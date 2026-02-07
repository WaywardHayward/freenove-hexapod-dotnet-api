using System.Net.Sockets;
using System.Text;
using hexapod_dotnet.Configuration;
using Microsoft.Extensions.Options;

namespace hexapod_dotnet.Services;

public class HexapodCommandInvoker : IHexapodCommandInvoker
{
    private readonly ILogger<HexapodCommandInvoker> _logger;
    private readonly HexapodSettings _settings;

    public HexapodCommandInvoker(ILogger<HexapodCommandInvoker> logger, IOptions<HexapodSettings> settings)
    {
        _logger = logger;
        _settings = settings.Value;
    }

    public async Task<string> InvokeCommandAsync(string command, bool expectResponse = false)
    {
        using var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        _logger.LogInformation("Connecting to {Host}:{Port}", _settings.Host, _settings.Port);
        await socket.ConnectAsync(_settings.Host, _settings.Port);
        _logger.LogInformation("Connected to {Host}:{Port}", _settings.Host, _settings.Port);

        _logger.LogInformation("Sending command {Command}", command);
        
        var bytes = Encoding.UTF8.GetBytes(command);
        await socket.SendAsync(bytes, SocketFlags.None);

        _logger.LogInformation("Sent command {Command}", command);

        if (expectResponse)
        {
            var buffer = new byte[1024];
            var bytesReceived = await socket.ReceiveAsync(buffer, SocketFlags.None);
            var response = Encoding.UTF8.GetString(buffer, 0, bytesReceived);
            _logger.LogInformation("Received response {Response}", response);
            return response;
        }
        
        await socket.DisconnectAsync(false);
        return "ok";
    }
}

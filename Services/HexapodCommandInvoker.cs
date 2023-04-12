using System.Net.Sockets;
using System.Text;
using hexapod_dotnet.Configuration;
using Microsoft.Extensions.Options;

namespace hexapod_dotnet.Services
{
    public class HexapodCommandInvoker
    {
        private readonly ILogger<HexapodCommandInvoker> _logger;
        private readonly Hexapod _hexapod;

        public HexapodCommandInvoker(ILogger<HexapodCommandInvoker> logger, IOptions<Hexapod> hexapod)
        {
            _logger = logger;
            _hexapod = hexapod.Value;
        }

        public async Task<string> InvokeCommand (string command, bool expectResponse = false)
        {
             try{
                // Connect to socket in hexapod options
                using var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                _logger.LogInformation($"Connecting to {_hexapod.Host}:{_hexapod.Port}");
                await socket.ConnectAsync(_hexapod.Host, _hexapod.Port);                
                _logger.LogInformation($"Connected to {_hexapod.Host}:{_hexapod.Port}");

                _logger.LogInformation($"Sending command {command}");
                
                // Send command
                var bytes = Encoding.UTF8.GetBytes(command);

                await socket.SendAsync(new ArraySegment<byte>(bytes), SocketFlags.None);

                _logger.LogInformation($"Sent command {command}");

                if(expectResponse){
                    // Get response
                    var buffer = new byte[1024];
                    var bytesReceived = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), SocketFlags.None);
                    var response = Encoding.UTF8.GetString(buffer, 0, bytesReceived);
                    _logger.LogInformation($"Received response {response}");
                    return response;
                }
                
                await socket.DisconnectAsync(false);

                _logger.LogInformation($"Sent command {command}");

                return "ok";

            }
            catch(Exception e){
                _logger.LogError(e, "Error sending command");  
                throw new Exception(e.Message);
            }
        }
    }
}
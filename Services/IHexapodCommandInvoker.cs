namespace hexapod_dotnet.Services;

public interface IHexapodCommandInvoker
{
    Task<string> InvokeCommandAsync(string command, bool expectResponse = false);
}

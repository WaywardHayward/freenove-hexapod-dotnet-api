namespace Hexapod.Services;

public interface IHexapodCommandInvoker
{
    Task<string> InvokeCommandAsync(string command, bool expectResponse = false);
}

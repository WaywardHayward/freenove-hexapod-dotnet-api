using hexapod_dotnet.Services;
using Microsoft.AspNetCore.Mvc;

namespace hexapod_dotnet.Controllers;

public abstract class HexapodController : ControllerBase
{
    protected readonly ILogger Logger;
    protected readonly IHexapodCommandInvoker Commander;
    
    protected HexapodController(ILogger logger, IHexapodCommandInvoker commander)
    {
        Logger = logger;
        Commander = commander;
    }

    protected async Task<ActionResult> InvokeCommandAsync(object command)
    {
        var commandString = command.ToString();
        if (string.IsNullOrEmpty(commandString))
        {
            return BadRequest("Command cannot be empty");
        }
        
        await Commander.InvokeCommandAsync(commandString);
        return Ok();
    }
}

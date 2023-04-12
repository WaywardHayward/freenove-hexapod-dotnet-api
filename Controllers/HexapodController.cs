using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hexapod_dotnet.Services;
using Microsoft.AspNetCore.Mvc;

namespace hexapod_dotnet.Controllers
{
    public abstract class HexapodController : ControllerBase
    {
        protected readonly ILogger _logger;
        protected readonly HexapodCommandInvoker _commander;
        protected HexapodController(ILogger logger, HexapodCommandInvoker commander)
        {
            _logger = logger;
            _commander = commander;
        }

        protected async Task<ActionResult> InvokeCommand(object command)
        {
            try
            {
                await _commander.InvokeCommand(command.ToString());
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error sending command");
                return BadRequest(e.Message);
            }
        }

    }
}
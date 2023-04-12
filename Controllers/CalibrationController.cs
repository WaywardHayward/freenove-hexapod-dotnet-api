using hexapod_dotnet.Model.Hexapod.Setters;
using hexapod_dotnet.Services;
using Microsoft.AspNetCore.Mvc;

namespace hexapod_dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalibrationController : HexapodController
    {
        public CalibrationController(ILogger<CalibrationController> logger, HexapodCommandInvoker invoker)
            :base(logger, invoker)
        {
        }

        [HttpPost("Led")]
        public async Task<ActionResult> CalibrateLed([FromBody] CalibrateLedCommand command) => await InvokeCommand(command);

        [HttpPost("Leg")]
        public async Task<ActionResult> CalibrateLeg([FromBody] CalibrateLegCommand command) => await InvokeCommand(command);

        [HttpPost("Attitude")]
        public async Task<ActionResult> Attitude([FromBody] AttitudeCommand attitudeCommand) => await InvokeCommand(attitudeCommand);

    }
}
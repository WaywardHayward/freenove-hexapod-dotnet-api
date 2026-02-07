using hexapod_dotnet.Model.Hexapod.Setters;
using hexapod_dotnet.Services;
using Microsoft.AspNetCore.Mvc;

namespace hexapod_dotnet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CalibrationController : HexapodController
{
    public CalibrationController(ILogger<CalibrationController> logger, IHexapodCommandInvoker invoker)
        : base(logger, invoker)
    {
    }

    [HttpPost("Led")]
    public async Task<ActionResult> CalibrateLed([FromBody] CalibrateLedCommand command) => 
        await InvokeCommandAsync(command);

    [HttpPost("Leg")]
    public async Task<ActionResult> CalibrateLeg([FromBody] CalibrateLegCommand command) => 
        await InvokeCommandAsync(command);

    [HttpPost("Attitude")]
    public async Task<ActionResult> Attitude([FromBody] AttitudeCommand command) => 
        await InvokeCommandAsync(command);
}

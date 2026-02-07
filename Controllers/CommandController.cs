using hexapod_dotnet.Model.Hexapod;
using hexapod_dotnet.Model.Hexapod.Setters;
using hexapod_dotnet.Services;
using Microsoft.AspNetCore.Mvc;

namespace hexapod_dotnet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommandController : HexapodController
{
    public CommandController(ILogger<CommandController> logger, IHexapodCommandInvoker commander)
        : base(logger, commander)
    {
    }
    
    [HttpPost("Reset")]
    public async Task<ActionResult> Reset() => 
        await InvokeCommandAsync(new ResetCommand());

    [HttpPost("Balance")]
    public async Task<ActionResult> Balance([FromBody] BalanceCommand command) => 
        await InvokeCommandAsync(command);

    [HttpPost("Position")]
    public async Task<ActionResult> Position([FromBody] PositionCommand command) => 
        await InvokeCommandAsync(command);

    [HttpPost("Move")]
    public async Task<ActionResult> Move([FromBody] MoveCommand command) => 
        await InvokeCommandAsync(command);

    [HttpPost("Buzz")]
    public async Task<ActionResult> Buzzer([FromBody] BuzzerCommand command) => 
        await InvokeCommandAsync(command);

    [HttpPost("Ready")]
    public async Task<ActionResult> Ready([FromBody] ReadyCommand command) => 
        await InvokeCommandAsync(command);

    [HttpPost("Led")]
    public async Task<ActionResult> Led([FromBody] LedCommand command) => 
        await InvokeCommandAsync(command);

    [HttpPost("Advanced")]
    public async Task<ActionResult> Advanced([FromBody] HexapodCommand command) => 
        await InvokeCommandAsync(command);
}

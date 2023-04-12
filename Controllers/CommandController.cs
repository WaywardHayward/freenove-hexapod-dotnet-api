using hexapod_dotnet.Model.Hexapod.Setters;
using hexapod_dotnet.Model.Hexapod;
using hexapod_dotnet.Services;
using Microsoft.AspNetCore.Mvc;

namespace hexapod_dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommandController : HexapodController
    {
        public CommandController(ILogger<CommandController> logger, HexapodCommandInvoker commander)
        :base(logger, commander)
        {
        }
        
        [HttpPost("Reset")]
        public async Task<ActionResult> Reset() => await InvokeCommand(new ResetCommand());

        [HttpPost("Balance")]
        public async Task<ActionResult> Balance([FromBody] BalanceCommand balanceCommand) => await InvokeCommand(balanceCommand);

        [HttpPost("Position")]
        public async Task<ActionResult> Move([FromBody] PositionCommand positionCommand) => await InvokeCommand(positionCommand);

        [HttpPost("Move")]
        public async Task<ActionResult> Move([FromBody] MoveCommand moveCommand) => await InvokeCommand(moveCommand);

        [HttpPost("Buzz")]
        public async Task<ActionResult> Buzzer([FromBody] BuzzerCommand buzzerCommand) => await InvokeCommand(buzzerCommand);

        [HttpPost("Ready")]
        public async Task<ActionResult> Ready([FromBody] ReadyCommand readyCommand) => await InvokeCommand(readyCommand);

        [HttpPost("Led")]
        public async Task<ActionResult> Led([FromBody] LedCommand command ) => await InvokeCommand(command);

        [HttpPost("Advanced")]
        public async Task<ActionResult> Send([FromBody]HexapodCommand command) => await InvokeCommand(command);
    }
}
using hexapod_dotnet.Model.Hexapod.Setters;
using hexapod_dotnet.Model.Hexapod;
using hexapod_dotnet.Services;
using Microsoft.AspNetCore.Mvc;

namespace hexapod_dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommandController : ControllerBase
    {
        private readonly ILogger<CommandController> _logger;
        private readonly HexapodCommandInvoker _commander;
        public CommandController(ILogger<CommandController> logger, HexapodCommandInvoker commander){
            _logger = logger;
            _commander = commander;
        }

        private async Task<ActionResult> InvokeCommand(object command){
            try{
                await _commander.InvokeCommand(command.ToString());
                return Ok();
            }
            catch(Exception e){
                _logger.LogError(e, "Error sending command");  
                return BadRequest(e.Message);
            }
        }

        
        [HttpPost("Reset")]
        public async Task<ActionResult> Reset() => await InvokeCommand(new ResetCommand());

        [HttpPost("Balance")]
        public async Task<ActionResult> Balance([FromBody] BalanceCommand balanceCommand) => await InvokeCommand(balanceCommand);

        [HttpPost("Attitude")]
        public async Task<ActionResult> Attitude([FromBody] AttitudeCommand attitudeCommand) => await InvokeCommand(attitudeCommand);

        [HttpPost("Position")]
        public async Task<ActionResult> Move([FromBody] PositionCommand positionCommand) => await InvokeCommand(positionCommand);

        [HttpPost("Move")]
        public async Task<ActionResult> Move([FromBody] MoveCommand moveCommand) {
            var readyCommand = new ReadyCommand { Ready = false };
            await InvokeCommand(readyCommand);
            readyCommand.Ready = true;
            await InvokeCommand(readyCommand);
            return await InvokeCommand(moveCommand);
        }

        [HttpPost("Buzz")]
        public async Task<ActionResult> Buzzer([FromBody] BuzzerCommand buzzerCommand) => await InvokeCommand(buzzerCommand);

        [HttpPost("Ready")]
        public async Task<ActionResult> Ready([FromBody] ReadyCommand readyCommand) => await InvokeCommand(readyCommand);

        [HttpPost("Calibrate/Led")]
        public async Task<ActionResult> CalibrateLed([FromBody] CalibrateLedCommand command ) => await InvokeCommand(command);

        [HttpPost("Calibrate/Leg")]
        public async Task<ActionResult> CalibrateLeg([FromBody] CalibrateLegCommand command ) => await InvokeCommand(command);

        [HttpPost("Led")]
        public async Task<ActionResult> Led([FromBody] LedCommand command ) => await InvokeCommand(command);

        [HttpPost("Advanced")]
        public async Task<ActionResult> Send([FromBody]HexapodCommand command) => await InvokeCommand(command);
    }
}
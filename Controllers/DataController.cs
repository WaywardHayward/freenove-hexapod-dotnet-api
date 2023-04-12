using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hexapod_dotnet.Model.Hexapod.Getters;
using hexapod_dotnet.Services;
using Microsoft.AspNetCore.Mvc;

namespace hexapod_dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        private readonly ILogger<DataController> _logger;
        private readonly HexapodCommandInvoker _invoker;

        public DataController(ILogger<DataController> logger, HexapodCommandInvoker invoker)
        {
            _logger = logger;
            _invoker = invoker;
        }

        [HttpGet("Power")]
        public async Task<ActionResult> Power()
        {
            try
            {
                var result = await _invoker.InvokeCommand(new PowerCommand().ToString(), true);
                var battery1 = result.Split('#')[1];
                var battery2 = result.Split('#')[2];
                return Ok(new {
                    Battery1 = battery1.Trim(),
                    Battery2 = battery2.Trim()
                });
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error sending command");
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Ultrasonic")]
        public async Task<ActionResult> Ultrasonic()
        {
            try
            {
                var result = await _invoker.InvokeCommand(new UltrasonicCommand().ToString(), true);
                return Ok(new {
                    Distance = result.Split('#').LastOrDefault()?.Trim()
                });
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error sending command");
                return BadRequest(e.Message);
            }
        }

    }
}
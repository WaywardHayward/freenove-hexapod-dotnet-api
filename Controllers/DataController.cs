using Hexapod.Models;
using Hexapod.Commands;
using Hexapod.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hexapod.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DataController : HexapodController
{
    public DataController(ILogger<DataController> logger, IHexapodCommandInvoker invoker)
        : base(logger, invoker)
    {
    }

    [HttpGet("Power")]
    public async Task<ActionResult<PowerResponse>> Power()
    {
        var result = await Commander.InvokeCommandAsync(new PowerCommand().ToString()!, expectResponse: true);
        var parts = result.Split('#');
        
        if (parts.Length < 3)
        {
            Logger.LogWarning("Unexpected power response format: {Response}", result);
            return BadRequest("Invalid response format from hexapod");
        }
        
        return Ok(new PowerResponse(parts[1].Trim(), parts[2].Trim()));
    }

    [HttpGet("Ultrasonic")]
    public async Task<ActionResult<UltrasonicResponse>> Ultrasonic()
    {
        var result = await Commander.InvokeCommandAsync(new UltrasonicCommand().ToString()!, expectResponse: true);
        var distance = result.Split('#').LastOrDefault()?.Trim();
        
        return Ok(new UltrasonicResponse(distance));
    }
}

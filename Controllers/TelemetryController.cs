using Microsoft.AspNetCore.Mvc;
using database_trade_study.Context;
using database_trade_study.Models;

[ApiController]
public class TelemetryController : Controller
{
    private readonly TelemetryContext _context;

    public TelemetryController(TelemetryContext context)
    {
        _context = context;
    }


    [HttpGet("telemetry")]
    public IActionResult GetTelemetry()
    {
        var data = _context.telemetry.ToList();

        if(data == null) 
        {
            return NotFound(new { message = "No data found" });
        }

        return Ok(data);
    }


    [HttpPost("telemetry")]
    public IActionResult PostTelemetry([FromBody] TelemetryData telemetryData)
    {
        if (telemetryData == null)
        {
            return BadRequest("Telemetry data is null.");
        }

         // Set the current timestamp if not provided
        if (telemetryData.timestamp == 0)
        {
            telemetryData.timestamp = ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds();
        }
            
        // Add the new telemetry data to the database
        _context.telemetry.Add(telemetryData);
        _context.SaveChanges();

        // Return a success response with the created data
        return Ok(telemetryData);
    }
}

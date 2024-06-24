using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using database_trade_study.Models;

[ApiController]
public class HelloWorldController : Controller
{
    [HttpGet("helloworld")]
    public IActionResult HelloWorld()
    {
        return Ok("Hello World. If you see this result, the API is working!");
    }

    [HttpPost("helloworld")]
    public IActionResult HelloWorldPost([FromBody] SamplePOSTModel model)
    {
        return Ok($"Hello {model.sampleName}! If you see this result, the API is working!");
    }
}

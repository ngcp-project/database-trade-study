using Microsoft.AspNetCore.Mvc;
using database_trade_study.Models;

[ApiController]
public class HelloWorldController : Controller
{
    [HttpGet("helloworld")]
    public IActionResult HelloWorld()
    {
        EndpointReturn endpointReturn = new EndpointReturn("", "", "");
        endpointReturn.message = "Hello World. If you see this result, the API is working!";

        Console.WriteLine("This is a sample Console.log message.");
        return Ok(endpointReturn.ToString());
    }

    [HttpPost("helloworld")]
    public IActionResult HelloWorldPost([FromBody] SamplePOSTModel model)
    {
        EndpointReturn endpointReturn = new EndpointReturn("", "", "");
        endpointReturn.message = $"Hello {model.sampleName}! If you see this result, the API is working!";
        endpointReturn.data = model.ToString();

        Console.WriteLine("Data: " + model.ToString());
        return Ok(endpointReturn.ToString());
    }
}

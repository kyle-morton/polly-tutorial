using Microsoft.AspNetCore.Mvc;

namespace ResponseService;

[Route("api/[Controller]")]
[ApiController]
public class ResponseController : ControllerBase
{
    public ResponseController()
    {
    }

    [Route("{id:int}")]
    [HttpGet]
    public ActionResult Get(int id) 
    {
        var rnd = new Random();
        var rndInteger = rnd.Next(1, 101);

        if (rndInteger >= id) {
            Console.WriteLine("Failure --> Generate a 500");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        Console.WriteLine("Success --> Generate a 200");
        return Ok();
    }
}

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
        return Ok();
    }
}

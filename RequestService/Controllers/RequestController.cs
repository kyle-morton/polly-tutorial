using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RequestService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RequestController : ControllerBase
{
    private readonly ILogger<RequestController> _logger;

    public RequestController(ILogger<RequestController> logger)
    {
        _logger = logger;
    }

    // GET api/request
    [HttpGet]
    public async Task<ActionResult> MakeRequest()
    {
        var client = new HttpClient();
        var response = await client.GetAsync("https://localhost:7286/api/response/25");

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("--> Response Returned Success");
            return Ok();
        }

        Console.WriteLine("--> Response returned Failure");
        return StatusCode(StatusCodes.Status500InternalServerError);
    }

}

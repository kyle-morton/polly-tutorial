using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RequestService.Policies;

namespace RequestService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RequestController : ControllerBase
{
    private ClientPolicy _clientPolicy;

    public RequestController(ClientPolicy clientPolicy)
    {
        _clientPolicy = clientPolicy;
    }

    // GET api/request
    [HttpGet]
    public async Task<ActionResult> MakeRequest()
    {
        var client = new HttpClient();

        // wrap our request in our client policy to retry
        var response = await _clientPolicy.ExponentialHttpRetry.ExecuteAsync(
            () => client.GetAsync("https://localhost:7286/api/response/25")
        );

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("--> Response Returned Success");
            return Ok();
        }

        Console.WriteLine("--> Response returned Failure");
        return StatusCode(StatusCodes.Status500InternalServerError);
    }

}

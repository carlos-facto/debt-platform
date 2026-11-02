using Microsoft.AspNetCore.Mvc;

namespace Debts.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class HelloController : ControllerBase
{
    public String Get()
    {
        return "Hello, Carlos!";
    }

    [HttpGet("{name}")]
    public ActionResult<string> Get(string name)
    {
        if (name.Length < 2)
            return BadRequest("The name is too short. Minimum length is 2 characters.");

        return Ok($"Hello, {name}!");
    }
}

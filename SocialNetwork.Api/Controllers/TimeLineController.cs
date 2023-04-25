using Microsoft.AspNetCore.Mvc;

namespace SocialNetwork.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TimeLineController : ControllerBase
{
    [HttpGet("{user}")]
    public object Get(string user)
    {
        throw new NotImplementedException();
    }
}
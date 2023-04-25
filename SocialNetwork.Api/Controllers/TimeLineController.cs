using Microsoft.AspNetCore.Mvc;

namespace SocialNetwork.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TimeLineController : ControllerBase
{
    [HttpGet("{user}")]
    public Task<IEnumerable<Message>> Get(string user)
    {
        return Task.FromResult(Enumerable.Empty<Message>());
    }
}
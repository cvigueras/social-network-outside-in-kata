using Microsoft.AspNetCore.Mvc;

namespace SocialNetwork.Api.Messages;

[ApiController]
[Route("[controller]")]
public class WallController : ControllerBase
{
    [HttpGet]
    public Task<IEnumerable<Message>> Get()
    {
        throw new NotImplementedException();
    }
}
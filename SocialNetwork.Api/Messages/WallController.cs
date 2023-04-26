using Microsoft.AspNetCore.Mvc;

namespace SocialNetwork.Api.Messages;

[ApiController]
[Route("[controller]")]
public class WallController : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<Message>> Get()
    {
        return await Task.FromResult(Enumerable.Empty<Message>());
    }
}
using Microsoft.AspNetCore.Mvc;

namespace SocialNetwork.Api.Messages;

[ApiController]
[Route("[controller]")]
public class WallController : ControllerBase
{
    private readonly IMessagesRepository _messagesRepository;

    public WallController(IMessagesRepository messagesRepository)
    {
        _messagesRepository = messagesRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<Message>> Get()
    {
        return await Task.FromResult(Enumerable.Empty<Message>());
    }
}
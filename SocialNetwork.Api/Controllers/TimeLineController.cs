using Microsoft.AspNetCore.Mvc;

namespace SocialNetwork.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TimeLineController : ControllerBase
{
    private readonly IMessagesRepository _messagesRepository;
    private readonly ITime _time;

    public TimeLineController(IMessagesRepository messagesRepository, ITime time)
    {
        _messagesRepository = messagesRepository;
        _time = time;
    }

    [HttpGet("{author}")]
    public Task<IEnumerable<Message>> Get(string author)
    {
        return _messagesRepository.Get(author);
    }

    [HttpPost("{author}")]
    public Task Post(string author, MessageDto messageDto)
    {
        _messagesRepository.Add(
            new Message
            {
                Timestamp = _time.Timestamp(),
                Post = messageDto.Post,
                Author = author,
            }
        );
        return Task.CompletedTask;
    }
}
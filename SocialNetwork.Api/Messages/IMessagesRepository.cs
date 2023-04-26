namespace SocialNetwork.Api.Messages;

public interface IMessagesRepository
{
    public Task Add(Message message);
    Task<IEnumerable<Message>> Get(string author);
}
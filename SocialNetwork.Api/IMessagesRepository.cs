namespace SocialNetwork.Api;

public interface IMessagesRepository
{
    public void Add(Message message);
    IEnumerable<Message> Get();
}
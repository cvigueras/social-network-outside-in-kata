namespace SocialNetwork.Api;

public interface ISubscriptionRepository
{
    Task<IEnumerable<Subscription>> Add(Subscription subscription);
}
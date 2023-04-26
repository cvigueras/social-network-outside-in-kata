namespace SocialNetwork.Api;

public interface ISubscriptionRepository
{
    Task Add(Subscription subscription);
}
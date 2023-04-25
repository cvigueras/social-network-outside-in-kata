using Microsoft.AspNetCore.Mvc;

namespace SocialNetwork.Api.Controllers;

public class SubscriptionsController : ControllerBase
{
    private readonly SubscriptionRepository _subscriptionRepository;

    public SubscriptionsController(SubscriptionRepository subscriptionRepository)
    {
        _subscriptionRepository = subscriptionRepository;
    }

    [HttpPost("{user}")]
    public void Post(string user, SubscriptionDto givenSubscription)
    {
        throw new NotImplementedException();
    }
}
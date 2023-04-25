using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace SocialNetwork.Test
{
    public class SubscriptionsControllerShould
    {
        private SubscriptionRepository _subscriptionRepository;

        [SetUp]
        public void SetUp()
        {
            _subscriptionRepository = Substitute.For<SubscriptionRepository>();
        }

        [Test]
        public void SubscribeUserToOtherUser()
        {
            var givenSubscription = new SubscriptionDto
            {
                Subscriber = "Charlie",
            };


            var subscriptionController = new SubscriptionsController(_subscriptionRepository);
            subscriptionController.Post("Alice", givenSubscription);

            var expectedSubscription = new Subscription
            {
                User = "Alice",
                Subscriber = "Charlie",

            };
            _subscriptionRepository.Received().Add(expectedSubscription);
        }
    }

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

    public class SubscriptionDto
    {
        public string Subscriber { get; set; }
    }

    public class SubscriptionRepository
    {
        public void Add(Subscription subscription)
        {
            throw new NotImplementedException();
        }
    }

    public class Subscription
    {
        public string User { get; set; }
        public string Subscriber { get; set; }
    }
}

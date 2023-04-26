using FluentAssertions;
using NSubstitute;
using NSubstitute.ClearExtensions;
using SocialNetwork.Api.Messages;
using SocialNetwork.Api.Time;

namespace SocialNetwork.Test.Messages
{
    public class WallShould
    {
        private WallController _wallController;
        private IMessagesRepository _messagesRepository;
        private ITime _time;


        [SetUp]
        public void SetUp()
        {
            _messagesRepository = Substitute.For<IMessagesRepository>();
            _wallController = new WallController(_messagesRepository);
            _time = Substitute.For<ITime>();
        }

        [Test]
        public async Task ReturnEmptyMessages()
        {
            var givenMessage = Enumerable.Empty<Message>();
            _messagesRepository.GetByAuthorAndSubscriptions("Alice").Returns(givenMessage);

            var result = await _wallController.Get();

            result.Should().BeEmpty();
        }

        [Test]
        public void GetOneMessageFromOwnAndSubscription()
        {
            var givenMessage = new Message
            {
                Post = "Hello everyone.",
                Author = "Alice",
                Timestamp = _time.Timestamp(),
            };
            var result = _messagesRepository.GetByAuthorAndSubscriptions("Alice");
            result.Should().Be(givenMessage);
        }
    }
}

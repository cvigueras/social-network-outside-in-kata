using FluentAssertions;
using NSubstitute;
using SocialNetwork.Api;
using SocialNetwork.Api.Controllers;

namespace SocialNetwork.Test
{
    public class TimeLineControllerShould
    {
        private TimeLineController _timelineController;
        private IMessagesRepository _messagesRepository;
        private ITime _time;

        [SetUp]
        public void Setup()
        {
            _messagesRepository = Substitute.For<IMessagesRepository>();
            _time = Substitute.For<ITime>();
            _timelineController = new TimeLineController(_messagesRepository, _time);
        }

        [Test]
        public async Task GetEmptyWhenGetOwnMessages()
        {
            _messagesRepository.Get().Returns(Enumerable.Empty<Message>());

            var result = await _timelineController.Get("Alice");

            result.Should().BeEmpty();
        }

        [Test]
        public void PostMessage()
        {
            _time.Timestamp.Returns(new DateTime(2023, 4, 18, 14, 35, 0));
            var givenMessage = new MessageDto
            {
                Post = "Hello everyone",
                Author = "Alice",
            };

            _timelineController.Post(givenMessage);

            var expectedMessage = new Message
            {
                Timestamp = _time.Timestamp,
                Post = "Hello everyone",
                Author = "Alice",
            };
            _messagesRepository.Received().Add(expectedMessage);
        }
    }
}

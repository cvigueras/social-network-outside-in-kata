using FluentAssertions;
using FluentAssertions.Common;
using NSubstitute;
using SocialNetwork.Api.Controllers;

namespace SocialNetwork.Test
{
    public class TimeLineControllerShould
    {
        [Test]
        public async Task GetEmptyWhenGetOwnMessages()
        {
            var timelineController = new TimeLineController();

            var result = await timelineController.Get("Alice");

            result.Should().BeEmpty();
        }

        [Test]
        public void PostMessage()
        {
            var timelineController = new TimeLineController();
            var timelineRepository = Substitute.For<ITimeLineRepository>();
            var time = Substitute.For<ITime>();
            time.Timestamp.Returns(new DateTime(2023, 4, 18, 14, 35, 0));
            var givenMessage = new MessageDto
            {
                Post = "Hello everyone"
            };

            timelineController.Post(givenMessage);

            var expectedMessage = new Message
            {
                Timestamp = time.Timestamp,
                Post = "Hello everyone",
                Author = "Alice",
            };
            timelineRepository.Received().Add(expectedMessage);
        }
    }

    public class MessageDto
    {
        public string Post { get; set; }
    }

    public interface ITime
    {
        DateTime Timestamp { get; }
    }

    public interface ITimeLineRepository
    {
        public void Add(Message message);
    }
}

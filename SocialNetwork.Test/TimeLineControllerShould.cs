using FluentAssertions;
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
    }
}

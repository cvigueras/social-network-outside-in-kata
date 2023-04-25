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

            var result = timelineController.Get("Alice");

            result.ToString().Should().BeEmpty();
        }
    }
}

using FluentAssertions;
using SocialNetwork.Api.Messages;

namespace SocialNetwork.Test.Messages
{
    public class WallShould
    {
        [Test]
        public async Task ReturnEmptyMessages()
        {
            var wallController = new WallController();
            var result = await wallController.Get();

            result.Should().BeEmpty();
        }
    }
}

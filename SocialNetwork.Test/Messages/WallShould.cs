using FluentAssertions;
using SocialNetwork.Api.Messages;

namespace SocialNetwork.Test.Messages
{
    public class WallShould
    {
        [Test]
        public void ReturnEmptyMessages()
        {
            var wallController = new WallController();
            var result = wallController.Get();

            result.Should().Be(Enumerable.Empty<Message>());
        }
    }
}

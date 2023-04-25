using Newtonsoft.Json;

namespace SocialNetwork.Test
{
    public class PostFeature
    {
        [Test]
        public async Task GetOwnUserMessagesAfterPost()
        {
            var socialNetwork = new SocialNetworkApplication();
            var client = socialNetwork.CreateClient();

            await client.PostAsync("/Timeline/Alice", new StringContent("{\"message\":\"Hello world\"}"));
            await client.PostAsync("/Timeline/Alice", new StringContent("{\"message\":\"I'm new user\"}"));
            await client.PostAsync("/Timeline/Alice", new StringContent("{\"message\":\"Hello everyone\"}"));

            var response = await client.GetAsync("/Timeline/Alice");

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var json = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(content), Formatting.Indented);

            await Verify(json);
        }
    }
}

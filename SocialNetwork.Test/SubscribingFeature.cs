using NSubstitute;
using SocialNetwork.Api;
using System.Text;
using Newtonsoft.Json;

namespace SocialNetwork.Test
{
    public class SubscribingFeature
    {
        [Test]
        public async Task GetOwnUserAndSubscribingMessagesAfterOtherUsersPost()
        {
            var time = Substitute.For<ITime>();
            var socialNetwork = new SocialNetworkApplication(time);
            time.Timestamp().Returns(new DateTime(2023, 4, 18, 14, 35, 0),
                new DateTime(2023, 4, 18, 14, 38, 0),
                new DateTime(2023, 4, 18, 14, 48, 0));

            var client = socialNetwork.CreateClient();

            var result = await client.PostAsync("/Timeline/Bob", 
                new StringContent("{\"post\":\"Hello I am Bob\"}", Encoding.Default, "application/json"));
            result.EnsureSuccessStatusCode();
            result = await client.PostAsync("/Timeline/Alice", 
                new StringContent("{\"post\":\"Hello I am Alice\"}", Encoding.Default, "application/json"));
            result.EnsureSuccessStatusCode();
            result = await client.PostAsync("/Timeline/Charlie", 
                new StringContent("{\"post\":\"Hello I am Charlie\"}", Encoding.Default, "application/json"));
            result.EnsureSuccessStatusCode();

            result = await client.PostAsync("/Subscriptions/Alice",
                new StringContent("{\"subscriber\":\"Charlie\"}", Encoding.Default, "application/json"));
            result.EnsureSuccessStatusCode();
            result = await client.PostAsync("/Subscriptions/Bob",
                new StringContent("{\"subscriber\":\"Charlie\"}", Encoding.Default, "application/json"));
            result.EnsureSuccessStatusCode();

            var response = await client.GetAsync("/Wall/Charlie");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var json = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(content), Formatting.Indented);

            await Verify(json);
        }
    }
}

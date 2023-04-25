﻿using Newtonsoft.Json;
using NSubstitute;
using SocialNetwork.Api;
using System.Text;

namespace SocialNetwork.Test
{
    public class PostFeature
    {
        [Test]
        public async Task GetOwnUserMessagesAfterPost()
        {
            var time = Substitute.For<ITime>();
            var socialNetwork = new SocialNetworkApplication(time);
            time.Timestamp().Returns(new DateTime(2023, 4, 18, 14, 35, 0),
                new DateTime(2023, 4, 18, 14, 38, 0),
                new DateTime(2023, 4, 18, 14, 48, 0));

            var client = socialNetwork.CreateClient();

            var result = await client.PostAsync("/Timeline/Alice", new StringContent("{\"post\":\"Hello world\"}", Encoding.Default, "application/json"));
            result.EnsureSuccessStatusCode();
            result = await client.PostAsync("/Timeline/Alice", new StringContent("{\"post\":\"I am new user\"}", Encoding.Default, "application/json"));
            result.EnsureSuccessStatusCode();
            result = await client.PostAsync("/Timeline/Alice", new StringContent("{\"post\":\"Hello everyone\"}", Encoding.Default, "application/json"));
            result.EnsureSuccessStatusCode();

            var response = await client.GetAsync("/Timeline/Alice");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var json = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(content), Formatting.Indented);

            await Verify(json);
        }
    }
}

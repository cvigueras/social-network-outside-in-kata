

using Newtonsoft.Json;

namespace SocialNetwork.Test
{
    public class WeatherForecastShould
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetWeather()
        {
            var socialNetwork = new SocialNetworkApplication();
            var client = socialNetwork.CreateClient();
            var response = await client.GetAsync("/WeatherForecast");

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var json = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(content), Formatting.Indented);

            await Verify(json);

        }
    }
}
namespace WeatherAPI.Services
{
    using System.Text;
    using Newtonsoft.Json;
    using WeatherAPI.Interfaces;

    public class PostService : IPostService
    {
        private const string Url = $"https://suggestions.dadata.ru/suggestions/api/4_1/rs/suggest/postal_office";

        public async Task<string> GetZipByCityName(string name, string apiKey)
        {
            using var client = new HttpClient();

            // client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Authorization", "Token " + apiKey);
            client.DefaultRequestHeaders.Add("Authorization", "Token " + apiKey);

            var body = $"\"query\":\"{name}\"";
            var data = new StringContent("{" + body + "}", Encoding.UTF8, "application/json");

            var response = await client.PostAsync(Url, data);

            dynamic report = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync()) !;
            string zip = report.suggestions[0].data.index;
            return zip;
        }
    }
}

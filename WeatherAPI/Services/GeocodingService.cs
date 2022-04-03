namespace WeatherAPI.Services
{
    using Newtonsoft.Json;
    using WeatherAPI.Interfaces;
    using WeatherAPI.Model;

    public class GeocodingService : IGeocodingService
    {
        private const string ApiId = "{apiid}";
        private const string Zip = "{zip}";
        private const string Uri = $"http://api.openweathermap.org/geo/1.0/zip?zip={Zip},RU&appid={ApiId}";

        public async Task<Coordinate> GetCoordinateByZip(string zip, string apiId)
        {
            string requestUrl = Uri
                 .Replace(Zip, zip)
                 .Replace(ApiId, apiId);

            var client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(requestUrl);

            dynamic report = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync()) !;

            double lat = report.lat;
            double lon = report.lon;

            return new Coordinate(lat, lon);
        }
    }
}

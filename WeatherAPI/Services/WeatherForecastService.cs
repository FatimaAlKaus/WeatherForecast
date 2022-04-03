namespace WeatherAPI.Services
{
    using Newtonsoft.Json;
    using WeatherAPI.Interfaces;
    using WeatherAPI.Model;

    public class WeatherForecastService : IWeatherForecastService
    {
        private const string Lat = "{lat}";
        private const string Lon = "{lon}";
        private const string ApiId = "{apiid}";
        private const string Uri = $"https://api.openweathermap.org/data/2.5/weather?lat={Lat}&lon={Lon}&appid={ApiId}&lang=ru&units=metric";

        private readonly IGeocodingService _geocodingService;

        public WeatherForecastService(IGeocodingService geocodingService)
        {
            _geocodingService = geocodingService;
        }

        public async Task<WeatherReport> GetCurentWeatherByCoordinate(double lat, double lon, string apiId)
        {
            string requestUrl = Uri
                 .Replace(Lat, lat.ToString())
                 .Replace(Lon, lon.ToString())
                 .Replace(ApiId, apiId);

            return await GetWeather(requestUrl);
        }

        public async Task<WeatherReport> GetWeatherByZip(string zip, string apiId)
        {
            Coordinate coordinate = await _geocodingService.GetCoordinateByZip(zip, apiId);

            string requestUrl = Uri
                 .Replace(Lat, coordinate.Latitude.ToString())
                 .Replace(Lon, coordinate.Longitude.ToString())
                 .Replace(ApiId, apiId);

            return await GetWeather(requestUrl);
        }

        private async Task<WeatherReport> GetWeather(string url)
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);

            dynamic report = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync()) !;

            string description = report.weather[0].description;
            string icon = report.weather[0].icon;
            double temp = report.main.temp;
            double feelsLike = report.main.feels_like;
            double windSpeed = report.wind.speed;
            string name = report.name;

            return new WeatherReport(description, GetIcon(icon), temp, feelsLike, windSpeed, name);
        }

        private string GetIcon(string iconId)
        {
            return $"https://openweathermap.org/img/wn/{iconId}@2x.png";
        }
    }
}

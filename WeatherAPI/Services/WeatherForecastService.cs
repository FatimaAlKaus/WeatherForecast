namespace WeatherAPI.Services
{
    using Newtonsoft.Json;
    using WeatherAPI.Interfaces;
    using WeatherAPI.Model;
    using WeatherAPI.Utils;

    public class WeatherForecastService : IWeatherForecastService
    {
        private const string Lat = "{lat}";
        private const string Lon = "{lon}";
        private const string ApiId = "{apiid}";
        private const string CurrentWeatherDataUrl = $"https://api.openweathermap.org/data/2.5/weather?lat={Lat}&lon={Lon}&appid={ApiId}&lang=ru&units=metric";
        private const string OneCallUrl = $"https://api.openweathermap.org/data/2.5/onecall?lat={Lat}&lon={Lon}&exclude=minutely,current,hourly&appid={ApiId}&units=metric&lang=ru";

        private readonly IGeocodingService _geocodingService;

        public WeatherForecastService(IGeocodingService geocodingService)
        {
            _geocodingService = geocodingService;
        }

        public async Task<WeatherReport> GetCurentWeatherByCoordinate(double lat, double lon, string apiId)
        {
            string requestUrl = CurrentWeatherDataUrl
                 .Replace(Lat, lat.ToString())
                 .Replace(Lon, lon.ToString())
                 .Replace(ApiId, apiId);

            return await GetWeather(requestUrl);
        }

        public async Task<WeatherReport> GetWeatherByZip(string zip, string apiId)
        {
            Coordinate coordinate = await _geocodingService.GetCoordinateByZip(zip, apiId);

            string requestUrl = CurrentWeatherDataUrl
                 .Replace(Lat, coordinate.Latitude.ToString())
                 .Replace(Lon, coordinate.Longitude.ToString())
                 .Replace(ApiId, apiId);

            return await GetWeather(requestUrl);
        }

        public async Task<WeatherReport[]> GetWeathersFor7Days(string zip, string apiId)
        {
            Coordinate coordinate = await _geocodingService.GetCoordinateByZip(zip, apiId);

            string requestUrl = OneCallUrl
                .Replace(Lat, coordinate.Latitude.ToString())
                .Replace(Lon, coordinate.Longitude.ToString())
                .Replace(ApiId, apiId);

            return await GetWeathers(requestUrl);
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

            return new WeatherReport(description, GetIcon(icon), temp, feelsLike, windSpeed);
        }

        private async Task<WeatherReport[]> GetWeathers(string url)
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);

            dynamic report = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync()) !;

            var weathers = new List<WeatherReport>();
            foreach (var dayReport in report.daily)
            {
                long unixTimeStamp = dayReport.dt;
                DateTime dateTime = UnixToDateTimeConverter.Convert(unixTimeStamp);
                string description = dayReport.weather[0].description;
                string icon = dayReport.weather[0].icon;
                double tempDay = dayReport.temp.day;
                double tempNight = dayReport.temp.night;
                double windSpeed = dayReport.wind_speed;

                var dReport = new WeatherReport(description, GetIcon(icon), tempDay, tempNight, windSpeed) { Date = dateTime };
                weathers.Add(dReport);
            }

            return weathers.ToArray();
        }

        private string GetIcon(string iconId)
        {
            return $"https://openweathermap.org/img/wn/{iconId}@2x.png";
        }
    }
}

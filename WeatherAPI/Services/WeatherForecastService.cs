namespace WeatherAPI.Services
{
    using System;
    using WeatherAPI.Interfaces;
    using WeatherAPI.Model;

    public class WeatherForecastService : IWeatherForecastService
    {
        private const string Lat = "{lat}";
        private const string Lon = "{lon}";
        private const string ApiId = "{apiid}";
        private const string Uri = $"https://api.openweathermap.org/data/2.5/weather?lat={Lat}&lon={Lon}&appid={ApiId}&lang=ru&units=metric";

        public WeatherForecastService()
        {
        }

        public async Task<string> GetCurrentWeather(double lat, double lon, string apiId)
        {
            string requestUrl = Uri
                 .Replace(Lat, lat.ToString())
                 .Replace(Lon, lon.ToString())
                 .Replace(ApiId, apiId);

            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(requestUrl);
            return await response.Content.ReadAsStringAsync();
        }

        public WeatherReport PredictForDay()
        {
            throw new NotImplementedException();
        }
    }
}

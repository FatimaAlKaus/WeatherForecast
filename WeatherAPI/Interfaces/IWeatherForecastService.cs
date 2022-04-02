namespace WeatherAPI.Interfaces
{
    public interface IWeatherForecastService
    {
        public Task<string> GetCurrentWeather(double lat, double lon, string apiId);
    }
}

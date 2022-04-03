namespace WeatherAPI.Interfaces
{
    using WeatherAPI.Model;

    public interface IWeatherForecastService
    {
        Task<WeatherReport> GetCurentWeatherByCoordinate(double lat, double lon, string apiId);

        Task<WeatherReport> GetWeatherByZip(string zip, string apiId);

        Task<WeatherReport[]> GetWeathersFor7Days(string zip, string apiId);
    }
}

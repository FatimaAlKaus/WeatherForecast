namespace WeatherAPI.Interfaces
{
    using WeatherAPI.Model;

    public interface IGeocodingService
    {
        Task<Coordinate> GetCoordinateByZip(string zip, string apiId);
    }
}

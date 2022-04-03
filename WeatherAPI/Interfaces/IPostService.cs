namespace WeatherAPI.Interfaces
{
    public interface IPostService
    {
        Task<string> GetZipByCityName(string name, string apiKey);
    }
}

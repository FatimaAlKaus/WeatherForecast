namespace WeatherAPI.Model
{
    public class WeatherReport
    {
        public WeatherReport(string description, string icon, double temp, double feelsLike, double windSpeed, string cityName)
        {
            Description = description;
            Icon = icon;
            Temp = temp;
            FeelsLike = feelsLike;
            WindSpeed = windSpeed;
            CityName = cityName;
        }

        public string Description { get; }

        public string Icon { get; }

        public double Temp { get; }

        public double FeelsLike { get; }

        public double WindSpeed { get; }

        public string CityName { get; }
    }
}

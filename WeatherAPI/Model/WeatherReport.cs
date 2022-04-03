namespace WeatherAPI.Model
{
    public class WeatherReport
    {
        public WeatherReport(string description, string icon, double tempDay, double tempNight, double windSpeed)
        {
            Description = description;
            Icon = icon;
            TempDay = tempDay;
            TempNight = tempNight;
            WindSpeed = windSpeed;
        }

        public DateTime Date { get; init; }

        public string DayOfWeek => Date.DayOfWeek.ToString();

        public string Description { get; }

        public string Icon { get; }

        public double TempDay { get; }

        public double TempNight { get; }

        public double WindSpeed { get; }
    }
}

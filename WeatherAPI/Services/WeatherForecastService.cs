namespace WeatherAPI.Services
{
    using System;
    using WeatherAPI.Interfaces;
    using WeatherAPI.Model;

    public class WeatherForecastService : IWeatherForecastService
    {
        public WeatherReport[] PredictForWeek()
        {
            throw new NotImplementedException();
        }

        public WeatherReport PredictForDay()
        {
            throw new NotImplementedException();
        }
    }
}

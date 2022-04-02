using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAPI.Interfaces;
using WeatherAPI.Model;

namespace WeatherAPI.Services
{
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

using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherAPI.Interfaces;

namespace WeatherForecast.ViewModel
{
    internal class MainWindowVM : BindableBase
    {
        private readonly IWeatherForecastService _weatherService;
        public MainWindowVM(IWeatherForecastService weatherService)
        {
            _weatherService = weatherService;
        }
    }
}

namespace WeatherForecast.ViewModel
{
    using DevExpress.Mvvm;
    using WeatherAPI.Interfaces;

    internal class MainWindowVM : BindableBase
    {
        private readonly IWeatherForecastService _weatherService;

        public MainWindowVM(IWeatherForecastService weatherService)
        {
            _weatherService = weatherService;
        }
    }
}

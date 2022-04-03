namespace WeatherForecast.ViewModel
{
    using System.Configuration;
    using System.Windows.Input;
    using DevExpress.Mvvm;
    using WeatherAPI.Interfaces;
    using WeatherAPI.Model;

    internal class MainWindowVM : BindableBase
    {
        private readonly IWeatherForecastService _weatherService;

        public MainWindowVM(IWeatherForecastService weatherService)
        {
            _weatherService = weatherService;
        }

        public int Lon { get; set; }

        public int Lat { get; set; }

        public string Zip { get; set; } = string.Empty;

        public ICommand SendRequest => new AsyncCommand(async () =>
        {
            var key = ConfigurationManager.AppSettings["apiid"] !;

            Report = await _weatherService.GetWeatherByZip(Zip, key);
            RaisePropertyChanged("Report");
        });

        public WeatherReport Report { get; set; } = null!;
    }
}

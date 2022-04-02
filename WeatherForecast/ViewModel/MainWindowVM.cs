namespace WeatherForecast.ViewModel
{
    using System.Configuration;
    using System.Windows.Input;
    using DevExpress.Mvvm;
    using Newtonsoft.Json;
    using WeatherAPI.Interfaces;

    internal class MainWindowVM : BindableBase
    {
        private readonly IWeatherForecastService _weatherService;

        private int _lat;
        private int _lon;

        public MainWindowVM(IWeatherForecastService weatherService)
        {
            _weatherService = weatherService;
        }

        public int Lon
        {
            get => _lon;
            set
            {
                _lon = value;
                RaisePropertiesChanged("Lon");
            }
        }

        public int Lat
        {
            get => _lat;
            set
            {
                _lat = value;
                RaisePropertiesChanged("Lat");
            }
        }

        public ICommand SendRequest => new AsyncCommand(async () =>
        {
            var key = ConfigurationManager.AppSettings["apiid"] !;
            string response = await _weatherService.GetCurrentWeather(lat: Lat, lon: Lon, key);
            dynamic report = JsonConvert.DeserializeObject(response) !;

            Response = report.name;
            RaisePropertiesChanged("Response");
        });

        public string Response { get; set; } = string.Empty;
    }
}

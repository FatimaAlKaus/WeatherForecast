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

        public MainWindowVM(IWeatherForecastService weatherService)
        {
            _weatherService = weatherService;
        }

        public int Lon { get; set; }

        public int Lat { get; set; }

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

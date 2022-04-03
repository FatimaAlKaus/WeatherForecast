namespace WeatherForecast.ViewModel
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Windows.Input;
    using DevExpress.Mvvm;
    using WeatherAPI.Interfaces;
    using WeatherAPI.Model;

    internal class MainWindowVM : BindableBase
    {
        private readonly IWeatherForecastService _weatherService;
        private readonly IPostService _postService;

        public MainWindowVM(IWeatherForecastService weatherService, IPostService postService)
        {
            _weatherService = weatherService;
            _postService = postService;
        }

        public ICommand Predict => new AsyncCommand(async () =>
        {
            var pKey = ConfigurationManager.AppSettings["PostApiId"] !;
            var wKey = ConfigurationManager.AppSettings["WeatherApiId"] !;
            Index = await _postService.GetZipByCityName(CityName, pKey);
            Reports = (await _weatherService.GetWeathersFor7Days(Index, wKey)).ToList();
            RaisePropertyChanged("Reports");
        });

        public string CityName { get; set; } = string.Empty;

        public List<WeatherReport> Reports { get; set; } = null!;

        public string Index { get; set; } = string.Empty;
    }
}

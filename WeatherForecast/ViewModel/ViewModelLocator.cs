namespace WeatherForecast.ViewModel
{
    internal class ViewModelLocator
    {
        public MainWindowVM MainWindowVM => IoC.GetRequiredService<MainWindowVM>();
    }
}

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAPI.Interfaces;
using WeatherAPI.Services;
using WeatherForecast.View;
using WeatherForecast.ViewModel;

namespace WeatherForecast
{
    internal static class IoC
    {
        private static readonly IServiceProvider _serviceProvider;
        static IoC()
        {
            _serviceProvider = ConfigureServices();
        }
        public static T GetRequiredService<T>() where T : notnull => _serviceProvider.GetRequiredService<T>();
        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<IWeatherForecastService, WeatherForecastService>();
            services.AddTransient<MainWindowVM>();
            services.AddTransient<MainWindow>();

            return services.BuildServiceProvider();
        }
    }
}

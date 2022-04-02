namespace WeatherForecast
{
    using System;
    using Microsoft.Extensions.DependencyInjection;
    using WeatherAPI.Interfaces;
    using WeatherAPI.Services;
    using WeatherForecast.View;
    using WeatherForecast.ViewModel;

    internal static class IoC
    {
        private static readonly IServiceProvider ServiceProvider;

        static IoC()
        {
            ServiceProvider = ConfigureServices();
        }

        public static T GetRequiredService<T>()
            where T : notnull
            => ServiceProvider.GetRequiredService<T>();

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

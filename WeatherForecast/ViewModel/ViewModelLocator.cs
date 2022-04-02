using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.ViewModel
{
    internal class ViewModelLocator
    {
        public MainWindowVM MainWindowVM => IoC.GetRequiredService<MainWindowVM>();
    }
}

namespace WeatherForecast.Component
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    /// <summary>
    /// Interaction logic for WeatherPresentation.xaml.
    /// </summary>
    public partial class WeatherPresentation : UserControl
    {
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(ImageSource), typeof(WeatherPresentation), new PropertyMetadata(null));

        public static readonly DependencyProperty DescriptionProperty =
                    DependencyProperty.Register("Description", typeof(string), typeof(WeatherPresentation), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty TempProperty =
            DependencyProperty.Register("Temp", typeof(int), typeof(WeatherPresentation), new PropertyMetadata(0));

        public static readonly DependencyProperty WindSpeedProperty =
                    DependencyProperty.Register("WindSpeed", typeof(double), typeof(WeatherPresentation), new PropertyMetadata(default(double)));

        public static readonly DependencyProperty DayOfWeekProperty =
            DependencyProperty.Register("DayOfWeek", typeof(string), typeof(WeatherPresentation), new PropertyMetadata(string.Empty));

        public WeatherPresentation()
        {
            InitializeComponent();
        }

        public string DayOfWeek
        {
            get { return (string)GetValue(DayOfWeekProperty); }
            set { SetValue(DayOfWeekProperty, value); }
        }

        public double WindSpeed
        {
            get { return (double)GetValue(WindSpeedProperty); }
            set { SetValue(WindSpeedProperty, value); }
        }

        public int Temp
        {
            get { return (int)GetValue(TempProperty); }
            set { SetValue(TempProperty, value); }
        }

        public ImageSource Icon
        {
            get { return (ImageSource)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }
    }
}

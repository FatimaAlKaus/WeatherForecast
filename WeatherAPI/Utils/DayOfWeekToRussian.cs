namespace WeatherAPI.Utils
{
    internal static class DayOfWeekToRussian
    {
        private static Dictionary<DayOfWeek, string> _enRuPairs = new Dictionary<DayOfWeek, string>()
        {
            { DayOfWeek.Monday, "Пн" },
            { DayOfWeek.Tuesday, "Вт" },
            { DayOfWeek.Wednesday, "Ср" },
            { DayOfWeek.Thursday, "Чт" },
            { DayOfWeek.Friday, "Пт" },
            { DayOfWeek.Saturday, "Cб" },
            { DayOfWeek.Sunday, "Вс" },
        };

        public static string From(DayOfWeek day) => _enRuPairs[day];
    }
}

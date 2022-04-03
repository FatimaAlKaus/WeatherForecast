namespace WeatherAPI.Model
{
    public struct Coordinate
    {
        public Coordinate(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}

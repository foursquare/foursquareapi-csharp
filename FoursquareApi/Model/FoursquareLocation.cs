namespace Foursquare.Model
{
    public enum LocationSource
    {
        Cellular = 0,
        Satellite = 1,
        WiFi = 2,
        IPAddress = 3,
        Unknown = 4
    }

    public sealed class FoursquareLocation
    {
        public FoursquareLocation()
        {

        }

        public FoursquareLocation(double lat, double lng)
        {
            Lat = lat;
            Lng = lng;
        }

        public double Lat { get; set; }
        public double Lng { get; set; }
        public double Accuracy { get; set; }
        public double Heading { get; set; }
        public double Speed { get; set; }
        public long Timestamp { get; set; }
        public LocationSource Source { get; set; }

        public override string ToString()
        {
            return this.Lat + "," + this.Lng + "," + this.Accuracy + "," + this.Timestamp / 1000;
        }
    }
}

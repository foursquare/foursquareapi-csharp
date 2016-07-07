namespace Foursquare.Model
{
    public class LatLng : IFoursquareType
    {
        public double lat { get; set; }
        public double lng { get; set; }
        public string contextLine { get; set; }
        public string name { get; set; }
    }
}

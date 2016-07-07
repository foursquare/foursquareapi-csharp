namespace Foursquare.Model
{
    public sealed class GeoCircle : IFoursquareType
    {
        public int radius { get; set; }
        public LatLng center { get; set; }
    }
}

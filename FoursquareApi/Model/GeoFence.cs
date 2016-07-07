namespace Foursquare.Model
{
    public sealed class GeoFence : IFoursquareType
    {
        public double lat { get; set; }
        public double lng { get; set; }
        public double radius { get; set; }
        public double smallestDistance { get; set; }
        public bool isNative { get; set; }
    }
}

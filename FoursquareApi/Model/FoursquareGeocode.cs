namespace Foursquare.Model
{
    public sealed class FoursquareGeocode : IFoursquareType
    {
        public FoursquareList<GeocoderLocation> interpretations { get; set; }
    }
}

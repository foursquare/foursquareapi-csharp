using Foursquare.Model;

namespace Foursquare.Response
{
    public sealed class VenueResponse : IFoursquareType
    {
        public Venue venue { get; set; }
    }
}

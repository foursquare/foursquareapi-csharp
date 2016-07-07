using Foursquare.Model;

namespace Foursquare.Response
{
    public sealed class EventsResponse : IFoursquareType
    {
        public FoursquareList<Event> events { get; set; }
    }
}

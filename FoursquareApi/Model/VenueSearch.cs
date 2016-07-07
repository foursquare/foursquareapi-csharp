using System.Collections.Generic;

namespace Foursquare.Model
{
    public class VenueSearch : IFoursquareType
    {
        public List<Venue> venues { get; set; }
        public List<Venue> neighborhoods { get; set; }
        public Venue geoVenue { get; set; }
        public bool confident { get; set; }
    }
}

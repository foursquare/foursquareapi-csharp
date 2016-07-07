using System.Collections.Generic;

namespace Foursquare.Model
{
    public sealed class AddVenue : IFoursquareType
    {
        public string ignoreDuplicatesKey { get; set; }
        public List<Venue> candidateDuplicateVenues { get; set; }
        public Venue venue { get; set; }
    }
}

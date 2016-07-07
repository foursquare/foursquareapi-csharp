using System.Collections.Generic;

namespace Foursquare.Model
{
    public sealed class VenueAttributeSection : IFoursquareType
    {
        public string section { get; set; }
        public string displayType { get; set; }
        public List<VenueAttribute> items { get; set; }
    }
}

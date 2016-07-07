using System.Collections.Generic;

namespace Foursquare.Model
{
    public sealed class VenueAttribute : IFoursquareType
    {
        public string displayName { get; set; }
        public string displayType { get; set; }
        public string summary { get; set; }
        public string detail { get; set; }
        public string sourceDetail { get; set; }
        public List<Entity> entities { get; set; }
    }
}

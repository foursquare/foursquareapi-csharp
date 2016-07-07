using System.Collections.Generic;

namespace Foursquare.Model
{
    public sealed class GeoSuggestions : IFoursquareType
    {
        public List<GeoSuggestion> locations { get; set; }
    }
}

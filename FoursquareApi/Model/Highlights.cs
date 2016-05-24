using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public sealed class Highlights : IFoursquareBase
    {
        public string requestId { get; set; }
        public Venue venue { get; set; }
        public Photo photo { get; set; }
        public List<Venue> alternateVenues { get; set; }
        public List<HighlightsSection> sections { get; set; }
        public GeoFence geoFence { get; set; }
    }
}

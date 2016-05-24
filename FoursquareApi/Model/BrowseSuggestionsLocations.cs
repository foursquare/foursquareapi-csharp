using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Foursquare.Model;

namespace Foursquare.Model
{
    public sealed class BrowseSuggestionsLocations : IFoursquareBase
    {
        public GeocoderLocation currentLocation { get; set; }
        public List<GeocoderLocation> relatedNeighborhoods { get; set; }
        public BrowseSuggestionsGeoBounds geoBounds { get; set; }
        public string distanceCopy { get; set; }
        public string distanceIcon { get; set; }
        public Photo currentLocationPhoto { get; set; }

        public sealed class BrowseSuggestionsGeoBounds : IFoursquareBase
        {
            public GeocoderLocation.Bounds box { get; set; }
            public GeoCircle circle { get; set; }
            public string geoId { get; set; }
        }
    }
}

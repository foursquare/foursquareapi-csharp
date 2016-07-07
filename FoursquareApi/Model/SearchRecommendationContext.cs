using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Foursquare.Model;

namespace Foursquare.Model
{
    public sealed class SearchRecommendationContext : IFoursquareType
    {
        public GeocoderLocation currentLocation { get; set; }
        public List<GeocoderLocation> relatedNeighborhoods { get; set; }
        public int suggestedRadius { get; set; }
        public string currency { get; set; }
    }
}

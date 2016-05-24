using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Foursquare.Model;

namespace Foursquare.Model
{
    public sealed class GeocoderLocation : IFoursquareBase
    {
        public string where { get; set; }
        public string what { get; set; }
        public Feature feature { get; set; }
        public LatLng center { get; set; }

        public string DisplayName
        {
            get
            {
                if (feature != null)
                {
                    return feature.matchedName ?? feature.displayName;
                }
                return where;
            }
        }

        public sealed class Feature : IFoursquareBase
        {
            public string cc { get; set; }
            public string name { get; set; }
            public string displayName { get; set; }
            public string matchedName { get; set; }
            public string highlightedName { get; set; }
            public int woeType { get; set; }
            public string slug { get; set; }
            public string id { get; set; }
            public bool hasCityPage { get; set; }
            public bool allowExplore { get; set; }
            public Geometry geometry { get; set; }
        }

        public sealed class Geometry : IFoursquareBase
        {
            public LatLng center { get; set; }
            public Bounds bounds { get; set; }
        }

        public sealed class Bounds : IFoursquareBase
        {
            public LatLng ne { get; set; }
            public LatLng sw { get; set; }
        }
    }
}

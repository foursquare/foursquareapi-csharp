using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public sealed class GeoSuggestion : IFoursquareType
    {
        public string name { get; set; }
        public string geoId { get; set; }
        public Photo photo { get; set; }
        public string type { get; set; }
        public FoursquareList<FacePile> facePile { get; set; }
        public FoursquareList<Taste> tastes { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public sealed class GeoSuggestions : IFoursquareBase
    {
        public List<GeoSuggestion> locations { get; set; }
    }
}

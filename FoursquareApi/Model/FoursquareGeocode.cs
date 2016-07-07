using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Foursquare.Model;

namespace Foursquare.Model
{
    public sealed class FoursquareGeocode : IFoursquareType
    {
        public FoursquareList<GeocoderLocation> interpretations { get; set; }
    }
}

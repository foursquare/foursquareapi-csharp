using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Foursquare.Model;

namespace Foursquare.Model
{
    public sealed class GeoCircle : IFoursquareType
    {
        public int radius { get; set; }
        public LatLng center { get; set; }
    }
}

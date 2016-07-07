using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class LatLng : IFoursquareType
    {
        public double lat { get; set; }
        public double lng { get; set; }
        public string contextLine { get; set; }
        public string name { get; set; }
    }
}

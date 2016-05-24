using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public sealed class GeoFence : IFoursquareBase
    {
        public double lat { get; set; }
        public double lng { get; set; }
        public double radius { get; set; }
        public double smallestDistance { get; set; }
        public bool isNative { get; set; }
    }
}

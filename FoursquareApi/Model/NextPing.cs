using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public sealed class NextPing : IFoursquareBase
    {
        public long minTime { get; set; }
        public GeoFence geoFence { get; set; }
    }
}

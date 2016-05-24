using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Foursquare.Model;

namespace Foursquare.Model
{
    public sealed class VenueHoursTimeframe : IFoursquareBase
    {
        public string days { get; set; }
        public bool includesToday { get; set; }
        public List<Open> open { get; set; }
        public List<Segment> segments { get; set; }

        public sealed class Open : IFoursquareBase
        {
            public string renderedTime { get; set; }
        }

        public sealed class Segment : IFoursquareBase
        {
            public string label { get; set; }
            public string renderedTime { get; set; }
        }
    }
}

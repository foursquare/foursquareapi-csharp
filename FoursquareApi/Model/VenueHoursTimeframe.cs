using System.Collections.Generic;

namespace Foursquare.Model
{
    public sealed class VenueHoursTimeframe : IFoursquareType
    {
        public string days { get; set; }
        public bool includesToday { get; set; }
        public List<Open> open { get; set; }
        public List<Segment> segments { get; set; }

        public sealed class Open : IFoursquareType
        {
            public string renderedTime { get; set; }
        }

        public sealed class Segment : IFoursquareType
        {
            public string label { get; set; }
            public string renderedTime { get; set; }
        }
    }
}

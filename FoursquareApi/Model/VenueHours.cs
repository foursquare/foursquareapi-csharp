using System.Collections.Generic;

namespace Foursquare.Model
{
    public sealed class VenueHours : IFoursquareType
    {
        public string status { get; set; }
        public bool isOpen { get; set; }
        public List<VenueHoursTimeframe> timeframes { get; set; }
    }
}

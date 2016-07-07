using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Foursquare.Model;

namespace Foursquare.Model
{
    public sealed class VenueHours : IFoursquareType
    {
        public string status { get; set; }
        public bool isOpen { get; set; }
        public List<VenueHoursTimeframe> timeframes { get; set; }
    }
}

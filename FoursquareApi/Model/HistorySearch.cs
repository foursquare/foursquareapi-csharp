using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class HistorySearch : IFoursquareType
    {
        public long earliestTimestamp { get; set; }
        public FoursquareList<Checkin> checkins { get; set; }
    }
}

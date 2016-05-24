using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Foursquare.Model
{
    public class Campaign : IFoursquareBase
    {
        public string id;
        public FoursquareList<Venue> venues;
        public long startsAt;
        public Special special;
        public string status;
    }
}

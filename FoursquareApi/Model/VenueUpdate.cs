using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Foursquare.Model
{
    public class VenueUpdate : IFoursquareBase
    {
        public long createdAt { get; set; }
        public string id { get; set; }
        public string shout { get; set; }
        public FoursquareList<Photo> photos { get; set; }
        public FoursquareList<Venue> venues { get; set; }
    }
}

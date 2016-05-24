using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class VenueStickers : IFoursquareBase
    {
        public string venueId { get; set; }
        public List<string> carousel { get; set; }
    }
}

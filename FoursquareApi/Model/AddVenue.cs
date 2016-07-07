using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Foursquare.Model;

namespace Foursquare.Model
{
    public sealed class AddVenue : IFoursquareType
    {
        public string ignoreDuplicatesKey { get; set; }
        public List<Venue> candidateDuplicateVenues { get; set; }
        public Venue venue { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Foursquare.Model;

namespace Foursquare.Model
{
    public sealed class OpinionatorSummary : IFoursquareBase
    {
        public string title { get; set; }
        public string text { get; set; }
        public string type { get; set; }
        public List<Venue> venues { get; set; }
        public List<Taste> tastes { get; set; }
        public List<FollowUser> users { get; set; }
    }
}

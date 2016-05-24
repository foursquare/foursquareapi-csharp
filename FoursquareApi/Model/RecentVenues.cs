using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class RecentVenues : IFoursquareBase
    {
        public List<RecentVenue> items { get; set; }

        public long next { get; set; }
        public bool hasOpinionatorCards { get; set; }
        public string titleText { get; set; }
        public string helpText { get; set; }
        public string privacyText { get; set; }
        public string opinionatorText { get; set; }
    }
}

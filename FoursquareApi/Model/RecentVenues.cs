using System.Collections.Generic;

namespace Foursquare.Model
{
    public class RecentVenues : IFoursquareType
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

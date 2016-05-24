using Foursquare.Helper;

namespace Foursquare.Model
{
    public sealed class Share : IFoursquareBase
    {
        public string id { get; set; }
        public User user { get; set; }
        public long sharedAt { get; set; }
        public string state { get; set; }
        public string type { get; set; }
        public Tip tip { get; set; }
        public Photo photo { get; set; }
        public string text { get; set; }
        public Venue venue { get; set; }
        public User fromUser { get; set; }

        public bool IsSaved
        {
            get { return !string.IsNullOrEmpty(state) && Constants.SHARE_STATE_SAVED == state; }
        }

        public Venue GetVenue()
        {
            if (venue == null && tip != null)
            {
                return tip.venue;
            }
            return venue;
        }
    }
}

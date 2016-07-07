using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class Venue : AbstractHasIdType, ISaveable
    {
        public override string id { get; set; }
        public string name { get; set; }
        public string canonicalUrl { get; set; }
        public bool hasMenu { get; set; }
        public bool verified { get; set; }
        public string referralId { get; set; }
        public string shortUrl { get; set; }
        public string url { get; set; }
        public double rating { get; set; }
        public int ratingSignals { get; set; }
        public bool venueRatingBlacklisted { get; set; }
        public bool closed { get; set; }
        public List<string> tags { get; set; }
        public Mayor mayor { get; set; }
        public Location location { get; set; }
        public List<Category> categories { get; set; }
        //public List<VenuePhrase> phrases { get; set; }
        public FoursquareGroups<Photo> photos { get; set; }
        // Will contain keys of checkinsCount, usersCount and tipCount
        public Dictionary<string, int> stats { get; set; }
        public FoursquareGroups<Tip> tips { get; set; }
        public FoursquareList<Event> events { get; set; }
        public List<Justification> justifications { get; set; } 
        public Price price { get; set; }
        //public VenueFriendVisits { get; set; }
        public FoursquareGroups<TipList> listed { get; set; }
        public Menu menu { get; set; }
        public VenueHours hours { get; set; }
        public VenueHours popular { get; set; }
        public BeenHere beenHere { get; set; }
        // Will contain key=url
        public Dictionary<string, string> reservations { get; set; }
        public Page page { get; set; }
        public List<VenueAttributeSection> attributes { get; set; }
        public Delivery delivery { get; set; }
        public FoursquareGroups<Checkin> hereNow { get; set; }
        public Contact contact { get; set; }
        public string description { get; set; }
        public string tipHint { get; set; }
        public bool locked { get; set; }
        public FoursquareGroups<Share> saves { get; set; }

        public FoursquareList<Taste> tastes { get; set; }
        // This only comes down in users/id/historycompletions
        public string contextLine { get; set; }
        public Photo bestPhoto { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Venue))
            {
                return false;
            }
            return (obj as Venue).id == id;
        }

        public override int GetHashCode()
        {
            return !string.IsNullOrEmpty(id) ? id.GetHashCode() : base.GetHashCode();
        }

        public Category FirstCategory
        {
            get
            {
                if (categories != null && categories.Count > 0)
                {
                    return categories.First();
                }
                return null;
            }
        }

        public sealed class Mayor : IFoursquareType
        {
            public int count { get; set; }
            public User user { get; set; }
        }

        public sealed class Menu : IFoursquareType
        {
            public string mobileUrl { get; set; }
            public string url { get; set; }
            public string type { get; set; }
            public string label { get; set; }
            public string anchor { get; set; }
        }

        public sealed class Delivery : IFoursquareType
        {
            public string url { get; set; }
            public Dictionary<string, string> provider { get; set; }
        }

        public sealed class Price : IFoursquareType
        {
            public int tier { get; set; }
            public string message { get; set; }
            public string currency { get; set; }
        }

        public sealed class BeenHere : IFoursquareType
        {
            public int count { get; set; }
            public bool marked { get; set; }
            public long lastVisitedAt { get; set; }
        }
    }
}

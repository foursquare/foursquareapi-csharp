using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class Checkin : AbstractHasIdType, IComparable<Checkin>
    {
        public override string id { get; set; }
        public long createdAt { get; set; }
        public int distance { get; set; }
        public bool isMayor { get; set; }
        public string shout { get; set; }
        public List<Entity> entities { get; set; }
        public string factoid { get; set; }
        public Source source { get; set; }
        public string type { get; set; }
        public int timeZoneOffset { get; set; }
        public User user { get; set; }
        public Venue venue { get; set; }
        public FoursquareList<Photo> photos { get; set; }
        public ScoreInfo score { get; set; }
        public FoursquareList<Checkin> overlaps { get; set; }
        public FoursquareList<Fact> facts { get; set; }
        public Shares shares { get; set; }
        public string visibility { get; set; }
        public User createdBy { get; set; }
        public string display { get; set; }
        [JsonProperty("event")]
        public Event checkinEvent { get; set; }
        public DisplayGeo displayGeo { get; set; }
        public LatLng location { get; set; }
        public FoursquareList<AppPost> posts { get; set; }
        public bool hasVenueLeaderboard { get; set; }

        public sealed class ScoreInfo : IFoursquareType
        {
            public int total { get; set; }
            public List<Score> scores { get; set; }
        }

        public sealed class Fact : IFoursquareType
        {
            public string type { get; set; }
            public string message { get; set; }
            public Photo icon { get; set; }
        }

        public sealed class Shares : IFoursquareType
        {
            public bool facebook { get; set; }
            public bool twitter { get; set; }
        }

        public int CompareTo(Checkin other)
        {
            if (other == null)
            {
                return 1;
            }
            return (int)(this.createdAt - other.createdAt);
        }
    }
}

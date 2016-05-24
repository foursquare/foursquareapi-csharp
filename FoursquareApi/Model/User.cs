using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Foursquare.Model
{
    public class User : IFoursquareBase
    {
        public const string PING_TYPE_OFF = "off";
        public const string PING_TYPE_ALWAYS = "always";
        public const string PING_TYPE_NEARBY = "nearby";

        public User() { }
        public virtual string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public string homeCity { get; set; }
        public string created { get; set; }
        public string bio { get; set; }
        public string relationship { get; set; }
        public string followingRelationship { get; set;  }
        public string type { get; set; }
        public string blockedStatus { get; set; }
        public bool pings { get; set; }
        public string checkinPings { get; set; }
        public int superuser { get; set; }
        public int coinBalance { get; set; }
        public Photo photo { get; set; }
        public Contact contact { get; set; }
        public FoursquareList<Badge> badges { get; set; }
        public FoursquareList<Checkin> checkins { get; set; }
        public FoursquareList<Tip> tips { get; set; }
        //public FoursquareGroups<TipList> lists { get; set; }
        public FoursquareList<Photo> photos { get; set; }
        //public UserScores scores { get; set; }
        public PageInfo pageInfo { get; set; }
        public FoursquareGroups<User> following { get; set; }
        public FoursquareGroups<User> friends { get; set; }
        public FoursquareGroups<User> followers { get; set; }
        public PassiveLocation lastPassive { get; set; }
        public bool muted { get; set; }
        public string status { get; set; }
        public FoursquareList<Taste> tastes { get; set; }
        public Image publisherLogo { get; set; }
        public FoursquareList<Share> saves { get; set; }
        public bool isAnonymous { get; set; }

        // Helpers
        public string FullName
        {
            get
            {
                return firstName + " " + lastName ?? "";
            }
        }

        public Checkin LastCheckin
        {
            get
            {
                return (checkins != null && checkins.count > 0 && checkins.items.Count > 0) ? checkins.items.First() : null;
            }
        }

        public bool IsSelf()
        {
            return (!string.IsNullOrEmpty(relationship) && relationship.Equals("self")) || (!string.IsNullOrEmpty(followingRelationship) && followingRelationship.Equals("self"));
        }

        public override bool Equals(object obj)
        {
            if (obj is User)
            {
                return this.id == (obj as User).id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return string.IsNullOrEmpty(id) ? base.GetHashCode() : id.GetHashCode();
        }
    }
}

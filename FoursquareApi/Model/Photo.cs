using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class Photo : IFoursquareType
    {
        public const string VISIBILITY_PUBLIC = "public";
        public const string VISIBILITY_FRIENDS = "friends";
        public const string VISIBILITY_PRIVATE = "private";

        public string id { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        public string prefix { get; set; }
        public string suffix { get; set; }
        public string url { get; set; }
        public long createdAt { get; set; }
        public string visibility { get; set; }
        public string backgroundColor { get; set; }
        public Checkin checkin { get; set; }
        public Venue venue { get; set; }
        public User user { get; set; }
        public Source source { get; set; }

        public bool IsPublic()
        {
            return String.Equals(visibility, VISIBILITY_PUBLIC);
        }

        public bool IsPrivate()
        {
            return String.Equals(visibility, VISIBILITY_PRIVATE);
        }

        public bool IsFriendsOnly()
        {
            return String.Equals(visibility, VISIBILITY_FRIENDS);
        }

        public string OriginalUrl
        {
            get
            {
                return prefix + "original" + suffix;
            }
        }
    }
}

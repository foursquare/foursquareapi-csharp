using System.Collections.Generic;

namespace Foursquare.Model
{
    public class UsersSearch : IFoursquareType
    {
        public List<FollowUser> results { get; set; }
        public Unmatched unmatched { get; set; }

        public sealed class Unmatched : IFoursquareType
        {
            public List<string> email { get; set; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

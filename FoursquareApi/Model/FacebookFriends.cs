using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class FacebookFriends : IFoursquareBase
    {
        public List<FacebookFriend> friends { get; set; }
        public string checksum { get; set; }
    }
}

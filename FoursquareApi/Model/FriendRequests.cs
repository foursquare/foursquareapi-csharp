using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class FriendRequests : IFoursquareBase
    {
        public List<User> requests { get; set; }
    }
}

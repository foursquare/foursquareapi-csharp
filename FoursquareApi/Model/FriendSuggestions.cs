using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class FriendSuggestions : IFoursquareBase
    {
        public List<User> users { get; set; } 
    }
}

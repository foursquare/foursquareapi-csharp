using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class FacebookFriend : User
    {
        public User user { get; set; }
        public override string id 
        { 
            get 
            {
                if (base.id == null || base.id.StartsWith("fb-"))
                {
                    return base.id;
                }
                return "fb-" + base.id; 
            }

            set
            {
                base.id = value;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class UserVisits : IFoursquareBase
    {
        public User user { get; set; }
        public int visits { get; set; }
        public int rank { get; set; }

        public int realRank
        {
            get { return rank + 1; }
        }
    }
}

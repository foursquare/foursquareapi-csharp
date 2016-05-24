using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class Likes : IFoursquareBase
    {
        public bool like { get; set; }
        public FoursquareList<User> likes { get; set; }
    }
}

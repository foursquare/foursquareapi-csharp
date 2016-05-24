using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class Friends : IFoursquareBase
    {
        public FoursquareList<User> friends { get; set; }
        public FoursquareList<User> following { get; set; }
        public string checksum { get; set; }
    }
}

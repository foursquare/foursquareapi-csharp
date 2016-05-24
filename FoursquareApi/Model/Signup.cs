using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Foursquare.Model;

namespace Foursquare.Model
{
    public class Signup : IFoursquareBase
    {
        public string access_token { get; set; }
        public User user { get; set; }
        public Settings settings { get; set; }
    }
}

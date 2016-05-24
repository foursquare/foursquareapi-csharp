using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Foursquare.Model;

namespace Foursquare.Model
{
    public class TopPicksResponse : IFoursquareBase
    {
        public string header { get; set; }
        public List<Footer> footers { get; set; }
        public List<TopPick> results { get; set; }
        public SignupUpsell signupUpsell { get; set; }

        public sealed class Footer : IFoursquareBase 
        {
            public string type { get; set; }
            public string copy { get; set; }
        }
    }
}

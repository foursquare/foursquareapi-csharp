using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Foursquare.Model;

namespace Foursquare.Model
{
    public sealed class CallbackUri : IFoursquareBase
    {
        public string url { get; set; }
        public string method { get; set; }
        public List<Argument> args { get; set; }

        public sealed class Argument : IFoursquareBase
        {
            public string key { get; set; }
            public string value { get; set; }
        }
    }
}

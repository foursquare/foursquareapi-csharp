using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Foursquare.Model;

namespace Foursquare.Model
{
    public sealed class Option : IFoursquareBase
    {
        public string displayName { get; set; }
        public string key { get; set; }
        public string value { get; set; }
        public bool selected { get; set; }
    }
}

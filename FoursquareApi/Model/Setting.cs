using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Foursquare.Model;

namespace Foursquare.Model
{
    public sealed class Setting : IFoursquareBase
    {
        public string id { get; set; }
        public string name { get; set; }
        public bool value { get; set; }
        public string description { get; set; }
    }
}

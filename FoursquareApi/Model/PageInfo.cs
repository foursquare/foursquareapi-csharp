using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class PageInfo : IFoursquareType
    {
        public string description { get; set; }
        public string title { get; set; }
        public string banner { get; set; }
    }
}

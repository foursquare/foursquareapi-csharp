using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class Url : IFoursquareType
    {
        public string url { get; set; }
        public string type { get; set; }
        //map of params
    }
}

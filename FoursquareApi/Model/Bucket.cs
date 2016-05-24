using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class Bucket : IFoursquareBase
    {
        public string name { get; set; }
        public int distance { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class Thumbnail : IFoursquareBase
    {
        public string id { get; set; }
        public Photo photo { get; set; }
        public string type { get; set; }
    }
}

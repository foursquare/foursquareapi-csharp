using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class Entity : IFoursquareBase
    {
        public string url { get; set; }
        public string type { get; set; }
        public string id { get; set; }
        public List<int> indices { get; set; }
        public bool onUser { get; set; }
    }
}

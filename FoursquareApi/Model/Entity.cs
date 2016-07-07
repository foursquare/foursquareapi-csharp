using System.Collections.Generic;

namespace Foursquare.Model
{
    public class Entity : IFoursquareType
    {
        public string url { get; set; }
        public string type { get; set; }
        public string id { get; set; }
        public List<int> indices { get; set; }
        public bool onUser { get; set; }
    }
}

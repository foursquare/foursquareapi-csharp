using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class Navigation : IFoursquareBase
    {
        public List<Entity> entities { get; set; }
        public string id { get; set; }
        public bool ignorable { get; set; }
        public NavigationTarget target { get; set; }
        public string text { get; set; }
        public string type { get; set; }
        public List<Thumbnail> thumbnails { get; set; }
        public string referralId { get; set; }
        public sealed class NavigationTarget : IFoursquareBase
        {
            public string type { get; set; }
            public string url { get; set; }
            [JsonProperty("params")]
            public Params urlParams { get; set; }
        }

        public sealed class Params : IFoursquareBase 
        {
            public string query { get; set; }
            public string novelty { get; set; }
            public string venueId { get; set; }
            public string campaignParams { get; set; }
        }
    }
}

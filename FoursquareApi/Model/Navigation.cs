using Newtonsoft.Json;
using System.Collections.Generic;

namespace Foursquare.Model
{
    public class Navigation : IFoursquareType
    {
        public List<Entity> entities { get; set; }
        public string id { get; set; }
        public bool ignorable { get; set; }
        public NavigationTarget target { get; set; }
        public string text { get; set; }
        public string type { get; set; }
        public List<Thumbnail> thumbnails { get; set; }
        public string referralId { get; set; }
        public sealed class NavigationTarget : IFoursquareType
        {
            public string type { get; set; }
            public string url { get; set; }
            [JsonProperty("params")]
            public Params urlParams { get; set; }
        }

        public sealed class Params : IFoursquareType 
        {
            public string query { get; set; }
            public string novelty { get; set; }
            public string venueId { get; set; }
            public string campaignParams { get; set; }
        }
    }
}

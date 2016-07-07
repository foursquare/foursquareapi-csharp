using System.Collections.Generic;
using Foursquare.Api;
using Newtonsoft.Json;

namespace Foursquare.Model
{
    [JsonConverter(typeof(UnifiedSuggestionConverter))]
    public class UnifiedSuggestion : IFoursquareType
    {
        public string type { get; set; }
        public string id { get; set; }
        public string text { get; set; }
        public List<Entity> entities { get; set; }
        public Suggestion suggestion { get; set; }
        public Venue venue { get; set; }
    }
}

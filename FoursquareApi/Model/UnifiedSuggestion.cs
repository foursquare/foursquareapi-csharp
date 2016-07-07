using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Foursquare.Model;
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

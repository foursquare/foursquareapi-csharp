using Newtonsoft.Json;

namespace Foursquare.Model
{
    public sealed class SpellSuggestion : IFoursquareType
    {
        public QueryTarget target { get; set; }
        public TextEntities message { get; set; }

        public sealed class QueryTarget : IFoursquareType
        {
            public string type { get; set; }
            public string url { get; set; }
            [JsonProperty("params")]
            public QueryTargetParams queryParams { get; set; }
        }

        public sealed class QueryTargetParams : IFoursquareType {

        }
    }
}

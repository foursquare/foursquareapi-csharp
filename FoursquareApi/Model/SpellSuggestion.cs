using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Foursquare.Model;
using Newtonsoft.Json;

namespace Foursquare.Model
{
    public sealed class SpellSuggestion : IFoursquareBase
    {
        public QueryTarget target { get; set; }
        public TextEntities message { get; set; }

        public sealed class QueryTarget : IFoursquareBase
        {
            public string type { get; set; }
            public string url { get; set; }
            [JsonProperty("params")]
            public QueryTargetParams queryParams { get; set; }
        }

        public sealed class QueryTargetParams : IFoursquareBase {

        }
    }
}

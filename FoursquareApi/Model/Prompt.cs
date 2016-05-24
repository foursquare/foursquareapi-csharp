using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Foursquare.Model;
using Newtonsoft.Json;

namespace Foursquare.Model
{
    public sealed class Prompt : IFoursquareBase
    {
        public string type { get; set; }
        public string moduleType { get; set; }
        public string prompt { get; set; }
        public string endpoint { get; set; }
        public string afterText { get; set; }
        public string iconFamily { get; set; }
        public List<Entity> entities { get; set; }
        [JsonProperty("params")]
        public Params promptParams { get; set; }
        public List<Option> options { get; set; }

        public sealed class Params : IFoursquareBase
        {
            public string promptId { get; set; }
            public string creatingView { get; set; }
            public string referralId { get; set; }
            public string venueId { get; set; }
            public string impressionId { get; set; }
            public string geoFeatureName { get; set; }
            public List<string> photoIds { get; set; }
            public string roundId { get; set; }
            public long ts { get; set; }
        }
    }
}

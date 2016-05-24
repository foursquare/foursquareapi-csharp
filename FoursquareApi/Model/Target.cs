using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Foursquare.Api;
using Newtonsoft.Json;

namespace Foursquare.Model
{
    [JsonConverter(typeof(TargetConverter))]
    public sealed class Target : IFoursquareBase
    {
        public string Type { get; set; }
        public IFoursquareBase Object { get; set; }
        public bool commentable { get; set; }
        public bool likeable { get; set; }
        public Photo icon { get; set; }
    }
}

using Foursquare.Api;
using Newtonsoft.Json;

namespace Foursquare.Model
{
    [JsonConverter(typeof(TargetConverter))]
    public sealed class Target : IFoursquareType
    {
        public string Type { get; set; }
        public IFoursquareType Object { get; set; }
        public bool commentable { get; set; }
        public bool likeable { get; set; }
        public Photo icon { get; set; }
    }
}

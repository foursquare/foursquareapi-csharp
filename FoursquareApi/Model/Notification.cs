using Foursquare.Api;
using Newtonsoft.Json;

namespace Foursquare.Model
{
    [JsonConverter(typeof(NotificationConverter))]
    public class Notification : IFoursquareType
    {
        public string type { get; set; }
        public bool alert { get; set; }
    }
}

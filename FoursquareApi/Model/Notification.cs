using Foursquare.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Foursquare.Model
{
    [JsonConverter(typeof(NotificationConverter))]
    public class Notification : IFoursquareType
    {
        public string type { get; set; }
        public bool alert { get; set; }
    }
}

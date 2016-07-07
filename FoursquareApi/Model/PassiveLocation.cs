using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class PassiveLocation : IFoursquareType
    {
        public User user { get; set; }
        public String city { get; set; }
        public TextEntities message { get; set; }
        public long createdAt { get; set; }
        public long lastSeenAt { get; set; }
        public long stoppedAt { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }
        public int distance { get; set; }
        public string contextLine { get; set; }
        public string exactContextLine { get; set; }
        public DisplayGeo displayGeo { get; set; }
        public string trumpedByCheckinId { get; set; }
    }
}

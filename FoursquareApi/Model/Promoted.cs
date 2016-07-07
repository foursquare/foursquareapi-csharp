using System;

namespace Foursquare.Model
{
    public class Promoted : IFoursquareType
    {
        public String id { get; set; }
        public String type { get; set; }
        public String specialId { get; set; }
        public String broadcastId { get; set; }
        public String imageAdId { get; set; }
        public String tipId { get; set; }
    }
}

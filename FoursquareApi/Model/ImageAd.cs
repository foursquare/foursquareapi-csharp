using System;

namespace Foursquare.Model
{
    public class ImageAd : IFoursquareType
    {
        public String id { get; set; }
        public String title { get; set; }
        public String subtitle { get; set; }
        public String url { get; set; }
        public Photo photo { get; set; }
        public Promoted promoted { get; set; }
        public String buttonTextOverride { get; set; }
    }
}

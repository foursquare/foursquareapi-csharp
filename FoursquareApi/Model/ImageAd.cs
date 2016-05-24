using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Foursquare.Model
{
    public class ImageAd : IFoursquareBase
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

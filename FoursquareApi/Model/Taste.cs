using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Foursquare.Model
{
    public class Taste : IFoursquareBase
    {
        public string id { get; set; }
        public string text { get; set; }
        public int venueFrequency { get; set; }
        public int tipFrequency { get; set; }
        public bool onUser { get; set; }
        public bool topical { get; set; }
        public bool upsell { get; set; }
    }
}

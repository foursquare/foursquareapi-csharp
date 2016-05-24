using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Foursquare.Model
{
    public class Insight : IFoursquareBase
    {
        public string type { get; set; }
        public string title { get; set; }
        public string subtitle { get; set; }
        public string summary { get; set; }
        public Photo photo { get; set; }
        public bool shareable { get; set; }
        public string image { get; set; }
        public string tw { get; set; }
        public string fb { get; set; }
        public string other { get; set; }
        public bool isFirstTime { get; set; }

        public int score { get; set; }
        public int ranking { get; set; }
        public int payoutSpots { get; set; }
        public string rankString { get; set; }

        public Special special { get; set;}
        public ImageAd imageAd { get; set; }
        public Sticker sticker { get; set; }
        public string progress { get; set; }
        public Score points { get; set; }
        public List<UserVisits> crownSummary { get; set; }
        public Tip tip { get; set; }
        public User mayor { get; set; }
        public string mayorSummary { get; set; }
        public bool hasSpecial { get; set; }
    }
}

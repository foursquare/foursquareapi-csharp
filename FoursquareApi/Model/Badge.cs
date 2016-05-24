using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class Badge : IFoursquareBase
    {
        public string id { get; set; }
        public string badgeId { get; set; }
        public string badgeText { get; set; }
        public string levelText { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public string hint { get; set; }
        public string unlockMessage { get; set; }
        public int level { get; set; }
        public Image image { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Foursquare.Model;

namespace Foursquare.Model
{
    public sealed class CheckinAchievements : IFoursquareBase
    {
        public Achievements stickerAchievements { get; set; }
        public Achievements venueAchievements { get; set; }

        public sealed class Achievements : IFoursquareBase
        {
            public string headerText { get; set; }
            public string bodyText { get; set; }
            public List<Achievement> items { get; set; }
        }

        public sealed class Achievement : IFoursquareBase 
        {
            public int visits { get; set; }
            public string summary { get; set; }

            // A venue achievement only has the venue key
            public Venue venue { get; set; }

            // A sticker has the rest
            public Sticker sticker { get; set; }
            public bool isMayor { get; set; }
            public string categoryPlural { get; set; }
        }
    }
}

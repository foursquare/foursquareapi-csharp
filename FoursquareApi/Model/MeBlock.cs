using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class MeBlock : IFoursquareBase
    {
        public string actionText { get; set; }
        public Checkin checkin { get; set; }
        public string justificationText { get; set; }
        public string prompt { get; set; }
        public List<Venue> venues { get; set; }
        public string requestId { get; set; }
        // private Group<VenueAttributePrompt> prompts;
        public Venue geoVenue { get; set; }
        public List<VenueStickers> stickers { get; set; }
        public bool confident { get; set; }
    }
}

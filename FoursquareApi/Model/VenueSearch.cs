using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class VenueSearch : IFoursquareBase
    {
        public List<Venue> venues { get; set; }
        public List<Venue> neighborhoods { get; set; }
        public Venue geoVenue { get; set; }
        public bool confident { get; set; }
        public List<VenueStickers> stickers { get; set; }
        // public SpellCorrection spellCorrection { get; set; }
    }
}

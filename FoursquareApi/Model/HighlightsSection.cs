using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class HighlightsSection : IFoursquareBase
    {
        public string referralId { get; set; }
        public string sectionType { get; set; }
        public bool promoted { get; set; }
        public TextEntitiesAndIcon title { get; set; }
        public TextEntitiesAndIcon justification { get; set; }
        public FoursquareList<Taste> tastes { get; set; }
        public Tip tip { get; set; }
        public VenueUpdate update { get; set; }
        public Special special { get; set; }
        public ImageAd imageAd { get; set; }
    }
}

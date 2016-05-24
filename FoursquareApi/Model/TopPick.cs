using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Foursquare.Model;

namespace Foursquare.Model
{
    public class TopPick : IFoursquareBase
    {
        public string type { get; set; }
        public Venue venue { get; set; }
        public Photo photo { get; set; }
        public TipList list { get; set; }
        public List<TopPickJustification> justifications { get; set; }
        public ImageAd imageAd { get; set; }
        public Promoted promoted { get; set; }
        public SignupUpsell signupUpsell { get; set; }

        public sealed class TopPickJustification : TextEntitiesAndIcon
        {
            public FoursquareList<FacePile> users { get; set; }
        }
    }
}

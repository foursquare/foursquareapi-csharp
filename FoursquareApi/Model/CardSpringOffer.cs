using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Foursquare.Model
{
    public class CardSpringOffer : IFoursquareBase
    {
        public string title { get; set; }
        public Photo image { get; set; }
        public string finePrint { get; set; }
        public FoursquareList<Redemption> redemptions { get; set; }
        public bool loaded { get; set; }
        public FoursquareList<CreditCard> cards { get; set; }
        public CampaignLocation locations { get; set; }
        public CardSpringEdu mCardSpringEdu { get; set; }
        public OfferInsight insight { get; set; }
        public string redemptionMode { get; set; }

        public sealed class CampaignLocation : IFoursquareBase
        {
            public User chain { get; set; }
            public Venue venue { get; set; }
        }
        public sealed class OfferInsight : IFoursquareBase
        {
            public string discountText { get; set; }
            public string spendText { get; set; }
            public string nextStep { get; set; }
            public string startButton { get; set; }
            public string finePrint { get; set; }
        }
    }
}

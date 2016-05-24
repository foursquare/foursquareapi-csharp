using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Foursquare.Model
{
    public class Redemption : IFoursquareBase
    {
        public string id { get; set; }
        public Venue venue { get; set; }
        public long redeemedAt { get; set; }
        public String saved { get; set; }
        public CardSpringOffer offer { get; set; }
        public CreditCard card { get; set; }
    }
}

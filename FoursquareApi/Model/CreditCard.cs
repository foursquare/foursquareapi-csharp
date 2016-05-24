using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Foursquare.Model
{
    public class CreditCard : IFoursquareBase
    {
        public string last4 { get; set; }
        public string brand { get; set; }
        public string displayBrand { get; set; }
        public string id { get; set; }
        public CardSpringOffer offer { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Foursquare.Model;

namespace Foursquare.Model
{
    public class PhoneSignupVerificationResponse : IFoursquareBase
    {
        public string signature { get; set; }
        public bool expired { get; set; }
    }
}

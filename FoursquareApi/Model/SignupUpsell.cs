using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Foursquare.Model;

namespace Foursquare.Model
{
    public sealed class SignupUpsell : IFoursquareBase
    {
        public string displayType { get; set; }
        public string text { get; set; }
    }
}

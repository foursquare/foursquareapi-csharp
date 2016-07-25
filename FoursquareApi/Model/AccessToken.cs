using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public sealed class AccessToken : IFoursquareType
    {
        public string access_token { get; set; }
    }
}

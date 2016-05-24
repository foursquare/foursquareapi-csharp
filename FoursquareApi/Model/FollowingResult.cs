using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Foursquare.Model;

namespace Foursquare.Model
{
    public sealed class FollowingResult : IFoursquareBase
    {
        public string trailingMarker { get; set; }
        public bool moreData { get; set; }
        public FoursquareList<FollowUser> following { get; set; }
        public string checksum { get; set; }
    }
}

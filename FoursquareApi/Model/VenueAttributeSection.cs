using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Foursquare.Model;

namespace Foursquare.Model
{
    public sealed class VenueAttributeSection : IFoursquareBase
    {
        public string section { get; set; }
        public string displayType { get; set; }
        public List<VenueAttribute> items { get; set; }
    }
}

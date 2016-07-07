using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Foursquare.Model;

namespace Foursquare.Model
{
    public sealed class VenueAttribute : IFoursquareType
    {
        public string displayName { get; set; }
        public string displayType { get; set; }
        public string summary { get; set; }
        public string detail { get; set; }
        public string sourceDetail { get; set; }
        public List<Entity> entities { get; set; }
    }
}

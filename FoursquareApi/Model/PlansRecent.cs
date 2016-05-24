using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class PlansRecent : IFoursquareBase
    {
        public List<Plan> items { get; set; }
        public string leadingMarker { get; set; }
        public string trailingMarker { get; set; }
        public bool moreData { get; set; }
    }
}

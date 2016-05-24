using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class HistoryCompletion : IFoursquareBase
    {
        public List<DisplayGeo> geographies { get; set; }
        public List<Venue> venues { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Foursquare.Model;

namespace Foursquare.Model
{
    public sealed class BrowseExploreIntent : IFoursquareBase
    {
        public string id { get; set; }
        public string value { get; set; }
    }
}

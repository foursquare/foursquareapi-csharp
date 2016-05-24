using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Foursquare.Model;

namespace Foursquare.Model
{
    public sealed class BrowseExploreFilterSection : IFoursquareBase
    {
        public string groupType { get; set; }
        public List<BrowseExploreRefinement> items { get; set; }
    }
}

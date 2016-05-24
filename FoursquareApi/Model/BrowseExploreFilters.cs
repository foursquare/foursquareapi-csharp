using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Foursquare.Model;

namespace Foursquare.Model
{
    public sealed class BrowseExploreFilters : IFoursquareBase
    {
        public string query { get; set; }
        public OpenAtFilter openAt { get; set; }
        public BrowseExploreIntent intent { get; set; }
        public BrowseExploreIntent subintent { get; set; }
        public List<BrowseExploreRefinement> refinements { get; set; }
    }
}

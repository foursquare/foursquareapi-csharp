using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Foursquare.Model;

namespace Foursquare.Model
{
    public sealed class BrowseExploreAutoCompleteSuggestion : IFoursquareBase
    {
        public string name { get; set; }
        public BrowseExploreFilters filters { get; set; }
    }
}

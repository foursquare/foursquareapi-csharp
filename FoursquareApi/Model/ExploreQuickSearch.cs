using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Foursquare.Model;

namespace Foursquare.Model
{
    public sealed class ExploreQuickSearch : IFoursquareBase
    {
        public string name { get; set; }
        public string icon { get; set; }
        public BrowseExploreFilters filters { get; set; }
        public Image iconImage { get; set; }
    }
}

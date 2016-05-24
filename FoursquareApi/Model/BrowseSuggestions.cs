using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Foursquare.Model;

namespace Foursquare.Model
{
    public sealed class BrowseSuggestions : IFoursquareBase
    {
        public List<BrowseExploreResult> sections { get; set; }
        public BrowseSuggestionsLocations context { get; set; }
        public int mostRelevantSectionIndex { get; set; }
        public List<BrowseExploreAutoCompleteSuggestion> autoCompleteSuggestions { get; set; }
        public FiltersInfo filtersInfo { get; set; }

        public sealed class FiltersInfo : IFoursquareBase
        {
            public string currency { get; set; }
            public List<DisabledFilter> disabledFilterRules { get; set; }
            public List<string> hiddenFilters { get; set; }
        }

        public sealed class DisabledFilter : IFoursquareBase
        {
            public string intent { get; set; }
            public List<string> filters { get; set; }
        }
    }
}

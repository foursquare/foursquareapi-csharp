using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foursquare.Model;

namespace Foursquare.Model
{
    public class BrowseExplore : IFoursquareBase
    {
        public const string SourceHomepage = "hp";
        public const string SourceRefinement = "pr";
        public const string SourceFilter = "f";
        public const string SourceTaste = "t";
        public const string SourceQuery = "q";

        public const int DefaultSnippetCharLimit = 80;

        public BrowseExploreSection group { get; set; }
        public BrowseExploreContext context { get; set; }
        public BrowseExploreMatchedTastes matchedTastes { get; set; }
        public SpellCorrection spellCorrection { get; set; }
        public SuggestedModifications suggestedModifications { get; set; }

    }
}

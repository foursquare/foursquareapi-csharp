using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foursquare.Model;

namespace Foursquare.Model
{
    public class SearchRecommendation : IFoursquareType
    {
        public const string SourceHomepage = "hp";
        public const string SourceRefinement = "pr";
        public const string SourceFilter = "f";
        public const string SourceTaste = "t";
        public const string SourceQuery = "q";

        public const int DefaultSnippetCharLimit = 80;

        public SearchRecommendationSection group { get; set; }
        public SearchRecommendationContext context { get; set; }
        public SearchRecommendationMatchedTastes matchedTastes { get; set; }
        public SpellCorrection spellCorrection { get; set; }
        public SuggestedModifications suggestedModifications { get; set; }

    }
}

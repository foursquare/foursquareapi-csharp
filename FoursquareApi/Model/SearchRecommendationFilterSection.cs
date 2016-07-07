using System.Collections.Generic;

namespace Foursquare.Model
{
    public sealed class SearchRecommendationFilterSection : IFoursquareType
    {
        public string groupType { get; set; }
        public List<SearchRecommendationRefinement> items { get; set; }
    }
}

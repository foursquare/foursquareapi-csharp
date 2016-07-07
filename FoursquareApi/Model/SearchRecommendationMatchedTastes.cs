using System.Collections.Generic;

namespace Foursquare.Model
{
    public sealed class SearchRecommendationMatchedTastes : IFoursquareType
    {
        public string header { get; set; }
        public List<Taste> tastes { get; set; }
    }
}

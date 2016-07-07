namespace Foursquare.Model
{
    public sealed class SuggestedModifications : IFoursquareType
    {
        public SearchRecommendationLocations.SearchRecommendationGeoBounds boundsExpansion { get; set; }
    }
}

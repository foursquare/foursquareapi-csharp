namespace Foursquare.Model
{
    public sealed class Suggestion : IFoursquareType
    {
        public Image icon { get; set; }
        public string querystring { get; set; }
        public string additionalText { get; set; }
        public SearchRecommendationFilters filters { get; set; }
        public TextEntities query { get; set; }
    }
}

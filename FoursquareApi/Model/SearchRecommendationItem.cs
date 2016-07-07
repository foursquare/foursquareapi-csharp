namespace Foursquare.Model
{
    public sealed class SearchRecommendationItem : IFoursquareType
    {
        public Venue venue { get; set; }
        public Photo photo { get; set; }
        public FoursquareList<SnippetDetailWrapper> snippets { get; set; }
        public Promoted promoted { get; set; }

        public sealed class SnippetDetailWrapper : IFoursquareType
        {
            public SnippetDetail detail { get; set; }
        }
    }
}

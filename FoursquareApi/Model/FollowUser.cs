namespace Foursquare.Model
{
    public sealed class FollowUser : IFoursquareType
    {
        public User user { get; set; }
        public string suggestionType { get; set; }
        public TextEntities justification { get; set; }
    }
}

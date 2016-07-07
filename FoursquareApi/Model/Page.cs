namespace Foursquare.Model
{
    public class Page : IFoursquareType
    {
        public User user { get; set; }
        public PageInfo pageInfo { get; set; }
    }
}

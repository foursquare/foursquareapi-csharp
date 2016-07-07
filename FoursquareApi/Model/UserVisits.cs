namespace Foursquare.Model
{
    public class UserVisits : IFoursquareType
    {
        public User user { get; set; }
        public int visits { get; set; }
        public int rank { get; set; }

        public int realRank => rank + 1;
    }
}

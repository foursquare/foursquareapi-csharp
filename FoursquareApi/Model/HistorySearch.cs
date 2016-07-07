namespace Foursquare.Model
{
    public class HistorySearch : IFoursquareType
    {
        public long earliestTimestamp { get; set; }
        public FoursquareList<Checkin> checkins { get; set; }
    }
}

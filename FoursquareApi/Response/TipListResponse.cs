using Foursquare.Model;

namespace Foursquare.Response
{
    public sealed class TipListResponse : IFoursquareType
    {
        public TipList list { get; set; }
    }
}

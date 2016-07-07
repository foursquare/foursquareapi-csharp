using Foursquare.Model;

namespace Foursquare.Response
{
    public sealed class TipListsResponse : IFoursquareType
    {
        public FoursquareList<TipList> lists { get; set; }
    }
}

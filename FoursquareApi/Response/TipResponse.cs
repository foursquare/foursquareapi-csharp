using Foursquare.Model;

namespace Foursquare.Response
{
    public sealed class TipResponse : IFoursquareType
    {
        public Tip tip { get; set; }
    }
}

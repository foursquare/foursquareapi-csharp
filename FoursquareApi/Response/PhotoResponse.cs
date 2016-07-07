using Foursquare.Model;

namespace Foursquare.Response
{
    public sealed class PhotoResponse : IFoursquareType
    {
        public Photo photo { get; set; }
    }
}

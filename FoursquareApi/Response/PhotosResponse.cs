using Foursquare.Model;

namespace Foursquare.Response
{
    public sealed class PhotosResponse : IFoursquareType
    {
        public FoursquareList<Photo> photos { get; set; }
    }
}

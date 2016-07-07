namespace Foursquare.Model
{
    public class Thumbnail : IFoursquareType
    {
        public string id { get; set; }
        public Photo photo { get; set; }
        public string type { get; set; }
    }
}

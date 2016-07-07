namespace Foursquare.Model
{
    public sealed class Source : IFoursquareType
    {
        public string name { get; set; }
        public string url { get; set; }
        public string id { get; set; }
        public string photo { get; set; }
        public string icon { get; set; }
        public string detailUrl { get; set; }
        public string banner { get; set; }
    }
}

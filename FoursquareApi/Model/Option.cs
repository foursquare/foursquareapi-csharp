namespace Foursquare.Model
{
    public sealed class Option : IFoursquareType
    {
        public string displayName { get; set; }
        public string key { get; set; }
        public string value { get; set; }
        public bool selected { get; set; }
    }
}

namespace Foursquare.Model
{
    public sealed class Setting : IFoursquareType
    {
        public string id { get; set; }
        public string name { get; set; }
        public bool value { get; set; }
        public string description { get; set; }
    }
}

namespace Foursquare.Model
{
    public class Contact : IFoursquareType
    {
        public string email { get; set; }
        public string facebook { get; set; }
        public string twitter { get; set; }
        public string phone { get; set; }
        public string formattedPhone { get; set; }
    }
}

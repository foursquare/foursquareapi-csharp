using System.Collections.Generic;

namespace Foursquare.Model
{
    public class Location : IFoursquareType
    {
        public string address { get; set; }
        public string crossStreet { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public double distance { get; set; }
        public string postalCode { get; set; }
        public string cc { get; set; }
        public string neighborhood { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string contextLine { get; set; }
        public string exactContextLine { get; set; }
        public List<string> formattedAddress { get; set; }
    }
}

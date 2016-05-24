using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Foursquare.Model;

namespace Foursquare.Model
{
    public class OffNetworkUser : IFoursquareBase
    {
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string displayPhone { get; set; }
        public List<string> numbers { get; set; }
        public long id { get; set; }
        public string GetAnyPhoneNumber()
        {
            if (!string.IsNullOrEmpty(phone))
            {
                return phone;
            }
            else if (numbers != null && numbers.Count > 0)
            {
                return numbers[0];
            }
            return null;
        }
    }
}

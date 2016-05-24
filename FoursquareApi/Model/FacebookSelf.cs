using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class FacebookSelf : IFoursquareBase
    {
        public static string TYPE_NEW = "new";
        public static string TYPE_EXISTING = "existing";
        public static string TYPE_ERROR = "error";

        public string type { get; set; }
        public string access_token { get; set; }
        public string error { get; set; }
        public User user { get; set; }
        public Settings settings { get; set; }
        public Data data { get; set; }

        public sealed class Data : IFoursquareBase
        {
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string gender { get; set; }
            public string email { get; set; }
            public string photo { get; set; }
            public long birthday { get; set; }
        }
    }
}

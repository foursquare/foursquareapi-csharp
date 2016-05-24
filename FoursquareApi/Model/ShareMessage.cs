using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class ShareMessage : IFoursquareBase
    {
        public string facebook { get; set; }
        public string sms { get; set; }
        public string twitter { get; set; }
        public ShareMessageBody email { get; set; }

        public sealed class ShareMessageBody : IFoursquareBase
        {
            public string subject { get; set; }
            public string body { get; set; }
            public string bodyHtml { get; set; }
        }
    }
}

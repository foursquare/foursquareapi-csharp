using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class AppPost : IFoursquareType
    {
        public string id { get; set; }
        public long createdAt { get; set; }
        public Source source { get; set; }
        public string text { get; set; }
        public string url { get; set; }
        public string contentId { get; set; }
        public string photoId { get; set; }
    }
}

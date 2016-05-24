using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class NotificationTrayItem : IFoursquareBase
    {
        public long createdAt { get; set; }
        public List<Entity> entities { get; set; }
        public Image icon { get; set; }
        public List<string> ids { get; set; }
        public Image image { get; set; }
        public string imageType { get; set; }
        public Target target { get; set; }
        public string text { get; set; }
        public bool unread { get; set; }
    }
}

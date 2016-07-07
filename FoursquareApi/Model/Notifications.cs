using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class Notifications : IFoursquareType
    {
        public string type { get; set; }
        public Item item { get; set; }

        public sealed class Item : IFoursquareType
        {
            public int unreadCount { get; set; }
            public int count { get; set; }
            public string promptText { get; set; }
            public bool overrideMute { get; set; }
        }
    }
}

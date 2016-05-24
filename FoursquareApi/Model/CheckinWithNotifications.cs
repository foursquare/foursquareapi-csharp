using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class CheckinWithNotifications : IFoursquareBase
    {
        public Checkin checkin { get; set; }
        public List<Notification> notifications { get; set; }
        public List<string> notificationsOrder { get; set; }
    }
}

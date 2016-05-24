using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Foursquare.Model;

namespace Foursquare.Model
{
    public sealed class NotificationSummary : IFoursquareBase
    {
        public int newFollowers { get; set; }
        public int tipLikes { get; set; }
        public int tipSaves { get; set; }
        public int shares { get; set; }
    }
}

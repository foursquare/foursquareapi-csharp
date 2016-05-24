using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class InsightNotification : Notification
    {
        public Item item { get; set; }
        public sealed class Item : IFoursquareBase
        {
            public FoursquareList<Insight> insights { get; set; }
        }
    }
}

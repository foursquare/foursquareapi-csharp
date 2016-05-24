using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class RecentVenue : IFoursquareBase
    {
        public Venue venue { get; set; }
        public Checkin checkin { get; set; }
        public PCheckin pcheckin { get; set; }
        public bool HasSelfTip()
        {
            if (venue != null && venue.tips != null)
            {
                foreach (var item in venue.tips.groups)
                {
                    if (item.type == "self") 
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}

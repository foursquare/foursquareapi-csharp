using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class ActivityStream : FoursquareList<ActivityCard>
    {
        public string leadingMarker { get; set; }
        public bool moreData { get; set; }
        public string trailingMarker { get; set; }
        public List<Bucket> buckets { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class ActivityCard : IFoursquareBase
    {
        public Target content { get; set; }
        public long createdAt { get; set; }
        public String referralId { get; set; }
        public TextEntities summary { get; set; }
        public List<Thumbnail> thumbnails { get; set; }
        public String type { get; set; }
        public Expire expire { get; set; }
        public Checkin checkin { get; set; }
        public PassiveLocation passiveLocation { get; set; }
        public PromotedTip promotedTip { get; set; }
        public Bulletin bulletin { get; set; }
        public FacebookAd facebookAd { get; set; }

        public sealed class FacebookAd : IFoursquareBase
        {
            public long fbAdTimeoutMs { get; set; }
        }

        public sealed class Expire : IFoursquareBase
        {
            public long after { get; set; }
        }
    }
}

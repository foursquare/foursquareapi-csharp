using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Foursquare.Model;

namespace Foursquare.Model
{
    public sealed class TipBucket : IFoursquareBase
    {
        public TextEntities summary { get; set; }
        public string bucketType { get; set; }
        public TipBucketMoreRequest more { get; set; }
        public List<TipBucketItem> items { get; set; }
        public SuggestionGroup<FollowUser> followSuggestions { get; set; }

        public sealed class TipBucketItem : IFoursquareBase
        {
            public string referralId { get; set; }
            public Target target { get; set; }
            public Tip Tip
            {
                get
                {
                    if (target.Object is Tip)
                    {
                        return target.Object as Tip;
                    }
                    return null;
                }
            }
        }

        public sealed class TipBucketMoreRequest : IFoursquareBase
        {
            public CallbackUri request { get; set; }
        }

        public class SuggestionGroup<T> : IFoursquareBase where T : IFoursquareBase
        {
            List<T> suggestions { get; set; }
            public string style { get; set; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class Tip : AbstractLikeableBase, ISaveable
    {
        public override string id { get; set; }
        public long createdAt { get; set; }
        public int distance { get; set; }
        public string text { get; set; }
        public List<Entity> entities { get; set; }
        public User user { get; set; }
        public Venue venue { get; set; }
        public Photo photo { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public string status { get; set; }
        public DisplayRange displayRange { get; set; }
        public Justification justification { get; set; }
        public FoursquareGroups<Share> saves { get; set; }
        public int viewCount { get; set; }
        public bool postTipHighlighting { get; set; }
        public bool logView { get; set; }
        public long endAt { get; set; }
        public string endAtSummary { get; set; }
        public string detailWebview { get; set; }
        public string finePrint { get; set; }
        public string title { get; set; }
        public string compactText { get; set; }

        public sealed class Justification : IFoursquareBase
        {
            public string message { get; set; }
            public string justificationType { get; set; }
        }
    }
}

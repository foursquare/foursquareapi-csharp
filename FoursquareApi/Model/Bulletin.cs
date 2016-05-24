using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Foursquare.Model;

namespace Foursquare.Model
{
    public sealed class Bulletin : IFoursquareBase
    {
        public string text { get; set; }
        public List<Entity> entities { get; set; }
        public string id { get; set; }
        public long createdAt { get; set; }
        public string titleText { get; set; }
        public string actionText { get; set; }
        public User user { get; set; }
        public Target target { get; set; }
        public Photo image { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class Comment : IFoursquareBase
    {
        public string id { get; set; }
        public long createdAt { get; set; }
        public User user { get; set; }
        public OffNetworkUser offNetworkUser { get; set; }
        public string text { get; set; }
        public List<Entity> entities { get; set; }
        public bool hi { get; set; }
        public Sticker sticker { get; set; }
        public int sendStatus { get; set; }
        public PassiveLocation location { get; set; }
        public Checkin checkin { get; set; }
        public Photo photo { get; set; }
        public bool isClientMade { get; set; }
        public string type { get; set; }
        public string tempBitmapUri { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Comment))
            {
                return false;
            }
            var c = obj as Comment;
            return id == c.id && isClientMade == c.isClientMade;
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }
    }
}

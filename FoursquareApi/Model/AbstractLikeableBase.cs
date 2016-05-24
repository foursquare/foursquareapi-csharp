using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public abstract class AbstractLikeableBase : IFoursquareBase
    {
        public FoursquareList<Comment> comments { get; set; }
        public FoursquareGroups<User> likes { get; set; }
        public bool like { get; set; }
        public bool dislike { get; set; }
        public bool ok { get; set; }
        public virtual string id { get; set; }

        public bool HasLikesOrComments()
        {
            return (comments != null && comments.count > 0) || (likes != null && likes.count > 0);
        }
    }
}

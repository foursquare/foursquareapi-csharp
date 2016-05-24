using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public sealed class PromotedTip : IFoursquareBase
    {
        public Tip tip { get; set; }
        public Promoted promoted { get; set; }
        public FoursquareList<User> facePile { get; set; }
        public Photo photo { get; set; }
    }
}

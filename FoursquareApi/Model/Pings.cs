using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public sealed class Pings : IFoursquareBase
    {
        public List<PushMessage> items { get; set; }
        public List<Target> targets { get; set; }
    }
}

using Foursquare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Response
{
    public sealed class TipListResponse : IFoursquareType
    {
        public TipList list { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Foursquare.Model;

namespace Foursquare.Model
{
    public sealed class Opinions : IFoursquareBase
    {
        public string roundId { get; set; }
        public bool hasMoreCards { get; set; }
        public List<Opinion> cards { get; set; }
        public bool showPagination { get; set; }
    }
}

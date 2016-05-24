using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public sealed class MayorshipResponse : IFoursquareBase
    {
        public List<Mayorship> mayorships { get; set; }
        public List<Mayorship> contendingMayorships { get; set; }
        public int gamePeriod { get; set; }
    }
}

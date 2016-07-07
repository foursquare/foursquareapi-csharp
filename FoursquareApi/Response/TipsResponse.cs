using Foursquare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Response
{
    public sealed class TipsResponse : IFoursquareType
    {
        public FoursquareList<Tip> tips { get; set; }
        public List<VenueTasteJustification> justifications { get; set; }
    }
}

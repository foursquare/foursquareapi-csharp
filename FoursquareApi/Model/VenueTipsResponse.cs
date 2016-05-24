using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Foursquare.Model;

namespace Foursquare.Model
{
    public sealed class VenueTipsResponse : IFoursquareBase
    {
        public FoursquareList<Tip> tips { get; set; }
        public List<VenueTasteJustification> justifications { get; set; }
    }
}

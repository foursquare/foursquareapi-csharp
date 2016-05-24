using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Foursquare.Model;

namespace Foursquare.Model
{
    public sealed class TastesSuggestions : IFoursquareBase
    {
        public long seed { get; set; }
        public int depth { get; set; }
        public List<Taste> tastes { get; set; }
    }
}

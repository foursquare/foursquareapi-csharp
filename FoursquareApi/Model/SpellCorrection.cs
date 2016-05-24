using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foursquare.Model;

namespace Foursquare.Model
{
    public class SpellCorrection : IFoursquareBase
    {
        public SpellSuggestion suggestion { get; set; }
        public SpellSuggestion correction { get; set; }
        public SpellSuggestion escapeHatch { get; set; }
    }
}

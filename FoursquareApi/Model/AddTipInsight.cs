using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Foursquare.Model;

namespace Foursquare.Model
{
    public sealed class AddTipInsight : IFoursquareBase
    {
        public ExpertiseDelta expertise { get; set; }
        public Image image { get; set; }
        public string insightType { get; set; }
        public int interestingness { get; set; }
        public TextEntities summary { get; set; }
    }
}

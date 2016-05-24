using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Foursquare.Model;

namespace Foursquare.Model
{
    public sealed class AddTip : IFoursquareBase
    {
        public Tip tip { get; set; }
        public string message { get; set; }
        public List<ExpertiseDelta> expertise { get; set; }
        public AddTipInsight insight { get; set; }
    }
}

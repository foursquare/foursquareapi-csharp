using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Foursquare.Model;

namespace Foursquare.Model
{
    public sealed class Opinion : IFoursquareBase
    {
        public bool showTipPromptNext { get; set; }
        public Venue venue { get; set; }
        public Prompt prompt { get; set; }
        public CallbackUri deny { get; set; }
        public CallbackUri skip { get; set; }
        public string roundId { get; set; }
    }
}

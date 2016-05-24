using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Foursquare.Model;

namespace Foursquare.Model
{
    public class PlanDetailsResponse : IFoursquareBase
    {
        public Plan plan { get; set; }
        public string invitationError { get; set; }
    }
}

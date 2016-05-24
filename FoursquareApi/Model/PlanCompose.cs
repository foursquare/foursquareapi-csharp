using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Foursquare.Model;

namespace Foursquare.Model
{
    public sealed class PlanCompose : IFoursquareBase
    {
        public List<User> users { get; set; }
        public TextEntities message { get; set; }
    }
}

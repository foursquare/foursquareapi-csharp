using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Foursquare.Model;

namespace Foursquare.Model
{
    public sealed class ExpertiseDelta : IFoursquareBase
    {
        public ExpertiseChange expertiseChange { get; set; }
        public Expertise expertise { get; set; }
    }
}

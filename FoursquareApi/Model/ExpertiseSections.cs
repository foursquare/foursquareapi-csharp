using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class ExpertiseSections: IFoursquareBase
    {
        public string trailingMarker { get; set; }

        public List<ExpertiseSection> sections { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Foursquare.Model;

namespace Foursquare.Model
{
    public class Justification : IFoursquareBase
    {
        public List<Entity> entities { get; set; }
        public string text { get; set; }
        public FoursquareList<FacePile> users { get; set; }
        public Target target { get; set; }
        public Image icon { get; set; }

    }
}

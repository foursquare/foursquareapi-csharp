using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class TextEntities : IFoursquareType
    {
        public string text { get; set; }
        public List<Entity> entities { get; set; }

        // Fields people threw on
        public bool firstPosition { get; set; }
    }
}

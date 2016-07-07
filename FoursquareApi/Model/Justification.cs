using System.Collections.Generic;

namespace Foursquare.Model
{
    public class Justification : IFoursquareType
    {
        public List<Entity> entities { get; set; }
        public string text { get; set; }
        public FoursquareList<FacePile> users { get; set; }
        public Target target { get; set; }
        public Image icon { get; set; }

    }
}

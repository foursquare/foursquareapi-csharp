using System.Collections.Generic;

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

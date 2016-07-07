using System.Collections.Generic;

namespace Foursquare.Model
{
    public sealed class VenueTasteJustification : IFoursquareType
    {
        public Image icon { get; set; }
        public bool firstPosition { get; set; }
        public string text { get; set; }
        public List<Entity> entities { get; set; } 
    }
}

using System.Collections.Generic;

namespace Foursquare.Model
{
    public sealed class SnippetMenu : IFoursquareType
    {
        public string text { get; set; }
        public string url { get; set; }
        public List<Entity> entities { get; set; }
        public DisplayRange displayRange { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Foursquare.Model;

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

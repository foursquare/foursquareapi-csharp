using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Foursquare.Model;

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

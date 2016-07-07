using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class Score : IFoursquareType
    {
        public string icon { get; set; }
        public string message { get; set; }
        public int points { get; set; }
        public Image image { get; set; }
        public Target target { get; set; }
    }
}

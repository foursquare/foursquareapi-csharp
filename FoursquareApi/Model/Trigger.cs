using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class Triggers : IFoursquareBase
    {
        public int notificationTriggered { get; set; }
        public StopDetect stopDetect { get; set; }
        public NextPing nextPing { get; set; }
    }
}

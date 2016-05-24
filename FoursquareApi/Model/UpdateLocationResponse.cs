using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{

    public sealed class UpdateLocationResponse: IFoursquareBase
    {
        public int sleep { get; set; }
        public string arrivalNotifications { get; set; }
        public bool allowBackgroundLocation { get; set; }
        public bool shutdown { get; set; }
        public bool primaryDevice { get; set; }
        public bool hasGlass { get; set; }
        public Triggers triggers { get; set; }
        public SignalScan signalScan { get; set; }
        public Pings pings { get; set; }
        public Highlights highlights { get; set; }
        public string pilgrimSessionId { get; set; }
        public string requestMarker { get; set; }
    }

    public sealed class SignalScan : IFoursquareBase
    {
        public bool wifi { get; set; }
        public bool iBeacon { get; set; }
    }
}

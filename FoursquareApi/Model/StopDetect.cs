using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public sealed class StopDetect : IFoursquareBase
    {
        public double locLag { get; set; }
        public double speedLag { get; set; }
        public double accelLag { get; set; }
        public double accelCeil { get; set; }
        public double accelW { get; set; }
        public double speedW { get; set; }
        public double fastestInterval { get; set; }
        public double lowThres { get; set; }
        public double highThres { get; set; }
        public long sampleRate { get; set; }
        public int backgroundTimer { get; set; }
        public double posSigma { get; set; }
        public double velSigma { get; set; }
    }
}

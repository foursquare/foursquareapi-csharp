using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class RegisterDeviceResponse : IFoursquareBase
    {
        public string uniqueDevice { get; set; }
        public bool primaryDevice { get; set; }
    }
}

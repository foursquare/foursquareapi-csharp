using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Foursquare.Model;

namespace Foursquare.Model
{
    public sealed class OpenAtFilter : IFoursquareBase
    {
        public bool openNow { get; set; }
        public int localDay { get; set; }
        public string localTime { get; set; }
        public bool IsDefault()
        {
            return !openNow && localDay == -1 && string.IsNullOrEmpty(localTime);
        }
    }
}

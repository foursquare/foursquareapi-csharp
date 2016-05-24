using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public sealed class Mayorship : IFoursquareBase
    {
        public Venue venue { get; set; }
        public User mayor { get; set; }
        public string summary { get; set; }
    }
}

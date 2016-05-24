using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Foursquare.Model
{
    public class TasteWrapper : IFoursquareBase
    {
        public Taste taste { get; set; }
        public bool onUser { get; set; }
    }
}

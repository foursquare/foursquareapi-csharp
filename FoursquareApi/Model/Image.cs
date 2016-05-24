﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class Image : IFoursquareBase
    {
        public string name { get; set; }
        public string prefix { get; set; }
        public string suffix { get; set;  }
        public string highlightColor { get; set; }
        public string fullPath { get; set; }
        public List<int> sizes { get; set; }

        public string GetExtension()
        {
           return suffix ?? name;
        }
    }
}
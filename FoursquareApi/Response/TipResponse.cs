﻿using Foursquare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Response
{
    public sealed class TipResponse : IFoursquareType
    {
        public Tip tip { get; set; }
    }
}
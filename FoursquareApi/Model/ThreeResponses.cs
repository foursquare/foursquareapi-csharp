//-----------------------------------------------------------------------
// <copyright file="TwoResponses.cs" company="Foursquare Labs Inc.">
//     Copyright (c) Kyle Fowler, Foursquare Labs Inc.. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Foursquare.Model
{
    public class ThreeResponses<T1, T2, T3> : TwoResponses<T1, T2> 
        where T1 : IFoursquareBase
        where T2 : IFoursquareBase
        where T3 : IFoursquareBase
    {
        public FoursquareResponse<T3> SubResponse3 { get; set; }
    }
}

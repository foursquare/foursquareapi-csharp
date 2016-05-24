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
    public class FourResponses<T1, T2, T3, T4> : ThreeResponses<T1,T2,T3>
        where T1 : IFoursquareBase
        where T2 : IFoursquareBase
        where T3 : IFoursquareBase
        where T4 : IFoursquareBase
    {
        public FoursquareResponse<T4> SubResponse4 { get; set; }
    }
}

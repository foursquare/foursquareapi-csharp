//-----------------------------------------------------------------------
// <copyright file="FiveResponses.cs" company="Foursquare Labs Inc.">
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
    public class FiveResponses<T1, T2, T3, T4, T5> : FourResponses<T1,T2,T3,T4>
        where T1 : IFoursquareBase
        where T2 : IFoursquareBase
        where T3 : IFoursquareBase
        where T4 : IFoursquareBase
        where T5 : IFoursquareBase
    {
        public FoursquareResponse<T5> SubResponse5 { get; set; }
    }
}

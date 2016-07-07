//-----------------------------------------------------------------------
// <copyright file="TwoResponses.cs" company="Foursquare Labs Inc.">
//     Copyright (c) Kyle Fowler, Foursquare Labs Inc.. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foursquare.Model;

namespace Foursquare.Response
{
    public class FourResponses<T1, T2, T3, T4> : ThreeResponses<T1,T2,T3>
        where T1 : IFoursquareType
        where T2 : IFoursquareType
        where T3 : IFoursquareType
        where T4 : IFoursquareType
    {
        public FoursquareResponse<T4> SubResponse4 { get; set; }
    }
}

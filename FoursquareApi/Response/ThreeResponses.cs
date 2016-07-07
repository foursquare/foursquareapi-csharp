//-----------------------------------------------------------------------
// <copyright file="TwoResponses.cs" company="Foursquare Labs Inc.">
//     Copyright (c) Kyle Fowler, Foursquare Labs Inc.. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foursquare.Model;

namespace Foursquare.Response
{
    public class ThreeResponses<T1, T2, T3> : TwoResponses<T1, T2> 
        where T1 : IFoursquareType
        where T2 : IFoursquareType
        where T3 : IFoursquareType
    {
        public FoursquareResponse<T3> SubResponse3 { get; set; }
    }
}

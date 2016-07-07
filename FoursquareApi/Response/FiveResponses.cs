//-----------------------------------------------------------------------
// <copyright file="FiveResponses.cs" company="Foursquare Labs Inc.">
//     Copyright (c) Kyle Fowler, Foursquare Labs Inc.. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foursquare.Model;

namespace Foursquare.Response
{
    public class FiveResponses<T1, T2, T3, T4, T5> : FourResponses<T1,T2,T3,T4>
        where T1 : IFoursquareType
        where T2 : IFoursquareType
        where T3 : IFoursquareType
        where T4 : IFoursquareType
        where T5 : IFoursquareType
    {
        public FoursquareResponse<T5> SubResponse5 { get; set; }
    }
}

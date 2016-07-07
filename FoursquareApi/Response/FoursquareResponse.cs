//-----------------------------------------------------------------------
// <copyright file="FoursquareResponse.cs" company="Foursquare Labs Inc.">
//     Copyright (c) Kyle Fowler, Foursquare Labs Inc.. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Foursquare.Model;

namespace Foursquare.Response
{
    public class FoursquareResponse<T> where T : IFoursquareType
    {
        public T response { get; set; }
        public Meta meta { get; set; }
        public List<Notifications> notifications { get; set; }
        public Exception Exception { get; set; }
    }

}

//-----------------------------------------------------------------------
// <copyright file="Meta.cs" company="Foursquare Labs Inc.">
//     Copyright (c) Kyle Fowler, Foursquare Labs Inc.. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Foursquare.Model
{
    public class Meta
    {
        public Int32 code { get; set; }
        public string requestId { get; set; }

        public string errorDetail { get; set; }
        public string errorMessage { get; set; }
        public string errorType { get; set; }
    }
}

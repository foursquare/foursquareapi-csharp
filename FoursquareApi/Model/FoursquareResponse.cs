//-----------------------------------------------------------------------
// <copyright file="FoursquareResponse.cs" company="Foursquare Labs Inc.">
//     Copyright (c) Kyle Fowler, Foursquare Labs Inc.. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Foursquare.Model
{
    public class FoursquareResponse<T> where T : IFoursquareBase
    {
        public T response { get; set; }
        public Meta meta { get; set; }
        public List<Notifications> notifications { get; set; }
        public Exception Exception { get; set; }
    }

}

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
using Foursquare.Model;
using System.Collections;

namespace Foursquare.Response
{
    public class TwoResponses<T1, T2> : IFoursquareType, IEnumerable<FoursquareResponse<IFoursquareType>>
        where T1 : IFoursquareType
        where T2 : IFoursquareType
    {
        public Meta meta { get; set; }

        public List<Notifications> notifications { get; set; }

        public FoursquareResponse<T1> SubResponse1 { get; set; }

        public FoursquareResponse<T2> SubResponse2 { get; set; }

        public Exception Exception { get; set; }

        public IEnumerator<FoursquareResponse<IFoursquareType>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}

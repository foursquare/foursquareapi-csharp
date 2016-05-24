using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Foursquare.Model;

namespace Foursquare.Model
{
    public sealed class UpdateLocationWrapper : IFoursquareBase
    {
        public UpdateLocationResponse Response { get; set; }
        public long Timestamp { get; set; }
        public FoursquareLocation LastLocation { get; set; }
    }
}

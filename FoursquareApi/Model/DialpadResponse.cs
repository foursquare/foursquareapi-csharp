using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Foursquare.Model;

namespace Foursquare.Model
{
    public sealed class DialpadResponse : IFoursquareBase
    {
        public List<ExploreQuickSearch> dialpad { get; set; }
    }
}

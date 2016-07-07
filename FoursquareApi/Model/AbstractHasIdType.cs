using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public abstract class AbstractHasIdType : IFoursquareType
    {
        public virtual string id { get; set; }
    }
}

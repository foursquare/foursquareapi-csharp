using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class Page : IFoursquareBase
    {
        public User user { get; set; }
        public PageInfo pageInfo { get; set; }
    }
}

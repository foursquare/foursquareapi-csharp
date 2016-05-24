using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Foursquare.Model;

namespace Foursquare.Model
{
    public class CommentWithVenues : IFoursquareBase
    {
        public Comment comment { get; set; }
        public List<Venue> venues { get; set; }
    }
}

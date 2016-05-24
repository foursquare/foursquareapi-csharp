using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Foursquare.Model;

namespace Foursquare.Model
{
    public sealed class FollowUser : IFoursquareBase
    {
        public User user { get; set; }
        public string suggestionType { get; set; }
        public TextEntities justification { get; set; }
    }
}

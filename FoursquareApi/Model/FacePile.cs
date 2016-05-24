using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Foursquare.Model;

namespace Foursquare.Model
{
    public sealed class FacePile : IFoursquareBase
    {
        public string id { get; set; }
        public string interactionType { get; set; }
        public User user { get; set; }
        public Photo photo { get; set; }

        public Photo GetPhoto()
        {
            return user == null ? photo : user.photo;
        }
    }
}

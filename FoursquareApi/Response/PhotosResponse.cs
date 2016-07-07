using Foursquare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Response
{
    public sealed class PhotosResponse : IFoursquareType
    {
        public FoursquareList<Photo> photos { get; set; }
    }
}

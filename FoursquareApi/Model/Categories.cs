using System.Collections.Generic;

namespace Foursquare.Model
{
    public sealed class Categories : IFoursquareType
    {
        public List<Category> categories { get; set; }
    }
}

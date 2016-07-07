using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Foursquare.Model;

namespace Foursquare.Model
{
    public sealed class SearchRecommendationFilterSection : IFoursquareType
    {
        public string groupType { get; set; }
        public List<SearchRecommendationRefinement> items { get; set; }
    }
}

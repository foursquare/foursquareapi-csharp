using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Foursquare.Model;

namespace Foursquare.Model
{
    public sealed class SearchRecommendationFilters : IFoursquareType
    {
        public string query { get; set; }
        public OpenAtFilter openAt { get; set; }
        public SearchRecommendationIntent intent { get; set; }
        public SearchRecommendationIntent subintent { get; set; }
        public List<SearchRecommendationRefinement> refinements { get; set; }
    }
}

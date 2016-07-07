using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Foursquare.Model;

namespace Foursquare.Model
{
    public sealed class SearchRecommendationRefinement : IFoursquareType
    {
        public const string SavesId = "1";
        public const string PlacesYouveBeenId = "2";
        public const string PlacesYouHaventBeenId = "3";
        public const string LikesId = "5";
        public const string SpecialsId = "7";
        public const string RecentlyOpenedId = "8";
        public const string TrendingId = "16";

        public string id { get; set; }
        public string value { get; set; }
        public bool filtersOnly { get; set; }
        public string source { get; set; }
        public string groupType { get; set; }
        public int refType { get; set; }
        public int score { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is SearchRecommendationRefinement))
            {
                return false;
            }
            var other = (SearchRecommendationRefinement) obj;
            return other.id == id && other.groupType == groupType;
        }

        public override int GetHashCode()
        {
            return id.GetHashCode() + groupType.GetHashCode();
        }
    }
}

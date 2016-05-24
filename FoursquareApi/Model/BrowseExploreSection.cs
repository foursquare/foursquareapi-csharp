using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Foursquare.Model;

namespace Foursquare.Model
{
    public sealed class BrowseExploreSection : IFoursquareBase
    {
        public const string ALL_INTENT_DISPLAY_TYPE = "IntentAll";
        public const string VENUE_DISPLAY_TYPE = "Venue";
        public const string GENERATED_DISPLAY_TYPE = "Generated";
        public const string HEADER_DISPLAY_TYPE = "Header";
        public const string TASTEMEGAPACK_DISPLAY_TYPE = "TasteMegapack";
        public const string FOLLOWEE_DISPLAY_TYPE = "Followee";
        public const string SAVED_DISPLAY_TYPE = "Saved";
        public const string NEW_VENUE_DISPLAY_TYPE = "NewVenue";
        public const string HOT_NOW_DISPLAY_TYPE = "HotNow";
        public const string SUBINTENT_DISPLAY_TYPE = "SubIntent";
        public const string SPECIALS_DISPLAY_TYPE = "Specials";
        public const string LIKED_DISPLAY_TYPE = "Liked";
        public const string ANON_FACEBOOK_DISPLAY_TYPE = "SignupUpsellFBOnly";
        public const string ANON_FACEBOOK_EMAIL_DISPLAY_TYPE = "SignupUpsellFBEmail";

        public BrowseExploreSection()
        {
            this.tappable = true;
        }

        public bool isFavorite { get; set; }
        public bool isPersonalized { get; set; }
        public string displayType { get; set; }
        public Photo photo { get; set; }
        public string totalHitsString { get; set; }
        public string icon { get; set; }
        public bool tappable { get; set; }
        public bool embiggen { get; set; }
        public int totalResults { get; set; }
        public List<User> facePile { get; set; }
        public BrowseExploreFilters activeFilters { get; set; }
        public List<BrowseExploreItem> results { get; set; }
        public TextEntities annotatedGroupTeaser { get; set; }
        public TextEntities annotatedGroupName { get; set; }
        public Promoted promoted { get; set; }
        public List<BrowseExploreSection> subSuggestions { get; set; }
        public BrowseSuggestionsLocations.BrowseSuggestionsGeoBounds geoBounds { get; set; }
    }
}

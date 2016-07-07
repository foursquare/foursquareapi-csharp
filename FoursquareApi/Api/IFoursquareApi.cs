using Foursquare.Helper;
using Foursquare.Model;
using Foursquare.Response;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Foursquare.Api
{
    interface IFoursquareApi
    {
        Task<FoursquareResponse<UserResponse>> UserDetails(string userId);
        Task<FoursquareResponse<PhotosResponse>> UserPhotos(string id = "self", int limit = Constants.DEFAULT_PAGE_SIZE, int offset = 0);
        Task<FoursquareResponse<HistorySearch>> SearchHistory(string id, int offset = 0, int limit = Constants.DEFAULT_PAGE_SIZE, string geoId = null,
            string venueId = null, string categoryId = null, string friendId = null, string stickerId = null, string near = null, string llBounds = null, FoursquareLocation loc = null);
        Task<FoursquareResponse<TipListResponse>> ListDetail(string id, int limit = Constants.DEFAULT_PAGE_SIZE, int offset = 0, FoursquareLocation loc = null, string includeVenues = null, string sort = null);
        Task<FoursquareResponse<TipListsResponse>> GetLists(string userId, string group, FoursquareLocation location = null, int limit = Constants.DEFAULT_PAGE_SIZE, int offset = 0, bool sortNearby = false);
        Task<FoursquareResponse<TipListResponse>> CreateList(string listName);
        Task<FoursquareResponse<Empty>> DeleteList(string listId);
        Task<FoursquareResponse<Share>> AddListItem(string type, string id, string listId);
        Task<FoursquareResponse<TipResponse>> TipDetail(string id, string intent = null, FoursquareLocation loc = null);
        Task<FoursquareResponse<TipsResponse>> UserTips(string id, string sort = null, int limit = Constants.DEFAULT_PAGE_SIZE, int offset = 0, string subjectId = null, FoursquareLocation loc = null);
        Task<FoursquareResponse<VenueResponse>> VenueDetails(string id,
            string promotedTipId = null, string intent = null, FoursquareLocation loc = null,
            string tasteIds = null, string searchTipId = null);
        Task<FoursquareResponse<EventsResponse>> VenueEvents(string id, string intent = null);
        Task<FoursquareResponse<VenueSearch>> SearchVenues(FoursquareLocation loc,
            string query = null,
            int limit = Constants.DEFAULT_PAGE_SIZE,
            string appSource = null,
            bool spellCorrect = false,
            string intent = "checkin",
            string wifi = null);
        Task<FoursquareResponse<AutoComplete>> AutoComplete(string query, string groups = null,
            int limit = Constants.DEFAULT_PAGE_SIZE, FoursquareLocation loc = null, CancellationTokenSource cancel = null,
            bool searched = false, string nearbyVenueIds = null);
        Task<FoursquareResponse<FoursquareGeocode>> GeocodeAutocomplete(string query, FoursquareLocation loc, int limit = 5);
        Task<FoursquareResponse<TipsResponse>> VenueTips(string id,
            string sort = null, string query = null, string tasteId = null,
            string promotedTipId = null, string searchTipId = null,
            int limit = Constants.DEFAULT_PAGE_SIZE, int offset = 0, string group = null, FoursquareLocation loc = null);
        Task<FoursquareResponse<PhotosResponse>> VenuePhotos(string id,
            int limit = Constants.DEFAULT_PAGE_SIZE, int offset = 0, FoursquareLocation loc = null);
        Task<FoursquareResponse<Categories>> Categories(FoursquareLocation loc = null, string countryCode = null);
        Task<FoursquareResponse<AddVenue>> AddVenue(Venue v, string category, FoursquareLocation loc, bool isPrivate = false, string dupeDetectedOverrideKey = null);
        Task<FoursquareResponse<Empty>> DeletePhoto(string id);
        Task<FoursquareResponse<PhotoResponse>> AddPhoto(Stream file, string checkinId = null, string venueId = null, string tipId = null, bool twitter = false, bool facebook = false, bool makePublic = false, FoursquareLocation loc = null);
        Task<FoursquareResponse<SearchRecommendation>> SearchRecommendations(SearchRecommendationFilters filters, RecommendationSort sort = RecommendationSort.BestMatch,
            string near = null, string nearGeoId = null, int snippetCharLimit = Constants.BROWSE_EXPLORE_SNIPPET_LENGTH,
            FoursquareLocation location = null, FoursquareLocation currentLocation = null, FoursquareLocation ne = null, FoursquareLocation sw = null,
            bool ignoreSpellingCorrection = false, int? searchRadius = null, string mode = null, int limit = Constants.DEFAULT_PAGE_SIZE, int offset = 0,
            List<string> excludeVenues = null, List<string> includeVenues = null, string referralId = null, SearchRecommendationLocations.SearchRecommendationGeoBounds bounds = null,
            int initialOffset = 0);
    }
}

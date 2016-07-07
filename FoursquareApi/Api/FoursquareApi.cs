//-----------------------------------------------------------------------
// <copyright file="FoursquareApi.cs" company="Foursquare Labs Inc.">
//     Copyright (c) Kyle Fowler, Foursquare Labs Inc.. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Foursquare.Helper;
using Foursquare.Model;
using Foursquare.Response;

namespace Foursquare.Api
{
    /// <summary>
    /// The wrapper class for all of the api calls and request building
    /// </summary>
    public sealed class FoursquareApi : IFoursquareApi
    {
        private const string ApiBase = "https://api.foursquare.com/v2/";

        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _version;

        internal static string UserLanguage { get; private set; }

        public string Token { get; set; }

        public FoursquareApi(string clientId, string clientSecret, string locale = "en", string version = "20160516") 
        {
            _clientId = clientId;
            _clientSecret = clientSecret;
            _version = version;

            UserLanguage = locale;
        }

        public bool IsLoggedIn()
        {
            return !string.IsNullOrEmpty(Token);
        }

        #region Users
        public Task<FoursquareResponse<UserResponse>> UserDetails(string userId)
        {
            var req = new FoursquareRequest(ApiBase + $"users/{userId}");
            AddCommonParams(ref req);
            return req.MakeRequest<UserResponse>();
        }

        public Task<FoursquareResponse<HistorySearch>> SearchHistory(string id, int offset = 0, int limit = Constants.DEFAULT_PAGE_SIZE, string geoId = null,
            string venueId = null, string categoryId = null, string friendId = null, string stickerId = null, string near = null, string llBounds = null, FoursquareLocation loc = null) 
        {
            var req = new FoursquareRequest(ApiBase + $"users/{id}/historysearch");
            req.AddParam("offset", offset.ToString());
            req.AddParam("limit", limit.ToString());
            req.AddParam("venueIds", venueId);
            req.AddParam("geoId", geoId);
            req.AddParam("stickerId", stickerId);
            req.AddParam("near", near);
            req.AddParam("categoryId", categoryId);
            req.AddParam("friendId", friendId);
            req.AddParam("llBounds", llBounds);
            AddCommonParams(ref req);
            AddLocationParams(ref req, loc);
            return req.MakeRequest<HistorySearch>();
        }

        public Task<FoursquareResponse<PhotosResponse>> UserPhotos(string id = "self", int limit = Constants.DEFAULT_PAGE_SIZE, int offset = 0)
        {
            var req = new FoursquareRequest(ApiBase + $"users/{id}/photos");
            req.AddParam("limit", limit.ToString());
            req.AddParam("offset", offset.ToString());
            AddCommonParams(ref req);
            return req.MakeRequest<PhotosResponse>();
        }
        #endregion

        #region BrowseExplore
        public Task<FoursquareResponse<SearchRecommendation>> SearchRecommendations(SearchRecommendationFilters filters, RecommendationSort sort = RecommendationSort.BestMatch, 
            string near = null, string nearGeoId = null, int snippetCharLimit = Constants.BROWSE_EXPLORE_SNIPPET_LENGTH,
            FoursquareLocation location = null, FoursquareLocation currentLocation = null, FoursquareLocation ne = null, FoursquareLocation sw = null,
            bool ignoreSpellingCorrection = false, int? searchRadius = null, string mode = null, int limit = Constants.DEFAULT_PAGE_SIZE, int offset = 0,
            List<string> excludeVenues = null, List<string> includeVenues = null, string referralId = null, SearchRecommendationLocations.SearchRecommendationGeoBounds bounds = null,
            int initialOffset = 0)
        {
            var req = new FoursquareRequest(ApiBase + "search/recommendations");
            if (searchRadius.HasValue)
            {
                req.AddParam("radius", searchRadius.GetValueOrDefault(0).ToString());
            }
            req.AddParam("snippetCharacterLimit", snippetCharLimit.ToString());
            switch (sort)
            {
                case RecommendationSort.Distance:
                    req.AddParam("sortByDistance", "1");
                    break;
                case RecommendationSort.Rating:
                    req.AddParam("sortByVenueRating", "1");
                    break;
            }

            if (!string.IsNullOrEmpty(mode))
            {
                req.AddParam("mode", mode);
            }
            if (excludeVenues != null && excludeVenues.Count > 0)
            {
                req.AddParam("excludeVenues", string.Join(",", excludeVenues));
            }
            if (includeVenues != null && includeVenues.Count > 0)
            {
                req.AddParam("includeVenues", string.Join(",", includeVenues));
            }
            if (ignoreSpellingCorrection)
            {
                req.AddParam("noCorrect", "1");
            }
            if (initialOffset > 0)
            {
                req.AddParam("initialOffset", initialOffset.ToString(CultureInfo.InvariantCulture));
            }

            req.AddParam("limit", limit.ToString());
            req.AddParam("offset", offset.ToString());
            req.AddParam("referralId", referralId);

            req.AddBrowseExploreParams(filters, currentLocation, location, ne, sw, near, nearGeoId);

            if (bounds != null)
            {
                if (bounds.box != null)
                {
                    req.AddParam("fromGeoBounds", "true");
                    req.AddParam("ne", ApiUtils.LatLngFromLocation(new FoursquareLocation { Lat = bounds.box.ne.lat, Lng = bounds.box.ne.lng }));
                    req.AddParam("sw", ApiUtils.LatLngFromLocation(new FoursquareLocation { Lat = bounds.box.sw.lat, Lng = bounds.box.sw.lng }));
                }
                else if (bounds.circle != null)
                {
                    req.AddParam("fromGeoBounds", "true");
                    req.AddParam("radius", bounds.circle.radius.ToString(CultureInfo.InvariantCulture));
                }
                else if (!string.IsNullOrEmpty(bounds.geoId))
                {
                    req.AddParam("fromGeoBounds", "true");
                }
            }

            AddCommonParams(ref req);
            return req.MakeRequest<SearchRecommendation>();
        }
        #endregion

        #region Photos
        public Task<FoursquareResponse<Empty>> DeletePhoto(string id)
        {
            var req = new FoursquareRequest(ApiBase + $"photos/{id}/delete", FoursquareRequest.HttpMethod.POST);
            AddCommonParams(ref req);
            return req.MakeRequest<Empty>();
        }

        public Task<FoursquareResponse<PhotoResponse>> AddPhoto(Stream file, string checkinId = null, string venueId = null, string tipId = null, bool twitter = false, bool facebook = false, bool makePublic = false, FoursquareLocation loc = null)
        {
            var req = new FoursquareRequest(ApiBase + "photos/add", FoursquareRequest.HttpMethod.PHOTO_POST)
            {
                File = file
            };
            var broadcast = string.Empty;
            if (twitter)
            {
                broadcast += "twitter";
            }
            if (facebook)
            {
                if (!string.IsNullOrEmpty(broadcast))
                {
                    broadcast += ",";
                }
                broadcast += "facebook";
            }
            if (!string.IsNullOrEmpty(checkinId))
            {
                req.AddParam("checkinId", checkinId);
                req.AddParam("broadcast", broadcast);
                req.AddParam("public", makePublic.ToString().ToLower());
            }
            else if(!string.IsNullOrEmpty(venueId)) 
            {
                req.AddParam("venueId", venueId);
            }
            else if (!string.IsNullOrEmpty(tipId))
            {
                req.AddParam("tipId", tipId);
            }
            AddLocationParams(ref req, loc);
            AddCommonParams(ref req);
            return req.MakeRequest<PhotoResponse>();
        }
        #endregion

        #region Venues
        public Task<FoursquareResponse<VenueResponse>> VenueDetails(string id, 
            string promotedTipId = null, string intent = null, FoursquareLocation loc = null,
            string tasteIds = null, string searchTipId = null)
        {
            var req = new FoursquareRequest(ApiBase + $"venues/{id}");
            req.AddParam("intent", intent);
            req.AddParam("tasteIds", tasteIds);
            req.AddParam("searchTipId", searchTipId);
            req.AddParam("promotedTipId", promotedTipId);
            AddLocationParams(ref req, loc);
            AddCommonParams(ref req);
            return req.MakeRequest<VenueResponse>();
        }

        public Task<FoursquareResponse<EventsResponse>> VenueEvents(string id, string intent = null)
        {
            var req = new FoursquareRequest(ApiBase + $"venues/{id}/events");
            req.AddParam("intent", intent);
            AddCommonParams(ref req);
            return req.MakeRequest<EventsResponse>();
        }

        public Task<FoursquareResponse<VenueSearch>> SearchVenues(FoursquareLocation loc, 
            string query = null, 
            int limit = Constants.DEFAULT_PAGE_SIZE, 
            string appSource = null, 
            bool spellCorrect = false, 
            string intent = "checkin", 
            string wifi = null)
        {
            var req = new FoursquareRequest(ApiBase + "venues/search");
            req.AddParam("query", query);
            req.AddParam("limit", limit.ToString());
            req.AddParam("appSource", appSource);
            req.AddParam("noCorrect", spellCorrect.ToString().ToLower());
            req.AddParam("intent", intent);
            req.AddParam("wifiScan", wifi);
            AddLocationParams(ref req, loc);
            AddCommonParams(ref req);
            return req.MakeRequest<VenueSearch>();
        }

        public Task<FoursquareResponse<AutoComplete>> AutoComplete(string query, string groups = null, 
            int limit = Constants.DEFAULT_PAGE_SIZE, FoursquareLocation loc = null, CancellationTokenSource cancel = null, 
            bool searched = false, string nearbyVenueIds = null)
        {
            var req = new FoursquareRequest(ApiBase + "search/autocomplete");
            req.AddParam("limit", limit.ToString());
            req.AddParam("group", groups);
            req.AddParam("query", query);
            req.AddParam("nearbyVenueIds", nearbyVenueIds);
            if (searched)
            {
                req.AddParam("searched", "true");
            }
            if (loc == null)
            {
                req.AddParam("intent", "global");
            }
            AddCommonParams(ref req);
            AddLocationParams(ref req, loc);
            return req.MakeRequest<AutoComplete>(cancel?.Token ?? new CancellationTokenSource().Token);
        }
        
        public Task<FoursquareResponse<FoursquareGeocode>> GeocodeAutocomplete(string query, FoursquareLocation loc, int limit = 5)
        {
            var req = new FoursquareRequest(ApiBase + "geo/geocode");
            req.AddParam("maxInterpretations", limit.ToString(CultureInfo.InvariantCulture));
            req.AddParam("autocomplete", "true");
            req.AddParam("query", query);
            AddCommonParams(ref req);
            AddLocationParams(ref req, loc);
            return req.MakeRequest<FoursquareGeocode>();
        }

        public Task<FoursquareResponse<TipsResponse>> VenueTips(string id, 
            string sort = null, string query = null, string tasteId = null, 
            string promotedTipId = null, string searchTipId = null, 
            int limit = Constants.DEFAULT_PAGE_SIZE, int offset = 0, string group = null, FoursquareLocation loc = null)
        {
            var req = new FoursquareRequest(ApiBase + $"venues/{id}/tips");
            req.AddParam("sort", sort);
            req.AddParam("limit", limit.ToString());
            req.AddParam("offset", offset.ToString());
            req.AddParam("query", query);
            req.AddParam("tasteId", tasteId);
            req.AddParam("group", group);
            req.AddParam("promotedTipId", promotedTipId);
            req.AddParam("searchTipId", searchTipId);
            AddLocationParams(ref req, loc);
            AddCommonParams(ref req);
            return req.MakeRequest<TipsResponse>();
        }

        public Task<FoursquareResponse<PhotosResponse>> VenuePhotos(string id,
            int limit = Constants.DEFAULT_PAGE_SIZE, int offset = 0, FoursquareLocation loc = null)
        {
            var req = new FoursquareRequest(ApiBase + $"venues/{id}/photos");
            req.AddParam("limit", limit.ToString());
            req.AddParam("offset", offset.ToString());
            AddLocationParams(ref req, loc);
            AddCommonParams(ref req);
            return req.MakeRequest<PhotosResponse>();
        }

        public Task<FoursquareResponse<Categories>> Categories(FoursquareLocation loc = null, string countryCode = null)
        {
            var req = new FoursquareRequest(ApiBase + "venues/categories");
            req.AddParam("cc", countryCode);
            AddLocationParams(ref req, loc);
            AddCommonParams(ref req);
            return req.MakeRequest<Categories>();
        }

        public Task<FoursquareResponse<AddVenue>> AddVenue(Venue v, string category, FoursquareLocation loc, bool isPrivate = false, string dupeDetectedOverrideKey = null)
        {
            var req = new FoursquareRequest(ApiBase + "venues/add", FoursquareRequest.HttpMethod.POST);
            req.AddParam("name", v.name);
            req.AddParam("primaryCategoryId", category);
            req.AddParam("ignoreDuplicatesKey", dupeDetectedOverrideKey);
            req.AddParam("ignoreDuplicates", !string.IsNullOrEmpty(dupeDetectedOverrideKey) ? "true" : "false");
            req.AddParam("private", isPrivate.ToString().ToLower());

            if (v.location != null)
            {
                req.AddParam("address", v.location.address);
                req.AddParam("crossStreet", v.location.crossStreet);
                req.AddParam("city", v.location.city);
                req.AddParam("state", v.location.state);
                req.AddParam("zip", v.location.postalCode);
            }

            if (v.contact != null)
            {
                req.AddParam("phone", v.contact.phone);
                req.AddParam("twitter", v.contact.twitter);
            }
            req.AddParam("url", v.url);
            AddLocationParams(ref req, loc);
            AddCommonParams(ref req);
            return req.MakeRequest<AddVenue>();
        }
        #endregion

        #region Tips
        public Task<FoursquareResponse<TipResponse>> TipDetail(string id, string intent = null, FoursquareLocation loc = null)
        {
            var req = new FoursquareRequest(ApiBase + "tips/" + id);
            req.AddParam("intent", intent);
            AddLocationParams(ref req, loc);
            AddCommonParams(ref req);
            return req.MakeRequest<TipResponse>();
        }

        public Task<FoursquareResponse<TipsResponse>> UserTips(string id, string sort = null, int limit = Constants.DEFAULT_PAGE_SIZE, int offset = 0, string subjectId = null, FoursquareLocation loc = null)
        {
            var req = new FoursquareRequest(ApiBase + $"users/{id}/tips");
            req.AddParam("sort", sort);
            req.AddParam("limit", limit.ToString());
            req.AddParam("offset", offset.ToString());
            req.AddParam("subjectId", subjectId);
            AddLocationParams(ref req, loc);
            AddCommonParams(ref req);
            return req.MakeRequest<TipsResponse>();
        }
        #endregion

        #region Lists and Saves
        public Task<FoursquareResponse<TipListResponse>> ListDetail(string id, int limit = Constants.DEFAULT_PAGE_SIZE, int offset = 0, FoursquareLocation loc = null, string includeVenues = null, string sort = null)
        {
            var req = new FoursquareRequest(ApiBase + $"lists/{id}");
            req.AddParam("limit", limit.ToString());
            req.AddParam("offset", offset.ToString());
            req.AddParam("sort", sort);
            req.AddParam("includeVenues", includeVenues);
            AddCommonParams(ref req);
            AddLocationParams(ref req, loc);
            return req.MakeRequest<TipListResponse>();
        }

        public Task<FoursquareResponse<TipListsResponse>> GetLists(string userId, string group, FoursquareLocation location = null, int limit = Constants.DEFAULT_PAGE_SIZE, int offset = 0, bool sortNearby = false)
        {
            var req = new FoursquareRequest(ApiBase + $"users/{(string.IsNullOrEmpty(userId) ? "self" : userId)}/lists");
            req.AddParam("limit", limit.ToString());
            req.AddParam("group", group);
            req.AddParam("offset", offset.ToString());
            req.AddParam("sort", sortNearby ? "nearby" : "");

            AddCommonParams(ref req);
            AddLocationParams(ref req, location);
            return req.MakeRequest<TipListsResponse>();
        }

        public Task<FoursquareResponse<TipListResponse>> CreateList(string listName)
        {
            var req = new FoursquareRequest(ApiBase + "lists/add", FoursquareRequest.HttpMethod.POST);
            req.AddParam("name", listName);
            AddCommonParams(ref req);

            return req.MakeRequest<TipListResponse>();
        }
        public Task<FoursquareResponse<Empty>> DeleteList(string listId)
        {
            var req = new FoursquareRequest(ApiBase + $"lists/{listId}/delete", FoursquareRequest.HttpMethod.POST);

            AddCommonParams(ref req);

            return req.MakeRequest<Empty>();
        }


        public Task<FoursquareResponse<Share>> AddListItem(string type, string id, string listId)
        {
            var endPoint = "lists/{0}/additem";
            var idKey = "";

            switch (type)
            {
                case Constants.TYPE_TIP:
                    idKey = "tipId";
                    break;
                case Constants.TYPE_VENUE:
                    idKey = "venueId";
                    break;
                case Constants.TYPE_SHARE:
                    idKey = "itemId";
                    break;
            }

            var req = new FoursquareRequest(string.Format(ApiBase + string.Format(endPoint, listId)), FoursquareRequest.HttpMethod.POST);
            req.AddParam(idKey, id);

            AddCommonParams(ref req);

            return req.MakeRequest<Share>();
        }
        #endregion

        private void AddCommonParams(ref FoursquareRequest refRequest)
        {
            if (IsLoggedIn())
            {
                refRequest.AddParam("oauth_token", Token);
            }
            else
            {
                refRequest.AddParam("client_id", _clientId);
                refRequest.AddParam("client_secret", _clientSecret);
            }

            if (!refRequest.HasParam("v"))
            {
                refRequest.AddParam("v", _version);
            }

        }

        private static void AddLocationParams(ref FoursquareRequest refRequest, FoursquareLocation location)
        {
            if (location != null)
            {
                refRequest.AddParam("ll", location.Lat.ToString(CultureInfo.InvariantCulture) + "," + location.Lng.ToString(CultureInfo.InvariantCulture));
                refRequest.AddParam("llAcc", location.Accuracy.ToString(CultureInfo.InvariantCulture));
            }
        }
    }
}

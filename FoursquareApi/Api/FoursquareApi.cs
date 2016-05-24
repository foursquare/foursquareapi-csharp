//-----------------------------------------------------------------------
// <copyright file="FoursquareApi.cs" company="Foursquare Labs Inc.">
//     Copyright (c) Kyle Fowler, Foursquare Labs Inc.. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Foursquare.Model;
using System.IO;
using System.Threading;
using System.Globalization;
using Foursquare.Helper;

namespace Foursquare.Api
{
    /// <summary>
    /// The wrapper class for all of the api calls and request building
    /// </summary>
    public sealed class FoursquareApi
    {
        public const int DEFAULT_COUNT = 200;
        public const int DEFAULT_PAGE_SIZE = 30;

        private const string _apiBase = "https://api.foursquare.com/v2/";
        private static string _appLocale;

        private string clientId;
        private string clientSecret;
        private string version;

        internal static string UserLanguage { get { return _appLocale; } }

        public string Token { get; set; }

        public FoursquareApi(string clientId, string clientSecret, string locale = "en", string version = "20160516") 
        {
            this.clientId = clientId;
            this.clientSecret = clientSecret;
            this.version = version;

            _appLocale = locale;
        }

        public bool IsLoggedIn()
        {
            return !string.IsNullOrEmpty(Token);
        }

        #region Users
        public Task<FoursquareResponse<User>> LookupUser(string email, string phone)
        {
            var req = new FoursquareRequest(_apiBase + "users/lookup");
            req.AddParam("email", email);
            req.AddParam("phone", phone);
            AddCommonParams(ref req);
            return req.MakeRequest<User>();
        }

        public Task<FoursquareResponse<Signup>> AddUser(string firstName, string lastName, string email, string phone, string password,
            string gender, int birthDate, int birthMonth, int birthYear, string foreignConsent = null, string fbToken = null, string signupSource = null, FoursquareLocation loc = null,
            string tastes = null, string instagramToken = null, string twitterToken = null, string twitterSecret = null) 
        {
            var req = new FoursquareRequest(_apiBase + "users/add", FoursquareRequest.HttpMethod.POST);
            req.AddParam("firstName", firstName);
            req.AddParam("lastName", lastName);
            req.AddParam("email", email);
            req.AddParam("phone", phone);
            req.AddParam("password", password);
            req.AddParam("gender", gender);
            req.AddParam("birthDate", birthDate.ToString());
            req.AddParam("birthMonth", birthMonth.ToString());
            req.AddParam("birthYear", birthYear.ToString());
            req.AddParam("foreignConsent", foreignConsent);
            req.AddParam("fbToken", fbToken);
            req.AddParam("signupSource", signupSource);
            req.AddParam("tastes", tastes);
            req.AddParam("instagramToken", instagramToken);
            req.AddParam("twitterToken", twitterToken);
            req.AddParam("twitterSecret", twitterSecret);
            AddCommonParams(ref req);
            AddLocationParams(ref req, loc);
            return req.MakeRequest<Signup>();
        }

        public Task<FoursquareResponse<User>> UserDetails(string userId)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "users/{0}", userId));
            AddCommonParams(ref req);
            return req.MakeRequest<User>();
        }

        public Task<TwoResponses<User, Settings>> GetUserAndSettings(string uniqueDevice = null)
        {
            var req = new FoursquareRequest(_apiBase + "multi");
            var userRequest = new FoursquareRequest("/users/self");
            var settingsRequest = new FoursquareRequest("/settings/all");
            settingsRequest.AddParam("uniqueDevice", uniqueDevice);

            req.AddSubRequest(userRequest);
            req.AddSubRequest(settingsRequest);

            AddCommonParams(ref req);
            return req.MakeRequest<User, Settings>();
        }

        public Task<FoursquareResponse<User>> UpdateFacebookLink(string token, IEnumerable<string> permissions, bool shareToTimeline)
        {
            var req = new FoursquareRequest(_apiBase + "users/self/update", FoursquareRequest.HttpMethod.POST);
            req.AddParam("fbToken", token);
            req.AddParam("fbPermissions", permissions != null ? string.Join<string>(",", permissions) : null);
            req.AddParam("enableFbTimelineSharing", shareToTimeline.ToString().ToLower());
            AddCommonParams(ref req);
            return req.MakeRequest<User>();
        }

        public Task<FoursquareResponse<User>> UpdateTwitterLink(string token, string secret)
        {
            var req = new FoursquareRequest(_apiBase + "users/self/update", FoursquareRequest.HttpMethod.POST);
            req.AddParam("twitterToken", token);
            req.AddParam("twitterSecret", secret);
            AddCommonParams(ref req);
            return req.MakeRequest<User>();
        }

        public Task<FoursquareResponse<InstagramAccessToken>> UpdateInstagramLink(string token)
        {
            var req = new FoursquareRequest(_apiBase + "users/linkinstagram", FoursquareRequest.HttpMethod.POST);
            req.AddParam("instagramToken", token);
            AddCommonParams(ref req);
            return req.MakeRequest<InstagramAccessToken>();
        }

        public Task<FoursquareResponse<User>> UpdateUserProfilePhoto(Stream file)
        {
            var req = new FoursquareRequest(_apiBase + "users/self/update", FoursquareRequest.HttpMethod.PHOTO_POST);
            req.File = file;
            AddCommonParams(ref req);
            return req.MakeRequest<User>();
        }

        public Task<FoursquareResponse<UsersSearch>> SearchUsers(string phoneNumbers = null, string emails = null,
            string twitterHandles = null, string twitterSource = null, string facebookIds = null, string name = null,
            string any = null)
        {
            var req = new FoursquareRequest(_apiBase + "users/search", FoursquareRequest.HttpMethod.POST);
            req.AddParam("phone", phoneNumbers);
            req.AddParam("email", emails);
            req.AddParam("twitter", twitterHandles);
            req.AddParam("twitterSource", twitterSource);
            req.AddParam("fbid", facebookIds);
            req.AddParam("name", name);
            req.AddParam("any", any);

            AddCommonParams(ref req);
            return req.MakeRequest<UsersSearch>();
        }

        public Task<FoursquareResponse<ScoreboardResponse>> Scoreboard(string id)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "users/{0}/scoreboard", id));
            AddCommonParams(ref req);
            return req.MakeRequest<ScoreboardResponse>();
        }

        public Task<FoursquareResponse<MayorshipResponse>> Mayorships(string id)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "users/{0}/achievements", id));
            AddCommonParams(ref req);
            return req.MakeRequest<MayorshipResponse>();
        }

        public Task<FoursquareResponse<HistoryCompletion>> GetHistoryAutoComplete(string id, FoursquareLocation loc = null)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "users/{0}/historycompletions", id));
            AddCommonParams(ref req);
            AddLocationParams(ref req, loc);
            return req.MakeRequest<HistoryCompletion>();
        }

        public Task<FoursquareResponse<HistorySearch>> SearchHistory(string id, int offset = 0, int limit = DEFAULT_PAGE_SIZE, string geoId = null,
            string venueId = null, string categoryId = null, string friendId = null, string stickerId = null, string near = null, string llBounds = null, FoursquareLocation loc = null) 
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "users/{0}/historysearch", id));
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

        public Task<TwoResponses<User, HistorySearch>> GetUserAndHistory(string id, FoursquareLocation loc = null)
        {
            var req = new FoursquareRequest(_apiBase + "multi");
            var user = new FoursquareRequest(string.Format("/users/{0}", id));
            var history = new FoursquareRequest(string.Format("/users/{0}/historysearch", id));
            req.AddSubRequest(user);
            req.AddSubRequest(history);
            AddCommonParams(ref req);
            AddLocationParams(ref req, loc);
            return req.MakeRequest<User, HistorySearch>();
        }

        public Task<TwoResponses<User, ActivityStream>> GetUserAndActivities(string id, FoursquareLocation loc = null)
        {
            var req = new FoursquareRequest(_apiBase + "multi");
            var user = new FoursquareRequest(string.Format("/users/{0}", id));
            var history = new FoursquareRequest(string.Format("/users/{0}/activities", id));
            req.AddSubRequest(user);
            req.AddSubRequest(history);
            AddCommonParams(ref req);
            AddLocationParams(ref req, loc);
            return req.MakeRequest<User, ActivityStream>();
        }

        public Task<FoursquareResponse<ActivityStream>> UserActivities(string id = "self", FoursquareLocation loc = null, string leadingMarker = null, 
            string trailingMarker = null, 
            int limit = DEFAULT_PAGE_SIZE, 
            string intent = null)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "users/{0}/activities", id));
            req.AddParam("afterMarker", leadingMarker);
            req.AddParam("beforeMarker", leadingMarker);
            req.AddParam("limit", limit.ToString());
            req.AddParam("intent", intent);
            AddCommonParams(ref req);
            return req.MakeRequest<ActivityStream>();
        }

        public Task<FoursquareResponse<FoursquareList<Photo>>> Photos(string type, string id = "self", int limit = DEFAULT_PAGE_SIZE, int offset = 0)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "{0}/{1}/photos", ApiUtils.PluralizeType(type), id));
            req.AddParam("limit", limit.ToString());
            req.AddParam("offset", offset.ToString());
            AddCommonParams(ref req);
            return req.MakeRequest<FoursquareList<Photo>>();
        }

        public Task<FourResponses<User, FoursquareList<Tip>, ExpertiseSections, FoursquareGroups<Taste>>> GetUserDetails(string id,
            FoursquareLocation loc = null, int tipLimit = DEFAULT_PAGE_SIZE, int tipOffset = 0, string tipSortOrder = Constants.SORT_FLAG_RECENT, string subjectId = null)
        {
            var req = new FoursquareRequest(_apiBase + "multi");
            var user = new FoursquareRequest(string.Format("/users/{0}", id));
            var tips = new FoursquareRequest(string.Format("/users/{0}/tips", id));
            var expertise = new FoursquareRequest(string.Format("/users/{0}/expertise", id));
            var tastes = new FoursquareRequest(string.Format("/users/{0}/tastes", id));

            tips.AddParam("sort", tipSortOrder);
            tips.AddParam("limit", tipLimit.ToString());
            tips.AddParam("offset", tipOffset.ToString());
            tips.AddParam("subjectId", subjectId);

            expertise.AddParam("limit", tipLimit.ToString());

            req.AddSubRequest(user);
            req.AddSubRequest(tips);
            req.AddSubRequest(expertise);
            req.AddSubRequest(tastes);
            AddCommonParams(ref req);
            AddLocationParams(ref req, loc);
            return req.MakeRequest<User, FoursquareList<Tip>, ExpertiseSections, FoursquareGroups<Taste>>();
        }

        public Task<FoursquareResponse<User>> BlockUser(string userId, bool block = true)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "users/{0}/{1}",userId, block ? "block" : "unblock"), FoursquareRequest.HttpMethod.POST);
            AddCommonParams(ref req);
            return req.MakeRequest<User>();
        }

        public Task<FoursquareResponse<User>> FlagUser(string userId, string reasons)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "users/{0}/flag", userId), FoursquareRequest.HttpMethod.POST);
            req.AddParam("problems", reasons);

            AddCommonParams(ref req);
            return req.MakeRequest<User>();
        }

        public Task<FoursquareResponse<CheckinAchievements>> Achievements(string userId)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "users/{0}/achievements", userId));
            AddCommonParams(ref req);
            return req.MakeRequest<CheckinAchievements>();
        }
        #endregion

        #region Expertise
        public Task<FoursquareResponse<ExpertiseSection>> ExpertiseSummary(string id, FoursquareLocation loc = null)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "users/{0}/expertisesummary", id));
            AddLocationParams(ref req, loc);
            AddCommonParams(ref req);
            return req.MakeRequest<ExpertiseSection>();
        }

        public Task<FoursquareResponse<ExpertiseSections>> Expertise(string id, int limit = DEFAULT_PAGE_SIZE, string afterMarker = null, FoursquareLocation loc = null)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "users/{0}/expertise", id));
            req.AddParam("limit", limit.ToString());
            req.AddParam("afterMarker", afterMarker);
            AddLocationParams(ref req, loc);
            AddCommonParams(ref req);
            return req.MakeRequest<ExpertiseSections>();
        }
        #endregion

        #region BrowseExplore
        public Task<FoursquareResponse<TopPicksResponse>> TopPicks(FoursquareLocation loc)
        {
            var req = new FoursquareRequest(_apiBase + "browse/toppicks");
            AddCommonParams(ref req);
            AddLocationParams(ref req, loc);
            return req.MakeRequest<TopPicksResponse>();
        }

        public Task<FoursquareResponse<DialpadResponse>> Dialpad(FoursquareLocation loc)
        {
            var req = new FoursquareRequest(_apiBase + "search/dialpad");
            AddCommonParams(ref req);
            AddLocationParams(ref req, loc);
            return req.MakeRequest<DialpadResponse>();
        }

        public Task<FoursquareResponse<BrowseExplore>> BrowseExplore(BrowseExploreFilters filters, Sort sort = Sort.BEST_MATCH, 
            string near = null, string nearGeoId = null, int snippetCharLimit = Constants.BROWSE_EXPLORE_SNIPPET_LENGTH,
            FoursquareLocation location = null, FoursquareLocation currentLocation = null, FoursquareLocation ne = null, FoursquareLocation sw = null,
            bool ignoreSpellingCorrection = false, int? searchRadius = null, string mode = null, int limit = DEFAULT_PAGE_SIZE, int offset = 0,
            List<string> excludeVenues = null, List<string> includeVenues = null, string referralId = null, BrowseSuggestionsLocations.BrowseSuggestionsGeoBounds bounds = null,
            int initialOffset = 0)
        {
            var req = new FoursquareRequest(_apiBase + "search/recommendations");
            if (searchRadius.HasValue)
            {
                req.AddParam("radius", searchRadius.GetValueOrDefault(0).ToString());
            }
            req.AddParam("snippetCharacterLimit", snippetCharLimit.ToString());
            switch (sort)
            {
                case Sort.DISTANCE:
                    req.AddParam("sortByDistance", "1");
                    break;
                case Sort.RATING:
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
            return req.MakeRequest<BrowseExplore>();
        }
        #endregion

        #region Friends
        public Task<FoursquareResponse<FollowersResult>> GetUserFollowers(string id, string checksum = null, string trailingMarker = null, int limit = 25)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "users/{0}/followers", id));
            req.AddParam("limit", limit.ToString());
            req.AddParam("afterMarker", trailingMarker);
            req.AddParam("checksum", checksum);
            AddCommonParams(ref req);
            return req.MakeRequest<FollowersResult>();
        }

        public Task<FoursquareResponse<FollowingResult>> GetUserFollowing(string id, string checksum = null, string trailingMarker = null, int limit = 25)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "users/{0}/following", id));
            req.AddParam("limit", limit.ToString());
            req.AddParam("afterMarker", trailingMarker);
            req.AddParam("checksum", checksum);
            AddCommonParams(ref req);
            return req.MakeRequest<FollowingResult>();
        }

        public Task<FoursquareResponse<Friends>> UserFriends(string id = "self", string checksum = null)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "users/{0}/friends", id));
            req.AddParam("checksum", checksum);
            AddCommonParams(ref req);
            return req.MakeRequest<Friends>();
        }

        public Task<TwoResponses<FriendRequests, Friends>> UserFriendsAndRequests(string checksum)
        {
            var req = new FoursquareRequest(_apiBase + "multi");
            var friendsRequest = new FoursquareRequest("/users/self/friends");
            var requestsRequest = new FoursquareRequest("/users/requests");
            friendsRequest.AddParam("checksum", checksum);

            req.AddSubRequest(requestsRequest);
            req.AddSubRequest(friendsRequest);

            AddCommonParams(ref req);
            return req.MakeRequest<FriendRequests, Friends>();
        }

        public Task<FoursquareResponse<User>> AddFriend(string id)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "users/{0}/request", id), FoursquareRequest.HttpMethod.POST);
            AddCommonParams(ref req);
            return req.MakeRequest<User>();
        }

        public Task<FoursquareResponse<Empty>> BulkAddFriend(string userIds)
        {
            var req = new FoursquareRequest(_apiBase + "users/bulkrequest", FoursquareRequest.HttpMethod.POST);
            req.AddParam("userIds", userIds);
            AddCommonParams(ref req);
            return req.MakeRequest<Empty>();
        }

        public Task<FoursquareResponse<User>> Follow(string id)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "users/{0}/createfollow", id), FoursquareRequest.HttpMethod.POST);
            AddCommonParams(ref req);
            return req.MakeRequest<User>();
        }

        public Task<FoursquareResponse<Empty>> BulkFollow(string ids)
        {
            var req = new FoursquareRequest(_apiBase + "users/createfollows", FoursquareRequest.HttpMethod.POST);
            req.AddParam("userIds", ids);
            AddCommonParams(ref req);
            return req.MakeRequest<Empty>();
        }

        public Task<FoursquareResponse<Empty>> BulkUnfollow(string ids)
        {
            var req = new FoursquareRequest(_apiBase + "users/deletefollows", FoursquareRequest.HttpMethod.POST);
            req.AddParam("userIds", ids);
            AddCommonParams(ref req);
            return req.MakeRequest<Empty>();
        }

        public Task<FoursquareResponse<User>> Unfollow(string id)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "users/{0}/unfollow", id), FoursquareRequest.HttpMethod.POST);
            AddCommonParams(ref req);
            return req.MakeRequest<User>();
        }

        public Task<FoursquareResponse<Empty>> InviteFriends(string csvs, string fbRequestIds, bool reporting)
        {
            var req = new FoursquareRequest(_apiBase + "users/invite", FoursquareRequest.HttpMethod.POST);
            if (reporting)
            {
                req.AddParam("fbid", csvs);
                req.AddParam("fbRequestId", fbRequestIds);
            }
            else
            {
                req.AddParam("email", csvs);
            }
            AddCommonParams(ref req);
            return req.MakeRequest<Empty>();
        }

        public Task<FoursquareResponse<FriendRequests>> FriendRequests()
        {
            var req = new FoursquareRequest(_apiBase + "users/requests");
            AddCommonParams(ref req);
            return req.MakeRequest<FriendRequests>();
        }

        public Task<FoursquareResponse<User>> Unfriend(string id)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "users/{0}/unfriend", id), FoursquareRequest.HttpMethod.POST);
            AddCommonParams(ref req);
            return req.MakeRequest<User>();
        }

        public Task<FoursquareResponse<User>> ApproveRequest(string id)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "users/{0}/approve", id), FoursquareRequest.HttpMethod.POST);
            AddCommonParams(ref req);
            return req.MakeRequest<User>();
        }

        public Task<FoursquareResponse<User>> DenyRequest(string id)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "users/{0}/deny", id), FoursquareRequest.HttpMethod.POST);
            AddCommonParams(ref req);
            return req.MakeRequest<User>();
        }

        public Task<FoursquareResponse<User>> UpdateCheckinPings(string id, string type)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "users/{0}/setcheckinpings", id), FoursquareRequest.HttpMethod.POST);
            AddCommonParams(ref req);
            req.AddParam("value", type);
            return req.MakeRequest<User>();
        }
        #endregion

        #region Feed
        public Task<FoursquareResponse<ActivitiesRecentResponse>> GetFeed(string leadingMarker = null, 
            string trailingMarker = null, 
            int limit = DEFAULT_PAGE_SIZE, 
            FoursquareLocation loc = null, 
            long updatesAfterTs = -1, 
            string uniqueDevice = null,
            int attachmentLimit = 4,
            int idealLimit = 3)
        {
            var req = new FoursquareRequest(_apiBase + "activities/recent");
            req.AddParam("attachmentsLimit", attachmentLimit.ToString());
            req.AddParam("idealLimit", idealLimit.ToString());
            req.AddParam("earliestAttachments", "false");
            req.AddParam("limit", limit.ToString());
            req.AddParam("afterMarker", leadingMarker);
            if (updatesAfterTs > 0)
            {
                req.AddParam("updatesAfterMarker", trailingMarker);
                req.AddParam("afterTimestamp", updatesAfterTs.ToString());
            }
            else
            {
                req.AddParam("beforeMarker", trailingMarker);
            }
            AddCommonParams(ref req);
            AddLocationParams(ref req, loc);
            return req.MakeRequest<ActivitiesRecentResponse>();
        }

        public Task<FoursquareResponse<FoursquareList<NotificationTrayItem>>> Notifications(int limit = DEFAULT_PAGE_SIZE, int offset = 0)
        {
            var req = new FoursquareRequest(_apiBase + "updates/notifications");
            req.AddParam("limit", limit.ToString());
            req.AddParam("offset", offset.ToString());
            AddCommonParams(ref req);
            return req.MakeRequest<FoursquareList<NotificationTrayItem>>();
        }

        public Task<TwoResponses<FriendRequests,FoursquareList<NotificationTrayItem>>> NotificationsAndFriendRequests(int limit = DEFAULT_PAGE_SIZE, int offset = 0, string checksum = null)
        {
            var req = new FoursquareRequest(_apiBase + "multi");

            var req1 = new FoursquareRequest("/users/requests");
            req1.AddParam("checksum", checksum);

            var req2 = new FoursquareRequest("/updates/notifications");
            req.AddParam("limit", limit.ToString());
            req.AddParam("offset", offset.ToString());

            req.AddSubRequest(req1);
            req.AddSubRequest(req2);

            AddCommonParams(ref req);
            return req.MakeRequest<FriendRequests, FoursquareList<NotificationTrayItem>>();
        }

        public Task<FoursquareResponse<Empty>> MarkNotificationsRead(long timeInSeconds)
        {
            var req = new FoursquareRequest(_apiBase + "updates/marknotificationsread", FoursquareRequest.HttpMethod.POST);
            req.AddParam("highWatermark", timeInSeconds.ToString());
            AddCommonParams(ref req);
            return req.MakeRequest<Empty>();
        }
        #endregion

        #region Checkins
        public Task<FoursquareResponse<CheckinWithNotifications>> AddCheckin(FoursquareLocation loc,
            string featureId = null, 
            string shout = null, 
            string eventId = null,
            string mentions = null,
            string with = null,
            bool publicCheckin = true,
            bool twitterShare = false,
            bool facebookShare = false,
            bool followersShare = false,
            bool broadcastLater = false,
            string debugInsights = null,
            string stickerId = null,
            string venue = null) {
            var req = new FoursquareRequest(_apiBase + "checkins/add", FoursquareRequest.HttpMethod.POST);
            AddCommonParams(ref req);
            req.AddParam("shout", shout);
            req.AddParam("eventId", eventId);
            req.AddParam("mentions", mentions);
            req.AddParam("with", with);

            string broadcast = "";
            if (!publicCheckin) {
                broadcast = "private";
            } else {
                broadcast = "public";
                if (twitterShare) {
                    broadcast += ",twitter";
                }
                if (facebookShare) {
                    broadcast += ",facebook";
                }
                if (followersShare) {
                    broadcast += ",followers";
                }
            }

            req.AddParam("broadcast", broadcast);
            req.AddParam("broadcastLater", broadcastLater.ToString().ToLower());
            req.AddParam("stickerId", stickerId);
            req.AddParam(string.IsNullOrEmpty(venue) ? "featureId" : "venueId", featureId);
            req.AddParam("venue", venue);
            req.AddParam("debuginsights", debugInsights);
            return req.MakeRequest<CheckinWithNotifications>();
        }

        public Task<FoursquareResponse<CheckinWithNotifications>> ShareCheckin(string id, bool facebook, bool twitter)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "checkins/{0}/share", id), FoursquareRequest.HttpMethod.POST);
            string broadcast = null;
            if (facebook && twitter)
            {
                broadcast = "facebook,twitter";
            }
            else if (facebook)
            {
                broadcast = "facebook";
            }
            else if (twitter)
            {
                broadcast = "twitter";
            }
            req.AddParam("broadcast", broadcast);
            AddCommonParams(ref req);
            return req.MakeRequest<CheckinWithNotifications>();
        }

        public Task<FoursquareResponse<Empty>> DeleteCheckin(string id)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "checkins/{0}/delete", id), FoursquareRequest.HttpMethod.POST);
            AddCommonParams(ref req);
            return req.MakeRequest<Empty>();
        }

        public Task<FoursquareResponse<CheckinDetailResponse>> CheckinDetails(string id, FoursquareLocation loc = null, string signature = null)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "checkins/{0}", id));
            req.AddParam("attachmentsLimit", DEFAULT_COUNT.ToString());
            req.AddParam("idealLimit", DEFAULT_COUNT.ToString());
            req.AddParam("earliestAttachments", "false");
            req.AddParam("signature", signature);
            req.AddParam("includeOverlapPhotos", "true");
            AddLocationParams(ref req, loc);
            AddCommonParams(ref req);
            return req.MakeRequest<CheckinDetailResponse>();
        }
        #endregion

        #region Photos
        public Task<FoursquareResponse<Empty>> DeletePhoto(string id)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "photos/{0}/delete", id), FoursquareRequest.HttpMethod.POST);
            AddCommonParams(ref req);
            return req.MakeRequest<Empty>();
        }

        public Task<FoursquareResponse<Photo>> AddPhoto(Stream file, string checkinId = null, string venueId = null, string tipId = null, bool twitter = false, bool facebook = false, bool makePublic = false, FoursquareLocation loc = null)
        {
            var req = new FoursquareRequest(_apiBase + "photos/add", FoursquareRequest.HttpMethod.PHOTO_POST);
            req.File = file;
            string broadcast = string.Empty;
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
            return req.MakeRequest<Photo>();
        }

        public Task<FoursquareResponse<Empty>> FlagPhoto(string id, string problem)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "photos/{0}/flag", id), FoursquareRequest.HttpMethod.POST);
            req.AddParam("problem", problem);
            AddCommonParams(ref req);
            return req.MakeRequest<Empty>();
        }
        #endregion

        #region Plans     
        public Task<FoursquareResponse<PlansRecent>> RecentPlans(string afterMarker = null, string beforeMarker = null, int limit = DEFAULT_PAGE_SIZE, bool active = true, FoursquareLocation loc = null)
        {
            var req = new FoursquareRequest(_apiBase + "plans/recent");
            req.AddParam("afterMarker", afterMarker);
            req.AddParam("beforeMarker", beforeMarker);
            req.AddParam("limit", limit.ToString());
            req.AddParam("mode", active ? "active" : null);
            req.AddParamIf("bg", !active);
            AddLocationParams(ref req, loc);
            AddCommonParams(ref req);
            return req.MakeRequest<PlansRecent>();
        }

        public Task<FoursquareResponse<Empty>> MarkPlanRead(string id, string afterMarker)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "plans/{0}/markread", id), FoursquareRequest.HttpMethod.POST);
            req.AddParam("afterMarker", afterMarker);
            AddCommonParams(ref req);
            return req.MakeRequest<Empty>();
        }

        public Task<FoursquareResponse<Empty>> DeletePlan(string id)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "plans/{0}/delete", id), FoursquareRequest.HttpMethod.POST);
            AddCommonParams(ref req);
            return req.MakeRequest<Empty>();
        }

        public Task<FoursquareResponse<Plan>> PlanDetails(string id, string afterMarker=null, bool isPoll=false)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "plans/{0}",id));
            req.AddParam("afterMarker", afterMarker);
            req.AddParamIf("isPoll", isPoll);
            AddCommonParams(ref req);
            return req.MakeRequest<Plan>();
        }

        public Task<FoursquareResponse<Empty>> LeavePlan(string id)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "plans/{0}/leave", id), FoursquareRequest.HttpMethod.POST);
            AddCommonParams(ref req);
            return req.MakeRequest<Empty>();
        }

        public Task<FoursquareResponse<Empty>> MutePlan(string id, bool mute)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "plans/{0}/setmute", id), FoursquareRequest.HttpMethod.POST);
            req.AddParam("value", mute ? "1" : "0");
            AddCommonParams(ref req);
            return req.MakeRequest<Empty>();
        }

        public Task<FoursquareResponse<CommentWithVenues>> AddNoteHi(string planId, string stickerId, FoursquareLocation loc)
        {
            var req = new FoursquareRequest(_apiBase + String.Format("plans/{0}/addhi", planId), FoursquareRequest.HttpMethod.POST);
            req.AddParam("addHi", "true");
            req.AddParam("stickerId", stickerId);

            AddCommonParams(ref req);
            AddLocationParams(ref req, loc);
            return req.MakeRequest<CommentWithVenues>();
        }

        public Task<FoursquareResponse<CommentWithVenues>> AddNoteComment(string planId, string text, string mentions, FoursquareLocation loc)
        {
            var req = new FoursquareRequest(_apiBase + String.Format("plans/{0}/addcomment", planId), FoursquareRequest.HttpMethod.POST);
            req.AddParam("text", text);
            req.AddParam("isBroadcast", "false");
            req.AddParam("mentions", mentions);
            AddCommonParams(ref req);
            AddLocationParams(ref req, loc);
            return req.MakeRequest<CommentWithVenues>();
        }

        public Task<FoursquareResponse<CommentWithVenues>> AddNotePhoto(string planId, Stream file, FoursquareLocation loc)
        {
            var req = new FoursquareRequest(_apiBase + String.Format("plans/{0}/addphoto", planId), FoursquareRequest.HttpMethod.PHOTO_POST)
            {
                File = file
            };

            AddCommonParams(ref req);
            AddLocationParams(ref req, loc);
            return req.MakeRequest<CommentWithVenues>();
        }

        public Task<FoursquareResponse<PlanDetailsResponse>> CreatePlanNote(IEnumerable<string> invitees, 
            FoursquareLocation loc, string text = null, string mentions = null, Stream file = null, 
            string stickerId = null, bool isHi = false, string offNetworkInvitees = null)
        {
            var req = new FoursquareRequest(_apiBase + "plans/addnote", (file == null) ? FoursquareRequest.HttpMethod.POST : FoursquareRequest.HttpMethod.PHOTO_POST)
            {
                File = file
            };

            req.AddParam("invitees", String.Join(",", invitees));
            req.AddParam("offNetworkInvitees", offNetworkInvitees);
            req.AddParam("isBroadcast", "false");

            if (isHi)
            {
                req.AddParam("addHi", "true");
                req.AddParam("stickerId", stickerId);
            }

            if (text != null)
            {
                req.AddParam("text", text);
            }

            if (mentions != null)
            {
                req.AddParam("mentions", mentions);
            }

            AddCommonParams(ref req);
            AddLocationParams(ref req, loc);
            return req.MakeRequest<PlanDetailsResponse>();
        }

        public Task<FoursquareResponse<PlanInvite>> InviteToMessage(string id, string invitees, string offNetworkUsers = null)
        {
            var req = new FoursquareRequest(_apiBase + String.Format("plans/{0}/invite", id), FoursquareRequest.HttpMethod.POST);
            req.AddParam("invitees", invitees);
            req.AddParam("offNetworkInvitees", offNetworkUsers);

            AddCommonParams(ref req);
            return req.MakeRequest<PlanInvite>();
        }
        #endregion

        #region Stickers
        public Task<FoursquareResponse<StickersResponse>> StickersForVenue(string venueId, string checksum = null)
        {
            var req = new FoursquareRequest(_apiBase + "stickers/forvenue");
            req.AddParam("venueId", venueId);
            req.AddParam("checksum", checksum);
            AddCommonParams(ref req);
            return req.MakeRequest<StickersResponse>();
        }

        public Task<FoursquareResponse<BadgeResponse>> LegacyBadges()
        {
            var req = new FoursquareRequest(_apiBase + "users/self/legacybadges");
            AddCommonParams(ref req);
            return req.MakeRequest<BadgeResponse>();
        }

        public Task<FoursquareResponse<StickersResponse>> UserStickers(string userId)
        {
            var req = new FoursquareRequest(_apiBase + string.Format("users/{0}/stickers", userId));
            AddCommonParams(ref req);
            return req.MakeRequest<StickersResponse>();
        }

        public Task<TwoResponses<StickersResponse, BadgeResponse>> UserStickersAndBadges(string userId)
        {
            var req = new FoursquareRequest(_apiBase + "multi");

            var stickerRequest = new FoursquareRequest(string.Format("/users/{0}/stickers", userId));
            var badgesRequest = new FoursquareRequest(string.Format("/users/{0}/legacybadges", userId));
            req.AddSubRequest(stickerRequest);
            req.AddSubRequest(badgesRequest);
            AddCommonParams(ref req);
            return req.MakeRequest<StickersResponse, BadgeResponse>();
        }
        #endregion

        #region Venues
        public Task<FoursquareResponse<Venue>> VenueDetails(string id, 
            string promotedTipId = null, string intent = null, FoursquareLocation loc = null,
            string tasteIds = null, string searchTipId = null)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "venues/{0}", id));
            req.AddParam("intent", intent);
            req.AddParam("tasteIds", tasteIds);
            req.AddParam("searchTipId", searchTipId);
            req.AddParam("promotedTipId", promotedTipId);
            AddLocationParams(ref req, loc);
            AddCommonParams(ref req);
            return req.MakeRequest<Venue>();
        }

        public Task<FoursquareResponse<FoursquareList<Event>>> VenueEvents(string id, string intent = null)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "venues/{0}/events", id));
            req.AddParam("intent", intent);
            AddCommonParams(ref req);
            return req.MakeRequest<FoursquareList<Event>>();
        }

        public Task<FoursquareResponse<VenueSearch>> SearchVenues(FoursquareLocation loc, 
            string query = null, 
            int limit = DEFAULT_PAGE_SIZE, 
            string appSource = null, 
            bool spellCorrect = false, 
            string intent = "checkin", 
            string wifi = null)
        {
            var req = new FoursquareRequest(_apiBase + "venues/search");
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
            int limit = DEFAULT_PAGE_SIZE, FoursquareLocation loc = null, CancellationTokenSource cancel = null, 
            bool searched = false, string nearbyVenueIds = null)
        {
            var req = new FoursquareRequest(_apiBase + "search/autocomplete");
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
            return req.MakeRequest<AutoComplete>(cancel == null ? new CancellationTokenSource().Token : cancel.Token);
        }
        
        public Task<FoursquareResponse<FoursquareGeocode>> GeocodeAutocomplete(string query, FoursquareLocation loc, int limit = 5)
        {
            var req = new FoursquareRequest(_apiBase + "geo/geocode");
            req.AddParam("maxInterpretations", limit.ToString(CultureInfo.InvariantCulture));
            req.AddParam("autocomplete", "true");
            req.AddParam("query", query);
            AddCommonParams(ref req);
            AddLocationParams(ref req, loc);
            return req.MakeRequest<FoursquareGeocode>();
        }

        public Task<FoursquareResponse<VenueTipsResponse>> VenueTips(string id, 
            string sort = null, string query = null, string tasteId = null, 
            string promotedTipId = null, string searchTipId = null, 
            int limit = DEFAULT_PAGE_SIZE, int offset = 0, string group = null, FoursquareLocation loc = null)
        {
            var req = new FoursquareRequest(_apiBase + string.Format("venues/{0}/tips", id));
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
            return req.MakeRequest<VenueTipsResponse>();
        }

        public Task<FoursquareResponse<FoursquareList<Photo>>> VenuePhotos(string id,
            int limit = DEFAULT_PAGE_SIZE, int offset = 0, FoursquareLocation loc = null)
        {
            var req = new FoursquareRequest(_apiBase + string.Format("venues/{0}/photos", id));
            req.AddParam("limit", limit.ToString());
            req.AddParam("offset", offset.ToString());
            AddLocationParams(ref req, loc);
            AddCommonParams(ref req);
            return req.MakeRequest<FoursquareList<Photo>>();
        }

        public Task<FoursquareResponse<Categories>> Categories(FoursquareLocation loc = null, string countryCode = null)
        {
            var req = new FoursquareRequest(_apiBase + "venues/categories");
            req.AddParam("cc", countryCode);
            AddLocationParams(ref req, loc);
            AddCommonParams(ref req);
            return req.MakeRequest<Categories>();
        }

        public Task<FoursquareResponse<AddVenue>> AddVenue(Venue v, string category, FoursquareLocation loc, bool isPrivate = false, string dupeDetectedOverrideKey = null)
        {
            var req = new FoursquareRequest(_apiBase + "venues/add", FoursquareRequest.HttpMethod.POST);
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
        public Task<FoursquareResponse<Empty>> FlagTip(string id, string problem)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "tips/{0}/flag", id), FoursquareRequest.HttpMethod.POST);
            req.AddParam("problem", problem);
            AddCommonParams(ref req);
            return req.MakeRequest<Empty>();
        }

        public Task<FoursquareResponse<Tip>> DeleteTip(string id)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "tips/{0}/delete", id), FoursquareRequest.HttpMethod.POST);
            AddCommonParams(ref req);
            return req.MakeRequest<Tip>();
        }

        public Task<FoursquareResponse<AddTip>> AddTip(string venueId, string text, bool facebook = false, bool twitter = false, long endTime = 0, string fakeInsight = null)
        {
            var req = new FoursquareRequest(_apiBase + "tips/add", FoursquareRequest.HttpMethod.POST);
            string broadcast = string.Empty;
            if (facebook)
            {
                broadcast += "facebook";
            }
            if (facebook && twitter)
            {
                broadcast += ",";
            }
            if (twitter)
            {
                broadcast += "twitter";
            }
            req.AddParam("broadcast", broadcast);
            req.AddParam("venueId", venueId);
            req.AddParam("text", text);
            if (endTime > 0)
            {
                req.AddParam("endAt", endTime.ToString());
            }
            req.AddParam("fakeInsightType", fakeInsight);
            AddCommonParams(ref req);
            return req.MakeRequest<AddTip>();
        }

        public Task<FoursquareResponse<Tip>> TipDetail(string id, string intent = null, FoursquareLocation loc = null)
        {
            var req = new FoursquareRequest(_apiBase + "tips/" + id);
            req.AddParam("intent", intent);
            AddLocationParams(ref req, loc);
            AddCommonParams(ref req);
            return req.MakeRequest<Tip>();
        }

        public Task<FoursquareResponse<FoursquareList<Tip>>> UserTips(string id, string sort = null, int limit = DEFAULT_PAGE_SIZE, int offset = 0, string subjectId = null, FoursquareLocation loc = null)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "users/{0}/tips",id));
            req.AddParam("sort", sort);
            req.AddParam("limit", limit.ToString());
            req.AddParam("offset", offset.ToString());
            req.AddParam("subjectId", subjectId);
            AddLocationParams(ref req, loc);
            AddCommonParams(ref req);
            return req.MakeRequest<FoursquareList<Tip>>();
        }
        #endregion

        #region Tastes
        public Task<FoursquareResponse<TastesAutocomplete>> TasteAutocomplete(string query)
        {
            var req = new FoursquareRequest(_apiBase + "tastes/autocomplete");
            req.AddParam("query", query);
            AddCommonParams(ref req);
            return req.MakeRequest<TastesAutocomplete>();
        }

        public Task<FoursquareResponse<FoursquareGroups<Taste>>> UserTastes(string id)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "users/{0}/tastes", id));
            AddCommonParams(ref req);
            return req.MakeRequest<FoursquareGroups<Taste>>();
        }

        public Task<FoursquareResponse<TastesSuggestions>> TasteSuggestions(int limit = DEFAULT_PAGE_SIZE, int offset = 0, 
            long seed = 0, FoursquareLocation loc = null, string intent = null, string prependTasteIds = null)
        {
            var req = new FoursquareRequest(_apiBase + "tastes/suggestions");
            req.AddParam("limit", limit.ToString());
            req.AddParam("offset", offset.ToString());
            if (seed > 0)
            {
                req.AddParam("seed", seed.ToString());
            }
            req.AddParam("intent", intent);
            req.AddParam("prefixTasteIds", prependTasteIds);
            AddCommonParams(ref req);
            AddLocationParams(ref req, loc);
            return req.MakeRequest<TastesSuggestions>();
        }

        public Task<FoursquareResponse<Empty>> AddTastes(List<string> tastes)
        {
            var req = new FoursquareRequest(_apiBase + "tastes/add", FoursquareRequest.HttpMethod.POST);
            req.AddParam("tasteId", string.Join(",", tastes));
            req.AddParam("tasteState", ((int)Constants.TasteInteractionState.LIKE).ToString());
            AddCommonParams(ref req);
            return req.MakeRequest<Empty>();
        }

        public Task<FoursquareResponse<Empty>> DeleteTaste(string taste)
        {
            var req = new FoursquareRequest(_apiBase + "tastes/delete", FoursquareRequest.HttpMethod.POST);
            req.AddParam("tasteId", taste);
            AddCommonParams(ref req);
            return req.MakeRequest<Empty>();
        }
        #endregion

        #region Opinionator

        public Task<FoursquareResponse<Opinions>> GetOpinionator(int round = 0, string anchorVenueId = null,
            string forceVenueId = null, FoursquareLocation loc = null, string debugModules = null)
        {
            var req = new FoursquareRequest(_apiBase + "opinionator/recent");
            if (round > 0)
            {
                req.AddParam("round", round.ToString());
            }
            req.AddParam("includePCheckins", "true");
            if (!string.IsNullOrEmpty(anchorVenueId))
            {
                req.AddParam("anchorVenueId", anchorVenueId);
            }
            if (!string.IsNullOrEmpty(forceVenueId))
            {
                req.AddParam("forceVenueId", forceVenueId);
            }
            AddCommonParams(ref req);
            AddLocationParams(ref req, loc);
            return req.MakeRequest<Opinions>();
        }

        public Task<FoursquareResponse<OpinionatorSummary>> GetOpinionatorSummary(int followerLimit = 5,
            int venueSuggestionsLimit = 3, int venueSuggestionsCandidateLimit = 50,
            int venueSuggestionsSimilarVenuesLimit = 50, string roundId = null,
            string impressionId = null, string debugSummary = null)
        {
            var req = new FoursquareRequest(_apiBase + "opinionator/summary");
            req.AddParam("roundId", roundId);
            req.AddParam("followerLimit", followerLimit.ToString());
            req.AddParam("venueSuggestionsLimit", venueSuggestionsLimit.ToString());
            req.AddParam("venueSuggestionsCandidateLimit", venueSuggestionsCandidateLimit.ToString());
            req.AddParam("venueSuggestionsSimilarVenuesLimit", venueSuggestionsSimilarVenuesLimit.ToString());
            req.AddParam("debugSummaryType", debugSummary);
            req.AddParam("impressionId", impressionId);
            AddCommonParams(ref req);
            return req.MakeRequest<OpinionatorSummary>();  
        }

        public Task<FoursquareResponse<Empty>> ClearOpinionatorHistory()
        {
            var req = new FoursquareRequest(_apiBase + "opinionator/clearhistory", FoursquareRequest.HttpMethod.POST);
            AddCommonParams(ref req);
            return req.MakeRequest<Empty>();
        }
        #endregion

        #region Inbox
        public Task<FoursquareResponse<FoursquareList<Share>>> Inbox(int limit = DEFAULT_PAGE_SIZE, int offset = 0)
        {
            var req = new FoursquareRequest(_apiBase + "users/inbox");
            req.AddParam("limit", limit.ToString());
            req.AddParam("offset", offset.ToString());
            req.AddParam("view", "recent");
            return req.MakeRequest<FoursquareList<Share>>();
        }

        public Task<FoursquareResponse<Empty>> AcceptShare(string id)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "shares/{0}/accept", id), FoursquareRequest.HttpMethod.POST);
            AddCommonParams(ref req);
            return req.MakeRequest<Empty>();
        }

        public Task<FoursquareResponse<Empty>> IgnoreShare(string id)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "shares/{0}/ignore", id), FoursquareRequest.HttpMethod.POST);
            AddCommonParams(ref req);
            return req.MakeRequest<Empty>();
        }

        public Task<FoursquareResponse<Share>> DeleteShare(string id)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "shares/{0}/delete", id), FoursquareRequest.HttpMethod.POST);
            AddCommonParams(ref req);
            return req.MakeRequest<Share>();
        }

        public Task<FoursquareResponse<Venue>> SaveVenue(string id, bool saving)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "venues/{0}/save", id), FoursquareRequest.HttpMethod.POST);
            req.AddParam("set", saving.ToString().ToLower());
            AddCommonParams(ref req);
            return req.MakeRequest<Venue>();
        }

        public Task<FoursquareResponse<Tip>> SaveTip(string id, bool saving)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "tips/{0}/save", id), FoursquareRequest.HttpMethod.POST);
            req.AddParam("set", saving.ToString().ToLower());
            AddCommonParams(ref req);
            return req.MakeRequest<Tip>();
        }

        public Task<FoursquareResponse<Share>> ShareAddNote(string id, string text)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "shares/{0}/addnote", id), FoursquareRequest.HttpMethod.POST);
            req.AddParam("text", text);
            AddCommonParams(ref req);
            return req.MakeRequest<Share>();
        }

        public Task<FoursquareResponse<FoursquareList<Share>>> Saves(string id, int offset = 0, int limit = DEFAULT_PAGE_SIZE, long startAt = -1, string sort = null, FoursquareLocation loc = null)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "users/{0}/saves", id));
            req.AddParam("limit", limit.ToString());
            req.AddParam("offset", offset.ToString());
            if (startAt > -1)
            {
                req.AddParam("startAt", startAt.ToString());
            }
            req.AddParam("sort", sort);
            AddLocationParams(ref req, loc);
            AddCommonParams(ref req);
            return req.MakeRequest<FoursquareList<Share>>();
        }

        public Task<FoursquareResponse<FoursquareGroups<Share>>> TipSaves(string id)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "tips/{0}/saves", id));
            AddCommonParams(ref req);
            return req.MakeRequest<FoursquareGroups<Share>>();
        }

        public Task<ThreeResponses<FoursquareList<Share>, FoursquareList<Share>, FoursquareList<Share>>> InboxSavesMulti(string userId = null,
                        FoursquareLocation loc = null, int limit = DEFAULT_PAGE_SIZE,
                        long startAt = 0, string sort = null)
        {
            var req = new FoursquareRequest(_apiBase + "multi");
            var inbox = new FoursquareRequest("/users/inbox");
            inbox.AddParam("limit", limit.ToString());
            inbox.AddParam("view", "recent");
            var saves = new FoursquareRequest(string.Format("/users/{0}/saves", userId));
            saves.AddParam("limit", limit.ToString());
            if (startAt > -1)
            {
                saves.AddParam("startAt", startAt.ToString());
            }
            saves.AddParam("sort", Constants.SORT_FLAG_NEARBY);

            var savesRecent = new FoursquareRequest(string.Format("/users/{0}/saves", userId));
            savesRecent.AddParam("limit", limit.ToString());
            if (startAt > -1)
            {
                savesRecent.AddParam("startAt", startAt.ToString());
            }
            savesRecent.AddParam("sort", Constants.SORT_FLAG_RECENT);

            req.AddSubRequest(inbox);
            req.AddSubRequest(saves);
            req.AddSubRequest(savesRecent);

            AddCommonParams(ref req);
            AddLocationParams(ref req, loc);

            return req.MakeRequest<FoursquareList<Share>, FoursquareList<Share>, FoursquareList<Share>>();
        }

        public Task<FoursquareResponse<FoursquareList<Share>>> Share(string type, string id, bool facebook, bool twitter, string text = null, List<string> userIds = null)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "{0}/{1}/share", ApiUtils.PluralizeType(type), id), FoursquareRequest.HttpMethod.POST);
            string broadcast = null;
            if (facebook && twitter)
            {
                broadcast = "facebook,twitter";
            }
            else if (facebook)
            {
                broadcast = "facebook";
            }
            else if (twitter)
            {
                broadcast = "twitter";
            }
            req.AddParam("broadcast", broadcast);
            req.AddParam("text", text);
            if (userIds != null && userIds.Count > 0)
            {
                req.AddParam("userIds", string.Join(",", userIds));
            }
            AddCommonParams(ref req);
            return req.MakeRequest<FoursquareList<Share>>();
        }
        #endregion

        #region Settings
        public Task<FoursquareResponse<Settings>> SetSetting(string settingName, string value, string uniqueDevice)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "settings/{0}/set", settingName), FoursquareRequest.HttpMethod.POST);
            req.AddParam("value", value);
            req.AddParam("uniqueDevice", uniqueDevice);
            AddCommonParams(ref req);
            return req.MakeRequest<Settings>();
        }

        public Task<FoursquareResponse<Empty>> SetNotificationSetting(string settingName, bool value, string uniqueDevice)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "settings/notifications/{0}/set", settingName), FoursquareRequest.HttpMethod.POST);
            req.AddParam("value", value.ToString().ToLower());
            req.AddParam("uniqueDevice", uniqueDevice);
            req.AddParam("deviceType", "mobile");
            AddCommonParams(ref req);
            return req.MakeRequest<Empty>();
        }

        public Task<FoursquareResponse<NotificationSettingsResponse>> NotificationSettings(string uniqueDevice)
        {
            var req = new FoursquareRequest(_apiBase + "settings/notifications/all");
            req.AddParam("uniqueDevice", uniqueDevice);
            req.AddParam("deviceType", "mobile");
            AddCommonParams(ref req);
            return req.MakeRequest<NotificationSettingsResponse>();
        }
        #endregion

        #region Common
        public Task<FoursquareResponse<FoursquareGroups<User>>> Like(string type, string id, bool value, string source = null, string signature = null)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "{0}/{1}/like", ApiUtils.PluralizeType(type), id), FoursquareRequest.HttpMethod.POST);
            req.AddParam("set", value.ToString().ToLower());
            req.AddParam("source", source);
            req.AddParam("signature", signature);
            AddCommonParams(ref req);
            return req.MakeRequest<FoursquareGroups<User>>();
        }

        public Task<FoursquareResponse<Likes>> GetLikes(string type, string id, int limit = DEFAULT_COUNT, int offset = 0)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "{0}/{1}/likes", ApiUtils.PluralizeType(type), id));
            req.AddParam("limit", limit.ToString());
            req.AddParam("offset", offset.ToString());
            AddCommonParams(ref req);
            return req.MakeRequest<Likes>();
        }

        public Task<FoursquareResponse<Comment>> Comment(string type, string id, string text, string mentions = null)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "{0}/{1}/addcomment", ApiUtils.PluralizeType(type), id), FoursquareRequest.HttpMethod.POST);
            req.AddParam("text", text);
            req.AddParam("mentions", mentions);
            AddCommonParams(ref req);
            return req.MakeRequest<Comment>();
        }

        public Task<FoursquareResponse<Empty>> GenericCallbackRequest(CallbackUri callback, FoursquareLocation loc = null)
        {
            var req = new FoursquareRequest(_apiBase + callback.url);
            AddCallbackUriParams(ref req, callback);
            AddLocationParams(ref req, loc);
            AddCommonParams(ref req);
            return req.MakeRequest<Empty>();
        }

        #endregion

        #region Lists and Saves
        public Task<FoursquareResponse<TipList>> TipListDetail(string id, int limit = DEFAULT_PAGE_SIZE, int offset = 0, FoursquareLocation loc = null, string includeVenues = null, string sort = null)
        {
            var req = new FoursquareRequest(_apiBase + string.Format("lists/{0}", id));
            req.AddParam("limit", limit.ToString());
            req.AddParam("offset", offset.ToString());
            req.AddParam("sort", sort);
            req.AddParam("includeVenues", includeVenues);
            AddCommonParams(ref req);
            AddLocationParams(ref req, loc);
            return req.MakeRequest<TipList>();
        }

        public Task<FoursquareResponse<FoursquareList<TipList>>> GetLists(string userId, string group, FoursquareLocation location = null, int limit = DEFAULT_PAGE_SIZE, int offset = 0, bool sortNearby = false)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "users/{0}/lists", string.IsNullOrEmpty(userId) ? "self" : userId));
            req.AddParam("limit", limit.ToString());
            req.AddParam("group", group);
            req.AddParam("offset", offset.ToString());
            req.AddParam("sort", sortNearby ? "nearby" : "");

            AddCommonParams(ref req);
            AddLocationParams(ref req, location);
            return req.MakeRequest<FoursquareList<TipList>>();
        }

        public Task<FoursquareResponse<TipList>> CreateList(string listName)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "lists/add"), FoursquareRequest.HttpMethod.POST);
            req.AddParam("name", listName);
            AddCommonParams(ref req);

            return req.MakeRequest<TipList>();
        }
        public Task<FoursquareResponse<Empty>> DeleteList(string listId)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + "lists/{0}/delete", listId), FoursquareRequest.HttpMethod.POST);

            AddCommonParams(ref req);

            return req.MakeRequest<Empty>();
        }


        public Task<FoursquareResponse<FoursquareGroups<Share>>> ListItemsListed(string type, string id)
        {
            var req = new FoursquareRequest(string.Format(_apiBase + String.Format("{0}/{1}/listed", ApiUtils.PluralizeType(type), id)), FoursquareRequest.HttpMethod.POST);

            AddCommonParams(ref req);

            return req.MakeRequest<FoursquareGroups<Share>>();
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

            var req = new FoursquareRequest(string.Format(_apiBase + String.Format(endPoint, listId)), FoursquareRequest.HttpMethod.POST);
            req.AddParam(idKey, id);

            AddCommonParams(ref req);

            return req.MakeRequest<Share>();
        }

        public Task<FoursquareResponse<Share>> DeleteListItem(string type, string id, string listId)
        {
            var endPoint = "lists/{0}/deleteitem";
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

            var req = new FoursquareRequest(string.Format(_apiBase + String.Format(endPoint, listId)), FoursquareRequest.HttpMethod.POST);
            req.AddParam(idKey, id);

            AddCommonParams(ref req);

            return req.MakeRequest<Share>();
        }

        public Task<ThreeResponses<FoursquareGroups<Share>, FoursquareList<TipList>, FoursquareList<TipList>>> GetListsSaves(string type, string id, string userId, FoursquareLocation location)
        {
            var req = new FoursquareRequest(_apiBase + "multi");
            var uid = string.IsNullOrEmpty(userId) ? "self" : userId;

            var savesRequest = new FoursquareRequest(string.Format("/users/{0}/saves", uid));
            savesRequest.AddParam("limit", "1");
            savesRequest.AddParam("offset", "0");
            savesRequest.AddParam("startAt", "0");

            var listRequest = new FoursquareRequest(string.Format("/users/{0}/lists", uid));
            listRequest.AddParam("group","created");
            listRequest.AddParam("sort", ApiUtils.GetListsSortParam(location));

            var endPoint = String.Format("/{0}/{1}/listed", ApiUtils.PluralizeType(type), id);
            var listedRequest = new FoursquareRequest(string.Format(endPoint));
            listedRequest.AddParam("group", "created");

            req.AddSubRequest(savesRequest);
            req.AddSubRequest(listRequest);
            req.AddSubRequest(listedRequest);

            AddCommonParams(ref req);
            AddLocationParams(ref req, location);
            return req.MakeRequest<FoursquareGroups<Share>, FoursquareList<TipList>, FoursquareList<TipList>>();
        }
        #endregion

        #region Tablet
        public Task<FoursquareResponse<GeoSuggestions>> GeoSuggestions(FoursquareLocation loc = null)
        {
            var req = new FoursquareRequest(_apiBase + "geo/suggestions");
            AddCommonParams(ref req);
            AddLocationParams(ref req, loc);
            return req.MakeRequest<GeoSuggestions>();
        }

        public Task<FoursquareResponse<BrowseSuggestions>> BrowseIntents(string near = null, string nearGeoId = null, FoursquareLocation location = null, FoursquareLocation currentLocation = null, FoursquareLocation ne = null, FoursquareLocation sw = null)
        {
            var req = new FoursquareRequest(_apiBase + "browse/intents");
            req.AddBrowseExploreParams(null, currentLocation, location, ne, sw, near, nearGeoId);
            AddCommonParams(ref req);
            return req.MakeRequest<BrowseSuggestions>();
        }

        public Task<FoursquareResponse<BrowseSuggestions>> BrowseTabletSuggestions(int browseGroupLimit = Constants.BROWSE_SUGGESTION_MAX_GRID_SIZE, int snippetCharLength = Constants.BROWSE_EXPLORE_SNIPPET_LENGTH, string mode = null, string intent = null, long timeInMillis = -1,
                    string near = null, string nearGeoId = null, FoursquareLocation location = null, FoursquareLocation currentLocation = null, FoursquareLocation ne = null, FoursquareLocation sw = null)
        {
            var req = new FoursquareRequest(_apiBase + "browse/tabletsuggestions");

            req.AddParam("browseGroupLimit", browseGroupLimit.ToString());
            req.AddParam("snippetCharacterLimit", snippetCharLength.ToString());
            req.AddParam("displayIntent", intent);
            if (!string.IsNullOrEmpty(mode))
            {
                req.AddParam("mode", mode);
            }
            if (timeInMillis > 0)
            {
                req.AddParam("requestTime", timeInMillis.ToString());
            }

            req.AddBrowseExploreParams(null, currentLocation, location, ne, sw, near, nearGeoId);
            AddCommonParams(ref req);
            return req.MakeRequest<BrowseSuggestions>();
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
                refRequest.AddParam("client_id", clientId);
                refRequest.AddParam("client_secret", clientSecret);
            }

            if (!refRequest.HasParam("v"))
            {
                refRequest.AddParam("v", version);
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

        private static void AddCallbackUriParams(ref FoursquareRequest refRequest, CallbackUri callback)
        {
            if (callback.args != null)
            {
                foreach (var item in callback.args)
                {
                    refRequest.AddParam(item.key, item.value);
                }
            }

            if (callback.method == "post")
            {
                refRequest.Method = FoursquareRequest.HttpMethod.POST;
            }
        }
    }
}

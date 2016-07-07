using System;
using System.Collections.Generic;

using Foursquare.Helper;
using System.Globalization;
using Foursquare.Model;

namespace Foursquare.Api
{
    internal static class ApiUtils
    {
        public static string GetLikeType(AbstractHasIdType like)
        {
            if (like is Checkin)
            {
                return Constants.TYPE_CHECKIN;
            }
            else if (like is Venue)
            {
                return Constants.TYPE_VENUE;
            }
            else if (like is Tip)
            {
                return Constants.TYPE_TIP;
            }
            return null;
        }

        public static bool IsFriend(User user)
        {
            return CheckRelationship(user, "friend");
        }

        public static bool IsFollowing(User user)
        {
            return CheckRelationship(user, "followingThem");
        }

        public static bool IsFollower(User user)
        {
            return CheckRelationship(user, "pendingMe");
        }

        private static bool CheckRelationship(User user, string relationship)
        {
            if (user == null) {
                return false;
            }
            if (relationship == user.relationship) {
                return true;
            }
            return relationship == user.followingRelationship;
        }
    
        public static bool IsFacebookFriend(User user) {
            return user != null && user.id.StartsWith("fb-");
        }
    
        public static bool IsFacebookFriend(String relationship) {
            return "facebook" == relationship;
        }

        public static string GetType(IFoursquareType type) 
        {
            if (type is Checkin)
            {
                return Constants.TYPE_CHECKIN;
            }
            else if (type is Tip)
            {
                return Constants.TYPE_TIP;
            }
            else if (type is Venue)
            {
                return Constants.TYPE_VENUE;
            }
            return null;
        }

        public static string PluralizeType(string type)
        {
            switch (type)
            {
                case Constants.TYPE_VENUE:
                    return "venues";
                case Constants.TYPE_USER:
                    return "users";
                case Constants.TYPE_ACTIVITY:
                    return "activities";
                case Constants.TYPE_CHECKIN:
                    return "checkins";
                case Constants.TYPE_SPECIAL:
                    return "specials";
                case Constants.TYPE_TIP:
                    return "tips";
                case Constants.TYPE_PAGE:
                    return "pages";
                case Constants.TYPE_PAGE_UPDATE:
                    return "pageupdates";
                case Constants.TYPE_CARDSPRING_OFFER:
                    return "offers";
                case Constants.TYPE_PLAN:
                    return "plans";
                case Constants.TYPE_PROMOTION:
                    return "promotions";
                default:
                    return null;
            }
        }

        public static void AddBrowseExploreParams(this FoursquareRequest req, SearchRecommendationFilters filters = null,
            FoursquareLocation currentLocation = null, FoursquareLocation location = null, FoursquareLocation ne = null, FoursquareLocation sw = null,
            string near = null, string nearGeoId = null)
        {
            if (filters != null)
            {
                if (!string.IsNullOrEmpty(filters.query))
                {
                    req.AddParam("query", filters.query);
                }
                if (filters.intent != null)
                {
                    req.AddParam("intent", filters.intent.id);
                }
                if (filters.subintent != null)
                {
                    req.AddParam("subintent", filters.subintent.id);
                }
                if (filters.openAt != null)
                {
                    if (filters.openAt.openNow)
                    {
                        req.AddParam("openNow", "1");
                    }
                    else if (filters.openAt.localDay >= 0 && !string.IsNullOrEmpty(filters.openAt.localTime))
                    {
                        req.AddParam("localDay", filters.openAt.localDay == 0 ? "7" : filters.openAt.localDay.ToString());
                        req.AddParam("localTime", filters.openAt.localTime);
                    }
                }
                if (filters.refinements != null && filters.refinements.Count > 0)
                {
                    var refinements = new Dictionary<string, string>();
                    for (int i = 0; i < filters.refinements.Count; i++)
                    {
                        SearchRecommendationRefinement item = filters.refinements[i];
                        if (!string.IsNullOrEmpty(item.groupType))
                        {
                            if (refinements.ContainsKey(item.groupType))
                            {
                                string val = refinements[item.groupType];
                                refinements[item.groupType] = val + "," + RefinementString(item, i);
                            }
                            else
                            {
                                refinements.Add(item.groupType, RefinementString(item, i));
                            }
                        }
                    }

                    foreach (var item in refinements.Keys)
                    {
                        req.AddParam(item, refinements[item]);
                    }
                }
            }

            if (ne == null && sw == null)
            {
                req.AddLocationParams(location);
                if (!string.IsNullOrEmpty(near))
                {
                    req.AddParam("near", near);
                    if (!string.IsNullOrEmpty(nearGeoId))
                    {
                        req.AddParam("nearGeoId", nearGeoId);
                    }
                }
            }
            else
            {
                req.AddParam("ne", LatLngFromLocation(ne));
                req.AddParam("sw", LatLngFromLocation(sw));
            }

            if (currentLocation != null)
            {
                req.AddParam("userll", LatLngFromLocation(currentLocation));
            }
        }

        private static string RefinementString(SearchRecommendationRefinement refinement, int index)
        {
            string output = string.Format("{0}-{1}", refinement.id, index);
            if (!string.IsNullOrEmpty(refinement.source)) 
            {
                output += ("-" + refinement.source);
            }
            return output;
        }


        private static void AddLocationParams(this FoursquareRequest refRequest, FoursquareLocation location)
        {
            if (location != null)
            {
                refRequest.AddParam("ll", location.Lat.ToString(CultureInfo.InvariantCulture) + "," + location.Lng.ToString(CultureInfo.InvariantCulture));
                refRequest.AddParam("llAcc", location.Accuracy.ToString());
            }
        }

        public static string LatLngFromLocation(FoursquareLocation loc)
        {
            return loc.Lat.ToString(CultureInfo.InvariantCulture) + "," + loc.Lng.ToString(CultureInfo.InvariantCulture);
        }

        public static String GetListsSortParam(FoursquareLocation loc)
        {
            return loc == null ? null : "nearby";
        }

        public static string GetOpenAtTimeParam(TimeSpan time)
        {
            return time.Hours.ToString(CultureInfo.InvariantCulture) + ":" + time.Minutes.ToString(CultureInfo.InvariantCulture);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Helper
{
    internal static class Constants
    {
        /** Governs whether check-ins are showed as "Nearby" or "Worldwide".*/
        public const int SAME_CITY_DISTANCE = 40000;

        // Type strings
        public const string TYPE_ACTIVITY = "activity";
        public const string TYPE_ACTIVITY_GROUP = "aggregation";
        public const string TYPE_BADGE = "badge";
        public const string TYPE_CELEBRITY = "celebrity";
        public const string TYPE_CHECKIN = "checkin";
        public const string TYPE_COMMENT = "comment";
        public const string TYPE_EVENT = "event";
        public const string TYPE_EXPERTISE = "expertise";
        public const string TYPE_HEADER = "header";
        public const string TYPE_FACEBOOK_SETTINGS = "facebookSettings";
        public const string TYPE_FACEPILE = "facePile";
        public const string TYPE_PHOTO_FACEPILE = "photoFacePile";
        public const string TYPE_IMAGE_PROMPT = "imagePrompt";
        public const string TYPE_IN_PROGRESS_EXP = "inProgressExpertise";
        public const string TYPE_LIST = "list";
        public const string TYPE_NAVIGATION = "navigation";
        public const string TYPE_NEWLINE = "newline";
        public const string TYPE_PAGE = "page";
        public const string TYPE_PAGE_UPDATE = "pageUpdate";
        public const string TYPE_PATH = "path";
        public const string TYPE_PHOTO = "photo";
        public const string TYPE_PLAN = "plan";
        public const string TYPE_PLANCOMPOSE = "planCompose";
        public const string TYPE_SPECIAL = "special";
        public const string TYPE_TIP = "tip";
        public const string TYPE_USER = "user";
        public const string TYPE_USER_FACEBOOK = "facebookUser";
        public const string TYPE_URL = "url";
        public const string TYPE_VENUE = "venue";
        public const string TYPE_RECOMMENDED = "rec";
        public const string TYPE_LIST_ITEM = "listItem";
        public const string TYPE_CATEGORY = "category";
        public const string TYPE_PHRASE = "phrase";
        public const string TYPE_CARDSPRING_OFFER = "cardOffer";
        public const string TYPE_OFFER = "offer";
        public const string TYPE_MENU = "menu";
        public const string TYPE_PROMOTION = "promotion";
        public const string TYPE_PENDING_CHECKIN = "pendingCheckin";
        public const string TYPE_DEFICIENCY = "deficiency";
        public const string TYPE_SHOUT = "Shout";
        public const string TYPE_TIP_TASTE_MATCH = "tip_taste_match";
        public const string TYPE_SEARCH_MATCH = "search_match";
        public const string TYPE_INBOX = "inbox";
        public const string TYPE_SECTION_TASTES = "tastes";
        public const string TYPE_TASTE = "taste";
        public const string TYPE_SHARE = "share";
        public const string TYPE_HOURS = "hours";
        public const string TYPE_KNOWN_FOR = "knownFor";
        public const string TYPE_TASTE_MENTION_COUNT = "tasteMentionCount";
        public const string TYPE_ADD_STICKER = "addSticker";
        public const string TYPE_QUERY = "query";
        public const string TYPE_MINI_VENUE = "minivenue";
        public const string TYPE_INSIGHT_TEXT_SEQ = "insightTextSeq";

        // Insights type
        public const string TYPE_BADGE_AWARD = "badgeAward";
        public const string TYPE_BECAME_MAYOR = "becameMayor";
        public const string TYPE_STOLE_MAYOR = "stoleMayor";
        public const string TYPE_MAX_STREAK = "maxStreak";
        public const string TYPE_EXTEND_STREAK = "extendStreak";
        public const string TYPE_POINTS_REWARD = "pointsReward";
        public const string TYPE_IMAGE_AD = "imageAd";
        public const string TYPE_FACEBOOK_AD = "facebookAd";
        public const string TYPE_FIRST_TIME = "firstTime";
        public const string TYPE_STICKER_UNLOCK = "stickerUnlock";
        public const string TYPE_GIVE_FEEDBACK = "giveFeedback";
        public const string TYPE_RATE_APP = "rateApp";
        public const string TYPE_INSIGHTS = "insights";
        public const string TYPE_FRIEND_MAYOR = "friendMayor";
        public const string TYPE_STICKER_MAYOR = "stickerMayor";
        public const string TYPE_MAYOR_MAYOR_HINT = "mayorMayorHint";
        public const string TYPE_STICKER_UNLOCK_HINT = "stickerUnlockHint";
        public const string TYPE_PUBLIC_MAYOR = "publicMayor";
        public const string TYPE_VENUE_STATS = "venueStats";

        public const string NAVIGATION_TYPE_PATH = "path";
        public const string NAVIGATION_TYPE_WEB_INTERNAL = "internalWeb";
        public const string NAVIGATION_TYPE_WEB_EXTERNAL = "externalWeb";

        public const string E = "e";   // employee
        public const string TT = "tt"; // trusted tester 
            
        public const string DELIVERY_SEAMLESS = "seamless";
        public const string DELIVERY_GRUBHUB = "grubhub";

        public const string TIP_BUCKET_TYPE_FOLLOWING  = "following";
        public const string TIP_BUCKET_TYPE_TASTES     = "yourTastes";

        public const string TIP_GROUP_TYPE_SAVED      = "saved";
        public const string TIP_GROUP_TYPE_FOLLOWING  = "following";
        public const string TIP_GROUP_TYPE_MERCHANT   = "merchant";
        public const string TIP_GROUP_TYPE_PROMOTED   = "promoted";
        public const string TIP_GROUP_TYPE_SELF       = "self";
        public const string TIP_GROUP_TYPE_SEARCH     = "searched";

        public const string RADAR_TYPE_FRIENDS_NEARBY = "friendsNearby";

        public const string SORT_FLAG_FRIENDS = "friends";
        public const string SORT_FLAG_NEARBY = "nearby";
        public const string SORT_FLAG_POPULAR = "popular";
        public const string SORT_FLAG_RECENT = "recent";

        public const int RECENT_VENUES_SIZE = 2;

        public const int BROWSE_EXPLORE_SNIPPET_LENGTH = 80;
        public const int BROWSE_SUGGESTION_MAX_GRID_SIZE = 12;

        public const string TIP_INSIGHT_SPECIALTY_EARNED     = "specialtyEarned";
        public const string TIP_INSIGHT_SPECIALTY_MILESTONE = "specialtyMilestone";
        public const string TIP_INSIGHT_SPECIALTY_PROGRESS = "specialtyProgress";
        public const string TIP_INSIGHT_MILESTONE = "tipMilestone";
        public const string TIP_INSIGHT_COUNT = "tipCount";
        public const string TIP_INSIGHT_STATS = "tipStats";
        public const string TIP_INSIGHT_FIRST_TIP = "firstTipAtVenue";
        public const string TIP_INSIGHT_EXPERT = "youAreAnExpert";

        public const string TASTE_INTENT_ONBOARDING = "Onboarding";
        public const string TASTE_INTENT_PROFILE_ADD = "ProfileAdd";
        public const string TASTE_INTENT_TIP_STREAM = "TipStream";

        public const string TIP_TYPE_MERCHANT_SPECIAL = "merchant_special";
        public const string TIP_TYPE_MERCHANT_TIP = "merchant_tip";
        public const string TIP_TYPE_USER = "user";

        public const string JUSTIFICATION_TYPE_EXPERTISE = "expertise";
        public const string JUSTIFICATION_TYPE_TASTE = "relatedTaste";
        public const string JUSTIFICATION_TYPE_LIKED = "liked";
        public const string JUSTIFICATION_TYPE_SAVED = "saved";

        public const string TASTE_GROUP_TYPE_RECENT = "recentTastes";
        public const string TASTE_GROUP_TYPE_ALL = "allTastes";
        public const string TASTE_GROUP_TYPE_COMMON = "commonTastes";

        public const string OPINIONATOR_SUMMARY_TYPE_FOLLOW = "followSuggestions";
        public const string OPINIONATOR_SUMMARY_TYPE_VENUE_SAVE = "venueSaveSuggestions";
        public const string OPINIONATOR_SUMMARY_TYPE_TASTE_SUGGESTIONS = "tasteSuggestions";
        public const string OPINIONATOR_SUMMARY_TYPE_NONE = "none";

        public const string OPINIONATOR_MODULE_TYPE_LIKE = "like";
        public const string OPINIONATOR_MODULE_TYPE_ATTR = "attr";
        public const string OPINIONATOR_MODULE_TYPE_TASTES = "tastes";
        public const string OPINIONATOR_MODULE_TYPE_PHOTO = "photoRanker";

        public const string OPINIONATOR_ICON_FAMILY_HEARTS = "hearts";
        public const string OPINIONATOR_ICON_FAMILY_THUMBS = "thumbs";
        public const string OPINIONATOR_ICON_FAMILY_NONE = "none";

        public const string SHARE_STATE_SAVED = "saved";

        public const string DISPLAY_TYPE_STANDARD = "standard";
        public const string DISPLAY_TYPE_SUBJECTIVE = "subjective";

        public static int MAX_DRIVING_TIME_IN_MIN = 120;
        public static int MAX_WALKING_DISTANCE_IN_METER = 800;

        public static string USER_FLAG_SPAM = "spam";
        public static string USER_FLAG_OFFENSIVE = "offensive";
        public static string USER_FLAG_BAD_EXPERT = "bad_expert";

        public static string MENU_TYPE_CATALOG = "catalog";
        public static string MENU_TYPE_MENU = "menu";
        public static string MENU_TYPE_PRODUCTS = "products";
        public static string MENU_TYPE_SERVICES = "services";

        public static char PARTICIPANTS_DELIMITER = ',';

        public static int STATUS_SEND_ERROR = -1;
        public static int STATUS_SENT = 0;
        public static int STATUS_SENDING = 1;

        public enum TasteInteractionState
        {
            LIKE = 1
        }
    }
}

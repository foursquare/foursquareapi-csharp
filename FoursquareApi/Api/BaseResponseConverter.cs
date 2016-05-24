using System;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Foursquare.Model;

namespace Foursquare.Api
{
    internal abstract class BaseResponseConverter : JsonConverter
    {
        protected FoursquareResponse<T> ParseResponse<T>(JToken jObject) where T : IFoursquareBase
        {
            FoursquareResponse<T> output = new FoursquareResponse<T>();

            if (jObject["meta"] != null)
            {
                output.meta = jObject["meta"].ToObject<Meta>();
            }

            if (jObject["notifications"] != null)
            {
                output.notifications = jObject["notifications"].ToObject<List<Notifications>>();
            }

            JToken response = jObject["response"];
            if (response != null)
            {
                if (response.Count() > 1)
                {
                    output.response = response.ToObject<T>();
                }
                else if (response.Count() == 1)
                {
                    JToken firstKey = response.Children().First().First();
                    if (!TypeRequiresFullParsing(typeof(T)) && firstKey.Type == JTokenType.Object)
                    {
                        output.response = firstKey.ToObject<T>();
                    }
                    else
                    {
                        output.response = response.ToObject<T>();
                    }
                }
            }

            if (typeof(T) == typeof(AccessToken))
            {
                output.response = jObject.ToObject<T>();
            }

            return output;
        }

        public static bool TypeRequiresFullParsing(Type t)
        {
            if (t == typeof(VenueTipsResponse) 
                || t == typeof(AddTip) 
                || t == typeof(AddVenue) 
                || t == typeof(PlanDetailsResponse)
                || t == typeof(CommentWithVenues)
                || t == typeof(PhoneSetResponse)
                || t == typeof(ActivitiesRecentResponse)
                || t == typeof(ScoreboardResponse)
                || t == typeof(MayorshipResponse)
                || t == typeof(CheckinDetailResponse))
            {
                return true;
            }
            return false;
        }
    }
}

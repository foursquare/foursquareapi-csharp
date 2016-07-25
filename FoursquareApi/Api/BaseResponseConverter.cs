using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Foursquare.Model;
using Foursquare.Response;

namespace Foursquare.Api
{
    internal abstract class BaseResponseConverter : JsonConverter
    {
        protected FoursquareResponse<T> ParseResponse<T>(JToken root) where T : IFoursquareType
        {
            FoursquareResponse<T> output = new FoursquareResponse<T>();

            if (root["meta"] != null)
            {
                output.meta = root["meta"].ToObject<Meta>();
            }

            if (root["notifications"] != null)
            {
                output.notifications = root["notifications"].ToObject<List<Notifications>>();
            }

            JToken response = root["response"];
            if (response != null)
            {
                output.response = response.ToObject<T>();
            }

            if (root["access_token"] != null)
            {
                output.response = root.ToObject<T>();
            }

            return output;
        }
    }
}

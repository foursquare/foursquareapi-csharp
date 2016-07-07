using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Foursquare.Model;
using Foursquare.Response;

namespace Foursquare.Api
{
    internal abstract class BaseResponseConverter : JsonConverter
    {
        protected FoursquareResponse<T> ParseResponse<T>(JToken jObject) where T : IFoursquareType
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
                output.response = response.ToObject<T>();
            }

            return output;
        }
    }
}

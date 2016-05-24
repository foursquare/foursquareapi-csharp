using System;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Foursquare.Model;

namespace Foursquare.Api
{
    internal class FoursquareThreeResponseConverter<T, V, C> : BaseResponseConverter
        where T : IFoursquareBase
        where V : IFoursquareBase
        where C : IFoursquareBase
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            ThreeResponses<T, V, C> output = (ThreeResponses<T, V, C>)Activator.CreateInstance(objectType);

            JObject jObject = JObject.Load(reader);
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
                if (response["responses"] != null)
                {
                    var responses = response["responses"].Children().ToList();
                    if (responses.Count > 0)
                    {
                        output.SubResponse1 = ParseResponse<T>(responses.ElementAt(0));
                    }
                    if (responses.Count > 1)
                    {
                        output.SubResponse2 = ParseResponse<V>(responses.ElementAt(1));
                    }
                    if (responses.Count > 2)
                    {
                        output.SubResponse3 = ParseResponse<C>(responses.ElementAt(2));
                    }
                }
            }

            return output;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}

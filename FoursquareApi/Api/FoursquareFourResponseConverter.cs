using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Foursquare.Model;
using Foursquare.Response;

namespace Foursquare.Api
{
    internal class FoursquareFourResponseConverter<T, V, C, D> : BaseResponseConverter
        where T : IFoursquareType
        where V : IFoursquareType
        where C : IFoursquareType
        where D : IFoursquareType
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            FourResponses<T, V, C, D> output = (FourResponses<T, V, C, D>)Activator.CreateInstance(objectType);

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
                    if (responses.Count > 3)
                    {
                        output.SubResponse4 = ParseResponse<D>(responses.ElementAt(3));
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

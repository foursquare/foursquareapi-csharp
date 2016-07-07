using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Foursquare.Model;

namespace Foursquare.Api
{
    internal class FoursquareResponseConverter<T> : BaseResponseConverter where T : IFoursquareType
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);

            return ParseResponse<T>(jObject);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}

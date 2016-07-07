using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Foursquare.Model;

namespace Foursquare.Api
{
    internal class NotificationConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            string type = jObject["type"].ToString();

            Notification n = new Notification();
            serializer.Populate(jObject.CreateReader(), n);
            return n;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}

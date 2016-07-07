using System;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Foursquare.Model;
using Foursquare.Helper;

namespace Foursquare.Api
{
    internal class UnifiedSuggestionConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            var sugg = new UnifiedSuggestion
            {
                type = jObject["type"].ToString(),
                id = jObject["id"].ToString(),
                text = jObject["text"].ToString()
            };
            try
            {
                var ents = new List<Entity>();
                serializer.Populate(jObject["entities"].CreateReader(), ents);
                sugg.entities = ents;
            }
            catch (Exception)
            {
                // We dont care
            }

            switch (sugg.type)
            {
                case Constants.TYPE_QUERY:
                    sugg.suggestion = jObject["object"].ToObject<Suggestion>();
                    break;
                case Constants.TYPE_MINI_VENUE:
                    sugg.venue = jObject["object"].ToObject<Venue>();
                    break;
                default:
                    break;
            }
            return sugg;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var target = value as UnifiedSuggestion;

            if (target == null)
            {
                return;
            }

            writer.WriteStartObject();
            writer.WritePropertyName("type");
            serializer.Serialize(writer, target.type);
            writer.WritePropertyName("id");
            serializer.Serialize(writer, target.id);
            writer.WritePropertyName("text");
            serializer.Serialize(writer, target.text);
            if (target.entities != null)
            {
                writer.WritePropertyName("entities");
                serializer.Serialize(writer, target.entities);
            }
            writer.WritePropertyName("object");
            switch (target.type)
            {
                case Constants.TYPE_QUERY:
                    serializer.Serialize(writer, target.suggestion, typeof(Suggestion));
                    break;
                case Constants.TYPE_MINI_VENUE:
                    serializer.Serialize(writer, target.venue, typeof(Venue));
                    break;
                default:
                    break;
            }
            writer.WriteEndObject();
        }
    }
}

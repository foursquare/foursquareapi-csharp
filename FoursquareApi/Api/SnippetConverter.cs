using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Foursquare.Model;
using Foursquare.Helper;

namespace Foursquare.Api
{
    internal class SnippetConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            var target = new SnippetDetail
            {
                type = jObject["type"].ToString()
            };

            switch (target.type)
            {
                case Constants.TYPE_FACEPILE:
                case Constants.TYPE_PHOTO_FACEPILE:
                    if (jObject.GetValue("object") != null) { 
                        target.facePile = jObject["object"].ToObject<FoursquareList<FacePile>>();
                    }
                    break;
                case Constants.TYPE_TIP:
                    target.tip = jObject["object"].ToObject<Tip>();
                    break;
                case Constants.TYPE_TASTE: 
                    target.taste = jObject["object"].ToObject<FoursquareList<Taste>>();
                    break;
                case Constants.TYPE_KNOWN_FOR:
                    target.knownFor = jObject["object"].ToObject<TextEntities>();
                    break;
                case Constants.TYPE_TASTE_MENTION_COUNT:
                    target.tasteMentionCount = jObject["object"].ToObject<TextEntities>();
                    break;
                case Constants.TYPE_MENU:
                    target.menu = jObject["object"].ToObject<SnippetMenu>();
                    break;
                case Constants.TYPE_HOURS:
                    target.hours = jObject["object"].ToObject<SnippetHours>();
                    break;
                case Constants.TYPE_INSIGHT_TEXT_SEQ:
                    target.insights = jObject["object"].ToObject<FoursquareList<TextEntitiesAndIcon>>();
                    break;
                default:
                    break;
            }
            return target;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}

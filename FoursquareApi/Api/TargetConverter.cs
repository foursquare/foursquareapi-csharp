using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Foursquare.Model;
using Foursquare.Helper;

namespace Foursquare.Api
{
    internal class TargetConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            var target = new Target();
            target.Type = jObject["type"].ToString();

            switch (target.Type)
            {
                case Constants.TYPE_CHECKIN:
                    target.Object = jObject["object"].ToObject<Checkin>();
                    break;
                case Constants.TYPE_TIP:
                    target.Object = jObject["object"].ToObject<Tip>();
                    break;
                case Constants.TYPE_USER:
                case Constants.TYPE_CELEBRITY:
                    target.Object = jObject["object"].ToObject<User>();
                    break;
                case Constants.TYPE_PAGE:
                    target.Object = jObject["object"].ToObject<Page>();
                    break;
                case Constants.TYPE_VENUE:
                    target.Object = jObject["object"].ToObject<Venue>();
                    break;
                case Constants.TYPE_PAGE_UPDATE:
                    target.Object = jObject["object"].ToObject<VenueUpdate>();
                    break;
                case Constants.TYPE_EVENT:
                    target.Object = jObject["object"].ToObject<Foursquare.Model.Event>();
                    break;
                case Constants.TYPE_BADGE:
                    break;
                case Constants.TYPE_ACTIVITY:
                    break;
                case Constants.TYPE_PHOTO:
                    target.Object = jObject["object"].ToObject<Photo>();
                    break;
                case Constants.TYPE_NAVIGATION:
                    target.Object = jObject["object"].ToObject<Navigation>();
                    break;
                case Constants.TYPE_URL:
                case Constants.TYPE_PATH:
                    target.Object = jObject["object"].ToObject<Url>();
                    break;
                case Constants.TYPE_PENDING_CHECKIN:
                    target.Object = jObject["object"].ToObject<PendingCheckin>();
                    break;
                case Constants.TYPE_CARDSPRING_OFFER:
                case Constants.TYPE_OFFER:
                    break;
                case Constants.TYPE_MENU:
                    break;
                case Constants.TYPE_TASTE:
                    target.Object = jObject["object"].ToObject<Taste>();
                    break;
                case Constants.TYPE_INBOX:
                    target.Object = jObject["object"].ToObject<Share>();
                    break;
                default:
                    break;
            }
            return target;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var target = value as Target;

            writer.WriteStartObject();
            writer.WritePropertyName("type");
            serializer.Serialize(writer, target.Type);
            writer.WritePropertyName("object");
            switch (target.Type)
            {
                case Constants.TYPE_CHECKIN:
                    serializer.Serialize(writer, target.Object, typeof(Checkin));
                    break;
                case Constants.TYPE_TIP:
                    serializer.Serialize(writer, target.Object, typeof(Tip));
                    break;
                case Constants.TYPE_USER:
                case Constants.TYPE_CELEBRITY:
                    serializer.Serialize(writer, target.Object, typeof(User));
                    break;
                case Constants.TYPE_PAGE:
                    serializer.Serialize(writer, target.Object, typeof(Page));
                    break;
                case Constants.TYPE_VENUE:
                    serializer.Serialize(writer, target.Object, typeof(Venue));
                    break;
                case Constants.TYPE_PAGE_UPDATE:
                    serializer.Serialize(writer, target.Object, typeof(VenueUpdate));
                    break;
                case Constants.TYPE_EVENT:
                    serializer.Serialize(writer, target.Object, typeof(Foursquare.Model.Event));
                    break;
                case Constants.TYPE_ACTIVITY:
                    break;
                case Constants.TYPE_PHOTO:
                    serializer.Serialize(writer, target.Object, typeof(Photo));
                    break;
                case Constants.TYPE_NAVIGATION:
                    serializer.Serialize(writer, target.Object, typeof(Navigation));
                    break;
                case Constants.TYPE_URL:
                case Constants.TYPE_PATH:
                    serializer.Serialize(writer, target.Object, typeof(Url));
                    break;
                case Constants.TYPE_PENDING_CHECKIN:
                    serializer.Serialize(writer, target.Object, typeof(PendingCheckin));
                    break;
                case Constants.TYPE_CARDSPRING_OFFER:
                case Constants.TYPE_OFFER:
                    break;
                case Constants.TYPE_MENU:
                    break;
                case Constants.TYPE_TASTE:
                    serializer.Serialize(writer, target.Object, typeof(Taste));
                    break;
                case Constants.TYPE_INBOX:
                    serializer.Serialize(writer, target.Object, typeof(Share));
                    break;
                default:
                    break;
            }
            writer.WriteEndObject();
        }
    }
}

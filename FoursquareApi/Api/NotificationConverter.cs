using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Foursquare.Model;
using Foursquare.Helper;

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
            Notification notif = null;
            string type = jObject["type"].ToString();

            switch (type)
            {
                case Constants.TYPE_INSIGHTS:
                    InsightNotification insight = new InsightNotification();
                    serializer.Populate(jObject.CreateReader(), insight);
                    notif = insight;
                    break;
                case Constants.TYPE_RATE_APP:
                    RateAppNotification rateapp = new RateAppNotification();
                    serializer.Populate(jObject.CreateReader(), rateapp);
                    notif = rateapp;
                    break;
                default:
                    Notification n = new Notification();
                    serializer.Populate(jObject.CreateReader(), n);
                    notif = n;
                    break;
            }
            return notif;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}

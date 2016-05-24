using System;
using System.Linq;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Foursquare.Model;

namespace Foursquare.Api
{
    internal class AutoCompleteConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            AutoComplete autoComplete = new AutoComplete();
            if (jObject["groups"] != null) {
                foreach (var item in jObject["groups"].Children().ToList())
                {
                    var type = item["type"].ToString();
                    switch (type)
                    {
                        case "categories":
                            autoComplete.categories = new FoursquareList<Category>();
                            serializer.Populate(item.CreateReader(), autoComplete.categories);
                            break;
                        case "venues":
                            autoComplete.venues = new FoursquareList<Venue>();
                            serializer.Populate(item.CreateReader(), autoComplete.venues);
                            break;
                        case "friends":
                            autoComplete.friends = new FoursquareList<User>();
                            serializer.Populate(item.CreateReader(), autoComplete.friends);
                            break;
                        case "queries":
                            autoComplete.queries = new FoursquareList<Suggestion>();
                            serializer.Populate(item.CreateReader(), autoComplete.queries);
                            break;
                        case "structured":
                            autoComplete.structuredQueries = new FoursquareList<Suggestion>();
                            serializer.Populate(item.CreateReader(), autoComplete.structuredQueries);
                            break;
                        case "unified":
                            autoComplete.unified = new FoursquareList<UnifiedSuggestion>();
                            serializer.Populate(item.CreateReader(), autoComplete.unified);
                            break;
                    }
                }
            }
            else if (jObject["queries"] != null)
            {
                var list = jObject["queries"];
                autoComplete.queries = new FoursquareList<Suggestion>();
                serializer.Populate(list.CreateReader(), autoComplete.queries.items);
            }

            return autoComplete;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}

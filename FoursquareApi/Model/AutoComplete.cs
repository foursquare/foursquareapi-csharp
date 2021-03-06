﻿using Newtonsoft.Json;
using Foursquare.Api;

namespace Foursquare.Model
{
    [JsonConverter(typeof(AutoCompleteConverter))]
    public class AutoComplete : IFoursquareType
    {
        public FoursquareList<Category> categories { get; set;}
        public FoursquareList<Venue> venues { get; set; }
        public FoursquareList<User> friends { get; set; }
        public FoursquareList<Suggestion> queries { get; set; }
        public FoursquareList<Suggestion> structuredQueries { get; set; }
        public FoursquareList<UnifiedSuggestion> unified { get; set; }
        public string version { get; set; }
    }
}

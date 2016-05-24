using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Foursquare.Model
{
    public class TipList : IFoursquareBase
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public User user { get; set; }
        [JsonProperty("public")]
        public bool isPublic { get; set; }
        public bool editable { get; set; }
        public bool collaborative { get; set; }
        public string url { get; set; }
        public string type { get; set; }
        public Photo photo { get; set; }
        public long createdAt { get; set; }
        public long updatedAt { get; set; }
        public int doneCount { get; set; }
        public int visitedCount { get; set; }
        public int venueCount { get; set; }
        public FoursquareList<Share> listItems { get; set; }
        public FoursquareList<User> followers { get; set; }
        public FoursquareList<User> collaborators { get; set; }
        public FoursquareList<User> saves { get; set; }
        public FoursquareList<Category> categories { get; set; } 
    }
}

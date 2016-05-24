using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class Event : IFoursquareBase
    {
        public bool allDay { get; set; }
        public long startAt { get; set; }
        public long endAt { get; set; }
        public FoursquareGroups<Checkin> hereNow { get; set; }
        public string id { get; set; }
        public List<string> images { get; set; }
        public string name { get; set; }
        public string summary { get; set; }
        public string text { get; set; }
        public string url { get; set; }
        public string genres { get; set; }
        public string rating { get; set; }
        public string runningTime { get; set; }
        public Venue venue { get; set; }
        public EventProvider provider { get; set; }
        public List<Category> categories { get; set; }

        public sealed class EventProvider : IFoursquareBase
        {
            public Image iconUrl { get; set; }
            public string name { get; set; }
            public string urlText { get; set; }
        }
    }
}

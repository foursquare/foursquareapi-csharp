using System.Collections.Generic;

namespace Foursquare.Model
{
    public sealed class CallbackUri : IFoursquareType
    {
        public string url { get; set; }
        public string method { get; set; }
        public List<Argument> args { get; set; }

        public sealed class Argument : IFoursquareType
        {
            public string key { get; set; }
            public string value { get; set; }
        }
    }
}

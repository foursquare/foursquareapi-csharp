namespace Foursquare.Model
{
    public class RateAppNotification : Notification
    {
        public Item item { get; set; }

        public sealed class Item : IFoursquareType
        {
            public string promptText { get; set; }
            public bool overrideMute { get; set; }
        }
    }
}

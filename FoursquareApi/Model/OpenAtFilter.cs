namespace Foursquare.Model
{
    public sealed class OpenAtFilter : IFoursquareType
    {
        public bool openNow { get; set; }
        public int localDay { get; set; }
        public string localTime { get; set; }
        public bool IsDefault()
        {
            return !openNow && localDay == -1 && string.IsNullOrEmpty(localTime);
        }
    }
}

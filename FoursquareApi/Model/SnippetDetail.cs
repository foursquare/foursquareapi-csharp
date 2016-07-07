using Newtonsoft.Json;
using Foursquare.Api;

namespace Foursquare.Model
{
    [JsonConverter(typeof(SnippetConverter))]
    public class SnippetDetail : IFoursquareType
    {
        public string type { get; set; }
        public FoursquareList<FacePile> facePile { get; set; }
        public Tip tip { get; set; }
        public FoursquareList<Taste> taste { get; set; }
        public TextEntities knownFor { get; set; }
        public TextEntities tasteMentionCount { get; set; }
        public SnippetMenu menu { get; set; }
        public SnippetHours hours { get; set; }
        public FoursquareList<TextEntitiesAndIcon> insights { get; set; }
    }
}

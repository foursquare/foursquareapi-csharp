namespace Foursquare.Model
{
    public class SpellCorrection : IFoursquareType
    {
        public SpellSuggestion suggestion { get; set; }
        public SpellSuggestion correction { get; set; }
        public SpellSuggestion escapeHatch { get; set; }
    }
}

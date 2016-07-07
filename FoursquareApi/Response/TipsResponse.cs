using Foursquare.Model;
using System.Collections.Generic;

namespace Foursquare.Response
{
    public sealed class TipsResponse : IFoursquareType
    {
        public FoursquareList<Tip> tips { get; set; }
        public List<VenueTasteJustification> justifications { get; set; }
    }
}

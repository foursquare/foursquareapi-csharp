using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Foursquare.Model;

namespace Foursquare.Model
{
    public sealed class BrowseExploreResult : IFoursquareBase
    {
        public List<BrowseExploreSection> suggestions { get; set; }
        public BrowseExploreIntent intent { get; set; }
        public TextEntities recommendedTastes { get; set; }
        public BrowseSuggestionsLocations.BrowseSuggestionsGeoBounds geoBounds { get; set; }
    }
}

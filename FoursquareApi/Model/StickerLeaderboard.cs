using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class StickerLeaderboard : IFoursquareBase
    {
        public List<UserVisits> crownSummary { get; set; }
        public String text { get; set; }
        public Sticker sticker { get; set; }
    }
}

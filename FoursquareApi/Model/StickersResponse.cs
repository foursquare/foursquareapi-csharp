using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class StickersResponse : IFoursquareBase
    {
        public string checksum { get; set; }
        public List<Sticker> stickers { get; set; }
        public List<string> plansCarousel { get; set; }
        public int totalCollectible { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class Expertise: IFoursquareBase
    {
        public string type { get; set; }
        public string summary { get; set; }
        public string displayName { get; set; }
        public string summaryName { get; set; }
        public string subjectId { get; set; }
        public int score { get; set; }
        public int delta { get; set; }
        public int targetScore { get; set; }
        public int level { get; set; }
        public int tipCount { get; set; }
        public int tipLikeCount { get; set; }
        public int tipSaveCount { get; set; }
        public string backgroundColor { get; set; }
        public string levelChange { get; set; }
        public Image displayIcon { get; set; }
        public Image summaryIcon { get; set; }
        public Taste taste { get; set; }

        public int progress
        {
            get
            {
                return (score * 100) / targetScore;
            }
        }

        public bool earned
        {
            get { return level > 0; }
        }

    }
}

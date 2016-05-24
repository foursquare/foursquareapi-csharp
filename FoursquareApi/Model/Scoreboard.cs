using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public sealed class Scoreboard : IFoursquareBase
    {
        public List<ScoreEntry> scores { get; set; }
        public int userIndex { get; set; }
        public string userRank { get; set; }
        public string bodyCopy { get; set; }
        public string state { get; set; }
        public long endDate { get; set; }
        public long payoutDate { get; set; }
        public int payoutSpots { get; set; }
        public string payoutCopy { get; set; }
        public bool showLastWeekLink { get; set; }
        public int payoutAmount { get; set; }
        public ShareText shareText { get; set; }

        public ScoreEntry UserScore
        {
            get
            {
                if (scores != null && userIndex < scores.Count)
                {
                    return scores[userIndex];
                }
                return null;
            }
        }

        public sealed class ScoreEntry : IFoursquareBase
        {
            public User user { get; set; }
            public int score { get; set; }
            public int ranking { get; set; }
        }

        public sealed class ShareText : IFoursquareBase
        {
            public string fb { get; set; }
            public string tw { get; set; }
            public string other { get; set; }
        }
    }
}

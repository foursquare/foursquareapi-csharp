using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public sealed class ScoreboardResponse : IFoursquareBase
    {
        public Scoreboard currentWeek { get; set; }
        public Scoreboard previousWeek { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class ExpertiseChange: IFoursquareBase
    {
        public int delta { get; set; }

        public string levelChange { get; set; }

        public bool LevelEarned()
        {
            return (levelChange != null &&
                    levelChange == "levelEarned");
        }
    }
}

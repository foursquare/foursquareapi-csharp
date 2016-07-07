using System.Collections.Generic;
using System.Linq;

namespace Foursquare.Model
{
    public class FoursquareGroups<T> : IFoursquareType where T : IFoursquareType
    {
        public int count { get; set; }
        public string summary { get; set; }
        public List<FoursquareList<T>> groups { get; set; }

        public bool IsEmpty() 
        {
            return count == 0 ||
                   groups == null ||
                   !groups.SelectMany(s => s.items).Any(); 
        }
    }
}

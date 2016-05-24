using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class FoursquareGroups<T> : IFoursquareBase where T : IFoursquareBase
    {
        public Int32 count { get; set; }
        public string summary { get; set; }
        public List<FoursquareList<T>> groups { get; set; }

        public bool IsEmpty() 
        {
            return count == 0 ||
                   groups == null ||
                   groups.SelectMany(s => s.items).Count() == 0; 
        }
    }
}

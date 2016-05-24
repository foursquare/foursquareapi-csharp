using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class FoursquareList<T> : IFoursquareBase where T : IFoursquareBase
    {
        public FoursquareList()
        {
            items = new List<T>();
        }

        public FoursquareList(List<T> foursquareList)
        {
            this.items = foursquareList;
        }

        public string name { get; set; }
        public string summary { get; set; }
        public string type { get; set; }
        public Int32 count { get; set; }
        public List<T> items { get; set; }
        public bool IsEmpty()
        {
            return items == null || items.Count == 0;
        }
    }
}

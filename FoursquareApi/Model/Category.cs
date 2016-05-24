using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public sealed class Category : IFoursquareBase
    {
        public string id { get; set; }
        public string name { get; set; }
        public string pluralName { get; set; }
        public string shortName { get; set; }
        public bool primary { get; set; }
        public Photo icon { get; set; }
        public List<Category> categories { get; set; }

        public override bool Equals(object obj)
        {
            var cat = obj as Category;
            if (cat == null)
            {
                return false;
            }
            return cat.id.Equals(this.id);
        }

        public override int GetHashCode()
        {
            return this.id.GetHashCode();
        }

        public bool Equals(Category obj)
        {
            if (obj == null)
            {
                return false;
            }
            return this.id.Equals((obj as Category).id);
        }
    }
}

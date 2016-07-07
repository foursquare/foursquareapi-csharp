using System.Collections.Generic;

namespace Foursquare.Model
{
    public sealed class Category : IFoursquareType
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
            return cat != null && cat.id.Equals(id);
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

        public bool Equals(Category obj)
        {
            return obj != null && id.Equals(obj.id);
        }
    }
}

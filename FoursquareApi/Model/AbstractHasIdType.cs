namespace Foursquare.Model
{
    public abstract class AbstractHasIdType : IFoursquareType
    {
        public virtual string id { get; set; }
    }
}

using Foursquare.Model;

namespace Foursquare.Response
{
    public sealed class UserResponse : IFoursquareType
    {
        public User user { get; set; }
    }
}

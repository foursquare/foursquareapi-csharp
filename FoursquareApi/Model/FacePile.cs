namespace Foursquare.Model
{
    public sealed class FacePile : IFoursquareType
    {
        public string id { get; set; }
        public string interactionType { get; set; }
        public User user { get; set; }
        public Photo photo { get; set; }

        public Photo GetPhoto()
        {
            return user == null ? photo : user.photo;
        }
    }
}

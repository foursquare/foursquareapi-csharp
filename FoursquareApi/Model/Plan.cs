using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class Plan : IFoursquareBase
    {
        private const string MUTED = "muted";
        private const string UNMUTED = "unmuted";

        public string id { get; set; }
        public long createdAt { get; set; }
        public bool isBroadcast { get; set; }
        public string text { get; set; }
        public List<Entity> entities { get; set; }
        public User user { get; set; }
        public FoursquareList<UserInterestedEvent> interested { get; set; }
        public bool isUnread { get; set; }
        public bool isGroup { get; set; }
        public string muteState { get; set; }
        public List<User> participants { get; set; }
        public List<OffNetworkUser> offNetworkParticipants { get; set; }
        public FoursquareList<Comment> comments { get; set; }
        public TextEntities readReceipt { get; set; }
        public string readMarker { get; set; }
        public List<Venue> venues { get; set; }
        public bool isFake { get; set; }
        public bool isMuted
        {
            get { return muteState == MUTED; }
            set { muteState = value ? MUTED : null; }
        }

        public sealed class UserInterestedEvent : IFoursquareBase
        {
            public User user { get; set; }
            public long createdAt { get; set; }
        }
    }
}

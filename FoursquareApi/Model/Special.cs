using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class Special : IFoursquareBase
    {
        public string description { get; set; }
        public string detail { get; set; }
        public string finePrint { get; set; }
        public FoursquareList<User> friendsHere { get; set; } // only used when type: friends
        public string icon { get; set; }
        public Photo iconUrl { get; set; }
        public Interaction interaction { get; set; } // only used for amex and cardspring deals right now
        public string message { get; set; }
        public int progress { get; set; } // only used when type: fcfs, swarm, friends
        public string progressDescription { get; set; }
        public string provider { get; set; }
        public string redemption { get; set; }
        public string state { get; set; } // only used when type:  fcfs, swarm, friends
        public int target { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public bool unlocked { get; set; }
        public Venue venue { get; set; }
        //public Mute mute { get; set; }
        public string text { get; set; }
        public User page { get; set; }
        public string name { get; set; }
        //public Campaigns campaigns { get; set; }
        public Photo photo { get; set; } // Used to display the right photo in explore

        public sealed class Interaction : IFoursquareBase
        {
            public string entryUrl { get; set; }
            public string exitUrl { get; set; }
            public string explanation { get; set; }
            public string input { get; set; }
            public string prompt { get; set; }
            public string purchaseUrl { get; set; }
            public string timeoutExplanation { get; set; }
            public string timeoutPrompt { get; set; }
            public string waitingPrompt { get; set; }
            public CardSpringOffer offer { get; set; }
        }

        public sealed class Campaigns : IFoursquareBase
        {
            public List<Campaign> active { get; set; }
            public List<Campaign> finished { get; set; }
        }
    }
}

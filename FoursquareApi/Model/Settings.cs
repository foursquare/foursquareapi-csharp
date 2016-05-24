using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public sealed class Settings : IFoursquareBase
    {
        // Disable Explore
        public bool disableRex { get; set; }

        // Pilgrim
        public bool receivePings { get; set; }
        public bool receiveCityPings { get; set; }
        public bool eligibleForRadarSplash { get; set; }
        public bool alreadySeenRadarSplash { get; set; }
        public string receiveCheckinPings { get; set; }
        public string arrivalNotifications { get; set; }
        public bool hideArrivalNotifications { get; set; }
        public bool allowBackgroundLocation { get; set; }

        // Facebook
        public string facebook { get; set; }
        public bool sendToFacebook { get; set; }
        public bool facebookTimeline { get; set; }
        public bool facebookLinked { get; set; }
        public List<string> facebookPermissions { get; set; }

        // Twitter
        public string twitter { get; set; }
        public bool sendToTwitter { get; set; }
        public bool sendBadgesToTwitter { get; set; }
        public bool sendMayorshipsToTwitter { get; set; }

        // Instagram
        public string instagram { get; set; }

        public List<string> roles { get; set; }
        public List<string> features { get; set; }
        public List<string> experiments { get; set; }
        //public Group<ExperimentComplex> experimentsComplex;
        public bool canBeCheckedInByFriends { get; set; }
        //public LocationSettings locationSettings;
        public bool allowOff4sqAds { get; set; }
        public bool wifiScanOnCheckinsAdd { get; set; }
        public bool wifiScanOnVenuesSearch { get; set; }
        public bool sharePassiveLocationWithFriends { get; set; }
        public bool completedBatmanOnboarding { get; set; }
        public bool showSwarmButtons { get; set; }
        public bool hasInstalledSwarm { get; set; }

        public sealed class LocationSettings : IFoursquareBase
        {
            public bool showPriceFilter { get; set; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class Sticker : IFoursquareBase
    {
        public string id { get; set; }
        public string name { get; set; }
        public Image image { get; set; }
        public string longName { get; set; }
        public List<Effect> effects { get; set; }
        public bool restricted { get; set; }
        public bool locked { get; set; }
        public string teaseText { get; set; }
        public string unlockText { get; set; }
        public bool hasLeaderboard { get; set; }
        public string stickerType { get; set; }
        public StickerGroup group { get; set; }
        public StickerProgress progress { get; set; }

        // Transient property
        public bool IsPlaceholder { get; set; }
        public bool IsLockedOrPlaceholder
        {
            get
            {
                return IsPlaceholder || locked;
            }
        }

        public string OriginalImageUrl() 
        {
            if (image != null)
            {
                return image.prefix + "original" + image.name;
            }
            return null;
        }

        public sealed class Effect : IFoursquareBase
        {
            public string type { get; set; }
            public Image detail { get; set; }
        }

        public sealed class PickerPosition : IFoursquareBase
        {
            public int page { get; set; }
            public int index { get; set; }
        }

        public sealed class StickerGroup : IFoursquareBase
        {
            public const string GROUP_COLLECTIBLE = "collectible";
            public const string GROUP_SPECIAL = "special";
            public const string GROUP_MESSAGING = "messaging";

            public string name { get; set; }
            public int index { get; set; }

            public override bool Equals(object obj)
            {
                if (obj is StickerGroup)
                {
                    return name == (obj as StickerGroup).name;
                }
                return false;
            }

            public override int GetHashCode()
            {
                return name.GetHashCode();
            }
        }

        public sealed class StickerProgress : IFoursquareBase
        {
            public int percentComplete { get; set; }
            public int checkinsRequired { get; set; }
            public int checkinsEarned { get; set; }
            public string progressText { get; set; }
        }
    }
}

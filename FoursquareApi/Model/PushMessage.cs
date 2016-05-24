using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public sealed class PushMessage : IFoursquareBase
    {
        public string iuid { get; set; }
        public string tt { get; set; }
        public string vid { get; set; }
        public string tipid { get; set; }
        public string uid { get; set; }
        public string hl { get; set; }
        public string url { get; set; }
        public string intent { get; set; }
        public string bz { get; set; }
        public string unc { get; set; }
        public string tid { get; set; }
        public string pulse { get; set; }
        public string rfid { get; set; }
        public string t { get; set; }
        public string grp { get; set; }
        public string m { get; set; }
        public string m2 { get; set; }
        public string settingId { get; set; }
        public string icon { get; set; }
        public string action { get; set; }
        public string fs { get; set; }
        public string thmPre { get; set; }
        public string thmSfx { get; set; }
        public string phoPre { get; set; }
        public string phoSfx { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare.Model
{
    public class ExpertiseSection: IFoursquareBase
    {
        private const string ExpertiseEarned = "earned";
        private const string ExpertiseInProgress = "progress";
        private const string ExpertiseRecent = "recent";

        public string name { get; set; }
        public string status { get; set; }

        public List<Expertise> expertise { get; set; }

        public bool IsEarned() {
	    	return (status != null && status == ExpertiseEarned);
	    }

	    public bool IsInProgress() {
	    	return (status != null && status == ExpertiseInProgress);
	    }

	    public bool IsRecent() {
	    	return (status != null && status == ExpertiseRecent);
	    }
    }
}

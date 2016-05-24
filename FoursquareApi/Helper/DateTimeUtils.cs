using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foursquare.Helper
{
    internal static class DateTimeUtils
    {
        private static DateTime EpochDT = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private static DateTimeOffset EpochDTO = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);

        public static long CurrentTimeMillis()
        {
            return (long)((DateTime.UtcNow - EpochDT).TotalMilliseconds);
        }

        public static DateTimeOffset ToEpochTime()
        {
            return ToDateTimeOffsetFromEpochMillis(CurrentTimeMillis());
        }

        public static long ToEpochTime(DateTimeOffset dateTime)
        {
            return Convert.ToInt64((dateTime.ToUniversalTime() - EpochDTO).TotalSeconds);
        }

        public static long ToEpochTimeMillis(DateTimeOffset dateTime)
        {
            return Convert.ToInt64((dateTime.ToUniversalTime() - EpochDTO).TotalMilliseconds);
        }

        public static DateTimeOffset ToDateTimeOffsetFromEpoch(long epochTime)
        {
            return new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero).AddSeconds(epochTime);
        }

        public static DateTimeOffset ToDateTimeOffsetFromEpochMillis(long epochTimeMillis)
        {
            return new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero).AddMilliseconds(epochTimeMillis);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RycharaStockAnalizer.Helpers
{
    public static class UnixTimeHelper
    {
        private static readonly DateTime UnixEpoch =
            new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static DateTime StringToDate(string date, bool close)
        {
            string[] dateDigits = date.Split('-');
            if (close)
            {
                return new DateTime(Convert.ToInt32(dateDigits[0]), Convert.ToInt32(dateDigits[1]), Convert.ToInt32(dateDigits[2]), 19, 30, 0, 0);
            }
            return new DateTime(Convert.ToInt32(dateDigits[0]), Convert.ToInt32(dateDigits[1]), Convert.ToInt32(dateDigits[2]));
        }

        public static long ToUnixTimeMilliSeconds(this DateTime dateTime)
        {
            return Convert.ToInt64((dateTime - UnixEpoch).TotalSeconds) * 1_000 + dateTime.Millisecond;
        }
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }
    }
}

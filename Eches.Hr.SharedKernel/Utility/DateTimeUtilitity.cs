using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eches.Hr.SharedKernal.Utility
{
    public static class DateTimeUtility
    {
        public static int CountDayOfWeek(DayOfWeek day, DateTime start, DateTime end)
        {
            TimeSpan ts = end - start;                       // Total duration
            int count = (int)Math.Floor(ts.TotalDays / 7);   // Number of whole weeks
            int remainder = (int)(ts.TotalDays % 7);         // Number of remaining days
            int sinceLastDay = (int)(end.DayOfWeek - day);   // Number of days since last [day]
            if (sinceLastDay < 0) sinceLastDay += 7;         // Adjust for negative days since last [day]
            //int textw = (int)(DateTime.Now.DayOfWeek);
            // If the days in excess of an even week are greater than or equal to the number days since the last [day], then count this one, too.
            if (remainder >= sinceLastDay) count++;

            return count;
        }

        public static bool CheckIfTimeFramesOverlap(DateTime timeFrameAStart, DateTime timeFrameAEnd, DateTime? timeFrameBStart, DateTime? timeFrameBEnd)
        {
            return
                (timeFrameBStart == null || timeFrameBStart <= timeFrameAEnd)
                && (timeFrameBEnd == null || timeFrameBEnd >= timeFrameAStart);
        }
    }
}

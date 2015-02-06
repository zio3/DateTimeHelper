using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public class DateTimeHelper
    {
        static private readonly TimeZoneInfo jstZoneInfo = System.TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");

        static public DateTime Now
        {
            get
            {
                var utdDate = DateTime.UtcNow;
                DateTime jst = System.TimeZoneInfo.ConvertTimeFromUtc(utdDate, jstZoneInfo);
                return jst;
            }
        }

        static public DateTime Today
        {
            get
            {
                return DateTimeHelper.Now.Date;
            }
        }
        static public IEnumerable<DateTime> EnumDateTime(DateTime start, DateTime end, TimeSpan step, bool lastWith = false)
        {
            var current = start;
            while (current < end)
            {
                yield return current;
                current = current.Add(step);
            }

            if (lastWith)
                yield return end;
        }

        static public DateTime ToMonthStart(DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        static public IEnumerable<DateTime> EnumMonthDateTime(DateTime start, DateTime end, bool lastWith = false)
        {
            var current = ToMonthStart(start);
            end = ToMonthStart(end);
            while (current < end)
            {
                yield return current;
                current = current.AddMonths(1);
            }

            if (lastWith)
                yield return end;
        }
    }
}
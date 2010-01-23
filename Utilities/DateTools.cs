using System;
using System.Collections.ObjectModel;
using System.IO;

namespace Utilities
{
    public static class DateToolsExtenstions
    {
        public static string Dtos(this DateTime dt)
        {
            return DateTools.Dtos(dt);
        }

        public static string DtoXml(this DateTime dt)
        {
            return DateTools.DtoXml(dt);
        }

        public static string Dtoc(this DateTime dt)
        {
            return DateTools.Dtoc(dt);
        }

        public static string Time(this DateTime dt)
        {
            return DateTools.Time(dt);
        }

        public static DateTime XmlToD(this string cIn)
        {
            return DateTools.XmlToD(cIn);
        }

        public static DateTime Ctod(this string cIn)
        {
            return DateTools.Ctod(cIn);
        }

        public static string Dtocs(this DateTime dt)
        {
            return DateTools.Dtocs(dt);
        }

        public static DateTime CcyymmddTod(this string cIn)
        {
            return DateTools.CcyymmddTod(cIn);
        }

        public static DateTime CcyymmddhhmmssTod(this string cIn)
        {
            return DateTools.CcyymmddhhmmssTod(cIn);
        }

        public static string TimeStamp(this DateTime dt, bool bFormatted)
        {
            return DateTools.TimeStamp(dt, bFormatted);
        }

        public static string TimeStamp(this DateTime dt)
        {
            return DateTools.TimeStamp(dt);
        }

        public static string DtoOsiDate(this DateTime dt)
        {
            return DateTools.DtoOsiDate(dt);
        }

        public static string DtoOsiDateTime(this DateTime dt)
        {
            return DateTools.DtoOsiDateTime(dt);
        }

        public static string StringDateToOsiDateTime(this string cIn)
        {
            return DateTools.StringDateToOsiDateTime(cIn);
        }

        public static string StringDateToOsiDate(this string cIn)
        {
            return DateTools.StringDateToOsiDate(cIn);
        }

        public static string StringDateToXmlDateOnly(this string cIn)
        {
            return DateTools.StringDateToXmlDateOnly(cIn);
        }

        public static int MonthsDifference(this DateTime dt1, DateTime dt2)
        {
            return DateTools.MonthsDifference(dt1, dt2);
        }

        public static DateTime Bow(this DateTime dIn)
        {
            return DateTools.Bow(dIn);
        }

        public static DateTime Bom(this DateTime dIn)
        {
            return DateTools.Bom(dIn);
        }

        public static DateTime Eom(this DateTime dIn)
        {
            return DateTools.Eom(dIn);
        }

        public static string CCYYMMDDHHNN_To_Formated_MMDDYYHHNN(this string dIn)
        {
            return DateTools.CCYYMMDDHHNN_To_Formated_MMDDYYHHNN(dIn);
        }

        public static long WeekDays(this DateTime dStart, DateTime dEnd)
        {
            return DateTools.WeekDays(dStart, dEnd);
        }

        public static bool IsValid(this DateTime dIn)
        {
            return DateTools.IsValid(dIn);
        }
    }

    [Serializable]
    public class DateTools
    {
        private static readonly Collection<string> HolidayDates = new Collection<string>();
        public string cErrorMessage = "";

        ///<summary>
        ///</summary>
        ///<param name="dt"></param>
        ///<returns></returns>
        public static string Dtos(DateTime dt)
        {
            string retVal = "";

            if (dt.Ticks > 0)
            {
                retVal = StringTools.Str00(dt.Year, 4);
                retVal += StringTools.Str00(dt.Month, 2);
                retVal += StringTools.Str00(dt.Day, 2);
            }

            return retVal;
        }

        ///<summary>
        ///</summary>
        ///<param name="dt"></param>
        ///<returns></returns>
        public static string DtoXml(DateTime dt)
        {
            string retVal = "";

            if (dt.Ticks > 0)
            {
                string temp = StringTools.Str00(dt.Month, 2);
                retVal = temp + "/";
                temp = StringTools.Str00(dt.Day, 2);
                retVal += temp + "/";
                temp = StringTools.Str00(dt.Year, 4);
                retVal += temp + " ";
                temp = StringTools.Str00(dt.Hour, 2);
                retVal += temp + ":";
                temp = StringTools.Str00(dt.Minute, 2);
                retVal += temp + ":";
                temp = StringTools.Str00(dt.Second, 2);
                retVal += temp;
            }

            return retVal;
        }

        ///<summary>
        ///</summary>
        ///<param name="dt"></param>
        ///<returns></returns>
        public static string Dtoc(DateTime dt)
        {
            string retVal = "";

            if (dt.Ticks > 0)
            {
                string temp = StringTools.Str00(dt.Month, 2);
                retVal = temp + "/";
                temp = StringTools.Str00(dt.Day, 2);
                retVal += temp + "/";
                temp = StringTools.Str00(dt.Year, 4);
                retVal += temp;
            }

            return retVal;
        }

        ///<summary>
        ///</summary>
        ///<param name="dt"></param>
        ///<returns></returns>
        public static string Time(DateTime dt)
        {
            string retVal = "";

            if (dt.Ticks > 0)
            {
                string temp = StringTools.Str00(dt.Hour, 2);
                retVal = temp + ":";
                temp = StringTools.Str00(dt.Minute, 2);
                retVal += temp + ":";
                temp = StringTools.Str00(dt.Second, 2);
                retVal += temp;
            }

            return retVal;
        }

        ///<summary>
        ///</summary>
        ///<param name="cIn"></param>
        ///<returns></returns>
        public static DateTime XmlToD(string cIn)
        {
            var dt = new DateTime();
            int nYear = StringTools.StrVal(StringTools.SubStr(cIn, 6, 4));
            int nMonth = StringTools.StrVal(StringTools.SubStr(cIn, 0, 2));
            int nDay = StringTools.StrVal(StringTools.SubStr(cIn, 3, 2));
            int nHour = StringTools.StrVal(StringTools.SubStr(cIn, 11, 2));
            int nMinute = StringTools.StrVal(StringTools.SubStr(cIn, 14, 2));
            int nSecond = StringTools.StrVal(StringTools.SubStr(cIn, 17, 2));

            if ((nYear > 0) && (nMonth > 0) && (nDay > 0))
            {
                if ((nHour > 0) && (nMinute >= 0) && (nSecond >= 0))
                    dt = new DateTime(nYear, nMonth, nDay, nHour, nMinute, nSecond);
                else
                    dt = new DateTime(nYear, nMonth, nDay);
            }

            return dt;
        }

        ///<summary>
        ///</summary>
        ///<param name="cIn"></param>
        ///<returns></returns>
        public static DateTime Ctod(string cIn)
        {
            var dt = new DateTime();

            if (cIn != null)
            {
                int nYears, nMonths, nDays;

                if (StringTools.SubStr(cIn, 4, 1) == "-")
                {
                    nYears = StringTools.StrVal(StringTools.SubStr(cIn, 0, 4));
                    nMonths = StringTools.StrVal(StringTools.SubStr(cIn, 5, 2));
                    nDays = StringTools.StrVal(StringTools.SubStr(cIn, 8, 2));
                }
                else
                {
                    nYears = StringTools.StrVal(StringTools.SubStr(cIn, 6, 4));
                    nMonths = StringTools.StrVal(StringTools.SubStr(cIn, 0, 2));
                    nDays = StringTools.StrVal(StringTools.SubStr(cIn, 3, 2));
                }

                if (nYears < 30)
                {
                    nYears = nYears + 2000;
                }
                else if (nYears < 100)
                {
                    nYears = nYears + 1900;
                }

                if ((nMonths > 0) && (nDays > 0))
                    dt = new DateTime(nYears, nMonths, nDays);
            }

            return dt;
        }

        ///<summary>
        ///</summary>
        ///<param name="dIn"></param>
        ///<returns></returns>
        public static DateTime DoubleToD(double dIn)
        {
            DateTime dt = DateTime.FromOADate(dIn);
            return dt;
        }

        ///<summary>
        ///</summary>
        ///<param name="dt"></param>
        ///<returns></returns>
        public static string Dtocs(DateTime dt)
        {
            string cOut = "        ";

            if (dt.Ticks > 0)
            {
                string cTemp = StringTools.Str00(dt.Month, 2);
                cOut = cTemp + "/";
                cTemp = StringTools.Str00(dt.Day, 2);
                cOut += cTemp + "/";
                cTemp = StringTools.Str00(dt.Year, 4).Substring(2, 2);
                cOut += cTemp;
            }

            return cOut;
        }

        ///<summary>
        ///</summary>
        ///<param name="cIn"></param>
        ///<returns></returns>
        public static DateTime CcyymmddTod(string cIn)
        {
            DateTime dt;

            try
            {
                dt = StringToDateTime(cIn, "yyyyMMdd");
            }
            catch
            {
                dt = new DateTime();
            }

            return dt;
        }

        public static DateTime CcyymmddhhmmssTod(string cIn)
        {
            DateTime dt;

            try
            {
                dt = StringToDateTime(cIn, "yyyyMMddHHmmss");
            }
            catch (Exception)
            {
                dt = new DateTime();
            }

            return dt;
        }

        ///<summary>
        ///</summary>
        ///<param name="dt"></param>
        ///<param name="bFormatted"></param>
        ///<returns></returns>
        public static string TimeStamp(DateTime dt, bool bFormatted)
        {
            if (!bFormatted)
                return dt.ToString("yyyyMMddHHmmss");

            return dt.ToString("yyyy-MM-dd HH:mm:ss");
        }

        ///<summary>
        ///</summary>
        ///<param name="dt"></param>
        ///<returns></returns>
        public static string TimeStamp(DateTime dt)
        {
            return TimeStamp(dt, false);
        }

        ///<summary>
        ///</summary>
        ///<param name="bFormatted"></param>
        ///<returns></returns>
        public static string TimeStamp(bool bFormatted)
        {
            return TimeStamp(DateTime.Now, bFormatted);
        }

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public static string TimeStamp()
        {
            return TimeStamp(DateTime.Now, false);
        }

        ///<summary>
        ///</summary>
        ///<param name="dt"></param>
        ///<returns></returns>
        public static string DtoOsiDate(DateTime dt)
        {
            string cOut = "";

            if (dt.Ticks > 0)
            {
                int nYear = dt.Year;
                int nMonth = dt.Month;
                int nDay = dt.Day;
                cOut = StringTools.Str00(nYear, 4) + "-" + StringTools.Str00(nMonth, 2) + "-" +
                       StringTools.Str00(nDay, 2);
            }

            return cOut;
        }

        ///<summary>
        ///</summary>
        ///<param name="dt"></param>
        ///<returns></returns>
        public static string DtoOsiDateTime(DateTime dt)
        {
            int nHour = dt.Hour;
            int nMinute = dt.Minute;
            int nSecond = dt.Second;
            string cOut = DtoOsiDate(dt) + "T" + StringTools.Str00(nHour, 2) + ":" + StringTools.Str00(nMinute, 2) + ":" +
                          StringTools.Str00(nSecond, 2);
            return cOut;
        }

        ///<summary>
        ///</summary>
        ///<param name="cIn"></param>
        ///<returns></returns>
        public static string StringDateToOsiDateTime(string cIn)
        {
            string cOut = cIn;

            if (cIn != null)
                if (cIn.IndexOf("-") < 0)
                {
                    try
                    {
                        DateTime dt = DateTime.Parse(cIn);

                        if (dt.Ticks > 0)
                            cOut = DtoOsiDateTime(dt);
                    }
                    catch
                    {
                    }
                }

            return cOut;
        }

        ///<summary>
        ///</summary>
        ///<param name="cIn"></param>
        ///<returns></returns>
        public static string StringDateToOsiDate(string cIn)
        {
            string cOut = cIn;

            if (cIn != null)
                if (cIn.IndexOf("-") < 0)
                {
                    try
                    {
                        DateTime dt = DateTime.Parse(cIn);

                        if (dt.Ticks > 0)
                            cOut = DtoOsiDate(dt);
                    }
                    catch
                    {
                    }
                }

            return cOut;
        }

        ///<summary>
        ///</summary>
        ///<param name="cIn"></param>
        ///<returns></returns>
        public static string StringDateToXmlDateOnly(string cIn)
        {
            string cOut = cIn;

            if (cIn != null)
                try
                {
                    DateTime dt = DateTime.Parse(cIn);

                    if (dt.Ticks > 0)
                    {
                        cOut = StringTools.Str00(dt.Year, 4) + "-" + StringTools.Str00(dt.Month, 2) + "-" +
                               StringTools.Str00(dt.Day, 2);
                    }
                }
                catch
                {
                }

            return cOut;
        }

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public static string DayOfWeekAbbr()
        {
            string dayOfWeek = "";
            DateTime dateTime = DateTime.Now;

            switch (dateTime.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    dayOfWeek = "Sun";
                    break;
                case DayOfWeek.Monday:
                    dayOfWeek = "Mon";
                    break;
                case DayOfWeek.Tuesday:
                    dayOfWeek = "Tue";
                    break;
                case DayOfWeek.Wednesday:
                    dayOfWeek = "Wed";
                    break;
                case DayOfWeek.Thursday:
                    dayOfWeek = "Thu";
                    break;
                case DayOfWeek.Friday:
                    dayOfWeek = "Fri";
                    break;
                case DayOfWeek.Saturday:
                    dayOfWeek = "Sat";
                    break;
            }

            return dayOfWeek;
        }

        /// <summary>
        /// Converts a string in the specified format into a representative DateTime
        /// object.
        /// 
        /// Exceptions:
        ///		System.ArgumentNullException - date or format is null.
        ///		System.FormatException - date or format is empty -or- date does not contain
        ///			date in the format specified.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="format">
        /// d		- Numeric day of the month without a leading zero.
        /// dd		- Numeric day of the month with a leading zero.
        /// ddd		- Abbreviated name of the day of the week.
        /// dddd	- Full name of the day of the week.
        /// 
        /// f,ff,fff,ffff,fffff - Fraction of a second. The more 'f's the higher the presision.
        /// 
        /// h		- 12 Hour clock, no leading zero.
        /// hh		- 12 Hour clock with leading zero.
        /// H		- 24 Hour clock, no leading zero.
        /// HH		- 24 Hour clock with leading zero.
        /// 
        /// m		- Minutes with no leading zero.
        /// mm		- Minutes with leading zero.
        /// 
        /// M		- Numeric month with no leading zero.
        /// MM		- Numeric month with a leading zero.
        /// MMM		- Abbreviated name of month.
        /// MMMM	- Full month name.
        /// 
        /// s		- Seconds with no leading zero.
        /// ss		- Seconds with leading zero.
        /// 
        /// t		- AM/PM but only the first letter.
        /// tt		- AM/PM
        /// 
        /// y		- Year with out century and leading zero.
        /// yy		- Year with out century, with leading zero.
        /// yyyy	- Year with century.
        /// 
        /// zz		- Time zone off set with +/-.
        /// </param>
        /// <returns></returns>
        public static DateTime StringToDateTime(string date, string format)
        {
            return DateTime.ParseExact(date, format, null);
        }

        /// <summary>
        /// Returns the number of months between dt1 and dt2. Note that the number
        /// of months is incremented after the same day on the next month (or the closest
        /// to that day possible - for instance, one month from 1/31/2006 (which is
        /// not a leap year) is 2/28/2006. Two months from then is 3/31/2006). Note that
        /// this means that 1/1/2006 and 2/1/2006 will show that there is a one month
        /// difference. 1/1/2006 and 2/2/2006 will show two months. It is important to
        /// note that this function will return at least 1 unless the two dates are
        /// identical, or there is an error. For instance, 1/1/2006 and 1/2/2006 will show
        /// a one month difference.
        /// 
        /// -1 is returned if there is an error.
        /// </summary>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <returns></returns>
        public static int MonthsDifference(DateTime dt1, DateTime dt2)
        {
            try
            {
                DateTime earlierDate;
                DateTime laterDate;

                if (dt1 <= dt2)
                {
                    earlierDate = dt1;
                    laterDate = dt2;
                }
                else
                {
                    earlierDate = dt2;
                    laterDate = dt1;
                }

                int i;
                for (i = 0; earlierDate < laterDate; i++)
                {
                    try
                    {
                        earlierDate = earlierDate.AddMonths(1);
                    }
                    catch
                    {
                        return -1;
                    }
                }
                return i;
            }
            catch
            {
                return -1;
            }
        }

        ///<summary>
        ///</summary>
        ///<param name="dIn"></param>
        ///<returns></returns>
        public static DateTime Bow(DateTime dIn)
        {
            try
            {
                while (dIn.DayOfWeek != DayOfWeek.Saturday)
                    dIn = dIn.AddDays(-1);
            }
            catch (Exception e)
            {
                Console.WriteLine("Bow exception: " + e.Message);
            }

            return dIn;
        }

        ///<summary>
        ///</summary>
        ///<param name="dIn"></param>
        ///<returns></returns>
        public static DateTime Bom(DateTime dIn)
        {
            try
            {
                while (dIn.Day != 1)
                    dIn = dIn.AddDays(-1);
            }
            catch (Exception e)
            {
                Console.WriteLine("Bom exception: " + e.Message);
            }

            return dIn;
        }

        ///<summary>
        ///</summary>
        ///<param name="dIn"></param>
        ///<returns></returns>
        public static DateTime Eom(DateTime dIn)
        {
            try
            {
                while (dIn.Day != 1)
                    dIn = dIn.AddDays(1);

                dIn = dIn.AddDays(-1);
            }
            catch (Exception e)
            {
                Console.WriteLine("Eom exception: " + e.Message);
            }

            return dIn;
        }

        ///<summary>
        ///</summary>
        ///<param name="dStartTime"></param>
        ///<param name="dEndTime"></param>
        ///<param name="nStartofDayHour"></param>
        ///<param name="nEndofDayHour"></param>
        ///<param name="cMel1"></param>
        ///<param name="nMax"></param>
        ///<returns></returns>
        public static int CalculateElapsedTime(DateTime dStartTime, DateTime dEndTime, int nStartofDayHour,
                                               int nEndofDayHour, string cMel1, int nMax)
        {
            if (HolidayDates.Count <= 0)
                ReadFdcHolidayDates(cMel1);

            int retVal = 0;
            int dMinutes = 0;
            DateTime dTemp;

            if (dStartTime.Hour < nStartofDayHour)
            {
                dTemp = dStartTime;
                dStartTime = new DateTime(dTemp.Year, dTemp.Month, dTemp.Day, nStartofDayHour, 0, 0);
            }

            if (dEndTime.Hour >= nEndofDayHour)
            {
                dTemp = dEndTime;
                dEndTime = new DateTime(dTemp.Year, dTemp.Month, dTemp.Day, nEndofDayHour, 0, 0);
            }

            if (dEndTime > dStartTime)
            {
                var oneDay = new TimeSpan(1, 0, 0, 0);
                TimeSpan span = dEndTime - dStartTime;

                if ((dEndTime.Day == dStartTime.Day) && (span.Days == 0))
                {
                    if (GetIsCountableDay(dStartTime))
                    {
                        retVal = span.Hours;
                        dMinutes = span.Minutes;
                    }
                }
                else
                {
                    //first day
                    if (GetIsCountableDay(dStartTime))
                    {
                        // hour is in middle of day
                        if (dStartTime.Hour >= nStartofDayHour & dStartTime.Hour <= nEndofDayHour)
                        {
                            dTemp = new DateTime(dStartTime.Year, dStartTime.Month, dStartTime.Day, nEndofDayHour, 0, 0);
                            span = dTemp - dStartTime;
                            retVal += span.Hours;

                            if (span.Minutes > 0)
                                dMinutes += span.Minutes;
                        }
                        else if (dStartTime.Hour < nStartofDayHour)
                            retVal += (nEndofDayHour - nStartofDayHour);
                    }

                    dStartTime += oneDay;

                    while ((dEndTime.Day > dStartTime.Day) || (dEndTime.Month > dStartTime.Month) ||
                           (dEndTime.Year > dStartTime.Year))
                    {
                        if (GetIsCountableDay(dStartTime))
                            retVal += (nEndofDayHour - nStartofDayHour);

                        dStartTime += oneDay;

                        if (retVal > nMax)
                            break;
                    }

                    if (retVal < nMax)
                    {
                        if (GetIsCountableDay(dEndTime))
                        {
                            // hour is in middle of day
                            if (dEndTime.Hour >= nStartofDayHour && dEndTime.Hour <= nEndofDayHour)
                            {
                                dTemp = new DateTime(dEndTime.Year, dEndTime.Month, dEndTime.Day, nStartofDayHour, 0, 0);
                                span = dEndTime - dTemp;
                                retVal += span.Hours;

                                if (span.Minutes > 0)
                                    dMinutes += span.Minutes;
                            }
                            else if (dEndTime.Hour >= nStartofDayHour)
                                retVal += (nEndofDayHour - nStartofDayHour);
                        }
                    }
                }
            }

            if (dMinutes >= 60)
                ++retVal;

            return retVal;
        }

        /// <summary>
        /// returns the total number of minutes
        /// </summary>
        /// <param name="dStartTime"></param>
        /// <param name="dEndTime"></param>
        /// <param name="nStartofDayHour"></param>
        /// <param name="nEndofDayHour"></param>
        /// <param name="cMel1"></param>
        /// <returns></returns>
        public static int CalculateElapsedMinutes(DateTime dStartTime, DateTime dEndTime, int nStartofDayHour, int nEndofDayHour, string cMel1)
        {
            return CalculateElapsedMinutes(dStartTime, dEndTime, nStartofDayHour, nEndofDayHour, cMel1, 0);
        }

        public static int CalculateElapsedMinutes(DateTime dStartTime, DateTime dEndTime, int nStartofDayHour, int nEndofDayHour, string cMel1, int nMaxMinutes)
        {
            if (HolidayDates.Count <= 0)
                ReadFdcHolidayDates(cMel1);

            int retVal = 0;
            int dMinutes = 0;
            DateTime dTemp;

            if (dStartTime.Hour < nStartofDayHour)
            {
                dTemp = dStartTime;
                dStartTime = new DateTime(dTemp.Year, dTemp.Month, dTemp.Day, nStartofDayHour, 0, 0);
            }

            if (dEndTime.Hour >= nEndofDayHour)
            {
                dTemp = dEndTime;
                dEndTime = new DateTime(dTemp.Year, dTemp.Month, dTemp.Day, nEndofDayHour, 0, 0);
            }

            if (dEndTime > dStartTime)
            {
                var oneDay = new TimeSpan(1, 0, 0, 0);
                TimeSpan span = dEndTime - dStartTime;

                if ((dEndTime.Day == dStartTime.Day) && (span.Days == 0))
                {
                    if (GetIsCountableDay(dStartTime))
                    {
                        retVal = span.Hours;
                        dMinutes += span.Minutes;

                        if (span.Seconds > 30)
                            dMinutes++;
                    }
                }
                else
                {
                    //first day
                    if (GetIsCountableDay(dStartTime))
                    {
                        //hour is in middle of day
                        if ((dStartTime.Hour >= nStartofDayHour) && (dStartTime.Hour <= nEndofDayHour))
                        {
                            dTemp = new DateTime(dStartTime.Year, dStartTime.Month, dStartTime.Day, nEndofDayHour, 0, 0);
                            span = dTemp - dStartTime;
                            retVal += span.Hours;

                            if (span.Minutes > 0)
                                dMinutes += span.Minutes;

                            if (span.Seconds > 30)
                                dMinutes++;
                        }
                        else if (dStartTime.Hour < nStartofDayHour)
                            retVal += (nEndofDayHour - nStartofDayHour);
                    }

                    dStartTime += oneDay;

                    while ((dEndTime.Day > dStartTime.Day) || (dEndTime.Month > dStartTime.Month) || (dEndTime.Year > dStartTime.Year))
                    {
                        if (GetIsCountableDay(dStartTime))
                            retVal += (nEndofDayHour - nStartofDayHour);

                        if ((nMaxMinutes > 0) && (retVal*60 > nMaxMinutes))
                            break;

                        dStartTime += oneDay;
                    }

                    if (((nMaxMinutes == 0) || (retVal*60 < nMaxMinutes)) && GetIsCountableDay(dEndTime))
                    {
                        //hour is in middle of day
                        if (dEndTime.Hour >= nStartofDayHour && dEndTime.Hour <= nEndofDayHour)
                        {
                            dTemp = new DateTime(dEndTime.Year, dEndTime.Month, dEndTime.Day, nStartofDayHour, 0, 0);
                            span = dEndTime - dTemp;
                            retVal += span.Hours;

                            if (span.Minutes > 0)
                                dMinutes += span.Minutes;
                        }
                        else if (dEndTime.Hour >= nStartofDayHour)
                            retVal += (nEndofDayHour - nStartofDayHour);
                    }
                }
            }

            retVal *= 60;
            retVal += dMinutes;
            return retVal;
        }

        /// <summary>
        /// returns the total elapsed time
        /// </summary>
        /// <param name="dStartTime"></param>
        /// <param name="dEndTime"></param>
        /// <param name="nStartofDayHour"></param>
        /// <param name="nEndofDayHour"></param>
        /// <param name="cMel1"></param>
        /// <returns></returns>
        public static double CalculateTotalElapsedTime(DateTime dStartTime, DateTime dEndTime, int nStartofDayHour, int nEndofDayHour, string cMel1)
        {
            return CalculateTotalElapsedTime(dStartTime, dEndTime, nStartofDayHour, nEndofDayHour, cMel1, 0);
        }

        public static double CalculateTotalElapsedTime(DateTime dStartTime, DateTime dEndTime, int nStartofDayHour, int nEndofDayHour, string cMel1, int nMaxHours)
        {
            int total = CalculateElapsedMinutes(dStartTime, dEndTime, nStartofDayHour, nEndofDayHour, cMel1, nMaxHours*60);
            double dTotal = Convert.ToDouble(total);
            return (dTotal/60);
        }

        /// <summary>
        /// checks if a countable day
        /// </summary>
        /// <param name="dDate"></param>
        /// <returns></returns>
        public static bool GetIsCountableDay(DateTime dDate)
        {
            bool retVal;
            int dayOfWeek = dDate.DayOfWeek.GetHashCode();

            if (dayOfWeek.Equals(6) || dayOfWeek.Equals(0)) // Sunday , Saturday
                retVal = false;
            else
            {
                string cDate = dDate.Dtos();
                cDate = cDate.SubStr(4, 2) + "/" + cDate.SubStr(6, 2) + "/" + cDate.SubStr(0, 4);
                retVal = !HolidayDates.Contains(cDate);
            }

            return retVal;
        }

        /// <summary>
        /// checks to see if it is a kfd holiday
        /// </summary>
        /// <param name="cMel1"></param>
        /// <param name="cDate"></param>
        /// <returns></returns>
        public static bool GetIsHoliday(string cMel1, string cDate)
        {
            if (HolidayDates.Count.Equals(0))
                ReadFdcHolidayDates(cMel1);

            return HolidayDates.Contains(cDate);
        }

        /// <summary>
        /// reads holidays.txt and populates the HolidayDates list
        /// </summary>
        /// <param name="cMel1"></param>
        public static void ReadFdcHolidayDates(string cMel1)
        {
            try
            {
                string cFile = cMel1 + "\\corp\\holidays.txt";

                if (FileTools.SFileExists(cFile))
                {
                    var stream = new StreamReader(cFile);

                    while (!stream.EndOfStream)
                    {
                        string cData = stream.ReadLine();

                        if (StringTools.Empty(cData) || cData.Equals("EOF"))
                            break;

                        if (! StringTools.SubStr(cData, 0, 2).Equals("//") && (cData.Length == 10))
                            HolidayDates.Add(cData);
                    }

                    stream.Close();
                }
            }
            catch
            {
            }
        }

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public static string CurrentDateTime()
        {
            return DateTime.Now.ToShortDateString() + " " + Time(DateTime.Now);
        }

        ///<summary>
        ///</summary>
        ///<param name="cIn"></param>
        ///<returns></returns>
        public DateTime CcyymmddToDate(string cIn)
        {
            var dt = new DateTime();

            if (cIn != null)
                try
                {
                    string cTemp = cIn.Substring(4, 2) + "/" + cIn.Substring(6, 2) + "/" + cIn.Substring(0, 4);
                    dt = Convert.ToDateTime(cTemp);
                }
                catch (Exception e)
                {
                    cErrorMessage = e.Message;
                }

            return dt;
        }

        // returns mm/dd/yy hh:mm
        public static string CCYYMMDDHHNN_To_Formated_MMDDYYHHNN(string date)
        {
            string retVal = "              ";

            if (date.Length >= 12)
            {
                retVal = StringTools.SubStr(date, 4, 2)
                         + "/"
                         + StringTools.SubStr(date, 6, 2)
                         + "/"
                         + StringTools.SubStr(date, 2, 2)
                         + " "
                         + StringTools.SubStr(date, 8, 2)
                         + ":"
                         + StringTools.SubStr(date, 10, 2);
            }

            return retVal;
        }

        public static long WeekDays(DateTime dStart, DateTime dEnd)
        {
            long nResult = 0;

            if (dStart.Ticks > 0 && dEnd.Ticks > 0)
            {
                DayOfWeek nDay;

                if (dStart > dEnd)
                {
                    while (dStart > dEnd)
                    {
                        nDay = dStart.DayOfWeek;

                        if (!((nDay == DayOfWeek.Sunday) || (nDay == DayOfWeek.Saturday)))
                            nResult -= 1;

                        dStart = dStart.AddDays(-1);
                    }
                }
                else
                {
                    while (dStart < dEnd)
                    {
                        nDay = dStart.DayOfWeek;

                        if (!((nDay == DayOfWeek.Sunday) || (nDay == DayOfWeek.Saturday)))
                            nResult += 1;

                        dStart = dStart.AddDays(1);
                    }
                }
            }

            return nResult;
        }

        public static bool IsValid(DateTime dIn)
        {
            return dIn.Ticks > 0;
        }

        public static string SDat5(string c)
        {
            string cReturn = "UN/KN";
            int nLen = c.Length;

            switch (nLen)
            {
                case 3:
                    if (!String.IsNullOrEmpty(c.SubStr(0, 1)))
                    {
                        var dt = new DateTime();
                        string cDt = Dtos(dt);
                        int in_month = c.SubStr(0, 2).StrVal();
                        int cur_month = dt.Month;
                        string syear = cDt.SubStr(2, 1);
                        string inyear = c.SubStr(2, 1);
                        int ouryear = cDt.SubStr(2, 2).StrVal();
                        string cTemp = syear + inyear;
                        int in_year = cTemp.StrVal();

                        if (in_year == ouryear)
                        {
                            if (in_month > cur_month)
                                in_year -= 10;
                        }
                        else if (in_year > ouryear)
                            in_year -= 10;

                        cReturn = c.SubStr(0, 2) + "/" + "00" + Convert.ToString(in_year).Right(2);
                    }
                    else if (!String.IsNullOrEmpty(c.SubStr(1, 1)))
                        cReturn = "01/" + c.SubStr(1, 2);
                    else if (c[2] == '1')
                        cReturn = "05/YR";
                    else if (c[2] == '2')
                        cReturn = "10/YR";
                    break;
                case 4:
                    if (!String.IsNullOrEmpty(c.SubStr(0, 1)))
                        cReturn = c.SubStr(0, 2) + "/" + c.SubStr(2, 2);
                    else if (!String.IsNullOrEmpty(c.SubStr(2, 1)))
                        cReturn = "01/" + c.SubStr(2, 2);
                    else if (c[3] == '1')
                        cReturn = "05/YR";
                    else if (c[3] == '2')
                        cReturn = "10/YR";
                    break;
                default:
                    cReturn = c.SubStr(0, 2) + "/" + c.SubStr(4, 2);
                    break;
            }

            return (cReturn);
        } //Dat5
    }
}
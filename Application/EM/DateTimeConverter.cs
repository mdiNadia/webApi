using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EM
{
   public static class DateTimeConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Shamsi">1365/05/05</param>
        /// <returns></returns>
        public static System.DateTime ChangeShamsiToMiladiDateTime(this string Shamsi)
        {
            // با این کار جلوی خطای نبود   ساعت گرفته خواهد شد 
            Shamsi = Shamsi + " 00:00";
            try
            {
                System.DateTime miladi = default(System.DateTime);
                System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                miladi = pc.ToDateTime(Convert.ToInt32(Shamsi.Substring(0, 4)), Convert.ToInt32(Shamsi.Substring(5, 2)), Convert.ToInt32(Shamsi.Substring(8, 2)), Convert.ToInt32(Shamsi.Substring(11, 2)), Convert.ToInt32(Shamsi.Substring(14, 2)), 0, 0, System.Globalization.Calendar.CurrentEra);
                return miladi;
            }
            catch (Exception)
            {
                return DateTime.Now;
            }
        }

        public static System.DateTime ChangeShamsiToMiladi(this string Shamsi)
        {
            Shamsi = Shamsi.Replace(" ", "");
            System.DateTime miladi = default(System.DateTime);
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            var year = Convert.ToInt32(Shamsi.Substring(0, 4));
            var month = Convert.ToInt32(Shamsi.Substring(5, 2));
            var day = Convert.ToInt32(Shamsi.Substring(8, 2));

            miladi = pc.ToDateTime(Convert.ToInt32(Shamsi.Substring(0, 4)), Convert.ToInt32(Shamsi.Substring(5, 2)), Convert.ToInt32(Shamsi.Substring(8, 2)), 10, 10, 10, 10, System.Globalization.Calendar.CurrentEra);
            miladi = miladi.Date;
            return miladi;
        }
        public static string ChangeMiladiToShamsi(this DateTime Miladi)
        {
            string Shamsi = null;
            System.Globalization.PersianCalendar PC = new System.Globalization.PersianCalendar();
            string Year = null;
            string Month = null;
            string Day = null;

            Year = PC.GetYear(Miladi).ToString();
            Month = PC.GetMonth(Miladi).ToString();
            if (Month.Length < 2)
                Month = "0" + Month;
            Day = PC.GetDayOfMonth(Miladi).ToString();
            if (Day.Length < 2)
                Day = "0" + Day;

            Shamsi = Year + "/" + Month + "/" + Day;

            return Shamsi;
        }
        public static string ChangeMiladiToShamsiTime(this DateTime Miladi)
        {
            string Shamsi = null;
            System.Globalization.PersianCalendar PC = new System.Globalization.PersianCalendar();
            string Year = null;
            string Month = null;
            string Day = null;

            Year = PC.GetHour(Miladi).ToString();
            Month = PC.GetMinute(Miladi).ToString();
            if (Month.Length < 2)
                Month = "0" + Month;
            Day = PC.GetSecond(Miladi).ToString();
            if (Day.Length < 2)
                Day = "0" + Day;

            Shamsi = Year + ":" + Month + ":" + Day;

            return Shamsi;
        }
        public static string ChangeMiladiToLongShamsi(this System.DateTime Miladi)
        {
            string Shamsi = null;
            System.Globalization.PersianCalendar PC = new System.Globalization.PersianCalendar();
            string Year = null;
            string Month = null;
            string Day = null;
            var daysofweek = new string[] { "یکشنبه", "دوشنبه", "سه شنبه", "چهارشنبه", "پنج شنبه", "جمعه", "شنبه" };

            Year = PC.GetYear(Miladi).ToString();
            Month = PC.GetMonth(Miladi).ToString();
            if (Month.Length < 2)
                Month = "0" + Month;
            Day = PC.GetDayOfMonth(Miladi).ToString();
            if (Day.Length < 2)
                Day = "0" + Day;
            string m = "";
            switch (Month)
            {
                case "01": m = "فروردین"; break;
                case "02": m = "اردیبشت"; break;
                case "03": m = "خرداد"; break;
                case "04": m = "تیر"; break;
                case "05": m = "مرداد"; break;
                case "06": m = "شهریور"; break;
                case "07": m = "مهر"; break;
                case "08": m = "آبان"; break;
                case "09": m = "آذر"; break;
                case "10": m = "دی"; break;
                case "11": m = "بهمن"; break;
                case "12": m = "اسفند"; break;
            }
            Shamsi = daysofweek[(int)PC.GetDayOfWeek(Miladi)] + " " + Day + " " + m + " " + Year;

            return Shamsi;
        }

        // نوشته شده توسط شرفی
        /// <summary>
        /// تاریخ شروع ماه کنونی خورشیدی با ورودی میلادی و خروجی میلادی
        /// </summary>
        /// <param name="Miladi">تاریخ میلادی</param>
        /// <returns></returns>
        public static DateTime ThisMonthStarted(this System.DateTime Miladi)
        {
            string Shamsi;
            PersianCalendar PC = new PersianCalendar();
            string Year;
            string Month;
            string Day;

            Year = PC.GetYear(Miladi).ToString();
            Month = PC.GetMonth(Miladi).ToString();
            if (Month.Length < 2)
                Month = "0" + Month;
            Day = "01";

            Shamsi = Year + "/" + Month + "/" + Day;
            var returnDate = ChangeShamsiToMiladi(Shamsi);
            return returnDate;
        }
        /// <summary>
        /// گرفتن تاریخ میلادی و برگردداندن تاریخ شروع و پایان ماه گذشته خورشیدی به صوزت میلادی
        /// </summary>
        /// <param name="Miladi">تاریخ ورودی میلادی</param>
        /// <returns></returns>
        public static Tuple<System.DateTime, System.DateTime> LastMonthRangeDate(this System.DateTime Miladi)
        {
            var lastMonth = Miladi.AddDays(-30);
            string Shamsi = null;
            string endDateShamsi = null;
            PersianCalendar PC = new PersianCalendar();
            string Year = null;
            string Month = null;
            string Day = null;
            string endDay = null;

            Year = PC.GetYear(Miladi).ToString();
            Month = PC.GetMonth(Miladi).ToString();

            if (Month.Length < 2)
                Month = "0" + Month;
            Day = "01";

            endDay = byte.Parse(Month) < 7 ? "31"
                : byte.Parse(Month) == 12 ? "29"
                : "30";

            Shamsi = Year + "/" + Month + "/" + Day;
            endDateShamsi = Year + "/" + Month + "/" + endDay;
            var returnStartDate = ChangeShamsiToMiladi(Shamsi);
            var returnEndtDate = ChangeShamsiToMiladi(endDateShamsi);
            return new Tuple<System.DateTime, System.DateTime>(returnStartDate, returnEndtDate);
        }
        /// <summary>
        /// نام سال خورشیدی جاری
        /// </summary>
        /// <param name="Miladi"></param>
        /// <returns></returns>
        public static string GetPersianYear(System.DateTime Miladi)
        {
            System.Globalization.PersianCalendar PC = new System.Globalization.PersianCalendar();
            string Year = null;

            Year = PC.GetYear(Miladi).ToString();
            return Year;
        }
        /// <summary>
        /// برگرداندن لیستی از روز های پیش رو
        /// </summary>
        /// <param name=""></param>
        /// <param name="Days"></param>
        /// <returns></returns>
        public static List<String> RetunDate(this DateTime date, int Days)
        {
            var list = new List<string>();
            for (int i = 0; i < Days; i++)
            {
                var rdate = ChangeMiladiToShamsi(date.AddDays(i));
                list.Add(rdate);
            }
            return list;
        }
        /// <summary>
        /// برگرداندن ساعت نسبت به سال 2019 برای مقایسه تاریخ 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string CovertDateTimeToHoure(this DateTime dateTime)
        {
            return dateTime.ToString("yyyyMMdd");
            //return (dateTime.Year - 2019) * 365 * 12 * 30 * 24 + (dateTime.Month - 1) * 30 * 24 + (dateTime.Day - 1) * 24 + dateTime.Hour;
        }

        public static string GetDayOfWeek(this int day)
        {
            switch (day)
            {
                case 0: return "شنبه";
                case 1: return "یکشنبه";
                case 2: return "دوشنبه";
                case 3: return "سه شنبه";
                case 4: return "چهارشنبه";
                case 5: return "پنجشنبه";
                case 6: return "جمعه";
                default: return "نامشخص";
            }
        }

        public static string GetDifferentDate(this DateTime dateTime)
        {
            string result = string.Empty;
            DateTime zeroTime = new DateTime(1, 1, 1);
            var differentDate = DateTime.Now - dateTime;
            var Years = (zeroTime + differentDate).Year - 1;
            var DiffMonth = (zeroTime + differentDate).Month - 1;
            var DiffDay = (zeroTime + differentDate).Day - 1;
            if (Years > 0) result += $"{Years} سال و";
            if (DiffMonth > 0) result += $"{DiffMonth} ماه و";
            if (DiffDay > 0) result += $"{DiffDay} روز ";


            return result;

        }
        // برگرداندن تاریخ شروع هفته با مشخص کردن روز شروع هفته
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }
        // برگرداندن تاریخ شروع ماه
    }
}

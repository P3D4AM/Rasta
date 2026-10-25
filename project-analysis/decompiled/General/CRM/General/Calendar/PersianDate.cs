using System;
using System.Globalization;

namespace CRM.General.Calendar;

public static class PersianDate
{
	public static string GetCurrentDate
	{
		get
		{
			PersianCalendar persianCalendar = new PersianCalendar();
			int year = persianCalendar.GetYear(DateTime.Today);
			int month = persianCalendar.GetMonth(DateTime.Today);
			int dayOfMonth = persianCalendar.GetDayOfMonth(DateTime.Today);
			string empty = string.Empty;
			string empty2 = string.Empty;
			string empty3 = string.Empty;
			empty = ((year >= 10) ? year.ToString() : $"0{year}");
			empty2 = ((month >= 10) ? month.ToString() : $"0{month}");
			empty3 = ((dayOfMonth >= 10) ? dayOfMonth.ToString() : $"0{dayOfMonth}");
			return $"{empty}/{empty2}/{empty3}";
		}
	}

	public static string GetCurrentTextDate
	{
		get
		{
			PersianCalendar persianCalendar = new PersianCalendar();
			string[] array = new string[7] { "شنبه", "يکشنبه", "دوشنبه", "سه شنبه", "چهارشنبه", "پنجشنبه", "جمعه" };
			string[] array2 = new string[12]
			{
				"فروردين", "ارديبهشت", "خرداد", "تير", "مرداد", "شهريور", "مهر", "آبان", "آذر", "دي",
				"بهمن", "اسفند"
			};
			int month = persianCalendar.GetMonth(DateTime.Today);
			int num = 0;
			switch (persianCalendar.GetDayOfWeek(DateTime.Today))
			{
			case DayOfWeek.Saturday:
				num = 0;
				break;
			case DayOfWeek.Sunday:
				num = 1;
				break;
			case DayOfWeek.Monday:
				num = 2;
				break;
			case DayOfWeek.Tuesday:
				num = 3;
				break;
			case DayOfWeek.Wednesday:
				num = 4;
				break;
			case DayOfWeek.Thursday:
				num = 5;
				break;
			case DayOfWeek.Friday:
				num = 6;
				break;
			}
			return $"{array[num]} {persianCalendar.GetDayOfMonth(DateTime.Today)} {array2[month - 1]} {persianCalendar.GetYear(DateTime.Today)}";
		}
	}

	public static int GetCurrentMonth => new PersianCalendar().GetMonth(DateTime.Today);

	public static int GetCurrentYear => new PersianCalendar().GetYear(DateTime.Today);

	public static int GetCurrentDay => new PersianCalendar().GetDayOfMonth(DateTime.Today);

	public static string GetCurrentTextMonth
	{
		get
		{
			PersianCalendar persianCalendar = new PersianCalendar();
			string[] obj = new string[12]
			{
				"فروردين", "ارديبهشت", "خرداد", "تير", "مرداد", "شهريور", "مهر", "آبان", "آذر", "دي",
				"بهمن", "اسفند"
			};
			int month = persianCalendar.GetMonth(DateTime.Today);
			return obj[month - 1];
		}
	}

	public static string GetCurrentTextWeekOfDay
	{
		get
		{
			PersianCalendar persianCalendar = new PersianCalendar();
			string[] array = new string[7] { "شنبه", "يکشنبه", "دوشنبه", "سه شنبه", "چهارشنبه", "پنجشنبه", "جمعه" };
			int num = 0;
			switch (persianCalendar.GetDayOfWeek(DateTime.Today))
			{
			case DayOfWeek.Saturday:
				num = 0;
				break;
			case DayOfWeek.Sunday:
				num = 1;
				break;
			case DayOfWeek.Monday:
				num = 2;
				break;
			case DayOfWeek.Tuesday:
				num = 3;
				break;
			case DayOfWeek.Wednesday:
				num = 4;
				break;
			case DayOfWeek.Thursday:
				num = 5;
				break;
			case DayOfWeek.Friday:
				num = 6;
				break;
			}
			return array[num];
		}
	}

	public static int GetCurrentNumberWeekOfDay
	{
		get
		{
			PersianCalendar persianCalendar = new PersianCalendar();
			int result = 0;
			switch (persianCalendar.GetDayOfWeek(DateTime.Today))
			{
			case DayOfWeek.Saturday:
				result = 7;
				break;
			case DayOfWeek.Sunday:
				result = 1;
				break;
			case DayOfWeek.Monday:
				result = 2;
				break;
			case DayOfWeek.Tuesday:
				result = 3;
				break;
			case DayOfWeek.Wednesday:
				result = 4;
				break;
			case DayOfWeek.Thursday:
				result = 5;
				break;
			case DayOfWeek.Friday:
				result = 6;
				break;
			}
			return result;
		}
	}

	public static int GetCurrentIntegerDate
	{
		get
		{
			PersianCalendar persianCalendar = new PersianCalendar();
			int year = persianCalendar.GetYear(DateTime.Today);
			int month = persianCalendar.GetMonth(DateTime.Today);
			int dayOfMonth = persianCalendar.GetDayOfMonth(DateTime.Today);
			string empty = string.Empty;
			string empty2 = string.Empty;
			string empty3 = string.Empty;
			empty = ((year >= 10) ? year.ToString() : $"0{year}");
			empty2 = ((month >= 10) ? month.ToString() : $"0{month}");
			empty3 = ((dayOfMonth >= 10) ? dayOfMonth.ToString() : $"0{dayOfMonth}");
			return Convert.ToInt32($"{empty}{empty2}{empty3}");
		}
	}

	public static int GetNumberOfPastDaysInCurrentYear => new PersianCalendar().GetDayOfYear(DateTime.Today);

	public static string DeAttacheDate(string GetDate, string GetAct)
	{
		string result = null;
		try
		{
			GetDate = GetDate.Replace("/", "").Replace(".", "").Replace("،", "")
				.Replace("\\", "")
				.Replace("-", "")
				.Replace("_", "");
			int.Parse(GetDate);
			if (GetAct == "Y")
			{
				result = GetDate.Substring(0, 4);
			}
			if (GetAct == "M")
			{
				result = GetDate.Substring(4, 2);
			}
			if (GetAct == "D")
			{
				result = GetDate.Substring(6, 2);
			}
		}
		catch
		{
			result = "خطا";
		}
		return result;
	}

	public static int DeAttacheDate(int GetDate, string GetAct)
	{
		string value = null;
		try
		{
			int.Parse(GetDate.ToString());
			string text = GetDate.ToString();
			if (GetAct == "Y")
			{
				value = text.Substring(0, 4);
			}
			if (GetAct == "M")
			{
				value = text.Substring(4, 2);
			}
			if (GetAct == "D")
			{
				value = text.Substring(6, 2);
			}
		}
		catch
		{
			value = "0";
		}
		return Convert.ToInt32(value);
	}

	public static string GetFormatetdDate(string PersianDate_YyyyMmDd, char? format = null)
	{
		if (!format.HasValue)
		{
			format = '/';
		}
		string[] obj = new string[5]
		{
			DeAttacheDate(PersianDate_YyyyMmDd, "Y"),
			null,
			null,
			null,
			null
		};
		char? c = format;
		obj[1] = c.ToString();
		obj[2] = DeAttacheDate(PersianDate_YyyyMmDd, "M");
		c = format;
		obj[3] = c.ToString();
		obj[4] = DeAttacheDate(PersianDate_YyyyMmDd, "D");
		return string.Concat(obj);
	}

	public static string GetShamsi2Miladi(string PersianDate_YyyyMmDd)
	{
		string text = null;
		PersianCalendar persianCalendar = new PersianCalendar();
		PersianDate_YyyyMmDd = PersianDate_YyyyMmDd.Replace(" ", "");
		try
		{
			string text2 = PersianDate_YyyyMmDd.Substring(0, 4);
			string text3 = PersianDate_YyyyMmDd.Substring(4, 2);
			string text4 = PersianDate_YyyyMmDd.Substring(6, 2);
			PersianDate_YyyyMmDd = text2 + "/" + text3 + "/" + text4;
			int.Parse(PersianDate_YyyyMmDd.Replace("/", ""));
			string s = persianCalendar.ToDateTime(Convert.ToInt32(text2), Convert.ToInt32(text3), Convert.ToInt32(text4), 0, 0, 0, 0).ToString();
			text = $"{DateTime.Parse(s):yyyy/MM/dd}";
			text = text.Replace(" ", "");
			text2 = text.Substring(0, 4);
			text3 = text.Substring(5, 2);
			text4 = text.Substring(8, 2);
			return text2 + "/" + text3 + "/" + text4;
		}
		catch
		{
			return "خطا";
		}
	}

	public static string GetShamsi2MiladiWithSlash(string PersianDate_YyyyMmDd)
	{
		string text = null;
		PersianCalendar persianCalendar = new PersianCalendar();
		PersianDate_YyyyMmDd = PersianDate_YyyyMmDd.Replace(" ", "");
		try
		{
			string text2 = PersianDate_YyyyMmDd.Substring(0, 4);
			string text3 = PersianDate_YyyyMmDd.Substring(5, 2);
			string text4 = PersianDate_YyyyMmDd.Substring(8, 2);
			PersianDate_YyyyMmDd = text2 + "/" + text3 + "/" + text4;
			int.Parse(PersianDate_YyyyMmDd.Replace("/", ""));
			string s = persianCalendar.ToDateTime(Convert.ToInt32(text2), Convert.ToInt32(text3), Convert.ToInt32(text4), 0, 0, 0, 0).ToString();
			text = $"{DateTime.Parse(s):yyyy/MM/dd}";
			text = text.Replace(" ", "");
			text2 = text.Substring(0, 4);
			text3 = text.Substring(5, 2);
			text4 = text.Substring(8, 2);
			return text2 + "/" + text3 + "/" + text4;
		}
		catch
		{
			return "خطا";
		}
	}

	public static string GetShamsi2Miladi(int PersianYear, int PersianMonth, int PersianDay)
	{
		string text = null;
		PersianCalendar persianCalendar = new PersianCalendar();
		if (PersianYear > 9998 || PersianMonth > 12 || PersianDay > 31)
		{
			return "خطا";
		}
		try
		{
			DateTime dateTime = persianCalendar.ToDateTime(PersianYear, PersianMonth, PersianDay, 0, 0, 0, 0);
			return $"{dateTime:yyyy/MM/dd}";
		}
		catch
		{
			return "خطا";
		}
	}

	public static bool GetKabiseh(int PersianYear)
	{
		bool result = false;
		if (new PersianCalendar().GetDaysInYear(PersianYear) == 366)
		{
			result = true;
		}
		return result;
	}

	public static bool GetKabiseh()
	{
		return GetKabiseh(new PersianCalendar().GetYear(DateTime.Today));
	}

	public static int GetNumberOfDaysInMonth(int PersianYear, int PersianMonth)
	{
		return new PersianCalendar().GetDaysInMonth(PersianYear, PersianMonth);
	}

	public static int GetNumberOfMonth(int Month)
	{
		int result = 0;
		switch (Month)
		{
		case 1:
		case 2:
		case 3:
		case 4:
		case 5:
		case 6:
			result = 31;
			break;
		case 7:
		case 8:
		case 9:
		case 10:
		case 11:
			result = 30;
			break;
		case 12:
			result = ((!GetKabiseh()) ? 29 : 30);
			break;
		}
		return result;
	}

	public static int GetNumberOfMonth(int Month, int PersianYear)
	{
		int result = 0;
		switch (Month)
		{
		case 1:
		case 2:
		case 3:
		case 4:
		case 5:
		case 6:
			result = 31;
			break;
		case 7:
		case 8:
		case 9:
		case 10:
		case 11:
			result = 30;
			break;
		case 12:
			result = ((!GetKabiseh(PersianYear)) ? 29 : 30);
			break;
		}
		return result;
	}

	public static string ConvertInt2Date(int date)
	{
		if (date.ToString().Length != 8)
		{
			return "error (length argument is not equal 8.)";
		}
		return date.ToString().Insert(4, "/").Insert(7, "/");
	}

	public static string GetMounthName(int month)
	{
		string result = "";
		switch (month)
		{
		case 1:
			result = "فروردين";
			break;
		case 2:
			result = "ارديبهشت";
			break;
		case 3:
			result = "خرداد";
			break;
		case 4:
			result = "تير";
			break;
		case 5:
			result = "مرداد";
			break;
		case 6:
			result = "شهريور";
			break;
		case 7:
			result = "مهر";
			break;
		case 8:
			result = "آبان";
			break;
		case 9:
			result = "آذر";
			break;
		case 10:
			result = "دي";
			break;
		case 11:
			result = "بهمن";
			break;
		case 12:
			result = "اسفند";
			break;
		}
		return result;
	}

	public static int GetNumberWeekOfDay(string PersianDate_YyyyMmDd)
	{
		int result = 0;
		string text = GetShamsi2MiladiWithSlash(PersianDate_YyyyMmDd) + " 12:00:00";
		if (text.Contains("خطا"))
		{
			text = GetShamsi2MiladiWithSlash(GetCurrentDate) + " 12:00:00";
		}
		PersianCalendar persianCalendar = new PersianCalendar();
		DateTime time = DateTime.ParseExact(text, "yyyy/MM/dd hh:mm:ss", CultureInfo.CurrentCulture);
		switch (persianCalendar.GetDayOfWeek(time))
		{
		case DayOfWeek.Saturday:
			result = 7;
			break;
		case DayOfWeek.Sunday:
			result = 1;
			break;
		case DayOfWeek.Monday:
			result = 2;
			break;
		case DayOfWeek.Tuesday:
			result = 3;
			break;
		case DayOfWeek.Wednesday:
			result = 4;
			break;
		case DayOfWeek.Thursday:
			result = 5;
			break;
		case DayOfWeek.Friday:
			result = 6;
			break;
		}
		return result;
	}

	public static string GetTextWeekOfDay(string PersianDate_YyyyMmDd)
	{
		string text = GetShamsi2Miladi(PersianDate_YyyyMmDd) + " 12:00:00";
		if (text.Contains("خطا"))
		{
			text = GetShamsi2Miladi(GetCurrentDate) + " 12:00:00";
		}
		PersianCalendar persianCalendar = new PersianCalendar();
		string[] array = new string[7] { "شنبه", "يکشنبه", "دوشنبه", "سه شنبه", "چهارشنبه", "پنجشنبه", "جمعه" };
		int num = 0;
		DateTime time = DateTime.ParseExact(text, "yyyy/MM/dd hh:mm:ss", CultureInfo.CurrentCulture);
		switch (persianCalendar.GetDayOfWeek(time))
		{
		case DayOfWeek.Saturday:
			num = 0;
			break;
		case DayOfWeek.Sunday:
			num = 1;
			break;
		case DayOfWeek.Monday:
			num = 2;
			break;
		case DayOfWeek.Tuesday:
			num = 3;
			break;
		case DayOfWeek.Wednesday:
			num = 4;
			break;
		case DayOfWeek.Thursday:
			num = 5;
			break;
		case DayOfWeek.Friday:
			num = 6;
			break;
		}
		return array[num];
	}

	public static string GetTextWeekOfDay(int Persian_Year, int Persian_Month, int Persian_Day)
	{
		string text = "";
		string text2 = "";
		string text3 = "";
		text = ((Persian_Year < 1000) ? ("0" + Persian_Year) : ((Persian_Year < 100) ? ("00" + Persian_Year) : ((Persian_Year >= 10) ? Persian_Year.ToString() : ("000" + Persian_Year))));
		text2 = ((Persian_Month >= 10) ? Persian_Month.ToString() : ("0" + Persian_Month));
		text3 = ((Persian_Day >= 10) ? Persian_Day.ToString() : ("0" + Persian_Day));
		return GetTextWeekOfDay(text + "/" + text2 + "/" + text3);
	}

	public static double GetDifferenceBetween2Date(string First_PersianDate_YyyyMmDd, string Second_PersianDate_YyyyMmDd)
	{
		First_PersianDate_YyyyMmDd = GetShamsi2Miladi(First_PersianDate_YyyyMmDd);
		Second_PersianDate_YyyyMmDd = GetShamsi2Miladi(Second_PersianDate_YyyyMmDd);
		return (DateTime.Parse(Second_PersianDate_YyyyMmDd) - DateTime.Parse(First_PersianDate_YyyyMmDd)).TotalDays;
	}

	public static string GetInsertedDays2Date(int Persian_Year, int Persian_Month, int Persian_Day, double Days)
	{
		string shamsi2Miladi = GetShamsi2Miladi(Persian_Year, Persian_Month, Persian_Day);
		return GetMiladi2Shamsi($"{DateTime.Parse(shamsi2Miladi).AddDays(Days):yyyy/MM/dd}");
	}

	public static string GetInsertedDays2Date(string PersianDate_YyyyMmDd, double Days)
	{
		PersianDate_YyyyMmDd = GetShamsi2Miladi(PersianDate_YyyyMmDd);
		return GetMiladi2Shamsi($"{DateTime.Parse(PersianDate_YyyyMmDd).AddDays(Days):yyyy/MM/dd}");
	}

	public static string GetMiladi2Shamsi(string MiladiDate_YyyyMmDd)
	{
		string text = "";
		try
		{
			PersianCalendar persianCalendar = new PersianCalendar();
			DateTime time = Convert.ToDateTime(MiladiDate_YyyyMmDd);
			int year = persianCalendar.GetYear(time);
			int month = persianCalendar.GetMonth(time);
			int dayOfMonth = persianCalendar.GetDayOfMonth(time);
			string empty = string.Empty;
			string empty2 = string.Empty;
			string empty3 = string.Empty;
			empty = ((year >= 10) ? year.ToString() : $"0{year}");
			empty2 = ((month >= 10) ? month.ToString() : $"0{month}");
			empty3 = ((dayOfMonth >= 10) ? dayOfMonth.ToString() : $"0{dayOfMonth}");
			return $"{empty}/{empty2}/{empty3}";
		}
		catch
		{
			return "خطا";
		}
	}

	public static string GetMiladi2Shamsi(DateTime MiladiDate)
	{
		return GetMiladi2Shamsi($"{MiladiDate:yyyy/MM/dd}");
	}

	public static int GetNumberWeekOfDayInDate(int Persian_Year, int Persian_Month, int Persian_Day)
	{
		string text = "";
		string text2 = "";
		string text3 = "";
		text = ((Persian_Year < 1000) ? ("0" + Persian_Year) : ((Persian_Year < 100) ? ("00" + Persian_Year) : ((Persian_Year >= 10) ? Persian_Year.ToString() : ("000" + Persian_Year))));
		text2 = ((Persian_Month >= 10) ? Persian_Month.ToString() : ("0" + Persian_Month));
		text3 = ((Persian_Day >= 10) ? Persian_Day.ToString() : ("0" + Persian_Day));
		return GetNumberWeekOfDayInDate(text + "/" + text2 + "/" + text3);
	}

	public static int GetNumberWeekOfDayInDate(string PersianDate_YyyyMmDd)
	{
		int result = 0;
		string text = GetShamsi2Miladi(PersianDate_YyyyMmDd) + " 12:00:00";
		if (text.Contains("خطا"))
		{
			text = GetShamsi2Miladi(GetCurrentDate) + " 12:00:00";
		}
		PersianCalendar persianCalendar = new PersianCalendar();
		DateTime time = DateTime.ParseExact(text, "yyyy/MM/dd hh:mm:ss", CultureInfo.CurrentCulture);
		switch (persianCalendar.GetDayOfWeek(time))
		{
		case DayOfWeek.Saturday:
			result = 7;
			break;
		case DayOfWeek.Sunday:
			result = 1;
			break;
		case DayOfWeek.Monday:
			result = 2;
			break;
		case DayOfWeek.Tuesday:
			result = 3;
			break;
		case DayOfWeek.Wednesday:
			result = 4;
			break;
		case DayOfWeek.Thursday:
			result = 5;
			break;
		case DayOfWeek.Friday:
			result = 6;
			break;
		}
		return result;
	}

	public static string GetFormatetdDate(int Persian_Year, int Persian_Month, int Persian_Day)
	{
		string text = "";
		string text2 = "";
		string text3 = "";
		text = ((Persian_Year < 1000) ? ("0" + Persian_Year) : ((Persian_Year < 100) ? ("00" + Persian_Year) : ((Persian_Year >= 10) ? Persian_Year.ToString() : ("000" + Persian_Year))));
		text2 = ((Persian_Month >= 10) ? Persian_Month.ToString() : ("0" + Persian_Month));
		text3 = ((Persian_Day >= 10) ? Persian_Day.ToString() : ("0" + Persian_Day));
		return text + "/" + text2 + "/" + text3;
	}

	public static string GetTextDate(DateTime MiladiDate)
	{
		PersianCalendar persianCalendar = new PersianCalendar();
		string[] array = new string[7] { "شنبه", "يکشنبه", "دوشنبه", "سه شنبه", "چهارشنبه", "پنجشنبه", "جمعه" };
		string[] array2 = new string[12]
		{
			"فروردين", "ارديبهشت", "خرداد", "تير", "مرداد", "شهريور", "مهر", "آبان", "آذر", "دي",
			"بهمن", "اسفند"
		};
		int month = persianCalendar.GetMonth(MiladiDate);
		int num = 0;
		switch (persianCalendar.GetDayOfWeek(MiladiDate))
		{
		case DayOfWeek.Saturday:
			num = 0;
			break;
		case DayOfWeek.Sunday:
			num = 1;
			break;
		case DayOfWeek.Monday:
			num = 2;
			break;
		case DayOfWeek.Tuesday:
			num = 3;
			break;
		case DayOfWeek.Wednesday:
			num = 4;
			break;
		case DayOfWeek.Thursday:
			num = 5;
			break;
		case DayOfWeek.Friday:
			num = 6;
			break;
		}
		return $"{array[num]} {persianCalendar.GetDayOfMonth(MiladiDate)} {array2[month - 1]} {persianCalendar.GetYear(MiladiDate)}";
	}

	public static string GetTextDate(string PersianDate_YyyyMmDd)
	{
		try
		{
			string[] array = PersianDate_YyyyMmDd.Split(new char[1] { '/' });
			return GetTextDate(int.Parse(array[0]), int.Parse(array[1]), int.Parse(array[2]));
		}
		catch
		{
			return "خطا";
		}
	}

	public static string GetTextDate(int Persian_Year, int Persian_Month, int Persian_Day)
	{
		try
		{
			string[] array = new string[12]
			{
				"فروردين", "ارديبهشت", "خرداد", "تير", "مرداد", "شهريور", "مهر", "آبان", "آذر", "دي",
				"بهمن", "اسفند"
			};
			return $"{GetTextWeekOfDay(Persian_Year, Persian_Month, Persian_Day)} {Persian_Day} {array[Persian_Month - 1]} {Persian_Year}";
		}
		catch
		{
			return "خطا";
		}
	}

	public static string GetPersianDayOfWeek(string dayOfWeek)
	{
		string text = "";
		return dayOfWeek.ToLower() switch
		{
			"saturday" => "شنبه", 
			"sunday" => "یکشنبه", 
			"monday" => "دوشنبه", 
			"tuesday" => "سه شنبه", 
			"wednesday" => "چهارشنبه", 
			"thursday" => "پنجشنبه", 
			"friday" => "جمعه", 
			_ => dayOfWeek, 
		};
	}
}

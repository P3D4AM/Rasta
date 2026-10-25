using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Calendar;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Elmah;

namespace CRMIdeal.Classes;

public static class DateTimeClass
{
	public static string DefineDayeOfWeekPersian(string day)
	{
		return day switch
		{
			"Saturday" => Labels.Saturday, 
			"Sunday" => Labels.Sunday, 
			"Monday" => Labels.Monday, 
			"Tuesday" => Labels.Tuesday, 
			"Wednesday" => Labels.Wednesday, 
			"Thursday" => Labels.Thursday, 
			"Friday" => Labels.Friday, 
			_ => day, 
		};
	}

	public static string DefineDayeOfWeek(string day)
	{
		return day switch
		{
			"Saturday" => "1", 
			"Sunday" => "2", 
			"Monday" => "3", 
			"Tuesday" => "4", 
			"Wednesday" => "5", 
			"Thursday" => "6", 
			"Friday" => "7", 
			_ => null, 
		};
	}

	public static string DefineDayeOfWeekStartWith7(string day)
	{
		return day switch
		{
			"Saturday" => "7", 
			"Sunday" => "1", 
			"Monday" => "2", 
			"Tuesday" => "3", 
			"Wednesday" => "4", 
			"Thursday" => "5", 
			"Friday" => "6", 
			_ => null, 
		};
	}

	public static string DefineDayeOfWeekFa(string day)
	{
		return day switch
		{
			"Saturday" => Labels.Saturday, 
			"Sunday" => Labels.Sunday, 
			"Monday" => Labels.Monday, 
			"Tuesday" => Labels.Tuesday, 
			"Wednesday" => Labels.Wednesday, 
			"Thursday" => Labels.Thursday, 
			"Friday" => Labels.Friday, 
			_ => null, 
		};
	}

	public static string ConvertNumToDayeOfWeek(int num)
	{
		return num switch
		{
			7 => Labels.Saturday, 
			1 => Labels.Sunday, 
			2 => Labels.Monday, 
			3 => Labels.Tuesday, 
			4 => Labels.Wednesday, 
			5 => Labels.Thursday, 
			6 => Labels.Friday, 
			_ => null, 
		};
	}

	public static string ConvertNumToDayeOfWeek(string num)
	{
		return num switch
		{
			"7" => Labels.Saturday, 
			"1" => Labels.Sunday, 
			"2" => Labels.Monday, 
			"3" => Labels.Tuesday, 
			"4" => Labels.Wednesday, 
			"5" => Labels.Thursday, 
			"6" => Labels.Friday, 
			_ => num, 
		};
	}

	public static int GetDayNumberFormZiro(string day)
	{
		return day switch
		{
			"Sunday" => 0, 
			"Monday" => 1, 
			"Tuesday" => 2, 
			"Wednesday" => 3, 
			"Thursday" => 4, 
			"Friday" => 5, 
			"Saturday" => 6, 
			_ => 0, 
		};
	}

	public static string ConvertDateWOSlashToSlash(string dateWithoutSlash)
	{
		if (!string.IsNullOrEmpty(dateWithoutSlash) && dateWithoutSlash.Length == 8)
		{
			dateWithoutSlash = dateWithoutSlash.Insert(4, "/");
			dateWithoutSlash = dateWithoutSlash.Insert(7, "/");
		}
		return dateWithoutSlash;
	}

	public static string CheckDate(string date)
	{
		try
		{
			if (!string.IsNullOrEmpty(date))
			{
				date = PersianDate.GetFormatetdDate(date.Replace("/", "").Replace("-", ""));
				date = DateTime.Parse(date).ToString("yyyyMMdd");
			}
			else
			{
				date = "";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			date = "";
		}
		return date;
	}

	public static string ConvertPerToEnWithLine(string date)
	{
		GregorianCalendar obj = new GregorianCalendar
		{
			CalendarType = GregorianCalendarTypes.USEnglish
		};
		string text = obj.GetYear(DateTime.Parse(date)).ToString();
		string text2 = obj.GetMonth(DateTime.Parse(date)).ToString();
		text2 = ((text2.Length == 1) ? ("0" + text2) : text2);
		string text3 = obj.GetDayOfMonth(DateTime.Parse(date)).ToString();
		text3 = ((text3.Length == 1) ? ("0" + text3) : text3);
		date = text + "-" + text2 + "-" + text3;
		return date;
	}

	public static DateTime ConvertEnToPerWithLine(DateTime date)
	{
		PersianCulture persianCulture = new PersianCulture();
		persianCulture.DateTimeFormat.ShortDatePattern = "yyyy/MM/dd";
		persianCulture.DateTimeFormat.LongDatePattern = "dddd d MMMM yyyy";
		persianCulture.DateTimeFormat.AMDesignator = "صبح";
		persianCulture.DateTimeFormat.PMDesignator = "عصر";
		Thread.CurrentThread.CurrentCulture = persianCulture;
		Thread.CurrentThread.CurrentUICulture = persianCulture;
		return DateTime.ParseExact(date.ToString("yyyy-MM-dd HH:mm:ss"), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
	}

	public static string DefineDayeOfWeekFaWithoutNull(string day)
	{
		return day switch
		{
			"Saturday" => Labels.Saturday, 
			"Sunday" => Labels.Sunday, 
			"Monday" => Labels.Monday, 
			"Tuesday" => Labels.Tuesday, 
			"Wednesday" => Labels.Wednesday, 
			"Thursday" => Labels.Thursday, 
			"Friday" => Labels.Friday, 
			_ => day, 
		};
	}

	public static string GetPersianDate(DateTime d)
	{
		return d.ToString("yyyy/MM/dd dddd");
	}

	public static long ConvertHourAndMinToSec(int hours, int min)
	{
		return (long)(hours * 60 * 60) + (long)(min * 60);
	}

	public static string ConvertSecToHourAndMin(long sec)
	{
		string result = "";
		try
		{
			long num = sec / 60 / 60;
			long num2 = sec / 60 % 60;
			result = ((num <= 9) ? ("0" + num) : num.ToString()) + ":" + ((num2 <= 9) ? ("0" + num2) : num2.ToString());
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public static string ConvertSecToYearMonthDayHourMinSec(long sec)
	{
		string text = "";
		try
		{
			if (sec != 0L)
			{
				TimeSpan timeSpan = TimeSpan.FromSeconds(sec);
				string and = Labels.And;
				int days = timeSpan.Days;
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				if (days > 0)
				{
					num = days / 365;
					num2 = days % 365 / 30;
					num3 = days % 365 % 30;
				}
				if (num > 0)
				{
					if (!string.IsNullOrWhiteSpace(text))
					{
						text = text + " " + and + " ";
					}
					text = text + num + " " + Labels.Year;
				}
				if (num2 > 0)
				{
					if (!string.IsNullOrWhiteSpace(text))
					{
						text = text + " " + and + " ";
					}
					text = text + num2 + " " + Labels.Month;
				}
				if (num3 > 0)
				{
					if (!string.IsNullOrWhiteSpace(text))
					{
						text = text + " " + and + " ";
					}
					text = text + num3 + " " + Labels.Day;
				}
				if (timeSpan.Hours > 0)
				{
					if (!string.IsNullOrWhiteSpace(text))
					{
						text = text + " " + and + " ";
					}
					text = text + $"{timeSpan.Hours:D2}" + " " + Labels.Hour;
				}
				if (timeSpan.Minutes > 0)
				{
					if (!string.IsNullOrWhiteSpace(text))
					{
						text = text + " " + and + " ";
					}
					text = text + $"{timeSpan.Minutes:D2}" + " " + Labels.Minute;
				}
				if (timeSpan.Seconds > 0)
				{
					if (!string.IsNullOrWhiteSpace(text))
					{
						text = text + " " + and + " ";
					}
					text = text + $"{timeSpan.Seconds:D2}" + " " + Labels.Second;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text;
	}

	public static string ConvertMinToHourAndMin(long min)
	{
		string text = "";
		try
		{
			if (min != 0L)
			{
				TimeSpan timeSpan = TimeSpan.FromMinutes(min);
				if (timeSpan.Hours > 0)
				{
					text = (int)timeSpan.TotalHours + " " + Labels.lblHour;
				}
				if (timeSpan.Minutes > 0)
				{
					if (!string.IsNullOrEmpty(text))
					{
						text = text + " " + Labels.And + " ";
					}
					text = text + timeSpan.Minutes + " " + Labels.lblMinute;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text;
	}

	public static string DateDifferenceInDayText(DateTime? StartDate, DateTime? EndDate, bool? emptyForZero = false)
	{
		string result = "";
		try
		{
			if (StartDate.HasValue && EndDate.HasValue)
			{
				int days = (StartDate.Value.Date - EndDate.Value.Date).Days;
				if (days > -28 && days <= -58)
				{
					result = Labels.lblLastMonth;
				}
				else if (days > -21 && days <= -28)
				{
					result = Labels.lblThreeWeeksAgo;
				}
				else if (days > -14 && days <= -21)
				{
					result = Labels.lblTwoWeeksAgo;
				}
				else if (days > -7 && days <= -14)
				{
					result = Labels.lblLastWeek;
				}
				else
				{
					switch (days)
					{
					case -7:
						result = Labels.lblSevenDaysAgo;
						break;
					case -6:
						result = Labels.lblSixDaysAgo;
						break;
					case -5:
						result = Labels.lblFiveDaysAgo;
						break;
					case -4:
						result = Labels.lblFourDaysAgo;
						break;
					case -3:
						result = Labels.lblThreeDaysAgo;
						break;
					case -2:
						result = Labels.lblTheDayBeforeYesterday;
						break;
					case -1:
						result = Labels.lblYesterday;
						break;
					case 0:
						result = ((!emptyForZero.GetValueOrDefault()) ? Labels.lblToday : (result = ""));
						break;
					case 1:
						result = Labels.lblTomorrow;
						break;
					case 2:
						result = Labels.lblTheDayAfterTomorrow;
						break;
					case 3:
						result = Labels.lblThreeDaysLater;
						break;
					case 4:
						result = Labels.lblFourDaysLater;
						break;
					case 5:
						result = Labels.lblFiveDaysLater;
						break;
					case 6:
						result = Labels.lblSixDaysLater;
						break;
					case 7:
						result = Labels.lblSevenDaysLater;
						break;
					case 8:
					case 9:
					case 10:
					case 11:
					case 12:
					case 13:
					case 14:
						result = Labels.lblNextWeek;
						break;
					default:
						result = ((days > 14 && days <= 21) ? Labels.lblTwoWeeksLater : ((days > 21 && days <= 28) ? Labels.lblThreeWeeksLater : ((days <= 28 || days > 58) ? "" : Labels.lblNextMonth)));
						break;
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public static DateTime? GetDateFromPersian(string dtPersian)
	{
		DateTime? dateTime = null;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (!string.IsNullOrEmpty(dtPersian))
			{
				dtPersian = PersianDate.GetFormatetdDate(dtPersian.Replace("/", ""));
				return lCID switch
				{
					1065 => DateTime.Parse(dtPersian + " 00:00:00", new PersianCulture()), 
					1025 => DateTime.Parse(dtPersian + " 00:00:00", new CultureInfo("ar-SA")), 
					_ => DateTime.Parse(dtPersian + " 00:00:00", new CultureInfo("en-US")), 
				};
			}
			dateTime = null;
		}
		catch (Exception)
		{
			dateTime = null;
		}
		return dateTime;
	}

	public static DateTime? GetLocalDate(DateTime? dateTime)
	{
		DateTime? dateTime2 = null;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			string text = (dateTime.HasValue ? dateTime.Value.ToString("yyyy/MM/dd") : null);
			if (!string.IsNullOrEmpty(text))
			{
				return lCID switch
				{
					1065 => DateTime.Parse(text + " " + dateTime.Value.ToString("HH:mm:ss"), new PersianCulture()), 
					1025 => DateTime.Parse(text + " " + dateTime.Value.ToString("HH:mm:ss"), new CultureInfo("ar-SA")), 
					_ => DateTime.Parse(text + " " + dateTime.Value.ToString("HH:mm:ss"), new CultureInfo("en-US")), 
				};
			}
			dateTime2 = null;
		}
		catch (Exception)
		{
			dateTime2 = null;
		}
		return dateTime2;
	}

	public static DateTime? GetDateFromQamari(string dtStr)
	{
		DateTime? result = null;
		try
		{
			if (!string.IsNullOrEmpty(dtStr))
			{
				dtStr = PersianDate.GetFormatetdDate(dtStr.Replace("/", ""));
				return DateTime.Parse(dtStr + " 00:00:00", new CultureInfo("ar-SA"));
			}
		}
		catch (Exception)
		{
			result = null;
		}
		return result;
	}

	public static DateTime? GetDateFromMiladi(string dtStr)
	{
		DateTime? result = null;
		try
		{
			if (!string.IsNullOrEmpty(dtStr))
			{
				dtStr = PersianDate.GetFormatetdDate(dtStr.Replace("/", ""));
				return DateTime.Parse(dtStr + " 00:00:00", new CultureInfo("en-US"));
			}
		}
		catch (Exception)
		{
			result = null;
		}
		return result;
	}

	public static List<SelectListItem> GetMonths(int langId = 0)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			_ = DateTime.Now;
			if (langId == 0)
			{
				langId = lCID;
			}
			string[] monthNames = new CultureInfo(langId).DateTimeFormat.MonthNames;
			for (int i = 0; i < monthNames.Length; i++)
			{
				if (!string.IsNullOrWhiteSpace(monthNames[i]))
				{
					list.Add(new SelectListItem
					{
						Text = monthNames[i],
						Value = (i + 1).ToString("00")
					});
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return list;
	}

	public static List<SelectListItem> GetDaysInWeek(int lcid = 0)
	{
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		if (lcid == 0)
		{
			lcid = lCID;
		}
		new List<SelectListItem>();
		CultureInfo culture = new CultureInfo(lcid);
		List<SelectListItem> list = Enumerable.ToList<SelectListItem>(Enumerable.Select<DayOfWeek, SelectListItem>(Enumerable.Cast<DayOfWeek>((IEnumerable)Enum.GetValues(typeof(DayOfWeek))), (Func<DayOfWeek, SelectListItem>)delegate(DayOfWeek d)
		{
			SelectListItem obj = new SelectListItem
			{
				Text = culture.DateTimeFormat.DayNames[(int)d]
			};
			int num = (int)d;
			obj.Value = num.ToString();
			return obj;
		}));
		DayOfWeek firstDayOfWeek = culture.DateTimeFormat.FirstDayOfWeek;
		return Enumerable.ToList<SelectListItem>(Enumerable.Concat<SelectListItem>(Enumerable.Skip<SelectListItem>((IEnumerable<SelectListItem>)list, (int)firstDayOfWeek), Enumerable.Take<SelectListItem>((IEnumerable<SelectListItem>)list, (int)firstDayOfWeek)));
	}

	public static int GetDayOfWeekNum(string dtPersian = "", DateTime? dt = null, bool sqlFormat = false)
	{
		int num = -1;
		if (!string.IsNullOrWhiteSpace(dtPersian))
		{
			dt = GetDateFromPersian(dtPersian);
		}
		if (dt.HasValue)
		{
			num = (int)(dt?.DayOfWeek).Value;
		}
		if (sqlFormat && num != -1)
		{
			num++;
		}
		return num;
	}

	public static string GetMinuteInFormat(int minute = 0, string format = "yyyy/MM/dd HH:mm")
	{
		int num = minute;
		minute = Math.Abs(minute);
		string text = format;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		if (minute != 0)
		{
			if (minute > 60)
			{
				num5 = minute / 60;
				num6 = minute % 60;
				if (num5 > 24)
				{
					num4 = num5 / 24;
					num5 %= 24;
				}
				if (num4 > 31)
				{
					num3 = num4 / 31;
					num4 %= 31;
				}
			}
			else
			{
				num6 = minute;
			}
		}
		text = text.Replace("yyyy", num2.ToString("0000")).Replace("MM", num3.ToString("00")).Replace("dd", num4.ToString("00"))
			.Replace("HH", num5.ToString("00"))
			.Replace("mm", num6.ToString("00"));
		text = text.Replace("0000/", "");
		text = text.Replace("00/", "");
		text = text.Replace("00 ", "");
		if (num < 0)
		{
			text = "-" + text;
		}
		return text;
	}

	public static List<DateTime> GetFirstDayOfMonths(DateTime startDate, DateTime endDate, int currentLanguageId = 1065)
	{
		List<DateTime> list = new List<DateTime>();
		string text = "fa-IR";
		Calendar calendar = new CultureInfo(currentLanguageId switch
		{
			1065 => "fa-IR", 
			1025 => "ar-SA", 
			1031 => "de-DE", 
			1055 => "tr-TR", 
			_ => "en-US", 
		}).Calendar;
		if (startDate > endDate)
		{
			DateTime dateTime = startDate;
			startDate = endDate;
			endDate = dateTime;
		}
		DateTime time = calendar.AddMonths(startDate, 0);
		time = calendar.AddDays(time, -calendar.GetDayOfMonth(time) + 1);
		while (time <= endDate)
		{
			list.Add(time);
			time = calendar.AddMonths(time, 1);
		}
		return list;
	}

	public static int GetMinuteFromTime(string Time)
	{
		int result = 0;
		if (!string.IsNullOrWhiteSpace(Time))
		{
			List<string> list = Enumerable.ToList<string>((IEnumerable<string>)Time.Split(new char[1] { ':' }));
			int.TryParse(list[0], out var result2);
			int.TryParse(list[1], out var result3);
			result = result2 * 60 + result3;
		}
		return result;
	}
}

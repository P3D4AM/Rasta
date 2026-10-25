using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Calendar;
using CRM.Resources;
using Elmah;
using GSD.Globalization;
using Mobile.Cache.Setting;

namespace Mobile.Classes.Helper;

public static class DateTimeClass
{
	public static string GetDayName(string day)
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

	public static string ConvertNumToDayName(int num)
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

	public static string ConvertNameToDayNum(string dayName)
	{
		return dayName switch
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

	public static string ConvertDateWoSlashToSlash(string dateWithoutSlash)
	{
		if (!string.IsNullOrEmpty(dateWithoutSlash) && dateWithoutSlash.Length == 8)
		{
			dateWithoutSlash = dateWithoutSlash.Insert(4, "/");
			dateWithoutSlash = dateWithoutSlash.Insert(7, "/");
		}
		return dateWithoutSlash;
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

	public static List<SelectListItem> GetDatesOfWeek(DateTime date)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		DateTime dateTime = DateTime.Today;
		if (lCID == 1025)
		{
			dateTime = dateTime.AddDays(-1.0);
		}
		int num = 0;
		switch (lCID)
		{
		case 1065:
			num = 1;
			break;
		case 1033:
			num = 1;
			break;
		case 1025:
			num = 2;
			break;
		}
		int dayOfWeek = (int)date.DayOfWeek;
		DateTime dateTime2 = date.AddDays(-1 * dayOfWeek - num);
		if (lCID == 1065 && dayOfWeek == 6)
		{
			dateTime2 = dateTime2.AddDays(7.0);
		}
		List<SelectListItem> list = new List<SelectListItem>();
		for (int i = 0; i < 7; i++)
		{
			list.Add(new SelectListItem
			{
				Text = dateTime2.AddDays(i).ToString("yyyy/MM/dd"),
				Value = ((int)dateTime2.AddDays(i).DayOfWeek).ToString(),
				Selected = (dateTime2.AddDays(i).ToString("yyyy/MM/dd") == dateTime.ToString("yyyy/MM/dd"))
			});
		}
		return list;
	}

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
}

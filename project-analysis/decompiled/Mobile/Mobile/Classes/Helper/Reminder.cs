using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using CRM.General.Calendar;
using Elmah;
using GSD.Globalization;
using Mobile.Cache.Setting;
using Mobile.Models;

namespace Mobile.Classes.Helper;

public class Reminder
{
	public static List<string> GetDatesOfWeekSelectListItem(string date = "")
	{
		List<string> list = new List<string>();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		DateTime today = DateTime.Today;
		if (lCID == 1025)
		{
			today = today.AddDays(-1.0);
		}
		DateTime dateTime = DateTimeClass.GetDateFromPersian(date) ?? DateTime.Now;
		int num = 0;
		switch (lCID)
		{
		case 1065:
			num = 1;
			break;
		case 1033:
			num = 1;
			break;
		}
		int dayOfWeek = (int)dateTime.DayOfWeek;
		DateTime dateTime2 = dateTime.AddDays(-1 * dayOfWeek - num);
		for (int i = 0; i < 7; i++)
		{
			list.Add(dateTime2.AddDays(i).ToString("yyyy/MM/dd"));
		}
		return list;
	}

	public static List<string> GetDatesOfWeekSelectListItemFromSp(string date = "")
	{
		CRMSpEntities cRMSpEntities = null;
		List<string> list = new List<string>();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int value = ((lCID != 1065 && lCID != 1025) ? 1 : 7);
		DateTime value2 = default(DateTime);
		string text = "";
		try
		{
			if (!string.IsNullOrEmpty(date))
			{
				text = PersianDate.GetFormatetdDate(date.Replace("/", ""));
				value2 = lCID switch
				{
					1065 => DateTime.Parse(text, new PersianCulture()), 
					1025 => DateTime.Parse(text, new CultureInfo("ar-SA")), 
					_ => DateTime.Parse(text, new CultureInfo("en-US")), 
				};
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		try
		{
			cRMSpEntities = new CRMSpEntities();
			List<CRMspSelectCalendarEventWeekDates_Result> list2 = Enumerable.ToList<CRMspSelectCalendarEventWeekDates_Result>((IEnumerable<CRMspSelectCalendarEventWeekDates_Result>)cRMSpEntities.CRMspSelectCalendarEventWeekDates(value2, value, 7));
			if (list2.Count > 0)
			{
				foreach (CRMspSelectCalendarEventWeekDates_Result item in list2)
				{
					if (item.MiladiDate.HasValue)
					{
						list.Add(item.MiladiDate.Value.ToString("yyyy/MM/dd"));
					}
				}
			}
			return list;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			return list;
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
	}
}

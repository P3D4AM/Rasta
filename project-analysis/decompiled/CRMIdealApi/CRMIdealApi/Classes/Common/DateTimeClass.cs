using System;
using System.Globalization;

namespace CRMIdealApi.Classes.Common;

public static class DateTimeClass
{
	public static string GetDayNameByDateTime(int LCID, DateTime dt)
	{
		return CultureInfo.GetCultureInfo(LCID).DateTimeFormat.DayNames[(int)dt.DayOfWeek];
	}

	public static DateTime? ParseGregorianDate(string input)
	{
		if (string.IsNullOrWhiteSpace(input))
		{
			return null;
		}
		try
		{
			return DateTime.ParseExact(input, "yyyy/MM/dd", CultureInfo.InvariantCulture);
		}
		catch
		{
			return null;
		}
	}

	public static string ToPersianDateString(DateTime? gregorianDate)
	{
		if (!gregorianDate.HasValue)
		{
			return null;
		}
		PersianCalendar persianCalendar = new PersianCalendar();
		int year = persianCalendar.GetYear(gregorianDate.Value);
		int month = persianCalendar.GetMonth(gregorianDate.Value);
		int dayOfMonth = persianCalendar.GetDayOfMonth(gregorianDate.Value);
		return $"{year:D4}{month:D2}{dayOfMonth:D2}";
	}
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace GSD.Globalization;

public class PersianCulture : CultureInfo
{
	private readonly Calendar cal;

	private readonly Calendar[] optionals;

	public override Calendar Calendar => cal;

	public override Calendar[] OptionalCalendars => optionals;

	public PersianCulture()
		: this("fa-IR", useUserOverride: true)
	{
	}

	public PersianCulture(string cultureName, bool useUserOverride)
		: base(cultureName, useUserOverride)
	{
		cal = base.OptionalCalendars[0];
		List<Calendar> list = new List<Calendar>();
		list.AddRange(base.OptionalCalendars);
		list.Insert(0, new PersianCalendar());
		Type? typeFromHandle = typeof(DateTimeFormatInfo);
		PropertyInfo property = typeof(Calendar).GetProperty("ID", BindingFlags.Instance | BindingFlags.NonPublic);
		FieldInfo field = typeFromHandle.GetField("optionalCalendars", BindingFlags.Instance | BindingFlags.NonPublic);
		int[] array = new int[list.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = (int)property.GetValue(list[i], null);
		}
		field.SetValue(DateTimeFormat, array);
		optionals = list.ToArray();
		cal = optionals[0];
		DateTimeFormat.Calendar = optionals[0];
		DateTimeFormat.MonthNames = new string[13]
		{
			"فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی",
			"بهمن", "اسفند", ""
		};
		DateTimeFormat.MonthGenitiveNames = new string[13]
		{
			"فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی",
			"بهمن", "اسفند", ""
		};
		DateTimeFormat.AbbreviatedMonthNames = new string[13]
		{
			"فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی",
			"بهمن", "اسفند", ""
		};
		DateTimeFormat.AbbreviatedMonthGenitiveNames = new string[13]
		{
			"فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی",
			"بهمن", "اسفند", ""
		};
		DateTimeFormat.AbbreviatedDayNames = new string[7] { "ی", "د", "س", "چ", "پ", "ج", "ش" };
		DateTimeFormat.ShortestDayNames = new string[7] { "ی", "د", "س", "چ", "پ", "ج", "ش" };
		DateTimeFormat.DayNames = new string[7] { "یکشنبه", "دوشنبه", "ﺳﻪ شنبه", "چهارشنبه", "پنج شنبه", "جمعه", "شنبه" };
		DateTimeFormat.AMDesignator = "ق.ظ";
		DateTimeFormat.PMDesignator = "ب.ظ";
		DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
		DateTimeFormat.LongDatePattern = "yyyy-MM-dd";
		DateTimeFormat.SetAllDateTimePatterns(new string[1] { "yyyy-MM-dd" }, 'd');
		DateTimeFormat.SetAllDateTimePatterns(new string[1] { "dddd, dd MMMM yyyy" }, 'D');
		DateTimeFormat.SetAllDateTimePatterns(new string[1] { "yyyy MMMM" }, 'y');
		DateTimeFormat.SetAllDateTimePatterns(new string[1] { "yyyy MMMM" }, 'Y');
	}
}

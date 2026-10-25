using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Threading;
using CRM.General.Calendar;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.GSD.Globalization;
using Elmah;

namespace CRMIdeal.Classes.Helper;

public class DeliverySchedule
{
	public static int GetDeliveryScheduleCount(int dayNum, string date)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int result2 = 0;
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		try
		{
			DateTime value = default(DateTime);
			DateTime dateTime = default(DateTime);
			string text = "";
			try
			{
				if (!string.IsNullOrEmpty(date))
				{
					text = PersianDate.GetFormatetdDate(date.Replace("/", ""));
					text += " 00:00:00";
					value = lCID switch
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
			List<WSspSelectDeliveryScheduleByDayNumberAndDate_Result> list = Enumerable.ToList<WSspSelectDeliveryScheduleByDayNumberAndDate_Result>((IEnumerable<WSspSelectDeliveryScheduleByDayNumberAndDate_Result>)cRMSpIEntities.WSspSelectDeliveryScheduleByDayNumberAndDate(dayNum, value, lCID, result));
			if (list != null && Enumerable.Any<WSspSelectDeliveryScheduleByDayNumberAndDate_Result>((IEnumerable<WSspSelectDeliveryScheduleByDayNumberAndDate_Result>)list))
			{
				result2 = Enumerable.Count<WSspSelectDeliveryScheduleByDayNumberAndDate_Result>((IEnumerable<WSspSelectDeliveryScheduleByDayNumberAndDate_Result>)list);
			}
		}
		catch (DbEntityValidationException e2)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e2);
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		finally
		{
			cRMSpIEntities.Dispose();
		}
		return result2;
	}

	public static int GetDeliveryScheduleTotalCount()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		int num = 0;
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		try
		{
			int num2 = 0;
			DateTime dateTime = DateTime.Now.AddDays(num2);
			DateTimeClass.GetDayNumberFormZiro(dateTime.ToString("dddd", new CultureInfo("en-US")));
			string[] array = new string[7] { "1", "2", "3", "4", "5", "6", "7" };
			_ = new string[7]
			{
				Labels.Sunday,
				Labels.Monday,
				Labels.Tuesday,
				Labels.Wednesday,
				Labels.Thursday,
				Labels.Friday,
				Labels.Saturday
			};
			_ = new string[7] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
			int num3 = 0;
			int num4 = 0;
			while (num4 < 7)
			{
				int dayNumberFormZiro = DateTimeClass.GetDayNumberFormZiro(dateTime.AddDays(num3).ToString("dddd", new CultureInfo("en-US")));
				string date = dateTime.AddDays(num3).ToString("yyyy/MM/dd");
				int deliveryScheduleCount = GetDeliveryScheduleCount(int.Parse(array[dayNumberFormZiro]), date);
				if (deliveryScheduleCount == 0)
				{
					num3++;
					num4++;
				}
				else
				{
					num += deliveryScheduleCount;
					num3++;
					num4++;
				}
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		finally
		{
			cRMSpIEntities.Dispose();
		}
		return num;
	}

	public static int GetPrdDeliveryScheduleCount(int dayNum, string date, int prdId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int result2 = 0;
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		try
		{
			DateTime value = default(DateTime);
			DateTime dateTime = default(DateTime);
			string text = "";
			try
			{
				if (!string.IsNullOrEmpty(date))
				{
					text = PersianDate.GetFormatetdDate(date.Replace("/", ""));
					text += " 00:00:00";
					value = lCID switch
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
			List<WSspSelectDeliveryScheduleByDayNumberAndDateForPrd_Result> list = Enumerable.ToList<WSspSelectDeliveryScheduleByDayNumberAndDateForPrd_Result>((IEnumerable<WSspSelectDeliveryScheduleByDayNumberAndDateForPrd_Result>)cRMSpIEntities.WSspSelectDeliveryScheduleByDayNumberAndDateForPrd(dayNum, value, prdId.ToString(), lCID, result));
			if (list != null && Enumerable.Any<WSspSelectDeliveryScheduleByDayNumberAndDateForPrd_Result>((IEnumerable<WSspSelectDeliveryScheduleByDayNumberAndDateForPrd_Result>)list))
			{
				result2 = Enumerable.Count<WSspSelectDeliveryScheduleByDayNumberAndDateForPrd_Result>((IEnumerable<WSspSelectDeliveryScheduleByDayNumberAndDateForPrd_Result>)list);
			}
		}
		catch (DbEntityValidationException e2)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e2);
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		finally
		{
			cRMSpIEntities.Dispose();
		}
		return result2;
	}

	public static int GetPrdDeliveryScheduleTotalCount(int prdId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		int num = 0;
		CRMEntities cRMEntities = new CRMEntities();
		try
		{
			int num2 = 0;
			DateTime dateTime = DateTime.Now.AddDays(num2);
			DateTimeClass.GetDayNumberFormZiro(dateTime.ToString("dddd", new CultureInfo("en-US")));
			string[] array = new string[7] { "1", "2", "3", "4", "5", "6", "7" };
			_ = new string[7]
			{
				Labels.Sunday,
				Labels.Monday,
				Labels.Tuesday,
				Labels.Wednesday,
				Labels.Thursday,
				Labels.Friday,
				Labels.Saturday
			};
			_ = new string[7] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
			int num3 = 0;
			int num4 = 0;
			while (num4 < 7)
			{
				int dayNumberFormZiro = DateTimeClass.GetDayNumberFormZiro(dateTime.AddDays(num3).ToString("dddd", new CultureInfo("en-US")));
				string date = dateTime.AddDays(num3).ToString("yyyy/MM/dd");
				int prdDeliveryScheduleCount = GetPrdDeliveryScheduleCount(int.Parse(array[dayNumberFormZiro]), date, prdId);
				if (prdDeliveryScheduleCount == 0)
				{
					num3++;
					num4++;
				}
				else
				{
					num += prdDeliveryScheduleCount;
					num3++;
					num4++;
				}
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		finally
		{
			cRMEntities.Dispose();
		}
		return num;
	}
}

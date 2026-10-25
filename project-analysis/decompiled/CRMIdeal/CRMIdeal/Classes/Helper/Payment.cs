using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using CRM.General.Calendar;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using CRMIdeal.GSD.Globalization;
using Elmah;

namespace CRMIdeal.Classes.Helper;

public class Payment
{
	public static List<InstallmentPayOrderViewModel> InstallmentPayment(decimal totalAmount, string startDate, int installmentCount, int installmentInterval, int currencyUnitId)
	{
		List<InstallmentPayOrderViewModel> list = new List<InstallmentPayOrderViewModel>();
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			if (totalAmount != 0m && !string.IsNullOrWhiteSpace(startDate) && installmentCount > 0 && installmentInterval > 0)
			{
				DateTime dateTime = default(DateTime);
				string text = "";
				DateTime dateTime2 = default(DateTime);
				try
				{
					if (!string.IsNullOrWhiteSpace(startDate))
					{
						text = PersianDate.GetFormatetdDate(startDate.Replace("/", ""));
						switch (lCID)
						{
						case 1065:
							dateTime = DateTime.Parse(text + " 00:00:00", new PersianCulture());
							startDate = dateTime.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime = DateTime.Parse(text + " 00:00:00", new CultureInfo("ar-SA"));
							startDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime = DateTime.Parse(text + " 00:00:00", new CultureInfo("en-US"));
							startDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						dateTime2 = dateTime;
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
				decimal num = default(decimal);
				decimal num2 = totalAmount / (decimal)installmentCount;
				bool result2 = false;
				WSspSelectCurrencyUnitsWithId_Result wSspSelectCurrencyUnitsWithId_Result = Enumerable.FirstOrDefault<WSspSelectCurrencyUnitsWithId_Result>((IEnumerable<WSspSelectCurrencyUnitsWithId_Result>)cRMSpEntities.WSspSelectCurrencyUnitsWithId(currencyUnitId, lCID, result));
				if (wSspSelectCurrencyUnitsWithId_Result != null)
				{
					bool.TryParse(wSspSelectCurrencyUnitsWithId_Result.IsDecimal.ToString(), out result2);
				}
				if (!result2 && num2 != 0m)
				{
					num2 = RoundCalculation.RoundNumber(num2);
				}
				for (int i = 1; i <= installmentCount; i++)
				{
					string dateStr = dateTime2.ToString("yyyy/MM/dd");
					DateTime dateTime3 = dateTime2;
					DateTime dateTime4 = DateTime.Parse(dateTime3.ToString("yyyy/MM/dd"));
					dateTime3 = now;
					DateTime dateTime5 = DateTime.Parse(dateTime3.ToString("yyyy/MM/dd"));
					int value = int.Parse(Math.Round((dateTime4 - dateTime5).TotalDays).ToString());
					InstallmentPayOrderViewModel item = new InstallmentPayOrderViewModel
					{
						Row = i,
						Date = dateTime2,
						DateStr = dateStr,
						Amount = num2,
						Day = value
					};
					list.Add(item);
					num += num2;
					dateTime2 = dateTime2.AddDays(installmentInterval);
				}
				if (num != totalAmount)
				{
					decimal num3 = ((num > totalAmount) ? (num - totalAmount) : (totalAmount - num));
					if (list != null && num3 != 0m && Enumerable.Any<InstallmentPayOrderViewModel>((IEnumerable<InstallmentPayOrderViewModel>)list))
					{
						int num4 = Enumerable.Count<InstallmentPayOrderViewModel>((IEnumerable<InstallmentPayOrderViewModel>)list);
						list[num4 - 1].Amount = list[num4 - 1].Amount - (decimal?)num3;
					}
				}
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return list;
	}
}

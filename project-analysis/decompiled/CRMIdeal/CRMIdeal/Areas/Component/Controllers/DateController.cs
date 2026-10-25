using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Calendar;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Component.Controllers;

public class DateController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	public string GetDates(int? year = null, int? month = null, int? day = null, string clName = "", bool mark = false)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		list.Add(new SelectListItem());
		list.Add(new SelectListItem());
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (!string.IsNullOrWhiteSpace(clName))
			{
				lCID = new CultureInfo(clName).LCID;
			}
			CultureInfo cultureInfo = new CultureInfo(lCID);
			int userId = UserLogin.CurrentUser.UserId;
			year = year ?? int.Parse(DateTime.Now.ToString("yyyy"));
			month = month ?? int.Parse(DateTime.Now.ToString("MM"));
			day = day ?? int.Parse(DateTime.Now.ToString("dd"));
			_ = DateTime.Now;
			string text = year?.ToString("0000") + "/" + month?.ToString("00") + "/01";
			DateTime value = default(DateTime);
			DateTime value2 = default(DateTime);
			if (!string.IsNullOrWhiteSpace(text))
			{
				switch (lCID)
				{
				case 1065:
				{
					text = text.Replace("/", "").Replace("-", "").Replace("\\", "")
						.Replace(" ", "")
						.Replace("_", "");
					PersianCalendar persianCalendar = new PersianCalendar();
					value = persianCalendar.ToDateTime(year.GetValueOrDefault(), month.GetValueOrDefault(), 1, 0, 0, 0, 0);
					value2 = persianCalendar.ToDateTime(day: persianCalendar.GetDaysInMonth(year.GetValueOrDefault(), month.GetValueOrDefault()), year: year.GetValueOrDefault(), month: month.GetValueOrDefault(), hour: 0, minute: 0, second: 0, millisecond: 0);
					break;
				}
				case 1025:
					text = PersianDate.GetFormatetdDate(text.Replace("/", ""));
					value = DateTime.Parse(text, new CultureInfo("ar-SA"));
					_ = value.AddMonths(1).Year.ToString(new CultureInfo("ar-SA")) + "/" + value.AddMonths(1).Month.ToString(new CultureInfo("ar-SA")) + "/01";
					value2 = DateTime.Parse(text, new CultureInfo("ar-SA")).AddMonths(1).AddDays(-1.0);
					break;
				default:
					text = PersianDate.GetFormatetdDate(text.Replace("/", ""));
					value = DateTime.Parse(text, new CultureInfo("en-US"));
					value2 = DateTime.Parse(value.AddMonths(1).Year + "/" + value.AddMonths(1).Month + "/01", new CultureInfo("en-US")).AddDays(-1.0);
					break;
				}
			}
			List<CRMspSelectCalendarEvents_Result> list2 = Enumerable.ToList<CRMspSelectCalendarEvents_Result>((IEnumerable<CRMspSelectCalendarEvents_Result>)_dbII.CRMspSelectCalendarEvents(value, value2, lCID, result));
			if (list2 != null)
			{
				foreach (CRMspSelectCalendarEvents_Result item in list2)
				{
					item.DayNum = (int)(item.MiladiDate?.DayOfWeek).Value;
				}
				list[0].Value = JsonConvert.SerializeObject(list2);
			}
			if (mark)
			{
				List<CRMspSelectLeave_Result> list3 = Enumerable.ToList<CRMspSelectLeave_Result>((IEnumerable<CRMspSelectLeave_Result>)_dbI.CRMspSelectLeave(null, null, null, userId, value, value2, lCID, result, 2, result2));
				if (list3 != null)
				{
					list3 = Enumerable.ToList<CRMspSelectLeave_Result>(Enumerable.Where<CRMspSelectLeave_Result>((IEnumerable<CRMspSelectLeave_Result>)list3, (Func<CRMspSelectLeave_Result, bool>)((CRMspSelectLeave_Result x) => x.VerifierUserId.GetValueOrDefault() != 0 && !x.IsCanceled.GetValueOrDefault() && (!x.ReplaceUserId.HasValue || x.ReplaceUserIsVerified.GetValueOrDefault()))));
					foreach (CRMspSelectLeave_Result item2 in list3)
					{
						item2.CanceledDatePersian = item2.CanceledDate?.ToString("yyyy/MM/dd HH:mm", cultureInfo);
						item2.FirstRegisterDatePersian = item2.FirstRegisterDate?.ToString("yyyy/MM/dd HH:mm", cultureInfo);
						item2.RegisterDatePersian = item2.RegisterDate.ToString("yyyy/MM/dd HH:mm", cultureInfo);
						item2.ReplaceUserVerifiedDatePersian = item2.ReplaceUserVerifiedDate?.ToString("yyyy/MM/dd HH:mm", cultureInfo);
						item2.FromDate = item2.FromDateTime?.ToString("yyyy/MM/dd HH:mm", cultureInfo);
						item2.FromDateI = item2.FromDateTime?.ToString("yyyy/MM/dd", cultureInfo);
						item2.ToDate = item2.ToDateTime?.ToString("yyyy/MM/dd HH:mm", cultureInfo);
						item2.VerifiedRegisterDatePersian = item2.VerifiedRegisterDate?.ToString("yyyy/MM/dd HH:mm", cultureInfo);
					}
					list[1].Value = JsonConvert.SerializeObject(list3);
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return JsonConvert.SerializeObject(list);
	}
}

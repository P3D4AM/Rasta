using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.FormBase.Controllers;

public class CalendarEventsController : Controller
{
	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[LoginAuthorize]
	public ActionResult Index()
	{
		base.ViewBag.lstMonths = DateTimeClass.GetMonths();
		return View();
	}

	[LoginAuthorize]
	public ActionResult InsertEdit(int id = 0)
	{
		CRMspSelectCalendarEventWithId_Result model = new CRMspSelectCalendarEventWithId_Result();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (id != 0)
			{
				model = Enumerable.FirstOrDefault<CRMspSelectCalendarEventWithId_Result>((IEnumerable<CRMspSelectCalendarEventWithId_Result>)_dbII.CRMspSelectCalendarEventWithId(id, lCID, result));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return View(model);
	}

	[HttpPost]
	[LoginAuthorize]
	public string InsertEdit(CRMspSelectCalendarEventWithId_Result vm)
	{
		string text = "";
		try
		{
			if (string.IsNullOrWhiteSpace(vm.JalaliDateStr))
			{
				text = text + string.Format(Messages.ErrorInFormat, Labels.lblJalaliCalendare) + "</br>";
			}
			if (string.IsNullOrWhiteSpace(vm.QamariDateStr))
			{
				text = text + string.Format(Messages.ErrorInFormat, Labels.lblQamariCalendare) + "</br>";
			}
			if (string.IsNullOrWhiteSpace(vm.MiladiDateStr))
			{
				text = text + string.Format(Messages.ErrorInFormat, Labels.lblMiladiCalendare) + "</br>";
			}
			vm.MiladiDate = DateTime.ParseExact(vm.MiladiDateStr, "yyyy/MM/dd", CultureInfo.InvariantCulture);
			if (!vm.MiladiDate.HasValue)
			{
				text = text + string.Format(Messages.ErrorInFormat, Labels.lblMiladiCalendare) + "</br>";
			}
			if (text == "")
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				Enumerable.FirstOrDefault<CRMspInsertUpdateCalendarEvent_Result>((IEnumerable<CRMspInsertUpdateCalendarEvent_Result>)_dbII.CRMspInsertUpdateCalendarEvent(vm.CalendarEventID, lCID, vm.IsClosed, vm.MiladiDate, int.Parse(vm.MiladiDateStr.Split(new char[1] { '/' })[0]), int.Parse(vm.MiladiDateStr.Split(new char[1] { '/' })[1]), int.Parse(vm.MiladiDateStr.Split(new char[1] { '/' })[2]), vm.MiladiDesc, vm.MiladiIsClosed, int.Parse(vm.JalaliDateStr.Split(new char[1] { '/' })[0]), int.Parse(vm.JalaliDateStr.Split(new char[1] { '/' })[1]), int.Parse(vm.JalaliDateStr.Split(new char[1] { '/' })[2]), vm.JalaliDesc, vm.JalaliIsClosed, int.Parse(vm.QamariDateStr.Split(new char[1] { '/' })[0]), int.Parse(vm.QamariDateStr.Split(new char[1] { '/' })[1]), int.Parse(vm.QamariDateStr.Split(new char[1] { '/' })[2]), vm.QamariDesc, vm.QamariIsClosed));
			}
		}
		catch (FormatException)
		{
			text += string.Format(Messages.ErrorInFormat, Labels.Date);
		}
		catch (Exception ex2)
		{
			Public.InsExceptToElmah(ex2);
		}
		return text;
	}

	[HttpPost]
	[LoginAuthorize]
	public string Delete(int id)
	{
		string result = "";
		try
		{
			if (Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.CRMspDeleteCalendarEvent(id)).Result == 0)
			{
				result = Messages.MsgErrorDoneOperation;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetDatesInMonth(int yearNum = 0, int monthNum = 0)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int num = 1;
			List<int> list = new List<int> { 1065, 1164, 1152 };
			num = (new List<int>
			{
				1025, 1056, 2049, 3073, 14337, 16385, 8193, 15361, 9217, 11265,
				10241, 4097, 5121, 6145, 7169, 1057, 1086, 2117
			}.Contains(lCID) ? 3 : (list.Contains(lCID) ? 1 : 2));
			List<CRMspSelectCalendarEventDatesInMonth_Result> list2 = Enumerable.ToList<CRMspSelectCalendarEventDatesInMonth_Result>((IEnumerable<CRMspSelectCalendarEventDatesInMonth_Result>)_dbII.CRMspSelectCalendarEventDatesInMonth(num, yearNum, monthNum));
			if (list2 != null)
			{
				result = JsonConvert.SerializeObject(list2);
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string ConvertDateStr(string jalali = "", string qamari = "", string miladi = "")
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			DateTime? dateTime = null;
			if (!string.IsNullOrWhiteSpace(jalali))
			{
				dateTime = DateTimeClass.GetDateFromPersian(jalali);
			}
			else if (!string.IsNullOrWhiteSpace(qamari))
			{
				dateTime = DateTimeClass.GetDateFromQamari(qamari);
			}
			else if (!string.IsNullOrWhiteSpace(miladi))
			{
				dateTime = DateTimeClass.GetDateFromMiladi(miladi);
			}
			if (dateTime.HasValue)
			{
				list.Add(new SelectListItem
				{
					Text = "1",
					Value = dateTime?.ToString("yyyy/MM/dd", new PersianCulture())
				});
				list.Add(new SelectListItem
				{
					Text = "2",
					Value = dateTime?.ToString("yyyy/MM/dd", new CultureInfo("ar-SA"))
				});
				list.Add(new SelectListItem
				{
					Text = "3",
					Value = dateTime?.ToString("yyyy/MM/dd", new CultureInfo("en-US"))
				});
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return JsonConvert.SerializeObject(list);
	}
}

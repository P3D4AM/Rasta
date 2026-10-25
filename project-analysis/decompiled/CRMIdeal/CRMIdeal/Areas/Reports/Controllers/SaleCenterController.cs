using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Reports.Controllers;

public class SaleCenterController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[LoginAuthorize]
	public ActionResult Index()
	{
		base.ViewBag.SaleCentersJs = JsonConvert.SerializeObject(GetSaleCenters());
		return View();
	}

	[HttpPost]
	[LoginAuthorize]
	public List<WSspSelectSaleCenters_Result> GetSaleCenters()
	{
		List<WSspSelectSaleCenters_Result> list = new List<WSspSelectSaleCenters_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			list = Enumerable.ToList<WSspSelectSaleCenters_Result>((IEnumerable<WSspSelectSaleCenters_Result>)_db.WSspSelectSaleCenters(lCID, result));
			if (list == null)
			{
				list = new List<WSspSelectSaleCenters_Result>();
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return list;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetSaleCentersInfo(int mode = 0, string saleCenterIds = "", string fDate = "", string tDate = "", int minGapTimeMinutes = 0)
	{
		List<WSspSelectSaleCenterInMode_Result> value = new List<WSspSelectSaleCenterInMode_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime? dateFromPersian = DateTimeClass.GetDateFromPersian(fDate);
			DateTime? dateFromPersian2 = DateTimeClass.GetDateFromPersian(tDate);
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<WSspSelectSaleCenterInMode_Result> list = Enumerable.ToList<WSspSelectSaleCenterInMode_Result>((IEnumerable<WSspSelectSaleCenterInMode_Result>)_dbII.WSspSelectSaleCenterInMode(mode, saleCenterIds, dateFromPersian, dateFromPersian2, lCID, result, result2, minGapTimeMinutes));
			if (list != null)
			{
				value = list;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return JsonConvert.SerializeObject(value);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetOrderItems(string dt = "")
	{
		List<WSspSelectOrderItemsSaleCenterDeliveryByDate_Result> value = new List<WSspSelectOrderItemsSaleCenterDeliveryByDate_Result>();
		int result = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
		}
		DateTime? dateFromPersian = DateTimeClass.GetDateFromPersian(dt);
		if (dateFromPersian.HasValue)
		{
			List<WSspSelectOrderItemsSaleCenterDeliveryByDate_Result> list = Enumerable.ToList<WSspSelectOrderItemsSaleCenterDeliveryByDate_Result>((IEnumerable<WSspSelectOrderItemsSaleCenterDeliveryByDate_Result>)_dbII.WSspSelectOrderItemsSaleCenterDeliveryByDate(dateFromPersian, result));
			if (list != null)
			{
				value = list;
			}
		}
		return JsonConvert.SerializeObject(value);
	}
}

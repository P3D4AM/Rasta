using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Company.Controllers;

public class SearchCompanyController : Controller
{
	private CRMSpEntities _db = new CRMSpEntities();

	private CRMSpIEntities _dbI = new CRMSpIEntities();

	public ActionResult Index(string selectedIds = "", string seperator = ",")
	{
		List<CRMspSelectCompanyByIds_Result> value = new List<CRMspSelectCompanyByIds_Result>();
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
			if (selectedIds.Replace(",", "").Replace(" ", "").Trim() != "")
			{
				value = Enumerable.ToList<CRMspSelectCompanyByIds_Result>((IEnumerable<CRMspSelectCompanyByIds_Result>)_dbI.CRMspSelectCompanyByIds(selectedIds, seperator, lCID, result, result2));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.SelectedIds = selectedIds;
		base.ViewBag.SelectedIdsJs = JsonConvert.SerializeObject(value);
		return View();
	}

	[LoginAuthorize]
	[HttpPost]
	public List<CRMspMainSearchWeb_Result> MainSearch(string value = "", string srchConditions = "")
	{
		List<CRMspMainSearchWeb_Result> result = new List<CRMspMainSearchWeb_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			result = Enumerable.ToList<CRMspMainSearchWeb_Result>((IEnumerable<CRMspMainSearchWeb_Result>)_dbI.CRMspMainSearchWeb(value, UserLogin.CurrentUser.UserId, 1, lCID, result2, srchConditions, result3));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[LoginAuthorize]
	[HttpPost]
	public string MainSearchJs(string value = "", string srchConditions = "")
	{
		return JsonConvert.SerializeObject(MainSearch(value, srchConditions));
	}
}

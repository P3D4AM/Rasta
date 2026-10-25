using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace CRMIdeal.Areas.Company.Controllers;

public class LinkedCompanyController : Controller
{
	private CRMSpEntities _db = new CRMSpEntities();

	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actLinkedCompany")]
	public ActionResult Index(int cmpId)
	{
		base.ViewBag.cmpId = cmpId;
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actLinkedCompany")]
	[AjaxOnly]
	public ActionResult LinkedCompany_Read([DataSourceRequest] DataSourceRequest request, int cmpId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmspSelectLinkedCompany_Result> list = new List<CrmspSelectLinkedCompany_Result>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			list = Enumerable.ToList<CrmspSelectLinkedCompany_Result>((IEnumerable<CrmspSelectLinkedCompany_Result>)_db.CrmspSelectLinkedCompany(cmpId, lCID, result, result2));
			foreach (CrmspSelectLinkedCompany_Result item in list)
			{
				_ = item.RegisterDate;
				item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actLinkedCompanyDelete")]
	public string LinkedCompanyDelete(int cmpId, int companyIdForLoad)
	{
		string result = "";
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (cmpId != 0 && companyIdForLoad != 0)
			{
				_db.CrmspDeleteLinkedCompany(cmpId, companyIdForLoad, result2);
			}
			else
			{
				result = Messages.msgNotFound;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actLinkedCompanyAdd")]
	public string LinkedCompanyAdd(int cmpId, int searchCmpId)
	{
		string result = "";
		try
		{
			if (cmpId != 0 && searchCmpId != 0)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
				if (result2 <= 0)
				{
					result2 = 1065;
				}
				_ = Thread.CurrentThread.CurrentCulture.LCID;
				DateTime now = DateTime.Now;
				int userId = UserLogin.CurrentUser.UserId;
				string persianDate = now.ToString("yyyyMMdd", new PersianCulture());
				short value = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short value2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
				int? centerId = null;
				if (UserLogin.CurrentUser != null)
				{
					centerId = UserLogin.CurrentUser.UserLastCId;
				}
				_db.CrmspInsertLinkedCompany(cmpId, searchCmpId, userId, persianDate, now, value2, value, appType, result2, centerId);
			}
			else
			{
				result = Messages.msgNotFound;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actLinkedCompanyDeleteAll")]
	public string LinkedCompanyDeleteAll(int cmpId)
	{
		string result = "";
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (cmpId != 0)
			{
				_db.CrmspDeleteAllLinkedCompany(cmpId, result2);
			}
			else
			{
				result = Messages.msgErrorNotSelectCompany;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		base.Dispose(disposing);
	}
}

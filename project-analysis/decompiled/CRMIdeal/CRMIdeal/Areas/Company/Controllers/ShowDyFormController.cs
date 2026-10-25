using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Security;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace CRMIdeal.Areas.Company.Controllers;

public class ShowDyFormController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actShowCmpDyForms")]
	public ActionResult Index(int cmpId = 0)
	{
		base.ViewBag.CompanyId = cmpId;
		return View();
	}

	[AjaxOnly]
	public ActionResult CompanyMasterValues_Read([DataSourceRequest] DataSourceRequest request, int cmpId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspDySelectCompanyMasterValues_Result> list = new List<CRMspDySelectCompanyMasterValues_Result>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (cmpId > 0)
			{
				list = Enumerable.ToList<CRMspDySelectCompanyMasterValues_Result>((IEnumerable<CRMspDySelectCompanyMasterValues_Result>)_dbI.CRMspDySelectCompanyMasterValues(cmpId, UserLogin.CurrentUser.UserId, lCID, result, result2));
				if (list != null && list.Count > 0)
				{
					foreach (CRMspDySelectCompanyMasterValues_Result item in list)
					{
						item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd");
						item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyy/MM/dd");
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		base.Dispose(disposing);
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Helper;
using Elmah;

namespace CRMIdeal.Areas.CompanyReport.Controllers;

public class CompanyLocationController : Controller
{
	private CRMSpEntities _db = new CRMSpEntities();

	[DynamicAuthorize(ControllerName = "frmCompanyReport", ActionName = "actcmpLocationOnMap")]
	public ActionResult Index()
	{
		return View();
	}

	[AjaxOnly]
	public JsonResult GetCompaniessLocation()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<mct_CRMspSelectCompanyLocationFromRptFilterData_Result> list = new List<mct_CRMspSelectCompanyLocationFromRptFilterData_Result>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			BaseInfo baseInfo = new BaseInfo();
			list = Enumerable.ToList<mct_CRMspSelectCompanyLocationFromRptFilterData_Result>((IEnumerable<mct_CRMspSelectCompanyLocationFromRptFilterData_Result>)_db.CRMspSelectCompanyLocationFromRptFilterData(UserLogin.CurrentUser.UserId, lCID, result, result2));
			foreach (mct_CRMspSelectCompanyLocationFromRptFilterData_Result item in list)
			{
				item.cmpCoordinateLastDatePerWithSlash = (item.cmpCoordinateLastDate.HasValue ? string.Format(Labels.CompanyLocationLastEditDate, baseInfo.En2FaNumber(item.cmpCoordinateLastDate.Value.ToString("yyyy/MM/dd") + string.Format(" ({0})", item.cmpCoordinateLastDate.Value.ToString("HH:mm:ss")))) : "");
				item.CompanyName = (item.cmpNumber.HasValue ? (item.CompanyName + " (" + baseInfo.En2FaNumber(item.cmpNumber.ToString()) + ")") : item.CompanyName);
				item.cmpReferUser = ((!string.IsNullOrEmpty(item.cmpReferUser)) ? string.Format(Labels.CompanyLocationReferUser, item.cmpReferUser) : item.cmpReferUser);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		base.Dispose(disposing);
	}
}

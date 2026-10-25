using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;

namespace CRMIdeal.Areas.Centers.Controllers;

public class SurveyController : Controller
{
	private CRMSpEntities _db = new CRMSpEntities();

	private CRMSpIEntities _dbI = new CRMSpIEntities();

	private CRMSpIIEntities _dbII = new CRMSpIIEntities();

	public ActionResult ManageCenters(int sId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
		_ = UserLogin.CurrentUser.UserId;
		short.Parse(Financial.Get().Id.ToString());
		short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
		_ = Configuration.AppType;
		int result2 = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
		}
		CRMspSelectSurveyWithId_Result model = new CRMspSelectSurveyWithId_Result();
		if (sId != 0)
		{
			CRMspSelectSurveyWithId_Result cRMspSelectSurveyWithId_Result = Enumerable.FirstOrDefault<CRMspSelectSurveyWithId_Result>((IEnumerable<CRMspSelectSurveyWithId_Result>)_db.CRMspSelectSurveyWithId(sId, lCID, result));
			if (cRMspSelectSurveyWithId_Result != null)
			{
				model = cRMspSelectSurveyWithId_Result;
			}
		}
		return View(model);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmSurDefineSurvey", ActionName = "actManageCenter")]
	public string ManageCentersIE(int sId, string cIds, string centerinfoJson)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int userId = UserLogin.CurrentUser.UserId;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			_ = Financial.Get().Id;
			if (sId != 0)
			{
				_dbII.CRMspUpdateSurveyCIds(sId, cIds, centerinfoJson, userId, value, registerDatePersian, value2, value3, appType);
			}
			else
			{
				result = string.Format(Messages.msgErrorIsNotSelectedItem, Labels.lblSurvey);
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			result = Messages.MsgErrorDoneOperation;
		}
		return result;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbI.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}
}

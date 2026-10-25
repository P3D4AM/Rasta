using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Elmah;

namespace CRMIdeal.Areas.Score.Controllers;

public class RulesSettingController : Controller
{
	private readonly CRMSpIEntities _db_I = new CRMSpIEntities();

	public ActionResult Index()
	{
		return View();
	}

	[LoginAuthorize]
	public ActionResult InsertEdit(int id = 0)
	{
		CRMspSelectScoreRulesSetting_Result cRMspSelectScoreRulesSetting_Result = new CRMspSelectScoreRulesSetting_Result();
		try
		{
			int result = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
			}
			cRMspSelectScoreRulesSetting_Result = Enumerable.FirstOrDefault<CRMspSelectScoreRulesSetting_Result>((IEnumerable<CRMspSelectScoreRulesSetting_Result>)_db_I.CRMspSelectScoreRulesSetting(result), (Func<CRMspSelectScoreRulesSetting_Result, bool>)((CRMspSelectScoreRulesSetting_Result m) => m.RuleSettingId == id));
			if (cRMspSelectScoreRulesSetting_Result == null)
			{
				cRMspSelectScoreRulesSetting_Result = new CRMspSelectScoreRulesSetting_Result();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(cRMspSelectScoreRulesSetting_Result);
	}

	[HttpPost]
	[LoginAuthorize]
	public ActionResult InsertEdit(CRMspSelectScoreRulesSetting_Result vm)
	{
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int userId = UserLogin.CurrentUser.UserId;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int? num = null;
			if (UserLogin.CurrentUser != null)
			{
				num = UserLogin.CurrentUser.UserLastCId;
			}
			ObjectParameter objectParameter = new ObjectParameter("Result", 0);
			_db_I.CRMspInsertUpdateScoreRulesSetting(vm.RuleSettingId, vm.UpdateCmpGroup, vm.UpdateCmpSubGroup, vm.UpdateCmpGroupII, vm.UpdateCmpGroupIII, vm.UpdateCmpGroupIV, userId, value, registerDatePersian, value2, value3, appType, result, objectParameter, (num != 0) ? num : null, vm.UseFirstPriorityRule);
			if (objectParameter != null)
			{
				int result2 = 0;
				if (objectParameter.Value != null)
				{
					int.TryParse(objectParameter.Value.ToString(), out result2);
				}
				vm.RuleSettingId = result2;
				if (result2 > 0)
				{
					base.ViewBag.Successfull = Messages.msgOperationCompleted;
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			base.ViewBag.Error = ex.Message;
		}
		return View(vm);
	}
}

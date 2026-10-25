using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.Models;
using CRMIdeal.Cache.Setting;

namespace CRMIdeal.Controllers;

public class CallCenterAPIController : Controller
{
	private readonly CRMSpIEntities _db = new CRMSpIEntities();

	public string GetCompanyIVRFormula(string phone, string cmpUserName = "", int prdGrouopId = 0, string ivrPrdIds = "", string validityPrdIds = "", int langId = 1065, string trunkUId = "")
	{
		string result = "-1";
		try
		{
			if (!string.IsNullOrWhiteSpace(phone))
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
				if (result2 <= 0)
				{
					result2 = 1065;
				}
				_ = Thread.CurrentThread.CurrentCulture.LCID;
				CRMspCalcIVRLinkRuleDetails_Result cRMspCalcIVRLinkRuleDetails_Result = Enumerable.FirstOrDefault<CRMspCalcIVRLinkRuleDetails_Result>((IEnumerable<CRMspCalcIVRLinkRuleDetails_Result>)_db.CRMspCalcIVRLinkRuleDetails(0, prdGrouopId, ivrPrdIds, validityPrdIds, cmpUserName, phone.ToString(), DateTime.Now, trunkUId, langId));
				if (cRMspCalcIVRLinkRuleDetails_Result != null)
				{
					result = cRMspCalcIVRLinkRuleDetails_Result.ResultJs;
				}
			}
		}
		catch (DbEntityValidationException ex)
		{
			result = "-2";
			InsertLog.InsExceptToLog((Exception)(object)ex);
		}
		catch (Exception ex2)
		{
			result = "0";
			InsertLog.InsExceptToLog(ex2);
		}
		return result;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		base.Dispose(disposing);
	}
}

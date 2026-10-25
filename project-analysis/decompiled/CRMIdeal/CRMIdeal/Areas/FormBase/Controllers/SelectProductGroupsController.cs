using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using Elmah;

namespace CRMIdeal.Areas.FormBase.Controllers;

public class SelectProductGroupsController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	public ActionResult Index(string positionName, int prdGroupId = 0, string selectedPrdGroupIds = "")
	{
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			base.ViewBag.PositionName = positionName;
			base.ViewBag.PrdGroupId = prdGroupId;
			base.ViewBag.SelectedPrdGroupIds = selectedPrdGroupIds;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View();
	}

	[AjaxOnly]
	public JsonResult GetPrdGroups(string positionName, int prdGroupId = 0)
	{
		List<WSspSelectProductGroupTree_Result> list = new List<WSspSelectProductGroupTree_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			_ = Labels.TextWithOutRoll;
			list = Enumerable.ToList<WSspSelectProductGroupTree_Result>((IEnumerable<WSspSelectProductGroupTree_Result>)_db.WSspSelectProductGroupTree(lCID, result));
			if (list == null)
			{
				list = new List<WSspSelectProductGroupTree_Result>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}

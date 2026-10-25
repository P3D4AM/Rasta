using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Security;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using Elmah;

namespace CRMIdeal.Areas.FormBase.Controllers;

public class SelectProjectTitleGroupsController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	public ActionResult Index(string positionName, int prjTitleGroupId = 0, string selectedPrjTitleGroupIds = "")
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
			base.ViewBag.PrjTitleGroupId = prjTitleGroupId;
			base.ViewBag.SelectedPrjTitleGroupIds = selectedPrjTitleGroupIds;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View();
	}

	[AjaxOnly]
	public JsonResult GetPrdTitleGroups(string positionName, int currentItemId = 0)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			_ = UserLogin.CurrentUser.UserId;
			List<CRMspSelectProjectTitleGroups_Result> list2 = Enumerable.ToList<CRMspSelectProjectTitleGroups_Result>((IEnumerable<CRMspSelectProjectTitleGroups_Result>)_dbI.CRMspSelectProjectTitleGroups(lCID, result));
			if (list2 != null && Enumerable.Any<CRMspSelectProjectTitleGroups_Result>((IEnumerable<CRMspSelectProjectTitleGroups_Result>)list2))
			{
				list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectProjectTitleGroups_Result, SelectListItem>((IEnumerable<CRMspSelectProjectTitleGroups_Result>)list2, (Func<CRMspSelectProjectTitleGroups_Result, SelectListItem>)((CRMspSelectProjectTitleGroups_Result item) => new SelectListItem
				{
					Text = item.ProjectTitleGroup,
					Value = item.ProjectTitleGroupId.ToString()
				})));
			}
			if (list == null)
			{
				list = new List<SelectListItem>();
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

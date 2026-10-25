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
using Kendo.Mvc.UI;

namespace CRMIdeal.Areas.Accounts.Controllers;

public class SecurityController : Controller
{
	private CRMSpEntities db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actRollPermission")]
	public ActionResult RollPermissionDefine()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectRollPermissionFormTree_Result> list = Enumerable.ToList<CRMspSelectRollPermissionFormTree_Result>((IEnumerable<CRMspSelectRollPermissionFormTree_Result>)db.CRMspSelectRollPermissionFormTree(lCID, result));
		List<TreeViewItemModel> list2 = new List<TreeViewItemModel>();
		foreach (CRMspSelectRollPermissionFormTree_Result item in list)
		{
			TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
			treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.rootId + "|" + item.Id));
			treeViewItemModel.Id = item.rootId + "|" + item.Id;
			treeViewItemModel.Text = item.FormPersianName;
			treeViewItemModel.ImageUrl = "";
			treeViewItemModel.Items = null;
			list2.Add(treeViewItemModel);
		}
		base.ViewBag.FormNameTree = list2;
		base.ViewBag.FormNameTreeID = list2[0].Id;
		int? num = 0;
		if (UserLogin.CurrentUser != null)
		{
			num = UserLogin.CurrentUser.RollId.GetValueOrDefault();
		}
		base.ViewBag.RollID = num;
		return View();
	}

	[AjaxOnly]
	public JsonResult GeAllAssignedActions(int rollId, int formId)
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
		List<AssignedFormActionsToRollViewModel> data = new List<AssignedFormActionsToRollViewModel>();
		try
		{
			List<AssignedFormActionsToRollViewModel> list = new List<AssignedFormActionsToRollViewModel>();
			List<CRMspSelectAssignedFormActionsToRoll_Result> list2 = Enumerable.ToList<CRMspSelectAssignedFormActionsToRoll_Result>((IEnumerable<CRMspSelectAssignedFormActionsToRoll_Result>)db.CRMspSelectAssignedFormActionsToRoll(formId, rollId, lCID, result, result2));
			List<CRMspSelectNotAssignedFormActionsToRoll_Result> list3 = Enumerable.ToList<CRMspSelectNotAssignedFormActionsToRoll_Result>((IEnumerable<CRMspSelectNotAssignedFormActionsToRoll_Result>)db.CRMspSelectNotAssignedFormActionsToRoll(formId, rollId, lCID, result, result2));
			foreach (CRMspSelectAssignedFormActionsToRoll_Result item in list2)
			{
				list.Add(new AssignedFormActionsToRollViewModel
				{
					ActionPersianName = item.ActionPersianName,
					ID = item.ID,
					ActionName = item.ActionName,
					FormId = item.FormId,
					IsCheck = true
				});
			}
			foreach (CRMspSelectNotAssignedFormActionsToRoll_Result item2 in list3)
			{
				list.Add(new AssignedFormActionsToRollViewModel
				{
					ActionPersianName = item2.ActionPersianName,
					ID = item2.ID,
					ActionName = item2.ActionName,
					FormId = item2.FormId,
					IsCheck = false
				});
			}
			data = Enumerable.ToList<AssignedFormActionsToRollViewModel>((IEnumerable<AssignedFormActionsToRollViewModel>)Enumerable.OrderBy<AssignedFormActionsToRollViewModel, string>((IEnumerable<AssignedFormActionsToRollViewModel>)list, (Func<AssignedFormActionsToRollViewModel, string>)((AssignedFormActionsToRollViewModel c) => c.ActionPersianName)));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	public ActionResult RollPermissionDefinePopup()
	{
		return View();
	}

	protected override void Dispose(bool disposing)
	{
		db.Dispose();
		_dbTbl.Dispose();
		base.Dispose(disposing);
	}
}

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

namespace CRMIdeal.Areas.Telegram.Controllers;

public class AddConversationController : Controller
{
	private CRMSpEntities _db = new CRMSpEntities();

	[DynamicAuthorize(ControllerName = "frmTelegram", ActionName = "actInsertMessageToCnvs")]
	public ActionResult Index(int msgId, int cmpId, int prsId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		GetProject(cmpId);
		base.ViewBag.CmpName = CRMIdeal.Classes.Helper.Company.GetCompanyNameWithTitle(cmpId);
		base.ViewBag.PrsName = CRMIdeal.Classes.Helper.Company.GetCmpPersonFullName(prsId);
		base.ViewBag.CmpId = cmpId;
		base.ViewBag.PrsId = prsId;
		base.ViewBag.MsgId = msgId;
		return View();
	}

	[AjaxOnly]
	public JsonResult GetProject(int cmpId)
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectCrmProjectBycmpAndUser_Result> list2 = Enumerable.ToList<CRMspSelectCrmProjectBycmpAndUser_Result>((IEnumerable<CRMspSelectCrmProjectBycmpAndUser_Result>)_db.CRMspSelectCrmProjectBycmpAndUser(cmpId, UserLogin.CurrentUser.UserId, lCID, result, result2));
			list.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "-1",
				Selected = true
			});
			list.AddRange(Enumerable.Select<CRMspSelectCrmProjectBycmpAndUser_Result, SelectListItem>((IEnumerable<CRMspSelectCrmProjectBycmpAndUser_Result>)list2, (Func<CRMspSelectCrmProjectBycmpAndUser_Result, SelectListItem>)((CRMspSelectCrmProjectBycmpAndUser_Result item) => new SelectListItem
			{
				Text = item.prjTitle,
				Value = item.ProjectID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ProjectList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		base.Dispose(disposing);
	}
}

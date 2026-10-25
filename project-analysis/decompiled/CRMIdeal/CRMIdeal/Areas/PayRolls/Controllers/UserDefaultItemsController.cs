using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;

namespace CRMIdeal.Areas.PayRolls.Controllers;

public class UserDefaultItemsController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actPayRollUserDefaultItems")]
	public ActionResult Index()
	{
		GetUsers();
		return View();
	}

	[AjaxOnly]
	public JsonResult GetUsers()
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
			List<CRMspSelectActiveUsers_Result> list2 = Enumerable.ToList<CRMspSelectActiveUsers_Result>(Enumerable.Where<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)_db.CRMspSelectActiveUsers(lCID, result, 0), (Func<CRMspSelectActiveUsers_Result, bool>)((CRMspSelectActiveUsers_Result m) => m.UserId > 0)));
			list.AddRange(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)list2, (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result item) => new SelectListItem
			{
				Text = (item.Name ?? ""),
				Value = item.UserId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.UserList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult LoadUserDefaultItems(int kind, int userId)
	{
		List<PayRollspSelectUserDefaultItems_Result> data = new List<PayRollspSelectUserDefaultItems_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			data = Enumerable.ToList<PayRollspSelectUserDefaultItems_Result>((IEnumerable<PayRollspSelectUserDefaultItems_Result>)_db.PayRollspSelectUserDefaultItems(kind, userId, lCID, result));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmPayRollUserDefaultItems", ActionName = "actIncDelete,actDecDelete")]
	public JsonResult ActDelete(int itemId)
	{
		string data = "";
		try
		{
			_db.PayRollspDeleteUserDefaultItems(itemId);
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("PayRollUserDefaultItems");
			data = "ok";
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmPayRollUserDefaultItems", ActionName = "actIncDeleteAll,actDecDeleteAll")]
	public JsonResult ActDeleteAll(int userId, int kind)
	{
		string data = "";
		try
		{
			_db.PayRollspDeleteUserDefaultItemsAll(userId, kind);
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("PayRollUserDefaultItems");
			data = "ok";
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[LoginAuthorize]
	public ActionResult ShowItems(string type, string param, string extra = "", int position = 0)
	{
		string text = "";
		string formName;
		string actionName;
		switch (position)
		{
		case 1:
			formName = "frmPayRollUserDefaultItems";
			actionName = "actIncInsert";
			text = "frmPayRollUserDefaultItemsDataEntry";
			break;
		case 2:
			formName = "frmPayRollUserDefaultItems";
			actionName = "actDecInsert";
			text = "frmPayRollUserDefaultItemsDataEntry";
			break;
		case 3:
			formName = "frmPayRollUserCycleDetails";
			actionName = "actIncInsert";
			text = "frmPayRollUserCycleDetailAddItems";
			break;
		case 4:
			formName = "frmPayRollUserCycleDetails";
			actionName = "actDecInsert";
			text = "frmPayRollUserCycleDetailAddItems";
			break;
		default:
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		if (!UserLogin.IsUserAccess(formName, actionName, UserLogin.CurrentUser))
		{
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		base.ViewBag.Parameters = param;
		base.ViewBag.Type = type;
		base.ViewBag.Extra = extra;
		base.ViewBag.FormName = text;
		return View();
	}

	[AjaxOnly]
	public JsonResult ReturnItemsToAddUserDefaultItems(string parameters, string extra = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiSelectorViewModel> data = new List<CommonMultiSelectorViewModel>();
		try
		{
			int result2 = 0;
			if (parameters != "")
			{
				int.TryParse(parameters, out result2);
			}
			int result3 = 0;
			if (extra != "")
			{
				int.TryParse(extra, out result3);
			}
			data = Enumerable.ToList<CommonMultiSelectorViewModel>(Enumerable.Select<PayRollspReturnItemsToAddUserDefaultItems_Result, CommonMultiSelectorViewModel>((IEnumerable<PayRollspReturnItemsToAddUserDefaultItems_Result>)Enumerable.ToList<PayRollspReturnItemsToAddUserDefaultItems_Result>((IEnumerable<PayRollspReturnItemsToAddUserDefaultItems_Result>)_db.PayRollspReturnItemsToAddUserDefaultItems(crmUserId: result3, itemKind: result2, languageID: lCID, defaultLanguageID: result)), (Func<PayRollspReturnItemsToAddUserDefaultItems_Result, CommonMultiSelectorViewModel>)((PayRollspReturnItemsToAddUserDefaultItems_Result item) => new CommonMultiSelectorViewModel
			{
				Id = int.Parse(item.PayRollItemId.ToString()),
				Name = item.ItemName,
				Selected = false
			})));
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult ReturnItemsToAddUserCycleItems(string parameters, string extra = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiSelectorViewModel> data = new List<CommonMultiSelectorViewModel>();
		try
		{
			int result2 = 0;
			if (parameters != "")
			{
				int.TryParse(parameters, out result2);
			}
			int value = 0;
			if (extra != "")
			{
				string[] array = extra.Split(new char[1] { '|' });
				value = ((array[0] != null && array[0] != "") ? int.Parse(array[0]) : 0);
				if (array[1] != null && array[1] != "")
				{
					int.Parse(array[1]);
				}
			}
			data = Enumerable.ToList<CommonMultiSelectorViewModel>(Enumerable.Select<PayRollspReturnItemsToAddUserCycleItems_Result, CommonMultiSelectorViewModel>((IEnumerable<PayRollspReturnItemsToAddUserCycleItems_Result>)Enumerable.ToList<PayRollspReturnItemsToAddUserCycleItems_Result>((IEnumerable<PayRollspReturnItemsToAddUserCycleItems_Result>)_db.PayRollspReturnItemsToAddUserCycleItems(result2, value, lCID, result)), (Func<PayRollspReturnItemsToAddUserCycleItems_Result, CommonMultiSelectorViewModel>)((PayRollspReturnItemsToAddUserCycleItems_Result item) => new CommonMultiSelectorViewModel
			{
				Id = int.Parse(item.PayRollItemId.ToString()),
				Name = item.ItemName,
				Selected = false
			})));
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	public string AddToUserDefaultItems(int crmUserId, string itemIds)
	{
		string result = "-1";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmPayRollUserDefaultItemsDataEntry", "actPost", currentUser))
			{
				return Messages.ErrorNotAccess;
			}
			int userId = UserLogin.CurrentUser.UserId;
			short value = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			short value2 = short.Parse(Financial.Get().Id.ToString());
			DateTime now = DateTime.Now;
			string registerDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			string appType = Configuration.AppType;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			if (crmUserId != 0 && !string.IsNullOrEmpty(itemIds) && _db.PayRollspInsertUserDefaultItemsByIds(itemIds, crmUserId, userId, now, registerDatePersian, value2, value, appType, result2) >= 0)
			{
				result = "1";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	public string AddToUserCycleItemValues(string extra, string itemIds)
	{
		string result = "-1";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmPayRollUserCycleDetailAddItems", "actPost", currentUser))
			{
				return Messages.ErrorNotAccess;
			}
			int userId = UserLogin.CurrentUser.UserId;
			short value = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			short value2 = short.Parse(Financial.Get().Id.ToString());
			DateTime now = DateTime.Now;
			string registerDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			string appType = Configuration.AppType;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int num = 0;
			int num2 = 0;
			if (extra != "")
			{
				string[] array = extra.Split(new char[1] { '|' });
				num = ((array[0] != null && array[0] != "") ? int.Parse(array[0]) : 0);
				num2 = ((array[1] != null && array[1] != "") ? int.Parse(array[1]) : 0);
			}
			if (num2 != 0 && !string.IsNullOrEmpty(itemIds) && num != 0)
			{
				if (PayRoll.IsVerify(num))
				{
					return Messages.msgErrorNotActivePayRollUserCycle;
				}
				if (_db.PayRollspInsertUserCycleItemValuesByIds(num, num2, itemIds, userId, now, registerDatePersian, value2, value, appType, result2) >= 0)
				{
					result = "1";
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmPayRollUserDefaultItems", ActionName = "actCopyDefaultItemsToOtherUsers")]
	public ActionResult CopyUserDefaultItemsToOtherUsers(int crmUserId)
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
			List<CRMspSelectActiveUsers_Result> list2 = Enumerable.ToList<CRMspSelectActiveUsers_Result>(Enumerable.Where<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)_db.CRMspSelectActiveUsers(lCID, result, 0), (Func<CRMspSelectActiveUsers_Result, bool>)((CRMspSelectActiveUsers_Result m) => m.UserId != crmUserId)));
			list.AddRange(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)list2, (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result item) => new SelectListItem
			{
				Text = (item.Name ?? ""),
				Value = item.UserId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.UserList = list;
		base.ViewBag.CrmUserId = crmUserId;
		return View();
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmPayRollUserDefaultItems", ActionName = "actCopyDefaultItemsToOtherUsers")]
	public string ActCopyDefaultItemsToOtherUsers(int crmUserId, string userIds)
	{
		string result = "";
		try
		{
			if (!UserLogin.IsUserAccess("frmPayRollUserDefaultItems", "actCopyDefaultItemsToOtherUsers", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (crmUserId == 0)
			{
				return Messages.msgErrorNotSelectUser;
			}
			if (!string.IsNullOrWhiteSpace(userIds) && userIds.EndsWith("|"))
			{
				userIds = userIds.TrimEnd(new char[1] { '|' });
			}
			if (string.IsNullOrWhiteSpace(userIds))
			{
				return Messages.msgErrorNotSelectedItem;
			}
			if (crmUserId != 0 && !string.IsNullOrWhiteSpace(userIds))
			{
				DateTime now = DateTime.Now;
				int userId = UserLogin.CurrentUser.UserId;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short value2 = short.Parse(Financial.Get().Id.ToString());
				_dbI.PayRollspCopyUserDefaultItemsToOtherUsers(crmUserId, userIds, userId, now, registerDatePersian, value2, value, appType, result2);
				result = "1";
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
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}

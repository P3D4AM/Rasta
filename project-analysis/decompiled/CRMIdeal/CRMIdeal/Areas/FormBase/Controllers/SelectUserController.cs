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
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;

namespace CRMIdeal.Areas.FormBase.Controllers;

public class SelectUserController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	public ActionResult Index(int position = 0, int crmUserId = 0, string selectedUserIds = "")
	{
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			base.ViewBag.Position = position;
			base.ViewBag.CrmUserId = crmUserId;
			if (position != 1)
			{
				base.ViewBag.SelectedUserIds = selectedUserIds;
			}
			else
			{
				CRMspSelectUsersById_Result cRMspSelectUsersById_Result = CRMIdeal.Classes.Helper.User.SelectUsersById(crmUserId);
				if (cRMspSelectUsersById_Result != null)
				{
					base.ViewBag.SelectedUserIds = cRMspSelectUsersById_Result.AlternativeUserIds;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View();
	}

	[AjaxOnly]
	public JsonResult GetUsersAndRollTree(int position = 0, int crmUserId = 0)
	{
		List<CRMspSelectUsersAndRollTree_Result> list = new List<CRMspSelectUsersAndRollTree_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			string textWithOutRoll = Labels.TextWithOutRoll;
			list = Enumerable.ToList<CRMspSelectUsersAndRollTree_Result>((IEnumerable<CRMspSelectUsersAndRollTree_Result>)_dbI.CRMspSelectUsersAndRollTree("", textWithOutRoll, lCID, result));
			if (list != null && Enumerable.Any<CRMspSelectUsersAndRollTree_Result>((IEnumerable<CRMspSelectUsersAndRollTree_Result>)list) && position != 0 && crmUserId != 0 && position == 2)
			{
				list = Enumerable.ToList<CRMspSelectUsersAndRollTree_Result>(Enumerable.Where<CRMspSelectUsersAndRollTree_Result>((IEnumerable<CRMspSelectUsersAndRollTree_Result>)list, (Func<CRMspSelectUsersAndRollTree_Result, bool>)((CRMspSelectUsersAndRollTree_Result m) => m.UserId != crmUserId)));
			}
			if (list == null)
			{
				list = new List<CRMspSelectUsersAndRollTree_Result>();
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

	[AjaxOnly]
	[HttpPost]
	public JsonResult Submit(string selectedUserIds, int position = 0, int crmUserId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel();
		commonReturnResultViewModel.IsDone = false;
		commonReturnResultViewModel.MessageExtra = "";
		int num = 0;
		try
		{
			if (crmUserId == 0)
			{
				commonReturnResultViewModel.Message = Messages.msgSendParameterNotEntered;
				commonReturnResultViewModel.IsDone = false;
				num++;
				return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
			}
			switch (position)
			{
			case 0:
				commonReturnResultViewModel.Message = Messages.msgSendParameterNotEntered;
				commonReturnResultViewModel.IsDone = false;
				num++;
				return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
			case 1:
			{
				int userId = UserLogin.CurrentUser.UserId;
				DateTime now = DateTime.Now;
				short value = short.Parse(now.ToString("yyyy", new PersianCulture()));
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				DateTime value3 = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				now.ToString("HH:mm:ss");
				string appType = Configuration.AppType;
				_dbI.CRMspUpdateAlternativeUsers(selectedUserIds, crmUserId, userId, value, value2, value3, registerDatePersian, appType);
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("Users", crmUserId);
				commonReturnResultViewModel.IsDone = true;
				commonReturnResultViewModel.Message = Messages.msgSuccessAction;
				break;
			}
			}
		}
		catch (Exception e)
		{
			commonReturnResultViewModel.IsDone = false;
			ErrorSignal.FromCurrentContext().Raise(e);
			commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
		}
		JsonResult jsonResult = Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public ActionResult SelectUserWithoutCategory(string positionName, int crmUserId = 0, string selectedUserIds = "")
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
			base.ViewBag.CrmUserId = crmUserId;
			base.ViewBag.SelectedUserIds = selectedUserIds;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View();
	}

	[AjaxOnly]
	public JsonResult GetUsers(string positionName, int crmUserId = 0)
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
			int userId = UserLogin.CurrentUser.UserId;
			if (positionName == "ctblCommission")
			{
				List<CRMspSelectUserForLinkedType_Result> list2 = Enumerable.ToList<CRMspSelectUserForLinkedType_Result>((IEnumerable<CRMspSelectUserForLinkedType_Result>)_db.CRMspSelectUserForLinkedType(userId, 21, lCID, result, result2));
				if (list2 != null && Enumerable.Any<CRMspSelectUserForLinkedType_Result>((IEnumerable<CRMspSelectUserForLinkedType_Result>)list2))
				{
					list2 = Enumerable.ToList<CRMspSelectUserForLinkedType_Result>(Enumerable.Where<CRMspSelectUserForLinkedType_Result>((IEnumerable<CRMspSelectUserForLinkedType_Result>)list2, (Func<CRMspSelectUserForLinkedType_Result, bool>)((CRMspSelectUserForLinkedType_Result item) => item.LinkedUserId != crmUserId)));
				}
				if (list2 != null && Enumerable.Any<CRMspSelectUserForLinkedType_Result>((IEnumerable<CRMspSelectUserForLinkedType_Result>)list2))
				{
					list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectUserForLinkedType_Result, SelectListItem>((IEnumerable<CRMspSelectUserForLinkedType_Result>)list2, (Func<CRMspSelectUserForLinkedType_Result, SelectListItem>)((CRMspSelectUserForLinkedType_Result item) => new SelectListItem
					{
						Text = item.UserName,
						Value = item.LinkedUserId.ToString()
					})));
				}
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

	public ActionResult SelectUserWithCategory(string positionName, int crmUserId = 0, string selectedUserIds = "")
	{
		base.ViewBag.PositionName = positionName;
		base.ViewBag.CrmUserId = crmUserId;
		base.ViewBag.SelectedUserIds = selectedUserIds;
		return View();
	}

	[AjaxOnly]
	public JsonResult GetUserWithCategory(string positionName, int crmUserId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectSingleUsersForRepParamWeb_Result> list = new List<CRMspSelectSingleUsersForRepParamWeb_Result>();
		try
		{
			int userId = UserLogin.CurrentUser.UserId;
			string noUserDepartmentTxt = Labels.NoUserDepartmentTxt;
			string noUserRollTxt = Labels.NoUserRollTxt;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (positionName == "DailyConversation")
			{
				list = Enumerable.ToList<CRMspSelectSingleUsersForRepParamWeb_Result>((IEnumerable<CRMspSelectSingleUsersForRepParamWeb_Result>)_dbII.CRMspSelectSingleUsersForRepParamWeb(userId, 2, noUserDepartmentTxt, noUserRollTxt, lCID, result, result2));
			}
			if (list == null)
			{
				list = new List<CRMspSelectSingleUsersForRepParamWeb_Result>();
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
		_dbII.Dispose();
		base.Dispose(disposing);
	}
}

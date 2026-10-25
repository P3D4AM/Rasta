using System;
using System.Collections;
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
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace CRMIdeal.Areas.Accounts.Controllers;

public class RollsController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actuLinkedRolls")]
	public ActionResult Linked()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<TreeViewItemModel> list = new List<TreeViewItemModel>();
		try
		{
			foreach (CRMspSelectLinkedType_Result item in Enumerable.ToList<CRMspSelectLinkedType_Result>((IEnumerable<CRMspSelectLinkedType_Result>)_db.CRMspSelectLinkedType(lCID, result)))
			{
				TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
				treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.LinkedTypeId + "|" + item.TypeOrder));
				treeViewItemModel.Id = item.LinkedTypeId + "|" + item.TypeOrder;
				treeViewItemModel.Text = item.LinkTypeName;
				treeViewItemModel.ImageUrl = "";
				treeViewItemModel.Items = null;
				list.Add(treeViewItemModel);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.LinkedTypeTree = list;
		GetRolls();
		return View();
	}

	[AjaxOnly]
	public JsonResult GetRolls()
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
			List<CRMspSelectsysRolls_Result> list2 = Enumerable.ToList<CRMspSelectsysRolls_Result>((IEnumerable<CRMspSelectsysRolls_Result>)_db.CRMspSelectsysRolls(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectsysRolls_Result, SelectListItem>((IEnumerable<CRMspSelectsysRolls_Result>)list2, (Func<CRMspSelectsysRolls_Result, SelectListItem>)((CRMspSelectsysRolls_Result item) => new SelectListItem
			{
				Text = (item.RollName ?? ""),
				Value = item.ID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.UserRolls = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult UnLinkedRolls_Read([DataSourceRequest] DataSourceRequest request, int rollId, int linkedTypeId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectUnLinkedRollsForLinkedType_Result> enumerable = new List<CRMspSelectUnLinkedRollsForLinkedType_Result>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			enumerable = Enumerable.ToList<CRMspSelectUnLinkedRollsForLinkedType_Result>((IEnumerable<CRMspSelectUnLinkedRollsForLinkedType_Result>)_db.CRMspSelectUnLinkedRollsForLinkedType(rollId, linkedTypeId, lCID, result, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public ActionResult LinkedRolls_Read([DataSourceRequest] DataSourceRequest request, int rollId, int linkedTypeId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectLinkedRollsForLinkedType_Result> enumerable = new List<CRMspSelectLinkedRollsForLinkedType_Result>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			enumerable = Enumerable.ToList<CRMspSelectLinkedRollsForLinkedType_Result>((IEnumerable<CRMspSelectLinkedRollsForLinkedType_Result>)_db.CRMspSelectLinkedRollsForLinkedType(rollId, linkedTypeId, lCID, result, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public string ActAssign(int linkedTypeId, int rollId, int linkedRollId, bool isLinkedPrs = false, bool isLinkedPrj = false, bool isLinkedCnvs = false)
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
			if (!UserLogin.IsUserAccess("frmLinkedRolls", "actAssign", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short value3 = short.Parse(Financial.Get().Id.ToString());
			int userId = UserLogin.CurrentUser.UserId;
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspInsertLinkedRollsForRoll(linkedTypeId, rollId, linkedRollId, userId, value3, value2, value, registerDatePersian, appType, result2, centerId));
			if (mct_Result != null)
			{
				int result3 = 0;
				int.TryParse(mct_Result.Result.ToString(), out result3);
				if (result3 == 0)
				{
					return Messages.msgErrorRunFunction;
				}
			}
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmLinkedUsers");
			if (linkedTypeId == 14)
			{
				if (isLinkedPrs)
				{
					mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspInsertLinkedRollsForRoll(23, rollId, linkedRollId, userId, value3, value2, value, registerDatePersian, appType, result2, centerId));
					if (mct_Result != null)
					{
						int result4 = 0;
						int.TryParse(mct_Result.Result.ToString(), out result4);
						if (result4 == 0)
						{
							return Messages.msgErrorRunFunction + " (" + Labels.LinkedRollsPrsInfo + ")";
						}
					}
				}
				if (isLinkedPrj)
				{
					mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspInsertLinkedRollsForRoll(24, rollId, linkedRollId, userId, value3, value2, value, registerDatePersian, appType, result2, centerId));
					if (mct_Result != null)
					{
						int result5 = 0;
						int.TryParse(mct_Result.Result.ToString(), out result5);
						if (result5 == 0)
						{
							return Messages.msgErrorRunFunction + " (" + Labels.LinkedRollsPrjInfo + ")";
						}
					}
				}
				if (isLinkedCnvs)
				{
					mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspInsertLinkedRollsForRoll(25, rollId, linkedRollId, userId, value3, value2, value, registerDatePersian, appType, result2, centerId));
					if (mct_Result != null)
					{
						int result6 = 0;
						int.TryParse(mct_Result.Result.ToString(), out result6);
						if (result6 == 0)
						{
							return Messages.msgErrorRunFunction + " (" + Labels.LinkedRollsCnvsInfo + ")";
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = Messages.msgErrorRunFunction + "<br>" + ex.Message;
		}
		return result;
	}

	[AjaxOnly]
	public string ActRemove(int linkedTypeId, int rollId, int linkedRollId, bool isLinkedPrs = false, bool isLinkedPrj = false, bool isLinkedCnvs = false)
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
			if (!UserLogin.IsUserAccess("frmLinkedRolls", "actRemove", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			DateTime now = DateTime.Now;
			now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			_ = UserLogin.CurrentUser.UserId;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspDeleteLinkedRollsForRoll(linkedTypeId, rollId, linkedRollId, result3));
			if (mct_Result != null)
			{
				int result4 = 0;
				int.TryParse(mct_Result.Result.ToString(), out result4);
				if (result4 == 0)
				{
					return Messages.msgErrorRunFunction;
				}
			}
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmLinkedUsers");
			if (linkedTypeId == 14)
			{
				if (isLinkedPrs)
				{
					mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspDeleteLinkedRollsForRoll(23, rollId, linkedRollId, result3));
					if (mct_Result != null)
					{
						int result5 = 0;
						int.TryParse(mct_Result.Result.ToString(), out result5);
						if (result5 == 0)
						{
							return Messages.msgErrorRunFunction + " (" + Labels.LinkedRollsPrsInfo + ")";
						}
					}
				}
				if (isLinkedPrj)
				{
					mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspDeleteLinkedRollsForRoll(24, rollId, linkedRollId, result3));
					if (mct_Result != null)
					{
						int result6 = 0;
						int.TryParse(mct_Result.Result.ToString(), out result6);
						if (result6 == 0)
						{
							return Messages.msgErrorRunFunction + " (" + Labels.LinkedRollsPrjInfo + ")";
						}
					}
				}
				if (isLinkedCnvs)
				{
					mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspDeleteLinkedRollsForRoll(25, rollId, linkedRollId, result3));
					if (mct_Result != null)
					{
						int result7 = 0;
						int.TryParse(mct_Result.Result.ToString(), out result7);
						if (result7 == 0)
						{
							return Messages.msgErrorRunFunction + " (" + Labels.LinkedRollsCnvsInfo + ")";
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = Messages.msgErrorRunFunction + "<br>" + ex.Message;
		}
		return result;
	}

	[AjaxOnly]
	public string ActAssignAll(int linkedTypeId, int rollId, bool isLinkedPrs = false, bool isLinkedPrj = false, bool isLinkedCnvs = false)
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
			if (!UserLogin.IsUserAccess("frmLinkedRolls", "actAssignAll", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short value3 = short.Parse(Financial.Get().Id.ToString());
			int userId = UserLogin.CurrentUser.UserId;
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspInsertLinkedRollsForRollAll(linkedTypeId, rollId, userId, value3, value2, value, registerDatePersian, appType, result2, centerId));
			if (mct_Result != null)
			{
				int result3 = 0;
				int.TryParse(mct_Result.Result.ToString(), out result3);
				if (result3 == 0)
				{
					return Messages.msgErrorRunFunction;
				}
			}
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmLinkedUsers");
			if (linkedTypeId == 14)
			{
				if (isLinkedPrs)
				{
					mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspInsertLinkedRollsForRollAll(23, rollId, userId, value3, value2, value, registerDatePersian, appType, result2, centerId));
					if (mct_Result != null)
					{
						int result4 = 0;
						int.TryParse(mct_Result.Result.ToString(), out result4);
						if (result4 == 0)
						{
							return Messages.msgErrorRunFunction + " (" + Labels.LinkedRollsPrsInfo + ")";
						}
					}
				}
				if (isLinkedPrj)
				{
					mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspInsertLinkedRollsForRollAll(24, rollId, userId, value3, value2, value, registerDatePersian, appType, result2, centerId));
					if (mct_Result != null)
					{
						int result5 = 0;
						int.TryParse(mct_Result.Result.ToString(), out result5);
						if (result5 == 0)
						{
							return Messages.msgErrorRunFunction + " (" + Labels.LinkedRollsPrjInfo + ")";
						}
					}
				}
				if (isLinkedCnvs)
				{
					mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspInsertLinkedRollsForRollAll(25, rollId, userId, value3, value2, value, registerDatePersian, appType, result2, centerId));
					if (mct_Result != null)
					{
						int result6 = 0;
						int.TryParse(mct_Result.Result.ToString(), out result6);
						if (result6 == 0)
						{
							return Messages.msgErrorRunFunction + " (" + Labels.LinkedRollsCnvsInfo + ")";
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = Messages.msgErrorRunFunction + "<br>" + ex.Message;
		}
		return result;
	}

	[AjaxOnly]
	public string ActRemoveAll(int linkedTypeId, int rollId, bool isLinkedPrs = false, bool isLinkedPrj = false, bool isLinkedCnvs = false)
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
			if (!UserLogin.IsUserAccess("frmLinkedRolls", "actRemoveAll", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			DateTime now = DateTime.Now;
			now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			_ = UserLogin.CurrentUser.UserId;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspDeleteLinkedRollsForRollAll(linkedTypeId, rollId, result3));
			if (mct_Result != null)
			{
				int result4 = 0;
				int.TryParse(mct_Result.Result.ToString(), out result4);
				if (result4 == 0)
				{
					return Messages.msgErrorRunFunction;
				}
			}
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmLinkedUsers");
			if (linkedTypeId == 14)
			{
				if (isLinkedPrs)
				{
					mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspDeleteLinkedRollsForRollAll(23, rollId, result3));
					if (mct_Result != null)
					{
						int result5 = 0;
						int.TryParse(mct_Result.Result.ToString(), out result5);
						if (result5 == 0)
						{
							return Messages.msgErrorRunFunction + " (" + Labels.LinkedRollsPrsInfo + ")";
						}
					}
				}
				if (isLinkedPrj)
				{
					mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspDeleteLinkedRollsForRollAll(24, rollId, result3));
					if (mct_Result != null)
					{
						int result6 = 0;
						int.TryParse(mct_Result.Result.ToString(), out result6);
						if (result6 == 0)
						{
							return Messages.msgErrorRunFunction + " (" + Labels.LinkedRollsPrjInfo + ")";
						}
					}
				}
				if (isLinkedCnvs)
				{
					mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspDeleteLinkedRollsForRollAll(25, rollId, result3));
					if (mct_Result != null)
					{
						int result7 = 0;
						int.TryParse(mct_Result.Result.ToString(), out result7);
						if (result7 == 0)
						{
							return Messages.msgErrorRunFunction + " (" + Labels.LinkedRollsCnvsInfo + ")";
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = Messages.msgErrorRunFunction + "<br>" + ex.Message;
		}
		return result;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		base.Dispose(disposing);
	}
}

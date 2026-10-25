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
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Accounts.Controllers;

public class UserAccessController : Controller
{
	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actuLinkedOprAccessForUser")]
	public ActionResult Opr()
	{
		return View();
	}

	[AjaxOnly]
	public JsonResult LoadOprs(int mode, int crmUserId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<nComboBoxListItem> list = new List<nComboBoxListItem>();
		try
		{
			switch (mode)
			{
			case 1:
			{
				List<WSspSelectPreOrderTypeUserAccess_Result> list4 = Enumerable.ToList<WSspSelectPreOrderTypeUserAccess_Result>((IEnumerable<WSspSelectPreOrderTypeUserAccess_Result>)_dbII.WSspSelectPreOrderTypeUserAccess(crmUserId, lCID, result));
				if (list4 == null || !Enumerable.Any<WSspSelectPreOrderTypeUserAccess_Result>((IEnumerable<WSspSelectPreOrderTypeUserAccess_Result>)list4))
				{
					break;
				}
				foreach (WSspSelectPreOrderTypeUserAccess_Result item4 in list4)
				{
					nComboBoxListItem item3 = new nComboBoxListItem
					{
						Value = item4.PreOrderTypeId.ToString(),
						Text = (item4.PreOrderType ?? ""),
						Selected = item4.UserAccess.GetValueOrDefault()
					};
					list.Add(item3);
				}
				break;
			}
			case 2:
			{
				List<WSspSelectOrderOprUserAccess_Result> list3 = Enumerable.ToList<WSspSelectOrderOprUserAccess_Result>((IEnumerable<WSspSelectOrderOprUserAccess_Result>)_dbII.WSspSelectOrderOprUserAccess(crmUserId, lCID, result));
				if (list3 == null || !Enumerable.Any<WSspSelectOrderOprUserAccess_Result>((IEnumerable<WSspSelectOrderOprUserAccess_Result>)list3))
				{
					break;
				}
				foreach (WSspSelectOrderOprUserAccess_Result item5 in list3)
				{
					nComboBoxListItem item2 = new nComboBoxListItem
					{
						Value = item5.OrderOprID.ToString(),
						Text = (item5.Name ?? ""),
						Selected = item5.UserAccess.GetValueOrDefault()
					};
					list.Add(item2);
				}
				break;
			}
			case 3:
			{
				List<WSspSelectBuyOrderOprUserAccess_Result> list2 = Enumerable.ToList<WSspSelectBuyOrderOprUserAccess_Result>((IEnumerable<WSspSelectBuyOrderOprUserAccess_Result>)_dbII.WSspSelectBuyOrderOprUserAccess(crmUserId, lCID, result));
				if (list2 == null || !Enumerable.Any<WSspSelectBuyOrderOprUserAccess_Result>((IEnumerable<WSspSelectBuyOrderOprUserAccess_Result>)list2))
				{
					break;
				}
				foreach (WSspSelectBuyOrderOprUserAccess_Result item6 in list2)
				{
					nComboBoxListItem item = new nComboBoxListItem
					{
						Value = item6.BuyOrderOprID.ToString(),
						Text = (item6.Name ?? ""),
						Selected = item6.UserAccess.GetValueOrDefault()
					};
					list.Add(item);
				}
				break;
			}
			}
			if (list == null)
			{
				list = new List<nComboBoxListItem>();
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
	public string ActAssign(int mode, string crmUserIds, int oprId)
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
			if (!UserLogin.IsUserAccess("frmMain", "actuLinkedOprAccessForUser", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			int userId = UserLogin.CurrentUser.UserId;
			int id = Financial.Get().Id;
			string text = "";
			switch (mode)
			{
			case 1:
				text = "WSPreOrderTypeUserAccess";
				_dbII.WSspInsertPreOrderTypeUserAccess(crmUserIds, oprId, userId, id, value2, value, registerDatePersian, appType, result2);
				break;
			case 2:
				text = "WSOrderOprUserAccess";
				_dbII.WSspInsertOrderOprUserAccess(crmUserIds, oprId, userId, id, value2, value, registerDatePersian, appType, result2);
				break;
			case 3:
				text = "WSBuyOrderOprUserAccess";
				_dbII.WSspInsertBuyOrderOprUserAccess(crmUserIds, oprId, userId, id, value2, value, registerDatePersian, appType, result2);
				break;
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo(text);
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
	public string ActRemove(int mode, string crmUserIds, int oprId)
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
			if (!UserLogin.IsUserAccess("frmMain", "actuLinkedOprAccessForUser", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			string text = "";
			switch (mode)
			{
			case 1:
				text = "WSPreOrderTypeUserAccess";
				_dbII.WSspDeletePreOrderTypeUserAccess(crmUserIds, oprId);
				break;
			case 2:
				text = "WSOrderOprUserAccess";
				_dbII.WSspDeleteOrderOprUserAccess(crmUserIds, oprId);
				break;
			case 3:
				text = "WSBuyOrderOprUserAccess";
				_dbII.WSspDeleteBuyOrderOprUserAccess(crmUserIds, oprId);
				break;
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo(text);
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
	public string ActAssignAll(int mode, string crmUserIds)
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
			if (!UserLogin.IsUserAccess("frmMain", "actuLinkedOprAccessForUser", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			int userId = UserLogin.CurrentUser.UserId;
			int id = Financial.Get().Id;
			string text = "";
			switch (mode)
			{
			case 1:
				text = "WSPreOrderTypeUserAccess";
				_dbII.WSspInsertPreOrderTypeUserAccessAll(crmUserIds, userId, id, value2, value, registerDatePersian, appType, result2);
				break;
			case 2:
				text = "WSOrderOprUserAccess";
				_dbII.WSspInsertOrderOprUserAccessAll(crmUserIds, userId, id, value2, value, registerDatePersian, appType, result2);
				break;
			case 3:
				text = "WSBuyOrderOprUserAccess";
				_dbII.WSspInsertBuyOrderOprUserAccessAll(crmUserIds, userId, id, value2, value, registerDatePersian, appType, result2);
				break;
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo(text);
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
	public string ActRemoveAll(int mode, string crmUserIds)
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
			if (!UserLogin.IsUserAccess("frmMain", "actuLinkedOprAccessForUser", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			string text = "";
			switch (mode)
			{
			case 1:
				text = "WSPreOrderTypeUserAccess";
				_dbII.WSspDeletePreOrderTypeUserAccessAll(crmUserIds);
				break;
			case 2:
				text = "WSOrderOprUserAccess";
				_dbII.WSspDeleteOrderOprUserAccessAll(crmUserIds);
				break;
			case 3:
				text = "WSBuyOrderOprUserAccess";
				_dbII.WSspDeleteBuyOrderOprUserAccessAll(crmUserIds);
				break;
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo(text);
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = Messages.msgErrorRunFunction + "<br>" + ex.Message;
		}
		return result;
	}

	private List<SelectListItem> GetUserActiveList()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int result = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
			}
			List<CRMspSelectActiveUsers_Result> list2 = CRMIdeal.Classes.Helper.User.SelectActiveUsers(result);
			if (list2 != null)
			{
				if (Enumerable.Any<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)list2))
				{
					List<CRMspSelectUsersByIds_Result> list3 = CRMIdeal.Classes.Helper.User.SelectUsersByIds("-10,-15,-20");
					if (list3 != null && Enumerable.Any<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list3))
					{
						foreach (CRMspSelectUsersByIds_Result item in list3)
						{
							list.Add(new SelectListItem
							{
								Text = item.FullName,
								Value = item.UserId.ToString(),
								Selected = false
							});
						}
					}
				}
				list.AddRange(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)list2, (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result item) => new SelectListItem
				{
					Text = item.Name,
					Value = item.UserId.ToString(),
					Selected = false
				})));
			}
			if (list != null)
			{
				foreach (SelectListItem item2 in Enumerable.Where<SelectListItem>((IEnumerable<SelectListItem>)list, (Func<SelectListItem, bool>)((SelectListItem item) => item.Value == UserLogin.CurrentUser.UserId.ToString())))
				{
					item2.Selected = true;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetUserActiveCombo(string selectedId = "")
	{
		string result = "";
		try
		{
			List<SelectListItem> userActiveList = GetUserActiveList();
			if (userActiveList != null)
			{
				result = JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<SelectListItem, nComboBoxListItem>((IEnumerable<SelectListItem>)userActiveList, (Func<SelectListItem, nComboBoxListItem>)((SelectListItem item) => new nComboBoxListItem
				{
					Text = item.Text,
					Value = item.Value,
					Selected = (item.Value == selectedId)
				}))));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actuLinkedOrdPayTypeAccessForUser")]
	public ActionResult OrderPaymentType()
	{
		return View();
	}

	[AjaxOnly]
	public JsonResult LoadOrderPaymentTypes(int mode, int crmUserId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<nComboBoxListItem> list = new List<nComboBoxListItem>();
		try
		{
			if (mode == 1)
			{
				List<WSspSelectOrderPaymentTypeUserAccess_Result> list2 = Enumerable.ToList<WSspSelectOrderPaymentTypeUserAccess_Result>((IEnumerable<WSspSelectOrderPaymentTypeUserAccess_Result>)_dbII.WSspSelectOrderPaymentTypeUserAccess(crmUserId, lCID, result));
				if (list2 != null && Enumerable.Any<WSspSelectOrderPaymentTypeUserAccess_Result>((IEnumerable<WSspSelectOrderPaymentTypeUserAccess_Result>)list2))
				{
					foreach (WSspSelectOrderPaymentTypeUserAccess_Result item2 in list2)
					{
						nComboBoxListItem item = new nComboBoxListItem
						{
							Value = item2.OrderPaymentTypeID.ToString(),
							Text = (item2.ordpayType ?? ""),
							Selected = item2.UserAccess.GetValueOrDefault()
						};
						list.Add(item);
					}
				}
			}
			if (list == null)
			{
				list = new List<nComboBoxListItem>();
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
	public string ActAssignOrdPayType(int mode, string crmUserIds, int payTypeId)
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
			if (!UserLogin.IsUserAccess("frmMain", "actuLinkedOrdPayTypeAccessForUser", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			int userId = UserLogin.CurrentUser.UserId;
			int id = Financial.Get().Id;
			string text = "";
			if (mode == 1)
			{
				text = "WSOrderPaymentTypeUserAccess";
				_dbII.WSspInsertOrderPaymentTypeUserAccess(crmUserIds, payTypeId, userId, id, value2, value, registerDatePersian, appType, result2);
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo(text);
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
	public string ActRemoveOrdPayType(int mode, string crmUserIds, int payTypeId)
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
			if (!UserLogin.IsUserAccess("frmMain", "actuLinkedOrdPayTypeAccessForUser", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			string text = "";
			if (mode == 1)
			{
				text = "WSOrderPaymentTypeUserAccess";
				_dbII.WSspDeleteOrderPaymentTypeUserAccess(crmUserIds, payTypeId);
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo(text);
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
	public string ActAssignAllOrdPayType(int mode, string crmUserIds)
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
			if (!UserLogin.IsUserAccess("frmMain", "actuLinkedOrdPayTypeAccessForUser", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			int userId = UserLogin.CurrentUser.UserId;
			int id = Financial.Get().Id;
			string text = "";
			if (mode == 1)
			{
				text = "WSOrderPaymentTypeUserAccess";
				_dbII.WSspInsertOrderPaymentTypeUserAccessAll(crmUserIds, userId, id, value2, value, registerDatePersian, appType, result2);
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo(text);
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
	public string ActRemoveAllOrdPayType(int mode, string crmUserIds)
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
			if (!UserLogin.IsUserAccess("frmMain", "actuLinkedOrdPayTypeAccessForUser", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			string text = "";
			if (mode == 1)
			{
				text = "WSOrderPaymentTypeUserAccess";
				_dbII.WSspDeleteOrderPaymentTypeUserAccessAll(crmUserIds);
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo(text);
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
		_dbII.Dispose();
		base.Dispose(disposing);
	}
}

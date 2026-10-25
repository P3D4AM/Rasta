using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Calendar;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Areas.OtherSystems.Controllers;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.BuyOrders.Controllers;

public class IssueOrderController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	private readonly CRMSpIIIEntities _dbIII = new CRMSpIIIEntities();

	[DynamicAuthorize(ControllerName = "frmBuyOrder", ActionName = "actIssueOrder")]
	public ActionResult Index(int bordId, string parameters = "")
	{
		base.ViewBag.BuyOrderId = bordId;
		base.ViewBag.IsBuying = VersionBuyer.BordPlus && VersionBuyer.Order;
		string text = "";
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			string[] array = parameters.Split(new char[1] { '|' });
			base.ViewBag.MyParameters = array;
			if (bordId > 0)
			{
				if (string.IsNullOrWhiteSpace(parameters))
				{
					WSspSelectBuyOrderById_Result wSspSelectBuyOrderById_Result = Enumerable.FirstOrDefault<WSspSelectBuyOrderById_Result>((IEnumerable<WSspSelectBuyOrderById_Result>)_dbII.WSspSelectBuyOrderById(bordId, lCID, result));
					if (wSspSelectBuyOrderById_Result != null)
					{
						num = wSspSelectBuyOrderById_Result.bordReqCmpId.GetValueOrDefault();
						num2 = wSspSelectBuyOrderById_Result.bordReqPrsId.GetValueOrDefault();
						num3 = wSspSelectBuyOrderById_Result.bordReqPrjId.GetValueOrDefault();
					}
				}
				if (num != 0)
				{
					CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(num);
					if (companyById != null)
					{
						text = companyById.cmpTitle ?? "";
						if (!string.IsNullOrWhiteSpace(text))
						{
							text += " ";
						}
						text += companyById.cmpName;
					}
				}
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		base.ViewBag.IsBuying = VersionBuyer.BordPlus && VersionBuyer.Order;
		base.ViewBag.CmpId = num;
		base.ViewBag.PrsId = num2;
		base.ViewBag.PrjId = num3;
		base.ViewBag.CmpFullName = text;
		GetOrderOpr();
		GetOrderReferUsers();
		GetOrderPrintFormat();
		GetOrderDefSetting();
		GetOrdSetPementType();
		return View();
	}

	[AjaxOnly]
	public JsonResult GetOrderOpr()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<WSspSelectOrderOpr_Result> list2 = Order.SelectOrderOpr();
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<WSspSelectOrderOpr_Result, SelectListItem>((IEnumerable<WSspSelectOrderOpr_Result>)list2, (Func<WSspSelectOrderOpr_Result, SelectListItem>)((WSspSelectOrderOpr_Result item) => new SelectListItem
				{
					Text = item.Name,
					Value = item.OrderOprID.ToString(),
					Selected = false
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.OrdOprList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetOrderReferUsers()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectUserForLinkedTypeIsActive_Result> list2 = Enumerable.ToList<CRMspSelectUserForLinkedTypeIsActive_Result>((IEnumerable<CRMspSelectUserForLinkedTypeIsActive_Result>)_dbI.CRMspSelectUserForLinkedTypeIsActive(UserLogin.CurrentUser.UserId, 7, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectUserForLinkedTypeIsActive_Result, SelectListItem>((IEnumerable<CRMspSelectUserForLinkedTypeIsActive_Result>)list2, (Func<CRMspSelectUserForLinkedTypeIsActive_Result, SelectListItem>)((CRMspSelectUserForLinkedTypeIsActive_Result item) => new SelectListItem
			{
				Text = item.UserName,
				Value = item.LinkedUserId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.OrdReferUserList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetOrderPrintFormat()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<spSelectPrintFormat_Result> list2 = CRMIdeal.Classes.Helper.PrintFormat.GetspPrintFortants(result2, 2);
			list.AddRange(Enumerable.Select<spSelectPrintFormat_Result, SelectListItem>((IEnumerable<spSelectPrintFormat_Result>)list2, (Func<spSelectPrintFormat_Result, SelectListItem>)((spSelectPrintFormat_Result item) => new SelectListItem
			{
				Text = item.Title,
				Value = item.PrintFormatID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.OrdPrintFormatList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetOrderDefSetting()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int userId = UserLogin.CurrentUser.UserId;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<WSspSelectOrderDefaultSettingUserAccess_Result> list2 = Enumerable.ToList<WSspSelectOrderDefaultSettingUserAccess_Result>((IEnumerable<WSspSelectOrderDefaultSettingUserAccess_Result>)_dbIII.WSspSelectOrderDefaultSettingUserAccess((short)1, userId, lCID, result));
			int? defSettingId = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbIII.WSspSelectOrderDefaultSettingIsDefUserAccess((short)1, userId, lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectOrderDefaultSettingUserAccess_Result, SelectListItem>((IEnumerable<WSspSelectOrderDefaultSettingUserAccess_Result>)list2, (Func<WSspSelectOrderDefaultSettingUserAccess_Result, SelectListItem>)((WSspSelectOrderDefaultSettingUserAccess_Result item) => new SelectListItem
			{
				Text = item.SettingTitle,
				Value = item.OrderSettingID.ToString(),
				Selected = (item.OrderSettingID == defSettingId.GetValueOrDefault())
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ordDefSettingList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetOrdSetPementType()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<WSspSettlementType_Result> list2 = Enumerable.ToList<WSspSettlementType_Result>((IEnumerable<WSspSettlementType_Result>)_db.WSspSettlementType(lCID, result));
			list.AddRange(Enumerable.Select<WSspSettlementType_Result, SelectListItem>((IEnumerable<WSspSettlementType_Result>)list2, (Func<WSspSettlementType_Result, SelectListItem>)((WSspSettlementType_Result item) => new SelectListItem
			{
				Text = item.Name,
				Value = item.Id.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.OrdSettlementTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetProductPriceGroup()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<WSspSelectProductPriceGroup_Result> list2 = Enumerable.ToList<WSspSelectProductPriceGroup_Result>((IEnumerable<WSspSelectProductPriceGroup_Result>)_db.WSspSelectProductPriceGroup(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectProductPriceGroup_Result, SelectListItem>((IEnumerable<WSspSelectProductPriceGroup_Result>)list2, (Func<WSspSelectProductPriceGroup_Result, SelectListItem>)((WSspSelectProductPriceGroup_Result item) => new SelectListItem
			{
				Text = item.ProductPriceGroupName,
				Value = item.ProductPriceGroupID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ProductPriceGroupList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public List<WSspSelectBuyOrderItemsWithOrdItemQuantity_Result> GetBuyOrderItems(int bordId)
	{
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectBuyOrderItemsWithOrdItemQuantity_Result> list = new List<WSspSelectBuyOrderItemsWithOrdItemQuantity_Result>();
		try
		{
			if (bordId > 0)
			{
				int result2 = 0;
				if (UserLogin.CurrentUser != null)
				{
					int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
				}
				list = Enumerable.ToList<WSspSelectBuyOrderItemsWithOrdItemQuantity_Result>((IEnumerable<WSspSelectBuyOrderItemsWithOrdItemQuantity_Result>)_dbII.WSspSelectBuyOrderItemsWithOrdItemQuantity(bordId, lCID, result, result2));
				if (list != null && Enumerable.Any<WSspSelectBuyOrderItemsWithOrdItemQuantity_Result>((IEnumerable<WSspSelectBuyOrderItemsWithOrdItemQuantity_Result>)list))
				{
					foreach (WSspSelectBuyOrderItemsWithOrdItemQuantity_Result item2 in list)
					{
						if (string.IsNullOrWhiteSpace(item2.ListPrdPriceGroup))
						{
							continue;
						}
						List<SelectListItem> list2 = new List<SelectListItem>();
						List<WSspSelectProductPriceGroupByPrdId_Result> list3 = new JavaScriptSerializer().Deserialize<List<WSspSelectProductPriceGroupByPrdId_Result>>(item2.ListPrdPriceGroup);
						if (list3 != null && Enumerable.Any<WSspSelectProductPriceGroupByPrdId_Result>((IEnumerable<WSspSelectProductPriceGroupByPrdId_Result>)list3))
						{
							foreach (WSspSelectProductPriceGroupByPrdId_Result item3 in list3)
							{
								string text = "";
								text = ((!item3.LastPriceDocDateTime.HasValue) ? "" : (item3.LastPriceDocDateTime.HasValue ? item3.LastPriceDocDateTime.Value.ToString("yyyy/MM/dd") : ""));
								if (!string.IsNullOrWhiteSpace(text))
								{
									text = " (" + text + ")";
								}
								SelectListItem item = new SelectListItem
								{
									Text = item3.ProductPriceGroupName + text,
									Value = item3.ProductPriceGroupID.ToString()
								};
								list2.Add(item);
							}
						}
						if (list2 != null)
						{
							item2.ListPrdPriceGroup = JsonConvert.SerializeObject(Enumerable.ToList<SelectListItem>((IEnumerable<SelectListItem>)list2));
						}
					}
				}
				if (list == null)
				{
					list = new List<WSspSelectBuyOrderItemsWithOrdItemQuantity_Result>();
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public ActionResult _PartialBuyOrderItems(int bordId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectBuyOrderItemsWithOrdItemQuantity_Result> list = new List<WSspSelectBuyOrderItemsWithOrdItemQuantity_Result>();
		GetProductPriceGroup();
		try
		{
			list = GetBuyOrderItems(bordId);
			if (list == null)
			{
				list = new List<WSspSelectBuyOrderItemsWithOrdItemQuantity_Result>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView(list);
	}

	public List<WSspReturnOrderFromBuyOrder_Result> GetOrders(int bordId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspReturnOrderFromBuyOrder_Result> list = new List<WSspReturnOrderFromBuyOrder_Result>();
		try
		{
			list = Enumerable.ToList<WSspReturnOrderFromBuyOrder_Result>((IEnumerable<WSspReturnOrderFromBuyOrder_Result>)_dbII.WSspReturnOrderFromBuyOrder(bordId, lCID, result));
			if (list != null && Enumerable.Any<WSspReturnOrderFromBuyOrder_Result>((IEnumerable<WSspReturnOrderFromBuyOrder_Result>)list))
			{
				foreach (WSspReturnOrderFromBuyOrder_Result item in list)
				{
					item.ordDate = (item.ordDateTime.HasValue ? item.ordDateTime.Value.ToString("yyyy/MM/dd") : "");
					item.OrderInfo = string.Format(Labels.IssueOrderFromBordOrderInfo, item.OrderOpr ?? "lblOrd".OrderLabels(), item.ordNumber.ToString(), item.ordDate);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public JsonResult GetOrderList(int bordId)
	{
		List<WSspReturnOrderFromBuyOrder_Result> data = new List<WSspReturnOrderFromBuyOrder_Result>();
		try
		{
			data = GetOrders(bordId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public string IssueOrder(int bordId, string ordDate, int orderOperId, int ordPrintFormatId, int ordReferUserId, int cmpId, int prsId, int prjId, int ordSettlementTypeId, string ordNote, string ordNote_Lang, string bordItems, int ordDefSettingId = 0)
	{
		//IL_0bec: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		string result = "-1";
		if (bordId > 0)
		{
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
				if (result2 <= 0)
				{
					result2 = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				int? num = null;
				if (UserLogin.CurrentUser != null)
				{
					num = UserLogin.CurrentUser.UserLastCId;
				}
				if (!VersionBuyer.BordPlus || !VersionBuyer.Order)
				{
					return "BV|" + Messages.VersionBuy;
				}
				List<IssueOrderFromBuyOrderItemsViewModel> list = new List<IssueOrderFromBuyOrderItemsViewModel>();
				if (!string.IsNullOrWhiteSpace(bordItems))
				{
					list = new JavaScriptSerializer().Deserialize<List<IssueOrderFromBuyOrderItemsViewModel>>(bordItems);
				}
				List<IssueOrderFromBuyOrderItemsViewModel> list2 = new List<IssueOrderFromBuyOrderItemsViewModel>();
				string text = "";
				if (Enumerable.Any<IssueOrderFromBuyOrderItemsViewModel>((IEnumerable<IssueOrderFromBuyOrderItemsViewModel>)list))
				{
					list2 = Enumerable.ToList<IssueOrderFromBuyOrderItemsViewModel>(Enumerable.Where<IssueOrderFromBuyOrderItemsViewModel>((IEnumerable<IssueOrderFromBuyOrderItemsViewModel>)list, (Func<IssueOrderFromBuyOrderItemsViewModel, bool>)((IssueOrderFromBuyOrderItemsViewModel m) => m.PrdQty.GetValueOrDefault() > 0.0)));
				}
				if (list2 != null && Enumerable.Any<IssueOrderFromBuyOrderItemsViewModel>((IEnumerable<IssueOrderFromBuyOrderItemsViewModel>)list2))
				{
					text = JsonConvert.SerializeObject(Enumerable.ToList<IssueOrderFromBuyOrderItemsViewModel>((IEnumerable<IssueOrderFromBuyOrderItemsViewModel>)list2));
				}
				WSspSelectBuyOrderById_Result wSspSelectBuyOrderById_Result = Enumerable.FirstOrDefault<WSspSelectBuyOrderById_Result>((IEnumerable<WSspSelectBuyOrderById_Result>)_dbII.WSspSelectBuyOrderById(bordId, lCID, result2));
				if (wSspSelectBuyOrderById_Result != null)
				{
					int result3 = 0;
					int.TryParse(wSspSelectBuyOrderById_Result.bordStatusId.ToString(), out result3);
					if (result3 == 4 || result3 == 5)
					{
						return "MOJ|" + "msgErrorIssueOrderForCanceledBord".OrderMessages();
					}
				}
				result = "msgErrorNotFindOrderForBuyOrder".OrderMessages();
				WSspReturnOrderFromBuyOrder_Result wSspReturnOrderFromBuyOrder_Result = new WSspReturnOrderFromBuyOrder_Result();
				string text2 = "";
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
				if (defLangID <= 0)
				{
					defLangID = 1065;
				}
				int lCID2 = Thread.CurrentThread.CurrentCulture.LCID;
				List<WSspReturnOrderFromBuyOrder_Result> orders = GetOrders(bordId);
				if (orders != null && Enumerable.Any<WSspReturnOrderFromBuyOrder_Result>((IEnumerable<WSspReturnOrderFromBuyOrder_Result>)orders))
				{
					wSspReturnOrderFromBuyOrder_Result = Enumerable.LastOrDefault<WSspReturnOrderFromBuyOrder_Result>((IEnumerable<WSspReturnOrderFromBuyOrder_Result>)orders);
					if (orders.Count > 1)
					{
						foreach (WSspReturnOrderFromBuyOrder_Result item2 in orders)
						{
							text2 = text2 + item2.ordNumber + ",";
						}
						if (!string.IsNullOrWhiteSpace(text2) && text2.EndsWith(","))
						{
							text2 = text2.TrimEnd(new char[1] { ',' });
						}
					}
				}
				else
				{
					wSspReturnOrderFromBuyOrder_Result = null;
				}
				mct_II_Result mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.WSspCheckBuyOrderHaveOrder(bordId));
				int result4 = 0;
				if (mct_II_Result != null)
				{
					int.TryParse(mct_II_Result.Result.ToString(), out result4);
					if (result4 == 0)
					{
						wSspReturnOrderFromBuyOrder_Result = null;
					}
				}
				if (wSspReturnOrderFromBuyOrder_Result != null && result4 == 1)
				{
					if (string.IsNullOrWhiteSpace(text2))
					{
						text2 = wSspReturnOrderFromBuyOrder_Result.ordNumber.ToString();
					}
					string text3 = (wSspReturnOrderFromBuyOrder_Result.ordDateTime.HasValue ? wSspReturnOrderFromBuyOrder_Result.ordDateTime.Value.ToString("yyyy/MM/dd") : "");
					string text4 = (wSspReturnOrderFromBuyOrder_Result.FirstRegisterDate.HasValue ? wSspReturnOrderFromBuyOrder_Result.FirstRegisterDate.Value.ToString("yyyy/MM/dd") : "");
					string text5 = string.Format("msgErrorOrderIssuedForBuyOrder".OrderMessages(), text2, text3, text4, wSspReturnOrderFromBuyOrder_Result.FirstRegisterUserName ?? "");
					result = "1|" + Labels.Error + " !!\r\n" + text5 + "|" + wSspReturnOrderFromBuyOrder_Result.OrderID + "|0";
				}
				else
				{
					if (UserLogin.IsUserAccess("frmIssueOrderFromBuyOrder", "actCanNotIssueOrderWithNoStock", UserLogin.CurrentUser))
					{
						CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
						bool flag = false;
						int num2 = 0;
						bool flag2 = false;
						if (cRMspSelectCrmsysSetting_Result != null)
						{
							flag = ((cRMspSelectCrmsysSetting_Result.InvStockFromLink.HasValue && cRMspSelectCrmsysSetting_Result.InvStockFromLink.GetValueOrDefault()) ? true : false);
							num2 = cRMspSelectCrmsysSetting_Result.LinkAccSystemId.GetValueOrDefault();
						}
						if (flag && num2 > 0)
						{
							List<IssueOrderFromBuyOrderItemsViewModel> list3 = new List<IssueOrderFromBuyOrderItemsViewModel>();
							if (list2 != null && Enumerable.Any<IssueOrderFromBuyOrderItemsViewModel>((IEnumerable<IssueOrderFromBuyOrderItemsViewModel>)list2))
							{
								foreach (IssueOrderFromBuyOrderItemsViewModel linkAccitem in list2)
								{
									bool flag3 = true;
									if (Enumerable.FirstOrDefault<IssueOrderFromBuyOrderItemsViewModel>((IEnumerable<IssueOrderFromBuyOrderItemsViewModel>)list3, (Func<IssueOrderFromBuyOrderItemsViewModel, bool>)((IssueOrderFromBuyOrderItemsViewModel m) => m.PrdId == linkAccitem.PrdId && m.WhId == linkAccitem.WhId && (m.LinkAccWHIdStr ?? "") == (linkAccitem.LinkAccWHIdStr ?? "") && (m.PrdTracing ?? "") == (linkAccitem.PrdTracing ?? "") && m.LinkAccSettingDBId.GetValueOrDefault() == linkAccitem.LinkAccSettingDBId.GetValueOrDefault())) != null)
									{
										flag3 = false;
									}
									if (!flag3)
									{
										continue;
									}
									List<IssueOrderFromBuyOrderItemsViewModel> list4 = Enumerable.ToList<IssueOrderFromBuyOrderItemsViewModel>(Enumerable.Where<IssueOrderFromBuyOrderItemsViewModel>((IEnumerable<IssueOrderFromBuyOrderItemsViewModel>)list2, (Func<IssueOrderFromBuyOrderItemsViewModel, bool>)((IssueOrderFromBuyOrderItemsViewModel m) => m.PrdId == linkAccitem.PrdId && m.WhId == linkAccitem.WhId && (m.LinkAccWHIdStr ?? "") == (linkAccitem.LinkAccWHIdStr ?? "") && (m.PrdTracing ?? "") == (linkAccitem.PrdTracing ?? "") && m.LinkAccSettingDBId.GetValueOrDefault() == linkAccitem.LinkAccSettingDBId.GetValueOrDefault())));
									double num3 = 0.0;
									if (list4 != null && Enumerable.Any<IssueOrderFromBuyOrderItemsViewModel>((IEnumerable<IssueOrderFromBuyOrderItemsViewModel>)list4))
									{
										foreach (IssueOrderFromBuyOrderItemsViewModel item3 in list4)
										{
											num3 += item3.PrdQty.GetValueOrDefault();
										}
									}
									IssueOrderFromBuyOrderItemsViewModel item = new IssueOrderFromBuyOrderItemsViewModel
									{
										BordItemId = linkAccitem.BordItemId,
										PrdQty = num3,
										PrdPrice = linkAccitem.PrdPrice,
										PrdPriceGroupId = linkAccitem.PrdPriceGroupId,
										PrdId = linkAccitem.PrdId,
										WhId = linkAccitem.WhId,
										LinkAccWHIdStr = linkAccitem.LinkAccWHIdStr,
										PrdTracing = linkAccitem.PrdTracing,
										OrdItemId = linkAccitem.OrdItemId,
										PriceCurrencyRate = linkAccitem.PriceCurrencyRate,
										LinkAccSettingDBId = linkAccitem.LinkAccSettingDBId
									};
									list3.Add(item);
								}
							}
							if (list3 != null && Enumerable.Any<IssueOrderFromBuyOrderItemsViewModel>((IEnumerable<IssueOrderFromBuyOrderItemsViewModel>)list3))
							{
								foreach (IssueOrderFromBuyOrderItemsViewModel item4 in list3)
								{
									int result5 = 0;
									int.TryParse(item4.BordItemId.ToString(), out result5);
									double result6 = 0.0;
									double.TryParse(item4.PrdQty.ToString(), out result6);
									int result7 = 0;
									int.TryParse(item4.PrdId.ToString(), out result7);
									int result8 = 0;
									int.TryParse(item4.WhId.ToString(), out result8);
									string text6 = item4.LinkAccWHIdStr ?? "";
									string text7 = ConvertCharacter.DecodeTracing(item4.PrdTracing ?? "");
									ProductController productController = new ProductController();
									string text8 = "";
									switch (num2)
									{
									case 3:
									{
										decimal prdPrice = default(decimal);
										double prdQuantity = 0.0;
										productController.TarazGetPrdQuantityAndPrice(result7, cmpId, result8, 0, ref prdPrice, ref prdQuantity, "pord", 0);
										text8 = prdQuantity.ToString();
										break;
									}
									case 4:
										text8 = productController.HolooGetPrdQuantity(result7, item4.LinkAccSettingDBId.HasValue ? item4.LinkAccSettingDBId.Value : 0);
										break;
									case 6:
										text8 = productController.KyanGetPrdQuantity(result7, result8);
										break;
									case 7:
										text8 = productController.PayvastGetPrdQuantity(result7, result8);
										break;
									case 11:
										text8 = productController.ShomaranGetPrdQuantity(result7, result8, text6 ?? "", text7 ?? "");
										break;
									case 12:
										text8 = productController.LinkAccGetPrdQuantity(num2, result7, result8, text6 ?? "", text7 ?? "");
										break;
									default:
										text8 = productController.LinkAccGetPrdQuantity(num2, result7, result8, text6 ?? "", text7 ?? "");
										break;
									}
									double result9 = 0.0;
									if (string.IsNullOrEmpty(text8))
									{
										continue;
									}
									if (text8 == Labels.frmError)
									{
										text8 = "0";
									}
									if (!(text8 != Labels.frmError))
									{
										continue;
									}
									double.TryParse(text8, out result9);
									if (result9 < result6)
									{
										string arg = "";
										WSspSelectProductsWithId_Result wSspSelectProductsWithId_Result = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(result7, lCID, defLangID));
										if (wSspSelectProductsWithId_Result != null)
										{
											arg = wSspSelectProductsWithId_Result.PrdName ?? "";
										}
										flag2 = true;
										result = "MOJ|" + string.Format("msgErrorUnableIssueOrderFormBuyOrderPrdNotStock".OrderMessages(), arg);
										return result.Replace("\\n\\r", "<br>").Replace("\\r\\n", "<br>");
									}
									flag2 = true;
								}
							}
						}
						if (!flag2)
						{
							CRMSpIIEntities dbII = _dbII;
							int? buyOrderId = bordId;
							int? languageID = lCID2;
							int? defaultLanguageID = defLangID;
							WSspControlBuyOrderItemsStock_Result wSspControlBuyOrderItemsStock_Result = Enumerable.FirstOrDefault<WSspControlBuyOrderItemsStock_Result>((IEnumerable<WSspControlBuyOrderItemsStock_Result>)dbII.WSspControlBuyOrderItemsStock(buyOrderId, text, languageID, defaultLanguageID, num));
							if (wSspControlBuyOrderItemsStock_Result != null)
							{
								result = "MOJ|" + string.Format("msgErrorUnableIssueOrderFormBuyOrderPrdNotStock".OrderMessages(), wSspControlBuyOrderItemsStock_Result.PrdName ?? "");
								return result.Replace("\\n\\r", "<br>").Replace("\\r\\n", "<br>");
							}
						}
					}
					if (UserLogin.IsUserAccess("frmIssueOrderFromBuyOrder", "actCanNotIssueOrderWithNoStockFromSold", UserLogin.CurrentUser))
					{
						string bordItemJson = "";
						if (!string.IsNullOrWhiteSpace(text))
						{
							bordItemJson = text;
						}
						string text9 = "";
						text9 = BuyOrder.ControlBuyOrderItemsSoldStock(bordId, 1, "", bordItemJson);
						if (!string.IsNullOrWhiteSpace(text9))
						{
							return "MOJ|" + text9;
						}
					}
					if (ordDate != null)
					{
						ordDate = ordDate.Replace("/", "").Replace("-", "").Replace("_", "")
							.Replace(".", "")
							.Replace(",", "")
							.Replace("\\", "");
					}
					DateTime value = default(DateTime);
					DateTime dateTime = default(DateTime);
					string text10 = "";
					try
					{
						if (!string.IsNullOrWhiteSpace(ordDate))
						{
							text10 = PersianDate.GetFormatetdDate(ordDate.Replace("/", ""));
							switch (lCID)
							{
							case 1065:
								dateTime = DateTime.Parse(text10 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
								ordDate = dateTime.ToString("yyyyMMdd");
								break;
							case 1025:
								dateTime = DateTime.Parse(text10 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
								ordDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							default:
								dateTime = DateTime.Parse(text10 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
								ordDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							}
							value = dateTime;
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						result = "-1";
					}
					string orderNote = "";
					string orderNoteLang = "";
					List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrWhiteSpace(ordNote_Lang))
					{
						list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(ordNote_Lang);
					}
					list5.Add(new CommonMultiLanguageViewModel
					{
						Value = ordNote,
						LanguageId = lCID2
					});
					if (list5 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5))
					{
						orderNote = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : "");
						orderNoteLang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID))));
					}
					DateTime now = DateTime.Now;
					DateTime value2 = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value3 = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					short value4 = short.Parse(now.ToString("yyyy", new PersianCulture()));
					int userId = UserLogin.CurrentUser.UserId;
					int id = Financial.Get().Id;
					ObjectParameter objectParameter = new ObjectParameter("InsertedOrderID", typeof(int));
					ObjectParameter objectParameter2 = new ObjectParameter("InsertedOrderNumber", typeof(long));
					mct_II_Result mct_II_Result2 = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.WSspIssueOrderFromBuyOrder(bordId, prjId, cmpId, prsId, ordDate, value, orderOperId, ordReferUserId, (ordPrintFormatId == 0) ? null : new int?(ordPrintFormatId), (ordDefSettingId == 0) ? null : new int?(ordDefSettingId), (ordSettlementTypeId == 0) ? null : new int?(ordSettlementTypeId), orderNote, orderNoteLang, text, userId, value3, id, value2, registerDatePersian, appType, defLangID, objectParameter, objectParameter2, num));
					int result10 = 0;
					if (mct_II_Result2 != null)
					{
						int.TryParse(mct_II_Result2.Result.ToString(), out result10);
					}
					int result11 = 0;
					if (objectParameter.Value != null)
					{
						int.TryParse(objectParameter.Value.ToString(), out result11);
					}
					long result12 = 0L;
					if (objectParameter2.Value != null)
					{
						long.TryParse(objectParameter2.Value.ToString(), out result12);
					}
					if (result10 <= 0)
					{
						return result10 switch
						{
							-1 => "MOJ|" + "msgErrorAlreadyIssueOrderFromBord".OrderMessages(), 
							-2 => "MOJ|" + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.lblPrdI), 
							_ => "MOJ|" + Messages.msgErrorRunFunction, 
						};
					}
					string text11 = "";
					WSspReturnOrderFromBuyOrder_Result wSspReturnOrderFromBuyOrder_Result2 = new WSspReturnOrderFromBuyOrder_Result();
					orders = GetOrders(bordId);
					text2 = "";
					if (orders != null && Enumerable.Any<WSspReturnOrderFromBuyOrder_Result>((IEnumerable<WSspReturnOrderFromBuyOrder_Result>)orders))
					{
						wSspReturnOrderFromBuyOrder_Result2 = Enumerable.LastOrDefault<WSspReturnOrderFromBuyOrder_Result>((IEnumerable<WSspReturnOrderFromBuyOrder_Result>)orders);
						if (orders.Count > 1)
						{
							foreach (WSspReturnOrderFromBuyOrder_Result item5 in orders)
							{
								text2 = text2 + item5.ordNumber + ",";
								text11 = text11 + item5.OrderID + ",";
							}
							if (!string.IsNullOrWhiteSpace(text2) && text2.EndsWith(","))
							{
								text2 = text2.TrimEnd(new char[1] { ',' });
							}
							if (!string.IsNullOrWhiteSpace(text11) && text11.EndsWith(","))
							{
								text11 = text11.TrimEnd(new char[1] { ',' });
							}
						}
						CRMSpIEntities dbI = _dbI;
						bool? calcAutoScoreInIssue = true;
						bool? calcAutoScoreInVerify = false;
						dbI.ScorespInsertAndCalcOrderScores(null, null, null, null, null, calcAutoScoreInIssue, calcAutoScoreInVerify, DateTime.Now, userId, value4, value3, value2, registerDatePersian, appType, lCID2, defLangID, null, true, wSspSelectBuyOrderById_Result.bordCId ?? num);
					}
					else
					{
						wSspReturnOrderFromBuyOrder_Result2 = null;
					}
					if (wSspReturnOrderFromBuyOrder_Result2 != null)
					{
						if (string.IsNullOrWhiteSpace(text2))
						{
							text2 = wSspReturnOrderFromBuyOrder_Result2.ordNumber.ToString();
						}
						result = "2|" + result11 + "|" + text2 + "|0";
					}
					else
					{
						result = "2|" + result11 + "|" + result12 + "|1";
					}
				}
			}
			catch (Exception ex)
			{
				ErrorSignal.FromCurrentContext().Raise(ex);
				result = Messages.msgErrorRunFunction + "<br>" + ex.Message;
			}
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string SearchCompanyOrder(int cmpId, int prsId, int prjId, string textSerach = "")
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			List<WSspSearchCompanyOrder_Result> list = Enumerable.ToList<WSspSearchCompanyOrder_Result>((IEnumerable<WSspSearchCompanyOrder_Result>)_dbII.WSspSearchCompanyOrder(cmpId, prsId, prjId, textSerach, UserLogin.CurrentUser.UserId, lCID, result2, 100, result3));
			if (list != null)
			{
				result = JsonConvert.SerializeObject(list);
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[AjaxOnly]
	public string AddBuyOrderToOrder(int bordId, int cmpId, int ordId, string bordItems)
	{
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		string result = "-1";
		if (bordId > 0)
		{
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
				if (result2 <= 0)
				{
					result2 = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				int? centerId = null;
				if (UserLogin.CurrentUser != null)
				{
					centerId = UserLogin.CurrentUser.UserLastCId;
				}
				if (!VersionBuyer.BordPlus || !VersionBuyer.Order)
				{
					return "BV|" + Messages.VersionBuy;
				}
				List<IssueOrderFromBuyOrderItemsViewModel> list = new List<IssueOrderFromBuyOrderItemsViewModel>();
				if (!string.IsNullOrWhiteSpace(bordItems))
				{
					list = new JavaScriptSerializer().Deserialize<List<IssueOrderFromBuyOrderItemsViewModel>>(bordItems);
				}
				List<IssueOrderFromBuyOrderItemsViewModel> list2 = new List<IssueOrderFromBuyOrderItemsViewModel>();
				string text = "";
				if (Enumerable.Any<IssueOrderFromBuyOrderItemsViewModel>((IEnumerable<IssueOrderFromBuyOrderItemsViewModel>)list))
				{
					list2 = Enumerable.ToList<IssueOrderFromBuyOrderItemsViewModel>(Enumerable.Where<IssueOrderFromBuyOrderItemsViewModel>((IEnumerable<IssueOrderFromBuyOrderItemsViewModel>)list, (Func<IssueOrderFromBuyOrderItemsViewModel, bool>)((IssueOrderFromBuyOrderItemsViewModel m) => m.PrdQty.GetValueOrDefault() > 0.0)));
				}
				if (list2 != null && Enumerable.Any<IssueOrderFromBuyOrderItemsViewModel>((IEnumerable<IssueOrderFromBuyOrderItemsViewModel>)list2))
				{
					text = JsonConvert.SerializeObject(Enumerable.ToList<IssueOrderFromBuyOrderItemsViewModel>((IEnumerable<IssueOrderFromBuyOrderItemsViewModel>)list2));
				}
				WSspSelectBuyOrderById_Result wSspSelectBuyOrderById_Result = Enumerable.FirstOrDefault<WSspSelectBuyOrderById_Result>((IEnumerable<WSspSelectBuyOrderById_Result>)_dbII.WSspSelectBuyOrderById(bordId, lCID, result2));
				if (wSspSelectBuyOrderById_Result != null)
				{
					int result3 = 0;
					int.TryParse(wSspSelectBuyOrderById_Result.bordStatusId.ToString(), out result3);
					if (result3 == 4 || result3 == 5)
					{
						return "MOJ|" + "msgErrorAddBuyOrderToOrderByCanceledBord".OrderMessages();
					}
				}
				result = "msgErrorNotFindOrderForBuyOrder".OrderMessages();
				WSspReturnOrderFromBuyOrder_Result wSspReturnOrderFromBuyOrder_Result = new WSspReturnOrderFromBuyOrder_Result();
				string text2 = "";
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result4);
				if (result4 <= 0)
				{
					result4 = 1065;
				}
				int lCID2 = Thread.CurrentThread.CurrentCulture.LCID;
				List<WSspReturnOrderFromBuyOrder_Result> orders = GetOrders(bordId);
				if (orders != null && Enumerable.Any<WSspReturnOrderFromBuyOrder_Result>((IEnumerable<WSspReturnOrderFromBuyOrder_Result>)orders))
				{
					wSspReturnOrderFromBuyOrder_Result = Enumerable.LastOrDefault<WSspReturnOrderFromBuyOrder_Result>((IEnumerable<WSspReturnOrderFromBuyOrder_Result>)orders);
					if (orders.Count > 1)
					{
						foreach (WSspReturnOrderFromBuyOrder_Result item2 in orders)
						{
							text2 = text2 + item2.ordNumber + ",";
						}
						if (!string.IsNullOrWhiteSpace(text2) && text2.EndsWith(","))
						{
							text2 = text2.TrimEnd(new char[1] { ',' });
						}
					}
				}
				else
				{
					wSspReturnOrderFromBuyOrder_Result = null;
				}
				mct_II_Result mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.WSspCheckBuyOrderHaveOrder(bordId));
				int result5 = 0;
				if (mct_II_Result != null)
				{
					int.TryParse(mct_II_Result.Result.ToString(), out result5);
					if (result5 == 0)
					{
						wSspReturnOrderFromBuyOrder_Result = null;
					}
				}
				if (wSspReturnOrderFromBuyOrder_Result != null && result5 == 1)
				{
					if (string.IsNullOrWhiteSpace(text2))
					{
						text2 = wSspReturnOrderFromBuyOrder_Result.ordNumber.ToString();
					}
					string text3 = (wSspReturnOrderFromBuyOrder_Result.ordDateTime.HasValue ? wSspReturnOrderFromBuyOrder_Result.ordDateTime.Value.ToString("yyyy/MM/dd") : "");
					string text4 = (wSspReturnOrderFromBuyOrder_Result.FirstRegisterDate.HasValue ? wSspReturnOrderFromBuyOrder_Result.FirstRegisterDate.Value.ToString("yyyy/MM/dd") : "");
					string text5 = string.Format("msgErrorOrderIssuedForBuyOrder".OrderMessages(), text2, text3, text4, wSspReturnOrderFromBuyOrder_Result.FirstRegisterUserName ?? "");
					result = "1|" + Labels.Error + " !!\r\n" + text5 + "|" + wSspReturnOrderFromBuyOrder_Result.OrderID + "|0";
				}
				else
				{
					if (UserLogin.IsUserAccess("frmIssueOrderFromBuyOrder", "actCanNotIssueOrderWithNoStock", UserLogin.CurrentUser))
					{
						CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
						bool flag = false;
						int num = 0;
						bool flag2 = false;
						if (cRMspSelectCrmsysSetting_Result != null)
						{
							flag = ((cRMspSelectCrmsysSetting_Result.InvStockFromLink.HasValue && cRMspSelectCrmsysSetting_Result.InvStockFromLink.GetValueOrDefault()) ? true : false);
							num = cRMspSelectCrmsysSetting_Result.LinkAccSystemId.GetValueOrDefault();
						}
						if (flag && num > 0)
						{
							List<IssueOrderFromBuyOrderItemsViewModel> list3 = new List<IssueOrderFromBuyOrderItemsViewModel>();
							if (list2 != null && Enumerable.Any<IssueOrderFromBuyOrderItemsViewModel>((IEnumerable<IssueOrderFromBuyOrderItemsViewModel>)list2))
							{
								foreach (IssueOrderFromBuyOrderItemsViewModel linkAccitem in list2)
								{
									bool flag3 = true;
									if (Enumerable.FirstOrDefault<IssueOrderFromBuyOrderItemsViewModel>((IEnumerable<IssueOrderFromBuyOrderItemsViewModel>)list3, (Func<IssueOrderFromBuyOrderItemsViewModel, bool>)((IssueOrderFromBuyOrderItemsViewModel m) => m.PrdId == linkAccitem.PrdId && m.WhId == linkAccitem.WhId && (m.LinkAccWHIdStr ?? "") == (linkAccitem.LinkAccWHIdStr ?? "") && (m.PrdTracing ?? "") == (linkAccitem.PrdTracing ?? "") && m.LinkAccSettingDBId.GetValueOrDefault() == linkAccitem.LinkAccSettingDBId.GetValueOrDefault())) != null)
									{
										flag3 = false;
									}
									if (!flag3)
									{
										continue;
									}
									List<IssueOrderFromBuyOrderItemsViewModel> list4 = Enumerable.ToList<IssueOrderFromBuyOrderItemsViewModel>(Enumerable.Where<IssueOrderFromBuyOrderItemsViewModel>((IEnumerable<IssueOrderFromBuyOrderItemsViewModel>)list2, (Func<IssueOrderFromBuyOrderItemsViewModel, bool>)((IssueOrderFromBuyOrderItemsViewModel m) => m.PrdId == linkAccitem.PrdId && m.WhId == linkAccitem.WhId && (m.LinkAccWHIdStr ?? "") == (linkAccitem.LinkAccWHIdStr ?? "") && (m.PrdTracing ?? "") == (linkAccitem.PrdTracing ?? "") && m.LinkAccSettingDBId.GetValueOrDefault() == linkAccitem.LinkAccSettingDBId.GetValueOrDefault())));
									double num2 = 0.0;
									if (list4 != null && Enumerable.Any<IssueOrderFromBuyOrderItemsViewModel>((IEnumerable<IssueOrderFromBuyOrderItemsViewModel>)list4))
									{
										foreach (IssueOrderFromBuyOrderItemsViewModel item3 in list4)
										{
											num2 += item3.PrdQty.GetValueOrDefault();
										}
									}
									IssueOrderFromBuyOrderItemsViewModel item = new IssueOrderFromBuyOrderItemsViewModel
									{
										BordItemId = linkAccitem.BordItemId,
										PrdQty = num2,
										PrdPrice = linkAccitem.PrdPrice,
										PrdPriceGroupId = linkAccitem.PrdPriceGroupId,
										PrdId = linkAccitem.PrdId,
										WhId = linkAccitem.WhId,
										LinkAccWHIdStr = linkAccitem.LinkAccWHIdStr,
										PrdTracing = linkAccitem.PrdTracing,
										OrdItemId = linkAccitem.OrdItemId,
										PriceCurrencyRate = linkAccitem.PriceCurrencyRate,
										LinkAccSettingDBId = linkAccitem.LinkAccSettingDBId
									};
									list3.Add(item);
								}
							}
							if (list3 != null && Enumerable.Any<IssueOrderFromBuyOrderItemsViewModel>((IEnumerable<IssueOrderFromBuyOrderItemsViewModel>)list3))
							{
								foreach (IssueOrderFromBuyOrderItemsViewModel item4 in list3)
								{
									int result6 = 0;
									int.TryParse(item4.BordItemId.ToString(), out result6);
									double result7 = 0.0;
									double.TryParse(item4.PrdQty.ToString(), out result7);
									int result8 = 0;
									int.TryParse(item4.PrdId.ToString(), out result8);
									int result9 = 0;
									int.TryParse(item4.WhId.ToString(), out result9);
									string text6 = item4.LinkAccWHIdStr ?? "";
									string text7 = ConvertCharacter.DecodeTracing(item4.PrdTracing ?? "");
									ProductController productController = new ProductController();
									string text8 = "";
									switch (num)
									{
									case 3:
									{
										decimal prdPrice = default(decimal);
										double prdQuantity = 0.0;
										productController.TarazGetPrdQuantityAndPrice(result8, cmpId, result9, 0, ref prdPrice, ref prdQuantity, "pord", 0);
										text8 = prdQuantity.ToString();
										break;
									}
									case 4:
										text8 = productController.HolooGetPrdQuantity(result8, item4.LinkAccSettingDBId.HasValue ? item4.LinkAccSettingDBId.Value : 0);
										break;
									case 6:
										text8 = productController.KyanGetPrdQuantity(result8, result9);
										break;
									case 7:
										text8 = productController.PayvastGetPrdQuantity(result8, result9);
										break;
									case 11:
										text8 = productController.ShomaranGetPrdQuantity(result8, result9, text6 ?? "", text7 ?? "");
										break;
									case 12:
										text8 = productController.LinkAccGetPrdQuantity(num, result8, result9, text6 ?? "", text7 ?? "");
										break;
									default:
										text8 = productController.LinkAccGetPrdQuantity(num, result8, result9, text6 ?? "", text7 ?? "");
										break;
									}
									double result10 = 0.0;
									if (string.IsNullOrEmpty(text8))
									{
										continue;
									}
									if (text8 == Labels.frmError)
									{
										text8 = "0";
									}
									if (!(text8 != Labels.frmError))
									{
										continue;
									}
									double.TryParse(text8, out result10);
									if (result10 < result7)
									{
										string arg = "";
										WSspSelectProductsWithId_Result wSspSelectProductsWithId_Result = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(result8, lCID, result4));
										if (wSspSelectProductsWithId_Result != null)
										{
											arg = wSspSelectProductsWithId_Result.PrdName ?? "";
										}
										flag2 = true;
										result = "MOJ|" + string.Format("msgErrorUnableAddBuyOrderToOrderPrdNotStock".OrderMessages(), arg);
										return result.Replace("\\n\\r", "<br>").Replace("\\r\\n", "<br>");
									}
									flag2 = true;
								}
							}
						}
						if (!flag2)
						{
							CRMSpIIEntities dbII = _dbII;
							int? buyOrderId = bordId;
							int? languageID = lCID2;
							int? defaultLanguageID = result4;
							WSspControlBuyOrderItemsStock_Result wSspControlBuyOrderItemsStock_Result = Enumerable.FirstOrDefault<WSspControlBuyOrderItemsStock_Result>((IEnumerable<WSspControlBuyOrderItemsStock_Result>)dbII.WSspControlBuyOrderItemsStock(buyOrderId, text, languageID, defaultLanguageID, centerId));
							if (wSspControlBuyOrderItemsStock_Result != null)
							{
								result = "MOJ|" + string.Format("msgErrorUnableAddBuyOrderToOrderPrdNotStock".OrderMessages(), wSspControlBuyOrderItemsStock_Result.PrdName ?? "");
								return result.Replace("\\n\\r", "<br>").Replace("\\r\\n", "<br>");
							}
						}
					}
					if (UserLogin.IsUserAccess("frmIssueOrderFromBuyOrder", "actCanNotIssueOrderWithNoStockFromSold", UserLogin.CurrentUser))
					{
						string bordItemJson = "";
						if (!string.IsNullOrWhiteSpace(text))
						{
							bordItemJson = text;
						}
						string text9 = "";
						text9 = BuyOrder.ControlBuyOrderItemsSoldStock(bordId, 2, "", bordItemJson);
						if (!string.IsNullOrWhiteSpace(text9))
						{
							return "MOJ|" + text9;
						}
					}
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					short.Parse(now.ToString("yyyy", new PersianCulture()));
					int userId = UserLogin.CurrentUser.UserId;
					int id = Financial.Get().Id;
					ObjectParameter objectParameter = new ObjectParameter("Result", typeof(int));
					_dbII.WSspAddBuyOrderToOrder(ordId, bordId, text, userId, value2, id, value, registerDatePersian, appType, result4, objectParameter, centerId);
					int result11 = 0;
					if (objectParameter.Value != null)
					{
						int.TryParse(objectParameter.Value.ToString(), out result11);
					}
					if (result11 <= 0)
					{
						return result11 switch
						{
							-1 => "MOJ|" + "msgErrorAlreadyAddedBordToOrd".OrderMessages(), 
							-2 => "MOJ|" + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.lblPrdI), 
							-3 => "MOJ|" + string.Format(Messages.msgErrorIsNotFound, "lblOrd".OrderLabels()), 
							_ => "MOJ|" + Messages.msgErrorRunFunction, 
						};
					}
					string text10 = "";
					WSspReturnOrderFromBuyOrder_Result wSspReturnOrderFromBuyOrder_Result2 = new WSspReturnOrderFromBuyOrder_Result();
					orders = GetOrders(bordId);
					long num3 = 0L;
					text2 = "";
					if (orders != null && Enumerable.Any<WSspReturnOrderFromBuyOrder_Result>((IEnumerable<WSspReturnOrderFromBuyOrder_Result>)orders))
					{
						WSspReturnOrderFromBuyOrder_Result wSspReturnOrderFromBuyOrder_Result3 = Enumerable.FirstOrDefault<WSspReturnOrderFromBuyOrder_Result>((IEnumerable<WSspReturnOrderFromBuyOrder_Result>)orders, (Func<WSspReturnOrderFromBuyOrder_Result, bool>)((WSspReturnOrderFromBuyOrder_Result m) => m.OrderID == ordId));
						if (wSspReturnOrderFromBuyOrder_Result3 != null)
						{
							num3 = wSspReturnOrderFromBuyOrder_Result3.ordNumber;
						}
						wSspReturnOrderFromBuyOrder_Result2 = Enumerable.LastOrDefault<WSspReturnOrderFromBuyOrder_Result>((IEnumerable<WSspReturnOrderFromBuyOrder_Result>)orders);
						if (orders.Count > 1)
						{
							foreach (WSspReturnOrderFromBuyOrder_Result item5 in orders)
							{
								text2 = text2 + item5.ordNumber + ",";
								text10 = text10 + item5.OrderID + ",";
							}
							if (!string.IsNullOrWhiteSpace(text2) && text2.EndsWith(","))
							{
								text2 = text2.TrimEnd(new char[1] { ',' });
							}
							if (!string.IsNullOrWhiteSpace(text10) && text10.EndsWith(","))
							{
								text10 = text10.TrimEnd(new char[1] { ',' });
							}
						}
					}
					else
					{
						wSspReturnOrderFromBuyOrder_Result2 = null;
					}
					if (wSspReturnOrderFromBuyOrder_Result2 != null)
					{
						if (string.IsNullOrWhiteSpace(text2))
						{
							text2 = wSspReturnOrderFromBuyOrder_Result2.ordNumber.ToString();
						}
						result = "2|" + ordId + "|" + text2 + "|0";
					}
					else
					{
						result = "2|" + ordId + "|" + num3 + "|1";
					}
				}
			}
			catch (Exception ex)
			{
				ErrorSignal.FromCurrentContext().Raise(ex);
				result = Messages.msgErrorRunFunction + "<br>" + ex.Message;
			}
		}
		return result;
	}

	[AjaxOnly]
	public string LinkBuyOrderToOrder(int bordId, int cmpId, int ordId, string bordItems)
	{
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		string result = "-1";
		if (bordId > 0)
		{
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
				if (result2 <= 0)
				{
					result2 = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				if (!VersionBuyer.BordPlus || !VersionBuyer.Order)
				{
					return "BV|" + Messages.VersionBuy;
				}
				List<IssueOrderFromBuyOrderItemsViewModel> list = new List<IssueOrderFromBuyOrderItemsViewModel>();
				if (!string.IsNullOrWhiteSpace(bordItems))
				{
					list = new JavaScriptSerializer().Deserialize<List<IssueOrderFromBuyOrderItemsViewModel>>(bordItems);
				}
				List<IssueOrderFromBuyOrderItemsViewModel> list2 = new List<IssueOrderFromBuyOrderItemsViewModel>();
				string bordItemList = "";
				if (Enumerable.Any<IssueOrderFromBuyOrderItemsViewModel>((IEnumerable<IssueOrderFromBuyOrderItemsViewModel>)list))
				{
					list2 = Enumerable.ToList<IssueOrderFromBuyOrderItemsViewModel>(Enumerable.Where<IssueOrderFromBuyOrderItemsViewModel>((IEnumerable<IssueOrderFromBuyOrderItemsViewModel>)list, (Func<IssueOrderFromBuyOrderItemsViewModel, bool>)((IssueOrderFromBuyOrderItemsViewModel m) => m.OrdItemId.GetValueOrDefault() != 0)));
				}
				if (list2 != null && Enumerable.Any<IssueOrderFromBuyOrderItemsViewModel>((IEnumerable<IssueOrderFromBuyOrderItemsViewModel>)list2))
				{
					bordItemList = JsonConvert.SerializeObject(Enumerable.ToList<IssueOrderFromBuyOrderItemsViewModel>((IEnumerable<IssueOrderFromBuyOrderItemsViewModel>)list2));
				}
				WSspSelectBuyOrderById_Result wSspSelectBuyOrderById_Result = Enumerable.FirstOrDefault<WSspSelectBuyOrderById_Result>((IEnumerable<WSspSelectBuyOrderById_Result>)_dbII.WSspSelectBuyOrderById(bordId, lCID, result2));
				if (wSspSelectBuyOrderById_Result != null)
				{
					int result3 = 0;
					int.TryParse(wSspSelectBuyOrderById_Result.bordStatusId.ToString(), out result3);
					if (result3 == 4 || result3 == 5)
					{
						return "MOJ|" + "msgErrorLinkBuyOrderToOrderByCanceledBord".OrderMessages();
					}
				}
				result = "msgErrorNotFindOrderForBuyOrder".OrderMessages();
				WSspReturnOrderFromBuyOrder_Result wSspReturnOrderFromBuyOrder_Result = new WSspReturnOrderFromBuyOrder_Result();
				string text = "";
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result4);
				if (result4 <= 0)
				{
					result4 = 1065;
				}
				_ = Thread.CurrentThread.CurrentCulture.LCID;
				List<WSspReturnOrderFromBuyOrder_Result> orders = GetOrders(bordId);
				if (orders != null && Enumerable.Any<WSspReturnOrderFromBuyOrder_Result>((IEnumerable<WSspReturnOrderFromBuyOrder_Result>)orders))
				{
					wSspReturnOrderFromBuyOrder_Result = Enumerable.LastOrDefault<WSspReturnOrderFromBuyOrder_Result>((IEnumerable<WSspReturnOrderFromBuyOrder_Result>)orders);
					if (orders.Count > 1)
					{
						foreach (WSspReturnOrderFromBuyOrder_Result item in orders)
						{
							text = text + item.ordNumber + ",";
						}
						if (!string.IsNullOrWhiteSpace(text) && text.EndsWith(","))
						{
							text = text.TrimEnd(new char[1] { ',' });
						}
					}
				}
				else
				{
					wSspReturnOrderFromBuyOrder_Result = null;
				}
				mct_II_Result mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.WSspCheckBuyOrderHaveOrder(bordId));
				int result5 = 0;
				if (mct_II_Result != null)
				{
					int.TryParse(mct_II_Result.Result.ToString(), out result5);
					if (result5 == 0)
					{
						wSspReturnOrderFromBuyOrder_Result = null;
					}
				}
				if (wSspReturnOrderFromBuyOrder_Result != null && result5 == 1)
				{
					if (string.IsNullOrWhiteSpace(text))
					{
						text = wSspReturnOrderFromBuyOrder_Result.ordNumber.ToString();
					}
					string text2 = (wSspReturnOrderFromBuyOrder_Result.ordDateTime.HasValue ? wSspReturnOrderFromBuyOrder_Result.ordDateTime.Value.ToString("yyyy/MM/dd") : "");
					string text3 = (wSspReturnOrderFromBuyOrder_Result.FirstRegisterDate.HasValue ? wSspReturnOrderFromBuyOrder_Result.FirstRegisterDate.Value.ToString("yyyy/MM/dd") : "");
					string text4 = string.Format("msgErrorOrderIssuedForBuyOrder".OrderMessages(), text, text2, text3, wSspReturnOrderFromBuyOrder_Result.FirstRegisterUserName ?? "");
					result = "1|" + Labels.Error + " !!\r\n" + text4 + "|" + wSspReturnOrderFromBuyOrder_Result.OrderID + "|0";
				}
				else
				{
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					short.Parse(now.ToString("yyyy", new PersianCulture()));
					int userId = UserLogin.CurrentUser.UserId;
					int id = Financial.Get().Id;
					ObjectParameter objectParameter = new ObjectParameter("Result", typeof(int));
					_dbII.WSspLinkBuyOrderToOrder(ordId, bordId, bordItemList, userId, value2, id, value, registerDatePersian, appType, result4, objectParameter);
					int result6 = 0;
					if (objectParameter.Value != null)
					{
						int.TryParse(objectParameter.Value.ToString(), out result6);
					}
					if (result6 <= 0)
					{
						return result6 switch
						{
							-1 => "MOJ|" + "msgErrorAlreadyLinkedBordToOrd".OrderMessages(), 
							-2 => "MOJ|" + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.lblPrdI), 
							-3 => "MOJ|" + string.Format(Messages.msgErrorIsNotFound, "lblOrd".OrderLabels()), 
							-4 => "MOJ|" + "msgErrorLinkBordToOrdNotItemInOrd".OrderMessages(), 
							_ => "MOJ|" + Messages.msgErrorRunFunction, 
						};
					}
					string text5 = "";
					WSspReturnOrderFromBuyOrder_Result wSspReturnOrderFromBuyOrder_Result2 = new WSspReturnOrderFromBuyOrder_Result();
					orders = GetOrders(bordId);
					long num = 0L;
					text = "";
					if (orders != null && Enumerable.Any<WSspReturnOrderFromBuyOrder_Result>((IEnumerable<WSspReturnOrderFromBuyOrder_Result>)orders))
					{
						WSspReturnOrderFromBuyOrder_Result wSspReturnOrderFromBuyOrder_Result3 = Enumerable.FirstOrDefault<WSspReturnOrderFromBuyOrder_Result>((IEnumerable<WSspReturnOrderFromBuyOrder_Result>)orders, (Func<WSspReturnOrderFromBuyOrder_Result, bool>)((WSspReturnOrderFromBuyOrder_Result m) => m.OrderID == ordId));
						if (wSspReturnOrderFromBuyOrder_Result3 != null)
						{
							num = wSspReturnOrderFromBuyOrder_Result3.ordNumber;
						}
						wSspReturnOrderFromBuyOrder_Result2 = Enumerable.LastOrDefault<WSspReturnOrderFromBuyOrder_Result>((IEnumerable<WSspReturnOrderFromBuyOrder_Result>)orders);
						if (orders.Count > 1)
						{
							foreach (WSspReturnOrderFromBuyOrder_Result item2 in orders)
							{
								text = text + item2.ordNumber + ",";
								text5 = text5 + item2.OrderID + ",";
							}
							if (!string.IsNullOrWhiteSpace(text) && text.EndsWith(","))
							{
								text = text.TrimEnd(new char[1] { ',' });
							}
							if (!string.IsNullOrWhiteSpace(text5) && text5.EndsWith(","))
							{
								text5 = text5.TrimEnd(new char[1] { ',' });
							}
						}
					}
					else
					{
						wSspReturnOrderFromBuyOrder_Result2 = null;
					}
					if (wSspReturnOrderFromBuyOrder_Result2 != null)
					{
						if (string.IsNullOrWhiteSpace(text))
						{
							text = wSspReturnOrderFromBuyOrder_Result2.ordNumber.ToString();
						}
						result = "2|" + ordId + "|" + text + "|0";
					}
					else
					{
						result = "2|" + ordId + "|" + num + "|1";
					}
				}
			}
			catch (Exception ex)
			{
				ErrorSignal.FromCurrentContext().Raise(ex);
				result = Messages.msgErrorRunFunction + "<br>" + ex.Message;
			}
		}
		return result;
	}

	[AjaxOnly]
	public string DeleteBuyOrderLinkOrder(int bordId, int bordItemId, int ordId, int ordItemId)
	{
		string result = "-1";
		if (bordId > 0 && bordItemId > 0 && ordId > 0 && ordItemId > 0)
		{
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
				if (result2 <= 0)
				{
					result2 = 1065;
				}
				_ = Thread.CurrentThread.CurrentCulture.LCID;
				if (!VersionBuyer.BordPlus || !VersionBuyer.Order)
				{
					return "BV|" + Messages.VersionBuy;
				}
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short.Parse(now.ToString("yyyy", new PersianCulture()));
				int userId = UserLogin.CurrentUser.UserId;
				int id = Financial.Get().Id;
				ObjectParameter objectParameter = new ObjectParameter("Result", typeof(int));
				_dbIII.WSspDeleteBuyOrderItemLinkOrderItem(bordId, bordItemId, ordId, ordItemId, userId, value2, id, value, registerDatePersian, appType, result2, objectParameter);
				int result3 = 0;
				if (objectParameter.Value != null)
				{
					int.TryParse(objectParameter.Value.ToString(), out result3);
				}
				if (result3 <= 0)
				{
					if (result3 == -1)
					{
						return "ERR|" + "msgErrorInDelLinkedBordItemToOrdItemBySerial".OrderMessages();
					}
					return "ERR|" + Messages.msgErrorRunFunction;
				}
				string text = "";
				WSspReturnOrderFromBuyOrder_Result wSspReturnOrderFromBuyOrder_Result = new WSspReturnOrderFromBuyOrder_Result();
				List<WSspReturnOrderFromBuyOrder_Result> orders = GetOrders(bordId);
				long num = 0L;
				string text2 = "";
				if (orders != null && Enumerable.Any<WSspReturnOrderFromBuyOrder_Result>((IEnumerable<WSspReturnOrderFromBuyOrder_Result>)orders))
				{
					WSspReturnOrderFromBuyOrder_Result wSspReturnOrderFromBuyOrder_Result2 = Enumerable.FirstOrDefault<WSspReturnOrderFromBuyOrder_Result>((IEnumerable<WSspReturnOrderFromBuyOrder_Result>)orders, (Func<WSspReturnOrderFromBuyOrder_Result, bool>)((WSspReturnOrderFromBuyOrder_Result m) => m.OrderID == ordId));
					if (wSspReturnOrderFromBuyOrder_Result2 != null)
					{
						num = wSspReturnOrderFromBuyOrder_Result2.ordNumber;
					}
					wSspReturnOrderFromBuyOrder_Result = Enumerable.LastOrDefault<WSspReturnOrderFromBuyOrder_Result>((IEnumerable<WSspReturnOrderFromBuyOrder_Result>)orders);
					if (orders.Count > 1)
					{
						foreach (WSspReturnOrderFromBuyOrder_Result item in orders)
						{
							text2 = text2 + item.ordNumber + ",";
							text = text + item.OrderID + ",";
						}
						if (!string.IsNullOrWhiteSpace(text2) && text2.EndsWith(","))
						{
							text2 = text2.TrimEnd(new char[1] { ',' });
						}
						if (!string.IsNullOrWhiteSpace(text) && text.EndsWith(","))
						{
							text = text.TrimEnd(new char[1] { ',' });
						}
					}
				}
				else
				{
					wSspReturnOrderFromBuyOrder_Result = null;
				}
				if (wSspReturnOrderFromBuyOrder_Result != null)
				{
					if (string.IsNullOrWhiteSpace(text2))
					{
						text2 = wSspReturnOrderFromBuyOrder_Result.ordNumber.ToString();
					}
					result = "2|" + ordId + "|" + text2 + "|0";
				}
				else
				{
					result = "2|" + ordId + "|" + num + "|1";
				}
			}
			catch (Exception ex)
			{
				ErrorSignal.FromCurrentContext().Raise(ex);
				result = Messages.msgErrorRunFunction + "<br>" + ex.Message;
			}
		}
		return result;
	}

	[AjaxOnly]
	public JsonResult GetBordAndOrdItemsList(int bordId, int ordId)
	{
		LinkBordToOrdItemLiatViewModel linkBordToOrdItemLiatViewModel = new LinkBordToOrdItemLiatViewModel();
		linkBordToOrdItemLiatViewModel.BordItems = new List<WSspSelectBuyOrderItemsWithOrdItemQuantity_Result>();
		linkBordToOrdItemLiatViewModel.OrdItems = new List<WSspSelectOrderItemsWithBordItemQuantity_Result>();
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
			linkBordToOrdItemLiatViewModel.BordItems = Enumerable.ToList<WSspSelectBuyOrderItemsWithOrdItemQuantity_Result>((IEnumerable<WSspSelectBuyOrderItemsWithOrdItemQuantity_Result>)_dbII.WSspSelectBuyOrderItemsWithOrdItemQuantity(bordId, lCID, result, result2));
			if (linkBordToOrdItemLiatViewModel.BordItems == null)
			{
				linkBordToOrdItemLiatViewModel.BordItems = new List<WSspSelectBuyOrderItemsWithOrdItemQuantity_Result>();
			}
			linkBordToOrdItemLiatViewModel.OrdItems = Enumerable.ToList<WSspSelectOrderItemsWithBordItemQuantity_Result>((IEnumerable<WSspSelectOrderItemsWithBordItemQuantity_Result>)_dbII.WSspSelectOrderItemsWithBordItemQuantity(ordId, lCID, result));
			if (linkBordToOrdItemLiatViewModel.OrdItems != null)
			{
				linkBordToOrdItemLiatViewModel.OrdItems = Enumerable.ToList<WSspSelectOrderItemsWithBordItemQuantity_Result>(Enumerable.Where<WSspSelectOrderItemsWithBordItemQuantity_Result>((IEnumerable<WSspSelectOrderItemsWithBordItemQuantity_Result>)linkBordToOrdItemLiatViewModel.OrdItems, (Func<WSspSelectOrderItemsWithBordItemQuantity_Result, bool>)((WSspSelectOrderItemsWithBordItemQuantity_Result m) => m.RemainingQuantity > 0.0)));
			}
			if (linkBordToOrdItemLiatViewModel.OrdItems == null)
			{
				linkBordToOrdItemLiatViewModel.OrdItems = new List<WSspSelectOrderItemsWithBordItemQuantity_Result>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(linkBordToOrdItemLiatViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[HttpPost]
	[LoginAuthorize]
	public string SearchOrderItemToLink(int bordIPrdId, int ordId, string textSerach = "")
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectOrderItemsWithBordItemQuantity_Result> list = Enumerable.ToList<WSspSelectOrderItemsWithBordItemQuantity_Result>((IEnumerable<WSspSelectOrderItemsWithBordItemQuantity_Result>)_dbII.WSspSelectOrderItemsWithBordItemQuantity(ordId, lCID, result2));
			if (list != null)
			{
				list = Enumerable.ToList<WSspSelectOrderItemsWithBordItemQuantity_Result>(Enumerable.Where<WSspSelectOrderItemsWithBordItemQuantity_Result>((IEnumerable<WSspSelectOrderItemsWithBordItemQuantity_Result>)list, (Func<WSspSelectOrderItemsWithBordItemQuantity_Result, bool>)((WSspSelectOrderItemsWithBordItemQuantity_Result m) => m.ordIPrdId == bordIPrdId)));
			}
			if (list != null)
			{
				list = Enumerable.ToList<WSspSelectOrderItemsWithBordItemQuantity_Result>(Enumerable.Where<WSspSelectOrderItemsWithBordItemQuantity_Result>((IEnumerable<WSspSelectOrderItemsWithBordItemQuantity_Result>)list, (Func<WSspSelectOrderItemsWithBordItemQuantity_Result, bool>)((WSspSelectOrderItemsWithBordItemQuantity_Result m) => m.RemainingQuantity > 0.0)));
			}
			if (list == null)
			{
				list = new List<WSspSelectOrderItemsWithBordItemQuantity_Result>();
			}
			if (list != null)
			{
				result = JsonConvert.SerializeObject(list);
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbI.Dispose();
		_dbII.Dispose();
		_dbIII.Dispose();
		base.Dispose(disposing);
	}
}

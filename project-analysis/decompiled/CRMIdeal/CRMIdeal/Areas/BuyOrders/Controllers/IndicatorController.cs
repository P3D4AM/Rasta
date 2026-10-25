using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Calendar;
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

namespace CRMIdeal.Areas.BuyOrders.Controllers;

public class IndicatorController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actbordBuyOrderIndicator")]
	public ActionResult Index(int position = 0, int cmpId = 0, string cmpName = "")
	{
		string text = "";
		string text2 = "";
		if (position == 0)
		{
			text = "frmMain";
			text2 = "actbordBuyOrderIndicator";
			if (!UserLogin.IsUserAccess(text, text2, UserLogin.CurrentUser))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			BuyOrderIndicatorViewModel model = new BuyOrderIndicatorViewModel
			{
				BordIndicatorCompanyId = cmpId.ToString(),
				BordIndicatorCompanyName = cmpName
			};
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			int result = 0;
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result);
			}
			if (result == 1)
			{
				base.ViewBag.LinkAccSettingDBList = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDB(1);
			}
			GetBordStatus();
			GetBorderOpr();
			GetBordUsers();
			GetBordReferUsers();
			GetBordPrintFormat();
			GetPrdFirstGroup();
			GetVerificationWorkFlow();
			GetWarehouse();
			GetCurrencyUnits();
			base.ViewBag.SuppUsersList = SelectActiveUsers_SelectListItem(0);
			base.ViewBag.CmpId = cmpId;
			return View(model);
		}
		return RedirectToAction("Login", "Account", (object)new
		{
			area = "",
			d = DateTime.Now
		});
	}

	[HttpPost]
	[LoginAuthorize]
	public List<CRMspSelectActiveUsers_Result> SelectActiveUsers()
	{
		List<CRMspSelectActiveUsers_Result> result = new List<CRMspSelectActiveUsers_Result>();
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
			List<CRMspSelectActiveUsers_Result> list = Enumerable.ToList<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)_db.CRMspSelectActiveUsers(lCID, result2, result3));
			if (list != null)
			{
				result = list;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public List<SelectListItem> SelectActiveUsers_SelectListItem(int? selectedId = 0)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		list.Add(new SelectListItem
		{
			Text = Labels.SelectedListDefValue,
			Value = "0",
			Selected = false
		});
		List<CRMspSelectActiveUsers_Result> list2 = SelectActiveUsers();
		if (list2 != null && Enumerable.Any<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)list2))
		{
			list.AddRange(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)list2, (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result item) => new SelectListItem
			{
				Text = item.Name,
				Value = item.UserId.ToString(),
				Selected = false
			})));
		}
		return list;
	}

	[AjaxOnly]
	public JsonResult GetBordStatus()
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
			List<WSspSelectBuyOrderStatus_Result> list2 = Enumerable.ToList<WSspSelectBuyOrderStatus_Result>((IEnumerable<WSspSelectBuyOrderStatus_Result>)_db.WSspSelectBuyOrderStatus(lCID, result));
			list.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			list.AddRange(Enumerable.Select<WSspSelectBuyOrderStatus_Result, SelectListItem>((IEnumerable<WSspSelectBuyOrderStatus_Result>)list2, (Func<WSspSelectBuyOrderStatus_Result, SelectListItem>)((WSspSelectBuyOrderStatus_Result item) => new SelectListItem
			{
				Text = item.BuyOrderStatus,
				Value = item.BuyOrderStatusId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.StatusList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetBorderOpr()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectBuyOrderOpr_Result> list2 = BuyOrder.SelectBuyOrderOpr();
			list.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<WSspSelectBuyOrderOpr_Result, SelectListItem>((IEnumerable<WSspSelectBuyOrderOpr_Result>)list2, (Func<WSspSelectBuyOrderOpr_Result, SelectListItem>)((WSspSelectBuyOrderOpr_Result item) => new SelectListItem
				{
					Text = item.Name,
					Value = item.BuyOrderOprID.ToString(),
					Selected = false
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.BordOprList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetBordUsers()
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
			List<WSspSelectBuyOrderRegUsers_Result> list2 = Enumerable.ToList<WSspSelectBuyOrderRegUsers_Result>((IEnumerable<WSspSelectBuyOrderRegUsers_Result>)_db.WSspSelectBuyOrderRegUsers(UserLogin.CurrentUser.UserId, lCID, result, result2));
			list.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			list.AddRange(Enumerable.Select<WSspSelectBuyOrderRegUsers_Result, SelectListItem>((IEnumerable<WSspSelectBuyOrderRegUsers_Result>)list2, (Func<WSspSelectBuyOrderRegUsers_Result, SelectListItem>)((WSspSelectBuyOrderRegUsers_Result item) => new SelectListItem
			{
				Text = item.UserName,
				Value = item.UserId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.FirstRegisterUsersList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetBordReferUsers()
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
			List<WSspSelectBuyOrderReferUsers_Result> list2 = Enumerable.ToList<WSspSelectBuyOrderReferUsers_Result>((IEnumerable<WSspSelectBuyOrderReferUsers_Result>)_db.WSspSelectBuyOrderReferUsers(UserLogin.CurrentUser.UserId, lCID, result, result2));
			list.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			list.AddRange(Enumerable.Select<WSspSelectBuyOrderReferUsers_Result, SelectListItem>((IEnumerable<WSspSelectBuyOrderReferUsers_Result>)list2, (Func<WSspSelectBuyOrderReferUsers_Result, SelectListItem>)((WSspSelectBuyOrderReferUsers_Result item) => new SelectListItem
			{
				Text = item.UserName,
				Value = item.UserId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ReferUsersList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetBordPrintFormat()
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
			List<WSspSelectBuyOrderPrintFormat_Result> list2 = Enumerable.ToList<WSspSelectBuyOrderPrintFormat_Result>((IEnumerable<WSspSelectBuyOrderPrintFormat_Result>)_db.WSspSelectBuyOrderPrintFormat(lCID, result, result2));
			list.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			list.AddRange(Enumerable.Select<WSspSelectBuyOrderPrintFormat_Result, SelectListItem>((IEnumerable<WSspSelectBuyOrderPrintFormat_Result>)list2, (Func<WSspSelectBuyOrderPrintFormat_Result, SelectListItem>)((WSspSelectBuyOrderPrintFormat_Result item) => new SelectListItem
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
		base.ViewBag.PrintFormatList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPrdFirstGroup()
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
			List<WSspSelectBuyOrderprdFirstGroup_Result> list2 = Enumerable.ToList<WSspSelectBuyOrderprdFirstGroup_Result>((IEnumerable<WSspSelectBuyOrderprdFirstGroup_Result>)_db.WSspSelectBuyOrderprdFirstGroup(lCID, result));
			list.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			list.AddRange(Enumerable.Select<WSspSelectBuyOrderprdFirstGroup_Result, SelectListItem>((IEnumerable<WSspSelectBuyOrderprdFirstGroup_Result>)list2, (Func<WSspSelectBuyOrderprdFirstGroup_Result, SelectListItem>)((WSspSelectBuyOrderprdFirstGroup_Result item) => new SelectListItem
			{
				Text = item.FGName,
				Value = item.PrdFirstGroupID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PrdFirstGroupList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPrdSecondGroup(int fgId = 0)
	{
		List<WSspSelectProductSecondGroupActiveInSale_Result> list = new List<WSspSelectProductSecondGroupActiveInSale_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectBuyOrderprdSecondGroup_Result> list2 = Enumerable.ToList<WSspSelectBuyOrderprdSecondGroup_Result>((IEnumerable<WSspSelectBuyOrderprdSecondGroup_Result>)_db.WSspSelectBuyOrderprdSecondGroup(fgId, lCID, result));
			list.Add(new WSspSelectProductSecondGroupActiveInSale_Result
			{
				PrdSecondGroupID = 0,
				SGName = Labels.SelectedListDefValue,
				FGName = ""
			});
			list.AddRange(Enumerable.Select<WSspSelectBuyOrderprdSecondGroup_Result, WSspSelectProductSecondGroupActiveInSale_Result>((IEnumerable<WSspSelectBuyOrderprdSecondGroup_Result>)list2, (Func<WSspSelectBuyOrderprdSecondGroup_Result, WSspSelectProductSecondGroupActiveInSale_Result>)((WSspSelectBuyOrderprdSecondGroup_Result item) => new WSspSelectProductSecondGroupActiveInSale_Result
			{
				PrdSecondGroupID = item.PrdSecondGroupID,
				SGName = item.SGName,
				FGName = item.FGName
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetProducts(string prdGroup = "0|0")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSearchProducts_Result> list = new List<WSspSearchProducts_Result>();
		try
		{
			int value = 0;
			int value2 = 0;
			if (prdGroup != null)
			{
				string[] array = prdGroup.Split(new char[1] { '|' });
				value = ((array[0] != null && array[0] != "") ? int.Parse(array[0]) : 0);
				value2 = ((array[1] != null && array[1] != "") ? int.Parse(array[1]) : 0);
			}
			List<WSspSearchProducts_Result> list2 = Enumerable.ToList<WSspSearchProducts_Result>((IEnumerable<WSspSearchProducts_Result>)_db.WSspSearchProducts(value, value2, "", "", 0, 1, lCID, result, 0, -1, 0, 0, "", null));
			list.Add(new WSspSearchProducts_Result
			{
				PrdId = 0,
				PName = Labels.SelectedListDefValue,
				GName = ""
			});
			list.AddRange(Enumerable.Select<WSspSearchProducts_Result, WSspSearchProducts_Result>((IEnumerable<WSspSearchProducts_Result>)list2, (Func<WSspSearchProducts_Result, WSspSearchProducts_Result>)((WSspSearchProducts_Result item) => new WSspSearchProducts_Result
			{
				PrdId = item.PrdId,
				PName = item.PName,
				GName = item.GName
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public JsonResult SearchProducts(string prdName = "", string prdBarcode = "", int prdFirstGroup = 0, int prdSecondGroup = 0, int prdKind = 0, int prdShowMode = 1, int prdInActive = -1)
	{
		List<WSspSearchProducts_Result> data = new List<WSspSearchProducts_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			data = Enumerable.ToList<WSspSearchProducts_Result>((IEnumerable<WSspSearchProducts_Result>)_db.WSspSearchProducts(prdFirstGroup, prdSecondGroup, prdBarcode, prdName, 0, prdShowMode, lCID, result, prdKind, prdInActive, 0, 0, "", null));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCompany(string value = "")
	{
		List<WSspSelectBuyOrderIndcSearchCompany_Result> data = new List<WSspSelectBuyOrderIndcSearchCompany_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			data = Enumerable.ToList<WSspSelectBuyOrderIndcSearchCompany_Result>((IEnumerable<WSspSelectBuyOrderIndcSearchCompany_Result>)_db.WSspSelectBuyOrderIndcSearchCompany(value, lCID, result));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetVerificationWorkFlow()
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
			List<WSspSelectVerificationWorkFlowWithObjectType_Result> list2 = Enumerable.ToList<WSspSelectVerificationWorkFlowWithObjectType_Result>((IEnumerable<WSspSelectVerificationWorkFlowWithObjectType_Result>)_db.WSspSelectVerificationWorkFlowWithObjectType(40, lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectVerificationWorkFlowWithObjectType_Result, SelectListItem>((IEnumerable<WSspSelectVerificationWorkFlowWithObjectType_Result>)list2, (Func<WSspSelectVerificationWorkFlowWithObjectType_Result, SelectListItem>)((WSspSelectVerificationWorkFlowWithObjectType_Result item) => new SelectListItem
			{
				Text = item.VerificationWorkFlowTitle,
				Value = item.VerificationWorkFlowId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.VerificationWorkFlowList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetVerificationWorkflowStep(int workflowId)
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
			List<WSspSelectVerificationWorkFlowSteps_Result> list2 = Enumerable.ToList<WSspSelectVerificationWorkFlowSteps_Result>((IEnumerable<WSspSelectVerificationWorkFlowSteps_Result>)_db.WSspSelectVerificationWorkFlowSteps(workflowId, lCID, result));
			list.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			list.AddRange(Enumerable.Select<WSspSelectVerificationWorkFlowSteps_Result, SelectListItem>((IEnumerable<WSspSelectVerificationWorkFlowSteps_Result>)list2, (Func<WSspSelectVerificationWorkFlowSteps_Result, SelectListItem>)((WSspSelectVerificationWorkFlowSteps_Result item) => new SelectListItem
			{
				Text = item.VerificationWorkFlowStepTitle,
				Value = item.VerificationWorkFlowStepId.ToString(),
				Selected = false
			})));
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
	public JsonResult GetWarehouse()
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
			_ = UserLogin.CurrentUser.UserId;
			List<WSspSelectActiveWareHouse_Result> list2 = CRMIdeal.Classes.Helper.Warehouse.SelectActiveWareHouse();
			list.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			if (list2 != null && Enumerable.Any<WSspSelectActiveWareHouse_Result>((IEnumerable<WSspSelectActiveWareHouse_Result>)list2))
			{
				list.AddRange(Enumerable.Select<WSspSelectActiveWareHouse_Result, SelectListItem>((IEnumerable<WSspSelectActiveWareHouse_Result>)list2, (Func<WSspSelectActiveWareHouse_Result, SelectListItem>)((WSspSelectActiveWareHouse_Result item) => new SelectListItem
				{
					Text = item.WrhsName,
					Value = item.WareHouseID.ToString(),
					Selected = false
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.WrhsList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCurrencyUnits()
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
			List<WSspSelectCurrencyUnits_Result> list2 = Enumerable.ToList<WSspSelectCurrencyUnits_Result>((IEnumerable<WSspSelectCurrencyUnits_Result>)_db.WSspSelectCurrencyUnits(lCID, result));
			list.Add(new SelectListItem
			{
				Value = "0",
				Text = Labels.SelectedListDefValue
			});
			list.AddRange(Enumerable.Select<WSspSelectCurrencyUnits_Result, SelectListItem>((IEnumerable<WSspSelectCurrencyUnits_Result>)list2, (Func<WSspSelectCurrencyUnits_Result, SelectListItem>)((WSspSelectCurrencyUnits_Result item) => new SelectListItem
			{
				Value = item.CurrencyUnitID.ToString(),
				Text = item.CurrencyUnit
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CurrencyUnitList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmBuyOrderIndicator", ActionName = "actConfirm")]
	[AjaxOnly]
	public JsonResult BuyOrderIndicator(BuyOrderIndicatorViewModel indicator)
	{
		JsonResult jsonResult = Json(BuyOrderIndicatorItem(indicator), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public IndicatorBuyOrderItem BuyOrderIndicatorItem(BuyOrderIndicatorViewModel indicator)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		IndicatorBuyOrderItem indicatorBuyOrderItem = new IndicatorBuyOrderItem();
		List<mct_WSspSelectBuyOrderIndicator_Result> items = new List<mct_WSspSelectBuyOrderIndicator_Result>();
		mct_WSspSelectBuyOrderIndicatorSum_Result itemFooter = new mct_WSspSelectBuyOrderIndicatorSum_Result();
		indicatorBuyOrderItem.Items = items;
		indicatorBuyOrderItem.ItemFooter = itemFooter;
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (indicator != null)
			{
				indicator.BordIndicatorMonth = ((indicator.BordIndicatorMonth != null && indicator.BordIndicatorMonth == "0") ? null : indicator.BordIndicatorMonth);
				string text = "0";
				if (!string.IsNullOrEmpty(indicator.BordIndicatorMonth) && indicator.BordIndicatorMonth != "0")
				{
					text = DateTime.Parse(DateTime.Now.ToString("yyyy") + "/" + indicator.BordIndicatorMonth + "/01").ToString("yyyyMM", new CultureInfo("en-US"));
				}
				indicator.BordIndicatorDate = ((!string.IsNullOrEmpty(indicator.BordIndicatorDate)) ? indicator.BordIndicatorDate.Replace("/", "") : "");
				indicator.BordIndicatorFDate = ((!string.IsNullOrEmpty(indicator.BordIndicatorFDate)) ? indicator.BordIndicatorFDate.Replace("/", "") : "");
				indicator.BordIndicatorTDate = ((!string.IsNullOrEmpty(indicator.BordIndicatorTDate)) ? indicator.BordIndicatorTDate.Replace("/", "") : "");
				indicator.BordIndicatorFOrderDate = ((!string.IsNullOrEmpty(indicator.BordIndicatorFOrderDate)) ? indicator.BordIndicatorFOrderDate.Replace("/", "") : "");
				indicator.BordIndicatorTOrderDate = ((!string.IsNullOrEmpty(indicator.BordIndicatorTOrderDate)) ? indicator.BordIndicatorTOrderDate.Replace("/", "") : "");
				indicator.BordIndicatorMonth = (string.IsNullOrEmpty(indicator.BordIndicatorMonth) ? "0" : ((lCID == 1025) ? text : (DateTime.Now.ToString("yyyy") + indicator.BordIndicatorMonth)));
				indicator.BordIndicatorBordNumber = (string.IsNullOrEmpty(indicator.BordIndicatorBordNumber) ? "0" : indicator.BordIndicatorBordNumber);
				indicator.BordIndicatorBordOrderNumber = (string.IsNullOrEmpty(indicator.BordIndicatorBordOrderNumber) ? "0" : indicator.BordIndicatorBordOrderNumber);
				indicator.BordIndicatorStatusId = (string.IsNullOrEmpty(indicator.BordIndicatorStatusId) ? "0" : indicator.BordIndicatorStatusId);
				indicator.BordIndicatorBordOprId = (string.IsNullOrEmpty(indicator.BordIndicatorBordOprId) ? "0" : indicator.BordIndicatorBordOprId);
				indicator.BordIndicatorFirstRegisterUserId = (string.IsNullOrEmpty(indicator.BordIndicatorFirstRegisterUserId) ? "0" : indicator.BordIndicatorFirstRegisterUserId);
				indicator.BordIndicatorReferUserId = (string.IsNullOrEmpty(indicator.BordIndicatorReferUserId) ? "0" : indicator.BordIndicatorReferUserId);
				indicator.BordIndicatorPrdFirstGroupId = (string.IsNullOrEmpty(indicator.BordIndicatorPrdFirstGroupId) ? "0" : indicator.BordIndicatorPrdFirstGroupId);
				indicator.BordIndicatorPrdSecondGroupId = (string.IsNullOrEmpty(indicator.BordIndicatorPrdSecondGroupId) ? "0" : indicator.BordIndicatorPrdSecondGroupId);
				indicator.BordIndicatorPrdId = (string.IsNullOrEmpty(indicator.BordIndicatorPrdId) ? "0" : indicator.BordIndicatorPrdId);
				if (string.IsNullOrEmpty(indicator.BordIndicatorBordAmount))
				{
					indicator.BordIndicatorBordAmount = "0";
				}
				if (string.IsNullOrEmpty(indicator.BordIndicatorPrintFormatId))
				{
					indicator.BordIndicatorPrintFormatId = "0";
				}
				indicator.BordIndicatorOtherFieldValue = (string.IsNullOrEmpty(indicator.BordIndicatorOtherFieldValue) ? "0" : indicator.BordIndicatorOtherFieldValue);
				indicator.BordIndicatorOtherFieldName = (string.IsNullOrEmpty(indicator.BordIndicatorOtherFieldName) ? "0" : indicator.BordIndicatorOtherFieldName);
				if (indicator.BordIndicatorOtherFieldValueLikelyBoolean)
				{
					indicator.BordIndicatorOtherFieldValueLikely = "1";
				}
				else
				{
					_ = Labels.HaveCompare;
					_ = Labels.HaveNotCompare;
					indicator.BordIndicatorOtherFieldValueLikely = "0";
					switch (indicator.BordIndicatorOtherFieldValue)
					{
					case "#Have":
					case "#دارد":
					case "#يملك":
						indicator.BordIndicatorOtherFieldValue = "-2";
						break;
					case "#HaveNot":
					case "#ندارد":
					case "#لا يملك":
						indicator.BordIndicatorOtherFieldValue = "-1";
						break;
					}
				}
				if (indicator.BordIndicatorOtherFieldName == "bordDiscountPercent" || indicator.BordIndicatorOtherFieldName == "bordTaxIndex")
				{
					indicator.BordIndicatorOtherFieldValue += ".00";
				}
				if (indicator.BordIndicatorOtherFieldName == "0")
				{
					indicator.BordIndicatorOtherFieldValue = "0";
				}
				if (!string.IsNullOrEmpty(indicator.BordIndicatorBordOprIdMulti) && indicator.BordIndicatorBordOprIdMulti != "0")
				{
					indicator.BordIndicatorBordOprId = indicator.BordIndicatorBordOprIdMulti.Trim().Replace("|", ",").Trim();
				}
				if (!string.IsNullOrEmpty(indicator.BordIndicatorStatusIdMulti) && indicator.BordIndicatorStatusIdMulti != "0")
				{
					indicator.BordIndicatorStatusId = indicator.BordIndicatorStatusIdMulti.Trim().Replace("|", ",").Trim();
				}
				if (!string.IsNullOrEmpty(indicator.BordIndicatorPrdIdMulti) && indicator.BordIndicatorPrdIdMulti != "0")
				{
					indicator.BordIndicatorPrdId = indicator.BordIndicatorPrdIdMulti.Trim().Replace("|", ",").Trim();
				}
				indicator.BordIndicatorOrderVerifiedStatusId = "0";
				indicator.BordIndicatorSettlementTypeId = "0";
				indicator.BordIndicatorHaveLinkAcc = (string.IsNullOrEmpty(indicator.BordIndicatorHaveLinkAcc) ? "0" : indicator.BordIndicatorHaveLinkAcc);
				indicator.BordIndicatorVerified = (string.IsNullOrEmpty(indicator.BordIndicatorVerified) ? "0" : indicator.BordIndicatorVerified);
				indicator.BordIndicatorVerificationWorkflowId = (string.IsNullOrEmpty(indicator.BordIndicatorVerificationWorkflowId) ? "0" : indicator.BordIndicatorVerificationWorkflowId);
				indicator.BordIndicatorVerificationWorkflowStepId = (string.IsNullOrEmpty(indicator.BordIndicatorVerificationWorkflowStepId) ? "0" : indicator.BordIndicatorVerificationWorkflowStepId);
				indicator.LinkAccSettingDBId = indicator.LinkAccSettingDBId.GetValueOrDefault();
				if (!string.IsNullOrWhiteSpace(indicator.BordIndicatorFirstRegisterUserIdMulti) && indicator.BordIndicatorFirstRegisterUserIdMulti != "0")
				{
					indicator.BordIndicatorFirstRegisterUserId = indicator.BordIndicatorFirstRegisterUserIdMulti.Trim().Replace("|", ",").Trim();
				}
				if (!string.IsNullOrWhiteSpace(indicator.BordIndicatorReferUserIdMulti) && indicator.BordIndicatorReferUserIdMulti != "0")
				{
					indicator.BordIndicatorReferUserId = indicator.BordIndicatorReferUserIdMulti.Trim().Replace("|", ",").Trim();
				}
				if (!string.IsNullOrWhiteSpace(indicator.BordIndicatorSuppUserIdMulti) && indicator.BordIndicatorSuppUserIdMulti != "0")
				{
					indicator.BordIndicatorSuppUserId = indicator.BordIndicatorSuppUserIdMulti.Trim().Replace("|", ",").Trim();
				}
				indicator.BordIndicatorWrhsId = (string.IsNullOrWhiteSpace(indicator.BordIndicatorWrhsId) ? "0" : indicator.BordIndicatorWrhsId);
				if (!string.IsNullOrWhiteSpace(indicator.BordIndicatorWrhsIds) && indicator.BordIndicatorWrhsIds != "0")
				{
					indicator.BordIndicatorWrhsId = indicator.BordIndicatorWrhsIds.Trim().Replace("|", ",").Trim();
				}
				DateTime value = DateTime.Now;
				DateTime value2 = DateTime.Now;
				DateTime value3 = DateTime.Now;
				DateTime value4 = DateTime.Now;
				DateTime value5 = DateTime.Now;
				if (!string.IsNullOrEmpty(indicator.BordIndicatorDate))
				{
					value = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.BordIndicatorDate.Replace("/", "")), lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.BordIndicatorFDate))
				{
					value2 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.BordIndicatorFDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.BordIndicatorTDate))
				{
					value3 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.BordIndicatorTDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.BordIndicatorFOrderDate))
				{
					value4 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.BordIndicatorFOrderDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.BordIndicatorTOrderDate))
				{
					value5 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.BordIndicatorTOrderDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				indicator.BordIndicatorFPayDocDateTemp = ((!string.IsNullOrEmpty(indicator.BordIndicatorFPayDocDateTemp)) ? indicator.BordIndicatorFPayDocDateTemp.Replace("/", "") : "");
				indicator.BordIndicatorTPayDocDateTemp = ((!string.IsNullOrEmpty(indicator.BordIndicatorTPayDocDateTemp)) ? indicator.BordIndicatorTPayDocDateTemp.Replace("/", "") : "");
				DateTime value6 = DateTime.Now;
				DateTime value7 = DateTime.Now;
				if (!string.IsNullOrEmpty(indicator.BordIndicatorFPayDocDateTemp))
				{
					value6 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.BordIndicatorFPayDocDateTemp.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.BordIndicatorTPayDocDateTemp))
				{
					value7 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.BordIndicatorTPayDocDateTemp.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				DayOfWeek dayOfWeek = DateTime.Now.DayOfWeek;
				items = Enumerable.ToList<mct_WSspSelectBuyOrderIndicator_Result>((IEnumerable<mct_WSspSelectBuyOrderIndicator_Result>)_db.mfi_WSspSelectBuyOrderIndicator(indicator.BordIndicatorDate, indicator.BordIndicatorFDate, indicator.BordIndicatorTDate, indicator.BordIndicatorFOrderDate, indicator.BordIndicatorTOrderDate, indicator.BordIndicatorMonth, indicator.BordIndicatorCompanyId, indicator.BordIndicatorBordNumber, indicator.BordIndicatorBordOrderNumber, indicator.BordIndicatorStatusId, indicator.BordIndicatorBordOprId, indicator.BordIndicatorFirstRegisterUserId, indicator.BordIndicatorReferUserId, indicator.BordIndicatorPrdFirstGroupId, indicator.BordIndicatorPrdSecondGroupId, indicator.BordIndicatorPrdId, indicator.BordIndicatorBordAmount, indicator.BordIndicatorOrderVerifiedStatusId, indicator.BordIndicatorPrintFormatId, indicator.BordIndicatorSettlementTypeId, indicator.BordIndicatorOtherFieldName, indicator.BordIndicatorOtherFieldValueLikely, indicator.BordIndicatorOtherFieldValue, UserLogin.CurrentUser.UserId, DateTime.Now.ToString("yyyy/MM/dd"), DateTimeClass.DefineDayeOfWeekPersian(dayOfWeek.ToString()), 1, lCID, result, value, value2, value3, value4, value5, indicator.BordIndicatorHaveLinkAcc, indicator.BordIndicatorVerified, indicator.BordIndicatorVerificationWorkflowId, indicator.BordIndicatorVerificationWorkflowStepId, indicator.LinkAccSettingDBId, (!string.IsNullOrEmpty(indicator.BordIndicatorFPayDocDateTemp)) ? new DateTime?(value6) : null, (!string.IsNullOrEmpty(indicator.BordIndicatorTPayDocDateTemp)) ? new DateTime?(value7) : null, indicator.BordIndicatorWrhsId, indicator.BordIndicatorSuppUserId, result2, indicator.BordIndicatorPrdSpecsJson, indicator.BordCurrencyUnitId, bordFacilityCmpId: indicator.BordFacilityCmpId, bordReqCmpId: indicator.BordReqCmpId));
				if (Enumerable.Any<mct_WSspSelectBuyOrderIndicator_Result>((IEnumerable<mct_WSspSelectBuyOrderIndicator_Result>)items))
				{
					itemFooter = Enumerable.FirstOrDefault<mct_WSspSelectBuyOrderIndicatorSum_Result>((IEnumerable<mct_WSspSelectBuyOrderIndicatorSum_Result>)Enumerable.ToList<mct_WSspSelectBuyOrderIndicatorSum_Result>((IEnumerable<mct_WSspSelectBuyOrderIndicatorSum_Result>)_db.mfi_WSspSelectBuyOrderIndicatorSum(indicator.BordIndicatorDate, indicator.BordIndicatorFDate, indicator.BordIndicatorTDate, indicator.BordIndicatorFOrderDate, indicator.BordIndicatorTOrderDate, indicator.BordIndicatorMonth, indicator.BordIndicatorCompanyId, indicator.BordIndicatorBordNumber, indicator.BordIndicatorBordOrderNumber, indicator.BordIndicatorStatusId, indicator.BordIndicatorBordOprId, indicator.BordIndicatorFirstRegisterUserId, indicator.BordIndicatorReferUserId, indicator.BordIndicatorPrdFirstGroupId, indicator.BordIndicatorPrdSecondGroupId, indicator.BordIndicatorPrdId, indicator.BordIndicatorBordAmount, indicator.BordIndicatorOrderVerifiedStatusId, indicator.BordIndicatorPrintFormatId, indicator.BordIndicatorSettlementTypeId, indicator.BordIndicatorOtherFieldName, indicator.BordIndicatorOtherFieldValueLikely, indicator.BordIndicatorOtherFieldValue, UserLogin.CurrentUser.UserId, DateTime.Now.ToString("yyyy/MM/dd"), DateTimeClass.DefineDayeOfWeekPersian(dayOfWeek.ToString()), lCID, result, value, value2, value3, value4, value5, indicator.BordIndicatorHaveLinkAcc, indicator.BordIndicatorVerified, indicator.BordIndicatorVerificationWorkflowId, indicator.BordIndicatorVerificationWorkflowStepId, indicator.LinkAccSettingDBId, (!string.IsNullOrEmpty(indicator.BordIndicatorFPayDocDateTemp)) ? new DateTime?(value6) : null, (!string.IsNullOrEmpty(indicator.BordIndicatorTPayDocDateTemp)) ? new DateTime?(value7) : null, indicator.BordIndicatorWrhsId, result2, indicator.BordIndicatorPrdSpecsJson, indicator.BordCurrencyUnitId, bordFacilityCmpId: indicator.BordFacilityCmpId, bordReqCmpId: indicator.BordReqCmpId)));
				}
				foreach (mct_WSspSelectBuyOrderIndicator_Result item in items)
				{
					if (lCID != 1065)
					{
						if (!string.IsNullOrEmpty(item.bordDate))
						{
							item.bordDate = PersianDate.GetShamsi2Miladi(item.bordDate.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrEmpty(item.bordOrderDate))
						{
							item.bordOrderDate = PersianDate.GetShamsi2Miladi(item.bordOrderDate.Replace("/", "")).Replace("/", "");
						}
					}
				}
				indicatorBuyOrderItem.Items = items;
				indicatorBuyOrderItem.ItemFooter = itemFooter;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return indicatorBuyOrderItem;
	}

	public ActionResult BuyOrderIndicator_Read([DataSourceRequest] DataSourceRequest request, string indicator)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		BuyOrderIndicatorViewModel indicator2 = new JavaScriptSerializer().Deserialize<BuyOrderIndicatorViewModel>(indicator);
		IndicatorBuyOrderItem indicatorBuyOrderItem = BuyOrderIndicatorItem(indicator2);
		JsonResult jsonResult = Json(((IEnumerable)indicatorBuyOrderItem.Items).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult IndicatorUpdateFooter(BuyOrderIndicatorViewModel indicator)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		mct_WSspSelectBuyOrderIndicatorSum_Result data = new mct_WSspSelectBuyOrderIndicatorSum_Result();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (indicator != null)
			{
				indicator.BordIndicatorMonth = ((indicator.BordIndicatorMonth != null && indicator.BordIndicatorMonth == "0") ? null : indicator.BordIndicatorMonth);
				string text = "0";
				if (!string.IsNullOrEmpty(indicator.BordIndicatorMonth) && indicator.BordIndicatorMonth != "0")
				{
					text = DateTime.Parse(DateTime.Now.ToString("yyyy") + "/" + indicator.BordIndicatorMonth + "/01").ToString("yyyyMM", new CultureInfo("en-US"));
				}
				indicator.BordIndicatorDate = ((!string.IsNullOrEmpty(indicator.BordIndicatorDate)) ? indicator.BordIndicatorDate.Replace("/", "") : "");
				indicator.BordIndicatorFDate = ((!string.IsNullOrEmpty(indicator.BordIndicatorFDate)) ? indicator.BordIndicatorFDate.Replace("/", "") : "");
				indicator.BordIndicatorTDate = ((!string.IsNullOrEmpty(indicator.BordIndicatorTDate)) ? indicator.BordIndicatorTDate.Replace("/", "") : "");
				indicator.BordIndicatorFOrderDate = ((!string.IsNullOrEmpty(indicator.BordIndicatorFOrderDate)) ? indicator.BordIndicatorFOrderDate.Replace("/", "") : "");
				indicator.BordIndicatorTOrderDate = ((!string.IsNullOrEmpty(indicator.BordIndicatorTOrderDate)) ? indicator.BordIndicatorTOrderDate.Replace("/", "") : "");
				indicator.BordIndicatorMonth = (string.IsNullOrEmpty(indicator.BordIndicatorMonth) ? "0" : ((lCID == 1025) ? text : (DateTime.Now.ToString("yyyy") + indicator.BordIndicatorMonth)));
				indicator.BordIndicatorBordNumber = (string.IsNullOrEmpty(indicator.BordIndicatorBordNumber) ? "0" : indicator.BordIndicatorBordNumber);
				indicator.BordIndicatorBordOrderNumber = (string.IsNullOrEmpty(indicator.BordIndicatorBordOrderNumber) ? "0" : indicator.BordIndicatorBordOrderNumber);
				indicator.BordIndicatorStatusId = (string.IsNullOrEmpty(indicator.BordIndicatorStatusId) ? "0" : indicator.BordIndicatorStatusId);
				indicator.BordIndicatorBordOprId = (string.IsNullOrEmpty(indicator.BordIndicatorBordOprId) ? "0" : indicator.BordIndicatorBordOprId);
				indicator.BordIndicatorFirstRegisterUserId = (string.IsNullOrEmpty(indicator.BordIndicatorFirstRegisterUserId) ? "0" : indicator.BordIndicatorFirstRegisterUserId);
				indicator.BordIndicatorReferUserId = (string.IsNullOrEmpty(indicator.BordIndicatorReferUserId) ? "0" : indicator.BordIndicatorReferUserId);
				indicator.BordIndicatorPrdFirstGroupId = (string.IsNullOrEmpty(indicator.BordIndicatorPrdFirstGroupId) ? "0" : indicator.BordIndicatorPrdFirstGroupId);
				indicator.BordIndicatorPrdSecondGroupId = (string.IsNullOrEmpty(indicator.BordIndicatorPrdSecondGroupId) ? "0" : indicator.BordIndicatorPrdSecondGroupId);
				indicator.BordIndicatorPrdId = (string.IsNullOrEmpty(indicator.BordIndicatorPrdId) ? "0" : indicator.BordIndicatorPrdId);
				if (string.IsNullOrEmpty(indicator.BordIndicatorBordAmount))
				{
					indicator.BordIndicatorBordAmount = "0";
				}
				if (string.IsNullOrEmpty(indicator.BordIndicatorPrintFormatId))
				{
					indicator.BordIndicatorPrintFormatId = "0";
				}
				indicator.BordIndicatorOtherFieldValue = (string.IsNullOrEmpty(indicator.BordIndicatorOtherFieldValue) ? "0" : indicator.BordIndicatorOtherFieldValue);
				indicator.BordIndicatorOtherFieldName = (string.IsNullOrEmpty(indicator.BordIndicatorOtherFieldName) ? "0" : indicator.BordIndicatorOtherFieldName);
				if (indicator.BordIndicatorOtherFieldValueLikelyBoolean)
				{
					indicator.BordIndicatorOtherFieldValueLikely = "1";
				}
				else
				{
					indicator.BordIndicatorOtherFieldValueLikely = "0";
					switch (indicator.BordIndicatorOtherFieldValue)
					{
					case "#Have":
					case "#دارد":
					case "#يملك":
						indicator.BordIndicatorOtherFieldValue = "-2";
						break;
					case "#HaveNot":
					case "#ندارد":
					case "#لا يملك":
						indicator.BordIndicatorOtherFieldValue = "-1";
						break;
					}
				}
				if (indicator.BordIndicatorOtherFieldName == "bordDiscountPercent" || indicator.BordIndicatorOtherFieldName == "bordTaxIndex")
				{
					indicator.BordIndicatorOtherFieldValue += ".00";
				}
				if (indicator.BordIndicatorOtherFieldName == "0")
				{
					indicator.BordIndicatorOtherFieldValue = "0";
				}
				if (!string.IsNullOrEmpty(indicator.BordIndicatorBordOprIdMulti) && indicator.BordIndicatorBordOprIdMulti != "0")
				{
					indicator.BordIndicatorBordOprId = indicator.BordIndicatorBordOprIdMulti.Trim().Replace("|", ",").Trim();
				}
				if (!string.IsNullOrEmpty(indicator.BordIndicatorStatusIdMulti) && indicator.BordIndicatorStatusIdMulti != "0")
				{
					indicator.BordIndicatorStatusId = indicator.BordIndicatorStatusIdMulti.Trim().Replace("|", ",").Trim();
				}
				if (!string.IsNullOrEmpty(indicator.BordIndicatorPrdIdMulti) && indicator.BordIndicatorPrdIdMulti != "0")
				{
					indicator.BordIndicatorPrdId = indicator.BordIndicatorPrdIdMulti.Trim().Replace("|", ",").Trim();
				}
				indicator.BordIndicatorHaveLinkAcc = (string.IsNullOrEmpty(indicator.BordIndicatorHaveLinkAcc) ? "0" : indicator.BordIndicatorHaveLinkAcc);
				indicator.BordIndicatorVerified = (string.IsNullOrEmpty(indicator.BordIndicatorVerified) ? "0" : indicator.BordIndicatorVerified);
				indicator.BordIndicatorVerificationWorkflowId = (string.IsNullOrEmpty(indicator.BordIndicatorVerificationWorkflowId) ? "0" : indicator.BordIndicatorVerificationWorkflowId);
				indicator.BordIndicatorVerificationWorkflowStepId = (string.IsNullOrEmpty(indicator.BordIndicatorVerificationWorkflowStepId) ? "0" : indicator.BordIndicatorVerificationWorkflowStepId);
				indicator.LinkAccSettingDBId = indicator.LinkAccSettingDBId.GetValueOrDefault();
				if (!string.IsNullOrWhiteSpace(indicator.BordIndicatorFirstRegisterUserIdMulti) && indicator.BordIndicatorFirstRegisterUserIdMulti != "0")
				{
					indicator.BordIndicatorFirstRegisterUserId = indicator.BordIndicatorFirstRegisterUserIdMulti.Trim().Replace("|", ",").Trim();
				}
				if (!string.IsNullOrWhiteSpace(indicator.BordIndicatorReferUserIdMulti) && indicator.BordIndicatorReferUserIdMulti != "0")
				{
					indicator.BordIndicatorReferUserId = indicator.BordIndicatorReferUserIdMulti.Trim().Replace("|", ",").Trim();
				}
				if (!string.IsNullOrWhiteSpace(indicator.BordIndicatorSuppUserIdMulti) && indicator.BordIndicatorSuppUserIdMulti != "0")
				{
					indicator.BordIndicatorSuppUserId = indicator.BordIndicatorSuppUserIdMulti.Trim().Replace("|", ",").Trim();
				}
				indicator.BordIndicatorWrhsId = (string.IsNullOrWhiteSpace(indicator.BordIndicatorWrhsId) ? "0" : indicator.BordIndicatorWrhsId);
				if (!string.IsNullOrWhiteSpace(indicator.BordIndicatorWrhsIds) && indicator.BordIndicatorWrhsIds != "0")
				{
					indicator.BordIndicatorWrhsId = indicator.BordIndicatorWrhsIds.Trim().Replace("|", ",").Trim();
				}
				DateTime value = DateTime.Now;
				DateTime value2 = DateTime.Now;
				DateTime value3 = DateTime.Now;
				DateTime value4 = DateTime.Now;
				DateTime value5 = DateTime.Now;
				if (!string.IsNullOrEmpty(indicator.BordIndicatorDate))
				{
					value = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.BordIndicatorDate.Replace("/", "")), lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.BordIndicatorFDate))
				{
					value2 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.BordIndicatorFDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.BordIndicatorTDate))
				{
					value3 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.BordIndicatorTDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.BordIndicatorFOrderDate))
				{
					value4 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.BordIndicatorFOrderDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.BordIndicatorTOrderDate))
				{
					value5 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.BordIndicatorTOrderDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				indicator.BordIndicatorFPayDocDateTemp = ((!string.IsNullOrEmpty(indicator.BordIndicatorFPayDocDateTemp)) ? indicator.BordIndicatorFPayDocDateTemp.Replace("/", "") : "");
				indicator.BordIndicatorTPayDocDateTemp = ((!string.IsNullOrEmpty(indicator.BordIndicatorTPayDocDateTemp)) ? indicator.BordIndicatorTPayDocDateTemp.Replace("/", "") : "");
				DateTime value6 = DateTime.Now;
				DateTime value7 = DateTime.Now;
				if (!string.IsNullOrEmpty(indicator.BordIndicatorFPayDocDateTemp))
				{
					value6 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.BordIndicatorFPayDocDateTemp.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.BordIndicatorTPayDocDateTemp))
				{
					value7 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.BordIndicatorTPayDocDateTemp.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				DayOfWeek dayOfWeek = DateTime.Now.DayOfWeek;
				data = Enumerable.FirstOrDefault<mct_WSspSelectBuyOrderIndicatorSum_Result>((IEnumerable<mct_WSspSelectBuyOrderIndicatorSum_Result>)_db.mfi_WSspSelectBuyOrderIndicatorSum(indicator.BordIndicatorDate, indicator.BordIndicatorFDate, indicator.BordIndicatorTDate, indicator.BordIndicatorFOrderDate, indicator.BordIndicatorTOrderDate, indicator.BordIndicatorMonth, indicator.BordIndicatorCompanyId, indicator.BordIndicatorBordNumber, indicator.BordIndicatorBordOrderNumber, indicator.BordIndicatorStatusId, indicator.BordIndicatorBordOprId, indicator.BordIndicatorFirstRegisterUserId, indicator.BordIndicatorReferUserId, indicator.BordIndicatorPrdFirstGroupId, indicator.BordIndicatorPrdSecondGroupId, indicator.BordIndicatorPrdId, indicator.BordIndicatorBordAmount, indicator.BordIndicatorOrderVerifiedStatusId, indicator.BordIndicatorPrintFormatId, indicator.BordIndicatorSettlementTypeId, indicator.BordIndicatorOtherFieldName, indicator.BordIndicatorOtherFieldValueLikely, indicator.BordIndicatorOtherFieldValue, UserLogin.CurrentUser.UserId, DateTime.Now.ToString("yyyy/MM/dd"), DateTimeClass.DefineDayeOfWeekPersian(dayOfWeek.ToString()), lCID, result, value, value2, value3, value4, value5, indicator.BordIndicatorHaveLinkAcc, indicator.BordIndicatorVerified, indicator.BordIndicatorVerificationWorkflowId, indicator.BordIndicatorVerificationWorkflowStepId, indicator.LinkAccSettingDBId, (!string.IsNullOrEmpty(indicator.BordIndicatorFPayDocDateTemp)) ? new DateTime?(value6) : null, (!string.IsNullOrEmpty(indicator.BordIndicatorTPayDocDateTemp)) ? new DateTime?(value7) : null, indicator.BordIndicatorWrhsId, result2, indicator.BordIndicatorPrdSpecsJson, indicator.BordCurrencyUnitId, bordFacilityCmpId: indicator.BordFacilityCmpId, bordReqCmpId: indicator.BordReqCmpId));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmBuyOrder", ActionName = "actIssueOrder")]
	public ActionResult IssueOrder(int bordId, string parameters = "")
	{
		return View();
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbI.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}
}

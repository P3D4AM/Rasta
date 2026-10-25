using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Orders.Controllers;

public class IndicatorController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actordOrderIndicator")]
	public ActionResult Index(int position = 0, int cmpId = 0, string cmpName = "")
	{
		string text = "";
		string text2 = "";
		if (position == 0)
		{
			text = "frmMain";
			text2 = "actordOrderIndicator";
			if (!UserLogin.IsUserAccess(text, text2, UserLogin.CurrentUser))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			OrderIndicatorViewModel model = new OrderIndicatorViewModel
			{
				OrdIndicatorCompanyId = cmpId.ToString(),
				OrdIndicatorCompanyName = cmpName
			};
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			int result = 0;
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result);
			}
			if (result == 1 || result == 4)
			{
				base.ViewBag.LinkAccSettingDBList = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDB(result);
			}
			GetOrdStatus();
			GetOrderOpr();
			GetOrdUsers();
			GetOrdSettlementType();
			GetOrdPrintFormat();
			GetPrdFirstGroup();
			GetOrdDeliveryTerms();
			GetSellerUsers();
			GetVerificationWorkFlow();
			GetPrdColor();
			GetWarehouse();
			GetCurrencyUnits();
			base.ViewBag.CmpId = cmpId;
			return View(model);
		}
		return RedirectToAction("Login", "Account", (object)new
		{
			area = "",
			d = DateTime.Now
		});
	}

	[AjaxOnly]
	public JsonResult GetOrdStatus()
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
			List<WSspSelectOrderStatus_Result> list2 = Enumerable.ToList<WSspSelectOrderStatus_Result>((IEnumerable<WSspSelectOrderStatus_Result>)_db.WSspSelectOrderStatus(lCID, result));
			list.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			list.AddRange(Enumerable.Select<WSspSelectOrderStatus_Result, SelectListItem>((IEnumerable<WSspSelectOrderStatus_Result>)list2, (Func<WSspSelectOrderStatus_Result, SelectListItem>)((WSspSelectOrderStatus_Result item) => new SelectListItem
			{
				Text = item.OrderStatus,
				Value = item.OrderStatusId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.OrdStatusList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
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
			list.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
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
		base.ViewBag.OrderOprList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetOrdUsers()
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
			List<WSspSelectOrderReferUsers_Result> list2 = Enumerable.ToList<WSspSelectOrderReferUsers_Result>((IEnumerable<WSspSelectOrderReferUsers_Result>)_db.WSspSelectOrderReferUsers(UserLogin.CurrentUser.UserId, lCID, result, result2));
			list.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			list.AddRange(Enumerable.Select<WSspSelectOrderReferUsers_Result, SelectListItem>((IEnumerable<WSspSelectOrderReferUsers_Result>)list2, (Func<WSspSelectOrderReferUsers_Result, SelectListItem>)((WSspSelectOrderReferUsers_Result item) => new SelectListItem
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
		base.ViewBag.ReferUsersList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetSellerUsers()
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
			List<CRMspSelectActiveUsers_Result> list2 = Enumerable.ToList<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)_db.CRMspSelectActiveUsers(lCID, result, result2));
			list.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			list.AddRange(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)list2, (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result item) => new SelectListItem
			{
				Text = item.Name,
				Value = item.UserId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.SellerList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
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
			List<WSspSelectVerificationWorkFlowWithObjectType_Result> list2 = Enumerable.ToList<WSspSelectVerificationWorkFlowWithObjectType_Result>((IEnumerable<WSspSelectVerificationWorkFlowWithObjectType_Result>)_db.WSspSelectVerificationWorkFlowWithObjectType(20, lCID, result));
			list.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
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
	public JsonResult GetOrdPrintFormat()
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
			List<CRMspSelectPrintFormatByTypeId_Result> printFortants = CRMIdeal.Classes.Helper.PrintFormat.GetPrintFortants(result2, 2);
			list.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			list.AddRange(Enumerable.Select<CRMspSelectPrintFormatByTypeId_Result, SelectListItem>((IEnumerable<CRMspSelectPrintFormatByTypeId_Result>)printFortants, (Func<CRMspSelectPrintFormatByTypeId_Result, SelectListItem>)((CRMspSelectPrintFormatByTypeId_Result item) => new SelectListItem
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
	public JsonResult GetOrdSettlementType()
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
			list.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
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
		base.ViewBag.SettlementTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetOrdDeliveryTerms()
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
			List<WSspSelectDeliveryTerms_Result> list2 = Enumerable.ToList<WSspSelectDeliveryTerms_Result>((IEnumerable<WSspSelectDeliveryTerms_Result>)_db.WSspSelectDeliveryTerms(lCID, result));
			list.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			list.AddRange(Enumerable.Select<WSspSelectDeliveryTerms_Result, SelectListItem>((IEnumerable<WSspSelectDeliveryTerms_Result>)list2, (Func<WSspSelectDeliveryTerms_Result, SelectListItem>)((WSspSelectDeliveryTerms_Result item) => new SelectListItem
			{
				Text = item.DeliveryTerm,
				Value = item.DeliveryTermId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.DeliveryTermList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPrdGroupsTree()
	{
		return JsonConvert.SerializeObject(Product.GetPrdGroupsTree());
	}

	[AjaxOnly]
	public JsonResult GetPrdFirstGroup()
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
			List<WSspSelectProductFirstGroupActiveInSale_Result> list2 = Enumerable.ToList<WSspSelectProductFirstGroupActiveInSale_Result>((IEnumerable<WSspSelectProductFirstGroupActiveInSale_Result>)_db.WSspSelectProductFirstGroupActiveInSale(lCID, result));
			list.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			list.AddRange(Enumerable.Select<WSspSelectProductFirstGroupActiveInSale_Result, SelectListItem>((IEnumerable<WSspSelectProductFirstGroupActiveInSale_Result>)list2, (Func<WSspSelectProductFirstGroupActiveInSale_Result, SelectListItem>)((WSspSelectProductFirstGroupActiveInSale_Result item) => new SelectListItem
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
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectProductSecondGroupActiveInSale_Result> list = new List<WSspSelectProductSecondGroupActiveInSale_Result>();
		try
		{
			List<WSspSelectProductSecondGroupActiveInSale_Result> list2 = Enumerable.ToList<WSspSelectProductSecondGroupActiveInSale_Result>((IEnumerable<WSspSelectProductSecondGroupActiveInSale_Result>)_db.WSspSelectProductSecondGroupActiveInSale(fgId, lCID, result));
			list.Add(new WSspSelectProductSecondGroupActiveInSale_Result
			{
				PrdSecondGroupID = 0,
				SGName = Labels.SelectedListDefValue,
				FGName = ""
			});
			list.AddRange(Enumerable.Select<WSspSelectProductSecondGroupActiveInSale_Result, WSspSelectProductSecondGroupActiveInSale_Result>((IEnumerable<WSspSelectProductSecondGroupActiveInSale_Result>)list2, (Func<WSspSelectProductSecondGroupActiveInSale_Result, WSspSelectProductSecondGroupActiveInSale_Result>)((WSspSelectProductSecondGroupActiveInSale_Result item) => new WSspSelectProductSecondGroupActiveInSale_Result
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
			List<WSspSearchProducts_Result> list2 = Enumerable.ToList<WSspSearchProducts_Result>((IEnumerable<WSspSearchProducts_Result>)_db.WSspSearchProducts(value, value2, "", "", 0, 2, lCID, result, 0, -1, 0, 0, "", null));
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

	public JsonResult SearchProducts(string prdName = "", string prdBarcode = "", int prdFirstGroup = 0, int prdSecondGroup = 0, int prdKind = 0, int prdShowMode = 2, int prdInActive = -1)
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
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetCompany(string value = "")
	{
		List<WSspOrderIndicatorSearchCompany_Result> data = new List<WSspOrderIndicatorSearchCompany_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			data = Enumerable.ToList<WSspOrderIndicatorSearchCompany_Result>((IEnumerable<WSspOrderIndicatorSearchCompany_Result>)_db.WSspOrderIndicatorSearchCompany(value, lCID, result));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPrdColor()
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
			List<WSspSelectProductColor_Result> list2 = Enumerable.ToList<WSspSelectProductColor_Result>((IEnumerable<WSspSelectProductColor_Result>)_db.WSspSelectProductColor(lCID, result));
			list.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			list.AddRange(Enumerable.Select<WSspSelectProductColor_Result, SelectListItem>((IEnumerable<WSspSelectProductColor_Result>)list2, (Func<WSspSelectProductColor_Result, SelectListItem>)((WSspSelectProductColor_Result item) => new SelectListItem
			{
				Text = item.Color,
				Value = item.ProductColorID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PrdColorList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
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

	public JsonResult OrderIndicator(OrderIndicatorViewModel indicator)
	{
		JsonResult jsonResult = Json(OrderIndicatorItem(indicator), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public IndicatorOrderItem OrderIndicatorItem(OrderIndicatorViewModel indicator)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		IndicatorOrderItem indicatorOrderItem = new IndicatorOrderItem();
		List<mct_WSspSelectOrderIndicator_Result> items = new List<mct_WSspSelectOrderIndicator_Result>();
		mct_WSspSelectOrderIndicatorSum_Result itemFooter = new mct_WSspSelectOrderIndicatorSum_Result();
		indicatorOrderItem.Items = items;
		indicatorOrderItem.ItemFooter = itemFooter;
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (indicator != null)
			{
				indicator.OrdIndicatorMonth = ((indicator.OrdIndicatorMonth != null && indicator.OrdIndicatorMonth == "0") ? null : indicator.OrdIndicatorMonth);
				string text = "0";
				if (!string.IsNullOrEmpty(indicator.OrdIndicatorMonth) && indicator.OrdIndicatorMonth != "0")
				{
					text = DateTime.Parse(DateTime.Now.ToString("yyyy") + "/" + indicator.OrdIndicatorMonth + "/01").ToString("yyyyMM", new CultureInfo("en-US"));
				}
				indicator.OrdIndicatorDate = ((!string.IsNullOrEmpty(indicator.OrdIndicatorDate)) ? indicator.OrdIndicatorDate.Replace("/", "") : "");
				indicator.OrdIndicatorFDate = ((!string.IsNullOrEmpty(indicator.OrdIndicatorFDate)) ? indicator.OrdIndicatorFDate.Replace("/", "") : "");
				indicator.OrdIndicatorTDate = ((!string.IsNullOrEmpty(indicator.OrdIndicatorTDate)) ? indicator.OrdIndicatorTDate.Replace("/", "") : "");
				indicator.OrdIndicatorMonth = (string.IsNullOrEmpty(indicator.OrdIndicatorMonth) ? "0" : ((lCID == 1025) ? text : (DateTime.Now.ToString("yyyy") + indicator.OrdIndicatorMonth)));
				indicator.OrdIndicatorOrderNumber = (string.IsNullOrEmpty(indicator.OrdIndicatorOrderNumber) ? "0" : indicator.OrdIndicatorOrderNumber);
				indicator.OrdIndicatorStatusId = (string.IsNullOrEmpty(indicator.OrdIndicatorStatusId) ? "0" : indicator.OrdIndicatorStatusId);
				indicator.OrdIndicatorFirstRegisterUserId = (string.IsNullOrEmpty(indicator.OrdIndicatorFirstRegisterUserId) ? "0" : indicator.OrdIndicatorFirstRegisterUserId);
				indicator.OrdIndicatorReferUserId = (string.IsNullOrEmpty(indicator.OrdIndicatorReferUserId) ? "0" : indicator.OrdIndicatorReferUserId);
				indicator.OrdIndicatorPrdFirstGroupId = (string.IsNullOrEmpty(indicator.OrdIndicatorPrdFirstGroupId) ? "0" : indicator.OrdIndicatorPrdFirstGroupId);
				indicator.OrdIndicatorPrdSecondGroupId = (string.IsNullOrEmpty(indicator.OrdIndicatorPrdSecondGroupId) ? "0" : indicator.OrdIndicatorPrdSecondGroupId);
				indicator.OrdIndicatorPrdId = (string.IsNullOrEmpty(indicator.OrdIndicatorPrdId) ? "0" : indicator.OrdIndicatorPrdId);
				indicator.OrdIndicatorOrderOprId = (string.IsNullOrEmpty(indicator.OrdIndicatorOrderOprId) ? "0" : indicator.OrdIndicatorOrderOprId);
				indicator.OrdIndicatorOtherFieldValue = (string.IsNullOrEmpty(indicator.OrdIndicatorOtherFieldValue) ? "0" : indicator.OrdIndicatorOtherFieldValue);
				indicator.OrdIndicatorOtherFieldName = (string.IsNullOrEmpty(indicator.OrdIndicatorOtherFieldName) ? "0" : indicator.OrdIndicatorOtherFieldName);
				if (indicator.OrdIndicatorOtherFieldValueLikelyBoolean)
				{
					indicator.OrdIndicatorOtherFieldValueLikely = "1";
				}
				else
				{
					indicator.OrdIndicatorOtherFieldValueLikely = "0";
					switch (indicator.OrdIndicatorOtherFieldValue)
					{
					case "#Have":
					case "#دارد":
					case "#يملك":
						indicator.OrdIndicatorOtherFieldValue = "-2";
						break;
					case "#HaveNot":
					case "#ندارد":
					case "#لا يملك":
						indicator.OrdIndicatorOtherFieldValue = "-1";
						break;
					}
				}
				if (indicator.OrdIndicatorOtherFieldName == "ordDiscountPercent" || indicator.OrdIndicatorOtherFieldName == "ordTaxIndex")
				{
					indicator.OrdIndicatorOtherFieldValue += ".00";
				}
				if (indicator.OrdIndicatorOtherFieldName == "0")
				{
					indicator.OrdIndicatorOtherFieldValue = "0";
				}
				if (!string.IsNullOrEmpty(indicator.OrdIndicatorOrderOprIdMulti) && indicator.OrdIndicatorOrderOprIdMulti != "0")
				{
					indicator.OrdIndicatorOrderOprId = indicator.OrdIndicatorOrderOprIdMulti.Trim().Replace("|", ",").Trim();
				}
				if (!string.IsNullOrEmpty(indicator.OrdIndicatorStatusIdMulti) && indicator.OrdIndicatorStatusIdMulti != "0")
				{
					indicator.OrdIndicatorStatusId = indicator.OrdIndicatorStatusIdMulti.Trim().Replace("|", ",").Trim();
				}
				if (!string.IsNullOrEmpty(indicator.OrdIndicatorPrdIdMulti) && indicator.OrdIndicatorPrdIdMulti != "0")
				{
					indicator.OrdIndicatorPrdId = indicator.OrdIndicatorPrdIdMulti.Trim().Replace("|", ",").Trim();
				}
				if (string.IsNullOrEmpty(indicator.OrdIndicatorOrderAmount))
				{
					indicator.OrdIndicatorOrderAmount = "0";
				}
				if (string.IsNullOrEmpty(indicator.OrdIndicatorOrderAmountTo))
				{
					indicator.OrdIndicatorOrderAmountTo = "0";
				}
				if (string.IsNullOrEmpty(indicator.OrdIndicatorOrderVerifiedStatusId))
				{
					indicator.OrdIndicatorOrderVerifiedStatusId = "0";
				}
				if (string.IsNullOrEmpty(indicator.OrdIndicatorPrintFormatId))
				{
					indicator.OrdIndicatorPrintFormatId = "0";
				}
				if (string.IsNullOrEmpty(indicator.OrdIndicatorSettlementTypeId))
				{
					indicator.OrdIndicatorSettlementTypeId = "0";
				}
				if (string.IsNullOrEmpty(indicator.OrdIndicatorDeliveryTermId))
				{
					indicator.OrdIndicatorDeliveryTermId = "0";
				}
				if (string.IsNullOrEmpty(indicator.OrdIndicatorVerificationWorkflowId))
				{
					indicator.OrdIndicatorVerificationWorkflowId = "0";
				}
				if (string.IsNullOrEmpty(indicator.OrdIndicatorVerificationWorkflowStepId))
				{
					indicator.OrdIndicatorVerificationWorkflowStepId = "0";
				}
				if (string.IsNullOrEmpty(indicator.OrdIndicatorSellerId))
				{
					indicator.OrdIndicatorSellerId = "0";
				}
				if (!string.IsNullOrEmpty(indicator.OrdIndicatorSaleCenterIdMulti) && indicator.OrdIndicatorSaleCenterIdMulti != "0")
				{
					indicator.OrdIndicatorSaleCenterId = indicator.OrdIndicatorSaleCenterIdMulti.Trim().Replace("|", ",").Trim();
				}
				else if (!string.IsNullOrEmpty(indicator.OrdIndicatorSaleCenterId) && indicator.OrdIndicatorSaleCenterId != "0")
				{
					indicator.OrdIndicatorSaleCenterId = indicator.OrdIndicatorSaleCenterId.Trim().Replace("|", ",").Trim();
				}
				indicator.OrdIndicatorHaveLinkAcc = (string.IsNullOrEmpty(indicator.OrdIndicatorHaveLinkAcc) ? "0" : indicator.OrdIndicatorHaveLinkAcc);
				indicator.OrdIndicatorHaveTsp = (string.IsNullOrEmpty(indicator.OrdIndicatorHaveTsp) ? "0" : indicator.OrdIndicatorHaveTsp);
				indicator.OrdIndicatorTspStatusResult = (string.IsNullOrWhiteSpace(indicator.OrdIndicatorTspStatusResult) ? "0" : indicator.OrdIndicatorTspStatusResult);
				indicator.OrdIndicatorPrdColorId = (string.IsNullOrWhiteSpace(indicator.OrdIndicatorPrdColorId) ? "0" : indicator.OrdIndicatorPrdColorId);
				indicator.OrdIndicatorPrdSize = (string.IsNullOrWhiteSpace(indicator.OrdIndicatorPrdSize) ? "" : indicator.OrdIndicatorPrdSize);
				indicator.OrdIndicatorPrdDesign = (string.IsNullOrWhiteSpace(indicator.OrdIndicatorPrdDesign) ? "" : indicator.OrdIndicatorPrdDesign);
				if (!string.IsNullOrWhiteSpace(indicator.OrdIndicatorFirstRegisterUserIdMulti) && indicator.OrdIndicatorFirstRegisterUserIdMulti != "0")
				{
					indicator.OrdIndicatorFirstRegisterUserId = indicator.OrdIndicatorFirstRegisterUserIdMulti.Trim().Replace("|", ",").Trim();
				}
				if (!string.IsNullOrWhiteSpace(indicator.OrdIndicatorReferUserIdMulti) && indicator.OrdIndicatorReferUserIdMulti != "0")
				{
					indicator.OrdIndicatorReferUserId = indicator.OrdIndicatorReferUserIdMulti.Trim().Replace("|", ",").Trim();
				}
				if (!string.IsNullOrWhiteSpace(indicator.OrdIndicatorSellerIdMulti) && indicator.OrdIndicatorSellerIdMulti != "0")
				{
					indicator.OrdIndicatorSellerId = indicator.OrdIndicatorSellerIdMulti.Trim().Replace("|", ",").Trim();
				}
				indicator.LinkAccSettingDBId = indicator.LinkAccSettingDBId.GetValueOrDefault();
				indicator.OrdIndicatorWrhsId = (string.IsNullOrWhiteSpace(indicator.OrdIndicatorWrhsId) ? "0" : indicator.OrdIndicatorWrhsId);
				if (!string.IsNullOrWhiteSpace(indicator.OrdIndicatorWrhsIds) && indicator.OrdIndicatorWrhsIds != "0")
				{
					indicator.OrdIndicatorWrhsId = indicator.OrdIndicatorWrhsIds.Trim().Replace("|", ",").Trim();
				}
				DateTime value = DateTime.Now;
				DateTime value2 = DateTime.Now;
				DateTime value3 = DateTime.Now;
				if (!string.IsNullOrEmpty(indicator.OrdIndicatorDate))
				{
					value = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.OrdIndicatorDate.Replace("/", "")), lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.OrdIndicatorFDate))
				{
					value2 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.OrdIndicatorFDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.OrdIndicatorTDate))
				{
					value3 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.OrdIndicatorTDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				indicator.OrdIndicatorFDeadlineDate = ((!string.IsNullOrEmpty(indicator.OrdIndicatorFDeadlineDate)) ? indicator.OrdIndicatorFDeadlineDate.Replace("/", "") : "");
				indicator.OrdIndicatorTDeadlineDate = ((!string.IsNullOrEmpty(indicator.OrdIndicatorTDeadlineDate)) ? indicator.OrdIndicatorTDeadlineDate.Replace("/", "") : "");
				DateTime value4 = DateTime.Now;
				DateTime value5 = DateTime.Now;
				if (!string.IsNullOrEmpty(indicator.OrdIndicatorFDeadlineDate))
				{
					value4 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.OrdIndicatorFDeadlineDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.OrdIndicatorTDeadlineDate))
				{
					value5 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.OrdIndicatorTDeadlineDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				indicator.OrdIndicatorFPayDocDateTemp = ((!string.IsNullOrEmpty(indicator.OrdIndicatorFPayDocDateTemp)) ? indicator.OrdIndicatorFPayDocDateTemp.Replace("/", "") : "");
				indicator.OrdIndicatorTPayDocDateTemp = ((!string.IsNullOrEmpty(indicator.OrdIndicatorTPayDocDateTemp)) ? indicator.OrdIndicatorTPayDocDateTemp.Replace("/", "") : "");
				DateTime value6 = DateTime.Now;
				DateTime value7 = DateTime.Now;
				if (!string.IsNullOrEmpty(indicator.OrdIndicatorFPayDocDateTemp))
				{
					value6 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.OrdIndicatorFPayDocDateTemp.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.OrdIndicatorTPayDocDateTemp))
				{
					value7 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.OrdIndicatorTPayDocDateTemp.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.OrdIndicatorFDeliveryDateStr))
				{
					indicator.OrdIndicatorFDeliveryDate = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.OrdIndicatorFDeliveryDateStr.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.OrdIndicatorTDeliveryDateStr))
				{
					indicator.OrdIndicatorTDeliveryDate = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.OrdIndicatorTDeliveryDateStr.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				indicator.OrdIndicatorTracing = ConvertCharacter.DecodeTracing(indicator.OrdIndicatorTracing);
				DayOfWeek dayOfWeek = DateTime.Now.DayOfWeek;
				items = Enumerable.ToList<mct_WSspSelectOrderIndicator_Result>((IEnumerable<mct_WSspSelectOrderIndicator_Result>)_db.mfi_WSspSelectOrderIndicator(indicator.OrdIndicatorDate, orderOprID: indicator.OrdIndicatorOrderOprId, fDate: indicator.OrdIndicatorFDate, tDate: indicator.OrdIndicatorTDate, month: indicator.OrdIndicatorMonth, companyID: indicator.OrdIndicatorCompanyId, orderNumber: indicator.OrdIndicatorOrderNumber, statusID: indicator.OrdIndicatorStatusId, ordFirstRegisterUserId: indicator.OrdIndicatorFirstRegisterUserId, ordReferUserId: indicator.OrdIndicatorReferUserId, prdFirstGroupId: indicator.OrdIndicatorPrdFirstGroupId, prdSecondGroupId: indicator.OrdIndicatorPrdSecondGroupId, prdId: indicator.OrdIndicatorPrdId, orderAmount: indicator.OrdIndicatorOrderAmount, orderAmountTo: indicator.OrdIndicatorOrderAmountTo, orderVerifiedStatusId: indicator.OrdIndicatorOrderVerifiedStatusId, printFormatId: indicator.OrdIndicatorPrintFormatId, ordSettlementTypeId: indicator.OrdIndicatorSettlementTypeId, otherFieldName: indicator.OrdIndicatorOtherFieldName, otherFieldValueLikely: indicator.OrdIndicatorOtherFieldValueLikely, otherFieldValue: indicator.OrdIndicatorOtherFieldValue, rptUserId: UserLogin.CurrentUser.UserId, rptDate: DateTime.Now.ToString("yyyy/MM/dd"), rptDay: DefineDayeOfWeekFa(dayOfWeek.ToString()), mode: 1, languageID: lCID, defaultLanguageID: result, dateTime: value, fDateTime: value2, tDateTime: value3, ordDeliveryTermId: indicator.OrdIndicatorDeliveryTermId, verificationWorkflowId: indicator.OrdIndicatorVerificationWorkflowId, verificationWorkflowStepId: indicator.OrdIndicatorVerificationWorkflowStepId, ordSellerId: indicator.OrdIndicatorSellerId, tracing: indicator.OrdIndicatorTracing, saleCenterId: indicator.OrdIndicatorSaleCenterId, haveLinkAcc: indicator.OrdIndicatorHaveLinkAcc, haveTsp: indicator.OrdIndicatorHaveTsp, prdColorId: indicator.OrdIndicatorPrdColorId, prdSize: indicator.OrdIndicatorPrdSize, prdDesign: indicator.OrdIndicatorPrdDesign, fDeadlineDateTime: (!string.IsNullOrEmpty(indicator.OrdIndicatorFDeadlineDate)) ? new DateTime?(value4) : null, tDeadlineDateTime: (!string.IsNullOrEmpty(indicator.OrdIndicatorTDeadlineDate)) ? new DateTime?(value5) : null, fPayDocDateTimeTemp: (!string.IsNullOrEmpty(indicator.OrdIndicatorFPayDocDateTemp)) ? new DateTime?(value6) : null, tPayDocDateTimeTemp: (!string.IsNullOrEmpty(indicator.OrdIndicatorTPayDocDateTemp)) ? new DateTime?(value7) : null, linkAccSettingDBId: indicator.LinkAccSettingDBId, wHId: indicator.OrdIndicatorWrhsId, ordIndicatorHaveDoc: indicator.OrdIndicatorHaveDoc, centerId: result2, fDeliveryDate: indicator.OrdIndicatorFDeliveryDate, tDeliveryDate: indicator.OrdIndicatorTDeliveryDate, fDeliveryTime: indicator.OrdIndicatorFDeliveryTime, tDeliveryTime: indicator.OrdIndicatorTDeliveryTime, prdSpecificationsJs: indicator.OrdIndicatorPrdSpecsJson, ordCurrencyUnitId: indicator.OrdCurrencyUnitId, ordTspStatusResult: indicator.OrdIndicatorTspStatusResult));
				if (Enumerable.Any<mct_WSspSelectOrderIndicator_Result>((IEnumerable<mct_WSspSelectOrderIndicator_Result>)items))
				{
					itemFooter = Enumerable.FirstOrDefault<mct_WSspSelectOrderIndicatorSum_Result>((IEnumerable<mct_WSspSelectOrderIndicatorSum_Result>)Enumerable.ToList<mct_WSspSelectOrderIndicatorSum_Result>((IEnumerable<mct_WSspSelectOrderIndicatorSum_Result>)_db.mfi_WSspSelectOrderIndicatorSum(indicator.OrdIndicatorDate, indicator.OrdIndicatorFDate, indicator.OrdIndicatorTDate, indicator.OrdIndicatorMonth, indicator.OrdIndicatorCompanyId, indicator.OrdIndicatorOrderNumber, indicator.OrdIndicatorStatusId, indicator.OrdIndicatorOrderOprId, indicator.OrdIndicatorFirstRegisterUserId, indicator.OrdIndicatorReferUserId, indicator.OrdIndicatorPrdFirstGroupId, indicator.OrdIndicatorPrdSecondGroupId, indicator.OrdIndicatorPrdId, indicator.OrdIndicatorOrderAmount, indicator.OrdIndicatorOrderAmountTo, indicator.OrdIndicatorOrderVerifiedStatusId, indicator.OrdIndicatorPrintFormatId, indicator.OrdIndicatorSettlementTypeId, indicator.OrdIndicatorOtherFieldName, indicator.OrdIndicatorOtherFieldValueLikely, indicator.OrdIndicatorOtherFieldValue, UserLogin.CurrentUser.UserId, DateTime.Now.ToString("yyyy/MM/dd"), DefineDayeOfWeekFa(dayOfWeek.ToString()), lCID, result, value, value2, value3, indicator.OrdIndicatorDeliveryTermId, indicator.OrdIndicatorVerificationWorkflowId, indicator.OrdIndicatorVerificationWorkflowStepId, indicator.OrdIndicatorSellerId, indicator.OrdIndicatorTracing, indicator.OrdIndicatorSaleCenterId, indicator.OrdIndicatorHaveLinkAcc, indicator.OrdIndicatorHaveTsp, indicator.OrdIndicatorPrdColorId, indicator.OrdIndicatorPrdSize, indicator.OrdIndicatorPrdDesign, (!string.IsNullOrEmpty(indicator.OrdIndicatorFDeadlineDate)) ? new DateTime?(value4) : null, (!string.IsNullOrEmpty(indicator.OrdIndicatorTDeadlineDate)) ? new DateTime?(value5) : null, (!string.IsNullOrEmpty(indicator.OrdIndicatorFPayDocDateTemp)) ? new DateTime?(value6) : null, (!string.IsNullOrEmpty(indicator.OrdIndicatorTPayDocDateTemp)) ? new DateTime?(value7) : null, indicator.LinkAccSettingDBId, indicator.OrdIndicatorWrhsId, indicator.OrdIndicatorHaveDoc, result2, indicator.OrdIndicatorFDeliveryDate, indicator.OrdIndicatorTDeliveryDate, indicator.OrdIndicatorFDeliveryTime, indicator.OrdIndicatorTDeliveryTime, indicator.OrdIndicatorPrdSpecsJson, indicator.OrdCurrencyUnitId, indicator.OrdIndicatorTspStatusResult)));
				}
				foreach (mct_WSspSelectOrderIndicator_Result item in items)
				{
					if (lCID != 1065 && !string.IsNullOrEmpty(item.ordDate))
					{
						item.ordDate = PersianDate.GetShamsi2Miladi(item.ordDate.Replace("/", "")).Replace("/", "");
					}
				}
				indicatorOrderItem.Items = items;
				indicatorOrderItem.ItemFooter = itemFooter;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return indicatorOrderItem;
	}

	public ActionResult OrderIndicator_Read([DataSourceRequest] DataSourceRequest request, string indicator)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		OrderIndicatorViewModel indicator2 = new JavaScriptSerializer().Deserialize<OrderIndicatorViewModel>(indicator);
		IndicatorOrderItem indicatorOrderItem = OrderIndicatorItem(indicator2);
		JsonResult jsonResult = Json(((IEnumerable)indicatorOrderItem.Items).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public string DefineDayeOfWeekFa(string day)
	{
		return day switch
		{
			"Saturday" => Labels.Saturday, 
			"Sunday" => Labels.Sunday, 
			"Monday" => Labels.Monday, 
			"Tuesday" => Labels.Tuesday, 
			"Wednesday" => Labels.Wednesday, 
			"Thursday" => Labels.Thursday, 
			"Friday" => Labels.Friday, 
			_ => day, 
		};
	}

	[AjaxOnly]
	public JsonResult IndicatorUpdateFooter(OrderIndicatorViewModel indicator)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		mct_WSspSelectOrderIndicatorSum_Result data = new mct_WSspSelectOrderIndicatorSum_Result();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (indicator != null)
			{
				indicator.OrdIndicatorMonth = ((indicator.OrdIndicatorMonth != null && indicator.OrdIndicatorMonth == "0") ? null : indicator.OrdIndicatorMonth);
				string text = "0";
				if (!string.IsNullOrEmpty(indicator.OrdIndicatorMonth) && indicator.OrdIndicatorMonth != "0")
				{
					text = DateTime.Parse(DateTime.Now.ToString("yyyy") + "/" + indicator.OrdIndicatorMonth + "/01").ToString("yyyyMM", new CultureInfo("en-US"));
				}
				indicator.OrdIndicatorDate = ((!string.IsNullOrEmpty(indicator.OrdIndicatorDate)) ? indicator.OrdIndicatorDate.Replace("/", "") : "");
				indicator.OrdIndicatorFDate = ((!string.IsNullOrEmpty(indicator.OrdIndicatorFDate)) ? indicator.OrdIndicatorFDate.Replace("/", "") : "");
				indicator.OrdIndicatorTDate = ((!string.IsNullOrEmpty(indicator.OrdIndicatorTDate)) ? indicator.OrdIndicatorTDate.Replace("/", "") : "");
				indicator.OrdIndicatorMonth = (string.IsNullOrEmpty(indicator.OrdIndicatorMonth) ? "0" : ((lCID == 1025) ? text : (DateTime.Now.ToString("yyyy") + indicator.OrdIndicatorMonth)));
				indicator.OrdIndicatorOrderNumber = (string.IsNullOrEmpty(indicator.OrdIndicatorOrderNumber) ? "0" : indicator.OrdIndicatorOrderNumber);
				indicator.OrdIndicatorStatusId = (string.IsNullOrEmpty(indicator.OrdIndicatorStatusId) ? "0" : indicator.OrdIndicatorStatusId);
				indicator.OrdIndicatorFirstRegisterUserId = (string.IsNullOrEmpty(indicator.OrdIndicatorFirstRegisterUserId) ? "0" : indicator.OrdIndicatorFirstRegisterUserId);
				indicator.OrdIndicatorReferUserId = (string.IsNullOrEmpty(indicator.OrdIndicatorReferUserId) ? "0" : indicator.OrdIndicatorReferUserId);
				indicator.OrdIndicatorPrdFirstGroupId = (string.IsNullOrEmpty(indicator.OrdIndicatorPrdFirstGroupId) ? "0" : indicator.OrdIndicatorPrdFirstGroupId);
				indicator.OrdIndicatorPrdSecondGroupId = (string.IsNullOrEmpty(indicator.OrdIndicatorPrdSecondGroupId) ? "0" : indicator.OrdIndicatorPrdSecondGroupId);
				indicator.OrdIndicatorPrdId = (string.IsNullOrEmpty(indicator.OrdIndicatorPrdId) ? "0" : indicator.OrdIndicatorPrdId);
				indicator.OrdIndicatorOrderOprId = (string.IsNullOrEmpty(indicator.OrdIndicatorOrderOprId) ? "0" : indicator.OrdIndicatorOrderOprId);
				indicator.OrdIndicatorOtherFieldValue = (string.IsNullOrEmpty(indicator.OrdIndicatorOtherFieldValue) ? "0" : indicator.OrdIndicatorOtherFieldValue);
				indicator.OrdIndicatorOtherFieldName = (string.IsNullOrEmpty(indicator.OrdIndicatorOtherFieldName) ? "0" : indicator.OrdIndicatorOtherFieldName);
				if (indicator.OrdIndicatorOtherFieldValueLikelyBoolean)
				{
					indicator.OrdIndicatorOtherFieldValueLikely = "1";
				}
				else
				{
					indicator.OrdIndicatorOtherFieldValueLikely = "0";
					switch (indicator.OrdIndicatorOtherFieldValue)
					{
					case "#Have":
					case "#دارد":
					case "#يملك":
						indicator.OrdIndicatorOtherFieldValue = "-2";
						break;
					case "#HaveNot":
					case "#ندارد":
					case "#لا يملك":
						indicator.OrdIndicatorOtherFieldValue = "-1";
						break;
					}
				}
				if (indicator.OrdIndicatorOtherFieldName == "ordDiscountPercent" || indicator.OrdIndicatorOtherFieldName == "ordTaxIndex")
				{
					indicator.OrdIndicatorOtherFieldValue += ".00";
				}
				if (indicator.OrdIndicatorOtherFieldName == "0")
				{
					indicator.OrdIndicatorOtherFieldValue = "0";
				}
				if (!string.IsNullOrEmpty(indicator.OrdIndicatorOrderOprIdMulti) && indicator.OrdIndicatorOrderOprIdMulti != "0")
				{
					indicator.OrdIndicatorOrderOprId = indicator.OrdIndicatorOrderOprIdMulti.Trim().Replace("|", ",").Trim();
				}
				if (!string.IsNullOrEmpty(indicator.OrdIndicatorStatusIdMulti) && indicator.OrdIndicatorStatusIdMulti != "0")
				{
					indicator.OrdIndicatorStatusId = indicator.OrdIndicatorStatusIdMulti.Trim().Replace("|", ",").Trim();
				}
				if (!string.IsNullOrEmpty(indicator.OrdIndicatorPrdIdMulti) && indicator.OrdIndicatorPrdIdMulti != "0")
				{
					indicator.OrdIndicatorPrdId = indicator.OrdIndicatorPrdIdMulti.Trim().Replace("|", ",").Trim();
				}
				if (string.IsNullOrEmpty(indicator.OrdIndicatorOrderAmount))
				{
					indicator.OrdIndicatorOrderAmount = "0";
				}
				if (string.IsNullOrEmpty(indicator.OrdIndicatorOrderAmountTo))
				{
					indicator.OrdIndicatorOrderAmountTo = "0";
				}
				if (string.IsNullOrEmpty(indicator.OrdIndicatorOrderVerifiedStatusId))
				{
					indicator.OrdIndicatorOrderVerifiedStatusId = "0";
				}
				if (string.IsNullOrEmpty(indicator.OrdIndicatorPrintFormatId))
				{
					indicator.OrdIndicatorPrintFormatId = "0";
				}
				if (string.IsNullOrEmpty(indicator.OrdIndicatorSettlementTypeId))
				{
					indicator.OrdIndicatorSettlementTypeId = "0";
				}
				if (string.IsNullOrEmpty(indicator.OrdIndicatorDeliveryTermId))
				{
					indicator.OrdIndicatorDeliveryTermId = "0";
				}
				if (string.IsNullOrEmpty(indicator.OrdIndicatorVerificationWorkflowId))
				{
					indicator.OrdIndicatorVerificationWorkflowId = "0";
				}
				if (string.IsNullOrEmpty(indicator.OrdIndicatorVerificationWorkflowStepId))
				{
					indicator.OrdIndicatorVerificationWorkflowStepId = "0";
				}
				if (string.IsNullOrEmpty(indicator.OrdIndicatorSellerId))
				{
					indicator.OrdIndicatorSellerId = "0";
				}
				if (!string.IsNullOrEmpty(indicator.OrdIndicatorSaleCenterIdMulti) && indicator.OrdIndicatorSaleCenterIdMulti != "0")
				{
					indicator.OrdIndicatorSaleCenterId = indicator.OrdIndicatorSaleCenterIdMulti.Trim().Replace("|", ",").Trim();
				}
				else if (!string.IsNullOrEmpty(indicator.OrdIndicatorSaleCenterId) && indicator.OrdIndicatorSaleCenterId != "0")
				{
					indicator.OrdIndicatorSaleCenterId = indicator.OrdIndicatorSaleCenterId.Trim().Replace("|", ",").Trim();
				}
				indicator.OrdIndicatorHaveLinkAcc = (string.IsNullOrEmpty(indicator.OrdIndicatorHaveLinkAcc) ? "0" : indicator.OrdIndicatorHaveLinkAcc);
				indicator.OrdIndicatorHaveTsp = (string.IsNullOrEmpty(indicator.OrdIndicatorHaveTsp) ? "0" : indicator.OrdIndicatorHaveTsp);
				indicator.OrdIndicatorTspStatusResult = (string.IsNullOrWhiteSpace(indicator.OrdIndicatorTspStatusResult) ? "0" : indicator.OrdIndicatorTspStatusResult);
				indicator.OrdIndicatorPrdColorId = (string.IsNullOrWhiteSpace(indicator.OrdIndicatorPrdColorId) ? "0" : indicator.OrdIndicatorPrdColorId);
				indicator.OrdIndicatorPrdSize = (string.IsNullOrWhiteSpace(indicator.OrdIndicatorPrdSize) ? "" : indicator.OrdIndicatorPrdSize);
				indicator.OrdIndicatorPrdDesign = (string.IsNullOrWhiteSpace(indicator.OrdIndicatorPrdDesign) ? "" : indicator.OrdIndicatorPrdDesign);
				if (!string.IsNullOrWhiteSpace(indicator.OrdIndicatorFirstRegisterUserIdMulti) && indicator.OrdIndicatorFirstRegisterUserIdMulti != "0")
				{
					indicator.OrdIndicatorFirstRegisterUserId = indicator.OrdIndicatorFirstRegisterUserIdMulti.Trim().Replace("|", ",").Trim();
				}
				if (!string.IsNullOrWhiteSpace(indicator.OrdIndicatorReferUserIdMulti) && indicator.OrdIndicatorReferUserIdMulti != "0")
				{
					indicator.OrdIndicatorReferUserId = indicator.OrdIndicatorReferUserIdMulti.Trim().Replace("|", ",").Trim();
				}
				if (!string.IsNullOrWhiteSpace(indicator.OrdIndicatorSellerIdMulti) && indicator.OrdIndicatorSellerIdMulti != "0")
				{
					indicator.OrdIndicatorSellerId = indicator.OrdIndicatorSellerIdMulti.Trim().Replace("|", ",").Trim();
				}
				indicator.LinkAccSettingDBId = indicator.LinkAccSettingDBId.GetValueOrDefault();
				indicator.OrdIndicatorWrhsId = (string.IsNullOrWhiteSpace(indicator.OrdIndicatorWrhsId) ? "0" : indicator.OrdIndicatorWrhsId);
				if (!string.IsNullOrWhiteSpace(indicator.OrdIndicatorWrhsIds) && indicator.OrdIndicatorWrhsIds != "0")
				{
					indicator.OrdIndicatorWrhsId = indicator.OrdIndicatorWrhsIds.Trim().Replace("|", ",").Trim();
				}
				DayOfWeek dayOfWeek = DateTime.Now.DayOfWeek;
				DateTime value = DateTime.Now;
				DateTime value2 = DateTime.Now;
				DateTime value3 = DateTime.Now;
				if (!string.IsNullOrEmpty(indicator.OrdIndicatorDate))
				{
					value = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.OrdIndicatorDate.Replace("/", "")), lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.OrdIndicatorFDate))
				{
					value2 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.OrdIndicatorFDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.OrdIndicatorTDate))
				{
					value3 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.OrdIndicatorTDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				indicator.OrdIndicatorFDeadlineDate = ((!string.IsNullOrEmpty(indicator.OrdIndicatorFDeadlineDate)) ? indicator.OrdIndicatorFDeadlineDate.Replace("/", "") : "");
				indicator.OrdIndicatorTDeadlineDate = ((!string.IsNullOrEmpty(indicator.OrdIndicatorTDeadlineDate)) ? indicator.OrdIndicatorTDeadlineDate.Replace("/", "") : "");
				DateTime value4 = DateTime.Now;
				DateTime value5 = DateTime.Now;
				if (!string.IsNullOrEmpty(indicator.OrdIndicatorFDeadlineDate))
				{
					value4 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.OrdIndicatorFDeadlineDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.OrdIndicatorTDeadlineDate))
				{
					value5 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.OrdIndicatorTDeadlineDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				indicator.OrdIndicatorFPayDocDateTemp = ((!string.IsNullOrEmpty(indicator.OrdIndicatorFPayDocDateTemp)) ? indicator.OrdIndicatorFPayDocDateTemp.Replace("/", "") : "");
				indicator.OrdIndicatorTPayDocDateTemp = ((!string.IsNullOrEmpty(indicator.OrdIndicatorTPayDocDateTemp)) ? indicator.OrdIndicatorTPayDocDateTemp.Replace("/", "") : "");
				DateTime value6 = DateTime.Now;
				DateTime value7 = DateTime.Now;
				if (!string.IsNullOrEmpty(indicator.OrdIndicatorFPayDocDateTemp))
				{
					value6 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.OrdIndicatorFPayDocDateTemp.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.OrdIndicatorTPayDocDateTemp))
				{
					value7 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.OrdIndicatorTPayDocDateTemp.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.OrdIndicatorFDeliveryDateStr))
				{
					indicator.OrdIndicatorFDeliveryDate = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.OrdIndicatorFDeliveryDateStr.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.OrdIndicatorTDeliveryDateStr))
				{
					indicator.OrdIndicatorTDeliveryDate = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.OrdIndicatorTDeliveryDateStr.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				indicator.OrdIndicatorTracing = ConvertCharacter.DecodeTracing(indicator.OrdIndicatorTracing);
				data = Enumerable.FirstOrDefault<mct_WSspSelectOrderIndicatorSum_Result>((IEnumerable<mct_WSspSelectOrderIndicatorSum_Result>)_db.mfi_WSspSelectOrderIndicatorSum(indicator.OrdIndicatorDate, indicator.OrdIndicatorFDate, indicator.OrdIndicatorTDate, indicator.OrdIndicatorMonth, indicator.OrdIndicatorCompanyId, indicator.OrdIndicatorOrderNumber, indicator.OrdIndicatorStatusId, indicator.OrdIndicatorOrderOprId, indicator.OrdIndicatorFirstRegisterUserId, indicator.OrdIndicatorReferUserId, indicator.OrdIndicatorPrdFirstGroupId, indicator.OrdIndicatorPrdSecondGroupId, indicator.OrdIndicatorPrdId, indicator.OrdIndicatorOrderAmount, indicator.OrdIndicatorOrderAmountTo, indicator.OrdIndicatorOrderVerifiedStatusId, indicator.OrdIndicatorPrintFormatId, indicator.OrdIndicatorSettlementTypeId, indicator.OrdIndicatorOtherFieldName, indicator.OrdIndicatorOtherFieldValueLikely, indicator.OrdIndicatorOtherFieldValue, UserLogin.CurrentUser.UserId, DateTime.Now.ToString("yyyy/MM/dd"), DefineDayeOfWeekFa(dayOfWeek.ToString()), lCID, result, value, value2, value3, indicator.OrdIndicatorDeliveryTermId, indicator.OrdIndicatorVerificationWorkflowId, indicator.OrdIndicatorVerificationWorkflowStepId, indicator.OrdIndicatorSellerId, indicator.OrdIndicatorTracing, indicator.OrdIndicatorSaleCenterId, indicator.OrdIndicatorHaveLinkAcc, indicator.OrdIndicatorHaveTsp, indicator.OrdIndicatorPrdColorId, indicator.OrdIndicatorPrdSize, indicator.OrdIndicatorPrdDesign, (!string.IsNullOrEmpty(indicator.OrdIndicatorFDeadlineDate)) ? new DateTime?(value4) : null, (!string.IsNullOrEmpty(indicator.OrdIndicatorTDeadlineDate)) ? new DateTime?(value5) : null, (!string.IsNullOrEmpty(indicator.OrdIndicatorFPayDocDateTemp)) ? new DateTime?(value6) : null, (!string.IsNullOrEmpty(indicator.OrdIndicatorTPayDocDateTemp)) ? new DateTime?(value7) : null, indicator.LinkAccSettingDBId, indicator.OrdIndicatorWrhsId, indicator.OrdIndicatorHaveDoc, result2, indicator.OrdIndicatorFDeliveryDate, indicator.OrdIndicatorTDeliveryDate, indicator.OrdIndicatorFDeliveryTime, indicator.OrdIndicatorTDeliveryTime, indicator.OrdIndicatorPrdSpecsJson, indicator.OrdCurrencyUnitId, indicator.OrdIndicatorTspStatusResult));
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

	[AjaxOnly]
	public JsonResult GetSaleCenters()
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
			List<WSspSelectSaleCenters_Result> list2 = Enumerable.ToList<WSspSelectSaleCenters_Result>((IEnumerable<WSspSelectSaleCenters_Result>)_db.WSspSelectSaleCenters(lCID, result));
			list.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			list.AddRange(Enumerable.Select<WSspSelectSaleCenters_Result, SelectListItem>((IEnumerable<WSspSelectSaleCenters_Result>)list2, (Func<WSspSelectSaleCenters_Result, SelectListItem>)((WSspSelectSaleCenters_Result item) => new SelectListItem
			{
				Text = item.SaleCenterName,
				Value = item.SaleCenterId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.SaleCenterList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult SearchSaleCenters(string value, int? saleCenterId = 0)
	{
		List<WSspSearchSaleCenters_Result> list = new List<WSspSearchSaleCenters_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			list = Enumerable.ToList<WSspSearchSaleCenters_Result>((IEnumerable<WSspSearchSaleCenters_Result>)_dbI.WSspSearchSaleCenters(value, lCID, result));
			int num = 600;
			if (list != null && Enumerable.Any<WSspSearchSaleCenters_Result>((IEnumerable<WSspSearchSaleCenters_Result>)list))
			{
				list = ((!string.IsNullOrWhiteSpace(value)) ? Enumerable.ToList<WSspSearchSaleCenters_Result>(Enumerable.Take<WSspSearchSaleCenters_Result>((IEnumerable<WSspSearchSaleCenters_Result>)list, num)) : ((saleCenterId.HasValue && saleCenterId != 0 && string.IsNullOrWhiteSpace(value)) ? Enumerable.ToList<WSspSearchSaleCenters_Result>(Enumerable.Take<WSspSearchSaleCenters_Result>(Enumerable.Where<WSspSearchSaleCenters_Result>((IEnumerable<WSspSearchSaleCenters_Result>)list, (Func<WSspSearchSaleCenters_Result, bool>)((WSspSearchSaleCenters_Result m) => m.SaleCenterId == saleCenterId)), num)) : ((!saleCenterId.HasValue || saleCenterId == 0) ? Enumerable.ToList<WSspSearchSaleCenters_Result>(Enumerable.Take<WSspSearchSaleCenters_Result>((IEnumerable<WSspSearchSaleCenters_Result>)list, num)) : Enumerable.ToList<WSspSearchSaleCenters_Result>(Enumerable.Take<WSspSearchSaleCenters_Result>(Enumerable.Where<WSspSearchSaleCenters_Result>((IEnumerable<WSspSearchSaleCenters_Result>)list, (Func<WSspSearchSaleCenters_Result, bool>)((WSspSearchSaleCenters_Result m) => m.SaleCenterId == saleCenterId)), num)))));
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
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public string ActSendSms()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		try
		{
			int userId = UserLogin.CurrentUser.UserId;
			DateTime now = DateTime.Now;
			string firstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			_db.CRMspFillsmsTempNumberFromOrderIndicator(userId, firstRegisterDatePersian, appType, lCID, result);
			return "1";
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			return Messages.msgErrorRunFunction + "<br>" + ex.Message;
		}
	}

	[DynamicAuthorize(ControllerName = "frmOrderIndicator", ActionName = "actCalculateOrderScores")]
	public ActionResult CalculateOrderScores()
	{
		return View();
	}

	[HttpPost]
	public JsonResult ActCalculateOrderScores(string fromDate, string toDate, int scoreRuleId = 0)
	{
		string text = "";
		string text2 = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		try
		{
			int result = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
			}
			if (!string.IsNullOrWhiteSpace(fromDate) && !string.IsNullOrWhiteSpace(toDate))
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
				if (result2 <= 0)
				{
					result2 = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				DateTime now = DateTime.Now;
				DateTime now2 = DateTime.Now;
				fromDate = fromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				now = lCID switch
				{
					1065 => DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00"), 
					1025 => DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None), 
					_ => DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None), 
				};
				toDate = toDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				now2 = lCID switch
				{
					1065 => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59"), 
					1025 => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59", new CultureInfo("ar-SA"), DateTimeStyles.None), 
					_ => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None), 
				};
				DateTime now3 = DateTime.Now;
				DateTime value = now3;
				string registerDatePersian = now3.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now3.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short value3 = short.Parse(Financial.Get().Id.ToString());
				int userId = UserLogin.CurrentUser.UserId;
				mct_Result_StrI mct_Result_StrI = Enumerable.FirstOrDefault<mct_Result_StrI>((IEnumerable<mct_Result_StrI>)_dbI.ScorespInsertAndCalcScoresFromOrderIndicator(now, now2, userId, value3, value2, value, registerDatePersian, appType, result2, result, scoreRuleId));
				if (mct_Result_StrI != null)
				{
					string text3 = mct_Result_StrI.Result.ToString();
					if (!string.IsNullOrWhiteSpace(text3))
					{
						if (text3 == "-1")
						{
							text = "";
							text2 = Messages.msgErrorRunFunction;
							commonResultStatusViewModel = CommonResultStatusViewModel.Error;
						}
						else
						{
							string[] array = text3.Split(new char[1] { '|' });
							string arg = "0";
							string arg2 = "0";
							if (array != null && array.Length > 1)
							{
								arg = array[0];
								arg = (string.IsNullOrWhiteSpace(arg) ? "0" : arg);
								arg2 = array[1];
								arg2 = (string.IsNullOrWhiteSpace(arg2) ? "0" : arg2);
							}
							text = "1";
							text2 = string.Format("msgSuccessInsertAndCalcScoresFromOrderIndicator".OrderMessages(), arg2, arg);
							commonResultStatusViewModel = CommonResultStatusViewModel.Success;
						}
					}
					else
					{
						text = "";
						text2 = Messages.msgErrorRunFunction;
						commonResultStatusViewModel = CommonResultStatusViewModel.Error;
					}
				}
				else
				{
					text = "";
					text2 = Messages.msgErrorRunFunction;
					commonResultStatusViewModel = CommonResultStatusViewModel.Error;
				}
			}
			else if (string.IsNullOrWhiteSpace(fromDate))
			{
				text = "";
				text2 = string.Format(Messages.msgErrorIsNotSelectedItem, Labels.CalculateOrdScoresFromDate);
				commonResultStatusViewModel = CommonResultStatusViewModel.Error;
			}
			else if (string.IsNullOrWhiteSpace(toDate))
			{
				text = "";
				text2 = string.Format(Messages.msgErrorIsNotSelectedItem, Labels.CalculateOrdScoresToDate);
				commonResultStatusViewModel = CommonResultStatusViewModel.Error;
			}
			else
			{
				text = "";
				text2 = Messages.msgErrorRunFunction;
				commonResultStatusViewModel = CommonResultStatusViewModel.Error;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text = "";
			text2 = Messages.msgErrorRunFunction + "<br>" + ex.Message;
			commonResultStatusViewModel = CommonResultStatusViewModel.Error;
		}
		CommonResultViewModel<string> data = new CommonResultViewModel<string>
		{
			Data = text,
			Message = text2,
			Status = commonResultStatusViewModel
		};
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[LoginAuthorize]
	[HttpPost]
	public JsonResult GetActiveScoreRules()
	{
		List<ScorespSelectActiveScoreRules_Result> data = new List<ScorespSelectActiveScoreRules_Result>();
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
			List<ScorespSelectActiveScoreRules_Result> list = Enumerable.ToList<ScorespSelectActiveScoreRules_Result>((IEnumerable<ScorespSelectActiveScoreRules_Result>)_dbII.ScorespSelectActiveScoreRules(30, lCID, result, result2));
			if (list != null)
			{
				data = list;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<WSspSelectSaleCenters_Result> SelectSaleCenters()
	{
		List<WSspSelectSaleCenters_Result> list = new List<WSspSelectSaleCenters_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			list = Enumerable.ToList<WSspSelectSaleCenters_Result>((IEnumerable<WSspSelectSaleCenters_Result>)_db.WSspSelectSaleCenters(lCID, result));
			if (list == null)
			{
				list = new List<WSspSelectSaleCenters_Result>();
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return list;
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectSaleCentersJs()
	{
		return JsonConvert.SerializeObject(SelectSaleCenters());
	}

	[AjaxOnly]
	public string OrderGroupVerify()
	{
		string text = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmOrderIndicator", "actOrderGroupVerify", currentUser))
		{
			return Messages.ErrorNotAccess;
		}
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = currentUser.UserId;
			DateTime now = DateTime.Now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int result2 = 0;
			if (currentUser != null)
			{
				int.TryParse(currentUser.UserLastCId.ToString(), out result2);
			}
			bool flag = UserLogin.IsUserAccess("frmOrder", "actIssueDraftAuto", currentUser);
			string formName = "frmOrder";
			string actionName = "actIssueDraftAuto";
			List<int> list = new List<int>();
			List<WSspSelectOrderIndicatorByDBTempInfo_Result> list2 = Enumerable.ToList<WSspSelectOrderIndicatorByDBTempInfo_Result>((IEnumerable<WSspSelectOrderIndicatorByDBTempInfo_Result>)_dbII.WSspSelectOrderIndicatorByDBTempInfo(currentUser.UserId, lCID, result));
			if (list2 != null && Enumerable.Any<WSspSelectOrderIndicatorByDBTempInfo_Result>((IEnumerable<WSspSelectOrderIndicatorByDBTempInfo_Result>)list2))
			{
				foreach (WSspSelectOrderIndicatorByDBTempInfo_Result item in list2)
				{
					int orderID = item.OrderID;
					string txt = string.Format("lblOrdByNum".OrderLabels(), item.ordNumber.ToString());
					if (orderID > 0 && !list.Contains(orderID))
					{
						list.Add(orderID);
					}
					string text2 = Order.CheckBeforeVerification(orderID, txt, 2, 0);
					if (!string.IsNullOrWhiteSpace(text2))
					{
						return text + text2;
					}
				}
			}
			_dbII.WSspOrderGroupVerify(userId, now, registerDatePersian);
			string text3 = "";
			string text4 = "";
			if (flag && Enumerable.Any<int>((IEnumerable<int>)list))
			{
				foreach (int item2 in list)
				{
					string refResult = "";
					bool flag2 = Order.IssueDraftAuto(item2, currentUser.UserId, ref refResult, 0, formName, actionName, result2);
					if (!string.IsNullOrWhiteSpace(refResult))
					{
						if (!flag2)
						{
							text3 = refResult;
							break;
						}
						if (!string.IsNullOrWhiteSpace(text4))
						{
							text4 += "<br>";
						}
						text4 += refResult;
					}
				}
			}
			text = "1|" + currentUser.UserId + "|" + currentUser.FullName + " (" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + ")";
			if (!string.IsNullOrWhiteSpace(text3))
			{
				return text + "|doc-1^,^" + text3;
			}
			if (!string.IsNullOrWhiteSpace(text4))
			{
				text = text + "|doc1^,^" + text4;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = Messages.frmErrorMessage;
		}
		return text;
	}

	[AjaxOnly]
	public string OrderGroupVerifyExit()
	{
		string text = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmOrderIndicator", "actOrderGroupVerifyExit", currentUser))
		{
			return Messages.ErrorNotAccess;
		}
		try
		{
			int userId = currentUser.UserId;
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			_dbII.WSspOrderGroupVerifyExit(userId);
			return "1";
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.frmErrorMessage;
		}
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbI.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}
}

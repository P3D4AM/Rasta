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

namespace CRMIdeal.Areas.PreOrders.Controllers;

public class IndicatorController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	public ActionResult Index(int position = 0, int cmpId = 0, string cmpName = "")
	{
		string text = "";
		string text2 = "";
		switch (position)
		{
		case 0:
			text = "frmMain";
			text2 = "actPreOrderIndicator";
			break;
		case 1:
			text = "frmMain";
			text2 = "actPreOrders";
			break;
		default:
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		if (!UserLogin.IsUserAccess(text, text2, UserLogin.CurrentUser))
		{
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		PreOrderIndicatorViewModel model = new PreOrderIndicatorViewModel
		{
			PordIndicatorCompanyId = cmpId.ToString(),
			PordIndicatorCompanyName = cmpName
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
		FillDropdownPordIndicator();
		GetPrdColor();
		GetWarehouse();
		return View(model);
	}

	private void FillDropdownPordIndicator()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<WSspSelectPreOrderOpr_Result> list = Enumerable.ToList<WSspSelectPreOrderOpr_Result>((IEnumerable<WSspSelectPreOrderOpr_Result>)_db.WSspSelectPreOrderOpr(lCID, result));
			List<SelectListItem> list2 = new List<SelectListItem>();
			list2.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			list2.AddRange(Enumerable.Select<WSspSelectPreOrderOpr_Result, SelectListItem>((IEnumerable<WSspSelectPreOrderOpr_Result>)list, (Func<WSspSelectPreOrderOpr_Result, SelectListItem>)((WSspSelectPreOrderOpr_Result item) => new SelectListItem
			{
				Text = item.PreOrderOpr,
				Value = item.PreOrderOprID.ToString(),
				Selected = false
			})));
			base.ViewBag.PreOrderOprList = list2;
			List<WSspSelectPreOrderTypes_Result> list3 = PreOrder.SelectPreOrderTypes();
			List<SelectListItem> list4 = new List<SelectListItem>();
			list4.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			if (list3 != null)
			{
				list4.AddRange(Enumerable.Select<WSspSelectPreOrderTypes_Result, SelectListItem>((IEnumerable<WSspSelectPreOrderTypes_Result>)list3, (Func<WSspSelectPreOrderTypes_Result, SelectListItem>)((WSspSelectPreOrderTypes_Result item) => new SelectListItem
				{
					Text = item.PreOrderType,
					Value = item.PreOrderTypeId.ToString(),
					Selected = false
				})));
			}
			base.ViewBag.PreOrderTypeList = list4;
			List<WSspSelectDeliveryTerms_Result> list5 = Enumerable.ToList<WSspSelectDeliveryTerms_Result>((IEnumerable<WSspSelectDeliveryTerms_Result>)_db.WSspSelectDeliveryTerms(lCID, result));
			List<SelectListItem> list6 = new List<SelectListItem>();
			list6.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			list6.AddRange(Enumerable.Select<WSspSelectDeliveryTerms_Result, SelectListItem>((IEnumerable<WSspSelectDeliveryTerms_Result>)list5, (Func<WSspSelectDeliveryTerms_Result, SelectListItem>)((WSspSelectDeliveryTerms_Result item) => new SelectListItem
			{
				Text = item.DeliveryTerm,
				Value = item.DeliveryTermId.ToString(),
				Selected = false
			})));
			base.ViewBag.PreOrderDeliveryTermList = list6;
			List<WSspSelectPreOrderReferUsers_Result> list7 = Enumerable.ToList<WSspSelectPreOrderReferUsers_Result>((IEnumerable<WSspSelectPreOrderReferUsers_Result>)_db.WSspSelectPreOrderReferUsers(UserLogin.CurrentUser.UserId, lCID, result, result2));
			List<SelectListItem> list8 = new List<SelectListItem>();
			list8.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			list8.AddRange(Enumerable.Select<WSspSelectPreOrderReferUsers_Result, SelectListItem>((IEnumerable<WSspSelectPreOrderReferUsers_Result>)list7, (Func<WSspSelectPreOrderReferUsers_Result, SelectListItem>)((WSspSelectPreOrderReferUsers_Result item) => new SelectListItem
			{
				Text = item.UserName,
				Value = item.UserId.ToString(),
				Selected = false
			})));
			base.ViewBag.UserList = list8;
			List<CRMspSelectActiveUsers_Result> list9 = Enumerable.ToList<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)_db.CRMspSelectActiveUsers(lCID, result, result2));
			List<SelectListItem> list10 = new List<SelectListItem>();
			list10.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			list10.AddRange(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)list9, (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result item) => new SelectListItem
			{
				Text = item.Name,
				Value = item.UserId.ToString(),
				Selected = false
			})));
			base.ViewBag.SellerList = list10;
			List<WSspSelectPreOrderStatus_Result> list11 = Enumerable.ToList<WSspSelectPreOrderStatus_Result>((IEnumerable<WSspSelectPreOrderStatus_Result>)_db.WSspSelectPreOrderStatus(lCID, result));
			List<SelectListItem> list12 = new List<SelectListItem>();
			list12.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			list12.AddRange(Enumerable.Select<WSspSelectPreOrderStatus_Result, SelectListItem>((IEnumerable<WSspSelectPreOrderStatus_Result>)list11, (Func<WSspSelectPreOrderStatus_Result, SelectListItem>)((WSspSelectPreOrderStatus_Result item) => new SelectListItem
			{
				Text = item.PreOrderStatus,
				Value = item.PreOrderStatusId.ToString(),
				Selected = false
			})));
			base.ViewBag.StatusList = list12;
			List<WSspSelectProductFirstGroupActiveInSale_Result> list13 = Enumerable.ToList<WSspSelectProductFirstGroupActiveInSale_Result>((IEnumerable<WSspSelectProductFirstGroupActiveInSale_Result>)_db.WSspSelectProductFirstGroupActiveInSale(lCID, result));
			List<SelectListItem> list14 = new List<SelectListItem>();
			list14.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			list14.AddRange(Enumerable.Select<WSspSelectProductFirstGroupActiveInSale_Result, SelectListItem>((IEnumerable<WSspSelectProductFirstGroupActiveInSale_Result>)list13, (Func<WSspSelectProductFirstGroupActiveInSale_Result, SelectListItem>)((WSspSelectProductFirstGroupActiveInSale_Result item) => new SelectListItem
			{
				Text = item.FGName,
				Value = item.PrdFirstGroupID.ToString(),
				Selected = false
			})));
			base.ViewBag.PrdFirstGroupList = list14;
			List<WSspSelectVerificationWorkFlowWithObjectType_Result> list15 = Enumerable.ToList<WSspSelectVerificationWorkFlowWithObjectType_Result>((IEnumerable<WSspSelectVerificationWorkFlowWithObjectType_Result>)_db.WSspSelectVerificationWorkFlowWithObjectType(10, lCID, result));
			List<SelectListItem> list16 = new List<SelectListItem>();
			list16.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			list16.AddRange(Enumerable.Select<WSspSelectVerificationWorkFlowWithObjectType_Result, SelectListItem>((IEnumerable<WSspSelectVerificationWorkFlowWithObjectType_Result>)list15, (Func<WSspSelectVerificationWorkFlowWithObjectType_Result, SelectListItem>)((WSspSelectVerificationWorkFlowWithObjectType_Result item) => new SelectListItem
			{
				Text = item.VerificationWorkFlowTitle,
				Value = item.VerificationWorkFlowId.ToString(),
				Selected = false
			})));
			base.ViewBag.VerificationWorkFlowList = list16;
			List<WSspSelectCurrencyUnits_Result> list17 = Enumerable.ToList<WSspSelectCurrencyUnits_Result>((IEnumerable<WSspSelectCurrencyUnits_Result>)_db.WSspSelectCurrencyUnits(lCID, result));
			List<SelectListItem> list18 = new List<SelectListItem>();
			list18.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			list18.AddRange(Enumerable.Select<WSspSelectCurrencyUnits_Result, SelectListItem>((IEnumerable<WSspSelectCurrencyUnits_Result>)list17, (Func<WSspSelectCurrencyUnits_Result, SelectListItem>)((WSspSelectCurrencyUnits_Result item) => new SelectListItem
			{
				Text = item.CurrencyUnit,
				Value = item.CurrencyUnitID.ToString(),
				Selected = false
			})));
			base.ViewBag.CurrencyUnitList = list18;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
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

	[HttpPost]
	[LoginAuthorize]
	public string GetPrdGroupsTree()
	{
		return JsonConvert.SerializeObject(Product.GetPrdGroupsTree());
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
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspPreOrderIndicatorSearchCompany_Result> data = new List<WSspPreOrderIndicatorSearchCompany_Result>();
		try
		{
			data = Enumerable.ToList<WSspPreOrderIndicatorSearchCompany_Result>((IEnumerable<WSspPreOrderIndicatorSearchCompany_Result>)_db.WSspPreOrderIndicatorSearchCompany(value, lCID, result));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
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
	public JsonResult GetCurrencyUnits()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectCurrencyUnits_Result> list = new List<WSspSelectCurrencyUnits_Result>();
		try
		{
			List<WSspSelectCurrencyUnits_Result> list2 = Enumerable.ToList<WSspSelectCurrencyUnits_Result>((IEnumerable<WSspSelectCurrencyUnits_Result>)_db.WSspSelectCurrencyUnits(lCID, result));
			list.Add(new WSspSelectCurrencyUnits_Result
			{
				CurrencyUnitID = 0,
				CurrencyUnit = Labels.SelectedListDefValue
			});
			list.AddRange(Enumerable.Select<WSspSelectCurrencyUnits_Result, WSspSelectCurrencyUnits_Result>((IEnumerable<WSspSelectCurrencyUnits_Result>)list2, (Func<WSspSelectCurrencyUnits_Result, WSspSelectCurrencyUnits_Result>)((WSspSelectCurrencyUnits_Result item) => new WSspSelectCurrencyUnits_Result
			{
				CurrencyUnitID = item.CurrencyUnitID,
				CurrencyUnit = item.CurrencyUnit
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
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

	public List<mct_WSspSelectPreOrderIndicator_Result> ListPreOrderIndicator(PreOrderIndicatorViewModel indicator)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<mct_WSspSelectPreOrderIndicator_Result> list = new List<mct_WSspSelectPreOrderIndicator_Result>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (indicator != null)
			{
				indicator.PordIndicatorMonth = ((indicator.PordIndicatorMonth != null && indicator.PordIndicatorMonth == "0") ? null : indicator.PordIndicatorMonth);
				string text = "0";
				if (!string.IsNullOrEmpty(indicator.PordIndicatorMonth) && indicator.PordIndicatorMonth != "0")
				{
					text = DateTime.Parse(DateTime.Now.ToString("yyyy") + "/" + indicator.PordIndicatorMonth + "/01").ToString("yyyyMM", new CultureInfo("en-US"));
				}
				indicator.PordIndicatorDate = ((!string.IsNullOrEmpty(indicator.PordIndicatorDate)) ? indicator.PordIndicatorDate.Replace("/", "") : "");
				indicator.PordIndicatorFDate = ((!string.IsNullOrEmpty(indicator.PordIndicatorFDate)) ? indicator.PordIndicatorFDate.Replace("/", "") : "");
				indicator.PordIndicatorTDate = ((!string.IsNullOrEmpty(indicator.PordIndicatorTDate)) ? indicator.PordIndicatorTDate.Replace("/", "") : "");
				indicator.PordIndicatorMonth = (string.IsNullOrEmpty(indicator.PordIndicatorMonth) ? "0" : ((lCID == 1025) ? text : (DateTime.Now.ToString("yyyy") + indicator.PordIndicatorMonth)));
				indicator.PordIndicatorPreOrderNumber = (string.IsNullOrEmpty(indicator.PordIndicatorPreOrderNumber) ? "0" : indicator.PordIndicatorPreOrderNumber);
				indicator.PordIndicatorStatusId = (string.IsNullOrEmpty(indicator.PordIndicatorStatusId) ? "0" : indicator.PordIndicatorStatusId);
				indicator.PordIndicatorFirstRegisterUserId = (string.IsNullOrEmpty(indicator.PordIndicatorFirstRegisterUserId) ? "0" : indicator.PordIndicatorFirstRegisterUserId);
				indicator.PordIndicatorReferUserId = (string.IsNullOrEmpty(indicator.PordIndicatorReferUserId) ? "0" : indicator.PordIndicatorReferUserId);
				indicator.PordIndicatorPrdFirstGroupId = (string.IsNullOrEmpty(indicator.PordIndicatorPrdFirstGroupId) ? "0" : indicator.PordIndicatorPrdFirstGroupId);
				indicator.PordIndicatorPrdSecondGroupId = (string.IsNullOrEmpty(indicator.PordIndicatorPrdSecondGroupId) ? "0" : indicator.PordIndicatorPrdSecondGroupId);
				indicator.PordIndicatorPrdId = (string.IsNullOrEmpty(indicator.PordIndicatorPrdId) ? "0" : indicator.PordIndicatorPrdId);
				indicator.PordIndicatorPreOrderOprId = (string.IsNullOrEmpty(indicator.PordIndicatorPreOrderOprId) ? "0" : indicator.PordIndicatorPreOrderOprId);
				indicator.PordIndicatorOtherFieldValue = (string.IsNullOrEmpty(indicator.PordIndicatorOtherFieldValue) ? "0" : indicator.PordIndicatorOtherFieldValue);
				indicator.PordIndicatorOtherFieldName = (string.IsNullOrEmpty(indicator.PordIndicatorOtherFieldName) ? "0" : indicator.PordIndicatorOtherFieldName);
				if (indicator.PordIndicatorOtherFieldValueLikelyBoolean)
				{
					indicator.PordIndicatorOtherFieldValueLikely = "1";
				}
				else
				{
					indicator.PordIndicatorOtherFieldValueLikely = "0";
					switch (indicator.PordIndicatorOtherFieldValue)
					{
					case "#Have":
					case "#دارد":
					case "#يملك":
						indicator.PordIndicatorOtherFieldValue = "-2";
						break;
					case "#HaveNot":
					case "#ندارد":
					case "#لا يملك":
						indicator.PordIndicatorOtherFieldValue = "-1";
						break;
					}
				}
				if (indicator.PordIndicatorOtherFieldName == "pordDiscountPercent" || indicator.PordIndicatorOtherFieldName == "pordTaxIndex")
				{
					indicator.PordIndicatorOtherFieldValue += ".00";
				}
				if (indicator.PordIndicatorOtherFieldName == "0")
				{
					indicator.PordIndicatorOtherFieldValue = "0";
				}
				if (!string.IsNullOrEmpty(indicator.PordIndicatorPrdIdMulti) && indicator.PordIndicatorPrdIdMulti != "0")
				{
					indicator.PordIndicatorPrdId = indicator.PordIndicatorPrdIdMulti.Trim().Replace("|", ",").Trim();
				}
				if (!string.IsNullOrEmpty(indicator.PordIndicatorPreOrderOprIdMulti) && indicator.PordIndicatorPreOrderOprIdMulti != "0")
				{
					indicator.PordIndicatorPreOrderOprId = indicator.PordIndicatorPreOrderOprIdMulti.Trim().Replace("|", ",").Trim();
				}
				indicator.PordIndicatorVerified = (string.IsNullOrEmpty(indicator.PordIndicatorVerified) ? "0" : indicator.PordIndicatorVerified);
				indicator.PordIndicatorHaveOrder = (string.IsNullOrEmpty(indicator.PordIndicatorHaveOrder) ? "0" : indicator.PordIndicatorHaveOrder);
				indicator.PordIndicatorVerificationWorkflowId = (string.IsNullOrEmpty(indicator.PordIndicatorVerificationWorkflowId) ? "0" : indicator.PordIndicatorVerificationWorkflowId);
				indicator.PordIndicatorVerificationWorkflowStepId = (string.IsNullOrEmpty(indicator.PordIndicatorVerificationWorkflowStepId) ? "0" : indicator.PordIndicatorVerificationWorkflowStepId);
				indicator.PordIndicatorPordTypeId = (string.IsNullOrEmpty(indicator.PordIndicatorPordTypeId) ? "0" : indicator.PordIndicatorPordTypeId);
				indicator.PordIndicatorPordDeliveryTermId = (string.IsNullOrEmpty(indicator.PordIndicatorPordDeliveryTermId) ? "0" : indicator.PordIndicatorPordDeliveryTermId);
				indicator.PordIndicatorSellerId = (string.IsNullOrEmpty(indicator.PordIndicatorSellerId) ? "0" : indicator.PordIndicatorSellerId);
				if (string.IsNullOrEmpty(indicator.PordIndicatorTotalAmount))
				{
					indicator.PordIndicatorTotalAmount = "0";
				}
				if (string.IsNullOrEmpty(indicator.PordIndicatorTotalAmountTo))
				{
					indicator.PordIndicatorTotalAmountTo = "0";
				}
				if (!string.IsNullOrEmpty(indicator.PordIndicatorPreOrderSaleCenterIdMulti) && indicator.PordIndicatorPreOrderSaleCenterIdMulti != "0")
				{
					indicator.PordIndicatorPreOrderSaleCenterId = indicator.PordIndicatorPreOrderSaleCenterIdMulti.Trim().Replace("|", ",").Trim();
				}
				else if (!string.IsNullOrEmpty(indicator.PordIndicatorPreOrderSaleCenterId) && indicator.PordIndicatorPreOrderSaleCenterId != "0")
				{
					indicator.PordIndicatorPreOrderSaleCenterId = indicator.PordIndicatorPreOrderSaleCenterId.Trim().Replace("|", ",").Trim();
				}
				indicator.PordIndicatorHaveLinkAcc = (string.IsNullOrEmpty(indicator.PordIndicatorHaveLinkAcc) ? "0" : indicator.PordIndicatorHaveLinkAcc);
				indicator.PordIndicatorPrdColorId = (string.IsNullOrWhiteSpace(indicator.PordIndicatorPrdColorId) ? "0" : indicator.PordIndicatorPrdColorId);
				indicator.PordIndicatorPrdSize = (string.IsNullOrWhiteSpace(indicator.PordIndicatorPrdSize) ? "" : indicator.PordIndicatorPrdSize);
				indicator.PordIndicatorPrdDesign = (string.IsNullOrWhiteSpace(indicator.PordIndicatorPrdDesign) ? "" : indicator.PordIndicatorPrdDesign);
				if (!string.IsNullOrWhiteSpace(indicator.PordIndicatorStatusIdMulti) && indicator.PordIndicatorStatusIdMulti != "0")
				{
					indicator.PordIndicatorStatusId = indicator.PordIndicatorStatusIdMulti.Trim().Replace("|", ",").Trim();
				}
				if (!string.IsNullOrWhiteSpace(indicator.PordIndicatorFirstRegisterUserIdMulti) && indicator.PordIndicatorFirstRegisterUserIdMulti != "0")
				{
					indicator.PordIndicatorFirstRegisterUserId = indicator.PordIndicatorFirstRegisterUserIdMulti.Trim().Replace("|", ",").Trim();
				}
				if (!string.IsNullOrWhiteSpace(indicator.PordIndicatorReferUserIdMulti) && indicator.PordIndicatorReferUserIdMulti != "0")
				{
					indicator.PordIndicatorReferUserId = indicator.PordIndicatorReferUserIdMulti.Trim().Replace("|", ",").Trim();
				}
				if (!string.IsNullOrWhiteSpace(indicator.PordIndicatorSellerIdMulti) && indicator.PordIndicatorSellerIdMulti != "0")
				{
					indicator.PordIndicatorSellerId = indicator.PordIndicatorSellerIdMulti.Trim().Replace("|", ",").Trim();
				}
				indicator.LinkAccSettingDBId = indicator.LinkAccSettingDBId.GetValueOrDefault();
				indicator.PordIndicatorWrhsId = (string.IsNullOrWhiteSpace(indicator.PordIndicatorWrhsId) ? "0" : indicator.PordIndicatorWrhsId);
				if (!string.IsNullOrWhiteSpace(indicator.PordIndicatorWrhsIds) && indicator.PordIndicatorWrhsIds != "0")
				{
					indicator.PordIndicatorWrhsId = indicator.PordIndicatorWrhsIds.Trim().Replace("|", ",").Trim();
				}
				DateTime value = DateTime.Now;
				DateTime value2 = DateTime.Now;
				DateTime value3 = DateTime.Now;
				if (!string.IsNullOrEmpty(indicator.PordIndicatorDate))
				{
					value = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.PordIndicatorDate.Replace("/", "")), lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.PordIndicatorFDate))
				{
					value2 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.PordIndicatorFDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.PordIndicatorTDate))
				{
					value3 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.PordIndicatorTDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				indicator.PordIndicatorFExpireDate = ((!string.IsNullOrEmpty(indicator.PordIndicatorFExpireDate)) ? indicator.PordIndicatorFExpireDate.Replace("/", "") : "");
				indicator.PordIndicatorTExpireDate = ((!string.IsNullOrEmpty(indicator.PordIndicatorTExpireDate)) ? indicator.PordIndicatorTExpireDate.Replace("/", "") : "");
				DateTime value4 = DateTime.Now;
				DateTime value5 = DateTime.Now;
				if (!string.IsNullOrEmpty(indicator.PordIndicatorFExpireDate))
				{
					value4 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.PordIndicatorFExpireDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.PordIndicatorTExpireDate))
				{
					value5 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.PordIndicatorTExpireDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				indicator.PordIndicatorFDeadlineDate = ((!string.IsNullOrEmpty(indicator.PordIndicatorFDeadlineDate)) ? indicator.PordIndicatorFDeadlineDate.Replace("/", "") : "");
				indicator.PordIndicatorTDeadlineDate = ((!string.IsNullOrEmpty(indicator.PordIndicatorTDeadlineDate)) ? indicator.PordIndicatorTDeadlineDate.Replace("/", "") : "");
				DateTime value6 = DateTime.Now;
				DateTime value7 = DateTime.Now;
				if (!string.IsNullOrEmpty(indicator.PordIndicatorFDeadlineDate))
				{
					value6 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.PordIndicatorFDeadlineDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.PordIndicatorTDeadlineDate))
				{
					value7 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.PordIndicatorTDeadlineDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				indicator.PordIndicatorFPayDocDateTemp = ((!string.IsNullOrEmpty(indicator.PordIndicatorFPayDocDateTemp)) ? indicator.PordIndicatorFPayDocDateTemp.Replace("/", "") : "");
				indicator.PordIndicatorTPayDocDateTemp = ((!string.IsNullOrEmpty(indicator.PordIndicatorTPayDocDateTemp)) ? indicator.PordIndicatorTPayDocDateTemp.Replace("/", "") : "");
				DateTime value8 = DateTime.Now;
				DateTime value9 = DateTime.Now;
				if (!string.IsNullOrEmpty(indicator.PordIndicatorFPayDocDateTemp))
				{
					value8 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.PordIndicatorFPayDocDateTemp.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.PordIndicatorTPayDocDateTemp))
				{
					value9 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.PordIndicatorTPayDocDateTemp.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.PordIndicatorFDeliveryDateStr))
				{
					indicator.PordIndicatorFDeliveryDate = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.PordIndicatorFDeliveryDateStr.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.PordIndicatorTDeliveryDateStr))
				{
					indicator.PordIndicatorTDeliveryDate = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.PordIndicatorTDeliveryDateStr.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				DayOfWeek dayOfWeek = DateTime.Now.DayOfWeek;
				list = Enumerable.ToList<mct_WSspSelectPreOrderIndicator_Result>((IEnumerable<mct_WSspSelectPreOrderIndicator_Result>)_db.mfi_WSspSelectPreOrderIndicator(indicator.PordIndicatorDate, indicator.PordIndicatorFDate, indicator.PordIndicatorTDate, indicator.PordIndicatorMonth, indicator.PordIndicatorCompanyId, indicator.PordIndicatorPreOrderNumber, indicator.PordIndicatorStatusId, indicator.PordIndicatorFirstRegisterUserId, indicator.PordIndicatorReferUserId, indicator.PordIndicatorPrdFirstGroupId, indicator.PordIndicatorPrdSecondGroupId, indicator.PordIndicatorPrdId, indicator.PordIndicatorPreOrderOprId, indicator.PordIndicatorOtherFieldName, indicator.PordIndicatorOtherFieldValueLikely, indicator.PordIndicatorOtherFieldValue, UserLogin.CurrentUser.UserId, DateTime.Now.ToString("yyyy/MM/dd"), DefineDayeOfWeekFa(dayOfWeek.ToString()), 1, indicator.PordIndicatorVerified, indicator.PordIndicatorHaveOrder, lCID, result, value, value2, value3, indicator.PordIndicatorVerificationWorkflowId, indicator.PordIndicatorVerificationWorkflowStepId, indicator.PordIndicatorPordDeliveryTermId, indicator.PordIndicatorPordTypeId, indicator.PordIndicatorTotalAmount, indicator.PordIndicatorTotalAmountTo, indicator.PordIndicatorSellerId, indicator.PordIndicatorPreOrderSaleCenterId, (!string.IsNullOrEmpty(indicator.PordIndicatorFExpireDate)) ? new DateTime?(value4) : null, (!string.IsNullOrEmpty(indicator.PordIndicatorTExpireDate)) ? new DateTime?(value5) : null, indicator.PordIndicatorHaveLinkAcc, indicator.PordIndicatorPrdColorId, indicator.PordIndicatorPrdSize, indicator.PordIndicatorPrdDesign, (!string.IsNullOrEmpty(indicator.PordIndicatorFDeadlineDate)) ? new DateTime?(value6) : null, (!string.IsNullOrEmpty(indicator.PordIndicatorTDeadlineDate)) ? new DateTime?(value7) : null, (!string.IsNullOrEmpty(indicator.PordIndicatorFPayDocDateTemp)) ? new DateTime?(value8) : null, (!string.IsNullOrEmpty(indicator.PordIndicatorTPayDocDateTemp)) ? new DateTime?(value9) : null, indicator.LinkAccSettingDBId, indicator.PordIndicatorWrhsId, result2, indicator.PordIndicatorFDeliveryDate, indicator.PordIndicatorTDeliveryDate, indicator.PordIndicatorFDeliveryTime, indicator.PordIndicatorTDeliveryTime, indicator.PordIndicatorPrdSpecsJson, indicator.PordCurrencyUnitId));
			}
			foreach (mct_WSspSelectPreOrderIndicator_Result item in list)
			{
				if (lCID != 1065 && !string.IsNullOrEmpty(item.pordDate))
				{
					item.pordDate = PersianDate.GetShamsi2Miladi(item.pordDate.Replace("/", "")).Replace("/", "");
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
	public ActionResult PreOrderIndicator_Read([DataSourceRequest] DataSourceRequest request, string indicator)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		PreOrderIndicatorViewModel indicator2 = new JavaScriptSerializer().Deserialize<PreOrderIndicatorViewModel>(indicator);
		JsonResult jsonResult = Json(((IEnumerable)ListPreOrderIndicator(indicator2)).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public ActionResult FirstLoadPreOrderIndicator(string cmpId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<mct_WSspSelectPreOrderIndicator_Result> list = new List<mct_WSspSelectPreOrderIndicator_Result>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (cmpId != "0" && cmpId != "" && cmpId != null)
			{
				string referUserId = UserLogin.CurrentUser.UserId.ToString();
				DayOfWeek dayOfWeek = DateTime.Now.DayOfWeek;
				list = Enumerable.ToList<mct_WSspSelectPreOrderIndicator_Result>((IEnumerable<mct_WSspSelectPreOrderIndicator_Result>)_db.mfi_WSspSelectPreOrderIndicator("", "", "", "0", cmpId, "0", "0", "0", referUserId, "0", "0", "0", "0", "0", "0", "0", UserLogin.CurrentUser.UserId, DateTime.Now.ToString("yyyyMMdd"), dayOfWeek.ToString(), 1, "0", "0", lCID, result, DateTime.Now, DateTime.Now, DateTime.Now, "0", "0", "0", "0", "0", "0", "0", "", null, null, "0", "0", "", "", null, null, null, null, 0, "0", result2, null, null, null, null, null, null));
				foreach (mct_WSspSelectPreOrderIndicator_Result item in list)
				{
					if (lCID != 1065 && !string.IsNullOrEmpty(item.pordDate))
					{
						item.pordDate = PersianDate.GetShamsi2Miladi(item.pordDate.Replace("/", "")).Replace("/", "");
					}
				}
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
	public JsonResult PreOrderIndicator(PreOrderIndicatorViewModel indicator)
	{
		JsonResult jsonResult = Json(ListPreOrderIndicator(indicator), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult IndicatorUpdateFooter(PreOrderIndicatorViewModel indicator)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		mct_WSspSelectPreOrderIndicatorSum_Result data = new mct_WSspSelectPreOrderIndicatorSum_Result();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (indicator != null)
			{
				indicator.PordIndicatorMonth = ((indicator.PordIndicatorMonth != null && indicator.PordIndicatorMonth == "0") ? null : indicator.PordIndicatorMonth);
				string text = "0";
				if (!string.IsNullOrEmpty(indicator.PordIndicatorMonth) && indicator.PordIndicatorMonth != "0")
				{
					text = DateTime.Parse(DateTime.Now.ToString("yyyy") + "/" + indicator.PordIndicatorMonth + "/01").ToString("yyyyMM", new CultureInfo("en-US"));
				}
				indicator.PordIndicatorDate = ((!string.IsNullOrEmpty(indicator.PordIndicatorDate)) ? indicator.PordIndicatorDate.Replace("/", "") : "");
				indicator.PordIndicatorFDate = ((!string.IsNullOrEmpty(indicator.PordIndicatorFDate)) ? indicator.PordIndicatorFDate.Replace("/", "") : "");
				indicator.PordIndicatorTDate = ((!string.IsNullOrEmpty(indicator.PordIndicatorTDate)) ? indicator.PordIndicatorTDate.Replace("/", "") : "");
				indicator.PordIndicatorMonth = (string.IsNullOrEmpty(indicator.PordIndicatorMonth) ? "0" : ((lCID == 1025) ? text : (DateTime.Now.ToString("yyyy") + indicator.PordIndicatorMonth)));
				indicator.PordIndicatorPreOrderNumber = (string.IsNullOrEmpty(indicator.PordIndicatorPreOrderNumber) ? "0" : indicator.PordIndicatorPreOrderNumber);
				indicator.PordIndicatorStatusId = (string.IsNullOrEmpty(indicator.PordIndicatorStatusId) ? "0" : indicator.PordIndicatorStatusId);
				indicator.PordIndicatorFirstRegisterUserId = (string.IsNullOrEmpty(indicator.PordIndicatorFirstRegisterUserId) ? "0" : indicator.PordIndicatorFirstRegisterUserId);
				indicator.PordIndicatorReferUserId = (string.IsNullOrEmpty(indicator.PordIndicatorReferUserId) ? "0" : indicator.PordIndicatorReferUserId);
				indicator.PordIndicatorPrdFirstGroupId = (string.IsNullOrEmpty(indicator.PordIndicatorPrdFirstGroupId) ? "0" : indicator.PordIndicatorPrdFirstGroupId);
				indicator.PordIndicatorPrdSecondGroupId = (string.IsNullOrEmpty(indicator.PordIndicatorPrdSecondGroupId) ? "0" : indicator.PordIndicatorPrdSecondGroupId);
				indicator.PordIndicatorPrdId = (string.IsNullOrEmpty(indicator.PordIndicatorPrdId) ? "0" : indicator.PordIndicatorPrdId);
				indicator.PordIndicatorPreOrderOprId = (string.IsNullOrEmpty(indicator.PordIndicatorPreOrderOprId) ? "0" : indicator.PordIndicatorPreOrderOprId);
				indicator.PordIndicatorOtherFieldValue = (string.IsNullOrEmpty(indicator.PordIndicatorOtherFieldValue) ? "0" : indicator.PordIndicatorOtherFieldValue);
				indicator.PordIndicatorOtherFieldName = (string.IsNullOrEmpty(indicator.PordIndicatorOtherFieldName) ? "0" : indicator.PordIndicatorOtherFieldName);
				if (indicator.PordIndicatorOtherFieldValueLikelyBoolean)
				{
					indicator.PordIndicatorOtherFieldValueLikely = "1";
				}
				else
				{
					indicator.PordIndicatorOtherFieldValueLikely = "0";
					switch (indicator.PordIndicatorOtherFieldValue)
					{
					case "#Have":
					case "#دارد":
					case "#يملك":
						indicator.PordIndicatorOtherFieldValue = "-2";
						break;
					case "#HaveNot":
					case "#ندارد":
					case "#لا يملك":
						indicator.PordIndicatorOtherFieldValue = "-1";
						break;
					}
				}
				if (indicator.PordIndicatorOtherFieldName == "pordDiscountPercent" || indicator.PordIndicatorOtherFieldName == "pordTaxIndex")
				{
					indicator.PordIndicatorOtherFieldValue += ".00";
				}
				if (indicator.PordIndicatorOtherFieldName == "0")
				{
					indicator.PordIndicatorOtherFieldValue = "0";
				}
				if (!string.IsNullOrEmpty(indicator.PordIndicatorPrdIdMulti) && indicator.PordIndicatorPrdIdMulti != "0")
				{
					indicator.PordIndicatorPrdId = indicator.PordIndicatorPrdIdMulti.Trim().Replace("|", ",").Trim();
				}
				if (!string.IsNullOrEmpty(indicator.PordIndicatorPreOrderOprIdMulti) && indicator.PordIndicatorPreOrderOprIdMulti != "0")
				{
					indicator.PordIndicatorPreOrderOprId = indicator.PordIndicatorPreOrderOprIdMulti.Trim().Replace("|", ",").Trim();
				}
				indicator.PordIndicatorVerified = (string.IsNullOrEmpty(indicator.PordIndicatorVerified) ? "0" : indicator.PordIndicatorVerified);
				indicator.PordIndicatorHaveOrder = (string.IsNullOrEmpty(indicator.PordIndicatorHaveOrder) ? "0" : indicator.PordIndicatorHaveOrder);
				indicator.PordIndicatorVerificationWorkflowId = (string.IsNullOrEmpty(indicator.PordIndicatorVerificationWorkflowId) ? "0" : indicator.PordIndicatorVerificationWorkflowId);
				indicator.PordIndicatorVerificationWorkflowStepId = (string.IsNullOrEmpty(indicator.PordIndicatorVerificationWorkflowStepId) ? "0" : indicator.PordIndicatorVerificationWorkflowStepId);
				indicator.PordIndicatorPordTypeId = (string.IsNullOrEmpty(indicator.PordIndicatorPordTypeId) ? "0" : indicator.PordIndicatorPordTypeId);
				indicator.PordIndicatorPordDeliveryTermId = (string.IsNullOrEmpty(indicator.PordIndicatorPordDeliveryTermId) ? "0" : indicator.PordIndicatorPordDeliveryTermId);
				indicator.PordIndicatorSellerId = (string.IsNullOrEmpty(indicator.PordIndicatorSellerId) ? "0" : indicator.PordIndicatorSellerId);
				if (string.IsNullOrEmpty(indicator.PordIndicatorTotalAmount))
				{
					indicator.PordIndicatorTotalAmount = "0";
				}
				if (string.IsNullOrEmpty(indicator.PordIndicatorTotalAmountTo))
				{
					indicator.PordIndicatorTotalAmountTo = "0";
				}
				if (!string.IsNullOrEmpty(indicator.PordIndicatorPreOrderSaleCenterIdMulti) && indicator.PordIndicatorPreOrderSaleCenterIdMulti != "0")
				{
					indicator.PordIndicatorPreOrderSaleCenterId = indicator.PordIndicatorPreOrderSaleCenterIdMulti.Trim().Replace("|", ",").Trim();
				}
				else if (!string.IsNullOrEmpty(indicator.PordIndicatorPreOrderSaleCenterId) && indicator.PordIndicatorPreOrderSaleCenterId != "0")
				{
					indicator.PordIndicatorPreOrderSaleCenterId = indicator.PordIndicatorPreOrderSaleCenterId.Trim().Replace("|", ",").Trim();
				}
				indicator.PordIndicatorHaveLinkAcc = (string.IsNullOrEmpty(indicator.PordIndicatorHaveLinkAcc) ? "0" : indicator.PordIndicatorHaveLinkAcc);
				indicator.PordIndicatorPrdColorId = (string.IsNullOrWhiteSpace(indicator.PordIndicatorPrdColorId) ? "0" : indicator.PordIndicatorPrdColorId);
				indicator.PordIndicatorPrdSize = (string.IsNullOrWhiteSpace(indicator.PordIndicatorPrdSize) ? "" : indicator.PordIndicatorPrdSize);
				indicator.PordIndicatorPrdDesign = (string.IsNullOrWhiteSpace(indicator.PordIndicatorPrdDesign) ? "" : indicator.PordIndicatorPrdDesign);
				if (!string.IsNullOrWhiteSpace(indicator.PordIndicatorStatusIdMulti) && indicator.PordIndicatorStatusIdMulti != "0")
				{
					indicator.PordIndicatorStatusId = indicator.PordIndicatorStatusIdMulti.Trim().Replace("|", ",").Trim();
				}
				if (!string.IsNullOrWhiteSpace(indicator.PordIndicatorFirstRegisterUserIdMulti) && indicator.PordIndicatorFirstRegisterUserIdMulti != "0")
				{
					indicator.PordIndicatorFirstRegisterUserId = indicator.PordIndicatorFirstRegisterUserIdMulti.Trim().Replace("|", ",").Trim();
				}
				if (!string.IsNullOrWhiteSpace(indicator.PordIndicatorReferUserIdMulti) && indicator.PordIndicatorReferUserIdMulti != "0")
				{
					indicator.PordIndicatorReferUserId = indicator.PordIndicatorReferUserIdMulti.Trim().Replace("|", ",").Trim();
				}
				if (!string.IsNullOrWhiteSpace(indicator.PordIndicatorSellerIdMulti) && indicator.PordIndicatorSellerIdMulti != "0")
				{
					indicator.PordIndicatorSellerId = indicator.PordIndicatorSellerIdMulti.Trim().Replace("|", ",").Trim();
				}
				indicator.LinkAccSettingDBId = indicator.LinkAccSettingDBId.GetValueOrDefault();
				indicator.PordIndicatorWrhsId = (string.IsNullOrWhiteSpace(indicator.PordIndicatorWrhsId) ? "0" : indicator.PordIndicatorWrhsId);
				if (!string.IsNullOrWhiteSpace(indicator.PordIndicatorWrhsIds) && indicator.PordIndicatorWrhsIds != "0")
				{
					indicator.PordIndicatorWrhsId = indicator.PordIndicatorWrhsIds.Trim().Replace("|", ",").Trim();
				}
				DayOfWeek dayOfWeek = DateTime.Now.DayOfWeek;
				DateTime value = DateTime.Now;
				DateTime value2 = DateTime.Now;
				DateTime value3 = DateTime.Now;
				if (!string.IsNullOrEmpty(indicator.PordIndicatorDate))
				{
					value = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.PordIndicatorDate.Replace("/", "")), lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.PordIndicatorFDate))
				{
					value2 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.PordIndicatorFDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.PordIndicatorTDate))
				{
					value3 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.PordIndicatorTDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				indicator.PordIndicatorFExpireDate = ((!string.IsNullOrEmpty(indicator.PordIndicatorFExpireDate)) ? indicator.PordIndicatorFExpireDate.Replace("/", "") : "");
				indicator.PordIndicatorTExpireDate = ((!string.IsNullOrEmpty(indicator.PordIndicatorTExpireDate)) ? indicator.PordIndicatorTExpireDate.Replace("/", "") : "");
				DateTime value4 = DateTime.Now;
				DateTime value5 = DateTime.Now;
				if (!string.IsNullOrEmpty(indicator.PordIndicatorFExpireDate))
				{
					value4 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.PordIndicatorFExpireDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.PordIndicatorTExpireDate))
				{
					value5 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.PordIndicatorTExpireDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				indicator.PordIndicatorFDeadlineDate = ((!string.IsNullOrEmpty(indicator.PordIndicatorFDeadlineDate)) ? indicator.PordIndicatorFDeadlineDate.Replace("/", "") : "");
				indicator.PordIndicatorTDeadlineDate = ((!string.IsNullOrEmpty(indicator.PordIndicatorTDeadlineDate)) ? indicator.PordIndicatorTDeadlineDate.Replace("/", "") : "");
				DateTime value6 = DateTime.Now;
				DateTime value7 = DateTime.Now;
				if (!string.IsNullOrEmpty(indicator.PordIndicatorFDeadlineDate))
				{
					value6 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.PordIndicatorFDeadlineDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.PordIndicatorTDeadlineDate))
				{
					value7 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.PordIndicatorTDeadlineDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				indicator.PordIndicatorFPayDocDateTemp = ((!string.IsNullOrEmpty(indicator.PordIndicatorFPayDocDateTemp)) ? indicator.PordIndicatorFPayDocDateTemp.Replace("/", "") : "");
				indicator.PordIndicatorTPayDocDateTemp = ((!string.IsNullOrEmpty(indicator.PordIndicatorTPayDocDateTemp)) ? indicator.PordIndicatorTPayDocDateTemp.Replace("/", "") : "");
				DateTime value8 = DateTime.Now;
				DateTime value9 = DateTime.Now;
				if (!string.IsNullOrEmpty(indicator.PordIndicatorFPayDocDateTemp))
				{
					value8 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.PordIndicatorFPayDocDateTemp.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.PordIndicatorTPayDocDateTemp))
				{
					value9 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.PordIndicatorTPayDocDateTemp.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.PordIndicatorFDeliveryDateStr))
				{
					indicator.PordIndicatorFDeliveryDate = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.PordIndicatorFDeliveryDateStr.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.PordIndicatorTDeliveryDateStr))
				{
					indicator.PordIndicatorTDeliveryDate = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.PordIndicatorTDeliveryDateStr.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				data = Enumerable.FirstOrDefault<mct_WSspSelectPreOrderIndicatorSum_Result>((IEnumerable<mct_WSspSelectPreOrderIndicatorSum_Result>)_db.mfi_WSspSelectPreOrderIndicatorSum(indicator.PordIndicatorDate, indicator.PordIndicatorFDate, indicator.PordIndicatorTDate, indicator.PordIndicatorMonth, indicator.PordIndicatorCompanyId, indicator.PordIndicatorPreOrderNumber, indicator.PordIndicatorStatusId, indicator.PordIndicatorFirstRegisterUserId, indicator.PordIndicatorReferUserId, indicator.PordIndicatorPrdFirstGroupId, indicator.PordIndicatorPrdSecondGroupId, indicator.PordIndicatorPrdId, indicator.PordIndicatorPreOrderOprId, indicator.PordIndicatorOtherFieldName, indicator.PordIndicatorOtherFieldValueLikely, indicator.PordIndicatorOtherFieldValue, UserLogin.CurrentUser.UserId, DateTime.Now.ToString("yyyy/MM/dd"), DefineDayeOfWeekFa(dayOfWeek.ToString()), indicator.PordIndicatorVerified, indicator.PordIndicatorHaveOrder, lCID, result, value, value2, value3, indicator.PordIndicatorVerificationWorkflowId, indicator.PordIndicatorVerificationWorkflowStepId, indicator.PordIndicatorPordDeliveryTermId, indicator.PordIndicatorPordTypeId, indicator.PordIndicatorTotalAmount, indicator.PordIndicatorTotalAmountTo, indicator.PordIndicatorSellerId, indicator.PordIndicatorPreOrderSaleCenterId, (!string.IsNullOrEmpty(indicator.PordIndicatorFExpireDate)) ? new DateTime?(value4) : null, (!string.IsNullOrEmpty(indicator.PordIndicatorTExpireDate)) ? new DateTime?(value5) : null, indicator.PordIndicatorHaveLinkAcc, indicator.PordIndicatorPrdColorId, indicator.PordIndicatorPrdSize, indicator.PordIndicatorPrdDesign, (!string.IsNullOrEmpty(indicator.PordIndicatorFDeadlineDate)) ? new DateTime?(value6) : null, (!string.IsNullOrEmpty(indicator.PordIndicatorTDeadlineDate)) ? new DateTime?(value7) : null, (!string.IsNullOrEmpty(indicator.PordIndicatorFPayDocDateTemp)) ? new DateTime?(value8) : null, (!string.IsNullOrEmpty(indicator.PordIndicatorTPayDocDateTemp)) ? new DateTime?(value9) : null, indicator.LinkAccSettingDBId, indicator.PordIndicatorWrhsId, result2, indicator.PordIndicatorFDeliveryDate, indicator.PordIndicatorTDeliveryDate, indicator.PordIndicatorFDeliveryTime, indicator.PordIndicatorTDeliveryTime, indicator.PordIndicatorPrdSpecsJson, indicator.PordCurrencyUnitId));
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
	public string PreOrderGroupVerify()
	{
		string text = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmPreOrderIndicator", "actPreOrderGroupVerify", currentUser))
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
			string userID = currentUser.UserId.ToString();
			string registerDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			List<WSspSelectPreOrderIndicatorByDBTempInfo_Result> list = Enumerable.ToList<WSspSelectPreOrderIndicatorByDBTempInfo_Result>((IEnumerable<WSspSelectPreOrderIndicatorByDBTempInfo_Result>)_dbII.WSspSelectPreOrderIndicatorByDBTempInfo(currentUser.UserId, lCID, result));
			if (list != null && Enumerable.Any<WSspSelectPreOrderIndicatorByDBTempInfo_Result>((IEnumerable<WSspSelectPreOrderIndicatorByDBTempInfo_Result>)list))
			{
				foreach (WSspSelectPreOrderIndicatorByDBTempInfo_Result item in list)
				{
					int preOrderID = item.PreOrderID;
					string txt = string.Format(Labels.lblPordByNum, item.pordNumber.ToString());
					string text2 = PreOrder.CheckBeforeVerification(preOrderID, txt, 2);
					if (!string.IsNullOrWhiteSpace(text2))
					{
						return text + text2;
					}
				}
			}
			return (_db.WSspPreOrderGroupVerify(userID, registerDatePersian) >= 0) ? "1" : Messages.frmErrorMessage;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.frmErrorMessage;
		}
	}

	[AjaxOnly]
	public string PreOrderGroupVerifyExit()
	{
		string text = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmPreOrderIndicator", "actPreOrderGroupVerifyExit", currentUser))
		{
			return Messages.ErrorNotAccess;
		}
		try
		{
			string userID = currentUser.UserId.ToString();
			string registerDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			return (_db.WSspPreOrderGroupVerifyExit(userID, registerDatePersian) >= 0) ? "1" : Messages.frmErrorMessage;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.frmErrorMessage;
		}
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
			_dbI.CRMspFillsmsTempNumberFromPreOrderIndicator(userId, firstRegisterDatePersian, appType, lCID, result);
			return "1";
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			return Messages.msgErrorRunFunction + "<br>" + ex.Message;
		}
	}

	[AjaxOnly]
	public JsonResult DeletePreOrderFromPreOrderIndicator()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel();
		try
		{
			if (!UserLogin.IsUserAccess("frmPreOrderIndicator", "actDeletePreOrder", UserLogin.CurrentUser))
			{
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = Messages.ErrorNotAccess;
				commonReturnResultViewModel.Tag = "";
				return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
			}
			_ = DateTime.Now;
			int userId = UserLogin.CurrentUser.UserId;
			_dbI.WSspDeletePreOrderFromPreOrderIndicator(userId, lCID, result);
			commonReturnResultViewModel.IsDone = true;
			commonReturnResultViewModel.Message = Messages.msgSuccessAction;
			commonReturnResultViewModel.MessageExtra = "";
			commonReturnResultViewModel.Tag = "";
		}
		catch (DbEntityValidationException e)
		{
			commonReturnResultViewModel.IsDone = false;
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
		}
		catch (Exception e2)
		{
			commonReturnResultViewModel.IsDone = false;
			ErrorSignal.FromCurrentContext().Raise(e2);
			commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
		}
		JsonResult jsonResult = Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
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

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbI.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}
}

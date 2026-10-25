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

namespace CRMIdeal.Areas.WareHouse.Controllers;

public class IndicatorController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actDocIndicator")]
	public ActionResult Index(int position = 0, int cmpId = 0, string cmpName = "")
	{
		DocIndicatorViewModel model = new DocIndicatorViewModel
		{
			DocIndicatorCompanyId = cmpId.ToString(),
			DocIndicatorCompanyName = cmpName
		};
		FillDropdownDocIndicator();
		GetWarehouse();
		return View(model);
	}

	private void FillDropdownDocIndicator()
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
			List<WSspSelectDocOpr_Result> list = Enumerable.ToList<WSspSelectDocOpr_Result>((IEnumerable<WSspSelectDocOpr_Result>)_db.WSspSelectDocOpr(lCID, result));
			List<SelectListItem> list2 = new List<SelectListItem>();
			list2.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			list2.AddRange(Enumerable.Select<WSspSelectDocOpr_Result, SelectListItem>((IEnumerable<WSspSelectDocOpr_Result>)list, (Func<WSspSelectDocOpr_Result, SelectListItem>)((WSspSelectDocOpr_Result item) => new SelectListItem
			{
				Text = item.Name,
				Value = item.DocOprID.ToString(),
				Selected = false
			})));
			base.ViewBag.DocOprList = list2;
			List<WSspSelectPreOrderReferUsers_Result> list3 = Enumerable.ToList<WSspSelectPreOrderReferUsers_Result>((IEnumerable<WSspSelectPreOrderReferUsers_Result>)_db.WSspSelectPreOrderReferUsers(UserLogin.CurrentUser.UserId, lCID, result, result2));
			List<SelectListItem> list4 = new List<SelectListItem>();
			list4.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			list4.AddRange(Enumerable.Select<WSspSelectPreOrderReferUsers_Result, SelectListItem>((IEnumerable<WSspSelectPreOrderReferUsers_Result>)list3, (Func<WSspSelectPreOrderReferUsers_Result, SelectListItem>)((WSspSelectPreOrderReferUsers_Result item) => new SelectListItem
			{
				Text = item.UserName,
				Value = item.UserId.ToString(),
				Selected = false
			})));
			base.ViewBag.UserList = list4;
			List<WSspSelectPreOrderStatus_Result> list5 = Enumerable.ToList<WSspSelectPreOrderStatus_Result>((IEnumerable<WSspSelectPreOrderStatus_Result>)_db.WSspSelectPreOrderStatus(lCID, result));
			List<SelectListItem> list6 = new List<SelectListItem>();
			list6.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			list6.AddRange(Enumerable.Select<WSspSelectPreOrderStatus_Result, SelectListItem>((IEnumerable<WSspSelectPreOrderStatus_Result>)list5, (Func<WSspSelectPreOrderStatus_Result, SelectListItem>)((WSspSelectPreOrderStatus_Result item) => new SelectListItem
			{
				Text = item.PreOrderStatus,
				Value = item.PreOrderStatusId.ToString(),
				Selected = false
			})));
			base.ViewBag.StatusList = list6;
			List<WSspSelectProductFirstGroupActiveInSale_Result> list7 = Enumerable.ToList<WSspSelectProductFirstGroupActiveInSale_Result>((IEnumerable<WSspSelectProductFirstGroupActiveInSale_Result>)_db.WSspSelectProductFirstGroupActiveInSale(lCID, result));
			List<SelectListItem> list8 = new List<SelectListItem>();
			list8.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			list8.AddRange(Enumerable.Select<WSspSelectProductFirstGroupActiveInSale_Result, SelectListItem>((IEnumerable<WSspSelectProductFirstGroupActiveInSale_Result>)list7, (Func<WSspSelectProductFirstGroupActiveInSale_Result, SelectListItem>)((WSspSelectProductFirstGroupActiveInSale_Result item) => new SelectListItem
			{
				Text = item.FGName,
				Value = item.PrdFirstGroupID.ToString(),
				Selected = false
			})));
			base.ViewBag.PrdFirstGroupList = list8;
			List<WSspSelectVerificationWorkFlowWithObjectType_Result> list9 = Enumerable.ToList<WSspSelectVerificationWorkFlowWithObjectType_Result>((IEnumerable<WSspSelectVerificationWorkFlowWithObjectType_Result>)_db.WSspSelectVerificationWorkFlowWithObjectType(10, lCID, result));
			List<SelectListItem> list10 = new List<SelectListItem>();
			list10.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			list10.AddRange(Enumerable.Select<WSspSelectVerificationWorkFlowWithObjectType_Result, SelectListItem>((IEnumerable<WSspSelectVerificationWorkFlowWithObjectType_Result>)list9, (Func<WSspSelectVerificationWorkFlowWithObjectType_Result, SelectListItem>)((WSspSelectVerificationWorkFlowWithObjectType_Result item) => new SelectListItem
			{
				Text = item.VerificationWorkFlowTitle,
				Value = item.VerificationWorkFlowId.ToString(),
				Selected = false
			})));
			base.ViewBag.VerificationWorkFlowList = list10;
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
			List<WSspSearchProducts_Result> list2 = Enumerable.ToList<WSspSearchProducts_Result>((IEnumerable<WSspSearchProducts_Result>)_db.WSspSearchProducts(value, value2, "", "", 0, 2, lCID, result, 1, 0, 0, 0, "", null));
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

	[AjaxOnly]
	public JsonResult GetCompany(string value = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspDocIndicatorSearchCompany_Result> data = new List<WSspDocIndicatorSearchCompany_Result>();
		try
		{
			data = Enumerable.ToList<WSspDocIndicatorSearchCompany_Result>((IEnumerable<WSspDocIndicatorSearchCompany_Result>)_dbII.WSspDocIndicatorSearchCompany(value, lCID, result));
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

	public List<mct_WSspDocIndicator_Result> ListDocIndicator(DocIndicatorViewModel indicator)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<mct_WSspDocIndicator_Result> list = new List<mct_WSspDocIndicator_Result>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (indicator != null)
			{
				indicator.DocIndicatorDate = ((!string.IsNullOrEmpty(indicator.DocIndicatorDate)) ? indicator.DocIndicatorDate.Replace("/", "") : "");
				indicator.DocIndicatorFDate = ((!string.IsNullOrEmpty(indicator.DocIndicatorFDate)) ? indicator.DocIndicatorFDate.Replace("/", "") : "");
				indicator.DocIndicatorTDate = ((!string.IsNullOrEmpty(indicator.DocIndicatorTDate)) ? indicator.DocIndicatorTDate.Replace("/", "") : "");
				indicator.DocIndicatorNumber = (string.IsNullOrEmpty(indicator.DocIndicatorNumber) ? "0" : indicator.DocIndicatorNumber);
				indicator.DocIndicatorOprId = (string.IsNullOrEmpty(indicator.DocIndicatorOprId) ? "0" : indicator.DocIndicatorOprId);
				indicator.DocIndicatorWhId = (string.IsNullOrEmpty(indicator.DocIndicatorWhId) ? "0" : indicator.DocIndicatorWhId);
				indicator.DocIndicatorWhIdI = (string.IsNullOrEmpty(indicator.DocIndicatorWhIdI) ? "0" : indicator.DocIndicatorWhIdI);
				indicator.DocIndicatorOrderId = (string.IsNullOrEmpty(indicator.DocIndicatorOrderId) ? "0" : indicator.DocIndicatorOrderId);
				indicator.DocIndicatorBuyOrderId = (string.IsNullOrEmpty(indicator.DocIndicatorBuyOrderId) ? "0" : indicator.DocIndicatorBuyOrderId);
				indicator.DocIndicatorFirstRegisterUserId = (string.IsNullOrEmpty(indicator.DocIndicatorFirstRegisterUserId) ? "0" : indicator.DocIndicatorFirstRegisterUserId);
				indicator.DocIndicatorPrdFirstGroupId = (string.IsNullOrEmpty(indicator.DocIndicatorPrdFirstGroupId) ? "0" : indicator.DocIndicatorPrdFirstGroupId);
				indicator.DocIndicatorPrdSecondGroupId = (string.IsNullOrEmpty(indicator.DocIndicatorPrdSecondGroupId) ? "0" : indicator.DocIndicatorPrdSecondGroupId);
				indicator.DocIndicatorPrdId = (string.IsNullOrEmpty(indicator.DocIndicatorPrdId) ? "0" : indicator.DocIndicatorPrdId);
				indicator.DocIndicatorVerificationWorkflowId = (string.IsNullOrEmpty(indicator.DocIndicatorVerificationWorkflowId) ? "0" : indicator.DocIndicatorVerificationWorkflowId);
				indicator.DocIndicatorVerificationWorkflowStepId = (string.IsNullOrEmpty(indicator.DocIndicatorVerificationWorkflowStepId) ? "0" : indicator.DocIndicatorVerificationWorkflowStepId);
				indicator.DocIndicatorOtherFieldValue = (string.IsNullOrEmpty(indicator.DocIndicatorOtherFieldValue) ? "0" : indicator.DocIndicatorOtherFieldValue);
				indicator.DocIndicatorOtherFieldName = (string.IsNullOrEmpty(indicator.DocIndicatorOtherFieldName) ? "0" : indicator.DocIndicatorOtherFieldName);
				if (indicator.DocIndicatorOtherFieldValueLikelyBoolean)
				{
					indicator.DocIndicatorOtherFieldValueLikely = "1";
				}
				else
				{
					indicator.DocIndicatorOtherFieldValueLikely = "0";
					switch (indicator.DocIndicatorOtherFieldValue)
					{
					case "#Have":
					case "#دارد":
					case "#يملك":
						indicator.DocIndicatorOtherFieldValue = "-2";
						break;
					case "#HaveNot":
					case "#ندارد":
					case "#لا يملك":
						indicator.DocIndicatorOtherFieldValue = "-1";
						break;
					}
				}
				if (indicator.DocIndicatorOtherFieldName == "0")
				{
					indicator.DocIndicatorOtherFieldValue = "0";
				}
				indicator.DocIndicatorWrhsId = (string.IsNullOrWhiteSpace(indicator.DocIndicatorWrhsId) ? "0" : indicator.DocIndicatorWrhsId);
				if (!string.IsNullOrWhiteSpace(indicator.DocIndicatorWrhsIds) && indicator.DocIndicatorWrhsIds != "0")
				{
					indicator.DocIndicatorWrhsId = indicator.DocIndicatorWrhsIds.Trim().Replace("|", ",").Trim();
				}
				indicator.DocIndicatorWhId = indicator.DocIndicatorWrhsId;
				indicator.DocIndicatorWrhsIdI = (string.IsNullOrWhiteSpace(indicator.DocIndicatorWrhsIdI) ? "0" : indicator.DocIndicatorWrhsIdI);
				if (!string.IsNullOrWhiteSpace(indicator.DocIndicatorWrhsIdsI) && indicator.DocIndicatorWrhsIdsI != "0")
				{
					indicator.DocIndicatorWrhsIdI = indicator.DocIndicatorWrhsIdsI.Trim().Replace("|", ",").Trim();
				}
				indicator.DocIndicatorWhIdI = indicator.DocIndicatorWrhsIdI;
				indicator.DocIndicatorWhId = (string.IsNullOrWhiteSpace(indicator.DocIndicatorWhId) ? "0" : indicator.DocIndicatorWhId);
				indicator.DocIndicatorWhIdI = (string.IsNullOrWhiteSpace(indicator.DocIndicatorWhIdI) ? "0" : indicator.DocIndicatorWhIdI);
				DateTime value = DateTime.Now;
				DateTime value2 = DateTime.Now;
				DateTime value3 = DateTime.Now;
				if (!string.IsNullOrEmpty(indicator.DocIndicatorDate))
				{
					value = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.DocIndicatorDate.Replace("/", "")), lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.DocIndicatorFDate))
				{
					value2 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.DocIndicatorFDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.DocIndicatorTDate))
				{
					value3 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.DocIndicatorTDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				DayOfWeek dayOfWeek = DateTime.Now.DayOfWeek;
				indicator.Tracing = ConvertCharacter.DecodeTracing(indicator.Tracing);
				list = Enumerable.ToList<mct_WSspDocIndicator_Result>((IEnumerable<mct_WSspDocIndicator_Result>)_db.mfi_WSspDocIndicator(1, (!string.IsNullOrEmpty(indicator.DocIndicatorDate)) ? new DateTime?(value) : null, (!string.IsNullOrEmpty(indicator.DocIndicatorFDate)) ? new DateTime?(value2) : null, (!string.IsNullOrEmpty(indicator.DocIndicatorTDate)) ? new DateTime?(value3) : null, indicator.DocIndicatorNumber, indicator.DocIndicatorCompanyId, indicator.DocIndicatorOprId, indicator.DocIndicatorWhId, indicator.DocIndicatorWhIdI, indicator.DocIndicatorOrderId, indicator.DocIndicatorBuyOrderId, indicator.DocIndicatorFirstRegisterUserId, indicator.DocIndicatorPrdFirstGroupId, indicator.DocIndicatorPrdSecondGroupId, indicator.DocIndicatorPrdId, indicator.DocIndicatorVerificationWorkflowId, indicator.DocIndicatorVerificationWorkflowStepId, indicator.DocIndicatorOtherFieldName, indicator.DocIndicatorOtherFieldValueLikely, indicator.DocIndicatorOtherFieldValue, lCID, result, UserLogin.CurrentUser.UserId, DateTime.Now.ToString("yyyy/MM/dd"), DefineDayeOfWeekFa(dayOfWeek.ToString()), indicator.Tracing, result2));
			}
			foreach (mct_WSspDocIndicator_Result item in list)
			{
				if (lCID != 1065 && !string.IsNullOrEmpty(item.DocDate))
				{
					item.DocDate = PersianDate.GetShamsi2Miladi(item.DocDate.Replace("/", "")).Replace("/", "");
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
	public ActionResult DocIndicator_Read([DataSourceRequest] DataSourceRequest request, string indicator)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		DocIndicatorViewModel indicator2 = new JavaScriptSerializer().Deserialize<DocIndicatorViewModel>(indicator);
		JsonResult jsonResult = Json(((IEnumerable)ListDocIndicator(indicator2)).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult DocIndicator(DocIndicatorViewModel indicator)
	{
		return Json(ListDocIndicator(indicator), JsonRequestBehavior.AllowGet);
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}
}

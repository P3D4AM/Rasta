using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
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

namespace CRMIdeal.Areas.StockSupply.Controllers;

public class IndicatorController : Controller
{
	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[LoginAuthorize]
	public ActionResult Index(int position = 0, int cmpId = 0, string cmpName = "")
	{
		string text = "";
		string text2 = "";
		if (position == 0)
		{
			text = "frmMain";
			text2 = "actstsupStockSupplyIndicator";
			if (!UserLogin.IsUserAccess(text, text2, UserLogin.CurrentUser))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			StockSupplyIndicatorViewModel model = new StockSupplyIndicatorViewModel
			{
				StsupIndicatorCompanyId = cmpId.ToString(),
				StsupIndicatorCompanyName = cmpName
			};
			GetStsupReferUser();
			GetWarehouse();
			GetVerificationWorkFlow();
			return View(model);
		}
		return RedirectToAction("Login", "Account", (object)new
		{
			area = "",
			d = DateTime.Now
		});
	}

	[AjaxOnly]
	public JsonResult GetStsupReferUser()
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
			_ = Configuration.MaxCountOfOnlineUser;
			List<WSspSelectStockSupplyReferUsers_Result> list2 = Enumerable.ToList<WSspSelectStockSupplyReferUsers_Result>((IEnumerable<WSspSelectStockSupplyReferUsers_Result>)_dbII.WSspSelectStockSupplyReferUsers(UserLogin.CurrentUser.UserId, lCID, result));
			list.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			list.AddRange(Enumerable.Select<WSspSelectStockSupplyReferUsers_Result, SelectListItem>((IEnumerable<WSspSelectStockSupplyReferUsers_Result>)list2, (Func<WSspSelectStockSupplyReferUsers_Result, SelectListItem>)((WSspSelectStockSupplyReferUsers_Result item) => new SelectListItem
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
		base.ViewBag.ReferUserList = list;
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
			_ = Configuration.MaxCountOfOnlineUser;
			List<WSspSelectWareHouse_Result> list2 = CRMIdeal.Classes.Helper.Warehouse.SelectWareHouse();
			list.AddRange(Enumerable.Select<WSspSelectWareHouse_Result, SelectListItem>((IEnumerable<WSspSelectWareHouse_Result>)list2, (Func<WSspSelectWareHouse_Result, SelectListItem>)((WSspSelectWareHouse_Result item) => new SelectListItem
			{
				Text = item.WrhsName,
				Value = item.WareHouseID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.WarehouseList = list;
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
			List<WSspSelectVerificationWorkFlowWithObjectType_Result> list2 = Enumerable.ToList<WSspSelectVerificationWorkFlowWithObjectType_Result>((IEnumerable<WSspSelectVerificationWorkFlowWithObjectType_Result>)_db.WSspSelectVerificationWorkFlowWithObjectType(45, lCID, result));
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
	public JsonResult GetCompany(string value = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspStockSupplyIndicatorSearchCompany_Result> list = new List<WSspStockSupplyIndicatorSearchCompany_Result>();
		try
		{
			list = Enumerable.ToList<WSspStockSupplyIndicatorSearchCompany_Result>((IEnumerable<WSspStockSupplyIndicatorSearchCompany_Result>)_dbII.WSspStockSupplyIndicatorSearchCompany(value, lCID, result));
			if (list == null)
			{
				list = new List<WSspStockSupplyIndicatorSearchCompany_Result>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
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
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<WSspSelectStockSupplyIndicator_Result> ListStockSupplyIndicator(StockSupplyIndicatorViewModel indicator)
	{
		//IL_06ac: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectStockSupplyIndicator_Result> list = new List<WSspSelectStockSupplyIndicator_Result>();
		try
		{
			if (indicator != null)
			{
				indicator.StsupIndicatorDate = ((!string.IsNullOrWhiteSpace(indicator.StsupIndicatorDate)) ? indicator.StsupIndicatorDate.Replace("/", "") : "");
				indicator.StsupIndicatorFDate = ((!string.IsNullOrWhiteSpace(indicator.StsupIndicatorFDate)) ? indicator.StsupIndicatorFDate.Replace("/", "") : "");
				indicator.StsupIndicatorTDate = ((!string.IsNullOrWhiteSpace(indicator.StsupIndicatorTDate)) ? indicator.StsupIndicatorTDate.Replace("/", "") : "");
				indicator.StsupIndicatorCompanyId = (string.IsNullOrWhiteSpace(indicator.StsupIndicatorCompanyId) ? "0" : indicator.StsupIndicatorCompanyId);
				indicator.StsupIndicatorStsupNumber = (string.IsNullOrWhiteSpace(indicator.StsupIndicatorStsupNumber) ? "0" : indicator.StsupIndicatorStsupNumber);
				indicator.StsupIndicatorReferUserId = (string.IsNullOrWhiteSpace(indicator.StsupIndicatorReferUserId) ? "0" : indicator.StsupIndicatorReferUserId);
				indicator.StsupIndicatorWhId = (string.IsNullOrWhiteSpace(indicator.StsupIndicatorWhId) ? "0" : indicator.StsupIndicatorWhId);
				indicator.StsupIndicatorPrdId = (string.IsNullOrWhiteSpace(indicator.StsupIndicatorPrdId) ? "0" : indicator.StsupIndicatorPrdId);
				indicator.StsupIndicatorPrdIdMulti = (string.IsNullOrWhiteSpace(indicator.StsupIndicatorPrdIdMulti) ? "0" : indicator.StsupIndicatorPrdIdMulti);
				if (indicator.StsupIndicatorPrdIdMulti != "0")
				{
					indicator.StsupIndicatorPrdId = indicator.StsupIndicatorPrdIdMulti.Trim().Replace("|", ",").Trim();
				}
				indicator.StsupIndicatorVerified = (string.IsNullOrWhiteSpace(indicator.StsupIndicatorVerified) ? "0" : indicator.StsupIndicatorVerified);
				indicator.StsupIndicatorVerificationWorkflowId = (string.IsNullOrWhiteSpace(indicator.StsupIndicatorVerificationWorkflowId) ? "0" : indicator.StsupIndicatorVerificationWorkflowId);
				indicator.StsupIndicatorVerificationWorkflowStepId = (string.IsNullOrWhiteSpace(indicator.StsupIndicatorVerificationWorkflowStepId) ? "0" : indicator.StsupIndicatorVerificationWorkflowStepId);
				indicator.StsupIndicatorCanceled = (string.IsNullOrWhiteSpace(indicator.StsupIndicatorCanceled) ? "0" : indicator.StsupIndicatorCanceled);
				indicator.StsupIndicatorSupplyStatus = (string.IsNullOrWhiteSpace(indicator.StsupIndicatorSupplyStatus) ? "0" : indicator.StsupIndicatorSupplyStatus);
				indicator.StsupIndicatorOtherFieldValue = (string.IsNullOrWhiteSpace(indicator.StsupIndicatorOtherFieldValue) ? "0" : indicator.StsupIndicatorOtherFieldValue);
				indicator.StsupIndicatorOtherFieldName = (string.IsNullOrWhiteSpace(indicator.StsupIndicatorOtherFieldName) ? "0" : indicator.StsupIndicatorOtherFieldName);
				if (indicator.StsupIndicatorOtherFieldValueLikelyBoolean)
				{
					indicator.StsupIndicatorOtherFieldValueLikely = "1";
				}
				else
				{
					indicator.StsupIndicatorOtherFieldValueLikely = "0";
					switch (indicator.StsupIndicatorOtherFieldValue)
					{
					case "#Have":
					case "#دارد":
					case "#يملك":
					case "#hat es":
						indicator.StsupIndicatorOtherFieldValue = "-2";
						break;
					case "#HaveNot":
					case "#لا يملك":
					case "#ندارد":
					case "#hat nicht":
						indicator.StsupIndicatorOtherFieldValue = "-1";
						break;
					}
				}
				if (indicator.StsupIndicatorOtherFieldName == "0")
				{
					indicator.StsupIndicatorOtherFieldValue = "0";
				}
				DateTime value = DateTime.Now;
				DateTime value2 = DateTime.Now;
				DateTime value3 = DateTime.Now;
				if (!string.IsNullOrWhiteSpace(indicator.StsupIndicatorDate))
				{
					value = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.StsupIndicatorDate.Replace("/", "")), lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrWhiteSpace(indicator.StsupIndicatorFDate))
				{
					value2 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.StsupIndicatorFDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrWhiteSpace(indicator.StsupIndicatorTDate))
				{
					value3 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.StsupIndicatorTDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				DateTime now = DateTime.Now;
				string rptDay = DateTimeClass.DefineDayeOfWeekFa(now.DayOfWeek.ToString());
				int userId = UserLogin.CurrentUser.UserId;
				string rptDate = now.ToString("yyyy/MM/dd");
				list = Enumerable.ToList<WSspSelectStockSupplyIndicator_Result>((IEnumerable<WSspSelectStockSupplyIndicator_Result>)_dbII.WSspSelectStockSupplyIndicator((!string.IsNullOrWhiteSpace(indicator.StsupIndicatorDate)) ? new DateTime?(value) : null, (!string.IsNullOrWhiteSpace(indicator.StsupIndicatorFDate)) ? new DateTime?(value2) : null, (!string.IsNullOrWhiteSpace(indicator.StsupIndicatorTDate)) ? new DateTime?(value3) : null, indicator.StsupIndicatorCompanyId, indicator.StsupIndicatorStsupNumber, indicator.StsupIndicatorReferUserId, indicator.StsupIndicatorWhId, indicator.StsupIndicatorPrdId, indicator.StsupIndicatorVerified, indicator.StsupIndicatorVerificationWorkflowId, indicator.StsupIndicatorVerificationWorkflowStepId, indicator.StsupIndicatorCanceled, indicator.StsupIndicatorSupplyStatus, indicator.StsupIndicatorOtherFieldName, indicator.StsupIndicatorOtherFieldValueLikely, indicator.StsupIndicatorOtherFieldValue, userId, rptDate, rptDay, lCID, result));
				if (list != null)
				{
					if (Enumerable.Any<WSspSelectStockSupplyIndicator_Result>((IEnumerable<WSspSelectStockSupplyIndicator_Result>)list))
					{
						foreach (WSspSelectStockSupplyIndicator_Result item in list)
						{
							if (string.IsNullOrWhiteSpace(item.stsupIBuyOrders))
							{
								continue;
							}
							List<StockSupplyItemsBuyOrdersViewModel> list2 = new JavaScriptSerializer().Deserialize<List<StockSupplyItemsBuyOrdersViewModel>>(item.stsupIBuyOrders);
							if (list2 == null)
							{
								continue;
							}
							if (Enumerable.Any<StockSupplyItemsBuyOrdersViewModel>((IEnumerable<StockSupplyItemsBuyOrdersViewModel>)list2))
							{
								foreach (StockSupplyItemsBuyOrdersViewModel item2 in list2)
								{
									item2.bordDate = (item2.bordDateTime.HasValue ? item2.bordDateTime.Value.ToString("yyyy/MM/dd") : "");
								}
							}
							item.stsupIBuyOrders = JsonConvert.SerializeObject(Enumerable.ToList<StockSupplyItemsBuyOrdersViewModel>((IEnumerable<StockSupplyItemsBuyOrdersViewModel>)list2));
						}
					}
				}
				else
				{
					list = new List<WSspSelectStockSupplyIndicator_Result>();
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
	public ActionResult StockSupplyIndicator_Read([DataSourceRequest] DataSourceRequest request, string indicator)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		StockSupplyIndicatorViewModel indicator2 = new JavaScriptSerializer().Deserialize<StockSupplyIndicatorViewModel>(indicator);
		JsonResult jsonResult = Json(((IEnumerable)ListStockSupplyIndicator(indicator2)).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult StockSupplyIndicator(StockSupplyIndicatorViewModel indicator)
	{
		JsonResult jsonResult = Json(ListStockSupplyIndicator(indicator), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult IndicatorUpdateFooter(StockSupplyIndicatorViewModel indicator)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		WSspSelectStockSupplyIndicatorSum_Result wSspSelectStockSupplyIndicatorSum_Result = new WSspSelectStockSupplyIndicatorSum_Result();
		try
		{
			if (indicator != null)
			{
				indicator.StsupIndicatorDate = ((!string.IsNullOrWhiteSpace(indicator.StsupIndicatorDate)) ? indicator.StsupIndicatorDate.Replace("/", "") : "");
				indicator.StsupIndicatorFDate = ((!string.IsNullOrWhiteSpace(indicator.StsupIndicatorFDate)) ? indicator.StsupIndicatorFDate.Replace("/", "") : "");
				indicator.StsupIndicatorTDate = ((!string.IsNullOrWhiteSpace(indicator.StsupIndicatorTDate)) ? indicator.StsupIndicatorTDate.Replace("/", "") : "");
				indicator.StsupIndicatorCompanyId = (string.IsNullOrWhiteSpace(indicator.StsupIndicatorCompanyId) ? "0" : indicator.StsupIndicatorCompanyId);
				indicator.StsupIndicatorStsupNumber = (string.IsNullOrWhiteSpace(indicator.StsupIndicatorStsupNumber) ? "0" : indicator.StsupIndicatorStsupNumber);
				indicator.StsupIndicatorReferUserId = (string.IsNullOrWhiteSpace(indicator.StsupIndicatorReferUserId) ? "0" : indicator.StsupIndicatorReferUserId);
				indicator.StsupIndicatorWhId = (string.IsNullOrWhiteSpace(indicator.StsupIndicatorWhId) ? "0" : indicator.StsupIndicatorWhId);
				indicator.StsupIndicatorPrdId = (string.IsNullOrWhiteSpace(indicator.StsupIndicatorPrdId) ? "0" : indicator.StsupIndicatorPrdId);
				indicator.StsupIndicatorPrdIdMulti = (string.IsNullOrWhiteSpace(indicator.StsupIndicatorPrdIdMulti) ? "0" : indicator.StsupIndicatorPrdIdMulti);
				if (indicator.StsupIndicatorPrdIdMulti != "0")
				{
					indicator.StsupIndicatorPrdId = indicator.StsupIndicatorPrdIdMulti.Trim().Replace("|", ",").Trim();
				}
				indicator.StsupIndicatorVerified = (string.IsNullOrWhiteSpace(indicator.StsupIndicatorVerified) ? "0" : indicator.StsupIndicatorVerified);
				indicator.StsupIndicatorVerificationWorkflowId = (string.IsNullOrWhiteSpace(indicator.StsupIndicatorVerificationWorkflowId) ? "0" : indicator.StsupIndicatorVerificationWorkflowId);
				indicator.StsupIndicatorVerificationWorkflowStepId = (string.IsNullOrWhiteSpace(indicator.StsupIndicatorVerificationWorkflowStepId) ? "0" : indicator.StsupIndicatorVerificationWorkflowStepId);
				indicator.StsupIndicatorCanceled = (string.IsNullOrWhiteSpace(indicator.StsupIndicatorCanceled) ? "0" : indicator.StsupIndicatorCanceled);
				indicator.StsupIndicatorSupplyStatus = (string.IsNullOrWhiteSpace(indicator.StsupIndicatorSupplyStatus) ? "0" : indicator.StsupIndicatorSupplyStatus);
				indicator.StsupIndicatorOtherFieldValue = (string.IsNullOrWhiteSpace(indicator.StsupIndicatorOtherFieldValue) ? "0" : indicator.StsupIndicatorOtherFieldValue);
				indicator.StsupIndicatorOtherFieldName = (string.IsNullOrWhiteSpace(indicator.StsupIndicatorOtherFieldName) ? "0" : indicator.StsupIndicatorOtherFieldName);
				if (indicator.StsupIndicatorOtherFieldValueLikelyBoolean)
				{
					indicator.StsupIndicatorOtherFieldValueLikely = "1";
				}
				else
				{
					indicator.StsupIndicatorOtherFieldValueLikely = "0";
					switch (indicator.StsupIndicatorOtherFieldValue)
					{
					case "#Have":
					case "#دارد":
					case "#يملك":
					case "#hat es":
						indicator.StsupIndicatorOtherFieldValue = "-2";
						break;
					case "#HaveNot":
					case "#لا يملك":
					case "#ندارد":
					case "#hat nicht":
						indicator.StsupIndicatorOtherFieldValue = "-1";
						break;
					}
				}
				if (indicator.StsupIndicatorOtherFieldName == "0")
				{
					indicator.StsupIndicatorOtherFieldValue = "0";
				}
				DateTime value = DateTime.Now;
				DateTime value2 = DateTime.Now;
				DateTime value3 = DateTime.Now;
				if (!string.IsNullOrWhiteSpace(indicator.StsupIndicatorDate))
				{
					value = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.StsupIndicatorDate.Replace("/", "")), lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrWhiteSpace(indicator.StsupIndicatorFDate))
				{
					value2 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.StsupIndicatorFDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrWhiteSpace(indicator.StsupIndicatorTDate))
				{
					value3 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.StsupIndicatorTDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				DateTime now = DateTime.Now;
				string rptDay = DateTimeClass.DefineDayeOfWeekFa(now.DayOfWeek.ToString());
				int userId = UserLogin.CurrentUser.UserId;
				string rptDate = now.ToString("yyyy/MM/dd");
				wSspSelectStockSupplyIndicatorSum_Result = Enumerable.FirstOrDefault<WSspSelectStockSupplyIndicatorSum_Result>((IEnumerable<WSspSelectStockSupplyIndicatorSum_Result>)_dbII.WSspSelectStockSupplyIndicatorSum((!string.IsNullOrWhiteSpace(indicator.StsupIndicatorDate)) ? new DateTime?(value) : null, (!string.IsNullOrWhiteSpace(indicator.StsupIndicatorFDate)) ? new DateTime?(value2) : null, (!string.IsNullOrWhiteSpace(indicator.StsupIndicatorTDate)) ? new DateTime?(value3) : null, indicator.StsupIndicatorCompanyId, indicator.StsupIndicatorStsupNumber, indicator.StsupIndicatorReferUserId, indicator.StsupIndicatorWhId, indicator.StsupIndicatorPrdId, indicator.StsupIndicatorVerified, indicator.StsupIndicatorVerificationWorkflowId, indicator.StsupIndicatorVerificationWorkflowStepId, indicator.StsupIndicatorCanceled, indicator.StsupIndicatorSupplyStatus, indicator.StsupIndicatorOtherFieldName, indicator.StsupIndicatorOtherFieldValueLikely, indicator.StsupIndicatorOtherFieldValue, userId, rptDate, rptDay, lCID, result));
				if (wSspSelectStockSupplyIndicatorSum_Result == null)
				{
					wSspSelectStockSupplyIndicatorSum_Result = new WSspSelectStockSupplyIndicatorSum_Result();
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(wSspSelectStockSupplyIndicatorSum_Result, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmStockSupplyIndicator", ActionName = "actIssueBuyOrder")]
	public ActionResult IssueBuyOrder(string stsupItemIds, string parameters = "")
	{
		base.ViewBag.StockSupplyItemIds = stsupItemIds;
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
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			string[] array = parameters.Split(new char[1] { '|' });
			base.ViewBag.MyParameters = array;
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		base.ViewBag.IsBuying = VersionBuyer.BuyOrders;
		base.ViewBag.CmpId = num;
		base.ViewBag.PrsId = num2;
		base.ViewBag.PrjId = num3;
		base.ViewBag.CmpFullName = text;
		GetBordDefSetting();
		return View();
	}

	[AjaxOnly]
	public JsonResult GetBordDefSetting()
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
			int userId = UserLogin.CurrentUser.UserId;
			List<WSspSelectBuyOrderDefaultSettingByReferUserIdAndIsPublic_Result> list2 = Enumerable.ToList<WSspSelectBuyOrderDefaultSettingByReferUserIdAndIsPublic_Result>((IEnumerable<WSspSelectBuyOrderDefaultSettingByReferUserIdAndIsPublic_Result>)_dbII.WSspSelectBuyOrderDefaultSettingByReferUserIdAndIsPublic(userId, lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectBuyOrderDefaultSettingByReferUserIdAndIsPublic_Result, SelectListItem>((IEnumerable<WSspSelectBuyOrderDefaultSettingByReferUserIdAndIsPublic_Result>)list2, (Func<WSspSelectBuyOrderDefaultSettingByReferUserIdAndIsPublic_Result, SelectListItem>)((WSspSelectBuyOrderDefaultSettingByReferUserIdAndIsPublic_Result item) => new SelectListItem
			{
				Text = item.SettingTitle,
				Value = item.BuyOrderDefaultSettingId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.bordDefSettingList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public List<WSspSelectStockSupplyItemsWithBordItemQuantityByItemIds_Result> GetStockSupplyItems(string stsupItemIds, int cmpId = 0, bool addAllPrd = false)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectStockSupplyItemsWithBordItemQuantityByItemIds_Result> list = new List<WSspSelectStockSupplyItemsWithBordItemQuantityByItemIds_Result>();
		try
		{
			if (stsupItemIds != "")
			{
				List<WSspSelectStockSupplyItemsWithBordItemQuantityByItemIds_Result> list2 = Enumerable.ToList<WSspSelectStockSupplyItemsWithBordItemQuantityByItemIds_Result>((IEnumerable<WSspSelectStockSupplyItemsWithBordItemQuantityByItemIds_Result>)_dbII.WSspSelectStockSupplyItemsWithBordItemQuantityByItemIds(stsupItemIds, lCID, result));
				if (list2 != null && Enumerable.Any<WSspSelectStockSupplyItemsWithBordItemQuantityByItemIds_Result>((IEnumerable<WSspSelectStockSupplyItemsWithBordItemQuantityByItemIds_Result>)list2))
				{
					new List<ReturnPrdQuantityViewModel>();
					foreach (WSspSelectStockSupplyItemsWithBordItemQuantityByItemIds_Result item in list2)
					{
						item.stsupIRemainedQuantity = item.stsupIQuantity - item.BuyOrderItemQuantity.GetValueOrDefault();
						if (addAllPrd)
						{
							list.Add(item);
						}
						else if (item.stsupIRemainedQuantity > 0.0)
						{
							list.Add(item);
						}
					}
				}
				if (list == null)
				{
					list = new List<WSspSelectStockSupplyItemsWithBordItemQuantityByItemIds_Result>();
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public ActionResult _PartialStockSupplyItems(string stsupItemIds, int cmpId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectStockSupplyItemsWithBordItemQuantityByItemIds_Result> list = new List<WSspSelectStockSupplyItemsWithBordItemQuantityByItemIds_Result>();
		GetProductCostGroup();
		try
		{
			list = GetStockSupplyItems(stsupItemIds, cmpId);
			if (list == null)
			{
				list = new List<WSspSelectStockSupplyItemsWithBordItemQuantityByItemIds_Result>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView(list);
	}

	[AjaxOnly]
	public string ActIssueBuyOrder(string stsupItemIds, int cmpId, int prsId, int prjId, string dateSelect, string valDetails, int bordDefSettingId = 0)
	{
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		string result = "-1";
		if (!string.IsNullOrWhiteSpace(stsupItemIds))
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
				if (!VersionBuyer.BuyOrders)
				{
					DbSet<WSBuyOrder> wSBuyOrder = _dbTbl.WSBuyOrder;
					ParameterExpression val = Expression.Parameter(typeof(WSBuyOrder), "c");
					if (Queryable.Any<WSBuyOrder>((IQueryable<WSBuyOrder>)wSBuyOrder, Expression.Lambda<Func<WSBuyOrder, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)10, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val })))
					{
						return "BV|" + Messages.VersionBuy;
					}
				}
				List<StockSupplyIdKeyValueViewModel> list = new List<StockSupplyIdKeyValueViewModel>();
				if (!string.IsNullOrEmpty(valDetails))
				{
					list = new JavaScriptSerializer().Deserialize<List<StockSupplyIdKeyValueViewModel>>(valDetails);
				}
				string text = "";
				List<StockSupplyIdKeyValueDblViewModel> list2 = new List<StockSupplyIdKeyValueDblViewModel>();
				string stsupItemList = "";
				if (Enumerable.Any<StockSupplyIdKeyValueViewModel>((IEnumerable<StockSupplyIdKeyValueViewModel>)list))
				{
					foreach (StockSupplyIdKeyValueViewModel item2 in list)
					{
						string id = item2.Id;
						_ = item2.Type;
						_ = item2.Tag;
						string value = item2.Value;
						int result3 = 0;
						int.TryParse(id, out result3);
						double result4 = 0.0;
						double.TryParse(value, out result4);
						decimal result5 = default(decimal);
						int result6 = 0;
						decimal.TryParse(item2.Cost, out result5);
						int.TryParse(item2.CostGroupId, out result6);
						double result7 = 0.0;
						double.TryParse(item2.PriceCurrencyRate.ToString(), out result7);
						if (result4 > 0.0)
						{
							text = text + result3 + "," + result4 + "|";
							StockSupplyIdKeyValueDblViewModel item = new StockSupplyIdKeyValueDblViewModel
							{
								Id = result3,
								Value = result4,
								Cost = result5,
								CostGroupId = ((result6 != 0) ? new int?(result6) : null),
								PriceCurrencyRate = result7
							};
							list2.Add(item);
						}
					}
				}
				if (list2 != null && Enumerable.Any<StockSupplyIdKeyValueDblViewModel>((IEnumerable<StockSupplyIdKeyValueDblViewModel>)list2))
				{
					stsupItemList = JsonConvert.SerializeObject(Enumerable.ToList<StockSupplyIdKeyValueDblViewModel>((IEnumerable<StockSupplyIdKeyValueDblViewModel>)list2));
				}
				List<WSspSelectStockSupplyCanceledByItemIds_Result> list3 = Enumerable.ToList<WSspSelectStockSupplyCanceledByItemIds_Result>((IEnumerable<WSspSelectStockSupplyCanceledByItemIds_Result>)_dbII.WSspSelectStockSupplyCanceledByItemIds(stsupItemIds, lCID, result2));
				if (list3 != null && Enumerable.Any<WSspSelectStockSupplyCanceledByItemIds_Result>((IEnumerable<WSspSelectStockSupplyCanceledByItemIds_Result>)list3))
				{
					result = "MOJ|" + Messages.msgErrorIssueBuyOrderForCanceledStsupInIndicator;
					foreach (WSspSelectStockSupplyCanceledByItemIds_Result item3 in list3)
					{
						result = result + "<br>" + string.Format(Labels.IssueBuyOrderFromStsupIndicatorByNumber, item3.stsupNumber.ToString());
					}
					return result;
				}
				List<WSspSelectStockSupplyIsNotVerifiedByItemIds_Result> list4 = Enumerable.ToList<WSspSelectStockSupplyIsNotVerifiedByItemIds_Result>((IEnumerable<WSspSelectStockSupplyIsNotVerifiedByItemIds_Result>)_dbII.WSspSelectStockSupplyIsNotVerifiedByItemIds(stsupItemIds, lCID, result2));
				if (list4 != null && Enumerable.Any<WSspSelectStockSupplyIsNotVerifiedByItemIds_Result>((IEnumerable<WSspSelectStockSupplyIsNotVerifiedByItemIds_Result>)list4))
				{
					result = "MOJ|" + Messages.msgErrorIssueBuyOrderForIsNotVerifiedStsupInIndicator;
					foreach (WSspSelectStockSupplyIsNotVerifiedByItemIds_Result item4 in list4)
					{
						result = result + "<br>" + string.Format(Labels.IssueBuyOrderFromStsupIndicatorByNumber, item4.stsupNumber.ToString());
					}
					return result;
				}
				result = Messages.msgErrorNotFindBuyOrderForStockSuppply;
				mct_II_Result mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.WSspCheckStockSupplyHaveBuyOrderByItemIds(stsupItemIds));
				int result8 = 0;
				if (mct_II_Result != null)
				{
					int.TryParse(mct_II_Result.Result.ToString(), out result8);
				}
				if (result8 == 1)
				{
					result = "1|" + Messages.msgErrorBuyOrderIssuedForStockSupplyInIndicator + "|0|0";
				}
				else
				{
					List<WSspSelectStockSupplyItemsWithBordItemQuantityByItemIds_Result> stockSupplyItems = GetStockSupplyItems(stsupItemIds, cmpId);
					if (stockSupplyItems != null && list != null && Enumerable.Any<WSspSelectStockSupplyItemsWithBordItemQuantityByItemIds_Result>((IEnumerable<WSspSelectStockSupplyItemsWithBordItemQuantityByItemIds_Result>)stockSupplyItems) && Enumerable.Any<StockSupplyIdKeyValueViewModel>((IEnumerable<StockSupplyIdKeyValueViewModel>)list))
					{
						foreach (StockSupplyIdKeyValueViewModel item5 in list)
						{
							string id2 = item5.Id;
							_ = item5.Type;
							_ = item5.Tag;
							string value2 = item5.Value;
							int objId = 0;
							int.TryParse(id2, out objId);
							double result9 = 0.0;
							double.TryParse(value2, out result9);
							WSspSelectStockSupplyItemsWithBordItemQuantityByItemIds_Result wSspSelectStockSupplyItemsWithBordItemQuantityByItemIds_Result = Enumerable.FirstOrDefault<WSspSelectStockSupplyItemsWithBordItemQuantityByItemIds_Result>((IEnumerable<WSspSelectStockSupplyItemsWithBordItemQuantityByItemIds_Result>)stockSupplyItems, (Func<WSspSelectStockSupplyItemsWithBordItemQuantityByItemIds_Result, bool>)((WSspSelectStockSupplyItemsWithBordItemQuantityByItemIds_Result m) => m.StockSupplyItemId == objId));
							if (wSspSelectStockSupplyItemsWithBordItemQuantityByItemIds_Result != null && result9 != 0.0 && wSspSelectStockSupplyItemsWithBordItemQuantityByItemIds_Result.stsupIRemainedQuantity.GetValueOrDefault() <= 0.0)
							{
								return "MOJ|" + Messages.msgErrorImpossibilityIssueBuyOrderFormStockSupply + "\r\n" + Messages.msgErrorIssueBuyOrderFormStockSupplyHaveInventory + "\r\n" + wSspSelectStockSupplyItemsWithBordItemQuantityByItemIds_Result.PrdName;
							}
						}
					}
					if (dateSelect != null)
					{
						dateSelect = dateSelect.Replace("/", "").Replace("-", "").Replace("_", "")
							.Replace(".", "")
							.Replace(",", "")
							.Replace("\\", "");
					}
					string bordDate = "";
					DateTime value3 = default(DateTime);
					DateTime dateTime = default(DateTime);
					string text2 = "";
					try
					{
						if (!string.IsNullOrEmpty(dateSelect))
						{
							text2 = PersianDate.GetFormatetdDate(dateSelect.Replace("/", ""));
							switch (lCID)
							{
							case 1065:
								dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
								bordDate = dateTime.ToString("yyyyMMdd");
								break;
							case 1025:
								dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
								bordDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							default:
								dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
								bordDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							}
							value3 = dateTime;
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						result = "-1";
					}
					DateTime now = DateTime.Now;
					DateTime value4 = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value5 = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					short.Parse(now.ToString("yyyy", new PersianCulture()));
					int userId = UserLogin.CurrentUser.UserId;
					int id3 = Financial.Get().Id;
					ObjectParameter objectParameter = new ObjectParameter("InsertedBuyOrderId", 0);
					ObjectParameter objectParameter2 = new ObjectParameter("InsertedBordNumber", typeof(long));
					mct_II_Result mct_II_Result2 = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.WSspIssueBuyOrderFromStockSupplyIndicator(bordDate, value3, stsupItemList, cmpId, prsId, prjId, bordDefSettingId, userId, value5, id3, value4, registerDatePersian, appType, lCID, result2, objectParameter, objectParameter2, centerId));
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
							-2 => string.Format(Messages.msgErrorIsNotSelectedItem, Labels.lblPrdI), 
							-1 => Messages.msgErrorBuyOrderIssuedForStockSupplyInIndicator, 
							_ => Messages.msgErrorRunFunction, 
						};
					}
					result = ((result11 <= 0) ? Messages.msgErrorRunFunction : ("2|" + result11 + "|" + result12 + "|1"));
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
	public JsonResult GetProductCostGroup()
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
			List<WSspSelectProductCostGroup_Result> list2 = Enumerable.ToList<WSspSelectProductCostGroup_Result>((IEnumerable<WSspSelectProductCostGroup_Result>)_db.WSspSelectProductCostGroup(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectProductCostGroup_Result, SelectListItem>((IEnumerable<WSspSelectProductCostGroup_Result>)list2, (Func<WSspSelectProductCostGroup_Result, SelectListItem>)((WSspSelectProductCostGroup_Result item) => new SelectListItem
			{
				Text = item.ProductCostGroupName,
				Value = item.ProductCostGroupID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ProductCostGroupList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	protected override void Dispose(bool disposing)
	{
		_dbTbl.Dispose();
		_db.Dispose();
		_dbI.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Calendar;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace CRMIdeal.Areas.Reports.Controllers;

public class ParadoxReportsController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actrptParadox")]
	public ActionResult Index()
	{
		ParadoxReportsViewModel paradoxReportsViewModel = new ParadoxReportsViewModel();
		DateTime now = DateTime.Now;
		string ordToDate = (paradoxReportsViewModel.DocToDate = now.ToString("yyyy/MM/dd"));
		paradoxReportsViewModel.OrdToDate = ordToDate;
		ordToDate = (paradoxReportsViewModel.DocFromDate = now.ToString("yyyy/01/01"));
		paradoxReportsViewModel.OrdFromDate = ordToDate;
		return View(paradoxReportsViewModel);
	}

	public ActionResult OrdSearch_Read([DataSourceRequest] DataSourceRequest request, string modelObj)
	{
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		List<WSfnRpt_ParadoxOrderViewModel> list = new List<WSfnRpt_ParadoxOrderViewModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
			int value = 0;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
				value = UserLogin.CurrentUser.UserId;
			}
			ParadoxReportsViewModel paradoxReportsViewModel = new JavaScriptSerializer().Deserialize<ParadoxReportsViewModel>(modelObj);
			paradoxReportsViewModel.OrdFromDate = paradoxReportsViewModel.OrdFromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
				.Replace(" ", "")
				.Replace("_", "");
			paradoxReportsViewModel.OrdToDate = paradoxReportsViewModel.OrdToDate.Replace("/", "").Replace("-", "").Replace("\\", "")
				.Replace(" ", "")
				.Replace("_", "");
			DateTime value2 = DateTime.Now;
			DateTime value3 = DateTime.Now;
			if (!string.IsNullOrEmpty(paradoxReportsViewModel.OrdFromDate))
			{
				value2 = DateTime.Parse(PersianDate.GetFormatetdDate(paradoxReportsViewModel.OrdFromDate.Replace("/", "")) + " 00:00:00", (currLangID == 1065) ? new PersianCulture() : ((currLangID == 1025) ? new CultureInfo("ar-SA") : new CultureInfo("en-US")));
			}
			if (!string.IsNullOrEmpty(paradoxReportsViewModel.OrdToDate))
			{
				value3 = DateTime.Parse(PersianDate.GetFormatetdDate(paradoxReportsViewModel.OrdToDate.Replace("/", "")) + " 23:59:59", (currLangID == 1065) ? new PersianCulture() : ((currLangID == 1025) ? new CultureInfo("ar-SA") : new CultureInfo("en-US")));
			}
			switch (paradoxReportsViewModel.OrdReportId)
			{
			case 1:
			{
				List<WSspRpt_ParadoxOrderHaveNotDraft_Result> list6 = Enumerable.ToList<WSspRpt_ParadoxOrderHaveNotDraft_Result>((IEnumerable<WSspRpt_ParadoxOrderHaveNotDraft_Result>)_db.WSspRpt_ParadoxOrderHaveNotDraft(paradoxReportsViewModel.OrdFromDate, paradoxReportsViewModel.OrdToDate, value2, value3, currLangID, result, result2, value));
				list.AddRange(Enumerable.Select<WSspRpt_ParadoxOrderHaveNotDraft_Result, WSfnRpt_ParadoxOrderViewModel>((IEnumerable<WSspRpt_ParadoxOrderHaveNotDraft_Result>)list6, (Func<WSspRpt_ParadoxOrderHaveNotDraft_Result, WSfnRpt_ParadoxOrderViewModel>)((WSspRpt_ParadoxOrderHaveNotDraft_Result item) => new WSfnRpt_ParadoxOrderViewModel
				{
					ordDate = ((!string.IsNullOrEmpty(item.ordDate) && currLangID != 1065) ? PersianDate.GetShamsi2Miladi(item.ordDate.Replace("/", "")).Replace("/", "") : item.ordDate),
					Company = item.Company,
					Opr = item.Opr,
					OrderId = item.OrderId,
					OrderOprID = item.OrderOprID,
					ordCompanyId = item.ordCompanyId,
					ordNumber = item.ordNumber,
					Dcnt = null,
					Ocnt = null
				})));
				break;
			}
			case 2:
			{
				List<WSspRpt_ParadoxOrderItemWithDraftItem_Result> list5 = Enumerable.ToList<WSspRpt_ParadoxOrderItemWithDraftItem_Result>((IEnumerable<WSspRpt_ParadoxOrderItemWithDraftItem_Result>)_db.WSspRpt_ParadoxOrderItemWithDraftItem(paradoxReportsViewModel.OrdFromDate, paradoxReportsViewModel.OrdToDate, value2, value3, currLangID, result, result2, value));
				list.AddRange(Enumerable.Select<WSspRpt_ParadoxOrderItemWithDraftItem_Result, WSfnRpt_ParadoxOrderViewModel>((IEnumerable<WSspRpt_ParadoxOrderItemWithDraftItem_Result>)list5, (Func<WSspRpt_ParadoxOrderItemWithDraftItem_Result, WSfnRpt_ParadoxOrderViewModel>)((WSspRpt_ParadoxOrderItemWithDraftItem_Result item) => new WSfnRpt_ParadoxOrderViewModel
				{
					ordDate = ((!string.IsNullOrEmpty(item.ordDate) && currLangID != 1065) ? PersianDate.GetShamsi2Miladi(item.ordDate.Replace("/", "")).Replace("/", "") : item.ordDate),
					Company = item.Company,
					Opr = item.Opr,
					OrderId = item.OrderId,
					OrderOprID = item.OrderOprID,
					ordCompanyId = item.ordCompanyId,
					ordNumber = item.ordNumber,
					Dcnt = item.Dcnt,
					Ocnt = item.Ocnt
				})));
				break;
			}
			case 3:
			{
				List<WSspRpt_ParadoxOrderItemSerialWithDraftItemSerial_Result> list4 = Enumerable.ToList<WSspRpt_ParadoxOrderItemSerialWithDraftItemSerial_Result>((IEnumerable<WSspRpt_ParadoxOrderItemSerialWithDraftItemSerial_Result>)_db.WSspRpt_ParadoxOrderItemSerialWithDraftItemSerial(paradoxReportsViewModel.OrdFromDate, paradoxReportsViewModel.OrdToDate, value2, value3, currLangID, result, result2, value));
				list.AddRange(Enumerable.Select<WSspRpt_ParadoxOrderItemSerialWithDraftItemSerial_Result, WSfnRpt_ParadoxOrderViewModel>((IEnumerable<WSspRpt_ParadoxOrderItemSerialWithDraftItemSerial_Result>)list4, (Func<WSspRpt_ParadoxOrderItemSerialWithDraftItemSerial_Result, WSfnRpt_ParadoxOrderViewModel>)((WSspRpt_ParadoxOrderItemSerialWithDraftItemSerial_Result item) => new WSfnRpt_ParadoxOrderViewModel
				{
					ordDate = ((!string.IsNullOrEmpty(item.ordDate) && currLangID != 1065) ? PersianDate.GetShamsi2Miladi(item.ordDate.Replace("/", "")).Replace("/", "") : item.ordDate),
					Company = item.Company,
					Opr = item.Opr,
					OrderId = item.OrderId,
					OrderOprID = item.OrderOprID,
					ordCompanyId = item.ordCompanyId,
					ordNumber = item.ordNumber,
					Dcnt = null,
					Ocnt = null
				})));
				break;
			}
			case 4:
			{
				List<WSspRpt_ParadoxOrderItemcntWithSerialcnt_Result> list3 = Enumerable.ToList<WSspRpt_ParadoxOrderItemcntWithSerialcnt_Result>((IEnumerable<WSspRpt_ParadoxOrderItemcntWithSerialcnt_Result>)_db.WSspRpt_ParadoxOrderItemcntWithSerialcnt(paradoxReportsViewModel.OrdFromDate, paradoxReportsViewModel.OrdToDate, value2, value3, currLangID, result, result2, value));
				list.AddRange(Enumerable.Select<WSspRpt_ParadoxOrderItemcntWithSerialcnt_Result, WSfnRpt_ParadoxOrderViewModel>((IEnumerable<WSspRpt_ParadoxOrderItemcntWithSerialcnt_Result>)list3, (Func<WSspRpt_ParadoxOrderItemcntWithSerialcnt_Result, WSfnRpt_ParadoxOrderViewModel>)((WSspRpt_ParadoxOrderItemcntWithSerialcnt_Result item) => new WSfnRpt_ParadoxOrderViewModel
				{
					ordDate = ((!string.IsNullOrEmpty(item.ordDate) && currLangID != 1065) ? PersianDate.GetShamsi2Miladi(item.ordDate.Replace("/", "")).Replace("/", "") : item.ordDate),
					Company = item.Company,
					Opr = item.Opr,
					OrderId = item.OrderId,
					OrderOprID = item.OrderOprID,
					ordCompanyId = item.ordCompanyId,
					ordNumber = item.ordNumber,
					Dcnt = null,
					Ocnt = null
				})));
				break;
			}
			case 5:
			{
				List<WSspSearchSerialInSale_Result> list2 = Enumerable.ToList<WSspSearchSerialInSale_Result>((IEnumerable<WSspSearchSerialInSale_Result>)_db.WSspSearchSerialInSale(fDate: paradoxReportsViewModel.OrdFromDate, tDate: paradoxReportsViewModel.OrdToDate, serial: paradoxReportsViewModel.OrdSerial, fDateTime: value2, tDateTime: value3, languageID: currLangID, defaultLanguageID: result, centerId: result2, userId: value));
				list.AddRange(Enumerable.Select<WSspSearchSerialInSale_Result, WSfnRpt_ParadoxOrderViewModel>((IEnumerable<WSspSearchSerialInSale_Result>)list2, (Func<WSspSearchSerialInSale_Result, WSfnRpt_ParadoxOrderViewModel>)((WSspSearchSerialInSale_Result item) => new WSfnRpt_ParadoxOrderViewModel
				{
					ordDate = ((!string.IsNullOrEmpty(item.ordDate) && currLangID != 1065) ? PersianDate.GetShamsi2Miladi(item.ordDate.Replace("/", "")).Replace("/", "") : item.ordDate),
					Company = item.Company,
					Opr = item.Opr,
					OrderId = item.OrderId,
					OrderOprID = item.OrderOprID,
					ordCompanyId = item.ordCompanyId,
					ordNumber = item.ordNumber,
					Dcnt = null,
					Ocnt = null
				})));
				break;
			}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public ActionResult DocSearch_Read([DataSourceRequest] DataSourceRequest request, string modelObj)
	{
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		List<WSfnRpt_ParadoxDraftViewModel> list = new List<WSfnRpt_ParadoxDraftViewModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			ParadoxReportsViewModel paradoxReportsViewModel = new JavaScriptSerializer().Deserialize<ParadoxReportsViewModel>(modelObj);
			paradoxReportsViewModel.DocFromDate = paradoxReportsViewModel.DocFromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
				.Replace(" ", "")
				.Replace("_", "");
			paradoxReportsViewModel.DocToDate = paradoxReportsViewModel.DocToDate.Replace("/", "").Replace("-", "").Replace("\\", "")
				.Replace(" ", "")
				.Replace("_", "");
			DateTime value = DateTime.Now;
			DateTime value2 = DateTime.Now;
			if (!string.IsNullOrEmpty(paradoxReportsViewModel.DocFromDate))
			{
				value = DateTime.Parse(PersianDate.GetFormatetdDate(paradoxReportsViewModel.DocFromDate.Replace("/", "")) + " 00:00:00", (currLangID == 1065) ? new PersianCulture() : ((currLangID == 1025) ? new CultureInfo("ar-SA") : new CultureInfo("en-US")));
			}
			if (!string.IsNullOrEmpty(paradoxReportsViewModel.DocToDate))
			{
				value2 = DateTime.Parse(PersianDate.GetFormatetdDate(paradoxReportsViewModel.DocToDate.Replace("/", "")) + " 23:59:59", (currLangID == 1065) ? new PersianCulture() : ((currLangID == 1025) ? new CultureInfo("ar-SA") : new CultureInfo("en-US")));
			}
			switch (paradoxReportsViewModel.DocReportId)
			{
			case 1:
			{
				List<WSspRpt_ParadoxDraftWithOrder_Result> list5 = Enumerable.ToList<WSspRpt_ParadoxDraftWithOrder_Result>((IEnumerable<WSspRpt_ParadoxDraftWithOrder_Result>)_db.WSspRpt_ParadoxDraftWithOrder(paradoxReportsViewModel.DocFromDate, paradoxReportsViewModel.DocToDate, value, value2, currLangID, result, result2));
				list.AddRange(Enumerable.Select<WSspRpt_ParadoxDraftWithOrder_Result, WSfnRpt_ParadoxDraftViewModel>((IEnumerable<WSspRpt_ParadoxDraftWithOrder_Result>)list5, (Func<WSspRpt_ParadoxDraftWithOrder_Result, WSfnRpt_ParadoxDraftViewModel>)((WSspRpt_ParadoxDraftWithOrder_Result item) => new WSfnRpt_ParadoxDraftViewModel
				{
					DocDate = ((!string.IsNullOrEmpty(item.DocDate) && currLangID != 1065) ? PersianDate.GetShamsi2Miladi(item.DocDate.Replace("/", "")).Replace("/", "") : item.DocDate),
					DocID = item.DocID,
					Opr = item.Opr,
					Company = item.Company,
					OrderId = item.OrderId,
					OprId = item.OprId,
					DocNumber = item.DocNumber,
					WareHouse = item.WareHouse
				})));
				break;
			}
			case 2:
			{
				List<WSspRpt_ParadoxDraftWithOutOrder_Result> list4 = Enumerable.ToList<WSspRpt_ParadoxDraftWithOutOrder_Result>((IEnumerable<WSspRpt_ParadoxDraftWithOutOrder_Result>)_db.WSspRpt_ParadoxDraftWithOutOrder(paradoxReportsViewModel.DocFromDate, paradoxReportsViewModel.DocToDate, value, value2, currLangID, result, result2));
				list.AddRange(Enumerable.Select<WSspRpt_ParadoxDraftWithOutOrder_Result, WSfnRpt_ParadoxDraftViewModel>((IEnumerable<WSspRpt_ParadoxDraftWithOutOrder_Result>)list4, (Func<WSspRpt_ParadoxDraftWithOutOrder_Result, WSfnRpt_ParadoxDraftViewModel>)((WSspRpt_ParadoxDraftWithOutOrder_Result item) => new WSfnRpt_ParadoxDraftViewModel
				{
					DocDate = ((!string.IsNullOrEmpty(item.DocDate) && currLangID != 1065) ? PersianDate.GetShamsi2Miladi(item.DocDate.Replace("/", "")).Replace("/", "") : item.DocDate),
					DocID = item.DocID,
					Opr = item.Opr,
					Company = item.Company,
					OrderId = item.OrderId,
					OprId = item.OprId,
					DocNumber = item.DocNumber,
					WareHouse = item.WareHouse
				})));
				break;
			}
			case 3:
			{
				List<WSspRpt_ParadoxDraftItemcntWithSerialcnt_Result> list3 = Enumerable.ToList<WSspRpt_ParadoxDraftItemcntWithSerialcnt_Result>((IEnumerable<WSspRpt_ParadoxDraftItemcntWithSerialcnt_Result>)_db.WSspRpt_ParadoxDraftItemcntWithSerialcnt(paradoxReportsViewModel.DocFromDate, paradoxReportsViewModel.DocToDate, value, value2, currLangID, result, result2));
				list.AddRange(Enumerable.Select<WSspRpt_ParadoxDraftItemcntWithSerialcnt_Result, WSfnRpt_ParadoxDraftViewModel>((IEnumerable<WSspRpt_ParadoxDraftItemcntWithSerialcnt_Result>)list3, (Func<WSspRpt_ParadoxDraftItemcntWithSerialcnt_Result, WSfnRpt_ParadoxDraftViewModel>)((WSspRpt_ParadoxDraftItemcntWithSerialcnt_Result item) => new WSfnRpt_ParadoxDraftViewModel
				{
					DocDate = ((!string.IsNullOrEmpty(item.DocDate) && currLangID != 1065) ? PersianDate.GetShamsi2Miladi(item.DocDate.Replace("/", "")).Replace("/", "") : item.DocDate),
					DocID = item.DocID,
					Opr = item.Opr,
					Company = item.Company,
					OrderId = item.OrderId,
					OprId = item.OprId,
					DocNumber = item.DocNumber,
					WareHouse = item.WareHouse
				})));
				break;
			}
			case 4:
			{
				List<WSspSearchSerialInDoc_Result> list2 = Enumerable.ToList<WSspSearchSerialInDoc_Result>((IEnumerable<WSspSearchSerialInDoc_Result>)_db.WSspSearchSerialInDoc(fDate: paradoxReportsViewModel.DocFromDate, tDate: paradoxReportsViewModel.DocToDate, serial: paradoxReportsViewModel.DocSerial, fDateTime: value, tDateTime: value2, languageID: currLangID, defaultLanguageID: result, centerId: result2));
				list.AddRange(Enumerable.Select<WSspSearchSerialInDoc_Result, WSfnRpt_ParadoxDraftViewModel>((IEnumerable<WSspSearchSerialInDoc_Result>)list2, (Func<WSspSearchSerialInDoc_Result, WSfnRpt_ParadoxDraftViewModel>)((WSspSearchSerialInDoc_Result item) => new WSfnRpt_ParadoxDraftViewModel
				{
					DocDate = ((!string.IsNullOrEmpty(item.DocDate) && currLangID != 1065) ? PersianDate.GetShamsi2Miladi(item.DocDate.Replace("/", "")).Replace("/", "") : item.DocDate),
					DocID = item.DocID,
					Opr = item.Opr,
					Company = item.Company,
					OrderId = item.OrderId,
					OprId = item.OprId,
					DocNumber = item.DocNumber,
					WareHouse = item.WareHouse
				})));
				break;
			}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public ActionResult PordSearch_Read([DataSourceRequest] DataSourceRequest request, string modelObj)
	{
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		List<WSspRpt_ParadoxPreOrderHaveNotDraft_Result> list = new List<WSspRpt_ParadoxPreOrderHaveNotDraft_Result>();
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
			if (!string.IsNullOrWhiteSpace(modelObj))
			{
				ParadoxReportsViewModel paradoxReportsViewModel = new JavaScriptSerializer().Deserialize<ParadoxReportsViewModel>(modelObj);
				if (paradoxReportsViewModel != null)
				{
					DateTime value = DateTime.Now;
					DateTime value2 = DateTime.Now;
					if (!string.IsNullOrWhiteSpace(paradoxReportsViewModel.PordFromDate))
					{
						paradoxReportsViewModel.PordFromDate = paradoxReportsViewModel.PordFromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
							.Replace(" ", "")
							.Replace("_", "");
						value = DateTime.Parse(PersianDate.GetFormatetdDate(paradoxReportsViewModel.PordFromDate.Replace("/", "")) + " 00:00:00", lCID switch
						{
							1025 => new CultureInfo("ar-SA"), 
							1065 => new PersianCulture(), 
							_ => new CultureInfo("en-US"), 
						});
					}
					if (!string.IsNullOrWhiteSpace(paradoxReportsViewModel.PordToDate))
					{
						paradoxReportsViewModel.PordToDate = paradoxReportsViewModel.PordToDate.Replace("/", "").Replace("-", "").Replace("\\", "")
							.Replace(" ", "")
							.Replace("_", "");
						value2 = DateTime.Parse(PersianDate.GetFormatetdDate(paradoxReportsViewModel.PordToDate.Replace("/", "")) + " 23:59:59", lCID switch
						{
							1025 => new CultureInfo("ar-SA"), 
							1065 => new PersianCulture(), 
							_ => new CultureInfo("en-US"), 
						});
					}
					switch (paradoxReportsViewModel.PordReportId)
					{
					case 1:
					{
						List<WSspRpt_ParadoxPreOrderHaveNotDraft_Result> list3 = Enumerable.ToList<WSspRpt_ParadoxPreOrderHaveNotDraft_Result>((IEnumerable<WSspRpt_ParadoxPreOrderHaveNotDraft_Result>)_dbII.WSspRpt_ParadoxPreOrderHaveNotDraft(UserLogin.CurrentUser.UserId, value, value2, lCID, result, result2));
						if (list3 != null && Enumerable.Any<WSspRpt_ParadoxPreOrderHaveNotDraft_Result>((IEnumerable<WSspRpt_ParadoxPreOrderHaveNotDraft_Result>)list3))
						{
							list.AddRange(Enumerable.Select<WSspRpt_ParadoxPreOrderHaveNotDraft_Result, WSspRpt_ParadoxPreOrderHaveNotDraft_Result>((IEnumerable<WSspRpt_ParadoxPreOrderHaveNotDraft_Result>)list3, (Func<WSspRpt_ParadoxPreOrderHaveNotDraft_Result, WSspRpt_ParadoxPreOrderHaveNotDraft_Result>)((WSspRpt_ParadoxPreOrderHaveNotDraft_Result item) => new WSspRpt_ParadoxPreOrderHaveNotDraft_Result
							{
								pordNumber = item.pordNumber,
								pordDate = (item.pordDateTime.HasValue ? item.pordDateTime.Value.ToString("yyyy/MM/dd") : ""),
								pordCompanyId = item.pordCompanyId,
								Company = item.Company,
								PreOrderID = item.PreOrderID,
								PreOrderOprID = item.PreOrderOprID,
								PreOrderOpr = item.PreOrderOpr,
								pordTypeId = item.pordTypeId,
								PreOrderType = item.PreOrderType
							})));
						}
						break;
					}
					case 2:
					{
						List<WSspRpt_ParadoxPreOrderItemWithDraftItem_Result> list2 = Enumerable.ToList<WSspRpt_ParadoxPreOrderItemWithDraftItem_Result>((IEnumerable<WSspRpt_ParadoxPreOrderItemWithDraftItem_Result>)_dbII.WSspRpt_ParadoxPreOrderItemWithDraftItem(UserLogin.CurrentUser.UserId, value, value2, lCID, result, result2));
						if (list2 != null && Enumerable.Any<WSspRpt_ParadoxPreOrderItemWithDraftItem_Result>((IEnumerable<WSspRpt_ParadoxPreOrderItemWithDraftItem_Result>)list2))
						{
							list.AddRange(Enumerable.Select<WSspRpt_ParadoxPreOrderItemWithDraftItem_Result, WSspRpt_ParadoxPreOrderHaveNotDraft_Result>((IEnumerable<WSspRpt_ParadoxPreOrderItemWithDraftItem_Result>)list2, (Func<WSspRpt_ParadoxPreOrderItemWithDraftItem_Result, WSspRpt_ParadoxPreOrderHaveNotDraft_Result>)((WSspRpt_ParadoxPreOrderItemWithDraftItem_Result item) => new WSspRpt_ParadoxPreOrderHaveNotDraft_Result
							{
								pordNumber = item.pordNumber,
								pordDate = (item.pordDateTime.HasValue ? item.pordDateTime.Value.ToString("yyyy/MM/dd") : ""),
								pordCompanyId = item.pordCompanyId,
								Company = item.Company,
								PreOrderID = item.PreOrderID,
								PreOrderOprID = item.PreOrderOprID,
								PreOrderOpr = item.PreOrderOpr,
								pordTypeId = item.pordTypeId,
								PreOrderType = item.PreOrderType
							})));
						}
						break;
					}
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}
}

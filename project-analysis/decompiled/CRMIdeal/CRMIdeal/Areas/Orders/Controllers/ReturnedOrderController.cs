using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Orders.Controllers;

public class ReturnedOrderController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMLinkSpEntities _dbLink = new CRMLinkSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	private const int _Mode_Issue = 1;

	private const int _Mode_EditItems = 10;

	public ActionResult Issue(int ordId = 0, int retOrdId = 0)
	{
		base.ViewBag.OrderId = ordId;
		base.ViewBag.ReturnedOrderId = retOrdId;
		int num = 1;
		if (ordId != 0 && retOrdId != 0)
		{
			num = 10;
		}
		base.ViewBag.Mode = num;
		base.ViewBag.OrderOprList = Order.SelectOrderOprByOprType_SelectListItem(2);
		return View();
	}

	[HttpPost]
	[LoginAuthorize]
	public string IssueReturnedOrderRefOrder(int ordId = 0, int retOrdId = 0, int orderOprId = 0, string ordDate = "", string jsRetItems = "", int quesMode = 0)
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
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int userId = UserLogin.CurrentUser.UserId;
			short.Parse(Financial.Get().Id.ToString());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int id = Financial.Get().Id;
			int result3 = 0;
			if (UserLogin.CurrentUser != null && result3 == 0)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			DateTime? dateFromPersian = DateTimeClass.GetDateFromPersian(ordDate);
			ordDate = dateFromPersian?.ToString("yyyyMMdd", new PersianCulture());
			int result4 = 0;
			WSspSelectOrderById_Result wSspSelectOrderById_Result = Enumerable.FirstOrDefault<WSspSelectOrderById_Result>((IEnumerable<WSspSelectOrderById_Result>)_db.WSspSelectOrderById(ordId, lCID, result2));
			if (wSspSelectOrderById_Result != null)
			{
				int.TryParse(wSspSelectOrderById_Result.ordCompanyId.ToString(), out result4);
			}
			if (quesMode == 0)
			{
				WSspCheckOrderHaveScoreUsage_Result wSspCheckOrderHaveScoreUsage_Result = Enumerable.FirstOrDefault<WSspCheckOrderHaveScoreUsage_Result>((IEnumerable<WSspCheckOrderHaveScoreUsage_Result>)_dbII.WSspCheckOrderHaveScoreUsage(ordId, lCID, result2));
				if (wSspCheckOrderHaveScoreUsage_Result != null && wSspCheckOrderHaveScoreUsage_Result.GeneratedDisCodeId.GetValueOrDefault() != 0)
				{
					return "-10";
				}
			}
			if (quesMode == 0 || quesMode != -15)
			{
				string moneyBagByFormat = "";
				if (CRMIdeal.Classes.Helper.Company.ReturnCompanyMoneyBagRemain(result4, ref moneyBagByFormat, result3) != 0m)
				{
					return "-15|" + moneyBagByFormat;
				}
			}
			List<WSspIssueReturnOrderRefOrder_Result> list = Enumerable.ToList<WSspIssueReturnOrderRefOrder_Result>((IEnumerable<WSspIssueReturnOrderRefOrder_Result>)_dbII.WSspIssueReturnOrderRefOrder(jsRetItems, ordId, orderOprId, retOrdId, ordDate, dateFromPersian, id, value, registerDatePersian, userId, value2, appType, lCID, result2, (result3 == 0) ? null : new int?(result3)));
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

	[HttpPost]
	[LoginAuthorize]
	public string GetOrder(int ordId = 0, int ordRefId = 0)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		list.Add(new SelectListItem
		{
			Text = "ord"
		});
		list.Add(new SelectListItem
		{
			Text = "ordI"
		});
		list.Add(new SelectListItem
		{
			Text = "ordRef"
		});
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			WSspSelectOrderById_Result wSspSelectOrderById_Result = Enumerable.FirstOrDefault<WSspSelectOrderById_Result>((IEnumerable<WSspSelectOrderById_Result>)_db.WSspSelectOrderById(ordId, lCID, result));
			if (wSspSelectOrderById_Result != null)
			{
				wSspSelectOrderById_Result.ordDate = wSspSelectOrderById_Result.ordDateTime?.ToString("yyyy/MM/dd");
				list[0].Value = JsonConvert.SerializeObject(wSspSelectOrderById_Result);
				List<WSspSelectOrderItems_Result> list2 = Enumerable.ToList<WSspSelectOrderItems_Result>((IEnumerable<WSspSelectOrderItems_Result>)_db.WSspSelectOrderItems(ordId, lCID, result));
				if (list2 != null)
				{
					list[1].Value = JsonConvert.SerializeObject(list2);
				}
			}
			if (ordRefId != 0)
			{
				WSspSelectOrderById_Result wSspSelectOrderById_Result2 = Enumerable.FirstOrDefault<WSspSelectOrderById_Result>((IEnumerable<WSspSelectOrderById_Result>)_db.WSspSelectOrderById(ordRefId, lCID, result));
				if (wSspSelectOrderById_Result2 != null)
				{
					wSspSelectOrderById_Result2.ordDate = wSspSelectOrderById_Result2.ordDateTime?.ToString("yyyy/MM/dd");
					list[2].Value = JsonConvert.SerializeObject(wSspSelectOrderById_Result2);
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetReturnedOrderItems(int ordId = 0)
	{
		List<WSspSelectOrderItemsWithRefOrdId_Result> value = new List<WSspSelectOrderItemsWithRefOrdId_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectOrderItemsWithRefOrdId_Result> list = Enumerable.ToList<WSspSelectOrderItemsWithRefOrdId_Result>((IEnumerable<WSspSelectOrderItemsWithRefOrdId_Result>)_dbII.WSspSelectOrderItemsWithRefOrdId(ordId, lCID, result));
			if (list != null)
			{
				foreach (WSspSelectOrderItemsWithRefOrdId_Result item in list)
				{
					item.ordDate = item.ordDateTime?.ToString("yyyy/MM/dd") ?? "";
				}
				value = list;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return JsonConvert.SerializeObject(value);
	}

	protected override void Dispose(bool disposing)
	{
		if (_db != null)
		{
			_db.Dispose();
		}
		if (_dbTbl != null)
		{
			_dbTbl.Dispose();
		}
		if (_dbLink != null)
		{
			_dbLink.Dispose();
		}
		if (_dbI != null)
		{
			_dbI.Dispose();
		}
		if (_dbII != null)
		{
			_dbII.Dispose();
		}
		base.Dispose(disposing);
	}
}

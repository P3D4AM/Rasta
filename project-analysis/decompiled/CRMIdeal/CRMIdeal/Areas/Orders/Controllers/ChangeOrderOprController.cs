using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

namespace CRMIdeal.Areas.Orders.Controllers;

public class ChangeOrderOprController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmOrder", ActionName = "actChangeOrderOpr")]
	public ActionResult Index(int orderId, int orderOprId)
	{
		base.ViewBag.OrderId = orderId;
		base.ViewBag.OrderOprId = orderOprId;
		WSspReturnDocForSaleOrder_Result wSspReturnDocForSaleOrder_Result = new WSspReturnDocForSaleOrder_Result();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		if (orderOprId > 0)
		{
			GetOrderOpr(orderOprId);
		}
		string text = "";
		if (orderId > 0)
		{
			List<WSspReturnDocForSaleOrder_Result> list = Enumerable.ToList<WSspReturnDocForSaleOrder_Result>((IEnumerable<WSspReturnDocForSaleOrder_Result>)_db.WSspReturnDocForSaleOrder(orderId, lCID, result));
			if (list != null && Enumerable.Any<WSspReturnDocForSaleOrder_Result>((IEnumerable<WSspReturnDocForSaleOrder_Result>)list))
			{
				wSspReturnDocForSaleOrder_Result = Enumerable.LastOrDefault<WSspReturnDocForSaleOrder_Result>((IEnumerable<WSspReturnDocForSaleOrder_Result>)list);
				if (list.Count > 1)
				{
					foreach (WSspReturnDocForSaleOrder_Result item in list)
					{
						text = text + item.DocNumber + ",";
					}
					if (!string.IsNullOrEmpty(text) && text.EndsWith(","))
					{
						text = text.TrimEnd(new char[1] { ',' });
					}
				}
			}
			if (wSspReturnDocForSaleOrder_Result != null)
			{
				if (string.IsNullOrEmpty(text))
				{
					text = wSspReturnDocForSaleOrder_Result.DocNumber.ToString();
				}
				wSspReturnDocForSaleOrder_Result.DocDate = (wSspReturnDocForSaleOrder_Result.DocDateTime.HasValue ? wSspReturnDocForSaleOrder_Result.DocDateTime.Value.ToString("yyyy/MM/dd") : "");
				base.ViewBag.Doc = wSspReturnDocForSaleOrder_Result;
			}
			else
			{
				wSspReturnDocForSaleOrder_Result = new WSspReturnDocForSaleOrder_Result();
			}
		}
		base.ViewBag.DocNumbers = text;
		return View(wSspReturnDocForSaleOrder_Result);
	}

	[AjaxOnly]
	public JsonResult GetOrderOpr(int orderOprId)
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
			int value = 0;
			if (UserLogin.CurrentUser != null)
			{
				value = UserLogin.CurrentUser.UserId;
			}
			List<WSspSelectOrderOprExceptId_Result> list2 = Enumerable.ToList<WSspSelectOrderOprExceptId_Result>((IEnumerable<WSspSelectOrderOprExceptId_Result>)_db.WSspSelectOrderOprExceptId(orderOprId, lCID, result, value));
			list.AddRange(Enumerable.Select<WSspSelectOrderOprExceptId_Result, SelectListItem>((IEnumerable<WSspSelectOrderOprExceptId_Result>)list2, (Func<WSspSelectOrderOprExceptId_Result, SelectListItem>)((WSspSelectOrderOprExceptId_Result item) => new SelectListItem
			{
				Text = item.Name,
				Value = item.OrderOprID.ToString(),
				Selected = false
			})));
			if (Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)list))
			{
				list[0].Selected = true;
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
	public string ChangeOrderOprType(int orderId, int orderOprId, int? cId = null, int quesMode = 0)
	{
		string result = "-1";
		if (orderId > 0)
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
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			_ = Financial.Get().Id;
			if (cId.GetValueOrDefault() == 0)
			{
				int result3 = 0;
				if (UserLogin.CurrentUser != null)
				{
					int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
				}
				if (result3 != 0)
				{
					cId = result3;
				}
			}
			if (Order.IsSentToLinkAccByAction(orderId))
			{
				return "-2";
			}
			if (quesMode == 0)
			{
				WSspCheckOrderHaveScoreUsage_Result wSspCheckOrderHaveScoreUsage_Result = Enumerable.FirstOrDefault<WSspCheckOrderHaveScoreUsage_Result>((IEnumerable<WSspCheckOrderHaveScoreUsage_Result>)_dbII.WSspCheckOrderHaveScoreUsage(orderId, lCID, result2));
				if (wSspCheckOrderHaveScoreUsage_Result != null && wSspCheckOrderHaveScoreUsage_Result.FirstScoreId.GetValueOrDefault() != 0)
				{
					return "-5";
				}
			}
			if (quesMode == -5)
			{
				mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.ScorespDeleteOrderScores(orderId, userId, value2, value3, value, registerDatePersian, appType, result2, (cId == 0) ? null : cId));
				int result4 = 0;
				if (mct_I_Result != null)
				{
					int.TryParse(mct_I_Result.Result.ToString(), out result4);
				}
				if (result4 == 0)
				{
					return Messages.msgErrorRunFunction;
				}
			}
			try
			{
				int result5 = 0;
				if (UserLogin.CurrentUser != null)
				{
					int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result5);
				}
				if (cId.GetValueOrDefault() == 0)
				{
					cId = result5;
				}
				long num = Enumerable.FirstOrDefault<long>(_db.Database.SqlQuery<long>($"Select dbo.WSfnReturnOrderNumber({Financial.Get().Id}, {orderOprId},{cId.GetValueOrDefault()})", Array.Empty<object>()));
				if (num > 0)
				{
					if (_db.WSspUpdateOrderOprByOrderId(orderId, orderOprId, num) == 1)
					{
						result = Messages.msgSuccessAction;
					}
					else
					{
						Exception e = new Exception("خطا در تغییر نوع فاکتور در دیتابیس!");
						ErrorSignal.FromCurrentContext().Raise(e);
					}
				}
			}
			catch (DbEntityValidationException e2)
			{
				ErrorSignal.FromCurrentContext().Raise((Exception)(object)e2);
			}
			catch (Exception e3)
			{
				ErrorSignal.FromCurrentContext().Raise(e3);
			}
		}
		return result;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbI.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}
}

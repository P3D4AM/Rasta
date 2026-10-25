using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Calendar;
using CRM.General.Security;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace CRMIdeal.Areas.Orders.Controllers;

public class DistributePaymentController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	[DynamicAuthorize(ControllerName = "frmOrder", ActionName = "actDistributePaymentToOrders")]
	public ActionResult Index(int cmpId, int ordId)
	{
		GetPayType();
		base.ViewBag.CompanyId = cmpId;
		base.ViewBag.OrderId = ordId;
		new DistributePaymentToOrdersViewModel();
		return View();
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmOrder", ActionName = "actDistributePaymentToOrders")]
	public int DistributePaymentToOrders(string importDate, int payTypeId, string docNumber, string docDate, string description, decimal docAmount, string orderIdsWithAmount, int ordId)
	{
		int num = -1;
		try
		{
			if (!string.IsNullOrEmpty(orderIdsWithAmount))
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				DateTime now = DateTime.Now;
				importDate = importDate.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
				docDate = docDate.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
				DateTime dateTime = default(DateTime);
				string text = "";
				DateTime value = default(DateTime);
				DateTime value2 = default(DateTime);
				try
				{
					if (!string.IsNullOrEmpty(importDate))
					{
						text = PersianDate.GetFormatetdDate(importDate.Replace("/", ""));
						text = text + " " + DateTime.Now.ToString("HH:mm:ss");
						switch (lCID)
						{
						case 1065:
							dateTime = DateTime.Parse(text, new PersianCulture());
							importDate = dateTime.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime = DateTime.Parse(text, new CultureInfo("ar-SA"));
							importDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime = DateTime.Parse(text, new CultureInfo("en-US"));
							importDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						value = dateTime;
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					num = -1;
				}
				try
				{
					if (!string.IsNullOrEmpty(docDate))
					{
						text = PersianDate.GetFormatetdDate(docDate.Replace("/", ""));
						text = text + " " + DateTime.Now.ToString("HH:mm:ss");
						switch (lCID)
						{
						case 1065:
							dateTime = DateTime.Parse(text, new PersianCulture());
							docDate = dateTime.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime = DateTime.Parse(text, new CultureInfo("ar-SA"));
							docDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime = DateTime.Parse(text, new CultureInfo("en-US"));
							docDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						value2 = dateTime;
					}
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
					num = -1;
				}
				string text2 = now.ToString("yyyyMMdd", new PersianCulture());
				short value3 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				int id = Financial.Get().Id;
				ObjectParameter objectParameter = new ObjectParameter("Result", 0);
				int userId = UserLogin.CurrentUser.UserId;
				_db.WSspDistributePaymentToOrders(importDate, payTypeId, null, null, docNumber, docDate, description, userId, text2, now, userId, id, value3, now, text2, value, value2, docAmount, null, appType, result, text2, userId, now, orderIdsWithAmount, ordId.ToString(), objectParameter);
				num = int.Parse(objectParameter.Value.ToString());
				Order.SetPaymentStatus(ordId);
				if (ordId != 0)
				{
					Order.CalcOrderCancelledScores(ordId);
				}
			}
			else
			{
				num = -1;
			}
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
			num = -1;
		}
		return num;
	}

	[AjaxOnly]
	public JsonResult GetPayType()
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
			int value = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserId : 0);
			List<WSspSelectActiveOrderPaymentTypes_Result> list2 = Enumerable.ToList<WSspSelectActiveOrderPaymentTypes_Result>((IEnumerable<WSspSelectActiveOrderPaymentTypes_Result>)_dbI.WSspSelectActiveOrderPaymentTypes(lCID, result, value));
			list.AddRange(Enumerable.Select<WSspSelectActiveOrderPaymentTypes_Result, SelectListItem>((IEnumerable<WSspSelectActiveOrderPaymentTypes_Result>)list2, (Func<WSspSelectActiveOrderPaymentTypes_Result, SelectListItem>)((WSspSelectActiveOrderPaymentTypes_Result item) => new SelectListItem
			{
				Text = item.ordpayType,
				Value = item.OrderPaymentTypeId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PayTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public List<WSspSelectCompanyOrderForDistributePayment_Result> GetOrdersList(int cmpId, int oprType = 0)
	{
		List<WSspSelectCompanyOrderForDistributePayment_Result> list = new List<WSspSelectCompanyOrderForDistributePayment_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int value = 0;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
				value = UserLogin.CurrentUser.UserId;
			}
			list = Enumerable.ToList<WSspSelectCompanyOrderForDistributePayment_Result>((IEnumerable<WSspSelectCompanyOrderForDistributePayment_Result>)_db.WSspSelectCompanyOrderForDistributePayment(cmpId, lCID, result, value, result2, oprType));
			foreach (WSspSelectCompanyOrderForDistributePayment_Result item in list)
			{
				item.ordDate = (item.ordDateTime.HasValue ? item.ordDateTime.Value.ToString("yyyy/MM/dd") : ((!string.IsNullOrEmpty(item.ordDate)) ? PersianDate.GetFormatetdDate(item.ordDate) : ""));
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
		return list;
	}

	public ActionResult OrdersList_Read([DataSourceRequest] DataSourceRequest request, int cmpId, int oprType = 0)
	{
		List<WSspSelectCompanyOrderForDistributePayment_Result> enumerable = new List<WSspSelectCompanyOrderForDistributePayment_Result>();
		try
		{
			enumerable = GetOrdersList(cmpId, oprType);
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		JsonResult jsonResult = Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}

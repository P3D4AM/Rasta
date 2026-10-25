using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.PreOrders.Controllers;

public class PaymentInstallmentController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actInstallmentPayPreOrder")]
	public ActionResult Index(int pordId)
	{
		base.ViewBag.PreOrderId = pordId;
		GetPayType();
		return View();
	}

	[AjaxOnly]
	public string ActInstallmentPayment(decimal totalAmount, string startDate, int installmentCount, int installmentInterval, int currencyUnitId)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			List<InstallmentPayOrderViewModel> list = Payment.InstallmentPayment(totalAmount, startDate, installmentCount, installmentInterval, currencyUnitId);
			if (list != null)
			{
				result = JsonConvert.SerializeObject(Enumerable.ToList<InstallmentPayOrderViewModel>((IEnumerable<InstallmentPayOrderViewModel>)list));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<WSspSelectActiveOrderPaymentTypes_Result, SelectListItem>((IEnumerable<WSspSelectActiveOrderPaymentTypes_Result>)Enumerable.ToList<WSspSelectActiveOrderPaymentTypes_Result>((IEnumerable<WSspSelectActiveOrderPaymentTypes_Result>)_dbI.WSspSelectActiveOrderPaymentTypes(lCID, result, value)), (Func<WSspSelectActiveOrderPaymentTypes_Result, SelectListItem>)((WSspSelectActiveOrderPaymentTypes_Result item) => new SelectListItem
			{
				Text = item.ordpayType,
				Value = item.OrderPaymentTypeId.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PayTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actInstallmentPayPreOrder")]
	public string ActInstallmentAndInsertPayment(int pordId, string payJson, int payTypeId)
	{
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			if (!UserLogin.IsUserAccess("frmPreOrder", "actInstallmentPayPreOrder", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			if (string.IsNullOrWhiteSpace(payJson))
			{
				return string.Format(Messages.msgErrorListEmpty, "");
			}
			List<InstallmentPayOrderViewModel> list = new JavaScriptSerializer().Deserialize<List<InstallmentPayOrderViewModel>>(payJson);
			if (list != null && Enumerable.Any<InstallmentPayOrderViewModel>((IEnumerable<InstallmentPayOrderViewModel>)list))
			{
				foreach (InstallmentPayOrderViewModel item in list)
				{
					if (item.Date.HasValue)
					{
						item.DateStr = (item.Date.HasValue ? item.Date.Value.ToString("yyyyMMdd", new PersianCulture()) : "");
					}
				}
				payJson = JsonConvert.SerializeObject(Enumerable.ToList<InstallmentPayOrderViewModel>((IEnumerable<InstallmentPayOrderViewModel>)list));
			}
			if (pordId > 0 && !string.IsNullOrWhiteSpace(payJson) && payTypeId != 0)
			{
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				int id = Financial.Get().Id;
				int userId = UserLogin.CurrentUser.UserId;
				ObjectParameter objectParameter = new ObjectParameter("Result", 0);
				ObjectParameter objectParameter2 = new ObjectParameter("errorMessage", "");
				_dbII.WSspInstallmentPaymentToPreOrder(pordId, payJson, payTypeId, centerId, userId, id, value2, value, registerDatePersian, appType, result, objectParameter, objectParameter2);
				int result2 = 0;
				if (objectParameter.Value != null)
				{
					int.TryParse(objectParameter.Value.ToString(), out result2);
				}
				string text2 = "";
				if (objectParameter2.Value != null)
				{
					text2 = objectParameter2.Value.ToString() ?? "";
					if (!string.IsNullOrWhiteSpace(text2) && text2.ToLower() == "list is empty")
					{
						text2 = string.Format(Messages.msgErrorListEmpty, "");
					}
				}
				if (result2 > 0)
				{
					return PreOrder.CalcAndSetPreOrderAmounts(pordId) ? "" : Messages.msgErrorInCalculation;
				}
				if (!string.IsNullOrWhiteSpace(text2))
				{
					return text2;
				}
				return Messages.msgErrorRunFunction;
			}
			return Messages.ErrorNotFound;
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			return Messages.msgErrorRunFunction + "<br>" + ex.Message;
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

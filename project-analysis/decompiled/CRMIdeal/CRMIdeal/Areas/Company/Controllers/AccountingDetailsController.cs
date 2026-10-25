using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Calendar;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace CRMIdeal.Areas.Company.Controllers;

public class AccountingDetailsController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	public ActionResult Index(int cmpId, string callFrom, string cmpName)
	{
		string text = "";
		switch (callFrom)
		{
		case "Company":
			text = "actNotShowcmpOrdRemain";
			if (UserLogin.IsUserAccess("frmCompanyI", text, UserLogin.CurrentUser))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			break;
		case "PreOrder":
			text = "actGotoCmpAccDetails";
			break;
		case "SaleOrder":
			text = "actGotoCmpAccDetails";
			break;
		case "BuyOrder":
			text = "actGotoCmpAccDetails";
			break;
		default:
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		base.ViewBag.CompanyId = cmpId;
		base.ViewBag.CallFrom = callFrom;
		base.ViewBag.CompanyName = cmpName;
		return View();
	}

	public List<CRMspReturnCmpAccountingDetails_Result> GetAccountingDetails(int cmpId)
	{
		List<CRMspReturnCmpAccountingDetails_Result> list = new List<CRMspReturnCmpAccountingDetails_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			string rptOrderTitle = Labels.RptOrderTitle;
			string rptPaymentTitle = Labels.RptPaymentTitle;
			string rptWastedTitle = Labels.RptWastedTitle;
			string rptBuyOrderTitle = Labels.RptBuyOrderTitle;
			string rptPreOrderTitle = Labels.RptPreOrderTitle;
			string rptSaleOrderTitle = Labels.RptSaleOrderTitle;
			string rptCmpMoneyBagTitle = Labels.RptCmpMoneyBagTitle;
			DateTime now = DateTime.Now;
			int userId = UserLogin.CurrentUser.UserId;
			string rptDate = now.ToString("yyyy/MM/dd HH:mm:ss");
			string rptDay = DateTimeClass.DefineDayeOfWeekFa(now.DayOfWeek.ToString());
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			list = Enumerable.ToList<CRMspReturnCmpAccountingDetails_Result>((IEnumerable<CRMspReturnCmpAccountingDetails_Result>)_db.CRMspReturnCmpAccountingDetails(cmpId, lCID, result, rptOrderTitle, rptPaymentTitle, rptWastedTitle, rptBuyOrderTitle, rptPreOrderTitle, rptSaleOrderTitle, now, now, userId, rptDate, rptDay, rptCmpMoneyBagTitle, result2));
			DateTime dateTime = default(DateTime);
			string text = "";
			foreach (CRMspReturnCmpAccountingDetails_Result item in list)
			{
				item.DatePer = item.DatePer.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
				if (!string.IsNullOrEmpty(item.DatePer))
				{
					text = PersianDate.GetFormatetdDate(item.DatePer.Replace("/", ""));
					text = text + " " + DateTime.Now.ToString("HH:mm:ss");
					switch (lCID)
					{
					case 1065:
						item.DatetimePerWithSlash = DateTime.Parse(text, new PersianCulture()).ToString("yyyy/MM/dd");
						break;
					case 1025:
						item.DatetimePerWithSlash = DateTime.Parse(PersianDate.GetShamsi2Miladi(item.DatePer.Replace("/", ""))).ToString("yyyy/MM/dd", new CultureInfo("ar-SA"));
						break;
					default:
						item.DatetimePerWithSlash = DateTime.Parse(PersianDate.GetShamsi2Miladi(item.DatePer.Replace("/", ""))).ToString("yyyy/MM/dd", new CultureInfo("en-US"));
						break;
					}
				}
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

	public ActionResult AccountingDetails_Read([DataSourceRequest] DataSourceRequest request, int cmpId)
	{
		List<CRMspReturnCmpAccountingDetails_Result> enumerable = new List<CRMspReturnCmpAccountingDetails_Result>();
		try
		{
			enumerable = GetAccountingDetails(cmpId);
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		base.Dispose(disposing);
	}
}

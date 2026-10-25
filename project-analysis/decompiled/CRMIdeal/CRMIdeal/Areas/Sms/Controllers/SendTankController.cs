using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Calendar;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace CRMIdeal.Areas.Sms.Controllers;

public class SendTankController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actsmsShowSendTank")]
	public ActionResult Index()
	{
		base.ViewBag.IsBuying = VersionBuyer.SMS;
		base.ViewBag.Delay = 5000;
		return View();
	}

	[AjaxOnly]
	public ActionResult SendTank_Read([DataSourceRequest] DataSourceRequest request, string sendDate)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SmsspSelectSmsReadySend_Result> list = new List<SmsspSelectSmsReadySend_Result>();
		try
		{
			DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59");
			DateTime dateTime = default(DateTime);
			if (!string.IsNullOrEmpty(sendDate))
			{
				sendDate = sendDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				dateTime = lCID switch
				{
					1065 => DateTime.Parse(PersianDate.GetFormatetdDate(sendDate) + " 23:59:59"), 
					1025 => DateTime.Parse(PersianDate.GetFormatetdDate(sendDate) + " 23:59:59", new CultureInfo("ar-SA"), DateTimeStyles.None), 
					_ => DateTime.Parse(PersianDate.GetFormatetdDate(sendDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None), 
				};
			}
			else
			{
				dateTime = DateTime.Now;
			}
			list = Enumerable.ToList<SmsspSelectSmsReadySend_Result>((IEnumerable<SmsspSelectSmsReadySend_Result>)_db.SmsspSelectSmsReadySend(dateTime, lCID, result, UserLogin.CurrentUser.UserId));
			foreach (SmsspSelectSmsReadySend_Result item in list)
			{
				item.SendDate = (item.SendDateTime.HasValue ? item.SendDateTime.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
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

	[AjaxOnly]
	[ValidateInput(false)]
	public JsonResult ActSendSms(string sendDate, string sendTimeFrom, string sendTimeTo)
	{
		string text = "";
		string text2 = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			CRMIdeal.Classes.Helper.Sms sms = new CRMIdeal.Classes.Helper.Sms();
			TimeSpan timeSpan = TimeSpan.Parse(DateTime.Now.ToString("HH:mm"));
			TimeSpan timeSpan2 = TimeSpan.Parse(sendTimeFrom);
			TimeSpan timeSpan3 = TimeSpan.Parse(sendTimeTo);
			string text3 = "";
			if (timeSpan >= timeSpan2 && timeSpan <= timeSpan3)
			{
				text3 = sms.SendSMSTank(sendDate);
			}
			if (!string.IsNullOrWhiteSpace(text3))
			{
				text = "0";
				text2 = text3;
				commonResultStatusViewModel = CommonResultStatusViewModel.Error;
			}
			else
			{
				text = "";
				text2 = "";
				commonResultStatusViewModel = CommonResultStatusViewModel.Success;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = "0";
			text2 = Messages.msgErrorRunFunction;
			commonResultStatusViewModel = CommonResultStatusViewModel.Error;
		}
		CommonResultViewModel<string> data = new CommonResultViewModel<string>
		{
			Data = text,
			Message = text2,
			Status = commonResultStatusViewModel
		};
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		base.Dispose(disposing);
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Helper;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;

namespace CRMIdeal.Controllers;

public class TestCallerIdController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	[LoginAuthorize]
	public ActionResult Index()
	{
		return View();
	}

	public ActionResult SearchList_Read([DataSourceRequest] DataSourceRequest request, string strSearch)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspCallerIDSearch_Result> enumerable = new List<CRMspCallerIDSearch_Result>();
		try
		{
			if (!string.IsNullOrEmpty(strSearch))
			{
				enumerable = Enumerable.ToList<CRMspCallerIDSearch_Result>((IEnumerable<CRMspCallerIDSearch_Result>)_db.CRMspCallerIDSearch(strSearch, lCID, result));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[LoginAuthorize]
	public void ShowCallerId()
	{
		try
		{
			_ = new string[7] { "TrunkCallId", "", "TrunkSource", "TrunkDestination", "TrunkFileLocation", "TrunkDestinationCycle", "" };
			_ = "02174451 " + 1;
			_ = new string[5]
			{
				"",
				"",
				"",
				"",
				"در " + DateTime.Now.ToString("HH:mm:ss") + "          خط: 2\r\nشماره تماس: <span>74451</span>\r\nنام مشتری: شرکت کارا افزار ایده آل    احمدی احمد\r\nنحوه آشنایی: آرشیو\r\nآخرین پروژه و وضعیت: بازاریابی\r\nتماس اولیه و ارسال اطلاعات\r\nمذاکره کننده: امیری\r\n\r\nطرف مذاکره: آقای دکتر رستم زاده "
			};
			new CallerIdAPIController().SendPopupMessage(companyDetailInfo: JsonConvert.SerializeObject(new List<string> { "6156", "17996", "6900", "28120", "تست CallerId به صورت Local" }), username: "Shir", password: "Palang", exten: "303", faced: "host", rejectUsers: "|0|-1|", voipDetailInfo: JsonConvert.SerializeObject(new CallerId.AsteriskCall.Data
			{
				EventType = "NewCallerId",
				CrmCallTypeId = 2,
				Source = "09330615655",
				Destination = "303",
				CalcExtension = "303",
				UId = "123456789.12345",
				CalcTelNumClean = "09330615655",
				CalcLineNumber = 50
			}), langId: 1065);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		base.Dispose(disposing);
	}
}

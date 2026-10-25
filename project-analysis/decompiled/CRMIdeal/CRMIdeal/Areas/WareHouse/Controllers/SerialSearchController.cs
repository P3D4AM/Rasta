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
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace CRMIdeal.Areas.WareHouse.Controllers;

public class SerialSearchController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actwhDocItemSerialSearch")]
	public ActionResult Index()
	{
		return View();
	}

	public ActionResult SerialList_Read([DataSourceRequest] DataSourceRequest request, string strSearch)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspDocItemSerialSearchWeb_Result> list = new List<WSspDocItemSerialSearchWeb_Result>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			list = Enumerable.ToList<WSspDocItemSerialSearchWeb_Result>((IEnumerable<WSspDocItemSerialSearchWeb_Result>)_dbII.WSspDocItemSerialSearchWeb(strSearch, UserLogin.CurrentUser.UserId, lCID, result, result2, 0, 0, 0, ""));
			using List<WSspDocItemSerialSearchWeb_Result>.Enumerator enumerator = list.GetEnumerator();
			WSspDocItemSerialSearchWeb_Result current;
			string docDate;
			for (; enumerator.MoveNext(); current.DocDate = docDate)
			{
				current = enumerator.Current;
				if (!string.IsNullOrEmpty(current.DocDate))
				{
					switch (lCID)
					{
					case 1065:
						break;
					default:
						docDate = DateTime.Parse(PersianDate.GetShamsi2Miladi(current.DocDate.Replace("/", ""))).ToString("yyyyMMdd", new CultureInfo("en-US"));
						continue;
					case 1025:
						docDate = DateTime.Parse(PersianDate.GetShamsi2Miladi(current.DocDate.Replace("/", ""))).ToString("yyyyMMdd", new CultureInfo("ar-SA"));
						continue;
					}
				}
				docDate = current.DocDate;
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

	public JsonResult GetSerialCards(string value, int lastRow, int stockMode, bool serialSelected, bool descriptionSelected, bool infoISelected, bool infoIISelected, bool infoIIISelected, bool infoIVSelected, bool infoVSelected, bool infoVISelected, int pageSize)
	{
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrEmpty(value))
		{
			string checkEmptySerialSearchValue = Messages.CheckEmptySerialSearchValue;
			return Json(new
			{
				message = checkEmptySerialSearchValue
			}, JsonRequestBehavior.AllowGet);
		}
		string text = null;
		text = (serialSelected ? "Serial" : (infoVISelected ? "InfoVI" : (infoISelected ? "InfoI" : (infoIISelected ? "InfoII" : (infoIIISelected ? "InfoIII" : (infoIVSelected ? "InfoIV" : (infoVSelected ? "InfoV" : ((!descriptionSelected) ? "Serial" : "Description"))))))));
		List<object> list = new List<object>();
		if (text != null)
		{
			list.Add(new
			{
				KeyName = text,
				TypeId = 1,
				Value = ""
			});
		}
		string text2 = new JavaScriptSerializer().Serialize((object)list);
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspDocItemSerialSearchWeb_Result> list2 = new List<WSspDocItemSerialSearchWeb_Result>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			CRMSpIIEntities dbII = _dbII;
			int? userId = UserLogin.CurrentUser.UserId;
			int? languageID = lCID;
			int? defaultLanguageID = result;
			int? centerId = result2;
			int? pageSize2 = pageSize;
			string objectJson = text2;
			list2 = Enumerable.ToList<WSspDocItemSerialSearchWeb_Result>((IEnumerable<WSspDocItemSerialSearchWeb_Result>)dbII.WSspDocItemSerialSearchWeb(value, userId, languageID, defaultLanguageID, centerId, pageSize2, lastRow, stockMode, objectJson));
			using (List<WSspDocItemSerialSearchWeb_Result>.Enumerator enumerator = list2.GetEnumerator())
			{
				WSspDocItemSerialSearchWeb_Result current;
				string docDate;
				for (; enumerator.MoveNext(); current.DocDate = docDate)
				{
					current = enumerator.Current;
					if (!string.IsNullOrEmpty(current.DocDate))
					{
						switch (lCID)
						{
						case 1065:
							break;
						default:
							docDate = DateTime.Parse(PersianDate.GetShamsi2Miladi(current.DocDate.Replace("/", ""))).ToString("yyyyMMdd", new CultureInfo("en-US"));
							continue;
						case 1025:
							docDate = DateTime.Parse(PersianDate.GetShamsi2Miladi(current.DocDate.Replace("/", ""))).ToString("yyyyMMdd", new CultureInfo("ar-SA"));
							continue;
						}
					}
					docDate = current.DocDate;
				}
			}
			return Json(list2, JsonRequestBehavior.AllowGet);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(null, JsonRequestBehavior.AllowGet);
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}
}

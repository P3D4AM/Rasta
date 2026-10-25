using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Calendar;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Elmah;

namespace CRMIdeal.Areas.Reports.Controllers;

public class SendLinkController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actrptSendLink")]
	public ActionResult Index()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<int> defaultSystemPartIds = new List<int>(new int[5] { 10, 11, 20, 30, 160 });
		List<CRMspSelectSystemParts_Result> list = Enumerable.ToList<CRMspSelectSystemParts_Result>((IEnumerable<CRMspSelectSystemParts_Result>)_db.CRMspSelectSystemParts(lCID, result));
		list = Enumerable.ToList<CRMspSelectSystemParts_Result>(Enumerable.Where<CRMspSelectSystemParts_Result>((IEnumerable<CRMspSelectSystemParts_Result>)list, (Func<CRMspSelectSystemParts_Result, bool>)((CRMspSelectSystemParts_Result p) => defaultSystemPartIds.Contains(p.SystemPartId))));
		List<SelectListItem> list2 = new List<SelectListItem>();
		list2.Add(new SelectListItem
		{
			Text = Labels.All,
			Value = "0",
			Selected = false
		});
		list2.AddRange(Enumerable.Select<CRMspSelectSystemParts_Result, SelectListItem>((IEnumerable<CRMspSelectSystemParts_Result>)list, (Func<CRMspSelectSystemParts_Result, SelectListItem>)((CRMspSelectSystemParts_Result item) => new SelectListItem
		{
			Text = (item.PartTitle ?? ""),
			Value = item.SystemPartId.ToString(),
			Selected = false
		})));
		base.ViewBag.SystemParts = list2;
		return View();
	}

	public ActionResult GetShortLinks(int pageNumber = 1, int pageSize = 50, int systemPartId = 0, string fDate = null, string tDate = null)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		_ = UserLogin.CurrentUser.UserId;
		CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
		DateTime value = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss"));
		string text = "";
		DateTime? dateTime = null;
		DateTime? dateTime2 = null;
		try
		{
			if (!string.IsNullOrEmpty(fDate) && !string.IsNullOrWhiteSpace(fDate))
			{
				text = PersianDate.GetFormatetdDate(fDate.Replace("/", ""));
				dateTime = lCID switch
				{
					1065 => DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()), 
					1025 => DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")), 
					_ => DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")), 
				};
				text = PersianDate.GetFormatetdDate(tDate.Replace("/", ""));
				dateTime2 = lCID switch
				{
					1065 => DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()), 
					1025 => DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")), 
					_ => DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")), 
				};
			}
			else
			{
				dateTime = null;
				dateTime2 = null;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			dateTime = null;
			dateTime2 = null;
		}
		List<CRMspSelectShortLinksWithPaging_Result> list = Enumerable.ToList<CRMspSelectShortLinksWithPaging_Result>((IEnumerable<CRMspSelectShortLinksWithPaging_Result>)_dbII.CRMspSelectShortLinksWithPaging(null, pageNumber, pageSize, systemPartId, dateTime, dateTime2, null, null, cRMspSelectCrmsysSetting_Result.CrmIPStatic, lCID, result, value));
		foreach (CRMspSelectShortLinksWithPaging_Result item in list)
		{
			item.ExpireDate = (item.ExpireDateTime.HasValue ? item.ExpireDateTime.Value.ToString("yyyy/MM/dd") : "");
			_ = item.FirstRegisterDateTime;
			item.FirstRegisterDate = item.FirstRegisterDateTime.ToString("yyyy/MM/dd");
			item.LastViewDate = (item.LastViewDateTime.HasValue ? item.LastViewDateTime.Value.ToString("yyyy/MM/dd") : "");
		}
		return Json(new
		{
			items = list,
			totalPages = (Enumerable.FirstOrDefault<CRMspSelectShortLinksWithPaging_Result>((IEnumerable<CRMspSelectShortLinksWithPaging_Result>)list)?.AllPage).GetValueOrDefault()
		}, JsonRequestBehavior.AllowGet);
	}

	public ActionResult UpdateShortLink(int shortLinkId)
	{
		try
		{
			CRMspSelectShortLinkById_Result cRMspSelectShortLinkById_Result = Enumerable.FirstOrDefault<CRMspSelectShortLinkById_Result>((IEnumerable<CRMspSelectShortLinkById_Result>)_dbII.CRMspSelectShortLinkById(shortLinkId));
			if (cRMspSelectShortLinkById_Result == null)
			{
				CommonResultViewModel<string> data = new CommonResultViewModel<string>
				{
					Data = "",
					Message = Messages.MsgErrorNotFound,
					Status = CommonResultStatusViewModel.Error
				};
				return Json(data, JsonRequestBehavior.AllowGet);
			}
			return View(cRMspSelectShortLinkById_Result);
		}
		catch (Exception)
		{
			CommonResultViewModel<string> data2 = new CommonResultViewModel<string>
			{
				Data = "",
				Message = Messages.MsgErrorNotFound,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data2, JsonRequestBehavior.AllowGet);
		}
	}

	[HttpPost]
	public ActionResult UpdateShortLink(int shortLinkId = 0, int? maxViewCount = null, bool? inActive = null)
	{
		new CommonResultViewModel<string>();
		maxViewCount = ((maxViewCount != 0) ? maxViewCount : null);
		inActive = ((inActive.HasValue && inActive.Value) ? new bool?(true) : null);
		CRMspSelectShortLinkById_Result model = new CRMspSelectShortLinkById_Result
		{
			ShortLinkId = shortLinkId,
			MaxViewCount = maxViewCount,
			InActive = inActive
		};
		try
		{
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int userId = UserLogin.CurrentUser.UserId;
			string appType = Configuration.AppType;
			if (Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.CRMspUpdateShortLink(shortLinkId, inActive, maxViewCount, value, registerDatePersian, userId, appType)).Result == -1)
			{
				base.ViewBag.Error = Messages.msgNotFound;
				return View(model);
			}
			base.ViewBag.Successfull = Messages.msgSuccessAction;
			return View(model);
		}
		catch (Exception)
		{
			base.ViewBag.Error = Messages.msgErrorRunFunction;
			return View(model);
		}
	}
}

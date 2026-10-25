using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using Elmah;

namespace CRMIdeal.Areas.FormBase.Controllers;

public class SelectUsersMultiController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIIEntities _dbIII = new CRMSpIIIEntities();

	public ActionResult Index(int linkedTypeId, int mode = 1, string resultInputId = "", bool activeInOrder = false, bool activeInQuickOrder = false, bool companySettingDefaultsDisabled = false, string excludeUserIds = "")
	{
		base.ViewBag.resultInputId = resultInputId;
		base.ViewBag.Mode = mode;
		base.ViewBag.LinkedTypeId = linkedTypeId;
		base.ViewBag.ActiveInOrder = activeInOrder;
		base.ViewBag.ActiveInQuickOrder = activeInQuickOrder;
		base.ViewBag.ExcludeUserIds = excludeUserIds;
		base.ViewBag.CompanySettingDefaultsDisabled = companySettingDefaultsDisabled;
		return View();
	}

	[HttpPost]
	public ActionResult GetRecords(int linkedTypeId, int pageNumber, int pageSize, string searchKeyword, string excludeUserIds)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int userId = UserLogin.CurrentUser.UserId;
		List<SelectListItem> list = new List<SelectListItem>();
		int totalCount = 0;
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			CRMSpIIIEntities dbIII = _dbIII;
			int? userId2 = userId;
			int? pageNumber2 = pageNumber;
			int? pageSize2 = pageSize;
			int? centerId = result2;
			bool? isActive = true;
			List<CRMspSelectUsersWithPaging_Result> list2 = Enumerable.ToList<CRMspSelectUsersWithPaging_Result>((IEnumerable<CRMspSelectUsersWithPaging_Result>)dbIII.CRMspSelectUsersWithPaging(userId2, pageNumber2, pageSize2, centerId, null, isActive, searchKeyword, lCID, result, linkedTypeId, excludeUserIds));
			list.AddRange(Enumerable.Select<CRMspSelectUsersWithPaging_Result, SelectListItem>((IEnumerable<CRMspSelectUsersWithPaging_Result>)list2, (Func<CRMspSelectUsersWithPaging_Result, SelectListItem>)((CRMspSelectUsersWithPaging_Result item) => new SelectListItem
			{
				Text = item.LName + " " + item.FName,
				Value = item.UserId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(new
		{
			Data = list,
			TotalCount = totalCount
		}, JsonRequestBehavior.AllowGet);
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbI.Dispose();
		_dbIII.Dispose();
		base.Dispose(disposing);
	}
}

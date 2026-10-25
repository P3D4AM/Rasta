using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.Models;
using CRM.Models.ViewModel.Targeting;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Targeting.Controllers;

public class ReportController : Controller
{
	private CRMSpEntities _db = new CRMSpEntities();

	private CRMSpIEntities _dbI = new CRMSpIEntities();

	private CRMSpIIEntities _dbII = new CRMSpIIEntities();

	private CRMSpIIIEntities _dbIII = new CRMSpIIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSalesTargetReport")]
	public ActionResult SalesTargetReport()
	{
		DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
		_ = UserLogin.CurrentUser.UserId;
		_ = Configuration.AppType;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectSaleTargets_Result> list = Enumerable.ToList<WSspSelectSaleTargets_Result>((IEnumerable<WSspSelectSaleTargets_Result>)_dbIII.WSspSelectSaleTargets(0, lCID, result));
		List<SelectListItem> list2 = new List<SelectListItem>();
		list2.AddRange(Enumerable.ToList<SelectListItem>(Enumerable.Select<WSspSelectSaleTargets_Result, SelectListItem>((IEnumerable<WSspSelectSaleTargets_Result>)list, (Func<WSspSelectSaleTargets_Result, SelectListItem>)((WSspSelectSaleTargets_Result item) => new SelectListItem
		{
			Text = item.TargetTitle,
			Value = item.SalesTargetId.ToString(),
			Selected = false
		}))));
		base.ViewBag.SalesTargets = list2;
		return View();
	}

	[HttpPost]
	public JsonResult GetSalesTargetReports(int salesTargetId, int pageSize)
	{
		DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
		_ = Configuration.AppType;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int result2 = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
		}
		try
		{
			_ = UserLogin.CurrentUser;
			WSspSelectSalesTarget_Result wSspSelectSalesTarget_Result = Enumerable.FirstOrDefault<WSspSelectSalesTarget_Result>((IEnumerable<WSspSelectSalesTarget_Result>)_dbIII.WSspSelectSalesTarget(salesTargetId, lCID, result));
			WSspChartSalesTargetReport_Result wSspChartSalesTargetReport_Result = null;
			List<WSspChartSalesTargetDistributionReport_Result> distribution = null;
			List<WSspSelectOrdersForSalesTarget_Result> list = null;
			SalesTargetViewModel salesTargetViewModel = null;
			int num = 0;
			if (wSspSelectSalesTarget_Result != null)
			{
				List<CRMspSelectUsers_Result> list2 = Enumerable.ToList<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)_db.CRMspSelectUsers(lCID, result, result2));
				_ = wSspSelectSalesTarget_Result.TargetFromDate;
				string targetFromDate = DateTimeClass.GetLocalDate(wSspSelectSalesTarget_Result.TargetFromDate).Value.ToString("yyyy/MM/dd");
				_ = wSspSelectSalesTarget_Result.TargetToDate;
				string targetToDate = DateTimeClass.GetLocalDate(wSspSelectSalesTarget_Result.TargetToDate).Value.ToString("yyyy/MM/dd");
				SalesTargetUserScopeViewModel salesTargetUserScopeViewModel = new SalesTargetUserScopeViewModel();
				if (!string.IsNullOrEmpty(wSspSelectSalesTarget_Result.TargetUserScopeJson))
				{
					salesTargetUserScopeViewModel = JsonConvert.DeserializeObject<SalesTargetUserScopeViewModel>(wSspSelectSalesTarget_Result.TargetUserScopeJson);
				}
				if (salesTargetUserScopeViewModel != null && salesTargetUserScopeViewModel.Key == 2 && !string.IsNullOrEmpty(salesTargetUserScopeViewModel.DepartmentId))
				{
					int result3 = 0;
					if (int.TryParse(salesTargetUserScopeViewModel.DepartmentId, out result3))
					{
						salesTargetUserScopeViewModel.DepartmentName = Enumerable.FirstOrDefault<CRMspSelectUserDepartmentById_Result>((IEnumerable<CRMspSelectUserDepartmentById_Result>)_dbI.CRMspSelectUserDepartmentById(result3, lCID, result))?.Department ?? "";
					}
				}
				if (salesTargetUserScopeViewModel != null && salesTargetUserScopeViewModel.Key == 3 && salesTargetUserScopeViewModel.SelectedUsers != null)
				{
					foreach (SalesTargetUserScopeSelectedItem selectedUser in salesTargetUserScopeViewModel.SelectedUsers)
					{
						if (string.IsNullOrEmpty(selectedUser.Val))
						{
							continue;
						}
						int userId = 0;
						if (int.TryParse(selectedUser.Val, out userId))
						{
							CRMspSelectUsers_Result cRMspSelectUsers_Result = Enumerable.FirstOrDefault<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)list2, (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result u) => u.UserId == userId));
							selectedUser.Text = cRMspSelectUsers_Result?.LName + " " + cRMspSelectUsers_Result?.FName;
						}
					}
				}
				salesTargetViewModel = new SalesTargetViewModel
				{
					SalesTargetId = wSspSelectSalesTarget_Result.SalesTargetId,
					TargetTitle = wSspSelectSalesTarget_Result.TargetTitle,
					TargetOrderCount = wSspSelectSalesTarget_Result.TargetOrderCount,
					TargetOrderAmount = wSspSelectSalesTarget_Result.TargetOrderAmount,
					TargetFromDateTime = wSspSelectSalesTarget_Result.TargetFromDate,
					TargetToDateTime = wSspSelectSalesTarget_Result.TargetToDate,
					TargetFromDate = targetFromDate,
					TargetToDate = targetToDate,
					RegisterDateTime = wSspSelectSalesTarget_Result.RegisterDate,
					TargetDistributionDetailsJson = wSspSelectSalesTarget_Result.TargetDistributionDetailsJson,
					TargetTermsJson = wSspSelectSalesTarget_Result.TargetTermsJson,
					TargetUserScopeJson = JsonConvert.SerializeObject(salesTargetUserScopeViewModel)
				};
				wSspChartSalesTargetReport_Result = Enumerable.FirstOrDefault<WSspChartSalesTargetReport_Result>((IEnumerable<WSspChartSalesTargetReport_Result>)_dbIII.WSspChartSalesTargetReport(salesTargetId, result2, lCID, result));
				if (!string.IsNullOrEmpty(wSspSelectSalesTarget_Result.TargetDistributionDetailsJson))
				{
					distribution = Enumerable.ToList<WSspChartSalesTargetDistributionReport_Result>((IEnumerable<WSspChartSalesTargetDistributionReport_Result>)_dbIII.WSspChartSalesTargetDistributionReport(salesTargetId, result2, lCID, result));
				}
				list = Enumerable.ToList<WSspSelectOrdersForSalesTarget_Result>((IEnumerable<WSspSelectOrdersForSalesTarget_Result>)_dbIII.WSspSelectOrdersForSalesTarget(salesTargetId, result2, lCID, result, UserLogin.CurrentUser.UserId, 1, pageSize));
				num = (Enumerable.FirstOrDefault<WSspSelectOrdersForSalesTarget_Result>((IEnumerable<WSspSelectOrdersForSalesTarget_Result>)list)?.TotalCount).GetValueOrDefault();
				foreach (WSspSelectOrdersForSalesTarget_Result item in list)
				{
					item.ordDate = (item.ordDateTime.HasValue ? DateTimeClass.GetLocalDate(item.ordDateTime).Value.ToString("yyyy/MM/dd") : "");
				}
				return Json(new
				{
					success = true,
					overall = wSspChartSalesTargetReport_Result,
					distribution = distribution,
					salesTarget = salesTargetViewModel,
					ordersData = list,
					ordersTotalCount = num
				}, JsonRequestBehavior.AllowGet);
			}
			return Json(new
			{
				success = false,
				message = Messages.msgSalesTargetNotFound
			}, JsonRequestBehavior.AllowGet);
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			return Json(new
			{
				success = false,
				message = ex.Message
			}, JsonRequestBehavior.AllowGet);
		}
	}

	[HttpPost]
	public JsonResult GetOrdersForSalesTarget(int salesTargetId, int pageNumber = 1, int pageSize = 20)
	{
		DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
		_ = Configuration.AppType;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int result2 = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
		}
		try
		{
			List<WSspSelectOrdersForSalesTarget_Result> list = Enumerable.ToList<WSspSelectOrdersForSalesTarget_Result>((IEnumerable<WSspSelectOrdersForSalesTarget_Result>)_dbIII.WSspSelectOrdersForSalesTarget(salesTargetId, result2, lCID, result, UserLogin.CurrentUser.UserId, pageNumber, pageSize));
			int valueOrDefault = (Enumerable.FirstOrDefault<WSspSelectOrdersForSalesTarget_Result>((IEnumerable<WSspSelectOrdersForSalesTarget_Result>)list)?.TotalCount).GetValueOrDefault();
			foreach (WSspSelectOrdersForSalesTarget_Result item in list)
			{
				item.ordDate = (item.ordDateTime.HasValue ? DateTimeClass.GetLocalDate(item.ordDateTime).Value.ToString("yyyy/MM/dd") : "");
			}
			return Json(new
			{
				success = true,
				data = list,
				totalCount = valueOrDefault
			}, JsonRequestBehavior.AllowGet);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Json(new
			{
				success = false,
				data = new { },
				totalCount = 0
			}, JsonRequestBehavior.AllowGet);
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

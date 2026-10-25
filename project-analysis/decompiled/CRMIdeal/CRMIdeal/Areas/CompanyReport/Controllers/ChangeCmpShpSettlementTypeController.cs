using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Elmah;

namespace CRMIdeal.Areas.CompanyReport.Controllers;

public class ChangeCmpShpSettlementTypeController : Controller
{
	private CRMSpEntities _db = new CRMSpEntities();

	private CRMSpIEntities _dbI = new CRMSpIEntities();

	[DynamicAuthorize(ControllerName = "frmCompanyReport", ActionName = "actcmpChangeShpSettlementType")]
	public ActionResult Index()
	{
		base.ViewBag.IsBuying = VersionBuyer.FoShop;
		GetShpSettlementTypes();
		GetShpSettlementCreditIssueType();
		return View();
	}

	[AjaxOnly]
	public JsonResult ActChangeCmpShpSettlementType(int cmpShpSettlementTypeId = 0, int cmpShpSettlementCreditIssueType = 0, decimal cmpShpSettlementCreditPerBuy = 0m, decimal cmpShpSettlementTotalCredit = 0m, bool cmpShpSettlementCreditRemainShow = false)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel();
		try
		{
			if (!VersionBuyer.FoShop)
			{
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = Messages.VersionBuy;
				commonReturnResultViewModel.Tag = "BV|";
				return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			_ = Financial.Get().Id;
			int userId = UserLogin.CurrentUser.UserId;
			short value3 = short.Parse(Financial.Get().Id.ToString());
			_dbI.CRMspUpdateCompanyShpSettlementTypeFromRptFilterData((cmpShpSettlementTypeId != 0) ? new int?(cmpShpSettlementTypeId) : null, (cmpShpSettlementCreditIssueType != 0) ? new int?(cmpShpSettlementCreditIssueType) : null, (cmpShpSettlementCreditPerBuy != 0m) ? new decimal?(cmpShpSettlementCreditPerBuy) : null, (cmpShpSettlementTotalCredit != 0m) ? new decimal?(cmpShpSettlementTotalCredit) : null, cmpShpSettlementCreditRemainShow, userId, value, registerDatePersian, value3, value2, appType);
			commonReturnResultViewModel.IsDone = true;
			commonReturnResultViewModel.Message = Messages.msgOperationCompleted;
			commonReturnResultViewModel.Tag = "";
		}
		catch (Exception e)
		{
			commonReturnResultViewModel.IsDone = false;
			ErrorSignal.FromCurrentContext().Raise(e);
			commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
		}
		JsonResult jsonResult = Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetShpSettlementTypes()
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
			List<CRMspSelectShpSettlementTypes_Result> list2 = Enumerable.ToList<CRMspSelectShpSettlementTypes_Result>((IEnumerable<CRMspSelectShpSettlementTypes_Result>)_dbI.CRMspSelectShpSettlementTypes(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectShpSettlementTypes_Result, SelectListItem>((IEnumerable<CRMspSelectShpSettlementTypes_Result>)list2, (Func<CRMspSelectShpSettlementTypes_Result, SelectListItem>)((CRMspSelectShpSettlementTypes_Result item) => new SelectListItem
			{
				Text = (item.ShpSettlementType ?? ""),
				Value = item.ShpSettlementTypeId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ShpSettlementTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetShpSettlementCreditIssueType()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			list.Add(new SelectListItem
			{
				Text = Labels.SelectItem1,
				Value = "",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.lblPOrd,
				Value = "20",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = "lblOrd".OrderLabels(),
				Value = "30",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.lblPOrd + " - " + "lblOrd".OrderLabels(),
				Value = "-100",
				Selected = false
			});
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ShpSettlementCreditIssueTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Calendar;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace CRMIdeal.Areas.Letters.Controllers;

public class IndicatorController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actltrLetterIndicator")]
	public ActionResult Index(int position = 0, int cmpId = 0, string cmpName = "")
	{
		string text = "";
		string text2 = "";
		if (position == 0)
		{
			text = "frmMain";
			text2 = "actltrLetterIndicator";
			if (!UserLogin.IsUserAccess(text, text2, UserLogin.CurrentUser))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			LetterIndicatorViewModel model = new LetterIndicatorViewModel
			{
				LetterCompanyNameId = cmpId.ToString(),
				LetterCompanyName = cmpName
			};
			GetLetterType();
			GetLetterRegUsers();
			GetLetterVerifierUsers();
			GetLetterNumberCounter();
			GetVerificationWorkFlow();
			base.ViewBag.CmpId = cmpId;
			return View(model);
		}
		return RedirectToAction("Login", "Account", (object)new
		{
			area = "",
			d = DateTime.Now
		});
	}

	[AjaxOnly]
	public JsonResult GetLetterType()
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
			List<SecspSelectLetterTypes_Result> list2 = Enumerable.ToList<SecspSelectLetterTypes_Result>((IEnumerable<SecspSelectLetterTypes_Result>)_db.SecspSelectLetterTypes(lCID, result));
			list.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			list.AddRange(Enumerable.Select<SecspSelectLetterTypes_Result, SelectListItem>((IEnumerable<SecspSelectLetterTypes_Result>)list2, (Func<SecspSelectLetterTypes_Result, SelectListItem>)((SecspSelectLetterTypes_Result item) => new SelectListItem
			{
				Text = item.LetterTypeTitle,
				Value = item.LetterTypeId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.TypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetLetterRegUsers()
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<SecspLetterIndicatorRegUsers_Result> list2 = Enumerable.ToList<SecspLetterIndicatorRegUsers_Result>((IEnumerable<SecspLetterIndicatorRegUsers_Result>)_db.SecspLetterIndicatorRegUsers(UserLogin.CurrentUser.UserId, lCID, result, result2));
			list.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			list.AddRange(Enumerable.Select<SecspLetterIndicatorRegUsers_Result, SelectListItem>((IEnumerable<SecspLetterIndicatorRegUsers_Result>)list2, (Func<SecspLetterIndicatorRegUsers_Result, SelectListItem>)((SecspLetterIndicatorRegUsers_Result item) => new SelectListItem
			{
				Text = item.UserName,
				Value = item.UserId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.RegUsersList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetLetterVerifierUsers()
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<SecspLetterIndicatorVerifierUsers_Result> list2 = Enumerable.ToList<SecspLetterIndicatorVerifierUsers_Result>((IEnumerable<SecspLetterIndicatorVerifierUsers_Result>)_db.SecspLetterIndicatorVerifierUsers(UserLogin.CurrentUser.UserId, lCID, result, result2));
			list.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			list.AddRange(Enumerable.Select<SecspLetterIndicatorVerifierUsers_Result, SelectListItem>((IEnumerable<SecspLetterIndicatorVerifierUsers_Result>)list2, (Func<SecspLetterIndicatorVerifierUsers_Result, SelectListItem>)((SecspLetterIndicatorVerifierUsers_Result item) => new SelectListItem
			{
				Text = item.UserName,
				Value = item.UserId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.VerifierUsersList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCompany(string value = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SecspLetterIndicatorCmpSearch_Result> data = new List<SecspLetterIndicatorCmpSearch_Result>();
		try
		{
			data = Enumerable.ToList<SecspLetterIndicatorCmpSearch_Result>((IEnumerable<SecspLetterIndicatorCmpSearch_Result>)_db.SecspLetterIndicatorCmpSearch(value, lCID, result));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetLetterNumberCounter()
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
			List<SecspSelectLetterNumberCounter_Result> list2 = Enumerable.ToList<SecspSelectLetterNumberCounter_Result>((IEnumerable<SecspSelectLetterNumberCounter_Result>)_dbI.SecspSelectLetterNumberCounter(lCID, result));
			list.AddRange(Enumerable.Select<SecspSelectLetterNumberCounter_Result, SelectListItem>((IEnumerable<SecspSelectLetterNumberCounter_Result>)list2, (Func<SecspSelectLetterNumberCounter_Result, SelectListItem>)((SecspSelectLetterNumberCounter_Result item) => new SelectListItem
			{
				Text = item.LtrNumCntTitle + ((!string.IsNullOrWhiteSpace(item.LetterType)) ? (" (" + item.LetterType + ")") : ""),
				Value = item.LetterNumberCounterId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.LetterNumberCounterList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetVerificationWorkFlow()
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
			List<WSspSelectVerificationWorkFlowWithObjectType_Result> list2 = Enumerable.ToList<WSspSelectVerificationWorkFlowWithObjectType_Result>((IEnumerable<WSspSelectVerificationWorkFlowWithObjectType_Result>)_db.WSspSelectVerificationWorkFlowWithObjectType(110, lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectVerificationWorkFlowWithObjectType_Result, SelectListItem>((IEnumerable<WSspSelectVerificationWorkFlowWithObjectType_Result>)list2, (Func<WSspSelectVerificationWorkFlowWithObjectType_Result, SelectListItem>)((WSspSelectVerificationWorkFlowWithObjectType_Result item) => new SelectListItem
			{
				Text = item.VerificationWorkFlowTitle,
				Value = item.VerificationWorkFlowId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.VerificationWorkFlowList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetVerificationWorkflowStep(int workflowId)
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
			List<WSspSelectVerificationWorkFlowSteps_Result> list2 = Enumerable.ToList<WSspSelectVerificationWorkFlowSteps_Result>((IEnumerable<WSspSelectVerificationWorkFlowSteps_Result>)_db.WSspSelectVerificationWorkFlowSteps(workflowId, lCID, result));
			list.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			list.AddRange(Enumerable.Select<WSspSelectVerificationWorkFlowSteps_Result, SelectListItem>((IEnumerable<WSspSelectVerificationWorkFlowSteps_Result>)list2, (Func<WSspSelectVerificationWorkFlowSteps_Result, SelectListItem>)((WSspSelectVerificationWorkFlowSteps_Result item) => new SelectListItem
			{
				Text = item.VerificationWorkFlowStepTitle,
				Value = item.VerificationWorkFlowStepId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmLetterIndicator", ActionName = "actConfirm")]
	[AjaxOnly]
	public JsonResult LetterIndicator(LetterIndicatorViewModel indicator)
	{
		return Json(LetterIndicatorItem(indicator), JsonRequestBehavior.AllowGet);
	}

	public IndicatorLetterItem LetterIndicatorItem(LetterIndicatorViewModel indicator)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		IndicatorLetterItem indicatorLetterItem = new IndicatorLetterItem();
		List<mct_SecspLetterIndicator_Result> items = new List<mct_SecspLetterIndicator_Result>();
		indicatorLetterItem.Items = items;
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (indicator != null)
			{
				indicator.LetterTypeId = (string.IsNullOrEmpty(indicator.LetterTypeId) ? "0" : indicator.LetterTypeId);
				indicator.LetterFDate = ((!string.IsNullOrEmpty(indicator.LetterFDate)) ? indicator.LetterFDate.Replace("/", "") : "0");
				indicator.LetterTDate = ((!string.IsNullOrEmpty(indicator.LetterTDate)) ? indicator.LetterTDate.Replace("/", "") : "0");
				indicator.LetterPreNumber = (string.IsNullOrEmpty(indicator.LetterPreNumber) ? "" : indicator.LetterPreNumber);
				indicator.LetterNumber = (string.IsNullOrEmpty(indicator.LetterNumber) ? "" : indicator.LetterNumber);
				indicator.LetterNumberII = (string.IsNullOrEmpty(indicator.LetterNumberII) ? "" : indicator.LetterNumberII);
				indicator.LetterAnnex = (string.IsNullOrEmpty(indicator.LetterAnnex) ? "" : indicator.LetterAnnex);
				indicator.LetterAnnexLikelyStr = (indicator.LetterAnnexLikely ? "1" : "0");
				switch (indicator.LetterAnnex)
				{
				case "#Have":
				case "#دارد":
				case "#يملك":
					indicator.LetterAnnex = "-2";
					break;
				case "#HaveNot":
				case "#ندارد":
				case "#لا يملك":
					indicator.LetterAnnex = "-1";
					break;
				}
				indicator.LetterSubject = (string.IsNullOrEmpty(indicator.LetterSubject) ? "" : indicator.LetterSubject);
				indicator.LetterSubjectLikelyStr = (indicator.LetterSubjectLikely ? "1" : "0");
				switch (indicator.LetterSubject)
				{
				case "#Have":
				case "#دارد":
				case "#يملك":
					indicator.LetterSubject = "-2";
					break;
				case "#HaveNot":
				case "#ندارد":
				case "#لا يملك":
					indicator.LetterSubject = "-1";
					break;
				}
				indicator.LetterHeader = (string.IsNullOrEmpty(indicator.LetterHeader) ? "" : indicator.LetterHeader);
				indicator.LetterHeaderLikelyStr = (indicator.LetterHeaderLikely ? "1" : "0");
				switch (indicator.LetterHeader)
				{
				case "#Have":
				case "#دارد":
				case "#يملك":
					indicator.LetterHeader = "-2";
					break;
				case "#HaveNot":
				case "#ندارد":
				case "#لا يملك":
					indicator.LetterHeader = "-1";
					break;
				}
				indicator.LetterContext = (string.IsNullOrEmpty(indicator.LetterContext) ? "" : indicator.LetterContext);
				indicator.LetterContextLikelyStr = (indicator.LetterContextLikely ? "1" : "0");
				switch (indicator.LetterContext)
				{
				case "#Have":
				case "#دارد":
				case "#يملك":
					indicator.LetterContext = "-2";
					break;
				case "#HaveNot":
				case "#ندارد":
				case "#لا يملك":
					indicator.LetterContext = "-1";
					break;
				}
				indicator.LetterFooter = (string.IsNullOrEmpty(indicator.LetterFooter) ? "" : indicator.LetterFooter);
				indicator.LetterFooterLikelyStr = (indicator.LetterFooterLikely ? "1" : "0");
				switch (indicator.LetterFooter)
				{
				case "#Have":
				case "#دارد":
				case "#يملك":
					indicator.LetterFooter = "-2";
					break;
				case "#HaveNot":
				case "#ندارد":
				case "#لا يملك":
					indicator.LetterFooter = "-1";
					break;
				}
				indicator.LetterRegUsersId = (string.IsNullOrEmpty(indicator.LetterRegUsersId) ? "0" : indicator.LetterRegUsersId);
				indicator.LetterVerifierId = (string.IsNullOrEmpty(indicator.LetterVerifierId) ? "0" : indicator.LetterVerifierId);
				indicator.LetterRegFDate = ((!string.IsNullOrEmpty(indicator.LetterRegFDate)) ? indicator.LetterRegFDate.Replace("/", "") : "0");
				indicator.LetterRegTDate = ((!string.IsNullOrEmpty(indicator.LetterRegTDate)) ? indicator.LetterRegTDate.Replace("/", "") : "0");
				indicator.LetterPrintFDate = ((!string.IsNullOrEmpty(indicator.LetterPrintFDate)) ? indicator.LetterPrintFDate.Replace("/", "") : "0");
				indicator.LetterPrintTDate = ((!string.IsNullOrEmpty(indicator.LetterPrintTDate)) ? indicator.LetterPrintTDate.Replace("/", "") : "0");
				indicator.LetterVerifyStatusId = (string.IsNullOrEmpty(indicator.LetterVerifyStatusId) ? "-1" : indicator.LetterVerifyStatusId);
				indicator.LetterPrintStatusId = (string.IsNullOrEmpty(indicator.LetterPrintStatusId) ? "-1" : indicator.LetterPrintStatusId);
				indicator.LetterNumberCounterId = (string.IsNullOrEmpty(indicator.LetterNumberCounterId) ? "0" : indicator.LetterNumberCounterId);
				indicator.LetterIndicatorVerificationWorkflowId = (string.IsNullOrEmpty(indicator.LetterIndicatorVerificationWorkflowId) ? "0" : indicator.LetterIndicatorVerificationWorkflowId);
				indicator.LetterIndicatorVerificationWorkflowStepId = (string.IsNullOrEmpty(indicator.LetterIndicatorVerificationWorkflowStepId) ? "0" : indicator.LetterIndicatorVerificationWorkflowStepId);
				DateTime value = DateTime.Now;
				DateTime value2 = DateTime.Now;
				DateTime value3 = DateTime.Now;
				DateTime value4 = DateTime.Now;
				DateTime value5 = DateTime.Now;
				DateTime value6 = DateTime.Now;
				if (!string.IsNullOrEmpty(indicator.LetterFDate) && indicator.LetterFDate != "0")
				{
					value = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.LetterFDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.LetterTDate) && indicator.LetterTDate != "0")
				{
					value2 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.LetterTDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.LetterRegFDate) && indicator.LetterRegFDate != "0")
				{
					value3 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.LetterRegFDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.LetterRegTDate) && indicator.LetterRegTDate != "0")
				{
					value4 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.LetterRegTDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.LetterPrintFDate) && indicator.LetterPrintFDate != "0")
				{
					value5 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.LetterPrintFDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.LetterPrintTDate) && indicator.LetterPrintTDate != "0")
				{
					value6 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.LetterPrintTDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				DayOfWeek dayOfWeek = DateTime.Now.DayOfWeek;
				items = Enumerable.ToList<mct_SecspLetterIndicator_Result>((IEnumerable<mct_SecspLetterIndicator_Result>)_db.mfi_SecspLetterIndicator(indicator.LetterTypeId, indicator.LetterFDate, indicator.LetterTDate, indicator.LetterPreNumber, indicator.LetterNumber, indicator.LetterNumberII, indicator.LetterAnnex, indicator.LetterAnnexLikelyStr, indicator.LetterCompanyNameId, indicator.LetterSubject, indicator.LetterSubjectLikelyStr, indicator.LetterHeader, indicator.LetterHeaderLikelyStr, indicator.LetterContext, indicator.LetterContextLikelyStr, indicator.LetterFooter, indicator.LetterFooterLikelyStr, indicator.LetterRegUsersId, indicator.LetterVerifierId, indicator.LetterRegFDate, indicator.LetterRegTDate, indicator.LetterPrintFDate, indicator.LetterPrintTDate, indicator.LetterVerifyStatusId, indicator.LetterPrintStatusId, UserLogin.CurrentUser.UserId.ToString(), DateTime.Now.ToString("yyyy/MM/dd", new PersianCulture()), DateTimeClass.DefineDayeOfWeekPersian(dayOfWeek.ToString()), lCID, result, value, value2, value3, value4, value5, value6, indicator.LetterNumberCounterId, indicator.LetterIndicatorVerificationWorkflowId, indicator.LetterIndicatorVerificationWorkflowStepId, result2));
				foreach (mct_SecspLetterIndicator_Result item in items)
				{
					item.AppType = ConverDateTimeToTime(item.LetterDateTime);
					if (lCID != 1065)
					{
						if (!string.IsNullOrEmpty(item.LetterDate))
						{
							item.LetterDate = PersianDate.GetShamsi2Miladi(item.LetterDate.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrEmpty(item.LetterLastPrintDate))
						{
							item.LetterLastPrintDate = PersianDate.GetShamsi2Miladi(item.LetterLastPrintDate.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrEmpty(item.LetterVerifiedRegisterDatePersian))
						{
							item.LetterVerifiedRegisterDatePersian = PersianDate.GetShamsi2Miladi(item.LetterVerifiedRegisterDatePersian.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrEmpty(item.FirstRegisterDatePersian))
						{
							item.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(item.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrEmpty(item.RegisterDatePersian))
						{
							item.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item.RegisterDatePersian.Replace("/", "")).Replace("/", "");
						}
					}
				}
				indicatorLetterItem.Items = items;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return indicatorLetterItem;
	}

	public ActionResult LetterIndicator_Read([DataSourceRequest] DataSourceRequest request, string indicator)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		LetterIndicatorViewModel indicator2 = new JavaScriptSerializer().Deserialize<LetterIndicatorViewModel>(indicator);
		IndicatorLetterItem indicatorLetterItem = LetterIndicatorItem(indicator2);
		return Json(((IEnumerable)indicatorLetterItem.Items).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	public string ConverDateTimeToTime(DateTime? date)
	{
		DateTime result = default(DateTime);
		string result2 = "";
		if (date.HasValue)
		{
			DateTime.TryParse(date.ToString(), out result);
			result2 = result.ToString("HH:mm:ss");
		}
		return result2;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}

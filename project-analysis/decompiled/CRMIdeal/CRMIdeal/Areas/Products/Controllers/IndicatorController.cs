using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Calendar;
using CRM.General.IO.FTP;
using CRM.General.Security;
using CRM.General.Utilities;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Cache.User;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Products.Controllers;

public class IndicatorController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIIIEntities _dbIII = new CRMSpIIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actPrdValidityIndicator")]
	[LoginAuthorize]
	public ActionResult Index()
	{
		ProductValidityIndicatorViewModel model = new ProductValidityIndicatorViewModel();
		GetProductValidity();
		GetOrderOpr();
		GetPreOrderOpr();
		GetPreOrderType();
		GetPordReferUser();
		return View(model);
	}

	[AjaxOnly]
	public JsonResult GetOrderOpr()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<WSspSelectOrderOpr_Result> list2 = Order.SelectOrderOpr();
			list.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<WSspSelectOrderOpr_Result, SelectListItem>((IEnumerable<WSspSelectOrderOpr_Result>)list2, (Func<WSspSelectOrderOpr_Result, SelectListItem>)((WSspSelectOrderOpr_Result item) => new SelectListItem
				{
					Text = item.Name,
					Value = item.OrderOprID.ToString(),
					Selected = false
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.OrderOprList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPreOrderOpr()
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
			List<WSspSelectPreOrderOpr_Result> list2 = Enumerable.ToList<WSspSelectPreOrderOpr_Result>((IEnumerable<WSspSelectPreOrderOpr_Result>)_db.WSspSelectPreOrderOpr(lCID, result));
			list.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			list.AddRange(Enumerable.Select<WSspSelectPreOrderOpr_Result, SelectListItem>((IEnumerable<WSspSelectPreOrderOpr_Result>)list2, (Func<WSspSelectPreOrderOpr_Result, SelectListItem>)((WSspSelectPreOrderOpr_Result item) => new SelectListItem
			{
				Text = item.PreOrderOpr,
				Value = item.PreOrderOprID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PreOrderOprList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPreOrderType()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<WSspSelectPreOrderTypes_Result> list2 = PreOrder.SelectPreOrderTypes();
			list.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<WSspSelectPreOrderTypes_Result, SelectListItem>((IEnumerable<WSspSelectPreOrderTypes_Result>)list2, (Func<WSspSelectPreOrderTypes_Result, SelectListItem>)((WSspSelectPreOrderTypes_Result item) => new SelectListItem
				{
					Text = item.PreOrderType,
					Value = item.PreOrderTypeId.ToString(),
					Selected = false
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PreOrderTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetProductValidity()
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
			List<WSspSelectProductValidity_Result> list2 = Enumerable.ToList<WSspSelectProductValidity_Result>((IEnumerable<WSspSelectProductValidity_Result>)_dbI.WSspSelectProductValidity(lCID, result));
			list.Add(new SelectListItem
			{
				Text = Labels.All,
				Value = "",
				Selected = false
			});
			list.AddRange(Enumerable.Select<WSspSelectProductValidity_Result, SelectListItem>((IEnumerable<WSspSelectProductValidity_Result>)list2, (Func<WSspSelectProductValidity_Result, SelectListItem>)((WSspSelectProductValidity_Result item) => new SelectListItem
			{
				Text = item.PrdName,
				Value = item.ProductID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ProductValidityList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetProjectTitles()
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
			List<CRMspSelectProjectTitles_Result> list2 = Enumerable.ToList<CRMspSelectProjectTitles_Result>((IEnumerable<CRMspSelectProjectTitles_Result>)_db.CRMspSelectProjectTitles(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectProjectTitles_Result, SelectListItem>((IEnumerable<CRMspSelectProjectTitles_Result>)list2, (Func<CRMspSelectProjectTitles_Result, SelectListItem>)((CRMspSelectProjectTitles_Result item) => new SelectListItem
			{
				Text = (item.ProjectTitle ?? ""),
				Value = (item.ProjectTitle ?? ""),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult GetProjectTitles_Lang(int currLangID)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<CRMspSelectProjectTitles_Result> list2 = Enumerable.ToList<CRMspSelectProjectTitles_Result>((IEnumerable<CRMspSelectProjectTitles_Result>)_db.CRMspSelectProjectTitles(currLangID, result));
			list.AddRange(Enumerable.Select<CRMspSelectProjectTitles_Result, SelectListItem>((IEnumerable<CRMspSelectProjectTitles_Result>)list2, (Func<CRMspSelectProjectTitles_Result, SelectListItem>)((CRMspSelectProjectTitles_Result item) => new SelectListItem
			{
				Text = (item.ProjectTitle ?? ""),
				Value = (item.ProjectTitle ?? ""),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPordDefSetting(int? id = null)
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
			int userId = UserLogin.CurrentUser.UserId;
			List<WSspSelectPreOrderDefaultSettingUserAccess_Result> list2 = Enumerable.ToList<WSspSelectPreOrderDefaultSettingUserAccess_Result>((IEnumerable<WSspSelectPreOrderDefaultSettingUserAccess_Result>)_dbIII.WSspSelectPreOrderDefaultSettingUserAccess(userId, lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectPreOrderDefaultSettingUserAccess_Result, SelectListItem>((IEnumerable<WSspSelectPreOrderDefaultSettingUserAccess_Result>)list2, (Func<WSspSelectPreOrderDefaultSettingUserAccess_Result, SelectListItem>)((WSspSelectPreOrderDefaultSettingUserAccess_Result item) => new SelectListItem
			{
				Text = item.SettingTitle,
				Value = item.PreOrderSettingID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PordDefSettingList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPordReferUser()
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectUserForLinkedTypeIsActive_Result> list2 = Enumerable.ToList<CRMspSelectUserForLinkedTypeIsActive_Result>((IEnumerable<CRMspSelectUserForLinkedTypeIsActive_Result>)_dbI.CRMspSelectUserForLinkedTypeIsActive(UserLogin.CurrentUser.UserId, 7, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectUserForLinkedTypeIsActive_Result, SelectListItem>((IEnumerable<CRMspSelectUserForLinkedTypeIsActive_Result>)list2, (Func<CRMspSelectUserForLinkedTypeIsActive_Result, SelectListItem>)((CRMspSelectUserForLinkedTypeIsActive_Result item) => new SelectListItem
			{
				Text = item.UserName,
				Value = item.LinkedUserId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ReferUserList = list;
		base.ViewBag.CnvsReferUserList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCompanyProject(int cmpId, int referUserId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectCrmProjectBycmpAndUser_Result> list = new List<WSspSelectCrmProjectBycmpAndUser_Result>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<WSspSelectCrmProjectBycmpAndUser_Result> list2 = Enumerable.ToList<WSspSelectCrmProjectBycmpAndUser_Result>((IEnumerable<WSspSelectCrmProjectBycmpAndUser_Result>)_db.WSspSelectCrmProjectBycmpAndUser(cmpId, referUserId, lCID, result, result2));
			list.Add(new WSspSelectCrmProjectBycmpAndUser_Result
			{
				ProjectID = -1,
				prjTitle = Labels.SelectedListDefValue
			});
			list.AddRange(Enumerable.Select<WSspSelectCrmProjectBycmpAndUser_Result, WSspSelectCrmProjectBycmpAndUser_Result>((IEnumerable<WSspSelectCrmProjectBycmpAndUser_Result>)list2, (Func<WSspSelectCrmProjectBycmpAndUser_Result, WSspSelectCrmProjectBycmpAndUser_Result>)((WSspSelectCrmProjectBycmpAndUser_Result item) => new WSspSelectCrmProjectBycmpAndUser_Result
			{
				ProjectID = item.ProjectID,
				prjTitle = item.prjTitle,
				prjcmpQuickRegisterDefSettingId = item.prjcmpQuickRegisterDefSettingId,
				prjpordDefaultSettingId = item.prjpordDefaultSettingId,
				prjordDefaultSettingId = item.prjordDefaultSettingId
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetUserEmailList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<EmailspSelectEmailUsersInfoByUser_Result> list2 = Enumerable.ToList<EmailspSelectEmailUsersInfoByUser_Result>((IEnumerable<EmailspSelectEmailUsersInfoByUser_Result>)_db.EmailspSelectEmailUsersInfoByUser(UserLogin.CurrentUser.UserId));
			list.AddRange(Enumerable.Select<EmailspSelectEmailUsersInfoByUser_Result, SelectListItem>((IEnumerable<EmailspSelectEmailUsersInfoByUser_Result>)list2, (Func<EmailspSelectEmailUsersInfoByUser_Result, SelectListItem>)((EmailspSelectEmailUsersInfoByUser_Result item) => new SelectListItem
			{
				Text = item.euNikeName + ((!string.IsNullOrWhiteSpace(item.euNikeEmail)) ? ("  [ " + item.euNikeEmail + " ]") : ""),
				Value = item.EmailUsersInfoId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.Emailslist = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetEmailSettingList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<EmailspSelectEmailSetting_Result> list2 = Enumerable.ToList<EmailspSelectEmailSetting_Result>((IEnumerable<EmailspSelectEmailSetting_Result>)_db.EmailspSelectEmailSetting("", ""));
			list.AddRange(Enumerable.Select<EmailspSelectEmailSetting_Result, SelectListItem>((IEnumerable<EmailspSelectEmailSetting_Result>)list2, (Func<EmailspSelectEmailSetting_Result, SelectListItem>)((EmailspSelectEmailSetting_Result item) => new SelectListItem
			{
				Text = item.EmailSettingId.ToString(),
				Value = item.EmailSettingId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.EmailSettinglist = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult PrdValidityIndicator(ProductValidityIndicatorViewModel indicator)
	{
		JsonResult jsonResult = Json(PrdValidityIndicatorItem(indicator), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public PrdValidityIndicatorItemViewModel PrdValidityIndicatorItem(ProductValidityIndicatorViewModel indicator)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		PrdValidityIndicatorItemViewModel prdValidityIndicatorItemViewModel = new PrdValidityIndicatorItemViewModel();
		List<WSspSelectProductValidityIndicator_Result> items = new List<WSspSelectProductValidityIndicator_Result>();
		string text = "";
		string oprJson = "";
		prdValidityIndicatorItemViewModel.Items = items;
		prdValidityIndicatorItemViewModel.CmpIds = text;
		prdValidityIndicatorItemViewModel.OprJson = oprJson;
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (indicator != null)
			{
				indicator.PrdValidityIndicatorPrdId = (string.IsNullOrWhiteSpace(indicator.PrdValidityIndicatorPrdId) ? "" : indicator.PrdValidityIndicatorPrdId);
				indicator.PreOrderOprId = indicator.PreOrderOprId.GetValueOrDefault();
				indicator.PreOrderTypeId = indicator.PreOrderTypeId.GetValueOrDefault();
				indicator.OrderOprId = indicator.OrderOprId.GetValueOrDefault();
				indicator.FromPordIValidityExpireDateEnd = ((!string.IsNullOrWhiteSpace(indicator.FromPordIValidityExpireDateEnd)) ? indicator.FromPordIValidityExpireDateEnd.Replace("/", "") : "");
				indicator.ToPordIValidityExpireDateEnd = ((!string.IsNullOrWhiteSpace(indicator.ToPordIValidityExpireDateEnd)) ? indicator.ToPordIValidityExpireDateEnd.Replace("/", "") : "");
				indicator.FromPordIValidityExpireDate = ((!string.IsNullOrWhiteSpace(indicator.FromPordIValidityExpireDate)) ? indicator.FromPordIValidityExpireDate.Replace("/", "") : "");
				indicator.ToPordIValidityExpireDate = ((!string.IsNullOrWhiteSpace(indicator.ToPordIValidityExpireDate)) ? indicator.ToPordIValidityExpireDate.Replace("/", "") : "");
				indicator.FromOrdIValidityExpireDateEnd = ((!string.IsNullOrWhiteSpace(indicator.FromOrdIValidityExpireDateEnd)) ? indicator.FromOrdIValidityExpireDateEnd.Replace("/", "") : "");
				indicator.ToOrdIValidityExpireDateEnd = ((!string.IsNullOrWhiteSpace(indicator.ToOrdIValidityExpireDateEnd)) ? indicator.ToOrdIValidityExpireDateEnd.Replace("/", "") : "");
				indicator.FromOrdIValidityExpireDate = ((!string.IsNullOrWhiteSpace(indicator.FromOrdIValidityExpireDate)) ? indicator.FromOrdIValidityExpireDate.Replace("/", "") : "");
				indicator.ToOrdIValidityExpireDate = ((!string.IsNullOrWhiteSpace(indicator.ToOrdIValidityExpireDate)) ? indicator.ToOrdIValidityExpireDate.Replace("/", "") : "");
				DateTime value = DateTime.Now;
				DateTime value2 = DateTime.Now;
				DateTime value3 = DateTime.Now;
				DateTime value4 = DateTime.Now;
				DateTime value5 = DateTime.Now;
				DateTime value6 = DateTime.Now;
				DateTime value7 = DateTime.Now;
				DateTime value8 = DateTime.Now;
				if (!string.IsNullOrWhiteSpace(indicator.FromPordIValidityExpireDateEnd))
				{
					value = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.FromPordIValidityExpireDateEnd.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrWhiteSpace(indicator.ToPordIValidityExpireDateEnd))
				{
					value2 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.ToPordIValidityExpireDateEnd.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrWhiteSpace(indicator.FromPordIValidityExpireDate))
				{
					value3 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.FromPordIValidityExpireDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrWhiteSpace(indicator.ToPordIValidityExpireDate))
				{
					value4 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.ToPordIValidityExpireDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrWhiteSpace(indicator.FromOrdIValidityExpireDateEnd))
				{
					value5 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.FromOrdIValidityExpireDateEnd.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrWhiteSpace(indicator.ToOrdIValidityExpireDateEnd))
				{
					value6 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.ToOrdIValidityExpireDateEnd.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrWhiteSpace(indicator.FromOrdIValidityExpireDate))
				{
					value7 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.FromOrdIValidityExpireDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrWhiteSpace(indicator.ToOrdIValidityExpireDate))
				{
					value8 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.ToOrdIValidityExpireDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				DateTime value9 = DateTime.Now;
				DateTime value10 = DateTime.Now;
				if (!string.IsNullOrWhiteSpace(indicator.FromPordDate))
				{
					value9 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.FromPordDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrWhiteSpace(indicator.ToPordDate))
				{
					value10 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.ToPordDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				int userId = UserLogin.CurrentUser.UserId;
				DateTime now = DateTime.Now;
				string rptDate = now.ToString("yyyy/MM/dd");
				string rptDay = DateTimeClass.DefineDayeOfWeekFaWithoutNull(now.DayOfWeek.ToString());
				items = Enumerable.ToList<WSspSelectProductValidityIndicator_Result>((IEnumerable<WSspSelectProductValidityIndicator_Result>)_dbI.WSspSelectProductValidityIndicator(indicator.PrdValidityIndicatorPrdId, (!string.IsNullOrWhiteSpace(indicator.FromPordIValidityExpireDateEnd)) ? new DateTime?(value) : null, (!string.IsNullOrWhiteSpace(indicator.ToPordIValidityExpireDateEnd)) ? new DateTime?(value2) : null, (!string.IsNullOrWhiteSpace(indicator.FromPordIValidityExpireDate)) ? new DateTime?(value3) : null, (!string.IsNullOrWhiteSpace(indicator.ToPordIValidityExpireDate)) ? new DateTime?(value4) : null, indicator.PreOrderOprId, indicator.PreOrderTypeId, (!string.IsNullOrWhiteSpace(indicator.FromOrdIValidityExpireDateEnd)) ? new DateTime?(value5) : null, (!string.IsNullOrWhiteSpace(indicator.ToOrdIValidityExpireDateEnd)) ? new DateTime?(value6) : null, (!string.IsNullOrWhiteSpace(indicator.FromOrdIValidityExpireDate)) ? new DateTime?(value7) : null, (!string.IsNullOrWhiteSpace(indicator.ToOrdIValidityExpireDate)) ? new DateTime?(value8) : null, indicator.OrderOprId, userId, rptDate, rptDay, lCID, result, (!string.IsNullOrWhiteSpace(indicator.FromPordDate)) ? new DateTime?(value9) : null, (!string.IsNullOrWhiteSpace(indicator.ToPordDate)) ? new DateTime?(value10) : null, result2));
				List<ProductValidityIndicatorSendItemViewModel> list = new List<ProductValidityIndicatorSendItemViewModel>();
				if (items == null)
				{
					items = new List<WSspSelectProductValidityIndicator_Result>();
				}
				else if (Enumerable.Any<WSspSelectProductValidityIndicator_Result>((IEnumerable<WSspSelectProductValidityIndicator_Result>)items))
				{
					foreach (WSspSelectProductValidityIndicator_Result item2 in items)
					{
						item2.oprDate = (item2.oprDateTime.HasValue ? item2.oprDateTime.Value.ToString("yyyy/MM/dd") : "");
						item2.oprDeadlineDatePersian = (item2.oprDeadlineDate.HasValue ? item2.oprDeadlineDate.Value.ToString("yyyy/MM/dd") : "");
						item2.oprIValidityExpireDatePersian = (item2.oprIValidityExpireDate.HasValue ? item2.oprIValidityExpireDate.Value.ToString("yyyy/MM/dd") : "");
						if (!string.IsNullOrWhiteSpace(text))
						{
							text += ",";
						}
						text += item2.oprCompanyId;
						if (item2.oprType == 10)
						{
							item2.rptUserName = Labels.lblPOrd;
						}
						else if (item2.oprType == 20)
						{
							item2.rptUserName = "lblOrd".OrderLabels();
						}
						else
						{
							item2.rptUserName = "";
						}
						ProductValidityIndicatorSendItemViewModel item = new ProductValidityIndicatorSendItemViewModel
						{
							OprId = item2.ordId,
							OprType = item2.oprType,
							OprFoLink = ""
						};
						list.Add(item);
					}
				}
				prdValidityIndicatorItemViewModel.Items = items;
				prdValidityIndicatorItemViewModel.CmpIds = text;
				if (list != null && Enumerable.Any<ProductValidityIndicatorSendItemViewModel>((IEnumerable<ProductValidityIndicatorSendItemViewModel>)list))
				{
					oprJson = JsonConvert.SerializeObject(Enumerable.ToList<ProductValidityIndicatorSendItemViewModel>((IEnumerable<ProductValidityIndicatorSendItemViewModel>)list));
				}
				prdValidityIndicatorItemViewModel.OprJson = oprJson;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return prdValidityIndicatorItemViewModel;
	}

	public ActionResult PrdValidityIndicator_Read([DataSourceRequest] DataSourceRequest request, string indicator)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		ProductValidityIndicatorViewModel indicator2 = new JavaScriptSerializer().Deserialize<ProductValidityIndicatorViewModel>(indicator);
		PrdValidityIndicatorItemViewModel prdValidityIndicatorItemViewModel = PrdValidityIndicatorItem(indicator2);
		JsonResult jsonResult = Json(((IEnumerable)prdValidityIndicatorItemViewModel.Items).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[LoginAuthorize]
	public ActionResult AutoIssuePreOrder(string cmpIds = "", int mode = 2)
	{
		GetPordDefSetting();
		GetPordReferUser();
		base.ViewBag.CmpIds = cmpIds;
		base.ViewBag.Mode = mode;
		base.ViewBag.IsBuying = VersionBuyer.PreOrders;
		return View();
	}

	[AjaxOnly]
	public JsonResult ActAutoIssueCalcPreOrder(string cmpIds, string pordDate, int mode, int prjId, string pordExpireDate = "", string pordExpireTime = "", string prdIds = "", string baseCalcDate = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel();
		try
		{
			if (!VersionBuyer.AutoCalcIssueBill)
			{
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = Messages.VersionBuy;
				commonReturnResultViewModel.Tag = "BV|";
				return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
			}
			if (!VersionBuyer.PreOrders)
			{
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = Messages.VersionBuy;
				commonReturnResultViewModel.Tag = "BV|";
				return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
			}
			if (mode == 1 && prjId == 0)
			{
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = string.Format(Messages.msgErrorIsNotSelectedItem, Labels.AutoIssuePreOrderProjectId);
				commonReturnResultViewModel.Tag = "";
				return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
			}
			DateTime value = default(DateTime);
			DateTime dateTime = default(DateTime);
			string text = "";
			try
			{
				if (!string.IsNullOrWhiteSpace(pordDate))
				{
					text = PersianDate.GetFormatetdDate(pordDate.Replace("/", ""));
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
						pordDate = dateTime.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
						pordDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
						pordDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
					value = dateTime;
					pordDate = pordDate.Replace("/", "").Replace("-", "").Replace("_", "")
						.Replace(".", "")
						.Replace(",", "")
						.Replace("\\", "");
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = string.Format(Messages.ErrorInFormat, Labels.AutoIssuePreOrderDate);
				commonReturnResultViewModel.Tag = "";
				return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
			}
			DateTime value2 = default(DateTime);
			dateTime = default(DateTime);
			text = "";
			try
			{
				if (!string.IsNullOrWhiteSpace(pordExpireDate))
				{
					pordExpireTime = ((!string.IsNullOrWhiteSpace(pordExpireTime)) ? pordExpireTime.Trim() : DateTime.Now.ToString("HH:mm:ss"));
					text = PersianDate.GetFormatetdDate(pordExpireDate.Replace("/", ""));
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text + " " + pordExpireTime, new PersianCulture());
						pordExpireDate = dateTime.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime = DateTime.Parse(text + " " + pordExpireTime, new CultureInfo("ar-SA"));
						pordExpireDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime = DateTime.Parse(text + " " + pordExpireTime, new CultureInfo("en-US"));
						pordExpireDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
					value2 = dateTime;
					pordExpireDate = pordExpireDate.Replace("/", "").Replace("-", "").Replace("_", "")
						.Replace(".", "")
						.Replace(",", "")
						.Replace("\\", "");
				}
			}
			catch (Exception e2)
			{
				ErrorSignal.FromCurrentContext().Raise(e2);
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = string.Format(Messages.ErrorInFormat, Labels.AutoIssuePreOrderExpireDateI);
				commonReturnResultViewModel.Tag = "";
				return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
			}
			DateTime value3 = DateTime.Now;
			dateTime = default(DateTime);
			text = "";
			try
			{
				if (!string.IsNullOrWhiteSpace(baseCalcDate))
				{
					text = PersianDate.GetFormatetdDate(baseCalcDate.Replace("/", ""));
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text + " 00:00:00", new PersianCulture());
						baseCalcDate = dateTime.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime = DateTime.Parse(text + " 00:00:00", new CultureInfo("ar-SA"));
						baseCalcDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime = DateTime.Parse(text + " 00:00:00", new CultureInfo("en-US"));
						baseCalcDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
					value3 = dateTime;
					baseCalcDate = baseCalcDate.Replace("/", "").Replace("-", "").Replace("_", "")
						.Replace(".", "")
						.Replace(",", "")
						.Replace("\\", "");
				}
			}
			catch (Exception e3)
			{
				ErrorSignal.FromCurrentContext().Raise(e3);
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = string.Format(Messages.ErrorInFormat, Labels.AutoIssuePreOrderBaseCalcDate);
				commonReturnResultViewModel.Tag = "";
				return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
			}
			DateTime now = DateTime.Now;
			DateTime value4 = now;
			string text2 = now.ToString("yyyyMMdd", new PersianCulture());
			short value5 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int id = Financial.Get().Id;
			int userId = UserLogin.CurrentUser.UserId;
			short value6 = short.Parse(Financial.Get().Id.ToString());
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
			List<WSspAutoIssueCalcPreOrderMulti_Result> list = Enumerable.ToList<WSspAutoIssueCalcPreOrderMulti_Result>((IEnumerable<WSspAutoIssueCalcPreOrderMulti_Result>)_dbI.WSspAutoIssueCalcPreOrderMulti(cmpIds, pordDate, value, mode, (prjId != 0) ? new int?(prjId) : null, userId: userId, year1: value6, month1: value5, fPId: id, registerDate: value4, registerDatePersian: text2, appType: appType, languageID: lCID, defaultLanguageId: result, errorMessage: objectParameter, pordExpireDate: pordExpireDate, pordExpireDateTime: (!string.IsNullOrWhiteSpace(pordExpireDate)) ? new DateTime?(value2) : null, prdIds: prdIds, baseCalcDate: value3, centerId: centerId));
			string messageExtra = "";
			List<AutoIssueBillPreOrderViewModel> list2 = new List<AutoIssueBillPreOrderViewModel>();
			if (list == null)
			{
				list = new List<WSspAutoIssueCalcPreOrderMulti_Result>();
			}
			else
			{
				foreach (WSspAutoIssueCalcPreOrderMulti_Result item2 in list)
				{
					item2.pordDate = (item2.pordDateTime.HasValue ? item2.pordDateTime.Value.ToString("yyyy/MM/dd") : "");
					string text3 = "";
					if (item2.pordTotalAmount.HasValue)
					{
						text3 = $"{item2.pordTotalAmount.GetValueOrDefault():N2}";
						text3 = text3.Replace(".00", "");
						text3 += ((!string.IsNullOrWhiteSpace(item2.pordCurrencyUnit)) ? (" " + item2.pordCurrencyUnit) : "");
					}
					item2.PreOrderOpr = string.Format(Labels.AutoIssuePreOrderPordInfo, Labels.lblPOrd, item2.pordNumber.ToString(), item2.pordDate, item2.CompanyName ?? "", text3);
					int result2 = 0;
					int.TryParse(item2.PrdAutoCalcPordCnvsReferUser.ToString(), out result2);
					int result3 = 0;
					int.TryParse(item2.PreOrderID.ToString(), out result3);
					if (result2 != 0 && result3 != 0 && result2 != -4 && result3 != 0)
					{
						string pordFOLink = GetPordFOLink(result3);
						AutoIssueBillPreOrderViewModel item = new AutoIssueBillPreOrderViewModel
						{
							PordId = result3,
							PordFoLink = pordFOLink
						};
						list2.Add(item);
					}
				}
				messageExtra = JsonConvert.SerializeObject(Enumerable.ToList<WSspAutoIssueCalcPreOrderMulti_Result>((IEnumerable<WSspAutoIssueCalcPreOrderMulti_Result>)list));
				if (list2 != null && Enumerable.Any<AutoIssueBillPreOrderViewModel>((IEnumerable<AutoIssueBillPreOrderViewModel>)list2))
				{
					string text4 = JsonConvert.SerializeObject(Enumerable.ToList<AutoIssueBillPreOrderViewModel>((IEnumerable<AutoIssueBillPreOrderViewModel>)list2));
					string text5 = "";
					DateTime value7 = now.AddSeconds(-7.0);
					short value8 = short.Parse(now.ToString("yyyy", new PersianCulture()));
					List<CommonInternalMessageViewModel> list3 = new List<CommonInternalMessageViewModel>();
					foreach (Languages item3 in Enumerable.ToList<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get()))
					{
						CommonInternalMessageViewModel commonInternalMessageViewModel = new CommonInternalMessageViewModel();
						commonInternalMessageViewModel.LanguageId = item3.LanguageID;
						commonInternalMessageViewModel.msgSubject = MyResource.GetResourceString("ReferExpSupportFollowMsgSubject", item3.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
						commonInternalMessageViewModel.msgdAttachRecDesc = MyResource.GetResourceString("ConversationErjaShow", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						commonInternalMessageViewModel.msgBody = MyResource.GetResourceString("ReferExpSupportFollowMsgBody", item3.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
						list3.Add(commonInternalMessageViewModel);
					}
					if (list3 != null && Enumerable.Any<CommonInternalMessageViewModel>((IEnumerable<CommonInternalMessageViewModel>)list3))
					{
						text5 = JsonConvert.SerializeObject(Enumerable.ToList<CommonInternalMessageViewModel>((IEnumerable<CommonInternalMessageViewModel>)list3));
					}
					string conversationErjaShow = Messages.ConversationErjaShow;
					string text6 = "";
					string surveyMainExtrenalLinkLogin = "";
					string surveyMainExtrenalLink = "";
					Uri url = base.HttpContext.Request.Url;
					string text7 = url.Scheme + "://" + url.Authority;
					if (text7.EndsWith("/"))
					{
						text7 = text7.TrimEnd(new char[1] { '/' });
					}
					text7 += "/Survey/Home/SurveyAnswerValues";
					text6 = text7;
					string text8 = "";
					CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
					string text9 = "";
					string text10 = "";
					if (cRMspSelectCrmsysSetting_Result != null)
					{
						text9 = cRMspSelectCrmsysSetting_Result.FOUrl ?? "";
						text10 = cRMspSelectCrmsysSetting_Result.CrmIPStatic ?? "";
					}
					if (!string.IsNullOrWhiteSpace(text9))
					{
						text8 = text9.Trim();
						if (!text8.Contains("http"))
						{
							text8 = url.Scheme + "://" + text8;
						}
						if (text8.EndsWith("/"))
						{
							text8 = text8.TrimEnd(new char[1] { '/' });
						}
						text8 += "/Survey/Home";
						surveyMainExtrenalLinkLogin = text8;
					}
					if (!string.IsNullOrWhiteSpace(text10))
					{
						text8 = text10.Trim();
						if (!text8.Contains("http"))
						{
							text8 = url.Scheme + "://" + text8;
						}
						if (text8.EndsWith("/"))
						{
							text8 = text8.TrimEnd(new char[1] { '/' });
						}
						text8 += "/Survey/Register/Index";
						surveyMainExtrenalLink = text8;
					}
					ObjectParameter objectParameter2 = new ObjectParameter("ErrorMessage", "");
					int maxFOCount = Configuration.MaxFOCount;
					_dbI.WSspReferExpSupportFollow(text4, 0, text5, userId, value4, text2, value7, value8, month1: value5, year1: value6, appType: appType, languageID: lCID, defaultLanguageId: result, errorMessage: objectParameter2, surveyMainInternalLink: text6, surveyMainExtrenalLink: surveyMainExtrenalLink, surveyMainExtrenalLinkLogin: surveyMainExtrenalLinkLogin, conversationErjaShowText: conversationErjaShow, centerId: centerId, foCountModule: maxFOCount);
					if (objectParameter2.Value != null && !string.IsNullOrWhiteSpace(objectParameter2.Value.ToString()))
					{
						commonReturnResultViewModel.IsDone = false;
						commonReturnResultViewModel.Message = commonReturnResultViewModel.Message + "<br>" + objectParameter2.Value.ToString();
					}
				}
			}
			commonReturnResultViewModel.MessageExtra = messageExtra;
			commonReturnResultViewModel.IsDone = true;
			commonReturnResultViewModel.Message = Messages.msgOperationCompleted;
			if (objectParameter.Value != null && !string.IsNullOrWhiteSpace(objectParameter.Value.ToString()))
			{
				commonReturnResultViewModel.Message = commonReturnResultViewModel.Message + "<br>" + objectParameter.Value.ToString();
			}
			commonReturnResultViewModel.Tag = "";
		}
		catch (DbEntityValidationException e4)
		{
			commonReturnResultViewModel.IsDone = false;
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e4);
			commonReturnResultViewModel.Message = Messages.frmErrorMessage;
		}
		catch (Exception e5)
		{
			commonReturnResultViewModel.IsDone = false;
			ErrorSignal.FromCurrentContext().Raise(e5);
			commonReturnResultViewModel.Message = Messages.frmErrorMessage;
		}
		JsonResult jsonResult = Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public string SetPordExpireDate(int mode, string pordDate = "", int pordDefSettingId = 0, int durationHours = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string result2 = "";
		try
		{
			DateTime now = DateTime.Now;
			DateTime dateTime = now;
			string text = now.ToString("HH:mm:ss");
			if (string.IsNullOrWhiteSpace(pordDate))
			{
				return "-1";
			}
			DateTime dateTime2 = default(DateTime);
			string text2 = "";
			try
			{
				text = ((!string.IsNullOrEmpty(text)) ? text.Trim() : DateTime.Now.ToString("HH:mm:ss"));
				text2 = PersianDate.GetFormatetdDate(pordDate.Replace("/", ""));
				switch (lCID)
				{
				case 1065:
					dateTime2 = DateTime.Parse(text2 + " " + text, new PersianCulture());
					pordDate = dateTime2.ToString("yyyyMMdd");
					break;
				case 1025:
					dateTime2 = DateTime.Parse(text2 + " " + text, new CultureInfo("ar-SA"));
					pordDate = dateTime2.ToString("yyyyMMdd", new PersianCulture());
					break;
				default:
					dateTime2 = DateTime.Parse(text2 + " " + text, new CultureInfo("en-US"));
					pordDate = dateTime2.ToString("yyyyMMdd", new PersianCulture());
					break;
				}
				dateTime = dateTime2;
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				result2 = "-1";
			}
			int result3 = 0;
			int pordCreditDurationId = 0;
			switch (mode)
			{
			case 1:
			{
				List<WSspSelectPreOrderDefaultSettingUserAccess_Result> list = Enumerable.ToList<WSspSelectPreOrderDefaultSettingUserAccess_Result>((IEnumerable<WSspSelectPreOrderDefaultSettingUserAccess_Result>)_dbIII.WSspSelectPreOrderDefaultSettingUserAccess(UserLogin.CurrentUser.UserId, lCID, result));
				if (list == null || !Enumerable.Any<WSspSelectPreOrderDefaultSettingUserAccess_Result>((IEnumerable<WSspSelectPreOrderDefaultSettingUserAccess_Result>)list))
				{
					break;
				}
				WSspSelectPreOrderDefaultSettingUserAccess_Result wSspSelectPreOrderDefaultSettingUserAccess_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderDefaultSettingUserAccess_Result>((IEnumerable<WSspSelectPreOrderDefaultSettingUserAccess_Result>)list, (Func<WSspSelectPreOrderDefaultSettingUserAccess_Result, bool>)((WSspSelectPreOrderDefaultSettingUserAccess_Result m) => m.PreOrderSettingID == pordDefSettingId));
				if (wSspSelectPreOrderDefaultSettingUserAccess_Result == null)
				{
					break;
				}
				int.TryParse(wSspSelectPreOrderDefaultSettingUserAccess_Result.CreditDurationId.ToString(), out pordCreditDurationId);
				if (pordCreditDurationId != 0)
				{
					WSspSelectCreditDuration_Result wSspSelectCreditDuration_Result = Enumerable.FirstOrDefault<WSspSelectCreditDuration_Result>((IEnumerable<WSspSelectCreditDuration_Result>)_db.WSspSelectCreditDuration(lCID, result), (Func<WSspSelectCreditDuration_Result, bool>)((WSspSelectCreditDuration_Result m) => m.CreditDurationID == pordCreditDurationId));
					if (wSspSelectCreditDuration_Result != null)
					{
						int.TryParse(wSspSelectCreditDuration_Result.CreditDurationHours.ToString(), out result3);
					}
				}
				break;
			}
			case 2:
				result3 = durationHours;
				break;
			}
			if (result3 > 0)
			{
				DateTime dateTime3 = dateTime;
				DateTime dateTime4 = dateTime3.AddHours(result3);
				string text3 = dateTime4.ToString("yyyy/MM/dd");
				string text4 = dateTime4.ToString("HH:mm");
				result2 = text3 + "|" + text4 + "|" + result3;
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			result2 = "-1";
		}
		return result2;
	}

	[DynamicAuthorize(ControllerName = "frmProductValidityIndicator", ActionName = "actPordReferExpSupportFollow")]
	public ActionResult PordReferExpSupportFollow(int mode = 2)
	{
		GetPordReferUser();
		base.ViewBag.Mode = mode;
		return View();
	}

	[AjaxOnly]
	public JsonResult ReferExpSupportFollow(int cnvsReferUserId, string pordIds)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel();
		try
		{
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			if (string.IsNullOrWhiteSpace(pordIds))
			{
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = Messages.msgErrorNotSelectItem;
				commonReturnResultViewModel.Tag = "";
				return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
			}
			if (cnvsReferUserId == 0)
			{
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = string.Format(Messages.msgErrorIsNotSelectedItem, Labels.AutoIssuePreOrderCnvsReferUser);
				commonReturnResultViewModel.Tag = "";
				return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string text = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			_ = Financial.Get().Id;
			int userId = UserLogin.CurrentUser.UserId;
			short value3 = short.Parse(Financial.Get().Id.ToString());
			DateTime value4 = now.AddSeconds(-7.0);
			short value5 = short.Parse(now.ToString("yyyy", new PersianCulture()));
			string text2 = "";
			string text3 = "";
			List<AutoIssueBillPreOrderViewModel> list = new List<AutoIssueBillPreOrderViewModel>();
			string[] array = pordIds.Split(new char[1] { ',' });
			if (array != null && array.Length != 0)
			{
				string[] array2 = array;
				foreach (string s in array2)
				{
					int result2 = 0;
					int.TryParse(s, out result2);
					if (result2 != 0)
					{
						string pordFOLink = GetPordFOLink(result2);
						AutoIssueBillPreOrderViewModel item = new AutoIssueBillPreOrderViewModel
						{
							PordId = result2,
							PordFoLink = pordFOLink
						};
						list.Add(item);
					}
				}
			}
			if (list != null && Enumerable.Any<AutoIssueBillPreOrderViewModel>((IEnumerable<AutoIssueBillPreOrderViewModel>)list))
			{
				text2 = JsonConvert.SerializeObject(Enumerable.ToList<AutoIssueBillPreOrderViewModel>((IEnumerable<AutoIssueBillPreOrderViewModel>)list));
			}
			List<CommonInternalMessageViewModel> list2 = new List<CommonInternalMessageViewModel>();
			foreach (Languages item2 in Enumerable.ToList<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get()))
			{
				CommonInternalMessageViewModel commonInternalMessageViewModel = new CommonInternalMessageViewModel();
				commonInternalMessageViewModel.LanguageId = item2.LanguageID;
				commonInternalMessageViewModel.msgSubject = MyResource.GetResourceString("ReferExpSupportFollowMsgSubject", item2.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
				commonInternalMessageViewModel.msgdAttachRecDesc = MyResource.GetResourceString("ConversationErjaShow", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				commonInternalMessageViewModel.msgBody = MyResource.GetResourceString("ReferExpSupportFollowMsgBody", item2.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
				list2.Add(commonInternalMessageViewModel);
			}
			if (list2 != null && Enumerable.Any<CommonInternalMessageViewModel>((IEnumerable<CommonInternalMessageViewModel>)list2))
			{
				text3 = JsonConvert.SerializeObject(Enumerable.ToList<CommonInternalMessageViewModel>((IEnumerable<CommonInternalMessageViewModel>)list2));
			}
			string conversationErjaShow = Messages.ConversationErjaShow;
			string text4 = "";
			string surveyMainExtrenalLinkLogin = "";
			string surveyMainExtrenalLink = "";
			Uri url = base.HttpContext.Request.Url;
			string text5 = url.Scheme + "://" + url.Authority;
			if (text5.EndsWith("/"))
			{
				text5 = text5.TrimEnd(new char[1] { '/' });
			}
			text5 += "/Survey/Home/SurveyAnswerValues";
			text4 = text5;
			string text6 = "";
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			string text7 = "";
			string text8 = "";
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				text7 = cRMspSelectCrmsysSetting_Result.FOUrl ?? "";
				text8 = cRMspSelectCrmsysSetting_Result.CrmIPStatic ?? "";
			}
			if (!string.IsNullOrWhiteSpace(text7))
			{
				text6 = text7.Trim();
				if (!text6.Contains("http"))
				{
					text6 = url.Scheme + "://" + text6;
				}
				if (text6.EndsWith("/"))
				{
					text6 = text6.TrimEnd(new char[1] { '/' });
				}
				text6 += "/Survey/Home";
				surveyMainExtrenalLinkLogin = text6;
			}
			if (!string.IsNullOrWhiteSpace(text8))
			{
				text6 = text8.Trim();
				if (!text6.Contains("http"))
				{
					text6 = url.Scheme + "://" + text6;
				}
				if (text6.EndsWith("/"))
				{
					text6 = text6.TrimEnd(new char[1] { '/' });
				}
				text6 += "/Survey/Register/Index";
				surveyMainExtrenalLink = text6;
			}
			int maxFOCount = Configuration.MaxFOCount;
			ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
			_dbI.WSspReferExpSupportFollow(text2, cnvsReferUserId, text3, userId, value, text, value4, value5, month1: value2, year1: value3, appType: appType, languageID: lCID, defaultLanguageId: result, errorMessage: objectParameter, surveyMainInternalLink: text4, surveyMainExtrenalLink: surveyMainExtrenalLink, surveyMainExtrenalLinkLogin: surveyMainExtrenalLinkLogin, conversationErjaShowText: conversationErjaShow, centerId: centerId, foCountModule: maxFOCount);
			commonReturnResultViewModel.MessageExtra = "";
			commonReturnResultViewModel.IsDone = true;
			commonReturnResultViewModel.Message = Messages.msgOperationCompleted;
			if (objectParameter.Value != null && !string.IsNullOrWhiteSpace(objectParameter.Value.ToString()))
			{
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = commonReturnResultViewModel.Message + "<br>" + objectParameter.Value.ToString();
			}
			commonReturnResultViewModel.Tag = "";
		}
		catch (DbEntityValidationException e)
		{
			commonReturnResultViewModel.IsDone = false;
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			commonReturnResultViewModel.Message = Messages.frmErrorMessage;
		}
		catch (Exception e2)
		{
			commonReturnResultViewModel.IsDone = false;
			ErrorSignal.FromCurrentContext().Raise(e2);
			commonReturnResultViewModel.Message = Messages.frmErrorMessage;
		}
		JsonResult jsonResult = Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public string GetPordFOLink(int pordId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string result2 = "";
		try
		{
			if (pordId != 0)
			{
				CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
				if (cRMspSelectCrmsysSetting_Result != null)
				{
					string text = cRMspSelectCrmsysSetting_Result.FOUrl ?? "";
					text = text.Trim();
					if (!string.IsNullOrWhiteSpace(text))
					{
						if (!text.StartsWith("http"))
						{
							text = "http://" + text;
						}
						if (text.EndsWith("/"))
						{
							text = text.Substring(0, text.Length - 1);
						}
						string text2 = CodeDecode.CoddingUTF8(pordId.ToString());
						text = text + "?" + "Pord".ToLower() + "=" + text2;
						if (cRMspSelectCrmsysSetting_Result.SendSMSPordFOLinkAfterVerifyType.GetValueOrDefault() == 2)
						{
							text += "&nl=1";
						}
						result2 = text;
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result2;
	}

	public string GetOrdFOLink(int ordId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string result2 = "";
		try
		{
			if (ordId != 0)
			{
				CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
				if (cRMspSelectCrmsysSetting_Result != null)
				{
					string text = cRMspSelectCrmsysSetting_Result.FOUrl ?? "";
					text = text.Trim();
					if (!string.IsNullOrWhiteSpace(text))
					{
						if (!text.StartsWith("http"))
						{
							text = "http://" + text;
						}
						if (text.EndsWith("/"))
						{
							text = text.Substring(0, text.Length - 1);
						}
						string text2 = CodeDecode.CoddingUTF8(ordId.ToString());
						text = text + "?" + "Ord".ToLower() + "=" + text2;
						result2 = text;
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result2;
	}

	[DynamicAuthorize(ControllerName = "frmProductValidityIndicator", ActionName = "actSendSms")]
	[LoginAuthorize]
	public ActionResult PrdValidityIndicatorSendSms()
	{
		return View();
	}

	[AjaxOnly]
	public JsonResult ActSendSms(string modelStr)
	{
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0433: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel();
		try
		{
			if (!VersionBuyer.SMS && !VersionBuyer.GSM)
			{
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = Messages.VersionBuy;
				commonReturnResultViewModel.Tag = "BV|";
				return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
			}
			ProductValidityIndicatorSendSmsViewModel productValidityIndicatorSendSmsViewModel = new ProductValidityIndicatorSendSmsViewModel();
			if (string.IsNullOrWhiteSpace(modelStr))
			{
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
				return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
			}
			productValidityIndicatorSendSmsViewModel = new JavaScriptSerializer().Deserialize<ProductValidityIndicatorSendSmsViewModel>(modelStr);
			string oprJson = "";
			if (string.IsNullOrWhiteSpace(productValidityIndicatorSendSmsViewModel.OprJson))
			{
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
				return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
			}
			productValidityIndicatorSendSmsViewModel.OprJson = productValidityIndicatorSendSmsViewModel.OprJson.Replace("&quot;", "\"").Replace("\\", "");
			productValidityIndicatorSendSmsViewModel.OprJson = productValidityIndicatorSendSmsViewModel.OprJson.Replace("\\", "");
			List<ProductValidityIndicatorSendItemViewModel> list = new List<ProductValidityIndicatorSendItemViewModel>();
			list = new JavaScriptSerializer().Deserialize<List<ProductValidityIndicatorSendItemViewModel>>(productValidityIndicatorSendSmsViewModel.OprJson);
			if (list != null && Enumerable.Any<ProductValidityIndicatorSendItemViewModel>((IEnumerable<ProductValidityIndicatorSendItemViewModel>)list))
			{
				foreach (ProductValidityIndicatorSendItemViewModel item in list)
				{
					int result2 = 0;
					int.TryParse(item.OprId.ToString(), out result2);
					int result3 = 0;
					int.TryParse(item.OprType.ToString(), out result3);
					if (result2 != 0)
					{
						switch (result3)
						{
						case 10:
						{
							string pordFOLink = GetPordFOLink(result2);
							item.OprFoLink = pordFOLink;
							break;
						}
						case 20:
						{
							string ordFOLink = GetOrdFOLink(result2);
							item.OprFoLink = ordFOLink;
							break;
						}
						}
					}
				}
			}
			if (list != null && Enumerable.Any<ProductValidityIndicatorSendItemViewModel>((IEnumerable<ProductValidityIndicatorSendItemViewModel>)list))
			{
				oprJson = JsonConvert.SerializeObject(Enumerable.ToList<ProductValidityIndicatorSendItemViewModel>((IEnumerable<ProductValidityIndicatorSendItemViewModel>)list));
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short value3 = short.Parse(Financial.Get().Id.ToString());
			int userId = UserLogin.CurrentUser.UserId;
			_ = Financial.Get().Id;
			new ObjectParameter("ErrorMessage", "");
			CRMspInsertSmsTempMobileNumbersProductValidityIndicator_Result cRMspInsertSmsTempMobileNumbersProductValidityIndicator_Result = Enumerable.FirstOrDefault<CRMspInsertSmsTempMobileNumbersProductValidityIndicator_Result>((IEnumerable<CRMspInsertSmsTempMobileNumbersProductValidityIndicator_Result>)_dbI.CRMspInsertSmsTempMobileNumbersProductValidityIndicator(oprJson, productValidityIndicatorSendSmsViewModel.TextBody, productValidityIndicatorSendSmsViewModel.RecieverType, userId, value, registerDatePersian, value3, value2, appType, lCID, result));
			string text = "";
			string messageExtra = "";
			string text2 = "";
			if (cRMspInsertSmsTempMobileNumbersProductValidityIndicator_Result != null)
			{
				text = cRMspInsertSmsTempMobileNumbersProductValidityIndicator_Result.Numbers + "@||@" + cRMspInsertSmsTempMobileNumbersProductValidityIndicator_Result.Companies + "@||@" + cRMspInsertSmsTempMobileNumbersProductValidityIndicator_Result.CompanyPersons + "@||@" + ((!cRMspInsertSmsTempMobileNumbersProductValidityIndicator_Result.AllBodyCount.HasValue) ? new int?(0) : cRMspInsertSmsTempMobileNumbersProductValidityIndicator_Result.AllBodyCount) + "@||@" + ((!cRMspInsertSmsTempMobileNumbersProductValidityIndicator_Result.AllBodyCost.HasValue) ? new decimal?(default(decimal)) : cRMspInsertSmsTempMobileNumbersProductValidityIndicator_Result.AllBodyCost) + "@||@" + cRMspInsertSmsTempMobileNumbersProductValidityIndicator_Result.SMSBody + "@||@" + ((!cRMspInsertSmsTempMobileNumbersProductValidityIndicator_Result.NumberCount.HasValue) ? new int?(0) : cRMspInsertSmsTempMobileNumbersProductValidityIndicator_Result.NumberCount) + "@||@";
				List<ProductValidityIndicatorSendSmsResultViewModel> list2 = new List<ProductValidityIndicatorSendSmsResultViewModel>();
				if (!string.IsNullOrWhiteSpace(cRMspInsertSmsTempMobileNumbersProductValidityIndicator_Result.OprList))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<ProductValidityIndicatorSendSmsResultViewModel>>(cRMspInsertSmsTempMobileNumbersProductValidityIndicator_Result.OprList);
				}
				if (list2 != null && !Enumerable.Any<ProductValidityIndicatorSendSmsResultViewModel>((IEnumerable<ProductValidityIndicatorSendSmsResultViewModel>)list2))
				{
					list2 = new List<ProductValidityIndicatorSendSmsResultViewModel>();
					text2 = "";
				}
				else if (list2 == null)
				{
					list2 = new List<ProductValidityIndicatorSendSmsResultViewModel>();
					text2 = "";
				}
				else
				{
					text2 = Messages.msgUnableSendSmsFollowList + "<br>";
					foreach (ProductValidityIndicatorSendSmsResultViewModel item2 in list2)
					{
						item2.oprDate = (item2.oprDateTime.HasValue ? item2.oprDateTime.Value.ToString("yyyy/MM/dd") : "");
						string text3 = "";
						string text4 = "";
						int result4 = 0;
						int.TryParse(item2.OprType.ToString(), out result4);
						switch (result4)
						{
						case 10:
							text4 = Labels.lblPOrd;
							break;
						case 20:
							text4 = "lblOrd".OrderLabels();
							break;
						}
						if (!string.IsNullOrWhiteSpace(item2.ErrorMessage))
						{
							if (item2.ErrorMessage == "-2")
							{
								text3 = string.Format(Messages.msgErrorPrdValidityIndicatorSendSmsMobNoSave, text4, item2.OprNumber.ToString(), item2.oprDate, item2.oprCompanyName ?? "");
							}
							else if (item2.ErrorMessage == "-1")
							{
								text3 = string.Format(Messages.msgErrorPrdValidityIndicatorSendsmsMobInCorrect, text4, item2.OprNumber.ToString(), item2.oprDate, item2.oprCompanyName ?? "");
							}
						}
						item2.OprName = text3;
						text2 = text2 + "<br>" + text3;
					}
					messageExtra = JsonConvert.SerializeObject(Enumerable.ToList<ProductValidityIndicatorSendSmsResultViewModel>((IEnumerable<ProductValidityIndicatorSendSmsResultViewModel>)list2));
				}
				commonReturnResultViewModel.MessageExtra = messageExtra;
				commonReturnResultViewModel.IsDone = true;
				commonReturnResultViewModel.Message = text2;
				commonReturnResultViewModel.Tag = text;
			}
			else
			{
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
			}
		}
		catch (DbEntityValidationException e)
		{
			commonReturnResultViewModel.IsDone = false;
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
		}
		catch (Exception e2)
		{
			commonReturnResultViewModel.IsDone = false;
			ErrorSignal.FromCurrentContext().Raise(e2);
			commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
		}
		JsonResult jsonResult = Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmProductValidityIndicator", ActionName = "actSendEmail")]
	[LoginAuthorize]
	public ActionResult PrdValidityIndicatorSendEmail()
	{
		GetUserEmailList();
		return View();
	}

	[AjaxOnly]
	[ValidateInput(false)]
	public JsonResult ActSendEmail(string modelStr)
	{
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_036a: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel();
		try
		{
			if (!VersionBuyer.Emails)
			{
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = Messages.VersionBuy;
				commonReturnResultViewModel.Tag = "BV|";
				return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
			}
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			ProductValidityIndicatorSendEmailViewModel productValidityIndicatorSendEmailViewModel = new ProductValidityIndicatorSendEmailViewModel();
			if (string.IsNullOrWhiteSpace(modelStr))
			{
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
				return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
			}
			productValidityIndicatorSendEmailViewModel = new JavaScriptSerializer().Deserialize<ProductValidityIndicatorSendEmailViewModel>(modelStr);
			string oprJson = "";
			if (string.IsNullOrWhiteSpace(productValidityIndicatorSendEmailViewModel.OprJson))
			{
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
				return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
			}
			productValidityIndicatorSendEmailViewModel.OprJson = productValidityIndicatorSendEmailViewModel.OprJson.Replace("&quot;", "\"").Replace("\\", "");
			productValidityIndicatorSendEmailViewModel.OprJson = productValidityIndicatorSendEmailViewModel.OprJson.Replace("\\", "");
			List<ProductValidityIndicatorSendItemViewModel> list = new List<ProductValidityIndicatorSendItemViewModel>();
			list = new JavaScriptSerializer().Deserialize<List<ProductValidityIndicatorSendItemViewModel>>(productValidityIndicatorSendEmailViewModel.OprJson);
			if (list != null && Enumerable.Any<ProductValidityIndicatorSendItemViewModel>((IEnumerable<ProductValidityIndicatorSendItemViewModel>)list))
			{
				foreach (ProductValidityIndicatorSendItemViewModel item in list)
				{
					int result2 = 0;
					int.TryParse(item.OprId.ToString(), out result2);
					int result3 = 0;
					int.TryParse(item.OprType.ToString(), out result3);
					if (result2 != 0)
					{
						switch (result3)
						{
						case 10:
						{
							string pordFOLink = GetPordFOLink(result2);
							item.OprFoLink = pordFOLink;
							break;
						}
						case 20:
						{
							string ordFOLink = GetOrdFOLink(result2);
							item.OprFoLink = ordFOLink;
							break;
						}
						}
					}
				}
			}
			if (list != null && Enumerable.Any<ProductValidityIndicatorSendItemViewModel>((IEnumerable<ProductValidityIndicatorSendItemViewModel>)list))
			{
				oprJson = JsonConvert.SerializeObject(Enumerable.ToList<ProductValidityIndicatorSendItemViewModel>((IEnumerable<ProductValidityIndicatorSendItemViewModel>)list));
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short value3 = short.Parse(Financial.Get().Id.ToString());
			int userId = UserLogin.CurrentUser.UserId;
			_ = Financial.Get().Id;
			int num = 0;
			EmailspSelectEmailSetting_Result emailspSelectEmailSetting_Result = Enumerable.FirstOrDefault<EmailspSelectEmailSetting_Result>((IEnumerable<EmailspSelectEmailSetting_Result>)_db.EmailspSelectEmailSetting("", ""));
			if (emailspSelectEmailSetting_Result != null)
			{
				num = emailspSelectEmailSetting_Result.EmailSettingId;
			}
			if (num == 0)
			{
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = Messages.errorInReadingSetting;
				return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
			}
			string text = productValidityIndicatorSendEmailViewModel.TextBody;
			if (!string.IsNullOrWhiteSpace(text))
			{
				text = ((!Thread.CurrentThread.CurrentCulture.TextInfo.IsRightToLeft) ? ("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" /> <div dir=\"ltr\">" + text + "</div>") : ("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" /> <div dir=\"rtl\">" + text + "</div>"));
				List<string> list2 = new List<string>();
				foreach (Match item2 in Regex.Matches(text, "<img.+?src=[\"'](.+?)[\"'].+?>", (RegexOptions)3))
				{
					string value4 = ((Capture)item2.Groups[1]).Value;
					if (!list2.Contains(value4))
					{
						list2.Add(value4);
					}
				}
				if (list2.Count > 0)
				{
					EmailSetting emailSetting = EmailSettings.Get();
					string text2 = ((emailSetting.EmailsAttachFilePath == null) ? "" : (emailSetting.EmailsAttachFilePath + (emailSetting.EmailsAttachFilePath.EndsWith("\\") ? "" : "\\")));
					try
					{
						string text3 = text;
						foreach (string item3 in list2)
						{
							string text4 = item3.Replace("%2F", "/").Replace("%20", " ");
							string text5 = base.Server.MapPath(text4);
							string[] array = text5.Split(new char[1] { '.' });
							RandomText randomText = new RandomText();
							string text6 = DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + randomText.CreateRandomCode(5, WithNumber: true, false).Replace(" ", "").Trim() + "-" + DateTime.Now.ToString("yyyyMMdd") + "-" + DateTime.Now.ToString("HHmmss") + "." + array[^1];
							string newValue = text2 + text6;
							if (!new FTPclient(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, Configuration.UsePassiveFtp).Upload(text5, emailSetting.EmailsAttachShareFilePathFtp + text6))
							{
								commonReturnResultViewModel.IsDone = false;
								commonReturnResultViewModel.Message = Messages.EmailSendingErrorInSaveImage;
								return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
							}
							text3 = text3.Replace(item3, newValue);
						}
						text = text3;
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						commonReturnResultViewModel.IsDone = false;
						commonReturnResultViewModel.Message = Messages.EmailSendingErrorInSaveImage;
						return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
					}
				}
			}
			new ObjectParameter("ErrorMessage", "");
			List<CRMspInsertEmailFromProductValidityIndicator_Result> list3 = Enumerable.ToList<CRMspInsertEmailFromProductValidityIndicator_Result>((IEnumerable<CRMspInsertEmailFromProductValidityIndicator_Result>)_dbI.CRMspInsertEmailFromProductValidityIndicator(oprJson, productValidityIndicatorSendEmailViewModel.Subject, text, productValidityIndicatorSendEmailViewModel.EmailUserInfoId, num, productValidityIndicatorSendEmailViewModel.RecieverType, userId, value, registerDatePersian, value3, value2, appType, lCID, result, centerId));
			string messageExtra = "";
			string text7 = "";
			if (list3 != null && !Enumerable.Any<CRMspInsertEmailFromProductValidityIndicator_Result>((IEnumerable<CRMspInsertEmailFromProductValidityIndicator_Result>)list3))
			{
				list3 = new List<CRMspInsertEmailFromProductValidityIndicator_Result>();
				text7 = Messages.EmailSendingSuccessfully;
			}
			else if (list3 == null)
			{
				list3 = new List<CRMspInsertEmailFromProductValidityIndicator_Result>();
				text7 = Messages.EmailSendingSuccessfully;
			}
			else
			{
				text7 = Messages.msgSendCorrectEmailNoSendInCorrect + "<br>";
				foreach (CRMspInsertEmailFromProductValidityIndicator_Result item4 in list3)
				{
					item4.oprDate = (item4.oprDateTime.HasValue ? item4.oprDateTime.Value.ToString("yyyy/MM/dd") : "");
					string text8 = "";
					string text9 = "";
					int result4 = 0;
					int.TryParse(item4.OprType.ToString(), out result4);
					switch (result4)
					{
					case 10:
						text9 = Labels.lblPOrd;
						break;
					case 20:
						text9 = "lblOrd".OrderLabels();
						break;
					}
					if (!string.IsNullOrWhiteSpace(item4.ErrorMessage))
					{
						if (item4.ErrorMessage == "-2")
						{
							text8 = string.Format(Messages.msgErrorPrdValidityIndicatorSendEmailNoSave, text9, item4.OprNumber.ToString(), item4.oprDate, item4.oprCompanyName ?? "");
						}
						else if (item4.ErrorMessage == "-1")
						{
							text8 = string.Format(Messages.msgErrorPrdValidityIndicatorSendEmailInCorrect, text9, item4.OprNumber.ToString(), item4.oprDate, item4.oprCompanyName ?? "");
						}
					}
					item4.OprName = text8;
					text7 = text7 + "<br>" + text8;
				}
				messageExtra = JsonConvert.SerializeObject(Enumerable.ToList<CRMspInsertEmailFromProductValidityIndicator_Result>((IEnumerable<CRMspInsertEmailFromProductValidityIndicator_Result>)list3));
			}
			commonReturnResultViewModel.MessageExtra = messageExtra;
			commonReturnResultViewModel.IsDone = true;
			commonReturnResultViewModel.Message = text7;
			commonReturnResultViewModel.Tag = "";
		}
		catch (DbEntityValidationException e2)
		{
			commonReturnResultViewModel.IsDone = false;
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e2);
			commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
		}
		catch (Exception e3)
		{
			commonReturnResultViewModel.IsDone = false;
			ErrorSignal.FromCurrentContext().Raise(e3);
			commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
		}
		JsonResult jsonResult = Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public JsonResult CompanyEmailsAndMobiles(string model)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		ProductValidityIndicatorCmpEmailMobileViewModel model2 = new JavaScriptSerializer().Deserialize<ProductValidityIndicatorCmpEmailMobileViewModel>(model);
		JsonResult jsonResult = Json(CompanyEmailsAndMobilesItem(model2), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public PrdValidityIndicatorCmpEmailMobileItemViewModel CompanyEmailsAndMobilesItem(ProductValidityIndicatorCmpEmailMobileViewModel model)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		PrdValidityIndicatorCmpEmailMobileItemViewModel prdValidityIndicatorCmpEmailMobileItemViewModel = new PrdValidityIndicatorCmpEmailMobileItemViewModel();
		List<CRMspSelectCompanyEmailsAndMobilesFromProductValidityIndicator_Result> items = new List<CRMspSelectCompanyEmailsAndMobilesFromProductValidityIndicator_Result>();
		string oprJson = "";
		prdValidityIndicatorCmpEmailMobileItemViewModel.Items = items;
		prdValidityIndicatorCmpEmailMobileItemViewModel.OprJson = oprJson;
		try
		{
			if (model != null)
			{
				int userId = UserLogin.CurrentUser.UserId;
				DateTime now = DateTime.Now;
				now.ToString("yyyy/MM/dd");
				DateTimeClass.DefineDayeOfWeekFaWithoutNull(now.DayOfWeek.ToString());
				items = Enumerable.ToList<CRMspSelectCompanyEmailsAndMobilesFromProductValidityIndicator_Result>((IEnumerable<CRMspSelectCompanyEmailsAndMobilesFromProductValidityIndicator_Result>)_dbI.CRMspSelectCompanyEmailsAndMobilesFromProductValidityIndicator(model.OprJson, model.RecieverType, userId, model.Type, model.Mode, lCID, result));
				List<ProductValidityIndicatorSendItemViewModel> list = new List<ProductValidityIndicatorSendItemViewModel>();
				if (items == null)
				{
					items = new List<CRMspSelectCompanyEmailsAndMobilesFromProductValidityIndicator_Result>();
				}
				else if (Enumerable.Any<CRMspSelectCompanyEmailsAndMobilesFromProductValidityIndicator_Result>((IEnumerable<CRMspSelectCompanyEmailsAndMobilesFromProductValidityIndicator_Result>)items))
				{
					foreach (CRMspSelectCompanyEmailsAndMobilesFromProductValidityIndicator_Result item2 in items)
					{
						item2.oprDate = (item2.oprDateTime.HasValue ? item2.oprDateTime.Value.ToString("yyyy/MM/dd") : "");
						if (item2.OprType.GetValueOrDefault() == 10 && string.IsNullOrWhiteSpace(item2.OprName))
						{
							item2.OprName = Labels.lblPOrd;
						}
						ProductValidityIndicatorSendItemViewModel item = new ProductValidityIndicatorSendItemViewModel
						{
							OprId = item2.OprId.GetValueOrDefault(),
							OprType = item2.OprType.GetValueOrDefault(),
							OprFoLink = ""
						};
						list.Add(item);
					}
				}
				prdValidityIndicatorCmpEmailMobileItemViewModel.Items = items;
				if (list != null && Enumerable.Any<ProductValidityIndicatorSendItemViewModel>((IEnumerable<ProductValidityIndicatorSendItemViewModel>)list))
				{
					oprJson = JsonConvert.SerializeObject(Enumerable.ToList<ProductValidityIndicatorSendItemViewModel>((IEnumerable<ProductValidityIndicatorSendItemViewModel>)list));
				}
				prdValidityIndicatorCmpEmailMobileItemViewModel.OprJson = oprJson;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return prdValidityIndicatorCmpEmailMobileItemViewModel;
	}

	public ActionResult CompanyEmailsAndMobiles_Read([DataSourceRequest] DataSourceRequest request, string model)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		ProductValidityIndicatorCmpEmailMobileViewModel model2 = new JavaScriptSerializer().Deserialize<ProductValidityIndicatorCmpEmailMobileViewModel>(model);
		PrdValidityIndicatorCmpEmailMobileItemViewModel prdValidityIndicatorCmpEmailMobileItemViewModel = CompanyEmailsAndMobilesItem(model2);
		JsonResult jsonResult = Json(((IEnumerable)prdValidityIndicatorCmpEmailMobileItemViewModel.Items).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public bool checkMultiLanguage(string defaultValue, List<CommonMultiLanguageViewModel> list)
	{
		bool result = true;
		List<CRMspSelectUserLanguages_Result> list2 = CRMIdeal.Cache.User.Language.Get();
		bool isCurrentUserAllowCopyOtherLanguage = UserLogin.IsCurrentUserAllowCopyOtherLanguage;
		foreach (Languages itemLang in CRMIdeal.Cache.Setting.Language.Get())
		{
			CommonMultiLanguageViewModel commonMultiLanguageViewModel = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == itemLang.LanguageID));
			if (commonMultiLanguageViewModel == null)
			{
				if (Enumerable.Any<CRMspSelectUserLanguages_Result>((IEnumerable<CRMspSelectUserLanguages_Result>)list2, (Func<CRMspSelectUserLanguages_Result, bool>)((CRMspSelectUserLanguages_Result c) => c.LanguageID == itemLang.LanguageID)))
				{
					if (isCurrentUserAllowCopyOtherLanguage)
					{
						list.Add(new CommonMultiLanguageViewModel
						{
							LanguageId = itemLang.LanguageID,
							Value = defaultValue
						});
					}
					else
					{
						result = false;
					}
				}
				else
				{
					list.Add(new CommonMultiLanguageViewModel
					{
						LanguageId = itemLang.LanguageID,
						Value = defaultValue
					});
				}
			}
			else
			{
				if (!string.IsNullOrEmpty(commonMultiLanguageViewModel.Value))
				{
					continue;
				}
				if (Enumerable.Any<CRMspSelectUserLanguages_Result>((IEnumerable<CRMspSelectUserLanguages_Result>)list2, (Func<CRMspSelectUserLanguages_Result, bool>)((CRMspSelectUserLanguages_Result c) => c.LanguageID == itemLang.LanguageID)))
				{
					if (isCurrentUserAllowCopyOtherLanguage)
					{
						commonMultiLanguageViewModel.Value = defaultValue;
					}
					else
					{
						result = false;
					}
				}
				else
				{
					commonMultiLanguageViewModel.Value = defaultValue;
				}
			}
		}
		return result;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbI.Dispose();
		_dbTbl.Dispose();
		_dbIII.Dispose();
		base.Dispose(disposing);
	}
}

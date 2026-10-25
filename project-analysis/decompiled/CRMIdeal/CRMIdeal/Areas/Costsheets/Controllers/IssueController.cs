using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.Objects;
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
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace CRMIdeal.Areas.Costsheets.Controllers;

public class IssueController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	[DynamicAuthorize(ControllerName = "frmCostsheet", ActionName = "actIssuePreOrder")]
	public ActionResult PreOrder(int cmpId, int prjId, string pordCostSheetIds)
	{
		WSCostSheetIssuePreOrderViewModel wSCostSheetIssuePreOrderViewModel = new WSCostSheetIssuePreOrderViewModel();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			wSCostSheetIssuePreOrderViewModel.CostSheetId = 0;
			wSCostSheetIssuePreOrderViewModel.pordDateTime = now;
			wSCostSheetIssuePreOrderViewModel.pordDate = now.ToString("yyyy/MM/dd");
			wSCostSheetIssuePreOrderViewModel.pordReferUserId = UserLogin.CurrentUser.UserId;
			wSCostSheetIssuePreOrderViewModel.pordCompanyId = cmpId;
			wSCostSheetIssuePreOrderViewModel.pordProjectId = prjId;
			wSCostSheetIssuePreOrderViewModel.pordCostSheetIds = pordCostSheetIds;
			CrmNumRefSetting crmNumRefSetting = Queryable.FirstOrDefault<CrmNumRefSetting>((IQueryable<CrmNumRefSetting>)_dbTbl.CrmNumRefSetting);
			if (crmNumRefSetting != null)
			{
				wSCostSheetIssuePreOrderViewModel.PordNumRefFormula = crmNumRefSetting.pordNumRefFormula ?? "";
			}
			List<int> list = Enumerable.ToList<int>(Enumerable.Select<CRMspSelectActiveUsers_Result, int>((IEnumerable<CRMspSelectActiveUsers_Result>)_db.CRMspSelectActiveUsers(lCID, result, 0), (Func<CRMspSelectActiveUsers_Result, int>)((CRMspSelectActiveUsers_Result c) => c.UserId)));
			base.ViewBag.ListUserIsActiveStatus = list;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		GetPordReferUsers();
		GetPordPaymentType();
		GetCurrencyUnit();
		GetDeliveryTerms();
		GetCommUser();
		GetCompanyPerson(cmpId);
		GetPreOrderOpr();
		GetPreOrderTypes();
		return View(wSCostSheetIssuePreOrderViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmIssuePreOrderFromCostSheet", ActionName = "actIssuePreOrder")]
	[ValidateAntiForgeryToken]
	public ActionResult PreOrder(WSCostSheetIssuePreOrderViewModel vm)
	{
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_041c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0360: Unknown result type (might be due to invalid IL or missing references)
		//IL_0680: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			GetPordReferUsers();
			GetPordPaymentType();
			GetCurrencyUnit();
			GetDeliveryTerms();
			GetCommUser();
			GetCompanyPerson(vm.pordCompanyId.GetValueOrDefault());
			GetPreOrderOpr();
			GetPreOrderTypes();
			List<int> list = Enumerable.ToList<int>(Enumerable.Select<CRMspSelectActiveUsers_Result, int>((IEnumerable<CRMspSelectActiveUsers_Result>)_db.CRMspSelectActiveUsers(lCID, result, 0), (Func<CRMspSelectActiveUsers_Result, int>)((CRMspSelectActiveUsers_Result c) => c.UserId)));
			base.ViewBag.ListUserIsActiveStatus = list;
			DateTime dateTime = default(DateTime);
			string text = "";
			DateTime now = DateTime.Now;
			string text2 = "";
			try
			{
				if (!string.IsNullOrEmpty(vm.PreOrderPayments))
				{
					List<WSCostSheetIssuePreOrderPayViewModel> list2 = new List<WSCostSheetIssuePreOrderPayViewModel>();
					if (!string.IsNullOrEmpty(vm.PreOrderPayments))
					{
						list2 = new JavaScriptSerializer().Deserialize<List<WSCostSheetIssuePreOrderPayViewModel>>(vm.PreOrderPayments);
						if (Enumerable.Any<WSCostSheetIssuePreOrderPayViewModel>((IEnumerable<WSCostSheetIssuePreOrderPayViewModel>)list2))
						{
							foreach (WSCostSheetIssuePreOrderPayViewModel item in list2)
							{
								try
								{
									string text3 = now.ToString("HH:mm:ss");
									text = PersianDate.GetFormatetdDate(item.pordpayImportDate.Replace("/", ""));
									switch (lCID)
									{
									case 1065:
										dateTime = DateTime.Parse(text + " " + text3, new PersianCulture());
										item.pordpayImportDate = dateTime.ToString("yyyyMMdd");
										break;
									case 1025:
										dateTime = DateTime.Parse(text + " " + text3, new CultureInfo("ar-SA"));
										item.pordpayImportDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
										break;
									default:
										dateTime = DateTime.Parse(text + " " + text3, new CultureInfo("en-US"));
										item.pordpayImportDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
										break;
									}
									item.pordpayImportDateTime = dateTime.ToString("yyyy/MM/dd HH:mm:ss", new CultureInfo("en-US"));
								}
								catch (Exception e)
								{
									ErrorSignal.FromCurrentContext().Raise(e);
									base.ViewBag.Error = string.Format(Messages.ErrorInFormat, Labels.ctshPordPayImportDate);
									return View(vm);
								}
							}
							text2 = new JavaScriptSerializer().Serialize((object)list2);
						}
					}
				}
			}
			catch (Exception ex)
			{
				ErrorSignal.FromCurrentContext().Raise(ex);
				base.ViewBag.Error = ex.Message;
				return View(vm);
			}
			string text4 = "";
			try
			{
				if (!string.IsNullOrEmpty(vm.PreOrderCommissions))
				{
					List<WSCostSheetIssuePreOrderCommViewModel> list3 = new List<WSCostSheetIssuePreOrderCommViewModel>();
					if (!string.IsNullOrEmpty(vm.PreOrderCommissions))
					{
						list3 = new JavaScriptSerializer().Deserialize<List<WSCostSheetIssuePreOrderCommViewModel>>(vm.PreOrderCommissions);
						if (Enumerable.Any<WSCostSheetIssuePreOrderCommViewModel>((IEnumerable<WSCostSheetIssuePreOrderCommViewModel>)list3))
						{
							foreach (WSCostSheetIssuePreOrderCommViewModel item2 in list3)
							{
								try
								{
									string text5 = now.ToString("HH:mm:ss");
									text = PersianDate.GetFormatetdDate(item2.pordCommDatePersian.Replace("/", ""));
									switch (lCID)
									{
									case 1065:
										dateTime = DateTime.Parse(text + " " + text5, new PersianCulture());
										item2.pordCommDatePersian = dateTime.ToString("yyyyMMdd");
										break;
									case 1025:
										dateTime = DateTime.Parse(text + " " + text5, new CultureInfo("ar-SA"));
										item2.pordCommDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
										break;
									default:
										dateTime = DateTime.Parse(text + " " + text5, new CultureInfo("en-US"));
										item2.pordCommDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
										break;
									}
									item2.pordCommDateTime = dateTime.ToString("yyyy/MM/dd HH:mm:ss", new CultureInfo("en-US"));
								}
								catch (Exception e2)
								{
									ErrorSignal.FromCurrentContext().Raise(e2);
									base.ViewBag.Error = string.Format(Messages.ErrorInFormat, Labels.ctshPordCommDate);
									return View(vm);
								}
								decimal result2 = default(decimal);
								decimal result3 = 1m;
								decimal.TryParse(item2.pordCommBaseAmount.ToString(), out result2);
								decimal.TryParse(item2.pordCommAmountCurrencyRate.ToString(), out result3);
								if (result2 > 0m)
								{
									result3 = ((result3 == 0m) ? 1m : result3);
									item2.pordCommAmount = result2 * result3;
								}
							}
							text4 = new JavaScriptSerializer().Serialize((object)list3);
						}
					}
				}
			}
			catch (Exception ex2)
			{
				ErrorSignal.FromCurrentContext().Raise(ex2);
				base.ViewBag.Error = ex2.Message;
				return View(vm);
			}
			try
			{
				string text6 = now.ToString("HH:mm:ss");
				text = PersianDate.GetFormatetdDate(vm.pordDate.Replace("/", ""));
				switch (lCID)
				{
				case 1065:
					dateTime = DateTime.Parse(text + " " + text6, new PersianCulture());
					vm.pordDate = dateTime.ToString("yyyyMMdd");
					break;
				case 1025:
					dateTime = DateTime.Parse(text + " " + text6, new CultureInfo("ar-SA"));
					vm.pordDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
					break;
				default:
					dateTime = DateTime.Parse(text + " " + text6, new CultureInfo("en-US"));
					vm.pordDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
					break;
				}
				vm.pordDateTime = dateTime;
			}
			catch (Exception e3)
			{
				ErrorSignal.FromCurrentContext().Raise(e3);
				base.ViewBag.Error = string.Format(Messages.ErrorInFormat, Labels.ctshPordDate);
				return View(vm);
			}
			try
			{
				if (!string.IsNullOrEmpty(vm.pordDeliveryDate))
				{
					text = PersianDate.GetFormatetdDate(vm.pordDeliveryDate.Replace("/", ""));
					text = (string.IsNullOrEmpty(vm.pordDeliveryTime) ? (text + " 00:00:00") : (text + " " + vm.pordDeliveryTime.Trim()));
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text, new PersianCulture());
						vm.pordDeliveryDate = dateTime.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime = DateTime.Parse(text, new CultureInfo("ar-SA"));
						vm.pordDeliveryDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime = DateTime.Parse(text, new CultureInfo("en-US"));
						vm.pordDeliveryDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
					vm.pordDeliveryDateTime = dateTime;
				}
			}
			catch (Exception e4)
			{
				ErrorSignal.FromCurrentContext().Raise(e4);
				base.ViewBag.Error = string.Format(Messages.ErrorInFormat, Labels.ctshPordDeliveryDate);
				return View(vm);
			}
			if (vm.pordDate != null)
			{
				vm.pordDate = vm.pordDate.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
			}
			if (vm.pordDeliveryDate != null)
			{
				vm.pordDeliveryDate = vm.pordDeliveryDate.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
			}
			if (!base.ModelState.IsValid)
			{
				base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
			else
			{
				if (!string.IsNullOrEmpty(vm.pordCostSheetIds))
				{
					if (vm.pordCostSheetIds.EndsWith(","))
					{
						vm.pordCostSheetIds = vm.pordCostSheetIds.Substring(0, vm.pordCostSheetIds.Length - 1);
					}
					if (vm.pordCostSheetIds.StartsWith(","))
					{
						vm.pordCostSheetIds = vm.pordCostSheetIds.Substring(1, vm.pordCostSheetIds.Length - 1);
					}
				}
				int userId = UserLogin.CurrentUser.UserId;
				DateTime value = now;
				string text7 = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				int id = Financial.Get().Id;
				ObjectParameter objectParameter = new ObjectParameter("insertedId", typeof(int));
				ObjectParameter objectParameter2 = new ObjectParameter("insertedNumber", typeof(long));
				ObjectParameter objectParameter3 = new ObjectParameter("errorMessage", "");
				CRMSpEntities db = _db;
				int? pordProjectId = vm.pordProjectId;
				int? pordCurrencyUnitId = vm.pordCurrencyUnitId;
				decimal? num = default(decimal);
				string pordDate = vm.pordDate;
				DateTime? pordDateTime = vm.pordDateTime;
				int? pordCompanyPersonId = vm.pordCompanyPersonId;
				int? pordReferUserId = vm.pordReferUserId;
				int? pordCurrencyUnitId2 = pordCurrencyUnitId;
				string pordDeliveryDate = vm.pordDeliveryDate;
				DateTime? pordDeliveryDateTime = vm.pordDeliveryDateTime;
				string pordDeliveryTime = vm.pordDeliveryTime;
				int? pordDeliveryTermId = vm.pordDeliveryTermId;
				decimal? pordTaxIndex = num;
				string preOrderPaymentJson = text2;
				string preOrderCommJson = text4;
				int? userId2 = userId;
				int? fPId = id;
				short? month = value2;
				DateTime? registerDate = value;
				string registerDatePersian = text7;
				string appType2 = appType;
				int? languageID = result;
				ObjectParameter insertedId = objectParameter;
				ObjectParameter insertedNumber = objectParameter2;
				ObjectParameter errorMessage = objectParameter3;
				Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)db.WSspIssuePreOrderFromCostSheet(pordProjectId, pordDate, pordDateTime, pordCompanyPersonId, pordReferUserId, pordCurrencyUnitId2, pordDeliveryDate, pordDeliveryDateTime, pordDeliveryTime, pordDeliveryTermId, pordTaxIndex, vm.pordCostSheetIds, vm.pordTypeId, vm.PreOrderOprId, preOrderPaymentJson, preOrderCommJson, userId2, fPId, month, registerDate, registerDatePersian, appType2, languageID, insertedId, insertedNumber, errorMessage, centerId));
				if (objectParameter3.Value != null)
				{
					if (!string.IsNullOrEmpty(objectParameter3.Value.ToString()))
					{
						base.ViewBag.Error = Messages.msgErrorRunFunction + "<br>" + objectParameter3.Value.ToString();
						return View(vm);
					}
					string arg = "";
					int result4 = 0;
					if (objectParameter.Value != null)
					{
						int.TryParse(objectParameter.Value.ToString() ?? "", out result4);
					}
					if (objectParameter2.Value != null)
					{
						arg = objectParameter2.Value.ToString() ?? "";
					}
					if (result4 <= 0)
					{
						base.ViewBag.Error = Messages.msgErrorRunFunction;
					}
					else
					{
						string text8 = Messages.msgSuccessAction + "<br>";
						text8 += string.Format(Messages.msgIssuePord, arg);
						base.ViewBag.Successfull = text8;
						vm.PreOrderId = result4;
					}
				}
				else
				{
					string arg2 = "";
					int result5 = 0;
					if (objectParameter.Value != null)
					{
						int.TryParse(objectParameter.Value.ToString() ?? "", out result5);
					}
					if (objectParameter2.Value != null)
					{
						arg2 = objectParameter2.Value.ToString() ?? "";
					}
					if (result5 <= 0)
					{
						base.ViewBag.Error = Messages.msgErrorRunFunction;
					}
					else
					{
						string text9 = Messages.msgSuccessAction + "<br>";
						text9 += string.Format(Messages.msgIssuePord, arg2);
						base.ViewBag.Successfull = text9;
						vm.PreOrderId = result5;
					}
				}
			}
			vm.pordDate = (vm.pordDateTime.HasValue ? vm.pordDateTime.Value.ToString("yyyy/MM/dd") : "");
			if (vm.pordDeliveryDateTime.HasValue)
			{
				vm.pordDeliveryDate = (vm.pordDeliveryDateTime.HasValue ? vm.pordDeliveryDateTime.Value.ToString("yyyy/MM/dd") : "");
				vm.pordDeliveryTime = (vm.pordDeliveryDateTime.HasValue ? vm.pordDeliveryDateTime.Value.ToString("HH:mm") : "");
			}
		}
		catch (DbEntityValidationException e5)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e5);
			base.ViewBag.Error = Messages.msgErrorRunFunction;
		}
		catch (Exception e6)
		{
			ErrorSignal.FromCurrentContext().Raise(e6);
			base.ViewBag.Error = Messages.msgErrorRunFunction;
		}
		return View(vm);
	}

	[DynamicAuthorize(ControllerName = "frmCostsheet", ActionName = "actIssuePreOrder")]
	public ActionResult SelectCostSheet(int prjId)
	{
		base.ViewBag.ProjectId = prjId;
		return View();
	}

	[AjaxOnly]
	public ActionResult CostSheet_Read([DataSourceRequest] DataSourceRequest request, int ctshPrjId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectCostSheets_Result> list = new List<WSspSelectCostSheets_Result>();
		try
		{
			if (ctshPrjId > 0)
			{
				list = Enumerable.ToList<WSspSelectCostSheets_Result>((IEnumerable<WSspSelectCostSheets_Result>)_db.WSspSelectCostSheets(ctshPrjId, lCID, result));
				foreach (WSspSelectCostSheets_Result item in list)
				{
					_ = item.ctshDate;
					item.ctshDatePersian = item.ctshDate.ToString("yyyy/MM/dd HH:mm:ss");
				}
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

	[DynamicAuthorize(ControllerName = "frmCostsheetDetails", ActionName = "actIssueBuyOrder")]
	public ActionResult BuyOrder(int ctshId, string ctshItemIds)
	{
		WSCostSheetIssueBuyOrderViewModel wSCostSheetIssueBuyOrderViewModel = new WSCostSheetIssueBuyOrderViewModel();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			_ = DateTime.Now;
			wSCostSheetIssueBuyOrderViewModel.CostSheetId = ctshId;
			wSCostSheetIssueBuyOrderViewModel.CostSheetItemIds = ctshItemIds;
			WSspSelectCostSheetsById_Result wSspSelectCostSheetsById_Result = Enumerable.FirstOrDefault<WSspSelectCostSheetsById_Result>((IEnumerable<WSspSelectCostSheetsById_Result>)_db.WSspSelectCostSheetsById(ctshId, lCID, result));
			if (wSspSelectCostSheetsById_Result == null)
			{
				base.ViewBag.Error = Messages.msgNotFound;
			}
			else
			{
				wSCostSheetIssueBuyOrderViewModel.CostSheetId = ctshId;
				wSCostSheetIssueBuyOrderViewModel.CostSheetItemIds = ctshItemIds;
				wSCostSheetIssueBuyOrderViewModel.bordReqCmpId = wSspSelectCostSheetsById_Result.prjCompanyId;
				wSCostSheetIssueBuyOrderViewModel.bordReqCmpName = wSspSelectCostSheetsById_Result.prjCompany ?? "";
				wSCostSheetIssueBuyOrderViewModel.bordReqCmpNumber = wSspSelectCostSheetsById_Result.prjCompanyNumber.ToString();
				wSCostSheetIssueBuyOrderViewModel.bordReqPrsId = wSspSelectCostSheetsById_Result.CompanyPersonId;
				wSCostSheetIssueBuyOrderViewModel.bordReqPrjId = wSspSelectCostSheetsById_Result.ctshCmpProjectId;
				wSCostSheetIssueBuyOrderViewModel.bordReqPrj = wSspSelectCostSheetsById_Result.ctshCmpProject ?? "";
				wSCostSheetIssueBuyOrderViewModel.bordPrjInquiryNum = wSspSelectCostSheetsById_Result.prjInquiryNum ?? "";
				wSCostSheetIssueBuyOrderViewModel.bordPrjNumRef = wSspSelectCostSheetsById_Result.prjNumRef ?? "";
				wSCostSheetIssueBuyOrderViewModel.bordReferUserId = UserLogin.CurrentUser.UserId;
				if (!wSCostSheetIssueBuyOrderViewModel.bordReqCmpId.HasValue)
				{
					base.ViewBag.Error = Messages.msgErrorNotSelectCompany;
				}
				if (!wSCostSheetIssueBuyOrderViewModel.bordReqPrsId.HasValue)
				{
					base.ViewBag.Error = Messages.msgErrorNotSelectCmpPerson;
				}
				if (!wSCostSheetIssueBuyOrderViewModel.bordReqPrjId.HasValue)
				{
					base.ViewBag.Error = Messages.msgErrorNotSelectCmpProject;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		GetBuyOrderOpr();
		GetBordReferUsers();
		GetProductFirstGroups();
		GetBordPaymentType();
		GetCurrencyUnit();
		GetDeliveryTerms();
		return View(wSCostSheetIssueBuyOrderViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmIssueBuyOrderFromCostSheet", ActionName = "actIssueBuyOrder")]
	[ValidateAntiForgeryToken]
	public ActionResult BuyOrder(WSCostSheetIssueBuyOrderViewModel vm)
	{
		//IL_0411: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_113c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1181: Unknown result type (might be due to invalid IL or missing references)
		//IL_11c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_120b: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			int? bordCId = null;
			if (UserLogin.CurrentUser != null)
			{
				bordCId = UserLogin.CurrentUser.UserLastCId;
			}
			GetBuyOrderOpr();
			GetBordReferUsers();
			GetProductFirstGroups();
			GetBordPaymentType();
			GetCurrencyUnit();
			GetDeliveryTerms();
			int? bordIWHId = null;
			WSspSelectCostSheetsById_Result wSspSelectCostSheetsById_Result = Enumerable.FirstOrDefault<WSspSelectCostSheetsById_Result>((IEnumerable<WSspSelectCostSheetsById_Result>)_db.WSspSelectCostSheetsById(vm.CostSheetId, lCID, defLangID));
			if (wSspSelectCostSheetsById_Result == null)
			{
				base.ViewBag.Error = Messages.msgNotFound;
				return View(vm);
			}
			if (!wSspSelectCostSheetsById_Result.prjCompanyId.HasValue || wSspSelectCostSheetsById_Result.prjCompanyId <= 0)
			{
				base.ViewBag.Error = Messages.msgErrorNotSelectCompany;
				return View(vm);
			}
			if (!wSspSelectCostSheetsById_Result.CompanyPersonId.HasValue || wSspSelectCostSheetsById_Result.CompanyPersonId <= 0)
			{
				base.ViewBag.Error = Messages.msgErrorNotSelectCmpPerson;
				return View(vm);
			}
			if (!wSspSelectCostSheetsById_Result.ctshCmpProjectId.HasValue || wSspSelectCostSheetsById_Result.ctshCmpProjectId <= 0)
			{
				base.ViewBag.Error = Messages.msgErrorNotSelectCmpProject;
				return View(vm);
			}
			int? bordCurrencyUnitId = wSspSelectCostSheetsById_Result.ctshSrcCurrencyUnitId;
			vm.bordReqCmpId = wSspSelectCostSheetsById_Result.prjCompanyId;
			vm.bordReqCmpName = wSspSelectCostSheetsById_Result.prjCompany ?? "";
			vm.bordReqCmpNumber = wSspSelectCostSheetsById_Result.prjCompanyNumber.ToString();
			vm.bordReqPrsId = wSspSelectCostSheetsById_Result.CompanyPersonId;
			vm.bordReqPrjId = wSspSelectCostSheetsById_Result.ctshCmpProjectId;
			vm.bordReqPrj = wSspSelectCostSheetsById_Result.ctshCmpProject ?? "";
			vm.bordPrjInquiryNum = wSspSelectCostSheetsById_Result.prjInquiryNum ?? "";
			vm.bordPrjNumRef = wSspSelectCostSheetsById_Result.prjNumRef ?? "";
			DateTime dateTime = default(DateTime);
			string text = "";
			DateTime now = DateTime.Now;
			string buyOrderPaymentJson = "";
			try
			{
				if (!string.IsNullOrEmpty(vm.BuyOrderPayments))
				{
					List<WSCostSheetIssueBuyOrderPayViewModel> list = new List<WSCostSheetIssueBuyOrderPayViewModel>();
					if (!string.IsNullOrEmpty(vm.BuyOrderPayments))
					{
						list = new JavaScriptSerializer().Deserialize<List<WSCostSheetIssueBuyOrderPayViewModel>>(vm.BuyOrderPayments);
						if (Enumerable.Any<WSCostSheetIssueBuyOrderPayViewModel>((IEnumerable<WSCostSheetIssueBuyOrderPayViewModel>)list))
						{
							foreach (WSCostSheetIssueBuyOrderPayViewModel item in list)
							{
								try
								{
									string text2 = now.ToString("HH:mm:ss");
									text = PersianDate.GetFormatetdDate(item.bordpayImportDate.Replace("/", ""));
									switch (lCID)
									{
									case 1065:
										dateTime = DateTime.Parse(text + " " + text2, new PersianCulture());
										item.bordpayImportDate = dateTime.ToString("yyyyMMdd");
										break;
									case 1025:
										dateTime = DateTime.Parse(text + " " + text2, new CultureInfo("ar-SA"));
										item.bordpayImportDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
										break;
									default:
										dateTime = DateTime.Parse(text + " " + text2, new CultureInfo("en-US"));
										item.bordpayImportDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
										break;
									}
									item.bordpayImportDateTime = dateTime.ToString("yyyy/MM/dd HH:mm:ss", new CultureInfo("en-US"));
								}
								catch (Exception e)
								{
									ErrorSignal.FromCurrentContext().Raise(e);
									base.ViewBag.Error = string.Format(Messages.ErrorInFormat, Labels.ctshPordPayImportDate);
									return View(vm);
								}
							}
							buyOrderPaymentJson = new JavaScriptSerializer().Serialize((object)list);
						}
					}
				}
			}
			catch (Exception ex)
			{
				ErrorSignal.FromCurrentContext().Raise(ex);
				base.ViewBag.Error = ex.Message;
				return View(vm);
			}
			try
			{
				if (!string.IsNullOrEmpty(vm.bordOrderDate))
				{
					text = PersianDate.GetFormatetdDate(vm.bordOrderDate.Replace("/", ""));
					text = text + " " + now.ToString("HH:mm:ss");
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text, new PersianCulture());
						vm.bordOrderDate = dateTime.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime = DateTime.Parse(text, new CultureInfo("ar-SA"));
						vm.bordOrderDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime = DateTime.Parse(text, new CultureInfo("en-US"));
						vm.bordOrderDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
					vm.bordOrderDateTime = dateTime;
				}
				else
				{
					vm.bordOrderDateTime = null;
				}
			}
			catch (Exception e2)
			{
				ErrorSignal.FromCurrentContext().Raise(e2);
				base.ViewBag.Error = string.Format(Messages.ErrorInFormat, Labels.ctshBordOrderDate);
				return View(vm);
			}
			try
			{
				if (!string.IsNullOrEmpty(vm.bordDeliveryDatePersian))
				{
					text = PersianDate.GetFormatetdDate(vm.bordDeliveryDatePersian.Replace("/", ""));
					text = (string.IsNullOrEmpty(vm.bordDeliveryTime) ? (text + " 00:00:00") : (text + " " + vm.bordDeliveryTime.Trim()));
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text, new PersianCulture());
						vm.bordDeliveryDatePersian = dateTime.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime = DateTime.Parse(text, new CultureInfo("ar-SA"));
						vm.bordDeliveryDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime = DateTime.Parse(text, new CultureInfo("en-US"));
						vm.bordDeliveryDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
					vm.bordDeliveryDate = dateTime;
				}
				else
				{
					vm.bordDeliveryDate = null;
				}
			}
			catch (Exception e3)
			{
				ErrorSignal.FromCurrentContext().Raise(e3);
				base.ViewBag.Error = string.Format(Messages.ErrorInFormat, Labels.ctshBordDeliveryDate);
				return View(vm);
			}
			try
			{
				if (!string.IsNullOrEmpty(vm.bordSupplierDeliveryDatePersian))
				{
					text = PersianDate.GetFormatetdDate(vm.bordSupplierDeliveryDatePersian.Replace("/", ""));
					text = (string.IsNullOrEmpty(vm.bordSupplierDeliveryTime) ? (text + " 00:00:00") : (text + " " + vm.bordSupplierDeliveryTime.Trim()));
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text, new PersianCulture());
						vm.bordSupplierDeliveryDatePersian = dateTime.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime = DateTime.Parse(text, new CultureInfo("ar-SA"));
						vm.bordSupplierDeliveryDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime = DateTime.Parse(text, new CultureInfo("en-US"));
						vm.bordSupplierDeliveryDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
					vm.bordSupplierDeliveryDate = dateTime;
				}
				else
				{
					vm.bordSupplierDeliveryDate = null;
				}
			}
			catch (Exception e4)
			{
				ErrorSignal.FromCurrentContext().Raise(e4);
				base.ViewBag.Error = string.Format(Messages.ErrorInFormat, Labels.ctshBordSupplierDeliveryDate);
				return View(vm);
			}
			try
			{
				if (!string.IsNullOrEmpty(vm.bordFinalDeliveryDatePersian))
				{
					text = PersianDate.GetFormatetdDate(vm.bordFinalDeliveryDatePersian.Replace("/", ""));
					text = (string.IsNullOrEmpty(vm.bordFinalDeliveryTime) ? (text + " 00:00:00") : (text + " " + vm.bordFinalDeliveryTime.Trim()));
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text, new PersianCulture());
						vm.bordFinalDeliveryDatePersian = dateTime.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime = DateTime.Parse(text, new CultureInfo("ar-SA"));
						vm.bordFinalDeliveryDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime = DateTime.Parse(text, new CultureInfo("en-US"));
						vm.bordFinalDeliveryDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
					vm.bordFinalDeliveryDate = dateTime;
				}
				else
				{
					vm.bordFinalDeliveryDate = null;
				}
			}
			catch (Exception e5)
			{
				ErrorSignal.FromCurrentContext().Raise(e5);
				base.ViewBag.Error = string.Format(Messages.ErrorInFormat, Labels.ctshBordFinalDeliveryDate);
				return View(vm);
			}
			if (vm.bordOrderDate != null)
			{
				vm.bordOrderDate = vm.bordOrderDate.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
			}
			if (vm.bordDeliveryDatePersian != null)
			{
				vm.bordDeliveryDatePersian = vm.bordDeliveryDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
			}
			if (vm.bordSupplierDeliveryDatePersian != null)
			{
				vm.bordSupplierDeliveryDatePersian = vm.bordSupplierDeliveryDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
			}
			if (vm.bordFinalDeliveryDatePersian != null)
			{
				vm.bordFinalDeliveryDatePersian = vm.bordFinalDeliveryDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
			}
			decimal num = default(decimal);
			decimal result = default(decimal);
			decimal result2 = default(decimal);
			decimal result3 = default(decimal);
			double result4 = 0.0;
			decimal result5 = default(decimal);
			decimal result6 = default(decimal);
			double result7 = 0.0;
			decimal result8 = default(decimal);
			decimal result9 = default(decimal);
			double result10 = 0.0;
			decimal result11 = default(decimal);
			decimal.TryParse(vm.bordFacilityCost.ToString(), out result);
			decimal.TryParse(vm.bordFacilityCostPercent.ToString(), out result2);
			decimal.TryParse(vm.bordFreightCost.ToString(), out result3);
			double.TryParse(vm.bordFreightCurrencyRate.ToString(), out result4);
			if (result4 == 0.0)
			{
				result4 = 1.0;
			}
			decimal.TryParse(vm.bordFinalFreightCost.ToString(), out result5);
			decimal.TryParse(vm.bordCustomsFee.ToString(), out result6);
			double.TryParse(vm.bordCustomsCurrencyRate.ToString(), out result7);
			if (result7 == 0.0)
			{
				result7 = 1.0;
			}
			decimal.TryParse(vm.bordFinalCustomsFee.ToString(), out result8);
			decimal.TryParse(vm.bordCommission.ToString(), out result9);
			double.TryParse(vm.bordCommissionCurrencyRate.ToString(), out result10);
			if (result10 == 0.0)
			{
				result10 = 1.0;
			}
			decimal.TryParse(vm.bordFinalCommission.ToString(), out result11);
			result5 = result3 * (decimal)result4;
			result8 = result6 * (decimal)result7;
			result11 = result9 * (decimal)result10;
			num = result + result5 + result8 + result11;
			vm.bordTotalFinalCost = num;
			vm.bordFreightCurrencyRate = result4;
			vm.bordFinalFreightCost = result5;
			vm.bordCustomsCurrencyRate = result7;
			vm.bordFinalCustomsFee = result8;
			vm.bordCommissionCurrencyRate = result10;
			vm.bordFinalCommission = result11;
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(vm.bordDeliveryTerm_Lang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(vm.bordDeliveryTerm_Lang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = vm.bordDeliveryTerm,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(vm.bordNote_Lang))
			{
				list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(vm.bordNote_Lang);
			}
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = vm.bordNote,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(vm.bordCustomsPart_Lang))
			{
				list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(vm.bordCustomsPart_Lang);
			}
			list4.Add(new CommonMultiLanguageViewModel
			{
				Value = vm.bordCustomsPart,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(vm.bordForwarderName_Lang))
			{
				list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(vm.bordForwarderName_Lang);
			}
			list5.Add(new CommonMultiLanguageViewModel
			{
				Value = vm.bordForwarderName,
				LanguageId = lCID
			});
			string text3 = "";
			string text4 = "";
			string text5 = "";
			string text6 = "";
			text3 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
			text4 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
			text5 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
			string bordForwarderName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
			foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages m) => m.LanguageID != defLangID))))
			{
				string text7 = "";
				string text8 = "";
				string text9 = "";
				string text10 = "";
				text7 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : "");
				text8 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : "");
				text9 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : "");
				text10 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : "");
				text6 = text6 + "[LangId=" + lang.LanguageID + "|,|bordDeliveryTerm=" + text7 + "|,|bordNote=" + text8 + "|,|bordForwarderName=" + text10 + "|,|bordCustomsPart=" + text9 + "|,|]@";
			}
			if (!base.ModelState.IsValid)
			{
				base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
			else
			{
				int userId = UserLogin.CurrentUser.UserId;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				int id = Financial.Get().Id;
				ObjectParameter objectParameter = new ObjectParameter("insertedId", typeof(int));
				ObjectParameter objectParameter2 = new ObjectParameter("insertedNumber", typeof(long));
				ObjectParameter objectParameter3 = new ObjectParameter("errorMessage", "");
				Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_db.WSspIssueBuyOrderFromCostSheet(vm.CostSheetId, vm.CostSheetItemIds, vm.BuyOrderOprId, vm.bordOrderNumber, vm.bordOrderDate, vm.bordOrderDateTime, vm.bordReferUserId, bordCurrencyUnitId, vm.bordCompanyId, vm.bordCompanyPersonId, vm.bordProjectId, vm.bordReqCmpId, vm.bordReqPrsId, vm.bordReqPrjId, vm.bordFacilityCmpId, vm.bordFacilityPrsId, vm.bordFacilityPrjId, text3, vm.bordDeliveryDate, vm.bordDeliveryDatePersian, vm.bordSupplierDeliveryDate, vm.bordSupplierDeliveryDatePersian, vm.bordFinalDeliveryDate, vm.bordFinalDeliveryDatePersian, null, null, null, text4, result, result2, bordForwarderName, result3, vm.bordFreightCurrUnId, result4, result5, text5, result6, vm.bordCustomsCurrUnId, result7, result8, num, result9, vm.bordCommissionCurrUnId, result10, result11, text6, bordIWHId, buyOrderPaymentJson, userId, id, value2, value, registerDatePersian, appType, defLangID, objectParameter, objectParameter2, objectParameter3, bordCId));
				if (objectParameter3.Value != null)
				{
					if (!string.IsNullOrEmpty(objectParameter3.Value.ToString()))
					{
						base.ViewBag.Error = Messages.msgErrorRunFunction + "<br>" + objectParameter3.Value.ToString();
						return View(vm);
					}
					string arg = "";
					int result12 = 0;
					if (objectParameter.Value != null)
					{
						int.TryParse(objectParameter.Value.ToString() ?? "", out result12);
					}
					if (objectParameter2.Value != null)
					{
						arg = objectParameter2.Value.ToString() ?? "";
					}
					if (result12 <= 0)
					{
						base.ViewBag.Error = Messages.msgErrorRunFunction;
					}
					else
					{
						string text11 = Messages.msgSuccessAction + "<br>";
						text11 += string.Format(Messages.msgIssueBord, arg);
						base.ViewBag.Successfull = text11;
						vm.BuyOrderId = result12;
					}
				}
				else
				{
					string arg2 = "";
					int result13 = 0;
					if (objectParameter.Value != null)
					{
						int.TryParse(objectParameter.Value.ToString() ?? "", out result13);
					}
					if (objectParameter2.Value != null)
					{
						arg2 = objectParameter2.Value.ToString() ?? "";
					}
					if (result13 <= 0)
					{
						base.ViewBag.Error = Messages.msgErrorRunFunction;
					}
					else
					{
						string text12 = Messages.msgSuccessAction + "<br>";
						text12 += string.Format(Messages.msgIssueBord, arg2);
						base.ViewBag.Successfull = text12;
						vm.BuyOrderId = result13;
					}
				}
			}
			if (vm.bordOrderDate != null)
			{
				vm.bordOrderDate = (vm.bordOrderDateTime.HasValue ? vm.bordOrderDateTime.Value.ToString("yyyy/MM/dd") : "");
			}
			if (vm.bordDeliveryDate.HasValue)
			{
				vm.bordDeliveryDatePersian = (vm.bordDeliveryDate.HasValue ? vm.bordDeliveryDate.Value.ToString("yyyy/MM/dd") : "");
				vm.bordDeliveryTime = (vm.bordDeliveryDate.HasValue ? vm.bordDeliveryDate.Value.ToString("HH:mm") : "");
			}
			if (vm.bordSupplierDeliveryDate.HasValue)
			{
				vm.bordSupplierDeliveryDatePersian = (vm.bordSupplierDeliveryDate.HasValue ? vm.bordSupplierDeliveryDate.Value.ToString("yyyy/MM/dd") : "");
				vm.bordSupplierDeliveryTime = (vm.bordSupplierDeliveryDate.HasValue ? vm.bordSupplierDeliveryDate.Value.ToString("HH:mm") : "");
			}
			if (vm.bordFinalDeliveryDate.HasValue)
			{
				vm.bordFinalDeliveryDatePersian = (vm.bordFinalDeliveryDate.HasValue ? vm.bordFinalDeliveryDate.Value.ToString("yyyy/MM/dd") : "");
				vm.bordFinalDeliveryTime = (vm.bordFinalDeliveryDate.HasValue ? vm.bordFinalDeliveryDate.Value.ToString("HH:mm") : "");
			}
		}
		catch (DbEntityValidationException e6)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e6);
			base.ViewBag.Error = Messages.msgErrorRunFunction;
		}
		catch (Exception e7)
		{
			ErrorSignal.FromCurrentContext().Raise(e7);
			base.ViewBag.Error = Messages.msgErrorRunFunction;
		}
		return View(vm);
	}

	[DynamicAuthorize(ControllerName = "frmCostsheetDetails", ActionName = "actIssueBuyOrder")]
	public ActionResult SelectCostSheetItems(int ctshId)
	{
		base.ViewBag.CostSheetId = ctshId;
		return View();
	}

	[AjaxOnly]
	public ActionResult CostSheetItems_Read([DataSourceRequest] DataSourceRequest request, int ctshId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectCostSheetItems_Result> enumerable = new List<WSspSelectCostSheetItems_Result>();
		try
		{
			if (ctshId > 0)
			{
				enumerable = Enumerable.ToList<WSspSelectCostSheetItems_Result>((IEnumerable<WSspSelectCostSheetItems_Result>)_db.WSspSelectCostSheetItems(ctshId, lCID, result));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetBuyOrderOpr()
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
			List<WSspSelectBuyOrderOpr_Result> list2 = CRMIdeal.Classes.Helper.BuyOrder.SelectBuyOrderOpr();
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<WSspSelectBuyOrderOpr_Result, SelectListItem>((IEnumerable<WSspSelectBuyOrderOpr_Result>)list2, (Func<WSspSelectBuyOrderOpr_Result, SelectListItem>)((WSspSelectBuyOrderOpr_Result item) => new SelectListItem
				{
					Text = item.Name,
					Value = item.BuyOrderOprID.ToString(),
					Selected = false
				})));
			}
			if (Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)list))
			{
				list[0].Selected = true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.BuyOrderOprList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetBordReferUsers()
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
			_ = Configuration.MaxCountOfOnlineUser;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<WSspSelectBuyOrderReferUsers_Result> list2 = Enumerable.ToList<WSspSelectBuyOrderReferUsers_Result>((IEnumerable<WSspSelectBuyOrderReferUsers_Result>)_db.WSspSelectBuyOrderReferUsers(UserLogin.CurrentUser.UserId, lCID, result, result2));
			list.AddRange(Enumerable.Select<WSspSelectBuyOrderReferUsers_Result, SelectListItem>((IEnumerable<WSspSelectBuyOrderReferUsers_Result>)list2, (Func<WSspSelectBuyOrderReferUsers_Result, SelectListItem>)((WSspSelectBuyOrderReferUsers_Result item) => new SelectListItem
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
		base.ViewBag.BordReferUsersList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetProductFirstGroups()
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
			List<WSspSelectProductFirstGroup_Result> list2 = Enumerable.ToList<WSspSelectProductFirstGroup_Result>((IEnumerable<WSspSelectProductFirstGroup_Result>)_db.WSspSelectProductFirstGroup(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectProductFirstGroup_Result, SelectListItem>((IEnumerable<WSspSelectProductFirstGroup_Result>)list2, (Func<WSspSelectProductFirstGroup_Result, SelectListItem>)((WSspSelectProductFirstGroup_Result item) => new SelectListItem
			{
				Text = item.FGName,
				Value = item.PrdFirstGroupID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ProductFirstGroupsList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetProductSecondGroups(int fgId)
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
			List<WSspSelectProductSecondGroup_Result> list2 = Enumerable.ToList<WSspSelectProductSecondGroup_Result>((IEnumerable<WSspSelectProductSecondGroup_Result>)_db.WSspSelectProductSecondGroup(fgId, lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectProductSecondGroup_Result, SelectListItem>((IEnumerable<WSspSelectProductSecondGroup_Result>)list2, (Func<WSspSelectProductSecondGroup_Result, SelectListItem>)((WSspSelectProductSecondGroup_Result item) => new SelectListItem
			{
				Text = item.SGName,
				Value = item.PrdSecondGroupID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ProductSecondGroupsList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetWarehouses()
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
			List<WSspSelectActiveWareHouse_Result> list2 = CRMIdeal.Classes.Helper.Warehouse.SelectActiveWareHouse();
			list.AddRange(Enumerable.Select<WSspSelectActiveWareHouse_Result, SelectListItem>((IEnumerable<WSspSelectActiveWareHouse_Result>)list2, (Func<WSspSelectActiveWareHouse_Result, SelectListItem>)((WSspSelectActiveWareHouse_Result item) => new SelectListItem
			{
				Text = item.WrhsName,
				Value = item.WareHouseID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.WarehousesList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetBordPaymentType()
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
			List<WSspSelectBuyOrderPaymentTypes_Result> list2 = Enumerable.ToList<WSspSelectBuyOrderPaymentTypes_Result>((IEnumerable<WSspSelectBuyOrderPaymentTypes_Result>)_db.WSspSelectBuyOrderPaymentTypes(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectBuyOrderPaymentTypes_Result, SelectListItem>((IEnumerable<WSspSelectBuyOrderPaymentTypes_Result>)list2, (Func<WSspSelectBuyOrderPaymentTypes_Result, SelectListItem>)((WSspSelectBuyOrderPaymentTypes_Result item) => new SelectListItem
			{
				Text = item.bordpayType,
				Value = item.BuyOrderPaymentTypeId.ToString(),
				Selected = false
			})));
			if (Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)list))
			{
				list[0].Selected = true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.BordPayTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCurrencyUnit()
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
			List<WSspSelectCurrencyUnits_Result> list2 = Enumerable.ToList<WSspSelectCurrencyUnits_Result>((IEnumerable<WSspSelectCurrencyUnits_Result>)_db.WSspSelectCurrencyUnits(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectCurrencyUnits_Result, SelectListItem>((IEnumerable<WSspSelectCurrencyUnits_Result>)list2, (Func<WSspSelectCurrencyUnits_Result, SelectListItem>)((WSspSelectCurrencyUnits_Result item) => new SelectListItem
			{
				Text = item.CurrencyUnit,
				Value = item.CurrencyUnitID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.FreightCurrencyUnitList = list;
		base.ViewBag.CustomsCurrencyUnitList = list;
		base.ViewBag.CommissionCurrencyUnitList = list;
		base.ViewBag.PordCurrencyUnitList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetDeliveryTerms()
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
			List<WSspSelectDeliveryTerms_Result> list2 = Enumerable.ToList<WSspSelectDeliveryTerms_Result>((IEnumerable<WSspSelectDeliveryTerms_Result>)_db.WSspSelectDeliveryTerms(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectDeliveryTerms_Result, SelectListItem>((IEnumerable<WSspSelectDeliveryTerms_Result>)list2, (Func<WSspSelectDeliveryTerms_Result, SelectListItem>)((WSspSelectDeliveryTerms_Result item) => new SelectListItem
			{
				Text = item.DeliveryTerm,
				Value = item.DeliveryTermId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.DeliveryTermsList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPordReferUsers()
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
			_ = Configuration.MaxCountOfOnlineUser;
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
		base.ViewBag.PordReferUsersList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPordPaymentType()
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
			int value = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserId : 0);
			List<WSspSelectActiveOrderPaymentTypes_Result> list2 = Enumerable.ToList<WSspSelectActiveOrderPaymentTypes_Result>((IEnumerable<WSspSelectActiveOrderPaymentTypes_Result>)_dbI.WSspSelectActiveOrderPaymentTypes(lCID, result, value));
			list.AddRange(Enumerable.Select<WSspSelectActiveOrderPaymentTypes_Result, SelectListItem>((IEnumerable<WSspSelectActiveOrderPaymentTypes_Result>)list2, (Func<WSspSelectActiveOrderPaymentTypes_Result, SelectListItem>)((WSspSelectActiveOrderPaymentTypes_Result item) => new SelectListItem
			{
				Text = item.ordpayType,
				Value = item.OrderPaymentTypeId.ToString(),
				Selected = false
			})));
			if (Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)list))
			{
				list[0].Selected = true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PordPayTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCommUser()
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectUserForLinkedType_Result, SelectListItem>((IEnumerable<CRMspSelectUserForLinkedType_Result>)Enumerable.ToList<CRMspSelectUserForLinkedType_Result>((IEnumerable<CRMspSelectUserForLinkedType_Result>)_db.CRMspSelectUserForLinkedType(UserLogin.CurrentUser.UserId, 21, lCID, result, result2)), (Func<CRMspSelectUserForLinkedType_Result, SelectListItem>)((CRMspSelectUserForLinkedType_Result item) => new SelectListItem
			{
				Text = item.UserName,
				Value = item.LinkedUserId.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CommUserList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCompanyPerson(int cmpId)
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyPersons_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyPersons_Result>)CRMIdeal.Classes.Helper.Company.SelectCompanyPersons(cmpId, 0, false), (Func<CRMspSelectCompanyPersons_Result, SelectListItem>)((CRMspSelectCompanyPersons_Result item) => new SelectListItem
			{
				Text = item.PersonTitleName,
				Value = item.CompanyPersonID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CompanyPersonList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPreOrderTypes()
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
			List<WSspSelectPreOrderTypes_Result> list2 = CRMIdeal.Classes.Helper.PreOrder.SelectPreOrderTypes();
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
		base.ViewBag.PreOrderTypesList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPreOrderOpr()
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
			List<WSspSelectPreOrderOpr_Result> list2 = Enumerable.ToList<WSspSelectPreOrderOpr_Result>((IEnumerable<WSspSelectPreOrderOpr_Result>)_db.WSspSelectPreOrderOpr(lCID, result));
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

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}

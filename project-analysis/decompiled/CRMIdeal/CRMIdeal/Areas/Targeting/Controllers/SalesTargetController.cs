using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Calendar;
using CRM.General.Security;
using CRM.Models;
using CRM.Models.ViewModel.Targeting;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CRMIdeal.Areas.Targeting.Controllers;

public class SalesTargetController : Controller
{
	private CRMSpEntities _db = new CRMSpEntities();

	private CRMSpIEntities _dbI = new CRMSpIEntities();

	private CRMSpIIEntities _dbII = new CRMSpIIEntities();

	private CRMSpIIIEntities _dbIII = new CRMSpIIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSalesTarget")]
	public ActionResult Index()
	{
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmSalesTarget", ActionName = "actInsert,actEdit,actCopy")]
	public ActionResult InsertEdit(int? targetId, bool isCopy = false)
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
		SalesTargetViewModel salesTargetViewModel = new SalesTargetViewModel();
		try
		{
			List<CRMspSelectUserDepartments_Result> list = Enumerable.ToList<CRMspSelectUserDepartments_Result>((IEnumerable<CRMspSelectUserDepartments_Result>)_db.CRMspSelectUserDepartments(lCID, result, result2));
			List<CRMspSelectUsersWithPaging_Result> list2 = Enumerable.ToList<CRMspSelectUsersWithPaging_Result>((IEnumerable<CRMspSelectUsersWithPaging_Result>)_dbIII.CRMspSelectUsersWithPaging(UserLogin.CurrentUser.UserId, 0, 0, result2, isActive: true, departmentId: 0, searchTerm: "", languageID: lCID, defaultLanguageID: result, linkedTypeId: 16, excludeUserIds: ""));
			List<SelectListItem> list3 = new List<SelectListItem>();
			list3.AddRange(Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectUserDepartments_Result, SelectListItem>((IEnumerable<CRMspSelectUserDepartments_Result>)list, (Func<CRMspSelectUserDepartments_Result, SelectListItem>)((CRMspSelectUserDepartments_Result item) => new SelectListItem
			{
				Text = item.Department,
				Value = item.DepartmentID.ToString(),
				Selected = false
			}))));
			base.ViewBag.Departments = list3;
			List<SelectListItem> list4 = new List<SelectListItem>();
			list4.AddRange(Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectUsersWithPaging_Result, SelectListItem>((IEnumerable<CRMspSelectUsersWithPaging_Result>)list2, (Func<CRMspSelectUsersWithPaging_Result, SelectListItem>)((CRMspSelectUsersWithPaging_Result item) => new SelectListItem
			{
				Text = item.LName + " " + item.FName,
				Value = item.UserId.ToString(),
				Selected = false
			}))));
			base.ViewBag.Users = list4;
			if (targetId > 0)
			{
				WSspSelectSalesTarget_Result wSspSelectSalesTarget_Result = Enumerable.FirstOrDefault<WSspSelectSalesTarget_Result>((IEnumerable<WSspSelectSalesTarget_Result>)_dbIII.WSspSelectSalesTarget(targetId, lCID, result));
				if (wSspSelectSalesTarget_Result != null)
				{
					salesTargetViewModel = new SalesTargetViewModel
					{
						SalesTargetId = wSspSelectSalesTarget_Result.SalesTargetId,
						TargetTitle = wSspSelectSalesTarget_Result.TargetTitle,
						TargetTitle_Lang = wSspSelectSalesTarget_Result.LangTitleJson,
						TargetFromDateTime = wSspSelectSalesTarget_Result.TargetFromDate,
						TargetToDateTime = wSspSelectSalesTarget_Result.TargetToDate,
						TargetDistributionDetailsJson = wSspSelectSalesTarget_Result.TargetDistributionDetailsJson,
						TargetTermsJson = wSspSelectSalesTarget_Result.TargetTermsJson,
						TargetUserScopeJson = wSspSelectSalesTarget_Result.TargetUserScopeJson,
						TargetOrderCount = wSspSelectSalesTarget_Result.TargetOrderCount,
						TargetOrderAmount = wSspSelectSalesTarget_Result.TargetOrderAmount
					};
					SalesTargetViewModel salesTargetViewModel2 = salesTargetViewModel;
					_ = wSspSelectSalesTarget_Result.TargetFromDate;
					salesTargetViewModel2.TargetFromDate = wSspSelectSalesTarget_Result.TargetFromDate.ToString("yyyy/MM/dd HH:mm:ss");
					SalesTargetViewModel salesTargetViewModel3 = salesTargetViewModel;
					_ = wSspSelectSalesTarget_Result.TargetToDate;
					salesTargetViewModel3.TargetToDate = wSspSelectSalesTarget_Result.TargetToDate.ToString("yyyy/MM/dd HH:mm:ss");
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		if (isCopy)
		{
			salesTargetViewModel.SalesTargetId = 0;
		}
		salesTargetViewModel.TargetUserScope = new SalesTargetUserScopeViewModel();
		salesTargetViewModel.TargetDistributionDetails = new SalesTargetDistributionViewModel();
		salesTargetViewModel.TargetTerms = new List<SalesTargetTermViewModel>();
		return View(salesTargetViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmSalesTargetDataEntry", ActionName = "actPost")]
	public ActionResult InsertEdit(SalesTargetViewModel model)
	{
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ed0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0de5: Unknown result type (might be due to invalid IL or missing references)
		DateTime now = DateTime.Now;
		DateTime value = now;
		string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
		_ = UserLogin.CurrentUser.UserId;
		string appType = Configuration.AppType;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
		short.Parse(Financial.Get().Id.ToString());
		string text = "";
		int result2 = 0;
		int id2 = Financial.Get().Id;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
		}
		try
		{
			if (base.ModelState.IsValid)
			{
				int num = 0;
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.TargetTitle_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.TargetTitle_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = model.TargetTitle,
					LanguageId = lCID
				});
				if (string.IsNullOrEmpty(model.TargetTitle))
				{
					text = text + string.Format(Messages.ErrorFieldEmpty, Labels.Title) + "<br>";
					num++;
				}
				else if (!Public.CheckMultiLanguage(model.TargetTitle, list))
				{
					num++;
				}
				if (model.SalesTargetId == 0 && !VersionBuyer.SalesTarget && Enumerable.Count<WSspSelectSaleTargets_Result>((IEnumerable<WSspSelectSaleTargets_Result>)_dbIII.WSspSelectSaleTargets(null, lCID, result)) >= 1)
				{
					text = text + "BV|" + string.Format(Messages.VersionBuyWithCount, "1");
					num++;
				}
				if (!string.IsNullOrEmpty(model.TargetFromDate))
				{
					model.TargetFromDate = model.TargetFromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
						.Replace(" ", "")
						.Replace("_", "");
					switch (lCID)
					{
					case 1065:
						model.TargetFromDateTime = DateTime.Parse(PersianDate.GetFormatetdDate(model.TargetFromDate) + " 00:00:00");
						break;
					case 1025:
						model.TargetFromDateTime = DateTime.Parse(PersianDate.GetFormatetdDate(model.TargetFromDate) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None);
						break;
					default:
						model.TargetFromDateTime = DateTime.Parse(PersianDate.GetFormatetdDate(model.TargetFromDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None);
						break;
					}
				}
				else
				{
					num++;
					text = text + string.Format(Messages.ErrorFieldEmpty, Labels.FromDate) + "<br>";
				}
				if (!string.IsNullOrEmpty(model.TargetToDate))
				{
					model.TargetToDate = model.TargetToDate.Replace("/", "").Replace("-", "").Replace("\\", "")
						.Replace(" ", "")
						.Replace("_", "");
					switch (lCID)
					{
					case 1065:
						model.TargetToDateTime = DateTime.Parse(PersianDate.GetFormatetdDate(model.TargetToDate) + " 00:00:00");
						break;
					case 1025:
						model.TargetToDateTime = DateTime.Parse(PersianDate.GetFormatetdDate(model.TargetToDate) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None);
						break;
					default:
						model.TargetToDateTime = DateTime.Parse(PersianDate.GetFormatetdDate(model.TargetToDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None);
						break;
					}
				}
				else
				{
					num++;
					text = text + string.Format(Messages.ErrorFieldEmpty, Labels.ToDate) + "<br>";
				}
				if (!string.IsNullOrEmpty(model.TargetDistributionDetailsJson))
				{
					model.TargetDistributionDetails = JsonConvert.DeserializeObject<SalesTargetDistributionViewModel>(model.TargetDistributionDetailsJson);
				}
				else
				{
					model.TargetDistributionDetails = null;
				}
				if (!string.IsNullOrEmpty(model.TargetTermsJson))
				{
					model.TargetTerms = JsonConvert.DeserializeObject<List<SalesTargetTermViewModel>>(model.TargetTermsJson);
				}
				else
				{
					model.TargetTerms = null;
				}
				if (!string.IsNullOrEmpty(model.TargetUserScopeJson))
				{
					model.TargetUserScope = JsonConvert.DeserializeObject<SalesTargetUserScopeViewModel>(model.TargetUserScopeJson);
				}
				if (model.TargetDistributionDetails != null && (string.IsNullOrEmpty(model.TargetDistributionDetails.Key) || model.TargetDistributionDetails.Key == "0" || model.TargetDistributionDetails.Items == null || model.TargetDistributionDetails.Items.Count == 0))
				{
					model.TargetDistributionDetails = null;
					model.TargetDistributionDetailsJson = null;
				}
				string text2 = model.TargetType ?? "";
				if (string.IsNullOrEmpty(text2) || (text2 != "Count" && text2 != "Amount"))
				{
					num++;
					text = text + Messages.msgSalesTargetTargetTypeRequired + "<br>";
				}
				else if (text2 == "Count")
				{
					if (model.TargetOrderCount <= 0)
					{
						num++;
						text = text + string.Format(Messages.msgSalesTargetFieldMustBePositive, Labels.Count) + "<br>";
					}
					decimal? targetOrderAmount = model.TargetOrderAmount;
					if ((targetOrderAmount.GetValueOrDefault() > default(decimal)) & targetOrderAmount.HasValue)
					{
						num++;
						text = text + string.Format(Messages.msgSalesTargetFieldMustBeZeroInMode, Labels.Count, Labels.Amount) + "<br>";
					}
				}
				else if (text2 == "Amount")
				{
					decimal? targetOrderAmount = model.TargetOrderAmount;
					if ((targetOrderAmount.GetValueOrDefault() <= default(decimal)) & targetOrderAmount.HasValue)
					{
						num++;
						text = text + string.Format(Messages.msgSalesTargetFieldMustBePositive, Labels.Amount) + "<br>";
					}
					if (model.TargetOrderCount > 0)
					{
						num++;
						text = text + string.Format(Messages.msgSalesTargetFieldMustBeZeroInMode, Labels.Amount, Labels.Count) + "<br>";
					}
				}
				if (model.TargetDistributionDetails != null && model.TargetTerms != null)
				{
					string distCriterionId = model.TargetDistributionDetails.Key;
					if (Enumerable.Any<string>((IEnumerable<string>)Enumerable.ToList<string>(Enumerable.Distinct<string>(Enumerable.SelectMany<SalesTargetTermViewModel, string>((IEnumerable<SalesTargetTermViewModel>)model.TargetTerms, (Func<SalesTargetTermViewModel, IEnumerable<string>>)((SalesTargetTermViewModel t) => Enumerable.Select<SalesTargetTermItemViewModel, string>((IEnumerable<SalesTargetTermItemViewModel>)t.Items, (Func<SalesTargetTermItemViewModel, string>)((SalesTargetTermItemViewModel i) => t.Key)))))), (Func<string, bool>)((string i) => i == distCriterionId)))
					{
						num++;
						text = text + Messages.msgSalesTargetDistributionConflictWithCondition + "<br>";
					}
				}
				if (model.TargetUserScope != null)
				{
					if (model.TargetUserScope.Key == 2)
					{
						if (string.IsNullOrEmpty(model.TargetUserScope.DepartmentId) || model.TargetUserScope.DepartmentId == "0")
						{
							num++;
							text = text + Messages.msgSalesTargetDepartmentRequired + "<br>";
						}
					}
					else if (model.TargetUserScope.Key == 3 && (model.TargetUserScope.SelectedUsers == null || model.TargetUserScope.SelectedUsers.Count == 0))
					{
						num++;
						text = text + Messages.msgSalesTargetUserRequired + "<br>";
					}
				}
				if (model.TargetDistributionDetails != null)
				{
					foreach (SalesTargetDistributionItemViewModel item in model.TargetDistributionDetails.Items)
					{
						decimal? num2 = ((!(text2 == "Count")) ? item.OrderAmount : ((decimal?)item.OrderCount));
						if (!num2.HasValue || num2.Value <= 0m)
						{
							num++;
							string arg = ((text2 == "Count") ? Labels.Count : Labels.Amount);
							text = text + string.Format(Messages.msgSalesTargetFieldMustBePositive, arg, item.Text) + "<br>";
							break;
						}
					}
				}
				if (model.TargetDistributionDetails != null && Enumerable.Any<SalesTargetDistributionItemViewModel>((IEnumerable<SalesTargetDistributionItemViewModel>)model.TargetDistributionDetails.Items))
				{
					decimal num3 = default(decimal);
					num3 = ((!(text2 == "Count")) ? model.TargetOrderAmount.GetValueOrDefault() : ((decimal)model.TargetOrderCount.GetValueOrDefault()));
					if (num3 > 0m)
					{
						decimal num4 = default(decimal);
						foreach (SalesTargetDistributionItemViewModel item2 in model.TargetDistributionDetails.Items)
						{
							decimal? num5 = ((!(text2 == "Count")) ? item2.OrderAmount : ((decimal?)item2.OrderCount));
							if (num5.HasValue)
							{
								num4 += num5.Value;
							}
						}
						if (Math.Abs(num4 - num3) > 0.01m)
						{
							num++;
							string arg2 = ((text2 == "Count") ? Labels.Count : Labels.Amount);
							text = text + string.Format(Messages.msgSalesTargetTotalMismatch, arg2, num4.ToString("N0"), num3.ToString("N0")) + "<br>";
						}
					}
				}
				if (model.TargetUserScope != null && model.TargetUserScope.Key == 3 && model.TargetDistributionDetails != null && model.TargetDistributionDetails.Key == "1")
				{
					List<string> list2 = Enumerable.ToList<string>((IEnumerable<string>)Enumerable.OrderBy<string, string>(Enumerable.Select<SalesTargetDistributionItemViewModel, string>((IEnumerable<SalesTargetDistributionItemViewModel>)model.TargetDistributionDetails.Items, (Func<SalesTargetDistributionItemViewModel, string>)((SalesTargetDistributionItemViewModel i) => i.Val)), (Func<string, string>)((string id) => id)));
					List<string> list3 = Enumerable.ToList<string>((IEnumerable<string>)Enumerable.OrderBy<string, string>(Enumerable.Select<SalesTargetUserScopeSelectedItem, string>((IEnumerable<SalesTargetUserScopeSelectedItem>)model.TargetUserScope.SelectedUsers, (Func<SalesTargetUserScopeSelectedItem, string>)((SalesTargetUserScopeSelectedItem u) => u.Val)), (Func<string, string>)((string id) => id)));
					if (!Enumerable.SequenceEqual<string>((IEnumerable<string>)list2, (IEnumerable<string>)list3))
					{
						num++;
						text = text + Messages.msgSalesTargetUserScopeDistributionMismatch + "<br>";
					}
				}
				if (model.TargetDistributionDetailsJson != null && model.TargetDistributionDetails.Key != "1" && model.TargetDistributionDetails.Items != null && Enumerable.Any<SalesTargetDistributionItemViewModel>((IEnumerable<SalesTargetDistributionItemViewModel>)model.TargetDistributionDetails.Items, (Func<SalesTargetDistributionItemViewModel, bool>)((SalesTargetDistributionItemViewModel i) => i.TargetNotif.HasValue)))
				{
					foreach (SalesTargetDistributionItemViewModel item3 in Enumerable.Where<SalesTargetDistributionItemViewModel>((IEnumerable<SalesTargetDistributionItemViewModel>)model.TargetDistributionDetails.Items, (Func<SalesTargetDistributionItemViewModel, bool>)((SalesTargetDistributionItemViewModel i) => i.TargetNotif.HasValue)))
					{
						item3.TargetNotif = null;
					}
					model.TargetDistributionDetailsJson = JsonConvert.SerializeObject(model.TargetDistributionDetails);
				}
				if (model.SalesTargetId > 0 && Enumerable.FirstOrDefault<WSspSelectSalesTarget_Result>((IEnumerable<WSspSelectSalesTarget_Result>)_dbIII.WSspSelectSalesTarget(model.SalesTargetId, lCID, result)) == null)
				{
					num++;
					text = text + Messages.msgSalesTargetNotFound + "<br>";
				}
				if (num == 0)
				{
					string targetFromDatePersian = model.TargetFromDateTime.ToString("yyyyMMdd", new PersianCulture());
					string targetToDatePersian = model.TargetToDateTime.ToString("yyyyMMdd", new PersianCulture());
					string targetDistributionDetailsJson = null;
					string targetTermsJson = null;
					string targetScopeJson = null;
					if (!string.IsNullOrEmpty(model.TargetDistributionDetailsJson))
					{
						JObject jObject = JObject.Parse(model.TargetDistributionDetailsJson);
						RemoveTextFieldsRecursive(jObject);
						targetDistributionDetailsJson = jObject.ToString(Formatting.None);
					}
					if (!string.IsNullOrEmpty(model.TargetTermsJson))
					{
						JArray jArray = JArray.Parse(model.TargetTermsJson);
						foreach (JToken item4 in jArray)
						{
							RemoveTextFieldsRecursive(item4);
						}
						targetTermsJson = jArray.ToString(Formatting.None);
						targetTermsJson = ConvertTermsJson(targetTermsJson);
					}
					if (!string.IsNullOrEmpty(model.TargetUserScopeJson))
					{
						JObject jObject2 = JObject.Parse(model.TargetUserScopeJson);
						RemoveTextFieldsRecursive(jObject2);
						targetScopeJson = jObject2.ToString(Formatting.None);
						targetScopeJson = ConvertUserScopeJson(targetScopeJson);
					}
					ObjectParameter errorMessage = new ObjectParameter("ErrorMessage", "");
					if (model.SalesTargetId == 0)
					{
						ObjectParameter insertedId = new ObjectParameter("InsertedId", 0);
						_dbIII.WSspInsertSalesTarget(new JavaScriptSerializer().Serialize((object)list), model.TargetOrderCount, model.TargetOrderAmount, model.TargetFromDateTime, model.TargetToDateTime, targetFromDatePersian, targetToDatePersian, targetDistributionDetailsJson, targetTermsJson, targetScopeJson, UserLogin.CurrentUser.UserId, id2, value2, value, registerDatePersian, appType, lCID, result, insertedId, errorMessage);
						base.ViewBag.Successfull = Messages.msgSuccessAction;
					}
					else
					{
						_dbIII.WSspUpdateSalesTarget(model.SalesTargetId, new JavaScriptSerializer().Serialize((object)list), model.TargetOrderCount, model.TargetOrderAmount, model.TargetFromDateTime, model.TargetToDateTime, targetFromDatePersian, targetToDatePersian, targetDistributionDetailsJson, targetTermsJson, targetScopeJson, UserLogin.CurrentUser.UserId, id2, value2, value, registerDatePersian, appType, lCID, result, errorMessage);
					}
					base.ViewBag.Successfull = Messages.msgSuccessAction;
				}
			}
			if (text != "")
			{
				base.ViewBag.Error = text;
				List<CRMspSelectUserDepartments_Result> list4 = Enumerable.ToList<CRMspSelectUserDepartments_Result>((IEnumerable<CRMspSelectUserDepartments_Result>)_db.CRMspSelectUserDepartments(lCID, result, result2));
				ObjectResult<CRMspSelectActiveUsers_Result> objectResult = _db.CRMspSelectActiveUsers(lCID, result, result2);
				List<SelectListItem> list5 = new List<SelectListItem>();
				list5.AddRange(Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectUserDepartments_Result, SelectListItem>((IEnumerable<CRMspSelectUserDepartments_Result>)list4, (Func<CRMspSelectUserDepartments_Result, SelectListItem>)((CRMspSelectUserDepartments_Result item) => new SelectListItem
				{
					Text = item.Department,
					Value = item.DepartmentID.ToString(),
					Selected = false
				}))));
				base.ViewBag.Departments = list5;
				List<SelectListItem> list6 = new List<SelectListItem>();
				list6.AddRange(Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)objectResult, (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result item) => new SelectListItem
				{
					Text = item.LName + " " + item.FName,
					Value = item.UserId.ToString(),
					Selected = false
				}))));
				base.ViewBag.Users = list6;
				_ = model.TargetFromDateTime;
				model.TargetFromDate = ((model.TargetFromDateTime != default(DateTime)) ? model.TargetFromDateTime.ToString("yyyy/MM/dd HH:mm:ss") : "");
				_ = model.TargetToDateTime;
				model.TargetToDate = ((model.TargetToDateTime != default(DateTime)) ? model.TargetToDateTime.ToString("yyyy/MM/dd HH:mm:ss") : "");
				return View(model);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			base.ViewBag.Error = Messages.msgErrorRunFunction;
			List<CRMspSelectUserDepartments_Result> list7 = Enumerable.ToList<CRMspSelectUserDepartments_Result>((IEnumerable<CRMspSelectUserDepartments_Result>)_db.CRMspSelectUserDepartments(lCID, result, result2));
			ObjectResult<CRMspSelectActiveUsers_Result> objectResult2 = _db.CRMspSelectActiveUsers(lCID, result, result2);
			List<SelectListItem> list8 = new List<SelectListItem>();
			list8.AddRange(Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectUserDepartments_Result, SelectListItem>((IEnumerable<CRMspSelectUserDepartments_Result>)list7, (Func<CRMspSelectUserDepartments_Result, SelectListItem>)((CRMspSelectUserDepartments_Result item) => new SelectListItem
			{
				Text = item.Department,
				Value = item.DepartmentID.ToString(),
				Selected = false
			}))));
			base.ViewBag.Departments = list8;
			List<SelectListItem> list9 = new List<SelectListItem>();
			list9.AddRange(Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)objectResult2, (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result item) => new SelectListItem
			{
				Text = item.LName + " " + item.FName,
				Value = item.UserId.ToString(),
				Selected = false
			}))));
			base.ViewBag.Users = list9;
			_ = model.TargetFromDateTime;
			model.TargetFromDate = model.TargetFromDateTime.ToString("yyyy/MM/dd HH:mm:ss");
			_ = model.TargetToDateTime;
			model.TargetToDate = model.TargetToDateTime.ToString("yyyy/MM/dd HH:mm:ss");
			return View(model);
		}
		return View(model);
	}

	public ActionResult DistributionSelectItems()
	{
		return View();
	}

	public ActionResult ConditionSelectItems()
	{
		return View();
	}

	[HttpPost]
	public ActionResult SendTargetNotif(int salesTargetId)
	{
		try
		{
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int.TryParse(SysSeting.Get().DefaultLanguageID?.ToString() ?? "1065", out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (Enumerable.FirstOrDefault<WSspSelectSalesTarget_Result>((IEnumerable<WSspSelectSalesTarget_Result>)_dbIII.WSspSelectSalesTarget(salesTargetId, lCID, result)) == null)
			{
				return Json(new
				{
					DistinctMessagesCount = 0,
					TotalMessagesCount = 0,
					Message = Messages.msgSalesTargetNotFound
				}, JsonRequestBehavior.AllowGet);
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			short value3 = short.Parse(Financial.Get().Id.ToString());
			string appType = Configuration.AppType;
			Dictionary<int, string> value4 = new Dictionary<int, string>
			{
				{
					1065,
					now.ToString("yyyy/MM/dd", new CultureInfo("fa-IR"))
				},
				{
					1025,
					now.ToString("yyyy/MM/dd", new CultureInfo("ar-SA"))
				},
				{
					1033,
					now.ToString("yyyy/MM/dd", new CultureInfo("en-US"))
				},
				{
					1055,
					now.ToString("yyyy/MM/dd", new CultureInfo("tr-TR"))
				},
				{
					1031,
					now.ToString("yyyy/MM/dd", new CultureInfo("de-DE"))
				}
			};
			Dictionary<int, string> value5 = new Dictionary<int, string>
			{
				{ 1065, "کاربر گرامی، هدف گذاری {0} در تاریخ {1} تحقق یافت." },
				{ 1033, "Dear user, sales target {0} achieved on {1}." },
				{ 1055, "Sevgili kullanıcı, {0} hedefi {1} tarihinde gerçekleşti." },
				{ 1031, "Lieber Benutzer, Vertriebsziel {0} wurde am {1} erreicht." },
				{ 1025, "عزيزي المستخدم، تم تحقيق الهدف {0} في التاريخ {1}." }
			};
			Dictionary<int, string> value6 = new Dictionary<int, string>
			{
				{ 1065, "کاربر گرامی، هدف گذاری {0} در تاریخ {1} در خصوص کاربر {2} تحقق یافت." },
				{ 1033, "Dear user, sales target {0} achieved on {1} for user {2}." },
				{ 1055, "Sevgili kullanıcı, {0} hedefi {1} tarihinde {2} kullanıcısı için gerçekleşti." },
				{ 1031, "Lieber Benutzer, Vertriebsziel {0} wurde am {1} für Benutzer {2} erreicht." },
				{ 1025, "عزيزي المستخدم، تم تحقيق الهدف {0} في التاريخ {1} للمستخدم {2}." }
			};
			string messageSubjectJson = JsonConvert.SerializeObject(new Dictionary<int, string>
			{
				{ 1065, "اطلاع رسانی دستیابی به هدف" },
				{ 1033, "Target Achievement Notification" },
				{ 1055, "Hedef Başarısı Bildirimi" },
				{ 1031, "Benachrichtigung zur Zielerreichung" },
				{ 1025, "إشعار تحقيق الهدف" }
			});
			string text = JsonConvert.SerializeObject(value6);
			string templateUserMessageJson = JsonConvert.SerializeObject(value5);
			string achievementDateJson = JsonConvert.SerializeObject(value4);
			CRMSpIIIEntities dbIII = _dbIII;
			int? userId = UserLogin.CurrentUser.UserId;
			int? salesTargetId2 = salesTargetId;
			int? languageID = lCID;
			int? defaultLanguageID = result;
			int? centerId = result2;
			string templateResponsibleUserMessageJson = text;
			WSspSendUserSalesTargetNotif_Result wSspSendUserSalesTargetNotif_Result = Enumerable.FirstOrDefault<WSspSendUserSalesTargetNotif_Result>((IEnumerable<WSspSendUserSalesTargetNotif_Result>)dbIII.WSspSendUserSalesTargetNotif(userId, null, salesTargetId2, null, languageID, defaultLanguageID, centerId, templateUserMessageJson, templateResponsibleUserMessageJson, messageSubjectJson, achievementDateJson, value, registerDatePersian, value3, value2, appType));
			return Json(new
			{
				DistinctMessagesCount = wSspSendUserSalesTargetNotif_Result.DistinctMessagesCount,
				TotalMessagesCount = wSspSendUserSalesTargetNotif_Result.TotalMessagesCount,
				Message = ""
			}, JsonRequestBehavior.AllowGet);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Json(new
			{
				DistinctMessagesCount = 0,
				TotalMessagesCount = 0
			}, JsonRequestBehavior.AllowGet);
		}
	}

	[HttpPost]
	public ActionResult GetDistributionScopeRecords(int distributionCriterionId = 1, int userId = 0, int pageNumber = 1, int pageSize = 30, string searchKeyword = "", int? userScope = 1, int? departmentId = null, List<int>? userIds = null, int? provinceId = 0, int? countryId = 0, int? companyGroupId = 0, int? productFirstGroupId = 0, int? productSecondGroupId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int totalCount = 0;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			_ = Labels.None;
			_ = Labels.HaveNot;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (userId == 0)
			{
				userId = UserLogin.CurrentUser.UserId;
			}
			if (distributionCriterionId == 1)
			{
				if (userScope.GetValueOrDefault() == 1 || userScope.GetValueOrDefault() == 2)
				{
					if (userScope.GetValueOrDefault() == 2 && departmentId == 0)
					{
						departmentId = -1;
					}
					else if (userScope.GetValueOrDefault() == 1)
					{
						departmentId = 0;
					}
					CRMSpIIIEntities dbIII = _dbIII;
					int? userId2 = userId;
					int? pageNumber2 = pageNumber;
					int? pageSize2 = pageSize;
					int? centerId = result2;
					string searchTerm = searchKeyword;
					bool? isActive = true;
					List<CRMspSelectUsersWithPaging_Result> list2 = Enumerable.ToList<CRMspSelectUsersWithPaging_Result>((IEnumerable<CRMspSelectUsersWithPaging_Result>)dbIII.CRMspSelectUsersWithPaging(userId2, pageNumber2, pageSize2, centerId, departmentId, isActive, searchTerm, lCID, result, 16, ""));
					list.AddRange(Enumerable.Select<CRMspSelectUsersWithPaging_Result, SelectListItem>((IEnumerable<CRMspSelectUsersWithPaging_Result>)list2, (Func<CRMspSelectUsersWithPaging_Result, SelectListItem>)((CRMspSelectUsersWithPaging_Result item) => new SelectListItem
					{
						Text = item.LName + " " + item.FName,
						Value = item.UserId.ToString(),
						Selected = false
					})));
					totalCount = (Enumerable.Any<CRMspSelectUsersWithPaging_Result>((IEnumerable<CRMspSelectUsersWithPaging_Result>)list2) ? Enumerable.FirstOrDefault<CRMspSelectUsersWithPaging_Result>((IEnumerable<CRMspSelectUsersWithPaging_Result>)list2).TotalCount.GetValueOrDefault() : 0);
				}
				else if (userScope.GetValueOrDefault() == 3)
				{
					List<int> list3 = userIds ?? new List<int>();
					string userIdList = (Enumerable.Any<int>((IEnumerable<int>)list3) ? string.Join(",", list3) : "");
					CRMSpIIIEntities dbIII2 = _dbIII;
					int? userId3 = userId;
					int? pageNumber3 = pageNumber;
					int? pageSize3 = pageSize;
					int? centerId2 = result2;
					string searchTerm = searchKeyword;
					bool? isActive = true;
					List<CRMspSelectUsersByIdsWithPaging_Result> list4 = Enumerable.ToList<CRMspSelectUsersByIdsWithPaging_Result>((IEnumerable<CRMspSelectUsersByIdsWithPaging_Result>)dbIII2.CRMspSelectUsersByIdsWithPaging(userId3, userIdList, pageNumber3, pageSize3, centerId2, isActive, searchTerm, lCID, result));
					list.AddRange(Enumerable.Select<CRMspSelectUsersByIdsWithPaging_Result, SelectListItem>((IEnumerable<CRMspSelectUsersByIdsWithPaging_Result>)list4, (Func<CRMspSelectUsersByIdsWithPaging_Result, SelectListItem>)((CRMspSelectUsersByIdsWithPaging_Result item) => new SelectListItem
					{
						Text = item.LName + " " + item.FName,
						Value = item.UserId.ToString(),
						Selected = false
					})));
					totalCount = (Enumerable.Any<CRMspSelectUsersByIdsWithPaging_Result>((IEnumerable<CRMspSelectUsersByIdsWithPaging_Result>)list4) ? Enumerable.FirstOrDefault<CRMspSelectUsersByIdsWithPaging_Result>((IEnumerable<CRMspSelectUsersByIdsWithPaging_Result>)list4).TotalCount.GetValueOrDefault() : 0);
				}
			}
			switch (distributionCriterionId)
			{
			case 2:
			{
				CRMSpIIIEntities dbIII3 = _dbIII;
				int? pageNumber5 = pageNumber;
				int? pageSize5 = pageSize;
				int? centerId2 = userId;
				int? languageID = lCID;
				int? defaultLanguageID = result;
				int? userId5 = centerId2;
				int? centerId3 = result2;
				string searchTerm = searchKeyword;
				List<CRMspSelectCityWithPaging_Result> list10 = Enumerable.ToList<CRMspSelectCityWithPaging_Result>((IEnumerable<CRMspSelectCityWithPaging_Result>)dbIII3.CRMspSelectCityWithPaging(pageNumber5, pageSize5, languageID, defaultLanguageID, userId5, centerId3, provinceId, searchTerm));
				list.AddRange(Enumerable.Select<CRMspSelectCityWithPaging_Result, SelectListItem>((IEnumerable<CRMspSelectCityWithPaging_Result>)list10, (Func<CRMspSelectCityWithPaging_Result, SelectListItem>)((CRMspSelectCityWithPaging_Result item) => new SelectListItem
				{
					Text = item.CityName,
					Value = item.CityID.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<CRMspSelectCityWithPaging_Result>((IEnumerable<CRMspSelectCityWithPaging_Result>)list10) ? Enumerable.FirstOrDefault<CRMspSelectCityWithPaging_Result>((IEnumerable<CRMspSelectCityWithPaging_Result>)list10).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 3:
			{
				List<CRMspSelectProvinceWithPaging_Result> list7 = Enumerable.ToList<CRMspSelectProvinceWithPaging_Result>((IEnumerable<CRMspSelectProvinceWithPaging_Result>)_dbIII.CRMspSelectProvinceWithPaging(pageNumber, pageSize, userId: userId, languageID: lCID, defaultLanguageID: result, centerId: result2, searchTerm: searchKeyword, countryId: countryId));
				list.AddRange(Enumerable.Select<CRMspSelectProvinceWithPaging_Result, SelectListItem>((IEnumerable<CRMspSelectProvinceWithPaging_Result>)list7, (Func<CRMspSelectProvinceWithPaging_Result, SelectListItem>)((CRMspSelectProvinceWithPaging_Result item) => new SelectListItem
				{
					Text = item.ProvinceName,
					Value = item.ProvinceID.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<CRMspSelectProvinceWithPaging_Result>((IEnumerable<CRMspSelectProvinceWithPaging_Result>)list7) ? Enumerable.FirstOrDefault<CRMspSelectProvinceWithPaging_Result>((IEnumerable<CRMspSelectProvinceWithPaging_Result>)list7).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 4:
			{
				List<CRMspSelectCompanyGroupsWithPaging_Result> list21 = Enumerable.ToList<CRMspSelectCompanyGroupsWithPaging_Result>((IEnumerable<CRMspSelectCompanyGroupsWithPaging_Result>)_dbIII.CRMspSelectCompanyGroupsWithPaging(pageNumber, pageSize, userId: userId, languageID: lCID, defaultLanguageID: result, centerId: result2, searchTerm: searchKeyword));
				list.AddRange(Enumerable.Select<CRMspSelectCompanyGroupsWithPaging_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsWithPaging_Result>)list21, (Func<CRMspSelectCompanyGroupsWithPaging_Result, SelectListItem>)((CRMspSelectCompanyGroupsWithPaging_Result item) => new SelectListItem
				{
					Text = item.GroupName,
					Value = item.CompanyGroupID.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<CRMspSelectCompanyGroupsWithPaging_Result>((IEnumerable<CRMspSelectCompanyGroupsWithPaging_Result>)list21) ? Enumerable.FirstOrDefault<CRMspSelectCompanyGroupsWithPaging_Result>((IEnumerable<CRMspSelectCompanyGroupsWithPaging_Result>)list21).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 5:
			{
				List<CRMspSelectCompanyGroupsIIWithPaging_Result> list12 = Enumerable.ToList<CRMspSelectCompanyGroupsIIWithPaging_Result>((IEnumerable<CRMspSelectCompanyGroupsIIWithPaging_Result>)_dbIII.CRMspSelectCompanyGroupsIIWithPaging(pageNumber, pageSize, lCID, result, searchKeyword));
				list.AddRange(Enumerable.Select<CRMspSelectCompanyGroupsIIWithPaging_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsIIWithPaging_Result>)list12, (Func<CRMspSelectCompanyGroupsIIWithPaging_Result, SelectListItem>)((CRMspSelectCompanyGroupsIIWithPaging_Result item) => new SelectListItem
				{
					Text = item.GroupIIName,
					Value = item.CompanyGroupIIID.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<CRMspSelectCompanyGroupsIIWithPaging_Result>((IEnumerable<CRMspSelectCompanyGroupsIIWithPaging_Result>)list12) ? Enumerable.FirstOrDefault<CRMspSelectCompanyGroupsIIWithPaging_Result>((IEnumerable<CRMspSelectCompanyGroupsIIWithPaging_Result>)list12).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 6:
			{
				List<CRMspSelectCompanyGroupsIIIWithPaging_Result> list9 = Enumerable.ToList<CRMspSelectCompanyGroupsIIIWithPaging_Result>((IEnumerable<CRMspSelectCompanyGroupsIIIWithPaging_Result>)_dbIII.CRMspSelectCompanyGroupsIIIWithPaging(pageNumber, pageSize, lCID, result, searchKeyword));
				list.AddRange(Enumerable.Select<CRMspSelectCompanyGroupsIIIWithPaging_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsIIIWithPaging_Result>)list9, (Func<CRMspSelectCompanyGroupsIIIWithPaging_Result, SelectListItem>)((CRMspSelectCompanyGroupsIIIWithPaging_Result item) => new SelectListItem
				{
					Text = item.GroupIIIName,
					Value = item.CompanyGroupIIIID.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<CRMspSelectCompanyGroupsIIIWithPaging_Result>((IEnumerable<CRMspSelectCompanyGroupsIIIWithPaging_Result>)list9) ? Enumerable.FirstOrDefault<CRMspSelectCompanyGroupsIIIWithPaging_Result>((IEnumerable<CRMspSelectCompanyGroupsIIIWithPaging_Result>)list9).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 7:
			{
				List<CRMspSelectCompanyGroupsIVWithPaging_Result> list18 = Enumerable.ToList<CRMspSelectCompanyGroupsIVWithPaging_Result>((IEnumerable<CRMspSelectCompanyGroupsIVWithPaging_Result>)_dbIII.CRMspSelectCompanyGroupsIVWithPaging(pageNumber, pageSize, lCID, result, userId, result2, searchKeyword));
				list.AddRange(Enumerable.Select<CRMspSelectCompanyGroupsIVWithPaging_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsIVWithPaging_Result>)list18, (Func<CRMspSelectCompanyGroupsIVWithPaging_Result, SelectListItem>)((CRMspSelectCompanyGroupsIVWithPaging_Result item) => new SelectListItem
				{
					Text = item.GroupIVName,
					Value = item.CompanyGroupIVID.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<CRMspSelectCompanyGroupsIVWithPaging_Result>((IEnumerable<CRMspSelectCompanyGroupsIVWithPaging_Result>)list18) ? Enumerable.FirstOrDefault<CRMspSelectCompanyGroupsIVWithPaging_Result>((IEnumerable<CRMspSelectCompanyGroupsIVWithPaging_Result>)list18).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 8:
			{
				List<CRMspSelectCompanySubGroupsWithPaging_Result> list19 = Enumerable.ToList<CRMspSelectCompanySubGroupsWithPaging_Result>((IEnumerable<CRMspSelectCompanySubGroupsWithPaging_Result>)_dbIII.CRMspSelectCompanySubGroupsWithPaging(pageNumber, pageSize, lCID, result, userId, result2, searchKeyword, companyGroupId));
				list.AddRange(Enumerable.Select<CRMspSelectCompanySubGroupsWithPaging_Result, SelectListItem>((IEnumerable<CRMspSelectCompanySubGroupsWithPaging_Result>)list19, (Func<CRMspSelectCompanySubGroupsWithPaging_Result, SelectListItem>)((CRMspSelectCompanySubGroupsWithPaging_Result item) => new SelectListItem
				{
					Text = item.SubGroupName,
					Value = item.CompanySubGroupID.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<CRMspSelectCompanySubGroupsWithPaging_Result>((IEnumerable<CRMspSelectCompanySubGroupsWithPaging_Result>)list19) ? Enumerable.FirstOrDefault<CRMspSelectCompanySubGroupsWithPaging_Result>((IEnumerable<CRMspSelectCompanySubGroupsWithPaging_Result>)list19).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 9:
			{
				List<CRMspSelectCompanyTypesWithPaging_Result> list14 = Enumerable.ToList<CRMspSelectCompanyTypesWithPaging_Result>((IEnumerable<CRMspSelectCompanyTypesWithPaging_Result>)_dbIII.CRMspSelectCompanyTypesWithPaging(pageNumber, pageSize, lCID, result, searchKeyword));
				list.AddRange(Enumerable.Select<CRMspSelectCompanyTypesWithPaging_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyTypesWithPaging_Result>)list14, (Func<CRMspSelectCompanyTypesWithPaging_Result, SelectListItem>)((CRMspSelectCompanyTypesWithPaging_Result item) => new SelectListItem
				{
					Text = item.CompanyTypeName,
					Value = item.CompanyTypeID.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<CRMspSelectCompanyTypesWithPaging_Result>((IEnumerable<CRMspSelectCompanyTypesWithPaging_Result>)list14) ? Enumerable.FirstOrDefault<CRMspSelectCompanyTypesWithPaging_Result>((IEnumerable<CRMspSelectCompanyTypesWithPaging_Result>)list14).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 10:
			{
				List<CRMspSelectCompanyPresentationsWithPaging_Result> list15 = Enumerable.ToList<CRMspSelectCompanyPresentationsWithPaging_Result>((IEnumerable<CRMspSelectCompanyPresentationsWithPaging_Result>)_dbIII.CRMspSelectCompanyPresentationsWithPaging(pageNumber, pageSize, lCID, result, searchKeyword));
				list.AddRange(Enumerable.Select<CRMspSelectCompanyPresentationsWithPaging_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyPresentationsWithPaging_Result>)list15, (Func<CRMspSelectCompanyPresentationsWithPaging_Result, SelectListItem>)((CRMspSelectCompanyPresentationsWithPaging_Result item) => new SelectListItem
				{
					Text = item.Presentation,
					Value = item.CompanyPresentationID.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<CRMspSelectCompanyPresentationsWithPaging_Result>((IEnumerable<CRMspSelectCompanyPresentationsWithPaging_Result>)list15) ? Enumerable.FirstOrDefault<CRMspSelectCompanyPresentationsWithPaging_Result>((IEnumerable<CRMspSelectCompanyPresentationsWithPaging_Result>)list15).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 11:
			{
				List<WSspSelectProductFirstGroupWithPaging_Result> list8 = Enumerable.ToList<WSspSelectProductFirstGroupWithPaging_Result>((IEnumerable<WSspSelectProductFirstGroupWithPaging_Result>)_dbIII.WSspSelectProductFirstGroupWithPaging(pageNumber, pageSize, lCID, result, searchKeyword));
				list.AddRange(Enumerable.Select<WSspSelectProductFirstGroupWithPaging_Result, SelectListItem>((IEnumerable<WSspSelectProductFirstGroupWithPaging_Result>)list8, (Func<WSspSelectProductFirstGroupWithPaging_Result, SelectListItem>)((WSspSelectProductFirstGroupWithPaging_Result item) => new SelectListItem
				{
					Text = item.FGName,
					Value = item.PrdFirstGroupID.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<WSspSelectProductFirstGroupWithPaging_Result>((IEnumerable<WSspSelectProductFirstGroupWithPaging_Result>)list8) ? Enumerable.FirstOrDefault<WSspSelectProductFirstGroupWithPaging_Result>((IEnumerable<WSspSelectProductFirstGroupWithPaging_Result>)list8).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 12:
			{
				List<WSspSelectProductSecondGroupWithPaging_Result> list13 = Enumerable.ToList<WSspSelectProductSecondGroupWithPaging_Result>((IEnumerable<WSspSelectProductSecondGroupWithPaging_Result>)_dbIII.WSspSelectProductSecondGroupWithPaging(pageNumber, pageSize, lCID, result, searchKeyword, productFirstGroupId));
				list.AddRange(Enumerable.Select<WSspSelectProductSecondGroupWithPaging_Result, SelectListItem>((IEnumerable<WSspSelectProductSecondGroupWithPaging_Result>)list13, (Func<WSspSelectProductSecondGroupWithPaging_Result, SelectListItem>)((WSspSelectProductSecondGroupWithPaging_Result item) => new SelectListItem
				{
					Text = item.SGName,
					Value = item.PrdSecondGroupID.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<WSspSelectProductSecondGroupWithPaging_Result>((IEnumerable<WSspSelectProductSecondGroupWithPaging_Result>)list13) ? Enumerable.FirstOrDefault<WSspSelectProductSecondGroupWithPaging_Result>((IEnumerable<WSspSelectProductSecondGroupWithPaging_Result>)list13).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 13:
			{
				List<WSspSelectProductWithPaging_Result> list20 = Enumerable.ToList<WSspSelectProductWithPaging_Result>((IEnumerable<WSspSelectProductWithPaging_Result>)_dbIII.WSspSelectProductWithPaging(pageNumber, pageSize, lCID, result, searchKeyword, productFirstGroupId, productSecondGroupId));
				list.AddRange(Enumerable.Select<WSspSelectProductWithPaging_Result, SelectListItem>((IEnumerable<WSspSelectProductWithPaging_Result>)list20, (Func<WSspSelectProductWithPaging_Result, SelectListItem>)((WSspSelectProductWithPaging_Result item) => new SelectListItem
				{
					Text = item.PrdName,
					Value = item.ProductID.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<WSspSelectProductWithPaging_Result>((IEnumerable<WSspSelectProductWithPaging_Result>)list20) ? Enumerable.FirstOrDefault<WSspSelectProductWithPaging_Result>((IEnumerable<WSspSelectProductWithPaging_Result>)list20).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 14:
			{
				List<WSspSelectOrderOprWithPaging_Result> list16 = Enumerable.ToList<WSspSelectOrderOprWithPaging_Result>((IEnumerable<WSspSelectOrderOprWithPaging_Result>)_dbIII.WSspSelectOrderOprWithPaging(pageNumber, pageSize, lCID, result, userId, result2, searchKeyword));
				list.AddRange(Enumerable.Select<WSspSelectOrderOprWithPaging_Result, SelectListItem>((IEnumerable<WSspSelectOrderOprWithPaging_Result>)list16, (Func<WSspSelectOrderOprWithPaging_Result, SelectListItem>)((WSspSelectOrderOprWithPaging_Result item) => new SelectListItem
				{
					Text = item.Name,
					Value = item.OrderOprID.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<WSspSelectOrderOprWithPaging_Result>((IEnumerable<WSspSelectOrderOprWithPaging_Result>)list16) ? Enumerable.FirstOrDefault<WSspSelectOrderOprWithPaging_Result>((IEnumerable<WSspSelectOrderOprWithPaging_Result>)list16).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 15:
			{
				List<WSspSelectOrderGroupWithPaging_Result> list6 = Enumerable.ToList<WSspSelectOrderGroupWithPaging_Result>((IEnumerable<WSspSelectOrderGroupWithPaging_Result>)_dbIII.WSspSelectOrderGroupWithPaging(pageNumber, pageSize, lCID, result, userId, result2, searchKeyword));
				list.AddRange(Enumerable.Select<WSspSelectOrderGroupWithPaging_Result, SelectListItem>((IEnumerable<WSspSelectOrderGroupWithPaging_Result>)list6, (Func<WSspSelectOrderGroupWithPaging_Result, SelectListItem>)((WSspSelectOrderGroupWithPaging_Result item) => new SelectListItem
				{
					Text = item.OrderGroupName,
					Value = item.OrderGroupId.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<WSspSelectOrderGroupWithPaging_Result>((IEnumerable<WSspSelectOrderGroupWithPaging_Result>)list6) ? Enumerable.FirstOrDefault<WSspSelectOrderGroupWithPaging_Result>((IEnumerable<WSspSelectOrderGroupWithPaging_Result>)list6).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 16:
			{
				List<WSspSelectOrderStatusWithPaging_Result> list17 = Enumerable.ToList<WSspSelectOrderStatusWithPaging_Result>((IEnumerable<WSspSelectOrderStatusWithPaging_Result>)_dbIII.WSspSelectOrderStatusWithPaging(pageNumber, pageSize, lCID, result, userId, searchKeyword));
				list.AddRange(Enumerable.Select<WSspSelectOrderStatusWithPaging_Result, SelectListItem>((IEnumerable<WSspSelectOrderStatusWithPaging_Result>)list17, (Func<WSspSelectOrderStatusWithPaging_Result, SelectListItem>)((WSspSelectOrderStatusWithPaging_Result item) => new SelectListItem
				{
					Text = item.OrderStatus,
					Value = item.OrderStatusId.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<WSspSelectOrderStatusWithPaging_Result>((IEnumerable<WSspSelectOrderStatusWithPaging_Result>)list17) ? Enumerable.FirstOrDefault<WSspSelectOrderStatusWithPaging_Result>((IEnumerable<WSspSelectOrderStatusWithPaging_Result>)list17).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 17:
			{
				List<WSspSelectDeliveryTermWithPaging_Result> list11 = Enumerable.ToList<WSspSelectDeliveryTermWithPaging_Result>((IEnumerable<WSspSelectDeliveryTermWithPaging_Result>)_dbIII.WSspSelectDeliveryTermWithPaging(pageNumber, pageSize, lCID, result, userId, result2, searchKeyword));
				list.AddRange(Enumerable.Select<WSspSelectDeliveryTermWithPaging_Result, SelectListItem>((IEnumerable<WSspSelectDeliveryTermWithPaging_Result>)list11, (Func<WSspSelectDeliveryTermWithPaging_Result, SelectListItem>)((WSspSelectDeliveryTermWithPaging_Result item) => new SelectListItem
				{
					Text = item.DeliveryTerm,
					Value = item.DeliveryTermId.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<WSspSelectDeliveryTermWithPaging_Result>((IEnumerable<WSspSelectDeliveryTermWithPaging_Result>)list11) ? Enumerable.FirstOrDefault<WSspSelectDeliveryTermWithPaging_Result>((IEnumerable<WSspSelectDeliveryTermWithPaging_Result>)list11).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 18:
			{
				List<WSspSelectSettlementTypeWithPaging_Result> list5 = Enumerable.ToList<WSspSelectSettlementTypeWithPaging_Result>((IEnumerable<WSspSelectSettlementTypeWithPaging_Result>)_dbIII.WSspSelectSettlementTypeWithPaging(pageNumber, pageSize, lCID, result, userId, result2, searchKeyword));
				list.AddRange(Enumerable.Select<WSspSelectSettlementTypeWithPaging_Result, SelectListItem>((IEnumerable<WSspSelectSettlementTypeWithPaging_Result>)list5, (Func<WSspSelectSettlementTypeWithPaging_Result, SelectListItem>)((WSspSelectSettlementTypeWithPaging_Result item) => new SelectListItem
				{
					Text = item.Name,
					Value = item.Id.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<WSspSelectSettlementTypeWithPaging_Result>((IEnumerable<WSspSelectSettlementTypeWithPaging_Result>)list5) ? Enumerable.FirstOrDefault<WSspSelectSettlementTypeWithPaging_Result>((IEnumerable<WSspSelectSettlementTypeWithPaging_Result>)list5).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			}
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

	[HttpPost]
	public ActionResult GetConditionScopeRecords(int conditionCriterionId = 1, int userId = 0, int pageNumber = 1, int pageSize = 30, int? provinceId = 0, int? countryId = 0, int? companyGroupId = 0, string searchKeyword = "", int? productFirstGroupId = 0, int? productSecondGroupId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		int totalCount = 0;
		try
		{
			_ = Labels.None;
			_ = Labels.HaveNot;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (userId == 0)
			{
				userId = UserLogin.CurrentUser.UserId;
			}
			switch (conditionCriterionId)
			{
			case 2:
			{
				CRMSpIIIEntities dbIII = _dbIII;
				int? pageNumber3 = pageNumber;
				int? pageSize3 = pageSize;
				int? userId3 = userId;
				List<CRMspSelectCityWithPaging_Result> list7 = Enumerable.ToList<CRMspSelectCityWithPaging_Result>((IEnumerable<CRMspSelectCityWithPaging_Result>)dbIII.CRMspSelectCityWithPaging(pageNumber3, pageSize3, lCID, result, userId3, result2, provinceId, searchKeyword));
				list.AddRange(Enumerable.Select<CRMspSelectCityWithPaging_Result, SelectListItem>((IEnumerable<CRMspSelectCityWithPaging_Result>)list7, (Func<CRMspSelectCityWithPaging_Result, SelectListItem>)((CRMspSelectCityWithPaging_Result item) => new SelectListItem
				{
					Text = item.CityName,
					Value = item.CityID.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<CRMspSelectCityWithPaging_Result>((IEnumerable<CRMspSelectCityWithPaging_Result>)list7) ? Enumerable.FirstOrDefault<CRMspSelectCityWithPaging_Result>((IEnumerable<CRMspSelectCityWithPaging_Result>)list7).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 3:
			{
				List<CRMspSelectProvinceWithPaging_Result> list4 = Enumerable.ToList<CRMspSelectProvinceWithPaging_Result>((IEnumerable<CRMspSelectProvinceWithPaging_Result>)_dbIII.CRMspSelectProvinceWithPaging(pageNumber, pageSize, userId: userId, languageID: lCID, defaultLanguageID: result, centerId: result2, searchTerm: searchKeyword, countryId: countryId));
				list.AddRange(Enumerable.Select<CRMspSelectProvinceWithPaging_Result, SelectListItem>((IEnumerable<CRMspSelectProvinceWithPaging_Result>)list4, (Func<CRMspSelectProvinceWithPaging_Result, SelectListItem>)((CRMspSelectProvinceWithPaging_Result item) => new SelectListItem
				{
					Text = item.ProvinceName,
					Value = item.ProvinceID.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<CRMspSelectProvinceWithPaging_Result>((IEnumerable<CRMspSelectProvinceWithPaging_Result>)list4) ? Enumerable.FirstOrDefault<CRMspSelectProvinceWithPaging_Result>((IEnumerable<CRMspSelectProvinceWithPaging_Result>)list4).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 4:
			{
				List<CRMspSelectCompanyGroupsWithPaging_Result> list18 = Enumerable.ToList<CRMspSelectCompanyGroupsWithPaging_Result>((IEnumerable<CRMspSelectCompanyGroupsWithPaging_Result>)_dbIII.CRMspSelectCompanyGroupsWithPaging(pageNumber, pageSize, userId: userId, languageID: lCID, defaultLanguageID: result, centerId: result2, searchTerm: searchKeyword));
				list.AddRange(Enumerable.Select<CRMspSelectCompanyGroupsWithPaging_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsWithPaging_Result>)list18, (Func<CRMspSelectCompanyGroupsWithPaging_Result, SelectListItem>)((CRMspSelectCompanyGroupsWithPaging_Result item) => new SelectListItem
				{
					Text = item.GroupName,
					Value = item.CompanyGroupID.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<CRMspSelectCompanyGroupsWithPaging_Result>((IEnumerable<CRMspSelectCompanyGroupsWithPaging_Result>)list18) ? Enumerable.FirstOrDefault<CRMspSelectCompanyGroupsWithPaging_Result>((IEnumerable<CRMspSelectCompanyGroupsWithPaging_Result>)list18).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 5:
			{
				List<CRMspSelectCompanyGroupsIIWithPaging_Result> list9 = Enumerable.ToList<CRMspSelectCompanyGroupsIIWithPaging_Result>((IEnumerable<CRMspSelectCompanyGroupsIIWithPaging_Result>)_dbIII.CRMspSelectCompanyGroupsIIWithPaging(pageNumber, pageSize, lCID, result, searchKeyword));
				list.AddRange(Enumerable.Select<CRMspSelectCompanyGroupsIIWithPaging_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsIIWithPaging_Result>)list9, (Func<CRMspSelectCompanyGroupsIIWithPaging_Result, SelectListItem>)((CRMspSelectCompanyGroupsIIWithPaging_Result item) => new SelectListItem
				{
					Text = item.GroupIIName,
					Value = item.CompanyGroupIIID.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<CRMspSelectCompanyGroupsIIWithPaging_Result>((IEnumerable<CRMspSelectCompanyGroupsIIWithPaging_Result>)list9) ? Enumerable.FirstOrDefault<CRMspSelectCompanyGroupsIIWithPaging_Result>((IEnumerable<CRMspSelectCompanyGroupsIIWithPaging_Result>)list9).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 6:
			{
				List<CRMspSelectCompanyGroupsIIIWithPaging_Result> list6 = Enumerable.ToList<CRMspSelectCompanyGroupsIIIWithPaging_Result>((IEnumerable<CRMspSelectCompanyGroupsIIIWithPaging_Result>)_dbIII.CRMspSelectCompanyGroupsIIIWithPaging(pageNumber, pageSize, lCID, result, searchKeyword));
				list.AddRange(Enumerable.Select<CRMspSelectCompanyGroupsIIIWithPaging_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsIIIWithPaging_Result>)list6, (Func<CRMspSelectCompanyGroupsIIIWithPaging_Result, SelectListItem>)((CRMspSelectCompanyGroupsIIIWithPaging_Result item) => new SelectListItem
				{
					Text = item.GroupIIIName,
					Value = item.CompanyGroupIIIID.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<CRMspSelectCompanyGroupsIIIWithPaging_Result>((IEnumerable<CRMspSelectCompanyGroupsIIIWithPaging_Result>)list6) ? Enumerable.FirstOrDefault<CRMspSelectCompanyGroupsIIIWithPaging_Result>((IEnumerable<CRMspSelectCompanyGroupsIIIWithPaging_Result>)list6).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 7:
			{
				List<CRMspSelectCompanyGroupsIVWithPaging_Result> list15 = Enumerable.ToList<CRMspSelectCompanyGroupsIVWithPaging_Result>((IEnumerable<CRMspSelectCompanyGroupsIVWithPaging_Result>)_dbIII.CRMspSelectCompanyGroupsIVWithPaging(pageNumber, pageSize, lCID, result, userId, result2, searchKeyword));
				list.AddRange(Enumerable.Select<CRMspSelectCompanyGroupsIVWithPaging_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsIVWithPaging_Result>)list15, (Func<CRMspSelectCompanyGroupsIVWithPaging_Result, SelectListItem>)((CRMspSelectCompanyGroupsIVWithPaging_Result item) => new SelectListItem
				{
					Text = item.GroupIVName,
					Value = item.CompanyGroupIVID.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<CRMspSelectCompanyGroupsIVWithPaging_Result>((IEnumerable<CRMspSelectCompanyGroupsIVWithPaging_Result>)list15) ? Enumerable.FirstOrDefault<CRMspSelectCompanyGroupsIVWithPaging_Result>((IEnumerable<CRMspSelectCompanyGroupsIVWithPaging_Result>)list15).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 8:
			{
				List<CRMspSelectCompanySubGroupsWithPaging_Result> list16 = Enumerable.ToList<CRMspSelectCompanySubGroupsWithPaging_Result>((IEnumerable<CRMspSelectCompanySubGroupsWithPaging_Result>)_dbIII.CRMspSelectCompanySubGroupsWithPaging(pageNumber, pageSize, lCID, result, userId, result2, searchKeyword, companyGroupId));
				list.AddRange(Enumerable.Select<CRMspSelectCompanySubGroupsWithPaging_Result, SelectListItem>((IEnumerable<CRMspSelectCompanySubGroupsWithPaging_Result>)list16, (Func<CRMspSelectCompanySubGroupsWithPaging_Result, SelectListItem>)((CRMspSelectCompanySubGroupsWithPaging_Result item) => new SelectListItem
				{
					Text = item.SubGroupName,
					Value = item.CompanySubGroupID.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<CRMspSelectCompanySubGroupsWithPaging_Result>((IEnumerable<CRMspSelectCompanySubGroupsWithPaging_Result>)list16) ? Enumerable.FirstOrDefault<CRMspSelectCompanySubGroupsWithPaging_Result>((IEnumerable<CRMspSelectCompanySubGroupsWithPaging_Result>)list16).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 9:
			{
				List<CRMspSelectCompanyTypesWithPaging_Result> list11 = Enumerable.ToList<CRMspSelectCompanyTypesWithPaging_Result>((IEnumerable<CRMspSelectCompanyTypesWithPaging_Result>)_dbIII.CRMspSelectCompanyTypesWithPaging(pageNumber, pageSize, lCID, result, searchKeyword));
				list.AddRange(Enumerable.Select<CRMspSelectCompanyTypesWithPaging_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyTypesWithPaging_Result>)list11, (Func<CRMspSelectCompanyTypesWithPaging_Result, SelectListItem>)((CRMspSelectCompanyTypesWithPaging_Result item) => new SelectListItem
				{
					Text = item.CompanyTypeName,
					Value = item.CompanyTypeID.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<CRMspSelectCompanyTypesWithPaging_Result>((IEnumerable<CRMspSelectCompanyTypesWithPaging_Result>)list11) ? Enumerable.FirstOrDefault<CRMspSelectCompanyTypesWithPaging_Result>((IEnumerable<CRMspSelectCompanyTypesWithPaging_Result>)list11).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 10:
			{
				List<CRMspSelectCompanyPresentationsWithPaging_Result> list12 = Enumerable.ToList<CRMspSelectCompanyPresentationsWithPaging_Result>((IEnumerable<CRMspSelectCompanyPresentationsWithPaging_Result>)_dbIII.CRMspSelectCompanyPresentationsWithPaging(pageNumber, pageSize, lCID, result, searchKeyword));
				list.AddRange(Enumerable.Select<CRMspSelectCompanyPresentationsWithPaging_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyPresentationsWithPaging_Result>)list12, (Func<CRMspSelectCompanyPresentationsWithPaging_Result, SelectListItem>)((CRMspSelectCompanyPresentationsWithPaging_Result item) => new SelectListItem
				{
					Text = item.Presentation,
					Value = item.CompanyPresentationID.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<CRMspSelectCompanyPresentationsWithPaging_Result>((IEnumerable<CRMspSelectCompanyPresentationsWithPaging_Result>)list12) ? Enumerable.FirstOrDefault<CRMspSelectCompanyPresentationsWithPaging_Result>((IEnumerable<CRMspSelectCompanyPresentationsWithPaging_Result>)list12).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 11:
			{
				List<WSspSelectProductFirstGroupWithPaging_Result> list5 = Enumerable.ToList<WSspSelectProductFirstGroupWithPaging_Result>((IEnumerable<WSspSelectProductFirstGroupWithPaging_Result>)_dbIII.WSspSelectProductFirstGroupWithPaging(pageNumber, pageSize, lCID, result, searchKeyword));
				list.AddRange(Enumerable.Select<WSspSelectProductFirstGroupWithPaging_Result, SelectListItem>((IEnumerable<WSspSelectProductFirstGroupWithPaging_Result>)list5, (Func<WSspSelectProductFirstGroupWithPaging_Result, SelectListItem>)((WSspSelectProductFirstGroupWithPaging_Result item) => new SelectListItem
				{
					Text = item.FGName,
					Value = item.PrdFirstGroupID.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<WSspSelectProductFirstGroupWithPaging_Result>((IEnumerable<WSspSelectProductFirstGroupWithPaging_Result>)list5) ? Enumerable.FirstOrDefault<WSspSelectProductFirstGroupWithPaging_Result>((IEnumerable<WSspSelectProductFirstGroupWithPaging_Result>)list5).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 12:
			{
				List<WSspSelectProductSecondGroupWithPaging_Result> list10 = Enumerable.ToList<WSspSelectProductSecondGroupWithPaging_Result>((IEnumerable<WSspSelectProductSecondGroupWithPaging_Result>)_dbIII.WSspSelectProductSecondGroupWithPaging(pageNumber, pageSize, lCID, result, searchKeyword, productFirstGroupId));
				list.AddRange(Enumerable.Select<WSspSelectProductSecondGroupWithPaging_Result, SelectListItem>((IEnumerable<WSspSelectProductSecondGroupWithPaging_Result>)list10, (Func<WSspSelectProductSecondGroupWithPaging_Result, SelectListItem>)((WSspSelectProductSecondGroupWithPaging_Result item) => new SelectListItem
				{
					Text = item.SGName,
					Value = item.PrdSecondGroupID.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<WSspSelectProductSecondGroupWithPaging_Result>((IEnumerable<WSspSelectProductSecondGroupWithPaging_Result>)list10) ? Enumerable.FirstOrDefault<WSspSelectProductSecondGroupWithPaging_Result>((IEnumerable<WSspSelectProductSecondGroupWithPaging_Result>)list10).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 13:
			{
				List<WSspSelectProductWithPaging_Result> list17 = Enumerable.ToList<WSspSelectProductWithPaging_Result>((IEnumerable<WSspSelectProductWithPaging_Result>)_dbIII.WSspSelectProductWithPaging(pageNumber, pageSize, lCID, result, searchKeyword, productFirstGroupId, productSecondGroupId));
				list.AddRange(Enumerable.Select<WSspSelectProductWithPaging_Result, SelectListItem>((IEnumerable<WSspSelectProductWithPaging_Result>)list17, (Func<WSspSelectProductWithPaging_Result, SelectListItem>)((WSspSelectProductWithPaging_Result item) => new SelectListItem
				{
					Text = item.PrdName,
					Value = item.ProductID.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<WSspSelectProductWithPaging_Result>((IEnumerable<WSspSelectProductWithPaging_Result>)list17) ? Enumerable.FirstOrDefault<WSspSelectProductWithPaging_Result>((IEnumerable<WSspSelectProductWithPaging_Result>)list17).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 14:
			{
				List<WSspSelectOrderOprWithPaging_Result> list13 = Enumerable.ToList<WSspSelectOrderOprWithPaging_Result>((IEnumerable<WSspSelectOrderOprWithPaging_Result>)_dbIII.WSspSelectOrderOprWithPaging(pageNumber, pageSize, lCID, result, userId, result2, searchKeyword));
				list.AddRange(Enumerable.Select<WSspSelectOrderOprWithPaging_Result, SelectListItem>((IEnumerable<WSspSelectOrderOprWithPaging_Result>)list13, (Func<WSspSelectOrderOprWithPaging_Result, SelectListItem>)((WSspSelectOrderOprWithPaging_Result item) => new SelectListItem
				{
					Text = item.Name,
					Value = item.OrderOprID.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<WSspSelectOrderOprWithPaging_Result>((IEnumerable<WSspSelectOrderOprWithPaging_Result>)list13) ? Enumerable.FirstOrDefault<WSspSelectOrderOprWithPaging_Result>((IEnumerable<WSspSelectOrderOprWithPaging_Result>)list13).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 15:
			{
				List<WSspSelectOrderGroupWithPaging_Result> list3 = Enumerable.ToList<WSspSelectOrderGroupWithPaging_Result>((IEnumerable<WSspSelectOrderGroupWithPaging_Result>)_dbIII.WSspSelectOrderGroupWithPaging(pageNumber, pageSize, lCID, result, userId, result2, searchKeyword));
				list.AddRange(Enumerable.Select<WSspSelectOrderGroupWithPaging_Result, SelectListItem>((IEnumerable<WSspSelectOrderGroupWithPaging_Result>)list3, (Func<WSspSelectOrderGroupWithPaging_Result, SelectListItem>)((WSspSelectOrderGroupWithPaging_Result item) => new SelectListItem
				{
					Text = item.OrderGroupName,
					Value = item.OrderGroupId.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<WSspSelectOrderGroupWithPaging_Result>((IEnumerable<WSspSelectOrderGroupWithPaging_Result>)list3) ? Enumerable.FirstOrDefault<WSspSelectOrderGroupWithPaging_Result>((IEnumerable<WSspSelectOrderGroupWithPaging_Result>)list3).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 16:
			{
				List<WSspSelectOrderStatusWithPaging_Result> list14 = Enumerable.ToList<WSspSelectOrderStatusWithPaging_Result>((IEnumerable<WSspSelectOrderStatusWithPaging_Result>)_dbIII.WSspSelectOrderStatusWithPaging(pageNumber, pageSize, lCID, result, userId, searchKeyword));
				list.AddRange(Enumerable.Select<WSspSelectOrderStatusWithPaging_Result, SelectListItem>((IEnumerable<WSspSelectOrderStatusWithPaging_Result>)list14, (Func<WSspSelectOrderStatusWithPaging_Result, SelectListItem>)((WSspSelectOrderStatusWithPaging_Result item) => new SelectListItem
				{
					Text = item.OrderStatus,
					Value = item.OrderStatusId.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<WSspSelectOrderStatusWithPaging_Result>((IEnumerable<WSspSelectOrderStatusWithPaging_Result>)list14) ? Enumerable.FirstOrDefault<WSspSelectOrderStatusWithPaging_Result>((IEnumerable<WSspSelectOrderStatusWithPaging_Result>)list14).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 17:
			{
				List<WSspSelectDeliveryTermWithPaging_Result> list8 = Enumerable.ToList<WSspSelectDeliveryTermWithPaging_Result>((IEnumerable<WSspSelectDeliveryTermWithPaging_Result>)_dbIII.WSspSelectDeliveryTermWithPaging(pageNumber, pageSize, lCID, result, userId, result2, searchKeyword));
				list.AddRange(Enumerable.Select<WSspSelectDeliveryTermWithPaging_Result, SelectListItem>((IEnumerable<WSspSelectDeliveryTermWithPaging_Result>)list8, (Func<WSspSelectDeliveryTermWithPaging_Result, SelectListItem>)((WSspSelectDeliveryTermWithPaging_Result item) => new SelectListItem
				{
					Text = item.DeliveryTerm,
					Value = item.DeliveryTermId.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<WSspSelectDeliveryTermWithPaging_Result>((IEnumerable<WSspSelectDeliveryTermWithPaging_Result>)list8) ? Enumerable.FirstOrDefault<WSspSelectDeliveryTermWithPaging_Result>((IEnumerable<WSspSelectDeliveryTermWithPaging_Result>)list8).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 18:
			{
				List<WSspSelectSettlementTypeWithPaging_Result> list2 = Enumerable.ToList<WSspSelectSettlementTypeWithPaging_Result>((IEnumerable<WSspSelectSettlementTypeWithPaging_Result>)_dbIII.WSspSelectSettlementTypeWithPaging(pageNumber, pageSize, lCID, result, userId, result2, searchKeyword));
				list.AddRange(Enumerable.Select<WSspSelectSettlementTypeWithPaging_Result, SelectListItem>((IEnumerable<WSspSelectSettlementTypeWithPaging_Result>)list2, (Func<WSspSelectSettlementTypeWithPaging_Result, SelectListItem>)((WSspSelectSettlementTypeWithPaging_Result item) => new SelectListItem
				{
					Text = item.Name,
					Value = item.Id.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<WSspSelectSettlementTypeWithPaging_Result>((IEnumerable<WSspSelectSettlementTypeWithPaging_Result>)list2) ? Enumerable.FirstOrDefault<WSspSelectSettlementTypeWithPaging_Result>((IEnumerable<WSspSelectSettlementTypeWithPaging_Result>)list2).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			}
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

	[HttpPost]
	public ActionResult SearchProduct(string search)
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
			ObjectResult<WSspSearchProducts_Result> objectResult = _db.WSspSearchProducts(null, null, null, search, null, null, lCID, result, null, null, null, null, null, null);
			list.AddRange(Enumerable.Select<WSspSearchProducts_Result, SelectListItem>((IEnumerable<WSspSearchProducts_Result>)objectResult, (Func<WSspSearchProducts_Result, SelectListItem>)((WSspSearchProducts_Result item) => new SelectListItem
			{
				Text = item.PName + " (" + item.PrdCode + ")",
				Value = item.PrdId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[HttpPost]
	public ActionResult GetSalesTargets(int pageNumber = 1, int pageSize = 12, string searchKeyword = "")
	{
		try
		{
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int.TryParse(SysSeting.Get().DefaultLanguageID?.ToString() ?? "1065", out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			ObjectParameter objectParameter = new ObjectParameter("TotalCount", 0);
			CRMSpIIIEntities dbIII = _dbIII;
			int? pageNumber2 = pageNumber;
			int? pageSize2 = pageSize;
			string searchTerm = searchKeyword ?? "";
			List<WSspSelectSalesTargetsWithPaging_Result> list = Enumerable.ToList<WSspSelectSalesTargetsWithPaging_Result>((IEnumerable<WSspSelectSalesTargetsWithPaging_Result>)dbIII.WSspSelectSalesTargetsWithPaging(lCID, result, searchTerm, pageNumber2, pageSize2, objectParameter));
			List<SalesTargetViewModel> list2 = new List<SalesTargetViewModel>();
			List<CRMspSelectUsers_Result> list3 = Enumerable.ToList<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)_db.CRMspSelectUsers(lCID, result, result2));
			List<CRMspSelectUserDepartments_Result> list4 = Enumerable.ToList<CRMspSelectUserDepartments_Result>((IEnumerable<CRMspSelectUserDepartments_Result>)_db.CRMspSelectUserDepartments(lCID, result, result2));
			foreach (WSspSelectSalesTargetsWithPaging_Result item2 in list)
			{
				_ = item2.TargetFromDate;
				string targetFromDate = DateTimeClass.GetLocalDate(item2.TargetFromDate).Value.ToString("yyyy/MM/dd");
				_ = item2.TargetToDate;
				string targetToDate = DateTimeClass.GetLocalDate(item2.TargetToDate).Value.ToString("yyyy/MM/dd");
				SalesTargetUserScopeViewModel salesTargetUserScopeViewModel = new SalesTargetUserScopeViewModel();
				if (!string.IsNullOrEmpty(item2.TargetUserScopeJson))
				{
					salesTargetUserScopeViewModel = JsonConvert.DeserializeObject<SalesTargetUserScopeViewModel>(item2.TargetUserScopeJson);
				}
				if (salesTargetUserScopeViewModel != null && salesTargetUserScopeViewModel.Key == 2 && !string.IsNullOrEmpty(salesTargetUserScopeViewModel.DepartmentId))
				{
					int deptId = 0;
					if (int.TryParse(salesTargetUserScopeViewModel.DepartmentId, out deptId))
					{
						salesTargetUserScopeViewModel.DepartmentName = Enumerable.FirstOrDefault<CRMspSelectUserDepartments_Result>((IEnumerable<CRMspSelectUserDepartments_Result>)list4, (Func<CRMspSelectUserDepartments_Result, bool>)((CRMspSelectUserDepartments_Result d) => d.DepartmentID == deptId))?.Department ?? "";
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
							CRMspSelectUsers_Result cRMspSelectUsers_Result = Enumerable.FirstOrDefault<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)list3, (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result u) => u.UserId == userId));
							selectedUser.Text = cRMspSelectUsers_Result?.LName + " " + cRMspSelectUsers_Result?.FName;
						}
					}
				}
				SalesTargetDistributionViewModel targetDistributionDetails = null;
				if (!string.IsNullOrEmpty(item2.TargetDistributionDetailsJson))
				{
					targetDistributionDetails = JsonConvert.DeserializeObject<SalesTargetDistributionViewModel>(item2.TargetDistributionDetailsJson);
				}
				List<SalesTargetTermViewModel> targetTerms = null;
				if (!string.IsNullOrEmpty(item2.TargetTermsJson))
				{
					targetTerms = JsonConvert.DeserializeObject<List<SalesTargetTermViewModel>>(item2.TargetTermsJson);
				}
				SalesTargetViewModel item = new SalesTargetViewModel
				{
					SalesTargetId = item2.SalesTargetId,
					TargetTitle = item2.TargetTitle,
					TargetOrderCount = item2.TargetOrderCount,
					TargetOrderAmount = item2.TargetOrderAmount,
					TargetFromDateTime = item2.TargetFromDate,
					TargetToDateTime = item2.TargetToDate,
					TargetFromDate = targetFromDate,
					TargetToDate = targetToDate,
					RegisterDateTime = item2.RegisterDate,
					TargetDistributionDetailsJson = item2.TargetDistributionDetailsJson,
					TargetDistributionDetails = targetDistributionDetails,
					TargetTermsJson = item2.TargetTermsJson,
					TargetTerms = targetTerms,
					TargetUserScopeJson = item2.TargetUserScopeJson,
					TargetUserScope = salesTargetUserScopeViewModel
				};
				list2.Add(item);
			}
			int num = int.Parse(objectParameter.Value.ToString());
			bool hasNextPage = list2.Count == pageSize && num > pageNumber * pageSize;
			return Json(new
			{
				Status = 1,
				Message = "",
				Data = list2,
				TotalCount = num,
				PageNumber = pageNumber,
				PageSize = pageSize,
				HasNextPage = hasNextPage
			}, JsonRequestBehavior.AllowGet);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Json(new
			{
				Status = 0,
				Message = Messages.msgErrorOperationFailed,
				Data = new List<SalesTargetViewModel>(),
				TotalCount = 0,
				PageNumber = pageNumber,
				PageSize = pageSize,
				HasNextPage = false
			}, JsonRequestBehavior.AllowGet);
		}
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmSalesTarget", ActionName = "actDelete")]
	public ActionResult Delete(int salesTargetId)
	{
		try
		{
			if (salesTargetId > 0)
			{
				ObjectParameter errorMessage = new ObjectParameter("ErrorMessage", "");
				_dbIII.WSspDeleteSalesTarget(salesTargetId, errorMessage);
				return Json(new CommonResultViewModel<string>
				{
					Data = "",
					Message = "",
					Status = CommonResultStatusViewModel.Success
				});
			}
			return Json(new CommonResultViewModel<string>
			{
				Data = "",
				Message = Messages.ErrorNotFound,
				Status = CommonResultStatusViewModel.Error
			});
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Json(new CommonResultViewModel<string>
			{
				Data = "",
				Message = Messages.msgErrorOperationFailed,
				Status = CommonResultStatusViewModel.Error
			}, JsonRequestBehavior.AllowGet);
		}
	}

	[HttpPost]
	[AjaxOnly]
	public ActionResult GetCountries()
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
			_ = UserLogin.CurrentUser.UserId;
			List<CRMspSelectCountry_Result> list2 = Enumerable.ToList<CRMspSelectCountry_Result>((IEnumerable<CRMspSelectCountry_Result>)_db.CRMspSelectCountry(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectCountry_Result, SelectListItem>((IEnumerable<CRMspSelectCountry_Result>)list2, (Func<CRMspSelectCountry_Result, SelectListItem>)((CRMspSelectCountry_Result item) => new SelectListItem
			{
				Text = item.Country,
				Value = item.CountryID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[HttpPost]
	[AjaxOnly]
	public ActionResult GetProvinces()
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
			_ = UserLogin.CurrentUser.UserId;
			List<CRMspSelectProvince_Result> list2 = Enumerable.ToList<CRMspSelectProvince_Result>((IEnumerable<CRMspSelectProvince_Result>)_db.CRMspSelectProvince(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectProvince_Result, SelectListItem>((IEnumerable<CRMspSelectProvince_Result>)list2, (Func<CRMspSelectProvince_Result, SelectListItem>)((CRMspSelectProvince_Result item) => new SelectListItem
			{
				Text = item.Province,
				Value = item.ProvinceID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[HttpPost]
	[AjaxOnly]
	public ActionResult GetCompanyGroups()
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
			int userId = UserLogin.CurrentUser.UserId;
			List<CRMspSelectCompanyGroup_Result> list2 = Enumerable.ToList<CRMspSelectCompanyGroup_Result>((IEnumerable<CRMspSelectCompanyGroup_Result>)_db.CRMspSelectCompanyGroup(userId, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyGroup_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroup_Result>)list2, (Func<CRMspSelectCompanyGroup_Result, SelectListItem>)((CRMspSelectCompanyGroup_Result item) => new SelectListItem
			{
				Text = item.GroupName,
				Value = item.CompanyGroupID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[HttpPost]
	[AjaxOnly]
	public ActionResult GetProductFirstGroups()
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
			_ = UserLogin.CurrentUser.UserId;
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
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[HttpPost]
	[AjaxOnly]
	public ActionResult GetProductSecondGroups(int? productFirstGroupId = 0)
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
			_ = UserLogin.CurrentUser.UserId;
			CRMSpEntities db = _db;
			int? languageID = lCID;
			int? defaultLanguageID = result;
			List<WSspSelectProductSecondGroup_Result> list2 = Enumerable.ToList<WSspSelectProductSecondGroup_Result>((IEnumerable<WSspSelectProductSecondGroup_Result>)db.WSspSelectProductSecondGroup(productFirstGroupId, languageID, defaultLanguageID));
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
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	private void RemoveTextFieldsRecursive(JToken token)
	{
		if (token.Type == JTokenType.Object)
		{
			JObject jObject = (JObject)token;
			if (jObject["Text"] != null)
			{
				jObject.Remove("Text");
			}
			{
				foreach (JProperty item in Enumerable.ToList<JProperty>(jObject.Properties()))
				{
					RemoveTextFieldsRecursive(item.Value);
				}
				return;
			}
		}
		if (token.Type != JTokenType.Array)
		{
			return;
		}
		foreach (JToken item2 in token.Children())
		{
			RemoveTextFieldsRecursive(item2);
		}
	}

	private string ConvertTermsJson(string originalJson)
	{
		if (string.IsNullOrEmpty(originalJson))
		{
			return null;
		}
		try
		{
			JArray jArray = JArray.Parse(originalJson);
			JArray jArray2 = new JArray();
			foreach (JToken item in jArray)
			{
				string text = item["Key"]?.ToString();
				JArray jArray3 = item["Items"] as JArray;
				if (!string.IsNullOrEmpty(text) && jArray3 != null && jArray3.Count > 0)
				{
					List<string> values = Enumerable.ToList<string>(Enumerable.Where<string>(Enumerable.Select<JToken, string>((IEnumerable<JToken>)jArray3, (Func<JToken, string>)((JToken i) => i["Val"]?.ToString())), (Func<string, bool>)((string id) => !string.IsNullOrEmpty(id))));
					JObject jObject = new JObject();
					jObject["Key"] = text;
					jObject["Ids"] = string.Join(",", values);
					jArray2.Add(jObject);
				}
			}
			return jArray2.ToString(Formatting.None);
		}
		catch
		{
			return originalJson;
		}
	}

	private string ConvertUserScopeJson(string originalJson)
	{
		if (string.IsNullOrEmpty(originalJson))
		{
			return null;
		}
		try
		{
			JObject jObject = JObject.Parse(originalJson);
			JObject jObject2 = new JObject();
			jObject2["Key"] = jObject["Key"];
			if (jObject["DepartmentId"] != null)
			{
				jObject2["DepartmentId"] = jObject["DepartmentId"];
			}
			if (jObject["SelectedUsers"] is JArray { Count: >0 } jArray)
			{
				List<string> values = Enumerable.ToList<string>(Enumerable.Where<string>(Enumerable.Select<JToken, string>((IEnumerable<JToken>)jArray, (Func<JToken, string>)((JToken u) => u["Val"]?.ToString())), (Func<string, bool>)((string id) => !string.IsNullOrEmpty(id))));
				jObject2["UserIds"] = string.Join(",", values);
			}
			return jObject2.ToString(Formatting.None);
		}
		catch
		{
			return originalJson;
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

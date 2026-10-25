using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Calendar;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Cache.User;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.PayRolls.Controllers;

public class PayRollListController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public int payrollListId;

		public int currLangID;

		internal bool _003CEditPayRollList_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditPayRollList_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditPayRollList_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public PayRollListLanguageIViewModel model;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__4;

		public Func<Languages, bool> _003C_003E9__10;

		internal bool _003CEditPayRollList_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditPayRollList_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditPayRollList_003Eb__4(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CEditPayRollList_003Eb__10(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_1
	{
		public PayRollList payrollList;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass9_1 CS_0024_003C_003E8__locals1;

		internal bool _003CEditPayRollList_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditPayRollList_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditPayRollList_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditPayRollList_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actPayRollList")]
	public ActionResult Index()
	{
		return View();
	}

	[AjaxOnly]
	public JsonResult GetPayRollList(string month, string year)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		PayRollListViewModel payRollListViewModel = new PayRollListViewModel();
		payRollListViewModel.PayRollList = new List<PayRollspSelectListWithMonth_Result>();
		payRollListViewModel.IsFind = false;
		try
		{
			if (!string.IsNullOrWhiteSpace(month) && !string.IsNullOrWhiteSpace(year))
			{
				int num = 0;
				int num2 = 0;
				try
				{
					string text = year + "/" + month + "/01";
					DateTime dateTime = default(DateTime);
					string text2 = "";
					text2 = PersianDate.GetFormatetdDate(text.Replace("/", ""));
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text2 + " 00:00:00", new PersianCulture());
						num = int.Parse(dateTime.ToString("MM", new PersianCulture()));
						num2 = int.Parse(dateTime.ToString("yyyy", new PersianCulture()));
						break;
					case 1025:
						dateTime = DateTime.Parse(text2 + " 00:00:00", new CultureInfo("ar-SA"));
						num = int.Parse(dateTime.ToString("MM", new CultureInfo("ar-SA")));
						num2 = int.Parse(dateTime.ToString("yyyy", new CultureInfo("ar-SA")));
						break;
					default:
						dateTime = DateTime.Parse(text2 + " 00:00:00", new CultureInfo("en-US"));
						num = int.Parse(dateTime.ToString("MM", new CultureInfo("en-US")));
						num2 = int.Parse(dateTime.ToString("yyyy", new CultureInfo("en-US")));
						break;
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					payRollListViewModel.Message = string.Format(Messages.ErrorInFormat, Labels.PayRollListYear + " , " + Labels.PayRollListMonth);
				}
				if (!string.IsNullOrWhiteSpace(num2.ToString() + num) && num > 0 && num2 > 0)
				{
					_ = Labels.PayRollItemKindAdditive;
					_ = Labels.PayRollItemKindReduction;
					_ = UserLogin.CurrentUser.UserId;
					payRollListViewModel.PayRollList = Enumerable.ToList<PayRollspSelectListWithMonth_Result>((IEnumerable<PayRollspSelectListWithMonth_Result>)_dbI.PayRollspSelectListWithMonth(num, num2, lCID, result));
					if (payRollListViewModel.PayRollList != null && Enumerable.Any<PayRollspSelectListWithMonth_Result>((IEnumerable<PayRollspSelectListWithMonth_Result>)payRollListViewModel.PayRollList))
					{
						payRollListViewModel.IsFind = true;
						foreach (PayRollspSelectListWithMonth_Result payRoll in payRollListViewModel.PayRollList)
						{
							_ = payRoll.FirstRegisterDate;
							payRoll.FirstRegisterDatePersian = payRoll.FirstRegisterDate.ToString("yyyy/MM/dd");
							_ = payRoll.RegisterDate;
							payRoll.RegisterDatePersian = payRoll.RegisterDate.ToString("yyyy/MM/dd");
						}
					}
					else
					{
						payRollListViewModel.PayRollList = new List<PayRollspSelectListWithMonth_Result>();
						payRollListViewModel.Message = Messages.msgErrorPayrollListNotRegisteredTheMonth;
					}
				}
				else
				{
					payRollListViewModel.Message = string.Format(Messages.ErrorInFormat, Labels.PayRollListYear + " , " + Labels.PayRollListMonth);
				}
			}
			else if (string.IsNullOrWhiteSpace(month))
			{
				payRollListViewModel.Message = string.Format(Messages.msgErrorIsNotSelectedItem, Labels.PayRollListMonth);
			}
			else if (string.IsNullOrWhiteSpace(year))
			{
				payRollListViewModel.Message = string.Format(Messages.msgErrorIsNotEnteredItem, Labels.PayRollListYear);
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			payRollListViewModel.Message = Messages.msgErrorRunFunction + "<br />" + ex.Message;
		}
		JsonResult jsonResult = Json(payRollListViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetPayRollListItems(int payrollListId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		PayRollListViewModel payRollListViewModel = new PayRollListViewModel();
		payRollListViewModel.PayRollItems = new List<PayRollspSelectActiveItems_Result>();
		payRollListViewModel.PayRollList = new List<PayRollspSelectListWithMonth_Result>();
		payRollListViewModel.PayRollListItems = new List<PayRollspSelectListItems_Result>();
		payRollListViewModel.PayRollListItemValues = new List<PayRollspSelectUserCycleItemValuesWithListId_Result>();
		payRollListViewModel.IsFind = false;
		try
		{
			string payRollItemKindAdditive = Labels.PayRollItemKindAdditive;
			string payRollItemKindReduction = Labels.PayRollItemKindReduction;
			_ = UserLogin.CurrentUser.UserId;
			payRollListViewModel.PayRollItems = Enumerable.ToList<PayRollspSelectActiveItems_Result>((IEnumerable<PayRollspSelectActiveItems_Result>)_dbI.PayRollspSelectActiveItems(payRollItemKindAdditive, payRollItemKindReduction, lCID, result));
			if (payRollListViewModel.PayRollItems != null && Enumerable.Any<PayRollspSelectActiveItems_Result>((IEnumerable<PayRollspSelectActiveItems_Result>)payRollListViewModel.PayRollItems))
			{
				payRollListViewModel.IsFind = true;
				List<PayRollspSelectListItems_Result> list = Enumerable.ToList<PayRollspSelectListItems_Result>((IEnumerable<PayRollspSelectListItems_Result>)_dbI.PayRollspSelectListItems(payrollListId, UserLogin.CurrentUser.UserId, lCID, result));
				if (list != null && Enumerable.Any<PayRollspSelectListItems_Result>((IEnumerable<PayRollspSelectListItems_Result>)list))
				{
					foreach (PayRollspSelectListItems_Result item in list)
					{
						_ = item.CycleDate;
						item.CycleDatePersian = item.CycleDate.ToString("yyyy/MM/dd");
						item.CycleVerifiedDatePersian = (item.CycleVerifiedDate.HasValue ? item.CycleVerifiedDate.Value.ToString("yyyy/MM/dd") : "");
						item.CycleIsVerified = item.CycleIsVerified.HasValue && item.CycleIsVerified != false;
					}
					payRollListViewModel.PayRollListItems.AddRange(list);
				}
				List<PayRollspSelectUserCycleItemValuesWithListId_Result> list2 = Enumerable.ToList<PayRollspSelectUserCycleItemValuesWithListId_Result>((IEnumerable<PayRollspSelectUserCycleItemValuesWithListId_Result>)_dbI.PayRollspSelectUserCycleItemValuesWithListId(payrollListId, UserLogin.CurrentUser.UserId, lCID, result));
				if (list2 != null && Enumerable.Any<PayRollspSelectUserCycleItemValuesWithListId_Result>((IEnumerable<PayRollspSelectUserCycleItemValuesWithListId_Result>)list2))
				{
					foreach (PayRollspSelectUserCycleItemValuesWithListId_Result item2 in list2)
					{
						_ = item2.FirstRegisterDate;
						item2.FirstRegisterDatePersian = item2.FirstRegisterDate.ToString("yyyy/MM/dd");
						_ = item2.RegisterDate;
						item2.RegisterDatePersian = item2.RegisterDate.ToString("yyyy/MM/dd");
					}
					payRollListViewModel.PayRollListItemValues.AddRange(list2);
				}
				if (payRollListViewModel.PayRollListItems == null)
				{
					payRollListViewModel.PayRollListItems = new List<PayRollspSelectListItems_Result>();
				}
				if (payRollListViewModel.PayRollListItemValues == null)
				{
					payRollListViewModel.PayRollListItemValues = new List<PayRollspSelectUserCycleItemValuesWithListId_Result>();
				}
			}
			else
			{
				payRollListViewModel.PayRollItems = new List<PayRollspSelectActiveItems_Result>();
				payRollListViewModel.Message = Messages.ErrorNotFound;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			payRollListViewModel.Message = Messages.msgErrorRunFunction + "<br />" + ex.Message;
		}
		JsonResult jsonResult = Json(payRollListViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmPayRollList", ActionName = "actInsertList")]
	public ActionResult InsertPayRollList()
	{
		base.ViewBag.IsBuying = VersionBuyer.PayRoll;
		GetPayRollListGroup();
		return View();
	}

	[AjaxOnly]
	public JsonResult ActInsertList(string month, string year, string listTitle, string listTitle_Lang, bool isCopyFromExistList, int? oldPayRollListId = null, int? payRollListGroupId = null, string cycleTitle = "", string cycleTitleLang = "")
	{
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		string data = "";
		string text = "";
		CommonResultStatusViewModel status = CommonResultStatusViewModel.Success;
		CommonResultViewModel<string> data2;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
			if (defLangID <= 0)
			{
				defLangID = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (!VersionBuyer.PayRoll)
			{
				data = "";
				text = Messages.VersionBuyModule;
				status = CommonResultStatusViewModel.Error;
				data2 = new CommonResultViewModel<string>
				{
					Data = data,
					Message = text,
					Status = status
				};
				return Json(data2, JsonRequestBehavior.AllowGet);
			}
			if (!UserLogin.IsUserAccess("frmPayRollList", "actInsertList"))
			{
				data = "";
				text = Messages.NotAccessToPage;
				status = CommonResultStatusViewModel.Error;
				data2 = new CommonResultViewModel<string>
				{
					Data = data,
					Message = text,
					Status = status
				};
				return Json(data2, JsonRequestBehavior.AllowGet);
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short value3 = short.Parse(Financial.Get().Id.ToString());
			int userId = UserLogin.CurrentUser.UserId;
			DateTime value4 = default(DateTime);
			string cycleDatePersian = "";
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrWhiteSpace(listTitle_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(listTitle_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = listTitle,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrWhiteSpace(cycleTitleLang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(cycleTitleLang);
			}
			if (!string.IsNullOrWhiteSpace(cycleTitle))
			{
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = cycleTitle,
					LanguageId = lCID
				});
			}
			if (list2 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2))
			{
				cycleTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : "");
				cycleTitleLang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID))));
			}
			int num = 0;
			if (string.IsNullOrWhiteSpace(listTitle))
			{
				num++;
				text = text + string.Format(Messages.msgErrorIsNotEnteredItem, Labels.PayRollUserCycleListCycleTitle) + "<br>";
			}
			else if (!checkMultiLanguage(listTitle, list))
			{
				num++;
				text = text + string.Format(Messages.CheckFieldInLang, Labels.PayRollListTitle) + "<br>";
			}
			if (string.IsNullOrWhiteSpace(month))
			{
				num++;
				text = text + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.PayRollListMonth) + "<br>";
			}
			if (string.IsNullOrWhiteSpace(year))
			{
				num++;
				text = text + string.Format(Messages.msgErrorIsNotEnteredItem, Labels.PayRollListYear) + "<br>";
			}
			if (isCopyFromExistList && oldPayRollListId.GetValueOrDefault() == 0)
			{
				num++;
				text = text + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.PayRollListOldList) + "<br>";
			}
			if (!string.IsNullOrWhiteSpace(month) && !string.IsNullOrWhiteSpace(year))
			{
				try
				{
					string text2 = now.ToString("dd");
					switch (lCID)
					{
					case 1065:
						if (int.Parse(month) > 6 && int.Parse(month) <= 12)
						{
							if (int.Parse(text2) == 31)
							{
								text2 = "30";
							}
							if (int.Parse(month) == 12 && (int.Parse(text2) == 31 || int.Parse(text2) == 30))
							{
								text2 = "29";
							}
						}
						break;
					case 1025:
						if (int.Parse(text2) == 31)
						{
							text2 = "30";
						}
						switch (int.Parse(month))
						{
						case 2:
						case 4:
						case 6:
						case 8:
						case 9:
						case 10:
						case 12:
							if (int.Parse(text2) == 30)
							{
								text2 = "29";
							}
							break;
						}
						break;
					default:
						switch (int.Parse(month))
						{
						case 2:
						case 4:
						case 6:
						case 9:
						case 11:
							if (int.Parse(text2) == 31)
							{
								text2 = "30";
							}
							if (int.Parse(month) == 2 && (int.Parse(text2) == 31 || int.Parse(text2) == 30 || int.Parse(text2) == 29))
							{
								text2 = "28";
							}
							break;
						}
						break;
					}
					string text3 = year + "/" + month + "/" + text2;
					DateTime dateTime = default(DateTime);
					string text4 = "";
					text4 = PersianDate.GetFormatetdDate(text3.Replace("/", ""));
					dateTime = lCID switch
					{
						1065 => DateTime.Parse(text4 + " 00:00:00", new PersianCulture()), 
						1025 => DateTime.Parse(text4 + " 00:00:00", new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(text4 + " 00:00:00", new CultureInfo("en-US")), 
					};
					value4 = dateTime;
					cycleDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					num++;
					text = string.Format(Messages.ErrorInFormat, Labels.PayRollUserCycleListYear + " , " + Labels.PayRollUserCycleListMonth);
				}
			}
			if (num == 0)
			{
				int value5 = 0;
				int value6 = 0;
				string payRollListLang = "";
				List<PayRollListLanguageViewModel> list3 = new List<PayRollListLanguageViewModel>();
				foreach (Languages lang in Enumerable.ToList<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get()))
				{
					PayRollListLanguageViewModel payRollListLanguageViewModel = new PayRollListLanguageViewModel();
					payRollListLanguageViewModel.LanguageID = lang.LanguageID;
					payRollListLanguageViewModel.ListTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : "");
					if (lang.LanguageID == 1065)
					{
						payRollListLanguageViewModel.ListMonth = int.Parse(value4.ToString("MM", new PersianCulture()));
						payRollListLanguageViewModel.ListYear = int.Parse(value4.ToString("yyyy", new PersianCulture()));
					}
					else
					{
						payRollListLanguageViewModel.ListMonth = int.Parse(value4.ToString("MM", new CultureInfo(lang.LanguageCollation)));
						payRollListLanguageViewModel.ListYear = int.Parse(value4.ToString("yyyy", new CultureInfo(lang.LanguageCollation)));
					}
					list3.Add(payRollListLanguageViewModel);
				}
				if (list3 != null && Enumerable.Any<PayRollListLanguageViewModel>((IEnumerable<PayRollListLanguageViewModel>)list3))
				{
					listTitle = (Enumerable.Any<PayRollListLanguageViewModel>((IEnumerable<PayRollListLanguageViewModel>)list3, (Func<PayRollListLanguageViewModel, bool>)((PayRollListLanguageViewModel c) => c.LanguageID == defLangID)) ? Enumerable.FirstOrDefault<PayRollListLanguageViewModel>((IEnumerable<PayRollListLanguageViewModel>)list3, (Func<PayRollListLanguageViewModel, bool>)((PayRollListLanguageViewModel c) => c.LanguageID == defLangID)).ListTitle : "");
					value5 = (Enumerable.Any<PayRollListLanguageViewModel>((IEnumerable<PayRollListLanguageViewModel>)list3, (Func<PayRollListLanguageViewModel, bool>)((PayRollListLanguageViewModel c) => c.LanguageID == defLangID)) ? Enumerable.FirstOrDefault<PayRollListLanguageViewModel>((IEnumerable<PayRollListLanguageViewModel>)list3, (Func<PayRollListLanguageViewModel, bool>)((PayRollListLanguageViewModel c) => c.LanguageID == defLangID)).ListMonth : 0);
					value6 = (Enumerable.Any<PayRollListLanguageViewModel>((IEnumerable<PayRollListLanguageViewModel>)list3, (Func<PayRollListLanguageViewModel, bool>)((PayRollListLanguageViewModel c) => c.LanguageID == defLangID)) ? Enumerable.FirstOrDefault<PayRollListLanguageViewModel>((IEnumerable<PayRollListLanguageViewModel>)list3, (Func<PayRollListLanguageViewModel, bool>)((PayRollListLanguageViewModel c) => c.LanguageID == defLangID)).ListYear : 0);
					payRollListLang = JsonConvert.SerializeObject(Enumerable.ToList<PayRollListLanguageViewModel>(Enumerable.Where<PayRollListLanguageViewModel>((IEnumerable<PayRollListLanguageViewModel>)list3, (Func<PayRollListLanguageViewModel, bool>)((PayRollListLanguageViewModel c) => c.LanguageID != defLangID))));
				}
				ObjectParameter objectParameter = new ObjectParameter("payRollListInsertedId", typeof(int));
				_dbI.PayRollspIssueList(listTitle, value6, value5, payRollListGroupId, payRollListLang, isCopyFromExistList, oldPayRollListId, value4, cycleDatePersian, userId, value2, value3, value, registerDatePersian, appType, defLangID, objectParameter, cycleTitle, cycleTitleLang);
				int result = 0;
				if (objectParameter != null && objectParameter.Value != null)
				{
					int.TryParse(objectParameter.Value.ToString(), out result);
				}
				if (result <= 0)
				{
					data = "";
					text = Messages.msgErrorRunFunction;
					status = CommonResultStatusViewModel.Error;
				}
				else if (result > 0)
				{
					data = result.ToString();
					text = Messages.msgSuccessAction;
					status = CommonResultStatusViewModel.Success;
				}
			}
			else
			{
				data = "";
				if (string.IsNullOrWhiteSpace(text))
				{
					text = Messages.msgErrorRunFunction;
				}
				status = CommonResultStatusViewModel.Error;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			data = "";
			text = Messages.msgErrorRunFunction + " " + ex.Message;
			status = CommonResultStatusViewModel.Error;
		}
		data2 = new CommonResultViewModel<string>
		{
			Data = data,
			Message = text,
			Status = status
		};
		return Json(data2, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmPayRollList", ActionName = "actEditList")]
	public ActionResult EditPayRollList(int payrollListId = 0)
	{
		_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass8_0();
		CS_0024_003C_003E8__locals0.payrollListId = payrollListId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		PayRollListLanguageIViewModel model = new PayRollListLanguageIViewModel();
		_ = DateTime.Now;
		try
		{
			DbSet<PayRollList_Lang> payRollList_Lang = _dbTbl.PayRollList_Lang;
			ParameterExpression val = Expression.Parameter(typeof(PayRollList_Lang), "c");
			List<PayRollList_Lang> list = Enumerable.ToList<PayRollList_Lang>((IEnumerable<PayRollList_Lang>)Queryable.Where<PayRollList_Lang>((IQueryable<PayRollList_Lang>)payRollList_Lang, Expression.Lambda<Func<PayRollList_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			PayRollList payRollList = new PayRollList();
			if (CS_0024_003C_003E8__locals0.payrollListId == 0)
			{
				payRollList = new PayRollList();
				payRollList.PayRollListId = 0;
				base.ViewBag.Error = Messages.ErrorNotFound;
			}
			else
			{
				DbSet<PayRollList> payRollList2 = _dbTbl.PayRollList;
				val = Expression.Parameter(typeof(PayRollList), "m");
				payRollList = Queryable.FirstOrDefault<PayRollList>((IQueryable<PayRollList>)payRollList2, Expression.Lambda<Func<PayRollList, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (payRollList == null)
				{
					payRollList = new PayRollList();
					payRollList.PayRollListId = 0;
				}
			}
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<PayRollList_Lang, CommonMultiLanguageViewModel>((IEnumerable<PayRollList_Lang>)list, (Func<PayRollList_Lang, CommonMultiLanguageViewModel>)((PayRollList_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.ListTitle,
				LanguageId = item.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = payRollList.ListTitle,
				LanguageId = result
			});
			model = new PayRollListLanguageIViewModel
			{
				PayRollListId = payRollList.PayRollListId,
				PayRollListGroupId = payRollList.PayRollListGroupId,
				ListYear = payRollList.ListYear,
				ListMonth = payRollList.ListMonth,
				ListTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				ListTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))))
			};
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		GetPayRollListGroup();
		return View(model);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmPayRollList", ActionName = "actEditList")]
	public ActionResult EditPayRollList(PayRollListLanguageIViewModel model)
	{
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass9_0();
		CS_0024_003C_003E8__locals0.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		GetPayRollListGroup();
		if (base.ModelState.IsValid)
		{
			if (CS_0024_003C_003E8__locals0.model.PayRollListId <= 0 && !VersionBuyer.PayRoll)
			{
				DbSet<PayRollList> payRollList = _dbTbl.PayRollList;
				ParameterExpression val = Expression.Parameter(typeof(PayRollList), "c");
				if (Queryable.Any<PayRollList>((IQueryable<PayRollList>)payRollList, Expression.Lambda<Func<PayRollList, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)10, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val })))
				{
					base.ViewBag.Error = "BV|" + Messages.VersionBuy;
					return View(CS_0024_003C_003E8__locals0.model);
				}
			}
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.ListTitle_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.ListTitle_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.ListTitle,
				LanguageId = lCID
			});
			if (string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.model.ListTitle))
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.PayRollListTitle) + "<br/>";
				num++;
			}
			else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.model.ListTitle, list))
			{
				text = text + string.Format(Messages.CheckFieldInLang, Labels.PayRollListTitle) + "<br>";
				num++;
			}
			if (num == 0)
			{
				DateTime now = DateTime.Now;
				try
				{
					_003C_003Ec__DisplayClass9_1 _003C_003Ec__DisplayClass9_ = new _003C_003Ec__DisplayClass9_1();
					_003C_003Ec__DisplayClass9_.payrollList = new PayRollList();
					if (CS_0024_003C_003E8__locals0.model.PayRollListId > 0)
					{
						DbSet<PayRollList> payRollList2 = _dbTbl.PayRollList;
						ParameterExpression val = Expression.Parameter(typeof(PayRollList), "m");
						_003C_003Ec__DisplayClass9_.payrollList = Queryable.FirstOrDefault<PayRollList>((IQueryable<PayRollList>)payRollList2, Expression.Lambda<Func<PayRollList, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass9_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					}
					DateTime now2 = DateTime.Now;
					DateTime registerDate = now2;
					string registerDatePersian = now2.ToString("yyyyMMdd", new PersianCulture());
					short month = short.Parse(now2.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					_ = Financial.Get().Id;
					int userId = UserLogin.CurrentUser.UserId;
					short year = short.Parse(Financial.Get().Id.ToString());
					_003C_003Ec__DisplayClass9_.payrollList.UserId = userId;
					_003C_003Ec__DisplayClass9_.payrollList.RegisterDate = registerDate;
					_003C_003Ec__DisplayClass9_.payrollList.RegisterDatePersian = registerDatePersian;
					_003C_003Ec__DisplayClass9_.payrollList.Month1 = month;
					_003C_003Ec__DisplayClass9_.payrollList.Year1 = year;
					_003C_003Ec__DisplayClass9_.payrollList.AppType = appType;
					_003C_003Ec__DisplayClass9_.payrollList.PayRollListGroupId = CS_0024_003C_003E8__locals0.model.PayRollListGroupId;
					_003C_003Ec__DisplayClass9_.payrollList.ListYear = CS_0024_003C_003E8__locals0.model.ListYear;
					_003C_003Ec__DisplayClass9_.payrollList.ListMonth = CS_0024_003C_003E8__locals0.model.ListMonth;
					_003C_003Ec__DisplayClass9_.payrollList.ListTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					if (CS_0024_003C_003E8__locals0.model.PayRollListId > 0)
					{
						_dbTbl.Entry(_003C_003Ec__DisplayClass9_.payrollList).State = EntityState.Modified;
						_dbTbl.SaveChanges();
						using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								_003C_003Ec__DisplayClass9_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass9_2();
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass9_;
								CS_0024_003C_003E8__locals1.lang = enumerator.Current;
								DbSet<PayRollList_Lang> payRollList_Lang = _dbTbl.PayRollList_Lang;
								ParameterExpression val = Expression.Parameter(typeof(PayRollList_Lang), "c");
								PayRollList_Lang payRollList_Lang2 = Queryable.FirstOrDefault<PayRollList_Lang>((IQueryable<PayRollList_Lang>)payRollList_Lang, Expression.Lambda<Func<PayRollList_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass9_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass9_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (payRollList_Lang2 != null)
								{
									payRollList_Lang2.ListTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									_dbTbl.Entry(payRollList_Lang2).State = EntityState.Modified;
									_dbTbl.SaveChanges();
									continue;
								}
								payRollList_Lang2 = new PayRollList_Lang
								{
									LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
									PayRollListId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.payrollList.PayRollListId,
									ListTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
								};
								_dbTbl.PayRollList_Lang.Add(payRollList_Lang2);
								_dbTbl.SaveChanges();
							}
						}
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					}
					else
					{
						_003C_003Ec__DisplayClass9_.payrollList.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
						_003C_003Ec__DisplayClass9_.payrollList.FirstRegisterDate = now;
						_003C_003Ec__DisplayClass9_.payrollList.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						_003C_003Ec__DisplayClass9_.payrollList.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
						_003C_003Ec__DisplayClass9_.payrollList.GUId = Guid.NewGuid();
						_dbTbl.PayRollList.Add(_003C_003Ec__DisplayClass9_.payrollList);
						_dbTbl.SaveChanges();
						if (_003C_003Ec__DisplayClass9_.payrollList.PayRollListId > 0)
						{
							foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
							{
								PayRollList_Lang entity = new PayRollList_Lang
								{
									LanguageID = lang.LanguageID,
									PayRollListId = _003C_003Ec__DisplayClass9_.payrollList.PayRollListId,
									ListTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null)
								};
								_dbTbl.PayRollList_Lang.Add(entity);
								_dbTbl.SaveChanges();
							}
						}
						base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					text = Messages.msgErrorRunFunction;
				}
			}
		}
		if (text != "")
		{
			base.ViewBag.Error = text;
		}
		return View(CS_0024_003C_003E8__locals0.model);
	}

	[DynamicAuthorize(ControllerName = "frmPayRollList", ActionName = "actAddUserCycle")]
	public ActionResult AddUserCycle(int payRollListId)
	{
		base.ViewBag.IsBuying = VersionBuyer.PayRoll;
		base.ViewBag.PayRollListId = payRollListId;
		return View();
	}

	[AjaxOnly]
	public JsonResult GetUserCycleListInMonth(string month, string year, string txtSearch)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		PayRollUserCycleListViewModel payRollUserCycleListViewModel = new PayRollUserCycleListViewModel();
		payRollUserCycleListViewModel.PayRollUserCycles = new List<PayRollspSelectUserCycleInMonth_Result>();
		payRollUserCycleListViewModel.IsFind = false;
		txtSearch = (string.IsNullOrWhiteSpace(txtSearch) ? "" : txtSearch);
		try
		{
			if (!string.IsNullOrWhiteSpace(month) && !string.IsNullOrWhiteSpace(year))
			{
				int num = 0;
				int num2 = 0;
				try
				{
					string text = year + "/" + month + "/01";
					DateTime dateTime = default(DateTime);
					string text2 = "";
					text2 = PersianDate.GetFormatetdDate(text.Replace("/", ""));
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text2 + " 00:00:00", new PersianCulture());
						num = int.Parse(dateTime.ToString("MM", new PersianCulture()));
						num2 = int.Parse(dateTime.ToString("yyyy", new PersianCulture()));
						break;
					case 1025:
						dateTime = DateTime.Parse(text2 + " 00:00:00", new CultureInfo("ar-SA"));
						num = int.Parse(dateTime.ToString("MM", new CultureInfo("ar-SA")));
						num2 = int.Parse(dateTime.ToString("yyyy", new CultureInfo("ar-SA")));
						break;
					default:
						dateTime = DateTime.Parse(text2 + " 00:00:00", new CultureInfo("en-US"));
						num = int.Parse(dateTime.ToString("MM", new CultureInfo("en-US")));
						num2 = int.Parse(dateTime.ToString("yyyy", new CultureInfo("en-US")));
						break;
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					payRollUserCycleListViewModel.Message = string.Format(Messages.ErrorInFormat, Labels.PayRollUserCycleListYear + " , " + Labels.PayRollUserCycleListMonth);
				}
				if (!string.IsNullOrWhiteSpace(num2.ToString() + num) && num > 0 && num2 > 0)
				{
					_ = Labels.PayRollItemKindAdditive;
					_ = Labels.PayRollItemKindReduction;
					_ = UserLogin.CurrentUser.UserId;
					payRollUserCycleListViewModel.PayRollUserCycles = Enumerable.ToList<PayRollspSelectUserCycleInMonth_Result>((IEnumerable<PayRollspSelectUserCycleInMonth_Result>)_dbI.PayRollspSelectUserCycleInMonth(num, num2, txtSearch, UserLogin.CurrentUser.UserId, lCID, result));
					if (payRollUserCycleListViewModel.PayRollUserCycles != null && Enumerable.Any<PayRollspSelectUserCycleInMonth_Result>((IEnumerable<PayRollspSelectUserCycleInMonth_Result>)payRollUserCycleListViewModel.PayRollUserCycles))
					{
						payRollUserCycleListViewModel.IsFind = true;
						foreach (PayRollspSelectUserCycleInMonth_Result payRollUserCycle in payRollUserCycleListViewModel.PayRollUserCycles)
						{
							_ = payRollUserCycle.CycleDate;
							payRollUserCycle.CycleDatePersian = payRollUserCycle.CycleDate.ToString("yyyy/MM/dd");
							payRollUserCycle.CycleVerifiedDatePersian = (payRollUserCycle.CycleVerifiedDate.HasValue ? payRollUserCycle.CycleVerifiedDate.Value.ToString("yyyy/MM/dd") : "");
							payRollUserCycle.CycleIsVerified = payRollUserCycle.CycleIsVerified.HasValue && payRollUserCycle.CycleIsVerified != false;
							_ = payRollUserCycle.CycleDate;
							payRollUserCycle.AppType = payRollUserCycle.CycleDate.ToString("yyyy-MM");
						}
					}
					else
					{
						payRollUserCycleListViewModel.PayRollUserCycles = new List<PayRollspSelectUserCycleInMonth_Result>();
						payRollUserCycleListViewModel.Message = Messages.msgErrorPayrollNotRegisteredTheMonth;
					}
				}
				else
				{
					payRollUserCycleListViewModel.Message = string.Format(Messages.ErrorInFormat, Labels.PayRollListYear + " , " + Labels.PayRollListMonth);
				}
			}
			else if (string.IsNullOrWhiteSpace(month))
			{
				payRollUserCycleListViewModel.Message = string.Format(Messages.msgErrorIsNotSelectedItem, Labels.PayRollListMonth);
			}
			else if (string.IsNullOrWhiteSpace(year))
			{
				payRollUserCycleListViewModel.Message = string.Format(Messages.msgErrorIsNotEnteredItem, Labels.PayRollListYear);
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			payRollUserCycleListViewModel.Message = Messages.msgErrorRunFunction + "<br />" + ex.Message;
		}
		JsonResult jsonResult = Json(payRollUserCycleListViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult ActAddUserCycleToList(string month, string year, int payrollListId, string userCycleIds)
	{
		string data = "";
		string text = "";
		CommonResultStatusViewModel status = CommonResultStatusViewModel.Success;
		CommonResultViewModel<string> data2;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
			if (defLangID <= 0)
			{
				defLangID = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (!VersionBuyer.PayRoll)
			{
				data = "";
				text = Messages.VersionBuyModule;
				status = CommonResultStatusViewModel.Error;
				data2 = new CommonResultViewModel<string>
				{
					Data = data,
					Message = text,
					Status = status
				};
				return Json(data2, JsonRequestBehavior.AllowGet);
			}
			if (!UserLogin.IsUserAccess("frmPayRollList", "actAddUserCycle"))
			{
				data = "";
				text = Messages.NotAccessToPage;
				status = CommonResultStatusViewModel.Error;
				data2 = new CommonResultViewModel<string>
				{
					Data = data,
					Message = text,
					Status = status
				};
				return Json(data2, JsonRequestBehavior.AllowGet);
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short value3 = short.Parse(Financial.Get().Id.ToString());
			int userId = UserLogin.CurrentUser.UserId;
			DateTime value4 = default(DateTime);
			string cycleDatePersian = "";
			int num = 0;
			if (payrollListId == 0)
			{
				num++;
				text = text + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.PayRollLists) + "<br>";
			}
			if (!string.IsNullOrWhiteSpace(userCycleIds))
			{
				if (userCycleIds.StartsWith(","))
				{
					userCycleIds = userCycleIds.TrimStart(new char[1] { ',' });
				}
				if (userCycleIds.EndsWith(","))
				{
					userCycleIds = userCycleIds.TrimEnd(new char[1] { ',' });
				}
			}
			if (string.IsNullOrWhiteSpace(userCycleIds))
			{
				num++;
				text = text + Messages.msgErrorNotSelectedItem + "<br>";
			}
			if (string.IsNullOrWhiteSpace(month))
			{
				num++;
				text = text + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.PayRollListMonth) + "<br>";
			}
			if (string.IsNullOrWhiteSpace(year))
			{
				num++;
				text = text + string.Format(Messages.msgErrorIsNotEnteredItem, Labels.PayRollListYear) + "<br>";
			}
			if (!string.IsNullOrWhiteSpace(month) && !string.IsNullOrWhiteSpace(year))
			{
				try
				{
					string text2 = now.ToString("dd");
					switch (lCID)
					{
					case 1065:
						if (int.Parse(month) > 6 && int.Parse(month) <= 12)
						{
							if (int.Parse(text2) == 31)
							{
								text2 = "30";
							}
							if (int.Parse(month) == 12 && (int.Parse(text2) == 31 || int.Parse(text2) == 30))
							{
								text2 = "29";
							}
						}
						break;
					case 1025:
						if (int.Parse(text2) == 31)
						{
							text2 = "30";
						}
						switch (int.Parse(month))
						{
						case 2:
						case 4:
						case 6:
						case 8:
						case 9:
						case 10:
						case 12:
							if (int.Parse(text2) == 30)
							{
								text2 = "29";
							}
							break;
						}
						break;
					default:
						switch (int.Parse(month))
						{
						case 2:
						case 4:
						case 6:
						case 9:
						case 11:
							if (int.Parse(text2) == 31)
							{
								text2 = "30";
							}
							if (int.Parse(month) == 2 && (int.Parse(text2) == 31 || int.Parse(text2) == 30 || int.Parse(text2) == 29))
							{
								text2 = "28";
							}
							break;
						}
						break;
					}
					string text3 = year + "/" + month + "/" + text2;
					DateTime dateTime = default(DateTime);
					string text4 = "";
					text4 = PersianDate.GetFormatetdDate(text3.Replace("/", ""));
					dateTime = lCID switch
					{
						1065 => DateTime.Parse(text4 + " 00:00:00", new PersianCulture()), 
						1025 => DateTime.Parse(text4 + " 00:00:00", new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(text4 + " 00:00:00", new CultureInfo("en-US")), 
					};
					value4 = dateTime;
					cycleDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					num++;
					text = string.Format(Messages.ErrorInFormat, Labels.PayRollUserCycleListYear + " , " + Labels.PayRollUserCycleListMonth);
				}
			}
			if (num == 0)
			{
				int value5 = 0;
				int value6 = 0;
				string payRollListLang = "";
				List<PayRollListLanguageViewModel> list = new List<PayRollListLanguageViewModel>();
				foreach (Languages item in Enumerable.ToList<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get()))
				{
					PayRollListLanguageViewModel payRollListLanguageViewModel = new PayRollListLanguageViewModel();
					payRollListLanguageViewModel.LanguageID = item.LanguageID;
					if (item.LanguageID == 1065)
					{
						payRollListLanguageViewModel.ListMonth = int.Parse(value4.ToString("MM", new PersianCulture()));
						payRollListLanguageViewModel.ListYear = int.Parse(value4.ToString("yyyy", new PersianCulture()));
					}
					else
					{
						payRollListLanguageViewModel.ListMonth = int.Parse(value4.ToString("MM", new CultureInfo(item.LanguageCollation)));
						payRollListLanguageViewModel.ListYear = int.Parse(value4.ToString("yyyy", new CultureInfo(item.LanguageCollation)));
					}
					list.Add(payRollListLanguageViewModel);
				}
				if (list != null && Enumerable.Any<PayRollListLanguageViewModel>((IEnumerable<PayRollListLanguageViewModel>)list))
				{
					value5 = (Enumerable.Any<PayRollListLanguageViewModel>((IEnumerable<PayRollListLanguageViewModel>)list, (Func<PayRollListLanguageViewModel, bool>)((PayRollListLanguageViewModel c) => c.LanguageID == defLangID)) ? Enumerable.FirstOrDefault<PayRollListLanguageViewModel>((IEnumerable<PayRollListLanguageViewModel>)list, (Func<PayRollListLanguageViewModel, bool>)((PayRollListLanguageViewModel c) => c.LanguageID == defLangID)).ListMonth : 0);
					value6 = (Enumerable.Any<PayRollListLanguageViewModel>((IEnumerable<PayRollListLanguageViewModel>)list, (Func<PayRollListLanguageViewModel, bool>)((PayRollListLanguageViewModel c) => c.LanguageID == defLangID)) ? Enumerable.FirstOrDefault<PayRollListLanguageViewModel>((IEnumerable<PayRollListLanguageViewModel>)list, (Func<PayRollListLanguageViewModel, bool>)((PayRollListLanguageViewModel c) => c.LanguageID == defLangID)).ListYear : 0);
					payRollListLang = JsonConvert.SerializeObject(Enumerable.ToList<PayRollListLanguageViewModel>(Enumerable.Where<PayRollListLanguageViewModel>((IEnumerable<PayRollListLanguageViewModel>)list, (Func<PayRollListLanguageViewModel, bool>)((PayRollListLanguageViewModel c) => c.LanguageID != defLangID))));
				}
				mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.PayRollspAddUserCycleToList(payrollListId, value6, value5, userCycleIds, payRollListLang, value4, cycleDatePersian, userId, value2, value3, value, registerDatePersian, appType, defLangID));
				int result = 0;
				if (mct_I_Result != null)
				{
					int.TryParse(mct_I_Result.Result.ToString(), out result);
				}
				if (result <= 0)
				{
					data = "";
					text = Messages.msgErrorRunFunction;
					status = CommonResultStatusViewModel.Error;
				}
				else if (result > 0)
				{
					data = result.ToString();
					text = Messages.msgSuccessAction;
					status = CommonResultStatusViewModel.Success;
				}
			}
			else
			{
				data = "";
				if (string.IsNullOrWhiteSpace(text))
				{
					text = Messages.msgErrorRunFunction;
				}
				status = CommonResultStatusViewModel.Error;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			data = "";
			text = Messages.msgErrorRunFunction + " " + ex.Message;
			status = CommonResultStatusViewModel.Error;
		}
		data2 = new CommonResultViewModel<string>
		{
			Data = data,
			Message = text,
			Status = status
		};
		return Json(data2, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPrintFormat()
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectPrintFormatByTypeId_Result> printFortants = CRMIdeal.Classes.Helper.PrintFormat.GetPrintFortants(result2, 100);
			list.AddRange(Enumerable.Select<CRMspSelectPrintFormatByTypeId_Result, SelectListItem>((IEnumerable<CRMspSelectPrintFormatByTypeId_Result>)printFortants, (Func<CRMspSelectPrintFormatByTypeId_Result, SelectListItem>)((CRMspSelectPrintFormatByTypeId_Result item) => new SelectListItem
			{
				Text = item.Title,
				Value = item.PrintFormatID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PrintFormatList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPayRollLists()
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
			List<PayRollspSelectList_Result> list2 = Enumerable.ToList<PayRollspSelectList_Result>((IEnumerable<PayRollspSelectList_Result>)_dbI.PayRollspSelectList(lCID, result));
			list.AddRange(Enumerable.Select<PayRollspSelectList_Result, SelectListItem>((IEnumerable<PayRollspSelectList_Result>)list2, (Func<PayRollspSelectList_Result, SelectListItem>)delegate(PayRollspSelectList_Result item)
			{
				SelectListItem selectListItem = new SelectListItem();
				string listTitle = item.ListTitle;
				_ = item.ListYear;
				_ = item.ListMonth;
				selectListItem.Text = string.Concat(listTitle, " (" + item.ListYear + "-" + item.ListMonth + ")");
				selectListItem.Value = item.PayRollListId.ToString();
				selectListItem.Selected = false;
				return selectListItem;
			}));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetPayRollListGroup()
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
			List<PayRollspSelectListGroups_Result> list2 = Enumerable.ToList<PayRollspSelectListGroups_Result>((IEnumerable<PayRollspSelectListGroups_Result>)_dbI.PayRollspSelectListGroups(lCID, result));
			list.AddRange(Enumerable.Select<PayRollspSelectListGroups_Result, SelectListItem>((IEnumerable<PayRollspSelectListGroups_Result>)list2, (Func<PayRollspSelectListGroups_Result, SelectListItem>)((PayRollspSelectListGroups_Result item) => new SelectListItem
			{
				Text = item.ListGroupName,
				Value = item.PayRollListGroupId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PayRollListGroup = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPaymentType()
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
			List<PayRollspSelectUserPaymentTypes_Result> list2 = Enumerable.ToList<PayRollspSelectUserPaymentTypes_Result>((IEnumerable<PayRollspSelectUserPaymentTypes_Result>)_db.PayRollspSelectUserPaymentTypes(lCID, result));
			list.AddRange(Enumerable.Select<PayRollspSelectUserPaymentTypes_Result, SelectListItem>((IEnumerable<PayRollspSelectUserPaymentTypes_Result>)list2, (Func<PayRollspSelectUserPaymentTypes_Result, SelectListItem>)((PayRollspSelectUserPaymentTypes_Result item) => new SelectListItem
			{
				Text = item.PaymentType,
				Value = item.PayRollUserPaymentTypeId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PayTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public string ActVerifyPayRoll(int cycleId)
	{
		string text = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmPayRollList", "actVerifyUserCycle", currentUser))
		{
			return Messages.ErrorNotAccess;
		}
		try
		{
			if (cycleId > 0)
			{
				string registerDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
				return (_db.PayRollspUserCycleVerify(cycleId, currentUser.UserId, registerDatePersian) > 0) ? "1" : Messages.msgErrorRunFunction;
			}
			return Messages.msgErrorNotActiveItem;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.msgErrorRunFunction;
		}
	}

	[AjaxOnly]
	public string ActExitFromIsVerifyPayRoll(int cycleId)
	{
		string text = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmPayRollList", "actExitVerifyUserCycle", currentUser))
		{
			return Messages.ErrorNotAccess;
		}
		try
		{
			if (cycleId > 0)
			{
				string registerDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
				return (_db.PayRollspUserCycleVerifyExit(cycleId, currentUser.UserId, registerDatePersian) > 0) ? "1" : Messages.msgErrorRunFunction;
			}
			return Messages.msgErrorNotActiveItem;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.msgErrorRunFunction;
		}
	}

	[AjaxOnly]
	public string DeleteUserCycleAllFromList(int payrollListId)
	{
		string text = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmPayRollList", "actDeleteUserCycleAll", currentUser))
		{
			return Messages.ErrorNotAccess;
		}
		try
		{
			if (payrollListId > 0)
			{
				mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.PayRollspDeleteItemsByListId(payrollListId));
				int result = 0;
				if (mct_I_Result != null)
				{
					int.TryParse(mct_I_Result.Result.ToString(), out result);
				}
				return (result > 0) ? "1" : Messages.msgErrorRunFunction;
			}
			return Messages.msgErrorNotActiveItem;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.msgErrorRunFunction;
		}
	}

	[AjaxOnly]
	public string DeleteListAndItems(int payrollListId)
	{
		string text = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmPayRollList", "actDeleteList", currentUser))
		{
			return Messages.ErrorNotAccess;
		}
		try
		{
			if (payrollListId > 0)
			{
				mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.PayRollspDeleteListAndItems(payrollListId));
				int result = 0;
				if (mct_I_Result != null)
				{
					int.TryParse(mct_I_Result.Result.ToString(), out result);
				}
				return (result > 0) ? "1" : Messages.msgErrorRunFunction;
			}
			return Messages.msgErrorNotActiveItem;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.msgErrorRunFunction;
		}
	}

	[AjaxOnly]
	public string DeleteListItem(int payRollListItemId)
	{
		string text = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmPayRollList", "actDeleteUserCycle", currentUser))
		{
			return Messages.ErrorNotAccess;
		}
		try
		{
			if (payRollListItemId > 0)
			{
				mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.PayRollspDeleteListItem(payRollListItemId));
				int result = 0;
				if (mct_I_Result != null)
				{
					int.TryParse(mct_I_Result.Result.ToString(), out result);
				}
				return (result > 0) ? "1" : Messages.msgErrorRunFunction;
			}
			return Messages.msgErrorNotActiveItem;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.msgErrorRunFunction;
		}
	}

	[AjaxOnly]
	public string DeleteListAndUserCycle(int payrollListId)
	{
		string text = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmPayRollList", "actDeleteListWithUserCycle", currentUser))
		{
			return Messages.ErrorNotAccess;
		}
		try
		{
			if (payrollListId > 0)
			{
				mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.PayRollspDeleteListAndUserCycle(payrollListId));
				int result = 0;
				if (mct_I_Result != null)
				{
					int.TryParse(mct_I_Result.Result.ToString(), out result);
				}
				return (result > 0) ? "1" : Messages.msgErrorRunFunction;
			}
			return Messages.msgErrorNotActiveItem;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.msgErrorRunFunction;
		}
	}

	[AjaxOnly]
	public string VerifyUserCycleAll(int payrollListId)
	{
		string text = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmPayRollList", "actVerifyUserCycleAll", currentUser))
		{
			return Messages.ErrorNotAccess;
		}
		try
		{
			if (payrollListId > 0)
			{
				DateTime now = DateTime.Now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				_dbI.PayRollspUserCycleVerifyByListId(payrollListId, currentUser.UserId, now, registerDatePersian);
				return "1";
			}
			return Messages.msgErrorNotActiveItem;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.msgErrorRunFunction;
		}
	}

	[AjaxOnly]
	public string ExitVerifyUserCycleAll(int payrollListId)
	{
		string text = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmPayRollList", "actExitVerifyUserCycleAll", currentUser))
		{
			return Messages.ErrorNotAccess;
		}
		try
		{
			if (payrollListId > 0)
			{
				_dbI.PayRollspUserCycleVerifyExitByListId(payrollListId);
				return "1";
			}
			return Messages.msgErrorNotActiveItem;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.msgErrorRunFunction;
		}
	}

	[DynamicAuthorize(ControllerName = "frmPayRollList", ActionName = "actInsertUserCyclePayAll")]
	public ActionResult InsertUserCyclePayAll(int payRollListId)
	{
		base.ViewBag.PayRollListId = payRollListId;
		GetPaymentType();
		return View();
	}

	[AjaxOnly]
	public JsonResult ActInsertUserCyclePayAll(string objModel)
	{
		//IL_0374: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		string data = "";
		string text = "";
		CommonResultStatusViewModel status = CommonResultStatusViewModel.Success;
		CommonResultViewModel<string> data2;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
			if (defLangID <= 0)
			{
				defLangID = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (!VersionBuyer.PayRoll)
			{
				data = "";
				text = Messages.VersionBuyModule;
				status = CommonResultStatusViewModel.Error;
				data2 = new CommonResultViewModel<string>
				{
					Data = data,
					Message = text,
					Status = status
				};
				return Json(data2, JsonRequestBehavior.AllowGet);
			}
			if (!UserLogin.IsUserAccess("frmPayRollList", "actInsertUserCyclePayAll"))
			{
				data = "";
				text = Messages.NotAccessToPage;
				status = CommonResultStatusViewModel.Error;
				data2 = new CommonResultViewModel<string>
				{
					Data = data,
					Message = text,
					Status = status
				};
				return Json(data2, JsonRequestBehavior.AllowGet);
			}
			if (!string.IsNullOrWhiteSpace(objModel))
			{
				PayRollListUserPaymentsLanguageViewModel payRollListUserPaymentsLanguageViewModel = new JavaScriptSerializer().Deserialize<PayRollListUserPaymentsLanguageViewModel>(objModel);
				if (payRollListUserPaymentsLanguageViewModel != null)
				{
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					short value3 = short.Parse(Financial.Get().Id.ToString());
					int userId = UserLogin.CurrentUser.UserId;
					int num = 0;
					if (payRollListUserPaymentsLanguageViewModel.PayRollListId == 0)
					{
						num++;
						text = text + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.PayRollLists) + "<br>";
					}
					if (payRollListUserPaymentsLanguageViewModel.PayTypeId == 0)
					{
						num++;
						text = text + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.PayRollListPaymentType) + "<br>";
					}
					if (payRollListUserPaymentsLanguageViewModel.AmountPercent <= 0m)
					{
						num++;
						text = text + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.PayRollListAmountPercent) + "<br>";
					}
					DateTime dateTime = default(DateTime);
					string text2 = "";
					DateTime value4 = default(DateTime);
					if (!string.IsNullOrWhiteSpace(payRollListUserPaymentsLanguageViewModel.PaymentDate))
					{
						try
						{
							text2 = PersianDate.GetFormatetdDate(payRollListUserPaymentsLanguageViewModel.PaymentDate.Replace("/", ""));
							switch (lCID)
							{
							case 1065:
								dateTime = DateTime.Parse(text2 + " 00:00:00", new PersianCulture());
								payRollListUserPaymentsLanguageViewModel.PaymentDate = dateTime.ToString("yyyyMMdd");
								break;
							case 1025:
								dateTime = DateTime.Parse(text2 + " 00:00:00", new CultureInfo("ar-SA"));
								payRollListUserPaymentsLanguageViewModel.PaymentDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							default:
								dateTime = DateTime.Parse(text2 + " 00:00:00", new CultureInfo("en-US"));
								payRollListUserPaymentsLanguageViewModel.PaymentDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							}
							value4 = dateTime;
						}
						catch (Exception e)
						{
							ErrorSignal.FromCurrentContext().Raise(e);
							num++;
							text = text + string.Format(Messages.ErrorInFormat, Labels.PayRollListPaymentDate) + "<br>";
						}
					}
					else
					{
						num++;
						text = text + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.PayRollListPaymentDate) + "<br>";
					}
					if (num == 0)
					{
						string description = "";
						string descriptionLang = "";
						List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
						if (!string.IsNullOrEmpty(payRollListUserPaymentsLanguageViewModel.Description_Lang))
						{
							list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(payRollListUserPaymentsLanguageViewModel.Description_Lang);
						}
						list.Add(new CommonMultiLanguageViewModel
						{
							Value = payRollListUserPaymentsLanguageViewModel.Description,
							LanguageId = lCID
						});
						if (list != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list))
						{
							description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : "");
							descriptionLang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID))));
						}
						mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.PayRollspInsertUserPaymentsByListId(payRollListUserPaymentsLanguageViewModel.PayRollListId, value4, payRollListUserPaymentsLanguageViewModel.PaymentDate, payRollListUserPaymentsLanguageViewModel.PayTypeId, payRollListUserPaymentsLanguageViewModel.AmountPercent, payRollListUserPaymentsLanguageViewModel.PaymentNumber, description, descriptionLang, payRollListUserPaymentsLanguageViewModel.BankingAccountType, userId, value2, value3, value, registerDatePersian, appType, defLangID));
						int result = 0;
						if (mct_I_Result != null)
						{
							int.TryParse(mct_I_Result.Result.ToString(), out result);
						}
						if (result <= 0)
						{
							data = "";
							text = Messages.msgErrorRunFunction;
							status = CommonResultStatusViewModel.Error;
						}
						else if (result > 0)
						{
							PushNotif.NewPayRollUserPaymentNotify();
							data = result.ToString();
							text = Messages.msgSuccessAction;
							status = CommonResultStatusViewModel.Success;
						}
					}
					else
					{
						data = "";
						if (string.IsNullOrWhiteSpace(text))
						{
							text = Messages.msgErrorRunFunction;
						}
						status = CommonResultStatusViewModel.Error;
					}
				}
				else
				{
					data = "";
					text = Messages.msgErrorRunFunction;
					status = CommonResultStatusViewModel.Error;
				}
			}
			else
			{
				data = "";
				text = Messages.msgErrorRunFunction;
				status = CommonResultStatusViewModel.Error;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			data = "";
			text = Messages.msgErrorRunFunction + " " + ex.Message;
			status = CommonResultStatusViewModel.Error;
		}
		data2 = new CommonResultViewModel<string>
		{
			Data = data,
			Message = text,
			Status = status
		};
		return Json(data2, JsonRequestBehavior.AllowGet);
	}

	public string GetMontName(string month)
	{
		string result = "";
		try
		{
			if (!string.IsNullOrWhiteSpace(month))
			{
				if (month != null)
				{
					int length = month.Length;
					if (length == 2)
					{
						switch (month[1])
						{
						case '1':
							if (!(month == "01"))
							{
								if (month == "11")
								{
									result = Labels.EleventhMonth;
								}
							}
							else
							{
								result = Labels.FirstMonth;
							}
							break;
						case '2':
							if (!(month == "02"))
							{
								if (month == "12")
								{
									result = Labels.TwelfthMonth;
								}
							}
							else
							{
								result = Labels.SecondMonth;
							}
							break;
						case '3':
							if (month == "03")
							{
								result = Labels.ThirdMonth;
							}
							break;
						case '4':
							if (month == "04")
							{
								result = Labels.FourthMonth;
							}
							break;
						case '5':
							if (month == "05")
							{
								result = Labels.FifthMonth;
							}
							break;
						case '6':
							if (month == "06")
							{
								result = Labels.SixthMonth;
							}
							break;
						case '7':
							if (month == "07")
							{
								result = Labels.SeventhMonth;
							}
							break;
						case '8':
							if (month == "08")
							{
								result = Labels.EighthMonth;
							}
							break;
						case '9':
							if (month == "09")
							{
								result = Labels.NinthMonth;
							}
							break;
						case '0':
							if (month == "10")
							{
								result = Labels.TenthMonth;
							}
							break;
						}
					}
				}
			}
			else
			{
				result = "";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = "";
		}
		return result;
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
		base.Dispose(disposing);
	}
}

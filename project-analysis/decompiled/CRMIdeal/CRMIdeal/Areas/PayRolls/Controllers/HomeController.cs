using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
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
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.PayRolls.Controllers;

public class HomeController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public int id;

		public int currLangID;

		internal bool _003CInsertEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public PayRollUserCycleLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__6;

		public Func<Languages, bool> _003C_003E9__12;

		internal bool _003CInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__6(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__12(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_1
	{
		public PayRollUserCycle model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass9_1 CS_0024_003C_003E8__locals1;

		internal bool _003CInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actPayRollUserCycle")]
	public ActionResult Index()
	{
		GetUsers();
		return View();
	}

	[AjaxOnly]
	public JsonResult GetUsers()
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
			List<CRMspSelectUserForLinkedType_Result> list2 = Enumerable.ToList<CRMspSelectUserForLinkedType_Result>(Enumerable.Where<CRMspSelectUserForLinkedType_Result>((IEnumerable<CRMspSelectUserForLinkedType_Result>)_db.CRMspSelectUserForLinkedType(UserLogin.CurrentUser.UserId, 22, lCID, result, result2), (Func<CRMspSelectUserForLinkedType_Result, bool>)((CRMspSelectUserForLinkedType_Result m) => m.LinkedUserId > 0)));
			list.Add(new SelectListItem
			{
				Text = Labels.All,
				Value = "-1",
				Selected = false
			});
			list.AddRange(Enumerable.Select<CRMspSelectUserForLinkedType_Result, SelectListItem>((IEnumerable<CRMspSelectUserForLinkedType_Result>)list2, (Func<CRMspSelectUserForLinkedType_Result, SelectListItem>)((CRMspSelectUserForLinkedType_Result item) => new SelectListItem
			{
				Text = (item.UserName ?? ""),
				Value = item.LinkedUserId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.UserList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult PayRollUserCycle_Read([DataSourceRequest] DataSourceRequest request, int crmUserId, string fromDate, string toDate)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<PayRollspSelectUserCycle_Result> list = new List<PayRollspSelectUserCycle_Result>();
		try
		{
			DateTime value = DateTime.Now;
			DateTime value2 = DateTime.Now;
			if (!string.IsNullOrEmpty(fromDate))
			{
				fromDate = fromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				value = lCID switch
				{
					1065 => DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00"), 
					1025 => DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None), 
					_ => DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None), 
				};
			}
			if (!string.IsNullOrEmpty(toDate))
			{
				toDate = toDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				value2 = lCID switch
				{
					1065 => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59"), 
					1025 => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59", new CultureInfo("ar-SA"), DateTimeStyles.None), 
					_ => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None), 
				};
			}
			list = Enumerable.ToList<PayRollspSelectUserCycle_Result>((IEnumerable<PayRollspSelectUserCycle_Result>)_db.PayRollspSelectUserCycle(crmUserId, 0, UserLogin.CurrentUser.UserId, value, value2, lCID, result));
			foreach (PayRollspSelectUserCycle_Result item in list)
			{
				_ = item.CycleDate;
				item.CycleDatePersian = item.CycleDate.ToString("yyyy/MM/dd");
				item.CycleIsVerified = item.CycleIsVerified.HasValue && item.CycleIsVerified != false;
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

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmPayRollUserCycle", ActionName = "actDelete")]
	public string ActDelete(int cycleId)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			PayRollspSelectUserCycle_Result payRollspSelectUserCycle_Result = Enumerable.FirstOrDefault<PayRollspSelectUserCycle_Result>((IEnumerable<PayRollspSelectUserCycle_Result>)_db.PayRollspSelectUserCycle(0, cycleId, 0, null, null, lCID, result2));
			if (payRollspSelectUserCycle_Result != null)
			{
				try
				{
					if (payRollspSelectUserCycle_Result.CycleIsVerified.GetValueOrDefault())
					{
						result = Messages.msgErrorNotActivePayRollUserCycle;
					}
					else
					{
						mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.PayRollspDeleteUserCycle(cycleId));
						if (mct_Result != null && mct_Result.Result > 0)
						{
							result = "";
						}
						else if (mct_Result != null && mct_Result.Result == 0)
						{
							result = Messages.RedundancyMessage;
						}
					}
				}
				catch (DbEntityValidationException e)
				{
					ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
					result = Messages.RedundancyMessage;
				}
				catch (Exception ex)
				{
					ErrorSignal.FromCurrentContext().Raise(ex);
					result = Messages.msgErrorCommunicateWithServer + "<br><p style=text-align:left;>" + ex.Message + "</p>";
				}
			}
			else
			{
				result = Messages.ErrorNotFound;
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	public void SetRegisterInfo(PayRollUserCycleLanguageViewModel model, ref string firstRegInfo, ref string regInfo)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			if (model == null)
			{
				return;
			}
			List<CRMspSelectUsersByIds_Result> list = CRMIdeal.Classes.Helper.User.SelectUsersByIds(model.FirstRegisterUserId + "," + model.UserId);
			if (list == null || !Enumerable.Any<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list))
			{
				return;
			}
			CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.FirstRegisterUserId));
			if (cRMspSelectUsersByIds_Result != null)
			{
				firstRegInfo = ((!string.IsNullOrEmpty(cRMspSelectUsersByIds_Result.LName)) ? cRMspSelectUsersByIds_Result.LName : "") + ((!string.IsNullOrEmpty(cRMspSelectUsersByIds_Result.FName)) ? (" " + cRMspSelectUsersByIds_Result.FName) : "");
				_ = model.FirstRegisterDate;
				string text = model.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				firstRegInfo += ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			}
			CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result2 = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.UserId));
			if (cRMspSelectUsersByIds_Result2 != null)
			{
				regInfo = ((!string.IsNullOrEmpty(cRMspSelectUsersByIds_Result2.LName)) ? cRMspSelectUsersByIds_Result2.LName : "") + ((!string.IsNullOrEmpty(cRMspSelectUsersByIds_Result2.FName)) ? (" " + cRMspSelectUsersByIds_Result2.FName) : "");
				_ = model.RegisterDate;
				string text2 = model.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				if (string.IsNullOrEmpty(model.AppType))
				{
					model.AppType = Configuration.AppType;
				}
				string text3 = Labels.AppType + ": " + Configuration.GetAppType(model.AppType);
				regInfo = regInfo + " (" + text3 + ")" + ((!string.IsNullOrEmpty(text2)) ? (" (" + text2 + ")") : "");
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	[DynamicAuthorize(ControllerName = "frmPayRollUserCycle", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(int crmUserId, int id = 0)
	{
		_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass8_0();
		CS_0024_003C_003E8__locals0.id = id;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		PayRollUserCycleLanguageViewModel payRollUserCycleLanguageViewModel = new PayRollUserCycleLanguageViewModel();
		if (CS_0024_003C_003E8__locals0.id > 0)
		{
			if (!UserLogin.IsUserAccess("frmPayRollUserCycle", "actEdit"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			DbSet<PayRollUserCycle_Lang> payRollUserCycle_Lang = _dbTbl.PayRollUserCycle_Lang;
			ParameterExpression val = Expression.Parameter(typeof(PayRollUserCycle_Lang), "c");
			List<PayRollUserCycle_Lang> list = Enumerable.ToList<PayRollUserCycle_Lang>((IEnumerable<PayRollUserCycle_Lang>)Queryable.Where<PayRollUserCycle_Lang>((IQueryable<PayRollUserCycle_Lang>)payRollUserCycle_Lang, Expression.Lambda<Func<PayRollUserCycle_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			DbSet<PayRollUserCycle> payRollUserCycle = _dbTbl.PayRollUserCycle;
			val = Expression.Parameter(typeof(PayRollUserCycle), "c");
			PayRollUserCycle payRollUserCycle2 = Queryable.FirstOrDefault<PayRollUserCycle>((IQueryable<PayRollUserCycle>)payRollUserCycle, Expression.Lambda<Func<PayRollUserCycle, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (payRollUserCycle2 == null)
			{
				base.ViewBag.Error = Messages.ErrorNotFound;
				return null;
			}
			if (payRollUserCycle2.CycleIsVerified.HasValue && payRollUserCycle2.CycleIsVerified.GetValueOrDefault())
			{
				base.ViewBag.Error = Messages.msgErrorNotActivePayRollUserCycle;
				return null;
			}
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<PayRollUserCycle_Lang, CommonMultiLanguageViewModel>((IEnumerable<PayRollUserCycle_Lang>)list, (Func<PayRollUserCycle_Lang, CommonMultiLanguageViewModel>)((PayRollUserCycle_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.CycleTitle,
				LanguageId = item.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = payRollUserCycle2.CycleTitle,
				LanguageId = result
			});
			PayRollUserCycleLanguageViewModel obj = new PayRollUserCycleLanguageViewModel
			{
				PayRollUserCycleId = payRollUserCycle2.PayRollUserCycleId,
				CrmUserId = payRollUserCycle2.CrmUserId,
				CycleTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				CycleTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				CycleDuration = payRollUserCycle2.CycleDuration,
				CycleDate = payRollUserCycle2.CycleDate
			};
			_ = payRollUserCycle2.CycleDate;
			obj.CycleDatePersian = payRollUserCycle2.CycleDate.ToString("yyyy/MM/dd");
			obj.CycleIsVerified = payRollUserCycle2.CycleIsVerified;
			obj.CycleVerifierUserId = payRollUserCycle2.CycleVerifierUserId;
			obj.CycleVerifiedDate = payRollUserCycle2.CycleVerifiedDate;
			obj.CycleVerifiedDatePersian = payRollUserCycle2.CycleVerifiedDatePersian;
			obj.CyclePrintFormatId = payRollUserCycle2.CyclePrintFormatId;
			obj.FirstRegisterUserId = payRollUserCycle2.FirstRegisterUserId;
			obj.FirstRegisterDate = payRollUserCycle2.FirstRegisterDate;
			obj.FirstRegisterDatePersian = payRollUserCycle2.FirstRegisterDatePersian;
			obj.UserId = payRollUserCycle2.UserId;
			obj.RegisterDate = payRollUserCycle2.RegisterDate;
			obj.RegisterDatePersian = payRollUserCycle2.RegisterDatePersian;
			obj.Year1 = payRollUserCycle2.Year1;
			obj.Month1 = payRollUserCycle2.Month1;
			obj.GUId = payRollUserCycle2.GUId;
			obj.AppType = payRollUserCycle2.AppType;
			obj.LanguageID = payRollUserCycle2.LanguageID;
			obj.CycleDefBankingAccountId = payRollUserCycle2.CycleDefBankingAccountId;
			obj.CycleMonth = payRollUserCycle2.CycleMonth;
			obj.CycleYear = payRollUserCycle2.CycleYear;
			obj.CycleNetSalary = payRollUserCycle2.CycleNetSalary;
			payRollUserCycleLanguageViewModel = obj;
		}
		else
		{
			if (!UserLogin.IsUserAccess("frmPayRollUserCycle", "actInsert"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			DateTime now = DateTime.Now;
			payRollUserCycleLanguageViewModel = new PayRollUserCycleLanguageViewModel
			{
				CrmUserId = crmUserId,
				CycleDate = now,
				CycleDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
				CycleVerifiedDate = now,
				CycleVerifiedDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
				FirstRegisterUserId = UserLogin.CurrentUser.UserId,
				FirstRegisterDate = now,
				FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
				UserId = UserLogin.CurrentUser.UserId,
				RegisterDate = now,
				RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture())
			};
			base.ViewBag.IsBuying = VersionBuyer.PayRoll;
		}
		GetPrintFormat();
		string firstRegInfo = "";
		string regInfo = "";
		SetRegisterInfo(payRollUserCycleLanguageViewModel, ref firstRegInfo, ref regInfo);
		payRollUserCycleLanguageViewModel.FirstRegisterUser = firstRegInfo;
		payRollUserCycleLanguageViewModel.EditUser = regInfo;
		return View(payRollUserCycleLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmPayRollUserCycleDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult InsertEdit(PayRollUserCycleLanguageViewModel vm)
	{
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass9_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.CycleTitle_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.CycleTitle_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.CycleTitle,
			LanguageId = lCID
		});
		GetPrintFormat();
		try
		{
			if (CS_0024_003C_003E8__locals0.vm.PayRollUserCycleId <= 0 && !VersionBuyer.PayRoll)
			{
				DbSet<PayRollUserCycle> payRollUserCycle = _dbTbl.PayRollUserCycle;
				ParameterExpression val = Expression.Parameter(typeof(PayRollUserCycle), "c");
				if (Queryable.Any<PayRollUserCycle>((IQueryable<PayRollUserCycle>)payRollUserCycle, Expression.Lambda<Func<PayRollUserCycle, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)2, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val })))
				{
					base.ViewBag.Error = "BV|" + Messages.VersionBuyPayRoll;
					return View(CS_0024_003C_003E8__locals0.vm);
				}
			}
			DateTime dateTime = default(DateTime);
			string text = "";
			try
			{
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.CycleDatePersian))
				{
					text = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.vm.CycleDatePersian.Replace("/", ""));
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
						CS_0024_003C_003E8__locals0.vm.CycleDatePersian = dateTime.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
						CS_0024_003C_003E8__locals0.vm.CycleDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
						CS_0024_003C_003E8__locals0.vm.CycleDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
					CS_0024_003C_003E8__locals0.vm.CycleDate = dateTime;
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				base.ViewBag.Error = Messages.WrongDateTime;
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			if (CS_0024_003C_003E8__locals0.vm.CycleDatePersian != null)
			{
				CS_0024_003C_003E8__locals0.vm.CycleDatePersian = CS_0024_003C_003E8__locals0.vm.CycleDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
			}
			string text2 = "";
			if (CS_0024_003C_003E8__locals0.vm.CycleTitle == null && CS_0024_003C_003E8__locals0.vm.CycleTitle == "")
			{
				text2 = text2 + string.Format(Messages.ErrorEmpty, Labels.PayRollUserCycleTitle) + "<br/>";
			}
			else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.CycleTitle, list))
			{
				text2 = text2 + string.Format(Messages.CheckFieldInLang, Labels.PayRollUserCycleTitle) + "<br>";
			}
			if (text2 != "")
			{
				base.ViewBag.Error = text2;
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			if (!base.ModelState.IsValid)
			{
				base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
			else
			{
				_003C_003Ec__DisplayClass9_1 _003C_003Ec__DisplayClass9_ = new _003C_003Ec__DisplayClass9_1();
				DateTime now = DateTime.Now;
				DateTime dateTime2 = now;
				string text3 = now.ToString("yyyyMMdd", new PersianCulture());
				short num = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short num2 = short.Parse(Financial.Get().Id.ToString());
				int userId = UserLogin.CurrentUser.UserId;
				_003C_003Ec__DisplayClass9_.model = new PayRollUserCycle();
				if (CS_0024_003C_003E8__locals0.vm.PayRollUserCycleId > 0)
				{
					DbSet<PayRollUserCycle> payRollUserCycle2 = _dbTbl.PayRollUserCycle;
					ParameterExpression val = Expression.Parameter(typeof(PayRollUserCycle), "c");
					_003C_003Ec__DisplayClass9_.model = Queryable.FirstOrDefault<PayRollUserCycle>((IQueryable<PayRollUserCycle>)payRollUserCycle2, Expression.Lambda<Func<PayRollUserCycle, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass9_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				_003C_003Ec__DisplayClass9_.model.CrmUserId = CS_0024_003C_003E8__locals0.vm.CrmUserId;
				_003C_003Ec__DisplayClass9_.model.CycleTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass9_.model.CycleDuration = CS_0024_003C_003E8__locals0.vm.CycleDuration;
				_003C_003Ec__DisplayClass9_.model.CycleDate = CS_0024_003C_003E8__locals0.vm.CycleDate;
				_003C_003Ec__DisplayClass9_.model.CycleDatePersian = CS_0024_003C_003E8__locals0.vm.CycleDatePersian;
				_003C_003Ec__DisplayClass9_.model.CyclePrintFormatId = CS_0024_003C_003E8__locals0.vm.CyclePrintFormatId;
				_003C_003Ec__DisplayClass9_.model.UserId = userId;
				_003C_003Ec__DisplayClass9_.model.Year1 = num2;
				_003C_003Ec__DisplayClass9_.model.Month1 = num;
				_003C_003Ec__DisplayClass9_.model.RegisterDate = dateTime2;
				_003C_003Ec__DisplayClass9_.model.RegisterDatePersian = text3;
				_003C_003Ec__DisplayClass9_.model.AppType = appType;
				_003C_003Ec__DisplayClass9_.model.CycleDefBankingAccountId = CS_0024_003C_003E8__locals0.vm.CycleDefBankingAccountId;
				_003C_003Ec__DisplayClass9_.model.CycleMonth = int.Parse(_003C_003Ec__DisplayClass9_.model.CycleDate.ToString("MM", new PersianCulture()));
				_003C_003Ec__DisplayClass9_.model.CycleYear = int.Parse(_003C_003Ec__DisplayClass9_.model.CycleDate.ToString("yyyy", new PersianCulture()));
				if (_003C_003Ec__DisplayClass9_.model.PayRollUserCycleId > 0)
				{
					if (_003C_003Ec__DisplayClass9_.model.CycleIsVerified.GetValueOrDefault())
					{
						base.ViewBag.Error = Messages.msgErrorNotActivePayRollUserCycle;
						return View(CS_0024_003C_003E8__locals0.vm);
					}
					_dbTbl.Entry(_003C_003Ec__DisplayClass9_.model).State = EntityState.Modified;
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass9_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass9_2();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass9_;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							DbSet<PayRollUserCycle_Lang> payRollUserCycle_Lang = _dbTbl.PayRollUserCycle_Lang;
							ParameterExpression val = Expression.Parameter(typeof(PayRollUserCycle_Lang), "c");
							PayRollUserCycle_Lang payRollUserCycle_Lang2 = Queryable.FirstOrDefault<PayRollUserCycle_Lang>((IQueryable<PayRollUserCycle_Lang>)payRollUserCycle_Lang, Expression.Lambda<Func<PayRollUserCycle_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass9_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass9_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (payRollUserCycle_Lang2 != null)
							{
								payRollUserCycle_Lang2.CycleTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								payRollUserCycle_Lang2.CycleMonth = int.Parse(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.CycleDate.ToString("MM", new CultureInfo(CS_0024_003C_003E8__locals1.lang.LanguageCollation)));
								payRollUserCycle_Lang2.CycleYear = int.Parse(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.CycleDate.ToString("yyyy", new CultureInfo(CS_0024_003C_003E8__locals1.lang.LanguageCollation)));
								_dbTbl.Entry(payRollUserCycle_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							payRollUserCycle_Lang2 = new PayRollUserCycle_Lang();
							payRollUserCycle_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
							payRollUserCycle_Lang2.PayRollUserCycleId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.PayRollUserCycleId;
							payRollUserCycle_Lang2.CycleTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							payRollUserCycle_Lang2.CycleMonth = int.Parse(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.CycleDate.ToString("MM", new CultureInfo(CS_0024_003C_003E8__locals1.lang.LanguageCollation)));
							payRollUserCycle_Lang2.CycleYear = int.Parse(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.CycleDate.ToString("yyyy", new CultureInfo(CS_0024_003C_003E8__locals1.lang.LanguageCollation)));
							_dbTbl.PayRollUserCycle_Lang.Add(payRollUserCycle_Lang2);
							_dbTbl.SaveChanges();
						}
					}
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
				else
				{
					_003C_003Ec__DisplayClass9_.model.FirstRegisterUserId = userId;
					_003C_003Ec__DisplayClass9_.model.FirstRegisterDate = dateTime2;
					_003C_003Ec__DisplayClass9_.model.FirstRegisterDatePersian = text3;
					_003C_003Ec__DisplayClass9_.model.GUId = Guid.NewGuid();
					_003C_003Ec__DisplayClass9_.model.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
					_dbTbl.PayRollUserCycle.Add(_003C_003Ec__DisplayClass9_.model);
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					if (_003C_003Ec__DisplayClass9_.model.PayRollUserCycleId <= 0)
					{
						base.ViewBag.Error = Messages.msgErrorRunFunction;
					}
					else
					{
						foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
						{
							PayRollUserCycle_Lang payRollUserCycle_Lang3 = new PayRollUserCycle_Lang();
							payRollUserCycle_Lang3.LanguageID = lang.LanguageID;
							payRollUserCycle_Lang3.PayRollUserCycleId = _003C_003Ec__DisplayClass9_.model.PayRollUserCycleId;
							payRollUserCycle_Lang3.CycleTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
							payRollUserCycle_Lang3.CycleMonth = int.Parse(_003C_003Ec__DisplayClass9_.model.CycleDate.ToString("MM", new CultureInfo(lang.LanguageCollation)));
							payRollUserCycle_Lang3.CycleYear = int.Parse(_003C_003Ec__DisplayClass9_.model.CycleDate.ToString("yyyy", new CultureInfo(lang.LanguageCollation)));
							_dbTbl.PayRollUserCycle_Lang.Add(payRollUserCycle_Lang3);
							_dbTbl.SaveChanges();
						}
						_db.PayRollspInsertDefaultItemsToUserCycleItems(_003C_003Ec__DisplayClass9_.model.PayRollUserCycleId, _003C_003Ec__DisplayClass9_.model.CrmUserId, userId, dateTime2, text3, num2, num, appType, CS_0024_003C_003E8__locals0.defLangID);
						base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
					}
				}
				string firstRegInfo = "";
				string regInfo = "";
				CS_0024_003C_003E8__locals0.vm.FirstRegisterUserId = _003C_003Ec__DisplayClass9_.model.FirstRegisterUserId;
				CS_0024_003C_003E8__locals0.vm.UserId = userId;
				CS_0024_003C_003E8__locals0.vm.FirstRegisterDate = _003C_003Ec__DisplayClass9_.model.FirstRegisterDate;
				CS_0024_003C_003E8__locals0.vm.RegisterDate = dateTime2;
				CS_0024_003C_003E8__locals0.vm.FirstRegisterDatePersian = _003C_003Ec__DisplayClass9_.model.FirstRegisterDatePersian;
				CS_0024_003C_003E8__locals0.vm.RegisterDatePersian = text3;
				CS_0024_003C_003E8__locals0.vm.AppType = appType;
				SetRegisterInfo(CS_0024_003C_003E8__locals0.vm, ref firstRegInfo, ref regInfo);
				CS_0024_003C_003E8__locals0.vm.FirstRegisterUser = firstRegInfo;
				CS_0024_003C_003E8__locals0.vm.EditUser = regInfo;
			}
		}
		catch (DbEntityValidationException e2)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e2);
			base.ViewBag.Error = Messages.msgErrorRunFunction;
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
			base.ViewBag.Error = Messages.msgErrorRunFunction;
		}
		return View(CS_0024_003C_003E8__locals0.vm);
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

	[LoginAuthorize]
	public ActionResult Preview(int cycleId = 0, int position = 0)
	{
		string text = "";
		string text2 = "";
		base.ViewBag.MainPostion = position;
		switch (position)
		{
		case 0:
			text = "frmPayRollUserCycle";
			text2 = "actShowPayRollCycle";
			break;
		case 1:
			text = "frmPayRollList";
			text2 = "actShowUserCycleDetails";
			break;
		case 2:
			text = "FramUserCommission";
			text2 = "actGoToPayRollUserCycle";
			break;
		default:
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		if (!UserLogin.IsUserAccess(text, text2, UserLogin.CurrentUser))
		{
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		base.ViewBag.CycleId = cycleId;
		return View();
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmPayRollUserCycle", ActionName = "actShowPayRollCycle")]
	public JsonResult GetPayRollCycleUser(int cycleId, int position = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CurrentPayRollUserCycleViewModel currentPayRollUserCycleViewModel = new CurrentPayRollUserCycleViewModel();
		currentPayRollUserCycleViewModel.CycleFinalAmount = new PayRollspReturnUserCycleFinalAmount_Result();
		try
		{
			PayRollspSelectUserCycle_Result payRollspSelectUserCycle_Result = Enumerable.FirstOrDefault<PayRollspSelectUserCycle_Result>((IEnumerable<PayRollspSelectUserCycle_Result>)_db.PayRollspSelectUserCycle(0, cycleId, UserLogin.CurrentUser.UserId, null, null, lCID, result));
			if (payRollspSelectUserCycle_Result != null)
			{
				if (position == 0 && !UserLogin.IsUserAccess("frmPayRollUserCycle", "actCanShowPayRollCycleNotVerify", UserLogin.CurrentUser) && !payRollspSelectUserCycle_Result.CycleIsVerified.GetValueOrDefault())
				{
					currentPayRollUserCycleViewModel.IsFind = false;
					currentPayRollUserCycleViewModel.Message = Messages.msgErrorNotShowPayRollCycleNotVerify;
					currentPayRollUserCycleViewModel.PayRoll = null;
					currentPayRollUserCycleViewModel.PayRollCurrentId = -1;
					JsonResult jsonResult = Json(currentPayRollUserCycleViewModel, JsonRequestBehavior.AllowGet);
					jsonResult.MaxJsonLength = int.MaxValue;
					return jsonResult;
				}
				currentPayRollUserCycleViewModel.IsFind = true;
				currentPayRollUserCycleViewModel.Message = "";
				currentPayRollUserCycleViewModel.PayRollCurrentId = payRollspSelectUserCycle_Result.PayRollUserCycleId;
				_ = payRollspSelectUserCycle_Result.CycleDate;
				payRollspSelectUserCycle_Result.CycleDatePersian = payRollspSelectUserCycle_Result.CycleDate.ToString("yyyy/MM/dd");
				payRollspSelectUserCycle_Result.CycleVerifiedDatePersian = (payRollspSelectUserCycle_Result.CycleVerifiedDate.HasValue ? payRollspSelectUserCycle_Result.CycleVerifiedDate.Value.ToString("yyyy/MM/dd") : null);
				_ = payRollspSelectUserCycle_Result.FirstRegisterDate;
				payRollspSelectUserCycle_Result.FirstRegisterDatePersian = payRollspSelectUserCycle_Result.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				_ = payRollspSelectUserCycle_Result.RegisterDate;
				payRollspSelectUserCycle_Result.RegisterDatePersian = payRollspSelectUserCycle_Result.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				if (string.IsNullOrEmpty(payRollspSelectUserCycle_Result.AppType))
				{
					payRollspSelectUserCycle_Result.AppType = Configuration.AppType;
				}
				payRollspSelectUserCycle_Result.AppType = Configuration.GetAppType(payRollspSelectUserCycle_Result.AppType);
				currentPayRollUserCycleViewModel.PayRoll = payRollspSelectUserCycle_Result;
				currentPayRollUserCycleViewModel.CycleFinalAmount = Enumerable.FirstOrDefault<PayRollspReturnUserCycleFinalAmount_Result>((IEnumerable<PayRollspReturnUserCycleFinalAmount_Result>)_db.PayRollspReturnUserCycleFinalAmount(cycleId));
			}
			else
			{
				currentPayRollUserCycleViewModel.IsFind = false;
				currentPayRollUserCycleViewModel.Message = Messages.ErrorNotFound;
				currentPayRollUserCycleViewModel.PayRoll = null;
				currentPayRollUserCycleViewModel.PayRollCurrentId = -1;
			}
		}
		catch (DbEntityValidationException ex)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
			currentPayRollUserCycleViewModel.IsFind = false;
			currentPayRollUserCycleViewModel.Message = Messages.frmErrorMessage + "<br />" + ((Exception)(object)ex).Message;
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			currentPayRollUserCycleViewModel.IsFind = false;
			currentPayRollUserCycleViewModel.Message = Messages.frmErrorMessage + "<br />" + ex2.Message;
		}
		JsonResult jsonResult2 = Json(currentPayRollUserCycleViewModel, JsonRequestBehavior.AllowGet);
		jsonResult2.MaxJsonLength = int.MaxValue;
		return jsonResult2;
	}

	public List<PayRollspSelectUserCycleItemValues_Result> GetPayRollCycleItemValues(int cycleId, int kind)
	{
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		List<PayRollspSelectUserCycleItemValues_Result> list = new List<PayRollspSelectUserCycleItemValues_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
			list = Enumerable.ToList<PayRollspSelectUserCycleItemValues_Result>((IEnumerable<PayRollspSelectUserCycleItemValues_Result>)_db.PayRollspSelectUserCycleItemValues(cycleId, kind, currLangID, result));
			if (list != null && Enumerable.Any<PayRollspSelectUserCycleItemValues_Result>((IEnumerable<PayRollspSelectUserCycleItemValues_Result>)list))
			{
				foreach (PayRollspSelectUserCycleItemValues_Result item in list)
				{
					List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrWhiteSpace(item.ItemValueDesc_Lang))
					{
						list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(item.ItemValueDesc_Lang);
						if (list2 == null)
						{
							list2 = new List<CommonMultiLanguageViewModel>();
						}
					}
					if (!string.IsNullOrWhiteSpace(item.ItemValueDesc))
					{
						list2.Add(new CommonMultiLanguageViewModel
						{
							Value = item.ItemValueDesc,
							LanguageId = result
						});
					}
					if (list2 != null)
					{
						item.ItemValueDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
					}
				}
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return list;
	}

	[AjaxOnly]
	public JsonResult LoadPayRollCycleItemValues(int cycleId, int kind)
	{
		List<PayRollspSelectUserCycleItemValues_Result> data = new List<PayRollspSelectUserCycleItemValues_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			data = GetPayRollCycleItemValues(cycleId, kind);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	public ActionResult Payments_Read([DataSourceRequest] DataSourceRequest request, int cycleId)
	{
		List<PayRollspSelectUserPayments_Result> list = new List<PayRollspSelectUserPayments_Result>();
		try
		{
			list = GetPayments(cycleId);
			foreach (PayRollspSelectUserPayments_Result item in list)
			{
				item.PaymentDatePersian = (item.PaymentDate.HasValue ? item.PaymentDate.Value.ToString("yyyyMMdd") : item.PaymentDatePersian);
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		JsonResult jsonResult = Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<PayRollspSelectUserPayments_Result> GetPayments(int cycleId)
	{
		List<PayRollspSelectUserPayments_Result> result = new List<PayRollspSelectUserPayments_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			result = Enumerable.ToList<PayRollspSelectUserPayments_Result>((IEnumerable<PayRollspSelectUserPayments_Result>)_db.PayRollspSelectUserPayments(cycleId, lCID, result2));
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return result;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmPayRollUserCycleDetails", ActionName = "actIncDelete,actDecDelete")]
	public JsonResult ActDeleteItemValue(int itemValueId, int cycleId)
	{
		string data = "";
		try
		{
			if (PayRoll.IsVerify(cycleId))
			{
				data = Messages.msgErrorNotActivePayRollUserCycle;
			}
			else
			{
				_db.PayRollspDeleteUserCycleItemValue(itemValueId);
				data = "ok";
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmPayRollUserCycleDetails", ActionName = "actIncEdit,actDecEdit")]
	public ActionResult SetItemValue(int cycleId, int kind)
	{
		PayRollUserCycleItemValuesViewModel payRollUserCycleItemValuesViewModel = new PayRollUserCycleItemValuesViewModel();
		payRollUserCycleItemValuesViewModel.CycleId = cycleId;
		payRollUserCycleItemValuesViewModel.ItemKind = kind;
		payRollUserCycleItemValuesViewModel.ItemValues = new List<UserCycleItemValuesViewModel>();
		payRollUserCycleItemValuesViewModel.ItemValues = GetItemValues(cycleId, kind);
		return View(payRollUserCycleItemValuesViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmPayRollUserCycleDetails", ActionName = "actIncEdit,actDecEdit")]
	[AllowAnonymous]
	[ValidateAntiForgeryToken]
	public ActionResult SetItemValue(PayRollUserCycleItemValuesViewModel model)
	{
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			if (PayRoll.IsVerify(model.CycleId))
			{
				model.ItemValues = GetItemValues(model.CycleId, model.ItemKind);
				base.ViewBag.Error = Messages.msgErrorNotActivePayRollUserCycle;
				return View(model);
			}
			List<UserCycleIdKeyValueItemViewModel> list = new List<UserCycleIdKeyValueItemViewModel>();
			if (!base.ModelState.IsValid)
			{
				base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
			else
			{
				DateTime now = DateTime.Now;
				int userId = UserLogin.CurrentUser.UserId;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short value2 = short.Parse(Financial.Get().Id.ToString());
				if (!string.IsNullOrEmpty(model.ValueDetails))
				{
					list = new JavaScriptSerializer().Deserialize<List<UserCycleIdKeyValueItemViewModel>>(model.ValueDetails);
				}
				string itemValues = "";
				List<UserCycleIdKeyValueItemLangViewModel> list2 = new List<UserCycleIdKeyValueItemLangViewModel>();
				List<UserCycleItemValueViewModel> list3 = new List<UserCycleItemValueViewModel>();
				foreach (UserCycleIdKeyValueItemViewModel item3 in list)
				{
					string text = item3.Id ?? "";
					int itemValId = 0;
					if (text != "")
					{
						string[] array = text.Split(new char[1] { '_' });
						if (array != null)
						{
							itemValId = int.Parse(array[0]);
							int.Parse(array[1]);
						}
					}
					_ = item3.Type;
					string value3 = ((!string.IsNullOrEmpty(item3.Value)) ? item3.Value : "0");
					string usefulIds = item3.UsefulIds;
					UserCycleItemValueViewModel item = new UserCycleItemValueViewModel
					{
						ItemValId = itemValId,
						Value = value3,
						UsefulIds = usefulIds
					};
					list3.Add(item);
					string value4 = item3.ItemValueDesc ?? "";
					string text2 = item3.ItemValueDesc_Lang ?? "";
					List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrWhiteSpace(text2))
					{
						list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(text2);
					}
					if (!string.IsNullOrWhiteSpace(value4))
					{
						list4.Add(new CommonMultiLanguageViewModel
						{
							Value = value4,
							LanguageId = lCID
						});
					}
					if (list4 == null || !Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4))
					{
						continue;
					}
					foreach (CommonMultiLanguageViewModel item4 in list4)
					{
						UserCycleIdKeyValueItemLangViewModel item2 = new UserCycleIdKeyValueItemLangViewModel
						{
							Desc = item4.Value,
							LangId = item4.LanguageId,
							ItemValId = itemValId
						};
						list2.Add(item2);
					}
				}
				if (list3 != null && Enumerable.Any<UserCycleItemValueViewModel>((IEnumerable<UserCycleItemValueViewModel>)list3))
				{
					itemValues = JsonConvert.SerializeObject(Enumerable.ToList<UserCycleItemValueViewModel>((IEnumerable<UserCycleItemValueViewModel>)list3));
				}
				string itemValueDescJson = "";
				if (list2 != null && Enumerable.Any<UserCycleIdKeyValueItemLangViewModel>((IEnumerable<UserCycleIdKeyValueItemLangViewModel>)list2))
				{
					itemValueDescJson = JsonConvert.SerializeObject(Enumerable.ToList<UserCycleIdKeyValueItemLangViewModel>((IEnumerable<UserCycleIdKeyValueItemLangViewModel>)list2));
				}
				ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
				_db.PayRollspUpdateUserCycleItemValues(itemValues, userId, now, registerDatePersian, value2, value, appType, objectParameter, itemValueDescJson);
				if (objectParameter.Value != null)
				{
					if (!string.IsNullOrEmpty(objectParameter.Value.ToString()))
					{
						if (objectParameter.Value.ToString() == "Error")
						{
							base.ViewBag.Error = Messages.msgErrorRunFunction;
						}
					}
					else
					{
						string text3 = FinalCalculate(model.CycleId);
						if (!string.IsNullOrEmpty(text3))
						{
							base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage + "<br>" + Messages.msgErrorInCalculation + "<br>" + text3;
						}
						else
						{
							base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
						}
					}
				}
				else
				{
					string text4 = FinalCalculate(model.CycleId);
					if (!string.IsNullOrEmpty(text4))
					{
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage + "<br>" + Messages.msgErrorInCalculation + "<br>" + text4;
					}
					else
					{
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					}
				}
				model.ItemValues = GetItemValues(model.CycleId, model.ItemKind);
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			base.ViewBag.Error = Messages.msgErrorRunFunction;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			base.ViewBag.Error = Messages.msgErrorRunFunction;
		}
		return View(model);
	}

	public List<UserCycleItemValuesViewModel> GetItemValues(int cycleId, int kind)
	{
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		List<UserCycleItemValuesViewModel> list = new List<UserCycleItemValuesViewModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
			foreach (PayRollspSelectUserCycleItemValues_Result payRollCycleItemValue in GetPayRollCycleItemValues(cycleId, kind))
			{
				UserCycleItemValuesViewModel userCycleItemValuesViewModel = new UserCycleItemValuesViewModel
				{
					PayRollUserCycleItemValueId = payRollCycleItemValue.PayRollUserCycleItemValueId,
					ItemId = payRollCycleItemValue.ItemId,
					Value = payRollCycleItemValue.Value,
					UsefulIds = payRollCycleItemValue.UsefulIds,
					ItemName = payRollCycleItemValue.ItemName,
					ItemType = payRollCycleItemValue.ItemType,
					ItemTypeId = payRollCycleItemValue.ItemTypeId,
					ItemFormula = payRollCycleItemValue.ItemFormula,
					ItemJustForShow = payRollCycleItemValue.ItemJustForShow,
					ValueNotValid = payRollCycleItemValue.ValueNotValid,
					ValueStr = payRollCycleItemValue.ValueStr
				};
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrWhiteSpace(payRollCycleItemValue.ItemValueDesc_Lang))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(payRollCycleItemValue.ItemValueDesc_Lang);
				}
				if (!string.IsNullOrWhiteSpace(payRollCycleItemValue.ItemValueDesc))
				{
					list2.Add(new CommonMultiLanguageViewModel
					{
						Value = payRollCycleItemValue.ItemValueDesc,
						LanguageId = result
					});
				}
				if (list2 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2))
				{
					userCycleItemValuesViewModel.ItemValueDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
					userCycleItemValuesViewModel.ItemValueDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
				}
				list.Add(userCycleItemValuesViewModel);
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return list;
	}

	public string FinalCalculate(int cycleId)
	{
		string text = "";
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			DateTime now = DateTime.Now;
			int userId = UserLogin.CurrentUser.UserId;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
			_db.PayRollspCalculateUserCycleItemValues(cycleId, userId, now, registerDatePersian, value2, value, appType, objectParameter, lCID, result);
			if (objectParameter.Value != null && !string.IsNullOrEmpty(objectParameter.Value.ToString()))
			{
				string text2 = objectParameter.Value.ToString();
				if (text2 == "Error")
				{
					text = Messages.msgErrorRunFunction;
				}
				else
				{
					string[] array = text2.Split(new string[1] { "@|@" }, StringSplitOptions.None);
					if (Enumerable.Any<string>((IEnumerable<string>)array))
					{
						string[] array2 = array;
						foreach (string text3 in array2)
						{
							if (string.IsNullOrEmpty(text3))
							{
								continue;
							}
							string[] array3 = text3.Split(new char[1] { ',' });
							if (array3 != null && array3.Length == 2)
							{
								string arg = "";
								if (!string.IsNullOrEmpty(array3[1]))
								{
									array3[1] = array3[1].Replace("ItemName=", "");
									arg = array3[1];
								}
								text = ((array3[0].IndexOf("Formula is null", StringComparison.Ordinal) < 0) ? ((array3[0].IndexOf("Error in formula", StringComparison.Ordinal) < 0) ? (text + Messages.msgErrorRunFunction) : (text + string.Format(Messages.msgErrorInPayRollItemFormula, arg) + "<br>")) : (text + string.Format(Messages.msgErrorFormulaIsNull, arg) + "<br>"));
							}
						}
					}
				}
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			text = Messages.msgErrorRunFunction;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			text = Messages.msgErrorRunFunction;
		}
		return text;
	}

	[AjaxOnly]
	public string ActFinalCalculate(int cycleId)
	{
		string text = "";
		try
		{
			if (!UserLogin.IsUserAccess("frmPayRollUserCycleDetails", "actCalculateUserCycle", UserLogin.CurrentUser))
			{
				return Buttons.PayRollActFinalCalculation + "<br>" + Messages.ErrorNotAccess;
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (PayRoll.IsVerify(cycleId))
			{
				return Messages.msgErrorNotActivePayRollUserCycle;
			}
			string text2 = FinalCalculate(cycleId);
			if (string.IsNullOrEmpty(text2))
			{
				return "1";
			}
			return Messages.msgErrorInCalculation + "<br>" + text2;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.msgErrorRunFunction;
		}
	}

	[AjaxOnly]
	public string ActVerifyPayRoll(int cycleId)
	{
		string text = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmPayRollUserCycleDetails", "actVerifyCycle", currentUser))
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
		if (!UserLogin.IsUserAccess("frmPayRollUserCycleDetails", "actExitVerify", currentUser))
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
	public JsonResult GetBankingAccounts(int crmUserId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<PayRollspSelectUserBankingAccounts_Result> list = new List<PayRollspSelectUserBankingAccounts_Result>();
		try
		{
			list = Enumerable.ToList<PayRollspSelectUserBankingAccounts_Result>((IEnumerable<PayRollspSelectUserBankingAccounts_Result>)_dbI.PayRollspSelectUserBankingAccounts(crmUserId, lCID, result));
			if (list != null && Enumerable.Any<PayRollspSelectUserBankingAccounts_Result>((IEnumerable<PayRollspSelectUserBankingAccounts_Result>)list))
			{
				foreach (PayRollspSelectUserBankingAccounts_Result item in list)
				{
					item.AccountTitle = item.AccountTitle ?? "";
					bool result2 = false;
					bool result3 = false;
					bool.TryParse(item.IsDefault.ToString(), out result2);
					bool.TryParse(item.IsDefaultII.ToString(), out result3);
					if (!(result2 || result3))
					{
						continue;
					}
					string text = "";
					if (result2)
					{
						text = Labels.PayRollUserPayBankingAccountDefault;
					}
					if (result3)
					{
						if (!string.IsNullOrWhiteSpace(text))
						{
							text += " - ";
						}
						text += Labels.PayRollUserPayBankingAccountDefaultII;
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						item.AccountTitle = item.AccountTitle + " (" + text + " )";
					}
				}
			}
			else
			{
				list = new List<PayRollspSelectUserBankingAccounts_Result>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbI.Dispose();
		base.Dispose(disposing);
	}

	[DynamicAuthorize(ControllerName = "frmPayRollUserCycleDetails", ActionName = "actShowItemsFromOther")]
	public ActionResult ShowPayRollUserCycles(int crmUserId, int cycleId)
	{
		base.ViewBag.CrmUserId = crmUserId;
		base.ViewBag.CycleId = cycleId;
		return View();
	}

	[AjaxOnly]
	public ActionResult ShowUserCycles_Read([DataSourceRequest] DataSourceRequest request, int crmUserId, int cycleId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<PayRollspSelectUserCycle_Result> list = new List<PayRollspSelectUserCycle_Result>();
		try
		{
			list = Enumerable.ToList<PayRollspSelectUserCycle_Result>((IEnumerable<PayRollspSelectUserCycle_Result>)_db.PayRollspSelectUserCycle(crmUserId, 0, UserLogin.CurrentUser.UserId, null, null, lCID, result));
			foreach (PayRollspSelectUserCycle_Result item in list)
			{
				_ = item.CycleDate;
				item.CycleDatePersian = item.CycleDate.ToString("yyyy/MM/dd");
				item.CycleIsVerified = item.CycleIsVerified.HasValue && item.CycleIsVerified != false;
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

	[DynamicAuthorize(ControllerName = "frmPayRollUserCycleDetails", ActionName = "actCopyItemsFromOther")]
	public ActionResult CopyOtherPayRollCycleItemValue(int crmUserId, int cycleId)
	{
		base.ViewBag.CrmUserId = crmUserId;
		base.ViewBag.CycleId = cycleId;
		GetUsersForCopy(crmUserId);
		GetUserCycles(crmUserId, cycleId);
		return View();
	}

	[AjaxOnly]
	public JsonResult GetUsersForCopy(int crmUserId)
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
			List<CRMspSelectActiveUsers_Result> list2 = Enumerable.ToList<CRMspSelectActiveUsers_Result>(Enumerable.Where<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)_db.CRMspSelectActiveUsers(lCID, result, 0), (Func<CRMspSelectActiveUsers_Result, bool>)((CRMspSelectActiveUsers_Result m) => m.UserId > 0)));
			list.AddRange(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)list2, (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result item) => new SelectListItem
			{
				Text = (item.Name ?? ""),
				Value = item.UserId.ToString(),
				Selected = (item.UserId == crmUserId)
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.UserList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetUserCycles(int crmUserId, int cycleId)
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
			List<PayRollspSelectUserCycle_Result> list2 = Enumerable.ToList<PayRollspSelectUserCycle_Result>(Enumerable.Where<PayRollspSelectUserCycle_Result>((IEnumerable<PayRollspSelectUserCycle_Result>)_db.PayRollspSelectUserCycle(crmUserId, 0, UserLogin.CurrentUser.UserId, null, null, lCID, result), (Func<PayRollspSelectUserCycle_Result, bool>)((PayRollspSelectUserCycle_Result model) => model.PayRollUserCycleId != cycleId)));
			list.AddRange(Enumerable.Select<PayRollspSelectUserCycle_Result, SelectListItem>((IEnumerable<PayRollspSelectUserCycle_Result>)list2, (Func<PayRollspSelectUserCycle_Result, SelectListItem>)((PayRollspSelectUserCycle_Result item) => new SelectListItem
			{
				Text = (item.CycleTitle ?? ""),
				Value = item.PayRollUserCycleId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.UserCycleList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmPayRollUserCycleDetails", ActionName = "actCopyItemsFromOther")]
	public string ActCopyPaste(int currCycleId, int oldCycleId, int crmUserId)
	{
		string text = "";
		try
		{
			if (!UserLogin.IsUserAccess("frmPayRollUserCycleDetails", "actCopyItemsFromOther", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (currCycleId > 0)
			{
				if (PayRoll.IsVerify(currCycleId))
				{
					return Messages.msgErrorNotActivePayRollUserCycle;
				}
				DateTime now = DateTime.Now;
				int userId = UserLogin.CurrentUser.UserId;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short value2 = short.Parse(Financial.Get().Id.ToString());
				_db.PayRollspCopyOtherCycleItemValues(oldCycleId, currCycleId, crmUserId, userId, now, registerDatePersian, value2, value, appType, result);
				return "ok";
			}
			return Messages.ErrorNotFound;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.msgErrorRunFunction;
		}
	}

	[DynamicAuthorize(ControllerName = "frmPayRollUserCycleDetails", ActionName = "actCommDetails")]
	public ActionResult CommissionDetails(int cycleId, int itemValueId, int itemId)
	{
		base.ViewBag.CycleId = cycleId;
		base.ViewBag.ItemValueId = itemValueId;
		base.ViewBag.ItemId = itemId;
		return View();
	}

	[AjaxOnly]
	public JsonResult GetOrderCommissions(int cycleId, int itemValueId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		PayRollOrderCommissionListViewModel payRollOrderCommissionListViewModel = new PayRollOrderCommissionListViewModel();
		payRollOrderCommissionListViewModel.OrderCommissions = new List<PayRollspSelectOrderCommissions_Result>();
		payRollOrderCommissionListViewModel.IsFind = false;
		try
		{
			if (cycleId != 0 && itemValueId != 0)
			{
				payRollOrderCommissionListViewModel.OrderCommissions = Enumerable.ToList<PayRollspSelectOrderCommissions_Result>((IEnumerable<PayRollspSelectOrderCommissions_Result>)_dbI.PayRollspSelectOrderCommissions(cycleId, itemValueId, lCID, result));
				if (payRollOrderCommissionListViewModel.OrderCommissions != null && Enumerable.Any<PayRollspSelectOrderCommissions_Result>((IEnumerable<PayRollspSelectOrderCommissions_Result>)payRollOrderCommissionListViewModel.OrderCommissions))
				{
					payRollOrderCommissionListViewModel.IsFind = true;
					foreach (PayRollspSelectOrderCommissions_Result orderCommission in payRollOrderCommissionListViewModel.OrderCommissions)
					{
						orderCommission.CommOrderDate = (orderCommission.CommOrderDateTime.HasValue ? orderCommission.CommOrderDateTime.Value.ToString("yyyy/MM/dd") : "");
						string payRollCommissionDetailsCommInfo = Labels.PayRollCommissionDetailsCommInfo;
						decimal valueOrDefault = orderCommission.CommOrderTotalAmount.GetValueOrDefault();
						string text = valueOrDefault.ToString();
						text = ((text.IndexOf(".00") < 0) ? $"{valueOrDefault:N2}" : $"{valueOrDefault:N0}");
						decimal commAmount = orderCommission.CommAmount;
						string text2 = commAmount.ToString();
						text2 = ((text2.IndexOf(".00") < 0) ? $"{commAmount:N2}" : $"{commAmount:N0}");
						orderCommission.CommOrderOpr = string.Format(payRollCommissionDetailsCommInfo, text2, orderCommission.CommAmountCurrUn ?? "", orderCommission.Company ?? "", orderCommission.CommOrderOpr ?? "", orderCommission.CommOrderNumber.GetValueOrDefault().ToString(), text, orderCommission.CommOrderCurrencyUnit ?? "");
					}
				}
				else
				{
					payRollOrderCommissionListViewModel.OrderCommissions = new List<PayRollspSelectOrderCommissions_Result>();
					payRollOrderCommissionListViewModel.Message = Messages.ErrorNotFound;
				}
			}
			else
			{
				payRollOrderCommissionListViewModel.Message = Messages.msgErrorNotSelectedItem;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			payRollOrderCommissionListViewModel.Message = Messages.msgErrorRunFunction + "<br />" + ex.Message;
		}
		JsonResult jsonResult = Json(payRollOrderCommissionListViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult ActAddOrderCommissions(int cycleId, int itemValueId, string ordComm)
	{
		decimal data = default(decimal);
		string text = "";
		CommonResultStatusViewModel status = CommonResultStatusViewModel.Success;
		CommonResultViewModel<decimal> data2;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (!UserLogin.IsUserAccess("frmPayRollUserCycleDetails", "actCommDetails"))
			{
				data = default(decimal);
				text = Messages.NotAccessToPage;
				status = CommonResultStatusViewModel.Error;
				data2 = new CommonResultViewModel<decimal>
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
			int num = 0;
			if (cycleId == 0)
			{
				num++;
				text = text + Messages.msgErrorNotSelectedItem + "<br>";
			}
			if (itemValueId == 0)
			{
				num++;
				text = text + Messages.msgErrorNotSelectedItem + "<br>";
			}
			if (string.IsNullOrWhiteSpace(ordComm))
			{
				num++;
				text = text + Messages.msgErrorPayRollNotSelecedCommissions + "<br>";
			}
			if (num == 0)
			{
				ObjectParameter objectParameter = new ObjectParameter("resultId", typeof(int));
				ObjectParameter objectParameter2 = new ObjectParameter("sumValue", typeof(decimal));
				_dbI.PayRollspAddOrderCommissions(cycleId, itemValueId, ordComm, userId, value2, value3, value, registerDatePersian, appType, objectParameter, objectParameter2);
				int result2 = 0;
				if (objectParameter != null && objectParameter.Value != null)
				{
					int.TryParse(objectParameter.Value.ToString(), out result2);
				}
				decimal result3 = default(decimal);
				if (objectParameter2 != null && objectParameter2.Value != null)
				{
					decimal.TryParse(objectParameter2.Value.ToString(), out result3);
				}
				if (result2 == 0)
				{
					data = default(decimal);
					text = Messages.msgErrorRunFunction;
					status = CommonResultStatusViewModel.Error;
				}
				else if (result2 == -1)
				{
					data = default(decimal);
					text = Messages.msgErrorPayRollNotSelecedCommissions;
					status = CommonResultStatusViewModel.Error;
				}
				else if (result2 > 0)
				{
					FinalCalculate(cycleId);
					data = result3;
					text = Messages.msgSuccessAction;
					status = CommonResultStatusViewModel.Success;
				}
			}
			else
			{
				data = default(decimal);
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
			data = default(decimal);
			text = Messages.msgErrorRunFunction + " " + ex.Message;
			status = CommonResultStatusViewModel.Error;
		}
		data2 = new CommonResultViewModel<decimal>
		{
			Data = data,
			Message = text,
			Status = status
		};
		return Json(data2, JsonRequestBehavior.AllowGet);
	}
}

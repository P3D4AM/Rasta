using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web;
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
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Company.Controllers;

public class CompanyMoneyBagController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public int cmpMnBgId;

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
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public CrmCompanyMoneyBagLanguageViewModel vm;

		public int defLangID;

		internal bool _003CInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__6(CommonMultiLanguageViewModel m)
		{
			return m.LanguageId != defLangID;
		}
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actCmpMoneyBag")]
	public ActionResult Index(int cmpId)
	{
		base.ViewBag.CmpId = cmpId;
		return View();
	}

	[AjaxOnly]
	public ActionResult CompanyMoneyBag_Read([DataSourceRequest] DataSourceRequest request, int cmpId, string fromDate, string toDate)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectCompanyMoneyBag_Result> list = new List<CRMspSelectCompanyMoneyBag_Result>();
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
			string cmpMnBgTextRemainderBefore = Labels.CmpMnBgTextRemainderBefore;
			string cmpMnBgTextManual = Labels.CmpMnBgTextManual;
			string cmpMnBgTextSystemic = Labels.CmpMnBgTextSystemic;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (UserLogin.IsUserAccess("frmCompanyMoneyBag", "actLoadData", UserLogin.CurrentUser))
			{
				list = Enumerable.ToList<CRMspSelectCompanyMoneyBag_Result>((IEnumerable<CRMspSelectCompanyMoneyBag_Result>)_dbI.CRMspSelectCompanyMoneyBag(cmpId, value, value2, cmpMnBgTextRemainderBefore, cmpMnBgTextManual, cmpMnBgTextSystemic, lCID, result, result2));
				foreach (CRMspSelectCompanyMoneyBag_Result item in list)
				{
					item.CmpMnBgDatePersian = (item.CmpMnBgDate.HasValue ? item.CmpMnBgDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
					item.CmpMnBgExpireDatePersian = item.CmpMnBgExpireDate?.ToString("yyyy/MM/dd HH:mm:ss");
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

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmCompanyMoneyBag", ActionName = "actDelete")]
	public string ActDelete(int cmpMnBgId)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (!UserLogin.IsUserAccess("frmCompanyMoneyBag", "actDelete", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			if (cmpMnBgId > 0)
			{
				try
				{
					mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.CRMspDeleteCompanyMoneyBag(cmpMnBgId));
					if (mct_I_Result != null && mct_I_Result.Result > 0)
					{
						result = "";
					}
					else if (mct_I_Result != null && mct_I_Result.Result == 0)
					{
						result = Messages.RedundancyMessage;
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

	public void SetRegisterInfo(CrmCompanyMoneyBagLanguageViewModel model, ref string firstRegInfo, ref string regInfo)
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
			CRMspSelectUsersById_Result cRMspSelectUsersById_Result = CRMIdeal.Classes.Helper.User.SelectUsersById(model.FirstRegisterUserId);
			if (cRMspSelectUsersById_Result != null)
			{
				firstRegInfo = cRMspSelectUsersById_Result.FullName ?? "";
				_ = model.FirstRegisterDate;
				string text = model.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				firstRegInfo += ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			}
			CRMspSelectUsersById_Result cRMspSelectUsersById_Result2 = CRMIdeal.Classes.Helper.User.SelectUsersById(model.UserId);
			if (cRMspSelectUsersById_Result2 != null)
			{
				regInfo = cRMspSelectUsersById_Result2.FullName ?? "";
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

	[DynamicAuthorize(ControllerName = "frmCompanyMoneyBag", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(int cmpId, int cmpMnBgId = 0)
	{
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass7_0();
		CS_0024_003C_003E8__locals0.cmpMnBgId = cmpMnBgId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		CrmCompanyMoneyBagLanguageViewModel crmCompanyMoneyBagLanguageViewModel = new CrmCompanyMoneyBagLanguageViewModel();
		int result2 = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
		}
		try
		{
			if (CS_0024_003C_003E8__locals0.cmpMnBgId > 0)
			{
				if (!UserLogin.IsUserAccess("frmCompanyMoneyBag", "actEdit"))
				{
					base.ViewBag.Error = Messages.NotAccessToPage;
					return null;
				}
				DbSet<CrmCompanyMoneyBag_Lang> crmCompanyMoneyBag_Lang = _dbTbl.CrmCompanyMoneyBag_Lang;
				ParameterExpression val = Expression.Parameter(typeof(CrmCompanyMoneyBag_Lang), "c");
				List<CrmCompanyMoneyBag_Lang> list = Enumerable.ToList<CrmCompanyMoneyBag_Lang>((IEnumerable<CrmCompanyMoneyBag_Lang>)Queryable.Where<CrmCompanyMoneyBag_Lang>((IQueryable<CrmCompanyMoneyBag_Lang>)crmCompanyMoneyBag_Lang, Expression.Lambda<Func<CrmCompanyMoneyBag_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass7_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				DbSet<CrmCompanyMoneyBag> crmCompanyMoneyBag = _dbTbl.CrmCompanyMoneyBag;
				val = Expression.Parameter(typeof(CrmCompanyMoneyBag), "c");
				CrmCompanyMoneyBag crmCompanyMoneyBag2 = Queryable.FirstOrDefault<CrmCompanyMoneyBag>((IQueryable<CrmCompanyMoneyBag>)crmCompanyMoneyBag, Expression.Lambda<Func<CrmCompanyMoneyBag, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass7_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (crmCompanyMoneyBag2 == null)
				{
					base.ViewBag.Error = Messages.ErrorNotFound;
					return null;
				}
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyMoneyBag_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyMoneyBag_Lang>)list, (Func<CrmCompanyMoneyBag_Lang, CommonMultiLanguageViewModel>)((CrmCompanyMoneyBag_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.CmpMnBgDesc,
					LanguageId = item.LanguageID
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyMoneyBag2.CmpMnBgDesc,
					LanguageId = result
				});
				CrmCompanyMoneyBagLanguageViewModel obj = new CrmCompanyMoneyBagLanguageViewModel
				{
					CompanyMoneyBagId = crmCompanyMoneyBag2.CompanyMoneyBagId,
					CmpMnBgCompanyId = crmCompanyMoneyBag2.CmpMnBgCompanyId,
					CmpMnBgSystemPartId = crmCompanyMoneyBag2.CmpMnBgSystemPartId,
					CmpMnBgSystemPartObjectId = crmCompanyMoneyBag2.CmpMnBgSystemPartObjectId,
					CmpMnBgNumber = crmCompanyMoneyBag2.CmpMnBgNumber,
					CmpMnBgDate = crmCompanyMoneyBag2.CmpMnBgDate
				};
				_ = crmCompanyMoneyBag2.CmpMnBgDate;
				obj.CmpMnBgDatePersian = crmCompanyMoneyBag2.CmpMnBgDate.ToString("yyyy/MM/dd");
				obj.CmpMnBgAmount = crmCompanyMoneyBag2.CmpMnBgAmount;
				obj.CmpMnBgDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
				obj.CmpMnBgDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
				obj.CmpMnBgBankTransactionCode = crmCompanyMoneyBag2.CmpMnBgBankTransactionCode;
				obj.FirstRegisterUserId = crmCompanyMoneyBag2.FirstRegisterUserId;
				obj.FirstRegisterDate = crmCompanyMoneyBag2.FirstRegisterDate;
				obj.FirstRegisterDatePersian = crmCompanyMoneyBag2.FirstRegisterDatePersian;
				obj.UserId = crmCompanyMoneyBag2.UserId;
				obj.Year1 = crmCompanyMoneyBag2.Year1;
				obj.Month1 = crmCompanyMoneyBag2.Month1;
				obj.RegisterDate = crmCompanyMoneyBag2.RegisterDate;
				obj.RegisterDatePersian = crmCompanyMoneyBag2.RegisterDatePersian;
				obj.GUId = crmCompanyMoneyBag2.GUId;
				obj.AppType = crmCompanyMoneyBag2.AppType;
				obj.LanguageID = crmCompanyMoneyBag2.LanguageID;
				obj.CmpMnBgExpireDate = crmCompanyMoneyBag2.CmpMnBgExpireDate;
				obj.CmpMnBgExpireDatePersian = crmCompanyMoneyBag2.CmpMnBgExpireDate?.ToString("yyyy/MM/dd");
				crmCompanyMoneyBagLanguageViewModel = obj;
			}
			else
			{
				if (!UserLogin.IsUserAccess("frmCompanyMoneyBag", "actInsert"))
				{
					base.ViewBag.Error = Messages.NotAccessToPage;
					return null;
				}
				DateTime now = DateTime.Now;
				long cmpMnBgNumber = Enumerable.FirstOrDefault<long>((IEnumerable<long>)Enumerable.ToList<long>(_dbI.Database.SqlQuery<long>($"Select dbo.CRMfnReturnCompanyMoneyBagNumber({result2})", Array.Empty<object>())));
				crmCompanyMoneyBagLanguageViewModel = new CrmCompanyMoneyBagLanguageViewModel
				{
					CmpMnBgCompanyId = cmpId,
					CmpMnBgDate = now,
					CmpMnBgDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
					FirstRegisterUserId = UserLogin.CurrentUser.UserId,
					FirstRegisterDate = now,
					FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
					UserId = UserLogin.CurrentUser.UserId,
					RegisterDate = now,
					RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
					CmpMnBgNumber = cmpMnBgNumber
				};
				base.ViewBag.IsBuying = VersionBuyer.MoneyBag;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		string firstRegInfo = "";
		string regInfo = "";
		SetRegisterInfo(crmCompanyMoneyBagLanguageViewModel, ref firstRegInfo, ref regInfo);
		crmCompanyMoneyBagLanguageViewModel.FirstRegisterUser = firstRegInfo;
		crmCompanyMoneyBagLanguageViewModel.EditUser = regInfo;
		return View(crmCompanyMoneyBagLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmCompanyMoneyBagDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult InsertEdit(CrmCompanyMoneyBagLanguageViewModel vm, HttpPostedFileBase fileSending)
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass8_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.CmpMnBgDesc_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.CmpMnBgDesc_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.CmpMnBgDesc,
			LanguageId = lCID
		});
		int? centerId = null;
		if (UserLogin.CurrentUser != null)
		{
			centerId = UserLogin.CurrentUser.UserLastCId;
		}
		try
		{
			if (CS_0024_003C_003E8__locals0.vm.CompanyMoneyBagId <= 0 && !VersionBuyer.MoneyBag)
			{
				DbSet<CrmCompanyMoneyBag> crmCompanyMoneyBag = _dbTbl.CrmCompanyMoneyBag;
				ParameterExpression val = Expression.Parameter(typeof(CrmCompanyMoneyBag), "c");
				if (Queryable.Any<CrmCompanyMoneyBag>((IQueryable<CrmCompanyMoneyBag>)crmCompanyMoneyBag, Expression.Lambda<Func<CrmCompanyMoneyBag, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)10, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val })))
				{
					base.ViewBag.Error = "BV|" + Messages.VersionBuy;
					return View(CS_0024_003C_003E8__locals0.vm);
				}
			}
			DateTime dateTime = default(DateTime);
			string text = "";
			try
			{
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.CmpMnBgDatePersian))
				{
					text = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.vm.CmpMnBgDatePersian.Replace("/", ""));
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
						CS_0024_003C_003E8__locals0.vm.CmpMnBgDatePersian = dateTime.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
						CS_0024_003C_003E8__locals0.vm.CmpMnBgDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
						CS_0024_003C_003E8__locals0.vm.CmpMnBgDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
					CS_0024_003C_003E8__locals0.vm.CmpMnBgDate = dateTime;
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				base.ViewBag.Error = string.Format(Messages.ErrorInFormat, Labels.CmpMnBgDate);
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			if (CS_0024_003C_003E8__locals0.vm.CmpMnBgDatePersian != null)
			{
				CS_0024_003C_003E8__locals0.vm.CmpMnBgDatePersian = CS_0024_003C_003E8__locals0.vm.CmpMnBgDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
			}
			try
			{
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.CmpMnBgExpireDatePersian))
				{
					text = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.vm.CmpMnBgExpireDatePersian.Replace("/", ""));
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
						CS_0024_003C_003E8__locals0.vm.CmpMnBgExpireDatePersian = dateTime.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
						CS_0024_003C_003E8__locals0.vm.CmpMnBgExpireDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
						CS_0024_003C_003E8__locals0.vm.CmpMnBgExpireDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
					CS_0024_003C_003E8__locals0.vm.CmpMnBgExpireDate = dateTime;
					CS_0024_003C_003E8__locals0.vm.CmpMnBgExpireDatePersian = CS_0024_003C_003E8__locals0.vm.CmpMnBgExpireDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
						.Replace(".", "")
						.Replace(",", "")
						.Replace("\\", "");
				}
			}
			catch (Exception e2)
			{
				ErrorSignal.FromCurrentContext().Raise(e2);
				base.ViewBag.Error = string.Format(Messages.ErrorInFormat, Labels.ExpireDate);
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			if (!base.ModelState.IsValid)
			{
				base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
			else
			{
				DateTime now = DateTime.Now;
				DateTime dateTime2 = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short value2 = short.Parse(Financial.Get().Id.ToString());
				int userId = UserLogin.CurrentUser.UserId;
				CrmCompanyMoneyBag crmCompanyMoneyBag2 = new CrmCompanyMoneyBag();
				if (CS_0024_003C_003E8__locals0.vm.CompanyMoneyBagId > 0)
				{
					DbSet<CrmCompanyMoneyBag> crmCompanyMoneyBag3 = _dbTbl.CrmCompanyMoneyBag;
					ParameterExpression val = Expression.Parameter(typeof(CrmCompanyMoneyBag), "c");
					crmCompanyMoneyBag2 = Queryable.FirstOrDefault<CrmCompanyMoneyBag>((IQueryable<CrmCompanyMoneyBag>)crmCompanyMoneyBag3, Expression.Lambda<Func<CrmCompanyMoneyBag, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				string cmpMnBgDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				string cmpMnBgDesc_Lang = "";
				if (list != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list))
				{
					cmpMnBgDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel m) => m.LanguageId != CS_0024_003C_003E8__locals0.defLangID))));
				}
				if (crmCompanyMoneyBag2.CompanyMoneyBagId > 0)
				{
					mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.CRMspUpdateCompanyMoneyBag(crmCompanyMoneyBag2.CompanyMoneyBagId, CS_0024_003C_003E8__locals0.vm.CmpMnBgDate, CS_0024_003C_003E8__locals0.vm.CmpMnBgDatePersian, CS_0024_003C_003E8__locals0.vm.CmpMnBgAmount, cmpMnBgDesc, cmpMnBgDesc_Lang, CS_0024_003C_003E8__locals0.vm.CmpMnBgBankTransactionCode, userId, value, value2, dateTime2, registerDatePersian, appType, CS_0024_003C_003E8__locals0.defLangID, CS_0024_003C_003E8__locals0.vm.CmpMnBgExpireDate, CS_0024_003C_003E8__locals0.vm.CmpMnBgExpireDatePersian));
					int result = 0;
					if (mct_I_Result != null)
					{
						int.TryParse(mct_I_Result.Result.ToString(), out result);
					}
					if (result != 1)
					{
						base.ViewBag.Error = Messages.msgErrorRunFunction;
					}
					else
					{
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					}
				}
				else
				{
					ObjectParameter objectParameter = new ObjectParameter("insertedCompanyMoneyBagId", 0);
					Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.CRMspInsertCompanyMoneyBag(CS_0024_003C_003E8__locals0.vm.CmpMnBgCompanyId, CS_0024_003C_003E8__locals0.vm.CmpMnBgSystemPartId, CS_0024_003C_003E8__locals0.vm.CmpMnBgSystemPartObjectId, CS_0024_003C_003E8__locals0.vm.CmpMnBgDate, CS_0024_003C_003E8__locals0.vm.CmpMnBgDatePersian, CS_0024_003C_003E8__locals0.vm.CmpMnBgAmount, cmpMnBgDesc, cmpMnBgDesc_Lang, CS_0024_003C_003E8__locals0.vm.CmpMnBgBankTransactionCode, userId, value2, value, dateTime2, registerDatePersian, appType, CS_0024_003C_003E8__locals0.defLangID, objectParameter, CS_0024_003C_003E8__locals0.vm.CmpMnBgExpireDate, CS_0024_003C_003E8__locals0.vm.CmpMnBgExpireDatePersian, centerId));
					int result2 = 0;
					if (objectParameter.Value != null)
					{
						int.TryParse(objectParameter.Value.ToString(), out result2);
					}
					CS_0024_003C_003E8__locals0.vm.CompanyMoneyBagId = result2;
					if (result2 <= 0)
					{
						base.ViewBag.Error = Messages.msgErrorRunFunction;
					}
					else
					{
						base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
					}
				}
				string firstRegInfo = "";
				string regInfo = "";
				CS_0024_003C_003E8__locals0.vm.FirstRegisterUserId = crmCompanyMoneyBag2.FirstRegisterUserId;
				CS_0024_003C_003E8__locals0.vm.UserId = userId;
				CS_0024_003C_003E8__locals0.vm.FirstRegisterDate = crmCompanyMoneyBag2.FirstRegisterDate;
				CS_0024_003C_003E8__locals0.vm.RegisterDate = dateTime2;
				CS_0024_003C_003E8__locals0.vm.FirstRegisterDatePersian = crmCompanyMoneyBag2.FirstRegisterDatePersian;
				CS_0024_003C_003E8__locals0.vm.RegisterDatePersian = registerDatePersian;
				CS_0024_003C_003E8__locals0.vm.AppType = appType;
				SetRegisterInfo(CS_0024_003C_003E8__locals0.vm, ref firstRegInfo, ref regInfo);
				CS_0024_003C_003E8__locals0.vm.FirstRegisterUser = firstRegInfo;
				CS_0024_003C_003E8__locals0.vm.EditUser = regInfo;
				CrmCompanyMoneyBagLanguageViewModel vm2 = CS_0024_003C_003E8__locals0.vm;
				_ = CS_0024_003C_003E8__locals0.vm.CmpMnBgDate;
				vm2.CmpMnBgDatePersian = CS_0024_003C_003E8__locals0.vm.CmpMnBgDate.ToString("yyyy/MM/dd");
			}
		}
		catch (DbEntityValidationException e3)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e3);
			base.ViewBag.Error = Messages.msgErrorRunFunction;
		}
		catch (Exception e4)
		{
			ErrorSignal.FromCurrentContext().Raise(e4);
			base.ViewBag.Error = Messages.msgErrorRunFunction;
		}
		return View(CS_0024_003C_003E8__locals0.vm);
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}

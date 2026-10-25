using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Transactions;
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

namespace CRMIdeal.Areas.PreOrders.Controllers;

public class CommissionController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass13_0
	{
		public int id;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public int commId;

		public int currLangID;

		internal bool _003CInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public WSPreOrderCommissionsLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__10;

		public Func<Languages, bool> _003C_003E9__24;

		internal bool _003CInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__10(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__24(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_1
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals1;

		internal bool _003CInsertEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	public List<WSspSelectPreOrderCommissions_Result> GetPreOrderCommission(int pordId, bool isShowAllUser)
	{
		List<WSspSelectPreOrderCommissions_Result> list = new List<WSspSelectPreOrderCommissions_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			int value = userId;
			if (isShowAllUser)
			{
				value = 0;
			}
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			list = Enumerable.ToList<WSspSelectPreOrderCommissions_Result>((IEnumerable<WSspSelectPreOrderCommissions_Result>)_db.WSspSelectPreOrderCommissions(pordId, value, userId, lCID, result, centerId));
			foreach (WSspSelectPreOrderCommissions_Result item in list)
			{
				DateTime now = DateTime.Now;
				_ = item.CommDateTime;
				item.CommDatePersian = DateTime.Parse(item.CommDateTime.ToString()).ToString("yyyy/MM/dd");
				if (item.CommEffectiveDateTime.HasValue)
				{
					item.CommEffectiveDatePersian = DateTime.Parse(item.CommEffectiveDateTime.ToString()).ToString("yyyy/MM/dd");
				}
				else if (!string.IsNullOrEmpty(item.CommEffectiveDatePersian))
				{
					item.CommEffectiveDatePersian = PersianDate.GetFormatetdDate(item.CommEffectiveDatePersian);
				}
				if (item.CommVerifiedDateTime.HasValue)
				{
					item.CommVerifiedDatePersian = DateTime.Parse(item.CommVerifiedDateTime.ToString()).ToString("yyyy/MM/dd");
				}
				else if (!string.IsNullOrEmpty(item.CommVerifiedDatePersian))
				{
					item.CommVerifiedDatePersian = PersianDate.GetFormatetdDate(item.CommVerifiedDatePersian);
				}
				if (item.CommIsPaidDateTime.HasValue)
				{
					item.CommIsPaidDatePersian = DateTime.Parse(item.CommIsPaidDateTime.ToString()).ToString("yyyy/MM/dd");
				}
				else if (!string.IsNullOrEmpty(item.CommIsPaidDatePersian))
				{
					item.CommIsPaidDatePersian = PersianDate.GetFormatetdDate(item.CommIsPaidDatePersian);
				}
				_ = item.FirstRegisterDate;
				item.FirstRegisterDatePersian = DateTime.Parse(item.FirstRegisterDate.ToString()).ToString("yyyy/MM/dd");
				_ = item.RegisterDate;
				item.RegisterDatePersian = DateTime.Parse(item.RegisterDate.ToString()).ToString("yyyy/MM/dd");
				item.CommIsVerified = item.CommIsVerified.HasValue && item.CommIsVerified != false;
				item.CommIsPaid = item.CommIsPaid.HasValue && item.CommIsPaid != false;
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

	public ActionResult Commission_Read([DataSourceRequest] DataSourceRequest request, int pordId, bool isShowAllUser)
	{
		List<WSspSelectPreOrderCommissions_Result> enumerable = new List<WSspSelectPreOrderCommissions_Result>();
		try
		{
			enumerable = GetPreOrderCommission(pordId, isShowAllUser);
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		JsonResult jsonResult = Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actInsertComm,actEdtiComm")]
	public ActionResult InsertEdit(int commId, int pordId, int cmpId)
	{
		_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass4_0();
		CS_0024_003C_003E8__locals0.commId = commId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		WSPreOrderCommissionsLanguageViewModel wSPreOrderCommissionsLanguageViewModel = new WSPreOrderCommissionsLanguageViewModel();
		DateTime now = DateTime.Now;
		if (CS_0024_003C_003E8__locals0.commId == 0)
		{
			wSPreOrderCommissionsLanguageViewModel = new WSPreOrderCommissionsLanguageViewModel
			{
				CommPreOrderId = Convert.ToInt32(pordId),
				CommCmpId = Convert.ToInt32(cmpId),
				CommDatePersian = now.ToString("yyyy/MM/dd"),
				FirstRegisterDate = now,
				RegisterDate = now,
				CommDateTime = now,
				CommEffectiveDateTime = now
			};
			base.ViewBag.IsBuying = VersionBuyer.Commissions;
		}
		else
		{
			DbSet<WSPreOrderCommissions_Lang> wSPreOrderCommissions_Lang = _dbTbl.WSPreOrderCommissions_Lang;
			ParameterExpression val = Expression.Parameter(typeof(WSPreOrderCommissions_Lang), "c");
			List<WSPreOrderCommissions_Lang> list = Enumerable.ToList<WSPreOrderCommissions_Lang>((IEnumerable<WSPreOrderCommissions_Lang>)Queryable.Where<WSPreOrderCommissions_Lang>((IQueryable<WSPreOrderCommissions_Lang>)wSPreOrderCommissions_Lang, Expression.Lambda<Func<WSPreOrderCommissions_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass4_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			DbSet<WSPreOrderCommissions> wSPreOrderCommissions = _dbTbl.WSPreOrderCommissions;
			val = Expression.Parameter(typeof(WSPreOrderCommissions), "c");
			WSPreOrderCommissions wSPreOrderCommissions2 = Queryable.FirstOrDefault<WSPreOrderCommissions>((IQueryable<WSPreOrderCommissions>)wSPreOrderCommissions, Expression.Lambda<Func<WSPreOrderCommissions, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass4_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) ?? new WSPreOrderCommissions();
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrderCommissions_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrderCommissions_Lang>)list, (Func<WSPreOrderCommissions_Lang, CommonMultiLanguageViewModel>)((WSPreOrderCommissions_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.CommBaseAmountDecDesc,
				LanguageId = item.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = wSPreOrderCommissions2.CommBaseAmountDecDesc,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrderCommissions_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrderCommissions_Lang>)list, (Func<WSPreOrderCommissions_Lang, CommonMultiLanguageViewModel>)((WSPreOrderCommissions_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.CommRateDesc,
				LanguageId = item.LanguageID
			})));
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = wSPreOrderCommissions2.CommRateDesc,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrderCommissions_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrderCommissions_Lang>)list, (Func<WSPreOrderCommissions_Lang, CommonMultiLanguageViewModel>)((WSPreOrderCommissions_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.CommDesc,
				LanguageId = item.LanguageID
			})));
			list4.Add(new CommonMultiLanguageViewModel
			{
				Value = wSPreOrderCommissions2.CommDesc,
				LanguageId = result
			});
			WSPreOrderCommissionsLanguageViewModel obj = new WSPreOrderCommissionsLanguageViewModel
			{
				PreOrderCommissionId = wSPreOrderCommissions2.PreOrderCommissionId
			};
			_ = wSPreOrderCommissions2.CommDateTime;
			obj.CommDatePersian = wSPreOrderCommissions2.CommDateTime.ToString("yyyy/MM/dd");
			obj.CommPreOrderId = wSPreOrderCommissions2.CommPreOrderId;
			obj.CommCmpId = wSPreOrderCommissions2.CommCmpId;
			obj.CommUserId = wSPreOrderCommissions2.CommUserId;
			obj.CommBaseAmountDec = wSPreOrderCommissions2.CommBaseAmountDec;
			obj.CommBaseAmountDecDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
			obj.CommBaseAmountDecDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
			obj.CommBaseAmount = wSPreOrderCommissions2.CommBaseAmount;
			obj.CommRate = wSPreOrderCommissions2.CommRate;
			obj.CommRateDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
			obj.CommRateDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
			obj.CommAmount = wSPreOrderCommissions2.CommAmount;
			obj.CommEffectiveDatePersian = (wSPreOrderCommissions2.CommEffectiveDateTime.HasValue ? wSPreOrderCommissions2.CommEffectiveDateTime.Value.ToString("yyyy/MM/dd") : "");
			obj.CommPayTypeId = wSPreOrderCommissions2.CommPayTypeId;
			obj.CommStatusId = wSPreOrderCommissions2.CommStatusId;
			obj.CommDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
			obj.CommDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
			obj.FirstRegisterUserId = wSPreOrderCommissions2.FirstRegisterUserId;
			obj.FirstRegisterDate = wSPreOrderCommissions2.FirstRegisterDate;
			obj.UserId = wSPreOrderCommissions2.UserId;
			obj.RegisterDate = wSPreOrderCommissions2.RegisterDate;
			obj.AppType = wSPreOrderCommissions2.AppType;
			obj.CommDateTime = wSPreOrderCommissions2.CommDateTime;
			obj.CommEffectiveDateTime = wSPreOrderCommissions2.CommEffectiveDateTime;
			obj.CommAmountCurrencyRate = wSPreOrderCommissions2.CommAmountCurrencyRate;
			obj.CommAmountCurrUnId = wSPreOrderCommissions2.CommAmountCurrUnId;
			wSPreOrderCommissionsLanguageViewModel = obj;
		}
		SetRegisterInfo(wSPreOrderCommissionsLanguageViewModel);
		string companyName = GetCompanyName(cmpId);
		base.ViewBag.CompanyName = companyName;
		GetCommUser();
		GetPayType();
		GetCurrencyUnit();
		return View(wSPreOrderCommissionsLanguageViewModel);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	[DynamicAuthorize(ControllerName = "frmCommissionDataEntry", ActionName = "actPost")]
	public ActionResult InsertEdit(WSPreOrderCommissionsLanguageViewModel vm)
	{
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0301: Unknown result type (might be due to invalid IL or missing references)
		//IL_0355: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass5_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		GetCommUser();
		GetPayType();
		GetCurrencyUnit();
		string companyName = GetCompanyName(CS_0024_003C_003E8__locals0.vm.CommCmpId);
		base.ViewBag.CompanyName = companyName;
		if (CS_0024_003C_003E8__locals0.vm.PreOrderCommissionId <= 0 && !VersionBuyer.Commissions)
		{
			DbSet<WSPreOrderCommissions> wSPreOrderCommissions = _dbTbl.WSPreOrderCommissions;
			ParameterExpression val = Expression.Parameter(typeof(WSPreOrderCommissions), "c");
			if (Queryable.Any<WSPreOrderCommissions>((IQueryable<WSPreOrderCommissions>)wSPreOrderCommissions, Expression.Lambda<Func<WSPreOrderCommissions, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)10, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val })))
			{
				base.ViewBag.Error = "BV|" + string.Format(Messages.VersionBuyWithCount, "10");
				SetRegisterInfo(CS_0024_003C_003E8__locals0.vm);
				return View(CS_0024_003C_003E8__locals0.vm);
			}
		}
		if (!PreOrder.CanChangeCommissionByOtherUser(CS_0024_003C_003E8__locals0.vm.CommPreOrderId))
		{
			base.ViewBag.Error = string.Format(Messages.msgErrorChangeCommissionByUnRelatedUser, Labels.lblPOrd);
			SetRegisterInfo(CS_0024_003C_003E8__locals0.vm);
			return View(CS_0024_003C_003E8__locals0.vm);
		}
		if (!base.ModelState.IsValid)
		{
			base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
		}
		else
		{
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.CommBaseAmountDecDesc_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.CommBaseAmountDecDesc_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.CommBaseAmountDecDesc,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.CommRateDesc_Lang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.CommRateDesc_Lang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.CommRateDesc,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.CommDesc_Lang))
			{
				list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.CommDesc_Lang);
			}
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.CommDesc,
				LanguageId = lCID
			});
			try
			{
				CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
				DateTime now = DateTime.Now;
				DateTime dateTime = default(DateTime);
				string text = "";
				try
				{
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.CommDatePersian))
					{
						CS_0024_003C_003E8__locals0.vm.CommDatePersian = CS_0024_003C_003E8__locals0.vm.CommDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
							.Replace(".", "")
							.Replace(",", "")
							.Replace("\\", "");
						text = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.vm.CommDatePersian.Replace("/", ""));
						text = text + " " + DateTime.Now.ToString("HH:mm:ss");
						switch (lCID)
						{
						case 1065:
							dateTime = DateTime.Parse(text, new PersianCulture());
							CS_0024_003C_003E8__locals0.vm.CommDatePersian = dateTime.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime = DateTime.Parse(text, new CultureInfo("ar-SA"));
							CS_0024_003C_003E8__locals0.vm.CommDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime = DateTime.Parse(text, new CultureInfo("en-US"));
							CS_0024_003C_003E8__locals0.vm.CommDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						CS_0024_003C_003E8__locals0.vm.CommDateTime = dateTime;
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					base.ViewBag.Error = string.Format(Messages.ErrorInFormat, Labels.PordCommDatePersian);
					return View(CS_0024_003C_003E8__locals0.vm);
				}
				try
				{
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.CommEffectiveDatePersian))
					{
						CS_0024_003C_003E8__locals0.vm.CommEffectiveDatePersian = CS_0024_003C_003E8__locals0.vm.CommEffectiveDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
							.Replace(".", "")
							.Replace(",", "")
							.Replace("\\", "");
						text = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.vm.CommEffectiveDatePersian.Replace("/", ""));
						text = text + " " + DateTime.Now.ToString("HH:mm:ss");
						switch (lCID)
						{
						case 1065:
							dateTime = DateTime.Parse(text, new PersianCulture());
							CS_0024_003C_003E8__locals0.vm.CommEffectiveDatePersian = dateTime.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime = DateTime.Parse(text, new CultureInfo("ar-SA"));
							CS_0024_003C_003E8__locals0.vm.CommEffectiveDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime = DateTime.Parse(text, new CultureInfo("en-US"));
							CS_0024_003C_003E8__locals0.vm.CommEffectiveDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						CS_0024_003C_003E8__locals0.vm.CommEffectiveDateTime = dateTime;
					}
					else
					{
						CS_0024_003C_003E8__locals0.vm.CommEffectiveDatePersian = null;
						CS_0024_003C_003E8__locals0.vm.CommEffectiveDateTime = ((!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.CommEffectiveDatePersian)) ? new DateTime?(now) : null);
					}
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
					base.ViewBag.Error = string.Format(Messages.ErrorInFormat, Labels.PordCommEffectiveDate);
					return View(CS_0024_003C_003E8__locals0.vm);
				}
				WSPreOrderCommissions wSPreOrderCommissions2 = new WSPreOrderCommissions();
				if (CS_0024_003C_003E8__locals0.vm.PreOrderCommissionId > 0)
				{
					DbSet<WSPreOrderCommissions> wSPreOrderCommissions3 = _dbTbl.WSPreOrderCommissions;
					ParameterExpression val = Expression.Parameter(typeof(WSPreOrderCommissions), "c");
					wSPreOrderCommissions2 = Queryable.FirstOrDefault<WSPreOrderCommissions>((IQueryable<WSPreOrderCommissions>)wSPreOrderCommissions3, Expression.Lambda<Func<WSPreOrderCommissions, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass5_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				wSPreOrderCommissions2.RegisterDate = now;
				wSPreOrderCommissions2.UserId = currentUser.UserId;
				wSPreOrderCommissions2.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				wSPreOrderCommissions2.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
				wSPreOrderCommissions2.AppType = Configuration.AppType;
				wSPreOrderCommissions2.Year1 = short.Parse(Financial.Get().Id.ToString());
				wSPreOrderCommissions2.CommDateTime = CS_0024_003C_003E8__locals0.vm.CommDateTime;
				wSPreOrderCommissions2.CommDatePersian = CS_0024_003C_003E8__locals0.vm.CommDatePersian;
				wSPreOrderCommissions2.CommPreOrderId = CS_0024_003C_003E8__locals0.vm.CommPreOrderId;
				wSPreOrderCommissions2.CommCmpId = CS_0024_003C_003E8__locals0.vm.CommCmpId;
				wSPreOrderCommissions2.CommUserId = CS_0024_003C_003E8__locals0.vm.CommUserId;
				wSPreOrderCommissions2.CommBaseAmountDecDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				wSPreOrderCommissions2.CommRate = CS_0024_003C_003E8__locals0.vm.CommRate;
				wSPreOrderCommissions2.CommRateDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				wSPreOrderCommissions2.CommAmount = CS_0024_003C_003E8__locals0.vm.CommAmount;
				wSPreOrderCommissions2.CommEffectiveDateTime = CS_0024_003C_003E8__locals0.vm.CommEffectiveDateTime;
				wSPreOrderCommissions2.CommEffectiveDatePersian = CS_0024_003C_003E8__locals0.vm.CommEffectiveDatePersian;
				wSPreOrderCommissions2.CommPayTypeId = CS_0024_003C_003E8__locals0.vm.CommPayTypeId;
				wSPreOrderCommissions2.CommDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				wSPreOrderCommissions2.CommAmountCurrUnId = CS_0024_003C_003E8__locals0.vm.CommAmountCurrUnId;
				wSPreOrderCommissions2.CommAmountCurrencyRate = CS_0024_003C_003E8__locals0.vm.CommAmountCurrencyRate;
				if (UserLogin.IsUserAccess("frmCommissionDataEntry", "actCanChangeCommBaseAmount", currentUser))
				{
					wSPreOrderCommissions2.CommBaseAmount = CS_0024_003C_003E8__locals0.vm.CommBaseAmount;
				}
				else if (wSPreOrderCommissions2.CommBaseAmount == 0m)
				{
					wSPreOrderCommissions2.CommBaseAmount = CS_0024_003C_003E8__locals0.vm.CommBaseAmount;
				}
				if (UserLogin.IsUserAccess("frmCommissionDataEntry", "actCanChangeCommBaseAmountDec", currentUser))
				{
					wSPreOrderCommissions2.CommBaseAmountDec = CS_0024_003C_003E8__locals0.vm.CommBaseAmountDec;
				}
				if (CS_0024_003C_003E8__locals0.vm.PreOrderCommissionId > 0)
				{
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.Entry(wSPreOrderCommissions2).State = EntityState.Modified;
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					_dbTbl.SaveChanges();
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass5_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass5_1();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							DbSet<WSPreOrderCommissions_Lang> wSPreOrderCommissions_Lang = _dbTbl.WSPreOrderCommissions_Lang;
							ParameterExpression val = Expression.Parameter(typeof(WSPreOrderCommissions_Lang), "c");
							WSPreOrderCommissions_Lang wSPreOrderCommissions_Lang2 = Queryable.FirstOrDefault<WSPreOrderCommissions_Lang>((IQueryable<WSPreOrderCommissions_Lang>)wSPreOrderCommissions_Lang, Expression.Lambda<Func<WSPreOrderCommissions_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass5_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass5_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (wSPreOrderCommissions_Lang2 != null)
							{
								wSPreOrderCommissions_Lang2.CommBaseAmountDecDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSPreOrderCommissions_Lang2.CommRateDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSPreOrderCommissions_Lang2.CommDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(wSPreOrderCommissions_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							wSPreOrderCommissions_Lang2 = new WSPreOrderCommissions_Lang();
							wSPreOrderCommissions_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
							wSPreOrderCommissions_Lang2.PreOrderCommissionId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.vm.PreOrderCommissionId;
							wSPreOrderCommissions_Lang2.CommBaseAmountDecDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							wSPreOrderCommissions_Lang2.CommRateDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							wSPreOrderCommissions_Lang2.CommDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							_dbTbl.WSPreOrderCommissions_Lang.Add(wSPreOrderCommissions_Lang2);
							_dbTbl.SaveChanges();
						}
					}
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
				else
				{
					wSPreOrderCommissions2.FirstRegisterUserId = currentUser.UserId;
					wSPreOrderCommissions2.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					wSPreOrderCommissions2.FirstRegisterDate = now;
					wSPreOrderCommissions2.GUId = Guid.NewGuid();
					wSPreOrderCommissions2.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
					wSPreOrderCommissions2.CommBaseAmount = CS_0024_003C_003E8__locals0.vm.CommBaseAmount;
					wSPreOrderCommissions2.CommBaseAmountDec = CS_0024_003C_003E8__locals0.vm.CommBaseAmountDec;
					wSPreOrderCommissions2.CommCId = PreOrder.GetPordCId(wSPreOrderCommissions2.CommPreOrderId);
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.WSPreOrderCommissions.Add(wSPreOrderCommissions2);
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					_dbTbl.SaveChanges();
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
					{
						WSPreOrderCommissions_Lang wSPreOrderCommissions_Lang3 = new WSPreOrderCommissions_Lang();
						wSPreOrderCommissions_Lang3.LanguageID = lang.LanguageID;
						wSPreOrderCommissions_Lang3.PreOrderCommissionId = wSPreOrderCommissions2.PreOrderCommissionId;
						wSPreOrderCommissions_Lang3.CommBaseAmountDecDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSPreOrderCommissions_Lang3.CommRateDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSPreOrderCommissions_Lang3.CommDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						_dbTbl.WSPreOrderCommissions_Lang.Add(wSPreOrderCommissions_Lang3);
						_dbTbl.SaveChanges();
					}
					base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
				}
				CS_0024_003C_003E8__locals0.vm.AppType = wSPreOrderCommissions2.AppType;
				CS_0024_003C_003E8__locals0.vm.UserId = wSPreOrderCommissions2.UserId;
				CS_0024_003C_003E8__locals0.vm.FirstRegisterUserId = wSPreOrderCommissions2.FirstRegisterUserId;
				CS_0024_003C_003E8__locals0.vm.FirstRegisterDate = wSPreOrderCommissions2.FirstRegisterDate;
				CS_0024_003C_003E8__locals0.vm.RegisterDate = wSPreOrderCommissions2.RegisterDate;
			}
			catch (DbEntityValidationException ex)
			{
				ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
				base.ViewBag.Error = Messages.frmErrorMessage + "<br/>" + ((Exception)(object)ex).Message;
			}
			catch (Exception ex2)
			{
				ErrorSignal.FromCurrentContext().Raise(ex2);
				base.ViewBag.Error = Messages.frmErrorMessage + "<br/>" + ex2.Message;
			}
		}
		SetRegisterInfo(CS_0024_003C_003E8__locals0.vm);
		return View(CS_0024_003C_003E8__locals0.vm);
	}

	public string GetCompanyName(int cmpId)
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
			CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(cmpId);
			if (companyById != null)
			{
				result = companyById.CompanyName ?? "";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
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
	public JsonResult GetPayType()
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<WSspSelectOrderCommissionPayTypes_Result, SelectListItem>((IEnumerable<WSspSelectOrderCommissionPayTypes_Result>)Enumerable.ToList<WSspSelectOrderCommissionPayTypes_Result>((IEnumerable<WSspSelectOrderCommissionPayTypes_Result>)_db.WSspSelectOrderCommissionPayTypes(lCID, result)), (Func<WSspSelectOrderCommissionPayTypes_Result, SelectListItem>)((WSspSelectOrderCommissionPayTypes_Result item) => new SelectListItem
			{
				Text = item.CommPayTypeTitle,
				Value = item.OrderCommissionPayTypeId.ToString()
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
		base.ViewBag.CurrencyUnitList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult ReturnPreOrderCommissionBaseAmount(int pordId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		WSspReturnPreOrderCommissionBaseAmount_Result data = new WSspReturnPreOrderCommissionBaseAmount_Result();
		try
		{
			data = Enumerable.FirstOrDefault<WSspReturnPreOrderCommissionBaseAmount_Result>((IEnumerable<WSspReturnPreOrderCommissionBaseAmount_Result>)_db.WSspReturnPreOrderCommissionBaseAmount(pordId)) ?? new WSspReturnPreOrderCommissionBaseAmount_Result
			{
				SumPriceAmount = default(decimal),
				SumPrice = default(decimal),
				SumQuantity = 0.0,
				SumDiscount = default(decimal),
				SumDiscountQty = default(decimal),
				SumDiscountI = default(decimal),
				pordDiscount = default(decimal),
				pordTax = default(decimal),
				pordTotalAmount = default(decimal),
				CommBaseAmount = default(decimal)
			};
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	public void SetRegisterInfo(WSPreOrderCommissionsLanguageViewModel model)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		string text2 = "";
		string text3 = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (model.PreOrderCommissionId > 0)
			{
				if (model.FirstRegisterUserId == currentUser.UserId)
				{
					text = currentUser.FullName;
				}
				else
				{
					CRMspSelectUsersById_Result cRMspSelectUsersById_Result = CRMIdeal.Classes.Helper.User.SelectUsersById(model.FirstRegisterUserId);
					text = ((cRMspSelectUsersById_Result != null) ? (cRMspSelectUsersById_Result.LName + ((cRMspSelectUsersById_Result.FName != null) ? (" " + cRMspSelectUsersById_Result.FName) : "")) : "");
				}
				if (model.UserId == currentUser.UserId)
				{
					text2 = currentUser.FullName;
				}
				else
				{
					CRMspSelectUsersById_Result cRMspSelectUsersById_Result2 = CRMIdeal.Classes.Helper.User.SelectUsersById(model.UserId);
					text2 = ((cRMspSelectUsersById_Result2 != null) ? (cRMspSelectUsersById_Result2.LName + ((cRMspSelectUsersById_Result2.FName != null) ? (" " + cRMspSelectUsersById_Result2.FName) : "")) : "");
				}
				if (string.IsNullOrEmpty(model.AppType))
				{
					model.AppType = Configuration.AppType;
				}
				text3 = Configuration.GetAppType(model.AppType);
			}
			else
			{
				text = currentUser.FullName;
				text2 = "";
				text3 = Configuration.GetAppType(Configuration.AppType);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		model.RegisterInfo = text2 + ((!string.IsNullOrEmpty(text3)) ? (" (" + Labels.AppType + ": " + text3 + ")") : "") + " " + model.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
		model.FirstRegisterInfo = text + " " + model.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
	}

	[AjaxOnly]
	public string GetDateBefore(string date)
	{
		string result = "-1";
		try
		{
			result = PersianDate.GetInsertedDays2Date(date.Replace("-", "").Replace("/", ""), -3.0);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actDeleteComm")]
	public string Delete(int id)
	{
		_003C_003Ec__DisplayClass13_0 _003C_003Ec__DisplayClass13_ = new _003C_003Ec__DisplayClass13_0();
		_003C_003Ec__DisplayClass13_.id = id;
		string result = "";
		try
		{
			if (!UserLogin.IsUserAccess("frmPreOrder", "actDeleteComm", UserLogin.CurrentUser))
			{
				return Messages.DoNotHaveAccess;
			}
			DbSet<WSPreOrderCommissions> wSPreOrderCommissions = _dbTbl.WSPreOrderCommissions;
			ParameterExpression val = Expression.Parameter(typeof(WSPreOrderCommissions), "c");
			WSPreOrderCommissions wSPreOrderCommissions2 = Queryable.FirstOrDefault<WSPreOrderCommissions>((IQueryable<WSPreOrderCommissions>)wSPreOrderCommissions, Expression.Lambda<Func<WSPreOrderCommissions, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass13_, typeof(_003C_003Ec__DisplayClass13_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (wSPreOrderCommissions2 != null)
			{
				if (!PreOrder.CanChangeCommissionByOtherUser(wSPreOrderCommissions2.CommPreOrderId))
				{
					return string.Format(Messages.msgErrorChangeCommissionByUnRelatedUser, Labels.lblPOrd);
				}
				try
				{
					TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.RequiresNew, new TransactionOptions
					{
						IsolationLevel = IsolationLevel.ReadUncommitted
					});
					using (transactionScope)
					{
						mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeletePreOrderCommission(_003C_003Ec__DisplayClass13_.id));
						if (mct_Result != null && mct_Result.Result > 0)
						{
							result = "";
						}
						else if (mct_Result != null && mct_Result.Result == 0)
						{
							result = Messages.RedundancyMessage;
						}
						transactionScope.Complete();
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
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			result = Messages.frmErrorMessage + " - " + ex2.Message;
		}
		return result;
	}

	[AjaxOnly]
	public string Verify(int id)
	{
		string result = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmPreOrder", "actVerifyComm", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			int userId = currentUser.UserId;
			DateTime now = DateTime.Now;
			string verifiedDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			_db.WSspPreOrderCommissionVerify(id, userId, now, verifiedDatePersian);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.frmErrorMessage;
		}
		return result;
	}

	[AjaxOnly]
	public string ExitVerify(int id)
	{
		string result = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmPreOrder", "actExitVerifyComm", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			_db.WSspPreOrderCommissionVerifyExit(id);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.frmErrorMessage;
		}
		return result;
	}

	[AjaxOnly]
	public string TransferPordCommToOrdOneToOne(int commId, int ordId, int pordid = 0)
	{
		string result = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmPreOrder", "actTransferPreOrderCommToOrderOneToOne", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			int userId = currentUser.UserId;
			DateTime now = DateTime.Now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short value = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			_db.WSspTransferPreOrderCommissionToOrderOneToOne(commId, userId, id, value, now, registerDatePersian, appType, ordId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.frmErrorMessage;
		}
		return result;
	}

	[AjaxOnly]
	public string TransferPordCommToOrdAll(int pordid, int ordId)
	{
		string result = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmPreOrder", "actTransferPreOrderCommToOrderAll", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			int userId = currentUser.UserId;
			DateTime now = DateTime.Now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short value = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			_db.WSspTransferPreOrderCommissionToOrderAll(pordid, userId, id, value, now, registerDatePersian, appType, ordId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.frmErrorMessage;
		}
		return result;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		base.Dispose(disposing);
	}
}

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

namespace CRMIdeal.Areas.Orders.Controllers;

public class CommissionController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass17_0
	{
		public int id;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_0
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
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public WSOrderCommissionsLanguageViewModel vm;

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
	private sealed class _003C_003Ec__DisplayClass8_1
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals1;

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

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	private readonly CRMSpIIIEntities _dbIII = new CRMSpIIIEntities();

	public List<WSspSelectOrderCommissions_Result> GetOrderCommission(int ordId, bool isShowAllUser)
	{
		//IL_03ec: Unknown result type (might be due to invalid IL or missing references)
		List<WSspSelectOrderCommissions_Result> list = new List<WSspSelectOrderCommissions_Result>();
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
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			int num = 0;
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				num = cRMspSelectCrmsysSetting_Result.LinkAccSystemId.GetValueOrDefault();
			}
			List<CRMspSelectLinkAccSettingDBIsActive_Result> list2 = new List<CRMspSelectLinkAccSettingDBIsActive_Result>();
			if (num == 1)
			{
				list2 = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDBList(1);
			}
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			list = Enumerable.ToList<WSspSelectOrderCommissions_Result>((IEnumerable<WSspSelectOrderCommissions_Result>)_db.WSspSelectOrderCommissions(ordId, value, userId, lCID, result, centerId));
			foreach (WSspSelectOrderCommissions_Result item in list)
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
				item.CommPreVerifiedDatePersian = (item.CommPreVerifiedDate.HasValue ? item.CommPreVerifiedDate.Value.ToString("yyyy/MM/dd") : "");
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
				if (!string.IsNullOrWhiteSpace(item.CommTypePrs))
				{
					item.CommTypeCmp = item.CommTypeCmp + " (" + item.CommTypePrs + ")";
				}
				if (num != 1)
				{
					continue;
				}
				List<CommLinkAccDataViewModel> list3 = new List<CommLinkAccDataViewModel>();
				if (!string.IsNullOrWhiteSpace(item.CommLinkAccData))
				{
					foreach (CommLinkAccDataViewModel item2 in new JavaScriptSerializer().Deserialize<List<CommLinkAccDataViewModel>>(item.CommLinkAccData))
					{
						int dbId = 0;
						int.TryParse(item2.DBId.ToString(), out dbId);
						if (dbId == 0 || list2 == null || !Enumerable.Any<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)list2))
						{
							continue;
						}
						CRMspSelectLinkAccSettingDBIsActive_Result cRMspSelectLinkAccSettingDBIsActive_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)list2, (Func<CRMspSelectLinkAccSettingDBIsActive_Result, bool>)((CRMspSelectLinkAccSettingDBIsActive_Result m) => m.LinkAccSettingDBId == dbId));
						if (cRMspSelectLinkAccSettingDBIsActive_Result == null)
						{
							continue;
						}
						item2.DbName = cRMspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbName ?? "";
						item2.DbTitle = cRMspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbTitle ?? "";
						string text = "";
						if (!string.IsNullOrWhiteSpace(item2.Number) && (item2.Number ?? "0") != "0")
						{
							text += string.Format(Labels.OrdCommListAccLinkHeaderNumber, item2.Number);
						}
						if (!string.IsNullOrWhiteSpace(item2.VoucherNumber) && (item2.VoucherNumber ?? "0") != "0")
						{
							if (!string.IsNullOrWhiteSpace(text))
							{
								text += ", ";
							}
							text += string.Format(Labels.OrdCommListAccLinkVoucherNumber, item2.VoucherNumber);
						}
						if (!string.IsNullOrWhiteSpace(item2.DetailId) && (item2.DetailId ?? "0") != "0")
						{
							if (!string.IsNullOrWhiteSpace(text))
							{
								text += ", ";
							}
							text += string.Format(Labels.OrdCommListAccLinkDetailId, item2.DetailId);
						}
						if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(item2.DbTitle))
						{
							text = text + " (" + item2.DbTitle + ")";
						}
						item2.CommInfoWithLbl = text;
						list3.Add(item2);
					}
				}
				item.CommLinkAccData = "";
				if (list3 != null && Enumerable.Any<CommLinkAccDataViewModel>((IEnumerable<CommLinkAccDataViewModel>)list3))
				{
					item.CommLinkAccData = JsonConvert.SerializeObject(Enumerable.ToList<CommLinkAccDataViewModel>((IEnumerable<CommLinkAccDataViewModel>)list3));
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

	public ActionResult Commission_Read([DataSourceRequest] DataSourceRequest request, int ordId, bool isShowAllUser)
	{
		List<WSspSelectOrderCommissions_Result> enumerable = new List<WSspSelectOrderCommissions_Result>();
		try
		{
			enumerable = GetOrderCommission(ordId, isShowAllUser);
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

	[DynamicAuthorize(ControllerName = "frmOrder", ActionName = "actInsertComm,actEdtiComm")]
	public ActionResult InsertEdit(int commId, int ordId, int cmpId)
	{
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass7_0();
		CS_0024_003C_003E8__locals0.commId = commId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		WSOrderCommissionsLanguageViewModel wSOrderCommissionsLanguageViewModel = new WSOrderCommissionsLanguageViewModel();
		DateTime now = DateTime.Now;
		if (CS_0024_003C_003E8__locals0.commId == 0)
		{
			wSOrderCommissionsLanguageViewModel = new WSOrderCommissionsLanguageViewModel
			{
				CommOrderId = Convert.ToInt32(ordId),
				CommCmpId = Convert.ToInt32(cmpId),
				CommDatePersian = now.ToString("yyyy/MM/dd"),
				FirstRegisterDate = now,
				RegisterDate = now,
				CommDateTime = now,
				CommEffectiveDateTime = now,
				CommKindId = 1,
				CommTypeId = 1
			};
			base.ViewBag.IsBuying = VersionBuyer.Commissions;
		}
		else
		{
			DbSet<WSOrderCommissions_Lang> wSOrderCommissions_Lang = _dbTbl.WSOrderCommissions_Lang;
			ParameterExpression val = Expression.Parameter(typeof(WSOrderCommissions_Lang), "c");
			List<WSOrderCommissions_Lang> list = Enumerable.ToList<WSOrderCommissions_Lang>((IEnumerable<WSOrderCommissions_Lang>)Queryable.Where<WSOrderCommissions_Lang>((IQueryable<WSOrderCommissions_Lang>)wSOrderCommissions_Lang, Expression.Lambda<Func<WSOrderCommissions_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass7_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			DbSet<WSOrderCommissions> wSOrderCommissions = _dbTbl.WSOrderCommissions;
			val = Expression.Parameter(typeof(WSOrderCommissions), "c");
			WSOrderCommissions wSOrderCommissions2 = Queryable.FirstOrDefault<WSOrderCommissions>((IQueryable<WSOrderCommissions>)wSOrderCommissions, Expression.Lambda<Func<WSOrderCommissions, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass7_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) ?? new WSOrderCommissions();
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrderCommissions_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrderCommissions_Lang>)list, (Func<WSOrderCommissions_Lang, CommonMultiLanguageViewModel>)((WSOrderCommissions_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.CommBaseAmountDecDesc,
				LanguageId = item.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = wSOrderCommissions2.CommBaseAmountDecDesc,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrderCommissions_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrderCommissions_Lang>)list, (Func<WSOrderCommissions_Lang, CommonMultiLanguageViewModel>)((WSOrderCommissions_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.CommRateDesc,
				LanguageId = item.LanguageID
			})));
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = wSOrderCommissions2.CommRateDesc,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrderCommissions_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrderCommissions_Lang>)list, (Func<WSOrderCommissions_Lang, CommonMultiLanguageViewModel>)((WSOrderCommissions_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.CommDesc,
				LanguageId = item.LanguageID
			})));
			list4.Add(new CommonMultiLanguageViewModel
			{
				Value = wSOrderCommissions2.CommDesc,
				LanguageId = result
			});
			WSOrderCommissionsLanguageViewModel obj = new WSOrderCommissionsLanguageViewModel
			{
				OrderCommissionId = wSOrderCommissions2.OrderCommissionId
			};
			_ = wSOrderCommissions2.CommDateTime;
			obj.CommDatePersian = wSOrderCommissions2.CommDateTime.ToString("yyyy/MM/dd");
			obj.CommOrderId = wSOrderCommissions2.CommOrderId;
			obj.CommCmpId = wSOrderCommissions2.CommCmpId;
			obj.CommUserId = wSOrderCommissions2.CommUserId;
			obj.CommBaseAmountDec = wSOrderCommissions2.CommBaseAmountDec;
			obj.CommBaseAmountDecDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
			obj.CommBaseAmountDecDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
			obj.CommBaseAmount = wSOrderCommissions2.CommBaseAmount;
			obj.CommRate = wSOrderCommissions2.CommRate;
			obj.CommRateDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
			obj.CommRateDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
			obj.CommAmount = wSOrderCommissions2.CommAmount;
			obj.CommEffectiveDatePersian = (wSOrderCommissions2.CommEffectiveDateTime.HasValue ? wSOrderCommissions2.CommEffectiveDateTime.Value.ToString("yyyy/MM/dd") : "");
			obj.CommPayTypeId = wSOrderCommissions2.CommPayTypeId;
			obj.CommStatusId = wSOrderCommissions2.CommStatusId;
			obj.CommDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
			obj.CommDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
			obj.FirstRegisterUserId = wSOrderCommissions2.FirstRegisterUserId;
			obj.FirstRegisterDate = wSOrderCommissions2.FirstRegisterDate;
			obj.UserId = wSOrderCommissions2.UserId;
			obj.RegisterDate = wSOrderCommissions2.RegisterDate;
			obj.AppType = wSOrderCommissions2.AppType;
			obj.CommDateTime = wSOrderCommissions2.CommDateTime;
			obj.CommEffectiveDateTime = wSOrderCommissions2.CommEffectiveDateTime;
			obj.CommAmountCurrUnId = wSOrderCommissions2.CommAmountCurrUnId;
			obj.CommAmountCurrencyRate = wSOrderCommissions2.CommAmountCurrencyRate;
			obj.CommBaseAmountDecPercent = wSOrderCommissions2.CommBaseAmountDecPercent;
			obj.CommKindId = wSOrderCommissions2.CommKindId;
			obj.CommTypeId = wSOrderCommissions2.CommTypeId;
			obj.CommTypeCmpId = wSOrderCommissions2.CommTypeCmpId;
			obj.CommTypePrsId = wSOrderCommissions2.CommTypePrsId;
			wSOrderCommissionsLanguageViewModel = obj;
		}
		SetRegisterInfo(wSOrderCommissionsLanguageViewModel);
		GetCommUser();
		GetPayType();
		GetCurrencyUnit();
		GetCommType();
		GetCommKind();
		string companyName = GetCompanyName(cmpId);
		base.ViewBag.CompanyName = companyName;
		string text = "";
		int num = 0;
		int num2 = 0;
		if (wSOrderCommissionsLanguageViewModel != null)
		{
			num = wSOrderCommissionsLanguageViewModel.CommTypeCmpId.GetValueOrDefault();
			num2 = wSOrderCommissionsLanguageViewModel.CommTypePrsId.GetValueOrDefault();
		}
		if (num != 0)
		{
			CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(num);
			if (companyById != null)
			{
				text = companyById.cmpTitle ?? "";
				if (!string.IsNullOrWhiteSpace(text))
				{
					text += " ";
				}
				text += companyById.cmpName;
			}
		}
		if (num2 != 0)
		{
			CRMspSelectCompanyPersonsByID_Result cRMspSelectCompanyPersonsByID_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonsByID_Result>((IEnumerable<CRMspSelectCompanyPersonsByID_Result>)_db.CRMspSelectCompanyPersonsByID(num2, CS_0024_003C_003E8__locals0.currLangID, result));
			if (cRMspSelectCompanyPersonsByID_Result != null)
			{
				string text2 = "";
				text2 = cRMspSelectCompanyPersonsByID_Result.PersonName ?? "";
				if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(text2))
				{
					text = text + text + " ";
				}
				if (!string.IsNullOrWhiteSpace(text2))
				{
					text = text + text + "(" + text2 + ")";
				}
			}
		}
		base.ViewBag.CmpId = num;
		base.ViewBag.PrsId = num2;
		base.ViewBag.CmpFullName = text;
		return View(wSOrderCommissionsLanguageViewModel);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	[DynamicAuthorize(ControllerName = "frmCommissionDataEntry", ActionName = "actPost")]
	public ActionResult InsertEdit(WSOrderCommissionsLanguageViewModel vm)
	{
		//IL_05a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_064a: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass8_0();
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
		GetCommType();
		GetCommKind();
		string companyName = GetCompanyName(CS_0024_003C_003E8__locals0.vm.CommCmpId);
		base.ViewBag.CompanyName = companyName;
		string text = "";
		int num = 0;
		int num2 = 0;
		if (CS_0024_003C_003E8__locals0.vm != null)
		{
			num = CS_0024_003C_003E8__locals0.vm.CommTypeCmpId.GetValueOrDefault();
			num2 = CS_0024_003C_003E8__locals0.vm.CommTypePrsId.GetValueOrDefault();
		}
		if (num != 0)
		{
			CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(num);
			if (companyById != null)
			{
				text = companyById.cmpTitle ?? "";
				if (!string.IsNullOrWhiteSpace(text))
				{
					text += " ";
				}
				text += companyById.cmpName;
			}
		}
		if (num2 != 0)
		{
			CRMspSelectCompanyPersonsByID_Result cRMspSelectCompanyPersonsByID_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonsByID_Result>((IEnumerable<CRMspSelectCompanyPersonsByID_Result>)_db.CRMspSelectCompanyPersonsByID(num2, lCID, CS_0024_003C_003E8__locals0.defLangID));
			if (cRMspSelectCompanyPersonsByID_Result != null)
			{
				string text2 = "";
				text2 = cRMspSelectCompanyPersonsByID_Result.PersonName ?? "";
				if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(text2))
				{
					text = text + text + " ";
				}
				if (!string.IsNullOrWhiteSpace(text2))
				{
					text = text + text + "(" + text2 + ")";
				}
			}
		}
		base.ViewBag.CmpId = num;
		base.ViewBag.PrsId = num2;
		base.ViewBag.CmpFullName = text;
		CS_0024_003C_003E8__locals0.vm.CommTypeCmpId = ((CS_0024_003C_003E8__locals0.vm.CommTypeCmpId.GetValueOrDefault() == 0) ? null : CS_0024_003C_003E8__locals0.vm.CommTypeCmpId);
		CS_0024_003C_003E8__locals0.vm.CommTypePrsId = ((CS_0024_003C_003E8__locals0.vm.CommTypePrsId.GetValueOrDefault() == 0) ? null : CS_0024_003C_003E8__locals0.vm.CommTypePrsId);
		CS_0024_003C_003E8__locals0.vm.CommUserId = ((CS_0024_003C_003E8__locals0.vm.CommUserId.GetValueOrDefault() == 0) ? null : CS_0024_003C_003E8__locals0.vm.CommUserId);
		if (CS_0024_003C_003E8__locals0.vm.OrderCommissionId <= 0 && !VersionBuyer.Commissions)
		{
			DbSet<WSOrderCommissions> wSOrderCommissions = _dbTbl.WSOrderCommissions;
			ParameterExpression val = Expression.Parameter(typeof(WSOrderCommissions), "c");
			if (Queryable.Any<WSOrderCommissions>((IQueryable<WSOrderCommissions>)wSOrderCommissions, Expression.Lambda<Func<WSOrderCommissions, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)10, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val })))
			{
				base.ViewBag.Error = "BV|" + string.Format(Messages.VersionBuyWithCount, "10");
				SetRegisterInfo(CS_0024_003C_003E8__locals0.vm);
				return View(CS_0024_003C_003E8__locals0.vm);
			}
		}
		if (!Order.CanChangeCommissionByOtherUser(CS_0024_003C_003E8__locals0.vm.CommOrderId))
		{
			base.ViewBag.Error = string.Format(Messages.msgErrorChangeCommissionByUnRelatedUser, "lblOrd".OrderLabels());
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
				string text3 = "";
				try
				{
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.CommDatePersian))
					{
						CS_0024_003C_003E8__locals0.vm.CommDatePersian = CS_0024_003C_003E8__locals0.vm.CommDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
							.Replace(".", "")
							.Replace(",", "")
							.Replace("\\", "");
						text3 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.vm.CommDatePersian.Replace("/", ""));
						text3 = text3 + " " + DateTime.Now.ToString("HH:mm:ss");
						switch (lCID)
						{
						case 1065:
							dateTime = DateTime.Parse(text3, new PersianCulture());
							CS_0024_003C_003E8__locals0.vm.CommDatePersian = dateTime.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime = DateTime.Parse(text3, new CultureInfo("ar-SA"));
							CS_0024_003C_003E8__locals0.vm.CommDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime = DateTime.Parse(text3, new CultureInfo("en-US"));
							CS_0024_003C_003E8__locals0.vm.CommDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						CS_0024_003C_003E8__locals0.vm.CommDateTime = dateTime;
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					base.ViewBag.Error = string.Format(Messages.ErrorInFormat, Labels.OrdCommDatePersian);
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
						text3 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.vm.CommEffectiveDatePersian.Replace("/", ""));
						text3 = text3 + " " + DateTime.Now.ToString("HH:mm:ss");
						switch (lCID)
						{
						case 1065:
							dateTime = DateTime.Parse(text3, new PersianCulture());
							CS_0024_003C_003E8__locals0.vm.CommEffectiveDatePersian = dateTime.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime = DateTime.Parse(text3, new CultureInfo("ar-SA"));
							CS_0024_003C_003E8__locals0.vm.CommEffectiveDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime = DateTime.Parse(text3, new CultureInfo("en-US"));
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
					base.ViewBag.Error = string.Format(Messages.ErrorInFormat, Labels.OrdCommEffectiveDate);
					return View(CS_0024_003C_003E8__locals0.vm);
				}
				WSOrderCommissions wSOrderCommissions2 = new WSOrderCommissions();
				if (CS_0024_003C_003E8__locals0.vm.OrderCommissionId > 0)
				{
					DbSet<WSOrderCommissions> wSOrderCommissions3 = _dbTbl.WSOrderCommissions;
					ParameterExpression val = Expression.Parameter(typeof(WSOrderCommissions), "c");
					wSOrderCommissions2 = Queryable.FirstOrDefault<WSOrderCommissions>((IQueryable<WSOrderCommissions>)wSOrderCommissions3, Expression.Lambda<Func<WSOrderCommissions, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				wSOrderCommissions2.RegisterDate = now;
				wSOrderCommissions2.UserId = currentUser.UserId;
				wSOrderCommissions2.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				wSOrderCommissions2.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
				wSOrderCommissions2.AppType = Configuration.AppType;
				wSOrderCommissions2.Year1 = short.Parse(Financial.Get().Id.ToString());
				wSOrderCommissions2.CommDateTime = CS_0024_003C_003E8__locals0.vm.CommDateTime;
				wSOrderCommissions2.CommDatePersian = CS_0024_003C_003E8__locals0.vm.CommDatePersian;
				wSOrderCommissions2.CommOrderId = CS_0024_003C_003E8__locals0.vm.CommOrderId;
				wSOrderCommissions2.CommCmpId = CS_0024_003C_003E8__locals0.vm.CommCmpId;
				wSOrderCommissions2.CommUserId = CS_0024_003C_003E8__locals0.vm.CommUserId;
				wSOrderCommissions2.CommKindId = CS_0024_003C_003E8__locals0.vm.CommKindId;
				wSOrderCommissions2.CommTypeId = CS_0024_003C_003E8__locals0.vm.CommTypeId;
				wSOrderCommissions2.CommTypeCmpId = CS_0024_003C_003E8__locals0.vm.CommTypeCmpId;
				wSOrderCommissions2.CommTypePrsId = CS_0024_003C_003E8__locals0.vm.CommTypePrsId;
				wSOrderCommissions2.CommBaseAmountDecDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				wSOrderCommissions2.CommRate = CS_0024_003C_003E8__locals0.vm.CommRate;
				wSOrderCommissions2.CommRateDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				wSOrderCommissions2.CommAmount = CS_0024_003C_003E8__locals0.vm.CommAmount;
				wSOrderCommissions2.CommEffectiveDateTime = CS_0024_003C_003E8__locals0.vm.CommEffectiveDateTime;
				wSOrderCommissions2.CommEffectiveDatePersian = CS_0024_003C_003E8__locals0.vm.CommEffectiveDatePersian;
				wSOrderCommissions2.CommPayTypeId = CS_0024_003C_003E8__locals0.vm.CommPayTypeId;
				wSOrderCommissions2.CommDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				wSOrderCommissions2.CommAmountCurrUnId = CS_0024_003C_003E8__locals0.vm.CommAmountCurrUnId;
				wSOrderCommissions2.CommAmountCurrencyRate = CS_0024_003C_003E8__locals0.vm.CommAmountCurrencyRate;
				if (UserLogin.IsUserAccess("frmCommissionDataEntry", "actCanChangeCommBaseAmount", currentUser))
				{
					wSOrderCommissions2.CommBaseAmount = CS_0024_003C_003E8__locals0.vm.CommBaseAmount;
				}
				else if (wSOrderCommissions2.CommBaseAmount == 0m)
				{
					wSOrderCommissions2.CommBaseAmount = CS_0024_003C_003E8__locals0.vm.CommBaseAmount;
				}
				if (UserLogin.IsUserAccess("frmCommissionDataEntry", "actCanChangeCommBaseAmountDec", currentUser))
				{
					wSOrderCommissions2.CommBaseAmountDec = CS_0024_003C_003E8__locals0.vm.CommBaseAmountDec;
					wSOrderCommissions2.CommBaseAmountDecPercent = CS_0024_003C_003E8__locals0.vm.CommBaseAmountDecPercent;
				}
				if (CS_0024_003C_003E8__locals0.vm.OrderCommissionId > 0)
				{
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.Entry(wSOrderCommissions2).State = EntityState.Modified;
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					_dbTbl.SaveChanges();
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass8_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass8_1();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							DbSet<WSOrderCommissions_Lang> wSOrderCommissions_Lang = _dbTbl.WSOrderCommissions_Lang;
							ParameterExpression val = Expression.Parameter(typeof(WSOrderCommissions_Lang), "c");
							WSOrderCommissions_Lang wSOrderCommissions_Lang2 = Queryable.FirstOrDefault<WSOrderCommissions_Lang>((IQueryable<WSOrderCommissions_Lang>)wSOrderCommissions_Lang, Expression.Lambda<Func<WSOrderCommissions_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass8_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass8_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (wSOrderCommissions_Lang2 != null)
							{
								wSOrderCommissions_Lang2.CommBaseAmountDecDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSOrderCommissions_Lang2.CommRateDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSOrderCommissions_Lang2.CommDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(wSOrderCommissions_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							wSOrderCommissions_Lang2 = new WSOrderCommissions_Lang();
							wSOrderCommissions_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
							wSOrderCommissions_Lang2.OrderCommissionId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.vm.OrderCommissionId;
							wSOrderCommissions_Lang2.CommBaseAmountDecDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							wSOrderCommissions_Lang2.CommRateDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							wSOrderCommissions_Lang2.CommDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							_dbTbl.WSOrderCommissions_Lang.Add(wSOrderCommissions_Lang2);
							_dbTbl.SaveChanges();
						}
					}
					Order.CalcAndSetOrderAmounts(CS_0024_003C_003E8__locals0.vm.CommOrderId);
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
				else
				{
					wSOrderCommissions2.FirstRegisterUserId = currentUser.UserId;
					wSOrderCommissions2.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					wSOrderCommissions2.FirstRegisterDate = now;
					wSOrderCommissions2.GUId = Guid.NewGuid();
					wSOrderCommissions2.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
					wSOrderCommissions2.CommBaseAmount = CS_0024_003C_003E8__locals0.vm.CommBaseAmount;
					wSOrderCommissions2.CommBaseAmountDec = CS_0024_003C_003E8__locals0.vm.CommBaseAmountDec;
					wSOrderCommissions2.CommBaseAmountDecPercent = CS_0024_003C_003E8__locals0.vm.CommBaseAmountDecPercent;
					wSOrderCommissions2.CommCId = Order.GetOrdCId(wSOrderCommissions2.CommOrderId);
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.WSOrderCommissions.Add(wSOrderCommissions2);
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					_dbTbl.SaveChanges();
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
					{
						WSOrderCommissions_Lang wSOrderCommissions_Lang3 = new WSOrderCommissions_Lang();
						wSOrderCommissions_Lang3.LanguageID = lang.LanguageID;
						wSOrderCommissions_Lang3.OrderCommissionId = wSOrderCommissions2.OrderCommissionId;
						wSOrderCommissions_Lang3.CommBaseAmountDecDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSOrderCommissions_Lang3.CommRateDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSOrderCommissions_Lang3.CommDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						_dbTbl.WSOrderCommissions_Lang.Add(wSOrderCommissions_Lang3);
						_dbTbl.SaveChanges();
					}
					Order.CalcAndSetOrderAmounts(CS_0024_003C_003E8__locals0.vm.CommOrderId);
					base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
				}
				CS_0024_003C_003E8__locals0.vm.AppType = wSOrderCommissions2.AppType;
				CS_0024_003C_003E8__locals0.vm.UserId = wSOrderCommissions2.UserId;
				CS_0024_003C_003E8__locals0.vm.FirstRegisterUserId = wSOrderCommissions2.FirstRegisterUserId;
				CS_0024_003C_003E8__locals0.vm.FirstRegisterDate = wSOrderCommissions2.FirstRegisterDate;
				CS_0024_003C_003E8__locals0.vm.RegisterDate = wSOrderCommissions2.RegisterDate;
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
			List<CRMspSelectUserForLinkedType_Result> list2 = Enumerable.ToList<CRMspSelectUserForLinkedType_Result>((IEnumerable<CRMspSelectUserForLinkedType_Result>)_db.CRMspSelectUserForLinkedType(UserLogin.CurrentUser.UserId, 21, lCID, result, result2));
			SelectListItem item2 = new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "",
				Selected = false
			};
			list.Add(item2);
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<CRMspSelectUserForLinkedType_Result, SelectListItem>((IEnumerable<CRMspSelectUserForLinkedType_Result>)list2, (Func<CRMspSelectUserForLinkedType_Result, SelectListItem>)((CRMspSelectUserForLinkedType_Result item) => new SelectListItem
				{
					Text = (item.UserName ?? ""),
					Value = item.LinkedUserId.ToString(),
					Selected = false
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CommUserList = list;
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
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
	public JsonResult GetCommType()
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<WSspSelectOrderCommissionTypes_Result, SelectListItem>((IEnumerable<WSspSelectOrderCommissionTypes_Result>)Enumerable.ToList<WSspSelectOrderCommissionTypes_Result>((IEnumerable<WSspSelectOrderCommissionTypes_Result>)_dbII.WSspSelectOrderCommissionTypes(lCID, result)), (Func<WSspSelectOrderCommissionTypes_Result, SelectListItem>)((WSspSelectOrderCommissionTypes_Result item) => new SelectListItem
			{
				Text = item.CommTypeTitle,
				Value = item.OrderCommissionTypeId.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CommTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCommKind()
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<WSspSelectOrderCommissionKinds_Result, SelectListItem>((IEnumerable<WSspSelectOrderCommissionKinds_Result>)Enumerable.ToList<WSspSelectOrderCommissionKinds_Result>((IEnumerable<WSspSelectOrderCommissionKinds_Result>)_dbII.WSspSelectOrderCommissionKinds(lCID, result)), (Func<WSspSelectOrderCommissionKinds_Result, SelectListItem>)((WSspSelectOrderCommissionKinds_Result item) => new SelectListItem
			{
				Text = item.CommKindTitle,
				Value = item.OrderCommissionKindId.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CommKindList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult ReturnOrderCommissionBaseAmount(int ordId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		WSspReturnOrderCommissionBaseAmount_Result data = new WSspReturnOrderCommissionBaseAmount_Result();
		try
		{
			data = Enumerable.FirstOrDefault<WSspReturnOrderCommissionBaseAmount_Result>((IEnumerable<WSspReturnOrderCommissionBaseAmount_Result>)_db.WSspReturnOrderCommissionBaseAmount(ordId)) ?? new WSspReturnOrderCommissionBaseAmount_Result
			{
				SumPriceAmount = default(decimal),
				SumPrice = default(decimal),
				SumQuantity = 0.0,
				SumDiscount = default(decimal),
				SumDiscountQty = default(decimal),
				SumDiscountI = default(decimal),
				ordDiscount = default(decimal),
				ordTax = default(decimal),
				ordTotalAmount = default(decimal),
				CommBaseAmount = default(decimal),
				ordGrossProfit = default(decimal),
				ordMoneySleep = default(decimal),
				ordNetProfit = default(decimal),
				ordSaleNetProfit = default(decimal)
			};
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	public void SetRegisterInfo(WSOrderCommissionsLanguageViewModel model)
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
			if (model.OrderCommissionId > 0)
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
	[DynamicAuthorize(ControllerName = "frmOrder", ActionName = "actDeleteComm")]
	public string Delete(int id)
	{
		_003C_003Ec__DisplayClass17_0 _003C_003Ec__DisplayClass17_ = new _003C_003Ec__DisplayClass17_0();
		_003C_003Ec__DisplayClass17_.id = id;
		string result = "";
		try
		{
			if (!UserLogin.IsUserAccess("frmOrder", "actDeleteComm", UserLogin.CurrentUser))
			{
				return Messages.DoNotHaveAccess;
			}
			DbSet<WSOrderCommissions> wSOrderCommissions = _dbTbl.WSOrderCommissions;
			ParameterExpression val = Expression.Parameter(typeof(WSOrderCommissions), "c");
			WSOrderCommissions wSOrderCommissions2 = Queryable.FirstOrDefault<WSOrderCommissions>((IQueryable<WSOrderCommissions>)wSOrderCommissions, Expression.Lambda<Func<WSOrderCommissions, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass17_, typeof(_003C_003Ec__DisplayClass17_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (wSOrderCommissions2 != null)
			{
				if (!Order.CanChangeCommissionByOtherUser(wSOrderCommissions2.CommOrderId))
				{
					return string.Format(Messages.msgErrorChangeCommissionByUnRelatedUser, "lblOrd".OrderLabels());
				}
				try
				{
					TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.RequiresNew, new TransactionOptions
					{
						IsolationLevel = IsolationLevel.ReadUncommitted
					});
					using (transactionScope)
					{
						mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)Enumerable.ToList<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteOrderCommission(_003C_003Ec__DisplayClass17_.id)));
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
					Order.CalcAndSetOrderAmounts(wSOrderCommissions2.CommOrderId);
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
		if (!UserLogin.IsUserAccess("frmOrder", "actVerifyComm", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			int userId = currentUser.UserId;
			DateTime now = DateTime.Now;
			string verifiedDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			_db.WSspOrderCommissionVerify(id, userId, now, verifiedDatePersian);
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
		if (!UserLogin.IsUserAccess("frmOrder", "actExitVerifyComm", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			_db.WSspOrderCommissionVerifyExit(id);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.frmErrorMessage;
		}
		return result;
	}

	[AjaxOnly]
	public string PreVerify(int commId)
	{
		string result = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmOrder", "actPreVerifyComm", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			int userId = currentUser.UserId;
			DateTime now = DateTime.Now;
			string preVerifiedDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			_dbIII.WSspOrderCommissionPreVerify(commId, userId, now, preVerifiedDatePersian);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.frmErrorMessage;
		}
		return result;
	}

	[AjaxOnly]
	public string ExitPreVerify(int commId)
	{
		string result = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmOrder", "actExitPreVerifyComm", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			_dbIII.WSspOrderCommissionPreVerifyExit(commId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.frmErrorMessage;
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmOrder", ActionName = "actInsertCommMulti")]
	public ActionResult InsertMultiComm(int ordId, int cmpId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		base.ViewBag.OrdId = ordId;
		base.ViewBag.CmpId = cmpId;
		string companyName = GetCompanyName(cmpId);
		base.ViewBag.CompanyName = companyName;
		GetCommUser();
		GetPayType();
		GetCurrencyUnit();
		GetCommType();
		GetCommKind();
		base.ViewBag.IsBuying = VersionBuyer.Commissions;
		return View();
	}

	[HttpPost]
	public JsonResult ActInsertMultiComm(string parameters)
	{
		//IL_0428: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_050a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0553: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		string text2 = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		CommonResultViewModel<string> data;
		if (!VersionBuyer.Commissions)
		{
			DbSet<WSOrderCommissions> wSOrderCommissions = _dbTbl.WSOrderCommissions;
			ParameterExpression val = Expression.Parameter(typeof(WSOrderCommissions), "c");
			if (Queryable.Any<WSOrderCommissions>((IQueryable<WSOrderCommissions>)wSOrderCommissions, Expression.Lambda<Func<WSOrderCommissions, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)10, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val })))
			{
				text = "";
				data = new CommonResultViewModel<string>
				{
					Data = text,
					Message = "BV|" + string.Format(Messages.VersionBuyWithCount, "10"),
					Status = CommonResultStatusViewModel.Error
				};
				return Json(data, JsonRequestBehavior.AllowGet);
			}
		}
		try
		{
			if (!string.IsNullOrWhiteSpace(parameters))
			{
				InsertMultiOrderCommissionsViewModel insertMultiOrderCommissionsViewModel = new JavaScriptSerializer().Deserialize<InsertMultiOrderCommissionsViewModel>(parameters);
				if (!Order.CanChangeCommissionByOtherUser(insertMultiOrderCommissionsViewModel.CommOrderId))
				{
					text = "";
					data = new CommonResultViewModel<string>
					{
						Data = text,
						Message = string.Format(Messages.msgErrorChangeCommissionByUnRelatedUser, "lblOrd".OrderLabels()),
						Status = CommonResultStatusViewModel.Error
					};
					return Json(data, JsonRequestBehavior.AllowGet);
				}
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
				if (defLangID <= 0)
				{
					defLangID = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				string orderCommJson = "";
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short value3 = short.Parse(Financial.Get().Id.ToString());
				int userId = UserLogin.CurrentUser.UserId;
				int id = Financial.Get().Id;
				string text3 = "";
				int num = 0;
				if (!UserLogin.IsUserAccess("frmOrder", "actInsertCommMulti", UserLogin.CurrentUser))
				{
					text3 = text3 + Messages.ErrorNotAccess + "<br>";
					num++;
				}
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(insertMultiOrderCommissionsViewModel.CommBaseAmountDecDesc_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(insertMultiOrderCommissionsViewModel.CommBaseAmountDecDesc_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = insertMultiOrderCommissionsViewModel.CommBaseAmountDecDesc,
					LanguageId = lCID
				});
				DateTime value4 = default(DateTime);
				DateTime dateTime = default(DateTime);
				string text4 = "";
				try
				{
					if (!string.IsNullOrEmpty(insertMultiOrderCommissionsViewModel.CommDatePersian))
					{
						insertMultiOrderCommissionsViewModel.CommDatePersian = insertMultiOrderCommissionsViewModel.CommDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
							.Replace(".", "")
							.Replace(",", "")
							.Replace("\\", "");
						text4 = PersianDate.GetFormatetdDate(insertMultiOrderCommissionsViewModel.CommDatePersian.Replace("/", ""));
						text4 = text4 + " " + DateTime.Now.ToString("HH:mm:ss");
						switch (lCID)
						{
						case 1065:
							dateTime = DateTime.Parse(text4, new PersianCulture());
							insertMultiOrderCommissionsViewModel.CommDatePersian = dateTime.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime = DateTime.Parse(text4, new CultureInfo("ar-SA"));
							insertMultiOrderCommissionsViewModel.CommDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime = DateTime.Parse(text4, new CultureInfo("en-US"));
							insertMultiOrderCommissionsViewModel.CommDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						value4 = dateTime;
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					text3 = text3 + string.Format(Messages.ErrorInFormat, Labels.InsMultiOrdCommDatePersian) + "<br>";
					num++;
				}
				if (!string.IsNullOrWhiteSpace(insertMultiOrderCommissionsViewModel.ListComm))
				{
					List<InsertMultiOrderCommissionItemViewModel> list2 = new JavaScriptSerializer().Deserialize<List<InsertMultiOrderCommissionItemViewModel>>(insertMultiOrderCommissionsViewModel.ListComm);
					if (list2 != null && Enumerable.Any<InsertMultiOrderCommissionItemViewModel>((IEnumerable<InsertMultiOrderCommissionItemViewModel>)list2))
					{
						if (!VersionBuyer.Commissions)
						{
							int num2 = Enumerable.Count<InsertMultiOrderCommissionItemViewModel>((IEnumerable<InsertMultiOrderCommissionItemViewModel>)list2);
							int num3 = 0;
							List<WSOrderCommissions> list3 = Enumerable.ToList<WSOrderCommissions>((IEnumerable<WSOrderCommissions>)_dbTbl.WSOrderCommissions);
							if (list3 != null)
							{
								num3 = Enumerable.Count<WSOrderCommissions>((IEnumerable<WSOrderCommissions>)list3);
							}
							if (num2 + num3 > 10)
							{
								num++;
								text = "";
								data = new CommonResultViewModel<string>
								{
									Data = text,
									Message = "BV|" + string.Format(Messages.VersionBuyWithCount, "10"),
									Status = CommonResultStatusViewModel.Error
								};
								return Json(data, JsonRequestBehavior.AllowGet);
							}
						}
						double num4 = 0.0;
						foreach (InsertMultiOrderCommissionItemViewModel item in list2)
						{
							List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
							if (!string.IsNullOrEmpty(item.CommRateDesc_Lang))
							{
								list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(item.CommRateDesc_Lang);
							}
							list4.Add(new CommonMultiLanguageViewModel
							{
								Value = item.CommRateDesc,
								LanguageId = lCID
							});
							List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
							if (!string.IsNullOrEmpty(item.CommDesc_Lang))
							{
								list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(item.CommDesc_Lang);
							}
							list5.Add(new CommonMultiLanguageViewModel
							{
								Value = item.CommDesc,
								LanguageId = lCID
							});
							item.CommRateDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
							item.CommRateDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID))));
							item.CommDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
							item.CommDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID))));
							try
							{
								if (!string.IsNullOrEmpty(item.CommEffectiveDatePersian))
								{
									item.CommEffectiveDatePersian = item.CommEffectiveDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
										.Replace(".", "")
										.Replace(",", "")
										.Replace("\\", "");
									text4 = PersianDate.GetFormatetdDate(item.CommEffectiveDatePersian.Replace("/", ""));
									text4 = text4 + " " + DateTime.Now.ToString("HH:mm:ss");
									switch (lCID)
									{
									case 1065:
										dateTime = DateTime.Parse(text4, new PersianCulture());
										item.CommEffectiveDatePersian = dateTime.ToString("yyyyMMdd");
										break;
									case 1025:
										dateTime = DateTime.Parse(text4, new CultureInfo("ar-SA"));
										item.CommEffectiveDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
										break;
									default:
										dateTime = DateTime.Parse(text4, new CultureInfo("en-US"));
										item.CommEffectiveDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
										break;
									}
									item.CommEffectiveDateTime = dateTime.ToString("yyyy-MM-dd HH:mm:ss", new CultureInfo("en-US"));
								}
								else
								{
									item.CommEffectiveDatePersian = null;
									item.CommEffectiveDateTime = null;
								}
							}
							catch (Exception e2)
							{
								ErrorSignal.FromCurrentContext().Raise(e2);
								text3 = text3 + string.Format(Messages.ErrorInFormat, Labels.InsMultiOrdCommEffectiveDate) + "<br>";
								num++;
							}
							num4 += item.CommRate.GetValueOrDefault();
						}
						if (num4 > 100.0)
						{
							text3 = text3 + Messages.msgErrorNotInsertCommPercentMore100I + "<br>";
							num++;
						}
						orderCommJson = new JavaScriptSerializer().Serialize((object)list2);
					}
					else
					{
						text3 = text3 + Messages.msgErrorNoCommToAdd + "<br>";
						num++;
					}
				}
				else
				{
					text3 = text3 + Messages.msgErrorNoCommToAdd + "<br>";
					num++;
				}
				if (num == 0)
				{
					insertMultiOrderCommissionsViewModel.CommBaseAmountDecDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					insertMultiOrderCommissionsViewModel.CommBaseAmountDecDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID))));
					ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
					text = "";
					mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.WSspInsertOrderCommissionMulti(insertMultiOrderCommissionsViewModel.CommOrderId, insertMultiOrderCommissionsViewModel.CommCmpId, value4, insertMultiOrderCommissionsViewModel.CommDatePersian, insertMultiOrderCommissionsViewModel.CommBaseAmountDec, insertMultiOrderCommissionsViewModel.CommBaseAmountDecDesc, insertMultiOrderCommissionsViewModel.CommBaseAmountDecDesc_Lang, insertMultiOrderCommissionsViewModel.CommBaseAmount, insertMultiOrderCommissionsViewModel.CommBaseAmountDecPercent, orderCommJson, userId, id, value3, value2, value, registerDatePersian, appType, defLangID, objectParameter));
					string text5 = "";
					if (objectParameter.Value != null)
					{
						text5 = objectParameter.Value.ToString();
						if (!string.IsNullOrWhiteSpace(text5))
						{
							text5 = Messages.msgErrorRunFunction + "<br>" + text5;
						}
						else if (mct_I_Result != null && mct_I_Result.Result > 0)
						{
							text5 = "";
						}
						else if (mct_I_Result != null && mct_I_Result.Result == 0)
						{
							text5 = Messages.msgErrorRunFunction;
						}
					}
					else if (mct_I_Result != null && mct_I_Result.Result > 0)
					{
						text5 = "";
					}
					else if (mct_I_Result != null && mct_I_Result.Result == 0)
					{
						text5 = Messages.msgErrorRunFunction;
					}
					if (!string.IsNullOrWhiteSpace(text5))
					{
						text = "";
						text2 = text5;
						commonResultStatusViewModel = CommonResultStatusViewModel.Error;
					}
					else
					{
						text2 = Messages.msgSuccessAction;
						commonResultStatusViewModel = CommonResultStatusViewModel.Success;
					}
					Order.CalcAndSetOrderAmounts(insertMultiOrderCommissionsViewModel.CommOrderId);
				}
				else
				{
					text = "";
					text2 = text3;
					commonResultStatusViewModel = CommonResultStatusViewModel.Error;
				}
			}
			else
			{
				text = "";
				text2 = string.Format(Messages.ErrorEmpty, Labels.SendCmpNotifToMobMsgBody);
				commonResultStatusViewModel = CommonResultStatusViewModel.Error;
			}
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
			text = "";
			data = new CommonResultViewModel<string>
			{
				Data = text,
				Message = Messages.msgErrorRunFunction,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data, JsonRequestBehavior.AllowGet);
		}
		data = new CommonResultViewModel<string>
		{
			Data = text,
			Message = text2,
			Status = commonResultStatusViewModel
		};
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
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

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbI.Dispose();
		_dbII.Dispose();
		_dbIII.Dispose();
		base.Dispose(disposing);
	}
}

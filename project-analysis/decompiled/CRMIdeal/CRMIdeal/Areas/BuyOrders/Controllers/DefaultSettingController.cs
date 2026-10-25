using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
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

namespace CRMIdeal.Areas.BuyOrders.Controllers;

public class DefaultSettingController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass11_0
	{
		public int defSettingId;

		public int currLangID;

		internal bool _003CGetDefaultSettingById_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass13_1
	{
		public WSBuyOrderDefaultSettingLanguageViewModel vm;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass13_2
	{
		public WSBuyOrderDefaultSetting model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass13_4
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass13_2 CS_0024_003C_003E8__locals1;

		internal bool _003CInsertEdit_003Eb__24(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__25(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__26(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__27(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__28(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__29(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__30(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__31(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__32(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__33(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__34(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__35(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__36(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__37(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__38(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__39(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__40(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__41(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__42(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__43(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actbordDefultSetting")]
	public ActionResult Index()
	{
		WSBuyOrderDefaultSettingLanguageViewModel model = new WSBuyOrderDefaultSettingLanguageViewModel();
		GetReferUser();
		GetBuyOrderOpr();
		GetCurrencyUnit();
		GetVerificationWorkFlow();
		GetBordPrintFormat();
		return View(model);
	}

	[AjaxOnly]
	public JsonResult GetReferUser()
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
			List<WSspSelectBuyOrderDefaultSettingUsers_Result> list2 = Enumerable.ToList<WSspSelectBuyOrderDefaultSettingUsers_Result>((IEnumerable<WSspSelectBuyOrderDefaultSettingUsers_Result>)_dbII.WSspSelectBuyOrderDefaultSettingUsers(UserLogin.CurrentUser.UserId, lCID, result, result2));
			list.AddRange(Enumerable.Select<WSspSelectBuyOrderDefaultSettingUsers_Result, SelectListItem>((IEnumerable<WSspSelectBuyOrderDefaultSettingUsers_Result>)list2, (Func<WSspSelectBuyOrderDefaultSettingUsers_Result, SelectListItem>)((WSspSelectBuyOrderDefaultSettingUsers_Result item) => new SelectListItem
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
		base.ViewBag.ReferUserList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
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
			List<WSspSelectBuyOrderOpr_Result> list2 = BuyOrder.SelectBuyOrderOpr();
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
	public JsonResult GetCurrencyUnit()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		List<SelectListItem> list2 = new List<SelectListItem>();
		try
		{
			List<WSspSelectCurrencyUnits_Result> list3 = Enumerable.ToList<WSspSelectCurrencyUnits_Result>((IEnumerable<WSspSelectCurrencyUnits_Result>)_db.WSspSelectCurrencyUnits(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectCurrencyUnits_Result, SelectListItem>((IEnumerable<WSspSelectCurrencyUnits_Result>)list3, (Func<WSspSelectCurrencyUnits_Result, SelectListItem>)((WSspSelectCurrencyUnits_Result item) => new SelectListItem
			{
				Text = item.CurrencyUnit,
				Value = item.CurrencyUnitID.ToString(),
				Selected = false
			})));
			list2.AddRange(Enumerable.Select<WSspSelectCurrencyUnits_Result, SelectListItem>((IEnumerable<WSspSelectCurrencyUnits_Result>)list3, (Func<WSspSelectCurrencyUnits_Result, SelectListItem>)((WSspSelectCurrencyUnits_Result item) => new SelectListItem
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
		base.ViewBag.CurrencyUnitListI = list2;
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
			List<WSspSelectVerificationWorkFlowWithObjectType_Result> list2 = Enumerable.ToList<WSspSelectVerificationWorkFlowWithObjectType_Result>((IEnumerable<WSspSelectVerificationWorkFlowWithObjectType_Result>)_db.WSspSelectVerificationWorkFlowWithObjectType(40, lCID, result));
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
	public JsonResult GetBordPrintFormat()
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
			List<CRMspSelectPrintFormatByTypeId_Result> printFortants = CRMIdeal.Classes.Helper.PrintFormat.GetPrintFortants(result2, 5);
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
		base.ViewBag.BuyOrdPrintFormatList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetDefaultSettingByReferUser(int referUserId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonDroupDownItemViewModel> data = new List<CommonDroupDownItemViewModel>();
		try
		{
			List<WSspSelectBuyOrderDefaultSettingByReferUserId_Result> list = Enumerable.ToList<WSspSelectBuyOrderDefaultSettingByReferUserId_Result>((IEnumerable<WSspSelectBuyOrderDefaultSettingByReferUserId_Result>)_dbII.WSspSelectBuyOrderDefaultSettingByReferUserId(referUserId, lCID, result));
			if (list != null && Enumerable.Any<WSspSelectBuyOrderDefaultSettingByReferUserId_Result>((IEnumerable<WSspSelectBuyOrderDefaultSettingByReferUserId_Result>)list))
			{
				data = Enumerable.ToList<CommonDroupDownItemViewModel>(Enumerable.Select<WSspSelectBuyOrderDefaultSettingByReferUserId_Result, CommonDroupDownItemViewModel>((IEnumerable<WSspSelectBuyOrderDefaultSettingByReferUserId_Result>)list, (Func<WSspSelectBuyOrderDefaultSettingByReferUserId_Result, CommonDroupDownItemViewModel>)((WSspSelectBuyOrderDefaultSettingByReferUserId_Result item) => new CommonDroupDownItemViewModel
				{
					Text = item.SettingTitle,
					Value = item.BuyOrderDefaultSettingId.ToString()
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetDefaultSettingById(int defSettingId)
	{
		_003C_003Ec__DisplayClass11_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass11_0();
		CS_0024_003C_003E8__locals0.defSettingId = defSettingId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		WSBuyOrderDefaultSettingLanguageViewModel wSBuyOrderDefaultSettingLanguageViewModel = new WSBuyOrderDefaultSettingLanguageViewModel();
		try
		{
			DbSet<WSBuyOrderDefaultSetting> wSBuyOrderDefaultSetting = _dbTbl.WSBuyOrderDefaultSetting;
			ParameterExpression val = Expression.Parameter(typeof(WSBuyOrderDefaultSetting), "c");
			WSBuyOrderDefaultSetting wSBuyOrderDefaultSetting2 = Queryable.FirstOrDefault<WSBuyOrderDefaultSetting>((IQueryable<WSBuyOrderDefaultSetting>)wSBuyOrderDefaultSetting, Expression.Lambda<Func<WSBuyOrderDefaultSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass11_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			DbSet<WSBuyOrderDefaultSetting_Lang> wSBuyOrderDefaultSetting_Lang = _dbTbl.WSBuyOrderDefaultSetting_Lang;
			val = Expression.Parameter(typeof(WSBuyOrderDefaultSetting_Lang), "c");
			List<WSBuyOrderDefaultSetting_Lang> list = Enumerable.ToList<WSBuyOrderDefaultSetting_Lang>((IEnumerable<WSBuyOrderDefaultSetting_Lang>)Queryable.Where<WSBuyOrderDefaultSetting_Lang>((IQueryable<WSBuyOrderDefaultSetting_Lang>)wSBuyOrderDefaultSetting_Lang, Expression.Lambda<Func<WSBuyOrderDefaultSetting_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass11_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			if (wSBuyOrderDefaultSetting2 != null)
			{
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				if (list != null)
				{
					list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSBuyOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSBuyOrderDefaultSetting_Lang>)list, (Func<WSBuyOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSBuyOrderDefaultSetting_Lang itemVm) => new CommonMultiLanguageViewModel
					{
						Value = itemVm.SettingTitle,
						LanguageId = itemVm.LanguageID
					})));
				}
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = wSBuyOrderDefaultSetting2.SettingTitle,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
				if (list != null)
				{
					list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSBuyOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSBuyOrderDefaultSetting_Lang>)list, (Func<WSBuyOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSBuyOrderDefaultSetting_Lang itemVm) => new CommonMultiLanguageViewModel
					{
						Value = itemVm.Title,
						LanguageId = itemVm.LanguageID
					})));
				}
				list3.Add(new CommonMultiLanguageViewModel
				{
					Value = wSBuyOrderDefaultSetting2.Title,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
				if (list != null)
				{
					list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSBuyOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSBuyOrderDefaultSetting_Lang>)list, (Func<WSBuyOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSBuyOrderDefaultSetting_Lang itemVm) => new CommonMultiLanguageViewModel
					{
						Value = itemVm.Subject,
						LanguageId = itemVm.LanguageID
					})));
				}
				list4.Add(new CommonMultiLanguageViewModel
				{
					Value = wSBuyOrderDefaultSetting2.Subject,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
				if (list != null)
				{
					list5 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSBuyOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSBuyOrderDefaultSetting_Lang>)list, (Func<WSBuyOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSBuyOrderDefaultSetting_Lang itemVm) => new CommonMultiLanguageViewModel
					{
						Value = itemVm.Note,
						LanguageId = itemVm.LanguageID
					})));
				}
				list5.Add(new CommonMultiLanguageViewModel
				{
					Value = wSBuyOrderDefaultSetting2.Note,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
				if (list != null)
				{
					list6 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSBuyOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSBuyOrderDefaultSetting_Lang>)list, (Func<WSBuyOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSBuyOrderDefaultSetting_Lang itemVm) => new CommonMultiLanguageViewModel
					{
						Value = itemVm.DeliveryTerm,
						LanguageId = itemVm.LanguageID
					})));
				}
				list6.Add(new CommonMultiLanguageViewModel
				{
					Value = wSBuyOrderDefaultSetting2.DeliveryTerm,
					LanguageId = result
				});
				wSBuyOrderDefaultSettingLanguageViewModel = new WSBuyOrderDefaultSettingLanguageViewModel
				{
					BuyOrderDefaultSettingId = wSBuyOrderDefaultSetting2.BuyOrderDefaultSettingId,
					ReferUserId = wSBuyOrderDefaultSetting2.ReferUserId,
					SettingTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					SettingTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					BuyOrderOprId = wSBuyOrderDefaultSetting2.BuyOrderOprId,
					Title = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					Title_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					Subject = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					Subject_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					TaxIndex = wSBuyOrderDefaultSetting2.TaxIndex,
					CalculateTax = wSBuyOrderDefaultSetting2.CalculateTax,
					TaxIndexItem = wSBuyOrderDefaultSetting2.TaxIndexItem,
					CalculateTaxItem = wSBuyOrderDefaultSetting2.CalculateTaxItem,
					PrintFormatId = wSBuyOrderDefaultSetting2.PrintFormatId,
					Note = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					Note_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					CurrencyUnitId = wSBuyOrderDefaultSetting2.CurrencyUnitId,
					CurrencyUnitIdI = wSBuyOrderDefaultSetting2.CurrencyUnitIdI,
					DeliveryTerm = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					DeliveryTerm_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					VerificationWorkFlowId = wSBuyOrderDefaultSetting2.VerificationWorkFlowId,
					IsPublic = wSBuyOrderDefaultSetting2.IsPublic
				};
				if (wSBuyOrderDefaultSettingLanguageViewModel != null)
				{
					try
					{
						string text = "";
						string text2 = "";
						CRMspSelectUsersById_Result cRMspSelectUsersById_Result = CRMIdeal.Classes.Helper.User.SelectUsersById(wSBuyOrderDefaultSetting2.FirstRegisterUserId);
						if (cRMspSelectUsersById_Result != null)
						{
							text = cRMspSelectUsersById_Result.FullName ?? "";
						}
						CRMspSelectUsersById_Result cRMspSelectUsersById_Result2 = CRMIdeal.Classes.Helper.User.SelectUsersById(wSBuyOrderDefaultSetting2.UserId);
						if (cRMspSelectUsersById_Result2 != null)
						{
							text2 = cRMspSelectUsersById_Result2.FullName ?? "";
						}
						_ = wSBuyOrderDefaultSetting2.FirstRegisterDate;
						string text3 = wSBuyOrderDefaultSetting2.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
						_ = wSBuyOrderDefaultSetting2.RegisterDate;
						string text4 = wSBuyOrderDefaultSetting2.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
						if (string.IsNullOrEmpty(wSBuyOrderDefaultSetting2.AppType))
						{
							wSBuyOrderDefaultSetting2.AppType = Configuration.AppType;
						}
						string text5 = Labels.AppType + ": " + Configuration.GetAppType(wSBuyOrderDefaultSetting2.AppType);
						wSBuyOrderDefaultSettingLanguageViewModel.FirstRegisterUser = text + " (" + text3 + ")";
						wSBuyOrderDefaultSettingLanguageViewModel.EditUser = text2 + " (" + text5 + ") (" + text4 + ")";
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
					}
				}
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		JsonResult jsonResult = Json(wSBuyOrderDefaultSettingLanguageViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult DeleteDefaultSetting(int defsettingId, int referUserId)
	{
		string data = "";
		try
		{
			mct_II_Result mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.WSspDeleteBuyOrderDefaultSetting(defsettingId));
			if (mct_II_Result != null)
			{
				int result = 0;
				int.TryParse(mct_II_Result.Result.ToString(), out result);
				if (result == 1)
				{
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSBuyOrderDefaultSetting", referUserId);
					data = "";
				}
				else
				{
					data = Messages.RedundancyMessage;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			data = Messages.msgErrorRunProcedure;
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult InsertEdit(string parameters)
	{
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_034a: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a1: Unknown result type (might be due to invalid IL or missing references)
		string data = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
			if (defLangID <= 0)
			{
				defLangID = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (!string.IsNullOrWhiteSpace(parameters))
			{
				_003C_003Ec__DisplayClass13_1 _003C_003Ec__DisplayClass13_ = new _003C_003Ec__DisplayClass13_1();
				_003C_003Ec__DisplayClass13_.vm = new JavaScriptSerializer().Deserialize<WSBuyOrderDefaultSettingLanguageViewModel>(parameters);
				if (_003C_003Ec__DisplayClass13_.vm != null)
				{
					_003C_003Ec__DisplayClass13_.vm.BuyOrderOprId = ((_003C_003Ec__DisplayClass13_.vm.BuyOrderOprId.GetValueOrDefault() == 0) ? null : _003C_003Ec__DisplayClass13_.vm.BuyOrderOprId);
					_003C_003Ec__DisplayClass13_.vm.PrintFormatId = ((_003C_003Ec__DisplayClass13_.vm.PrintFormatId.GetValueOrDefault() == 0) ? null : _003C_003Ec__DisplayClass13_.vm.PrintFormatId);
					_003C_003Ec__DisplayClass13_.vm.CurrencyUnitId = ((_003C_003Ec__DisplayClass13_.vm.CurrencyUnitId.GetValueOrDefault() == 0) ? null : _003C_003Ec__DisplayClass13_.vm.CurrencyUnitId);
					_003C_003Ec__DisplayClass13_.vm.CurrencyUnitIdI = ((_003C_003Ec__DisplayClass13_.vm.CurrencyUnitIdI.GetValueOrDefault() == 0) ? null : _003C_003Ec__DisplayClass13_.vm.CurrencyUnitIdI);
					_003C_003Ec__DisplayClass13_.vm.VerificationWorkFlowId = ((_003C_003Ec__DisplayClass13_.vm.VerificationWorkFlowId.GetValueOrDefault() == 0) ? null : _003C_003Ec__DisplayClass13_.vm.VerificationWorkFlowId);
					_003C_003Ec__DisplayClass13_.vm.TaxIndex = ((_003C_003Ec__DisplayClass13_.vm.TaxIndex.GetValueOrDefault() == 0m) ? null : _003C_003Ec__DisplayClass13_.vm.TaxIndex);
					_003C_003Ec__DisplayClass13_.vm.TaxIndexItem = ((_003C_003Ec__DisplayClass13_.vm.TaxIndexItem.GetValueOrDefault() == 0m) ? null : _003C_003Ec__DisplayClass13_.vm.TaxIndexItem);
					List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrWhiteSpace(_003C_003Ec__DisplayClass13_.vm.SettingTitle_Lang))
					{
						list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(_003C_003Ec__DisplayClass13_.vm.SettingTitle_Lang);
					}
					list.Add(new CommonMultiLanguageViewModel
					{
						Value = _003C_003Ec__DisplayClass13_.vm.SettingTitle,
						LanguageId = lCID
					});
					List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrWhiteSpace(_003C_003Ec__DisplayClass13_.vm.Title_Lang))
					{
						list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(_003C_003Ec__DisplayClass13_.vm.Title_Lang);
					}
					list2.Add(new CommonMultiLanguageViewModel
					{
						Value = _003C_003Ec__DisplayClass13_.vm.Title,
						LanguageId = lCID
					});
					List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrWhiteSpace(_003C_003Ec__DisplayClass13_.vm.Subject_Lang))
					{
						list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(_003C_003Ec__DisplayClass13_.vm.Subject_Lang);
					}
					list3.Add(new CommonMultiLanguageViewModel
					{
						Value = _003C_003Ec__DisplayClass13_.vm.Subject,
						LanguageId = lCID
					});
					List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrWhiteSpace(_003C_003Ec__DisplayClass13_.vm.Note_Lang))
					{
						list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(_003C_003Ec__DisplayClass13_.vm.Note_Lang);
					}
					list4.Add(new CommonMultiLanguageViewModel
					{
						Value = _003C_003Ec__DisplayClass13_.vm.Note,
						LanguageId = lCID
					});
					List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrWhiteSpace(_003C_003Ec__DisplayClass13_.vm.DeliveryTerm_Lang))
					{
						list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(_003C_003Ec__DisplayClass13_.vm.DeliveryTerm_Lang);
					}
					list5.Add(new CommonMultiLanguageViewModel
					{
						Value = _003C_003Ec__DisplayClass13_.vm.DeliveryTerm,
						LanguageId = lCID
					});
					string text = "";
					int num = 0;
					if (string.IsNullOrWhiteSpace(_003C_003Ec__DisplayClass13_.vm.SettingTitle))
					{
						num++;
						text = string.Format(Messages.ErrorEmpty, Labels.bordDefSetSettingTitle) + "<br/>";
					}
					else if (!checkMultiLanguage(_003C_003Ec__DisplayClass13_.vm.SettingTitle, list))
					{
						num++;
						text = text + string.Format(Messages.CheckFieldInLang, Labels.bordDefSetSettingTitle) + "<br>";
					}
					if (num > 0)
					{
						data = "-1|" + text;
					}
					else
					{
						_003C_003Ec__DisplayClass13_2 _003C_003Ec__DisplayClass13_2 = new _003C_003Ec__DisplayClass13_2();
						DateTime now = DateTime.Now;
						_003C_003Ec__DisplayClass13_2.model = new WSBuyOrderDefaultSetting();
						if (_003C_003Ec__DisplayClass13_.vm.BuyOrderDefaultSettingId > 0)
						{
							DbSet<WSBuyOrderDefaultSetting> wSBuyOrderDefaultSetting = _dbTbl.WSBuyOrderDefaultSetting;
							ParameterExpression val = Expression.Parameter(typeof(WSBuyOrderDefaultSetting), "c");
							_003C_003Ec__DisplayClass13_2.model = Queryable.FirstOrDefault<WSBuyOrderDefaultSetting>((IQueryable<WSBuyOrderDefaultSetting>)wSBuyOrderDefaultSetting, Expression.Lambda<Func<WSBuyOrderDefaultSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass13_, typeof(_003C_003Ec__DisplayClass13_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						}
						_003C_003Ec__DisplayClass13_2.model.UserId = UserLogin.CurrentUser.UserId;
						_003C_003Ec__DisplayClass13_2.model.RegisterDate = now;
						_003C_003Ec__DisplayClass13_2.model.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						_003C_003Ec__DisplayClass13_2.model.Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
						_003C_003Ec__DisplayClass13_2.model.AppType = Configuration.AppType;
						_003C_003Ec__DisplayClass13_2.model.ReferUserId = _003C_003Ec__DisplayClass13_.vm.ReferUserId;
						_003C_003Ec__DisplayClass13_2.model.SettingTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
						_003C_003Ec__DisplayClass13_2.model.BuyOrderOprId = _003C_003Ec__DisplayClass13_.vm.BuyOrderOprId;
						_003C_003Ec__DisplayClass13_2.model.Title = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
						_003C_003Ec__DisplayClass13_2.model.Subject = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
						_003C_003Ec__DisplayClass13_2.model.TaxIndex = _003C_003Ec__DisplayClass13_.vm.TaxIndex;
						_003C_003Ec__DisplayClass13_2.model.CalculateTax = _003C_003Ec__DisplayClass13_.vm.CalculateTax;
						_003C_003Ec__DisplayClass13_2.model.TaxIndexItem = _003C_003Ec__DisplayClass13_.vm.TaxIndexItem;
						_003C_003Ec__DisplayClass13_2.model.CalculateTaxItem = _003C_003Ec__DisplayClass13_.vm.CalculateTaxItem;
						_003C_003Ec__DisplayClass13_2.model.PrintFormatId = _003C_003Ec__DisplayClass13_.vm.PrintFormatId;
						_003C_003Ec__DisplayClass13_2.model.Note = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
						_003C_003Ec__DisplayClass13_2.model.CurrencyUnitId = _003C_003Ec__DisplayClass13_.vm.CurrencyUnitId;
						_003C_003Ec__DisplayClass13_2.model.CurrencyUnitIdI = _003C_003Ec__DisplayClass13_.vm.CurrencyUnitIdI;
						_003C_003Ec__DisplayClass13_2.model.DeliveryTerm = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
						_003C_003Ec__DisplayClass13_2.model.VerificationWorkFlowId = _003C_003Ec__DisplayClass13_.vm.VerificationWorkFlowId;
						_003C_003Ec__DisplayClass13_2.model.IsPublic = _003C_003Ec__DisplayClass13_.vm.IsPublic;
						if (_003C_003Ec__DisplayClass13_.vm.BuyOrderDefaultSettingId == 0)
						{
							_003C_003Ec__DisplayClass13_2.model.FPId = Financial.Get().Id;
							_003C_003Ec__DisplayClass13_2.model.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
							_003C_003Ec__DisplayClass13_2.model.FirstRegisterDate = now;
							_003C_003Ec__DisplayClass13_2.model.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
							_003C_003Ec__DisplayClass13_2.model.LanguageID = defLangID;
							_003C_003Ec__DisplayClass13_2.model.GUId = Guid.NewGuid();
							_dbTbl.WSBuyOrderDefaultSetting.Add(_003C_003Ec__DisplayClass13_2.model);
							_dbTbl.SaveChanges();
							if (_003C_003Ec__DisplayClass13_2.model.BuyOrderDefaultSettingId != 0)
							{
								foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
								{
									WSBuyOrderDefaultSetting_Lang wSBuyOrderDefaultSetting_Lang = new WSBuyOrderDefaultSetting_Lang();
									wSBuyOrderDefaultSetting_Lang.LanguageID = lang.LanguageID;
									wSBuyOrderDefaultSetting_Lang.BuyOrderDefaultSettingId = _003C_003Ec__DisplayClass13_2.model.BuyOrderDefaultSettingId;
									wSBuyOrderDefaultSetting_Lang.SettingTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
									wSBuyOrderDefaultSetting_Lang.Title = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
									wSBuyOrderDefaultSetting_Lang.Subject = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
									wSBuyOrderDefaultSetting_Lang.Note = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
									wSBuyOrderDefaultSetting_Lang.DeliveryTerm = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
									_dbTbl.WSBuyOrderDefaultSetting_Lang.Add(wSBuyOrderDefaultSetting_Lang);
									_dbTbl.SaveChanges();
								}
								CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSBuyOrderDefaultSetting", _003C_003Ec__DisplayClass13_.vm.ReferUserId);
								data = _003C_003Ec__DisplayClass13_2.model.BuyOrderDefaultSettingId + "|" + Messages.frmFormBaseInsertSuccessFulMessage;
							}
						}
						else
						{
							_dbTbl.Entry(_003C_003Ec__DisplayClass13_2.model).State = EntityState.Modified;
							_dbTbl.SaveChanges();
							using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))).GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									_003C_003Ec__DisplayClass13_4 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass13_4();
									CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass13_2;
									CS_0024_003C_003E8__locals2.lang = enumerator.Current;
									DbSet<WSBuyOrderDefaultSetting_Lang> wSBuyOrderDefaultSetting_Lang2 = _dbTbl.WSBuyOrderDefaultSetting_Lang;
									ParameterExpression val = Expression.Parameter(typeof(WSBuyOrderDefaultSetting_Lang), "c");
									WSBuyOrderDefaultSetting_Lang wSBuyOrderDefaultSetting_Lang3 = Queryable.FirstOrDefault<WSBuyOrderDefaultSetting_Lang>((IQueryable<WSBuyOrderDefaultSetting_Lang>)wSBuyOrderDefaultSetting_Lang2, Expression.Lambda<Func<WSBuyOrderDefaultSetting_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals2, typeof(_003C_003Ec__DisplayClass13_4)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals2, typeof(_003C_003Ec__DisplayClass13_4)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
									if (wSBuyOrderDefaultSetting_Lang3 != null)
									{
										wSBuyOrderDefaultSetting_Lang3.SettingTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
										wSBuyOrderDefaultSetting_Lang3.Title = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
										wSBuyOrderDefaultSetting_Lang3.Subject = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
										wSBuyOrderDefaultSetting_Lang3.Note = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
										wSBuyOrderDefaultSetting_Lang3.DeliveryTerm = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
										_dbTbl.Entry(wSBuyOrderDefaultSetting_Lang3).State = EntityState.Modified;
										_dbTbl.SaveChanges();
										continue;
									}
									wSBuyOrderDefaultSetting_Lang3 = new WSBuyOrderDefaultSetting_Lang();
									wSBuyOrderDefaultSetting_Lang3.LanguageID = CS_0024_003C_003E8__locals2.lang.LanguageID;
									wSBuyOrderDefaultSetting_Lang3.BuyOrderDefaultSettingId = CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.model.BuyOrderDefaultSettingId;
									wSBuyOrderDefaultSetting_Lang3.SettingTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
									wSBuyOrderDefaultSetting_Lang3.Title = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
									wSBuyOrderDefaultSetting_Lang3.Subject = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
									wSBuyOrderDefaultSetting_Lang3.Note = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
									wSBuyOrderDefaultSetting_Lang3.DeliveryTerm = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
									_dbTbl.WSBuyOrderDefaultSetting_Lang.Add(wSBuyOrderDefaultSetting_Lang3);
									_dbTbl.SaveChanges();
								}
							}
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSBuyOrderDefaultSetting", _003C_003Ec__DisplayClass13_.vm.ReferUserId);
							data = _003C_003Ec__DisplayClass13_2.model.BuyOrderDefaultSettingId + "|" + Messages.frmFormBaseEditSuccessFulMessage;
						}
					}
				}
				else
				{
					data = "-1|" + Messages.msgErrorRunProcedure;
				}
			}
			else
			{
				data = "-1|" + Messages.msgErrorRunProcedure;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			data = "-1|" + Messages.msgErrorRunProcedure;
		}
		return Json(data, JsonRequestBehavior.AllowGet);
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
		_dbTbl.Dispose();
		_dbI.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}
}

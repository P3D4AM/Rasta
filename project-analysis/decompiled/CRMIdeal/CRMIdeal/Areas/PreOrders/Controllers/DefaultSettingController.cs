using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
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
using Newtonsoft.Json.Linq;

namespace CRMIdeal.Areas.PreOrders.Controllers;

public class DefaultSettingController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass21_0
	{
		public WSPreOrderDefaultSettingLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__23;

		public Func<Languages, bool> _003C_003E9__44;

		internal bool _003CIndex_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CIndex_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CIndex_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CIndex_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CIndex_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CIndex_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CIndex_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CIndex_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CIndex_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CIndex_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CIndex_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CIndex_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CIndex_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CIndex_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CIndex_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CIndex_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CIndex_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CIndex_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CIndex_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CIndex_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CIndex_003Eb__23(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CIndex_003Eb__44(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass21_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass21_0 CS_0024_003C_003E8__locals1;

		internal bool _003CIndex_003Eb__46(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__47(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__48(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__49(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__50(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__51(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__52(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__53(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__54(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__55(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__56(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__57(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__58(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__59(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__60(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__61(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__62(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__63(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__64(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__65(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__66(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__67(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__68(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__69(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__70(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__71(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__72(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__73(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__74(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__75(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__76(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__77(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__78(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__79(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__80(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__81(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__82(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__83(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__84(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__85(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public int id;

		public int currLangID;

		public WSPreOrderDefaultSettingLanguageViewModel result;

		internal bool _003CGetDefaultSettingById_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__24(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__25(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__26(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__27(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__28(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__29(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__30(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__31(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__32(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__33(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__34(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__35(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__36(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__37(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__38(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__39(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__40(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__41(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__44(CRMspSelectUsersByIds_Result c)
		{
			return c.UserId == result.FirstRegisterUserId;
		}

		internal bool _003CGetDefaultSettingById_003Eb__45(CRMspSelectUsersByIds_Result c)
		{
			return c.UserId == result.UserId;
		}
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actpordDefultSetting")]
	public ActionResult Index(int position = 0)
	{
		string text = "";
		string text2 = "";
		switch (position)
		{
		case 0:
			text = "frmMain";
			text2 = "actpordDefultSetting";
			break;
		case 1:
			text = "frmPreOrder";
			text2 = "actSetting";
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
		WSPreOrderDefaultSettingLanguageViewModel model = new WSPreOrderDefaultSettingLanguageViewModel();
		FillDropdownPordDefSetting();
		GetCurrencyUnit();
		GetDeliveryTerms();
		GetPreOrderTypes();
		GetWareHouse();
		GetProductPriceGroup();
		GetSeller();
		GetEmailUsersInfo();
		GetEmailUserDefaultSetting();
		GetDefPayType();
		GetSaleAreas();
		return View(model);
	}

	[AjaxOnly]
	public JsonResult GetDefaultSettingByReferUser(int id)
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
			data = Enumerable.ToList<CommonDroupDownItemViewModel>(Enumerable.Select<WSspSelectPreOrderDefaultSettingByReferUserId_Result, CommonDroupDownItemViewModel>((IEnumerable<WSspSelectPreOrderDefaultSettingByReferUserId_Result>)Enumerable.ToList<WSspSelectPreOrderDefaultSettingByReferUserId_Result>((IEnumerable<WSspSelectPreOrderDefaultSettingByReferUserId_Result>)_db.WSspSelectPreOrderDefaultSettingByReferUserId(id, lCID, result)), (Func<WSspSelectPreOrderDefaultSettingByReferUserId_Result, CommonDroupDownItemViewModel>)((WSspSelectPreOrderDefaultSettingByReferUserId_Result item) => new CommonDroupDownItemViewModel
			{
				Text = item.SettingTitle,
				Value = item.PreOrderSettingID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetDefaultSettingById(int id)
	{
		_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass6_0();
		CS_0024_003C_003E8__locals0.id = id;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		CS_0024_003C_003E8__locals0.result = new WSPreOrderDefaultSettingLanguageViewModel();
		try
		{
			DbSet<WSPreOrderDefaultSetting> wSPreOrderDefaultSetting = _dbTbl.WSPreOrderDefaultSetting;
			ParameterExpression val = Expression.Parameter(typeof(WSPreOrderDefaultSetting), "c");
			WSPreOrderDefaultSetting wSPreOrderDefaultSetting2 = Queryable.FirstOrDefault<WSPreOrderDefaultSetting>((IQueryable<WSPreOrderDefaultSetting>)wSPreOrderDefaultSetting, Expression.Lambda<Func<WSPreOrderDefaultSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass6_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			DbSet<WSPreOrderDefaultSetting_Lang> wSPreOrderDefaultSetting_Lang = _dbTbl.WSPreOrderDefaultSetting_Lang;
			val = Expression.Parameter(typeof(WSPreOrderDefaultSetting_Lang), "c");
			List<WSPreOrderDefaultSetting_Lang> list = Enumerable.ToList<WSPreOrderDefaultSetting_Lang>((IEnumerable<WSPreOrderDefaultSetting_Lang>)Queryable.Where<WSPreOrderDefaultSetting_Lang>((IQueryable<WSPreOrderDefaultSetting_Lang>)wSPreOrderDefaultSetting_Lang, Expression.Lambda<Func<WSPreOrderDefaultSetting_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass6_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrderDefaultSetting_Lang>)list, (Func<WSPreOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSPreOrderDefaultSetting_Lang itemVm) => new CommonMultiLanguageViewModel
			{
				Value = itemVm.Title,
				LanguageId = itemVm.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = wSPreOrderDefaultSetting2.Title,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrderDefaultSetting_Lang>)list, (Func<WSPreOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSPreOrderDefaultSetting_Lang itemVm) => new CommonMultiLanguageViewModel
			{
				Value = itemVm.Subject,
				LanguageId = itemVm.LanguageID
			})));
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = wSPreOrderDefaultSetting2.Subject,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrderDefaultSetting_Lang>)list, (Func<WSPreOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSPreOrderDefaultSetting_Lang itemVm) => new CommonMultiLanguageViewModel
			{
				Value = itemVm.SpecialWord,
				LanguageId = itemVm.LanguageID
			})));
			list4.Add(new CommonMultiLanguageViewModel
			{
				Value = wSPreOrderDefaultSetting2.SpecialWord,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list5 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrderDefaultSetting_Lang>)list, (Func<WSPreOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSPreOrderDefaultSetting_Lang itemVm) => new CommonMultiLanguageViewModel
			{
				Value = itemVm.DescriptionI,
				LanguageId = itemVm.LanguageID
			})));
			list5.Add(new CommonMultiLanguageViewModel
			{
				Value = wSPreOrderDefaultSetting2.DescriptionI,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list6 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrderDefaultSetting_Lang>)list, (Func<WSPreOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSPreOrderDefaultSetting_Lang itemVm) => new CommonMultiLanguageViewModel
			{
				Value = itemVm.DescriptionII,
				LanguageId = itemVm.LanguageID
			})));
			list6.Add(new CommonMultiLanguageViewModel
			{
				Value = wSPreOrderDefaultSetting2.DescriptionII,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list7 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrderDefaultSetting_Lang>)list, (Func<WSPreOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSPreOrderDefaultSetting_Lang itemVm) => new CommonMultiLanguageViewModel
			{
				Value = itemVm.SigningI,
				LanguageId = itemVm.LanguageID
			})));
			list7.Add(new CommonMultiLanguageViewModel
			{
				Value = wSPreOrderDefaultSetting2.SigningI,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list8 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrderDefaultSetting_Lang>)list, (Func<WSPreOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSPreOrderDefaultSetting_Lang itemVm) => new CommonMultiLanguageViewModel
			{
				Value = itemVm.SigningII,
				LanguageId = itemVm.LanguageID
			})));
			list8.Add(new CommonMultiLanguageViewModel
			{
				Value = wSPreOrderDefaultSetting2.SigningII,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list9 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrderDefaultSetting_Lang>)list, (Func<WSPreOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSPreOrderDefaultSetting_Lang itemVm) => new CommonMultiLanguageViewModel
			{
				Value = itemVm.SigningIII,
				LanguageId = itemVm.LanguageID
			})));
			list9.Add(new CommonMultiLanguageViewModel
			{
				Value = wSPreOrderDefaultSetting2.SigningIII,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list10 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrderDefaultSetting_Lang>)list, (Func<WSPreOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSPreOrderDefaultSetting_Lang itemVm) => new CommonMultiLanguageViewModel
			{
				Value = itemVm.Address,
				LanguageId = itemVm.LanguageID
			})));
			list10.Add(new CommonMultiLanguageViewModel
			{
				Value = wSPreOrderDefaultSetting2.Address,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list11 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrderDefaultSetting_Lang>)list, (Func<WSPreOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSPreOrderDefaultSetting_Lang itemVm) => new CommonMultiLanguageViewModel
			{
				Value = itemVm.SettingTitle,
				LanguageId = itemVm.LanguageID
			})));
			list11.Add(new CommonMultiLanguageViewModel
			{
				Value = wSPreOrderDefaultSetting2.SettingTitle,
				LanguageId = result
			});
			if (wSPreOrderDefaultSetting2 != null)
			{
				CS_0024_003C_003E8__locals0.result = new WSPreOrderDefaultSettingLanguageViewModel
				{
					UserId = wSPreOrderDefaultSetting2.UserId,
					AppType = wSPreOrderDefaultSetting2.AppType,
					PreOrderSettingID = wSPreOrderDefaultSetting2.PreOrderSettingID,
					AccountNumberI = wSPreOrderDefaultSetting2.AccountNumberI,
					Email = wSPreOrderDefaultSetting2.Email,
					FPId = wSPreOrderDefaultSetting2.FPId,
					SignatureId = wSPreOrderDefaultSetting2.SignatureId,
					DeliveryTimeId = wSPreOrderDefaultSetting2.DeliveryTimeId,
					RightLogoId = wSPreOrderDefaultSetting2.RightLogoId,
					AccountNumberII = wSPreOrderDefaultSetting2.AccountNumberII,
					RegisterDatePersian = wSPreOrderDefaultSetting2.RegisterDate.ToString("yyyyMMdd"),
					GUId = wSPreOrderDefaultSetting2.GUId,
					RegisterDate = wSPreOrderDefaultSetting2.RegisterDate,
					Month1 = wSPreOrderDefaultSetting2.Month1,
					PreOrderOprID = wSPreOrderDefaultSetting2.PreOrderOprID,
					CalculateTax = wSPreOrderDefaultSetting2.CalculateTax,
					CreditDurationId = wSPreOrderDefaultSetting2.CreditDurationId,
					LeftLogoId = wSPreOrderDefaultSetting2.LeftLogoId,
					AccountShabaNumberI = wSPreOrderDefaultSetting2.AccountShabaNumberI,
					VerifierRequestId = wSPreOrderDefaultSetting2.VerifierRequestId,
					PayConditionId = wSPreOrderDefaultSetting2.PayConditionId,
					PrintFormatId = wSPreOrderDefaultSetting2.PrintFormatId,
					Fax = wSPreOrderDefaultSetting2.Fax,
					WebSite = wSPreOrderDefaultSetting2.WebSite,
					GuarantyId = wSPreOrderDefaultSetting2.GuarantyId,
					Telephone = wSPreOrderDefaultSetting2.Telephone,
					TaxIndex = wSPreOrderDefaultSetting2.TaxIndex,
					AccountShabaNumberII = wSPreOrderDefaultSetting2.AccountShabaNumberII,
					ReferUserId = wSPreOrderDefaultSetting2.ReferUserId,
					Title = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					Title_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					Subject = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					Subject_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					SpecialWord = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					SpecialWord_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					SigningI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					SigningI_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					SigningII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					SigningII_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					SigningIII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					SigningIII_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					DescriptionII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					DescriptionII_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					DescriptionI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					DescriptionI_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					Address = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					Address_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					SettingTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					SettingTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					FirstRegisterDate = wSPreOrderDefaultSetting2.FirstRegisterDate,
					FirstRegisterUserId = wSPreOrderDefaultSetting2.FirstRegisterUserId,
					VerificationWorkFlowId = wSPreOrderDefaultSetting2.VerificationWorkFlowId,
					CurrencyUnitId = wSPreOrderDefaultSetting2.CurrencyUnitId,
					DeliveryTermId = wSPreOrderDefaultSetting2.DeliveryTermId,
					PreOrderTypeId = wSPreOrderDefaultSetting2.PreOrderTypeId,
					DefWHId = wSPreOrderDefaultSetting2.DefWHId,
					DefPrdPriceGroupId = wSPreOrderDefaultSetting2.DefPrdPriceGroupId,
					SellerId = wSPreOrderDefaultSetting2.SellerId,
					EmailUsersInfoId = wSPreOrderDefaultSetting2.EmailUsersInfoId,
					EmailUserDefaultSettingId = wSPreOrderDefaultSetting2.EmailUserDefaultSettingId,
					SaleCenterId = wSPreOrderDefaultSetting2.SaleCenterId,
					DefPayTypeId = wSPreOrderDefaultSetting2.DefPayTypeId,
					TaxIndexItem = wSPreOrderDefaultSetting2.TaxIndexItem,
					CalculateTaxItem = wSPreOrderDefaultSetting2.CalculateTaxItem,
					CurrencyUnitIdI = wSPreOrderDefaultSetting2.CurrencyUnitIdI,
					SaleAreaId = wSPreOrderDefaultSetting2.SaleAreaId,
					PublicMode = wSPreOrderDefaultSetting2.PublicMode,
					InActive = wSPreOrderDefaultSetting2.InActive,
					AccessUserJson = wSPreOrderDefaultSetting2.AccessUserJson
				};
				JArray jArray = new JArray();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.result.AccessUserJson) && ((int?)CS_0024_003C_003E8__locals0.result.PublicMode).GetValueOrDefault() == 3)
				{
					List<int> userIds = new List<int>();
					new List<object>();
					try
					{
						jArray = JArray.Parse(CS_0024_003C_003E8__locals0.result.AccessUserJson);
						foreach (JToken item in jArray)
						{
							int? num = item.Value<int?>("UserId") ?? item.Value<int?>("id");
							if (num.HasValue && num.Value > 0)
							{
								userIds.Add(num.Value);
							}
						}
					}
					catch
					{
					}
					int result2 = 0;
					if (UserLogin.CurrentUser != null)
					{
						int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
					}
					IEnumerable<CRMspSelectUsers_Result> enumerable = Enumerable.Where<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)Enumerable.ToList<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)_db.CRMspSelectUsers(CS_0024_003C_003E8__locals0.currLangID, result, result2)), (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result u) => userIds.Contains(u.UserId)));
					List<object> list12 = new List<object>();
					foreach (CRMspSelectUsers_Result user in enumerable)
					{
						Enumerable.FirstOrDefault<JToken>((IEnumerable<JToken>)jArray, (Func<JToken, bool>)((JToken j) => (j.Value<int?>("UserId") ?? j.Value<int?>("id")) == user.UserId));
						list12.Add(new
						{
							text = user.LName + " " + user.FName,
							id = user.UserId
						});
					}
					string accessUserJson = JsonConvert.SerializeObject(list12, new JsonSerializerSettings
					{
						NullValueHandling = NullValueHandling.Ignore,
						Formatting = Formatting.None
					});
					CS_0024_003C_003E8__locals0.result.AccessUserJson = accessUserJson;
				}
				if (CS_0024_003C_003E8__locals0.result != null)
				{
					try
					{
						string text = "";
						string text2 = "";
						string text3 = (CS_0024_003C_003E8__locals0.result.FirstRegisterUserId ?? UserLogin.CurrentUser.UserId).ToString();
						_ = CS_0024_003C_003E8__locals0.result.UserId;
						List<CRMspSelectUsersByIds_Result> list13 = CRMIdeal.Classes.Helper.User.SelectUsersByIds(text3 + "," + CS_0024_003C_003E8__locals0.result.UserId);
						if (Enumerable.Any<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list13))
						{
							CS_0024_003C_003E8__locals0.result.FirstRegisterUserId = CS_0024_003C_003E8__locals0.result.FirstRegisterUserId ?? UserLogin.CurrentUser.UserId;
							CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list13, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == CS_0024_003C_003E8__locals0.result.FirstRegisterUserId));
							text = ((cRMspSelectUsersByIds_Result != null) ? (cRMspSelectUsersByIds_Result.LName + ((cRMspSelectUsersByIds_Result.FName != null) ? (" " + cRMspSelectUsersByIds_Result.FName) : "")) : "");
							WSPreOrderDefaultSettingLanguageViewModel result3 = CS_0024_003C_003E8__locals0.result;
							_ = CS_0024_003C_003E8__locals0.result.UserId;
							result3.UserId = CS_0024_003C_003E8__locals0.result.UserId;
							CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result2 = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list13, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == CS_0024_003C_003E8__locals0.result.UserId));
							text2 = ((cRMspSelectUsersByIds_Result2 != null) ? (cRMspSelectUsersByIds_Result2.LName + ((cRMspSelectUsersByIds_Result2.FName != null) ? (" " + cRMspSelectUsersByIds_Result2.FName) : "")) : "");
						}
						string text4 = (CS_0024_003C_003E8__locals0.result.FirstRegisterDate.HasValue ? CS_0024_003C_003E8__locals0.result.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
						_ = CS_0024_003C_003E8__locals0.result.RegisterDate;
						string text5 = CS_0024_003C_003E8__locals0.result.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
						if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.result.AppType))
						{
							CS_0024_003C_003E8__locals0.result.AppType = Configuration.AppType;
						}
						string text6 = Labels.AppType + ": " + Configuration.GetAppType(CS_0024_003C_003E8__locals0.result.AppType);
						CS_0024_003C_003E8__locals0.result.FirstRegisterUser = text + " (" + text4 + ")";
						CS_0024_003C_003E8__locals0.result.EditUser = text2 + " (" + text6 + ") (" + text5 + ")";
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
					}
				}
				if (CS_0024_003C_003E8__locals0.result != null && CS_0024_003C_003E8__locals0.result.SaleCenterId.GetValueOrDefault() != 0)
				{
					WSspSelectSaleCenterWithId_Result wSspSelectSaleCenterWithId_Result = Enumerable.FirstOrDefault<WSspSelectSaleCenterWithId_Result>((IEnumerable<WSspSelectSaleCenterWithId_Result>)_dbII.WSspSelectSaleCenterWithId(CS_0024_003C_003E8__locals0.result.SaleCenterId, CS_0024_003C_003E8__locals0.currLangID, result));
					if (wSspSelectSaleCenterWithId_Result != null)
					{
						CS_0024_003C_003E8__locals0.result.SaleCenterName = wSspSelectSaleCenterWithId_Result.SaleCenterName ?? "";
					}
				}
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return Json(CS_0024_003C_003E8__locals0.result, JsonRequestBehavior.AllowGet);
	}

	private void FillDropdownPordDefSetting()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectPreOrderVerifiers_Result> list = Enumerable.ToList<CRMspSelectPreOrderVerifiers_Result>((IEnumerable<CRMspSelectPreOrderVerifiers_Result>)_db.CRMspSelectPreOrderVerifiers(UserLogin.CurrentUser.UserId, lCID, result, result2));
			List<SelectListItem> list2 = new List<SelectListItem>();
			list2.AddRange(Enumerable.Select<CRMspSelectPreOrderVerifiers_Result, SelectListItem>((IEnumerable<CRMspSelectPreOrderVerifiers_Result>)list, (Func<CRMspSelectPreOrderVerifiers_Result, SelectListItem>)((CRMspSelectPreOrderVerifiers_Result item) => new SelectListItem
			{
				Text = item.UserName,
				Value = item.LinkedUserId.ToString(),
				Selected = false
			})));
			base.ViewBag.VerifierRequestList = list2;
			List<WSspSelectPreOrderDefaultSettingUsers_Result> list3 = Enumerable.ToList<WSspSelectPreOrderDefaultSettingUsers_Result>((IEnumerable<WSspSelectPreOrderDefaultSettingUsers_Result>)_db.WSspSelectPreOrderDefaultSettingUsers(UserLogin.CurrentUser.UserId, lCID, result, result2));
			List<SelectListItem> list4 = new List<SelectListItem>();
			list4.AddRange(Enumerable.Select<WSspSelectPreOrderDefaultSettingUsers_Result, SelectListItem>((IEnumerable<WSspSelectPreOrderDefaultSettingUsers_Result>)list3, (Func<WSspSelectPreOrderDefaultSettingUsers_Result, SelectListItem>)((WSspSelectPreOrderDefaultSettingUsers_Result item) => new SelectListItem
			{
				Text = item.UserName,
				Value = item.UserId.ToString(),
				Selected = false
			})));
			base.ViewBag.ReferUserList = list4;
			List<WSspSelectPreOrderStatus_Result> list5 = Enumerable.ToList<WSspSelectPreOrderStatus_Result>((IEnumerable<WSspSelectPreOrderStatus_Result>)_db.WSspSelectPreOrderStatus(lCID, result));
			List<SelectListItem> list6 = new List<SelectListItem>();
			list6.AddRange(Enumerable.Select<WSspSelectPreOrderStatus_Result, SelectListItem>((IEnumerable<WSspSelectPreOrderStatus_Result>)list5, (Func<WSspSelectPreOrderStatus_Result, SelectListItem>)((WSspSelectPreOrderStatus_Result item) => new SelectListItem
			{
				Text = item.PreOrderStatus,
				Value = item.PreOrderStatusId.ToString(),
				Selected = false
			})));
			base.ViewBag.PordStatusList = list6;
			List<WSspSelectPreOrderOpr_Result> list7 = Enumerable.ToList<WSspSelectPreOrderOpr_Result>((IEnumerable<WSspSelectPreOrderOpr_Result>)_db.WSspSelectPreOrderOpr(lCID, result));
			List<SelectListItem> list8 = new List<SelectListItem>();
			list8.AddRange(Enumerable.Select<WSspSelectPreOrderOpr_Result, SelectListItem>((IEnumerable<WSspSelectPreOrderOpr_Result>)list7, (Func<WSspSelectPreOrderOpr_Result, SelectListItem>)((WSspSelectPreOrderOpr_Result item) => new SelectListItem
			{
				Text = item.PreOrderOpr,
				Value = item.PreOrderOprID.ToString(),
				Selected = false
			})));
			base.ViewBag.PordOprList = list8;
			List<WSspSelectGuaranty_Result> list9 = Enumerable.ToList<WSspSelectGuaranty_Result>((IEnumerable<WSspSelectGuaranty_Result>)_db.WSspSelectGuaranty(lCID, result));
			List<SelectListItem> list10 = new List<SelectListItem>();
			list10.AddRange(Enumerable.Select<WSspSelectGuaranty_Result, SelectListItem>((IEnumerable<WSspSelectGuaranty_Result>)list9, (Func<WSspSelectGuaranty_Result, SelectListItem>)((WSspSelectGuaranty_Result item) => new SelectListItem
			{
				Text = item.Guaranty,
				Value = item.GuarantyID.ToString(),
				Selected = false
			})));
			base.ViewBag.PordGuarantyList = list10;
			List<WSspSelectDeliveryTime_Result> list11 = Enumerable.ToList<WSspSelectDeliveryTime_Result>((IEnumerable<WSspSelectDeliveryTime_Result>)_db.WSspSelectDeliveryTime(lCID, result));
			List<SelectListItem> list12 = new List<SelectListItem>();
			list12.AddRange(Enumerable.Select<WSspSelectDeliveryTime_Result, SelectListItem>((IEnumerable<WSspSelectDeliveryTime_Result>)list11, (Func<WSspSelectDeliveryTime_Result, SelectListItem>)((WSspSelectDeliveryTime_Result item) => new SelectListItem
			{
				Text = item.DeliveryTime,
				Value = item.DeliveryTimeID.ToString(),
				Selected = false
			})));
			base.ViewBag.PordDeliveryTimeList = list12;
			List<WSspSelectPayCondition_Result> list13 = Enumerable.ToList<WSspSelectPayCondition_Result>((IEnumerable<WSspSelectPayCondition_Result>)_db.WSspSelectPayCondition(lCID, result));
			List<SelectListItem> list14 = new List<SelectListItem>();
			list14.AddRange(Enumerable.Select<WSspSelectPayCondition_Result, SelectListItem>((IEnumerable<WSspSelectPayCondition_Result>)list13, (Func<WSspSelectPayCondition_Result, SelectListItem>)((WSspSelectPayCondition_Result item) => new SelectListItem
			{
				Text = item.PayCondition,
				Value = item.PayConditionID.ToString(),
				Selected = false
			})));
			base.ViewBag.PordPayConditionList = list14;
			List<WSspSelectCreditDuration_Result> list15 = Enumerable.ToList<WSspSelectCreditDuration_Result>((IEnumerable<WSspSelectCreditDuration_Result>)_db.WSspSelectCreditDuration(lCID, result));
			List<SelectListItem> list16 = new List<SelectListItem>();
			list16.AddRange(Enumerable.Select<WSspSelectCreditDuration_Result, SelectListItem>((IEnumerable<WSspSelectCreditDuration_Result>)list15, (Func<WSspSelectCreditDuration_Result, SelectListItem>)((WSspSelectCreditDuration_Result item) => new SelectListItem
			{
				Text = item.CreditDuration,
				Value = item.CreditDurationID.ToString(),
				Selected = false
			})));
			base.ViewBag.PordCreditDurationList = list16;
			List<spSelectPrintFormat_Result> list17 = CRMIdeal.Classes.Helper.PrintFormat.GetspPrintFortants(result2, 1);
			List<SelectListItem> list18 = new List<SelectListItem>();
			list18.AddRange(Enumerable.Select<spSelectPrintFormat_Result, SelectListItem>((IEnumerable<spSelectPrintFormat_Result>)list17, (Func<spSelectPrintFormat_Result, SelectListItem>)((spSelectPrintFormat_Result item) => new SelectListItem
			{
				Text = item.Title,
				Value = item.PrintFormatID.ToString(),
				Selected = false
			})));
			base.ViewBag.PordPrintFormatList = list18;
			List<WSspSelectPreOrderOpr_Result> list19 = Enumerable.ToList<WSspSelectPreOrderOpr_Result>((IEnumerable<WSspSelectPreOrderOpr_Result>)_db.WSspSelectPreOrderOpr(lCID, result));
			List<SelectListItem> list20 = new List<SelectListItem>();
			list20.AddRange(Enumerable.Select<WSspSelectPreOrderOpr_Result, SelectListItem>((IEnumerable<WSspSelectPreOrderOpr_Result>)list19, (Func<WSspSelectPreOrderOpr_Result, SelectListItem>)((WSspSelectPreOrderOpr_Result item) => new SelectListItem
			{
				Text = item.PreOrderOpr,
				Value = item.PreOrderOprID.ToString(),
				Selected = false
			})));
			base.ViewBag.PordOprList = list20;
			List<WSspSelectVerificationWorkFlowWithObjectType_Result> list21 = Enumerable.ToList<WSspSelectVerificationWorkFlowWithObjectType_Result>((IEnumerable<WSspSelectVerificationWorkFlowWithObjectType_Result>)_db.WSspSelectVerificationWorkFlowWithObjectType(10, lCID, result));
			List<SelectListItem> list22 = new List<SelectListItem>();
			list22.AddRange(Enumerable.Select<WSspSelectVerificationWorkFlowWithObjectType_Result, SelectListItem>((IEnumerable<WSspSelectVerificationWorkFlowWithObjectType_Result>)list21, (Func<WSspSelectVerificationWorkFlowWithObjectType_Result, SelectListItem>)((WSspSelectVerificationWorkFlowWithObjectType_Result item) => new SelectListItem
			{
				Text = item.VerificationWorkFlowTitle,
				Value = item.VerificationWorkFlowId.ToString(),
				Selected = false
			})));
			base.ViewBag.PordVerificationWorkflowList = list22;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
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
	public JsonResult GetPreOrderTypes()
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
	public JsonResult GetWareHouse()
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
		base.ViewBag.WareHouseList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetProductPriceGroup()
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
			List<WSspSelectProductPriceGroup_Result> list2 = Enumerable.ToList<WSspSelectProductPriceGroup_Result>((IEnumerable<WSspSelectProductPriceGroup_Result>)_db.WSspSelectProductPriceGroup(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectProductPriceGroup_Result, SelectListItem>((IEnumerable<WSspSelectProductPriceGroup_Result>)list2, (Func<WSspSelectProductPriceGroup_Result, SelectListItem>)((WSspSelectProductPriceGroup_Result item) => new SelectListItem
			{
				Text = item.ProductPriceGroupName,
				Value = item.ProductPriceGroupID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ProductPriceGroupList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetSeller()
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
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<CRMspSelectActiveUsers_Result> list2 = Enumerable.ToList<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)_db.CRMspSelectActiveUsers(lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)list2, (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result item) => new SelectListItem
			{
				Text = item.Name,
				Value = item.UserId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.SellerList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetEmailUsersInfo(int userId = 0)
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
			if (userId == 0)
			{
				userId = UserLogin.CurrentUser.UserId;
			}
			List<EmailspSelectActiveEmailUsersInfoByUserId_Result> list2 = Enumerable.ToList<EmailspSelectActiveEmailUsersInfoByUserId_Result>((IEnumerable<EmailspSelectActiveEmailUsersInfoByUserId_Result>)_db.EmailspSelectActiveEmailUsersInfoByUserId(userId));
			list.AddRange(Enumerable.Select<EmailspSelectActiveEmailUsersInfoByUserId_Result, SelectListItem>((IEnumerable<EmailspSelectActiveEmailUsersInfoByUserId_Result>)list2, (Func<EmailspSelectActiveEmailUsersInfoByUserId_Result, SelectListItem>)((EmailspSelectActiveEmailUsersInfoByUserId_Result item) => new SelectListItem
			{
				Text = item.euNikeName + "  [ " + item.euNikeEmail + " ]",
				Value = item.EmailUsersInfoId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.EmailUsersInfoList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetEmailUserDefaultSetting(int userId = 0)
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
			if (userId == 0)
			{
				userId = UserLogin.CurrentUser.UserId;
			}
			List<EmailspSelectEmailUserDefaultSettingByUser_Result> list2 = Enumerable.ToList<EmailspSelectEmailUserDefaultSettingByUser_Result>((IEnumerable<EmailspSelectEmailUserDefaultSettingByUser_Result>)_db.EmailspSelectEmailUserDefaultSettingByUser(userId));
			list.AddRange(Enumerable.Select<EmailspSelectEmailUserDefaultSettingByUser_Result, SelectListItem>((IEnumerable<EmailspSelectEmailUserDefaultSettingByUser_Result>)list2, (Func<EmailspSelectEmailUserDefaultSettingByUser_Result, SelectListItem>)((EmailspSelectEmailUserDefaultSettingByUser_Result item) => new SelectListItem
			{
				Text = item.eudTitle,
				Value = item.EmailUserDefaultSettingId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.EmailUserDefaultSettingList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetSaleCenters()
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
			List<WSspSelectSaleCenters_Result> list2 = Enumerable.ToList<WSspSelectSaleCenters_Result>((IEnumerable<WSspSelectSaleCenters_Result>)_db.WSspSelectSaleCenters(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectSaleCenters_Result, SelectListItem>((IEnumerable<WSspSelectSaleCenters_Result>)list2, (Func<WSspSelectSaleCenters_Result, SelectListItem>)((WSspSelectSaleCenters_Result item) => new SelectListItem
			{
				Text = item.SaleCenterName,
				Value = item.SaleCenterId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.SaleCenterList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult SearchSaleCenters(string value, int? saleCenterId = 0)
	{
		List<WSspSearchSaleCenters_Result> list = new List<WSspSearchSaleCenters_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			list = Enumerable.ToList<WSspSearchSaleCenters_Result>((IEnumerable<WSspSearchSaleCenters_Result>)_dbI.WSspSearchSaleCenters(value, lCID, result));
			int num = 600;
			if (list != null && Enumerable.Any<WSspSearchSaleCenters_Result>((IEnumerable<WSspSearchSaleCenters_Result>)list))
			{
				list = ((!string.IsNullOrWhiteSpace(value)) ? Enumerable.ToList<WSspSearchSaleCenters_Result>(Enumerable.Take<WSspSearchSaleCenters_Result>((IEnumerable<WSspSearchSaleCenters_Result>)list, num)) : ((saleCenterId.HasValue && saleCenterId != 0 && string.IsNullOrWhiteSpace(value)) ? Enumerable.ToList<WSspSearchSaleCenters_Result>(Enumerable.Take<WSspSearchSaleCenters_Result>(Enumerable.Where<WSspSearchSaleCenters_Result>((IEnumerable<WSspSearchSaleCenters_Result>)list, (Func<WSspSearchSaleCenters_Result, bool>)((WSspSearchSaleCenters_Result m) => m.SaleCenterId == saleCenterId)), num)) : ((!saleCenterId.HasValue || saleCenterId == 0) ? Enumerable.ToList<WSspSearchSaleCenters_Result>(Enumerable.Take<WSspSearchSaleCenters_Result>((IEnumerable<WSspSearchSaleCenters_Result>)list, num)) : Enumerable.ToList<WSspSearchSaleCenters_Result>(Enumerable.Take<WSspSearchSaleCenters_Result>(Enumerable.Where<WSspSearchSaleCenters_Result>((IEnumerable<WSspSearchSaleCenters_Result>)list, (Func<WSspSearchSaleCenters_Result, bool>)((WSspSearchSaleCenters_Result m) => m.SaleCenterId == saleCenterId)), num)))));
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
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetDefPayType()
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
			int value = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserId : 0);
			List<WSspSelectActiveOrderPaymentTypes_Result> list2 = Enumerable.ToList<WSspSelectActiveOrderPaymentTypes_Result>((IEnumerable<WSspSelectActiveOrderPaymentTypes_Result>)_dbI.WSspSelectActiveOrderPaymentTypes(lCID, result, value));
			list.AddRange(Enumerable.Select<WSspSelectActiveOrderPaymentTypes_Result, SelectListItem>((IEnumerable<WSspSelectActiveOrderPaymentTypes_Result>)list2, (Func<WSspSelectActiveOrderPaymentTypes_Result, SelectListItem>)((WSspSelectActiveOrderPaymentTypes_Result item) => new SelectListItem
			{
				Text = item.ordpayType,
				Value = item.OrderPaymentTypeId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.DefPayTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetSaleAreas()
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
			List<WSspSelectSaleAreas_Result> list2 = Enumerable.ToList<WSspSelectSaleAreas_Result>((IEnumerable<WSspSelectSaleAreas_Result>)_dbII.WSspSelectSaleAreas(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectSaleAreas_Result, SelectListItem>((IEnumerable<WSspSelectSaleAreas_Result>)list2, (Func<WSspSelectSaleAreas_Result, SelectListItem>)((WSspSelectSaleAreas_Result item) => new SelectListItem
			{
				Text = item.SaleAreaName,
				Value = item.SaleAreaId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.SaleAreaList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult DeleteDefaultSetting(int id)
	{
		string data = "";
		try
		{
			WSPreOrderDefaultSetting wSPreOrderDefaultSetting = _dbTbl.WSPreOrderDefaultSetting.Find(id);
			if (wSPreOrderDefaultSetting != null)
			{
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)Enumerable.ToList<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteWSPreOrderDefaultSetting(id)));
				if (mct_Result != null && mct_Result.Result > 0)
				{
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSPreOrderDefaultSetting", wSPreOrderDefaultSetting.ReferUserId);
					data = "ok";
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
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmPreOrderDefultSetting", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult Index(WSPreOrderDefaultSettingLanguageViewModel vm)
	{
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_033c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0390: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e4: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass21_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass21_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string appType = CS_0024_003C_003E8__locals0.vm.AppType;
		FillDropdownPordDefSetting();
		GetCurrencyUnit();
		GetDeliveryTerms();
		GetPreOrderTypes();
		GetWareHouse();
		GetProductPriceGroup();
		GetSeller();
		GetEmailUsersInfo();
		GetEmailUserDefaultSetting();
		GetDefPayType();
		GetSaleAreas();
		CS_0024_003C_003E8__locals0.vm.ReferUserId = CS_0024_003C_003E8__locals0.vm.FPId;
		string accessUserJson = CS_0024_003C_003E8__locals0.vm.AccessUserJson;
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.Title_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.Title_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.Title,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.Subject_Lang))
		{
			list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.Subject_Lang);
		}
		list2.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.Subject,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.SpecialWord_Lang))
		{
			list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.SpecialWord_Lang);
		}
		list3.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.SpecialWord,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.DescriptionI_Lang))
		{
			list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.DescriptionI_Lang);
		}
		list4.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.DescriptionI,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.DescriptionII_Lang))
		{
			list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.DescriptionII_Lang);
		}
		list5.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.DescriptionII,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.SigningI_Lang))
		{
			list6 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.SigningI_Lang);
		}
		list6.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.SigningI,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list7 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.SigningII_Lang))
		{
			list7 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.SigningII_Lang);
		}
		list7.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.SigningII,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list8 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.SigningIII_Lang))
		{
			list8 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.SigningIII_Lang);
		}
		list8.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.SigningIII,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list9 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.Address_Lang))
		{
			list9 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.Address_Lang);
		}
		list9.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.Address,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list10 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.SettingTitle_Lang))
		{
			list10 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.SettingTitle_Lang);
		}
		list10.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.SettingTitle,
			LanguageId = lCID
		});
		string text = "";
		if (CS_0024_003C_003E8__locals0.vm.SettingTitle == null && CS_0024_003C_003E8__locals0.vm.SettingTitle == "")
		{
			text = text + Messages.CheckSettingTitle + "<br/>";
		}
		else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.SettingTitle, list10))
		{
			text = text + Messages.CheckSettingTitleLang + "<br>";
		}
		if (text != "")
		{
			base.ViewBag.Error = text;
			return View(CS_0024_003C_003E8__locals0.vm);
		}
		if (!base.ModelState.IsValid)
		{
			base.ViewBag.Error = Messages.frmErrorMessage + "<br/>" + string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
		}
		else
		{
			DateTime now = DateTime.Now;
			WSPreOrderDefaultSetting wSPreOrderDefaultSetting = new WSPreOrderDefaultSetting();
			if (CS_0024_003C_003E8__locals0.vm.PreOrderSettingID > 0)
			{
				DbSet<WSPreOrderDefaultSetting> wSPreOrderDefaultSetting2 = _dbTbl.WSPreOrderDefaultSetting;
				ParameterExpression val = Expression.Parameter(typeof(WSPreOrderDefaultSetting), "c");
				wSPreOrderDefaultSetting = Queryable.FirstOrDefault<WSPreOrderDefaultSetting>((IQueryable<WSPreOrderDefaultSetting>)wSPreOrderDefaultSetting2, Expression.Lambda<Func<WSPreOrderDefaultSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass21_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			}
			wSPreOrderDefaultSetting.UserId = UserLogin.CurrentUser.UserId;
			wSPreOrderDefaultSetting.RegisterDate = now;
			wSPreOrderDefaultSetting.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			wSPreOrderDefaultSetting.Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			wSPreOrderDefaultSetting.AppType = Configuration.AppType;
			wSPreOrderDefaultSetting.PreOrderSettingID = CS_0024_003C_003E8__locals0.vm.PreOrderSettingID;
			wSPreOrderDefaultSetting.AccountNumberI = CS_0024_003C_003E8__locals0.vm.AccountNumberI;
			wSPreOrderDefaultSetting.Email = CS_0024_003C_003E8__locals0.vm.Email;
			wSPreOrderDefaultSetting.SignatureId = CS_0024_003C_003E8__locals0.vm.SignatureId;
			wSPreOrderDefaultSetting.DeliveryTimeId = CS_0024_003C_003E8__locals0.vm.DeliveryTimeId;
			wSPreOrderDefaultSetting.RightLogoId = CS_0024_003C_003E8__locals0.vm.RightLogoId;
			wSPreOrderDefaultSetting.AccountNumberII = CS_0024_003C_003E8__locals0.vm.AccountNumberII;
			wSPreOrderDefaultSetting.CalculateTax = CS_0024_003C_003E8__locals0.vm.CalculateTax;
			wSPreOrderDefaultSetting.CreditDurationId = CS_0024_003C_003E8__locals0.vm.CreditDurationId;
			wSPreOrderDefaultSetting.LeftLogoId = CS_0024_003C_003E8__locals0.vm.LeftLogoId;
			wSPreOrderDefaultSetting.AccountShabaNumberI = CS_0024_003C_003E8__locals0.vm.AccountShabaNumberI;
			wSPreOrderDefaultSetting.VerifierRequestId = CS_0024_003C_003E8__locals0.vm.VerifierRequestId;
			wSPreOrderDefaultSetting.PayConditionId = CS_0024_003C_003E8__locals0.vm.PayConditionId;
			wSPreOrderDefaultSetting.PrintFormatId = CS_0024_003C_003E8__locals0.vm.PrintFormatId;
			wSPreOrderDefaultSetting.Fax = CS_0024_003C_003E8__locals0.vm.Fax;
			wSPreOrderDefaultSetting.WebSite = CS_0024_003C_003E8__locals0.vm.WebSite;
			wSPreOrderDefaultSetting.GuarantyId = CS_0024_003C_003E8__locals0.vm.GuarantyId;
			wSPreOrderDefaultSetting.Telephone = CS_0024_003C_003E8__locals0.vm.Telephone;
			wSPreOrderDefaultSetting.TaxIndex = CS_0024_003C_003E8__locals0.vm.TaxIndex;
			wSPreOrderDefaultSetting.AccountShabaNumberII = CS_0024_003C_003E8__locals0.vm.AccountShabaNumberII;
			wSPreOrderDefaultSetting.ReferUserId = CS_0024_003C_003E8__locals0.vm.ReferUserId;
			wSPreOrderDefaultSetting.PreOrderOprID = CS_0024_003C_003E8__locals0.vm.PreOrderOprID;
			wSPreOrderDefaultSetting.VerificationWorkFlowId = CS_0024_003C_003E8__locals0.vm.VerificationWorkFlowId;
			wSPreOrderDefaultSetting.CurrencyUnitId = CS_0024_003C_003E8__locals0.vm.CurrencyUnitId;
			wSPreOrderDefaultSetting.CurrencyUnitIdI = CS_0024_003C_003E8__locals0.vm.CurrencyUnitIdI;
			wSPreOrderDefaultSetting.PreOrderTypeId = CS_0024_003C_003E8__locals0.vm.PreOrderTypeId;
			wSPreOrderDefaultSetting.DeliveryTermId = CS_0024_003C_003E8__locals0.vm.DeliveryTermId;
			wSPreOrderDefaultSetting.DefWHId = CS_0024_003C_003E8__locals0.vm.DefWHId;
			wSPreOrderDefaultSetting.DefPrdPriceGroupId = CS_0024_003C_003E8__locals0.vm.DefPrdPriceGroupId;
			wSPreOrderDefaultSetting.SellerId = CS_0024_003C_003E8__locals0.vm.SellerId;
			wSPreOrderDefaultSetting.EmailUsersInfoId = CS_0024_003C_003E8__locals0.vm.EmailUsersInfoId;
			wSPreOrderDefaultSetting.EmailUserDefaultSettingId = CS_0024_003C_003E8__locals0.vm.EmailUserDefaultSettingId;
			wSPreOrderDefaultSetting.SaleCenterId = CS_0024_003C_003E8__locals0.vm.SaleCenterId;
			wSPreOrderDefaultSetting.DefPayTypeId = CS_0024_003C_003E8__locals0.vm.DefPayTypeId;
			wSPreOrderDefaultSetting.SaleCenterId = CS_0024_003C_003E8__locals0.vm.SaleCenterId;
			wSPreOrderDefaultSetting.SaleAreaId = CS_0024_003C_003E8__locals0.vm.SaleAreaId;
			wSPreOrderDefaultSetting.TaxIndexItem = CS_0024_003C_003E8__locals0.vm.TaxIndexItem;
			wSPreOrderDefaultSetting.CalculateTaxItem = CS_0024_003C_003E8__locals0.vm.CalculateTaxItem;
			wSPreOrderDefaultSetting.PublicMode = CS_0024_003C_003E8__locals0.vm.PublicMode.GetValueOrDefault(1);
			wSPreOrderDefaultSetting.InActive = CS_0024_003C_003E8__locals0.vm.InActive;
			if (((int?)CS_0024_003C_003E8__locals0.vm.PublicMode).GetValueOrDefault() == 3 && !string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.AccessUserJson))
			{
				try
				{
					JArray jArray = JArray.Parse(CS_0024_003C_003E8__locals0.vm.AccessUserJson);
					JArray jArray2 = new JArray();
					foreach (JToken item in jArray)
					{
						JObject jObject = new JObject();
						int result = 0;
						int.TryParse(item["id"]?.ToString(), out result);
						if (CS_0024_003C_003E8__locals0.vm.ReferUserId != result)
						{
							jObject["UserId"] = result.ToString();
							jArray2.Add(jObject);
						}
					}
					CS_0024_003C_003E8__locals0.vm.AccessUserJson = jArray2.ToString(Formatting.None);
				}
				catch
				{
					CS_0024_003C_003E8__locals0.vm.AccessUserJson = null;
				}
			}
			else
			{
				CS_0024_003C_003E8__locals0.vm.AccessUserJson = null;
			}
			wSPreOrderDefaultSetting.AccessUserJson = CS_0024_003C_003E8__locals0.vm.AccessUserJson;
			wSPreOrderDefaultSetting.Title = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
			wSPreOrderDefaultSetting.Subject = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
			wSPreOrderDefaultSetting.SpecialWord = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
			wSPreOrderDefaultSetting.DescriptionI = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
			wSPreOrderDefaultSetting.DescriptionII = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
			wSPreOrderDefaultSetting.SigningI = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
			wSPreOrderDefaultSetting.SigningII = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
			wSPreOrderDefaultSetting.SigningIII = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
			wSPreOrderDefaultSetting.Address = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
			wSPreOrderDefaultSetting.SettingTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
			try
			{
				if (appType == "insert")
				{
					wSPreOrderDefaultSetting.FPId = Financial.Get().Id;
					wSPreOrderDefaultSetting.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
					wSPreOrderDefaultSetting.FirstRegisterDate = DateTime.Now;
					wSPreOrderDefaultSetting.FirstRegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
					wSPreOrderDefaultSetting.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
					wSPreOrderDefaultSetting.GUId = Guid.NewGuid();
					_dbTbl.WSPreOrderDefaultSetting.Add(wSPreOrderDefaultSetting);
					_dbTbl.SaveChanges();
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
					{
						WSPreOrderDefaultSetting_Lang wSPreOrderDefaultSetting_Lang = new WSPreOrderDefaultSetting_Lang();
						wSPreOrderDefaultSetting_Lang.LanguageID = lang.LanguageID;
						wSPreOrderDefaultSetting_Lang.PreOrderSettingID = wSPreOrderDefaultSetting.PreOrderSettingID;
						wSPreOrderDefaultSetting_Lang.Title = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSPreOrderDefaultSetting_Lang.Subject = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSPreOrderDefaultSetting_Lang.SpecialWord = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSPreOrderDefaultSetting_Lang.DescriptionI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSPreOrderDefaultSetting_Lang.DescriptionII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSPreOrderDefaultSetting_Lang.SigningI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSPreOrderDefaultSetting_Lang.SigningII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSPreOrderDefaultSetting_Lang.SigningIII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSPreOrderDefaultSetting_Lang.Address = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSPreOrderDefaultSetting_Lang.SettingTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						_dbTbl.WSPreOrderDefaultSetting_Lang.Add(wSPreOrderDefaultSetting_Lang);
						_dbTbl.SaveChanges();
					}
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSPreOrderDefaultSetting", CS_0024_003C_003E8__locals0.vm.ReferUserId);
					base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
				}
				else if (appType == "edit")
				{
					_dbTbl.Entry(wSPreOrderDefaultSetting).State = EntityState.Modified;
					_dbTbl.SaveChanges();
					using (List<Languages>.Enumerator enumerator2 = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							_003C_003Ec__DisplayClass21_2 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass21_2();
							CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
							CS_0024_003C_003E8__locals2.lang = enumerator2.Current;
							DbSet<WSPreOrderDefaultSetting_Lang> wSPreOrderDefaultSetting_Lang2 = _dbTbl.WSPreOrderDefaultSetting_Lang;
							ParameterExpression val = Expression.Parameter(typeof(WSPreOrderDefaultSetting_Lang), "c");
							WSPreOrderDefaultSetting_Lang wSPreOrderDefaultSetting_Lang3 = Queryable.FirstOrDefault<WSPreOrderDefaultSetting_Lang>((IQueryable<WSPreOrderDefaultSetting_Lang>)wSPreOrderDefaultSetting_Lang2, Expression.Lambda<Func<WSPreOrderDefaultSetting_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals2, typeof(_003C_003Ec__DisplayClass21_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals2, typeof(_003C_003Ec__DisplayClass21_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (wSPreOrderDefaultSetting_Lang3 != null)
							{
								wSPreOrderDefaultSetting_Lang3.Title = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								wSPreOrderDefaultSetting_Lang3.Subject = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								wSPreOrderDefaultSetting_Lang3.SpecialWord = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								wSPreOrderDefaultSetting_Lang3.DescriptionI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								wSPreOrderDefaultSetting_Lang3.DescriptionII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								wSPreOrderDefaultSetting_Lang3.SigningI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								wSPreOrderDefaultSetting_Lang3.SigningII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								wSPreOrderDefaultSetting_Lang3.SigningIII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								wSPreOrderDefaultSetting_Lang3.Address = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								wSPreOrderDefaultSetting_Lang3.SettingTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								_dbTbl.Entry(wSPreOrderDefaultSetting_Lang3).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							wSPreOrderDefaultSetting_Lang3 = new WSPreOrderDefaultSetting_Lang();
							wSPreOrderDefaultSetting_Lang3.LanguageID = CS_0024_003C_003E8__locals2.lang.LanguageID;
							wSPreOrderDefaultSetting_Lang3.PreOrderSettingID = wSPreOrderDefaultSetting.PreOrderSettingID;
							wSPreOrderDefaultSetting_Lang3.Title = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
							wSPreOrderDefaultSetting_Lang3.Subject = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
							wSPreOrderDefaultSetting_Lang3.SpecialWord = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
							wSPreOrderDefaultSetting_Lang3.DescriptionI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
							wSPreOrderDefaultSetting_Lang3.DescriptionII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
							wSPreOrderDefaultSetting_Lang3.SigningI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
							wSPreOrderDefaultSetting_Lang3.SigningII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
							wSPreOrderDefaultSetting_Lang3.SigningIII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
							wSPreOrderDefaultSetting_Lang3.Address = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
							wSPreOrderDefaultSetting_Lang3.SettingTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
							_dbTbl.WSPreOrderDefaultSetting_Lang.Add(wSPreOrderDefaultSetting_Lang3);
							_dbTbl.SaveChanges();
						}
					}
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSPreOrderDefaultSetting", CS_0024_003C_003E8__locals0.vm.ReferUserId);
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
			}
			catch (DbEntityValidationException e)
			{
				ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
				base.ViewBag.Error = Messages.frmErrorMessage;
			}
			catch (Exception e2)
			{
				ErrorSignal.FromCurrentContext().Raise(e2);
				base.ViewBag.Error = Messages.frmErrorMessage;
			}
		}
		CS_0024_003C_003E8__locals0.vm.AppType = appType;
		CS_0024_003C_003E8__locals0.vm.AccessUserJson = accessUserJson;
		return View(CS_0024_003C_003E8__locals0.vm);
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

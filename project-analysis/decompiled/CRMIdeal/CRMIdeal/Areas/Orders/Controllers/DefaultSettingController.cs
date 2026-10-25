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

namespace CRMIdeal.Areas.Orders.Controllers;

public class DefaultSettingController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass24_0
	{
		public int id;

		public int currLangID;

		public WSOrderDefaultSettingLanguageViewModel result;

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

		internal bool _003CGetDefaultSettingById_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__24(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__25(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__26(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__27(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__28(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__29(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__30(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__31(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__32(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__33(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__34(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__35(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__36(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__37(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__38(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__39(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__40(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__41(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__42(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__43(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__44(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__45(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetDefaultSettingById_003Eb__48(CRMspSelectUsersByIds_Result c)
		{
			return c.UserId == result.FirstRegisterUserId;
		}

		internal bool _003CGetDefaultSettingById_003Eb__49(CRMspSelectUsersByIds_Result c)
		{
			return c.UserId == result.UserId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass26_0
	{
		public int id;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public WSOrderDefaultSettingLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__39;

		public Func<Languages, bool> _003C_003E9__62;

		internal bool _003CIndex_003Eb__31(WSspCheckDefaultOrderSettingUserConflict_Result s)
		{
			if (s.UserId == vm.ReferUserId)
			{
				return s.Priority.GetValueOrDefault() == 1;
			}
			return false;
		}

		internal bool _003CIndex_003Eb__32(WSspCheckDefaultOrderSettingUserConflict_Result s)
		{
			if (s.UserId == vm.ReferUserId)
			{
				return s.Priority.GetValueOrDefault() == 2;
			}
			return false;
		}

		internal bool _003CIndex_003Eb__33(WSspCheckDefaultOrderSettingUserConflict_Result s)
		{
			if (s.UserId == vm.ReferUserId)
			{
				return s.Priority.GetValueOrDefault() == 2;
			}
			return false;
		}

		internal bool _003CIndex_003Eb__35(WSspCheckDefaultOrderSettingUserConflict_Result s)
		{
			if (s.UserId == vm.ReferUserId)
			{
				return s.Priority.GetValueOrDefault() == 1;
			}
			return false;
		}

		internal bool _003CIndex_003Eb__36(WSspCheckDefaultOrderSettingUserConflict_Result s)
		{
			if (s.UserId == vm.ReferUserId)
			{
				return s.Priority.GetValueOrDefault() == 2;
			}
			return false;
		}

		internal bool _003CIndex_003Eb__37(WSspCheckDefaultOrderSettingUserConflict_Result s)
		{
			if (s.UserId == vm.ReferUserId)
			{
				return s.Priority.GetValueOrDefault() == 2;
			}
			return false;
		}

		internal bool _003CIndex_003Eb__1(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CIndex_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

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

		internal bool _003CIndex_003Eb__39(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CIndex_003Eb__62(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_3
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals1;

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

		internal bool _003CIndex_003Eb__86(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__87(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__88(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__89(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__90(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__91(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__92(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__93(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__94(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__95(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__96(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__97(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__98(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__99(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__100(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__101(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__102(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__103(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__104(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__105(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__106(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__107(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	private readonly CRMSpIIIEntities _dbIII = new CRMSpIIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actordDefultSetting")]
	public ActionResult Index(int position = 0)
	{
		string formName;
		string actionName;
		switch (position)
		{
		case 0:
			formName = "frmMain";
			actionName = "actordDefultSetting";
			break;
		case 1:
			formName = "frmOrder";
			actionName = "actSetting";
			break;
		default:
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		if (!UserLogin.IsUserAccess(formName, actionName, UserLogin.CurrentUser))
		{
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		WSOrderDefaultSettingLanguageViewModel model = new WSOrderDefaultSettingLanguageViewModel();
		FillDropdownOrdDefSetting();
		GetCurrencyUnit();
		GetDeliveryTerms();
		GetVerifierTitles();
		GetWareHouse();
		GetProductPriceGroup();
		GetSeller();
		GetEmailUsersInfo();
		GetEmailUserDefaultSetting();
		GetVerificationWorkFlow();
		GetDefPayType();
		GetOrdSetPementType();
		GetSaleAreas();
		return View(model);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmOrderDefultSetting", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult Index(WSOrderDefaultSettingLanguageViewModel vm)
	{
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_034a: Unknown result type (might be due to invalid IL or missing references)
		//IL_039e: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0493: Unknown result type (might be due to invalid IL or missing references)
		//IL_0584: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass6_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string appType = CS_0024_003C_003E8__locals0.vm.AppType;
		FillDropdownOrdDefSetting();
		GetCurrencyUnit();
		GetDeliveryTerms();
		GetVerifierTitles();
		GetWareHouse();
		GetProductPriceGroup();
		GetSeller();
		GetEmailUsersInfo();
		GetEmailUserDefaultSetting();
		GetVerificationWorkFlow();
		GetDefPayType();
		GetOrdSetPementType();
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
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.Note_Lang))
		{
			list9 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.Note_Lang);
		}
		list9.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.Note,
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
		List<CommonMultiLanguageViewModel> list11 = new List<CommonMultiLanguageViewModel>();
		List<CrmProjectTitles_LangViewModel> list12 = new List<CrmProjectTitles_LangViewModel>();
		if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.vm.AddPrdValidityPrjTitle))
		{
			CRMspSelectProjectTitlesByVal_Result cRMspSelectProjectTitlesByVal_Result = Enumerable.FirstOrDefault<CRMspSelectProjectTitlesByVal_Result>((IEnumerable<CRMspSelectProjectTitlesByVal_Result>)_dbI.CRMspSelectProjectTitlesByVal(CS_0024_003C_003E8__locals0.vm.AddPrdValidityPrjTitle, lCID, CS_0024_003C_003E8__locals0.defLangID));
			if (cRMspSelectProjectTitlesByVal_Result != null)
			{
				if (!string.IsNullOrEmpty(cRMspSelectProjectTitlesByVal_Result.ProjectTitles_Lang))
				{
					list12 = new JavaScriptSerializer().Deserialize<List<CrmProjectTitles_LangViewModel>>(cRMspSelectProjectTitlesByVal_Result.ProjectTitles_Lang);
				}
				list12.Add(new CrmProjectTitles_LangViewModel
				{
					CrmProjectTitlesLangID = 0,
					ProjectTitleID = cRMspSelectProjectTitlesByVal_Result.ProjectTitleID,
					LanguageID = lCID,
					ProjectTitle = cRMspSelectProjectTitlesByVal_Result.ProjectTitle,
					ProjectTitleDesc = cRMspSelectProjectTitlesByVal_Result.ProjectTitleDesc
				});
			}
		}
		else
		{
			CS_0024_003C_003E8__locals0.vm.AddPrdValidityPrjTitle = "";
			CS_0024_003C_003E8__locals0.vm.AddPrdValidityPrjTitle_Lang = "";
		}
		if (list12 != null && Enumerable.Any<CrmProjectTitles_LangViewModel>((IEnumerable<CrmProjectTitles_LangViewModel>)list12))
		{
			foreach (CrmProjectTitles_LangViewModel item in list12)
			{
				list11.Add(new CommonMultiLanguageViewModel
				{
					Value = item.ProjectTitle,
					LanguageId = item.LanguageID
				});
			}
		}
		if (!Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11))
		{
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.AddPrdValidityPrjTitle_Lang))
			{
				list11 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.AddPrdValidityPrjTitle_Lang);
			}
			list11.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.AddPrdValidityPrjTitle,
				LanguageId = lCID
			});
		}
		string text = "";
		if (CS_0024_003C_003E8__locals0.vm.SettingTitle == null && CS_0024_003C_003E8__locals0.vm.SettingTitle == "")
		{
			text = text + Messages.CheckSettingTitle + "<br/>";
		}
		else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.SettingTitle, list10))
		{
			text = text + Messages.CheckSettingTitleLang + "<br>";
		}
		if (CS_0024_003C_003E8__locals0.vm != null)
		{
			int result = 0;
			decimal result2 = default(decimal);
			bool result3 = false;
			decimal result4 = default(decimal);
			bool result5 = false;
			int.TryParse(CS_0024_003C_003E8__locals0.vm.OrderOprID.ToString(), out result);
			decimal.TryParse(CS_0024_003C_003E8__locals0.vm.TaxIndex.ToString(), out result2);
			bool.TryParse(CS_0024_003C_003E8__locals0.vm.CalculateTax.ToString(), out result3);
			decimal.TryParse(CS_0024_003C_003E8__locals0.vm.TaxIndexItem.ToString(), out result4);
			bool.TryParse(CS_0024_003C_003E8__locals0.vm.CalculateTaxItem.ToString(), out result5);
			if (result != 0)
			{
				WSspSelectOrderOprById_Result wSspSelectOrderOprById_Result = Enumerable.FirstOrDefault<WSspSelectOrderOprById_Result>((IEnumerable<WSspSelectOrderOprById_Result>)_dbI.WSspSelectOrderOprById(result, lCID, CS_0024_003C_003E8__locals0.defLangID));
				if (wSspSelectOrderOprById_Result != null)
				{
					bool result6 = false;
					bool.TryParse(wSspSelectOrderOprById_Result.Taxable.ToString(), out result6);
					if (result6 && ((result3 && result2 == 0m) || !result3) && ((result5 && result4 == 0m) || !result5))
					{
						text = text + "msgErrorOrderOprTaxableSetTaxIndexInOrdDefDSetting".OrderMessages() + "<br>";
					}
				}
			}
		}
		bool result7 = false;
		bool.TryParse(CS_0024_003C_003E8__locals0.vm.IsDefIssueQuickOrder.ToString(), out result7);
		if (text != "")
		{
			base.ViewBag.Error = text;
			return View(CS_0024_003C_003E8__locals0.vm);
		}
		if (!base.ModelState.IsValid)
		{
			base.ViewBag.Error = Messages.frmErrorMessage;
		}
		else
		{
			DateTime now = DateTime.Now;
			WSOrderDefaultSetting wSOrderDefaultSetting = new WSOrderDefaultSetting();
			if (CS_0024_003C_003E8__locals0.vm.OrderSettingID > 0)
			{
				DbSet<WSOrderDefaultSetting> wSOrderDefaultSetting2 = _dbTbl.WSOrderDefaultSetting;
				ParameterExpression val = Expression.Parameter(typeof(WSOrderDefaultSetting), "c");
				wSOrderDefaultSetting = Queryable.FirstOrDefault<WSOrderDefaultSetting>((IQueryable<WSOrderDefaultSetting>)wSOrderDefaultSetting2, Expression.Lambda<Func<WSOrderDefaultSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass6_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			}
			wSOrderDefaultSetting.UserId = UserLogin.CurrentUser.UserId;
			wSOrderDefaultSetting.RegisterDate = now;
			wSOrderDefaultSetting.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			wSOrderDefaultSetting.Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			wSOrderDefaultSetting.AppType = Configuration.AppType;
			wSOrderDefaultSetting.OrderSettingID = CS_0024_003C_003E8__locals0.vm.OrderSettingID;
			wSOrderDefaultSetting.AccountNumberI = CS_0024_003C_003E8__locals0.vm.AccountNumberI;
			wSOrderDefaultSetting.SignatureId = CS_0024_003C_003E8__locals0.vm.SignatureId;
			wSOrderDefaultSetting.RightLogoId = CS_0024_003C_003E8__locals0.vm.RightLogoId;
			wSOrderDefaultSetting.AccountNumberII = CS_0024_003C_003E8__locals0.vm.AccountNumberII;
			wSOrderDefaultSetting.CalculateTax = CS_0024_003C_003E8__locals0.vm.CalculateTax;
			wSOrderDefaultSetting.LeftLogoId = CS_0024_003C_003E8__locals0.vm.LeftLogoId;
			wSOrderDefaultSetting.AccountShabaNumberI = CS_0024_003C_003E8__locals0.vm.AccountShabaNumberI;
			wSOrderDefaultSetting.PrintFormatId = CS_0024_003C_003E8__locals0.vm.PrintFormatId;
			wSOrderDefaultSetting.GuarantyId = CS_0024_003C_003E8__locals0.vm.GuarantyId;
			wSOrderDefaultSetting.TaxIndex = CS_0024_003C_003E8__locals0.vm.TaxIndex;
			wSOrderDefaultSetting.AccountShabaNumberII = CS_0024_003C_003E8__locals0.vm.AccountShabaNumberII;
			wSOrderDefaultSetting.ReferUserId = CS_0024_003C_003E8__locals0.vm.ReferUserId;
			wSOrderDefaultSetting.OrderOprID = CS_0024_003C_003E8__locals0.vm.OrderOprID;
			wSOrderDefaultSetting.AutoGenerateOrdSerial = CS_0024_003C_003E8__locals0.vm.AutoGenerateOrdSerial;
			wSOrderDefaultSetting.CurrencyUnitId = CS_0024_003C_003E8__locals0.vm.CurrencyUnitId;
			wSOrderDefaultSetting.CurrencyUnitIdI = CS_0024_003C_003E8__locals0.vm.CurrencyUnitIdI;
			wSOrderDefaultSetting.DeliveryTermId = CS_0024_003C_003E8__locals0.vm.DeliveryTermId;
			wSOrderDefaultSetting.VerifierRequestId = CS_0024_003C_003E8__locals0.vm.VerifierRequestId;
			wSOrderDefaultSetting.SettlementTypeId = CS_0024_003C_003E8__locals0.vm.SettlementTypeId;
			wSOrderDefaultSetting.DefWHId = CS_0024_003C_003E8__locals0.vm.DefWHId;
			wSOrderDefaultSetting.DefPrdPriceGroupId = CS_0024_003C_003E8__locals0.vm.DefPrdPriceGroupId;
			wSOrderDefaultSetting.SellerId = CS_0024_003C_003E8__locals0.vm.SellerId;
			wSOrderDefaultSetting.EmailUsersInfoId = CS_0024_003C_003E8__locals0.vm.EmailUsersInfoId;
			wSOrderDefaultSetting.EmailUserDefaultSettingId = CS_0024_003C_003E8__locals0.vm.EmailUserDefaultSettingId;
			wSOrderDefaultSetting.VerificationWorkFlowId = CS_0024_003C_003E8__locals0.vm.VerificationWorkFlowId;
			wSOrderDefaultSetting.SaleCenterId = CS_0024_003C_003E8__locals0.vm.SaleCenterId;
			wSOrderDefaultSetting.DefPayTypeId = CS_0024_003C_003E8__locals0.vm.DefPayTypeId;
			wSOrderDefaultSetting.SaleCenterId = CS_0024_003C_003E8__locals0.vm.SaleCenterId;
			wSOrderDefaultSetting.SaleAreaId = CS_0024_003C_003E8__locals0.vm.SaleAreaId;
			wSOrderDefaultSetting.TaxIndexItem = CS_0024_003C_003E8__locals0.vm.TaxIndexItem;
			wSOrderDefaultSetting.CalculateTaxItem = CS_0024_003C_003E8__locals0.vm.CalculateTaxItem;
			List<int> list13 = new List<int>();
			List<int> list14 = new List<int>();
			if (((int?)CS_0024_003C_003E8__locals0.vm.PublicMode).GetValueOrDefault() == 3 && !string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.AccessUserJson))
			{
				try
				{
					foreach (JToken item2 in JArray.Parse(CS_0024_003C_003E8__locals0.vm.AccessUserJson))
					{
						int result8 = 0;
						int.TryParse(item2["UserId"]?.ToString() ?? item2["id"]?.ToString(), out result8);
						if (result8 <= 0 || result8 == CS_0024_003C_003E8__locals0.vm.ReferUserId)
						{
							continue;
						}
						if (CS_0024_003C_003E8__locals0.vm.ActiveInOrder.GetValueOrDefault())
						{
							bool result9 = false;
							bool.TryParse(item2["IsDefIssueOrder"]?.ToString(), out result9);
							if (result9)
							{
								list13.Add(result8);
							}
						}
						if (CS_0024_003C_003E8__locals0.vm.ActiveInQuickOrder.GetValueOrDefault())
						{
							bool result10 = false;
							bool.TryParse(item2["IsDefIssueQuickOrder"]?.ToString(), out result10);
							if (result10)
							{
								list14.Add(result8);
							}
						}
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
			}
			if (CS_0024_003C_003E8__locals0.vm.ReferUserId > 0)
			{
				if (CS_0024_003C_003E8__locals0.vm.ActiveInOrder.GetValueOrDefault() && CS_0024_003C_003E8__locals0.vm.IsDefIssueOrder.GetValueOrDefault())
				{
					list13.Add(CS_0024_003C_003E8__locals0.vm.ReferUserId.Value);
				}
				if (CS_0024_003C_003E8__locals0.vm.ActiveInQuickOrder.GetValueOrDefault() && CS_0024_003C_003E8__locals0.vm.IsDefIssueQuickOrder.GetValueOrDefault())
				{
					list14.Add(CS_0024_003C_003E8__locals0.vm.ReferUserId.Value);
				}
			}
			List<WSspCheckDefaultOrderSettingUserConflict_Result> list15 = new List<WSspCheckDefaultOrderSettingUserConflict_Result>();
			List<WSspCheckDefaultOrderSettingUserConflict_Result> list16 = new List<WSspCheckDefaultOrderSettingUserConflict_Result>();
			if (Enumerable.Any<int>((IEnumerable<int>)list13))
			{
				list15 = Enumerable.ToList<WSspCheckDefaultOrderSettingUserConflict_Result>((IEnumerable<WSspCheckDefaultOrderSettingUserConflict_Result>)_dbIII.WSspCheckDefaultOrderSettingUserConflict(string.Join(",", Enumerable.Distinct<int>((IEnumerable<int>)list13)), CS_0024_003C_003E8__locals0.vm.OrderSettingID, (short)1, lCID, CS_0024_003C_003E8__locals0.defLangID)) ?? new List<WSspCheckDefaultOrderSettingUserConflict_Result>();
			}
			if (Enumerable.Any<int>((IEnumerable<int>)list14))
			{
				list16 = Enumerable.ToList<WSspCheckDefaultOrderSettingUserConflict_Result>((IEnumerable<WSspCheckDefaultOrderSettingUserConflict_Result>)_dbIII.WSspCheckDefaultOrderSettingUserConflict(string.Join(",", Enumerable.Distinct<int>((IEnumerable<int>)list14)), CS_0024_003C_003E8__locals0.vm.OrderSettingID, (short)2, lCID, CS_0024_003C_003E8__locals0.defLangID)) ?? new List<WSspCheckDefaultOrderSettingUserConflict_Result>();
			}
			if (((int?)CS_0024_003C_003E8__locals0.vm.PublicMode).GetValueOrDefault() == 2)
			{
				if (CS_0024_003C_003E8__locals0.vm.ActiveInOrder.HasValue && CS_0024_003C_003E8__locals0.vm.IsDefIssueOrder.HasValue && CS_0024_003C_003E8__locals0.vm.ActiveInOrder.GetValueOrDefault() && CS_0024_003C_003E8__locals0.vm.IsDefIssueOrder.GetValueOrDefault())
				{
					List<WSspCheckPublicDefaultOrderSettingConflict_Result> list17 = Enumerable.ToList<WSspCheckPublicDefaultOrderSettingConflict_Result>((IEnumerable<WSspCheckPublicDefaultOrderSettingConflict_Result>)_dbIII.WSspCheckPublicDefaultOrderSettingConflict(CS_0024_003C_003E8__locals0.vm.OrderSettingID, (short)1, lCID, CS_0024_003C_003E8__locals0.defLangID));
					if (list17 != null && Enumerable.Any<WSspCheckPublicDefaultOrderSettingConflict_Result>((IEnumerable<WSspCheckPublicDefaultOrderSettingConflict_Result>)list17))
					{
						CS_0024_003C_003E8__locals0.vm.IsDefIssueOrder = false;
					}
				}
				if (CS_0024_003C_003E8__locals0.vm.ActiveInQuickOrder.HasValue && CS_0024_003C_003E8__locals0.vm.IsDefIssueQuickOrder.HasValue && CS_0024_003C_003E8__locals0.vm.ActiveInQuickOrder.GetValueOrDefault() && CS_0024_003C_003E8__locals0.vm.IsDefIssueQuickOrder.GetValueOrDefault())
				{
					List<WSspCheckPublicDefaultOrderSettingConflict_Result> list18 = Enumerable.ToList<WSspCheckPublicDefaultOrderSettingConflict_Result>((IEnumerable<WSspCheckPublicDefaultOrderSettingConflict_Result>)_dbIII.WSspCheckPublicDefaultOrderSettingConflict(CS_0024_003C_003E8__locals0.vm.OrderSettingID, (short)2, lCID, CS_0024_003C_003E8__locals0.defLangID));
					if (list18 != null && Enumerable.Any<WSspCheckPublicDefaultOrderSettingConflict_Result>((IEnumerable<WSspCheckPublicDefaultOrderSettingConflict_Result>)list18))
					{
						CS_0024_003C_003E8__locals0.vm.IsDefIssueQuickOrder = false;
					}
				}
			}
			if (((int?)CS_0024_003C_003E8__locals0.vm.PublicMode).GetValueOrDefault() == 3 && !string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.AccessUserJson))
			{
				try
				{
					JArray jArray = JArray.Parse(CS_0024_003C_003E8__locals0.vm.AccessUserJson);
					JArray jArray2 = new JArray();
					foreach (JToken item3 in jArray)
					{
						int userId = 0;
						int.TryParse(item3["UserId"]?.ToString() ?? item3["id"]?.ToString(), out userId);
						if (userId <= 0 || userId == CS_0024_003C_003E8__locals0.vm.ReferUserId)
						{
							continue;
						}
						JObject jObject = new JObject();
						jObject["UserId"] = userId.ToString();
						if (CS_0024_003C_003E8__locals0.vm.ActiveInOrder.GetValueOrDefault())
						{
							bool result11 = false;
							bool.TryParse(item3["IsDefIssueOrder"]?.ToString(), out result11);
							if (!result11)
							{
								jObject["IsDefIssueOrder"] = false;
							}
							else
							{
								bool flag = Enumerable.Any<WSspCheckDefaultOrderSettingUserConflict_Result>((IEnumerable<WSspCheckDefaultOrderSettingUserConflict_Result>)list15, (Func<WSspCheckDefaultOrderSettingUserConflict_Result, bool>)((WSspCheckDefaultOrderSettingUserConflict_Result s) => s.UserId == userId && s.Priority.GetValueOrDefault() == 1));
								bool flag2 = Enumerable.Any<WSspCheckDefaultOrderSettingUserConflict_Result>((IEnumerable<WSspCheckDefaultOrderSettingUserConflict_Result>)list15, (Func<WSspCheckDefaultOrderSettingUserConflict_Result, bool>)((WSspCheckDefaultOrderSettingUserConflict_Result s) => s.UserId == userId && s.Priority.GetValueOrDefault() == 2));
								if (flag)
								{
									jObject["IsDefIssueOrder"] = false;
								}
								else if (flag2 && CS_0024_003C_003E8__locals0.vm.SaveDefSettings.GetValueOrDefault() == 1)
								{
									jObject["IsDefIssueOrder"] = true;
									List<int?> values = Enumerable.ToList<int?>(Enumerable.Distinct<int?>(Enumerable.Select<WSspCheckDefaultOrderSettingUserConflict_Result, int?>(Enumerable.Where<WSspCheckDefaultOrderSettingUserConflict_Result>((IEnumerable<WSspCheckDefaultOrderSettingUserConflict_Result>)list15, (Func<WSspCheckDefaultOrderSettingUserConflict_Result, bool>)((WSspCheckDefaultOrderSettingUserConflict_Result s) => s.UserId == userId && s.Priority.GetValueOrDefault() == 2)), (Func<WSspCheckDefaultOrderSettingUserConflict_Result, int?>)((WSspCheckDefaultOrderSettingUserConflict_Result s) => s.OrderSettingID))));
									_dbIII.WSspUpdateOrderDefaultSettingDefFields(userId, string.Join(",", values), (short)1);
								}
								else if (flag2)
								{
									jObject["IsDefIssueOrder"] = false;
								}
								else
								{
									jObject["IsDefIssueOrder"] = true;
								}
							}
						}
						else
						{
							jObject["IsDefIssueOrder"] = false;
						}
						if (CS_0024_003C_003E8__locals0.vm.ActiveInQuickOrder.GetValueOrDefault())
						{
							bool result12 = false;
							bool.TryParse(item3["IsDefIssueQuickOrder"]?.ToString(), out result12);
							if (!result12)
							{
								jObject["IsDefIssueQuickOrder"] = false;
							}
							else
							{
								bool flag3 = Enumerable.Any<WSspCheckDefaultOrderSettingUserConflict_Result>((IEnumerable<WSspCheckDefaultOrderSettingUserConflict_Result>)list16, (Func<WSspCheckDefaultOrderSettingUserConflict_Result, bool>)((WSspCheckDefaultOrderSettingUserConflict_Result s) => s.UserId == userId && s.Priority.GetValueOrDefault() == 1));
								bool flag4 = Enumerable.Any<WSspCheckDefaultOrderSettingUserConflict_Result>((IEnumerable<WSspCheckDefaultOrderSettingUserConflict_Result>)list16, (Func<WSspCheckDefaultOrderSettingUserConflict_Result, bool>)((WSspCheckDefaultOrderSettingUserConflict_Result s) => s.UserId == userId && s.Priority.GetValueOrDefault() == 2));
								if (flag3)
								{
									jObject["IsDefIssueQuickOrder"] = false;
								}
								else if (flag4 && CS_0024_003C_003E8__locals0.vm.SaveDefSettings.GetValueOrDefault() == 1)
								{
									jObject["IsDefIssueQuickOrder"] = true;
									List<int?> values2 = Enumerable.ToList<int?>(Enumerable.Distinct<int?>(Enumerable.Select<WSspCheckDefaultOrderSettingUserConflict_Result, int?>(Enumerable.Where<WSspCheckDefaultOrderSettingUserConflict_Result>((IEnumerable<WSspCheckDefaultOrderSettingUserConflict_Result>)list16, (Func<WSspCheckDefaultOrderSettingUserConflict_Result, bool>)((WSspCheckDefaultOrderSettingUserConflict_Result s) => s.UserId == userId && s.Priority.GetValueOrDefault() == 2)), (Func<WSspCheckDefaultOrderSettingUserConflict_Result, int?>)((WSspCheckDefaultOrderSettingUserConflict_Result s) => s.OrderSettingID))));
									_dbIII.WSspUpdateOrderDefaultSettingDefFields(userId, string.Join(",", values2), (short)2);
								}
								else if (flag4)
								{
									jObject["IsDefIssueQuickOrder"] = false;
								}
								else
								{
									jObject["IsDefIssueQuickOrder"] = true;
								}
							}
						}
						else
						{
							jObject["IsDefIssueQuickOrder"] = false;
						}
						jArray2.Add(jObject);
					}
					wSOrderDefaultSetting.AccessUserJson = jArray2.ToString(Formatting.None);
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
					wSOrderDefaultSetting.AccessUserJson = null;
				}
			}
			else
			{
				wSOrderDefaultSetting.AccessUserJson = null;
			}
			wSOrderDefaultSetting.PublicMode = CS_0024_003C_003E8__locals0.vm.PublicMode.GetValueOrDefault(1);
			wSOrderDefaultSetting.ActiveInOrder = CS_0024_003C_003E8__locals0.vm.ActiveInOrder;
			wSOrderDefaultSetting.ActiveInQuickOrder = CS_0024_003C_003E8__locals0.vm.ActiveInQuickOrder;
			if (CS_0024_003C_003E8__locals0.vm.ActiveInOrder.HasValue && CS_0024_003C_003E8__locals0.vm.IsDefIssueOrder.HasValue && CS_0024_003C_003E8__locals0.vm.ActiveInOrder.GetValueOrDefault() && CS_0024_003C_003E8__locals0.vm.IsDefIssueOrder.GetValueOrDefault())
			{
				bool flag5 = Enumerable.Any<WSspCheckDefaultOrderSettingUserConflict_Result>((IEnumerable<WSspCheckDefaultOrderSettingUserConflict_Result>)list15, (Func<WSspCheckDefaultOrderSettingUserConflict_Result, bool>)((WSspCheckDefaultOrderSettingUserConflict_Result s) => s.UserId == CS_0024_003C_003E8__locals0.vm.ReferUserId && s.Priority.GetValueOrDefault() == 1));
				bool flag6 = Enumerable.Any<WSspCheckDefaultOrderSettingUserConflict_Result>((IEnumerable<WSspCheckDefaultOrderSettingUserConflict_Result>)list15, (Func<WSspCheckDefaultOrderSettingUserConflict_Result, bool>)((WSspCheckDefaultOrderSettingUserConflict_Result s) => s.UserId == CS_0024_003C_003E8__locals0.vm.ReferUserId && s.Priority.GetValueOrDefault() == 2));
				if (flag5)
				{
					wSOrderDefaultSetting.IsDefIssueOrder = false;
				}
				else if (flag6 && CS_0024_003C_003E8__locals0.vm.SaveDefSettings.GetValueOrDefault() == 1)
				{
					wSOrderDefaultSetting.IsDefIssueOrder = true;
					List<int?> values3 = Enumerable.ToList<int?>(Enumerable.Distinct<int?>(Enumerable.Select<WSspCheckDefaultOrderSettingUserConflict_Result, int?>(Enumerable.Where<WSspCheckDefaultOrderSettingUserConflict_Result>((IEnumerable<WSspCheckDefaultOrderSettingUserConflict_Result>)list15, (Func<WSspCheckDefaultOrderSettingUserConflict_Result, bool>)((WSspCheckDefaultOrderSettingUserConflict_Result s) => s.UserId == CS_0024_003C_003E8__locals0.vm.ReferUserId && s.Priority.GetValueOrDefault() == 2)), (Func<WSspCheckDefaultOrderSettingUserConflict_Result, int?>)((WSspCheckDefaultOrderSettingUserConflict_Result s) => s.OrderSettingID))));
					_dbIII.WSspUpdateOrderDefaultSettingDefFields(CS_0024_003C_003E8__locals0.vm.ReferUserId.Value, string.Join(",", values3), (short)1);
				}
				else if (flag6)
				{
					wSOrderDefaultSetting.IsDefIssueOrder = false;
				}
				else
				{
					wSOrderDefaultSetting.IsDefIssueOrder = true;
				}
			}
			else
			{
				wSOrderDefaultSetting.IsDefIssueOrder = false;
			}
			if (CS_0024_003C_003E8__locals0.vm.ActiveInQuickOrder.HasValue && CS_0024_003C_003E8__locals0.vm.IsDefIssueQuickOrder.HasValue && CS_0024_003C_003E8__locals0.vm.ActiveInQuickOrder.GetValueOrDefault() && CS_0024_003C_003E8__locals0.vm.IsDefIssueQuickOrder.GetValueOrDefault())
			{
				bool flag7 = Enumerable.Any<WSspCheckDefaultOrderSettingUserConflict_Result>((IEnumerable<WSspCheckDefaultOrderSettingUserConflict_Result>)list16, (Func<WSspCheckDefaultOrderSettingUserConflict_Result, bool>)((WSspCheckDefaultOrderSettingUserConflict_Result s) => s.UserId == CS_0024_003C_003E8__locals0.vm.ReferUserId && s.Priority.GetValueOrDefault() == 1));
				bool flag8 = Enumerable.Any<WSspCheckDefaultOrderSettingUserConflict_Result>((IEnumerable<WSspCheckDefaultOrderSettingUserConflict_Result>)list16, (Func<WSspCheckDefaultOrderSettingUserConflict_Result, bool>)((WSspCheckDefaultOrderSettingUserConflict_Result s) => s.UserId == CS_0024_003C_003E8__locals0.vm.ReferUserId && s.Priority.GetValueOrDefault() == 2));
				if (flag7)
				{
					wSOrderDefaultSetting.IsDefIssueQuickOrder = false;
				}
				else if (flag8 && CS_0024_003C_003E8__locals0.vm.SaveDefSettings.GetValueOrDefault() == 1)
				{
					wSOrderDefaultSetting.IsDefIssueQuickOrder = true;
					List<int?> values4 = Enumerable.ToList<int?>(Enumerable.Distinct<int?>(Enumerable.Select<WSspCheckDefaultOrderSettingUserConflict_Result, int?>(Enumerable.Where<WSspCheckDefaultOrderSettingUserConflict_Result>((IEnumerable<WSspCheckDefaultOrderSettingUserConflict_Result>)list16, (Func<WSspCheckDefaultOrderSettingUserConflict_Result, bool>)((WSspCheckDefaultOrderSettingUserConflict_Result s) => s.UserId == CS_0024_003C_003E8__locals0.vm.ReferUserId && s.Priority.GetValueOrDefault() == 2)), (Func<WSspCheckDefaultOrderSettingUserConflict_Result, int?>)((WSspCheckDefaultOrderSettingUserConflict_Result s) => s.OrderSettingID))));
					_dbIII.WSspUpdateOrderDefaultSettingDefFields(CS_0024_003C_003E8__locals0.vm.ReferUserId.Value, string.Join(",", values4), (short)2);
				}
				else if (flag8)
				{
					wSOrderDefaultSetting.IsDefIssueQuickOrder = false;
				}
				else
				{
					wSOrderDefaultSetting.IsDefIssueQuickOrder = true;
				}
			}
			else
			{
				wSOrderDefaultSetting.IsDefIssueQuickOrder = false;
			}
			wSOrderDefaultSetting.Title = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
			wSOrderDefaultSetting.Subject = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
			wSOrderDefaultSetting.SpecialWord = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
			wSOrderDefaultSetting.DescriptionI = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
			wSOrderDefaultSetting.DescriptionII = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
			wSOrderDefaultSetting.SigningI = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
			wSOrderDefaultSetting.SigningII = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
			wSOrderDefaultSetting.SigningIII = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
			wSOrderDefaultSetting.Note = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
			wSOrderDefaultSetting.SettingTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
			wSOrderDefaultSetting.AutoInsertOrdPay = CS_0024_003C_003E8__locals0.vm.AutoInsertOrdPay;
			wSOrderDefaultSetting.AddPrdValidity = CS_0024_003C_003E8__locals0.vm.AddPrdValidity;
			wSOrderDefaultSetting.AddPrdValidityPrjTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
			try
			{
				if (appType == "insert")
				{
					wSOrderDefaultSetting.FPId = Financial.Get().Id;
					wSOrderDefaultSetting.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
					wSOrderDefaultSetting.FirstRegisterDate = DateTime.Now;
					wSOrderDefaultSetting.FirstRegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
					wSOrderDefaultSetting.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
					wSOrderDefaultSetting.GUId = Guid.NewGuid();
					_dbTbl.WSOrderDefaultSetting.Add(wSOrderDefaultSetting);
					_dbTbl.SaveChanges();
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
					{
						WSOrderDefaultSetting_Lang wSOrderDefaultSetting_Lang = new WSOrderDefaultSetting_Lang();
						wSOrderDefaultSetting_Lang.LanguageID = lang.LanguageID;
						wSOrderDefaultSetting_Lang.OrderSettingID = wSOrderDefaultSetting.OrderSettingID;
						wSOrderDefaultSetting_Lang.Title = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSOrderDefaultSetting_Lang.Subject = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSOrderDefaultSetting_Lang.SpecialWord = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSOrderDefaultSetting_Lang.DescriptionI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSOrderDefaultSetting_Lang.DescriptionII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSOrderDefaultSetting_Lang.SigningI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSOrderDefaultSetting_Lang.SigningII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSOrderDefaultSetting_Lang.SigningIII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSOrderDefaultSetting_Lang.Note = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSOrderDefaultSetting_Lang.SettingTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSOrderDefaultSetting_Lang.AddPrdValidityPrjTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						_dbTbl.WSOrderDefaultSetting_Lang.Add(wSOrderDefaultSetting_Lang);
						_dbTbl.SaveChanges();
					}
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSOrderDefaultSetting", CS_0024_003C_003E8__locals0.vm.ReferUserId);
					CS_0024_003C_003E8__locals0.vm.OrderSettingID = wSOrderDefaultSetting.OrderSettingID;
					base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
				}
				else if (appType == "edit")
				{
					_dbTbl.Entry(wSOrderDefaultSetting).State = EntityState.Modified;
					_dbTbl.SaveChanges();
					using (List<Languages>.Enumerator enumerator3 = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator3.MoveNext())
						{
							_003C_003Ec__DisplayClass6_3 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass6_3();
							CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
							CS_0024_003C_003E8__locals3.lang = enumerator3.Current;
							DbSet<WSOrderDefaultSetting_Lang> wSOrderDefaultSetting_Lang2 = _dbTbl.WSOrderDefaultSetting_Lang;
							ParameterExpression val = Expression.Parameter(typeof(WSOrderDefaultSetting_Lang), "c");
							WSOrderDefaultSetting_Lang wSOrderDefaultSetting_Lang3 = Queryable.FirstOrDefault<WSOrderDefaultSetting_Lang>((IQueryable<WSOrderDefaultSetting_Lang>)wSOrderDefaultSetting_Lang2, Expression.Lambda<Func<WSOrderDefaultSetting_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals3, typeof(_003C_003Ec__DisplayClass6_3)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals3, typeof(_003C_003Ec__DisplayClass6_3)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (wSOrderDefaultSetting_Lang3 != null)
							{
								wSOrderDefaultSetting_Lang3.Title = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)).Value : null);
								wSOrderDefaultSetting_Lang3.Subject = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)).Value : null);
								wSOrderDefaultSetting_Lang3.SpecialWord = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)).Value : null);
								wSOrderDefaultSetting_Lang3.DescriptionI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)).Value : null);
								wSOrderDefaultSetting_Lang3.DescriptionII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)).Value : null);
								wSOrderDefaultSetting_Lang3.SigningI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)).Value : null);
								wSOrderDefaultSetting_Lang3.SigningII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)).Value : null);
								wSOrderDefaultSetting_Lang3.SigningIII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)).Value : null);
								wSOrderDefaultSetting_Lang3.Note = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)).Value : null);
								wSOrderDefaultSetting_Lang3.SettingTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)).Value : null);
								wSOrderDefaultSetting_Lang3.AddPrdValidityPrjTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)).Value : null);
								_dbTbl.Entry(wSOrderDefaultSetting_Lang3).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							wSOrderDefaultSetting_Lang3 = new WSOrderDefaultSetting_Lang();
							wSOrderDefaultSetting_Lang3.LanguageID = CS_0024_003C_003E8__locals3.lang.LanguageID;
							wSOrderDefaultSetting_Lang3.OrderSettingID = wSOrderDefaultSetting.OrderSettingID;
							wSOrderDefaultSetting_Lang3.Title = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)).Value : null);
							wSOrderDefaultSetting_Lang3.Subject = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)).Value : null);
							wSOrderDefaultSetting_Lang3.SpecialWord = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)).Value : null);
							wSOrderDefaultSetting_Lang3.DescriptionI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)).Value : null);
							wSOrderDefaultSetting_Lang3.DescriptionII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)).Value : null);
							wSOrderDefaultSetting_Lang3.SigningI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)).Value : null);
							wSOrderDefaultSetting_Lang3.SigningII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)).Value : null);
							wSOrderDefaultSetting_Lang3.SigningIII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)).Value : null);
							wSOrderDefaultSetting_Lang3.Note = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)).Value : null);
							wSOrderDefaultSetting_Lang3.SettingTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)).Value : null);
							wSOrderDefaultSetting_Lang3.AddPrdValidityPrjTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)).Value : null);
							_dbTbl.WSOrderDefaultSetting_Lang.Add(wSOrderDefaultSetting_Lang3);
							_dbTbl.SaveChanges();
						}
					}
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSOrderDefaultSetting", CS_0024_003C_003E8__locals0.vm.ReferUserId);
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
			}
			catch (DbEntityValidationException e3)
			{
				ErrorSignal.FromCurrentContext().Raise((Exception)(object)e3);
				base.ViewBag.Error = Messages.frmErrorMessage;
			}
			catch (Exception e4)
			{
				ErrorSignal.FromCurrentContext().Raise(e4);
				base.ViewBag.Error = Messages.frmErrorMessage;
			}
		}
		CS_0024_003C_003E8__locals0.vm.AppType = appType;
		CS_0024_003C_003E8__locals0.vm.AccessUserJson = accessUserJson;
		return View(CS_0024_003C_003E8__locals0.vm);
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
			data = Enumerable.ToList<CommonDroupDownItemViewModel>(Enumerable.Select<WSspSelectOrderDefaultSettingByReferUserId_Result, CommonDroupDownItemViewModel>((IEnumerable<WSspSelectOrderDefaultSettingByReferUserId_Result>)Enumerable.ToList<WSspSelectOrderDefaultSettingByReferUserId_Result>((IEnumerable<WSspSelectOrderDefaultSettingByReferUserId_Result>)_db.WSspSelectOrderDefaultSettingByReferUserId(id, lCID, result)), (Func<WSspSelectOrderDefaultSettingByReferUserId_Result, CommonDroupDownItemViewModel>)((WSspSelectOrderDefaultSettingByReferUserId_Result item) => new CommonDroupDownItemViewModel
			{
				Text = item.SettingTitle,
				Value = item.OrderSettingID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	private void FillDropdownOrdDefSetting()
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
		try
		{
			List<WSspSelectOrderDefaultSettingUsers_Result> list = Enumerable.ToList<WSspSelectOrderDefaultSettingUsers_Result>((IEnumerable<WSspSelectOrderDefaultSettingUsers_Result>)_db.WSspSelectOrderDefaultSettingUsers(UserLogin.CurrentUser.UserId, lCID, result, result2));
			List<SelectListItem> list2 = new List<SelectListItem>();
			list2.AddRange(Enumerable.Select<WSspSelectOrderDefaultSettingUsers_Result, SelectListItem>((IEnumerable<WSspSelectOrderDefaultSettingUsers_Result>)list, (Func<WSspSelectOrderDefaultSettingUsers_Result, SelectListItem>)((WSspSelectOrderDefaultSettingUsers_Result item) => new SelectListItem
			{
				Text = item.UserName,
				Value = item.UserId.ToString(),
				Selected = false
			})));
			base.ViewBag.ReferUserList = list2;
			List<WSspSelectGuaranty_Result> list3 = Enumerable.ToList<WSspSelectGuaranty_Result>((IEnumerable<WSspSelectGuaranty_Result>)_db.WSspSelectGuaranty(lCID, result));
			List<SelectListItem> list4 = new List<SelectListItem>();
			list4.AddRange(Enumerable.Select<WSspSelectGuaranty_Result, SelectListItem>((IEnumerable<WSspSelectGuaranty_Result>)list3, (Func<WSspSelectGuaranty_Result, SelectListItem>)((WSspSelectGuaranty_Result item) => new SelectListItem
			{
				Text = item.Guaranty,
				Value = item.GuarantyID.ToString(),
				Selected = false
			})));
			base.ViewBag.PordGuarantyList = list4;
			List<spSelectPrintFormat_Result> list5 = CRMIdeal.Classes.Helper.PrintFormat.GetspPrintFortants(result2, 2);
			List<SelectListItem> list6 = new List<SelectListItem>();
			list6.AddRange(Enumerable.Select<spSelectPrintFormat_Result, SelectListItem>((IEnumerable<spSelectPrintFormat_Result>)list5, (Func<spSelectPrintFormat_Result, SelectListItem>)((spSelectPrintFormat_Result item) => new SelectListItem
			{
				Text = item.Title,
				Value = item.PrintFormatID.ToString(),
				Selected = false
			})));
			base.ViewBag.PordPrintFormatList = list6;
			List<WSspSelectOrderOpr_Result> list7 = Order.SelectOrderOpr();
			List<SelectListItem> list8 = new List<SelectListItem>();
			if (list7 != null)
			{
				list8.AddRange(Enumerable.Select<WSspSelectOrderOpr_Result, SelectListItem>((IEnumerable<WSspSelectOrderOpr_Result>)list7, (Func<WSspSelectOrderOpr_Result, SelectListItem>)((WSspSelectOrderOpr_Result item) => new SelectListItem
				{
					Text = item.Name,
					Value = item.OrderOprID.ToString(),
					Selected = false
				})));
			}
			if (Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)list8))
			{
				list8[0].Selected = true;
			}
			base.ViewBag.OrderOprList = list8;
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
	public JsonResult GetVerifierTitles()
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
			List<CRMspSelectOrderVerifiers_Result> list2 = Enumerable.ToList<CRMspSelectOrderVerifiers_Result>((IEnumerable<CRMspSelectOrderVerifiers_Result>)_db.CRMspSelectOrderVerifiers(UserLogin.CurrentUser.UserId, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectOrderVerifiers_Result, SelectListItem>((IEnumerable<CRMspSelectOrderVerifiers_Result>)list2, (Func<CRMspSelectOrderVerifiers_Result, SelectListItem>)((CRMspSelectOrderVerifiers_Result item) => new SelectListItem
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
		base.ViewBag.VerifierRequestList = list;
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
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
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
			List<WSspSelectVerificationWorkFlowWithObjectType_Result> list2 = Enumerable.ToList<WSspSelectVerificationWorkFlowWithObjectType_Result>((IEnumerable<WSspSelectVerificationWorkFlowWithObjectType_Result>)_db.WSspSelectVerificationWorkFlowWithObjectType(20, lCID, result));
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
	public JsonResult GetOrdSetPementType()
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
			List<WSspSettlementType_Result> list2 = Enumerable.ToList<WSspSettlementType_Result>((IEnumerable<WSspSettlementType_Result>)_db.WSspSettlementType(lCID, result));
			list.AddRange(Enumerable.Select<WSspSettlementType_Result, SelectListItem>((IEnumerable<WSspSettlementType_Result>)list2, (Func<WSspSettlementType_Result, SelectListItem>)((WSspSettlementType_Result item) => new SelectListItem
			{
				Text = item.Name,
				Value = item.Id.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.OrdSettlementTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetOrdGuaranty()
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
			List<WSspSelectGuaranty_Result> list2 = Enumerable.ToList<WSspSelectGuaranty_Result>((IEnumerable<WSspSelectGuaranty_Result>)_db.WSspSelectGuaranty(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectGuaranty_Result, SelectListItem>((IEnumerable<WSspSelectGuaranty_Result>)list2, (Func<WSspSelectGuaranty_Result, SelectListItem>)((WSspSelectGuaranty_Result item) => new SelectListItem
			{
				Text = item.Guaranty,
				Value = item.GuarantyID.ToString(),
				Selected = false
			})));
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		base.ViewBag.PordGuarantyList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetDefaultSettingById(int id)
	{
		_003C_003Ec__DisplayClass24_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass24_0();
		CS_0024_003C_003E8__locals0.id = id;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		CS_0024_003C_003E8__locals0.result = new WSOrderDefaultSettingLanguageViewModel();
		try
		{
			DbSet<WSOrderDefaultSetting> wSOrderDefaultSetting = _dbTbl.WSOrderDefaultSetting;
			ParameterExpression val = Expression.Parameter(typeof(WSOrderDefaultSetting), "c");
			WSOrderDefaultSetting wSOrderDefaultSetting2 = Queryable.FirstOrDefault<WSOrderDefaultSetting>((IQueryable<WSOrderDefaultSetting>)wSOrderDefaultSetting, Expression.Lambda<Func<WSOrderDefaultSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass24_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			DbSet<WSOrderDefaultSetting_Lang> wSOrderDefaultSetting_Lang = _dbTbl.WSOrderDefaultSetting_Lang;
			val = Expression.Parameter(typeof(WSOrderDefaultSetting_Lang), "c");
			List<WSOrderDefaultSetting_Lang> list = Enumerable.ToList<WSOrderDefaultSetting_Lang>((IEnumerable<WSOrderDefaultSetting_Lang>)Queryable.Where<WSOrderDefaultSetting_Lang>((IQueryable<WSOrderDefaultSetting_Lang>)wSOrderDefaultSetting_Lang, Expression.Lambda<Func<WSOrderDefaultSetting_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass24_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrderDefaultSetting_Lang>)list, (Func<WSOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSOrderDefaultSetting_Lang itemVm) => new CommonMultiLanguageViewModel
			{
				Value = itemVm.Title,
				LanguageId = itemVm.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = wSOrderDefaultSetting2.Title,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrderDefaultSetting_Lang>)list, (Func<WSOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSOrderDefaultSetting_Lang itemVm) => new CommonMultiLanguageViewModel
			{
				Value = itemVm.Subject,
				LanguageId = itemVm.LanguageID
			})));
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = wSOrderDefaultSetting2.Subject,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrderDefaultSetting_Lang>)list, (Func<WSOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSOrderDefaultSetting_Lang itemVm) => new CommonMultiLanguageViewModel
			{
				Value = itemVm.SpecialWord,
				LanguageId = itemVm.LanguageID
			})));
			list4.Add(new CommonMultiLanguageViewModel
			{
				Value = wSOrderDefaultSetting2.SpecialWord,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list5 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrderDefaultSetting_Lang>)list, (Func<WSOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSOrderDefaultSetting_Lang itemVm) => new CommonMultiLanguageViewModel
			{
				Value = itemVm.DescriptionI,
				LanguageId = itemVm.LanguageID
			})));
			list5.Add(new CommonMultiLanguageViewModel
			{
				Value = wSOrderDefaultSetting2.DescriptionI,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list6 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrderDefaultSetting_Lang>)list, (Func<WSOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSOrderDefaultSetting_Lang itemVm) => new CommonMultiLanguageViewModel
			{
				Value = itemVm.DescriptionII,
				LanguageId = itemVm.LanguageID
			})));
			list6.Add(new CommonMultiLanguageViewModel
			{
				Value = wSOrderDefaultSetting2.DescriptionII,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list7 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrderDefaultSetting_Lang>)list, (Func<WSOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSOrderDefaultSetting_Lang itemVm) => new CommonMultiLanguageViewModel
			{
				Value = itemVm.SigningI,
				LanguageId = itemVm.LanguageID
			})));
			list7.Add(new CommonMultiLanguageViewModel
			{
				Value = wSOrderDefaultSetting2.SigningI,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list8 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrderDefaultSetting_Lang>)list, (Func<WSOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSOrderDefaultSetting_Lang itemVm) => new CommonMultiLanguageViewModel
			{
				Value = itemVm.SigningII,
				LanguageId = itemVm.LanguageID
			})));
			list8.Add(new CommonMultiLanguageViewModel
			{
				Value = wSOrderDefaultSetting2.SigningII,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list9 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrderDefaultSetting_Lang>)list, (Func<WSOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSOrderDefaultSetting_Lang itemVm) => new CommonMultiLanguageViewModel
			{
				Value = itemVm.SigningIII,
				LanguageId = itemVm.LanguageID
			})));
			list9.Add(new CommonMultiLanguageViewModel
			{
				Value = wSOrderDefaultSetting2.SigningIII,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list10 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrderDefaultSetting_Lang>)list, (Func<WSOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSOrderDefaultSetting_Lang itemVm) => new CommonMultiLanguageViewModel
			{
				Value = itemVm.Note,
				LanguageId = itemVm.LanguageID
			})));
			list10.Add(new CommonMultiLanguageViewModel
			{
				Value = wSOrderDefaultSetting2.Note,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list11 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrderDefaultSetting_Lang>)list, (Func<WSOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSOrderDefaultSetting_Lang itemVm) => new CommonMultiLanguageViewModel
			{
				Value = itemVm.SettingTitle,
				LanguageId = itemVm.LanguageID
			})));
			list11.Add(new CommonMultiLanguageViewModel
			{
				Value = wSOrderDefaultSetting2.SettingTitle,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list12 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrderDefaultSetting_Lang>)list, (Func<WSOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSOrderDefaultSetting_Lang itemVm) => new CommonMultiLanguageViewModel
			{
				Value = itemVm.AddPrdValidityPrjTitle,
				LanguageId = itemVm.LanguageID
			})));
			list12.Add(new CommonMultiLanguageViewModel
			{
				Value = wSOrderDefaultSetting2.AddPrdValidityPrjTitle,
				LanguageId = result
			});
			if (wSOrderDefaultSetting2 != null)
			{
				CS_0024_003C_003E8__locals0.result = new WSOrderDefaultSettingLanguageViewModel
				{
					UserId = wSOrderDefaultSetting2.UserId,
					AppType = wSOrderDefaultSetting2.AppType,
					OrderSettingID = wSOrderDefaultSetting2.OrderSettingID,
					AccountNumberI = wSOrderDefaultSetting2.AccountNumberI,
					FPId = wSOrderDefaultSetting2.FPId,
					SignatureId = wSOrderDefaultSetting2.SignatureId,
					RightLogoId = wSOrderDefaultSetting2.RightLogoId,
					AccountNumberII = wSOrderDefaultSetting2.AccountNumberII,
					RegisterDatePersian = wSOrderDefaultSetting2.RegisterDate.ToString("yyyyMMdd"),
					GUId = wSOrderDefaultSetting2.GUId,
					RegisterDate = wSOrderDefaultSetting2.RegisterDate,
					Month1 = wSOrderDefaultSetting2.Month1,
					OrderOprID = wSOrderDefaultSetting2.OrderOprID,
					CalculateTax = wSOrderDefaultSetting2.CalculateTax,
					LeftLogoId = wSOrderDefaultSetting2.LeftLogoId,
					AccountShabaNumberI = wSOrderDefaultSetting2.AccountShabaNumberI,
					PrintFormatId = wSOrderDefaultSetting2.PrintFormatId,
					GuarantyId = wSOrderDefaultSetting2.GuarantyId,
					TaxIndex = wSOrderDefaultSetting2.TaxIndex,
					AccountShabaNumberII = wSOrderDefaultSetting2.AccountShabaNumberII,
					ReferUserId = wSOrderDefaultSetting2.ReferUserId,
					AutoGenerateOrdSerial = wSOrderDefaultSetting2.AutoGenerateOrdSerial,
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
					Note = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					Note_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					SettingTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					SettingTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					FirstRegisterDate = wSOrderDefaultSetting2.FirstRegisterDate,
					FirstRegisterUserId = wSOrderDefaultSetting2.FirstRegisterUserId,
					CurrencyUnitId = wSOrderDefaultSetting2.CurrencyUnitId,
					CurrencyUnitIdI = wSOrderDefaultSetting2.CurrencyUnitIdI,
					DeliveryTermId = wSOrderDefaultSetting2.DeliveryTermId,
					VerifierRequestId = wSOrderDefaultSetting2.VerifierRequestId,
					DefWHId = wSOrderDefaultSetting2.DefWHId,
					DefPrdPriceGroupId = wSOrderDefaultSetting2.DefPrdPriceGroupId,
					SellerId = wSOrderDefaultSetting2.SellerId,
					EmailUsersInfoId = wSOrderDefaultSetting2.EmailUsersInfoId,
					EmailUserDefaultSettingId = wSOrderDefaultSetting2.EmailUserDefaultSettingId,
					VerificationWorkFlowId = wSOrderDefaultSetting2.VerificationWorkFlowId,
					SaleCenterId = wSOrderDefaultSetting2.SaleCenterId,
					SaleAreaId = wSOrderDefaultSetting2.SaleAreaId,
					DefPayTypeId = wSOrderDefaultSetting2.DefPayTypeId,
					SettlementTypeId = wSOrderDefaultSetting2.SettlementTypeId,
					IsDefIssueQuickOrder = wSOrderDefaultSetting2.IsDefIssueQuickOrder,
					AutoInsertOrdPay = wSOrderDefaultSetting2.AutoInsertOrdPay,
					TaxIndexItem = wSOrderDefaultSetting2.TaxIndexItem,
					CalculateTaxItem = wSOrderDefaultSetting2.CalculateTaxItem,
					AddPrdValidity = wSOrderDefaultSetting2.AddPrdValidity,
					AddPrdValidityPrjTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					AddPrdValidityPrjTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					PublicMode = wSOrderDefaultSetting2.PublicMode.GetValueOrDefault(1),
					ActiveInOrder = wSOrderDefaultSetting2.ActiveInOrder,
					ActiveInQuickOrder = wSOrderDefaultSetting2.ActiveInQuickOrder,
					IsDefIssueOrder = wSOrderDefaultSetting2.IsDefIssueOrder,
					AccessUserJson = wSOrderDefaultSetting2.AccessUserJson
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
					List<object> list13 = new List<object>();
					foreach (CRMspSelectUsers_Result user in enumerable)
					{
						JToken jToken = Enumerable.FirstOrDefault<JToken>((IEnumerable<JToken>)jArray, (Func<JToken, bool>)((JToken j) => (j.Value<int?>("UserId") ?? j.Value<int?>("id")) == user.UserId));
						bool? flag = jToken?.Value<bool?>("IsDefIssueOrder");
						bool? flag2 = jToken?.Value<bool?>("IsDefIssueQuickOrder");
						list13.Add(new
						{
							text = user.LName + " " + user.FName,
							id = user.UserId,
							IsDefIssueOrder = flag.GetValueOrDefault(),
							IsDefIssueQuickOrder = flag2.GetValueOrDefault()
						});
					}
					string accessUserJson = JsonConvert.SerializeObject(list13, new JsonSerializerSettings
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
						List<CRMspSelectUsersByIds_Result> list14 = CRMIdeal.Classes.Helper.User.SelectUsersByIds(text3 + "," + CS_0024_003C_003E8__locals0.result.UserId);
						if (Enumerable.Any<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list14))
						{
							CS_0024_003C_003E8__locals0.result.FirstRegisterUserId = CS_0024_003C_003E8__locals0.result.FirstRegisterUserId ?? UserLogin.CurrentUser.UserId;
							CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list14, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == CS_0024_003C_003E8__locals0.result.FirstRegisterUserId));
							text = ((cRMspSelectUsersByIds_Result != null) ? (cRMspSelectUsersByIds_Result.LName + ((cRMspSelectUsersByIds_Result.FName != null) ? (" " + cRMspSelectUsersByIds_Result.FName) : "")) : "");
							WSOrderDefaultSettingLanguageViewModel result3 = CS_0024_003C_003E8__locals0.result;
							_ = CS_0024_003C_003E8__locals0.result.UserId;
							result3.UserId = CS_0024_003C_003E8__locals0.result.UserId;
							CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result2 = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list14, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == CS_0024_003C_003E8__locals0.result.UserId));
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

	[AjaxOnly]
	public JsonResult GetOrdPrintFormat()
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
			List<spSelectPrintFormat_Result> list2 = CRMIdeal.Classes.Helper.PrintFormat.GetspPrintFortants(result2, 2);
			list.AddRange(Enumerable.Select<spSelectPrintFormat_Result, SelectListItem>((IEnumerable<spSelectPrintFormat_Result>)list2, (Func<spSelectPrintFormat_Result, SelectListItem>)((spSelectPrintFormat_Result item) => new SelectListItem
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
		base.ViewBag.PordPrintFormatList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult DeleteDefaultSetting(int id)
	{
		_003C_003Ec__DisplayClass26_0 _003C_003Ec__DisplayClass26_ = new _003C_003Ec__DisplayClass26_0();
		_003C_003Ec__DisplayClass26_.id = id;
		string data = "";
		try
		{
			DbSet<WSOrderDefaultSetting> wSOrderDefaultSetting = _dbTbl.WSOrderDefaultSetting;
			ParameterExpression val = Expression.Parameter(typeof(WSOrderDefaultSetting), "c");
			WSOrderDefaultSetting wSOrderDefaultSetting2 = Queryable.FirstOrDefault<WSOrderDefaultSetting>((IQueryable<WSOrderDefaultSetting>)wSOrderDefaultSetting, Expression.Lambda<Func<WSOrderDefaultSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass26_, typeof(_003C_003Ec__DisplayClass26_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (wSOrderDefaultSetting2 != null)
			{
				Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)Enumerable.ToList<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteWSOrderDefaultSetting(_003C_003Ec__DisplayClass26_.id)));
				DbSet<WSOrderDefaultSetting> wSOrderDefaultSetting3 = _dbTbl.WSOrderDefaultSetting;
				val = Expression.Parameter(typeof(WSOrderDefaultSetting), "c");
				if (Queryable.FirstOrDefault<WSOrderDefaultSetting>((IQueryable<WSOrderDefaultSetting>)wSOrderDefaultSetting3, Expression.Lambda<Func<WSOrderDefaultSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass26_, typeof(_003C_003Ec__DisplayClass26_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) == null)
				{
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSOrderDefaultSetting", wSOrderDefaultSetting2.ReferUserId);
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

	[AjaxOnly]
	public string CheckIsDefIssueQuickOrder(int ordDefSetId, int referUserId)
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
			WSspSelectOrderDefaultSettingIsDefIssueQuickOrder_Result wSspSelectOrderDefaultSettingIsDefIssueQuickOrder_Result = Enumerable.FirstOrDefault<WSspSelectOrderDefaultSettingIsDefIssueQuickOrder_Result>((IEnumerable<WSspSelectOrderDefaultSettingIsDefIssueQuickOrder_Result>)_dbI.WSspSelectOrderDefaultSettingIsDefIssueQuickOrder(referUserId, lCID, result2));
			if (wSspSelectOrderDefaultSettingIsDefIssueQuickOrder_Result != null && wSspSelectOrderDefaultSettingIsDefIssueQuickOrder_Result.OrderSettingID != ordDefSetId)
			{
				result = ((!string.IsNullOrWhiteSpace(wSspSelectOrderDefaultSettingIsDefIssueQuickOrder_Result.SettingTitle)) ? (wSspSelectOrderDefaultSettingIsDefIssueQuickOrder_Result.SettingTitle ?? "") : "-1");
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[AjaxOnly]
	public JsonResult CheckDefaultOrderSettingUserConflict(int publicMode = 1, string accessUserJson = "", bool activeInOrder = false, bool activeInQuickOrder = false, bool defaultInOrder = false, bool defaultInQuickOrder = false, int orderSettingId = 0, int referUserId = 0)
	{
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			bool hasPublicDefaultOrder = false;
			bool hasPublicDefaultQuickOrder = false;
			bool flag = false;
			bool flag2 = false;
			string text = "";
			if (publicMode == 2)
			{
				if (activeInOrder && defaultInOrder)
				{
					foreach (WSspCheckPublicDefaultOrderSettingConflict_Result item in Enumerable.ToList<WSspCheckPublicDefaultOrderSettingConflict_Result>((IEnumerable<WSspCheckPublicDefaultOrderSettingConflict_Result>)_dbIII.WSspCheckPublicDefaultOrderSettingConflict(orderSettingId, (short)1, lCID, result)))
					{
						hasPublicDefaultOrder = true;
						text = text + string.Format(Messages.msgPublicDefaultOrderConflict, item.OrderDefaultSetting) + "<br />";
					}
				}
				if (activeInQuickOrder && defaultInQuickOrder)
				{
					foreach (WSspCheckPublicDefaultOrderSettingConflict_Result item2 in Enumerable.ToList<WSspCheckPublicDefaultOrderSettingConflict_Result>((IEnumerable<WSspCheckPublicDefaultOrderSettingConflict_Result>)_dbIII.WSspCheckPublicDefaultOrderSettingConflict(orderSettingId, (short)2, lCID, result)))
					{
						hasPublicDefaultQuickOrder = true;
						text = text + string.Format(Messages.msgPublicDefaultQuickOrderConflict, item2.OrderDefaultSetting) + "<br />";
					}
				}
			}
			if (publicMode == 3 && !string.IsNullOrEmpty(accessUserJson))
			{
				try
				{
					foreach (JToken item3 in JArray.Parse(accessUserJson))
					{
						int result2 = 0;
						int.TryParse(item3["UserId"]?.ToString() ?? item3["id"]?.ToString(), out result2);
						if (result2 <= 0 || result2 == referUserId)
						{
							continue;
						}
						if (activeInOrder)
						{
							bool result3 = false;
							bool.TryParse(item3["IsDefIssueOrder"]?.ToString(), out result3);
							if (result3)
							{
								list.Add(result2);
							}
						}
						if (activeInQuickOrder)
						{
							bool result4 = false;
							bool.TryParse(item3["IsDefIssueQuickOrder"]?.ToString(), out result4);
							if (result4)
							{
								list2.Add(result2);
							}
						}
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
			}
			if (activeInOrder && defaultInOrder && referUserId > 0)
			{
				list.Add(referUserId);
			}
			if (activeInQuickOrder && defaultInQuickOrder && referUserId > 0)
			{
				list2.Add(referUserId);
			}
			List<WSspCheckDefaultOrderSettingUserConflict_Result> list3 = new List<WSspCheckDefaultOrderSettingUserConflict_Result>();
			List<WSspCheckDefaultOrderSettingUserConflict_Result> list4 = new List<WSspCheckDefaultOrderSettingUserConflict_Result>();
			if (activeInOrder && Enumerable.Any<int>((IEnumerable<int>)list))
			{
				list3 = Enumerable.ToList<WSspCheckDefaultOrderSettingUserConflict_Result>((IEnumerable<WSspCheckDefaultOrderSettingUserConflict_Result>)_dbIII.WSspCheckDefaultOrderSettingUserConflict(string.Join(",", Enumerable.Distinct<int>((IEnumerable<int>)list)), orderSettingId, (short)1, lCID, result)) ?? new List<WSspCheckDefaultOrderSettingUserConflict_Result>();
			}
			if (activeInQuickOrder && Enumerable.Any<int>((IEnumerable<int>)list2))
			{
				list4 = Enumerable.ToList<WSspCheckDefaultOrderSettingUserConflict_Result>((IEnumerable<WSspCheckDefaultOrderSettingUserConflict_Result>)_dbIII.WSspCheckDefaultOrderSettingUserConflict(string.Join(",", Enumerable.Distinct<int>((IEnumerable<int>)list2)), orderSettingId, (short)2, lCID, result)) ?? new List<WSspCheckDefaultOrderSettingUserConflict_Result>();
			}
			flag2 = Enumerable.Any<WSspCheckDefaultOrderSettingUserConflict_Result>((IEnumerable<WSspCheckDefaultOrderSettingUserConflict_Result>)list3, (Func<WSspCheckDefaultOrderSettingUserConflict_Result, bool>)((WSspCheckDefaultOrderSettingUserConflict_Result s) => s.Priority.GetValueOrDefault() == 1));
			flag = Enumerable.Any<WSspCheckDefaultOrderSettingUserConflict_Result>((IEnumerable<WSspCheckDefaultOrderSettingUserConflict_Result>)list4, (Func<WSspCheckDefaultOrderSettingUserConflict_Result, bool>)((WSspCheckDefaultOrderSettingUserConflict_Result s) => s.Priority.GetValueOrDefault() == 1));
			bool flag3 = flag2 || flag;
			if (Enumerable.Any<WSspCheckDefaultOrderSettingUserConflict_Result>((IEnumerable<WSspCheckDefaultOrderSettingUserConflict_Result>)list3))
			{
				foreach (WSspCheckDefaultOrderSettingUserConflict_Result item4 in flag3 ? Enumerable.Where<WSspCheckDefaultOrderSettingUserConflict_Result>((IEnumerable<WSspCheckDefaultOrderSettingUserConflict_Result>)list3, (Func<WSspCheckDefaultOrderSettingUserConflict_Result, bool>)((WSspCheckDefaultOrderSettingUserConflict_Result s) => s.Priority.GetValueOrDefault() == 1)) : Enumerable.Where<WSspCheckDefaultOrderSettingUserConflict_Result>((IEnumerable<WSspCheckDefaultOrderSettingUserConflict_Result>)list3, (Func<WSspCheckDefaultOrderSettingUserConflict_Result, bool>)((WSspCheckDefaultOrderSettingUserConflict_Result s) => s.Priority.GetValueOrDefault() == 2)))
				{
					text += (flag3 ? (string.Format(Messages.msgUserOwnDefaultOrderCannotOverride, item4.User, item4.OrderDefaultSetting) + "<br />") : (string.Format(Messages.msgUserDefaultOrderOverride, item4.User, item4.OrderDefaultSetting) + "<br />"));
				}
			}
			if (Enumerable.Any<WSspCheckDefaultOrderSettingUserConflict_Result>((IEnumerable<WSspCheckDefaultOrderSettingUserConflict_Result>)list4))
			{
				foreach (WSspCheckDefaultOrderSettingUserConflict_Result item5 in flag3 ? Enumerable.Where<WSspCheckDefaultOrderSettingUserConflict_Result>((IEnumerable<WSspCheckDefaultOrderSettingUserConflict_Result>)list4, (Func<WSspCheckDefaultOrderSettingUserConflict_Result, bool>)((WSspCheckDefaultOrderSettingUserConflict_Result s) => s.Priority.GetValueOrDefault() == 1)) : Enumerable.Where<WSspCheckDefaultOrderSettingUserConflict_Result>((IEnumerable<WSspCheckDefaultOrderSettingUserConflict_Result>)list4, (Func<WSspCheckDefaultOrderSettingUserConflict_Result, bool>)((WSspCheckDefaultOrderSettingUserConflict_Result s) => s.Priority.GetValueOrDefault() == 2)))
				{
					text += (flag3 ? (string.Format(Messages.msgUserOwnDefaultQuickOrderCannotOverride, item5.User, item5.OrderDefaultSetting) + "<br />") : (string.Format(Messages.msgUserDefaultQuickOrderOverride, item5.User, item5.OrderDefaultSetting) + "<br />"));
				}
			}
			return Json(new
			{
				message = text,
				hasOwnDefaultOrder = flag2,
				hasOwnDefaultQuickOrder = flag,
				hasPublicDefaultOrder = hasPublicDefaultOrder,
				hasPublicDefaultQuickOrder = hasPublicDefaultQuickOrder,
				isSuccess = string.IsNullOrEmpty(text)
			}, JsonRequestBehavior.AllowGet);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return Json(new
		{
			message = "",
			hasOwnDefaultOrder = false,
			hasOwnDefaultQuickOrder = false,
			hasPublicDefaultOrder = false,
			hasPublicDefaultQuickOrder = false,
			isSuccess = false
		}, JsonRequestBehavior.AllowGet);
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

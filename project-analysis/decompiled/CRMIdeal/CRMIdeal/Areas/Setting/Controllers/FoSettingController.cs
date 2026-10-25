using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.IO;
using CRM.General.IO.FTP;
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

namespace CRMIdeal.Areas.Setting.Controllers;

public class FoSettingController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass125_0
	{
		public CrmFoShpLogoSettingLanguageViewModel model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass127_0
	{
		public int cId;

		internal bool _003CEditCmpUPSetting_003Eb__0(CrmFoSetting_Lang x)
		{
			return x.CrmFoSetting.CId == cId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass128_0
	{
		public CrmFoSettingCmpUPLanguageViewModel model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass130_0
	{
		public int cId;

		internal bool _003CEditShopPrdStockCtrlSetting_003Eb__0(CrmFoSetting_Lang x)
		{
			return x.CrmFoSetting.CId == cId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass131_0
	{
		public CrmFoSettingShopPrdStockCtrlLanguageViewModel model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass132_0
	{
		public int? cId;

		public int currLangID;

		internal bool _003CEditShopCartSetting_003Eb__0(CrmFoSetting_Lang x)
		{
			return x.CrmFoSetting.CId == cId;
		}

		internal bool _003CEditShopCartSetting_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditShopCartSetting_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditShopCartSetting_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CEditShopCartSetting_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditShopCartSetting_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditShopCartSetting_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CEditShopCartSetting_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditShopCartSetting_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditShopCartSetting_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CEditShopCartSetting_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditShopCartSetting_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditShopCartSetting_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CEditShopCartSetting_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditShopCartSetting_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditShopCartSetting_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CEditShopCartSetting_003Eb__24(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditShopCartSetting_003Eb__25(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditShopCartSetting_003Eb__26(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CEditShopCartSetting_003Eb__27(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditShopCartSetting_003Eb__28(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditShopCartSetting_003Eb__29(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass133_0
	{
		public CrmFoSettingShopCartLanguageViewModel model;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__18;

		internal bool _003CEditShopCartSetting_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditShopCartSetting_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditShopCartSetting_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditShopCartSetting_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditShopCartSetting_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditShopCartSetting_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditShopCartSetting_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditShopCartSetting_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditShopCartSetting_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditShopCartSetting_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditShopCartSetting_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditShopCartSetting_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditShopCartSetting_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditShopCartSetting_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditShopCartSetting_003Eb__18(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass133_1
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass133_0 CS_0024_003C_003E8__locals1;

		internal bool _003CEditShopCartSetting_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditShopCartSetting_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditShopCartSetting_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditShopCartSetting_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditShopCartSetting_003Eb__24(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditShopCartSetting_003Eb__25(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditShopCartSetting_003Eb__26(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditShopCartSetting_003Eb__27(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditShopCartSetting_003Eb__28(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditShopCartSetting_003Eb__29(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditShopCartSetting_003Eb__30(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditShopCartSetting_003Eb__31(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditShopCartSetting_003Eb__32(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditShopCartSetting_003Eb__33(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditShopCartSetting_003Eb__34(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditShopCartSetting_003Eb__35(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditShopCartSetting_003Eb__36(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditShopCartSetting_003Eb__37(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditShopCartSetting_003Eb__38(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditShopCartSetting_003Eb__39(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditShopCartSetting_003Eb__40(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditShopCartSetting_003Eb__41(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditShopCartSetting_003Eb__42(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditShopCartSetting_003Eb__43(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditShopCartSetting_003Eb__44(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditShopCartSetting_003Eb__45(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditShopCartSetting_003Eb__46(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditShopCartSetting_003Eb__47(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass134_0
	{
		public int cId;

		public int currLangID;

		internal bool _003CEditFoTabSetting_003Eb__0(CrmFoSetting_Lang x)
		{
			return x.CrmFoSetting.CId == cId;
		}

		internal bool _003CEditFoTabSetting_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__24(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__25(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__26(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__27(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__28(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__29(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__30(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__31(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__32(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__33(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__34(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__35(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__36(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__37(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__38(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__39(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__40(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__41(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__42(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__43(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__44(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__45(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__46(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__47(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__48(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__49(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__50(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__51(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__52(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__53(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__54(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__55(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__56(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__57(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__58(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__59(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__60(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__61(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__62(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__63(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__64(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__65(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__66(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__67(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__68(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__69(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__70(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__71(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__72(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__73(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass135_0
	{
		public CrmFoSettingFoTabLanguageViewModel model;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__37;

		internal bool _003CEditFoTabSetting_003Eb__1(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__24(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__25(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__26(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__27(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__28(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__29(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__30(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__31(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__32(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__33(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__34(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__35(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__36(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditFoTabSetting_003Eb__37(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass135_1
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass135_0 CS_0024_003C_003E8__locals1;

		internal bool _003CEditFoTabSetting_003Eb__39(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__40(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__41(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__42(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__43(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__44(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__45(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__46(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__47(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__48(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__49(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__50(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__51(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__52(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__53(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__54(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__55(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__56(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__57(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__58(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__59(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__60(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__61(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__62(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__63(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__64(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__65(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__66(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__67(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__68(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__69(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__70(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__71(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__72(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__73(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__74(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__75(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__76(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__77(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__78(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__79(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__80(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__81(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__82(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__83(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__84(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__85(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__86(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__87(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__88(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__89(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__90(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__91(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__92(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__93(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__94(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__95(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__96(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__97(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__98(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__99(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__100(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__101(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__102(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__103(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__104(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__105(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__106(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__107(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__108(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__109(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoTabSetting_003Eb__110(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass136_0
	{
		public int cId;

		internal bool _003CEditFoActionSetting_003Eb__0(CrmFoSetting_Lang x)
		{
			return x.CrmFoSetting.CId == cId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass137_0
	{
		public CrmFoSettingFoActionLanguageViewModel model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass138_0
	{
		public int cId;

		public int currLangID;

		internal bool _003CEditFoSalesOrderLblSetting_003Eb__0(CrmFoSetting_Lang x)
		{
			return x.CrmFoSetting.CId == cId;
		}

		internal bool _003CEditFoSalesOrderLblSetting_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFoSalesOrderLblSetting_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFoSalesOrderLblSetting_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFoSalesOrderLblSetting_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFoSalesOrderLblSetting_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CEditFoSalesOrderLblSetting_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass139_0
	{
		public CrmFoSettingSalesOrderLblLanguageViewModel model;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__5;

		internal bool _003CEditFoSalesOrderLblSetting_003Eb__1(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditFoSalesOrderLblSetting_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditFoSalesOrderLblSetting_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditFoSalesOrderLblSetting_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditFoSalesOrderLblSetting_003Eb__5(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass139_1
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass139_0 CS_0024_003C_003E8__locals1;

		internal bool _003CEditFoSalesOrderLblSetting_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoSalesOrderLblSetting_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoSalesOrderLblSetting_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoSalesOrderLblSetting_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoSalesOrderLblSetting_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoSalesOrderLblSetting_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoSalesOrderLblSetting_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoSalesOrderLblSetting_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass140_0
	{
		public int cId;

		internal bool _003CEditFoSalesPreOrderSetting_003Eb__0(CrmFoSetting_Lang x)
		{
			return x.CrmFoSetting.CId == cId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass141_0
	{
		public int foId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass142_0
	{
		public int cId;

		internal bool _003CEditFoOrdListShowTypeSetting_003Eb__0(CrmFoSetting_Lang x)
		{
			return x.CrmFoSetting.CId == cId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass143_0
	{
		public CrmFoSettingFoOrdListShowTypeLanguageViewModel model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass145_0
	{
		public int onlinePayBankInfoId;

		public int currLangID;

		internal bool _003COnlinePayBankInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003COnlinePayBankInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003COnlinePayBankInsertEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003COnlinePayBankInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003COnlinePayBankInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003COnlinePayBankInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass146_0
	{
		public int defLangID;

		public CrmOnlinePayBankInfoLanguageViewModel model;

		public Func<Languages, bool> _003C_003E9__4;

		public Func<Languages, bool> _003C_003E9__14;

		internal bool _003COnlinePayBankInsertEdit_003Eb__0(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003COnlinePayBankInsertEdit_003Eb__1(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003COnlinePayBankInsertEdit_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003COnlinePayBankInsertEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003COnlinePayBankInsertEdit_003Eb__4(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003COnlinePayBankInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003COnlinePayBankInsertEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003COnlinePayBankInsertEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003COnlinePayBankInsertEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003COnlinePayBankInsertEdit_003Eb__14(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass146_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass146_0 CS_0024_003C_003E8__locals1;

		internal bool _003COnlinePayBankInsertEdit_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003COnlinePayBankInsertEdit_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003COnlinePayBankInsertEdit_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003COnlinePayBankInsertEdit_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003COnlinePayBankInsertEdit_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003COnlinePayBankInsertEdit_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003COnlinePayBankInsertEdit_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003COnlinePayBankInsertEdit_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass148_0
	{
		public int cId;

		public int currLangID;

		internal bool _003CEditFoMobSetting_003Eb__0(CrmFoSetting_Lang x)
		{
			return x.CrmFoSetting.CId == cId;
		}

		internal bool _003CEditFoMobSetting_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFoMobSetting_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditFoMobSetting_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass149_0
	{
		public CrmFoMobSettingLanguageViewModel model;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__5;

		internal bool _003CEditFoMobSetting_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditFoMobSetting_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditFoMobSetting_003Eb__5(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass149_1
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass149_0 CS_0024_003C_003E8__locals1;

		internal bool _003CEditFoMobSetting_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoMobSetting_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoMobSetting_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditFoMobSetting_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public int foSettingId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass154_0
	{
		public int id;

		public int currLangID;

		internal bool _003CSeoInsertEdit_003Eb__0(CommonMultiLanguageViewModel x)
		{
			return x.LanguageId == currLangID;
		}

		internal bool _003CSeoInsertEdit_003Eb__1(CommonMultiLanguageViewModel x)
		{
			return x.LanguageId != currLangID;
		}

		internal bool _003CSeoInsertEdit_003Eb__2(CommonMultiLanguageViewModel x)
		{
			return x.LanguageId == currLangID;
		}

		internal bool _003CSeoInsertEdit_003Eb__3(CommonMultiLanguageViewModel x)
		{
			return x.LanguageId != currLangID;
		}

		internal bool _003CSeoInsertEdit_003Eb__4(CommonMultiLanguageViewModel x)
		{
			return x.LanguageId == currLangID;
		}

		internal bool _003CSeoInsertEdit_003Eb__5(CommonMultiLanguageViewModel x)
		{
			return x.LanguageId != currLangID;
		}

		internal bool _003CSeoInsertEdit_003Eb__6(CommonMultiLanguageViewModel x)
		{
			return x.LanguageId == currLangID;
		}

		internal bool _003CSeoInsertEdit_003Eb__7(CommonMultiLanguageViewModel x)
		{
			return x.LanguageId != currLangID;
		}

		internal bool _003CSeoInsertEdit_003Eb__8(CommonMultiLanguageViewModel x)
		{
			return x.LanguageId == currLangID;
		}

		internal bool _003CSeoInsertEdit_003Eb__9(CommonMultiLanguageViewModel x)
		{
			return x.LanguageId != currLangID;
		}

		internal bool _003CSeoInsertEdit_003Eb__10(CommonMultiLanguageViewModel x)
		{
			return x.LanguageId == currLangID;
		}

		internal bool _003CSeoInsertEdit_003Eb__11(CommonMultiLanguageViewModel x)
		{
			return x.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass155_0
	{
		public CrmFoSettingSeoLanguageViewModel model;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__13;

		public Func<Languages, bool> _003C_003E9__39;

		internal bool _003CSeoInsertEdit_003Eb__1(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CSeoInsertEdit_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CSeoInsertEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CSeoInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CSeoInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CSeoInsertEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CSeoInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CSeoInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CSeoInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CSeoInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CSeoInsertEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CSeoInsertEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CSeoInsertEdit_003Eb__13(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CSeoInsertEdit_003Eb__39(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass155_1
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass155_0 CS_0024_003C_003E8__locals1;

		internal bool _003CSeoInsertEdit_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSeoInsertEdit_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSeoInsertEdit_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSeoInsertEdit_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSeoInsertEdit_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSeoInsertEdit_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSeoInsertEdit_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSeoInsertEdit_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSeoInsertEdit_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSeoInsertEdit_003Eb__24(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSeoInsertEdit_003Eb__25(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSeoInsertEdit_003Eb__26(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSeoInsertEdit_003Eb__27(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSeoInsertEdit_003Eb__28(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSeoInsertEdit_003Eb__29(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSeoInsertEdit_003Eb__30(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSeoInsertEdit_003Eb__31(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSeoInsertEdit_003Eb__32(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSeoInsertEdit_003Eb__33(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSeoInsertEdit_003Eb__34(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSeoInsertEdit_003Eb__35(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSeoInsertEdit_003Eb__36(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSeoInsertEdit_003Eb__37(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSeoInsertEdit_003Eb__38(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass15_0
	{
		public int foSettingId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass1_0
	{
		public int cId;

		internal bool _003CInsertEditEmail_003Eb__0(CrmFoSetting_Lang x)
		{
			return x.CrmFoSetting.CId == cId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass2_0
	{
		public CrmFoSettingLanguageViewModel model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass30_0
	{
		public int cId;

		public int currLangID;

		internal bool _003CInsertEdit_Old_003Eb__0(CrmFoSetting_Lang x)
		{
			return x.CrmFoSetting.CId == cId;
		}

		internal bool _003CInsertEdit_Old_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_Old_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_Old_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_Old_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_Old_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_Old_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_Old_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_Old_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_Old_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_Old_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_Old_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_Old_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_Old_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_Old_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_Old_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_Old_003Eb__24(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_Old_003Eb__25(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_Old_003Eb__26(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_Old_003Eb__27(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_Old_003Eb__28(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_Old_003Eb__29(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass31_0
	{
		public CrmFoSettingLanguageViewModel model;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__11;

		public Func<Languages, bool> _003C_003E9__29;

		internal bool _003CInsertEdit_Old_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_Old_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_Old_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_Old_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_Old_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_Old_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_Old_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_Old_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_Old_003Eb__11(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEdit_Old_003Eb__29(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass31_1
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass31_0 CS_0024_003C_003E8__locals1;

		internal bool _003CInsertEdit_Old_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_Old_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_Old_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_Old_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_Old_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_Old_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_Old_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_Old_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_Old_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_Old_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_Old_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_Old_003Eb__24(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_Old_003Eb__25(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_Old_003Eb__26(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_Old_003Eb__27(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_Old_003Eb__28(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass33_0
	{
		public CRMspSelectFoSettingRegisterWithId_Result model;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__11;

		public Func<Languages, bool> _003C_003E9__29;

		internal bool _003CInsertEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

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

		internal bool _003CInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__11(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__29(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass33_1
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass33_0 CS_0024_003C_003E8__locals1;

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
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass39_0
	{
		public CrmFoShopSettingLanguageViewModel model;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__5;

		internal bool _003CEditShopSetting_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditShopSetting_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditShopSetting_003Eb__5(Languages m)
		{
			return m.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public int cId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass43_0
	{
		public CrmFoTicketSettingLanguageViewModel model;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__5;

		internal bool _003CEditUserDepartmentTicketSetting_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditUserDepartmentTicketSetting_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditUserDepartmentTicketSetting_003Eb__5(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass43_1
	{
		public UserDepartments modelUserDepartments;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass43_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass43_1 CS_0024_003C_003E8__locals1;

		internal bool _003CEditUserDepartmentTicketSetting_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditUserDepartmentTicketSetting_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditUserDepartmentTicketSetting_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditUserDepartmentTicketSetting_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public CrmFoSettingLanguageViewModel model;
	}

	private CRMSpEntities db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private CRMSpIEntities _dbI = new CRMSpIEntities();

	private CRMSpIIEntities _dbII = new CRMSpIIEntities();

	private readonly CRMLinkSpEntities _dbLink = new CRMLinkSpEntities();

	private readonly int _BgPicWidth = 1280;

	private readonly int _BgPicHeight = 939;

	private readonly int _PrdPicWidth = 300;

	private readonly int _PrdPicHeight = 300;

	private readonly int _NewsPicWidth = 300;

	private readonly int _NewsPicHeight = 300;

	private const int SEO_IE_Mode_FoSetting = 0;

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actFoSetting")]
	public string GetFoSettingRegister(int cId = 0)
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
			if (cId == 0)
			{
				cId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId.GetValueOrDefault() : 0);
			}
			List<CRMspSelectFoSettingRegister_Result> list = Enumerable.ToList<CRMspSelectFoSettingRegister_Result>((IEnumerable<CRMspSelectFoSettingRegister_Result>)_dbII.CRMspSelectFoSettingRegister(cId, lCID, result2));
			if (list != null)
			{
				result = JsonConvert.SerializeObject(list);
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actFoSetting")]
	public ActionResult InsertEditEmail(int foSettingId = 0)
	{
		_003C_003Ec__DisplayClass1_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass1_0();
		GetEmailSettingList();
		GetEmailList();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		CS_0024_003C_003E8__locals0.cId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId.GetValueOrDefault() : 0);
		CrmFoSettingLanguageViewModel crmFoSettingLanguageViewModel = new CrmFoSettingLanguageViewModel();
		DateTime now = DateTime.Now;
		try
		{
			Enumerable.ToList<CrmFoSetting_Lang>(Enumerable.Where<CrmFoSetting_Lang>((IEnumerable<CrmFoSetting_Lang>)Enumerable.ToList<CrmFoSetting_Lang>((IEnumerable<CrmFoSetting_Lang>)_dbTbl.CrmFoSetting_Lang), (Func<CrmFoSetting_Lang, bool>)((CrmFoSetting_Lang x) => x.CrmFoSetting.CId == CS_0024_003C_003E8__locals0.cId)));
			CrmFoSetting crmFoSetting = new CrmFoSetting();
			DbSet<CrmFoSetting> crmFoSetting2 = _dbTbl.CrmFoSetting;
			ParameterExpression val = Expression.Parameter(typeof(CrmFoSetting), "x");
			crmFoSetting = Queryable.FirstOrDefault<CrmFoSetting>((IQueryable<CrmFoSetting>)crmFoSetting2, Expression.Lambda<Func<CrmFoSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Convert((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass1_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), typeof(int?))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmFoSetting == null)
			{
				crmFoSetting = new CrmFoSetting
				{
					FoSettingId = 0,
					UserId = UserLogin.CurrentUser.UserId,
					FirstRegisterUserId = UserLogin.CurrentUser.UserId,
					RegisterDate = now,
					FirstRegisterDate = now
				};
			}
			crmFoSettingLanguageViewModel = new CrmFoSettingLanguageViewModel
			{
				FoSettingId = crmFoSetting.FoSettingId,
				EmailSendingIsActive = crmFoSetting.EmailSendingIsActive,
				EmailSettingId = crmFoSetting.EmailSettingId,
				EmailUserInfoId = crmFoSetting.EmailUserInfoId,
				EmailSubjectPatternFormula = crmFoSetting.EmailSubjectPatternFormula,
				EmailBodyPatternFormula = crmFoSetting.EmailBodyPatternFormula,
				FoLogEmailAdminI = crmFoSetting.FoLogEmailAdminI,
				FoLogEmailAdminII = crmFoSetting.FoLogEmailAdminII,
				EmailSmtpUseDefaultCredentials = crmFoSetting.EmailSmtpUseDefaultCredentials,
				EmailSmtpEnableSSL = crmFoSetting.EmailSmtpEnableSSL,
				EmailSmtpPort = crmFoSetting.EmailSmtpPort,
				EmailSubjectPatternFormulaSendFoInfo = crmFoSetting.EmailSubjectPatternFormulaSendFoInfo,
				EmailBodyPatternFormulaSendFoInfo = crmFoSetting.EmailBodyPatternFormulaSendFoInfo,
				FoAdminUserIds = crmFoSetting.FoAdminUserIds
			};
			if (!string.IsNullOrWhiteSpace(crmFoSettingLanguageViewModel.FoAdminUserIds))
			{
				List<CRMspSelectUsersByIds_Result> list = CRMIdeal.Classes.Helper.User.SelectUsersByIds(crmFoSettingLanguageViewModel.FoAdminUserIds);
				if (list != null && Enumerable.Any<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list))
				{
					crmFoSettingLanguageViewModel.FoAdminUsers = "";
					foreach (CRMspSelectUsersByIds_Result item in list)
					{
						if (!string.IsNullOrWhiteSpace(item.FullName))
						{
							if (!string.IsNullOrWhiteSpace(crmFoSettingLanguageViewModel.FoAdminUsers))
							{
								crmFoSettingLanguageViewModel.FoAdminUsers += ",";
							}
							crmFoSettingLanguageViewModel.FoAdminUsers += item.FullName;
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return View(crmFoSettingLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult InsertEditEmail(CrmFoSettingLanguageViewModel model)
	{
		_003C_003Ec__DisplayClass2_0 _003C_003Ec__DisplayClass2_ = new _003C_003Ec__DisplayClass2_0();
		_003C_003Ec__DisplayClass2_.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		GetEmailSettingList();
		GetEmailList();
		string text = "";
		int num = 0;
		try
		{
			if (_003C_003Ec__DisplayClass2_.model.FoSettingId <= 0)
			{
				num++;
			}
			if (num == 0)
			{
				DateTime now = DateTime.Now;
				DbSet<CrmFoSetting> crmFoSetting = _dbTbl.CrmFoSetting;
				ParameterExpression val = Expression.Parameter(typeof(CrmFoSetting), "m");
				CrmFoSetting crmFoSetting2 = Queryable.FirstOrDefault<CrmFoSetting>((IQueryable<CrmFoSetting>)crmFoSetting, Expression.Lambda<Func<CrmFoSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass2_, typeof(_003C_003Ec__DisplayClass2_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (crmFoSetting2 != null)
				{
					crmFoSetting2.EmailSendingIsActive = _003C_003Ec__DisplayClass2_.model.EmailSendingIsActive;
					crmFoSetting2.EmailSettingId = _003C_003Ec__DisplayClass2_.model.EmailSettingId;
					crmFoSetting2.EmailUserInfoId = _003C_003Ec__DisplayClass2_.model.EmailUserInfoId;
					crmFoSetting2.EmailSubjectPatternFormula = _003C_003Ec__DisplayClass2_.model.EmailSubjectPatternFormula;
					crmFoSetting2.EmailBodyPatternFormula = _003C_003Ec__DisplayClass2_.model.EmailBodyPatternFormula;
					crmFoSetting2.EmailSubjectPatternFormulaSendFoInfo = _003C_003Ec__DisplayClass2_.model.EmailSubjectPatternFormulaSendFoInfo;
					crmFoSetting2.EmailBodyPatternFormulaSendFoInfo = _003C_003Ec__DisplayClass2_.model.EmailBodyPatternFormulaSendFoInfo;
					crmFoSetting2.FoLogEmailAdminI = _003C_003Ec__DisplayClass2_.model.FoLogEmailAdminI;
					crmFoSetting2.FoLogEmailAdminII = _003C_003Ec__DisplayClass2_.model.FoLogEmailAdminII;
					crmFoSetting2.EmailSmtpUseDefaultCredentials = _003C_003Ec__DisplayClass2_.model.EmailSmtpUseDefaultCredentials;
					crmFoSetting2.EmailSmtpEnableSSL = _003C_003Ec__DisplayClass2_.model.EmailSmtpEnableSSL;
					crmFoSetting2.EmailSmtpPort = _003C_003Ec__DisplayClass2_.model.EmailSmtpPort;
					crmFoSetting2.FoAdminUserIds = _003C_003Ec__DisplayClass2_.model.FoAdminUserIds;
					crmFoSetting2.UserId = UserLogin.CurrentUser.UserId;
					crmFoSetting2.RegisterDate = now;
					crmFoSetting2.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					crmFoSetting2.Year1 = short.Parse(Financial.Get().Id.ToString());
					crmFoSetting2.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
					crmFoSetting2.AppType = Configuration.AppType;
					if (_003C_003Ec__DisplayClass2_.model.FoSettingId > 0)
					{
						_dbTbl.Entry(crmFoSetting2).State = EntityState.Modified;
						_dbTbl.SaveChanges();
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					}
					new FilesManager();
					new FacadeFTP(Configuration.FacadeFtpFo);
					string pathFtpFo = Configuration.PathFtpFo;
					string userNameFtpFo = Configuration.UserNameFtpFo;
					string passwordFtpFo = Configuration.PasswordFtpFo;
					bool usePassiveFtpFo = Configuration.UsePassiveFtpFo;
					if (!string.IsNullOrEmpty(pathFtpFo) && !string.IsNullOrEmpty(userNameFtpFo) && !string.IsNullOrEmpty(passwordFtpFo))
					{
						try
						{
							List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
							list.Add(new CommonMultiLanguageViewModel
							{
								Value = _003C_003Ec__DisplayClass2_.model.EmailBodyPatternFormula,
								LanguageId = lCID
							});
							List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
							list2.Add(new CommonMultiLanguageViewModel
							{
								Value = _003C_003Ec__DisplayClass2_.model.EmailBodyPatternFormulaSendFoInfo,
								LanguageId = lCID
							});
							if (list != null)
							{
								Files.UploadPicFromEditorToFtp(pathFtpFo, userNameFtpFo, passwordFtpFo, usePassiveFtpFo, list);
							}
							if (list2 != null)
							{
								Files.UploadPicFromEditorToFtp(pathFtpFo, userNameFtpFo, passwordFtpFo, usePassiveFtpFo, list2);
							}
						}
						catch (Exception e)
						{
							ErrorSignal.FromCurrentContext().Raise(e);
						}
					}
					_003C_003Ec__DisplayClass2_.model.UserId = crmFoSetting2.UserId;
					_003C_003Ec__DisplayClass2_.model.FirstRegisterUserId = crmFoSetting2.FirstRegisterUserId;
					_003C_003Ec__DisplayClass2_.model.RegisterDate = crmFoSetting2.RegisterDate;
					_003C_003Ec__DisplayClass2_.model.FirstRegisterDate = crmFoSetting2.FirstRegisterDate;
					_003C_003Ec__DisplayClass2_.model.AppType = crmFoSetting2.AppType;
				}
				else
				{
					text = Messages.ErrorNotFound;
				}
			}
			else
			{
				text = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
		}
		catch (DbEntityValidationException e2)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e2);
			text = Messages.frmErrorMessage;
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
			text = Messages.frmErrorMessage;
		}
		base.ViewBag.Error = text;
		return View(_003C_003Ec__DisplayClass2_.model);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actFoSetting")]
	public ActionResult InsertEditSms()
	{
		_003C_003Ec__DisplayClass3_0 _003C_003Ec__DisplayClass3_ = new _003C_003Ec__DisplayClass3_0();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		_003C_003Ec__DisplayClass3_.cId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId.GetValueOrDefault() : 0);
		CrmFoSettingLanguageViewModel model = new CrmFoSettingLanguageViewModel();
		_ = DateTime.Now;
		try
		{
			DbSet<CrmFoSetting> crmFoSetting = _dbTbl.CrmFoSetting;
			ParameterExpression val = Expression.Parameter(typeof(CrmFoSetting), "x");
			CrmFoSetting crmFoSetting2 = Queryable.FirstOrDefault<CrmFoSetting>((IQueryable<CrmFoSetting>)crmFoSetting, Expression.Lambda<Func<CrmFoSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Convert((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass3_, typeof(_003C_003Ec__DisplayClass3_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), typeof(int?))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			model = new CrmFoSettingLanguageViewModel
			{
				FoSettingId = crmFoSetting2.FoSettingId,
				SmsSendingIsActive = crmFoSetting2.SmsSendingIsActive,
				SmsWebServiceUserName = crmFoSetting2.SmsWebServiceUserName,
				SmsWebServicePassword = crmFoSetting2.SmsWebServicePassword,
				SmsWebServiceNumber = crmFoSetting2.SmsWebServiceNumber,
				SmsWebServiceUrl = crmFoSetting2.SmsWebServiceUrl,
				SmsBodyPatternFormula = crmFoSetting2.SmsBodyPatternFormula,
				SmsSendByGSM = crmFoSetting2.SmsSendByGSM,
				SmsSendByWeb = crmFoSetting2.SmsSendByWeb,
				SmsIsSendedVerification = crmFoSetting2.SmsIsSendedVerification,
				SmsVerificationId = crmFoSetting2.SmsVerificationId,
				SmsBodyPatternFormulaSendFoInfo = crmFoSetting2.SmsBodyPatternFormulaSendFoInfo,
				SmsBodyPatternFormulaForgetPassword = crmFoSetting2.SmsBodyPatternFormulaForgetPassword,
				SmsBodyPatternFormulaOTP = crmFoSetting2.SmsBodyPatternFormulaOTP
			};
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(model);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult InsertEditSms(CrmFoSettingLanguageViewModel model)
	{
		_003C_003Ec__DisplayClass4_0 _003C_003Ec__DisplayClass4_ = new _003C_003Ec__DisplayClass4_0();
		_003C_003Ec__DisplayClass4_.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		try
		{
			if (_003C_003Ec__DisplayClass4_.model.FoSettingId <= 0)
			{
				num++;
			}
			if (num == 0)
			{
				DateTime now = DateTime.Now;
				DbSet<CrmFoSetting> crmFoSetting = _dbTbl.CrmFoSetting;
				ParameterExpression val = Expression.Parameter(typeof(CrmFoSetting), "m");
				CrmFoSetting crmFoSetting2 = Queryable.FirstOrDefault<CrmFoSetting>((IQueryable<CrmFoSetting>)crmFoSetting, Expression.Lambda<Func<CrmFoSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass4_, typeof(_003C_003Ec__DisplayClass4_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (crmFoSetting2 != null)
				{
					crmFoSetting2.SmsBodyPatternFormulaSendFoInfo = _003C_003Ec__DisplayClass4_.model.SmsBodyPatternFormulaSendFoInfo;
					crmFoSetting2.SmsBodyPatternFormulaForgetPassword = _003C_003Ec__DisplayClass4_.model.SmsBodyPatternFormulaForgetPassword;
					crmFoSetting2.SmsSendingIsActive = _003C_003Ec__DisplayClass4_.model.SmsSendingIsActive;
					crmFoSetting2.SmsWebServiceUserName = _003C_003Ec__DisplayClass4_.model.SmsWebServiceUserName;
					crmFoSetting2.SmsWebServiceNumber = _003C_003Ec__DisplayClass4_.model.SmsWebServiceNumber;
					crmFoSetting2.SmsWebServiceUrl = _003C_003Ec__DisplayClass4_.model.SmsWebServiceUrl;
					crmFoSetting2.SmsBodyPatternFormula = _003C_003Ec__DisplayClass4_.model.SmsBodyPatternFormula;
					crmFoSetting2.SmsSendByGSM = _003C_003Ec__DisplayClass4_.model.SmsSendByGSM;
					crmFoSetting2.SmsSendByWeb = _003C_003Ec__DisplayClass4_.model.SmsSendByWeb;
					crmFoSetting2.SmsIsSendedVerification = _003C_003Ec__DisplayClass4_.model.SmsIsSendedVerification;
					crmFoSetting2.SmsVerificationId = _003C_003Ec__DisplayClass4_.model.SmsVerificationId;
					crmFoSetting2.SmsBodyPatternFormulaOTP = _003C_003Ec__DisplayClass4_.model.SmsBodyPatternFormulaOTP;
					crmFoSetting2.UserId = UserLogin.CurrentUser.UserId;
					crmFoSetting2.RegisterDate = now;
					crmFoSetting2.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					crmFoSetting2.Year1 = short.Parse(Financial.Get().Id.ToString());
					crmFoSetting2.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
					crmFoSetting2.AppType = Configuration.AppType;
					_003C_003Ec__DisplayClass4_.model.SmsWebServicePassword = ((!string.IsNullOrEmpty(_003C_003Ec__DisplayClass4_.model.SmsWebServicePassword)) ? _003C_003Ec__DisplayClass4_.model.SmsWebServicePassword : null);
					string text2 = ((!string.IsNullOrEmpty(_003C_003Ec__DisplayClass4_.model.SmsWebServicePassword)) ? XorCipher.EncryptByPrivateKey(_003C_003Ec__DisplayClass4_.model.SmsWebServicePassword) : null);
					if (!string.IsNullOrEmpty(crmFoSetting2.SmsWebServicePassword))
					{
						XorCipher.DecryptByPrivateKey(crmFoSetting2.SmsWebServicePassword);
					}
					bool num2 = text2 == crmFoSetting2.SmsWebServicePassword;
					bool flag = _003C_003Ec__DisplayClass4_.model.SmsWebServicePassword == crmFoSetting2.SmsWebServicePassword;
					if (!num2 && !flag)
					{
						crmFoSetting2.SmsWebServicePassword = text2;
					}
					if (_003C_003Ec__DisplayClass4_.model.FoSettingId > 0)
					{
						_dbTbl.Entry(crmFoSetting2).State = EntityState.Modified;
						_dbTbl.SaveChanges();
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					}
				}
				else
				{
					text = Messages.ErrorNotFound;
				}
			}
			else
			{
				text = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			text = Messages.frmErrorMessage;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			text = Messages.frmErrorMessage;
		}
		base.ViewBag.Error = text;
		return View(_003C_003Ec__DisplayClass4_.model);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actFoSetting")]
	public ActionResult EditShopHomeSetting()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		int? cId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
		CrmFoHomeSettingLanguageViewModel model = new CrmFoHomeSettingLanguageViewModel();
		_ = DateTime.Now;
		try
		{
			BaseInfo baseInfo = new BaseInfo();
			IEnumerable<CrmFoSetting_Lang> enumerable = Enumerable.Where<CrmFoSetting_Lang>((IEnumerable<CrmFoSetting_Lang>)Enumerable.ToList<CrmFoSetting_Lang>((IEnumerable<CrmFoSetting_Lang>)_dbTbl.CrmFoSetting_Lang), (Func<CrmFoSetting_Lang, bool>)((CrmFoSetting_Lang x) => x.CrmFoSetting.CId == cId));
			string positionTopRightTxt = Labels.PositionTopRightTxt;
			string positionTopCenterTxt = Labels.PositionTopCenterTxt;
			string positionTopLeftTxt = Labels.PositionTopLeftTxt;
			string positionCenterRightTxt = Labels.PositionCenterRightTxt;
			string positionCenterTxt = Labels.PositionCenterTxt;
			string positionCenterLeftTxt = Labels.PositionCenterLeftTxt;
			string positionBottomRightTxt = Labels.PositionBottomRightTxt;
			string positionBottomCenterTxt = Labels.PositionBottomCenterTxt;
			string positionBottomLeftTxt = Labels.PositionBottomLeftTxt;
			CRMSpEntities cRMSpEntities = db;
			string foSettingDefDisplay4Column = Labels.FoSettingDefDisplay4Column;
			string foSettingDefDisplay3Column = Labels.FoSettingDefDisplay3Column;
			string foSettingDefDisplayListView = Labels.FoSettingDefDisplayListView;
			string foSettingDefDisplayListViewSmall = Labels.FoSettingDefDisplayListViewSmall;
			int? languageID = result;
			int? defaultLanguageID = result;
			CRMspSelectFoSetting_Result cRMspSelectFoSetting_Result = Enumerable.FirstOrDefault<CRMspSelectFoSetting_Result>((IEnumerable<CRMspSelectFoSetting_Result>)cRMSpEntities.CRMspSelectFoSetting(foSettingDefDisplay4Column, foSettingDefDisplay3Column, foSettingDefDisplayListView, foSettingDefDisplayListViewSmall, positionTopRightTxt, positionTopCenterTxt, positionTopLeftTxt, positionCenterRightTxt, positionCenterTxt, positionCenterLeftTxt, positionBottomRightTxt, positionBottomCenterTxt, positionBottomLeftTxt, languageID, defaultLanguageID, cId));
			if (cRMspSelectFoSetting_Result == null)
			{
				cRMspSelectFoSetting_Result = new CRMspSelectFoSetting_Result
				{
					FoSettingId = 0,
					PrdPriceVisible = false
				};
			}
			List<CommonMultiLanguageViewModel> list = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.ShpHomePrdPartTitle,
				LanguageId = item.LanguageID
			})));
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = cRMspSelectFoSetting_Result.ShpHomePrdPartTitle,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.ShpHomeTopHeaderContent,
				LanguageId = item.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = cRMspSelectFoSetting_Result.ShpHomeTopHeaderContent,
				LanguageId = result
			});
			model = new CrmFoHomeSettingLanguageViewModel
			{
				FoSettingId = cRMspSelectFoSetting_Result.FoSettingId,
				ShpHomePrdPartTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
				ShpHomePrdPartTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
				ShpHomeGalleryIdI = cRMspSelectFoSetting_Result.ShpHomeGalleryIdI,
				ShpHomeGalleryIdII = cRMspSelectFoSetting_Result.ShpHomeGalleryIdII,
				ShpHomeGalleryIdIII = cRMspSelectFoSetting_Result.ShpHomeGalleryIdIII,
				ShpHomeTopHeaderBgColor = baseInfo.DelphiCToRgbolor(cRMspSelectFoSetting_Result.ShpHomeTopHeaderBgColor),
				ShpHomeTopHeaderFontColor = baseInfo.DelphiCToRgbolor(cRMspSelectFoSetting_Result.ShpHomeTopHeaderFontColor),
				ShpFooterId = cRMspSelectFoSetting_Result.ShpFooterId,
				ShpHomeTopHeaderContent = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
				ShpHomeTopHeaderContent_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))))
			};
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.GalleryIList = GetGalleryList();
		base.ViewBag.GalleryIIList = GetGalleryList();
		base.ViewBag.GalleryIIIList = GetGalleryList();
		base.ViewBag.ShpFooterList = GetShpFooterList();
		return View(model);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult EditShopHomeSetting(CrmFoHomeSettingLanguageViewModel model)
	{
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		base.ViewBag.GalleryIList = GetGalleryList();
		base.ViewBag.GalleryIIList = GetGalleryList();
		base.ViewBag.GalleryIIIList = GetGalleryList();
		base.ViewBag.ShpFooterList = GetShpFooterList();
		try
		{
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.ShpHomePrdPartTitle_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ShpHomePrdPartTitle_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = model.ShpHomePrdPartTitle,
				LanguageId = lCID
			});
			string prdPartTitleMultiLang = "";
			string shpHomePrdPartTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : "");
			string foSetting_Lang = "";
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.ShpHomeTopHeaderContent_Lang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ShpHomeTopHeaderContent_Lang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = model.ShpHomeTopHeaderContent,
				LanguageId = lCID
			});
			string shpHomeTopHeaderContent = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : "");
			List<CrmFoSetting_Lang> list3 = new List<CrmFoSetting_Lang>();
			foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages m) => m.LanguageID != defLangID))))
			{
				CrmFoSetting_Lang crmFoSetting_Lang = new CrmFoSetting_Lang();
				crmFoSetting_Lang.LanguageID = lang.LanguageID;
				crmFoSetting_Lang.ShpHomePrdPartTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : "");
				crmFoSetting_Lang.ShpHomeTopHeaderContent = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : "");
				list3.Add(crmFoSetting_Lang);
			}
			if (list3 != null && Enumerable.Any<CrmFoSetting_Lang>((IEnumerable<CrmFoSetting_Lang>)list3))
			{
				foSetting_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CrmFoSetting_Lang>((IEnumerable<CrmFoSetting_Lang>)list3));
			}
			if (base.ModelState.IsValid)
			{
				BaseInfo baseInfo = new BaseInfo();
				if (num == 0)
				{
					DateTime now = DateTime.Now;
					int userId = UserLogin.CurrentUser.UserId;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value = short.Parse(Financial.Get().Id.ToString());
					short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					_dbI.CRMspUpdateFODefaultShopHomePageSetting(foSettingId: model.FoSettingId, shpHomeGalleryIdI: model.ShpHomeGalleryIdI, shpHomeGalleryIdII: model.ShpHomeGalleryIdII, shpHomeGalleryIdIII: model.ShpHomeGalleryIdIII, shpHomeTopHeaderBgColor: baseInfo.RgbToDelphiColor(model.ShpHomeTopHeaderBgColor), shpHomeTopHeaderFontColor: baseInfo.RgbToDelphiColor(model.ShpHomeTopHeaderFontColor), shpHomePrdPartTitle: shpHomePrdPartTitle, prdPartTitleMultiLang: prdPartTitleMultiLang, userId: userId, year1: value, month1: value2, registerDate: now, registerDatePersian: registerDatePersian, appType: appType, defaultLanguageID: defLangID, shpFooterId: model.ShpFooterId, shpHomeTopHeaderContent: shpHomeTopHeaderContent, foSetting_Lang: foSetting_Lang);
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmFoSetting");
					new FilesManager();
					new FacadeFTP(Configuration.FacadeFtpFo);
					string pathFtpFo = Configuration.PathFtpFo;
					string userNameFtpFo = Configuration.UserNameFtpFo;
					string passwordFtpFo = Configuration.PasswordFtpFo;
					bool usePassiveFtpFo = Configuration.UsePassiveFtpFo;
					if (!string.IsNullOrEmpty(pathFtpFo) && !string.IsNullOrEmpty(userNameFtpFo) && !string.IsNullOrEmpty(passwordFtpFo))
					{
						try
						{
							if (list2 != null)
							{
								Files.UploadPicFromEditorToFtp(pathFtpFo, userNameFtpFo, passwordFtpFo, usePassiveFtpFo, list2);
							}
						}
						catch (Exception e)
						{
							ErrorSignal.FromCurrentContext().Raise(e);
						}
					}
				}
			}
			else
			{
				text = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
		}
		catch (DbEntityValidationException e2)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e2);
			text = Messages.frmErrorMessage;
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
			text = Messages.frmErrorMessage;
		}
		base.ViewBag.Error = text;
		return View(model);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actFoSetting")]
	public ActionResult EditFrontHomeSetting()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		int? cId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
		CrmFoHomeSettingLanguageViewModel model = new CrmFoHomeSettingLanguageViewModel();
		_ = DateTime.Now;
		try
		{
			new BaseInfo();
			IEnumerable<CrmFoSetting_Lang> enumerable = Enumerable.Where<CrmFoSetting_Lang>((IEnumerable<CrmFoSetting_Lang>)Enumerable.ToList<CrmFoSetting_Lang>((IEnumerable<CrmFoSetting_Lang>)_dbTbl.CrmFoSetting_Lang), (Func<CrmFoSetting_Lang, bool>)((CrmFoSetting_Lang x) => x.CrmFoSetting.CId == cId));
			string positionTopRightTxt = Labels.PositionTopRightTxt;
			string positionTopCenterTxt = Labels.PositionTopCenterTxt;
			string positionTopLeftTxt = Labels.PositionTopLeftTxt;
			string positionCenterRightTxt = Labels.PositionCenterRightTxt;
			string positionCenterTxt = Labels.PositionCenterTxt;
			string positionCenterLeftTxt = Labels.PositionCenterLeftTxt;
			string positionBottomRightTxt = Labels.PositionBottomRightTxt;
			string positionBottomCenterTxt = Labels.PositionBottomCenterTxt;
			string positionBottomLeftTxt = Labels.PositionBottomLeftTxt;
			_ = Labels.SmsSendByWebTxt;
			_ = Labels.SmsSendByGsmTxt;
			CRMSpEntities cRMSpEntities = db;
			string foSettingDefDisplay4Column = Labels.FoSettingDefDisplay4Column;
			string foSettingDefDisplay3Column = Labels.FoSettingDefDisplay3Column;
			string foSettingDefDisplayListView = Labels.FoSettingDefDisplayListView;
			string foSettingDefDisplayListViewSmall = Labels.FoSettingDefDisplayListViewSmall;
			int? languageID = result;
			int? defaultLanguageID = result;
			CRMspSelectFoSetting_Result cRMspSelectFoSetting_Result = Enumerable.FirstOrDefault<CRMspSelectFoSetting_Result>((IEnumerable<CRMspSelectFoSetting_Result>)cRMSpEntities.CRMspSelectFoSetting(foSettingDefDisplay4Column, foSettingDefDisplay3Column, foSettingDefDisplayListView, foSettingDefDisplayListViewSmall, positionTopRightTxt, positionTopCenterTxt, positionTopLeftTxt, positionCenterRightTxt, positionCenterTxt, positionCenterLeftTxt, positionBottomRightTxt, positionBottomCenterTxt, positionBottomLeftTxt, languageID, defaultLanguageID, cId));
			if (cRMspSelectFoSetting_Result == null)
			{
				cRMspSelectFoSetting_Result = new CRMspSelectFoSetting_Result
				{
					FoSettingId = 0,
					PrdPriceVisible = false
				};
			}
			Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.ShpHomePrdPartTitle,
				LanguageId = item.LanguageID
			}))).Add(new CommonMultiLanguageViewModel
			{
				Value = cRMspSelectFoSetting_Result.ShpHomePrdPartTitle,
				LanguageId = result
			});
			model = new CrmFoHomeSettingLanguageViewModel
			{
				FoSettingId = cRMspSelectFoSetting_Result.FoSettingId,
				FoHomeGalleryIdI = cRMspSelectFoSetting_Result.FoHomeGalleryIdI,
				FoHomeGalleryIdII = cRMspSelectFoSetting_Result.FoHomeGalleryIdII,
				FoHomeGalleryIdIII = cRMspSelectFoSetting_Result.FoHomeGalleryIdIII,
				MobFoHomeGalleryId = cRMspSelectFoSetting_Result.MobFoHomeGalleryId,
				FoFileAttachCount = cRMspSelectFoSetting_Result.FoFileAttachCount,
				FoShowControlPrdValidity = cRMspSelectFoSetting_Result.FoShowControlPrdValidity,
				FoShowPordByTspMethod = cRMspSelectFoSetting_Result.FoShowPordByTspMethod,
				FoShowOrdByTspMethod = cRMspSelectFoSetting_Result.FoShowOrdByTspMethod
			};
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.FoGalleryIList = GetFoGalleryList();
		base.ViewBag.FoGalleryIIList = GetFoGalleryList();
		base.ViewBag.FoGalleryIIIList = GetFoGalleryList();
		base.ViewBag.MobFoGalleryIIIList = GetMobFoGalleryList();
		return View(model);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult EditFrontHomeSetting(CrmFoHomeSettingLanguageViewModel model)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		base.ViewBag.FoGalleryIList = GetFoGalleryList();
		base.ViewBag.FoGalleryIIList = GetFoGalleryList();
		base.ViewBag.FoGalleryIIIList = GetFoGalleryList();
		base.ViewBag.MobFoGalleryIIIList = GetMobFoGalleryList();
		try
		{
			if (base.ModelState.IsValid)
			{
				new BaseInfo();
				if (num == 0)
				{
					DateTime now = DateTime.Now;
					int userId = UserLogin.CurrentUser.UserId;
					string text2 = now.ToString("yyyyMMdd", new PersianCulture());
					short value = short.Parse(Financial.Get().Id.ToString());
					short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					_dbI.CRMspUpdateFODefaultFrontHomePageSetting(userId: userId, year1: value, month1: value2, registerDate: now, registerDatePersian: text2, appType: appType, defaultLanguageID: result, foHomeGalleryIdI: model.FoHomeGalleryIdI, foHomeGalleryIdII: model.FoHomeGalleryIdII, foHomeGalleryIdIII: model.FoHomeGalleryIdIII, mobFoHomeGalleryId: model.MobFoHomeGalleryId, foFileAttachCount: model.FoFileAttachCount, foShowControlPrdValidity: model.FoShowControlPrdValidity, foShowPordByTspMethod: model.FoShowPordByTspMethod, foShowOrdByTspMethod: model.FoShowOrdByTspMethod, foSettingId: model.FoSettingId);
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmFoSetting");
				}
			}
			else
			{
				text = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			text = Messages.frmErrorMessage;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			text = Messages.frmErrorMessage;
		}
		base.ViewBag.Error = text;
		return View(model);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actFoSetting")]
	public ActionResult FoSettingShare()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int num = -1;
		int num2 = -1;
		try
		{
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<CRMspSelectCrmsysSetting_Result>((IEnumerable<CRMspSelectCrmsysSetting_Result>)db.CRMspSelectCrmsysSetting(lCID, result));
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				num = cRMspSelectCrmsysSetting_Result.FoSettingShareMode.GetValueOrDefault(-1);
				num2 = cRMspSelectCrmsysSetting_Result.FoSettingShareId.GetValueOrDefault(-1);
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		base.ViewBag.FoSettingShareMode = num;
		base.ViewBag.FoSettingShareId = num2;
		return View();
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actFoSetting")]
	public string FoSettingShare(int? shareMode = null, int? shareId = null)
	{
		string result = "";
		try
		{
			_dbII.CRMspUpdateSysSettingFoSettingShare(shareMode, shareId);
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			result = Messages.MsgErrorDoneOperation;
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetFoSettings(int? selectedId = null)
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
			List<CRMspSelectFoSetting_Result> list2 = Enumerable.ToList<CRMspSelectFoSetting_Result>((IEnumerable<CRMspSelectFoSetting_Result>)db.CRMspSelectFoSetting(null, null, null, null, null, null, null, null, null, null, null, null, null, lCID, result, 0));
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<CRMspSelectFoSetting_Result, SelectListItem>((IEnumerable<CRMspSelectFoSetting_Result>)list2, (Func<CRMspSelectFoSetting_Result, SelectListItem>)((CRMspSelectFoSetting_Result x) => new SelectListItem
				{
					Text = x.CenterName,
					Value = x.FoSettingId.ToString(),
					Selected = (x.FoSettingId == selectedId)
				})));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return JsonConvert.SerializeObject(list);
	}

	[LoginAuthorize]
	public ActionResult PrdCardInfoInsertEdit(int foSettingId)
	{
		string text = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int? centerId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
			CRMspSelectFoSetting_Result cRMspSelectFoSetting_Result = Enumerable.FirstOrDefault<CRMspSelectFoSetting_Result>((IEnumerable<CRMspSelectFoSetting_Result>)db.CRMspSelectFoSetting(Labels.FoSettingDefDisplay4Column, Labels.FoSettingDefDisplay3Column, Labels.FoSettingDefDisplayListView, Labels.FoSettingDefDisplayListViewSmall, null, null, null, null, null, null, null, null, null, lCID, result, centerId));
			if (cRMspSelectFoSetting_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectFoSetting_Result.PrdCardInfoHTML))
			{
				text = cRMspSelectFoSetting_Result.PrdCardInfoHTML;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		base.ViewBag.FoSettingId = foSettingId;
		base.ViewBag.HTMLContent = text;
		return View();
	}

	[HttpPost]
	[LoginAuthorize]
	[ValidateInput(false)]
	public string PrdCardInfoInsertEdit(int foSettingId, string htmlContent = "")
	{
		string result = "";
		try
		{
			_dbII.CRMspUpdateFoSettingPrdCardInfoHTML(foSettingId, htmlContent);
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			result = Messages.msgErrorOperationFailed;
		}
		return result;
	}

	[HttpGet]
	[AjaxOnly]
	public JsonResult GetFoSettingSmsWebServicePasswordWithInput(int foSettingId, string inputPassword, int mode)
	{
		_003C_003Ec__DisplayClass14_0 _003C_003Ec__DisplayClass14_ = new _003C_003Ec__DisplayClass14_0();
		_003C_003Ec__DisplayClass14_.foSettingId = foSettingId;
		DbSet<CrmFoSetting> crmFoSetting = _dbTbl.CrmFoSetting;
		ParameterExpression val = Expression.Parameter(typeof(CrmFoSetting), "m");
		CrmFoSetting crmFoSetting2 = Queryable.FirstOrDefault<CrmFoSetting>((IQueryable<CrmFoSetting>)crmFoSetting, Expression.Lambda<Func<CrmFoSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass14_, typeof(_003C_003Ec__DisplayClass14_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
		if (crmFoSetting2 == null || string.IsNullOrEmpty(crmFoSetting2.SmsWebServicePassword))
		{
			return Json(new
			{
				data = string.Empty
			}, JsonRequestBehavior.AllowGet);
		}
		inputPassword = ((!string.IsNullOrEmpty(inputPassword)) ? inputPassword : null);
		string obj = ((!string.IsNullOrEmpty(inputPassword)) ? XorCipher.EncryptByPrivateKey(inputPassword) : null);
		string text = ((!string.IsNullOrEmpty(crmFoSetting2.SmsWebServicePassword)) ? XorCipher.DecryptByPrivateKey(crmFoSetting2.SmsWebServicePassword) : null);
		bool num = obj == crmFoSetting2.SmsWebServicePassword;
		bool flag = inputPassword == crmFoSetting2.SmsWebServicePassword;
		if (!num && !flag)
		{
			return Json(new
			{
				data = inputPassword
			}, JsonRequestBehavior.AllowGet);
		}
		return Json(new
		{
			data = ((mode == 1) ? text : crmFoSetting2.SmsWebServicePassword)
		}, JsonRequestBehavior.AllowGet);
	}

	public JsonResult GetFoSettingSmsWebServicePassword(int foSettingId, int mode)
	{
		_003C_003Ec__DisplayClass15_0 _003C_003Ec__DisplayClass15_ = new _003C_003Ec__DisplayClass15_0();
		_003C_003Ec__DisplayClass15_.foSettingId = foSettingId;
		DbSet<CrmFoSetting> crmFoSetting = _dbTbl.CrmFoSetting;
		ParameterExpression val = Expression.Parameter(typeof(CrmFoSetting), "m");
		CrmFoSetting crmFoSetting2 = Queryable.FirstOrDefault<CrmFoSetting>((IQueryable<CrmFoSetting>)crmFoSetting, Expression.Lambda<Func<CrmFoSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass15_, typeof(_003C_003Ec__DisplayClass15_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
		if (crmFoSetting2 == null || string.IsNullOrEmpty(crmFoSetting2.SmsWebServicePassword))
		{
			return Json(new
			{
				data = string.Empty
			}, JsonRequestBehavior.AllowGet);
		}
		return Json(new
		{
			data = ((mode == 1) ? XorCipher.DecryptByPrivateKey(crmFoSetting2.SmsWebServicePassword) : crmFoSetting2.SmsWebServicePassword)
		}, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actFoSetting")]
	public ActionResult Index(string tName = "")
	{
		GetStatusGroups();
		GetUserDepartmentList();
		base.ViewBag.TagRedirector = tName;
		CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
		int num = 0;
		if (cRMspSelectCrmsysSetting_Result != null)
		{
			num = cRMspSelectCrmsysSetting_Result.LinkAccSystemId.GetValueOrDefault();
		}
		base.ViewBag.LinkAccSystemId = num;
		string text = base.Server.MapPath(Configuration.HostTempFilesPath);
		string text2 = "";
		string[] directories = System.IO.Directory.GetDirectories(text);
		if (directories != null)
		{
			string[] array = directories;
			foreach (string text3 in array)
			{
				if (!string.IsNullOrEmpty(text3))
				{
					string text4 = text3.Replace("\\", "\\");
					text4 = text4.Replace(text + "\\", "");
					if (!string.IsNullOrEmpty(text4) && text4.ToLower() != "cnvs" && text4.ToLower() != "emails" && text4.ToLower() != "intmsg" && text4.ToLower() != "telegram" && text4.ToLower() != "test")
					{
						text2 = text2 + text4 + ",";
					}
				}
			}
		}
		base.ViewBag.ListDir = text2;
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actFoSetting")]
	public ActionResult Index_Old()
	{
		GetStatusGroups();
		GetUserDepartmentList();
		string text = base.Server.MapPath(Configuration.HostTempFilesPath);
		string text2 = "";
		string[] directories = System.IO.Directory.GetDirectories(text);
		if (directories != null)
		{
			string[] array = directories;
			foreach (string text3 in array)
			{
				if (!string.IsNullOrEmpty(text3))
				{
					string text4 = text3.Replace("\\", "\\");
					text4 = text4.Replace(text + "\\", "");
					if (!string.IsNullOrEmpty(text4) && text4.ToLower() != "cnvs" && text4.ToLower() != "emails" && text4.ToLower() != "intmsg" && text4.ToLower() != "telegram" && text4.ToLower() != "test")
					{
						text2 = text2 + text4 + ",";
					}
				}
			}
		}
		base.ViewBag.ListDir = text2;
		return View();
	}

	[AjaxOnly]
	public JsonResult GetFoSetting()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int? centerId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
		CRMspSelectFoSetting_Result cRMspSelectFoSetting_Result = new CRMspSelectFoSetting_Result();
		try
		{
			string positionTopRightTxt = Labels.PositionTopRightTxt;
			string positionTopCenterTxt = Labels.PositionTopCenterTxt;
			string positionTopLeftTxt = Labels.PositionTopLeftTxt;
			string positionCenterRightTxt = Labels.PositionCenterRightTxt;
			string positionCenterTxt = Labels.PositionCenterTxt;
			string positionCenterLeftTxt = Labels.PositionCenterLeftTxt;
			string positionBottomRightTxt = Labels.PositionBottomRightTxt;
			string positionBottomCenterTxt = Labels.PositionBottomCenterTxt;
			string positionBottomLeftTxt = Labels.PositionBottomLeftTxt;
			_ = Labels.SmsSendByWebTxt;
			_ = Labels.SmsSendByGsmTxt;
			CRMSpEntities cRMSpEntities = db;
			string foSettingDefDisplay4Column = Labels.FoSettingDefDisplay4Column;
			string foSettingDefDisplay3Column = Labels.FoSettingDefDisplay3Column;
			string foSettingDefDisplayListView = Labels.FoSettingDefDisplayListView;
			string foSettingDefDisplayListViewSmall = Labels.FoSettingDefDisplayListViewSmall;
			int? languageID = lCID;
			int? defaultLanguageID = result;
			cRMspSelectFoSetting_Result = Enumerable.FirstOrDefault<CRMspSelectFoSetting_Result>((IEnumerable<CRMspSelectFoSetting_Result>)cRMSpEntities.CRMspSelectFoSetting(foSettingDefDisplay4Column, foSettingDefDisplay3Column, foSettingDefDisplayListView, foSettingDefDisplayListViewSmall, positionTopRightTxt, positionTopCenterTxt, positionTopLeftTxt, positionCenterRightTxt, positionCenterTxt, positionCenterLeftTxt, positionBottomRightTxt, positionBottomCenterTxt, positionBottomLeftTxt, languageID, defaultLanguageID, centerId));
			BaseInfo baseInfo = new BaseInfo();
			if (cRMspSelectFoSetting_Result != null)
			{
				cRMspSelectFoSetting_Result.ShpHomeTopHeaderBgColor = baseInfo.DelphiCToRgbolor(cRMspSelectFoSetting_Result.ShpHomeTopHeaderBgColor);
				cRMspSelectFoSetting_Result.ShpHomeTopHeaderFontColor = baseInfo.DelphiCToRgbolor(cRMspSelectFoSetting_Result.ShpHomeTopHeaderFontColor);
				cRMspSelectFoSetting_Result.LoginBgColor = baseInfo.DelphiCToRgbolor(cRMspSelectFoSetting_Result.LoginBgColor);
				cRMspSelectFoSetting_Result.LoginBtnBgColor = baseInfo.DelphiCToRgbolor(cRMspSelectFoSetting_Result.LoginBtnBgColor);
				cRMspSelectFoSetting_Result.LoginBtnFontColor = baseInfo.DelphiCToRgbolor(cRMspSelectFoSetting_Result.LoginBtnFontColor);
				cRMspSelectFoSetting_Result.LoginLinkColor = baseInfo.DelphiCToRgbolor(cRMspSelectFoSetting_Result.LoginLinkColor);
				cRMspSelectFoSetting_Result.LoginTextBorderFColor = baseInfo.DelphiCToRgbolor(cRMspSelectFoSetting_Result.LoginTextBorderFColor);
				cRMspSelectFoSetting_Result.LoginTextBorderTColor = baseInfo.DelphiCToRgbolor(cRMspSelectFoSetting_Result.LoginTextBorderTColor);
				if (!string.IsNullOrEmpty(cRMspSelectFoSetting_Result.LoginBgImagePath))
				{
					string loginBgImagePath = cRMspSelectFoSetting_Result.LoginBgImagePath;
					cRMspSelectFoSetting_Result.LoginBgImagePath = cRMspSelectFoSetting_Result.LoginBgImagePath.Replace(Configuration.MainDirectoryPath, "/");
					cRMspSelectFoSetting_Result.LoginBgImagePath = Configuration.HostTempFilesPath + cRMspSelectFoSetting_Result.LoginBgImagePath;
					if (!System.IO.File.Exists(base.Server.MapPath(cRMspSelectFoSetting_Result.LoginBgImagePath)) && !DownlaodFileFromFTP(loginBgImagePath, cRMspSelectFoSetting_Result.LoginBgImagePath))
					{
						cRMspSelectFoSetting_Result.LoginBgImagePath = "";
					}
				}
				cRMspSelectFoSetting_Result.RegBgColor = baseInfo.DelphiCToRgbolor(cRMspSelectFoSetting_Result.RegBgColor);
				cRMspSelectFoSetting_Result.RegBtnBgColor = baseInfo.DelphiCToRgbolor(cRMspSelectFoSetting_Result.RegBtnBgColor);
				cRMspSelectFoSetting_Result.RegBtnFontColor = baseInfo.DelphiCToRgbolor(cRMspSelectFoSetting_Result.RegBtnFontColor);
				cRMspSelectFoSetting_Result.RegLinkColor = baseInfo.DelphiCToRgbolor(cRMspSelectFoSetting_Result.RegLinkColor);
				cRMspSelectFoSetting_Result.RegTextBorderFColor = baseInfo.DelphiCToRgbolor(cRMspSelectFoSetting_Result.RegTextBorderFColor);
				cRMspSelectFoSetting_Result.RegTextBorderTColor = baseInfo.DelphiCToRgbolor(cRMspSelectFoSetting_Result.RegTextBorderTColor);
				if (!string.IsNullOrEmpty(cRMspSelectFoSetting_Result.RegBgImagePath))
				{
					string regBgImagePath = cRMspSelectFoSetting_Result.RegBgImagePath;
					cRMspSelectFoSetting_Result.RegBgImagePath = cRMspSelectFoSetting_Result.RegBgImagePath.Replace(Configuration.MainDirectoryPath, "/");
					cRMspSelectFoSetting_Result.RegBgImagePath = Configuration.HostTempFilesPath + cRMspSelectFoSetting_Result.RegBgImagePath;
					if (!System.IO.File.Exists(base.Server.MapPath(cRMspSelectFoSetting_Result.RegBgImagePath)) && !DownlaodFileFromFTP(regBgImagePath, cRMspSelectFoSetting_Result.RegBgImagePath))
					{
						cRMspSelectFoSetting_Result.RegBgImagePath = "";
					}
				}
				if (!string.IsNullOrEmpty(cRMspSelectFoSetting_Result.ShpLogoPathWidth110))
				{
					string shpLogoPathWidth = cRMspSelectFoSetting_Result.ShpLogoPathWidth110;
					cRMspSelectFoSetting_Result.ShpLogoPathWidth110 = cRMspSelectFoSetting_Result.ShpLogoPathWidth110.Replace(Configuration.MainDirectoryPath, "/");
					cRMspSelectFoSetting_Result.ShpLogoPathWidth110 = Configuration.HostTempFilesPath + cRMspSelectFoSetting_Result.ShpLogoPathWidth110;
					if (!System.IO.File.Exists(base.Server.MapPath(cRMspSelectFoSetting_Result.ShpLogoPathWidth110)) && DownlaodFileFromFTP(shpLogoPathWidth, cRMspSelectFoSetting_Result.ShpLogoPathWidth110))
					{
						cRMspSelectFoSetting_Result.ShpLogoPathWidth110 = "";
					}
				}
				if (!string.IsNullOrEmpty(cRMspSelectFoSetting_Result.ShpLogoPathWidth215))
				{
					string shpLogoPathWidth2 = cRMspSelectFoSetting_Result.ShpLogoPathWidth215;
					cRMspSelectFoSetting_Result.ShpLogoPathWidth215 = cRMspSelectFoSetting_Result.ShpLogoPathWidth215.Replace(Configuration.MainDirectoryPath, "/");
					cRMspSelectFoSetting_Result.ShpLogoPathWidth215 = Configuration.HostTempFilesPath + cRMspSelectFoSetting_Result.ShpLogoPathWidth215;
					if (!System.IO.File.Exists(base.Server.MapPath(cRMspSelectFoSetting_Result.ShpLogoPathWidth215)) && DownlaodFileFromFTP(shpLogoPathWidth2, cRMspSelectFoSetting_Result.ShpLogoPathWidth215))
					{
						cRMspSelectFoSetting_Result.ShpLogoPathWidth215 = "";
					}
				}
				if (!string.IsNullOrEmpty(cRMspSelectFoSetting_Result.FoMobEntryLogoPath))
				{
					string foMobEntryLogoPath = cRMspSelectFoSetting_Result.FoMobEntryLogoPath;
					cRMspSelectFoSetting_Result.FoMobEntryLogoPath = cRMspSelectFoSetting_Result.FoMobEntryLogoPath.Replace(Configuration.MainDirectoryPath, "/");
					cRMspSelectFoSetting_Result.FoMobEntryLogoPath = Configuration.HostTempFilesPath + cRMspSelectFoSetting_Result.FoMobEntryLogoPath;
					if (!System.IO.File.Exists(base.Server.MapPath(cRMspSelectFoSetting_Result.FoMobEntryLogoPath)) && DownlaodFileFromFTP(foMobEntryLogoPath, cRMspSelectFoSetting_Result.FoMobEntryLogoPath))
					{
						cRMspSelectFoSetting_Result.FoMobEntryLogoPath = "";
					}
				}
				if (!string.IsNullOrEmpty(cRMspSelectFoSetting_Result.ShpPrdDefPhotoAdd))
				{
					string shpPrdDefPhotoAdd = cRMspSelectFoSetting_Result.ShpPrdDefPhotoAdd;
					cRMspSelectFoSetting_Result.ShpPrdDefPhotoAdd = cRMspSelectFoSetting_Result.ShpPrdDefPhotoAdd.Replace(Configuration.MainDirectoryPath, "/");
					cRMspSelectFoSetting_Result.ShpPrdDefPhotoAdd = Configuration.HostTempFilesPath + cRMspSelectFoSetting_Result.ShpPrdDefPhotoAdd;
					if (!System.IO.File.Exists(base.Server.MapPath(cRMspSelectFoSetting_Result.ShpPrdDefPhotoAdd)) && DownlaodFileFromFTP(shpPrdDefPhotoAdd, cRMspSelectFoSetting_Result.ShpPrdDefPhotoAdd))
					{
						cRMspSelectFoSetting_Result.ShpPrdDefPhotoAdd = "";
					}
				}
				cRMspSelectFoSetting_Result.AppType = "";
				string text = cRMspSelectFoSetting_Result.ShpCartPayTypeIds ?? "";
				List<string> lstShpCartPayTypeIds = Enumerable.ToList<string>((IEnumerable<string>)text.Split(new char[1] { ',' }));
				JsonResult shpCartPayType = GetShpCartPayType();
				int i;
				for (i = 0; i < lstShpCartPayTypeIds.Count; i++)
				{
					if (cRMspSelectFoSetting_Result.AppType != "")
					{
						cRMspSelectFoSetting_Result.AppType += ", ";
					}
					cRMspSelectFoSetting_Result.AppType += Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)(List<SelectListItem>)shpCartPayType.Data, (Func<SelectListItem, bool>)((SelectListItem x) => x.Value == lstShpCartPayTypeIds[i])).Text;
				}
				cRMspSelectFoSetting_Result.RegNullableFields = CRMIdeal.Classes.Helper.Setting.GetRegNullableFieldsByTitleJson(cRMspSelectFoSetting_Result.RegNullableFields);
			}
			else
			{
				cRMspSelectFoSetting_Result = new CRMspSelectFoSetting_Result();
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
		JsonResult jsonResult = Json(cRMspSelectFoSetting_Result, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetFoDefaultCnvsStatusGroups(int cnvsStatusGroupId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CRMspSelectFODefaultCnvsStatusGroups_Result cRMspSelectFODefaultCnvsStatusGroups_Result = new CRMspSelectFODefaultCnvsStatusGroups_Result();
		try
		{
			cRMspSelectFODefaultCnvsStatusGroups_Result = Enumerable.FirstOrDefault<CRMspSelectFODefaultCnvsStatusGroups_Result>((IEnumerable<CRMspSelectFODefaultCnvsStatusGroups_Result>)db.CRMspSelectFODefaultCnvsStatusGroups(cnvsStatusGroupId, lCID, result));
			if (cRMspSelectFODefaultCnvsStatusGroups_Result == null)
			{
				cRMspSelectFODefaultCnvsStatusGroups_Result = new CRMspSelectFODefaultCnvsStatusGroups_Result();
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
		JsonResult jsonResult = Json(cRMspSelectFODefaultCnvsStatusGroups_Result, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetFoDefaultUserDepartmentTicket(int departmentId)
	{
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		CRMspSelectFODefaultUserDepartmentTicket_Result cRMspSelectFODefaultUserDepartmentTicket_Result = new CRMspSelectFODefaultUserDepartmentTicket_Result();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			cRMspSelectFODefaultUserDepartmentTicket_Result = Enumerable.FirstOrDefault<CRMspSelectFODefaultUserDepartmentTicket_Result>((IEnumerable<CRMspSelectFODefaultUserDepartmentTicket_Result>)db.CRMspSelectFODefaultUserDepartmentTicket(departmentId, currLangID, result));
			if (cRMspSelectFODefaultUserDepartmentTicket_Result == null)
			{
				cRMspSelectFODefaultUserDepartmentTicket_Result = new CRMspSelectFODefaultUserDepartmentTicket_Result();
			}
			else
			{
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrWhiteSpace(cRMspSelectFODefaultUserDepartmentTicket_Result.TicketFooterText_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(cRMspSelectFODefaultUserDepartmentTicket_Result.TicketFooterText_Lang);
				}
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CommonMultiLanguageViewModel, CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, CommonMultiLanguageViewModel>)((CommonMultiLanguageViewModel item) => new CommonMultiLanguageViewModel
				{
					Value = item.Value,
					LanguageId = item.LanguageId
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = cRMspSelectFODefaultUserDepartmentTicket_Result.TicketFooterText,
					LanguageId = result
				});
				cRMspSelectFODefaultUserDepartmentTicket_Result.TicketFooterText = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
				cRMspSelectFODefaultUserDepartmentTicket_Result.TicketFooterText_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
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
		JsonResult jsonResult = Json(cRMspSelectFODefaultUserDepartmentTicket_Result, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actFoSetting")]
	public ActionResult InsertEdit_Old()
	{
		_003C_003Ec__DisplayClass30_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass30_0();
		GetPresentationList();
		GetcmpTypeList();
		GetcmpGroupList();
		GetcmpGroupIIList();
		GetcmpGroupIIList();
		GetcmpGroupIIIList();
		GetcmpGroupIVList();
		GetCmpReferUser();
		GetStatusGroups();
		GetprjPriorityList();
		GetprjGradeList();
		GetprjGroupList();
		GetprjStartUserist();
		GetcnvsPriorityList();
		GetTopicList();
		GetCnvsUserList();
		GetCnvsReferUserList();
		GetEmailSettingList();
		GetEmailList();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		CS_0024_003C_003E8__locals0.cId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId.GetValueOrDefault() : 0);
		CrmFoSettingLanguageViewModel crmFoSettingLanguageViewModel = new CrmFoSettingLanguageViewModel();
		DateTime now = DateTime.Now;
		try
		{
			IEnumerable<CrmFoSetting_Lang> enumerable = Enumerable.Where<CrmFoSetting_Lang>((IEnumerable<CrmFoSetting_Lang>)Enumerable.ToList<CrmFoSetting_Lang>((IEnumerable<CrmFoSetting_Lang>)_dbTbl.CrmFoSetting_Lang), (Func<CrmFoSetting_Lang, bool>)((CrmFoSetting_Lang x) => x.CrmFoSetting.CId == CS_0024_003C_003E8__locals0.cId));
			CrmFoSetting crmFoSetting = new CrmFoSetting();
			DbSet<CrmFoSetting> crmFoSetting2 = _dbTbl.CrmFoSetting;
			ParameterExpression val = Expression.Parameter(typeof(CrmFoSetting), "x");
			crmFoSetting = Queryable.FirstOrDefault<CrmFoSetting>((IQueryable<CrmFoSetting>)crmFoSetting2, Expression.Lambda<Func<CrmFoSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Convert((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass30_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), typeof(int?))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmFoSetting == null)
			{
				crmFoSetting = new CrmFoSetting
				{
					FoSettingId = 0,
					UserId = UserLogin.CurrentUser.UserId,
					FirstRegisterUserId = UserLogin.CurrentUser.UserId,
					RegisterDate = now,
					FirstRegisterDate = now
				};
			}
			List<CommonMultiLanguageViewModel> list = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.PrjDefaultTitle,
				LanguageId = item.LanguageID
			})));
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = crmFoSetting.PrjDefaultTitle,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.PrjDefaultPostFix,
				LanguageId = item.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = crmFoSetting.PrjDefaultPostFix,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.CnvsDefaultDesc,
				LanguageId = item.LanguageID
			})));
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = crmFoSetting.CnvsDefaultDesc,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.CnvsDefaultReferDesc,
				LanguageId = item.LanguageID
			})));
			list4.Add(new CommonMultiLanguageViewModel
			{
				Value = crmFoSetting.CnvsDefaultReferDesc,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list5 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.CnvsDescTooltip,
				LanguageId = item.LanguageID
			})));
			list5.Add(new CommonMultiLanguageViewModel
			{
				Value = crmFoSetting.CnvsDescTooltip,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list6 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.TicketDescTooltip,
				LanguageId = item.LanguageID
			})));
			list6.Add(new CommonMultiLanguageViewModel
			{
				Value = crmFoSetting.TicketDescTooltip,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list7 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.TicketSubjectDefaultContext,
				LanguageId = item.LanguageID
			})));
			list7.Add(new CommonMultiLanguageViewModel
			{
				Value = crmFoSetting.TicketSubjectDefaultContext,
				LanguageId = result
			});
			crmFoSettingLanguageViewModel = new CrmFoSettingLanguageViewModel
			{
				FoSettingId = crmFoSetting.FoSettingId,
				CmpDefaultGroupId = crmFoSetting.CmpDefaultGroupId,
				CmpDefaultSubGroupId = crmFoSetting.CmpDefaultSubGroupId,
				CmpDefaultGroupIdII = crmFoSetting.CmpDefaultGroupIdII,
				CmpDefaultGroupIdIII = crmFoSetting.CmpDefaultGroupIdIII,
				CmpDefaultGroupIdIV = crmFoSetting.CmpDefaultGroupIdIV,
				CmpDefaultTypeId = crmFoSetting.CmpDefaultTypeId,
				CmpDefaultPresentationId = crmFoSetting.CmpDefaultPresentationId,
				CmpDefaultReferUserId = crmFoSetting.CmpDefaultReferUserId,
				PrjDefaultStarterUserId = crmFoSetting.PrjDefaultStarterUserId,
				PrjDefaultGradeId = crmFoSetting.PrjDefaultGradeId,
				PrjDefaultPriorityId = crmFoSetting.PrjDefaultPriorityId,
				PrjDefaultGroupId = crmFoSetting.PrjDefaultGroupId,
				PrjDefaultCnvsStatusGroupId = crmFoSetting.PrjDefaultCnvsStatusGroupId,
				PrjDefaultFOCmpCanSee = crmFoSetting.PrjDefaultFOCmpCanSee,
				PrjInsertCrmProjectsForbiddenFUFDPActive = crmFoSetting.PrjInsertCrmProjectsForbiddenFUFDPActive,
				PrjInsertProjectInformationsDefualtFieldActive = crmFoSetting.PrjInsertProjectInformationsDefualtFieldActive,
				CnvsDefaultTopicId = crmFoSetting.CnvsDefaultTopicId,
				CnvsDefaultUserId = crmFoSetting.CnvsDefaultUserId,
				CnvsDefaultReferUserId = crmFoSetting.CnvsDefaultReferUserId,
				CnvsDefaultStatusId = crmFoSetting.CnvsDefaultStatusId,
				CnvsDefaultPriorityId = crmFoSetting.CnvsDefaultPriorityId,
				EmailSendingIsActive = crmFoSetting.EmailSendingIsActive,
				EmailSettingId = crmFoSetting.EmailSettingId,
				EmailUserInfoId = crmFoSetting.EmailUserInfoId,
				EmailSubjectPatternFormula = crmFoSetting.EmailSubjectPatternFormula,
				EmailBodyPatternFormula = crmFoSetting.EmailBodyPatternFormula,
				SmsSendingIsActive = crmFoSetting.SmsSendingIsActive,
				SmsWebServiceUserName = crmFoSetting.SmsWebServiceUserName,
				SmsWebServicePassword = crmFoSetting.SmsWebServicePassword,
				SmsWebServiceNumber = crmFoSetting.SmsWebServiceNumber,
				SmsWebServiceUrl = crmFoSetting.SmsWebServiceUrl,
				SmsBodyPatternFormula = crmFoSetting.SmsBodyPatternFormula,
				FoLogEmailAdminI = crmFoSetting.FoLogEmailAdminI,
				FoLogEmailAdminII = crmFoSetting.FoLogEmailAdminII,
				PrjDefaultTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				PrjDefaultPostFix = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				CnvsDefaultDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				CnvsDefaultReferDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				PrjDefaultTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				PrjDefaultPostFix_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				CnvsDefaultReferDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				CnvsDefaultDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				UserId = crmFoSetting.UserId,
				FirstRegisterUserId = crmFoSetting.FirstRegisterUserId,
				RegisterDate = crmFoSetting.RegisterDate,
				FirstRegisterDate = crmFoSetting.FirstRegisterDate,
				AppType = crmFoSetting.AppType,
				CnvsDescTooltip = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				CnvsDescTooltip_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				TicketDescTooltip = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				TicketDescTooltip_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				PrdPriceVisible = crmFoSetting.PrdPriceVisible,
				PrdDisplayType = crmFoSetting.PrdDisplayType,
				TicketSubjectDefaultContext = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				TicketSubjectDefaultContext_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				TicketSubjSelectLoadDefaultContext = crmFoSetting.TicketSubjSelectLoadDefaultContext,
				SmsSendByGSM = crmFoSetting.SmsSendByGSM,
				SmsSendByWeb = crmFoSetting.SmsSendByWeb,
				CmpDefUsernameType = crmFoSetting.CmpDefUsernameType,
				CmpDefPasswordType = crmFoSetting.CmpDefPasswordType,
				EmailSmtpUseDefaultCredentials = crmFoSetting.EmailSmtpUseDefaultCredentials,
				EmailSmtpEnableSSL = crmFoSetting.EmailSmtpEnableSSL,
				EmailSmtpPort = crmFoSetting.EmailSmtpPort,
				SmsIsSendedVerification = crmFoSetting.SmsIsSendedVerification,
				SmsVerificationId = crmFoSetting.SmsVerificationId,
				EmailSubjectPatternFormulaSendFoInfo = crmFoSetting.EmailSubjectPatternFormulaSendFoInfo,
				EmailBodyPatternFormulaSendFoInfo = crmFoSetting.EmailBodyPatternFormulaSendFoInfo,
				SmsBodyPatternFormulaSendFoInfo = crmFoSetting.SmsBodyPatternFormulaSendFoInfo,
				SmsBodyPatternFormulaForgetPassword = crmFoSetting.SmsBodyPatternFormulaForgetPassword,
				CmpDefFOActiveType = crmFoSetting.CmpDefFOActiveType,
				SmsBodyPatternFormulaOTP = crmFoSetting.SmsBodyPatternFormulaOTP,
				FoAdminUserIds = crmFoSetting.FoAdminUserIds
			};
			if (!string.IsNullOrEmpty(crmFoSettingLanguageViewModel.TicketSubjectDefaultContext))
			{
				crmFoSettingLanguageViewModel.TicketSubjectDefaultContextExtra = crmFoSettingLanguageViewModel.TicketSubjectDefaultContext.Replace("|#|", ",");
			}
			else
			{
				crmFoSettingLanguageViewModel.TicketSubjectDefaultContextExtra = "";
			}
			if (!string.IsNullOrWhiteSpace(crmFoSettingLanguageViewModel.FoAdminUserIds))
			{
				List<CRMspSelectUsersByIds_Result> list8 = CRMIdeal.Classes.Helper.User.SelectUsersByIds(crmFoSettingLanguageViewModel.FoAdminUserIds);
				if (list8 != null && Enumerable.Any<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list8))
				{
					crmFoSettingLanguageViewModel.FoAdminUsers = "";
					foreach (CRMspSelectUsersByIds_Result item in list8)
					{
						if (!string.IsNullOrWhiteSpace(item.FullName))
						{
							if (!string.IsNullOrWhiteSpace(crmFoSettingLanguageViewModel.FoAdminUsers))
							{
								crmFoSettingLanguageViewModel.FoAdminUsers += ",";
							}
							crmFoSettingLanguageViewModel.FoAdminUsers += item.FullName;
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		SetRegisterInfo(crmFoSettingLanguageViewModel);
		return View(crmFoSettingLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult InsertEdit_Old(CrmFoSettingLanguageViewModel model)
	{
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_0296: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_033e: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass31_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass31_0();
		CS_0024_003C_003E8__locals0.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		GetPresentationList();
		GetcmpTypeList();
		GetcmpGroupList();
		GetcmpGroupIIList();
		GetcmpGroupIIList();
		GetcmpGroupIIIList();
		GetcmpGroupIVList();
		GetCmpReferUser();
		GetStatusGroups();
		GetprjPriorityList();
		GetprjGradeList();
		GetprjGroupList();
		GetprjStartUserist();
		GetcnvsPriorityList();
		GetTopicList();
		GetCnvsUserList();
		GetCnvsReferUserList();
		GetEmailSettingList();
		GetEmailList();
		string text = "";
		int countError = 0;
		try
		{
			if (base.ModelState.IsValid)
			{
				if (CS_0024_003C_003E8__locals0.model.CmpDefaultSubGroupId == 0)
				{
					CS_0024_003C_003E8__locals0.model.CmpDefaultSubGroupId = null;
				}
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.PrjDefaultTitle_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.PrjDefaultTitle_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.PrjDefaultTitle,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.PrjDefaultPostFix_Lang))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.PrjDefaultPostFix_Lang);
				}
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.PrjDefaultPostFix,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.CnvsDefaultDesc_Lang))
				{
					list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.CnvsDefaultDesc_Lang);
				}
				list3.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.CnvsDefaultDesc,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.CnvsDefaultReferDesc_Lang))
				{
					list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.CnvsDefaultReferDesc_Lang);
				}
				list4.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.CnvsDefaultReferDesc,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.CnvsDescTooltip_Lang))
				{
					list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.CnvsDescTooltip_Lang);
				}
				list5.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.CnvsDescTooltip,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.TicketDescTooltip_Lang))
				{
					list6 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.TicketDescTooltip_Lang);
				}
				list6.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.TicketDescTooltip,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list7 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.TicketSubjectDefaultContext_Lang))
				{
					list7 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.TicketSubjectDefaultContext_Lang);
				}
				list7.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.TicketSubjectDefaultContext,
					LanguageId = lCID
				});
				text = ChkBeforeSubmitFoSetting(CS_0024_003C_003E8__locals0.model, list, list3, ref countError);
				if (countError == 0)
				{
					DateTime now = DateTime.Now;
					CrmFoSetting crmFoSetting = new CrmFoSetting();
					if (CS_0024_003C_003E8__locals0.model.FoSettingId > 0)
					{
						DbSet<CrmFoSetting> crmFoSetting2 = _dbTbl.CrmFoSetting;
						ParameterExpression val = Expression.Parameter(typeof(CrmFoSetting), "m");
						crmFoSetting = Queryable.FirstOrDefault<CrmFoSetting>((IQueryable<CrmFoSetting>)crmFoSetting2, Expression.Lambda<Func<CrmFoSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass31_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					}
					else
					{
						crmFoSetting = new CrmFoSetting();
					}
					if (crmFoSetting != null)
					{
						crmFoSetting.CmpDefaultGroupId = CS_0024_003C_003E8__locals0.model.CmpDefaultGroupId;
						crmFoSetting.CmpDefaultSubGroupId = CS_0024_003C_003E8__locals0.model.CmpDefaultSubGroupId;
						crmFoSetting.CmpDefaultGroupIdII = CS_0024_003C_003E8__locals0.model.CmpDefaultGroupIdII;
						crmFoSetting.CmpDefaultGroupIdIII = CS_0024_003C_003E8__locals0.model.CmpDefaultGroupIdIII;
						crmFoSetting.CmpDefaultGroupIdIV = CS_0024_003C_003E8__locals0.model.CmpDefaultGroupIdIV;
						crmFoSetting.CmpDefaultTypeId = CS_0024_003C_003E8__locals0.model.CmpDefaultTypeId;
						crmFoSetting.CmpDefaultPresentationId = CS_0024_003C_003E8__locals0.model.CmpDefaultPresentationId;
						crmFoSetting.CmpDefaultReferUserId = CS_0024_003C_003E8__locals0.model.CmpDefaultReferUserId;
						crmFoSetting.PrjDefaultStarterUserId = CS_0024_003C_003E8__locals0.model.PrjDefaultStarterUserId;
						crmFoSetting.PrjDefaultGradeId = CS_0024_003C_003E8__locals0.model.PrjDefaultGradeId;
						crmFoSetting.PrjDefaultPriorityId = CS_0024_003C_003E8__locals0.model.PrjDefaultPriorityId;
						crmFoSetting.PrjDefaultGroupId = CS_0024_003C_003E8__locals0.model.PrjDefaultGroupId;
						crmFoSetting.PrjDefaultCnvsStatusGroupId = CS_0024_003C_003E8__locals0.model.PrjDefaultCnvsStatusGroupId;
						crmFoSetting.PrjDefaultFOCmpCanSee = CS_0024_003C_003E8__locals0.model.PrjDefaultFOCmpCanSee;
						crmFoSetting.PrjInsertCrmProjectsForbiddenFUFDPActive = CS_0024_003C_003E8__locals0.model.PrjInsertCrmProjectsForbiddenFUFDPActive;
						crmFoSetting.PrjInsertProjectInformationsDefualtFieldActive = CS_0024_003C_003E8__locals0.model.PrjInsertProjectInformationsDefualtFieldActive;
						crmFoSetting.CnvsDefaultTopicId = CS_0024_003C_003E8__locals0.model.CnvsDefaultTopicId;
						crmFoSetting.CnvsDefaultUserId = CS_0024_003C_003E8__locals0.model.CnvsDefaultUserId;
						crmFoSetting.CnvsDefaultReferUserId = CS_0024_003C_003E8__locals0.model.CnvsDefaultReferUserId;
						crmFoSetting.CnvsDefaultStatusId = CS_0024_003C_003E8__locals0.model.CnvsDefaultStatusId;
						crmFoSetting.CnvsDefaultPriorityId = CS_0024_003C_003E8__locals0.model.CnvsDefaultPriorityId;
						crmFoSetting.EmailSendingIsActive = CS_0024_003C_003E8__locals0.model.EmailSendingIsActive;
						crmFoSetting.EmailSettingId = CS_0024_003C_003E8__locals0.model.EmailSettingId;
						crmFoSetting.EmailUserInfoId = CS_0024_003C_003E8__locals0.model.EmailUserInfoId;
						crmFoSetting.EmailSubjectPatternFormula = CS_0024_003C_003E8__locals0.model.EmailSubjectPatternFormula;
						crmFoSetting.EmailBodyPatternFormula = CS_0024_003C_003E8__locals0.model.EmailBodyPatternFormula;
						crmFoSetting.EmailSubjectPatternFormulaSendFoInfo = CS_0024_003C_003E8__locals0.model.EmailSubjectPatternFormulaSendFoInfo;
						crmFoSetting.EmailBodyPatternFormulaSendFoInfo = CS_0024_003C_003E8__locals0.model.EmailBodyPatternFormulaSendFoInfo;
						crmFoSetting.SmsBodyPatternFormulaSendFoInfo = CS_0024_003C_003E8__locals0.model.SmsBodyPatternFormulaSendFoInfo;
						crmFoSetting.SmsBodyPatternFormulaForgetPassword = CS_0024_003C_003E8__locals0.model.SmsBodyPatternFormulaForgetPassword;
						crmFoSetting.SmsSendingIsActive = CS_0024_003C_003E8__locals0.model.SmsSendingIsActive;
						crmFoSetting.SmsWebServiceUserName = CS_0024_003C_003E8__locals0.model.SmsWebServiceUserName;
						crmFoSetting.SmsWebServicePassword = CS_0024_003C_003E8__locals0.model.SmsWebServicePassword;
						crmFoSetting.SmsWebServiceNumber = CS_0024_003C_003E8__locals0.model.SmsWebServiceNumber;
						crmFoSetting.SmsWebServiceUrl = CS_0024_003C_003E8__locals0.model.SmsWebServiceUrl;
						crmFoSetting.SmsBodyPatternFormula = CS_0024_003C_003E8__locals0.model.SmsBodyPatternFormula;
						crmFoSetting.FoLogEmailAdminI = CS_0024_003C_003E8__locals0.model.FoLogEmailAdminI;
						crmFoSetting.FoLogEmailAdminII = CS_0024_003C_003E8__locals0.model.FoLogEmailAdminII;
						crmFoSetting.UserId = UserLogin.CurrentUser.UserId;
						crmFoSetting.RegisterDate = now;
						crmFoSetting.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						crmFoSetting.Year1 = short.Parse(Financial.Get().Id.ToString());
						crmFoSetting.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
						crmFoSetting.AppType = Configuration.AppType;
						crmFoSetting.PrjDefaultTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmFoSetting.PrjDefaultPostFix = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmFoSetting.CnvsDefaultDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmFoSetting.CnvsDefaultReferDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmFoSetting.SmsSendByGSM = CS_0024_003C_003E8__locals0.model.SmsSendByGSM;
						crmFoSetting.SmsSendByWeb = CS_0024_003C_003E8__locals0.model.SmsSendByWeb;
						if (CS_0024_003C_003E8__locals0.model.CmpDefUsernameType.GetValueOrDefault() == -1)
						{
							crmFoSetting.CmpDefUsernameType = null;
						}
						else
						{
							crmFoSetting.CmpDefUsernameType = CS_0024_003C_003E8__locals0.model.CmpDefUsernameType;
						}
						if (CS_0024_003C_003E8__locals0.model.CmpDefPasswordType.GetValueOrDefault() == -1)
						{
							crmFoSetting.CmpDefPasswordType = null;
						}
						else
						{
							crmFoSetting.CmpDefPasswordType = CS_0024_003C_003E8__locals0.model.CmpDefPasswordType;
						}
						crmFoSetting.EmailSmtpUseDefaultCredentials = CS_0024_003C_003E8__locals0.model.EmailSmtpUseDefaultCredentials;
						crmFoSetting.EmailSmtpEnableSSL = CS_0024_003C_003E8__locals0.model.EmailSmtpEnableSSL;
						crmFoSetting.EmailSmtpPort = CS_0024_003C_003E8__locals0.model.EmailSmtpPort;
						crmFoSetting.SmsIsSendedVerification = CS_0024_003C_003E8__locals0.model.SmsIsSendedVerification;
						crmFoSetting.SmsVerificationId = CS_0024_003C_003E8__locals0.model.SmsVerificationId;
						crmFoSetting.CmpDefFOActiveType = CS_0024_003C_003E8__locals0.model.CmpDefFOActiveType;
						crmFoSetting.SmsBodyPatternFormulaOTP = CS_0024_003C_003E8__locals0.model.SmsBodyPatternFormulaOTP;
						crmFoSetting.FoAdminUserIds = CS_0024_003C_003E8__locals0.model.FoAdminUserIds;
						if (CS_0024_003C_003E8__locals0.model.FoSettingId > 0)
						{
							_dbTbl.Entry(crmFoSetting).State = EntityState.Modified;
							_dbTbl.SaveChanges();
							using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									_003C_003Ec__DisplayClass31_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass31_1();
									CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
									CS_0024_003C_003E8__locals1.lang = enumerator.Current;
									DbSet<CrmFoSetting_Lang> crmFoSetting_Lang = _dbTbl.CrmFoSetting_Lang;
									ParameterExpression val = Expression.Parameter(typeof(CrmFoSetting_Lang), "c");
									CrmFoSetting_Lang crmFoSetting_Lang2 = Queryable.FirstOrDefault<CrmFoSetting_Lang>((IQueryable<CrmFoSetting_Lang>)crmFoSetting_Lang, Expression.Lambda<Func<CrmFoSetting_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass31_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Convert((Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass31_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), typeof(int?)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
									if (crmFoSetting_Lang2 != null)
									{
										crmFoSetting_Lang2.PrjDefaultTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										crmFoSetting_Lang2.PrjDefaultPostFix = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										crmFoSetting_Lang2.CnvsDefaultDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										crmFoSetting_Lang2.CnvsDefaultReferDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										_dbTbl.Entry(crmFoSetting_Lang2).State = EntityState.Modified;
										_dbTbl.SaveChanges();
										continue;
									}
									crmFoSetting_Lang2 = new CrmFoSetting_Lang
									{
										PrjDefaultTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
										PrjDefaultPostFix = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
										CnvsDefaultDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
										CnvsDefaultReferDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
										LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
										FoSettingId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.FoSettingId
									};
									_dbTbl.CrmFoSetting_Lang.Add(crmFoSetting_Lang2);
									_dbTbl.SaveChanges();
								}
							}
							base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
						}
						else
						{
							crmFoSetting.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
							crmFoSetting.FirstRegisterDate = now;
							crmFoSetting.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
							crmFoSetting.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
							crmFoSetting.GUId = Guid.NewGuid();
							_dbTbl.CrmFoSetting.Add(crmFoSetting);
							_dbTbl.SaveChanges();
							if (crmFoSetting.FoSettingId > 0)
							{
								foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
								{
									CrmFoSetting_Lang entity = new CrmFoSetting_Lang
									{
										PrjDefaultTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
										PrjDefaultPostFix = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
										CnvsDefaultDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
										CnvsDefaultReferDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
										LanguageID = lang.LanguageID,
										FoSettingId = crmFoSetting.FoSettingId
									};
									_dbTbl.CrmFoSetting_Lang.Add(entity);
									_dbTbl.SaveChanges();
								}
							}
							base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
						}
						new FilesManager();
						new FacadeFTP(Configuration.FacadeFtpFo);
						string pathFtpFo = Configuration.PathFtpFo;
						string userNameFtpFo = Configuration.UserNameFtpFo;
						string passwordFtpFo = Configuration.PasswordFtpFo;
						bool usePassiveFtpFo = Configuration.UsePassiveFtpFo;
						if (!string.IsNullOrEmpty(pathFtpFo) && !string.IsNullOrEmpty(userNameFtpFo) && !string.IsNullOrEmpty(passwordFtpFo))
						{
							try
							{
								List<CommonMultiLanguageViewModel> list8 = new List<CommonMultiLanguageViewModel>();
								list8.Add(new CommonMultiLanguageViewModel
								{
									Value = CS_0024_003C_003E8__locals0.model.EmailBodyPatternFormula,
									LanguageId = lCID
								});
								List<CommonMultiLanguageViewModel> list9 = new List<CommonMultiLanguageViewModel>();
								list9.Add(new CommonMultiLanguageViewModel
								{
									Value = CS_0024_003C_003E8__locals0.model.EmailBodyPatternFormulaSendFoInfo,
									LanguageId = lCID
								});
								if (list8 != null)
								{
									Files.UploadPicFromEditorToFtp(pathFtpFo, userNameFtpFo, passwordFtpFo, usePassiveFtpFo, list8);
								}
								if (list9 != null)
								{
									Files.UploadPicFromEditorToFtp(pathFtpFo, userNameFtpFo, passwordFtpFo, usePassiveFtpFo, list9);
								}
							}
							catch (Exception e)
							{
								ErrorSignal.FromCurrentContext().Raise(e);
							}
						}
						CS_0024_003C_003E8__locals0.model.UserId = crmFoSetting.UserId;
						CS_0024_003C_003E8__locals0.model.FirstRegisterUserId = crmFoSetting.FirstRegisterUserId;
						CS_0024_003C_003E8__locals0.model.RegisterDate = crmFoSetting.RegisterDate;
						CS_0024_003C_003E8__locals0.model.FirstRegisterDate = crmFoSetting.FirstRegisterDate;
						CS_0024_003C_003E8__locals0.model.AppType = crmFoSetting.AppType;
					}
					else
					{
						text = Messages.ErrorNotFound;
					}
				}
			}
			else
			{
				text = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
		}
		catch (DbEntityValidationException e2)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e2);
			text = Messages.frmErrorMessage;
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
			text = Messages.frmErrorMessage;
		}
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.TicketSubjectDefaultContext))
		{
			CS_0024_003C_003E8__locals0.model.TicketSubjectDefaultContextExtra = CS_0024_003C_003E8__locals0.model.TicketSubjectDefaultContext.Replace("|#|", ",");
		}
		else
		{
			CS_0024_003C_003E8__locals0.model.TicketSubjectDefaultContextExtra = "";
		}
		base.ViewBag.Error = text;
		SetRegisterInfo(CS_0024_003C_003E8__locals0.model);
		return View(CS_0024_003C_003E8__locals0.model);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actFoSetting")]
	public ActionResult InsertEdit(int foSettingRegisterId = 0, int foSettingId = 0, int cmpKind = 0)
	{
		GetPresentationList();
		GetcmpTypeList();
		GetcmpGroupList();
		GetcmpGroupIIList();
		GetcmpGroupIIList();
		GetcmpGroupIIIList();
		GetcmpGroupIVList();
		GetCmpReferUser();
		GetStatusGroups();
		GetprjPriorityList();
		GetprjGradeList();
		GetprjGroupList();
		GetprjStartUserist();
		GetcnvsPriorityList();
		GetTopicList();
		GetCnvsUserList();
		GetCnvsReferUserList();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int? num = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
		CRMspSelectFoSettingRegisterWithId_Result cRMspSelectFoSettingRegisterWithId_Result = new CRMspSelectFoSettingRegisterWithId_Result();
		try
		{
			CRMspSelectFoSettingRegisterWithId_Result cRMspSelectFoSettingRegisterWithId_Result2 = Enumerable.FirstOrDefault<CRMspSelectFoSettingRegisterWithId_Result>((IEnumerable<CRMspSelectFoSettingRegisterWithId_Result>)_dbII.CRMspSelectFoSettingRegisterWithId(foSettingRegisterId, lCID, result));
			if (cRMspSelectFoSettingRegisterWithId_Result2 != null)
			{
				cRMspSelectFoSettingRegisterWithId_Result = cRMspSelectFoSettingRegisterWithId_Result2;
			}
			else
			{
				cRMspSelectFoSettingRegisterWithId_Result.CId = num.GetValueOrDefault();
				cRMspSelectFoSettingRegisterWithId_Result.CmpKind = cmpKind;
				cRMspSelectFoSettingRegisterWithId_Result.FoSettingId = foSettingId;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(cRMspSelectFoSettingRegisterWithId_Result);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult InsertEdit(CRMspSelectFoSettingRegisterWithId_Result model)
	{
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass33_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass33_0();
		CS_0024_003C_003E8__locals0.model = model;
		int userId = UserLogin.CurrentUser.UserId;
		DateTime now = DateTime.Now;
		DateTime dateTime = now;
		string text = now.ToString("yyyyMMdd", new PersianCulture());
		short year = short.Parse(Financial.Get().Id.ToString());
		short month = short.Parse(now.ToString("MM", new PersianCulture()));
		string appType = Configuration.AppType;
		int? cId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		GetPresentationList();
		GetcmpTypeList();
		GetcmpGroupList();
		GetcmpGroupIIList();
		GetcmpGroupIIList();
		GetcmpGroupIIIList();
		GetcmpGroupIVList();
		GetCmpReferUser();
		GetStatusGroups();
		GetprjPriorityList();
		GetprjGradeList();
		GetprjGroupList();
		GetprjStartUserist();
		GetcnvsPriorityList();
		GetTopicList();
		GetCnvsUserList();
		GetCnvsReferUserList();
		string text2 = "";
		int countError = 0;
		try
		{
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.PrjDefaultTitle_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.PrjDefaultTitle_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.PrjDefaultTitle,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.PrjDefaultPostFix_Lang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.PrjDefaultPostFix_Lang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.PrjDefaultPostFix,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.CnvsDefaultDesc_Lang))
			{
				list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.CnvsDefaultDesc_Lang);
			}
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.CnvsDefaultDesc,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.CnvsDefaultReferDesc_Lang))
			{
				list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.CnvsDefaultReferDesc_Lang);
			}
			list4.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.CnvsDefaultReferDesc,
				LanguageId = lCID
			});
			text2 = ChkBeforeSubmitFoSettingRegister(CS_0024_003C_003E8__locals0.model, list, list3, ref countError);
			if (CS_0024_003C_003E8__locals0.model.FoSettingRegisterId == 0 && CS_0024_003C_003E8__locals0.model.FoSettingId == 0)
			{
				CrmFoSetting crmFoSetting = new CrmFoSetting();
				crmFoSetting.CId = cId;
				crmFoSetting.CmpDefaultReferUserId = CS_0024_003C_003E8__locals0.model.CmpDefaultReferUserId;
				crmFoSetting.PrjDefaultTitle = CS_0024_003C_003E8__locals0.model.PrjDefaultTitle;
				crmFoSetting.PrjDefaultStarterUserId = CS_0024_003C_003E8__locals0.model.PrjDefaultStarterUserId;
				crmFoSetting.PrjDefaultCnvsStatusGroupId = CS_0024_003C_003E8__locals0.model.PrjDefaultCnvsStatusGroupId;
				crmFoSetting.CnvsDefaultTopicId = CS_0024_003C_003E8__locals0.model.CnvsDefaultTopicId;
				crmFoSetting.CnvsDefaultDesc = CS_0024_003C_003E8__locals0.model.CnvsDefaultDesc;
				crmFoSetting.CnvsDefaultUserId = CS_0024_003C_003E8__locals0.model.CnvsDefaultUserId;
				crmFoSetting.CnvsDefaultReferUserId = CS_0024_003C_003E8__locals0.model.CnvsDefaultReferUserId;
				crmFoSetting.CnvsDefaultStatusId = CS_0024_003C_003E8__locals0.model.CnvsDefaultStatusId;
				crmFoSetting.FirstRegisterUserId = userId;
				crmFoSetting.FirstRegisterDate = dateTime;
				crmFoSetting.FirstRegisterDatePersian = text;
				crmFoSetting.UserId = userId;
				crmFoSetting.RegisterDate = dateTime;
				crmFoSetting.RegisterDatePersian = text;
				crmFoSetting.Year1 = year;
				crmFoSetting.Month1 = month;
				crmFoSetting.AppType = appType;
				crmFoSetting.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
				crmFoSetting.GUId = Guid.NewGuid();
				_dbTbl.CrmFoSetting.Add(crmFoSetting);
				_dbTbl.SaveChanges();
				CS_0024_003C_003E8__locals0.model.FoSettingId = crmFoSetting.FoSettingId;
				CS_0024_003C_003E8__locals0.model.CId = cId.GetValueOrDefault();
			}
			if (CS_0024_003C_003E8__locals0.model.CmpDefaultSubGroupId == 0)
			{
				CS_0024_003C_003E8__locals0.model.CmpDefaultSubGroupId = null;
			}
			if (countError == 0)
			{
				CrmFoSettingRegister crmFoSettingRegister = new CrmFoSettingRegister();
				if (CS_0024_003C_003E8__locals0.model.FoSettingRegisterId > 0)
				{
					DbSet<CrmFoSettingRegister> crmFoSettingRegister2 = _dbTbl.CrmFoSettingRegister;
					ParameterExpression val = Expression.Parameter(typeof(CrmFoSettingRegister), "m");
					crmFoSettingRegister = Queryable.FirstOrDefault<CrmFoSettingRegister>((IQueryable<CrmFoSettingRegister>)crmFoSettingRegister2, Expression.Lambda<Func<CrmFoSettingRegister, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass33_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				else
				{
					crmFoSettingRegister = new CrmFoSettingRegister();
					crmFoSettingRegister.CId = cId.GetValueOrDefault();
				}
				if (crmFoSettingRegister != null)
				{
					crmFoSettingRegister.CmpDefaultGroupId = CS_0024_003C_003E8__locals0.model.CmpDefaultGroupId;
					crmFoSettingRegister.CmpDefaultSubGroupId = CS_0024_003C_003E8__locals0.model.CmpDefaultSubGroupId;
					crmFoSettingRegister.CmpDefaultGroupIdII = CS_0024_003C_003E8__locals0.model.CmpDefaultGroupIdII;
					crmFoSettingRegister.CmpDefaultGroupIdIII = CS_0024_003C_003E8__locals0.model.CmpDefaultGroupIdIII;
					crmFoSettingRegister.CmpDefaultGroupIdIV = CS_0024_003C_003E8__locals0.model.CmpDefaultGroupIdIV;
					crmFoSettingRegister.CmpDefaultTypeId = CS_0024_003C_003E8__locals0.model.CmpDefaultTypeId;
					crmFoSettingRegister.CmpDefaultPresentationId = CS_0024_003C_003E8__locals0.model.CmpDefaultPresentationId;
					crmFoSettingRegister.CmpDefaultReferUserId = CS_0024_003C_003E8__locals0.model.CmpDefaultReferUserId;
					crmFoSettingRegister.PrjDefaultStarterUserId = CS_0024_003C_003E8__locals0.model.PrjDefaultStarterUserId;
					crmFoSettingRegister.PrjDefaultGradeId = CS_0024_003C_003E8__locals0.model.PrjDefaultGradeId;
					crmFoSettingRegister.PrjDefaultPriorityId = CS_0024_003C_003E8__locals0.model.PrjDefaultPriorityId;
					crmFoSettingRegister.PrjDefaultGroupId = CS_0024_003C_003E8__locals0.model.PrjDefaultGroupId;
					crmFoSettingRegister.PrjDefaultCnvsStatusGroupId = CS_0024_003C_003E8__locals0.model.PrjDefaultCnvsStatusGroupId;
					crmFoSettingRegister.PrjDefaultFOCmpCanSee = CS_0024_003C_003E8__locals0.model.PrjDefaultFOCmpCanSee;
					crmFoSettingRegister.PrjInsertCrmProjectsForbiddenFUFDPActive = CS_0024_003C_003E8__locals0.model.PrjInsertCrmProjectsForbiddenFUFDPActive;
					crmFoSettingRegister.PrjInsertProjectInformationsDefualtFieldActive = CS_0024_003C_003E8__locals0.model.PrjInsertProjectInformationsDefualtFieldActive;
					crmFoSettingRegister.CnvsDefaultTopicId = CS_0024_003C_003E8__locals0.model.CnvsDefaultTopicId;
					crmFoSettingRegister.CnvsDefaultUserId = CS_0024_003C_003E8__locals0.model.CnvsDefaultUserId;
					crmFoSettingRegister.CnvsDefaultReferUserId = CS_0024_003C_003E8__locals0.model.CnvsDefaultReferUserId;
					crmFoSettingRegister.CnvsDefaultStatusId = CS_0024_003C_003E8__locals0.model.CnvsDefaultStatusId;
					crmFoSettingRegister.CnvsDefaultStatusResultId = CS_0024_003C_003E8__locals0.model.CnvsDefaultStatusResultId;
					crmFoSettingRegister.CnvsDefaultPriorityId = CS_0024_003C_003E8__locals0.model.CnvsDefaultPriorityId;
					crmFoSettingRegister.CmpKind = CS_0024_003C_003E8__locals0.model.CmpKind;
					crmFoSettingRegister.UserId = UserLogin.CurrentUser.UserId;
					crmFoSettingRegister.RegisterDate = now;
					crmFoSettingRegister.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					crmFoSettingRegister.Year1 = short.Parse(Financial.Get().Id.ToString());
					crmFoSettingRegister.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
					crmFoSettingRegister.AppType = Configuration.AppType;
					crmFoSettingRegister.PrjDefaultTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					crmFoSettingRegister.PrjDefaultPostFix = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					crmFoSettingRegister.CnvsDefaultDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					crmFoSettingRegister.CnvsDefaultReferDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					if (CS_0024_003C_003E8__locals0.model.CmpDefUsernameType.GetValueOrDefault() == -1)
					{
						crmFoSettingRegister.CmpDefUsernameType = null;
					}
					else
					{
						crmFoSettingRegister.CmpDefUsernameType = CS_0024_003C_003E8__locals0.model.CmpDefUsernameType;
					}
					if (CS_0024_003C_003E8__locals0.model.CmpDefPasswordType.GetValueOrDefault() == -1)
					{
						crmFoSettingRegister.CmpDefPasswordType = null;
					}
					else
					{
						crmFoSettingRegister.CmpDefPasswordType = CS_0024_003C_003E8__locals0.model.CmpDefPasswordType;
					}
					crmFoSettingRegister.CmpDefFOActiveType = CS_0024_003C_003E8__locals0.model.CmpDefFOActiveType;
					if (CS_0024_003C_003E8__locals0.model.FoSettingRegisterId > 0)
					{
						_dbTbl.Entry(crmFoSettingRegister).State = EntityState.Modified;
						_dbTbl.SaveChanges();
						using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								_003C_003Ec__DisplayClass33_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass33_1();
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
								CS_0024_003C_003E8__locals1.lang = enumerator.Current;
								DbSet<CrmFoSettingRegister_Lang> crmFoSettingRegister_Lang = _dbTbl.CrmFoSettingRegister_Lang;
								ParameterExpression val = Expression.Parameter(typeof(CrmFoSettingRegister_Lang), "c");
								CrmFoSettingRegister_Lang crmFoSettingRegister_Lang2 = Queryable.FirstOrDefault<CrmFoSettingRegister_Lang>((IQueryable<CrmFoSettingRegister_Lang>)crmFoSettingRegister_Lang, Expression.Lambda<Func<CrmFoSettingRegister_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass33_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass33_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (crmFoSettingRegister_Lang2 != null)
								{
									crmFoSettingRegister_Lang2.PrjDefaultTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									crmFoSettingRegister_Lang2.PrjDefaultPostFix = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									crmFoSettingRegister_Lang2.CnvsDefaultDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									crmFoSettingRegister_Lang2.CnvsDefaultReferDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									_dbTbl.Entry(crmFoSettingRegister_Lang2).State = EntityState.Modified;
									_dbTbl.SaveChanges();
									continue;
								}
								crmFoSettingRegister_Lang2 = new CrmFoSettingRegister_Lang
								{
									PrjDefaultTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
									PrjDefaultPostFix = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
									CnvsDefaultDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
									CnvsDefaultReferDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
									LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
									FoSettingRegisterId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.FoSettingRegisterId
								};
								_dbTbl.CrmFoSettingRegister_Lang.Add(crmFoSettingRegister_Lang2);
								_dbTbl.SaveChanges();
							}
						}
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					}
					else
					{
						crmFoSettingRegister.FoSettingId = CS_0024_003C_003E8__locals0.model.FoSettingId;
						crmFoSettingRegister.FirstRegisterUserId = userId;
						crmFoSettingRegister.FirstRegisterDate = dateTime;
						crmFoSettingRegister.FirstRegisterDatePersian = text;
						crmFoSettingRegister.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
						crmFoSettingRegister.GUId = Guid.NewGuid();
						_dbTbl.CrmFoSettingRegister.Add(crmFoSettingRegister);
						_dbTbl.SaveChanges();
						if (crmFoSettingRegister.FoSettingRegisterId > 0)
						{
							foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
							{
								CrmFoSettingRegister_Lang entity = new CrmFoSettingRegister_Lang
								{
									PrjDefaultTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
									PrjDefaultPostFix = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
									CnvsDefaultDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
									CnvsDefaultReferDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
									LanguageID = lang.LanguageID,
									FoSettingRegisterId = crmFoSettingRegister.FoSettingRegisterId
								};
								_dbTbl.CrmFoSettingRegister_Lang.Add(entity);
								_dbTbl.SaveChanges();
							}
						}
						base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
					}
					CS_0024_003C_003E8__locals0.model.UserId = crmFoSettingRegister.UserId;
					CS_0024_003C_003E8__locals0.model.FirstRegisterUserId = crmFoSettingRegister.FirstRegisterUserId;
					CS_0024_003C_003E8__locals0.model.RegisterDate = crmFoSettingRegister.RegisterDate;
					CS_0024_003C_003E8__locals0.model.FirstRegisterDate = crmFoSettingRegister.FirstRegisterDate;
					CS_0024_003C_003E8__locals0.model.AppType = crmFoSettingRegister.AppType;
				}
				else
				{
					text2 = Messages.ErrorNotFound;
				}
			}
			else
			{
				text2 = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			text2 = Messages.frmErrorMessage;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			text2 = Messages.frmErrorMessage;
		}
		base.ViewBag.Error = text2;
		SetRegisterInfoRegister(CS_0024_003C_003E8__locals0.model);
		return View(CS_0024_003C_003E8__locals0.model);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actFoSetting")]
	public ActionResult EditCnvsSetting()
	{
		GetTopicList();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		int? cId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
		CrmFoCnvsSettingLanguageViewModel model = new CrmFoCnvsSettingLanguageViewModel();
		_ = DateTime.Now;
		try
		{
			string positionTopRightTxt = Labels.PositionTopRightTxt;
			string positionTopCenterTxt = Labels.PositionTopCenterTxt;
			string positionTopLeftTxt = Labels.PositionTopLeftTxt;
			string positionCenterRightTxt = Labels.PositionCenterRightTxt;
			string positionCenterTxt = Labels.PositionCenterTxt;
			string positionCenterLeftTxt = Labels.PositionCenterLeftTxt;
			string positionBottomRightTxt = Labels.PositionBottomRightTxt;
			string positionBottomCenterTxt = Labels.PositionBottomCenterTxt;
			string positionBottomLeftTxt = Labels.PositionBottomLeftTxt;
			_ = Labels.SmsSendByWebTxt;
			_ = Labels.SmsSendByGsmTxt;
			IEnumerable<CrmFoSetting_Lang> enumerable = Enumerable.Where<CrmFoSetting_Lang>((IEnumerable<CrmFoSetting_Lang>)Enumerable.ToList<CrmFoSetting_Lang>((IEnumerable<CrmFoSetting_Lang>)_dbTbl.CrmFoSetting_Lang), (Func<CrmFoSetting_Lang, bool>)((CrmFoSetting_Lang x) => x.CrmFoSetting.CId == cId));
			CRMSpEntities cRMSpEntities = db;
			string foSettingDefDisplay4Column = Labels.FoSettingDefDisplay4Column;
			string foSettingDefDisplay3Column = Labels.FoSettingDefDisplay3Column;
			string foSettingDefDisplayListView = Labels.FoSettingDefDisplayListView;
			string foSettingDefDisplayListViewSmall = Labels.FoSettingDefDisplayListViewSmall;
			int? languageID = result;
			int? defaultLanguageID = result;
			CRMspSelectFoSetting_Result cRMspSelectFoSetting_Result = Enumerable.FirstOrDefault<CRMspSelectFoSetting_Result>((IEnumerable<CRMspSelectFoSetting_Result>)cRMSpEntities.CRMspSelectFoSetting(foSettingDefDisplay4Column, foSettingDefDisplay3Column, foSettingDefDisplayListView, foSettingDefDisplayListViewSmall, positionTopRightTxt, positionTopCenterTxt, positionTopLeftTxt, positionCenterRightTxt, positionCenterTxt, positionCenterLeftTxt, positionBottomRightTxt, positionBottomCenterTxt, positionBottomLeftTxt, languageID, defaultLanguageID, cId));
			if (cRMspSelectFoSetting_Result == null)
			{
				cRMspSelectFoSetting_Result = new CRMspSelectFoSetting_Result
				{
					FoSettingId = 0
				};
			}
			List<CommonMultiLanguageViewModel> list = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.CnvsDescTooltip,
				LanguageId = item.LanguageID
			})));
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = cRMspSelectFoSetting_Result.CnvsDescTooltip,
				LanguageId = result
			});
			model = new CrmFoCnvsSettingLanguageViewModel
			{
				FoSettingId = cRMspSelectFoSetting_Result.FoSettingId,
				CnvsDefaultTopicId = cRMspSelectFoSetting_Result.FODefaultConversationTopicId,
				CnvsDescTooltip = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
				CnvsDescTooltip_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
				FoCanInsCnvs = cRMspSelectFoSetting_Result.FoCanInsCnvs.GetValueOrDefault()
			};
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(model);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult EditCnvsSetting(CrmFoCnvsSettingLanguageViewModel model)
	{
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		try
		{
			GetTopicList();
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.CnvsDescTooltip_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.CnvsDescTooltip_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = model.CnvsDescTooltip,
				LanguageId = lCID
			});
			string text2 = "";
			string cnvsDescTooltip = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : "");
			foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages m) => m.LanguageID != defLangID))))
			{
				string text3 = "";
				text3 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : "");
				text2 = text2 + "[LangId=" + lang.LanguageID + "|,|Txt=" + text3 + "|,|]@";
			}
			if (base.ModelState.IsValid)
			{
				if (num == 0)
				{
					DateTime now = DateTime.Now;
					int userId = UserLogin.CurrentUser.UserId;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value = short.Parse(Financial.Get().Id.ToString());
					short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					_dbI.CRMspUpdateFODefaultCnvsSetting(model.CnvsDefaultTopicId, cnvsDescTooltip, text2, userId, value, value2, now, registerDatePersian, appType, defLangID, model.FoCanInsCnvs, model.FoSettingId);
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
			}
			else
			{
				text = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			text = Messages.frmErrorMessage;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			text = Messages.frmErrorMessage;
		}
		base.ViewBag.Error = text;
		return View(model);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actFoSetting")]
	public ActionResult EditCnvsStatusGroupSetting()
	{
		GetStatusGroups();
		GetUsers(addCmpReferUser: true);
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		CrmFoCnvsSettingLanguageViewModel model = new CrmFoCnvsSettingLanguageViewModel();
		_ = DateTime.Now;
		try
		{
			model = new CrmFoCnvsSettingLanguageViewModel
			{
				FoSettingId = 0
			};
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(model);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult EditCnvsStatusGroupSetting(CrmFoCnvsSettingLanguageViewModel model)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		try
		{
			GetStatusGroups();
			GetUsers(addCmpReferUser: true);
			if (base.ModelState.IsValid)
			{
				if (num == 0)
				{
					DateTime now = DateTime.Now;
					int userId = UserLogin.CurrentUser.UserId;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value = short.Parse(Financial.Get().Id.ToString());
					short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					db.CRMspUpdateFODefaultCnvsStatusGroupSetting(model.CnvsStatusGroupId, model.CnvsStatusId, model.CnvsReferUserId, model.CnvsReferMultiUser, userId, value, value2, now, registerDatePersian, appType, result);
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
			}
			else
			{
				text = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			text = Messages.frmErrorMessage;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			text = Messages.frmErrorMessage;
		}
		base.ViewBag.Error = text;
		return View(model);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actFoSetting")]
	public ActionResult EditShopSetting()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		int? centerId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
		CrmFoShopSettingLanguageViewModel model = new CrmFoShopSettingLanguageViewModel();
		_ = DateTime.Now;
		try
		{
			string positionTopRightTxt = Labels.PositionTopRightTxt;
			string positionTopCenterTxt = Labels.PositionTopCenterTxt;
			string positionTopLeftTxt = Labels.PositionTopLeftTxt;
			string positionCenterRightTxt = Labels.PositionCenterRightTxt;
			string positionCenterTxt = Labels.PositionCenterTxt;
			string positionCenterLeftTxt = Labels.PositionCenterLeftTxt;
			string positionBottomRightTxt = Labels.PositionBottomRightTxt;
			string positionBottomCenterTxt = Labels.PositionBottomCenterTxt;
			string positionBottomLeftTxt = Labels.PositionBottomLeftTxt;
			_ = Labels.SmsSendByWebTxt;
			_ = Labels.SmsSendByGsmTxt;
			CRMSpEntities cRMSpEntities = db;
			string foSettingDefDisplay4Column = Labels.FoSettingDefDisplay4Column;
			string foSettingDefDisplay3Column = Labels.FoSettingDefDisplay3Column;
			string foSettingDefDisplayListView = Labels.FoSettingDefDisplayListView;
			string foSettingDefDisplayListViewSmall = Labels.FoSettingDefDisplayListViewSmall;
			int? languageID = result;
			int? defaultLanguageID = result;
			CRMspSelectFoSetting_Result foSetting = Enumerable.FirstOrDefault<CRMspSelectFoSetting_Result>((IEnumerable<CRMspSelectFoSetting_Result>)cRMSpEntities.CRMspSelectFoSetting(foSettingDefDisplay4Column, foSettingDefDisplay3Column, foSettingDefDisplayListView, foSettingDefDisplayListViewSmall, positionTopRightTxt, positionTopCenterTxt, positionTopLeftTxt, positionCenterRightTxt, positionCenterTxt, positionCenterLeftTxt, positionBottomRightTxt, positionBottomCenterTxt, positionBottomLeftTxt, languageID, defaultLanguageID, centerId));
			if (foSetting == null)
			{
				foSetting = new CRMspSelectFoSetting_Result
				{
					FoSettingId = 0,
					PrdPriceVisible = false
				};
			}
			List<CommonMultiLanguageViewModel> list = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(Enumerable.Where<CrmFoSetting_Lang>((IEnumerable<CrmFoSetting_Lang>)Enumerable.ToList<CrmFoSetting_Lang>((IEnumerable<CrmFoSetting_Lang>)_dbTbl.CrmFoSetting_Lang), (Func<CrmFoSetting_Lang, bool>)((CrmFoSetting_Lang x) => x.FoSettingId == foSetting.FoSettingId)), (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.ShpLinkedPrdLbl,
				LanguageId = item.LanguageID
			})));
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = foSetting.ShpLinkedPrdLbl,
				LanguageId = result
			});
			model = new CrmFoShopSettingLanguageViewModel
			{
				FoSettingId = foSetting.FoSettingId,
				PrdPriceVisible = foSetting.PrdPriceVisible,
				PrdDisplayType = foSetting.PrdDisplayType,
				SHPDefaultPriceGroupId = foSetting.SHPDefaultPriceGroupId,
				PrdFCRVisible = foSetting.PrdFCRVisible,
				PrdPriceWithFCRVisible = foSetting.PrdPriceWithFCRVisible,
				ShpSidebarMenuVisible = foSetting.ShpSidebarMenuVisible,
				PrdPriceInDecimalVisible = foSetting.PrdPriceInDecimalVisible,
				ShpStartWithShop = foSetting.ShpStartWithShop,
				FoShowShopBtn = foSetting.FoShowShopBtn,
				ShpUniqueSaleCenterParentInOrd = foSetting.ShpUniqueSaleCenterParentInOrd,
				ShpLinkedPrdLbl = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
				ShpLinkedPrdLbl_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
				ShpDefLinkAccSettingDBId = foSetting.ShpDefLinkAccSettingDBId
			};
			GetPrdPriceGroupList();
			GetLinkAccHolooDatabases();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(model);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult EditShopSetting(CrmFoShopSettingLanguageViewModel model)
	{
		//IL_0252: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass39_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass39_0();
		CS_0024_003C_003E8__locals0.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		GetPrdPriceGroupList();
		GetLinkAccHolooDatabases();
		try
		{
			if (base.ModelState.IsValid)
			{
				DbSet<CrmFoSetting> crmFoSetting = _dbTbl.CrmFoSetting;
				ParameterExpression val = Expression.Parameter(typeof(CrmFoSetting), "fo");
				CrmFoSetting crmFoSetting2 = Queryable.FirstOrDefault<CrmFoSetting>((IQueryable<CrmFoSetting>)crmFoSetting, Expression.Lambda<Func<CrmFoSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass39_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (crmFoSetting2 != null && (!CS_0024_003C_003E8__locals0.model.ShpDefLinkAccSettingDBId.HasValue || CS_0024_003C_003E8__locals0.model.ShpDefLinkAccSettingDBId == 0) && crmFoSetting2.ShpOrdSendLinkAccAfterIssue.GetValueOrDefault())
				{
					text = Messages.msgErrorFoSettingLinkAccAfterIssueRequiresShpDefDB;
					base.ViewBag.Error = text;
					return View(CS_0024_003C_003E8__locals0.model);
				}
				if (num == 0)
				{
					DateTime now = DateTime.Now;
					int userId = UserLogin.CurrentUser.UserId;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value = short.Parse(Financial.Get().Id.ToString());
					short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					string foSetting_Lang = "";
					List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.ShpLinkedPrdLbl_Lang))
					{
						list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.ShpLinkedPrdLbl_Lang);
					}
					list.Add(new CommonMultiLanguageViewModel
					{
						Value = CS_0024_003C_003E8__locals0.model.ShpLinkedPrdLbl,
						LanguageId = lCID
					});
					string shpLinkedPrdLbl = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : "");
					List<CrmFoSetting_Lang> list2 = new List<CrmFoSetting_Lang>();
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages m) => m.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
					{
						CrmFoSetting_Lang crmFoSetting_Lang = new CrmFoSetting_Lang();
						crmFoSetting_Lang.LanguageID = lang.LanguageID;
						crmFoSetting_Lang.ShpLinkedPrdLbl = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : "");
						list2.Add(crmFoSetting_Lang);
					}
					if (list2 != null && Enumerable.Any<CrmFoSetting_Lang>((IEnumerable<CrmFoSetting_Lang>)list2))
					{
						foSetting_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CrmFoSetting_Lang>((IEnumerable<CrmFoSetting_Lang>)list2));
					}
					_dbI.CRMspUpdateFODefaultShopSetting(CS_0024_003C_003E8__locals0.model.SHPDefaultPriceGroupId, CS_0024_003C_003E8__locals0.model.PrdPriceVisible, CS_0024_003C_003E8__locals0.model.PrdDisplayType, userId, value, value2, now, registerDatePersian, appType, CS_0024_003C_003E8__locals0.defLangID, CS_0024_003C_003E8__locals0.model.ShpSidebarMenuVisible, CS_0024_003C_003E8__locals0.model.PrdFCRVisible, CS_0024_003C_003E8__locals0.model.PrdPriceWithFCRVisible, CS_0024_003C_003E8__locals0.model.PrdPriceInDecimalVisible, CS_0024_003C_003E8__locals0.model.ShpStartWithShop, CS_0024_003C_003E8__locals0.model.FoShowShopBtn, CS_0024_003C_003E8__locals0.model.ShpUniqueSaleCenterParentInOrd, CS_0024_003C_003E8__locals0.model.FoSettingId, shpLinkedPrdLbl, foSetting_Lang, CS_0024_003C_003E8__locals0.model.ShpDefLinkAccSettingDBId);
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
			}
			else
			{
				text = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			text = Messages.frmErrorMessage;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			text = Messages.frmErrorMessage;
		}
		base.ViewBag.Error = text;
		return View(CS_0024_003C_003E8__locals0.model);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actFoSetting")]
	public ActionResult EditTicketSetting()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		int? cId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
		CrmFoTicketSettingLanguageViewModel model = new CrmFoTicketSettingLanguageViewModel();
		_ = DateTime.Now;
		GetStatusGroups();
		GetUserDepartmentList();
		GetTopicList();
		List<SelectListItem> smsProviderList = GetSmsProviderList();
		base.ViewBag.TicketDelaySMSProviders = smsProviderList;
		base.ViewBag.TicketBusySMSProviders = smsProviderList;
		base.ViewBag.TicketUnhappySMSProviders = smsProviderList;
		try
		{
			string positionTopRightTxt = Labels.PositionTopRightTxt;
			string positionTopCenterTxt = Labels.PositionTopCenterTxt;
			string positionTopLeftTxt = Labels.PositionTopLeftTxt;
			string positionCenterRightTxt = Labels.PositionCenterRightTxt;
			string positionCenterTxt = Labels.PositionCenterTxt;
			string positionCenterLeftTxt = Labels.PositionCenterLeftTxt;
			string positionBottomRightTxt = Labels.PositionBottomRightTxt;
			string positionBottomCenterTxt = Labels.PositionBottomCenterTxt;
			string positionBottomLeftTxt = Labels.PositionBottomLeftTxt;
			_ = Labels.SmsSendByWebTxt;
			_ = Labels.SmsSendByGsmTxt;
			IEnumerable<CrmFoSetting_Lang> enumerable = Enumerable.Where<CrmFoSetting_Lang>((IEnumerable<CrmFoSetting_Lang>)Enumerable.ToList<CrmFoSetting_Lang>((IEnumerable<CrmFoSetting_Lang>)_dbTbl.CrmFoSetting_Lang), (Func<CrmFoSetting_Lang, bool>)((CrmFoSetting_Lang x) => x.CrmFoSetting.CId == cId));
			CRMSpEntities cRMSpEntities = db;
			string foSettingDefDisplay4Column = Labels.FoSettingDefDisplay4Column;
			string foSettingDefDisplay3Column = Labels.FoSettingDefDisplay3Column;
			string foSettingDefDisplayListView = Labels.FoSettingDefDisplayListView;
			string foSettingDefDisplayListViewSmall = Labels.FoSettingDefDisplayListViewSmall;
			int? languageID = result;
			int? defaultLanguageID = result;
			CRMspSelectFoSetting_Result cRMspSelectFoSetting_Result = Enumerable.FirstOrDefault<CRMspSelectFoSetting_Result>((IEnumerable<CRMspSelectFoSetting_Result>)cRMSpEntities.CRMspSelectFoSetting(foSettingDefDisplay4Column, foSettingDefDisplay3Column, foSettingDefDisplayListView, foSettingDefDisplayListViewSmall, positionTopRightTxt, positionTopCenterTxt, positionTopLeftTxt, positionCenterRightTxt, positionCenterTxt, positionCenterLeftTxt, positionBottomRightTxt, positionBottomCenterTxt, positionBottomLeftTxt, languageID, defaultLanguageID, cId));
			if (cRMspSelectFoSetting_Result == null)
			{
				cRMspSelectFoSetting_Result = new CRMspSelectFoSetting_Result
				{
					FoSettingId = 0
				};
			}
			List<CommonMultiLanguageViewModel> list = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.TicketDescTooltip,
				LanguageId = item.LanguageID
			})));
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = cRMspSelectFoSetting_Result.TicketDescTooltip,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.TicketSubjectDefaultContext,
				LanguageId = item.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = cRMspSelectFoSetting_Result.TicketSubjectDefaultContext,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.TicketAutoReplyAfterSetDoingTimeDesc,
				LanguageId = item.LanguageID
			})));
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = cRMspSelectFoSetting_Result.TicketAutoReplyAfterSetDoingTimeDesc,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.TicketDelayAllarmMessage,
				LanguageId = item.LanguageID
			})));
			list4.Add(new CommonMultiLanguageViewModel
			{
				Value = cRMspSelectFoSetting_Result.TicketDelayAllarmMessage,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list5 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.TicketBusyAllarmMessage,
				LanguageId = item.LanguageID
			})));
			list5.Add(new CommonMultiLanguageViewModel
			{
				Value = cRMspSelectFoSetting_Result.TicketBusyAllarmMessage,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list6 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.TicketUnhappyAllarmMessage,
				LanguageId = item.LanguageID
			})));
			list6.Add(new CommonMultiLanguageViewModel
			{
				Value = cRMspSelectFoSetting_Result.TicketUnhappyAllarmMessage,
				LanguageId = result
			});
			model = new CrmFoTicketSettingLanguageViewModel
			{
				FoSettingId = cRMspSelectFoSetting_Result.FoSettingId,
				TicketSubjSelectLoadDefaultContext = cRMspSelectFoSetting_Result.TicketSubjSelectLoadDefaultContext,
				TicketDescTooltip = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
				TicketDescTooltip_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
				TicketSubjectDefaultContext = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
				TicketSubjectDefaultContext_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
				TicketCanAddNewSubject = cRMspSelectFoSetting_Result.TicketCanAddNewSubject,
				TicketAllowInCurrntCount = cRMspSelectFoSetting_Result.TicketAllowInCurrntCount,
				TicketAllowAddBeforeAnswerCount = cRMspSelectFoSetting_Result.TicketAllowAddBeforeAnswerCount,
				TicketAutoCloseAfterDay = cRMspSelectFoSetting_Result.TicketAutoCloseAfterDay,
				TicketAddProjectTypeId = cRMspSelectFoSetting_Result.TicketAddProjectTypeId,
				TicketProjectTitleAndTitleGroup = cRMspSelectFoSetting_Result.TicketProjectTitleAndTitleGroup,
				TicketFileAttachCount = cRMspSelectFoSetting_Result.TicketFileAttachCount,
				TicketSendIntMsg = cRMspSelectFoSetting_Result.TicketSendIntMsg,
				TicketFullRemindDate = cRMspSelectFoSetting_Result.TicketFullRemindDate,
				TicketCountCurrentWithStop = cRMspSelectFoSetting_Result.TicketCountCurrentWithStop,
				TicketAutoReplyAfterSetDoingTime = cRMspSelectFoSetting_Result.TicketAutoReplyAfterSetDoingTime,
				TicketAutoReplyAfterSetDoingTimeTopicId = cRMspSelectFoSetting_Result.TicketAutoReplyAfterSetDoingTimeTopicId,
				TicketAutoReplyAfterSetDoingTimeDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
				TicketAutoReplyAfterSetDoingTimeDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
				TicketDelayAllarm = cRMspSelectFoSetting_Result.TicketDelayAllarm,
				TicketDelayAllarmDay = cRMspSelectFoSetting_Result.TicketDelayAllarmDay,
				TicketDelayAllarmTime = cRMspSelectFoSetting_Result.TicketDelayAllarmTime,
				TicketDelayAllarmReceivers = cRMspSelectFoSetting_Result.TicketDelayAllarmReceivers,
				TicketDelayAllarmReceiversName = cRMspSelectFoSetting_Result.TicketDelayAllarmReceiversName,
				TicketDelayAllarmMessage = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
				TicketDelayAllarmMessage_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
				TicketDelayAllarmSendSMS = cRMspSelectFoSetting_Result.TicketDelayAllarmSendSMS,
				TicketDelayAllarmSendSMSProviderId = cRMspSelectFoSetting_Result.TicketDelayAllarmSendSMSProviderId,
				TicketDelayAllarmSendSMSNumber = cRMspSelectFoSetting_Result.TicketDelayAllarmSendSMSNumber,
				TicketBusyAllarm = cRMspSelectFoSetting_Result.TicketBusyAllarm,
				TicketBusyAllarmAllMsgCnt = cRMspSelectFoSetting_Result.TicketBusyAllarmAllMsgCnt,
				TicketBusyAllarmUserRepCnt = cRMspSelectFoSetting_Result.TicketBusyAllarmUserRepCnt,
				TicketBusyAllarmReceivers = cRMspSelectFoSetting_Result.TicketBusyAllarmReceivers,
				TicketBusyAllarmReceiversName = cRMspSelectFoSetting_Result.TicketBusyAllarmReceiversName,
				TicketBusyAllarmMessage = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
				TicketBusyAllarmMessage_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
				TicketBusyAllarmSendSMS = cRMspSelectFoSetting_Result.TicketBusyAllarmSendSMS,
				TicketBusyAllarmSendSMSProviderId = cRMspSelectFoSetting_Result.TicketBusyAllarmSendSMSProviderId,
				TicketBusyAllarmSendSMSNumber = cRMspSelectFoSetting_Result.TicketBusyAllarmSendSMSNumber,
				TicketUnhappyAllarm = cRMspSelectFoSetting_Result.TicketUnhappyAllarm,
				TicketUnhappyAllarmMinVote = cRMspSelectFoSetting_Result.TicketUnhappyAllarmMinVote,
				TicketUnhappyAllarmReceivers = cRMspSelectFoSetting_Result.TicketUnhappyAllarmReceivers,
				TicketUnhappyAllarmReceiversName = cRMspSelectFoSetting_Result.TicketUnhappyAllarmReceiversName,
				TicketUnhappyAllarmMessage = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
				TicketUnhappyAllarmMessage_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
				TicketUnhappyAllarmSendSMS = cRMspSelectFoSetting_Result.TicketUnhappyAllarmSendSMS,
				TicketUnhappyAllarmSendSMSProviderId = cRMspSelectFoSetting_Result.TicketUnhappyAllarmSendSMSProviderId,
				TicketUnhappyAllarmSendSMSNumber = cRMspSelectFoSetting_Result.TicketUnhappyAllarmSendSMSNumber,
				TicketColorAllarm = cRMspSelectFoSetting_Result.TicketColorAllarm,
				TicketColorAllarmJs = cRMspSelectFoSetting_Result.TicketColorAllarmJs,
				TicketClosedCanReplayAfterDays = cRMspSelectFoSetting_Result.TicketClosedCanReplayAfterDays,
				TicketDescMaxLen = cRMspSelectFoSetting_Result.TicketDescMaxLen
			};
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(model);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult EditTicketSetting(CrmFoTicketSettingLanguageViewModel model)
	{
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0757: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		GetStatusGroups();
		GetUserDepartmentList();
		GetTopicList();
		List<SelectListItem> smsProviderList = GetSmsProviderList();
		base.ViewBag.TicketDelaySMSProviders = smsProviderList;
		base.ViewBag.TicketBusySMSProviders = smsProviderList;
		base.ViewBag.TicketUnhappySMSProviders = smsProviderList;
		try
		{
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.TicketDescTooltip_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.TicketDescTooltip_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = model.TicketDescTooltip,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.TicketSubjectDefaultContext_Lang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.TicketSubjectDefaultContext_Lang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = model.TicketSubjectDefaultContext,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.TicketAutoReplyAfterSetDoingTimeDesc_Lang))
			{
				list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.TicketAutoReplyAfterSetDoingTimeDesc_Lang);
			}
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = model.TicketAutoReplyAfterSetDoingTimeDesc,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.TicketDelayAllarmMessage_Lang))
			{
				list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.TicketDelayAllarmMessage_Lang);
			}
			list4.Add(new CommonMultiLanguageViewModel
			{
				Value = model.TicketDelayAllarmMessage,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.TicketBusyAllarmMessage_Lang))
			{
				list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.TicketBusyAllarmMessage_Lang);
			}
			list5.Add(new CommonMultiLanguageViewModel
			{
				Value = model.TicketBusyAllarmMessage,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.TicketUnhappyAllarmMessage_Lang))
			{
				list6 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.TicketUnhappyAllarmMessage_Lang);
			}
			list6.Add(new CommonMultiLanguageViewModel
			{
				Value = model.TicketUnhappyAllarmMessage,
				LanguageId = lCID
			});
			string ticketDescTooltip = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
			string ticketSubjectDefaultContext = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
			string ticketAutoReplyAfterSetDoingTimeDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
			string ticketDelayAllarmMessage = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
			string ticketBusyAllarmMessage = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
			string ticketUnhappyAllarmMessage = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
			string text2 = "";
			foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages m) => m.LanguageID != defLangID))))
			{
				string text3 = "";
				string text4 = "";
				text3 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : "");
				text4 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : "");
				string text5 = "";
				text5 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : "");
				string text6 = "";
				text6 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : "");
				string text7 = "";
				text7 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : "");
				string text8 = "";
				text8 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : "");
				text2 = text2 + "[LangId=" + lang.LanguageID + "|,|DescTooltip=" + text3 + "|,|DefSubj=" + text4 + "|,|AutoReplyDesc=" + text5 + "|,|TicketDelayAllarmMessageLang=" + text6 + "|,|TicketBusyAllarmMessageLang=" + text7 + "|,|TicketUnhappyAllarmMessageLang=" + text8 + "|,|]@";
			}
			if (base.ModelState.IsValid)
			{
				if (num == 0)
				{
					if (!VersionBuyer.TicketPlus)
					{
						model.TicketAllowInCurrntCount = null;
						model.TicketAllowAddBeforeAnswerCount = null;
						model.TicketAutoCloseAfterDay = null;
						model.TicketAddProjectTypeId = null;
						model.TicketProjectTitleAndTitleGroup = null;
						model.TicketCountCurrentWithStop = null;
					}
					if (!string.IsNullOrWhiteSpace(model.TicketProjectTitleAndTitleGroup))
					{
						List<CrmFoTicketProjectTitleAndTitleGroupViewModel> list7 = new JavaScriptSerializer().Deserialize<List<CrmFoTicketProjectTitleAndTitleGroupViewModel>>(model.TicketProjectTitleAndTitleGroup);
						if (list7 != null && Enumerable.Any<CrmFoTicketProjectTitleAndTitleGroupViewModel>((IEnumerable<CrmFoTicketProjectTitleAndTitleGroupViewModel>)list7))
						{
							foreach (CrmFoTicketProjectTitleAndTitleGroupViewModel item in list7)
							{
								int result = 0;
								int.TryParse(item.prjcnvsStatusGroupId.ToString(), out result);
								string text9 = CkeckFirstcnvsStatusProcessKind(result);
								if (!string.IsNullOrWhiteSpace(text9))
								{
									text = text9;
									base.ViewBag.Error = text;
									return View(model);
								}
							}
						}
					}
					DateTime now = DateTime.Now;
					int userId = UserLogin.CurrentUser.UserId;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value = short.Parse(Financial.Get().Id.ToString());
					short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					_dbI.CRMspUpdateFODefaultTicketSetting(ticketDescTooltip, model.TicketSubjSelectLoadDefaultContext, ticketSubjectDefaultContext, text2, userId, value, value2, now, registerDatePersian, appType, defLangID, model.TicketCanAddNewSubject, model.TicketAllowInCurrntCount, model.TicketAllowAddBeforeAnswerCount, model.TicketAutoCloseAfterDay, model.TicketAddProjectTypeId, model.TicketProjectTitleAndTitleGroup, model.TicketFileAttachCount, model.TicketSendIntMsg, model.TicketFullRemindDate, model.TicketCountCurrentWithStop, model.TicketAutoReplyAfterSetDoingTime, model.TicketAutoReplyAfterSetDoingTimeTopicId, ticketAutoReplyAfterSetDoingTimeDesc, model.TicketDelayAllarm, model.TicketDelayAllarmDay, model.TicketDelayAllarmTime, model.TicketDelayAllarmReceivers, ticketDelayAllarmMessage, model.TicketDelayAllarmSendSMS, model.TicketDelayAllarmSendSMSProviderId, model.TicketDelayAllarmSendSMSNumber, model.TicketBusyAllarm, model.TicketBusyAllarmAllMsgCnt, model.TicketBusyAllarmUserRepCnt, model.TicketBusyAllarmReceivers, ticketBusyAllarmMessage, model.TicketBusyAllarmSendSMS, model.TicketBusyAllarmSendSMSProviderId, model.TicketBusyAllarmSendSMSNumber, model.TicketUnhappyAllarm, model.TicketUnhappyAllarmMinVote, model.TicketUnhappyAllarmReceivers, ticketUnhappyAllarmMessage, model.TicketUnhappyAllarmSendSMS, model.TicketUnhappyAllarmSendSMSProviderId, model.TicketUnhappyAllarmSendSMSNumber, model.TicketColorAllarm, model.TicketColorAllarmJs, model.TicketClosedCanReplayAfterDays, model.FoSettingId, model.TicketDescMaxLen);
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmFoSetting");
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
			}
			else
			{
				text = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			text = Messages.frmErrorMessage;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			text = Messages.frmErrorMessage;
		}
		base.ViewBag.Error = text;
		return View(model);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actFoSetting")]
	public ActionResult EditUserDepartmentTicketSetting()
	{
		GetUserDepartmentList();
		GetUsers();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		CrmFoTicketSettingLanguageViewModel model = new CrmFoTicketSettingLanguageViewModel();
		_ = DateTime.Now;
		try
		{
			model = new CrmFoTicketSettingLanguageViewModel
			{
				FoSettingId = 0
			};
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(model);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult EditUserDepartmentTicketSetting(CrmFoTicketSettingLanguageViewModel model)
	{
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass43_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass43_0();
		CS_0024_003C_003E8__locals0.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		try
		{
			if (UserLogin.CurrentUser != null)
			{
				_ = UserLogin.CurrentUser.UserLastCId;
			}
			GetUserDepartmentList();
			GetUsers();
			if (base.ModelState.IsValid)
			{
				if (num == 0)
				{
					DateTime now = DateTime.Now;
					int userId = UserLogin.CurrentUser.UserId;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short num2 = short.Parse(Financial.Get().Id.ToString());
					short num3 = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					db.CRMspUpdateFODefaultUserDepartmentTicketSetting(CS_0024_003C_003E8__locals0.model.DepartmentId, CS_0024_003C_003E8__locals0.model.DefaultTicketUserId, CS_0024_003C_003E8__locals0.model.TicketReferMultiUser, userId, num2, num3, now, registerDatePersian, appType, CS_0024_003C_003E8__locals0.defLangID);
					List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.TicketFooterText_Lang))
					{
						list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.TicketFooterText_Lang);
					}
					list.Add(new CommonMultiLanguageViewModel
					{
						Value = CS_0024_003C_003E8__locals0.model.TicketFooterText,
						LanguageId = lCID
					});
					if (CS_0024_003C_003E8__locals0.model.DepartmentId > 0 && VersionBuyer.TicketPlus)
					{
						_003C_003Ec__DisplayClass43_1 _003C_003Ec__DisplayClass43_ = new _003C_003Ec__DisplayClass43_1();
						DbSet<UserDepartments> userDepartments = _dbTbl.UserDepartments;
						ParameterExpression val = Expression.Parameter(typeof(UserDepartments), "c");
						_003C_003Ec__DisplayClass43_.modelUserDepartments = Queryable.FirstOrDefault<UserDepartments>((IQueryable<UserDepartments>)userDepartments, Expression.Lambda<Func<UserDepartments, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Convert((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), typeof(int?)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass43_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						if (_003C_003Ec__DisplayClass43_.modelUserDepartments != null)
						{
							_003C_003Ec__DisplayClass43_.modelUserDepartments.UserId = userId;
							_003C_003Ec__DisplayClass43_.modelUserDepartments.RegisterDate = now;
							_003C_003Ec__DisplayClass43_.modelUserDepartments.RegisterDatePersian = registerDatePersian;
							_003C_003Ec__DisplayClass43_.modelUserDepartments.Month1 = num3;
							_003C_003Ec__DisplayClass43_.modelUserDepartments.AppType = appType;
							_003C_003Ec__DisplayClass43_.modelUserDepartments.Year1 = num2;
							_003C_003Ec__DisplayClass43_.modelUserDepartments.TicketFooterText = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
							_dbTbl.Entry(_003C_003Ec__DisplayClass43_.modelUserDepartments).State = EntityState.Modified;
							_dbTbl.Configuration.ValidateOnSaveEnabled = false;
							_dbTbl.SaveChanges();
							_dbTbl.Configuration.ValidateOnSaveEnabled = true;
							using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									_003C_003Ec__DisplayClass43_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass43_2();
									CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass43_;
									CS_0024_003C_003E8__locals1.lang = enumerator.Current;
									DbSet<UserDepartments_Lang> userDepartments_Lang = _dbTbl.UserDepartments_Lang;
									val = Expression.Parameter(typeof(UserDepartments_Lang), "c");
									UserDepartments_Lang userDepartments_Lang2 = Queryable.FirstOrDefault<UserDepartments_Lang>((IQueryable<UserDepartments_Lang>)userDepartments_Lang, Expression.Lambda<Func<UserDepartments_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass43_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass43_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
									if (userDepartments_Lang2 != null)
									{
										userDepartments_Lang2.TicketFooterText = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										_dbTbl.Entry(userDepartments_Lang2).State = EntityState.Modified;
										_dbTbl.SaveChanges();
										continue;
									}
									userDepartments_Lang2 = new UserDepartments_Lang();
									userDepartments_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
									userDepartments_Lang2.DepartmentID = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.modelUserDepartments.DepartmentID;
									userDepartments_Lang2.Department = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.modelUserDepartments.Department;
									userDepartments_Lang2.TicketFooterText = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									_dbTbl.UserDepartments_Lang.Add(userDepartments_Lang2);
									_dbTbl.SaveChanges();
								}
							}
							new FilesManager();
							new FacadeFTP(Configuration.FacadeFtpFo);
							string pathFtpFo = Configuration.PathFtpFo;
							string userNameFtpFo = Configuration.UserNameFtpFo;
							string passwordFtpFo = Configuration.PasswordFtpFo;
							bool usePassiveFtpFo = Configuration.UsePassiveFtpFo;
							if (!string.IsNullOrEmpty(pathFtpFo) && !string.IsNullOrEmpty(userNameFtpFo) && !string.IsNullOrEmpty(passwordFtpFo))
							{
								try
								{
									if (list != null)
									{
										Files.UploadPicFromEditorToFtp(pathFtpFo, userNameFtpFo, passwordFtpFo, usePassiveFtpFo, list);
									}
								}
								catch (Exception e)
								{
									ErrorSignal.FromCurrentContext().Raise(e);
								}
							}
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("UserDepartments");
						}
					}
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
			}
			else
			{
				text = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
		}
		catch (DbEntityValidationException e2)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e2);
			text = Messages.frmErrorMessage;
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
			text = Messages.frmErrorMessage;
		}
		base.ViewBag.Error = text;
		return View(CS_0024_003C_003E8__locals0.model);
	}

	public string CkeckFirstcnvsStatusProcessKind(int cnvsStatusGroupId)
	{
		string result = "";
		_ = UserLogin.CurrentUser;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (cnvsStatusGroupId != 0)
			{
				List<CRMspSelectConversationStatus_Result> list = Enumerable.ToList<CRMspSelectConversationStatus_Result>((IEnumerable<CRMspSelectConversationStatus_Result>)db.CRMspSelectConversationStatus(cnvsStatusGroupId, lCID, result2));
				if (list != null && Enumerable.Any<CRMspSelectConversationStatus_Result>((IEnumerable<CRMspSelectConversationStatus_Result>)list))
				{
					CRMspSelectConversationStatus_Result cRMspSelectConversationStatus_Result = Enumerable.FirstOrDefault<CRMspSelectConversationStatus_Result>((IEnumerable<CRMspSelectConversationStatus_Result>)list);
					if (cRMspSelectConversationStatus_Result != null)
					{
						int result3 = 0;
						int.TryParse(cRMspSelectConversationStatus_Result.ProcessKindId.ToString(), out result3);
						if (result3 != 1 && result3 != 0)
						{
							result = string.Format(Messages.msgErrorTicketFristCnvsStatusProcessKindNotDoing, cRMspSelectConversationStatus_Result.ConversationStatusGroup ?? "");
						}
					}
				}
				else
				{
					result = Messages.msgErrorNotDefinedCnvsStatusForGroup;
				}
			}
			else
			{
				result = Messages.msgNotFound;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = Messages.frmErrorMessage;
			result = ex.Message;
		}
		return result;
	}

	[AjaxOnly]
	public JsonResult GetPresentationList()
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyPresentation_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyPresentation_Result>)Enumerable.ToList<CRMspSelectCompanyPresentation_Result>((IEnumerable<CRMspSelectCompanyPresentation_Result>)db.CRMspSelectCompanyPresentation(lCID, result)), (Func<CRMspSelectCompanyPresentation_Result, SelectListItem>)((CRMspSelectCompanyPresentation_Result item) => new SelectListItem
			{
				Text = item.Presentation,
				Value = item.CompanyPresentationID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.cmpPresentationList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetcmpTypeList()
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyType_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyType_Result>)Enumerable.ToList<CRMspSelectCompanyType_Result>((IEnumerable<CRMspSelectCompanyType_Result>)db.CRMspSelectCompanyType(lCID, result)), (Func<CRMspSelectCompanyType_Result, SelectListItem>)((CRMspSelectCompanyType_Result item) => new SelectListItem
			{
				Text = item.CompanyTypeName,
				Value = item.CompanyTypeID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.cmpTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetcmpGroupList()
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyGroup_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroup_Result>)Enumerable.ToList<CRMspSelectCompanyGroup_Result>((IEnumerable<CRMspSelectCompanyGroup_Result>)db.CRMspSelectCompanyGroup(UserLogin.CurrentUser.UserId, lCID, result, result2)), (Func<CRMspSelectCompanyGroup_Result, SelectListItem>)((CRMspSelectCompanyGroup_Result item) => new SelectListItem
			{
				Text = item.GroupName,
				Value = item.CompanyGroupID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.cmpGroupList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetcmpGroupIIList()
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyGroupsII_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsII_Result>)Enumerable.ToList<CRMspSelectCompanyGroupsII_Result>((IEnumerable<CRMspSelectCompanyGroupsII_Result>)db.CRMspSelectCompanyGroupsII(lCID, result)), (Func<CRMspSelectCompanyGroupsII_Result, SelectListItem>)((CRMspSelectCompanyGroupsII_Result item) => new SelectListItem
			{
				Text = item.GroupIIName,
				Value = item.CompanyGroupIIID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.cmpGroupIIList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetcmpGroupIIIList()
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyGroupsIII_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsIII_Result>)Enumerable.ToList<CRMspSelectCompanyGroupsIII_Result>((IEnumerable<CRMspSelectCompanyGroupsIII_Result>)db.CRMspSelectCompanyGroupsIII(lCID, result)), (Func<CRMspSelectCompanyGroupsIII_Result, SelectListItem>)((CRMspSelectCompanyGroupsIII_Result item) => new SelectListItem
			{
				Text = item.GroupIIIName,
				Value = item.CompanyGroupIIIID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.cmpGroupIIIList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetcmpGroupIVList()
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyGroupsIV_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsIV_Result>)Enumerable.ToList<CRMspSelectCompanyGroupsIV_Result>((IEnumerable<CRMspSelectCompanyGroupsIV_Result>)db.CRMspSelectCompanyGroupsIV(UserLogin.CurrentUser.UserId, lCID, result, result2)), (Func<CRMspSelectCompanyGroupsIV_Result, SelectListItem>)((CRMspSelectCompanyGroupsIV_Result item) => new SelectListItem
			{
				Text = item.GroupIVName,
				Value = item.CompanyGroupIVID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.cmpGroupIVList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetSubGroup(int id)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> data = new List<SelectListItem>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			data = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanySubGroup_Result, SelectListItem>((IEnumerable<CRMspSelectCompanySubGroup_Result>)Enumerable.ToList<CRMspSelectCompanySubGroup_Result>((IEnumerable<CRMspSelectCompanySubGroup_Result>)db.CRMspSelectCompanySubGroup(UserLogin.CurrentUser.UserId, id, lCID, result, result2)), (Func<CRMspSelectCompanySubGroup_Result, SelectListItem>)((CRMspSelectCompanySubGroup_Result item) => new SelectListItem
			{
				Text = item.SubGroupName,
				Value = item.CompanySubGroupID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCmpReferUser()
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyReferUsers_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyReferUsers_Result>)Enumerable.ToList<CRMspSelectCompanyReferUsers_Result>((IEnumerable<CRMspSelectCompanyReferUsers_Result>)db.CRMspSelectCompanyReferUsers(UserLogin.CurrentUser.UserId, lCID, result, result2)), (Func<CRMspSelectCompanyReferUsers_Result, SelectListItem>)((CRMspSelectCompanyReferUsers_Result item) => new SelectListItem
			{
				Text = item.USER,
				Value = item.UserId.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.cmpReferUserList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetStatusGroups()
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectConversationStatusGroups_Result, SelectListItem>((IEnumerable<CRMspSelectConversationStatusGroups_Result>)Enumerable.ToList<CRMspSelectConversationStatusGroups_Result>((IEnumerable<CRMspSelectConversationStatusGroups_Result>)db.CRMspSelectConversationStatusGroups(lCID, result)), (Func<CRMspSelectConversationStatusGroups_Result, SelectListItem>)((CRMspSelectConversationStatusGroups_Result item) => new SelectListItem
			{
				Text = item.ConversationStatusGroup,
				Value = item.ConversationStatusGroupID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.StatusGroupslist = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetprjPriorityList()
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectProjectPriority_Result, SelectListItem>((IEnumerable<CRMspSelectProjectPriority_Result>)Enumerable.ToList<CRMspSelectProjectPriority_Result>((IEnumerable<CRMspSelectProjectPriority_Result>)db.CRMspSelectProjectPriority(lCID, result)), (Func<CRMspSelectProjectPriority_Result, SelectListItem>)((CRMspSelectProjectPriority_Result item) => new SelectListItem
			{
				Text = item.Priority,
				Value = item.ProjectPriorityID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ProjectPrioritylist = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetprjGradeList()
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectProjectGrade_Result, SelectListItem>((IEnumerable<CRMspSelectProjectGrade_Result>)Enumerable.ToList<CRMspSelectProjectGrade_Result>((IEnumerable<CRMspSelectProjectGrade_Result>)db.CRMspSelectProjectGrade(lCID, result)), (Func<CRMspSelectProjectGrade_Result, SelectListItem>)((CRMspSelectProjectGrade_Result item) => new SelectListItem
			{
				Text = item.ProjectGrade,
				Value = item.ProjectGradeID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ProjectGradelist = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetprjGroupList()
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectProjectGroups_Result, SelectListItem>((IEnumerable<CRMspSelectProjectGroups_Result>)Enumerable.ToList<CRMspSelectProjectGroups_Result>((IEnumerable<CRMspSelectProjectGroups_Result>)db.CRMspSelectProjectGroups(lCID, result)), (Func<CRMspSelectProjectGroups_Result, SelectListItem>)((CRMspSelectProjectGroups_Result item) => new SelectListItem
			{
				Text = item.ProjectGroup,
				Value = item.ProjectGroupID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ProjectGroupslist = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetprjStartUserist()
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectUserForLinkedType_Result, SelectListItem>((IEnumerable<CRMspSelectUserForLinkedType_Result>)Enumerable.ToList<CRMspSelectUserForLinkedType_Result>((IEnumerable<CRMspSelectUserForLinkedType_Result>)db.CRMspSelectUserForLinkedType(UserLogin.CurrentUser.UserId, 11, lCID, result, result2)), (Func<CRMspSelectUserForLinkedType_Result, SelectListItem>)((CRMspSelectUserForLinkedType_Result item) => new SelectListItem
			{
				Text = item.UserName,
				Value = item.LinkedUserId.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PrjStartUsers = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult GetProjectTitleGroup(string textValue)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSearchProjectTitleGroup_Result> data = new List<CRMspSearchProjectTitleGroup_Result>();
		try
		{
			textValue = textValue ?? "";
			data = Enumerable.ToList<CRMspSearchProjectTitleGroup_Result>((IEnumerable<CRMspSearchProjectTitleGroup_Result>)_dbI.CRMspSearchProjectTitleGroup(textValue, lCID, result));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public JsonResult GetProjectTitleGroupByPrjTitleGroup(string textValue, string prjTitleGroups = "", int prjTitleGroupId = 0)
	{
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSearchProjectTitleGroup_Result> list = new List<CRMspSearchProjectTitleGroup_Result>();
		try
		{
			textValue = textValue ?? "";
			list = Enumerable.ToList<CRMspSearchProjectTitleGroup_Result>((IEnumerable<CRMspSearchProjectTitleGroup_Result>)_dbI.CRMspSearchProjectTitleGroup(textValue, lCID, result));
			List<CrmFoTicketProjectTitleAndTitleGroupViewModel> list2 = new List<CrmFoTicketProjectTitleAndTitleGroupViewModel>();
			if (!string.IsNullOrWhiteSpace(prjTitleGroups))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CrmFoTicketProjectTitleAndTitleGroupViewModel>>(prjTitleGroups);
				if (list2 != null && list2.Count > 0 && prjTitleGroupId != 0)
				{
					List<CrmFoTicketProjectTitleAndTitleGroupViewModel> list3 = new List<CrmFoTicketProjectTitleAndTitleGroupViewModel>();
					foreach (CrmFoTicketProjectTitleAndTitleGroupViewModel item2 in list2)
					{
						if (item2.prjTitleGroupId.GetValueOrDefault() != prjTitleGroupId)
						{
							list3.Add(item2);
						}
					}
					list2 = list3;
				}
			}
			if (list2 != null && Enumerable.Any<CrmFoTicketProjectTitleAndTitleGroupViewModel>((IEnumerable<CrmFoTicketProjectTitleAndTitleGroupViewModel>)list2))
			{
				List<CRMspSearchProjectTitleGroup_Result> list4 = new List<CRMspSearchProjectTitleGroup_Result>();
				if (list != null && Enumerable.Any<CRMspSearchProjectTitleGroup_Result>((IEnumerable<CRMspSearchProjectTitleGroup_Result>)list))
				{
					foreach (CRMspSearchProjectTitleGroup_Result item in list)
					{
						if (Enumerable.FirstOrDefault<CrmFoTicketProjectTitleAndTitleGroupViewModel>((IEnumerable<CrmFoTicketProjectTitleAndTitleGroupViewModel>)list2, (Func<CrmFoTicketProjectTitleAndTitleGroupViewModel, bool>)((CrmFoTicketProjectTitleAndTitleGroupViewModel m) => m.prjTitleGroupId.GetValueOrDefault() == item.ProjectTitleGroupId)) == null)
						{
							list4.Add(item);
						}
					}
					list = list4;
				}
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

	[AjaxOnly]
	public JsonResult GetcnvsPriorityList()
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectConversationPriority_Result, SelectListItem>((IEnumerable<CRMspSelectConversationPriority_Result>)Enumerable.ToList<CRMspSelectConversationPriority_Result>((IEnumerable<CRMspSelectConversationPriority_Result>)db.CRMspSelectConversationPriority(lCID, result)), (Func<CRMspSelectConversationPriority_Result, SelectListItem>)((CRMspSelectConversationPriority_Result item) => new SelectListItem
			{
				Text = item.Priority,
				Value = item.ConversationPriorityID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ConversationPrioritylist = list;
		base.ViewBag.ConversationPrioritylistI = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetTopicList()
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectConversationTopics_Result, SelectListItem>((IEnumerable<CRMspSelectConversationTopics_Result>)Enumerable.ToList<CRMspSelectConversationTopics_Result>((IEnumerable<CRMspSelectConversationTopics_Result>)db.CRMspSelectConversationTopics(lCID, result)), (Func<CRMspSelectConversationTopics_Result, SelectListItem>)((CRMspSelectConversationTopics_Result item) => new SelectListItem
			{
				Text = item.Topic,
				Value = item.ConversationTopicsID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ConversationTopicslist = list;
		base.ViewBag.ConversationTopicslistI = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetcnvsStatusList(int statusGroupId)
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
			foreach (CRMspSelectConversationStatus_Result item in Enumerable.ToList<CRMspSelectConversationStatus_Result>((IEnumerable<CRMspSelectConversationStatus_Result>)db.CRMspSelectConversationStatus(statusGroupId, lCID, result)))
			{
				if (item.StatusDesc == null)
				{
					item.StatusDesc = "";
				}
				list.Add(new SelectListItem
				{
					Text = ((!string.IsNullOrEmpty(item.Status)) ? item.Status : "") + (item.ProgressPercent.HasValue ? (" |" + Labels.cnvsPercentStatus + ": " + item.ProgressPercent) : "") + ((!string.IsNullOrEmpty(item.StatusDesc)) ? (" |" + Labels.cnvsDescStatus + ": " + item.StatusDesc) : ""),
					Value = item.ConversationStatusID.ToString()
				});
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CnvsStatuslist = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCnvsStatusResult(int cnvsStatusId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> data = new List<SelectListItem>();
		try
		{
			List<CRMspSelectActiveConversationStatusResult_Result> list = Enumerable.ToList<CRMspSelectActiveConversationStatusResult_Result>((IEnumerable<CRMspSelectActiveConversationStatusResult_Result>)_dbI.CRMspSelectActiveConversationStatusResult(cnvsStatusId, lCID, result));
			if (list != null && Enumerable.Any<CRMspSelectActiveConversationStatusResult_Result>((IEnumerable<CRMspSelectActiveConversationStatusResult_Result>)list))
			{
				data = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectActiveConversationStatusResult_Result, SelectListItem>((IEnumerable<CRMspSelectActiveConversationStatusResult_Result>)list, (Func<CRMspSelectActiveConversationStatusResult_Result, SelectListItem>)((CRMspSelectActiveConversationStatusResult_Result item) => new SelectListItem
				{
					Text = item.ResultTitle,
					Value = item.ConversationStatusResultId.ToString()
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetCnvsUserList()
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectUserForLinkedType_Result, SelectListItem>((IEnumerable<CRMspSelectUserForLinkedType_Result>)Enumerable.ToList<CRMspSelectUserForLinkedType_Result>((IEnumerable<CRMspSelectUserForLinkedType_Result>)db.CRMspSelectUserForLinkedType(UserLogin.CurrentUser.UserId, 8, lCID, result, result2)), (Func<CRMspSelectUserForLinkedType_Result, SelectListItem>)((CRMspSelectUserForLinkedType_Result item) => new SelectListItem
			{
				Text = item.UserName,
				Value = item.LinkedUserId.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CnvsUserslist = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public List<SelectListItem> GetCnvsReferUserListI(bool addSaleCenterResponsibleUser = false)
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
			if (addSaleCenterResponsibleUser)
			{
				List<CRMspSelectUsersByIds_Result> list2 = CRMIdeal.Classes.Helper.User.SelectUsersByIds("-109");
				if (list2 != null)
				{
					list.AddRange(Enumerable.Select<CRMspSelectUsersByIds_Result, SelectListItem>((IEnumerable<CRMspSelectUsersByIds_Result>)Enumerable.ToList<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list2), (Func<CRMspSelectUsersByIds_Result, SelectListItem>)((CRMspSelectUsersByIds_Result i) => new SelectListItem
					{
						Text = (i.FullName ?? ""),
						Value = i.UserId.ToString(),
						Selected = false
					})));
					SelectListItem item2 = new SelectListItem
					{
						Text = "--------------------",
						Value = "",
						Selected = false
					};
					list.Add(item2);
				}
			}
			List<CRMspSelectUserForLinkedType_Result> list3 = Enumerable.ToList<CRMspSelectUserForLinkedType_Result>((IEnumerable<CRMspSelectUserForLinkedType_Result>)db.CRMspSelectUserForLinkedType(UserLogin.CurrentUser.UserId, 7, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectUserForLinkedType_Result, SelectListItem>((IEnumerable<CRMspSelectUserForLinkedType_Result>)list3, (Func<CRMspSelectUserForLinkedType_Result, SelectListItem>)((CRMspSelectUserForLinkedType_Result item) => new SelectListItem
			{
				Text = item.UserName,
				Value = item.LinkedUserId.ToString(),
				Selected = false
			})));
			if (list == null)
			{
				list = new List<SelectListItem>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public JsonResult GetCnvsReferUserList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		List<SelectListItem> list2 = new List<SelectListItem>();
		List<SelectListItem> list3 = new List<SelectListItem>();
		List<SelectListItem> list4 = new List<SelectListItem>();
		try
		{
			list = GetCnvsReferUserListI();
			list2 = GetCnvsReferUserListI();
			list3 = GetCnvsReferUserListI(addSaleCenterResponsibleUser: true);
			list4 = GetCnvsReferUserListI(addSaleCenterResponsibleUser: true);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CnvsReferUserList = list;
		base.ViewBag.CnvsReferUserListI = list2;
		base.ViewBag.pordCnvsReferUserList = list3;
		base.ViewBag.ordCnvsReferUserListI = list4;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetEmailSettingList()
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<EmailSetting, SelectListItem>((IEnumerable<EmailSetting>)Enumerable.ToList<EmailSetting>((IEnumerable<EmailSetting>)_dbTbl.EmailSetting), (Func<EmailSetting, SelectListItem>)((EmailSetting item) => new SelectListItem
			{
				Text = item.EmailSettingId.ToString(),
				Value = item.EmailSettingId.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.EmailSettinglist = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetEmailList()
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
			DbSet<EmailUsersInfo> emailUsersInfo = _dbTbl.EmailUsersInfo;
			ParameterExpression val = Expression.Parameter(typeof(EmailUsersInfo), "c");
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<EmailUsersInfo, SelectListItem>((IEnumerable<EmailUsersInfo>)Enumerable.ToList<EmailUsersInfo>((IEnumerable<EmailUsersInfo>)Queryable.Where<EmailUsersInfo>((IQueryable<EmailUsersInfo>)emailUsersInfo, Expression.Lambda<Func<EmailUsersInfo, bool>>((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (ParameterExpression[])(object)new ParameterExpression[1] { val }))), (Func<EmailUsersInfo, SelectListItem>)((EmailUsersInfo item) => new SelectListItem
			{
				Text = item.euNikeName + "  [ " + item.euNikeEmail + " ]",
				Value = item.EmailUsersInfoId.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.Emailslist = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetUserDepartmentList()
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectUserDepartments_Result, SelectListItem>((IEnumerable<CRMspSelectUserDepartments_Result>)Enumerable.ToList<CRMspSelectUserDepartments_Result>((IEnumerable<CRMspSelectUserDepartments_Result>)db.CRMspSelectUserDepartments(lCID, result, result2)), (Func<CRMspSelectUserDepartments_Result, SelectListItem>)((CRMspSelectUserDepartments_Result item) => new SelectListItem
			{
				Text = item.Department,
				Value = item.DepartmentID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.UserDepartmentList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetUsers(bool addCmpReferUser = false)
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
			if (addCmpReferUser)
			{
				List<CRMspSelectUsersByIds_Result> list2 = CRMIdeal.Classes.Helper.User.SelectUsersByIds("-102");
				if (list2 != null)
				{
					list.AddRange(Enumerable.Select<CRMspSelectUsersByIds_Result, SelectListItem>((IEnumerable<CRMspSelectUsersByIds_Result>)Enumerable.ToList<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list2), (Func<CRMspSelectUsersByIds_Result, SelectListItem>)((CRMspSelectUsersByIds_Result i) => new SelectListItem
					{
						Text = (i.FullName ?? ""),
						Value = i.UserId.ToString(),
						Selected = false
					})));
					SelectListItem item2 = new SelectListItem
					{
						Text = "--------------------",
						Value = "0",
						Selected = false
					};
					list.Add(item2);
				}
			}
			List<CRMspSelectActiveUsers_Result> list3 = Enumerable.ToList<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)db.CRMspSelectActiveUsers(lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)list3, (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result item) => new SelectListItem
			{
				Text = (item.Name ?? ""),
				Value = item.UserId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.UsersList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPrdPriceGroupList()
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
			List<WSspSelectProductPriceGroup_Result> list2 = Enumerable.ToList<WSspSelectProductPriceGroup_Result>((IEnumerable<WSspSelectProductPriceGroup_Result>)db.WSspSelectProductPriceGroup(lCID, result));
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
		base.ViewBag.PrdPriceGroupList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public void GetLinkAccHolooDatabases()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
		int num = 0;
		if (cRMspSelectCrmsysSetting_Result != null)
		{
			num = cRMspSelectCrmsysSetting_Result.LinkAccSystemId.GetValueOrDefault();
		}
		base.ViewBag.LinkAccSystemId = num;
		if (num == 4)
		{
			List<CRMspSelectLinkAccSettingDB_Result> list2 = Enumerable.ToList<CRMspSelectLinkAccSettingDB_Result>((IEnumerable<CRMspSelectLinkAccSettingDB_Result>)_dbLink.CRMspSelectLinkAccSettingDB(4, null, lCID, result));
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<CRMspSelectLinkAccSettingDB_Result, SelectListItem>((IEnumerable<CRMspSelectLinkAccSettingDB_Result>)list2, (Func<CRMspSelectLinkAccSettingDB_Result, SelectListItem>)((CRMspSelectLinkAccSettingDB_Result item) => new SelectListItem
				{
					Text = item.LinkAccSettingDbTitle,
					Value = item.LinkAccSettingDBId.ToString(),
					Selected = false
				})));
			}
			base.ViewBag.LinkAccSettingDBList = list;
		}
		else
		{
			base.ViewBag.LinkAccSettingDBList = list;
		}
	}

	[AjaxOnly]
	public JsonResult GetGallery()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		List<SelectListItem> list2 = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			string cmsGalleryGalleryEffectSlideTxt = Labels.CmsGalleryGalleryEffectSlideTxt;
			string cmsGalleryGalleryEffectFadeTxt = Labels.CmsGalleryGalleryEffectFadeTxt;
			List<CRMspCmsSelectActiveGallery_Result> list3 = Enumerable.ToList<CRMspCmsSelectActiveGallery_Result>((IEnumerable<CRMspCmsSelectActiveGallery_Result>)db.CRMspCmsSelectActiveGallery(cmsGalleryGalleryEffectSlideTxt, cmsGalleryGalleryEffectFadeTxt, lCID, result, 220));
			list.AddRange(Enumerable.Select<CRMspCmsSelectActiveGallery_Result, SelectListItem>((IEnumerable<CRMspCmsSelectActiveGallery_Result>)Enumerable.ToList<CRMspCmsSelectActiveGallery_Result>((IEnumerable<CRMspCmsSelectActiveGallery_Result>)list3), (Func<CRMspCmsSelectActiveGallery_Result, SelectListItem>)((CRMspCmsSelectActiveGallery_Result i) => new SelectListItem
			{
				Text = i.GalleryTitle,
				Value = i.GalleryId.ToString(),
				Selected = false
			})));
			List<CRMspCmsSelectActiveGallery_Result> list4 = Enumerable.ToList<CRMspCmsSelectActiveGallery_Result>((IEnumerable<CRMspCmsSelectActiveGallery_Result>)db.CRMspCmsSelectActiveGallery(cmsGalleryGalleryEffectSlideTxt, cmsGalleryGalleryEffectFadeTxt, lCID, result, 210));
			list2.AddRange(Enumerable.Select<CRMspCmsSelectActiveGallery_Result, SelectListItem>((IEnumerable<CRMspCmsSelectActiveGallery_Result>)Enumerable.ToList<CRMspCmsSelectActiveGallery_Result>((IEnumerable<CRMspCmsSelectActiveGallery_Result>)list4), (Func<CRMspCmsSelectActiveGallery_Result, SelectListItem>)((CRMspCmsSelectActiveGallery_Result i) => new SelectListItem
			{
				Text = i.GalleryTitle,
				Value = i.GalleryId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.GalleryIList = list;
		base.ViewBag.GalleryIIList = list;
		base.ViewBag.GalleryIIIList = list;
		base.ViewBag.FoGalleryIList = list2;
		base.ViewBag.FoGalleryIIList = list2;
		base.ViewBag.FoGalleryIIIList = list2;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public List<SelectListItem> GetGalleryList()
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
			string cmsGalleryGalleryEffectSlideTxt = Labels.CmsGalleryGalleryEffectSlideTxt;
			string cmsGalleryGalleryEffectFadeTxt = Labels.CmsGalleryGalleryEffectFadeTxt;
			List<CRMspCmsSelectActiveGallery_Result> list2 = Enumerable.ToList<CRMspCmsSelectActiveGallery_Result>((IEnumerable<CRMspCmsSelectActiveGallery_Result>)db.CRMspCmsSelectActiveGallery(cmsGalleryGalleryEffectSlideTxt, cmsGalleryGalleryEffectFadeTxt, lCID, result, 220));
			list.AddRange(Enumerable.Select<CRMspCmsSelectActiveGallery_Result, SelectListItem>((IEnumerable<CRMspCmsSelectActiveGallery_Result>)Enumerable.ToList<CRMspCmsSelectActiveGallery_Result>((IEnumerable<CRMspCmsSelectActiveGallery_Result>)list2), (Func<CRMspCmsSelectActiveGallery_Result, SelectListItem>)((CRMspCmsSelectActiveGallery_Result i) => new SelectListItem
			{
				Text = i.GalleryTitle,
				Value = i.GalleryId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public List<SelectListItem> GetFoGalleryList()
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
			string cmsGalleryGalleryEffectSlideTxt = Labels.CmsGalleryGalleryEffectSlideTxt;
			string cmsGalleryGalleryEffectFadeTxt = Labels.CmsGalleryGalleryEffectFadeTxt;
			List<CRMspCmsSelectActiveGallery_Result> list2 = Enumerable.ToList<CRMspCmsSelectActiveGallery_Result>((IEnumerable<CRMspCmsSelectActiveGallery_Result>)db.CRMspCmsSelectActiveGallery(cmsGalleryGalleryEffectSlideTxt, cmsGalleryGalleryEffectFadeTxt, lCID, result, 210));
			list.AddRange(Enumerable.Select<CRMspCmsSelectActiveGallery_Result, SelectListItem>((IEnumerable<CRMspCmsSelectActiveGallery_Result>)Enumerable.ToList<CRMspCmsSelectActiveGallery_Result>((IEnumerable<CRMspCmsSelectActiveGallery_Result>)list2), (Func<CRMspCmsSelectActiveGallery_Result, SelectListItem>)((CRMspCmsSelectActiveGallery_Result i) => new SelectListItem
			{
				Text = i.GalleryTitle,
				Value = i.GalleryId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public List<SelectListItem> GetMobFoGalleryList()
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
			string cmsGalleryGalleryEffectSlideTxt = Labels.CmsGalleryGalleryEffectSlideTxt;
			string cmsGalleryGalleryEffectFadeTxt = Labels.CmsGalleryGalleryEffectFadeTxt;
			List<CRMspCmsSelectActiveGallery_Result> list2 = Enumerable.ToList<CRMspCmsSelectActiveGallery_Result>((IEnumerable<CRMspCmsSelectActiveGallery_Result>)db.CRMspCmsSelectActiveGallery(cmsGalleryGalleryEffectSlideTxt, cmsGalleryGalleryEffectFadeTxt, lCID, result, 230));
			list.AddRange(Enumerable.Select<CRMspCmsSelectActiveGallery_Result, SelectListItem>((IEnumerable<CRMspCmsSelectActiveGallery_Result>)Enumerable.ToList<CRMspCmsSelectActiveGallery_Result>((IEnumerable<CRMspCmsSelectActiveGallery_Result>)list2), (Func<CRMspCmsSelectActiveGallery_Result, SelectListItem>)((CRMspCmsSelectActiveGallery_Result i) => new SelectListItem
			{
				Text = i.GalleryTitle,
				Value = i.GalleryId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public List<SelectListItem> GetShpFooterList()
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
			List<CRMspCmsSelectFooterBySysPartId_Result> list2 = Enumerable.ToList<CRMspCmsSelectFooterBySysPartId_Result>((IEnumerable<CRMspCmsSelectFooterBySysPartId_Result>)_dbII.CRMspCmsSelectFooterBySysPartId(220, true, lCID, result));
			list.AddRange(Enumerable.Select<CRMspCmsSelectFooterBySysPartId_Result, SelectListItem>((IEnumerable<CRMspCmsSelectFooterBySysPartId_Result>)Enumerable.ToList<CRMspCmsSelectFooterBySysPartId_Result>((IEnumerable<CRMspCmsSelectFooterBySysPartId_Result>)list2), (Func<CRMspCmsSelectFooterBySysPartId_Result, SelectListItem>)((CRMspCmsSelectFooterBySysPartId_Result i) => new SelectListItem
			{
				Text = i.FooterTitle,
				Value = i.FooterId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public JsonResult GetPosition()
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
			SelectListItem item = new SelectListItem
			{
				Text = Labels.PositionTopRightTxt,
				Value = "1",
				Selected = false
			};
			list.Add(item);
			item = new SelectListItem
			{
				Text = Labels.PositionTopCenterTxt,
				Value = "2",
				Selected = false
			};
			list.Add(item);
			item = new SelectListItem
			{
				Text = Labels.PositionTopLeftTxt,
				Value = "3",
				Selected = false
			};
			list.Add(item);
			item = new SelectListItem
			{
				Text = Labels.PositionCenterRightTxt,
				Value = "4",
				Selected = false
			};
			list.Add(item);
			item = new SelectListItem
			{
				Text = Labels.PositionCenterTxt,
				Value = "5",
				Selected = false
			};
			list.Add(item);
			item = new SelectListItem
			{
				Text = Labels.PositionCenterLeftTxt,
				Value = "6",
				Selected = false
			};
			list.Add(item);
			item = new SelectListItem
			{
				Text = Labels.PositionBottomRightTxt,
				Value = "7",
				Selected = false
			};
			list.Add(item);
			item = new SelectListItem
			{
				Text = Labels.PositionBottomCenterTxt,
				Value = "8",
				Selected = false
			};
			list.Add(item);
			item = new SelectListItem
			{
				Text = Labels.PositionBottomLeftTxt,
				Value = "9",
				Selected = false
			};
			list.Add(item);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PositionList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetSmsSendType()
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
			SelectListItem item = new SelectListItem
			{
				Text = Labels.SmsSendByWebTxt,
				Value = "1",
				Selected = false
			};
			list.Add(item);
			item = new SelectListItem
			{
				Text = Labels.SmsSendByGsmTxt,
				Value = "2",
				Selected = false
			};
			list.Add(item);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.SmsSendTypeList = list;
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
			if (Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)list))
			{
				list[0].Selected = true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.WareHouseList = list;
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
			List<WSspSelectCurrencyUnits_Result> list2 = Enumerable.ToList<WSspSelectCurrencyUnits_Result>((IEnumerable<WSspSelectCurrencyUnits_Result>)db.WSspSelectCurrencyUnits(lCID, result));
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
	public JsonResult GetPordVerifierRequest()
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
			List<CRMspSelectUsersByIds_Result> list2 = CRMIdeal.Classes.Helper.User.SelectUsersByIds("-109");
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<CRMspSelectUsersByIds_Result, SelectListItem>((IEnumerable<CRMspSelectUsersByIds_Result>)Enumerable.ToList<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list2), (Func<CRMspSelectUsersByIds_Result, SelectListItem>)((CRMspSelectUsersByIds_Result i) => new SelectListItem
				{
					Text = (i.FullName ?? ""),
					Value = i.UserId.ToString(),
					Selected = false
				})));
				SelectListItem item2 = new SelectListItem
				{
					Text = "--------------------",
					Value = "",
					Selected = false
				};
				list.Add(item2);
			}
			List<CRMspSelectPreOrderVerifiers_Result> list3 = Enumerable.ToList<CRMspSelectPreOrderVerifiers_Result>((IEnumerable<CRMspSelectPreOrderVerifiers_Result>)db.CRMspSelectPreOrderVerifiers(UserLogin.CurrentUser.UserId, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectPreOrderVerifiers_Result, SelectListItem>((IEnumerable<CRMspSelectPreOrderVerifiers_Result>)list3, (Func<CRMspSelectPreOrderVerifiers_Result, SelectListItem>)((CRMspSelectPreOrderVerifiers_Result item) => new SelectListItem
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
		base.ViewBag.PordVerifierRequestList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetOrderOpr()
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
			List<WSspSelectOrderOpr_Result> list2 = Order.SelectOrderOpr();
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<WSspSelectOrderOpr_Result, SelectListItem>((IEnumerable<WSspSelectOrderOpr_Result>)list2, (Func<WSspSelectOrderOpr_Result, SelectListItem>)((WSspSelectOrderOpr_Result item) => new SelectListItem
				{
					Text = item.Name,
					Value = item.OrderOprID.ToString(),
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
		base.ViewBag.OrderOprList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetOrdVerifierRequest()
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
			List<CRMspSelectUsersByIds_Result> list2 = CRMIdeal.Classes.Helper.User.SelectUsersByIds("-109");
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<CRMspSelectUsersByIds_Result, SelectListItem>((IEnumerable<CRMspSelectUsersByIds_Result>)Enumerable.ToList<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list2), (Func<CRMspSelectUsersByIds_Result, SelectListItem>)((CRMspSelectUsersByIds_Result i) => new SelectListItem
				{
					Text = (i.FullName ?? ""),
					Value = i.UserId.ToString(),
					Selected = false
				})));
				SelectListItem item2 = new SelectListItem
				{
					Text = "--------------------",
					Value = "",
					Selected = false
				};
				list.Add(item2);
			}
			List<CRMspSelectOrderVerifiers_Result> list3 = Enumerable.ToList<CRMspSelectOrderVerifiers_Result>((IEnumerable<CRMspSelectOrderVerifiers_Result>)db.CRMspSelectOrderVerifiers(UserLogin.CurrentUser.UserId, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectOrderVerifiers_Result, SelectListItem>((IEnumerable<CRMspSelectOrderVerifiers_Result>)list3, (Func<CRMspSelectOrderVerifiers_Result, SelectListItem>)((CRMspSelectOrderVerifiers_Result item) => new SelectListItem
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
		base.ViewBag.OrdVerifierRequestList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetOrdPayType()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		List<SelectListItem> list2 = new List<SelectListItem>();
		try
		{
			list = GetOrderPayList();
			list2 = GetOrderPayList();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.OrdPayTypeList = list;
		base.ViewBag.PordPayTypeList = list2;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetShpCartPayType()
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
			list.Add(new SelectListItem
			{
				Text = Labels.FoSettingShpCartPayTypeOnSpot,
				Value = "1",
				Selected = false
			});
			if (VersionBuyer.OnlinePay)
			{
				list.Add(new SelectListItem
				{
					Text = Labels.FoSettingShpCartPayTypeOnline,
					Value = "2",
					Selected = false
				});
			}
			list.Add(new SelectListItem
			{
				Text = Labels.FoSettingShpCartPayTypePrePayment,
				Value = "3",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.FoSettingShpCartPayTypeMoneyBag,
				Value = "4",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.FoSettingShpCartPayTypeBasaWallet,
				Value = "5",
				Selected = false
			});
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ShpCartPayTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public List<SelectListItem> GetActiveUserList(bool addSaleCenterResponsibleUser = false)
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
			if (addSaleCenterResponsibleUser)
			{
				List<CRMspSelectUsersByIds_Result> list2 = CRMIdeal.Classes.Helper.User.SelectUsersByIds("-109");
				if (list2 != null)
				{
					list.AddRange(Enumerable.Select<CRMspSelectUsersByIds_Result, SelectListItem>((IEnumerable<CRMspSelectUsersByIds_Result>)Enumerable.ToList<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list2), (Func<CRMspSelectUsersByIds_Result, SelectListItem>)((CRMspSelectUsersByIds_Result i) => new SelectListItem
					{
						Text = (i.FullName ?? ""),
						Value = i.UserId.ToString(),
						Selected = false
					})));
					SelectListItem item2 = new SelectListItem
					{
						Text = "--------------------",
						Value = "",
						Selected = false
					};
					list.Add(item2);
				}
			}
			List<CRMspSelectActiveUsers_Result> list3 = Enumerable.ToList<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)db.CRMspSelectActiveUsers(lCID, result, result2));
			if (list3 != null && Enumerable.Any<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)list3))
			{
				list.AddRange(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)list3, (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result item) => new SelectListItem
				{
					Text = (item.Name ?? ""),
					Value = item.UserId.ToString(),
					Selected = false
				})));
			}
			if (list == null)
			{
				list = new List<SelectListItem>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public JsonResult GetPordAndOrdReferUser()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		List<SelectListItem> list2 = new List<SelectListItem>();
		try
		{
			list = GetActiveUserList(addSaleCenterResponsibleUser: true);
			list2 = GetActiveUserList(addSaleCenterResponsibleUser: true);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PordReferUserList = list;
		base.ViewBag.OrdReferUserList = list2;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public List<SelectListItem> GetVerificationWorkFlowList(int objectType)
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
			List<WSspSelectVerificationWorkFlowWithObjectType_Result> list2 = Enumerable.ToList<WSspSelectVerificationWorkFlowWithObjectType_Result>((IEnumerable<WSspSelectVerificationWorkFlowWithObjectType_Result>)db.WSspSelectVerificationWorkFlowWithObjectType(objectType, lCID, result));
			if (list2 != null && Enumerable.Any<WSspSelectVerificationWorkFlowWithObjectType_Result>((IEnumerable<WSspSelectVerificationWorkFlowWithObjectType_Result>)list2))
			{
				list.AddRange(Enumerable.Select<WSspSelectVerificationWorkFlowWithObjectType_Result, SelectListItem>((IEnumerable<WSspSelectVerificationWorkFlowWithObjectType_Result>)list2, (Func<WSspSelectVerificationWorkFlowWithObjectType_Result, SelectListItem>)((WSspSelectVerificationWorkFlowWithObjectType_Result item) => new SelectListItem
				{
					Text = (item.VerificationWorkFlowTitle ?? ""),
					Value = item.VerificationWorkFlowId.ToString(),
					Selected = false
				})));
			}
			if (list == null)
			{
				list = new List<SelectListItem>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public JsonResult GetPordAndOrdVerificationWorkFlow()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		List<SelectListItem> list2 = new List<SelectListItem>();
		try
		{
			list = GetVerificationWorkFlowList(10);
			list2 = GetVerificationWorkFlowList(20);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PordVerificationWorkFloList = list;
		base.ViewBag.OrdVerificationWorkFloList = list2;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public List<SelectListItem> GetGsmModelSettingList()
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
			List<SmsspSelectGSMModemSetting_Result> list2 = Enumerable.ToList<SmsspSelectGSMModemSetting_Result>((IEnumerable<SmsspSelectGSMModemSetting_Result>)db.SmsspSelectGSMModemSetting());
			if (list2 != null && Enumerable.Any<SmsspSelectGSMModemSetting_Result>((IEnumerable<SmsspSelectGSMModemSetting_Result>)list2))
			{
				list.AddRange(Enumerable.Select<SmsspSelectGSMModemSetting_Result, SelectListItem>((IEnumerable<SmsspSelectGSMModemSetting_Result>)list2, (Func<SmsspSelectGSMModemSetting_Result, SelectListItem>)((SmsspSelectGSMModemSetting_Result item) => new SelectListItem
				{
					Text = (item.DeviceName ?? ""),
					Value = item.ID.ToString(),
					Selected = false
				})));
			}
			if (list == null)
			{
				list = new List<SelectListItem>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public JsonResult GetPordAndOrdGsmModelSetting()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		List<SelectListItem> list2 = new List<SelectListItem>();
		List<SelectListItem> list3 = new List<SelectListItem>();
		List<SelectListItem> list4 = new List<SelectListItem>();
		try
		{
			list = GetGsmModelSettingList();
			list2 = GetGsmModelSettingList();
			list3 = GetGsmModelSettingList();
			list4 = GetGsmModelSettingList();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PordGsmModelSettingList = list;
		base.ViewBag.OrdGsmModelSettingList = list2;
		base.ViewBag.PordAfterVerifyGsmModelSettingList = list3;
		base.ViewBag.OrdAfterVerifyGsmModelSettingList = list4;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public List<SelectListItem> GetSmsProviderList()
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
			List<SmsspSelectActiveProviders_Result> list2 = Enumerable.ToList<SmsspSelectActiveProviders_Result>((IEnumerable<SmsspSelectActiveProviders_Result>)db.SmsspSelectActiveProviders());
			if (list2 != null && Enumerable.Any<SmsspSelectActiveProviders_Result>((IEnumerable<SmsspSelectActiveProviders_Result>)list2))
			{
				list.AddRange(Enumerable.Select<SmsspSelectActiveProviders_Result, SelectListItem>((IEnumerable<SmsspSelectActiveProviders_Result>)list2, (Func<SmsspSelectActiveProviders_Result, SelectListItem>)((SmsspSelectActiveProviders_Result item) => new SelectListItem
				{
					Text = (item.ProviderName ?? ""),
					Value = item.Id.ToString(),
					Selected = false
				})));
			}
			if (list == null)
			{
				list = new List<SelectListItem>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public JsonResult GetPordAndOrdSmsProvider()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		List<SelectListItem> list2 = new List<SelectListItem>();
		List<SelectListItem> list3 = new List<SelectListItem>();
		List<SelectListItem> list4 = new List<SelectListItem>();
		try
		{
			list = GetSmsProviderList();
			list2 = GetSmsProviderList();
			list3 = GetSmsProviderList();
			list4 = GetSmsProviderList();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PordSmsProviderList = list;
		base.ViewBag.OrdSmsProviderList = list2;
		base.ViewBag.PordSmsAfterVerifyProviderList = list3;
		base.ViewBag.OrdSmsAfterVerifyProviderList = list4;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public List<SelectListItem> GetEmailSettingListI()
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
			List<EmailSetting> list2 = Enumerable.ToList<EmailSetting>((IEnumerable<EmailSetting>)_dbTbl.EmailSetting);
			if (list2 != null && Enumerable.Any<EmailSetting>((IEnumerable<EmailSetting>)list2))
			{
				list.AddRange(Enumerable.Select<EmailSetting, SelectListItem>((IEnumerable<EmailSetting>)list2, (Func<EmailSetting, SelectListItem>)((EmailSetting item) => new SelectListItem
				{
					Text = item.EmailSettingId.ToString(),
					Value = item.EmailSettingId.ToString(),
					Selected = false
				})));
			}
			if (list == null)
			{
				list = new List<SelectListItem>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public JsonResult GetPordAndOrdEmailSetting()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		List<SelectListItem> list2 = new List<SelectListItem>();
		try
		{
			list = GetEmailSettingListI();
			list2 = GetEmailSettingListI();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PordEmailSettingList = list;
		base.ViewBag.OrdEmailSettingList = list2;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public List<SelectListItem> GetEmailUserInfoList()
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
			List<EmailspSelectAllActiveEmailUsersInfo_Result> list2 = Enumerable.ToList<EmailspSelectAllActiveEmailUsersInfo_Result>((IEnumerable<EmailspSelectAllActiveEmailUsersInfo_Result>)_dbI.EmailspSelectAllActiveEmailUsersInfo(lCID, result));
			if (list2 != null && Enumerable.Any<EmailspSelectAllActiveEmailUsersInfo_Result>((IEnumerable<EmailspSelectAllActiveEmailUsersInfo_Result>)list2))
			{
				list.AddRange(Enumerable.Select<EmailspSelectAllActiveEmailUsersInfo_Result, SelectListItem>((IEnumerable<EmailspSelectAllActiveEmailUsersInfo_Result>)list2, (Func<EmailspSelectAllActiveEmailUsersInfo_Result, SelectListItem>)((EmailspSelectAllActiveEmailUsersInfo_Result item) => new SelectListItem
				{
					Text = item.euUserName + ((!string.IsNullOrWhiteSpace(item.euUser)) ? (" [" + item.euUser + "]") : ""),
					Value = item.EmailUsersInfoId.ToString(),
					Selected = false
				})));
			}
			if (list == null)
			{
				list = new List<SelectListItem>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public JsonResult GetPordAndOrdEmailUserInfo()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		List<SelectListItem> list2 = new List<SelectListItem>();
		try
		{
			list = GetEmailUserInfoList();
			list2 = GetEmailUserInfoList();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PordEmailUserInfoList = list;
		base.ViewBag.OrdEmailUserInfoList = list2;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public List<SelectListItem> GetOrderPayList()
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
			if (list2 != null && Enumerable.Any<WSspSelectActiveOrderPaymentTypes_Result>((IEnumerable<WSspSelectActiveOrderPaymentTypes_Result>)list2))
			{
				list.AddRange(Enumerable.Select<WSspSelectActiveOrderPaymentTypes_Result, SelectListItem>((IEnumerable<WSspSelectActiveOrderPaymentTypes_Result>)list2, (Func<WSspSelectActiveOrderPaymentTypes_Result, SelectListItem>)((WSspSelectActiveOrderPaymentTypes_Result item) => new SelectListItem
				{
					Text = item.ordpayType,
					Value = item.OrderPaymentTypeId.ToString(),
					Selected = false
				})));
			}
			if (list == null)
			{
				list = new List<SelectListItem>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public List<SelectListItem> GetCreditDurationList()
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
			List<WSspSelectCreditDuration_Result> list2 = Enumerable.ToList<WSspSelectCreditDuration_Result>((IEnumerable<WSspSelectCreditDuration_Result>)db.WSspSelectCreditDuration(lCID, result));
			if (list2 != null && Enumerable.Any<WSspSelectCreditDuration_Result>((IEnumerable<WSspSelectCreditDuration_Result>)list2))
			{
				list.AddRange(Enumerable.Select<WSspSelectCreditDuration_Result, SelectListItem>((IEnumerable<WSspSelectCreditDuration_Result>)list2, (Func<WSspSelectCreditDuration_Result, SelectListItem>)((WSspSelectCreditDuration_Result item) => new SelectListItem
				{
					Text = (item.CreditDuration ?? ""),
					Value = item.CreditDurationID.ToString(),
					Selected = false
				})));
			}
			if (list == null)
			{
				list = new List<SelectListItem>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public JsonResult GetPordCreditDuration()
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
			list = GetCreditDurationList();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PordCreditDurationList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public List<SelectListItem> GetPrintFormatList(int printFormatTypeId)
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
			List<spSelectPrintFormat_Result> list2 = CRMIdeal.Classes.Helper.PrintFormat.GetspPrintFortants(result2, printFormatTypeId);
			if (list2 != null && Enumerable.Any<spSelectPrintFormat_Result>((IEnumerable<spSelectPrintFormat_Result>)list2))
			{
				list.AddRange(Enumerable.Select<spSelectPrintFormat_Result, SelectListItem>((IEnumerable<spSelectPrintFormat_Result>)list2, (Func<spSelectPrintFormat_Result, SelectListItem>)((spSelectPrintFormat_Result item) => new SelectListItem
				{
					Text = (item.Title ?? ""),
					Value = item.PrintFormatID.ToString(),
					Selected = false
				})));
			}
			if (list == null)
			{
				list = new List<SelectListItem>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public JsonResult GetPordAndOrdPrintFormat()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		List<SelectListItem> list2 = new List<SelectListItem>();
		try
		{
			list = GetPrintFormatList(1);
			list2 = GetPrintFormatList(2);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PordPrintFormatList = list;
		base.ViewBag.OrdPrintFormatList = list2;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public string ChkBeforeSubmitFoSetting(CrmFoSettingLanguageViewModel model, List<CommonMultiLanguageViewModel> listModelObj_PrjDefaultTitle_Lang, List<CommonMultiLanguageViewModel> listModelObj_CnvsDefaultDesc_Lang, ref int countError)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		if (model.PrjDefaultTitle == null && model.PrjDefaultTitle == "")
		{
			text = text + Messages.CheckprjTitle + "<br/>";
			countError++;
		}
		else if (!checkMultiLanguage(model.PrjDefaultTitle, listModelObj_PrjDefaultTitle_Lang))
		{
			text = text + text + Messages.CheckprjTitleLang + "<br>";
			countError++;
		}
		if (string.IsNullOrEmpty(model.CnvsDefaultDesc))
		{
			countError++;
			text = text + Messages.CheckEmptycnvsDesc + "<br>";
		}
		else if (!checkMultiLanguage(model.CnvsDefaultDesc, listModelObj_CnvsDefaultDesc_Lang))
		{
			text = text + text + Messages.CheckcnvsDescLang + "<br>";
			countError++;
		}
		_ = model.CmpDefaultReferUserId;
		if (model.CmpDefaultReferUserId == 0)
		{
			countError++;
			text = text + Messages.CheckEmptycmpReferUserId + "<br>";
		}
		_ = model.CnvsDefaultTopicId;
		if (model.CnvsDefaultTopicId == 0)
		{
			countError++;
			text = text + Messages.CheckEmptycnvsTopicId + "<br>";
		}
		_ = model.CnvsDefaultUserId;
		if (model.CnvsDefaultUserId == 0)
		{
			countError++;
			text = text + Messages.CheckEmptycnvsUserId + "<br>";
		}
		_ = model.CnvsDefaultReferUserId;
		if (model.CnvsDefaultReferUserId == 0)
		{
			countError++;
			text = text + Messages.CheckEmptycnvsReferUserId + "<br>";
		}
		_ = model.CnvsDefaultStatusId;
		if (model.CnvsDefaultStatusId == 0)
		{
			countError++;
			text = text + Messages.CheckEmptycnvsStatusId + "<br>";
		}
		_ = model.PrjDefaultCnvsStatusGroupId;
		if (model.PrjDefaultCnvsStatusGroupId == 0)
		{
			text = text + Messages.CheckprjcnvsStatusGroupId + "<br/>";
			countError++;
		}
		_ = model.PrjDefaultStarterUserId;
		if (model.PrjDefaultStarterUserId == 0)
		{
			text = text + Messages.CheckprjStarterUserId + "<br>";
			countError++;
		}
		return text;
	}

	public string ChkBeforeSubmitFoSettingRegister(CRMspSelectFoSettingRegisterWithId_Result model, List<CommonMultiLanguageViewModel> listModelObj_PrjDefaultTitle_Lang, List<CommonMultiLanguageViewModel> listModelObj_CnvsDefaultDesc_Lang, ref int countError)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		if (model.PrjDefaultTitle == null && model.PrjDefaultTitle == "")
		{
			text = text + Messages.CheckprjTitle + "<br/>";
			countError++;
		}
		else if (!checkMultiLanguage(model.PrjDefaultTitle, listModelObj_PrjDefaultTitle_Lang))
		{
			text = text + text + Messages.CheckprjTitleLang + "<br>";
			countError++;
		}
		if (string.IsNullOrEmpty(model.CnvsDefaultDesc))
		{
			countError++;
			text = text + Messages.CheckEmptycnvsDesc + "<br>";
		}
		else if (!checkMultiLanguage(model.CnvsDefaultDesc, listModelObj_CnvsDefaultDesc_Lang))
		{
			text = text + text + Messages.CheckcnvsDescLang + "<br>";
			countError++;
		}
		_ = model.CmpDefaultReferUserId;
		if (model.CmpDefaultReferUserId == 0)
		{
			countError++;
			text = text + Messages.CheckEmptycmpReferUserId + "<br>";
		}
		_ = model.CnvsDefaultTopicId;
		if (model.CnvsDefaultTopicId == 0)
		{
			countError++;
			text = text + Messages.CheckEmptycnvsTopicId + "<br>";
		}
		_ = model.CnvsDefaultUserId;
		if (model.CnvsDefaultUserId == 0)
		{
			countError++;
			text = text + Messages.CheckEmptycnvsUserId + "<br>";
		}
		_ = model.CnvsDefaultReferUserId;
		if (model.CnvsDefaultReferUserId == 0)
		{
			countError++;
			text = text + Messages.CheckEmptycnvsReferUserId + "<br>";
		}
		_ = model.CnvsDefaultStatusId;
		if (model.CnvsDefaultStatusId == 0)
		{
			countError++;
			text = text + Messages.CheckEmptycnvsStatusId + "<br>";
		}
		if (!model.CnvsDefaultStatusResultId.HasValue || model.CnvsDefaultStatusResultId == 0)
		{
			countError++;
			text = text + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.FoSettingCnvsDefaultStatusResult) + "<br>";
		}
		_ = model.PrjDefaultCnvsStatusGroupId;
		if (model.PrjDefaultCnvsStatusGroupId == 0)
		{
			text = text + Messages.CheckprjcnvsStatusGroupId + "<br/>";
			countError++;
		}
		_ = model.PrjDefaultStarterUserId;
		if (model.PrjDefaultStarterUserId == 0)
		{
			text = text + Messages.CheckprjStarterUserId + "<br>";
			countError++;
		}
		return text;
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

	public void SetRegisterInfo(CrmFoSettingLanguageViewModel model)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		string text2 = "";
		try
		{
			string text3 = "";
			string text4 = "";
			_ = model.FirstRegisterUserId;
			string text5 = model.FirstRegisterUserId.ToString();
			_ = model.UserId;
			List<CRMspSelectUsersByIds_Result> list = CRMIdeal.Classes.Helper.User.SelectUsersByIds(text5 + "," + model.UserId);
			if (Enumerable.Any<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list))
			{
				CrmFoSettingLanguageViewModel crmFoSettingLanguageViewModel = model;
				_ = model.FirstRegisterUserId;
				crmFoSettingLanguageViewModel.FirstRegisterUserId = model.FirstRegisterUserId;
				CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.FirstRegisterUserId));
				text3 = ((cRMspSelectUsersByIds_Result != null) ? (cRMspSelectUsersByIds_Result.LName + ((cRMspSelectUsersByIds_Result.FName != null) ? (" " + cRMspSelectUsersByIds_Result.FName) : "")) : "");
				CrmFoSettingLanguageViewModel crmFoSettingLanguageViewModel2 = model;
				_ = model.UserId;
				crmFoSettingLanguageViewModel2.UserId = model.UserId;
				CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result2 = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.UserId));
				text4 = ((cRMspSelectUsersByIds_Result2 != null) ? (cRMspSelectUsersByIds_Result2.LName + ((cRMspSelectUsersByIds_Result2.FName != null) ? (" " + cRMspSelectUsersByIds_Result2.FName) : "")) : "");
			}
			_ = model.FirstRegisterDate;
			string text6 = model.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
			_ = model.RegisterDate;
			string text7 = model.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
			if (string.IsNullOrEmpty(model.AppType))
			{
				model.AppType = Configuration.AppType;
			}
			string text8 = Labels.AppType + ": " + Configuration.GetAppType(model.AppType);
			text = Labels.frmFirstRegisterUser + ": " + text3 + " (" + text6 + ")";
			text2 = Labels.frmRegisterUser + ": " + text4 + " (" + text8 + ") (" + text7 + ")";
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.FirstRegisterInfo = text;
		base.ViewBag.EditInfo = text2;
	}

	public void SetRegisterInfoRegister(CRMspSelectFoSettingRegisterWithId_Result model)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		string text2 = "";
		try
		{
			string text3 = "";
			string text4 = "";
			_ = model.FirstRegisterUserId;
			string text5 = model.FirstRegisterUserId.ToString();
			_ = model.UserId;
			List<CRMspSelectUsersByIds_Result> list = CRMIdeal.Classes.Helper.User.SelectUsersByIds(text5 + "," + model.UserId);
			if (Enumerable.Any<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list))
			{
				CRMspSelectFoSettingRegisterWithId_Result cRMspSelectFoSettingRegisterWithId_Result = model;
				_ = model.FirstRegisterUserId;
				cRMspSelectFoSettingRegisterWithId_Result.FirstRegisterUserId = model.FirstRegisterUserId;
				CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.FirstRegisterUserId));
				text3 = ((cRMspSelectUsersByIds_Result != null) ? (cRMspSelectUsersByIds_Result.LName + ((cRMspSelectUsersByIds_Result.FName != null) ? (" " + cRMspSelectUsersByIds_Result.FName) : "")) : "");
				CRMspSelectFoSettingRegisterWithId_Result cRMspSelectFoSettingRegisterWithId_Result2 = model;
				_ = model.UserId;
				cRMspSelectFoSettingRegisterWithId_Result2.UserId = model.UserId;
				CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result2 = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.UserId));
				text4 = ((cRMspSelectUsersByIds_Result2 != null) ? (cRMspSelectUsersByIds_Result2.LName + ((cRMspSelectUsersByIds_Result2.FName != null) ? (" " + cRMspSelectUsersByIds_Result2.FName) : "")) : "");
			}
			_ = model.FirstRegisterDate;
			string text6 = model.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
			_ = model.RegisterDate;
			string text7 = model.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
			if (string.IsNullOrEmpty(model.AppType))
			{
				model.AppType = Configuration.AppType;
			}
			string text8 = Labels.AppType + ": " + Configuration.GetAppType(model.AppType);
			text = Labels.frmFirstRegisterUser + ": " + text3 + " (" + text6 + ")";
			text2 = Labels.frmRegisterUser + ": " + text4 + " (" + text8 + ") (" + text7 + ")";
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.FirstRegisterInfo = text;
		base.ViewBag.EditInfo = text2;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actFoSetting")]
	public ActionResult SetTicketSubjectDefaultContext()
	{
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actFoSetting")]
	public ActionResult SelectReferMultiUsers(int referUserId = 0, string referMultiUser = "", string partName = "")
	{
		base.ViewBag.ReferMultiUser = referMultiUser;
		base.ViewBag.ReferUserId = referUserId;
		base.ViewBag.PartName = partName;
		GetUsersList(referUserId, referMultiUser);
		return View();
	}

	[AjaxOnly]
	public JsonResult GetUsersList(int referUserId, string referMultiUser = "")
	{
		List<CommonMultiSelectorViewModel> list = new List<CommonMultiSelectorViewModel>();
		try
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
			foreach (CRMspSelectActiveUsers_Result item in (referUserId > 0) ? Enumerable.ToList<CRMspSelectActiveUsers_Result>(Enumerable.Where<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)db.CRMspSelectActiveUsers(lCID, result, result2), (Func<CRMspSelectActiveUsers_Result, bool>)((CRMspSelectActiveUsers_Result m) => m.UserId > 0 && m.UserId != referUserId))) : Enumerable.ToList<CRMspSelectActiveUsers_Result>(Enumerable.Where<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)db.CRMspSelectActiveUsers(lCID, result, result2), (Func<CRMspSelectActiveUsers_Result, bool>)((CRMspSelectActiveUsers_Result m) => m.UserId > 0))))
			{
				CommonMultiSelectorViewModel commonMultiSelectorViewModel = new CommonMultiSelectorViewModel();
				bool flag = false;
				if (!string.IsNullOrEmpty(referMultiUser))
				{
					string[] array = referMultiUser.Split(new char[1] { ',' });
					if (Enumerable.Any<string>((IEnumerable<string>)array))
					{
						string[] array2 = array;
						foreach (string text in array2)
						{
							if (!string.IsNullOrEmpty(text) && item.UserId == int.Parse(text))
							{
								flag = true;
							}
						}
					}
				}
				if (flag)
				{
					commonMultiSelectorViewModel.Name = item.Name ?? "";
					commonMultiSelectorViewModel.Selected = true;
					commonMultiSelectorViewModel.Id = item.UserId;
				}
				else
				{
					commonMultiSelectorViewModel.Name = item.Name ?? "";
					commonMultiSelectorViewModel.Selected = false;
					commonMultiSelectorViewModel.Id = item.UserId;
				}
				list.Add(commonMultiSelectorViewModel);
			}
			base.ViewBag.ReferUsersList = list;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public string TransferPrdGallery()
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
			FilesManager filesManager = new FilesManager();
			FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
			string pathFtp = Configuration.PathFtp;
			string userNameFtp = Configuration.UserNameFtp;
			string passwordFtp = Configuration.PasswordFtp;
			bool usePassiveFtp = Configuration.UsePassiveFtp;
			string pathFtpFo = Configuration.PathFtpFo;
			string userNameFtpFo = Configuration.UserNameFtpFo;
			string passwordFtpFo = Configuration.PasswordFtpFo;
			bool usePassiveFtpFo = Configuration.UsePassiveFtpFo;
			if (string.IsNullOrEmpty(pathFtpFo) || string.IsNullOrEmpty(userNameFtpFo) || string.IsNullOrEmpty(passwordFtpFo))
			{
				return Messages.msgErrorFtpFONotDefined;
			}
			bool flag = false;
			List<WSspSelectProductGallery_Result> list = Enumerable.ToList<WSspSelectProductGallery_Result>((IEnumerable<WSspSelectProductGallery_Result>)db.WSspSelectProductGallery(0));
			if (Enumerable.Any<WSspSelectProductGallery_Result>((IEnumerable<WSspSelectProductGallery_Result>)list))
			{
				foreach (WSspSelectProductGallery_Result item in list)
				{
					string text = "";
					if (item == null || string.IsNullOrEmpty(item.FilePath) || string.IsNullOrEmpty(item.FileName))
					{
						continue;
					}
					string text2 = item.FilePath.ToLower().Replace(Configuration.PathFtp.ToLower(), "");
					bool flag2 = false;
					string text3 = "/" + Configuration.PrdDirectoryPath;
					string text4 = text2;
					text4 = text4.Replace((Configuration.MainDirectoryPath + Configuration.PrdDirectoryPath).ToLower(), "");
					if (!string.IsNullOrEmpty(text4))
					{
						string[] array = text4.Split(new char[1] { '/' });
						if (Enumerable.Any<string>((IEnumerable<string>)array))
						{
							for (int i = 0; i < array.Length - 1; i++)
							{
								if (!string.IsNullOrEmpty(array[i]) && array[i].IndexOf(".", StringComparison.Ordinal) <= 0)
								{
									text3 = text3 + array[i] + "/";
								}
							}
						}
						flag2 = filesManager.CreateDirectory(text3);
					}
					if (!flag2)
					{
						continue;
					}
					bool flag3 = false;
					string text5 = text3 + item.FileName;
					text = HttpContext.Current.Server.MapPath(text5);
					if (!System.IO.File.Exists(text))
					{
						flag3 = facadeFTP.Download(pathFtp, userNameFtp, passwordFtp, text, text2, overwrite: true, usePassiveFtp);
						if (flag3)
						{
							flag = true;
						}
					}
					if (flag3 && System.IO.File.Exists(text) && item.FileName.IndexOf(".") > 0 && item.IsMain.GetValueOrDefault())
					{
						string fileName = item.FileName;
						fileName = fileName.Insert(item.FileName.IndexOf("."), "-Thumb");
						string text6 = HttpContext.Current.Server.MapPath(text3 + fileName);
						if (!System.IO.File.Exists(text6))
						{
							ImageFormat format = SetImageFormat(item.FileName);
							ResizeImage(text, text6, format, _PrdPicWidth, _PrdPicHeight);
						}
					}
				}
			}
			if (flag)
			{
				string prdDirectoryPath = Configuration.PrdDirectoryPath;
				prdDirectoryPath = prdDirectoryPath.Replace("/", "");
				bool flag4 = facadeFTP.ExistsDirectoryInFtp(pathFtpFo, userNameFtpFo, passwordFtpFo, "/", prdDirectoryPath, usePassiveFtpFo);
				if (!flag4)
				{
					flag4 = facadeFTP.CreateDirectoryInFtp(pathFtpFo, userNameFtpFo, passwordFtpFo, "/", prdDirectoryPath, usePassiveFtpFo);
				}
				if (flag4)
				{
					bool usePassive = usePassiveFtpFo;
					facadeFTP.UploadFtpAllContents(pathFtpFo, userNameFtpFo, passwordFtpFo, "/" + prdDirectoryPath, "/" + prdDirectoryPath, usePassive);
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = Messages.FOMsgErrorDoneOperation + "<br>" + ex.Message;
		}
		return result;
	}

	public ImageFormat SetImageFormat(string fileName)
	{
		ImageFormat result = ImageFormat.Png;
		if (string.IsNullOrEmpty(fileName))
		{
			return result;
		}
		string[] array = fileName.Split(new char[1] { '.' });
		if (Enumerable.Any<string>((IEnumerable<string>)array) && array.Length == 2)
		{
			switch (array[1].ToLower())
			{
			case "jpeg":
			case "jpg":
				result = ImageFormat.Jpeg;
				break;
			case "png":
				result = ImageFormat.Png;
				break;
			case "gif":
				result = ImageFormat.Gif;
				break;
			case "tiff":
				result = ImageFormat.Tiff;
				break;
			case "bmp":
				result = ImageFormat.Bmp;
				break;
			default:
				result = ImageFormat.Png;
				break;
			}
		}
		return result;
	}

	public static bool ResizeImage(string orgFile, string resizedFile, ImageFormat format, int width, int height)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Image val = Image.FromFile(orgFile);
			try
			{
				Bitmap val2 = new Bitmap(width, height, val.PixelFormat);
				Graphics obj = Graphics.FromImage((Image)val2);
				obj.CompositingQuality = (CompositingQuality)2;
				obj.SmoothingMode = (SmoothingMode)2;
				obj.InterpolationMode = (InterpolationMode)7;
				obj.PixelOffsetMode = (PixelOffsetMode)2;
				Rectangle val3 = default(Rectangle);
				((Rectangle)(ref val3))._002Ector(0, 0, width, height);
				obj.DrawImage(val, val3);
				((Image)val2).Save(resizedFile, format);
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
			return true;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return false;
		}
	}

	[AjaxOnly]
	public string TransferNewsPicture()
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
			FilesManager filesManager = new FilesManager();
			FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
			string pathFtp = Configuration.PathFtp;
			string userNameFtp = Configuration.UserNameFtp;
			string passwordFtp = Configuration.PasswordFtp;
			bool usePassiveFtp = Configuration.UsePassiveFtp;
			string pathFtpFo = Configuration.PathFtpFo;
			string userNameFtpFo = Configuration.UserNameFtpFo;
			string passwordFtpFo = Configuration.PasswordFtpFo;
			bool usePassiveFtpFo = Configuration.UsePassiveFtpFo;
			if (string.IsNullOrEmpty(pathFtpFo) || string.IsNullOrEmpty(userNameFtpFo) || string.IsNullOrEmpty(passwordFtpFo))
			{
				return Messages.msgErrorFtpFONotDefined;
			}
			bool flag = false;
			List<CRMspCmsSelectNewsPicture_Result> list = Enumerable.ToList<CRMspCmsSelectNewsPicture_Result>((IEnumerable<CRMspCmsSelectNewsPicture_Result>)_dbI.CRMspCmsSelectNewsPicture(0, -110, 0, lCID, result2));
			if (Enumerable.Any<CRMspCmsSelectNewsPicture_Result>((IEnumerable<CRMspCmsSelectNewsPicture_Result>)list))
			{
				foreach (CRMspCmsSelectNewsPicture_Result item in list)
				{
					string text = "";
					if (item == null || string.IsNullOrEmpty(item.FilePath) || string.IsNullOrEmpty(item.FileName))
					{
						continue;
					}
					string text2 = item.FilePath.ToLower().Replace(Configuration.PathFtp.ToLower(), "");
					bool flag2 = false;
					string text3 = "/" + Configuration.CmsNewsDirectoryPath;
					string text4 = text2;
					text4 = text4.Replace((Configuration.MainDirectoryPath + Configuration.CmsNewsDirectoryPath).ToLower(), "");
					if (!string.IsNullOrEmpty(text4))
					{
						string[] array = text4.Split(new char[1] { '/' });
						if (Enumerable.Any<string>((IEnumerable<string>)array))
						{
							for (int i = 0; i < array.Length - 1; i++)
							{
								if (!string.IsNullOrEmpty(array[i]) && array[i].IndexOf(".", StringComparison.Ordinal) <= 0)
								{
									text3 = text3 + array[i] + "/";
								}
							}
						}
						flag2 = filesManager.CreateDirectory(text3);
					}
					if (!flag2)
					{
						continue;
					}
					bool flag3 = false;
					string text5 = text3 + item.FileName;
					text = HttpContext.Current.Server.MapPath(text5);
					if (!System.IO.File.Exists(text))
					{
						flag3 = facadeFTP.Download(pathFtp, userNameFtp, passwordFtp, text, text2, overwrite: true, usePassiveFtp);
						if (flag3)
						{
							flag = true;
						}
					}
					if (flag3 && System.IO.File.Exists(text) && item.FileName.IndexOf(".") > 0)
					{
						string fileName = item.FileName;
						fileName = fileName.Insert(item.FileName.IndexOf("."), "-Thumb");
						string text6 = HttpContext.Current.Server.MapPath(text3 + fileName);
						if (!System.IO.File.Exists(text6))
						{
							ImageFormat format = SetImageFormat(item.FileName);
							ResizeImage(text, text6, format, _NewsPicWidth, _NewsPicHeight);
						}
					}
				}
			}
			if (flag)
			{
				string cmsNewsDirectoryPath = Configuration.CmsNewsDirectoryPath;
				cmsNewsDirectoryPath = cmsNewsDirectoryPath.Replace("/", "");
				bool flag4 = facadeFTP.ExistsDirectoryInFtp(pathFtpFo, userNameFtpFo, passwordFtpFo, "/", cmsNewsDirectoryPath, usePassiveFtpFo);
				if (!flag4)
				{
					flag4 = facadeFTP.CreateDirectoryInFtp(pathFtpFo, userNameFtpFo, passwordFtpFo, "/", cmsNewsDirectoryPath, usePassiveFtpFo);
				}
				if (flag4)
				{
					bool usePassive = usePassiveFtpFo;
					facadeFTP.UploadFtpAllContents(pathFtpFo, userNameFtpFo, passwordFtpFo, "/" + cmsNewsDirectoryPath, "/" + cmsNewsDirectoryPath, usePassive);
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = Messages.FOMsgErrorDoneOperation + "<br>" + ex.Message;
		}
		return result;
	}

	[AjaxOnly]
	public string TransferAllImagesToFo(string dirName)
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
			new FilesManager();
			FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtpFo);
			string pathFtpFo = Configuration.PathFtpFo;
			string userNameFtpFo = Configuration.UserNameFtpFo;
			string passwordFtpFo = Configuration.PasswordFtpFo;
			bool usePassiveFtpFo = Configuration.UsePassiveFtpFo;
			if (string.IsNullOrEmpty(pathFtpFo) || string.IsNullOrEmpty(userNameFtpFo) || string.IsNullOrEmpty(passwordFtpFo))
			{
				return Messages.msgErrorFtpFONotDefined;
			}
			bool flag = false;
			string hostTempFilesPath = Configuration.HostTempFilesPath;
			hostTempFilesPath = hostTempFilesPath.Replace("~", "");
			bool flag2 = facadeFTP.ExistsDirectoryInFtp(pathFtpFo, userNameFtpFo, passwordFtpFo, "", hostTempFilesPath, usePassiveFtpFo);
			if (!flag2)
			{
				flag2 = facadeFTP.CreateDirectoryInFtp(pathFtpFo, userNameFtpFo, passwordFtpFo, "", hostTempFilesPath, usePassiveFtpFo);
			}
			if (flag2)
			{
				hostTempFilesPath += ((!string.IsNullOrEmpty(dirName)) ? ("/" + dirName) : "");
				flag2 = facadeFTP.ExistsDirectoryInFtp(pathFtpFo, userNameFtpFo, passwordFtpFo, "", hostTempFilesPath, usePassiveFtpFo);
				if (!flag2)
				{
					flag2 = facadeFTP.CreateDirectoryInFtp(pathFtpFo, userNameFtpFo, passwordFtpFo, "", hostTempFilesPath, usePassiveFtpFo);
				}
				if (flag2)
				{
					bool usePassive = usePassiveFtpFo;
					flag = facadeFTP.UploadFtpAllContents(pathFtpFo, userNameFtpFo, passwordFtpFo, hostTempFilesPath, hostTempFilesPath, usePassive);
				}
			}
			if (!flag)
			{
				result = Messages.msgErrorRunFunction;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = Messages.msgErrorRunFunction + "<br>" + ex.Message;
		}
		return result;
	}

	public static bool DownlaodFileFromFTP(string sourceFile, string filePath)
	{
		bool result = false;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			FilesManager filesManager = new FilesManager();
			FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
			string pathFtp = Configuration.PathFtp;
			string userNameFtp = Configuration.UserNameFtp;
			string passwordFtp = Configuration.PasswordFtp;
			bool usePassiveFtp = Configuration.UsePassiveFtp;
			if (!string.IsNullOrEmpty(sourceFile) && !string.IsNullOrEmpty(filePath))
			{
				string text = "";
				if (!string.IsNullOrEmpty(sourceFile))
				{
					string source = sourceFile.ToLower().Replace(Configuration.PathFtp.ToLower(), "");
					bool flag = false;
					string text2 = filePath;
					if (!string.IsNullOrEmpty(text2))
					{
						string[] array = text2.Split(new char[1] { '/' });
						text2 = "";
						if (Enumerable.Any<string>((IEnumerable<string>)array))
						{
							for (int i = 0; i < array.Length - 1; i++)
							{
								if (!string.IsNullOrEmpty(array[i]) && array[i].IndexOf(".", StringComparison.Ordinal) <= 0)
								{
									text2 = text2 + array[i] + "/";
								}
							}
						}
						flag = filesManager.CreateDirectory(text2);
					}
					if (flag)
					{
						bool flag2 = true;
						text = HttpContext.Current.Server.MapPath(filePath);
						if (!System.IO.File.Exists(text))
						{
							flag2 = facadeFTP.Download(pathFtp, userNameFtp, passwordFtp, text, source, overwrite: true, usePassiveFtp);
						}
						result = flag2;
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actFoSetting")]
	public ActionResult EditLoginSetting()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		int? cId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
		CrmFoLoginSettingLanguageViewModel crmFoLoginSettingLanguageViewModel = new CrmFoLoginSettingLanguageViewModel();
		_ = DateTime.Now;
		try
		{
			BaseInfo baseInfo = new BaseInfo();
			IEnumerable<CrmFoSetting_Lang> enumerable = Enumerable.Where<CrmFoSetting_Lang>((IEnumerable<CrmFoSetting_Lang>)Enumerable.ToList<CrmFoSetting_Lang>((IEnumerable<CrmFoSetting_Lang>)_dbTbl.CrmFoSetting_Lang), (Func<CrmFoSetting_Lang, bool>)((CrmFoSetting_Lang x) => x.CrmFoSetting.CId == cId));
			string positionTopRightTxt = Labels.PositionTopRightTxt;
			string positionTopCenterTxt = Labels.PositionTopCenterTxt;
			string positionTopLeftTxt = Labels.PositionTopLeftTxt;
			string positionCenterRightTxt = Labels.PositionCenterRightTxt;
			string positionCenterTxt = Labels.PositionCenterTxt;
			string positionCenterLeftTxt = Labels.PositionCenterLeftTxt;
			string positionBottomRightTxt = Labels.PositionBottomRightTxt;
			string positionBottomCenterTxt = Labels.PositionBottomCenterTxt;
			string positionBottomLeftTxt = Labels.PositionBottomLeftTxt;
			_ = Labels.SmsSendByWebTxt;
			_ = Labels.SmsSendByGsmTxt;
			CRMSpEntities cRMSpEntities = db;
			string foSettingDefDisplay4Column = Labels.FoSettingDefDisplay4Column;
			string foSettingDefDisplay3Column = Labels.FoSettingDefDisplay3Column;
			string foSettingDefDisplayListView = Labels.FoSettingDefDisplayListView;
			string foSettingDefDisplayListViewSmall = Labels.FoSettingDefDisplayListViewSmall;
			int? languageID = result;
			int? defaultLanguageID = result;
			CRMspSelectFoSetting_Result cRMspSelectFoSetting_Result = Enumerable.FirstOrDefault<CRMspSelectFoSetting_Result>((IEnumerable<CRMspSelectFoSetting_Result>)cRMSpEntities.CRMspSelectFoSetting(foSettingDefDisplay4Column, foSettingDefDisplay3Column, foSettingDefDisplayListView, foSettingDefDisplayListViewSmall, positionTopRightTxt, positionTopCenterTxt, positionTopLeftTxt, positionCenterRightTxt, positionCenterTxt, positionCenterLeftTxt, positionBottomRightTxt, positionBottomCenterTxt, positionBottomLeftTxt, languageID, defaultLanguageID, cId));
			if (cRMspSelectFoSetting_Result == null)
			{
				cRMspSelectFoSetting_Result = new CRMspSelectFoSetting_Result
				{
					FoSettingId = 0,
					PrdPriceVisible = false
				};
			}
			List<CommonMultiLanguageViewModel> list = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.LoginTitle,
				LanguageId = item.LanguageID
			})));
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = cRMspSelectFoSetting_Result.LoginTitle,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.LoginFormTitle,
				LanguageId = item.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = cRMspSelectFoSetting_Result.LoginFormTitle,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.LoginRegLinkTitle,
				LanguageId = item.LanguageID
			})));
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = cRMspSelectFoSetting_Result.LoginRegLinkTitle,
				LanguageId = result
			});
			crmFoLoginSettingLanguageViewModel = new CrmFoLoginSettingLanguageViewModel
			{
				FoSettingId = cRMspSelectFoSetting_Result.FoSettingId,
				LoginTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
				LoginTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
				LoginFormTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
				LoginFormTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
				LoginRegLinkTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
				LoginRegLinkTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
				LoginPosition = cRMspSelectFoSetting_Result.LoginPosition,
				LoginBgImagePath = cRMspSelectFoSetting_Result.LoginBgImagePath,
				LoginBgColor = baseInfo.DelphiCToRgbolor(cRMspSelectFoSetting_Result.LoginBgColor),
				LoginBtnBgColor = baseInfo.DelphiCToRgbolor(cRMspSelectFoSetting_Result.LoginBtnBgColor),
				LoginBtnFontColor = baseInfo.DelphiCToRgbolor(cRMspSelectFoSetting_Result.LoginBtnFontColor),
				LoginLinkColor = baseInfo.DelphiCToRgbolor(cRMspSelectFoSetting_Result.LoginLinkColor),
				LoginTextBorderFColor = baseInfo.DelphiCToRgbolor(cRMspSelectFoSetting_Result.LoginTextBorderFColor),
				LoginTextBorderTColor = baseInfo.DelphiCToRgbolor(cRMspSelectFoSetting_Result.LoginTextBorderTColor),
				LoginRegBtnHide = cRMspSelectFoSetting_Result.LoginRegBtnHide.GetValueOrDefault(),
				LoginAuthenticationType = cRMspSelectFoSetting_Result.LoginAuthenticationType,
				LoginType = cRMspSelectFoSetting_Result.LoginType,
				LoginSendOTPSms = cRMspSelectFoSetting_Result.LoginSendOTPSms,
				LoginSendOTPSmsBodyPatternFormula = cRMspSelectFoSetting_Result.LoginSendOTPSmsBodyPatternFormula,
				LoginAuthenticationInfoJson = cRMspSelectFoSetting_Result.LoginAuthenticationInfoJson,
				LoginByPassword = cRMspSelectFoSetting_Result.LoginByPassword,
				LoginByOTP = cRMspSelectFoSetting_Result.LoginByOTP,
				LoginByOTPSmsBodyPatternFormula = cRMspSelectFoSetting_Result.LoginByOTPSmsBodyPatternFormula,
				LoginAndFoActive = cRMspSelectFoSetting_Result.LoginAndFoActive,
				LoginAndShpActive = cRMspSelectFoSetting_Result.LoginAndShpActive
			};
			if (crmFoLoginSettingLanguageViewModel != null && !string.IsNullOrEmpty(crmFoLoginSettingLanguageViewModel.LoginBgImagePath))
			{
				string loginBgImagePath = crmFoLoginSettingLanguageViewModel.LoginBgImagePath;
				crmFoLoginSettingLanguageViewModel.LoginBgImagePath = crmFoLoginSettingLanguageViewModel.LoginBgImagePath.Replace(Configuration.MainDirectoryPath, "/");
				crmFoLoginSettingLanguageViewModel.LoginBgImagePath = Configuration.HostTempFilesPath + crmFoLoginSettingLanguageViewModel.LoginBgImagePath;
				if (!System.IO.File.Exists(base.Server.MapPath(crmFoLoginSettingLanguageViewModel.LoginBgImagePath)) && !DownlaodFileFromFTP(loginBgImagePath, crmFoLoginSettingLanguageViewModel.LoginBgImagePath))
				{
					crmFoLoginSettingLanguageViewModel.LoginBgImagePath = "";
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		GetPosition();
		return View(crmFoLoginSettingLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult EditLoginSetting(CrmFoLoginSettingLanguageViewModel model, HttpPostedFileBase urlUpload)
	{
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int? centerId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
		string text = "";
		int num = 0;
		GetPosition();
		try
		{
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.LoginTitle_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.LoginTitle_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = model.LoginTitle,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.LoginFormTitle_Lang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.LoginFormTitle_Lang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = model.LoginFormTitle,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.LoginRegLinkTitle_Lang))
			{
				list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.LoginRegLinkTitle_Lang);
			}
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = model.LoginRegLinkTitle,
				LanguageId = lCID
			});
			string loginTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : "");
			string loginFormTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : "");
			string loginRegLinkTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : "");
			string text2 = "";
			foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages m) => m.LanguageID != defLangID))))
			{
				string text3 = "";
				string text4 = "";
				string text5 = "";
				text3 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : "");
				text4 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : "");
				text5 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : "");
				text2 = text2 + "[LangId=" + lang.LanguageID + "|,|LoginTitle=" + text3 + "|,|LoginFormTitle=" + text4 + "|,|RegLinkTitle=" + text5 + "|,|]@";
			}
			BaseInfo baseInfo;
			DateTime now;
			int userId;
			string registerDatePersian;
			short value;
			short value2;
			string appType;
			string text6;
			if (base.ModelState.IsValid)
			{
				baseInfo = new BaseInfo();
				if (num == 0)
				{
					now = DateTime.Now;
					userId = UserLogin.CurrentUser.UserId;
					registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					value = short.Parse(Financial.Get().Id.ToString());
					value2 = short.Parse(now.ToString("MM", new PersianCulture()));
					appType = Configuration.AppType;
					text6 = "";
					string positionTopRightTxt = Labels.PositionTopRightTxt;
					string positionTopCenterTxt = Labels.PositionTopCenterTxt;
					string positionTopLeftTxt = Labels.PositionTopLeftTxt;
					string positionCenterRightTxt = Labels.PositionCenterRightTxt;
					string positionCenterTxt = Labels.PositionCenterTxt;
					string positionCenterLeftTxt = Labels.PositionCenterLeftTxt;
					string positionBottomRightTxt = Labels.PositionBottomRightTxt;
					string positionBottomCenterTxt = Labels.PositionBottomCenterTxt;
					string positionBottomLeftTxt = Labels.PositionBottomLeftTxt;
					_ = Labels.SmsSendByWebTxt;
					_ = Labels.SmsSendByGsmTxt;
					CRMSpEntities cRMSpEntities = db;
					string foSettingDefDisplay4Column = Labels.FoSettingDefDisplay4Column;
					string foSettingDefDisplay3Column = Labels.FoSettingDefDisplay3Column;
					string foSettingDefDisplayListView = Labels.FoSettingDefDisplayListView;
					string foSettingDefDisplayListViewSmall = Labels.FoSettingDefDisplayListViewSmall;
					int? languageID = defLangID;
					int? defaultLanguageID = defLangID;
					CRMspSelectFoSetting_Result cRMspSelectFoSetting_Result = Enumerable.FirstOrDefault<CRMspSelectFoSetting_Result>((IEnumerable<CRMspSelectFoSetting_Result>)cRMSpEntities.CRMspSelectFoSetting(foSettingDefDisplay4Column, foSettingDefDisplay3Column, foSettingDefDisplayListView, foSettingDefDisplayListViewSmall, positionTopRightTxt, positionTopCenterTxt, positionTopLeftTxt, positionCenterRightTxt, positionCenterTxt, positionCenterLeftTxt, positionBottomRightTxt, positionBottomCenterTxt, positionBottomLeftTxt, languageID, defaultLanguageID, centerId));
					if (cRMspSelectFoSetting_Result != null)
					{
						text6 = cRMspSelectFoSetting_Result.LoginBgImagePath;
					}
					if (urlUpload == null)
					{
						goto IL_0835;
					}
					string text7 = urlUpload.ContentType.ToLower();
					string text8 = Path.GetExtension(urlUpload.FileName).ToLower();
					if ((text7 != "image/jpg" && text7 != "image/jpeg" && text7 != "image/pjpeg" && text7 != "image/gif" && text7 != "image/x-png" && text7 != "image/png") || (text8 != ".jpg" && text8 != ".png" && text8 != ".gif" && text8 != ".jpeg"))
					{
						base.ModelState.AddModelError("error", Messages.frmErrorNotImageFile);
						return View(model);
					}
					FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
					string pathFtp = Configuration.PathFtp;
					string userNameFtp = Configuration.UserNameFtp;
					string passwordFtp = Configuration.PasswordFtp;
					bool usePassiveFtp = Configuration.UsePassiveFtp;
					string fileName = Path.GetFileName(urlUpload.FileName);
					string text9 = Configuration.MainDirectoryPath + Configuration.FoSettingDirectoryPath;
					string text10 = text9 + (text9.EndsWith("/") ? "" : "/");
					bool flag = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, Configuration.MainDirectoryPath, Configuration.FoSettingDirectoryPath, usePassiveFtp);
					if (!flag)
					{
						flag = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, Configuration.MainDirectoryPath, Configuration.FoSettingDirectoryPath, usePassiveFtp);
					}
					bool flag2 = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text10, "Login/", usePassiveFtp);
					if (!flag2)
					{
						flag2 = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text10, "Login/", usePassiveFtp);
					}
					if (!(flag && flag2))
					{
						goto IL_0835;
					}
					text10 += "Login/";
					string text11 = text10;
					text11 = text11.Replace(Configuration.MainDirectoryPath, "/");
					text11 = Configuration.HostTempFilesPath + text11;
					text11 = base.Server.MapPath(text11);
					if (!System.IO.Directory.Exists(text11))
					{
						System.IO.Directory.CreateDirectory(text11);
						CRM.General.IO.Directory.SetFullControlForEveryOne(text11);
					}
					if (System.IO.Directory.Exists(text11))
					{
						string text12 = text11 + "Initial-" + fileName;
						text11 += fileName;
						if (System.IO.File.Exists(text11))
						{
							System.IO.File.Delete(text11);
						}
						urlUpload.SaveAs(text12);
						if (System.IO.File.Exists(text12))
						{
							ImageFormat format = SetImageFormat(fileName);
							if (ResizeImage(text12, text11, format, _BgPicWidth, _BgPicHeight))
							{
								System.IO.File.Delete(text12);
							}
						}
					}
					if (!System.IO.File.Exists(text11))
					{
						goto IL_0835;
					}
					text10 += fileName;
					if (facadeFTP.UploadFtpFormTable(pathFtp, userNameFtp, passwordFtp, text10, text11, usePassiveFtp))
					{
						model.LoginBgImagePath = text10;
						goto IL_0835;
					}
					model.LoginBgImagePath = null;
					Exception e = new Exception(Messages.msgErrorUploadingFileInFtp + "  -  hostname: " + pathFtp + " ,username: " + userNameFtp + " ,destination: " + text10);
					ErrorSignal.FromCurrentContext().Raise(e);
					base.ModelState.AddModelError("error", Messages.frmErrorInSendingFile);
					base.ViewBag.Error = Messages.frmErrorInSendingFile;
				}
			}
			else
			{
				text = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
			goto end_IL_007d;
			IL_0835:
			if (!string.IsNullOrEmpty(model.LoginBgImagePath) && model.LoginBgImagePath.IndexOf(Configuration.HostTempFilesPath, StringComparison.Ordinal) >= 0)
			{
				model.LoginBgImagePath = model.LoginBgImagePath.Replace(Configuration.HostTempFilesPath + "/", "");
				model.LoginBgImagePath = Configuration.MainDirectoryPath + model.LoginBgImagePath;
			}
			if (!string.IsNullOrWhiteSpace(text6) && (text6 ?? "").ToLower() != (model.LoginBgImagePath ?? "").ToLower())
			{
				DeleteOldFileFromFtp(text6);
			}
			_dbI.CRMspUpdateFODefaultLoginSetting(loginTitle, loginFormTitle, model.LoginBgImagePath, baseInfo.RgbToDelphiColor(model.LoginBgColor), baseInfo.RgbToDelphiColor(model.LoginBtnBgColor), baseInfo.RgbToDelphiColor(model.LoginBtnFontColor), baseInfo.RgbToDelphiColor(model.LoginLinkColor), loginRegLinkTitle, model.LoginPosition, baseInfo.RgbToDelphiColor(model.LoginTextBorderFColor), baseInfo.RgbToDelphiColor(model.LoginTextBorderTColor), text2, userId, value, value2, now, registerDatePersian, appType, defLangID, model.LoginRegBtnHide, model.LoginAuthenticationType, model.LoginType, model.LoginSendOTPSms, model.LoginSendOTPSmsBodyPatternFormula, model.FoSettingId, model.LoginAuthenticationInfoJson, model.LoginByPassword, model.LoginByOTP, model.LoginByOTPSmsBodyPatternFormula, model.LoginAndFoActive, model.LoginAndShpActive);
			if (!string.IsNullOrEmpty(model.LoginBgImagePath))
			{
				model.LoginBgImagePath = model.LoginBgImagePath.Replace(Configuration.MainDirectoryPath, "/");
				model.LoginBgImagePath = Configuration.HostTempFilesPath + model.LoginBgImagePath;
			}
			base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
			end_IL_007d:;
		}
		catch (DbEntityValidationException e2)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e2);
			text = Messages.frmErrorMessage;
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
			text = Messages.frmErrorMessage;
		}
		base.ViewBag.Error = text;
		return View(model);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actFoSetting")]
	public ActionResult EditRegisterSetting()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		int? cId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
		CrmFoRegisterSettingLanguageViewModel crmFoRegisterSettingLanguageViewModel = new CrmFoRegisterSettingLanguageViewModel();
		_ = DateTime.Now;
		try
		{
			BaseInfo baseInfo = new BaseInfo();
			IEnumerable<CrmFoSetting_Lang> enumerable = Enumerable.Where<CrmFoSetting_Lang>((IEnumerable<CrmFoSetting_Lang>)Enumerable.ToList<CrmFoSetting_Lang>((IEnumerable<CrmFoSetting_Lang>)_dbTbl.CrmFoSetting_Lang), (Func<CrmFoSetting_Lang, bool>)((CrmFoSetting_Lang x) => x.CrmFoSetting.CId == cId));
			string positionTopRightTxt = Labels.PositionTopRightTxt;
			string positionTopCenterTxt = Labels.PositionTopCenterTxt;
			string positionTopLeftTxt = Labels.PositionTopLeftTxt;
			string positionCenterRightTxt = Labels.PositionCenterRightTxt;
			string positionCenterTxt = Labels.PositionCenterTxt;
			string positionCenterLeftTxt = Labels.PositionCenterLeftTxt;
			string positionBottomRightTxt = Labels.PositionBottomRightTxt;
			string positionBottomCenterTxt = Labels.PositionBottomCenterTxt;
			string positionBottomLeftTxt = Labels.PositionBottomLeftTxt;
			_ = Labels.SmsSendByWebTxt;
			_ = Labels.SmsSendByGsmTxt;
			CRMSpEntities cRMSpEntities = db;
			string foSettingDefDisplay4Column = Labels.FoSettingDefDisplay4Column;
			string foSettingDefDisplay3Column = Labels.FoSettingDefDisplay3Column;
			string foSettingDefDisplayListView = Labels.FoSettingDefDisplayListView;
			string foSettingDefDisplayListViewSmall = Labels.FoSettingDefDisplayListViewSmall;
			int? languageID = result;
			int? defaultLanguageID = result;
			CRMspSelectFoSetting_Result cRMspSelectFoSetting_Result = Enumerable.FirstOrDefault<CRMspSelectFoSetting_Result>((IEnumerable<CRMspSelectFoSetting_Result>)cRMSpEntities.CRMspSelectFoSetting(foSettingDefDisplay4Column, foSettingDefDisplay3Column, foSettingDefDisplayListView, foSettingDefDisplayListViewSmall, positionTopRightTxt, positionTopCenterTxt, positionTopLeftTxt, positionCenterRightTxt, positionCenterTxt, positionCenterLeftTxt, positionBottomRightTxt, positionBottomCenterTxt, positionBottomLeftTxt, languageID, defaultLanguageID, cId));
			if (cRMspSelectFoSetting_Result == null)
			{
				cRMspSelectFoSetting_Result = new CRMspSelectFoSetting_Result
				{
					FoSettingId = 0,
					PrdPriceVisible = false
				};
			}
			List<CommonMultiLanguageViewModel> list = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.RegTitle,
				LanguageId = item.LanguageID
			})));
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = cRMspSelectFoSetting_Result.RegTitle,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.RegFormTitle,
				LanguageId = item.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = cRMspSelectFoSetting_Result.RegFormTitle,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.RegLoginLinkTitle,
				LanguageId = item.LanguageID
			})));
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = cRMspSelectFoSetting_Result.RegLoginLinkTitle,
				LanguageId = result
			});
			crmFoRegisterSettingLanguageViewModel = new CrmFoRegisterSettingLanguageViewModel
			{
				FoSettingId = cRMspSelectFoSetting_Result.FoSettingId,
				RegTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
				RegTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
				RegFormTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
				RegFormTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
				RegLoginLinkTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
				RegLoginLinkTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
				RegPosition = cRMspSelectFoSetting_Result.RegPosition,
				RegBgImagePath = cRMspSelectFoSetting_Result.RegBgImagePath,
				RegBgColor = baseInfo.DelphiCToRgbolor(cRMspSelectFoSetting_Result.RegBgColor),
				RegBtnBgColor = baseInfo.DelphiCToRgbolor(cRMspSelectFoSetting_Result.RegBtnBgColor),
				RegBtnFontColor = baseInfo.DelphiCToRgbolor(cRMspSelectFoSetting_Result.RegBtnFontColor),
				RegLinkColor = baseInfo.DelphiCToRgbolor(cRMspSelectFoSetting_Result.RegLinkColor),
				RegTextBorderFColor = baseInfo.DelphiCToRgbolor(cRMspSelectFoSetting_Result.RegTextBorderFColor),
				RegTextBorderTColor = baseInfo.DelphiCToRgbolor(cRMspSelectFoSetting_Result.RegTextBorderTColor),
				RegNullableFields = cRMspSelectFoSetting_Result.RegNullableFields
			};
			if (crmFoRegisterSettingLanguageViewModel != null && !string.IsNullOrEmpty(crmFoRegisterSettingLanguageViewModel.RegBgImagePath))
			{
				string regBgImagePath = crmFoRegisterSettingLanguageViewModel.RegBgImagePath;
				crmFoRegisterSettingLanguageViewModel.RegBgImagePath = crmFoRegisterSettingLanguageViewModel.RegBgImagePath.Replace(Configuration.MainDirectoryPath, "/");
				crmFoRegisterSettingLanguageViewModel.RegBgImagePath = Configuration.HostTempFilesPath + crmFoRegisterSettingLanguageViewModel.RegBgImagePath;
				if (!System.IO.File.Exists(base.Server.MapPath(crmFoRegisterSettingLanguageViewModel.RegBgImagePath)) && !DownlaodFileFromFTP(regBgImagePath, crmFoRegisterSettingLanguageViewModel.RegBgImagePath))
				{
					crmFoRegisterSettingLanguageViewModel.RegBgImagePath = "";
				}
			}
			crmFoRegisterSettingLanguageViewModel.RegNullableFieldsByTitle = CRMIdeal.Classes.Helper.Setting.GetRegNullableFieldsByTitleJson(crmFoRegisterSettingLanguageViewModel.RegNullableFields);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		GetPosition();
		return View(crmFoRegisterSettingLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult EditRegisterSetting(CrmFoRegisterSettingLanguageViewModel model, HttpPostedFileBase urlUpload)
	{
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int? centerId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
		string text = "";
		int num = 0;
		GetPosition();
		try
		{
			model.RegNullableFieldsByTitle = CRMIdeal.Classes.Helper.Setting.GetRegNullableFieldsByTitleJson(model.RegNullableFields);
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.RegTitle_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.RegTitle_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = model.RegTitle,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.RegFormTitle_Lang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.RegFormTitle_Lang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = model.RegFormTitle,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.RegLoginLinkTitle_Lang))
			{
				list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.RegLoginLinkTitle_Lang);
			}
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = model.RegLoginLinkTitle,
				LanguageId = lCID
			});
			string regTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : "");
			string regFormTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : "");
			string regLoginLinkTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : "");
			string text2 = "";
			foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages m) => m.LanguageID != defLangID))))
			{
				string text3 = "";
				string text4 = "";
				string text5 = "";
				text3 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : "");
				text4 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : "");
				text5 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : "");
				text2 = text2 + "[LangId=" + lang.LanguageID + "|,|RegTitle=" + text3 + "|,|RegFormTitle=" + text4 + "|,|LoginLinkTitle=" + text5 + "|,|]@";
			}
			string text6 = "";
			string positionTopRightTxt = Labels.PositionTopRightTxt;
			string positionTopCenterTxt = Labels.PositionTopCenterTxt;
			string positionTopLeftTxt = Labels.PositionTopLeftTxt;
			string positionCenterRightTxt = Labels.PositionCenterRightTxt;
			string positionCenterTxt = Labels.PositionCenterTxt;
			string positionCenterLeftTxt = Labels.PositionCenterLeftTxt;
			string positionBottomRightTxt = Labels.PositionBottomRightTxt;
			string positionBottomCenterTxt = Labels.PositionBottomCenterTxt;
			string positionBottomLeftTxt = Labels.PositionBottomLeftTxt;
			_ = Labels.SmsSendByWebTxt;
			_ = Labels.SmsSendByGsmTxt;
			CRMSpEntities cRMSpEntities = db;
			string foSettingDefDisplay4Column = Labels.FoSettingDefDisplay4Column;
			string foSettingDefDisplay3Column = Labels.FoSettingDefDisplay3Column;
			string foSettingDefDisplayListView = Labels.FoSettingDefDisplayListView;
			string foSettingDefDisplayListViewSmall = Labels.FoSettingDefDisplayListViewSmall;
			int? languageID = defLangID;
			int? defaultLanguageID = defLangID;
			CRMspSelectFoSetting_Result cRMspSelectFoSetting_Result = Enumerable.FirstOrDefault<CRMspSelectFoSetting_Result>((IEnumerable<CRMspSelectFoSetting_Result>)cRMSpEntities.CRMspSelectFoSetting(foSettingDefDisplay4Column, foSettingDefDisplay3Column, foSettingDefDisplayListView, foSettingDefDisplayListViewSmall, positionTopRightTxt, positionTopCenterTxt, positionTopLeftTxt, positionCenterRightTxt, positionCenterTxt, positionCenterLeftTxt, positionBottomRightTxt, positionBottomCenterTxt, positionBottomLeftTxt, languageID, defaultLanguageID, centerId));
			if (cRMspSelectFoSetting_Result != null)
			{
				text6 = cRMspSelectFoSetting_Result.RegBgImagePath;
			}
			BaseInfo baseInfo;
			DateTime now;
			int userId;
			string registerDatePersian;
			short value;
			short value2;
			string appType;
			if (base.ModelState.IsValid)
			{
				baseInfo = new BaseInfo();
				if (num == 0)
				{
					now = DateTime.Now;
					userId = UserLogin.CurrentUser.UserId;
					registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					value = short.Parse(Financial.Get().Id.ToString());
					value2 = short.Parse(now.ToString("MM", new PersianCulture()));
					appType = Configuration.AppType;
					if (urlUpload == null)
					{
						goto IL_0846;
					}
					string text7 = urlUpload.ContentType.ToLower();
					string text8 = Path.GetExtension(urlUpload.FileName).ToLower();
					if ((text7 != "image/jpg" && text7 != "image/jpeg" && text7 != "image/pjpeg" && text7 != "image/gif" && text7 != "image/x-png" && text7 != "image/png") || (text8 != ".jpg" && text8 != ".png" && text8 != ".gif" && text8 != ".jpeg"))
					{
						base.ModelState.AddModelError("error", Messages.frmErrorNotImageFile);
						return View(model);
					}
					FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
					string pathFtp = Configuration.PathFtp;
					string userNameFtp = Configuration.UserNameFtp;
					string passwordFtp = Configuration.PasswordFtp;
					bool usePassiveFtp = Configuration.UsePassiveFtp;
					string fileName = Path.GetFileName(urlUpload.FileName);
					string text9 = Configuration.MainDirectoryPath + Configuration.FoSettingDirectoryPath;
					string text10 = text9 + (text9.EndsWith("/") ? "" : "/");
					bool flag = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, Configuration.MainDirectoryPath, Configuration.FoSettingDirectoryPath, usePassiveFtp);
					if (!flag)
					{
						flag = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, Configuration.MainDirectoryPath, Configuration.FoSettingDirectoryPath, usePassiveFtp);
					}
					bool flag2 = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text10, "Register/", usePassiveFtp);
					if (!flag2)
					{
						flag2 = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text10, "Register/", usePassiveFtp);
					}
					if (!(flag && flag2))
					{
						goto IL_0846;
					}
					text10 += "Register/";
					string text11 = text10;
					text11 = text11.Replace(Configuration.MainDirectoryPath, "/");
					text11 = Configuration.HostTempFilesPath + text11;
					text11 = base.Server.MapPath(text11);
					if (!System.IO.Directory.Exists(text11))
					{
						System.IO.Directory.CreateDirectory(text11);
						CRM.General.IO.Directory.SetFullControlForEveryOne(text11);
					}
					if (System.IO.Directory.Exists(text11))
					{
						string text12 = text11 + "Initial-" + fileName;
						text11 += fileName;
						if (System.IO.File.Exists(text11))
						{
							System.IO.File.Delete(text11);
						}
						urlUpload.SaveAs(text12);
						if (System.IO.File.Exists(text12))
						{
							ImageFormat format = SetImageFormat(fileName);
							if (ResizeImage(text12, text11, format, _BgPicWidth, _BgPicHeight))
							{
								System.IO.File.Delete(text12);
							}
						}
					}
					if (!System.IO.File.Exists(text11))
					{
						goto IL_0846;
					}
					text10 += fileName;
					if (facadeFTP.UploadFtpFormTable(pathFtp, userNameFtp, passwordFtp, text10, text11, usePassiveFtp))
					{
						model.RegBgImagePath = text10;
						goto IL_0846;
					}
					model.RegBgImagePath = null;
					Exception e = new Exception(Messages.msgErrorUploadingFileInFtp + "  -  hostname: " + pathFtp + " ,username: " + userNameFtp + " ,destination: " + text10);
					ErrorSignal.FromCurrentContext().Raise(e);
					base.ModelState.AddModelError("error", Messages.frmErrorInSendingFile);
					base.ViewBag.Error = Messages.frmErrorInSendingFile;
				}
			}
			else
			{
				text = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
			goto end_IL_007d;
			IL_0846:
			if (!string.IsNullOrEmpty(model.RegBgImagePath) && model.RegBgImagePath.IndexOf(Configuration.HostTempFilesPath, StringComparison.Ordinal) >= 0)
			{
				model.RegBgImagePath = model.RegBgImagePath.Replace(Configuration.HostTempFilesPath + "/", "");
				model.RegBgImagePath = Configuration.MainDirectoryPath + model.RegBgImagePath;
			}
			if (!string.IsNullOrWhiteSpace(text6) && (text6 ?? "").ToLower() != (model.RegBgImagePath ?? "").ToLower())
			{
				DeleteOldFileFromFtp(text6);
			}
			db.CRMspUpdateFODefaultRegisterSetting(regTitle, regFormTitle, model.RegBgImagePath, baseInfo.RgbToDelphiColor(model.RegBgColor), baseInfo.RgbToDelphiColor(model.RegBtnBgColor), baseInfo.RgbToDelphiColor(model.RegBtnFontColor), baseInfo.RgbToDelphiColor(model.RegLinkColor), regLoginLinkTitle, model.RegPosition, baseInfo.RgbToDelphiColor(model.RegTextBorderFColor), baseInfo.RgbToDelphiColor(model.RegTextBorderTColor), model.RegDyFormId, text2, userId, value, value2, now, registerDatePersian, appType, defLangID, model.FoSettingId, model.RegNullableFields);
			if (!string.IsNullOrEmpty(model.RegBgImagePath))
			{
				model.RegBgImagePath = model.RegBgImagePath.Replace(Configuration.MainDirectoryPath, "/");
				model.RegBgImagePath = Configuration.HostTempFilesPath + model.RegBgImagePath;
			}
			base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
			end_IL_007d:;
		}
		catch (DbEntityValidationException e2)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e2);
			text = Messages.frmErrorMessage;
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
			text = Messages.frmErrorMessage;
		}
		base.ViewBag.Error = text;
		return View(model);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actFoSetting")]
	public ActionResult EditShpLogoSetting()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		int? centerId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
		CrmFoShpLogoSettingLanguageViewModel crmFoShpLogoSettingLanguageViewModel = new CrmFoShpLogoSettingLanguageViewModel();
		_ = DateTime.Now;
		try
		{
			string positionTopRightTxt = Labels.PositionTopRightTxt;
			string positionTopCenterTxt = Labels.PositionTopCenterTxt;
			string positionTopLeftTxt = Labels.PositionTopLeftTxt;
			string positionCenterRightTxt = Labels.PositionCenterRightTxt;
			string positionCenterTxt = Labels.PositionCenterTxt;
			string positionCenterLeftTxt = Labels.PositionCenterLeftTxt;
			string positionBottomRightTxt = Labels.PositionBottomRightTxt;
			string positionBottomCenterTxt = Labels.PositionBottomCenterTxt;
			string positionBottomLeftTxt = Labels.PositionBottomLeftTxt;
			_ = Labels.SmsSendByWebTxt;
			_ = Labels.SmsSendByGsmTxt;
			CRMSpEntities cRMSpEntities = db;
			string foSettingDefDisplay4Column = Labels.FoSettingDefDisplay4Column;
			string foSettingDefDisplay3Column = Labels.FoSettingDefDisplay3Column;
			string foSettingDefDisplayListView = Labels.FoSettingDefDisplayListView;
			string foSettingDefDisplayListViewSmall = Labels.FoSettingDefDisplayListViewSmall;
			int? languageID = result;
			int? defaultLanguageID = result;
			CRMspSelectFoSetting_Result cRMspSelectFoSetting_Result = Enumerable.FirstOrDefault<CRMspSelectFoSetting_Result>((IEnumerable<CRMspSelectFoSetting_Result>)cRMSpEntities.CRMspSelectFoSetting(foSettingDefDisplay4Column, foSettingDefDisplay3Column, foSettingDefDisplayListView, foSettingDefDisplayListViewSmall, positionTopRightTxt, positionTopCenterTxt, positionTopLeftTxt, positionCenterRightTxt, positionCenterTxt, positionCenterLeftTxt, positionBottomRightTxt, positionBottomCenterTxt, positionBottomLeftTxt, languageID, defaultLanguageID, centerId));
			if (cRMspSelectFoSetting_Result == null)
			{
				cRMspSelectFoSetting_Result = new CRMspSelectFoSetting_Result
				{
					FoSettingId = 0,
					PrdPriceVisible = false
				};
			}
			crmFoShpLogoSettingLanguageViewModel = new CrmFoShpLogoSettingLanguageViewModel
			{
				FoSettingId = cRMspSelectFoSetting_Result.FoSettingId,
				ShpLogoPathWidth110 = cRMspSelectFoSetting_Result.ShpLogoPathWidth110,
				ShpLogoPathWidth215 = cRMspSelectFoSetting_Result.ShpLogoPathWidth215,
				ShpPrdDefPhotoAdd = cRMspSelectFoSetting_Result.ShpPrdDefPhotoAdd
			};
			if (crmFoShpLogoSettingLanguageViewModel != null)
			{
				if (!string.IsNullOrEmpty(crmFoShpLogoSettingLanguageViewModel.ShpLogoPathWidth110))
				{
					string shpLogoPathWidth = crmFoShpLogoSettingLanguageViewModel.ShpLogoPathWidth110;
					crmFoShpLogoSettingLanguageViewModel.ShpLogoPathWidth110 = crmFoShpLogoSettingLanguageViewModel.ShpLogoPathWidth110.Replace(Configuration.MainDirectoryPath, "/");
					crmFoShpLogoSettingLanguageViewModel.ShpLogoPathWidth110 = Configuration.HostTempFilesPath + crmFoShpLogoSettingLanguageViewModel.ShpLogoPathWidth110;
					if (!System.IO.File.Exists(base.Server.MapPath(crmFoShpLogoSettingLanguageViewModel.ShpLogoPathWidth110)) && !DownlaodFileFromFTP(shpLogoPathWidth, crmFoShpLogoSettingLanguageViewModel.ShpLogoPathWidth110))
					{
						crmFoShpLogoSettingLanguageViewModel.ShpLogoPathWidth110 = "";
					}
				}
				if (!string.IsNullOrEmpty(crmFoShpLogoSettingLanguageViewModel.ShpLogoPathWidth215))
				{
					string shpLogoPathWidth2 = crmFoShpLogoSettingLanguageViewModel.ShpLogoPathWidth215;
					crmFoShpLogoSettingLanguageViewModel.ShpLogoPathWidth215 = crmFoShpLogoSettingLanguageViewModel.ShpLogoPathWidth215.Replace(Configuration.MainDirectoryPath, "/");
					crmFoShpLogoSettingLanguageViewModel.ShpLogoPathWidth215 = Configuration.HostTempFilesPath + crmFoShpLogoSettingLanguageViewModel.ShpLogoPathWidth215;
					if (!System.IO.File.Exists(base.Server.MapPath(crmFoShpLogoSettingLanguageViewModel.ShpLogoPathWidth215)) && !DownlaodFileFromFTP(shpLogoPathWidth2, crmFoShpLogoSettingLanguageViewModel.ShpLogoPathWidth215))
					{
						crmFoShpLogoSettingLanguageViewModel.ShpLogoPathWidth215 = "";
					}
				}
				if (!string.IsNullOrEmpty(crmFoShpLogoSettingLanguageViewModel.ShpPrdDefPhotoAdd))
				{
					string shpPrdDefPhotoAdd = crmFoShpLogoSettingLanguageViewModel.ShpPrdDefPhotoAdd;
					crmFoShpLogoSettingLanguageViewModel.ShpPrdDefPhotoAdd = crmFoShpLogoSettingLanguageViewModel.ShpPrdDefPhotoAdd.Replace(Configuration.MainDirectoryPath, "/");
					crmFoShpLogoSettingLanguageViewModel.ShpPrdDefPhotoAdd = Configuration.HostTempFilesPath + crmFoShpLogoSettingLanguageViewModel.ShpPrdDefPhotoAdd;
					if (!System.IO.File.Exists(base.Server.MapPath(crmFoShpLogoSettingLanguageViewModel.ShpPrdDefPhotoAdd)) && !DownlaodFileFromFTP(shpPrdDefPhotoAdd, crmFoShpLogoSettingLanguageViewModel.ShpPrdDefPhotoAdd))
					{
						crmFoShpLogoSettingLanguageViewModel.ShpPrdDefPhotoAdd = "";
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(crmFoShpLogoSettingLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult EditShpLogoSetting(CrmFoShpLogoSettingLanguageViewModel model, HttpPostedFileBase urlUpload, HttpPostedFileBase urlUploadI, HttpPostedFileBase urlUploadII)
	{
		_003C_003Ec__DisplayClass125_0 _003C_003Ec__DisplayClass125_ = new _003C_003Ec__DisplayClass125_0();
		_003C_003Ec__DisplayClass125_.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		int? centerId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
		string text = "";
		int num = 0;
		try
		{
			string text2 = "";
			string text3 = "";
			string text4 = "";
			string positionTopRightTxt = Labels.PositionTopRightTxt;
			string positionTopCenterTxt = Labels.PositionTopCenterTxt;
			string positionTopLeftTxt = Labels.PositionTopLeftTxt;
			string positionCenterRightTxt = Labels.PositionCenterRightTxt;
			string positionCenterTxt = Labels.PositionCenterTxt;
			string positionCenterLeftTxt = Labels.PositionCenterLeftTxt;
			string positionBottomRightTxt = Labels.PositionBottomRightTxt;
			string positionBottomCenterTxt = Labels.PositionBottomCenterTxt;
			string positionBottomLeftTxt = Labels.PositionBottomLeftTxt;
			_ = Labels.SmsSendByWebTxt;
			_ = Labels.SmsSendByGsmTxt;
			CRMSpEntities cRMSpEntities = db;
			string foSettingDefDisplay4Column = Labels.FoSettingDefDisplay4Column;
			string foSettingDefDisplay3Column = Labels.FoSettingDefDisplay3Column;
			string foSettingDefDisplayListView = Labels.FoSettingDefDisplayListView;
			string foSettingDefDisplayListViewSmall = Labels.FoSettingDefDisplayListViewSmall;
			int? languageID = result;
			int? defaultLanguageID = result;
			CRMspSelectFoSetting_Result cRMspSelectFoSetting_Result = Enumerable.FirstOrDefault<CRMspSelectFoSetting_Result>((IEnumerable<CRMspSelectFoSetting_Result>)cRMSpEntities.CRMspSelectFoSetting(foSettingDefDisplay4Column, foSettingDefDisplay3Column, foSettingDefDisplayListView, foSettingDefDisplayListViewSmall, positionTopRightTxt, positionTopCenterTxt, positionTopLeftTxt, positionCenterRightTxt, positionCenterTxt, positionCenterLeftTxt, positionBottomRightTxt, positionBottomCenterTxt, positionBottomLeftTxt, languageID, defaultLanguageID, centerId));
			if (cRMspSelectFoSetting_Result != null)
			{
				text2 = cRMspSelectFoSetting_Result.ShpLogoPathWidth110;
				text3 = cRMspSelectFoSetting_Result.ShpLogoPathWidth215;
				text4 = cRMspSelectFoSetting_Result.ShpPrdDefPhotoAdd;
			}
			int customWidth2;
			int customHeight2;
			int customWidth3;
			int customHeight3;
			string text5;
			DateTime now;
			int userId;
			string registerDatePersian;
			short year;
			short month;
			string appType;
			int num2;
			if (base.ModelState.IsValid)
			{
				int customWidth = 110;
				int customHeight = 40;
				customWidth2 = 215;
				customHeight2 = 78;
				customWidth3 = 300;
				customHeight3 = 300;
				text5 = "Logo/";
				if (num == 0)
				{
					now = DateTime.Now;
					userId = UserLogin.CurrentUser.UserId;
					registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					year = short.Parse(Financial.Get().Id.ToString());
					month = short.Parse(now.ToString("MM", new PersianCulture()));
					appType = Configuration.AppType;
					num2 = 500;
					if (urlUpload == null)
					{
						goto IL_0688;
					}
					string text6 = urlUpload.ContentType.ToLower();
					string text7 = Path.GetExtension(urlUpload.FileName).ToLower();
					if ((text6 != "image/jpg" && text6 != "image/jpeg" && text6 != "image/pjpeg" && text6 != "image/gif" && text6 != "image/x-png" && text6 != "image/png") || (text7 != ".jpg" && text7 != ".png" && text7 != ".gif" && text7 != ".jpeg"))
					{
						text = Messages.frmErrorNotImageFile;
						base.ViewBag.Error = text;
						base.ModelState.AddModelError("error", text);
						return View(_003C_003Ec__DisplayClass125_.model);
					}
					if (urlUpload.ContentLength / 1024 > num2)
					{
						text = string.Format(Messages.frmErrorMaxImageSizeForUpload, num2);
						base.ViewBag.Error = text;
						base.ModelState.AddModelError("error", text);
						return View(_003C_003Ec__DisplayClass125_.model);
					}
					FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
					string pathFtp = Configuration.PathFtp;
					string userNameFtp = Configuration.UserNameFtp;
					string passwordFtp = Configuration.PasswordFtp;
					bool usePassiveFtp = Configuration.UsePassiveFtp;
					string fileName = Path.GetFileName(urlUpload.FileName);
					string text8 = Configuration.MainDirectoryPath + Configuration.FoSettingDirectoryPath;
					string text9 = text8 + (text8.EndsWith("/") ? "" : "/");
					bool flag = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, Configuration.MainDirectoryPath, Configuration.FoSettingDirectoryPath, usePassiveFtp);
					if (!flag)
					{
						flag = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, Configuration.MainDirectoryPath, Configuration.FoSettingDirectoryPath, usePassiveFtp);
					}
					bool flag2 = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text9, text5, usePassiveFtp);
					if (!flag2)
					{
						flag2 = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text9, text5, usePassiveFtp);
					}
					if (!(flag && flag2))
					{
						goto IL_0688;
					}
					text9 += text5;
					string text10 = text9;
					text10 = text10.Replace(Configuration.MainDirectoryPath, "/");
					text10 = Configuration.HostTempFilesPath + text10;
					text10 = base.Server.MapPath(text10);
					if (!System.IO.Directory.Exists(text10))
					{
						System.IO.Directory.CreateDirectory(text10);
						CRM.General.IO.Directory.SetFullControlForEveryOne(text10);
					}
					if (System.IO.Directory.Exists(text10))
					{
						string text11 = text10 + "Initial-" + fileName;
						text10 += fileName;
						if (System.IO.File.Exists(text10))
						{
							System.IO.File.Delete(text10);
						}
						urlUpload.SaveAs(text11);
						if (System.IO.File.Exists(text11))
						{
							ImageManager.CompressFile(new ImageManager.ImageParam
							{
								FilePath = text11,
								DestPath = text10,
								CustomHeight = customHeight,
								CustomWidth = customWidth
							});
							ImageManager.DeleteFile(new ImageManager.ImageParam
							{
								FilePath = text11
							});
						}
					}
					if (!System.IO.File.Exists(text10))
					{
						goto IL_0688;
					}
					text9 += fileName;
					if (facadeFTP.UploadFtpFormTable(pathFtp, userNameFtp, passwordFtp, text9, text10, usePassiveFtp))
					{
						_003C_003Ec__DisplayClass125_.model.ShpLogoPathWidth110 = text9;
						goto IL_0688;
					}
					_003C_003Ec__DisplayClass125_.model.ShpLogoPathWidth110 = null;
					Exception e = new Exception(Messages.msgErrorUploadingFileInFtp + "  -  hostname: " + pathFtp + " ,username: " + userNameFtp + " ,destination: " + text9);
					ErrorSignal.FromCurrentContext().Raise(e);
					base.ModelState.AddModelError("error", Messages.frmErrorInSendingFile);
					base.ViewBag.Error = Messages.frmErrorInSendingFile;
				}
			}
			else
			{
				text = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
			goto end_IL_006f;
			IL_0b30:
			if (urlUploadII == null)
			{
				goto IL_0fde;
			}
			string text12 = urlUploadII.ContentType.ToLower();
			string text13 = Path.GetExtension(urlUploadII.FileName).ToLower();
			if ((text12 != "image/jpg" && text12 != "image/jpeg" && text12 != "image/pjpeg" && text12 != "image/gif" && text12 != "image/x-png" && text12 != "image/png") || (text13 != ".jpg" && text13 != ".png" && text13 != ".gif" && text13 != ".jpeg"))
			{
				text = Messages.frmErrorNotImageFile;
				base.ViewBag.Error = text;
				base.ModelState.AddModelError("error", text);
				return View(_003C_003Ec__DisplayClass125_.model);
			}
			if (urlUploadII.ContentLength / 1024 > num2)
			{
				text = string.Format(Messages.frmErrorMaxImageSizeForUpload, num2);
				base.ViewBag.Error = text;
				base.ModelState.AddModelError("error", text);
				return View(_003C_003Ec__DisplayClass125_.model);
			}
			FacadeFTP facadeFTP2 = new FacadeFTP(Configuration.FacadeFtp);
			string pathFtp2 = Configuration.PathFtp;
			string userNameFtp2 = Configuration.UserNameFtp;
			string passwordFtp2 = Configuration.PasswordFtp;
			bool usePassiveFtp2 = Configuration.UsePassiveFtp;
			string fileName2 = Path.GetFileName(urlUploadII.FileName);
			string text14 = Configuration.MainDirectoryPath + Configuration.FoSettingDirectoryPath;
			string text15 = text14 + (text14.EndsWith("/") ? "" : "/");
			bool flag3 = facadeFTP2.ExistsDirectoryInFtp(pathFtp2, userNameFtp2, passwordFtp2, Configuration.MainDirectoryPath, Configuration.FoSettingDirectoryPath, usePassiveFtp2);
			if (!flag3)
			{
				flag3 = facadeFTP2.CreateDirectoryInFtp(pathFtp2, userNameFtp2, passwordFtp2, Configuration.MainDirectoryPath, Configuration.FoSettingDirectoryPath, usePassiveFtp2);
			}
			bool flag4 = facadeFTP2.ExistsDirectoryInFtp(pathFtp2, userNameFtp2, passwordFtp2, text15, text5, usePassiveFtp2);
			if (!flag4)
			{
				flag4 = facadeFTP2.CreateDirectoryInFtp(pathFtp2, userNameFtp2, passwordFtp2, text15, text5, usePassiveFtp2);
			}
			if (!(flag3 && flag4))
			{
				goto IL_0fde;
			}
			text15 += text5;
			string text16 = text15;
			text16 = text16.Replace(Configuration.MainDirectoryPath, "/");
			text16 = Configuration.HostTempFilesPath + text16;
			text16 = base.Server.MapPath(text16);
			if (!System.IO.Directory.Exists(text16))
			{
				System.IO.Directory.CreateDirectory(text16);
				CRM.General.IO.Directory.SetFullControlForEveryOne(text16);
			}
			if (System.IO.Directory.Exists(text16))
			{
				string text17 = text16 + "Initial-" + fileName2;
				text16 += fileName2;
				if (System.IO.File.Exists(text16))
				{
					System.IO.File.Delete(text16);
				}
				urlUploadII.SaveAs(text17);
				if (System.IO.File.Exists(text17))
				{
					ImageManager.CompressFile(new ImageManager.ImageParam
					{
						FilePath = text17,
						DestPath = text16,
						CustomHeight = customHeight3,
						CustomWidth = customWidth3
					});
					ImageManager.DeleteFile(new ImageManager.ImageParam
					{
						FilePath = text17
					});
				}
			}
			if (!System.IO.File.Exists(text16))
			{
				goto IL_0fde;
			}
			text15 += fileName2;
			if (facadeFTP2.UploadFtpFormTable(pathFtp2, userNameFtp2, passwordFtp2, text15, text16, usePassiveFtp2))
			{
				_003C_003Ec__DisplayClass125_.model.ShpPrdDefPhotoAdd = text15;
				goto IL_0fde;
			}
			_003C_003Ec__DisplayClass125_.model.ShpPrdDefPhotoAdd = null;
			Exception e2 = new Exception(Messages.msgErrorUploadingFileInFtp + "  -  hostname: " + pathFtp2 + " ,username: " + userNameFtp2 + " ,destination: " + text15);
			ErrorSignal.FromCurrentContext().Raise(e2);
			base.ModelState.AddModelError("error", Messages.frmErrorInSendingFile);
			base.ViewBag.Error = Messages.frmErrorInSendingFile;
			goto end_IL_006f;
			IL_0688:
			if (urlUploadI == null)
			{
				goto IL_0b30;
			}
			string text18 = urlUploadI.ContentType.ToLower();
			string text19 = Path.GetExtension(urlUploadI.FileName).ToLower();
			if ((text18 != "image/jpg" && text18 != "image/jpeg" && text18 != "image/pjpeg" && text18 != "image/gif" && text18 != "image/x-png" && text18 != "image/png") || (text19 != ".jpg" && text19 != ".png" && text19 != ".gif" && text19 != ".jpeg"))
			{
				text = Messages.frmErrorNotImageFile;
				base.ViewBag.Error = text;
				base.ModelState.AddModelError("error", text);
				return View(_003C_003Ec__DisplayClass125_.model);
			}
			if (urlUploadI.ContentLength / 1024 > num2)
			{
				text = string.Format(Messages.frmErrorMaxImageSizeForUpload, num2);
				base.ViewBag.Error = text;
				base.ModelState.AddModelError("error", text);
				return View(_003C_003Ec__DisplayClass125_.model);
			}
			FacadeFTP facadeFTP3 = new FacadeFTP(Configuration.FacadeFtp);
			string pathFtp3 = Configuration.PathFtp;
			string userNameFtp3 = Configuration.UserNameFtp;
			string passwordFtp3 = Configuration.PasswordFtp;
			bool usePassiveFtp3 = Configuration.UsePassiveFtp;
			string fileName3 = Path.GetFileName(urlUploadI.FileName);
			string text20 = Configuration.MainDirectoryPath + Configuration.FoSettingDirectoryPath;
			string text21 = text20 + (text20.EndsWith("/") ? "" : "/");
			bool flag5 = facadeFTP3.ExistsDirectoryInFtp(pathFtp3, userNameFtp3, passwordFtp3, Configuration.MainDirectoryPath, Configuration.FoSettingDirectoryPath, usePassiveFtp3);
			if (!flag5)
			{
				flag5 = facadeFTP3.CreateDirectoryInFtp(pathFtp3, userNameFtp3, passwordFtp3, Configuration.MainDirectoryPath, Configuration.FoSettingDirectoryPath, usePassiveFtp3);
			}
			bool flag6 = facadeFTP3.ExistsDirectoryInFtp(pathFtp3, userNameFtp3, passwordFtp3, text21, text5, usePassiveFtp3);
			if (!flag6)
			{
				flag6 = facadeFTP3.CreateDirectoryInFtp(pathFtp3, userNameFtp3, passwordFtp3, text21, text5, usePassiveFtp3);
			}
			if (!(flag5 && flag6))
			{
				goto IL_0b30;
			}
			text21 += text5;
			string text22 = text21;
			text22 = text22.Replace(Configuration.MainDirectoryPath, "/");
			text22 = Configuration.HostTempFilesPath + text22;
			text22 = base.Server.MapPath(text22);
			if (!System.IO.Directory.Exists(text22))
			{
				System.IO.Directory.CreateDirectory(text22);
				CRM.General.IO.Directory.SetFullControlForEveryOne(text22);
			}
			if (System.IO.Directory.Exists(text22))
			{
				string text23 = text22 + "Initial-" + fileName3;
				text22 += fileName3;
				if (System.IO.File.Exists(text22))
				{
					System.IO.File.Delete(text22);
				}
				urlUploadI.SaveAs(text23);
				if (System.IO.File.Exists(text23))
				{
					ImageManager.CompressFile(new ImageManager.ImageParam
					{
						FilePath = text23,
						DestPath = text22,
						CustomHeight = customHeight2,
						CustomWidth = customWidth2
					});
					ImageManager.DeleteFile(new ImageManager.ImageParam
					{
						FilePath = text23
					});
				}
			}
			if (!System.IO.File.Exists(text22))
			{
				goto IL_0b30;
			}
			text21 += fileName3;
			if (facadeFTP3.UploadFtpFormTable(pathFtp3, userNameFtp3, passwordFtp3, text21, text22, usePassiveFtp3))
			{
				_003C_003Ec__DisplayClass125_.model.ShpLogoPathWidth215 = text21;
				goto IL_0b30;
			}
			_003C_003Ec__DisplayClass125_.model.ShpLogoPathWidth215 = null;
			Exception e3 = new Exception(Messages.msgErrorUploadingFileInFtp + "  -  hostname: " + pathFtp3 + " ,username: " + userNameFtp3 + " ,destination: " + text21);
			ErrorSignal.FromCurrentContext().Raise(e3);
			base.ModelState.AddModelError("error", Messages.frmErrorInSendingFile);
			base.ViewBag.Error = Messages.frmErrorInSendingFile;
			goto end_IL_006f;
			IL_0fde:
			if (!string.IsNullOrEmpty(_003C_003Ec__DisplayClass125_.model.ShpLogoPathWidth110) && _003C_003Ec__DisplayClass125_.model.ShpLogoPathWidth110.IndexOf(Configuration.HostTempFilesPath, StringComparison.Ordinal) >= 0)
			{
				_003C_003Ec__DisplayClass125_.model.ShpLogoPathWidth110 = _003C_003Ec__DisplayClass125_.model.ShpLogoPathWidth110.Replace(Configuration.HostTempFilesPath + "/", "");
				_003C_003Ec__DisplayClass125_.model.ShpLogoPathWidth110 = Configuration.MainDirectoryPath + _003C_003Ec__DisplayClass125_.model.ShpLogoPathWidth110;
			}
			if (!string.IsNullOrEmpty(_003C_003Ec__DisplayClass125_.model.ShpLogoPathWidth215) && _003C_003Ec__DisplayClass125_.model.ShpLogoPathWidth215.IndexOf(Configuration.HostTempFilesPath, StringComparison.Ordinal) >= 0)
			{
				_003C_003Ec__DisplayClass125_.model.ShpLogoPathWidth215 = _003C_003Ec__DisplayClass125_.model.ShpLogoPathWidth215.Replace(Configuration.HostTempFilesPath + "/", "");
				_003C_003Ec__DisplayClass125_.model.ShpLogoPathWidth215 = Configuration.MainDirectoryPath + _003C_003Ec__DisplayClass125_.model.ShpLogoPathWidth215;
			}
			if (!string.IsNullOrEmpty(_003C_003Ec__DisplayClass125_.model.ShpPrdDefPhotoAdd) && _003C_003Ec__DisplayClass125_.model.ShpPrdDefPhotoAdd.IndexOf(Configuration.HostTempFilesPath, StringComparison.Ordinal) >= 0)
			{
				_003C_003Ec__DisplayClass125_.model.ShpPrdDefPhotoAdd = _003C_003Ec__DisplayClass125_.model.ShpPrdDefPhotoAdd.Replace(Configuration.HostTempFilesPath + "/", "");
				_003C_003Ec__DisplayClass125_.model.ShpPrdDefPhotoAdd = Configuration.MainDirectoryPath + _003C_003Ec__DisplayClass125_.model.ShpPrdDefPhotoAdd;
			}
			if (!string.IsNullOrWhiteSpace(text2) && (text2 ?? "").ToLower() != (_003C_003Ec__DisplayClass125_.model.ShpLogoPathWidth110 ?? "").ToLower())
			{
				DeleteOldFileFromFtp(text2);
			}
			if (!string.IsNullOrWhiteSpace(text3) && (text3 ?? "").ToLower() != (_003C_003Ec__DisplayClass125_.model.ShpLogoPathWidth215 ?? "").ToLower())
			{
				DeleteOldFileFromFtp(text3);
			}
			if (!string.IsNullOrWhiteSpace(text4) && (text4 ?? "").ToLower() != (_003C_003Ec__DisplayClass125_.model.ShpPrdDefPhotoAdd ?? "").ToLower())
			{
				DeleteOldFileFromFtp(text4);
			}
			DbSet<CrmFoSetting> crmFoSetting = _dbTbl.CrmFoSetting;
			ParameterExpression val = Expression.Parameter(typeof(CrmFoSetting), "m");
			CrmFoSetting crmFoSetting2 = Queryable.FirstOrDefault<CrmFoSetting>((IQueryable<CrmFoSetting>)crmFoSetting, Expression.Lambda<Func<CrmFoSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass125_, typeof(_003C_003Ec__DisplayClass125_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmFoSetting2 != null)
			{
				crmFoSetting2.UserId = userId;
				crmFoSetting2.RegisterDate = now;
				crmFoSetting2.RegisterDatePersian = registerDatePersian;
				crmFoSetting2.Year1 = year;
				crmFoSetting2.Month1 = month;
				crmFoSetting2.AppType = appType;
				crmFoSetting2.ShpLogoPathWidth110 = _003C_003Ec__DisplayClass125_.model.ShpLogoPathWidth110;
				crmFoSetting2.ShpLogoPathWidth215 = _003C_003Ec__DisplayClass125_.model.ShpLogoPathWidth215;
				crmFoSetting2.ShpPrdDefPhotoAdd = _003C_003Ec__DisplayClass125_.model.ShpPrdDefPhotoAdd;
				_dbTbl.Entry(crmFoSetting2).State = EntityState.Modified;
				_dbTbl.SaveChanges();
			}
			if (!string.IsNullOrEmpty(_003C_003Ec__DisplayClass125_.model.ShpLogoPathWidth110))
			{
				_003C_003Ec__DisplayClass125_.model.ShpLogoPathWidth110 = _003C_003Ec__DisplayClass125_.model.ShpLogoPathWidth110.Replace(Configuration.MainDirectoryPath, "/");
				_003C_003Ec__DisplayClass125_.model.ShpLogoPathWidth110 = Configuration.HostTempFilesPath + _003C_003Ec__DisplayClass125_.model.ShpLogoPathWidth110;
			}
			if (!string.IsNullOrEmpty(_003C_003Ec__DisplayClass125_.model.ShpLogoPathWidth215))
			{
				_003C_003Ec__DisplayClass125_.model.ShpLogoPathWidth215 = _003C_003Ec__DisplayClass125_.model.ShpLogoPathWidth215.Replace(Configuration.MainDirectoryPath, "/");
				_003C_003Ec__DisplayClass125_.model.ShpLogoPathWidth215 = Configuration.HostTempFilesPath + _003C_003Ec__DisplayClass125_.model.ShpLogoPathWidth215;
			}
			if (!string.IsNullOrEmpty(_003C_003Ec__DisplayClass125_.model.ShpPrdDefPhotoAdd))
			{
				_003C_003Ec__DisplayClass125_.model.ShpPrdDefPhotoAdd = _003C_003Ec__DisplayClass125_.model.ShpPrdDefPhotoAdd.Replace(Configuration.MainDirectoryPath, "/");
				_003C_003Ec__DisplayClass125_.model.ShpPrdDefPhotoAdd = Configuration.HostTempFilesPath + _003C_003Ec__DisplayClass125_.model.ShpPrdDefPhotoAdd;
			}
			base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
			end_IL_006f:;
		}
		catch (DbEntityValidationException e4)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e4);
			text = Messages.frmErrorMessage;
		}
		catch (Exception e5)
		{
			ErrorSignal.FromCurrentContext().Raise(e5);
			text = Messages.frmErrorMessage;
		}
		base.ViewBag.Error = text;
		return View(_003C_003Ec__DisplayClass125_.model);
	}

	public ActionResult SetColor(int type, string color = "")
	{
		base.ViewBag.Type = type;
		base.ViewBag.Color = color;
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actFoSetting")]
	public ActionResult EditCmpUPSetting()
	{
		_003C_003Ec__DisplayClass127_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass127_0();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		CS_0024_003C_003E8__locals0.cId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId.GetValueOrDefault() : 0);
		CrmFoSettingCmpUPLanguageViewModel model = new CrmFoSettingCmpUPLanguageViewModel();
		_ = DateTime.Now;
		try
		{
			Enumerable.Where<CrmFoSetting_Lang>((IEnumerable<CrmFoSetting_Lang>)Enumerable.ToList<CrmFoSetting_Lang>((IEnumerable<CrmFoSetting_Lang>)_dbTbl.CrmFoSetting_Lang), (Func<CrmFoSetting_Lang, bool>)((CrmFoSetting_Lang x) => x.CrmFoSetting.CId == CS_0024_003C_003E8__locals0.cId));
			CrmFoSetting crmFoSetting = new CrmFoSetting();
			DbSet<CrmFoSetting> crmFoSetting2 = _dbTbl.CrmFoSetting;
			ParameterExpression val = Expression.Parameter(typeof(CrmFoSetting), "x");
			crmFoSetting = Queryable.FirstOrDefault<CrmFoSetting>((IQueryable<CrmFoSetting>)crmFoSetting2, Expression.Lambda<Func<CrmFoSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Convert((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass127_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), typeof(int?))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmFoSetting == null)
			{
				crmFoSetting = new CrmFoSetting
				{
					FoSettingId = 0
				};
			}
			model = new CrmFoSettingCmpUPLanguageViewModel
			{
				FoSettingId = crmFoSetting.FoSettingId,
				CmpDefUsernameType = crmFoSetting.CmpDefUsernameType,
				CmpDefPasswordType = crmFoSetting.CmpDefPasswordType
			};
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(model);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult EditCmpUPSetting(CrmFoSettingCmpUPLanguageViewModel model)
	{
		_003C_003Ec__DisplayClass128_0 _003C_003Ec__DisplayClass128_ = new _003C_003Ec__DisplayClass128_0();
		_003C_003Ec__DisplayClass128_.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		if (_003C_003Ec__DisplayClass128_.model.FoSettingId <= 0)
		{
			text = Messages.ErrorNotFound;
			num++;
		}
		try
		{
			if (base.ModelState.IsValid)
			{
				if (num == 0)
				{
					DateTime now = DateTime.Now;
					CrmFoSetting crmFoSetting = new CrmFoSetting();
					if (_003C_003Ec__DisplayClass128_.model.FoSettingId <= 0)
					{
						text = Messages.ErrorNotFound;
						base.ViewBag.Error = text;
						return View(_003C_003Ec__DisplayClass128_.model);
					}
					DbSet<CrmFoSetting> crmFoSetting2 = _dbTbl.CrmFoSetting;
					ParameterExpression val = Expression.Parameter(typeof(CrmFoSetting), "m");
					crmFoSetting = Queryable.FirstOrDefault<CrmFoSetting>((IQueryable<CrmFoSetting>)crmFoSetting2, Expression.Lambda<Func<CrmFoSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass128_, typeof(_003C_003Ec__DisplayClass128_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					if (crmFoSetting != null)
					{
						if (_003C_003Ec__DisplayClass128_.model.CmpDefPasswordType.GetValueOrDefault() == -1)
						{
							crmFoSetting.CmpDefPasswordType = null;
						}
						else
						{
							crmFoSetting.CmpDefPasswordType = _003C_003Ec__DisplayClass128_.model.CmpDefPasswordType;
						}
						if (_003C_003Ec__DisplayClass128_.model.CmpDefUsernameType.GetValueOrDefault() == -1)
						{
							crmFoSetting.CmpDefUsernameType = null;
						}
						else
						{
							crmFoSetting.CmpDefUsernameType = _003C_003Ec__DisplayClass128_.model.CmpDefUsernameType;
						}
						crmFoSetting.UserId = UserLogin.CurrentUser.UserId;
						crmFoSetting.RegisterDate = now;
						crmFoSetting.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						crmFoSetting.Year1 = short.Parse(Financial.Get().Id.ToString());
						crmFoSetting.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
						crmFoSetting.AppType = Configuration.AppType;
						if (_003C_003Ec__DisplayClass128_.model.FoSettingId > 0)
						{
							_dbTbl.Entry(crmFoSetting).State = EntityState.Modified;
							_dbTbl.SaveChanges();
							base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
						}
						else
						{
							text = Messages.ErrorNotFound;
						}
					}
					else
					{
						text = Messages.ErrorNotFound;
					}
				}
			}
			else
			{
				text = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			text = Messages.frmErrorMessage;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			text = Messages.frmErrorMessage;
		}
		base.ViewBag.Error = text;
		return View(_003C_003Ec__DisplayClass128_.model);
	}

	[AjaxOnly]
	public JsonResult GetOnlinePayBankInfo()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectOnlinePayBankInfo_Result> list = new List<CRMspSelectOnlinePayBankInfo_Result>();
		try
		{
			list = Enumerable.ToList<CRMspSelectOnlinePayBankInfo_Result>((IEnumerable<CRMspSelectOnlinePayBankInfo_Result>)_dbI.CRMspSelectOnlinePayBankInfo(lCID, result));
			if (list == null)
			{
				list = new List<CRMspSelectOnlinePayBankInfo_Result>();
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

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actFoSetting")]
	public ActionResult EditShopPrdStockCtrlSetting()
	{
		_003C_003Ec__DisplayClass130_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass130_0();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		CS_0024_003C_003E8__locals0.cId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId.GetValueOrDefault() : 0);
		CrmFoSettingShopPrdStockCtrlLanguageViewModel model = new CrmFoSettingShopPrdStockCtrlLanguageViewModel();
		_ = DateTime.Now;
		try
		{
			Enumerable.Where<CrmFoSetting_Lang>((IEnumerable<CrmFoSetting_Lang>)Enumerable.ToList<CrmFoSetting_Lang>((IEnumerable<CrmFoSetting_Lang>)_dbTbl.CrmFoSetting_Lang), (Func<CrmFoSetting_Lang, bool>)((CrmFoSetting_Lang x) => x.CrmFoSetting.CId == CS_0024_003C_003E8__locals0.cId));
			CrmFoSetting crmFoSetting = new CrmFoSetting();
			DbSet<CrmFoSetting> crmFoSetting2 = _dbTbl.CrmFoSetting;
			ParameterExpression val = Expression.Parameter(typeof(CrmFoSetting), "x");
			crmFoSetting = Queryable.FirstOrDefault<CrmFoSetting>((IQueryable<CrmFoSetting>)crmFoSetting2, Expression.Lambda<Func<CrmFoSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Convert((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass130_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), typeof(int?))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmFoSetting == null)
			{
				crmFoSetting = new CrmFoSetting
				{
					FoSettingId = 0
				};
			}
			model = new CrmFoSettingShopPrdStockCtrlLanguageViewModel
			{
				FoSettingId = crmFoSetting.FoSettingId,
				PrdStockControlType = crmFoSetting.PrdStockControlType,
				PrdStockControlDefWhId = crmFoSetting.PrdStockControlDefWhId
			};
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		GetWareHouse();
		return View(model);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult EditShopPrdStockCtrlSetting(CrmFoSettingShopPrdStockCtrlLanguageViewModel model)
	{
		_003C_003Ec__DisplayClass131_0 _003C_003Ec__DisplayClass131_ = new _003C_003Ec__DisplayClass131_0();
		_003C_003Ec__DisplayClass131_.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		GetWareHouse();
		if (_003C_003Ec__DisplayClass131_.model.FoSettingId <= 0)
		{
			text = Messages.ErrorNotFound;
			num++;
		}
		try
		{
			if (base.ModelState.IsValid)
			{
				if (num == 0)
				{
					DateTime now = DateTime.Now;
					CrmFoSetting crmFoSetting = new CrmFoSetting();
					if (_003C_003Ec__DisplayClass131_.model.FoSettingId <= 0)
					{
						text = Messages.ErrorNotFound;
						base.ViewBag.Error = text;
						return View(_003C_003Ec__DisplayClass131_.model);
					}
					DbSet<CrmFoSetting> crmFoSetting2 = _dbTbl.CrmFoSetting;
					ParameterExpression val = Expression.Parameter(typeof(CrmFoSetting), "m");
					crmFoSetting = Queryable.FirstOrDefault<CrmFoSetting>((IQueryable<CrmFoSetting>)crmFoSetting2, Expression.Lambda<Func<CrmFoSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass131_, typeof(_003C_003Ec__DisplayClass131_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					if (crmFoSetting != null)
					{
						crmFoSetting.PrdStockControlType = _003C_003Ec__DisplayClass131_.model.PrdStockControlType;
						crmFoSetting.PrdStockControlDefWhId = _003C_003Ec__DisplayClass131_.model.PrdStockControlDefWhId;
						if (crmFoSetting.PrdStockControlType.GetValueOrDefault() == 2)
						{
							_003C_003Ec__DisplayClass131_.model.PrdStockControlDefWhId = crmFoSetting.ShpDefWHId;
							crmFoSetting.PrdStockControlDefWhId = crmFoSetting.ShpDefWHId;
						}
						else
						{
							_003C_003Ec__DisplayClass131_.model.PrdStockControlDefWhId = null;
							crmFoSetting.PrdStockControlDefWhId = null;
						}
						crmFoSetting.UserId = UserLogin.CurrentUser.UserId;
						crmFoSetting.RegisterDate = now;
						crmFoSetting.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						crmFoSetting.Year1 = short.Parse(Financial.Get().Id.ToString());
						crmFoSetting.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
						crmFoSetting.AppType = Configuration.AppType;
						if (_003C_003Ec__DisplayClass131_.model.FoSettingId > 0)
						{
							_dbTbl.Entry(crmFoSetting).State = EntityState.Modified;
							_dbTbl.SaveChanges();
							base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
						}
						else
						{
							text = Messages.ErrorNotFound;
						}
					}
					else
					{
						text = Messages.ErrorNotFound;
					}
				}
			}
			else
			{
				text = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			text = Messages.frmErrorMessage;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			text = Messages.frmErrorMessage;
		}
		base.ViewBag.Error = text;
		return View(_003C_003Ec__DisplayClass131_.model);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actFoSetting")]
	public ActionResult EditShopCartSetting()
	{
		_003C_003Ec__DisplayClass132_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass132_0();
		GetWareHouse();
		GetCurrencyUnit();
		GetPordVerifierRequest();
		GetOrdVerifierRequest();
		GetOrderOpr();
		GetStatusGroups();
		GetcnvsPriorityList();
		GetTopicList();
		GetCnvsUserList();
		GetCnvsReferUserList();
		GetOrdPayType();
		GetShpCartPayType();
		GetPordAndOrdReferUser();
		GetPordAndOrdVerificationWorkFlow();
		GetPordAndOrdGsmModelSetting();
		GetPordAndOrdSmsProvider();
		GetPordAndOrdEmailSetting();
		GetPordAndOrdEmailUserInfo();
		GetPordCreditDuration();
		GetPordAndOrdPrintFormat();
		GetprjStartUserist();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		CS_0024_003C_003E8__locals0.cId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
		CrmFoSettingShopCartLanguageViewModel crmFoSettingShopCartLanguageViewModel = new CrmFoSettingShopCartLanguageViewModel();
		_ = DateTime.Now;
		try
		{
			string shpDefPordCnvsReferMultiUserName = "";
			string shpDefOrdCnvsReferMultiUserName = "";
			string positionTopRightTxt = Labels.PositionTopRightTxt;
			string positionTopCenterTxt = Labels.PositionTopCenterTxt;
			string positionTopLeftTxt = Labels.PositionTopLeftTxt;
			string positionCenterRightTxt = Labels.PositionCenterRightTxt;
			string positionCenterTxt = Labels.PositionCenterTxt;
			string positionCenterLeftTxt = Labels.PositionCenterLeftTxt;
			string positionBottomRightTxt = Labels.PositionBottomRightTxt;
			string positionBottomCenterTxt = Labels.PositionBottomCenterTxt;
			string positionBottomLeftTxt = Labels.PositionBottomLeftTxt;
			_ = Labels.SmsSendByWebTxt;
			_ = Labels.SmsSendByGsmTxt;
			CRMSpEntities cRMSpEntities = db;
			string foSettingDefDisplay4Column = Labels.FoSettingDefDisplay4Column;
			string foSettingDefDisplay3Column = Labels.FoSettingDefDisplay3Column;
			string foSettingDefDisplayListView = Labels.FoSettingDefDisplayListView;
			string foSettingDefDisplayListViewSmall = Labels.FoSettingDefDisplayListViewSmall;
			int? languageID = CS_0024_003C_003E8__locals0.currLangID;
			int? defaultLanguageID = result;
			CRMspSelectFoSetting_Result cRMspSelectFoSetting_Result = Enumerable.FirstOrDefault<CRMspSelectFoSetting_Result>((IEnumerable<CRMspSelectFoSetting_Result>)cRMSpEntities.CRMspSelectFoSetting(foSettingDefDisplay4Column, foSettingDefDisplay3Column, foSettingDefDisplayListView, foSettingDefDisplayListViewSmall, positionTopRightTxt, positionTopCenterTxt, positionTopLeftTxt, positionCenterRightTxt, positionCenterTxt, positionCenterLeftTxt, positionBottomRightTxt, positionBottomCenterTxt, positionBottomLeftTxt, languageID, defaultLanguageID, CS_0024_003C_003E8__locals0.cId));
			if (cRMspSelectFoSetting_Result != null)
			{
				shpDefPordCnvsReferMultiUserName = cRMspSelectFoSetting_Result.ShpDefPordCnvsReferMultiUserName ?? "";
				shpDefOrdCnvsReferMultiUserName = cRMspSelectFoSetting_Result.ShpDefOrdCnvsReferMultiUserName ?? "";
			}
			IEnumerable<CrmFoSetting_Lang> enumerable = Enumerable.Where<CrmFoSetting_Lang>((IEnumerable<CrmFoSetting_Lang>)Enumerable.ToList<CrmFoSetting_Lang>((IEnumerable<CrmFoSetting_Lang>)_dbTbl.CrmFoSetting_Lang), (Func<CrmFoSetting_Lang, bool>)((CrmFoSetting_Lang x) => x.CrmFoSetting.CId == CS_0024_003C_003E8__locals0.cId));
			CrmFoSetting crmFoSetting = new CrmFoSetting();
			DbSet<CrmFoSetting> crmFoSetting2 = _dbTbl.CrmFoSetting;
			ParameterExpression val = Expression.Parameter(typeof(CrmFoSetting), "x");
			crmFoSetting = Queryable.FirstOrDefault<CrmFoSetting>((IQueryable<CrmFoSetting>)crmFoSetting2, Expression.Lambda<Func<CrmFoSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass132_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmFoSetting == null)
			{
				crmFoSetting = new CrmFoSetting
				{
					FoSettingId = 0
				};
			}
			List<CommonMultiLanguageViewModel> list = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.ShpDefPrjTitle,
				LanguageId = item.LanguageID
			})));
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = crmFoSetting.ShpDefPrjTitle,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.ShpDefPordVerifierRequestMsg,
				LanguageId = item.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = crmFoSetting.ShpDefPordVerifierRequestMsg,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.ShpDefPordCnvsDesc,
				LanguageId = item.LanguageID
			})));
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = crmFoSetting.ShpDefPordCnvsDesc,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.ShpDefOrdVerifierRequestMsg,
				LanguageId = item.LanguageID
			})));
			list4.Add(new CommonMultiLanguageViewModel
			{
				Value = crmFoSetting.ShpDefOrdVerifierRequestMsg,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list5 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.ShpDefOrdCnvsDesc,
				LanguageId = item.LanguageID
			})));
			list5.Add(new CommonMultiLanguageViewModel
			{
				Value = crmFoSetting.ShpDefOrdCnvsDesc,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list6 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.ShpCartDescriptionLbl,
				LanguageId = item.LanguageID
			})));
			list6.Add(new CommonMultiLanguageViewModel
			{
				Value = crmFoSetting.ShpCartDescriptionLbl,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list7 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.ShpCartDescriptionPlaceholder,
				LanguageId = item.LanguageID
			})));
			list7.Add(new CommonMultiLanguageViewModel
			{
				Value = crmFoSetting.ShpCartDescriptionPlaceholder,
				LanguageId = result
			});
			crmFoSettingShopCartLanguageViewModel = new CrmFoSettingShopCartLanguageViewModel
			{
				FoSettingId = crmFoSetting.FoSettingId,
				ShpTransportationDefValue = crmFoSetting.ShpTransportationDefValue,
				ShpTransportationFreeMinValue = crmFoSetting.ShpTransportationFreeMinValue,
				ShpDefPrjcnvsStatusGroupId = crmFoSetting.ShpDefPrjcnvsStatusGroupId,
				ShpDefWHId = crmFoSetting.ShpDefWHId,
				ShpDefCurrencyUnitId = crmFoSetting.ShpDefCurrencyUnitId,
				ShpDefPordVerifierRequestId = crmFoSetting.ShpDefPordVerifierRequestId,
				ShpDefPordExpireDay = crmFoSetting.ShpDefPordExpireDay,
				ShpDefPordCnvsTopicId = crmFoSetting.ShpDefPordCnvsTopicId,
				ShpDefPordCnvsReferUserId = crmFoSetting.ShpDefPordCnvsReferUserId,
				ShpDefPordCnvsReferMultiUser = ((!string.IsNullOrWhiteSpace(crmFoSetting.ShpDefPordCnvsReferMultiUser)) ? crmFoSetting.ShpDefPordCnvsReferMultiUser.Replace(',', '|') : crmFoSetting.ShpDefPordCnvsReferMultiUser),
				ShpDefPordCnvsStatusId = crmFoSetting.ShpDefPordCnvsStatusId,
				ShpDefPordCnvsPriorityId = crmFoSetting.ShpDefPordCnvsPriorityId,
				ShpDefOrderOprId = crmFoSetting.ShpDefOrderOprId,
				ShpDefOrdVerifierRequestId = crmFoSetting.ShpDefOrdVerifierRequestId,
				ShpDefOrdpayTypeId = crmFoSetting.ShpDefOrdpayTypeId,
				ShpDefOrdCnvsTopicId = crmFoSetting.ShpDefOrdCnvsTopicId,
				ShpDefOrdCnvsReferUserId = crmFoSetting.ShpDefOrdCnvsReferUserId,
				ShpDefOrdCnvsReferMultiUser = ((!string.IsNullOrWhiteSpace(crmFoSetting.ShpDefOrdCnvsReferMultiUser)) ? crmFoSetting.ShpDefOrdCnvsReferMultiUser.Replace(',', '|') : crmFoSetting.ShpDefOrdCnvsReferMultiUser),
				ShpDefOrdCnvsStatusId = crmFoSetting.ShpDefOrdCnvsStatusId,
				ShpDefPordCnvsStatusResultId = crmFoSetting.ShpDefPordCnvsStatusResultId,
				ShpDefOrdCnvsStatusResultId = crmFoSetting.ShpDefOrdCnvsStatusResultId,
				ShpDefOrdCnvsPriorityId = crmFoSetting.ShpDefOrdCnvsPriorityId,
				ShpShowPayOnLineRdoBtn = crmFoSetting.ShpShowPayOnLineRdoBtn,
				ShpCartSettlementCreditActive = crmFoSetting.ShpCartSettlementCreditActive,
				FoCanEditPayAmount = crmFoSetting.FoCanEditPayAmount,
				ShpDefPrjTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				ShpDefPrjTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				ShpDefPordVerifierRequestMsg = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				ShpDefPordVerifierRequestMsg_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				ShpDefPordCnvsDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				ShpDefPordCnvsDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				ShpDefOrdVerifierRequestMsg = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				ShpDefOrdVerifierRequestMsg_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				ShpDefOrdCnvsDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				ShpDefOrdCnvsDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				ShpDefPordCnvsReferMultiUserName = shpDefPordCnvsReferMultiUserName,
				ShpDefOrdCnvsReferMultiUserName = shpDefOrdCnvsReferMultiUserName,
				ShpCartDescriptionLbl = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				ShpCartDescriptionLbl_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				ShpCartDescriptionPlaceholder = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				ShpCartDescriptionPlaceholder_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				ShpCartPayTypeIds = crmFoSetting.ShpCartPayTypeIds,
				ShpPrsAddressNotNull = crmFoSetting.ShpPrsAddressNotNull,
				ShpDeliveryScheduleActive = crmFoSetting.ShpDeliveryScheduleActive,
				ShpPrdDeliveryScheduleActive = crmFoSetting.ShpPrdDeliveryScheduleActive,
				ShpPrdDeliveryScheduleActiveInBox = crmFoSetting.ShpPrdDeliveryScheduleActiveInBox,
				ShpPrdDeliveryScheduleActiveInDetail = crmFoSetting.ShpPrdDeliveryScheduleActiveInDetail,
				ShpDeliveryScheduleLimitMoveDay = crmFoSetting.ShpDeliveryScheduleLimitMoveDay,
				ShpCartIssuePordAfterPayOnLine = crmFoSetting.ShpCartIssuePordAfterPayOnLine,
				ShpDefPordReferUserId = crmFoSetting.ShpDefPordReferUserId,
				ShpPordVerifyAfterIssue = crmFoSetting.ShpPordVerifyAfterIssue,
				ShpDefPordVerifyWorkFlowId = crmFoSetting.ShpDefPordVerifyWorkFlowId,
				ShpPordVerifyWorkFlowStartAfterIssue = crmFoSetting.ShpPordVerifyWorkFlowStartAfterIssue,
				ShpPordSendSmsAfterIssue = crmFoSetting.ShpPordSendSmsAfterIssue,
				ShpPordSendSmsAfterIssueGSM = crmFoSetting.ShpPordSendSmsAfterIssueGSM,
				ShpDefPordSendSmsAfterIssueGSMSetId = crmFoSetting.ShpDefPordSendSmsAfterIssueGSMSetId,
				ShpPordSendSmsAfterIssueWeb = crmFoSetting.ShpPordSendSmsAfterIssueWeb,
				ShpDefPordSendSmsAfterIssueProviderId = crmFoSetting.ShpDefPordSendSmsAfterIssueProviderId,
				ShpDefPordSendSmsAfterIssueNumber = crmFoSetting.ShpDefPordSendSmsAfterIssueNumber,
				ShpDefPordSendSmsAfterIssueBodyPatternFormula = crmFoSetting.ShpDefPordSendSmsAfterIssueBodyPatternFormula,
				ShpPordSendEmailAfterIssue = crmFoSetting.ShpPordSendEmailAfterIssue,
				ShpDefPordSendEmailAfterIssueSettingId = crmFoSetting.ShpDefPordSendEmailAfterIssueSettingId,
				ShpDefPordSendEmailAfterIssueUserInfoId = crmFoSetting.ShpDefPordSendEmailAfterIssueUserInfoId,
				ShpDefPordSendEmailAfterIssueSubjectPatternFormula = crmFoSetting.ShpDefPordSendEmailAfterIssueSubjectPatternFormula,
				ShpDefPordSendEmailAfterIssueBodyPatternFormula = crmFoSetting.ShpDefPordSendEmailAfterIssueBodyPatternFormula,
				ShpCartIssueOrdAfterPayOnLine = crmFoSetting.ShpCartIssueOrdAfterPayOnLine,
				ShpDefOrdReferUserId = crmFoSetting.ShpDefOrdReferUserId,
				ShpOrdVerifyAfterIssue = crmFoSetting.ShpOrdVerifyAfterIssue,
				ShpDefOrdVerifyWorkFlowId = crmFoSetting.ShpDefOrdVerifyWorkFlowId,
				ShpOrdVerifyWorkFlowStartAfterIssue = crmFoSetting.ShpOrdVerifyWorkFlowStartAfterIssue,
				ShpOrdSendSmsAfterIssue = crmFoSetting.ShpOrdSendSmsAfterIssue,
				ShpOrdSendSmsAfterIssueGSM = crmFoSetting.ShpOrdSendSmsAfterIssueGSM,
				ShpDefOrdSendSmsAfterIssueGSMSetId = crmFoSetting.ShpDefOrdSendSmsAfterIssueGSMSetId,
				ShpOrdSendSmsAfterIssueWeb = crmFoSetting.ShpOrdSendSmsAfterIssueWeb,
				ShpDefOrdSendSmsAfterIssueProviderId = crmFoSetting.ShpDefOrdSendSmsAfterIssueProviderId,
				ShpDefOrdSendSmsAfterIssueNumber = crmFoSetting.ShpDefOrdSendSmsAfterIssueNumber,
				ShpDefOrdSendSmsAfterIssueBodyPatternFormula = crmFoSetting.ShpDefOrdSendSmsAfterIssueBodyPatternFormula,
				ShpOrdSendEmailAfterIssue = crmFoSetting.ShpOrdSendEmailAfterIssue,
				ShpDefOrdSendEmailAfterIssueSettingId = crmFoSetting.ShpDefOrdSendEmailAfterIssueSettingId,
				ShpDefOrdSendEmailAfterIssueUserInfoId = crmFoSetting.ShpDefOrdSendEmailAfterIssueUserInfoId,
				ShpDefOrdSendEmailAfterIssueSubjectPatternFormula = crmFoSetting.ShpDefOrdSendEmailAfterIssueSubjectPatternFormula,
				ShpDefOrdSendEmailAfterIssueBodyPatternFormula = crmFoSetting.ShpDefOrdSendEmailAfterIssueBodyPatternFormula,
				ShpOrdSendLinkAccAfterIssue = crmFoSetting.ShpOrdSendLinkAccAfterIssue,
				ShpDefPordPayTypeId = crmFoSetting.ShpDefPordPayTypeId,
				ShpShowDeliveryTerm = crmFoSetting.ShpShowDeliveryTerm,
				ShpPrdDoneTimeScheduleActive = crmFoSetting.ShpPrdDoneTimeScheduleActive,
				ShpDefItemCalculateTax = crmFoSetting.ShpDefItemCalculateTax,
				ShpDefItemTaxIndex = crmFoSetting.ShpDefItemTaxIndex,
				ShpDefItemTaxType = crmFoSetting.ShpDefItemTaxType,
				ShpDefPordCreditDurationId = crmFoSetting.ShpDefPordCreditDurationId,
				ShpDefPordPrintFormatId = crmFoSetting.ShpDefPordPrintFormatId,
				ShpPordSendSmsAfterVerify = crmFoSetting.ShpPordSendSmsAfterVerify,
				ShpPordSendSmsAfterVerifyGSM = crmFoSetting.ShpPordSendSmsAfterVerifyGSM,
				ShpDefPordSendSmsAfterVerifyGSMSetId = crmFoSetting.ShpDefPordSendSmsAfterVerifyGSMSetId,
				ShpPordSendSmsAfterVerifyWeb = crmFoSetting.ShpPordSendSmsAfterVerifyWeb,
				ShpDefPordSendSmsAfterVerifyProviderId = crmFoSetting.ShpDefPordSendSmsAfterVerifyProviderId,
				ShpDefPordSendSmsAfterVerifyNumber = crmFoSetting.ShpDefPordSendSmsAfterVerifyNumber,
				ShpDefPordSendSmsAfterVerifyBodyPatternFormula = crmFoSetting.ShpDefPordSendSmsAfterVerifyBodyPatternFormula,
				ShpDefOrdPrintFormatId = crmFoSetting.ShpDefOrdPrintFormatId,
				ShpOrdSendSmsAfterVerify = crmFoSetting.ShpOrdSendSmsAfterVerify,
				ShpOrdSendSmsAfterVerifyGSM = crmFoSetting.ShpOrdSendSmsAfterVerifyGSM,
				ShpDefOrdSendSmsAfterVerifyGSMSetId = crmFoSetting.ShpDefOrdSendSmsAfterVerifyGSMSetId,
				ShpOrdSendSmsAfterVerifyWeb = crmFoSetting.ShpOrdSendSmsAfterVerifyWeb,
				ShpDefOrdSendSmsAfterVerifyProviderId = crmFoSetting.ShpDefOrdSendSmsAfterVerifyProviderId,
				ShpDefOrdSendSmsAfterVerifyNumber = crmFoSetting.ShpDefOrdSendSmsAfterVerifyNumber,
				ShpDefOrdSendSmsAfterVerifyBodyPatternFormula = crmFoSetting.ShpDefOrdSendSmsAfterVerifyBodyPatternFormula,
				ShpCanSaveOnlinePaymentAfterVerify = crmFoSetting.ShpCanSaveOnlinePaymentAfterVerify,
				ShpDefPrjStarterUserId = crmFoSetting.ShpDefPrjStarterUserId,
				ShpDefPrjNewProjectOnCart = crmFoSetting.ShpDefPrjNewProjectOnCart,
				ShpTransportationVisible = crmFoSetting.ShpTransportationVisible,
				ShpToleranceVisible = crmFoSetting.ShpToleranceVisible,
				ShpTolerancePercent = crmFoSetting.ShpTolerancePercent,
				ShpToleranceLinkedPrdId = crmFoSetting.ShpToleranceLinkedPrdId
			};
			if (crmFoSettingShopCartLanguageViewModel != null && crmFoSettingShopCartLanguageViewModel.ShpToleranceLinkedPrdId.GetValueOrDefault() != 0)
			{
				WSspSelectProductsWithId_Result wSspSelectProductsWithId_Result = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)db.WSspSelectProductsWithId(crmFoSettingShopCartLanguageViewModel.ShpToleranceLinkedPrdId.GetValueOrDefault(), CS_0024_003C_003E8__locals0.currLangID, result));
				if (wSspSelectProductsWithId_Result != null)
				{
					crmFoSettingShopCartLanguageViewModel.ShpToleranceLinkedPrd = wSspSelectProductsWithId_Result.PrdName + ((!string.IsNullOrWhiteSpace(wSspSelectProductsWithId_Result.PrdCode)) ? (" (" + wSspSelectProductsWithId_Result.PrdCode + ")") : "");
					crmFoSettingShopCartLanguageViewModel.ShpToleranceLinkedPrdAutoCalcPrice = wSspSelectProductsWithId_Result.PrdAutoCalcPrice.GetValueOrDefault();
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(crmFoSettingShopCartLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult EditShopCartSetting(CrmFoSettingShopCartLanguageViewModel model)
	{
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02be: Unknown result type (might be due to invalid IL or missing references)
		//IL_0312: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass133_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass133_0();
		CS_0024_003C_003E8__locals0.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		GetWareHouse();
		GetCurrencyUnit();
		GetPordVerifierRequest();
		GetOrdVerifierRequest();
		GetOrderOpr();
		GetStatusGroups();
		GetTopicList();
		GetCnvsUserList();
		GetCnvsReferUserList();
		GetOrdPayType();
		GetcnvsPriorityList();
		GetShpCartPayType();
		GetPordAndOrdReferUser();
		GetPordAndOrdVerificationWorkFlow();
		GetPordAndOrdGsmModelSetting();
		GetPordAndOrdSmsProvider();
		GetPordAndOrdEmailSetting();
		GetPordAndOrdEmailUserInfo();
		GetPordCreditDuration();
		GetPordAndOrdPrintFormat();
		GetprjStartUserist();
		string text = "";
		int num = 0;
		try
		{
			if (base.ModelState.IsValid)
			{
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.ShpDefPrjTitle_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.ShpDefPrjTitle_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.ShpDefPrjTitle,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.ShpDefPordVerifierRequestMsg_Lang))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.ShpDefPordVerifierRequestMsg_Lang);
				}
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.ShpDefPordVerifierRequestMsg,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.ShpDefPordCnvsDesc_Lang))
				{
					list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.ShpDefPordCnvsDesc_Lang);
				}
				list3.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.ShpDefPordCnvsDesc,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.ShpDefOrdVerifierRequestMsg_Lang))
				{
					list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.ShpDefOrdVerifierRequestMsg_Lang);
				}
				list4.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.ShpDefOrdVerifierRequestMsg,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.ShpDefOrdCnvsDesc_Lang))
				{
					list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.ShpDefOrdCnvsDesc_Lang);
				}
				list5.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.ShpDefOrdCnvsDesc,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.ShpCartDescriptionLbl_Lang))
				{
					list6 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.ShpCartDescriptionLbl_Lang);
				}
				list6.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.ShpCartDescriptionLbl,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list7 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.ShpCartDescriptionPlaceholder_Lang))
				{
					list7 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.ShpCartDescriptionPlaceholder_Lang);
				}
				list7.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.ShpCartDescriptionPlaceholder,
					LanguageId = lCID
				});
				if (num == 0)
				{
					DateTime now = DateTime.Now;
					CrmFoSetting crmFoSetting = new CrmFoSetting();
					if (CS_0024_003C_003E8__locals0.model.FoSettingId > 0)
					{
						DbSet<CrmFoSetting> crmFoSetting2 = _dbTbl.CrmFoSetting;
						ParameterExpression val = Expression.Parameter(typeof(CrmFoSetting), "m");
						crmFoSetting = Queryable.FirstOrDefault<CrmFoSetting>((IQueryable<CrmFoSetting>)crmFoSetting2, Expression.Lambda<Func<CrmFoSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass133_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					}
					if (crmFoSetting != null)
					{
						if ((!crmFoSetting.ShpDefLinkAccSettingDBId.HasValue || crmFoSetting.ShpDefLinkAccSettingDBId == 0) && CS_0024_003C_003E8__locals0.model.ShpOrdSendLinkAccAfterIssue.GetValueOrDefault())
						{
							text = Messages.msgErrorFoSettingLinkAccAfterIssueRequiresShpDefDB;
							base.ViewBag.Error = text;
							return View(CS_0024_003C_003E8__locals0.model);
						}
						crmFoSetting.ShpTransportationDefValue = CS_0024_003C_003E8__locals0.model.ShpTransportationDefValue;
						crmFoSetting.ShpTransportationFreeMinValue = CS_0024_003C_003E8__locals0.model.ShpTransportationFreeMinValue;
						crmFoSetting.ShpDefPrjcnvsStatusGroupId = CS_0024_003C_003E8__locals0.model.ShpDefPrjcnvsStatusGroupId;
						crmFoSetting.ShpDefWHId = CS_0024_003C_003E8__locals0.model.ShpDefWHId;
						if (crmFoSetting.PrdStockControlType.GetValueOrDefault() == 2)
						{
							crmFoSetting.PrdStockControlDefWhId = crmFoSetting.ShpDefWHId;
						}
						CrmMobSetting crmMobSetting = Queryable.FirstOrDefault<CrmMobSetting>((IQueryable<CrmMobSetting>)_dbTbl.CrmMobSetting);
						if (crmMobSetting != null)
						{
							crmMobSetting.PordWHId = crmFoSetting.ShpDefWHId;
							crmMobSetting.UserId = UserLogin.CurrentUser.UserId;
							crmMobSetting.RegisterDate = now;
							crmMobSetting.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
							crmMobSetting.Year1 = short.Parse(Financial.Get().Id.ToString());
							crmMobSetting.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
							crmMobSetting.AppType = Configuration.AppType;
							_dbTbl.Entry(crmMobSetting).State = EntityState.Modified;
							_dbTbl.SaveChanges();
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmMobSetting");
						}
						crmFoSetting.ShpDefCurrencyUnitId = CS_0024_003C_003E8__locals0.model.ShpDefCurrencyUnitId;
						crmFoSetting.ShpDefPordVerifierRequestId = CS_0024_003C_003E8__locals0.model.ShpDefPordVerifierRequestId;
						crmFoSetting.ShpDefPordExpireDay = CS_0024_003C_003E8__locals0.model.ShpDefPordExpireDay;
						crmFoSetting.ShpDefPordCnvsTopicId = CS_0024_003C_003E8__locals0.model.ShpDefPordCnvsTopicId;
						crmFoSetting.ShpDefPordCnvsReferUserId = CS_0024_003C_003E8__locals0.model.ShpDefPordCnvsReferUserId;
						crmFoSetting.ShpDefPordCnvsReferMultiUser = CS_0024_003C_003E8__locals0.model.ShpDefPordCnvsReferMultiUser;
						if (!string.IsNullOrWhiteSpace(crmFoSetting.ShpDefPordCnvsReferMultiUser))
						{
							crmFoSetting.ShpDefPordCnvsReferMultiUser = crmFoSetting.ShpDefPordCnvsReferMultiUser.Replace('|', ',');
						}
						crmFoSetting.ShpPrdDoneTimeScheduleActive = CS_0024_003C_003E8__locals0.model.ShpPrdDoneTimeScheduleActive;
						crmFoSetting.ShpDefPordCnvsStatusId = CS_0024_003C_003E8__locals0.model.ShpDefPordCnvsStatusId;
						crmFoSetting.ShpDefPordCnvsPriorityId = CS_0024_003C_003E8__locals0.model.ShpDefPordCnvsPriorityId;
						crmFoSetting.ShpDefOrderOprId = CS_0024_003C_003E8__locals0.model.ShpDefOrderOprId;
						crmFoSetting.ShpDefOrdVerifierRequestId = CS_0024_003C_003E8__locals0.model.ShpDefOrdVerifierRequestId;
						crmFoSetting.ShpDefOrdpayTypeId = CS_0024_003C_003E8__locals0.model.ShpDefOrdpayTypeId;
						crmFoSetting.ShpDefOrdCnvsTopicId = CS_0024_003C_003E8__locals0.model.ShpDefOrdCnvsTopicId;
						crmFoSetting.ShpDefOrdCnvsReferUserId = CS_0024_003C_003E8__locals0.model.ShpDefOrdCnvsReferUserId;
						crmFoSetting.ShpDefOrdCnvsReferMultiUser = CS_0024_003C_003E8__locals0.model.ShpDefOrdCnvsReferMultiUser;
						if (!string.IsNullOrWhiteSpace(crmFoSetting.ShpDefOrdCnvsReferMultiUser))
						{
							crmFoSetting.ShpDefOrdCnvsReferMultiUser = crmFoSetting.ShpDefOrdCnvsReferMultiUser.Replace('|', ',');
						}
						crmFoSetting.ShpDefOrdCnvsStatusId = CS_0024_003C_003E8__locals0.model.ShpDefOrdCnvsStatusId;
						crmFoSetting.ShpDefOrdCnvsPriorityId = CS_0024_003C_003E8__locals0.model.ShpDefOrdCnvsPriorityId;
						crmFoSetting.ShpDefPordCnvsStatusResultId = CS_0024_003C_003E8__locals0.model.ShpDefPordCnvsStatusResultId;
						crmFoSetting.ShpDefOrdCnvsStatusResultId = CS_0024_003C_003E8__locals0.model.ShpDefOrdCnvsStatusResultId;
						crmFoSetting.ShpShowPayOnLineRdoBtn = CS_0024_003C_003E8__locals0.model.ShpShowPayOnLineRdoBtn;
						crmFoSetting.ShpCartSettlementCreditActive = CS_0024_003C_003E8__locals0.model.ShpCartSettlementCreditActive;
						crmFoSetting.FoCanEditPayAmount = CS_0024_003C_003E8__locals0.model.FoCanEditPayAmount;
						crmFoSetting.UserId = UserLogin.CurrentUser.UserId;
						crmFoSetting.RegisterDate = now;
						crmFoSetting.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						crmFoSetting.Year1 = short.Parse(Financial.Get().Id.ToString());
						crmFoSetting.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
						crmFoSetting.AppType = Configuration.AppType;
						crmFoSetting.ShpDefPrjTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmFoSetting.ShpDefPordVerifierRequestMsg = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmFoSetting.ShpDefPordCnvsDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmFoSetting.ShpDefOrdVerifierRequestMsg = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmFoSetting.ShpDefOrdCnvsDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmFoSetting.ShpCartDescriptionLbl = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmFoSetting.ShpCartDescriptionPlaceholder = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						if (crmFoSetting.ShpDefPordCnvsStatusId == 0)
						{
							crmFoSetting.ShpDefPordCnvsStatusId = null;
						}
						if (crmFoSetting.ShpDefOrdCnvsStatusId == 0)
						{
							crmFoSetting.ShpDefOrdCnvsStatusId = null;
						}
						if (crmFoSetting.ShpDefPordCnvsStatusResultId == 0)
						{
							crmFoSetting.ShpDefPordCnvsStatusResultId = null;
						}
						if (crmFoSetting.ShpDefOrdCnvsStatusResultId == 0)
						{
							crmFoSetting.ShpDefOrdCnvsStatusResultId = null;
						}
						crmFoSetting.ShpCartPayTypeIds = CS_0024_003C_003E8__locals0.model.ShpCartPayTypeIds;
						if (crmFoSetting.ShpCartPayTypeIds != null && (!crmFoSetting.ShpShowPayOnLineRdoBtn.HasValue || crmFoSetting.ShpShowPayOnLineRdoBtn == false) && Enumerable.FirstOrDefault<string>((IEnumerable<string>)Enumerable.ToList<string>((IEnumerable<string>)(crmFoSetting.ShpCartPayTypeIds ?? "").Split(new char[1] { ',' })), (Func<string, bool>)((string x) => x == "2")) != null)
						{
							crmFoSetting.ShpShowPayOnLineRdoBtn = true;
						}
						if (!VersionBuyer.OnlinePay)
						{
							crmFoSetting.ShpShowPayOnLineRdoBtn = false;
						}
						crmFoSetting.ShpPrsAddressNotNull = CS_0024_003C_003E8__locals0.model.ShpPrsAddressNotNull;
						crmFoSetting.ShpDeliveryScheduleActive = CS_0024_003C_003E8__locals0.model.ShpDeliveryScheduleActive;
						crmFoSetting.ShpPrdDeliveryScheduleActive = CS_0024_003C_003E8__locals0.model.ShpPrdDeliveryScheduleActive;
						crmFoSetting.ShpPrdDeliveryScheduleActiveInBox = CS_0024_003C_003E8__locals0.model.ShpPrdDeliveryScheduleActiveInBox;
						crmFoSetting.ShpPrdDeliveryScheduleActiveInDetail = CS_0024_003C_003E8__locals0.model.ShpPrdDeliveryScheduleActiveInDetail;
						crmFoSetting.ShpDeliveryScheduleLimitMoveDay = CS_0024_003C_003E8__locals0.model.ShpDeliveryScheduleLimitMoveDay;
						crmFoSetting.ShpCartIssuePordAfterPayOnLine = CS_0024_003C_003E8__locals0.model.ShpCartIssuePordAfterPayOnLine;
						crmFoSetting.ShpDefPordReferUserId = CS_0024_003C_003E8__locals0.model.ShpDefPordReferUserId;
						crmFoSetting.ShpPordVerifyAfterIssue = CS_0024_003C_003E8__locals0.model.ShpPordVerifyAfterIssue;
						crmFoSetting.ShpDefPordVerifyWorkFlowId = CS_0024_003C_003E8__locals0.model.ShpDefPordVerifyWorkFlowId;
						crmFoSetting.ShpPordVerifyWorkFlowStartAfterIssue = CS_0024_003C_003E8__locals0.model.ShpPordVerifyWorkFlowStartAfterIssue;
						crmFoSetting.ShpPordSendSmsAfterIssue = CS_0024_003C_003E8__locals0.model.ShpPordSendSmsAfterIssue;
						crmFoSetting.ShpPordSendSmsAfterIssueGSM = CS_0024_003C_003E8__locals0.model.ShpPordSendSmsAfterIssueGSM;
						crmFoSetting.ShpDefPordSendSmsAfterIssueGSMSetId = CS_0024_003C_003E8__locals0.model.ShpDefPordSendSmsAfterIssueGSMSetId;
						crmFoSetting.ShpPordSendSmsAfterIssueWeb = CS_0024_003C_003E8__locals0.model.ShpPordSendSmsAfterIssueWeb;
						crmFoSetting.ShpDefPordSendSmsAfterIssueProviderId = CS_0024_003C_003E8__locals0.model.ShpDefPordSendSmsAfterIssueProviderId;
						crmFoSetting.ShpDefPordSendSmsAfterIssueNumber = CS_0024_003C_003E8__locals0.model.ShpDefPordSendSmsAfterIssueNumber;
						crmFoSetting.ShpDefPordSendSmsAfterIssueBodyPatternFormula = CS_0024_003C_003E8__locals0.model.ShpDefPordSendSmsAfterIssueBodyPatternFormula;
						crmFoSetting.ShpPordSendEmailAfterIssue = CS_0024_003C_003E8__locals0.model.ShpPordSendEmailAfterIssue;
						crmFoSetting.ShpDefPordSendEmailAfterIssueSettingId = CS_0024_003C_003E8__locals0.model.ShpDefPordSendEmailAfterIssueSettingId;
						crmFoSetting.ShpDefPordSendEmailAfterIssueUserInfoId = CS_0024_003C_003E8__locals0.model.ShpDefPordSendEmailAfterIssueUserInfoId;
						crmFoSetting.ShpDefPordSendEmailAfterIssueSubjectPatternFormula = CS_0024_003C_003E8__locals0.model.ShpDefPordSendEmailAfterIssueSubjectPatternFormula;
						crmFoSetting.ShpDefPordSendEmailAfterIssueBodyPatternFormula = CS_0024_003C_003E8__locals0.model.ShpDefPordSendEmailAfterIssueBodyPatternFormula;
						crmFoSetting.ShpCartIssueOrdAfterPayOnLine = CS_0024_003C_003E8__locals0.model.ShpCartIssueOrdAfterPayOnLine;
						crmFoSetting.ShpDefOrdReferUserId = CS_0024_003C_003E8__locals0.model.ShpDefOrdReferUserId;
						crmFoSetting.ShpOrdVerifyAfterIssue = CS_0024_003C_003E8__locals0.model.ShpOrdVerifyAfterIssue;
						crmFoSetting.ShpDefOrdVerifyWorkFlowId = CS_0024_003C_003E8__locals0.model.ShpDefOrdVerifyWorkFlowId;
						crmFoSetting.ShpOrdVerifyWorkFlowStartAfterIssue = CS_0024_003C_003E8__locals0.model.ShpOrdVerifyWorkFlowStartAfterIssue;
						crmFoSetting.ShpOrdSendSmsAfterIssue = CS_0024_003C_003E8__locals0.model.ShpOrdSendSmsAfterIssue;
						crmFoSetting.ShpOrdSendSmsAfterIssueGSM = CS_0024_003C_003E8__locals0.model.ShpOrdSendSmsAfterIssueGSM;
						crmFoSetting.ShpDefOrdSendSmsAfterIssueGSMSetId = CS_0024_003C_003E8__locals0.model.ShpDefOrdSendSmsAfterIssueGSMSetId;
						crmFoSetting.ShpOrdSendSmsAfterIssueWeb = CS_0024_003C_003E8__locals0.model.ShpOrdSendSmsAfterIssueWeb;
						crmFoSetting.ShpDefOrdSendSmsAfterIssueProviderId = CS_0024_003C_003E8__locals0.model.ShpDefOrdSendSmsAfterIssueProviderId;
						crmFoSetting.ShpDefOrdSendSmsAfterIssueNumber = CS_0024_003C_003E8__locals0.model.ShpDefOrdSendSmsAfterIssueNumber;
						crmFoSetting.ShpDefOrdSendSmsAfterIssueBodyPatternFormula = CS_0024_003C_003E8__locals0.model.ShpDefOrdSendSmsAfterIssueBodyPatternFormula;
						crmFoSetting.ShpOrdSendEmailAfterIssue = CS_0024_003C_003E8__locals0.model.ShpOrdSendEmailAfterIssue;
						crmFoSetting.ShpDefOrdSendEmailAfterIssueSettingId = CS_0024_003C_003E8__locals0.model.ShpDefOrdSendEmailAfterIssueSettingId;
						crmFoSetting.ShpDefOrdSendEmailAfterIssueUserInfoId = CS_0024_003C_003E8__locals0.model.ShpDefOrdSendEmailAfterIssueUserInfoId;
						crmFoSetting.ShpDefOrdSendEmailAfterIssueSubjectPatternFormula = CS_0024_003C_003E8__locals0.model.ShpDefOrdSendEmailAfterIssueSubjectPatternFormula;
						crmFoSetting.ShpDefOrdSendEmailAfterIssueBodyPatternFormula = CS_0024_003C_003E8__locals0.model.ShpDefOrdSendEmailAfterIssueBodyPatternFormula;
						crmFoSetting.ShpOrdSendLinkAccAfterIssue = CS_0024_003C_003E8__locals0.model.ShpOrdSendLinkAccAfterIssue;
						crmFoSetting.ShpDefPordPayTypeId = CS_0024_003C_003E8__locals0.model.ShpDefPordPayTypeId;
						crmFoSetting.ShpShowDeliveryTerm = CS_0024_003C_003E8__locals0.model.ShpShowDeliveryTerm;
						crmFoSetting.ShpDefItemCalculateTax = CS_0024_003C_003E8__locals0.model.ShpDefItemCalculateTax;
						crmFoSetting.ShpDefItemTaxIndex = CS_0024_003C_003E8__locals0.model.ShpDefItemTaxIndex;
						crmFoSetting.ShpDefItemTaxType = CS_0024_003C_003E8__locals0.model.ShpDefItemTaxType;
						crmFoSetting.ShpDefPordCreditDurationId = CS_0024_003C_003E8__locals0.model.ShpDefPordCreditDurationId;
						crmFoSetting.ShpDefPordPrintFormatId = CS_0024_003C_003E8__locals0.model.ShpDefPordPrintFormatId;
						crmFoSetting.ShpPordSendSmsAfterVerify = CS_0024_003C_003E8__locals0.model.ShpPordSendSmsAfterVerify;
						crmFoSetting.ShpPordSendSmsAfterVerifyGSM = CS_0024_003C_003E8__locals0.model.ShpPordSendSmsAfterVerifyGSM;
						crmFoSetting.ShpDefPordSendSmsAfterVerifyGSMSetId = CS_0024_003C_003E8__locals0.model.ShpDefPordSendSmsAfterVerifyGSMSetId;
						crmFoSetting.ShpPordSendSmsAfterVerifyWeb = CS_0024_003C_003E8__locals0.model.ShpPordSendSmsAfterVerifyWeb;
						crmFoSetting.ShpDefPordSendSmsAfterVerifyProviderId = CS_0024_003C_003E8__locals0.model.ShpDefPordSendSmsAfterVerifyProviderId;
						crmFoSetting.ShpDefPordSendSmsAfterVerifyNumber = CS_0024_003C_003E8__locals0.model.ShpDefPordSendSmsAfterVerifyNumber;
						crmFoSetting.ShpDefPordSendSmsAfterVerifyBodyPatternFormula = CS_0024_003C_003E8__locals0.model.ShpDefPordSendSmsAfterVerifyBodyPatternFormula;
						crmFoSetting.ShpDefOrdPrintFormatId = CS_0024_003C_003E8__locals0.model.ShpDefOrdPrintFormatId;
						crmFoSetting.ShpOrdSendSmsAfterVerify = CS_0024_003C_003E8__locals0.model.ShpOrdSendSmsAfterVerify;
						crmFoSetting.ShpOrdSendSmsAfterVerifyGSM = CS_0024_003C_003E8__locals0.model.ShpOrdSendSmsAfterVerifyGSM;
						crmFoSetting.ShpDefOrdSendSmsAfterVerifyGSMSetId = CS_0024_003C_003E8__locals0.model.ShpDefOrdSendSmsAfterVerifyGSMSetId;
						crmFoSetting.ShpOrdSendSmsAfterVerifyWeb = CS_0024_003C_003E8__locals0.model.ShpOrdSendSmsAfterVerifyWeb;
						crmFoSetting.ShpDefOrdSendSmsAfterVerifyProviderId = CS_0024_003C_003E8__locals0.model.ShpDefOrdSendSmsAfterVerifyProviderId;
						crmFoSetting.ShpDefOrdSendSmsAfterVerifyNumber = CS_0024_003C_003E8__locals0.model.ShpDefOrdSendSmsAfterVerifyNumber;
						crmFoSetting.ShpDefOrdSendSmsAfterVerifyBodyPatternFormula = CS_0024_003C_003E8__locals0.model.ShpDefOrdSendSmsAfterVerifyBodyPatternFormula;
						crmFoSetting.ShpCanSaveOnlinePaymentAfterVerify = CS_0024_003C_003E8__locals0.model.ShpCanSaveOnlinePaymentAfterVerify;
						crmFoSetting.ShpDefPrjStarterUserId = CS_0024_003C_003E8__locals0.model.ShpDefPrjStarterUserId;
						crmFoSetting.ShpDefPrjNewProjectOnCart = CS_0024_003C_003E8__locals0.model.ShpDefPrjNewProjectOnCart;
						crmFoSetting.ShpTransportationVisible = CS_0024_003C_003E8__locals0.model.ShpTransportationVisible;
						crmFoSetting.ShpToleranceVisible = CS_0024_003C_003E8__locals0.model.ShpToleranceVisible;
						crmFoSetting.ShpTolerancePercent = CS_0024_003C_003E8__locals0.model.ShpTolerancePercent;
						crmFoSetting.ShpToleranceLinkedPrdId = CS_0024_003C_003E8__locals0.model.ShpToleranceLinkedPrdId;
						if (crmFoSetting.ShpToleranceLinkedPrdId.GetValueOrDefault() != 0)
						{
							WSspSelectProductsWithId_Result wSspSelectProductsWithId_Result = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)db.WSspSelectProductsWithId(crmFoSetting.ShpToleranceLinkedPrdId.GetValueOrDefault(), lCID, CS_0024_003C_003E8__locals0.defLangID));
							if (wSspSelectProductsWithId_Result != null && wSspSelectProductsWithId_Result.PrdAutoCalcPrice.GetValueOrDefault())
							{
								crmFoSetting.ShpTolerancePercent = wSspSelectProductsWithId_Result.PrdAutoCalcPricePercent;
								CS_0024_003C_003E8__locals0.model.ShpTolerancePercent = crmFoSetting.ShpTolerancePercent;
							}
						}
						if (CS_0024_003C_003E8__locals0.model.FoSettingId > 0)
						{
							_dbTbl.Entry(crmFoSetting).State = EntityState.Modified;
							_dbTbl.SaveChanges();
							using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									_003C_003Ec__DisplayClass133_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass133_1();
									CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
									CS_0024_003C_003E8__locals1.lang = enumerator.Current;
									DbSet<CrmFoSetting_Lang> crmFoSetting_Lang = _dbTbl.CrmFoSetting_Lang;
									ParameterExpression val = Expression.Parameter(typeof(CrmFoSetting_Lang), "c");
									CrmFoSetting_Lang crmFoSetting_Lang2 = Queryable.FirstOrDefault<CrmFoSetting_Lang>((IQueryable<CrmFoSetting_Lang>)crmFoSetting_Lang, Expression.Lambda<Func<CrmFoSetting_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass133_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Convert((Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass133_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), typeof(int?)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
									if (crmFoSetting_Lang2 != null)
									{
										crmFoSetting_Lang2.ShpDefPrjTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										crmFoSetting_Lang2.ShpDefPordVerifierRequestMsg = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										crmFoSetting_Lang2.ShpDefPordCnvsDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										crmFoSetting_Lang2.ShpDefOrdVerifierRequestMsg = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										crmFoSetting_Lang2.ShpDefOrdCnvsDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										crmFoSetting_Lang2.ShpCartDescriptionLbl = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										crmFoSetting_Lang2.ShpCartDescriptionPlaceholder = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										_dbTbl.Entry(crmFoSetting_Lang2).State = EntityState.Modified;
										_dbTbl.SaveChanges();
										continue;
									}
									crmFoSetting_Lang2 = new CrmFoSetting_Lang
									{
										PrjDefaultTitle = " ",
										CnvsDefaultDesc = " ",
										ShpDefPrjTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
										ShpDefPordVerifierRequestMsg = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
										ShpDefPordCnvsDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
										ShpDefOrdVerifierRequestMsg = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
										ShpDefOrdCnvsDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
										ShpCartDescriptionLbl = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
										ShpCartDescriptionPlaceholder = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
										FoSettingId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.FoSettingId,
										LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID
									};
									_dbTbl.CrmFoSetting_Lang.Add(crmFoSetting_Lang2);
									_dbTbl.SaveChanges();
								}
							}
							base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
							new FilesManager();
							new FacadeFTP(Configuration.FacadeFtpFo);
							string pathFtpFo = Configuration.PathFtpFo;
							string userNameFtpFo = Configuration.UserNameFtpFo;
							string passwordFtpFo = Configuration.PasswordFtpFo;
							bool usePassiveFtpFo = Configuration.UsePassiveFtpFo;
							if (!string.IsNullOrEmpty(pathFtpFo) && !string.IsNullOrEmpty(userNameFtpFo) && !string.IsNullOrEmpty(passwordFtpFo))
							{
								try
								{
									if (list6 != null)
									{
										Files.UploadPicFromEditorToFtp(pathFtpFo, userNameFtpFo, passwordFtpFo, usePassiveFtpFo, list6);
									}
								}
								catch (Exception e)
								{
									ErrorSignal.FromCurrentContext().Raise(e);
								}
							}
						}
						else
						{
							text = Messages.ErrorNotFound;
						}
					}
					else
					{
						text = Messages.ErrorNotFound;
					}
				}
			}
			else
			{
				text = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
		}
		catch (DbEntityValidationException e2)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e2);
			text = Messages.frmErrorMessage;
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
			text = Messages.frmErrorMessage;
		}
		base.ViewBag.Error = text;
		return View(CS_0024_003C_003E8__locals0.model);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actFoSetting")]
	public ActionResult EditFoTabSetting()
	{
		_003C_003Ec__DisplayClass134_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass134_0();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		CS_0024_003C_003E8__locals0.cId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId.GetValueOrDefault() : 0);
		CrmFoSettingFoTabLanguageViewModel model = new CrmFoSettingFoTabLanguageViewModel();
		_ = DateTime.Now;
		try
		{
			IEnumerable<CrmFoSetting_Lang> enumerable = Enumerable.Where<CrmFoSetting_Lang>((IEnumerable<CrmFoSetting_Lang>)Enumerable.ToList<CrmFoSetting_Lang>((IEnumerable<CrmFoSetting_Lang>)_dbTbl.CrmFoSetting_Lang), (Func<CrmFoSetting_Lang, bool>)((CrmFoSetting_Lang x) => x.CrmFoSetting.CId == CS_0024_003C_003E8__locals0.cId));
			CrmFoSetting crmFoSetting = new CrmFoSetting();
			DbSet<CrmFoSetting> crmFoSetting2 = _dbTbl.CrmFoSetting;
			ParameterExpression val = Expression.Parameter(typeof(CrmFoSetting), "x");
			crmFoSetting = Queryable.FirstOrDefault<CrmFoSetting>((IQueryable<CrmFoSetting>)crmFoSetting2, Expression.Lambda<Func<CrmFoSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Convert((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass134_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), typeof(int?))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmFoSetting == null)
			{
				crmFoSetting = new CrmFoSetting
				{
					FoSettingId = 0
				};
			}
			List<CommonMultiLanguageViewModel> list = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.FoCmpInfoTabTitle,
				LanguageId = item.LanguageID
			})));
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = crmFoSetting.FoCmpInfoTabTitle,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.FoLinkedCmpInfoTabTitle,
				LanguageId = item.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = crmFoSetting.FoLinkedCmpInfoTabTitle,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.FoCmpPrjInfoTabTitle,
				LanguageId = item.LanguageID
			})));
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = crmFoSetting.FoCmpPrjInfoTabTitle,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.FoLinkedCmpPrjInfoTabTitle,
				LanguageId = item.LanguageID
			})));
			list4.Add(new CommonMultiLanguageViewModel
			{
				Value = crmFoSetting.FoLinkedCmpPrjInfoTabTitle,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list5 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.FoCmpPordInfoTabTitle,
				LanguageId = item.LanguageID
			})));
			list5.Add(new CommonMultiLanguageViewModel
			{
				Value = crmFoSetting.FoCmpPordInfoTabTitle,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list6 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.FoLinkedCmpPordInfoTabTitle,
				LanguageId = item.LanguageID
			})));
			list6.Add(new CommonMultiLanguageViewModel
			{
				Value = crmFoSetting.FoLinkedCmpPordInfoTabTitle,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list7 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.FoCmpOrdInfoTabTitle,
				LanguageId = item.LanguageID
			})));
			list7.Add(new CommonMultiLanguageViewModel
			{
				Value = crmFoSetting.FoCmpOrdInfoTabTitle,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list8 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.FoLinkedCmpOrdInfoTabTitle,
				LanguageId = item.LanguageID
			})));
			list8.Add(new CommonMultiLanguageViewModel
			{
				Value = crmFoSetting.FoLinkedCmpOrdInfoTabTitle,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list9 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.FoCmpDraftInfoTabTitle,
				LanguageId = item.LanguageID
			})));
			list9.Add(new CommonMultiLanguageViewModel
			{
				Value = crmFoSetting.FoCmpDraftInfoTabTitle,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list10 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.FoLinkedCmpDraftInfoTabTitle,
				LanguageId = item.LanguageID
			})));
			list10.Add(new CommonMultiLanguageViewModel
			{
				Value = crmFoSetting.FoLinkedCmpDraftInfoTabTitle,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list11 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.FoCmpTicketInfoTabTitle,
				LanguageId = item.LanguageID
			})));
			list11.Add(new CommonMultiLanguageViewModel
			{
				Value = crmFoSetting.FoCmpTicketInfoTabTitle,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list12 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.FoDyFormInfoTabTitle,
				LanguageId = item.LanguageID
			})));
			list12.Add(new CommonMultiLanguageViewModel
			{
				Value = crmFoSetting.FoDyFormInfoTabTitle,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list13 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.FoCmpLinkedInfoTabTitle,
				LanguageId = item.LanguageID
			})));
			list13.Add(new CommonMultiLanguageViewModel
			{
				Value = crmFoSetting.FoCmpLinkedInfoTabTitle,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list14 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.FoCmpLetterInfoTabTitle,
				LanguageId = item.LanguageID
			})));
			list14.Add(new CommonMultiLanguageViewModel
			{
				Value = crmFoSetting.FoCmpLetterInfoTabTitle,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list15 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.FoCmpFileInfoTabTitle,
				LanguageId = item.LanguageID
			})));
			list15.Add(new CommonMultiLanguageViewModel
			{
				Value = crmFoSetting.FoCmpFileInfoTabTitle,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list16 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.FoSurveyInfoTabTitle,
				LanguageId = item.LanguageID
			})));
			list16.Add(new CommonMultiLanguageViewModel
			{
				Value = crmFoSetting.FoSurveyInfoTabTitle,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list17 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.FoDiscountCodeInfoTabTitle,
				LanguageId = item.LanguageID
			})));
			list17.Add(new CommonMultiLanguageViewModel
			{
				Value = crmFoSetting.FoDiscountCodeInfoTabTitle,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list18 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.FoCmpMnBgInfoTabTitle,
				LanguageId = item.LanguageID
			})));
			list18.Add(new CommonMultiLanguageViewModel
			{
				Value = crmFoSetting.FoCmpMnBgInfoTabTitle,
				LanguageId = result
			});
			model = new CrmFoSettingFoTabLanguageViewModel
			{
				FoSettingId = crmFoSetting.FoSettingId,
				FoCmpInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				FoLinkedCmpInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				FoCmpPrjInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				FoShowCmpPrjInfoTab = crmFoSetting.FoShowCmpPrjInfoTab,
				FoLinkedCmpPrjInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				FoShowLinkedCmpPrjInfoTab = crmFoSetting.FoShowLinkedCmpPrjInfoTab,
				FoCmpPordInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				FoShowCmpPordInfoTab = crmFoSetting.FoShowCmpPordInfoTab,
				FoLinkedCmpPordInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				FoShowLinkedCmpPordInfoTab = crmFoSetting.FoShowLinkedCmpPordInfoTab,
				FoCmpOrdInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				FoShowCmpOrdInfoTab = crmFoSetting.FoShowCmpOrdInfoTab,
				FoLinkedCmpOrdInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				FoShowLinkedCmpOrdInfoTab = crmFoSetting.FoShowLinkedCmpOrdInfoTab,
				FoCmpDraftInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				FoShowCmpDraftInfoTab = crmFoSetting.FoShowCmpDraftInfoTab,
				FoDiscountCodeInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list17, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list17, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				FoShowDiscountCodeInfoTab = crmFoSetting.FoShowDiscountCodeInfoTab,
				FoLinkedCmpDraftInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				FoShowLinkedCmpDraftInfoTab = crmFoSetting.FoShowLinkedCmpDraftInfoTab,
				FoCmpTicketInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				FoShowCmpTicketInfoTab = crmFoSetting.FoShowCmpTicketInfoTab,
				FoDyFormInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				FoShowDyFormInfoTab = crmFoSetting.FoShowDyFormInfoTab,
				FoCmpLinkedInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				FoShowCmpLinkedInfoTab = crmFoSetting.FoShowCmpLinkedInfoTab,
				FoCmpInfoTabTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				FoLinkedCmpInfoTabTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				FoCmpPrjInfoTabTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				FoLinkedCmpPrjInfoTabTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				FoCmpPordInfoTabTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				FoLinkedCmpPordInfoTabTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				FoCmpOrdInfoTabTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				FoLinkedCmpOrdInfoTabTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				FoCmpDraftInfoTabTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				FoDiscountCodeInfoTabTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list17, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				FoLinkedCmpDraftInfoTabTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				FoCmpTicketInfoTabTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				FoDyFormInfoTabTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				FoCmpLinkedInfoTabTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				FoCmpLetterInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				FoShowCmpLetterInfoTab = crmFoSetting.FoShowCmpLetterInfoTab,
				FoCmpLetterInfoTabTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				FoCmpFileInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list15, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list15, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				FoShowCmpFileInfoTab = crmFoSetting.FoShowCmpFileInfoTab,
				FoCmpFileInfoTabTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list15, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				FoSurveyInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list16, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list16, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				FoShowSurveyInfoTab = crmFoSetting.FoShowSurveyInfoTab,
				FoSurveyInfoTabTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list16, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				FoCmpMnBgInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list18, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list18, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				FoShowCmpMnBgInfoTab = crmFoSetting.FoShowCmpMnBgInfoTab,
				FoCmpMnBgInfoTabTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list18, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))))
			};
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(model);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actFoSetting")]
	[ValidateAntiForgeryToken]
	public ActionResult EditFoTabSetting(CrmFoSettingFoTabLanguageViewModel model)
	{
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0327: Unknown result type (might be due to invalid IL or missing references)
		//IL_037b: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0423: Unknown result type (might be due to invalid IL or missing references)
		//IL_0477: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_051f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0573: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_061b: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass135_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass135_0();
		CS_0024_003C_003E8__locals0.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		try
		{
			if (base.ModelState.IsValid)
			{
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.FoCmpInfoTabTitle_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.FoCmpInfoTabTitle_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.FoCmpInfoTabTitle,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.FoLinkedCmpInfoTabTitle_Lang))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.FoLinkedCmpInfoTabTitle_Lang);
				}
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.FoLinkedCmpInfoTabTitle,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.FoCmpPrjInfoTabTitle_Lang))
				{
					list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.FoCmpPrjInfoTabTitle_Lang);
				}
				list3.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.FoCmpPrjInfoTabTitle,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.FoLinkedCmpPrjInfoTabTitle_Lang))
				{
					list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.FoLinkedCmpPrjInfoTabTitle_Lang);
				}
				list4.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.FoLinkedCmpPrjInfoTabTitle,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.FoCmpPordInfoTabTitle_Lang))
				{
					list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.FoCmpPordInfoTabTitle_Lang);
				}
				list5.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.FoCmpPordInfoTabTitle,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.FoLinkedCmpPordInfoTabTitle_Lang))
				{
					list6 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.FoLinkedCmpPordInfoTabTitle_Lang);
				}
				list6.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.FoLinkedCmpPordInfoTabTitle,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list7 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.FoCmpOrdInfoTabTitle_Lang))
				{
					list7 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.FoCmpOrdInfoTabTitle_Lang);
				}
				list7.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.FoCmpOrdInfoTabTitle,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list8 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.FoLinkedCmpOrdInfoTabTitle_Lang))
				{
					list8 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.FoLinkedCmpOrdInfoTabTitle_Lang);
				}
				list8.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.FoLinkedCmpOrdInfoTabTitle,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list9 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.FoCmpDraftInfoTabTitle_Lang))
				{
					list9 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.FoCmpDraftInfoTabTitle_Lang);
				}
				list9.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.FoCmpDraftInfoTabTitle,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list10 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.FoLinkedCmpDraftInfoTabTitle_Lang))
				{
					list10 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.FoLinkedCmpDraftInfoTabTitle_Lang);
				}
				list10.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.FoLinkedCmpDraftInfoTabTitle,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list11 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.FoCmpTicketInfoTabTitle_Lang))
				{
					list11 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.FoCmpTicketInfoTabTitle_Lang);
				}
				list11.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.FoCmpTicketInfoTabTitle,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list12 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.FoDyFormInfoTabTitle_Lang))
				{
					list12 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.FoDyFormInfoTabTitle_Lang);
				}
				list12.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.FoDyFormInfoTabTitle,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list13 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.FoCmpLinkedInfoTabTitle_Lang))
				{
					list13 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.FoCmpLinkedInfoTabTitle_Lang);
				}
				list13.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.FoCmpLinkedInfoTabTitle,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list14 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.FoCmpLetterInfoTabTitle_Lang))
				{
					list14 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.FoCmpLetterInfoTabTitle_Lang);
				}
				list14.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.FoCmpLetterInfoTabTitle,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list15 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.FoCmpFileInfoTabTitle_Lang))
				{
					list15 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.FoCmpFileInfoTabTitle_Lang);
				}
				list15.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.FoCmpFileInfoTabTitle,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list16 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.FoSurveyInfoTabTitle_Lang))
				{
					list16 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.FoSurveyInfoTabTitle_Lang);
				}
				list16.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.FoSurveyInfoTabTitle,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list17 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.FoDiscountCodeInfoTabTitle_Lang))
				{
					list17 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.FoDiscountCodeInfoTabTitle_Lang);
				}
				list17.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.FoDiscountCodeInfoTabTitle,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list18 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.FoCmpMnBgInfoTabTitle_Lang))
				{
					list18 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.FoCmpMnBgInfoTabTitle_Lang);
				}
				list18.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.FoCmpMnBgInfoTabTitle,
					LanguageId = lCID
				});
				if (num == 0)
				{
					DateTime now = DateTime.Now;
					CrmFoSetting crmFoSetting = new CrmFoSetting();
					if (CS_0024_003C_003E8__locals0.model.FoSettingId > 0)
					{
						DbSet<CrmFoSetting> crmFoSetting2 = _dbTbl.CrmFoSetting;
						ParameterExpression val = Expression.Parameter(typeof(CrmFoSetting), "m");
						crmFoSetting = Queryable.FirstOrDefault<CrmFoSetting>((IQueryable<CrmFoSetting>)crmFoSetting2, Expression.Lambda<Func<CrmFoSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass135_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					}
					if (crmFoSetting != null)
					{
						crmFoSetting.FoCmpInfoTabTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmFoSetting.FoLinkedCmpInfoTabTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmFoSetting.FoCmpPrjInfoTabTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmFoSetting.FoShowCmpPrjInfoTab = CS_0024_003C_003E8__locals0.model.FoShowCmpPrjInfoTab;
						crmFoSetting.FoLinkedCmpPrjInfoTabTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmFoSetting.FoShowLinkedCmpPrjInfoTab = CS_0024_003C_003E8__locals0.model.FoShowLinkedCmpPrjInfoTab;
						crmFoSetting.FoCmpPordInfoTabTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmFoSetting.FoShowCmpPordInfoTab = CS_0024_003C_003E8__locals0.model.FoShowCmpPordInfoTab;
						crmFoSetting.FoLinkedCmpPordInfoTabTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmFoSetting.FoShowLinkedCmpPordInfoTab = CS_0024_003C_003E8__locals0.model.FoShowLinkedCmpPordInfoTab;
						crmFoSetting.FoCmpOrdInfoTabTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmFoSetting.FoShowCmpOrdInfoTab = CS_0024_003C_003E8__locals0.model.FoShowCmpOrdInfoTab;
						crmFoSetting.FoLinkedCmpOrdInfoTabTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmFoSetting.FoShowLinkedCmpOrdInfoTab = CS_0024_003C_003E8__locals0.model.FoShowLinkedCmpOrdInfoTab;
						crmFoSetting.FoCmpDraftInfoTabTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmFoSetting.FoShowCmpDraftInfoTab = CS_0024_003C_003E8__locals0.model.FoShowCmpDraftInfoTab;
						crmFoSetting.FoDiscountCodeInfoTabTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list17, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list17, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmFoSetting.FoShowDiscountCodeInfoTab = CS_0024_003C_003E8__locals0.model.FoShowDiscountCodeInfoTab;
						crmFoSetting.FoLinkedCmpDraftInfoTabTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmFoSetting.FoShowLinkedCmpDraftInfoTab = CS_0024_003C_003E8__locals0.model.FoShowLinkedCmpDraftInfoTab;
						crmFoSetting.FoCmpTicketInfoTabTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmFoSetting.FoShowCmpTicketInfoTab = CS_0024_003C_003E8__locals0.model.FoShowCmpTicketInfoTab;
						crmFoSetting.FoDyFormInfoTabTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmFoSetting.FoShowDyFormInfoTab = CS_0024_003C_003E8__locals0.model.FoShowDyFormInfoTab;
						crmFoSetting.FoCmpLinkedInfoTabTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmFoSetting.FoShowCmpLinkedInfoTab = CS_0024_003C_003E8__locals0.model.FoShowCmpLinkedInfoTab;
						crmFoSetting.FoCmpLetterInfoTabTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmFoSetting.FoShowCmpLetterInfoTab = CS_0024_003C_003E8__locals0.model.FoShowCmpLetterInfoTab;
						crmFoSetting.FoCmpFileInfoTabTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list15, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list15, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmFoSetting.FoShowCmpFileInfoTab = CS_0024_003C_003E8__locals0.model.FoShowCmpFileInfoTab;
						crmFoSetting.FoSurveyInfoTabTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list16, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list16, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmFoSetting.FoShowSurveyInfoTab = CS_0024_003C_003E8__locals0.model.FoShowSurveyInfoTab;
						crmFoSetting.FoCmpMnBgInfoTabTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list18, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list18, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmFoSetting.FoShowCmpMnBgInfoTab = CS_0024_003C_003E8__locals0.model.FoShowCmpMnBgInfoTab;
						crmFoSetting.UserId = UserLogin.CurrentUser.UserId;
						crmFoSetting.RegisterDate = now;
						crmFoSetting.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						crmFoSetting.Year1 = short.Parse(Financial.Get().Id.ToString());
						crmFoSetting.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
						crmFoSetting.AppType = Configuration.AppType;
						if (CS_0024_003C_003E8__locals0.model.FoSettingId > 0)
						{
							_dbTbl.Entry(crmFoSetting).State = EntityState.Modified;
							_dbTbl.SaveChanges();
							using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									_003C_003Ec__DisplayClass135_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass135_1();
									CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
									CS_0024_003C_003E8__locals1.lang = enumerator.Current;
									DbSet<CrmFoSetting_Lang> crmFoSetting_Lang = _dbTbl.CrmFoSetting_Lang;
									ParameterExpression val = Expression.Parameter(typeof(CrmFoSetting_Lang), "c");
									CrmFoSetting_Lang crmFoSetting_Lang2 = Queryable.FirstOrDefault<CrmFoSetting_Lang>((IQueryable<CrmFoSetting_Lang>)crmFoSetting_Lang, Expression.Lambda<Func<CrmFoSetting_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass135_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Convert((Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass135_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), typeof(int?)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
									if (crmFoSetting_Lang2 != null)
									{
										crmFoSetting_Lang2.FoCmpInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										crmFoSetting_Lang2.FoLinkedCmpInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										crmFoSetting_Lang2.FoCmpPrjInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										crmFoSetting_Lang2.FoLinkedCmpPrjInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										crmFoSetting_Lang2.FoCmpPordInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										crmFoSetting_Lang2.FoLinkedCmpPordInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										crmFoSetting_Lang2.FoCmpOrdInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										crmFoSetting_Lang2.FoLinkedCmpOrdInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										crmFoSetting_Lang2.FoCmpDraftInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										crmFoSetting_Lang2.FoDiscountCodeInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list17, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list17, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										crmFoSetting_Lang2.FoLinkedCmpDraftInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										crmFoSetting_Lang2.FoCmpTicketInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										crmFoSetting_Lang2.FoDyFormInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										crmFoSetting_Lang2.FoCmpLinkedInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										crmFoSetting_Lang2.FoCmpLetterInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										crmFoSetting_Lang2.FoCmpFileInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list15, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list15, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										crmFoSetting_Lang2.FoSurveyInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list16, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list16, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										crmFoSetting_Lang2.FoCmpMnBgInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list18, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list18, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										_dbTbl.Entry(crmFoSetting_Lang2).State = EntityState.Modified;
										_dbTbl.SaveChanges();
										continue;
									}
									crmFoSetting_Lang2 = new CrmFoSetting_Lang
									{
										FoCmpInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
										FoLinkedCmpInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
										FoCmpPrjInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
										FoLinkedCmpPrjInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
										FoCmpPordInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
										FoLinkedCmpPordInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
										FoCmpOrdInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
										FoLinkedCmpOrdInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
										FoCmpDraftInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
										FoDiscountCodeInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list17, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list17, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
										FoLinkedCmpDraftInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
										FoCmpTicketInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
										FoDyFormInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
										FoCmpLinkedInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
										FoCmpLetterInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
										FoCmpFileInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list15, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list15, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
										FoSurveyInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list16, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list16, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
										FoCmpMnBgInfoTabTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list18, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list18, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
									};
									_dbTbl.CrmFoSetting_Lang.Add(crmFoSetting_Lang2);
									_dbTbl.SaveChanges();
								}
							}
							base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmFoSetting");
						}
						else
						{
							text = Messages.ErrorNotFound;
						}
					}
					else
					{
						text = Messages.ErrorNotFound;
					}
				}
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			text = Messages.frmErrorMessage;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			text = Messages.frmErrorMessage;
		}
		base.ViewBag.Error = text;
		return View(CS_0024_003C_003E8__locals0.model);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actFoSetting")]
	public ActionResult EditFoActionSetting()
	{
		_003C_003Ec__DisplayClass136_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass136_0();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		CS_0024_003C_003E8__locals0.cId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId.GetValueOrDefault() : 0);
		CrmFoSettingFoActionLanguageViewModel model = new CrmFoSettingFoActionLanguageViewModel();
		_ = DateTime.Now;
		try
		{
			Enumerable.Where<CrmFoSetting_Lang>((IEnumerable<CrmFoSetting_Lang>)Enumerable.ToList<CrmFoSetting_Lang>((IEnumerable<CrmFoSetting_Lang>)_dbTbl.CrmFoSetting_Lang), (Func<CrmFoSetting_Lang, bool>)((CrmFoSetting_Lang x) => x.CrmFoSetting.CId == CS_0024_003C_003E8__locals0.cId));
			CrmFoSetting crmFoSetting = new CrmFoSetting();
			DbSet<CrmFoSetting> crmFoSetting2 = _dbTbl.CrmFoSetting;
			ParameterExpression val = Expression.Parameter(typeof(CrmFoSetting), "x");
			crmFoSetting = Queryable.FirstOrDefault<CrmFoSetting>((IQueryable<CrmFoSetting>)crmFoSetting2, Expression.Lambda<Func<CrmFoSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Convert((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass136_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), typeof(int?))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmFoSetting == null)
			{
				crmFoSetting = new CrmFoSetting
				{
					FoSettingId = 0
				};
			}
			model = new CrmFoSettingFoActionLanguageViewModel
			{
				FoSettingId = crmFoSetting.FoSettingId,
				FoActAddProductToOrder = crmFoSetting.FoActAddProductToOrder
			};
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(model);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actFoSetting")]
	[ValidateAntiForgeryToken]
	public ActionResult EditFoActionSetting(CrmFoSettingFoActionLanguageViewModel model)
	{
		_003C_003Ec__DisplayClass137_0 _003C_003Ec__DisplayClass137_ = new _003C_003Ec__DisplayClass137_0();
		_003C_003Ec__DisplayClass137_.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		try
		{
			if (base.ModelState.IsValid && num == 0)
			{
				DateTime now = DateTime.Now;
				CrmFoSetting crmFoSetting = new CrmFoSetting();
				if (_003C_003Ec__DisplayClass137_.model.FoSettingId > 0)
				{
					DbSet<CrmFoSetting> crmFoSetting2 = _dbTbl.CrmFoSetting;
					ParameterExpression val = Expression.Parameter(typeof(CrmFoSetting), "m");
					crmFoSetting = Queryable.FirstOrDefault<CrmFoSetting>((IQueryable<CrmFoSetting>)crmFoSetting2, Expression.Lambda<Func<CrmFoSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass137_, typeof(_003C_003Ec__DisplayClass137_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				if (crmFoSetting != null)
				{
					crmFoSetting.FoActAddProductToOrder = _003C_003Ec__DisplayClass137_.model.FoActAddProductToOrder;
					crmFoSetting.UserId = UserLogin.CurrentUser.UserId;
					crmFoSetting.RegisterDate = now;
					crmFoSetting.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					crmFoSetting.Year1 = short.Parse(Financial.Get().Id.ToString());
					crmFoSetting.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
					crmFoSetting.AppType = Configuration.AppType;
					if (_003C_003Ec__DisplayClass137_.model.FoSettingId > 0)
					{
						_dbTbl.Entry(crmFoSetting).State = EntityState.Modified;
						_dbTbl.SaveChanges();
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					}
					else
					{
						text = Messages.ErrorNotFound;
					}
				}
				else
				{
					text = Messages.ErrorNotFound;
				}
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			text = Messages.frmErrorMessage;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			text = Messages.frmErrorMessage;
		}
		base.ViewBag.Error = text;
		return View(_003C_003Ec__DisplayClass137_.model);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actFoSetting")]
	public ActionResult EditFoSalesOrderLblSetting()
	{
		_003C_003Ec__DisplayClass138_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass138_0();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		CS_0024_003C_003E8__locals0.cId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId.GetValueOrDefault() : 0);
		CrmFoSettingSalesOrderLblLanguageViewModel model = new CrmFoSettingSalesOrderLblLanguageViewModel();
		_ = DateTime.Now;
		try
		{
			IEnumerable<CrmFoSetting_Lang> enumerable = Enumerable.Where<CrmFoSetting_Lang>((IEnumerable<CrmFoSetting_Lang>)Enumerable.ToList<CrmFoSetting_Lang>((IEnumerable<CrmFoSetting_Lang>)_dbTbl.CrmFoSetting_Lang), (Func<CrmFoSetting_Lang, bool>)((CrmFoSetting_Lang x) => x.CrmFoSetting.CId == CS_0024_003C_003E8__locals0.cId));
			CrmFoSetting crmFoSetting = new CrmFoSetting();
			DbSet<CrmFoSetting> crmFoSetting2 = _dbTbl.CrmFoSetting;
			ParameterExpression val = Expression.Parameter(typeof(CrmFoSetting), "x");
			crmFoSetting = Queryable.FirstOrDefault<CrmFoSetting>((IQueryable<CrmFoSetting>)crmFoSetting2, Expression.Lambda<Func<CrmFoSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Convert((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass138_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), typeof(int?))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmFoSetting == null)
			{
				crmFoSetting = new CrmFoSetting
				{
					FoSettingId = 0
				};
			}
			List<CommonMultiLanguageViewModel> list = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.FoSalesOrderLbl,
				LanguageId = item.LanguageID
			})));
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = crmFoSetting.FoSalesOrderLbl,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.FoSalesReturnOrderLbl,
				LanguageId = item.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = crmFoSetting.FoSalesReturnOrderLbl,
				LanguageId = result
			});
			model = new CrmFoSettingSalesOrderLblLanguageViewModel
			{
				FoSettingId = crmFoSetting.FoSettingId,
				FoSalesOrderLbl = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				FoSalesReturnOrderLbl = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				FoSalesOrderLbl_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				FoSalesReturnOrderLbl_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				FoOrdListShowType = crmFoSetting.FoOrdListShowType
			};
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(model);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actFoSetting")]
	[ValidateAntiForgeryToken]
	public ActionResult EditFoSalesOrderLblSetting(CrmFoSettingSalesOrderLblLanguageViewModel model)
	{
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass139_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass139_0();
		CS_0024_003C_003E8__locals0.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		try
		{
			if (base.ModelState.IsValid)
			{
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.FoSalesOrderLbl_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.FoSalesOrderLbl_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.FoSalesOrderLbl,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.FoSalesReturnOrderLbl_Lang))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.FoSalesReturnOrderLbl_Lang);
				}
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.FoSalesReturnOrderLbl,
					LanguageId = lCID
				});
				if (num == 0)
				{
					DateTime now = DateTime.Now;
					CrmFoSetting crmFoSetting = new CrmFoSetting();
					if (CS_0024_003C_003E8__locals0.model.FoSettingId > 0)
					{
						DbSet<CrmFoSetting> crmFoSetting2 = _dbTbl.CrmFoSetting;
						ParameterExpression val = Expression.Parameter(typeof(CrmFoSetting), "m");
						crmFoSetting = Queryable.FirstOrDefault<CrmFoSetting>((IQueryable<CrmFoSetting>)crmFoSetting2, Expression.Lambda<Func<CrmFoSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass139_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					}
					if (crmFoSetting != null)
					{
						crmFoSetting.FoSalesOrderLbl = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmFoSetting.FoSalesReturnOrderLbl = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmFoSetting.FoOrdListShowType = CS_0024_003C_003E8__locals0.model.FoOrdListShowType;
						crmFoSetting.UserId = UserLogin.CurrentUser.UserId;
						crmFoSetting.RegisterDate = now;
						crmFoSetting.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						crmFoSetting.Year1 = short.Parse(Financial.Get().Id.ToString());
						crmFoSetting.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
						crmFoSetting.AppType = Configuration.AppType;
						if (CS_0024_003C_003E8__locals0.model.FoSettingId > 0)
						{
							_dbTbl.Entry(crmFoSetting).State = EntityState.Modified;
							_dbTbl.SaveChanges();
							using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									_003C_003Ec__DisplayClass139_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass139_1();
									CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
									CS_0024_003C_003E8__locals1.lang = enumerator.Current;
									DbSet<CrmFoSetting_Lang> crmFoSetting_Lang = _dbTbl.CrmFoSetting_Lang;
									ParameterExpression val = Expression.Parameter(typeof(CrmFoSetting_Lang), "c");
									CrmFoSetting_Lang crmFoSetting_Lang2 = Queryable.FirstOrDefault<CrmFoSetting_Lang>((IQueryable<CrmFoSetting_Lang>)crmFoSetting_Lang, Expression.Lambda<Func<CrmFoSetting_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass139_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Convert((Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass139_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), typeof(int?)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
									if (crmFoSetting_Lang2 != null)
									{
										crmFoSetting_Lang2.FoSalesOrderLbl = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										crmFoSetting_Lang2.FoSalesReturnOrderLbl = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										_dbTbl.Entry(crmFoSetting_Lang2).State = EntityState.Modified;
										_dbTbl.SaveChanges();
										continue;
									}
									crmFoSetting_Lang2 = new CrmFoSetting_Lang
									{
										FoSalesOrderLbl = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
										FoSalesReturnOrderLbl = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
									};
									_dbTbl.CrmFoSetting_Lang.Add(crmFoSetting_Lang2);
									_dbTbl.SaveChanges();
								}
							}
							base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmFoSetting");
						}
						else
						{
							text = Messages.ErrorNotFound;
						}
					}
					else
					{
						text = Messages.ErrorNotFound;
					}
				}
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			text = Messages.frmErrorMessage;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			text = Messages.frmErrorMessage;
		}
		base.ViewBag.Error = text;
		return View(CS_0024_003C_003E8__locals0.model);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actFoSetting")]
	public ActionResult EditFoSalesPreOrderSetting()
	{
		_003C_003Ec__DisplayClass140_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass140_0();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		_ = DateTime.Now;
		CS_0024_003C_003E8__locals0.cId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId.GetValueOrDefault() : 0);
		int num = 0;
		string text = "";
		try
		{
			Enumerable.Where<CrmFoSetting_Lang>((IEnumerable<CrmFoSetting_Lang>)Enumerable.ToList<CrmFoSetting_Lang>((IEnumerable<CrmFoSetting_Lang>)_dbTbl.CrmFoSetting_Lang), (Func<CrmFoSetting_Lang, bool>)((CrmFoSetting_Lang x) => x.CrmFoSetting.CId == CS_0024_003C_003E8__locals0.cId));
			CrmFoSetting crmFoSetting = new CrmFoSetting();
			DbSet<CrmFoSetting> crmFoSetting2 = _dbTbl.CrmFoSetting;
			ParameterExpression val = Expression.Parameter(typeof(CrmFoSetting), "x");
			crmFoSetting = Queryable.FirstOrDefault<CrmFoSetting>((IQueryable<CrmFoSetting>)crmFoSetting2, Expression.Lambda<Func<CrmFoSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Convert((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass140_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), typeof(int?))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmFoSetting != null)
			{
				num = crmFoSetting.FoSettingId;
				text = crmFoSetting.FoPordListShowType;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.FoSettingId = num;
		base.ViewBag.FoPordListShowType = text;
		return View();
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actFoSetting")]
	public string EditFoSalesPreOrderSetting(int foId = 0, string foPordListShowType = "")
	{
		_003C_003Ec__DisplayClass141_0 _003C_003Ec__DisplayClass141_ = new _003C_003Ec__DisplayClass141_0();
		_003C_003Ec__DisplayClass141_.foId = foId;
		string result = "";
		try
		{
			DbSet<CrmFoSetting> crmFoSetting = _dbTbl.CrmFoSetting;
			ParameterExpression val = Expression.Parameter(typeof(CrmFoSetting), "x");
			CrmFoSetting crmFoSetting2 = Queryable.FirstOrDefault<CrmFoSetting>((IQueryable<CrmFoSetting>)crmFoSetting, Expression.Lambda<Func<CrmFoSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass141_, typeof(_003C_003Ec__DisplayClass141_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmFoSetting2 != null)
			{
				crmFoSetting2.FoPordListShowType = foPordListShowType;
				_dbTbl.Entry(crmFoSetting2).State = EntityState.Modified;
				_dbTbl.SaveChanges();
			}
			else
			{
				result = Messages.ErrorNotFound;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			result = ex.Message;
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actFoSetting")]
	public ActionResult EditFoOrdListShowTypeSetting()
	{
		_003C_003Ec__DisplayClass142_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass142_0();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		CS_0024_003C_003E8__locals0.cId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId.GetValueOrDefault() : 0);
		CrmFoSettingFoOrdListShowTypeLanguageViewModel model = new CrmFoSettingFoOrdListShowTypeLanguageViewModel();
		_ = DateTime.Now;
		try
		{
			Enumerable.Where<CrmFoSetting_Lang>((IEnumerable<CrmFoSetting_Lang>)Enumerable.ToList<CrmFoSetting_Lang>((IEnumerable<CrmFoSetting_Lang>)_dbTbl.CrmFoSetting_Lang), (Func<CrmFoSetting_Lang, bool>)((CrmFoSetting_Lang x) => x.CrmFoSetting.CId == CS_0024_003C_003E8__locals0.cId));
			CrmFoSetting crmFoSetting = new CrmFoSetting();
			DbSet<CrmFoSetting> crmFoSetting2 = _dbTbl.CrmFoSetting;
			ParameterExpression val = Expression.Parameter(typeof(CrmFoSetting), "x");
			crmFoSetting = Queryable.FirstOrDefault<CrmFoSetting>((IQueryable<CrmFoSetting>)crmFoSetting2, Expression.Lambda<Func<CrmFoSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Convert((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass142_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), typeof(int?))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmFoSetting == null)
			{
				crmFoSetting = new CrmFoSetting
				{
					FoSettingId = 0
				};
			}
			model = new CrmFoSettingFoOrdListShowTypeLanguageViewModel
			{
				FoSettingId = crmFoSetting.FoSettingId,
				FoOrdListShowType = crmFoSetting.FoOrdListShowType
			};
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(model);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actFoSetting")]
	[ValidateAntiForgeryToken]
	public ActionResult EditFoOrdListShowTypeSetting(CrmFoSettingFoOrdListShowTypeLanguageViewModel model)
	{
		_003C_003Ec__DisplayClass143_0 _003C_003Ec__DisplayClass143_ = new _003C_003Ec__DisplayClass143_0();
		_003C_003Ec__DisplayClass143_.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		try
		{
			if (base.ModelState.IsValid && num == 0)
			{
				DateTime now = DateTime.Now;
				CrmFoSetting crmFoSetting = new CrmFoSetting();
				if (_003C_003Ec__DisplayClass143_.model.FoSettingId > 0)
				{
					DbSet<CrmFoSetting> crmFoSetting2 = _dbTbl.CrmFoSetting;
					ParameterExpression val = Expression.Parameter(typeof(CrmFoSetting), "m");
					crmFoSetting = Queryable.FirstOrDefault<CrmFoSetting>((IQueryable<CrmFoSetting>)crmFoSetting2, Expression.Lambda<Func<CrmFoSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass143_, typeof(_003C_003Ec__DisplayClass143_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				if (crmFoSetting != null)
				{
					crmFoSetting.FoOrdListShowType = _003C_003Ec__DisplayClass143_.model.FoOrdListShowType;
					crmFoSetting.UserId = UserLogin.CurrentUser.UserId;
					crmFoSetting.RegisterDate = now;
					crmFoSetting.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					crmFoSetting.Year1 = short.Parse(Financial.Get().Id.ToString());
					crmFoSetting.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
					crmFoSetting.AppType = Configuration.AppType;
					if (_003C_003Ec__DisplayClass143_.model.FoSettingId > 0)
					{
						_dbTbl.Entry(crmFoSetting).State = EntityState.Modified;
						_dbTbl.SaveChanges();
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmFoSetting");
					}
					else
					{
						text = Messages.ErrorNotFound;
					}
				}
				else
				{
					text = Messages.ErrorNotFound;
				}
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			text = Messages.frmErrorMessage;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			text = Messages.frmErrorMessage;
		}
		base.ViewBag.Error = text;
		return View(_003C_003Ec__DisplayClass143_.model);
	}

	public void SetOnlinePayBankRegisterInfo(CrmOnlinePayBankInfoLanguageViewModel model, ref string firstRegInfo, ref string regInfo)
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
				firstRegInfo = ((!string.IsNullOrEmpty(cRMspSelectUsersById_Result.LName)) ? cRMspSelectUsersById_Result.LName : "") + ((!string.IsNullOrEmpty(cRMspSelectUsersById_Result.FName)) ? (" " + cRMspSelectUsersById_Result.FName) : "");
				_ = model.FirstRegisterDate;
				string text = model.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				firstRegInfo += ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			}
			CRMspSelectUsersById_Result cRMspSelectUsersById_Result2 = CRMIdeal.Classes.Helper.User.SelectUsersById(model.UserId);
			if (cRMspSelectUsersById_Result2 != null)
			{
				regInfo = ((!string.IsNullOrEmpty(cRMspSelectUsersById_Result2.LName)) ? cRMspSelectUsersById_Result2.LName : "") + ((!string.IsNullOrEmpty(cRMspSelectUsersById_Result2.FName)) ? (" " + cRMspSelectUsersById_Result2.FName) : "");
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

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actFoSetting")]
	public ActionResult OnlinePayBankInsertEdit(int onlinePayBankInfoId = 0)
	{
		_003C_003Ec__DisplayClass145_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass145_0();
		CS_0024_003C_003E8__locals0.onlinePayBankInfoId = onlinePayBankInfoId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		CrmOnlinePayBankInfoLanguageViewModel crmOnlinePayBankInfoLanguageViewModel = new CrmOnlinePayBankInfoLanguageViewModel();
		_ = DateTime.Now;
		try
		{
			DbSet<CrmOnlinePayBankInfo_Lang> crmOnlinePayBankInfo_Lang = _dbTbl.CrmOnlinePayBankInfo_Lang;
			ParameterExpression val = Expression.Parameter(typeof(CrmOnlinePayBankInfo_Lang), "x");
			List<CrmOnlinePayBankInfo_Lang> list = Enumerable.ToList<CrmOnlinePayBankInfo_Lang>((IEnumerable<CrmOnlinePayBankInfo_Lang>)Queryable.Where<CrmOnlinePayBankInfo_Lang>((IQueryable<CrmOnlinePayBankInfo_Lang>)crmOnlinePayBankInfo_Lang, Expression.Lambda<Func<CrmOnlinePayBankInfo_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass145_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			if (CS_0024_003C_003E8__locals0.onlinePayBankInfoId > 0)
			{
				DbSet<CrmOnlinePayBankInfo> crmOnlinePayBankInfo = _dbTbl.CrmOnlinePayBankInfo;
				val = Expression.Parameter(typeof(CrmOnlinePayBankInfo), "x");
				CrmOnlinePayBankInfo crmOnlinePayBankInfo2 = Queryable.FirstOrDefault<CrmOnlinePayBankInfo>((IQueryable<CrmOnlinePayBankInfo>)crmOnlinePayBankInfo, Expression.Lambda<Func<CrmOnlinePayBankInfo, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass145_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (crmOnlinePayBankInfo2 != null && crmOnlinePayBankInfo2.OnlinePayBankInfoId > 0)
				{
					List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmOnlinePayBankInfo_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmOnlinePayBankInfo_Lang>)list, (Func<CrmOnlinePayBankInfo_Lang, CommonMultiLanguageViewModel>)((CrmOnlinePayBankInfo_Lang item) => new CommonMultiLanguageViewModel
					{
						Value = item.BankName,
						LanguageId = item.LanguageID
					})));
					list2.Add(new CommonMultiLanguageViewModel
					{
						Value = crmOnlinePayBankInfo2.BankName,
						LanguageId = result
					});
					List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmOnlinePayBankInfo_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmOnlinePayBankInfo_Lang>)list, (Func<CrmOnlinePayBankInfo_Lang, CommonMultiLanguageViewModel>)((CrmOnlinePayBankInfo_Lang item) => new CommonMultiLanguageViewModel
					{
						Value = item.BankAdditionalData,
						LanguageId = item.LanguageID
					})));
					list3.Add(new CommonMultiLanguageViewModel
					{
						Value = crmOnlinePayBankInfo2.BankAdditionalData,
						LanguageId = result
					});
					crmOnlinePayBankInfoLanguageViewModel.OnlinePayBankInfoId = crmOnlinePayBankInfo2.OnlinePayBankInfoId;
					crmOnlinePayBankInfoLanguageViewModel.BankOnlinePayType = crmOnlinePayBankInfo2.BankOnlinePayType;
					crmOnlinePayBankInfoLanguageViewModel.BankName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
					crmOnlinePayBankInfoLanguageViewModel.BankCurrencyRate = crmOnlinePayBankInfo2.BankCurrencyRate;
					crmOnlinePayBankInfoLanguageViewModel.BankLoginAccount = crmOnlinePayBankInfo2.BankLoginAccount;
					crmOnlinePayBankInfoLanguageViewModel.BankAdditionalData = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
					crmOnlinePayBankInfoLanguageViewModel.BankIPGPageUrl = crmOnlinePayBankInfo2.BankIPGPageUrl;
					crmOnlinePayBankInfoLanguageViewModel.BankPGWSaleServiceUrl = crmOnlinePayBankInfo2.BankPGWSaleServiceUrl;
					crmOnlinePayBankInfoLanguageViewModel.BankPGWConfirmServiceUrl = crmOnlinePayBankInfo2.BankPGWConfirmServiceUrl;
					crmOnlinePayBankInfoLanguageViewModel.BankReversalServiceUrl = crmOnlinePayBankInfo2.BankReversalServiceUrl;
					crmOnlinePayBankInfoLanguageViewModel.BankSalePaymentCallback = crmOnlinePayBankInfo2.BankSalePaymentCallback;
					crmOnlinePayBankInfoLanguageViewModel.IsActive = crmOnlinePayBankInfo2.IsActive;
					crmOnlinePayBankInfoLanguageViewModel.IsActiveInShopApp = crmOnlinePayBankInfo2.IsActiveInShopApp;
					crmOnlinePayBankInfoLanguageViewModel.OrderView = crmOnlinePayBankInfo2.OrderView;
					crmOnlinePayBankInfoLanguageViewModel.FirstRegisterUserId = crmOnlinePayBankInfo2.FirstRegisterUserId;
					crmOnlinePayBankInfoLanguageViewModel.FirstRegisterDate = crmOnlinePayBankInfo2.FirstRegisterDate;
					crmOnlinePayBankInfoLanguageViewModel.FirstRegisterDatePersian = crmOnlinePayBankInfo2.FirstRegisterDate.ToString("yyyy/MM/dd");
					crmOnlinePayBankInfoLanguageViewModel.UserId = crmOnlinePayBankInfo2.UserId;
					crmOnlinePayBankInfoLanguageViewModel.RegisterDate = crmOnlinePayBankInfo2.RegisterDate;
					crmOnlinePayBankInfoLanguageViewModel.RegisterDatePersian = crmOnlinePayBankInfo2.RegisterDate.ToString("yyyy/MM/dd");
					crmOnlinePayBankInfoLanguageViewModel.BankName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
					crmOnlinePayBankInfoLanguageViewModel.BankAdditionalData_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
					crmOnlinePayBankInfoLanguageViewModel.BankingBankID = crmOnlinePayBankInfo2.BankingBankID;
					crmOnlinePayBankInfoLanguageViewModel.BankLoginPassword = crmOnlinePayBankInfo2.BankLoginPassword;
					crmOnlinePayBankInfoLanguageViewModel.BankTerminalCode = crmOnlinePayBankInfo2.BankTerminalCode;
					crmOnlinePayBankInfoLanguageViewModel.BankAcceptorCode = crmOnlinePayBankInfo2.BankAcceptorCode;
					crmOnlinePayBankInfoLanguageViewModel.BankSignKey = crmOnlinePayBankInfo2.BankSignKey;
					crmOnlinePayBankInfoLanguageViewModel.BankOrdPayTypeId = crmOnlinePayBankInfo2.BankOrdPayTypeId;
					crmOnlinePayBankInfoLanguageViewModel.BankPordPayTypeId = crmOnlinePayBankInfo2.BankPordPayTypeId;
					string firstRegInfo = "";
					string regInfo = "";
					SetOnlinePayBankRegisterInfo(crmOnlinePayBankInfoLanguageViewModel, ref firstRegInfo, ref regInfo);
					crmOnlinePayBankInfoLanguageViewModel.FirstRegisterUser = firstRegInfo;
					crmOnlinePayBankInfoLanguageViewModel.EditUser = regInfo;
				}
				else
				{
					crmOnlinePayBankInfoLanguageViewModel.AppType = Configuration.AppType;
				}
			}
			else
			{
				crmOnlinePayBankInfoLanguageViewModel.AppType = Configuration.AppType;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		GetOrdPayType();
		return View(crmOnlinePayBankInfoLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actFoSetting")]
	[ValidateAntiForgeryToken]
	public ActionResult OnlinePayBankInsertEdit(CrmOnlinePayBankInfoLanguageViewModel model)
	{
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass146_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass146_0();
		CS_0024_003C_003E8__locals0.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		GetOrdPayType();
		try
		{
			if (base.ModelState.IsValid)
			{
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.BankName_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.BankName_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.BankName,
					LanguageId = lCID
				});
				if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.BankName))
				{
					text = text + string.Format(Messages.ErrorEmpty, Labels.FoSettingBnkName) + "<br/>";
					num++;
				}
				else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.model.BankName, list))
				{
					text = text + string.Format(Messages.CheckFieldInLang, Labels.FoSettingBnkName) + "<br>";
					num++;
				}
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.BankAdditionalData_Lang))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.BankAdditionalData_Lang);
				}
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.BankAdditionalData,
					LanguageId = lCID
				});
				if (num == 0)
				{
					DateTime now = DateTime.Now;
					if (CS_0024_003C_003E8__locals0.model.OnlinePayBankInfoId <= 0)
					{
						CrmOnlinePayBankInfo crmOnlinePayBankInfo = new CrmOnlinePayBankInfo();
						crmOnlinePayBankInfo.BankName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmOnlinePayBankInfo.BankCurrencyRate = CS_0024_003C_003E8__locals0.model.BankCurrencyRate;
						crmOnlinePayBankInfo.BankLoginAccount = CS_0024_003C_003E8__locals0.model.BankLoginAccount;
						crmOnlinePayBankInfo.BankLoginPassword = ((!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.BankLoginPassword)) ? XorCipher.EncryptByPrivateKey(CS_0024_003C_003E8__locals0.model.BankLoginPassword) : null);
						crmOnlinePayBankInfo.BankAdditionalData = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmOnlinePayBankInfo.BankIPGPageUrl = CS_0024_003C_003E8__locals0.model.BankIPGPageUrl;
						crmOnlinePayBankInfo.BankPGWSaleServiceUrl = CS_0024_003C_003E8__locals0.model.BankPGWSaleServiceUrl;
						crmOnlinePayBankInfo.BankPGWConfirmServiceUrl = CS_0024_003C_003E8__locals0.model.BankPGWConfirmServiceUrl;
						crmOnlinePayBankInfo.BankReversalServiceUrl = CS_0024_003C_003E8__locals0.model.BankReversalServiceUrl;
						crmOnlinePayBankInfo.BankSalePaymentCallback = CS_0024_003C_003E8__locals0.model.BankSalePaymentCallback;
						crmOnlinePayBankInfo.IsActive = CS_0024_003C_003E8__locals0.model.IsActive;
						crmOnlinePayBankInfo.IsActiveInShopApp = CS_0024_003C_003E8__locals0.model.IsActiveInShopApp;
						crmOnlinePayBankInfo.OrderView = CS_0024_003C_003E8__locals0.model.OrderView;
						crmOnlinePayBankInfo.BankingBankID = CS_0024_003C_003E8__locals0.model.BankingBankID;
						crmOnlinePayBankInfo.BankTerminalCode = CS_0024_003C_003E8__locals0.model.BankTerminalCode;
						crmOnlinePayBankInfo.BankAcceptorCode = CS_0024_003C_003E8__locals0.model.BankAcceptorCode;
						crmOnlinePayBankInfo.BankSignKey = CS_0024_003C_003E8__locals0.model.BankSignKey;
						crmOnlinePayBankInfo.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
						crmOnlinePayBankInfo.FirstRegisterDate = now;
						crmOnlinePayBankInfo.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						crmOnlinePayBankInfo.UserId = UserLogin.CurrentUser.UserId;
						crmOnlinePayBankInfo.RegisterDate = now;
						crmOnlinePayBankInfo.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						crmOnlinePayBankInfo.Year1 = short.Parse(Financial.Get().Id.ToString());
						crmOnlinePayBankInfo.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
						crmOnlinePayBankInfo.LanguageID = lCID;
						crmOnlinePayBankInfo.AppType = Configuration.AppType;
						crmOnlinePayBankInfo.BankOrdPayTypeId = CS_0024_003C_003E8__locals0.model.BankOrdPayTypeId;
						crmOnlinePayBankInfo.BankPordPayTypeId = CS_0024_003C_003E8__locals0.model.BankPordPayTypeId;
						_dbTbl.CrmOnlinePayBankInfo.Add(crmOnlinePayBankInfo);
						_dbTbl.SaveChanges();
						foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
						{
							CrmOnlinePayBankInfo_Lang entity = new CrmOnlinePayBankInfo_Lang
							{
								BankName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
								BankAdditionalData = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null)
							};
							_dbTbl.CrmOnlinePayBankInfo_Lang.Add(entity);
							_dbTbl.SaveChanges();
						}
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmOnlinePayBankInfo");
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					}
					else
					{
						DbSet<CrmOnlinePayBankInfo> crmOnlinePayBankInfo2 = _dbTbl.CrmOnlinePayBankInfo;
						ParameterExpression val = Expression.Parameter(typeof(CrmOnlinePayBankInfo), "x");
						CrmOnlinePayBankInfo crmOnlinePayBankInfo3 = Queryable.FirstOrDefault<CrmOnlinePayBankInfo>((IQueryable<CrmOnlinePayBankInfo>)crmOnlinePayBankInfo2, Expression.Lambda<Func<CrmOnlinePayBankInfo, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass146_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						crmOnlinePayBankInfo3.BankName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmOnlinePayBankInfo3.BankCurrencyRate = CS_0024_003C_003E8__locals0.model.BankCurrencyRate;
						crmOnlinePayBankInfo3.BankLoginAccount = CS_0024_003C_003E8__locals0.model.BankLoginAccount;
						crmOnlinePayBankInfo3.BankAdditionalData = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmOnlinePayBankInfo3.BankIPGPageUrl = CS_0024_003C_003E8__locals0.model.BankIPGPageUrl;
						crmOnlinePayBankInfo3.BankPGWSaleServiceUrl = CS_0024_003C_003E8__locals0.model.BankPGWSaleServiceUrl;
						crmOnlinePayBankInfo3.BankPGWConfirmServiceUrl = CS_0024_003C_003E8__locals0.model.BankPGWConfirmServiceUrl;
						crmOnlinePayBankInfo3.BankReversalServiceUrl = CS_0024_003C_003E8__locals0.model.BankReversalServiceUrl;
						crmOnlinePayBankInfo3.BankSalePaymentCallback = CS_0024_003C_003E8__locals0.model.BankSalePaymentCallback;
						crmOnlinePayBankInfo3.IsActive = CS_0024_003C_003E8__locals0.model.IsActive;
						crmOnlinePayBankInfo3.IsActiveInShopApp = CS_0024_003C_003E8__locals0.model.IsActiveInShopApp;
						crmOnlinePayBankInfo3.OrderView = CS_0024_003C_003E8__locals0.model.OrderView;
						crmOnlinePayBankInfo3.UserId = UserLogin.CurrentUser.UserId;
						crmOnlinePayBankInfo3.RegisterDate = now;
						crmOnlinePayBankInfo3.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						crmOnlinePayBankInfo3.Year1 = short.Parse(Financial.Get().Id.ToString());
						crmOnlinePayBankInfo3.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
						crmOnlinePayBankInfo3.AppType = Configuration.AppType;
						crmOnlinePayBankInfo3.BankingBankID = CS_0024_003C_003E8__locals0.model.BankingBankID;
						CS_0024_003C_003E8__locals0.model.BankLoginPassword = ((!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.BankLoginPassword)) ? CS_0024_003C_003E8__locals0.model.BankLoginPassword : null);
						string text2 = ((!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.BankLoginPassword)) ? XorCipher.EncryptByPrivateKey(CS_0024_003C_003E8__locals0.model.BankLoginPassword) : null);
						if (!string.IsNullOrEmpty(crmOnlinePayBankInfo3.BankLoginPassword))
						{
							XorCipher.DecryptByPrivateKey(crmOnlinePayBankInfo3.BankLoginPassword);
						}
						bool num2 = text2 == crmOnlinePayBankInfo3.BankLoginPassword;
						bool flag = CS_0024_003C_003E8__locals0.model.BankLoginPassword == crmOnlinePayBankInfo3.BankLoginPassword;
						if (!num2 && !flag)
						{
							crmOnlinePayBankInfo3.BankLoginPassword = text2;
						}
						crmOnlinePayBankInfo3.BankTerminalCode = CS_0024_003C_003E8__locals0.model.BankTerminalCode;
						crmOnlinePayBankInfo3.BankAcceptorCode = CS_0024_003C_003E8__locals0.model.BankAcceptorCode;
						crmOnlinePayBankInfo3.BankSignKey = CS_0024_003C_003E8__locals0.model.BankSignKey;
						crmOnlinePayBankInfo3.BankOrdPayTypeId = CS_0024_003C_003E8__locals0.model.BankOrdPayTypeId;
						crmOnlinePayBankInfo3.BankPordPayTypeId = CS_0024_003C_003E8__locals0.model.BankPordPayTypeId;
						_dbTbl.Entry(crmOnlinePayBankInfo3).State = EntityState.Modified;
						_dbTbl.SaveChanges();
						using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								_003C_003Ec__DisplayClass146_2 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass146_2();
								CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
								CS_0024_003C_003E8__locals2.lang = enumerator.Current;
								DbSet<CrmOnlinePayBankInfo_Lang> crmOnlinePayBankInfo_Lang = _dbTbl.CrmOnlinePayBankInfo_Lang;
								val = Expression.Parameter(typeof(CrmOnlinePayBankInfo_Lang), "c");
								CrmOnlinePayBankInfo_Lang crmOnlinePayBankInfo_Lang2 = Queryable.FirstOrDefault<CrmOnlinePayBankInfo_Lang>((IQueryable<CrmOnlinePayBankInfo_Lang>)crmOnlinePayBankInfo_Lang, Expression.Lambda<Func<CrmOnlinePayBankInfo_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals2, typeof(_003C_003Ec__DisplayClass146_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals2, typeof(_003C_003Ec__DisplayClass146_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (crmOnlinePayBankInfo_Lang2 != null)
								{
									crmOnlinePayBankInfo_Lang2.BankName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
									crmOnlinePayBankInfo_Lang2.BankAdditionalData = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
									_dbTbl.Entry(crmOnlinePayBankInfo_Lang2).State = EntityState.Modified;
									_dbTbl.SaveChanges();
									continue;
								}
								crmOnlinePayBankInfo_Lang2 = new CrmOnlinePayBankInfo_Lang();
								crmOnlinePayBankInfo_Lang2.LanguageID = CS_0024_003C_003E8__locals2.lang.LanguageID;
								crmOnlinePayBankInfo_Lang2.OnlinePayBankInfoId = CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.model.OnlinePayBankInfoId;
								crmOnlinePayBankInfo_Lang2.BankName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								crmOnlinePayBankInfo_Lang2.BankAdditionalData = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								_dbTbl.CrmOnlinePayBankInfo_Lang.Add(crmOnlinePayBankInfo_Lang2);
								_dbTbl.SaveChanges();
							}
						}
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmOnlinePayBankInfo");
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					}
				}
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			text = Messages.frmErrorMessage;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			text = Messages.frmErrorMessage;
		}
		base.ViewBag.Error = text;
		return View(CS_0024_003C_003E8__locals0.model);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actFoSetting")]
	public string DeleteOnlinePayBank(int onlinePayBankInfoId = 0)
	{
		string result = "";
		try
		{
			if (onlinePayBankInfoId != 0)
			{
				mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.CRMspDeleteOnlinePayBankInfo(onlinePayBankInfoId));
				if (mct_I_Result != null && mct_I_Result.Result > 0)
				{
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmOnlinePayBankInfo");
					result = Messages.frmDeleteSuccessMessage;
				}
				else
				{
					result = "-2";
				}
			}
			else
			{
				result = "0";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actFoSetting")]
	public ActionResult EditFoMobSetting()
	{
		_003C_003Ec__DisplayClass148_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass148_0();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		CS_0024_003C_003E8__locals0.cId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId.GetValueOrDefault() : 0);
		CrmFoMobSettingLanguageViewModel crmFoMobSettingLanguageViewModel = new CrmFoMobSettingLanguageViewModel();
		_ = DateTime.Now;
		try
		{
			IEnumerable<CrmFoSetting_Lang> enumerable = Enumerable.Where<CrmFoSetting_Lang>((IEnumerable<CrmFoSetting_Lang>)Enumerable.ToList<CrmFoSetting_Lang>((IEnumerable<CrmFoSetting_Lang>)_dbTbl.CrmFoSetting_Lang), (Func<CrmFoSetting_Lang, bool>)((CrmFoSetting_Lang x) => x.CrmFoSetting.CId == CS_0024_003C_003E8__locals0.cId));
			CrmFoSetting crmFoSetting = new CrmFoSetting();
			DbSet<CrmFoSetting> crmFoSetting2 = _dbTbl.CrmFoSetting;
			ParameterExpression val = Expression.Parameter(typeof(CrmFoSetting), "x");
			crmFoSetting = Queryable.FirstOrDefault<CrmFoSetting>((IQueryable<CrmFoSetting>)crmFoSetting2, Expression.Lambda<Func<CrmFoSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Convert((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass148_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), typeof(int?))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmFoSetting == null)
			{
				crmFoSetting = new CrmFoSetting
				{
					FoSettingId = 0
				};
			}
			List<CommonMultiLanguageViewModel> list = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>(enumerable, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.FoMobLogoTitle,
				LanguageId = item.LanguageID
			})));
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = crmFoSetting.FoMobLogoTitle,
				LanguageId = result
			});
			crmFoMobSettingLanguageViewModel = new CrmFoMobSettingLanguageViewModel
			{
				FoSettingId = crmFoSetting.FoSettingId,
				FoMobLogoTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				FoMobLogoTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				FoMobEntryLogoPath = crmFoSetting.FoMobEntryLogoPath
			};
			if (crmFoMobSettingLanguageViewModel != null && !string.IsNullOrEmpty(crmFoMobSettingLanguageViewModel.FoMobEntryLogoPath))
			{
				string foMobEntryLogoPath = crmFoMobSettingLanguageViewModel.FoMobEntryLogoPath;
				crmFoMobSettingLanguageViewModel.FoMobEntryLogoPath = crmFoMobSettingLanguageViewModel.FoMobEntryLogoPath.Replace(Configuration.MainDirectoryPath, "/");
				crmFoMobSettingLanguageViewModel.FoMobEntryLogoPath = Configuration.HostTempFilesPath + crmFoMobSettingLanguageViewModel.FoMobEntryLogoPath;
				if (!System.IO.File.Exists(base.Server.MapPath(crmFoMobSettingLanguageViewModel.FoMobEntryLogoPath)) && !DownlaodFileFromFTP(foMobEntryLogoPath, crmFoMobSettingLanguageViewModel.FoMobEntryLogoPath))
				{
					crmFoMobSettingLanguageViewModel.FoMobEntryLogoPath = "";
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(crmFoMobSettingLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult EditFoMobSetting(CrmFoMobSettingLanguageViewModel model, HttpPostedFileBase urlUpload)
	{
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass149_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass149_0();
		CS_0024_003C_003E8__locals0.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int? centerId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
		string text = "";
		int num = 0;
		try
		{
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.FoMobLogoTitle_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.FoMobLogoTitle_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.FoMobLogoTitle,
				LanguageId = lCID
			});
			string text2 = "";
			string positionTopRightTxt = Labels.PositionTopRightTxt;
			string positionTopCenterTxt = Labels.PositionTopCenterTxt;
			string positionTopLeftTxt = Labels.PositionTopLeftTxt;
			string positionCenterRightTxt = Labels.PositionCenterRightTxt;
			string positionCenterTxt = Labels.PositionCenterTxt;
			string positionCenterLeftTxt = Labels.PositionCenterLeftTxt;
			string positionBottomRightTxt = Labels.PositionBottomRightTxt;
			string positionBottomCenterTxt = Labels.PositionBottomCenterTxt;
			string positionBottomLeftTxt = Labels.PositionBottomLeftTxt;
			_ = Labels.SmsSendByWebTxt;
			_ = Labels.SmsSendByGsmTxt;
			CRMSpEntities cRMSpEntities = db;
			string foSettingDefDisplay4Column = Labels.FoSettingDefDisplay4Column;
			string foSettingDefDisplay3Column = Labels.FoSettingDefDisplay3Column;
			string foSettingDefDisplayListView = Labels.FoSettingDefDisplayListView;
			string foSettingDefDisplayListViewSmall = Labels.FoSettingDefDisplayListViewSmall;
			int? languageID = CS_0024_003C_003E8__locals0.defLangID;
			int? defaultLanguageID = CS_0024_003C_003E8__locals0.defLangID;
			CRMspSelectFoSetting_Result cRMspSelectFoSetting_Result = Enumerable.FirstOrDefault<CRMspSelectFoSetting_Result>((IEnumerable<CRMspSelectFoSetting_Result>)cRMSpEntities.CRMspSelectFoSetting(foSettingDefDisplay4Column, foSettingDefDisplay3Column, foSettingDefDisplayListView, foSettingDefDisplayListViewSmall, positionTopRightTxt, positionTopCenterTxt, positionTopLeftTxt, positionCenterRightTxt, positionCenterTxt, positionCenterLeftTxt, positionBottomRightTxt, positionBottomCenterTxt, positionBottomLeftTxt, languageID, defaultLanguageID, centerId));
			if (cRMspSelectFoSetting_Result != null)
			{
				text2 = cRMspSelectFoSetting_Result.FoMobEntryLogoPath;
			}
			DateTime now;
			int userId;
			string registerDatePersian;
			short year;
			short month;
			string appType;
			if (base.ModelState.IsValid)
			{
				int customWidth = 150;
				int customHeight = 150;
				string text3 = "Logo/";
				if (num == 0)
				{
					now = DateTime.Now;
					userId = UserLogin.CurrentUser.UserId;
					registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					year = short.Parse(Financial.Get().Id.ToString());
					month = short.Parse(now.ToString("MM", new PersianCulture()));
					appType = Configuration.AppType;
					int num2 = 500;
					if (urlUpload == null)
					{
						goto IL_06c1;
					}
					string text4 = urlUpload.ContentType.ToLower();
					string text5 = Path.GetExtension(urlUpload.FileName).ToLower();
					if ((text4 != "image/jpg" && text4 != "image/jpeg" && text4 != "image/pjpeg" && text4 != "image/gif" && text4 != "image/x-png" && text4 != "image/png") || (text5 != ".jpg" && text5 != ".png" && text5 != ".gif" && text5 != ".jpeg"))
					{
						text = Messages.frmErrorNotImageFile;
						base.ViewBag.Error = text;
						base.ModelState.AddModelError("error", text);
						return View(CS_0024_003C_003E8__locals0.model);
					}
					if (urlUpload.ContentLength / 1024 > num2)
					{
						text = string.Format(Messages.frmErrorMaxImageSizeForUpload, num2);
						base.ViewBag.Error = text;
						base.ModelState.AddModelError("error", text);
						return View(CS_0024_003C_003E8__locals0.model);
					}
					FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
					string pathFtp = Configuration.PathFtp;
					string userNameFtp = Configuration.UserNameFtp;
					string passwordFtp = Configuration.PasswordFtp;
					bool usePassiveFtp = Configuration.UsePassiveFtp;
					string fileName = Path.GetFileName(urlUpload.FileName);
					string text6 = Configuration.MainDirectoryPath + Configuration.FoSettingDirectoryPath;
					string text7 = text6 + (text6.EndsWith("/") ? "" : "/");
					bool flag = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, Configuration.MainDirectoryPath, Configuration.FoSettingDirectoryPath, usePassiveFtp);
					if (!flag)
					{
						flag = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, Configuration.MainDirectoryPath, Configuration.FoSettingDirectoryPath, usePassiveFtp);
					}
					bool flag2 = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text7, text3, usePassiveFtp);
					if (!flag2)
					{
						flag2 = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text7, text3, usePassiveFtp);
					}
					if (!(flag && flag2))
					{
						goto IL_06c1;
					}
					text7 += text3;
					string text8 = text7;
					text8 = text8.Replace(Configuration.MainDirectoryPath, "/");
					text8 = Configuration.HostTempFilesPath + text8;
					text8 = base.Server.MapPath(text8);
					if (!System.IO.Directory.Exists(text8))
					{
						System.IO.Directory.CreateDirectory(text8);
						CRM.General.IO.Directory.SetFullControlForEveryOne(text8);
					}
					if (System.IO.Directory.Exists(text8))
					{
						string text9 = text8 + "Initial-" + fileName;
						text8 += fileName;
						if (System.IO.File.Exists(text8))
						{
							System.IO.File.Delete(text8);
						}
						urlUpload.SaveAs(text9);
						if (System.IO.File.Exists(text9))
						{
							ImageManager.CompressFile(new ImageManager.ImageParam
							{
								FilePath = text9,
								DestPath = text8,
								CustomHeight = customHeight,
								CustomWidth = customWidth
							});
							ImageManager.DeleteFile(new ImageManager.ImageParam
							{
								FilePath = text9
							});
						}
					}
					if (!System.IO.File.Exists(text8))
					{
						goto IL_06c1;
					}
					text7 += fileName;
					if (facadeFTP.UploadFtpFormTable(pathFtp, userNameFtp, passwordFtp, text7, text8, usePassiveFtp))
					{
						CS_0024_003C_003E8__locals0.model.FoMobEntryLogoPath = text7;
						goto IL_06c1;
					}
					CS_0024_003C_003E8__locals0.model.FoMobEntryLogoPath = null;
					Exception e = new Exception(Messages.msgErrorUploadingFileInFtp + "  -  hostname: " + pathFtp + " ,username: " + userNameFtp + " ,destination: " + text7);
					ErrorSignal.FromCurrentContext().Raise(e);
					base.ModelState.AddModelError("error", Messages.frmErrorInSendingFile);
					base.ViewBag.Error = Messages.frmErrorInSendingFile;
				}
			}
			else
			{
				text = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
			goto end_IL_007d;
			IL_06c1:
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.FoMobEntryLogoPath) && CS_0024_003C_003E8__locals0.model.FoMobEntryLogoPath.IndexOf(Configuration.HostTempFilesPath, StringComparison.Ordinal) >= 0)
			{
				CS_0024_003C_003E8__locals0.model.FoMobEntryLogoPath = CS_0024_003C_003E8__locals0.model.FoMobEntryLogoPath.Replace(Configuration.HostTempFilesPath + "/", "");
				CS_0024_003C_003E8__locals0.model.FoMobEntryLogoPath = Configuration.MainDirectoryPath + CS_0024_003C_003E8__locals0.model.FoMobEntryLogoPath;
			}
			if (!string.IsNullOrWhiteSpace(text2) && (text2 ?? "").ToLower() != (CS_0024_003C_003E8__locals0.model.FoMobEntryLogoPath ?? "").ToLower())
			{
				DeleteOldFileFromFtp(text2);
			}
			DbSet<CrmFoSetting> crmFoSetting = _dbTbl.CrmFoSetting;
			ParameterExpression val = Expression.Parameter(typeof(CrmFoSetting), "m");
			CrmFoSetting crmFoSetting2 = Queryable.FirstOrDefault<CrmFoSetting>((IQueryable<CrmFoSetting>)crmFoSetting, Expression.Lambda<Func<CrmFoSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass149_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmFoSetting2 != null)
			{
				crmFoSetting2.FoMobLogoTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				crmFoSetting2.FoMobEntryLogoPath = CS_0024_003C_003E8__locals0.model.FoMobEntryLogoPath;
				crmFoSetting2.UserId = userId;
				crmFoSetting2.RegisterDate = now;
				crmFoSetting2.RegisterDatePersian = registerDatePersian;
				crmFoSetting2.Year1 = year;
				crmFoSetting2.Month1 = month;
				crmFoSetting2.AppType = appType;
				_dbTbl.Entry(crmFoSetting2).State = EntityState.Modified;
				_dbTbl.SaveChanges();
				using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass149_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass149_1();
						CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
						CS_0024_003C_003E8__locals1.lang = enumerator.Current;
						DbSet<CrmFoSetting_Lang> crmFoSetting_Lang = _dbTbl.CrmFoSetting_Lang;
						val = Expression.Parameter(typeof(CrmFoSetting_Lang), "c");
						CrmFoSetting_Lang crmFoSetting_Lang2 = Queryable.FirstOrDefault<CrmFoSetting_Lang>((IQueryable<CrmFoSetting_Lang>)crmFoSetting_Lang, Expression.Lambda<Func<CrmFoSetting_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass149_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Convert((Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass149_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), typeof(int?)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						if (crmFoSetting_Lang2 != null)
						{
							crmFoSetting_Lang2.FoMobLogoTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							_dbTbl.Entry(crmFoSetting_Lang2).State = EntityState.Modified;
							_dbTbl.SaveChanges();
							continue;
						}
						crmFoSetting_Lang2 = new CrmFoSetting_Lang
						{
							FoMobLogoTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
						};
						_dbTbl.CrmFoSetting_Lang.Add(crmFoSetting_Lang2);
						_dbTbl.SaveChanges();
					}
				}
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmFoSetting");
			}
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.FoMobEntryLogoPath))
			{
				CS_0024_003C_003E8__locals0.model.FoMobEntryLogoPath = CS_0024_003C_003E8__locals0.model.FoMobEntryLogoPath.Replace(Configuration.MainDirectoryPath, "/");
				CS_0024_003C_003E8__locals0.model.FoMobEntryLogoPath = Configuration.HostTempFilesPath + CS_0024_003C_003E8__locals0.model.FoMobEntryLogoPath;
			}
			base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
			end_IL_007d:;
		}
		catch (DbEntityValidationException e2)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e2);
			text = Messages.frmErrorMessage;
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
			text = Messages.frmErrorMessage;
		}
		base.ViewBag.Error = text;
		return View(CS_0024_003C_003E8__locals0.model);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetTicketAlarmSetting()
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
			List<CRMspSelectTicketAlarmSetting_Result> list = Enumerable.ToList<CRMspSelectTicketAlarmSetting_Result>((IEnumerable<CRMspSelectTicketAlarmSetting_Result>)_dbII.CRMspSelectTicketAlarmSetting(lCID, result2));
			if (list != null)
			{
				foreach (CRMspSelectTicketAlarmSetting_Result item in list)
				{
					item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm");
					item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd HH:mm");
				}
				result = JsonConvert.SerializeObject(list);
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	public void DeleteOldFileFromFtp(string filePath)
	{
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			new FilesManager();
			string pathFtp = Configuration.PathFtp;
			string userNameFtp = Configuration.UserNameFtp;
			string passwordFtp = Configuration.PasswordFtp;
			bool usePassiveFtp = Configuration.UsePassiveFtp;
			bool flag = !string.IsNullOrEmpty(pathFtp) && !string.IsNullOrEmpty(userNameFtp) && !string.IsNullOrEmpty(passwordFtp);
			string pathFtpFo = Configuration.PathFtpFo;
			string userNameFtpFo = Configuration.UserNameFtpFo;
			string passwordFtpFo = Configuration.PasswordFtpFo;
			bool usePassiveFtpFo = Configuration.UsePassiveFtpFo;
			bool flag2 = !string.IsNullOrEmpty(pathFtpFo) && !string.IsNullOrEmpty(userNameFtpFo) && !string.IsNullOrEmpty(passwordFtpFo);
			string text = "";
			string[] array = filePath.Split(new char[1] { '/' });
			if (array != null && array.Length != 0)
			{
				text = array[^1];
			}
			if (string.IsNullOrWhiteSpace(filePath) || string.IsNullOrWhiteSpace(text))
			{
				return;
			}
			if (flag)
			{
				FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
				string destination = filePath.ToLower();
				facadeFTP.Delete(pathFtp, userNameFtp, passwordFtp, text, destination, usePassiveFtp);
				string text2 = filePath.ToLower().Replace(pathFtp.ToLower(), "");
				text2 = text2.Replace(Configuration.MainDirectoryPath.ToLower(), "/");
				text2 = Configuration.HostTempFilesPath + text2;
				text2 = base.Server.MapPath(text2);
				if (System.IO.File.Exists(text2))
				{
					System.IO.File.Delete(text2);
				}
			}
			if (flag2)
			{
				FacadeFTP facadeFTP2 = new FacadeFTP(Configuration.FacadeFtpFo);
				string text3 = filePath.ToLower().Replace(pathFtp.ToLower(), "");
				text3 = string.Concat(str1: text3.Replace(Configuration.MainDirectoryPath.ToLower(), "/"), str0: Configuration.HostTempFilesPath);
				text3 = text3.Replace("~", "").ToLower();
				facadeFTP2.Delete(pathFtpFo, userNameFtpFo, passwordFtpFo, text, text3, usePassiveFtpFo);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	[AjaxOnly]
	public JsonResult SearchProducts(int fgId = 0, int sgId = 0, string barcode = "", string val = "")
	{
		List<WSspSearchProductsWeb_Result> list = new List<WSspSearchProductsWeb_Result>();
		try
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
			list = Enumerable.ToList<WSspSearchProductsWeb_Result>((IEnumerable<WSspSearchProductsWeb_Result>)_dbI.WSspSearchProductsWeb(fgId, sgId, barcode, val, 0, 0, lCID, result, 0, -1, null, null, result2, UserLogin.CurrentUser.UserId));
			if (list == null)
			{
				list = new List<WSspSearchProductsWeb_Result>();
			}
			else if (Enumerable.Any<WSspSearchProductsWeb_Result>((IEnumerable<WSspSearchProductsWeb_Result>)list))
			{
				foreach (WSspSearchProductsWeb_Result item in list)
				{
					item.PrdLinkAccPrdCode = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccCodeWithComa(2, item.PrdLinkAccPrdCode);
					item.PrdLinkAccPrdIdStr = item.PName + "|" + item.PrdCode + "|" + item.PrdModel + "|" + item.PrdLatinName + "|" + item.PrdBarcode + "|" + item.PrdFirstBarcode + "|" + item.PrdLinkAccPrdCode + "|";
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actFoSetting")]
	public ActionResult SeoInsertEdit(int mode = 0, int id = 0)
	{
		_003C_003Ec__DisplayClass154_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass154_0();
		CS_0024_003C_003E8__locals0.id = id;
		CrmFoSettingSeoLanguageViewModel crmFoSettingSeoLanguageViewModel = new CrmFoSettingSeoLanguageViewModel();
		crmFoSettingSeoLanguageViewModel.Mode = mode;
		_ = UserLogin.CurrentUser.UserId;
		DateTime now = DateTime.Now;
		now.ToString("yyyyMMdd", new PersianCulture());
		short.Parse(Financial.Get().Id.ToString());
		short.Parse(now.ToString("MM", new PersianCulture()));
		_ = Configuration.AppType;
		if (UserLogin.CurrentUser != null)
		{
			_ = UserLogin.CurrentUser.UserLastCId;
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			if (CS_0024_003C_003E8__locals0.id != 0)
			{
				crmFoSettingSeoLanguageViewModel.ID = CS_0024_003C_003E8__locals0.id;
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
				List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
				List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
				List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
				if (mode == 0)
				{
					DbSet<CrmFoSetting> crmFoSetting = _dbTbl.CrmFoSetting;
					ParameterExpression val = Expression.Parameter(typeof(CrmFoSetting), "x");
					CrmFoSetting crmFoSetting2 = Queryable.FirstOrDefault<CrmFoSetting>((IQueryable<CrmFoSetting>)crmFoSetting, Expression.Lambda<Func<CrmFoSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass154_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					if (crmFoSetting2 != null)
					{
						crmFoSettingSeoLanguageViewModel.InModeSeoIsActive = crmFoSetting2.ShpSeoIsActive;
						crmFoSettingSeoLanguageViewModel.SeoIsActive = crmFoSetting2.ShpHomeSeoIsActive;
						crmFoSettingSeoLanguageViewModel.SeoTitle = crmFoSetting2.ShpHomeSeoTitle;
						crmFoSettingSeoLanguageViewModel.SeoDescription = crmFoSetting2.ShpHomeSeoDescription;
						crmFoSettingSeoLanguageViewModel.SeoHttpEquiv = crmFoSetting2.ShpHomeSeoHttpEquiv;
						crmFoSettingSeoLanguageViewModel.SeoExpires = crmFoSetting2.ShpHomeSeoExpires;
						crmFoSettingSeoLanguageViewModel.SeoGoogleNotranslate = crmFoSetting2.ShpHomeSeoGoogleNotranslate;
						crmFoSettingSeoLanguageViewModel.SeoDistribution = crmFoSetting2.ShpHomeSeoDistribution;
						crmFoSettingSeoLanguageViewModel.SeoRobots = crmFoSetting2.ShpHomeSeoRobots;
						crmFoSettingSeoLanguageViewModel.SeoRating = crmFoSetting2.ShpHomeSeoRating;
						crmFoSettingSeoLanguageViewModel.SeoAuthor = crmFoSetting2.ShpHomeSeoAuthor;
						crmFoSettingSeoLanguageViewModel.SeoIsUseSocialNetwork = crmFoSetting2.ShpHomeSeoIsUseSocialNetwork;
						crmFoSettingSeoLanguageViewModel.SeoMobileOptimized = crmFoSetting2.ShpHomeSeoMobileOptimized;
						crmFoSettingSeoLanguageViewModel.SeoCopyright = crmFoSetting2.ShpHomeSeoCopyright;
						crmFoSettingSeoLanguageViewModel.SeoUseDefault = crmFoSetting2.ShpHomeSeoUseDefault;
						crmFoSettingSeoLanguageViewModel.SeoKeywords = crmFoSetting2.ShpHomeSeoKeywords;
						crmFoSettingSeoLanguageViewModel.SeoFAQ = crmFoSetting2.ShpHomeSeoFAQ;
						crmFoSettingSeoLanguageViewModel.SeoGoogleAnalytics = HttpUtility.UrlDecode(crmFoSetting2.ShpSeoGoogleAnalytics);
						DbSet<CrmFoSetting_Lang> crmFoSetting_Lang = _dbTbl.CrmFoSetting_Lang;
						val = Expression.Parameter(typeof(CrmFoSetting_Lang), "x");
						List<CrmFoSetting_Lang> list7 = Enumerable.ToList<CrmFoSetting_Lang>((IEnumerable<CrmFoSetting_Lang>)Queryable.Where<CrmFoSetting_Lang>((IQueryable<CrmFoSetting_Lang>)crmFoSetting_Lang, Expression.Lambda<Func<CrmFoSetting_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Convert((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass154_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), typeof(int?))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
						if (list7 != null)
						{
							list = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmFoSetting_Lang>)list7, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
							{
								Value = item.ShpHomeSeoTitle,
								LanguageId = item.LanguageID
							})));
							list.Add(new CommonMultiLanguageViewModel
							{
								Value = crmFoSetting2.ShpHomeSeoTitle,
								LanguageId = result
							});
							list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmFoSetting_Lang>)list7, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
							{
								Value = item.ShpHomeSeoDescription,
								LanguageId = item.LanguageID
							})));
							list2.Add(new CommonMultiLanguageViewModel
							{
								Value = crmFoSetting2.ShpHomeSeoDescription,
								LanguageId = result
							});
							list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmFoSetting_Lang>)list7, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
							{
								Value = item.ShpHomeSeoAuthor,
								LanguageId = item.LanguageID
							})));
							list3.Add(new CommonMultiLanguageViewModel
							{
								Value = crmFoSetting2.ShpHomeSeoAuthor,
								LanguageId = result
							});
							list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmFoSetting_Lang>)list7, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
							{
								Value = item.ShpHomeSeoCopyright,
								LanguageId = item.LanguageID
							})));
							list4.Add(new CommonMultiLanguageViewModel
							{
								Value = crmFoSetting2.ShpHomeSeoCopyright,
								LanguageId = result
							});
							list5 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmFoSetting_Lang>)list7, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
							{
								Value = item.ShpHomeSeoKeywords,
								LanguageId = item.LanguageID
							})));
							list5.Add(new CommonMultiLanguageViewModel
							{
								Value = crmFoSetting2.ShpHomeSeoKeywords,
								LanguageId = result
							});
							list6 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFoSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmFoSetting_Lang>)list7, (Func<CrmFoSetting_Lang, CommonMultiLanguageViewModel>)((CrmFoSetting_Lang item) => new CommonMultiLanguageViewModel
							{
								Value = item.ShpHomeSeoFAQ,
								LanguageId = item.LanguageID
							})));
							list6.Add(new CommonMultiLanguageViewModel
							{
								Value = crmFoSetting2.ShpHomeSeoFAQ,
								LanguageId = result
							});
						}
					}
				}
				if (list.Count > 0)
				{
					crmFoSettingSeoLanguageViewModel.SeoTitle = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel x) => x.LanguageId == CS_0024_003C_003E8__locals0.currLangID))?.Value;
					crmFoSettingSeoLanguageViewModel.SeoTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel x) => x.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
				}
				if (list2.Count > 0)
				{
					crmFoSettingSeoLanguageViewModel.SeoDescription = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel x) => x.LanguageId == CS_0024_003C_003E8__locals0.currLangID))?.Value;
					crmFoSettingSeoLanguageViewModel.SeoDescription_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel x) => x.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
				}
				if (list3.Count > 0)
				{
					crmFoSettingSeoLanguageViewModel.SeoAuthor = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel x) => x.LanguageId == CS_0024_003C_003E8__locals0.currLangID))?.Value;
					crmFoSettingSeoLanguageViewModel.SeoAuthor_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel x) => x.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
				}
				if (list4.Count > 0)
				{
					crmFoSettingSeoLanguageViewModel.SeoCopyright = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel x) => x.LanguageId == CS_0024_003C_003E8__locals0.currLangID))?.Value;
					crmFoSettingSeoLanguageViewModel.SeoCopyright_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel x) => x.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
				}
				if (list5.Count > 0)
				{
					crmFoSettingSeoLanguageViewModel.SeoKeywords = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel x) => x.LanguageId == CS_0024_003C_003E8__locals0.currLangID))?.Value;
					crmFoSettingSeoLanguageViewModel.SeoKeywords_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel x) => x.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
				}
				if (list6.Count > 0)
				{
					crmFoSettingSeoLanguageViewModel.SeoFAQ = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel x) => x.LanguageId == CS_0024_003C_003E8__locals0.currLangID))?.Value;
					crmFoSettingSeoLanguageViewModel.SeoFAQ_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel x) => x.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return View(crmFoSettingSeoLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	public string SeoInsertEdit(CrmFoSettingSeoLanguageViewModel model)
	{
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_0287: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass155_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass155_0();
		CS_0024_003C_003E8__locals0.model = model;
		_ = UserLogin.CurrentUser.UserId;
		DateTime now = DateTime.Now;
		now.ToString("yyyyMMdd", new PersianCulture());
		short.Parse(Financial.Get().Id.ToString());
		short.Parse(now.ToString("MM", new PersianCulture()));
		_ = Configuration.AppType;
		if (UserLogin.CurrentUser != null)
		{
			_ = UserLogin.CurrentUser.UserLastCId;
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		try
		{
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.SeoTitle_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.SeoTitle_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.SeoTitle,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.SeoDescription_Lang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.SeoDescription_Lang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.SeoDescription,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.SeoAuthor_Lang))
			{
				list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.SeoAuthor_Lang);
			}
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.SeoAuthor,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.SeoCopyright_Lang))
			{
				list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.SeoCopyright_Lang);
			}
			list4.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.SeoCopyright,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.SeoKeywords_Lang))
			{
				list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.SeoKeywords_Lang);
			}
			list5.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.SeoKeywords,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.SeoFAQ_Lang))
			{
				list6 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.SeoFAQ_Lang);
			}
			list6.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.SeoFAQ,
				LanguageId = lCID
			});
			if (CS_0024_003C_003E8__locals0.model.Mode == 0 && CS_0024_003C_003E8__locals0.model.ID == 0)
			{
				num++;
				text += Messages.msgErrorNotSelectedItem;
			}
			if (num == 0 && CS_0024_003C_003E8__locals0.model.Mode == 0)
			{
				DbSet<CrmFoSetting> crmFoSetting = _dbTbl.CrmFoSetting;
				ParameterExpression val = Expression.Parameter(typeof(CrmFoSetting), "m");
				CrmFoSetting crmFoSetting2 = Queryable.FirstOrDefault<CrmFoSetting>((IQueryable<CrmFoSetting>)crmFoSetting, Expression.Lambda<Func<CrmFoSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass155_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (crmFoSetting2 != null)
				{
					crmFoSetting2.ShpSeoIsActive = CS_0024_003C_003E8__locals0.model.InModeSeoIsActive;
					crmFoSetting2.ShpHomeSeoIsActive = CS_0024_003C_003E8__locals0.model.SeoIsActive;
					crmFoSetting2.ShpHomeSeoTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					crmFoSetting2.ShpHomeSeoDescription = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					crmFoSetting2.ShpHomeSeoHttpEquiv = CS_0024_003C_003E8__locals0.model.SeoHttpEquiv;
					crmFoSetting2.ShpHomeSeoExpires = CS_0024_003C_003E8__locals0.model.SeoExpires;
					crmFoSetting2.ShpHomeSeoGoogleNotranslate = CS_0024_003C_003E8__locals0.model.SeoGoogleNotranslate;
					crmFoSetting2.ShpHomeSeoDistribution = CS_0024_003C_003E8__locals0.model.SeoDistribution;
					crmFoSetting2.ShpHomeSeoRobots = CS_0024_003C_003E8__locals0.model.SeoRobots;
					crmFoSetting2.ShpHomeSeoRating = CS_0024_003C_003E8__locals0.model.SeoRating;
					crmFoSetting2.ShpHomeSeoAuthor = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					crmFoSetting2.ShpHomeSeoIsUseSocialNetwork = CS_0024_003C_003E8__locals0.model.SeoIsUseSocialNetwork;
					crmFoSetting2.ShpHomeSeoMobileOptimized = CS_0024_003C_003E8__locals0.model.SeoMobileOptimized;
					crmFoSetting2.ShpHomeSeoCopyright = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					crmFoSetting2.ShpHomeSeoUseDefault = CS_0024_003C_003E8__locals0.model.SeoUseDefault;
					crmFoSetting2.ShpHomeSeoKeywords = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					crmFoSetting2.ShpHomeSeoFAQ = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					crmFoSetting2.ShpSeoGoogleAnalytics = CS_0024_003C_003E8__locals0.model.SeoGoogleAnalytics;
					if (CS_0024_003C_003E8__locals0.model.ID > 0)
					{
						_dbTbl.Entry(crmFoSetting2).State = EntityState.Modified;
						_dbTbl.SaveChanges();
						using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								_003C_003Ec__DisplayClass155_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass155_1();
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
								CS_0024_003C_003E8__locals1.lang = enumerator.Current;
								DbSet<CrmFoSetting_Lang> crmFoSetting_Lang = _dbTbl.CrmFoSetting_Lang;
								val = Expression.Parameter(typeof(CrmFoSetting_Lang), "c");
								CrmFoSetting_Lang crmFoSetting_Lang2 = Queryable.FirstOrDefault<CrmFoSetting_Lang>((IQueryable<CrmFoSetting_Lang>)crmFoSetting_Lang, Expression.Lambda<Func<CrmFoSetting_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass155_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Convert((Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass155_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), typeof(int?)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (crmFoSetting_Lang2 != null)
								{
									crmFoSetting_Lang2.ShpHomeSeoTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									crmFoSetting_Lang2.ShpHomeSeoDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									crmFoSetting_Lang2.ShpHomeSeoAuthor = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									crmFoSetting_Lang2.ShpHomeSeoCopyright = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									crmFoSetting_Lang2.ShpHomeSeoKeywords = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									crmFoSetting_Lang2.ShpHomeSeoFAQ = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									_dbTbl.Entry(crmFoSetting_Lang2).State = EntityState.Modified;
									_dbTbl.SaveChanges();
									continue;
								}
								crmFoSetting_Lang2 = new CrmFoSetting_Lang
								{
									ShpHomeSeoTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
									ShpHomeSeoDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
									ShpHomeSeoAuthor = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
									ShpHomeSeoCopyright = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
									ShpHomeSeoKeywords = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
									ShpHomeSeoFAQ = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
									LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
									FoSettingId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.ID
								};
								_dbTbl.CrmFoSetting_Lang.Add(crmFoSetting_Lang2);
								_dbTbl.SaveChanges();
							}
						}
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					}
					else
					{
						crmFoSetting2.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
						crmFoSetting2.FirstRegisterDate = now;
						crmFoSetting2.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						crmFoSetting2.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
						crmFoSetting2.GUId = Guid.NewGuid();
						_dbTbl.CrmFoSetting.Add(crmFoSetting2);
						_dbTbl.SaveChanges();
						if (crmFoSetting2.FoSettingId > 0)
						{
							foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
							{
								CrmFoSetting_Lang entity = new CrmFoSetting_Lang
								{
									ShpHomeSeoTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
									ShpHomeSeoDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
									ShpHomeSeoAuthor = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
									ShpHomeSeoCopyright = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
									ShpHomeSeoKeywords = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
									ShpHomeSeoFAQ = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
									LanguageID = lang.LanguageID,
									FoSettingId = crmFoSetting2.FoSettingId
								};
								_dbTbl.CrmFoSetting_Lang.Add(entity);
								_dbTbl.SaveChanges();
							}
						}
						base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
					}
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			text = text + Messages.MsgErrorDoneOperation + "<br />";
		}
		return text;
	}

	protected override void Dispose(bool disposing)
	{
		db.Dispose();
		_dbTbl.Dispose();
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}

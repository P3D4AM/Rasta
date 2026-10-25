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
using CRM.General.Utilities;
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

namespace CRMIdeal.Areas.Company.Controllers;

public class InsertQuickCompanyController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass29_0
	{
		public CRMspSelectCompanyByCmpAndUserId_Result cmp;

		public int currLangID;

		internal bool _003CLoadInfo_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CLoadInfo_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CLoadInfo_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CLoadInfo_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CLoadInfo_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CLoadInfo_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CLoadInfo_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CLoadInfo_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CLoadInfo_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CLoadInfo_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CLoadInfo_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CLoadInfo_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CLoadInfo_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CLoadInfo_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CLoadInfo_003Eb__24(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CLoadInfo_003Eb__25(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CLoadInfo_003Eb__26(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CLoadInfo_003Eb__27(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CLoadInfo_003Eb__28(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CLoadInfo_003Eb__29(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CLoadInfo_003Eb__30(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CLoadInfo_003Eb__34(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CLoadInfo_003Eb__35(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CLoadInfo_003Eb__36(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CLoadInfo_003Eb__37(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CLoadInfo_003Eb__38(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CLoadInfo_003Eb__39(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass29_1
	{
		public CRMspSelectCompanyPersonByCmpOrPrsId_Result prs;

		public CRMspSelectCompanyProjectByCmpOrPrjId_Result prj;

		public CRMspSelectConversationByCmpOrCnvsId_Result cnvs;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass38_0
	{
		public CrmCmpPrsPrjCnvsLanguageViewModel model;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__35;

		public Func<CRMspSelectCompanyTitle_Result, bool> _003C_003E9__55;

		public Func<CRMspSelectPersonTitle_Result, bool> _003C_003E9__56;

		public Func<Languages, bool> _003C_003E9__57;

		public Func<Languages, bool> _003C_003E9__73;

		public Func<Languages, bool> _003C_003E9__87;

		public Func<Languages, bool> _003C_003E9__107;

		internal bool _003CActPost_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CActPost_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CActPost_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CActPost_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CActPost_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CActPost_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CActPost_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CActPost_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CActPost_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CActPost_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CActPost_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CActPost_003Eb__24(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CActPost_003Eb__25(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CActPost_003Eb__26(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CActPost_003Eb__27(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CActPost_003Eb__28(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CActPost_003Eb__29(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CActPost_003Eb__30(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CActPost_003Eb__31(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CActPost_003Eb__32(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CActPost_003Eb__33(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CActPost_003Eb__34(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CActPost_003Eb__35(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CActPost_003Eb__55(CRMspSelectCompanyTitle_Result m)
		{
			return m.CompanyTitleID == model.CmpTitleId;
		}

		internal bool _003CActPost_003Eb__56(CRMspSelectPersonTitle_Result m)
		{
			return m.PersonTitleID == model.PrsTitleId;
		}

		internal bool _003CActPost_003Eb__57(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CActPost_003Eb__73(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CActPost_003Eb__87(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CActPost_003Eb__107(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass38_1
	{
		public int setId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass38_3
	{
		public int prsId;

		public int cmpId;

		public int prjId;

		public int cnvsId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass38_4
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass38_3 CS_0024_003C_003E8__locals1;

		internal bool _003CActPost_003Eb__37(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__38(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__39(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__40(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__41(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__42(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__43(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__44(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__45(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__46(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__47(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__48(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass38_6
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass38_3 CS_0024_003C_003E8__locals2;

		internal bool _003CActPost_003Eb__59(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__60(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__61(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__62(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__63(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__64(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__65(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__66(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__67(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__68(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__69(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__70(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__71(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__72(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass38_7
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass38_3 CS_0024_003C_003E8__locals3;

		internal bool _003CActPost_003Eb__75(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__76(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__77(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__78(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__79(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__80(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__81(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__82(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__83(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__84(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__85(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__86(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass38_8
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass38_3 CS_0024_003C_003E8__locals4;

		internal bool _003CActPost_003Eb__89(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__90(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__91(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__92(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__93(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__94(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__95(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__96(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__97(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__98(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__99(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__100(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__101(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__102(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__103(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__104(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__105(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__106(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass38_9
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass38_3 CS_0024_003C_003E8__locals5;

		internal bool _003CActPost_003Eb__109(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__110(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__111(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__112(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__113(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__114(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__115(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPost_003Eb__116(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass40_1
	{
		public int setId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass40_2
	{
		public int prjId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass40_3
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass40_2 CS_0024_003C_003E8__locals1;

		internal bool _003CActPrjEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPrjEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPrjEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPrjEdit_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPrjEdit_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPrjEdit_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPrjEdit_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPrjEdit_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPrjEdit_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPrjEdit_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPrjEdit_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CActPrjEdit_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass41_0
	{
		public int setId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass42_0
	{
		public int setId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass44_0
	{
		public int defSettingId;

		public int currLangID;

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__24(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__25(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__26(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__27(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__28(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__29(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__30(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__31(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__32(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__33(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__34(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__35(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__36(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__37(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__38(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__39(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__40(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__41(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__42(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__43(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__44(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__45(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__46(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__47(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__48(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__49(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__50(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__51(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__52(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__53(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__54(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__55(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__56(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__57(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public int setId;
	}

	private CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private CRMSpIEntities _dbI = new CRMSpIEntities();

	private CRMSpIIIEntities _dbIII = new CRMSpIIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actQuickRegisterCompany")]
	public ActionResult Index()
	{
		int num = 0;
		string text = "";
		int num2 = 0;
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		try
		{
			_003C_003Ec__DisplayClass4_0 _003C_003Ec__DisplayClass4_ = new _003C_003Ec__DisplayClass4_0();
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			_003C_003Ec__DisplayClass4_.setId = 0;
			int.TryParse(SysSeting.Get().ID.ToString(), out _003C_003Ec__DisplayClass4_.setId);
			DbSet<CrmsysSetting> crmsysSetting = _dbTbl.CrmsysSetting;
			ParameterExpression val = Expression.Parameter(typeof(CrmsysSetting), "m");
			CrmsysSetting crmsysSetting2 = Queryable.FirstOrDefault<CrmsysSetting>((IQueryable<CrmsysSetting>)crmsysSetting, Expression.Lambda<Func<CrmsysSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass4_, typeof(_003C_003Ec__DisplayClass4_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmsysSetting2 != null)
			{
				flag = ((crmsysSetting2.cmpQNotNullProjectGroup.HasValue && crmsysSetting2.cmpQNotNullProjectGroup != false) ? true : false);
				flag2 = ((crmsysSetting2.cmpQNotNullProjectGrade.HasValue && crmsysSetting2.cmpQNotNullProjectGrade != false) ? true : false);
				flag3 = ((crmsysSetting2.cmpQNotNullProjectPriority.HasValue && crmsysSetting2.cmpQNotNullProjectPriority != false) ? true : false);
				flag4 = ((crmsysSetting2.cmpQDefPrintAfterSave.HasValue && crmsysSetting2.cmpQDefPrintAfterSave != false) ? true : false);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CmpQDefCountryId = num;
		base.ViewBag.CmpQNotNullProjectGroup = flag;
		base.ViewBag.CmpQNotNullProjectGrade = flag2;
		base.ViewBag.CmpQNotNullProjectPriority = flag3;
		base.ViewBag.CmpQDefProjectTitle = text;
		base.ViewBag.CmpQDefProjectGroupId = num2;
		base.ViewBag.CmpQDefPrintAfterSave = flag4;
		GetPrsTitle();
		GetCnvsReferUser();
		GetCnvsStatus(num2);
		GetCmpTitle();
		GetCompanyQuickRegisterDefSetting();
		GetCmpReferUser();
		return View();
	}

	[AjaxOnly]
	public JsonResult GetCity(int provinceId, string val = "")
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectCompanyCity_Result> list2 = Enumerable.ToList<CRMspSelectCompanyCity_Result>(Enumerable.Where<CRMspSelectCompanyCity_Result>((IEnumerable<CRMspSelectCompanyCity_Result>)_db.CRMspSelectCompanyCity(UserLogin.CurrentUser.UserId, provinceId, lCID, result, result2), (Func<CRMspSelectCompanyCity_Result, bool>)((CRMspSelectCompanyCity_Result m) => (m.City ?? "").Contains(val))));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyCity_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyCity_Result>)list2, (Func<CRMspSelectCompanyCity_Result, SelectListItem>)((CRMspSelectCompanyCity_Result item) => new SelectListItem
			{
				Text = (item.City ?? ""),
				Value = item.CityID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CmpCityList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult SearchCity(int provinceId, string val = "")
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSearchCity_Result> list2 = Enumerable.ToList<CRMspSearchCity_Result>((IEnumerable<CRMspSearchCity_Result>)_db.CRMspSearchCity(UserLogin.CurrentUser.UserId, val, provinceId, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSearchCity_Result, SelectListItem>((IEnumerable<CRMspSearchCity_Result>)list2, (Func<CRMspSearchCity_Result, SelectListItem>)((CRMspSearchCity_Result item) => new SelectListItem
			{
				Text = ((!string.IsNullOrEmpty(item.Province)) ? (item.Province + " - ") : "") + item.City,
				Value = item.ProvinceId + "-" + item.CityID,
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CmpCityList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetProvince(int countryId, string val = "")
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectCompanyProvince_Result> list2 = Enumerable.ToList<CRMspSelectCompanyProvince_Result>(Enumerable.Where<CRMspSelectCompanyProvince_Result>((IEnumerable<CRMspSelectCompanyProvince_Result>)_db.CRMspSelectCompanyProvince(UserLogin.CurrentUser.UserId, countryId, lCID, result, result2), (Func<CRMspSelectCompanyProvince_Result, bool>)((CRMspSelectCompanyProvince_Result m) => (m.Province ?? "").Contains(val))));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyProvince_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyProvince_Result>)list2, (Func<CRMspSelectCompanyProvince_Result, SelectListItem>)((CRMspSelectCompanyProvince_Result item) => new SelectListItem
			{
				Text = (item.Province ?? ""),
				Value = item.ProvinceID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CmpProvinceList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCountry()
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
			List<CRMspSelectCountry_Result> list2 = Enumerable.ToList<CRMspSelectCountry_Result>((IEnumerable<CRMspSelectCountry_Result>)_db.CRMspSelectCountry(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectCountry_Result, SelectListItem>((IEnumerable<CRMspSelectCountry_Result>)list2, (Func<CRMspSelectCountry_Result, SelectListItem>)((CRMspSelectCountry_Result item) => new SelectListItem
			{
				Text = (item.Country ?? ""),
				Value = item.CountryID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CmpCountryList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPrsTitle()
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
			List<CRMspSelectPersonTitle_Result> list2 = Enumerable.ToList<CRMspSelectPersonTitle_Result>((IEnumerable<CRMspSelectPersonTitle_Result>)_db.CRMspSelectPersonTitle(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectPersonTitle_Result, SelectListItem>((IEnumerable<CRMspSelectPersonTitle_Result>)list2, (Func<CRMspSelectPersonTitle_Result, SelectListItem>)((CRMspSelectPersonTitle_Result item) => new SelectListItem
			{
				Text = (item.PersonTitle ?? ""),
				Value = item.PersonTitleID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PrsTitleList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCmpTitle()
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
			List<CRMspSelectCompanyTitle_Result> list2 = Enumerable.ToList<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)_db.CRMspSelectCompanyTitle(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyTitle_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyTitle_Result>)list2, (Func<CRMspSelectCompanyTitle_Result, SelectListItem>)((CRMspSelectCompanyTitle_Result item) => new SelectListItem
			{
				Text = (item.CompanyTitle ?? ""),
				Value = item.CompanyTitleID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CmpTitleList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCmpPresentation(string val = "")
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
			List<CRMspSelectCompanyPresentation_Result> list2 = Enumerable.ToList<CRMspSelectCompanyPresentation_Result>(Enumerable.Where<CRMspSelectCompanyPresentation_Result>((IEnumerable<CRMspSelectCompanyPresentation_Result>)_db.CRMspSelectCompanyPresentation(lCID, result), (Func<CRMspSelectCompanyPresentation_Result, bool>)((CRMspSelectCompanyPresentation_Result m) => (m.Presentation ?? "").Contains(val))));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyPresentation_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyPresentation_Result>)list2, (Func<CRMspSelectCompanyPresentation_Result, SelectListItem>)((CRMspSelectCompanyPresentation_Result item) => new SelectListItem
			{
				Text = (item.Presentation ?? ""),
				Value = item.CompanyPresentationID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CmpPresentationList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCmpType(string val = "")
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
			List<CRMspSelectCompanyType_Result> list2 = Enumerable.ToList<CRMspSelectCompanyType_Result>(Enumerable.Where<CRMspSelectCompanyType_Result>((IEnumerable<CRMspSelectCompanyType_Result>)_db.CRMspSelectCompanyType(lCID, result), (Func<CRMspSelectCompanyType_Result, bool>)((CRMspSelectCompanyType_Result m) => (m.CompanyTypeName ?? "").Contains(val))));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyType_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyType_Result>)list2, (Func<CRMspSelectCompanyType_Result, SelectListItem>)((CRMspSelectCompanyType_Result item) => new SelectListItem
			{
				Text = (item.CompanyTypeName ?? ""),
				Value = item.CompanyTypeID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CmpTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPrjGroup(string val = "")
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
			List<CRMspSelectProjectGroups_Result> list2 = Enumerable.ToList<CRMspSelectProjectGroups_Result>(Enumerable.Where<CRMspSelectProjectGroups_Result>((IEnumerable<CRMspSelectProjectGroups_Result>)_db.CRMspSelectProjectGroups(lCID, result), (Func<CRMspSelectProjectGroups_Result, bool>)((CRMspSelectProjectGroups_Result m) => (m.ProjectGroup ?? "").Contains(val))));
			list.AddRange(Enumerable.Select<CRMspSelectProjectGroups_Result, SelectListItem>((IEnumerable<CRMspSelectProjectGroups_Result>)list2, (Func<CRMspSelectProjectGroups_Result, SelectListItem>)((CRMspSelectProjectGroups_Result item) => new SelectListItem
			{
				Text = (item.ProjectGroup ?? ""),
				Value = item.ProjectGroupID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PrjGroupList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPrjGrade(string val = "")
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
			List<CRMspSelectProjectGrade_Result> list2 = Enumerable.ToList<CRMspSelectProjectGrade_Result>(Enumerable.Where<CRMspSelectProjectGrade_Result>((IEnumerable<CRMspSelectProjectGrade_Result>)_db.CRMspSelectProjectGrade(lCID, result), (Func<CRMspSelectProjectGrade_Result, bool>)((CRMspSelectProjectGrade_Result m) => (m.ProjectGrade ?? "").Contains(val))));
			list.AddRange(Enumerable.Select<CRMspSelectProjectGrade_Result, SelectListItem>((IEnumerable<CRMspSelectProjectGrade_Result>)list2, (Func<CRMspSelectProjectGrade_Result, SelectListItem>)((CRMspSelectProjectGrade_Result item) => new SelectListItem
			{
				Text = (item.ProjectGrade ?? ""),
				Value = item.ProjectGradeID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PrjGradeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPrjPriority(string val = "")
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
			List<CRMspSelectProjectPriority_Result> list2 = Enumerable.ToList<CRMspSelectProjectPriority_Result>(Enumerable.Where<CRMspSelectProjectPriority_Result>((IEnumerable<CRMspSelectProjectPriority_Result>)_db.CRMspSelectProjectPriority(lCID, result), (Func<CRMspSelectProjectPriority_Result, bool>)((CRMspSelectProjectPriority_Result m) => (m.Priority ?? "").Contains(val))));
			list.AddRange(Enumerable.Select<CRMspSelectProjectPriority_Result, SelectListItem>((IEnumerable<CRMspSelectProjectPriority_Result>)list2, (Func<CRMspSelectProjectPriority_Result, SelectListItem>)((CRMspSelectProjectPriority_Result item) => new SelectListItem
			{
				Text = (item.Priority ?? ""),
				Value = item.ProjectPriorityID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PrjPriorityList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCnvsStatus(int prjcnvsStatusGroupId = 0)
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
			List<CRMspSelectActiveConversationStatus_Result> list2 = Enumerable.ToList<CRMspSelectActiveConversationStatus_Result>((IEnumerable<CRMspSelectActiveConversationStatus_Result>)_dbI.CRMspSelectActiveConversationStatus(prjcnvsStatusGroupId, lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectActiveConversationStatus_Result, SelectListItem>((IEnumerable<CRMspSelectActiveConversationStatus_Result>)list2, (Func<CRMspSelectActiveConversationStatus_Result, SelectListItem>)((CRMspSelectActiveConversationStatus_Result item) => new SelectListItem
			{
				Text = ((!string.IsNullOrEmpty(item.Status)) ? item.Status : ""),
				Value = item.ConversationStatusID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CnvsStatusList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCnvsReferUser()
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectUserForCnvsReferToUser_Result> list2 = Enumerable.ToList<CRMspSelectUserForCnvsReferToUser_Result>((IEnumerable<CRMspSelectUserForCnvsReferToUser_Result>)_db.CRMspSelectUserForCnvsReferToUser(UserLogin.CurrentUser.UserId, 7, 0, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectUserForCnvsReferToUser_Result, SelectListItem>((IEnumerable<CRMspSelectUserForCnvsReferToUser_Result>)list2, (Func<CRMspSelectUserForCnvsReferToUser_Result, SelectListItem>)((CRMspSelectUserForCnvsReferToUser_Result item) => new SelectListItem
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
		base.ViewBag.CnvsReferUserList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPrjTitle(string val = "")
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			CRMSpEntities db = _db;
			int? userId = UserLogin.CurrentUser.UserId;
			List<CRMspSelectCompanyProjectTitle_Result> list2 = Enumerable.ToList<CRMspSelectCompanyProjectTitle_Result>((IEnumerable<CRMspSelectCompanyProjectTitle_Result>)db.CRMspSelectCompanyProjectTitle(val, userId, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyProjectTitle_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyProjectTitle_Result>)list2, (Func<CRMspSelectCompanyProjectTitle_Result, SelectListItem>)((CRMspSelectCompanyProjectTitle_Result item) => new SelectListItem
			{
				Text = (item.prjTitle ?? ""),
				Value = item.prjTitle + "^@^" + item.ProjectTitleStatusGroupId.GetValueOrDefault(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CnvsReferUserList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCnvsTopics()
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
			List<CRMspSelectConversationTopics_Result> list2 = Enumerable.ToList<CRMspSelectConversationTopics_Result>((IEnumerable<CRMspSelectConversationTopics_Result>)_db.CRMspSelectConversationTopics(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectConversationTopics_Result, SelectListItem>((IEnumerable<CRMspSelectConversationTopics_Result>)list2, (Func<CRMspSelectConversationTopics_Result, SelectListItem>)((CRMspSelectConversationTopics_Result item) => new SelectListItem
			{
				Text = (item.Topic ?? ""),
				Value = item.ConversationTopicsID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CnvsTopicsList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPrjStatusGroups()
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
			List<CRMspSelectConversationStatusGroups_Result> list2 = Enumerable.ToList<CRMspSelectConversationStatusGroups_Result>((IEnumerable<CRMspSelectConversationStatusGroups_Result>)_db.CRMspSelectConversationStatusGroups(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectConversationStatusGroups_Result, SelectListItem>((IEnumerable<CRMspSelectConversationStatusGroups_Result>)list2, (Func<CRMspSelectConversationStatusGroups_Result, SelectListItem>)((CRMspSelectConversationStatusGroups_Result item) => new SelectListItem
			{
				Text = (item.ConversationStatusGroup ?? ""),
				Value = item.ConversationStatusGroupID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PrjStatusGroupList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCmpReferUser()
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectCompanyReferUsers_Result> list2 = Enumerable.ToList<CRMspSelectCompanyReferUsers_Result>((IEnumerable<CRMspSelectCompanyReferUsers_Result>)_db.CRMspSelectCompanyReferUsers(UserLogin.CurrentUser.UserId, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyReferUsers_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyReferUsers_Result>)list2, (Func<CRMspSelectCompanyReferUsers_Result, SelectListItem>)((CRMspSelectCompanyReferUsers_Result item) => new SelectListItem
			{
				Text = (item.USER ?? ""),
				Value = item.UserId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CmpReferUserList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public List<CRMspCheckDuplicateCompany_Result> CheckDuplicateCmp(int? typeSearch, int cmpId, string val, int? titleId, int? cityId)
	{
		List<CRMspCheckDuplicateCompany_Result> result = new List<CRMspCheckDuplicateCompany_Result>();
		try
		{
			string lblLackOfShow = Labels.lblLackOfShow;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			result = Enumerable.ToList<CRMspCheckDuplicateCompany_Result>((IEnumerable<CRMspCheckDuplicateCompany_Result>)_db.CRMspCheckDuplicateCompany(typeSearch, cmpId, val, titleId, cityId, UserLogin.CurrentUser.UserId, lblLackOfShow, lCID, result2, result3));
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
	public JsonResult CheckDuplicateCompany(int? typeSearch, int cmpId, string val, int? titleId, int? cityId)
	{
		List<CRMspCheckDuplicateCompany_Result> data = new List<CRMspCheckDuplicateCompany_Result>();
		try
		{
			_ = Labels.lblLackOfShow;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			data = CheckDuplicateCmp(typeSearch, cmpId, val, titleId, cityId);
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public ActionResult CheckDuplicateCompany_Read([DataSourceRequest] DataSourceRequest request, int? typeSearch, int cmpId, string val, int? titleId, int? cityId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspCheckDuplicateCompany_Result> enumerable = new List<CRMspCheckDuplicateCompany_Result>();
		try
		{
			enumerable = CheckDuplicateCmp(typeSearch, cmpId, val, titleId, cityId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<CRMspMainSearchWeb_Result> MainSearchCompany(string searchVal)
	{
		List<CRMspMainSearchWeb_Result> result = new List<CRMspMainSearchWeb_Result>();
		try
		{
			_ = Labels.lblLackOfShow;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			result = Enumerable.ToList<CRMspMainSearchWeb_Result>((IEnumerable<CRMspMainSearchWeb_Result>)_dbI.CRMspMainSearchWeb(searchVal, UserLogin.CurrentUser.UserId, 1, lCID, result2, ",1000,1,2,3,8,9,11,12,14,17,20,21,22,", result3));
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
	public JsonResult MainSearch(string searchVal)
	{
		List<CRMspMainSearchWeb_Result> data = new List<CRMspMainSearchWeb_Result>();
		try
		{
			data = MainSearchCompany(searchVal);
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public ActionResult MainSearch_Read([DataSourceRequest] DataSourceRequest request, string searchVal)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspMainSearchWeb_Result> enumerable = new List<CRMspMainSearchWeb_Result>();
		try
		{
			enumerable = MainSearchCompany(searchVal);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult SearchConversation(int cnvsId)
	{
		CRMspSelectConversationByCmpOrCnvsId_Result cRMspSelectConversationByCmpOrCnvsId_Result = new CRMspSelectConversationByCmpOrCnvsId_Result();
		try
		{
			cRMspSelectConversationByCmpOrCnvsId_Result = SelectConversation(0, cnvsId);
			if (cRMspSelectConversationByCmpOrCnvsId_Result == null)
			{
				cRMspSelectConversationByCmpOrCnvsId_Result = new CRMspSelectConversationByCmpOrCnvsId_Result();
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
		JsonResult jsonResult = Json(cRMspSelectConversationByCmpOrCnvsId_Result, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult LoadInfo(int cmpId, int prsId, int prjId, int cnvsId)
	{
		CrmCmpPrsPrjCnvsLanguageViewModel crmCmpPrsPrjCnvsLanguageViewModel = new CrmCmpPrsPrjCnvsLanguageViewModel();
		try
		{
			_003C_003Ec__DisplayClass29_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass29_0();
			_ = Labels.lblLackOfShow;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			CS_0024_003C_003E8__locals0.cmp = Enumerable.FirstOrDefault<CRMspSelectCompanyByCmpAndUserId_Result>((IEnumerable<CRMspSelectCompanyByCmpAndUserId_Result>)_db.CRMspSelectCompanyByCmpAndUserId(cmpId, UserLogin.CurrentUser.UserId, CS_0024_003C_003E8__locals0.currLangID, result, result2));
			if (CS_0024_003C_003E8__locals0.cmp != null)
			{
				_003C_003Ec__DisplayClass29_1 _003C_003Ec__DisplayClass29_ = new _003C_003Ec__DisplayClass29_1();
				_003C_003Ec__DisplayClass29_.prs = SelectPerson(cmpId, prsId);
				_003C_003Ec__DisplayClass29_.prj = SelectProject(cmpId, prjId);
				_003C_003Ec__DisplayClass29_.cnvs = SelectConversation(cmpId, cnvsId);
				crmCmpPrsPrjCnvsLanguageViewModel.CompanyId = CS_0024_003C_003E8__locals0.cmp.CompanyID;
				crmCmpPrsPrjCnvsLanguageViewModel.CmpName = CS_0024_003C_003E8__locals0.cmp.cmpName ?? "";
				crmCmpPrsPrjCnvsLanguageViewModel.CmpPreTel = CS_0024_003C_003E8__locals0.cmp.cmpPreTel ?? "";
				crmCmpPrsPrjCnvsLanguageViewModel.CmpTel = CS_0024_003C_003E8__locals0.cmp.cmpTel ?? "";
				crmCmpPrsPrjCnvsLanguageViewModel.CmpProvinceId = CS_0024_003C_003E8__locals0.cmp.cmpProvinceId;
				crmCmpPrsPrjCnvsLanguageViewModel.CmpCityId = CS_0024_003C_003E8__locals0.cmp.cmpCityId;
				crmCmpPrsPrjCnvsLanguageViewModel.CmpNumber = CS_0024_003C_003E8__locals0.cmp.cmpNumber;
				crmCmpPrsPrjCnvsLanguageViewModel.CmpPresentationId = CS_0024_003C_003E8__locals0.cmp.cmpPresentationId;
				crmCmpPrsPrjCnvsLanguageViewModel.CmpTypeId = CS_0024_003C_003E8__locals0.cmp.cmpTypeId;
				crmCmpPrsPrjCnvsLanguageViewModel.CmpAddress = CS_0024_003C_003E8__locals0.cmp.cmpAddress ?? "";
				crmCmpPrsPrjCnvsLanguageViewModel.CmpReferUser = CS_0024_003C_003E8__locals0.cmp.ReferUser ?? "";
				crmCmpPrsPrjCnvsLanguageViewModel.CmpReferUserId = CS_0024_003C_003E8__locals0.cmp.cmpReferUserId;
				crmCmpPrsPrjCnvsLanguageViewModel.CmpSuppUserId = CS_0024_003C_003E8__locals0.cmp.cmpSuppUserId;
				crmCmpPrsPrjCnvsLanguageViewModel.RegisterUser = CS_0024_003C_003E8__locals0.cmp.RegisterUser ?? "";
				crmCmpPrsPrjCnvsLanguageViewModel.FirstRegisterUser = CS_0024_003C_003E8__locals0.cmp.FirstRegisterUser ?? "";
				crmCmpPrsPrjCnvsLanguageViewModel.FirstRegisterDatePersian = (CS_0024_003C_003E8__locals0.cmp.FirstRegisterDate.HasValue ? CS_0024_003C_003E8__locals0.cmp.FirstRegisterDate.Value.ToString("yyyy/MM/dd") : "");
				_ = CS_0024_003C_003E8__locals0.cmp.RegisterDate;
				crmCmpPrsPrjCnvsLanguageViewModel.RegisterDatePersian = CS_0024_003C_003E8__locals0.cmp.RegisterDate.ToString("yyyy/MM/dd");
				crmCmpPrsPrjCnvsLanguageViewModel.CmpEffectiveDate = (CS_0024_003C_003E8__locals0.cmp.cmpEffectiveDateTime.HasValue ? CS_0024_003C_003E8__locals0.cmp.cmpEffectiveDateTime.Value.ToString("yyyy/MM/dd") : "");
				crmCmpPrsPrjCnvsLanguageViewModel.CmpKind = CS_0024_003C_003E8__locals0.cmp.cmpKind.GetValueOrDefault();
				crmCmpPrsPrjCnvsLanguageViewModel.CmpTitleId = CS_0024_003C_003E8__locals0.cmp.cmpTitleId;
				CRMspSelectCompanyById_Result cRMspSelectCompanyById_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyById_Result>((IEnumerable<CRMspSelectCompanyById_Result>)_db.CRMspSelectCompanyById(CS_0024_003C_003E8__locals0.cmp.CompanyID, result, result, result2));
				if (cRMspSelectCompanyById_Result != null)
				{
					DbSet<CrmCompany_Lang> crmCompany_Lang = _dbTbl.CrmCompany_Lang;
					ParameterExpression val = Expression.Parameter(typeof(CrmCompany_Lang), "c");
					List<CrmCompany_Lang> list = Enumerable.ToList<CrmCompany_Lang>((IEnumerable<CrmCompany_Lang>)Queryable.Where<CrmCompany_Lang>((IQueryable<CrmCompany_Lang>)crmCompany_Lang, Expression.Lambda<Func<CrmCompany_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass29_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompany_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompany_Lang>)list, (Func<CrmCompany_Lang, CommonMultiLanguageViewModel>)((CrmCompany_Lang item) => new CommonMultiLanguageViewModel
					{
						Value = item.cmpName,
						LanguageId = item.LanguageID
					})));
					list2.Add(new CommonMultiLanguageViewModel
					{
						Value = cRMspSelectCompanyById_Result.cmpName,
						LanguageId = result
					});
					List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompany_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompany_Lang>)list, (Func<CrmCompany_Lang, CommonMultiLanguageViewModel>)((CrmCompany_Lang item) => new CommonMultiLanguageViewModel
					{
						Value = item.cmpAddress,
						LanguageId = item.LanguageID
					})));
					list3.Add(new CommonMultiLanguageViewModel
					{
						Value = cRMspSelectCompanyById_Result.cmpAddress,
						LanguageId = result
					});
					crmCmpPrsPrjCnvsLanguageViewModel.CmpName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
					crmCmpPrsPrjCnvsLanguageViewModel.CmpAddress = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
					crmCmpPrsPrjCnvsLanguageViewModel.CmpName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
					crmCmpPrsPrjCnvsLanguageViewModel.CmpAddress_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
				}
				if (_003C_003Ec__DisplayClass29_.prs != null)
				{
					crmCmpPrsPrjCnvsLanguageViewModel.CompanyPersonId = _003C_003Ec__DisplayClass29_.prs.CompanyPersonID;
					crmCmpPrsPrjCnvsLanguageViewModel.PrsTitleId = _003C_003Ec__DisplayClass29_.prs.prsTitleId;
					crmCmpPrsPrjCnvsLanguageViewModel.PrsLName = _003C_003Ec__DisplayClass29_.prs.prsLName ?? "";
					crmCmpPrsPrjCnvsLanguageViewModel.PrsFName = _003C_003Ec__DisplayClass29_.prs.prsFName ?? "";
					crmCmpPrsPrjCnvsLanguageViewModel.PrsMobile = _003C_003Ec__DisplayClass29_.prs.prsMobile ?? "";
					crmCmpPrsPrjCnvsLanguageViewModel.PrsBirthDate = (_003C_003Ec__DisplayClass29_.prs.prsBirthDateTime.HasValue ? _003C_003Ec__DisplayClass29_.prs.prsBirthDateTime.Value.ToString("yyyy/MM/dd") : "");
					crmCmpPrsPrjCnvsLanguageViewModel.PrsNationalCode = _003C_003Ec__DisplayClass29_.prs.prsNationalCode ?? "";
					CRMspSelectCompanyPersonByCmpOrPrsId_Result cRMspSelectCompanyPersonByCmpOrPrsId_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonByCmpOrPrsId_Result>((IEnumerable<CRMspSelectCompanyPersonByCmpOrPrsId_Result>)_db.CRMspSelectCompanyPersonByCmpOrPrsId(_003C_003Ec__DisplayClass29_.prs.CompanyPersonID, cmpId, languageID: result, defaultLanguageID: result, userId: UserLogin.CurrentUser.UserId, centerId: result2));
					if (cRMspSelectCompanyPersonByCmpOrPrsId_Result != null)
					{
						DbSet<CrmCompanyPersons_Lang> crmCompanyPersons_Lang = _dbTbl.CrmCompanyPersons_Lang;
						ParameterExpression val = Expression.Parameter(typeof(CrmCompanyPersons_Lang), "c");
						List<CrmCompanyPersons_Lang> list4 = Enumerable.ToList<CrmCompanyPersons_Lang>((IEnumerable<CrmCompanyPersons_Lang>)Queryable.Where<CrmCompanyPersons_Lang>((IQueryable<CrmCompanyPersons_Lang>)crmCompanyPersons_Lang, Expression.Lambda<Func<CrmCompanyPersons_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass29_, typeof(_003C_003Ec__DisplayClass29_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
						List<CommonMultiLanguageViewModel> list5 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyPersons_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyPersons_Lang>)list4, (Func<CrmCompanyPersons_Lang, CommonMultiLanguageViewModel>)((CrmCompanyPersons_Lang item) => new CommonMultiLanguageViewModel
						{
							Value = item.prsLName,
							LanguageId = item.LanguageID
						})));
						list5.Add(new CommonMultiLanguageViewModel
						{
							Value = cRMspSelectCompanyPersonByCmpOrPrsId_Result.prsLName,
							LanguageId = result
						});
						List<CommonMultiLanguageViewModel> list6 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyPersons_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyPersons_Lang>)list4, (Func<CrmCompanyPersons_Lang, CommonMultiLanguageViewModel>)((CrmCompanyPersons_Lang item) => new CommonMultiLanguageViewModel
						{
							Value = item.prsFName,
							LanguageId = item.LanguageID
						})));
						list6.Add(new CommonMultiLanguageViewModel
						{
							Value = cRMspSelectCompanyPersonByCmpOrPrsId_Result.prsFName,
							LanguageId = result
						});
						crmCmpPrsPrjCnvsLanguageViewModel.PrsLName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
						crmCmpPrsPrjCnvsLanguageViewModel.PrsFName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
						crmCmpPrsPrjCnvsLanguageViewModel.PrsLName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
						crmCmpPrsPrjCnvsLanguageViewModel.PrsFName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
					}
				}
				if (_003C_003Ec__DisplayClass29_.prj != null)
				{
					crmCmpPrsPrjCnvsLanguageViewModel.ProjectId = _003C_003Ec__DisplayClass29_.prj.ProjectID;
					crmCmpPrsPrjCnvsLanguageViewModel.PrjTitle = _003C_003Ec__DisplayClass29_.prj.prjTitle ?? "";
					crmCmpPrsPrjCnvsLanguageViewModel.PrjGroupId = _003C_003Ec__DisplayClass29_.prj.prjGroupId;
					crmCmpPrsPrjCnvsLanguageViewModel.PrjGradeId = _003C_003Ec__DisplayClass29_.prj.prjGradeId;
					crmCmpPrsPrjCnvsLanguageViewModel.PrjPriorityId = _003C_003Ec__DisplayClass29_.prj.prjPriorityId;
					crmCmpPrsPrjCnvsLanguageViewModel.PrjPostFix = _003C_003Ec__DisplayClass29_.prj.prjPostFix ?? "";
					crmCmpPrsPrjCnvsLanguageViewModel.PrjStartDate = _003C_003Ec__DisplayClass29_.prj.prjStartDate;
					crmCmpPrsPrjCnvsLanguageViewModel.PrjRemindDate = _003C_003Ec__DisplayClass29_.prj.prjRemindDate;
					crmCmpPrsPrjCnvsLanguageViewModel.DefProjectGroupId = _003C_003Ec__DisplayClass29_.prj.prjcnvsStatusGroupId;
					crmCmpPrsPrjCnvsLanguageViewModel.PrjDesc = _003C_003Ec__DisplayClass29_.prj.prjDesc ?? "";
					int userId = UserLogin.CurrentUser.UserId;
					CRMspSelectCompanyProjectByCmpOrPrjId_Result cRMspSelectCompanyProjectByCmpOrPrjId_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyProjectByCmpOrPrjId_Result>((IEnumerable<CRMspSelectCompanyProjectByCmpOrPrjId_Result>)_db.CRMspSelectCompanyProjectByCmpOrPrjId(_003C_003Ec__DisplayClass29_.prj.ProjectID, cmpId, userId, result, result, result2));
					if (cRMspSelectCompanyProjectByCmpOrPrjId_Result != null)
					{
						DbSet<CrmProjects_Lang> crmProjects_Lang = _dbTbl.CrmProjects_Lang;
						ParameterExpression val = Expression.Parameter(typeof(CrmProjects_Lang), "c");
						List<CrmProjects_Lang> list7 = Enumerable.ToList<CrmProjects_Lang>((IEnumerable<CrmProjects_Lang>)Queryable.Where<CrmProjects_Lang>((IQueryable<CrmProjects_Lang>)crmProjects_Lang, Expression.Lambda<Func<CrmProjects_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass29_, typeof(_003C_003Ec__DisplayClass29_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
						List<CommonMultiLanguageViewModel> list8 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmProjects_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmProjects_Lang>)list7, (Func<CrmProjects_Lang, CommonMultiLanguageViewModel>)((CrmProjects_Lang item) => new CommonMultiLanguageViewModel
						{
							Value = item.prjTitle,
							LanguageId = item.LanguageID
						})));
						list8.Add(new CommonMultiLanguageViewModel
						{
							Value = cRMspSelectCompanyProjectByCmpOrPrjId_Result.prjTitle,
							LanguageId = result
						});
						List<CommonMultiLanguageViewModel> list9 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmProjects_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmProjects_Lang>)list7, (Func<CrmProjects_Lang, CommonMultiLanguageViewModel>)((CrmProjects_Lang item) => new CommonMultiLanguageViewModel
						{
							Value = item.prjPostFix,
							LanguageId = item.LanguageID
						})));
						list9.Add(new CommonMultiLanguageViewModel
						{
							Value = cRMspSelectCompanyProjectByCmpOrPrjId_Result.prjPostFix,
							LanguageId = result
						});
						List<CommonMultiLanguageViewModel> list10 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmProjects_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmProjects_Lang>)list7, (Func<CrmProjects_Lang, CommonMultiLanguageViewModel>)((CrmProjects_Lang item) => new CommonMultiLanguageViewModel
						{
							Value = item.prjDesc,
							LanguageId = item.LanguageID
						})));
						list10.Add(new CommonMultiLanguageViewModel
						{
							Value = cRMspSelectCompanyProjectByCmpOrPrjId_Result.prjDesc,
							LanguageId = result
						});
						crmCmpPrsPrjCnvsLanguageViewModel.PrjTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
						crmCmpPrsPrjCnvsLanguageViewModel.PrjPostFix = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
						crmCmpPrsPrjCnvsLanguageViewModel.PrjTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
						crmCmpPrsPrjCnvsLanguageViewModel.PrjPostFix_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
						crmCmpPrsPrjCnvsLanguageViewModel.PrjDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
						crmCmpPrsPrjCnvsLanguageViewModel.PrjDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
					}
				}
				if (_003C_003Ec__DisplayClass29_.cnvs != null)
				{
					crmCmpPrsPrjCnvsLanguageViewModel.ConversationId = _003C_003Ec__DisplayClass29_.cnvs.ConversationID;
					crmCmpPrsPrjCnvsLanguageViewModel.CnvsDesc = _003C_003Ec__DisplayClass29_.cnvs.cnvsDesc ?? "";
					crmCmpPrsPrjCnvsLanguageViewModel.CnvsReferUserId = _003C_003Ec__DisplayClass29_.cnvs.cnvsReferUserId;
					crmCmpPrsPrjCnvsLanguageViewModel.CnvsReferDesc = _003C_003Ec__DisplayClass29_.cnvs.cnvsReferDesc ?? "";
					crmCmpPrsPrjCnvsLanguageViewModel.CnvsStatusId = _003C_003Ec__DisplayClass29_.cnvs.cnvsStatusId;
					crmCmpPrsPrjCnvsLanguageViewModel.CnvsStatusResultId = _003C_003Ec__DisplayClass29_.cnvs.cnvsStatusResultId;
					crmCmpPrsPrjCnvsLanguageViewModel.CnvsRemindDate = _003C_003Ec__DisplayClass29_.cnvs.cnvsRemindDate;
					crmCmpPrsPrjCnvsLanguageViewModel.CnvsTime = _003C_003Ec__DisplayClass29_.cnvs.cnvsTime ?? "";
					CRMspSelectConversationByCmpOrCnvsId_Result cRMspSelectConversationByCmpOrCnvsId_Result = Enumerable.FirstOrDefault<CRMspSelectConversationByCmpOrCnvsId_Result>((IEnumerable<CRMspSelectConversationByCmpOrCnvsId_Result>)_db.CRMspSelectConversationByCmpOrCnvsId(_003C_003Ec__DisplayClass29_.cnvs.ConversationID, cmpId, languageID: result, defaultLanguageID: result, userId: UserLogin.CurrentUser.UserId, centerId: result2));
					if (cRMspSelectConversationByCmpOrCnvsId_Result != null)
					{
						DbSet<CrmConversation_Lang> crmConversation_Lang = _dbTbl.CrmConversation_Lang;
						ParameterExpression val = Expression.Parameter(typeof(CrmConversation_Lang), "c");
						List<CrmConversation_Lang> list11 = Enumerable.ToList<CrmConversation_Lang>((IEnumerable<CrmConversation_Lang>)Queryable.Where<CrmConversation_Lang>((IQueryable<CrmConversation_Lang>)crmConversation_Lang, Expression.Lambda<Func<CrmConversation_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass29_, typeof(_003C_003Ec__DisplayClass29_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
						List<CommonMultiLanguageViewModel> list12 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmConversation_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmConversation_Lang>)list11, (Func<CrmConversation_Lang, CommonMultiLanguageViewModel>)((CrmConversation_Lang item) => new CommonMultiLanguageViewModel
						{
							Value = item.cnvsDesc,
							LanguageId = item.LanguageID
						})));
						list12.Add(new CommonMultiLanguageViewModel
						{
							Value = cRMspSelectConversationByCmpOrCnvsId_Result.cnvsDesc,
							LanguageId = result
						});
						List<CommonMultiLanguageViewModel> list13 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmConversation_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmConversation_Lang>)list11, (Func<CrmConversation_Lang, CommonMultiLanguageViewModel>)((CrmConversation_Lang item) => new CommonMultiLanguageViewModel
						{
							Value = item.cnvsReferDesc,
							LanguageId = item.LanguageID
						})));
						list13.Add(new CommonMultiLanguageViewModel
						{
							Value = cRMspSelectConversationByCmpOrCnvsId_Result.cnvsReferDesc,
							LanguageId = result
						});
						crmCmpPrsPrjCnvsLanguageViewModel.CnvsDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
						crmCmpPrsPrjCnvsLanguageViewModel.CnvsReferDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
						crmCmpPrsPrjCnvsLanguageViewModel.CnvsDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
						crmCmpPrsPrjCnvsLanguageViewModel.CnvsReferDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
					}
				}
				CRMspSelectCompanyConversationFirstCnvsUser_Result cRMspSelectCompanyConversationFirstCnvsUser_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyConversationFirstCnvsUser_Result>((IEnumerable<CRMspSelectCompanyConversationFirstCnvsUser_Result>)_dbI.CRMspSelectCompanyConversationFirstCnvsUser(cmpId, prjId, CS_0024_003C_003E8__locals0.currLangID, result));
				if (cRMspSelectCompanyConversationFirstCnvsUser_Result != null && cRMspSelectCompanyConversationFirstCnvsUser_Result.cnvsUserId.HasValue)
				{
					crmCmpPrsPrjCnvsLanguageViewModel.PrjFirstCnvsUserId = cRMspSelectCompanyConversationFirstCnvsUser_Result.cnvsUserId;
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
		JsonResult jsonResult = Json(crmCmpPrsPrjCnvsLanguageViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public CRMspSelectCompanyPersonByCmpOrPrsId_Result SelectPerson(int cmpId, int prsId)
	{
		CRMspSelectCompanyPersonByCmpOrPrsId_Result result = new CRMspSelectCompanyPersonByCmpOrPrsId_Result();
		try
		{
			_ = Labels.lblLackOfShow;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			result = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonByCmpOrPrsId_Result>((IEnumerable<CRMspSelectCompanyPersonByCmpOrPrsId_Result>)_db.CRMspSelectCompanyPersonByCmpOrPrsId(prsId, cmpId, languageID: lCID, defaultLanguageID: result2, userId: UserLogin.CurrentUser.UserId, centerId: result3));
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

	public CRMspSelectCompanyProjectByCmpOrPrjId_Result SelectProject(int cmpId, int prjId)
	{
		CRMspSelectCompanyProjectByCmpOrPrjId_Result cRMspSelectCompanyProjectByCmpOrPrjId_Result = new CRMspSelectCompanyProjectByCmpOrPrjId_Result();
		try
		{
			_ = Labels.lblLackOfShow;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			cRMspSelectCompanyProjectByCmpOrPrjId_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyProjectByCmpOrPrjId_Result>((IEnumerable<CRMspSelectCompanyProjectByCmpOrPrjId_Result>)_db.CRMspSelectCompanyProjectByCmpOrPrjId(prjId, cmpId, userId, lCID, result, result2));
			if (cRMspSelectCompanyProjectByCmpOrPrjId_Result != null)
			{
				cRMspSelectCompanyProjectByCmpOrPrjId_Result.prjRemindDate = (cRMspSelectCompanyProjectByCmpOrPrjId_Result.prjRemindDateTime.HasValue ? cRMspSelectCompanyProjectByCmpOrPrjId_Result.prjRemindDateTime.Value.ToString("yyyy/MM/dd") : "");
				cRMspSelectCompanyProjectByCmpOrPrjId_Result.prjStartDate = (cRMspSelectCompanyProjectByCmpOrPrjId_Result.prjStartDateTime.HasValue ? cRMspSelectCompanyProjectByCmpOrPrjId_Result.prjStartDateTime.Value.ToString("yyyy/MM/dd") : "");
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
		return cRMspSelectCompanyProjectByCmpOrPrjId_Result;
	}

	public CRMspSelectConversationByCmpOrCnvsId_Result SelectConversation(int cmpId, int cnvsId)
	{
		CRMspSelectConversationByCmpOrCnvsId_Result cRMspSelectConversationByCmpOrCnvsId_Result = new CRMspSelectConversationByCmpOrCnvsId_Result();
		try
		{
			_ = Labels.lblLackOfShow;
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
			cRMspSelectConversationByCmpOrCnvsId_Result = Enumerable.FirstOrDefault<CRMspSelectConversationByCmpOrCnvsId_Result>((IEnumerable<CRMspSelectConversationByCmpOrCnvsId_Result>)_db.CRMspSelectConversationByCmpOrCnvsId(cnvsId, cmpId, languageID: lCID, defaultLanguageID: result, userId: UserLogin.CurrentUser.UserId, centerId: result2));
			if (cRMspSelectConversationByCmpOrCnvsId_Result != null)
			{
				cRMspSelectConversationByCmpOrCnvsId_Result.cnvsRemindDate = (cRMspSelectConversationByCmpOrCnvsId_Result.cnvsRemindDateTime.HasValue ? cRMspSelectConversationByCmpOrCnvsId_Result.cnvsRemindDateTime.Value.ToString("yyyy/MM/dd") : "");
				cRMspSelectConversationByCmpOrCnvsId_Result.cnvsDate = (cRMspSelectConversationByCmpOrCnvsId_Result.cnvsDateTime.HasValue ? cRMspSelectConversationByCmpOrCnvsId_Result.cnvsDateTime.Value.ToString("yyyy/MM/dd") : "");
				cRMspSelectConversationByCmpOrCnvsId_Result.cnvsTime = cRMspSelectConversationByCmpOrCnvsId_Result.cnvsDate + " " + cRMspSelectConversationByCmpOrCnvsId_Result.cnvsTime;
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
		return cRMspSelectConversationByCmpOrCnvsId_Result;
	}

	public string CantSaveDupPrjPostFix(string prjPostFix, int currentId)
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
			if (!string.IsNullOrEmpty(prjPostFix) && UserLogin.IsUserAccess("frmDefineProjects", "actNotCanSavePrjPostFixDup", UserLogin.CurrentUser))
			{
				CRMspCheckDuplicatePrjPostFix_Result cRMspCheckDuplicatePrjPostFix_Result = Enumerable.FirstOrDefault<CRMspCheckDuplicatePrjPostFix_Result>((IEnumerable<CRMspCheckDuplicatePrjPostFix_Result>)_db.CRMspCheckDuplicatePrjPostFix(prjPostFix, currentId, lCID, result2));
				if (cRMspCheckDuplicatePrjPostFix_Result != null)
				{
					result = string.Format(Messages.CheckDuplicatePrjPostFix, cRMspCheckDuplicatePrjPostFix_Result.CompanyNumber.ToString(), cRMspCheckDuplicatePrjPostFix_Result.CompanyName ?? "");
				}
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		return result;
	}

	public string CantSaveDupPrjDesc(string prjDesc, int currentId)
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
			if (!string.IsNullOrEmpty(prjDesc) && UserLogin.IsUserAccess("frmDefineProjects", "actNotCanSavePrjDescDup", UserLogin.CurrentUser))
			{
				CRMspCheckDuplicatePrjDesc_Result cRMspCheckDuplicatePrjDesc_Result = Enumerable.FirstOrDefault<CRMspCheckDuplicatePrjDesc_Result>((IEnumerable<CRMspCheckDuplicatePrjDesc_Result>)_db.CRMspCheckDuplicatePrjDesc(prjDesc, currentId, lCID, result2));
				if (cRMspCheckDuplicatePrjDesc_Result != null)
				{
					result = string.Format(Messages.CheckDuplicatePrjDesc, cRMspCheckDuplicatePrjDesc_Result.CompanyNumber.ToString(), cRMspCheckDuplicatePrjDesc_Result.CompanyName ?? "");
				}
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		return result;
	}

	public string CantSaveDupTel(string tel, int mode, int currentId, ref int dupCmpId, string pre = "")
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
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null && !string.IsNullOrEmpty(tel) && ((cRMspSelectCrmsysSetting_Result.CantSaveDupTel.HasValue && cRMspSelectCrmsysSetting_Result.CantSaveDupTel != false) ? true : false) && !UserLogin.IsUserAccess("frmCompanyI", "actCanSaveTelDupAtTimeLimit", UserLogin.CurrentUser))
			{
				CRMspCheckDuplicateTel_Result cRMspCheckDuplicateTel_Result = Enumerable.FirstOrDefault<CRMspCheckDuplicateTel_Result>((IEnumerable<CRMspCheckDuplicateTel_Result>)_db.CRMspCheckDuplicateTel(pre + tel, mode, currentId, lCID, result2));
				if (cRMspCheckDuplicateTel_Result != null)
				{
					result = string.Format(Messages.CheckDuplicateTel, cRMspCheckDuplicateTel_Result.cmpNumber.ToString(), cRMspCheckDuplicateTel_Result.CompanyName ?? "");
					dupCmpId = cRMspCheckDuplicateTel_Result.CompanyID;
				}
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		return result;
	}

	public string CantSaveDupPrsMob(string mobile, int currentPersonId)
	{
		string result = "";
		CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
		if (cRMspSelectCrmsysSetting_Result != null && !string.IsNullOrEmpty(mobile) && ((cRMspSelectCrmsysSetting_Result.CantSaveDupPrsMob.HasValue && cRMspSelectCrmsysSetting_Result.CantSaveDupPrsMob != false) ? true : false) && !UserLogin.IsUserAccess("frmCompanyI", "actCanSaveMobDupAtTimeLimit", UserLogin.CurrentUser))
		{
			string text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)_db.CRMspCheckDuplicatePrsMobile(mobile, currentPersonId));
			if (text.ToString() != "")
			{
				result = "1" + Messages.CheckDuplicatePrsMobile + text;
			}
		}
		return result;
	}

	public string CantSaveDupPrsNationalCode(string prsNCode, int currentId, ref int dupCmpId, ref int dupPrsId)
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
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null && !string.IsNullOrEmpty(prsNCode) && ((cRMspSelectCrmsysSetting_Result.CantSaveDupPrsNationalCode.HasValue && cRMspSelectCrmsysSetting_Result.CantSaveDupPrsNationalCode != false) ? true : false))
			{
				CRMspCheckDuplicatePrsNationalCode_Result cRMspCheckDuplicatePrsNationalCode_Result = Enumerable.FirstOrDefault<CRMspCheckDuplicatePrsNationalCode_Result>((IEnumerable<CRMspCheckDuplicatePrsNationalCode_Result>)_db.CRMspCheckDuplicatePrsNationalCode(prsNCode, currentId, lCID, result2));
				if (cRMspCheckDuplicatePrsNationalCode_Result != null)
				{
					result = string.Format(Messages.CheckDuplicatePrsNationalCode, cRMspCheckDuplicatePrsNationalCode_Result.cmpNumber.ToString(), cRMspCheckDuplicatePrsNationalCode_Result.CompanyName ?? "");
					dupCmpId = cRMspCheckDuplicatePrsNationalCode_Result.prsCompanyId;
					dupPrsId = cRMspCheckDuplicatePrsNationalCode_Result.CompanyPersonID;
				}
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		return result;
	}

	[AjaxOnly]
	public JsonResult ActPost(CrmCmpPrsPrjCnvsLanguageViewModel model)
	{
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_035f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0407: Unknown result type (might be due to invalid IL or missing references)
		//IL_045b: Unknown result type (might be due to invalid IL or missing references)
		//IL_04af: Unknown result type (might be due to invalid IL or missing references)
		//IL_0503: Unknown result type (might be due to invalid IL or missing references)
		//IL_0557: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_53f7: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass38_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass38_0();
		CS_0024_003C_003E8__locals0.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		ResultInsertQuickCmpPrsPrjCnvs resultInsertQuickCmpPrsPrjCnvs = new ResultInsertQuickCmpPrsPrjCnvs();
		int num = 0;
		string text = "";
		try
		{
			if (!UserLogin.IsUserAccess("frmCompanyIQuickRegister", "actPost", UserLogin.CurrentUser))
			{
				resultInsertQuickCmpPrsPrjCnvs.IsDone = false;
				resultInsertQuickCmpPrsPrjCnvs.Message = Messages.ErrorNotAccess;
				return Json(resultInsertQuickCmpPrsPrjCnvs, JsonRequestBehavior.AllowGet);
			}
			if (CS_0024_003C_003E8__locals0.model != null)
			{
				_003C_003Ec__DisplayClass38_1 _003C_003Ec__DisplayClass38_ = new _003C_003Ec__DisplayClass38_1();
				int? num2 = null;
				if (UserLogin.CurrentUser != null)
				{
					num2 = UserLogin.CurrentUser.UserLastCId;
				}
				DateTime now = DateTime.Now;
				_ = Labels.PersonLabel;
				int userId = UserLogin.CurrentUser.UserId;
				DateTime value = now;
				string text2 = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(Financial.Get().Id.ToString());
				short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
				_ = Messages.MobConversationErjaShow;
				string appType = Configuration.AppType;
				string text3 = DateTimeClass.DefineDayeOfWeekStartWith7(now.DayOfWeek.ToString());
				string text4 = now.ToString("HH:mm:ss");
				int dupCmpId = 0;
				int dupPrsId = 0;
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.CmpName_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.CmpName_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.CmpName,
					LanguageId = lCID
				});
				int result = 0;
				int.TryParse(CS_0024_003C_003E8__locals0.model.CmpKind.ToString(), out result);
				List<Languages> list2 = Enumerable.ToList<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get());
				if (result == 1 && list != null && list2 != null && !UserLogin.IsUserAccess("frmCompanyI", "actCanChangeRealCmpNameInInsert", UserLogin.CurrentUser))
				{
					if (Enumerable.Count<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list) == Enumerable.Count<Languages>((IEnumerable<Languages>)list2))
					{
						foreach (CommonMultiLanguageViewModel item2 in list)
						{
							Languages languages = Enumerable.FirstOrDefault<Languages>((IEnumerable<Languages>)list2, (Func<Languages, bool>)((Languages m) => m.LanguageID == item2.LanguageId));
							if (languages != null)
							{
								item2.Value = MyResource.GetResourceString("lblPerson", languages.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
							}
						}
					}
					else
					{
						list = new List<CommonMultiLanguageViewModel>();
						foreach (Languages item3 in list2)
						{
							CommonMultiLanguageViewModel commonMultiLanguageViewModel = new CommonMultiLanguageViewModel();
							commonMultiLanguageViewModel.LanguageId = item3.LanguageID;
							commonMultiLanguageViewModel.Value = MyResource.GetResourceString("lblPerson", item3.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
							list.Add(commonMultiLanguageViewModel);
						}
					}
				}
				List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.CmpAddress_Lang))
				{
					list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.CmpAddress_Lang);
				}
				list3.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.CmpAddress,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.PrsLName_Lang))
				{
					list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.PrsLName_Lang);
				}
				list4.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.PrsLName,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.PrsFName_Lang))
				{
					list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.PrsFName_Lang);
				}
				list5.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.PrsFName,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.PrjTitle_Lang))
				{
					list6 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.PrjTitle_Lang);
				}
				list6.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.PrjTitle,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list7 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.PrjPostFix_Lang))
				{
					list7 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.PrjPostFix_Lang);
				}
				list7.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.PrjPostFix,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list8 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.PrjDesc_Lang))
				{
					list8 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.PrjDesc_Lang);
				}
				list8.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.PrjDesc,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list9 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.CnvsDesc_Lang))
				{
					list9 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.CnvsDesc_Lang);
				}
				list9.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.CnvsDesc,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list10 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.CnvsReferDesc_Lang))
				{
					list10 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.CnvsReferDesc_Lang);
				}
				list10.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.CnvsReferDesc,
					LanguageId = lCID
				});
				DbSet<CrmCompanyQuickRegisterDefSetting_Lang> crmCompanyQuickRegisterDefSetting_Lang = _dbTbl.CrmCompanyQuickRegisterDefSetting_Lang;
				ParameterExpression val = Expression.Parameter(typeof(CrmCompanyQuickRegisterDefSetting_Lang), "c");
				List<CrmCompanyQuickRegisterDefSetting_Lang> list11 = Enumerable.ToList<CrmCompanyQuickRegisterDefSetting_Lang>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)Queryable.Where<CrmCompanyQuickRegisterDefSetting_Lang>((IQueryable<CrmCompanyQuickRegisterDefSetting_Lang>)crmCompanyQuickRegisterDefSetting_Lang, Expression.Lambda<Func<CrmCompanyQuickRegisterDefSetting_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Coalesce((Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass38_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)0, typeof(int)))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				DbSet<CrmCompanyQuickRegisterDefSetting> crmCompanyQuickRegisterDefSetting = _dbTbl.CrmCompanyQuickRegisterDefSetting;
				val = Expression.Parameter(typeof(CrmCompanyQuickRegisterDefSetting), "c");
				CrmCompanyQuickRegisterDefSetting crmCompanyQuickRegisterDefSetting2 = Queryable.FirstOrDefault<CrmCompanyQuickRegisterDefSetting>((IQueryable<CrmCompanyQuickRegisterDefSetting>)crmCompanyQuickRegisterDefSetting, Expression.Lambda<Func<CrmCompanyQuickRegisterDefSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Coalesce((Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass38_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)0, typeof(int)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				string text5 = "";
				List<CommonMultiLanguageViewModel> list12 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list11, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.cmpActivityType,
					LanguageId = item.LanguageID
				})));
				if (crmCompanyQuickRegisterDefSetting2 != null)
				{
					list12.Add(new CommonMultiLanguageViewModel
					{
						Value = crmCompanyQuickRegisterDefSetting2.cmpActivityType,
						LanguageId = CS_0024_003C_003E8__locals0.defLangID
					});
					text5 = crmCompanyQuickRegisterDefSetting2.cmpActivityType;
				}
				string text6 = "";
				List<CommonMultiLanguageViewModel> list13 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list11, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.cmpSpecialPoint,
					LanguageId = item.LanguageID
				})));
				if (crmCompanyQuickRegisterDefSetting2 != null)
				{
					list13.Add(new CommonMultiLanguageViewModel
					{
						Value = crmCompanyQuickRegisterDefSetting2.cmpSpecialPoint,
						LanguageId = CS_0024_003C_003E8__locals0.defLangID
					});
					text6 = crmCompanyQuickRegisterDefSetting2.cmpSpecialPoint;
				}
				string text7 = "";
				List<CommonMultiLanguageViewModel> list14 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list11, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.cmpDescription,
					LanguageId = item.LanguageID
				})));
				if (crmCompanyQuickRegisterDefSetting2 != null)
				{
					list14.Add(new CommonMultiLanguageViewModel
					{
						Value = crmCompanyQuickRegisterDefSetting2.cmpDescription,
						LanguageId = CS_0024_003C_003E8__locals0.defLangID
					});
					text7 = crmCompanyQuickRegisterDefSetting2.cmpDescription;
				}
				string text8 = "";
				List<CommonMultiLanguageViewModel> list15 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list11, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.prsSpecialPoint,
					LanguageId = item.LanguageID
				})));
				if (crmCompanyQuickRegisterDefSetting2 != null)
				{
					list15.Add(new CommonMultiLanguageViewModel
					{
						Value = crmCompanyQuickRegisterDefSetting2.prsSpecialPoint,
						LanguageId = CS_0024_003C_003E8__locals0.defLangID
					});
					text8 = crmCompanyQuickRegisterDefSetting2.prsSpecialPoint;
				}
				string text9 = "";
				List<CommonMultiLanguageViewModel> list16 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list11, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.prsDescription,
					LanguageId = item.LanguageID
				})));
				if (crmCompanyQuickRegisterDefSetting2 != null)
				{
					list16.Add(new CommonMultiLanguageViewModel
					{
						Value = crmCompanyQuickRegisterDefSetting2.prsDescription,
						LanguageId = CS_0024_003C_003E8__locals0.defLangID
					});
					text9 = crmCompanyQuickRegisterDefSetting2.prsDescription;
				}
				string text10 = "";
				List<CommonMultiLanguageViewModel> list17 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list11, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.prjSubject,
					LanguageId = item.LanguageID
				})));
				if (crmCompanyQuickRegisterDefSetting2 != null)
				{
					list17.Add(new CommonMultiLanguageViewModel
					{
						Value = crmCompanyQuickRegisterDefSetting2.prjSubject,
						LanguageId = CS_0024_003C_003E8__locals0.defLangID
					});
					text10 = crmCompanyQuickRegisterDefSetting2.prjSubject;
				}
				string text11 = "";
				List<CommonMultiLanguageViewModel> list18 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list11, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.prjTitleGroup,
					LanguageId = item.LanguageID
				})));
				if (crmCompanyQuickRegisterDefSetting2 != null)
				{
					list18.Add(new CommonMultiLanguageViewModel
					{
						Value = crmCompanyQuickRegisterDefSetting2.prjTitleGroup,
						LanguageId = CS_0024_003C_003E8__locals0.defLangID
					});
					text11 = crmCompanyQuickRegisterDefSetting2.prjTitleGroup;
				}
				string text12 = "";
				List<CommonMultiLanguageViewModel> list19 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list11, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.prjDescI,
					LanguageId = item.LanguageID
				})));
				if (crmCompanyQuickRegisterDefSetting2 != null)
				{
					list19.Add(new CommonMultiLanguageViewModel
					{
						Value = crmCompanyQuickRegisterDefSetting2.prjDescI,
						LanguageId = CS_0024_003C_003E8__locals0.defLangID
					});
					text12 = crmCompanyQuickRegisterDefSetting2.prjDescI;
				}
				bool flag = false;
				bool flag2 = false;
				bool flag3 = false;
				_003C_003Ec__DisplayClass38_.setId = 0;
				int.TryParse(SysSeting.Get().ID.ToString(), out _003C_003Ec__DisplayClass38_.setId);
				DbSet<CrmsysSetting> crmsysSetting = _dbTbl.CrmsysSetting;
				val = Expression.Parameter(typeof(CrmsysSetting), "m");
				CrmsysSetting crmsysSetting2 = Queryable.FirstOrDefault<CrmsysSetting>((IQueryable<CrmsysSetting>)crmsysSetting, Expression.Lambda<Func<CrmsysSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass38_, typeof(_003C_003Ec__DisplayClass38_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (crmsysSetting2 != null)
				{
					flag = ((crmsysSetting2.cmpQNotNullProjectGroup.HasValue && crmsysSetting2.cmpQNotNullProjectGroup != false) ? true : false);
					flag2 = ((crmsysSetting2.cmpQNotNullProjectGrade.HasValue && crmsysSetting2.cmpQNotNullProjectGrade != false) ? true : false);
					flag3 = ((crmsysSetting2.cmpQNotNullProjectPriority.HasValue && crmsysSetting2.cmpQNotNullProjectPriority != false) ? true : false);
				}
				int? defProjectGroupId = CS_0024_003C_003E8__locals0.model.DefProjectGroupId;
				int num3 = CS_0024_003C_003E8__locals0.model.CmpReferUserId.GetValueOrDefault();
				if (num3 == 0)
				{
					num++;
					text = text + string.Format(Messages.msgErrorIsNotEntered, Labels.CompanyIICmpReferUser) + "<br>";
				}
				if (!UserLogin.IsUserAccess("frmCompanyI", "actCanChangeReferUserInInsert", UserLogin.CurrentUser))
				{
					num3 = userId;
				}
				if (CS_0024_003C_003E8__locals0.model.CmpCountryId.GetValueOrDefault() == 0)
				{
					num++;
					text = text + string.Format(Messages.MsgErrorNotSetFieldInCmpQuickRegDefSetting, Labels.CmpQuickRegisterDefSettingCmpCity) + "<br>";
				}
				if (CS_0024_003C_003E8__locals0.model.CnvsTopicId.GetValueOrDefault() == 0)
				{
					num++;
					text = text + string.Format(Messages.MsgErrorNotSetFieldInCmpQuickRegDefSetting, Labels.CmpQuickRegisterDefSettingCnvsTopic) + "<br>";
				}
				if (defProjectGroupId.GetValueOrDefault() == 0)
				{
					num++;
					text = text + string.Format(Messages.MsgErrorNotSetFieldInCmpQuickRegDefSetting, Labels.CmpQuickRegisterDefSettingPrjCnvsStatusGroup) + "<br>";
				}
				if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.CmpName))
				{
					num++;
					text = text + string.Format(Messages.msgErrorIsNotEntered, Labels.CompanyIICmpName) + "<br>";
				}
				else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.model.CmpName, list))
				{
					num++;
					text = text + string.Format(Messages.CheckFieldInLang, Labels.CompanyIICmpName) + "<br>";
				}
				if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.PrsLName))
				{
					num++;
					text = text + string.Format(Messages.msgErrorIsNotEntered, Labels.CompanyIIPrsName) + "<br>";
				}
				else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.model.PrsLName, list4))
				{
					num++;
					text = text + string.Format(Messages.CheckFieldInLang, Labels.CompanyIIPrsName) + "<br>";
				}
				if (!CS_0024_003C_003E8__locals0.model.CmpProvinceId.HasValue)
				{
					num++;
					text = text + string.Format(Messages.msgErrorIsNotEntered, Labels.CompanyIICmpProvince) + "<br>";
				}
				if (!CS_0024_003C_003E8__locals0.model.CmpCityId.HasValue)
				{
					num++;
					text = text + string.Format(Messages.msgErrorIsNotEntered, Labels.CompanyIICmpCity) + "<br>";
				}
				if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.PrjTitle))
				{
					num++;
					text = text + string.Format(Messages.msgErrorIsNotEntered, Labels.CompanyIIPrjTitle) + "<br>";
				}
				else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.model.PrjTitle, list6))
				{
					num++;
					text = text + string.Format(Messages.CheckFieldInLang, Labels.CompanyIIPrjTitle) + "<br>";
				}
				if (flag && !CS_0024_003C_003E8__locals0.model.PrjGroupId.HasValue)
				{
					num++;
					text = text + string.Format(Messages.msgErrorIsNotEntered, Labels.CompanyIIPrjGroup) + "<br>";
				}
				if (flag2 && !CS_0024_003C_003E8__locals0.model.PrjGradeId.HasValue)
				{
					num++;
					text = text + string.Format(Messages.msgErrorIsNotEntered, Labels.CompanyIIPrjGrade) + "<br>";
				}
				if (flag3 && !CS_0024_003C_003E8__locals0.model.PrjPriorityId.HasValue)
				{
					num++;
					text = text + string.Format(Messages.msgErrorIsNotEntered, Labels.CompanyIIPrjPriority) + "<br>";
				}
				if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.CnvsDesc))
				{
					num++;
					text = text + string.Format(Messages.msgErrorIsNotEntered, Labels.CompanyIICnvsDesc) + "<br>";
				}
				else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.model.CnvsDesc, list9))
				{
					num++;
					text = text + string.Format(Messages.CheckFieldInLang, Labels.CompanyIICnvsDesc) + "<br>";
				}
				if (!CS_0024_003C_003E8__locals0.model.CnvsStatusId.HasValue)
				{
					num++;
					text = text + string.Format(Messages.msgErrorIsNotEntered, Labels.CompanyIICnvsStatus) + "<br>";
				}
				if (!CS_0024_003C_003E8__locals0.model.CnvsReferUserId.HasValue)
				{
					num++;
					text = text + string.Format(Messages.msgErrorIsNotEntered, Labels.CompanyIICnvsReferUser) + "<br>";
				}
				if (!CS_0024_003C_003E8__locals0.model.CnvsStatusResultId.HasValue)
				{
					num++;
					text = text + string.Format(Messages.msgErrorIsNotEntered, Labels.CompanyIICnvsStatusResult) + "<br>";
				}
				CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
				DateTime? dateTime = DateTime.Now;
				DateTime? dateTime2 = DateTime.Now;
				DateTime? dateTime3 = DateTime.Now;
				DateTime dateTime4 = default(DateTime);
				string text13 = "";
				try
				{
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.PrjStartDate))
					{
						text13 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.model.PrjStartDate.Replace("/", ""));
						switch (lCID)
						{
						case 1065:
							dateTime4 = DateTime.Parse(text13 + " " + now.ToString("HH:mm:ss"), new PersianCulture());
							CS_0024_003C_003E8__locals0.model.PrjStartDate = dateTime4.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime4 = DateTime.Parse(text13 + " " + now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
							CS_0024_003C_003E8__locals0.model.PrjStartDate = dateTime4.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime4 = DateTime.Parse(text13 + " " + now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
							CS_0024_003C_003E8__locals0.model.PrjStartDate = dateTime4.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						dateTime = dateTime4;
					}
					else
					{
						CS_0024_003C_003E8__locals0.model.PrjStartDate = text2;
						dateTime = value;
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					num++;
					text = text + string.Format(Messages.ErrorInFormat, Labels.CompanyIIPrjStartDate) + "<br>";
				}
				dateTime4 = default(DateTime);
				text13 = "";
				try
				{
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.PrjRemindDate))
					{
						text13 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.model.PrjRemindDate.Replace("/", ""));
						switch (lCID)
						{
						case 1065:
							dateTime4 = DateTime.Parse(text13 + " " + now.ToString("HH:mm:ss"), new PersianCulture());
							CS_0024_003C_003E8__locals0.model.PrjRemindDate = dateTime4.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime4 = DateTime.Parse(text13 + " " + now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
							CS_0024_003C_003E8__locals0.model.PrjRemindDate = dateTime4.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime4 = DateTime.Parse(text13 + " " + now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
							CS_0024_003C_003E8__locals0.model.PrjRemindDate = dateTime4.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						dateTime2 = dateTime4;
					}
					else
					{
						dateTime2 = null;
					}
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
					num++;
					text = text + string.Format(Messages.ErrorInFormat, Labels.CompanyIIPrjRemindDate) + "<br>";
				}
				dateTime4 = default(DateTime);
				text13 = "";
				try
				{
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.CnvsRemindDate))
					{
						text13 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.model.CnvsRemindDate.Replace("/", ""));
						switch (lCID)
						{
						case 1065:
							dateTime4 = DateTime.Parse(text13 + " " + now.ToString("HH:mm:ss"), new PersianCulture());
							CS_0024_003C_003E8__locals0.model.CnvsRemindDate = dateTime4.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime4 = DateTime.Parse(text13 + " " + now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
							CS_0024_003C_003E8__locals0.model.CnvsRemindDate = dateTime4.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime4 = DateTime.Parse(text13 + " " + now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
							CS_0024_003C_003E8__locals0.model.CnvsRemindDate = dateTime4.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						dateTime3 = dateTime4;
					}
					else
					{
						dateTime3 = null;
						if (cRMspSelectCrmsysSetting_Result != null && cRMspSelectCrmsysSetting_Result.MustFullcnvsRemindDate.HasValue && cRMspSelectCrmsysSetting_Result.MustFullcnvsRemindDate != false)
						{
							num++;
							text = text + Messages.CheckmustFullCnvsRemindDate + "<br>";
						}
						if (CS_0024_003C_003E8__locals0.model.CnvsReferUserId != UserLogin.CurrentUser.UserId && !UserLogin.IsUserAccess("frmDefineConversation", "actCnvsReferUserWithoutRemindDate", UserLogin.CurrentUser))
						{
							num++;
							text = text + Messages.cnvsErrorNotMatchUserIdReferID + "<br>";
						}
					}
				}
				catch (Exception e3)
				{
					ErrorSignal.FromCurrentContext().Raise(e3);
					num++;
					text = text + string.Format(Messages.ErrorInFormat, Labels.CompanyIICnvsRemindDate) + "<br>";
				}
				DateTime? cmpEffectiveDateTime = DateTime.Now;
				DateTime? prsBirthDateTime = DateTime.Now;
				dateTime4 = default(DateTime);
				text13 = "";
				try
				{
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.CmpEffectiveDate))
					{
						text13 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.model.CmpEffectiveDate.Replace("/", ""));
						switch (lCID)
						{
						case 1065:
							dateTime4 = DateTime.Parse(text13 + " " + now.ToString("HH:mm:ss"), new PersianCulture());
							CS_0024_003C_003E8__locals0.model.CmpEffectiveDate = dateTime4.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime4 = DateTime.Parse(text13 + " " + now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
							CS_0024_003C_003E8__locals0.model.CmpEffectiveDate = dateTime4.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime4 = DateTime.Parse(text13 + " " + now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
							CS_0024_003C_003E8__locals0.model.CmpEffectiveDate = dateTime4.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						cmpEffectiveDateTime = dateTime4;
					}
					else
					{
						cmpEffectiveDateTime = null;
					}
				}
				catch (Exception e4)
				{
					ErrorSignal.FromCurrentContext().Raise(e4);
					num++;
					text = text + string.Format(Messages.ErrorInFormat, Labels.CompanyIICmpEffectiveDate) + "<br>";
				}
				dateTime4 = default(DateTime);
				text13 = "";
				try
				{
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.PrsBirthDate))
					{
						text13 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.model.PrsBirthDate.Replace("/", ""));
						switch (lCID)
						{
						case 1065:
							dateTime4 = DateTime.Parse(text13 + " " + now.ToString("HH:mm:ss"), new PersianCulture());
							CS_0024_003C_003E8__locals0.model.PrsBirthDate = dateTime4.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime4 = DateTime.Parse(text13 + " " + now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
							CS_0024_003C_003E8__locals0.model.PrsBirthDate = dateTime4.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime4 = DateTime.Parse(text13 + " " + now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
							CS_0024_003C_003E8__locals0.model.PrsBirthDate = dateTime4.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						prsBirthDateTime = dateTime4;
					}
					else
					{
						prsBirthDateTime = null;
					}
				}
				catch (Exception e5)
				{
					ErrorSignal.FromCurrentContext().Raise(e5);
					num++;
					text = text + string.Format(Messages.ErrorInFormat, Labels.CompanyIIPrsBirthDate) + "<br>";
				}
				if (CS_0024_003C_003E8__locals0.model.IsPrj.GetValueOrDefault() != 1)
				{
					DbSet<CrmsysDBObjects> crmsysDBObjects = _dbTbl.CrmsysDBObjects;
					val = Expression.Parameter(typeof(CrmsysDBObjects), "m");
					using (List<CrmsysDBObjects>.Enumerator enumerator3 = Enumerable.ToList<CrmsysDBObjects>((IEnumerable<CrmsysDBObjects>)Queryable.Where<CrmsysDBObjects>((IQueryable<CrmsysDBObjects>)crmsysDBObjects, Expression.Lambda<Func<CrmsysDBObjects, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)"CrmCompany", typeof(string))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Convert((Expression)(object)Expression.Constant((object)true, typeof(bool)), typeof(bool?)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }))).GetEnumerator())
					{
						while (enumerator3.MoveNext())
						{
							switch (enumerator3.Current.FieldName)
							{
							case "cmpTitleId":
								if (!CS_0024_003C_003E8__locals0.model.CmpTitleId.HasValue && result == 0)
								{
									text = text + Messages.CheckcmpTitleId + "<br>";
									num++;
								}
								break;
							case "cmpPresentationId":
								if (!CS_0024_003C_003E8__locals0.model.CmpPresentationId.HasValue)
								{
									text = text + Messages.CheckcmpPresentationId + "<br>";
									num++;
								}
								break;
							case "cmpTypeId":
								if (!CS_0024_003C_003E8__locals0.model.CmpTypeId.HasValue)
								{
									text = text + Messages.CheckcmpTypeId + "<br>";
									num++;
								}
								break;
							case "cmpPreTel":
								if (CS_0024_003C_003E8__locals0.model.CmpPreTel == null)
								{
									text = text + Messages.CheckcmpPreTel + "<br>";
									num++;
								}
								break;
							case "cmpTel":
								if (CS_0024_003C_003E8__locals0.model.CmpTel == null)
								{
									text = text + Messages.CheckcmpTel + "<br>";
									num++;
								}
								break;
							case "cmpAddress":
								if (CS_0024_003C_003E8__locals0.model.CmpAddress == null)
								{
									text = text + Messages.CheckcmpAddress + "<br>";
									num++;
								}
								else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.model.CmpAddress, list3))
								{
									text = text + Messages.CheckcmpAddressLang + "<br>";
									num++;
								}
								break;
							case "cmpEffectiveDatePersian":
								if (CS_0024_003C_003E8__locals0.model.CmpEffectiveDate == null)
								{
									text = text + Messages.CheckCmpEffectiveDatePersian + "<br>";
									num++;
								}
								break;
							case "cmpActivityType":
								if (string.IsNullOrWhiteSpace(text5))
								{
									text = text + string.Format(Messages.MsgErrorNotSetFieldInCmpQuickRegDefSetting, Labels.CmpQuickRegisterDefSettingCmpActivityType) + "<br>";
									num++;
								}
								else if (!checkMultiLanguage(text5, list12))
								{
									text = text + string.Format(Messages.msgErrorNotSetFieldInCmpQuickRegDefSettingInLang, Labels.CmpQuickRegisterDefSettingCmpActivityType) + "<br>";
									num++;
								}
								break;
							case "cmpSpecialPoint":
								if (string.IsNullOrWhiteSpace(text6))
								{
									text = text + string.Format(Messages.MsgErrorNotSetFieldInCmpQuickRegDefSetting, Labels.CmpQuickRegisterDefSettingCmpSpecialPoint) + "<br>";
									num++;
								}
								else if (!checkMultiLanguage(text6, list13))
								{
									text = text + string.Format(Messages.msgErrorNotSetFieldInCmpQuickRegDefSettingInLang, Labels.CmpQuickRegisterDefSettingCmpSpecialPoint) + "<br>";
									num++;
								}
								break;
							case "cmpDescription":
								if (string.IsNullOrWhiteSpace(text7))
								{
									text = text + string.Format(Messages.MsgErrorNotSetFieldInCmpQuickRegDefSetting, Labels.CmpQuickRegisterDefSettingCmpDescription) + "<br>";
									num++;
								}
								else if (!checkMultiLanguage(text7, list14))
								{
									text = text + string.Format(Messages.msgErrorNotSetFieldInCmpQuickRegDefSettingInLang, Labels.CmpQuickRegisterDefSettingCmpDescription) + "<br>";
									num++;
								}
								break;
							}
						}
					}
					if (CS_0024_003C_003E8__locals0.model.CmpPreTel != null && CS_0024_003C_003E8__locals0.model.CmpPreTel.Length > 1 && CS_0024_003C_003E8__locals0.model.CmpPreTel.Substring(0, 2) == "09")
					{
						text = text + Messages.msgErrorCheckcmpPreTelMobileInQuickInsert + "<br>";
						num++;
					}
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.CmpTel))
					{
						bool flag4 = true;
						for (int i = 0; i < CS_0024_003C_003E8__locals0.model.CmpTel.Length; i++)
						{
							if (!char.IsDigit(CS_0024_003C_003E8__locals0.model.CmpTel[i]))
							{
								flag4 = false;
							}
						}
						if (!flag4)
						{
							text = text + string.Format(Messages.msgErrorCheckDigit, Labels.CompanyIICmpTel) + "<br>";
							num++;
						}
					}
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.CmpPreTel))
					{
						bool flag5 = true;
						for (int j = 0; j < CS_0024_003C_003E8__locals0.model.CmpPreTel.Length; j++)
						{
							if (!char.IsDigit(CS_0024_003C_003E8__locals0.model.CmpPreTel[j]))
							{
								flag5 = false;
							}
						}
						if (!flag5)
						{
							text = text + string.Format(Messages.msgErrorCheckDigit, Labels.CompanyIICmpPreTel) + "<br>";
							num++;
						}
					}
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.CmpTel))
					{
						CantSaveDupTel(CS_0024_003C_003E8__locals0.model.CmpTel, 1, CS_0024_003C_003E8__locals0.model.CompanyId, ref dupCmpId, CS_0024_003C_003E8__locals0.model.CmpPreTel ?? "");
					}
					string text14 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					if (!string.IsNullOrEmpty(text14) && text14 != Labels.lblPerson && text14 != "شخص")
					{
						int titleId = (CS_0024_003C_003E8__locals0.model.CmpTitleId.HasValue ? int.Parse(CS_0024_003C_003E8__locals0.model.CmpTitleId.ToString()) : 0);
						int cityId = (CS_0024_003C_003E8__locals0.model.CmpCityId.HasValue ? int.Parse(CS_0024_003C_003E8__locals0.model.CmpCityId.ToString()) : 0);
						CRMspCheckDuplicateCompanyViewModel cRMspCheckDuplicateCompanyViewModel = CRMIdeal.Classes.Helper.Company.CheckDuplicateCompany(1, 0, text14, titleId, cityId, userId);
						if (cRMspCheckDuplicateCompanyViewModel != null)
						{
							dupCmpId = cRMspCheckDuplicateCompanyViewModel.CompanyID;
						}
					}
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.PrsMobile))
					{
						try
						{
							long.Parse(CS_0024_003C_003E8__locals0.model.PrsMobile);
						}
						catch
						{
							text = text + string.Format(Messages.msgErrorCheckDigit, Labels.CompanyIIPrsMobile) + "<br>";
							num++;
						}
					}
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.PrsMobile))
					{
						int mobNumLen = CRMIdeal.Classes.Helper.Setting.GetMobNumLen();
						bool mobNumLenNoCheck = CRMIdeal.Classes.Helper.Setting.GetMobNumLenNoCheck();
						if (CS_0024_003C_003E8__locals0.model.PrsMobile.Length != mobNumLen && !mobNumLenNoCheck)
						{
							text = text + Messages.CheckprsMobile + "<br>";
							num++;
						}
						if (CS_0024_003C_003E8__locals0.model.PrsMobile.Length >= 2 && CS_0024_003C_003E8__locals0.model.PrsMobile.Substring(0, 2) != "09" && !mobNumLenNoCheck)
						{
							text = text + Messages.CheckprsMobileFormat + "<br>";
							num++;
						}
					}
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.PrsNationalCode))
					{
						CantSaveDupPrsNationalCode(CS_0024_003C_003E8__locals0.model.PrsNationalCode, CS_0024_003C_003E8__locals0.model.CompanyPersonId, ref dupCmpId, ref dupPrsId);
					}
					List<CRMspSelectsysDBObjectsNotNull_Result> list20 = Enumerable.ToList<CRMspSelectsysDBObjectsNotNull_Result>((IEnumerable<CRMspSelectsysDBObjectsNotNull_Result>)_db.CRMspSelectsysDBObjectsNotNull("CrmCompanyPersons", lCID, CS_0024_003C_003E8__locals0.defLangID));
					if (list20 != null && Enumerable.Any<CRMspSelectsysDBObjectsNotNull_Result>((IEnumerable<CRMspSelectsysDBObjectsNotNull_Result>)list20))
					{
						using List<CRMspSelectsysDBObjectsNotNull_Result>.Enumerator enumerator4 = list20.GetEnumerator();
						while (enumerator4.MoveNext())
						{
							switch (enumerator4.Current.FieldName)
							{
							case "prsLName":
								if (string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.model.PrsLName))
								{
									text = text + string.Format(Messages.ErrorEmpty, Labels.prsLName + " (" + Labels.lblCompayPerson + ") ") + "<br/>";
									num++;
								}
								else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.model.PrsLName, list4))
								{
									text = text + string.Format(Messages.CheckFieldInLang, Labels.prsLName + " (" + Labels.lblCompayPerson + ") ") + "<br>";
									num++;
								}
								break;
							case "prsFName":
								if (string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.model.PrsFName))
								{
									text = text + string.Format(Messages.ErrorEmpty, Labels.prsFName + " (" + Labels.lblCompayPerson + ") ") + "<br/>";
									num++;
								}
								else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.model.PrsFName, list5))
								{
									text = text + string.Format(Messages.CheckFieldInLang, Labels.prsFName + " (" + Labels.lblCompayPerson + ") ") + "<br>";
									num++;
								}
								break;
							case "prsTitleId":
								if (!CS_0024_003C_003E8__locals0.model.PrsTitleId.HasValue && result == 1)
								{
									text = text + string.Format(Messages.ErrorEmpty, Labels.prsTitleId + " (" + Labels.lblCompayPerson + ") ") + "<br/>";
									num++;
								}
								break;
							case "prsMobile":
								if (string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.model.PrsMobile))
								{
									text = text + string.Format(Messages.ErrorEmpty, Labels.prsMobile + " (" + Labels.lblCompayPerson + ") ") + "<br/>";
									num++;
								}
								break;
							case "prsNationalCode":
								if (string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.model.PrsNationalCode))
								{
									text = text + string.Format(Messages.ErrorEmpty, Labels.prsNationalCode + " (" + Labels.lblCompayPerson + ") ") + "<br/>";
									num++;
								}
								break;
							case "prsBirthDate":
								if (string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.model.PrsBirthDate))
								{
									text = text + string.Format(Messages.ErrorEmpty, Labels.prsBirthDate + " (" + Labels.lblCompayPerson + ") ") + "<br/>";
									num++;
								}
								break;
							case "prsSpecialPoint":
								if (string.IsNullOrWhiteSpace(text8))
								{
									text = text + string.Format(Messages.MsgErrorNotSetFieldInCmpQuickRegDefSetting, Labels.CmpQuickRegisterDefSettingPrsSpecialPoint) + "<br>";
									num++;
								}
								else if (!checkMultiLanguage(text8, list15))
								{
									text = text + string.Format(Messages.msgErrorNotSetFieldInCmpQuickRegDefSettingInLang, Labels.CmpQuickRegisterDefSettingPrsSpecialPoint) + "<br>";
									num++;
								}
								break;
							case "prsDescription":
								if (string.IsNullOrWhiteSpace(text9))
								{
									text = text + string.Format(Messages.MsgErrorNotSetFieldInCmpQuickRegDefSetting, Labels.CmpQuickRegisterDefSettingPrsDescription) + "<br>";
									num++;
								}
								else if (!checkMultiLanguage(text9, list16))
								{
									text = text + string.Format(Messages.msgErrorNotSetFieldInCmpQuickRegDefSettingInLang, Labels.CmpQuickRegisterDefSettingPrsDescription) + "<br>";
									num++;
								}
								break;
							}
						}
					}
				}
				if (list6 != null)
				{
					string text15 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					if (!string.IsNullOrEmpty(text15))
					{
						bool flag6 = UserLogin.IsUserAccess("frmDefineProjects", "actCanSaveNewTitleWithoutDefine", UserLogin.CurrentUser);
						if (Enumerable.FirstOrDefault<CRMspSelectCompanyProjectTitle_Result>((IEnumerable<CRMspSelectCompanyProjectTitle_Result>)_db.CRMspSelectCompanyProjectTitle(text15, userId, lCID, CS_0024_003C_003E8__locals0.defLangID, num2)) == null && !flag6)
						{
							text = text + Messages.prjMsgNotAccessDefinePrjTitle + "<br>";
							num++;
						}
					}
				}
				if (list7 != null)
				{
					string text16 = "";
					foreach (CommonMultiLanguageViewModel item4 in list7)
					{
						if (!string.IsNullOrEmpty(item4.Value) && string.IsNullOrEmpty(text16))
						{
							text16 = CantSaveDupPrjPostFix(item4.Value, 0);
						}
					}
					if (!string.IsNullOrEmpty(text16))
					{
						num++;
						text = text + text16 + "<br>";
					}
				}
				if (list8 != null)
				{
					string text17 = "";
					foreach (CommonMultiLanguageViewModel item5 in list8)
					{
						if (!string.IsNullOrEmpty(item5.Value) && string.IsNullOrEmpty(text17))
						{
							text17 = CantSaveDupPrjDesc(item5.Value, 0);
						}
					}
					if (!string.IsNullOrEmpty(text17))
					{
						num++;
						text = text + text17 + "<br>";
					}
				}
				List<CRMspSelectsysDBObjectsNotNull_Result> list21 = Enumerable.ToList<CRMspSelectsysDBObjectsNotNull_Result>((IEnumerable<CRMspSelectsysDBObjectsNotNull_Result>)_db.CRMspSelectsysDBObjectsNotNull("CrmProjects", lCID, CS_0024_003C_003E8__locals0.defLangID));
				if (list21 != null && Enumerable.Any<CRMspSelectsysDBObjectsNotNull_Result>((IEnumerable<CRMspSelectsysDBObjectsNotNull_Result>)list21))
				{
					using List<CRMspSelectsysDBObjectsNotNull_Result>.Enumerator enumerator4 = list21.GetEnumerator();
					while (enumerator4.MoveNext())
					{
						switch (enumerator4.Current.FieldName)
						{
						case "prjTitle":
							if (string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.model.PrjTitle))
							{
								text = text + string.Format(Messages.ErrorEmpty, Labels.prjTitle) + "<br/>";
								num++;
							}
							else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.model.PrjTitle, list6))
							{
								text = text + string.Format(Messages.CheckFieldInLang, Labels.prjTitle) + "<br>";
								num++;
							}
							break;
						case "prjDesc":
							if (string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.model.PrjDesc))
							{
								text = text + string.Format(Messages.ErrorEmpty, Labels.prjDesc) + "<br/>";
								num++;
							}
							else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.model.PrjDesc, list8))
							{
								text = text + string.Format(Messages.CheckFieldInLang, Labels.prjDesc) + "<br>";
								num++;
							}
							break;
						case "prjGradeId":
							if (!CS_0024_003C_003E8__locals0.model.PrjGradeId.HasValue)
							{
								text = text + string.Format(Messages.ErrorEmpty, Labels.prjGradeId) + "<br/>";
								num++;
							}
							break;
						case "prjPriorityId":
							if (!CS_0024_003C_003E8__locals0.model.PrjPriorityId.HasValue)
							{
								text = text + string.Format(Messages.ErrorEmpty, Labels.prjPriorityId) + "<br/>";
								num++;
							}
							break;
						case "prjGroupId":
							if (!CS_0024_003C_003E8__locals0.model.PrjGroupId.HasValue)
							{
								text = text + string.Format(Messages.ErrorEmpty, Labels.prjGroupId) + "<br/>";
								num++;
							}
							break;
						case "prjcnvsStatusGroupId":
							if (!CS_0024_003C_003E8__locals0.model.DefProjectGroupId.HasValue)
							{
								text = text + string.Format(Messages.ErrorEmpty, Labels.prjcnvsStatusGroupId) + "<br/>";
								num++;
							}
							break;
						case "prjPostFix":
							if (string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.model.PrjPostFix))
							{
								text = text + string.Format(Messages.ErrorEmpty, Labels.prjPostFix) + "<br/>";
								num++;
							}
							else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.model.PrjPostFix, list7))
							{
								text = text + string.Format(Messages.CheckFieldInLang, Labels.prjPostFix) + "<br>";
								num++;
							}
							break;
						case "prjRemindDate":
							if (string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.model.PrjRemindDate))
							{
								text = text + string.Format(Messages.ErrorEmpty, Labels.prjRemindDate) + "<br/>";
								num++;
							}
							break;
						case "prjSubject":
							if (string.IsNullOrWhiteSpace(text10))
							{
								text = text + string.Format(Messages.MsgErrorNotSetFieldInCmpQuickRegDefSetting, Labels.CmpQuickRegisterDefSettingPrjSubject) + "<br>";
								num++;
							}
							else if (!checkMultiLanguage(text10, list17))
							{
								text = text + string.Format(Messages.msgErrorNotSetFieldInCmpQuickRegDefSettingInLang, Labels.CmpQuickRegisterDefSettingPrjSubject) + "<br>";
								num++;
							}
							break;
						case "prjTitleGroup":
							if (string.IsNullOrWhiteSpace(text11))
							{
								text = text + string.Format(Messages.MsgErrorNotSetFieldInCmpQuickRegDefSetting, Labels.CmpQuickRegisterDefSettingPrjTitleGroup) + "<br>";
								num++;
							}
							else if (!checkMultiLanguage(text11, list18))
							{
								text = text + string.Format(Messages.msgErrorNotSetFieldInCmpQuickRegDefSettingInLang, Labels.CmpQuickRegisterDefSettingPrjTitleGroup) + "<br>";
								num++;
							}
							break;
						case "prjDescI":
							if (string.IsNullOrWhiteSpace(text12))
							{
								text = text + string.Format(Messages.MsgErrorNotSetFieldInCmpQuickRegDefSetting, Labels.CmpQuickRegisterDefSettingPrjDescI) + "<br>";
								num++;
							}
							else if (!checkMultiLanguage(text12, list19))
							{
								text = text + string.Format(Messages.msgErrorNotSetFieldInCmpQuickRegDefSettingInLang, Labels.CmpQuickRegisterDefSettingPrjDescI) + "<br>";
								num++;
							}
							break;
						}
					}
				}
				if (CS_0024_003C_003E8__locals0.model.CnvsStatusId.HasValue)
				{
					CRMspSelectConversationForcedStatusBFCurr_Result cRMspSelectConversationForcedStatusBFCurr_Result = Enumerable.FirstOrDefault<CRMspSelectConversationForcedStatusBFCurr_Result>((IEnumerable<CRMspSelectConversationForcedStatusBFCurr_Result>)_db.CRMspSelectConversationForcedStatusBFCurr(CS_0024_003C_003E8__locals0.model.CnvsStatusId, 0, lCID, CS_0024_003C_003E8__locals0.defLangID, 0));
					if (cRMspSelectConversationForcedStatusBFCurr_Result != null)
					{
						string arg = ((!string.IsNullOrEmpty(cRMspSelectConversationForcedStatusBFCurr_Result.Status)) ? cRMspSelectConversationForcedStatusBFCurr_Result.Status : "");
						text = text + string.Format(Messages.CheckForcedStatusBFCurr, arg) + "<br>";
						num++;
					}
				}
				int userId2 = UserLogin.CurrentUser.UserId;
				int result2 = 0;
				int.TryParse(CS_0024_003C_003E8__locals0.model.CnvsStatusResultId.ToString(), out result2);
				if (result2 == 0)
				{
					num++;
					text = text + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.CompanyIICnvsStatusResult) + "<br>";
				}
				else
				{
					CRMspSelectConversationStatusResultById_Result cRMspSelectConversationStatusResultById_Result = Enumerable.FirstOrDefault<CRMspSelectConversationStatusResultById_Result>((IEnumerable<CRMspSelectConversationStatusResultById_Result>)_dbI.CRMspSelectConversationStatusResultById(result2, lCID, CS_0024_003C_003E8__locals0.defLangID));
					if (cRMspSelectConversationStatusResultById_Result == null)
					{
						num++;
						text = text + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.CompanyIICnvsStatusResult) + "<br>";
					}
					else
					{
						bool result3 = false;
						bool.TryParse(cRMspSelectConversationStatusResultById_Result.CnvsRemindDateNotNull.ToString(), out result3);
						if (result3 && string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.model.CnvsRemindDate))
						{
							num++;
							text = text + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.cnvsRemindDate) + "<br>";
						}
						string text18 = cRMspSelectConversationStatusResultById_Result.StatusResultUsedUserIds ?? "";
						if (!string.IsNullOrWhiteSpace(text18))
						{
							string[] array = text18.Split(new char[1] { '|' });
							if (array != null && array.Length != 0)
							{
								bool flag7 = false;
								string[] array2 = array;
								foreach (string s in array2)
								{
									int result4 = 0;
									int.TryParse(s, out result4);
									if (result4 != 0 && result4 == userId2)
									{
										flag7 = true;
									}
								}
								if (!flag7)
								{
									num++;
									text = text + Messages.msgErrorCanNotSaveCnvsInResult + "<br>";
								}
							}
						}
						bool result5 = false;
						bool.TryParse(cRMspSelectConversationStatusResultById_Result.NeedDyFormChecked.ToString(), out result5);
						if (result5 && CS_0024_003C_003E8__locals0.model.CompanyId != 0)
						{
							int result6 = 0;
							int.TryParse(cRMspSelectConversationStatusResultById_Result.NeedDyFormCheckedFormId.ToString(), out result6);
							if (result6 != 0)
							{
								CRMspCnvsStatusResultNeedDyFormChecked_Result cRMspCnvsStatusResultNeedDyFormChecked_Result = Enumerable.FirstOrDefault<CRMspCnvsStatusResultNeedDyFormChecked_Result>((IEnumerable<CRMspCnvsStatusResultNeedDyFormChecked_Result>)_dbI.CRMspCnvsStatusResultNeedDyFormChecked(result6, CS_0024_003C_003E8__locals0.model.CompanyId, CS_0024_003C_003E8__locals0.model.CompanyPersonId, CS_0024_003C_003E8__locals0.model.ProjectId, CS_0024_003C_003E8__locals0.model.ConversationId, lCID, CS_0024_003C_003E8__locals0.defLangID));
								if (cRMspCnvsStatusResultNeedDyFormChecked_Result != null)
								{
									bool result7 = false;
									bool.TryParse(cRMspCnvsStatusResultNeedDyFormChecked_Result.IsChecked.ToString(), out result7);
									if (!result7)
									{
										num++;
										text = text + string.Format(Messages.msgErrorNotSaveCnvsBeforeDyFormChecked, cRMspCnvsStatusResultNeedDyFormChecked_Result.FormName ?? "", cRMspCnvsStatusResultNeedDyFormChecked_Result.DyFormNumber.GetValueOrDefault().ToString()) + "<br>";
									}
								}
								else
								{
									num++;
									text = text + string.Format(Messages.msgErrorNotSaveCnvsBeforeInsertDyFormFromCmp, cRMspSelectConversationStatusResultById_Result.NeedDyFormCheckedForm ?? "") + "<br>";
								}
							}
						}
						bool result8 = false;
						bool.TryParse(cRMspSelectConversationStatusResultById_Result.NoCnvsDup.ToString(), out result8);
						if (result8)
						{
							CRMspCnvsStatusResultNoCnvsDup_Result cRMspCnvsStatusResultNoCnvsDup_Result = Enumerable.FirstOrDefault<CRMspCnvsStatusResultNoCnvsDup_Result>((IEnumerable<CRMspCnvsStatusResultNoCnvsDup_Result>)_dbI.CRMspCnvsStatusResultNoCnvsDup(CS_0024_003C_003E8__locals0.model.CompanyId, CS_0024_003C_003E8__locals0.model.ProjectId, CS_0024_003C_003E8__locals0.model.CnvsStatusResultId, CS_0024_003C_003E8__locals0.model.ConversationId, lCID, CS_0024_003C_003E8__locals0.defLangID));
							if (cRMspCnvsStatusResultNoCnvsDup_Result != null)
							{
								cRMspCnvsStatusResultNoCnvsDup_Result.cnvsDate = (cRMspCnvsStatusResultNoCnvsDup_Result.cnvsDateTime.HasValue ? cRMspCnvsStatusResultNoCnvsDup_Result.cnvsDateTime.Value.ToString("yyyy/MM/dd") : "");
								num++;
								text = text + string.Format(Messages.msgErrorNoDupCnvsInStatusResult, cRMspCnvsStatusResultNoCnvsDup_Result.cnvsDate, cRMspCnvsStatusResultNoCnvsDup_Result.cnvsStatus ?? "", cRMspCnvsStatusResultNoCnvsDup_Result.cnvsStatusResult ?? "") + "<br>";
							}
						}
						int result9 = 0;
						int.TryParse(cRMspSelectConversationStatusResultById_Result.CnvsCountLimit.ToString(), out result9);
						if (result9 > 0)
						{
							int? num4 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbI.CRMspReturnCnvsStatusResultCnvsCount(CS_0024_003C_003E8__locals0.model.CompanyId, CS_0024_003C_003E8__locals0.model.ProjectId, CS_0024_003C_003E8__locals0.model.CnvsStatusResultId, CS_0024_003C_003E8__locals0.model.ConversationId));
							int result10 = 0;
							int.TryParse(num4.ToString(), out result10);
							if (CS_0024_003C_003E8__locals0.model.ConversationId == 0)
							{
								result10++;
							}
							if (result9 < result10)
							{
								num++;
								text = text + string.Format(Messages.msgErrorCnvsCountLimitInStatusResult, cRMspSelectConversationStatusResultById_Result.ResultTitle ?? "", result9.ToString()) + "<br>";
							}
						}
						long result11 = 0L;
						long.TryParse(cRMspSelectConversationStatusResultById_Result.CnvsDoingTimeLimit.ToString(), out result11);
						if (result11 > 0)
						{
							long? num5 = Enumerable.FirstOrDefault<long?>((IEnumerable<long?>)_dbI.CRMspReturnCnvsStatusResultCnvsSumDoingTime(CS_0024_003C_003E8__locals0.model.CompanyId, CS_0024_003C_003E8__locals0.model.ProjectId, CS_0024_003C_003E8__locals0.model.CnvsStatusResultId, CS_0024_003C_003E8__locals0.model.ConversationId));
							long result12 = 0L;
							long.TryParse(num5.ToString(), out result12);
							long num6 = 0L;
							result12 += num6;
							result11 *= 60;
							if (result11 < result12)
							{
								long.TryParse(cRMspSelectConversationStatusResultById_Result.CnvsDoingTimeLimit.ToString(), out result11);
								num++;
								text = text + string.Format(Messages.msgErrorCnvsDoingTimeLimitInStatusResult, cRMspSelectConversationStatusResultById_Result.ResultTitle ?? "", result11.ToString()) + "<br>";
							}
						}
					}
				}
				int result13 = 0;
				int.TryParse(CS_0024_003C_003E8__locals0.model.CnvsStatusId.ToString(), out result13);
				if (result13 == 0)
				{
					num++;
					text = text + string.Format(Messages.msgErrorIsNotEntered, Labels.CompanyIICnvsStatus) + "<br>";
				}
				else
				{
					CRMspSelectConversationStatusById_Result cRMspSelectConversationStatusById_Result = Enumerable.FirstOrDefault<CRMspSelectConversationStatusById_Result>((IEnumerable<CRMspSelectConversationStatusById_Result>)_db.CRMspSelectConversationStatusById(result13, lCID, CS_0024_003C_003E8__locals0.defLangID));
					if (cRMspSelectConversationStatusById_Result == null)
					{
						num++;
						text = text + string.Format(Messages.msgErrorIsNotEntered, Labels.CompanyIICnvsStatus) + "<br>";
					}
					else
					{
						bool result14 = false;
						bool.TryParse(cRMspSelectConversationStatusById_Result.GroupNoRegCnvsOlderStatus.ToString(), out result14);
						bool result15 = false;
						bool.TryParse(cRMspSelectConversationStatusById_Result.NoRegCnvsOlderStatus.ToString(), out result15);
						if (result14)
						{
							CRMspSelectConversationStatusNextCurr_Result cRMspSelectConversationStatusNextCurr_Result = Enumerable.FirstOrDefault<CRMspSelectConversationStatusNextCurr_Result>((IEnumerable<CRMspSelectConversationStatusNextCurr_Result>)_dbI.CRMspSelectConversationStatusNextCurr(result13, CS_0024_003C_003E8__locals0.model.ProjectId, CS_0024_003C_003E8__locals0.model.ConversationId, lCID, CS_0024_003C_003E8__locals0.defLangID));
							if (cRMspSelectConversationStatusNextCurr_Result != null)
							{
								num++;
								text = text + string.Format(Messages.msgErrorNoRegCnvsOlderStatus, cRMspSelectConversationStatusNextCurr_Result.Status ?? "") + "<br>";
							}
						}
						else if (result15)
						{
							CRMspSelectConversationStatusNextCurr_Result cRMspSelectConversationStatusNextCurr_Result2 = Enumerable.FirstOrDefault<CRMspSelectConversationStatusNextCurr_Result>((IEnumerable<CRMspSelectConversationStatusNextCurr_Result>)_dbI.CRMspSelectConversationStatusNextCurr(result13, CS_0024_003C_003E8__locals0.model.ProjectId, CS_0024_003C_003E8__locals0.model.ConversationId, lCID, CS_0024_003C_003E8__locals0.defLangID));
							if (cRMspSelectConversationStatusNextCurr_Result2 != null)
							{
								num++;
								text = text + string.Format(Messages.msgErrorNoRegCnvsOlderStatus, cRMspSelectConversationStatusNextCurr_Result2.Status ?? "") + "<br>";
							}
						}
						string text19 = cRMspSelectConversationStatusById_Result.StatusUsedUserIds ?? "";
						if (!string.IsNullOrWhiteSpace(text19))
						{
							string[] array3 = text19.Split(new char[1] { '|' });
							if (array3 != null && array3.Length != 0)
							{
								bool flag8 = false;
								string[] array2 = array3;
								foreach (string s2 in array2)
								{
									int result16 = 0;
									int.TryParse(s2, out result16);
									if (result16 != 0 && result16 == userId2)
									{
										flag8 = true;
									}
								}
								if (!flag8)
								{
									num++;
									text = text + Messages.msgErrorCanNotSaveCnvsInStatus + "<br>";
								}
							}
						}
						int result17 = 0;
						int.TryParse(cRMspSelectConversationStatusById_Result.CnvsCountLimit.ToString(), out result17);
						if (result17 > 0)
						{
							int? num7 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbI.CRMspReturnCnvsStatusCnvsCount(CS_0024_003C_003E8__locals0.model.CompanyId, CS_0024_003C_003E8__locals0.model.ProjectId, CS_0024_003C_003E8__locals0.model.CnvsStatusId, CS_0024_003C_003E8__locals0.model.ConversationId));
							int result18 = 0;
							int.TryParse(num7.ToString(), out result18);
							if (CS_0024_003C_003E8__locals0.model.ConversationId == 0)
							{
								result18++;
							}
							if (result17 < result18)
							{
								num++;
								text = text + string.Format(Messages.msgErrorCnvsCountLimitInStatus, cRMspSelectConversationStatusById_Result.Status ?? "", result17.ToString()) + "<br>";
							}
						}
						long result19 = 0L;
						long.TryParse(cRMspSelectConversationStatusById_Result.CnvsDoingTimeLimit.ToString(), out result19);
						if (result19 > 0)
						{
							long? num8 = Enumerable.FirstOrDefault<long?>((IEnumerable<long?>)_dbI.CRMspReturnCnvsStatusCnvsSumDoingTime(CS_0024_003C_003E8__locals0.model.CompanyId, CS_0024_003C_003E8__locals0.model.ProjectId, CS_0024_003C_003E8__locals0.model.CnvsStatusId, CS_0024_003C_003E8__locals0.model.ConversationId));
							long result20 = 0L;
							long.TryParse(num8.ToString(), out result20);
							long num9 = 0L;
							result20 += num9;
							result19 *= 60;
							if (result19 < result20)
							{
								long.TryParse(cRMspSelectConversationStatusById_Result.CnvsDoingTimeLimit.ToString(), out result19);
								num++;
								text = text + string.Format(Messages.msgErrorCnvsDoingTimeLimitInStatus, cRMspSelectConversationStatusById_Result.Status ?? "", result19.ToString()) + "<br>";
							}
						}
					}
				}
				if (num > 0)
				{
					resultInsertQuickCmpPrsPrjCnvs.IsDone = false;
					resultInsertQuickCmpPrsPrjCnvs.Message = text;
				}
				else
				{
					_003C_003Ec__DisplayClass38_3 _003C_003Ec__DisplayClass38_2 = new _003C_003Ec__DisplayClass38_3();
					ObjectParameter objectParameter = new ObjectParameter("insertedCompanyId", 0);
					ObjectParameter objectParameter2 = new ObjectParameter("insertedPersonId", 0);
					ObjectParameter objectParameter3 = new ObjectParameter("insertedProjectId", 0);
					ObjectParameter objectParameter4 = new ObjectParameter("insertedConversationId", 0);
					ObjectParameter objectParameter5 = new ObjectParameter("isCmpDup", false);
					_db.CRMspInsertQuickCmpPrsPrjCnvs(num3, (Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null, CS_0024_003C_003E8__locals0.model.CmpTypeId, CS_0024_003C_003E8__locals0.model.CmpPresentationId, CS_0024_003C_003E8__locals0.model.CmpPreTel, CS_0024_003C_003E8__locals0.model.CmpTel, CS_0024_003C_003E8__locals0.model.CmpCountryId, CS_0024_003C_003E8__locals0.model.CmpProvinceId, CS_0024_003C_003E8__locals0.model.CmpCityId, (Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null, (Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null, (Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null, CS_0024_003C_003E8__locals0.model.PrsTitleId, CS_0024_003C_003E8__locals0.model.PrsMobile, (Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null, (Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null, CS_0024_003C_003E8__locals0.model.PrjGroupId, CS_0024_003C_003E8__locals0.model.PrjGradeId, CS_0024_003C_003E8__locals0.model.PrjPriorityId, defProjectGroupId, CS_0024_003C_003E8__locals0.model.CnvsTopicId, (Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null, null, userId, CS_0024_003C_003E8__locals0.model.CnvsReferUserId, (Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null, CS_0024_003C_003E8__locals0.model.CnvsStatusId, null, CS_0024_003C_003E8__locals0.model.CnvsRemindDate, dateTime3, value2, value3, userId, text2, value, text3, text4, appType, CS_0024_003C_003E8__locals0.defLangID, CS_0024_003C_003E8__locals0.model.CompanyId, (CS_0024_003C_003E8__locals0.model.CompanyPersonId > 0) ? new int?(CS_0024_003C_003E8__locals0.model.CompanyPersonId) : null, 0, 0, CS_0024_003C_003E8__locals0.model.PrjRemindDate, dateTime2, CS_0024_003C_003E8__locals0.model.PrjStartDate, DateTimeClass.DefineDayeOfWeekStartWith7(dateTime.Value.DayOfWeek.ToString()), text4, dateTime, insertedCompanyId: objectParameter, insertedPersonId: objectParameter2, insertedProjectId: objectParameter3, insertedConversationId: objectParameter4, prjDesc: (Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null, cmpEffectiveDatePersian: CS_0024_003C_003E8__locals0.model.CmpEffectiveDate, cmpEffectiveDateTime: cmpEffectiveDateTime, prsBirthDate: CS_0024_003C_003E8__locals0.model.PrsBirthDate, prsBirthDateTime: prsBirthDateTime, cmpKind: CS_0024_003C_003E8__locals0.model.CmpKind, cmpTitleId: CS_0024_003C_003E8__locals0.model.CmpTitleId, prsNationalCode: CS_0024_003C_003E8__locals0.model.PrsNationalCode, companyQuickRegisterDefSettingId: CS_0024_003C_003E8__locals0.model.CompanyQuickRegisterDefSettingId, dupCmpId: dupCmpId, dupPrsId: dupPrsId, isCmpDup: objectParameter5, cnvsStatusResultId: CS_0024_003C_003E8__locals0.model.CnvsStatusResultId, centerId: num2);
					_003C_003Ec__DisplayClass38_2.cmpId = 0;
					if (objectParameter.Value != null)
					{
						int.TryParse(objectParameter.Value.ToString(), out _003C_003Ec__DisplayClass38_2.cmpId);
					}
					resultInsertQuickCmpPrsPrjCnvs.CompanyId = _003C_003Ec__DisplayClass38_2.cmpId;
					_003C_003Ec__DisplayClass38_2.prsId = 0;
					if (objectParameter2.Value != null)
					{
						int.TryParse(objectParameter2.Value.ToString(), out _003C_003Ec__DisplayClass38_2.prsId);
					}
					resultInsertQuickCmpPrsPrjCnvs.CompanyPersonId = _003C_003Ec__DisplayClass38_2.prsId;
					_003C_003Ec__DisplayClass38_2.prjId = 0;
					if (objectParameter3.Value != null)
					{
						int.TryParse(objectParameter3.Value.ToString(), out _003C_003Ec__DisplayClass38_2.prjId);
					}
					resultInsertQuickCmpPrsPrjCnvs.ProjectId = _003C_003Ec__DisplayClass38_2.prjId;
					_003C_003Ec__DisplayClass38_2.cnvsId = 0;
					if (objectParameter4.Value != null)
					{
						int.TryParse(objectParameter4.Value.ToString(), out _003C_003Ec__DisplayClass38_2.cnvsId);
					}
					resultInsertQuickCmpPrsPrjCnvs.ConversationId = _003C_003Ec__DisplayClass38_2.cnvsId;
					bool result21 = false;
					if (objectParameter5.Value != null)
					{
						bool.TryParse(objectParameter5.Value.ToString(), out result21);
					}
					if (result21)
					{
						if (dupPrsId == 0 && _003C_003Ec__DisplayClass38_2.prsId > 0)
						{
							using List<Languages>.Enumerator enumerator2 = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator();
							while (enumerator2.MoveNext())
							{
								_003C_003Ec__DisplayClass38_4 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass38_4();
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass38_2;
								CS_0024_003C_003E8__locals1.lang = enumerator2.Current;
								DbSet<CrmCompanyPersons_Lang> crmCompanyPersons_Lang = _dbTbl.CrmCompanyPersons_Lang;
								val = Expression.Parameter(typeof(CrmCompanyPersons_Lang), "c");
								CrmCompanyPersons_Lang crmCompanyPersons_Lang2 = Queryable.FirstOrDefault<CrmCompanyPersons_Lang>((IQueryable<CrmCompanyPersons_Lang>)crmCompanyPersons_Lang, Expression.Lambda<Func<CrmCompanyPersons_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass38_4)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass38_4)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (crmCompanyPersons_Lang2 != null)
								{
									crmCompanyPersons_Lang2.prsLName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									crmCompanyPersons_Lang2.prsFName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									_dbTbl.Entry(crmCompanyPersons_Lang2).State = EntityState.Modified;
									_dbTbl.SaveChanges();
									continue;
								}
								CrmCompanyPersons_Lang entity = new CrmCompanyPersons_Lang
								{
									LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
									CompanyPersonID = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.prsId,
									prsLName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
									prsFName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
									prsSpecialPoint = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list15, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list15, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
									prsDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list16, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list16, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
								};
								_dbTbl.CrmCompanyPersons_Lang.Add(entity);
								_dbTbl.SaveChanges();
							}
						}
						if (list9 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9))
						{
							foreach (Languages item6 in Enumerable.ToList<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get()))
							{
								foreach (CommonMultiLanguageViewModel itemLang in list9)
								{
									if (itemLang.LanguageId != item6.LanguageID)
									{
										continue;
									}
									string text20 = "";
									string text21 = "";
									if (CS_0024_003C_003E8__locals0.model.CmpTitleId.GetValueOrDefault() != 0)
									{
										List<CRMspSelectCompanyTitle_Result> list22 = Enumerable.ToList<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)_db.CRMspSelectCompanyTitle(lCID, CS_0024_003C_003E8__locals0.defLangID));
										if (list22 != null && Enumerable.Any<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)list22))
										{
											CRMspSelectCompanyTitle_Result cRMspSelectCompanyTitle_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)list22, (Func<CRMspSelectCompanyTitle_Result, bool>)((CRMspSelectCompanyTitle_Result m) => m.CompanyTitleID == CS_0024_003C_003E8__locals0.model.CmpTitleId));
											if (cRMspSelectCompanyTitle_Result != null)
											{
												text21 = cRMspSelectCompanyTitle_Result.CompanyTitle ?? "";
												if (!string.IsNullOrWhiteSpace(text21))
												{
													text21 += " ";
												}
											}
										}
									}
									string text22 = "";
									if (CS_0024_003C_003E8__locals0.model.PrsTitleId.GetValueOrDefault() != 0)
									{
										List<CRMspSelectPersonTitle_Result> list23 = Enumerable.ToList<CRMspSelectPersonTitle_Result>((IEnumerable<CRMspSelectPersonTitle_Result>)_db.CRMspSelectPersonTitle(lCID, CS_0024_003C_003E8__locals0.defLangID));
										if (list23 != null && Enumerable.Any<CRMspSelectPersonTitle_Result>((IEnumerable<CRMspSelectPersonTitle_Result>)list23))
										{
											CRMspSelectPersonTitle_Result cRMspSelectPersonTitle_Result = Enumerable.FirstOrDefault<CRMspSelectPersonTitle_Result>((IEnumerable<CRMspSelectPersonTitle_Result>)list23, (Func<CRMspSelectPersonTitle_Result, bool>)((CRMspSelectPersonTitle_Result m) => m.PersonTitleID == CS_0024_003C_003E8__locals0.model.PrsTitleId));
											if (cRMspSelectPersonTitle_Result != null)
											{
												text22 = cRMspSelectPersonTitle_Result.PersonTitle ?? "";
												if (!string.IsNullOrWhiteSpace(text22))
												{
													text22 += " ";
												}
											}
										}
									}
									string text23 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == itemLang.LanguageId)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == itemLang.LanguageId)).Value : "");
									string text24 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == itemLang.LanguageId)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == itemLang.LanguageId)).Value : "");
									if (!string.IsNullOrWhiteSpace(text24))
									{
										text24 += " ";
									}
									string text25 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == itemLang.LanguageId)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == itemLang.LanguageId)).Value : "");
									text20 = "\n\r" + MyResource.GetResourceString("CompanyIQuickRegisterDupCmp", item6.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + text21 + text23 + " (" + text22 + text24 + text25 + ")";
									itemLang.Value += text20;
								}
							}
						}
					}
					else
					{
						if (_003C_003Ec__DisplayClass38_2.cmpId > 0)
						{
							using List<Languages>.Enumerator enumerator2 = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator();
							while (enumerator2.MoveNext())
							{
								_003C_003Ec__DisplayClass38_6 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass38_6();
								CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2 = _003C_003Ec__DisplayClass38_2;
								CS_0024_003C_003E8__locals3.lang = enumerator2.Current;
								DbSet<CrmCompany_Lang> crmCompany_Lang = _dbTbl.CrmCompany_Lang;
								val = Expression.Parameter(typeof(CrmCompany_Lang), "c");
								CrmCompany_Lang crmCompany_Lang2 = Queryable.FirstOrDefault<CrmCompany_Lang>((IQueryable<CrmCompany_Lang>)crmCompany_Lang, Expression.Lambda<Func<CrmCompany_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals3, typeof(_003C_003Ec__DisplayClass38_6)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals3, typeof(_003C_003Ec__DisplayClass38_6)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (crmCompany_Lang2 != null)
								{
									crmCompany_Lang2.cmpAddress = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)).Value : null);
									crmCompany_Lang2.cmpName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)).Value : null);
									_dbTbl.Entry(crmCompany_Lang2).State = EntityState.Modified;
									_dbTbl.SaveChanges();
									continue;
								}
								CrmCompany_Lang entity2 = new CrmCompany_Lang
								{
									LanguageID = CS_0024_003C_003E8__locals3.lang.LanguageID,
									CompanyID = CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.cmpId,
									cmpAddress = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)).Value : null),
									cmpName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)).Value : null),
									cmpActivityType = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)).Value : null),
									cmpSpecialPoint = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)).Value : null),
									cmpDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals3.lang.LanguageID)).Value : null)
								};
								_dbTbl.CrmCompany_Lang.Add(entity2);
								_dbTbl.SaveChanges();
							}
						}
						if (_003C_003Ec__DisplayClass38_2.prsId > 0)
						{
							using List<Languages>.Enumerator enumerator2 = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator();
							while (enumerator2.MoveNext())
							{
								_003C_003Ec__DisplayClass38_7 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass38_7();
								CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals3 = _003C_003Ec__DisplayClass38_2;
								CS_0024_003C_003E8__locals4.lang = enumerator2.Current;
								DbSet<CrmCompanyPersons_Lang> crmCompanyPersons_Lang3 = _dbTbl.CrmCompanyPersons_Lang;
								val = Expression.Parameter(typeof(CrmCompanyPersons_Lang), "c");
								CrmCompanyPersons_Lang crmCompanyPersons_Lang4 = Queryable.FirstOrDefault<CrmCompanyPersons_Lang>((IQueryable<CrmCompanyPersons_Lang>)crmCompanyPersons_Lang3, Expression.Lambda<Func<CrmCompanyPersons_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals4, typeof(_003C_003Ec__DisplayClass38_7)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals4, typeof(_003C_003Ec__DisplayClass38_7)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (crmCompanyPersons_Lang4 != null)
								{
									crmCompanyPersons_Lang4.prsLName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals4.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals4.lang.LanguageID)).Value : null);
									crmCompanyPersons_Lang4.prsFName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals4.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals4.lang.LanguageID)).Value : null);
									_dbTbl.Entry(crmCompanyPersons_Lang4).State = EntityState.Modified;
									_dbTbl.SaveChanges();
									continue;
								}
								CrmCompanyPersons_Lang entity3 = new CrmCompanyPersons_Lang
								{
									LanguageID = CS_0024_003C_003E8__locals4.lang.LanguageID,
									CompanyPersonID = CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals3.prsId,
									prsLName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals4.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals4.lang.LanguageID)).Value : null),
									prsFName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals4.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals4.lang.LanguageID)).Value : null),
									prsSpecialPoint = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list15, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals4.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list15, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals4.lang.LanguageID)).Value : null),
									prsDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list16, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals4.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list16, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals4.lang.LanguageID)).Value : null)
								};
								_dbTbl.CrmCompanyPersons_Lang.Add(entity3);
								_dbTbl.SaveChanges();
							}
						}
					}
					if (_003C_003Ec__DisplayClass38_2.prjId > 0)
					{
						using List<Languages>.Enumerator enumerator2 = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator();
						while (enumerator2.MoveNext())
						{
							_003C_003Ec__DisplayClass38_8 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass38_8();
							CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals4 = _003C_003Ec__DisplayClass38_2;
							CS_0024_003C_003E8__locals5.lang = enumerator2.Current;
							DbSet<CrmProjects_Lang> crmProjects_Lang = _dbTbl.CrmProjects_Lang;
							val = Expression.Parameter(typeof(CrmProjects_Lang), "c");
							CrmProjects_Lang crmProjects_Lang2 = Queryable.FirstOrDefault<CrmProjects_Lang>((IQueryable<CrmProjects_Lang>)crmProjects_Lang, Expression.Lambda<Func<CrmProjects_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals5, typeof(_003C_003Ec__DisplayClass38_8)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals5, typeof(_003C_003Ec__DisplayClass38_8)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (crmProjects_Lang2 != null)
							{
								crmProjects_Lang2.prjTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals5.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals5.lang.LanguageID)).Value : null);
								crmProjects_Lang2.prjPostFix = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals5.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals5.lang.LanguageID)).Value : null);
								crmProjects_Lang2.prjDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals5.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals5.lang.LanguageID)).Value : null);
								_dbTbl.Entry(crmProjects_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							crmProjects_Lang2 = new CrmProjects_Lang
							{
								LanguageID = CS_0024_003C_003E8__locals5.lang.LanguageID,
								ProjectID = CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals4.prjId,
								prjTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals5.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals5.lang.LanguageID)).Value : null),
								prjPostFix = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals5.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals5.lang.LanguageID)).Value : null),
								prjDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals5.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals5.lang.LanguageID)).Value : null),
								prjSubject = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list17, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals5.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list17, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals5.lang.LanguageID)).Value : null),
								prjTitleGroup = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list18, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals5.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list18, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals5.lang.LanguageID)).Value : null),
								prjDescI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list19, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals5.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list19, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals5.lang.LanguageID)).Value : null)
							};
							_dbTbl.CrmProjects_Lang.Add(crmProjects_Lang2);
							_dbTbl.SaveChanges();
						}
					}
					if (_003C_003Ec__DisplayClass38_2.cnvsId > 0)
					{
						using List<Languages>.Enumerator enumerator2 = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator();
						while (enumerator2.MoveNext())
						{
							_003C_003Ec__DisplayClass38_9 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass38_9();
							CS_0024_003C_003E8__locals6.CS_0024_003C_003E8__locals5 = _003C_003Ec__DisplayClass38_2;
							CS_0024_003C_003E8__locals6.lang = enumerator2.Current;
							DbSet<CrmConversation_Lang> crmConversation_Lang = _dbTbl.CrmConversation_Lang;
							val = Expression.Parameter(typeof(CrmConversation_Lang), "c");
							CrmConversation_Lang crmConversation_Lang2 = Queryable.FirstOrDefault<CrmConversation_Lang>((IQueryable<CrmConversation_Lang>)crmConversation_Lang, Expression.Lambda<Func<CrmConversation_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals6, typeof(_003C_003Ec__DisplayClass38_9)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals6, typeof(_003C_003Ec__DisplayClass38_9)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (crmConversation_Lang2 != null)
							{
								crmConversation_Lang2.cnvsDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals6.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals6.lang.LanguageID)).Value : null);
								crmConversation_Lang2.cnvsReferDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals6.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals6.lang.LanguageID)).Value : null);
								_dbTbl.Entry(crmConversation_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							crmConversation_Lang2 = new CrmConversation_Lang
							{
								LanguageID = CS_0024_003C_003E8__locals6.lang.LanguageID,
								ConversationID = CS_0024_003C_003E8__locals6.CS_0024_003C_003E8__locals5.cnvsId,
								cnvsDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals6.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals6.lang.LanguageID)).Value : null),
								cnvsReferDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals6.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals6.lang.LanguageID)).Value : null)
							};
							_dbTbl.CrmConversation_Lang.Add(crmConversation_Lang2);
							_dbTbl.SaveChanges();
						}
					}
					if (_003C_003Ec__DisplayClass38_2.cnvsId > 0)
					{
						resultInsertQuickCmpPrsPrjCnvs.IsDone = true;
						resultInsertQuickCmpPrsPrjCnvs.Message = Messages.msgSuccessAction;
					}
					if (CS_0024_003C_003E8__locals0.model.CnvsStatusResultId.HasValue && _003C_003Ec__DisplayClass38_2.cnvsId > 0)
					{
						CRMspSelectConversationStatusResultById_Result cRMspSelectConversationStatusResultById_Result2 = Enumerable.FirstOrDefault<CRMspSelectConversationStatusResultById_Result>((IEnumerable<CRMspSelectConversationStatusResultById_Result>)_dbI.CRMspSelectConversationStatusResultById(CS_0024_003C_003E8__locals0.model.CnvsStatusResultId, lCID, CS_0024_003C_003E8__locals0.defLangID));
						if (cRMspSelectConversationStatusResultById_Result2 != null)
						{
							DateTime now2 = DateTime.Now;
							DateTime value4 = now2;
							string registerDatePersian = now2.ToString("yyyyMMdd", new PersianCulture());
							short value5 = short.Parse(now2.ToString("MM", new PersianCulture()));
							string appType3 = Configuration.AppType;
							short value6 = short.Parse(Financial.Get().Id.ToString());
							int userId4 = UserLogin.CurrentUser.UserId;
							string conversationErjaShow = Messages.ConversationErjaShow;
							bool result22 = false;
							bool.TryParse(cRMspSelectConversationStatusResultById_Result2.EventPolicyActive.ToString(), out result22);
							string text26 = "";
							string surveyMainExtrenalLinkLogin = "";
							string surveyMainExtrenalLink = "";
							Uri url = base.HttpContext.Request.Url;
							string text27 = url.Scheme + "://" + url.Authority;
							if (text27.EndsWith("/"))
							{
								text27 = text27.TrimEnd(new char[1] { '/' });
							}
							text27 += "/Survey/Home/SurveyAnswerValues";
							text26 = text27;
							string text28 = "";
							string text29 = "";
							string text30 = "";
							if (cRMspSelectCrmsysSetting_Result != null)
							{
								text29 = cRMspSelectCrmsysSetting_Result.FOUrl ?? "";
								text30 = cRMspSelectCrmsysSetting_Result.CrmIPStatic ?? "";
							}
							if (!string.IsNullOrWhiteSpace(text29))
							{
								text28 = text29.Trim();
								if (!text28.Contains("http"))
								{
									text28 = url.Scheme + "://" + text28;
								}
								if (text28.EndsWith("/"))
								{
									text28 = text28.TrimEnd(new char[1] { '/' });
								}
								text28 += "/Survey/Home";
								surveyMainExtrenalLinkLogin = text28;
							}
							if (!string.IsNullOrWhiteSpace(text30))
							{
								text28 = text30.Trim();
								if (!text28.Contains("http"))
								{
									text28 = url.Scheme + "://" + text28;
								}
								if (text28.EndsWith("/"))
								{
									text28 = text28.TrimEnd(new char[1] { '/' });
								}
								text28 += "/Survey/Register/Index";
								surveyMainExtrenalLink = text28;
							}
							int maxFOCount = Configuration.MaxFOCount;
							ObjectParameter objectParameter6 = new ObjectParameter("ResultJson", "");
							_dbI.CRMspCnvsStatusResultEventExecute(_003C_003Ec__DisplayClass38_2.cnvsId, "", null, false, text26, surveyMainExtrenalLink, surveyMainExtrenalLinkLogin, conversationErjaShow, "", userId4, value6, value5, value4, registerDatePersian, appType3, lCID, CS_0024_003C_003E8__locals0.defLangID, objectParameter6, num2, maxFOCount);
							string text31 = "";
							string text32 = "";
							if (objectParameter6 != null && objectParameter6.Value != null && !string.IsNullOrWhiteSpace(objectParameter6.Value.ToString()))
							{
								List<CRMspRunCnvsStatusResultEventPolicyViewModel> list24 = new JavaScriptSerializer().Deserialize<List<CRMspRunCnvsStatusResultEventPolicyViewModel>>(objectParameter6.Value.ToString());
								if (list24 != null && Enumerable.Any<CRMspRunCnvsStatusResultEventPolicyViewModel>((IEnumerable<CRMspRunCnvsStatusResultEventPolicyViewModel>)list24) && Enumerable.FirstOrDefault<CRMspRunCnvsStatusResultEventPolicyViewModel>((IEnumerable<CRMspRunCnvsStatusResultEventPolicyViewModel>)list24, (Func<CRMspRunCnvsStatusResultEventPolicyViewModel, bool>)((CRMspRunCnvsStatusResultEventPolicyViewModel m) => m.EventPolicyTypeId.GetValueOrDefault() == 14 && (m.EventPolicyShortText ?? "") == "FOCountModule")) != null)
								{
									string companyNameWithTitle = CRMIdeal.Classes.Helper.Company.GetCompanyNameWithTitle(_003C_003Ec__DisplayClass38_2.cmpId);
									text32 = "<br>" + string.Format(Messages.msgLackCapacityCmpFoNotActive, companyNameWithTitle);
									list24 = Enumerable.ToList<CRMspRunCnvsStatusResultEventPolicyViewModel>(Enumerable.Where<CRMspRunCnvsStatusResultEventPolicyViewModel>((IEnumerable<CRMspRunCnvsStatusResultEventPolicyViewModel>)list24, (Func<CRMspRunCnvsStatusResultEventPolicyViewModel, bool>)((CRMspRunCnvsStatusResultEventPolicyViewModel m) => m.EventPolicyTypeId.GetValueOrDefault() != 14 && (m.EventPolicyShortText ?? "") != "FOCountModule")));
								}
								if (list24 != null && Enumerable.Any<CRMspRunCnvsStatusResultEventPolicyViewModel>((IEnumerable<CRMspRunCnvsStatusResultEventPolicyViewModel>)list24))
								{
									CRMspRunCnvsStatusResultEventPolicyViewModel cRMspRunCnvsStatusResultEventPolicyViewModel = Enumerable.FirstOrDefault<CRMspRunCnvsStatusResultEventPolicyViewModel>((IEnumerable<CRMspRunCnvsStatusResultEventPolicyViewModel>)list24, (Func<CRMspRunCnvsStatusResultEventPolicyViewModel, bool>)((CRMspRunCnvsStatusResultEventPolicyViewModel m) => (m.MessageError ?? "") != ""));
									if (cRMspRunCnvsStatusResultEventPolicyViewModel != null)
									{
										text31 = cRMspRunCnvsStatusResultEventPolicyViewModel.MessageError ?? "";
									}
								}
							}
							if (!string.IsNullOrWhiteSpace(text31))
							{
								string message = Messages.msgErrorRunFunction + "<br>" + text31;
								resultInsertQuickCmpPrsPrjCnvs.IsDone = false;
								resultInsertQuickCmpPrsPrjCnvs.Message = message;
							}
							else
							{
								resultInsertQuickCmpPrsPrjCnvs.IsDone = true;
								resultInsertQuickCmpPrsPrjCnvs.Message = Messages.msgSuccessAction + text32;
							}
						}
						else
						{
							resultInsertQuickCmpPrsPrjCnvs.IsDone = true;
							resultInsertQuickCmpPrsPrjCnvs.Message = Messages.msgSuccessAction;
						}
					}
					else
					{
						resultInsertQuickCmpPrsPrjCnvs.IsDone = true;
						resultInsertQuickCmpPrsPrjCnvs.Message = Messages.msgSuccessAction;
					}
					if (CS_0024_003C_003E8__locals0.model.IsPrj.GetValueOrDefault() != 1 && _003C_003Ec__DisplayClass38_2.cmpId > 0 && _003C_003Ec__DisplayClass38_2.prsId > 0 && !string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.model.PrsMobile))
					{
						_db.CRMspAutoSendSMSAfterSaveMobile(_003C_003Ec__DisplayClass38_2.cmpId, _003C_003Ec__DisplayClass38_2.prsId, CS_0024_003C_003E8__locals0.model.PrsMobile, userId, appType, CS_0024_003C_003E8__locals0.defLangID, 0, (num2 != 0) ? num2 : null);
					}
					if (result21 && resultInsertQuickCmpPrsPrjCnvs.IsDone)
					{
						resultInsertQuickCmpPrsPrjCnvs.Message = Messages.msgCompanyIQuickRegisterDupCmpByPrjAndCnvs;
					}
					if (_003C_003Ec__DisplayClass38_2.cmpId != 0)
					{
						string errorMsg = "";
						if (!CRMIdeal.Classes.Helper.OtherSystems.SendCmpToLinkAccByShpIsActive(_003C_003Ec__DisplayClass38_2.cmpId, num2.GetValueOrDefault(), ref errorMsg))
						{
							int result23 = 0;
							string text33 = "";
							if (cRMspSelectCrmsysSetting_Result != null)
							{
								int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result23);
							}
							text33 = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
							if (result21 && resultInsertQuickCmpPrsPrjCnvs.IsDone)
							{
								resultInsertQuickCmpPrsPrjCnvs.Message = Messages.msgCompanyIQuickRegisterDupCmpByPrjAndCnvs + "<br>" + string.Format(Messages.msgErrorSendCmpToOtherSystem, text33) + "<br>" + errorMsg;
							}
						}
					}
					PushNotif.NewIntMsgNotify();
				}
			}
			else
			{
				resultInsertQuickCmpPrsPrjCnvs.IsDone = false;
				resultInsertQuickCmpPrsPrjCnvs.Message = Messages.msgNotFound;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			resultInsertQuickCmpPrsPrjCnvs.IsDone = false;
			resultInsertQuickCmpPrsPrjCnvs.Message = Messages.msgErrorRunFunction + "<br>" + ex.Message;
		}
		return Json(resultInsertQuickCmpPrsPrjCnvs, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public int RunCnvsEventPolicyForSms(int cnvsId, int statusId, int prjId, int cmpId, int prsId, bool eventPolicyNeedCheck)
	{
		int result = -1;
		try
		{
			if (cnvsId > 0)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
				if (result2 <= 0)
				{
					result2 = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				DateTime now = DateTime.Now;
				string text = now.ToString("yyyyMMdd", new PersianCulture());
				short value = short.Parse(Financial.Get().Id.ToString());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				int? centerId = null;
				if (UserLogin.CurrentUser != null)
				{
					centerId = UserLogin.CurrentUser.UserLastCId;
				}
				ObjectParameter objectParameter = new ObjectParameter("Result", 0);
				_dbI.CRMspRunCnvsEventPolicy(cnvsId, statusId, prjId, cmpId, prsId, text, UserLogin.CurrentUser.UserId, value, value2, text, appType, result2, eventPolicyNeedCheck, objectParameter, lCID, centerId);
				if (objectParameter != null)
				{
					result = ((!(objectParameter.Value.ToString() == "0") && !(objectParameter.Value.ToString() == "-1")) ? 1 : 0);
				}
			}
			else
			{
				result = -1;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = -1;
		}
		return result;
	}

	[AjaxOnly]
	public JsonResult ActPrjEdit(CrmCmpPrsPrjCnvsLanguageViewModel model)
	{
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0280: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		ResultInsertQuickCmpPrsPrjCnvs resultInsertQuickCmpPrsPrjCnvs = new ResultInsertQuickCmpPrsPrjCnvs();
		int num = 0;
		string text = "";
		try
		{
			int result = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
			}
			if (!UserLogin.IsUserAccess("frmCompanyIQuickRegister", "actPrjEdit", UserLogin.CurrentUser))
			{
				resultInsertQuickCmpPrsPrjCnvs.IsDone = false;
				resultInsertQuickCmpPrsPrjCnvs.Message = Messages.ErrorNotAccess;
				return Json(resultInsertQuickCmpPrsPrjCnvs, JsonRequestBehavior.AllowGet);
			}
			if (UserLogin.IsUserAccess("frmCompanyI", "actNotCanEditNoReferUserPrj", UserLogin.CurrentUser))
			{
				CRMspSelectCompanyProjectByCmpOrPrjId_Result cRMspSelectCompanyProjectByCmpOrPrjId_Result = SelectProject(model.CompanyPersonId, model.ProjectId);
				if (cRMspSelectCompanyProjectByCmpOrPrjId_Result != null && cRMspSelectCompanyProjectByCmpOrPrjId_Result.prjStarterUserId != UserLogin.CurrentUser.UserId)
				{
					resultInsertQuickCmpPrsPrjCnvs.IsDone = false;
					resultInsertQuickCmpPrsPrjCnvs.Message = Messages.msgNotCanEditPrjWithoutBeReferUser;
					return Json(resultInsertQuickCmpPrsPrjCnvs, JsonRequestBehavior.AllowGet);
				}
			}
			if (model != null)
			{
				_003C_003Ec__DisplayClass40_1 _003C_003Ec__DisplayClass40_ = new _003C_003Ec__DisplayClass40_1();
				DateTime now = DateTime.Now;
				_ = Labels.PersonLabel;
				int userId = UserLogin.CurrentUser.UserId;
				DateTime value = now;
				string text2 = now.ToString("yyyyMMdd", new PersianCulture());
				short.Parse(Financial.Get().Id.ToString());
				short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
				_ = Messages.MobConversationErjaShow;
				_ = Configuration.AppType;
				DateTimeClass.DefineDayeOfWeekStartWith7(now.DayOfWeek.ToString());
				now.ToString("HH:mm:ss");
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.PrjTitle_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.PrjTitle_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = model.PrjTitle,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.PrjPostFix_Lang))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.PrjPostFix_Lang);
				}
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = model.PrjPostFix,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.PrjDesc_Lang))
				{
					list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.PrjDesc_Lang);
				}
				list3.Add(new CommonMultiLanguageViewModel
				{
					Value = model.PrjDesc,
					LanguageId = lCID
				});
				_003C_003Ec__DisplayClass40_.setId = 0;
				int.TryParse(SysSeting.Get().ID.ToString(), out _003C_003Ec__DisplayClass40_.setId);
				DbSet<CrmsysSetting> crmsysSetting = _dbTbl.CrmsysSetting;
				ParameterExpression val = Expression.Parameter(typeof(CrmsysSetting), "m");
				CrmsysSetting crmsysSetting2 = Queryable.FirstOrDefault<CrmsysSetting>((IQueryable<CrmsysSetting>)crmsysSetting, Expression.Lambda<Func<CrmsysSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass40_, typeof(_003C_003Ec__DisplayClass40_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (crmsysSetting2 != null)
				{
					if (crmsysSetting2.cmpQNotNullProjectGroup.HasValue)
					{
						_ = crmsysSetting2.cmpQNotNullProjectGroup == false;
					}
					if (crmsysSetting2.cmpQNotNullProjectGrade.HasValue)
					{
						_ = crmsysSetting2.cmpQNotNullProjectGrade == false;
					}
					if (crmsysSetting2.cmpQNotNullProjectPriority.HasValue)
					{
						_ = crmsysSetting2.cmpQNotNullProjectPriority == false;
					}
				}
				if (string.IsNullOrEmpty(model.PrjTitle))
				{
					num++;
					text = text + string.Format(Messages.msgErrorIsNotEntered, Labels.CompanyIIPrjTitle) + "<br>";
				}
				else if (!checkMultiLanguage(model.PrjTitle, list))
				{
					num++;
					text = text + string.Format(Messages.CheckFieldInLang, Labels.CompanyIIPrjTitle) + "<br>";
				}
				if (!model.PrjGroupId.HasValue)
				{
					num++;
					text = text + string.Format(Messages.msgErrorIsNotEntered, Labels.CompanyIIPrjGroup) + "<br>";
				}
				if (!model.PrjGradeId.HasValue)
				{
					num++;
					text = text + string.Format(Messages.msgErrorIsNotEntered, Labels.CompanyIIPrjGrade) + "<br>";
				}
				if (!model.PrjPriorityId.HasValue)
				{
					num++;
					text = text + string.Format(Messages.msgErrorIsNotEntered, Labels.CompanyIIPrjPriority) + "<br>";
				}
				List<CRMspSelectsysDBObjectsNotNull_Result> list4 = Enumerable.ToList<CRMspSelectsysDBObjectsNotNull_Result>((IEnumerable<CRMspSelectsysDBObjectsNotNull_Result>)_db.CRMspSelectsysDBObjectsNotNull("CrmProjects", lCID, defLangID));
				if (list4 != null && Enumerable.Any<CRMspSelectsysDBObjectsNotNull_Result>((IEnumerable<CRMspSelectsysDBObjectsNotNull_Result>)list4))
				{
					using List<CRMspSelectsysDBObjectsNotNull_Result>.Enumerator enumerator = list4.GetEnumerator();
					while (enumerator.MoveNext())
					{
						switch (enumerator.Current.FieldName)
						{
						case "prjTitle":
							if (string.IsNullOrWhiteSpace(model.PrjTitle))
							{
								text = text + string.Format(Messages.ErrorEmpty, Labels.prjTitle) + "<br/>";
								num++;
							}
							else if (!checkMultiLanguage(model.PrjTitle, list))
							{
								text = text + string.Format(Messages.CheckFieldInLang, Labels.prjTitle) + "<br>";
								num++;
							}
							break;
						case "prjDesc":
							if (string.IsNullOrWhiteSpace(model.PrjDesc))
							{
								text = text + string.Format(Messages.ErrorEmpty, Labels.prjDesc) + "<br/>";
								num++;
							}
							else if (!checkMultiLanguage(model.PrjDesc, list3))
							{
								text = text + string.Format(Messages.CheckFieldInLang, Labels.prjDesc) + "<br>";
								num++;
							}
							break;
						case "prjGradeId":
							if (!model.PrjGradeId.HasValue)
							{
								text = text + string.Format(Messages.ErrorEmpty, Labels.prjGradeId) + "<br/>";
								num++;
							}
							break;
						case "prjPriorityId":
							if (!model.PrjPriorityId.HasValue)
							{
								text = text + string.Format(Messages.ErrorEmpty, Labels.prjPriorityId) + "<br/>";
								num++;
							}
							break;
						case "prjGroupId":
							if (!model.PrjGroupId.HasValue)
							{
								text = text + string.Format(Messages.ErrorEmpty, Labels.prjGroupId) + "<br/>";
								num++;
							}
							break;
						case "prjcnvsStatusGroupId":
							if (!model.DefProjectGroupId.HasValue)
							{
								text = text + string.Format(Messages.ErrorEmpty, Labels.prjcnvsStatusGroupId) + "<br/>";
								num++;
							}
							break;
						case "prjPostFix":
							if (string.IsNullOrWhiteSpace(model.PrjPostFix))
							{
								text = text + string.Format(Messages.ErrorEmpty, Labels.prjPostFix) + "<br/>";
								num++;
							}
							else if (!checkMultiLanguage(model.PrjPostFix, list2))
							{
								text = text + string.Format(Messages.CheckFieldInLang, Labels.prjPostFix) + "<br>";
								num++;
							}
							break;
						case "prjRemindDate":
							if (string.IsNullOrWhiteSpace(model.PrjRemindDate))
							{
								text = text + string.Format(Messages.ErrorEmpty, Labels.prjRemindDate) + "<br/>";
								num++;
							}
							break;
						}
					}
				}
				DateTime? prjStartDateTime = DateTime.Now;
				DateTime? prjRemindDateTime = DateTime.Now;
				DateTime dateTime = default(DateTime);
				string text3 = "";
				try
				{
					if (!string.IsNullOrEmpty(model.PrjStartDate))
					{
						text3 = PersianDate.GetFormatetdDate(model.PrjStartDate.Replace("/", ""));
						switch (lCID)
						{
						case 1065:
							dateTime = DateTime.Parse(text3 + " " + now.ToString("HH:mm:ss"), new PersianCulture());
							model.PrjStartDate = dateTime.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime = DateTime.Parse(text3 + " " + now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
							model.PrjStartDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime = DateTime.Parse(text3 + " " + now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
							model.PrjStartDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						prjStartDateTime = dateTime;
					}
					else
					{
						prjStartDateTime = value;
						model.PrjStartDate = text2;
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					num++;
					text = text + string.Format(Messages.ErrorInFormat, Labels.CompanyIIPrjStartDate) + "<br>";
				}
				dateTime = default(DateTime);
				text3 = "";
				try
				{
					if (!string.IsNullOrEmpty(model.PrjRemindDate))
					{
						text3 = PersianDate.GetFormatetdDate(model.PrjRemindDate.Replace("/", ""));
						switch (lCID)
						{
						case 1065:
							dateTime = DateTime.Parse(text3 + " " + now.ToString("HH:mm:ss"), new PersianCulture());
							model.PrjRemindDate = dateTime.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime = DateTime.Parse(text3 + " " + now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
							model.PrjRemindDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime = DateTime.Parse(text3 + " " + now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
							model.PrjRemindDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						prjRemindDateTime = dateTime;
					}
					else
					{
						prjRemindDateTime = value;
						model.PrjRemindDate = text2;
					}
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
					num++;
					text = text + string.Format(Messages.ErrorInFormat, Labels.CompanyIIPrjRemindDate) + "<br>";
				}
				if (list != null)
				{
					string text4 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					if (!string.IsNullOrEmpty(text4))
					{
						bool flag = UserLogin.IsUserAccess("frmDefineProjects", "actCanSaveNewTitleWithoutDefine", UserLogin.CurrentUser);
						if (Enumerable.FirstOrDefault<CRMspSelectCompanyProjectTitle_Result>((IEnumerable<CRMspSelectCompanyProjectTitle_Result>)_db.CRMspSelectCompanyProjectTitle(text4, userId, lCID, defLangID, result)) == null && !flag)
						{
							text = text + Messages.prjMsgNotAccessDefinePrjTitle + "<br>";
							num++;
						}
					}
				}
				if (list2 != null)
				{
					string text5 = "";
					foreach (CommonMultiLanguageViewModel item in list2)
					{
						if (!string.IsNullOrEmpty(item.Value) && string.IsNullOrEmpty(text5))
						{
							text5 = CantSaveDupPrjPostFix(item.Value, model.ProjectId);
						}
					}
					if (!string.IsNullOrEmpty(text5))
					{
						num++;
						text = text + text5 + "<br>";
					}
				}
				if (list3 != null)
				{
					string text6 = "";
					foreach (CommonMultiLanguageViewModel item2 in list3)
					{
						if (!string.IsNullOrEmpty(item2.Value) && string.IsNullOrEmpty(text6))
						{
							text6 = CantSaveDupPrjDesc(item2.Value, model.ProjectId);
						}
					}
					if (!string.IsNullOrEmpty(text6))
					{
						num++;
						text = text + text6 + "<br>";
					}
				}
				if (num > 0)
				{
					resultInsertQuickCmpPrsPrjCnvs.IsDone = false;
					resultInsertQuickCmpPrsPrjCnvs.Message = text;
				}
				else
				{
					_003C_003Ec__DisplayClass40_2 _003C_003Ec__DisplayClass40_2 = new _003C_003Ec__DisplayClass40_2();
					string prjTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					string prjPostFix = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					string prjDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					string prjStartDay = DateTimeClass.DefineDayeOfWeekStartWith7(prjStartDateTime.Value.DayOfWeek.ToString());
					string prjStartTime = prjStartDateTime.Value.ToString("HH:mm:ss");
					_db.CRMspUpdateQuickCmpPrsProjectByPrjId(model.ProjectId, prjTitle, prjPostFix, model.PrjGroupId, model.PrjGradeId, model.PrjPriorityId, model.PrjRemindDate, prjRemindDateTime, model.PrjStartDate, prjStartDay, prjStartTime, prjStartDateTime, userId, prjDesc);
					_003C_003Ec__DisplayClass40_2.prjId = model.ProjectId;
					if (_003C_003Ec__DisplayClass40_2.prjId > 0)
					{
						using List<Languages>.Enumerator enumerator3 = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))).GetEnumerator();
						while (enumerator3.MoveNext())
						{
							_003C_003Ec__DisplayClass40_3 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass40_3();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass40_2;
							CS_0024_003C_003E8__locals1.lang = enumerator3.Current;
							DbSet<CrmProjects_Lang> crmProjects_Lang = _dbTbl.CrmProjects_Lang;
							val = Expression.Parameter(typeof(CrmProjects_Lang), "c");
							CrmProjects_Lang crmProjects_Lang2 = Queryable.FirstOrDefault<CrmProjects_Lang>((IQueryable<CrmProjects_Lang>)crmProjects_Lang, Expression.Lambda<Func<CrmProjects_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass40_3)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass40_3)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (crmProjects_Lang2 != null)
							{
								crmProjects_Lang2.prjTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmProjects_Lang2.prjPostFix = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmProjects_Lang2.prjDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(crmProjects_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							crmProjects_Lang2 = new CrmProjects_Lang
							{
								LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
								ProjectID = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.prjId,
								prjTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
								prjPostFix = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
								prjDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
							};
							_dbTbl.CrmProjects_Lang.Add(crmProjects_Lang2);
							_dbTbl.SaveChanges();
						}
					}
					resultInsertQuickCmpPrsPrjCnvs.IsDone = true;
					resultInsertQuickCmpPrsPrjCnvs.Message = Messages.msgSuccessUpdateAction;
				}
			}
			else
			{
				resultInsertQuickCmpPrsPrjCnvs.IsDone = false;
				resultInsertQuickCmpPrsPrjCnvs.Message = Messages.msgNotFound;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			resultInsertQuickCmpPrsPrjCnvs.IsDone = false;
			resultInsertQuickCmpPrsPrjCnvs.Message = Messages.msgErrorRunFunction + "<br>" + ex.Message;
		}
		return Json(resultInsertQuickCmpPrsPrjCnvs, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	public ActionResult CmpQRSetDefaultSetting()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		CmpQRSetDefaultSettingViewModel cmpQRSetDefaultSettingViewModel = new CmpQRSetDefaultSettingViewModel();
		try
		{
			_003C_003Ec__DisplayClass41_0 _003C_003Ec__DisplayClass41_ = new _003C_003Ec__DisplayClass41_0();
			_003C_003Ec__DisplayClass41_.setId = 0;
			int.TryParse(SysSeting.Get().ID.ToString(), out _003C_003Ec__DisplayClass41_.setId);
			DbSet<CrmsysSetting> crmsysSetting = _dbTbl.CrmsysSetting;
			ParameterExpression val = Expression.Parameter(typeof(CrmsysSetting), "m");
			CrmsysSetting crmsysSetting2 = Queryable.FirstOrDefault<CrmsysSetting>((IQueryable<CrmsysSetting>)crmsysSetting, Expression.Lambda<Func<CrmsysSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass41_, typeof(_003C_003Ec__DisplayClass41_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmsysSetting2 != null)
			{
				cmpQRSetDefaultSettingViewModel.cmpQDefCountryId = crmsysSetting2.cmpQDefCountryId;
				cmpQRSetDefaultSettingViewModel.cmpQDefProjectTitle = crmsysSetting2.cmpQDefProjectTitle;
				cmpQRSetDefaultSettingViewModel.cmpQDefProjectGroupId = crmsysSetting2.cmpQDefProjectGroupId;
				cmpQRSetDefaultSettingViewModel.cmpQDefcnvsTopicId = crmsysSetting2.cmpQDefcnvsTopicId;
				cmpQRSetDefaultSettingViewModel.cmpQNotNullProjectGroup = crmsysSetting2.cmpQNotNullProjectGroup;
				cmpQRSetDefaultSettingViewModel.cmpQNotNullProjectGrade = crmsysSetting2.cmpQNotNullProjectGrade;
				cmpQRSetDefaultSettingViewModel.cmpQNotNullProjectPriority = crmsysSetting2.cmpQNotNullProjectPriority;
				cmpQRSetDefaultSettingViewModel.cmpQDefPrintAfterSave = crmsysSetting2.cmpQDefPrintAfterSave;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		GetCountry();
		GetCnvsTopics();
		GetPrjStatusGroups();
		return View(cmpQRSetDefaultSettingViewModel);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	public ActionResult CmpQRSetDefaultSetting(CmpQRSetDefaultSettingViewModel model)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		GetCountry();
		GetCnvsTopics();
		GetPrjStatusGroups();
		string text = "";
		if (base.ModelState.IsValid)
		{
			try
			{
				_003C_003Ec__DisplayClass42_0 _003C_003Ec__DisplayClass42_ = new _003C_003Ec__DisplayClass42_0();
				DateTime now = DateTime.Now;
				int userId = UserLogin.CurrentUser.UserId;
				DateTime value = now;
				now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(Financial.Get().Id.ToString());
				short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				_003C_003Ec__DisplayClass42_.setId = 0;
				int.TryParse(SysSeting.Get().ID.ToString(), out _003C_003Ec__DisplayClass42_.setId);
				DbSet<CrmsysSetting> crmsysSetting = _dbTbl.CrmsysSetting;
				ParameterExpression val = Expression.Parameter(typeof(CrmsysSetting), "m");
				CrmsysSetting crmsysSetting2 = Queryable.FirstOrDefault<CrmsysSetting>((IQueryable<CrmsysSetting>)crmsysSetting, Expression.Lambda<Func<CrmsysSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass42_, typeof(_003C_003Ec__DisplayClass42_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (crmsysSetting2 != null)
				{
					crmsysSetting2.cmpQDefCountryId = model.cmpQDefCountryId;
					crmsysSetting2.cmpQDefProjectTitle = model.cmpQDefProjectTitle;
					crmsysSetting2.cmpQDefProjectGroupId = model.cmpQDefProjectGroupId;
					crmsysSetting2.cmpQDefcnvsTopicId = model.cmpQDefcnvsTopicId;
					crmsysSetting2.cmpQNotNullProjectGroup = model.cmpQNotNullProjectGroup;
					crmsysSetting2.cmpQNotNullProjectGrade = model.cmpQNotNullProjectGrade;
					crmsysSetting2.cmpQNotNullProjectPriority = model.cmpQNotNullProjectPriority;
					crmsysSetting2.cmpQDefPrintAfterSave = model.cmpQDefPrintAfterSave;
					crmsysSetting2.UserId = userId;
					crmsysSetting2.RegisterDate = value;
					crmsysSetting2.Month1 = value3;
					crmsysSetting2.Year1 = value2;
					crmsysSetting2.AppType = appType;
					_dbTbl.Entry(crmsysSetting2).State = EntityState.Modified;
					_dbTbl.SaveChanges();
					if (SysSeting.Update())
					{
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					}
					else
					{
						text = Messages.ErrorInCacheUpdate;
					}
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				text = Messages.msgErrorRunFunction;
			}
		}
		if (text != "")
		{
			base.ViewBag.Error = text;
		}
		return View(model);
	}

	[AjaxOnly]
	public JsonResult GetCompanyQuickRegisterDefSetting()
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
			List<CRMspSelectCompanyQuickRegisterDefSettingUserAccess_Result> list2 = Enumerable.ToList<CRMspSelectCompanyQuickRegisterDefSettingUserAccess_Result>((IEnumerable<CRMspSelectCompanyQuickRegisterDefSettingUserAccess_Result>)_dbIII.CRMspSelectCompanyQuickRegisterDefSettingUserAccess((short)1, UserLogin.CurrentUser.UserId, lCID, result));
			int? defaultSetting = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbIII.CRMspSelectCompanyQuickRegisterDefSettingIsDefUserAccess((short)1, UserLogin.CurrentUser.UserId, lCID, result));
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyQuickRegisterDefSettingUserAccess_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyQuickRegisterDefSettingUserAccess_Result>)list2, (Func<CRMspSelectCompanyQuickRegisterDefSettingUserAccess_Result, SelectListItem>)((CRMspSelectCompanyQuickRegisterDefSettingUserAccess_Result item) => new SelectListItem
			{
				Text = item.SettingTitle,
				Value = item.CompanyQuickRegisterDefSettingId.ToString(),
				Selected = (item.CompanyQuickRegisterDefSettingId == defaultSetting.GetValueOrDefault())
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CmpDefSettingList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult SelectCompanyQuickRegisterDefSetting(int defSettingId)
	{
		_003C_003Ec__DisplayClass44_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass44_0();
		CS_0024_003C_003E8__locals0.defSettingId = defSettingId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		CrmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel = new CrmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel();
		try
		{
			DbSet<CrmCompanyQuickRegisterDefSetting> crmCompanyQuickRegisterDefSetting = _dbTbl.CrmCompanyQuickRegisterDefSetting;
			ParameterExpression val = Expression.Parameter(typeof(CrmCompanyQuickRegisterDefSetting), "c");
			CrmCompanyQuickRegisterDefSetting crmCompanyQuickRegisterDefSetting2 = Queryable.FirstOrDefault<CrmCompanyQuickRegisterDefSetting>((IQueryable<CrmCompanyQuickRegisterDefSetting>)crmCompanyQuickRegisterDefSetting, Expression.Lambda<Func<CrmCompanyQuickRegisterDefSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass44_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmCompanyQuickRegisterDefSetting2 != null)
			{
				DbSet<CrmCompanyQuickRegisterDefSetting_Lang> crmCompanyQuickRegisterDefSetting_Lang = _dbTbl.CrmCompanyQuickRegisterDefSetting_Lang;
				val = Expression.Parameter(typeof(CrmCompanyQuickRegisterDefSetting_Lang), "c");
				List<CrmCompanyQuickRegisterDefSetting_Lang> list = Enumerable.ToList<CrmCompanyQuickRegisterDefSetting_Lang>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)Queryable.Where<CrmCompanyQuickRegisterDefSetting_Lang>((IQueryable<CrmCompanyQuickRegisterDefSetting_Lang>)crmCompanyQuickRegisterDefSetting_Lang, Expression.Lambda<Func<CrmCompanyQuickRegisterDefSetting_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass44_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang myitem) => new CommonMultiLanguageViewModel
				{
					Value = myitem.SettingTitle,
					LanguageId = myitem.LanguageID
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyQuickRegisterDefSetting2.SettingTitle,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang myitem) => new CommonMultiLanguageViewModel
				{
					Value = myitem.cmpActivityType,
					LanguageId = myitem.LanguageID
				})));
				list3.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyQuickRegisterDefSetting2.cmpActivityType,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang myitem) => new CommonMultiLanguageViewModel
				{
					Value = myitem.cmpSpecialPoint,
					LanguageId = myitem.LanguageID
				})));
				list4.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyQuickRegisterDefSetting2.cmpSpecialPoint,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list5 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang myitem) => new CommonMultiLanguageViewModel
				{
					Value = myitem.cmpDescription,
					LanguageId = myitem.LanguageID
				})));
				list5.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyQuickRegisterDefSetting2.cmpDescription,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list6 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang myitem) => new CommonMultiLanguageViewModel
				{
					Value = myitem.prsSpecialPoint,
					LanguageId = myitem.LanguageID
				})));
				list6.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyQuickRegisterDefSetting2.prsSpecialPoint,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list7 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang myitem) => new CommonMultiLanguageViewModel
				{
					Value = myitem.prsDescription,
					LanguageId = myitem.LanguageID
				})));
				list7.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyQuickRegisterDefSetting2.prsDescription,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list8 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang myitem) => new CommonMultiLanguageViewModel
				{
					Value = myitem.prjTitle,
					LanguageId = myitem.LanguageID
				})));
				list8.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyQuickRegisterDefSetting2.prjTitle,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list9 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang myitem) => new CommonMultiLanguageViewModel
				{
					Value = myitem.prjDesc,
					LanguageId = myitem.LanguageID
				})));
				list9.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyQuickRegisterDefSetting2.prjDesc,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list10 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang myitem) => new CommonMultiLanguageViewModel
				{
					Value = myitem.prjPostFix,
					LanguageId = myitem.LanguageID
				})));
				list10.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyQuickRegisterDefSetting2.prjPostFix,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list11 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang myitem) => new CommonMultiLanguageViewModel
				{
					Value = myitem.prjSubject,
					LanguageId = myitem.LanguageID
				})));
				list11.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyQuickRegisterDefSetting2.prjSubject,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list12 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang myitem) => new CommonMultiLanguageViewModel
				{
					Value = myitem.prjTitleGroup,
					LanguageId = myitem.LanguageID
				})));
				list12.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyQuickRegisterDefSetting2.prjTitleGroup,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list13 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang myitem) => new CommonMultiLanguageViewModel
				{
					Value = myitem.prjDescI,
					LanguageId = myitem.LanguageID
				})));
				list13.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyQuickRegisterDefSetting2.prjDescI,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list14 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang myitem) => new CommonMultiLanguageViewModel
				{
					Value = myitem.cnvsDesc,
					LanguageId = myitem.LanguageID
				})));
				list14.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyQuickRegisterDefSetting2.cnvsDesc,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list15 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang myitem) => new CommonMultiLanguageViewModel
				{
					Value = myitem.cnvsReferDesc,
					LanguageId = myitem.LanguageID
				})));
				list15.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyQuickRegisterDefSetting2.cnvsReferDesc,
					LanguageId = result
				});
				DateTime now = DateTime.Now;
				crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel = new CrmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel
				{
					CompanyQuickRegisterDefSettingId = crmCompanyQuickRegisterDefSetting2.CompanyQuickRegisterDefSettingId,
					cmpTitleId = crmCompanyQuickRegisterDefSetting2.cmpTitleId,
					cmpGroupId = crmCompanyQuickRegisterDefSetting2.cmpGroupId,
					cmpSubGroupId = crmCompanyQuickRegisterDefSetting2.cmpSubGroupId,
					cmpGroupIdII = crmCompanyQuickRegisterDefSetting2.cmpGroupIdII,
					cmpGroupIdIII = crmCompanyQuickRegisterDefSetting2.cmpGroupIdIII,
					cmpGroupIdIV = crmCompanyQuickRegisterDefSetting2.cmpGroupIdIV,
					cmpTypeId = crmCompanyQuickRegisterDefSetting2.cmpTypeId,
					cmpPresentationId = crmCompanyQuickRegisterDefSetting2.cmpPresentationId,
					cmpCityId = crmCompanyQuickRegisterDefSetting2.cmpCityId,
					cmpEffectiveDateIncDay = crmCompanyQuickRegisterDefSetting2.cmpEffectiveDateIncDay,
					cmpEffectiveDate = "",
					cmpKind = crmCompanyQuickRegisterDefSetting2.cmpKind,
					prsTitleId = crmCompanyQuickRegisterDefSetting2.prsTitleId,
					prsJobId = crmCompanyQuickRegisterDefSetting2.prsJobId,
					prsTypeId = crmCompanyQuickRegisterDefSetting2.prsTypeId,
					prsGroupId = crmCompanyQuickRegisterDefSetting2.prsGroupId,
					prsSexId = crmCompanyQuickRegisterDefSetting2.prsSexId,
					prsEducationId = crmCompanyQuickRegisterDefSetting2.prsEducationId,
					prsCityId = crmCompanyQuickRegisterDefSetting2.prsCityId,
					prsDepartmentId = crmCompanyQuickRegisterDefSetting2.prsDepartmentId,
					prjGradeId = crmCompanyQuickRegisterDefSetting2.prjGradeId,
					prjPriorityId = crmCompanyQuickRegisterDefSetting2.prjPriorityId,
					prjGroupId = crmCompanyQuickRegisterDefSetting2.prjGroupId,
					prjcnvsStatusGroupId = crmCompanyQuickRegisterDefSetting2.prjcnvsStatusGroupId,
					prjRemindDateIncDay = crmCompanyQuickRegisterDefSetting2.prjRemindDateIncDay,
					prjRemindDate = "",
					prjFOCmpCanSee = (crmCompanyQuickRegisterDefSetting2.prjFOCmpCanSee.HasValue && crmCompanyQuickRegisterDefSetting2.prjFOCmpCanSee.GetValueOrDefault()),
					prjCategoryId = crmCompanyQuickRegisterDefSetting2.prjCategoryId,
					cnvsTopicId = crmCompanyQuickRegisterDefSetting2.cnvsTopicId,
					cnvsStatusId = crmCompanyQuickRegisterDefSetting2.cnvsStatusId,
					cnvsPriorityId = crmCompanyQuickRegisterDefSetting2.cnvsPriorityId,
					cnvsRemindDateIncDay = crmCompanyQuickRegisterDefSetting2.cnvsRemindDateIncDay,
					cnvsRemindDate = "",
					cnvsRemindTime = crmCompanyQuickRegisterDefSetting2.cnvsRemindTime,
					cnvsRemindDateForAllarmIncDay = crmCompanyQuickRegisterDefSetting2.cnvsRemindDateForAllarmIncDay,
					cnvsRemindDateForAllarm = "",
					cnvsFOCmpCanSee = (crmCompanyQuickRegisterDefSetting2.cnvsFOCmpCanSee.HasValue && crmCompanyQuickRegisterDefSetting2.cnvsFOCmpCanSee.GetValueOrDefault()),
					IsDefault = crmCompanyQuickRegisterDefSetting2.IsDefault,
					SettingTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					SettingTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					cmpActivityType_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					cmpActivityType = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					cmpSpecialPoint_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					cmpSpecialPoint = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					cmpDescription_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					cmpDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					prsSpecialPoint_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					prsSpecialPoint = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					prsDescription_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					prsDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					prjTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					prjTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					prjDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					prjDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					prjPostFix_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					prjPostFix = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					prjSubject_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					prjSubject = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					prjTitleGroup_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					prjTitleGroup = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					prjDescI_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					prjDescI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					cnvsDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					cnvsDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					cnvsReferDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list15, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					cnvsReferDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list15, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list15, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "")
				};
				if (crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel != null)
				{
					if (crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.cmpEffectiveDateIncDay.HasValue)
					{
						int result2 = 0;
						int.TryParse(crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.cmpEffectiveDateIncDay.ToString(), out result2);
						crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.cmpEffectiveDate = now.AddDays(result2).ToString("yyyy/MM/dd");
					}
					if (crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.cmpCityId.HasValue)
					{
						int result3 = 0;
						int.TryParse(crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.cmpCityId.ToString(), out result3);
						if (result3 != 0)
						{
							CRMspSelectCountryProvinceCityByCityId_Result cRMspSelectCountryProvinceCityByCityId_Result = Enumerable.FirstOrDefault<CRMspSelectCountryProvinceCityByCityId_Result>((IEnumerable<CRMspSelectCountryProvinceCityByCityId_Result>)_dbI.CRMspSelectCountryProvinceCityByCityId(result3, CS_0024_003C_003E8__locals0.currLangID, result));
							if (cRMspSelectCountryProvinceCityByCityId_Result != null)
							{
								crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.cmpCountry = cRMspSelectCountryProvinceCityByCityId_Result.Country ?? "";
								crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.cmpCountryId = cRMspSelectCountryProvinceCityByCityId_Result.CountryId;
								crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.cmpProvince = cRMspSelectCountryProvinceCityByCityId_Result.Province ?? "";
								crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.cmpProvinceId = cRMspSelectCountryProvinceCityByCityId_Result.ProvinceId;
								crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.cmpCity = crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.cmpCity ?? "";
								crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.cmpCityId = cRMspSelectCountryProvinceCityByCityId_Result.CityID;
							}
						}
					}
					if (crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.prsCityId.HasValue)
					{
						int result4 = 0;
						int.TryParse(crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.prsCityId.ToString(), out result4);
						if (result4 != 0)
						{
							CRMspSelectCountryProvinceCityByCityId_Result cRMspSelectCountryProvinceCityByCityId_Result2 = Enumerable.FirstOrDefault<CRMspSelectCountryProvinceCityByCityId_Result>((IEnumerable<CRMspSelectCountryProvinceCityByCityId_Result>)_dbI.CRMspSelectCountryProvinceCityByCityId(result4, CS_0024_003C_003E8__locals0.currLangID, result));
							if (cRMspSelectCountryProvinceCityByCityId_Result2 != null)
							{
								crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.prsCountryId = cRMspSelectCountryProvinceCityByCityId_Result2.CountryId;
								crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.prsProvinceId = cRMspSelectCountryProvinceCityByCityId_Result2.ProvinceId;
								crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.prsCityId = cRMspSelectCountryProvinceCityByCityId_Result2.CityID;
							}
						}
					}
					if (crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.prjRemindDateIncDay.HasValue)
					{
						int result5 = 0;
						int.TryParse(crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.prjRemindDateIncDay.ToString(), out result5);
						crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.prjRemindDate = now.AddDays(result5).ToString("yyyy/MM/dd");
					}
					if (crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.cnvsRemindDateIncDay.HasValue)
					{
						int result6 = 0;
						int.TryParse(crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.cnvsRemindDateIncDay.ToString(), out result6);
						crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.cnvsRemindDate = now.AddDays(result6).ToString("yyyy/MM/dd");
					}
					if (crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.cnvsRemindDateForAllarmIncDay.HasValue)
					{
						int result7 = 0;
						int.TryParse(crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.cnvsRemindDateForAllarmIncDay.ToString(), out result7);
						crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.cnvsRemindDateForAllarm = now.AddDays(result7).ToString("yyyy/MM/dd");
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
		JsonResult jsonResult = Json(crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult SetPrjPostFixByPrjStartDate(int month, string prjStartDate)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		try
		{
			if (month != 0 && !string.IsNullOrWhiteSpace(prjStartDate))
			{
				DateTime dateTime = DateTime.Now;
				DateTime now = DateTime.Now;
				DateTime dateTime2 = default(DateTime);
				string text = "";
				try
				{
					text = PersianDate.GetFormatetdDate(prjStartDate.Replace("/", ""));
					switch (lCID)
					{
					case 1065:
						dateTime2 = DateTime.Parse(text + " " + now.ToString("HH:mm:ss"), new PersianCulture());
						prjStartDate = dateTime2.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime2 = DateTime.Parse(text + " " + now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
						prjStartDate = dateTime2.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime2 = DateTime.Parse(text + " " + now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
						prjStartDate = dateTime2.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
					dateTime = dateTime2;
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
				dateTime = dateTime.AddMonths(month);
				foreach (Languages item in Enumerable.ToList<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get()))
				{
					CommonMultiLanguageViewModel commonMultiLanguageViewModel = new CommonMultiLanguageViewModel();
					commonMultiLanguageViewModel.LanguageId = item.LanguageID;
					if (item.LanguageID == 1065)
					{
						commonMultiLanguageViewModel.Value = dateTime.ToString("yyyy/MM/dd", new PersianCulture());
					}
					else if (item.LanguageID == 1025)
					{
						commonMultiLanguageViewModel.Value = dateTime.ToString("yyyy/MM/dd", new CultureInfo("ar-SA"));
					}
					else
					{
						commonMultiLanguageViewModel.Value = dateTime.ToString("yyyy/MM/dd", new CultureInfo("en-US"));
					}
					list.Add(commonMultiLanguageViewModel);
				}
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			list = null;
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
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
		_dbIII.Dispose();
		base.Dispose(disposing);
	}
}

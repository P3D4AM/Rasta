using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Objects;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using CRM.General.Calendar;
using CRM.General.IO;
using CRM.General.IO.FTP;
using CRM.General.Security;
using CRM.General.Utilities;
using CRM.Models;
using CRM.Models.ReportModel.PreOrderPrintRpt;
using CRM.Resources;
using CRMIdeal.Areas.OtherSystems.Controllers;
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
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using Stimulsoft.Report;
using Stimulsoft.Report.Components;
using Stimulsoft.Report.Dictionary;
using Stimulsoft.Report.Export;

namespace CRMIdeal.Areas.PreOrders.Controllers;

public class HomeController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public int id;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass15_0
	{
		public int id;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass19_0
	{
		public int pordItemId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass20_0
	{
		public int pordItemId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass26_0
	{
		public HomeController _003C_003E4__this;

		public int currLangID;

		public int defLangID;

		public WSspRpt_PrintPreOrder_Result item;

		public Func<WSspRpt_PrintPreOrder_Result, List<WSspSelectPreOrderItemSpecificationByItemId_Result>> _003C_003E9__4;

		public Func<WSspRpt_PrintPreOrder_Result, List<WSspRpt_PrintPreOrderPayments_Result>> _003C_003E9__5;

		internal List<WSspSelectPreOrderItemSpecificationByItemId_Result> _003CCreatePdfImage_003Eb__4(WSspRpt_PrintPreOrder_Result itemSpe)
		{
			return Enumerable.ToList<WSspSelectPreOrderItemSpecificationByItemId_Result>((IEnumerable<WSspSelectPreOrderItemSpecificationByItemId_Result>)_003C_003E4__this._db.WSspSelectPreOrderItemSpecificationByItemId(itemSpe.PreOrderItemID, currLangID, defLangID));
		}

		internal List<WSspRpt_PrintPreOrderPayments_Result> _003CCreatePdfImage_003Eb__5(WSspRpt_PrintPreOrder_Result itemSpe)
		{
			return Enumerable.ToList<WSspRpt_PrintPreOrderPayments_Result>((IEnumerable<WSspRpt_PrintPreOrderPayments_Result>)_003C_003E4__this._db.WSspRpt_PrintPreOrderPayments(itemSpe.PreOrderID, currLangID, defLangID));
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass27_0
	{
		public int pordOrResId;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__5;

		public Func<Languages, bool> _003C_003E9__11;

		internal bool _003CSaveReasonGroup_003Eb__1(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CSaveReasonGroup_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CSaveReasonGroup_003Eb__5(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CSaveReasonGroup_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CSaveReasonGroup_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CSaveReasonGroup_003Eb__11(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass27_1
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass27_0 CS_0024_003C_003E8__locals1;

		internal bool _003CSaveReasonGroup_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSaveReasonGroup_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSaveReasonGroup_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSaveReasonGroup_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass28_0
	{
		public int pordId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass28_1
	{
		public CRMspSelectFilesDirectory_Result item;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass36_0
	{
		public int id;

		public int currLangID;

		internal bool _003CInsertEdit_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__24(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__25(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__26(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__27(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__28(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__29(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__30(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__31(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__32(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__33(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__34(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__35(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__36(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__37(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__38(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__39(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__40(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__41(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__42(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__43(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__44(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__45(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__46(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__47(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__48(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__49(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__50(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__51(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__52(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__53(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass37_0
	{
		public CRMspSelectCompanyById_Result cmp;

		public WSPreOrderLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__33;

		public Func<Languages, bool> _003C_003E9__83;

		internal bool _003CInsertEdit_003Eb__0(CRMspSelectCompanyTitle_Result c)
		{
			return c.CompanyTitleID == cmp.cmpTitleId;
		}

		internal bool _003CInsertEdit_003Eb__1(CRMspSelectCompanyTitle_Result c)
		{
			return c.CompanyTitleID == cmp.cmpTitleId;
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

		internal bool _003CInsertEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__24(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__25(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__26(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__27(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__28(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__29(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__30(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__31(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__33(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__83(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass37_1
	{
		public WSPreOrder model;

		internal bool _003CInsertEdit_003Eb__32(WSspSelectCreditDuration_Result m)
		{
			return m.CreditDurationID == model.pordCreditDurationId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass37_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass37_1 CS_0024_003C_003E8__locals1;

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

		internal bool _003CInsertEdit_003Eb__44(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__45(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__46(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__47(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__48(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__49(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__50(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__51(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__52(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__53(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__54(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__55(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__56(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__57(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__58(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__59(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__60(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__61(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__62(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__63(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__64(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__65(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__66(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__67(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__68(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__69(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__70(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__71(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__72(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__73(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__74(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__75(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__76(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__77(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__78(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__79(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__80(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__81(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__82(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass40_0
	{
		public int id;

		public int currLangID;

		internal bool _003CGetPreOrderDefaultSetting_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetPreOrderDefaultSetting_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetPreOrderDefaultSetting_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetPreOrderDefaultSetting_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetPreOrderDefaultSetting_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetPreOrderDefaultSetting_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetPreOrderDefaultSetting_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetPreOrderDefaultSetting_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetPreOrderDefaultSetting_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetPreOrderDefaultSetting_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetPreOrderDefaultSetting_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetPreOrderDefaultSetting_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetPreOrderDefaultSetting_003Eb__24(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetPreOrderDefaultSetting_003Eb__25(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetPreOrderDefaultSetting_003Eb__26(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetPreOrderDefaultSetting_003Eb__27(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetPreOrderDefaultSetting_003Eb__28(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetPreOrderDefaultSetting_003Eb__29(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetPreOrderDefaultSetting_003Eb__30(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetPreOrderDefaultSetting_003Eb__31(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetPreOrderDefaultSetting_003Eb__32(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetPreOrderDefaultSetting_003Eb__33(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetPreOrderDefaultSetting_003Eb__34(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetPreOrderDefaultSetting_003Eb__35(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetPreOrderDefaultSetting_003Eb__36(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetPreOrderDefaultSetting_003Eb__37(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetPreOrderDefaultSetting_003Eb__38(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetPreOrderDefaultSetting_003Eb__39(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetPreOrderDefaultSetting_003Eb__40(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetPreOrderDefaultSetting_003Eb__41(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass73_1
	{
		public WSspPrdGroupMustExistInPreOrderStatusDetails_Result item;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass75_0
	{
		public int reasonId;
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMLinkSpEntities _dbLink = new CRMLinkSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	private readonly CRMSpIIIEntities _dbIII = new CRMSpIIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actPreOrder")]
	public ActionResult Index(int? id = null, bool? isOpenNew = null, bool? fromIndicator = null, string parameters = "", int? companyId = null, int? selWorkflowStepId = null, string intMsgInfo = "", int preOrderId = 0)
	{
		if (!string.IsNullOrWhiteSpace(intMsgInfo))
		{
			base.ViewBag.IntMsgInfo = intMsgInfo;
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		base.ViewBag.SelectedWorkflowStepId = selWorkflowStepId;
		string text = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiSelectorViewModel>(Enumerable.Select<WSspSelectPreOrderPrdGroupMustExistReasonGroups_Result, CommonMultiSelectorViewModel>((IEnumerable<WSspSelectPreOrderPrdGroupMustExistReasonGroups_Result>)Enumerable.ToList<WSspSelectPreOrderPrdGroupMustExistReasonGroups_Result>((IEnumerable<WSspSelectPreOrderPrdGroupMustExistReasonGroups_Result>)_db.WSspSelectPreOrderPrdGroupMustExistReasonGroups(lCID, result)), (Func<WSspSelectPreOrderPrdGroupMustExistReasonGroups_Result, CommonMultiSelectorViewModel>)((WSspSelectPreOrderPrdGroupMustExistReasonGroups_Result item) => new CommonMultiSelectorViewModel
		{
			Id = item.PrdGroupMustExistReasonGroupId,
			Selected = (item.NeedReasonTxt.HasValue && item.NeedReasonTxt != false)
		}))));
		base.ViewBag.GroupMustExistReason = text;
		base.ViewBag.Parameters = parameters;
		base.ViewBag.SendedPreOrderId = 0;
		base.ViewBag.CompanyId = 0;
		if (isOpenNew ?? false)
		{
			base.ViewBag.IsOpenNew = true;
		}
		if (fromIndicator ?? false)
		{
			base.ViewBag.FromIndicator = true;
		}
		base.ViewBag.FromSearchId = false;
		if (id.HasValue)
		{
			base.ViewBag.SendedPreOrderId = id;
			base.ViewBag.FromSearchId = true;
		}
		if (companyId.HasValue && companyId > 0)
		{
			base.ViewBag.CompanyId = companyId;
		}
		GetReasonGroups();
		string text2 = "";
		bool flag = false;
		try
		{
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				int result2 = 0;
				int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result2);
				if (result2 == 1)
				{
					CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_dbLink.CRMspSelectLinkAccSetting(0, "PreUsedHintSetting", lCID, result, 1, 0, "PordPreUsedHint"));
					if (cRMspSelectLinkAccSetting_Result != null)
					{
						text2 = cRMspSelectLinkAccSetting_Result.PreUsedHint ?? "";
					}
				}
				if (!string.IsNullOrWhiteSpace(text2))
				{
					flag = true;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PreUsedHintLinkAcc = text2;
		base.ViewBag.HavePreUsedHintLinkAcc = flag;
		base.ViewBag.PreOrderId = preOrderId;
		return View();
	}

	[AjaxOnly]
	public string GetGroupMustExistReason()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			return JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiSelectorViewModel>(Enumerable.Select<WSspSelectPreOrderPrdGroupMustExistReasonGroups_Result, CommonMultiSelectorViewModel>((IEnumerable<WSspSelectPreOrderPrdGroupMustExistReasonGroups_Result>)Enumerable.ToList<WSspSelectPreOrderPrdGroupMustExistReasonGroups_Result>((IEnumerable<WSspSelectPreOrderPrdGroupMustExistReasonGroups_Result>)_db.WSspSelectPreOrderPrdGroupMustExistReasonGroups(lCID, result)), (Func<WSspSelectPreOrderPrdGroupMustExistReasonGroups_Result, CommonMultiSelectorViewModel>)((WSspSelectPreOrderPrdGroupMustExistReasonGroups_Result item) => new CommonMultiSelectorViewModel
			{
				Id = item.PrdGroupMustExistReasonGroupId,
				Selected = (item.NeedReasonTxt.HasValue && item.NeedReasonTxt != false)
			}))));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return "";
	}

	[AjaxOnly]
	public JsonResult GetPreOrderItemsDetails(int id)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectPreOrderItemSpecificationByItemId_Result> list = new List<WSspSelectPreOrderItemSpecificationByItemId_Result>();
		try
		{
			List<WSspSelectPreOrderItemSpecificationByItemId_Result> list2 = Enumerable.ToList<WSspSelectPreOrderItemSpecificationByItemId_Result>((IEnumerable<WSspSelectPreOrderItemSpecificationByItemId_Result>)_db.WSspSelectPreOrderItemSpecificationByItemId(id, lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectPreOrderItemSpecificationByItemId_Result, WSspSelectPreOrderItemSpecificationByItemId_Result>((IEnumerable<WSspSelectPreOrderItemSpecificationByItemId_Result>)list2, (Func<WSspSelectPreOrderItemSpecificationByItemId_Result, WSspSelectPreOrderItemSpecificationByItemId_Result>)((WSspSelectPreOrderItemSpecificationByItemId_Result item) => new WSspSelectPreOrderItemSpecificationByItemId_Result
			{
				PreOrderItemSpcflID = item.PreOrderItemSpcflID,
				Specification = item.Specification,
				SpecificationI = item.SpecificationI,
				SpecificationII = item.SpecificationII
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<PreOrderItemsViewModel> GetPreOrderItemsProducts(int id)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<PreOrderItemsViewModel> list = new List<PreOrderItemsViewModel>();
		try
		{
			List<WSspSelectPreOrderItems_Result> list2 = Enumerable.ToList<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)_db.WSspSelectPreOrderItems(id, lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectPreOrderItems_Result, PreOrderItemsViewModel>((IEnumerable<WSspSelectPreOrderItems_Result>)list2, (Func<WSspSelectPreOrderItems_Result, PreOrderItemsViewModel>)((WSspSelectPreOrderItems_Result item) => new PreOrderItemsViewModel
			{
				PrdName = item.PrdName,
				PrdCode = item.PrdCode,
				PreOrderItemID = item.PreOrderItemID,
				PrdCurrencyUnitPrice = item.pordICurrencyUnit,
				PrdGroupName = item.PrdFGName + "/" + item.PrdSGName,
				PrdUnitName = item.pordIPrdUnit,
				PreOrderId = item.PreOrderId,
				pordIDescription = item.pordIDescription,
				pordIDiscount = item.pordIDiscount,
				pordIDiscountPercent = item.pordIDiscountPercent,
				pordIFCR = item.pordIFCR,
				pordIFCRI = item.pordIFCRI,
				pordIOrderView = item.pordIOrderView,
				pordIPrdId = item.pordIPrdId,
				pordIPrice = item.pordIPrice,
				pordIQuantity = item.pordIQuantity,
				pordIQuantityDesc = item.pordIQuantityDesc,
				pordITax = item.pordITax,
				pordITaxIndex = item.pordITaxIndex,
				pordITotalPrice = item.pordITotalPrice,
				pordIWHId = item.pordIWHId,
				pordITracing = item.pordITracing,
				pordIPriceSum = item.pordIPriceSum,
				pordIDiscountSum = item.pordIDiscountSum,
				pordIDiscountISum = item.pordIDiscountISum,
				pordITaxSum = item.pordITaxSum,
				pordIPriceInQuan = item.pordIPriceInQuan,
				pordIPrdUnitIdI = item.pordIPrdUnitIdI,
				pordIPrdUnitIName = item.pordIPrdUnitI,
				pordIPrdColor = item.pordIPrdColor,
				pordIPrdColorId = item.pordIPrdColorId,
				PrdSingleItem = item.PrdSingleItem,
				pordIPrdUnitIRateResult = item.pordIPrdUnitIRateResult,
				pordIPrdUnitIRate = item.pordIPrdUnitIRate,
				pordILinkAccWHIdStr = item.pordILinkAccWHIdStr,
				pordIValidityExpireDate = item.pordIValidityExpireDate,
				pordIValidityExpireDatePersian = (item.pordIValidityExpireDate.HasValue ? item.pordIValidityExpireDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : ""),
				pordIPrdAutoCalcRate = item.pordIPrdAutoCalcRate,
				pordIPrdAutoCalcInflationRateInfo = item.pordIPrdAutoCalcInflationRateInfo,
				pordIDescriptionI = item.pordIDescriptionI,
				pordIDeliveryTerm = item.pordIDeliveryTerm,
				pordIDeliveryDate = item.pordIDeliveryDate,
				pordIDeliveryDatePersian = (item.pordIDeliveryDate.HasValue ? item.pordIDeliveryDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : ""),
				pordIDeliveryEndDate = item.pordIDeliveryEndDate,
				pordIDeliveryEndDatePersian = (item.pordIDeliveryEndDate.HasValue ? item.pordIDeliveryEndDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : ""),
				StockSupplyItemIds = item.StockSupplyItemIds,
				pordIDiscountCodeId = item.pordIDiscountCodeId,
				pordIDiscountCode = item.pordIDiscountCode,
				pordIDiscountCodeUserId = item.pordIDiscountCodeUserId,
				pordIDiscountCodeUser = item.pordIDiscountCodeUser,
				pordIDiscountCodeRegisterDate = item.pordIDiscountCodeRegisterDate,
				pordIDiscountCodeRegisterDatePersian = ((!item.pordIDiscountCodeRegisterDate.HasValue) ? "" : item.pordIDiscountCodeRegisterDate?.ToString("yyyy/MM/dd HH:mm")),
				PrdRowColor = Public.TColorToHex(item.PrdRowColor),
				PrdWeight = item.PrdWeight,
				PrdLocation = item.PrdLocation,
				PrdSpecificationsJs = JsonConvert.SerializeObject(Product.SelectProductSpecificationValues(item.pordIPrdId)),
				itemOrderView = item.itemOrderView,
				pordILinkedParentItemId = item.pordILinkedParentItemId,
				pordILinkedParentPrdId = item.pordILinkedParentPrdId,
				RowNumber = item.RowNumber,
				pordILinkedParentPrdName = item.pordILinkedParentPrdName,
				pordILinkedParentPrdCode = item.pordILinkedParentPrdCode,
				pordIWrhsName = item.pordIWrhsName,
				pordIPrdWeight = item.pordIPrdWeight
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public JsonResult GetPreOrder(int poreOrderCurrentId, int companyId, long preOrderNumber, string fromDate, string toDate, string linkAccPordNum, int? userId = null, int? preOrderId = null, bool? fromPaymentIndicator = false)
	{
		//IL_1092: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		DateTime value = DateTime.Now;
		DateTime now = DateTime.Now;
		int result2 = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
		}
		if (fromDate != "-20")
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
		toDate = toDate.Replace("/", "").Replace("-", "").Replace("\\", "")
			.Replace(" ", "")
			.Replace("_", "");
		now = lCID switch
		{
			1065 => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59"), 
			1025 => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59", new CultureInfo("ar-SA"), DateTimeStyles.None), 
			_ => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None), 
		};
		CurrentPreOrderViewModel currentPreOrderViewModel = new CurrentPreOrderViewModel();
		currentPreOrderViewModel.LastVerificationStep = new WSspSelectVerificationWorkFlowStepLast_Result();
		currentPreOrderViewModel.FooterData = new WSfnReturnPreOrderSumFooter_Result();
		currentPreOrderViewModel.OrderId = 0;
		currentPreOrderViewModel.OrderInfo = "";
		currentPreOrderViewModel.OrderUserName = "";
		currentPreOrderViewModel.WareHouseCount = 0;
		currentPreOrderViewModel.DocList = new List<WSspReturnDocFromPreOrder_Result>();
		currentPreOrderViewModel.PreOrderItemsList = new List<PreOrderItemsViewModel>();
		if (!userId.HasValue)
		{
			userId = UserLogin.CurrentUser.UserId;
		}
		if (!preOrderId.HasValue)
		{
			preOrderId = 0;
		}
		if (fromPaymentIndicator.GetValueOrDefault() && poreOrderCurrentId != 0 && preOrderId == 0)
		{
			preOrderId = poreOrderCurrentId;
		}
		currentPreOrderViewModel.pordLinkAccPreOrderNumber = Labels.PordShowLinkAccPreOrderNumber + ":";
		currentPreOrderViewModel.pordLinkAccPreOrderIdStr = Labels.PordShowLinkAccPreOrderIdStr + ":";
		currentPreOrderViewModel.OrdList = new List<WSspReturnOrderFromPreOrder_Result>();
		currentPreOrderViewModel.FooterPay = new WSspReturnSumPreOrderPay_Result();
		currentPreOrderViewModel.PordNumberRevisionList = new List<WSspSelectPreOrderNumberRevision_Result>();
		currentPreOrderViewModel.KaraAfzar_SmsPanelUserName = "";
		currentPreOrderViewModel.KaraAfzar_SmsPanelOrdId = 0;
		currentPreOrderViewModel.KaraAfzar_SmsPanelOrdItemId = 0;
		currentPreOrderViewModel.KaraAfzar_SmsPanelOrdItemPriceSum = default(decimal);
		currentPreOrderViewModel.pordLinkAccFirstTransferDateStr = Labels.lblLinkAccFirstTransferDate + ":";
		currentPreOrderViewModel.pordLinkAccLastTransferDateStr = Labels.lblLinkAccLastTransferDate + ":";
		currentPreOrderViewModel.PreOrderDiscountCount = 0;
		currentPreOrderViewModel.StockSupplyList = new List<WSspReturnStockSupplyFromPreOrder_Result>();
		currentPreOrderViewModel.pordLinkAccData = "";
		currentPreOrderViewModel.PordIsCanceled = false;
		currentPreOrderViewModel.IsSentToLinkAcc = false;
		currentPreOrderViewModel.IsExpired = false;
		currentPreOrderViewModel.PordInfoInHead = "";
		try
		{
			List<WSspSelectPreOrdersInMode_Result> list = Enumerable.ToList<WSspSelectPreOrdersInMode_Result>((IEnumerable<WSspSelectPreOrdersInMode_Result>)_db.WSspSelectPreOrdersInMode(fromDate, toDate, userId, preOrderId, companyId, preOrderNumber, lCID, result, value, now, linkAccPordNum, result2));
			if (Enumerable.Any<WSspSelectPreOrdersInMode_Result>((IEnumerable<WSspSelectPreOrdersInMode_Result>)list))
			{
				currentPreOrderViewModel.IsFind = true;
				currentPreOrderViewModel.Message = "";
				currentPreOrderViewModel.FromDate = fromDate;
				currentPreOrderViewModel.ToDate = toDate;
				currentPreOrderViewModel.PreOrderNextId = -1;
				currentPreOrderViewModel.PreOrderPreviousId = -1;
				currentPreOrderViewModel.RemainpordAmount = default(decimal);
				currentPreOrderViewModel.sumpordpayAmount = default(decimal);
				currentPreOrderViewModel.AllPayRemain = default(decimal);
				currentPreOrderViewModel.NotInSumTotalPrice = default(decimal);
				if (list.Count == 1)
				{
					currentPreOrderViewModel.PreOrderFirstId = -1;
					currentPreOrderViewModel.PreOrderLastId = -1;
				}
				else
				{
					currentPreOrderViewModel.PreOrderFirstId = Enumerable.FirstOrDefault<WSspSelectPreOrdersInMode_Result>((IEnumerable<WSspSelectPreOrdersInMode_Result>)list).PreOrderID;
					currentPreOrderViewModel.PreOrderLastId = Enumerable.LastOrDefault<WSspSelectPreOrdersInMode_Result>((IEnumerable<WSspSelectPreOrdersInMode_Result>)list).PreOrderID;
				}
				WSspSelectPreOrdersInMode_Result wSspSelectPreOrdersInMode_Result = ((poreOrderCurrentId <= 0) ? Enumerable.LastOrDefault<WSspSelectPreOrdersInMode_Result>((IEnumerable<WSspSelectPreOrdersInMode_Result>)list) : Enumerable.FirstOrDefault<WSspSelectPreOrdersInMode_Result>((IEnumerable<WSspSelectPreOrdersInMode_Result>)list, (Func<WSspSelectPreOrdersInMode_Result, bool>)((WSspSelectPreOrdersInMode_Result c) => c.PreOrderID == poreOrderCurrentId)));
				if (wSspSelectPreOrdersInMode_Result != null)
				{
					if (PreOrder.IsEditAfterFix(wSspSelectPreOrdersInMode_Result.pordEditAfterFixInfoJs, wSspSelectPreOrdersInMode_Result.PreOrderID, 1))
					{
						wSspSelectPreOrdersInMode_Result.pordIsFixed = false;
					}
					if (!string.IsNullOrWhiteSpace((wSspSelectPreOrdersInMode_Result.pordEditAfterFixInfoJs ?? "").Replace("[]", "")))
					{
						List<EditAfterFixInfoViewModel> list2 = JsonConvert.DeserializeObject<List<EditAfterFixInfoViewModel>>(wSspSelectPreOrdersInMode_Result.pordEditAfterFixInfoJs);
						if (list2 != null)
						{
							foreach (EditAfterFixInfoViewModel item in list2)
							{
								CRMspSelectUsersById_Result cRMspSelectUsersById_Result = CRMIdeal.Classes.Helper.User.SelectUsersById(item.eafUserId);
								if (cRMspSelectUsersById_Result != null)
								{
									item.eafUserName = cRMspSelectUsersById_Result.FullName;
								}
								item.eafRequestDatePersian = item.eafRequestDate.ToString("yyyy/MM/dd HH:mm");
								item.eafEndDatePersian = item.eafEndDate?.ToString("yyyy/MM/dd HH:mm");
								item.eafDoneDatePersian = item.eafDoneDate?.ToString("yyyy/MM/dd HH:mm");
							}
							wSspSelectPreOrdersInMode_Result.pordEditAfterFixInfoJs = JsonConvert.SerializeObject(list2);
						}
					}
					wSspSelectPreOrdersInMode_Result.pordDateTime = wSspSelectPreOrdersInMode_Result.pordDateTime;
					wSspSelectPreOrdersInMode_Result.pordDate = (wSspSelectPreOrdersInMode_Result.pordDateTime.HasValue ? wSspSelectPreOrdersInMode_Result.pordDateTime.Value.ToString("yyyy/MM/dd") : null);
					wSspSelectPreOrdersInMode_Result.pordDeliveryDate = (wSspSelectPreOrdersInMode_Result.pordDeliveryDateTime.HasValue ? wSspSelectPreOrdersInMode_Result.pordDeliveryDateTime.Value.ToString("yyyyMMdd") : null);
					wSspSelectPreOrdersInMode_Result.pordDeliveryEndDate = (wSspSelectPreOrdersInMode_Result.pordDeliveryEndDateTime.HasValue ? wSspSelectPreOrdersInMode_Result.pordDeliveryEndDateTime.Value.ToString("yyyyMMdd") : null);
					wSspSelectPreOrdersInMode_Result.pordImportDate = (wSspSelectPreOrdersInMode_Result.pordImportDateTime.HasValue ? wSspSelectPreOrdersInMode_Result.pordImportDateTime.Value.ToString("yyyy/MM/dd HH:mm:ss") : null);
					_ = wSspSelectPreOrdersInMode_Result.RegisterDate;
					wSspSelectPreOrdersInMode_Result.RegisterDatePersian = wSspSelectPreOrdersInMode_Result.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
					if (string.IsNullOrEmpty(wSspSelectPreOrdersInMode_Result.AppType))
					{
						wSspSelectPreOrdersInMode_Result.AppType = Configuration.AppType;
					}
					wSspSelectPreOrdersInMode_Result.AppType = Configuration.GetAppType(wSspSelectPreOrdersInMode_Result.AppType);
					if (!string.IsNullOrEmpty(wSspSelectPreOrdersInMode_Result.VerifierFName) && wSspSelectPreOrdersInMode_Result.pordVerifiedRegisterDate.HasValue)
					{
						wSspSelectPreOrdersInMode_Result.VerifierFName += (wSspSelectPreOrdersInMode_Result.pordVerifiedRegisterDate.HasValue ? (" (" + wSspSelectPreOrdersInMode_Result.pordVerifiedRegisterDate.Value.ToString("yyyy/MM/dd HH:mm") + ")") : "");
					}
					wSspSelectPreOrdersInMode_Result.pordExpireDate = (wSspSelectPreOrdersInMode_Result.pordExpireDateTime.HasValue ? wSspSelectPreOrdersInMode_Result.pordExpireDateTime.Value.ToString("yyyy/MM/dd-HH:mm") : null);
					wSspSelectPreOrdersInMode_Result.pordDeadlineDatePersian = (wSspSelectPreOrdersInMode_Result.pordDeadlineDate.HasValue ? wSspSelectPreOrdersInMode_Result.pordDeadlineDate.Value.ToString("yyyy/MM/dd") : null);
					if (wSspSelectPreOrdersInMode_Result.pordChangeStatusUserId.GetValueOrDefault() != 0)
					{
						string text = "";
						text = wSspSelectPreOrdersInMode_Result.pordChangeStatusUser ?? "";
						if (wSspSelectPreOrdersInMode_Result.pordChangeStatusDate.HasValue)
						{
							if (!string.IsNullOrWhiteSpace(text))
							{
								text += " - ";
							}
							text += (wSspSelectPreOrdersInMode_Result.pordChangeStatusDate.HasValue ? (" (" + wSspSelectPreOrdersInMode_Result.pordChangeStatusDate.Value.ToString("yyyy/MM/dd HH:mm") + ")") : "");
						}
						if (!string.IsNullOrWhiteSpace(text))
						{
							text = " (" + text + ")";
						}
						wSspSelectPreOrdersInMode_Result.pordStatus += text;
					}
					_ = Labels.lblReviewStatus;
					_ = Labels.lblVerifyStatus;
					_ = Labels.lblNotVerifyStatus;
					_ = Labels.lblCancelStatus;
					_ = Labels.lblNotCancelStatus;
					_ = Labels.lblExpireStatus;
					_ = Labels.lblNotExpireStatus;
					"lblIssueOrderStatus".OrderLabels();
					"lblNotIssueOrderStatus".OrderLabels();
					string lblFoIsActive = Labels.lblFoIsActive;
					_ = Labels.lblShpIsActive;
					string text2 = "";
					if (wSspSelectPreOrdersInMode_Result.pordExpireDateTime.HasValue && wSspSelectPreOrdersInMode_Result.pordExpireDateTime < DateTime.Now)
					{
						currentPreOrderViewModel.IsExpired = true;
					}
					text2 = wSspSelectPreOrdersInMode_Result.pordNumber.ToString();
					if (wSspSelectPreOrdersInMode_Result.pordNumberRevision.HasValue)
					{
						text2 = text2 + "-" + wSspSelectPreOrdersInMode_Result.pordNumberRevision;
					}
					if (!string.IsNullOrWhiteSpace(wSspSelectPreOrdersInMode_Result.pordStatus) && wSspSelectPreOrdersInMode_Result.pordStatusId.GetValueOrDefault() == 4)
					{
						if (!string.IsNullOrWhiteSpace(text2))
						{
							text2 += " / ";
						}
						text2 = text2 + "<span class='span-is-canceled'>" + wSspSelectPreOrdersInMode_Result.pordStatus + "</span>";
					}
					bool flag = false;
					wSspSelectPreOrdersInMode_Result.CmpShpIsActive = wSspSelectPreOrdersInMode_Result.CmpShpIsActive ?? "0";
					if (!string.IsNullOrWhiteSpace(wSspSelectPreOrdersInMode_Result.CmpShpIsActive) && wSspSelectPreOrdersInMode_Result.CmpShpIsActive != "" && wSspSelectPreOrdersInMode_Result.CmpShpIsActive == "1")
					{
						flag = true;
					}
					if (!flag)
					{
						if (!string.IsNullOrWhiteSpace(text2))
						{
							text2 += " / ";
						}
						text2 = text2 + "<span class='span-fo-is-active'>" + lblFoIsActive + "</span>";
					}
					currentPreOrderViewModel.PordInfoInHead = text2;
					if (wSspSelectPreOrdersInMode_Result.pordStatusId.GetValueOrDefault() == 4 || (wSspSelectPreOrdersInMode_Result.pordExpireDateTime.HasValue && wSspSelectPreOrdersInMode_Result.pordExpireDateTime < DateTime.Now))
					{
						currentPreOrderViewModel.PordIsCanceled = true;
					}
					currentPreOrderViewModel.PreOrder = wSspSelectPreOrdersInMode_Result;
					currentPreOrderViewModel.PreOrderNumber = wSspSelectPreOrdersInMode_Result.pordNumber;
					currentPreOrderViewModel.PreOrderCurrentId = wSspSelectPreOrdersInMode_Result.PreOrderID;
					if (list.Count == 1)
					{
						currentPreOrderViewModel.PreOrderNextId = -1;
						currentPreOrderViewModel.PreOrderPreviousId = -1;
					}
					else
					{
						WSspSelectPreOrdersInMode_Result next = Lists.GetNext(list, wSspSelectPreOrdersInMode_Result);
						if (next != null)
						{
							currentPreOrderViewModel.PreOrderNextId = next.PreOrderID;
						}
						WSspSelectPreOrdersInMode_Result previous = Lists.GetPrevious(list, wSspSelectPreOrdersInMode_Result);
						if (previous != null)
						{
							currentPreOrderViewModel.PreOrderPreviousId = previous.PreOrderID;
						}
					}
					currentPreOrderViewModel.PreOrderItemsList = GetPreOrderItemsProducts(wSspSelectPreOrdersInMode_Result.PreOrderID);
					WSspReturnSumPreOrderPay_Result wSspReturnSumPreOrderPay_Result = Enumerable.FirstOrDefault<WSspReturnSumPreOrderPay_Result>((IEnumerable<WSspReturnSumPreOrderPay_Result>)Enumerable.ToList<WSspReturnSumPreOrderPay_Result>((IEnumerable<WSspReturnSumPreOrderPay_Result>)_db.WSspReturnSumPreOrderPay(wSspSelectPreOrdersInMode_Result.PreOrderID)));
					if (wSspReturnSumPreOrderPay_Result != null)
					{
						currentPreOrderViewModel.RemainpordAmount = wSspReturnSumPreOrderPay_Result.RemainpordAmount;
						currentPreOrderViewModel.sumpordpayAmount = wSspReturnSumPreOrderPay_Result.sumpordpayAmount;
						currentPreOrderViewModel.FooterPay = wSspReturnSumPreOrderPay_Result;
					}
					CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
					int num = 0;
					if (cRMspSelectCrmsysSetting_Result != null)
					{
						if (cRMspSelectCrmsysSetting_Result.CmpAccFromLink.HasValue)
						{
							cRMspSelectCrmsysSetting_Result.CmpAccFromLink.GetValueOrDefault();
						}
						num = cRMspSelectCrmsysSetting_Result.LinkAccSystemId.GetValueOrDefault();
					}
					CRMspReturnCmpAccountingSummary_Result cRMspReturnCmpAccountingSummary_Result = Enumerable.FirstOrDefault<CRMspReturnCmpAccountingSummary_Result>((IEnumerable<CRMspReturnCmpAccountingSummary_Result>)Enumerable.ToList<CRMspReturnCmpAccountingSummary_Result>((IEnumerable<CRMspReturnCmpAccountingSummary_Result>)_db.CRMspReturnCmpAccountingSummary(wSspSelectPreOrdersInMode_Result.pordCompanyId, result2)));
					if (cRMspReturnCmpAccountingSummary_Result != null)
					{
						currentPreOrderViewModel.AllPayRemain = cRMspReturnCmpAccountingSummary_Result.AllPayRemain;
					}
					WSfnReturnPreOrderSumFooter_Result footerData = Enumerable.FirstOrDefault<WSfnReturnPreOrderSumFooter_Result>((IEnumerable<WSfnReturnPreOrderSumFooter_Result>)Enumerable.ToList<WSfnReturnPreOrderSumFooter_Result>((IEnumerable<WSfnReturnPreOrderSumFooter_Result>)_db.WSfnReturnPreOrderSumFooter(wSspSelectPreOrdersInMode_Result.PreOrderID)));
					currentPreOrderViewModel.FooterData = footerData;
					List<WSspReturnOrderFromPreOrder_Result> list3 = Enumerable.ToList<WSspReturnOrderFromPreOrder_Result>((IEnumerable<WSspReturnOrderFromPreOrder_Result>)_db.WSspReturnOrderFromPreOrder(wSspSelectPreOrdersInMode_Result.PreOrderID, lCID, result));
					currentPreOrderViewModel.OrdList = new List<WSspReturnOrderFromPreOrder_Result>();
					currentPreOrderViewModel.OrdList = list3;
					WSspReturnOrderFromPreOrder_Result wSspReturnOrderFromPreOrder_Result = new WSspReturnOrderFromPreOrder_Result();
					if (list3 != null)
					{
						wSspReturnOrderFromPreOrder_Result = Enumerable.LastOrDefault<WSspReturnOrderFromPreOrder_Result>((IEnumerable<WSspReturnOrderFromPreOrder_Result>)list3);
					}
					if (wSspReturnOrderFromPreOrder_Result != null)
					{
						currentPreOrderViewModel.OrderId = wSspReturnOrderFromPreOrder_Result.OrderID;
						currentPreOrderViewModel.OrderInfo = wSspReturnOrderFromPreOrder_Result.OrderInfo;
						currentPreOrderViewModel.OrderUserName = wSspReturnOrderFromPreOrder_Result.UserName;
					}
					decimal? notInSumTotalPrice = Enumerable.FirstOrDefault<decimal?>((IEnumerable<decimal?>)_db.WSspReturnPreOrderINotInSumTotalPrice(wSspSelectPreOrdersInMode_Result.PreOrderID));
					if (notInSumTotalPrice.HasValue)
					{
						currentPreOrderViewModel.NotInSumTotalPrice = notInSumTotalPrice;
					}
					if (wSspSelectPreOrdersInMode_Result.pordVerificationWorkFlowId.HasValue)
					{
						currentPreOrderViewModel.LastVerificationStep = Enumerable.FirstOrDefault<WSspSelectVerificationWorkFlowStepLast_Result>((IEnumerable<WSspSelectVerificationWorkFlowStepLast_Result>)_db.WSspSelectVerificationWorkFlowStepLast(wSspSelectPreOrdersInMode_Result.PreOrderID, 10, wSspSelectPreOrdersInMode_Result.pordVerificationWorkFlowId, 0, lCID, result));
					}
					WSspReturnPreOrderCommissionBaseAmount_Result wSspReturnPreOrderCommissionBaseAmount_Result = Enumerable.FirstOrDefault<WSspReturnPreOrderCommissionBaseAmount_Result>((IEnumerable<WSspReturnPreOrderCommissionBaseAmount_Result>)_db.WSspReturnPreOrderCommissionBaseAmount(wSspSelectPreOrdersInMode_Result.PreOrderID));
					if (wSspReturnPreOrderCommissionBaseAmount_Result != null)
					{
						currentPreOrderViewModel.SumCommAmount = wSspReturnPreOrderCommissionBaseAmount_Result.CommBaseAmount;
					}
					bool result3 = false;
					if (VersionBuyer.IsDecimal)
					{
						WSspSelectCurrencyUnitsWithId_Result wSspSelectCurrencyUnitsWithId_Result = Enumerable.FirstOrDefault<WSspSelectCurrencyUnitsWithId_Result>((IEnumerable<WSspSelectCurrencyUnitsWithId_Result>)_db.WSspSelectCurrencyUnitsWithId(wSspSelectPreOrdersInMode_Result.pordCurrencyUnitId, lCID, result));
						if (wSspSelectCurrencyUnitsWithId_Result != null)
						{
							bool.TryParse(wSspSelectCurrencyUnitsWithId_Result.IsDecimal.ToString(), out result3);
						}
					}
					currentPreOrderViewModel.isDecimal = result3;
					currentPreOrderViewModel.pordVerifierId = wSspSelectPreOrdersInMode_Result.pordTypeId;
					currentPreOrderViewModel.pordNumRef = wSspSelectPreOrdersInMode_Result.pordNumRef;
					currentPreOrderViewModel.pordSellerId = wSspSelectPreOrdersInMode_Result.pordSellerId;
					currentPreOrderViewModel.pordSellerName = wSspSelectPreOrdersInMode_Result.pordSellerName;
					currentPreOrderViewModel.pordLinkAccPreOrderNumber = Labels.PordShowLinkAccPreOrderNumber + ": " + wSspSelectPreOrdersInMode_Result.pordLinkAccPreOrderNumber;
					currentPreOrderViewModel.pordLinkAccPreOrderIdStr = Labels.PordShowLinkAccPreOrderIdStr + ": " + ((!string.IsNullOrWhiteSpace(wSspSelectPreOrdersInMode_Result.pordLinkAccPreOrderIdStr)) ? wSspSelectPreOrdersInMode_Result.pordLinkAccPreOrderIdStr : (wSspSelectPreOrdersInMode_Result.pordLinkAccPreOrderId.HasValue ? wSspSelectPreOrdersInMode_Result.pordLinkAccPreOrderId.ToString() : ""));
					currentPreOrderViewModel.pordLinkAccFirstTransferDateStr = Labels.lblLinkAccFirstTransferDate + ":" + (wSspSelectPreOrdersInMode_Result.pordLinkAccFirstTransferDate.HasValue ? ("<span class='span-transfer-date-to-acc'>" + wSspSelectPreOrdersInMode_Result.pordLinkAccFirstTransferDate.Value.ToString("yyyy/MM/dd HH:mm:ss") + "</span>") : "");
					currentPreOrderViewModel.pordLinkAccLastTransferDateStr = Labels.lblLinkAccLastTransferDate + ":" + (wSspSelectPreOrdersInMode_Result.pordLinkAccLastTransferDate.HasValue ? ("<span class='span-transfer-date-to-acc'>" + wSspSelectPreOrdersInMode_Result.pordLinkAccLastTransferDate.Value.ToString("yyyy/MM/dd HH:mm:ss") + "</span>") : "");
					currentPreOrderViewModel.pordLinkAccData = wSspSelectPreOrdersInMode_Result.pordLinkAccData ?? "";
					if (num == 1)
					{
						List<CRMspSelectLinkAccSettingDBIsActive_Result> linkAccSettingDBList = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDBList(1);
						List<PordLinkAccDataViewModel> list4 = new List<PordLinkAccDataViewModel>();
						if (!string.IsNullOrWhiteSpace(currentPreOrderViewModel.pordLinkAccData))
						{
							foreach (PordLinkAccDataViewModel item2 in new JavaScriptSerializer().Deserialize<List<PordLinkAccDataViewModel>>(currentPreOrderViewModel.pordLinkAccData))
							{
								int dbId = 0;
								int.TryParse(item2.DBId.ToString(), out dbId);
								if (dbId != 0 && linkAccSettingDBList != null && Enumerable.Any<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)linkAccSettingDBList))
								{
									CRMspSelectLinkAccSettingDBIsActive_Result cRMspSelectLinkAccSettingDBIsActive_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)linkAccSettingDBList, (Func<CRMspSelectLinkAccSettingDBIsActive_Result, bool>)((CRMspSelectLinkAccSettingDBIsActive_Result m) => m.LinkAccSettingDBId == dbId));
									if (cRMspSelectLinkAccSettingDBIsActive_Result != null)
									{
										item2.DbName = cRMspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbName ?? "";
										item2.DbTitle = cRMspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbTitle ?? "";
										item2.NumberWithLbl = Labels.PordShowLinkAccPreOrderNumber + ": " + item2.Number;
										item2.IdWithLbl = Labels.PordShowLinkAccPreOrderIdStr + ": " + item2.Id;
										item2.FTDateWithLbl = Labels.lblLinkAccFirstTransferDate + ":" + (item2.FTDate.HasValue ? ("<span class='span-transfer-date-to-acc'>" + item2.FTDate.Value.ToString("yyyy/MM/dd HH:mm:ss") + "</span>") : "");
										item2.LTDateWithLbl = Labels.lblLinkAccLastTransferDate + ":" + (item2.LTDate.HasValue ? ("<span class='span-transfer-date-to-acc'>" + item2.LTDate.Value.ToString("yyyy/MM/dd HH:mm:ss") + "</span>") : "");
										list4.Add(item2);
									}
								}
							}
						}
						currentPreOrderViewModel.pordLinkAccData = "";
						if (list4 != null && Enumerable.Any<PordLinkAccDataViewModel>((IEnumerable<PordLinkAccDataViewModel>)list4))
						{
							currentPreOrderViewModel.pordLinkAccData = JsonConvert.SerializeObject(Enumerable.ToList<PordLinkAccDataViewModel>((IEnumerable<PordLinkAccDataViewModel>)list4));
						}
					}
					if (wSspSelectPreOrdersInMode_Result.pordLinkAccPreOrderId.GetValueOrDefault() != 0 || !string.IsNullOrWhiteSpace(wSspSelectPreOrdersInMode_Result.pordLinkAccPreOrderIdStr) || !string.IsNullOrWhiteSpace(wSspSelectPreOrdersInMode_Result.pordLinkAccPreOrderNumber) || (!string.IsNullOrWhiteSpace(wSspSelectPreOrdersInMode_Result.pordLinkAccData) && wSspSelectPreOrdersInMode_Result.pordLinkAccData != "[]"))
					{
						currentPreOrderViewModel.IsSentToLinkAcc = true;
					}
					List<int?> list5 = Enumerable.ToList<int?>((IEnumerable<int?>)_dbI.WSspReturnPreOrderItemsWareHouseCnt(wSspSelectPreOrdersInMode_Result.PreOrderID));
					if (list5 != null)
					{
						int result4 = 0;
						int.TryParse(list5.Count.ToString(), out result4);
						currentPreOrderViewModel.WareHouseCount = result4;
					}
					List<WSspReturnDocFromPreOrder_Result> list6 = Enumerable.ToList<WSspReturnDocFromPreOrder_Result>((IEnumerable<WSspReturnDocFromPreOrder_Result>)_dbI.WSspReturnDocFromPreOrder(wSspSelectPreOrdersInMode_Result.PreOrderID, lCID, result));
					currentPreOrderViewModel.DocList = new List<WSspReturnDocFromPreOrder_Result>();
					currentPreOrderViewModel.DocList = list6;
					WSspReturnDocFromPreOrder_Result wSspReturnDocFromPreOrder_Result = new WSspReturnDocFromPreOrder_Result();
					if (list6 != null)
					{
						wSspReturnDocFromPreOrder_Result = Enumerable.LastOrDefault<WSspReturnDocFromPreOrder_Result>((IEnumerable<WSspReturnDocFromPreOrder_Result>)list6);
					}
					if (wSspReturnDocFromPreOrder_Result != null)
					{
						currentPreOrderViewModel.DocInformation = wSspReturnDocFromPreOrder_Result.Info;
						currentPreOrderViewModel.DocId = wSspReturnDocFromPreOrder_Result.DocID;
						currentPreOrderViewModel.OprType = wSspReturnDocFromPreOrder_Result.OprType;
					}
					currentPreOrderViewModel.PordNumberRevisionList = Enumerable.ToList<WSspSelectPreOrderNumberRevision_Result>((IEnumerable<WSspSelectPreOrderNumberRevision_Result>)_dbI.WSspSelectPreOrderNumberRevision(wSspSelectPreOrdersInMode_Result.pordNumber, lCID, result, result2));
					if (currentPreOrderViewModel.PordNumberRevisionList != null && Enumerable.Any<WSspSelectPreOrderNumberRevision_Result>((IEnumerable<WSspSelectPreOrderNumberRevision_Result>)currentPreOrderViewModel.PordNumberRevisionList))
					{
						foreach (WSspSelectPreOrderNumberRevision_Result pordNumberRevision in currentPreOrderViewModel.PordNumberRevisionList)
						{
							pordNumberRevision.pordDate = (pordNumberRevision.pordDateTime.HasValue ? pordNumberRevision.pordDateTime.Value.ToString("yyyy/MM/dd") : "");
						}
					}
					else
					{
						currentPreOrderViewModel.PordNumberRevisionList = new List<WSspSelectPreOrderNumberRevision_Result>();
					}
					CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result2 = SysSeting.Get();
					if (cRMspSelectCrmsysSetting_Result2 != null)
					{
						string karaAfzarLockSerial = Configuration.KaraAfzarLockSerial;
						string text3 = cRMspSelectCrmsysSetting_Result2.LockSerial ?? "";
						if (!string.IsNullOrWhiteSpace(text3) && text3 == karaAfzarLockSerial)
						{
							currentPreOrderViewModel.KaraAfzar_SmsPanelUserName = Order.KaraAfzarGetSmsPanelUserName(wSspSelectPreOrdersInMode_Result.pordCompanyId.GetValueOrDefault());
							WSspSelectOrderItemsByPordIdAndManufacturerName_Result wSspSelectOrderItemsByPordIdAndManufacturerName_Result = Order.KaraAfzarGetChargeSmsOrdItem(wSspSelectPreOrdersInMode_Result.PreOrderID);
							if (wSspSelectOrderItemsByPordIdAndManufacturerName_Result != null)
							{
								currentPreOrderViewModel.KaraAfzar_SmsPanelOrdId = wSspSelectOrderItemsByPordIdAndManufacturerName_Result.OrderId;
								currentPreOrderViewModel.KaraAfzar_SmsPanelOrdItemId = wSspSelectOrderItemsByPordIdAndManufacturerName_Result.OrderItemID;
								currentPreOrderViewModel.KaraAfzar_SmsPanelOrdItemPriceSum = wSspSelectOrderItemsByPordIdAndManufacturerName_Result.ordIPriceSum.GetValueOrDefault();
							}
						}
					}
					currentPreOrderViewModel.PreOrderDiscountCount = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbII.WSspReturnPreOrderDiscountCount(wSspSelectPreOrdersInMode_Result.PreOrderID)).GetValueOrDefault();
					currentPreOrderViewModel.StockSupplyList = Enumerable.ToList<WSspReturnStockSupplyFromPreOrder_Result>((IEnumerable<WSspReturnStockSupplyFromPreOrder_Result>)_dbII.WSspReturnStockSupplyFromPreOrder(wSspSelectPreOrdersInMode_Result.PreOrderID, lCID, result));
					if (currentPreOrderViewModel.StockSupplyList == null)
					{
						currentPreOrderViewModel.StockSupplyList = new List<WSspReturnStockSupplyFromPreOrder_Result>();
					}
					else if (Enumerable.Any<WSspReturnStockSupplyFromPreOrder_Result>((IEnumerable<WSspReturnStockSupplyFromPreOrder_Result>)currentPreOrderViewModel.StockSupplyList))
					{
						foreach (WSspReturnStockSupplyFromPreOrder_Result stockSupply in currentPreOrderViewModel.StockSupplyList)
						{
							stockSupply.stsupInfo = "(" + stockSupply.stsupNumber + " - " + Labels.lblStsup + ")";
						}
					}
				}
				else
				{
					currentPreOrderViewModel.IsFind = false;
					currentPreOrderViewModel.Message = Messages.ErrorNotFound;
					currentPreOrderViewModel.FromDate = fromDate;
					currentPreOrderViewModel.ToDate = toDate;
					currentPreOrderViewModel.PreOrder = null;
					currentPreOrderViewModel.PreOrderCurrentId = -1;
					currentPreOrderViewModel.PreOrderNextId = -1;
					currentPreOrderViewModel.PreOrderNumber = -1L;
					currentPreOrderViewModel.PreOrderPreviousId = -1;
					currentPreOrderViewModel.CompanyId = -1;
					currentPreOrderViewModel.PreOrderFirstId = -1;
					currentPreOrderViewModel.PreOrderLastId = -1;
					currentPreOrderViewModel.RemainpordAmount = default(decimal);
					currentPreOrderViewModel.sumpordpayAmount = default(decimal);
					currentPreOrderViewModel.AllPayRemain = default(decimal);
					currentPreOrderViewModel.NotInSumTotalPrice = default(decimal);
				}
			}
			else
			{
				currentPreOrderViewModel.IsFind = false;
				currentPreOrderViewModel.Message = Messages.ErrorNotFound;
				currentPreOrderViewModel.FromDate = fromDate;
				currentPreOrderViewModel.ToDate = toDate;
				currentPreOrderViewModel.PreOrder = null;
				currentPreOrderViewModel.PreOrderCurrentId = -1;
				currentPreOrderViewModel.PreOrderNextId = -1;
				currentPreOrderViewModel.PreOrderNumber = -1L;
				currentPreOrderViewModel.PreOrderPreviousId = -1;
				currentPreOrderViewModel.CompanyId = -1;
				currentPreOrderViewModel.PreOrderFirstId = -1;
				currentPreOrderViewModel.PreOrderLastId = -1;
				currentPreOrderViewModel.RemainpordAmount = default(decimal);
				currentPreOrderViewModel.sumpordpayAmount = default(decimal);
				currentPreOrderViewModel.AllPayRemain = default(decimal);
				currentPreOrderViewModel.NotInSumTotalPrice = default(decimal);
			}
		}
		catch (DbEntityValidationException ex)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
			currentPreOrderViewModel.Message = Messages.frmErrorMessage + "<br />" + ((Exception)(object)ex).Message;
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			currentPreOrderViewModel.Message = Messages.frmErrorMessage + "<br />" + ex2.Message;
		}
		JsonResult jsonResult = Json(currentPreOrderViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetSumPreOrderPay(int preOrderId)
	{
		WSspReturnSumPreOrderPay_Result data = new WSspReturnSumPreOrderPay_Result();
		try
		{
			WSspReturnSumPreOrderPay_Result wSspReturnSumPreOrderPay_Result = Enumerable.FirstOrDefault<WSspReturnSumPreOrderPay_Result>((IEnumerable<WSspReturnSumPreOrderPay_Result>)Enumerable.ToList<WSspReturnSumPreOrderPay_Result>((IEnumerable<WSspReturnSumPreOrderPay_Result>)_db.WSspReturnSumPreOrderPay(preOrderId)));
			if (wSspReturnSumPreOrderPay_Result != null)
			{
				data = new WSspReturnSumPreOrderPay_Result
				{
					RemainpordAmount = wSspReturnSumPreOrderPay_Result.RemainpordAmount,
					sumpordpayAmount = wSspReturnSumPreOrderPay_Result.sumpordpayAmount
				};
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult _PartialFiles(int preOrderId)
	{
		base.ViewBag.preOrderId = preOrderId;
		return PartialView();
	}

	public ActionResult _PartialFiles_Read([DataSourceRequest] DataSourceRequest request, int preOrderId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectFilesDirectory_Result> list = Files.SelectFilesDirectory("", "", "", "10", preOrderId.ToString(), "0", "0", false);
		if (list != null && Enumerable.Any<CRMspSelectFilesDirectory_Result>((IEnumerable<CRMspSelectFilesDirectory_Result>)list))
		{
			foreach (CRMspSelectFilesDirectory_Result item in list)
			{
				DateTime now = DateTime.Now;
				if (item.DocDateTime.HasValue)
				{
					item.DocDate = DateTime.Parse(item.DocDateTime.ToString()).ToString("yyyy/MM/dd");
				}
				else if (!string.IsNullOrEmpty(item.DocDate))
				{
					item.DocDate = PersianDate.GetFormatetdDate(item.DocDate);
				}
				if (!string.IsNullOrEmpty(item.DocDay))
				{
					item.DocDay = DateTimeClass.ConvertNumToDayeOfWeek(int.Parse(item.DocDay));
				}
			}
		}
		JsonResult jsonResult = Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actDelete")]
	public string Delete(int id)
	{
		_003C_003Ec__DisplayClass14_0 _003C_003Ec__DisplayClass14_ = new _003C_003Ec__DisplayClass14_0();
		_003C_003Ec__DisplayClass14_.id = id;
		string result = "";
		try
		{
			DbSet<WSPreOrder> wSPreOrder = _dbTbl.WSPreOrder;
			ParameterExpression val = Expression.Parameter(typeof(WSPreOrder), "c");
			WSPreOrder wSPreOrder2 = Queryable.FirstOrDefault<WSPreOrder>((IQueryable<WSPreOrder>)wSPreOrder, Expression.Lambda<Func<WSPreOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass14_, typeof(_003C_003Ec__DisplayClass14_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (wSPreOrder2 != null)
			{
				try
				{
					if (PreOrder.IsSentToLinkAccByAction(wSPreOrder2.PreOrderID))
					{
						string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
						return string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
					}
					int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
					if (result2 <= 0)
					{
						result2 = 1065;
					}
					_ = Thread.CurrentThread.CurrentCulture.LCID;
					List<CRMspSelectFilesDirectory_Result> list = Files.SelectFilesDirectory("", "", "", "10", wSPreOrder2.PreOrderID.ToString(), "0", "0", false);
					if (list != null && Enumerable.Any<CRMspSelectFilesDirectory_Result>((IEnumerable<CRMspSelectFilesDirectory_Result>)list))
					{
						return Messages.msgErrorItemHasFiles;
					}
					_db.CRMspDyDeleteFormFieldMasterValuesBySysPart(_003C_003Ec__DisplayClass14_.id, "pord");
					mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)Enumerable.ToList<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteWSPreOrder(_003C_003Ec__DisplayClass14_.id)));
					if (mct_Result != null && mct_Result.Result > 0)
					{
						result = "";
					}
					else if (mct_Result != null && mct_Result.Result == 0)
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
			result = Messages.frmErrorMessage;
		}
		return result;
	}

	[AjaxOnly]
	public string ActivePreOrder(int id)
	{
		_003C_003Ec__DisplayClass15_0 _003C_003Ec__DisplayClass15_ = new _003C_003Ec__DisplayClass15_0();
		_003C_003Ec__DisplayClass15_.id = id;
		DateTime now = DateTime.Now;
		string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
		short value = short.Parse(now.ToString("MM", new PersianCulture()));
		string appType = Configuration.AppType;
		short value2 = short.Parse(Financial.Get().Id.ToString());
		int userId = UserLogin.CurrentUser.UserId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmPreOrder", "actVerifyPreOrder", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			DbSet<WSPreOrder> wSPreOrder = _dbTbl.WSPreOrder;
			ParameterExpression val = Expression.Parameter(typeof(WSPreOrder), "c");
			WSPreOrder wSPreOrder2 = Queryable.FirstOrDefault<WSPreOrder>((IQueryable<WSPreOrder>)wSPreOrder, Expression.Lambda<Func<WSPreOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass15_, typeof(_003C_003Ec__DisplayClass15_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (wSPreOrder2 != null)
			{
				int? pordCompanyId = wSPreOrder2.pordCompanyId;
				_ = wSPreOrder2.pordCompanyPersonId;
				_ = UserLogin.CurrentUser;
				string text2 = PreOrder.CheckBeforeVerification(wSPreOrder2.PreOrderID);
				if (!string.IsNullOrWhiteSpace(text2))
				{
					return text2;
				}
				_db.WSspPreOrderVerify(_003C_003Ec__DisplayClass15_.id, currentUser.UserId, DateTime.Now.ToString("yyyyMMdd", new PersianCulture()));
				text = "1|" + UserLogin.CurrentUser.UserId + "|" + UserLogin.CurrentUser.FullName + " (" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + ")";
				bool? sendSMSPordFOLinkAfterVerify = SysSeting.Get().SendSMSPordFOLinkAfterVerify;
				int? sendSMSPordFOLinkAfterVerifyType = SysSeting.Get().SendSMSPordFOLinkAfterVerifyType;
				string text3 = "";
				string text4 = "";
				string text5 = "";
				string text6 = "";
				if (sendSMSPordFOLinkAfterVerify.GetValueOrDefault())
				{
					List<SelectListItem> pordFoShortLinks = PreOrder.GetPordFoShortLinks(_003C_003Ec__DisplayClass15_.id);
					text4 = pordFoShortLinks[1].Value;
					text5 = pordFoShortLinks[2].Value;
					text6 = pordFoShortLinks[3].Value;
					if (sendSMSPordFOLinkAfterVerifyType.GetValueOrDefault() == 1)
					{
						text3 = text4;
					}
					else if (sendSMSPordFOLinkAfterVerifyType.GetValueOrDefault() == 2)
					{
						text3 = text5;
					}
					else if (sendSMSPordFOLinkAfterVerifyType.GetValueOrDefault() == 3)
					{
						text3 = text6;
					}
				}
				if (!string.IsNullOrWhiteSpace(text3))
				{
					ObjectParameter objectParameter = new ObjectParameter("Result", 0);
					_dbII.CRMspSendSmsPordFOLinkAfterVerify(_003C_003Ec__DisplayClass15_.id, text3, text4, text5, userId, value2, value, registerDatePersian, appType, lCID, result, objectParameter, text6, centerId);
					if (objectParameter != null && (int)objectParameter.Value == 1 && text != "")
					{
						text += "<br>";
					}
				}
				PreOrder.SendSmsFoSettingPordAfterVerify(_003C_003Ec__DisplayClass15_.id);
				CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(pordCompanyId.GetValueOrDefault());
				if (companyById != null && companyById.cmpCRMShopIsActive.GetValueOrDefault())
				{
					int retId = 0;
					new InternalMessage().SendIntmsgSingle(0, Labels.ShopVerifyPreOrderTitle, string.Format(Labels.ShopVerifyPreOrderMsg, wSPreOrder2.pordNumber, now.ToString("yyyy/MM/dd")).Replace("<br>", "\n"), 5, userId, -20, now.ToString("yyyyMMdd", new PersianCulture()), now.ToString("HH:mm:ss"), 0, "", _003C_003Ec__DisplayClass15_.id, Messages.ConversationErjaShow, 0, out retId, result);
					if (pordCompanyId.HasValue && pordCompanyId > 0)
					{
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary.Add("Title", Labels.ShopVerifyPreOrderTitle);
						dictionary.Add("Message", string.Format(Labels.ShopVerifyPreOrderMsg, wSPreOrder2.pordNumber, now.ToString("yyyy/MM/dd")).Replace("<br>", "\n"));
						dictionary.Add("MessageType", "VerifyPreOrd");
						dictionary.Add("InternalMessageId", retId.ToString());
						dictionary.Add("preOrderID", wSPreOrder2.PreOrderID.ToString());
						PushNotif.NewIntMsgNotifyToCompany(int.Parse(pordCompanyId.ToString()), dictionary);
					}
				}
			}
			else
			{
				text = Messages.ErrorNotFound;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = Messages.frmErrorMessage;
		}
		return text;
	}

	[AjaxOnly]
	public string DeactivePreOrder(int id)
	{
		string result = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmPreOrder", "actExitFromIsFix", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			_db.WSspPreOrderVerifyExit(id, currentUser.UserId, DateTime.Now.ToString("yyyyMMdd", new PersianCulture()));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.frmErrorMessage;
		}
		return result;
	}

	[AjaxOnly]
	public string CanceledPreOrder(int pordId)
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
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmPreOrder", "actCanceledPreOrder", currentUser))
			{
				return Messages.DoNotHaveAccess;
			}
			if (pordId > 0)
			{
				DateTime now = DateTime.Now;
				string pordChangeStatusDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				int userId = currentUser.UserId;
				string text2 = UserLogin.CurrentUser.FullName ?? "";
				_dbII.WSspPreOrderCanceled(pordId, userId, now, pordChangeStatusDatePersian);
				string text3 = "";
				int result2 = 0;
				WSspSelectPreOrderWithId_Result wSspSelectPreOrderWithId_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)_db.WSspSelectPreOrderWithId(pordId, lCID, result));
				if (wSspSelectPreOrderWithId_Result != null)
				{
					text3 = wSspSelectPreOrderWithId_Result.pordStatus ?? "";
					int.TryParse(wSspSelectPreOrderWithId_Result.pordStatusId.ToString(), out result2);
					if (SysSeting.Get().LinkAccSystemId.GetValueOrDefault() == 21 && !string.IsNullOrWhiteSpace(wSspSelectPreOrderWithId_Result.pordLinkAccPreOrderNumber))
					{
						CRMIdeal.Classes.Helper.OtherSystems.HamyarProvider hamyarProvider = new CRMIdeal.Classes.Helper.OtherSystems.HamyarProvider(false);
						WSspSelectPreOrderWithId_Result pord = wSspSelectPreOrderWithId_Result;
						hamyarProvider.EbtalSefareshInHamyar(null, pord);
					}
				}
				return "1|" + result2 + "|" + text3 + " (" + text2 + " - " + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + ")";
			}
			return Messages.ErrorNotFound;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.msgErrorRunFunction;
		}
	}

	[AjaxOnly]
	public string ExitFromIsCanceled(int pordId)
	{
		string result = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmPreOrder", "actExitFromIsCanceled", currentUser))
			{
				return Messages.DoNotHaveAccess;
			}
			if (pordId > 0)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
				if (result2 <= 0)
				{
					result2 = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				_dbII.WSspPreOrderCanceledExit(pordId);
				string text = "";
				int result3 = 0;
				WSspSelectPreOrderWithId_Result wSspSelectPreOrderWithId_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)_db.WSspSelectPreOrderWithId(pordId, lCID, result2));
				if (wSspSelectPreOrderWithId_Result != null)
				{
					text = wSspSelectPreOrderWithId_Result.pordStatus ?? "";
					int.TryParse(wSspSelectPreOrderWithId_Result.pordStatusId.ToString(), out result3);
				}
				result = "1|" + result3 + "|" + text;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actRemoveProduct")]
	public string RemoveProduct(int pordItemId, int pordId)
	{
		_003C_003Ec__DisplayClass19_0 _003C_003Ec__DisplayClass19_ = new _003C_003Ec__DisplayClass19_0();
		_003C_003Ec__DisplayClass19_.pordItemId = pordItemId;
		string result = "";
		try
		{
			if (PreOrder.IsFixed(pordId))
			{
				return Messages.msgErrorNotActiveProd;
			}
			if (PreOrder.IsSentToLinkAccByAction(pordId))
			{
				string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
				return string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
			}
			if (_003C_003Ec__DisplayClass19_.pordItemId > 0)
			{
				DbSet<WSPreOrderItems> wSPreOrderItems = _dbTbl.WSPreOrderItems;
				ParameterExpression val = Expression.Parameter(typeof(WSPreOrderItems), "c");
				WSPreOrderItems wSPreOrderItems2 = Queryable.FirstOrDefault<WSPreOrderItems>((IQueryable<WSPreOrderItems>)wSPreOrderItems, Expression.Lambda<Func<WSPreOrderItems, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass19_, typeof(_003C_003Ec__DisplayClass19_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (wSPreOrderItems2 != null)
				{
					try
					{
						_db.WSspDeletePreOrderItemSpecification(wSPreOrderItems2.PreOrderItemID);
						mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)Enumerable.ToList<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteWSPreOrderItems(_003C_003Ec__DisplayClass19_.pordItemId)));
						if (mct_Result != null && mct_Result.Result > 0)
						{
							result = (PreOrder.CalcAndSetPreOrderAmounts(pordId) ? "1" : Messages.msgErrorInCalculation);
						}
						else if (mct_Result != null && mct_Result.Result == 0)
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
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			result = Messages.frmErrorMessage;
		}
		return result;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actRemoveProductAll")]
	public string RemoveProductAll(int pordItemId)
	{
		_003C_003Ec__DisplayClass20_0 _003C_003Ec__DisplayClass20_ = new _003C_003Ec__DisplayClass20_0();
		_003C_003Ec__DisplayClass20_.pordItemId = pordItemId;
		string result = "";
		try
		{
			if (_003C_003Ec__DisplayClass20_.pordItemId > 0)
			{
				DbSet<WSPreOrderItems> wSPreOrderItems = _dbTbl.WSPreOrderItems;
				ParameterExpression val = Expression.Parameter(typeof(WSPreOrderItems), "c");
				WSPreOrderItems wSPreOrderItems2 = Queryable.FirstOrDefault<WSPreOrderItems>((IQueryable<WSPreOrderItems>)wSPreOrderItems, Expression.Lambda<Func<WSPreOrderItems, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass20_, typeof(_003C_003Ec__DisplayClass20_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (wSPreOrderItems2 != null)
				{
					try
					{
						if (PreOrder.IsFixed(wSPreOrderItems2.PreOrderId))
						{
							return Messages.msgErrorNotActiveProd;
						}
						if (PreOrder.IsSentToLinkAccByAction(wSPreOrderItems2.PreOrderId))
						{
							string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
							return string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
						}
						mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)Enumerable.ToList<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.WSspDeletePreOrderItemsAll(wSPreOrderItems2.PreOrderId)));
						if (mct_I_Result != null && mct_I_Result.Result > 0)
						{
							result = (PreOrder.CalcAndSetPreOrderAmounts(wSPreOrderItems2.PreOrderId) ? "1" : Messages.msgErrorInCalculation);
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
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			result = Messages.frmErrorMessage;
		}
		return result;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actCopypreoItem")]
	public string CopyPordItem(int pordId)
	{
		string text = "";
		try
		{
			if (pordId > 0)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				_ = Thread.CurrentThread.CurrentCulture.LCID;
				string firstRegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
				return (_db.WSspTmpUserItemCopy("PreOrder", pordId, UserLogin.CurrentUser.UserId, Configuration.AppType, result, firstRegisterDatePersian) > 0) ? "1" : Messages.msgErrorRunFunction;
			}
			return Messages.msgErrorNotActiveItem;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.frmErrorMessage;
		}
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actPastpreoItem")]
	public string PastePordItem(int pordId)
	{
		string result = "";
		try
		{
			if (pordId > 0)
			{
				if (PreOrder.IsFixed(pordId))
				{
					return Messages.msgErrorNotActiveProd;
				}
				if (PreOrder.IsSentToLinkAccByAction(pordId))
				{
					string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
					return string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
				}
				string registerDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
				short value = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
				int id = Financial.Get().Id;
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
				if (result2 <= 0)
				{
					result2 = 1065;
				}
				_ = Thread.CurrentThread.CurrentCulture.LCID;
				int? centerId = null;
				if (UserLogin.CurrentUser != null)
				{
					centerId = UserLogin.CurrentUser.UserLastCId;
				}
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.WSspTmpUserItemPast("PreOrder", pordId, UserLogin.CurrentUser.UserId, id, value, registerDatePersian, Configuration.AppType, result2, centerId));
				if (mct_Result != null && mct_Result.Result > 0)
				{
					result = (PreOrder.CalcAndSetPreOrderAmounts(pordId) ? "1" : Messages.msgErrorInCalculation);
				}
				else if (mct_Result != null && mct_Result.Result == 0)
				{
					result = Messages.msgErrorRunFunction;
				}
			}
			else
			{
				result = Messages.msgErrorNotActiveItem;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	public ActionResult _PartialList(int poreOrderCurrentId, int companyId, int preOrderNumber, string fromDate, string toDate, string linkAccPordNum, int? userId = null, int? preOrderId = null)
	{
		PreOrderListViewModel preOrderListViewModel = new PreOrderListViewModel
		{
			userId = userId,
			companyId = companyId,
			preOrderId = preOrderId,
			toDate = toDate,
			preOrderNumber = preOrderNumber,
			fromDate = fromDate,
			poreOrderCurrentId = poreOrderCurrentId,
			linkAccPreOrderNumber = linkAccPordNum
		};
		base.ViewBag.PreOrderList = preOrderListViewModel;
		return PartialView();
	}

	public ActionResult _PartialList_Read([DataSourceRequest] DataSourceRequest request, int poreOrderCurrentId, int companyId, int preOrderNumber, string fromDate, string toDate, string linkAccPordNum, int? userId = null, int? preOrderId = null)
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
		DateTime value = DateTime.Now;
		DateTime now = DateTime.Now;
		if (fromDate != "-20")
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
		toDate = toDate.Replace("/", "").Replace("-", "").Replace("\\", "")
			.Replace(" ", "")
			.Replace("_", "");
		now = lCID switch
		{
			1065 => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59"), 
			1025 => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59", new CultureInfo("ar-SA"), DateTimeStyles.None), 
			_ => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None), 
		};
		if (!userId.HasValue)
		{
			userId = UserLogin.CurrentUser.UserId;
		}
		if (!preOrderId.HasValue)
		{
			preOrderId = 0;
		}
		List<WSspSelectPreOrdersInMode_Result> list = Enumerable.ToList<WSspSelectPreOrdersInMode_Result>(Enumerable.Reverse<WSspSelectPreOrdersInMode_Result>((IEnumerable<WSspSelectPreOrdersInMode_Result>)_db.WSspSelectPreOrdersInMode(fromDate, toDate, userId, preOrderId, companyId, preOrderNumber, lCID, result, value, now, linkAccPordNum, result2)));
		foreach (WSspSelectPreOrdersInMode_Result item in list)
		{
			item.pordDate = (item.pordDateTime.HasValue ? item.pordDateTime.Value.ToString("yyyy/MM/dd") : item.pordDate);
			if (!string.IsNullOrWhiteSpace(item.CompanyPerson))
			{
				item.CompanyName = item.CompanyName + " - " + item.CompanyPerson;
			}
		}
		JsonResult jsonResult = Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	[LoginAuthorize]
	public string SendPreOrderEmail(int id, string emails, string cmpRemainAccLink = "", string cmpRemainAccLinkjs = "")
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
			string appType = Configuration.AppType;
			if (!(emails.Trim() != ""))
			{
				return Messages.EmailsNotExist;
			}
			if (Enumerable.Any<string>(Enumerable.Where<string>((IEnumerable<string>)emails.Split(new char[1] { '|' }), (Func<string, bool>)((string str) => str != "")), (Func<string, bool>)((string str) => !Regex.IsMatch(str.Trim(), "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", (RegexOptions)1))))
			{
				return Messages.EmailFormatError;
			}
			WSPreOrder wSPreOrder = _dbTbl.WSPreOrder.Find(id);
			if (wSPreOrder != null)
			{
				string[] array = CreatePdfImage(id, cmpRemainAccLink, cmpRemainAccLinkjs);
				string filePath = array[0];
				string filePathII = array[1];
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short.Parse(now.ToString("MM", new PersianCulture()));
				short.Parse(Financial.Get().Id.ToString());
				_dbII.EmailspInsertEmailUserTempTankByCompanyWeb(UserLogin.CurrentUser.UserId, 20, wSPreOrder.PreOrderID, wSPreOrder.pordCompanyId, wSPreOrder.pordProjectId, filePath, filePathII, "", "", "", value, registerDatePersian, appType, lCID, result2);
			}
			else
			{
				result = Messages.ErrorNotFound;
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			result = Messages.frmErrorMessage;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			result = Messages.frmErrorMessage;
		}
		return result;
	}

	private string[] CreatePdfImage(int preOrderId, string cmpRemainAccLink = "", string cmpRemainAccLinkjs = "")
	{
		//IL_1d96: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d9d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1da0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dbe: Expected I4, but got Unknown
		//IL_1dbe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dc2: Invalid comparison between Unknown and I4
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1930: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a87: Unknown result type (might be due to invalid IL or missing references)
		//IL_1aa5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1aac: Expected O, but got Unknown
		//IL_1ad7: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass26_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass26_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		string[] array = new string[2] { "", "" };
		StiReport stiReport = new StiReport();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
			if (CS_0024_003C_003E8__locals0.defLangID <= 0)
			{
				CS_0024_003C_003E8__locals0.defLangID = 1065;
			}
			CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
			int result = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
			}
			string text = base.Server.MapPath("~/Areas/Reports/ReportDatasets/");
			string text2 = base.Server.MapPath("~/Areas/Reports/ReportFiles/");
			string text3 = "";
			Parameters parameters = new Parameters();
			CRMIdeal.Classes.Helper.Reports reports = new CRMIdeal.Classes.Helper.Reports();
			parameters.SysSetting = reports.GetSysSetting();
			int userId = UserLogin.CurrentUser.UserId;
			DateTime now = DateTime.Now;
			string rptDate = now.ToString("yyyy/MM/dd");
			string rptDay = DateTimeClass.DefineDayeOfWeekFaWithoutNull(now.DayOfWeek.ToString());
			parameters.NotUsed_ListLinkAccData = new List<PordLinkAccDataViewModel>();
			parameters.NotUsed_ListPayLinkAccData = new List<PayLinkAccDataViewModel>();
			parameters.NotUsed_ListCmpAllPayRemainLinkAccData = new List<CmpAccountingLinkAccDataViewModel>();
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			int result2 = 0;
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result2);
			}
			List<CRMspSelectLinkAccSettingDBIsActive_Result> list = new List<CRMspSelectLinkAccSettingDBIsActive_Result>();
			if (result2 == 1)
			{
				list = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDBList(1);
			}
			parameters.CmpLinkAccAllPayRemain = default(decimal);
			decimal result3 = default(decimal);
			int cmpId = 0;
			if (result2 > 0)
			{
				CompanyController companyController = new CompanyController();
				string text4 = "";
				switch (result2)
				{
				case 1:
				{
					decimal num = default(decimal);
					decimal num2 = default(decimal);
					decimal num3 = default(decimal);
					if (list == null || !Enumerable.Any<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)list))
					{
						break;
					}
					foreach (CRMspSelectLinkAccSettingDBIsActive_Result item in list)
					{
						int result4 = 0;
						int.TryParse(item.LinkAccSettingDBId.ToString(), out result4);
						if (result4 != 0)
						{
							CmpAccountingLinkAccDataViewModel cmpAccountingLinkAccDataViewModel = new CmpAccountingLinkAccDataViewModel
							{
								DBId = result4,
								DbName = item.LinkAccSettingDbName,
								DbTitle = item.LinkAccSettingDbTitle
							};
							num = default(decimal);
							num2 = default(decimal);
							num3 = default(decimal);
							companyController.SepGetCmpAccountingDetail(cmpId, ref num, ref num2, ref num3, result4);
							text4 = $"{num:N2}";
							cmpAccountingLinkAccDataViewModel.AllPayRemain = decimal.Parse(text4 ?? "0");
							parameters.NotUsed_ListCmpAllPayRemainLinkAccData.Add(cmpAccountingLinkAccDataViewModel);
						}
					}
					break;
				}
				case 4:
					if (!string.IsNullOrWhiteSpace(cmpRemainAccLink))
					{
						text4 = cmpRemainAccLink;
					}
					if (string.IsNullOrWhiteSpace(cmpRemainAccLinkjs))
					{
						break;
					}
					try
					{
						parameters.NotUsed_ListCmpAllPayRemainLinkAccData = new JavaScriptSerializer().Deserialize<List<CmpAccountingLinkAccDataViewModel>>(cmpRemainAccLinkjs);
						if (parameters.NotUsed_ListCmpAllPayRemainLinkAccData == null)
						{
							parameters.NotUsed_ListCmpAllPayRemainLinkAccData = new List<CmpAccountingLinkAccDataViewModel>();
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
					}
					break;
				default:
					if (!string.IsNullOrWhiteSpace(cmpRemainAccLink))
					{
						text4 = cmpRemainAccLink;
					}
					break;
				}
				if (text4 == Labels.frmError)
				{
					text4 = "0.00";
				}
				if (!string.IsNullOrWhiteSpace(text4))
				{
					decimal.TryParse(text4, out result3);
				}
			}
			parameters.CmpLinkAccAllPayRemain = result3;
			parameters.ActNotShowFinancialInfo = UserLogin.IsUserAccess("frmPreOrder", "actNotShowFinancialInfo", UserLogin.CurrentUser);
			parameters.PrintPreOrder = new WSspRpt_PrintPreOrderById_Result();
			parameters.PrintPreOrder = Enumerable.FirstOrDefault<WSspRpt_PrintPreOrderById_Result>((IEnumerable<WSspRpt_PrintPreOrderById_Result>)_dbII.WSspRpt_PrintPreOrderById(preOrderId, CS_0024_003C_003E8__locals0.currLangID, CS_0024_003C_003E8__locals0.defLangID, userId, rptDate, rptDay, parameters.CmpLinkAccAllPayRemain));
			if (parameters.PrintPreOrder == null)
			{
				parameters.PrintPreOrder = new WSspRpt_PrintPreOrderById_Result();
			}
			else if (CS_0024_003C_003E8__locals0.currLangID != 1065)
			{
				if (!string.IsNullOrEmpty(parameters.PrintPreOrder.pordDate))
				{
					parameters.PrintPreOrder.pordDate = PersianDate.GetShamsi2Miladi(parameters.PrintPreOrder.pordDate.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(parameters.PrintPreOrder.prsBirthDate))
				{
					parameters.PrintPreOrder.prsBirthDate = PersianDate.GetShamsi2Miladi(parameters.PrintPreOrder.prsBirthDate.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(parameters.PrintPreOrder.pordDeliveryDate))
				{
					parameters.PrintPreOrder.pordDeliveryDate = PersianDate.GetShamsi2Miladi(parameters.PrintPreOrder.pordDeliveryDate.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(parameters.PrintPreOrder.pordDeliveryEndDate))
				{
					parameters.PrintPreOrder.pordDeliveryEndDate = PersianDate.GetShamsi2Miladi(parameters.PrintPreOrder.pordDeliveryEndDate.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(parameters.PrintPreOrder.RegisterDatePersian))
				{
					parameters.PrintPreOrder.RegisterDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintPreOrder.RegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(parameters.PrintPreOrder.pordExpireDate))
				{
					parameters.PrintPreOrder.pordExpireDate = PersianDate.GetShamsi2Miladi(parameters.PrintPreOrder.pordExpireDate.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(parameters.PrintPreOrder.prjStartDate))
				{
					parameters.PrintPreOrder.prjStartDate = PersianDate.GetShamsi2Miladi(parameters.PrintPreOrder.prjStartDate.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(parameters.PrintPreOrder.pordDeadlineDatePersian))
				{
					parameters.PrintPreOrder.pordDeadlineDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintPreOrder.pordDeadlineDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(parameters.PrintPreOrder.pordChangeStatusDatePersian))
				{
					parameters.PrintPreOrder.pordChangeStatusDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintPreOrder.pordChangeStatusDatePersian.Replace("/", "")).Replace("/", "");
				}
			}
			List<WSspRpt_PrintPreOrder_Result> list2 = Enumerable.ToList<WSspRpt_PrintPreOrder_Result>((IEnumerable<WSspRpt_PrintPreOrder_Result>)_db.WSspRpt_PrintPreOrder(preOrderId, CS_0024_003C_003E8__locals0.currLangID, CS_0024_003C_003E8__locals0.defLangID, userId, rptDate, rptDay, parameters.CmpLinkAccAllPayRemain));
			foreach (WSspRpt_PrintPreOrder_Result item2 in list2)
			{
				if (CS_0024_003C_003E8__locals0.currLangID != 1065)
				{
					if (!string.IsNullOrEmpty(item2.pordDate))
					{
						item2.pordDate = PersianDate.GetShamsi2Miladi(item2.pordDate.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item2.prsBirthDate))
					{
						item2.prsBirthDate = PersianDate.GetShamsi2Miladi(item2.prsBirthDate.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item2.pordDeliveryDate))
					{
						item2.pordDeliveryDate = PersianDate.GetShamsi2Miladi(item2.pordDeliveryDate.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item2.RegisterDatePersian))
					{
						item2.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item2.RegisterDatePersian.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item2.POIRegisterDatePersian))
					{
						item2.POIRegisterDatePersian = PersianDate.GetShamsi2Miladi(item2.POIRegisterDatePersian.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item2.LastOrdDate))
					{
						item2.LastOrdDate = PersianDate.GetShamsi2Miladi(item2.LastOrdDate.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item2.pordIDeliveryDatePersian))
					{
						item2.pordIDeliveryDatePersian = PersianDate.GetShamsi2Miladi(item2.pordIDeliveryDatePersian.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item2.prjStartDate))
					{
						item2.prjStartDate = PersianDate.GetShamsi2Miladi(item2.prjStartDate.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item2.pordDeadlineDatePersian))
					{
						item2.pordDeadlineDatePersian = PersianDate.GetShamsi2Miladi(item2.pordDeadlineDatePersian.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item2.pordIValidityExpireDatePersian))
					{
						item2.pordIValidityExpireDatePersian = PersianDate.GetShamsi2Miladi(item2.pordIValidityExpireDatePersian.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item2.pordIDiscountCodeRegisterDatePersian))
					{
						item2.pordIDiscountCodeRegisterDatePersian = PersianDate.GetShamsi2Miladi(item2.pordIDiscountCodeRegisterDatePersian.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item2.pordChangeStatusDatePersian))
					{
						item2.pordChangeStatusDatePersian = PersianDate.GetShamsi2Miladi(item2.pordChangeStatusDatePersian.Replace("/", "")).Replace("/", "");
					}
				}
			}
			byte[] coLoGo = SysSeting.Get().CoLoGo;
			if (coLoGo != null && coLoGo.Length != 0)
			{
				parameters.CoLogo = Convert.ToBase64String(coLoGo);
			}
			parameters.ReportDateTime = DateTime.Now;
			parameters.ReporterUserName = UserLogin.CurrentUser.FullName;
			CS_0024_003C_003E8__locals0.item = Enumerable.FirstOrDefault<WSspRpt_PrintPreOrder_Result>((IEnumerable<WSspRpt_PrintPreOrder_Result>)list2);
			if (CS_0024_003C_003E8__locals0.item == null)
			{
				CS_0024_003C_003E8__locals0.item = new WSspRpt_PrintPreOrder_Result();
				if (parameters.PrintPreOrder != null)
				{
					CS_0024_003C_003E8__locals0.item.PreOrderID = parameters.PrintPreOrder.PreOrderID;
					CS_0024_003C_003E8__locals0.item.pordCompanyId = parameters.PrintPreOrder.pordCompanyId;
					CS_0024_003C_003E8__locals0.item.pordCompanyPersonId = parameters.PrintPreOrder.pordCompanyPersonId;
					CS_0024_003C_003E8__locals0.item.pordProjectId = parameters.PrintPreOrder.pordProjectId;
					CS_0024_003C_003E8__locals0.item.pordReferUserId = parameters.PrintPreOrder.pordReferUserId;
					CS_0024_003C_003E8__locals0.item.pordFirstRegisterUserId = parameters.PrintPreOrder.pordFirstRegisterUserId;
					CS_0024_003C_003E8__locals0.item.UserId = parameters.PrintPreOrder.UserId;
					CS_0024_003C_003E8__locals0.item.pordVerifierId = parameters.PrintPreOrder.pordVerifierId;
					CS_0024_003C_003E8__locals0.item.pordVerificationWorkFlowId = parameters.PrintPreOrder.pordVerificationWorkFlowId;
				}
			}
			parameters.ListPrintPreOrder = list2;
			List<WSspSelectPreOrderItemSpecificationByItemId_Result> list3 = new List<WSspSelectPreOrderItemSpecificationByItemId_Result>();
			foreach (List<WSspSelectPreOrderItemSpecificationByItemId_Result> item3 in Enumerable.Select<WSspRpt_PrintPreOrder_Result, List<WSspSelectPreOrderItemSpecificationByItemId_Result>>((IEnumerable<WSspRpt_PrintPreOrder_Result>)parameters.ListPrintPreOrder, (Func<WSspRpt_PrintPreOrder_Result, List<WSspSelectPreOrderItemSpecificationByItemId_Result>>)((WSspRpt_PrintPreOrder_Result itemSpe) => Enumerable.ToList<WSspSelectPreOrderItemSpecificationByItemId_Result>((IEnumerable<WSspSelectPreOrderItemSpecificationByItemId_Result>)CS_0024_003C_003E8__locals0._003C_003E4__this._db.WSspSelectPreOrderItemSpecificationByItemId(itemSpe.PreOrderItemID, CS_0024_003C_003E8__locals0.currLangID, CS_0024_003C_003E8__locals0.defLangID)))))
			{
				list3.AddRange(item3);
			}
			foreach (WSspSelectPreOrderItemSpecificationByItemId_Result item4 in list3)
			{
				if (CS_0024_003C_003E8__locals0.currLangID != 1065)
				{
					if (!string.IsNullOrEmpty(item4.RegisterDatePersian))
					{
						item4.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item4.RegisterDatePersian.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item4.FirstRegisterDatePersian))
					{
						item4.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(item4.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
					}
				}
			}
			parameters.ListPrintPreOrderItemSpecification = list3;
			List<WSspRpt_PrintPreOrderPayments_Result> list4 = new List<WSspRpt_PrintPreOrderPayments_Result>();
			foreach (List<WSspRpt_PrintPreOrderPayments_Result> item5 in Enumerable.Select<WSspRpt_PrintPreOrder_Result, List<WSspRpt_PrintPreOrderPayments_Result>>((IEnumerable<WSspRpt_PrintPreOrder_Result>)parameters.ListPrintPreOrder, (Func<WSspRpt_PrintPreOrder_Result, List<WSspRpt_PrintPreOrderPayments_Result>>)((WSspRpt_PrintPreOrder_Result itemSpe) => Enumerable.ToList<WSspRpt_PrintPreOrderPayments_Result>((IEnumerable<WSspRpt_PrintPreOrderPayments_Result>)CS_0024_003C_003E8__locals0._003C_003E4__this._db.WSspRpt_PrintPreOrderPayments(itemSpe.PreOrderID, CS_0024_003C_003E8__locals0.currLangID, CS_0024_003C_003E8__locals0.defLangID)))))
			{
				list4.AddRange(item5);
			}
			foreach (WSspRpt_PrintPreOrderPayments_Result item6 in list4)
			{
				if (CS_0024_003C_003E8__locals0.currLangID != 1065)
				{
					if (!string.IsNullOrEmpty(item6.RegisterDatePersian))
					{
						item6.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item6.RegisterDatePersian.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item6.ImportDate))
					{
						item6.ImportDate = PersianDate.GetShamsi2Miladi(item6.ImportDate.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item6.pordpayDocDate))
					{
						item6.pordpayDocDate = PersianDate.GetShamsi2Miladi(item6.pordpayDocDate.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item6.pordpayFirstRegisteDatePersian))
					{
						item6.pordpayFirstRegisteDatePersian = PersianDate.GetShamsi2Miladi(item6.pordpayFirstRegisteDatePersian.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item6.FirstRegisterDatePersian))
					{
						item6.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(item6.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrWhiteSpace(item6.pordpayVerifiedRegisterDatePersian))
					{
						item6.pordpayVerifiedRegisterDatePersian = PersianDate.GetShamsi2Miladi(item6.pordpayVerifiedRegisterDatePersian.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrWhiteSpace(item6.pordpayDocDateTemp))
					{
						item6.pordpayDocDateTemp = PersianDate.GetShamsi2Miladi(item6.pordpayDocDateTemp.Replace("/", "")).Replace("/", "");
					}
				}
				if (string.IsNullOrWhiteSpace(item6.pordpayLinkAccData))
				{
					continue;
				}
				List<PayLinkAccDataViewModel> list5 = new JavaScriptSerializer().Deserialize<List<PayLinkAccDataViewModel>>(item6.pordpayLinkAccData);
				if (list5 == null || !Enumerable.Any<PayLinkAccDataViewModel>((IEnumerable<PayLinkAccDataViewModel>)list5))
				{
					continue;
				}
				foreach (PayLinkAccDataViewModel vmLkAcc2 in list5)
				{
					vmLkAcc2.PayId = item6.PreOrderPaymentId;
					CRMspSelectLinkAccSettingDBIsActive_Result cRMspSelectLinkAccSettingDBIsActive_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)list, (Func<CRMspSelectLinkAccSettingDBIsActive_Result, bool>)((CRMspSelectLinkAccSettingDBIsActive_Result m) => m.LinkAccSettingDBId == vmLkAcc2.DBId.GetValueOrDefault()));
					if (cRMspSelectLinkAccSettingDBIsActive_Result != null)
					{
						vmLkAcc2.DbName = cRMspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbName ?? "";
						vmLkAcc2.DbTitle = cRMspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbTitle ?? "";
					}
				}
				parameters.NotUsed_ListPayLinkAccData.AddRange(list5);
			}
			parameters.ListPrintPreOrderPayments = list4;
			parameters.ListDyPrintCmpForm = new List<CRMspDyPrintCmpForm_Result>();
			parameters.ListDyPrintPrsForm = new List<CRMspDyPrintPrsForm_Result>();
			parameters.ListDyPrintPrjForm = new List<CRMspDyPrintPrjForm_Result>();
			parameters.ListDyPrintPordForm = new List<CRMspDyPrintPordForm_Result>();
			parameters.ListPrintProjectInformationTree = new List<CRMspPrintProjectInformationTree_Result>();
			if (CS_0024_003C_003E8__locals0.item != null)
			{
				if (CS_0024_003C_003E8__locals0.item.pordCompanyId.HasValue)
				{
					parameters.ListDyPrintCmpForm = Enumerable.ToList<CRMspDyPrintCmpForm_Result>((IEnumerable<CRMspDyPrintCmpForm_Result>)_db.CRMspDyPrintCmpForm(CS_0024_003C_003E8__locals0.item.pordCompanyId, CS_0024_003C_003E8__locals0.currLangID, CS_0024_003C_003E8__locals0.defLangID, userId, result));
				}
				if (CS_0024_003C_003E8__locals0.item.pordCompanyPersonId.HasValue)
				{
					parameters.ListDyPrintPrsForm = Enumerable.ToList<CRMspDyPrintPrsForm_Result>((IEnumerable<CRMspDyPrintPrsForm_Result>)_db.CRMspDyPrintPrsForm(CS_0024_003C_003E8__locals0.item.pordCompanyPersonId, CS_0024_003C_003E8__locals0.currLangID, CS_0024_003C_003E8__locals0.defLangID, userId, result));
				}
				if (CS_0024_003C_003E8__locals0.item.pordProjectId.HasValue)
				{
					parameters.ListDyPrintPrjForm = Enumerable.ToList<CRMspDyPrintPrjForm_Result>((IEnumerable<CRMspDyPrintPrjForm_Result>)_db.CRMspDyPrintPrjForm(CS_0024_003C_003E8__locals0.item.pordProjectId, CS_0024_003C_003E8__locals0.currLangID, CS_0024_003C_003E8__locals0.defLangID, userId, result));
					parameters.ListPrintProjectInformationTree = Enumerable.ToList<CRMspPrintProjectInformationTree_Result>((IEnumerable<CRMspPrintProjectInformationTree_Result>)_db.CRMspPrintProjectInformationTree(CS_0024_003C_003E8__locals0.item.pordProjectId, CS_0024_003C_003E8__locals0.currLangID, CS_0024_003C_003E8__locals0.defLangID));
				}
				parameters.ListDyPrintPordForm = Enumerable.ToList<CRMspDyPrintPordForm_Result>((IEnumerable<CRMspDyPrintPordForm_Result>)_db.CRMspDyPrintPordForm(CS_0024_003C_003E8__locals0.item.PreOrderID, CS_0024_003C_003E8__locals0.currLangID, CS_0024_003C_003E8__locals0.defLangID, userId, result));
			}
			parameters.SignatureReferUser = null;
			parameters.SignatureFirstUser = null;
			parameters.SignatureLastEditUser = null;
			parameters.SignatureVerifierUser = null;
			DbSet<UserSignature> userSignature = _dbTbl.UserSignature;
			ParameterExpression val = Expression.Parameter(typeof(UserSignature), "c");
			UserSignature userSignature2 = Queryable.FirstOrDefault<UserSignature>((IQueryable<UserSignature>)userSignature, Expression.Lambda<Func<UserSignature, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Convert((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), typeof(int?)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass26_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (userSignature2 != null && userSignature2.Signature != null && userSignature2.Signature.Length != 0)
			{
				parameters.SignatureReferUser = userSignature2.Signature;
			}
			DbSet<UserSignature> userSignature3 = _dbTbl.UserSignature;
			val = Expression.Parameter(typeof(UserSignature), "c");
			userSignature2 = Queryable.FirstOrDefault<UserSignature>((IQueryable<UserSignature>)userSignature3, Expression.Lambda<Func<UserSignature, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Convert((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), typeof(int?)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass26_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (userSignature2 != null && userSignature2.Signature != null && userSignature2.Signature.Length != 0)
			{
				parameters.SignatureFirstUser = userSignature2.Signature;
			}
			DbSet<UserSignature> userSignature4 = _dbTbl.UserSignature;
			val = Expression.Parameter(typeof(UserSignature), "c");
			userSignature2 = Queryable.FirstOrDefault<UserSignature>((IQueryable<UserSignature>)userSignature4, Expression.Lambda<Func<UserSignature, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass26_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (userSignature2 != null && userSignature2.Signature != null && userSignature2.Signature.Length != 0)
			{
				parameters.SignatureLastEditUser = userSignature2.Signature;
			}
			DbSet<UserSignature> userSignature5 = _dbTbl.UserSignature;
			val = Expression.Parameter(typeof(UserSignature), "c");
			userSignature2 = Queryable.FirstOrDefault<UserSignature>((IQueryable<UserSignature>)userSignature5, Expression.Lambda<Func<UserSignature, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Convert((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), typeof(int?)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass26_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (userSignature2 != null && userSignature2.Signature != null && userSignature2.Signature.Length != 0)
			{
				parameters.SignatureVerifierUser = userSignature2.Signature;
			}
			parameters.NotUsed_ListPrintPreOrderOrderVerificationRequestDetails = new List<WSspRpt_PrintVerificationRequestDetails_Result>();
			if (CS_0024_003C_003E8__locals0.item != null && CS_0024_003C_003E8__locals0.item.pordVerificationWorkFlowId.HasValue)
			{
				parameters.NotUsed_ListPrintPreOrderOrderVerificationRequestDetails = Enumerable.ToList<WSspRpt_PrintVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintVerificationRequestDetails_Result>)_dbI.WSspRpt_PrintVerificationRequestDetails(CS_0024_003C_003E8__locals0.item.PreOrderID, 10, CS_0024_003C_003E8__locals0.item.pordVerificationWorkFlowId, CS_0024_003C_003E8__locals0.currLangID, CS_0024_003C_003E8__locals0.defLangID));
				if (parameters.NotUsed_ListPrintPreOrderOrderVerificationRequestDetails != null && Enumerable.Any<WSspRpt_PrintVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintVerificationRequestDetails_Result>)parameters.NotUsed_ListPrintPreOrderOrderVerificationRequestDetails))
				{
					foreach (WSspRpt_PrintVerificationRequestDetails_Result notUsed_ListPrintPreOrderOrderVerificationRequestDetail in parameters.NotUsed_ListPrintPreOrderOrderVerificationRequestDetails)
					{
						if (CS_0024_003C_003E8__locals0.currLangID != 1065)
						{
							if (!string.IsNullOrEmpty(notUsed_ListPrintPreOrderOrderVerificationRequestDetail.VerifyDatePersian))
							{
								notUsed_ListPrintPreOrderOrderVerificationRequestDetail.VerifyDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintPreOrderOrderVerificationRequestDetail.VerifyDatePersian.Replace("/", "")).Replace("/", "");
							}
							if (!string.IsNullOrEmpty(notUsed_ListPrintPreOrderOrderVerificationRequestDetail.FirstRegisterDatePersian))
							{
								notUsed_ListPrintPreOrderOrderVerificationRequestDetail.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintPreOrderOrderVerificationRequestDetail.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
							}
							if (!string.IsNullOrEmpty(notUsed_ListPrintPreOrderOrderVerificationRequestDetail.RegisterDatePersian))
							{
								notUsed_ListPrintPreOrderOrderVerificationRequestDetail.RegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintPreOrderOrderVerificationRequestDetail.RegisterDatePersian.Replace("/", "")).Replace("/", "");
							}
							if (!string.IsNullOrEmpty(notUsed_ListPrintPreOrderOrderVerificationRequestDetail.VerificationReqDatePersian))
							{
								notUsed_ListPrintPreOrderOrderVerificationRequestDetail.VerificationReqDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintPreOrderOrderVerificationRequestDetail.VerificationReqDatePersian.Replace("/", "")).Replace("/", "");
							}
							if (!string.IsNullOrEmpty(notUsed_ListPrintPreOrderOrderVerificationRequestDetail.VerificationReqExpiredDatePersian))
							{
								notUsed_ListPrintPreOrderOrderVerificationRequestDetail.VerificationReqExpiredDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintPreOrderOrderVerificationRequestDetail.VerificationReqExpiredDatePersian.Replace("/", "")).Replace("/", "");
							}
						}
						if (notUsed_ListPrintPreOrderOrderVerificationRequestDetail.VerifyUserSignature != null)
						{
							notUsed_ListPrintPreOrderOrderVerificationRequestDetail.VerifyUserSignatureStr = Convert.ToBase64String(notUsed_ListPrintPreOrderOrderVerificationRequestDetail.VerifyUserSignature);
						}
					}
				}
			}
			if (parameters.NotUsed_ListPrintPreOrderOrderVerificationRequestDetails == null)
			{
				parameters.NotUsed_ListPrintPreOrderOrderVerificationRequestDetails = new List<WSspRpt_PrintVerificationRequestDetails_Result>();
			}
			parameters.NotUsed_ListPreOrderItemPrdPicture = new List<WSspRpt_PrintPreOrderItemPrdPicture_Result>();
			if (CS_0024_003C_003E8__locals0.item != null)
			{
				parameters.NotUsed_ListPreOrderItemPrdPicture = Enumerable.ToList<WSspRpt_PrintPreOrderItemPrdPicture_Result>((IEnumerable<WSspRpt_PrintPreOrderItemPrdPicture_Result>)_dbI.WSspRpt_PrintPreOrderItemPrdPicture(CS_0024_003C_003E8__locals0.item.PreOrderID, CS_0024_003C_003E8__locals0.currLangID, CS_0024_003C_003E8__locals0.defLangID));
			}
			if (parameters.NotUsed_ListPreOrderItemPrdPicture == null)
			{
				parameters.NotUsed_ListPreOrderItemPrdPicture = new List<WSspRpt_PrintPreOrderItemPrdPicture_Result>();
			}
			parameters.NotUsed_ListPreOrderDiscount = new List<WSspRpt_PrintPreOrderDiscounts_Result>();
			if (CS_0024_003C_003E8__locals0.item != null)
			{
				parameters.NotUsed_ListPreOrderDiscount = Enumerable.ToList<WSspRpt_PrintPreOrderDiscounts_Result>((IEnumerable<WSspRpt_PrintPreOrderDiscounts_Result>)_dbII.WSspRpt_PrintPreOrderDiscounts(CS_0024_003C_003E8__locals0.item.PreOrderID, CS_0024_003C_003E8__locals0.currLangID, CS_0024_003C_003E8__locals0.defLangID));
				if (parameters.NotUsed_ListPreOrderDiscount != null && Enumerable.Any<WSspRpt_PrintPreOrderDiscounts_Result>((IEnumerable<WSspRpt_PrintPreOrderDiscounts_Result>)parameters.NotUsed_ListPreOrderDiscount))
				{
					foreach (WSspRpt_PrintPreOrderDiscounts_Result item7 in parameters.NotUsed_ListPreOrderDiscount)
					{
						if (CS_0024_003C_003E8__locals0.currLangID != 1065)
						{
							if (!string.IsNullOrEmpty(item7.FirstRegisterDatePersian))
							{
								item7.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(item7.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
							}
							if (!string.IsNullOrEmpty(item7.RegisterDatePersian))
							{
								item7.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item7.RegisterDatePersian.Replace("/", "")).Replace("/", "");
							}
						}
					}
				}
			}
			if (parameters.NotUsed_ListPreOrderDiscount == null)
			{
				parameters.NotUsed_ListPreOrderDiscount = new List<WSspRpt_PrintPreOrderDiscounts_Result>();
			}
			string text5 = "";
			if (CS_0024_003C_003E8__locals0.item != null)
			{
				text5 = CS_0024_003C_003E8__locals0.item.pordLinkAccData ?? "";
			}
			else if (parameters.PrintPreOrder != null)
			{
				text5 = parameters.PrintPreOrder.pordLinkAccData ?? "";
			}
			if (!string.IsNullOrWhiteSpace(text5))
			{
				List<PordLinkAccDataViewModel> list6 = new JavaScriptSerializer().Deserialize<List<PordLinkAccDataViewModel>>(text5);
				if (list6 != null && Enumerable.Any<PordLinkAccDataViewModel>((IEnumerable<PordLinkAccDataViewModel>)list6))
				{
					foreach (PordLinkAccDataViewModel vmLkAcc in list6)
					{
						vmLkAcc.PordId = preOrderId;
						CRMspSelectLinkAccSettingDBIsActive_Result cRMspSelectLinkAccSettingDBIsActive_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)list, (Func<CRMspSelectLinkAccSettingDBIsActive_Result, bool>)((CRMspSelectLinkAccSettingDBIsActive_Result m) => m.LinkAccSettingDBId == vmLkAcc.DBId.GetValueOrDefault()));
						if (cRMspSelectLinkAccSettingDBIsActive_Result2 != null)
						{
							vmLkAcc.DbName = cRMspSelectLinkAccSettingDBIsActive_Result2.LinkAccSettingDbName ?? "";
							vmLkAcc.DbTitle = cRMspSelectLinkAccSettingDBIsActive_Result2.LinkAccSettingDbTitle ?? "";
						}
					}
					parameters.NotUsed_ListLinkAccData.AddRange(list6);
				}
			}
			if (parameters.NotUsed_ListLinkAccData == null)
			{
				parameters.NotUsed_ListLinkAccData = new List<PordLinkAccDataViewModel>();
			}
			if (parameters.NotUsed_ListPayLinkAccData == null)
			{
				parameters.NotUsed_ListPayLinkAccData = new List<PayLinkAccDataViewModel>();
			}
			if (parameters.NotUsed_ListCmpAllPayRemainLinkAccData == null)
			{
				parameters.NotUsed_ListCmpAllPayRemainLinkAccData = new List<CmpAccountingLinkAccDataViewModel>();
			}
			WSspReturnPrintFormatFileNameById_Result wSspReturnPrintFormatFileNameById_Result = Enumerable.FirstOrDefault<WSspReturnPrintFormatFileNameById_Result>((IEnumerable<WSspReturnPrintFormatFileNameById_Result>)Enumerable.ToList<WSspReturnPrintFormatFileNameById_Result>((IEnumerable<WSspReturnPrintFormatFileNameById_Result>)_db.WSspReturnPrintFormatFileNameById(CS_0024_003C_003E8__locals0.item.pordPrintFormatId)));
			if (wSspReturnPrintFormatFileNameById_Result != null)
			{
				text3 = wSspReturnPrintFormatFileNameById_Result.FileNameWeb;
			}
			if (string.IsNullOrEmpty(text3))
			{
				text3 = "PreOrderPrint.mrt";
			}
			XmlSerializer val2 = new XmlSerializer(typeof(Parameters));
			StringWriter stringWriter = new StringWriter();
			XmlWriter val3 = XmlWriter.Create((TextWriter)stringWriter);
			val2.Serialize(val3, (object)parameters);
			DataSet val4 = new DataSet();
			val4.ReadXmlSchema(text + "PreOrderPrint.xsd");
			XElement val5 = XElement.Parse(stringWriter.ToString());
			val4.ReadXml(((XNode)val5).CreateReader((ReaderOptions)0));
			int result5 = 0;
			if (wSspReturnPrintFormatFileNameById_Result != null)
			{
				int.TryParse(wSspReturnPrintFormatFileNameById_Result.CId.ToString(), out result5);
			}
			else
			{
				result5 = CRMIdeal.Classes.Helper.PrintFormat.GetPrintFormatCId(0, text3);
			}
			if (result5 != 0 && !string.IsNullOrWhiteSpace(text2))
			{
				if (!text2.EndsWith("/"))
				{
					text2 += "/";
				}
				text2 = text2 + result5 + "/";
			}
			stiReport.Load(text2 + text3);
			string text6 = "Integrated Security=False;Data Source={DBServer};Initial Catalog={DBName};Password={DBPass};User ID={DBUser}";
			text6 = text6.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
			text6 = text6.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
			text6 = text6.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
			text6 = text6.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
			((CollectionBase)stiReport.Dictionary.Databases).Clear();
			stiReport.Dictionary.Databases.Add(new StiSqlDatabase("CRMIdealExtra", text6));
			stiReport.Compile();
			stiReport.RegData(val4);
			stiReport.Render();
			string text7 = base.Server.MapPath(Configuration.HostTempFilesPath) + "\\Emails\\Files";
			StiJpegExportSettings stiJpegExportSettings = new StiJpegExportSettings
			{
				ImageResolution = 200
			};
			int currentPage = Enumerable.Count<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
			string text8 = text7 + "\\Pro_" + UserLogin.CurrentUser.UserId + "_" + preOrderId + ".pdf";
			string text9 = text7 + "\\Pro_Zip_" + UserLogin.CurrentUser.UserId + "_" + preOrderId;
			if (!System.IO.Directory.Exists(text9))
			{
				System.IO.Directory.CreateDirectory(text9);
				CRM.General.IO.Directory.SetFullControlForEveryOne(text9);
			}
			string file = text9 + "\\Pro_001.jpg";
			stiJpegExportSettings.PageRange = new StiPagesRange(currentPage);
			stiReport.ExportDocument(StiExportFormat.ImageJpeg, file, stiJpegExportSettings);
			string[] files = System.IO.Directory.GetFiles(text9);
			if (Enumerable.Any<string>((IEnumerable<string>)files))
			{
				PdfDocument pdfDocument = new PdfDocument();
				for (int i = 0; i < files.Length; i++)
				{
					PdfPage pdfPage = new PdfPage();
					StiPage stiPage = Enumerable.FirstOrDefault<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
					if (stiPage != null)
					{
						if (stiPage.Orientation == StiPageOrientation.Landscape)
						{
							pdfPage.Orientation = PageOrientation.Landscape;
						}
						try
						{
							PaperKind paperSize = stiPage.PaperSize;
							switch (paperSize - 8)
							{
							default:
								if ((int)paperSize != 66)
								{
									break;
								}
								pdfPage.Size = PageSize.A2;
								goto end_IL_1d94;
							case 0:
								pdfPage.Size = PageSize.A3;
								goto end_IL_1d94;
							case 1:
								pdfPage.Size = PageSize.A4;
								goto end_IL_1d94;
							case 3:
								pdfPage.Size = PageSize.A5;
								goto end_IL_1d94;
							case 4:
								pdfPage.Size = PageSize.B4;
								goto end_IL_1d94;
							case 5:
								pdfPage.Size = PageSize.B5;
								goto end_IL_1d94;
							case 2:
								break;
							}
							pdfPage.Size = PageSize.A4;
							end_IL_1d94:;
						}
						catch (Exception e2)
						{
							ErrorSignal.FromCurrentContext().Raise(e2);
							pdfPage.Size = PageSize.A4;
						}
					}
					pdfDocument.Pages.Add(pdfPage);
					XGraphics xGraphics = XGraphics.FromPdfPage(pdfDocument.Pages[i]);
					XImage xImage = XImage.FromFile(files[i]);
					xGraphics.DrawImage(xImage, 0.0, 0.0);
					xImage.Dispose();
					xGraphics.Dispose();
				}
				pdfDocument.Save(text8);
				pdfDocument.Close();
			}
			try
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(text9);
				FileInfo[] files2 = directoryInfo.GetFiles();
				for (int j = 0; j < files2.Length; j++)
				{
					files2[j].Delete();
				}
				DirectoryInfo[] directories = directoryInfo.GetDirectories();
				for (int j = 0; j < directories.Length; j++)
				{
					directories[j].Delete(recursive: true);
				}
				if (System.IO.Directory.Exists(text9))
				{
					System.IO.Directory.Delete(text9);
				}
			}
			catch (Exception e3)
			{
				ErrorSignal.FromCurrentContext().Raise(e3);
			}
			array[0] = text8;
			array[1] = "";
		}
		catch (Exception e4)
		{
			ErrorSignal.FromCurrentContext().Raise(e4);
		}
		finally
		{
			((Component)stiReport).Dispose();
		}
		return array;
	}

	[AjaxOnly]
	[HttpPost]
	public JsonResult SaveReasonGroup(int reasonGroupID, int firstGroupID, int companyID, int projectID, int preOrderID, int pordOrResId, string txtReason, string txtReason_Lang)
	{
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass27_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass27_0();
		CS_0024_003C_003E8__locals0.pordOrResId = pordOrResId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(txtReason_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(txtReason_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = txtReason,
			LanguageId = lCID
		});
		int num = 1;
		try
		{
			DateTime now = DateTime.Now;
			DbSet<WSPreOrderPrdGroupMustExistReasons> wSPreOrderPrdGroupMustExistReasons = _dbTbl.WSPreOrderPrdGroupMustExistReasons;
			ParameterExpression val = Expression.Parameter(typeof(WSPreOrderPrdGroupMustExistReasons), "c");
			WSPreOrderPrdGroupMustExistReasons wSPreOrderPrdGroupMustExistReasons2 = Queryable.FirstOrDefault<WSPreOrderPrdGroupMustExistReasons>((IQueryable<WSPreOrderPrdGroupMustExistReasons>)wSPreOrderPrdGroupMustExistReasons, Expression.Lambda<Func<WSPreOrderPrdGroupMustExistReasons, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass27_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (wSPreOrderPrdGroupMustExistReasons2 != null)
			{
				wSPreOrderPrdGroupMustExistReasons2.UserId = UserLogin.CurrentUser.UserId;
				wSPreOrderPrdGroupMustExistReasons2.RegisterDate = now;
				wSPreOrderPrdGroupMustExistReasons2.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				wSPreOrderPrdGroupMustExistReasons2.Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
				wSPreOrderPrdGroupMustExistReasons2.AppType = Configuration.AppType;
				wSPreOrderPrdGroupMustExistReasons2.PrdFirstGroupID = firstGroupID;
				wSPreOrderPrdGroupMustExistReasons2.PrdGroupMustExistReasonGroupId = reasonGroupID;
				wSPreOrderPrdGroupMustExistReasons2.CompanyId = companyID;
				wSPreOrderPrdGroupMustExistReasons2.cmpProjectId = projectID;
				wSPreOrderPrdGroupMustExistReasons2.PreOrderId = preOrderID;
				wSPreOrderPrdGroupMustExistReasons2.Reason = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_dbTbl.Entry(wSPreOrderPrdGroupMustExistReasons2).State = EntityState.Modified;
				_dbTbl.SaveChanges();
				using List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator();
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass27_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass27_1();
					CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
					CS_0024_003C_003E8__locals1.lang = enumerator.Current;
					DbSet<WSPreOrderPrdGroupMustExistReasons_Lang> wSPreOrderPrdGroupMustExistReasons_Lang = _dbTbl.WSPreOrderPrdGroupMustExistReasons_Lang;
					val = Expression.Parameter(typeof(WSPreOrderPrdGroupMustExistReasons_Lang), "c");
					WSPreOrderPrdGroupMustExistReasons_Lang wSPreOrderPrdGroupMustExistReasons_Lang2 = Queryable.FirstOrDefault<WSPreOrderPrdGroupMustExistReasons_Lang>((IQueryable<WSPreOrderPrdGroupMustExistReasons_Lang>)wSPreOrderPrdGroupMustExistReasons_Lang, Expression.Lambda<Func<WSPreOrderPrdGroupMustExistReasons_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass27_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass27_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					if (wSPreOrderPrdGroupMustExistReasons_Lang2 != null)
					{
						wSPreOrderPrdGroupMustExistReasons_Lang2.Reason = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
						_dbTbl.Entry(wSPreOrderPrdGroupMustExistReasons_Lang2).State = EntityState.Modified;
						_dbTbl.SaveChanges();
						continue;
					}
					wSPreOrderPrdGroupMustExistReasons_Lang2 = new WSPreOrderPrdGroupMustExistReasons_Lang();
					wSPreOrderPrdGroupMustExistReasons_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
					wSPreOrderPrdGroupMustExistReasons_Lang2.PrdGroupMustExistReasonId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.pordOrResId;
					wSPreOrderPrdGroupMustExistReasons_Lang2.Reason = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
					_dbTbl.WSPreOrderPrdGroupMustExistReasons_Lang.Add(wSPreOrderPrdGroupMustExistReasons_Lang2);
					_dbTbl.SaveChanges();
				}
			}
			else
			{
				wSPreOrderPrdGroupMustExistReasons2 = new WSPreOrderPrdGroupMustExistReasons();
				wSPreOrderPrdGroupMustExistReasons2.UserId = UserLogin.CurrentUser.UserId;
				wSPreOrderPrdGroupMustExistReasons2.RegisterDate = now;
				wSPreOrderPrdGroupMustExistReasons2.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				wSPreOrderPrdGroupMustExistReasons2.Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
				wSPreOrderPrdGroupMustExistReasons2.AppType = Configuration.AppType;
				wSPreOrderPrdGroupMustExistReasons2.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
				wSPreOrderPrdGroupMustExistReasons2.GUId = System.Guid.NewGuid();
				wSPreOrderPrdGroupMustExistReasons2.FPId = Financial.Get().Id;
				wSPreOrderPrdGroupMustExistReasons2.FirstRegisterDate = now;
				wSPreOrderPrdGroupMustExistReasons2.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				wSPreOrderPrdGroupMustExistReasons2.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
				wSPreOrderPrdGroupMustExistReasons2.PrdFirstGroupID = firstGroupID;
				wSPreOrderPrdGroupMustExistReasons2.PrdGroupMustExistReasonGroupId = reasonGroupID;
				wSPreOrderPrdGroupMustExistReasons2.CompanyId = companyID;
				wSPreOrderPrdGroupMustExistReasons2.cmpProjectId = projectID;
				wSPreOrderPrdGroupMustExistReasons2.PreOrderId = preOrderID;
				wSPreOrderPrdGroupMustExistReasons2.Reason = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				wSPreOrderPrdGroupMustExistReasons2.CId = PreOrder.GetPordCId(preOrderID);
				_dbTbl.WSPreOrderPrdGroupMustExistReasons.Add(wSPreOrderPrdGroupMustExistReasons2);
				_dbTbl.SaveChanges();
				foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
				{
					WSPreOrderPrdGroupMustExistReasons_Lang wSPreOrderPrdGroupMustExistReasons_Lang3 = new WSPreOrderPrdGroupMustExistReasons_Lang();
					wSPreOrderPrdGroupMustExistReasons_Lang3.LanguageID = lang.LanguageID;
					wSPreOrderPrdGroupMustExistReasons_Lang3.PrdGroupMustExistReasonId = wSPreOrderPrdGroupMustExistReasons2.PrdGroupMustExistReasonId;
					wSPreOrderPrdGroupMustExistReasons_Lang3.Reason = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
					_dbTbl.WSPreOrderPrdGroupMustExistReasons_Lang.Add(wSPreOrderPrdGroupMustExistReasons_Lang3);
					_dbTbl.SaveChanges();
				}
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			num = 0;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			num = 0;
		}
		JsonResult jsonResult = Json(num, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public string IssueDuplicatePreOrder(int pordId)
	{
		_003C_003Ec__DisplayClass28_0 _003C_003Ec__DisplayClass28_ = new _003C_003Ec__DisplayClass28_0();
		_003C_003Ec__DisplayClass28_.pordId = pordId;
		string text = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmPreOrder", "actInsertDupPord", currentUser))
			{
				return Messages.ErrorNotAccess + "|";
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			int? centerId = null;
			if (currentUser != null)
			{
				centerId = currentUser.UserLastCId;
			}
			if (_003C_003Ec__DisplayClass28_.pordId > 0)
			{
				int num = 0;
				DbSet<WSPreOrder> wSPreOrder = _dbTbl.WSPreOrder;
				ParameterExpression val = Expression.Parameter(typeof(WSPreOrder), "m");
				if (Queryable.FirstOrDefault<WSPreOrder>((IQueryable<WSPreOrder>)wSPreOrder, Expression.Lambda<Func<WSPreOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass28_, typeof(_003C_003Ec__DisplayClass28_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
				{
					int userId = UserLogin.CurrentUser.UserId;
					DateTime now = DateTime.Now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					ObjectParameter objectParameter = new ObjectParameter("InsertedPreOrderId", 0);
					ObjectParameter objectParameter2 = new ObjectParameter("InsertedPordNumber", typeof(long));
					ObjectParameter objectParameter3 = new ObjectParameter("InsertedPordNumberRevision", typeof(long));
					ObjectParameter objectParameter4 = new ObjectParameter("ErrorMessage", "");
					objectParameter.Value = 0;
					objectParameter2.Value = 0;
					objectParameter3.Value = 0;
					Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_db.WSspIssueDuplicatePreOrder(_003C_003Ec__DisplayClass28_.pordId, userId, value, now, registerDatePersian, appType, objectParameter, objectParameter2, objectParameter3, objectParameter4, centerId));
					if (objectParameter4.Value != null)
					{
						if (!string.IsNullOrEmpty(objectParameter4.Value.ToString()))
						{
							text = objectParameter4.Value.ToString();
						}
						else
						{
							string text2 = "";
							string text3 = "";
							string text4 = "";
							if (objectParameter.Value != null)
							{
								text4 = objectParameter.Value.ToString() ?? "";
							}
							if (objectParameter2.Value != null)
							{
								text2 = objectParameter2.Value.ToString() ?? "";
							}
							if (objectParameter3.Value != null)
							{
								text3 = objectParameter3.Value.ToString() ?? "";
							}
							text = "1|" + text4 + "," + text2 + "," + text3;
							num = int.Parse(text4);
						}
					}
					else
					{
						string text5 = "";
						string text6 = "";
						string text7 = "";
						if (objectParameter.Value != null)
						{
							text7 = objectParameter.Value.ToString() ?? "";
						}
						if (objectParameter2.Value != null)
						{
							text5 = objectParameter2.Value.ToString() ?? "";
						}
						if (objectParameter3.Value != null)
						{
							text6 = objectParameter3.Value.ToString() ?? "";
						}
						text = "1|" + text7 + "," + text5 + "," + text6;
						num = int.Parse(text7);
					}
					if (num > 0 && VersionBuyer.AttachFiles)
					{
						FilesManager filesManager = new FilesManager();
						FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
						string pathFtp = Configuration.PathFtp;
						string userNameFtp = Configuration.UserNameFtp;
						string passwordFtp = Configuration.PasswordFtp;
						bool usePassiveFtp = Configuration.UsePassiveFtp;
						List<CRMspSelectFilesDirectory_Result> list = Files.SelectFilesDirectory("", "", "", "10", num.ToString(), "0", "0", false);
						if (list != null && Enumerable.Any<CRMspSelectFilesDirectory_Result>((IEnumerable<CRMspSelectFilesDirectory_Result>)list))
						{
							using List<CRMspSelectFilesDirectory_Result>.Enumerator enumerator = list.GetEnumerator();
							while (enumerator.MoveNext())
							{
								_003C_003Ec__DisplayClass28_1 _003C_003Ec__DisplayClass28_2 = new _003C_003Ec__DisplayClass28_1();
								_003C_003Ec__DisplayClass28_2.item = enumerator.Current;
								string text8 = "";
								string text9 = "";
								if (string.IsNullOrEmpty(_003C_003Ec__DisplayClass28_2.item.FilePath) || string.IsNullOrEmpty(_003C_003Ec__DisplayClass28_2.item.FileName))
								{
									continue;
								}
								string[] array = _003C_003Ec__DisplayClass28_2.item.FileName.Split(new char[1] { '.' });
								string text10 = _003C_003Ec__DisplayClass28_2.item.FilePath.Replace(_003C_003Ec__DisplayClass28_2.item.FileName, "");
								text10 += (text10.EndsWith("/") ? "" : "/");
								string text11 = text10.Split(new char[1] { '/' })[^2];
								string text12 = text10.Replace(text11 + "/", "");
								string text13 = _003C_003Ec__DisplayClass28_2.item.FilePath.ToLower().Replace(Configuration.PathFtp.ToLower(), "");
								text13 = Configuration.MainDirectoryPath + _003C_003Ec__DisplayClass28_2.item.FolderName + "/" + _003C_003Ec__DisplayClass28_2.item.FileName;
								if (text13 != "")
								{
									text8 = filesManager.SetNameDirectory(UserLogin.CurrentUser.UserId);
									if (filesManager.CreateDirectory(text8))
									{
										text9 = HttpContext.Current.Server.MapPath(text8 + "/" + _003C_003Ec__DisplayClass28_2.item.FileName);
										if (!facadeFTP.Download(pathFtp, userNameFtp, passwordFtp, text9, text13, overwrite: true, usePassiveFtp))
										{
											if (!string.IsNullOrEmpty(text9))
											{
												text9 = HttpContext.Current.Server.MapPath(text8 + "/");
												if (System.IO.Directory.Exists(text9))
												{
													DirectoryInfo directoryInfo = new DirectoryInfo(text9);
													FileInfo[] files = directoryInfo.GetFiles();
													for (int i = 0; i < files.Length; i++)
													{
														files[i].Delete();
													}
													DirectoryInfo[] directories = directoryInfo.GetDirectories();
													for (int i = 0; i < directories.Length; i++)
													{
														directories[i].Delete(recursive: true);
													}
													if (System.IO.Directory.Exists(text9))
													{
														System.IO.Directory.Delete(text9);
													}
												}
											}
											text9 = "";
											try
											{
												_db.CRMspDeleteCrmFilesDirectory(_003C_003Ec__DisplayClass28_2.item.FileDirectoryID);
											}
											catch (Exception e)
											{
												ErrorSignal.FromCurrentContext().Raise(e);
											}
										}
									}
								}
								if (!string.IsNullOrEmpty(text9))
								{
									bool flag = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text12, text11, usePassiveFtp);
									if (!flag)
									{
										flag = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text12, text11, usePassiveFtp);
									}
									if (flag)
									{
										string text14 = _003C_003Ec__DisplayClass28_2.item.TypeOprObjectId + "-" + _003C_003Ec__DisplayClass28_2.item.FileDirectoryID + "." + array[^1];
										if (facadeFTP.UploadFtpFormTable(pathFtp, userNameFtp, passwordFtp, text10 + text14, text9, usePassiveFtp))
										{
											string text15 = Configuration.PathFtp + text10 + text14;
											string fileName = text14;
											DbSet<CrmFilesDirectory> crmFilesDirectory = _dbTbl.CrmFilesDirectory;
											val = Expression.Parameter(typeof(CrmFilesDirectory), "m");
											CrmFilesDirectory crmFilesDirectory2 = Queryable.FirstOrDefault<CrmFilesDirectory>((IQueryable<CrmFilesDirectory>)crmFilesDirectory, Expression.Lambda<Func<CrmFilesDirectory, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass28_2, typeof(_003C_003Ec__DisplayClass28_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
											if (crmFilesDirectory2 != null)
											{
												text15 = text15.Trim().Replace(Configuration.PathFtp, "");
												crmFilesDirectory2.FilePath = text15;
												crmFilesDirectory2.FileName = fileName;
												_dbTbl.Entry(crmFilesDirectory2).State = EntityState.Modified;
												_dbTbl.SaveChanges();
											}
											if (string.IsNullOrEmpty(text9))
											{
												continue;
											}
											text9 = HttpContext.Current.Server.MapPath(text8 + "/");
											if (System.IO.Directory.Exists(text9))
											{
												DirectoryInfo directoryInfo2 = new DirectoryInfo(text9);
												FileInfo[] files = directoryInfo2.GetFiles();
												for (int i = 0; i < files.Length; i++)
												{
													files[i].Delete();
												}
												DirectoryInfo[] directories = directoryInfo2.GetDirectories();
												for (int i = 0; i < directories.Length; i++)
												{
													directories[i].Delete(recursive: true);
												}
												if (System.IO.Directory.Exists(text9))
												{
													System.IO.Directory.Delete(text9);
												}
											}
											continue;
										}
										Exception e2 = new Exception(Messages.msgErrorUploadingFileInFtp + "  -  hostname: " + Configuration.PathFtp + " ,username: " + Configuration.UserNameFtp + " ,destination: " + text12 + " ,directoryName: " + text11);
										ErrorSignal.FromCurrentContext().Raise(e2);
										text = text + "|" + Messages.frmErrorInSendingFile;
										try
										{
											_db.CRMspDeleteCrmFilesDirectory(_003C_003Ec__DisplayClass28_2.item.FileDirectoryID);
										}
										catch (Exception e3)
										{
											ErrorSignal.FromCurrentContext().Raise(e3);
										}
										if (string.IsNullOrEmpty(text9))
										{
											continue;
										}
										text9 = HttpContext.Current.Server.MapPath(text8 + "/");
										if (System.IO.Directory.Exists(text9))
										{
											DirectoryInfo directoryInfo3 = new DirectoryInfo(text9);
											FileInfo[] files = directoryInfo3.GetFiles();
											for (int i = 0; i < files.Length; i++)
											{
												files[i].Delete();
											}
											DirectoryInfo[] directories = directoryInfo3.GetDirectories();
											for (int i = 0; i < directories.Length; i++)
											{
												directories[i].Delete(recursive: true);
											}
											if (System.IO.Directory.Exists(text9))
											{
												System.IO.Directory.Delete(text9);
											}
										}
										continue;
									}
									Exception e4 = new Exception(Messages.msgErrorUploadingFileInFtp + " -  hostname: " + Configuration.PathFtp + " ,username: " + Configuration.UserNameFtp + " ,destination: " + text12 + " ,directoryName: " + text11);
									ErrorSignal.FromCurrentContext().Raise(e4);
									text = text + "|" + Messages.frmErrorInSendingFile;
									try
									{
										_db.CRMspDeleteCrmFilesDirectory(_003C_003Ec__DisplayClass28_2.item.FileDirectoryID);
									}
									catch (Exception e5)
									{
										ErrorSignal.FromCurrentContext().Raise(e5);
									}
									if (string.IsNullOrEmpty(text9))
									{
										continue;
									}
									text9 = HttpContext.Current.Server.MapPath(text8 + "/");
									if (System.IO.Directory.Exists(text9))
									{
										DirectoryInfo directoryInfo4 = new DirectoryInfo(text9);
										FileInfo[] files = directoryInfo4.GetFiles();
										for (int i = 0; i < files.Length; i++)
										{
											files[i].Delete();
										}
										DirectoryInfo[] directories = directoryInfo4.GetDirectories();
										for (int i = 0; i < directories.Length; i++)
										{
											directories[i].Delete(recursive: true);
										}
										if (System.IO.Directory.Exists(text9))
										{
											System.IO.Directory.Delete(text9);
										}
									}
								}
								else
								{
									try
									{
										_db.CRMspDeleteCrmFilesDirectory(_003C_003Ec__DisplayClass28_2.item.FileDirectoryID);
									}
									catch (Exception e6)
									{
										ErrorSignal.FromCurrentContext().Raise(e6);
									}
									text = text + "|" + Messages.frmErrorInSendingFile;
								}
							}
						}
					}
					else if (num > 0 && !VersionBuyer.AttachFiles)
					{
						List<CRMspSelectFilesDirectory_Result> list2 = Files.SelectFilesDirectory("", "", "", "10", num.ToString(), "0", "0", false);
						if (list2 != null && Enumerable.Any<CRMspSelectFilesDirectory_Result>((IEnumerable<CRMspSelectFilesDirectory_Result>)list2))
						{
							foreach (CRMspSelectFilesDirectory_Result item in list2)
							{
								try
								{
									_db.CRMspDeleteCrmFilesDirectory(item.FileDirectoryID);
								}
								catch (Exception e7)
								{
									ErrorSignal.FromCurrentContext().Raise(e7);
								}
							}
						}
					}
				}
				else
				{
					text = Messages.ErrorNotFound + "|";
				}
			}
			else
			{
				text = Messages.ErrorNotFound + "|";
			}
		}
		catch (Exception e8)
		{
			ErrorSignal.FromCurrentContext().Raise(e8);
			text = Messages.msgErrorRunFunction + "|";
		}
		return text;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actRemoveProductWithLinked")]
	public string RemoveProductWithLinked(int pordId, int pordItemId)
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
			if (!UserLogin.IsUserAccess("frmPreOrder", "actRemoveProductWithLinked", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			if (PreOrder.IsFixed(pordId))
			{
				return Messages.msgErrorNotActiveProd;
			}
			if (PreOrder.IsSentToLinkAccByAction(pordId))
			{
				string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
				return string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
			}
			if (pordItemId > 0)
			{
				try
				{
					mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.WSspDeletePreOrderItemWithLinkedPrd(pordId, pordItemId));
					if (mct_I_Result != null && mct_I_Result.Result > 0)
					{
						result = (PreOrder.CalcAndSetPreOrderAmounts(pordId) ? "1" : Messages.msgErrorInCalculation);
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

	public string GetPordFOLink(int pordId = 0)
	{
		return JsonConvert.SerializeObject(PreOrder.GetPordExternalLinks(pordId));
	}

	public string GetPordFOShortLink(int pordId = 0)
	{
		return JsonConvert.SerializeObject(PreOrder.GetPordFoShortLinks(pordId));
	}

	[AjaxOnly]
	public string IsFixed(int pordId)
	{
		string result = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmPreOrder", "actIsFixed", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			_dbII.WSspPreOrderIsFixed(pordId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	[AjaxOnly]
	public string ExitIsFixed(int pordId)
	{
		string result = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmPreOrder", "actExitIsFixed", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			if (PreOrder.IsVerified(pordId))
			{
				return string.Format(Messages.msgErrorNotExitIsFixedAfterVerify, Labels.lblPOrd);
			}
			_dbII.WSspPreOrderIsFixedExit(pordId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	[AjaxOnly]
	public string CalcAndUpdateDiscountPolicy(int pordId)
	{
		string text = "";
		_ = UserLogin.CurrentUser;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			if (pordId != 0)
			{
				if (PreOrder.IsFixed(pordId))
				{
					return Messages.msgErrorNotActiveProd;
				}
				if (PreOrder.IsSentToLinkAccByAction(pordId))
				{
					string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
					return string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
				}
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				int id = Financial.Get().Id;
				int userId = UserLogin.CurrentUser.UserId;
				ObjectParameter objectParameter = new ObjectParameter("Result", typeof(int));
				List<WSspCalcAndUpdateDiscountPolicyInPordItems_Result> list = Enumerable.ToList<WSspCalcAndUpdateDiscountPolicyInPordItems_Result>((IEnumerable<WSspCalcAndUpdateDiscountPolicyInPordItems_Result>)_dbII.WSspCalcAndUpdateDiscountPolicyInPordItems(pordId, value, userId, id, value2, value, registerDatePersian, appType, lCID, result, objectParameter));
				int result2 = 0;
				if (objectParameter != null && objectParameter.Value != null)
				{
					int.TryParse(objectParameter.Value.ToString(), out result2);
				}
				switch (result2)
				{
				case 1:
				{
					string text2 = "";
					if (list != null && Enumerable.Any<WSspCalcAndUpdateDiscountPolicyInPordItems_Result>((IEnumerable<WSspCalcAndUpdateDiscountPolicyInPordItems_Result>)list))
					{
						foreach (WSspCalcAndUpdateDiscountPolicyInPordItems_Result item in list)
						{
							if (!string.IsNullOrWhiteSpace(item.DPTitle))
							{
								if (!string.IsNullOrWhiteSpace(text2))
								{
									text2 += "<br>";
								}
								text2 += item.DPTitle;
							}
						}
					}
					return "1|" + string.Format(Messages.msgCalcAdnUpdateDiscounPolicyOnItem, Labels.lblPOrd, text2);
				}
				case 2:
					return string.Format(Messages.msgErrorNotFindDiscoutPolicyOnItem, Labels.lblPOrd);
				default:
					return string.Format(Messages.msgErrorCalcAndUpdateDiscountPolicyOnItem, Labels.lblPOrd);
				}
			}
			return Messages.ErrorNotFound;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.msgErrorRunFunction;
		}
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbLink.Dispose();
		_dbI.Dispose();
		_dbII.Dispose();
		_dbIII.Dispose();
		base.Dispose(disposing);
	}

	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(int id = 0, string itemsAmount = "", string parameters = "")
	{
		_003C_003Ec__DisplayClass36_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass36_0();
		CS_0024_003C_003E8__locals0.id = id;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		int? num = null;
		if (UserLogin.CurrentUser != null)
		{
			num = UserLogin.CurrentUser.UserLastCId;
		}
		string[] array = parameters.Split(new char[1] { '|' });
		base.ViewBag.MyParameters = array;
		decimal result2 = default(decimal);
		string text = "";
		string text2 = "";
		WSPreOrderLanguageViewModel wSPreOrderLanguageViewModel = new WSPreOrderLanguageViewModel();
		List<CRMspSelectCompanyTitle_Result> list = Enumerable.ToList<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)_db.CRMspSelectCompanyTitle(CS_0024_003C_003E8__locals0.currLangID, result));
		if (CS_0024_003C_003E8__locals0.id > 0)
		{
			if (!UserLogin.IsUserAccess("frmPreOrder", "actEdit"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			DbSet<WSPreOrder_Lang> wSPreOrder_Lang = _dbTbl.WSPreOrder_Lang;
			ParameterExpression val = Expression.Parameter(typeof(WSPreOrder_Lang), "c");
			List<WSPreOrder_Lang> list2 = Enumerable.ToList<WSPreOrder_Lang>((IEnumerable<WSPreOrder_Lang>)Queryable.Where<WSPreOrder_Lang>((IQueryable<WSPreOrder_Lang>)wSPreOrder_Lang, Expression.Lambda<Func<WSPreOrder_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass36_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			DbSet<WSPreOrder> wSPreOrder = _dbTbl.WSPreOrder;
			val = Expression.Parameter(typeof(WSPreOrder), "c");
			WSPreOrder wSPreOrder2 = Queryable.FirstOrDefault<WSPreOrder>((IQueryable<WSPreOrder>)wSPreOrder, Expression.Lambda<Func<WSPreOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass36_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (wSPreOrder2 == null)
			{
				base.ViewBag.Error = Messages.ErrorNotFound;
				return null;
			}
			if (PreOrder.IsEditAfterFix(wSPreOrder2.pordEditAfterFixInfoJs, wSPreOrder2.PreOrderID, 1))
			{
				wSPreOrder2.pordIsFixed = false;
			}
			if (wSPreOrder2.pordIsFixed.HasValue && wSPreOrder2.pordIsFixed.GetValueOrDefault())
			{
				base.ViewBag.Error = Messages.msgErrorNotActiveProd;
				return null;
			}
			if (itemsAmount.Trim() != "")
			{
				itemsAmount = itemsAmount.Replace(",", "").Replace("،", "");
				decimal.TryParse(itemsAmount, out result2);
			}
			CRMspSelectCompanyById_Result cmp2 = CRMIdeal.Classes.Helper.Company.GetCompanyById(wSPreOrder2.pordCompanyId.GetValueOrDefault());
			if (cmp2 != null)
			{
				text = ((Enumerable.FirstOrDefault<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)list, (Func<CRMspSelectCompanyTitle_Result, bool>)((CRMspSelectCompanyTitle_Result c) => c.CompanyTitleID == cmp2.cmpTitleId)) != null) ? (Enumerable.FirstOrDefault<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)list, (Func<CRMspSelectCompanyTitle_Result, bool>)((CRMspSelectCompanyTitle_Result c) => c.CompanyTitleID == cmp2.cmpTitleId)).CompanyTitle + " ") : "") + cmp2.cmpName;
				text2 = cmp2.cmpAddress;
			}
			List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrder_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrder_Lang>)list2, (Func<WSPreOrder_Lang, CommonMultiLanguageViewModel>)((WSPreOrder_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.pordTitle,
				LanguageId = item.LanguageID
			})));
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = wSPreOrder2.pordTitle,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrder_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrder_Lang>)list2, (Func<WSPreOrder_Lang, CommonMultiLanguageViewModel>)((WSPreOrder_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.pordSubject,
				LanguageId = item.LanguageID
			})));
			list4.Add(new CommonMultiLanguageViewModel
			{
				Value = wSPreOrder2.pordSubject,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list5 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrder_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrder_Lang>)list2, (Func<WSPreOrder_Lang, CommonMultiLanguageViewModel>)((WSPreOrder_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.pordTotalAmountStr,
				LanguageId = item.LanguageID
			})));
			list5.Add(new CommonMultiLanguageViewModel
			{
				Value = wSPreOrder2.pordTotalAmountStr,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list6 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrder_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrder_Lang>)list2, (Func<WSPreOrder_Lang, CommonMultiLanguageViewModel>)((WSPreOrder_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.pordSpecialWord,
				LanguageId = item.LanguageID
			})));
			list6.Add(new CommonMultiLanguageViewModel
			{
				Value = wSPreOrder2.pordSpecialWord,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list7 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrder_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrder_Lang>)list2, (Func<WSPreOrder_Lang, CommonMultiLanguageViewModel>)((WSPreOrder_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.pordDescriptionI,
				LanguageId = item.LanguageID
			})));
			list7.Add(new CommonMultiLanguageViewModel
			{
				Value = wSPreOrder2.pordDescriptionI,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list8 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrder_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrder_Lang>)list2, (Func<WSPreOrder_Lang, CommonMultiLanguageViewModel>)((WSPreOrder_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.pordDescriptionII,
				LanguageId = item.LanguageID
			})));
			list8.Add(new CommonMultiLanguageViewModel
			{
				Value = wSPreOrder2.pordDescriptionII,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list9 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrder_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrder_Lang>)list2, (Func<WSPreOrder_Lang, CommonMultiLanguageViewModel>)((WSPreOrder_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.pordSigningI,
				LanguageId = item.LanguageID
			})));
			list9.Add(new CommonMultiLanguageViewModel
			{
				Value = wSPreOrder2.pordSigningI,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list10 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrder_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrder_Lang>)list2, (Func<WSPreOrder_Lang, CommonMultiLanguageViewModel>)((WSPreOrder_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.pordSigningII,
				LanguageId = item.LanguageID
			})));
			list10.Add(new CommonMultiLanguageViewModel
			{
				Value = wSPreOrder2.pordSigningII,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list11 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrder_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrder_Lang>)list2, (Func<WSPreOrder_Lang, CommonMultiLanguageViewModel>)((WSPreOrder_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.pordSigningIII,
				LanguageId = item.LanguageID
			})));
			list11.Add(new CommonMultiLanguageViewModel
			{
				Value = wSPreOrder2.pordSigningIII,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list12 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrder_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrder_Lang>)list2, (Func<WSPreOrder_Lang, CommonMultiLanguageViewModel>)((WSPreOrder_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.pordAddress,
				LanguageId = item.LanguageID
			})));
			list12.Add(new CommonMultiLanguageViewModel
			{
				Value = wSPreOrder2.pordAddress,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list13 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrder_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrder_Lang>)list2, (Func<WSPreOrder_Lang, CommonMultiLanguageViewModel>)((WSPreOrder_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.pordDiscountTitle,
				LanguageId = item.LanguageID
			})));
			list13.Add(new CommonMultiLanguageViewModel
			{
				Value = wSPreOrder2.pordDiscountTitle,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list14 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrder_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrder_Lang>)list2, (Func<WSPreOrder_Lang, CommonMultiLanguageViewModel>)((WSPreOrder_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.pordcmpTitle,
				LanguageId = item.LanguageID
			})));
			list14.Add(new CommonMultiLanguageViewModel
			{
				Value = wSPreOrder2.pordcmpTitle,
				LanguageId = result
			});
			wSPreOrderLanguageViewModel = new WSPreOrderLanguageViewModel
			{
				LanguageID = wSPreOrder2.LanguageID,
				UserId = wSPreOrder2.UserId,
				FirstRegisterUserId = wSPreOrder2.FirstRegisterUserId,
				FirstRegisterDate = wSPreOrder2.FirstRegisterDate,
				FirstRegisterDatePersian = wSPreOrder2.FirstRegisterDatePersian,
				pordFirstRegisterUserId = wSPreOrder2.pordFirstRegisterUserId,
				RegisterDate = wSPreOrder2.RegisterDate,
				RegisterDatePersian = wSPreOrder2.RegisterDatePersian,
				pordVerifiedRegisterDate = wSPreOrder2.pordVerifiedRegisterDate,
				pordVerifiedRegisterDatePersian = wSPreOrder2.pordVerifiedRegisterDatePersian,
				FPId = wSPreOrder2.FPId,
				Month1 = wSPreOrder2.Month1,
				AppType = wSPreOrder2.AppType,
				GUId = wSPreOrder2.GUId,
				PreOrderID = wSPreOrder2.PreOrderID,
				PreOrderOprID = wSPreOrder2.PreOrderOprID,
				pordAccountNumberI = wSPreOrder2.pordAccountNumberI,
				pordAccountNumberII = wSPreOrder2.pordAccountNumberII,
				pordAccountShabaNumberI = wSPreOrder2.pordAccountShabaNumberI,
				pordAccountShabaNumberII = wSPreOrder2.pordAccountShabaNumberII,
				pordCalculateTax = wSPreOrder2.pordCalculateTax,
				pordCompanyId = wSPreOrder2.pordCompanyId,
				pordCompanyPersonId = wSPreOrder2.pordCompanyPersonId,
				pordCreditDurationId = wSPreOrder2.pordCreditDurationId,
				pordDate = (wSPreOrder2.pordDateTime.HasValue ? wSPreOrder2.pordDateTime.Value.ToString("yyyy/MM/dd") : ""),
				pordDateTime = wSPreOrder2.pordDateTime,
				pordDay = wSPreOrder2.pordDay,
				pordDeliveryDate = (wSPreOrder2.pordDeliveryDateTime.HasValue ? wSPreOrder2.pordDeliveryDateTime.Value.ToString("yyyy/MM/dd") : ""),
				pordDeliveryDateTime = wSPreOrder2.pordDeliveryDateTime,
				pordImportDate = wSPreOrder2.pordImportDate,
				pordImportDateTime = wSPreOrder2.pordImportDateTime,
				pordDeliveryTime = wSPreOrder2.pordDeliveryTime,
				pordDeliveryTimeId = wSPreOrder2.pordDeliveryTimeId,
				pordTime = wSPreOrder2.pordTime,
				pordDescriptionId = wSPreOrder2.pordDescriptionId,
				pordDiscount = wSPreOrder2.pordDiscount,
				pordDiscountPercent = wSPreOrder2.pordDiscountPercent,
				pordEmail = wSPreOrder2.pordEmail,
				pordFax = wSPreOrder2.pordFax,
				pordGuarantyId = wSPreOrder2.pordGuarantyId,
				pordRound = wSPreOrder2.pordRound,
				pordInstallAmount = wSPreOrder2.pordInstallAmount,
				pordIsFixed = wSPreOrder2.pordIsFixed,
				pordIsVerified = wSPreOrder2.pordIsVerified,
				pordItemCount = wSPreOrder2.pordItemCount,
				pordItemsAmount = wSPreOrder2.pordItemsAmount,
				pordLLogoId = wSPreOrder2.pordLLogoId,
				pordNumber = wSPreOrder2.pordNumber,
				pordPayConditionId = wSPreOrder2.pordPayConditionId,
				pordPrintFormatId = wSPreOrder2.pordPrintFormatId,
				pordProjectId = wSPreOrder2.pordProjectId,
				pordRLogoId = wSPreOrder2.pordRLogoId,
				pordReferUserId = wSPreOrder2.pordReferUserId,
				pordSignatureId = wSPreOrder2.pordSignatureId,
				pordStatusId = wSPreOrder2.pordStatusId,
				pordSumAmount = wSPreOrder2.pordSumAmount,
				pordTax = wSPreOrder2.pordTax,
				pordTaxIndex = wSPreOrder2.pordTaxIndex,
				pordTelephone = wSPreOrder2.pordTelephone,
				pordTotalAmount = wSPreOrder2.pordTotalAmount,
				pordTransportation = wSPreOrder2.pordTransportation,
				pordVerifierRequestId = wSPreOrder2.pordVerifierRequestId,
				pordVerifierId = wSPreOrder2.pordVerifierId,
				pordWebSite = wSPreOrder2.pordWebSite,
				pordTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				pordTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				pordSubject = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				pordSubject_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				pordTotalAmountStr = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				pordTotalAmountStr_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				pordSpecialWord = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				pordSpecialWord_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				pordDescriptionI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				pordDescriptionI_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				pordDescriptionII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				pordDescriptionII_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				pordSigningI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				pordSigningI_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				pordSigningII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				pordSigningII_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				pordSigningIII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				pordSigningIII_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				pordAddress = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				pordAddress_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				pordDiscountTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				pordDiscountTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				pordcmpTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				pordcmpTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				pordVerificationWorkFlowId = wSPreOrder2.pordVerificationWorkFlowId,
				pordExpireDate = (wSPreOrder2.pordExpireDateTime.HasValue ? wSPreOrder2.pordExpireDateTime.Value.ToString("yyyy/MM/dd") : ""),
				pordExpireDateTime = wSPreOrder2.pordExpireDateTime,
				pordExpireTime = (wSPreOrder2.pordExpireDateTime.HasValue ? wSPreOrder2.pordExpireDateTime.Value.ToString("HH:mm") : ""),
				pordCurrencyUnitId = wSPreOrder2.pordCurrencyUnitId,
				pordCurrencyUnitIdI = wSPreOrder2.pordCurrencyUnitIdI,
				pordCurrencyUnitIRate = wSPreOrder2.pordCurrencyUnitIRate,
				pordNumberRevision = wSPreOrder2.pordNumberRevision,
				pordDeliveryTermId = wSPreOrder2.pordDeliveryTermId,
				pordDeliveryEndDate = (wSPreOrder2.pordDeliveryEndDateTime.HasValue ? wSPreOrder2.pordDeliveryEndDateTime.Value.ToString("yyyy/MM/dd") : ""),
				pordDeliveryEndDateTime = wSPreOrder2.pordDeliveryEndDateTime,
				pordDeliveryEndTime = wSPreOrder2.pordDeliveryEndTime,
				pordNumRef = wSPreOrder2.pordNumRef,
				pordTypeId = wSPreOrder2.pordTypeId,
				pordDefWHId = wSPreOrder2.pordDefWHId,
				pordDefPrdPriceGroupId = wSPreOrder2.pordDefPrdPriceGroupId,
				pordSellerId = wSPreOrder2.pordSellerId,
				pordEmailUsersInfoId = wSPreOrder2.pordEmailUsersInfoId,
				pordEmailUserDefaultSettingId = wSPreOrder2.pordEmailUserDefaultSettingId,
				pordSaleCenterId = wSPreOrder2.pordSaleCenterId,
				pordDefPayTypeId = wSPreOrder2.pordDefPayTypeId,
				pordDeadlineDate = wSPreOrder2.pordDeadlineDate,
				pordDeadlineDatePersian = (wSPreOrder2.pordDeadlineDate.HasValue ? wSPreOrder2.pordDeadlineDate.Value.ToString("yyyy/MM/dd") : ""),
				pordDefaultSettingId = wSPreOrder2.pordDefaultSettingId,
				pordDeliveryDay = wSPreOrder2.pordDeliveryDay,
				pordDeliveryEndDay = wSPreOrder2.pordDeliveryEndDay,
				pordSaleAreaId = wSPreOrder2.pordSaleAreaId
			};
			if (wSPreOrderLanguageViewModel != null && wSPreOrderLanguageViewModel.pordSaleCenterId.GetValueOrDefault() != 0)
			{
				WSspSelectSaleCenterWithId_Result wSspSelectSaleCenterWithId_Result = Enumerable.FirstOrDefault<WSspSelectSaleCenterWithId_Result>((IEnumerable<WSspSelectSaleCenterWithId_Result>)_dbII.WSspSelectSaleCenterWithId(wSPreOrderLanguageViewModel.pordSaleCenterId, CS_0024_003C_003E8__locals0.currLangID, result));
				if (wSspSelectSaleCenterWithId_Result != null)
				{
					wSPreOrderLanguageViewModel.pordSaleCenterName = wSspSelectSaleCenterWithId_Result.SaleCenterName ?? "";
				}
			}
		}
		else
		{
			if (!UserLogin.IsUserAccess("frmPreOrder", "actInsert"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			long pordNumber = Enumerable.FirstOrDefault<long>(_db.Database.SqlQuery<long>($"Select dbo.WSfnReturnPreOrderNumber({Financial.Get().Id},{0},{num.GetValueOrDefault()})", Array.Empty<object>()));
			DateTime now = DateTime.Now;
			wSPreOrderLanguageViewModel = new WSPreOrderLanguageViewModel
			{
				pordNumber = pordNumber,
				pordFirstRegisterUserId = UserLogin.CurrentUser.UserId,
				pordDate = now.ToString("yyyyMMdd"),
				pordDateTime = now,
				pordImportDate = now.ToString("yyyyMMdd", new PersianCulture()),
				pordImportDateTime = now,
				pordDay = DateTimeClass.DefineDayeOfWeekStartWith7(now.DayOfWeek.ToString()),
				pordTime = now.ToString("HH:mm:ss"),
				pordStatusId = 1
			};
			if (!UserLogin.IsUserAccess("frmPreOrderDataEntry", "actNoPordTax", UserLogin.CurrentUser))
			{
				wSPreOrderLanguageViewModel.pordCalculateTax = true;
			}
			if (array != null && array.Length >= 1 && array[0] != "")
			{
				int result3 = 0;
				int.TryParse(array[0], out result3);
				CRMspSelectCompanyById_Result cmp = CRMIdeal.Classes.Helper.Company.GetCompanyById(result3);
				if (cmp != null)
				{
					text = ((Enumerable.FirstOrDefault<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)list, (Func<CRMspSelectCompanyTitle_Result, bool>)((CRMspSelectCompanyTitle_Result c) => c.CompanyTitleID == cmp.cmpTitleId)) != null) ? (Enumerable.FirstOrDefault<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)list, (Func<CRMspSelectCompanyTitle_Result, bool>)((CRMspSelectCompanyTitle_Result c) => c.CompanyTitleID == cmp.cmpTitleId)).CompanyTitle + " ") : "") + cmp.cmpName;
					text2 = cmp.cmpAddress;
				}
			}
			base.ViewBag.IsBuying = VersionBuyer.PreOrders;
		}
		FillDropdownPOrder();
		GetVerificationWorkFlow();
		GetDeliveryTerms();
		GetPreOrderTypes();
		GetWareHouse();
		GetProductPriceGroup();
		GetSeller();
		GetEmailUsersInfo();
		GetEmailUserDefaultSetting();
		GetDefPayType();
		GetSaleAreas();
		List<int> list15 = new List<int>();
		List<CRMspSelectUsers_Result> list16 = CRMIdeal.Classes.Helper.User.SelectUsers(0);
		if (list16 != null && Enumerable.Any<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)list16))
		{
			list15 = Enumerable.ToList<int>(Enumerable.Select<CRMspSelectUsers_Result, int>(Enumerable.Where<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)list16, (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result c) => c.IsActive == false || !c.IsActive.HasValue)), (Func<CRMspSelectUsers_Result, int>)((CRMspSelectUsers_Result c) => c.UserId)));
		}
		base.ViewBag.ListUserIsActiveStatus = list15;
		base.ViewBag.ItemsSumAmount = result2;
		base.ViewBag.CmpFullName = text;
		base.ViewBag.CmpAddrs = text2;
		GetCurrencyUnit();
		return View(wSPreOrderLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmPreOrderDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult InsertEdit(WSPreOrderLanguageViewModel vm)
	{
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_0296: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_033e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0392: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_043a: Unknown result type (might be due to invalid IL or missing references)
		//IL_048e: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e2: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass37_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass37_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		if (UserLogin.IsUserAccess("frmPreOrderDataEntry", "actSetPreOrderOprNotNull") && (!CS_0024_003C_003E8__locals0.vm.PreOrderOprID.HasValue || CS_0024_003C_003E8__locals0.vm.PreOrderOprID <= 0))
		{
			base.ViewBag.Error = Messages.msgErrorEnterPreOrderGroup;
			return View(CS_0024_003C_003E8__locals0.vm);
		}
		int? num = null;
		if (UserLogin.CurrentUser != null)
		{
			num = UserLogin.CurrentUser.UserLastCId;
		}
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.pordTitle_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.pordTitle_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.pordTitle,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.pordSubject_Lang))
		{
			list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.pordSubject_Lang);
		}
		list2.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.pordSubject,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.pordTotalAmountStr_Lang))
		{
			list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.pordTotalAmountStr_Lang);
		}
		list3.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.pordTotalAmountStr,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.pordSpecialWord_Lang))
		{
			list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.pordSpecialWord_Lang);
		}
		list4.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.pordSpecialWord,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.pordDescriptionI_Lang))
		{
			list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.pordDescriptionI_Lang);
		}
		list5.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.pordDescriptionI,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.pordDescriptionII_Lang))
		{
			list6 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.pordDescriptionII_Lang);
		}
		list6.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.pordDescriptionII,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list7 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.pordSigningI_Lang))
		{
			list7 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.pordSigningI_Lang);
		}
		list7.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.pordSigningI,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list8 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.pordSigningII_Lang))
		{
			list8 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.pordSigningII_Lang);
		}
		list8.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.pordSigningII,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list9 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.pordSigningIII_Lang))
		{
			list9 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.pordSigningIII_Lang);
		}
		list9.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.pordSigningIII,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list10 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.pordAddress_Lang))
		{
			list10 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.pordAddress_Lang);
		}
		list10.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.pordAddress,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list11 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.pordDiscountTitle_Lang))
		{
			list11 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.pordDiscountTitle_Lang);
		}
		list11.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.pordDiscountTitle,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list12 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.pordcmpTitle_Lang))
		{
			list12 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.pordcmpTitle_Lang);
		}
		list12.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.pordcmpTitle,
			LanguageId = lCID
		});
		long num2 = 0L;
		string text = "";
		int sysPartId = 20;
		base.ViewBag.MyParameters = "".Split(new char[1] { '|' });
		string text2 = "";
		string text3 = "";
		CS_0024_003C_003E8__locals0.cmp = CRMIdeal.Classes.Helper.Company.GetCompanyById(CS_0024_003C_003E8__locals0.vm.pordCompanyId.GetValueOrDefault());
		List<CRMspSelectCompanyTitle_Result> list13 = Enumerable.ToList<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)_db.CRMspSelectCompanyTitle(lCID, CS_0024_003C_003E8__locals0.defLangID));
		if (CS_0024_003C_003E8__locals0.cmp != null)
		{
			text2 = ((Enumerable.FirstOrDefault<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)list13, (Func<CRMspSelectCompanyTitle_Result, bool>)((CRMspSelectCompanyTitle_Result c) => c.CompanyTitleID == CS_0024_003C_003E8__locals0.cmp.cmpTitleId)) != null) ? (Enumerable.FirstOrDefault<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)list13, (Func<CRMspSelectCompanyTitle_Result, bool>)((CRMspSelectCompanyTitle_Result c) => c.CompanyTitleID == CS_0024_003C_003E8__locals0.cmp.cmpTitleId)).CompanyTitle + " ") : "") + CS_0024_003C_003E8__locals0.cmp.cmpName;
			text3 = CS_0024_003C_003E8__locals0.cmp.cmpAddress;
		}
		base.ViewBag.CmpFullName = text2;
		base.ViewBag.CmpAddrs = text3;
		GetCurrencyUnit();
		decimal result = default(decimal);
		if (base.Request.UrlReferrer != null)
		{
			string[] array = base.Request.UrlReferrer.Query.Replace("itemsAmount", "|").Split(new char[1] { '|' });
			if (array.Length == 2)
			{
				decimal.TryParse(array[1].Replace(",", "").Replace("،", ""), out result);
			}
		}
		base.ViewBag.ItemsSumAmount = result;
		FillDropdownPOrder();
		GetVerificationWorkFlow();
		GetDeliveryTerms();
		GetPreOrderTypes();
		GetWareHouse();
		GetProductPriceGroup();
		GetSeller();
		GetEmailUsersInfo();
		GetEmailUserDefaultSetting();
		GetDefPayType();
		GetSaleAreas();
		List<int> list14 = new List<int>();
		List<CRMspSelectUsers_Result> list15 = CRMIdeal.Classes.Helper.User.SelectUsers(0);
		if (list15 != null && Enumerable.Any<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)list15))
		{
			list14 = Enumerable.ToList<int>(Enumerable.Select<CRMspSelectUsers_Result, int>(Enumerable.Where<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)list15, (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result c) => c.IsActive == false || !c.IsActive.HasValue)), (Func<CRMspSelectUsers_Result, int>)((CRMspSelectUsers_Result c) => c.UserId)));
		}
		base.ViewBag.ListUserIsActiveStatus = list14;
		try
		{
			if (CS_0024_003C_003E8__locals0.vm.PreOrderID <= 0 && !VersionBuyer.PreOrders)
			{
				DbSet<WSPreOrder> wSPreOrder = _dbTbl.WSPreOrder;
				ParameterExpression val = Expression.Parameter(typeof(WSPreOrder), "c");
				if (Queryable.Any<WSPreOrder>((IQueryable<WSPreOrder>)wSPreOrder, Expression.Lambda<Func<WSPreOrder, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)10, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val })))
				{
					base.ViewBag.Error = "BV|" + Messages.VersionBuy;
					return View(CS_0024_003C_003E8__locals0.vm);
				}
			}
			if (CS_0024_003C_003E8__locals0.vm.PreOrderID > 0 && PreOrder.IsSentToLinkAccByAction(CS_0024_003C_003E8__locals0.vm.PreOrderID))
			{
				string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
				base.ViewBag.Error = string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			if (!CS_0024_003C_003E8__locals0.vm.pordDiscountPercent.HasValue)
			{
				CS_0024_003C_003E8__locals0.vm.pordDiscountPercent = default(decimal);
			}
			DateTime dateTime = default(DateTime);
			string text4 = "";
			try
			{
				if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.pordTime))
				{
					CS_0024_003C_003E8__locals0.vm.pordTime = DateTime.Now.ToString("HH:mm:ss");
				}
				else
				{
					CS_0024_003C_003E8__locals0.vm.pordTime = CS_0024_003C_003E8__locals0.vm.pordTime.Trim();
				}
				text4 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.vm.pordDate.Replace("/", ""));
				switch (lCID)
				{
				case 1065:
					dateTime = DateTime.Parse(text4 + " " + CS_0024_003C_003E8__locals0.vm.pordTime, new PersianCulture());
					CS_0024_003C_003E8__locals0.vm.pordDate = dateTime.ToString("yyyyMMdd");
					break;
				case 1025:
					dateTime = DateTime.Parse(text4 + " " + CS_0024_003C_003E8__locals0.vm.pordTime, new CultureInfo("ar-SA"));
					CS_0024_003C_003E8__locals0.vm.pordDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
					break;
				default:
					dateTime = DateTime.Parse(text4 + " " + CS_0024_003C_003E8__locals0.vm.pordTime, new CultureInfo("en-US"));
					CS_0024_003C_003E8__locals0.vm.pordDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
					break;
				}
				CS_0024_003C_003E8__locals0.vm.pordDateTime = dateTime;
				CS_0024_003C_003E8__locals0.vm.pordDay = DateTimeClass.DefineDayeOfWeekStartWith7(dateTime.DayOfWeek.ToString());
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				CS_0024_003C_003E8__locals0.vm.pordDate = (CS_0024_003C_003E8__locals0.vm.pordDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.pordDeliveryDate = (CS_0024_003C_003E8__locals0.vm.pordDeliveryDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDeliveryDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.pordExpireDate = (CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.pordExpireTime = (CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.Value.ToString("HH:mm") : "");
				CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDate = (CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.pordDeadlineDatePersian = (CS_0024_003C_003E8__locals0.vm.pordDeadlineDate.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDeadlineDate.Value.ToString("yyyy/MM/dd") : "");
				base.ViewBag.Error = Messages.WrongPordDateTime;
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			try
			{
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.pordDeliveryDate))
				{
					text4 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.vm.pordDeliveryDate.Replace("/", ""));
					text4 = (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.pordDeliveryTime) ? (text4 + " 00:00:00") : (text4 + " " + CS_0024_003C_003E8__locals0.vm.pordDeliveryTime.Trim()));
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text4, new PersianCulture());
						CS_0024_003C_003E8__locals0.vm.pordDeliveryDate = dateTime.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime = DateTime.Parse(text4, new CultureInfo("ar-SA"));
						CS_0024_003C_003E8__locals0.vm.pordDeliveryDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime = DateTime.Parse(text4, new CultureInfo("en-US"));
						CS_0024_003C_003E8__locals0.vm.pordDeliveryDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
					CS_0024_003C_003E8__locals0.vm.pordDeliveryDateTime = dateTime;
					CS_0024_003C_003E8__locals0.vm.pordDeliveryDay = DateTimeClass.DefineDayeOfWeekStartWith7(dateTime.DayOfWeek.ToString());
				}
				else
				{
					CS_0024_003C_003E8__locals0.vm.pordDeliveryDateTime = null;
					CS_0024_003C_003E8__locals0.vm.pordDeliveryDay = null;
				}
			}
			catch (Exception e2)
			{
				ErrorSignal.FromCurrentContext().Raise(e2);
				CS_0024_003C_003E8__locals0.vm.pordDate = (CS_0024_003C_003E8__locals0.vm.pordDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.pordDeliveryDate = (CS_0024_003C_003E8__locals0.vm.pordDeliveryDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDeliveryDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.pordExpireDate = (CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.pordExpireTime = (CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.Value.ToString("HH:mm") : "");
				CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDate = (CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.pordDeadlineDatePersian = (CS_0024_003C_003E8__locals0.vm.pordDeadlineDate.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDeadlineDate.Value.ToString("yyyy/MM/dd") : "");
				base.ViewBag.Error = Messages.WrongPordDeliveryDateTime;
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			try
			{
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDate))
				{
					text4 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDate.Replace("/", ""));
					text4 = (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.pordDeliveryEndTime) ? (text4 + " 00:00:00") : (text4 + " " + CS_0024_003C_003E8__locals0.vm.pordDeliveryEndTime.Trim()));
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text4, new PersianCulture());
						CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDate = dateTime.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime = DateTime.Parse(text4, new CultureInfo("ar-SA"));
						CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime = DateTime.Parse(text4, new CultureInfo("en-US"));
						CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
					CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDateTime = dateTime;
					CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDay = DateTimeClass.DefineDayeOfWeekStartWith7(dateTime.DayOfWeek.ToString());
				}
				else
				{
					CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDateTime = null;
					CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDay = null;
				}
			}
			catch (Exception e3)
			{
				ErrorSignal.FromCurrentContext().Raise(e3);
				CS_0024_003C_003E8__locals0.vm.pordDate = (CS_0024_003C_003E8__locals0.vm.pordDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.pordDeliveryDate = (CS_0024_003C_003E8__locals0.vm.pordDeliveryDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDeliveryDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.pordExpireDate = (CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.pordExpireTime = (CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.Value.ToString("HH:mm") : "");
				CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDate = (CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.pordDeadlineDatePersian = (CS_0024_003C_003E8__locals0.vm.pordDeadlineDate.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDeadlineDate.Value.ToString("yyyy/MM/dd") : "");
				base.ViewBag.Error = string.Format(Messages.ErrorInFormat, Labels.pordDeliveryEndDate);
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			if (CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDate != null)
			{
				CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDate = CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDate.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
			}
			try
			{
				if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.vm.pordExpireDate))
				{
					text4 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.vm.pordExpireDate.Replace("/", ""));
					text4 = (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.pordExpireTime) ? (text4 + " 00:00:00") : (text4 + " " + CS_0024_003C_003E8__locals0.vm.pordExpireTime.Trim()));
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text4, new PersianCulture());
						CS_0024_003C_003E8__locals0.vm.pordExpireDate = dateTime.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime = DateTime.Parse(text4, new CultureInfo("ar-SA"));
						CS_0024_003C_003E8__locals0.vm.pordExpireDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime = DateTime.Parse(text4, new CultureInfo("en-US"));
						CS_0024_003C_003E8__locals0.vm.pordExpireDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
					CS_0024_003C_003E8__locals0.vm.pordExpireDateTime = dateTime;
				}
				else
				{
					if (UserLogin.IsUserAccess("frmPreOrderDataEntry", "actSetPordExpireDateNotNull", UserLogin.CurrentUser))
					{
						base.ViewBag.Error = string.Format(Messages.msgErrorIsNotEntered, Labels.pordExpireDate);
						CS_0024_003C_003E8__locals0.vm.pordDate = (CS_0024_003C_003E8__locals0.vm.pordDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDateTime.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.vm.pordDeliveryDate = (CS_0024_003C_003E8__locals0.vm.pordDeliveryDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDeliveryDateTime.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.vm.pordExpireDate = (CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.vm.pordExpireTime = (CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.Value.ToString("HH:mm") : "");
						CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDate = (CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDateTime.Value.ToString("yyyy/MM/dd") : "");
						return View(CS_0024_003C_003E8__locals0.vm);
					}
					CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDate = null;
				}
			}
			catch (Exception e4)
			{
				ErrorSignal.FromCurrentContext().Raise(e4);
				CS_0024_003C_003E8__locals0.vm.pordDate = (CS_0024_003C_003E8__locals0.vm.pordDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.pordDeliveryDate = (CS_0024_003C_003E8__locals0.vm.pordDeliveryDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDeliveryDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.pordExpireDate = (CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.pordExpireTime = (CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.Value.ToString("HH:mm") : "");
				CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDate = (CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDateTime.Value.ToString("yyyy/MM/dd") : "");
				base.ViewBag.Error = Messages.WrongDateTime;
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			if (CS_0024_003C_003E8__locals0.vm.pordExpireDate != null)
			{
				CS_0024_003C_003E8__locals0.vm.pordExpireDate = CS_0024_003C_003E8__locals0.vm.pordExpireDate.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
			}
			try
			{
				if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.vm.pordDeadlineDatePersian))
				{
					text4 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.vm.pordDeadlineDatePersian.Replace("/", ""));
					text4 += " 00:00:00";
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text4, new PersianCulture());
						CS_0024_003C_003E8__locals0.vm.pordDeadlineDatePersian = dateTime.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime = DateTime.Parse(text4, new CultureInfo("ar-SA"));
						CS_0024_003C_003E8__locals0.vm.pordDeadlineDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime = DateTime.Parse(text4, new CultureInfo("en-US"));
						CS_0024_003C_003E8__locals0.vm.pordDeadlineDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
					CS_0024_003C_003E8__locals0.vm.pordDeadlineDate = dateTime;
				}
				else
				{
					if (UserLogin.IsUserAccess("frmPreOrderDataEntry", "actSetPordDeadlineDateNotNull", UserLogin.CurrentUser))
					{
						base.ViewBag.Error = string.Format(Messages.msgErrorIsNotEntered, Labels.pordDeadlineDate);
						CS_0024_003C_003E8__locals0.vm.pordDate = (CS_0024_003C_003E8__locals0.vm.pordDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDateTime.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.vm.pordDeliveryDate = (CS_0024_003C_003E8__locals0.vm.pordDeliveryDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDeliveryDateTime.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.vm.pordExpireDate = (CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.vm.pordExpireTime = (CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.Value.ToString("HH:mm") : "");
						CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDate = (CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDateTime.Value.ToString("yyyy/MM/dd") : "");
						return View(CS_0024_003C_003E8__locals0.vm);
					}
					CS_0024_003C_003E8__locals0.vm.pordDeadlineDate = null;
				}
			}
			catch (Exception e5)
			{
				ErrorSignal.FromCurrentContext().Raise(e5);
				CS_0024_003C_003E8__locals0.vm.pordDate = (CS_0024_003C_003E8__locals0.vm.pordDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.pordDeliveryDate = (CS_0024_003C_003E8__locals0.vm.pordDeliveryDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDeliveryDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.pordExpireDate = (CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.pordExpireTime = (CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.Value.ToString("HH:mm") : "");
				CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDate = (CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.pordDeadlineDatePersian = (CS_0024_003C_003E8__locals0.vm.pordDeadlineDate.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDeadlineDate.Value.ToString("yyyy/MM/dd") : "");
				base.ViewBag.Error = string.Format(Messages.ErrorInFormat, Labels.pordDeadlineDate);
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			if (CS_0024_003C_003E8__locals0.vm.pordDeadlineDatePersian != null)
			{
				CS_0024_003C_003E8__locals0.vm.pordDeadlineDatePersian = CS_0024_003C_003E8__locals0.vm.pordDeadlineDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
			}
			if (CS_0024_003C_003E8__locals0.vm.pordDate != null)
			{
				CS_0024_003C_003E8__locals0.vm.pordDate = CS_0024_003C_003E8__locals0.vm.pordDate.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
			}
			if (CS_0024_003C_003E8__locals0.vm.pordDeliveryDate != null)
			{
				CS_0024_003C_003E8__locals0.vm.pordDeliveryDate = CS_0024_003C_003E8__locals0.vm.pordDeliveryDate.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
			}
			if (CS_0024_003C_003E8__locals0.vm.pordImportDate != null)
			{
				CS_0024_003C_003E8__locals0.vm.pordImportDate = CS_0024_003C_003E8__locals0.vm.pordImportDate.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
			}
			if (CS_0024_003C_003E8__locals0.vm.pordVerifiedRegisterDatePersian != null)
			{
				CS_0024_003C_003E8__locals0.vm.pordVerifiedRegisterDatePersian = CS_0024_003C_003E8__locals0.vm.pordVerifiedRegisterDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
			}
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.pordNumRef) && UserLogin.IsUserAccess("frmPreOrderDataEntry", "actNotDupNumRef", UserLogin.CurrentUser))
			{
				WSspCheckDuplicatePreOrderNumRef_Result wSspCheckDuplicatePreOrderNumRef_Result = Enumerable.FirstOrDefault<WSspCheckDuplicatePreOrderNumRef_Result>((IEnumerable<WSspCheckDuplicatePreOrderNumRef_Result>)_db.WSspCheckDuplicatePreOrderNumRef(CS_0024_003C_003E8__locals0.vm.pordNumRef, CS_0024_003C_003E8__locals0.vm.PreOrderID, num));
				if (wSspCheckDuplicatePreOrderNumRef_Result != null)
				{
					CS_0024_003C_003E8__locals0.vm.pordDate = (CS_0024_003C_003E8__locals0.vm.pordDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDateTime.Value.ToString("yyyy/MM/dd") : "");
					CS_0024_003C_003E8__locals0.vm.pordDeliveryDate = (CS_0024_003C_003E8__locals0.vm.pordDeliveryDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDeliveryDateTime.Value.ToString("yyyy/MM/dd") : "");
					CS_0024_003C_003E8__locals0.vm.pordExpireDate = (CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.Value.ToString("yyyy/MM/dd") : "");
					CS_0024_003C_003E8__locals0.vm.pordExpireTime = (CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.Value.ToString("HH:mm") : "");
					CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDate = (CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDateTime.Value.ToString("yyyy/MM/dd") : "");
					CS_0024_003C_003E8__locals0.vm.pordDeadlineDatePersian = (CS_0024_003C_003E8__locals0.vm.pordDeadlineDate.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDeadlineDate.Value.ToString("yyyy/MM/dd") : "");
					base.ViewBag.Error = string.Format(Messages.PreOrderNumRefIsRepeated, wSspCheckDuplicatePreOrderNumRef_Result.pordNumber.ToString());
					return View(CS_0024_003C_003E8__locals0.vm);
				}
			}
			if (!base.ModelState.IsValid)
			{
				base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
			else
			{
				_003C_003Ec__DisplayClass37_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass37_1();
				CS_0024_003C_003E8__locals1.model = new WSPreOrder();
				if (CS_0024_003C_003E8__locals0.vm.PreOrderID > 0)
				{
					DbSet<WSPreOrder> wSPreOrder2 = _dbTbl.WSPreOrder;
					ParameterExpression val = Expression.Parameter(typeof(WSPreOrder), "c");
					CS_0024_003C_003E8__locals1.model = Queryable.FirstOrDefault<WSPreOrder>((IQueryable<WSPreOrder>)wSPreOrder2, Expression.Lambda<Func<WSPreOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass37_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				DateTime now = DateTime.Now;
				CS_0024_003C_003E8__locals1.model.UserId = UserLogin.CurrentUser.UserId;
				CS_0024_003C_003E8__locals1.model.RegisterDate = now;
				CS_0024_003C_003E8__locals1.model.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				CS_0024_003C_003E8__locals1.model.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
				CS_0024_003C_003E8__locals1.model.AppType = Configuration.AppType;
				CS_0024_003C_003E8__locals1.model.pordVerifiedRegisterDate = CS_0024_003C_003E8__locals0.vm.pordVerifiedRegisterDate;
				CS_0024_003C_003E8__locals1.model.pordVerifiedRegisterDatePersian = CS_0024_003C_003E8__locals0.vm.pordVerifiedRegisterDatePersian;
				CS_0024_003C_003E8__locals1.model.PreOrderOprID = CS_0024_003C_003E8__locals0.vm.PreOrderOprID;
				CS_0024_003C_003E8__locals1.model.pordAccountNumberI = CS_0024_003C_003E8__locals0.vm.pordAccountNumberI;
				CS_0024_003C_003E8__locals1.model.pordAccountNumberII = CS_0024_003C_003E8__locals0.vm.pordAccountNumberII;
				CS_0024_003C_003E8__locals1.model.pordAccountShabaNumberI = CS_0024_003C_003E8__locals0.vm.pordAccountShabaNumberI;
				CS_0024_003C_003E8__locals1.model.pordAccountShabaNumberII = CS_0024_003C_003E8__locals0.vm.pordAccountShabaNumberII;
				CS_0024_003C_003E8__locals1.model.pordCompanyId = CS_0024_003C_003E8__locals0.vm.pordCompanyId;
				CS_0024_003C_003E8__locals1.model.pordCompanyPersonId = CS_0024_003C_003E8__locals0.vm.pordCompanyPersonId;
				CS_0024_003C_003E8__locals1.model.pordCreditDurationId = CS_0024_003C_003E8__locals0.vm.pordCreditDurationId;
				CS_0024_003C_003E8__locals1.model.pordDate = CS_0024_003C_003E8__locals0.vm.pordDate;
				CS_0024_003C_003E8__locals1.model.pordDateTime = CS_0024_003C_003E8__locals0.vm.pordDateTime;
				CS_0024_003C_003E8__locals1.model.pordDay = CS_0024_003C_003E8__locals0.vm.pordDay;
				CS_0024_003C_003E8__locals1.model.pordDeliveryDate = CS_0024_003C_003E8__locals0.vm.pordDeliveryDate;
				CS_0024_003C_003E8__locals1.model.pordDeliveryDateTime = CS_0024_003C_003E8__locals0.vm.pordDeliveryDateTime;
				CS_0024_003C_003E8__locals1.model.pordImportDate = CS_0024_003C_003E8__locals0.vm.pordImportDate;
				CS_0024_003C_003E8__locals1.model.pordImportDateTime = CS_0024_003C_003E8__locals0.vm.pordImportDateTime;
				CS_0024_003C_003E8__locals1.model.pordDeliveryTime = CS_0024_003C_003E8__locals0.vm.pordDeliveryTime;
				CS_0024_003C_003E8__locals1.model.pordDeliveryTimeId = CS_0024_003C_003E8__locals0.vm.pordDeliveryTimeId;
				CS_0024_003C_003E8__locals1.model.pordTime = CS_0024_003C_003E8__locals0.vm.pordTime;
				CS_0024_003C_003E8__locals1.model.pordDescriptionId = CS_0024_003C_003E8__locals0.vm.pordDescriptionId;
				if (!UserLogin.IsUserAccess("frmPreOrderDataEntry", "actNoPordDiscount", UserLogin.CurrentUser))
				{
					CS_0024_003C_003E8__locals1.model.pordDiscount = CS_0024_003C_003E8__locals0.vm.pordDiscount;
					CS_0024_003C_003E8__locals1.model.pordDiscountPercent = CS_0024_003C_003E8__locals0.vm.pordDiscountPercent;
				}
				if (!UserLogin.IsUserAccess("frmPreOrderDataEntry", "actNoPordTax", UserLogin.CurrentUser))
				{
					CS_0024_003C_003E8__locals1.model.pordCalculateTax = CS_0024_003C_003E8__locals0.vm.pordCalculateTax;
					CS_0024_003C_003E8__locals1.model.pordTax = CS_0024_003C_003E8__locals0.vm.pordTax;
					CS_0024_003C_003E8__locals1.model.pordTaxIndex = CS_0024_003C_003E8__locals0.vm.pordTaxIndex;
				}
				CS_0024_003C_003E8__locals1.model.pordEmail = CS_0024_003C_003E8__locals0.vm.pordEmail;
				CS_0024_003C_003E8__locals1.model.pordFax = CS_0024_003C_003E8__locals0.vm.pordFax;
				CS_0024_003C_003E8__locals1.model.pordGuarantyId = CS_0024_003C_003E8__locals0.vm.pordGuarantyId;
				CS_0024_003C_003E8__locals1.model.pordRound = CS_0024_003C_003E8__locals0.vm.pordRound;
				CS_0024_003C_003E8__locals1.model.pordInstallAmount = CS_0024_003C_003E8__locals0.vm.pordInstallAmount;
				CS_0024_003C_003E8__locals1.model.pordIsFixed = CS_0024_003C_003E8__locals0.vm.pordIsFixed;
				CS_0024_003C_003E8__locals1.model.pordIsVerified = CS_0024_003C_003E8__locals0.vm.pordIsVerified;
				CS_0024_003C_003E8__locals1.model.pordItemCount = CS_0024_003C_003E8__locals0.vm.pordItemCount;
				CS_0024_003C_003E8__locals1.model.pordItemsAmount = CS_0024_003C_003E8__locals0.vm.pordItemsAmount;
				CS_0024_003C_003E8__locals1.model.pordLLogoId = CS_0024_003C_003E8__locals0.vm.pordLLogoId;
				CS_0024_003C_003E8__locals1.model.pordNumber = CS_0024_003C_003E8__locals0.vm.pordNumber;
				CS_0024_003C_003E8__locals1.model.pordPayConditionId = CS_0024_003C_003E8__locals0.vm.pordPayConditionId;
				if (!UserLogin.IsUserAccess("frmPreOrderDataEntry", "actCanNotChangePrintFormat", UserLogin.CurrentUser))
				{
					CS_0024_003C_003E8__locals1.model.pordPrintFormatId = CS_0024_003C_003E8__locals0.vm.pordPrintFormatId;
				}
				else if (CS_0024_003C_003E8__locals1.model.PreOrderID == 0)
				{
					CS_0024_003C_003E8__locals1.model.pordPrintFormatId = CS_0024_003C_003E8__locals0.vm.pordPrintFormatId;
				}
				CS_0024_003C_003E8__locals1.model.pordProjectId = CS_0024_003C_003E8__locals0.vm.pordProjectId;
				CS_0024_003C_003E8__locals1.model.pordRLogoId = CS_0024_003C_003E8__locals0.vm.pordRLogoId;
				CS_0024_003C_003E8__locals1.model.pordReferUserId = CS_0024_003C_003E8__locals0.vm.pordReferUserId;
				CS_0024_003C_003E8__locals1.model.pordSignatureId = CS_0024_003C_003E8__locals0.vm.pordSignatureId;
				CS_0024_003C_003E8__locals1.model.pordStatusId = CS_0024_003C_003E8__locals0.vm.pordStatusId;
				CS_0024_003C_003E8__locals1.model.pordSumAmount = CS_0024_003C_003E8__locals0.vm.pordSumAmount;
				CS_0024_003C_003E8__locals1.model.pordTelephone = CS_0024_003C_003E8__locals0.vm.pordTelephone;
				CS_0024_003C_003E8__locals1.model.pordTotalAmount = CS_0024_003C_003E8__locals0.vm.pordTotalAmount;
				CS_0024_003C_003E8__locals1.model.pordTransportation = CS_0024_003C_003E8__locals0.vm.pordTransportation;
				CS_0024_003C_003E8__locals1.model.pordVerifierRequestId = CS_0024_003C_003E8__locals0.vm.pordVerifierRequestId;
				CS_0024_003C_003E8__locals1.model.pordVerifierId = CS_0024_003C_003E8__locals0.vm.pordVerifierId;
				CS_0024_003C_003E8__locals1.model.pordWebSite = CS_0024_003C_003E8__locals0.vm.pordWebSite;
				CS_0024_003C_003E8__locals1.model.pordDeliveryEndDate = CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDate;
				CS_0024_003C_003E8__locals1.model.pordDeliveryEndDateTime = CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDateTime;
				CS_0024_003C_003E8__locals1.model.pordDeliveryEndTime = CS_0024_003C_003E8__locals0.vm.pordDeliveryEndTime;
				CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDate = (CS_0024_003C_003E8__locals1.model.pordDeliveryEndDateTime.HasValue ? CS_0024_003C_003E8__locals1.model.pordDeliveryEndDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals1.model.pordDeadlineDate = CS_0024_003C_003E8__locals0.vm.pordDeadlineDate;
				CS_0024_003C_003E8__locals1.model.pordDeadlineDatePersian = CS_0024_003C_003E8__locals0.vm.pordDeadlineDatePersian;
				CS_0024_003C_003E8__locals1.model.pordDeliveryEndDay = CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDay;
				CS_0024_003C_003E8__locals1.model.pordDeliveryDay = CS_0024_003C_003E8__locals0.vm.pordDeliveryDay;
				if (CS_0024_003C_003E8__locals1.model.pordDateTime.HasValue && CS_0024_003C_003E8__locals1.model.pordCreditDurationId.HasValue && !CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.HasValue)
				{
					WSspSelectCreditDuration_Result wSspSelectCreditDuration_Result = Enumerable.FirstOrDefault<WSspSelectCreditDuration_Result>((IEnumerable<WSspSelectCreditDuration_Result>)_db.WSspSelectCreditDuration(lCID, CS_0024_003C_003E8__locals0.defLangID), (Func<WSspSelectCreditDuration_Result, bool>)((WSspSelectCreditDuration_Result m) => m.CreditDurationID == CS_0024_003C_003E8__locals1.model.pordCreditDurationId));
					if (wSspSelectCreditDuration_Result != null && wSspSelectCreditDuration_Result.CreditDurationHours.HasValue)
					{
						int result2 = 0;
						int.TryParse(wSspSelectCreditDuration_Result.CreditDurationHours.ToString(), out result2);
						if (result2 > 0)
						{
							DateTime dateTime2 = (CS_0024_003C_003E8__locals1.model.pordDateTime.HasValue ? CS_0024_003C_003E8__locals1.model.pordDateTime.Value : now);
							CS_0024_003C_003E8__locals1.model.pordExpireDateTime = dateTime2.AddHours(result2);
							CS_0024_003C_003E8__locals1.model.pordExpireDate = dateTime2.AddHours(result2).ToString("yyyyMMdd", new PersianCulture());
							CS_0024_003C_003E8__locals0.vm.pordExpireDate = dateTime2.AddHours(result2).ToString("yyyy/MM/dd", new PersianCulture());
						}
					}
				}
				else if (!UserLogin.IsUserAccess("frmPreOrderDataEntry", "actCanNotChangePordExpireDate", UserLogin.CurrentUser) || CS_0024_003C_003E8__locals1.model.PreOrderID == 0)
				{
					CS_0024_003C_003E8__locals1.model.pordExpireDate = CS_0024_003C_003E8__locals0.vm.pordExpireDate;
					CS_0024_003C_003E8__locals1.model.pordExpireDateTime = CS_0024_003C_003E8__locals0.vm.pordExpireDateTime;
				}
				if (string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals1.model.pordExpireDate))
				{
					CS_0024_003C_003E8__locals1.model.pordExpireDateTime = null;
				}
				if (!UserLogin.IsUserAccess("frmPreOrderDataEntry", "actCanNotChangePordTitle", UserLogin.CurrentUser) || CS_0024_003C_003E8__locals1.model.PreOrderID == 0)
				{
					CS_0024_003C_003E8__locals1.model.pordTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				}
				CS_0024_003C_003E8__locals1.model.pordSubject = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				CS_0024_003C_003E8__locals1.model.pordTotalAmountStr = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				CS_0024_003C_003E8__locals1.model.pordSpecialWord = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				if (!UserLogin.IsUserAccess("frmPreOrderDataEntry", "actCanNotChangePordDescriptionI", UserLogin.CurrentUser) || CS_0024_003C_003E8__locals1.model.PreOrderID == 0)
				{
					CS_0024_003C_003E8__locals1.model.pordDescriptionI = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				}
				if (!UserLogin.IsUserAccess("frmPreOrderDataEntry", "actCanNotChangePordDescriptionII", UserLogin.CurrentUser) || CS_0024_003C_003E8__locals1.model.PreOrderID == 0)
				{
					CS_0024_003C_003E8__locals1.model.pordDescriptionII = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				}
				CS_0024_003C_003E8__locals1.model.pordSigningI = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				CS_0024_003C_003E8__locals1.model.pordSigningII = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				CS_0024_003C_003E8__locals1.model.pordSigningIII = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				CS_0024_003C_003E8__locals1.model.pordAddress = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				CS_0024_003C_003E8__locals1.model.pordDiscountTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				CS_0024_003C_003E8__locals1.model.pordcmpTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				CS_0024_003C_003E8__locals1.model.pordItemCount = ((CS_0024_003C_003E8__locals1.model.pordItemCount == 0) ? null : CS_0024_003C_003E8__locals1.model.pordItemCount);
				WSPreOrder model = CS_0024_003C_003E8__locals1.model;
				decimal? pordItemsAmount = CS_0024_003C_003E8__locals1.model.pordItemsAmount;
				model.pordItemsAmount = (((pordItemsAmount.GetValueOrDefault() == default(decimal)) & pordItemsAmount.HasValue) ? null : CS_0024_003C_003E8__locals1.model.pordItemsAmount);
				CS_0024_003C_003E8__locals1.model.pordInstallAmount = CS_0024_003C_003E8__locals1.model.pordInstallAmount.GetValueOrDefault();
				WSPreOrder model2 = CS_0024_003C_003E8__locals1.model;
				pordItemsAmount = CS_0024_003C_003E8__locals1.model.pordSumAmount;
				model2.pordSumAmount = (((pordItemsAmount.GetValueOrDefault() == default(decimal)) & pordItemsAmount.HasValue) ? null : CS_0024_003C_003E8__locals1.model.pordSumAmount);
				WSPreOrder model3 = CS_0024_003C_003E8__locals1.model;
				pordItemsAmount = CS_0024_003C_003E8__locals1.model.pordTax;
				model3.pordTax = (((pordItemsAmount.GetValueOrDefault() == default(decimal)) & pordItemsAmount.HasValue) ? null : CS_0024_003C_003E8__locals1.model.pordTax);
				pordItemsAmount = CS_0024_003C_003E8__locals1.model.pordTotalAmount;
				if ((pordItemsAmount.GetValueOrDefault() == default(decimal)) & pordItemsAmount.HasValue)
				{
					CS_0024_003C_003E8__locals1.model.pordTotalAmount = null;
					CS_0024_003C_003E8__locals1.model.pordTotalAmountStr = null;
				}
				WSPreOrder model4 = CS_0024_003C_003E8__locals1.model;
				pordItemsAmount = CS_0024_003C_003E8__locals1.model.pordDiscountPercent;
				model4.pordDiscountPercent = (((pordItemsAmount.GetValueOrDefault() == default(decimal)) & pordItemsAmount.HasValue) ? null : CS_0024_003C_003E8__locals1.model.pordDiscountPercent);
				CS_0024_003C_003E8__locals1.model.pordTransportation = CS_0024_003C_003E8__locals1.model.pordTransportation.GetValueOrDefault();
				CS_0024_003C_003E8__locals1.model.pordRound = CS_0024_003C_003E8__locals1.model.pordRound.GetValueOrDefault();
				CS_0024_003C_003E8__locals1.model.pordDiscount = CS_0024_003C_003E8__locals1.model.pordDiscount.GetValueOrDefault();
				CS_0024_003C_003E8__locals1.model.pordAccountNumberII = CS_0024_003C_003E8__locals1.model.pordAccountNumberII ?? "";
				CS_0024_003C_003E8__locals1.model.pordAccountShabaNumberII = CS_0024_003C_003E8__locals1.model.pordAccountShabaNumberII ?? "";
				CS_0024_003C_003E8__locals1.model.pordVerificationWorkFlowId = CS_0024_003C_003E8__locals0.vm.pordVerificationWorkFlowId;
				int result3 = 0;
				int.TryParse(CS_0024_003C_003E8__locals1.model.pordCurrencyUnitId.ToString(), out result3);
				CS_0024_003C_003E8__locals1.model.pordCurrencyUnitId = CS_0024_003C_003E8__locals0.vm.pordCurrencyUnitId;
				CS_0024_003C_003E8__locals1.model.pordCurrencyUnitIdI = CS_0024_003C_003E8__locals0.vm.pordCurrencyUnitIdI;
				CS_0024_003C_003E8__locals1.model.pordCurrencyUnitIRate = CS_0024_003C_003E8__locals0.vm.pordCurrencyUnitIRate;
				CS_0024_003C_003E8__locals1.model.pordDeliveryTermId = CS_0024_003C_003E8__locals0.vm.pordDeliveryTermId;
				CS_0024_003C_003E8__locals1.model.pordSellerId = CS_0024_003C_003E8__locals0.vm.pordSellerId;
				CS_0024_003C_003E8__locals1.model.pordDefaultSettingId = CS_0024_003C_003E8__locals0.vm.pordDefaultSettingId;
				CS_0024_003C_003E8__locals1.model.pordSaleAreaId = CS_0024_003C_003E8__locals0.vm.pordSaleAreaId;
				if (!UserLogin.IsUserAccess("frmPreOrderDataEntry", "actCanNotChangePordDefWH", UserLogin.CurrentUser))
				{
					CS_0024_003C_003E8__locals1.model.pordDefWHId = CS_0024_003C_003E8__locals0.vm.pordDefWHId;
				}
				else if (CS_0024_003C_003E8__locals1.model.PreOrderID == 0)
				{
					CS_0024_003C_003E8__locals1.model.pordDefWHId = CS_0024_003C_003E8__locals0.vm.pordDefWHId;
				}
				if (!UserLogin.IsUserAccess("frmPreOrderDataEntry", "actCanNotChangePordDefPrdPriceGroup", UserLogin.CurrentUser))
				{
					CS_0024_003C_003E8__locals1.model.pordDefPrdPriceGroupId = CS_0024_003C_003E8__locals0.vm.pordDefPrdPriceGroupId;
				}
				else if (CS_0024_003C_003E8__locals1.model.PreOrderID == 0)
				{
					CS_0024_003C_003E8__locals1.model.pordDefPrdPriceGroupId = CS_0024_003C_003E8__locals0.vm.pordDefPrdPriceGroupId;
				}
				if (!UserLogin.IsUserAccess("frmPreOrderDataEntry", "actCanNotChangeEmailUserInfo", UserLogin.CurrentUser))
				{
					CS_0024_003C_003E8__locals1.model.pordEmailUsersInfoId = CS_0024_003C_003E8__locals0.vm.pordEmailUsersInfoId;
				}
				else if (CS_0024_003C_003E8__locals1.model.PreOrderID == 0)
				{
					CS_0024_003C_003E8__locals1.model.pordEmailUsersInfoId = CS_0024_003C_003E8__locals0.vm.pordEmailUsersInfoId;
				}
				if (!UserLogin.IsUserAccess("frmPreOrderDataEntry", "actCanNotChangeEmailUserDefSetting", UserLogin.CurrentUser))
				{
					CS_0024_003C_003E8__locals1.model.pordEmailUserDefaultSettingId = CS_0024_003C_003E8__locals0.vm.pordEmailUserDefaultSettingId;
				}
				else if (CS_0024_003C_003E8__locals1.model.PreOrderID == 0)
				{
					CS_0024_003C_003E8__locals1.model.pordEmailUserDefaultSettingId = CS_0024_003C_003E8__locals0.vm.pordEmailUserDefaultSettingId;
				}
				if (!UserLogin.IsUserAccess("frmPreOrderDataEntry", "actCanNotChangePordSaleCenter", UserLogin.CurrentUser) || CS_0024_003C_003E8__locals1.model.PreOrderID == 0)
				{
					CS_0024_003C_003E8__locals1.model.pordSaleCenterId = CS_0024_003C_003E8__locals0.vm.pordSaleCenterId;
				}
				if (!UserLogin.IsUserAccess("frmPreOrderDataEntry", "actCanNotChangePordDefPayType", UserLogin.CurrentUser))
				{
					CS_0024_003C_003E8__locals1.model.pordDefPayTypeId = CS_0024_003C_003E8__locals0.vm.pordDefPayTypeId;
				}
				else if (CS_0024_003C_003E8__locals1.model.PreOrderID == 0)
				{
					CS_0024_003C_003E8__locals1.model.pordDefPayTypeId = CS_0024_003C_003E8__locals0.vm.pordDefPayTypeId;
				}
				if (CS_0024_003C_003E8__locals1.model.PreOrderID > 0)
				{
					CS_0024_003C_003E8__locals0.vm.pordTypeId = CS_0024_003C_003E8__locals1.model.pordTypeId;
					if (UserLogin.IsUserAccess("frmPreOrderDataEntry", "actCanChangeNumRef", UserLogin.CurrentUser))
					{
						CS_0024_003C_003E8__locals1.model.pordNumRef = CS_0024_003C_003E8__locals0.vm.pordNumRef;
					}
					string sql = $"Select * from WSfnCheckDuplicatePreOrderNumber({CS_0024_003C_003E8__locals1.model.pordNumber}, {CS_0024_003C_003E8__locals1.model.PreOrderID},{CS_0024_003C_003E8__locals1.model.pordTypeId.GetValueOrDefault()},{CS_0024_003C_003E8__locals1.model.pordCId.GetValueOrDefault()})";
					long? num3 = Enumerable.FirstOrDefault<long?>(_db.Database.SqlQuery<long?>(sql, Array.Empty<object>()));
					if (num3.HasValue && num3 > 0)
					{
						CS_0024_003C_003E8__locals0.vm.pordDate = (CS_0024_003C_003E8__locals0.vm.pordDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDateTime.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.vm.pordDeliveryDate = (CS_0024_003C_003E8__locals0.vm.pordDeliveryDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDeliveryDateTime.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.vm.pordExpireDate = (CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.vm.pordExpireTime = (CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.Value.ToString("HH:mm") : "");
						CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDate = (CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDateTime.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.vm.pordDeadlineDatePersian = (CS_0024_003C_003E8__locals0.vm.pordDeadlineDate.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDeadlineDate.Value.ToString("yyyy/MM/dd") : "");
						base.ViewBag.Error = Messages.PreOrderNumberIsRepeated;
						return View(CS_0024_003C_003E8__locals0.vm);
					}
					CS_0024_003C_003E8__locals1.model.pordNumberRevision = CS_0024_003C_003E8__locals0.vm.pordNumberRevision;
					if (Enumerable.FirstOrDefault<WSspCheckDuplicatePreOrderNumberRevision_Result>((IEnumerable<WSspCheckDuplicatePreOrderNumberRevision_Result>)_db.WSspCheckDuplicatePreOrderNumberRevision(CS_0024_003C_003E8__locals1.model.pordNumber, CS_0024_003C_003E8__locals1.model.pordNumberRevision, CS_0024_003C_003E8__locals1.model.PreOrderID, CS_0024_003C_003E8__locals1.model.pordCId)) != null)
					{
						CS_0024_003C_003E8__locals0.vm.pordDate = (CS_0024_003C_003E8__locals0.vm.pordDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDateTime.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.vm.pordDeliveryDate = (CS_0024_003C_003E8__locals0.vm.pordDeliveryDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDeliveryDateTime.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.vm.pordExpireDate = (CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.vm.pordExpireTime = (CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.Value.ToString("HH:mm") : "");
						CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDate = (CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDateTime.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.vm.pordDeadlineDatePersian = (CS_0024_003C_003E8__locals0.vm.pordDeadlineDate.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDeadlineDate.Value.ToString("yyyy/MM/dd") : "");
						base.ViewBag.Error = Messages.PreOrderNumberRevisionIsRepeated;
						return View(CS_0024_003C_003E8__locals0.vm);
					}
					_dbTbl.Entry(CS_0024_003C_003E8__locals1.model).State = EntityState.Modified;
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					mct_II_Result mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.WSspSelectPreOrderCanceledStatusId());
					if (mct_II_Result != null && mct_II_Result.Result != 0 && CS_0024_003C_003E8__locals1.model.pordStatusId == mct_II_Result.Result && SysSeting.Get().LinkAccSystemId.GetValueOrDefault() == 21 && !string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals1.model.pordLinkAccPreOrderNumber))
					{
						new CRMIdeal.Classes.Helper.OtherSystems.HamyarProvider(false).EbtalSefareshInHamyar(CS_0024_003C_003E8__locals1.model.PreOrderID);
					}
					if (!PreOrder.CalcAndSetPreOrderAmounts(CS_0024_003C_003E8__locals1.model))
					{
						base.ViewBag.Error = Messages.CalcAndSetPreOrderErrorMessage;
					}
					else
					{
						using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								_003C_003Ec__DisplayClass37_2 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass37_2();
								CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals1;
								CS_0024_003C_003E8__locals2.lang = enumerator.Current;
								DbSet<WSPreOrder_Lang> wSPreOrder_Lang = _dbTbl.WSPreOrder_Lang;
								ParameterExpression val = Expression.Parameter(typeof(WSPreOrder_Lang), "c");
								WSPreOrder_Lang wSPreOrder_Lang2 = Queryable.FirstOrDefault<WSPreOrder_Lang>((IQueryable<WSPreOrder_Lang>)wSPreOrder_Lang, Expression.Lambda<Func<WSPreOrder_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals2, typeof(_003C_003Ec__DisplayClass37_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals2, typeof(_003C_003Ec__DisplayClass37_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (wSPreOrder_Lang2 != null)
								{
									if (!UserLogin.IsUserAccess("frmPreOrderDataEntry", "actCanNotChangePordTitle", UserLogin.CurrentUser) || CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.model.PreOrderID == 0)
									{
										wSPreOrder_Lang2.pordTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
									}
									wSPreOrder_Lang2.pordSubject = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
									wSPreOrder_Lang2.pordTotalAmountStr = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
									wSPreOrder_Lang2.pordSpecialWord = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
									if (!UserLogin.IsUserAccess("frmPreOrderDataEntry", "actCanNotChangePordDescriptionI", UserLogin.CurrentUser) || CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.model.PreOrderID == 0)
									{
										wSPreOrder_Lang2.pordDescriptionI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
									}
									if (!UserLogin.IsUserAccess("frmPreOrderDataEntry", "actCanNotChangePordDescriptionII", UserLogin.CurrentUser) || CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.model.PreOrderID == 0)
									{
										wSPreOrder_Lang2.pordDescriptionII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
									}
									wSPreOrder_Lang2.pordSigningI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
									wSPreOrder_Lang2.pordSigningII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
									wSPreOrder_Lang2.pordSigningIII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
									wSPreOrder_Lang2.pordAddress = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
									wSPreOrder_Lang2.pordDiscountTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
									wSPreOrder_Lang2.pordcmpTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
									_dbTbl.Entry(wSPreOrder_Lang2).State = EntityState.Modified;
									_dbTbl.SaveChanges();
									continue;
								}
								wSPreOrder_Lang2 = new WSPreOrder_Lang();
								wSPreOrder_Lang2.LanguageID = CS_0024_003C_003E8__locals2.lang.LanguageID;
								wSPreOrder_Lang2.PreOrderID = CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.model.PreOrderID;
								if (!UserLogin.IsUserAccess("frmPreOrderDataEntry", "actCanNotChangePordTitle", UserLogin.CurrentUser) || CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.model.PreOrderID == 0)
								{
									wSPreOrder_Lang2.pordTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								}
								wSPreOrder_Lang2.pordSubject = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								wSPreOrder_Lang2.pordTotalAmountStr = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								wSPreOrder_Lang2.pordSpecialWord = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								if (!UserLogin.IsUserAccess("frmPreOrderDataEntry", "actCanNotChangePordDescriptionI", UserLogin.CurrentUser) || CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.model.PreOrderID == 0)
								{
									wSPreOrder_Lang2.pordDescriptionI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								}
								if (!UserLogin.IsUserAccess("frmPreOrderDataEntry", "actCanNotChangePordDescriptionII", UserLogin.CurrentUser) || CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.model.PreOrderID == 0)
								{
									wSPreOrder_Lang2.pordDescriptionII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								}
								wSPreOrder_Lang2.pordSigningI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								wSPreOrder_Lang2.pordSigningII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								wSPreOrder_Lang2.pordSigningIII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								wSPreOrder_Lang2.pordAddress = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								wSPreOrder_Lang2.pordDiscountTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								wSPreOrder_Lang2.pordcmpTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								_dbTbl.WSPreOrder_Lang.Add(wSPreOrder_Lang2);
								_dbTbl.SaveChanges();
							}
						}
						if (result3 != 0)
						{
							int result4 = 0;
							int.TryParse(CS_0024_003C_003E8__locals1.model.pordCurrencyUnitId.ToString(), out result4);
							if (result3 != result4 && result4 != 0)
							{
								_dbI.WSspUpdatePreOrderItemCurrencyUnitId(CS_0024_003C_003E8__locals1.model.PreOrderID, result4, UserLogin.CurrentUser.UserId, short.Parse(now.ToString("MM", new PersianCulture())), now, now.ToString("yyyyMMdd", new PersianCulture()), Configuration.AppType);
							}
						}
						short value = short.Parse(Financial.Get().Id.ToString());
						Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.WSspUpdateUserMoneyBagExpireDateByPord(CS_0024_003C_003E8__locals1.model.PreOrderID, UserLogin.CurrentUser.UserId, value, short.Parse(now.ToString("MM", new PersianCulture())), now, now.ToString("yyyyMMdd", new PersianCulture()), Configuration.AppType));
						if (CS_0024_003C_003E8__locals1.model.pordReferUserId.GetValueOrDefault() != 0)
						{
							Info.Update(CS_0024_003C_003E8__locals1.model.pordReferUserId.GetValueOrDefault(), true);
						}
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					}
				}
				else
				{
					CS_0024_003C_003E8__locals1.model.FPId = Financial.Get().Id;
					CS_0024_003C_003E8__locals1.model.pordTypeId = CS_0024_003C_003E8__locals0.vm.pordTypeId;
					CS_0024_003C_003E8__locals1.model.pordFirstRegisterUserId = CS_0024_003C_003E8__locals0.vm.pordFirstRegisterUserId;
					CS_0024_003C_003E8__locals1.model.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
					CS_0024_003C_003E8__locals1.model.FirstRegisterDate = now;
					CS_0024_003C_003E8__locals1.model.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					CS_0024_003C_003E8__locals1.model.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
					CS_0024_003C_003E8__locals1.model.GUId = System.Guid.NewGuid();
					long num4 = 0L;
					bool flag = false;
					int num5 = 0;
					while (!flag)
					{
						num4 = Enumerable.FirstOrDefault<long>(_db.Database.SqlQuery<long>($"Select dbo.WSfnReturnPreOrderNumber({Financial.Get().Id},{CS_0024_003C_003E8__locals1.model.pordTypeId.GetValueOrDefault()},{num.GetValueOrDefault()})", Array.Empty<object>()));
						CS_0024_003C_003E8__locals1.model.pordNumber = num4;
						num2 = CS_0024_003C_003E8__locals1.model.pordNumber;
						flag = ReservedNumber.AddNumber(sysPartId, num2);
						num5++;
						if (num5 > 10)
						{
							break;
						}
					}
					CS_0024_003C_003E8__locals1.model.pordVerifiedRegisterDate = null;
					CS_0024_003C_003E8__locals1.model.pordVerifiedRegisterDatePersian = null;
					string sql2 = $"Select * from WSfnCheckDuplicatePreOrderNumber({CS_0024_003C_003E8__locals1.model.pordNumber}, 0,{CS_0024_003C_003E8__locals1.model.pordTypeId.GetValueOrDefault()},{num.GetValueOrDefault()})";
					long? num6 = Enumerable.FirstOrDefault<long?>(_db.Database.SqlQuery<long?>(sql2, Array.Empty<object>()));
					if (num6.HasValue && num6 > 0)
					{
						CS_0024_003C_003E8__locals0.vm.pordDate = (CS_0024_003C_003E8__locals0.vm.pordDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDateTime.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.vm.pordDeliveryDate = (CS_0024_003C_003E8__locals0.vm.pordDeliveryDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDeliveryDateTime.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.vm.pordExpireDate = (CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.vm.pordExpireTime = (CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.Value.ToString("HH:mm") : "");
						CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDate = (CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDateTime.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.vm.pordDeadlineDatePersian = (CS_0024_003C_003E8__locals0.vm.pordDeadlineDate.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDeadlineDate.Value.ToString("yyyy/MM/dd") : "");
						base.ViewBag.Error = Messages.PreOrderNumberIsRepeated;
						ReservedNumber.UpdateNumber(sysPartId, num2);
						if (!string.IsNullOrWhiteSpace(text))
						{
							ReservedNumber.UpdateNumber(sysPartId, 0, text);
						}
						return View(CS_0024_003C_003E8__locals0.vm);
					}
					CS_0024_003C_003E8__locals1.model.GUId = System.Guid.NewGuid();
					if (UserLogin.IsUserAccess("frmPreOrderDataEntry", "actAutoCalcNumRef", UserLogin.CurrentUser))
					{
						flag = false;
						num5 = 0;
						while (!flag)
						{
							string pordNumRef = Enumerable.FirstOrDefault<string>((IEnumerable<string>)_db.WSspReturnPreOrderNumRef(CS_0024_003C_003E8__locals1.model.pordCompanyId, CS_0024_003C_003E8__locals1.model.pordProjectId, CS_0024_003C_003E8__locals1.model.pordReferUserId, CS_0024_003C_003E8__locals1.model.pordNumber, CS_0024_003C_003E8__locals1.model.pordNumberRevision, languageID: lCID, defaultLanguageID: CS_0024_003C_003E8__locals0.defLangID, preOrderOprId: CS_0024_003C_003E8__locals1.model.PreOrderOprID, pordTypeId: CS_0024_003C_003E8__locals1.model.pordTypeId, pordCenterId: num));
							CS_0024_003C_003E8__locals1.model.pordNumRef = pordNumRef;
							text = CS_0024_003C_003E8__locals1.model.pordNumRef;
							flag = string.IsNullOrWhiteSpace(text) || !UserLogin.IsUserAccess("frmPreOrderDataEntry", "actNotDupNumRef", UserLogin.CurrentUser) || ReservedNumber.AddNumber(sysPartId, 0, text);
							num5++;
							if (num5 > 10)
							{
								break;
							}
						}
					}
					else
					{
						CS_0024_003C_003E8__locals1.model.pordNumRef = CS_0024_003C_003E8__locals0.vm.pordNumRef;
					}
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals1.model.pordNumRef) && UserLogin.IsUserAccess("frmPreOrderDataEntry", "actNotDupNumRef", UserLogin.CurrentUser))
					{
						WSspCheckDuplicatePreOrderNumRef_Result wSspCheckDuplicatePreOrderNumRef_Result2 = Enumerable.FirstOrDefault<WSspCheckDuplicatePreOrderNumRef_Result>((IEnumerable<WSspCheckDuplicatePreOrderNumRef_Result>)_db.WSspCheckDuplicatePreOrderNumRef(CS_0024_003C_003E8__locals1.model.pordNumRef, CS_0024_003C_003E8__locals1.model.PreOrderID, num));
						if (wSspCheckDuplicatePreOrderNumRef_Result2 != null)
						{
							CS_0024_003C_003E8__locals0.vm.pordDate = (CS_0024_003C_003E8__locals0.vm.pordDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDateTime.Value.ToString("yyyy/MM/dd") : "");
							CS_0024_003C_003E8__locals0.vm.pordDeliveryDate = (CS_0024_003C_003E8__locals0.vm.pordDeliveryDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDeliveryDateTime.Value.ToString("yyyy/MM/dd") : "");
							CS_0024_003C_003E8__locals0.vm.pordExpireDate = (CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.Value.ToString("yyyy/MM/dd") : "");
							CS_0024_003C_003E8__locals0.vm.pordExpireTime = (CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.Value.ToString("HH:mm") : "");
							CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDate = (CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDateTime.Value.ToString("yyyy/MM/dd") : "");
							CS_0024_003C_003E8__locals0.vm.pordDeadlineDatePersian = (CS_0024_003C_003E8__locals0.vm.pordDeadlineDate.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDeadlineDate.Value.ToString("yyyy/MM/dd") : "");
							base.ViewBag.Error = string.Format(Messages.PreOrderNumRefIsRepeated, wSspCheckDuplicatePreOrderNumRef_Result2.pordNumber.ToString());
							ReservedNumber.UpdateNumber(sysPartId, num2);
							if (!string.IsNullOrWhiteSpace(text))
							{
								ReservedNumber.UpdateNumber(sysPartId, 0, text);
							}
							return View(CS_0024_003C_003E8__locals0.vm);
						}
					}
					CS_0024_003C_003E8__locals1.model.pordCId = num;
					_dbTbl.WSPreOrder.Add(CS_0024_003C_003E8__locals1.model);
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					num2 = (ReservedNumber.RemoveNumber(sysPartId, num2) ? 0 : num2);
					if (!string.IsNullOrWhiteSpace(text))
					{
						text = (ReservedNumber.RemoveNumber(sysPartId, 0, text) ? "" : text);
					}
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
					{
						WSPreOrder_Lang wSPreOrder_Lang3 = new WSPreOrder_Lang();
						wSPreOrder_Lang3.LanguageID = lang.LanguageID;
						wSPreOrder_Lang3.PreOrderID = CS_0024_003C_003E8__locals1.model.PreOrderID;
						wSPreOrder_Lang3.pordTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSPreOrder_Lang3.pordSubject = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSPreOrder_Lang3.pordTotalAmountStr = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSPreOrder_Lang3.pordSpecialWord = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSPreOrder_Lang3.pordDescriptionI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSPreOrder_Lang3.pordDescriptionII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSPreOrder_Lang3.pordSigningI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSPreOrder_Lang3.pordSigningII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSPreOrder_Lang3.pordSigningIII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSPreOrder_Lang3.pordAddress = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSPreOrder_Lang3.pordDiscountTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSPreOrder_Lang3.pordcmpTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						_dbTbl.WSPreOrder_Lang.Add(wSPreOrder_Lang3);
						_dbTbl.SaveChanges();
					}
					CS_0024_003C_003E8__locals0.vm.PreOrderID = CS_0024_003C_003E8__locals1.model.PreOrderID;
					if (CS_0024_003C_003E8__locals1.model.PreOrderID != 0)
					{
						_dbII.WSspCalcAndUpdatePreOrderAmountsCurrency(CS_0024_003C_003E8__locals1.model.PreOrderID, lCID, CS_0024_003C_003E8__locals0.defLangID);
					}
					base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
				}
			}
		}
		catch (DbEntityValidationException ex)
		{
			Public.InsExceptToElmah((Exception)(object)ex);
			base.ViewBag.Error = Messages.frmErrorMessage;
		}
		catch (Exception ex2)
		{
			Public.InsExceptToElmah(ex2);
			base.ViewBag.Error = Messages.frmErrorMessage;
		}
		CS_0024_003C_003E8__locals0.vm.pordDate = (CS_0024_003C_003E8__locals0.vm.pordDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDateTime.Value.ToString("yyyy/MM/dd") : "");
		CS_0024_003C_003E8__locals0.vm.pordDeliveryDate = (CS_0024_003C_003E8__locals0.vm.pordDeliveryDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDeliveryDateTime.Value.ToString("yyyy/MM/dd") : "");
		CS_0024_003C_003E8__locals0.vm.pordExpireDate = (CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.Value.ToString("yyyy/MM/dd") : "");
		CS_0024_003C_003E8__locals0.vm.pordExpireTime = (CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordExpireDateTime.Value.ToString("HH:mm") : "");
		CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDate = (CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDeliveryEndDateTime.Value.ToString("yyyy/MM/dd") : "");
		CS_0024_003C_003E8__locals0.vm.pordDeadlineDatePersian = (CS_0024_003C_003E8__locals0.vm.pordDeadlineDate.HasValue ? CS_0024_003C_003E8__locals0.vm.pordDeadlineDate.Value.ToString("yyyy/MM/dd") : "");
		if (num2 != 0L)
		{
			ReservedNumber.RemoveNumber(sysPartId, num2);
		}
		if (!string.IsNullOrWhiteSpace(text))
		{
			ReservedNumber.RemoveNumber(sysPartId, 0, text);
		}
		return View(CS_0024_003C_003E8__locals0.vm);
	}

	[AjaxOnly]
	public JsonResult PreOrderItemTax(int preOrderId)
	{
		decimal? num = Enumerable.FirstOrDefault<decimal?>(_db.Database.SqlQuery<decimal?>($"Select * from dbo.WSfnReturnPreOrderItemTax({preOrderId})", Array.Empty<object>()));
		if (!num.HasValue)
		{
			num = default(decimal);
		}
		return Json(num, JsonRequestBehavior.AllowGet);
	}

	public FileResult GetLogoPreOrder(int id = 0)
	{
		try
		{
			byte[] array = null;
			WSspSelectWSLogo_Result wSspSelectWSLogo_Result = new WSspSelectWSLogo_Result();
			if (id != 0)
			{
				WSspSelectWSLogo_Result wSspSelectWSLogo_Result2 = Enumerable.FirstOrDefault<WSspSelectWSLogo_Result>((IEnumerable<WSspSelectWSLogo_Result>)_db.WSspSelectWSLogo(id));
				if (wSspSelectWSLogo_Result2 != null)
				{
					wSspSelectWSLogo_Result = wSspSelectWSLogo_Result2;
					if (wSspSelectWSLogo_Result != null)
					{
						array = wSspSelectWSLogo_Result.Logo;
						Image.FromStream((Stream)new MemoryStream(array, writable: false));
					}
				}
				return File(array, "image/jpeg");
			}
			return null;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return null;
		}
	}

	[AjaxOnly]
	public JsonResult GetPreOrderDefaultSetting(int id)
	{
		_003C_003Ec__DisplayClass40_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass40_0();
		CS_0024_003C_003E8__locals0.id = id;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		DbSet<WSPreOrderDefaultSetting> wSPreOrderDefaultSetting = _dbTbl.WSPreOrderDefaultSetting;
		ParameterExpression val = Expression.Parameter(typeof(WSPreOrderDefaultSetting), "c");
		WSPreOrderDefaultSetting wSPreOrderDefaultSetting2 = Queryable.FirstOrDefault<WSPreOrderDefaultSetting>((IQueryable<WSPreOrderDefaultSetting>)wSPreOrderDefaultSetting, Expression.Lambda<Func<WSPreOrderDefaultSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass40_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
		WSspSelectPreOrderDefaultSettingByReferUserIdLanguageViewModel wSspSelectPreOrderDefaultSettingByReferUserIdLanguageViewModel = new WSspSelectPreOrderDefaultSettingByReferUserIdLanguageViewModel();
		if (wSPreOrderDefaultSetting2 != null)
		{
			DbSet<WSPreOrderDefaultSetting_Lang> wSPreOrderDefaultSetting_Lang = _dbTbl.WSPreOrderDefaultSetting_Lang;
			val = Expression.Parameter(typeof(WSPreOrderDefaultSetting_Lang), "c");
			List<WSPreOrderDefaultSetting_Lang> list = Enumerable.ToList<WSPreOrderDefaultSetting_Lang>((IEnumerable<WSPreOrderDefaultSetting_Lang>)Queryable.Where<WSPreOrderDefaultSetting_Lang>((IQueryable<WSPreOrderDefaultSetting_Lang>)wSPreOrderDefaultSetting_Lang, Expression.Lambda<Func<WSPreOrderDefaultSetting_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass40_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrderDefaultSetting_Lang>)list, (Func<WSPreOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSPreOrderDefaultSetting_Lang myitem) => new CommonMultiLanguageViewModel
			{
				Value = myitem.Title,
				LanguageId = myitem.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = wSPreOrderDefaultSetting2.Title,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrderDefaultSetting_Lang>)list, (Func<WSPreOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSPreOrderDefaultSetting_Lang myitem) => new CommonMultiLanguageViewModel
			{
				Value = myitem.DescriptionI,
				LanguageId = myitem.LanguageID
			})));
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = wSPreOrderDefaultSetting2.DescriptionI,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrderDefaultSetting_Lang>)list, (Func<WSPreOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSPreOrderDefaultSetting_Lang myitem) => new CommonMultiLanguageViewModel
			{
				Value = myitem.DescriptionII,
				LanguageId = myitem.LanguageID
			})));
			list4.Add(new CommonMultiLanguageViewModel
			{
				Value = wSPreOrderDefaultSetting2.DescriptionII,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list5 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrderDefaultSetting_Lang>)list, (Func<WSPreOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSPreOrderDefaultSetting_Lang myitem) => new CommonMultiLanguageViewModel
			{
				Value = myitem.Subject,
				LanguageId = myitem.LanguageID
			})));
			list5.Add(new CommonMultiLanguageViewModel
			{
				Value = wSPreOrderDefaultSetting2.Subject,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list6 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrderDefaultSetting_Lang>)list, (Func<WSPreOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSPreOrderDefaultSetting_Lang myitem) => new CommonMultiLanguageViewModel
			{
				Value = myitem.SpecialWord,
				LanguageId = myitem.LanguageID
			})));
			list6.Add(new CommonMultiLanguageViewModel
			{
				Value = wSPreOrderDefaultSetting2.SpecialWord,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list7 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrderDefaultSetting_Lang>)list, (Func<WSPreOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSPreOrderDefaultSetting_Lang myitem) => new CommonMultiLanguageViewModel
			{
				Value = myitem.SettingTitle,
				LanguageId = myitem.LanguageID
			})));
			list7.Add(new CommonMultiLanguageViewModel
			{
				Value = wSPreOrderDefaultSetting2.SettingTitle,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list8 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrderDefaultSetting_Lang>)list, (Func<WSPreOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSPreOrderDefaultSetting_Lang myitem) => new CommonMultiLanguageViewModel
			{
				Value = myitem.SigningI,
				LanguageId = myitem.LanguageID
			})));
			list8.Add(new CommonMultiLanguageViewModel
			{
				Value = wSPreOrderDefaultSetting2.SigningI,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list9 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrderDefaultSetting_Lang>)list, (Func<WSPreOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSPreOrderDefaultSetting_Lang myitem) => new CommonMultiLanguageViewModel
			{
				Value = myitem.SigningII,
				LanguageId = myitem.LanguageID
			})));
			list9.Add(new CommonMultiLanguageViewModel
			{
				Value = wSPreOrderDefaultSetting2.SigningII,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list10 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrderDefaultSetting_Lang>)list, (Func<WSPreOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSPreOrderDefaultSetting_Lang myitem) => new CommonMultiLanguageViewModel
			{
				Value = myitem.SigningIII,
				LanguageId = myitem.LanguageID
			})));
			list10.Add(new CommonMultiLanguageViewModel
			{
				Value = wSPreOrderDefaultSetting2.SigningIII,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list11 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrderDefaultSetting_Lang>)list, (Func<WSPreOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSPreOrderDefaultSetting_Lang myitem) => new CommonMultiLanguageViewModel
			{
				Value = myitem.Address,
				LanguageId = myitem.LanguageID
			})));
			list11.Add(new CommonMultiLanguageViewModel
			{
				Value = wSPreOrderDefaultSetting2.Address,
				LanguageId = result
			});
			wSspSelectPreOrderDefaultSettingByReferUserIdLanguageViewModel = new WSspSelectPreOrderDefaultSettingByReferUserIdLanguageViewModel
			{
				UserId = wSPreOrderDefaultSetting2.UserId,
				AppType = wSPreOrderDefaultSetting2.AppType,
				GUId = wSPreOrderDefaultSetting2.GUId,
				RegisterDate = wSPreOrderDefaultSetting2.RegisterDate,
				Month1 = wSPreOrderDefaultSetting2.Month1,
				RegisterDatePersian = wSPreOrderDefaultSetting2.RegisterDatePersian,
				FPId = wSPreOrderDefaultSetting2.FPId,
				Email = wSPreOrderDefaultSetting2.Email,
				WebSite = wSPreOrderDefaultSetting2.WebSite,
				Telephone = wSPreOrderDefaultSetting2.Telephone,
				PreOrderOprID = wSPreOrderDefaultSetting2.PreOrderOprID,
				Fax = wSPreOrderDefaultSetting2.Fax,
				VerifierRequestId = wSPreOrderDefaultSetting2.VerifierRequestId,
				GuarantyId = wSPreOrderDefaultSetting2.GuarantyId,
				AccountNumberI = wSPreOrderDefaultSetting2.AccountNumberI,
				AccountNumberII = wSPreOrderDefaultSetting2.AccountNumberII,
				PreOrderSettingID = wSPreOrderDefaultSetting2.PreOrderSettingID,
				PrintFormatId = wSPreOrderDefaultSetting2.PrintFormatId,
				AccountShabaNumberI = wSPreOrderDefaultSetting2.AccountShabaNumberI,
				AccountShabaNumberII = wSPreOrderDefaultSetting2.AccountShabaNumberII,
				CalculateTax = wSPreOrderDefaultSetting2.CalculateTax,
				CreditDurationId = wSPreOrderDefaultSetting2.CreditDurationId,
				DeliveryTimeId = wSPreOrderDefaultSetting2.DeliveryTimeId,
				LeftLogoId = wSPreOrderDefaultSetting2.LeftLogoId,
				PayConditionId = wSPreOrderDefaultSetting2.PayConditionId,
				ReferUserId = wSPreOrderDefaultSetting2.ReferUserId,
				RightLogoId = wSPreOrderDefaultSetting2.RightLogoId,
				SignatureId = wSPreOrderDefaultSetting2.SignatureId,
				TaxIndex = wSPreOrderDefaultSetting2.TaxIndex,
				Title_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				Title = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				DescriptionI_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				DescriptionI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				DescriptionII_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				DescriptionII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				Subject_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				Subject = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				SpecialWord_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				SpecialWord = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				SettingTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				SettingTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				SigningI_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				SigningI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				SigningII_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				SigningII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				SigningIII_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				SigningIII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				Address_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				Address = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
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
				CurrencyUnitIdI = wSPreOrderDefaultSetting2.CurrencyUnitIdI,
				SaleAreaId = wSPreOrderDefaultSetting2.SaleAreaId
			};
			if (wSspSelectPreOrderDefaultSettingByReferUserIdLanguageViewModel != null && wSspSelectPreOrderDefaultSettingByReferUserIdLanguageViewModel.SaleCenterId.GetValueOrDefault() != 0)
			{
				WSspSelectSaleCenterWithId_Result wSspSelectSaleCenterWithId_Result = Enumerable.FirstOrDefault<WSspSelectSaleCenterWithId_Result>((IEnumerable<WSspSelectSaleCenterWithId_Result>)_dbII.WSspSelectSaleCenterWithId(wSspSelectPreOrderDefaultSettingByReferUserIdLanguageViewModel.SaleCenterId, CS_0024_003C_003E8__locals0.currLangID, result));
				if (wSspSelectSaleCenterWithId_Result != null)
				{
					wSspSelectPreOrderDefaultSettingByReferUserIdLanguageViewModel.SaleCenterName = wSspSelectSaleCenterWithId_Result.SaleCenterName ?? "";
				}
			}
		}
		return Json(wSspSelectPreOrderDefaultSettingByReferUserIdLanguageViewModel, JsonRequestBehavior.AllowGet);
	}

	[LoginAuthorize]
	public ActionResult SearchCompany(string formName = null)
	{
		if (string.IsNullOrEmpty(formName))
		{
			formName = "frmPreOrderDataEntry";
		}
		switch (formName)
		{
		case "frmCompanyI":
			if (!UserLogin.IsUserAccess(formName, "actLinkedCompanyAdd"))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			base.ViewBag.SendFormName = formName;
			return View();
		case "frmShpExProductDetails":
		case "frmCompanyReportOperation":
		case "frmIssueBuyOrderFromStockSupply":
		case "frmIssueOrderFromBuyOrder":
		case "frmOrderCommission":
		case "frmAddOrderOprExceptTspCmp":
			base.ViewBag.SendFormName = formName;
			return View();
		case "frmLeaveDataEntry":
			if (!UserLogin.IsUserAccess(formName, "actMissionSearchCompany"))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			base.ViewBag.SendFormName = formName;
			return View();
		default:
			if (!UserLogin.IsUserAccess(formName, "actSearchCompany"))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			base.ViewBag.SendFormName = formName;
			return View();
		}
	}

	private void FillDropdownPOrder()
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
			List<CRMspSelectUserForLinkedType_Result> list3 = Enumerable.ToList<CRMspSelectUserForLinkedType_Result>((IEnumerable<CRMspSelectUserForLinkedType_Result>)_db.CRMspSelectUserForLinkedType(UserLogin.CurrentUser.UserId, 7, lCID, result, result2));
			List<SelectListItem> list4 = new List<SelectListItem>();
			list4.AddRange(Enumerable.Select<CRMspSelectUserForLinkedType_Result, SelectListItem>((IEnumerable<CRMspSelectUserForLinkedType_Result>)list3, (Func<CRMspSelectUserForLinkedType_Result, SelectListItem>)((CRMspSelectUserForLinkedType_Result item) => new SelectListItem
			{
				Text = item.UserName,
				Value = item.LinkedUserId.ToString(),
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
			List<WSspSelectPreOrderDefaultSettingUserAccess_Result> list19 = Enumerable.ToList<WSspSelectPreOrderDefaultSettingUserAccess_Result>((IEnumerable<WSspSelectPreOrderDefaultSettingUserAccess_Result>)_dbIII.WSspSelectPreOrderDefaultSettingUserAccess(UserLogin.CurrentUser.UserId, lCID, result));
			List<SelectListItem> list20 = new List<SelectListItem>();
			list20.AddRange(Enumerable.Select<WSspSelectPreOrderDefaultSettingUserAccess_Result, SelectListItem>((IEnumerable<WSspSelectPreOrderDefaultSettingUserAccess_Result>)list19, (Func<WSspSelectPreOrderDefaultSettingUserAccess_Result, SelectListItem>)((WSspSelectPreOrderDefaultSettingUserAccess_Result item) => new SelectListItem
			{
				Text = item.SettingTitle,
				Value = item.PreOrderSettingID.ToString(),
				Selected = false
			})));
			base.ViewBag.PordDefSettingList = list20;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	[AjaxOnly]
	public JsonResult GetPordOpr()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmDroupDownItem> list = new List<CrmDroupDownItem>();
		try
		{
			list = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<WSspSelectPreOrderOpr_Result, CrmDroupDownItem>((IEnumerable<WSspSelectPreOrderOpr_Result>)Enumerable.ToList<WSspSelectPreOrderOpr_Result>((IEnumerable<WSspSelectPreOrderOpr_Result>)_db.WSspSelectPreOrderOpr(lCID, result)), (Func<WSspSelectPreOrderOpr_Result, CrmDroupDownItem>)((WSspSelectPreOrderOpr_Result item) => new CrmDroupDownItem
			{
				text = item.PreOrderOpr,
				value = item.PreOrderOprID.ToString()
			})));
			base.ViewBag.PordOprList = list;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPordGuaranty()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmDroupDownItem> list = new List<CrmDroupDownItem>();
		try
		{
			list = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<WSspSelectGuaranty_Result, CrmDroupDownItem>((IEnumerable<WSspSelectGuaranty_Result>)Enumerable.ToList<WSspSelectGuaranty_Result>((IEnumerable<WSspSelectGuaranty_Result>)_db.WSspSelectGuaranty(lCID, result)), (Func<WSspSelectGuaranty_Result, CrmDroupDownItem>)((WSspSelectGuaranty_Result item) => new CrmDroupDownItem
			{
				text = item.Guaranty,
				value = item.GuarantyID.ToString()
			})));
			base.ViewBag.PordGuarantyList = list;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPordDeliveryTime()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmDroupDownItem> list = new List<CrmDroupDownItem>();
		try
		{
			list = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<WSspSelectDeliveryTime_Result, CrmDroupDownItem>((IEnumerable<WSspSelectDeliveryTime_Result>)Enumerable.ToList<WSspSelectDeliveryTime_Result>((IEnumerable<WSspSelectDeliveryTime_Result>)_db.WSspSelectDeliveryTime(lCID, result)), (Func<WSspSelectDeliveryTime_Result, CrmDroupDownItem>)((WSspSelectDeliveryTime_Result item) => new CrmDroupDownItem
			{
				text = item.DeliveryTime,
				value = item.DeliveryTimeID.ToString()
			})));
			base.ViewBag.PordDeliveryTimeList = list;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPordPayCondition()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmDroupDownItem> list = new List<CrmDroupDownItem>();
		try
		{
			list = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<WSspSelectPayCondition_Result, CrmDroupDownItem>((IEnumerable<WSspSelectPayCondition_Result>)Enumerable.ToList<WSspSelectPayCondition_Result>((IEnumerable<WSspSelectPayCondition_Result>)_db.WSspSelectPayCondition(lCID, result)), (Func<WSspSelectPayCondition_Result, CrmDroupDownItem>)((WSspSelectPayCondition_Result item) => new CrmDroupDownItem
			{
				text = item.PayCondition,
				value = item.PayConditionID.ToString()
			})));
			base.ViewBag.PordPayConditionList = list;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPordCreditDuration()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmDroupDownItem> list = new List<CrmDroupDownItem>();
		try
		{
			list = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<WSspSelectCreditDuration_Result, CrmDroupDownItem>((IEnumerable<WSspSelectCreditDuration_Result>)Enumerable.ToList<WSspSelectCreditDuration_Result>((IEnumerable<WSspSelectCreditDuration_Result>)_db.WSspSelectCreditDuration(lCID, result)), (Func<WSspSelectCreditDuration_Result, CrmDroupDownItem>)((WSspSelectCreditDuration_Result item) => new CrmDroupDownItem
			{
				text = item.CreditDuration,
				value = item.CreditDurationID.ToString()
			})));
			base.ViewBag.PordCreditDurationList = list;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPordPrintFormat()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmDroupDownItem> list = new List<CrmDroupDownItem>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			list = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<spSelectPrintFormat_Result, CrmDroupDownItem>((IEnumerable<spSelectPrintFormat_Result>)CRMIdeal.Classes.Helper.PrintFormat.GetspPrintFortants(result2, 1), (Func<spSelectPrintFormat_Result, CrmDroupDownItem>)((spSelectPrintFormat_Result item) => new CrmDroupDownItem
			{
				text = item.Title,
				value = item.PrintFormatID.ToString()
			})));
			base.ViewBag.PordPrintFormatList = list;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPordDefSetting(int? id = null)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmDroupDownItem> list = new List<CrmDroupDownItem>();
		try
		{
			if (!id.HasValue)
			{
				id = UserLogin.CurrentUser.UserId;
			}
			list = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<WSspSelectPreOrderDefaultSettingUserAccess_Result, CrmDroupDownItem>((IEnumerable<WSspSelectPreOrderDefaultSettingUserAccess_Result>)Enumerable.ToList<WSspSelectPreOrderDefaultSettingUserAccess_Result>((IEnumerable<WSspSelectPreOrderDefaultSettingUserAccess_Result>)_dbIII.WSspSelectPreOrderDefaultSettingUserAccess(id, lCID, result)), (Func<WSspSelectPreOrderDefaultSettingUserAccess_Result, CrmDroupDownItem>)((WSspSelectPreOrderDefaultSettingUserAccess_Result item) => new CrmDroupDownItem
			{
				text = item.SettingTitle,
				value = item.PreOrderSettingID.ToString()
			})));
			base.ViewBag.PordDefSettingList = list;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPordCompany()
	{
		List<CRMfnSelectNotForbiddenCompany_Result> list = new List<CRMfnSelectNotForbiddenCompany_Result>();
		try
		{
			list.Add(new CRMfnSelectNotForbiddenCompany_Result
			{
				CompanyID = -1,
				cmpName = Labels.SelectedListDefValue,
				cmpAddress = ""
			});
			int result = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
			}
			List<CRMfnSelectNotForbiddenCompany_Result> list2 = Enumerable.ToList<CRMfnSelectNotForbiddenCompany_Result>((IEnumerable<CRMfnSelectNotForbiddenCompany_Result>)_db.CRMfnSelectNotForbiddenCompany(UserLogin.CurrentUser.UserId, result));
			list.AddRange(Enumerable.Select<CRMfnSelectNotForbiddenCompany_Result, CRMfnSelectNotForbiddenCompany_Result>((IEnumerable<CRMfnSelectNotForbiddenCompany_Result>)list2, (Func<CRMfnSelectNotForbiddenCompany_Result, CRMfnSelectNotForbiddenCompany_Result>)((CRMfnSelectNotForbiddenCompany_Result item) => new CRMfnSelectNotForbiddenCompany_Result
			{
				cmpName = item.cmpName,
				CompanyID = item.CompanyID,
				cmpAddress = ((!string.IsNullOrEmpty(item.cmpAddress)) ? item.cmpAddress : "")
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPordCompanyPerson(int cmpId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectCompanyPersons_Result> list = new List<CRMspSelectCompanyPersons_Result>();
		try
		{
			List<CRMspSelectCompanyPersons_Result> list2 = CRMIdeal.Classes.Helper.Company.SelectCompanyPersons(cmpId, 0, false);
			list.Add(new CRMspSelectCompanyPersons_Result
			{
				CompanyPersonID = -1,
				PersonName = Labels.SelectedListDefValue
			});
			list.AddRange(Enumerable.Select<CRMspSelectCompanyPersons_Result, CRMspSelectCompanyPersons_Result>((IEnumerable<CRMspSelectCompanyPersons_Result>)list2, (Func<CRMspSelectCompanyPersons_Result, CRMspSelectCompanyPersons_Result>)((CRMspSelectCompanyPersons_Result item) => new CRMspSelectCompanyPersons_Result
			{
				CompanyPersonID = item.CompanyPersonID,
				PersonName = item.PersonTitleName,
				IsMainPerson = item.IsMainPerson,
				prsJob = item.prsJob,
				prsDepartment = item.prsDepartment
			})));
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
	public JsonResult GetPordCompanyProject(string cmpIdReferUserId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectCrmProjectBycmpAndUser_Result> list = new List<WSspSelectCrmProjectBycmpAndUser_Result>();
		try
		{
			int value = 0;
			int value2 = 0;
			if (cmpIdReferUserId != null)
			{
				string[] array = cmpIdReferUserId.Split(new char[1] { '|' });
				if (array[0] != null)
				{
					array[0] = ((array[0] == "0") ? "" : array[0]);
				}
				value = ((array[0] != null) ? int.Parse(array[0]) : 0);
				value2 = ((array[1] != null) ? int.Parse(array[1]) : 0);
			}
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<WSspSelectCrmProjectBycmpAndUser_Result> list2 = Enumerable.ToList<WSspSelectCrmProjectBycmpAndUser_Result>((IEnumerable<WSspSelectCrmProjectBycmpAndUser_Result>)_db.WSspSelectCrmProjectBycmpAndUser(value, value2, lCID, result, result2));
			list.Add(new WSspSelectCrmProjectBycmpAndUser_Result
			{
				ProjectID = -1,
				prjTitle = Labels.SelectedListDefValue
			});
			list.AddRange(Enumerable.Select<WSspSelectCrmProjectBycmpAndUser_Result, WSspSelectCrmProjectBycmpAndUser_Result>((IEnumerable<WSspSelectCrmProjectBycmpAndUser_Result>)list2, (Func<WSspSelectCrmProjectBycmpAndUser_Result, WSspSelectCrmProjectBycmpAndUser_Result>)((WSspSelectCrmProjectBycmpAndUser_Result item) => new WSspSelectCrmProjectBycmpAndUser_Result
			{
				ProjectID = item.ProjectID,
				prjTitle = item.prjTitle,
				prjcmpQuickRegisterDefSettingId = item.prjcmpQuickRegisterDefSettingId,
				prjpordDefaultSettingId = item.prjpordDefaultSettingId,
				prjordDefaultSettingId = item.prjordDefaultSettingId
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
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
			List<WSspSelectVerificationWorkFlowWithObjectType_Result> list2 = Enumerable.ToList<WSspSelectVerificationWorkFlowWithObjectType_Result>((IEnumerable<WSspSelectVerificationWorkFlowWithObjectType_Result>)_db.WSspSelectVerificationWorkFlowWithObjectType(10, lCID, result));
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
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			_ = Configuration.MaxCountOfOnlineUser;
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
	public JsonResult GetPordReferUser(int pordId = 0)
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
			_ = Configuration.MaxCountOfOnlineUser;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (pordId != 0)
			{
				List<CRMspSelectUserForLinkedType_Result> list2 = Enumerable.ToList<CRMspSelectUserForLinkedType_Result>((IEnumerable<CRMspSelectUserForLinkedType_Result>)_db.CRMspSelectUserForLinkedType(UserLogin.CurrentUser.UserId, 7, lCID, result, result2));
				list.AddRange(Enumerable.Select<CRMspSelectUserForLinkedType_Result, SelectListItem>((IEnumerable<CRMspSelectUserForLinkedType_Result>)list2, (Func<CRMspSelectUserForLinkedType_Result, SelectListItem>)((CRMspSelectUserForLinkedType_Result item) => new SelectListItem
				{
					Text = item.UserName,
					Value = item.LinkedUserId.ToString(),
					Selected = false
				})));
			}
			else
			{
				List<CRMspSelectUserForLinkedTypeIsActive_Result> list3 = Enumerable.ToList<CRMspSelectUserForLinkedTypeIsActive_Result>((IEnumerable<CRMspSelectUserForLinkedTypeIsActive_Result>)_dbI.CRMspSelectUserForLinkedTypeIsActive(UserLogin.CurrentUser.UserId, 7, lCID, result, result2));
				list.AddRange(Enumerable.Select<CRMspSelectUserForLinkedTypeIsActive_Result, SelectListItem>((IEnumerable<CRMspSelectUserForLinkedTypeIsActive_Result>)list3, (Func<CRMspSelectUserForLinkedTypeIsActive_Result, SelectListItem>)((CRMspSelectUserForLinkedTypeIsActive_Result item) => new SelectListItem
				{
					Text = item.UserName,
					Value = item.LinkedUserId.ToString(),
					Selected = false
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ReferUserList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetEmailUsersInfo()
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
			List<EmailspSelectActiveEmailUsersInfoByUserId_Result> list2 = Enumerable.ToList<EmailspSelectActiveEmailUsersInfoByUserId_Result>((IEnumerable<EmailspSelectActiveEmailUsersInfoByUserId_Result>)_db.EmailspSelectActiveEmailUsersInfoByUserId(UserLogin.CurrentUser.UserId));
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
	public JsonResult GetEmailUserDefaultSetting()
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
			List<EmailspSelectEmailUserDefaultSettingByUser_Result> list2 = Enumerable.ToList<EmailspSelectEmailUserDefaultSettingByUser_Result>((IEnumerable<EmailspSelectEmailUserDefaultSettingByUser_Result>)_db.EmailspSelectEmailUserDefaultSettingByUser(UserLogin.CurrentUser.UserId));
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

	public List<WSspSelectSaleCenters_Result> SelectSaleCenters()
	{
		List<WSspSelectSaleCenters_Result> list = new List<WSspSelectSaleCenters_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			list = Enumerable.ToList<WSspSelectSaleCenters_Result>((IEnumerable<WSspSelectSaleCenters_Result>)_db.WSspSelectSaleCenters(lCID, result));
			if (list == null)
			{
				list = new List<WSspSelectSaleCenters_Result>();
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return list;
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectSaleCentersJs()
	{
		return JsonConvert.SerializeObject(SelectSaleCenters());
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
	public ActionResult _PartialSearchCompany(string txtSearchValue, int mode)
	{
		base.ViewBag.txtSearch = txtSearchValue;
		base.ViewBag.mode = mode;
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult SearchCompany_Read([DataSourceRequest] DataSourceRequest request, string txtSearchValue, int mode)
	{
		List<CRMspMainSearchViewModel> list = new List<CRMspMainSearchViewModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			string searchConditionMode = "";
			if (mode == 1)
			{
				searchConditionMode = ",1000,1,2,3,8,9,11,12,14,17,20,21,22,";
			}
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspMainSearchWeb_Result> list2 = Enumerable.ToList<CRMspMainSearchWeb_Result>((IEnumerable<CRMspMainSearchWeb_Result>)_dbI.CRMspMainSearchWeb(txtSearchValue, UserLogin.CurrentUser.UserId, mode, lCID, result, searchConditionMode, result2));
			list.AddRange(Enumerable.Select<CRMspMainSearchWeb_Result, CRMspMainSearchViewModel>((IEnumerable<CRMspMainSearchWeb_Result>)list2, (Func<CRMspMainSearchWeb_Result, CRMspMainSearchViewModel>)((CRMspMainSearchWeb_Result company) => new CRMspMainSearchViewModel
			{
				CompanyID = company.CompanyID.GetValueOrDefault(),
				cmpTitle = company.cmpTitle,
				cmpName = company.cmpName,
				cmpNameWithTitle = company.cmpNameWithTitle,
				cmpNumber = company.cmpNumber,
				cmpPreTel = company.cmpPreTel,
				cmpTel = company.cmpTel,
				cmpTelUpTo = company.cmpTelUpTo,
				cmpPreTelII = company.cmpPreTelII,
				cmpTelII = company.cmpTelII,
				cmpTelUpToII = company.cmpTelUpToII,
				cmpFax = company.cmpFax,
				cmpMobile = company.cmpMobile,
				Country = company.Country,
				Province = company.Province,
				City = company.City,
				cmpAddress = company.cmpAddress,
				ReferUser = company.ReferUser,
				cmpPresentation = company.cmpPresentation,
				cmpType = company.cmpType,
				cmpGroup = company.cmpGroup,
				cmpSubGroup = company.cmpSubGroup,
				cmpGroupII = company.cmpGroupII,
				prsFName = company.prsFName,
				prsLName = company.prsLName,
				PrsName = company.PrsName,
				prsFax = company.prsFax,
				prsMobile = company.prsMobile,
				prsTel = company.prsTel,
				prsTelDesc = company.prsTelDesc,
				prsTelII = company.prsTelII,
				PrjTitle = company.PrjTitle,
				cnvsDesc = company.cnvsDesc,
				cnvsSubject = company.cnvsSubject,
				cnvsTopic = company.cnvsTopic,
				prsId = company.prsId,
				prjId = company.prjId,
				ConversationID = company.ConversationID,
				cmpReferUserId = company.cmpReferUserId,
				cmpCoordinateLatitude = company.cmpCoordinateLatitude,
				cmpCoordinateLongitude = company.cmpCoordinateLongitude,
				cmpCoordinateZoomLevel = company.cmpCoordinateZoomLevel,
				cmpCountryId = company.cmpCountryId,
				cmpProvinceId = company.cmpProvinceId,
				cmpCityId = company.cmpCityId
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request));
	}

	[AjaxOnly]
	public JsonResult GetReasonGroups()
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
			List<WSspSelectPreOrderPrdGroupMustExistReasonGroups_Result> list2 = Enumerable.ToList<WSspSelectPreOrderPrdGroupMustExistReasonGroups_Result>((IEnumerable<WSspSelectPreOrderPrdGroupMustExistReasonGroups_Result>)_db.WSspSelectPreOrderPrdGroupMustExistReasonGroups(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectPreOrderPrdGroupMustExistReasonGroups_Result, SelectListItem>((IEnumerable<WSspSelectPreOrderPrdGroupMustExistReasonGroups_Result>)list2, (Func<WSspSelectPreOrderPrdGroupMustExistReasonGroups_Result, SelectListItem>)((WSspSelectPreOrderPrdGroupMustExistReasonGroups_Result item) => new SelectListItem
			{
				Text = item.PrdGroupMustExistReasonGroupTitle + (item.NeedReasonTxt.GetValueOrDefault() ? (" " + Labels.PrdGroupMustExistReasonGroupNeedReasonTxt) : ""),
				Value = item.PrdGroupMustExistReasonGroupId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ReasonGroupsList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult PrdGroupMustExistInPreOrderStatusBycmpPrjId_Read([DataSourceRequest] DataSourceRequest request, int pordProjectId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspPrdGroupMustExistInPreOrderStatusBycmpPrjId_Result> enumerable = new List<WSspPrdGroupMustExistInPreOrderStatusBycmpPrjId_Result>();
		try
		{
			enumerable = Enumerable.ToList<WSspPrdGroupMustExistInPreOrderStatusBycmpPrjId_Result>((IEnumerable<WSspPrdGroupMustExistInPreOrderStatusBycmpPrjId_Result>)_db.WSspPrdGroupMustExistInPreOrderStatusBycmpPrjId(pordProjectId, lCID, result));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult PrdGroupMustExistInPreOrderStatusDetails_Read([DataSourceRequest] DataSourceRequest request, int pordProjectId, int prdFirstGroupId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		new List<WSspPrdGroupMustExistInPreOrderStatusDetails_Result>();
		List<WSspPrdGroupMustExistInPreOrderStatusDetails_ResultLanguageViewModel> list = new List<WSspPrdGroupMustExistInPreOrderStatusDetails_ResultLanguageViewModel>();
		try
		{
			using List<WSspPrdGroupMustExistInPreOrderStatusDetails_Result>.Enumerator enumerator = Enumerable.ToList<WSspPrdGroupMustExistInPreOrderStatusDetails_Result>((IEnumerable<WSspPrdGroupMustExistInPreOrderStatusDetails_Result>)_db.WSspPrdGroupMustExistInPreOrderStatusDetails(pordProjectId, prdFirstGroupId, result, result)).GetEnumerator();
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass73_1 _003C_003Ec__DisplayClass73_ = new _003C_003Ec__DisplayClass73_1();
				_003C_003Ec__DisplayClass73_.item = enumerator.Current;
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				if (_003C_003Ec__DisplayClass73_.item.recType == 2)
				{
					DbSet<WSPreOrderPrdGroupMustExistReasons_Lang> wSPreOrderPrdGroupMustExistReasons_Lang = _dbTbl.WSPreOrderPrdGroupMustExistReasons_Lang;
					ParameterExpression val = Expression.Parameter(typeof(WSPreOrderPrdGroupMustExistReasons_Lang), "c");
					list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrderPrdGroupMustExistReasons_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrderPrdGroupMustExistReasons_Lang>)Enumerable.ToList<WSPreOrderPrdGroupMustExistReasons_Lang>((IEnumerable<WSPreOrderPrdGroupMustExistReasons_Lang>)Queryable.Where<WSPreOrderPrdGroupMustExistReasons_Lang>((IQueryable<WSPreOrderPrdGroupMustExistReasons_Lang>)wSPreOrderPrdGroupMustExistReasons_Lang, Expression.Lambda<Func<WSPreOrderPrdGroupMustExistReasons_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass73_, typeof(_003C_003Ec__DisplayClass73_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }))), (Func<WSPreOrderPrdGroupMustExistReasons_Lang, CommonMultiLanguageViewModel>)((WSPreOrderPrdGroupMustExistReasons_Lang Myitem) => new CommonMultiLanguageViewModel
					{
						Value = Myitem.Reason,
						LanguageId = Myitem.LanguageID
					})));
					list2.Add(new CommonMultiLanguageViewModel
					{
						Value = _003C_003Ec__DisplayClass73_.item.Reason,
						LanguageId = result
					});
				}
				list.Add(new WSspPrdGroupMustExistInPreOrderStatusDetails_ResultLanguageViewModel
				{
					GroupId = _003C_003Ec__DisplayClass73_.item.GroupId,
					pordDate = (_003C_003Ec__DisplayClass73_.item.pordDateTime.HasValue ? _003C_003Ec__DisplayClass73_.item.pordDateTime.Value.ToString("yyyyMMdd") : _003C_003Ec__DisplayClass73_.item.pordDate),
					pordDateTime = _003C_003Ec__DisplayClass73_.item.pordDateTime,
					pordNumber = _003C_003Ec__DisplayClass73_.item.pordNumber,
					PordOrResId = _003C_003Ec__DisplayClass73_.item.PordOrResId,
					recType = _003C_003Ec__DisplayClass73_.item.recType,
					RefUser = _003C_003Ec__DisplayClass73_.item.RefUser,
					Reason = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
					Reason_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))))
				});
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public int CheckPrdGroupMustExistInPreOrderBycmpPrjIdisOk(int pordProjectId)
	{
		int result = 0;
		try
		{
			if (!UserLogin.IsUserAccess("frmPreOrder", "actActivePreOrderHavePrdMustExist"))
			{
				return -1;
			}
			List<WSspCheckPrdGroupMustExistInPreOrderBycmpPrjId_Result> list = Enumerable.ToList<WSspCheckPrdGroupMustExistInPreOrderBycmpPrjId_Result>((IEnumerable<WSspCheckPrdGroupMustExistInPreOrderBycmpPrjId_Result>)_db.WSspCheckPrdGroupMustExistInPreOrderBycmpPrjId(pordProjectId));
			if (Enumerable.Any<WSspCheckPrdGroupMustExistInPreOrderBycmpPrjId_Result>((IEnumerable<WSspCheckPrdGroupMustExistInPreOrderBycmpPrjId_Result>)list) && list.Count > 0)
			{
				result = 1;
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
	public string DeletePreOrderPrdGroupMustExistReasons(int reasonId)
	{
		_003C_003Ec__DisplayClass75_0 _003C_003Ec__DisplayClass75_ = new _003C_003Ec__DisplayClass75_0();
		_003C_003Ec__DisplayClass75_.reasonId = reasonId;
		string text = "";
		try
		{
			if (!UserLogin.IsUserAccess("frmPreOrder", "actDeleteReason"))
			{
				return Messages.NotAccessToPage;
			}
			DbSet<WSPreOrderPrdGroupMustExistReasons> wSPreOrderPrdGroupMustExistReasons = _dbTbl.WSPreOrderPrdGroupMustExistReasons;
			ParameterExpression val = Expression.Parameter(typeof(WSPreOrderPrdGroupMustExistReasons), "m");
			if (Queryable.FirstOrDefault<WSPreOrderPrdGroupMustExistReasons>((IQueryable<WSPreOrderPrdGroupMustExistReasons>)wSPreOrderPrdGroupMustExistReasons, Expression.Lambda<Func<WSPreOrderPrdGroupMustExistReasons, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass75_, typeof(_003C_003Ec__DisplayClass75_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
			{
				try
				{
					if (Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_db.WSspDeletePreOrderPrdGroupMustExistReasons(_003C_003Ec__DisplayClass75_.reasonId)).GetValueOrDefault() > 0)
					{
						return "1";
					}
					return Messages.RedundancyMessage;
				}
				catch (DbEntityValidationException e)
				{
					ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
					return Messages.RedundancyMessage;
				}
				catch (Exception ex)
				{
					ErrorSignal.FromCurrentContext().Raise(ex);
					return Messages.msgErrorCommunicateWithServer + "<br><p style=text-align:left;>" + ex.Message + "</p>";
				}
			}
			return Messages.ErrorNotFound;
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			return Messages.frmErrorMessage + " - " + ex2.Message;
		}
	}

	[AjaxOnly]
	public string GetPreOrderNumber(int pordTypeId, int? cId = null)
	{
		string result = "";
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (cId.GetValueOrDefault() == 0)
			{
				cId = result2;
			}
			result = Enumerable.FirstOrDefault<long>(_db.Database.SqlQuery<long>($"Select dbo.WSfnReturnPreOrderNumber({Financial.Get().Id},{pordTypeId},{cId})", Array.Empty<object>())).ToString();
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
	public int CheckPrdGroupSameInPreOrder(int pordId)
	{
		int result = 0;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (UserLogin.IsUserAccess("frmPreOrder", "actMustPrdGroupSame"))
			{
				List<WSspCheckPrdGroupSameInPreOrder_Result> list = Enumerable.ToList<WSspCheckPrdGroupSameInPreOrder_Result>((IEnumerable<WSspCheckPrdGroupSameInPreOrder_Result>)_dbI.WSspCheckPrdGroupSameInPreOrder(pordId, lCID, result2));
				if (list != null && Enumerable.Any<WSspCheckPrdGroupSameInPreOrder_Result>((IEnumerable<WSspCheckPrdGroupSameInPreOrder_Result>)list))
				{
					result = 1;
				}
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
	public string SetPordExpireDate(int pordCreditDurationId = 0, string pordDate = "", string pordTime = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string result2 = "";
		try
		{
			if (!string.IsNullOrWhiteSpace(pordDate) && pordCreditDurationId != 0)
			{
				DateTime dateTime = DateTime.Now;
				DateTime dateTime2 = default(DateTime);
				string text = "";
				try
				{
					pordTime = ((!string.IsNullOrEmpty(pordTime)) ? pordTime.Trim() : DateTime.Now.ToString("HH:mm:ss"));
					text = PersianDate.GetFormatetdDate(pordDate.Replace("/", ""));
					switch (lCID)
					{
					case 1065:
						dateTime2 = DateTime.Parse(text + " " + pordTime, new PersianCulture());
						pordDate = dateTime2.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime2 = DateTime.Parse(text + " " + pordTime, new CultureInfo("ar-SA"));
						pordDate = dateTime2.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime2 = DateTime.Parse(text + " " + pordTime, new CultureInfo("en-US"));
						pordDate = dateTime2.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
					dateTime = dateTime2;
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					result2 = "-1";
				}
				WSspSelectCreditDuration_Result wSspSelectCreditDuration_Result = Enumerable.FirstOrDefault<WSspSelectCreditDuration_Result>((IEnumerable<WSspSelectCreditDuration_Result>)_db.WSspSelectCreditDuration(lCID, result), (Func<WSspSelectCreditDuration_Result, bool>)((WSspSelectCreditDuration_Result m) => m.CreditDurationID == pordCreditDurationId));
				if (wSspSelectCreditDuration_Result != null && wSspSelectCreditDuration_Result.CreditDurationHours.HasValue)
				{
					int result3 = 0;
					int.TryParse(wSspSelectCreditDuration_Result.CreditDurationHours.ToString(), out result3);
					if (result3 > 0)
					{
						DateTime dateTime3 = dateTime;
						DateTime dateTime4 = dateTime3.AddHours(result3);
						string text2 = dateTime4.ToString("yyyy/MM/dd");
						string text3 = dateTime4.ToString("HH:mm");
						result2 = text2 + "|" + text3;
					}
				}
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			result2 = "-1";
		}
		return result2;
	}

	[LoginAuthorize]
	public ActionResult SelectIssuedOrderFromPord(int pordId, int mode)
	{
		base.ViewBag.PordId = pordId;
		base.ViewBag.Mode = mode;
		GetIssuedOrderFromPord(pordId);
		return View();
	}

	[AjaxOnly]
	public JsonResult GetIssuedOrderFromPord(int pordId)
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
			List<WSspReturnOrderFromPreOrder_Result> list2 = Enumerable.ToList<WSspReturnOrderFromPreOrder_Result>((IEnumerable<WSspReturnOrderFromPreOrder_Result>)_db.WSspReturnOrderFromPreOrder(pordId, lCID, result));
			if (list2 != null && Enumerable.Any<WSspReturnOrderFromPreOrder_Result>((IEnumerable<WSspReturnOrderFromPreOrder_Result>)list2))
			{
				foreach (WSspReturnOrderFromPreOrder_Result item in list2)
				{
					item.ordDate = (item.ordDateTime.HasValue ? item.ordDateTime.Value.ToString("yyyy/MM/dd") : "");
					item.RegisterDatePersian = item.OrderInfo;
					item.OrderInfo = string.Format(Labels.PordIssuedOrderList, item.OrderOpr ?? "", item.ordNumber.ToString(), item.ordDate);
				}
				list = Enumerable.ToList<SelectListItem>(Enumerable.Select<WSspReturnOrderFromPreOrder_Result, SelectListItem>((IEnumerable<WSspReturnOrderFromPreOrder_Result>)list2, (Func<WSspReturnOrderFromPreOrder_Result, SelectListItem>)((WSspReturnOrderFromPreOrder_Result item) => new SelectListItem
				{
					Text = item.OrderInfo,
					Value = item.OrderID.ToString()
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.IssuedOrderListFromPord = list;
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public bool CheckLastCompanyOrderHaveTax(int cmpId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		bool result2 = false;
		try
		{
			bool haveOrd = false;
			result2 = Order.CheckLastCompanyOrderHaveTax(cmpId, ref haveOrd);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result2;
	}

	[AjaxOnly]
	public int CheckPordOrderHaveTax(int pordId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int result2 = 0;
		try
		{
			WSspSelectPreOrderWithId_Result wSspSelectPreOrderWithId_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)_db.WSspSelectPreOrderWithId(pordId, lCID, result));
			if (wSspSelectPreOrderWithId_Result != null)
			{
				List<WSspSelectPreOrderItems_Result> list = Enumerable.ToList<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)_db.WSspSelectPreOrderItems(pordId, lCID, result));
				if (list == null)
				{
					return result2;
				}
				if (!Enumerable.Any<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)list))
				{
					return result2;
				}
				int valueOrDefault = wSspSelectPreOrderWithId_Result.pordCompanyId.GetValueOrDefault();
				bool haveOrd = false;
				bool flag = Order.CheckLastCompanyOrderHaveTax(valueOrDefault, ref haveOrd);
				bool flag2 = PreOrder.CheckCheckPreOrderHaveTax(pordId);
				if (haveOrd && flag != flag2)
				{
					result2 = 1;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result2;
	}

	[AjaxOnly]
	public int CheckPreOrderItemTaxIndex(int pordId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		int result2 = 0;
		try
		{
			List<WSspSelectPreOrderItemTaxIndex_Result> list = Enumerable.ToList<WSspSelectPreOrderItemTaxIndex_Result>((IEnumerable<WSspSelectPreOrderItemTaxIndex_Result>)_dbII.WSspSelectPreOrderItemTaxIndex(pordId));
			if (list != null && Enumerable.Any<WSspSelectPreOrderItemTaxIndex_Result>((IEnumerable<WSspSelectPreOrderItemTaxIndex_Result>)list) && list.Count > 1)
			{
				result2 = 1;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result2;
	}

	[AjaxOnly]
	public double GetCurrencyUnitRate(int currencyUnitId, int currencyUnitIdI)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		double result2 = 0.0;
		try
		{
			WSspSelectCurrencyUnitRateTop1_Result wSspSelectCurrencyUnitRateTop1_Result = Enumerable.FirstOrDefault<WSspSelectCurrencyUnitRateTop1_Result>((IEnumerable<WSspSelectCurrencyUnitRateTop1_Result>)_db.WSspSelectCurrencyUnitRateTop1(currencyUnitId, currencyUnitIdI, lCID, result));
			if (wSspSelectCurrencyUnitRateTop1_Result != null)
			{
				double.TryParse(wSspSelectCurrencyUnitRateTop1_Result.CurrencyRate.ToString(), out result2);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result2;
	}
}

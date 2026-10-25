using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Objects;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using CRM.General.Calendar;
using CRM.General.IO;
using CRM.General.Security;
using CRM.General.Utilities;
using CRM.Models;
using CRM.Models.ReportModel.OrderPrintRpt;
using CRM.Resources;
using CRMIdeal.Areas.OtherSystems.Controllers;
using CRMIdeal.Cache.Setting;
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

namespace CRMIdeal.Areas.Orders.Controllers;

public class HomeController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass15_0
	{
		public int ordItemId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass16_0
	{
		public int ordItemId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass21_0
	{
		public int orderItemId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass25_0
	{
		public HomeController _003C_003E4__this;

		public int currLangID;

		public int defLangID;

		public WSspRpt_PrintOrder_Result ord;

		public Func<WSspRpt_PrintOrder_Result, List<WSspRpt_PrintOrderItems_Result>> _003C_003E9__4;

		public Func<WSspRpt_PrintOrder_Result, List<WSspRpt_PrintOrderPayments_Result>> _003C_003E9__5;

		internal List<WSspRpt_PrintOrderItems_Result> _003CCreatePdfImage_003Eb__4(WSspRpt_PrintOrder_Result itemSpe)
		{
			return Enumerable.ToList<WSspRpt_PrintOrderItems_Result>((IEnumerable<WSspRpt_PrintOrderItems_Result>)_003C_003E4__this._db.WSspRpt_PrintOrderItems(itemSpe.OrderID, currLangID, defLangID));
		}

		internal List<WSspRpt_PrintOrderPayments_Result> _003CCreatePdfImage_003Eb__5(WSspRpt_PrintOrder_Result itemSpe)
		{
			return Enumerable.ToList<WSspRpt_PrintOrderPayments_Result>((IEnumerable<WSspRpt_PrintOrderPayments_Result>)_003C_003E4__this._db.WSspRpt_PrintOrderPayments(itemSpe.OrderID, currLangID, defLangID));
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass48_0
	{
		public int id;

		public int currLangID;

		public WSOrder model;

		public WSOrderLanguageViewModel vm;

		internal bool _003CInsertEdit_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__24(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__25(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__26(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__27(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__28(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__29(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__30(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__31(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__32(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__33(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__34(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__35(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__36(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__37(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__38(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__39(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__40(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__41(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__42(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__43(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__44(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__45(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__46(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__47(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__48(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__49(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__50(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__51(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__52(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__53(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__54(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass49_0
	{
		public CRMspSelectCompanyById_Result cmp;

		public WSOrderLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__32;

		public Func<Languages, bool> _003C_003E9__82;

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

		internal bool _003CInsertEdit_003Eb__32(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__82(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass49_1
	{
		public WSOrder model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass49_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass49_1 CS_0024_003C_003E8__locals1;

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
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass59_0
	{
		public int id;

		public int currLangID;

		internal bool _003CGetOrderDefaultSetting_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetOrderDefaultSetting_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetOrderDefaultSetting_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetOrderDefaultSetting_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetOrderDefaultSetting_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetOrderDefaultSetting_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetOrderDefaultSetting_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetOrderDefaultSetting_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetOrderDefaultSetting_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetOrderDefaultSetting_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetOrderDefaultSetting_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetOrderDefaultSetting_003Eb__24(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetOrderDefaultSetting_003Eb__25(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetOrderDefaultSetting_003Eb__26(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetOrderDefaultSetting_003Eb__27(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetOrderDefaultSetting_003Eb__28(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetOrderDefaultSetting_003Eb__29(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetOrderDefaultSetting_003Eb__30(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetOrderDefaultSetting_003Eb__31(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetOrderDefaultSetting_003Eb__32(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetOrderDefaultSetting_003Eb__33(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetOrderDefaultSetting_003Eb__34(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetOrderDefaultSetting_003Eb__35(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetOrderDefaultSetting_003Eb__36(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetOrderDefaultSetting_003Eb__37(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetOrderDefaultSetting_003Eb__38(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetOrderDefaultSetting_003Eb__39(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetOrderDefaultSetting_003Eb__40(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetOrderDefaultSetting_003Eb__41(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetOrderDefaultSetting_003Eb__42(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetOrderDefaultSetting_003Eb__43(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetOrderDefaultSetting_003Eb__44(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetOrderDefaultSetting_003Eb__45(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass89_0
	{
		public int id;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass94_0
	{
		public int ordId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass95_0
	{
		public WSOrderProfitViewModel model;
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMLinkSpEntities _dbLink = new CRMLinkSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	private readonly CRMSpIIIEntities _dbIII = new CRMSpIIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actordSaleOrder")]
	public ActionResult Index(int? id = null, bool? isOpenNew = null, bool? fromIndicator = null, string parameters = "", int? companyId = null, int? productId = null, int? selWorkflowStepId = null, string intMsgInfo = "", int orderId = 0)
	{
		if (!string.IsNullOrWhiteSpace(intMsgInfo))
		{
			base.ViewBag.IntMsgInfo = intMsgInfo;
		}
		GetWareHouseForBarcode();
		base.ViewBag.Parameters = parameters;
		base.ViewBag.SendedOrderId = 0;
		base.ViewBag.CompanyId = 0;
		base.ViewBag.SelectedWorkflowStepId = selWorkflowStepId;
		base.ViewBag.FromSearchId = false;
		if (id.HasValue)
		{
			base.ViewBag.SendedOrderId = id;
			base.ViewBag.FromSearchId = true;
		}
		if (isOpenNew ?? false)
		{
			base.ViewBag.IsOpenNew = true;
		}
		if (fromIndicator ?? false)
		{
			base.ViewBag.FromIndicator = true;
		}
		if (companyId.HasValue && companyId > 0)
		{
			base.ViewBag.CompanyId = companyId;
		}
		base.ViewBag.ProductID = 0;
		if (productId.HasValue)
		{
			base.ViewBag.ProductID = productId;
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
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
					CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_dbLink.CRMspSelectLinkAccSetting(0, "PreUsedHintSetting", lCID, result, 1, 0, "OrdPreUsedHint"));
					if (cRMspSelectLinkAccSetting_Result != null)
					{
						text = cRMspSelectLinkAccSetting_Result.PreUsedHint ?? "";
					}
				}
				if (!string.IsNullOrWhiteSpace(text))
				{
					flag = true;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PreUsedHintLinkAcc = text;
		base.ViewBag.HavePreUsedHintLinkAcc = flag;
		base.ViewBag.OrderId = orderId;
		return View();
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actordSaleOrder")]
	public JsonResult GetOrder(int orderCurrentId, int companyId, long orderNumber, string fromDate, string toDate, string linkAccOrdNum, int? userId = null, int? orderId = null, bool? fromPaymentIndicator = false)
	{
		//IL_11ee: Unknown result type (might be due to invalid IL or missing references)
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
		CurrentOrderViewModel currentOrderViewModel = new CurrentOrderViewModel();
		currentOrderViewModel.OrderId = 0;
		currentOrderViewModel.OrderInfo = "";
		currentOrderViewModel.OrderUserName = "";
		currentOrderViewModel.FooterData = new WSfnReturnOrderSumFooter_Result();
		currentOrderViewModel.LastVerificationStep = new WSspSelectVerificationWorkFlowStepLast_Result();
		currentOrderViewModel.ordLinkAccOrderNumber = "OrdShowLinkAccOrderNumber".OrderLabels() + ":";
		currentOrderViewModel.ordLinkAccVoucherNumber = Labels.OrdShowLinkAccVoucherNumber + ":";
		currentOrderViewModel.ordLinkAccOrderIdStr = "OrdShowLinkAccOrderIdStr".OrderLabels() + ":";
		currentOrderViewModel.TspOrdIdentify = "OrdShowTspOrdIdentify".OrderLabels() + ":";
		currentOrderViewModel.TspOrdInno = "OrdShowTspOrdInno".OrderLabels() + ":";
		currentOrderViewModel.TspOrdIns = "OrdShowTspOrdIns".OrderLabels() + ":";
		currentOrderViewModel.TspOrdSendDatePersian = "OrdShowTspOrdSendDate".OrderLabels() + ":";
		currentOrderViewModel.TspOrdUID = "OrdShowTspOrdUID".OrderLabels() + ":";
		currentOrderViewModel.TspOrdReferenceNumber = "OrdShowTspOrdReferenceNumber".OrderLabels() + ":";
		currentOrderViewModel.TspOrdStatus = "OrdShowTspOrdStatus".OrderLabels() + ":";
		currentOrderViewModel.ordLinkAccFirstTransferDateStr = Labels.lblLinkAccFirstTransferDate + ":";
		currentOrderViewModel.ordLinkAccLastTransferDateStr = Labels.lblLinkAccLastTransferDate + ":";
		currentOrderViewModel.TspOrdStatusResult = "OrdShowTspOrdStatusResult".OrderLabels() + ":";
		currentOrderViewModel.TspOrdSendTypeTitle = "OrdShowTspOrdSendType".OrderLabels() + ":";
		currentOrderViewModel.ordLinkAccData = "";
		currentOrderViewModel.FooterPay = new WSspReturnSumOrderPay_Result();
		currentOrderViewModel.KaraAfzar_SmsPanelUserName = "";
		currentOrderViewModel.BuyOrderList = new List<WSspReturnBuyOrderFromOrder_Result>();
		currentOrderViewModel.IsSentToLinkAcc = false;
		if (!userId.HasValue)
		{
			userId = UserLogin.CurrentUser.UserId;
		}
		if (!orderId.HasValue)
		{
			orderId = 0;
		}
		if (fromPaymentIndicator.GetValueOrDefault() && orderCurrentId != 0 && orderId == 0)
		{
			orderId = orderCurrentId;
		}
		try
		{
			List<WSspSelectOrdersInMode_Result> list = Enumerable.ToList<WSspSelectOrdersInMode_Result>((IEnumerable<WSspSelectOrdersInMode_Result>)_db.WSspSelectOrdersInMode(fromDate, toDate, userId, orderId, companyId, orderNumber, lCID, result, value, now, linkAccOrdNum, result2));
			if (Enumerable.Any<WSspSelectOrdersInMode_Result>((IEnumerable<WSspSelectOrdersInMode_Result>)list))
			{
				currentOrderViewModel.IsFind = true;
				currentOrderViewModel.Message = "";
				currentOrderViewModel.FromDate = fromDate;
				currentOrderViewModel.ToDate = toDate;
				currentOrderViewModel.OrderNextId = -1;
				currentOrderViewModel.OrderPreviousId = -1;
				currentOrderViewModel.RemainOrdAmount = default(decimal);
				currentOrderViewModel.SumOrdpayAmount = default(decimal);
				currentOrderViewModel.RemainOlderordsAmount = default(decimal);
				currentOrderViewModel.WareHouseCount = 0;
				if (list.Count == 1)
				{
					currentOrderViewModel.OrderFirstId = -1;
					currentOrderViewModel.OrderLastId = -1;
				}
				else
				{
					currentOrderViewModel.OrderFirstId = Enumerable.FirstOrDefault<WSspSelectOrdersInMode_Result>((IEnumerable<WSspSelectOrdersInMode_Result>)list).OrderID;
					currentOrderViewModel.OrderLastId = Enumerable.LastOrDefault<WSspSelectOrdersInMode_Result>((IEnumerable<WSspSelectOrdersInMode_Result>)list).OrderID;
				}
				WSspSelectOrdersInMode_Result wSspSelectOrdersInMode_Result = ((orderCurrentId <= 0) ? Enumerable.LastOrDefault<WSspSelectOrdersInMode_Result>((IEnumerable<WSspSelectOrdersInMode_Result>)list) : list.Find((WSspSelectOrdersInMode_Result c) => c.OrderID == orderCurrentId));
				if (wSspSelectOrdersInMode_Result != null)
				{
					if (Order.IsEditAfterFix(wSspSelectOrdersInMode_Result.ordEditAfterFixInfoJs, wSspSelectOrdersInMode_Result.OrderID, 1))
					{
						wSspSelectOrdersInMode_Result.ordIsFixed = false;
					}
					if (!string.IsNullOrWhiteSpace((wSspSelectOrdersInMode_Result.ordEditAfterFixInfoJs ?? "").Replace("[]", "")))
					{
						List<EditAfterFixInfoViewModel> list2 = JsonConvert.DeserializeObject<List<EditAfterFixInfoViewModel>>(wSspSelectOrdersInMode_Result.ordEditAfterFixInfoJs);
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
							wSspSelectOrdersInMode_Result.ordEditAfterFixInfoJs = JsonConvert.SerializeObject(list2);
						}
					}
					wSspSelectOrdersInMode_Result.ordDateTime = wSspSelectOrdersInMode_Result.ordDateTime;
					wSspSelectOrdersInMode_Result.ordDate = (wSspSelectOrdersInMode_Result.ordDateTime.HasValue ? wSspSelectOrdersInMode_Result.ordDateTime.Value.ToString("yyyy/MM/dd") : null);
					wSspSelectOrdersInMode_Result.ordVerifiedRegisterDatePersian = (wSspSelectOrdersInMode_Result.ordVerifiedRegisterDate.HasValue ? wSspSelectOrdersInMode_Result.ordVerifiedRegisterDate.Value.ToString("yyyyMMdd") : null);
					wSspSelectOrdersInMode_Result.ordDeliveryDate = (wSspSelectOrdersInMode_Result.ordDeliveryDateTime.HasValue ? wSspSelectOrdersInMode_Result.ordDeliveryDateTime.Value.ToString("yyyyMMdd") : null);
					wSspSelectOrdersInMode_Result.ordImportDate = (wSspSelectOrdersInMode_Result.ordImportDateTime.HasValue ? wSspSelectOrdersInMode_Result.ordImportDateTime.Value.ToString("yyyy/MM/dd HH:mm:ss") : null);
					_ = wSspSelectOrdersInMode_Result.RegisterDate;
					wSspSelectOrdersInMode_Result.RegisterDatePersian = wSspSelectOrdersInMode_Result.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
					if (string.IsNullOrEmpty(wSspSelectOrdersInMode_Result.AppType))
					{
						wSspSelectOrdersInMode_Result.AppType = Configuration.AppType;
					}
					wSspSelectOrdersInMode_Result.AppType = Configuration.GetAppType(wSspSelectOrdersInMode_Result.AppType);
					if (!string.IsNullOrEmpty(wSspSelectOrdersInMode_Result.VerifierFName) && wSspSelectOrdersInMode_Result.ordVerifiedRegisterDate.HasValue)
					{
						wSspSelectOrdersInMode_Result.VerifierFName += (wSspSelectOrdersInMode_Result.ordVerifiedRegisterDate.HasValue ? (" (" + wSspSelectOrdersInMode_Result.ordVerifiedRegisterDate.Value.ToString("yyyy/MM/dd HH:mm") + ")") : "");
					}
					wSspSelectOrdersInMode_Result.ordDeadlineDatePersian = (wSspSelectOrdersInMode_Result.ordDeadlineDate.HasValue ? wSspSelectOrdersInMode_Result.ordDeadlineDate.Value.ToString("yyyy/MM/dd") : null);
					wSspSelectOrdersInMode_Result.TspOrdSendDatePersian = (wSspSelectOrdersInMode_Result.TspOrdSendDate.HasValue ? wSspSelectOrdersInMode_Result.TspOrdSendDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : null);
					wSspSelectOrdersInMode_Result.TspOrdLastEditDatePersian = (wSspSelectOrdersInMode_Result.TspOrdLastEditDate.HasValue ? wSspSelectOrdersInMode_Result.TspOrdLastEditDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : null);
					currentOrderViewModel.TspOrdIdentify = "OrdShowTspOrdIdentify".OrderLabels() + ": " + wSspSelectOrdersInMode_Result.TspOrdIdentify;
					currentOrderViewModel.TspOrdInno = "OrdShowTspOrdInno".OrderLabels() + ": " + wSspSelectOrdersInMode_Result.TspOrdInno;
					int result3 = 0;
					int.TryParse(wSspSelectOrdersInMode_Result.TspInty.ToString(), out result3);
					int result4 = 0;
					int.TryParse(wSspSelectOrdersInMode_Result.TspInp.ToString(), out result4);
					int result5 = 0;
					int.TryParse(wSspSelectOrdersInMode_Result.TspOrdIns.ToString(), out result5);
					string text = "";
					switch (result3)
					{
					case 1:
						text = Labels.OrderOprTspIntyI;
						break;
					case 2:
						text = Labels.OrderOprTspIntyII;
						break;
					case 3:
						text = Labels.OrderOprTspIntyIII;
						break;
					}
					switch (result4)
					{
					case 1:
						text = text + " " + Labels.OrderOprTspInpI;
						break;
					case 2:
						text = text + " " + Labels.OrderOprTspInpII;
						break;
					case 3:
						text = text + " " + Labels.OrderOprTspInpIII;
						break;
					case 4:
						text = text + " " + Labels.OrderOprTspInpIV;
						break;
					case 5:
						text = text + " " + Labels.OrderOprTspInpV;
						break;
					case 6:
						text = text + " " + Labels.OrderOprTspInpVI;
						break;
					}
					switch (result5)
					{
					case 1:
						text = text + " (" + Labels.OrderOprTspInsI + ")";
						break;
					case 2:
						text = text + " (" + Labels.OrderOprTspInsII + ")";
						break;
					case 3:
						text = text + " (" + Labels.OrderOprTspInsIII + ")";
						break;
					case 4:
						text = text + " (" + Labels.OrderOprTspInsIV + ")";
						break;
					}
					currentOrderViewModel.TspOrdIns = "OrdShowTspOrdIns".OrderLabels() + ": " + text;
					currentOrderViewModel.TspOrdSendDatePersian = "OrdShowTspOrdSendDate".OrderLabels() + ": " + wSspSelectOrdersInMode_Result.TspOrdSendDatePersian;
					currentOrderViewModel.TspOrdUID = "OrdShowTspOrdUID".OrderLabels() + ": " + wSspSelectOrdersInMode_Result.TspOrdUID;
					currentOrderViewModel.TspOrdReferenceNumber = "OrdShowTspOrdReferenceNumber".OrderLabels() + ": " + wSspSelectOrdersInMode_Result.TspOrdReferenceNumber;
					currentOrderViewModel.TspOrdStatus = "OrdShowTspOrdStatus".OrderLabels() + ": " + wSspSelectOrdersInMode_Result.TspOrdStatus;
					currentOrderViewModel.TspOrdStatusResult = "OrdShowTspOrdStatusResult".OrderLabels() + ": " + wSspSelectOrdersInMode_Result.TspOrdStatusResult;
					string tspOrdSendTypeTitle = Order.GetTspOrdSendTypeTitle(wSspSelectOrdersInMode_Result.TspOrdSendTypeId.GetValueOrDefault());
					currentOrderViewModel.TspOrdSendTypeTitle = "OrdShowTspOrdSendType".OrderLabels() + ": " + tspOrdSendTypeTitle;
					currentOrderViewModel.Order = wSspSelectOrdersInMode_Result;
					currentOrderViewModel.OrderNumber = wSspSelectOrdersInMode_Result.ordNumber;
					currentOrderViewModel.OrderCurrentId = wSspSelectOrdersInMode_Result.OrderID;
					if (list.Count == 1)
					{
						currentOrderViewModel.OrderNextId = -1;
						currentOrderViewModel.OrderPreviousId = -1;
					}
					else
					{
						WSspSelectOrdersInMode_Result next = Lists.GetNext(list, wSspSelectOrdersInMode_Result);
						if (next != null)
						{
							currentOrderViewModel.OrderNextId = next.OrderID;
						}
						WSspSelectOrdersInMode_Result previous = Lists.GetPrevious(list, wSspSelectOrdersInMode_Result);
						if (previous != null)
						{
							currentOrderViewModel.OrderPreviousId = previous.OrderID;
						}
					}
					currentOrderViewModel.OrderItemsList = GetOrderItemsProducts(wSspSelectOrdersInMode_Result.OrderID);
					WSfnReturnOrderSumFooter_Result footerData = Enumerable.FirstOrDefault<WSfnReturnOrderSumFooter_Result>((IEnumerable<WSfnReturnOrderSumFooter_Result>)Enumerable.ToList<WSfnReturnOrderSumFooter_Result>((IEnumerable<WSfnReturnOrderSumFooter_Result>)_db.WSfnReturnOrderSumFooter(wSspSelectOrdersInMode_Result.OrderID)));
					currentOrderViewModel.FooterData = footerData;
					WSspReturnSumOrderPay_Result wSspReturnSumOrderPay_Result = Enumerable.FirstOrDefault<WSspReturnSumOrderPay_Result>((IEnumerable<WSspReturnSumOrderPay_Result>)Enumerable.ToList<WSspReturnSumOrderPay_Result>((IEnumerable<WSspReturnSumOrderPay_Result>)_db.WSspReturnSumOrderPay(wSspSelectOrdersInMode_Result.OrderID)));
					if (wSspReturnSumOrderPay_Result != null)
					{
						currentOrderViewModel.RemainOrdAmount = wSspReturnSumOrderPay_Result.RemainordAmount;
						currentOrderViewModel.SumOrdpayAmount = wSspReturnSumOrderPay_Result.sumordpayAmount;
						currentOrderViewModel.RemainOlderordsAmount = wSspReturnSumOrderPay_Result.RemainOlderordsAmount;
						currentOrderViewModel.FooterPay = wSspReturnSumOrderPay_Result;
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
					if (wSspSelectOrdersInMode_Result.ordLinkAccCodeId.GetValueOrDefault() != 0 || !string.IsNullOrWhiteSpace(wSspSelectOrdersInMode_Result.ordLinkAccCode) || wSspSelectOrdersInMode_Result.ordLinkAccOrderId.GetValueOrDefault() != 0 || !string.IsNullOrWhiteSpace(wSspSelectOrdersInMode_Result.ordLinkAccOrderNumber) || wSspSelectOrdersInMode_Result.ordLinkAccVoucherId.GetValueOrDefault() != 0 || !string.IsNullOrWhiteSpace(wSspSelectOrdersInMode_Result.ordLinkAccVoucherNumber) || !string.IsNullOrWhiteSpace(wSspSelectOrdersInMode_Result.ordLinkAccOrderIdStr) || (!string.IsNullOrWhiteSpace(wSspSelectOrdersInMode_Result.ordLinkAccData) && wSspSelectOrdersInMode_Result.ordLinkAccData != "[]"))
					{
						currentOrderViewModel.IsSentToLinkAcc = true;
					}
					List<WSspReturnDocForSaleOrder_Result> list3 = Enumerable.ToList<WSspReturnDocForSaleOrder_Result>((IEnumerable<WSspReturnDocForSaleOrder_Result>)_db.WSspReturnDocForSaleOrder(wSspSelectOrdersInMode_Result.OrderID, lCID, result));
					currentOrderViewModel.DocList = new List<WSspReturnDocForSaleOrder_Result>();
					currentOrderViewModel.DocList = list3;
					WSspReturnDocForSaleOrder_Result wSspReturnDocForSaleOrder_Result = new WSspReturnDocForSaleOrder_Result();
					if (list3 != null)
					{
						wSspReturnDocForSaleOrder_Result = Enumerable.LastOrDefault<WSspReturnDocForSaleOrder_Result>((IEnumerable<WSspReturnDocForSaleOrder_Result>)list3);
					}
					if (wSspReturnDocForSaleOrder_Result != null)
					{
						currentOrderViewModel.DocInformation = wSspReturnDocForSaleOrder_Result.Info;
						currentOrderViewModel.DocId = wSspReturnDocForSaleOrder_Result.DocID;
						currentOrderViewModel.OprType = wSspReturnDocForSaleOrder_Result.OprType;
					}
					List<int?> list4 = Enumerable.ToList<int?>((IEnumerable<int?>)_db.WSfnReturnOrderItemsWareHouseCnt(wSspSelectOrdersInMode_Result.OrderID));
					if (list4 != null)
					{
						int result6 = 0;
						int.TryParse(list4.Count.ToString(), out result6);
						currentOrderViewModel.WareHouseCount = result6;
					}
					WSspReturnOrderSumPricePartRate_Result wSspReturnOrderSumPricePartRate_Result = Enumerable.FirstOrDefault<WSspReturnOrderSumPricePartRate_Result>((IEnumerable<WSspReturnOrderSumPricePartRate_Result>)_db.WSspReturnOrderSumPricePartRate(wSspSelectOrdersInMode_Result.OrderID));
					if (wSspReturnOrderSumPricePartRate_Result != null)
					{
						currentOrderViewModel.SumPricePartI = wSspReturnOrderSumPricePartRate_Result.SumPricePartI;
						currentOrderViewModel.SumPricePartII = wSspReturnOrderSumPricePartRate_Result.SumPricePartII;
					}
					WSspReturnOrderCommissionBaseAmount_Result wSspReturnOrderCommissionBaseAmount_Result = Enumerable.FirstOrDefault<WSspReturnOrderCommissionBaseAmount_Result>((IEnumerable<WSspReturnOrderCommissionBaseAmount_Result>)_db.WSspReturnOrderCommissionBaseAmount(wSspSelectOrdersInMode_Result.OrderID));
					if (wSspReturnOrderCommissionBaseAmount_Result != null)
					{
						currentOrderViewModel.SumCommAmount = wSspReturnOrderCommissionBaseAmount_Result.CommBaseAmount;
					}
					if (wSspSelectOrdersInMode_Result.ordVerificationWorkFlowId.HasValue)
					{
						currentOrderViewModel.LastVerificationStep = Enumerable.FirstOrDefault<WSspSelectVerificationWorkFlowStepLast_Result>((IEnumerable<WSspSelectVerificationWorkFlowStepLast_Result>)_db.WSspSelectVerificationWorkFlowStepLast(wSspSelectOrdersInMode_Result.OrderID, 20, wSspSelectOrdersInMode_Result.ordVerificationWorkFlowId, 0, lCID, result));
					}
					bool result7 = false;
					WSspSelectCurrencyUnitsWithId_Result wSspSelectCurrencyUnitsWithId_Result = Enumerable.FirstOrDefault<WSspSelectCurrencyUnitsWithId_Result>((IEnumerable<WSspSelectCurrencyUnitsWithId_Result>)_db.WSspSelectCurrencyUnitsWithId(wSspSelectOrdersInMode_Result.ordCurrencyUnitId, lCID, result));
					if (wSspSelectCurrencyUnitsWithId_Result != null)
					{
						bool.TryParse(wSspSelectCurrencyUnitsWithId_Result.IsDecimal.ToString(), out result7);
					}
					currentOrderViewModel.isDecimal = result7;
					currentOrderViewModel.ordLinkAccOrderNumber = "OrdShowLinkAccOrderNumber".OrderLabels() + ": " + wSspSelectOrdersInMode_Result.ordLinkAccOrderNumber;
					currentOrderViewModel.ordLinkAccVoucherNumber = Labels.OrdShowLinkAccVoucherNumber + ": " + wSspSelectOrdersInMode_Result.ordLinkAccVoucherNumber;
					currentOrderViewModel.ordLinkAccOrderIdStr = "OrdShowLinkAccOrderIdStr".OrderLabels() + ": " + ((!string.IsNullOrWhiteSpace(wSspSelectOrdersInMode_Result.ordLinkAccOrderIdStr)) ? wSspSelectOrdersInMode_Result.ordLinkAccOrderIdStr : (wSspSelectOrdersInMode_Result.ordLinkAccOrderId.HasValue ? wSspSelectOrdersInMode_Result.ordLinkAccOrderId.ToString() : ""));
					currentOrderViewModel.ordLinkAccFirstTransferDateStr = Labels.lblLinkAccFirstTransferDate + ":" + (wSspSelectOrdersInMode_Result.ordLinkAccFirstTransferDate.HasValue ? ("<span class='span-transfer-date-to-acc'>" + wSspSelectOrdersInMode_Result.ordLinkAccFirstTransferDate.Value.ToString("yyyy/MM/dd HH:mm:ss") + "</span>") : "");
					currentOrderViewModel.ordLinkAccLastTransferDateStr = Labels.lblLinkAccLastTransferDate + ":" + (wSspSelectOrdersInMode_Result.ordLinkAccLastTransferDate.HasValue ? ("<span class='span-transfer-date-to-acc'>" + wSspSelectOrdersInMode_Result.ordLinkAccLastTransferDate.Value.ToString("yyyy/MM/dd HH:mm:ss") + "</span>") : "");
					currentOrderViewModel.ordLinkAccData = wSspSelectOrdersInMode_Result.ordLinkAccData ?? "";
					if (num == 1 || num == 4)
					{
						List<CRMspSelectLinkAccSettingDBIsActive_Result> linkAccSettingDBList = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDBList(num);
						List<OrdLinkAccDataViewModel> list5 = new List<OrdLinkAccDataViewModel>();
						if (!string.IsNullOrWhiteSpace(currentOrderViewModel.ordLinkAccData))
						{
							foreach (OrdLinkAccDataViewModel item2 in new JavaScriptSerializer().Deserialize<List<OrdLinkAccDataViewModel>>(currentOrderViewModel.ordLinkAccData))
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
										item2.NumberWithLbl = "OrdShowLinkAccOrderNumber".OrderLabels() + ": " + item2.Number;
										item2.IdWithLbl = "OrdShowLinkAccOrderIdStr".OrderLabels() + ": " + item2.Id;
										item2.VoucherNumberWithLbl = Labels.OrdShowLinkAccVoucherNumber + ": " + item2.VoucherNumber;
										item2.VoucherIdWithLbl = item2.VoucherId ?? "";
										item2.FTDateWithLbl = Labels.lblLinkAccFirstTransferDate + ":" + (item2.FTDate.HasValue ? ("<span class='span-transfer-date-to-acc'>" + item2.FTDate.Value.ToString("yyyy/MM/dd HH:mm:ss") + "</span>") : "");
										item2.LTDateWithLbl = Labels.lblLinkAccLastTransferDate + ":" + (item2.LTDate.HasValue ? ("<span class='span-transfer-date-to-acc'>" + item2.LTDate.Value.ToString("yyyy/MM/dd HH:mm:ss") + "</span>") : "");
										list5.Add(item2);
									}
								}
							}
						}
						currentOrderViewModel.ordLinkAccData = "";
						if (list5 != null && Enumerable.Any<OrdLinkAccDataViewModel>((IEnumerable<OrdLinkAccDataViewModel>)list5))
						{
							currentOrderViewModel.ordLinkAccData = JsonConvert.SerializeObject(Enumerable.ToList<OrdLinkAccDataViewModel>((IEnumerable<OrdLinkAccDataViewModel>)list5));
						}
					}
					CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result2 = SysSeting.Get();
					if (cRMspSelectCrmsysSetting_Result2 != null)
					{
						string karaAfzarLockSerial = Configuration.KaraAfzarLockSerial;
						string text2 = cRMspSelectCrmsysSetting_Result2.LockSerial ?? "";
						if (!string.IsNullOrWhiteSpace(text2) && text2 == karaAfzarLockSerial)
						{
							currentOrderViewModel.KaraAfzar_SmsPanelUserName = Order.KaraAfzarGetSmsPanelUserName(wSspSelectOrdersInMode_Result.ordCompanyId);
						}
					}
					currentOrderViewModel.BuyOrderList = Enumerable.ToList<WSspReturnBuyOrderFromOrder_Result>((IEnumerable<WSspReturnBuyOrderFromOrder_Result>)_dbII.WSspReturnBuyOrderFromOrder(wSspSelectOrdersInMode_Result.OrderID, lCID, result));
					if (currentOrderViewModel.BuyOrderList == null)
					{
						currentOrderViewModel.BuyOrderList = new List<WSspReturnBuyOrderFromOrder_Result>();
					}
				}
				else
				{
					currentOrderViewModel.IsFind = false;
					currentOrderViewModel.Message = Messages.ErrorNotFound;
					currentOrderViewModel.FromDate = fromDate;
					currentOrderViewModel.ToDate = toDate;
					currentOrderViewModel.Order = null;
					currentOrderViewModel.OrderCurrentId = -1;
					currentOrderViewModel.OrderNextId = -1;
					currentOrderViewModel.OrderNumber = -1L;
					currentOrderViewModel.OrderPreviousId = -1;
					currentOrderViewModel.CompanyId = -1;
					currentOrderViewModel.OrderFirstId = -1;
					currentOrderViewModel.OrderLastId = -1;
					currentOrderViewModel.RemainOrdAmount = default(decimal);
					currentOrderViewModel.SumOrdpayAmount = default(decimal);
					currentOrderViewModel.RemainOlderordsAmount = default(decimal);
					currentOrderViewModel.WareHouseCount = 0;
				}
			}
			else
			{
				currentOrderViewModel.IsFind = false;
				currentOrderViewModel.Message = Messages.ErrorNotFound;
				currentOrderViewModel.FromDate = fromDate;
				currentOrderViewModel.ToDate = toDate;
				currentOrderViewModel.Order = null;
				currentOrderViewModel.OrderCurrentId = -1;
				currentOrderViewModel.OrderNextId = -1;
				currentOrderViewModel.OrderNumber = -1L;
				currentOrderViewModel.OrderPreviousId = -1;
				currentOrderViewModel.CompanyId = -1;
				currentOrderViewModel.OrderFirstId = -1;
				currentOrderViewModel.OrderLastId = -1;
				currentOrderViewModel.RemainOrdAmount = default(decimal);
				currentOrderViewModel.SumOrdpayAmount = default(decimal);
				currentOrderViewModel.RemainOlderordsAmount = default(decimal);
				currentOrderViewModel.WareHouseCount = 0;
			}
		}
		catch (DbEntityValidationException ex)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
			currentOrderViewModel.Message = Messages.frmErrorMessage + "<br />" + ((Exception)(object)ex).Message;
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			currentOrderViewModel.Message = Messages.frmErrorMessage + "<br />" + ex2.Message;
		}
		JsonResult jsonResult = Json(currentOrderViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<WSspSelectOrderPayments_Result> GetOrderPayment(int id)
	{
		//IL_054f: Unknown result type (might be due to invalid IL or missing references)
		List<WSspSelectOrderPayments_Result> list = new List<WSspSelectOrderPayments_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			list = Enumerable.ToList<WSspSelectOrderPayments_Result>((IEnumerable<WSspSelectOrderPayments_Result>)_db.WSspSelectOrderPayments(id, lCID, result));
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
			foreach (WSspSelectOrderPayments_Result item in list)
			{
				DateTime now = DateTime.Now;
				if (item.ImportDateTime.HasValue)
				{
					item.ImportDate = DateTime.Parse(item.ImportDateTime.ToString()).ToString("yyyy/MM/dd");
				}
				else if (!string.IsNullOrEmpty(item.ImportDate))
				{
					item.ImportDate = PersianDate.GetFormatetdDate(item.ImportDate);
				}
				if (item.ordpayDocDateTime.HasValue)
				{
					item.ordpayDocDate = DateTime.Parse(item.ordpayDocDateTime.ToString()).ToString("yyyy/MM/dd");
				}
				else if (!string.IsNullOrEmpty(item.ordpayDocDate))
				{
					item.ordpayDocDate = PersianDate.GetFormatetdDate(item.ordpayDocDate);
				}
				if (item.ordpayLinkAccHeaderId.HasValue || item.ordpayLinkAccDetailId.HasValue || !string.IsNullOrWhiteSpace(item.ordpayLinkAccHeaderNumber) || !string.IsNullOrWhiteSpace(item.ordpayLinkAccVoucherNumber))
				{
					string text = "";
					if (!string.IsNullOrWhiteSpace(item.ordpayLinkAccHeaderNumber))
					{
						text += string.Format(Labels.OrdPayListAccLinkHeaderNumber, item.ordpayLinkAccHeaderNumber);
					}
					if (!string.IsNullOrWhiteSpace(item.ordpayLinkAccVoucherNumber))
					{
						if (!string.IsNullOrWhiteSpace(text))
						{
							text += ", ";
						}
						text += string.Format(Labels.OrdPayListAccLinkVoucherNumber, item.ordpayLinkAccVoucherNumber);
					}
					if (item.ordpayLinkAccDetailId.HasValue)
					{
						if (!string.IsNullOrWhiteSpace(text))
						{
							text += ", ";
						}
						text += string.Format(Labels.OrdPayListAccLinkDetailId, item.ordpayLinkAccDetailId.ToString());
					}
					if (!string.IsNullOrWhiteSpace(item.ordpayLinkAccPayType) && item.ordpayLinkAccPayType == "pord")
					{
						text = text + " (" + Labels.lblPOrd + ")";
					}
					item.ordpayLinkAccHeaderNumber = text;
				}
				bool result2 = false;
				bool.TryParse(item.ordpayIsVerified.ToString(), out result2);
				if (result2)
				{
					item.ordpayVerifier += (item.ordpayVerifiedRegisterDate.HasValue ? (" (<span class='dt-verify'>" + item.ordpayVerifiedRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") + "</span>)") : "");
					if (!string.IsNullOrWhiteSpace(item.ordpayVerifier))
					{
						item.ordpayVerifier = Labels.lblPayVerified + "(" + item.ordpayVerifier + ")";
					}
				}
				item.ordpayBankDocDatePersian = (item.ordpayBankDocDate.HasValue ? item.ordpayBankDocDate.Value.ToString("yyyy/MM/dd") : "");
				item.ordpayBankDocRegisterDatePersian = (item.ordpayBankDocRegisterDate.HasValue ? item.ordpayBankDocRegisterDate.Value.ToString("yyyy/MM/dd") : "");
				item.ordpayDocDateTemp = (item.ordpayDocDateTimeTemp.HasValue ? item.ordpayDocDateTimeTemp.Value.ToString("yyyy/MM/dd") : "");
				item.ordpayDeActiveDatePersian = (item.ordpayDeActiveDate.HasValue ? item.ordpayDeActiveDate.Value.ToString("yyyy/MM/dd") : "");
				bool result3 = false;
				bool.TryParse(item.ordpayDeActive.ToString(), out result3);
				if (result3)
				{
					item.ordpayDeActiveUser += (item.ordpayDeActiveDate.HasValue ? (" (<span class='dt-deactive'>" + item.ordpayDeActiveDate.Value.ToString("yyyy/MM/dd HH:mm:ss") + "</span>)") : "");
					if (!string.IsNullOrWhiteSpace(item.ordpayDeActiveUser))
					{
						item.ordpayDeActiveUser = Labels.lblPayDeActive + "(" + item.ordpayDeActiveUser + ")";
					}
				}
				if (num != 1)
				{
					continue;
				}
				List<PayLinkAccDataViewModel> list3 = new List<PayLinkAccDataViewModel>();
				if (!string.IsNullOrWhiteSpace(item.ordpayLinkAccData))
				{
					foreach (PayLinkAccDataViewModel item2 in new JavaScriptSerializer().Deserialize<List<PayLinkAccDataViewModel>>(item.ordpayLinkAccData))
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
						string text2 = "";
						if (!string.IsNullOrWhiteSpace(item2.Number) && (item2.Number ?? "0") != "0")
						{
							text2 += string.Format(Labels.OrdPayListAccLinkHeaderNumber, item2.Number);
						}
						if (!string.IsNullOrWhiteSpace(item2.VoucherNumber) && (item2.VoucherNumber ?? "0") != "0")
						{
							if (!string.IsNullOrWhiteSpace(text2))
							{
								text2 += ", ";
							}
							text2 += string.Format(Labels.OrdPayListAccLinkVoucherNumber, item2.VoucherNumber);
						}
						if (!string.IsNullOrWhiteSpace(item2.DetailId) && (item2.DetailId ?? "0") != "0")
						{
							if (!string.IsNullOrWhiteSpace(text2))
							{
								text2 += ", ";
							}
							text2 += string.Format(Labels.OrdPayListAccLinkDetailId, item2.DetailId);
						}
						if (!string.IsNullOrWhiteSpace(item2.RefundNum) && (item2.RefundNum ?? "0") != "0")
						{
							if (!string.IsNullOrWhiteSpace(text2))
							{
								text2 += ", ";
							}
							text2 += string.Format(Labels.OrdPayListAccLinkRefundNum, item2.RefundNum);
						}
						if (!string.IsNullOrWhiteSpace(item2.RefundVoucherNum) && (item2.RefundVoucherNum ?? "0") != "0")
						{
							if (!string.IsNullOrWhiteSpace(text2))
							{
								text2 += ", ";
							}
							text2 += string.Format(Labels.OrdPayListAccLinkRefundVoucherNum, item2.RefundVoucherNum);
						}
						if (!string.IsNullOrWhiteSpace(item2.Type) && item2.Type == "pord")
						{
							text2 = text2 + " (" + Labels.lblPOrd + ")";
						}
						if (!string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(item2.DbTitle))
						{
							text2 = text2 + " (" + item2.DbTitle + ")";
						}
						item2.PayInfoWithLbl = text2;
						list3.Add(item2);
					}
				}
				item.ordpayLinkAccData = "";
				if (list3 != null && Enumerable.Any<PayLinkAccDataViewModel>((IEnumerable<PayLinkAccDataViewModel>)list3))
				{
					item.ordpayLinkAccData = JsonConvert.SerializeObject(Enumerable.ToList<PayLinkAccDataViewModel>((IEnumerable<PayLinkAccDataViewModel>)list3));
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

	public List<WSspSelectOrderItems_Result> GetOrderItemsProducts(int id)
	{
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		List<WSspSelectOrderItems_Result> list = new List<WSspSelectOrderItems_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
			list = Enumerable.ToList<WSspSelectOrderItems_Result>((IEnumerable<WSspSelectOrderItems_Result>)_db.WSspSelectOrderItems(id, currLangID, result));
			if (list != null && Enumerable.Any<WSspSelectOrderItems_Result>((IEnumerable<WSspSelectOrderItems_Result>)list))
			{
				foreach (WSspSelectOrderItems_Result item in list)
				{
					item.ordIValidityExpireDatePersian = (item.ordIValidityExpireDate.HasValue ? item.ordIValidityExpireDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
					item.ordIDeliveryDatePersian = (item.ordIDeliveryDate.HasValue ? item.ordIDeliveryDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
					item.ordIDeliveryEndDatePersian = (item.ordIDeliveryEndDate.HasValue ? item.ordIDeliveryEndDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
					List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrWhiteSpace(item.ordIDescriptionI_Lang))
					{
						list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(item.ordIDescriptionI_Lang);
					}
					list2.Add(new CommonMultiLanguageViewModel
					{
						Value = item.ordIDescriptionI,
						LanguageId = currLangID
					});
					if (list2 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2))
					{
						item.ordIDescriptionI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
						item.ordIDescriptionI_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
					}
					item.PrdRowColor = Public.TColorToHex(item.PrdRowColor);
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
	public ActionResult _PartialFiles()
	{
		return PartialView();
	}

	public ActionResult PrePaid_Read([DataSourceRequest] DataSourceRequest request, int orderId)
	{
		List<WSspSelectOrderPayments_Result> list = new List<WSspSelectOrderPayments_Result>();
		try
		{
			list = GetOrderPayment(orderId);
			foreach (WSspSelectOrderPayments_Result item in list)
			{
				item.ImportDate = (item.ImportDateTime.HasValue ? item.ImportDateTime.Value.ToString("yyyyMMdd") : item.ImportDate);
				item.ordpayDocDate = (item.ordpayDocDateTime.HasValue ? item.ordpayDocDateTime.Value.ToString("yyyyMMdd") : item.ordpayDocDate);
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

	public ActionResult OrderFiles_Read([DataSourceRequest] DataSourceRequest request, int orderId, int companyId, int projectId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectFilesDirectory_Result> list = Files.SelectFilesDirectory(companyId.ToString(), "0", projectId.ToString(), "20", orderId.ToString(), "0", "0", false);
		List<CrmFilesDirectoryViewModel> list2 = new List<CrmFilesDirectoryViewModel>();
		if (list != null && Enumerable.Any<CRMspSelectFilesDirectory_Result>((IEnumerable<CRMspSelectFilesDirectory_Result>)list))
		{
			foreach (CRMspSelectFilesDirectory_Result item in list)
			{
				CrmFilesDirectoryViewModel crmFilesDirectoryViewModel = new CrmFilesDirectoryViewModel();
				crmFilesDirectoryViewModel.FileDirectoryID = item.FileDirectoryID;
				crmFilesDirectoryViewModel.FileDirectoryTypeId = item.FileDirectoryTypeId;
				crmFilesDirectoryViewModel.FileDirectoryTypeIdTitle = item.FileDirectoryType ?? "";
				crmFilesDirectoryViewModel.DocTime = item.DocTime;
				crmFilesDirectoryViewModel.Title = item.Title;
				crmFilesDirectoryViewModel.ProjectIdTitle = item.prjTitle;
				crmFilesDirectoryViewModel.FileName = item.FileName;
				crmFilesDirectoryViewModel.PaymentType = item.PaymentType;
				if (!string.IsNullOrEmpty(item.DocDay))
				{
					crmFilesDirectoryViewModel.DocDay = DateTimeClass.ConvertNumToDayeOfWeek(int.Parse(item.DocDay));
				}
				DateTime now = DateTime.Now;
				if (item.DocDateTime.HasValue)
				{
					crmFilesDirectoryViewModel.DocDate = DateTime.Parse(item.DocDateTime.ToString()).ToString("yyyy/MM/dd");
				}
				else if (!string.IsNullOrEmpty(item.DocDate))
				{
					crmFilesDirectoryViewModel.DocDate = PersianDate.GetFormatetdDate(item.DocDate);
				}
				crmFilesDirectoryViewModel.FileDirectoryNumRef = item.FileDirectoryNumRef;
				list2.Add(crmFilesDirectoryViewModel);
			}
		}
		JsonResult jsonResult = Json(((IEnumerable)list2).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmOrder", ActionName = "actCopypreoItem")]
	public string CopyOrdItem(int ordId)
	{
		string text = "";
		try
		{
			if (ordId > 0)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				_ = Thread.CurrentThread.CurrentCulture.LCID;
				string firstRegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
				return (_db.WSspTmpUserItemCopy("Order", ordId, UserLogin.CurrentUser.UserId, Configuration.AppType, result, firstRegisterDatePersian) > 0) ? "1" : Messages.msgErrorRunFunction;
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
	[DynamicAuthorize(ControllerName = "frmOrder", ActionName = "actPastpreoItem")]
	public string PasteOrdItem(int ordId)
	{
		string result = "";
		try
		{
			if (ordId > 0)
			{
				if (Order.IsFixed(ordId))
				{
					return "msgErrorNotActiveOrd".OrderMessages();
				}
				if (Order.IsSentToLinkAccByAction(ordId))
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
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.WSspTmpUserItemPast("Order", ordId, UserLogin.CurrentUser.UserId, id, value, registerDatePersian, Configuration.AppType, result2, centerId));
				if (mct_Result != null && mct_Result.Result > 0)
				{
					result = (Order.CalcAndSetOrderAmounts(ordId) ? "1" : Messages.msgErrorInCalculation);
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

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmOrder", ActionName = "actRemoveProduct")]
	public string RemoveProduct(int ordItemId, int ordId)
	{
		_003C_003Ec__DisplayClass15_0 _003C_003Ec__DisplayClass15_ = new _003C_003Ec__DisplayClass15_0();
		_003C_003Ec__DisplayClass15_.ordItemId = ordItemId;
		string result = "";
		try
		{
			if (Order.IsFixed(ordId))
			{
				return "msgErrorNotActiveOrd".OrderMessages();
			}
			if (Order.IsSentToLinkAccByAction(ordId))
			{
				string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
				return string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
			}
			if (_003C_003Ec__DisplayClass15_.ordItemId > 0)
			{
				DbSet<WSOrderItems> wSOrderItems = _dbTbl.WSOrderItems;
				ParameterExpression val = Expression.Parameter(typeof(WSOrderItems), "c");
				if (Queryable.FirstOrDefault<WSOrderItems>((IQueryable<WSOrderItems>)wSOrderItems, Expression.Lambda<Func<WSOrderItems, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass15_, typeof(_003C_003Ec__DisplayClass15_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
				{
					try
					{
						mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)Enumerable.ToList<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteWSOrderItems(_003C_003Ec__DisplayClass15_.ordItemId)));
						if (mct_Result != null && mct_Result.Result > 0)
						{
							result = (Order.CalcAndSetOrderAmounts(ordId) ? "1" : Messages.msgErrorInCalculation);
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
	[DynamicAuthorize(ControllerName = "frmOrder", ActionName = "actRemoveProductAll")]
	public string RemoveProductAll(int ordItemId)
	{
		_003C_003Ec__DisplayClass16_0 _003C_003Ec__DisplayClass16_ = new _003C_003Ec__DisplayClass16_0();
		_003C_003Ec__DisplayClass16_.ordItemId = ordItemId;
		string result = "";
		try
		{
			if (_003C_003Ec__DisplayClass16_.ordItemId > 0)
			{
				DbSet<WSOrderItems> wSOrderItems = _dbTbl.WSOrderItems;
				ParameterExpression val = Expression.Parameter(typeof(WSOrderItems), "c");
				WSOrderItems wSOrderItems2 = Queryable.FirstOrDefault<WSOrderItems>((IQueryable<WSOrderItems>)wSOrderItems, Expression.Lambda<Func<WSOrderItems, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass16_, typeof(_003C_003Ec__DisplayClass16_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (wSOrderItems2 != null)
				{
					try
					{
						if (Order.IsFixed(wSOrderItems2.OrderId))
						{
							return "msgErrorNotActiveOrd".OrderMessages();
						}
						if (Order.IsSentToLinkAccByAction(wSOrderItems2.OrderId))
						{
							string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
							return string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
						}
						mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.WSspDeleteOrderItemsAll(wSOrderItems2.OrderId));
						if (mct_I_Result != null && mct_I_Result.Result > 0)
						{
							result = (Order.CalcAndSetOrderAmounts(wSOrderItems2.OrderId) ? "1" : Messages.msgErrorInCalculation);
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

	public ActionResult OrdItemSerials_Read([DataSourceRequest] DataSourceRequest request, int orderItemId)
	{
		List<WSspSelectOrderItemSerialsByOrderItemId_Result> orderItemSerials = GetOrderItemSerials(orderItemId);
		JsonResult jsonResult = Json(((IEnumerable)orderItemSerials).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<WSspSelectOrderItemSerialsByOrderItemId_Result> GetOrderItemSerials(int orderItemId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectOrderItemSerialsByOrderItemId_Result> list = new List<WSspSelectOrderItemSerialsByOrderItemId_Result>();
		try
		{
			list = Enumerable.ToList<WSspSelectOrderItemSerialsByOrderItemId_Result>((IEnumerable<WSspSelectOrderItemSerialsByOrderItemId_Result>)_db.WSspSelectOrderItemSerialsByOrderItemId(orderItemId, lCID, result));
			foreach (WSspSelectOrderItemSerialsByOrderItemId_Result item in list)
			{
				item.DocDate = (item.DocDateTime.HasValue ? item.DocDateTime.Value.ToString("yyyyMMdd") : item.DocDate);
				item.AppType = (item.ExpDate.HasValue ? item.ExpDate.Value.ToString("yyyyMMdd", new CultureInfo("en-US")) : "");
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
	[DynamicAuthorize(ControllerName = "frmOrder", ActionName = "actDeleteAllSerials")]
	public string RemoveAllItemSerials(int ordItemId, int ordId)
	{
		string result = Messages.frmErrorMessage;
		try
		{
			if (Order.IsFixed(ordId))
			{
				return "msgErrorNotActiveOrd".OrderMessages();
			}
			if (ordItemId > 0)
			{
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)Enumerable.ToList<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteOrderItemSerialsByOrderItemId(ordItemId)));
				if (mct_Result != null && mct_Result.Result > 0)
				{
					result = "1";
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
			result = Messages.frmErrorMessage;
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = Messages.msgErrorCommunicateWithServer + "<br><p style=text-align:left;>" + ex.Message + "</p>";
		}
		return result;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmOrder", ActionName = "actDeleteItemSerial")]
	public string RemoveItemSerials(int orderItemSerialId, int ordId)
	{
		string result = "";
		try
		{
			if (Order.IsFixed(ordId))
			{
				return "msgErrorNotActiveOrd".OrderMessages();
			}
			if (orderItemSerialId > 0)
			{
				if (_dbTbl.WSOrderItemSerials.Find(orderItemSerialId) != null)
				{
					try
					{
						mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)Enumerable.ToList<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteWSOrderItemSerials(orderItemSerialId)));
						if (mct_Result != null && mct_Result.Result > 0)
						{
							result = "1";
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
	[DynamicAuthorize(ControllerName = "frmOrder", ActionName = "actInsertAutoItemSerial")]
	public string InsertAutoOrderItemSerial(int orderItemId, int ordId)
	{
		_003C_003Ec__DisplayClass21_0 _003C_003Ec__DisplayClass21_ = new _003C_003Ec__DisplayClass21_0();
		_003C_003Ec__DisplayClass21_.orderItemId = orderItemId;
		string result = "1";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (Order.IsFixed(ordId) && !UserLogin.IsUserAccess("frmOrder", "actCanUseAutoInsertSerialAfterVerified"))
			{
				return "msgErrorNotActiveOrd".OrderMessages();
			}
			DbSet<WSOrderItems> wSOrderItems = _dbTbl.WSOrderItems;
			ParameterExpression val = Expression.Parameter(typeof(WSOrderItems), "c");
			WSOrderItems wSOrderItems2 = Queryable.FirstOrDefault<WSOrderItems>((IQueryable<WSOrderItems>)wSOrderItems, Expression.Lambda<Func<WSOrderItems, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass21_, typeof(_003C_003Ec__DisplayClass21_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			_db.WSspInsertAutoOrderItemSerial(_003C_003Ec__DisplayClass21_.orderItemId, UserLogin.CurrentUser.UserId, int.Parse(DateTime.Now.ToString("MM", new PersianCulture())), Financial.Get().Id, DateTime.Now.ToString("yyyyMMdd", new PersianCulture()), wSOrderItems2.ordIWHId, Configuration.AppType, result2);
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

	[AjaxOnly]
	public string VerifyOrder(int id)
	{
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		return Order.VerifyOrderComplete(id, "frmOrder", UserLogin.IsUserAccess("frmOrder", "actVerifyOrder", currentUser), actVerifyOrder_Passed: false, UserLogin.IsUserAccess("frmOrder", "actAutoReferOrderToWrhsUserAfterVerify", currentUser), UserLogin.IsUserAccess("frmOrder", "actIssueDraftAuto", currentUser), "actIssueDraftAuto", UserLogin.IsUserAccess("frmOrder", "actGetOrdFOLink", currentUser));
	}

	[AjaxOnly]
	public string DeactiveOrder(int id)
	{
		string result = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmOrder", "actExitFromIsFix", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			_db.WSspOrderVerifyExit(id, currentUser.UserId, DateTime.Now.ToString("yyyyMMdd", new PersianCulture()));
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			int userId = UserLogin.CurrentUser.UserId;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.ScorespDeleteOrderScores(id, userId, value2, value, now, registerDatePersian, appType, result2, centerId));
			if (mct_I_Result != null && mct_I_Result.Result == 0)
			{
				result = Messages.msgErrorRunFunction;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.frmErrorMessage;
		}
		return result;
	}

	[AjaxOnly]
	[LoginAuthorize]
	public string SendOrderEmail(int id, string emails, string cmpRemainAccLink = "", string cmpRemainAccLinkjs = "")
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
			WSOrder wSOrder = _dbTbl.WSOrder.Find(id);
			if (wSOrder != null)
			{
				string[] array = CreatePdfImage(id, cmpRemainAccLink, cmpRemainAccLinkjs);
				string filePath = array[0];
				string filePathII = array[1];
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short.Parse(now.ToString("MM", new PersianCulture()));
				short.Parse(Financial.Get().Id.ToString());
				_dbII.EmailspInsertEmailUserTempTankByCompanyWeb(UserLogin.CurrentUser.UserId, 30, wSOrder.OrderID, wSOrder.ordCompanyId, wSOrder.ordProjectId, filePath, filePathII, "", "", "", value, registerDatePersian, appType, lCID, result2);
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

	private string[] CreatePdfImage(int orderId, string cmpRemainAccLink = "", string cmpRemainAccLinkjs = "")
	{
		//IL_1b88: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b92: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bb0: Expected I4, but got Unknown
		//IL_1bb0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bb4: Invalid comparison between Unknown and I4
		//IL_02e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cd6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1726: Unknown result type (might be due to invalid IL or missing references)
		//IL_1879: Unknown result type (might be due to invalid IL or missing references)
		//IL_1897: Unknown result type (might be due to invalid IL or missing references)
		//IL_189e: Expected O, but got Unknown
		//IL_18c9: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass25_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass25_0();
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
			parameters.NotUsed_ListLinkAccData = new List<OrdLinkAccDataViewModel>();
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
			int num = 0;
			decimal result3 = default(decimal);
			if (result2 > 0)
			{
				CompanyController companyController = new CompanyController();
				string text4 = "";
				switch (result2)
				{
				case 1:
				{
					decimal num2 = default(decimal);
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
							num2 = default(decimal);
							decimal linkAccDebitBalance = default(decimal);
							decimal linkAccCreditBalance = default(decimal);
							companyController.SepGetCmpAccountingDetail(num, ref num2, ref linkAccDebitBalance, ref linkAccCreditBalance, result4);
							text4 = $"{num2:N2}";
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
			parameters.ActNotShowFinancialInfo = UserLogin.IsUserAccess("frmOrder", "actNotShowFinancialInfo", UserLogin.CurrentUser);
			List<WSspRpt_PrintOrder_Result> list2 = Enumerable.ToList<WSspRpt_PrintOrder_Result>((IEnumerable<WSspRpt_PrintOrder_Result>)_db.WSspRpt_PrintOrder(orderId, CS_0024_003C_003E8__locals0.currLangID, CS_0024_003C_003E8__locals0.defLangID, userId, rptDate, rptDay, parameters.CmpLinkAccAllPayRemain));
			foreach (WSspRpt_PrintOrder_Result item2 in list2)
			{
				if (CS_0024_003C_003E8__locals0.currLangID != 1065)
				{
					if (!string.IsNullOrEmpty(item2.ordDate))
					{
						item2.ordDate = PersianDate.GetShamsi2Miladi(item2.ordDate.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item2.prsBirthDate))
					{
						item2.prsBirthDate = PersianDate.GetShamsi2Miladi(item2.prsBirthDate.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item2.ordDeliveryDate))
					{
						item2.ordDeliveryDate = PersianDate.GetShamsi2Miladi(item2.ordDeliveryDate.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item2.RegisterDatePersian))
					{
						item2.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item2.RegisterDatePersian.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item2.OIRegisterDatePersian))
					{
						item2.OIRegisterDatePersian = PersianDate.GetShamsi2Miladi(item2.OIRegisterDatePersian.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item2.LastOrdDate))
					{
						item2.LastOrdDate = PersianDate.GetShamsi2Miladi(item2.LastOrdDate.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item2.ordIDeliveryDatePersian))
					{
						item2.ordIDeliveryDatePersian = PersianDate.GetShamsi2Miladi(item2.ordIDeliveryDatePersian.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item2.ordDeadlineDatePersian))
					{
						item2.ordDeadlineDatePersian = PersianDate.GetShamsi2Miladi(item2.ordDeadlineDatePersian.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item2.ordDeliveryEndDate))
					{
						item2.ordDeliveryEndDate = PersianDate.GetShamsi2Miladi(item2.ordDeliveryEndDate.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item2.ordIValidityExpireDatePersian))
					{
						item2.ordIValidityExpireDatePersian = PersianDate.GetShamsi2Miladi(item2.ordIValidityExpireDatePersian.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item2.ordIDiscountCodeRegisterDatePersian))
					{
						item2.ordIDiscountCodeRegisterDatePersian = PersianDate.GetShamsi2Miladi(item2.ordIDiscountCodeRegisterDatePersian.Replace("/", "")).Replace("/", "");
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
			WSspRpt_PrintOrder_Result wSspRpt_PrintOrder_Result = Enumerable.FirstOrDefault<WSspRpt_PrintOrder_Result>((IEnumerable<WSspRpt_PrintOrder_Result>)list2);
			if (wSspRpt_PrintOrder_Result == null)
			{
				wSspRpt_PrintOrder_Result = new WSspRpt_PrintOrder_Result();
			}
			parameters.NotUsed_ListPrintOrder = list2;
			List<WSspRpt_PrintOrderItemSerials_Result> list3 = new List<WSspRpt_PrintOrderItemSerials_Result>();
			foreach (WSspRpt_PrintOrder_Result item3 in parameters.NotUsed_ListPrintOrder)
			{
				List<WSspRpt_PrintOrderItemSerials_Result> collection = Enumerable.ToList<WSspRpt_PrintOrderItemSerials_Result>((IEnumerable<WSspRpt_PrintOrderItemSerials_Result>)_db.WSspRpt_PrintOrderItemSerials(item3.OrderItemID, CS_0024_003C_003E8__locals0.currLangID, CS_0024_003C_003E8__locals0.defLangID));
				list3.AddRange(collection);
			}
			foreach (WSspRpt_PrintOrderItemSerials_Result item4 in list3)
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
			parameters.NotUsed_ListPrintOrderItemSerials = list3;
			List<WSspRpt_PrintOrderItems_Result> list4 = new List<WSspRpt_PrintOrderItems_Result>();
			foreach (List<WSspRpt_PrintOrderItems_Result> item5 in Enumerable.Select<WSspRpt_PrintOrder_Result, List<WSspRpt_PrintOrderItems_Result>>((IEnumerable<WSspRpt_PrintOrder_Result>)parameters.NotUsed_ListPrintOrder, (Func<WSspRpt_PrintOrder_Result, List<WSspRpt_PrintOrderItems_Result>>)((WSspRpt_PrintOrder_Result itemSpe) => Enumerable.ToList<WSspRpt_PrintOrderItems_Result>((IEnumerable<WSspRpt_PrintOrderItems_Result>)CS_0024_003C_003E8__locals0._003C_003E4__this._db.WSspRpt_PrintOrderItems(itemSpe.OrderID, CS_0024_003C_003E8__locals0.currLangID, CS_0024_003C_003E8__locals0.defLangID)))))
			{
				list4.AddRange(item5);
			}
			foreach (WSspRpt_PrintOrderItems_Result item6 in list4)
			{
				if (CS_0024_003C_003E8__locals0.currLangID != 1065)
				{
					if (!string.IsNullOrEmpty(item6.OIRegisterDatePersian))
					{
						item6.OIRegisterDatePersian = PersianDate.GetShamsi2Miladi(item6.OIRegisterDatePersian.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item6.ordIDeliveryDatePersian))
					{
						item6.ordIDeliveryDatePersian = PersianDate.GetShamsi2Miladi(item6.ordIDeliveryDatePersian.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item6.ordIValidityExpireDatePersian))
					{
						item6.ordIValidityExpireDatePersian = PersianDate.GetShamsi2Miladi(item6.ordIValidityExpireDatePersian.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item6.ordIDiscountCodeRegisterDatePersian))
					{
						item6.ordIDiscountCodeRegisterDatePersian = PersianDate.GetShamsi2Miladi(item6.ordIDiscountCodeRegisterDatePersian.Replace("/", "")).Replace("/", "");
					}
				}
			}
			parameters.NotUsed_ListPrintOrderItems = list4;
			List<WSspRpt_PrintOrderPayments_Result> list5 = new List<WSspRpt_PrintOrderPayments_Result>();
			foreach (List<WSspRpt_PrintOrderPayments_Result> item7 in Enumerable.Select<WSspRpt_PrintOrder_Result, List<WSspRpt_PrintOrderPayments_Result>>((IEnumerable<WSspRpt_PrintOrder_Result>)parameters.NotUsed_ListPrintOrder, (Func<WSspRpt_PrintOrder_Result, List<WSspRpt_PrintOrderPayments_Result>>)((WSspRpt_PrintOrder_Result itemSpe) => Enumerable.ToList<WSspRpt_PrintOrderPayments_Result>((IEnumerable<WSspRpt_PrintOrderPayments_Result>)CS_0024_003C_003E8__locals0._003C_003E4__this._db.WSspRpt_PrintOrderPayments(itemSpe.OrderID, CS_0024_003C_003E8__locals0.currLangID, CS_0024_003C_003E8__locals0.defLangID)))))
			{
				list5.AddRange(item7);
			}
			foreach (WSspRpt_PrintOrderPayments_Result item8 in list5)
			{
				if (CS_0024_003C_003E8__locals0.currLangID != 1065)
				{
					if (!string.IsNullOrEmpty(item8.RegisterDatePersian))
					{
						item8.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item8.RegisterDatePersian.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item8.ImportDate))
					{
						item8.ImportDate = PersianDate.GetShamsi2Miladi(item8.ImportDate.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item8.ordpayDocDate))
					{
						item8.ordpayDocDate = PersianDate.GetShamsi2Miladi(item8.ordpayDocDate.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item8.ordpayFirstRegisteDatePersian))
					{
						item8.ordpayFirstRegisteDatePersian = PersianDate.GetShamsi2Miladi(item8.ordpayFirstRegisteDatePersian.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item8.FirstRegisterDatePersian))
					{
						item8.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(item8.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrWhiteSpace(item8.ordpayVerifiedRegisterDatePersian))
					{
						item8.ordpayVerifiedRegisterDatePersian = PersianDate.GetShamsi2Miladi(item8.ordpayVerifiedRegisterDatePersian.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrWhiteSpace(item8.ordpayBankDocDatePersian))
					{
						item8.ordpayBankDocDatePersian = PersianDate.GetShamsi2Miladi(item8.ordpayBankDocDatePersian.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrWhiteSpace(item8.ordpayBankDocRegisterDatePersian))
					{
						item8.ordpayBankDocRegisterDatePersian = PersianDate.GetShamsi2Miladi(item8.ordpayBankDocRegisterDatePersian.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrWhiteSpace(item8.ordpayDocDateTemp))
					{
						item8.ordpayDocDateTemp = PersianDate.GetShamsi2Miladi(item8.ordpayDocDateTemp.Replace("/", "")).Replace("/", "");
					}
				}
				if (string.IsNullOrWhiteSpace(item8.ordpayLinkAccData))
				{
					continue;
				}
				List<PayLinkAccDataViewModel> list6 = new JavaScriptSerializer().Deserialize<List<PayLinkAccDataViewModel>>(item8.ordpayLinkAccData);
				if (list6 == null || !Enumerable.Any<PayLinkAccDataViewModel>((IEnumerable<PayLinkAccDataViewModel>)list6))
				{
					continue;
				}
				foreach (PayLinkAccDataViewModel vmLkAcc2 in list6)
				{
					vmLkAcc2.PayId = item8.OrderPaymentId;
					CRMspSelectLinkAccSettingDBIsActive_Result cRMspSelectLinkAccSettingDBIsActive_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)list, (Func<CRMspSelectLinkAccSettingDBIsActive_Result, bool>)((CRMspSelectLinkAccSettingDBIsActive_Result m) => m.LinkAccSettingDBId == vmLkAcc2.DBId.GetValueOrDefault()));
					if (cRMspSelectLinkAccSettingDBIsActive_Result != null)
					{
						vmLkAcc2.DbName = cRMspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbName ?? "";
						vmLkAcc2.DbTitle = cRMspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbTitle ?? "";
					}
				}
				parameters.NotUsed_ListPayLinkAccData.AddRange(list6);
			}
			parameters.NotUsed_ListPrintOrderPayments = list5;
			parameters.ListDyPrintCmpForm = new List<CRMspDyPrintCmpForm_Result>();
			parameters.ListDyPrintPrsForm = new List<CRMspDyPrintPrsForm_Result>();
			parameters.ListDyPrintPrjForm = new List<CRMspDyPrintPrjForm_Result>();
			parameters.ListDyPrintPordForm = new List<CRMspDyPrintPordForm_Result>();
			parameters.ListDyPrintOrdForm = new List<CRMspDyPrintOrdForm_Result>();
			parameters.ListPrintProjectInformationTree = new List<CRMspPrintProjectInformationTree_Result>();
			if (wSspRpt_PrintOrder_Result != null)
			{
				_ = wSspRpt_PrintOrder_Result.ordCompanyId;
				parameters.ListDyPrintCmpForm = Enumerable.ToList<CRMspDyPrintCmpForm_Result>((IEnumerable<CRMspDyPrintCmpForm_Result>)_db.CRMspDyPrintCmpForm(wSspRpt_PrintOrder_Result.ordCompanyId, CS_0024_003C_003E8__locals0.currLangID, CS_0024_003C_003E8__locals0.defLangID, userId, result));
				if (wSspRpt_PrintOrder_Result.ordCompanyPersonId.HasValue)
				{
					parameters.ListDyPrintPrsForm = Enumerable.ToList<CRMspDyPrintPrsForm_Result>((IEnumerable<CRMspDyPrintPrsForm_Result>)_db.CRMspDyPrintPrsForm(wSspRpt_PrintOrder_Result.ordCompanyPersonId, CS_0024_003C_003E8__locals0.currLangID, CS_0024_003C_003E8__locals0.defLangID, userId, result));
				}
				if (wSspRpt_PrintOrder_Result.ordProjectId.HasValue)
				{
					parameters.ListDyPrintPrjForm = Enumerable.ToList<CRMspDyPrintPrjForm_Result>((IEnumerable<CRMspDyPrintPrjForm_Result>)_db.CRMspDyPrintPrjForm(wSspRpt_PrintOrder_Result.ordProjectId, CS_0024_003C_003E8__locals0.currLangID, CS_0024_003C_003E8__locals0.defLangID, userId, result));
					parameters.ListPrintProjectInformationTree = Enumerable.ToList<CRMspPrintProjectInformationTree_Result>((IEnumerable<CRMspPrintProjectInformationTree_Result>)_db.CRMspPrintProjectInformationTree(wSspRpt_PrintOrder_Result.ordProjectId, CS_0024_003C_003E8__locals0.currLangID, CS_0024_003C_003E8__locals0.defLangID));
				}
				if (wSspRpt_PrintOrder_Result.PreOrderId.HasValue)
				{
					parameters.ListDyPrintPordForm = Enumerable.ToList<CRMspDyPrintPordForm_Result>((IEnumerable<CRMspDyPrintPordForm_Result>)_db.CRMspDyPrintPordForm(wSspRpt_PrintOrder_Result.PreOrderId, CS_0024_003C_003E8__locals0.currLangID, CS_0024_003C_003E8__locals0.defLangID, userId, result));
				}
				parameters.ListDyPrintOrdForm = Enumerable.ToList<CRMspDyPrintOrdForm_Result>((IEnumerable<CRMspDyPrintOrdForm_Result>)_db.CRMspDyPrintOrdForm(wSspRpt_PrintOrder_Result.OrderID, CS_0024_003C_003E8__locals0.currLangID, CS_0024_003C_003E8__locals0.defLangID, userId, result));
			}
			parameters.Signature = "";
			DbSet<UserSignature> userSignature = _dbTbl.UserSignature;
			ParameterExpression val = Expression.Parameter(typeof(UserSignature), "c");
			UserSignature userSignature2 = Queryable.FirstOrDefault<UserSignature>((IQueryable<UserSignature>)userSignature, Expression.Lambda<Func<UserSignature, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Property((Expression)null, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (userSignature2 != null && userSignature2.Signature != null && userSignature2.Signature.Length != 0)
			{
				parameters.Signature = Convert.ToBase64String(userSignature2.Signature);
			}
			parameters.SignatureReferUser = null;
			parameters.SignatureLastEditUser = null;
			parameters.SignatureVerifierUser = null;
			CS_0024_003C_003E8__locals0.ord = Enumerable.FirstOrDefault<WSspRpt_PrintOrder_Result>((IEnumerable<WSspRpt_PrintOrder_Result>)list2);
			if (CS_0024_003C_003E8__locals0.ord != null)
			{
				DbSet<UserSignature> userSignature3 = _dbTbl.UserSignature;
				val = Expression.Parameter(typeof(UserSignature), "c");
				userSignature2 = Queryable.FirstOrDefault<UserSignature>((IQueryable<UserSignature>)userSignature3, Expression.Lambda<Func<UserSignature, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Convert((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), typeof(int?)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass25_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (userSignature2 != null && userSignature2.Signature != null && userSignature2.Signature.Length != 0)
				{
					parameters.SignatureReferUser = userSignature2.Signature;
				}
				DbSet<UserSignature> userSignature4 = _dbTbl.UserSignature;
				val = Expression.Parameter(typeof(UserSignature), "c");
				userSignature2 = Queryable.FirstOrDefault<UserSignature>((IQueryable<UserSignature>)userSignature4, Expression.Lambda<Func<UserSignature, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass25_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (userSignature2 != null && userSignature2.Signature != null && userSignature2.Signature.Length != 0)
				{
					parameters.SignatureLastEditUser = userSignature2.Signature;
				}
				DbSet<UserSignature> userSignature5 = _dbTbl.UserSignature;
				val = Expression.Parameter(typeof(UserSignature), "c");
				userSignature2 = Queryable.FirstOrDefault<UserSignature>((IQueryable<UserSignature>)userSignature5, Expression.Lambda<Func<UserSignature, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Convert((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), typeof(int?)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass25_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (userSignature2 != null && userSignature2.Signature != null && userSignature2.Signature.Length != 0)
				{
					parameters.SignatureVerifierUser = userSignature2.Signature;
				}
			}
			parameters.NotUsed_ListPrintOrderVerificationRequestDetails = new List<WSspRpt_PrintVerificationRequestDetails_Result>();
			if (wSspRpt_PrintOrder_Result != null && wSspRpt_PrintOrder_Result.ordVerificationWorkFlowId.HasValue)
			{
				parameters.NotUsed_ListPrintOrderVerificationRequestDetails = Enumerable.ToList<WSspRpt_PrintVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintVerificationRequestDetails_Result>)_dbI.WSspRpt_PrintVerificationRequestDetails(wSspRpt_PrintOrder_Result.OrderID, 20, wSspRpt_PrintOrder_Result.ordVerificationWorkFlowId, CS_0024_003C_003E8__locals0.currLangID, CS_0024_003C_003E8__locals0.defLangID));
				if (parameters.NotUsed_ListPrintOrderVerificationRequestDetails != null && Enumerable.Any<WSspRpt_PrintVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintVerificationRequestDetails_Result>)parameters.NotUsed_ListPrintOrderVerificationRequestDetails))
				{
					foreach (WSspRpt_PrintVerificationRequestDetails_Result notUsed_ListPrintOrderVerificationRequestDetail in parameters.NotUsed_ListPrintOrderVerificationRequestDetails)
					{
						if (CS_0024_003C_003E8__locals0.currLangID != 1065)
						{
							if (!string.IsNullOrEmpty(notUsed_ListPrintOrderVerificationRequestDetail.VerifyDatePersian))
							{
								notUsed_ListPrintOrderVerificationRequestDetail.VerifyDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintOrderVerificationRequestDetail.VerifyDatePersian.Replace("/", "")).Replace("/", "");
							}
							if (!string.IsNullOrEmpty(notUsed_ListPrintOrderVerificationRequestDetail.FirstRegisterDatePersian))
							{
								notUsed_ListPrintOrderVerificationRequestDetail.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintOrderVerificationRequestDetail.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
							}
							if (!string.IsNullOrEmpty(notUsed_ListPrintOrderVerificationRequestDetail.RegisterDatePersian))
							{
								notUsed_ListPrintOrderVerificationRequestDetail.RegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintOrderVerificationRequestDetail.RegisterDatePersian.Replace("/", "")).Replace("/", "");
							}
							if (!string.IsNullOrEmpty(notUsed_ListPrintOrderVerificationRequestDetail.VerificationReqDatePersian))
							{
								notUsed_ListPrintOrderVerificationRequestDetail.VerificationReqDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintOrderVerificationRequestDetail.VerificationReqDatePersian.Replace("/", "")).Replace("/", "");
							}
							if (!string.IsNullOrEmpty(notUsed_ListPrintOrderVerificationRequestDetail.VerificationReqExpiredDatePersian))
							{
								notUsed_ListPrintOrderVerificationRequestDetail.VerificationReqExpiredDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintOrderVerificationRequestDetail.VerificationReqExpiredDatePersian.Replace("/", "")).Replace("/", "");
							}
						}
						if (notUsed_ListPrintOrderVerificationRequestDetail.VerifyUserSignature != null)
						{
							notUsed_ListPrintOrderVerificationRequestDetail.VerifyUserSignatureStr = Convert.ToBase64String(notUsed_ListPrintOrderVerificationRequestDetail.VerifyUserSignature);
						}
					}
				}
			}
			if (parameters.NotUsed_ListPrintOrderVerificationRequestDetails == null)
			{
				parameters.NotUsed_ListPrintOrderVerificationRequestDetails = new List<WSspRpt_PrintVerificationRequestDetails_Result>();
			}
			parameters.NotUsed_ListPrintOrderDoc = new List<WSspRpt_PrintOrderDoc_Result>();
			if (wSspRpt_PrintOrder_Result != null)
			{
				parameters.NotUsed_ListPrintOrderDoc = Enumerable.ToList<WSspRpt_PrintOrderDoc_Result>((IEnumerable<WSspRpt_PrintOrderDoc_Result>)_dbI.WSspRpt_PrintOrderDoc(wSspRpt_PrintOrder_Result.OrderID, CS_0024_003C_003E8__locals0.currLangID, CS_0024_003C_003E8__locals0.defLangID));
				if (parameters.NotUsed_ListPrintOrderDoc != null && Enumerable.Any<WSspRpt_PrintOrderDoc_Result>((IEnumerable<WSspRpt_PrintOrderDoc_Result>)parameters.NotUsed_ListPrintOrderDoc))
				{
					foreach (WSspRpt_PrintOrderDoc_Result item9 in parameters.NotUsed_ListPrintOrderDoc)
					{
						if (CS_0024_003C_003E8__locals0.currLangID != 1065 && !string.IsNullOrEmpty(item9.DocDate))
						{
							item9.DocDate = PersianDate.GetShamsi2Miladi(item9.DocDate.Replace("/", "")).Replace("/", "");
						}
					}
				}
			}
			if (parameters.NotUsed_ListPrintOrderDoc == null)
			{
				parameters.NotUsed_ListPrintOrderDoc = new List<WSspRpt_PrintOrderDoc_Result>();
			}
			parameters.NotUsed_ListOrderItemPrdPicture = new List<WSspRpt_PrintOrderItemPrdPicture_Result>();
			if (wSspRpt_PrintOrder_Result != null)
			{
				parameters.NotUsed_ListOrderItemPrdPicture = Enumerable.ToList<WSspRpt_PrintOrderItemPrdPicture_Result>((IEnumerable<WSspRpt_PrintOrderItemPrdPicture_Result>)_dbI.WSspRpt_PrintOrderItemPrdPicture(wSspRpt_PrintOrder_Result.OrderID, CS_0024_003C_003E8__locals0.currLangID, CS_0024_003C_003E8__locals0.defLangID));
			}
			if (parameters.NotUsed_ListOrderItemPrdPicture == null)
			{
				parameters.NotUsed_ListOrderItemPrdPicture = new List<WSspRpt_PrintOrderItemPrdPicture_Result>();
			}
			CRMspReturnSumCompanyScores_Result cRMspReturnSumCompanyScores_Result = Enumerable.FirstOrDefault<CRMspReturnSumCompanyScores_Result>((IEnumerable<CRMspReturnSumCompanyScores_Result>)_dbI.CRMspReturnSumCompanyScores(num, result));
			if (cRMspReturnSumCompanyScores_Result != null)
			{
				parameters.SumScores = cRMspReturnSumCompanyScores_Result.SumScores;
				parameters.SumUsableScores = cRMspReturnSumCompanyScores_Result.SumUsableScores;
			}
			List<ScorespSelectOrderScores_Result> list7 = Enumerable.ToList<ScorespSelectOrderScores_Result>((IEnumerable<ScorespSelectOrderScores_Result>)_dbI.ScorespSelectOrderScores(orderId, CS_0024_003C_003E8__locals0.currLangID, CS_0024_003C_003E8__locals0.defLangID, result));
			if (list7 != null)
			{
				parameters.NotUsed_ScorespSelectOrderScores = list7;
			}
			string text5 = "";
			if (wSspRpt_PrintOrder_Result != null)
			{
				text5 = wSspRpt_PrintOrder_Result.ordLinkAccData ?? "";
			}
			if (!string.IsNullOrWhiteSpace(text5))
			{
				List<OrdLinkAccDataViewModel> list8 = new JavaScriptSerializer().Deserialize<List<OrdLinkAccDataViewModel>>(text5);
				if (list8 != null && Enumerable.Any<OrdLinkAccDataViewModel>((IEnumerable<OrdLinkAccDataViewModel>)list8))
				{
					foreach (OrdLinkAccDataViewModel vmLkAcc in list8)
					{
						vmLkAcc.OrdId = orderId;
						CRMspSelectLinkAccSettingDBIsActive_Result cRMspSelectLinkAccSettingDBIsActive_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)list, (Func<CRMspSelectLinkAccSettingDBIsActive_Result, bool>)((CRMspSelectLinkAccSettingDBIsActive_Result m) => m.LinkAccSettingDBId == vmLkAcc.DBId.GetValueOrDefault()));
						if (cRMspSelectLinkAccSettingDBIsActive_Result2 != null)
						{
							vmLkAcc.DbName = cRMspSelectLinkAccSettingDBIsActive_Result2.LinkAccSettingDbName ?? "";
							vmLkAcc.DbTitle = cRMspSelectLinkAccSettingDBIsActive_Result2.LinkAccSettingDbTitle ?? "";
						}
					}
					parameters.NotUsed_ListLinkAccData.AddRange(list8);
				}
			}
			if (parameters.NotUsed_ListLinkAccData == null)
			{
				parameters.NotUsed_ListLinkAccData = new List<OrdLinkAccDataViewModel>();
			}
			if (parameters.NotUsed_ListPayLinkAccData == null)
			{
				parameters.NotUsed_ListPayLinkAccData = new List<PayLinkAccDataViewModel>();
			}
			if (parameters.NotUsed_ListCmpAllPayRemainLinkAccData == null)
			{
				parameters.NotUsed_ListCmpAllPayRemainLinkAccData = new List<CmpAccountingLinkAccDataViewModel>();
			}
			WSspReturnPrintFormatFileNameById_Result wSspReturnPrintFormatFileNameById_Result = Enumerable.FirstOrDefault<WSspReturnPrintFormatFileNameById_Result>((IEnumerable<WSspReturnPrintFormatFileNameById_Result>)Enumerable.ToList<WSspReturnPrintFormatFileNameById_Result>((IEnumerable<WSspReturnPrintFormatFileNameById_Result>)_db.WSspReturnPrintFormatFileNameById(wSspRpt_PrintOrder_Result.ordPrintFormatId)));
			if (wSspReturnPrintFormatFileNameById_Result != null)
			{
				text3 = wSspReturnPrintFormatFileNameById_Result.FileNameWeb;
			}
			if (string.IsNullOrEmpty(text3))
			{
				text3 = "OrderPrint.mrt";
			}
			XmlSerializer val2 = new XmlSerializer(typeof(Parameters));
			StringWriter stringWriter = new StringWriter();
			XmlWriter val3 = XmlWriter.Create((TextWriter)stringWriter);
			val2.Serialize(val3, (object)parameters);
			DataSet val4 = new DataSet();
			val4.ReadXmlSchema(text + "OrderPrint.xsd");
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
			string text8 = text7 + "\\Ord_" + UserLogin.CurrentUser.UserId + "_" + orderId + ".pdf";
			string text9 = text7 + "\\Ord_Zip_" + UserLogin.CurrentUser.UserId + "_" + orderId;
			if (!System.IO.Directory.Exists(text9))
			{
				System.IO.Directory.CreateDirectory(text9);
				CRM.General.IO.Directory.SetFullControlForEveryOne(text9);
			}
			string file = text9 + "\\Ord_001.jpg";
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
								goto end_IL_1b86;
							case 0:
								pdfPage.Size = PageSize.A3;
								goto end_IL_1b86;
							case 1:
								pdfPage.Size = PageSize.A4;
								goto end_IL_1b86;
							case 3:
								pdfPage.Size = PageSize.A5;
								goto end_IL_1b86;
							case 4:
								pdfPage.Size = PageSize.B4;
								goto end_IL_1b86;
							case 5:
								pdfPage.Size = PageSize.B5;
								goto end_IL_1b86;
							case 2:
								break;
							}
							pdfPage.Size = PageSize.A4;
							end_IL_1b86:;
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

	public ActionResult _PartialList(int orderCurrentId, int companyId, int orderNumber, string fromDate, string toDate, string linkAccOrdNum, int? userId = null, int? orderId = null)
	{
		OrderListViewModel orderListViewModel = new OrderListViewModel
		{
			userId = userId,
			companyId = companyId,
			orderId = orderId,
			toDate = toDate,
			orderNumber = orderNumber,
			fromDate = fromDate,
			orderCurrentId = orderCurrentId,
			linkAccOrderNumber = linkAccOrdNum
		};
		base.ViewBag.OrderList = orderListViewModel;
		return PartialView();
	}

	public ActionResult _PartialList_Read([DataSourceRequest] DataSourceRequest request, int orderCurrentId, int companyId, int orderNumber, string fromDate, string toDate, string linkAccOrdNum, int? userId = null, int? orderId = null)
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
		if (!orderId.HasValue)
		{
			orderId = 0;
		}
		List<WSspSelectOrdersInMode_Result> list = Enumerable.ToList<WSspSelectOrdersInMode_Result>(Enumerable.Reverse<WSspSelectOrdersInMode_Result>((IEnumerable<WSspSelectOrdersInMode_Result>)_db.WSspSelectOrdersInMode(fromDate, toDate, userId, orderId, companyId, orderNumber, lCID, result, value, now, linkAccOrdNum, result2)));
		foreach (WSspSelectOrdersInMode_Result item in list)
		{
			item.ordDate = (item.ordDateTime.HasValue ? item.ordDateTime.Value.ToString("yyyy/MM/dd") : item.ordDate);
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
	public JsonResult GetWareHouseForBarcode()
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
			List<WSspSelectWareHouse_Result> list2 = CRMIdeal.Classes.Helper.Warehouse.SelectWareHouse();
			list.AddRange(Enumerable.Select<WSspSelectWareHouse_Result, SelectListItem>((IEnumerable<WSspSelectWareHouse_Result>)list2, (Func<WSspSelectWareHouse_Result, SelectListItem>)((WSspSelectWareHouse_Result item) => new SelectListItem
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
		base.ViewBag.WareHouseForBarCodeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public string RegisterBarcode(int ordId, int whId, string prdCode, string prdSerial, int ordItemId = 0)
	{
		string result = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
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
			int userId = currentUser.UserId;
			DateTime now = DateTime.Now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			if (ordId > 0)
			{
				if (Order.IsSentToLinkAccByAction(ordId))
				{
					string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
					return string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
				}
				int num = _db.WSspInsertOrderItemWithBarcode(ordId, prdCode, prdSerial, whId, userId, value2, value, now, registerDatePersian, appType, result2, ordItemId, centerId);
				int result3 = 0;
				int.TryParse(num.ToString(), out result3);
				if (result3 > 0)
				{
					result = "";
				}
				else
				{
					switch (result3)
					{
					case 0:
						result = Messages.msgErrorRunProcedure;
						break;
					case -1:
						result = Messages.msgErrorPrdAndSerialIsDup;
						break;
					case -2:
						result = Messages.msgErrorSerialNotFoundAndInsert;
						break;
					case -3:
						result = Messages.msgErrorNoPrdWithCode;
						break;
					case -4:
						result = Messages.msgErrorSerialIsOnDraft;
						break;
					case -5:
						result = Messages.msgErrorSerialIsOnMovement;
						break;
					}
				}
			}
			else
			{
				result = Messages.ErrorNotFound;
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
	public string InsertOrdItemSerialByBarcode(int orderItemId, int prdId, int whId, string prdCode, string prdSerial)
	{
		string result = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
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
			int userId = currentUser.UserId;
			DateTime now = DateTime.Now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			if (string.IsNullOrWhiteSpace(prdSerial))
			{
				return Messages.msgErrorNotSerialInBarcode;
			}
			if (orderItemId > 0)
			{
				mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.WSspInsertOrderItemSerialWithBarcode(orderItemId, prdId, prdCode, prdSerial, whId, userId, value2, value, now, registerDatePersian, appType, result2, centerId));
				int result3 = 0;
				int.TryParse(mct_I_Result.Result.ToString(), out result3);
				if (result3 > 0)
				{
					result = "";
				}
				else
				{
					switch (result3)
					{
					case 0:
						result = Messages.msgErrorRunProcedure;
						break;
					case -1:
						result = Messages.msgErrorNoPrdWithCode;
						break;
					case -2:
						result = Messages.msgErrorConflictPrdWithCode;
						break;
					case -3:
						result = Messages.msgErrorSerialIsOnDraft;
						break;
					case -4:
						result = Messages.msgErrorNotSerialInBarcode;
						break;
					case -5:
						result = Messages.msgErrorSerialNotFoundAndInsert;
						break;
					case -6:
						result = Messages.msgErrorSerialIsDup;
						break;
					case -7:
						result = Messages.msgErrorSerialIsOnMovement;
						break;
					}
				}
			}
			else
			{
				result = Messages.ErrorNotFound;
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
	[DynamicAuthorize(ControllerName = "frmOrder", ActionName = "actRemoveProductWithLinked")]
	public string RemoveProductWithLinked(int ordId, int ordItemId)
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
			if (!UserLogin.IsUserAccess("frmOrder", "actRemoveProductWithLinked", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			if (Order.IsFixed(ordId))
			{
				return "msgErrorNotActiveOrd".OrderMessages();
			}
			if (Order.IsSentToLinkAccByAction(ordId))
			{
				string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
				return string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
			}
			if (ordItemId > 0)
			{
				try
				{
					mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.WSspDeleteOrderItemWithLinkedPrd(ordId, ordItemId));
					if (mct_I_Result != null && mct_I_Result.Result > 0)
					{
						result = (Order.CalcAndSetOrderAmounts(ordId) ? "1" : Messages.msgErrorInCalculation);
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

	[AjaxOnly]
	public ActionResult OrderScores_Read([DataSourceRequest] DataSourceRequest request, int orderId = 0)
	{
		JsonResult jsonResult = Json(((IEnumerable)SelectOrderScores(orderId)).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<ScorespSelectOrderScores_Result> SelectOrderScores(int orderId = 0)
	{
		List<ScorespSelectOrderScores_Result> list = new List<ScorespSelectOrderScores_Result>();
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
			list = Enumerable.ToList<ScorespSelectOrderScores_Result>((IEnumerable<ScorespSelectOrderScores_Result>)_dbI.ScorespSelectOrderScores(orderId, lCID, result, result2));
			if (list != null)
			{
				foreach (ScorespSelectOrderScores_Result item in list)
				{
					_ = item.ScoreDate;
					item.ScoreDatePersian = item.ScoreDate.ToString("yyyy/MM/dd");
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[DynamicAuthorize(ControllerName = "frmOrder", ActionName = "actDeleteScore")]
	[AjaxOnly]
	public string DeleteOrderScore(int orderId = 0, int scoreId = 0)
	{
		string result = "";
		if (!UserLogin.IsUserAccess("frmOrder", "actDeleteScore", UserLogin.CurrentUser))
		{
			return "-1";
		}
		try
		{
			if (orderId != 0)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
				if (result2 <= 0)
				{
					result2 = 1065;
				}
				_ = Thread.CurrentThread.CurrentCulture.LCID;
				DateTime now = DateTime.Now;
				int userId = UserLogin.CurrentUser.UserId;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short value2 = short.Parse(Financial.Get().Id.ToString());
				int? centerId = null;
				if (UserLogin.CurrentUser != null)
				{
					centerId = UserLogin.CurrentUser.UserLastCId;
				}
				mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.ScorespDeleteScore(scoreId, userId, value2, value, now, registerDatePersian, appType, result2, centerId));
				int result3 = 0;
				if (mct_I_Result != null)
				{
					int.TryParse(mct_I_Result.Result.ToString(), out result3);
					if (result3 > 0)
					{
						result = Messages.frmDeleteSuccessMessage;
					}
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

	public string GetOrdFOLink(int ordId = 0)
	{
		return JsonConvert.SerializeObject(Order.GetOrdExternalLinks(ordId));
	}

	public string GetOrdFOShortLink(int ordId = 0)
	{
		return JsonConvert.SerializeObject(Order.GetOrdFoShortLinks(ordId));
	}

	[AjaxOnly]
	public JsonResult GetDocInfo(int ordId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspReturnDocForSaleOrder_Result> list = new List<WSspReturnDocForSaleOrder_Result>();
		try
		{
			list = Enumerable.ToList<WSspReturnDocForSaleOrder_Result>((IEnumerable<WSspReturnDocForSaleOrder_Result>)_db.WSspReturnDocForSaleOrder(ordId, lCID, result));
			if (list == null)
			{
				list = new List<WSspReturnDocForSaleOrder_Result>();
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
	public string IsFixed(int ordId)
	{
		string result = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmOrder", "actIsFixed", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			_dbII.WSspOrderIsFixed(ordId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	[AjaxOnly]
	public string ExitIsFixed(int ordId)
	{
		string result = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmOrder", "actExitIsFixed", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			if (Order.IsVerified(ordId))
			{
				return string.Format(Messages.msgErrorNotExitIsFixedAfterVerify, "lblOrd".OrderLabels());
			}
			_dbII.WSspOrderIsFixedExit(ordId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	[AjaxOnly]
	[HttpPost]
	public JsonResult EditOrdTsp(int ordId, string tspOrdIdentify, string tspOrdInno, string tspOrdReferenceNumber)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel();
		commonReturnResultViewModel.IsDone = false;
		int num = 0;
		try
		{
			if (num == 0)
			{
				DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
				short.Parse(Financial.Get().Id.ToString());
				short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				_ = UserLogin.CurrentUser.UserId;
				if (string.IsNullOrWhiteSpace(tspOrdIdentify))
				{
					tspOrdIdentify = "IsNull";
				}
				if (string.IsNullOrWhiteSpace(tspOrdInno))
				{
					tspOrdInno = "IsNull";
				}
				if (string.IsNullOrWhiteSpace(tspOrdReferenceNumber))
				{
					tspOrdReferenceNumber = "IsNull";
				}
				_dbI.TSPspUpdateOrder(ordId, tspOrdIdentify, tspOrdInno, null, null, null, null, null, null, tspOrdReferenceNumber, null, null, appType, null, null);
				commonReturnResultViewModel.IsDone = true;
				commonReturnResultViewModel.Message = Messages.msgSuccessAction;
			}
			else
			{
				commonReturnResultViewModel.IsDone = false;
			}
		}
		catch (DbEntityValidationException e)
		{
			commonReturnResultViewModel.IsDone = false;
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
		}
		catch (Exception e2)
		{
			commonReturnResultViewModel.IsDone = false;
			ErrorSignal.FromCurrentContext().Raise(e2);
			commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
		}
		return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetRefOrdersForSaleOrder(int ordId = 0)
	{
		List<WSspReturnRefOrdersForSaleOrder_Result> value = new List<WSspReturnRefOrdersForSaleOrder_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (ordId != 0)
			{
				List<WSspReturnRefOrdersForSaleOrder_Result> list = Enumerable.ToList<WSspReturnRefOrdersForSaleOrder_Result>((IEnumerable<WSspReturnRefOrdersForSaleOrder_Result>)_dbII.WSspReturnRefOrdersForSaleOrder(ordId, lCID, result));
				if (list != null)
				{
					foreach (WSspReturnRefOrdersForSaleOrder_Result item in list)
					{
						item.ordDate = item.ordDateTime?.ToString("yyyy/MM/dd");
					}
					value = list;
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return JsonConvert.SerializeObject(value);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetOrderInfoWithOrdNumber(long ordNumber = 0L)
	{
		WSspSelectOrderWithOrdNumber_Result value = new WSspSelectOrderWithOrdNumber_Result();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (ordNumber != 0L)
			{
				WSspSelectOrderWithOrdNumber_Result wSspSelectOrderWithOrdNumber_Result = Enumerable.FirstOrDefault<WSspSelectOrderWithOrdNumber_Result>((IEnumerable<WSspSelectOrderWithOrdNumber_Result>)_dbII.WSspSelectOrderWithOrdNumber(ordNumber, lCID, result));
				if (wSspSelectOrderWithOrdNumber_Result != null)
				{
					value = wSspSelectOrderWithOrdNumber_Result;
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return JsonConvert.SerializeObject(value);
	}

	[AjaxOnly]
	public JsonResult KaraAfzarCreateUserNameSmsPanel(int cmpId)
	{
		string text = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		string text2 = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (cmpId != 0)
			{
				int num = 0;
				if (cmpId <= 0)
				{
					num++;
					text = text + Messages.msgErrorNotSelectCompany + "<br>";
				}
				if (num == 0)
				{
					string newSmsUserName = "";
					string text3 = Order.KaraAfzarCreateUsernameAndPasswordForSmsOrdItemByCmp(cmpId, ref newSmsUserName);
					if (string.IsNullOrWhiteSpace(text3) && !string.IsNullOrWhiteSpace(newSmsUserName))
					{
						text2 = "1";
						text = Messages.msgSuccessAction;
						commonResultStatusViewModel = CommonResultStatusViewModel.Success;
					}
					else
					{
						text2 = "";
						text = text3;
						if (string.IsNullOrWhiteSpace(text))
						{
							text = Messages.msgErrorRunFunction;
						}
						commonResultStatusViewModel = CommonResultStatusViewModel.Fail;
					}
				}
				else
				{
					text2 = "";
					if (string.IsNullOrWhiteSpace(text))
					{
						text = Messages.msgErrorRunFunction;
					}
					commonResultStatusViewModel = CommonResultStatusViewModel.Error;
				}
			}
			else
			{
				text2 = "";
				text = Messages.msgErrorRunFunction;
				commonResultStatusViewModel = CommonResultStatusViewModel.Error;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text2 = "";
			text = Messages.msgErrorRunFunction + " " + ex.Message;
			commonResultStatusViewModel = CommonResultStatusViewModel.Error;
		}
		CommonResultViewModel<string> data = new CommonResultViewModel<string>
		{
			Data = text2,
			Message = text,
			Status = commonResultStatusViewModel
		};
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult KaraAfzarCreateMobAppDomain(int cmpId)
	{
		string text = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		string text2 = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (cmpId != 0)
			{
				int num = 0;
				if (cmpId <= 0)
				{
					num++;
					text = text + Messages.msgErrorNotSelectCompany + "<br>";
				}
				if (num == 0)
				{
					string text3 = Order.KaraAfzarCreateDomainandUrlForMobByCmp(cmpId);
					if (string.IsNullOrWhiteSpace(text3))
					{
						text2 = "1";
						text = Messages.msgSuccessAction;
						commonResultStatusViewModel = CommonResultStatusViewModel.Success;
					}
					else
					{
						text2 = "";
						text = text3;
						if (string.IsNullOrWhiteSpace(text))
						{
							text = Messages.msgErrorRunFunction;
						}
						commonResultStatusViewModel = CommonResultStatusViewModel.Fail;
					}
				}
				else
				{
					text2 = "";
					if (string.IsNullOrWhiteSpace(text))
					{
						text = Messages.msgErrorRunFunction;
					}
					commonResultStatusViewModel = CommonResultStatusViewModel.Error;
				}
			}
			else
			{
				text2 = "";
				text = Messages.msgErrorRunFunction;
				commonResultStatusViewModel = CommonResultStatusViewModel.Error;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text2 = "";
			text = Messages.msgErrorRunFunction + " " + ex.Message;
			commonResultStatusViewModel = CommonResultStatusViewModel.Error;
		}
		CommonResultViewModel<string> data = new CommonResultViewModel<string>
		{
			Data = text2,
			Message = text,
			Status = commonResultStatusViewModel
		};
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult KaraAfzarUpdateMobAppDomain(int cmpId)
	{
		string text = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		string text2 = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (cmpId != 0)
			{
				int num = 0;
				if (cmpId <= 0)
				{
					num++;
					text = text + Messages.msgErrorNotSelectCompany + "<br>";
				}
				if (num == 0)
				{
					string text3 = Order.KaraAfzarUpdateDomainandUrlForMobByCmp(cmpId);
					if (string.IsNullOrWhiteSpace(text3))
					{
						text2 = "1";
						text = Messages.msgSuccessAction;
						commonResultStatusViewModel = CommonResultStatusViewModel.Success;
					}
					else
					{
						text2 = "";
						text = text3;
						if (string.IsNullOrWhiteSpace(text))
						{
							text = Messages.msgErrorRunFunction;
						}
						commonResultStatusViewModel = CommonResultStatusViewModel.Fail;
					}
				}
				else
				{
					text2 = "";
					if (string.IsNullOrWhiteSpace(text))
					{
						text = Messages.msgErrorRunFunction;
					}
					commonResultStatusViewModel = CommonResultStatusViewModel.Error;
				}
			}
			else
			{
				text2 = "";
				text = Messages.msgErrorRunFunction;
				commonResultStatusViewModel = CommonResultStatusViewModel.Error;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text2 = "";
			text = Messages.msgErrorRunFunction + " " + ex.Message;
			commonResultStatusViewModel = CommonResultStatusViewModel.Error;
		}
		CommonResultViewModel<string> data = new CommonResultViewModel<string>
		{
			Data = text2,
			Message = text,
			Status = commonResultStatusViewModel
		};
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public string CalcAndUpdateDiscountPolicy(int ordId)
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
			if (ordId != 0)
			{
				if (Order.IsFixed(ordId))
				{
					return "msgErrorNotActiveOrd".OrderMessages();
				}
				if (Order.IsSentToLinkAccByAction(ordId))
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
				List<WSspCalcAndUpdateDiscountPolicyInOrdItems_Result> list = Enumerable.ToList<WSspCalcAndUpdateDiscountPolicyInOrdItems_Result>((IEnumerable<WSspCalcAndUpdateDiscountPolicyInOrdItems_Result>)_dbII.WSspCalcAndUpdateDiscountPolicyInOrdItems(ordId, value, userId, id, value2, value, registerDatePersian, appType, lCID, result, objectParameter));
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
					if (list != null && Enumerable.Any<WSspCalcAndUpdateDiscountPolicyInOrdItems_Result>((IEnumerable<WSspCalcAndUpdateDiscountPolicyInOrdItems_Result>)list))
					{
						foreach (WSspCalcAndUpdateDiscountPolicyInOrdItems_Result item in list)
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
					return "1|" + string.Format(Messages.msgCalcAdnUpdateDiscounPolicyOnItem, "lblOrd".OrderLabels(), text2);
				}
				case 2:
					return string.Format(Messages.msgErrorNotFindDiscoutPolicyOnItem, "lblOrd".OrderLabels());
				default:
					return string.Format(Messages.msgErrorCalcAndUpdateDiscountPolicyOnItem, "lblOrd".OrderLabels());
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

	[DynamicAuthorize(ControllerName = "frmOrder", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(int id = 0, string itemsAmount = "", string parameters = "")
	{
		_003C_003Ec__DisplayClass48_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass48_0();
		CS_0024_003C_003E8__locals0.id = id;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		_ = UserLogin.CurrentUser.UserId;
		string[] array = parameters.Split(new char[1] { '|' });
		base.ViewBag.MyParameters = array;
		decimal result2 = default(decimal);
		string text = "";
		string text2 = "";
		string text3 = "";
		CS_0024_003C_003E8__locals0.vm = new WSOrderLanguageViewModel();
		List<CRMspSelectCompanyTitle_Result> list = Enumerable.ToList<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)_db.CRMspSelectCompanyTitle(CS_0024_003C_003E8__locals0.currLangID, result));
		if (CS_0024_003C_003E8__locals0.id > 0)
		{
			if (!UserLogin.IsUserAccess("frmOrder", "actEdit"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			DbSet<WSOrder_Lang> wSOrder_Lang = _dbTbl.WSOrder_Lang;
			ParameterExpression val = Expression.Parameter(typeof(WSOrder_Lang), "c");
			List<WSOrder_Lang> list2 = Enumerable.ToList<WSOrder_Lang>((IEnumerable<WSOrder_Lang>)Queryable.Where<WSOrder_Lang>((IQueryable<WSOrder_Lang>)wSOrder_Lang, Expression.Lambda<Func<WSOrder_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass48_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			DbSet<WSOrder> wSOrder = _dbTbl.WSOrder;
			val = Expression.Parameter(typeof(WSOrder), "c");
			CS_0024_003C_003E8__locals0.model = Queryable.FirstOrDefault<WSOrder>((IQueryable<WSOrder>)wSOrder, Expression.Lambda<Func<WSOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass48_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (CS_0024_003C_003E8__locals0.model == null)
			{
				base.ViewBag.Error = Messages.ErrorNotFound;
				return null;
			}
			if (Order.IsEditAfterFix(CS_0024_003C_003E8__locals0.model.ordEditAfterFixInfoJs, CS_0024_003C_003E8__locals0.model.OrderID, 1))
			{
				CS_0024_003C_003E8__locals0.model.ordIsFixed = false;
			}
			if (CS_0024_003C_003E8__locals0.model.ordIsFixed.HasValue && CS_0024_003C_003E8__locals0.model.ordIsFixed.GetValueOrDefault())
			{
				base.ViewBag.Error = "msgErrorNotActiveOrd".OrderMessages();
				return null;
			}
			if (itemsAmount.Trim() != "")
			{
				itemsAmount = itemsAmount.Replace(",", "").Replace("،", "").Replace("/", ".");
				decimal.TryParse(itemsAmount, out result2);
			}
			CRMspSelectCompanyById_Result cmp2 = CRMIdeal.Classes.Helper.Company.GetCompanyById(CS_0024_003C_003E8__locals0.model.ordCompanyId);
			if (cmp2 != null)
			{
				text = ((Enumerable.FirstOrDefault<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)list, (Func<CRMspSelectCompanyTitle_Result, bool>)((CRMspSelectCompanyTitle_Result c) => c.CompanyTitleID == cmp2.cmpTitleId)) != null) ? (Enumerable.FirstOrDefault<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)list, (Func<CRMspSelectCompanyTitle_Result, bool>)((CRMspSelectCompanyTitle_Result c) => c.CompanyTitleID == cmp2.cmpTitleId)).CompanyTitle + " ") : "") + cmp2.cmpName;
				text2 = cmp2.cmpAddress;
				text3 = cmp2.cmpTel;
			}
			List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrder_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrder_Lang>)list2, (Func<WSOrder_Lang, CommonMultiLanguageViewModel>)((WSOrder_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.ordTitle,
				LanguageId = item.LanguageID
			})));
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.ordTitle,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrder_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrder_Lang>)list2, (Func<WSOrder_Lang, CommonMultiLanguageViewModel>)((WSOrder_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.ordSubject,
				LanguageId = item.LanguageID
			})));
			list4.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.ordSubject,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list5 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrder_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrder_Lang>)list2, (Func<WSOrder_Lang, CommonMultiLanguageViewModel>)((WSOrder_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.ordTotalAmountStr,
				LanguageId = item.LanguageID
			})));
			list5.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.ordTotalAmountStr,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list6 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrder_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrder_Lang>)list2, (Func<WSOrder_Lang, CommonMultiLanguageViewModel>)((WSOrder_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.ordSpecialWord,
				LanguageId = item.LanguageID
			})));
			list6.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.ordSpecialWord,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list7 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrder_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrder_Lang>)list2, (Func<WSOrder_Lang, CommonMultiLanguageViewModel>)((WSOrder_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.ordDescriptionI,
				LanguageId = item.LanguageID
			})));
			list7.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.ordDescriptionI,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list8 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrder_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrder_Lang>)list2, (Func<WSOrder_Lang, CommonMultiLanguageViewModel>)((WSOrder_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.ordDescriptionII,
				LanguageId = item.LanguageID
			})));
			list8.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.ordDescriptionII,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list9 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrder_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrder_Lang>)list2, (Func<WSOrder_Lang, CommonMultiLanguageViewModel>)((WSOrder_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.ordSigningI,
				LanguageId = item.LanguageID
			})));
			list9.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.ordSigningI,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list10 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrder_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrder_Lang>)list2, (Func<WSOrder_Lang, CommonMultiLanguageViewModel>)((WSOrder_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.ordSigningII,
				LanguageId = item.LanguageID
			})));
			list10.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.ordSigningII,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list11 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrder_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrder_Lang>)list2, (Func<WSOrder_Lang, CommonMultiLanguageViewModel>)((WSOrder_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.ordSigningIII,
				LanguageId = item.LanguageID
			})));
			list11.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.ordSigningIII,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list12 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrder_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrder_Lang>)list2, (Func<WSOrder_Lang, CommonMultiLanguageViewModel>)((WSOrder_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.ordNote,
				LanguageId = item.LanguageID
			})));
			list12.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.ordNote,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list13 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrder_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrder_Lang>)list2, (Func<WSOrder_Lang, CommonMultiLanguageViewModel>)((WSOrder_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.ordDiscountTitle,
				LanguageId = item.LanguageID
			})));
			list13.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.ordDiscountTitle,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list14 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrder_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrder_Lang>)list2, (Func<WSOrder_Lang, CommonMultiLanguageViewModel>)((WSOrder_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.ordcmpTitle,
				LanguageId = item.LanguageID
			})));
			list14.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.ordcmpTitle,
				LanguageId = result
			});
			WSOrderLanguageViewModel wSOrderLanguageViewModel = new WSOrderLanguageViewModel
			{
				OrderID = CS_0024_003C_003E8__locals0.model.OrderID,
				OrderOprID = CS_0024_003C_003E8__locals0.model.OrderOprID,
				PreOrderId = CS_0024_003C_003E8__locals0.model.PreOrderId,
				PreOrderVerifierId = CS_0024_003C_003E8__locals0.model.PreOrderVerifierId,
				ordNumber = CS_0024_003C_003E8__locals0.model.ordNumber,
				ordDate = (CS_0024_003C_003E8__locals0.model.ordDateTime.HasValue ? CS_0024_003C_003E8__locals0.model.ordDateTime.Value.ToString("yyyy/MM/dd") : ""),
				ordCompanyId = CS_0024_003C_003E8__locals0.model.ordCompanyId,
				ordCompanyPersonId = CS_0024_003C_003E8__locals0.model.ordCompanyPersonId,
				ordProjectId = CS_0024_003C_003E8__locals0.model.ordProjectId,
				ordItemCount = CS_0024_003C_003E8__locals0.model.ordItemCount,
				ordItemsAmount = CS_0024_003C_003E8__locals0.model.ordItemsAmount,
				ordInstallAmount = CS_0024_003C_003E8__locals0.model.ordInstallAmount,
				ordDiscount = CS_0024_003C_003E8__locals0.model.ordDiscount,
				ordSumAmount = CS_0024_003C_003E8__locals0.model.ordSumAmount,
				ordTax = CS_0024_003C_003E8__locals0.model.ordTax,
				ordTaxIndex = CS_0024_003C_003E8__locals0.model.ordTaxIndex,
				ordCalculateTax = CS_0024_003C_003E8__locals0.model.ordCalculateTax,
				ordTotalAmount = CS_0024_003C_003E8__locals0.model.ordTotalAmount,
				ordIsVerified = CS_0024_003C_003E8__locals0.model.ordIsVerified,
				ordVerifiedRegisterDate = CS_0024_003C_003E8__locals0.model.ordVerifiedRegisterDate,
				ordVerifiedRegisterDatePersian = CS_0024_003C_003E8__locals0.model.ordVerifiedRegisterDatePersian,
				ordStatusId = CS_0024_003C_003E8__locals0.model.ordStatusId,
				ordIsFixed = CS_0024_003C_003E8__locals0.model.ordIsFixed,
				ordGuarantyId = CS_0024_003C_003E8__locals0.model.ordGuarantyId,
				ordDescriptionId = CS_0024_003C_003E8__locals0.model.ordDescriptionId,
				ordPrintFormatId = CS_0024_003C_003E8__locals0.model.ordPrintFormatId,
				ordRLogoId = CS_0024_003C_003E8__locals0.model.ordRLogoId,
				ordLLogoId = CS_0024_003C_003E8__locals0.model.ordLLogoId,
				ordAccountNumberI = CS_0024_003C_003E8__locals0.model.ordAccountNumberI,
				ordAccountShabaNumberI = CS_0024_003C_003E8__locals0.model.ordAccountShabaNumberI,
				ordAccountNumberII = CS_0024_003C_003E8__locals0.model.ordAccountNumberII,
				ordAccountShabaNumberII = CS_0024_003C_003E8__locals0.model.ordAccountShabaNumberII,
				ordSignatureId = CS_0024_003C_003E8__locals0.model.ordSignatureId,
				ordImportDate = CS_0024_003C_003E8__locals0.model.ordImportDate,
				ordFirstRegisterUserId = CS_0024_003C_003E8__locals0.model.ordFirstRegisterUserId,
				UserId = CS_0024_003C_003E8__locals0.model.UserId,
				FPId = CS_0024_003C_003E8__locals0.model.FPId,
				Month1 = CS_0024_003C_003E8__locals0.model.Month1,
				RegisterDate = CS_0024_003C_003E8__locals0.model.RegisterDate,
				RegisterDatePersian = CS_0024_003C_003E8__locals0.model.RegisterDatePersian,
				ordVerifierId = CS_0024_003C_003E8__locals0.model.ordVerifierId,
				ordSettlementTypeId = CS_0024_003C_003E8__locals0.model.ordSettlementTypeId,
				ordDay = CS_0024_003C_003E8__locals0.model.ordDay,
				ordTime = CS_0024_003C_003E8__locals0.model.ordTime,
				GUId = CS_0024_003C_003E8__locals0.model.GUId,
				ordTransportation = CS_0024_003C_003E8__locals0.model.ordTransportation,
				ordReferUserId = CS_0024_003C_003E8__locals0.model.ordReferUserId,
				ordDiscountPercent = CS_0024_003C_003E8__locals0.model.ordDiscountPercent,
				ordRound = CS_0024_003C_003E8__locals0.model.ordRound,
				ordDateTime = CS_0024_003C_003E8__locals0.model.ordDateTime,
				ordImportDateTime = CS_0024_003C_003E8__locals0.model.ordImportDateTime,
				ordDeliveryDate = (CS_0024_003C_003E8__locals0.model.ordDeliveryDateTime.HasValue ? CS_0024_003C_003E8__locals0.model.ordDeliveryDateTime.Value.ToString("yyyy/MM/dd") : ""),
				ordDeliveryDateTime = CS_0024_003C_003E8__locals0.model.ordDeliveryDateTime,
				ordDeliveryTime = CS_0024_003C_003E8__locals0.model.ordDeliveryTime,
				ordDeliveryEndDate = (CS_0024_003C_003E8__locals0.model.ordDeliveryEndDateTime.HasValue ? CS_0024_003C_003E8__locals0.model.ordDeliveryEndDateTime.Value.ToString("yyyy/MM/dd") : ""),
				ordDeliveryEndDateTime = CS_0024_003C_003E8__locals0.model.ordDeliveryEndDateTime,
				ordDeliveryEndTime = CS_0024_003C_003E8__locals0.model.ordDeliveryEndTime,
				ordSerial = CS_0024_003C_003E8__locals0.model.ordSerial,
				AppType = CS_0024_003C_003E8__locals0.model.AppType,
				ordVerifierRequestId = CS_0024_003C_003E8__locals0.model.ordVerifierRequestId,
				LanguageID = CS_0024_003C_003E8__locals0.model.LanguageID,
				FirstRegisterUserId = CS_0024_003C_003E8__locals0.model.FirstRegisterUserId,
				FirstRegisterDatePersian = CS_0024_003C_003E8__locals0.model.FirstRegisterDatePersian,
				FirstRegisterDate = CS_0024_003C_003E8__locals0.model.FirstRegisterDate,
				ordTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				ordTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				ordSubject = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				ordSubject_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				ordTotalAmountStr = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				ordTotalAmountStr_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				ordSpecialWord = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				ordSpecialWord_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				ordDescriptionI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				ordDescriptionI_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				ordDescriptionII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				ordDescriptionII_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				ordSigningI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				ordSigningI_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				ordSigningII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				ordSigningII_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				ordSigningIII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				ordSigningIII_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				ordNote = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				ordNote_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				ordDiscountTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				ordDiscountTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				ordcmpTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				ordcmpTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				ordCurrencyUnitId = CS_0024_003C_003E8__locals0.model.ordCurrencyUnitId,
				ordCurrencyUnitIdI = CS_0024_003C_003E8__locals0.model.ordCurrencyUnitIdI,
				ordCurrencyUnitIRate = CS_0024_003C_003E8__locals0.model.ordCurrencyUnitIRate,
				ordDeliveryTermId = CS_0024_003C_003E8__locals0.model.ordDeliveryTermId,
				ordNumRef = CS_0024_003C_003E8__locals0.model.ordNumRef,
				ordDefWHId = CS_0024_003C_003E8__locals0.model.ordDefWHId,
				ordDefPrdPriceGroupId = CS_0024_003C_003E8__locals0.model.ordDefPrdPriceGroupId,
				ordSellerId = CS_0024_003C_003E8__locals0.model.ordSellerId,
				ordEmailUsersInfoId = CS_0024_003C_003E8__locals0.model.ordEmailUsersInfoId,
				ordEmailUserDefaultSettingId = CS_0024_003C_003E8__locals0.model.ordEmailUserDefaultSettingId,
				ordVerificationWorkFlowId = CS_0024_003C_003E8__locals0.model.ordVerificationWorkFlowId,
				ordSaleCenterId = CS_0024_003C_003E8__locals0.model.ordSaleCenterId,
				ordDefPayTypeId = CS_0024_003C_003E8__locals0.model.ordDefPayTypeId,
				ordDailyCounter = CS_0024_003C_003E8__locals0.model.ordDailyCounter,
				ordDeadlineDate = CS_0024_003C_003E8__locals0.model.ordDeadlineDate,
				ordDeadlineDatePersian = (CS_0024_003C_003E8__locals0.model.ordDeadlineDate.HasValue ? CS_0024_003C_003E8__locals0.model.ordDeadlineDate.Value.ToString("yyyy/MM/dd") : ""),
				ordTspSettingId = CS_0024_003C_003E8__locals0.model.ordTspSettingId,
				TspOrdIrtaxid = CS_0024_003C_003E8__locals0.model.TspOrdIrtaxid,
				TspOrdFt = CS_0024_003C_003E8__locals0.model.TspOrdFt,
				TspOrdBillid = CS_0024_003C_003E8__locals0.model.TspOrdBillid,
				TspOrdSetm = CS_0024_003C_003E8__locals0.model.TspOrdSetm,
				TspOrdInsp = CS_0024_003C_003E8__locals0.model.TspOrdInsp,
				TspOrdTax17 = CS_0024_003C_003E8__locals0.model.TspOrdTax17,
				TspOrdCdcn = CS_0024_003C_003E8__locals0.model.TspOrdCdcn,
				TspOrdCdcd = CS_0024_003C_003E8__locals0.model.TspOrdCdcd,
				TspOrdCdcdPersian = (CS_0024_003C_003E8__locals0.model.TspOrdCdcd.HasValue ? CS_0024_003C_003E8__locals0.model.TspOrdCdcd.Value.ToString("yyyy/MM/dd") : ""),
				ordDefaultSettingId = CS_0024_003C_003E8__locals0.model.ordDefaultSettingId,
				ordDeliveryDay = CS_0024_003C_003E8__locals0.model.ordDeliveryDay,
				ordDeliveryEndDay = CS_0024_003C_003E8__locals0.model.ordDeliveryEndDay,
				ordCompanyPersonIds = CS_0024_003C_003E8__locals0.model.ordCompanyPersonIds,
				ordGroupId = CS_0024_003C_003E8__locals0.model.ordGroupId,
				TspOrdSbc = CS_0024_003C_003E8__locals0.model.TspOrdSbc,
				TspOrdScln = CS_0024_003C_003E8__locals0.model.TspOrdScln,
				TspOrdScc = CS_0024_003C_003E8__locals0.model.TspOrdScc,
				TspOrdCrn = CS_0024_003C_003E8__locals0.model.TspOrdCrn,
				ordSaleAreaId = CS_0024_003C_003E8__locals0.model.ordSaleAreaId,
				ordRefOrderId = CS_0024_003C_003E8__locals0.model.ordRefOrderId
			};
			DbSet<WSOrder> wSOrder2 = _dbTbl.WSOrder;
			val = Expression.Parameter(typeof(WSOrder), "x");
			wSOrderLanguageViewModel.ordReturnsCnt = Enumerable.ToList<WSOrder>((IEnumerable<WSOrder>)Queryable.Where<WSOrder>((IQueryable<WSOrder>)wSOrder2, Expression.Lambda<Func<WSOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Convert((Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass48_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), typeof(int?))), (ParameterExpression[])(object)new ParameterExpression[1] { val }))).Count;
			CS_0024_003C_003E8__locals0.vm = wSOrderLanguageViewModel;
			if (CS_0024_003C_003E8__locals0.vm.ordRefOrderId.GetValueOrDefault() != 0)
			{
				WSOrderLanguageViewModel vm = CS_0024_003C_003E8__locals0.vm;
				DbSet<WSOrder> wSOrder3 = _dbTbl.WSOrder;
				val = Expression.Parameter(typeof(WSOrder), "x");
				vm.ordRefOrderNumber = Queryable.FirstOrDefault<WSOrder>((IQueryable<WSOrder>)wSOrder3, Expression.Lambda<Func<WSOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Convert((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), typeof(int?)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass48_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })).ordNumber;
			}
			if (CS_0024_003C_003E8__locals0.vm != null && CS_0024_003C_003E8__locals0.vm.ordSaleCenterId.GetValueOrDefault() != 0)
			{
				WSspSelectSaleCenterWithId_Result wSspSelectSaleCenterWithId_Result = Enumerable.FirstOrDefault<WSspSelectSaleCenterWithId_Result>((IEnumerable<WSspSelectSaleCenterWithId_Result>)_dbII.WSspSelectSaleCenterWithId(CS_0024_003C_003E8__locals0.vm.ordSaleCenterId, CS_0024_003C_003E8__locals0.currLangID, result));
				if (wSspSelectSaleCenterWithId_Result != null)
				{
					CS_0024_003C_003E8__locals0.vm.ordSaleCenterName = wSspSelectSaleCenterWithId_Result.SaleCenterName ?? "";
				}
			}
		}
		else
		{
			if (!UserLogin.IsUserAccess("frmOrder", "actInsert"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			DateTime now = DateTime.Now;
			CS_0024_003C_003E8__locals0.vm = new WSOrderLanguageViewModel
			{
				ordFirstRegisterUserId = UserLogin.CurrentUser.UserId,
				ordDate = now.ToString("yyyyMMdd", new PersianCulture()),
				ordDateTime = now,
				ordImportDate = now.ToString("yyyyMMdd", new PersianCulture()),
				ordImportDateTime = now,
				ordDay = DateTimeClass.DefineDayeOfWeekStartWith7(now.DayOfWeek.ToString()),
				ordTime = now.ToString("HH:mm:ss"),
				ordStatusId = 1,
				UserId = UserLogin.CurrentUser.UserId,
				RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
				RegisterDate = now
			};
			if (!UserLogin.IsUserAccess("frmOrderDataEntry", "actNoOrdTax", UserLogin.CurrentUser))
			{
				CS_0024_003C_003E8__locals0.vm.ordCalculateTax = true;
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
					text3 = cmp.cmpTel;
				}
			}
			base.ViewBag.IsBuying = VersionBuyer.Order;
		}
		GetOrdDefSetting();
		GetOrderOpr();
		GetOrdStatus();
		GetOrdGuaranty();
		GetOrdPrintFormat();
		GetOrdSetPementType();
		GetReferUser();
		GetdVerifierTitles();
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
		base.ViewBag.CmpTele = text3;
		GetCurrencyUnit();
		GetDeliveryTerms();
		GetWareHouse();
		GetProductPriceGroup();
		GetSeller();
		GetEmailUsersInfo();
		GetEmailUserDefaultSetting();
		GetVerificationWorkFlow();
		GetDefPayType();
		GetTspSetting();
		GetTspFt();
		GetTspSetm();
		GetTspDpvb();
		GetOrderGroups();
		GetSaleAreas();
		return View(CS_0024_003C_003E8__locals0.vm);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmOrderDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult InsertEdit(WSOrderLanguageViewModel vm)
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0309: Unknown result type (might be due to invalid IL or missing references)
		//IL_035d: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0405: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass49_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass49_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ordTitle_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.ordTitle_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.ordTitle,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ordSubject_Lang))
		{
			list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.ordSubject_Lang);
		}
		list2.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.ordSubject,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ordTotalAmountStr_Lang))
		{
			list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.ordTotalAmountStr_Lang);
		}
		list3.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.ordTotalAmountStr,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ordSpecialWord_Lang))
		{
			list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.ordSpecialWord_Lang);
		}
		list4.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.ordSpecialWord,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ordDescriptionI_Lang))
		{
			list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.ordDescriptionI_Lang);
		}
		list5.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.ordDescriptionI,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ordDescriptionII_Lang))
		{
			list6 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.ordDescriptionII_Lang);
		}
		list6.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.ordDescriptionII,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list7 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ordSigningI_Lang))
		{
			list7 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.ordSigningI_Lang);
		}
		list7.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.ordSigningI,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list8 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ordSigningII_Lang))
		{
			list8 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.ordSigningII_Lang);
		}
		list8.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.ordSigningII,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list9 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ordSigningIII_Lang))
		{
			list9 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.ordSigningIII_Lang);
		}
		list9.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.ordSigningIII,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list10 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ordNote_Lang))
		{
			list10 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.ordNote_Lang);
		}
		list10.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.ordNote,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list11 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ordDiscountTitle_Lang))
		{
			list11 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.ordDiscountTitle_Lang);
		}
		list11.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.ordDiscountTitle,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list12 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ordcmpTitle_Lang))
		{
			list12 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.ordcmpTitle_Lang);
		}
		list12.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.ordcmpTitle,
			LanguageId = lCID
		});
		base.ViewBag.MyParameters = "".Split(new char[1] { '|' });
		string text = "";
		string text2 = "";
		string text3 = "";
		CS_0024_003C_003E8__locals0.cmp = CRMIdeal.Classes.Helper.Company.GetCompanyById(CS_0024_003C_003E8__locals0.vm.ordCompanyId);
		List<CRMspSelectCompanyTitle_Result> list13 = Enumerable.ToList<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)_db.CRMspSelectCompanyTitle(lCID, CS_0024_003C_003E8__locals0.defLangID));
		if (CS_0024_003C_003E8__locals0.cmp != null)
		{
			text = ((Enumerable.FirstOrDefault<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)list13, (Func<CRMspSelectCompanyTitle_Result, bool>)((CRMspSelectCompanyTitle_Result c) => c.CompanyTitleID == CS_0024_003C_003E8__locals0.cmp.cmpTitleId)) != null) ? (Enumerable.FirstOrDefault<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)list13, (Func<CRMspSelectCompanyTitle_Result, bool>)((CRMspSelectCompanyTitle_Result c) => c.CompanyTitleID == CS_0024_003C_003E8__locals0.cmp.cmpTitleId)).CompanyTitle + " ") : "") + CS_0024_003C_003E8__locals0.cmp.cmpName;
			text2 = CS_0024_003C_003E8__locals0.cmp.cmpAddress;
			text3 = CS_0024_003C_003E8__locals0.cmp.cmpTel;
		}
		base.ViewBag.CmpFullName = text;
		base.ViewBag.CmpAddrs = text2;
		base.ViewBag.CmpTele = text3;
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
		GetOrdDefSetting();
		GetOrderOpr();
		GetOrdStatus();
		GetOrdGuaranty();
		GetOrdPrintFormat();
		GetOrdSetPementType();
		GetReferUser();
		GetdVerifierTitles();
		GetCurrencyUnit();
		GetDeliveryTerms();
		GetWareHouse();
		GetProductPriceGroup();
		GetSeller();
		GetEmailUsersInfo();
		GetEmailUserDefaultSetting();
		GetVerificationWorkFlow();
		GetDefPayType();
		GetTspSetting();
		GetTspFt();
		GetTspSetm();
		GetTspDpvb();
		GetOrderGroups();
		GetSaleAreas();
		List<int> list14 = new List<int>();
		List<CRMspSelectUsers_Result> list15 = CRMIdeal.Classes.Helper.User.SelectUsers(0);
		if (list15 != null && Enumerable.Any<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)list15))
		{
			list14 = Enumerable.ToList<int>(Enumerable.Select<CRMspSelectUsers_Result, int>(Enumerable.Where<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)list15, (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result c) => c.IsActive == false || !c.IsActive.HasValue)), (Func<CRMspSelectUsers_Result, int>)((CRMspSelectUsers_Result c) => c.UserId)));
		}
		base.ViewBag.ListUserIsActiveStatus = list14;
		long num = 0L;
		long num2 = 0L;
		string text4 = "";
		int sysPartId = 30;
		try
		{
			int? num3 = null;
			if (UserLogin.CurrentUser != null)
			{
				num3 = UserLogin.CurrentUser.UserLastCId;
			}
			if (CS_0024_003C_003E8__locals0.vm.OrderID <= 0 && !VersionBuyer.Order)
			{
				DbSet<WSOrder> wSOrder = _dbTbl.WSOrder;
				ParameterExpression val = Expression.Parameter(typeof(WSOrder), "c");
				if (Queryable.Any<WSOrder>((IQueryable<WSOrder>)wSOrder, Expression.Lambda<Func<WSOrder, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)10, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val })))
				{
					base.ViewBag.Error = "BV|" + Messages.VersionBuy;
					return View(CS_0024_003C_003E8__locals0.vm);
				}
			}
			if (CS_0024_003C_003E8__locals0.vm.OrderID > 0 && Order.IsSentToLinkAccByAction(CS_0024_003C_003E8__locals0.vm.OrderID))
			{
				string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
				base.ViewBag.Error = string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			if (CS_0024_003C_003E8__locals0.vm.OrderID > 0 && CS_0024_003C_003E8__locals0.vm.ordSaleCenterId.GetValueOrDefault() != 0)
			{
				CRMspSelectFoSetting_Result foSetting = CRMIdeal.Classes.Helper.Setting.GetFoSetting();
				if (foSetting != null)
				{
					bool result2 = false;
					bool.TryParse(foSetting.ShpUniqueSaleCenterParentInOrd.ToString(), out result2);
					if (result2)
					{
						WSspCheckOrderSaleCenterUnique_Result wSspCheckOrderSaleCenterUnique_Result = Enumerable.FirstOrDefault<WSspCheckOrderSaleCenterUnique_Result>((IEnumerable<WSspCheckOrderSaleCenterUnique_Result>)_dbII.WSspCheckOrderSaleCenterUnique(CS_0024_003C_003E8__locals0.vm.OrderID, CS_0024_003C_003E8__locals0.vm.ordSaleCenterId, lCID, CS_0024_003C_003E8__locals0.defLangID));
						if (wSspCheckOrderSaleCenterUnique_Result != null && wSspCheckOrderSaleCenterUnique_Result.OrderItemID != 0)
						{
							base.ViewBag.Error = string.Format("msgErrorNotSaveOrdByDifferentOrdISaleCenter".OrderMessages(), wSspCheckOrderSaleCenterUnique_Result.PrdName ?? "");
							return View(CS_0024_003C_003E8__locals0.vm);
						}
					}
				}
			}
			if (!CS_0024_003C_003E8__locals0.vm.ordDiscountPercent.HasValue)
			{
				CS_0024_003C_003E8__locals0.vm.ordDiscountPercent = default(decimal);
			}
			DateTime dateTime = default(DateTime);
			string text5 = "";
			try
			{
				if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ordTime))
				{
					CS_0024_003C_003E8__locals0.vm.ordTime = DateTime.Now.ToString("HH:mm:ss");
				}
				else
				{
					CS_0024_003C_003E8__locals0.vm.ordTime = CS_0024_003C_003E8__locals0.vm.ordTime.Trim();
				}
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ordDate))
				{
					text5 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.vm.ordDate.Replace("/", ""));
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text5 + " " + CS_0024_003C_003E8__locals0.vm.ordTime, new PersianCulture());
						CS_0024_003C_003E8__locals0.vm.ordDate = dateTime.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime = DateTime.Parse(text5 + " " + CS_0024_003C_003E8__locals0.vm.ordTime, new CultureInfo("ar-SA"));
						CS_0024_003C_003E8__locals0.vm.ordDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime = DateTime.Parse(text5 + " " + CS_0024_003C_003E8__locals0.vm.ordTime, new CultureInfo("en-US"));
						CS_0024_003C_003E8__locals0.vm.ordDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
					CS_0024_003C_003E8__locals0.vm.ordDateTime = dateTime;
					CS_0024_003C_003E8__locals0.vm.ordDay = DateTimeClass.DefineDayeOfWeekStartWith7(dateTime.DayOfWeek.ToString());
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				CS_0024_003C_003E8__locals0.vm.ordDate = (CS_0024_003C_003E8__locals0.vm.ordDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.ordDeliveryDate = (CS_0024_003C_003E8__locals0.vm.ordDeliveryDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDeliveryDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDate = (CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.ordDeadlineDatePersian = (CS_0024_003C_003E8__locals0.vm.ordDeadlineDate.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDeadlineDate.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.TspOrdCdcdPersian = (CS_0024_003C_003E8__locals0.vm.TspOrdCdcd.HasValue ? CS_0024_003C_003E8__locals0.vm.TspOrdCdcd.Value.ToString("yyyy/MM/dd") : "");
				base.ViewBag.Error = "WrongOrdDateTime".OrderMessages();
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			try
			{
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ordDeliveryDate))
				{
					text5 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.vm.ordDeliveryDate.Replace("/", ""));
					text5 = (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ordDeliveryTime) ? (text5 + " 00:00:00") : (text5 + " " + CS_0024_003C_003E8__locals0.vm.ordDeliveryTime.Trim()));
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text5, new PersianCulture());
						CS_0024_003C_003E8__locals0.vm.ordDeliveryDate = dateTime.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime = DateTime.Parse(text5, new CultureInfo("ar-SA"));
						CS_0024_003C_003E8__locals0.vm.ordDeliveryDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime = DateTime.Parse(text5, new CultureInfo("en-US"));
						CS_0024_003C_003E8__locals0.vm.ordDeliveryDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
					CS_0024_003C_003E8__locals0.vm.ordDeliveryDateTime = dateTime;
					CS_0024_003C_003E8__locals0.vm.ordDeliveryDay = DateTimeClass.DefineDayeOfWeekStartWith7(dateTime.DayOfWeek.ToString());
				}
				else
				{
					CS_0024_003C_003E8__locals0.vm.ordDeliveryDateTime = null;
					CS_0024_003C_003E8__locals0.vm.ordDeliveryDay = null;
				}
			}
			catch (Exception e2)
			{
				ErrorSignal.FromCurrentContext().Raise(e2);
				CS_0024_003C_003E8__locals0.vm.ordDate = (CS_0024_003C_003E8__locals0.vm.ordDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.ordDeliveryDate = (CS_0024_003C_003E8__locals0.vm.ordDeliveryDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDeliveryDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDate = (CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.ordDeadlineDatePersian = (CS_0024_003C_003E8__locals0.vm.ordDeadlineDate.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDeadlineDate.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.TspOrdCdcdPersian = (CS_0024_003C_003E8__locals0.vm.TspOrdCdcd.HasValue ? CS_0024_003C_003E8__locals0.vm.TspOrdCdcd.Value.ToString("yyyy/MM/dd") : "");
				base.ViewBag.Error = Messages.WrongOrdDeliveryDateTime;
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			try
			{
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDate))
				{
					text5 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDate.Replace("/", ""));
					text5 = (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ordDeliveryEndTime) ? (text5 + " 00:00:00") : (text5 + " " + CS_0024_003C_003E8__locals0.vm.ordDeliveryEndTime.Trim()));
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text5, new PersianCulture());
						CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDate = dateTime.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime = DateTime.Parse(text5, new CultureInfo("ar-SA"));
						CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime = DateTime.Parse(text5, new CultureInfo("en-US"));
						CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
					CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDateTime = dateTime;
					CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDay = DateTimeClass.DefineDayeOfWeekStartWith7(dateTime.DayOfWeek.ToString());
				}
				else
				{
					CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDateTime = null;
					CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDay = null;
				}
			}
			catch (Exception e3)
			{
				ErrorSignal.FromCurrentContext().Raise(e3);
				CS_0024_003C_003E8__locals0.vm.ordDate = (CS_0024_003C_003E8__locals0.vm.ordDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.ordDeliveryDate = (CS_0024_003C_003E8__locals0.vm.ordDeliveryDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDeliveryDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDate = (CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.ordDeadlineDatePersian = (CS_0024_003C_003E8__locals0.vm.ordDeadlineDate.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDeadlineDate.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.TspOrdCdcdPersian = (CS_0024_003C_003E8__locals0.vm.TspOrdCdcd.HasValue ? CS_0024_003C_003E8__locals0.vm.TspOrdCdcd.Value.ToString("yyyy/MM/dd") : "");
				base.ViewBag.Error = string.Format(Messages.ErrorInFormat, Labels.ordDeliveryEndDate);
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			if (CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDate != null)
			{
				CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDate = CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDate.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
			}
			try
			{
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ordDeadlineDatePersian))
				{
					text5 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.vm.ordDeadlineDatePersian.Replace("/", ""));
					text5 += " 00:00:00";
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text5, new PersianCulture());
						CS_0024_003C_003E8__locals0.vm.ordDeadlineDatePersian = dateTime.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime = DateTime.Parse(text5, new CultureInfo("ar-SA"));
						CS_0024_003C_003E8__locals0.vm.ordDeadlineDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime = DateTime.Parse(text5, new CultureInfo("en-US"));
						CS_0024_003C_003E8__locals0.vm.ordDeadlineDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
					CS_0024_003C_003E8__locals0.vm.ordDeadlineDate = dateTime;
				}
				else
				{
					if (UserLogin.IsUserAccess("frmOrderDataEntry", "actSetOrdDeadlineDateNotNull", UserLogin.CurrentUser))
					{
						base.ViewBag.Error = string.Format(Messages.msgErrorIsNotEntered, Labels.ordDeadlineDate);
						CS_0024_003C_003E8__locals0.vm.ordDate = (CS_0024_003C_003E8__locals0.vm.ordDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDateTime.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.vm.ordDeliveryDate = (CS_0024_003C_003E8__locals0.vm.ordDeliveryDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDeliveryDateTime.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDate = (CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDateTime.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.vm.ordDeadlineDatePersian = (CS_0024_003C_003E8__locals0.vm.ordDeadlineDate.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDeadlineDate.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.vm.TspOrdCdcdPersian = (CS_0024_003C_003E8__locals0.vm.TspOrdCdcd.HasValue ? CS_0024_003C_003E8__locals0.vm.TspOrdCdcd.Value.ToString("yyyy/MM/dd") : "");
						return View(CS_0024_003C_003E8__locals0.vm);
					}
					CS_0024_003C_003E8__locals0.vm.ordDeadlineDate = null;
				}
			}
			catch (Exception e4)
			{
				ErrorSignal.FromCurrentContext().Raise(e4);
				CS_0024_003C_003E8__locals0.vm.ordDate = (CS_0024_003C_003E8__locals0.vm.ordDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.ordDeliveryDate = (CS_0024_003C_003E8__locals0.vm.ordDeliveryDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDeliveryDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDate = (CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.ordDeadlineDatePersian = (CS_0024_003C_003E8__locals0.vm.ordDeadlineDate.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDeadlineDate.Value.ToString("yyyy/MM/dd") : "");
				base.ViewBag.Error = string.Format(Messages.ErrorInFormat, Labels.ordDeadlineDate);
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			if (CS_0024_003C_003E8__locals0.vm.ordDeadlineDatePersian != null)
			{
				CS_0024_003C_003E8__locals0.vm.ordDeadlineDatePersian = CS_0024_003C_003E8__locals0.vm.ordDeadlineDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
			}
			try
			{
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.TspOrdCdcdPersian))
				{
					text5 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.vm.TspOrdCdcdPersian.Replace("/", ""));
					text5 += " 00:00:00";
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text5, new PersianCulture());
						CS_0024_003C_003E8__locals0.vm.TspOrdCdcdPersian = dateTime.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime = DateTime.Parse(text5, new CultureInfo("ar-SA"));
						CS_0024_003C_003E8__locals0.vm.TspOrdCdcdPersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime = DateTime.Parse(text5, new CultureInfo("en-US"));
						CS_0024_003C_003E8__locals0.vm.TspOrdCdcdPersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
					CS_0024_003C_003E8__locals0.vm.TspOrdCdcd = dateTime;
				}
				else
				{
					CS_0024_003C_003E8__locals0.vm.TspOrdCdcd = null;
				}
			}
			catch (Exception e5)
			{
				ErrorSignal.FromCurrentContext().Raise(e5);
				CS_0024_003C_003E8__locals0.vm.ordDate = (CS_0024_003C_003E8__locals0.vm.ordDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.ordDeliveryDate = (CS_0024_003C_003E8__locals0.vm.ordDeliveryDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDeliveryDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDate = (CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.ordDeadlineDatePersian = (CS_0024_003C_003E8__locals0.vm.ordDeadlineDate.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDeadlineDate.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.TspOrdCdcdPersian = (CS_0024_003C_003E8__locals0.vm.TspOrdCdcd.HasValue ? CS_0024_003C_003E8__locals0.vm.TspOrdCdcd.Value.ToString("yyyy/MM/dd") : "");
				base.ViewBag.Error = string.Format(Messages.ErrorInFormat, Labels.ordTspOrdCdcd);
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			if (CS_0024_003C_003E8__locals0.vm.TspOrdCdcdPersian != null)
			{
				CS_0024_003C_003E8__locals0.vm.TspOrdCdcdPersian = CS_0024_003C_003E8__locals0.vm.TspOrdCdcdPersian.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
			}
			if (CS_0024_003C_003E8__locals0.vm.ordDate != null)
			{
				CS_0024_003C_003E8__locals0.vm.ordDate = CS_0024_003C_003E8__locals0.vm.ordDate.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
			}
			if (CS_0024_003C_003E8__locals0.vm.ordDeliveryDate != null)
			{
				CS_0024_003C_003E8__locals0.vm.ordDeliveryDate = CS_0024_003C_003E8__locals0.vm.ordDeliveryDate.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
			}
			if (CS_0024_003C_003E8__locals0.vm.ordImportDate != null)
			{
				CS_0024_003C_003E8__locals0.vm.ordImportDate = CS_0024_003C_003E8__locals0.vm.ordImportDate.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
			}
			if (CS_0024_003C_003E8__locals0.vm.ordVerifiedRegisterDatePersian != null)
			{
				CS_0024_003C_003E8__locals0.vm.ordVerifiedRegisterDatePersian = CS_0024_003C_003E8__locals0.vm.ordVerifiedRegisterDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
			}
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ordNumRef) && UserLogin.IsUserAccess("frmOrderDataEntry", "actNotDupNumRef", UserLogin.CurrentUser))
			{
				WSspCheckDuplicateOrderNumRef_Result wSspCheckDuplicateOrderNumRef_Result = Enumerable.FirstOrDefault<WSspCheckDuplicateOrderNumRef_Result>((IEnumerable<WSspCheckDuplicateOrderNumRef_Result>)_db.WSspCheckDuplicateOrderNumRef(CS_0024_003C_003E8__locals0.vm.ordNumRef, CS_0024_003C_003E8__locals0.vm.OrderID, CS_0024_003C_003E8__locals0.vm.OrderOprID, num3));
				if (wSspCheckDuplicateOrderNumRef_Result != null)
				{
					CS_0024_003C_003E8__locals0.vm.ordDate = (CS_0024_003C_003E8__locals0.vm.ordDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDateTime.Value.ToString("yyyy/MM/dd") : "");
					CS_0024_003C_003E8__locals0.vm.ordDeliveryDate = (CS_0024_003C_003E8__locals0.vm.ordDeliveryDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDeliveryDateTime.Value.ToString("yyyy/MM/dd") : "");
					CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDate = (CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDateTime.Value.ToString("yyyy/MM/dd") : "");
					CS_0024_003C_003E8__locals0.vm.ordDeadlineDatePersian = (CS_0024_003C_003E8__locals0.vm.ordDeadlineDate.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDeadlineDate.Value.ToString("yyyy/MM/dd") : "");
					CS_0024_003C_003E8__locals0.vm.TspOrdCdcdPersian = (CS_0024_003C_003E8__locals0.vm.TspOrdCdcd.HasValue ? CS_0024_003C_003E8__locals0.vm.TspOrdCdcd.Value.ToString("yyyy/MM/dd") : "");
					base.ViewBag.Error = string.Format(Messages.OrderNumRefIsRepeated, wSspCheckDuplicateOrderNumRef_Result.ordNumber.ToString());
					return View(CS_0024_003C_003E8__locals0.vm);
				}
			}
			if (!base.ModelState.IsValid)
			{
				base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
			else
			{
				_003C_003Ec__DisplayClass49_1 _003C_003Ec__DisplayClass49_ = new _003C_003Ec__DisplayClass49_1();
				_003C_003Ec__DisplayClass49_.model = new WSOrder();
				if (CS_0024_003C_003E8__locals0.vm.OrderID > 0)
				{
					DbSet<WSOrder> wSOrder2 = _dbTbl.WSOrder;
					ParameterExpression val = Expression.Parameter(typeof(WSOrder), "c");
					_003C_003Ec__DisplayClass49_.model = Queryable.FirstOrDefault<WSOrder>((IQueryable<WSOrder>)wSOrder2, Expression.Lambda<Func<WSOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass49_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				_003C_003Ec__DisplayClass49_.model.UserId = UserLogin.CurrentUser.UserId;
				DateTime now = DateTime.Now;
				_003C_003Ec__DisplayClass49_.model.RegisterDate = now;
				_003C_003Ec__DisplayClass49_.model.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				_003C_003Ec__DisplayClass49_.model.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
				_003C_003Ec__DisplayClass49_.model.AppType = Configuration.AppType;
				if (CS_0024_003C_003E8__locals0.vm.OrderID == 0)
				{
					_003C_003Ec__DisplayClass49_.model.FPId = Financial.Get().Id;
				}
				if (UserLogin.IsUserAccess("frmOrderDataEntry", "actSetSettlementTypeNotNull") && (!CS_0024_003C_003E8__locals0.vm.ordSettlementTypeId.HasValue || CS_0024_003C_003E8__locals0.vm.ordSettlementTypeId <= 0))
				{
					base.ViewBag.Error = Messages.msgErrorPaymentTypeIsNotEntered;
					CS_0024_003C_003E8__locals0.vm.ordDate = (CS_0024_003C_003E8__locals0.vm.ordDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDateTime.Value.ToString("yyyy/MM/dd") : "");
					CS_0024_003C_003E8__locals0.vm.ordDeliveryDate = (CS_0024_003C_003E8__locals0.vm.ordDeliveryDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDeliveryDateTime.Value.ToString("yyyy/MM/dd") : "");
					CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDate = (CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDateTime.Value.ToString("yyyy/MM/dd") : "");
					CS_0024_003C_003E8__locals0.vm.ordDeadlineDatePersian = (CS_0024_003C_003E8__locals0.vm.ordDeadlineDate.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDeadlineDate.Value.ToString("yyyy/MM/dd") : "");
					CS_0024_003C_003E8__locals0.vm.TspOrdCdcdPersian = (CS_0024_003C_003E8__locals0.vm.TspOrdCdcd.HasValue ? CS_0024_003C_003E8__locals0.vm.TspOrdCdcd.Value.ToString("yyyy/MM/dd") : "");
					return View(CS_0024_003C_003E8__locals0.vm);
				}
				if (CS_0024_003C_003E8__locals0.vm.OrderID > 0 && (_003C_003Ec__DisplayClass49_.model.OrderOprID != CS_0024_003C_003E8__locals0.vm.OrderOprID || _003C_003Ec__DisplayClass49_.model.ordDate != CS_0024_003C_003E8__locals0.vm.ordDate))
				{
					string arg = CS_0024_003C_003E8__locals0.vm.ordDateTime.GetValueOrDefault(now).ToString("yyyy-MM-dd", new CultureInfo("en-US"));
					long value = Enumerable.FirstOrDefault<long>(_dbI.Database.SqlQuery<long>($"Select dbo.WSfnReturnOrderDailyCounter({CS_0024_003C_003E8__locals0.vm.OrderOprID}, '{arg}')", Array.Empty<object>()));
					_003C_003Ec__DisplayClass49_.model.ordDailyCounter = value;
				}
				_003C_003Ec__DisplayClass49_.model.OrderOprID = CS_0024_003C_003E8__locals0.vm.OrderOprID;
				_003C_003Ec__DisplayClass49_.model.PreOrderId = CS_0024_003C_003E8__locals0.vm.PreOrderId;
				_003C_003Ec__DisplayClass49_.model.PreOrderVerifierId = CS_0024_003C_003E8__locals0.vm.PreOrderVerifierId;
				_003C_003Ec__DisplayClass49_.model.ordNumber = CS_0024_003C_003E8__locals0.vm.ordNumber;
				_003C_003Ec__DisplayClass49_.model.ordDate = CS_0024_003C_003E8__locals0.vm.ordDate;
				if (CS_0024_003C_003E8__locals0.vm.ordCompanyId != 0)
				{
					_003C_003Ec__DisplayClass49_.model.ordCompanyId = CS_0024_003C_003E8__locals0.vm.ordCompanyId;
				}
				if (CS_0024_003C_003E8__locals0.vm.ordCompanyPersonId.GetValueOrDefault() != 0)
				{
					_003C_003Ec__DisplayClass49_.model.ordCompanyPersonId = CS_0024_003C_003E8__locals0.vm.ordCompanyPersonId;
				}
				if (CS_0024_003C_003E8__locals0.vm.ordProjectId.GetValueOrDefault() != 0)
				{
					_003C_003Ec__DisplayClass49_.model.ordProjectId = CS_0024_003C_003E8__locals0.vm.ordProjectId;
				}
				_003C_003Ec__DisplayClass49_.model.ordItemCount = CS_0024_003C_003E8__locals0.vm.ordItemCount;
				_003C_003Ec__DisplayClass49_.model.ordItemsAmount = CS_0024_003C_003E8__locals0.vm.ordItemsAmount;
				_003C_003Ec__DisplayClass49_.model.ordInstallAmount = CS_0024_003C_003E8__locals0.vm.ordInstallAmount;
				_003C_003Ec__DisplayClass49_.model.ordSumAmount = CS_0024_003C_003E8__locals0.vm.ordSumAmount;
				_003C_003Ec__DisplayClass49_.model.ordTotalAmount = CS_0024_003C_003E8__locals0.vm.ordTotalAmount;
				_003C_003Ec__DisplayClass49_.model.ordIsVerified = CS_0024_003C_003E8__locals0.vm.ordIsVerified;
				_003C_003Ec__DisplayClass49_.model.ordVerifiedRegisterDate = CS_0024_003C_003E8__locals0.vm.ordVerifiedRegisterDate;
				_003C_003Ec__DisplayClass49_.model.ordVerifiedRegisterDatePersian = CS_0024_003C_003E8__locals0.vm.ordVerifiedRegisterDatePersian;
				_003C_003Ec__DisplayClass49_.model.ordStatusId = CS_0024_003C_003E8__locals0.vm.ordStatusId;
				_003C_003Ec__DisplayClass49_.model.ordIsFixed = CS_0024_003C_003E8__locals0.vm.ordIsFixed;
				_003C_003Ec__DisplayClass49_.model.ordGuarantyId = CS_0024_003C_003E8__locals0.vm.ordGuarantyId;
				_003C_003Ec__DisplayClass49_.model.ordDescriptionId = CS_0024_003C_003E8__locals0.vm.ordDescriptionId;
				if (!UserLogin.IsUserAccess("frmOrderDataEntry", "actCanNotChangePrintFormat", UserLogin.CurrentUser))
				{
					_003C_003Ec__DisplayClass49_.model.ordPrintFormatId = CS_0024_003C_003E8__locals0.vm.ordPrintFormatId;
				}
				else if (_003C_003Ec__DisplayClass49_.model.OrderID == 0)
				{
					_003C_003Ec__DisplayClass49_.model.ordPrintFormatId = CS_0024_003C_003E8__locals0.vm.ordPrintFormatId;
				}
				_003C_003Ec__DisplayClass49_.model.ordRLogoId = CS_0024_003C_003E8__locals0.vm.ordRLogoId;
				_003C_003Ec__DisplayClass49_.model.ordLLogoId = CS_0024_003C_003E8__locals0.vm.ordLLogoId;
				_003C_003Ec__DisplayClass49_.model.ordAccountNumberI = CS_0024_003C_003E8__locals0.vm.ordAccountNumberI;
				_003C_003Ec__DisplayClass49_.model.ordAccountShabaNumberI = CS_0024_003C_003E8__locals0.vm.ordAccountShabaNumberI;
				_003C_003Ec__DisplayClass49_.model.ordAccountNumberII = CS_0024_003C_003E8__locals0.vm.ordAccountNumberII;
				_003C_003Ec__DisplayClass49_.model.ordAccountShabaNumberII = CS_0024_003C_003E8__locals0.vm.ordAccountShabaNumberII;
				_003C_003Ec__DisplayClass49_.model.ordSignatureId = CS_0024_003C_003E8__locals0.vm.ordSignatureId;
				_003C_003Ec__DisplayClass49_.model.ordImportDate = CS_0024_003C_003E8__locals0.vm.ordImportDate;
				_003C_003Ec__DisplayClass49_.model.ordVerifierId = CS_0024_003C_003E8__locals0.vm.ordVerifierId;
				_003C_003Ec__DisplayClass49_.model.ordSettlementTypeId = CS_0024_003C_003E8__locals0.vm.ordSettlementTypeId;
				_003C_003Ec__DisplayClass49_.model.ordDay = CS_0024_003C_003E8__locals0.vm.ordDay;
				_003C_003Ec__DisplayClass49_.model.ordTime = CS_0024_003C_003E8__locals0.vm.ordTime;
				_003C_003Ec__DisplayClass49_.model.ordTransportation = CS_0024_003C_003E8__locals0.vm.ordTransportation;
				_003C_003Ec__DisplayClass49_.model.ordReferUserId = CS_0024_003C_003E8__locals0.vm.ordReferUserId;
				if (!UserLogin.IsUserAccess("frmOrderDataEntry", "actNoOrdDiscount", UserLogin.CurrentUser))
				{
					_003C_003Ec__DisplayClass49_.model.ordDiscount = CS_0024_003C_003E8__locals0.vm.ordDiscount;
					_003C_003Ec__DisplayClass49_.model.ordDiscountPercent = CS_0024_003C_003E8__locals0.vm.ordDiscountPercent;
				}
				if (!UserLogin.IsUserAccess("frmOrderDataEntry", "actNoOrdTax", UserLogin.CurrentUser))
				{
					_003C_003Ec__DisplayClass49_.model.ordTax = CS_0024_003C_003E8__locals0.vm.ordTax;
					_003C_003Ec__DisplayClass49_.model.ordTaxIndex = CS_0024_003C_003E8__locals0.vm.ordTaxIndex;
					_003C_003Ec__DisplayClass49_.model.ordCalculateTax = CS_0024_003C_003E8__locals0.vm.ordCalculateTax;
				}
				_003C_003Ec__DisplayClass49_.model.ordRound = CS_0024_003C_003E8__locals0.vm.ordRound;
				_003C_003Ec__DisplayClass49_.model.ordDateTime = CS_0024_003C_003E8__locals0.vm.ordDateTime;
				_003C_003Ec__DisplayClass49_.model.ordImportDateTime = CS_0024_003C_003E8__locals0.vm.ordImportDateTime;
				_003C_003Ec__DisplayClass49_.model.ordDeliveryDate = CS_0024_003C_003E8__locals0.vm.ordDeliveryDate;
				_003C_003Ec__DisplayClass49_.model.ordDeliveryDateTime = CS_0024_003C_003E8__locals0.vm.ordDeliveryDateTime;
				_003C_003Ec__DisplayClass49_.model.ordDeliveryTime = CS_0024_003C_003E8__locals0.vm.ordDeliveryTime;
				_003C_003Ec__DisplayClass49_.model.ordDeliveryEndDate = CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDate;
				_003C_003Ec__DisplayClass49_.model.ordDeliveryEndDateTime = CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDateTime;
				_003C_003Ec__DisplayClass49_.model.ordDeliveryEndTime = CS_0024_003C_003E8__locals0.vm.ordDeliveryEndTime;
				_003C_003Ec__DisplayClass49_.model.ordSerial = CS_0024_003C_003E8__locals0.vm.ordSerial;
				_003C_003Ec__DisplayClass49_.model.ordVerifierRequestId = CS_0024_003C_003E8__locals0.vm.ordVerifierRequestId;
				int result3 = 0;
				int.TryParse(_003C_003Ec__DisplayClass49_.model.ordCurrencyUnitId.ToString(), out result3);
				_003C_003Ec__DisplayClass49_.model.ordDeliveryEndDay = CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDay;
				_003C_003Ec__DisplayClass49_.model.ordDeliveryDay = CS_0024_003C_003E8__locals0.vm.ordDeliveryDay;
				_003C_003Ec__DisplayClass49_.model.ordCurrencyUnitId = CS_0024_003C_003E8__locals0.vm.ordCurrencyUnitId;
				_003C_003Ec__DisplayClass49_.model.ordDeliveryTermId = CS_0024_003C_003E8__locals0.vm.ordDeliveryTermId;
				_003C_003Ec__DisplayClass49_.model.ordCurrencyUnitIdI = CS_0024_003C_003E8__locals0.vm.ordCurrencyUnitIdI;
				_003C_003Ec__DisplayClass49_.model.ordCurrencyUnitIRate = CS_0024_003C_003E8__locals0.vm.ordCurrencyUnitIRate;
				_003C_003Ec__DisplayClass49_.model.ordDeadlineDate = CS_0024_003C_003E8__locals0.vm.ordDeadlineDate;
				_003C_003Ec__DisplayClass49_.model.ordDeadlineDatePersian = CS_0024_003C_003E8__locals0.vm.ordDeadlineDatePersian;
				_003C_003Ec__DisplayClass49_.model.TspOrdCdcn = CS_0024_003C_003E8__locals0.vm.TspOrdCdcn;
				_003C_003Ec__DisplayClass49_.model.TspOrdCdcdPersian = CS_0024_003C_003E8__locals0.vm.TspOrdCdcdPersian;
				_003C_003Ec__DisplayClass49_.model.TspOrdCdcd = CS_0024_003C_003E8__locals0.vm.TspOrdCdcd;
				_003C_003Ec__DisplayClass49_.model.ordDefaultSettingId = CS_0024_003C_003E8__locals0.vm.ordDefaultSettingId;
				_003C_003Ec__DisplayClass49_.model.ordSellerId = CS_0024_003C_003E8__locals0.vm.ordSellerId;
				_003C_003Ec__DisplayClass49_.model.ordVerificationWorkFlowId = CS_0024_003C_003E8__locals0.vm.ordVerificationWorkFlowId;
				_003C_003Ec__DisplayClass49_.model.ordCompanyPersonIds = CS_0024_003C_003E8__locals0.vm.ordCompanyPersonIds;
				if (!UserLogin.IsUserAccess("frmOrderDataEntry", "actCanNotChangeOrdDefWH", UserLogin.CurrentUser))
				{
					_003C_003Ec__DisplayClass49_.model.ordDefWHId = CS_0024_003C_003E8__locals0.vm.ordDefWHId;
				}
				else if (_003C_003Ec__DisplayClass49_.model.OrderID == 0)
				{
					_003C_003Ec__DisplayClass49_.model.ordDefWHId = CS_0024_003C_003E8__locals0.vm.ordDefWHId;
				}
				if (!UserLogin.IsUserAccess("frmOrderDataEntry", "actCanNotChangeOrdDefPrdPriceGroup", UserLogin.CurrentUser))
				{
					_003C_003Ec__DisplayClass49_.model.ordDefPrdPriceGroupId = CS_0024_003C_003E8__locals0.vm.ordDefPrdPriceGroupId;
				}
				else if (_003C_003Ec__DisplayClass49_.model.OrderID == 0)
				{
					_003C_003Ec__DisplayClass49_.model.ordDefPrdPriceGroupId = CS_0024_003C_003E8__locals0.vm.ordDefPrdPriceGroupId;
				}
				if (!UserLogin.IsUserAccess("frmOrderDataEntry", "actCanNotChangeEmailUserInfo", UserLogin.CurrentUser))
				{
					_003C_003Ec__DisplayClass49_.model.ordEmailUsersInfoId = CS_0024_003C_003E8__locals0.vm.ordEmailUsersInfoId;
				}
				else if (_003C_003Ec__DisplayClass49_.model.OrderID == 0)
				{
					_003C_003Ec__DisplayClass49_.model.ordEmailUsersInfoId = CS_0024_003C_003E8__locals0.vm.ordEmailUsersInfoId;
				}
				if (!UserLogin.IsUserAccess("frmOrderDataEntry", "actCanNotChangeEmailUserDefSetting", UserLogin.CurrentUser))
				{
					_003C_003Ec__DisplayClass49_.model.ordEmailUserDefaultSettingId = CS_0024_003C_003E8__locals0.vm.ordEmailUserDefaultSettingId;
				}
				else if (_003C_003Ec__DisplayClass49_.model.OrderID == 0)
				{
					_003C_003Ec__DisplayClass49_.model.ordEmailUserDefaultSettingId = CS_0024_003C_003E8__locals0.vm.ordEmailUserDefaultSettingId;
				}
				if (!UserLogin.IsUserAccess("frmOrderDataEntry", "actCanNotChangeOrdSaleCenter", UserLogin.CurrentUser) || _003C_003Ec__DisplayClass49_.model.OrderID == 0)
				{
					_003C_003Ec__DisplayClass49_.model.ordSaleCenterId = CS_0024_003C_003E8__locals0.vm.ordSaleCenterId;
				}
				if (!UserLogin.IsUserAccess("frmOrderDataEntry", "actCanNotChangeOrdDefPayType", UserLogin.CurrentUser))
				{
					_003C_003Ec__DisplayClass49_.model.ordDefPayTypeId = CS_0024_003C_003E8__locals0.vm.ordDefPayTypeId;
				}
				else if (_003C_003Ec__DisplayClass49_.model.OrderID == 0)
				{
					_003C_003Ec__DisplayClass49_.model.ordDefPayTypeId = CS_0024_003C_003E8__locals0.vm.ordDefPayTypeId;
				}
				_003C_003Ec__DisplayClass49_.model.ordTspSettingId = CS_0024_003C_003E8__locals0.vm.ordTspSettingId;
				_003C_003Ec__DisplayClass49_.model.TspOrdIrtaxid = CS_0024_003C_003E8__locals0.vm.TspOrdIrtaxid;
				_003C_003Ec__DisplayClass49_.model.TspOrdFt = CS_0024_003C_003E8__locals0.vm.TspOrdFt;
				_003C_003Ec__DisplayClass49_.model.TspOrdBillid = CS_0024_003C_003E8__locals0.vm.TspOrdBillid;
				if (!UserLogin.IsUserAccess("frmOrderDataEntry", "actCanNotChangeTspOrdSetm", UserLogin.CurrentUser))
				{
					_003C_003Ec__DisplayClass49_.model.TspOrdSetm = CS_0024_003C_003E8__locals0.vm.TspOrdSetm;
				}
				_003C_003Ec__DisplayClass49_.model.TspOrdTax17 = CS_0024_003C_003E8__locals0.vm.TspOrdTax17;
				_003C_003Ec__DisplayClass49_.model.TspOrdInsp = CS_0024_003C_003E8__locals0.vm.TspOrdInsp;
				_003C_003Ec__DisplayClass49_.model.TspOrdCdcn = CS_0024_003C_003E8__locals0.vm.TspOrdCdcn;
				_003C_003Ec__DisplayClass49_.model.TspOrdCdcdPersian = CS_0024_003C_003E8__locals0.vm.TspOrdCdcdPersian;
				_003C_003Ec__DisplayClass49_.model.TspOrdCdcd = CS_0024_003C_003E8__locals0.vm.TspOrdCdcd;
				_003C_003Ec__DisplayClass49_.model.TspOrdSbc = CS_0024_003C_003E8__locals0.vm.TspOrdSbc;
				_003C_003Ec__DisplayClass49_.model.TspOrdScln = CS_0024_003C_003E8__locals0.vm.TspOrdScln;
				_003C_003Ec__DisplayClass49_.model.TspOrdScc = CS_0024_003C_003E8__locals0.vm.TspOrdScc;
				_003C_003Ec__DisplayClass49_.model.TspOrdCrn = CS_0024_003C_003E8__locals0.vm.TspOrdCrn;
				_003C_003Ec__DisplayClass49_.model.ordSaleAreaId = CS_0024_003C_003E8__locals0.vm.ordSaleAreaId;
				if (!UserLogin.IsUserAccess("frmOrderDataEntry", "actCanNotChangeOrdTitle", UserLogin.CurrentUser) || _003C_003Ec__DisplayClass49_.model.OrderID == 0)
				{
					_003C_003Ec__DisplayClass49_.model.ordTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				}
				_003C_003Ec__DisplayClass49_.model.ordSubject = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass49_.model.ordTotalAmountStr = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass49_.model.ordSpecialWord = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				if (!UserLogin.IsUserAccess("frmOrderDataEntry", "actCanNotChangeOrdDescriptionI", UserLogin.CurrentUser) || _003C_003Ec__DisplayClass49_.model.OrderID == 0)
				{
					_003C_003Ec__DisplayClass49_.model.ordDescriptionI = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				}
				if (!UserLogin.IsUserAccess("frmOrderDataEntry", "actCanNotChangeOrdDescriptionII", UserLogin.CurrentUser) || _003C_003Ec__DisplayClass49_.model.OrderID == 0)
				{
					_003C_003Ec__DisplayClass49_.model.ordDescriptionII = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				}
				_003C_003Ec__DisplayClass49_.model.ordSigningI = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass49_.model.ordSigningII = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass49_.model.ordSigningIII = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass49_.model.ordNote = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass49_.model.ordDiscountTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass49_.model.ordcmpTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass49_.model.ordItemCount = ((_003C_003Ec__DisplayClass49_.model.ordItemCount == 0) ? null : _003C_003Ec__DisplayClass49_.model.ordItemCount);
				WSOrder model = _003C_003Ec__DisplayClass49_.model;
				decimal? ordItemsAmount = _003C_003Ec__DisplayClass49_.model.ordItemsAmount;
				model.ordItemsAmount = (((ordItemsAmount.GetValueOrDefault() == default(decimal)) & ordItemsAmount.HasValue) ? null : _003C_003Ec__DisplayClass49_.model.ordItemsAmount);
				WSOrder model2 = _003C_003Ec__DisplayClass49_.model;
				ordItemsAmount = _003C_003Ec__DisplayClass49_.model.ordSumAmount;
				model2.ordSumAmount = (((ordItemsAmount.GetValueOrDefault() == default(decimal)) & ordItemsAmount.HasValue) ? null : _003C_003Ec__DisplayClass49_.model.ordSumAmount);
				WSOrder model3 = _003C_003Ec__DisplayClass49_.model;
				ordItemsAmount = _003C_003Ec__DisplayClass49_.model.ordTax;
				model3.ordTax = (((ordItemsAmount.GetValueOrDefault() == default(decimal)) & ordItemsAmount.HasValue) ? null : _003C_003Ec__DisplayClass49_.model.ordTax);
				ordItemsAmount = _003C_003Ec__DisplayClass49_.model.ordTotalAmount;
				if ((ordItemsAmount.GetValueOrDefault() == default(decimal)) & ordItemsAmount.HasValue)
				{
					_003C_003Ec__DisplayClass49_.model.ordTotalAmount = null;
					_003C_003Ec__DisplayClass49_.model.ordTotalAmountStr = null;
				}
				WSOrder model4 = _003C_003Ec__DisplayClass49_.model;
				ordItemsAmount = _003C_003Ec__DisplayClass49_.model.ordDiscountPercent;
				model4.ordDiscountPercent = (((ordItemsAmount.GetValueOrDefault() == default(decimal)) & ordItemsAmount.HasValue) ? null : _003C_003Ec__DisplayClass49_.model.ordDiscountPercent);
				_003C_003Ec__DisplayClass49_.model.ordTransportation = _003C_003Ec__DisplayClass49_.model.ordTransportation.GetValueOrDefault();
				_003C_003Ec__DisplayClass49_.model.ordRound = _003C_003Ec__DisplayClass49_.model.ordRound.GetValueOrDefault();
				_003C_003Ec__DisplayClass49_.model.ordDiscount = _003C_003Ec__DisplayClass49_.model.ordDiscount.GetValueOrDefault();
				WSOrder model5 = _003C_003Ec__DisplayClass49_.model;
				ordItemsAmount = _003C_003Ec__DisplayClass49_.model.ordInstallAmount;
				model5.ordInstallAmount = (((ordItemsAmount.GetValueOrDefault() == default(decimal)) & ordItemsAmount.HasValue) ? null : _003C_003Ec__DisplayClass49_.model.ordInstallAmount);
				_003C_003Ec__DisplayClass49_.model.ordAccountNumberII = ((_003C_003Ec__DisplayClass49_.model.ordAccountNumberII == "") ? null : _003C_003Ec__DisplayClass49_.model.ordAccountNumberII);
				_003C_003Ec__DisplayClass49_.model.ordAccountShabaNumberII = ((_003C_003Ec__DisplayClass49_.model.ordAccountShabaNumberII == "") ? null : _003C_003Ec__DisplayClass49_.model.ordAccountShabaNumberII);
				_003C_003Ec__DisplayClass49_.model.ordGroupId = CS_0024_003C_003E8__locals0.vm.ordGroupId;
				_003C_003Ec__DisplayClass49_.model.ordRefOrderId = CS_0024_003C_003E8__locals0.vm.ordRefOrderId;
				if (_003C_003Ec__DisplayClass49_.model.OrderID > 0)
				{
					if (UserLogin.IsUserAccess("frmOrderDataEntry", "actCanChangeNumRef", UserLogin.CurrentUser))
					{
						_003C_003Ec__DisplayClass49_.model.ordNumRef = CS_0024_003C_003E8__locals0.vm.ordNumRef;
					}
					int result4 = 0;
					int.TryParse(_003C_003Ec__DisplayClass49_.model.OrderOprID.ToString(), out result4);
					long result5 = 0L;
					long.TryParse(_003C_003Ec__DisplayClass49_.model.ordNumber.ToString(), out result5);
					if (CheckDuplicateOrderNumber(result5, _003C_003Ec__DisplayClass49_.model.OrderID, result4, _003C_003Ec__DisplayClass49_.model.ordCId) > 0)
					{
						CS_0024_003C_003E8__locals0.vm.ordDate = (CS_0024_003C_003E8__locals0.vm.ordDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDateTime.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.vm.ordDeliveryDate = (CS_0024_003C_003E8__locals0.vm.ordDeliveryDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDeliveryDateTime.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDate = (CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDateTime.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.vm.ordDeadlineDatePersian = (CS_0024_003C_003E8__locals0.vm.ordDeadlineDate.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDeadlineDate.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.vm.TspOrdCdcdPersian = (CS_0024_003C_003E8__locals0.vm.TspOrdCdcd.HasValue ? CS_0024_003C_003E8__locals0.vm.TspOrdCdcd.Value.ToString("yyyy/MM/dd") : "");
						base.ViewBag.Error = "OrderNumberIsRepeated".OrderMessages();
						return View(CS_0024_003C_003E8__locals0.vm);
					}
					_dbTbl.Entry(_003C_003Ec__DisplayClass49_.model).State = EntityState.Modified;
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					if (!Order.CalcAndSetOrderAmounts(_003C_003Ec__DisplayClass49_.model))
					{
						base.ViewBag.Error = "CalcAndSetOrderErrorMessage".OrderMessages();
					}
					else
					{
						using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								_003C_003Ec__DisplayClass49_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass49_2();
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass49_;
								CS_0024_003C_003E8__locals1.lang = enumerator.Current;
								DbSet<WSOrder_Lang> wSOrder_Lang = _dbTbl.WSOrder_Lang;
								ParameterExpression val = Expression.Parameter(typeof(WSOrder_Lang), "c");
								WSOrder_Lang wSOrder_Lang2 = Queryable.FirstOrDefault<WSOrder_Lang>((IQueryable<WSOrder_Lang>)wSOrder_Lang, Expression.Lambda<Func<WSOrder_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass49_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass49_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (wSOrder_Lang2 != null)
								{
									if (!UserLogin.IsUserAccess("frmOrderDataEntry", "actCanNotChangeOrdTitle", UserLogin.CurrentUser) || CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.OrderID == 0)
									{
										wSOrder_Lang2.ordTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									}
									wSOrder_Lang2.ordSubject = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									wSOrder_Lang2.ordTotalAmountStr = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									wSOrder_Lang2.ordSpecialWord = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									if (!UserLogin.IsUserAccess("frmOrderDataEntry", "actCanNotChangeOrdDescriptionI", UserLogin.CurrentUser) || CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.OrderID == 0)
									{
										wSOrder_Lang2.ordDescriptionI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									}
									if (!UserLogin.IsUserAccess("frmOrderDataEntry", "actCanNotChangeOrdDescriptionII", UserLogin.CurrentUser) || CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.OrderID == 0)
									{
										wSOrder_Lang2.ordDescriptionII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									}
									wSOrder_Lang2.ordSigningI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									wSOrder_Lang2.ordSigningII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									wSOrder_Lang2.ordSigningIII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									wSOrder_Lang2.ordNote = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									wSOrder_Lang2.ordDiscountTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									wSOrder_Lang2.ordcmpTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									_dbTbl.Entry(wSOrder_Lang2).State = EntityState.Modified;
									_dbTbl.SaveChanges();
									continue;
								}
								wSOrder_Lang2 = new WSOrder_Lang();
								wSOrder_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
								wSOrder_Lang2.OrderID = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.OrderID;
								if (!UserLogin.IsUserAccess("frmOrderDataEntry", "actCanNotChangeOrdTitle", UserLogin.CurrentUser) || CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.OrderID == 0)
								{
									wSOrder_Lang2.ordTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								}
								wSOrder_Lang2.ordSubject = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSOrder_Lang2.ordTotalAmountStr = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSOrder_Lang2.ordSpecialWord = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								if (!UserLogin.IsUserAccess("frmOrderDataEntry", "actCanNotChangeOrdDescriptionI", UserLogin.CurrentUser) || CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.OrderID == 0)
								{
									wSOrder_Lang2.ordDescriptionI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								}
								if (!UserLogin.IsUserAccess("frmOrderDataEntry", "actCanNotChangeOrdDescriptionII", UserLogin.CurrentUser) || CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.OrderID == 0)
								{
									wSOrder_Lang2.ordDescriptionII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								}
								wSOrder_Lang2.ordSigningI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSOrder_Lang2.ordSigningII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSOrder_Lang2.ordSigningIII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSOrder_Lang2.ordNote = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSOrder_Lang2.ordDiscountTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSOrder_Lang2.ordcmpTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.WSOrder_Lang.Add(wSOrder_Lang2);
								_dbTbl.SaveChanges();
							}
						}
						if (result3 != 0)
						{
							int result6 = 0;
							int.TryParse(_003C_003Ec__DisplayClass49_.model.ordCurrencyUnitId.ToString(), out result6);
							if (result3 != result6 && result6 != 0)
							{
								_dbI.WSspUpdateOrderItemCurrencyUnitId(_003C_003Ec__DisplayClass49_.model.OrderID, result6, UserLogin.CurrentUser.UserId, short.Parse(now.ToString("MM", new PersianCulture())), now, now.ToString("yyyyMMdd", new PersianCulture()), Configuration.AppType);
							}
						}
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					}
				}
				else
				{
					DateTime now2 = DateTime.Now;
					_003C_003Ec__DisplayClass49_.model.ordFirstRegisterUserId = CS_0024_003C_003E8__locals0.vm.ordFirstRegisterUserId;
					_003C_003Ec__DisplayClass49_.model.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
					_003C_003Ec__DisplayClass49_.model.FirstRegisterDate = now2;
					_003C_003Ec__DisplayClass49_.model.FirstRegisterDatePersian = now2.ToString("yyyyMMdd", new PersianCulture());
					_003C_003Ec__DisplayClass49_.model.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
					_003C_003Ec__DisplayClass49_.model.GUId = System.Guid.NewGuid();
					string arg2 = _003C_003Ec__DisplayClass49_.model.ordDateTime.GetValueOrDefault(now2).ToString("yyyy-MM-dd", new CultureInfo("en-US"));
					long num4 = 0L;
					bool flag = false;
					int num5 = 0;
					while (!flag)
					{
						num4 = Enumerable.FirstOrDefault<long>(_dbI.Database.SqlQuery<long>($"Select dbo.WSfnReturnOrderDailyCounter({_003C_003Ec__DisplayClass49_.model.OrderOprID}, '{arg2}')", Array.Empty<object>()));
						_003C_003Ec__DisplayClass49_.model.ordDailyCounter = num4;
						num2 = _003C_003Ec__DisplayClass49_.model.ordDailyCounter.GetValueOrDefault();
						flag = ReservedNumber.AddNumber(sysPartId, num2);
						num5++;
						if (num5 > 10)
						{
							break;
						}
					}
					long num6 = 0L;
					flag = false;
					num5 = 0;
					while (!flag)
					{
						num6 = Enumerable.FirstOrDefault<long>(_db.Database.SqlQuery<long>($"Select dbo.WSfnReturnOrderNumber({Financial.Get().Id}, {_003C_003Ec__DisplayClass49_.model.OrderOprID},{num3.GetValueOrDefault()})", Array.Empty<object>()));
						_003C_003Ec__DisplayClass49_.model.ordNumber = num6;
						num = _003C_003Ec__DisplayClass49_.model.ordNumber;
						flag = ReservedNumber.AddNumber(sysPartId, num);
						num5++;
						if (num5 > 10)
						{
							break;
						}
					}
					_003C_003Ec__DisplayClass49_.model.ordVerifiedRegisterDate = null;
					_003C_003Ec__DisplayClass49_.model.ordVerifiedRegisterDatePersian = null;
					long result7 = 0L;
					long.TryParse(_003C_003Ec__DisplayClass49_.model.ordNumber.ToString(), out result7);
					int result8 = 0;
					int.TryParse(_003C_003Ec__DisplayClass49_.model.OrderOprID.ToString(), out result8);
					if (CheckDuplicateOrderNumber(result7, 0, result8, num3) > 0)
					{
						CS_0024_003C_003E8__locals0.vm.ordDate = (CS_0024_003C_003E8__locals0.vm.ordDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDateTime.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.vm.ordDeliveryDate = (CS_0024_003C_003E8__locals0.vm.ordDeliveryDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDeliveryDateTime.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDate = (CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDateTime.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.vm.ordDeadlineDatePersian = (CS_0024_003C_003E8__locals0.vm.ordDeadlineDate.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDeadlineDate.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.vm.TspOrdCdcdPersian = (CS_0024_003C_003E8__locals0.vm.TspOrdCdcd.HasValue ? CS_0024_003C_003E8__locals0.vm.TspOrdCdcd.Value.ToString("yyyy/MM/dd") : "");
						base.ViewBag.Error = "OrderNumberIsRepeated".OrderMessages();
						ReservedNumber.UpdateNumber(sysPartId, num2);
						ReservedNumber.UpdateNumber(sysPartId, num);
						if (!string.IsNullOrWhiteSpace(text4))
						{
							ReservedNumber.UpdateNumber(sysPartId, 0, text4);
						}
						return View(CS_0024_003C_003E8__locals0.vm);
					}
					if (UserLogin.IsUserAccess("frmOrderDataEntry", "actAutoCalcNumRef", UserLogin.CurrentUser))
					{
						flag = false;
						num5 = 0;
						while (!flag)
						{
							string ordNumRef = Enumerable.FirstOrDefault<string>((IEnumerable<string>)_db.WSspReturnOrderNumRef(_003C_003Ec__DisplayClass49_.model.ordCompanyId, _003C_003Ec__DisplayClass49_.model.ordProjectId, _003C_003Ec__DisplayClass49_.model.ordReferUserId, _003C_003Ec__DisplayClass49_.model.ordNumber, lCID, CS_0024_003C_003E8__locals0.defLangID, _003C_003Ec__DisplayClass49_.model.ordDailyCounter, num3));
							_003C_003Ec__DisplayClass49_.model.ordNumRef = ordNumRef;
							text4 = _003C_003Ec__DisplayClass49_.model.ordNumRef;
							flag = string.IsNullOrWhiteSpace(text4) || !UserLogin.IsUserAccess("frmOrderDataEntry", "actNotDupNumRef", UserLogin.CurrentUser) || ReservedNumber.AddNumber(sysPartId, 0, text4);
							num5++;
							if (num5 > 10)
							{
								break;
							}
						}
					}
					else
					{
						_003C_003Ec__DisplayClass49_.model.ordNumRef = CS_0024_003C_003E8__locals0.vm.ordNumRef;
					}
					if (!string.IsNullOrEmpty(_003C_003Ec__DisplayClass49_.model.ordNumRef) && UserLogin.IsUserAccess("frmOrderDataEntry", "actNotDupNumRef", UserLogin.CurrentUser))
					{
						WSspCheckDuplicateOrderNumRef_Result wSspCheckDuplicateOrderNumRef_Result2 = Enumerable.FirstOrDefault<WSspCheckDuplicateOrderNumRef_Result>((IEnumerable<WSspCheckDuplicateOrderNumRef_Result>)_db.WSspCheckDuplicateOrderNumRef(_003C_003Ec__DisplayClass49_.model.ordNumRef, _003C_003Ec__DisplayClass49_.model.OrderID, _003C_003Ec__DisplayClass49_.model.OrderOprID, num3));
						if (wSspCheckDuplicateOrderNumRef_Result2 != null)
						{
							base.ViewBag.Error = string.Format(Messages.OrderNumRefIsRepeated, wSspCheckDuplicateOrderNumRef_Result2.ordNumber.ToString());
							CS_0024_003C_003E8__locals0.vm.ordDate = (CS_0024_003C_003E8__locals0.vm.ordDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDateTime.Value.ToString("yyyy/MM/dd") : "");
							CS_0024_003C_003E8__locals0.vm.ordDeliveryDate = (CS_0024_003C_003E8__locals0.vm.ordDeliveryDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDeliveryDateTime.Value.ToString("yyyy/MM/dd") : "");
							CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDate = (CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDateTime.Value.ToString("yyyy/MM/dd") : "");
							CS_0024_003C_003E8__locals0.vm.ordDeadlineDatePersian = (CS_0024_003C_003E8__locals0.vm.ordDeadlineDate.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDeadlineDate.Value.ToString("yyyy/MM/dd") : "");
							CS_0024_003C_003E8__locals0.vm.TspOrdCdcdPersian = (CS_0024_003C_003E8__locals0.vm.TspOrdCdcd.HasValue ? CS_0024_003C_003E8__locals0.vm.TspOrdCdcd.Value.ToString("yyyy/MM/dd") : "");
							ReservedNumber.UpdateNumber(sysPartId, num2);
							ReservedNumber.UpdateNumber(sysPartId, num);
							if (!string.IsNullOrWhiteSpace(text4))
							{
								ReservedNumber.UpdateNumber(sysPartId, 0, text4);
							}
							return View(CS_0024_003C_003E8__locals0.vm);
						}
					}
					_003C_003Ec__DisplayClass49_.model.ordCId = num3;
					_dbTbl.WSOrder.Add(_003C_003Ec__DisplayClass49_.model);
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					CS_0024_003C_003E8__locals0.vm.OrderID = _003C_003Ec__DisplayClass49_.model.OrderID;
					num2 = (ReservedNumber.RemoveNumber(sysPartId, num2) ? 0 : num2);
					num = (ReservedNumber.RemoveNumber(sysPartId, num) ? 0 : num);
					if (!string.IsNullOrWhiteSpace(text4))
					{
						text4 = (ReservedNumber.RemoveNumber(sysPartId, 0, text4) ? "" : text4);
					}
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
					{
						WSOrder_Lang wSOrder_Lang3 = new WSOrder_Lang();
						wSOrder_Lang3.LanguageID = lang.LanguageID;
						wSOrder_Lang3.OrderID = _003C_003Ec__DisplayClass49_.model.OrderID;
						wSOrder_Lang3.ordTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSOrder_Lang3.ordSubject = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSOrder_Lang3.ordTotalAmountStr = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSOrder_Lang3.ordSpecialWord = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSOrder_Lang3.ordDescriptionI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSOrder_Lang3.ordDescriptionII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSOrder_Lang3.ordSigningI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSOrder_Lang3.ordSigningII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSOrder_Lang3.ordSigningIII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSOrder_Lang3.ordNote = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSOrder_Lang3.ordDiscountTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSOrder_Lang3.ordcmpTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						_dbTbl.WSOrder_Lang.Add(wSOrder_Lang3);
						_dbTbl.SaveChanges();
					}
					if (_003C_003Ec__DisplayClass49_.model.OrderID != 0)
					{
						_dbII.WSspCalcAndUpdateOrderAmountsCurrency(_003C_003Ec__DisplayClass49_.model.OrderID, lCID, CS_0024_003C_003E8__locals0.defLangID);
					}
					if (_003C_003Ec__DisplayClass49_.model.OrderID != 0)
					{
						Order.CalcOrderCancelledScores(_003C_003Ec__DisplayClass49_.model.OrderID);
					}
					base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
				}
			}
		}
		catch (DbEntityValidationException e6)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e6);
			base.ViewBag.Error = Messages.frmErrorMessage;
		}
		catch (Exception e7)
		{
			ErrorSignal.FromCurrentContext().Raise(e7);
			base.ViewBag.Error = Messages.frmErrorMessage;
		}
		CS_0024_003C_003E8__locals0.vm.ordDate = (CS_0024_003C_003E8__locals0.vm.ordDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDateTime.Value.ToString("yyyy/MM/dd") : "");
		CS_0024_003C_003E8__locals0.vm.ordDeliveryDate = (CS_0024_003C_003E8__locals0.vm.ordDeliveryDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDeliveryDateTime.Value.ToString("yyyy/MM/dd") : "");
		CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDate = (CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDeliveryEndDateTime.Value.ToString("yyyy/MM/dd") : "");
		CS_0024_003C_003E8__locals0.vm.ordDeadlineDatePersian = (CS_0024_003C_003E8__locals0.vm.ordDeadlineDate.HasValue ? CS_0024_003C_003E8__locals0.vm.ordDeadlineDate.Value.ToString("yyyy/MM/dd") : "");
		CS_0024_003C_003E8__locals0.vm.TspOrdCdcdPersian = (CS_0024_003C_003E8__locals0.vm.TspOrdCdcd.HasValue ? CS_0024_003C_003E8__locals0.vm.TspOrdCdcd.Value.ToString("yyyy/MM/dd") : "");
		if (num2 != 0L)
		{
			ReservedNumber.RemoveNumber(sysPartId, num2);
		}
		if (num != 0L)
		{
			ReservedNumber.RemoveNumber(sysPartId, num);
		}
		if (!string.IsNullOrWhiteSpace(text4))
		{
			ReservedNumber.RemoveNumber(sysPartId, 0, text4);
		}
		return View(CS_0024_003C_003E8__locals0.vm);
	}

	[AjaxOnly]
	public string GetOrderDailyCounter(int orderOprId, string ordDate)
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
			DateTime dateTime = DateTime.Now;
			string text = "";
			try
			{
				if (!string.IsNullOrWhiteSpace(ordDate))
				{
					text = PersianDate.GetFormatetdDate(ordDate.Replace("/", ""));
					dateTime = lCID switch
					{
						1065 => DateTime.Parse(text + " 00:00:00", new PersianCulture()), 
						1025 => DateTime.Parse(text + " 00:00:00", new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(text + " 00:00:00", new CultureInfo("en-US")), 
					};
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			string arg = dateTime.ToString("yyyy-MM-dd", new CultureInfo("en-US"));
			result = Enumerable.FirstOrDefault<long>(_dbI.Database.SqlQuery<long>($"Select dbo.WSfnReturnOrderDailyCounter({orderOprId}, '{arg}')", Array.Empty<object>())).ToString();
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return result;
	}

	[AjaxOnly]
	public string GetOrderNumber(int orderOprId, int? cId = null)
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
			result = Enumerable.FirstOrDefault<long>(_db.Database.SqlQuery<long>($"Select dbo.WSfnReturnOrderNumber({Financial.Get().Id}, {orderOprId},{cId.GetValueOrDefault()})", Array.Empty<object>())).ToString();
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
	public string GetOrderSerialNumber(int orderOprId)
	{
		string result = "";
		try
		{
			result = Enumerable.FirstOrDefault<int>(_db.Database.SqlQuery<int>($"Select dbo.WSfnReturnOrderSerialNumber({Financial.Get().Id}, {orderOprId})", Array.Empty<object>())).ToString();
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
	public long CheckDuplicateOrderNumber(long orderNumber, int orderId, int orderOprId, int? cId = null)
	{
		long result = 0L;
		try
		{
			int? num = null;
			if (UserLogin.CurrentUser != null)
			{
				num = UserLogin.CurrentUser.UserLastCId;
			}
			if (cId.GetValueOrDefault() == 0)
			{
				cId = num;
			}
			long? num2 = Enumerable.FirstOrDefault<long?>((IEnumerable<long?>)Enumerable.ToList<long?>((IEnumerable<long?>)_db.WSfnCheckDuplicateOrderNumber(orderNumber, orderId, Financial.Get().Id, orderOprId, cId)));
			if (num2.HasValue)
			{
				result = num2.Value;
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			result = -1L;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			result = -1L;
		}
		return result;
	}

	public JsonResult GetOrdTitle(string text)
	{
		text = text ?? "";
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<string> list2 = Enumerable.ToList<string>((IEnumerable<string>)_db.WSspOrderSearchAndLoadTitle(text, lCID, result));
			list.AddRange(Enumerable.Select<string, SelectListItem>((IEnumerable<string>)list2, (Func<string, SelectListItem>)((string item) => new SelectListItem
			{
				Text = item,
				Value = item,
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
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult GetOrdTitle_Lang(string text, int currLangID)
	{
		text = text ?? "";
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			List<string> list2 = Enumerable.ToList<string>((IEnumerable<string>)_db.WSspOrderSearchAndLoadTitle(text, currLangID, result));
			list.AddRange(Enumerable.Select<string, SelectListItem>((IEnumerable<string>)list2, (Func<string, SelectListItem>)((string item) => new SelectListItem
			{
				Text = item,
				Value = item,
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
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult GetOrdSubject(string text)
	{
		text = text ?? "";
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<string> list2 = Enumerable.ToList<string>((IEnumerable<string>)_db.WSspOrderSearchAndLoadSubject(text, lCID, result));
			list.AddRange(Enumerable.Select<string, SelectListItem>((IEnumerable<string>)list2, (Func<string, SelectListItem>)((string item) => new SelectListItem
			{
				Text = item,
				Value = item,
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
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult GetOrdSubject_Lang(string text, int currLangID)
	{
		text = text ?? "";
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			List<string> list2 = Enumerable.ToList<string>((IEnumerable<string>)_db.WSspOrderSearchAndLoadSubject(text, currLangID, result));
			list.AddRange(Enumerable.Select<string, SelectListItem>((IEnumerable<string>)list2, (Func<string, SelectListItem>)((string item) => new SelectListItem
			{
				Text = item,
				Value = item,
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
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult OrderItemTax(int orderId)
	{
		decimal? num = Enumerable.FirstOrDefault<decimal?>(_db.Database.SqlQuery<decimal?>($"Select * from dbo.WSfnReturnOrderItemTax({orderId})", Array.Empty<object>()));
		if (!num.HasValue)
		{
			num = default(decimal);
		}
		return Json(num, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetOrderDefaultSetting(int id)
	{
		_003C_003Ec__DisplayClass59_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass59_0();
		CS_0024_003C_003E8__locals0.id = id;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		WSspSelectOrderDefaultSettingByReferUserIdLanguageViewModel wSspSelectOrderDefaultSettingByReferUserIdLanguageViewModel = new WSspSelectOrderDefaultSettingByReferUserIdLanguageViewModel();
		try
		{
			DbSet<WSOrderDefaultSetting> wSOrderDefaultSetting = _dbTbl.WSOrderDefaultSetting;
			ParameterExpression val = Expression.Parameter(typeof(WSOrderDefaultSetting), "c");
			WSOrderDefaultSetting wSOrderDefaultSetting2 = Queryable.FirstOrDefault<WSOrderDefaultSetting>((IQueryable<WSOrderDefaultSetting>)wSOrderDefaultSetting, Expression.Lambda<Func<WSOrderDefaultSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass59_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (wSOrderDefaultSetting2 != null)
			{
				DbSet<WSOrderDefaultSetting_Lang> wSOrderDefaultSetting_Lang = _dbTbl.WSOrderDefaultSetting_Lang;
				val = Expression.Parameter(typeof(WSOrderDefaultSetting_Lang), "c");
				List<WSOrderDefaultSetting_Lang> list = Enumerable.ToList<WSOrderDefaultSetting_Lang>((IEnumerable<WSOrderDefaultSetting_Lang>)Queryable.Where<WSOrderDefaultSetting_Lang>((IQueryable<WSOrderDefaultSetting_Lang>)wSOrderDefaultSetting_Lang, Expression.Lambda<Func<WSOrderDefaultSetting_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass59_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrderDefaultSetting_Lang>)list, (Func<WSOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSOrderDefaultSetting_Lang myitem) => new CommonMultiLanguageViewModel
				{
					Value = myitem.Title,
					LanguageId = myitem.LanguageID
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = wSOrderDefaultSetting2.Title,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrderDefaultSetting_Lang>)list, (Func<WSOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSOrderDefaultSetting_Lang myitem) => new CommonMultiLanguageViewModel
				{
					Value = myitem.DescriptionI,
					LanguageId = myitem.LanguageID
				})));
				list3.Add(new CommonMultiLanguageViewModel
				{
					Value = wSOrderDefaultSetting2.DescriptionI,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrderDefaultSetting_Lang>)list, (Func<WSOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSOrderDefaultSetting_Lang myitem) => new CommonMultiLanguageViewModel
				{
					Value = myitem.DescriptionII,
					LanguageId = myitem.LanguageID
				})));
				list4.Add(new CommonMultiLanguageViewModel
				{
					Value = wSOrderDefaultSetting2.DescriptionII,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list5 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrderDefaultSetting_Lang>)list, (Func<WSOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSOrderDefaultSetting_Lang myitem) => new CommonMultiLanguageViewModel
				{
					Value = myitem.Subject,
					LanguageId = myitem.LanguageID
				})));
				list5.Add(new CommonMultiLanguageViewModel
				{
					Value = wSOrderDefaultSetting2.Subject,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list6 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrderDefaultSetting_Lang>)list, (Func<WSOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSOrderDefaultSetting_Lang myitem) => new CommonMultiLanguageViewModel
				{
					Value = myitem.SpecialWord,
					LanguageId = myitem.LanguageID
				})));
				list6.Add(new CommonMultiLanguageViewModel
				{
					Value = wSOrderDefaultSetting2.SpecialWord,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list7 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrderDefaultSetting_Lang>)list, (Func<WSOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSOrderDefaultSetting_Lang myitem) => new CommonMultiLanguageViewModel
				{
					Value = myitem.SettingTitle,
					LanguageId = myitem.LanguageID
				})));
				list7.Add(new CommonMultiLanguageViewModel
				{
					Value = wSOrderDefaultSetting2.SettingTitle,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list8 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrderDefaultSetting_Lang>)list, (Func<WSOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSOrderDefaultSetting_Lang myitem) => new CommonMultiLanguageViewModel
				{
					Value = myitem.SigningI,
					LanguageId = myitem.LanguageID
				})));
				list8.Add(new CommonMultiLanguageViewModel
				{
					Value = wSOrderDefaultSetting2.SigningI,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list9 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrderDefaultSetting_Lang>)list, (Func<WSOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSOrderDefaultSetting_Lang myitem) => new CommonMultiLanguageViewModel
				{
					Value = myitem.SigningII,
					LanguageId = myitem.LanguageID
				})));
				list9.Add(new CommonMultiLanguageViewModel
				{
					Value = wSOrderDefaultSetting2.SigningII,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list10 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrderDefaultSetting_Lang>)list, (Func<WSOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSOrderDefaultSetting_Lang myitem) => new CommonMultiLanguageViewModel
				{
					Value = myitem.SigningIII,
					LanguageId = myitem.LanguageID
				})));
				list10.Add(new CommonMultiLanguageViewModel
				{
					Value = wSOrderDefaultSetting2.SigningIII,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list11 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrderDefaultSetting_Lang>)list, (Func<WSOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSOrderDefaultSetting_Lang myitem) => new CommonMultiLanguageViewModel
				{
					Value = myitem.Note,
					LanguageId = myitem.LanguageID
				})));
				list11.Add(new CommonMultiLanguageViewModel
				{
					Value = wSOrderDefaultSetting2.Note,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list12 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrderDefaultSetting_Lang>)list, (Func<WSOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSOrderDefaultSetting_Lang myitem) => new CommonMultiLanguageViewModel
				{
					Value = myitem.AddPrdValidityPrjTitle,
					LanguageId = myitem.LanguageID
				})));
				list12.Add(new CommonMultiLanguageViewModel
				{
					Value = wSOrderDefaultSetting2.AddPrdValidityPrjTitle,
					LanguageId = result
				});
				wSspSelectOrderDefaultSettingByReferUserIdLanguageViewModel = new WSspSelectOrderDefaultSettingByReferUserIdLanguageViewModel
				{
					OrderSettingID = wSOrderDefaultSetting2.OrderSettingID,
					GuarantyId = wSOrderDefaultSetting2.GuarantyId,
					TaxIndex = wSOrderDefaultSetting2.TaxIndex,
					CalculateTax = wSOrderDefaultSetting2.CalculateTax,
					PrintFormatId = wSOrderDefaultSetting2.PrintFormatId,
					RightLogoId = wSOrderDefaultSetting2.RightLogoId,
					LeftLogoId = wSOrderDefaultSetting2.LeftLogoId,
					SignatureId = wSOrderDefaultSetting2.SignatureId,
					UserId = wSOrderDefaultSetting2.UserId,
					FPId = wSOrderDefaultSetting2.FPId,
					Month1 = wSOrderDefaultSetting2.Month1,
					RegisterDate = wSOrderDefaultSetting2.RegisterDate,
					RegisterDatePersian = wSOrderDefaultSetting2.RegisterDatePersian,
					GUId = wSOrderDefaultSetting2.GUId,
					AccountNumberI = wSOrderDefaultSetting2.AccountNumberI,
					AccountShabaNumberI = wSOrderDefaultSetting2.AccountShabaNumberI,
					AccountNumberII = wSOrderDefaultSetting2.AccountNumberII,
					AccountShabaNumberII = wSOrderDefaultSetting2.AccountShabaNumberII,
					ReferUserId = wSOrderDefaultSetting2.ReferUserId,
					OrderOprID = wSOrderDefaultSetting2.OrderOprID,
					AutoGenerateOrdSerial = wSOrderDefaultSetting2.AutoGenerateOrdSerial,
					AppType = wSOrderDefaultSetting2.AppType,
					LanguageID = wSOrderDefaultSetting2.LanguageID,
					FirstRegisterUserId = wSOrderDefaultSetting2.FirstRegisterUserId,
					FirstRegisterDatePersian = wSOrderDefaultSetting2.FirstRegisterDatePersian,
					FirstRegisterDate = wSOrderDefaultSetting2.FirstRegisterDate,
					Title_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					Title = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					Subject_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					Subject = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					DescriptionI_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					DescriptionI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					DescriptionII_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					DescriptionII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
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
					Note_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					Note = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
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
					DefPayTypeId = wSOrderDefaultSetting2.DefPayTypeId,
					SettlementTypeId = wSOrderDefaultSetting2.SettlementTypeId,
					AddPrdValidity = wSOrderDefaultSetting2.AddPrdValidity,
					AddPrdValidityPrjTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					AddPrdValidityPrjTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					SaleAreaId = wSOrderDefaultSetting2.SaleAreaId
				};
				if (wSspSelectOrderDefaultSettingByReferUserIdLanguageViewModel != null && wSspSelectOrderDefaultSettingByReferUserIdLanguageViewModel.SaleCenterId.GetValueOrDefault() != 0)
				{
					WSspSelectSaleCenterWithId_Result wSspSelectSaleCenterWithId_Result = Enumerable.FirstOrDefault<WSspSelectSaleCenterWithId_Result>((IEnumerable<WSspSelectSaleCenterWithId_Result>)_dbII.WSspSelectSaleCenterWithId(wSspSelectOrderDefaultSettingByReferUserIdLanguageViewModel.SaleCenterId, CS_0024_003C_003E8__locals0.currLangID, result));
					if (wSspSelectSaleCenterWithId_Result != null)
					{
						wSspSelectOrderDefaultSettingByReferUserIdLanguageViewModel.SaleCenterName = wSspSelectSaleCenterWithId_Result.SaleCenterName ?? "";
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
		return Json(wSspSelectOrderDefaultSettingByReferUserIdLanguageViewModel, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetOrdDefSetting(int? id = null)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int userId = UserLogin.CurrentUser.UserId;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			if (!id.HasValue)
			{
				id = UserLogin.CurrentUser.UserId;
			}
			List<WSspSelectOrderDefaultSettingUserAccess_Result> list2 = Enumerable.ToList<WSspSelectOrderDefaultSettingUserAccess_Result>((IEnumerable<WSspSelectOrderDefaultSettingUserAccess_Result>)_dbIII.WSspSelectOrderDefaultSettingUserAccess((short)1, userId, lCID, result));
			int? defSettingId = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbIII.WSspSelectOrderDefaultSettingIsDefUserAccess((short)1, userId, lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectOrderDefaultSettingUserAccess_Result, SelectListItem>((IEnumerable<WSspSelectOrderDefaultSettingUserAccess_Result>)list2, (Func<WSspSelectOrderDefaultSettingUserAccess_Result, SelectListItem>)((WSspSelectOrderDefaultSettingUserAccess_Result item) => new SelectListItem
			{
				Text = item.SettingTitle,
				Value = item.OrderSettingID.ToString(),
				Selected = (item.OrderSettingID == defSettingId.GetValueOrDefault())
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ordDefSettingList = list;
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
	public JsonResult GetOrdStatus()
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
			List<WSspSelectOrderStatus_Result> list2 = Enumerable.ToList<WSspSelectOrderStatus_Result>((IEnumerable<WSspSelectOrderStatus_Result>)_db.WSspSelectOrderStatus(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectOrderStatus_Result, SelectListItem>((IEnumerable<WSspSelectOrderStatus_Result>)list2, (Func<WSspSelectOrderStatus_Result, SelectListItem>)((WSspSelectOrderStatus_Result item) => new SelectListItem
			{
				Text = item.OrderStatus,
				Value = item.OrderStatusId.ToString(),
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
		base.ViewBag.OrdStatusList = list;
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
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.OrdGuarantyList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
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
		base.ViewBag.OrdPrintFormatList = list;
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
	public JsonResult GetReferUser(int? userId = null, int ordId = 0)
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
			if (!userId.HasValue)
			{
				userId = UserLogin.CurrentUser.UserId;
			}
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (ordId != 0)
			{
				List<CRMspSelectUserForLinkedType_Result> list2 = Enumerable.ToList<CRMspSelectUserForLinkedType_Result>((IEnumerable<CRMspSelectUserForLinkedType_Result>)_db.CRMspSelectUserForLinkedType(userId, 7, lCID, result, result2));
				list.AddRange(Enumerable.Select<CRMspSelectUserForLinkedType_Result, SelectListItem>((IEnumerable<CRMspSelectUserForLinkedType_Result>)list2, (Func<CRMspSelectUserForLinkedType_Result, SelectListItem>)((CRMspSelectUserForLinkedType_Result item) => new SelectListItem
				{
					Text = item.UserName,
					Value = item.LinkedUserId.ToString(),
					Selected = false
				})));
			}
			else
			{
				List<CRMspSelectUserForLinkedTypeIsActive_Result> list3 = Enumerable.ToList<CRMspSelectUserForLinkedTypeIsActive_Result>((IEnumerable<CRMspSelectUserForLinkedTypeIsActive_Result>)_dbI.CRMspSelectUserForLinkedTypeIsActive(userId, 7, lCID, result, result2));
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

	public JsonResult GetdVerifierTitles()
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
			_ = Configuration.MaxCountOfOnlineUser;
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
	public JsonResult GetTspSetting()
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
			List<TSPspSelectSetting_Result> list2 = Enumerable.ToList<TSPspSelectSetting_Result>((IEnumerable<TSPspSelectSetting_Result>)_dbI.TSPspSelectSetting(lCID, result));
			list.AddRange(Enumerable.Select<TSPspSelectSetting_Result, SelectListItem>((IEnumerable<TSPspSelectSetting_Result>)list2, (Func<TSPspSelectSetting_Result, SelectListItem>)((TSPspSelectSetting_Result item) => new SelectListItem
			{
				Text = item.TspSettingTitle,
				Value = item.TspSettingId.ToString(),
				Selected = false
			})));
			if (list == null || !Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)list))
			{
				list.Add(new SelectListItem
				{
					Text = Labels.SelectedListDefValue,
					Value = "",
					Selected = false
				});
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.TspSettingList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetTspFt()
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
			list.Add(new SelectListItem
			{
				Text = Labels.SelectItem1,
				Value = "",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.ordTspOrdFtI,
				Value = "1",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.ordTspOrdFtII,
				Value = "2",
				Selected = false
			});
			if (Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)list))
			{
				list[0].Selected = true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.TspFtList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetTspSetm()
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
			list.Add(new SelectListItem
			{
				Text = Labels.SelectItem1,
				Value = "",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.TspSetmI,
				Value = "1",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.TspSetmII,
				Value = "2",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.TspSetmIII,
				Value = "3",
				Selected = false
			});
			if (Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)list))
			{
				list[0].Selected = true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.TspSetmList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetTspDpvb()
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
			list.Add(new SelectListItem
			{
				Text = Labels.SelectItem1,
				Value = "",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.TspDpvbI,
				Value = "1",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.TspDpvbII,
				Value = "2",
				Selected = false
			});
			if (Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)list))
			{
				list[0].Selected = true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.TspDpvbList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public decimal GetDiscountLimitation(int? rollId = null)
	{
		decimal result = default(decimal);
		try
		{
			if (!rollId.HasValue)
			{
				rollId = UserLogin.CurrentUser.RollId;
			}
			CRMspReturnRollDiscountLimitation_Result cRMspReturnRollDiscountLimitation_Result = Enumerable.FirstOrDefault<CRMspReturnRollDiscountLimitation_Result>((IEnumerable<CRMspReturnRollDiscountLimitation_Result>)Enumerable.ToList<CRMspReturnRollDiscountLimitation_Result>((IEnumerable<CRMspReturnRollDiscountLimitation_Result>)_db.CRMspReturnRollDiscountLimitation(rollId)));
			if (cRMspReturnRollDiscountLimitation_Result != null && cRMspReturnRollDiscountLimitation_Result.LimitOrderDiscountActive.HasValue && cRMspReturnRollDiscountLimitation_Result.LimitOrderDiscountActive.GetValueOrDefault())
			{
				result = cRMspReturnRollDiscountLimitation_Result.LimitOrderDiscountPercent.GetValueOrDefault();
				return result;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public List<SelectListItem> GetOrderGroups(int selectedId = 0)
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
			List<WSspSelectOrderGroups_Result> list2 = Enumerable.ToList<WSspSelectOrderGroups_Result>((IEnumerable<WSspSelectOrderGroups_Result>)_dbII.WSspSelectOrderGroups(lCID, result));
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<WSspSelectOrderGroups_Result, SelectListItem>((IEnumerable<WSspSelectOrderGroups_Result>)list2, (Func<WSspSelectOrderGroups_Result, SelectListItem>)((WSspSelectOrderGroups_Result x) => new SelectListItem
				{
					Text = x.OrderGroupName,
					Value = x.OrderGroupId.ToString(),
					Selected = (x.OrderGroupId == selectedId)
				})));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		base.ViewBag.OrderGroupsSelectListItem = list;
		return list;
	}

	[HttpPost]
	[LoginAuthorize]
	public JsonResult GetOrderGroupsJs(int selectedId = 0)
	{
		return Json(GetOrderGroups(selectedId), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmOrder", ActionName = "actDelete")]
	public string Delete(int id)
	{
		_003C_003Ec__DisplayClass89_0 _003C_003Ec__DisplayClass89_ = new _003C_003Ec__DisplayClass89_0();
		_003C_003Ec__DisplayClass89_.id = id;
		string result = "";
		try
		{
			DbSet<WSOrder> wSOrder = _dbTbl.WSOrder;
			ParameterExpression val = Expression.Parameter(typeof(WSOrder), "c");
			WSOrder wSOrder2 = Queryable.FirstOrDefault<WSOrder>((IQueryable<WSOrder>)wSOrder, Expression.Lambda<Func<WSOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass89_, typeof(_003C_003Ec__DisplayClass89_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (wSOrder2 != null)
			{
				try
				{
					if (Order.IsSentToLinkAccByAction(wSOrder2.OrderID))
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
					List<CRMspSelectFilesDirectory_Result> list = Files.SelectFilesDirectory(wSOrder2.ordCompanyId.ToString(), "0", wSOrder2.ordProjectId.ToString(), "20", wSOrder2.OrderID.ToString(), "0", "0", false);
					if (list != null && Enumerable.Any<CRMspSelectFilesDirectory_Result>((IEnumerable<CRMspSelectFilesDirectory_Result>)list))
					{
						return Messages.msgErrorItemHasFiles;
					}
					_db.CRMspDyDeleteFormFieldMasterValuesBySysPart(_003C_003Ec__DisplayClass89_.id, "ord");
					mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)Enumerable.ToList<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteWSOrder(_003C_003Ec__DisplayClass89_.id)));
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
	public string LoadProductQuantity(int prdId, int? ordIWHId = null, double? fcr = null, double? fcrI = null, string tracing = null, int cmpId = 0, string CrmOrdType = "pord", string linkAccWhId = "", string sefareshCode = "")
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
			tracing = ConvertCharacter.DecodeTracing(tracing);
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			int id = Financial.Get().Id;
			int value = 0;
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			bool flag = false;
			int num = 0;
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				flag = ((cRMspSelectCrmsysSetting_Result.InvStockFromLink.HasValue && cRMspSelectCrmsysSetting_Result.InvStockFromLink.GetValueOrDefault()) ? true : false);
				num = cRMspSelectCrmsysSetting_Result.LinkAccSystemId.GetValueOrDefault();
			}
			if (flag && num > 0)
			{
				ProductController productController = new ProductController();
				string text2 = "";
				switch (num)
				{
				case 3:
				{
					decimal prdPrice = default(decimal);
					double prdQuantity = 0.0;
					productController.TarazGetPrdQuantityAndPrice(prdId, cmpId, ordIWHId.GetValueOrDefault(), 0, ref prdPrice, ref prdQuantity, CrmOrdType, 0);
					text2 = prdQuantity.ToString();
					break;
				}
				case 4:
				{
					List<ProductQuantityLinkAccDataViewModel> prdQuantityList = new CRMIdeal.Classes.Helper.OtherSystems.HolooProvider(0).GetPrdQuantityList(prdId);
					if (prdQuantityList != null && Enumerable.Any<ProductQuantityLinkAccDataViewModel>((IEnumerable<ProductQuantityLinkAccDataViewModel>)prdQuantityList))
					{
						ProductQuantityLinkAccDataViewModel productQuantityLinkAccDataViewModel = Enumerable.FirstOrDefault<ProductQuantityLinkAccDataViewModel>((IEnumerable<ProductQuantityLinkAccDataViewModel>)prdQuantityList);
						if (productQuantityLinkAccDataViewModel != null)
						{
							text2 = productQuantityLinkAccDataViewModel.Quantity.ToString();
						}
					}
					break;
				}
				case 6:
					text2 = productController.KyanGetPrdQuantity(prdId, ordIWHId.GetValueOrDefault());
					break;
				case 7:
					text2 = productController.PayvastGetPrdQuantity(prdId, ordIWHId.GetValueOrDefault());
					break;
				case 11:
					text2 = productController.ShomaranGetPrdQuantity(prdId, ordIWHId.GetValueOrDefault(), linkAccWhId, tracing, sefareshCode);
					break;
				case 12:
					text2 = productController.LinkAccGetPrdQuantity(num, prdId, ordIWHId.GetValueOrDefault(), linkAccWhId, tracing);
					break;
				default:
					text2 = productController.LinkAccGetPrdQuantity(num, prdId, ordIWHId.GetValueOrDefault(), linkAccWhId, tracing);
					break;
				}
				double result3 = 0.0;
				if (!string.IsNullOrEmpty(text2) && text2 != Labels.frmError)
				{
					double.TryParse(text2, out result3);
				}
				return result3 + "|" + result3;
			}
			WSspReturnPrdQuantity_Result wSspReturnPrdQuantity_Result = Enumerable.FirstOrDefault<WSspReturnPrdQuantity_Result>((IEnumerable<WSspReturnPrdQuantity_Result>)_db.WSspReturnPrdQuantity(prdId, id, ordIWHId, value, lCID, result, fcr, fcrI, tracing, result2));
			if (wSspReturnPrdQuantity_Result != null)
			{
				text = ((!wSspReturnPrdQuantity_Result.QuantityRemain.HasValue) ? "0|" : (wSspReturnPrdQuantity_Result.QuantityRemain + "|"));
				if (wSspReturnPrdQuantity_Result.TracingRemainCount.HasValue)
				{
					return text + wSspReturnPrdQuantity_Result.TracingRemainCount;
				}
				return text + "0";
			}
			return "0|0";
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return "-1";
		}
	}

	public JsonResult GetTspOrdIrtaxid(int cmpId, int ordId = 0, string val = "")
	{
		List<TSPspSelectOrderIrtaxid_Result> list = new List<TSPspSelectOrderIrtaxid_Result>();
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
			if (cmpId > 0)
			{
				list = Enumerable.ToList<TSPspSelectOrderIrtaxid_Result>((IEnumerable<TSPspSelectOrderIrtaxid_Result>)_dbI.TSPspSelectOrderIrtaxid(cmpId, val, ordId, UserLogin.CurrentUser.UserId, lCID, result, result2));
				if (list != null && Enumerable.Any<TSPspSelectOrderIrtaxid_Result>((IEnumerable<TSPspSelectOrderIrtaxid_Result>)list))
				{
					foreach (TSPspSelectOrderIrtaxid_Result item in list)
					{
						item.ordDate = (item.ordDateTime.HasValue ? item.ordDateTime.Value.ToString("yyyy/MM/dd") : "");
						item.OrdInfo = item.ordNumber + " (" + item.OrdOpr + ") " + item.ordDate + ((!string.IsNullOrWhiteSpace(item.TspOrdIdentify)) ? (" (" + item.TspOrdIdentify + ")") : "");
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
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public int CheckOrderHaveTax(int ordId)
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
			int num = 0;
			WSspCheckOrderHaveTax_Result wSspCheckOrderHaveTax_Result = Enumerable.FirstOrDefault<WSspCheckOrderHaveTax_Result>((IEnumerable<WSspCheckOrderHaveTax_Result>)_dbI.WSspCheckOrderHaveTax(ordId));
			decimal result3 = default(decimal);
			decimal result4 = default(decimal);
			List<WSspSelectOrderItems_Result> list = Enumerable.ToList<WSspSelectOrderItems_Result>((IEnumerable<WSspSelectOrderItems_Result>)_db.WSspSelectOrderItems(ordId, lCID, result));
			if (list == null)
			{
				return result2;
			}
			if (!Enumerable.Any<WSspSelectOrderItems_Result>((IEnumerable<WSspSelectOrderItems_Result>)list))
			{
				return result2;
			}
			if (wSspCheckOrderHaveTax_Result != null)
			{
				decimal.TryParse(wSspCheckOrderHaveTax_Result.ordTax.ToString(), out result3);
				decimal.TryParse(wSspCheckOrderHaveTax_Result.ordItemsTax.ToString(), out result4);
				num = wSspCheckOrderHaveTax_Result.ordCompanyId.GetValueOrDefault();
				bool result5 = false;
				bool.TryParse(wSspCheckOrderHaveTax_Result.Taxable.ToString(), out result5);
				bool flag = false;
				if (result3 != 0m || result4 != 0m)
				{
					flag = true;
				}
				if (flag != result5)
				{
					result2 = 2;
				}
				else
				{
					bool haveOrd = false;
					bool flag2 = Order.CheckLastCompanyOrderHaveTax(num, ref haveOrd);
					if (haveOrd && flag2 != result5)
					{
						result2 = 1;
					}
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
	public int CheckOrderItemTaxIndex(int ordId)
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
			List<WSspSelectOrderItemTaxIndex_Result> list = Enumerable.ToList<WSspSelectOrderItemTaxIndex_Result>((IEnumerable<WSspSelectOrderItemTaxIndex_Result>)_dbII.WSspSelectOrderItemTaxIndex(ordId));
			if (list != null && Enumerable.Any<WSspSelectOrderItemTaxIndex_Result>((IEnumerable<WSspSelectOrderItemTaxIndex_Result>)list) && list.Count > 1)
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

	[DynamicAuthorize(ControllerName = "frmOrder", ActionName = "actEditProfit")]
	public ActionResult EditProfit(int ordId)
	{
		_003C_003Ec__DisplayClass94_0 _003C_003Ec__DisplayClass94_ = new _003C_003Ec__DisplayClass94_0();
		_003C_003Ec__DisplayClass94_.ordId = ordId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		WSOrderProfitViewModel model = new WSOrderProfitViewModel();
		try
		{
			if (_003C_003Ec__DisplayClass94_.ordId <= 0)
			{
				base.ViewBag.Error = Messages.ErrorNotFound;
				return null;
			}
			if (!UserLogin.IsUserAccess("frmOrder", "actEditProfit"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			DbSet<WSOrder> wSOrder = _dbTbl.WSOrder;
			ParameterExpression val = Expression.Parameter(typeof(WSOrder), "c");
			WSOrder wSOrder2 = Queryable.FirstOrDefault<WSOrder>((IQueryable<WSOrder>)wSOrder, Expression.Lambda<Func<WSOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass94_, typeof(_003C_003Ec__DisplayClass94_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (wSOrder2 == null)
			{
				base.ViewBag.Error = Messages.ErrorNotFound;
				return null;
			}
			if (Order.IsFixed(_003C_003Ec__DisplayClass94_.ordId))
			{
				base.ViewBag.Error = "msgErrorNotActiveOrd".OrderMessages();
				return null;
			}
			model = new WSOrderProfitViewModel
			{
				OrderID = wSOrder2.OrderID,
				ordDate = (wSOrder2.ordDateTime.HasValue ? wSOrder2.ordDateTime.Value.ToString("yyyy/MM/dd") : ""),
				ordGrossProfit = wSOrder2.ordGrossProfit,
				ordMoneySleep = wSOrder2.ordMoneySleep,
				ordSaleNetProfit = wSOrder2.ordSaleNetProfit,
				ordSumOtherComm = wSOrder2.ordSumOtherComm,
				ordSumSaleComm = wSOrder2.ordSumSaleComm,
				ordSumBuyComm = wSOrder2.ordSumBuyComm,
				ordSumMangComm = wSOrder2.ordSumMangComm,
				ordNetProfit = wSOrder2.ordNetProfit
			};
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(model);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmOrder", ActionName = "actEditProfit")]
	[ValidateAntiForgeryToken]
	public ActionResult EditProfit(WSOrderProfitViewModel model)
	{
		_003C_003Ec__DisplayClass95_0 _003C_003Ec__DisplayClass95_ = new _003C_003Ec__DisplayClass95_0();
		_003C_003Ec__DisplayClass95_.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			if (!VersionBuyer.Order)
			{
				base.ViewBag.Error = "BV|" + Messages.VersionBuyWithoutCount;
				return View(_003C_003Ec__DisplayClass95_.model);
			}
			if (!base.ModelState.IsValid)
			{
				base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
			else
			{
				DbSet<WSOrder> wSOrder = _dbTbl.WSOrder;
				ParameterExpression val = Expression.Parameter(typeof(WSOrder), "c");
				WSOrder wSOrder2 = Queryable.FirstOrDefault<WSOrder>((IQueryable<WSOrder>)wSOrder, Expression.Lambda<Func<WSOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass95_, typeof(_003C_003Ec__DisplayClass95_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				wSOrder2.UserId = UserLogin.CurrentUser.UserId;
				DateTime dateTime = (wSOrder2.RegisterDate = DateTime.Now);
				wSOrder2.RegisterDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
				wSOrder2.Month1 = short.Parse(dateTime.ToString("MM", new PersianCulture()));
				wSOrder2.AppType = Configuration.AppType;
				wSOrder2.ordGrossProfit = _003C_003Ec__DisplayClass95_.model.ordGrossProfit;
				wSOrder2.ordMoneySleep = _003C_003Ec__DisplayClass95_.model.ordMoneySleep;
				wSOrder2.ordSaleNetProfit = _003C_003Ec__DisplayClass95_.model.ordSaleNetProfit;
				wSOrder2.ordNetProfit = _003C_003Ec__DisplayClass95_.model.ordNetProfit;
				if (wSOrder2 == null)
				{
					base.ViewBag.Successfull = Messages.ErrorNotFound;
				}
				else
				{
					_dbTbl.Entry(wSOrder2).State = EntityState.Modified;
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					if (!Order.CalcAndSetOrderAmounts(wSOrder2))
					{
						base.ViewBag.Error = "CalcAndSetOrderErrorMessage".OrderMessages();
					}
					else
					{
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			base.ViewBag.Error = Messages.msgErrorRunFunction;
		}
		return View(_003C_003Ec__DisplayClass95_.model);
	}
}

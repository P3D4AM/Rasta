using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Objects;
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
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.FormBase.Controllers;

public class ConversationStatusResultController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass34_0
	{
		public int cnvsStatusResultId;

		public int currLangID;

		public int defLangID;

		public Func<CommonMultiLanguageViewModel, bool> _003C_003E9__17;

		public Func<CommonMultiLanguageViewModel, bool> _003C_003E9__18;

		public Func<CommonMultiLanguageViewModel, bool> _003C_003E9__19;

		public Func<CommonMultiLanguageViewModel, bool> _003C_003E9__20;

		public Func<CommonMultiLanguageViewModel, bool> _003C_003E9__21;

		public Func<CommonMultiLanguageViewModel, bool> _003C_003E9__22;

		public Func<CommonMultiLanguageViewModel, bool> _003C_003E9__23;

		public Func<CommonMultiLanguageViewModel, bool> _003C_003E9__24;

		public Func<CommonMultiLanguageViewModel, bool> _003C_003E9__25;

		internal bool _003CInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
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
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
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
			return c.LanguageId != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__24(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__25(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass48_0
	{
		public int cnvsStatusResultId;

		public int currLangID;

		public int defLangID;

		public Func<CommonMultiLanguageViewModel, bool> _003C_003E9__17;

		public Func<CommonMultiLanguageViewModel, bool> _003C_003E9__18;

		public Func<CommonMultiLanguageViewModel, bool> _003C_003E9__19;

		public Func<CommonMultiLanguageViewModel, bool> _003C_003E9__20;

		public Func<CommonMultiLanguageViewModel, bool> _003C_003E9__21;

		public Func<CommonMultiLanguageViewModel, bool> _003C_003E9__22;

		public Func<CommonMultiLanguageViewModel, bool> _003C_003E9__23;

		public Func<CommonMultiLanguageViewModel, bool> _003C_003E9__24;

		public Func<CommonMultiLanguageViewModel, bool> _003C_003E9__25;

		internal bool _003CInsertEdit_I_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_I_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_I_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_I_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_I_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_I_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_I_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_I_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_I_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_I_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_I_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_I_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_I_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_I_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_I_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_I_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_I_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_I_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_I_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != defLangID;
		}

		internal bool _003CInsertEdit_I_003Eb__24(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_I_003Eb__25(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private static class _003C_003Eo__34
	{
		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__0;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__1;

		public static CallSite<Func<CallSite, object, int, object>> _003C_003Ep__2;

		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__3;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__4;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__5;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__6;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__7;

		public static CallSite<Func<CallSite, Type, object, object>> _003C_003Ep__8;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__9;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__10;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__11;

		public static CallSite<Func<CallSite, Type, object, object>> _003C_003Ep__12;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__13;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__14;

		public static CallSite<Func<CallSite, object, string>> _003C_003Ep__15;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__16;

		public static CallSite<Func<CallSite, Type, object, object>> _003C_003Ep__17;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__18;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__19;

		public static CallSite<Func<CallSite, object, string>> _003C_003Ep__20;

		public static CallSite<Func<CallSite, object, IEnumerable>> _003C_003Ep__21;
	}

	[CompilerGenerated]
	private static class _003C_003Eo__46
	{
		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__0;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__1;

		public static CallSite<Func<CallSite, object, int, object>> _003C_003Ep__2;

		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__3;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__4;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__5;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__6;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__7;

		public static CallSite<Func<CallSite, Type, object, object>> _003C_003Ep__8;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__9;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__10;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__11;

		public static CallSite<_003C_003EA_007B00000200_007D<CallSite, Type, object, int>> _003C_003Ep__12;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__13;

		public static CallSite<_003C_003EA_007B00000200_007D<CallSite, Type, object, int>> _003C_003Ep__14;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__15;

		public static CallSite<_003C_003EA_007B00000200_007D<CallSite, Type, object, int>> _003C_003Ep__16;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__17;

		public static CallSite<_003C_003EA_007B00000200_007D<CallSite, Type, object, int>> _003C_003Ep__18;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__19;

		public static CallSite<_003C_003EA_007B00000200_007D<CallSite, Type, object, int>> _003C_003Ep__20;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__21;

		public static CallSite<_003C_003EA_007B00000200_007D<CallSite, Type, object, int>> _003C_003Ep__22;

		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__23;

		public static CallSite<Func<CallSite, object, string, object>> _003C_003Ep__24;

		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__25;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__26;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__27;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__28;

		public static CallSite<Func<CallSite, object, string>> _003C_003Ep__29;

		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__30;

		public static CallSite<Func<CallSite, object, string, object>> _003C_003Ep__31;

		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__32;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__33;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__34;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__35;

		public static CallSite<Func<CallSite, object, string>> _003C_003Ep__36;

		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__37;

		public static CallSite<Func<CallSite, object, string, object>> _003C_003Ep__38;

		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__39;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__40;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__41;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__42;

		public static CallSite<Func<CallSite, object, string>> _003C_003Ep__43;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__44;

		public static CallSite<_003C_003EA_007B00000200_007D<CallSite, Type, object, int>> _003C_003Ep__45;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__46;

		public static CallSite<_003C_003EA_007B00000200_007D<CallSite, Type, object, int>> _003C_003Ep__47;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__48;

		public static CallSite<_003C_003EA_007B00000200_007D<CallSite, Type, object, int>> _003C_003Ep__49;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__50;

		public static CallSite<_003C_003EA_007B00000200_007D<CallSite, Type, object, bool>> _003C_003Ep__51;

		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__52;

		public static CallSite<Func<CallSite, object, string, object>> _003C_003Ep__53;

		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__54;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__55;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__56;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__57;

		public static CallSite<Func<CallSite, object, string>> _003C_003Ep__58;

		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__59;

		public static CallSite<Func<CallSite, object, string, object>> _003C_003Ep__60;

		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__61;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__62;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__63;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__64;

		public static CallSite<Func<CallSite, object, string>> _003C_003Ep__65;

		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__66;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__67;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__68;

		public static CallSite<_003C_003EA_007B00000200_007D<CallSite, Type, object, bool>> _003C_003Ep__69;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__70;

		public static CallSite<_003C_003EA_007B00000200_007D<CallSite, Type, object, int>> _003C_003Ep__71;

		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__72;

		public static CallSite<Func<CallSite, object, string, object>> _003C_003Ep__73;

		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__74;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__75;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__76;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__77;

		public static CallSite<Func<CallSite, object, string>> _003C_003Ep__78;

		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__79;

		public static CallSite<Func<CallSite, object, string, object>> _003C_003Ep__80;

		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__81;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__82;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__83;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__84;

		public static CallSite<Func<CallSite, object, string>> _003C_003Ep__85;

		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__86;

		public static CallSite<Func<CallSite, object, string, object>> _003C_003Ep__87;

		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__88;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__89;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__90;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__91;

		public static CallSite<Func<CallSite, object, string>> _003C_003Ep__92;

		public static CallSite<Func<CallSite, object, IEnumerable>> _003C_003Ep__93;

		public static CallSite<Func<CallSite, object, Dictionary<string, object>>> _003C_003Ep__94;

		public static CallSite<Func<CallSite, object, Dictionary<string, object>>> _003C_003Ep__95;
	}

	[CompilerGenerated]
	private static class _003C_003Eo__48
	{
		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__0;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__1;

		public static CallSite<Func<CallSite, object, int, object>> _003C_003Ep__2;

		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__3;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__4;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__5;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__6;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__7;

		public static CallSite<Func<CallSite, Type, object, object>> _003C_003Ep__8;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__9;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__10;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__11;

		public static CallSite<Func<CallSite, Type, object, object>> _003C_003Ep__12;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__13;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__14;

		public static CallSite<Func<CallSite, object, string>> _003C_003Ep__15;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__16;

		public static CallSite<Func<CallSite, Type, object, object>> _003C_003Ep__17;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__18;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__19;

		public static CallSite<Func<CallSite, object, string>> _003C_003Ep__20;

		public static CallSite<Func<CallSite, object, IEnumerable>> _003C_003Ep__21;
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actDefinecnvsStatusResult")]
	public ActionResult Index(int cnvsStatusGroupId = 0, int cnvsStatusId = 0)
	{
		base.ViewBag.CnvsStatusId = cnvsStatusId;
		base.ViewBag.CnvsStatusGroupId = cnvsStatusGroupId;
		return View();
	}

	[AjaxOnly]
	public ActionResult ConversationStatusResult_Read([DataSourceRequest] DataSourceRequest request, int cnvsStatusId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectConversationStatusResult_Result> list = new List<CRMspSelectConversationStatusResult_Result>();
		try
		{
			list = Enumerable.ToList<CRMspSelectConversationStatusResult_Result>((IEnumerable<CRMspSelectConversationStatusResult_Result>)_dbI.CRMspSelectConversationStatusResult(cnvsStatusId, lCID, result));
			foreach (CRMspSelectConversationStatusResult_Result item in list)
			{
				if (string.IsNullOrEmpty(item.AppType))
				{
					item.AppType = Configuration.AppType;
				}
				item.AppType = Configuration.GetAppType(item.AppType);
				string text = item.FirstRegisterUser ?? "";
				_ = item.FirstRegisterDate;
				string text2 = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				item.FirstRegisterDatePersian = text + " (" + text2 + ")";
				string text3 = item.EditUser ?? "";
				_ = item.RegisterDate;
				string text4 = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				item.RegisterDatePersian = text3 + " (" + Labels.AppType + ":" + item.AppType + ")  (" + text4 + ")";
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

	public List<CRMspSelectConversationStatusResult_Result> GetConversationStatusResultList(int cnvsStatusId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectConversationStatusResult_Result> list = new List<CRMspSelectConversationStatusResult_Result>();
		try
		{
			list = Enumerable.ToList<CRMspSelectConversationStatusResult_Result>((IEnumerable<CRMspSelectConversationStatusResult_Result>)_dbI.CRMspSelectConversationStatusResult(cnvsStatusId, lCID, result));
			foreach (CRMspSelectConversationStatusResult_Result item in list)
			{
				if (string.IsNullOrEmpty(item.AppType))
				{
					item.AppType = Configuration.AppType;
				}
				item.AppType = Configuration.GetAppType(item.AppType);
				string text = item.FirstRegisterUser ?? "";
				_ = item.FirstRegisterDate;
				string text2 = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				item.FirstRegisterDatePersian = text + " (" + text2 + ")";
				string text3 = item.EditUser ?? "";
				_ = item.RegisterDate;
				string text4 = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				item.RegisterDatePersian = text3 + " (" + Labels.AppType + ":" + item.AppType + ")  (" + text4 + ")";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public JsonResult GetConversationStatusResultListJson(int cnvsStatusId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectConversationStatusResult_Result> data = new List<CRMspSelectConversationStatusResult_Result>();
		try
		{
			data = GetConversationStatusResultList(cnvsStatusId);
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
	public JsonResult GetCnvsReferUsers()
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
			List<CRMspSelectUsersByIds_Result> list2 = CRMIdeal.Classes.Helper.User.SelectUsersByIds("-100,-102,-103");
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
			List<CRMspSelectActiveUsers_Result> list3 = Enumerable.ToList<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)_db.CRMspSelectActiveUsers(lCID, result, 0));
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
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetCnvsStatusGroups()
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
			List<CRMspSelectActiveConversationStatusGroups_Result> list2 = Enumerable.ToList<CRMspSelectActiveConversationStatusGroups_Result>((IEnumerable<CRMspSelectActiveConversationStatusGroups_Result>)_dbI.CRMspSelectActiveConversationStatusGroups(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectActiveConversationStatusGroups_Result, SelectListItem>((IEnumerable<CRMspSelectActiveConversationStatusGroups_Result>)list2, (Func<CRMspSelectActiveConversationStatusGroups_Result, SelectListItem>)((CRMspSelectActiveConversationStatusGroups_Result item) => new SelectListItem
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
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetCnvsStatus(int cnvsStatusGroupId = 0)
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
			List<CRMspSelectActiveConversationStatus_Result> list2 = Enumerable.ToList<CRMspSelectActiveConversationStatus_Result>((IEnumerable<CRMspSelectActiveConversationStatus_Result>)_dbI.CRMspSelectActiveConversationStatus(cnvsStatusGroupId, lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectActiveConversationStatus_Result, SelectListItem>((IEnumerable<CRMspSelectActiveConversationStatus_Result>)list2, (Func<CRMspSelectActiveConversationStatus_Result, SelectListItem>)((CRMspSelectActiveConversationStatus_Result item) => new SelectListItem
			{
				Text = (item.Status ?? ""),
				Value = item.ConversationStatusID.ToString(),
				Selected = false
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
	public JsonResult GetCnvsTopics()
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
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetNextCnvsStatus(int cnvsStatusGroupId = 0, int currCnvsStatusId = 0)
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
			List<CRMspSelectConversationStatusNextCurrStatus_Result> list2 = Enumerable.ToList<CRMspSelectConversationStatusNextCurrStatus_Result>((IEnumerable<CRMspSelectConversationStatusNextCurrStatus_Result>)_dbI.CRMspSelectConversationStatusNextCurrStatus(cnvsStatusGroupId, currCnvsStatusId, lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectConversationStatusNextCurrStatus_Result, SelectListItem>((IEnumerable<CRMspSelectConversationStatusNextCurrStatus_Result>)list2, (Func<CRMspSelectConversationStatusNextCurrStatus_Result, SelectListItem>)((CRMspSelectConversationStatusNextCurrStatus_Result item) => new SelectListItem
			{
				Text = (item.Status ?? ""),
				Value = item.ConversationStatusID.ToString(),
				Selected = false
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
	public JsonResult GetNextCnvsStatusResult(int cnvsStatusId = 0, int currCnvsStatusResultId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectActiveConversationStatusResult_Result> data = new List<CRMspSelectActiveConversationStatusResult_Result>();
		try
		{
			data = Enumerable.ToList<CRMspSelectActiveConversationStatusResult_Result>((IEnumerable<CRMspSelectActiveConversationStatusResult_Result>)_dbI.CRMspSelectActiveConversationStatusResult(cnvsStatusId, lCID, result));
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
	public JsonResult GetCnvsStatusResult(int cnvsStatusId = 0)
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
			List<CRMspSelectActiveConversationStatusResult_Result> list2 = Enumerable.ToList<CRMspSelectActiveConversationStatusResult_Result>((IEnumerable<CRMspSelectActiveConversationStatusResult_Result>)_dbI.CRMspSelectActiveConversationStatusResult(cnvsStatusId, lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectActiveConversationStatusResult_Result, SelectListItem>((IEnumerable<CRMspSelectActiveConversationStatusResult_Result>)list2, (Func<CRMspSelectActiveConversationStatusResult_Result, SelectListItem>)((CRMspSelectActiveConversationStatusResult_Result item) => new SelectListItem
			{
				Text = (item.ResultTitle ?? ""),
				Value = item.ConversationStatusResultId.ToString(),
				Selected = false
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
	public JsonResult GetDyForms(string sysPartIds = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspDySelectParentFormsBySysPartIds_Result> list = new List<CRMspDySelectParentFormsBySysPartIds_Result>();
		try
		{
			list = Enumerable.ToList<CRMspDySelectParentFormsBySysPartIds_Result>((IEnumerable<CRMspDySelectParentFormsBySysPartIds_Result>)_dbI.CRMspDySelectParentFormsBySysPartIds(sysPartIds, lCID, result));
			if (list == null)
			{
				list = new List<CRMspDySelectParentFormsBySysPartIds_Result>();
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
	public JsonResult GetActiveUsers()
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
			List<CRMspSelectActiveUsers_Result> list2 = Enumerable.ToList<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)_db.CRMspSelectActiveUsers(lCID, result, 0));
			list.AddRange(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)list2, (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result item) => new SelectListItem
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
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetCmpGroup()
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
			List<CRMspSelectCompanyGroup_Result> list2 = Enumerable.ToList<CRMspSelectCompanyGroup_Result>((IEnumerable<CRMspSelectCompanyGroup_Result>)_db.CRMspSelectCompanyGroup(UserLogin.CurrentUser.UserId, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyGroup_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroup_Result>)list2, (Func<CRMspSelectCompanyGroup_Result, SelectListItem>)((CRMspSelectCompanyGroup_Result item) => new SelectListItem
			{
				Text = (item.GroupName ?? ""),
				Value = item.CompanyGroupID.ToString(),
				Selected = false
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
	public JsonResult GetCmpSubGroup(int cmpGroupId = 0)
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
			List<CRMspSelectCompanySubGroup_Result> list2 = Enumerable.ToList<CRMspSelectCompanySubGroup_Result>((IEnumerable<CRMspSelectCompanySubGroup_Result>)_db.CRMspSelectCompanySubGroup(UserLogin.CurrentUser.UserId, cmpGroupId, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectCompanySubGroup_Result, SelectListItem>((IEnumerable<CRMspSelectCompanySubGroup_Result>)list2, (Func<CRMspSelectCompanySubGroup_Result, SelectListItem>)((CRMspSelectCompanySubGroup_Result item) => new SelectListItem
			{
				Text = (item.SubGroupName ?? ""),
				Value = item.CompanySubGroupID.ToString(),
				Selected = false
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
	public JsonResult GetCmpGroupII()
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
			List<CRMspSelectCompanyGroupsII_Result> list2 = Enumerable.ToList<CRMspSelectCompanyGroupsII_Result>((IEnumerable<CRMspSelectCompanyGroupsII_Result>)_db.CRMspSelectCompanyGroupsII(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyGroupsII_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsII_Result>)list2, (Func<CRMspSelectCompanyGroupsII_Result, SelectListItem>)((CRMspSelectCompanyGroupsII_Result item) => new SelectListItem
			{
				Text = (item.GroupIIName ?? ""),
				Value = item.CompanyGroupIIID.ToString(),
				Selected = false
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
	public JsonResult GetCmpGroupIII()
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
			List<CRMspSelectCompanyGroupsIII_Result> list2 = Enumerable.ToList<CRMspSelectCompanyGroupsIII_Result>((IEnumerable<CRMspSelectCompanyGroupsIII_Result>)_db.CRMspSelectCompanyGroupsIII(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyGroupsIII_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsIII_Result>)list2, (Func<CRMspSelectCompanyGroupsIII_Result, SelectListItem>)((CRMspSelectCompanyGroupsIII_Result item) => new SelectListItem
			{
				Text = (item.GroupIIIName ?? ""),
				Value = item.CompanyGroupIIIID.ToString(),
				Selected = false
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
	public JsonResult GetCmpGroupIV()
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
			List<CRMspSelectCompanyGroupsIV_Result> list2 = Enumerable.ToList<CRMspSelectCompanyGroupsIV_Result>((IEnumerable<CRMspSelectCompanyGroupsIV_Result>)_db.CRMspSelectCompanyGroupsIV(UserLogin.CurrentUser.UserId, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyGroupsIV_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsIV_Result>)list2, (Func<CRMspSelectCompanyGroupsIV_Result, SelectListItem>)((CRMspSelectCompanyGroupsIV_Result item) => new SelectListItem
			{
				Text = (item.GroupIVName ?? ""),
				Value = item.CompanyGroupIVID.ToString(),
				Selected = false
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
	public JsonResult GetCmpType()
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
			List<CRMspSelectCompanyType_Result> list2 = Enumerable.ToList<CRMspSelectCompanyType_Result>((IEnumerable<CRMspSelectCompanyType_Result>)_db.CRMspSelectCompanyType(lCID, result));
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
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetEventPolicyTypeByPartName(string partName = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectActiveEventPolicyTypesByPartName_Result> list = new List<CRMspSelectActiveEventPolicyTypesByPartName_Result>();
		try
		{
			list = Enumerable.ToList<CRMspSelectActiveEventPolicyTypesByPartName_Result>((IEnumerable<CRMspSelectActiveEventPolicyTypesByPartName_Result>)_dbI.CRMspSelectActiveEventPolicyTypesByPartName(partName, lCID, result));
			if (list == null)
			{
				list = new List<CRMspSelectActiveEventPolicyTypesByPartName_Result>();
			}
			else
			{
				foreach (CRMspSelectActiveEventPolicyTypesByPartName_Result item in list)
				{
					if (!string.IsNullOrWhiteSpace(item.JsonSetting))
					{
						item.JsonSetting = item.JsonSetting.Replace("\"", "\\\"");
					}
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
	public JsonResult GetSmsProviders()
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
			List<SmsspSelectSmsProvidersIsActive_Result> list2 = Enumerable.ToList<SmsspSelectSmsProvidersIsActive_Result>((IEnumerable<SmsspSelectSmsProvidersIsActive_Result>)_dbI.SmsspSelectSmsProvidersIsActive());
			list.AddRange(Enumerable.Select<SmsspSelectSmsProvidersIsActive_Result, SelectListItem>((IEnumerable<SmsspSelectSmsProvidersIsActive_Result>)list2, (Func<SmsspSelectSmsProvidersIsActive_Result, SelectListItem>)((SmsspSelectSmsProvidersIsActive_Result item) => new SelectListItem
			{
				Text = (item.ProviderName ?? ""),
				Value = item.Id.ToString(),
				Selected = false
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
	public JsonResult GetSurvey()
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
			List<CRMspSelectSurvey_Result> list2 = Enumerable.ToList<CRMspSelectSurvey_Result>(Enumerable.Where<CRMspSelectSurvey_Result>((IEnumerable<CRMspSelectSurvey_Result>)_db.CRMspSelectSurvey(lCID, result, result2), (Func<CRMspSelectSurvey_Result, bool>)((CRMspSelectSurvey_Result m) => m.surSystemPartId == 10 && !m.surInactive.GetValueOrDefault())));
			list.AddRange(Enumerable.Select<CRMspSelectSurvey_Result, SelectListItem>((IEnumerable<CRMspSelectSurvey_Result>)list2, (Func<CRMspSelectSurvey_Result, SelectListItem>)((CRMspSelectSurvey_Result item) => new SelectListItem
			{
				Text = (item.surTitle ?? ""),
				Value = item.SurveyId.ToString(),
				Selected = false
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
	public JsonResult GetSurveySendSetting()
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
			List<CRMspSelectSurveySendSetting_Result> list2 = Enumerable.ToList<CRMspSelectSurveySendSetting_Result>((IEnumerable<CRMspSelectSurveySendSetting_Result>)_db.CRMspSelectSurveySendSetting(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectSurveySendSetting_Result, SelectListItem>((IEnumerable<CRMspSelectSurveySendSetting_Result>)list2, (Func<CRMspSelectSurveySendSetting_Result, SelectListItem>)((CRMspSelectSurveySendSetting_Result item) => new SelectListItem
			{
				Text = (item.surssTitle ?? ""),
				Value = item.SurveySendSettingId.ToString(),
				Selected = false
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
	public JsonResult GetSurveySendSettingByEvent()
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
			List<CRMspSelectSurveySendSetting_Result> list2 = Enumerable.ToList<CRMspSelectSurveySendSetting_Result>((IEnumerable<CRMspSelectSurveySendSetting_Result>)_db.CRMspSelectSurveySendSetting(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectSurveySendSetting_Result, SelectListItem>((IEnumerable<CRMspSelectSurveySendSetting_Result>)list2, (Func<CRMspSelectSurveySendSetting_Result, SelectListItem>)((CRMspSelectSurveySendSetting_Result item) => new SelectListItem
			{
				Text = item.SurveySendSettingId + "|" + item.surssSmsSendByWeb.GetValueOrDefault() + "|" + item.surssSmsSendByGSM.GetValueOrDefault() + "|" + item.surssSendByEmail.GetValueOrDefault(),
				Value = item.SurveySendSettingId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.SurveySendSettingByEventList = list;
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetPreOrderDefaultSetting()
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
			List<WSspSelectPreOrderDefaultSettingPublic_Result> list2 = Enumerable.ToList<WSspSelectPreOrderDefaultSettingPublic_Result>((IEnumerable<WSspSelectPreOrderDefaultSettingPublic_Result>)_dbI.WSspSelectPreOrderDefaultSettingPublic(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectPreOrderDefaultSettingPublic_Result, SelectListItem>((IEnumerable<WSspSelectPreOrderDefaultSettingPublic_Result>)list2, (Func<WSspSelectPreOrderDefaultSettingPublic_Result, SelectListItem>)((WSspSelectPreOrderDefaultSettingPublic_Result item) => new SelectListItem
			{
				Text = item.SettingTitle + ((!string.IsNullOrWhiteSpace(item.ReferUser)) ? (" (" + item.ReferUser + ")") : ""),
				Value = item.PreOrderSettingID.ToString(),
				Selected = false
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
	public JsonResult GetOrderDefaultSetting()
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
			List<WSspSelectOrderDefaultSettingPublic_Result> list2 = Enumerable.ToList<WSspSelectOrderDefaultSettingPublic_Result>((IEnumerable<WSspSelectOrderDefaultSettingPublic_Result>)_dbI.WSspSelectOrderDefaultSettingPublic(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectOrderDefaultSettingPublic_Result, SelectListItem>((IEnumerable<WSspSelectOrderDefaultSettingPublic_Result>)list2, (Func<WSspSelectOrderDefaultSettingPublic_Result, SelectListItem>)((WSspSelectOrderDefaultSettingPublic_Result item) => new SelectListItem
			{
				Text = item.SettingTitle + ((!string.IsNullOrWhiteSpace(item.ReferUser)) ? (" (" + item.ReferUser + ")") : ""),
				Value = item.OrderSettingID.ToString(),
				Selected = false
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
	public JsonResult GetEmailUsersInfo()
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
			list.AddRange(Enumerable.Select<EmailspSelectAllActiveEmailUsersInfo_Result, SelectListItem>((IEnumerable<EmailspSelectAllActiveEmailUsersInfo_Result>)list2, (Func<EmailspSelectAllActiveEmailUsersInfo_Result, SelectListItem>)((EmailspSelectAllActiveEmailUsersInfo_Result item) => new SelectListItem
			{
				Text = item.euUserName + ((!string.IsNullOrWhiteSpace(item.euUser)) ? (" (" + item.euUser + ")") : ""),
				Value = item.EmailUsersInfoId.ToString(),
				Selected = false
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
	public List<CRMspSelectActiveEventPolicyReceivers_Result> GetActiveEventPolicyReceiversList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectActiveEventPolicyReceivers_Result> list = new List<CRMspSelectActiveEventPolicyReceivers_Result>();
		try
		{
			list = Enumerable.ToList<CRMspSelectActiveEventPolicyReceivers_Result>((IEnumerable<CRMspSelectActiveEventPolicyReceivers_Result>)_dbI.CRMspSelectActiveEventPolicyReceivers(lCID, result));
			if (list == null)
			{
				list = new List<CRMspSelectActiveEventPolicyReceivers_Result>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public JsonResult GetPrjTitleGroup(string textValue)
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
			textValue = textValue ?? "";
			List<CRMspSearchProjectTitleGroup_Result> list2 = Enumerable.ToList<CRMspSearchProjectTitleGroup_Result>((IEnumerable<CRMspSearchProjectTitleGroup_Result>)_dbI.CRMspSearchProjectTitleGroup(textValue, lCID, result));
			list.AddRange(Enumerable.Select<CRMspSearchProjectTitleGroup_Result, SelectListItem>((IEnumerable<CRMspSearchProjectTitleGroup_Result>)list2, (Func<CRMspSearchProjectTitleGroup_Result, SelectListItem>)((CRMspSearchProjectTitleGroup_Result item) => new SelectListItem
			{
				Text = (item.ProjectTitleGroup ?? ""),
				Value = item.ProjectTitleGroupId.ToString(),
				Selected = false
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
	public JsonResult GetPrjTitle(string textValue)
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
			textValue = textValue ?? "";
			List<CRMspSelectProjectTitles_Result> list2 = Enumerable.ToList<CRMspSelectProjectTitles_Result>((IEnumerable<CRMspSelectProjectTitles_Result>)_db.CRMspSelectProjectTitles(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectProjectTitles_Result, SelectListItem>((IEnumerable<CRMspSelectProjectTitles_Result>)list2, (Func<CRMspSelectProjectTitles_Result, SelectListItem>)((CRMspSelectProjectTitles_Result item) => new SelectListItem
			{
				Text = (item.ProjectTitle ?? ""),
				Value = item.ProjectTitleID.ToString(),
				Selected = false
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

	public void SetCnvsStatusResultRegisterInfo(CrmConversationStatusResultLanguageViewModel model, ref string firstRegInfo, ref string regInfo)
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

	[DynamicAuthorize(ControllerName = "frmDefinecnvsStatus", ActionName = "actAddCnvsStatusResult,actEditCnvsStatusResult")]
	public ActionResult InsertEdit(int cnvsStatusGroupId, int cnvsStatusId, int cnvsStatusResultId = 0)
	{
		//IL_1315: Unknown result type (might be due to invalid IL or missing references)
		//IL_14cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_16bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e6f: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass34_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass34_0();
		CS_0024_003C_003E8__locals0.cnvsStatusResultId = cnvsStatusResultId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		CrmConversationStatusResultLanguageViewModel crmConversationStatusResultLanguageViewModel = new CrmConversationStatusResultLanguageViewModel();
		try
		{
			GetLangList();
			DateTime now = DateTime.Now;
			if (CS_0024_003C_003E8__locals0.cnvsStatusResultId == 0)
			{
				if (!UserLogin.IsUserAccess("frmDefinecnvsStatus", "actAddCnvsStatusResult", UserLogin.CurrentUser))
				{
					return RedirectToAction("Login", "Account", (object)new
					{
						area = "",
						d = DateTime.Now
					});
				}
				crmConversationStatusResultLanguageViewModel.ConversationStatusGroupId = cnvsStatusGroupId;
				crmConversationStatusResultLanguageViewModel.ConversationStatusId = cnvsStatusId;
				crmConversationStatusResultLanguageViewModel.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
				crmConversationStatusResultLanguageViewModel.FirstRegisterDate = now;
				crmConversationStatusResultLanguageViewModel.UserId = UserLogin.CurrentUser.UserId;
				crmConversationStatusResultLanguageViewModel.RegisterDate = now;
				crmConversationStatusResultLanguageViewModel.AppType = Configuration.AppType;
				CRMspSelectActiveEventPolicyTypesByPartName_Result cRMspSelectActiveEventPolicyTypesByPartName_Result = Enumerable.FirstOrDefault<CRMspSelectActiveEventPolicyTypesByPartName_Result>((IEnumerable<CRMspSelectActiveEventPolicyTypesByPartName_Result>)_dbI.CRMspSelectActiveEventPolicyTypesByPartName("OTP", CS_0024_003C_003E8__locals0.currLangID, CS_0024_003C_003E8__locals0.defLangID));
				if (cRMspSelectActiveEventPolicyTypesByPartName_Result != null)
				{
					CrmConversationStatusResultEventPolicyLanguageViewModel value = new CrmConversationStatusResultEventPolicyLanguageViewModel
					{
						ConversationStatusResultEventPolicyId = 0,
						ConversationStatusGroupId = cnvsStatusGroupId,
						ConversationStatusId = cnvsStatusId,
						ConversationStatusResultId = 0,
						EventPolicyTypeId = cRMspSelectActiveEventPolicyTypesByPartName_Result.EventPolicyTypeId,
						EventPolicyType = (cRMspSelectActiveEventPolicyTypesByPartName_Result.ActTitle ?? ""),
						EventPolicyReceiverId = null,
						EventPolicyReceiver = "",
						EventPolicyReceiverUsers = "",
						EventPolicyReceiverPrsJobs = "",
						EventPolicySetting = cRMspSelectActiveEventPolicyTypesByPartName_Result.JsonSetting,
						EventPolicySendTimeType = null,
						EventPolicySendTimeValue = null,
						EventPolicySendTimeValueII = null,
						EventPolicyUserCheckBeforeSend = false,
						EventPolicyShortDescription = "",
						EventPolicyBigDescription = "",
						Mode = 1,
						PartName = cRMspSelectActiveEventPolicyTypesByPartName_Result.PartName,
						HasSetting = false,
						DeActive = false,
						Row = 1,
						ActName = cRMspSelectActiveEventPolicyTypesByPartName_Result.ActName,
						EventPolicySetting_Lang = "",
						EventPolicyShortDescription_Lang = "",
						EventPolicyBigDescription_Lang = ""
					};
					crmConversationStatusResultLanguageViewModel.OTPJson = "[" + JsonConvert.SerializeObject(value) + "]";
					if (!string.IsNullOrWhiteSpace(crmConversationStatusResultLanguageViewModel.OTPJson))
					{
						crmConversationStatusResultLanguageViewModel.OTPJson = crmConversationStatusResultLanguageViewModel.OTPJson.Replace("\\\"", "\\\\\\\"");
					}
				}
				CRMspSelectActiveEventPolicyTypesByPartName_Result cRMspSelectActiveEventPolicyTypesByPartName_Result2 = Enumerable.FirstOrDefault<CRMspSelectActiveEventPolicyTypesByPartName_Result>((IEnumerable<CRMspSelectActiveEventPolicyTypesByPartName_Result>)_dbI.CRMspSelectActiveEventPolicyTypesByPartName("PORD", CS_0024_003C_003E8__locals0.currLangID, CS_0024_003C_003E8__locals0.defLangID));
				if (cRMspSelectActiveEventPolicyTypesByPartName_Result2 != null)
				{
					CrmConversationStatusResultEventPolicyLanguageViewModel value2 = new CrmConversationStatusResultEventPolicyLanguageViewModel
					{
						ConversationStatusResultEventPolicyId = 0,
						ConversationStatusGroupId = cnvsStatusGroupId,
						ConversationStatusId = cnvsStatusId,
						ConversationStatusResultId = 0,
						EventPolicyTypeId = cRMspSelectActiveEventPolicyTypesByPartName_Result2.EventPolicyTypeId,
						EventPolicyType = (cRMspSelectActiveEventPolicyTypesByPartName_Result2.ActTitle ?? ""),
						EventPolicyReceiverId = null,
						EventPolicyReceiver = "",
						EventPolicyReceiverUsers = "",
						EventPolicyReceiverPrsJobs = "",
						EventPolicySetting = cRMspSelectActiveEventPolicyTypesByPartName_Result2.JsonSetting,
						EventPolicySendTimeType = null,
						EventPolicySendTimeValue = null,
						EventPolicySendTimeValueII = null,
						EventPolicyUserCheckBeforeSend = false,
						EventPolicyShortDescription = "",
						EventPolicyBigDescription = "",
						Mode = 1,
						PartName = cRMspSelectActiveEventPolicyTypesByPartName_Result2.PartName,
						HasSetting = false,
						DeActive = false,
						Row = 1,
						ActName = cRMspSelectActiveEventPolicyTypesByPartName_Result2.ActName,
						EventPolicySetting_Lang = "",
						EventPolicyShortDescription_Lang = "",
						EventPolicyBigDescription_Lang = ""
					};
					crmConversationStatusResultLanguageViewModel.IssuePordJson = "[" + JsonConvert.SerializeObject(value2) + "]";
					if (!string.IsNullOrWhiteSpace(crmConversationStatusResultLanguageViewModel.IssuePordJson))
					{
						crmConversationStatusResultLanguageViewModel.IssuePordJson = crmConversationStatusResultLanguageViewModel.IssuePordJson.Replace("\\\"", "\\\\\\\"");
					}
				}
				CRMspSelectActiveEventPolicyTypesByPartName_Result cRMspSelectActiveEventPolicyTypesByPartName_Result3 = Enumerable.FirstOrDefault<CRMspSelectActiveEventPolicyTypesByPartName_Result>((IEnumerable<CRMspSelectActiveEventPolicyTypesByPartName_Result>)_dbI.CRMspSelectActiveEventPolicyTypesByPartName("ORD", CS_0024_003C_003E8__locals0.currLangID, CS_0024_003C_003E8__locals0.defLangID));
				if (cRMspSelectActiveEventPolicyTypesByPartName_Result3 != null)
				{
					CrmConversationStatusResultEventPolicyLanguageViewModel value3 = new CrmConversationStatusResultEventPolicyLanguageViewModel
					{
						ConversationStatusResultEventPolicyId = 0,
						ConversationStatusGroupId = cnvsStatusGroupId,
						ConversationStatusId = cnvsStatusId,
						ConversationStatusResultId = 0,
						EventPolicyTypeId = cRMspSelectActiveEventPolicyTypesByPartName_Result3.EventPolicyTypeId,
						EventPolicyType = (cRMspSelectActiveEventPolicyTypesByPartName_Result3.ActTitle ?? ""),
						EventPolicyReceiverId = null,
						EventPolicyReceiver = "",
						EventPolicyReceiverUsers = "",
						EventPolicyReceiverPrsJobs = "",
						EventPolicySetting = cRMspSelectActiveEventPolicyTypesByPartName_Result3.JsonSetting,
						EventPolicySendTimeType = null,
						EventPolicySendTimeValue = null,
						EventPolicySendTimeValueII = null,
						EventPolicyUserCheckBeforeSend = false,
						EventPolicyShortDescription = "",
						EventPolicyBigDescription = "",
						Mode = 1,
						PartName = cRMspSelectActiveEventPolicyTypesByPartName_Result3.PartName,
						HasSetting = false,
						DeActive = false,
						Row = 1,
						ActName = cRMspSelectActiveEventPolicyTypesByPartName_Result3.ActName,
						EventPolicySetting_Lang = "",
						EventPolicyShortDescription_Lang = "",
						EventPolicyBigDescription_Lang = ""
					};
					crmConversationStatusResultLanguageViewModel.IssueOrdJson = "[" + JsonConvert.SerializeObject(value3) + "]";
					if (!string.IsNullOrWhiteSpace(crmConversationStatusResultLanguageViewModel.IssueOrdJson))
					{
						crmConversationStatusResultLanguageViewModel.IssueOrdJson = crmConversationStatusResultLanguageViewModel.IssueOrdJson.Replace("\\\"", "\\\\\\\"");
					}
				}
				CRMspSelectActiveEventPolicyTypesByPartName_Result cRMspSelectActiveEventPolicyTypesByPartName_Result4 = Enumerable.FirstOrDefault<CRMspSelectActiveEventPolicyTypesByPartName_Result>((IEnumerable<CRMspSelectActiveEventPolicyTypesByPartName_Result>)_dbI.CRMspSelectActiveEventPolicyTypesByPartName("DYFORM", CS_0024_003C_003E8__locals0.currLangID, CS_0024_003C_003E8__locals0.defLangID));
				if (cRMspSelectActiveEventPolicyTypesByPartName_Result4 != null)
				{
					CrmConversationStatusResultEventPolicyLanguageViewModel value4 = new CrmConversationStatusResultEventPolicyLanguageViewModel
					{
						ConversationStatusResultEventPolicyId = 0,
						ConversationStatusGroupId = cnvsStatusGroupId,
						ConversationStatusId = cnvsStatusId,
						ConversationStatusResultId = 0,
						EventPolicyTypeId = cRMspSelectActiveEventPolicyTypesByPartName_Result4.EventPolicyTypeId,
						EventPolicyType = (cRMspSelectActiveEventPolicyTypesByPartName_Result4.ActTitle ?? ""),
						EventPolicyReceiverId = null,
						EventPolicyReceiver = "",
						EventPolicyReceiverUsers = "",
						EventPolicyReceiverPrsJobs = "",
						EventPolicySetting = cRMspSelectActiveEventPolicyTypesByPartName_Result4.JsonSetting,
						EventPolicySendTimeType = null,
						EventPolicySendTimeValue = null,
						EventPolicySendTimeValueII = null,
						EventPolicyUserCheckBeforeSend = false,
						EventPolicyShortDescription = "",
						EventPolicyBigDescription = "",
						Mode = 1,
						PartName = cRMspSelectActiveEventPolicyTypesByPartName_Result4.PartName,
						HasSetting = false,
						DeActive = false,
						Row = 1,
						ActName = cRMspSelectActiveEventPolicyTypesByPartName_Result4.ActName,
						EventPolicySetting_Lang = "",
						EventPolicyShortDescription_Lang = "",
						EventPolicyBigDescription_Lang = ""
					};
					crmConversationStatusResultLanguageViewModel.IssueDyFormJson = "[" + JsonConvert.SerializeObject(value4) + "]";
					if (!string.IsNullOrWhiteSpace(crmConversationStatusResultLanguageViewModel.IssueDyFormJson))
					{
						crmConversationStatusResultLanguageViewModel.IssueDyFormJson = crmConversationStatusResultLanguageViewModel.IssueDyFormJson.Replace("\\\"", "\\\\\\\"");
					}
				}
				CRMspSelectActiveEventPolicyTypesByPartName_Result cRMspSelectActiveEventPolicyTypesByPartName_Result5 = Enumerable.FirstOrDefault<CRMspSelectActiveEventPolicyTypesByPartName_Result>((IEnumerable<CRMspSelectActiveEventPolicyTypesByPartName_Result>)_dbI.CRMspSelectActiveEventPolicyTypesByPartName("FO", CS_0024_003C_003E8__locals0.currLangID, CS_0024_003C_003E8__locals0.defLangID));
				if (cRMspSelectActiveEventPolicyTypesByPartName_Result5 != null)
				{
					CrmConversationStatusResultEventPolicyLanguageViewModel value5 = new CrmConversationStatusResultEventPolicyLanguageViewModel
					{
						ConversationStatusResultEventPolicyId = 0,
						ConversationStatusGroupId = cnvsStatusGroupId,
						ConversationStatusId = cnvsStatusId,
						ConversationStatusResultId = 0,
						EventPolicyTypeId = cRMspSelectActiveEventPolicyTypesByPartName_Result5.EventPolicyTypeId,
						EventPolicyType = (cRMspSelectActiveEventPolicyTypesByPartName_Result5.ActTitle ?? ""),
						EventPolicyReceiverId = null,
						EventPolicyReceiver = "",
						EventPolicyReceiverUsers = "",
						EventPolicyReceiverPrsJobs = "",
						EventPolicySetting = cRMspSelectActiveEventPolicyTypesByPartName_Result5.JsonSetting,
						EventPolicySendTimeType = null,
						EventPolicySendTimeValue = null,
						EventPolicySendTimeValueII = null,
						EventPolicyUserCheckBeforeSend = false,
						EventPolicyShortDescription = "",
						EventPolicyBigDescription = "",
						Mode = 1,
						PartName = cRMspSelectActiveEventPolicyTypesByPartName_Result5.PartName,
						HasSetting = false,
						DeActive = false,
						Row = 1,
						ActName = cRMspSelectActiveEventPolicyTypesByPartName_Result5.ActName,
						EventPolicySetting_Lang = "",
						EventPolicyShortDescription_Lang = "",
						EventPolicyBigDescription_Lang = ""
					};
					crmConversationStatusResultLanguageViewModel.FOJson = "[" + JsonConvert.SerializeObject(value5) + "]";
					if (!string.IsNullOrWhiteSpace(crmConversationStatusResultLanguageViewModel.FOJson))
					{
						crmConversationStatusResultLanguageViewModel.FOJson = crmConversationStatusResultLanguageViewModel.FOJson.Replace("\\\"", "\\\\\\\"");
					}
				}
				CRMspSelectActiveEventPolicyTypesByPartName_Result cRMspSelectActiveEventPolicyTypesByPartName_Result6 = Enumerable.FirstOrDefault<CRMspSelectActiveEventPolicyTypesByPartName_Result>((IEnumerable<CRMspSelectActiveEventPolicyTypesByPartName_Result>)_dbI.CRMspSelectActiveEventPolicyTypesByPartName("SHP", CS_0024_003C_003E8__locals0.currLangID, CS_0024_003C_003E8__locals0.defLangID));
				if (cRMspSelectActiveEventPolicyTypesByPartName_Result6 != null)
				{
					CrmConversationStatusResultEventPolicyLanguageViewModel value6 = new CrmConversationStatusResultEventPolicyLanguageViewModel
					{
						ConversationStatusResultEventPolicyId = 0,
						ConversationStatusGroupId = cnvsStatusGroupId,
						ConversationStatusId = cnvsStatusId,
						ConversationStatusResultId = 0,
						EventPolicyTypeId = cRMspSelectActiveEventPolicyTypesByPartName_Result6.EventPolicyTypeId,
						EventPolicyType = (cRMspSelectActiveEventPolicyTypesByPartName_Result6.ActTitle ?? ""),
						EventPolicyReceiverId = null,
						EventPolicyReceiver = "",
						EventPolicyReceiverUsers = "",
						EventPolicyReceiverPrsJobs = "",
						EventPolicySetting = cRMspSelectActiveEventPolicyTypesByPartName_Result6.JsonSetting,
						EventPolicySendTimeType = null,
						EventPolicySendTimeValue = null,
						EventPolicySendTimeValueII = null,
						EventPolicyUserCheckBeforeSend = false,
						EventPolicyShortDescription = "",
						EventPolicyBigDescription = "",
						Mode = 1,
						PartName = cRMspSelectActiveEventPolicyTypesByPartName_Result6.PartName,
						HasSetting = false,
						DeActive = false,
						Row = 1,
						ActName = cRMspSelectActiveEventPolicyTypesByPartName_Result6.ActName,
						EventPolicySetting_Lang = "",
						EventPolicyShortDescription_Lang = "",
						EventPolicyBigDescription_Lang = ""
					};
					crmConversationStatusResultLanguageViewModel.ShpJson = "[" + JsonConvert.SerializeObject(value6) + "]";
					if (!string.IsNullOrWhiteSpace(crmConversationStatusResultLanguageViewModel.ShpJson))
					{
						crmConversationStatusResultLanguageViewModel.ShpJson = crmConversationStatusResultLanguageViewModel.ShpJson.Replace("\\\"", "\\\\\\\"");
					}
				}
				CRMspSelectActiveEventPolicyTypesByPartName_Result cRMspSelectActiveEventPolicyTypesByPartName_Result7 = Enumerable.FirstOrDefault<CRMspSelectActiveEventPolicyTypesByPartName_Result>((IEnumerable<CRMspSelectActiveEventPolicyTypesByPartName_Result>)_dbI.CRMspSelectActiveEventPolicyTypesByPartName("PRJ", CS_0024_003C_003E8__locals0.currLangID, CS_0024_003C_003E8__locals0.defLangID));
				if (cRMspSelectActiveEventPolicyTypesByPartName_Result7 != null)
				{
					CrmConversationStatusResultEventPolicyLanguageViewModel value7 = new CrmConversationStatusResultEventPolicyLanguageViewModel
					{
						ConversationStatusResultEventPolicyId = 0,
						ConversationStatusGroupId = cnvsStatusGroupId,
						ConversationStatusId = cnvsStatusId,
						ConversationStatusResultId = 0,
						EventPolicyTypeId = cRMspSelectActiveEventPolicyTypesByPartName_Result7.EventPolicyTypeId,
						EventPolicyType = (cRMspSelectActiveEventPolicyTypesByPartName_Result7.ActTitle ?? ""),
						EventPolicyReceiverId = null,
						EventPolicyReceiver = "",
						EventPolicyReceiverUsers = "",
						EventPolicyReceiverPrsJobs = "",
						EventPolicySetting = cRMspSelectActiveEventPolicyTypesByPartName_Result7.JsonSetting,
						EventPolicySendTimeType = null,
						EventPolicySendTimeValue = null,
						EventPolicySendTimeValueII = null,
						EventPolicyUserCheckBeforeSend = false,
						EventPolicyShortDescription = "",
						EventPolicyBigDescription = "",
						Mode = 1,
						PartName = cRMspSelectActiveEventPolicyTypesByPartName_Result7.PartName,
						HasSetting = false,
						DeActive = false,
						Row = 1,
						ActName = cRMspSelectActiveEventPolicyTypesByPartName_Result7.ActName,
						EventPolicySetting_Lang = "",
						EventPolicyShortDescription_Lang = "",
						EventPolicyBigDescription_Lang = ""
					};
					crmConversationStatusResultLanguageViewModel.AddPrjJson = "[" + JsonConvert.SerializeObject(value7) + "]";
					if (!string.IsNullOrWhiteSpace(crmConversationStatusResultLanguageViewModel.AddPrjJson))
					{
						crmConversationStatusResultLanguageViewModel.AddPrjJson = crmConversationStatusResultLanguageViewModel.AddPrjJson.Replace("\\\"", "\\\\\\\"");
					}
				}
				List<CRMspSelectConversationStatusResult_Result> list = Enumerable.ToList<CRMspSelectConversationStatusResult_Result>((IEnumerable<CRMspSelectConversationStatusResult_Result>)_dbI.CRMspSelectConversationStatusResult(cnvsStatusId, CS_0024_003C_003E8__locals0.currLangID, CS_0024_003C_003E8__locals0.defLangID));
				if (!Enumerable.Any<CRMspSelectConversationStatusResult_Result>((IEnumerable<CRMspSelectConversationStatusResult_Result>)list))
				{
					crmConversationStatusResultLanguageViewModel.OrderView = 10;
				}
				else
				{
					int num = (Enumerable.Any<CRMspSelectConversationStatusResult_Result>((IEnumerable<CRMspSelectConversationStatusResult_Result>)list) ? Enumerable.Count<CRMspSelectConversationStatusResult_Result>((IEnumerable<CRMspSelectConversationStatusResult_Result>)list) : 0);
					crmConversationStatusResultLanguageViewModel.OrderView = num * 10 + 10;
					if (Enumerable.LastOrDefault<CRMspSelectConversationStatusResult_Result>((IEnumerable<CRMspSelectConversationStatusResult_Result>)list) != null)
					{
						int valueOrDefault = Enumerable.LastOrDefault<CRMspSelectConversationStatusResult_Result>((IEnumerable<CRMspSelectConversationStatusResult_Result>)list).OrderView.GetValueOrDefault();
						if (valueOrDefault > 0)
						{
							crmConversationStatusResultLanguageViewModel.OrderView = valueOrDefault + 10;
						}
					}
				}
			}
			else
			{
				if (!UserLogin.IsUserAccess("frmDefinecnvsStatus", "actEditCnvsStatusResult", UserLogin.CurrentUser))
				{
					return RedirectToAction("Login", "Account", (object)new
					{
						area = "",
						d = DateTime.Now
					});
				}
				DbSet<CrmConversationStatusResult_Lang> crmConversationStatusResult_Lang = _dbTbl.CrmConversationStatusResult_Lang;
				ParameterExpression val = Expression.Parameter(typeof(CrmConversationStatusResult_Lang), "c");
				List<CrmConversationStatusResult_Lang> list2 = Enumerable.ToList<CrmConversationStatusResult_Lang>((IEnumerable<CrmConversationStatusResult_Lang>)Queryable.Where<CrmConversationStatusResult_Lang>((IQueryable<CrmConversationStatusResult_Lang>)crmConversationStatusResult_Lang, Expression.Lambda<Func<CrmConversationStatusResult_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass34_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				CRMspSelectConversationStatusResultById_Result cRMspSelectConversationStatusResultById_Result = Enumerable.FirstOrDefault<CRMspSelectConversationStatusResultById_Result>((IEnumerable<CRMspSelectConversationStatusResultById_Result>)_dbI.CRMspSelectConversationStatusResultById(CS_0024_003C_003E8__locals0.cnvsStatusResultId, CS_0024_003C_003E8__locals0.defLangID, CS_0024_003C_003E8__locals0.defLangID));
				if (cRMspSelectConversationStatusResultById_Result != null)
				{
					List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmConversationStatusResult_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmConversationStatusResult_Lang>)list2, (Func<CrmConversationStatusResult_Lang, CommonMultiLanguageViewModel>)((CrmConversationStatusResult_Lang item) => new CommonMultiLanguageViewModel
					{
						Value = item.ResultTitle,
						LanguageId = item.LanguageID
					})));
					list3.Add(new CommonMultiLanguageViewModel
					{
						Value = cRMspSelectConversationStatusResultById_Result.ResultTitle,
						LanguageId = CS_0024_003C_003E8__locals0.defLangID
					});
					List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmConversationStatusResult_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmConversationStatusResult_Lang>)list2, (Func<CrmConversationStatusResult_Lang, CommonMultiLanguageViewModel>)((CrmConversationStatusResult_Lang item) => new CommonMultiLanguageViewModel
					{
						Value = item.ResultDesc,
						LanguageId = item.LanguageID
					})));
					list4.Add(new CommonMultiLanguageViewModel
					{
						Value = cRMspSelectConversationStatusResultById_Result.ResultDesc,
						LanguageId = CS_0024_003C_003E8__locals0.defLangID
					});
					List<CommonMultiLanguageViewModel> list5 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmConversationStatusResult_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmConversationStatusResult_Lang>)list2, (Func<CrmConversationStatusResult_Lang, CommonMultiLanguageViewModel>)((CrmConversationStatusResult_Lang item) => new CommonMultiLanguageViewModel
					{
						Value = item.CnvsDesc,
						LanguageId = item.LanguageID
					})));
					list5.Add(new CommonMultiLanguageViewModel
					{
						Value = cRMspSelectConversationStatusResultById_Result.CnvsDesc,
						LanguageId = CS_0024_003C_003E8__locals0.defLangID
					});
					List<CommonMultiLanguageViewModel> list6 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmConversationStatusResult_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmConversationStatusResult_Lang>)list2, (Func<CrmConversationStatusResult_Lang, CommonMultiLanguageViewModel>)((CrmConversationStatusResult_Lang item) => new CommonMultiLanguageViewModel
					{
						Value = item.CnvsReferDesc,
						LanguageId = item.LanguageID
					})));
					list6.Add(new CommonMultiLanguageViewModel
					{
						Value = cRMspSelectConversationStatusResultById_Result.CnvsReferDesc,
						LanguageId = CS_0024_003C_003E8__locals0.defLangID
					});
					crmConversationStatusResultLanguageViewModel = new CrmConversationStatusResultLanguageViewModel
					{
						ConversationStatusResultId = cRMspSelectConversationStatusResultById_Result.ConversationStatusResultId,
						ConversationStatusGroupId = cRMspSelectConversationStatusResultById_Result.ConversationStatusGroupId,
						ConversationStatusId = cRMspSelectConversationStatusResultById_Result.ConversationStatusId,
						ResultTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
						ResultTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
						ResultDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
						ResultDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
						EventPolicyActive = cRMspSelectConversationStatusResultById_Result.EventPolicyActive,
						OTPSendActive = cRMspSelectConversationStatusResultById_Result.OTPSendActive,
						IssuePordActive = cRMspSelectConversationStatusResultById_Result.IssuePordActive,
						IssueOrdActive = cRMspSelectConversationStatusResultById_Result.IssueOrdActive,
						IssueDyFormActive = cRMspSelectConversationStatusResultById_Result.IssueDyFormActive,
						NeedDyFormChecked = cRMspSelectConversationStatusResultById_Result.NeedDyFormChecked,
						NeedDyFormCheckedFormId = cRMspSelectConversationStatusResultById_Result.NeedDyFormCheckedFormId,
						PrjFinished = cRMspSelectConversationStatusResultById_Result.PrjFinished,
						NoCnvsDup = cRMspSelectConversationStatusResultById_Result.NoCnvsDup,
						StatusResultUsedUserIds = cRMspSelectConversationStatusResultById_Result.StatusResultUsedUserIds,
						StatusResultUsedUsersjson = cRMspSelectConversationStatusResultById_Result.StatusResultUsedUsersJson,
						DoingTimeEndDeadlineMin = cRMspSelectConversationStatusResultById_Result.DoingTimeEndDeadlineMin,
						DoingTimeEndCnvsStatusId = cRMspSelectConversationStatusResultById_Result.DoingTimeEndCnvsStatusId,
						DoingTimeEndCnvsStatusResultId = cRMspSelectConversationStatusResultById_Result.DoingTimeEndCnvsStatusResultId,
						CnvsCountLimit = cRMspSelectConversationStatusResultById_Result.CnvsCountLimit,
						CnvsDoingTimeLimit = cRMspSelectConversationStatusResultById_Result.CnvsDoingTimeLimit,
						CnvsDoingTimeNotNull = cRMspSelectConversationStatusResultById_Result.CnvsDoingTimeNotNull,
						CnvsRemindDateNotNull = cRMspSelectConversationStatusResultById_Result.CnvsRemindDateNotNull,
						CnvsRemindDateForAllarmNotNull = cRMspSelectConversationStatusResultById_Result.CnvsRemindDateForAllarmNotNull,
						CnvsTopicId = cRMspSelectConversationStatusResultById_Result.CnvsTopicId,
						CnvsReferUserId = cRMspSelectConversationStatusResultById_Result.CnvsReferUserId,
						CnvsReferUserNoChange = cRMspSelectConversationStatusResultById_Result.CnvsReferUserNoChange,
						CnvsRemindDay = cRMspSelectConversationStatusResultById_Result.CnvsRemindDay,
						CnvsDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
						CnvsDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
						CnvsReferDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
						CnvsReferDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
						IsDefault = cRMspSelectConversationStatusResultById_Result.IsDefault,
						DeActive = cRMspSelectConversationStatusResultById_Result.DeActive,
						OrderView = cRMspSelectConversationStatusResultById_Result.OrderView,
						UpdateCmpGroupActive = cRMspSelectConversationStatusResultById_Result.UpdateCmpGroupActive,
						UpdateCmpGroupActiveJson = cRMspSelectConversationStatusResultById_Result.UpdateCmpGroupActiveJson,
						EventPolicyJson = cRMspSelectConversationStatusResultById_Result.EventPolicyJson,
						FirstRegisterUserId = cRMspSelectConversationStatusResultById_Result.FirstRegisterUserId,
						FirstRegisterDate = cRMspSelectConversationStatusResultById_Result.FirstRegisterDate,
						UserId = cRMspSelectConversationStatusResultById_Result.UserId,
						RegisterDate = cRMspSelectConversationStatusResultById_Result.RegisterDate,
						AppType = cRMspSelectConversationStatusResultById_Result.AppType,
						AddPrjActive = cRMspSelectConversationStatusResultById_Result.AddPrjActive,
						CnvsNoNeedRemindDateAlert = cRMspSelectConversationStatusResultById_Result.CnvsNoNeedRemindDateAlert
					};
					if (crmConversationStatusResultLanguageViewModel != null)
					{
						if (!string.IsNullOrWhiteSpace(crmConversationStatusResultLanguageViewModel.UpdateCmpGroupActiveJson))
						{
							CrmConversationStatusResultUpdateCmpGroupActiveViewModel crmConversationStatusResultUpdateCmpGroupActiveViewModel = new JavaScriptSerializer().Deserialize<CrmConversationStatusResultUpdateCmpGroupActiveViewModel>(crmConversationStatusResultLanguageViewModel.UpdateCmpGroupActiveJson.Replace("[", "").Replace("]", ""));
							if (crmConversationStatusResultUpdateCmpGroupActiveViewModel != null)
							{
								int result = 0;
								int.TryParse(crmConversationStatusResultUpdateCmpGroupActiveViewModel.cmpGroupId.ToString(), out result);
								if (result != 0)
								{
									crmConversationStatusResultLanguageViewModel.CmpGroupId = result;
									crmConversationStatusResultLanguageViewModel.IsUpdateCmpGroup = true;
								}
								int result2 = 0;
								int.TryParse(crmConversationStatusResultUpdateCmpGroupActiveViewModel.cmpSubGroupId.ToString(), out result2);
								if (result2 != 0)
								{
									crmConversationStatusResultLanguageViewModel.CmpSubGroupId = result2;
									crmConversationStatusResultLanguageViewModel.IsUpdateCmpSubGroup = true;
								}
								int result3 = 0;
								int.TryParse(crmConversationStatusResultUpdateCmpGroupActiveViewModel.cmpGroupIIId.ToString(), out result3);
								if (result3 != 0)
								{
									crmConversationStatusResultLanguageViewModel.CmpGroupIIId = result3;
									crmConversationStatusResultLanguageViewModel.IsUpdateCmpGroupII = true;
								}
								int result4 = 0;
								int.TryParse(crmConversationStatusResultUpdateCmpGroupActiveViewModel.cmpGroupIIIId.ToString(), out result4);
								if (result4 != 0)
								{
									crmConversationStatusResultLanguageViewModel.CmpGroupIIIId = result4;
									crmConversationStatusResultLanguageViewModel.IsUpdateCmpGroupIII = true;
								}
								int result5 = 0;
								int.TryParse(crmConversationStatusResultUpdateCmpGroupActiveViewModel.cmpGroupIVId.ToString(), out result5);
								if (result5 != 0)
								{
									crmConversationStatusResultLanguageViewModel.CmpGroupIVId = result5;
									crmConversationStatusResultLanguageViewModel.IsUpdateCmpGroupIV = true;
								}
								int result6 = 0;
								int.TryParse(crmConversationStatusResultUpdateCmpGroupActiveViewModel.cmpTypeId.ToString(), out result6);
								if (result6 != 0)
								{
									crmConversationStatusResultLanguageViewModel.CmpTypeId = result6;
									crmConversationStatusResultLanguageViewModel.IsUpdateCmpType = true;
								}
							}
						}
						if (!string.IsNullOrWhiteSpace(crmConversationStatusResultLanguageViewModel.StatusResultUsedUsersjson))
						{
							List<CrmConversationStatusResultStatusResultUsedUsersViewModel> list7 = new JavaScriptSerializer().Deserialize<List<CrmConversationStatusResultStatusResultUsedUsersViewModel>>(crmConversationStatusResultLanguageViewModel.StatusResultUsedUsersjson);
							if (list7 != null)
							{
								crmConversationStatusResultLanguageViewModel.StatusResultUsedUsersjson = JsonConvert.SerializeObject(Enumerable.ToList<CrmConversationStatusResultStatusResultUsedUsersViewModel>((IEnumerable<CrmConversationStatusResultStatusResultUsedUsersViewModel>)list7));
							}
						}
						List<CrmConversationStatusResultEventPolicyLanguageViewModel> list8 = new List<CrmConversationStatusResultEventPolicyLanguageViewModel>();
						CrmConversationStatusResultEventPolicyLanguageViewModel crmConversationStatusResultEventPolicyLanguageViewModel = new CrmConversationStatusResultEventPolicyLanguageViewModel();
						CrmConversationStatusResultEventPolicyLanguageViewModel crmConversationStatusResultEventPolicyLanguageViewModel2 = new CrmConversationStatusResultEventPolicyLanguageViewModel();
						CrmConversationStatusResultEventPolicyLanguageViewModel crmConversationStatusResultEventPolicyLanguageViewModel3 = new CrmConversationStatusResultEventPolicyLanguageViewModel();
						CrmConversationStatusResultEventPolicyLanguageViewModel crmConversationStatusResultEventPolicyLanguageViewModel4 = new CrmConversationStatusResultEventPolicyLanguageViewModel();
						CrmConversationStatusResultEventPolicyLanguageViewModel crmConversationStatusResultEventPolicyLanguageViewModel5 = new CrmConversationStatusResultEventPolicyLanguageViewModel();
						CrmConversationStatusResultEventPolicyLanguageViewModel crmConversationStatusResultEventPolicyLanguageViewModel6 = new CrmConversationStatusResultEventPolicyLanguageViewModel();
						CrmConversationStatusResultEventPolicyLanguageViewModel crmConversationStatusResultEventPolicyLanguageViewModel7 = new CrmConversationStatusResultEventPolicyLanguageViewModel();
						List<CRMspSelectConversationStatusResultEventPolicyByCnvsStatusResultId_Result> list9 = Enumerable.ToList<CRMspSelectConversationStatusResultEventPolicyByCnvsStatusResultId_Result>((IEnumerable<CRMspSelectConversationStatusResultEventPolicyByCnvsStatusResultId_Result>)_dbI.CRMspSelectConversationStatusResultEventPolicyByCnvsStatusResultId(crmConversationStatusResultLanguageViewModel.ConversationStatusResultId, CS_0024_003C_003E8__locals0.currLangID, CS_0024_003C_003E8__locals0.defLangID));
						if (list9 != null && Enumerable.Any<CRMspSelectConversationStatusResultEventPolicyByCnvsStatusResultId_Result>((IEnumerable<CRMspSelectConversationStatusResultEventPolicyByCnvsStatusResultId_Result>)list9))
						{
							int num2 = 1;
							foreach (CRMspSelectConversationStatusResultEventPolicyByCnvsStatusResultId_Result item in list9)
							{
								CrmConversationStatusResultEventPolicyLanguageViewModel crmConversationStatusResultEventPolicyLanguageViewModel8 = new CrmConversationStatusResultEventPolicyLanguageViewModel
								{
									ConversationStatusResultEventPolicyId = item.ConversationStatusResultEventPolicyId,
									ConversationStatusGroupId = item.ConversationStatusGroupId,
									ConversationStatusId = item.ConversationStatusId,
									ConversationStatusResultId = item.ConversationStatusResultId,
									EventPolicyTypeId = item.EventPolicyTypeId,
									EventPolicyType = item.EventPolicyTypeActTitle,
									EventPolicyReceiverId = item.EventPolicyReceiverId,
									EventPolicyReceiver = item.EventPolicyReceiver,
									EventPolicySetting = item.EventPolicySetting,
									EventPolicySendTimeType = item.EventPolicySendTimeType,
									EventPolicySendTimeValue = item.EventPolicySendTimeValue,
									EventPolicySendTimeValueII = item.EventPolicySendTimeValueII,
									EventPolicyUserCheckBeforeSend = item.EventPolicyUserCheckBeforeSend,
									EventPolicyShortDescription = item.EventPolicyShortDescription,
									EventPolicyBigDescription = item.EventPolicyBigDescription,
									DeActive = item.DeActive,
									PartName = item.EventPolicyTypePartName,
									HasSetting = true,
									ActName = item.EventPolicyTypeActName,
									EventPolicyDescription_Lang = item.ConversationStatusResultEventPolicyLang
								};
								if (!string.IsNullOrWhiteSpace(item.EventPolicySetting))
								{
									string text = item.EventPolicySetting.Replace("\\", "");
									List<object> list10 = new JavaScriptSerializer().Deserialize<List<object>>(text);
									if (list10 != null && Enumerable.Any<object>((IEnumerable<object>)list10))
									{
										for (int i = 0; i < list10.Count; i++)
										{
											if (_003C_003Eo__34._003C_003Ep__5 == null)
											{
												_003C_003Eo__34._003C_003Ep__5 = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)83, typeof(ConversationStatusResultController), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
											}
											Func<CallSite, object, bool> target = _003C_003Eo__34._003C_003Ep__5.Target;
											CallSite<Func<CallSite, object, bool>> _003C_003Ep__ = _003C_003Eo__34._003C_003Ep__5;
											if (_003C_003Eo__34._003C_003Ep__0 == null)
											{
												_003C_003Eo__34._003C_003Ep__0 = CallSite<Func<CallSite, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)35, typeof(ConversationStatusResultController), new CSharpArgumentInfo[2]
												{
													CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
													CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
												}));
											}
											object obj = _003C_003Eo__34._003C_003Ep__0.Target((CallSite)(object)_003C_003Eo__34._003C_003Ep__0, list10[i], null);
											if (_003C_003Eo__34._003C_003Ep__4 == null)
											{
												_003C_003Eo__34._003C_003Ep__4 = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)84, typeof(ConversationStatusResultController), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
											}
											object arg;
											if (!_003C_003Eo__34._003C_003Ep__4.Target((CallSite)(object)_003C_003Eo__34._003C_003Ep__4, obj))
											{
												if (_003C_003Eo__34._003C_003Ep__3 == null)
												{
													_003C_003Eo__34._003C_003Ep__3 = CallSite<Func<CallSite, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, (ExpressionType)2, typeof(ConversationStatusResultController), new CSharpArgumentInfo[2]
													{
														CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
														CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
													}));
												}
												Func<CallSite, object, object, object> target2 = _003C_003Eo__34._003C_003Ep__3.Target;
												CallSite<Func<CallSite, object, object, object>> _003C_003Ep__2 = _003C_003Eo__34._003C_003Ep__3;
												if (_003C_003Eo__34._003C_003Ep__2 == null)
												{
													_003C_003Eo__34._003C_003Ep__2 = CallSite<Func<CallSite, object, int, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)15, typeof(ConversationStatusResultController), new CSharpArgumentInfo[2]
													{
														CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
														CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
													}));
												}
												arg = target2((CallSite)(object)_003C_003Ep__2, obj, _003C_003Eo__34._003C_003Ep__2.Target((CallSite)(object)_003C_003Eo__34._003C_003Ep__2, (object)((dynamic)list10[i]).Count, 0));
											}
											else
											{
												arg = obj;
											}
											if (!target((CallSite)(object)_003C_003Ep__, arg))
											{
												continue;
											}
											foreach (dynamic item2 in (dynamic)list10[i])
											{
												dynamic val2 = item2.Key;
												dynamic val3 = item2.Value;
												if (_003C_003Eo__34._003C_003Ep__10 == null)
												{
													_003C_003Eo__34._003C_003Ep__10 = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)83, typeof(ConversationStatusResultController), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
												}
												Func<CallSite, object, bool> target3 = _003C_003Eo__34._003C_003Ep__10.Target;
												CallSite<Func<CallSite, object, bool>> _003C_003Ep__3 = _003C_003Eo__34._003C_003Ep__10;
												if (_003C_003Eo__34._003C_003Ep__9 == null)
												{
													_003C_003Eo__34._003C_003Ep__9 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)34, typeof(ConversationStatusResultController), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
												}
												if (!target3((CallSite)(object)_003C_003Ep__3, _003C_003Eo__34._003C_003Ep__9.Target((CallSite)(object)_003C_003Eo__34._003C_003Ep__9, (object)string.IsNullOrWhiteSpace(val2))))
												{
													continue;
												}
												switch (val2 as string)
												{
												case "EventPolicyReceiverUsers":
												{
													dynamic val5 = val3.ToString();
													if (_003C_003Eo__34._003C_003Ep__14 == null)
													{
														_003C_003Eo__34._003C_003Ep__14 = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)83, typeof(ConversationStatusResultController), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
													}
													Func<CallSite, object, bool> target5 = _003C_003Eo__34._003C_003Ep__14.Target;
													CallSite<Func<CallSite, object, bool>> _003C_003Ep__5 = _003C_003Eo__34._003C_003Ep__14;
													if (_003C_003Eo__34._003C_003Ep__13 == null)
													{
														_003C_003Eo__34._003C_003Ep__13 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)34, typeof(ConversationStatusResultController), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
													}
													if (target5((CallSite)(object)_003C_003Ep__5, _003C_003Eo__34._003C_003Ep__13.Target((CallSite)(object)_003C_003Eo__34._003C_003Ep__13, (object)string.IsNullOrWhiteSpace(val5))))
													{
														crmConversationStatusResultEventPolicyLanguageViewModel8.EventPolicyReceiverUsers = val5;
													}
													break;
												}
												case "EventPolicyReceiverPrsJobs":
												{
													dynamic val4 = val3.ToString();
													if (_003C_003Eo__34._003C_003Ep__19 == null)
													{
														_003C_003Eo__34._003C_003Ep__19 = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)83, typeof(ConversationStatusResultController), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
													}
													Func<CallSite, object, bool> target4 = _003C_003Eo__34._003C_003Ep__19.Target;
													CallSite<Func<CallSite, object, bool>> _003C_003Ep__4 = _003C_003Eo__34._003C_003Ep__19;
													if (_003C_003Eo__34._003C_003Ep__18 == null)
													{
														_003C_003Eo__34._003C_003Ep__18 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)34, typeof(ConversationStatusResultController), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
													}
													if (target4((CallSite)(object)_003C_003Ep__4, _003C_003Eo__34._003C_003Ep__18.Target((CallSite)(object)_003C_003Eo__34._003C_003Ep__18, (object)string.IsNullOrWhiteSpace(val4))))
													{
														crmConversationStatusResultEventPolicyLanguageViewModel8.EventPolicyReceiverPrsJobs = val4;
													}
													break;
												}
												}
											}
										}
									}
								}
								List<CommonMultiLanguageViewModel> list11 = new List<CommonMultiLanguageViewModel>();
								List<CommonMultiLanguageViewModel> list12 = new List<CommonMultiLanguageViewModel>();
								List<CommonMultiLanguageViewModel> list13 = new List<CommonMultiLanguageViewModel>();
								if (!string.IsNullOrWhiteSpace(crmConversationStatusResultEventPolicyLanguageViewModel8.EventPolicyDescription_Lang))
								{
									List<CrmConversationStatusResultEventPolicy_LangViewModel> list14 = new JavaScriptSerializer().Deserialize<List<CrmConversationStatusResultEventPolicy_LangViewModel>>(crmConversationStatusResultEventPolicyLanguageViewModel8.EventPolicyDescription_Lang);
									if (list14 != null && Enumerable.Any<CrmConversationStatusResultEventPolicy_LangViewModel>((IEnumerable<CrmConversationStatusResultEventPolicy_LangViewModel>)list14))
									{
										list11 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmConversationStatusResultEventPolicy_LangViewModel, CommonMultiLanguageViewModel>((IEnumerable<CrmConversationStatusResultEventPolicy_LangViewModel>)list14, (Func<CrmConversationStatusResultEventPolicy_LangViewModel, CommonMultiLanguageViewModel>)((CrmConversationStatusResultEventPolicy_LangViewModel itemLang) => new CommonMultiLanguageViewModel
										{
											Value = itemLang.EventPolicySetting,
											LanguageId = itemLang.LanguageID
										})));
										list12 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmConversationStatusResultEventPolicy_LangViewModel, CommonMultiLanguageViewModel>((IEnumerable<CrmConversationStatusResultEventPolicy_LangViewModel>)list14, (Func<CrmConversationStatusResultEventPolicy_LangViewModel, CommonMultiLanguageViewModel>)((CrmConversationStatusResultEventPolicy_LangViewModel itemLang) => new CommonMultiLanguageViewModel
										{
											Value = itemLang.EventPolicyShortDescription,
											LanguageId = itemLang.LanguageID
										})));
										list13 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmConversationStatusResultEventPolicy_LangViewModel, CommonMultiLanguageViewModel>((IEnumerable<CrmConversationStatusResultEventPolicy_LangViewModel>)list14, (Func<CrmConversationStatusResultEventPolicy_LangViewModel, CommonMultiLanguageViewModel>)((CrmConversationStatusResultEventPolicy_LangViewModel itemLang) => new CommonMultiLanguageViewModel
										{
											Value = itemLang.EventPolicyBigDescription,
											LanguageId = itemLang.LanguageID
										})));
									}
								}
								list11.Add(new CommonMultiLanguageViewModel
								{
									Value = item.EventPolicySetting,
									LanguageId = CS_0024_003C_003E8__locals0.defLangID
								});
								list12.Add(new CommonMultiLanguageViewModel
								{
									Value = item.EventPolicyShortDescription,
									LanguageId = CS_0024_003C_003E8__locals0.defLangID
								});
								list13.Add(new CommonMultiLanguageViewModel
								{
									Value = item.EventPolicyBigDescription,
									LanguageId = CS_0024_003C_003E8__locals0.defLangID
								});
								crmConversationStatusResultEventPolicyLanguageViewModel8.EventPolicySetting = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : "");
								crmConversationStatusResultEventPolicyLanguageViewModel8.EventPolicyShortDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
								crmConversationStatusResultEventPolicyLanguageViewModel8.EventPolicyBigDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
								crmConversationStatusResultEventPolicyLanguageViewModel8.EventPolicySetting_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.defLangID))));
								crmConversationStatusResultEventPolicyLanguageViewModel8.EventPolicyBigDescription_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
								crmConversationStatusResultEventPolicyLanguageViewModel8.EventPolicyBigDescription_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
								if (crmConversationStatusResultEventPolicyLanguageViewModel8.PartName == "OTP")
								{
									crmConversationStatusResultEventPolicyLanguageViewModel8.Row = 1;
									crmConversationStatusResultEventPolicyLanguageViewModel = crmConversationStatusResultEventPolicyLanguageViewModel8;
								}
								else if (crmConversationStatusResultEventPolicyLanguageViewModel8.PartName == "PORD")
								{
									crmConversationStatusResultEventPolicyLanguageViewModel8.Row = 1;
									crmConversationStatusResultEventPolicyLanguageViewModel2 = crmConversationStatusResultEventPolicyLanguageViewModel8;
								}
								else if (crmConversationStatusResultEventPolicyLanguageViewModel8.PartName == "ORD")
								{
									crmConversationStatusResultEventPolicyLanguageViewModel8.Row = 1;
									crmConversationStatusResultEventPolicyLanguageViewModel3 = crmConversationStatusResultEventPolicyLanguageViewModel8;
								}
								else if (crmConversationStatusResultEventPolicyLanguageViewModel8.PartName == "DYFORM")
								{
									crmConversationStatusResultEventPolicyLanguageViewModel8.Row = 1;
									crmConversationStatusResultEventPolicyLanguageViewModel4 = crmConversationStatusResultEventPolicyLanguageViewModel8;
								}
								else if (crmConversationStatusResultEventPolicyLanguageViewModel8.PartName == "FO")
								{
									crmConversationStatusResultEventPolicyLanguageViewModel8.Row = 1;
									crmConversationStatusResultEventPolicyLanguageViewModel5 = crmConversationStatusResultEventPolicyLanguageViewModel8;
								}
								else if (crmConversationStatusResultEventPolicyLanguageViewModel8.PartName == "SHP")
								{
									crmConversationStatusResultEventPolicyLanguageViewModel8.Row = 1;
									crmConversationStatusResultEventPolicyLanguageViewModel6 = crmConversationStatusResultEventPolicyLanguageViewModel8;
								}
								else if (crmConversationStatusResultEventPolicyLanguageViewModel8.PartName == "PRJ")
								{
									crmConversationStatusResultEventPolicyLanguageViewModel8.Row = 1;
									crmConversationStatusResultEventPolicyLanguageViewModel7 = crmConversationStatusResultEventPolicyLanguageViewModel8;
								}
								else
								{
									crmConversationStatusResultEventPolicyLanguageViewModel8.Row = num2;
									list8.Add(crmConversationStatusResultEventPolicyLanguageViewModel8);
									num2++;
								}
							}
						}
						if (list8 != null)
						{
							crmConversationStatusResultLanguageViewModel.EventPolicyJson = JsonConvert.SerializeObject(Enumerable.ToList<CrmConversationStatusResultEventPolicyLanguageViewModel>((IEnumerable<CrmConversationStatusResultEventPolicyLanguageViewModel>)list8));
						}
						if (crmConversationStatusResultEventPolicyLanguageViewModel != null)
						{
							crmConversationStatusResultLanguageViewModel.OTPJson = "[" + JsonConvert.SerializeObject(crmConversationStatusResultEventPolicyLanguageViewModel) + "]";
							if (!string.IsNullOrWhiteSpace(crmConversationStatusResultLanguageViewModel.OTPJson))
							{
								crmConversationStatusResultLanguageViewModel.OTPJson = crmConversationStatusResultLanguageViewModel.OTPJson.Replace("\\\"", "\\\\\\\"");
							}
						}
						if (crmConversationStatusResultEventPolicyLanguageViewModel2 != null)
						{
							crmConversationStatusResultLanguageViewModel.IssuePordJson = "[" + JsonConvert.SerializeObject(crmConversationStatusResultEventPolicyLanguageViewModel2) + "]";
							if (!string.IsNullOrWhiteSpace(crmConversationStatusResultLanguageViewModel.IssuePordJson))
							{
								crmConversationStatusResultLanguageViewModel.IssuePordJson = crmConversationStatusResultLanguageViewModel.IssuePordJson.Replace("\\\"", "\\\\\\\"");
							}
						}
						if (crmConversationStatusResultEventPolicyLanguageViewModel3 != null)
						{
							crmConversationStatusResultLanguageViewModel.IssueOrdJson = "[" + JsonConvert.SerializeObject(crmConversationStatusResultEventPolicyLanguageViewModel3) + "]";
							if (!string.IsNullOrWhiteSpace(crmConversationStatusResultLanguageViewModel.IssueOrdJson))
							{
								crmConversationStatusResultLanguageViewModel.IssueOrdJson = crmConversationStatusResultLanguageViewModel.IssueOrdJson.Replace("\\\"", "\\\\\\\"");
							}
						}
						if (crmConversationStatusResultEventPolicyLanguageViewModel4 != null)
						{
							crmConversationStatusResultLanguageViewModel.IssueDyFormJson = "[" + JsonConvert.SerializeObject(crmConversationStatusResultEventPolicyLanguageViewModel4) + "]";
							if (!string.IsNullOrWhiteSpace(crmConversationStatusResultLanguageViewModel.IssueDyFormJson))
							{
								crmConversationStatusResultLanguageViewModel.IssueDyFormJson = crmConversationStatusResultLanguageViewModel.IssueDyFormJson.Replace("\\\"", "\\\\\\\"");
							}
						}
						if (crmConversationStatusResultEventPolicyLanguageViewModel5 != null)
						{
							crmConversationStatusResultLanguageViewModel.FOJson = "[" + JsonConvert.SerializeObject(crmConversationStatusResultEventPolicyLanguageViewModel5) + "]";
							if (!string.IsNullOrWhiteSpace(crmConversationStatusResultLanguageViewModel.FOJson))
							{
								crmConversationStatusResultLanguageViewModel.FOJson = crmConversationStatusResultLanguageViewModel.FOJson.Replace("\\\"", "\\\\\\\"");
							}
						}
						if (crmConversationStatusResultEventPolicyLanguageViewModel6 != null)
						{
							crmConversationStatusResultLanguageViewModel.ShpJson = "[" + JsonConvert.SerializeObject(crmConversationStatusResultEventPolicyLanguageViewModel6) + "]";
							if (!string.IsNullOrWhiteSpace(crmConversationStatusResultLanguageViewModel.ShpJson))
							{
								crmConversationStatusResultLanguageViewModel.ShpJson = crmConversationStatusResultLanguageViewModel.ShpJson.Replace("\\\"", "\\\\\\\"");
							}
						}
						if (crmConversationStatusResultEventPolicyLanguageViewModel7 != null)
						{
							crmConversationStatusResultLanguageViewModel.AddPrjJson = "[" + JsonConvert.SerializeObject(crmConversationStatusResultEventPolicyLanguageViewModel7) + "]";
							if (!string.IsNullOrWhiteSpace(crmConversationStatusResultLanguageViewModel.AddPrjJson))
							{
								crmConversationStatusResultLanguageViewModel.AddPrjJson = crmConversationStatusResultLanguageViewModel.AddPrjJson.Replace("\\\"", "\\\\\\\"");
							}
						}
					}
				}
				else
				{
					crmConversationStatusResultLanguageViewModel = new CrmConversationStatusResultLanguageViewModel
					{
						ConversationStatusGroupId = cnvsStatusGroupId,
						ConversationStatusId = cnvsStatusId,
						FirstRegisterUserId = UserLogin.CurrentUser.UserId,
						FirstRegisterDate = now,
						UserId = UserLogin.CurrentUser.UserId,
						RegisterDate = now,
						AppType = Configuration.AppType
					};
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		string firstRegInfo = "";
		string regInfo = "";
		if (crmConversationStatusResultLanguageViewModel != null)
		{
			SetCnvsStatusResultRegisterInfo(crmConversationStatusResultLanguageViewModel, ref firstRegInfo, ref regInfo);
			crmConversationStatusResultLanguageViewModel.FirstRegisterUser = firstRegInfo;
			crmConversationStatusResultLanguageViewModel.EditUser = regInfo;
		}
		return View(crmConversationStatusResultLanguageViewModel);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefineBaseInfoIDataEntry", ActionName = "actPost")]
	public ActionResult InsertEdit(CrmConversationStatusResultLanguageViewModel model)
	{
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		GetLangList();
		if (base.ModelState.IsValid)
		{
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.ResultTitle_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ResultTitle_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = model.ResultTitle,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.ResultDesc_Lang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ResultDesc_Lang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = model.ResultDesc,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.CnvsDesc_Lang))
			{
				list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.CnvsDesc_Lang);
			}
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = model.CnvsDesc,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.CnvsReferDesc_Lang))
			{
				list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.CnvsReferDesc_Lang);
			}
			list4.Add(new CommonMultiLanguageViewModel
			{
				Value = model.CnvsReferDesc,
				LanguageId = lCID
			});
			if (string.IsNullOrWhiteSpace(model.ResultTitle))
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.cnvsStatusResultTitle) + "<br/>";
				num++;
			}
			else if (!checkMultiLanguage(model.ResultTitle, list))
			{
				text = text + string.Format(Messages.CheckFieldInLang, Labels.cnvsStatusResultTitle) + "<br>";
				num++;
			}
			if (model.IsDefault.HasValue && model.IsDefault.GetValueOrDefault())
			{
				CRMspSelectConversationStatusResultIsDefault_Result cRMspSelectConversationStatusResultIsDefault_Result = Enumerable.FirstOrDefault<CRMspSelectConversationStatusResultIsDefault_Result>((IEnumerable<CRMspSelectConversationStatusResultIsDefault_Result>)_dbI.CRMspSelectConversationStatusResultIsDefault(model.ConversationStatusId, lCID, defLangID));
				if (cRMspSelectConversationStatusResultIsDefault_Result != null && cRMspSelectConversationStatusResultIsDefault_Result.ConversationStatusResultId != model.ConversationStatusResultId)
				{
					text = text + string.Format(Messages.msgErrorNotSaveCnvsStatusResultDefault, Labels.cnvsStatusResultDefault, cRMspSelectConversationStatusResultIsDefault_Result.ResultTitle ?? "") + "<br>";
					num++;
				}
			}
			if (model.DeActive.HasValue && model.DeActive == false)
			{
				int num2 = 10;
				List<CRMspSelectActiveConversationStatusResult_Result> list5 = Enumerable.ToList<CRMspSelectActiveConversationStatusResult_Result>((IEnumerable<CRMspSelectActiveConversationStatusResult_Result>)_dbI.CRMspSelectActiveConversationStatusResult(model.ConversationStatusId, lCID, defLangID));
				if (list5 != null && Enumerable.Any<CRMspSelectActiveConversationStatusResult_Result>((IEnumerable<CRMspSelectActiveConversationStatusResult_Result>)list5) && Enumerable.Count<CRMspSelectActiveConversationStatusResult_Result>((IEnumerable<CRMspSelectActiveConversationStatusResult_Result>)list5) >= num2)
				{
					if (model.ConversationStatusResultId == 0)
					{
						text = text + string.Format(Messages.msgErrorNotSaveMoreCnvsStatusResult, num2.ToString()) + "<br>";
						num++;
					}
					else if (Enumerable.FirstOrDefault<CRMspSelectActiveConversationStatusResult_Result>((IEnumerable<CRMspSelectActiveConversationStatusResult_Result>)list5, (Func<CRMspSelectActiveConversationStatusResult_Result, bool>)((CRMspSelectActiveConversationStatusResult_Result m) => m.ConversationStatusResultId == model.ConversationStatusResultId)) == null)
					{
						text = text + string.Format(Messages.msgErrorNotSaveMoreCnvsStatusResult, num2.ToString()) + "<br>";
						num++;
					}
				}
			}
			if (num == 0)
			{
				try
				{
					DateTime now = DateTime.Now;
					DateTime dateTime = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					short value2 = short.Parse(Financial.Get().Id.ToString());
					int userId = UserLogin.CurrentUser.UserId;
					string cnvsStatusResultEventPolicy = "";
					List<CrmConversationStatusResultEventPolicyLanguageViewModel> list6 = new List<CrmConversationStatusResultEventPolicyLanguageViewModel>();
					if (!string.IsNullOrWhiteSpace(model.EventPolicyJson))
					{
						List<CrmConversationStatusResultEventPolicyLanguageViewModel> list7 = ConvertEventPolicyJsonToViewMode(model.EventPolicyJson);
						if (list7 != null)
						{
							list6.AddRange(list7);
						}
					}
					if (!string.IsNullOrWhiteSpace(model.OTPJson))
					{
						List<CrmConversationStatusResultEventPolicyLanguageViewModel> list8 = ConvertEventPolicyJsonToViewMode(model.OTPJson);
						if (list8 != null)
						{
							list6.AddRange(list8);
						}
					}
					if (!string.IsNullOrWhiteSpace(model.IssuePordJson))
					{
						List<CrmConversationStatusResultEventPolicyLanguageViewModel> list9 = ConvertEventPolicyJsonToViewMode(model.IssuePordJson);
						if (list9 != null)
						{
							list6.AddRange(list9);
						}
					}
					if (!string.IsNullOrWhiteSpace(model.IssueOrdJson))
					{
						List<CrmConversationStatusResultEventPolicyLanguageViewModel> list10 = ConvertEventPolicyJsonToViewMode(model.IssueOrdJson);
						if (list10 != null)
						{
							list6.AddRange(list10);
						}
					}
					if (!string.IsNullOrWhiteSpace(model.IssueDyFormJson))
					{
						List<CrmConversationStatusResultEventPolicyLanguageViewModel> list11 = ConvertEventPolicyJsonToViewMode(model.IssueDyFormJson);
						if (list11 != null)
						{
							list6.AddRange(list11);
						}
					}
					if (!string.IsNullOrWhiteSpace(model.FOJson))
					{
						List<CrmConversationStatusResultEventPolicyLanguageViewModel> list12 = ConvertEventPolicyJsonToViewMode(model.FOJson);
						if (list12 != null)
						{
							list6.AddRange(list12);
						}
					}
					if (!string.IsNullOrWhiteSpace(model.ShpJson))
					{
						List<CrmConversationStatusResultEventPolicyLanguageViewModel> list13 = ConvertEventPolicyJsonToViewMode(model.ShpJson);
						if (list13 != null)
						{
							list6.AddRange(list13);
						}
					}
					if (!string.IsNullOrWhiteSpace(model.AddPrjJson))
					{
						List<CrmConversationStatusResultEventPolicyLanguageViewModel> list14 = ConvertEventPolicyJsonToViewMode(model.AddPrjJson);
						if (list14 != null)
						{
							list6.AddRange(list14);
						}
					}
					if (list6 != null && Enumerable.Any<CrmConversationStatusResultEventPolicyLanguageViewModel>((IEnumerable<CrmConversationStatusResultEventPolicyLanguageViewModel>)list6))
					{
						cnvsStatusResultEventPolicy = JsonConvert.SerializeObject(Enumerable.ToList<CrmConversationStatusResultEventPolicyLanguageViewModel>((IEnumerable<CrmConversationStatusResultEventPolicyLanguageViewModel>)list6));
					}
					string resultTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					string resultDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					string cnvsDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					string cnvsReferDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					List<CrmConversationStatusResult_LangViewModel> list15 = new List<CrmConversationStatusResult_LangViewModel>();
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
					{
						CrmConversationStatusResult_LangViewModel crmConversationStatusResult_LangViewModel = new CrmConversationStatusResult_LangViewModel();
						crmConversationStatusResult_LangViewModel.LanguageID = lang.LanguageID;
						crmConversationStatusResult_LangViewModel.ResultTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmConversationStatusResult_LangViewModel.ResultDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmConversationStatusResult_LangViewModel.CnvsDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmConversationStatusResult_LangViewModel.CnvsReferDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						list15.Add(crmConversationStatusResult_LangViewModel);
					}
					string cnvsStatusResultLang = "";
					if (list15 != null && Enumerable.Any<CrmConversationStatusResult_LangViewModel>((IEnumerable<CrmConversationStatusResult_LangViewModel>)list15))
					{
						cnvsStatusResultLang = JsonConvert.SerializeObject(Enumerable.ToList<CrmConversationStatusResult_LangViewModel>((IEnumerable<CrmConversationStatusResult_LangViewModel>)list15));
					}
					CrmConversationStatusResultUpdateCmpGroupActiveViewModel crmConversationStatusResultUpdateCmpGroupActiveViewModel = new CrmConversationStatusResultUpdateCmpGroupActiveViewModel();
					bool value3 = false;
					if (model.CmpGroupId.GetValueOrDefault() != 0)
					{
						value3 = true;
						crmConversationStatusResultUpdateCmpGroupActiveViewModel.cmpGroupId = model.CmpGroupId;
					}
					if (model.CmpSubGroupId.GetValueOrDefault() != 0)
					{
						value3 = true;
						crmConversationStatusResultUpdateCmpGroupActiveViewModel.cmpSubGroupId = model.CmpSubGroupId;
					}
					if (model.CmpGroupIIId.GetValueOrDefault() != 0)
					{
						value3 = true;
						crmConversationStatusResultUpdateCmpGroupActiveViewModel.cmpGroupIIId = model.CmpGroupIIId;
					}
					if (model.CmpGroupIIIId.GetValueOrDefault() != 0)
					{
						value3 = true;
						crmConversationStatusResultUpdateCmpGroupActiveViewModel.cmpGroupIIIId = model.CmpGroupIIIId;
					}
					if (model.CmpGroupIVId.GetValueOrDefault() != 0)
					{
						value3 = true;
						crmConversationStatusResultUpdateCmpGroupActiveViewModel.cmpGroupIVId = model.CmpGroupIVId;
					}
					if (model.CmpTypeId.GetValueOrDefault() != 0)
					{
						value3 = true;
						crmConversationStatusResultUpdateCmpGroupActiveViewModel.cmpTypeId = model.CmpTypeId;
					}
					model.UpdateCmpGroupActiveJson = "[" + JsonConvert.SerializeObject(crmConversationStatusResultUpdateCmpGroupActiveViewModel) + "]";
					model.UpdateCmpGroupActive = value3;
					if (!model.OrderView.HasValue)
					{
						List<CRMspSelectConversationStatusResult_Result> list16 = Enumerable.ToList<CRMspSelectConversationStatusResult_Result>((IEnumerable<CRMspSelectConversationStatusResult_Result>)_dbI.CRMspSelectConversationStatusResult(model.ConversationStatusId, lCID, defLangID));
						if (!Enumerable.Any<CRMspSelectConversationStatusResult_Result>((IEnumerable<CRMspSelectConversationStatusResult_Result>)list16))
						{
							model.OrderView = 10;
						}
						else
						{
							int num3 = (Enumerable.Any<CRMspSelectConversationStatusResult_Result>((IEnumerable<CRMspSelectConversationStatusResult_Result>)list16) ? Enumerable.Count<CRMspSelectConversationStatusResult_Result>((IEnumerable<CRMspSelectConversationStatusResult_Result>)list16) : 0);
							model.OrderView = num3 * 10 + 10;
							if (Enumerable.LastOrDefault<CRMspSelectConversationStatusResult_Result>((IEnumerable<CRMspSelectConversationStatusResult_Result>)list16) != null)
							{
								int valueOrDefault = Enumerable.LastOrDefault<CRMspSelectConversationStatusResult_Result>((IEnumerable<CRMspSelectConversationStatusResult_Result>)list16).OrderView.GetValueOrDefault();
								if (valueOrDefault > 0)
								{
									model.OrderView = valueOrDefault + 10;
								}
							}
						}
					}
					ObjectParameter objectParameter = new ObjectParameter("InsertedId", 0);
					mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.CRMspInsertUpdateConversationStatusResult(model.ConversationStatusResultId, model.ConversationStatusGroupId, model.ConversationStatusId, resultTitle, resultDesc, model.EventPolicyActive, model.OTPSendActive, model.IssuePordActive, model.IssueOrdActive, model.IssueDyFormActive, model.NeedDyFormChecked, model.NeedDyFormCheckedFormId, model.PrjFinished, model.NoCnvsDup, model.StatusResultUsedUserIds, model.DoingTimeEndDeadlineMin, model.DoingTimeEndCnvsStatusId, model.DoingTimeEndCnvsStatusResultId, model.CnvsCountLimit, model.CnvsDoingTimeLimit, model.CnvsDoingTimeNotNull, model.CnvsRemindDateNotNull, model.CnvsRemindDateForAllarmNotNull, model.CnvsTopicId, model.CnvsReferUserId, model.CnvsReferUserNoChange, model.CnvsRemindDay, cnvsDesc, cnvsReferDesc, model.UpdateCmpGroupActive, model.UpdateCmpGroupActiveJson, model.IsDefault, model.DeActive, model.OrderView, cnvsStatusResultLang, cnvsStatusResultEventPolicy, userId, value2, value, dateTime, registerDatePersian, appType, lCID, defLangID, objectParameter, model.AddPrjActive, model.CnvsNoNeedRemindDateAlert));
					int result = 0;
					if (mct_I_Result != null)
					{
						int.TryParse(mct_I_Result.Result.ToString(), out result);
					}
					int result2 = 0;
					if (objectParameter != null && objectParameter.Value != null)
					{
						int.TryParse(objectParameter.Value.ToString(), out result2);
					}
					string text2 = Messages.frmFormBaseInsertSuccessFulMessage;
					if (model.ConversationStatusResultId > 0)
					{
						text2 = Messages.frmFormBaseEditSuccessFulMessage;
					}
					else
					{
						model.ConversationStatusResultId = result2;
					}
					if (result == 1 && model.ConversationStatusResultId > 0)
					{
						base.ViewBag.Successfull = text2;
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmConversationStatusResult");
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmConversationStatusResultEventPolicy");
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmConversationStatus");
						model.UserId = userId;
						model.RegisterDate = dateTime;
					}
					else
					{
						text = Messages.msgErrorRunFunction;
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					text = Messages.msgErrorRunFunction;
				}
			}
		}
		if (!string.IsNullOrWhiteSpace(text))
		{
			base.ViewBag.Error = text;
		}
		string firstRegInfo = "";
		string regInfo = "";
		if (model != null)
		{
			SetCnvsStatusResultRegisterInfo(model, ref firstRegInfo, ref regInfo);
			model.FirstRegisterUser = firstRegInfo;
			model.EditUser = regInfo;
		}
		return View(model);
	}

	public ActionResult ShowUsersAndRollTree(int mode = 0)
	{
		base.ViewBag.Mode = mode;
		return View();
	}

	[AjaxOnly]
	public JsonResult GetUsersAndRollTree()
	{
		List<CRMspSelectUsersAndRollTree_Result> data = new List<CRMspSelectUsersAndRollTree_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			string textWithOutRoll = Labels.TextWithOutRoll;
			data = Enumerable.ToList<CRMspSelectUsersAndRollTree_Result>((IEnumerable<CRMspSelectUsersAndRollTree_Result>)_dbI.CRMspSelectUsersAndRollTree("", textWithOutRoll, lCID, result));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public ActionResult SelectOneUser(string formName, string hdnItemName, string spanItemName, string txtItemName)
	{
		base.ViewBag.FormName = formName;
		base.ViewBag.HdnItemName = hdnItemName;
		base.ViewBag.SpanItemName = spanItemName;
		base.ViewBag.TxtItemName = txtItemName;
		return View();
	}

	public ActionResult SelectMultiUsers(string formName, string hdnItemName, string spanItemName, string txtItemName, string hdnJsonName)
	{
		base.ViewBag.FormName = formName;
		base.ViewBag.HdnItemName = hdnItemName;
		base.ViewBag.SpanItemName = spanItemName;
		base.ViewBag.TxtItemName = txtItemName;
		base.ViewBag.HdnJsonName = hdnJsonName;
		return View();
	}

	public ActionResult SelectMultiPersonJobs(string formName, string hdnItemName, string spanItemName, string txtItemName, string hdnJsonName)
	{
		base.ViewBag.FormName = formName;
		base.ViewBag.HdnItemName = hdnItemName;
		base.ViewBag.SpanItemName = spanItemName;
		base.ViewBag.TxtItemName = txtItemName;
		base.ViewBag.HdnJsonName = hdnJsonName;
		return View();
	}

	[AjaxOnly]
	public JsonResult GetPersonJobs()
	{
		List<CRMspSelectPersonJobs_Result> data = new List<CRMspSelectPersonJobs_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			_ = Labels.TextWithOutRoll;
			data = Enumerable.ToList<CRMspSelectPersonJobs_Result>((IEnumerable<CRMspSelectPersonJobs_Result>)_db.CRMspSelectPersonJobs(lCID, result));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public ActionResult AddEventPolicy(string partName, string positionName = "")
	{
		base.ViewBag.PartName = partName;
		base.ViewBag.PositionName = positionName;
		return View();
	}

	[AjaxOnly]
	public JsonResult GetEventPolicyReceiversByPartName(string partName)
	{
		List<CRMspSelectActiveEventPolicyReceiversByPartName_Result> data = new List<CRMspSelectActiveEventPolicyReceiversByPartName_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			_ = Labels.TextWithOutRoll;
			data = Enumerable.ToList<CRMspSelectActiveEventPolicyReceiversByPartName_Result>((IEnumerable<CRMspSelectActiveEventPolicyReceiversByPartName_Result>)_dbI.CRMspSelectActiveEventPolicyReceiversByPartName(partName, lCID, result));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public ActionResult SetEventPolicySetting(int rowNumber, int eventPolicyTypeId, int eventPolicyReceiverId = 0, int cnvsStatusResultEventPolicyId = 0, string partName = "", string positionName = "")
	{
		base.ViewBag.RowNumber = rowNumber;
		base.ViewBag.EventPolicyTypeId = eventPolicyTypeId;
		base.ViewBag.EventPolicyReceiverId = eventPolicyReceiverId;
		base.ViewBag.CnvsStatusResultEventPolicyId = cnvsStatusResultEventPolicyId;
		base.ViewBag.PartName = partName;
		base.ViewBag.PositionName = positionName;
		string text = "";
		List<CRMspSelectActiveEventPolicyReceivers_Result> activeEventPolicyReceiversList = GetActiveEventPolicyReceiversList();
		if (activeEventPolicyReceiversList != null && Enumerable.Any<CRMspSelectActiveEventPolicyReceivers_Result>((IEnumerable<CRMspSelectActiveEventPolicyReceivers_Result>)activeEventPolicyReceiversList))
		{
			text = JsonConvert.SerializeObject(Enumerable.ToList<CRMspSelectActiveEventPolicyReceivers_Result>((IEnumerable<CRMspSelectActiveEventPolicyReceivers_Result>)activeEventPolicyReceiversList));
		}
		base.ViewBag.EventPolicyReceivers = text;
		GetSurveySendSettingByEvent();
		string text2 = "";
		List<Languages> list = Enumerable.ToList<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get());
		List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
		if (list != null && Enumerable.Any<Languages>((IEnumerable<Languages>)list))
		{
			foreach (Languages item2 in list)
			{
				CommonMultiLanguageViewModel item = new CommonMultiLanguageViewModel
				{
					LanguageId = item2.LanguageID,
					Value = item2.LanguageID.ToString()
				};
				list2.Add(item);
			}
		}
		if (list2 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2))
		{
			text2 = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2));
		}
		base.ViewBag.LangList = text2;
		return View();
	}

	public ActionResult AddPatternToText(string formName, string itemName, string itemType)
	{
		base.ViewBag.FormName = formName;
		base.ViewBag.ItemName = itemName;
		base.ViewBag.ItemType = itemType;
		return View();
	}

	public List<CrmConversationStatusResultEventPolicyLanguageViewModel> ConvertEventPolicyJsonToViewMode(string strJson)
	{
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_24f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_266d: Unknown result type (might be due to invalid IL or missing references)
		//IL_26d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_2745: Unknown result type (might be due to invalid IL or missing references)
		List<CrmConversationStatusResultEventPolicyLanguageViewModel> list = new List<CrmConversationStatusResultEventPolicyLanguageViewModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
			if (defLangID <= 0)
			{
				defLangID = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (!string.IsNullOrWhiteSpace(strJson))
			{
				List<object> list2 = new JavaScriptSerializer().Deserialize<List<object>>(strJson);
				if (list2 != null && Enumerable.Any<object>((IEnumerable<object>)list2))
				{
					for (int i = 0; i < list2.Count; i++)
					{
						CrmConversationStatusResultEventPolicyLanguageViewModel crmConversationStatusResultEventPolicyLanguageViewModel = new CrmConversationStatusResultEventPolicyLanguageViewModel();
						if (_003C_003Eo__46._003C_003Ep__5 == null)
						{
							_003C_003Eo__46._003C_003Ep__5 = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)83, typeof(ConversationStatusResultController), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						Func<CallSite, object, bool> target = _003C_003Eo__46._003C_003Ep__5.Target;
						CallSite<Func<CallSite, object, bool>> _003C_003Ep__ = _003C_003Eo__46._003C_003Ep__5;
						if (_003C_003Eo__46._003C_003Ep__0 == null)
						{
							_003C_003Eo__46._003C_003Ep__0 = CallSite<Func<CallSite, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)35, typeof(ConversationStatusResultController), new CSharpArgumentInfo[2]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
							}));
						}
						object obj = _003C_003Eo__46._003C_003Ep__0.Target((CallSite)(object)_003C_003Eo__46._003C_003Ep__0, list2[i], null);
						if (_003C_003Eo__46._003C_003Ep__4 == null)
						{
							_003C_003Eo__46._003C_003Ep__4 = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)84, typeof(ConversationStatusResultController), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						object arg2;
						if (!_003C_003Eo__46._003C_003Ep__4.Target((CallSite)(object)_003C_003Eo__46._003C_003Ep__4, obj))
						{
							if (_003C_003Eo__46._003C_003Ep__3 == null)
							{
								_003C_003Eo__46._003C_003Ep__3 = CallSite<Func<CallSite, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, (ExpressionType)2, typeof(ConversationStatusResultController), new CSharpArgumentInfo[2]
								{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
								}));
							}
							Func<CallSite, object, object, object> target2 = _003C_003Eo__46._003C_003Ep__3.Target;
							CallSite<Func<CallSite, object, object, object>> _003C_003Ep__2 = _003C_003Eo__46._003C_003Ep__3;
							object arg = obj;
							if (_003C_003Eo__46._003C_003Ep__2 == null)
							{
								_003C_003Eo__46._003C_003Ep__2 = CallSite<Func<CallSite, object, int, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)15, typeof(ConversationStatusResultController), new CSharpArgumentInfo[2]
								{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
								}));
							}
							arg2 = target2((CallSite)(object)_003C_003Ep__2, arg, _003C_003Eo__46._003C_003Ep__2.Target((CallSite)(object)_003C_003Eo__46._003C_003Ep__2, (object)((dynamic)list2[i]).Count, 0));
						}
						else
						{
							arg2 = obj;
						}
						if (target((CallSite)(object)_003C_003Ep__, arg2))
						{
							foreach (dynamic item in (dynamic)list2[i])
							{
								dynamic val = item.Key;
								dynamic val2 = item.Value;
								if (_003C_003Eo__46._003C_003Ep__10 == null)
								{
									_003C_003Eo__46._003C_003Ep__10 = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)83, typeof(ConversationStatusResultController), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
								}
								Func<CallSite, object, bool> target3 = _003C_003Eo__46._003C_003Ep__10.Target;
								CallSite<Func<CallSite, object, bool>> _003C_003Ep__3 = _003C_003Eo__46._003C_003Ep__10;
								if (_003C_003Eo__46._003C_003Ep__9 == null)
								{
									_003C_003Eo__46._003C_003Ep__9 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)34, typeof(ConversationStatusResultController), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
								}
								if (!target3((CallSite)(object)_003C_003Ep__3, _003C_003Eo__46._003C_003Ep__9.Target((CallSite)(object)_003C_003Eo__46._003C_003Ep__9, (object)string.IsNullOrWhiteSpace(val))))
								{
									continue;
								}
								switch (val as string)
								{
								case "ConversationStatusResultEventPolicyId":
								{
									int conversationStatusResultEventPolicyId = 0;
									int.TryParse((val2 ?? ((object)0)).ToString(), out conversationStatusResultEventPolicyId);
									crmConversationStatusResultEventPolicyLanguageViewModel.ConversationStatusResultEventPolicyId = conversationStatusResultEventPolicyId;
									break;
								}
								case "ConversationStatusGroupId":
								{
									int conversationStatusGroupId = 0;
									int.TryParse((val2 ?? ((object)0)).ToString(), out conversationStatusGroupId);
									crmConversationStatusResultEventPolicyLanguageViewModel.ConversationStatusGroupId = conversationStatusGroupId;
									break;
								}
								case "ConversationStatusId":
								{
									int conversationStatusId = 0;
									int.TryParse((val2 ?? ((object)0)).ToString(), out conversationStatusId);
									crmConversationStatusResultEventPolicyLanguageViewModel.ConversationStatusId = conversationStatusId;
									break;
								}
								case "ConversationStatusResultId":
								{
									int conversationStatusResultId = 0;
									int.TryParse((val2 ?? ((object)0)).ToString(), out conversationStatusResultId);
									crmConversationStatusResultEventPolicyLanguageViewModel.ConversationStatusResultId = conversationStatusResultId;
									break;
								}
								case "EventPolicyTypeId":
								{
									int eventPolicyTypeId = 0;
									int.TryParse((val2 ?? ((object)0)).ToString(), out eventPolicyTypeId);
									crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicyTypeId = eventPolicyTypeId;
									break;
								}
								case "EventPolicyReceiverId":
								{
									int value4 = 0;
									int.TryParse((val2 ?? ((object)0)).ToString(), out value4);
									crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicyReceiverId = value4;
									break;
								}
								case "EventPolicyReceiverUsers":
								{
									if (_003C_003Eo__46._003C_003Ep__27 == null)
									{
										_003C_003Eo__46._003C_003Ep__27 = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)83, typeof(ConversationStatusResultController), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
									}
									Func<CallSite, object, bool> target8 = _003C_003Eo__46._003C_003Ep__27.Target;
									CallSite<Func<CallSite, object, bool>> _003C_003Ep__8 = _003C_003Eo__46._003C_003Ep__27;
									if (_003C_003Eo__46._003C_003Ep__23 == null)
									{
										_003C_003Eo__46._003C_003Ep__23 = CallSite<Func<CallSite, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)35, typeof(ConversationStatusResultController), new CSharpArgumentInfo[2]
										{
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
										}));
									}
									obj = _003C_003Eo__46._003C_003Ep__23.Target((CallSite)(object)_003C_003Eo__46._003C_003Ep__23, (object)val2, null);
									if (_003C_003Eo__46._003C_003Ep__26 == null)
									{
										_003C_003Eo__46._003C_003Ep__26 = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)84, typeof(ConversationStatusResultController), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
									}
									object arg8;
									if (!_003C_003Eo__46._003C_003Ep__26.Target((CallSite)(object)_003C_003Eo__46._003C_003Ep__26, obj))
									{
										if (_003C_003Eo__46._003C_003Ep__25 == null)
										{
											_003C_003Eo__46._003C_003Ep__25 = CallSite<Func<CallSite, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, (ExpressionType)2, typeof(ConversationStatusResultController), new CSharpArgumentInfo[2]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
											}));
										}
										Func<CallSite, object, object, object> target9 = _003C_003Eo__46._003C_003Ep__25.Target;
										CallSite<Func<CallSite, object, object, object>> _003C_003Ep__9 = _003C_003Eo__46._003C_003Ep__25;
										object arg7 = obj;
										if (_003C_003Eo__46._003C_003Ep__24 == null)
										{
											_003C_003Eo__46._003C_003Ep__24 = CallSite<Func<CallSite, object, string, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)35, typeof(ConversationStatusResultController), new CSharpArgumentInfo[2]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
											}));
										}
										arg8 = target9((CallSite)(object)_003C_003Ep__9, arg7, _003C_003Eo__46._003C_003Ep__24.Target((CallSite)(object)_003C_003Eo__46._003C_003Ep__24, (object)val2, "null"));
									}
									else
									{
										arg8 = obj;
									}
									if (target8((CallSite)(object)_003C_003Ep__8, arg8))
									{
										dynamic val5 = val2.ToString();
										crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicyReceiverUsers = val5;
									}
									else
									{
										crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicyReceiverUsers = "";
									}
									break;
								}
								case "EventPolicyReceiverPrsJobs":
								{
									if (_003C_003Eo__46._003C_003Ep__34 == null)
									{
										_003C_003Eo__46._003C_003Ep__34 = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)83, typeof(ConversationStatusResultController), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
									}
									Func<CallSite, object, bool> target13 = _003C_003Eo__46._003C_003Ep__34.Target;
									CallSite<Func<CallSite, object, bool>> _003C_003Ep__13 = _003C_003Eo__46._003C_003Ep__34;
									if (_003C_003Eo__46._003C_003Ep__30 == null)
									{
										_003C_003Eo__46._003C_003Ep__30 = CallSite<Func<CallSite, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)35, typeof(ConversationStatusResultController), new CSharpArgumentInfo[2]
										{
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
										}));
									}
									obj = _003C_003Eo__46._003C_003Ep__30.Target((CallSite)(object)_003C_003Eo__46._003C_003Ep__30, (object)val2, null);
									if (_003C_003Eo__46._003C_003Ep__33 == null)
									{
										_003C_003Eo__46._003C_003Ep__33 = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)84, typeof(ConversationStatusResultController), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
									}
									object arg12;
									if (!_003C_003Eo__46._003C_003Ep__33.Target((CallSite)(object)_003C_003Eo__46._003C_003Ep__33, obj))
									{
										if (_003C_003Eo__46._003C_003Ep__32 == null)
										{
											_003C_003Eo__46._003C_003Ep__32 = CallSite<Func<CallSite, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, (ExpressionType)2, typeof(ConversationStatusResultController), new CSharpArgumentInfo[2]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
											}));
										}
										Func<CallSite, object, object, object> target14 = _003C_003Eo__46._003C_003Ep__32.Target;
										CallSite<Func<CallSite, object, object, object>> _003C_003Ep__14 = _003C_003Eo__46._003C_003Ep__32;
										object arg11 = obj;
										if (_003C_003Eo__46._003C_003Ep__31 == null)
										{
											_003C_003Eo__46._003C_003Ep__31 = CallSite<Func<CallSite, object, string, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)35, typeof(ConversationStatusResultController), new CSharpArgumentInfo[2]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
											}));
										}
										arg12 = target14((CallSite)(object)_003C_003Ep__14, arg11, _003C_003Eo__46._003C_003Ep__31.Target((CallSite)(object)_003C_003Eo__46._003C_003Ep__31, (object)val2, "null"));
									}
									else
									{
										arg12 = obj;
									}
									if (target13((CallSite)(object)_003C_003Ep__13, arg12))
									{
										dynamic val7 = val2.ToString();
										crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicyReceiverPrsJobs = val7;
									}
									else
									{
										crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicyReceiverPrsJobs = "";
									}
									break;
								}
								case "EventPolicySetting":
								{
									if (_003C_003Eo__46._003C_003Ep__41 == null)
									{
										_003C_003Eo__46._003C_003Ep__41 = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)83, typeof(ConversationStatusResultController), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
									}
									Func<CallSite, object, bool> target11 = _003C_003Eo__46._003C_003Ep__41.Target;
									CallSite<Func<CallSite, object, bool>> _003C_003Ep__11 = _003C_003Eo__46._003C_003Ep__41;
									if (_003C_003Eo__46._003C_003Ep__37 == null)
									{
										_003C_003Eo__46._003C_003Ep__37 = CallSite<Func<CallSite, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)35, typeof(ConversationStatusResultController), new CSharpArgumentInfo[2]
										{
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
										}));
									}
									obj = _003C_003Eo__46._003C_003Ep__37.Target((CallSite)(object)_003C_003Eo__46._003C_003Ep__37, (object)val2, null);
									if (_003C_003Eo__46._003C_003Ep__40 == null)
									{
										_003C_003Eo__46._003C_003Ep__40 = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)84, typeof(ConversationStatusResultController), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
									}
									object arg10;
									if (!_003C_003Eo__46._003C_003Ep__40.Target((CallSite)(object)_003C_003Eo__46._003C_003Ep__40, obj))
									{
										if (_003C_003Eo__46._003C_003Ep__39 == null)
										{
											_003C_003Eo__46._003C_003Ep__39 = CallSite<Func<CallSite, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, (ExpressionType)2, typeof(ConversationStatusResultController), new CSharpArgumentInfo[2]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
											}));
										}
										Func<CallSite, object, object, object> target12 = _003C_003Eo__46._003C_003Ep__39.Target;
										CallSite<Func<CallSite, object, object, object>> _003C_003Ep__12 = _003C_003Eo__46._003C_003Ep__39;
										object arg9 = obj;
										if (_003C_003Eo__46._003C_003Ep__38 == null)
										{
											_003C_003Eo__46._003C_003Ep__38 = CallSite<Func<CallSite, object, string, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)35, typeof(ConversationStatusResultController), new CSharpArgumentInfo[2]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
											}));
										}
										arg10 = target12((CallSite)(object)_003C_003Ep__12, arg9, _003C_003Eo__46._003C_003Ep__38.Target((CallSite)(object)_003C_003Eo__46._003C_003Ep__38, (object)val2, "null"));
									}
									else
									{
										arg10 = obj;
									}
									if (target11((CallSite)(object)_003C_003Ep__11, arg10))
									{
										dynamic val6 = val2.ToString();
										crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicySetting = val6;
									}
									else
									{
										crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicySetting = "";
									}
									break;
								}
								case "EventPolicySendTimeType":
								{
									int value6 = 0;
									int.TryParse((val2 ?? ((object)0)).ToString(), out value6);
									crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicySendTimeType = value6;
									break;
								}
								case "EventPolicySendTimeValue":
								{
									int value5 = 0;
									int.TryParse((val2 ?? ((object)0)).ToString(), out value5);
									crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicySendTimeValue = value5;
									break;
								}
								case "EventPolicySendTimeValueII":
								{
									int value3 = 0;
									int.TryParse((val2 ?? ((object)0)).ToString(), out value3);
									crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicySendTimeValueII = value3;
									break;
								}
								case "EventPolicyUserCheckBeforeSend":
								{
									bool value2 = false;
									bool.TryParse((val2 ?? ((object)0)).ToString(), out value2);
									crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicyUserCheckBeforeSend = value2;
									break;
								}
								case "EventPolicyShortDescription":
								{
									if (_003C_003Eo__46._003C_003Ep__56 == null)
									{
										_003C_003Eo__46._003C_003Ep__56 = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)83, typeof(ConversationStatusResultController), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
									}
									Func<CallSite, object, bool> target6 = _003C_003Eo__46._003C_003Ep__56.Target;
									CallSite<Func<CallSite, object, bool>> _003C_003Ep__6 = _003C_003Eo__46._003C_003Ep__56;
									if (_003C_003Eo__46._003C_003Ep__52 == null)
									{
										_003C_003Eo__46._003C_003Ep__52 = CallSite<Func<CallSite, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)35, typeof(ConversationStatusResultController), new CSharpArgumentInfo[2]
										{
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
										}));
									}
									obj = _003C_003Eo__46._003C_003Ep__52.Target((CallSite)(object)_003C_003Eo__46._003C_003Ep__52, (object)val2, null);
									if (_003C_003Eo__46._003C_003Ep__55 == null)
									{
										_003C_003Eo__46._003C_003Ep__55 = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)84, typeof(ConversationStatusResultController), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
									}
									object arg6;
									if (!_003C_003Eo__46._003C_003Ep__55.Target((CallSite)(object)_003C_003Eo__46._003C_003Ep__55, obj))
									{
										if (_003C_003Eo__46._003C_003Ep__54 == null)
										{
											_003C_003Eo__46._003C_003Ep__54 = CallSite<Func<CallSite, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, (ExpressionType)2, typeof(ConversationStatusResultController), new CSharpArgumentInfo[2]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
											}));
										}
										Func<CallSite, object, object, object> target7 = _003C_003Eo__46._003C_003Ep__54.Target;
										CallSite<Func<CallSite, object, object, object>> _003C_003Ep__7 = _003C_003Eo__46._003C_003Ep__54;
										object arg5 = obj;
										if (_003C_003Eo__46._003C_003Ep__53 == null)
										{
											_003C_003Eo__46._003C_003Ep__53 = CallSite<Func<CallSite, object, string, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)35, typeof(ConversationStatusResultController), new CSharpArgumentInfo[2]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
											}));
										}
										arg6 = target7((CallSite)(object)_003C_003Ep__7, arg5, _003C_003Eo__46._003C_003Ep__53.Target((CallSite)(object)_003C_003Eo__46._003C_003Ep__53, (object)val2, "null"));
									}
									else
									{
										arg6 = obj;
									}
									if (target6((CallSite)(object)_003C_003Ep__6, arg6))
									{
										dynamic val4 = val2.ToString();
										crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicyShortDescription = val4;
									}
									else
									{
										crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicyShortDescription = "";
									}
									break;
								}
								case "EventPolicyBigDescription":
								{
									if (_003C_003Eo__46._003C_003Ep__63 == null)
									{
										_003C_003Eo__46._003C_003Ep__63 = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)83, typeof(ConversationStatusResultController), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
									}
									Func<CallSite, object, bool> target17 = _003C_003Eo__46._003C_003Ep__63.Target;
									CallSite<Func<CallSite, object, bool>> _003C_003Ep__17 = _003C_003Eo__46._003C_003Ep__63;
									if (_003C_003Eo__46._003C_003Ep__59 == null)
									{
										_003C_003Eo__46._003C_003Ep__59 = CallSite<Func<CallSite, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)35, typeof(ConversationStatusResultController), new CSharpArgumentInfo[2]
										{
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
										}));
									}
									obj = _003C_003Eo__46._003C_003Ep__59.Target((CallSite)(object)_003C_003Eo__46._003C_003Ep__59, (object)val2, null);
									if (_003C_003Eo__46._003C_003Ep__62 == null)
									{
										_003C_003Eo__46._003C_003Ep__62 = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)84, typeof(ConversationStatusResultController), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
									}
									object arg16;
									if (!_003C_003Eo__46._003C_003Ep__62.Target((CallSite)(object)_003C_003Eo__46._003C_003Ep__62, obj))
									{
										if (_003C_003Eo__46._003C_003Ep__61 == null)
										{
											_003C_003Eo__46._003C_003Ep__61 = CallSite<Func<CallSite, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, (ExpressionType)2, typeof(ConversationStatusResultController), new CSharpArgumentInfo[2]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
											}));
										}
										Func<CallSite, object, object, object> target18 = _003C_003Eo__46._003C_003Ep__61.Target;
										CallSite<Func<CallSite, object, object, object>> _003C_003Ep__18 = _003C_003Eo__46._003C_003Ep__61;
										object arg15 = obj;
										if (_003C_003Eo__46._003C_003Ep__60 == null)
										{
											_003C_003Eo__46._003C_003Ep__60 = CallSite<Func<CallSite, object, string, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)35, typeof(ConversationStatusResultController), new CSharpArgumentInfo[2]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
											}));
										}
										arg16 = target18((CallSite)(object)_003C_003Ep__18, arg15, _003C_003Eo__46._003C_003Ep__60.Target((CallSite)(object)_003C_003Eo__46._003C_003Ep__60, (object)val2, "null"));
									}
									else
									{
										arg16 = obj;
									}
									if (target17((CallSite)(object)_003C_003Ep__17, arg16))
									{
										dynamic val9 = val2.ToString();
										crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicyBigDescription = val9;
									}
									else
									{
										crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicyBigDescription = "";
									}
									break;
								}
								case "DeActive":
								{
									bool value = false;
									if (_003C_003Eo__46._003C_003Ep__67 == null)
									{
										_003C_003Eo__46._003C_003Ep__67 = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)83, typeof(ConversationStatusResultController), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
									}
									Func<CallSite, object, bool> target10 = _003C_003Eo__46._003C_003Ep__67.Target;
									CallSite<Func<CallSite, object, bool>> _003C_003Ep__10 = _003C_003Eo__46._003C_003Ep__67;
									if (_003C_003Eo__46._003C_003Ep__66 == null)
									{
										_003C_003Eo__46._003C_003Ep__66 = CallSite<Func<CallSite, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)35, typeof(ConversationStatusResultController), new CSharpArgumentInfo[2]
										{
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
										}));
									}
									if (target10((CallSite)(object)_003C_003Ep__10, _003C_003Eo__46._003C_003Ep__66.Target((CallSite)(object)_003C_003Eo__46._003C_003Ep__66, (object)val2, null)))
									{
										bool.TryParse(val2.ToString(), out value);
									}
									crmConversationStatusResultEventPolicyLanguageViewModel.DeActive = value;
									break;
								}
								case "Mode":
								{
									int mode = 0;
									int.TryParse((val2 ?? ((object)0)).ToString(), out mode);
									crmConversationStatusResultEventPolicyLanguageViewModel.Mode = mode;
									break;
								}
								case "EventPolicySetting_Lang":
								{
									if (_003C_003Eo__46._003C_003Ep__76 == null)
									{
										_003C_003Eo__46._003C_003Ep__76 = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)83, typeof(ConversationStatusResultController), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
									}
									Func<CallSite, object, bool> target15 = _003C_003Eo__46._003C_003Ep__76.Target;
									CallSite<Func<CallSite, object, bool>> _003C_003Ep__15 = _003C_003Eo__46._003C_003Ep__76;
									if (_003C_003Eo__46._003C_003Ep__72 == null)
									{
										_003C_003Eo__46._003C_003Ep__72 = CallSite<Func<CallSite, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)35, typeof(ConversationStatusResultController), new CSharpArgumentInfo[2]
										{
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
										}));
									}
									obj = _003C_003Eo__46._003C_003Ep__72.Target((CallSite)(object)_003C_003Eo__46._003C_003Ep__72, (object)val2, null);
									if (_003C_003Eo__46._003C_003Ep__75 == null)
									{
										_003C_003Eo__46._003C_003Ep__75 = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)84, typeof(ConversationStatusResultController), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
									}
									object arg14;
									if (!_003C_003Eo__46._003C_003Ep__75.Target((CallSite)(object)_003C_003Eo__46._003C_003Ep__75, obj))
									{
										if (_003C_003Eo__46._003C_003Ep__74 == null)
										{
											_003C_003Eo__46._003C_003Ep__74 = CallSite<Func<CallSite, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, (ExpressionType)2, typeof(ConversationStatusResultController), new CSharpArgumentInfo[2]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
											}));
										}
										Func<CallSite, object, object, object> target16 = _003C_003Eo__46._003C_003Ep__74.Target;
										CallSite<Func<CallSite, object, object, object>> _003C_003Ep__16 = _003C_003Eo__46._003C_003Ep__74;
										object arg13 = obj;
										if (_003C_003Eo__46._003C_003Ep__73 == null)
										{
											_003C_003Eo__46._003C_003Ep__73 = CallSite<Func<CallSite, object, string, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)35, typeof(ConversationStatusResultController), new CSharpArgumentInfo[2]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
											}));
										}
										arg14 = target16((CallSite)(object)_003C_003Ep__16, arg13, _003C_003Eo__46._003C_003Ep__73.Target((CallSite)(object)_003C_003Eo__46._003C_003Ep__73, (object)val2, "null"));
									}
									else
									{
										arg14 = obj;
									}
									if (target15((CallSite)(object)_003C_003Ep__15, arg14))
									{
										dynamic val8 = val2.ToString();
										crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicySetting_Lang = val8;
									}
									else
									{
										crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicySetting_Lang = "";
									}
									break;
								}
								case "EventPolicyShortDescription_Lang":
								{
									if (_003C_003Eo__46._003C_003Ep__83 == null)
									{
										_003C_003Eo__46._003C_003Ep__83 = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)83, typeof(ConversationStatusResultController), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
									}
									Func<CallSite, object, bool> target19 = _003C_003Eo__46._003C_003Ep__83.Target;
									CallSite<Func<CallSite, object, bool>> _003C_003Ep__19 = _003C_003Eo__46._003C_003Ep__83;
									if (_003C_003Eo__46._003C_003Ep__79 == null)
									{
										_003C_003Eo__46._003C_003Ep__79 = CallSite<Func<CallSite, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)35, typeof(ConversationStatusResultController), new CSharpArgumentInfo[2]
										{
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
										}));
									}
									obj = _003C_003Eo__46._003C_003Ep__79.Target((CallSite)(object)_003C_003Eo__46._003C_003Ep__79, (object)val2, null);
									if (_003C_003Eo__46._003C_003Ep__82 == null)
									{
										_003C_003Eo__46._003C_003Ep__82 = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)84, typeof(ConversationStatusResultController), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
									}
									object arg18;
									if (!_003C_003Eo__46._003C_003Ep__82.Target((CallSite)(object)_003C_003Eo__46._003C_003Ep__82, obj))
									{
										if (_003C_003Eo__46._003C_003Ep__81 == null)
										{
											_003C_003Eo__46._003C_003Ep__81 = CallSite<Func<CallSite, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, (ExpressionType)2, typeof(ConversationStatusResultController), new CSharpArgumentInfo[2]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
											}));
										}
										Func<CallSite, object, object, object> target20 = _003C_003Eo__46._003C_003Ep__81.Target;
										CallSite<Func<CallSite, object, object, object>> _003C_003Ep__20 = _003C_003Eo__46._003C_003Ep__81;
										object arg17 = obj;
										if (_003C_003Eo__46._003C_003Ep__80 == null)
										{
											_003C_003Eo__46._003C_003Ep__80 = CallSite<Func<CallSite, object, string, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)35, typeof(ConversationStatusResultController), new CSharpArgumentInfo[2]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
											}));
										}
										arg18 = target20((CallSite)(object)_003C_003Ep__20, arg17, _003C_003Eo__46._003C_003Ep__80.Target((CallSite)(object)_003C_003Eo__46._003C_003Ep__80, (object)val2, "null"));
									}
									else
									{
										arg18 = obj;
									}
									if (target19((CallSite)(object)_003C_003Ep__19, arg18))
									{
										dynamic val10 = val2.ToString();
										crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicyShortDescription_Lang = val10;
									}
									else
									{
										crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicyShortDescription_Lang = "";
									}
									break;
								}
								case "EventPolicyBigDescription_Lang":
								{
									if (_003C_003Eo__46._003C_003Ep__90 == null)
									{
										_003C_003Eo__46._003C_003Ep__90 = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)83, typeof(ConversationStatusResultController), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
									}
									Func<CallSite, object, bool> target4 = _003C_003Eo__46._003C_003Ep__90.Target;
									CallSite<Func<CallSite, object, bool>> _003C_003Ep__4 = _003C_003Eo__46._003C_003Ep__90;
									if (_003C_003Eo__46._003C_003Ep__86 == null)
									{
										_003C_003Eo__46._003C_003Ep__86 = CallSite<Func<CallSite, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)35, typeof(ConversationStatusResultController), new CSharpArgumentInfo[2]
										{
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
										}));
									}
									obj = _003C_003Eo__46._003C_003Ep__86.Target((CallSite)(object)_003C_003Eo__46._003C_003Ep__86, (object)val2, null);
									if (_003C_003Eo__46._003C_003Ep__89 == null)
									{
										_003C_003Eo__46._003C_003Ep__89 = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)84, typeof(ConversationStatusResultController), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
									}
									object arg4;
									if (!_003C_003Eo__46._003C_003Ep__89.Target((CallSite)(object)_003C_003Eo__46._003C_003Ep__89, obj))
									{
										if (_003C_003Eo__46._003C_003Ep__88 == null)
										{
											_003C_003Eo__46._003C_003Ep__88 = CallSite<Func<CallSite, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, (ExpressionType)2, typeof(ConversationStatusResultController), new CSharpArgumentInfo[2]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
											}));
										}
										Func<CallSite, object, object, object> target5 = _003C_003Eo__46._003C_003Ep__88.Target;
										CallSite<Func<CallSite, object, object, object>> _003C_003Ep__5 = _003C_003Eo__46._003C_003Ep__88;
										object arg3 = obj;
										if (_003C_003Eo__46._003C_003Ep__87 == null)
										{
											_003C_003Eo__46._003C_003Ep__87 = CallSite<Func<CallSite, object, string, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)35, typeof(ConversationStatusResultController), new CSharpArgumentInfo[2]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
											}));
										}
										arg4 = target5((CallSite)(object)_003C_003Ep__5, arg3, _003C_003Eo__46._003C_003Ep__87.Target((CallSite)(object)_003C_003Eo__46._003C_003Ep__87, (object)val2, "null"));
									}
									else
									{
										arg4 = obj;
									}
									if (target4((CallSite)(object)_003C_003Ep__4, arg4))
									{
										dynamic val3 = val2.ToString();
										crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicyBigDescription_Lang = val3;
									}
									else
									{
										crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicyBigDescription_Lang = "";
									}
									break;
								}
								}
							}
						}
						List<object> list3 = new List<object>();
						if (!string.IsNullOrWhiteSpace(crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicySetting))
						{
							crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicySetting = crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicySetting.Replace("\\", "");
							list3 = new JavaScriptSerializer().Deserialize<List<object>>(crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicySetting);
						}
						if (!string.IsNullOrWhiteSpace(crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicyReceiverUsers))
						{
							int num = list3.FindIndex((dynamic x) => ((Dictionary<string, object>)x).ContainsKey("EventPolicyReceiverUsers"));
							if (num != -1)
							{
								Dictionary<string, string> dictionary = new Dictionary<string, string>();
								dictionary.Add("EventPolicyReceiverUsers", crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicyReceiverUsers);
								list3[num] = dictionary;
							}
							else
							{
								Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
								dictionary2.Add("EventPolicyReceiverUsers", crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicyReceiverUsers);
								list3.Add(dictionary2);
							}
						}
						if (!string.IsNullOrWhiteSpace(crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicyReceiverPrsJobs))
						{
							int num2 = list3.FindIndex((dynamic x) => ((Dictionary<string, object>)x).ContainsKey("EventPolicyReceiverPrsJobs"));
							if (num2 != -1)
							{
								Dictionary<string, string> dictionary3 = new Dictionary<string, string>();
								dictionary3.Add("EventPolicyReceiverPrsJobs", crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicyReceiverPrsJobs);
								list3[num2] = dictionary3;
							}
							else
							{
								Dictionary<string, string> dictionary4 = new Dictionary<string, string>();
								dictionary4.Add("EventPolicyReceiverPrsJobs", crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicyReceiverPrsJobs);
								list3.Add(dictionary4);
							}
						}
						if (list3 != null && Enumerable.Any<object>((IEnumerable<object>)list3))
						{
							crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicySetting = JsonConvert.SerializeObject(Enumerable.ToList<object>((IEnumerable<object>)list3));
						}
						List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
						List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
						List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
						if (!string.IsNullOrWhiteSpace(crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicySetting_Lang))
						{
							crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicySetting_Lang = crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicySetting_Lang.Replace("\\\"", "\"");
							list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicySetting_Lang);
						}
						if (!string.IsNullOrWhiteSpace(crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicySetting))
						{
							list4.Add(new CommonMultiLanguageViewModel
							{
								Value = crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicySetting,
								LanguageId = lCID
							});
						}
						if (!string.IsNullOrWhiteSpace(crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicyShortDescription_Lang))
						{
							crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicyShortDescription_Lang = crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicyShortDescription_Lang.Replace("\\\"", "\"");
							list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicyShortDescription_Lang);
						}
						if (!string.IsNullOrWhiteSpace(crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicyShortDescription))
						{
							list5.Add(new CommonMultiLanguageViewModel
							{
								Value = crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicyShortDescription,
								LanguageId = lCID
							});
						}
						if (!string.IsNullOrWhiteSpace(crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicyBigDescription_Lang))
						{
							crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicyBigDescription_Lang = crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicyBigDescription_Lang.Replace("\\\"", "\"");
							list6 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicyBigDescription_Lang);
						}
						if (!string.IsNullOrWhiteSpace(crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicyBigDescription))
						{
							list6.Add(new CommonMultiLanguageViewModel
							{
								Value = crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicyBigDescription,
								LanguageId = lCID
							});
						}
						List<CrmConversationStatusResultEventPolicy_LangViewModel> list7 = new List<CrmConversationStatusResultEventPolicy_LangViewModel>();
						crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicySetting = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
						crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicyShortDescription = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
						crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicyBigDescription = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
						foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
						{
							CrmConversationStatusResultEventPolicy_LangViewModel crmConversationStatusResultEventPolicy_LangViewModel = new CrmConversationStatusResultEventPolicy_LangViewModel();
							crmConversationStatusResultEventPolicy_LangViewModel.LanguageID = lang.LanguageID;
							crmConversationStatusResultEventPolicy_LangViewModel.EventPolicySetting = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
							crmConversationStatusResultEventPolicy_LangViewModel.EventPolicyShortDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
							crmConversationStatusResultEventPolicy_LangViewModel.EventPolicyBigDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
							list7.Add(crmConversationStatusResultEventPolicy_LangViewModel);
						}
						if (list7 != null && Enumerable.Any<CrmConversationStatusResultEventPolicy_LangViewModel>((IEnumerable<CrmConversationStatusResultEventPolicy_LangViewModel>)list7))
						{
							crmConversationStatusResultEventPolicyLanguageViewModel.EventPolicyDescription_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CrmConversationStatusResultEventPolicy_LangViewModel>((IEnumerable<CrmConversationStatusResultEventPolicy_LangViewModel>)list7));
						}
						list.Add(crmConversationStatusResultEventPolicyLanguageViewModel);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmDefinecnvsStatus", ActionName = "actDeleteCnvsStatusResult")]
	public string ActDelete(int cnvsStatusResultId)
	{
		string text = "";
		try
		{
			if (cnvsStatusResultId > 0)
			{
				try
				{
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					short value3 = short.Parse(Financial.Get().Id.ToString());
					int userId = UserLogin.CurrentUser.UserId;
					mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.CRMspDeleteConversationStatusResult(cnvsStatusResultId, userId, value3, value2, value, registerDatePersian, appType));
					int result = 0;
					if (mct_I_Result != null)
					{
						int.TryParse(mct_I_Result.Result.ToString(), out result);
					}
					if (result == 1)
					{
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmConversationStatusResult");
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmConversationStatusResultEventPolicy");
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmConversationStatus");
						return "1";
					}
					return Messages.RedundancyMessage;
				}
				catch (DbEntityValidationException e)
				{
					ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
					return Messages.msgErrorRunFunction;
				}
				catch (Exception ex)
				{
					ErrorSignal.FromCurrentContext().Raise(ex);
					return Messages.msgErrorCommunicateWithServer + "<br><p style=text-align:left;>" + ex.Message + "</p>";
				}
			}
			return Messages.ErrorNotFound;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			return Messages.frmErrorMessage;
		}
	}

	[DynamicAuthorize(ControllerName = "frmDefinecnvsStatus", ActionName = "actAddCnvsStatusResult,actEditCnvsStatusResult")]
	public ActionResult InsertEdit_I(int cnvsStatusGroupId, int cnvsStatusId, int cnvsStatusResultId = 0)
	{
		//IL_1302: Unknown result type (might be due to invalid IL or missing references)
		//IL_14ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_16a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e5c: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass48_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass48_0();
		CS_0024_003C_003E8__locals0.cnvsStatusResultId = cnvsStatusResultId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		CrmConversationStatusResultLanguageViewModel crmConversationStatusResultLanguageViewModel = new CrmConversationStatusResultLanguageViewModel();
		try
		{
			DateTime now = DateTime.Now;
			if (CS_0024_003C_003E8__locals0.cnvsStatusResultId == 0)
			{
				if (!UserLogin.IsUserAccess("frmDefinecnvsStatus", "actAddCnvsStatusResult", UserLogin.CurrentUser))
				{
					return RedirectToAction("Login", "Account", (object)new
					{
						area = "",
						d = DateTime.Now
					});
				}
				crmConversationStatusResultLanguageViewModel.ConversationStatusGroupId = cnvsStatusGroupId;
				crmConversationStatusResultLanguageViewModel.ConversationStatusId = cnvsStatusId;
				crmConversationStatusResultLanguageViewModel.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
				crmConversationStatusResultLanguageViewModel.FirstRegisterDate = now;
				crmConversationStatusResultLanguageViewModel.UserId = UserLogin.CurrentUser.UserId;
				crmConversationStatusResultLanguageViewModel.RegisterDate = now;
				crmConversationStatusResultLanguageViewModel.AppType = Configuration.AppType;
				CRMspSelectActiveEventPolicyTypesByPartName_Result cRMspSelectActiveEventPolicyTypesByPartName_Result = Enumerable.FirstOrDefault<CRMspSelectActiveEventPolicyTypesByPartName_Result>((IEnumerable<CRMspSelectActiveEventPolicyTypesByPartName_Result>)_dbI.CRMspSelectActiveEventPolicyTypesByPartName("OTP", CS_0024_003C_003E8__locals0.currLangID, CS_0024_003C_003E8__locals0.defLangID));
				if (cRMspSelectActiveEventPolicyTypesByPartName_Result != null)
				{
					CrmConversationStatusResultEventPolicyLanguageViewModel value = new CrmConversationStatusResultEventPolicyLanguageViewModel
					{
						ConversationStatusResultEventPolicyId = 0,
						ConversationStatusGroupId = cnvsStatusGroupId,
						ConversationStatusId = cnvsStatusId,
						ConversationStatusResultId = 0,
						EventPolicyTypeId = cRMspSelectActiveEventPolicyTypesByPartName_Result.EventPolicyTypeId,
						EventPolicyType = (cRMspSelectActiveEventPolicyTypesByPartName_Result.ActTitle ?? ""),
						EventPolicyReceiverId = null,
						EventPolicyReceiver = "",
						EventPolicyReceiverUsers = "",
						EventPolicyReceiverPrsJobs = "",
						EventPolicySetting = cRMspSelectActiveEventPolicyTypesByPartName_Result.JsonSetting,
						EventPolicySendTimeType = null,
						EventPolicySendTimeValue = null,
						EventPolicySendTimeValueII = null,
						EventPolicyUserCheckBeforeSend = false,
						EventPolicyShortDescription = "",
						EventPolicyBigDescription = "",
						Mode = 1,
						PartName = cRMspSelectActiveEventPolicyTypesByPartName_Result.PartName,
						HasSetting = false,
						DeActive = false,
						Row = 1,
						ActName = cRMspSelectActiveEventPolicyTypesByPartName_Result.ActName,
						EventPolicySetting_Lang = "",
						EventPolicyShortDescription_Lang = "",
						EventPolicyBigDescription_Lang = ""
					};
					crmConversationStatusResultLanguageViewModel.OTPJson = "[" + JsonConvert.SerializeObject(value) + "]";
					if (!string.IsNullOrWhiteSpace(crmConversationStatusResultLanguageViewModel.OTPJson))
					{
						crmConversationStatusResultLanguageViewModel.OTPJson = crmConversationStatusResultLanguageViewModel.OTPJson.Replace("\\\"", "\\\\\\\"");
					}
				}
				CRMspSelectActiveEventPolicyTypesByPartName_Result cRMspSelectActiveEventPolicyTypesByPartName_Result2 = Enumerable.FirstOrDefault<CRMspSelectActiveEventPolicyTypesByPartName_Result>((IEnumerable<CRMspSelectActiveEventPolicyTypesByPartName_Result>)_dbI.CRMspSelectActiveEventPolicyTypesByPartName("PORD", CS_0024_003C_003E8__locals0.currLangID, CS_0024_003C_003E8__locals0.defLangID));
				if (cRMspSelectActiveEventPolicyTypesByPartName_Result2 != null)
				{
					CrmConversationStatusResultEventPolicyLanguageViewModel value2 = new CrmConversationStatusResultEventPolicyLanguageViewModel
					{
						ConversationStatusResultEventPolicyId = 0,
						ConversationStatusGroupId = cnvsStatusGroupId,
						ConversationStatusId = cnvsStatusId,
						ConversationStatusResultId = 0,
						EventPolicyTypeId = cRMspSelectActiveEventPolicyTypesByPartName_Result2.EventPolicyTypeId,
						EventPolicyType = (cRMspSelectActiveEventPolicyTypesByPartName_Result2.ActTitle ?? ""),
						EventPolicyReceiverId = null,
						EventPolicyReceiver = "",
						EventPolicyReceiverUsers = "",
						EventPolicyReceiverPrsJobs = "",
						EventPolicySetting = cRMspSelectActiveEventPolicyTypesByPartName_Result2.JsonSetting,
						EventPolicySendTimeType = null,
						EventPolicySendTimeValue = null,
						EventPolicySendTimeValueII = null,
						EventPolicyUserCheckBeforeSend = false,
						EventPolicyShortDescription = "",
						EventPolicyBigDescription = "",
						Mode = 1,
						PartName = cRMspSelectActiveEventPolicyTypesByPartName_Result2.PartName,
						HasSetting = false,
						DeActive = false,
						Row = 1,
						ActName = cRMspSelectActiveEventPolicyTypesByPartName_Result2.ActName,
						EventPolicySetting_Lang = "",
						EventPolicyShortDescription_Lang = "",
						EventPolicyBigDescription_Lang = ""
					};
					crmConversationStatusResultLanguageViewModel.IssuePordJson = "[" + JsonConvert.SerializeObject(value2) + "]";
					if (!string.IsNullOrWhiteSpace(crmConversationStatusResultLanguageViewModel.IssuePordJson))
					{
						crmConversationStatusResultLanguageViewModel.IssuePordJson = crmConversationStatusResultLanguageViewModel.IssuePordJson.Replace("\\\"", "\\\\\\\"");
					}
				}
				CRMspSelectActiveEventPolicyTypesByPartName_Result cRMspSelectActiveEventPolicyTypesByPartName_Result3 = Enumerable.FirstOrDefault<CRMspSelectActiveEventPolicyTypesByPartName_Result>((IEnumerable<CRMspSelectActiveEventPolicyTypesByPartName_Result>)_dbI.CRMspSelectActiveEventPolicyTypesByPartName("ORD", CS_0024_003C_003E8__locals0.currLangID, CS_0024_003C_003E8__locals0.defLangID));
				if (cRMspSelectActiveEventPolicyTypesByPartName_Result3 != null)
				{
					CrmConversationStatusResultEventPolicyLanguageViewModel value3 = new CrmConversationStatusResultEventPolicyLanguageViewModel
					{
						ConversationStatusResultEventPolicyId = 0,
						ConversationStatusGroupId = cnvsStatusGroupId,
						ConversationStatusId = cnvsStatusId,
						ConversationStatusResultId = 0,
						EventPolicyTypeId = cRMspSelectActiveEventPolicyTypesByPartName_Result3.EventPolicyTypeId,
						EventPolicyType = (cRMspSelectActiveEventPolicyTypesByPartName_Result3.ActTitle ?? ""),
						EventPolicyReceiverId = null,
						EventPolicyReceiver = "",
						EventPolicyReceiverUsers = "",
						EventPolicyReceiverPrsJobs = "",
						EventPolicySetting = cRMspSelectActiveEventPolicyTypesByPartName_Result3.JsonSetting,
						EventPolicySendTimeType = null,
						EventPolicySendTimeValue = null,
						EventPolicySendTimeValueII = null,
						EventPolicyUserCheckBeforeSend = false,
						EventPolicyShortDescription = "",
						EventPolicyBigDescription = "",
						Mode = 1,
						PartName = cRMspSelectActiveEventPolicyTypesByPartName_Result3.PartName,
						HasSetting = false,
						DeActive = false,
						Row = 1,
						ActName = cRMspSelectActiveEventPolicyTypesByPartName_Result3.ActName,
						EventPolicySetting_Lang = "",
						EventPolicyShortDescription_Lang = "",
						EventPolicyBigDescription_Lang = ""
					};
					crmConversationStatusResultLanguageViewModel.IssueOrdJson = "[" + JsonConvert.SerializeObject(value3) + "]";
					if (!string.IsNullOrWhiteSpace(crmConversationStatusResultLanguageViewModel.IssueOrdJson))
					{
						crmConversationStatusResultLanguageViewModel.IssueOrdJson = crmConversationStatusResultLanguageViewModel.IssueOrdJson.Replace("\\\"", "\\\\\\\"");
					}
				}
				CRMspSelectActiveEventPolicyTypesByPartName_Result cRMspSelectActiveEventPolicyTypesByPartName_Result4 = Enumerable.FirstOrDefault<CRMspSelectActiveEventPolicyTypesByPartName_Result>((IEnumerable<CRMspSelectActiveEventPolicyTypesByPartName_Result>)_dbI.CRMspSelectActiveEventPolicyTypesByPartName("DYFORM", CS_0024_003C_003E8__locals0.currLangID, CS_0024_003C_003E8__locals0.defLangID));
				if (cRMspSelectActiveEventPolicyTypesByPartName_Result4 != null)
				{
					CrmConversationStatusResultEventPolicyLanguageViewModel value4 = new CrmConversationStatusResultEventPolicyLanguageViewModel
					{
						ConversationStatusResultEventPolicyId = 0,
						ConversationStatusGroupId = cnvsStatusGroupId,
						ConversationStatusId = cnvsStatusId,
						ConversationStatusResultId = 0,
						EventPolicyTypeId = cRMspSelectActiveEventPolicyTypesByPartName_Result4.EventPolicyTypeId,
						EventPolicyType = (cRMspSelectActiveEventPolicyTypesByPartName_Result4.ActTitle ?? ""),
						EventPolicyReceiverId = null,
						EventPolicyReceiver = "",
						EventPolicyReceiverUsers = "",
						EventPolicyReceiverPrsJobs = "",
						EventPolicySetting = cRMspSelectActiveEventPolicyTypesByPartName_Result4.JsonSetting,
						EventPolicySendTimeType = null,
						EventPolicySendTimeValue = null,
						EventPolicySendTimeValueII = null,
						EventPolicyUserCheckBeforeSend = false,
						EventPolicyShortDescription = "",
						EventPolicyBigDescription = "",
						Mode = 1,
						PartName = cRMspSelectActiveEventPolicyTypesByPartName_Result4.PartName,
						HasSetting = false,
						DeActive = false,
						Row = 1,
						ActName = cRMspSelectActiveEventPolicyTypesByPartName_Result4.ActName,
						EventPolicySetting_Lang = "",
						EventPolicyShortDescription_Lang = "",
						EventPolicyBigDescription_Lang = ""
					};
					crmConversationStatusResultLanguageViewModel.IssueDyFormJson = "[" + JsonConvert.SerializeObject(value4) + "]";
					if (!string.IsNullOrWhiteSpace(crmConversationStatusResultLanguageViewModel.IssueDyFormJson))
					{
						crmConversationStatusResultLanguageViewModel.IssueDyFormJson = crmConversationStatusResultLanguageViewModel.IssueDyFormJson.Replace("\\\"", "\\\\\\\"");
					}
				}
				CRMspSelectActiveEventPolicyTypesByPartName_Result cRMspSelectActiveEventPolicyTypesByPartName_Result5 = Enumerable.FirstOrDefault<CRMspSelectActiveEventPolicyTypesByPartName_Result>((IEnumerable<CRMspSelectActiveEventPolicyTypesByPartName_Result>)_dbI.CRMspSelectActiveEventPolicyTypesByPartName("FO", CS_0024_003C_003E8__locals0.currLangID, CS_0024_003C_003E8__locals0.defLangID));
				if (cRMspSelectActiveEventPolicyTypesByPartName_Result5 != null)
				{
					CrmConversationStatusResultEventPolicyLanguageViewModel value5 = new CrmConversationStatusResultEventPolicyLanguageViewModel
					{
						ConversationStatusResultEventPolicyId = 0,
						ConversationStatusGroupId = cnvsStatusGroupId,
						ConversationStatusId = cnvsStatusId,
						ConversationStatusResultId = 0,
						EventPolicyTypeId = cRMspSelectActiveEventPolicyTypesByPartName_Result5.EventPolicyTypeId,
						EventPolicyType = (cRMspSelectActiveEventPolicyTypesByPartName_Result5.ActTitle ?? ""),
						EventPolicyReceiverId = null,
						EventPolicyReceiver = "",
						EventPolicyReceiverUsers = "",
						EventPolicyReceiverPrsJobs = "",
						EventPolicySetting = cRMspSelectActiveEventPolicyTypesByPartName_Result5.JsonSetting,
						EventPolicySendTimeType = null,
						EventPolicySendTimeValue = null,
						EventPolicySendTimeValueII = null,
						EventPolicyUserCheckBeforeSend = false,
						EventPolicyShortDescription = "",
						EventPolicyBigDescription = "",
						Mode = 1,
						PartName = cRMspSelectActiveEventPolicyTypesByPartName_Result5.PartName,
						HasSetting = false,
						DeActive = false,
						Row = 1,
						ActName = cRMspSelectActiveEventPolicyTypesByPartName_Result5.ActName,
						EventPolicySetting_Lang = "",
						EventPolicyShortDescription_Lang = "",
						EventPolicyBigDescription_Lang = ""
					};
					crmConversationStatusResultLanguageViewModel.FOJson = "[" + JsonConvert.SerializeObject(value5) + "]";
					if (!string.IsNullOrWhiteSpace(crmConversationStatusResultLanguageViewModel.FOJson))
					{
						crmConversationStatusResultLanguageViewModel.FOJson = crmConversationStatusResultLanguageViewModel.FOJson.Replace("\\\"", "\\\\\\\"");
					}
				}
				CRMspSelectActiveEventPolicyTypesByPartName_Result cRMspSelectActiveEventPolicyTypesByPartName_Result6 = Enumerable.FirstOrDefault<CRMspSelectActiveEventPolicyTypesByPartName_Result>((IEnumerable<CRMspSelectActiveEventPolicyTypesByPartName_Result>)_dbI.CRMspSelectActiveEventPolicyTypesByPartName("SHP", CS_0024_003C_003E8__locals0.currLangID, CS_0024_003C_003E8__locals0.defLangID));
				if (cRMspSelectActiveEventPolicyTypesByPartName_Result6 != null)
				{
					CrmConversationStatusResultEventPolicyLanguageViewModel value6 = new CrmConversationStatusResultEventPolicyLanguageViewModel
					{
						ConversationStatusResultEventPolicyId = 0,
						ConversationStatusGroupId = cnvsStatusGroupId,
						ConversationStatusId = cnvsStatusId,
						ConversationStatusResultId = 0,
						EventPolicyTypeId = cRMspSelectActiveEventPolicyTypesByPartName_Result6.EventPolicyTypeId,
						EventPolicyType = (cRMspSelectActiveEventPolicyTypesByPartName_Result6.ActTitle ?? ""),
						EventPolicyReceiverId = null,
						EventPolicyReceiver = "",
						EventPolicyReceiverUsers = "",
						EventPolicyReceiverPrsJobs = "",
						EventPolicySetting = cRMspSelectActiveEventPolicyTypesByPartName_Result6.JsonSetting,
						EventPolicySendTimeType = null,
						EventPolicySendTimeValue = null,
						EventPolicySendTimeValueII = null,
						EventPolicyUserCheckBeforeSend = false,
						EventPolicyShortDescription = "",
						EventPolicyBigDescription = "",
						Mode = 1,
						PartName = cRMspSelectActiveEventPolicyTypesByPartName_Result6.PartName,
						HasSetting = false,
						DeActive = false,
						Row = 1,
						ActName = cRMspSelectActiveEventPolicyTypesByPartName_Result6.ActName,
						EventPolicySetting_Lang = "",
						EventPolicyShortDescription_Lang = "",
						EventPolicyBigDescription_Lang = ""
					};
					crmConversationStatusResultLanguageViewModel.ShpJson = "[" + JsonConvert.SerializeObject(value6) + "]";
					if (!string.IsNullOrWhiteSpace(crmConversationStatusResultLanguageViewModel.ShpJson))
					{
						crmConversationStatusResultLanguageViewModel.ShpJson = crmConversationStatusResultLanguageViewModel.ShpJson.Replace("\\\"", "\\\\\\\"");
					}
				}
				CRMspSelectActiveEventPolicyTypesByPartName_Result cRMspSelectActiveEventPolicyTypesByPartName_Result7 = Enumerable.FirstOrDefault<CRMspSelectActiveEventPolicyTypesByPartName_Result>((IEnumerable<CRMspSelectActiveEventPolicyTypesByPartName_Result>)_dbI.CRMspSelectActiveEventPolicyTypesByPartName("PRJ", CS_0024_003C_003E8__locals0.currLangID, CS_0024_003C_003E8__locals0.defLangID));
				if (cRMspSelectActiveEventPolicyTypesByPartName_Result7 != null)
				{
					CrmConversationStatusResultEventPolicyLanguageViewModel value7 = new CrmConversationStatusResultEventPolicyLanguageViewModel
					{
						ConversationStatusResultEventPolicyId = 0,
						ConversationStatusGroupId = cnvsStatusGroupId,
						ConversationStatusId = cnvsStatusId,
						ConversationStatusResultId = 0,
						EventPolicyTypeId = cRMspSelectActiveEventPolicyTypesByPartName_Result7.EventPolicyTypeId,
						EventPolicyType = (cRMspSelectActiveEventPolicyTypesByPartName_Result.ActTitle ?? ""),
						EventPolicyReceiverId = null,
						EventPolicyReceiver = "",
						EventPolicyReceiverUsers = "",
						EventPolicyReceiverPrsJobs = "",
						EventPolicySetting = cRMspSelectActiveEventPolicyTypesByPartName_Result7.JsonSetting,
						EventPolicySendTimeType = null,
						EventPolicySendTimeValue = null,
						EventPolicySendTimeValueII = null,
						EventPolicyUserCheckBeforeSend = false,
						EventPolicyShortDescription = "",
						EventPolicyBigDescription = "",
						Mode = 1,
						PartName = cRMspSelectActiveEventPolicyTypesByPartName_Result7.PartName,
						HasSetting = false,
						DeActive = false,
						Row = 1,
						ActName = cRMspSelectActiveEventPolicyTypesByPartName_Result7.ActName,
						EventPolicySetting_Lang = "",
						EventPolicyShortDescription_Lang = "",
						EventPolicyBigDescription_Lang = ""
					};
					crmConversationStatusResultLanguageViewModel.AddPrjJson = "[" + JsonConvert.SerializeObject(value7) + "]";
					if (!string.IsNullOrWhiteSpace(crmConversationStatusResultLanguageViewModel.AddPrjJson))
					{
						crmConversationStatusResultLanguageViewModel.AddPrjJson = crmConversationStatusResultLanguageViewModel.AddPrjJson.Replace("\\\"", "\\\\\\\"");
					}
				}
				List<CRMspSelectConversationStatusResult_Result> list = Enumerable.ToList<CRMspSelectConversationStatusResult_Result>((IEnumerable<CRMspSelectConversationStatusResult_Result>)_dbI.CRMspSelectConversationStatusResult(cnvsStatusId, CS_0024_003C_003E8__locals0.currLangID, CS_0024_003C_003E8__locals0.defLangID));
				if (!Enumerable.Any<CRMspSelectConversationStatusResult_Result>((IEnumerable<CRMspSelectConversationStatusResult_Result>)list))
				{
					crmConversationStatusResultLanguageViewModel.OrderView = 10;
				}
				else
				{
					int num = (Enumerable.Any<CRMspSelectConversationStatusResult_Result>((IEnumerable<CRMspSelectConversationStatusResult_Result>)list) ? Enumerable.Count<CRMspSelectConversationStatusResult_Result>((IEnumerable<CRMspSelectConversationStatusResult_Result>)list) : 0);
					crmConversationStatusResultLanguageViewModel.OrderView = num * 10 + 10;
					if (Enumerable.LastOrDefault<CRMspSelectConversationStatusResult_Result>((IEnumerable<CRMspSelectConversationStatusResult_Result>)list) != null)
					{
						int valueOrDefault = Enumerable.LastOrDefault<CRMspSelectConversationStatusResult_Result>((IEnumerable<CRMspSelectConversationStatusResult_Result>)list).OrderView.GetValueOrDefault();
						if (valueOrDefault > 0)
						{
							crmConversationStatusResultLanguageViewModel.OrderView = valueOrDefault + 10;
						}
					}
				}
			}
			else
			{
				if (!UserLogin.IsUserAccess("frmDefinecnvsStatus", "actEditCnvsStatusResult", UserLogin.CurrentUser))
				{
					return RedirectToAction("Login", "Account", (object)new
					{
						area = "",
						d = DateTime.Now
					});
				}
				DbSet<CrmConversationStatusResult_Lang> crmConversationStatusResult_Lang = _dbTbl.CrmConversationStatusResult_Lang;
				ParameterExpression val = Expression.Parameter(typeof(CrmConversationStatusResult_Lang), "c");
				List<CrmConversationStatusResult_Lang> list2 = Enumerable.ToList<CrmConversationStatusResult_Lang>((IEnumerable<CrmConversationStatusResult_Lang>)Queryable.Where<CrmConversationStatusResult_Lang>((IQueryable<CrmConversationStatusResult_Lang>)crmConversationStatusResult_Lang, Expression.Lambda<Func<CrmConversationStatusResult_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass48_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				CRMspSelectConversationStatusResultById_Result cRMspSelectConversationStatusResultById_Result = Enumerable.FirstOrDefault<CRMspSelectConversationStatusResultById_Result>((IEnumerable<CRMspSelectConversationStatusResultById_Result>)_dbI.CRMspSelectConversationStatusResultById(CS_0024_003C_003E8__locals0.cnvsStatusResultId, CS_0024_003C_003E8__locals0.defLangID, CS_0024_003C_003E8__locals0.defLangID));
				if (cRMspSelectConversationStatusResultById_Result != null)
				{
					List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmConversationStatusResult_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmConversationStatusResult_Lang>)list2, (Func<CrmConversationStatusResult_Lang, CommonMultiLanguageViewModel>)((CrmConversationStatusResult_Lang item) => new CommonMultiLanguageViewModel
					{
						Value = item.ResultTitle,
						LanguageId = item.LanguageID
					})));
					list3.Add(new CommonMultiLanguageViewModel
					{
						Value = cRMspSelectConversationStatusResultById_Result.ResultTitle,
						LanguageId = CS_0024_003C_003E8__locals0.defLangID
					});
					List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmConversationStatusResult_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmConversationStatusResult_Lang>)list2, (Func<CrmConversationStatusResult_Lang, CommonMultiLanguageViewModel>)((CrmConversationStatusResult_Lang item) => new CommonMultiLanguageViewModel
					{
						Value = item.ResultDesc,
						LanguageId = item.LanguageID
					})));
					list4.Add(new CommonMultiLanguageViewModel
					{
						Value = cRMspSelectConversationStatusResultById_Result.ResultDesc,
						LanguageId = CS_0024_003C_003E8__locals0.defLangID
					});
					List<CommonMultiLanguageViewModel> list5 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmConversationStatusResult_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmConversationStatusResult_Lang>)list2, (Func<CrmConversationStatusResult_Lang, CommonMultiLanguageViewModel>)((CrmConversationStatusResult_Lang item) => new CommonMultiLanguageViewModel
					{
						Value = item.CnvsDesc,
						LanguageId = item.LanguageID
					})));
					list5.Add(new CommonMultiLanguageViewModel
					{
						Value = cRMspSelectConversationStatusResultById_Result.CnvsDesc,
						LanguageId = CS_0024_003C_003E8__locals0.defLangID
					});
					List<CommonMultiLanguageViewModel> list6 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmConversationStatusResult_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmConversationStatusResult_Lang>)list2, (Func<CrmConversationStatusResult_Lang, CommonMultiLanguageViewModel>)((CrmConversationStatusResult_Lang item) => new CommonMultiLanguageViewModel
					{
						Value = item.CnvsReferDesc,
						LanguageId = item.LanguageID
					})));
					list6.Add(new CommonMultiLanguageViewModel
					{
						Value = cRMspSelectConversationStatusResultById_Result.CnvsReferDesc,
						LanguageId = CS_0024_003C_003E8__locals0.defLangID
					});
					crmConversationStatusResultLanguageViewModel = new CrmConversationStatusResultLanguageViewModel
					{
						ConversationStatusResultId = cRMspSelectConversationStatusResultById_Result.ConversationStatusResultId,
						ConversationStatusGroupId = cRMspSelectConversationStatusResultById_Result.ConversationStatusGroupId,
						ConversationStatusId = cRMspSelectConversationStatusResultById_Result.ConversationStatusId,
						ResultTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
						ResultTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
						ResultDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
						ResultDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
						EventPolicyActive = cRMspSelectConversationStatusResultById_Result.EventPolicyActive,
						OTPSendActive = cRMspSelectConversationStatusResultById_Result.OTPSendActive,
						IssuePordActive = cRMspSelectConversationStatusResultById_Result.IssuePordActive,
						IssueOrdActive = cRMspSelectConversationStatusResultById_Result.IssueOrdActive,
						IssueDyFormActive = cRMspSelectConversationStatusResultById_Result.IssueDyFormActive,
						NeedDyFormChecked = cRMspSelectConversationStatusResultById_Result.NeedDyFormChecked,
						NeedDyFormCheckedFormId = cRMspSelectConversationStatusResultById_Result.NeedDyFormCheckedFormId,
						PrjFinished = cRMspSelectConversationStatusResultById_Result.PrjFinished,
						NoCnvsDup = cRMspSelectConversationStatusResultById_Result.NoCnvsDup,
						StatusResultUsedUserIds = cRMspSelectConversationStatusResultById_Result.StatusResultUsedUserIds,
						StatusResultUsedUsersjson = cRMspSelectConversationStatusResultById_Result.StatusResultUsedUsersJson,
						DoingTimeEndDeadlineMin = cRMspSelectConversationStatusResultById_Result.DoingTimeEndDeadlineMin,
						DoingTimeEndCnvsStatusId = cRMspSelectConversationStatusResultById_Result.DoingTimeEndCnvsStatusId,
						DoingTimeEndCnvsStatusResultId = cRMspSelectConversationStatusResultById_Result.DoingTimeEndCnvsStatusResultId,
						CnvsCountLimit = cRMspSelectConversationStatusResultById_Result.CnvsCountLimit,
						CnvsDoingTimeLimit = cRMspSelectConversationStatusResultById_Result.CnvsDoingTimeLimit,
						CnvsDoingTimeNotNull = cRMspSelectConversationStatusResultById_Result.CnvsDoingTimeNotNull,
						CnvsRemindDateNotNull = cRMspSelectConversationStatusResultById_Result.CnvsRemindDateNotNull,
						CnvsRemindDateForAllarmNotNull = cRMspSelectConversationStatusResultById_Result.CnvsRemindDateForAllarmNotNull,
						CnvsTopicId = cRMspSelectConversationStatusResultById_Result.CnvsTopicId,
						CnvsReferUserId = cRMspSelectConversationStatusResultById_Result.CnvsReferUserId,
						CnvsReferUserNoChange = cRMspSelectConversationStatusResultById_Result.CnvsReferUserNoChange,
						CnvsRemindDay = cRMspSelectConversationStatusResultById_Result.CnvsRemindDay,
						CnvsDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
						CnvsDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
						CnvsReferDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
						CnvsReferDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
						IsDefault = cRMspSelectConversationStatusResultById_Result.IsDefault,
						DeActive = cRMspSelectConversationStatusResultById_Result.DeActive,
						OrderView = cRMspSelectConversationStatusResultById_Result.OrderView,
						UpdateCmpGroupActive = cRMspSelectConversationStatusResultById_Result.UpdateCmpGroupActive,
						UpdateCmpGroupActiveJson = cRMspSelectConversationStatusResultById_Result.UpdateCmpGroupActiveJson,
						EventPolicyJson = cRMspSelectConversationStatusResultById_Result.EventPolicyJson,
						FirstRegisterUserId = cRMspSelectConversationStatusResultById_Result.FirstRegisterUserId,
						FirstRegisterDate = cRMspSelectConversationStatusResultById_Result.FirstRegisterDate,
						UserId = cRMspSelectConversationStatusResultById_Result.UserId,
						RegisterDate = cRMspSelectConversationStatusResultById_Result.RegisterDate,
						AppType = cRMspSelectConversationStatusResultById_Result.AppType,
						AddPrjActive = cRMspSelectConversationStatusResultById_Result.AddPrjActive
					};
					if (crmConversationStatusResultLanguageViewModel != null)
					{
						if (!string.IsNullOrWhiteSpace(crmConversationStatusResultLanguageViewModel.UpdateCmpGroupActiveJson))
						{
							CrmConversationStatusResultUpdateCmpGroupActiveViewModel crmConversationStatusResultUpdateCmpGroupActiveViewModel = new JavaScriptSerializer().Deserialize<CrmConversationStatusResultUpdateCmpGroupActiveViewModel>(crmConversationStatusResultLanguageViewModel.UpdateCmpGroupActiveJson.Replace("[", "").Replace("]", ""));
							if (crmConversationStatusResultUpdateCmpGroupActiveViewModel != null)
							{
								int result = 0;
								int.TryParse(crmConversationStatusResultUpdateCmpGroupActiveViewModel.cmpGroupId.ToString(), out result);
								if (result != 0)
								{
									crmConversationStatusResultLanguageViewModel.CmpGroupId = result;
									crmConversationStatusResultLanguageViewModel.IsUpdateCmpGroup = true;
								}
								int result2 = 0;
								int.TryParse(crmConversationStatusResultUpdateCmpGroupActiveViewModel.cmpSubGroupId.ToString(), out result2);
								if (result2 != 0)
								{
									crmConversationStatusResultLanguageViewModel.CmpSubGroupId = result2;
									crmConversationStatusResultLanguageViewModel.IsUpdateCmpSubGroup = true;
								}
								int result3 = 0;
								int.TryParse(crmConversationStatusResultUpdateCmpGroupActiveViewModel.cmpGroupIIId.ToString(), out result3);
								if (result3 != 0)
								{
									crmConversationStatusResultLanguageViewModel.CmpGroupIIId = result3;
									crmConversationStatusResultLanguageViewModel.IsUpdateCmpGroupII = true;
								}
								int result4 = 0;
								int.TryParse(crmConversationStatusResultUpdateCmpGroupActiveViewModel.cmpGroupIIIId.ToString(), out result4);
								if (result4 != 0)
								{
									crmConversationStatusResultLanguageViewModel.CmpGroupIIIId = result4;
									crmConversationStatusResultLanguageViewModel.IsUpdateCmpGroupIII = true;
								}
								int result5 = 0;
								int.TryParse(crmConversationStatusResultUpdateCmpGroupActiveViewModel.cmpGroupIVId.ToString(), out result5);
								if (result5 != 0)
								{
									crmConversationStatusResultLanguageViewModel.CmpGroupIVId = result5;
									crmConversationStatusResultLanguageViewModel.IsUpdateCmpGroupIV = true;
								}
								int result6 = 0;
								int.TryParse(crmConversationStatusResultUpdateCmpGroupActiveViewModel.cmpTypeId.ToString(), out result6);
								if (result6 != 0)
								{
									crmConversationStatusResultLanguageViewModel.CmpTypeId = result6;
									crmConversationStatusResultLanguageViewModel.IsUpdateCmpType = true;
								}
							}
						}
						if (!string.IsNullOrWhiteSpace(crmConversationStatusResultLanguageViewModel.StatusResultUsedUsersjson))
						{
							List<CrmConversationStatusResultStatusResultUsedUsersViewModel> list7 = new JavaScriptSerializer().Deserialize<List<CrmConversationStatusResultStatusResultUsedUsersViewModel>>(crmConversationStatusResultLanguageViewModel.StatusResultUsedUsersjson);
							if (list7 != null)
							{
								crmConversationStatusResultLanguageViewModel.StatusResultUsedUsersjson = JsonConvert.SerializeObject(Enumerable.ToList<CrmConversationStatusResultStatusResultUsedUsersViewModel>((IEnumerable<CrmConversationStatusResultStatusResultUsedUsersViewModel>)list7));
							}
						}
						List<CrmConversationStatusResultEventPolicyLanguageViewModel> list8 = new List<CrmConversationStatusResultEventPolicyLanguageViewModel>();
						CrmConversationStatusResultEventPolicyLanguageViewModel crmConversationStatusResultEventPolicyLanguageViewModel = new CrmConversationStatusResultEventPolicyLanguageViewModel();
						CrmConversationStatusResultEventPolicyLanguageViewModel crmConversationStatusResultEventPolicyLanguageViewModel2 = new CrmConversationStatusResultEventPolicyLanguageViewModel();
						CrmConversationStatusResultEventPolicyLanguageViewModel crmConversationStatusResultEventPolicyLanguageViewModel3 = new CrmConversationStatusResultEventPolicyLanguageViewModel();
						CrmConversationStatusResultEventPolicyLanguageViewModel crmConversationStatusResultEventPolicyLanguageViewModel4 = new CrmConversationStatusResultEventPolicyLanguageViewModel();
						CrmConversationStatusResultEventPolicyLanguageViewModel crmConversationStatusResultEventPolicyLanguageViewModel5 = new CrmConversationStatusResultEventPolicyLanguageViewModel();
						CrmConversationStatusResultEventPolicyLanguageViewModel crmConversationStatusResultEventPolicyLanguageViewModel6 = new CrmConversationStatusResultEventPolicyLanguageViewModel();
						CrmConversationStatusResultEventPolicyLanguageViewModel crmConversationStatusResultEventPolicyLanguageViewModel7 = new CrmConversationStatusResultEventPolicyLanguageViewModel();
						List<CRMspSelectConversationStatusResultEventPolicyByCnvsStatusResultId_Result> list9 = Enumerable.ToList<CRMspSelectConversationStatusResultEventPolicyByCnvsStatusResultId_Result>((IEnumerable<CRMspSelectConversationStatusResultEventPolicyByCnvsStatusResultId_Result>)_dbI.CRMspSelectConversationStatusResultEventPolicyByCnvsStatusResultId(crmConversationStatusResultLanguageViewModel.ConversationStatusResultId, CS_0024_003C_003E8__locals0.currLangID, CS_0024_003C_003E8__locals0.defLangID));
						if (list9 != null && Enumerable.Any<CRMspSelectConversationStatusResultEventPolicyByCnvsStatusResultId_Result>((IEnumerable<CRMspSelectConversationStatusResultEventPolicyByCnvsStatusResultId_Result>)list9))
						{
							int num2 = 1;
							foreach (CRMspSelectConversationStatusResultEventPolicyByCnvsStatusResultId_Result item in list9)
							{
								CrmConversationStatusResultEventPolicyLanguageViewModel crmConversationStatusResultEventPolicyLanguageViewModel8 = new CrmConversationStatusResultEventPolicyLanguageViewModel
								{
									ConversationStatusResultEventPolicyId = item.ConversationStatusResultEventPolicyId,
									ConversationStatusGroupId = item.ConversationStatusGroupId,
									ConversationStatusId = item.ConversationStatusId,
									ConversationStatusResultId = item.ConversationStatusResultId,
									EventPolicyTypeId = item.EventPolicyTypeId,
									EventPolicyType = item.EventPolicyTypeActTitle,
									EventPolicyReceiverId = item.EventPolicyReceiverId,
									EventPolicyReceiver = item.EventPolicyReceiver,
									EventPolicySetting = item.EventPolicySetting,
									EventPolicySendTimeType = item.EventPolicySendTimeType,
									EventPolicySendTimeValue = item.EventPolicySendTimeValue,
									EventPolicySendTimeValueII = item.EventPolicySendTimeValueII,
									EventPolicyUserCheckBeforeSend = item.EventPolicyUserCheckBeforeSend,
									EventPolicyShortDescription = item.EventPolicyShortDescription,
									EventPolicyBigDescription = item.EventPolicyBigDescription,
									DeActive = item.DeActive,
									PartName = item.EventPolicyTypePartName,
									HasSetting = true,
									ActName = item.EventPolicyTypeActName,
									EventPolicyDescription_Lang = item.ConversationStatusResultEventPolicyLang
								};
								if (!string.IsNullOrWhiteSpace(item.EventPolicySetting))
								{
									string text = item.EventPolicySetting.Replace("\\", "");
									List<object> list10 = new JavaScriptSerializer().Deserialize<List<object>>(text);
									if (list10 != null && Enumerable.Any<object>((IEnumerable<object>)list10))
									{
										for (int i = 0; i < list10.Count; i++)
										{
											if (_003C_003Eo__48._003C_003Ep__5 == null)
											{
												_003C_003Eo__48._003C_003Ep__5 = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)83, typeof(ConversationStatusResultController), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
											}
											Func<CallSite, object, bool> target = _003C_003Eo__48._003C_003Ep__5.Target;
											CallSite<Func<CallSite, object, bool>> _003C_003Ep__ = _003C_003Eo__48._003C_003Ep__5;
											if (_003C_003Eo__48._003C_003Ep__0 == null)
											{
												_003C_003Eo__48._003C_003Ep__0 = CallSite<Func<CallSite, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)35, typeof(ConversationStatusResultController), new CSharpArgumentInfo[2]
												{
													CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
													CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
												}));
											}
											object obj = _003C_003Eo__48._003C_003Ep__0.Target((CallSite)(object)_003C_003Eo__48._003C_003Ep__0, list10[i], null);
											if (_003C_003Eo__48._003C_003Ep__4 == null)
											{
												_003C_003Eo__48._003C_003Ep__4 = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)84, typeof(ConversationStatusResultController), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
											}
											object arg;
											if (!_003C_003Eo__48._003C_003Ep__4.Target((CallSite)(object)_003C_003Eo__48._003C_003Ep__4, obj))
											{
												if (_003C_003Eo__48._003C_003Ep__3 == null)
												{
													_003C_003Eo__48._003C_003Ep__3 = CallSite<Func<CallSite, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, (ExpressionType)2, typeof(ConversationStatusResultController), new CSharpArgumentInfo[2]
													{
														CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
														CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
													}));
												}
												Func<CallSite, object, object, object> target2 = _003C_003Eo__48._003C_003Ep__3.Target;
												CallSite<Func<CallSite, object, object, object>> _003C_003Ep__2 = _003C_003Eo__48._003C_003Ep__3;
												if (_003C_003Eo__48._003C_003Ep__2 == null)
												{
													_003C_003Eo__48._003C_003Ep__2 = CallSite<Func<CallSite, object, int, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)15, typeof(ConversationStatusResultController), new CSharpArgumentInfo[2]
													{
														CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
														CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
													}));
												}
												arg = target2((CallSite)(object)_003C_003Ep__2, obj, _003C_003Eo__48._003C_003Ep__2.Target((CallSite)(object)_003C_003Eo__48._003C_003Ep__2, (object)((dynamic)list10[i]).Count, 0));
											}
											else
											{
												arg = obj;
											}
											if (!target((CallSite)(object)_003C_003Ep__, arg))
											{
												continue;
											}
											foreach (dynamic item2 in (dynamic)list10[i])
											{
												dynamic val2 = item2.Key;
												dynamic val3 = item2.Value;
												if (_003C_003Eo__48._003C_003Ep__10 == null)
												{
													_003C_003Eo__48._003C_003Ep__10 = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)83, typeof(ConversationStatusResultController), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
												}
												Func<CallSite, object, bool> target3 = _003C_003Eo__48._003C_003Ep__10.Target;
												CallSite<Func<CallSite, object, bool>> _003C_003Ep__3 = _003C_003Eo__48._003C_003Ep__10;
												if (_003C_003Eo__48._003C_003Ep__9 == null)
												{
													_003C_003Eo__48._003C_003Ep__9 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)34, typeof(ConversationStatusResultController), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
												}
												if (!target3((CallSite)(object)_003C_003Ep__3, _003C_003Eo__48._003C_003Ep__9.Target((CallSite)(object)_003C_003Eo__48._003C_003Ep__9, (object)string.IsNullOrWhiteSpace(val2))))
												{
													continue;
												}
												switch (val2 as string)
												{
												case "EventPolicyReceiverUsers":
												{
													dynamic val5 = val3.ToString();
													if (_003C_003Eo__48._003C_003Ep__14 == null)
													{
														_003C_003Eo__48._003C_003Ep__14 = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)83, typeof(ConversationStatusResultController), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
													}
													Func<CallSite, object, bool> target5 = _003C_003Eo__48._003C_003Ep__14.Target;
													CallSite<Func<CallSite, object, bool>> _003C_003Ep__5 = _003C_003Eo__48._003C_003Ep__14;
													if (_003C_003Eo__48._003C_003Ep__13 == null)
													{
														_003C_003Eo__48._003C_003Ep__13 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)34, typeof(ConversationStatusResultController), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
													}
													if (target5((CallSite)(object)_003C_003Ep__5, _003C_003Eo__48._003C_003Ep__13.Target((CallSite)(object)_003C_003Eo__48._003C_003Ep__13, (object)string.IsNullOrWhiteSpace(val5))))
													{
														crmConversationStatusResultEventPolicyLanguageViewModel8.EventPolicyReceiverUsers = val5;
													}
													break;
												}
												case "EventPolicyReceiverPrsJobs":
												{
													dynamic val4 = val3.ToString();
													if (_003C_003Eo__48._003C_003Ep__19 == null)
													{
														_003C_003Eo__48._003C_003Ep__19 = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)83, typeof(ConversationStatusResultController), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
													}
													Func<CallSite, object, bool> target4 = _003C_003Eo__48._003C_003Ep__19.Target;
													CallSite<Func<CallSite, object, bool>> _003C_003Ep__4 = _003C_003Eo__48._003C_003Ep__19;
													if (_003C_003Eo__48._003C_003Ep__18 == null)
													{
														_003C_003Eo__48._003C_003Ep__18 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)34, typeof(ConversationStatusResultController), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
													}
													if (target4((CallSite)(object)_003C_003Ep__4, _003C_003Eo__48._003C_003Ep__18.Target((CallSite)(object)_003C_003Eo__48._003C_003Ep__18, (object)string.IsNullOrWhiteSpace(val4))))
													{
														crmConversationStatusResultEventPolicyLanguageViewModel8.EventPolicyReceiverPrsJobs = val4;
													}
													break;
												}
												}
											}
										}
									}
								}
								List<CommonMultiLanguageViewModel> list11 = new List<CommonMultiLanguageViewModel>();
								List<CommonMultiLanguageViewModel> list12 = new List<CommonMultiLanguageViewModel>();
								List<CommonMultiLanguageViewModel> list13 = new List<CommonMultiLanguageViewModel>();
								if (!string.IsNullOrWhiteSpace(crmConversationStatusResultEventPolicyLanguageViewModel8.EventPolicyDescription_Lang))
								{
									List<CrmConversationStatusResultEventPolicy_LangViewModel> list14 = new JavaScriptSerializer().Deserialize<List<CrmConversationStatusResultEventPolicy_LangViewModel>>(crmConversationStatusResultEventPolicyLanguageViewModel8.EventPolicyDescription_Lang);
									if (list14 != null && Enumerable.Any<CrmConversationStatusResultEventPolicy_LangViewModel>((IEnumerable<CrmConversationStatusResultEventPolicy_LangViewModel>)list14))
									{
										list11 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmConversationStatusResultEventPolicy_LangViewModel, CommonMultiLanguageViewModel>((IEnumerable<CrmConversationStatusResultEventPolicy_LangViewModel>)list14, (Func<CrmConversationStatusResultEventPolicy_LangViewModel, CommonMultiLanguageViewModel>)((CrmConversationStatusResultEventPolicy_LangViewModel itemLang) => new CommonMultiLanguageViewModel
										{
											Value = itemLang.EventPolicySetting,
											LanguageId = itemLang.LanguageID
										})));
										list12 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmConversationStatusResultEventPolicy_LangViewModel, CommonMultiLanguageViewModel>((IEnumerable<CrmConversationStatusResultEventPolicy_LangViewModel>)list14, (Func<CrmConversationStatusResultEventPolicy_LangViewModel, CommonMultiLanguageViewModel>)((CrmConversationStatusResultEventPolicy_LangViewModel itemLang) => new CommonMultiLanguageViewModel
										{
											Value = itemLang.EventPolicyShortDescription,
											LanguageId = itemLang.LanguageID
										})));
										list13 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmConversationStatusResultEventPolicy_LangViewModel, CommonMultiLanguageViewModel>((IEnumerable<CrmConversationStatusResultEventPolicy_LangViewModel>)list14, (Func<CrmConversationStatusResultEventPolicy_LangViewModel, CommonMultiLanguageViewModel>)((CrmConversationStatusResultEventPolicy_LangViewModel itemLang) => new CommonMultiLanguageViewModel
										{
											Value = itemLang.EventPolicyBigDescription,
											LanguageId = itemLang.LanguageID
										})));
									}
								}
								list11.Add(new CommonMultiLanguageViewModel
								{
									Value = item.EventPolicySetting,
									LanguageId = CS_0024_003C_003E8__locals0.defLangID
								});
								list12.Add(new CommonMultiLanguageViewModel
								{
									Value = item.EventPolicyShortDescription,
									LanguageId = CS_0024_003C_003E8__locals0.defLangID
								});
								list13.Add(new CommonMultiLanguageViewModel
								{
									Value = item.EventPolicyBigDescription,
									LanguageId = CS_0024_003C_003E8__locals0.defLangID
								});
								crmConversationStatusResultEventPolicyLanguageViewModel8.EventPolicySetting = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : "");
								crmConversationStatusResultEventPolicyLanguageViewModel8.EventPolicyShortDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
								crmConversationStatusResultEventPolicyLanguageViewModel8.EventPolicyBigDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
								crmConversationStatusResultEventPolicyLanguageViewModel8.EventPolicySetting_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.defLangID))));
								crmConversationStatusResultEventPolicyLanguageViewModel8.EventPolicyBigDescription_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
								crmConversationStatusResultEventPolicyLanguageViewModel8.EventPolicyBigDescription_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
								if (crmConversationStatusResultEventPolicyLanguageViewModel8.PartName == "OTP")
								{
									crmConversationStatusResultEventPolicyLanguageViewModel8.Row = 1;
									crmConversationStatusResultEventPolicyLanguageViewModel = crmConversationStatusResultEventPolicyLanguageViewModel8;
								}
								else if (crmConversationStatusResultEventPolicyLanguageViewModel8.PartName == "PORD")
								{
									crmConversationStatusResultEventPolicyLanguageViewModel8.Row = 1;
									crmConversationStatusResultEventPolicyLanguageViewModel2 = crmConversationStatusResultEventPolicyLanguageViewModel8;
								}
								else if (crmConversationStatusResultEventPolicyLanguageViewModel8.PartName == "ORD")
								{
									crmConversationStatusResultEventPolicyLanguageViewModel8.Row = 1;
									crmConversationStatusResultEventPolicyLanguageViewModel3 = crmConversationStatusResultEventPolicyLanguageViewModel8;
								}
								else if (crmConversationStatusResultEventPolicyLanguageViewModel8.PartName == "DYFORM")
								{
									crmConversationStatusResultEventPolicyLanguageViewModel8.Row = 1;
									crmConversationStatusResultEventPolicyLanguageViewModel4 = crmConversationStatusResultEventPolicyLanguageViewModel8;
								}
								else if (crmConversationStatusResultEventPolicyLanguageViewModel8.PartName == "FO")
								{
									crmConversationStatusResultEventPolicyLanguageViewModel8.Row = 1;
									crmConversationStatusResultEventPolicyLanguageViewModel5 = crmConversationStatusResultEventPolicyLanguageViewModel8;
								}
								else if (crmConversationStatusResultEventPolicyLanguageViewModel8.PartName == "SHP")
								{
									crmConversationStatusResultEventPolicyLanguageViewModel8.Row = 1;
									crmConversationStatusResultEventPolicyLanguageViewModel6 = crmConversationStatusResultEventPolicyLanguageViewModel8;
								}
								else if (crmConversationStatusResultEventPolicyLanguageViewModel8.PartName == "PRJ")
								{
									crmConversationStatusResultEventPolicyLanguageViewModel8.Row = 1;
									crmConversationStatusResultEventPolicyLanguageViewModel7 = crmConversationStatusResultEventPolicyLanguageViewModel8;
								}
								else
								{
									crmConversationStatusResultEventPolicyLanguageViewModel8.Row = num2;
									list8.Add(crmConversationStatusResultEventPolicyLanguageViewModel8);
									num2++;
								}
							}
						}
						if (list8 != null)
						{
							crmConversationStatusResultLanguageViewModel.EventPolicyJson = JsonConvert.SerializeObject(Enumerable.ToList<CrmConversationStatusResultEventPolicyLanguageViewModel>((IEnumerable<CrmConversationStatusResultEventPolicyLanguageViewModel>)list8));
						}
						if (crmConversationStatusResultEventPolicyLanguageViewModel != null)
						{
							crmConversationStatusResultLanguageViewModel.OTPJson = "[" + JsonConvert.SerializeObject(crmConversationStatusResultEventPolicyLanguageViewModel) + "]";
							if (!string.IsNullOrWhiteSpace(crmConversationStatusResultLanguageViewModel.OTPJson))
							{
								crmConversationStatusResultLanguageViewModel.OTPJson = crmConversationStatusResultLanguageViewModel.OTPJson.Replace("\\\"", "\\\\\\\"");
							}
						}
						if (crmConversationStatusResultEventPolicyLanguageViewModel2 != null)
						{
							crmConversationStatusResultLanguageViewModel.IssuePordJson = "[" + JsonConvert.SerializeObject(crmConversationStatusResultEventPolicyLanguageViewModel2) + "]";
							if (!string.IsNullOrWhiteSpace(crmConversationStatusResultLanguageViewModel.IssuePordJson))
							{
								crmConversationStatusResultLanguageViewModel.IssuePordJson = crmConversationStatusResultLanguageViewModel.IssuePordJson.Replace("\\\"", "\\\\\\\"");
							}
						}
						if (crmConversationStatusResultEventPolicyLanguageViewModel3 != null)
						{
							crmConversationStatusResultLanguageViewModel.IssueOrdJson = "[" + JsonConvert.SerializeObject(crmConversationStatusResultEventPolicyLanguageViewModel3) + "]";
							if (!string.IsNullOrWhiteSpace(crmConversationStatusResultLanguageViewModel.IssueOrdJson))
							{
								crmConversationStatusResultLanguageViewModel.IssueOrdJson = crmConversationStatusResultLanguageViewModel.IssueOrdJson.Replace("\\\"", "\\\\\\\"");
							}
						}
						if (crmConversationStatusResultEventPolicyLanguageViewModel4 != null)
						{
							crmConversationStatusResultLanguageViewModel.IssueDyFormJson = "[" + JsonConvert.SerializeObject(crmConversationStatusResultEventPolicyLanguageViewModel4) + "]";
							if (!string.IsNullOrWhiteSpace(crmConversationStatusResultLanguageViewModel.IssueDyFormJson))
							{
								crmConversationStatusResultLanguageViewModel.IssueDyFormJson = crmConversationStatusResultLanguageViewModel.IssueDyFormJson.Replace("\\\"", "\\\\\\\"");
							}
						}
						if (crmConversationStatusResultEventPolicyLanguageViewModel5 != null)
						{
							crmConversationStatusResultLanguageViewModel.FOJson = "[" + JsonConvert.SerializeObject(crmConversationStatusResultEventPolicyLanguageViewModel5) + "]";
							if (!string.IsNullOrWhiteSpace(crmConversationStatusResultLanguageViewModel.FOJson))
							{
								crmConversationStatusResultLanguageViewModel.FOJson = crmConversationStatusResultLanguageViewModel.FOJson.Replace("\\\"", "\\\\\\\"");
							}
						}
						if (crmConversationStatusResultEventPolicyLanguageViewModel6 != null)
						{
							crmConversationStatusResultLanguageViewModel.ShpJson = "[" + JsonConvert.SerializeObject(crmConversationStatusResultEventPolicyLanguageViewModel6) + "]";
							if (!string.IsNullOrWhiteSpace(crmConversationStatusResultLanguageViewModel.ShpJson))
							{
								crmConversationStatusResultLanguageViewModel.ShpJson = crmConversationStatusResultLanguageViewModel.ShpJson.Replace("\\\"", "\\\\\\\"");
							}
						}
						if (crmConversationStatusResultEventPolicyLanguageViewModel7 != null)
						{
							crmConversationStatusResultLanguageViewModel.AddPrjJson = "[" + JsonConvert.SerializeObject(crmConversationStatusResultEventPolicyLanguageViewModel7) + "]";
							if (!string.IsNullOrWhiteSpace(crmConversationStatusResultLanguageViewModel.AddPrjJson))
							{
								crmConversationStatusResultLanguageViewModel.AddPrjJson = crmConversationStatusResultLanguageViewModel.AddPrjJson.Replace("\\\"", "\\\\\\\"");
							}
						}
					}
				}
				else
				{
					crmConversationStatusResultLanguageViewModel = new CrmConversationStatusResultLanguageViewModel
					{
						ConversationStatusGroupId = cnvsStatusGroupId,
						ConversationStatusId = cnvsStatusId,
						FirstRegisterUserId = UserLogin.CurrentUser.UserId,
						FirstRegisterDate = now,
						UserId = UserLogin.CurrentUser.UserId,
						RegisterDate = now,
						AppType = Configuration.AppType
					};
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		string firstRegInfo = "";
		string regInfo = "";
		if (crmConversationStatusResultLanguageViewModel != null)
		{
			SetCnvsStatusResultRegisterInfo(crmConversationStatusResultLanguageViewModel, ref firstRegInfo, ref regInfo);
			crmConversationStatusResultLanguageViewModel.FirstRegisterUser = firstRegInfo;
			crmConversationStatusResultLanguageViewModel.EditUser = regInfo;
		}
		return View(crmConversationStatusResultLanguageViewModel);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefineBaseInfoIDataEntry", ActionName = "actPost")]
	public ActionResult InsertEdit_I(CrmConversationStatusResultLanguageViewModel model)
	{
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		if (base.ModelState.IsValid)
		{
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.ResultTitle_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ResultTitle_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = model.ResultTitle,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.ResultDesc_Lang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ResultDesc_Lang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = model.ResultDesc,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.CnvsDesc_Lang))
			{
				list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.CnvsDesc_Lang);
			}
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = model.CnvsDesc,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.CnvsReferDesc_Lang))
			{
				list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.CnvsReferDesc_Lang);
			}
			list4.Add(new CommonMultiLanguageViewModel
			{
				Value = model.CnvsReferDesc,
				LanguageId = lCID
			});
			if (string.IsNullOrWhiteSpace(model.ResultTitle))
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.cnvsStatusResultTitle) + "<br/>";
				num++;
			}
			else if (!checkMultiLanguage(model.ResultTitle, list))
			{
				text = text + string.Format(Messages.CheckFieldInLang, Labels.cnvsStatusResultTitle) + "<br>";
				num++;
			}
			if (model.IsDefault.HasValue && model.IsDefault.GetValueOrDefault())
			{
				CRMspSelectConversationStatusResultIsDefault_Result cRMspSelectConversationStatusResultIsDefault_Result = Enumerable.FirstOrDefault<CRMspSelectConversationStatusResultIsDefault_Result>((IEnumerable<CRMspSelectConversationStatusResultIsDefault_Result>)_dbI.CRMspSelectConversationStatusResultIsDefault(model.ConversationStatusId, lCID, defLangID));
				if (cRMspSelectConversationStatusResultIsDefault_Result != null && cRMspSelectConversationStatusResultIsDefault_Result.ConversationStatusResultId != model.ConversationStatusResultId)
				{
					text = text + string.Format(Messages.msgErrorNotSaveCnvsStatusResultDefault, Labels.cnvsStatusResultDefault, cRMspSelectConversationStatusResultIsDefault_Result.ResultTitle ?? "") + "<br>";
					num++;
				}
			}
			if (model.DeActive.HasValue && model.DeActive == false)
			{
				int num2 = 10;
				List<CRMspSelectActiveConversationStatusResult_Result> list5 = Enumerable.ToList<CRMspSelectActiveConversationStatusResult_Result>((IEnumerable<CRMspSelectActiveConversationStatusResult_Result>)_dbI.CRMspSelectActiveConversationStatusResult(model.ConversationStatusId, lCID, defLangID));
				if (list5 != null && Enumerable.Any<CRMspSelectActiveConversationStatusResult_Result>((IEnumerable<CRMspSelectActiveConversationStatusResult_Result>)list5) && Enumerable.Count<CRMspSelectActiveConversationStatusResult_Result>((IEnumerable<CRMspSelectActiveConversationStatusResult_Result>)list5) >= num2)
				{
					if (model.ConversationStatusResultId == 0)
					{
						text = text + string.Format(Messages.msgErrorNotSaveMoreCnvsStatusResult, num2.ToString()) + "<br>";
						num++;
					}
					else if (Enumerable.FirstOrDefault<CRMspSelectActiveConversationStatusResult_Result>((IEnumerable<CRMspSelectActiveConversationStatusResult_Result>)list5, (Func<CRMspSelectActiveConversationStatusResult_Result, bool>)((CRMspSelectActiveConversationStatusResult_Result m) => m.ConversationStatusResultId == model.ConversationStatusResultId)) == null)
					{
						text = text + string.Format(Messages.msgErrorNotSaveMoreCnvsStatusResult, num2.ToString()) + "<br>";
						num++;
					}
				}
			}
			if (num == 0)
			{
				try
				{
					DateTime now = DateTime.Now;
					DateTime dateTime = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					short value2 = short.Parse(Financial.Get().Id.ToString());
					int userId = UserLogin.CurrentUser.UserId;
					string cnvsStatusResultEventPolicy = "";
					List<CrmConversationStatusResultEventPolicyLanguageViewModel> list6 = new List<CrmConversationStatusResultEventPolicyLanguageViewModel>();
					if (!string.IsNullOrWhiteSpace(model.EventPolicyJson))
					{
						List<CrmConversationStatusResultEventPolicyLanguageViewModel> list7 = ConvertEventPolicyJsonToViewMode(model.EventPolicyJson);
						if (list7 != null)
						{
							list6.AddRange(list7);
						}
					}
					if (!string.IsNullOrWhiteSpace(model.OTPJson))
					{
						List<CrmConversationStatusResultEventPolicyLanguageViewModel> list8 = ConvertEventPolicyJsonToViewMode(model.OTPJson);
						if (list8 != null)
						{
							list6.AddRange(list8);
						}
					}
					if (!string.IsNullOrWhiteSpace(model.IssuePordJson))
					{
						List<CrmConversationStatusResultEventPolicyLanguageViewModel> list9 = ConvertEventPolicyJsonToViewMode(model.IssuePordJson);
						if (list9 != null)
						{
							list6.AddRange(list9);
						}
					}
					if (!string.IsNullOrWhiteSpace(model.IssueOrdJson))
					{
						List<CrmConversationStatusResultEventPolicyLanguageViewModel> list10 = ConvertEventPolicyJsonToViewMode(model.IssueOrdJson);
						if (list10 != null)
						{
							list6.AddRange(list10);
						}
					}
					if (!string.IsNullOrWhiteSpace(model.IssueDyFormJson))
					{
						List<CrmConversationStatusResultEventPolicyLanguageViewModel> list11 = ConvertEventPolicyJsonToViewMode(model.IssueDyFormJson);
						if (list11 != null)
						{
							list6.AddRange(list11);
						}
					}
					if (!string.IsNullOrWhiteSpace(model.FOJson))
					{
						List<CrmConversationStatusResultEventPolicyLanguageViewModel> list12 = ConvertEventPolicyJsonToViewMode(model.FOJson);
						if (list12 != null)
						{
							list6.AddRange(list12);
						}
					}
					if (!string.IsNullOrWhiteSpace(model.ShpJson))
					{
						List<CrmConversationStatusResultEventPolicyLanguageViewModel> list13 = ConvertEventPolicyJsonToViewMode(model.ShpJson);
						if (list13 != null)
						{
							list6.AddRange(list13);
						}
					}
					if (!string.IsNullOrWhiteSpace(model.AddPrjJson))
					{
						List<CrmConversationStatusResultEventPolicyLanguageViewModel> list14 = ConvertEventPolicyJsonToViewMode(model.AddPrjJson);
						if (list14 != null)
						{
							list6.AddRange(list14);
						}
					}
					if (list6 != null && Enumerable.Any<CrmConversationStatusResultEventPolicyLanguageViewModel>((IEnumerable<CrmConversationStatusResultEventPolicyLanguageViewModel>)list6))
					{
						cnvsStatusResultEventPolicy = JsonConvert.SerializeObject(Enumerable.ToList<CrmConversationStatusResultEventPolicyLanguageViewModel>((IEnumerable<CrmConversationStatusResultEventPolicyLanguageViewModel>)list6));
					}
					string resultTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					string resultDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					string cnvsDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					string cnvsReferDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					List<CrmConversationStatusResult_LangViewModel> list15 = new List<CrmConversationStatusResult_LangViewModel>();
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
					{
						CrmConversationStatusResult_LangViewModel crmConversationStatusResult_LangViewModel = new CrmConversationStatusResult_LangViewModel();
						crmConversationStatusResult_LangViewModel.LanguageID = lang.LanguageID;
						crmConversationStatusResult_LangViewModel.ResultTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmConversationStatusResult_LangViewModel.ResultDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmConversationStatusResult_LangViewModel.CnvsDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmConversationStatusResult_LangViewModel.CnvsReferDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						list15.Add(crmConversationStatusResult_LangViewModel);
					}
					string cnvsStatusResultLang = "";
					if (list15 != null && Enumerable.Any<CrmConversationStatusResult_LangViewModel>((IEnumerable<CrmConversationStatusResult_LangViewModel>)list15))
					{
						cnvsStatusResultLang = JsonConvert.SerializeObject(Enumerable.ToList<CrmConversationStatusResult_LangViewModel>((IEnumerable<CrmConversationStatusResult_LangViewModel>)list15));
					}
					CrmConversationStatusResultUpdateCmpGroupActiveViewModel crmConversationStatusResultUpdateCmpGroupActiveViewModel = new CrmConversationStatusResultUpdateCmpGroupActiveViewModel();
					bool value3 = false;
					if (model.CmpGroupId.GetValueOrDefault() != 0)
					{
						value3 = true;
						crmConversationStatusResultUpdateCmpGroupActiveViewModel.cmpGroupId = model.CmpGroupId;
					}
					if (model.CmpSubGroupId.GetValueOrDefault() != 0)
					{
						value3 = true;
						crmConversationStatusResultUpdateCmpGroupActiveViewModel.cmpSubGroupId = model.CmpSubGroupId;
					}
					if (model.CmpGroupIIId.GetValueOrDefault() != 0)
					{
						value3 = true;
						crmConversationStatusResultUpdateCmpGroupActiveViewModel.cmpGroupIIId = model.CmpGroupIIId;
					}
					if (model.CmpGroupIIIId.GetValueOrDefault() != 0)
					{
						value3 = true;
						crmConversationStatusResultUpdateCmpGroupActiveViewModel.cmpGroupIIIId = model.CmpGroupIIIId;
					}
					if (model.CmpGroupIVId.GetValueOrDefault() != 0)
					{
						value3 = true;
						crmConversationStatusResultUpdateCmpGroupActiveViewModel.cmpGroupIVId = model.CmpGroupIVId;
					}
					if (model.CmpTypeId.GetValueOrDefault() != 0)
					{
						value3 = true;
						crmConversationStatusResultUpdateCmpGroupActiveViewModel.cmpTypeId = model.CmpTypeId;
					}
					model.UpdateCmpGroupActiveJson = "[" + JsonConvert.SerializeObject(crmConversationStatusResultUpdateCmpGroupActiveViewModel) + "]";
					model.UpdateCmpGroupActive = value3;
					if (!model.OrderView.HasValue)
					{
						List<CRMspSelectConversationStatusResult_Result> list16 = Enumerable.ToList<CRMspSelectConversationStatusResult_Result>((IEnumerable<CRMspSelectConversationStatusResult_Result>)_dbI.CRMspSelectConversationStatusResult(model.ConversationStatusId, lCID, defLangID));
						if (!Enumerable.Any<CRMspSelectConversationStatusResult_Result>((IEnumerable<CRMspSelectConversationStatusResult_Result>)list16))
						{
							model.OrderView = 10;
						}
						else
						{
							int num3 = (Enumerable.Any<CRMspSelectConversationStatusResult_Result>((IEnumerable<CRMspSelectConversationStatusResult_Result>)list16) ? Enumerable.Count<CRMspSelectConversationStatusResult_Result>((IEnumerable<CRMspSelectConversationStatusResult_Result>)list16) : 0);
							model.OrderView = num3 * 10 + 10;
							if (Enumerable.LastOrDefault<CRMspSelectConversationStatusResult_Result>((IEnumerable<CRMspSelectConversationStatusResult_Result>)list16) != null)
							{
								int valueOrDefault = Enumerable.LastOrDefault<CRMspSelectConversationStatusResult_Result>((IEnumerable<CRMspSelectConversationStatusResult_Result>)list16).OrderView.GetValueOrDefault();
								if (valueOrDefault > 0)
								{
									model.OrderView = valueOrDefault + 10;
								}
							}
						}
					}
					ObjectParameter objectParameter = new ObjectParameter("InsertedId", 0);
					mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.CRMspInsertUpdateConversationStatusResult(model.ConversationStatusResultId, model.ConversationStatusGroupId, model.ConversationStatusId, resultTitle, resultDesc, model.EventPolicyActive, model.OTPSendActive, model.IssuePordActive, model.IssueOrdActive, model.IssueDyFormActive, model.NeedDyFormChecked, model.NeedDyFormCheckedFormId, model.PrjFinished, model.NoCnvsDup, model.StatusResultUsedUserIds, model.DoingTimeEndDeadlineMin, model.DoingTimeEndCnvsStatusId, model.DoingTimeEndCnvsStatusResultId, model.CnvsCountLimit, model.CnvsDoingTimeLimit, model.CnvsDoingTimeNotNull, model.CnvsRemindDateNotNull, model.CnvsRemindDateForAllarmNotNull, model.CnvsTopicId, model.CnvsReferUserId, model.CnvsReferUserNoChange, model.CnvsRemindDay, cnvsDesc, cnvsReferDesc, model.UpdateCmpGroupActive, model.UpdateCmpGroupActiveJson, model.IsDefault, model.DeActive, model.OrderView, cnvsStatusResultLang, cnvsStatusResultEventPolicy, userId, value2, value, dateTime, registerDatePersian, appType, lCID, defLangID, objectParameter, model.AddPrjActive, model.CnvsNoNeedRemindDateAlert));
					int result = 0;
					if (mct_I_Result != null)
					{
						int.TryParse(mct_I_Result.Result.ToString(), out result);
					}
					int result2 = 0;
					if (objectParameter != null && objectParameter.Value != null)
					{
						int.TryParse(objectParameter.Value.ToString(), out result2);
					}
					string text2 = Messages.frmFormBaseInsertSuccessFulMessage;
					if (model.ConversationStatusResultId > 0)
					{
						text2 = Messages.frmFormBaseEditSuccessFulMessage;
					}
					else
					{
						model.ConversationStatusResultId = result2;
					}
					if (result == 1 && model.ConversationStatusResultId > 0)
					{
						base.ViewBag.Successfull = text2;
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmConversationStatusResult");
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmConversationStatusResultEventPolicy");
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmConversationStatus");
						model.UserId = userId;
						model.RegisterDate = dateTime;
					}
					else
					{
						text = Messages.msgErrorRunFunction;
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					text = Messages.msgErrorRunFunction;
				}
			}
		}
		if (!string.IsNullOrWhiteSpace(text))
		{
			base.ViewBag.Error = text;
		}
		string firstRegInfo = "";
		string regInfo = "";
		if (model != null)
		{
			SetCnvsStatusResultRegisterInfo(model, ref firstRegInfo, ref regInfo);
			model.FirstRegisterUser = firstRegInfo;
			model.EditUser = regInfo;
		}
		return View(model);
	}

	public void GetLangList()
	{
		string text = "";
		try
		{
			List<Languages> list = Enumerable.ToList<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get());
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (list != null && Enumerable.Any<Languages>((IEnumerable<Languages>)list))
			{
				foreach (Languages item2 in list)
				{
					CommonMultiLanguageViewModel item = new CommonMultiLanguageViewModel
					{
						LanguageId = item2.LanguageID,
						Value = item2.LanguageID.ToString()
					};
					list2.Add(item);
				}
			}
			if (list2 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2))
			{
				text = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.LangList = text;
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
		base.Dispose(disposing);
	}
}

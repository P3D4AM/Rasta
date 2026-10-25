using System;
using System.Collections;
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
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CRMIdeal.Areas.Company.Controllers;

public class QuickRegisterDefSettingController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass42_0
	{
		public CrmCompanyQuickRegisterDefSettingLocationLanguageViewModel model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass44_0
	{
		public CrmCompanyQuickRegisterDefSettingLocationLanguageViewModel model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public int defSettingId;

		public int currLangID;

		internal bool _003CInsertEdit_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
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
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__24(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__25(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__26(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__27(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__28(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__29(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__30(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__31(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__32(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__33(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__34(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__35(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__36(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__37(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__38(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__39(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__40(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__41(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__42(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__43(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__44(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__45(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__46(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__47(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__48(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__49(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__50(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__51(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__52(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__53(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__54(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__55(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__56(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__57(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public CrmCompanyQuickRegisterDefSettingLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__40;

		public Func<Languages, bool> _003C_003E9__98;

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

		internal bool _003CInsertEdit_003Eb__40(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__98(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals1;

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

		internal bool _003CInsertEdit_003Eb__83(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__84(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__85(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__86(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__87(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__88(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__89(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__90(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__91(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__92(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__93(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__94(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__95(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__96(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__97(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	private CRMSpEntities _db = new CRMSpEntities();

	private CRMSpIEntities _dbI = new CRMSpIEntities();

	private CRMSpIIIEntities _dbIII = new CRMSpIIIEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actCompanyQuickRegisterDefSetting")]
	public ActionResult Index()
	{
		return View();
	}

	[AjaxOnly]
	public ActionResult QuickRegisterDefSetting_Read([DataSourceRequest] DataSourceRequest request)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectCompanyQuickRegisterDefSetting_Result> enumerable = new List<CRMspSelectCompanyQuickRegisterDefSetting_Result>();
		try
		{
			enumerable = Enumerable.ToList<CRMspSelectCompanyQuickRegisterDefSetting_Result>((IEnumerable<CRMspSelectCompanyQuickRegisterDefSetting_Result>)_dbI.CRMspSelectCompanyQuickRegisterDefSetting(lCID, result));
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
	[DynamicAuthorize(ControllerName = "frmCompanyQuickRegisterDefSetting", ActionName = "actDelete")]
	public string ActDelete(int defSettingId)
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
			if (!UserLogin.IsUserAccess("frmCompanyQuickRegisterDefSetting", "actDelete", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			if (defSettingId > 0)
			{
				try
				{
					mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.CRMspDeleteCompanyQuickRegisterDefSetting(defSettingId));
					if (mct_I_Result != null && mct_I_Result.Result > 0)
					{
						result = "";
					}
					else if (mct_I_Result != null && mct_I_Result.Result == 0)
					{
						result = Messages.RedundancyMessage;
					}
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCompanyQuickRegisterDefSetting");
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

	[DynamicAuthorize(ControllerName = "frmCompanyQuickRegisterDefSetting", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(int defSettingId)
	{
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass7_0();
		CS_0024_003C_003E8__locals0.defSettingId = defSettingId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		CrmCompanyQuickRegisterDefSettingLanguageViewModel crmCompanyQuickRegisterDefSettingLanguageViewModel = new CrmCompanyQuickRegisterDefSettingLanguageViewModel();
		DateTime now = DateTime.Now;
		FullAllCombo();
		try
		{
			if (CS_0024_003C_003E8__locals0.defSettingId == 0)
			{
				crmCompanyQuickRegisterDefSettingLanguageViewModel = new CrmCompanyQuickRegisterDefSettingLanguageViewModel
				{
					FirstRegisterDate = now,
					RegisterDate = now,
					CompanyQuickRegisterDefSettingId = 0
				};
			}
			else
			{
				DbSet<CrmCompanyQuickRegisterDefSetting_Lang> crmCompanyQuickRegisterDefSetting_Lang = _dbTbl.CrmCompanyQuickRegisterDefSetting_Lang;
				ParameterExpression val = Expression.Parameter(typeof(CrmCompanyQuickRegisterDefSetting_Lang), "c");
				List<CrmCompanyQuickRegisterDefSetting_Lang> list = Enumerable.ToList<CrmCompanyQuickRegisterDefSetting_Lang>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)Queryable.Where<CrmCompanyQuickRegisterDefSetting_Lang>((IQueryable<CrmCompanyQuickRegisterDefSetting_Lang>)crmCompanyQuickRegisterDefSetting_Lang, Expression.Lambda<Func<CrmCompanyQuickRegisterDefSetting_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass7_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				DbSet<CrmCompanyQuickRegisterDefSetting> crmCompanyQuickRegisterDefSetting = _dbTbl.CrmCompanyQuickRegisterDefSetting;
				val = Expression.Parameter(typeof(CrmCompanyQuickRegisterDefSetting), "c");
				CrmCompanyQuickRegisterDefSetting crmCompanyQuickRegisterDefSetting2 = Queryable.FirstOrDefault<CrmCompanyQuickRegisterDefSetting>((IQueryable<CrmCompanyQuickRegisterDefSetting>)crmCompanyQuickRegisterDefSetting, Expression.Lambda<Func<CrmCompanyQuickRegisterDefSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass7_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) ?? new CrmCompanyQuickRegisterDefSetting();
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.SettingTitle,
					LanguageId = item.LanguageID
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyQuickRegisterDefSetting2.SettingTitle,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.cmpActivityType,
					LanguageId = item.LanguageID
				})));
				list3.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyQuickRegisterDefSetting2.cmpActivityType,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.cmpSpecialPoint,
					LanguageId = item.LanguageID
				})));
				list4.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyQuickRegisterDefSetting2.cmpSpecialPoint,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list5 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.cmpDescription,
					LanguageId = item.LanguageID
				})));
				list5.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyQuickRegisterDefSetting2.cmpDescription,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list6 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.prsSpecialPoint,
					LanguageId = item.LanguageID
				})));
				list6.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyQuickRegisterDefSetting2.prsSpecialPoint,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list7 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.prsDescription,
					LanguageId = item.LanguageID
				})));
				list7.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyQuickRegisterDefSetting2.prsDescription,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list8 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.prjTitle,
					LanguageId = item.LanguageID
				})));
				list8.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyQuickRegisterDefSetting2.prjTitle,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list9 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.prjDesc,
					LanguageId = item.LanguageID
				})));
				list9.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyQuickRegisterDefSetting2.prjDesc,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list10 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.prjPostFix,
					LanguageId = item.LanguageID
				})));
				list10.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyQuickRegisterDefSetting2.prjPostFix,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list11 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.prjSubject,
					LanguageId = item.LanguageID
				})));
				list11.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyQuickRegisterDefSetting2.prjSubject,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list12 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.prjTitleGroup,
					LanguageId = item.LanguageID
				})));
				list12.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyQuickRegisterDefSetting2.prjTitleGroup,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list13 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.prjDescI,
					LanguageId = item.LanguageID
				})));
				list13.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyQuickRegisterDefSetting2.prjDescI,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list14 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.cnvsDesc,
					LanguageId = item.LanguageID
				})));
				list14.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyQuickRegisterDefSetting2.cnvsDesc,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list15 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.cnvsReferDesc,
					LanguageId = item.LanguageID
				})));
				list15.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyQuickRegisterDefSetting2.cnvsReferDesc,
					LanguageId = result
				});
				crmCompanyQuickRegisterDefSettingLanguageViewModel = new CrmCompanyQuickRegisterDefSettingLanguageViewModel
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
					prjFOCmpCanSee = crmCompanyQuickRegisterDefSetting2.prjFOCmpCanSee,
					prjCategoryId = crmCompanyQuickRegisterDefSetting2.prjCategoryId,
					cnvsTopicId = crmCompanyQuickRegisterDefSetting2.cnvsTopicId,
					cnvsStatusId = crmCompanyQuickRegisterDefSetting2.cnvsStatusId,
					cnvsPriorityId = crmCompanyQuickRegisterDefSetting2.cnvsPriorityId,
					cnvsRemindDateIncDay = crmCompanyQuickRegisterDefSetting2.cnvsRemindDateIncDay,
					cnvsRemindTime = crmCompanyQuickRegisterDefSetting2.cnvsRemindTime,
					cnvsRemindDateForAllarmIncDay = crmCompanyQuickRegisterDefSetting2.cnvsRemindDateForAllarmIncDay,
					cnvsFOCmpCanSee = crmCompanyQuickRegisterDefSetting2.cnvsFOCmpCanSee,
					OrderView = crmCompanyQuickRegisterDefSetting2.OrderView,
					IsDefault = crmCompanyQuickRegisterDefSetting2.IsDefault,
					IsDefaultForCmpInfo = crmCompanyQuickRegisterDefSetting2.IsDefaultForCmpInfo,
					FirstRegisterUserId = crmCompanyQuickRegisterDefSetting2.FirstRegisterUserId,
					FirstRegisterDate = crmCompanyQuickRegisterDefSetting2.FirstRegisterDate,
					FirstRegisterDatePersian = crmCompanyQuickRegisterDefSetting2.FirstRegisterDatePersian,
					UserId = crmCompanyQuickRegisterDefSetting2.UserId,
					RegisterDate = crmCompanyQuickRegisterDefSetting2.RegisterDate,
					RegisterDatePersian = crmCompanyQuickRegisterDefSetting2.RegisterDatePersian,
					AppType = crmCompanyQuickRegisterDefSetting2.AppType,
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
					cnvsReferDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list15, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list15, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					IsDefIssueQuickOrder = crmCompanyQuickRegisterDefSetting2.IsDefIssueQuickOrder,
					prjpordDefaultSettingId = crmCompanyQuickRegisterDefSetting2.prjpordDefaultSettingId,
					prjordDefaultSettingId = crmCompanyQuickRegisterDefSetting2.prjordDefaultSettingId,
					cmpLocationLat = crmCompanyQuickRegisterDefSetting2.cmpLocationLat,
					cmpLocationLong = crmCompanyQuickRegisterDefSetting2.cmpLocationLong,
					cmpLocationZoom = crmCompanyQuickRegisterDefSetting2.cmpLocationZoom,
					prsLocationLat = crmCompanyQuickRegisterDefSetting2.prsLocationLat,
					prsLocationLong = crmCompanyQuickRegisterDefSetting2.prsLocationLong,
					prsLocationZoom = crmCompanyQuickRegisterDefSetting2.prsLocationZoom,
					AccessUserJson = crmCompanyQuickRegisterDefSetting2.AccessUserJson,
					ActiveInQuickOrder = crmCompanyQuickRegisterDefSetting2.ActiveInQuickOrder,
					InActive = crmCompanyQuickRegisterDefSetting2.InActive,
					PublicMode = crmCompanyQuickRegisterDefSetting2.PublicMode
				};
				JArray jArray = new JArray();
				if (!string.IsNullOrEmpty(crmCompanyQuickRegisterDefSettingLanguageViewModel.AccessUserJson) && ((int?)crmCompanyQuickRegisterDefSettingLanguageViewModel.PublicMode).GetValueOrDefault() == 3)
				{
					List<int> userIds = new List<int>();
					new List<object>();
					try
					{
						jArray = JArray.Parse(crmCompanyQuickRegisterDefSettingLanguageViewModel.AccessUserJson);
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
					List<object> list16 = new List<object>();
					foreach (CRMspSelectUsers_Result user in enumerable)
					{
						JToken jToken = Enumerable.FirstOrDefault<JToken>((IEnumerable<JToken>)jArray, (Func<JToken, bool>)((JToken j) => (j.Value<int?>("UserId") ?? j.Value<int?>("id")) == user.UserId));
						bool? flag = jToken?.Value<bool?>("IsDefaultForCmpInfo");
						bool? flag2 = jToken?.Value<bool?>("IsDefIssueQuickOrder");
						bool? flag3 = jToken?.Value<bool?>("IsDefault");
						list16.Add(new
						{
							text = user.LName + " " + user.FName,
							id = user.UserId,
							IsDefaultForCmpInfo = flag.GetValueOrDefault(),
							IsDefIssueQuickOrder = flag2.GetValueOrDefault(),
							IsDefault = flag3.GetValueOrDefault()
						});
					}
					string accessUserJson = JsonConvert.SerializeObject(list16, new JsonSerializerSettings
					{
						NullValueHandling = NullValueHandling.Ignore,
						Formatting = Formatting.None
					});
					crmCompanyQuickRegisterDefSettingLanguageViewModel.AccessUserJson = accessUserJson;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		SetRegisterInfo(crmCompanyQuickRegisterDefSettingLanguageViewModel);
		return View(crmCompanyQuickRegisterDefSettingLanguageViewModel);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	[DynamicAuthorize(ControllerName = "frmCompanyQuickRegisterDefSettingDataEntry", ActionName = "actPost")]
	public ActionResult InsertEdit(CrmCompanyQuickRegisterDefSettingLanguageViewModel vm)
	{
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0321: Unknown result type (might be due to invalid IL or missing references)
		//IL_0375: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_041d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0471: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c5: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass8_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		FullAllCombo();
		if (!base.ModelState.IsValid)
		{
			base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
		}
		else
		{
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.SettingTitle_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.SettingTitle_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.SettingTitle,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.cmpActivityType_Lang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.cmpActivityType_Lang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.cmpActivityType,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.cmpSpecialPoint_Lang))
			{
				list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.cmpSpecialPoint_Lang);
			}
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.cmpSpecialPoint,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.cmpDescription_Lang))
			{
				list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.cmpDescription_Lang);
			}
			list4.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.cmpDescription,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.prsSpecialPoint_Lang))
			{
				list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.prsSpecialPoint_Lang);
			}
			list5.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.prsSpecialPoint,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.prsDescription_Lang))
			{
				list6 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.prsDescription_Lang);
			}
			list6.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.prsDescription,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list7 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.prjTitle_Lang))
			{
				list7 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.prjTitle_Lang);
			}
			list7.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.prjTitle,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list8 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.prjDesc_Lang))
			{
				list8 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.prjDesc_Lang);
			}
			list8.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.prjDesc,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list9 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.prjPostFix_Lang))
			{
				list9 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.prjPostFix_Lang);
			}
			list9.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.prjPostFix,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list10 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.prjSubject_Lang))
			{
				list10 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.prjSubject_Lang);
			}
			list10.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.prjSubject,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list11 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.prjTitleGroup_Lang))
			{
				list11 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.prjTitleGroup_Lang);
			}
			list11.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.prjTitleGroup,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list12 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.prjDescI_Lang))
			{
				list12 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.prjDescI_Lang);
			}
			list12.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.prjDescI,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list13 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.cnvsDesc_Lang))
			{
				list13 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.cnvsDesc_Lang);
			}
			list13.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.cnvsDesc,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list14 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.cnvsReferDesc_Lang))
			{
				list14 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.cnvsReferDesc_Lang);
			}
			list14.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.cnvsReferDesc,
				LanguageId = lCID
			});
			string text = "";
			if (string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.vm.SettingTitle))
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.CmpQuickRegisterDefSettingSettingTitle) + "<br/>";
			}
			else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.SettingTitle, list))
			{
				text = text + string.Format(Messages.CheckFieldInLang, Labels.CmpQuickRegisterDefSettingSettingTitle) + "<br>";
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				base.ViewBag.Error = text;
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			try
			{
				CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
				DateTime now = DateTime.Now;
				CrmCompanyQuickRegisterDefSetting crmCompanyQuickRegisterDefSetting = new CrmCompanyQuickRegisterDefSetting();
				if (CS_0024_003C_003E8__locals0.vm.CompanyQuickRegisterDefSettingId > 0)
				{
					DbSet<CrmCompanyQuickRegisterDefSetting> crmCompanyQuickRegisterDefSetting2 = _dbTbl.CrmCompanyQuickRegisterDefSetting;
					ParameterExpression val = Expression.Parameter(typeof(CrmCompanyQuickRegisterDefSetting), "c");
					crmCompanyQuickRegisterDefSetting = Queryable.FirstOrDefault<CrmCompanyQuickRegisterDefSetting>((IQueryable<CrmCompanyQuickRegisterDefSetting>)crmCompanyQuickRegisterDefSetting2, Expression.Lambda<Func<CrmCompanyQuickRegisterDefSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				crmCompanyQuickRegisterDefSetting.RegisterDate = now;
				crmCompanyQuickRegisterDefSetting.UserId = currentUser.UserId;
				crmCompanyQuickRegisterDefSetting.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				crmCompanyQuickRegisterDefSetting.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
				crmCompanyQuickRegisterDefSetting.AppType = Configuration.AppType;
				crmCompanyQuickRegisterDefSetting.Year1 = short.Parse(Financial.Get().Id.ToString());
				crmCompanyQuickRegisterDefSetting.cmpTitleId = CS_0024_003C_003E8__locals0.vm.cmpTitleId;
				crmCompanyQuickRegisterDefSetting.cmpGroupId = CS_0024_003C_003E8__locals0.vm.cmpGroupId;
				crmCompanyQuickRegisterDefSetting.cmpSubGroupId = CS_0024_003C_003E8__locals0.vm.cmpSubGroupId;
				crmCompanyQuickRegisterDefSetting.cmpGroupIdII = CS_0024_003C_003E8__locals0.vm.cmpGroupIdII;
				crmCompanyQuickRegisterDefSetting.cmpGroupIdIII = CS_0024_003C_003E8__locals0.vm.cmpGroupIdIII;
				crmCompanyQuickRegisterDefSetting.cmpGroupIdIV = CS_0024_003C_003E8__locals0.vm.cmpGroupIdIV;
				crmCompanyQuickRegisterDefSetting.cmpTypeId = CS_0024_003C_003E8__locals0.vm.cmpTypeId;
				crmCompanyQuickRegisterDefSetting.cmpPresentationId = CS_0024_003C_003E8__locals0.vm.cmpPresentationId;
				crmCompanyQuickRegisterDefSetting.cmpCityId = CS_0024_003C_003E8__locals0.vm.cmpCityId;
				crmCompanyQuickRegisterDefSetting.cmpEffectiveDateIncDay = CS_0024_003C_003E8__locals0.vm.cmpEffectiveDateIncDay;
				crmCompanyQuickRegisterDefSetting.cmpKind = CS_0024_003C_003E8__locals0.vm.cmpKind;
				crmCompanyQuickRegisterDefSetting.prsTitleId = CS_0024_003C_003E8__locals0.vm.prsTitleId;
				crmCompanyQuickRegisterDefSetting.prsJobId = CS_0024_003C_003E8__locals0.vm.prsJobId;
				crmCompanyQuickRegisterDefSetting.prsTypeId = CS_0024_003C_003E8__locals0.vm.prsTypeId;
				crmCompanyQuickRegisterDefSetting.prsGroupId = CS_0024_003C_003E8__locals0.vm.prsGroupId;
				crmCompanyQuickRegisterDefSetting.prsSexId = CS_0024_003C_003E8__locals0.vm.prsSexId;
				crmCompanyQuickRegisterDefSetting.prsEducationId = CS_0024_003C_003E8__locals0.vm.prsEducationId;
				crmCompanyQuickRegisterDefSetting.prsCityId = CS_0024_003C_003E8__locals0.vm.prsCityId;
				crmCompanyQuickRegisterDefSetting.prsDepartmentId = CS_0024_003C_003E8__locals0.vm.prsDepartmentId;
				crmCompanyQuickRegisterDefSetting.prjGradeId = CS_0024_003C_003E8__locals0.vm.prjGradeId;
				crmCompanyQuickRegisterDefSetting.prjPriorityId = CS_0024_003C_003E8__locals0.vm.prjPriorityId;
				crmCompanyQuickRegisterDefSetting.prjGroupId = CS_0024_003C_003E8__locals0.vm.prjGroupId;
				crmCompanyQuickRegisterDefSetting.prjcnvsStatusGroupId = CS_0024_003C_003E8__locals0.vm.prjcnvsStatusGroupId;
				crmCompanyQuickRegisterDefSetting.prjRemindDateIncDay = CS_0024_003C_003E8__locals0.vm.prjRemindDateIncDay;
				crmCompanyQuickRegisterDefSetting.prjFOCmpCanSee = CS_0024_003C_003E8__locals0.vm.prjFOCmpCanSee;
				crmCompanyQuickRegisterDefSetting.prjCategoryId = CS_0024_003C_003E8__locals0.vm.prjCategoryId;
				crmCompanyQuickRegisterDefSetting.cnvsTopicId = CS_0024_003C_003E8__locals0.vm.cnvsTopicId;
				crmCompanyQuickRegisterDefSetting.cnvsStatusId = CS_0024_003C_003E8__locals0.vm.cnvsStatusId;
				crmCompanyQuickRegisterDefSetting.cnvsPriorityId = CS_0024_003C_003E8__locals0.vm.cnvsPriorityId;
				crmCompanyQuickRegisterDefSetting.cnvsRemindDateIncDay = CS_0024_003C_003E8__locals0.vm.cnvsRemindDateIncDay;
				crmCompanyQuickRegisterDefSetting.cnvsRemindTime = CS_0024_003C_003E8__locals0.vm.cnvsRemindTime;
				crmCompanyQuickRegisterDefSetting.cnvsRemindDateForAllarmIncDay = CS_0024_003C_003E8__locals0.vm.cnvsRemindDateForAllarmIncDay;
				crmCompanyQuickRegisterDefSetting.cnvsFOCmpCanSee = CS_0024_003C_003E8__locals0.vm.cnvsFOCmpCanSee;
				crmCompanyQuickRegisterDefSetting.OrderView = CS_0024_003C_003E8__locals0.vm.OrderView;
				crmCompanyQuickRegisterDefSetting.prjpordDefaultSettingId = CS_0024_003C_003E8__locals0.vm.prjpordDefaultSettingId;
				crmCompanyQuickRegisterDefSetting.prjordDefaultSettingId = CS_0024_003C_003E8__locals0.vm.prjordDefaultSettingId;
				crmCompanyQuickRegisterDefSetting.SettingTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				crmCompanyQuickRegisterDefSetting.cmpActivityType = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				crmCompanyQuickRegisterDefSetting.cmpSpecialPoint = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				crmCompanyQuickRegisterDefSetting.cmpDescription = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				crmCompanyQuickRegisterDefSetting.prsSpecialPoint = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				crmCompanyQuickRegisterDefSetting.prsDescription = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				crmCompanyQuickRegisterDefSetting.prjTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				crmCompanyQuickRegisterDefSetting.prjDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				crmCompanyQuickRegisterDefSetting.prjPostFix = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				crmCompanyQuickRegisterDefSetting.prjSubject = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				crmCompanyQuickRegisterDefSetting.prjTitleGroup = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				crmCompanyQuickRegisterDefSetting.prjDescI = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				crmCompanyQuickRegisterDefSetting.cnvsDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				crmCompanyQuickRegisterDefSetting.cnvsReferDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				crmCompanyQuickRegisterDefSetting.cmpLocationLat = CS_0024_003C_003E8__locals0.vm.cmpLocationLat;
				crmCompanyQuickRegisterDefSetting.cmpLocationLong = CS_0024_003C_003E8__locals0.vm.cmpLocationLong;
				crmCompanyQuickRegisterDefSetting.cmpLocationZoom = CS_0024_003C_003E8__locals0.vm.cmpLocationZoom;
				crmCompanyQuickRegisterDefSetting.prsLocationLat = CS_0024_003C_003E8__locals0.vm.prsLocationLat;
				crmCompanyQuickRegisterDefSetting.prsLocationLong = CS_0024_003C_003E8__locals0.vm.prsLocationLong;
				crmCompanyQuickRegisterDefSetting.prsLocationZoom = CS_0024_003C_003E8__locals0.vm.prsLocationZoom;
				crmCompanyQuickRegisterDefSetting.PublicMode = CS_0024_003C_003E8__locals0.vm.PublicMode;
				crmCompanyQuickRegisterDefSetting.ActiveInQuickOrder = CS_0024_003C_003E8__locals0.vm.ActiveInQuickOrder;
				crmCompanyQuickRegisterDefSetting.InActive = CS_0024_003C_003E8__locals0.vm.InActive;
				List<int> list15 = new List<int>();
				List<int> list16 = new List<int>();
				List<int> list17 = new List<int>();
				if (((int?)CS_0024_003C_003E8__locals0.vm.PublicMode).GetValueOrDefault() == 3 && !string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.AccessUserJson))
				{
					try
					{
						foreach (JToken item in JArray.Parse(CS_0024_003C_003E8__locals0.vm.AccessUserJson))
						{
							int result = 0;
							int.TryParse(item["UserId"]?.ToString() ?? item["id"]?.ToString(), out result);
							if (result <= 0)
							{
								continue;
							}
							bool result2 = false;
							bool.TryParse(item["IsDefaultForCmpInfo"]?.ToString(), out result2);
							if (result2)
							{
								list15.Add(result);
							}
							if (CS_0024_003C_003E8__locals0.vm.ActiveInQuickOrder.GetValueOrDefault())
							{
								bool result3 = false;
								bool.TryParse(item["IsDefIssueQuickOrder"]?.ToString(), out result3);
								if (result3)
								{
									list16.Add(result);
								}
							}
							bool result4 = false;
							bool.TryParse(item["IsDefault"]?.ToString(), out result4);
							if (result4)
							{
								list17.Add(result);
							}
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
					}
				}
				List<CRMspCheckDefaultCompanySettingUserConflict_Result> list18 = new List<CRMspCheckDefaultCompanySettingUserConflict_Result>();
				List<CRMspCheckDefaultCompanySettingUserConflict_Result> list19 = new List<CRMspCheckDefaultCompanySettingUserConflict_Result>();
				List<CRMspCheckDefaultCompanySettingUserConflict_Result> list20 = new List<CRMspCheckDefaultCompanySettingUserConflict_Result>();
				if (Enumerable.Any<int>((IEnumerable<int>)list15))
				{
					list18 = Enumerable.ToList<CRMspCheckDefaultCompanySettingUserConflict_Result>((IEnumerable<CRMspCheckDefaultCompanySettingUserConflict_Result>)_dbIII.CRMspCheckDefaultCompanySettingUserConflict(string.Join(",", Enumerable.Distinct<int>((IEnumerable<int>)list15)), CS_0024_003C_003E8__locals0.vm.CompanyQuickRegisterDefSettingId, (short)1, lCID, CS_0024_003C_003E8__locals0.defLangID)) ?? new List<CRMspCheckDefaultCompanySettingUserConflict_Result>();
				}
				if (Enumerable.Any<int>((IEnumerable<int>)list16))
				{
					list19 = Enumerable.ToList<CRMspCheckDefaultCompanySettingUserConflict_Result>((IEnumerable<CRMspCheckDefaultCompanySettingUserConflict_Result>)_dbIII.CRMspCheckDefaultCompanySettingUserConflict(string.Join(",", Enumerable.Distinct<int>((IEnumerable<int>)list16)), CS_0024_003C_003E8__locals0.vm.CompanyQuickRegisterDefSettingId, (short)2, lCID, CS_0024_003C_003E8__locals0.defLangID)) ?? new List<CRMspCheckDefaultCompanySettingUserConflict_Result>();
				}
				if (Enumerable.Any<int>((IEnumerable<int>)list17))
				{
					list20 = Enumerable.ToList<CRMspCheckDefaultCompanySettingUserConflict_Result>((IEnumerable<CRMspCheckDefaultCompanySettingUserConflict_Result>)_dbIII.CRMspCheckDefaultCompanySettingUserConflict(string.Join(",", Enumerable.Distinct<int>((IEnumerable<int>)list17)), CS_0024_003C_003E8__locals0.vm.CompanyQuickRegisterDefSettingId, (short)3, lCID, CS_0024_003C_003E8__locals0.defLangID)) ?? new List<CRMspCheckDefaultCompanySettingUserConflict_Result>();
				}
				bool flag = false;
				bool flag2 = false;
				bool flag3 = false;
				if (((int?)CS_0024_003C_003E8__locals0.vm.PublicMode).GetValueOrDefault() == 2)
				{
					if (CS_0024_003C_003E8__locals0.vm.IsDefaultForCmpInfo.GetValueOrDefault())
					{
						List<CRMspCheckPublicDefaultCompanySettingConflict_Result> list21 = Enumerable.ToList<CRMspCheckPublicDefaultCompanySettingConflict_Result>((IEnumerable<CRMspCheckPublicDefaultCompanySettingConflict_Result>)_dbIII.CRMspCheckPublicDefaultCompanySettingConflict(CS_0024_003C_003E8__locals0.vm.CompanyQuickRegisterDefSettingId, (short)1, lCID, CS_0024_003C_003E8__locals0.defLangID));
						if (list21 != null && Enumerable.Any<CRMspCheckPublicDefaultCompanySettingConflict_Result>((IEnumerable<CRMspCheckPublicDefaultCompanySettingConflict_Result>)list21))
						{
							flag = true;
						}
					}
					if (CS_0024_003C_003E8__locals0.vm.ActiveInQuickOrder.GetValueOrDefault() && CS_0024_003C_003E8__locals0.vm.IsDefIssueQuickOrder.GetValueOrDefault())
					{
						List<CRMspCheckPublicDefaultCompanySettingConflict_Result> list22 = Enumerable.ToList<CRMspCheckPublicDefaultCompanySettingConflict_Result>((IEnumerable<CRMspCheckPublicDefaultCompanySettingConflict_Result>)_dbIII.CRMspCheckPublicDefaultCompanySettingConflict(CS_0024_003C_003E8__locals0.vm.CompanyQuickRegisterDefSettingId, (short)2, lCID, CS_0024_003C_003E8__locals0.defLangID));
						if (list22 != null && Enumerable.Any<CRMspCheckPublicDefaultCompanySettingConflict_Result>((IEnumerable<CRMspCheckPublicDefaultCompanySettingConflict_Result>)list22))
						{
							flag2 = true;
						}
					}
					if (CS_0024_003C_003E8__locals0.vm.IsDefault.GetValueOrDefault())
					{
						List<CRMspCheckPublicDefaultCompanySettingConflict_Result> list23 = Enumerable.ToList<CRMspCheckPublicDefaultCompanySettingConflict_Result>((IEnumerable<CRMspCheckPublicDefaultCompanySettingConflict_Result>)_dbIII.CRMspCheckPublicDefaultCompanySettingConflict(CS_0024_003C_003E8__locals0.vm.CompanyQuickRegisterDefSettingId, (short)3, lCID, CS_0024_003C_003E8__locals0.defLangID));
						if (list23 != null && Enumerable.Any<CRMspCheckPublicDefaultCompanySettingConflict_Result>((IEnumerable<CRMspCheckPublicDefaultCompanySettingConflict_Result>)list23))
						{
							flag3 = true;
						}
					}
				}
				crmCompanyQuickRegisterDefSetting.IsDefaultForCmpInfo = CS_0024_003C_003E8__locals0.vm.IsDefaultForCmpInfo.GetValueOrDefault() && !flag;
				crmCompanyQuickRegisterDefSetting.IsDefIssueQuickOrder = CS_0024_003C_003E8__locals0.vm.IsDefIssueQuickOrder.GetValueOrDefault() && CS_0024_003C_003E8__locals0.vm.ActiveInQuickOrder.GetValueOrDefault() && !flag2;
				crmCompanyQuickRegisterDefSetting.IsDefault = CS_0024_003C_003E8__locals0.vm.IsDefault.GetValueOrDefault() && !flag3;
				if (((int?)CS_0024_003C_003E8__locals0.vm.PublicMode).GetValueOrDefault() == 3 && !string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.AccessUserJson))
				{
					try
					{
						JArray jArray = JArray.Parse(CS_0024_003C_003E8__locals0.vm.AccessUserJson);
						JArray jArray2 = new JArray();
						foreach (JToken item2 in jArray)
						{
							int userId = 0;
							int.TryParse(item2["UserId"]?.ToString() ?? item2["id"]?.ToString(), out userId);
							if (userId <= 0)
							{
								continue;
							}
							JObject jObject = new JObject();
							jObject["UserId"] = userId.ToString();
							bool result5 = false;
							bool.TryParse(item2["IsDefaultForCmpInfo"]?.ToString(), out result5);
							if (!result5)
							{
								jObject["IsDefaultForCmpInfo"] = false;
							}
							else
							{
								bool flag4 = Enumerable.Any<CRMspCheckDefaultCompanySettingUserConflict_Result>((IEnumerable<CRMspCheckDefaultCompanySettingUserConflict_Result>)list18, (Func<CRMspCheckDefaultCompanySettingUserConflict_Result, bool>)((CRMspCheckDefaultCompanySettingUserConflict_Result s) => s.UserId == userId));
								if (flag4 && CS_0024_003C_003E8__locals0.vm.SaveDefSettings == 1)
								{
									jObject["IsDefaultForCmpInfo"] = true;
									List<int?> values = Enumerable.ToList<int?>(Enumerable.Distinct<int?>(Enumerable.Select<CRMspCheckDefaultCompanySettingUserConflict_Result, int?>(Enumerable.Where<CRMspCheckDefaultCompanySettingUserConflict_Result>((IEnumerable<CRMspCheckDefaultCompanySettingUserConflict_Result>)list18, (Func<CRMspCheckDefaultCompanySettingUserConflict_Result, bool>)((CRMspCheckDefaultCompanySettingUserConflict_Result s) => s.UserId == userId)), (Func<CRMspCheckDefaultCompanySettingUserConflict_Result, int?>)((CRMspCheckDefaultCompanySettingUserConflict_Result s) => s.SettingID))));
									Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbIII.CRMspUpdateCompanyDefaultSettingDefFields(userId, string.Join(",", values), (short)1));
								}
								else if (flag4)
								{
									jObject["IsDefaultForCmpInfo"] = false;
								}
								else
								{
									jObject["IsDefaultForCmpInfo"] = true;
								}
							}
							if (CS_0024_003C_003E8__locals0.vm.ActiveInQuickOrder.GetValueOrDefault())
							{
								bool result6 = false;
								bool.TryParse(item2["IsDefIssueQuickOrder"]?.ToString(), out result6);
								if (!result6)
								{
									jObject["IsDefIssueQuickOrder"] = false;
								}
								else
								{
									bool flag5 = Enumerable.Any<CRMspCheckDefaultCompanySettingUserConflict_Result>((IEnumerable<CRMspCheckDefaultCompanySettingUserConflict_Result>)list19, (Func<CRMspCheckDefaultCompanySettingUserConflict_Result, bool>)((CRMspCheckDefaultCompanySettingUserConflict_Result s) => s.UserId == userId));
									if (flag5 && CS_0024_003C_003E8__locals0.vm.SaveDefSettings == 1)
									{
										jObject["IsDefIssueQuickOrder"] = true;
										List<int?> values2 = Enumerable.ToList<int?>(Enumerable.Distinct<int?>(Enumerable.Select<CRMspCheckDefaultCompanySettingUserConflict_Result, int?>(Enumerable.Where<CRMspCheckDefaultCompanySettingUserConflict_Result>((IEnumerable<CRMspCheckDefaultCompanySettingUserConflict_Result>)list19, (Func<CRMspCheckDefaultCompanySettingUserConflict_Result, bool>)((CRMspCheckDefaultCompanySettingUserConflict_Result s) => s.UserId == userId)), (Func<CRMspCheckDefaultCompanySettingUserConflict_Result, int?>)((CRMspCheckDefaultCompanySettingUserConflict_Result s) => s.SettingID))));
										Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbIII.CRMspUpdateCompanyDefaultSettingDefFields(userId, string.Join(",", values2), (short)2));
									}
									else if (flag5)
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
							bool result7 = false;
							bool.TryParse(item2["IsDefault"]?.ToString(), out result7);
							if (!result7)
							{
								jObject["IsDefault"] = false;
							}
							else
							{
								bool flag6 = Enumerable.Any<CRMspCheckDefaultCompanySettingUserConflict_Result>((IEnumerable<CRMspCheckDefaultCompanySettingUserConflict_Result>)list20, (Func<CRMspCheckDefaultCompanySettingUserConflict_Result, bool>)((CRMspCheckDefaultCompanySettingUserConflict_Result s) => s.UserId == userId));
								if (flag6 && CS_0024_003C_003E8__locals0.vm.SaveDefSettings == 1)
								{
									jObject["IsDefault"] = true;
									List<int?> values3 = Enumerable.ToList<int?>(Enumerable.Distinct<int?>(Enumerable.Select<CRMspCheckDefaultCompanySettingUserConflict_Result, int?>(Enumerable.Where<CRMspCheckDefaultCompanySettingUserConflict_Result>((IEnumerable<CRMspCheckDefaultCompanySettingUserConflict_Result>)list20, (Func<CRMspCheckDefaultCompanySettingUserConflict_Result, bool>)((CRMspCheckDefaultCompanySettingUserConflict_Result s) => s.UserId == userId)), (Func<CRMspCheckDefaultCompanySettingUserConflict_Result, int?>)((CRMspCheckDefaultCompanySettingUserConflict_Result s) => s.SettingID))));
									Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbIII.CRMspUpdateCompanyDefaultSettingDefFields(userId, string.Join(",", values3), (short)3));
								}
								else if (flag6)
								{
									jObject["IsDefault"] = false;
								}
								else
								{
									jObject["IsDefault"] = true;
								}
							}
							jArray2.Add(jObject);
						}
						CS_0024_003C_003E8__locals0.vm.AccessUserJson = jArray2.ToString(Formatting.None);
					}
					catch (Exception e2)
					{
						ErrorSignal.FromCurrentContext().Raise(e2);
						CS_0024_003C_003E8__locals0.vm.AccessUserJson = null;
					}
				}
				else
				{
					CS_0024_003C_003E8__locals0.vm.AccessUserJson = null;
				}
				crmCompanyQuickRegisterDefSetting.AccessUserJson = CS_0024_003C_003E8__locals0.vm.AccessUserJson;
				if (CS_0024_003C_003E8__locals0.vm.CompanyQuickRegisterDefSettingId > 0)
				{
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.Entry(crmCompanyQuickRegisterDefSetting).State = EntityState.Modified;
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					_dbTbl.SaveChanges();
					using (List<Languages>.Enumerator enumerator2 = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							_003C_003Ec__DisplayClass8_2 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass8_2();
							CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
							CS_0024_003C_003E8__locals2.lang = enumerator2.Current;
							DbSet<CrmCompanyQuickRegisterDefSetting_Lang> crmCompanyQuickRegisterDefSetting_Lang = _dbTbl.CrmCompanyQuickRegisterDefSetting_Lang;
							ParameterExpression val = Expression.Parameter(typeof(CrmCompanyQuickRegisterDefSetting_Lang), "c");
							CrmCompanyQuickRegisterDefSetting_Lang crmCompanyQuickRegisterDefSetting_Lang2 = Queryable.FirstOrDefault<CrmCompanyQuickRegisterDefSetting_Lang>((IQueryable<CrmCompanyQuickRegisterDefSetting_Lang>)crmCompanyQuickRegisterDefSetting_Lang, Expression.Lambda<Func<CrmCompanyQuickRegisterDefSetting_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals2, typeof(_003C_003Ec__DisplayClass8_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals2, typeof(_003C_003Ec__DisplayClass8_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (crmCompanyQuickRegisterDefSetting_Lang2 != null)
							{
								crmCompanyQuickRegisterDefSetting_Lang2.SettingTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								crmCompanyQuickRegisterDefSetting_Lang2.cmpActivityType = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								crmCompanyQuickRegisterDefSetting_Lang2.cmpSpecialPoint = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								crmCompanyQuickRegisterDefSetting_Lang2.cmpDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								crmCompanyQuickRegisterDefSetting_Lang2.prsSpecialPoint = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								crmCompanyQuickRegisterDefSetting_Lang2.prsDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								crmCompanyQuickRegisterDefSetting_Lang2.prjTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								crmCompanyQuickRegisterDefSetting_Lang2.prjDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								crmCompanyQuickRegisterDefSetting_Lang2.prjPostFix = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								crmCompanyQuickRegisterDefSetting_Lang2.prjSubject = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								crmCompanyQuickRegisterDefSetting_Lang2.prjTitleGroup = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								crmCompanyQuickRegisterDefSetting_Lang2.prjDescI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								crmCompanyQuickRegisterDefSetting_Lang2.cnvsDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								crmCompanyQuickRegisterDefSetting_Lang2.cnvsReferDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								_dbTbl.Entry(crmCompanyQuickRegisterDefSetting_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							crmCompanyQuickRegisterDefSetting_Lang2 = new CrmCompanyQuickRegisterDefSetting_Lang();
							crmCompanyQuickRegisterDefSetting_Lang2.LanguageID = CS_0024_003C_003E8__locals2.lang.LanguageID;
							crmCompanyQuickRegisterDefSetting_Lang2.CompanyQuickRegisterDefSettingId = CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.vm.CompanyQuickRegisterDefSettingId;
							crmCompanyQuickRegisterDefSetting_Lang2.SettingTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
							crmCompanyQuickRegisterDefSetting_Lang2.cmpActivityType = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
							crmCompanyQuickRegisterDefSetting_Lang2.cmpSpecialPoint = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
							crmCompanyQuickRegisterDefSetting_Lang2.cmpDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
							crmCompanyQuickRegisterDefSetting_Lang2.prsSpecialPoint = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
							crmCompanyQuickRegisterDefSetting_Lang2.prsDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
							crmCompanyQuickRegisterDefSetting_Lang2.prjTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
							crmCompanyQuickRegisterDefSetting_Lang2.prjDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
							crmCompanyQuickRegisterDefSetting_Lang2.prjPostFix = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
							crmCompanyQuickRegisterDefSetting_Lang2.prjSubject = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
							crmCompanyQuickRegisterDefSetting_Lang2.prjTitleGroup = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
							crmCompanyQuickRegisterDefSetting_Lang2.prjDescI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
							crmCompanyQuickRegisterDefSetting_Lang2.cnvsDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
							crmCompanyQuickRegisterDefSetting_Lang2.cnvsReferDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
							_dbTbl.CrmCompanyQuickRegisterDefSetting_Lang.Add(crmCompanyQuickRegisterDefSetting_Lang2);
							_dbTbl.SaveChanges();
						}
					}
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
				else
				{
					crmCompanyQuickRegisterDefSetting.FirstRegisterUserId = currentUser.UserId;
					crmCompanyQuickRegisterDefSetting.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					crmCompanyQuickRegisterDefSetting.FirstRegisterDate = now;
					crmCompanyQuickRegisterDefSetting.GUId = Guid.NewGuid();
					crmCompanyQuickRegisterDefSetting.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.CrmCompanyQuickRegisterDefSetting.Add(crmCompanyQuickRegisterDefSetting);
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					_dbTbl.SaveChanges();
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
					{
						CrmCompanyQuickRegisterDefSetting_Lang crmCompanyQuickRegisterDefSetting_Lang3 = new CrmCompanyQuickRegisterDefSetting_Lang();
						crmCompanyQuickRegisterDefSetting_Lang3.LanguageID = lang.LanguageID;
						crmCompanyQuickRegisterDefSetting_Lang3.CompanyQuickRegisterDefSettingId = crmCompanyQuickRegisterDefSetting.CompanyQuickRegisterDefSettingId;
						crmCompanyQuickRegisterDefSetting_Lang3.SettingTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmCompanyQuickRegisterDefSetting_Lang3.cmpActivityType = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmCompanyQuickRegisterDefSetting_Lang3.cmpSpecialPoint = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmCompanyQuickRegisterDefSetting_Lang3.cmpDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmCompanyQuickRegisterDefSetting_Lang3.prsSpecialPoint = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmCompanyQuickRegisterDefSetting_Lang3.prsDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmCompanyQuickRegisterDefSetting_Lang3.prjTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmCompanyQuickRegisterDefSetting_Lang3.prjDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmCompanyQuickRegisterDefSetting_Lang3.prjPostFix = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmCompanyQuickRegisterDefSetting_Lang3.prjSubject = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmCompanyQuickRegisterDefSetting_Lang3.prjTitleGroup = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmCompanyQuickRegisterDefSetting_Lang3.prjDescI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmCompanyQuickRegisterDefSetting_Lang3.cnvsDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmCompanyQuickRegisterDefSetting_Lang3.cnvsReferDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						_dbTbl.CrmCompanyQuickRegisterDefSetting_Lang.Add(crmCompanyQuickRegisterDefSetting_Lang3);
						_dbTbl.SaveChanges();
					}
					CS_0024_003C_003E8__locals0.vm.CompanyQuickRegisterDefSettingId = crmCompanyQuickRegisterDefSetting.CompanyQuickRegisterDefSettingId;
					base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
				}
				CS_0024_003C_003E8__locals0.vm.AppType = crmCompanyQuickRegisterDefSetting.AppType;
				CS_0024_003C_003E8__locals0.vm.UserId = crmCompanyQuickRegisterDefSetting.UserId;
				CS_0024_003C_003E8__locals0.vm.FirstRegisterUserId = crmCompanyQuickRegisterDefSetting.FirstRegisterUserId;
				CS_0024_003C_003E8__locals0.vm.FirstRegisterDate = crmCompanyQuickRegisterDefSetting.FirstRegisterDate;
				CS_0024_003C_003E8__locals0.vm.RegisterDate = crmCompanyQuickRegisterDefSetting.RegisterDate;
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCompanyQuickRegisterDefSetting");
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

	public void SetRegisterInfo(CrmCompanyQuickRegisterDefSettingLanguageViewModel model)
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
			if (model.CompanyQuickRegisterDefSettingId > 0)
			{
				if (model.FirstRegisterUserId == currentUser.UserId)
				{
					text = currentUser.FullName;
				}
				else
				{
					CRMspSelectUsersById_Result cRMspSelectUsersById_Result = CRMIdeal.Classes.Helper.User.SelectUsersById(model.FirstRegisterUserId);
					text = ((cRMspSelectUsersById_Result != null) ? (cRMspSelectUsersById_Result.FullName ?? "") : "");
				}
				if (model.UserId == currentUser.UserId)
				{
					text2 = currentUser.FullName;
				}
				else
				{
					CRMspSelectUsersById_Result cRMspSelectUsersById_Result2 = CRMIdeal.Classes.Helper.User.SelectUsersById(model.UserId);
					text2 = ((cRMspSelectUsersById_Result2 != null) ? (cRMspSelectUsersById_Result2.FullName ?? "") : "");
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

	public void FullAllCombo()
	{
		GetcmpTitleList();
		GetcmpPresentationList();
		GetcmpTypeList();
		GetcmpGroupList();
		GetcmpGroupIIList();
		GetcmpGroupIIIList();
		GetcmpGroupIVList();
		GetSubGroup(0);
		GetPrsTitleList();
		GetPrsJobsList();
		GetPrsDepartmentList();
		GetPrsTypeList();
		GetPrsGroupList();
		GetPrsSexList();
		GetPrsEducation();
		GetStatusGroups();
		GetprjPriorityList();
		GetprjGradeList();
		GetprjGroupList();
		GetcnvsPriorityList();
		GetTopicList();
		GetcnvsStatusList(0);
		GetPordDefaultSettingPublicList();
		GetOrdDefaultSettingPublicList();
	}

	[AjaxOnly]
	public JsonResult GetcmpTitleList()
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyTitle_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyTitle_Result>)Enumerable.ToList<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)_db.CRMspSelectCompanyTitle(lCID, result)), (Func<CRMspSelectCompanyTitle_Result, SelectListItem>)((CRMspSelectCompanyTitle_Result item) => new SelectListItem
			{
				Text = item.CompanyTitle,
				Value = item.CompanyTitleID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.cmpTitleList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetcmpPresentationList()
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyPresentation_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyPresentation_Result>)Enumerable.ToList<CRMspSelectCompanyPresentation_Result>((IEnumerable<CRMspSelectCompanyPresentation_Result>)_db.CRMspSelectCompanyPresentation(lCID, result)), (Func<CRMspSelectCompanyPresentation_Result, SelectListItem>)((CRMspSelectCompanyPresentation_Result item) => new SelectListItem
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyType_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyType_Result>)Enumerable.ToList<CRMspSelectCompanyType_Result>((IEnumerable<CRMspSelectCompanyType_Result>)_db.CRMspSelectCompanyType(lCID, result)), (Func<CRMspSelectCompanyType_Result, SelectListItem>)((CRMspSelectCompanyType_Result item) => new SelectListItem
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyGroup_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroup_Result>)Enumerable.ToList<CRMspSelectCompanyGroup_Result>((IEnumerable<CRMspSelectCompanyGroup_Result>)_db.CRMspSelectCompanyGroup(UserLogin.CurrentUser.UserId, lCID, result, result2)), (Func<CRMspSelectCompanyGroup_Result, SelectListItem>)((CRMspSelectCompanyGroup_Result item) => new SelectListItem
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyGroupsII_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsII_Result>)Enumerable.ToList<CRMspSelectCompanyGroupsII_Result>((IEnumerable<CRMspSelectCompanyGroupsII_Result>)_db.CRMspSelectCompanyGroupsII(lCID, result)), (Func<CRMspSelectCompanyGroupsII_Result, SelectListItem>)((CRMspSelectCompanyGroupsII_Result item) => new SelectListItem
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyGroupsIII_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsIII_Result>)Enumerable.ToList<CRMspSelectCompanyGroupsIII_Result>((IEnumerable<CRMspSelectCompanyGroupsIII_Result>)_db.CRMspSelectCompanyGroupsIII(lCID, result)), (Func<CRMspSelectCompanyGroupsIII_Result, SelectListItem>)((CRMspSelectCompanyGroupsIII_Result item) => new SelectListItem
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyGroupsIV_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsIV_Result>)Enumerable.ToList<CRMspSelectCompanyGroupsIV_Result>((IEnumerable<CRMspSelectCompanyGroupsIV_Result>)_db.CRMspSelectCompanyGroupsIV(UserLogin.CurrentUser.UserId, lCID, result, result2)), (Func<CRMspSelectCompanyGroupsIV_Result, SelectListItem>)((CRMspSelectCompanyGroupsIV_Result item) => new SelectListItem
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
	public JsonResult GetSubGroup(int cmpGroupId)
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanySubGroup_Result, SelectListItem>((IEnumerable<CRMspSelectCompanySubGroup_Result>)Enumerable.ToList<CRMspSelectCompanySubGroup_Result>((IEnumerable<CRMspSelectCompanySubGroup_Result>)_db.CRMspSelectCompanySubGroup(UserLogin.CurrentUser.UserId, cmpGroupId, lCID, result, result2)), (Func<CRMspSelectCompanySubGroup_Result, SelectListItem>)((CRMspSelectCompanySubGroup_Result item) => new SelectListItem
			{
				Text = item.SubGroupName,
				Value = item.CompanySubGroupID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.cmpSubGroupList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPrsTitleList()
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectPersonTitle_Result, SelectListItem>((IEnumerable<CRMspSelectPersonTitle_Result>)Enumerable.ToList<CRMspSelectPersonTitle_Result>((IEnumerable<CRMspSelectPersonTitle_Result>)_db.CRMspSelectPersonTitle(lCID, result)), (Func<CRMspSelectPersonTitle_Result, SelectListItem>)((CRMspSelectPersonTitle_Result item) => new SelectListItem
			{
				Text = item.PersonTitle,
				Value = item.PersonTitleID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.prsTitleList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPrsJobsList()
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectPersonJobs_Result, SelectListItem>((IEnumerable<CRMspSelectPersonJobs_Result>)Enumerable.ToList<CRMspSelectPersonJobs_Result>((IEnumerable<CRMspSelectPersonJobs_Result>)_db.CRMspSelectPersonJobs(lCID, result)), (Func<CRMspSelectPersonJobs_Result, SelectListItem>)((CRMspSelectPersonJobs_Result item) => new SelectListItem
			{
				Text = item.Jobs,
				Value = item.PersonJobID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.prsJobList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPrsDepartmentList()
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectPersonDepartments_Result, SelectListItem>((IEnumerable<CRMspSelectPersonDepartments_Result>)Enumerable.ToList<CRMspSelectPersonDepartments_Result>((IEnumerable<CRMspSelectPersonDepartments_Result>)_db.CRMspSelectPersonDepartments(lCID, result)), (Func<CRMspSelectPersonDepartments_Result, SelectListItem>)((CRMspSelectPersonDepartments_Result item) => new SelectListItem
			{
				Text = item.PersonDepartment,
				Value = item.PersonDepartmentId.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.prsDepartmentList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPrsTypeList()
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectPersonType_Result, SelectListItem>((IEnumerable<CRMspSelectPersonType_Result>)Enumerable.ToList<CRMspSelectPersonType_Result>((IEnumerable<CRMspSelectPersonType_Result>)_db.CRMspSelectPersonType(lCID, result)), (Func<CRMspSelectPersonType_Result, SelectListItem>)((CRMspSelectPersonType_Result item) => new SelectListItem
			{
				Text = item.PersonType,
				Value = item.PersonTypeID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.prsTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPrsGroupList()
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectPersonGroups_Result, SelectListItem>((IEnumerable<CRMspSelectPersonGroups_Result>)Enumerable.ToList<CRMspSelectPersonGroups_Result>((IEnumerable<CRMspSelectPersonGroups_Result>)_db.CRMspSelectPersonGroups(lCID, result)), (Func<CRMspSelectPersonGroups_Result, SelectListItem>)((CRMspSelectPersonGroups_Result item) => new SelectListItem
			{
				Text = item.PersonGroup,
				Value = item.PersonGroupID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.prsGroupList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPrsSexList()
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectSex_Result, SelectListItem>((IEnumerable<CRMspSelectSex_Result>)Enumerable.ToList<CRMspSelectSex_Result>((IEnumerable<CRMspSelectSex_Result>)_db.CRMspSelectSex(lCID, result)), (Func<CRMspSelectSex_Result, SelectListItem>)((CRMspSelectSex_Result item) => new SelectListItem
			{
				Text = item.SexType,
				Value = item.SexID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.prsSexList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPrsEducation()
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectEducation_Result, SelectListItem>((IEnumerable<CRMspSelectEducation_Result>)Enumerable.ToList<CRMspSelectEducation_Result>((IEnumerable<CRMspSelectEducation_Result>)_db.CRMspSelectEducation(lCID, result)), (Func<CRMspSelectEducation_Result, SelectListItem>)((CRMspSelectEducation_Result item) => new SelectListItem
			{
				Text = item.Education,
				Value = item.EducationID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.prsEducationList = list;
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectConversationStatusGroups_Result, SelectListItem>((IEnumerable<CRMspSelectConversationStatusGroups_Result>)Enumerable.ToList<CRMspSelectConversationStatusGroups_Result>((IEnumerable<CRMspSelectConversationStatusGroups_Result>)_db.CRMspSelectConversationStatusGroups(lCID, result)), (Func<CRMspSelectConversationStatusGroups_Result, SelectListItem>)((CRMspSelectConversationStatusGroups_Result item) => new SelectListItem
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectProjectPriority_Result, SelectListItem>((IEnumerable<CRMspSelectProjectPriority_Result>)Enumerable.ToList<CRMspSelectProjectPriority_Result>((IEnumerable<CRMspSelectProjectPriority_Result>)_db.CRMspSelectProjectPriority(lCID, result)), (Func<CRMspSelectProjectPriority_Result, SelectListItem>)((CRMspSelectProjectPriority_Result item) => new SelectListItem
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectProjectGrade_Result, SelectListItem>((IEnumerable<CRMspSelectProjectGrade_Result>)Enumerable.ToList<CRMspSelectProjectGrade_Result>((IEnumerable<CRMspSelectProjectGrade_Result>)_db.CRMspSelectProjectGrade(lCID, result)), (Func<CRMspSelectProjectGrade_Result, SelectListItem>)((CRMspSelectProjectGrade_Result item) => new SelectListItem
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectProjectGroups_Result, SelectListItem>((IEnumerable<CRMspSelectProjectGroups_Result>)Enumerable.ToList<CRMspSelectProjectGroups_Result>((IEnumerable<CRMspSelectProjectGroups_Result>)_db.CRMspSelectProjectGroups(lCID, result)), (Func<CRMspSelectProjectGroups_Result, SelectListItem>)((CRMspSelectProjectGroups_Result item) => new SelectListItem
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

	public JsonResult ProjectTitleFull(string valPrjTitle)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectCompanyProjectTitle_Result> list = new List<CRMspSelectCompanyProjectTitle_Result>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			valPrjTitle = valPrjTitle ?? "";
			list = Enumerable.ToList<CRMspSelectCompanyProjectTitle_Result>((IEnumerable<CRMspSelectCompanyProjectTitle_Result>)_db.CRMspSelectCompanyProjectTitle(valPrjTitle, UserLogin.CurrentUser.UserId, lCID, result, result2));
			foreach (CRMspSelectCompanyProjectTitle_Result item in list)
			{
				item.prjStatusGroup = item.prjStatusGroup ?? "";
				item.prjTitle = item.prjTitle ?? "";
				item.ProjectTitleGroupId = item.ProjectTitleGroupId.GetValueOrDefault();
				item.ProjectTitleGradeId = item.ProjectTitleGradeId.GetValueOrDefault();
				item.ProjectTitlePriorityId = item.ProjectTitlePriorityId.GetValueOrDefault();
				item.ProjectTitleDesc = item.ProjectTitleDesc ?? "";
				item.ProjectTitleStatusGroupId = item.ProjectTitleStatusGroupId.GetValueOrDefault();
				item.ProjectCategoryId = item.ProjectCategoryId.GetValueOrDefault();
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

	public List<TreeViewItemModel> GetProjectCategoryNodeTree(List<CRMspSelectProjectCategoryTree_Result> lstCategory, int? currCatId)
	{
		List<TreeViewItemModel> list = new List<TreeViewItemModel>();
		try
		{
			List<CRMspSelectProjectCategoryTree_Result> list2 = Enumerable.ToList<CRMspSelectProjectCategoryTree_Result>(Enumerable.Where<CRMspSelectProjectCategoryTree_Result>((IEnumerable<CRMspSelectProjectCategoryTree_Result>)lstCategory, (Func<CRMspSelectProjectCategoryTree_Result, bool>)((CRMspSelectProjectCategoryTree_Result m) => m.ParentId == currCatId)));
			if (Enumerable.Any<CRMspSelectProjectCategoryTree_Result>((IEnumerable<CRMspSelectProjectCategoryTree_Result>)list2))
			{
				foreach (CRMspSelectProjectCategoryTree_Result item in list2)
				{
					TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
					treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.ProjectCategoryId.ToString()));
					treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("categoryFullName", item.CategoryFullName.ToString()));
					treeViewItemModel.Id = item.ProjectCategoryId.ToString();
					treeViewItemModel.Text = item.CategoryName;
					treeViewItemModel.ImageUrl = "";
					List<TreeViewItemModel> projectCategoryNodeTree = GetProjectCategoryNodeTree(lstCategory, item.ProjectCategoryId);
					treeViewItemModel.Items = new List<TreeViewItemModel>(projectCategoryNodeTree);
					list.Add(treeViewItemModel);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public List<TreeViewItemModel> GetProjectCategoryTree(int currCatId = -1)
	{
		List<TreeViewItemModel> list = new List<TreeViewItemModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectProjectCategoryTree_Result> list2 = Enumerable.ToList<CRMspSelectProjectCategoryTree_Result>((IEnumerable<CRMspSelectProjectCategoryTree_Result>)_db.CRMspSelectProjectCategoryTree(currCatId, lCID, result));
			if (Enumerable.Any<CRMspSelectProjectCategoryTree_Result>((IEnumerable<CRMspSelectProjectCategoryTree_Result>)list2))
			{
				List<CRMspSelectProjectCategoryTree_Result> list3 = Enumerable.ToList<CRMspSelectProjectCategoryTree_Result>(Enumerable.Where<CRMspSelectProjectCategoryTree_Result>((IEnumerable<CRMspSelectProjectCategoryTree_Result>)list2, (Func<CRMspSelectProjectCategoryTree_Result, bool>)((CRMspSelectProjectCategoryTree_Result m) => m.ParentId == 0)));
				if (Enumerable.Any<CRMspSelectProjectCategoryTree_Result>((IEnumerable<CRMspSelectProjectCategoryTree_Result>)list3))
				{
					foreach (CRMspSelectProjectCategoryTree_Result item in list3)
					{
						TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
						treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.ProjectCategoryId.ToString()));
						treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("categoryFullName", item.CategoryFullName.ToString()));
						treeViewItemModel.Id = item.ProjectCategoryId.ToString();
						treeViewItemModel.Text = item.CategoryName;
						treeViewItemModel.ImageUrl = "";
						List<TreeViewItemModel> projectCategoryNodeTree = GetProjectCategoryNodeTree(list2, item.ProjectCategoryId);
						treeViewItemModel.Items = new List<TreeViewItemModel>(projectCategoryNodeTree);
						list.Add(treeViewItemModel);
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
		return list;
	}

	[AjaxOnly]
	public ActionResult _PartialProjectCategoryTree(int currCatId = -1)
	{
		try
		{
			List<TreeViewItemModel> projectCategoryTree = GetProjectCategoryTree(currCatId);
			base.ViewBag.PrjCategoryTree = projectCategoryTree;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView();
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectConversationPriority_Result, SelectListItem>((IEnumerable<CRMspSelectConversationPriority_Result>)Enumerable.ToList<CRMspSelectConversationPriority_Result>((IEnumerable<CRMspSelectConversationPriority_Result>)_db.CRMspSelectConversationPriority(lCID, result)), (Func<CRMspSelectConversationPriority_Result, SelectListItem>)((CRMspSelectConversationPriority_Result item) => new SelectListItem
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectConversationTopics_Result, SelectListItem>((IEnumerable<CRMspSelectConversationTopics_Result>)Enumerable.ToList<CRMspSelectConversationTopics_Result>((IEnumerable<CRMspSelectConversationTopics_Result>)_db.CRMspSelectConversationTopics(lCID, result)), (Func<CRMspSelectConversationTopics_Result, SelectListItem>)((CRMspSelectConversationTopics_Result item) => new SelectListItem
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
			foreach (CRMspSelectConversationStatus_Result item in Enumerable.ToList<CRMspSelectConversationStatus_Result>((IEnumerable<CRMspSelectConversationStatus_Result>)_db.CRMspSelectConversationStatus(statusGroupId, lCID, result)))
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

	public JsonResult GetCity(string value, int? cityId = 0)
	{
		List<mct_CRMspSelectUserAccessCompanyCity_Result> list = new List<mct_CRMspSelectUserAccessCompanyCity_Result>();
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
			list = Enumerable.ToList<mct_CRMspSelectUserAccessCompanyCity_Result>((IEnumerable<mct_CRMspSelectUserAccessCompanyCity_Result>)_db.mfi_CRMspSelectUserAccessCompanyCity(UserLogin.CurrentUser.UserId, value, lCID, result, result2));
			if (list != null && Enumerable.Any<mct_CRMspSelectUserAccessCompanyCity_Result>((IEnumerable<mct_CRMspSelectUserAccessCompanyCity_Result>)list))
			{
				list = ((!string.IsNullOrWhiteSpace(value)) ? Enumerable.ToList<mct_CRMspSelectUserAccessCompanyCity_Result>(Enumerable.Take<mct_CRMspSelectUserAccessCompanyCity_Result>((IEnumerable<mct_CRMspSelectUserAccessCompanyCity_Result>)list, 600)) : ((cityId.HasValue && cityId != 0 && string.IsNullOrWhiteSpace(value)) ? Enumerable.ToList<mct_CRMspSelectUserAccessCompanyCity_Result>(Enumerable.Take<mct_CRMspSelectUserAccessCompanyCity_Result>(Enumerable.Where<mct_CRMspSelectUserAccessCompanyCity_Result>((IEnumerable<mct_CRMspSelectUserAccessCompanyCity_Result>)list, (Func<mct_CRMspSelectUserAccessCompanyCity_Result, bool>)((mct_CRMspSelectUserAccessCompanyCity_Result m) => m.CityID == cityId)), 600)) : ((!cityId.HasValue || cityId == 0) ? Enumerable.ToList<mct_CRMspSelectUserAccessCompanyCity_Result>(Enumerable.Take<mct_CRMspSelectUserAccessCompanyCity_Result>((IEnumerable<mct_CRMspSelectUserAccessCompanyCity_Result>)list, 600)) : Enumerable.ToList<mct_CRMspSelectUserAccessCompanyCity_Result>(Enumerable.Take<mct_CRMspSelectUserAccessCompanyCity_Result>(Enumerable.Where<mct_CRMspSelectUserAccessCompanyCity_Result>((IEnumerable<mct_CRMspSelectUserAccessCompanyCity_Result>)list, (Func<mct_CRMspSelectUserAccessCompanyCity_Result, bool>)((mct_CRMspSelectUserAccessCompanyCity_Result m) => m.CityID == cityId)), 600)))));
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
	public JsonResult GetPordDefaultSettingPublicList()
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<WSspSelectPreOrderDefaultSettingPublic_Result, SelectListItem>((IEnumerable<WSspSelectPreOrderDefaultSettingPublic_Result>)Enumerable.ToList<WSspSelectPreOrderDefaultSettingPublic_Result>((IEnumerable<WSspSelectPreOrderDefaultSettingPublic_Result>)_dbI.WSspSelectPreOrderDefaultSettingPublic(lCID, result)), (Func<WSspSelectPreOrderDefaultSettingPublic_Result, SelectListItem>)((WSspSelectPreOrderDefaultSettingPublic_Result item) => new SelectListItem
			{
				Text = item.SettingTitle,
				Value = item.PreOrderSettingID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PordDefaultSettingPublicList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetOrdDefaultSettingPublicList()
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<WSspSelectOrderDefaultSettingPublic_Result, SelectListItem>((IEnumerable<WSspSelectOrderDefaultSettingPublic_Result>)Enumerable.ToList<WSspSelectOrderDefaultSettingPublic_Result>((IEnumerable<WSspSelectOrderDefaultSettingPublic_Result>)_dbI.WSspSelectOrderDefaultSettingPublic(lCID, result)), (Func<WSspSelectOrderDefaultSettingPublic_Result, SelectListItem>)((WSspSelectOrderDefaultSettingPublic_Result item) => new SelectListItem
			{
				Text = item.SettingTitle,
				Value = item.OrderSettingID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.OrdDefaultSettingPublicList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
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

	[LoginAuthorize]
	public ActionResult CompanyEditLocation(int id)
	{
		CrmCompanyQuickRegisterDefSettingLocationLanguageViewModel crmCompanyQuickRegisterDefSettingLocationLanguageViewModel = new CrmCompanyQuickRegisterDefSettingLocationLanguageViewModel();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			CRMspSelectCompanyQuickRegisterDefSettingById_Result cRMspSelectCompanyQuickRegisterDefSettingById_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyQuickRegisterDefSettingById_Result>((IEnumerable<CRMspSelectCompanyQuickRegisterDefSettingById_Result>)_dbI.CRMspSelectCompanyQuickRegisterDefSettingById(id, lCID, result));
			if (cRMspSelectCompanyQuickRegisterDefSettingById_Result != null)
			{
				crmCompanyQuickRegisterDefSettingLocationLanguageViewModel.CompanyQuickRegisterDefSettingId = id;
				crmCompanyQuickRegisterDefSettingLocationLanguageViewModel.cmpLocationLat = cRMspSelectCompanyQuickRegisterDefSettingById_Result.cmpLocationLat;
				crmCompanyQuickRegisterDefSettingLocationLanguageViewModel.cmpLocationLong = cRMspSelectCompanyQuickRegisterDefSettingById_Result.cmpLocationLong;
				crmCompanyQuickRegisterDefSettingLocationLanguageViewModel.cmpLocationZoom = cRMspSelectCompanyQuickRegisterDefSettingById_Result.cmpLocationZoom;
				base.ViewBag.AppType = cRMspSelectCompanyQuickRegisterDefSettingById_Result.AppType;
				base.ViewBag.SettingTitle = cRMspSelectCompanyQuickRegisterDefSettingById_Result.SettingTitle;
			}
			else
			{
				crmCompanyQuickRegisterDefSettingLocationLanguageViewModel.CompanyQuickRegisterDefSettingId = id;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			base.ViewBag.Error = Messages.frmErrorMessage;
		}
		return View(crmCompanyQuickRegisterDefSettingLocationLanguageViewModel);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult CompanyEditLocation(CrmCompanyQuickRegisterDefSettingLocationLanguageViewModel model)
	{
		_003C_003Ec__DisplayClass42_0 _003C_003Ec__DisplayClass42_ = new _003C_003Ec__DisplayClass42_0();
		_003C_003Ec__DisplayClass42_.model = model;
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
			DbSet<CrmCompanyQuickRegisterDefSetting> crmCompanyQuickRegisterDefSetting = _dbTbl.CrmCompanyQuickRegisterDefSetting;
			ParameterExpression val = Expression.Parameter(typeof(CrmCompanyQuickRegisterDefSetting), "m");
			CrmCompanyQuickRegisterDefSetting crmCompanyQuickRegisterDefSetting2 = Queryable.FirstOrDefault<CrmCompanyQuickRegisterDefSetting>((IQueryable<CrmCompanyQuickRegisterDefSetting>)crmCompanyQuickRegisterDefSetting, Expression.Lambda<Func<CrmCompanyQuickRegisterDefSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass42_, typeof(_003C_003Ec__DisplayClass42_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmCompanyQuickRegisterDefSetting2 != null)
			{
				base.ViewBag.SettingTitle = crmCompanyQuickRegisterDefSetting2.SettingTitle;
			}
			if (base.ModelState.IsValid)
			{
				if (num == 0)
				{
					if (crmCompanyQuickRegisterDefSetting2 != null)
					{
						DateTime now = DateTime.Now;
						string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						_dbIII.CRMspUpdateCompanyQuickRegisterDefSettingLocation(_003C_003Ec__DisplayClass42_.model.CompanyQuickRegisterDefSettingId, _003C_003Ec__DisplayClass42_.model.cmpLocationLat, _003C_003Ec__DisplayClass42_.model.cmpLocationLong, _003C_003Ec__DisplayClass42_.model.cmpLocationZoom, now, registerDatePersian, UserLogin.CurrentUser.UserId, Configuration.AppType);
						base.ViewBag.Successfull = Messages.cmpCompanyEditSuccessFulMessage;
					}
					else
					{
						text = Messages.ErrorNotFoundSetting;
					}
				}
				else
				{
					text = Messages.msgErrorRunFunction;
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
		return View(_003C_003Ec__DisplayClass42_.model);
	}

	[LoginAuthorize]
	public ActionResult PersonEditLocation(int id)
	{
		CrmCompanyQuickRegisterDefSettingLocationLanguageViewModel crmCompanyQuickRegisterDefSettingLocationLanguageViewModel = new CrmCompanyQuickRegisterDefSettingLocationLanguageViewModel();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			CRMspSelectCompanyQuickRegisterDefSettingById_Result cRMspSelectCompanyQuickRegisterDefSettingById_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyQuickRegisterDefSettingById_Result>((IEnumerable<CRMspSelectCompanyQuickRegisterDefSettingById_Result>)_dbI.CRMspSelectCompanyQuickRegisterDefSettingById(id, lCID, result));
			if (cRMspSelectCompanyQuickRegisterDefSettingById_Result != null)
			{
				crmCompanyQuickRegisterDefSettingLocationLanguageViewModel.CompanyQuickRegisterDefSettingId = id;
				crmCompanyQuickRegisterDefSettingLocationLanguageViewModel.prsLocationLat = cRMspSelectCompanyQuickRegisterDefSettingById_Result.prsLocationLat;
				crmCompanyQuickRegisterDefSettingLocationLanguageViewModel.prsLocationLong = cRMspSelectCompanyQuickRegisterDefSettingById_Result.prsLocationLong;
				crmCompanyQuickRegisterDefSettingLocationLanguageViewModel.prsLocationZoom = cRMspSelectCompanyQuickRegisterDefSettingById_Result.prsLocationZoom;
				base.ViewBag.AppType = cRMspSelectCompanyQuickRegisterDefSettingById_Result.AppType;
				base.ViewBag.SettingTitle = cRMspSelectCompanyQuickRegisterDefSettingById_Result.SettingTitle;
			}
			else
			{
				crmCompanyQuickRegisterDefSettingLocationLanguageViewModel.CompanyQuickRegisterDefSettingId = id;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			base.ViewBag.Error = Messages.frmErrorMessage;
		}
		return View(crmCompanyQuickRegisterDefSettingLocationLanguageViewModel);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult PersonEditLocation(CrmCompanyQuickRegisterDefSettingLocationLanguageViewModel model)
	{
		_003C_003Ec__DisplayClass44_0 _003C_003Ec__DisplayClass44_ = new _003C_003Ec__DisplayClass44_0();
		_003C_003Ec__DisplayClass44_.model = model;
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
			DbSet<CrmCompanyQuickRegisterDefSetting> crmCompanyQuickRegisterDefSetting = _dbTbl.CrmCompanyQuickRegisterDefSetting;
			ParameterExpression val = Expression.Parameter(typeof(CrmCompanyQuickRegisterDefSetting), "m");
			CrmCompanyQuickRegisterDefSetting crmCompanyQuickRegisterDefSetting2 = Queryable.FirstOrDefault<CrmCompanyQuickRegisterDefSetting>((IQueryable<CrmCompanyQuickRegisterDefSetting>)crmCompanyQuickRegisterDefSetting, Expression.Lambda<Func<CrmCompanyQuickRegisterDefSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass44_, typeof(_003C_003Ec__DisplayClass44_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmCompanyQuickRegisterDefSetting2 != null)
			{
				base.ViewBag.SettingTitle = crmCompanyQuickRegisterDefSetting2.SettingTitle;
			}
			if (base.ModelState.IsValid)
			{
				if (num == 0)
				{
					if (crmCompanyQuickRegisterDefSetting2 != null)
					{
						DateTime now = DateTime.Now;
						string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						_dbIII.CRMspUpdatePersonQuickRegisterDefSettingLocation(_003C_003Ec__DisplayClass44_.model.CompanyQuickRegisterDefSettingId, _003C_003Ec__DisplayClass44_.model.prsLocationLat, _003C_003Ec__DisplayClass44_.model.prsLocationLong, _003C_003Ec__DisplayClass44_.model.prsLocationZoom, now, registerDatePersian, UserLogin.CurrentUser.UserId, Configuration.AppType);
						base.ViewBag.Successfull = Messages.cmpCompanyEditSuccessFulMessage;
					}
					else
					{
						text = Messages.ErrorNotFoundSetting;
					}
				}
				else
				{
					text = Messages.msgErrorRunFunction;
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
		return View(_003C_003Ec__DisplayClass44_.model);
	}

	[AjaxOnly]
	public JsonResult CheckDefaultCompanySettingUserConflict(int publicMode = 1, string accessUserJson = "", bool activeInQuickOrder = false, bool defaultForCmpInfo = false, bool defaultQuickOrder = false, bool defaultIsDefault = false, int settingId = 0)
	{
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			bool hasPublicDefaultForCmpInfo = false;
			bool hasPublicDefaultQuickOrder = false;
			bool hasPublicDefaultIsDefault = false;
			string text = "";
			switch (publicMode)
			{
			case 2:
				if (defaultForCmpInfo)
				{
					foreach (CRMspCheckPublicDefaultCompanySettingConflict_Result item in Enumerable.ToList<CRMspCheckPublicDefaultCompanySettingConflict_Result>((IEnumerable<CRMspCheckPublicDefaultCompanySettingConflict_Result>)_dbIII.CRMspCheckPublicDefaultCompanySettingConflict(settingId, (short)1, lCID, result)))
					{
						hasPublicDefaultForCmpInfo = true;
						text = text + string.Format(Messages.msgPublicDefaultCmpInfoConflict, item.OrderDefaultSetting) + "<br />";
					}
				}
				if (defaultQuickOrder && activeInQuickOrder)
				{
					foreach (CRMspCheckPublicDefaultCompanySettingConflict_Result item2 in Enumerable.ToList<CRMspCheckPublicDefaultCompanySettingConflict_Result>((IEnumerable<CRMspCheckPublicDefaultCompanySettingConflict_Result>)_dbIII.CRMspCheckPublicDefaultCompanySettingConflict(settingId, (short)2, lCID, result)))
					{
						hasPublicDefaultQuickOrder = true;
						text = text + string.Format(Messages.msgPublicDefaultQuickOrderConflict, item2.OrderDefaultSetting) + "<br />";
					}
				}
				if (!defaultIsDefault)
				{
					break;
				}
				foreach (CRMspCheckPublicDefaultCompanySettingConflict_Result item3 in Enumerable.ToList<CRMspCheckPublicDefaultCompanySettingConflict_Result>((IEnumerable<CRMspCheckPublicDefaultCompanySettingConflict_Result>)_dbIII.CRMspCheckPublicDefaultCompanySettingConflict(settingId, (short)3, lCID, result)))
				{
					hasPublicDefaultIsDefault = true;
					text = text + string.Format(Messages.msgPublicDefaultIsDefaultConflict, item3.OrderDefaultSetting) + "<br />";
				}
				break;
			case 3:
			{
				if (string.IsNullOrEmpty(accessUserJson))
				{
					break;
				}
				List<int> list = new List<int>();
				List<int> list2 = new List<int>();
				List<int> list3 = new List<int>();
				try
				{
					foreach (JToken item4 in JArray.Parse(accessUserJson))
					{
						int result2 = 0;
						int.TryParse(item4["UserId"]?.ToString() ?? item4["id"]?.ToString(), out result2);
						if (result2 <= 0)
						{
							continue;
						}
						bool result3 = false;
						bool.TryParse(item4["IsDefaultForCmpInfo"]?.ToString(), out result3);
						if (result3)
						{
							list.Add(result2);
						}
						if (activeInQuickOrder)
						{
							result3 = false;
							bool.TryParse(item4["IsDefIssueQuickOrder"]?.ToString(), out result3);
							if (result3)
							{
								list2.Add(result2);
							}
						}
						result3 = false;
						bool.TryParse(item4["IsDefault"]?.ToString(), out result3);
						if (result3)
						{
							list3.Add(result2);
						}
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
				List<CRMspCheckDefaultCompanySettingUserConflict_Result> list4 = new List<CRMspCheckDefaultCompanySettingUserConflict_Result>();
				List<CRMspCheckDefaultCompanySettingUserConflict_Result> list5 = new List<CRMspCheckDefaultCompanySettingUserConflict_Result>();
				List<CRMspCheckDefaultCompanySettingUserConflict_Result> list6 = new List<CRMspCheckDefaultCompanySettingUserConflict_Result>();
				if (Enumerable.Any<int>((IEnumerable<int>)list))
				{
					list4 = Enumerable.ToList<CRMspCheckDefaultCompanySettingUserConflict_Result>((IEnumerable<CRMspCheckDefaultCompanySettingUserConflict_Result>)_dbIII.CRMspCheckDefaultCompanySettingUserConflict(string.Join(",", Enumerable.Distinct<int>((IEnumerable<int>)list)), settingId, (short)1, lCID, result)) ?? new List<CRMspCheckDefaultCompanySettingUserConflict_Result>();
				}
				if (Enumerable.Any<int>((IEnumerable<int>)list2))
				{
					list5 = Enumerable.ToList<CRMspCheckDefaultCompanySettingUserConflict_Result>((IEnumerable<CRMspCheckDefaultCompanySettingUserConflict_Result>)_dbIII.CRMspCheckDefaultCompanySettingUserConflict(string.Join(",", Enumerable.Distinct<int>((IEnumerable<int>)list2)), settingId, (short)2, lCID, result)) ?? new List<CRMspCheckDefaultCompanySettingUserConflict_Result>();
				}
				if (Enumerable.Any<int>((IEnumerable<int>)list3))
				{
					list6 = Enumerable.ToList<CRMspCheckDefaultCompanySettingUserConflict_Result>((IEnumerable<CRMspCheckDefaultCompanySettingUserConflict_Result>)_dbIII.CRMspCheckDefaultCompanySettingUserConflict(string.Join(",", Enumerable.Distinct<int>((IEnumerable<int>)list3)), settingId, (short)3, lCID, result)) ?? new List<CRMspCheckDefaultCompanySettingUserConflict_Result>();
				}
				foreach (CRMspCheckDefaultCompanySettingUserConflict_Result item5 in list4)
				{
					text = text + string.Format(Messages.msgUserDefaultCmpInfoOverride, item5.User, item5.OrderDefaultSetting) + "<br />";
				}
				foreach (CRMspCheckDefaultCompanySettingUserConflict_Result item6 in list5)
				{
					text = text + string.Format(Messages.msgUserDefaultQuickOrderOverride, item6.User, item6.OrderDefaultSetting) + "<br />";
				}
				foreach (CRMspCheckDefaultCompanySettingUserConflict_Result item7 in list6)
				{
					text = text + string.Format(Messages.msgUserDefaultIsDefaultOverride, item7.User, item7.OrderDefaultSetting) + "<br />";
				}
				break;
			}
			}
			return Json(new
			{
				message = text,
				hasPublicDefaultForCmpInfo = hasPublicDefaultForCmpInfo,
				hasPublicDefaultQuickOrder = hasPublicDefaultQuickOrder,
				hasPublicDefaultIsDefault = hasPublicDefaultIsDefault,
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
			hasPublicDefaultForCmpInfo = false,
			hasPublicDefaultQuickOrder = false,
			hasPublicDefaultIsDefault = false,
			isSuccess = false
		}, JsonRequestBehavior.AllowGet);
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbI.Dispose();
		_dbIII.Dispose();
		_dbTbl.Dispose();
		base.Dispose(disposing);
	}
}

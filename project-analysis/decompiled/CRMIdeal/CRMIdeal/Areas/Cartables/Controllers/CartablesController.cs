using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Objects;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Calendar;
using CRM.General.IO;
using CRM.General.IO.FTP;
using CRM.General.Security;
using CRM.General.Utilities;
using CRM.Models;
using CRM.Models.ViewModel.AI;
using CRM.Resources;
using CRMIdeal.Areas.Company.Controllers;
using CRMIdeal.Cache;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Cache.User;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using CRMIdeal.Hubs;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CRMIdeal.Areas.Cartables.Controllers;

public class CartablesController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass106_0
	{
		public int callHistoryId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass107_0
	{
		public CrmCallHistory callHistory;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass108_0
	{
		public int callHistoryId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass109_0
	{
		public CrmCallHistory callHistory;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass116_0
	{
		public int knlgid;

		public CRMspKnlgSearch_Result knlg;

		internal bool _003C_PartialKnlgPreviewInfo_003Eb__0(CRMspKnlgSearch_Result c)
		{
			return c.KnowledgeTankId > knlgid;
		}

		internal bool _003C_PartialKnlgPreviewInfo_003Eb__3(CRMspKnlgSearch_Result c)
		{
			return c.KnowledgeTankId < knlgid;
		}

		internal bool _003C_PartialKnlgPreviewInfo_003Eb__5(CRMspKnlgSearch_Result c)
		{
			return c.KnowledgeTankId == knlgid;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass127_0
	{
		public int noteId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass168_0
	{
		public int cmpId;

		public int currLangID;

		internal bool _003CCDailyTelAddCmpTel_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CCDailyTelAddCmpTel_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CCDailyTelAddCmpTel_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CCDailyTelAddCmpTel_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CCDailyTelAddCmpTel_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CCDailyTelAddCmpTel_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CCDailyTelAddCmpTel_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CCDailyTelAddCmpTel_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CCDailyTelAddCmpTel_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass169_0
	{
		public AddTelToCmpAndPrsViewModel model;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__9;

		internal bool _003CCDailyTelAddCmpTel_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CCDailyTelAddCmpTel_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CCDailyTelAddCmpTel_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CCDailyTelAddCmpTel_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CCDailyTelAddCmpTel_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CCDailyTelAddCmpTel_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CCDailyTelAddCmpTel_003Eb__9(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass169_1
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass169_0 CS_0024_003C_003E8__locals1;

		internal bool _003CCDailyTelAddCmpTel_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCDailyTelAddCmpTel_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCDailyTelAddCmpTel_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCDailyTelAddCmpTel_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCDailyTelAddCmpTel_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCDailyTelAddCmpTel_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCDailyTelAddCmpTel_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCDailyTelAddCmpTel_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCDailyTelAddCmpTel_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCDailyTelAddCmpTel_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCDailyTelAddCmpTel_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCDailyTelAddCmpTel_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass171_0
	{
		public int prsId;

		public int currLangID;

		internal bool _003CCDailyTelAddPrsTel_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CCDailyTelAddPrsTel_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CCDailyTelAddPrsTel_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CCDailyTelAddPrsTel_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CCDailyTelAddPrsTel_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CCDailyTelAddPrsTel_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass172_0
	{
		public AddTelToCmpAndPrsViewModel model;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__7;

		internal bool _003CCDailyTelAddPrsTel_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CCDailyTelAddPrsTel_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CCDailyTelAddPrsTel_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CCDailyTelAddPrsTel_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CCDailyTelAddPrsTel_003Eb__7(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass172_1
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass172_0 CS_0024_003C_003E8__locals1;

		internal bool _003CCDailyTelAddPrsTel_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCDailyTelAddPrsTel_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCDailyTelAddPrsTel_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCDailyTelAddPrsTel_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCDailyTelAddPrsTel_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCDailyTelAddPrsTel_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCDailyTelAddPrsTel_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCDailyTelAddPrsTel_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass189_7
	{
		public int fId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass218_0
	{
		public int userId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass219_0
	{
		public int userId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass268_0
	{
		public int knlgid;

		public CRMspknlgSelectKnowledgeTankByRollId_Result knlg;

		internal bool _003C_PartialKnlgInfo_003Eb__1(CRMspknlgSelectKnowledgeTankByRollId_Result c)
		{
			return c.KnowledgeTankId < knlgid;
		}

		internal bool _003C_PartialKnlgInfo_003Eb__2(CRMspknlgSelectKnowledgeTankByRollId_Result c)
		{
			return c.KnowledgeTankId > knlgid;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass274_0
	{
		public int ktid;

		public int currLangID;

		internal bool _003CCKnowledgeTankEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CCKnowledgeTankEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CCKnowledgeTankEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CCKnowledgeTankEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CCKnowledgeTankEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CCKnowledgeTankEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CCKnowledgeTankEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CCKnowledgeTankEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CCKnowledgeTankEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass275_1
	{
		public CrmKnowledgeTank KnlgTank;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass275_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass275_1 CS_0024_003C_003E8__locals1;

		internal bool _003CCKnowledgeTankEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCKnowledgeTankEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCKnowledgeTankEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCKnowledgeTankEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCKnowledgeTankEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCKnowledgeTankEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCKnowledgeTankEdit_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCKnowledgeTankEdit_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCKnowledgeTankEdit_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCKnowledgeTankEdit_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCKnowledgeTankEdit_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCKnowledgeTankEdit_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass317_0
	{
		public int id;

		public int currLangID;

		internal bool _003CUserTaskDefinePriorityEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CUserTaskDefinePriorityEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CUserTaskDefinePriorityEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CUserTaskDefinePriorityEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CUserTaskDefinePriorityEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CUserTaskDefinePriorityEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass318_0
	{
		public int defLangID;

		public UserTaskPrioritiesLanguageViewModel model;

		public Func<Languages, bool> _003C_003E9__4;

		internal bool _003CUserTaskDefinePriorityEdit_003Eb__0(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CUserTaskDefinePriorityEdit_003Eb__1(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CUserTaskDefinePriorityEdit_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CUserTaskDefinePriorityEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CUserTaskDefinePriorityEdit_003Eb__4(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass318_1
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass318_0 CS_0024_003C_003E8__locals1;

		internal bool _003CUserTaskDefinePriorityEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserTaskDefinePriorityEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserTaskDefinePriorityEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserTaskDefinePriorityEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserTaskDefinePriorityEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserTaskDefinePriorityEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserTaskDefinePriorityEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserTaskDefinePriorityEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass319_0
	{
		public int id;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass324_0
	{
		public int utid;

		public int currLangID;

		internal bool _003CCReminderPrivateTaskEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CCReminderPrivateTaskEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CCReminderPrivateTaskEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CCReminderPrivateTaskEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CCReminderPrivateTaskEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CCReminderPrivateTaskEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass325_0
	{
		public int defLangID;

		public UserTasksLanguageViewModel model;

		public Func<Languages, bool> _003C_003E9__4;

		internal bool _003CCReminderPrivateTaskEdit_003Eb__0(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CCReminderPrivateTaskEdit_003Eb__1(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CCReminderPrivateTaskEdit_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CCReminderPrivateTaskEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CCReminderPrivateTaskEdit_003Eb__4(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass325_1
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass325_0 CS_0024_003C_003E8__locals1;

		internal bool _003CCReminderPrivateTaskEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCReminderPrivateTaskEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCReminderPrivateTaskEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCReminderPrivateTaskEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCReminderPrivateTaskEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCReminderPrivateTaskEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCReminderPrivateTaskEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCReminderPrivateTaskEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	private CRMSpEntities db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private CRMSpIEntities dbI = new CRMSpIEntities();

	private CRMSpIIEntities _dbII = new CRMSpIIEntities();

	private CRMSpIIIEntities _dbIII = new CRMSpIIIEntities();

	private CRMSpIEntities _dbI = new CRMSpIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actReferUserCommission")]
	public ActionResult CReferUserCommission()
	{
		GetCommUser();
		base.ViewBag.CommissionKinds = SelectOrderCommissionKinds_SelectListItem();
		base.ViewBag.CommissionTypes = SelectOrderCommissionTypes_SelectListItem();
		return View();
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectUserForLinkedType_Result, SelectListItem>((IEnumerable<CRMspSelectUserForLinkedType_Result>)Enumerable.ToList<CRMspSelectUserForLinkedType_Result>((IEnumerable<CRMspSelectUserForLinkedType_Result>)db.CRMspSelectUserForLinkedType(UserLogin.CurrentUser.UserId, 21, lCID, result, result2)), (Func<CRMspSelectUserForLinkedType_Result, SelectListItem>)((CRMspSelectUserForLinkedType_Result item) => new SelectListItem
			{
				Text = item.UserName,
				Value = item.LinkedUserId.ToString()
			})));
			foreach (SelectListItem item in list)
			{
				if (item.Value.ToString() == UserLogin.CurrentUser.UserId.ToString())
				{
					item.Selected = true;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CommUserList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[HttpPost]
	[LoginAuthorize]
	public List<WSspSelectOrderCommissionKinds_Result> SelectOrderCommissionKinds()
	{
		List<WSspSelectOrderCommissionKinds_Result> result = new List<WSspSelectOrderCommissionKinds_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectOrderCommissionKinds_Result> list = Enumerable.ToList<WSspSelectOrderCommissionKinds_Result>((IEnumerable<WSspSelectOrderCommissionKinds_Result>)_dbII.WSspSelectOrderCommissionKinds(lCID, result2));
			if (list != null)
			{
				result = list;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public List<SelectListItem> SelectOrderCommissionKinds_SelectListItem()
	{
		return Enumerable.ToList<SelectListItem>(Enumerable.Select<WSspSelectOrderCommissionKinds_Result, SelectListItem>((IEnumerable<WSspSelectOrderCommissionKinds_Result>)SelectOrderCommissionKinds(), (Func<WSspSelectOrderCommissionKinds_Result, SelectListItem>)((WSspSelectOrderCommissionKinds_Result x) => new SelectListItem
		{
			Text = x.CommKindTitle,
			Value = x.OrderCommissionKindId.ToString()
		})));
	}

	[HttpPost]
	[LoginAuthorize]
	public List<WSspSelectOrderCommissionTypes_Result> SelectOrderCommissionTypes()
	{
		List<WSspSelectOrderCommissionTypes_Result> result = new List<WSspSelectOrderCommissionTypes_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectOrderCommissionTypes_Result> list = Enumerable.ToList<WSspSelectOrderCommissionTypes_Result>((IEnumerable<WSspSelectOrderCommissionTypes_Result>)_dbII.WSspSelectOrderCommissionTypes(lCID, result2));
			if (list != null)
			{
				result = list;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public List<SelectListItem> SelectOrderCommissionTypes_SelectListItem()
	{
		return Enumerable.ToList<SelectListItem>(Enumerable.Select<WSspSelectOrderCommissionTypes_Result, SelectListItem>((IEnumerable<WSspSelectOrderCommissionTypes_Result>)SelectOrderCommissionTypes(), (Func<WSspSelectOrderCommissionTypes_Result, SelectListItem>)((WSspSelectOrderCommissionTypes_Result x) => new SelectListItem
		{
			Text = x.CommTypeTitle,
			Value = x.OrderCommissionTypeId.ToString()
		})));
	}

	[HttpPost]
	[LoginAuthorize]
	public List<CRMspMainSearchWebSmart_Result> MainSearchWebSmart(string val = "")
	{
		List<CRMspMainSearchWebSmart_Result> result = new List<CRMspMainSearchWebSmart_Result>();
		try
		{
			if (!string.IsNullOrWhiteSpace(val))
			{
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
				List<CRMspMainSearchWebSmart_Result> list = Enumerable.ToList<CRMspMainSearchWebSmart_Result>((IEnumerable<CRMspMainSearchWebSmart_Result>)_dbI.CRMspMainSearchWebSmart(val, UserLogin.CurrentUser.UserId, 1, lCID, result2, "", result3));
				if (list != null)
				{
					result = list;
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string MainSearchWebSmartJs(string val = "")
	{
		return JsonConvert.SerializeObject(MainSearchWebSmart(val));
	}

	public List<WSspSelectUserOrderCommissionsViewModel> UserOrderCommissions(int crmUserId, bool isShowAllUser, int mode, string fromDate, string toDate, string crmUserIds = "", bool isShowSameOrder = false, int? companyId = null, int? commissionKindId = null, bool? isVerified = null, bool? isNotVerified = null, bool? isPaied = null, bool? isNotPaied = null, string effectiveFromDate = null, string effectiveToDate = null, string ordFromDate = null, string ordToDate = null, double? percentFrom = null, double? percentTo = null, bool? isPreVerified = null, bool? isNotPreVerified = null)
	{
		List<WSspSelectUserOrderCommissionsViewModel> list = new List<WSspSelectUserOrderCommissionsViewModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			string rptDate = now.ToString("yyyy/MM/dd HH:mm:ss");
			string rptDay = DateTimeClass.DefineDayeOfWeekFa(now.DayOfWeek.ToString());
			int userId = UserLogin.CurrentUser.UserId;
			if (isShowAllUser)
			{
				crmUserId = 0;
			}
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (!string.IsNullOrWhiteSpace(crmUserIds))
			{
				crmUserIds = crmUserIds.Replace("|", ",");
				if (crmUserIds.EndsWith(","))
				{
					crmUserIds = crmUserIds.TrimEnd(new char[1] { ',' });
				}
				if (crmUserIds.StartsWith(","))
				{
					crmUserIds = crmUserIds.TrimStart(new char[1] { ',' });
				}
			}
			if (string.IsNullOrWhiteSpace(crmUserIds) || crmUserId == 0)
			{
				crmUserIds = crmUserId.ToString();
			}
			if (!string.IsNullOrWhiteSpace(crmUserIds))
			{
				string[] array = crmUserIds.Split(new char[1] { ',' });
				if (array != null && array.Length == 1)
				{
					isShowSameOrder = false;
				}
			}
			DateTime? fDateTime = null;
			DateTime? tDateTime = null;
			if (!string.IsNullOrWhiteSpace(fromDate))
			{
				fromDate = fromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				fDateTime = lCID switch
				{
					1065 => DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00"), 
					1025 => DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None), 
					_ => DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None), 
				};
			}
			if (!string.IsNullOrWhiteSpace(toDate))
			{
				toDate = toDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				tDateTime = lCID switch
				{
					1065 => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59"), 
					1025 => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59", new CultureInfo("ar-SA"), DateTimeStyles.None), 
					_ => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None), 
				};
			}
			DateTime? effectiveFromDate2 = null;
			DateTime? effectiveToDate2 = null;
			if (!string.IsNullOrWhiteSpace(effectiveFromDate))
			{
				effectiveFromDate = effectiveFromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				effectiveFromDate2 = lCID switch
				{
					1065 => DateTime.Parse(PersianDate.GetFormatetdDate(effectiveFromDate) + " 00:00:00"), 
					1025 => DateTime.Parse(PersianDate.GetFormatetdDate(effectiveFromDate) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None), 
					_ => DateTime.Parse(PersianDate.GetFormatetdDate(effectiveFromDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None), 
				};
			}
			if (!string.IsNullOrWhiteSpace(effectiveToDate))
			{
				effectiveToDate = effectiveToDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				effectiveToDate2 = lCID switch
				{
					1065 => DateTime.Parse(PersianDate.GetFormatetdDate(effectiveToDate) + " 23:59:59"), 
					1025 => DateTime.Parse(PersianDate.GetFormatetdDate(effectiveToDate) + " 23:59:59", new CultureInfo("ar-SA"), DateTimeStyles.None), 
					_ => DateTime.Parse(PersianDate.GetFormatetdDate(effectiveToDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None), 
				};
			}
			DateTime? ordFromDate2 = null;
			DateTime? ordToDate2 = null;
			if (!string.IsNullOrWhiteSpace(ordFromDate))
			{
				ordFromDate = ordFromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				ordFromDate2 = lCID switch
				{
					1065 => DateTime.Parse(PersianDate.GetFormatetdDate(ordFromDate) + " 00:00:00"), 
					1025 => DateTime.Parse(PersianDate.GetFormatetdDate(ordFromDate) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None), 
					_ => DateTime.Parse(PersianDate.GetFormatetdDate(ordFromDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None), 
				};
			}
			if (!string.IsNullOrWhiteSpace(ordToDate))
			{
				ordToDate = ordToDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				ordToDate2 = lCID switch
				{
					1065 => DateTime.Parse(PersianDate.GetFormatetdDate(ordToDate) + " 23:59:59"), 
					1025 => DateTime.Parse(PersianDate.GetFormatetdDate(ordToDate) + " 23:59:59", new CultureInfo("ar-SA"), DateTimeStyles.None), 
					_ => DateTime.Parse(PersianDate.GetFormatetdDate(ordToDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None), 
				};
			}
			foreach (WSspSelectUserOrderCommissions_Result item in Enumerable.ToList<WSspSelectUserOrderCommissions_Result>((IEnumerable<WSspSelectUserOrderCommissions_Result>)db.WSspSelectUserOrderCommissions(userId, rptDate, rptDay, crmUserId, fDateTime, tDateTime, lCID, result, crmUserIds, isShowSameOrder, commissionKindId, companyId, isVerified, isNotVerified, isPaied, isNotPaied, effectiveFromDate2, effectiveToDate2, ordFromDate2, ordToDate2, percentFrom, percentTo, result2, isPreVerified, isNotPreVerified)))
			{
				_ = item.CommDateTime;
				item.CommDatePersian = DateTime.Parse(item.CommDateTime.ToString()).ToString("yyyy/MM/dd HH:mm:ss");
				if (item.CommEffectiveDateTime.HasValue)
				{
					item.CommEffectiveDatePersian = DateTime.Parse(item.CommEffectiveDateTime.ToString()).ToString("yyyy/MM/dd HH:mm:ss");
				}
				else if (!string.IsNullOrEmpty(item.CommEffectiveDatePersian))
				{
					item.CommEffectiveDatePersian = PersianDate.GetFormatetdDate(item.CommEffectiveDatePersian);
				}
				if (item.CommVerifiedDateTime.HasValue)
				{
					item.CommVerifiedDatePersian = DateTime.Parse(item.CommVerifiedDateTime.ToString()).ToString("yyyy/MM/dd HH:mm:ss");
				}
				else if (!string.IsNullOrEmpty(item.CommVerifiedDatePersian))
				{
					item.CommVerifiedDatePersian = PersianDate.GetFormatetdDate(item.CommVerifiedDatePersian);
				}
				if (item.CommIsPaidDateTime.HasValue)
				{
					item.CommIsPaidDatePersian = DateTime.Parse(item.CommIsPaidDateTime.ToString()).ToString("yyyy/MM/dd HH:mm:ss");
				}
				else if (!string.IsNullOrEmpty(item.CommIsPaidDatePersian))
				{
					item.CommIsPaidDatePersian = PersianDate.GetFormatetdDate(item.CommIsPaidDatePersian);
				}
				_ = item.FirstRegisterDate;
				item.FirstRegisterDatePersian = DateTime.Parse(item.FirstRegisterDate.ToString()).ToString("yyyy/MM/dd HH:mm:ss");
				_ = item.RegisterDate;
				item.RegisterDatePersian = DateTime.Parse(item.RegisterDate.ToString()).ToString("yyyy/MM/dd HH:mm:ss");
				if (item.ordDateTime.HasValue)
				{
					item.OrdDate = DateTime.Parse(item.ordDateTime.ToString()).ToString("yyyy/MM/dd HH:mm:ss");
				}
				else if (!string.IsNullOrEmpty(item.OrdDate))
				{
					item.OrdDate = PersianDate.GetFormatetdDate(item.OrdDate);
				}
				item.CommIsVerified = item.CommIsVerified.HasValue && item.CommIsVerified != false;
				item.CommIsPaid = item.CommIsPaid.HasValue && item.CommIsPaid != false;
				string text = item.CommTypeCmp ?? "";
				if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(item.CommTypePrs))
				{
					text += " ";
				}
				if (!string.IsNullOrWhiteSpace(item.CommTypePrs))
				{
					text = text + "(" + item.CommTypePrs + ")";
				}
				item.CommIsPreVerified = item.CommIsPreVerified.GetValueOrDefault();
				item.CommPreVerifiedDatePersian = (item.CommPreVerifiedDate.HasValue ? item.CommPreVerifiedDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
				WSspSelectUserOrderCommissionsViewModel wSspSelectUserOrderCommissionsViewModel = new WSspSelectUserOrderCommissionsViewModel();
				wSspSelectUserOrderCommissionsViewModel.CommUser = item.CommUser;
				wSspSelectUserOrderCommissionsViewModel.CmpReferUser = item.CmpReferUser;
				wSspSelectUserOrderCommissionsViewModel.CmpProject = item.CmpProject;
				wSspSelectUserOrderCommissionsViewModel.ordProjectId = item.ordProjectId;
				wSspSelectUserOrderCommissionsViewModel.CmpCity = item.CmpCity;
				wSspSelectUserOrderCommissionsViewModel.cmpActivityType = item.cmpActivityType;
				wSspSelectUserOrderCommissionsViewModel.cmpGroup = item.cmpGroup;
				wSspSelectUserOrderCommissionsViewModel.cmpSubGroup = item.cmpSubGroup;
				wSspSelectUserOrderCommissionsViewModel.cmpGroupII = item.cmpGroupII;
				wSspSelectUserOrderCommissionsViewModel.cmpGroupIII = item.cmpGroupIII;
				wSspSelectUserOrderCommissionsViewModel.cmpGroupIV = item.cmpGroupIV;
				wSspSelectUserOrderCommissionsViewModel.cmpType = item.cmpType;
				wSspSelectUserOrderCommissionsViewModel.cmpPresentation = item.cmpPresentation;
				wSspSelectUserOrderCommissionsViewModel.cmpWebSite = item.cmpWebSite;
				wSspSelectUserOrderCommissionsViewModel.cmpSpecialPoint = item.cmpSpecialPoint;
				wSspSelectUserOrderCommissionsViewModel.cmpDescription = item.cmpDescription;
				wSspSelectUserOrderCommissionsViewModel.cmpFirstRegisterUser = item.cmpFirstRegisterUser;
				wSspSelectUserOrderCommissionsViewModel.cmpFirstRegisterDate = item.cmpFirstRegisterDate;
				wSspSelectUserOrderCommissionsViewModel.cmpEconomicCode = item.cmpEconomicCode;
				wSspSelectUserOrderCommissionsViewModel.cmpEffectiveDateTime = item.cmpEffectiveDateTime;
				wSspSelectUserOrderCommissionsViewModel.OrdCmp = item.OrdCmp;
				wSspSelectUserOrderCommissionsViewModel.OrdPerson = item.OrdPerson;
				wSspSelectUserOrderCommissionsViewModel.OrderOpr = item.OrderOpr;
				wSspSelectUserOrderCommissionsViewModel.OrderOprID = item.OrderOprID;
				wSspSelectUserOrderCommissionsViewModel.OrdDate = item.OrdDate;
				wSspSelectUserOrderCommissionsViewModel.ordDateTime = item.ordDateTime;
				wSspSelectUserOrderCommissionsViewModel.ordItemSumPrice = item.ordItemSumPrice;
				wSspSelectUserOrderCommissionsViewModel.ordItemSumDiscount = item.ordItemSumDiscount;
				wSspSelectUserOrderCommissionsViewModel.ordItemsAmount = item.ordItemsAmount;
				wSspSelectUserOrderCommissionsViewModel.ordDiscount = item.ordDiscount;
				wSspSelectUserOrderCommissionsViewModel.ordSumAmount = item.ordSumAmount;
				wSspSelectUserOrderCommissionsViewModel.ordAllDiscount = item.ordAllDiscount;
				wSspSelectUserOrderCommissionsViewModel.ordAllDiscountPercent = item.ordAllDiscountPercent;
				wSspSelectUserOrderCommissionsViewModel.ordTax = item.ordTax;
				wSspSelectUserOrderCommissionsViewModel.ordTotalAmount = item.ordTotalAmount;
				wSspSelectUserOrderCommissionsViewModel.ordPayAmount = item.ordPayAmount;
				wSspSelectUserOrderCommissionsViewModel.ordPayDocDetails = item.ordPayDocDetails;
				wSspSelectUserOrderCommissionsViewModel.ordPayRemain = item.ordPayRemain;
				wSspSelectUserOrderCommissionsViewModel.YearMonthCommDate = item.YearMonthCommDate;
				wSspSelectUserOrderCommissionsViewModel.CommDatePersianFN = item.CommDatePersianFN;
				wSspSelectUserOrderCommissionsViewModel.OrderCommissionId = item.OrderCommissionId;
				wSspSelectUserOrderCommissionsViewModel.CommDateTime = item.CommDateTime;
				wSspSelectUserOrderCommissionsViewModel.CommDatePersian = item.CommDatePersian;
				wSspSelectUserOrderCommissionsViewModel.CommOrderId = item.CommOrderId;
				wSspSelectUserOrderCommissionsViewModel.CommCmpId = item.CommCmpId;
				wSspSelectUserOrderCommissionsViewModel.CommUserId = item.CommUserId;
				wSspSelectUserOrderCommissionsViewModel.CommBaseAmountDec = item.CommBaseAmountDec;
				wSspSelectUserOrderCommissionsViewModel.CommBaseAmountDecDesc = item.CommBaseAmountDecDesc;
				wSspSelectUserOrderCommissionsViewModel.CommBaseAmount = item.CommBaseAmount;
				wSspSelectUserOrderCommissionsViewModel.CommBaseAmountFormated = item.CommBaseAmountFormated;
				wSspSelectUserOrderCommissionsViewModel.CommRate = item.CommRate;
				wSspSelectUserOrderCommissionsViewModel.CommRateDesc = item.CommRateDesc;
				wSspSelectUserOrderCommissionsViewModel.CommAmount = item.CommAmount;
				wSspSelectUserOrderCommissionsViewModel.CommAmountFormated = item.CommAmountFormated;
				wSspSelectUserOrderCommissionsViewModel.CommEffectiveDateTime = item.CommEffectiveDateTime;
				wSspSelectUserOrderCommissionsViewModel.CommEffectiveDatePersian = item.CommEffectiveDatePersian;
				wSspSelectUserOrderCommissionsViewModel.CommPayTypeId = item.CommPayTypeId;
				wSspSelectUserOrderCommissionsViewModel.CommPayType = item.CommPayType;
				wSspSelectUserOrderCommissionsViewModel.CommStatusId = item.CommStatusId;
				wSspSelectUserOrderCommissionsViewModel.CommDesc = item.CommDesc;
				wSspSelectUserOrderCommissionsViewModel.CommIsVerified = item.CommIsVerified;
				wSspSelectUserOrderCommissionsViewModel.CommVerifierUserId = item.CommVerifierUserId;
				wSspSelectUserOrderCommissionsViewModel.CommVerifierUser = item.CommVerifierUser;
				wSspSelectUserOrderCommissionsViewModel.CommVerifiedDateTime = item.CommVerifiedDateTime;
				wSspSelectUserOrderCommissionsViewModel.CommVerifiedDatePersian = item.CommVerifiedDatePersian;
				wSspSelectUserOrderCommissionsViewModel.FirstRegisterUserId = item.FirstRegisterUserId;
				wSspSelectUserOrderCommissionsViewModel.FirstRegisterUser = item.FirstRegisterUser;
				wSspSelectUserOrderCommissionsViewModel.FirstRegisterDatePersian = item.FirstRegisterDatePersian;
				wSspSelectUserOrderCommissionsViewModel.FirstRegisterDate = item.FirstRegisterDate;
				wSspSelectUserOrderCommissionsViewModel.RegisterUser = item.RegisterUser;
				wSspSelectUserOrderCommissionsViewModel.RegisterDatePersian = item.RegisterDatePersian;
				wSspSelectUserOrderCommissionsViewModel.RegisterDate = item.RegisterDate;
				wSspSelectUserOrderCommissionsViewModel.CommIsPaid = item.CommIsPaid;
				wSspSelectUserOrderCommissionsViewModel.CommIsPaidDateTime = item.CommIsPaidDateTime;
				wSspSelectUserOrderCommissionsViewModel.CommIsPaidDatePersian = item.CommIsPaidDatePersian;
				wSspSelectUserOrderCommissionsViewModel.CommIsPaidPayRollUserCycleId = item.CommIsPaidPayRollUserCycleId;
				wSspSelectUserOrderCommissionsViewModel.CommIsPaidUserId = item.CommIsPaidUserId;
				wSspSelectUserOrderCommissionsViewModel.CommIsPaidUser = item.CommIsPaidUser;
				wSspSelectUserOrderCommissionsViewModel.PaidPayRollUserCycle = item.PaidPayRollUserCycle;
				wSspSelectUserOrderCommissionsViewModel.rptUser = item.rptUser;
				wSspSelectUserOrderCommissionsViewModel.rptDate = item.rptDate;
				wSspSelectUserOrderCommissionsViewModel.rptDay = item.rptDay;
				wSspSelectUserOrderCommissionsViewModel.SUMCommAmount = item.SUMCommAmount;
				wSspSelectUserOrderCommissionsViewModel.SUMordSumAmount = item.SUMordSumAmount;
				if (item.cmpFirstRegisterDate.HasValue)
				{
					wSspSelectUserOrderCommissionsViewModel.cmpFirstRegisterDatePersian = DateTime.Parse(item.cmpFirstRegisterDate.ToString()).ToString("yyyy/MM/dd HH:mm:ss");
				}
				if (item.cmpEffectiveDateTime.HasValue)
				{
					wSspSelectUserOrderCommissionsViewModel.cmpEffectiveDatePersian = DateTime.Parse(item.cmpEffectiveDateTime.ToString()).ToString("yyyy/MM/dd HH:mm:ss");
				}
				if (!string.IsNullOrEmpty(wSspSelectUserOrderCommissionsViewModel.ordAllDiscountPercent) && wSspSelectUserOrderCommissionsViewModel.ordAllDiscountPercent == "0.000000")
				{
					wSspSelectUserOrderCommissionsViewModel.ordAllDiscountPercent = "0.00";
				}
				wSspSelectUserOrderCommissionsViewModel.ordNumber = item.ordNumber;
				wSspSelectUserOrderCommissionsViewModel.ordDailyCounter = item.ordDailyCounter;
				wSspSelectUserOrderCommissionsViewModel.ordNumRef = item.ordNumRef;
				wSspSelectUserOrderCommissionsViewModel.ordIProductNames = item.ordIProductNames;
				wSspSelectUserOrderCommissionsViewModel.RowNumber = item.RowNumber;
				wSspSelectUserOrderCommissionsViewModel.CommUserIdI = item.CommUserIdI;
				wSspSelectUserOrderCommissionsViewModel.CommUserI = item.CommUserI;
				wSspSelectUserOrderCommissionsViewModel.CommAmountI = item.CommAmountI;
				wSspSelectUserOrderCommissionsViewModel.CommUserIdII = item.CommUserIdII;
				wSspSelectUserOrderCommissionsViewModel.CommUserII = item.CommUserII;
				wSspSelectUserOrderCommissionsViewModel.CommAmountII = item.CommAmountII;
				wSspSelectUserOrderCommissionsViewModel.CommUserIdIII = item.CommUserIdIII;
				wSspSelectUserOrderCommissionsViewModel.CommUserIII = item.CommUserIII;
				wSspSelectUserOrderCommissionsViewModel.CommAmountIII = item.CommAmountIII;
				wSspSelectUserOrderCommissionsViewModel.CommUserIdIByPayType = item.CommUserIdIByPayType;
				wSspSelectUserOrderCommissionsViewModel.CommUserIByPayType = item.CommUserIByPayType;
				wSspSelectUserOrderCommissionsViewModel.CommAmountIByPayType = item.CommAmountIByPayType;
				wSspSelectUserOrderCommissionsViewModel.CommUserIdIIByPayType = item.CommUserIdIIByPayType;
				wSspSelectUserOrderCommissionsViewModel.CommUserIIByPayType = item.CommUserIIByPayType;
				wSspSelectUserOrderCommissionsViewModel.CommAmountIIByPayType = item.CommAmountIIByPayType;
				wSspSelectUserOrderCommissionsViewModel.CommUserIdIIIByPayType = item.CommUserIdIIIByPayType;
				wSspSelectUserOrderCommissionsViewModel.CommUserIIIByPayType = item.CommUserIIIByPayType;
				wSspSelectUserOrderCommissionsViewModel.CommAmountIIIByPayType = item.CommAmountIIIByPayType;
				wSspSelectUserOrderCommissionsViewModel.SUMCommBaseAmountDecInOrd = item.SUMCommBaseAmountDecInOrd;
				wSspSelectUserOrderCommissionsViewModel.SUMCommAmountInOrd = item.SUMCommAmountInOrd;
				wSspSelectUserOrderCommissionsViewModel.SUMCommBaseAmountDecInOrdByTerm = item.SUMCommBaseAmountDecInOrdByTerm;
				wSspSelectUserOrderCommissionsViewModel.SUMCommAmountInOrdByTerm = item.SUMCommAmountInOrdByTerm;
				wSspSelectUserOrderCommissionsViewModel.CommKindId = item.CommKindId;
				wSspSelectUserOrderCommissionsViewModel.CommKindTitle = item.CommKindTitle;
				wSspSelectUserOrderCommissionsViewModel.CommTypeId = item.CommTypeId;
				wSspSelectUserOrderCommissionsViewModel.CommTypeTitle = item.CommTypeTitle;
				wSspSelectUserOrderCommissionsViewModel.CommTypeCmpId = item.CommTypeCmpId;
				wSspSelectUserOrderCommissionsViewModel.CommTypeCmp = item.CommTypeCmp;
				wSspSelectUserOrderCommissionsViewModel.CommTypePrsId = item.CommTypePrsId;
				wSspSelectUserOrderCommissionsViewModel.CommTypePrs = item.CommTypePrs;
				wSspSelectUserOrderCommissionsViewModel.CommTypeCmpFullName = text;
				wSspSelectUserOrderCommissionsViewModel.CommIsPreVerified = item.CommIsPreVerified;
				wSspSelectUserOrderCommissionsViewModel.CommPreVerifierUserId = item.CommPreVerifierUserId;
				wSspSelectUserOrderCommissionsViewModel.CommPreVerifierUser = item.CommPreVerifierUser;
				wSspSelectUserOrderCommissionsViewModel.CommPreVerifiedDate = item.CommPreVerifiedDate;
				wSspSelectUserOrderCommissionsViewModel.CommPreVerifiedDatePersian = item.CommPreVerifiedDatePersian;
				list.Add(wSspSelectUserOrderCommissionsViewModel);
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

	public ActionResult Commission_Read([DataSourceRequest] DataSourceRequest request, int crmUserId, bool isShowAllUser, int mode, string fromDate, string toDate, string crmUserIds = "", bool isShowSameOrder = false, int? companyId = null, int? commissionKindId = null, bool? isVerified = null, bool? isNotVerified = null, bool? isPaied = null, bool? isNotPaied = null, string effectiveFromDate = null, string effectiveToDate = null, string ordFromDate = null, string ordToDate = null, double? percentFrom = null, double? percentTo = null, bool? isPreVerified = null, bool? isNotPreVerified = null)
	{
		List<WSspSelectUserOrderCommissionsViewModel> enumerable = new List<WSspSelectUserOrderCommissionsViewModel>();
		try
		{
			enumerable = UserOrderCommissions(crmUserId, isShowAllUser, mode, fromDate, toDate, crmUserIds, isShowSameOrder, companyId, commissionKindId, isVerified, isNotVerified, isPaied, isNotPaied, effectiveFromDate, effectiveToDate, ordFromDate, ordToDate, percentFrom, percentTo, isPreVerified, isNotPreVerified);
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

	[AjaxOnly]
	public string PayCommManual(int id)
	{
		string result = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("FramUserCommission", "actPayCommManual", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			int userId = currentUser.UserId;
			DateTime now = DateTime.Now;
			string commIsPaidDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			db.WSspPayOrderCommissionManual(id, userId, now, commIsPaidDatePersian);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.frmErrorMessage;
		}
		return result;
	}

	[AjaxOnly]
	public string ExitPayCommManual(int id)
	{
		string result = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("FramUserCommission", "actExitPayCommManual", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			db.WSspPayExitOrderCommissionManual(id, userId, appType);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.frmErrorMessage;
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "FramUserCommission", ActionName = "actPayCommSystemic")]
	public ActionResult CReferUserCommissionPayCommSystemic(int crmUserId, string ordCommIds)
	{
		base.ViewBag.OrdCommIds = ordCommIds;
		base.ViewBag.CrmUserId = crmUserId;
		return View();
	}

	[AjaxOnly]
	public JsonResult GetPayOrderCommissionPayRollUserCycle(int crmUserId, string month, string year, string txtSearch)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		ReferUserCommissionPayRollUserCycleListViewModel referUserCommissionPayRollUserCycleListViewModel = new ReferUserCommissionPayRollUserCycleListViewModel();
		referUserCommissionPayRollUserCycleListViewModel.PayRollUserCycles = new List<WSspSelectPayOrderCommissionPayRollUserCycle_Result>();
		referUserCommissionPayRollUserCycleListViewModel.IsFind = false;
		txtSearch = (string.IsNullOrWhiteSpace(txtSearch) ? "" : txtSearch);
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (!string.IsNullOrWhiteSpace(month) && !string.IsNullOrWhiteSpace(year) && crmUserId != 0)
			{
				int num = 0;
				int num2 = 0;
				try
				{
					string text = year + "/" + month + "/01";
					DateTime dateTime = default(DateTime);
					string text2 = "";
					text2 = PersianDate.GetFormatetdDate(text.Replace("/", ""));
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text2 + " 00:00:00", new PersianCulture());
						num = int.Parse(dateTime.ToString("MM", new PersianCulture()));
						num2 = int.Parse(dateTime.ToString("yyyy", new PersianCulture()));
						break;
					case 1025:
						dateTime = DateTime.Parse(text2 + " 00:00:00", new CultureInfo("ar-SA"));
						num = int.Parse(dateTime.ToString("MM", new CultureInfo("ar-SA")));
						num2 = int.Parse(dateTime.ToString("yyyy", new CultureInfo("ar-SA")));
						break;
					default:
						dateTime = DateTime.Parse(text2 + " 00:00:00", new CultureInfo("en-US"));
						num = int.Parse(dateTime.ToString("MM", new CultureInfo("en-US")));
						num2 = int.Parse(dateTime.ToString("yyyy", new CultureInfo("en-US")));
						break;
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					referUserCommissionPayRollUserCycleListViewModel.Message = string.Format(Messages.ErrorInFormat, Labels.CReferUserCommissionPayCommSystemicYear + " , " + Labels.CReferUserCommissionPayCommSystemicMonth);
				}
				if (!string.IsNullOrWhiteSpace(num2.ToString() + num) && num > 0 && num2 > 0)
				{
					_ = Labels.PayRollItemKindAdditive;
					_ = Labels.PayRollItemKindReduction;
					_ = UserLogin.CurrentUser.UserId;
					referUserCommissionPayRollUserCycleListViewModel.PayRollUserCycles = Enumerable.ToList<WSspSelectPayOrderCommissionPayRollUserCycle_Result>((IEnumerable<WSspSelectPayOrderCommissionPayRollUserCycle_Result>)_dbI.WSspSelectPayOrderCommissionPayRollUserCycle(num, num2, txtSearch, crmUserId, UserLogin.CurrentUser.UserId, lCID, result, result2));
					if (referUserCommissionPayRollUserCycleListViewModel.PayRollUserCycles != null && Enumerable.Any<WSspSelectPayOrderCommissionPayRollUserCycle_Result>((IEnumerable<WSspSelectPayOrderCommissionPayRollUserCycle_Result>)referUserCommissionPayRollUserCycleListViewModel.PayRollUserCycles))
					{
						referUserCommissionPayRollUserCycleListViewModel.IsFind = true;
						foreach (WSspSelectPayOrderCommissionPayRollUserCycle_Result payRollUserCycle in referUserCommissionPayRollUserCycleListViewModel.PayRollUserCycles)
						{
							_ = payRollUserCycle.CycleDate;
							payRollUserCycle.CycleDatePersian = payRollUserCycle.CycleDate.ToString("yyyy/MM/dd");
							payRollUserCycle.CycleTitle += ((!string.IsNullOrWhiteSpace(payRollUserCycle.CycleDatePersian)) ? (" (" + payRollUserCycle.CycleDatePersian + ")") : "");
						}
					}
					else
					{
						referUserCommissionPayRollUserCycleListViewModel.PayRollUserCycles = new List<WSspSelectPayOrderCommissionPayRollUserCycle_Result>();
						referUserCommissionPayRollUserCycleListViewModel.Message = Messages.msgErrorPayrollNotRegisteredTheMonth;
					}
				}
				else
				{
					referUserCommissionPayRollUserCycleListViewModel.Message = string.Format(Messages.ErrorInFormat, Labels.CReferUserCommissionPayCommSystemicYear + " , " + Labels.CReferUserCommissionPayCommSystemicMonth);
				}
			}
			else if (crmUserId == 0 || crmUserId == -1)
			{
				referUserCommissionPayRollUserCycleListViewModel.Message = Messages.msgErrorNotSelectedUser;
			}
			else if (string.IsNullOrWhiteSpace(month))
			{
				referUserCommissionPayRollUserCycleListViewModel.Message = string.Format(Messages.msgErrorIsNotSelectedItem, Labels.CReferUserCommissionPayCommSystemicMonth);
			}
			else if (string.IsNullOrWhiteSpace(year))
			{
				referUserCommissionPayRollUserCycleListViewModel.Message = string.Format(Messages.msgErrorIsNotEnteredItem, Labels.CReferUserCommissionPayCommSystemicYear);
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			referUserCommissionPayRollUserCycleListViewModel.Message = Messages.msgErrorRunFunction + "<br />" + ex.Message;
		}
		JsonResult jsonResult = Json(referUserCommissionPayRollUserCycleListViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult ActPayCommSystemic(int cycleId, int itemValueId, string ordCommIds)
	{
		string data = "";
		string text = "";
		CommonResultStatusViewModel status = CommonResultStatusViewModel.Success;
		CommonResultViewModel<string> data2;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (!UserLogin.IsUserAccess("FramUserCommission", "actPayCommSystemic"))
			{
				data = "";
				text = Messages.NotAccessToPage;
				status = CommonResultStatusViewModel.Error;
				data2 = new CommonResultViewModel<string>
				{
					Data = data,
					Message = text,
					Status = status
				};
				return Json(data2, JsonRequestBehavior.AllowGet);
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string text2 = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short value3 = short.Parse(Financial.Get().Id.ToString());
			int userId = UserLogin.CurrentUser.UserId;
			int num = 0;
			if (cycleId == 0)
			{
				num++;
				text = text + Messages.msgErrorNotSelectedItem + "<br>";
			}
			if (itemValueId == 0)
			{
				num++;
				text = text + Messages.msgErrorNotSelectedItem + "<br>";
			}
			if (!string.IsNullOrWhiteSpace(ordCommIds))
			{
				if (ordCommIds.StartsWith(","))
				{
					ordCommIds = ordCommIds.TrimStart(new char[1] { ',' });
				}
				if (ordCommIds.EndsWith(","))
				{
					ordCommIds = ordCommIds.TrimEnd(new char[1] { ',' });
				}
			}
			if (string.IsNullOrWhiteSpace(ordCommIds))
			{
				num++;
				text = text + Messages.msgErrorNotSelectedItem + "<br>";
			}
			if (num == 0)
			{
				ObjectParameter objectParameter = new ObjectParameter("resultId", typeof(int));
				_dbI.WSspPayOrderCommissionSystemic(userId, value, text2, cycleId, itemValueId, ordCommIds, userId, value2, value3, value, text2, appType, objectParameter);
				int result2 = 0;
				if (objectParameter != null && objectParameter.Value != null)
				{
					int.TryParse(objectParameter.Value.ToString(), out result2);
				}
				if (result2 == 0)
				{
					data = "";
					text = Messages.msgErrorRunFunction;
					status = CommonResultStatusViewModel.Error;
				}
				else if (result2 == -1)
				{
					data = "";
					text = Messages.msgErrorInCalculation;
					status = CommonResultStatusViewModel.Error;
				}
				else if (result2 > 0)
				{
					data = "";
					text = Messages.msgSuccessAction;
					status = CommonResultStatusViewModel.Success;
				}
			}
			else
			{
				data = "";
				if (string.IsNullOrWhiteSpace(text))
				{
					text = Messages.msgErrorRunFunction;
				}
				status = CommonResultStatusViewModel.Error;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			data = "";
			text = Messages.msgErrorRunFunction + " " + ex.Message;
			status = CommonResultStatusViewModel.Error;
		}
		data2 = new CommonResultViewModel<string>
		{
			Data = data,
			Message = text,
			Status = status
		};
		return Json(data2, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public string VerifyComm(int id)
	{
		string result = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("FramUserCommission", "actVerifyComm", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			int userId = currentUser.UserId;
			DateTime now = DateTime.Now;
			string verifiedDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			db.WSspOrderCommissionVerify(id, userId, now, verifiedDatePersian);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.frmErrorMessage;
		}
		return result;
	}

	[AjaxOnly]
	public string ExitVerifyComm(int id)
	{
		string result = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("FramUserCommission", "actExitVerifyComm", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			db.WSspOrderCommissionVerifyExit(id);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.frmErrorMessage;
		}
		return result;
	}

	[AjaxOnly]
	public string VerifyCommMulti(string commIds)
	{
		string result = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("FramUserCommission", "actVerifyCommMulti", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			int userId = currentUser.UserId;
			DateTime now = DateTime.Now;
			string verifiedDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			if (!string.IsNullOrWhiteSpace(commIds))
			{
				if (commIds.StartsWith(","))
				{
					commIds = commIds.TrimStart(new char[1] { ',' });
				}
				if (commIds.EndsWith(","))
				{
					commIds = commIds.TrimEnd(new char[1] { ',' });
				}
			}
			_dbI.WSspOrderCommissionVerifyMulti(commIds, userId, now, verifiedDatePersian);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.frmErrorMessage;
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "FramUserCommission", ActionName = "actShowFiles")]
	public ActionResult CReferUserCommissionShowFiles(int cmpId)
	{
		string text = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(cmpId);
			if (companyById != null)
			{
				text = companyById.CompanyName ?? "";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CmpId = cmpId;
		base.ViewBag.CmpName = text;
		return View();
	}

	[AjaxOnly]
	public JsonResult CReferUserCommissionGetFiles(int cmpId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectFilesDirectory_Result> list = new List<CRMspSelectFilesDirectory_Result>();
		try
		{
			if (cmpId != 0)
			{
				list = Files.SelectFilesDirectory(cmpId.ToString(), "0", "0", "0", "0", "0", "0", true);
				if (list != null && Enumerable.Any<CRMspSelectFilesDirectory_Result>((IEnumerable<CRMspSelectFilesDirectory_Result>)list))
				{
					list = Enumerable.ToList<CRMspSelectFilesDirectory_Result>((IEnumerable<CRMspSelectFilesDirectory_Result>)Enumerable.OrderBy<CRMspSelectFilesDirectory_Result, int?>((IEnumerable<CRMspSelectFilesDirectory_Result>)list, (Func<CRMspSelectFilesDirectory_Result, int?>)((CRMspSelectFilesDirectory_Result c) => c.FileDirectoryTypeOprId)));
				}
				if (list != null && Enumerable.Any<CRMspSelectFilesDirectory_Result>((IEnumerable<CRMspSelectFilesDirectory_Result>)list))
				{
					foreach (CRMspSelectFilesDirectory_Result item in list)
					{
						item.DocDate = (item.DocDateTime.HasValue ? item.DocDateTime.Value.ToString("yyyy/MM/dd - HH:mm:ss - dddd") : "");
					}
				}
				else
				{
					list = new List<CRMspSelectFilesDirectory_Result>();
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

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actcUserLocation")]
	public ActionResult CUserLocation()
	{
		return View();
	}

	[AjaxOnly]
	public ActionResult _PartialCUserLocation()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			List<CRMspUserTreeLocationCartable_Result> list = Enumerable.ToList<CRMspUserTreeLocationCartable_Result>((IEnumerable<CRMspUserTreeLocationCartable_Result>)db.CRMspUserTreeLocationCartable(UserLogin.CurrentUser.UserId, 19, Labels.AllUsers, lCID, result));
			List<TreeViewItemModel> list2 = new List<TreeViewItemModel>
			{
				new TreeViewItemModel
				{
					HtmlAttributes = 
					{
						new KeyValuePair<string, string>("accesskey", "-1|-1")
					},
					Id = "-1|-1",
					Text = Labels.Empty,
					ImageUrl = "",
					Items = null
				}
			};
			foreach (CRMspUserTreeLocationCartable_Result item in list)
			{
				TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
				treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.RootId + "|" + item.KeyId));
				treeViewItemModel.Id = item.RootId + "|" + item.KeyId;
				treeViewItemModel.Text = item.KeyName;
				treeViewItemModel.ImageUrl = "";
				treeViewItemModel.Items = null;
				list2.Add(treeViewItemModel);
			}
			base.ViewBag.DashboardTree = list2;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView();
	}

	[AjaxOnly]
	public JsonResult GetUsersLocation(int userId, int lastHour = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<UserLocationViewModel> list = new List<UserLocationViewModel>();
		try
		{
			BaseInfo baseInfo = new BaseInfo();
			List<CRMspResultsUserLocationCartable_Result> list2 = new List<CRMspResultsUserLocationCartable_Result>();
			list2 = ((userId != -1) ? Enumerable.ToList<CRMspResultsUserLocationCartable_Result>(Enumerable.Where<CRMspResultsUserLocationCartable_Result>((IEnumerable<CRMspResultsUserLocationCartable_Result>)db.CRMspResultsUserLocationCartable(UserLogin.CurrentUser.UserId, lastHour, lCID, result), (Func<CRMspResultsUserLocationCartable_Result, bool>)((CRMspResultsUserLocationCartable_Result m) => m.UserId == userId))) : Enumerable.ToList<CRMspResultsUserLocationCartable_Result>((IEnumerable<CRMspResultsUserLocationCartable_Result>)db.CRMspResultsUserLocationCartable(UserLogin.CurrentUser.UserId, lastHour, lCID, result)));
			foreach (CRMspResultsUserLocationCartable_Result item2 in list2)
			{
				UserLocationViewModel item = new UserLocationViewModel
				{
					UserId = item2.UserId,
					FullName = (item2.FullName ?? ""),
					RollName = ((!string.IsNullOrEmpty(item2.RollName)) ? $" ({item2.RollName})" : ""),
					CoordinateLatitude = ((!string.IsNullOrEmpty(item2.CoordinateLatitude)) ? item2.CoordinateLatitude : ""),
					CoordinateLongitude = ((!string.IsNullOrEmpty(item2.CoordinateLongitude)) ? item2.CoordinateLongitude : ""),
					CoordinateLastDate = (item2.CoordinateLastDate.HasValue ? baseInfo.En2FaNumber(item2.CoordinateLastDate.Value.ToString("yyyy/MM/dd")) : ""),
					CoordinateLastTime = (item2.CoordinateLastDate.HasValue ? string.Format(" ({0})", baseInfo.En2FaNumber(item2.CoordinateLastDate.Value.ToString("HH:mm:ss"))) : ""),
					CmpAccess = ""
				};
				list.Add(item);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actcBookMarks")]
	public ActionResult CBookMark()
	{
		return View();
	}

	[HttpPost]
	[LoginAuthorize]
	public List<CRMspUserTreeBookMarksCartableWeb_Result> UserTreeBookMarksCartableWeb()
	{
		List<CRMspUserTreeBookMarksCartableWeb_Result> result = new List<CRMspUserTreeBookMarksCartableWeb_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			short.Parse(Financial.Get().Id.ToString());
			_ = Financial.Get().Id;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			List<CRMspUserTreeBookMarksCartableWeb_Result> list = Enumerable.ToList<CRMspUserTreeBookMarksCartableWeb_Result>((IEnumerable<CRMspUserTreeBookMarksCartableWeb_Result>)dbI.CRMspUserTreeBookMarksCartableWeb(userId, 4, Labels.AllUsers, lCID, result2, result3));
			if (list != null)
			{
				result = list;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string UserTreeBookMarksCartableWebJs()
	{
		return JsonConvert.SerializeObject(UserTreeBookMarksCartableWeb());
	}

	[HttpPost]
	[LoginAuthorize]
	public List<CRMspResultsBookMarksCartableWeb_Result> ResultsBookMarksCartable(int referUserId = 0, int lastRowNumber = 0, int pageSize = 300)
	{
		List<CRMspResultsBookMarksCartableWeb_Result> result = new List<CRMspResultsBookMarksCartableWeb_Result>();
		try
		{
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
			List<CRMspResultsBookMarksCartableWeb_Result> list = Enumerable.ToList<CRMspResultsBookMarksCartableWeb_Result>((IEnumerable<CRMspResultsBookMarksCartableWeb_Result>)dbI.CRMspResultsBookMarksCartableWeb(UserLogin.CurrentUser.UserId, referUserId, lCID, result2, lastRowNumber, pageSize, false, result3));
			if (list != null)
			{
				foreach (CRMspResultsBookMarksCartableWeb_Result item in list)
				{
					List<CRMspResultsDailyCartableWeb_Result> list2 = JsonConvert.DeserializeObject<List<CRMspResultsDailyCartableWeb_Result>>(item.CmpJs);
					if (list2 != null)
					{
						CRMspResultsDailyCartableWeb_Result cRMspResultsDailyCartableWeb_Result = Enumerable.FirstOrDefault<CRMspResultsDailyCartableWeb_Result>((IEnumerable<CRMspResultsDailyCartableWeb_Result>)list2);
						item.CompanyID = cRMspResultsDailyCartableWeb_Result.CompanyID;
						item.CompanyName = cRMspResultsDailyCartableWeb_Result.CompanyName;
						item.cmpPreTel = cRMspResultsDailyCartableWeb_Result.cmpPreTel;
						item.cmpTel = cRMspResultsDailyCartableWeb_Result.cmpTel;
						item.cmpTelUpTo = cRMspResultsDailyCartableWeb_Result.cmpTelUpTo;
						item.cmpTelDesc = cRMspResultsDailyCartableWeb_Result.cmpTelDesc;
						item.cmpPreTelII = cRMspResultsDailyCartableWeb_Result.cmpPreTelII;
						item.cmpTelII = cRMspResultsDailyCartableWeb_Result.cmpTelII;
						item.cmpTelUpToII = cRMspResultsDailyCartableWeb_Result.cmpTelUpToII;
						item.cmpTelIIDesc = cRMspResultsDailyCartableWeb_Result.cmpTelIIDesc;
						item.cmpFax = cRMspResultsDailyCartableWeb_Result.cmpFax;
						item.cmpFaxDesc = cRMspResultsDailyCartableWeb_Result.cmpFaxDesc;
						item.cmpCountryId = cRMspResultsDailyCartableWeb_Result.cmpCountryId;
						item.Country = cRMspResultsDailyCartableWeb_Result.Country;
						item.cmpProvinceId = cRMspResultsDailyCartableWeb_Result.cmpProvinceId;
						item.Province = cRMspResultsDailyCartableWeb_Result.Province;
						item.cmpCityId = cRMspResultsDailyCartableWeb_Result.cmpCityId;
						item.City = cRMspResultsDailyCartableWeb_Result.City;
						item.cmpAddress = cRMspResultsDailyCartableWeb_Result.cmpAddress;
						item.cmpPresentation = cRMspResultsDailyCartableWeb_Result.cmpPresentation;
					}
					List<CRMspResultsDailyCartableWeb_Result> list3 = JsonConvert.DeserializeObject<List<CRMspResultsDailyCartableWeb_Result>>(item.PrsJs);
					if (list3 != null)
					{
						CRMspResultsDailyCartableWeb_Result cRMspResultsDailyCartableWeb_Result2 = Enumerable.FirstOrDefault<CRMspResultsDailyCartableWeb_Result>((IEnumerable<CRMspResultsDailyCartableWeb_Result>)list3);
						item.Person = cRMspResultsDailyCartableWeb_Result2.Person;
						item.prsPreTel = cRMspResultsDailyCartableWeb_Result2.prsPreTel;
						item.prsTel = cRMspResultsDailyCartableWeb_Result2.prsTel;
						item.prsTelUpTo = cRMspResultsDailyCartableWeb_Result2.prsTelUpTo;
						item.prsTelDesc = cRMspResultsDailyCartableWeb_Result2.prsTelDesc;
						item.prsMobile = cRMspResultsDailyCartableWeb_Result2.prsMobile;
					}
					List<CRMspResultsDailyCartableWeb_Result> list4 = JsonConvert.DeserializeObject<List<CRMspResultsDailyCartableWeb_Result>>(item.PrjJs);
					if (list4 != null)
					{
						CRMspResultsDailyCartableWeb_Result cRMspResultsDailyCartableWeb_Result3 = Enumerable.FirstOrDefault<CRMspResultsDailyCartableWeb_Result>((IEnumerable<CRMspResultsDailyCartableWeb_Result>)list4);
						item.prjTitle = cRMspResultsDailyCartableWeb_Result3.prjTitle;
						item.ProjectID = cRMspResultsDailyCartableWeb_Result3.ProjectID;
					}
					if (item.RemindDateTime.HasValue)
					{
						DateTime.TryParse(item.RemindDateTime.ToString(), out var result4);
						item.RemindDate = result4.ToString("yyyy/MM/dd");
					}
					else if (!string.IsNullOrEmpty(item.RemindDate))
					{
						if (lCID != 1065)
						{
							item.RemindDate = DateTime.ParseExact(PersianDate.GetFormatetdDate(item.RemindDate.Replace("/", "")), "yyyy/MM/dd", new PersianCulture()).ToString("yyyy/MM/dd");
						}
						else
						{
							item.RemindDate = PersianDate.GetFormatetdDate(item.RemindDate.Replace("/", ""));
						}
					}
					if (item.cnvsDateTime.HasValue)
					{
						DateTime.TryParse(item.cnvsDateTime.ToString(), out var result5);
						item.cnvsDate = result5.ToString("yyyy/MM/dd");
					}
					else if (!string.IsNullOrEmpty(item.cnvsDate))
					{
						if (lCID != 1065)
						{
							item.cnvsDate = DateTime.ParseExact(PersianDate.GetFormatetdDate(item.cnvsDate.Replace("/", "")), "yyyy/MM/dd", new PersianCulture()).ToString("yyyy/MM/dd");
						}
						else
						{
							item.cnvsDate = PersianDate.GetFormatetdDate(item.cnvsDate.Replace("/", ""));
						}
					}
					_ = item.RegisterDate;
					item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd");
				}
				result = list;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string ResultsBookMarksCartableJs(int referUserId = 0, int lastRowNumber = 0, int pageSize = 300)
	{
		return JsonConvert.SerializeObject(ResultsBookMarksCartable(referUserId, lastRowNumber, pageSize));
	}

	[AjaxOnly]
	public ActionResult _PartialCBookMark()
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
			List<CRMspUserTreeBookMarksCartable_Result> list = Enumerable.ToList<CRMspUserTreeBookMarksCartable_Result>((IEnumerable<CRMspUserTreeBookMarksCartable_Result>)db.CRMspUserTreeBookMarksCartable(UserLogin.CurrentUser.UserId, 4, Labels.AllUsers, lCID, result, result2));
			List<TreeViewItemModel> list2 = new List<TreeViewItemModel>
			{
				new TreeViewItemModel
				{
					HtmlAttributes = 
					{
						new KeyValuePair<string, string>("accesskey", "-1|-1")
					},
					Id = "-1|-1",
					Text = Labels.Empty,
					ImageUrl = "",
					Items = null
				}
			};
			foreach (CRMspUserTreeBookMarksCartable_Result item in list)
			{
				TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
				treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.RootId + "|" + item.KeyId));
				treeViewItemModel.Id = item.RootId + "|" + item.KeyId;
				treeViewItemModel.Text = item.KeyName;
				treeViewItemModel.ImageUrl = "";
				treeViewItemModel.Items = null;
				list2.Add(treeViewItemModel);
			}
			base.ViewBag.CBookMarkTree = list2;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult _PartialCBookMarkGrid(int bookmarkId)
	{
		if (bookmarkId == 0)
		{
			bookmarkId = UserLogin.CurrentUser.UserId;
		}
		base.ViewBag.BookmarkIdDate = bookmarkId + "|" + DateTime.Now.ToString("yyyyMMdd");
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult CBookMark_Read([DataSourceRequest] DataSourceRequest request, string bookmarkIdDate)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string[] array = bookmarkIdDate.Split(new char[1] { '|' });
		List<CRMspResultsBookMarksCartable_Result> list = new List<CRMspResultsBookMarksCartable_Result>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (int.Parse(array[0]) != 0)
			{
				int treeKeyid = int.Parse(array[0]);
				list = ((treeKeyid != -1) ? Enumerable.ToList<CRMspResultsBookMarksCartable_Result>((IEnumerable<CRMspResultsBookMarksCartable_Result>)Enumerable.OrderBy<CRMspResultsBookMarksCartable_Result, string>(Enumerable.Where<CRMspResultsBookMarksCartable_Result>((IEnumerable<CRMspResultsBookMarksCartable_Result>)Enumerable.ToList<CRMspResultsBookMarksCartable_Result>((IEnumerable<CRMspResultsBookMarksCartable_Result>)db.CRMspResultsBookMarksCartable(UserLogin.CurrentUser.UserId, lCID, result, result2)), (Func<CRMspResultsBookMarksCartable_Result, bool>)((CRMspResultsBookMarksCartable_Result c) => c.cnvsReferUserId == treeKeyid)), (Func<CRMspResultsBookMarksCartable_Result, string>)((CRMspResultsBookMarksCartable_Result c) => c.cnvsTime))) : Enumerable.ToList<CRMspResultsBookMarksCartable_Result>((IEnumerable<CRMspResultsBookMarksCartable_Result>)Enumerable.OrderBy<CRMspResultsBookMarksCartable_Result, string>((IEnumerable<CRMspResultsBookMarksCartable_Result>)Enumerable.ToList<CRMspResultsBookMarksCartable_Result>((IEnumerable<CRMspResultsBookMarksCartable_Result>)db.CRMspResultsBookMarksCartable(UserLogin.CurrentUser.UserId, lCID, result, result2)), (Func<CRMspResultsBookMarksCartable_Result, string>)((CRMspResultsBookMarksCartable_Result c) => c.cnvsTime))));
			}
			foreach (CRMspResultsBookMarksCartable_Result item in list)
			{
				if (item.RemindDateTime.HasValue)
				{
					DateTime.TryParse(item.RemindDateTime.ToString(), out var result3);
					item.RemindDate = result3.ToString("yyyy/MM/dd");
				}
				else if (!string.IsNullOrEmpty(item.RemindDate))
				{
					if (lCID != 1065)
					{
						item.RemindDate = DateTime.ParseExact(PersianDate.GetFormatetdDate(item.RemindDate.Replace("/", "")), "yyyy/MM/dd", new PersianCulture()).ToString("yyyy/MM/dd");
					}
					else
					{
						item.RemindDate = PersianDate.GetFormatetdDate(item.RemindDate.Replace("/", ""));
					}
				}
				if (item.cnvsDateTime.HasValue)
				{
					DateTime.TryParse(item.cnvsDateTime.ToString(), out var result4);
					item.cnvsDate = result4.ToString("yyyy/MM/dd");
				}
				else if (!string.IsNullOrEmpty(item.cnvsDate))
				{
					if (lCID != 1065)
					{
						item.cnvsDate = DateTime.ParseExact(PersianDate.GetFormatetdDate(item.cnvsDate.Replace("/", "")), "yyyy/MM/dd", new PersianCulture()).ToString("yyyy/MM/dd");
					}
					else
					{
						item.cnvsDate = PersianDate.GetFormatetdDate(item.cnvsDate.Replace("/", ""));
					}
				}
				_ = item.RegisterDate;
				item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd");
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	public ActionResult ChangeCulture(string lang, string returnUrl)
	{
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected O, but got Unknown
		if (!Enumerable.Any<CRMspSelectUserLanguages_Result>((IEnumerable<CRMspSelectUserLanguages_Result>)CRMIdeal.Cache.User.Language.Get(UserLogin.CurrentUser.UserId), (Func<CRMspSelectUserLanguages_Result, bool>)((CRMspSelectUserLanguages_Result c) => c.LanguageCollation.ToLower() == lang.ToLower())))
		{
			return Redirect("~/");
		}
		base.Session["Culture"] = new CultureInfo(lang);
		HttpCookie val = (HttpCookie)((base.Request.Cookies["CurrentLanguage"] != null) ? ((object)base.Request.Cookies["CurrentLanguage"]) : ((object)new HttpCookie("CurrentLanguage")));
		val.Value = lang;
		val.Expires = DateTime.MaxValue;
		base.Response.Cookies.Add(val);
		CultureInfo cultureInfo = new CultureInfo(lang);
		Thread.CurrentThread.CurrentUICulture = cultureInfo;
		Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureInfo.Name);
		Thread.CurrentThread.CurrentCulture = cultureInfo;
		bool? fromLoginPage = true;
		Info.Update(null, fromLoginPage);
		Permissions.Update();
		Alarms.Update();
		CRMIdeal.Cache.User.Language.Update();
		Manager.UpdateAllSettingCach();
		return Redirect(returnUrl);
	}

	public ActionResult Index()
	{
		return View();
	}

	[LoginAuthorize]
	public ActionResult HomePage()
	{
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actBackUp")]
	public ActionResult BackUpRestore()
	{
		return View();
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmBackUpRestore", ActionName = "actCreateBackUp")]
	public JsonResult CreateBackup()
	{
		string data = "";
		string message = "";
		CommonResultStatusViewModel status = CommonResultStatusViewModel.Success;
		CommonResultViewModel<string> data2;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			string text = DateTime.Now.ToString("yyyyMMdd-HHmmss", new PersianCulture());
			if (!UserLogin.IsUserAccess("frmMain", "actBackUp", UserLogin.CurrentUser))
			{
				data = "";
				message = Messages.ErrorNotAccess;
				status = CommonResultStatusViewModel.Error;
				data2 = new CommonResultViewModel<string>
				{
					Data = data,
					Message = message,
					Status = status
				};
				return Json(data2, JsonRequestBehavior.AllowGet);
			}
			string text2 = base.Server.MapPath("/BackUp/" + text);
			if (!System.IO.Directory.Exists(text2))
			{
				System.IO.Directory.CreateDirectory(text2);
				CRM.General.IO.Directory.SetFullControlForEveryOne(text2);
			}
			string text3 = text2 + "\\BCKCRM-" + text + ".bak";
			string dbName = CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]);
			mct_CRMspCreateBackupFromDb_Result mct_CRMspCreateBackupFromDb_Result = Enumerable.FirstOrDefault<mct_CRMspCreateBackupFromDb_Result>((IEnumerable<mct_CRMspCreateBackupFromDb_Result>)db.CRMspCreateBackupFromDb(dbName, text3));
			if (mct_CRMspCreateBackupFromDb_Result != null)
			{
				if (mct_CRMspCreateBackupFromDb_Result.Result.GetValueOrDefault() == 1)
				{
					data = text3;
					message = Messages.msgSuccessAction;
					status = CommonResultStatusViewModel.Success;
				}
				else
				{
					data = "";
					message = Messages.msgErrorRunFunction;
					status = CommonResultStatusViewModel.Error;
					if (!string.IsNullOrWhiteSpace(mct_CRMspCreateBackupFromDb_Result.Message))
					{
						Exception e = new Exception(Messages.msgErrorRunFunction + " - " + mct_CRMspCreateBackupFromDb_Result.Message);
						ErrorSignal.FromCurrentContext().Raise(e);
					}
				}
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			data = "";
			data2 = new CommonResultViewModel<string>
			{
				Data = data,
				Message = Messages.msgErrorRunFunction,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data2, JsonRequestBehavior.AllowGet);
		}
		data2 = new CommonResultViewModel<string>
		{
			Data = data,
			Message = message,
			Status = status
		};
		return Json(data2, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actcSerach")]
	public ActionResult CSearch()
	{
		string text = "";
		base.ViewBag.txtSearch = text + "|" + 1;
		return View();
	}

	[AjaxOnly]
	public ActionResult _PartialCSearch(string txtSearch, int mode, string searchConditionMode = "")
	{
		base.ViewBag.txtSearch = txtSearch + "|" + mode + "|" + searchConditionMode;
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult CSearch_Read([DataSourceRequest] DataSourceRequest request, string ContextSearch)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspMainSearchWeb_Result> listCompany = new List<CRMspMainSearchWeb_Result>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (!string.IsNullOrEmpty(ContextSearch))
			{
				string[] array = ContextSearch.Split(new char[1] { '|' });
				listCompany = Enumerable.ToList<CRMspMainSearchWeb_Result>((IEnumerable<CRMspMainSearchWeb_Result>)dbI.CRMspMainSearchWeb(array[0], UserLogin.CurrentUser.UserId, int.Parse(array[1]), lCID, result, array[2], result2));
				string text = array[2];
				int result3 = 0;
				int.TryParse(array[1], out result3);
				if (!string.IsNullOrWhiteSpace(text) && result3 == 1)
				{
					text = ((!text.Contains("1000") && !text.Contains("1001") && !text.Contains("1002")) ? (string.Join(",", Enumerable.ToList<string>(Enumerable.Where<string>((IEnumerable<string>)Enumerable.ToList<string>((IEnumerable<string>)text.Split(new char[1] { ',' })), (Func<string, bool>)((string x) => x != "1003")))) + ",1000,1002") : (string.Join(",", Enumerable.ToList<string>(Enumerable.Where<string>((IEnumerable<string>)Enumerable.ToList<string>((IEnumerable<string>)text.Split(new char[1] { ',' })), (Func<string, bool>)((string x) => x != "1000" && x != "1001" && x != "1002")))) + ",1003"));
					List<CRMspMainSearchWeb_Result> list = Enumerable.ToList<CRMspMainSearchWeb_Result>((IEnumerable<CRMspMainSearchWeb_Result>)_dbI.CRMspMainSearchWeb(array[0], UserLogin.CurrentUser.UserId, result3, lCID, result, text, result2));
					if (list != null && Enumerable.Any<CRMspMainSearchWeb_Result>((IEnumerable<CRMspMainSearchWeb_Result>)list))
					{
						if (listCompany == null)
						{
							listCompany = new List<CRMspMainSearchWeb_Result>();
						}
						if (Enumerable.Any<CRMspMainSearchWeb_Result>((IEnumerable<CRMspMainSearchWeb_Result>)listCompany))
						{
							listCompany.AddRange(Enumerable.ToList<CRMspMainSearchWeb_Result>(Enumerable.Where<CRMspMainSearchWeb_Result>((IEnumerable<CRMspMainSearchWeb_Result>)list, (Func<CRMspMainSearchWeb_Result, bool>)((CRMspMainSearchWeb_Result x) => Enumerable.FirstOrDefault<CRMspMainSearchWeb_Result>((IEnumerable<CRMspMainSearchWeb_Result>)listCompany, (Func<CRMspMainSearchWeb_Result, bool>)((CRMspMainSearchWeb_Result r) => r.CompanyID == x.CompanyID)) == null))));
						}
						else
						{
							listCompany.AddRange(list);
						}
					}
				}
				if (listCompany != null && Enumerable.Any<CRMspMainSearchWeb_Result>((IEnumerable<CRMspMainSearchWeb_Result>)listCompany))
				{
					foreach (CRMspMainSearchWeb_Result item in listCompany)
					{
						item.cmpCode = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccCodeWithComa(1, item.cmpCode);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)listCompany).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[HttpPost]
	[LoginAuthorize]
	public List<CRMspMainSearchWebSmart_Result> LoadSerach(string value = "", int mode = 1, string cons = "")
	{
		List<CRMspMainSearchWebSmart_Result> list = new List<CRMspMainSearchWebSmart_Result>();
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
			List<CRMspMainSearchWebSmart_Result> sp = Enumerable.ToList<CRMspMainSearchWebSmart_Result>((IEnumerable<CRMspMainSearchWebSmart_Result>)dbI.CRMspMainSearchWebSmart(value, UserLogin.CurrentUser.UserId, mode, lCID, result, cons, result2));
			if (!string.IsNullOrWhiteSpace(cons) && mode == 1)
			{
				cons = ((!cons.Contains("1000") && !cons.Contains("1001") && !cons.Contains("1002")) ? (string.Join(",", Enumerable.ToList<string>(Enumerable.Where<string>((IEnumerable<string>)Enumerable.ToList<string>((IEnumerable<string>)cons.Split(new char[1] { ',' })), (Func<string, bool>)((string x) => x != "1003")))) + ",1000,1002") : (string.Join(",", Enumerable.ToList<string>(Enumerable.Where<string>((IEnumerable<string>)Enumerable.ToList<string>((IEnumerable<string>)cons.Split(new char[1] { ',' })), (Func<string, bool>)((string x) => x != "1000" && x != "1001" && x != "1002")))) + ",1003"));
				List<CRMspMainSearchWebSmart_Result> list2 = Enumerable.ToList<CRMspMainSearchWebSmart_Result>((IEnumerable<CRMspMainSearchWebSmart_Result>)dbI.CRMspMainSearchWebSmart(value, UserLogin.CurrentUser.UserId, mode, lCID, result, cons, result2));
				if (list2 != null && Enumerable.Any<CRMspMainSearchWebSmart_Result>((IEnumerable<CRMspMainSearchWebSmart_Result>)list2))
				{
					if (sp == null)
					{
						sp = new List<CRMspMainSearchWebSmart_Result>();
					}
					if (Enumerable.Any<CRMspMainSearchWebSmart_Result>((IEnumerable<CRMspMainSearchWebSmart_Result>)sp))
					{
						sp.AddRange(Enumerable.ToList<CRMspMainSearchWebSmart_Result>(Enumerable.Where<CRMspMainSearchWebSmart_Result>((IEnumerable<CRMspMainSearchWebSmart_Result>)list2, (Func<CRMspMainSearchWebSmart_Result, bool>)((CRMspMainSearchWebSmart_Result x) => Enumerable.FirstOrDefault<CRMspMainSearchWebSmart_Result>((IEnumerable<CRMspMainSearchWebSmart_Result>)sp, (Func<CRMspMainSearchWebSmart_Result, bool>)((CRMspMainSearchWebSmart_Result r) => r.CompanyID == x.CompanyID)) == null))));
					}
					else
					{
						sp.AddRange(list2);
					}
				}
			}
			if (sp != null)
			{
				list = sp;
				foreach (CRMspMainSearchWebSmart_Result item in list)
				{
					if (!string.IsNullOrWhiteSpace(item.cmpEffectiveDatePersian))
					{
						item.cmpEffectiveDatePersian = item.cmpEffectiveDateTime?.ToString("yyyy/MM/dd");
					}
					if (!string.IsNullOrWhiteSpace(item.FirstRegisterDatePersian))
					{
						item.FirstRegisterDatePersian = item.FirstRegisterDate?.ToString("yyyy/MM/dd HH:mm:ss");
					}
					if (!string.IsNullOrWhiteSpace(item.RegisterDatePersian))
					{
						item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
					}
					item.cmpCode = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccCodeWithComa(1, item.cmpCode);
				}
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
	public string LoadSerachJs(string value = "", int mode = 1, string cons = "")
	{
		return JsonConvert.SerializeObject(LoadSerach(value, mode, cons));
	}

	[HttpPost]
	[LoginAuthorize]
	public JsonResult LoadFileSerachJs(string value = "", string cons = "", int pageNumber = 1, int pageSize = 30)
	{
		List<CRMspFileSearchWebSmart_Result> list = new List<CRMspFileSearchWebSmart_Result>();
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
			ObjectParameter objectParameter = new ObjectParameter("TotalCount", 0);
			List<CRMspFileSearchWebSmart_Result> list2 = Enumerable.ToList<CRMspFileSearchWebSmart_Result>((IEnumerable<CRMspFileSearchWebSmart_Result>)_dbIII.CRMspFileSearchWebSmart(value, UserLogin.CurrentUser.UserId, lCID, result, cons, result2, pageNumber, pageSize, objectParameter));
			if (list2 != null)
			{
				list = list2;
				foreach (CRMspFileSearchWebSmart_Result item in list)
				{
					if (!string.IsNullOrWhiteSpace(item.FirstRegisterDatePersian))
					{
						item.FirstRegisterDatePersian = item.FirstRegisterDate?.ToString("yyyy/MM/dd HH:mm:ss");
					}
					if (!string.IsNullOrWhiteSpace(item.RegisterDatePersian))
					{
						item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
					}
					item.DocDateTimeStr = (item.DocDateTime.HasValue ? DateTimeClass.GetLocalDate(item.DocDateTime).Value.ToString("yyyy/MM/dd") : "");
					item.cmpCode = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccCodeWithComa(1, item.cmpCode);
				}
			}
			return Json(new
			{
				Items = list,
				TotalCount = objectParameter.Value,
				PageNumber = pageNumber,
				PageSize = pageSize,
				HasNextPage = (pageNumber * pageSize < (int)objectParameter.Value)
			}, JsonRequestBehavior.AllowGet);
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return Json(new
		{
			Items = new { },
			TotalCount = 0,
			PageNumber = pageNumber,
			PageSize = pageSize,
			HasNextPage = false
		}, JsonRequestBehavior.AllowGet);
	}

	[HttpPost]
	[LoginAuthorize]
	public JsonResult LoadPreOrderSearchJs(string value = "", string cons = "", int pageNumber = 1, int pageSize = 30)
	{
		List<WSspSearchPreOrders_Result> list = new List<WSspSearchPreOrders_Result>();
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
			ObjectParameter objectParameter = new ObjectParameter("TotalCount", 0);
			List<WSspSearchPreOrders_Result> list2 = Enumerable.ToList<WSspSearchPreOrders_Result>((IEnumerable<WSspSearchPreOrders_Result>)_dbIII.WSspSearchPreOrders(value, UserLogin.CurrentUser.UserId, lCID, result, cons, result2, pageNumber, pageSize, objectParameter));
			if (list2 != null)
			{
				list = list2;
				foreach (WSspSearchPreOrders_Result item in list)
				{
					item.pordDate = (item.pordDateTime.HasValue ? DateTimeClass.GetLocalDate(item.pordDateTime).Value.ToString("yyyy/MM/dd") : "");
				}
			}
			return Json(new
			{
				Items = list,
				TotalCount = objectParameter.Value,
				PageNumber = pageNumber,
				PageSize = pageSize,
				HasNextPage = (pageNumber * pageSize < (int)objectParameter.Value)
			}, JsonRequestBehavior.AllowGet);
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return Json(new
		{
			Items = new { },
			TotalCount = 0,
			PageNumber = pageNumber,
			PageSize = pageSize,
			HasNextPage = false
		}, JsonRequestBehavior.AllowGet);
	}

	[HttpPost]
	[LoginAuthorize]
	public JsonResult LoadOrderSearchJs(string value = "", string cons = "", int pageNumber = 1, int pageSize = 30)
	{
		List<WSspSearchOrders_Result> list = new List<WSspSearchOrders_Result>();
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
			ObjectParameter objectParameter = new ObjectParameter("TotalCount", 0);
			List<WSspSearchOrders_Result> list2 = Enumerable.ToList<WSspSearchOrders_Result>((IEnumerable<WSspSearchOrders_Result>)_dbIII.WSspSearchOrders(value, UserLogin.CurrentUser.UserId, lCID, result, cons, result2, pageNumber, pageSize, objectParameter));
			if (list2 != null)
			{
				list = list2;
				foreach (WSspSearchOrders_Result item in list)
				{
					item.ordDate = (item.ordDateTime.HasValue ? DateTimeClass.GetLocalDate(item.ordDateTime).Value.ToString("yyyy/MM/dd") : "");
				}
			}
			return Json(new
			{
				Items = list,
				TotalCount = objectParameter.Value,
				PageNumber = pageNumber,
				PageSize = pageSize,
				HasNextPage = (pageNumber * pageSize < (int)objectParameter.Value)
			}, JsonRequestBehavior.AllowGet);
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return Json(new
		{
			Items = new { },
			TotalCount = 0,
			PageNumber = pageNumber,
			PageSize = pageSize,
			HasNextPage = false
		}, JsonRequestBehavior.AllowGet);
	}

	[HttpPost]
	[LoginAuthorize]
	public JsonResult LoadBuyOrderSearchJs(string value = "", string cons = "", int pageNumber = 1, int pageSize = 30)
	{
		List<WSspSearchBuyOrders_Result> list = new List<WSspSearchBuyOrders_Result>();
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
			ObjectParameter objectParameter = new ObjectParameter("TotalCount", 0);
			List<WSspSearchBuyOrders_Result> list2 = Enumerable.ToList<WSspSearchBuyOrders_Result>((IEnumerable<WSspSearchBuyOrders_Result>)_dbIII.WSspSearchBuyOrders(value, UserLogin.CurrentUser.UserId, lCID, result, cons, result2, pageNumber, pageSize, objectParameter));
			if (list2 != null)
			{
				list = list2;
				foreach (WSspSearchBuyOrders_Result item in list)
				{
					item.bordDate = (item.bordDateTime.HasValue ? DateTimeClass.GetLocalDate(item.bordDateTime).Value.ToString("yyyy/MM/dd") : "");
				}
			}
			return Json(new
			{
				Items = list,
				TotalCount = objectParameter.Value,
				PageNumber = pageNumber,
				PageSize = pageSize,
				HasNextPage = (pageNumber * pageSize < (int)objectParameter.Value)
			}, JsonRequestBehavior.AllowGet);
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return Json(new
		{
			Items = new { },
			TotalCount = 0,
			PageNumber = pageNumber,
			PageSize = pageSize,
			HasNextPage = false
		}, JsonRequestBehavior.AllowGet);
	}

	[HttpPost]
	[LoginAuthorize]
	public JsonResult LoadLetterSearchJs(string value = "", string cons = "", int pageNumber = 1, int pageSize = 30)
	{
		List<SecspSearchLetters_Result> list = new List<SecspSearchLetters_Result>();
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
			ObjectParameter objectParameter = new ObjectParameter("TotalCount", 0);
			List<SecspSearchLetters_Result> list2 = Enumerable.ToList<SecspSearchLetters_Result>((IEnumerable<SecspSearchLetters_Result>)_dbIII.SecspSearchLetters(value, UserLogin.CurrentUser.UserId, lCID, result, cons, result2, pageNumber, pageSize, objectParameter));
			if (list2 != null)
			{
				list = list2;
				foreach (SecspSearchLetters_Result item in list)
				{
					_ = item.LetterDateTime;
					item.LetterDate = DateTimeClass.GetLocalDate(item.LetterDateTime).Value.ToString("yyyy/MM/dd");
				}
			}
			return Json(new
			{
				Items = list,
				TotalCount = objectParameter.Value,
				PageNumber = pageNumber,
				PageSize = pageSize,
				HasNextPage = (pageNumber * pageSize < (int)objectParameter.Value)
			}, JsonRequestBehavior.AllowGet);
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return Json(new
		{
			Items = new { },
			TotalCount = 0,
			PageNumber = pageNumber,
			PageSize = pageSize,
			HasNextPage = false
		}, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult _PartialMainSearch(string valSearch, string searchConditionMode = "")
	{
		base.ViewBag.ValSearch = valSearch;
		base.ViewBag.SearchConditionMode = searchConditionMode;
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult MainSearch_Read([DataSourceRequest] DataSourceRequest request, string valSearch, string searchConditionMode = "")
	{
		List<CRMspMainSearchWeb_Result> list = new List<CRMspMainSearchWeb_Result>();
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
			list = Enumerable.ToList<CRMspMainSearchWeb_Result>((IEnumerable<CRMspMainSearchWeb_Result>)dbI.CRMspMainSearchWeb(valSearch, UserLogin.CurrentUser.UserId, 1, lCID, result, searchConditionMode, result2));
			if (list != null && Enumerable.Any<CRMspMainSearchWeb_Result>((IEnumerable<CRMspMainSearchWeb_Result>)list))
			{
				foreach (CRMspMainSearchWeb_Result item in list)
				{
					item.cmpCode = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccCodeWithComa(1, item.cmpCode);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	public string AddMinutesReminder(int userTaskID, int minute, string typeReminder, string clientCurrentTime)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string result2 = "";
		DateTime dateTime = DateTime.Now;
		if (clientCurrentTime != "")
		{
			dateTime = DateTime.Parse(dateTime.ToString("yyyy/MM/dd") + " " + clientCurrentTime);
		}
		try
		{
			if (typeReminder == "1")
			{
				CrmUserTasks crmUserTasks = _dbTbl.CrmUserTasks.Find(userTaskID);
				if (crmUserTasks != null)
				{
					DateTime dateTime2 = dateTime;
					dateTime2 = dateTime2.AddMinutes(minute);
					crmUserTasks.UserTaskRemindDate = dateTime2.ToString("yyyyMMdd", new PersianCulture());
					crmUserTasks.UserTaskRemindDateTime = dateTime2;
					crmUserTasks.UserTaskRemindTime = dateTime2.ToString("HH:mm");
					crmUserTasks.AppType = Configuration.AppType;
					_dbTbl.Entry(crmUserTasks).State = EntityState.Modified;
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					Alarms.Update(crmUserTasks.UserId);
					CRMspSelectUserTasks_Result cRMspSelectUserTasks_Result = Enumerable.FirstOrDefault<CRMspSelectUserTasks_Result>((IEnumerable<CRMspSelectUserTasks_Result>)Enumerable.ToList<CRMspSelectUserTasks_Result>((IEnumerable<CRMspSelectUserTasks_Result>)db.CRMspSelectUserTasks(lCID, result)), (Func<CRMspSelectUserTasks_Result, bool>)((CRMspSelectUserTasks_Result c) => c.UserTaskId == userTaskID));
					string text = "";
					string strB = dateTime.ToString("yyyyMMdd");
					if ((string.CompareOrdinal(cRMspSelectUserTasks_Result.UserTaskRemindDate, strB) < -1 || string.CompareOrdinal(cRMspSelectUserTasks_Result.UserTaskRemindDate, strB) == 0) && cRMspSelectUserTasks_Result.UserId == UserLogin.CurrentUser.UserId && !cRMspSelectUserTasks_Result.UserTaskDidIt.GetValueOrDefault())
					{
						_ = cRMspSelectUserTasks_Result.UserTaskDate;
						DateTime.TryParse(cRMspSelectUserTasks_Result.UserTaskDate.ToString(), out var result3);
						cRMspSelectUserTasks_Result.UserTaskDatePersian = result3.ToString("yyyyMMdd");
						if (cRMspSelectUserTasks_Result.UserTaskRemindDateTime.HasValue)
						{
							DateTime.TryParse(cRMspSelectUserTasks_Result.UserTaskRemindDateTime.ToString(), out var result4);
							cRMspSelectUserTasks_Result.UserTaskRemindDate = result4.ToString("yyyyMMdd");
						}
						else if (!string.IsNullOrEmpty(cRMspSelectUserTasks_Result.UserTaskRemindDate))
						{
							if (lCID != 1065)
							{
								cRMspSelectUserTasks_Result.UserTaskRemindDate = DateTime.ParseExact(PersianDate.GetFormatetdDate(cRMspSelectUserTasks_Result.UserTaskRemindDate.Replace("/", "")), "yyyy/MM/dd", new PersianCulture()).ToString("yyyyMMdd");
							}
							else
							{
								cRMspSelectUserTasks_Result.UserTaskRemindDate = cRMspSelectUserTasks_Result.UserTaskRemindDate.Replace("/", "");
							}
						}
						text = "1|" + cRMspSelectUserTasks_Result.UserTaskId + "|" + cRMspSelectUserTasks_Result.UserTaskTitle + "|" + cRMspSelectUserTasks_Result.UserTaskTime + "|" + cRMspSelectUserTasks_Result.UserTaskDatePersian + "|" + cRMspSelectUserTasks_Result.UserTaskRemindTime + "|" + cRMspSelectUserTasks_Result.UserTaskRemindDate + "|" + 0 + "|" + 0 + "|" + 0;
					}
					result2 = text;
				}
			}
			else
			{
				CrmConversation crmConversation = _dbTbl.CrmConversation.Find(userTaskID);
				if (crmConversation != null)
				{
					dateTime = dateTime.AddMinutes(minute);
					crmConversation.cnvsRemindTime = dateTime.ToString("HH:mm");
					crmConversation.cnvsRemindDateForAllarm = dateTime.ToString("yyyyMMdd", new PersianCulture());
					crmConversation.cnvsRemindDateTimeForAllarm = dateTime;
					crmConversation.AppType = Configuration.AppType;
					_dbTbl.Entry(crmConversation).State = EntityState.Modified;
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					Alarms.Update(crmConversation.UserId);
					CRMspSelectCrmConversationWithID_Result cRMspSelectCrmConversationWithID_Result = Enumerable.FirstOrDefault<CRMspSelectCrmConversationWithID_Result>((IEnumerable<CRMspSelectCrmConversationWithID_Result>)db.CRMspSelectCrmConversationWithID(userTaskID, lCID, result));
					string text2 = "";
					string strB2 = dateTime.ToString("yyyyMMdd");
					if ((string.CompareOrdinal(cRMspSelectCrmConversationWithID_Result.cnvsRemindDateForAllarm, strB2) < -1 || string.CompareOrdinal(cRMspSelectCrmConversationWithID_Result.cnvsRemindDateForAllarm, strB2) == 0) && cRMspSelectCrmConversationWithID_Result.cnvsReferUserId == UserLogin.CurrentUser.UserId && !cRMspSelectCrmConversationWithID_Result.cnvsRemindOk.GetValueOrDefault())
					{
						if (cRMspSelectCrmConversationWithID_Result.cnvsRemindDateTime.HasValue)
						{
							DateTime.TryParse(cRMspSelectCrmConversationWithID_Result.cnvsRemindDateTime.ToString(), out var result5);
							cRMspSelectCrmConversationWithID_Result.cnvsRemindDate = result5.ToString("yyyyMMdd");
						}
						else if (!string.IsNullOrEmpty(cRMspSelectCrmConversationWithID_Result.cnvsRemindDate))
						{
							if (lCID != 1065)
							{
								cRMspSelectCrmConversationWithID_Result.cnvsRemindDate = DateTime.ParseExact(PersianDate.GetFormatetdDate(cRMspSelectCrmConversationWithID_Result.cnvsRemindDate.Replace("/", "")), "yyyy/MM/dd", new PersianCulture()).ToString("yyyyMMdd");
							}
							else
							{
								cRMspSelectCrmConversationWithID_Result.cnvsRemindDate = cRMspSelectCrmConversationWithID_Result.cnvsRemindDate.Replace("/", "");
							}
						}
						if (cRMspSelectCrmConversationWithID_Result.cnvsRemindDateTimeForAllarm.HasValue)
						{
							DateTime.TryParse(cRMspSelectCrmConversationWithID_Result.cnvsRemindDateTimeForAllarm.ToString(), out var result6);
							cRMspSelectCrmConversationWithID_Result.cnvsRemindDateForAllarm = result6.ToString("yyyyMMdd");
						}
						else if (!string.IsNullOrEmpty(cRMspSelectCrmConversationWithID_Result.cnvsRemindDateForAllarm))
						{
							if (lCID != 1065)
							{
								cRMspSelectCrmConversationWithID_Result.cnvsRemindDateForAllarm = DateTime.ParseExact(PersianDate.GetFormatetdDate(cRMspSelectCrmConversationWithID_Result.cnvsRemindDateForAllarm.Replace("/", "")), "yyyy/MM/dd", new PersianCulture()).ToString("yyyyMMdd");
							}
							else
							{
								cRMspSelectCrmConversationWithID_Result.cnvsRemindDateForAllarm = cRMspSelectCrmConversationWithID_Result.cnvsRemindDateForAllarm.Replace("/", "");
							}
						}
						text2 = "2|" + cRMspSelectCrmConversationWithID_Result.ConversationID + "|" + CRMIdeal.Classes.Helper.Company.GetCompanyNameWithTitle(cRMspSelectCrmConversationWithID_Result.cnvsCompanyId) + " " + CRMIdeal.Classes.Helper.Company.GetCmpPersonNameWithTitle(cRMspSelectCrmConversationWithID_Result.cnvsPersonId) + "|" + cRMspSelectCrmConversationWithID_Result.cnvsTime + "|" + cRMspSelectCrmConversationWithID_Result.cnvsRemindDate + "|" + cRMspSelectCrmConversationWithID_Result.cnvsRemindTime + "|" + cRMspSelectCrmConversationWithID_Result.cnvsRemindDateForAllarm + "|" + cRMspSelectCrmConversationWithID_Result.cnvsCompanyId + "|" + cRMspSelectCrmConversationWithID_Result.cnvsPersonId + "|" + cRMspSelectCrmConversationWithID_Result.cnvsProjectId;
					}
					result2 = text2;
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
		return result2;
	}

	public string ChkBeforeSubmitUserTask(CrmUserTasks uTask, ref int countError)
	{
		string text = "";
		if (string.IsNullOrEmpty(uTask.UserTaskTitle))
		{
			text += "عنوان وارد نگردیده!";
			countError++;
		}
		if (string.IsNullOrEmpty(uTask.UserTaskDatePersian))
		{
			text += "تاریخ وارد نگردیده!";
			countError++;
		}
		if (string.IsNullOrEmpty(uTask.UserTaskRemindDate))
		{
			text += "تاریخ آلارم وارد نگردیده!";
			countError++;
		}
		if (string.IsNullOrEmpty(uTask.UserTaskTime))
		{
			text += "زمان وارد نگردیده!";
			countError++;
		}
		if (string.IsNullOrEmpty(uTask.UserTaskRemindTime))
		{
			text += "زمان آلارم وارد نگردیده!";
			countError++;
		}
		return text;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actDefinePrjPriority")]
	public ActionResult UserTaskDefinePriority()
	{
		return View();
	}

	public static string HexToColor(string hexColor)
	{
		if (string.IsNullOrWhiteSpace(hexColor))
		{
			return null;
		}
		if (hexColor.IndexOf('#') != -1)
		{
			hexColor = hexColor.Replace("#", "");
		}
		string text = "00";
		string text2 = "00";
		string text3 = "00";
		if (hexColor.Length == 6)
		{
			text = hexColor.Substring(0, 2);
			text2 = hexColor.Substring(2, 2);
			text3 = hexColor.Substring(4, 2);
		}
		else if (hexColor.Length == 3)
		{
			text = hexColor[0].ToString() + hexColor[0];
			text2 = hexColor[1].ToString() + hexColor[1];
			text3 = hexColor[2].ToString() + hexColor[2];
		}
		return "$00" + text3.ToString() + text2.ToString() + text.ToString();
	}

	public string TColorToHex(string TColor)
	{
		string text = TColor.Substring(3, 2);
		string text2 = TColor.Substring(5, 2);
		string text3 = TColor.Substring(7, 2);
		return "#" + text3 + text2 + text;
	}

	public string getUtPriorityColor(int id)
	{
		string result = "-1";
		CrmUserTaskPriorities crmUserTaskPriorities = new CrmUserTaskPriorities();
		crmUserTaskPriorities = _dbTbl.CrmUserTaskPriorities.Find(id);
		if (crmUserTaskPriorities != null)
		{
			result = TColorToHex(crmUserTaskPriorities.Color);
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actcInternalTask")]
	public ActionResult CInternalTask()
	{
		GetCInternalTaskTreeJs();
		return View();
	}

	[AjaxOnly]
	public ActionResult _PartialCInternalTaskGrid(int treeUserId, int typeId)
	{
		base.ViewBag.treeUserId = treeUserId;
		base.ViewBag.typeId = typeId;
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult CInternalTask_Read([DataSourceRequest] DataSourceRequest request, int treeUserId, int typeId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspInternalMessageLoadShortUserMessage_Result> list = new List<CRMspInternalMessageLoadShortUserMessage_Result>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (typeId != 0)
			{
				list = Enumerable.ToList<CRMspInternalMessageLoadShortUserMessage_Result>((IEnumerable<CRMspInternalMessageLoadShortUserMessage_Result>)db.CRMspInternalMessageLoadShortUserMessage(UserLogin.CurrentUser.UserId, typeId, lCID, result, false, result2));
				foreach (CRMspInternalMessageLoadShortUserMessage_Result item in list)
				{
					if (item.msgdSendDateTime.HasValue)
					{
						DateTime.TryParse(item.msgdSendDateTime.ToString(), out var result3);
						item.SendDateTime = result3.ToString("yyyy/MM/dd HH:mm:ss");
					}
				}
			}
			int messageId = 0;
			if (list.Count > 0)
			{
				messageId = Enumerable.FirstOrDefault<CRMspInternalMessageLoadShortUserMessage_Result>((IEnumerable<CRMspInternalMessageLoadShortUserMessage_Result>)list).InternalMessageID;
			}
			UpdateInternalMessage("Receive", messageId, typeId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public ActionResult _PartialCInternalTask()
	{
		try
		{
			IQueryable<CRMUserTreeInternalMessageCartable_Result> obj = db.CRMUserTreeInternalMessageCartable(UserLogin.CurrentUser.UserId, 5);
			ParameterExpression val = Expression.Parameter(typeof(CRMUserTreeInternalMessageCartable_Result), "c");
			List<CRMUserTreeInternalMessageCartable_Result> list = Enumerable.ToList<CRMUserTreeInternalMessageCartable_Result>((IEnumerable<CRMUserTreeInternalMessageCartable_Result>)Queryable.Where<CRMUserTreeInternalMessageCartable_Result>(obj, Expression.Lambda<Func<CRMUserTreeInternalMessageCartable_Result, bool>>((Expression)(object)Expression.NotEqual((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Convert((Expression)(object)Expression.Constant((object)0, typeof(int)), typeof(int?))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			List<TreeViewItemModel> list2 = new List<TreeViewItemModel>();
			foreach (CRMUserTreeInternalMessageCartable_Result item in list)
			{
				TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
				treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.RootId + "|" + item.KeyId));
				treeViewItemModel.Id = item.RootId + "|" + item.KeyId;
				treeViewItemModel.Text = item.KeyName;
				treeViewItemModel.ImageUrl = "";
				treeViewItemModel.Items = null;
				list2.Add(treeViewItemModel);
			}
			base.ViewBag.CInternalTaskTree = list2;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView();
	}

	[AjaxOnly]
	public JsonResult GetCInternalTaskTree()
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
		List<CRMspIntMsgUserTreeInternalMessageCartable_Result> list = Enumerable.ToList<CRMspIntMsgUserTreeInternalMessageCartable_Result>((IEnumerable<CRMspIntMsgUserTreeInternalMessageCartable_Result>)db.CRMspIntMsgUserTreeInternalMessageCartable(UserLogin.CurrentUser.UserId, 5, lCID, result, result2));
		List<TreeViewItemModel> list2 = new List<TreeViewItemModel>();
		foreach (CRMspIntMsgUserTreeInternalMessageCartable_Result item in list)
		{
			TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
			treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.RootID + "|" + item.KeyID));
			treeViewItemModel.Id = item.RootID + "|" + item.KeyID;
			treeViewItemModel.Text = item.KeyName;
			treeViewItemModel.ImageUrl = "";
			treeViewItemModel.Items = null;
			list2.Add(treeViewItemModel);
		}
		base.ViewBag.CInternalTaskTree = list2;
		return Json(list2, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCInternalTaskTreeJs()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspIntMsgUserTreeInternalMessageCartable_Result> list = new List<CRMspIntMsgUserTreeInternalMessageCartable_Result>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			list = Enumerable.ToList<CRMspIntMsgUserTreeInternalMessageCartable_Result>((IEnumerable<CRMspIntMsgUserTreeInternalMessageCartable_Result>)db.CRMspIntMsgUserTreeInternalMessageCartable(UserLogin.CurrentUser.UserId, 5, lCID, result, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CInternalTaskTreeJs = JsonConvert.SerializeObject(list);
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult CInternalTaskMessages(int typeId = 0, int lastInternalMessageID = 0, int pageSize = 500)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspInternalMessageLoadShortUserMessageWithPaging_Result> list = new List<CRMspInternalMessageLoadShortUserMessageWithPaging_Result>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (typeId != 0)
			{
				list = Enumerable.ToList<CRMspInternalMessageLoadShortUserMessageWithPaging_Result>((IEnumerable<CRMspInternalMessageLoadShortUserMessageWithPaging_Result>)dbI.CRMspInternalMessageLoadShortUserMessageWithPaging(UserLogin.CurrentUser.UserId, typeId, lastInternalMessageID, pageSize, lCID, result, result2));
				foreach (CRMspInternalMessageLoadShortUserMessageWithPaging_Result item in list)
				{
					_ = item.msgdSendDateTime;
					DateTime.TryParse(item.msgdSendDateTime.ToString(), out var result3);
					item.SendDateTime = result3.ToString("yyyy/MM/dd HH:mm:ss");
				}
			}
			int messageId = 0;
			if (list.Count > 0)
			{
				messageId = Enumerable.FirstOrDefault<CRMspInternalMessageLoadShortUserMessageWithPaging_Result>((IEnumerable<CRMspInternalMessageLoadShortUserMessageWithPaging_Result>)list).InternalMessageID.GetValueOrDefault();
			}
			UpdateInternalMessage("Receive", messageId, typeId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CInternalTaskVerifyRequests = JsonConvert.SerializeObject(list);
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public bool ReadInternalMessage(int messageId, int typeId)
	{
		try
		{
			string date = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			string time = DateTime.Now.ToString("HH:mm:ss");
			int result = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
			}
			db.CRMspInternalMessageUpdate("Read", messageId, UserLogin.CurrentUser.UserId, typeId, time, date, Configuration.AppType, result);
			return true;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return false;
		}
	}

	public JsonResult ReadMultipleInternalMessage(string messageIdsJs = "")
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			if (!string.IsNullOrWhiteSpace(messageIdsJs))
			{
				list = new JavaScriptSerializer().Deserialize<List<SelectListItem>>(messageIdsJs);
				if (list != null && list.Count > 0)
				{
					foreach (SelectListItem item in list)
					{
						item.Selected = ReadInternalMessage(int.Parse(item.Value), int.Parse(item.Text));
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actcInternalTask")]
	public ActionResult CInternalMessage()
	{
		GetUserListInIntMsg();
		GetMsgUser();
		GetMsgdToUser();
		GetMsgdFromUser();
		GetMsgdType();
		return View();
	}

	[AjaxOnly]
	public JsonResult GetUserListInIntMsg()
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
			List<CRMspIntMsgUserAndLinkedUser_Result> list2 = Enumerable.ToList<CRMspIntMsgUserAndLinkedUser_Result>((IEnumerable<CRMspIntMsgUserAndLinkedUser_Result>)db.CRMspIntMsgUserAndLinkedUser(UserLogin.CurrentUser.UserId, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspIntMsgUserAndLinkedUser_Result, SelectListItem>((IEnumerable<CRMspIntMsgUserAndLinkedUser_Result>)list2, (Func<CRMspIntMsgUserAndLinkedUser_Result, SelectListItem>)((CRMspIntMsgUserAndLinkedUser_Result item) => new SelectListItem
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
		base.ViewBag.userList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public ActionResult _PartialCInternalMessageGroup(int selectedUserId, string fDate, string tDate)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		if (selectedUserId == 0)
		{
			selectedUserId = UserLogin.CurrentUser.UserId;
		}
		fDate = fDate.Replace("/", "");
		tDate = tDate.Replace("/", "");
		int result2 = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
		}
		List<CRMspIntMsgSelectInternalMessageGroup_Result> list = Enumerable.ToList<CRMspIntMsgSelectInternalMessageGroup_Result>((IEnumerable<CRMspIntMsgSelectInternalMessageGroup_Result>)db.CRMspIntMsgSelectInternalMessageGroup(selectedUserId, fDate, tDate, lCID, result, result2));
		List<TreeViewItemModel> list2 = new List<TreeViewItemModel>();
		foreach (CRMspIntMsgSelectInternalMessageGroup_Result item in list)
		{
			TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
			treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.RootID + "|" + item.InternalMessageGroupID));
			treeViewItemModel.Id = item.RootID + "|" + item.InternalMessageGroupID;
			treeViewItemModel.Text = item.InternalMessageGroup;
			treeViewItemModel.ImageUrl = "";
			treeViewItemModel.Items = null;
			list2.Add(treeViewItemModel);
		}
		base.ViewBag.treeIntMsgGroup = list2;
		return PartialView();
	}

	[DynamicAuthorize(ControllerName = "frmInternalMessage", ActionName = "actDeleteFull")]
	public string DeleteInternalMessage(int intMsgDetId, int mode)
	{
		string result = "";
		if (!UserLogin.IsUserAccess("frmInternalMessage", "actDeleteFull", UserLogin.CurrentUser))
		{
			return "-1";
		}
		try
		{
			result = ((intMsgDetId == 0) ? "0" : ((db.CRMspInternalMessageDelete(mode, intMsgDetId, UserLogin.CurrentUser.UserId) <= 0) ? "-2" : Messages.frmDeleteSuccessMessage));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmInternalMessage", ActionName = "actIsFinalized")]
	public string UpdateFinalizedmsg(int intMsgId)
	{
		string result = "";
		if (!UserLogin.IsUserAccess("frmInternalMessage", "actIsFinalized", UserLogin.CurrentUser))
		{
			return "-1";
		}
		try
		{
			if (intMsgId != 0 && db.CRMspIntMsgUpdateFinalizedmsg(1, intMsgId, Configuration.AppType) > 0)
			{
				result = "1";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmInternalMessage", ActionName = "actExitFinalized")]
	public string ExitFinalizedmsg(int intMsgId)
	{
		string result = "";
		if (!UserLogin.IsUserAccess("frmInternalMessage", "actExitFinalized", UserLogin.CurrentUser))
		{
			return "-1";
		}
		try
		{
			if (intMsgId != 0 && db.CRMspIntMsgUpdateFinalizedmsg(2, intMsgId, Configuration.AppType) > 0)
			{
				result = "1";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmInternalMessage", ActionName = "actViewMessageCycle")]
	public ActionResult CInternalMessageViewI(int messageTypeId, int messageId, string fromPlase)
	{
		if (messageTypeId == 1 || messageTypeId == 5 || messageTypeId == 6 || messageTypeId == 7 || messageTypeId == 8 || messageTypeId == 10 || messageTypeId == 12 || messageTypeId == 9 || messageTypeId == 14 || messageTypeId == 16 || messageTypeId == 45 || messageTypeId == 50 || messageTypeId == 55 || messageTypeId == 60 || messageTypeId == 17 || messageTypeId == 18 || messageTypeId == 19 || messageTypeId == 20 || messageTypeId == 21)
		{
			UpdateInternalMessage("Read", messageId, messageTypeId);
		}
		base.ViewBag.fromPlase = fromPlase;
		base.ViewBag.msgTypeId = messageTypeId;
		base.ViewBag.msgId = messageId;
		return View();
	}

	public ActionResult _PartialCInternalMessageViewI(int msgid, string kind, int msgTypeId, int fromPlase)
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
		CRMspIntMsgSelectMessageInTypeViewModel cRMspIntMsgSelectMessageInTypeViewModel = new CRMspIntMsgSelectMessageInTypeViewModel();
		List<CRMspIntMsgSelectMessageInType_Result> list = Enumerable.ToList<CRMspIntMsgSelectMessageInType_Result>((IEnumerable<CRMspIntMsgSelectMessageInType_Result>)db.CRMspIntMsgSelectMessageInType(msgid, UserLogin.CurrentUser.UserId, msgTypeId, lCID, result, result2));
		CRMspIntMsgSelectMessageInType_Result cRMspIntMsgSelectMessageInType_Result = null;
		cRMspIntMsgSelectMessageInType_Result = ((msgid == 0) ? Enumerable.FirstOrDefault<CRMspIntMsgSelectMessageInType_Result>(Enumerable.Take<CRMspIntMsgSelectMessageInType_Result>((IEnumerable<CRMspIntMsgSelectMessageInType_Result>)Enumerable.OrderByDescending<CRMspIntMsgSelectMessageInType_Result, int>((IEnumerable<CRMspIntMsgSelectMessageInType_Result>)list, (Func<CRMspIntMsgSelectMessageInType_Result, int>)((CRMspIntMsgSelectMessageInType_Result c) => c.InternalMessageID)), 1)) : ((kind == "next") ? (Enumerable.FirstOrDefault<CRMspIntMsgSelectMessageInType_Result>(Enumerable.Take<CRMspIntMsgSelectMessageInType_Result>(Enumerable.Where<CRMspIntMsgSelectMessageInType_Result>((IEnumerable<CRMspIntMsgSelectMessageInType_Result>)list, (Func<CRMspIntMsgSelectMessageInType_Result, bool>)((CRMspIntMsgSelectMessageInType_Result c) => c.InternalMessageID > msgid)), 1)) ?? Enumerable.First<CRMspIntMsgSelectMessageInType_Result>(Enumerable.Take<CRMspIntMsgSelectMessageInType_Result>((IEnumerable<CRMspIntMsgSelectMessageInType_Result>)Enumerable.OrderByDescending<CRMspIntMsgSelectMessageInType_Result, int>((IEnumerable<CRMspIntMsgSelectMessageInType_Result>)list, (Func<CRMspIntMsgSelectMessageInType_Result, int>)((CRMspIntMsgSelectMessageInType_Result c) => c.InternalMessageID)), 1))) : ((!(kind == "prev")) ? Enumerable.FirstOrDefault<CRMspIntMsgSelectMessageInType_Result>((IEnumerable<CRMspIntMsgSelectMessageInType_Result>)list, (Func<CRMspIntMsgSelectMessageInType_Result, bool>)((CRMspIntMsgSelectMessageInType_Result c) => c.InternalMessageID == msgid)) : (Enumerable.FirstOrDefault<CRMspIntMsgSelectMessageInType_Result>(Enumerable.Take<CRMspIntMsgSelectMessageInType_Result>((IEnumerable<CRMspIntMsgSelectMessageInType_Result>)Enumerable.OrderByDescending<CRMspIntMsgSelectMessageInType_Result, int>(Enumerable.Where<CRMspIntMsgSelectMessageInType_Result>((IEnumerable<CRMspIntMsgSelectMessageInType_Result>)list, (Func<CRMspIntMsgSelectMessageInType_Result, bool>)((CRMspIntMsgSelectMessageInType_Result c) => c.InternalMessageID < msgid)), (Func<CRMspIntMsgSelectMessageInType_Result, int>)((CRMspIntMsgSelectMessageInType_Result c) => c.InternalMessageID)), 1)) ?? Enumerable.First<CRMspIntMsgSelectMessageInType_Result>(Enumerable.Take<CRMspIntMsgSelectMessageInType_Result>((IEnumerable<CRMspIntMsgSelectMessageInType_Result>)list, 1))))));
		if (cRMspIntMsgSelectMessageInType_Result == null)
		{
			cRMspIntMsgSelectMessageInType_Result = new CRMspIntMsgSelectMessageInType_Result
			{
				RegisterDate = DateTime.Now,
				InternalMessageID = 0
			};
		}
		else if (cRMspIntMsgSelectMessageInType_Result.msgdTypeId == 12)
		{
			UpdateInternalMessage("Read", cRMspIntMsgSelectMessageInType_Result.InternalMessageID, cRMspIntMsgSelectMessageInType_Result.msgdTypeId);
		}
		cRMspIntMsgSelectMessageInTypeViewModel.InternalMessageID = cRMspIntMsgSelectMessageInType_Result.InternalMessageID;
		cRMspIntMsgSelectMessageInTypeViewModel.msgSubject = cRMspIntMsgSelectMessageInType_Result.msgSubject;
		cRMspIntMsgSelectMessageInTypeViewModel.msgBody = cRMspIntMsgSelectMessageInType_Result.msgBody;
		cRMspIntMsgSelectMessageInTypeViewModel.InternalMessageDetailID = cRMspIntMsgSelectMessageInType_Result.InternalMessageDetailID;
		cRMspIntMsgSelectMessageInTypeViewModel.msgdTypeId = cRMspIntMsgSelectMessageInType_Result.msgdTypeId;
		cRMspIntMsgSelectMessageInTypeViewModel.MessageType = cRMspIntMsgSelectMessageInType_Result.MessageType;
		cRMspIntMsgSelectMessageInTypeViewModel.msgMasterId = cRMspIntMsgSelectMessageInType_Result.msgMasterId;
		cRMspIntMsgSelectMessageInTypeViewModel.msgdFromUserId = cRMspIntMsgSelectMessageInType_Result.msgdFromUserId;
		cRMspIntMsgSelectMessageInTypeViewModel.FROMUser = cRMspIntMsgSelectMessageInType_Result.FROMUser;
		cRMspIntMsgSelectMessageInTypeViewModel.msgdToUserId = cRMspIntMsgSelectMessageInType_Result.msgdToUserId;
		cRMspIntMsgSelectMessageInTypeViewModel.ToUser = cRMspIntMsgSelectMessageInType_Result.ToUser;
		cRMspIntMsgSelectMessageInTypeViewModel.ToOtherUser = cRMspIntMsgSelectMessageInType_Result.ToOtherUser;
		cRMspIntMsgSelectMessageInTypeViewModel.ToAndOtherUser = cRMspIntMsgSelectMessageInType_Result.ToAndOtherUser;
		cRMspIntMsgSelectMessageInTypeViewModel.msgdSendDate = cRMspIntMsgSelectMessageInType_Result.msgdSendDate;
		cRMspIntMsgSelectMessageInTypeViewModel.msgdSendTime = cRMspIntMsgSelectMessageInType_Result.msgdSendTime;
		cRMspIntMsgSelectMessageInTypeViewModel.msgdSendDateTime = cRMspIntMsgSelectMessageInType_Result.msgdSendDateTime;
		cRMspIntMsgSelectMessageInTypeViewModel.SendDateTime = cRMspIntMsgSelectMessageInType_Result.SendDateTime;
		cRMspIntMsgSelectMessageInTypeViewModel.msgdReceiveDate = cRMspIntMsgSelectMessageInType_Result.msgdReceiveDate;
		cRMspIntMsgSelectMessageInTypeViewModel.msgdReceiveTime = cRMspIntMsgSelectMessageInType_Result.msgdReceiveTime;
		cRMspIntMsgSelectMessageInTypeViewModel.msgdReceiveDateTime = cRMspIntMsgSelectMessageInType_Result.msgdReceiveDateTime;
		cRMspIntMsgSelectMessageInTypeViewModel.ReceiveDateTime = cRMspIntMsgSelectMessageInType_Result.ReceiveDateTime;
		cRMspIntMsgSelectMessageInTypeViewModel.msgdIsRead = cRMspIntMsgSelectMessageInType_Result.msgdIsRead;
		cRMspIntMsgSelectMessageInTypeViewModel.msgdReadDate = cRMspIntMsgSelectMessageInType_Result.msgdReadDate;
		cRMspIntMsgSelectMessageInTypeViewModel.msgdReadDateTime = cRMspIntMsgSelectMessageInType_Result.msgdReadDateTime;
		cRMspIntMsgSelectMessageInTypeViewModel.msgdReadTime = cRMspIntMsgSelectMessageInType_Result.msgdReadTime;
		cRMspIntMsgSelectMessageInTypeViewModel.ReadDateTime = cRMspIntMsgSelectMessageInType_Result.ReadDateTime;
		cRMspIntMsgSelectMessageInTypeViewModel.msgdPriorityId = cRMspIntMsgSelectMessageInType_Result.msgdPriorityId;
		cRMspIntMsgSelectMessageInTypeViewModel.InternalMessagePriority = cRMspIntMsgSelectMessageInType_Result.InternalMessagePriority;
		cRMspIntMsgSelectMessageInTypeViewModel.msgdIsDraft = cRMspIntMsgSelectMessageInType_Result.msgdIsDraft;
		cRMspIntMsgSelectMessageInTypeViewModel.msgdIsDeleted = cRMspIntMsgSelectMessageInType_Result.msgdIsDeleted;
		cRMspIntMsgSelectMessageInTypeViewModel.msgdAttachFile = cRMspIntMsgSelectMessageInType_Result.msgdAttachFile;
		cRMspIntMsgSelectMessageInTypeViewModel.msgdAttachRecId = cRMspIntMsgSelectMessageInType_Result.msgdAttachRecId;
		cRMspIntMsgSelectMessageInTypeViewModel.msgdAttachRecDesc = cRMspIntMsgSelectMessageInType_Result.msgdAttachRecDesc;
		cRMspIntMsgSelectMessageInTypeViewModel.DocNumber = cRMspIntMsgSelectMessageInType_Result.DocNumber;
		cRMspIntMsgSelectMessageInTypeViewModel.OprID = cRMspIntMsgSelectMessageInType_Result.OprID;
		cRMspIntMsgSelectMessageInTypeViewModel.CompanyID = cRMspIntMsgSelectMessageInType_Result.CompanyID;
		cRMspIntMsgSelectMessageInTypeViewModel.ProjectID = cRMspIntMsgSelectMessageInType_Result.ProjectID;
		cRMspIntMsgSelectMessageInTypeViewModel.msgdGroupId = cRMspIntMsgSelectMessageInType_Result.msgdGroupId;
		cRMspIntMsgSelectMessageInTypeViewModel.InternalMessageGroup = cRMspIntMsgSelectMessageInType_Result.InternalMessageGroup;
		cRMspIntMsgSelectMessageInTypeViewModel.UserId = cRMspIntMsgSelectMessageInType_Result.UserId;
		cRMspIntMsgSelectMessageInTypeViewModel.Year1 = cRMspIntMsgSelectMessageInType_Result.Year1;
		cRMspIntMsgSelectMessageInTypeViewModel.Month1 = cRMspIntMsgSelectMessageInType_Result.Month1;
		cRMspIntMsgSelectMessageInTypeViewModel.RegisterDate = cRMspIntMsgSelectMessageInType_Result.RegisterDate;
		cRMspIntMsgSelectMessageInTypeViewModel.RegisterDatePersian = cRMspIntMsgSelectMessageInType_Result.RegisterDatePersian;
		cRMspIntMsgSelectMessageInTypeViewModel.msgActiveInCycle = cRMspIntMsgSelectMessageInType_Result.msgActiveInCycle;
		cRMspIntMsgSelectMessageInTypeViewModel.msgLastGroupId = cRMspIntMsgSelectMessageInType_Result.msgLastGroupId;
		cRMspIntMsgSelectMessageInTypeViewModel.msgIsFinalised = cRMspIntMsgSelectMessageInType_Result.msgIsFinalised;
		cRMspIntMsgSelectMessageInTypeViewModel.msgdAttachRecIdI = cRMspIntMsgSelectMessageInType_Result.msgdAttachRecIdI;
		cRMspIntMsgSelectMessageInTypeViewModel.msgdAttachRecDescI = cRMspIntMsgSelectMessageInType_Result.msgdAttachRecDescI;
		base.ViewBag.msgTypeId = cRMspIntMsgSelectMessageInType_Result.msgdTypeId;
		base.ViewBag.fromPlase = fromPlase;
		base.ViewBag.intMsgId = cRMspIntMsgSelectMessageInType_Result.InternalMessageID;
		return PartialView(cRMspIntMsgSelectMessageInTypeViewModel);
	}

	public ActionResult IntMsgGetBodyInfoI_Read([DataSourceRequest] DataSourceRequest request, int intMsgId, int msgTypeId)
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
		List<CRMspIntMsgSelectMessageInTypeViewModel> list = new List<CRMspIntMsgSelectMessageInTypeViewModel>();
		if (intMsgId == 0)
		{
			return Json(((IEnumerable)list).ToDataSourceResult(request));
		}
		foreach (CRMspIntMsgSelectMessageInType_Result item in Enumerable.ToList<CRMspIntMsgSelectMessageInType_Result>((IEnumerable<CRMspIntMsgSelectMessageInType_Result>)db.CRMspIntMsgSelectMessageInType(intMsgId, UserLogin.CurrentUser.UserId, msgTypeId, lCID, result, result2)))
		{
			CRMspIntMsgSelectMessageInTypeViewModel cRMspIntMsgSelectMessageInTypeViewModel = new CRMspIntMsgSelectMessageInTypeViewModel();
			cRMspIntMsgSelectMessageInTypeViewModel.msgBody = item.msgBody;
			list.Add(cRMspIntMsgSelectMessageInTypeViewModel);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	public string CheckUnReadMessageVerify()
	{
		string text = "";
		try
		{
			int result = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)Enumerable.ToList<int?>((IEnumerable<int?>)db.CRMspIntMsgGetUnReadMessge(UserLogin.CurrentUser.UserId, result)));
			CRMspIntMsgGetUnReadVerify_Result cRMspIntMsgGetUnReadVerify_Result = Enumerable.FirstOrDefault<CRMspIntMsgGetUnReadVerify_Result>((IEnumerable<CRMspIntMsgGetUnReadVerify_Result>)Enumerable.ToList<CRMspIntMsgGetUnReadVerify_Result>((IEnumerable<CRMspIntMsgGetUnReadVerify_Result>)db.CRMspIntMsgGetUnReadVerify(UserLogin.CurrentUser.UserId, result)));
			int valueOrDefault = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbII.CRMspGetUnReadSmsReceiveCnt()).GetValueOrDefault();
			if (num.HasValue)
			{
				int? num2 = num;
				text = num2 + "|";
			}
			else
			{
				text = "0|";
			}
			if (cRMspIntMsgGetUnReadVerify_Result != null && cRMspIntMsgGetUnReadVerify_Result.Cnt.HasValue)
			{
				text = text + cRMspIntMsgGetUnReadVerify_Result.Cnt + "|";
				text = text + cRMspIntMsgGetUnReadVerify_Result.msgdTypeId + "|";
				text = text + cRMspIntMsgGetUnReadVerify_Result.InternalMessageID + "|";
			}
			else
			{
				text += "0|0|0|";
			}
			text += valueOrDefault;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actcTimeAttendance")]
	public ActionResult CTimeAttendance()
	{
		base.ViewBag.ShiftWorkingAndTimesTree_Json = GetShiftWorkingAndTimesTree_Json();
		return View();
	}

	[HttpPost]
	[LoginAuthorize]
	public List<CRMspUserTreeTimeAttendanceCartable_Result> UserTreeTimeAttendanceCartable()
	{
		List<CRMspUserTreeTimeAttendanceCartable_Result> list = new List<CRMspUserTreeTimeAttendanceCartable_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			short.Parse(Financial.Get().Id.ToString());
			_ = Financial.Get().Id;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspUserTreeTimeAttendanceCartable_Result> list2 = Enumerable.ToList<CRMspUserTreeTimeAttendanceCartable_Result>((IEnumerable<CRMspUserTreeTimeAttendanceCartable_Result>)db.CRMspUserTreeTimeAttendanceCartable(userId, 29, lCID, result, result2));
			if (list2 != null)
			{
				list.Add(new CRMspUserTreeTimeAttendanceCartable_Result
				{
					KeyId = -1,
					KeyName = Labels.AllUsers
				});
				list.AddRange(list2);
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
	public string UserTreeTimeAttendanceCartableJs()
	{
		return JsonConvert.SerializeObject(UserTreeTimeAttendanceCartable());
	}

	[HttpPost]
	[LoginAuthorize]
	public List<CRMResultsTimeAttendanceCartableViewModel> ResultsTimeAttendanceCartable(int selectedUserId = 0, string fDate = "", string tDate = "", int shiftWorkingTimeId = 0, int shiftWorkingId = 0)
	{
		List<CRMResultsTimeAttendanceCartableViewModel> list = new List<CRMResultsTimeAttendanceCartableViewModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			_ = UserLogin.CurrentUser.UserId;
			short.Parse(Financial.Get().Id.ToString());
			_ = Financial.Get().Id;
			DateTime value = DateTime.Now;
			if (!string.IsNullOrWhiteSpace(fDate))
			{
				try
				{
					fDate = PersianDate.GetFormatetdDate(fDate.Replace("/", ""));
					value = lCID switch
					{
						1065 => DateTime.Parse(fDate + " 06:00:00", new PersianCulture()), 
						1025 => DateTime.Parse(fDate + " 06:00:00", new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(fDate + " 06:00:00", new CultureInfo("en-US")), 
					};
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
			}
			DateTime value2 = DateTime.Now;
			if (!string.IsNullOrWhiteSpace(tDate))
			{
				try
				{
					tDate = PersianDate.GetFormatetdDate(tDate.Replace("/", ""));
					value2 = lCID switch
					{
						1065 => DateTime.Parse(tDate + " 18:00:00", new PersianCulture()), 
						1025 => DateTime.Parse(tDate + " 18:00:00", new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(tDate + " 18:00:00", new CultureInfo("en-US")), 
					};
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
				}
			}
			bool smartTimeAttendance = VersionBuyer.SmartTimeAttendance;
			ObjectParameter executedQuery = new ObjectParameter("ExecutedQuery", "");
			List<CRMspResultsTimeAttendanceCartable_Result> list2 = Enumerable.ToList<CRMspResultsTimeAttendanceCartable_Result>((IEnumerable<CRMspResultsTimeAttendanceCartable_Result>)dbI.CRMspResultsTimeAttendanceCartable(value, value2, DateTime.Now, selectedUserId, UserLogin.CurrentUser.UserId, lCID, result, executedQuery, shiftWorkingTimeId, smartTimeAttendance, shiftWorkingId));
			if (list2 != null)
			{
				foreach (CRMspResultsTimeAttendanceCartable_Result item in list2)
				{
					string tmEntryChanges = "";
					string tmExitChanges = "";
					if (item.tmEntryTimeVerifyUserId.GetValueOrDefault() != 0)
					{
						tmEntryChanges = item.tmEntryTimeVerifyUser + " " + item.tmEntryTimeVerifyDate?.ToString("yyyy/MM/dd HH:mm:ss");
					}
					if (item.tmExitTimeVerifyUserId.GetValueOrDefault() != 0)
					{
						tmExitChanges = item.tmExitTimeVerifyUser + " " + item.tmExitTimeVerifyDate?.ToString("yyyy/MM/dd HH:mm:ss");
					}
					int num = 0;
					string tmEntryDelayStr = "";
					num = item.tmEntryDelay.GetValueOrDefault();
					if (num != 0)
					{
						if (num <= 0)
						{
							num *= -1;
						}
						tmEntryDelayStr = TimeSpan.FromMinutes(num).ToString();
					}
					if (!string.IsNullOrWhiteSpace(item.IsClosedDesc) && item.IsClosedDesc.EndsWith(" - "))
					{
						item.IsClosedDesc = item.IsClosedDesc.Substring(0, item.IsClosedDesc.Length - 3);
					}
					CRMResultsTimeAttendanceCartableViewModel cRMResultsTimeAttendanceCartableViewModel = new CRMResultsTimeAttendanceCartableViewModel
					{
						TimeAttendanceId = item.TimeAttendanceId,
						tmDayName = item.DayName,
						tmUserId = item.tmUserId.GetValueOrDefault(),
						tmUser = item.tmUser,
						tmDate = item.tmDate,
						tmEntryBase = item.tmEntryBase,
						tmEntryTime = item.tmEntryTime,
						tmEntryBaseStr = (item.tmEntryBase.HasValue ? ConverDateTimeToTime(item.tmEntryBase) : ""),
						tmEntryTimeStr = (item.tmEntryTime.HasValue ? ConverDateTimeToTime(item.tmEntryTime) : ""),
						tmEntryDelay = item.tmEntryDelay.GetValueOrDefault(),
						tmEntryDelayStr = tmEntryDelayStr,
						tmEntryDelayAllowMin = item.tmEntryDelayAllowMin.GetValueOrDefault(),
						DelayMinusAllow = item.DelayMinusAllow,
						tmEntryRegisterIP = item.tmEntryRegisterIP,
						tmExitBase = item.tmExitBase,
						tmExitTime = item.tmExitTime,
						tmExitBaseStr = (item.tmExitBase.HasValue ? ConverDateTimeToTime(item.tmExitBase) : ""),
						tmExitTimeStr = (item.tmExitTime.HasValue ? ConverDateTimeToTime(item.tmExitTime) : ""),
						tmExitHurry = item.tmExitHurry,
						tmExitHurryAllowMin = item.tmExitHurryAllowMin,
						HurryMinusAllow = item.HurryMinusAllow,
						tmExitRegisterIP = item.tmExitRegisterIP,
						tmDateStr = item.tmDate?.ToString("yyyy/MM/dd  dddd"),
						tmDateOnlyStr = item.tmDate?.ToString("yyyy/MM/dd"),
						AppType = item.AppType,
						tmEntryChanges = tmEntryChanges,
						tmExitChanges = tmExitChanges,
						IsClosed = item.IsClosed,
						IsClosedDesc = item.IsClosedDesc,
						IsAbsent = item.IsAbsent,
						IsWeekend = item.IsWeekend,
						EntryDiff = item.EntryDiff,
						EntryDiffSign = item.EntryDiffSign,
						EntryDiffMinute = item.EntryDiffMinute,
						EntryDiffSecond = item.EntryDiffSecond,
						ExitDiff = item.ExitDiff,
						ExitDiffSign = item.ExitDiffSign,
						ExitDiffMinute = item.ExitDiffMinute,
						ExitDiffSecond = item.ExitDiffSecond,
						HourlyLeaveInfoJs = item.HourlyLeaveInfoJs,
						DailyLeaveInfoJs = item.DailyLeaveInfoJs,
						HourlyMissionInfoJs = item.HourlyMissionInfoJs,
						DailyMissionInfoJs = item.DailyMissionInfoJs,
						IsNotArrivedDay = item.IsNotArrivedDay,
						tmLocalDate = (item.tmDate.HasValue ? DateTimeClass.GetLocalDate(item.tmDate).Value.ToString("yyyy/MM/dd") : ""),
						tmShiftWorkingTimeId = item.tmShiftWorkingTimeId,
						tmShiftWorkingId = item.tmShiftWorkingId,
						tmEntryLat = item.tmEntryLat,
						tmEntryLng = item.tmEntryLng,
						tmEntryZoom = item.tmEntryZoom,
						tmEntryIsTemp = item.tmEntryIsTemp,
						tmExitLat = item.tmExitLat,
						tmExitLng = item.tmExitLng,
						tmExitZoom = item.tmExitZoom,
						tmExitIsTemp = item.tmExitIsTemp,
						tmdEntryIsTempCnt = item.tmdEntryIsTempCnt,
						tmdExitIsTempCnt = item.tmdExitIsTempCnt
					};
					if (cRMResultsTimeAttendanceCartableViewModel.tmShiftWorkingTimeId.GetValueOrDefault() == 0)
					{
						cRMResultsTimeAttendanceCartableViewModel.IsAbsent = false;
					}
					list.Add(cRMResultsTimeAttendanceCartableViewModel);
				}
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
	public string ResultsTimeAttendanceCartableJs(int selectedUserId = 0, string fDate = "", string tDate = "", int shiftWorkingTimeId = 0, int shiftWorkingId = 0)
	{
		return JsonConvert.SerializeObject(ResultsTimeAttendanceCartable(selectedUserId, fDate, tDate, shiftWorkingTimeId, shiftWorkingId));
	}

	[HttpPost]
	[LoginAuthorize]
	public string GenerateDatesBetween(string fDate = "", string tDate = "")
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
			DateTime dateTime = DateTime.Now;
			if (!string.IsNullOrWhiteSpace(fDate))
			{
				try
				{
					fDate = PersianDate.GetFormatetdDate(fDate.Replace("/", ""));
					dateTime = lCID switch
					{
						1065 => DateTime.Parse(fDate + " 06:00:00", new PersianCulture()), 
						1025 => DateTime.Parse(fDate + " 06:00:00", new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(fDate + " 06:00:00", new CultureInfo("en-US")), 
					};
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
			}
			DateTime dateTime2 = DateTime.Now;
			if (!string.IsNullOrWhiteSpace(tDate))
			{
				try
				{
					tDate = PersianDate.GetFormatetdDate(tDate.Replace("/", ""));
					dateTime2 = lCID switch
					{
						1065 => DateTime.Parse(tDate + " 18:00:00", new PersianCulture()), 
						1025 => DateTime.Parse(tDate + " 18:00:00", new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(tDate + " 18:00:00", new CultureInfo("en-US")), 
					};
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
				}
			}
			string[] array = new string[7];
			array[6] = Labels.Saturday;
			array[0] = Labels.Sunday;
			array[1] = Labels.Monday;
			array[2] = Labels.Tuesday;
			array[3] = Labels.Wednesday;
			array[4] = Labels.Thursday;
			array[5] = Labels.Friday;
			while (dateTime <= dateTime2)
			{
				list.Add(new SelectListItem
				{
					Text = array[(int)dateTime2.DayOfWeek],
					Value = dateTime2.ToString("yyyy/MM/dd")
				});
				dateTime2 = dateTime2.AddDays(-1.0);
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return JsonConvert.SerializeObject(list);
	}

	[AjaxOnly]
	public ActionResult _PartialCTimeAttendance(string TADate)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = DateTime.Now.ToString("yyyy/MM/dd");
		_ = TADate == "";
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspUserTreeTimeAttendanceCartable_Result> list = Enumerable.ToList<CRMspUserTreeTimeAttendanceCartable_Result>((IEnumerable<CRMspUserTreeTimeAttendanceCartable_Result>)db.CRMspUserTreeTimeAttendanceCartable(UserLogin.CurrentUser.UserId, 29, lCID, result, result2));
			List<TreeViewItemModel> list2 = new List<TreeViewItemModel>
			{
				new TreeViewItemModel
				{
					HtmlAttributes = 
					{
						new KeyValuePair<string, string>("accesskey", "-1|-1")
					},
					Id = "-1|-1",
					Text = Labels.Empty,
					ImageUrl = "",
					Items = null
				}
			};
			foreach (CRMspUserTreeTimeAttendanceCartable_Result item in list)
			{
				TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
				treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.RootId + "|" + item.KeyId));
				treeViewItemModel.Id = item.RootId + "|" + item.KeyId;
				treeViewItemModel.Text = item.KeyName;
				treeViewItemModel.ImageUrl = "";
				treeViewItemModel.Items = null;
				list2.Add(treeViewItemModel);
			}
			base.ViewBag.CTimeAttendanceTree = list2;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult _PartialCTimeAttendanceGrid(int userId, string FDate, string TDate, int shiftWorkingTimeId = 0, int shiftWorkingId = 0)
	{
		if (userId == 0)
		{
			userId = UserLogin.CurrentUser.UserId;
		}
		string text = DateTime.Now.ToString("yyyy/MM/dd");
		DateTime now = DateTime.Now;
		new DateTime(now.Year, now.Month, 1);
		if (FDate == "")
		{
			FDate = text;
		}
		if (TDate == "")
		{
			TDate = text;
		}
		base.ViewBag.UserIdFTDate = userId + "|" + FDate + "|" + TDate + "|" + shiftWorkingTimeId + "|" + shiftWorkingId;
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult CTimeAttendance_Read([DataSourceRequest] DataSourceRequest request, string userIdFTDate)
	{
		string[] array = userIdFTDate.Split(new char[1] { '|' });
		List<CRMResultsTimeAttendanceCartableViewModel> list = new List<CRMResultsTimeAttendanceCartableViewModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (int.Parse(array[0]) != 0)
			{
				DateTime value = DateTime.Now;
				DateTime value2 = DateTime.Now;
				string text = array[1];
				string text2 = array[2];
				int value3 = int.Parse((!string.IsNullOrWhiteSpace(array[3])) ? array[3] : "0");
				int value4 = int.Parse((!string.IsNullOrWhiteSpace(array[4])) ? array[4] : "0");
				if (!string.IsNullOrWhiteSpace(text))
				{
					try
					{
						text = PersianDate.GetFormatetdDate(text.Replace("/", ""));
						value = lCID switch
						{
							1065 => DateTime.Parse(text + " 06:00:00", new PersianCulture()), 
							1025 => DateTime.Parse(text + " 06:00:00", new CultureInfo("ar-SA")), 
							_ => DateTime.Parse(text + " 06:00:00", new CultureInfo("en-US")), 
						};
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
					}
				}
				if (!string.IsNullOrWhiteSpace(text2))
				{
					try
					{
						text2 = PersianDate.GetFormatetdDate(text2.Replace("/", ""));
						value2 = lCID switch
						{
							1065 => DateTime.Parse(text2 + " 18:00:00", new PersianCulture()), 
							1025 => DateTime.Parse(text2 + " 18:00:00", new CultureInfo("ar-SA")), 
							_ => DateTime.Parse(text2 + " 18:00:00", new CultureInfo("en-US")), 
						};
					}
					catch (Exception e2)
					{
						ErrorSignal.FromCurrentContext().Raise(e2);
					}
				}
				ObjectParameter executedQuery = new ObjectParameter("ExecutedQuery", "");
				bool smartTimeAttendance = VersionBuyer.SmartTimeAttendance;
				foreach (CRMspResultsTimeAttendanceCartable_Result item2 in Enumerable.ToList<CRMspResultsTimeAttendanceCartable_Result>((IEnumerable<CRMspResultsTimeAttendanceCartable_Result>)dbI.CRMspResultsTimeAttendanceCartable(value, value2, DateTime.Now, int.Parse((!string.IsNullOrWhiteSpace(array[0])) ? array[0] : "0"), UserLogin.CurrentUser.UserId, lCID, result, executedQuery, value3, smartTimeAttendance, value4)))
				{
					string tmEntryChanges = "";
					string tmExitChanges = "";
					if (item2.tmEntryTimeVerifyUserId.GetValueOrDefault() != 0)
					{
						tmEntryChanges = item2.tmEntryTimeVerifyUser + " " + item2.tmEntryTimeVerifyDate?.ToString("yyyy/MM/dd HH:mm:ss");
					}
					if (item2.tmExitTimeVerifyUserId.GetValueOrDefault() != 0)
					{
						tmExitChanges = item2.tmExitTimeVerifyUser + " " + item2.tmExitTimeVerifyDate?.ToString("yyyy/MM/dd HH:mm:ss");
					}
					CRMResultsTimeAttendanceCartableViewModel item = new CRMResultsTimeAttendanceCartableViewModel
					{
						TimeAttendanceId = item2.TimeAttendanceId,
						tmUserId = item2.tmUserId.GetValueOrDefault(),
						tmDate = item2.tmDate,
						tmEntryBase = item2.tmEntryBase,
						tmEntryTime = item2.tmEntryTime,
						tmEntryBaseStr = (item2.tmEntryBase.HasValue ? ConverDateTimeToTime(item2.tmEntryBase) : ""),
						tmEntryTimeStr = (item2.tmEntryTime.HasValue ? ConverDateTimeToTime(item2.tmEntryTime) : ""),
						tmEntryDelay = item2.tmEntryDelay.GetValueOrDefault(),
						tmEntryDelayAllowMin = item2.tmEntryDelayAllowMin.GetValueOrDefault(),
						DelayMinusAllow = item2.DelayMinusAllow,
						tmEntryRegisterIP = item2.tmEntryRegisterIP,
						tmExitBase = item2.tmExitBase,
						tmExitTime = item2.tmExitTime,
						tmExitBaseStr = (item2.tmExitBase.HasValue ? ConverDateTimeToTime(item2.tmExitBase) : ""),
						tmExitTimeStr = (item2.tmExitTime.HasValue ? ConverDateTimeToTime(item2.tmExitTime) : ""),
						tmExitHurry = item2.tmExitHurry,
						tmExitHurryAllowMin = item2.tmExitHurryAllowMin,
						HurryMinusAllow = item2.HurryMinusAllow,
						tmExitRegisterIP = item2.tmExitRegisterIP,
						tmDateStr = item2.tmDate?.ToString("yyyy/MM/dd  dddd"),
						tmDateOnlyStr = item2.tmDate?.ToString("yyyy/MM/dd"),
						AppType = item2.AppType,
						tmEntryChanges = tmEntryChanges,
						tmExitChanges = tmExitChanges,
						EntryDiff = item2.EntryDiff,
						EntryDiffSign = item2.EntryDiffSign,
						EntryDiffMinute = item2.EntryDiffMinute,
						EntryDiffSecond = item2.EntryDiffSecond,
						ExitDiff = item2.ExitDiff,
						ExitDiffSign = item2.ExitDiffSign,
						ExitDiffMinute = item2.ExitDiffMinute,
						ExitDiffSecond = item2.ExitDiffSecond,
						HourlyLeaveInfoJs = item2.HourlyLeaveInfoJs,
						DailyLeaveInfoJs = item2.DailyLeaveInfoJs,
						HourlyMissionInfoJs = item2.HourlyMissionInfoJs,
						DailyMissionInfoJs = item2.DailyMissionInfoJs,
						IsNotArrivedDay = item2.IsNotArrivedDay
					};
					list.Add(item);
				}
			}
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request));
	}

	[AjaxOnly]
	public JsonResult CTimeAttendanceCartableFooter(int userId = 0, string fDate = "", string tDate = "", int shiftWorkingTimeId = 0, int shiftWorkingId = 0)
	{
		CRMspResultsTimeAttendanceCartableFooter_Result cRMspResultsTimeAttendanceCartableFooter_Result = new CRMspResultsTimeAttendanceCartableFooter_Result();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (userId != 0)
			{
				DateTime value = DateTime.Now;
				DateTime value2 = DateTime.Now;
				if (!string.IsNullOrWhiteSpace(fDate))
				{
					try
					{
						fDate = PersianDate.GetFormatetdDate(fDate.Replace("/", ""));
						value = lCID switch
						{
							1065 => DateTime.Parse(fDate + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()), 
							1025 => DateTime.Parse(fDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")), 
							_ => DateTime.Parse(fDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")), 
						};
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
					}
				}
				if (!string.IsNullOrWhiteSpace(tDate))
				{
					try
					{
						tDate = PersianDate.GetFormatetdDate(tDate.Replace("/", ""));
						value2 = lCID switch
						{
							1065 => DateTime.Parse(tDate + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()), 
							1025 => DateTime.Parse(tDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")), 
							_ => DateTime.Parse(tDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")), 
						};
					}
					catch (Exception e2)
					{
						ErrorSignal.FromCurrentContext().Raise(e2);
					}
				}
				bool smartTimeAttendance = VersionBuyer.SmartTimeAttendance;
				cRMspResultsTimeAttendanceCartableFooter_Result = Enumerable.FirstOrDefault<CRMspResultsTimeAttendanceCartableFooter_Result>((IEnumerable<CRMspResultsTimeAttendanceCartableFooter_Result>)dbI.CRMspResultsTimeAttendanceCartableFooter(value, value2, DateTime.Now, userId, UserLogin.CurrentUser.UserId, lCID, result, smartTimeAttendanceModule: smartTimeAttendance, shiftWorkingTimeId: shiftWorkingTimeId, shiftWorkingId: shiftWorkingId));
				if (cRMspResultsTimeAttendanceCartableFooter_Result != null)
				{
					int num = 0;
					num = cRMspResultsTimeAttendanceCartableFooter_Result.CalcEntryTimeDelay.GetValueOrDefault();
					if (num != 0)
					{
						if (num <= 0)
						{
							num *= -1;
						}
						cRMspResultsTimeAttendanceCartableFooter_Result.CalcEntryTimeDelayStr = ConvertTimeAttendanseFooterDates(num);
					}
					num = cRMspResultsTimeAttendanceCartableFooter_Result.CalcHurryExitTimeDelay.GetValueOrDefault();
					if (num != 0)
					{
						if (num <= 0)
						{
							num *= -1;
						}
						cRMspResultsTimeAttendanceCartableFooter_Result.CalcHurryExitTimeDelayStr = ConvertTimeAttendanseFooterDates(num);
					}
					num = cRMspResultsTimeAttendanceCartableFooter_Result.CalcOvertime.GetValueOrDefault();
					if (num != 0)
					{
						if (num <= 0)
						{
							num *= -1;
						}
						cRMspResultsTimeAttendanceCartableFooter_Result.CalcOvertimeStr = ConvertTimeAttendanseFooterDates(num);
					}
					num = cRMspResultsTimeAttendanceCartableFooter_Result.CalcSoonEntryTimeDelay.GetValueOrDefault();
					if (num != 0)
					{
						if (num <= 0)
						{
							num *= -1;
						}
						cRMspResultsTimeAttendanceCartableFooter_Result.CalcSoonEntryTimeDelayStr = ConvertTimeAttendanseFooterDates(num);
					}
					num = cRMspResultsTimeAttendanceCartableFooter_Result.AllHourlyLeaveTimeMinutes.GetValueOrDefault();
					if (num != 0)
					{
						if (num <= 0)
						{
							num *= -1;
						}
						cRMspResultsTimeAttendanceCartableFooter_Result.AllHourlyLeaveTimeMinutesStr = ConvertTimeAttendanseFooterDates(num);
					}
					num = cRMspResultsTimeAttendanceCartableFooter_Result.AllHourlyMissionTimeMinutes.GetValueOrDefault();
					if (num != 0)
					{
						if (num <= 0)
						{
							num *= -1;
						}
						cRMspResultsTimeAttendanceCartableFooter_Result.AllHourlyMissionTimeMinutesStr = ConvertTimeAttendanseFooterDates(num);
					}
					num = System.Math.Abs(cRMspResultsTimeAttendanceCartableFooter_Result.AllIsCloseWorkTimeMinutes.GetValueOrDefault());
					if (num != 0)
					{
						cRMspResultsTimeAttendanceCartableFooter_Result.AllIsCloseWorkTimeMinutesStr = ConvertTimeAttendanseFooterDates(num);
					}
					num = System.Math.Abs(cRMspResultsTimeAttendanceCartableFooter_Result.LeaveSoonEntryTimeMinutes.GetValueOrDefault());
					if (num != 0)
					{
						cRMspResultsTimeAttendanceCartableFooter_Result.LeaveSoonEntryTimeMinutesStr = ConvertTimeAttendanseFooterDates(num);
					}
					num = System.Math.Abs(cRMspResultsTimeAttendanceCartableFooter_Result.LeaveLateEntryTimeMinutes.GetValueOrDefault());
					if (num != 0)
					{
						cRMspResultsTimeAttendanceCartableFooter_Result.LeaveLateEntryTimeMinutesStr = ConvertTimeAttendanseFooterDates(num);
					}
					num = System.Math.Abs(cRMspResultsTimeAttendanceCartableFooter_Result.LeaveHurryExitTimeMinutes.GetValueOrDefault());
					if (num != 0)
					{
						cRMspResultsTimeAttendanceCartableFooter_Result.LeaveHurryExitTimeMinutesStr = ConvertTimeAttendanseFooterDates(num);
					}
					num = System.Math.Abs(cRMspResultsTimeAttendanceCartableFooter_Result.LeaveOvertimeExitTimeMinutes.GetValueOrDefault());
					if (num != 0)
					{
						cRMspResultsTimeAttendanceCartableFooter_Result.LeaveOvertimeExitTimeMinutesStr = ConvertTimeAttendanseFooterDates(num);
					}
					num = System.Math.Abs(cRMspResultsTimeAttendanceCartableFooter_Result.MissionSoonEntryTimeMinutes.GetValueOrDefault());
					if (num != 0)
					{
						cRMspResultsTimeAttendanceCartableFooter_Result.MissionSoonEntryTimeMinutesStr = ConvertTimeAttendanseFooterDates(num);
					}
					num = System.Math.Abs(cRMspResultsTimeAttendanceCartableFooter_Result.MissionLateEntryTimeMinutes.GetValueOrDefault());
					if (num != 0)
					{
						cRMspResultsTimeAttendanceCartableFooter_Result.MissionLateEntryTimeMinutesStr = ConvertTimeAttendanseFooterDates(num);
					}
					num = System.Math.Abs(cRMspResultsTimeAttendanceCartableFooter_Result.MissionHurryExitTimeMinutes.GetValueOrDefault());
					if (num != 0)
					{
						cRMspResultsTimeAttendanceCartableFooter_Result.MissionHurryExitTimeMinutesStr = ConvertTimeAttendanseFooterDates(num);
					}
					num = System.Math.Abs(cRMspResultsTimeAttendanceCartableFooter_Result.MissionOvertimeExitTimeMinutes.GetValueOrDefault());
					if (num != 0)
					{
						cRMspResultsTimeAttendanceCartableFooter_Result.MissionOvertimeExitTimeMinutesStr = ConvertTimeAttendanseFooterDates(num);
					}
				}
			}
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		return Json(cRMspResultsTimeAttendanceCartableFooter_Result, JsonRequestBehavior.AllowGet);
	}

	public string ConvertTimeAttendanseFooterDates(int tm = 0)
	{
		string text = "";
		if (tm != 0)
		{
			text = TimeSpan.FromMinutes(tm).ToString().Replace("0000/00/00 00:", "")
				.Replace("0000/00/00 ", "")
				.Replace("0000/00/", "")
				.Replace("0000/", "")
				.Trim();
			if (text.Contains("."))
			{
				string[] array = text.Split(new char[1] { '.' });
				string s = array[0].Split(new char[1] { '/' })[^1];
				text.Split(new char[1] { '.' });
				string[] array2 = array[1].Split(new char[1] { ':' });
				string s2 = array2[0];
				text = int.Parse(s) * 24 + int.Parse(s2) + ":" + array2[1] + ":" + array2[2];
			}
		}
		return text;
	}

	public string ConverDateTimeToTime(DateTime? date)
	{
		DateTime result = default(DateTime);
		string result2 = "";
		if (date.HasValue)
		{
			DateTime.TryParse(date.ToString(), out result);
			result2 = result.ToString("HH:mm:ss");
		}
		return result2;
	}

	public string GetShiftWorkingAndTimesTree_Json()
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
			int result3 = 0;
			int value = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
				value = UserLogin.CurrentUser.UserId;
			}
			List<CRMspShiftWorkingTreeTimeAttendanceCartable_Result> list = new List<CRMspShiftWorkingTreeTimeAttendanceCartable_Result>();
			List<CRMspShiftWorkingTreeTimeAttendanceCartable_Result> list2 = Enumerable.ToList<CRMspShiftWorkingTreeTimeAttendanceCartable_Result>((IEnumerable<CRMspShiftWorkingTreeTimeAttendanceCartable_Result>)_dbII.CRMspShiftWorkingTreeTimeAttendanceCartable(value, 29, result3, lCID, result2));
			if (list2 != null)
			{
				list.AddRange(list2);
			}
			result = JsonConvert.SerializeObject(list);
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	public ActionResult CTimeAttendanceInsertEdit(int tmId = 0, string tmDate = "", int tmUserId = 0, int? swtId = null)
	{
		TimeAttendanceLanguageViewModel model = new TimeAttendanceLanguageViewModel();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime? tmDateTime = DateTimeClass.GetDateFromPersian(tmDate);
			if (tmId != 0)
			{
				CRMspSelectTimeAttendanceById_Result cRMspSelectTimeAttendanceById_Result = Enumerable.FirstOrDefault<CRMspSelectTimeAttendanceById_Result>((IEnumerable<CRMspSelectTimeAttendanceById_Result>)_dbII.CRMspSelectTimeAttendanceById(tmId, lCID, result));
				if (cRMspSelectTimeAttendanceById_Result != null)
				{
					string tmEntryChanges = "";
					string tmExitChanges = "";
					if (cRMspSelectTimeAttendanceById_Result.tmEntryTimeVerifyUserId.GetValueOrDefault() != 0)
					{
						tmEntryChanges = cRMspSelectTimeAttendanceById_Result.tmEntryTimeVerifyUser + " " + cRMspSelectTimeAttendanceById_Result.tmEntryTimeVerifyDate?.ToString("yyyy/MM/dd HH:mm:ss");
					}
					if (cRMspSelectTimeAttendanceById_Result.tmExitTimeVerifyUserId.GetValueOrDefault() != 0)
					{
						tmExitChanges = cRMspSelectTimeAttendanceById_Result.tmExitTimeVerifyUser + " " + cRMspSelectTimeAttendanceById_Result.tmExitTimeVerifyDate?.ToString("yyyy/MM/dd HH:mm:ss");
					}
					model = new TimeAttendanceLanguageViewModel
					{
						TimeAttendanceId = cRMspSelectTimeAttendanceById_Result.TimeAttendanceId,
						tmDate = cRMspSelectTimeAttendanceById_Result.tmDate,
						tmDatePersian = cRMspSelectTimeAttendanceById_Result.tmDate.ToString("yyyy/MM/dd"),
						tmUser = cRMspSelectTimeAttendanceById_Result.tmUser,
						tmUserId = cRMspSelectTimeAttendanceById_Result.tmUserId,
						tmEntryBase = cRMspSelectTimeAttendanceById_Result.tmEntryBase?.ToString("HH:mm"),
						tmEntryTime = ((!cRMspSelectTimeAttendanceById_Result.tmEntryTime.HasValue) ? null : cRMspSelectTimeAttendanceById_Result.tmEntryTime?.ToString("HH:mm")),
						tmEntryDelay = cRMspSelectTimeAttendanceById_Result.tmEntryDelay,
						tmEntryDelayStr = DateTimeClass.GetMinuteInFormat(cRMspSelectTimeAttendanceById_Result.tmEntryDelay),
						tmExitBase = ((!cRMspSelectTimeAttendanceById_Result.tmExitBase.HasValue) ? null : cRMspSelectTimeAttendanceById_Result.tmExitBase.Value.ToString("HH:mm")),
						tmExitTime = ((!cRMspSelectTimeAttendanceById_Result.tmExitTime.HasValue) ? null : cRMspSelectTimeAttendanceById_Result.tmExitTime.Value.ToString("HH:mm")),
						tmExitHurry = cRMspSelectTimeAttendanceById_Result.tmExitHurry,
						tmExitHurryStr = DateTimeClass.GetMinuteInFormat(cRMspSelectTimeAttendanceById_Result.tmExitHurry.GetValueOrDefault()),
						tmEntryRegisterIP = cRMspSelectTimeAttendanceById_Result.tmEntryRegisterIP,
						tmExitRegisterIP = cRMspSelectTimeAttendanceById_Result.tmExitRegisterIP,
						tmEntryChanges = tmEntryChanges,
						tmExitChanges = tmExitChanges,
						tmShiftWorkingTimeId = cRMspSelectTimeAttendanceById_Result.tmShiftWorkingTimeId,
						tmLeaveId = cRMspSelectTimeAttendanceById_Result.tmLeaveId,
						tmLeaveTypeId = cRMspSelectTimeAttendanceById_Result.tmLeaveTypeId,
						tmLeaveType = cRMspSelectTimeAttendanceById_Result.tmLeaveType,
						tmExitHurryAllowMin = cRMspSelectTimeAttendanceById_Result.tmExitHurryAllowMin,
						tmEntryDelayAllowMin = cRMspSelectTimeAttendanceById_Result.tmEntryDelayAllowMin,
						tmEntryIsTemp = cRMspSelectTimeAttendanceById_Result.tmEntryIsTemp,
						tmExitIsTemp = cRMspSelectTimeAttendanceById_Result.tmExitIsTemp
					};
				}
			}
			else if (!string.IsNullOrEmpty(tmDate))
			{
				CRMspSelectShiftWorkingTimeById_Result cRMspSelectShiftWorkingTimeById_Result = Enumerable.FirstOrDefault<CRMspSelectShiftWorkingTimeById_Result>((IEnumerable<CRMspSelectShiftWorkingTimeById_Result>)_dbII.CRMspSelectShiftWorkingTimeById(swtId, lCID, result));
				ShiftWorkingDayViewModel shiftWorkingDayViewModel = new ShiftWorkingDayViewModel();
				if (cRMspSelectShiftWorkingTimeById_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectShiftWorkingTimeById_Result.swtWeekDays))
				{
					List<ShiftWorkingDayViewModel> list = JsonConvert.DeserializeObject<List<ShiftWorkingDayViewModel>>(cRMspSelectShiftWorkingTimeById_Result.swtWeekDays);
					if (list != null)
					{
						ShiftWorkingDayViewModel shiftWorkingDayViewModel2 = Enumerable.FirstOrDefault<ShiftWorkingDayViewModel>((IEnumerable<ShiftWorkingDayViewModel>)list, (Func<ShiftWorkingDayViewModel, bool>)((ShiftWorkingDayViewModel x) => x.DayNum == (int)(tmDateTime?.DayOfWeek).Value));
						if (shiftWorkingDayViewModel2 != null)
						{
							shiftWorkingDayViewModel = shiftWorkingDayViewModel2;
						}
					}
				}
				int? tmEntryDelayAllowMin = null;
				if (!string.IsNullOrWhiteSpace(shiftWorkingDayViewModel.EntryTimeLate))
				{
					tmEntryDelayAllowMin = int.Parse(shiftWorkingDayViewModel.EntryTimeLate.Split(new char[1] { ':' })[0]) * 60 + int.Parse(shiftWorkingDayViewModel.EntryTimeLate.Split(new char[1] { ':' })[1]);
				}
				int? tmExitHurryAllowMin = null;
				if (!string.IsNullOrWhiteSpace(shiftWorkingDayViewModel.ExitTimeSoon))
				{
					tmExitHurryAllowMin = int.Parse(shiftWorkingDayViewModel.ExitTimeSoon.Split(new char[1] { ':' })[0]) * 60 + int.Parse(shiftWorkingDayViewModel.ExitTimeSoon.Split(new char[1] { ':' })[1]);
				}
				model = new TimeAttendanceLanguageViewModel
				{
					tmDatePersian = tmDate,
					tmUserId = tmUserId,
					tmUser = CRMIdeal.Classes.Helper.User.GetUserName(tmUserId, result, lCID),
					tmShiftWorkingTimeId = swtId,
					tmEntryBase = shiftWorkingDayViewModel.EntryTime,
					tmExitBase = shiftWorkingDayViewModel.ExitTime,
					tmEntryDelayAllowMin = tmEntryDelayAllowMin,
					tmExitHurryAllowMin = tmExitHurryAllowMin
				};
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(model);
	}

	[HttpPost]
	[LoginAuthorize]
	public JsonResult CTimeAttendanceInsertEdit(TimeAttendanceLanguageViewModel model)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel();
		commonReturnResultViewModel.IsDone = false;
		commonReturnResultViewModel.MessageExtra = "";
		int num = 0;
		try
		{
			if (string.IsNullOrEmpty(model.tmDatePersian))
			{
				commonReturnResultViewModel.Message = Messages.msgErrorEnterDate;
				commonReturnResultViewModel.IsDone = false;
				num++;
				return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
			}
			if (string.IsNullOrEmpty(model.tmEntryTime))
			{
				commonReturnResultViewModel.Message = Messages.msgCtmEntryTimeRequired;
				commonReturnResultViewModel.IsDone = false;
				num++;
				return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
			}
			if (!string.IsNullOrEmpty(model.tmEntryTime))
			{
				model.tmEntryTime += ":00";
			}
			if (!string.IsNullOrEmpty(model.tmExitTime))
			{
				model.tmExitTime += ":00";
			}
			DateTime? dateTime = null;
			string text = null;
			DateTime? dateTime2 = null;
			DateTime? dateTime3 = null;
			DateTime dateTime4 = default(DateTime);
			string text2 = "";
			try
			{
				if (!string.IsNullOrEmpty(model.tmDatePersian))
				{
					text2 = PersianDate.GetFormatetdDate(model.tmDatePersian.Replace("/", ""));
					if (lCID == 1065)
					{
						dateTime4 = DateTime.Parse(text2 + " " + model.tmEntryTime, new PersianCulture());
						text = dateTime4.ToString("yyyyMMdd");
					}
					else
					{
						dateTime4 = DateTime.Parse(text2 + " " + model.tmEntryTime, new CultureInfo("en-US"));
						text = dateTime4.ToString("yyyyMMdd");
					}
					dateTime = dateTime4;
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				commonReturnResultViewModel.Message = Messages.ErrorFormatDatePersian;
				commonReturnResultViewModel.IsDone = false;
				num++;
				return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
			}
			try
			{
				if (!string.IsNullOrEmpty(model.tmEntryTime))
				{
					text2 = PersianDate.GetFormatetdDate(text.Replace("/", ""));
					dateTime4 = ((lCID != 1065) ? DateTime.Parse(text2 + " " + model.tmEntryTime, new CultureInfo("en-US")) : DateTime.Parse(text2 + " " + model.tmEntryTime, new PersianCulture()));
					dateTime2 = dateTime4;
				}
			}
			catch (Exception e2)
			{
				ErrorSignal.FromCurrentContext().Raise(e2);
				commonReturnResultViewModel.Message = Messages.ErrorFormatTime;
				commonReturnResultViewModel.IsDone = false;
				num++;
				return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
			}
			try
			{
				if (!string.IsNullOrEmpty(model.tmExitTime))
				{
					text2 = PersianDate.GetFormatetdDate(text.Replace("/", ""));
					dateTime4 = ((lCID != 1065) ? DateTime.Parse(text2 + " " + model.tmExitTime, new CultureInfo("en-US")) : DateTime.Parse(text2 + " " + model.tmExitTime, new PersianCulture()));
					dateTime3 = dateTime4;
				}
			}
			catch (Exception e3)
			{
				ErrorSignal.FromCurrentContext().Raise(e3);
				commonReturnResultViewModel.Message = Messages.ErrorFormatTime;
				commonReturnResultViewModel.IsDone = false;
				num++;
				return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
			}
			if (string.IsNullOrEmpty(model.tmEntryRegisterIP))
			{
				model.tmEntryRegisterIP = null;
			}
			if (string.IsNullOrEmpty(model.tmExitRegisterIP))
			{
				model.tmExitRegisterIP = null;
			}
			if (model.tmShiftWorkingTimeId == 0)
			{
				model.tmShiftWorkingTimeId = null;
			}
			int userId = UserLogin.CurrentUser.UserId;
			DateTime now = DateTime.Now;
			short value = short.Parse(now.ToString("yyyy", new PersianCulture()));
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			DateTime value3 = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			string appType = Configuration.AppType;
			ObjectParameter objectParameter = new ObjectParameter("Result", 0);
			if (model.Mode.GetValueOrDefault() == 1)
			{
				if (!UserLogin.IsUserAccess("frmMain", "actcTimeAttendanceEdit", UserLogin.CurrentUser))
				{
					commonReturnResultViewModel.IsDone = false;
					commonReturnResultViewModel.Message = Messages.ErrorNotAccess;
					return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
				}
				DateTime? dateTime5 = null;
				DateTime? dateTime6 = null;
				if (dateTime.HasValue && !string.IsNullOrWhiteSpace(model.tmEntryBase))
				{
					dateTime5 = DateTime.Parse(dateTime?.ToString("yyyy-MM-dd") + " " + model.tmEntryBase);
				}
				if (dateTime.HasValue && !string.IsNullOrWhiteSpace(model.tmExitBase))
				{
					dateTime6 = DateTime.Parse(dateTime?.ToString("yyyy-MM-dd") + " " + model.tmExitBase);
				}
				CRMSpIIEntities dbII = _dbII;
				int? mode = 1;
				int? timeAttendanceId = model.TimeAttendanceId;
				DateTime? tmDate = dateTime;
				string tmDatePersian = text;
				int? tmUserId = model.tmUserId;
				int? tmEntryDelay = model.tmEntryDelay;
				DateTime? tmEntryBase = dateTime5;
				int? tmEntryDelayAllowMin = model.tmEntryDelayAllowMin;
				DateTime? tmEntryTime = dateTime2;
				int? tmEntryDelay2 = tmEntryDelay;
				string tmEntryRegisterIP = model.tmEntryRegisterIP;
				DateTime? tmExitBase = dateTime6;
				int? tmExitHurry = model.tmExitHurry;
				int? tmExitHurryAllowMin = model.tmExitHurryAllowMin;
				Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)dbII.CRMspInsertUpdateTimeAttendance(mode, timeAttendanceId, tmDate, tmDatePersian, tmUserId, tmEntryBase, tmEntryTime, tmEntryDelay2, tmEntryDelayAllowMin, tmEntryRegisterIP, tmExitBase, dateTime3, tmExitHurry, tmExitHurryAllowMin, model.tmExitRegisterIP, null, userId, value, value2, value3, registerDatePersian, appType, lCID, result, objectParameter, null, null, null, null, null, null, model.tmShiftWorkingTimeId, model.tmEntryIsTemp, model.tmExitIsTemp));
			}
			else if (model.Mode.GetValueOrDefault() == 2)
			{
				if (model.TimeAttendanceDetailId.GetValueOrDefault() == 0)
				{
					if (!UserLogin.IsUserAccess("frmMain", "actcTimeAttendanceDetailsInsert", UserLogin.CurrentUser))
					{
						commonReturnResultViewModel.IsDone = false;
						commonReturnResultViewModel.Message = Messages.ErrorNotAccess;
						return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
					}
				}
				else if (!UserLogin.IsUserAccess("frmMain", "actcTimeAttendanceDetailsEdit", UserLogin.CurrentUser))
				{
					commonReturnResultViewModel.IsDone = false;
					commonReturnResultViewModel.Message = Messages.ErrorNotAccess;
					return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
				}
				Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbII.CRMspInsertUpdateTimeAttendanceDetails(model.TimeAttendanceId, model.TimeAttendanceDetailId, dateTime, text, model.tmUserId, model.tmEntryBase, dateTime2?.ToString("HH:mm"), model.tmEntryDelay, model.tmEntryRegisterIP, model.tmExitBase, dateTime3?.ToString("HH:mm"), model.tmExitHurry, model.tmExitRegisterIP, userId, value, value2, value3, registerDatePersian, appType, lCID, result, objectParameter, model.tmShiftWorkingTimeId, model.tmEntryIsTemp, model.tmExitIsTemp));
			}
			if (objectParameter != null)
			{
				if (objectParameter.Value.ToString() == "1")
				{
					commonReturnResultViewModel.IsDone = true;
					commonReturnResultViewModel.Message = Messages.msgSuccessAction;
				}
				else
				{
					commonReturnResultViewModel.IsDone = false;
					commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
				}
			}
		}
		catch (DbEntityValidationException e4)
		{
			commonReturnResultViewModel.IsDone = false;
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e4);
			commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
		}
		catch (Exception e5)
		{
			commonReturnResultViewModel.IsDone = false;
			ErrorSignal.FromCurrentContext().Raise(e5);
			commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
		}
		return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	[HttpPost]
	public JsonResult CTimeAttendanceInsertEdit_Old(string parameters)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel();
		commonReturnResultViewModel.IsDone = false;
		commonReturnResultViewModel.MessageExtra = "";
		int num = 0;
		try
		{
			if (!string.IsNullOrEmpty(parameters))
			{
				TimeAttendanceLanguageViewModel timeAttendanceLanguageViewModel = new JavaScriptSerializer().Deserialize<TimeAttendanceLanguageViewModel>(parameters);
				if (string.IsNullOrEmpty(timeAttendanceLanguageViewModel.tmDatePersian))
				{
					commonReturnResultViewModel.Message = Messages.msgErrorEnterDate;
					commonReturnResultViewModel.IsDone = false;
					num++;
					return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
				}
				if (string.IsNullOrEmpty(timeAttendanceLanguageViewModel.tmEntryTime))
				{
					commonReturnResultViewModel.Message = Messages.msgCtmEntryTimeRequired;
					commonReturnResultViewModel.IsDone = false;
					num++;
					return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
				}
				if (!string.IsNullOrEmpty(timeAttendanceLanguageViewModel.tmEntryTime))
				{
					timeAttendanceLanguageViewModel.tmEntryTime += ":00";
				}
				if (!string.IsNullOrEmpty(timeAttendanceLanguageViewModel.tmExitTime))
				{
					timeAttendanceLanguageViewModel.tmExitTime += ":00";
				}
				string text = null;
				DateTime dateTime = default(DateTime);
				string text2 = "";
				try
				{
					if (!string.IsNullOrEmpty(timeAttendanceLanguageViewModel.tmDatePersian))
					{
						text2 = PersianDate.GetFormatetdDate(timeAttendanceLanguageViewModel.tmDatePersian.Replace("/", ""));
						text = ((lCID != 1065) ? DateTime.Parse(text2 + " " + timeAttendanceLanguageViewModel.tmEntryTime, new CultureInfo("en-US")).ToString("yyyyMMdd") : DateTime.Parse(text2 + " " + timeAttendanceLanguageViewModel.tmEntryTime, new PersianCulture()).ToString("yyyyMMdd"));
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					commonReturnResultViewModel.Message = Messages.ErrorFormatDatePersian;
					commonReturnResultViewModel.IsDone = false;
					num++;
					return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
				}
				try
				{
					if (!string.IsNullOrEmpty(timeAttendanceLanguageViewModel.tmEntryTime))
					{
						text2 = PersianDate.GetFormatetdDate(text.Replace("/", ""));
						if (lCID == 1065)
						{
							dateTime = DateTime.Parse(text2 + " " + timeAttendanceLanguageViewModel.tmEntryTime, new PersianCulture());
						}
						else
						{
							dateTime = DateTime.Parse(text2 + " " + timeAttendanceLanguageViewModel.tmEntryTime, new CultureInfo("en-US"));
						}
					}
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
					commonReturnResultViewModel.Message = Messages.ErrorFormatTime;
					commonReturnResultViewModel.IsDone = false;
					num++;
					return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
				}
				try
				{
					if (!string.IsNullOrEmpty(timeAttendanceLanguageViewModel.tmExitTime))
					{
						text2 = PersianDate.GetFormatetdDate(text.Replace("/", ""));
						if (lCID == 1065)
						{
							dateTime = DateTime.Parse(text2 + " " + timeAttendanceLanguageViewModel.tmExitTime, new PersianCulture());
						}
						else
						{
							dateTime = DateTime.Parse(text2 + " " + timeAttendanceLanguageViewModel.tmExitTime, new CultureInfo("en-US"));
						}
					}
				}
				catch (Exception e3)
				{
					ErrorSignal.FromCurrentContext().Raise(e3);
					commonReturnResultViewModel.Message = Messages.ErrorFormatTime;
					commonReturnResultViewModel.IsDone = false;
					num++;
					return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
				}
				if (string.IsNullOrEmpty(timeAttendanceLanguageViewModel.tmEntryRegisterIP))
				{
					timeAttendanceLanguageViewModel.tmEntryRegisterIP = null;
				}
				if (string.IsNullOrEmpty(timeAttendanceLanguageViewModel.tmExitRegisterIP))
				{
					timeAttendanceLanguageViewModel.tmExitRegisterIP = null;
				}
				if (timeAttendanceLanguageViewModel.tmShiftWorkingTimeId == 0)
				{
					timeAttendanceLanguageViewModel.tmShiftWorkingTimeId = null;
				}
				_ = UserLogin.CurrentUser.UserId;
				DateTime now = DateTime.Now;
				short.Parse(now.ToString("yyyy", new PersianCulture()));
				short.Parse(now.ToString("MM", new PersianCulture()));
				now.ToString("yyyyMMdd", new PersianCulture());
				_ = Configuration.AppType;
				ObjectParameter objectParameter = new ObjectParameter("Result", 0);
				if (objectParameter != null)
				{
					if (objectParameter.Value.ToString() == "1")
					{
						commonReturnResultViewModel.IsDone = true;
						commonReturnResultViewModel.Message = Messages.msgSuccessAction;
					}
					else
					{
						commonReturnResultViewModel.IsDone = false;
						commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
					}
				}
			}
			else
			{
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = Messages.msgSendParameterNotEntered;
			}
		}
		catch (DbEntityValidationException e4)
		{
			commonReturnResultViewModel.IsDone = false;
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e4);
			commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
		}
		catch (Exception e5)
		{
			commonReturnResultViewModel.IsDone = false;
			ErrorSignal.FromCurrentContext().Raise(e5);
			commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
		}
		return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
	}

	[HttpPost]
	[LoginAuthorize]
	public string DeleteTimeAttendance(int mode = 0, int tmId = 0)
	{
		string result = "";
		try
		{
			if (tmId == 0)
			{
				result = Messages.mnuErrorPleaseSelectARow;
			}
			else
			{
				switch (mode)
				{
				case 1:
					result = Messages.msgIsNotPossibleToDeleteMainRecord;
					break;
				case 2:
					if (!UserLogin.IsUserAccess("frmMain", "actcTimeAttendanceDetailsDelete", UserLogin.CurrentUser))
					{
						return Messages.msgErrorAccessLimited;
					}
					_dbII.CRMspDeleteTimeAttendanceDetails(tmId);
					break;
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			result = Messages.msgErrorOperationFailed;
		}
		return result;
	}

	public ActionResult CTimeAttendanceEditReq(int tmId = 0, string tmDate = "", int tmSelectedUserId = 0, int? swtId = null, int? swId = null)
	{
		TimeAttendanceEditReqLanguageViewModel model = new TimeAttendanceEditReqLanguageViewModel();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime dateTime = DateTime.Now;
			if (!string.IsNullOrEmpty(tmDate))
			{
				string formatetdDate = PersianDate.GetFormatetdDate(tmDate.Replace("/", ""));
				dateTime = lCID switch
				{
					1065 => DateTime.Parse(formatetdDate + " 00:00:00", new PersianCulture()), 
					1025 => DateTime.Parse(formatetdDate + " 00:00:00", new CultureInfo("ar-SA")), 
					_ => DateTime.Parse(formatetdDate + " 00:00:00", new CultureInfo("en-US")), 
				};
			}
			if (tmSelectedUserId == 0)
			{
				tmSelectedUserId = UserLogin.CurrentUser.UserId;
			}
			DateTime tmDateTime = dateTime;
			CRMspSelectTimeAttendanceByDate_Result cRMspSelectTimeAttendanceByDate_Result = Enumerable.FirstOrDefault<CRMspSelectTimeAttendanceByDate_Result>((IEnumerable<CRMspSelectTimeAttendanceByDate_Result>)dbI.CRMspSelectTimeAttendanceByDate(dateTime, tmSelectedUserId, lCID, result));
			if (cRMspSelectTimeAttendanceByDate_Result != null)
			{
				model = new TimeAttendanceEditReqLanguageViewModel
				{
					tmDatePersian = cRMspSelectTimeAttendanceByDate_Result.tmDate.ToString("yyyy/MM/dd"),
					tmUser = cRMspSelectTimeAttendanceByDate_Result.tmUser,
					tmUserId = cRMspSelectTimeAttendanceByDate_Result.tmUserId,
					tmCurrentEntryTime = cRMspSelectTimeAttendanceByDate_Result.tmEntryTime.ToString("HH:mm:ss"),
					tmCurrentExitTime = ((!cRMspSelectTimeAttendanceByDate_Result.tmExitTime.HasValue) ? null : cRMspSelectTimeAttendanceByDate_Result.tmExitTime.Value.ToString("HH:mm:ss")),
					tmCurrentEntryRegisterIP = cRMspSelectTimeAttendanceByDate_Result.tmEntryRegisterIP,
					tmCurrentExitRegisterIP = cRMspSelectTimeAttendanceByDate_Result.tmExitRegisterIP,
					tmEntryRegisterIP = base.Request.UserHostAddress,
					tmExitRegisterIP = base.Request.UserHostAddress,
					EntryRequestIsRequired = false,
					tmShiftWorkingID = swId,
					tmShiftWorkingTimeID = cRMspSelectTimeAttendanceByDate_Result.tmShiftWorkingTimeId,
					tmLeaveId = cRMspSelectTimeAttendanceByDate_Result.tmLeaveId,
					tmLeaveTypeId = cRMspSelectTimeAttendanceByDate_Result.tmLeaveTypeId,
					tmEntryTimeSoonAllowMin = cRMspSelectTimeAttendanceByDate_Result.tmEntryTimeSoonAllowMin,
					tmExitTimeLateAllowMin = cRMspSelectTimeAttendanceByDate_Result.tmExitTimeLateAllowMin
				};
			}
			else
			{
				bool value = Enumerable.FirstOrDefault<CRMspSelectTimeAttendanceRequest_Result>((IEnumerable<CRMspSelectTimeAttendanceRequest_Result>)dbI.CRMspSelectTimeAttendanceRequest(null, 1, tmSelectedUserId, dateTime.ToString("yyyy-MM-dd", new CultureInfo("en-US")), 0)) == null;
				CRMspSelectShiftWorkingTimeById_Result cRMspSelectShiftWorkingTimeById_Result = Enumerable.FirstOrDefault<CRMspSelectShiftWorkingTimeById_Result>((IEnumerable<CRMspSelectShiftWorkingTimeById_Result>)_dbII.CRMspSelectShiftWorkingTimeById(swtId, lCID, result));
				new ShiftWorkingDayViewModel();
				if (cRMspSelectShiftWorkingTimeById_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectShiftWorkingTimeById_Result.swtWeekDays))
				{
					List<ShiftWorkingDayViewModel> list = JsonConvert.DeserializeObject<List<ShiftWorkingDayViewModel>>(cRMspSelectShiftWorkingTimeById_Result.swtWeekDays);
					if (list != null)
					{
						ShiftWorkingDayViewModel shiftWorkingDayViewModel = Enumerable.FirstOrDefault<ShiftWorkingDayViewModel>((IEnumerable<ShiftWorkingDayViewModel>)list, (Func<ShiftWorkingDayViewModel, bool>)((ShiftWorkingDayViewModel x) => x.DayNum == (int)tmDateTime.DayOfWeek));
					}
				}
				model = new TimeAttendanceEditReqLanguageViewModel
				{
					tmDatePersian = dateTime.ToString("yyyy/MM/dd"),
					tmUserId = tmSelectedUserId,
					tmUser = CRMIdeal.Classes.Helper.User.GetUserName(tmSelectedUserId, result, lCID),
					tmEntryRegisterIP = base.Request.UserHostAddress,
					tmExitRegisterIP = base.Request.UserHostAddress,
					EntryRequestIsRequired = value,
					tmShiftWorkingID = swId,
					tmShiftWorkingTimeID = swtId
				};
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(model);
	}

	[AjaxOnly]
	public JsonResult CTimeAttendanceEditReqChangeDate(string tmDate = "", int tmSelectedUserId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		TimeAttendanceEditReqLanguageViewModel data = new TimeAttendanceEditReqLanguageViewModel();
		try
		{
			if (!string.IsNullOrEmpty(tmDate) && tmSelectedUserId != 0)
			{
				DateTime value = DateTime.Now;
				if (!string.IsNullOrEmpty(tmDate))
				{
					string formatetdDate = PersianDate.GetFormatetdDate(tmDate.Replace("/", ""));
					value = lCID switch
					{
						1065 => DateTime.Parse(formatetdDate + " 00:00:00", new PersianCulture()), 
						1025 => DateTime.Parse(formatetdDate + " 00:00:00", new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(formatetdDate + " 00:00:00", new CultureInfo("en-US")), 
					};
				}
				CRMspSelectTimeAttendanceByDate_Result cRMspSelectTimeAttendanceByDate_Result = Enumerable.FirstOrDefault<CRMspSelectTimeAttendanceByDate_Result>((IEnumerable<CRMspSelectTimeAttendanceByDate_Result>)dbI.CRMspSelectTimeAttendanceByDate(value, tmSelectedUserId, lCID, result));
				if (cRMspSelectTimeAttendanceByDate_Result != null)
				{
					TimeAttendanceEditReqLanguageViewModel timeAttendanceEditReqLanguageViewModel = new TimeAttendanceEditReqLanguageViewModel();
					_ = cRMspSelectTimeAttendanceByDate_Result.tmEntryTime;
					timeAttendanceEditReqLanguageViewModel.tmCurrentEntryTime = cRMspSelectTimeAttendanceByDate_Result.tmEntryTime.ToString("HH:mm:ss");
					timeAttendanceEditReqLanguageViewModel.tmCurrentExitTime = ((!cRMspSelectTimeAttendanceByDate_Result.tmExitTime.HasValue) ? null : cRMspSelectTimeAttendanceByDate_Result.tmExitTime.Value.ToString("HH:mm:ss"));
					timeAttendanceEditReqLanguageViewModel.tmCurrentEntryRegisterIP = cRMspSelectTimeAttendanceByDate_Result.tmEntryRegisterIP;
					timeAttendanceEditReqLanguageViewModel.tmCurrentExitRegisterIP = cRMspSelectTimeAttendanceByDate_Result.tmExitRegisterIP;
					data = timeAttendanceEditReqLanguageViewModel;
				}
				else
				{
					bool value2 = Enumerable.FirstOrDefault<CRMspSelectTimeAttendanceRequest_Result>((IEnumerable<CRMspSelectTimeAttendanceRequest_Result>)dbI.CRMspSelectTimeAttendanceRequest(null, 1, tmSelectedUserId, value.ToString("yyyy-MM-dd", new CultureInfo("en-US")), 0)) == null;
					data = new TimeAttendanceEditReqLanguageViewModel
					{
						EntryRequestIsRequired = value2
					};
				}
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
	public JsonResult CTimeAttendanceCheckDuplicateRequest(string tmDate = "", int userId = 0, int reqType = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		TimeAttendanceCheckDuplicateRequest data = new TimeAttendanceCheckDuplicateRequest();
		try
		{
			if (!string.IsNullOrEmpty(tmDate) && userId != 0)
			{
				DateTime dateTime = DateTime.Now;
				if (!string.IsNullOrEmpty(tmDate))
				{
					string formatetdDate = PersianDate.GetFormatetdDate(tmDate.Replace("/", ""));
					dateTime = lCID switch
					{
						1065 => DateTime.Parse(formatetdDate + " 00:00:00", new PersianCulture()), 
						1025 => DateTime.Parse(formatetdDate + " 00:00:00", new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(formatetdDate + " 00:00:00", new CultureInfo("en-US")), 
					};
				}
				CRMspSelectTimeAttendanceRequest_Result cRMspSelectTimeAttendanceRequest_Result = Enumerable.FirstOrDefault<CRMspSelectTimeAttendanceRequest_Result>((IEnumerable<CRMspSelectTimeAttendanceRequest_Result>)dbI.CRMspSelectTimeAttendanceRequest(null, reqType, userId, dateTime.ToString("yyyy-MM-dd", new CultureInfo("en-US")), 0));
				if (cRMspSelectTimeAttendanceRequest_Result != null)
				{
					TimeAttendanceVerifyExtraDataViewModel timeAttendanceVerifyExtraDataViewModel = Enumerable.FirstOrDefault<TimeAttendanceVerifyExtraDataViewModel>((IEnumerable<TimeAttendanceVerifyExtraDataViewModel>)JsonConvert.DeserializeObject<List<TimeAttendanceVerifyExtraDataViewModel>>(cRMspSelectTimeAttendanceRequest_Result.RequestData));
					data = new TimeAttendanceCheckDuplicateRequest
					{
						RequestId = cRMspSelectTimeAttendanceRequest_Result.TimeAttendanceRequestId,
						tmDate = dateTime.ToString("yyyy/MM/dd", new CultureInfo("fa-IR")),
						tmTime = timeAttendanceVerifyExtraDataViewModel.tmTime,
						tmUser = CRMIdeal.Classes.Helper.User.GetUserName(userId, lCID, result)
					};
				}
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
	[HttpPost]
	public JsonResult CTimeAttendanceEditReq(string parameters)
	{
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel();
		commonReturnResultViewModel.IsDone = false;
		commonReturnResultViewModel.MessageExtra = "";
		int num = 0;
		try
		{
			if (!string.IsNullOrEmpty(parameters))
			{
				TimeAttendanceEditReqLanguageViewModel timeAttendanceEditReqLanguageViewModel = new JavaScriptSerializer().Deserialize<TimeAttendanceEditReqLanguageViewModel>(parameters);
				int userId = UserLogin.CurrentUser.UserId;
				DateTime now = DateTime.Now;
				short value = short.Parse(now.ToString("yyyy", new PersianCulture()));
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				DateTime value3 = now;
				string text = now.ToString("yyyyMMdd", new PersianCulture());
				string msgdSendTime = now.ToString("HH:mm:ss");
				string appType = Configuration.AppType;
				int? centerId = null;
				if (UserLogin.CurrentUser != null)
				{
					centerId = UserLogin.CurrentUser.UserLastCId;
				}
				if (timeAttendanceEditReqLanguageViewModel.tmUserId.GetValueOrDefault() == 0)
				{
					commonReturnResultViewModel.Message = Messages.msgErrorNotSelectedUser;
					commonReturnResultViewModel.IsDone = false;
					num++;
					return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
				}
				CRMspSelectUsersById_Result cRMspSelectUsersById_Result = CRMIdeal.Classes.Helper.User.SelectUsersById(timeAttendanceEditReqLanguageViewModel.tmUserId.GetValueOrDefault());
				if ((cRMspSelectUsersById_Result?.ResponsibleUserId).GetValueOrDefault() == 0)
				{
					commonReturnResultViewModel.Message = Messages.msgErrorResponsibleUserNotDefined;
					commonReturnResultViewModel.IsDone = false;
					num++;
					return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
				}
				int value4 = cRMspSelectUsersById_Result.ResponsibleUserId.Value;
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(timeAttendanceEditReqLanguageViewModel.tmDescription_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(timeAttendanceEditReqLanguageViewModel.tmDescription_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = timeAttendanceEditReqLanguageViewModel.tmDescription,
					LanguageId = lCID
				});
				if (string.IsNullOrEmpty(timeAttendanceEditReqLanguageViewModel.tmDescription))
				{
					commonReturnResultViewModel.Message = Messages.CheckEmptyTmDesc;
					commonReturnResultViewModel.IsDone = false;
					num++;
					return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
				}
				if (!checkCtmEditReqMultiLanguage(timeAttendanceEditReqLanguageViewModel.tmDescription, list))
				{
					commonReturnResultViewModel.Message = Messages.CheckTmDescLang;
					commonReturnResultViewModel.IsDone = false;
					num++;
					return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
				}
				string tmDate = "";
				if (!string.IsNullOrEmpty(timeAttendanceEditReqLanguageViewModel.tmDatePersian))
				{
					DateTime now2 = DateTime.Now;
					string formatetdDate = PersianDate.GetFormatetdDate(timeAttendanceEditReqLanguageViewModel.tmDatePersian.Replace("/", ""));
					tmDate = (lCID switch
					{
						1065 => DateTime.Parse(formatetdDate + " 00:00:00", new PersianCulture()), 
						1025 => DateTime.Parse(formatetdDate + " 00:00:00", new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(formatetdDate + " 00:00:00", new CultureInfo("en-US")), 
					}).ToString("yyyy-MM-dd", new CultureInfo("en-US"));
				}
				if (timeAttendanceEditReqLanguageViewModel.IsEntryRequestDuplicate.GetValueOrDefault())
				{
					timeAttendanceEditReqLanguageViewModel.IsEntryRequest = false;
				}
				if (timeAttendanceEditReqLanguageViewModel.IsExitRequestDuplicate.GetValueOrDefault())
				{
					timeAttendanceEditReqLanguageViewModel.IsExitRequest = false;
				}
				int? requestId = null;
				int? requestTypeId = null;
				string requestData = null;
				int? requestIdI = null;
				int? requestTypeIdI = null;
				string requestDataI = null;
				if (timeAttendanceEditReqLanguageViewModel.IsEntryRequest.GetValueOrDefault())
				{
					requestData = JsonConvert.SerializeObject(Enumerable.ToList<TimeAttendanceVerifyExtraDataViewModel>((IEnumerable<TimeAttendanceVerifyExtraDataViewModel>)new List<TimeAttendanceVerifyExtraDataViewModel>
					{
						new TimeAttendanceVerifyExtraDataViewModel
						{
							tmTime = timeAttendanceEditReqLanguageViewModel.tmEntryTime,
							tmRegisterIP = timeAttendanceEditReqLanguageViewModel.tmEntryRegisterIP,
							tmDate = tmDate,
							tmDescription = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list)),
							tmUserId = timeAttendanceEditReqLanguageViewModel.tmUserId,
							tmShiftWorkingId = timeAttendanceEditReqLanguageViewModel.tmShiftWorkingID,
							tmShiftWorkingTimeId = timeAttendanceEditReqLanguageViewModel.tmShiftWorkingTimeID
						}
					}));
					requestTypeId = 1;
				}
				else if (timeAttendanceEditReqLanguageViewModel.ResendEntryRequestId.GetValueOrDefault() != 0)
				{
					requestId = timeAttendanceEditReqLanguageViewModel.ResendEntryRequestId;
					CRMspSelectTimeAttendanceRequest_Result cRMspSelectTimeAttendanceRequest_Result = Enumerable.FirstOrDefault<CRMspSelectTimeAttendanceRequest_Result>((IEnumerable<CRMspSelectTimeAttendanceRequest_Result>)dbI.CRMspSelectTimeAttendanceRequest(timeAttendanceEditReqLanguageViewModel.ResendEntryRequestId, null, null, null, null));
					if (cRMspSelectTimeAttendanceRequest_Result != null)
					{
						list = JsonConvert.DeserializeObject<List<CommonMultiLanguageViewModel>>(Enumerable.FirstOrDefault<TimeAttendanceVerifyExtraDataViewModel>((IEnumerable<TimeAttendanceVerifyExtraDataViewModel>)JsonConvert.DeserializeObject<List<TimeAttendanceVerifyExtraDataViewModel>>(cRMspSelectTimeAttendanceRequest_Result.RequestData)).tmDescription);
					}
					else
					{
						requestId = null;
					}
				}
				if (timeAttendanceEditReqLanguageViewModel.IsExitRequest.GetValueOrDefault())
				{
					List<TimeAttendanceVerifyExtraDataViewModel> list2 = new List<TimeAttendanceVerifyExtraDataViewModel>();
					TimeAttendanceVerifyExtraDataViewModel timeAttendanceVerifyExtraDataViewModel = new TimeAttendanceVerifyExtraDataViewModel();
					timeAttendanceVerifyExtraDataViewModel.tmTime = timeAttendanceEditReqLanguageViewModel.tmExitTime;
					timeAttendanceVerifyExtraDataViewModel.tmRegisterIP = timeAttendanceEditReqLanguageViewModel.tmExitRegisterIP;
					timeAttendanceVerifyExtraDataViewModel.tmDate = tmDate;
					timeAttendanceVerifyExtraDataViewModel.tmDescription = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list));
					timeAttendanceVerifyExtraDataViewModel.tmUserId = timeAttendanceEditReqLanguageViewModel.tmUserId;
					timeAttendanceVerifyExtraDataViewModel.tmShiftWorkingId = timeAttendanceEditReqLanguageViewModel.tmShiftWorkingID;
					timeAttendanceVerifyExtraDataViewModel.tmShiftWorkingTimeId = timeAttendanceEditReqLanguageViewModel.tmShiftWorkingTimeID;
					list2.Add(timeAttendanceVerifyExtraDataViewModel);
					if (!timeAttendanceEditReqLanguageViewModel.IsEntryRequest.GetValueOrDefault())
					{
						requestData = JsonConvert.SerializeObject(Enumerable.ToList<TimeAttendanceVerifyExtraDataViewModel>((IEnumerable<TimeAttendanceVerifyExtraDataViewModel>)list2));
						requestTypeId = 2;
					}
					else
					{
						requestDataI = JsonConvert.SerializeObject(Enumerable.ToList<TimeAttendanceVerifyExtraDataViewModel>((IEnumerable<TimeAttendanceVerifyExtraDataViewModel>)list2));
						requestTypeIdI = 2;
					}
				}
				else if (timeAttendanceEditReqLanguageViewModel.ResendExitRequestId.GetValueOrDefault() != 0)
				{
					if (requestId.HasValue)
					{
						requestIdI = timeAttendanceEditReqLanguageViewModel.ResendExitRequestId;
					}
					else
					{
						requestId = timeAttendanceEditReqLanguageViewModel.ResendExitRequestId;
					}
					CRMspSelectTimeAttendanceRequest_Result cRMspSelectTimeAttendanceRequest_Result2 = Enumerable.FirstOrDefault<CRMspSelectTimeAttendanceRequest_Result>((IEnumerable<CRMspSelectTimeAttendanceRequest_Result>)dbI.CRMspSelectTimeAttendanceRequest(timeAttendanceEditReqLanguageViewModel.ResendExitRequestId, null, null, null, null));
					if (cRMspSelectTimeAttendanceRequest_Result2 != null)
					{
						list = JsonConvert.DeserializeObject<List<CommonMultiLanguageViewModel>>(Enumerable.FirstOrDefault<TimeAttendanceVerifyExtraDataViewModel>((IEnumerable<TimeAttendanceVerifyExtraDataViewModel>)JsonConvert.DeserializeObject<List<TimeAttendanceVerifyExtraDataViewModel>>(cRMspSelectTimeAttendanceRequest_Result2.RequestData)).tmDescription);
					}
					else
					{
						requestId = null;
					}
				}
				List<TimeAttendanceEditReqMultiLanguageViewModel> list3 = new List<TimeAttendanceEditReqMultiLanguageViewModel>();
				foreach (Languages lang in Enumerable.ToList<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get()))
				{
					CommonMultiLanguageViewModel commonMultiLanguageViewModel = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel m) => m.LanguageId == lang.LanguageID)));
					TimeAttendanceEditReqMultiLanguageViewModel timeAttendanceEditReqMultiLanguageViewModel = new TimeAttendanceEditReqMultiLanguageViewModel();
					if (timeAttendanceEditReqLanguageViewModel.tmUserId == userId)
					{
						timeAttendanceEditReqMultiLanguageViewModel.Subject = MyResource.GetResourceString("CTimeAttendanceEditRequst", lang.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
					}
					else
					{
						timeAttendanceEditReqMultiLanguageViewModel.Subject = MyResource.GetResourceString("CTimeAttendanceEditRequstForAnotherUser", lang.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
					}
					string languageCollation = lang.LanguageCollation;
					CultureInfo cultureInfo = ((languageCollation.Trim().ToLower() == "fa-ir") ? new PersianCulture() : new CultureInfo(languageCollation));
					string text2 = DateTime.Now.ToString("yyyy/MM/dd", cultureInfo);
					timeAttendanceEditReqMultiLanguageViewModel.Body = Environment.NewLine + "-->" + CRMIdeal.Classes.Helper.User.GetUserName(userId, defLangID, lang.LanguageID) + "  " + text2 + " " + DateTime.Now.ToString("HH:mm:ss") + Environment.NewLine + commonMultiLanguageViewModel.Value;
					timeAttendanceEditReqMultiLanguageViewModel.LanguageId = lang.LanguageID;
					list3.Add(timeAttendanceEditReqMultiLanguageViewModel);
				}
				string msgLangValue = JsonConvert.SerializeObject(Enumerable.ToList<TimeAttendanceEditReqMultiLanguageViewModel>((IEnumerable<TimeAttendanceEditReqMultiLanguageViewModel>)list3));
				string msgSubject = ((Enumerable.FirstOrDefault<TimeAttendanceEditReqMultiLanguageViewModel>((IEnumerable<TimeAttendanceEditReqMultiLanguageViewModel>)list3, (Func<TimeAttendanceEditReqMultiLanguageViewModel, bool>)((TimeAttendanceEditReqMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<TimeAttendanceEditReqMultiLanguageViewModel>((IEnumerable<TimeAttendanceEditReqMultiLanguageViewModel>)list3, (Func<TimeAttendanceEditReqMultiLanguageViewModel, bool>)((TimeAttendanceEditReqMultiLanguageViewModel c) => c.LanguageId == defLangID)).Subject : null);
				string msgBody = ((Enumerable.FirstOrDefault<TimeAttendanceEditReqMultiLanguageViewModel>((IEnumerable<TimeAttendanceEditReqMultiLanguageViewModel>)list3, (Func<TimeAttendanceEditReqMultiLanguageViewModel, bool>)((TimeAttendanceEditReqMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<TimeAttendanceEditReqMultiLanguageViewModel>((IEnumerable<TimeAttendanceEditReqMultiLanguageViewModel>)list3, (Func<TimeAttendanceEditReqMultiLanguageViewModel, bool>)((TimeAttendanceEditReqMultiLanguageViewModel c) => c.LanguageId == defLangID)).Body : null);
				ObjectParameter objectParameter = new ObjectParameter("InsertedID", -1);
				if (requestId.HasValue || requestTypeId.HasValue)
				{
					Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)dbI.CRMspSendTimeAttendanceEditRequest(requestId, requestTypeId, requestData, requestIdI, requestTypeIdI, requestDataI, msgSubject, msgBody, msgLangValue, userId, value4, text, msgdSendTime, value3, userId, value, value2, value3, text, appType, defLangID, objectParameter, centerId));
				}
				else
				{
					objectParameter.Value = 1;
				}
				if (objectParameter != null)
				{
					if (objectParameter.Value.ToString() == "-1")
					{
						commonReturnResultViewModel.IsDone = false;
						commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
					}
					else
					{
						PushNotif.NewIntMsgNotify();
						commonReturnResultViewModel.IsDone = true;
						commonReturnResultViewModel.Message = Messages.msgSuccessAction;
					}
				}
			}
			else
			{
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = Messages.msgSendParameterNotEntered;
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

	public bool checkCtmEditReqMultiLanguage(string defaultValue, List<CommonMultiLanguageViewModel> list)
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

	public ActionResult CTimeAttendanceVerifyReq(int msgdId = 0, int attachRecId = 0, int attachRecIdI = 0, bool setReadWhenDone = false)
	{
		TimeAttendanceVerifyLanguageViewModel timeAttendanceVerifyLanguageViewModel = new TimeAttendanceVerifyLanguageViewModel();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
			if (defLangID <= 0)
			{
				defLangID = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			CRMspSelectTimeAttendanceRequestMessage_Result cRMspSelectTimeAttendanceRequestMessage_Result = Enumerable.FirstOrDefault<CRMspSelectTimeAttendanceRequestMessage_Result>((IEnumerable<CRMspSelectTimeAttendanceRequestMessage_Result>)dbI.CRMspSelectTimeAttendanceRequestMessage(attachRecId, null, null, null, null, msgdId));
			if (cRMspSelectTimeAttendanceRequestMessage_Result == null)
			{
				return View(timeAttendanceVerifyLanguageViewModel);
			}
			TimeAttendanceVerifyExtraDataViewModel requestData = Enumerable.FirstOrDefault<TimeAttendanceVerifyExtraDataViewModel>((IEnumerable<TimeAttendanceVerifyExtraDataViewModel>)JsonConvert.DeserializeObject<List<TimeAttendanceVerifyExtraDataViewModel>>(cRMspSelectTimeAttendanceRequestMessage_Result.RequestData));
			string tmDatePersianStr = "";
			string tmDatePersian = "";
			DateTime value = DateTime.Now;
			if (!string.IsNullOrEmpty(requestData.tmDate))
			{
				value = DateTime.Parse(requestData.tmDate + " 00:00:00", new CultureInfo("en-US"));
				tmDatePersianStr = value.ToString("dddd dd MMMM yyyy");
				tmDatePersian = value.ToString("yyyy/MM/dd");
			}
			timeAttendanceVerifyLanguageViewModel = new TimeAttendanceVerifyLanguageViewModel
			{
				tmDatePersianStr = tmDatePersianStr,
				tmDatePersian = tmDatePersian,
				tmUserId = requestData.tmUserId,
				SetReadWhenDone = setReadWhenDone,
				HasTwoRequests = false
			};
			if (timeAttendanceVerifyLanguageViewModel.tmUserId.GetValueOrDefault() != 0)
			{
				timeAttendanceVerifyLanguageViewModel.tmUser = CRMIdeal.Classes.Helper.User.GetUserName(timeAttendanceVerifyLanguageViewModel.tmUserId.Value, lCID, defLangID);
			}
			List<CommonMultiLanguageViewModel> list = JsonConvert.DeserializeObject<List<CommonMultiLanguageViewModel>>(requestData.tmDescription);
			timeAttendanceVerifyLanguageViewModel.tmDescription = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
			timeAttendanceVerifyLanguageViewModel.RequestId = cRMspSelectTimeAttendanceRequestMessage_Result.TimeAttendanceRequestId;
			timeAttendanceVerifyLanguageViewModel.MessageId = cRMspSelectTimeAttendanceRequestMessage_Result.MessageId;
			timeAttendanceVerifyLanguageViewModel.MessageDetailId = cRMspSelectTimeAttendanceRequestMessage_Result.MessageDetailId;
			timeAttendanceVerifyLanguageViewModel.MsgdTypeId = cRMspSelectTimeAttendanceRequestMessage_Result.MsgdTypeId;
			timeAttendanceVerifyLanguageViewModel.MsgdFromUserId = cRMspSelectTimeAttendanceRequestMessage_Result.msgdFromUserId;
			timeAttendanceVerifyLanguageViewModel.MsgdPriorityId = cRMspSelectTimeAttendanceRequestMessage_Result.msgdPriorityId;
			timeAttendanceVerifyLanguageViewModel.MsgdAttachRecId = cRMspSelectTimeAttendanceRequestMessage_Result.msgdAttachRecId;
			timeAttendanceVerifyLanguageViewModel.MsgdAttachRecIdI = cRMspSelectTimeAttendanceRequestMessage_Result.msgdAttachRecIdI;
			if (cRMspSelectTimeAttendanceRequestMessage_Result.RequestTypeId == 1)
			{
				timeAttendanceVerifyLanguageViewModel.tmEntryTime = requestData.tmTime;
				timeAttendanceVerifyLanguageViewModel.tmEntryRegisterIP = requestData.tmRegisterIP;
				List<CommonMultiLanguageViewModel> list2 = JsonConvert.DeserializeObject<List<CommonMultiLanguageViewModel>>(requestData.tmDescription);
				timeAttendanceVerifyLanguageViewModel.tmEntryDescription = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
				timeAttendanceVerifyLanguageViewModel.EntryUserLat = requestData.UserLat;
				timeAttendanceVerifyLanguageViewModel.EntryUserLng = requestData.UserLng;
				timeAttendanceVerifyLanguageViewModel.EntryRequestIsVerified = requestData.RequestVerified;
				timeAttendanceVerifyLanguageViewModel.EntryRequestId = cRMspSelectTimeAttendanceRequestMessage_Result.TimeAttendanceRequestId;
				timeAttendanceVerifyLanguageViewModel.EntryMessageId = cRMspSelectTimeAttendanceRequestMessage_Result.MessageId;
				timeAttendanceVerifyLanguageViewModel.EntryMessageDetailId = cRMspSelectTimeAttendanceRequestMessage_Result.MessageDetailId;
				timeAttendanceVerifyLanguageViewModel.EntryMsgdTypeId = cRMspSelectTimeAttendanceRequestMessage_Result.MsgdTypeId;
				timeAttendanceVerifyLanguageViewModel.ShiftWorkingId = requestData.tmShiftWorkingId;
				timeAttendanceVerifyLanguageViewModel.ShiftWorkingTimeId = requestData.tmShiftWorkingTimeId;
			}
			else
			{
				timeAttendanceVerifyLanguageViewModel.tmExitTime = requestData.tmTime;
				timeAttendanceVerifyLanguageViewModel.tmExitRegisterIP = requestData.tmRegisterIP;
				List<CommonMultiLanguageViewModel> list3 = JsonConvert.DeserializeObject<List<CommonMultiLanguageViewModel>>(requestData.tmDescription);
				timeAttendanceVerifyLanguageViewModel.tmExitDescription = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
				timeAttendanceVerifyLanguageViewModel.ExitUserLat = requestData.UserLat;
				timeAttendanceVerifyLanguageViewModel.ExitUserLng = requestData.UserLng;
				timeAttendanceVerifyLanguageViewModel.ExitRequestIsVerified = requestData.RequestVerified;
				timeAttendanceVerifyLanguageViewModel.ExitRequestId = cRMspSelectTimeAttendanceRequestMessage_Result.TimeAttendanceRequestId;
				timeAttendanceVerifyLanguageViewModel.ExitMessageId = cRMspSelectTimeAttendanceRequestMessage_Result.MessageId;
				timeAttendanceVerifyLanguageViewModel.ExitMessageDetailId = cRMspSelectTimeAttendanceRequestMessage_Result.MessageDetailId;
				timeAttendanceVerifyLanguageViewModel.ExitMsgdTypeId = cRMspSelectTimeAttendanceRequestMessage_Result.MsgdTypeId;
				timeAttendanceVerifyLanguageViewModel.ShiftWorkingId = requestData.tmShiftWorkingId;
				timeAttendanceVerifyLanguageViewModel.ShiftWorkingTimeId = requestData.tmShiftWorkingTimeId;
			}
			CRMspSelectTimeAttendanceRequestMessage_Result cRMspSelectTimeAttendanceRequestMessage_Result2 = null;
			cRMspSelectTimeAttendanceRequestMessage_Result2 = ((attachRecIdI == 0) ? Enumerable.FirstOrDefault<CRMspSelectTimeAttendanceRequestMessage_Result>((IEnumerable<CRMspSelectTimeAttendanceRequestMessage_Result>)dbI.CRMspSelectTimeAttendanceRequestMessage(null, (cRMspSelectTimeAttendanceRequestMessage_Result.RequestTypeId != 1) ? 1 : 2, timeAttendanceVerifyLanguageViewModel.tmUserId, value.ToString("yyyy-MM-dd", new CultureInfo("en-US")), 0, null)) : Enumerable.FirstOrDefault<CRMspSelectTimeAttendanceRequestMessage_Result>((IEnumerable<CRMspSelectTimeAttendanceRequestMessage_Result>)dbI.CRMspSelectTimeAttendanceRequestMessage(attachRecIdI, null, null, null, null, msgdId)));
			if (cRMspSelectTimeAttendanceRequestMessage_Result2 != null)
			{
				timeAttendanceVerifyLanguageViewModel.HasTwoRequests = true;
				TimeAttendanceVerifyExtraDataViewModel timeAttendanceVerifyExtraDataViewModel = Enumerable.FirstOrDefault<TimeAttendanceVerifyExtraDataViewModel>((IEnumerable<TimeAttendanceVerifyExtraDataViewModel>)JsonConvert.DeserializeObject<List<TimeAttendanceVerifyExtraDataViewModel>>(cRMspSelectTimeAttendanceRequestMessage_Result2.RequestData));
				if (cRMspSelectTimeAttendanceRequestMessage_Result2.RequestTypeId == 1)
				{
					timeAttendanceVerifyLanguageViewModel.tmEntryTime = timeAttendanceVerifyExtraDataViewModel.tmTime;
					timeAttendanceVerifyLanguageViewModel.tmEntryRegisterIP = timeAttendanceVerifyExtraDataViewModel.tmRegisterIP;
					List<CommonMultiLanguageViewModel> list4 = JsonConvert.DeserializeObject<List<CommonMultiLanguageViewModel>>(timeAttendanceVerifyExtraDataViewModel.tmDescription);
					timeAttendanceVerifyLanguageViewModel.tmEntryDescription = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					timeAttendanceVerifyLanguageViewModel.EntryUserLat = timeAttendanceVerifyExtraDataViewModel.UserLat;
					timeAttendanceVerifyLanguageViewModel.EntryUserLng = timeAttendanceVerifyExtraDataViewModel.UserLng;
					timeAttendanceVerifyLanguageViewModel.EntryRequestIsVerified = timeAttendanceVerifyExtraDataViewModel.RequestVerified;
					timeAttendanceVerifyLanguageViewModel.EntryRequestId = cRMspSelectTimeAttendanceRequestMessage_Result2.TimeAttendanceRequestId;
					timeAttendanceVerifyLanguageViewModel.EntryMessageId = cRMspSelectTimeAttendanceRequestMessage_Result2.MessageId;
					timeAttendanceVerifyLanguageViewModel.EntryMessageDetailId = cRMspSelectTimeAttendanceRequestMessage_Result2.MessageDetailId;
					timeAttendanceVerifyLanguageViewModel.EntryMsgdTypeId = cRMspSelectTimeAttendanceRequestMessage_Result2.MsgdTypeId;
					timeAttendanceVerifyLanguageViewModel.ShiftWorkingId = requestData.tmShiftWorkingId;
					timeAttendanceVerifyLanguageViewModel.ShiftWorkingTimeId = requestData.tmShiftWorkingTimeId;
				}
				else
				{
					timeAttendanceVerifyLanguageViewModel.tmExitTime = timeAttendanceVerifyExtraDataViewModel.tmTime;
					timeAttendanceVerifyLanguageViewModel.tmExitRegisterIP = timeAttendanceVerifyExtraDataViewModel.tmRegisterIP;
					List<CommonMultiLanguageViewModel> list5 = JsonConvert.DeserializeObject<List<CommonMultiLanguageViewModel>>(timeAttendanceVerifyExtraDataViewModel.tmDescription);
					timeAttendanceVerifyLanguageViewModel.tmExitDescription = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					timeAttendanceVerifyLanguageViewModel.ExitUserLat = timeAttendanceVerifyExtraDataViewModel.UserLat;
					timeAttendanceVerifyLanguageViewModel.ExitUserLng = timeAttendanceVerifyExtraDataViewModel.UserLng;
					timeAttendanceVerifyLanguageViewModel.ExitRequestIsVerified = timeAttendanceVerifyExtraDataViewModel.RequestVerified;
					timeAttendanceVerifyLanguageViewModel.ExitRequestId = cRMspSelectTimeAttendanceRequestMessage_Result2.TimeAttendanceRequestId;
					timeAttendanceVerifyLanguageViewModel.ExitMessageId = cRMspSelectTimeAttendanceRequestMessage_Result2.MessageId;
					timeAttendanceVerifyLanguageViewModel.ExitMessageDetailId = cRMspSelectTimeAttendanceRequestMessage_Result2.MessageDetailId;
					timeAttendanceVerifyLanguageViewModel.ExitMsgdTypeId = cRMspSelectTimeAttendanceRequestMessage_Result2.MsgdTypeId;
					timeAttendanceVerifyLanguageViewModel.ShiftWorkingId = requestData.tmShiftWorkingId;
					timeAttendanceVerifyLanguageViewModel.ShiftWorkingTimeId = requestData.tmShiftWorkingTimeId;
				}
			}
			ObjectResult<CRMspSelectShiftWorkingTimeByDate_Result> objectResult = _dbII.CRMspSelectShiftWorkingTimeByDate(timeAttendanceVerifyLanguageViewModel.tmUserId, value, requestData.tmShiftWorkingId.GetValueOrDefault(), -1, lCID, defLangID);
			CRMspSelectShiftWorkingTimeByDate_Result cRMspSelectShiftWorkingTimeByDate_Result = ((objectResult != null) ? Enumerable.FirstOrDefault<CRMspSelectShiftWorkingTimeByDate_Result>((IEnumerable<CRMspSelectShiftWorkingTimeByDate_Result>)objectResult, (Func<CRMspSelectShiftWorkingTimeByDate_Result, bool>)((CRMspSelectShiftWorkingTimeByDate_Result x) => x.ShiftWorkingTimeId == requestData.tmShiftWorkingTimeId)) : null);
			if (cRMspSelectShiftWorkingTimeByDate_Result != null)
			{
				DateTime dateTime = DateTime.Parse(requestData.tmDate + " " + cRMspSelectShiftWorkingTimeByDate_Result.EntryTime, new CultureInfo("en-US"));
				timeAttendanceVerifyLanguageViewModel.tmEntryBaseDatePersian = cRMspSelectShiftWorkingTimeByDate_Result.EntryTime;
				timeAttendanceVerifyLanguageViewModel.tmEntryBaseDateI = dateTime.ToString("yyyy/MM/dd HH:mm");
				DateTime dateTime2 = DateTime.Parse(requestData.tmDate + " " + cRMspSelectShiftWorkingTimeByDate_Result.ExitTime, new CultureInfo("en-US"));
				timeAttendanceVerifyLanguageViewModel.tmExitBaseDatePersian = cRMspSelectShiftWorkingTimeByDate_Result.ExitTime;
				timeAttendanceVerifyLanguageViewModel.tmExitBaseDateI = dateTime2.ToString("yyyy/MM/dd HH:mm");
				timeAttendanceVerifyLanguageViewModel.tmEntryDelayAllowMin = cRMspSelectShiftWorkingTimeByDate_Result.EntryTimeLateMin;
				timeAttendanceVerifyLanguageViewModel.tmExitHurryAllowMin = cRMspSelectShiftWorkingTimeByDate_Result.ExitTimeSoonMin;
			}
			CRMspSelectTimeAttendanceByDate_Result cRMspSelectTimeAttendanceByDate_Result = Enumerable.FirstOrDefault<CRMspSelectTimeAttendanceByDate_Result>((IEnumerable<CRMspSelectTimeAttendanceByDate_Result>)dbI.CRMspSelectTimeAttendanceByDate(value, timeAttendanceVerifyLanguageViewModel.tmUserId, lCID, defLangID));
			timeAttendanceVerifyLanguageViewModel.VerifyEntryRequestIsRequired = cRMspSelectTimeAttendanceByDate_Result == null;
			if (cRMspSelectTimeAttendanceByDate_Result != null)
			{
				TimeAttendanceVerifyLanguageViewModel timeAttendanceVerifyLanguageViewModel2 = timeAttendanceVerifyLanguageViewModel;
				_ = cRMspSelectTimeAttendanceByDate_Result.tmEntryTime;
				timeAttendanceVerifyLanguageViewModel2.tmCurrentEntryTime = cRMspSelectTimeAttendanceByDate_Result.tmEntryTime.ToString("HH:mm:ss");
				timeAttendanceVerifyLanguageViewModel.tmCurrentEntryRegisterIP = cRMspSelectTimeAttendanceByDate_Result.tmEntryRegisterIP;
				timeAttendanceVerifyLanguageViewModel.tmCurrentExitTime = ((!cRMspSelectTimeAttendanceByDate_Result.tmExitTime.HasValue) ? null : cRMspSelectTimeAttendanceByDate_Result.tmExitTime.Value.ToString("HH:mm:ss"));
				timeAttendanceVerifyLanguageViewModel.tmCurrentExitRegisterIP = cRMspSelectTimeAttendanceByDate_Result.tmExitRegisterIP;
			}
			if (timeAttendanceVerifyLanguageViewModel.EntryMessageId.GetValueOrDefault() != 0 && timeAttendanceVerifyLanguageViewModel.EntryMsgdTypeId.GetValueOrDefault() != 0)
			{
				ReadInternalMessage(timeAttendanceVerifyLanguageViewModel.EntryMessageId.Value, timeAttendanceVerifyLanguageViewModel.EntryMsgdTypeId.Value);
			}
			if (timeAttendanceVerifyLanguageViewModel.ExitMessageId.GetValueOrDefault() != 0 && timeAttendanceVerifyLanguageViewModel.ExitMsgdTypeId.GetValueOrDefault() != 0)
			{
				ReadInternalMessage(timeAttendanceVerifyLanguageViewModel.ExitMessageId.Value, timeAttendanceVerifyLanguageViewModel.ExitMsgdTypeId.Value);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(timeAttendanceVerifyLanguageViewModel);
	}

	[AjaxOnly]
	[HttpPost]
	public JsonResult CTimeAttendanceVerifyReq(string parameters)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel();
		commonReturnResultViewModel.IsDone = false;
		commonReturnResultViewModel.MessageExtra = "";
		int num = 0;
		try
		{
			if (!string.IsNullOrEmpty(parameters))
			{
				TimeAttendanceVerifyLanguageViewModel timeAttendanceVerifyLanguageViewModel = new JavaScriptSerializer().Deserialize<TimeAttendanceVerifyLanguageViewModel>(parameters);
				string text = null;
				DateTime? dateTime = null;
				DateTime? dateTime2 = null;
				DateTime? dateTime3 = null;
				DateTime dateTime4 = default(DateTime);
				string text2 = "";
				if (!string.IsNullOrEmpty(timeAttendanceVerifyLanguageViewModel.tmEntryTime))
				{
					timeAttendanceVerifyLanguageViewModel.tmEntryTime += ":00";
				}
				if (!string.IsNullOrEmpty(timeAttendanceVerifyLanguageViewModel.tmExitTime))
				{
					timeAttendanceVerifyLanguageViewModel.tmExitTime += ":00";
				}
				try
				{
					if (string.IsNullOrEmpty(timeAttendanceVerifyLanguageViewModel.tmDatePersian))
					{
						commonReturnResultViewModel.Message = Messages.msgErrorEnterDate;
						commonReturnResultViewModel.IsDone = false;
						num++;
						return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
					}
					string text3 = DateTime.Now.ToString("HH:mm:ss");
					if (!string.IsNullOrEmpty(timeAttendanceVerifyLanguageViewModel.tmEntryTime))
					{
						text3 = timeAttendanceVerifyLanguageViewModel.tmEntryTime;
					}
					text2 = PersianDate.GetFormatetdDate(timeAttendanceVerifyLanguageViewModel.tmDatePersian.Replace("/", ""));
					dateTime4 = lCID switch
					{
						1065 => DateTime.Parse(text2 + " " + text3, new PersianCulture()), 
						1025 => DateTime.Parse(text2 + " " + text3, new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(text2 + " " + text3, new CultureInfo("en-US")), 
					};
					dateTime = dateTime4;
					text = dateTime4.ToString("yyyyMMdd", new CultureInfo("fa-IR"));
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					commonReturnResultViewModel.Message = Messages.ErrorFormatTime;
					commonReturnResultViewModel.IsDone = false;
					num++;
					return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
				}
				try
				{
					if (!string.IsNullOrEmpty(timeAttendanceVerifyLanguageViewModel.tmEntryTime))
					{
						text2 = PersianDate.GetFormatetdDate(timeAttendanceVerifyLanguageViewModel.tmDatePersian.Replace("/", ""));
						dateTime2 = lCID switch
						{
							1065 => DateTime.Parse(text2 + " " + timeAttendanceVerifyLanguageViewModel.tmEntryTime, new PersianCulture()), 
							1025 => DateTime.Parse(text2 + " " + timeAttendanceVerifyLanguageViewModel.tmEntryTime, new CultureInfo("ar-SA")), 
							_ => DateTime.Parse(text2 + " " + timeAttendanceVerifyLanguageViewModel.tmEntryTime, new CultureInfo("en-US")), 
						};
					}
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
					commonReturnResultViewModel.Message = Messages.ErrorFormatTime;
					commonReturnResultViewModel.IsDone = false;
					num++;
					return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
				}
				try
				{
					if (!string.IsNullOrEmpty(timeAttendanceVerifyLanguageViewModel.tmExitTime))
					{
						text2 = PersianDate.GetFormatetdDate(timeAttendanceVerifyLanguageViewModel.tmDatePersian.Replace("/", ""));
						dateTime3 = lCID switch
						{
							1065 => DateTime.Parse(text2 + " " + timeAttendanceVerifyLanguageViewModel.tmExitTime, new PersianCulture()), 
							1025 => DateTime.Parse(text2 + " " + timeAttendanceVerifyLanguageViewModel.tmExitTime, new CultureInfo("ar-SA")), 
							_ => DateTime.Parse(text2 + " " + timeAttendanceVerifyLanguageViewModel.tmExitTime, new CultureInfo("en-US")), 
						};
					}
				}
				catch (Exception e3)
				{
					ErrorSignal.FromCurrentContext().Raise(e3);
					commonReturnResultViewModel.Message = Messages.ErrorFormatTime;
					commonReturnResultViewModel.IsDone = false;
					num++;
					return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
				}
				int userId = UserLogin.CurrentUser.UserId;
				DateTime now = DateTime.Now;
				short value = short.Parse(now.ToString("yyyy", new PersianCulture()));
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				DateTime value3 = now;
				string text4 = now.ToString("yyyyMMdd", new PersianCulture());
				string appType = Configuration.AppType;
				if (!timeAttendanceVerifyLanguageViewModel.VerifyEntryRequest.GetValueOrDefault() && timeAttendanceVerifyLanguageViewModel.VerifyExitRequest.GetValueOrDefault() && Enumerable.FirstOrDefault<CRMspSelectTimeAttendanceByDate_Result>((IEnumerable<CRMspSelectTimeAttendanceByDate_Result>)dbI.CRMspSelectTimeAttendanceByDate(dateTime, timeAttendanceVerifyLanguageViewModel.tmUserId, lCID, result)) == null)
				{
					commonReturnResultViewModel.Message = Messages.CtmVerifyEntryTimeReqRquiredBecauseIsEmpty;
					commonReturnResultViewModel.IsDone = false;
					num++;
					return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
				}
				if (string.IsNullOrEmpty(timeAttendanceVerifyLanguageViewModel.tmEntryRegisterIP))
				{
					timeAttendanceVerifyLanguageViewModel.tmEntryRegisterIP = null;
				}
				if (string.IsNullOrEmpty(timeAttendanceVerifyLanguageViewModel.tmExitRegisterIP))
				{
					timeAttendanceVerifyLanguageViewModel.tmExitRegisterIP = null;
				}
				int num2 = 0;
				if (timeAttendanceVerifyLanguageViewModel.VerifyEntryRequest.GetValueOrDefault() && timeAttendanceVerifyLanguageViewModel.VerifyExitRequest.GetValueOrDefault())
				{
					num2 = 1;
					timeAttendanceVerifyLanguageViewModel.tmEntryTimeVerifyUserId = userId;
					timeAttendanceVerifyLanguageViewModel.tmEntryTimeVerifyDate = value3;
					timeAttendanceVerifyLanguageViewModel.tmEntryTimeVerifyDatePersian = text4;
					timeAttendanceVerifyLanguageViewModel.tmExitTimeVerifyUserId = userId;
					timeAttendanceVerifyLanguageViewModel.tmExitTimeVerifyDate = value3;
					timeAttendanceVerifyLanguageViewModel.tmExitTimeVerifyDatePersian = text4;
				}
				else if (timeAttendanceVerifyLanguageViewModel.VerifyEntryRequest.GetValueOrDefault())
				{
					num2 = 2;
					timeAttendanceVerifyLanguageViewModel.tmEntryTimeVerifyUserId = userId;
					timeAttendanceVerifyLanguageViewModel.tmEntryTimeVerifyDate = value3;
					timeAttendanceVerifyLanguageViewModel.tmEntryTimeVerifyDatePersian = text4;
				}
				else if (timeAttendanceVerifyLanguageViewModel.VerifyExitRequest.GetValueOrDefault())
				{
					num2 = 3;
					timeAttendanceVerifyLanguageViewModel.tmExitTimeVerifyUserId = userId;
					timeAttendanceVerifyLanguageViewModel.tmExitTimeVerifyDate = value3;
					timeAttendanceVerifyLanguageViewModel.tmExitTimeVerifyDatePersian = text4;
				}
				ObjectParameter objectParameter = new ObjectParameter("Result", 0);
				if (num2 != 0)
				{
					DateTime? dateTime5 = null;
					if (!string.IsNullOrWhiteSpace(timeAttendanceVerifyLanguageViewModel.tmEntryBaseDateI))
					{
						dateTime5 = DateTime.Parse(timeAttendanceVerifyLanguageViewModel.tmEntryBaseDateI);
					}
					DateTime? dateTime6 = null;
					if (!string.IsNullOrWhiteSpace(timeAttendanceVerifyLanguageViewModel.tmExitBaseDateI))
					{
						dateTime6 = DateTime.Parse(timeAttendanceVerifyLanguageViewModel.tmExitBaseDateI);
					}
					int? tmEntryDelay = null;
					int? tmExitHurry = null;
					if (timeAttendanceVerifyLanguageViewModel.ShiftWorkingTimeId.GetValueOrDefault() != 0)
					{
						if (dateTime5.HasValue && dateTime2.HasValue)
						{
							tmEntryDelay = (int?)(dateTime2 - dateTime5)?.TotalMinutes;
						}
						if (dateTime6.HasValue && dateTime3.HasValue)
						{
							tmExitHurry = (int?)(dateTime6 - dateTime3)?.TotalMinutes;
						}
					}
					else if (dateTime2.HasValue && dateTime3.HasValue)
					{
						tmExitHurry = (int?)(dateTime2 - dateTime3)?.TotalMinutes;
					}
					Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbII.CRMspInsertUpdateTimeAttendance(num2, null, dateTime, text, timeAttendanceVerifyLanguageViewModel.tmUserId, tmEntryTime: dateTime2, tmEntryRegisterIP: timeAttendanceVerifyLanguageViewModel.tmEntryRegisterIP, tmExitTime: dateTime3, tmExitRegisterIP: timeAttendanceVerifyLanguageViewModel.tmExitRegisterIP, userId: userId, year1: value, month1: value2, registerDate: value3, registerDatePersian: text4, appType: appType, languageID: lCID, defaultLanguageID: result, result: objectParameter, tmEntryTimeVerifyUserId: timeAttendanceVerifyLanguageViewModel.tmEntryTimeVerifyUserId, tmEntryTimeVerifyDate: timeAttendanceVerifyLanguageViewModel.tmEntryTimeVerifyDate, tmEntryTimeVerifyDatePersian: timeAttendanceVerifyLanguageViewModel.tmEntryTimeVerifyDatePersian, tmExitTimeVerifyUserId: timeAttendanceVerifyLanguageViewModel.tmExitTimeVerifyUserId, tmExitTimeVerifyDate: timeAttendanceVerifyLanguageViewModel.tmExitTimeVerifyDate, tmExitTimeVerifyDatePersian: timeAttendanceVerifyLanguageViewModel.tmExitTimeVerifyDatePersian, tmShiftWorkingTimeId: timeAttendanceVerifyLanguageViewModel.ShiftWorkingTimeId, tmEntryBase: dateTime5, tmEntryDelay: tmEntryDelay, tmEntryDelayAllowMin: timeAttendanceVerifyLanguageViewModel.tmEntryDelayAllowMin, tmExitBase: dateTime6, tmExitHurry: tmExitHurry, tmExitHurryAllowMin: timeAttendanceVerifyLanguageViewModel.tmExitHurryAllowMin, tmDescription: null, tmEntryIsTemp: null, tmExitIsTemp: null));
				}
				else
				{
					objectParameter.Value = 1;
				}
				if (objectParameter != null)
				{
					if (objectParameter.Value.ToString() == "1")
					{
						string msgSubject = "";
						string msgBody = "";
						string msgSubject2 = "";
						string msgBody2 = "";
						bool flag = false;
						bool flag2 = false;
						if (timeAttendanceVerifyLanguageViewModel.VerifyEntryRequest.GetValueOrDefault())
						{
							dbI.CRMspUpdateTimeAttendanceRequestVerified(timeAttendanceVerifyLanguageViewModel.EntryRequestId.Value, true, userId, value3, text4, appType);
							msgSubject = Labels.AttendanceReqVerify;
							msgBody = Labels.AttendanceReqVerifyText;
							flag = true;
						}
						else if (timeAttendanceVerifyLanguageViewModel.UnVerifyEntryRequest.GetValueOrDefault())
						{
							dbI.CRMspUpdateTimeAttendanceRequestVerified(timeAttendanceVerifyLanguageViewModel.EntryRequestId.Value, false, userId, value3, text4, appType);
							msgSubject = Labels.AttendanceReqNotVerify;
							msgBody = Labels.AttendanceReqNotVerifyText;
							flag = true;
						}
						if (timeAttendanceVerifyLanguageViewModel.VerifyExitRequest.GetValueOrDefault())
						{
							dbI.CRMspUpdateTimeAttendanceRequestVerified(timeAttendanceVerifyLanguageViewModel.ExitRequestId.Value, true, userId, value3, text4, appType);
							msgSubject2 = Labels.AttendanceReqVerify;
							msgBody2 = Labels.AttendanceReqVerifyText;
							flag2 = true;
						}
						else if (timeAttendanceVerifyLanguageViewModel.UnVerifyExitRequest.GetValueOrDefault())
						{
							dbI.CRMspUpdateTimeAttendanceRequestVerified(timeAttendanceVerifyLanguageViewModel.ExitRequestId.Value, false, userId, value3, text4, appType);
							msgSubject2 = Labels.AttendanceReqNotVerify;
							msgBody2 = Labels.AttendanceReqNotVerifyText;
							flag2 = true;
						}
						commonReturnResultViewModel.IsDone = true;
						commonReturnResultViewModel.Message = Messages.msgSuccessAction;
						int retId = 0;
						int retId2 = 0;
						InternalMessage internalMessage = new InternalMessage();
						if (flag)
						{
							internalMessage.SendIntmsgSingle(0, msgSubject, msgBody, 19, userId, timeAttendanceVerifyLanguageViewModel.tmUserId, now.ToString("yyyyMMdd", new PersianCulture()), now.ToString("HH:mm:ss"), 0, "", timeAttendanceVerifyLanguageViewModel.EntryRequestId, Messages.ConversationErjaShow, null, out retId, result);
						}
						if (flag2)
						{
							internalMessage.SendIntmsgSingle(0, msgSubject2, msgBody2, 19, userId, timeAttendanceVerifyLanguageViewModel.tmUserId, now.ToString("yyyyMMdd", new PersianCulture()), now.ToString("HH:mm:ss"), 0, "", timeAttendanceVerifyLanguageViewModel.ExitRequestId, Messages.ConversationErjaShow, null, out retId2, result);
						}
					}
					else
					{
						commonReturnResultViewModel.IsDone = false;
						commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
					}
				}
			}
			else
			{
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = Messages.msgSendParameterNotEntered;
			}
		}
		catch (DbEntityValidationException e4)
		{
			commonReturnResultViewModel.IsDone = false;
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e4);
			commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
		}
		catch (Exception e5)
		{
			commonReturnResultViewModel.IsDone = false;
			ErrorSignal.FromCurrentContext().Raise(e5);
			commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
		}
		return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
	}

	public ActionResult CTimeAttendanceVerifyReqMap(string parameters, int mapType = 1)
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		TimeAttendanceVerifyLanguageViewModel timeAttendanceVerifyLanguageViewModel = new TimeAttendanceVerifyLanguageViewModel();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (!string.IsNullOrEmpty(parameters))
			{
				timeAttendanceVerifyLanguageViewModel = new JavaScriptSerializer().Deserialize<TimeAttendanceVerifyLanguageViewModel>(parameters);
				if (mapType == 1)
				{
					timeAttendanceVerifyLanguageViewModel.MapUserLat = timeAttendanceVerifyLanguageViewModel.EntryUserLat;
					timeAttendanceVerifyLanguageViewModel.MapUserLng = timeAttendanceVerifyLanguageViewModel.EntryUserLng;
				}
				else
				{
					timeAttendanceVerifyLanguageViewModel.MapUserLat = timeAttendanceVerifyLanguageViewModel.ExitUserLat;
					timeAttendanceVerifyLanguageViewModel.MapUserLng = timeAttendanceVerifyLanguageViewModel.ExitUserLng;
				}
				CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
				base.ViewBag.CoLat = cRMspSelectCrmsysSetting_Result.CoLatitude;
				base.ViewBag.CoLong = cRMspSelectCrmsysSetting_Result.CoLongitude;
				base.ViewBag.CoZoomLevel = cRMspSelectCrmsysSetting_Result.CoZoom;
				base.ViewBag.CoName = cRMspSelectCrmsysSetting_Result.CoName;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(timeAttendanceVerifyLanguageViewModel);
	}

	[AjaxOnly]
	public string CTMGetAroundCompanies(string polygon = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectCompanyInsidePolygon_Result> value = new List<CRMspSelectCompanyInsidePolygon_Result>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (!string.IsNullOrEmpty(polygon))
			{
				value = Enumerable.ToList<CRMspSelectCompanyInsidePolygon_Result>((IEnumerable<CRMspSelectCompanyInsidePolygon_Result>)dbI.CRMspSelectCompanyInsidePolygon(polygon, lCID, result, result2));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(value);
	}

	public string CTimeSelectTimeAttendanceDetails(int userId = 0, string dt = "")
	{
		List<CRMspSelectTimeAttendanceDetails_Result> value = new List<CRMspSelectTimeAttendanceDetails_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectTimeAttendanceDetails_Result> list = Enumerable.ToList<CRMspSelectTimeAttendanceDetails_Result>((IEnumerable<CRMspSelectTimeAttendanceDetails_Result>)_dbII.CRMspSelectTimeAttendanceDetails(userId, null, DateTime.Parse(dt), lCID, result));
			if (list != null)
			{
				foreach (CRMspSelectTimeAttendanceDetails_Result item in list)
				{
					item.tmdEntryTimeDelayStr = DateTimeClass.GetMinuteInFormat(item.tmdEntryTimeDelay.GetValueOrDefault());
					item.tmdExitTimeDelayStr = DateTimeClass.GetMinuteInFormat(item.tmdExitTimeDelay.GetValueOrDefault());
				}
				value = list;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return JsonConvert.SerializeObject(value);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actcDailyTel")]
	public ActionResult CDailyTel()
	{
		SysSeting.Get();
		string text = (VersionBuyer.Recorder ? "Rec" : "CI");
		base.ViewBag.Mode = text;
		base.ViewBag.IsBuying = VersionBuyer.CallerId;
		SelectUsersExtentions();
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actcDailyTelRegNote")]
	public ActionResult CDailyTelNoteRegister(int callHistoryId)
	{
		_003C_003Ec__DisplayClass106_0 _003C_003Ec__DisplayClass106_ = new _003C_003Ec__DisplayClass106_0();
		_003C_003Ec__DisplayClass106_.callHistoryId = callHistoryId;
		DbSet<CrmCallHistory> crmCallHistory = _dbTbl.CrmCallHistory;
		ParameterExpression val = Expression.Parameter(typeof(CrmCallHistory), "m");
		CrmCallHistory crmCallHistory2 = Queryable.FirstOrDefault<CrmCallHistory>((IQueryable<CrmCallHistory>)crmCallHistory, Expression.Lambda<Func<CrmCallHistory, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass106_, typeof(_003C_003Ec__DisplayClass106_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
		if (crmCallHistory2 == null)
		{
			crmCallHistory2 = new CrmCallHistory();
			crmCallHistory2.UserID = UserLogin.CurrentUser.UserId;
			crmCallHistory2.Year1 = short.Parse(DateTime.Now.ToString("yyyy", new PersianCulture()));
			crmCallHistory2.Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			crmCallHistory2.RegisterDate = DateTime.Now;
			crmCallHistory2.RegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			crmCallHistory2.CallHistoryID = _003C_003Ec__DisplayClass106_.callHistoryId;
		}
		return View(crmCallHistory2);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actcDailyTelRegNote")]
	[HttpPost]
	public ActionResult CDailyTelNoteRegister(CrmCallHistory callHistory)
	{
		_003C_003Ec__DisplayClass107_0 _003C_003Ec__DisplayClass107_ = new _003C_003Ec__DisplayClass107_0();
		_003C_003Ec__DisplayClass107_.callHistory = callHistory;
		string text = "";
		int num = 0;
		try
		{
			if (base.ModelState.IsValid)
			{
				DbSet<CrmCallHistory> crmCallHistory = _dbTbl.CrmCallHistory;
				ParameterExpression val = Expression.Parameter(typeof(CrmCallHistory), "m");
				CrmCallHistory crmCallHistory2 = Queryable.FirstOrDefault<CrmCallHistory>((IQueryable<CrmCallHistory>)crmCallHistory, Expression.Lambda<Func<CrmCallHistory, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass107_, typeof(_003C_003Ec__DisplayClass107_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (crmCallHistory2 != null)
				{
					if (string.IsNullOrEmpty(crmCallHistory2.Note))
					{
						crmCallHistory2.Note = _003C_003Ec__DisplayClass107_.callHistory.Note;
						crmCallHistory2.NoteRegisterUserId = UserLogin.CurrentUser.UserId;
						crmCallHistory2.NoteEditedUserId = UserLogin.CurrentUser.UserId;
					}
					else
					{
						crmCallHistory2.Note = _003C_003Ec__DisplayClass107_.callHistory.Note;
						crmCallHistory2.NoteEditedUserId = UserLogin.CurrentUser.UserId;
					}
				}
				else
				{
					text += Messages.ErrorNotFound;
					num++;
				}
				if (num == 0 && crmCallHistory2 != null)
				{
					crmCallHistory2.AppType = Configuration.AppType;
					_dbTbl.Entry(crmCallHistory2).State = EntityState.Modified;
					_dbTbl.SaveChanges();
					base.ViewBag.SuccessfullEdit = Messages.frmFormBaseEditSuccessFulMessage;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.Error = text;
		return View(_003C_003Ec__DisplayClass107_.callHistory);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actcDailyTelEdit")]
	public ActionResult CDailyTelNumberEdit(int callHistoryId)
	{
		_003C_003Ec__DisplayClass108_0 _003C_003Ec__DisplayClass108_ = new _003C_003Ec__DisplayClass108_0();
		_003C_003Ec__DisplayClass108_.callHistoryId = callHistoryId;
		DbSet<CrmCallHistory> crmCallHistory = _dbTbl.CrmCallHistory;
		ParameterExpression val = Expression.Parameter(typeof(CrmCallHistory), "m");
		CrmCallHistory crmCallHistory2 = Queryable.FirstOrDefault<CrmCallHistory>((IQueryable<CrmCallHistory>)crmCallHistory, Expression.Lambda<Func<CrmCallHistory, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass108_, typeof(_003C_003Ec__DisplayClass108_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
		if (crmCallHistory2 == null)
		{
			crmCallHistory2 = new CrmCallHistory();
			crmCallHistory2.UserID = UserLogin.CurrentUser.UserId;
			crmCallHistory2.Year1 = short.Parse(Financial.Get().Id.ToString());
			crmCallHistory2.Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			crmCallHistory2.RegisterDate = DateTime.Now;
			crmCallHistory2.RegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			crmCallHistory2.CallHistoryID = _003C_003Ec__DisplayClass108_.callHistoryId;
		}
		return View(crmCallHistory2);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actcDailyTelEdit")]
	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult CDailyTelNumberEdit(CrmCallHistory callHistory)
	{
		_003C_003Ec__DisplayClass109_0 _003C_003Ec__DisplayClass109_ = new _003C_003Ec__DisplayClass109_0();
		_003C_003Ec__DisplayClass109_.callHistory = callHistory;
		string text = "";
		int num = 0;
		try
		{
			if (base.ModelState.IsValid)
			{
				DbSet<CrmCallHistory> crmCallHistory = _dbTbl.CrmCallHistory;
				ParameterExpression val = Expression.Parameter(typeof(CrmCallHistory), "m");
				CrmCallHistory crmCallHistory2 = Queryable.FirstOrDefault<CrmCallHistory>((IQueryable<CrmCallHistory>)crmCallHistory, Expression.Lambda<Func<CrmCallHistory, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass109_, typeof(_003C_003Ec__DisplayClass109_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (crmCallHistory2 != null)
				{
					if (!string.IsNullOrEmpty(_003C_003Ec__DisplayClass109_.callHistory.PhoneNumber))
					{
						bool flag = true;
						for (int i = 0; i < _003C_003Ec__DisplayClass109_.callHistory.PhoneNumber.Length; i++)
						{
							if (!char.IsDigit(_003C_003Ec__DisplayClass109_.callHistory.PhoneNumber[i]))
							{
								flag = false;
							}
						}
						if (!flag)
						{
							num++;
							text = text + Messages.CheckTelDigit + "\r\n";
						}
					}
				}
				else
				{
					text += Messages.ErrorNotFound;
					num++;
				}
				if (num == 0)
				{
					crmCallHistory2.PhoneNumber = _003C_003Ec__DisplayClass109_.callHistory.PhoneNumber;
					crmCallHistory2.NumberEditedUserId = UserLogin.CurrentUser.UserId;
					crmCallHistory2.AppType = Configuration.AppType;
					_dbTbl.Entry(crmCallHistory2).State = EntityState.Modified;
					_dbTbl.SaveChanges();
					base.ViewBag.SuccessfullEdit = Messages.frmFormBaseEditSuccessFulMessage;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.Error = text;
		return View(_003C_003Ec__DisplayClass109_.callHistory);
	}

	public List<SelectListItem> SelectUsersExtentions()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int result = 0;
			int value = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
				value = UserLogin.CurrentUser.UserId;
			}
			List<CRMspSelectAllUsersExtensions_Result> list2 = Enumerable.ToList<CRMspSelectAllUsersExtensions_Result>((IEnumerable<CRMspSelectAllUsersExtensions_Result>)dbI.CRMspSelectAllUsersExtensions(value, result));
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<CRMspSelectAllUsersExtensions_Result, SelectListItem>((IEnumerable<CRMspSelectAllUsersExtensions_Result>)list2, (Func<CRMspSelectAllUsersExtensions_Result, SelectListItem>)((CRMspSelectAllUsersExtensions_Result x) => new SelectListItem
				{
					Text = x.Extensions,
					Value = x.Extensions
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.UsersExtentions = list;
		return list;
	}

	public ActionResult ConversationQuickView()
	{
		CRMResultsReminderCartableViewModel model = new CRMResultsReminderCartableViewModel();
		return View(model);
	}

	public ActionResult _PartialConversationQuickView(int id, string kind)
	{
		return PartialView(null);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actcKnowledgeManage")]
	public ActionResult CKnowledgeTank(int knlgid)
	{
		base.ViewBag.KnlgId = knlgid;
		return View();
	}

	public string ChkBeforeSubmitKnlgTank(CrmKnowledgeTank KnlgTank, ref int countError)
	{
		string text = "";
		if (string.IsNullOrEmpty(KnlgTank.knlgTitle))
		{
			text += "عنوان وارد نگردیده!|";
			countError++;
		}
		if (KnlgTank.knlgGroupId == 0)
		{
			text += "گروه وارد نگردیده!";
			countError++;
		}
		if (string.IsNullOrEmpty(KnlgTank.knlgKnowledge))
		{
			text += "دانش مرتبط وارد نگردیده!|";
			countError++;
		}
		return text;
	}

	public ActionResult CKnowledgeTankPreview(int knlgId, string txtSearch, int mode)
	{
		base.ViewBag.knlgId = knlgId;
		base.ViewBag.txtknowledge = txtSearch + "-" + mode;
		return View();
	}

	[AjaxOnly]
	public ActionResult _PartialKnlgPreviewInfo(int knlgid, string kind, string txtknowledge)
	{
		_003C_003Ec__DisplayClass116_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass116_0();
		CS_0024_003C_003E8__locals0.knlgid = knlgid;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CRMspKnlgSearchViewModel cRMspKnlgSearchViewModel = new CRMspKnlgSearchViewModel();
		CS_0024_003C_003E8__locals0.knlg = null;
		try
		{
			if (!string.IsNullOrEmpty(txtknowledge))
			{
				string[] array = txtknowledge.Split(new char[1] { '-' });
				int? rollId = UserLogin.CurrentUser.RollId;
				List<CRMspKnlgSearch_Result> list = Enumerable.ToList<CRMspKnlgSearch_Result>((IEnumerable<CRMspKnlgSearch_Result>)db.CRMspKnlgSearch(array[0], rollId, int.Parse(array[1]), lCID, result));
				if (CS_0024_003C_003E8__locals0.knlgid == 0)
				{
					CS_0024_003C_003E8__locals0.knlg = Enumerable.FirstOrDefault<CRMspKnlgSearch_Result>((IEnumerable<CRMspKnlgSearch_Result>)list);
				}
				else
				{
					switch (kind)
					{
					case "next":
						if (UserLogin.IsUserAccess("frmKnowledgeTankDataEntry", "actNext", UserLogin.CurrentUser))
						{
							CS_0024_003C_003E8__locals0.knlg = Enumerable.FirstOrDefault<CRMspKnlgSearch_Result>((IEnumerable<CRMspKnlgSearch_Result>)list, (Func<CRMspKnlgSearch_Result, bool>)((CRMspKnlgSearch_Result c) => c.KnowledgeTankId > CS_0024_003C_003E8__locals0.knlgid)) ?? Enumerable.FirstOrDefault<CRMspKnlgSearch_Result>((IEnumerable<CRMspKnlgSearch_Result>)Enumerable.OrderByDescending<CRMspKnlgSearch_Result, int>((IEnumerable<CRMspKnlgSearch_Result>)list, (Func<CRMspKnlgSearch_Result, int>)((CRMspKnlgSearch_Result c) => c.KnowledgeTankId)));
						}
						break;
					case "prev":
						if (UserLogin.IsUserAccess("frmKnowledgeTankDataEntry", "actPrior", UserLogin.CurrentUser))
						{
							CS_0024_003C_003E8__locals0.knlg = Enumerable.FirstOrDefault<CRMspKnlgSearch_Result>((IEnumerable<CRMspKnlgSearch_Result>)Enumerable.OrderByDescending<CRMspKnlgSearch_Result, int>((IEnumerable<CRMspKnlgSearch_Result>)list, (Func<CRMspKnlgSearch_Result, int>)((CRMspKnlgSearch_Result c) => c.KnowledgeTankId)), (Func<CRMspKnlgSearch_Result, bool>)((CRMspKnlgSearch_Result c) => c.KnowledgeTankId < CS_0024_003C_003E8__locals0.knlgid)) ?? Enumerable.FirstOrDefault<CRMspKnlgSearch_Result>((IEnumerable<CRMspKnlgSearch_Result>)list);
						}
						break;
					case "first":
						if (UserLogin.IsUserAccess("frmKnowledgeTankDataEntry", "actFirst", UserLogin.CurrentUser))
						{
							CS_0024_003C_003E8__locals0.knlg = Enumerable.FirstOrDefault<CRMspKnlgSearch_Result>((IEnumerable<CRMspKnlgSearch_Result>)list);
						}
						break;
					case "last":
						if (UserLogin.IsUserAccess("frmKnowledgeTankDataEntry", "actLast", UserLogin.CurrentUser))
						{
							CS_0024_003C_003E8__locals0.knlg = Enumerable.FirstOrDefault<CRMspKnlgSearch_Result>((IEnumerable<CRMspKnlgSearch_Result>)Enumerable.OrderByDescending<CRMspKnlgSearch_Result, int>((IEnumerable<CRMspKnlgSearch_Result>)list, (Func<CRMspKnlgSearch_Result, int>)((CRMspKnlgSearch_Result c) => c.KnowledgeTankId)));
						}
						break;
					default:
						CS_0024_003C_003E8__locals0.knlg = Enumerable.FirstOrDefault<CRMspKnlgSearch_Result>((IEnumerable<CRMspKnlgSearch_Result>)list, (Func<CRMspKnlgSearch_Result, bool>)((CRMspKnlgSearch_Result c) => c.KnowledgeTankId == CS_0024_003C_003E8__locals0.knlgid));
						break;
					}
				}
				DateTime now = DateTime.Now;
				if (CS_0024_003C_003E8__locals0.knlg == null)
				{
					CS_0024_003C_003E8__locals0.knlg = new CRMspKnlgSearch_Result();
					CS_0024_003C_003E8__locals0.knlg.RegisterDate = now;
					CS_0024_003C_003E8__locals0.knlg.FirstRegisterDate = now;
					CS_0024_003C_003E8__locals0.knlg.KnowledgeTankId = 0;
				}
				cRMspKnlgSearchViewModel.KnowledgeTankId = CS_0024_003C_003E8__locals0.knlg.KnowledgeTankId;
				cRMspKnlgSearchViewModel.knlgTitle = CS_0024_003C_003E8__locals0.knlg.knlgTitle;
				cRMspKnlgSearchViewModel.knlgSigns = CS_0024_003C_003E8__locals0.knlg.knlgSigns;
				cRMspKnlgSearchViewModel.knlgKnowledge = CS_0024_003C_003E8__locals0.knlg.knlgKnowledge;
				cRMspKnlgSearchViewModel.knlgPriorityId = CS_0024_003C_003E8__locals0.knlg.knlgPriorityId;
				cRMspKnlgSearchViewModel.knowledgeTankPriorityTitle = CS_0024_003C_003E8__locals0.knlg.knowledgeTankPriorityTitle ?? "";
				cRMspKnlgSearchViewModel.knlgGroupId = CS_0024_003C_003E8__locals0.knlg.knlgGroupId;
				cRMspKnlgSearchViewModel.knowledgeTankGroupTitle = CS_0024_003C_003E8__locals0.knlg.knowledgeTankGroupTitle ?? "";
				cRMspKnlgSearchViewModel.FirstRegisterDate = CS_0024_003C_003E8__locals0.knlg.FirstRegisterDate;
				cRMspKnlgSearchViewModel.FirstRegisterDatePersian = CS_0024_003C_003E8__locals0.knlg.FirstRegisterDatePersian;
				cRMspKnlgSearchViewModel.FirstRegisterDatePersian = DateTimeClass.ConvertDateWOSlashToSlash(cRMspKnlgSearchViewModel.FirstRegisterDatePersian);
				cRMspKnlgSearchViewModel.UserId = CS_0024_003C_003E8__locals0.knlg.UserId;
				DbSet<Users> users = _dbTbl.Users;
				ParameterExpression val = Expression.Parameter(typeof(Users), "c");
				Queryable.FirstOrDefault<Users>((IQueryable<Users>)users, Expression.Lambda<Func<Users, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass116_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				cRMspKnlgSearchViewModel.EditedUser = CS_0024_003C_003E8__locals0.knlg.EditedUser ?? "";
				cRMspKnlgSearchViewModel.RegisterUser = CS_0024_003C_003E8__locals0.knlg.RegisterUser ?? "";
				cRMspKnlgSearchViewModel.RegisterDate = CS_0024_003C_003E8__locals0.knlg.RegisterDate;
				cRMspKnlgSearchViewModel.RegisterDatePersian = CS_0024_003C_003E8__locals0.knlg.RegisterDatePersian;
				cRMspKnlgSearchViewModel.RegisterDatePersian = DateTimeClass.ConvertDateWOSlashToSlash(cRMspKnlgSearchViewModel.RegisterDatePersian);
				cRMspKnlgSearchViewModel.EditedUser = Labels.frmRegisterUser + ": " + cRMspKnlgSearchViewModel.EditedUser;
				cRMspKnlgSearchViewModel.RegisterUser = Labels.frmFirstRegisterUser + ": " + cRMspKnlgSearchViewModel.RegisterUser;
				_ = CS_0024_003C_003E8__locals0.knlg.FirstRegisterDate;
				cRMspKnlgSearchViewModel.FirstRegisterDatePersian = CS_0024_003C_003E8__locals0.knlg.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				_ = CS_0024_003C_003E8__locals0.knlg.RegisterDate;
				cRMspKnlgSearchViewModel.RegisterDatePersian = CS_0024_003C_003E8__locals0.knlg.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				string appType = Configuration.AppType;
				if (CS_0024_003C_003E8__locals0.knlg.KnowledgeTankId > 0)
				{
					CRMspknlgSelectKnowledgeTankByRollId_Result cRMspknlgSelectKnowledgeTankByRollId_Result = Enumerable.FirstOrDefault<CRMspknlgSelectKnowledgeTankByRollId_Result>((IEnumerable<CRMspknlgSelectKnowledgeTankByRollId_Result>)db.CRMspknlgSelectKnowledgeTankByRollId(CS_0024_003C_003E8__locals0.knlg.KnowledgeTankId, UserLogin.CurrentUser.RollId, lCID, result));
					if (cRMspknlgSelectKnowledgeTankByRollId_Result != null && cRMspknlgSelectKnowledgeTankByRollId_Result.KnowledgeTankId == cRMspknlgSelectKnowledgeTankByRollId_Result.KnowledgeTankId)
					{
						if (string.IsNullOrEmpty(cRMspknlgSelectKnowledgeTankByRollId_Result.AppType))
						{
							appType = Configuration.AppType;
						}
						appType = cRMspknlgSelectKnowledgeTankByRollId_Result.AppType;
					}
				}
				cRMspKnlgSearchViewModel.AppType = Labels.AppType + ": " + Configuration.GetAppType(appType);
				cRMspKnlgSearchViewModel.EditedUser = cRMspKnlgSearchViewModel.EditedUser + " (" + cRMspKnlgSearchViewModel.AppType + ")";
				cRMspKnlgSearchViewModel.knlgFOCmpCanSee = CS_0024_003C_003E8__locals0.knlg.knlgFOCmpCanSee.GetValueOrDefault();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView(cRMspKnlgSearchViewModel);
	}

	[AjaxOnly]
	public ActionResult _PartialKnlgPreviewShowFilse(int knlgId)
	{
		base.ViewBag.KnlgId = knlgId;
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult _PartialKnlgPreviewShowFilse_Read([DataSourceRequest] DataSourceRequest request, int knlgId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectFilesDirectory_Result> list = new List<CRMspSelectFilesDirectory_Result>();
		try
		{
			if (knlgId != 0)
			{
				list = Files.SelectFilesDirectory("0", "0", "0", "40", knlgId.ToString(), "0", "0", false);
				if (list != null && Enumerable.Any<CRMspSelectFilesDirectory_Result>((IEnumerable<CRMspSelectFilesDirectory_Result>)list))
				{
					foreach (CRMspSelectFilesDirectory_Result item in list)
					{
						if (item.DocDateTime.HasValue)
						{
							DateTime.TryParse(item.DocDateTime.ToString(), out var result2);
							item.DocDate = result2.ToString("yyyy/MM/dd");
						}
						else if (!string.IsNullOrEmpty(item.DocDate))
						{
							if (lCID != 1065)
							{
								item.DocDate = DateTime.ParseExact(PersianDate.GetFormatetdDate(item.DocDate.Replace("/", "")), "yyyy/MM/dd", new PersianCulture()).ToString("yyyy/MM/dd");
							}
							else
							{
								item.DocDate = PersianDate.GetFormatetdDate(item.DocDate.Replace("/", ""));
							}
						}
						if (string.IsNullOrEmpty(item.AppType))
						{
							item.AppType = Configuration.AppType;
						}
						item.AppType = Configuration.GetAppType(item.AppType);
						string text = item.FirstRegisterUser ?? "";
						string text2 = (item.FirstRegisterDate.HasValue ? item.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
						item.FirstRegisterUser = Labels.frmFirstRegisterUser + ": " + text + " (" + text2 + ")";
						string text3 = item.EditUser ?? "";
						_ = item.RegisterDate;
						string text4 = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
						item.EditUser = Labels.frmRegisterUser + ": " + text3 + " (" + Labels.AppType + ":" + item.AppType + ")  (" + text4 + ")";
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult _PartialKnlgPreviewList(string txtknowledge)
	{
		base.ViewBag.txtknowledge = txtknowledge;
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult KnlgPreviewList_Read([DataSourceRequest] DataSourceRequest request, string txtknowledge)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspKnlgSearch_Result> list = new List<CRMspKnlgSearch_Result>();
		try
		{
			if (!string.IsNullOrEmpty(txtknowledge))
			{
				string[] array = txtknowledge.Split(new char[1] { '-' });
				int? rollId = UserLogin.CurrentUser.RollId;
				list = Enumerable.ToList<CRMspKnlgSearch_Result>((IEnumerable<CRMspKnlgSearch_Result>)db.CRMspKnlgSearch(array[0], rollId, int.Parse(array[1]), lCID, result));
				foreach (CRMspKnlgSearch_Result item in list)
				{
					_ = item.FirstRegisterDate;
					item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyyMMdd");
					_ = item.RegisterDate;
					item.RegisterDatePersian = item.RegisterDate.ToString("yyyyMMdd");
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	public ActionResult _PartialShowReminderAlarm()
	{
		return PartialView();
	}

	[AjaxOnly]
	public string CheckVersionSystem(int place)
	{
		string text = "";
		try
		{
			CRMspSelectSystemCrmProject_Result cRMspSelectSystemCrmProject_Result = Enumerable.FirstOrDefault<CRMspSelectSystemCrmProject_Result>((IEnumerable<CRMspSelectSystemCrmProject_Result>)db.CRMspSelectSystemCrmProject());
			string text2 = "";
			if (cRMspSelectSystemCrmProject_Result != null)
			{
				text2 = cRMspSelectSystemCrmProject_Result.Version ?? "";
			}
			if (VersionConfig.CurrentVerWin != text2)
			{
				text = text + "-1|مغايرت در ورژن برنامه\r\n\r\nاين نسخه قديمي تر از آخرين نسخه قابل استفاده مي باشد\r\n\r\nآخرين نسخه:" + VersionConfig.CurrentVerWin + "\r\n\r\nلطفا جهت جلوگيري از مشکلات احتمالي برنامه خود را به روز نمائيد|";
				return text;
			}
			string s = DateTime.Now.ToString("MMdd", new PersianCulture());
			text = ((int.Parse(s) <= 1219 && int.Parse(s) >= 119) ? (text + "|") : (text + "eyd|"));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text;
	}

	[AjaxOnly]
	public string CheckSystemProject(int place)
	{
		string text = "";
		try
		{
			text += "||||";
			DateTime.Now.ToString("yyyyMMdd");
			int result = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbII.CRMspUserReminderCount(UserLogin.CurrentUser.UserId, 1, DateTime.Now, result));
			if (num.HasValue)
			{
				string text2 = text;
				int? num2 = num;
				text = text2 + num2 + "|";
			}
			else
			{
				text += "0|";
			}
			DbSet<CrmUserNotes> crmUserNotes = _dbTbl.CrmUserNotes;
			ParameterExpression val = Expression.Parameter(typeof(CrmUserNotes), "u");
			CrmUserNotes crmUserNotes2 = Queryable.First<CrmUserNotes>((IQueryable<CrmUserNotes>)crmUserNotes, Expression.Lambda<Func<CrmUserNotes, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Property((Expression)null, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmUserNotes2 != null)
			{
				text = text + crmUserNotes2.NoteId + "|" + crmUserNotes2.Note + "|" + crmUserNotes2.Note1 + "|" + crmUserNotes2.Note2 + "|" + crmUserNotes2.Note3 + "|";
			}
			string machineName = Environment.MachineName;
			string userHostAddress = base.Request.UserHostAddress;
			text = text + machineName + "|" + userHostAddress;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text;
	}

	public FileResult GetProfileImage()
	{
		byte[] array = null;
		try
		{
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				array = cRMspSelectCrmsysSetting_Result.CoLoGo;
				new MemoryStream();
				Image.FromStream((Stream)new MemoryStream(array, writable: false));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return File(array, "image/jpeg");
	}

	public ActionResult UserNotesInsert(int noteId)
	{
		CrmUserNotes crmUserNotes = _dbTbl.CrmUserNotes.Find(noteId);
		if (crmUserNotes == null)
		{
			crmUserNotes = new CrmUserNotes();
			crmUserNotes.UserId = UserLogin.CurrentUser.UserId;
			crmUserNotes.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
			crmUserNotes.Year1 = short.Parse(Financial.Get().Id.ToString());
			crmUserNotes.Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			crmUserNotes.RegisterDate = DateTime.Now;
			crmUserNotes.RegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			crmUserNotes.FirstRegisterDate = DateTime.Now;
			crmUserNotes.FirstRegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			crmUserNotes.NoteId = noteId;
		}
		return View(crmUserNotes);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult UserNotesInsert(CrmUserNotes userNote)
	{
		try
		{
			if (base.ModelState.IsValid)
			{
				userNote.UserId = UserLogin.CurrentUser.UserId;
				userNote.Year1 = short.Parse(Financial.Get().Id.ToString());
				userNote.Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
				userNote.RegisterDate = DateTime.Now;
				userNote.RegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
				userNote.AppType = Configuration.AppType;
				_dbTbl.Entry(userNote).State = EntityState.Modified;
				_dbTbl.SaveChanges();
				base.ViewBag.SuccessfullEdit = Messages.frmFormBaseEditSuccessFulMessage;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(userNote);
	}

	[AjaxOnly]
	public string SaveUserNote(int noteId, int mode, string note = "")
	{
		_003C_003Ec__DisplayClass127_0 _003C_003Ec__DisplayClass127_ = new _003C_003Ec__DisplayClass127_0();
		_003C_003Ec__DisplayClass127_.noteId = noteId;
		string result = "";
		try
		{
			DbSet<CrmUserNotes> crmUserNotes = _dbTbl.CrmUserNotes;
			ParameterExpression val = Expression.Parameter(typeof(CrmUserNotes), "c");
			CrmUserNotes crmUserNotes2 = Queryable.FirstOrDefault<CrmUserNotes>((IQueryable<CrmUserNotes>)crmUserNotes, Expression.Lambda<Func<CrmUserNotes, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass127_, typeof(_003C_003Ec__DisplayClass127_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmUserNotes2 != null && _003C_003Ec__DisplayClass127_.noteId > 0)
			{
				switch (mode)
				{
				case 1:
					crmUserNotes2.Note = note;
					break;
				case 2:
					crmUserNotes2.Note1 = note;
					break;
				case 3:
					crmUserNotes2.Note2 = note;
					break;
				case 4:
					crmUserNotes2.Note3 = note;
					break;
				}
				crmUserNotes2.Year1 = short.Parse(Financial.Get().Id.ToString());
				crmUserNotes2.Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
				crmUserNotes2.RegisterDate = DateTime.Now;
				crmUserNotes2.RegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
				crmUserNotes2.AppType = Configuration.AppType;
				_dbTbl.Entry(crmUserNotes2).State = EntityState.Modified;
				_dbTbl.SaveChanges();
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

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actCongratulationNoorooz")]
	public ActionResult CongratulationNoorooz()
	{
		return View();
	}

	public ActionResult WinCallerId()
	{
		base.ViewBag.CurrentUsername = UserLogin.CurrentUser.UserName;
		return View();
	}

	[AjaxOnly]
	public ActionResult _PartialCapabilityDiagram()
	{
		return PartialView();
	}

	public ActionResult _PartialChatUsers()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectActiveUsers_Result> model = new List<CRMspSelectActiveUsers_Result>();
		try
		{
			model = Enumerable.ToList<CRMspSelectActiveUsers_Result>(Enumerable.Where<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)db.CRMspSelectActiveUsers(lCID, result, 0), (Func<CRMspSelectActiveUsers_Result, bool>)((CRMspSelectActiveUsers_Result m) => m.UserId != UserLogin.CurrentUser.UserId)));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView(model);
	}

	[HttpPost]
	[LoginAuthorize]
	public string MainSearchWebSmartWithDelay(string srchVal = "", int? srchType = null, string srchCols = "")
	{
		return JsonConvert.SerializeObject(MainSearch.MainSearchWebSmartWithDelay(srchVal, srchType, srchCols));
	}

	protected override void Dispose(bool disposing)
	{
		db.Dispose();
		_dbTbl.Dispose();
		dbI.Dispose();
		_dbII.Dispose();
		_dbIII.Dispose();
		base.Dispose(disposing);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actcDaily")]
	public ActionResult CDaily()
	{
		return View();
	}

	[HttpPost]
	[LoginAuthorize]
	public List<CRMspUserTreeDailyCartableWeb_Result> UserTreeDailyCartableWeb(string selectedDate = "", bool? isShowTicket = false)
	{
		List<CRMspUserTreeDailyCartableWeb_Result> result = new List<CRMspUserTreeDailyCartableWeb_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			short.Parse(Financial.Get().Id.ToString());
			_ = Financial.Get().Id;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			selectedDate = selectedDate.Replace("/", "");
			DateTime value = DateTime.Now;
			DateTime value2 = DateTime.Now;
			if (selectedDate != "")
			{
				value = DateTime.Parse(PersianDate.GetFormatetdDate(selectedDate) + " 00:00:00");
				value2 = DateTime.Parse(PersianDate.GetFormatetdDate(selectedDate) + " 23:59:59");
			}
			List<CRMspUserTreeDailyCartableWeb_Result> list = Enumerable.ToList<CRMspUserTreeDailyCartableWeb_Result>((IEnumerable<CRMspUserTreeDailyCartableWeb_Result>)_dbI.CRMspUserTreeDailyCartableWeb(userId, 2, value, value2, Labels.AllUsers, lCID, result2, isShowTicket, result3));
			if (list != null)
			{
				result = list;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string UserTreeDailyCartableWebJs(string selectedDate = "", bool? isShowTicket = false)
	{
		return JsonConvert.SerializeObject(UserTreeDailyCartableWeb(selectedDate, isShowTicket));
	}

	public List<CRMspResultsDailyCartableWeb_Result> LoadDailyCartable(int selectedUserId = -1, string selectedDate = "", bool? isShowTicket = false, int lastRowNumber = 0, int pageSize = 300)
	{
		List<CRMspResultsDailyCartableWeb_Result> result = new List<CRMspResultsDailyCartableWeb_Result>();
		try
		{
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
			DateTime.Parse(PersianDate.GetFormatetdDate(selectedDate.Replace("/", "")) + " 23:59:59");
			DateTime value = DateTime.Now;
			DateTime value2 = DateTime.Now;
			if (selectedDate != "")
			{
				value = DateTime.Parse(PersianDate.GetFormatetdDate(selectedDate.Replace("/", "")) + " 00:00:00");
				value2 = DateTime.Parse(PersianDate.GetFormatetdDate(selectedDate.Replace("/", "")) + " 23:59:59");
			}
			List<CRMspResultsDailyCartableWeb_Result> list = Enumerable.ToList<CRMspResultsDailyCartableWeb_Result>((IEnumerable<CRMspResultsDailyCartableWeb_Result>)dbI.CRMspResultsDailyCartableWeb(value, value2, UserLogin.CurrentUser.UserId, selectedUserId, lCID, result2, isShowTicket, lastRowNumber, pageSize, false, result3));
			if (list != null)
			{
				foreach (CRMspResultsDailyCartableWeb_Result item in list)
				{
					List<CRMspResultsDailyCartableWeb_Result> list2 = JsonConvert.DeserializeObject<List<CRMspResultsDailyCartableWeb_Result>>(item.CmpJs);
					if (list2 != null)
					{
						CRMspResultsDailyCartableWeb_Result cRMspResultsDailyCartableWeb_Result = Enumerable.FirstOrDefault<CRMspResultsDailyCartableWeb_Result>((IEnumerable<CRMspResultsDailyCartableWeb_Result>)list2);
						item.CompanyID = cRMspResultsDailyCartableWeb_Result.CompanyID;
						item.CompanyName = cRMspResultsDailyCartableWeb_Result.CompanyName;
						item.cmpPreTel = cRMspResultsDailyCartableWeb_Result.cmpPreTel;
						item.cmpTel = cRMspResultsDailyCartableWeb_Result.cmpTel;
						item.cmpTelUpTo = cRMspResultsDailyCartableWeb_Result.cmpTelUpTo;
						item.cmpTelDesc = cRMspResultsDailyCartableWeb_Result.cmpTelDesc;
						item.cmpPreTelII = cRMspResultsDailyCartableWeb_Result.cmpPreTelII;
						item.cmpTelII = cRMspResultsDailyCartableWeb_Result.cmpTelII;
						item.cmpTelUpToII = cRMspResultsDailyCartableWeb_Result.cmpTelUpToII;
						item.cmpTelIIDesc = cRMspResultsDailyCartableWeb_Result.cmpTelIIDesc;
						item.cmpFax = cRMspResultsDailyCartableWeb_Result.cmpFax;
						item.cmpFaxDesc = cRMspResultsDailyCartableWeb_Result.cmpFaxDesc;
						item.cmpCountryId = cRMspResultsDailyCartableWeb_Result.cmpCountryId;
						item.Country = cRMspResultsDailyCartableWeb_Result.Country;
						item.cmpProvinceId = cRMspResultsDailyCartableWeb_Result.cmpProvinceId;
						item.Province = cRMspResultsDailyCartableWeb_Result.Province;
						item.cmpCityId = cRMspResultsDailyCartableWeb_Result.cmpCityId;
						item.City = cRMspResultsDailyCartableWeb_Result.City;
						item.cmpAddress = cRMspResultsDailyCartableWeb_Result.cmpAddress;
						item.cmpPresentation = cRMspResultsDailyCartableWeb_Result.cmpPresentation;
					}
					List<CRMspResultsDailyCartableWeb_Result> list3 = JsonConvert.DeserializeObject<List<CRMspResultsDailyCartableWeb_Result>>(item.PrsJs);
					if (list3 != null)
					{
						CRMspResultsDailyCartableWeb_Result cRMspResultsDailyCartableWeb_Result2 = Enumerable.FirstOrDefault<CRMspResultsDailyCartableWeb_Result>((IEnumerable<CRMspResultsDailyCartableWeb_Result>)list3);
						item.Person = cRMspResultsDailyCartableWeb_Result2.Person;
						item.prsPreTel = cRMspResultsDailyCartableWeb_Result2.prsPreTel;
						item.prsTel = cRMspResultsDailyCartableWeb_Result2.prsTel;
						item.prsTelUpTo = cRMspResultsDailyCartableWeb_Result2.prsTelUpTo;
						item.prsTelDesc = cRMspResultsDailyCartableWeb_Result2.prsTelDesc;
						item.prsMobile = cRMspResultsDailyCartableWeb_Result2.prsMobile;
					}
					List<CRMspResultsDailyCartableWeb_Result> list4 = JsonConvert.DeserializeObject<List<CRMspResultsDailyCartableWeb_Result>>(item.PrjJs);
					if (list4 != null)
					{
						CRMspResultsDailyCartableWeb_Result cRMspResultsDailyCartableWeb_Result3 = Enumerable.FirstOrDefault<CRMspResultsDailyCartableWeb_Result>((IEnumerable<CRMspResultsDailyCartableWeb_Result>)list4);
						item.prjTitle = cRMspResultsDailyCartableWeb_Result3.prjTitle;
						item.ProjectID = cRMspResultsDailyCartableWeb_Result3.ProjectID;
					}
					if (item.RemindDateTime.HasValue)
					{
						DateTime.TryParse(item.RemindDateTime.ToString(), out var result4);
						item.RemindDate = result4.ToString("yyyy/MM/dd");
					}
					else if (!string.IsNullOrEmpty(item.RemindDate))
					{
						if (lCID != 1065)
						{
							item.RemindDate = DateTime.ParseExact(PersianDate.GetFormatetdDate(item.RemindDate.Replace("/", "")), "yyyy/MM/dd", new PersianCulture()).ToString("yyyy/MM/dd");
						}
						else
						{
							item.RemindDate = PersianDate.GetFormatetdDate(item.RemindDate.Replace("/", ""));
						}
					}
					if (item.cnvsDateTime.HasValue)
					{
						DateTime.TryParse(item.cnvsDateTime.ToString(), out var result5);
						item.cnvsDate = result5.ToString("yyyy/MM/dd");
					}
					else if (!string.IsNullOrEmpty(item.cnvsDate))
					{
						if (lCID != 1065)
						{
							item.cnvsDate = DateTime.ParseExact(PersianDate.GetFormatetdDate(item.cnvsDate.Replace("/", "")), "yyyy/MM/dd", new PersianCulture()).ToString("yyyy/MM/dd");
						}
						else
						{
							item.cnvsDate = PersianDate.GetFormatetdDate(item.cnvsDate.Replace("/", ""));
						}
					}
					item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd");
				}
				result = list;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	public string LoadDailyCartableJs(int selectedUserId = -1, string selectedDate = "", bool? isShowTicket = false, int lastRowNumber = 0, int pageSize = 300)
	{
		return JsonConvert.SerializeObject(LoadDailyCartable(selectedUserId, selectedDate, isShowTicket, lastRowNumber, pageSize));
	}

	[AjaxOnly]
	public ActionResult _PartialCDaily(string cDDate, bool isShowTicket)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		cDDate = cDDate.Replace("/", "");
		DateTime value = DateTime.Now;
		DateTime value2 = DateTime.Now;
		if (cDDate != "")
		{
			value = DateTime.Parse(PersianDate.GetFormatetdDate(cDDate) + " 00:00:00");
			value2 = DateTime.Parse(PersianDate.GetFormatetdDate(cDDate) + " 23:59:59");
		}
		int result2 = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
		}
		int.TryParse(cDDate, out var result3);
		if (result3 <= 0)
		{
			cDDate = DateTime.Now.ToString("yyyyMMdd");
			int.TryParse(cDDate, out result3);
		}
		try
		{
			List<CRMspUserTreeDailyCartable_Result> list = Enumerable.ToList<CRMspUserTreeDailyCartable_Result>((IEnumerable<CRMspUserTreeDailyCartable_Result>)db.CRMspUserTreeDailyCartable(UserLogin.CurrentUser.UserId, 2, value, value2, Labels.AllUsers, lCID, result, isShowTicket, result2));
			List<TreeViewItemModel> list2 = new List<TreeViewItemModel>
			{
				new TreeViewItemModel
				{
					HtmlAttributes = 
					{
						new KeyValuePair<string, string>("accesskey", "-1|-1")
					},
					Id = "-1|-1",
					Text = Labels.Empty,
					ImageUrl = "",
					Items = null
				}
			};
			foreach (CRMspUserTreeDailyCartable_Result item in list)
			{
				TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
				treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.RootId + "|" + item.KeyId));
				treeViewItemModel.Id = item.RootId + "|" + item.KeyId;
				treeViewItemModel.Text = item.KeyName;
				treeViewItemModel.ImageUrl = "";
				treeViewItemModel.Items = null;
				list2.Add(treeViewItemModel);
			}
			base.ViewBag.CDailyTree = list2;
			base.ViewBag.DailyId = UserLogin.CurrentUser.UserId;
			base.ViewBag.cDDate = result3;
			base.ViewBag.DailyIdDate = UserLogin.CurrentUser.UserId + "|" + result3;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult _PartialCDailyGrid(int DailyId, string cDDate, bool isShowTicket)
	{
		if (DailyId == 0)
		{
			DailyId = UserLogin.CurrentUser.UserId;
		}
		string text = ((!(cDDate == "")) ? cDDate.Replace("/", "") : DateTime.Now.ToString("yyyyMMdd"));
		base.ViewBag.DailyIdDate = DailyId + "|" + text + "|" + isShowTicket;
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult CDaily_Read([DataSourceRequest] DataSourceRequest request, string DailyIdDate)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string[] array = DailyIdDate.Split(new char[1] { '|' });
		string text = ((array[1] == "") ? DateTime.Now.ToString("yyyyMMdd") : array[1].Replace("/", ""));
		List<CRMspResultsDailyCartable_Result> list = new List<CRMspResultsDailyCartable_Result>();
		try
		{
			bool result2 = false;
			if (Enumerable.Count<string>((IEnumerable<string>)array) >= 3)
			{
				bool.TryParse(array[2], out result2);
			}
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			if (array[0] != null && int.Parse(array[0]) != 0)
			{
				int TreeKeyId = int.Parse(array[0]);
				DateTime value = DateTime.Now;
				DateTime value2 = DateTime.Now;
				if (text != "")
				{
					value = DateTime.Parse(PersianDate.GetFormatetdDate(text) + " 00:00:00");
					value2 = DateTime.Parse(PersianDate.GetFormatetdDate(text) + " 23:59:59");
				}
				list = ((int.Parse(array[0]) != -1) ? Enumerable.ToList<CRMspResultsDailyCartable_Result>(Enumerable.Where<CRMspResultsDailyCartable_Result>((IEnumerable<CRMspResultsDailyCartable_Result>)db.CRMspResultsDailyCartable(value, value2, UserLogin.CurrentUser.UserId, lCID, result, result2, result3), (Func<CRMspResultsDailyCartable_Result, bool>)((CRMspResultsDailyCartable_Result c) => c.cnvsUserId == TreeKeyId))) : Enumerable.ToList<CRMspResultsDailyCartable_Result>((IEnumerable<CRMspResultsDailyCartable_Result>)db.CRMspResultsDailyCartable(value, value2, UserLogin.CurrentUser.UserId, lCID, result, result2, result3)));
			}
			foreach (CRMspResultsDailyCartable_Result item in list)
			{
				if (item.RemindDateTime.HasValue)
				{
					DateTime.TryParse(item.RemindDateTime.ToString(), out var result4);
					item.RemindDate = result4.ToString("yyyy/MM/dd");
				}
				else if (!string.IsNullOrEmpty(item.RemindDate))
				{
					if (lCID != 1065)
					{
						item.RemindDate = DateTime.ParseExact(PersianDate.GetFormatetdDate(item.RemindDate.Replace("/", "")), "yyyy/MM/dd", new PersianCulture()).ToString("yyyy/MM/dd");
					}
					else
					{
						item.RemindDate = PersianDate.GetFormatetdDate(item.RemindDate.Replace("/", ""));
					}
				}
				if (item.cnvsDateTime.HasValue)
				{
					DateTime.TryParse(item.cnvsDateTime.ToString(), out var result5);
					item.cnvsDate = result5.ToString("yyyy/MM/dd");
				}
				else if (!string.IsNullOrEmpty(item.cnvsDate))
				{
					if (lCID != 1065)
					{
						item.cnvsDate = DateTime.ParseExact(PersianDate.GetFormatetdDate(item.cnvsDate.Replace("/", "")), "yyyy/MM/dd", new PersianCulture()).ToString("yyyy/MM/dd");
					}
					else
					{
						item.cnvsDate = PersianDate.GetFormatetdDate(item.cnvsDate.Replace("/", ""));
					}
				}
				item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd");
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	public ActionResult ConvertVoiceFileToText(int callHistoryId, string filePath, int? devType = 1)
	{
		//IL_0af1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af8: Expected I4, but got Unknown
		//IL_0c0a: Unknown result type (might be due to invalid IL or missing references)
		if (!VersionBuyer.AI)
		{
			return Json(new
			{
				Status = 0,
				Message = Messages.VersionBuyAI,
				Data = new { }
			}, JsonRequestBehavior.AllowGet);
		}
		if (!UserLogin.IsUserAccess("frmMain", "actcDailyTelConvertVoiceToText"))
		{
			return Json(new
			{
				Status = 0,
				Message = Messages.ErrorNotAccess,
				Data = new { }
			}, JsonRequestBehavior.AllowGet);
		}
		string hostname = "";
		string username = "";
		string password = "";
		bool usePassive = false;
		try
		{
			if (filePath != null)
			{
				devType = devType ?? new int?(1);
				if (!string.IsNullOrEmpty(Configuration.PathFtpRecording) && devType.GetValueOrDefault() == 1)
				{
					filePath.ToLower().Replace(Configuration.PathFtpRecording.ToLower(), "");
					_ = Configuration.FacadeFtpRecording;
					hostname = Configuration.PathFtpRecording;
					username = Configuration.UserNameFtpRecording;
					password = Configuration.PasswordFtpRecording;
					usePassive = Configuration.UsePassiveFtpRecording;
				}
				else if (!string.IsNullOrEmpty(Configuration.PathFtpRecordingII) && devType.GetValueOrDefault() == 2)
				{
					filePath.ToLower().Replace(Configuration.PathFtpRecordingII.ToLower(), "");
					_ = Configuration.FacadeFtpRecordingII;
					hostname = Configuration.PathFtpRecordingII;
					username = Configuration.UserNameFtpRecordingII;
					password = Configuration.PasswordFtpRecordingII;
					usePassive = Configuration.UsePassiveFtpRecordingII;
				}
				else
				{
					if (filePath.IndexOf("CRMRecording\\", StringComparison.Ordinal) < 0)
					{
						filePath = "CRMRecording\\" + filePath;
					}
					filePath.ToLower().Replace(Configuration.PathFtp.ToLower(), "");
					_ = Configuration.FacadeFtp;
					hostname = Configuration.PathFtp;
					username = Configuration.UserNameFtp;
					password = Configuration.PasswordFtp;
					usePassive = Configuration.UsePassiveFtp;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		byte[] bytesResponse;
		try
		{
			bytesResponse = new FTPclient(hostname, username, password, usePassive).GetBytesResponse(filePath);
		}
		catch (WebException)
		{
			return Json(new
			{
				Status = 0,
				Message = "دریافت فایل صوتی از FTP با خطا مواجه شد.",
				Data = new { }
			}, JsonRequestBehavior.AllowGet);
		}
		if (bytesResponse == null || bytesResponse.Length == 0)
		{
			return Json(new
			{
				Status = 0,
				Message = "فایل صوتی خالی یا نامعتبر است.",
				Data = new { }
			}, JsonRequestBehavior.AllowGet);
		}
		string extension = Path.GetExtension(filePath);
		if (string.IsNullOrWhiteSpace(extension) && !string.IsNullOrWhiteSpace(filePath))
		{
			extension = Path.GetExtension(filePath);
		}
		extension = (extension ?? "").ToLowerInvariant();
		HashSet<string> obj = new HashSet<string>();
		obj.Add(".mp3");
		obj.Add(".mp4");
		obj.Add(".mpeg");
		obj.Add(".mpga");
		obj.Add(".m4a");
		obj.Add(".wav");
		obj.Add(".webm");
		if (!obj.Contains(extension))
		{
			return Json(new
			{
				Status = 0,
				Message = "فرمت فایل صوتی پشتیبانی نمی\u200cشود.",
				Data = new { }
			}, JsonRequestBehavior.AllowGet);
		}
		if (extension == null)
		{
			goto IL_03ab;
		}
		int length = extension.Length;
		string mediaType;
		if (length != 4)
		{
			if (length != 5)
			{
				goto IL_03ab;
			}
			char c = extension[3];
			if (c != 'b')
			{
				if (c != 'e')
				{
					if (c != 'g' || !(extension == ".mpga"))
					{
						goto IL_03ab;
					}
					mediaType = "audio/mpeg";
				}
				else
				{
					if (!(extension == ".mpeg"))
					{
						goto IL_03ab;
					}
					mediaType = "audio/mpeg";
				}
			}
			else
			{
				if (!(extension == ".webm"))
				{
					goto IL_03ab;
				}
				mediaType = "audio/webm";
			}
		}
		else
		{
			char c = extension[3];
			if ((uint)c <= 52u)
			{
				if (c != '3')
				{
					if (c != '4' || !(extension == ".mp4"))
					{
						goto IL_03ab;
					}
					mediaType = "audio/mp4";
				}
				else
				{
					if (!(extension == ".mp3"))
					{
						goto IL_03ab;
					}
					mediaType = "audio/mpeg";
				}
			}
			else if (c != 'a')
			{
				if (c != 'v' || !(extension == ".wav"))
				{
					goto IL_03ab;
				}
				mediaType = "audio/wav";
			}
			else
			{
				if (!(extension == ".m4a"))
				{
					goto IL_03ab;
				}
				mediaType = "audio/m4a";
			}
		}
		goto IL_03b3;
		IL_03ab:
		mediaType = "application/octet-stream";
		goto IL_03b3;
		IL_03b3:
		try
		{
			using HttpClient httpClient = new HttpClient();
			httpClient.DefaultRequestHeaders.Accept.Clear();
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			JsonConvert.SerializeObject(new
			{
				modelId = -1,
				responseTypeSysTitle = "speech-to-text",
				callHistoryId = callHistoryId,
				languageId = lCID
			});
			string aIDomain = SysSeting.Get().AIDomain;
			if (string.IsNullOrEmpty(aIDomain))
			{
				return Json(new
				{
					Status = 0,
					Message = Messages.msgErrorAIDomainNotFound,
					Data = new { }
				}, JsonRequestBehavior.AllowGet);
			}
			bool result2 = false;
			bool.TryParse(UserAIInProccess.Get(UserLogin.CurrentUser.UserId).ToString(), out result2);
			if (result2)
			{
				return Json(new
				{
					Status = 0,
					Message = Messages.msgErrorAiProcessingQueueConflict,
					Data = new { }
				}, JsonRequestBehavior.AllowGet);
			}
			UserAIInProccess.Update(UserLogin.CurrentUser.UserId, value: true);
			string text = $"?modelId=-1&responseTypeSysTitle=speech-to-text&callHistoryId={callHistoryId}&languageId={lCID}&userId={UserLogin.CurrentUser.UserId}";
			string requestUri = aIDomain + "/api/Answer/GetDataForConvertVoiceToText" + text;
			StringContent content = new StringContent("", Encoding.UTF8, "application/json");
			HttpResponseMessage result3 = httpClient.PostAsync(requestUri, content).Result;
			if (!result3.IsSuccessStatusCode)
			{
				UserAIInProccess.Update(UserLogin.CurrentUser.UserId);
				return Json(new
				{
					Status = 0,
					Message = Messages.msgErrorOperationFailed,
					Data = new { }
				}, JsonRequestBehavior.AllowGet);
			}
			ServiceResult<AIConvertVoiceToTextDataViewModel> serviceResult = JsonConvert.DeserializeObject<ServiceResult<AIConvertVoiceToTextDataViewModel>>(result3.Content.ReadAsStringAsync().Result);
			if (serviceResult == null || serviceResult.Status != ServiceResultStatus.Success)
			{
				UserAIInProccess.Update(UserLogin.CurrentUser.UserId);
				return Json(new
				{
					Status = 0,
					Message = (serviceResult?.Message ?? "پاسخ دریافتی از سرور نامعتبر است."),
					Data = new { }
				}, JsonRequestBehavior.AllowGet);
			}
			if (serviceResult.Data.Response != null)
			{
				UserAIInProccess.Update(UserLogin.CurrentUser.UserId);
				return Json(new
				{
					Status = 1,
					Message = "",
					Data = new
					{
						serviceResult.Data.Response.Text,
						serviceResult.Data.Response.TotalTokens,
						serviceResult.Data.Response.InputTokens,
						serviceResult.Data.Response.OutputTokens
					}
				}, JsonRequestBehavior.AllowGet);
			}
			string text2 = serviceResult.Data.Provider.ApiBaseUrl;
			if (!text2.EndsWith("/"))
			{
				text2 += "/";
			}
			text2 += "v1";
			string requestUri2 = text2 + "/audio/transcriptions";
			HttpClient httpClient2 = new HttpClient();
			httpClient2.Timeout = TimeSpan.FromMinutes(serviceResult.Data.Setting.ProviderTimeOut.GetValueOrDefault(2));
			using HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri2);
			httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", serviceResult.Data.Provider.ApiKey);
			using MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
			multipartFormDataContent.Add(new StringContent("gpt-4o-transcribe"), "model");
			multipartFormDataContent.Add(new StringContent("این فایل صوتی یک مکالمه فارسی است. گفتار را با بیشترین دقت ممکن به متن تبدیل کن و خروجی نهایی را به\u200cصورت یک متن فارسی کاملا\u064b خوانا و ویراستاری\u200cشده برگردان. قوانین الزامی: 1. همه کلمات و جملات گفته\u200cشده را کامل ثبت کن و هیچ بخشی را حذف، خلاصه یا بازنویسی نکن. 2. غلط\u200cهای املایی، کلمات اشتباه تشخیص\u200cداده\u200cشده، علائم نگارشی، فاصله\u200cگذاری و نیم\u200cفاصله\u200cها را اصلاح کن. 3. جمله\u200cها را از نظر نگارشی اصلاح کن، اما معنی، ترتیب مطالب و لحن مکالمه را تغییر نده. 4. نام اشخاص، شرکت\u200cها، برندها، شماره\u200cها و اصطلاحات تخصصی را حدس نزن و تغییر نده؛ اگر نام یا عبارتی نامشخص است، نزدیک\u200cترین شکل شنیده\u200cشده را حفظ کن. 5. عبارات تخصصی انگلیسی را با حروف انگلیسی بنویس؛ مانند CRM، API، AI، OpenAI و ChatGPT. 6. از نوشتن عبارات انگلیسی به\u200cصورت آوایی فارسی مانند «سی آر ام» و «ای پی آی» خودداری کن. 8. کلمات محاوره\u200cای را در صورت امکان به شکل صحیح و خوانا بنویس، اما محتوای گفتار را رسمی یا ادبی نکن. 9. گویندگان را فقط در صورتی جدا کن که از روی صدا یا محتوای مکالمه قابل تشخیص باشند. 10. هیچ توضیح، عنوان، تحلیل، خلاصه، علامت اضافی یا متن خارج از رونوشت تولید نکن. 11. فقط متن نهایی اصلاح\u200cشده را برگردان."), "prompt");
			multipartFormDataContent.Add(new StringContent("json"), "response_format");
			ByteArrayContent byteArrayContent = new ByteArrayContent(bytesResponse);
			byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(mediaType);
			multipartFormDataContent.Add(byteArrayContent, "file", string.IsNullOrWhiteSpace(filePath) ? ("audio" + extension) : filePath);
			httpRequestMessage.Content = multipartFormDataContent;
			using HttpResponseMessage httpResponseMessage = httpClient2.SendAsync(httpRequestMessage).Result;
			string result4 = httpResponseMessage.Content.ReadAsStringAsync().Result;
			if (!httpResponseMessage.IsSuccessStatusCode)
			{
				string text3 = "";
				JObject jObject = null;
				try
				{
					jObject = JObject.Parse(result4);
				}
				catch
				{
				}
				JToken jToken = jObject?["error"];
				if (jToken != null)
				{
					string text4 = jToken["code"]?.Value<string>();
					string text5 = jToken["message"]?.Value<string>();
					switch (text4)
					{
					case "context_window_exceeded":
						text3 = "طول ورودی از حداکثر ظرفیت مدل بیشتر است.";
						break;
					case "invalid_request_format":
						text3 = "فرمت درخواست نامعتبر است. لطفا\u064b پارامترهای ارسالی را بررسی کنید.";
						break;
					case "unsupported_model":
						text3 = "مدل انتخاب شده برای تبدیل صوت به متن پشتیبانی نمی\u200cشود.";
						break;
					case "content_policy_violation":
						text3 = "محتوای فایل صوتی با سیاست\u200cهای امنیتی سرویس مطابقت ندارد.";
						break;
					case "invalid_api_key":
						text3 = "کلید API نامعتبر است. لطفا\u064b با مدیر سیستم تماس بگیرید.";
						break;
					case "insufficient_tier":
					case "model_access_denied":
					case "model_access_limited":
						text3 = "شما به این مدل دسترسی ندارید.";
						break;
					case "resource_not_found":
						text3 = "منبع درخواستی یافت نشد.";
						break;
					case "rate_limit_exceeded":
						text3 = "محدودیت نرخ درخواست. لطفا\u064b چند ثانیه صبر کنید.";
						break;
					case "insufficient_quota":
					case "quota_exceeded":
						text3 = "اعتبار سرویس تمام شده است.";
						break;
					case "service_unavailable":
					case "internal_server_error":
					case "provider_server_error":
					case "model_overloaded":
						text3 = "خطای موقتی در سرور سرویس\u200cدهنده. لطفا\u064b چند لحظه بعد مجددا\u064b تلاش کنید.";
						break;
					default:
						text3 = "خطای سرویس\u200cدهنده: " + text5;
						break;
					}
					UserAIInProccess.Update(UserLogin.CurrentUser.UserId);
					return Json(new
					{
						Status = 0,
						Message = text3,
						Data = new { }
					}, JsonRequestBehavior.AllowGet);
				}
				text3 = (int)httpResponseMessage.StatusCode switch
				{
					400 => "درخواست نادرست است. لطفا\u064b پارامترهای ارسال شده را بررسی کنید.", 
					401 => "احراز هویت ناموفق بود. لطفا\u064b کلید API را بررسی کنید.", 
					403 => "شما به این منبع دسترسی ندارید.", 
					404 => "Endpoint یا منبع درخواستی یافت نشد.", 
					409 => "تداخل در درخواست. لطفا\u064b مجددا\u064b تلاش کنید.", 
					413 => "حجم فایل صوتی بیش از حد مجاز است.", 
					415 => "فرمت فایل صوتی پشتیبانی نمی\u200cشود.", 
					422 => "داده\u200cهای ارسالی از نظر معنایی نادرست هستند.", 
					429 => "محدودیت نرخ درخواست. لطفا\u064b چند ثانیه صبر کنید.", 
					500 => "خطای داخلی سرور. لطفا\u064b بعدا\u064b تلاش کنید.", 
					502 => "خطای Bad Gateway. لطفا\u064b بعدا\u064b تلاش کنید.", 
					503 => "سرویس موقتا\u064b در دسترس نیست.", 
					504 => "زمان انتظار به پایان رسید.", 
					_ => $"خطای ناشناخته ({httpResponseMessage.StatusCode})", 
				};
				UserAIInProccess.Update(UserLogin.CurrentUser.UserId);
				return Json(new
				{
					Status = 0,
					Message = text3,
					Data = new { }
				}, JsonRequestBehavior.AllowGet);
			}
			JObject jObject2;
			try
			{
				jObject2 = JObject.Parse(result4);
			}
			catch
			{
				UserAIInProccess.Update(UserLogin.CurrentUser.UserId);
				return Json(new
				{
					Status = 0,
					Message = "پاسخ دریافتی از سرویس JSON معتبر نیست.",
					Data = new { }
				}, JsonRequestBehavior.AllowGet);
			}
			AITranscribeResponseViewModel aITranscribeResponseViewModel = jObject2.ToObject<AITranscribeResponseViewModel>();
			if (aITranscribeResponseViewModel == null)
			{
				UserAIInProccess.Update(UserLogin.CurrentUser.UserId);
				return Json(new
				{
					Status = 0,
					Message = "پاسخ دریافتی از سرویس ساختار نامعتبری دارد.",
					Data = new { }
				}, JsonRequestBehavior.AllowGet);
			}
			string text6 = aITranscribeResponseViewModel.text?.Trim();
			if (string.IsNullOrWhiteSpace(text6))
			{
				UserAIInProccess.Update(UserLogin.CurrentUser.UserId);
				return Json(new
				{
					Status = 0,
					Message = "متنی از فایل صوتی استخراج نشد.",
					Data = new { }
				}, JsonRequestBehavior.AllowGet);
			}
			AITranscribeUsageViewModel usage = aITranscribeResponseViewModel.usage;
			int inputTokens = usage?.input_tokens ?? 0;
			int outputTokens = usage?.output_tokens ?? 0;
			int totalTokens = usage?.total_tokens ?? 0;
			(usage?.input_token_details?.audio_tokens).GetValueOrDefault();
			(usage?.input_token_details?.text_tokens).GetValueOrDefault();
			JToken? jToken2 = jObject2["estimated_cost"];
			jToken2?["unit"]?.Value<decimal>();
			jToken2?["exchange_rate"]?.Value<decimal>();
			jToken2?["irt"]?.Value<decimal>();
			string text7 = "";
			if (httpResponseMessage.Headers.TryGetValues("x-request-id", out var values))
			{
				text7 = Enumerable.FirstOrDefault<string>(values) ?? "";
			}
			if (usage != null)
			{
				JsonConvert.SerializeObject(usage, Formatting.None);
			}
			Uri.EscapeDataString(result4);
			string text8 = $"?responseTypeId={serviceResult.Data.ResponseType.ResponseTypeId}&providerId={serviceResult.Data.Provider.ProviderId}&callHistoryId={callHistoryId}&languageId={lCID}&outputContentId={text7}&userId={UserLogin.CurrentUser.UserId}";
			string requestUri3 = aIDomain + "/api/Answer/SaveVoiceToTextResponse" + text8;
			StringContent content2 = new StringContent(JsonConvert.SerializeObject(result4), Encoding.UTF8, "application/json");
			HttpResponseMessage result5 = httpClient.PostAsync(requestUri3, content2).Result;
			UserAIInProccess.Update(UserLogin.CurrentUser.UserId);
			_ = result5.IsSuccessStatusCode;
			UserAIInProccess.Update(UserLogin.CurrentUser.UserId);
			return Json(new
			{
				Status = 1,
				Message = "",
				Data = new
				{
					Text = text6,
					TotalTokens = totalTokens,
					InputTokens = inputTokens,
					OutputTokens = outputTokens
				}
			}, JsonRequestBehavior.AllowGet);
		}
		catch (Newtonsoft.Json.JsonException)
		{
			UserAIInProccess.Update(UserLogin.CurrentUser.UserId);
			return Json(new
			{
				Status = 0,
				Message = "خطا در پردازش پاسخ دریافتی از سرویس. لطفا\u064b با پشتیبانی تماس بگیرید.",
				Data = new { }
			}, JsonRequestBehavior.AllowGet);
		}
		catch (InvalidOperationException)
		{
			UserAIInProccess.Update(UserLogin.CurrentUser.UserId);
			return Json(new
			{
				Status = 0,
				Message = "پاسخ دریافتی از سرویس ساختار نامعتبری دارد.",
				Data = new { }
			}, JsonRequestBehavior.AllowGet);
		}
		catch (Exception ex3)
		{
			UserAIInProccess.Update(UserLogin.CurrentUser.UserId);
			return Json(new
			{
				Status = 0,
				Message = "خطای غیرمنتظره در پردازش پاسخ: " + ex3.Message,
				Data = new { }
			}, JsonRequestBehavior.AllowGet);
		}
	}

	[AjaxOnly]
	public JsonResult GetLineNumber(string currentDate)
	{
		string text = ((!string.IsNullOrEmpty(currentDate)) ? currentDate : DateTime.Now.ToString("yyyy/MM/dd"));
		string allLine = Messages.AllLine;
		string line = Messages.Line;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		DateTime value = default(DateTime);
		DateTime value2 = default(DateTime);
		try
		{
			if (!string.IsNullOrEmpty(text))
			{
				text = text.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				switch (lCID)
				{
				case 1065:
					value = DateTime.Parse(PersianDate.GetFormatetdDate(text) + " 00:00:00");
					value2 = DateTime.Parse(PersianDate.GetFormatetdDate(text) + " 23:59:59");
					break;
				case 1025:
					value = DateTime.Parse(PersianDate.GetFormatetdDate(text) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None);
					value2 = DateTime.Parse(PersianDate.GetFormatetdDate(text) + " 23:59:59", new CultureInfo("ar-SA"), DateTimeStyles.None);
					break;
				default:
					value = DateTime.Parse(PersianDate.GetFormatetdDate(text) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None);
					value2 = DateTime.Parse(PersianDate.GetFormatetdDate(text) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None);
					break;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		int result2 = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
		}
		List<CRMspReturnDailyCIRecordVoiceLineNumber_Lang_Result> list = Enumerable.ToList<CRMspReturnDailyCIRecordVoiceLineNumber_Lang_Result>((IEnumerable<CRMspReturnDailyCIRecordVoiceLineNumber_Lang_Result>)db.CRMspReturnDailyCIRecordVoiceLineNumber_Lang(value, value2, "", allLine, line, UserLogin.CurrentUser.UserId, result2));
		List<CrmDroupDownItem> listnumLine = new List<CrmDroupDownItem>();
		foreach (CRMspReturnDailyCIRecordVoiceLineNumber_Lang_Result item in Enumerable.Select(Enumerable.Where(Enumerable.Select((IEnumerable<CRMspReturnDailyCIRecordVoiceLineNumber_Lang_Result>)list, (CRMspReturnDailyCIRecordVoiceLineNumber_Lang_Result item) => new
		{
			item = item,
			indexFind = listnumLine.Find((CrmDroupDownItem l) => l.value == item.LineNumber.ToString())
		}), _003C_003Eh__TransparentIdentifier0 => _003C_003Eh__TransparentIdentifier0.indexFind == null), _003C_003Eh__TransparentIdentifier0 => _003C_003Eh__TransparentIdentifier0.item))
		{
			listnumLine.Add(new CrmDroupDownItem
			{
				text = item.LineName,
				value = item.LineNumber.ToString()
			});
		}
		return Json(listnumLine, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public int UpdateCallHistory(string currentDate, string ModeSrvRIP)
	{
		int result = 0;
		try
		{
			if (ModeSrvRIP == "Rec")
			{
				if (db.CRMspUpdateCallHistoryRecord(DateTime.Parse(currentDate), DateTime.Parse(currentDate)) > 0)
				{
					result = 1;
				}
			}
			else if (ModeSrvRIP == "CI" && db.CRMspUpdateCallHistory(DateTime.Parse(currentDate), DateTime.Parse(currentDate)) > 0)
			{
				result = 1;
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			result = -1;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			result = -1;
		}
		return result;
	}

	[AjaxOnly]
	public ActionResult _PartialCDailyTelGrid(string currentDate, string callTypeId, string callLineNumber, string selectedUserIds = "")
	{
		string text = DateTime.Now.DayOfWeek.ToString();
		DateTime.Now.ToString("yyyy/MM/dd");
		string text2 = currentDate.Replace("/", "");
		base.ViewBag.CallParameter = currentDate + "|" + callTypeId + "|" + callLineNumber + "|" + text2 + "|" + text + "|" + selectedUserIds;
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult CDailyTel_Read([DataSourceRequest] DataSourceRequest request, string callParameter)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		_ = VersionBuyer.Recorder;
		string[] array = callParameter.Split(new char[1] { '|' });
		array[4] = DateTimeClass.DefineDayeOfWeekFaWithoutNull(array[4]);
		List<CRMspReturnDailyCIRecordVoiceInformationViewModel> list = new List<CRMspReturnDailyCIRecordVoiceInformationViewModel>();
		try
		{
			if (array[0] != null && array[0] != "")
			{
				DateTime dateTime = DateTime.ParseExact(array[0].Replace("/", "-"), "yyyy-MM-dd", CultureInfo.DefaultThreadCurrentCulture);
				string userId = UserLogin.CurrentUser.UserId.ToString();
				int result2 = 0;
				if (UserLogin.CurrentUser != null)
				{
					int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
				}
				int result3 = 0;
				int.TryParse(array[6], out result3);
				long result4 = 0L;
				long.TryParse(array[7], out result4);
				result4 *= 60;
				long result5 = 0L;
				long.TryParse(array[8], out result5);
				result5 *= 60;
				bool result6 = false;
				bool.TryParse(array[9], out result6);
				string selectedUserIds = ((array.Length >= 11) ? array[10] : "");
				foreach (mct_CRMspReturnDailyCIRecordVoiceInformationWithOutServiceRIP_Result item in Enumerable.ToList<mct_CRMspReturnDailyCIRecordVoiceInformationWithOutServiceRIP_Result>((IEnumerable<mct_CRMspReturnDailyCIRecordVoiceInformationWithOutServiceRIP_Result>)db.mfi_CRMspReturnDailyCIRecordVoiceInformationWithOutServiceRIP(dateTime.Date, dateTime.Date, "", array[1], array[2], userId, array[3], array[4], lCID, result, array[5], result3, result4, result5, result6, 0, 0, 0, selectedUserIds, result2)))
				{
					CRMspReturnDailyCIRecordVoiceInformationViewModel cRMspReturnDailyCIRecordVoiceInformationViewModel = new CRMspReturnDailyCIRecordVoiceInformationViewModel
					{
						CompanyID = item.CompanyID,
						CompanyPersonID = item.CompanyPersonID,
						PhoneName = item.PhoneName,
						CallTypeId = item.CallTypeId,
						CallType = item.CallType,
						CallTime = item.CallTime,
						CallDate = item.CallDate,
						CallDay = item.CallDay,
						LineNumber = item.LineNumber,
						CallHistoryid = item.CallHistoryid,
						RegisterDate = item.RegisterDate,
						PhoneNumber = item.PhoneNumber,
						PersonId = item.PersonId,
						NoteWithRegEdt = item.NoteWithRegEdt,
						EditedUser = item.EditedUser,
						NoteRegisterUserId = item.NoteRegisterUserId,
						NoteEditedUserId = item.NoteEditedUserId,
						NumberEditedUserId = item.NumberEditedUserId,
						Tamas = item.Tamas,
						Lenght = item.lenght,
						FilePath = item.FilePathWeb,
						rptDate = item.rptDate,
						rptDay = item.rptDay,
						UserName = item.UserName,
						Duration = "0",
						InternalDial = (item.internalDial ?? ""),
						InternalName = (item.internalName ?? ""),
						DevType = item.DevType.GetValueOrDefault(1),
						ConversationID = item.ConversationID,
						cnvsProjectId = item.cnvsProjectId,
						cnvsFirstRegisterUser = (item.cnvsFirstRegisterUser ?? "")
					};
					cRMspReturnDailyCIRecordVoiceInformationViewModel.rptDate = DateTimeClass.ConvertDateWOSlashToSlash(cRMspReturnDailyCIRecordVoiceInformationViewModel.rptDate);
					DateTime.TryParse(cRMspReturnDailyCIRecordVoiceInformationViewModel.RegisterDate.ToString(), out var result7);
					cRMspReturnDailyCIRecordVoiceInformationViewModel.RegisterDateStr = (cRMspReturnDailyCIRecordVoiceInformationViewModel.RegisterDate.HasValue ? result7.ToString("HH:mm:ss tt  dddd  yyyy/MM/dd ") : "");
					list.Add(cRMspReturnDailyCIRecordVoiceInformationViewModel);
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
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult _PartialCDailyTel(string currentDate, string callTypeId, string callLineNumber, string extensionNumber, int conversationStatus, long fCallLength, long tCallLength, bool orderByCmp, int pageFirstId = 0, int pageLastId = 0, int pageSize = 100, string selectedUserIds = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspReturnDailyCIRecordVoiceInformationViewModel> list = new List<CRMspReturnDailyCIRecordVoiceInformationViewModel>();
		try
		{
			DateTime.Now.ToString("yyyy/MM/dd");
			string rptDate = currentDate.Replace("/", "");
			string rptDay = DateTimeClass.DefineDayeOfWeekFaWithoutNull(DateTime.Now.DayOfWeek.ToString());
			if (!string.IsNullOrWhiteSpace(currentDate))
			{
				DateTime dateTime = DateTime.ParseExact(currentDate.Replace("/", "-"), "yyyy-MM-dd", CultureInfo.DefaultThreadCurrentCulture);
				string userId = UserLogin.CurrentUser.UserId.ToString();
				int result2 = 0;
				if (UserLogin.CurrentUser != null)
				{
					int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
				}
				foreach (mct_CRMspReturnDailyCIRecordVoiceInformationWithOutServiceRIP_Result item in Enumerable.ToList<mct_CRMspReturnDailyCIRecordVoiceInformationWithOutServiceRIP_Result>((IEnumerable<mct_CRMspReturnDailyCIRecordVoiceInformationWithOutServiceRIP_Result>)db.mfi_CRMspReturnDailyCIRecordVoiceInformationWithOutServiceRIP(dateTime.Date, dateTime.Date, "", callTypeId, callLineNumber, userId, rptDate, rptDay, lCID, result, extensionNumber, conversationStatus, (fCallLength > 0) ? (fCallLength * 60) : 0, (tCallLength > 0) ? (tCallLength * 60) : 0, orderByCmp, pageSize, pageFirstId, pageLastId, selectedUserIds, result2)))
				{
					CRMspReturnDailyCIRecordVoiceInformationViewModel cRMspReturnDailyCIRecordVoiceInformationViewModel = new CRMspReturnDailyCIRecordVoiceInformationViewModel
					{
						RowNumber = item.RowNumber,
						CompanyID = item.CompanyID,
						CompanyPersonID = item.CompanyPersonID,
						PhoneName = item.PhoneName,
						CallTypeId = item.CallTypeId,
						CallType = item.CallType,
						CallTime = item.CallTime,
						CallDate = item.CallDate,
						CallDay = item.CallDay,
						LineNumber = item.LineNumber,
						CallHistoryid = item.CallHistoryid,
						RegisterDate = item.RegisterDate,
						PhoneNumber = item.PhoneNumber,
						PersonId = item.PersonId,
						NoteWithRegEdt = item.NoteWithRegEdt,
						EditedUser = item.EditedUser,
						NoteRegisterUserId = item.NoteRegisterUserId,
						NoteEditedUserId = item.NoteEditedUserId,
						NumberEditedUserId = item.NumberEditedUserId,
						Tamas = item.Tamas,
						Lenght = item.lenght,
						FilePath = item.FilePathWeb,
						rptDate = item.rptDate,
						rptDay = item.rptDay,
						UserName = item.UserName,
						Duration = "0",
						InternalDial = (item.internalDial ?? ""),
						InternalName = (item.internalName ?? ""),
						DevType = item.DevType.GetValueOrDefault(1),
						ConversationID = item.ConversationID,
						cnvsProjectId = item.cnvsProjectId,
						cnvsFirstRegisterUser = (item.cnvsFirstRegisterUser ?? "")
					};
					cRMspReturnDailyCIRecordVoiceInformationViewModel.rptDate = DateTimeClass.ConvertDateWOSlashToSlash(cRMspReturnDailyCIRecordVoiceInformationViewModel.rptDate);
					DateTime.TryParse(cRMspReturnDailyCIRecordVoiceInformationViewModel.RegisterDate.ToString(), out var result3);
					cRMspReturnDailyCIRecordVoiceInformationViewModel.RegisterDateStr = (cRMspReturnDailyCIRecordVoiceInformationViewModel.RegisterDate.HasValue ? result3.ToString("HH:mm:ss tt  dddd  yyyy/MM/dd ") : "");
					cRMspReturnDailyCIRecordVoiceInformationViewModel.RegisterDateStrI = (cRMspReturnDailyCIRecordVoiceInformationViewModel.RegisterDate.HasValue ? result3.ToString("HH:mm:ss - yyyy/MM/dd ") : "");
					list.Add(cRMspReturnDailyCIRecordVoiceInformationViewModel);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView(list);
	}

	[AjaxOnly]
	public JsonResult CDailyTelList(string currentDate, string callTypeId, string callLineNumber, string extensionNumber, int conversationStatus, long fCallLength, long tCallLength, bool orderByCmp, int pageSize = 100, int lastRowNumberId = 0, string phoneNumber = "", string selectedUserIds = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspReturnDailyCIRecordVoiceInformationViewModel> list = new List<CRMspReturnDailyCIRecordVoiceInformationViewModel>();
		try
		{
			DateTime.Now.ToString("yyyy/MM/dd");
			string rptDate = currentDate.Replace("/", "");
			string rptDay = DateTimeClass.DefineDayeOfWeekFaWithoutNull(DateTime.Now.DayOfWeek.ToString());
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (!string.IsNullOrWhiteSpace(currentDate))
			{
				DateTime dateTime = DateTime.ParseExact(currentDate.Replace("/", "-"), "yyyy-MM-dd", CultureInfo.DefaultThreadCurrentCulture);
				string userId = UserLogin.CurrentUser.UserId.ToString();
				foreach (CRMspResultsCallHistoryCartableWeb_Result item in Enumerable.ToList<CRMspResultsCallHistoryCartableWeb_Result>((IEnumerable<CRMspResultsCallHistoryCartableWeb_Result>)dbI.CRMspResultsCallHistoryCartableWeb(dateTime.Date, dateTime.Date, "", callTypeId, callLineNumber, userId, rptDate, rptDay, lCID, result, extensionNumber, conversationStatus, (fCallLength > 0) ? (fCallLength * 60) : 0, (tCallLength > 0) ? (tCallLength * 60) : 0, orderByCmp, pageSize, lastRowNumberId, phoneNumber, false, selectedUserIds, result2)))
				{
					string text = "";
					try
					{
						if (!string.IsNullOrWhiteSpace(item.CallDate) && !string.IsNullOrEmpty(item.CallTime))
						{
							text = PersianDate.GetFormatetdDate(item.CallDate.Replace("/", ""));
							switch (lCID)
							{
							case 1065:
								item.CallDate = DateTime.Parse(text + " " + item.CallTime, new PersianCulture()).ToString("yyyy/MM/dd HH:mm:ss", new PersianCulture());
								break;
							case 1025:
								item.CallDate = DateTime.Parse(text + " " + item.CallTime, new CultureInfo("ar-SA")).ToString("yyyy/MM/dd HH:mm:ss", new CultureInfo("ar-SA"));
								break;
							default:
								item.CallDate = DateTime.Parse(text + " " + item.CallTime, new CultureInfo("en-US")).ToString("yyyy/MM/dd HH:mm:ss", new CultureInfo("en-US"));
								break;
							}
						}
						else
						{
							item.CallDate = "";
							item.CallTime = "";
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
					}
					CRMspReturnDailyCIRecordVoiceInformationViewModel cRMspReturnDailyCIRecordVoiceInformationViewModel = new CRMspReturnDailyCIRecordVoiceInformationViewModel
					{
						RowNumber = item.RowNumber,
						CompanyID = item.CompanyID,
						CompanyPersonID = item.CompanyPersonID,
						PhoneName = item.PhoneName,
						CallTypeId = item.CallTypeId,
						CallType = item.CallType,
						CallTime = item.CallTime,
						CallDate = item.CallDate,
						TrunkSource = item.TrunkSource,
						TrunkDestination = item.TrunkDestination,
						CallDateTime = item.CallDateTime,
						ExtensionUserName = item.ExtensionUserName,
						CallDay = item.CallDay,
						LineNumber = item.LineNumber,
						CallHistoryid = item.CallHistoryid,
						RegisterDate = item.RegisterDate,
						PhoneNumber = item.PhoneNumber,
						PersonId = item.PersonId,
						NoteWithRegEdt = item.NoteWithRegEdt,
						EditedUser = item.EditedUser,
						NoteRegisterUserId = item.NoteRegisterUserId,
						NoteEditedUserId = item.NoteEditedUserId,
						NumberEditedUserId = item.NumberEditedUserId,
						Tamas = item.Tamas,
						Lenght = item.lenght,
						FilePath = item.FilePathWeb,
						rptDate = item.rptDate,
						rptDay = item.rptDay,
						UserName = item.UserName,
						Duration = item.lenght,
						InternalDial = (item.internalDial ?? ""),
						InternalName = (item.internalName ?? ""),
						DevType = item.DevType.GetValueOrDefault(1),
						ConversationID = item.ConversationID,
						cnvsProjectId = item.cnvsProjectId,
						cnvsFirstRegisterUser = (item.cnvsFirstRegisterUser ?? ""),
						IsFinished = item.IsFinished,
						IVRAuthResult = item.IVRAuthResult,
						cmpNumber = item.cmpNumber,
						cmpUserName = item.cmpUserName,
						FirstRegisterUserId = item.FirstRegisterUserId,
						FirstRegisterUser = item.FirstRegisterUser,
						TodayCallCnt = item.TodayCallCnt,
						TodayCallDuration = item.TodayCallDuration
					};
					cRMspReturnDailyCIRecordVoiceInformationViewModel.rptDate = DateTimeClass.ConvertDateWOSlashToSlash(cRMspReturnDailyCIRecordVoiceInformationViewModel.rptDate);
					DateTime.TryParse(cRMspReturnDailyCIRecordVoiceInformationViewModel.RegisterDate.ToString(), out var result3);
					cRMspReturnDailyCIRecordVoiceInformationViewModel.RegisterDateStr = (cRMspReturnDailyCIRecordVoiceInformationViewModel.RegisterDate.HasValue ? result3.ToString("HH:mm:ss tt  dddd  yyyy/MM/dd ") : "");
					cRMspReturnDailyCIRecordVoiceInformationViewModel.RegisterDateStrI = (cRMspReturnDailyCIRecordVoiceInformationViewModel.RegisterDate.HasValue ? result3.ToString("HH:mm:ss") : "");
					list.Add(cRMspReturnDailyCIRecordVoiceInformationViewModel);
				}
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[HttpPost]
	[LoginAuthorize]
	public string CDailyTelMissedCallsList(string fDate = "", string tDate = "", string callLineNumber = "", string extensionNumber = "", bool orderByCmp = false, string phoneNumber = "", string selectedUserIds = "")
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
			int userId = UserLogin.CurrentUser.UserId;
			string rptDay = DateTimeClass.DefineDayeOfWeekFaWithoutNull(DateTime.Now.DayOfWeek.ToString());
			string rptDate = fDate.Replace("/", "");
			DateTime dateTime = DateTime.ParseExact(fDate.Replace("/", "-"), "yyyy-MM-dd", CultureInfo.DefaultThreadCurrentCulture);
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			List<CRMspSelectCallHistoryMissedCalls_Result> list = Enumerable.ToList<CRMspSelectCallHistoryMissedCalls_Result>((IEnumerable<CRMspSelectCallHistoryMissedCalls_Result>)_dbI.CRMspSelectCallHistoryMissedCalls(userId, dateTime.Date, dateTime.Date, rptDate, rptDay, lCID, result2, callLineNumber, extensionNumber, orderByCmp, phoneNumber, selectedUserIds, result3));
			if (list != null)
			{
				foreach (CRMspSelectCallHistoryMissedCalls_Result item in list)
				{
					item.RegisterDatePersian = item.RegisterDate.ToString("HH:mm:ss");
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

	public JsonResult ChartDailyTelGroupByCallTypeIdDuration(string fDate = "", string tDate = "")
	{
		List<CRMspChartDailyTelGroupByCallTypeIdDuration_Result> data = new List<CRMspChartDailyTelGroupByCallTypeIdDuration_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result2 = 0;
			int value = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
				value = UserLogin.CurrentUser.UserId;
			}
			DateTime value2 = DateTime.Now;
			DateTime value3 = DateTime.Now;
			if (!string.IsNullOrWhiteSpace(fDate) && !string.IsNullOrWhiteSpace(tDate))
			{
				try
				{
					fDate = PersianDate.GetFormatetdDate(fDate.Replace("/", ""));
					value2 = lCID switch
					{
						1065 => DateTime.Parse(fDate + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()), 
						1025 => DateTime.Parse(fDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(fDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")), 
					};
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
				try
				{
					tDate = PersianDate.GetFormatetdDate(tDate.Replace("/", ""));
					value3 = lCID switch
					{
						1065 => DateTime.Parse(tDate + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()), 
						1025 => DateTime.Parse(tDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(tDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")), 
					};
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
				}
			}
			data = Enumerable.ToList<CRMspChartDailyTelGroupByCallTypeIdDuration_Result>((IEnumerable<CRMspChartDailyTelGroupByCallTypeIdDuration_Result>)_dbI.CRMspChartDailyTelGroupByCallTypeIdDuration(value2, value3, lCID, result, value, result2));
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	public JsonResult ChartDailyTelGroupByCallTypeIdCnt(string fDate = "", string tDate = "")
	{
		List<CRMspChartDailyTelGroupByCallTypeId_Result> data = new List<CRMspChartDailyTelGroupByCallTypeId_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result2 = 0;
			int value = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
				value = UserLogin.CurrentUser.UserId;
			}
			DateTime value2 = DateTime.Now;
			DateTime value3 = DateTime.Now;
			if (!string.IsNullOrWhiteSpace(fDate) && !string.IsNullOrWhiteSpace(tDate))
			{
				try
				{
					fDate = PersianDate.GetFormatetdDate(fDate.Replace("/", ""));
					value2 = lCID switch
					{
						1065 => DateTime.Parse(fDate + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()), 
						1025 => DateTime.Parse(fDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(fDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")), 
					};
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
				try
				{
					tDate = PersianDate.GetFormatetdDate(tDate.Replace("/", ""));
					value3 = lCID switch
					{
						1065 => DateTime.Parse(tDate + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()), 
						1025 => DateTime.Parse(tDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(tDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")), 
					};
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
				}
			}
			data = Enumerable.ToList<CRMspChartDailyTelGroupByCallTypeId_Result>((IEnumerable<CRMspChartDailyTelGroupByCallTypeId_Result>)_dbI.CRMspChartDailyTelGroupByCallTypeId(value2, value3, lCID, result, value, result2));
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	public JsonResult ChartDailyTelGroupByLineNumber(string fDate = "", string tDate = "")
	{
		List<CRMspChartDailyTelGroupByLineNumber_Result> data = new List<CRMspChartDailyTelGroupByLineNumber_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result2 = 0;
			int value = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
				value = UserLogin.CurrentUser.UserId;
			}
			DateTime value2 = DateTime.Now;
			DateTime value3 = DateTime.Now;
			if (!string.IsNullOrWhiteSpace(fDate) && !string.IsNullOrWhiteSpace(tDate))
			{
				try
				{
					fDate = PersianDate.GetFormatetdDate(fDate.Replace("/", ""));
					value2 = lCID switch
					{
						1065 => DateTime.Parse(fDate + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()), 
						1025 => DateTime.Parse(fDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(fDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")), 
					};
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
				try
				{
					tDate = PersianDate.GetFormatetdDate(tDate.Replace("/", ""));
					value3 = lCID switch
					{
						1065 => DateTime.Parse(tDate + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()), 
						1025 => DateTime.Parse(tDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(tDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")), 
					};
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
				}
			}
			data = Enumerable.ToList<CRMspChartDailyTelGroupByLineNumber_Result>((IEnumerable<CRMspChartDailyTelGroupByLineNumber_Result>)_dbI.CRMspChartDailyTelGroupByLineNumber(value2, value3, value, result2));
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	public JsonResult ChartDailyTelGroupByLineNumberDuration(string fDate = "", string tDate = "")
	{
		List<CRMspChartDailyTelGroupByLineNumberDuration_Result> data = new List<CRMspChartDailyTelGroupByLineNumberDuration_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result2 = 0;
			int value = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
				value = UserLogin.CurrentUser.UserId;
			}
			DateTime value2 = DateTime.Now;
			DateTime value3 = DateTime.Now;
			if (!string.IsNullOrWhiteSpace(fDate) && !string.IsNullOrWhiteSpace(tDate))
			{
				try
				{
					fDate = PersianDate.GetFormatetdDate(fDate.Replace("/", ""));
					value2 = lCID switch
					{
						1065 => DateTime.Parse(fDate + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()), 
						1025 => DateTime.Parse(fDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(fDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")), 
					};
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
				try
				{
					tDate = PersianDate.GetFormatetdDate(tDate.Replace("/", ""));
					value3 = lCID switch
					{
						1065 => DateTime.Parse(tDate + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()), 
						1025 => DateTime.Parse(tDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(tDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")), 
					};
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
				}
			}
			data = Enumerable.ToList<CRMspChartDailyTelGroupByLineNumberDuration_Result>((IEnumerable<CRMspChartDailyTelGroupByLineNumberDuration_Result>)_dbI.CRMspChartDailyTelGroupByLineNumberDuration(value2, value3, value, result2));
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	public JsonResult ChartDailyTelGroupByExtensionNumber(string fDate = "", string tDate = "")
	{
		List<CRMspChartDailyTelGroupByExtensionNumber_Result> data = new List<CRMspChartDailyTelGroupByExtensionNumber_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result2 = 0;
			int value = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
				value = UserLogin.CurrentUser.UserId;
			}
			DateTime value2 = DateTime.Now;
			DateTime value3 = DateTime.Now;
			if (!string.IsNullOrWhiteSpace(fDate) && !string.IsNullOrWhiteSpace(tDate))
			{
				try
				{
					fDate = PersianDate.GetFormatetdDate(fDate.Replace("/", ""));
					value2 = lCID switch
					{
						1065 => DateTime.Parse(fDate + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()), 
						1025 => DateTime.Parse(fDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(fDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")), 
					};
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
				try
				{
					tDate = PersianDate.GetFormatetdDate(tDate.Replace("/", ""));
					value3 = lCID switch
					{
						1065 => DateTime.Parse(tDate + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()), 
						1025 => DateTime.Parse(tDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(tDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")), 
					};
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
				}
			}
			data = Enumerable.ToList<CRMspChartDailyTelGroupByExtensionNumber_Result>((IEnumerable<CRMspChartDailyTelGroupByExtensionNumber_Result>)_dbI.CRMspChartDailyTelGroupByExtensionNumber(value2, value3, lCID, result, value, result2));
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	public JsonResult ChartDailyTelGroupByConversationState(string fDate = "", string tDate = "")
	{
		List<CRMspChartDailyTelGroupByConversationState_Result> data = new List<CRMspChartDailyTelGroupByConversationState_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result2 = 0;
			int value = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
				value = UserLogin.CurrentUser.UserId;
			}
			DateTime value2 = DateTime.Now;
			DateTime value3 = DateTime.Now;
			if (!string.IsNullOrWhiteSpace(fDate) && !string.IsNullOrWhiteSpace(tDate))
			{
				try
				{
					fDate = PersianDate.GetFormatetdDate(fDate.Replace("/", ""));
					value2 = lCID switch
					{
						1065 => DateTime.Parse(fDate + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()), 
						1025 => DateTime.Parse(fDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(fDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")), 
					};
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
				try
				{
					tDate = PersianDate.GetFormatetdDate(tDate.Replace("/", ""));
					value3 = lCID switch
					{
						1065 => DateTime.Parse(tDate + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()), 
						1025 => DateTime.Parse(tDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(tDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")), 
					};
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
				}
			}
			data = Enumerable.ToList<CRMspChartDailyTelGroupByConversationState_Result>((IEnumerable<CRMspChartDailyTelGroupByConversationState_Result>)_dbI.CRMspChartDailyTelGroupByConversationState(value2, value3, value, result2));
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	public JsonResult ChartDailyTelGroupByCmpDuration(string fDate = "", string tDate = "")
	{
		List<CRMspChartDailyTelGroupByCmpDuration_Result> data = new List<CRMspChartDailyTelGroupByCmpDuration_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result2 = 0;
			int value = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
				value = UserLogin.CurrentUser.UserId;
			}
			DateTime value2 = DateTime.Now;
			DateTime value3 = DateTime.Now;
			if (!string.IsNullOrWhiteSpace(fDate) && !string.IsNullOrWhiteSpace(tDate))
			{
				try
				{
					fDate = PersianDate.GetFormatetdDate(fDate.Replace("/", ""));
					value2 = lCID switch
					{
						1065 => DateTime.Parse(fDate + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()), 
						1025 => DateTime.Parse(fDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(fDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")), 
					};
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
				try
				{
					tDate = PersianDate.GetFormatetdDate(tDate.Replace("/", ""));
					value3 = lCID switch
					{
						1065 => DateTime.Parse(tDate + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()), 
						1025 => DateTime.Parse(tDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(tDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")), 
					};
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
				}
			}
			data = Enumerable.ToList<CRMspChartDailyTelGroupByCmpDuration_Result>((IEnumerable<CRMspChartDailyTelGroupByCmpDuration_Result>)_dbI.CRMspChartDailyTelGroupByCmpDuration(value2, value3, lCID, result, value, result2));
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	public JsonResult ChartDailyTelCallTypesDurationGroupByHour(string fDate = "", string tDate = "")
	{
		List<CRMspChartDailyTelCallTypesDurationGroupByHour_Result> data = new List<CRMspChartDailyTelCallTypesDurationGroupByHour_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result2 = 0;
			int value = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
				value = UserLogin.CurrentUser.UserId;
			}
			DateTime value2 = DateTime.Now;
			DateTime value3 = DateTime.Now;
			if (!string.IsNullOrWhiteSpace(fDate) && !string.IsNullOrWhiteSpace(tDate))
			{
				try
				{
					fDate = PersianDate.GetFormatetdDate(fDate.Replace("/", ""));
					value2 = lCID switch
					{
						1065 => DateTime.Parse(fDate + " 00:00:00", new PersianCulture()), 
						1025 => DateTime.Parse(fDate + " 00:00:00", new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(fDate + " 00:00:00", new CultureInfo("en-US")), 
					};
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
				try
				{
					tDate = PersianDate.GetFormatetdDate(tDate.Replace("/", ""));
					value3 = lCID switch
					{
						1065 => DateTime.Parse(tDate + " 23:59:59", new PersianCulture()), 
						1025 => DateTime.Parse(tDate + " 23:59:59", new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(tDate + " 23:59:59", new CultureInfo("en-US")), 
					};
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
				}
			}
			data = Enumerable.ToList<CRMspChartDailyTelCallTypesDurationGroupByHour_Result>((IEnumerable<CRMspChartDailyTelCallTypesDurationGroupByHour_Result>)_dbI.CRMspChartDailyTelCallTypesDurationGroupByHour(value2, value3, value, result2));
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	public JsonResult ChartDailyTelGroupByCmpDurationAndExten(string fDate = "", string tDate = "")
	{
		List<CRMspChartDailyTelGroupByCmpDurationAndExten_Result> data = new List<CRMspChartDailyTelGroupByCmpDurationAndExten_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result2 = 0;
			int value = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
				value = UserLogin.CurrentUser.UserId;
			}
			DateTime value2 = DateTime.Now;
			DateTime value3 = DateTime.Now;
			if (!string.IsNullOrWhiteSpace(fDate) && !string.IsNullOrWhiteSpace(tDate))
			{
				try
				{
					fDate = PersianDate.GetFormatetdDate(fDate.Replace("/", ""));
					value2 = lCID switch
					{
						1065 => DateTime.Parse(fDate + " 06:00:00", new PersianCulture()), 
						1025 => DateTime.Parse(fDate + " 06:00:00", new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(fDate + " 06:00:00", new CultureInfo("en-US")), 
					};
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
				try
				{
					tDate = PersianDate.GetFormatetdDate(tDate.Replace("/", ""));
					value3 = lCID switch
					{
						1065 => DateTime.Parse(tDate + " 18:00:00", new PersianCulture()), 
						1025 => DateTime.Parse(tDate + " 18:00:00", new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(tDate + " 18:00:00", new CultureInfo("en-US")), 
					};
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
				}
			}
			data = Enumerable.ToList<CRMspChartDailyTelGroupByCmpDurationAndExten_Result>((IEnumerable<CRMspChartDailyTelGroupByCmpDurationAndExten_Result>)_dbI.CRMspChartDailyTelGroupByCmpDurationAndExten(value2, value3, lCID, result, value, result2));
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actcDailyTelInsertCnvs")]
	public ActionResult CDailyTelSelectCmpProjects(int callHistoryId, int cmpId, int prsId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		GetCmpProjects(cmpId);
		GetCmpPerson(cmpId);
		base.ViewBag.CmpName = CRMIdeal.Classes.Helper.Company.GetCompanyNameWithTitle(cmpId);
		base.ViewBag.CmpId = cmpId;
		base.ViewBag.CallHistoryId = callHistoryId;
		return View();
	}

	public ActionResult CDailyTelShowText(int callHistoryId, int cmpId, int prsId, int cnvsId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		base.ViewBag.CmpName = CRMIdeal.Classes.Helper.Company.GetCompanyNameWithTitle(cmpId);
		base.ViewBag.CmpId = cmpId;
		base.ViewBag.PrsId = prsId;
		base.ViewBag.CnvsId = cnvsId;
		base.ViewBag.CallHistoryId = callHistoryId;
		GetUserCreditBalance();
		return View();
	}

	public ActionResult GetUserCreditBalance()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int num = 0;
		try
		{
			using HttpClient httpClient = new HttpClient
			{
				Timeout = TimeSpan.FromSeconds(800.0)
			};
			string aIDomain = SysSeting.Get().AIDomain;
			if (string.IsNullOrEmpty(aIDomain))
			{
				base.ViewBag.Error = Messages.msgErrorAIDomainNotFound;
				return View(new AIAnswerViewModel());
			}
			string content = JsonConvert.SerializeObject(new
			{
				LanguageId = lCID,
				UserId = UserLogin.CurrentUser.UserId
			});
			string requestUri = aIDomain + "/api/Response/GetUserCreditBalance";
			StringContent content2 = new StringContent(content, Encoding.UTF8, "application/json");
			if (result <= 0)
			{
				result = 1065;
			}
			HttpResponseMessage result2 = httpClient.PostAsync(requestUri, content2).Result;
			if (result2.IsSuccessStatusCode)
			{
				num = JsonConvert.DeserializeObject<ServiceResult<int>>(result2.Content.ReadAsStringAsync().Result).Data;
				if (num < 0)
				{
					num = 0;
				}
				base.ViewBag.UserCreditBalance = num;
				return Json(new
				{
					userCreditBalance = num
				}, JsonRequestBehavior.AllowGet);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(new
		{
			userCreditBalance = num,
			Message = Messages.msgErrorOperationFailed
		}, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCmpPerson(int cmpId)
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
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectCompanyPersons_Result> list2 = CRMIdeal.Classes.Helper.Company.SelectCompanyPersons(cmpId);
			list.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "-1",
				Selected = false
			});
			list.AddRange(Enumerable.Select<CRMspSelectCompanyPersons_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyPersons_Result>)list2, (Func<CRMspSelectCompanyPersons_Result, SelectListItem>)((CRMspSelectCompanyPersons_Result item) => new SelectListItem
			{
				Text = item.PersonTitleName,
				Value = item.CompanyPersonID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PersonList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCmpProjects(int cmpId, int prjId = 0)
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
			if (cmpId > 0)
			{
				List<WSspSelectCrmProjectBycmpAndUser_Result> list2 = Enumerable.ToList<WSspSelectCrmProjectBycmpAndUser_Result>((IEnumerable<WSspSelectCrmProjectBycmpAndUser_Result>)db.WSspSelectCrmProjectBycmpAndUser(cmpId, UserLogin.CurrentUser.UserId, lCID, result, result2));
				list.Add(new SelectListItem
				{
					Text = Labels.SelectedListDefValue,
					Value = "-1",
					Selected = false
				});
				list.AddRange(Enumerable.Select<WSspSelectCrmProjectBycmpAndUser_Result, SelectListItem>((IEnumerable<WSspSelectCrmProjectBycmpAndUser_Result>)list2, (Func<WSspSelectCrmProjectBycmpAndUser_Result, SelectListItem>)((WSspSelectCrmProjectBycmpAndUser_Result item) => new SelectListItem
				{
					Text = item.prjTitle,
					Value = item.ProjectID.ToString(),
					Selected = false
				})));
				if (list != null && Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)list))
				{
					if (prjId != 0)
					{
						if (Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list, (Func<SelectListItem, bool>)((SelectListItem m) => m.Value == prjId.ToString())) != null)
						{
							Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list, (Func<SelectListItem, bool>)((SelectListItem m) => m.Value == prjId.ToString())).Selected = true;
						}
					}
					else if (Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list, (Func<SelectListItem, bool>)((SelectListItem m) => m.Value != "-1")) != null)
					{
						Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list, (Func<SelectListItem, bool>)((SelectListItem m) => m.Value != "-1")).Selected = true;
					}
				}
			}
			else
			{
				list.Add(new SelectListItem
				{
					Text = Labels.SelectedListDefValue,
					Value = "-1",
					Selected = false
				});
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ProjectList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public string UpdateCallHistoryCmpAndPrs(int callHistoryId, int cmpId, int? prsId, int mode = 0)
	{
		string text = "0";
		try
		{
			if (prsId == 0)
			{
				prsId = null;
			}
			db.CRMspUpdateCallHistoryCmpAndPrs(callHistoryId, cmpId, prsId, mode);
			return CRMIdeal.Classes.Helper.Company.GetCompanyNameWithTitle(cmpId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return "0";
		}
	}

	[LoginAuthorize]
	public ActionResult CDailyTelSearchCompany(int position)
	{
		string formName = "frmMain";
		string actionName = "";
		switch (position)
		{
		case 1:
			actionName = "actcDailyTelAddCmpTel";
			break;
		case 2:
			actionName = "actcDailyTelAddPrsTel";
			break;
		}
		if (!UserLogin.IsUserAccess(formName, actionName))
		{
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		base.ViewBag.Position = position;
		return View();
	}

	public ActionResult SearchCompany_Read([DataSourceRequest] DataSourceRequest request, string strSearch)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspMainSearchWeb_Result> enumerable = new List<CRMspMainSearchWeb_Result>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			enumerable = Enumerable.ToList<CRMspMainSearchWeb_Result>((IEnumerable<CRMspMainSearchWeb_Result>)dbI.CRMspMainSearchWeb(strSearch, UserLogin.CurrentUser.UserId, 1, lCID, result, ",1000,1,2,3,8,9,11,12,14,17,20,21,22,", result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actcDailyTelAddCmpTel")]
	public ActionResult CDailyTelAddCmpTel(int cmpId)
	{
		_003C_003Ec__DisplayClass168_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass168_0();
		CS_0024_003C_003E8__locals0.cmpId = cmpId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		AddTelToCmpAndPrsViewModel model = new AddTelToCmpAndPrsViewModel();
		try
		{
			DbSet<CrmCompany> crmCompany = _dbTbl.CrmCompany;
			ParameterExpression val = Expression.Parameter(typeof(CrmCompany), "m");
			CrmCompany crmCompany2 = Queryable.FirstOrDefault<CrmCompany>((IQueryable<CrmCompany>)crmCompany, Expression.Lambda<Func<CrmCompany, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass168_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmCompany2 == null)
			{
				base.ViewBag.Error = Messages.msgNotFound;
			}
			else
			{
				string companyNameWithTitle = CRMIdeal.Classes.Helper.Company.GetCompanyNameWithTitle(CS_0024_003C_003E8__locals0.cmpId);
				DbSet<CrmCompany_Lang> crmCompany_Lang = _dbTbl.CrmCompany_Lang;
				val = Expression.Parameter(typeof(CrmCompany_Lang), "c");
				List<CrmCompany_Lang> list = Enumerable.ToList<CrmCompany_Lang>((IEnumerable<CrmCompany_Lang>)Queryable.Where<CrmCompany_Lang>((IQueryable<CrmCompany_Lang>)crmCompany_Lang, Expression.Lambda<Func<CrmCompany_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass168_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompany_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompany_Lang>)list, (Func<CrmCompany_Lang, CommonMultiLanguageViewModel>)((CrmCompany_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.cmpTelDesc,
					LanguageId = item.LanguageID
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompany2.cmpTelDesc,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompany_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompany_Lang>)list, (Func<CrmCompany_Lang, CommonMultiLanguageViewModel>)((CrmCompany_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.cmpTelIIDesc,
					LanguageId = item.LanguageID
				})));
				list3.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompany2.cmpTelIIDesc,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompany_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompany_Lang>)list, (Func<CrmCompany_Lang, CommonMultiLanguageViewModel>)((CrmCompany_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.cmpFaxDesc,
					LanguageId = item.LanguageID
				})));
				list4.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompany2.cmpFaxDesc,
					LanguageId = result
				});
				model = new AddTelToCmpAndPrsViewModel
				{
					CompanyID = crmCompany2.CompanyID,
					CompanyName = companyNameWithTitle,
					cmpTelDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					cmpFaxDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					cmpTelIIDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					cmpFax = crmCompany2.cmpFax,
					cmpPreTel = crmCompany2.cmpPreTel,
					cmpPreTelII = crmCompany2.cmpPreTelII,
					cmpTel = crmCompany2.cmpTel,
					cmpTelII = crmCompany2.cmpTelII,
					cmpFaxDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					cmpTelDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					cmpTelIIDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))))
				};
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(model);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actcDailyTelAddCmpTel")]
	public ActionResult CDailyTelAddCmpTel(AddTelToCmpAndPrsViewModel model)
	{
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass169_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass169_0();
		CS_0024_003C_003E8__locals0.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int countError = 0;
		try
		{
			DateTime now = DateTime.Now;
			if (base.ModelState.IsValid)
			{
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.cmpFaxDesc_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.cmpFaxDesc_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.cmpFaxDesc,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.cmpTelDesc_Lang))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.cmpTelDesc_Lang);
				}
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.cmpTelDesc,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.cmpTelIIDesc_Lang))
				{
					list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.cmpTelIIDesc_Lang);
				}
				list3.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.cmpTelIIDesc,
					LanguageId = lCID
				});
				text = ChkBeforeSubmitCompany_Lang(CS_0024_003C_003E8__locals0.model, list, list2, list3, ref countError);
				if (countError == 0)
				{
					bool flag = false;
					DbSet<CrmCompany> crmCompany = _dbTbl.CrmCompany;
					ParameterExpression val = Expression.Parameter(typeof(CrmCompany), "m");
					CrmCompany crmCompany2 = Queryable.FirstOrDefault<CrmCompany>((IQueryable<CrmCompany>)crmCompany, Expression.Lambda<Func<CrmCompany, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass169_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					if (crmCompany2 != null)
					{
						crmCompany2.cmpTel = CS_0024_003C_003E8__locals0.model.cmpTel;
						crmCompany2.cmpPreTel = CS_0024_003C_003E8__locals0.model.cmpPreTel;
						crmCompany2.cmpTelDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmCompany2.cmpTelII = CS_0024_003C_003E8__locals0.model.cmpTelII;
						crmCompany2.cmpPreTelII = CS_0024_003C_003E8__locals0.model.cmpPreTelII;
						crmCompany2.cmpTelIIDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmCompany2.cmpFax = CS_0024_003C_003E8__locals0.model.cmpFax;
						crmCompany2.cmpFaxDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmCompany2.UserId = UserLogin.CurrentUser.UserId;
						crmCompany2.Year1 = short.Parse(Financial.Get().Id.ToString());
						crmCompany2.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
						crmCompany2.RegisterDate = now;
						crmCompany2.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						crmCompany2.AppType = Configuration.AppType;
						_dbTbl.Entry(crmCompany2).State = EntityState.Modified;
						_dbTbl.SaveChanges();
						flag = true;
					}
					if (flag)
					{
						using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								_003C_003Ec__DisplayClass169_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass169_1();
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
								CS_0024_003C_003E8__locals1.lang = enumerator.Current;
								DbSet<CrmCompany_Lang> crmCompany_Lang = _dbTbl.CrmCompany_Lang;
								val = Expression.Parameter(typeof(CrmCompany_Lang), "c");
								CrmCompany_Lang crmCompany_Lang2 = Queryable.FirstOrDefault<CrmCompany_Lang>((IQueryable<CrmCompany_Lang>)crmCompany_Lang, Expression.Lambda<Func<CrmCompany_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass169_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass169_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (crmCompany_Lang2 != null)
								{
									crmCompany_Lang2.cmpTelIIDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									crmCompany_Lang2.cmpTelDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									crmCompany_Lang2.cmpFaxDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									_dbTbl.Entry(crmCompany_Lang2).State = EntityState.Modified;
									_dbTbl.SaveChanges();
									continue;
								}
								CrmCompany_Lang entity = new CrmCompany_Lang
								{
									LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
									CompanyID = crmCompany2.CompanyID,
									cmpTelIIDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
									cmpTelDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
									cmpName = " ",
									cmpFaxDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
								};
								_dbTbl.CrmCompany_Lang.Add(entity);
								_dbTbl.SaveChanges();
							}
						}
						base.ViewBag.Successfull = Messages.cmpCompanyEditSuccessFulMessage;
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
		return View(CS_0024_003C_003E8__locals0.model);
	}

	public string ChkBeforeSubmitCompany_Lang(AddTelToCmpAndPrsViewModel company, List<CommonMultiLanguageViewModel> listModelObj_cmpFaxDesc_Lang, List<CommonMultiLanguageViewModel> listModelObj_cmpTelDesc_Lang, List<CommonMultiLanguageViewModel> listModelObj_cmpTelIIDesc_Lang, ref int countError)
	{
		_ = CRMIdeal.Cache.Setting.Language.Get().Count;
		_ = CRMIdeal.Cache.User.Language.Get().Count;
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		if (company.cmpPreTel != null && company.cmpPreTel.Length > 1 && company.cmpPreTel.Substring(0, 2) == "09")
		{
			countError++;
			text += Messages.CheckcmpPreTelMobile;
		}
		if (company.cmpPreTelII != null && company.cmpPreTelII.Length > 1 && company.cmpPreTelII.Substring(0, 2) == "09")
		{
			countError++;
			text += Messages.CheckcmpPreTelIIMobile;
		}
		if (!string.IsNullOrEmpty(company.cmpTel))
		{
			bool flag = true;
			for (int i = 0; i < company.cmpTel.Length; i++)
			{
				if (!char.IsDigit(company.cmpTel[i]))
				{
					flag = false;
				}
			}
			if (!flag)
			{
				countError++;
				text = text + Messages.CheckNrmbercmpTel + "<br>";
			}
		}
		if (!string.IsNullOrEmpty(company.cmpPreTel))
		{
			bool flag2 = true;
			for (int j = 0; j < company.cmpPreTel.Length; j++)
			{
				if (!char.IsDigit(company.cmpPreTel[j]))
				{
					flag2 = false;
				}
			}
			if (!flag2)
			{
				countError++;
				text = text + Messages.CheckNrmbercmpPreTel + "<br>";
			}
		}
		if (!string.IsNullOrEmpty(company.cmpTelII))
		{
			bool flag3 = true;
			for (int k = 0; k < company.cmpTelII.Length; k++)
			{
				if (!char.IsDigit(company.cmpTelII[k]))
				{
					flag3 = false;
				}
			}
			if (!flag3)
			{
				countError++;
				text = text + Messages.CheckNrmbercmpTelII + "<br>";
			}
		}
		if (!string.IsNullOrEmpty(company.cmpPreTelII))
		{
			bool flag4 = true;
			for (int l = 0; l < company.cmpPreTelII.Length; l++)
			{
				if (!char.IsDigit(company.cmpPreTelII[l]))
				{
					flag4 = false;
				}
			}
			if (!flag4)
			{
				countError++;
				text = text + Messages.CheckNrmbercmpPreTelII + "<br>";
			}
		}
		if (!string.IsNullOrEmpty(company.cmpFax))
		{
			bool flag5 = true;
			for (int m = 0; m < company.cmpFax.Length; m++)
			{
				if (!char.IsDigit(company.cmpFax[m]))
				{
					flag5 = false;
				}
			}
			if (!flag5)
			{
				countError++;
				text = text + Messages.CheckNrmbercmpFax + "<br>";
			}
		}
		CompanyInfoController companyInfoController = new CompanyInfoController();
		if (!string.IsNullOrEmpty(company.cmpTel))
		{
			string text2 = companyInfoController.CantSaveDupTel(company.cmpTel, 1, company.CompanyID, company.cmpPreTel ?? "");
			if (!string.IsNullOrEmpty(text2))
			{
				countError++;
				text = text + text2 + "<br/>";
			}
		}
		if (!string.IsNullOrEmpty(company.cmpTelII))
		{
			string text3 = companyInfoController.CantSaveDupTel(company.cmpTelII, 1, company.CompanyID, company.cmpPreTelII ?? "");
			if (!string.IsNullOrEmpty(text3))
			{
				countError++;
				text = text + text3 + "<br/>";
			}
		}
		if (!string.IsNullOrEmpty(company.cmpFax))
		{
			string text4 = companyInfoController.CantSaveDupFax(company.cmpFax, 1, company.CompanyID, company.cmpPreTel ?? "");
			if (!string.IsNullOrEmpty(text4))
			{
				countError++;
				text = text + text4 + "<br/>";
			}
		}
		return text;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actcDailyTelAddPrsTel")]
	public ActionResult CDailyTelAddPrsTel(int prsId)
	{
		_003C_003Ec__DisplayClass171_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass171_0();
		CS_0024_003C_003E8__locals0.prsId = prsId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		AddTelToCmpAndPrsViewModel model = new AddTelToCmpAndPrsViewModel();
		try
		{
			DbSet<CrmCompanyPersons> crmCompanyPersons = _dbTbl.CrmCompanyPersons;
			ParameterExpression val = Expression.Parameter(typeof(CrmCompanyPersons), "m");
			CrmCompanyPersons crmCompanyPersons2 = Queryable.FirstOrDefault<CrmCompanyPersons>((IQueryable<CrmCompanyPersons>)crmCompanyPersons, Expression.Lambda<Func<CrmCompanyPersons, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass171_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmCompanyPersons2 == null)
			{
				base.ViewBag.Error = Messages.msgNotFound;
			}
			else
			{
				string companyNameWithTitle = CRMIdeal.Classes.Helper.Company.GetCompanyNameWithTitle(crmCompanyPersons2.prsCompanyId);
				string cmpPersonFullName = CRMIdeal.Classes.Helper.Company.GetCmpPersonFullName(CS_0024_003C_003E8__locals0.prsId);
				DbSet<CrmCompanyPersons_Lang> crmCompanyPersons_Lang = _dbTbl.CrmCompanyPersons_Lang;
				val = Expression.Parameter(typeof(CrmCompanyPersons_Lang), "c");
				List<CrmCompanyPersons_Lang> list = Enumerable.ToList<CrmCompanyPersons_Lang>((IEnumerable<CrmCompanyPersons_Lang>)Queryable.Where<CrmCompanyPersons_Lang>((IQueryable<CrmCompanyPersons_Lang>)crmCompanyPersons_Lang, Expression.Lambda<Func<CrmCompanyPersons_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass171_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyPersons_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyPersons_Lang>)list, (Func<CrmCompanyPersons_Lang, CommonMultiLanguageViewModel>)((CrmCompanyPersons_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.prsTelDesc,
					LanguageId = item.LanguageID
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyPersons2.prsTelDesc,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyPersons_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyPersons_Lang>)list, (Func<CrmCompanyPersons_Lang, CommonMultiLanguageViewModel>)((CrmCompanyPersons_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.prsFaxDesc,
					LanguageId = item.LanguageID
				})));
				list3.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyPersons2.prsFaxDesc,
					LanguageId = result
				});
				model = new AddTelToCmpAndPrsViewModel
				{
					CompanyID = crmCompanyPersons2.prsCompanyId,
					CompanyName = companyNameWithTitle,
					PersonName = cmpPersonFullName,
					CompanyPersonID = crmCompanyPersons2.CompanyPersonID,
					prsPreTel = crmCompanyPersons2.prsPreTel,
					prsTel = crmCompanyPersons2.prsTel,
					prsTelDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					prsFax = crmCompanyPersons2.prsFax,
					prsFaxDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					prsTelII = crmCompanyPersons2.prsTelII,
					prsMobile = crmCompanyPersons2.prsMobile,
					prsTelDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					prsFaxDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))))
				};
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(model);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actcDailyTelAddPrsTel")]
	public ActionResult CDailyTelAddPrsTel(AddTelToCmpAndPrsViewModel model)
	{
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass172_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass172_0();
		CS_0024_003C_003E8__locals0.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int countError = 0;
		try
		{
			DateTime now = DateTime.Now;
			if (base.ModelState.IsValid)
			{
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.prsTelDesc_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.prsTelDesc_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.prsTelDesc,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.prsFaxDesc_Lang))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.prsFaxDesc_Lang);
				}
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.prsFaxDesc,
					LanguageId = lCID
				});
				text += ChkSubmitPerson_Lang(CS_0024_003C_003E8__locals0.model, ref countError);
				if (countError == 0)
				{
					bool flag = false;
					DbSet<CrmCompanyPersons> crmCompanyPersons = _dbTbl.CrmCompanyPersons;
					ParameterExpression val = Expression.Parameter(typeof(CrmCompanyPersons), "m");
					CrmCompanyPersons crmCompanyPersons2 = Queryable.FirstOrDefault<CrmCompanyPersons>((IQueryable<CrmCompanyPersons>)crmCompanyPersons, Expression.Lambda<Func<CrmCompanyPersons, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass172_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					if (crmCompanyPersons2 != null)
					{
						crmCompanyPersons2.prsPreTel = CS_0024_003C_003E8__locals0.model.prsPreTel;
						crmCompanyPersons2.prsTel = CS_0024_003C_003E8__locals0.model.prsTel;
						crmCompanyPersons2.prsTelDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmCompanyPersons2.prsTelII = CS_0024_003C_003E8__locals0.model.prsTelII;
						crmCompanyPersons2.prsFax = CS_0024_003C_003E8__locals0.model.prsFax;
						crmCompanyPersons2.prsFaxDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmCompanyPersons2.prsMobile = CS_0024_003C_003E8__locals0.model.prsMobile;
						crmCompanyPersons2.UserId = UserLogin.CurrentUser.UserId;
						crmCompanyPersons2.Year1 = short.Parse(Financial.Get().Id.ToString());
						crmCompanyPersons2.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
						crmCompanyPersons2.RegisterDate = now;
						crmCompanyPersons2.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						crmCompanyPersons2.AppType = Configuration.AppType;
						_dbTbl.Entry(crmCompanyPersons2).State = EntityState.Modified;
						_dbTbl.SaveChanges();
						flag = true;
					}
					if (flag)
					{
						using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								_003C_003Ec__DisplayClass172_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass172_1();
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
								CS_0024_003C_003E8__locals1.lang = enumerator.Current;
								DbSet<CrmCompanyPersons_Lang> crmCompanyPersons_Lang = _dbTbl.CrmCompanyPersons_Lang;
								val = Expression.Parameter(typeof(CrmCompanyPersons_Lang), "c");
								CrmCompanyPersons_Lang crmCompanyPersons_Lang2 = Queryable.FirstOrDefault<CrmCompanyPersons_Lang>((IQueryable<CrmCompanyPersons_Lang>)crmCompanyPersons_Lang, Expression.Lambda<Func<CrmCompanyPersons_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass172_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass172_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (crmCompanyPersons_Lang2 != null)
								{
									crmCompanyPersons_Lang2.prsTelDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									crmCompanyPersons_Lang2.prsFaxDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									_dbTbl.Entry(crmCompanyPersons_Lang2).State = EntityState.Modified;
									_dbTbl.SaveChanges();
									continue;
								}
								CrmCompanyPersons_Lang entity = new CrmCompanyPersons_Lang
								{
									LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
									CompanyPersonID = crmCompanyPersons2.CompanyPersonID,
									prsLName = " ",
									prsTelDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
									prsFaxDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
								};
								_dbTbl.CrmCompanyPersons_Lang.Add(entity);
								_dbTbl.SaveChanges();
							}
						}
						base.ViewBag.Successfull = Messages.prsPersonEditSuccessFulMessage;
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
		return View(CS_0024_003C_003E8__locals0.model);
	}

	public string ChkSubmitPerson_Lang(AddTelToCmpAndPrsViewModel person, ref int countError)
	{
		_ = CRMIdeal.Cache.Setting.Language.Get().Count;
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		string text = "";
		CompanyInfoController companyInfoController = new CompanyInfoController();
		if (Thread.CurrentThread.CurrentCulture.LCID == 1065 && person.prsMobile != null)
		{
			if (person.prsMobile.Length < 11)
			{
				countError++;
				text = text + Messages.CheckprsMobile + "<br>";
			}
			if (!Regex.IsMatch(person.prsMobile, "09([0-9])\\d{8}"))
			{
				countError++;
				text = text + Messages.CheckprsMobileFormat + "<br>";
			}
		}
		if (person.prsMobile != null)
		{
			string text2 = companyInfoController.CantSaveDupPrsMob(person.prsMobile, person.CompanyPersonID);
			if (text2 != "" && text2.Substring(0, 1) == "1")
			{
				text2 = text2.Substring(1, text2.Length - 1);
				countError++;
				text = text + text2 + "<br>";
			}
		}
		if (!string.IsNullOrEmpty(person.prsTel))
		{
			try
			{
				long.Parse(person.prsTel);
			}
			catch
			{
				countError++;
				text = text + Messages.CheckprsTelDigit + "<br>";
			}
		}
		if (!string.IsNullOrEmpty(person.prsPreTel))
		{
			try
			{
				long.Parse(person.prsPreTel);
			}
			catch
			{
				countError++;
				text = text + Messages.CheckprsPreTelDigit + "<br>";
			}
		}
		if (!string.IsNullOrEmpty(person.prsTelII))
		{
			try
			{
				long.Parse(person.prsTelII);
			}
			catch
			{
				countError++;
				text = text + Messages.CheckprsTelIIoDigit + "<br>";
			}
		}
		if (!string.IsNullOrEmpty(person.prsFax))
		{
			try
			{
				long.Parse(person.prsFax);
			}
			catch
			{
				countError++;
				text = text + Messages.CheckprsFaxDigit + "<br>";
			}
		}
		if (!string.IsNullOrEmpty(person.prsMobile))
		{
			try
			{
				long.Parse(person.prsMobile);
			}
			catch
			{
				countError++;
				text = text + Messages.CheckprsMobileDigit + "<br>";
			}
		}
		if (!string.IsNullOrEmpty(person.prsTel))
		{
			string text3 = companyInfoController.CantSaveDupTel(person.prsTel, 2, person.CompanyPersonID, person.prsPreTel ?? "");
			if (!string.IsNullOrEmpty(text3))
			{
				countError++;
				text = text + text3 + "<br/>";
			}
		}
		if (!string.IsNullOrEmpty(person.prsTelII))
		{
			string text4 = companyInfoController.CantSaveDupTel(person.prsTelII, 2, person.CompanyPersonID, person.prsPreTel ?? "");
			if (!string.IsNullOrEmpty(text4))
			{
				countError++;
				text = text + text4 + "<br/>";
			}
		}
		if (!string.IsNullOrEmpty(person.prsFax))
		{
			string text5 = companyInfoController.CantSaveDupFax(person.prsFax, 2, person.CompanyPersonID, person.prsPreTel ?? "");
			if (!string.IsNullOrEmpty(text5))
			{
				countError++;
				text = text + text5 + "<br/>";
			}
		}
		return text;
	}

	[AjaxOnly]
	public JsonResult GetCallHistoryConversation(int cnvsId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CRMspSelectCallHistoryConversationByCnvsId_Result data = new CRMspSelectCallHistoryConversationByCnvsId_Result();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			data = Enumerable.FirstOrDefault<CRMspSelectCallHistoryConversationByCnvsId_Result>((IEnumerable<CRMspSelectCallHistoryConversationByCnvsId_Result>)db.CRMspSelectCallHistoryConversationByCnvsId(cnvsId, UserLogin.CurrentUser.UserId, lCID, result, result2));
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

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actcOpenRecordingFile")]
	[AjaxOnly]
	public string GetFileRecPath(string filePath, int devType = 1)
	{
		string text = "";
		try
		{
			if (filePath != null)
			{
				devType = devType;
				string text2 = "";
				string text3 = "";
				string text4 = "";
				string text5 = "";
				string text6 = "";
				bool flag = false;
				if (!string.IsNullOrEmpty(Configuration.PathFtpRecording) && devType == 1)
				{
					text2 = filePath.ToLower().Replace(Configuration.PathFtpRecording.ToLower(), "");
					text3 = Configuration.FacadeFtpRecording;
					text4 = Configuration.PathFtpRecording;
					text5 = Configuration.UserNameFtpRecording;
					text6 = Configuration.PasswordFtpRecording;
					flag = Configuration.UsePassiveFtpRecording;
				}
				else if (!string.IsNullOrEmpty(Configuration.PathFtpRecordingII) && devType == 2)
				{
					text2 = filePath.ToLower().Replace(Configuration.PathFtpRecordingII.ToLower(), "");
					text3 = Configuration.FacadeFtpRecordingII;
					text4 = Configuration.PathFtpRecordingII;
					text5 = Configuration.UserNameFtpRecordingII;
					text6 = Configuration.PasswordFtpRecordingII;
					flag = Configuration.UsePassiveFtpRecordingII;
				}
				else
				{
					if (filePath.IndexOf("CRMRecording\\", StringComparison.Ordinal) < 0)
					{
						filePath = "CRMRecording\\" + filePath;
					}
					text2 = filePath.ToLower().Replace(Configuration.PathFtp.ToLower(), "");
					text3 = Configuration.FacadeFtp;
					text4 = Configuration.PathFtp;
					text5 = Configuration.UserNameFtp;
					text6 = Configuration.PasswordFtp;
					flag = Configuration.UsePassiveFtp;
				}
				if (text2 != "")
				{
					FilesManager filesManager = new FilesManager();
					string text7 = filesManager.SetNameDirectory(UserLogin.CurrentUser.UserId);
					if (filesManager.CreateDirectory(text7))
					{
						char c = '/';
						if (text2.Contains("\\"))
						{
							c = '\\';
						}
						else if (text2.Contains("/"))
						{
							c = '/';
						}
						string[] array = text2.Split(new char[1] { c });
						text7 += (text7.EndsWith("\\") ? "" : "\\");
						text = HttpContext.Current.Server.MapPath(text7 + array[^1]);
						if (!new FacadeFTP(text3).Download(text4, text5, text6, text, text2, overwrite: true, flag))
						{
							text = "";
							string path = HttpContext.Current.Server.MapPath(text7);
							if (System.IO.Directory.Exists(path))
							{
								DirectoryInfo directoryInfo = new DirectoryInfo(path);
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
								if (System.IO.Directory.Exists(path))
								{
									System.IO.Directory.Delete(path);
								}
							}
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text;
	}

	private List<SelectListItem> GetUsersForDailyTelList()
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
			int value = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
				value = UserLogin.CurrentUser.UserId;
			}
			List<CRMspSelectSingleUsersForRepParam_Result> list2 = Enumerable.ToList<CRMspSelectSingleUsersForRepParam_Result>((IEnumerable<CRMspSelectSingleUsersForRepParam_Result>)db.CRMspSelectSingleUsersForRepParam(value, 6, lCID, result, result2));
			if (list2 != null)
			{
				list.Add(new SelectListItem
				{
					Text = Labels.AllUsers,
					Value = "",
					Selected = false
				});
				if (list2 != null && Enumerable.Any<CRMspSelectSingleUsersForRepParam_Result>((IEnumerable<CRMspSelectSingleUsersForRepParam_Result>)list2))
				{
					list.AddRange(Enumerable.Select<CRMspSelectSingleUsersForRepParam_Result, SelectListItem>((IEnumerable<CRMspSelectSingleUsersForRepParam_Result>)list2, (Func<CRMspSelectSingleUsersForRepParam_Result, SelectListItem>)((CRMspSelectSingleUsersForRepParam_Result item) => new SelectListItem
					{
						Text = item.UserName,
						Value = item.UserId.ToString(),
						Selected = false
					})));
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetUsersForDailyTelCombo(string selectedId = "")
	{
		string result = "";
		try
		{
			List<SelectListItem> usersForDailyTelList = GetUsersForDailyTelList();
			if (usersForDailyTelList != null)
			{
				result = JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<SelectListItem, nComboBoxListItem>((IEnumerable<SelectListItem>)usersForDailyTelList, (Func<SelectListItem, nComboBoxListItem>)((SelectListItem item) => new nComboBoxListItem
				{
					Text = item.Text,
					Value = item.Value,
					Selected = (item.Value == selectedId)
				}))));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[AjaxOnly]
	public JsonResult GetCnvsUsers()
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
		List<CrmDroupDownItem> data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspForgetCrtbSelectUsers_Result, CrmDroupDownItem>((IEnumerable<CRMspForgetCrtbSelectUsers_Result>)Enumerable.ToList<CRMspForgetCrtbSelectUsers_Result>((IEnumerable<CRMspForgetCrtbSelectUsers_Result>)db.CRMspForgetCrtbSelectUsers(UserLogin.CurrentUser.UserId, Labels.All, lCID, result, result2)), (Func<CRMspForgetCrtbSelectUsers_Result, CrmDroupDownItem>)((CRMspForgetCrtbSelectUsers_Result item) => new CrmDroupDownItem
		{
			text = item.UserName,
			value = item.UserId.ToString()
		})));
		return Json(data, JsonRequestBehavior.AllowGet);
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
		int result2 = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
		}
		List<CrmDroupDownItem> data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspForgetCrtbSelectReferUsers_Result, CrmDroupDownItem>((IEnumerable<CRMspForgetCrtbSelectReferUsers_Result>)Enumerable.ToList<CRMspForgetCrtbSelectReferUsers_Result>((IEnumerable<CRMspForgetCrtbSelectReferUsers_Result>)db.CRMspForgetCrtbSelectReferUsers(UserLogin.CurrentUser.UserId, Labels.All, lCID, result, result2)), (Func<CRMspForgetCrtbSelectReferUsers_Result, CrmDroupDownItem>)((CRMspForgetCrtbSelectReferUsers_Result item) => new CrmDroupDownItem
		{
			text = item.Val,
			value = item.ReferUserId.ToString()
		})));
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCnvsStatus()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmDroupDownItem> data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspForgetCrtbSelectConversationStatus_Result, CrmDroupDownItem>((IEnumerable<CRMspForgetCrtbSelectConversationStatus_Result>)Enumerable.ToList<CRMspForgetCrtbSelectConversationStatus_Result>((IEnumerable<CRMspForgetCrtbSelectConversationStatus_Result>)db.CRMspForgetCrtbSelectConversationStatus(UserLogin.CurrentUser.UserId, Labels.All, lCID, result)), (Func<CRMspForgetCrtbSelectConversationStatus_Result, CrmDroupDownItem>)((CRMspForgetCrtbSelectConversationStatus_Result item) => new CrmDroupDownItem
		{
			text = item.Val,
			value = item.ID.ToString()
		})));
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetProjects()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmDroupDownItem> data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspForgetCrtbSelectProjectTitle_Result, CrmDroupDownItem>((IEnumerable<CRMspForgetCrtbSelectProjectTitle_Result>)Enumerable.ToList<CRMspForgetCrtbSelectProjectTitle_Result>((IEnumerable<CRMspForgetCrtbSelectProjectTitle_Result>)db.CRMspForgetCrtbSelectProjectTitle(UserLogin.CurrentUser.UserId, Labels.All, lCID, result)), (Func<CRMspForgetCrtbSelectProjectTitle_Result, CrmDroupDownItem>)((CRMspForgetCrtbSelectProjectTitle_Result item) => new CrmDroupDownItem
		{
			text = item.Val,
			value = item.ProjectId
		})));
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actcForget")]
	public ActionResult CForget()
	{
		return View();
	}

	[AjaxOnly]
	public ActionResult _PartialCForgetGrid(string FDate, string TDate, string cnvsStatusId, string prjTitle, string cnvsuserId, string cnvsReferUserId, bool noRemindDate, string prjPostFix)
	{
		if (FDate != "")
		{
			FDate = FDate.Replace("/", "");
		}
		base.ViewBag.ForgetParameter = FDate + "|" + TDate + "|" + cnvsStatusId + "|" + prjTitle + "|" + cnvsuserId + "|" + cnvsReferUserId + "|" + noRemindDate + "|" + prjPostFix;
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult CForget_Read([DataSourceRequest] DataSourceRequest request, string forgetParameter)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string day = DateTime.Now.DayOfWeek.ToString();
		string[] array = forgetParameter.Split(new char[1] { '|' });
		List<mct_CRMspResultsForgetCompanyCartable_Result> list = new List<mct_CRMspResultsForgetCompanyCartable_Result>();
		try
		{
			if (array[0] != null && array[0] != "")
			{
				array[0].Insert(4, "/").Insert(7, "/");
				array[1].Insert(4, "/").Insert(7, "/");
				string cnvsStatusId = ((array[2] == "0") ? "" : array[2]);
				string prjTitle = ((array[3] == Labels.All) ? "" : array[3]);
				string cnvsuserId = ((array[4] == "0") ? "" : array[4]);
				string cnvsReferUserId = ((array[5] == "0") ? "" : array[5]);
				string prjPostFix = (string.IsNullOrWhiteSpace(array[7]) ? "" : array[7]);
				int result2 = 0;
				if (UserLogin.CurrentUser != null)
				{
					int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
				}
				list = Enumerable.ToList<mct_CRMspResultsForgetCompanyCartable_Result>((IEnumerable<mct_CRMspResultsForgetCompanyCartable_Result>)db.mfi_CRMspResultsForgetCompanyCartable(array[0], array[1], DateTime.Parse(DateTimeClass.ConvertDateWOSlashToSlash(array[0])), DateTime.Parse(DateTimeClass.ConvertDateWOSlashToSlash(array[1])), cnvsStatusId, prjTitle, cnvsuserId, cnvsReferUserId, bool.Parse(array[6]), UserLogin.CurrentUser.UserId, DateTime.Now.ToString("yyyy/MM/dd"), DateTimeClass.DefineDayeOfWeekFaWithoutNull(day), lCID, result, prjPostFix, result2));
				foreach (mct_CRMspResultsForgetCompanyCartable_Result item in list)
				{
					if (item.cnvsDateTime.HasValue)
					{
						DateTime.TryParse(item.cnvsDateTime.ToString(), out var result3);
						item.cnvsDate = result3.ToString("yyyy/MM/dd");
					}
					else if (!string.IsNullOrEmpty(item.cnvsDate))
					{
						if (lCID != 1065)
						{
							item.cnvsDate = DateTime.ParseExact(PersianDate.GetFormatetdDate(item.cnvsDate.Replace("/", "")), "yyyy/MM/dd", new PersianCulture()).ToString("yyyy/MM/dd");
						}
						else
						{
							item.cnvsDate = PersianDate.GetFormatetdDate(item.cnvsDate.Replace("/", ""));
						}
					}
					if (item.cnvsRemindDateTime.HasValue)
					{
						DateTime.TryParse(item.cnvsRemindDateTime.ToString(), out var result4);
						item.cnvsRemindDate = result4.ToString("yyyy/MM/dd");
					}
					else if (!string.IsNullOrEmpty(item.cnvsRemindDate))
					{
						if (lCID != 1065)
						{
							item.cnvsRemindDate = DateTime.ParseExact(PersianDate.GetFormatetdDate(item.cnvsRemindDate.Replace("/", "")), "yyyy/MM/dd", new PersianCulture()).ToString("yyyy/MM/dd");
						}
						else
						{
							item.cnvsRemindDate = PersianDate.GetFormatetdDate(item.cnvsRemindDate.Replace("/", ""));
						}
					}
					if (item.ImportDateTime.HasValue)
					{
						DateTime.TryParse(item.ImportDateTime.ToString(), out var result5);
						item.ImportDate = result5.ToString("yyyy/MM/dd");
					}
					else if (!string.IsNullOrEmpty(item.ImportDate))
					{
						if (lCID != 1065)
						{
							item.ImportDate = DateTime.ParseExact(PersianDate.GetFormatetdDate(item.ImportDate.Replace("/", "")), "yyyy/MM/dd", new PersianCulture()).ToString("yyyy/MM/dd");
						}
						else
						{
							item.ImportDate = PersianDate.GetFormatetdDate(item.ImportDate.Replace("/", ""));
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[HttpPost]
	[LoginAuthorize]
	[AjaxOnly]
	public ActionResult FillForgetCompanySmsTempNumber(string fDate = "", string tDate = "", string prjTitle = "", string cnvsuserId = "", string cnvsStatusId = "", string cnvsReferUserId = "", bool noRemindDate = false, string prjPostFix = "", int lastRowNumber = 0, int pageSize = 100, bool isPrint = false)
	{
		int? count = 0;
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
			string day = DateTime.Now.DayOfWeek.ToString();
			string firstRegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			string appType = Configuration.AppType;
			count = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbII.CRMspFillSmsTempNumberInForgetCartableWeb(UserLogin.CurrentUser.UserId, fDate, tDate, DateTime.Parse(DateTimeClass.ConvertDateWOSlashToSlash(fDate)), DateTime.Parse(DateTimeClass.ConvertDateWOSlashToSlash(tDate)), (cnvsStatusId == "0") ? "" : cnvsStatusId, (prjTitle == Labels.All) ? "" : prjTitle, (cnvsuserId == "0") ? "" : cnvsuserId, (cnvsReferUserId == "0") ? "" : cnvsReferUserId, noRemindDate, UserLogin.CurrentUser.UserId, DateTime.Now.ToString("yyyy/MM/dd"), DateTimeClass.DefineDayeOfWeekFaWithoutNull(day), lCID, result, string.IsNullOrWhiteSpace(prjPostFix) ? "" : prjPostFix, 0, pageSize + lastRowNumber, isPrint, result2, firstRegisterDatePersian, DateTime.Now, appType));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(new { count });
	}

	[HttpPost]
	[LoginAuthorize]
	public List<CRMspResultsForgetCompanyCartableWeb_Result> ResultsForgetCompanyCartable(string fDate = "", string tDate = "", string prjTitle = "", string cnvsuserId = "", string cnvsStatusId = "", string cnvsReferUserId = "", bool noRemindDate = false, string prjPostFix = "", int lastRowNumber = 0, int pageSize = 100, bool isPrint = false)
	{
		List<CRMspResultsForgetCompanyCartableWeb_Result> result = new List<CRMspResultsForgetCompanyCartableWeb_Result>();
		try
		{
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
			string day = DateTime.Now.DayOfWeek.ToString();
			List<CRMspResultsForgetCompanyCartableWeb_Result> list = Enumerable.ToList<CRMspResultsForgetCompanyCartableWeb_Result>((IEnumerable<CRMspResultsForgetCompanyCartableWeb_Result>)dbI.CRMspResultsForgetCompanyCartableWeb(fDate, tDate, DateTime.Parse(DateTimeClass.ConvertDateWOSlashToSlash(fDate)), DateTime.Parse(DateTimeClass.ConvertDateWOSlashToSlash(tDate)), (cnvsStatusId == "0") ? "" : cnvsStatusId, (prjTitle == Labels.All) ? "" : prjTitle, (cnvsuserId == "0") ? "" : cnvsuserId, (cnvsReferUserId == "0") ? "" : cnvsReferUserId, noRemindDate, UserLogin.CurrentUser.UserId, DateTime.Now.ToString("yyyy/MM/dd"), DateTimeClass.DefineDayeOfWeekFaWithoutNull(day), lCID, result2, string.IsNullOrWhiteSpace(prjPostFix) ? "" : prjPostFix, lastRowNumber, pageSize, isPrint, result3));
			if (list != null)
			{
				foreach (CRMspResultsForgetCompanyCartableWeb_Result item in list)
				{
					if (item.cnvsDateTime.HasValue)
					{
						DateTime.TryParse(item.cnvsDateTime.ToString(), out var result4);
						item.cnvsDate = result4.ToString("yyyy/MM/dd");
					}
					else if (!string.IsNullOrEmpty(item.cnvsDate))
					{
						if (lCID != 1065)
						{
							item.cnvsDate = DateTime.ParseExact(PersianDate.GetFormatetdDate(item.cnvsDate.Replace("/", "")), "yyyy/MM/dd", new PersianCulture()).ToString("yyyy/MM/dd");
						}
						else
						{
							item.cnvsDate = PersianDate.GetFormatetdDate(item.cnvsDate.Replace("/", ""));
						}
					}
					if (item.cnvsRemindDateTime.HasValue)
					{
						DateTime.TryParse(item.cnvsRemindDateTime.ToString(), out var result5);
						item.cnvsRemindDate = result5.ToString("yyyy/MM/dd");
					}
					else if (!string.IsNullOrEmpty(item.cnvsRemindDate))
					{
						if (lCID != 1065)
						{
							item.cnvsRemindDate = DateTime.ParseExact(PersianDate.GetFormatetdDate(item.cnvsRemindDate.Replace("/", "")), "yyyy/MM/dd", new PersianCulture()).ToString("yyyy/MM/dd");
						}
						else
						{
							item.cnvsRemindDate = PersianDate.GetFormatetdDate(item.cnvsRemindDate.Replace("/", ""));
						}
					}
					if (item.ImportDateTime.HasValue)
					{
						DateTime.TryParse(item.ImportDateTime.ToString(), out var result6);
						item.ImportDate = result6.ToString("yyyy/MM/dd");
					}
					else if (!string.IsNullOrEmpty(item.ImportDate))
					{
						if (lCID != 1065)
						{
							item.ImportDate = DateTime.ParseExact(PersianDate.GetFormatetdDate(item.ImportDate.Replace("/", "")), "yyyy/MM/dd", new PersianCulture()).ToString("yyyy/MM/dd");
						}
						else
						{
							item.ImportDate = PersianDate.GetFormatetdDate(item.ImportDate.Replace("/", ""));
						}
					}
				}
				result = list;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string ResultsForgetCompanyCartableJs(string fDate = "", string tDate = "", string prjTitle = "", string cnvsuserId = "", string cnvsStatusId = "", string cnvsReferUserId = "", bool noRemindDate = false, string prjPostFix = "", int lastRowNumber = 0, int pageSize = 100, bool isPrint = false)
	{
		return JsonConvert.SerializeObject(ResultsForgetCompanyCartable(fDate, tDate, prjTitle, cnvsuserId, cnvsStatusId, cnvsReferUserId, noRemindDate, prjPostFix, lastRowNumber, pageSize, isPrint));
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actInternalNewMessage")]
	public ActionResult CInternalMessageNew(string sendMode, int msgTypeId, int replyUserId, int loadUserId, string loadSubject, string loadMessage, int replyPriorityId, int replyGroupId, int flagShowReceivers, int replyMasterMessageId, bool replyActiveInCycle, int msgAttachRecId, int cmpId = 0, int prjId = 0, string loadCheckerUsersId = "", string msgAttachRecDesc = "", int msgAttachRecIdI = 0, string msgAttachRecDescI = "", int msgCId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		CrmInternalMessageViewModel crmInternalMessageViewModel = new CrmInternalMessageViewModel();
		crmInternalMessageViewModel.msgCId = msgCId;
		string text = "";
		try
		{
			int userId = UserLogin.CurrentUser.UserId;
			crmInternalMessageViewModel.CompanyId = cmpId;
			crmInternalMessageViewModel.ProjectId = prjId;
			crmInternalMessageViewModel.EnableChkActiveInCycle = "";
			if (sendMode == null || sendMode.Length != 0)
			{
				switch (sendMode)
				{
				case "Forward":
				case "Reply":
					break;
				case "New":
					crmInternalMessageViewModel.EnableChkActiveInCycle = "1";
					goto IL_00d9;
				default:
					goto IL_00d9;
				}
			}
			crmInternalMessageViewModel.EnableChkActiveInCycle = replyActiveInCycle.ToString().ToLower();
			goto IL_00d9;
			IL_00d9:
			string text2 = "";
			string msgSubject = loadSubject;
			int? num = 0;
			if (replyMasterMessageId != 0)
			{
				CRMspSelectInternalMessageById_Result cRMspSelectInternalMessageById_Result = Enumerable.FirstOrDefault<CRMspSelectInternalMessageById_Result>((IEnumerable<CRMspSelectInternalMessageById_Result>)dbI.CRMspSelectInternalMessageById(replyMasterMessageId, currLangID, result));
				if (cRMspSelectInternalMessageById_Result != null)
				{
					if (sendMode == "Reply" || sendMode == "Forward")
					{
						List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
						foreach (Languages item in Enumerable.ToList<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get()))
						{
							CommonMultiLanguageViewModel commonMultiLanguageViewModel = new CommonMultiLanguageViewModel();
							string value = "";
							CRMspSelectInternalMessageById_Result cRMspSelectInternalMessageById_Result2 = Enumerable.FirstOrDefault<CRMspSelectInternalMessageById_Result>((IEnumerable<CRMspSelectInternalMessageById_Result>)dbI.CRMspSelectInternalMessageById(cRMspSelectInternalMessageById_Result.InternalMessageID, item.LanguageID, result));
							if (cRMspSelectInternalMessageById_Result2 != null)
							{
								string text3 = ((sendMode == "Reply") ? (MyResource.GetResourceString("IntMsgSendReply", item.LanguageCollation, "CRM.Resources.Labels", typeof(Messages).GetTypeInfo().Assembly) + ":") : loadSubject);
								value = (((sendMode == "Reply" || sendMode == "Forward") && string.IsNullOrEmpty(cRMspSelectInternalMessageById_Result2.msgSubject)) ? (text3 + " " + ((!string.IsNullOrEmpty(cRMspSelectInternalMessageById_Result2.msgSubject)) ? cRMspSelectInternalMessageById_Result2.msgSubject : "")) : (string.IsNullOrEmpty(cRMspSelectInternalMessageById_Result2.msgSubject) ? cRMspSelectInternalMessageById_Result2.msgSubject : ((cRMspSelectInternalMessageById_Result2.msgSubject.IndexOf(text3, StringComparison.Ordinal) < 0) ? (text3 + " " + ((!string.IsNullOrEmpty(cRMspSelectInternalMessageById_Result2.msgSubject)) ? cRMspSelectInternalMessageById_Result2.msgSubject : "")) : cRMspSelectInternalMessageById_Result2.msgSubject)));
							}
							commonMultiLanguageViewModel.LanguageId = item.LanguageID;
							commonMultiLanguageViewModel.Value = value;
							list.Add(commonMultiLanguageViewModel);
						}
						msgSubject = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
						crmInternalMessageViewModel.msgSubject_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
					}
					else
					{
						msgSubject = cRMspSelectInternalMessageById_Result.msgSubject;
					}
					text2 = text2 + Environment.NewLine + Environment.NewLine + "--------------------------------" + Environment.NewLine + cRMspSelectInternalMessageById_Result.msgBody;
					num = cRMspSelectInternalMessageById_Result.msgAttachRecId.GetValueOrDefault(msgAttachRecId);
					crmInternalMessageViewModel.messageAttachRecId = msgAttachRecId;
				}
			}
			else
			{
				crmInternalMessageViewModel.messageAttachRecId = msgAttachRecId;
				string[] array = ((loadMessage != "") ? loadMessage.Split(new char[1] { '-' }) : null);
				if (array != null)
				{
					if (Enumerable.Any<string>((IEnumerable<string>)array))
					{
						for (int i = 0; i < array.Length; i++)
						{
							if (!string.IsNullOrEmpty(array[i]))
							{
								array[i] = array[i].Replace("|pordNum|", "-");
							}
						}
					}
					text2 = "";
					text2 = Enumerable.Aggregate<string, string>((IEnumerable<string>)array, text2, (Func<string, string, string>)((string current, string item) => current + item + Environment.NewLine));
				}
			}
			if (!crmInternalMessageViewModel.IsForwardMessage || num != 0)
			{
				try
				{
					_dbI.CRMspDeleteFilesDirectoryTemplateByTypeAndUser(1, userId);
					string text4 = Configuration.HostTempFilesPath + "/" + Configuration.IntmsgDirectoryPath;
					string path = base.Server.MapPath(text4 + userId + "/");
					if (System.IO.Directory.Exists(path))
					{
						DirectoryInfo directoryInfo = new DirectoryInfo(path);
						FileInfo[] files = directoryInfo.GetFiles();
						for (int j = 0; j < files.Length; j++)
						{
							files[j].Delete();
						}
						DirectoryInfo[] directories = directoryInfo.GetDirectories();
						for (int j = 0; j < directories.Length; j++)
						{
							directories[j].Delete(recursive: true);
						}
						System.IO.Directory.Delete(path);
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
			}
			if (msgTypeId > 0)
			{
				crmInternalMessageViewModel.msgTypeId = 1;
			}
			string text5 = "";
			if (flagShowReceivers == 0)
			{
				crmInternalMessageViewModel.IntMsgReceivers = "";
			}
			if (replyUserId != 0)
			{
				if (!string.IsNullOrWhiteSpace(crmInternalMessageViewModel.IntMsgReceivers))
				{
					crmInternalMessageViewModel.IntMsgReceivers += ",";
				}
				crmInternalMessageViewModel.IntMsgReceivers += replyUserId;
			}
			if (loadUserId != 0)
			{
				if (!string.IsNullOrWhiteSpace(crmInternalMessageViewModel.IntMsgReceivers))
				{
					crmInternalMessageViewModel.IntMsgReceivers += ",";
				}
				crmInternalMessageViewModel.IntMsgReceivers += loadUserId;
			}
			if (!string.IsNullOrWhiteSpace(loadCheckerUsersId) && loadCheckerUsersId != "0")
			{
				string[] array2 = loadCheckerUsersId.Split(new char[1] { '|' });
				if (Enumerable.Any<string>((IEnumerable<string>)array2))
				{
					string[] array3 = array2;
					foreach (string text6 in array3)
					{
						if (!string.IsNullOrWhiteSpace(text6) && text6 != "0")
						{
							if (!string.IsNullOrWhiteSpace(crmInternalMessageViewModel.IntMsgReceivers))
							{
								crmInternalMessageViewModel.IntMsgReceivers += ",";
							}
							crmInternalMessageViewModel.IntMsgReceivers += text6;
						}
					}
				}
			}
			if (!string.IsNullOrWhiteSpace(crmInternalMessageViewModel.IntMsgReceivers))
			{
				List<CRMspSelectUsersByIds_Result> list2 = CRMIdeal.Classes.Helper.User.SelectUsersByIds(crmInternalMessageViewModel.IntMsgReceivers);
				if (list2 != null && Enumerable.Any<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list2))
				{
					foreach (CRMspSelectUsersByIds_Result item2 in list2)
					{
						if (!string.IsNullOrWhiteSpace(item2.FullName))
						{
							if (!string.IsNullOrWhiteSpace(text5))
							{
								text5 += ",";
							}
							text5 += item2.FullName;
						}
					}
				}
			}
			crmInternalMessageViewModel.msgToUsersTitle = text5;
			if (!string.IsNullOrEmpty(msgAttachRecDesc))
			{
				crmInternalMessageViewModel.AttachRecDesc = msgAttachRecDesc;
			}
			if (sendMode == "Forward")
			{
				crmInternalMessageViewModel.IsForwardMessage = true;
			}
			crmInternalMessageViewModel.msgSubject = msgSubject;
			crmInternalMessageViewModel.msgBody = text2;
			if (replyMasterMessageId != 0)
			{
				crmInternalMessageViewModel.msgMasterId = replyMasterMessageId;
			}
			if (replyPriorityId > 0)
			{
				crmInternalMessageViewModel.ReplyPriorityID = replyPriorityId;
			}
			if (replyGroupId > 0)
			{
				crmInternalMessageViewModel.msgLastGroupId = replyGroupId;
			}
			if (num > 0 && num.HasValue)
			{
				crmInternalMessageViewModel.AttachRecId = num.Value;
			}
			crmInternalMessageViewModel.UserId = UserLogin.CurrentUser.UserId;
			crmInternalMessageViewModel.msgFromUserId = UserLogin.CurrentUser.UserId;
			crmInternalMessageViewModel.Year1 = short.Parse(Financial.Get().Id.ToString());
			crmInternalMessageViewModel.Month1 = short.Parse(DateTime.Now.ToString("MM"));
			crmInternalMessageViewModel.RegisterDate = DateTime.Now;
			crmInternalMessageViewModel.RegisterDatePersian = DateTime.Now.ToString("yyyyMMdd");
			crmInternalMessageViewModel.ImportDate = DateTime.Now.ToString("yyyyMMdd");
			crmInternalMessageViewModel.msgAttachRecIdI = ((msgAttachRecIdI > 0) ? new int?(msgAttachRecIdI) : null);
			crmInternalMessageViewModel.msgAttachRecDescI = msgAttachRecDescI;
			string text7 = sendMode;
			if (sendMode == "Forward")
			{
				text7 = "Reply";
			}
			text = (crmInternalMessageViewModel.HelpParameters = text7 + "||" + msgTypeId + "||" + replyUserId + "||" + loadUserId + "||" + loadSubject + "||" + loadMessage + "||" + replyPriorityId + "||" + replyGroupId + "||" + replyMasterMessageId + "||" + replyActiveInCycle + "||" + msgAttachRecId + "||" + msgAttachRecIdI + "||" + msgAttachRecDescI + "||" + msgCId);
			crmInternalMessageViewModel.SendMode = sendMode + "|" + replyMasterMessageId;
			if ((sendMode == "Forward" || sendMode == "Reply") && replyMasterMessageId > 0)
			{
				foreach (CRMspIntMsgSelectMessageFiles_Result item3 in Enumerable.ToList<CRMspIntMsgSelectMessageFiles_Result>((IEnumerable<CRMspIntMsgSelectMessageFiles_Result>)db.CRMspIntMsgSelectMessageFiles(replyMasterMessageId)))
				{
					try
					{
						CrmFilesDirectoryTemplate crmFilesDirectoryTemplate = new CrmFilesDirectoryTemplate();
						crmFilesDirectoryTemplate.AppType = Configuration.AppType;
						crmFilesDirectoryTemplate.GUId = System.Guid.NewGuid();
						crmFilesDirectoryTemplate.TypeId = 1;
						crmFilesDirectoryTemplate.UserId = UserLogin.CurrentUser.UserId;
						crmFilesDirectoryTemplate.CopyFromPath = "FileDirectoryID:" + item3.FileDirectoryID;
						crmFilesDirectoryTemplate.Title = item3.Title;
						_dbTbl.CrmFilesDirectoryTemplate.Add(crmFilesDirectoryTemplate);
						_dbTbl.SaveChanges();
					}
					catch (Exception e2)
					{
						ErrorSignal.FromCurrentContext().Raise(e2);
					}
				}
			}
			if (sendMode == "Reply" && replyMasterMessageId > 0 && (msgTypeId == 1 || msgTypeId == 5 || msgTypeId == 6 || msgTypeId == 7 || msgTypeId == 8 || msgTypeId == 10 || msgTypeId == 12 || msgTypeId == 9 || msgTypeId == 14 || msgTypeId == 16 || msgTypeId == 45 || msgTypeId == 50 || msgTypeId == 55 || msgTypeId == 60 || msgTypeId == 17 || msgTypeId == 18 || msgTypeId == 19 || msgTypeId == 20 || msgTypeId == 21))
			{
				UpdateInternalMessage("Read", replyMasterMessageId, msgTypeId);
			}
			bool prjFoCmpCanSee = false;
			bool prjIsTicket = false;
			bool prjTicketStop = false;
			GetCnvsLastStatus(cmpId, prjId, ref prjFoCmpCanSee, ref prjIsTicket, ref prjTicketStop, msgCId);
			if (prjIsTicket)
			{
				crmInternalMessageViewModel.cnvsIsTicket = true;
				crmInternalMessageViewModel.cnvsFOCmpCanSee = true;
			}
			if (prjFoCmpCanSee)
			{
				crmInternalMessageViewModel.prjFOCmpCanSee = true;
			}
			if (UserLogin.IsUserAccess("frmDefineConversation", "actDefSelectFOCmpCanSee", UserLogin.CurrentUser) && crmInternalMessageViewModel.prjFOCmpCanSee.GetValueOrDefault())
			{
				crmInternalMessageViewModel.cnvsFOCmpCanSee = true;
			}
			crmInternalMessageViewModel.prjTicketStop = prjTicketStop;
			CRMspSelectCompanyConversationFirstCnvsUser_Result cRMspSelectCompanyConversationFirstCnvsUser_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyConversationFirstCnvsUser_Result>((IEnumerable<CRMspSelectCompanyConversationFirstCnvsUser_Result>)_dbI.CRMspSelectCompanyConversationFirstCnvsUser(cmpId, prjId, currLangID, result));
			if (cRMspSelectCompanyConversationFirstCnvsUser_Result != null && cRMspSelectCompanyConversationFirstCnvsUser_Result.cnvsUserId.HasValue)
			{
				crmInternalMessageViewModel.PrjFirstCnvsUserId = cRMspSelectCompanyConversationFirstCnvsUser_Result.cnvsUserId;
			}
			CRMspSelectCompanyConversationLastStatus_Result cRMspSelectCompanyConversationLastStatus_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyConversationLastStatus_Result>((IEnumerable<CRMspSelectCompanyConversationLastStatus_Result>)db.CRMspSelectCompanyConversationLastStatus(cmpId, prjId, currLangID, result));
			if (cRMspSelectCompanyConversationLastStatus_Result != null && cRMspSelectCompanyConversationLastStatus_Result.cnvsPersonId.HasValue)
			{
				crmInternalMessageViewModel.LastCnvsPersonId = cRMspSelectCompanyConversationLastStatus_Result.cnvsPersonId;
				crmInternalMessageViewModel.cnvsPersonId = cRMspSelectCompanyConversationLastStatus_Result.cnvsPersonId;
			}
			CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(cmpId);
			if (companyById != null)
			{
				crmInternalMessageViewModel.CmpReferUserId = companyById.cmpReferUserId;
				crmInternalMessageViewModel.CmpSuppUserId = companyById.cmpSuppUserId;
			}
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		FillDropdownIntMsg();
		base.ViewBag.SaveParameter = text;
		base.ViewBag.EnableChkActiveInCycle = crmInternalMessageViewModel.EnableChkActiveInCycle;
		base.ViewBag.SendMode = sendMode + "|" + replyMasterMessageId;
		base.ViewBag.CntFileId = Files.HaveFileDirectoryIdMore10();
		return View(crmInternalMessageViewModel);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult CInternalMessageNew(CrmInternalMessageViewModel newMessage)
	{
		//IL_35d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0252: Unknown result type (might be due to invalid IL or missing references)
		//IL_361c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b5f: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		bool flag = Files.HaveFileDirectoryIdMore10();
		base.ViewBag.CntFileId = flag;
		FillDropdownIntMsg();
		base.ViewBag.SaveParameter = newMessage.HelpParameters;
		base.ViewBag.EnableChkActiveInCycle = newMessage.EnableChkActiveInCycle;
		base.ViewBag.SendMode = newMessage.SendMode;
		int? num2 = null;
		if (UserLogin.CurrentUser != null)
		{
			num2 = UserLogin.CurrentUser.UserLastCId;
		}
		if (newMessage.msgCId.GetValueOrDefault() != 0)
		{
			num2 = newMessage.msgCId;
		}
		int userId = UserLogin.CurrentUser.UserId;
		string appType = Configuration.AppType;
		int id = Financial.Get().Id;
		string text2 = "";
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(newMessage.cnvsDesc_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(newMessage.cnvsDesc_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = newMessage.cnvsDesc,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(newMessage.cnvsReferDesc_Lang))
		{
			list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(newMessage.cnvsReferDesc_Lang);
		}
		list2.Add(new CommonMultiLanguageViewModel
		{
			Value = newMessage.cnvsReferDesc,
			LanguageId = lCID
		});
		if (!newMessage.CanInsertCnvsWithIntMsg)
		{
			goto IL_35b3;
		}
		try
		{
			if (string.IsNullOrEmpty(newMessage.cnvsDesc))
			{
				num++;
				text = text + Messages.CheckEmptycnvsDesc + "<br>";
			}
			else if (!checkMultiLanguage(newMessage.cnvsDesc, list))
			{
				text = text + Messages.CheckcnvsDescLang + "<br>";
				num++;
			}
			bool result = false;
			bool.TryParse(newMessage.IsCloseTicket.ToString(), out result);
			if (!result)
			{
				goto IL_0368;
			}
			string text3 = CRMIdeal.Classes.Helper.Company.CheckPrjIsFinishedByPrjPrdHNotDone(newMessage.ProjectId, isTicket: true);
			if (string.IsNullOrWhiteSpace(text3))
			{
				goto IL_0368;
			}
			text = text + text3 + "<br>";
			num++;
			goto end_IL_02d3;
			IL_03de:
			if (!string.IsNullOrEmpty(newMessage.cnvsRemindTime) && newMessage.cnvsRemindTime.Length < 5)
			{
				num++;
				text = text + Messages.CheckFormatcnvsRemindTime + "<br>";
			}
			if (userId != newMessage.cnvsReferUserId && !newMessage.cnvsRemindDateTime.HasValue && !UserLogin.IsUserAccess("frmDefineConversation", "actCnvsReferUserWithoutRemindDate", UserLogin.CurrentUser))
			{
				text = text + Messages.cnvsErrorNotMatchUserIdReferID + "<br>";
				num++;
			}
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null && cRMspSelectCrmsysSetting_Result.MustFullcnvsRemindDate.HasValue && cRMspSelectCrmsysSetting_Result.MustFullcnvsRemindDate != false && !newMessage.cnvsRemindDateTime.HasValue)
			{
				text = text + Messages.CheckmustFullCnvsRemindDate + "<br>";
				num++;
			}
			if (newMessage.cnvsRemindDateTimeForAllarm.HasValue && string.IsNullOrEmpty(newMessage.cnvsRemindTime))
			{
				num++;
				text = text + Messages.CheckAlarmcnvsRemindDateForAllarm + "<br>";
			}
			if (!string.IsNullOrEmpty(newMessage.cnvsRemindTime) && !newMessage.cnvsRemindDateTimeForAllarm.HasValue)
			{
				num++;
				text = text + Messages.CheckAlarmcnvsRemindTime + "<br>";
			}
			CRMspSelectConversationForcedStatusBFCurr_Result cRMspSelectConversationForcedStatusBFCurr_Result = Enumerable.FirstOrDefault<CRMspSelectConversationForcedStatusBFCurr_Result>((IEnumerable<CRMspSelectConversationForcedStatusBFCurr_Result>)db.CRMspSelectConversationForcedStatusBFCurr(newMessage.cnvsStatusId, newMessage.ProjectId, lCID, defLangID, 0));
			if (cRMspSelectConversationForcedStatusBFCurr_Result != null)
			{
				string arg = ((!string.IsNullOrEmpty(cRMspSelectConversationForcedStatusBFCurr_Result.Status)) ? cRMspSelectConversationForcedStatusBFCurr_Result.Status : "");
				num++;
				text = text + string.Format(Messages.CheckForcedStatusBFCurr, arg) + "<br>";
			}
			string text4 = "";
			if (newMessage.cnvsRemindDateTimeForAllarm.HasValue)
			{
				text4 = (newMessage.cnvsRemindDateTimeForAllarm.HasValue ? newMessage.cnvsRemindDateTimeForAllarm.Value.ToString("yyyyMMdd") : "");
				try
				{
					string text5 = newMessage.cnvsRemindTime;
					if (string.IsNullOrEmpty(text5))
					{
						text5 = "00:00:00";
					}
					if (!string.IsNullOrEmpty(text4))
					{
						DateTime dateTime = default(DateTime);
						string text6 = "";
						text6 = PersianDate.GetFormatetdDate(text4.Replace("/", ""));
						switch (lCID)
						{
						case 1065:
							dateTime = DateTime.Parse(text6 + " " + text5, new PersianCulture());
							text4 = dateTime.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime = DateTime.Parse(text6 + " " + text5, new CultureInfo("ar-SA"));
							text4 = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime = DateTime.Parse(text6 + " " + text5, new CultureInfo("en-US"));
							text4 = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						newMessage.cnvsRemindDateTimeForAllarm = dateTime;
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
			}
			if (!string.IsNullOrWhiteSpace(text4) && !string.IsNullOrWhiteSpace(newMessage.cnvsRemindTime))
			{
				string strB = DateTime.Now.ToString("yyyyMMdd");
				string text7 = (newMessage.cnvsRemindDateTimeForAllarm.HasValue ? newMessage.cnvsRemindDateTimeForAllarm.Value.ToString("yyyyMMdd") : "");
				if (string.Compare(text7, strB) <= -1)
				{
					num++;
					text = text + Messages.msgErrorBeforecnvsRemindDateForAllarm + "<br>";
				}
				else if (string.Compare(text7, strB) == 0)
				{
					strB = DateTime.Now.ToString("yyyyMMddHHmm");
					text7 += newMessage.cnvsRemindTime;
					text7 = text7.Replace(":", "");
					if (string.Compare(text7, strB) <= -1)
					{
						num++;
						text = text + Messages.msgErrorBeforecnvsRemindTime + "<br>";
					}
				}
			}
			int userId2 = UserLogin.CurrentUser.UserId;
			int result2 = 0;
			int.TryParse(newMessage.cnvsStatusResultId.ToString(), out result2);
			if (result2 == 0)
			{
				num++;
				text = text + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.cnvsStatusResultId) + "<br>";
			}
			else
			{
				CRMspSelectConversationStatusResultById_Result cRMspSelectConversationStatusResultById_Result = Enumerable.FirstOrDefault<CRMspSelectConversationStatusResultById_Result>((IEnumerable<CRMspSelectConversationStatusResultById_Result>)_dbI.CRMspSelectConversationStatusResultById(result2, lCID, defLangID));
				if (cRMspSelectConversationStatusResultById_Result == null)
				{
					num++;
					text = text + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.cnvsStatusResultId) + "<br>";
				}
				else
				{
					bool result3 = false;
					bool.TryParse(cRMspSelectConversationStatusResultById_Result.CnvsRemindDateNotNull.ToString(), out result3);
					string value = "";
					if (newMessage.cnvsRemindDateTime.HasValue)
					{
						value = (newMessage.cnvsRemindDateTime.HasValue ? newMessage.cnvsRemindDateTime.Value.ToString("yyyyMMdd") : "");
					}
					if (result3 && string.IsNullOrWhiteSpace(value))
					{
						num++;
						text = text + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.cnvsRemindDate) + "<br>";
					}
					bool result4 = false;
					bool.TryParse(cRMspSelectConversationStatusResultById_Result.CnvsRemindDateForAllarmNotNull.ToString(), out result4);
					if (result4)
					{
						if (string.IsNullOrWhiteSpace(text4))
						{
							num++;
							text = text + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.cnvsRemindDateForAllarm) + "<br>";
						}
						else if (string.IsNullOrWhiteSpace(newMessage.cnvsRemindTime))
						{
							num++;
							text = text + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.cnvsRemindTime) + "<br>";
						}
					}
					string text8 = cRMspSelectConversationStatusResultById_Result.StatusResultUsedUserIds ?? "";
					if (!string.IsNullOrWhiteSpace(text8))
					{
						string[] array = text8.Split(new char[1] { '|' });
						if (array != null && array.Length != 0)
						{
							bool flag2 = false;
							string[] array2 = array;
							foreach (string s in array2)
							{
								int result5 = 0;
								int.TryParse(s, out result5);
								if (result5 != 0 && result5 == userId2)
								{
									flag2 = true;
								}
							}
							if (!flag2)
							{
								num++;
								text = text + Messages.msgErrorCanNotSaveCnvsInResult + "<br>";
							}
						}
					}
					bool result6 = false;
					bool.TryParse(cRMspSelectConversationStatusResultById_Result.NeedDyFormChecked.ToString(), out result6);
					if (result6)
					{
						int result7 = 0;
						int.TryParse(cRMspSelectConversationStatusResultById_Result.NeedDyFormCheckedFormId.ToString(), out result7);
						if (result7 != 0)
						{
							CRMspCnvsStatusResultNeedDyFormChecked_Result cRMspCnvsStatusResultNeedDyFormChecked_Result = Enumerable.FirstOrDefault<CRMspCnvsStatusResultNeedDyFormChecked_Result>((IEnumerable<CRMspCnvsStatusResultNeedDyFormChecked_Result>)_dbI.CRMspCnvsStatusResultNeedDyFormChecked(result7, newMessage.CompanyId, newMessage.cnvsPersonId, newMessage.ProjectId, 0, lCID, defLangID));
							if (cRMspCnvsStatusResultNeedDyFormChecked_Result != null)
							{
								bool result8 = false;
								bool.TryParse(cRMspCnvsStatusResultNeedDyFormChecked_Result.IsChecked.ToString(), out result8);
								if (!result8)
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
					bool result9 = false;
					bool.TryParse(cRMspSelectConversationStatusResultById_Result.NoCnvsDup.ToString(), out result9);
					if (result9)
					{
						CRMspCnvsStatusResultNoCnvsDup_Result cRMspCnvsStatusResultNoCnvsDup_Result = Enumerable.FirstOrDefault<CRMspCnvsStatusResultNoCnvsDup_Result>((IEnumerable<CRMspCnvsStatusResultNoCnvsDup_Result>)_dbI.CRMspCnvsStatusResultNoCnvsDup(newMessage.CompanyId, newMessage.ProjectId, newMessage.cnvsStatusResultId, 0, lCID, defLangID));
						if (cRMspCnvsStatusResultNoCnvsDup_Result != null)
						{
							cRMspCnvsStatusResultNoCnvsDup_Result.cnvsDate = (cRMspCnvsStatusResultNoCnvsDup_Result.cnvsDateTime.HasValue ? cRMspCnvsStatusResultNoCnvsDup_Result.cnvsDateTime.Value.ToString("yyyy/MM/dd") : "");
							num++;
							text = text + string.Format(Messages.msgErrorNoDupCnvsInStatusResult, cRMspCnvsStatusResultNoCnvsDup_Result.cnvsDate, cRMspCnvsStatusResultNoCnvsDup_Result.cnvsStatus ?? "", cRMspCnvsStatusResultNoCnvsDup_Result.cnvsStatusResult ?? "") + "<br>";
						}
					}
					int result10 = 0;
					int.TryParse(cRMspSelectConversationStatusResultById_Result.CnvsCountLimit.ToString(), out result10);
					if (result10 > 0)
					{
						int? num3 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbI.CRMspReturnCnvsStatusResultCnvsCount(newMessage.CompanyId, newMessage.ProjectId, newMessage.cnvsStatusResultId, 0));
						int result11 = 0;
						int.TryParse(num3.ToString(), out result11);
						result11++;
						if (result10 < result11)
						{
							num++;
							text = text + string.Format(Messages.msgErrorCnvsCountLimitInStatusResult, cRMspSelectConversationStatusResultById_Result.ResultTitle ?? "", result10.ToString()) + "<br>";
						}
					}
				}
			}
			int result12 = 0;
			int.TryParse(newMessage.cnvsStatusId.ToString(), out result12);
			if (result12 == 0)
			{
				num++;
				text = text + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.cnvsStatusId) + "<br>";
			}
			else
			{
				CRMspSelectConversationStatusById_Result cRMspSelectConversationStatusById_Result = Enumerable.FirstOrDefault<CRMspSelectConversationStatusById_Result>((IEnumerable<CRMspSelectConversationStatusById_Result>)db.CRMspSelectConversationStatusById(result12, lCID, defLangID));
				if (cRMspSelectConversationStatusById_Result == null)
				{
					num++;
					text = text + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.cnvsStatusId) + "<br>";
				}
				else
				{
					bool result13 = false;
					bool.TryParse(cRMspSelectConversationStatusById_Result.GroupNoRegCnvsOlderStatus.ToString(), out result13);
					bool result14 = false;
					bool.TryParse(cRMspSelectConversationStatusById_Result.NoRegCnvsOlderStatus.ToString(), out result14);
					if (result13)
					{
						CRMspSelectConversationStatusNextCurr_Result cRMspSelectConversationStatusNextCurr_Result = Enumerable.FirstOrDefault<CRMspSelectConversationStatusNextCurr_Result>((IEnumerable<CRMspSelectConversationStatusNextCurr_Result>)_dbI.CRMspSelectConversationStatusNextCurr(result12, newMessage.ProjectId, 0, lCID, defLangID));
						if (cRMspSelectConversationStatusNextCurr_Result != null)
						{
							num++;
							text = text + string.Format(Messages.msgErrorNoRegCnvsOlderStatus, cRMspSelectConversationStatusNextCurr_Result.Status ?? "") + "<br>";
						}
					}
					else if (result14)
					{
						CRMspSelectConversationStatusNextCurr_Result cRMspSelectConversationStatusNextCurr_Result2 = Enumerable.FirstOrDefault<CRMspSelectConversationStatusNextCurr_Result>((IEnumerable<CRMspSelectConversationStatusNextCurr_Result>)_dbI.CRMspSelectConversationStatusNextCurr(result12, newMessage.ProjectId, 0, lCID, defLangID));
						if (cRMspSelectConversationStatusNextCurr_Result2 != null)
						{
							num++;
							text = text + string.Format(Messages.msgErrorNoRegCnvsOlderStatus, cRMspSelectConversationStatusNextCurr_Result2.Status ?? "") + "<br>";
						}
					}
					string text9 = cRMspSelectConversationStatusById_Result.StatusUsedUserIds ?? "";
					if (!string.IsNullOrWhiteSpace(text9))
					{
						string[] array3 = text9.Split(new char[1] { '|' });
						if (array3 != null && array3.Length != 0)
						{
							bool flag3 = false;
							string[] array2 = array3;
							foreach (string s2 in array2)
							{
								int result15 = 0;
								int.TryParse(s2, out result15);
								if (result15 != 0 && result15 == userId2)
								{
									flag3 = true;
								}
							}
							if (!flag3)
							{
								num++;
								text = text + Messages.msgErrorCanNotSaveCnvsInStatus + "<br>";
							}
						}
					}
					int result16 = 0;
					int.TryParse(cRMspSelectConversationStatusById_Result.CnvsCountLimit.ToString(), out result16);
					if (result16 > 0)
					{
						int? num4 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbI.CRMspReturnCnvsStatusCnvsCount(newMessage.CompanyId, newMessage.ProjectId, newMessage.cnvsStatusId, 0));
						int result17 = 0;
						int.TryParse(num4.ToString(), out result17);
						result17++;
						if (result16 < result17)
						{
							num++;
							text = text + string.Format(Messages.msgErrorCnvsCountLimitInStatus, cRMspSelectConversationStatusById_Result.Status ?? "", result16.ToString()) + "<br>";
						}
					}
				}
			}
			if (num <= 0)
			{
				CRMspSelectCompanyConversationLastStatus_Result cRMspSelectCompanyConversationLastStatus_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyConversationLastStatus_Result>((IEnumerable<CRMspSelectCompanyConversationLastStatus_Result>)db.CRMspSelectCompanyConversationLastStatus(newMessage.CompanyId, newMessage.ProjectId, lCID, defLangID));
				string text10 = "";
				if (newMessage.cnvsRemindDateTime.HasValue)
				{
					text10 = lCID switch
					{
						1065 => DateTime.Parse(newMessage.cnvsRemindDateTime.ToString()).ToString("yyyyMMdd"), 
						1025 => DateTime.Parse(newMessage.cnvsRemindDateTime.ToString(), new CultureInfo("ar-SA"), DateTimeStyles.None).ToString("yyyyMMdd", new PersianCulture()), 
						_ => DateTime.Parse(newMessage.cnvsRemindDateTime.ToString(), new CultureInfo("en-US"), DateTimeStyles.None).ToString("yyyyMMdd", new PersianCulture()), 
					};
				}
				string text11 = "";
				if (newMessage.cnvsRemindDateTimeForAllarm.HasValue)
				{
					text11 = lCID switch
					{
						1065 => DateTime.Parse(newMessage.cnvsRemindDateTimeForAllarm.ToString()).ToString("yyyyMMdd"), 
						1025 => DateTime.Parse(newMessage.cnvsRemindDateTimeForAllarm.ToString(), new CultureInfo("ar-SA"), DateTimeStyles.None).ToString("yyyyMMdd", new PersianCulture()), 
						_ => DateTime.Parse(newMessage.cnvsRemindDateTimeForAllarm.ToString(), new CultureInfo("en-US"), DateTimeStyles.None).ToString("yyyyMMdd", new PersianCulture()), 
					};
				}
				DateTime now = DateTime.Now;
				ObjectParameter objectParameter = new ObjectParameter("InsertedConversationID", 0);
				db.CRMspInternalMessageInsertCmpConversation(newMessage.ProjectId, newMessage.CompanyId, now.ToString("yyyyMMdd", new PersianCulture()), DateTimeClass.DefineDayeOfWeekStartWith7(DateTime.Now.DayOfWeek.ToString()), now.ToString("HH:mm:ss"), newMessage.cnvsTopicId, (Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null, newMessage.cnvsPersonId, newMessage.cnvsUserId, newMessage.cnvsReferUserId, (Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null, newMessage.cnvsStatusId, null, cnvsRemindDateTime: newMessage.cnvsRemindDateTime, cnvsRemindDate: newMessage.cnvsRemindDateTime.HasValue ? text10 : null, cnvsRemindTime: newMessage.cnvsRemindTime, cnvsRemindDateForAllarm: newMessage.cnvsRemindDateTimeForAllarm.HasValue ? text11 : null, cnvsFirstRegisterUserId: userId, cnvsFirstRegisterDate: now.ToString("yyyyMMdd", new PersianCulture()), userId: userId, year1: short.Parse(id.ToString()), month1: short.Parse(now.ToString("MM", new PersianCulture())), registerDate: now, registerDatePersian: now.ToString("yyyyMMdd", new PersianCulture()), firstRegisterDate: now, appType: appType, cnvsDateTime: now, cnvsFirstRegisterDateTime: now, cnvsRemindDateTimeForAllarm: newMessage.cnvsRemindDateTimeForAllarm, insertedConversationID: objectParameter, languageID: defLangID, cnvsFOCmpCanSee: newMessage.cnvsFOCmpCanSee, cnvsIsTicket: newMessage.cnvsIsTicket, cnvsStatusResultId: newMessage.cnvsStatusResultId, centerId: (num2 != 0) ? num2 : null);
				int num5 = (int)objectParameter.Value;
				if (num5 > 0)
				{
					int? centerId = CRMIdeal.Classes.Helper.Company.GetPrjCId(newMessage.ProjectId);
					if (centerId.GetValueOrDefault() == 0)
					{
						centerId = num2;
					}
					Languages languages = Enumerable.FirstOrDefault<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID == defLangID));
					string culture = ((languages != null && !string.IsNullOrEmpty(languages.LanguageCollation)) ? languages.LanguageCollation : "fa-IR");
					foreach (Languages lang6 in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
					{
						CrmConversation_Lang entity = new CrmConversation_Lang
						{
							LanguageID = lang6.LanguageID,
							cnvsDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang6.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang6.LanguageID)).Value : null),
							cnvsReferDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang6.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang6.LanguageID)).Value : null),
							ConversationID = num5
						};
						_dbTbl.CrmConversation_Lang.Add(entity);
						_dbTbl.SaveChanges();
					}
					bool flag4 = false;
					string msgSubject = "";
					string text12 = "";
					List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
					List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
					if (newMessage.cnvsReferUserId != userId)
					{
						flag4 = true;
						msgSubject = MyResource.GetResourceString("ConversationErjaFrom", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + CRMIdeal.Classes.Helper.Company.GetUserName(UserLogin.CurrentUser.UserId, defLangID, defLangID);
						text12 = MyResource.GetResourceString("ConversationErjaInConnection", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + CRMIdeal.Classes.Helper.Company.GetCompanyName(newMessage.CompanyId, defLangID, defLangID) + "\r\n" + MyResource.GetResourceString("ConversationErjaPerson", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + CRMIdeal.Classes.Helper.Company.GetCmpPersonName(defLangID, defLangID, newMessage.cnvsPersonId) + "\r\n" + MyResource.GetResourceString("ConversationErjaProject", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + CRMIdeal.Classes.Helper.Company.GetCmpProjectTitle(defLangID, defLangID, newMessage.ProjectId) + "\r\n\r\n" + MyResource.GetResourceString("ConversationErjaConversationDescription", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":\r\n" + newMessage.cnvsDesc;
						if (!string.IsNullOrEmpty(newMessage.cnvsReferDesc))
						{
							text12 = text12 + "\r\n" + MyResource.GetResourceString("ConversationErjaReferDescription", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":\r\n" + newMessage.cnvsReferDesc;
						}
						text12 = text12 + "\r\n\r\n" + MyResource.GetResourceString("ConversationErjaDetails", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						foreach (Languages lang5 in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
						{
							list3.Add(new CommonMultiLanguageViewModel
							{
								LanguageId = lang5.LanguageID,
								Value = MyResource.GetResourceString("ConversationErjaFrom", lang5.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + CRMIdeal.Classes.Helper.Company.GetUserName(UserLogin.CurrentUser.UserId, defLangID, lang5.LanguageID)
							});
							string text13 = MyResource.GetResourceString("ConversationErjaInConnection", lang5.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + CRMIdeal.Classes.Helper.Company.GetCompanyName(newMessage.CompanyId, defLangID, lang5.LanguageID) + "\r\n" + MyResource.GetResourceString("ConversationErjaPerson", lang5.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + CRMIdeal.Classes.Helper.Company.GetCmpPersonName(defLangID, lang5.LanguageID, newMessage.cnvsPersonId) + "\r\n" + MyResource.GetResourceString("ConversationErjaProject", lang5.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + CRMIdeal.Classes.Helper.Company.GetCmpProjectTitle(defLangID, lang5.LanguageID, newMessage.ProjectId) + "\r\n\r\n" + MyResource.GetResourceString("ConversationErjaConversationDescription", lang5.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":\r\n" + ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang5.LanguageID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang5.LanguageID)).Value : null);
							if (!string.IsNullOrEmpty(newMessage.cnvsReferDesc))
							{
								text13 = text13 + "\r\n" + MyResource.GetResourceString("ConversationErjaReferDescription", lang5.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":\r\n" + ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang5.LanguageID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang5.LanguageID)).Value : null);
							}
							text13 = text13 + "\r\n\r\n" + MyResource.GetResourceString("ConversationErjaDetails", lang5.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
							list4.Add(new CommonMultiLanguageViewModel
							{
								LanguageId = lang5.LanguageID,
								Value = text13
							});
						}
					}
					bool flag5 = false;
					string msgSubject2 = "";
					string text14 = "";
					int value2 = 0;
					List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
					List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
					if (cRMspSelectCompanyConversationLastStatus_Result != null)
					{
						bool valueOrDefault = Enumerable.FirstOrDefault<bool?>((IEnumerable<bool?>)Enumerable.ToList<bool?>((IEnumerable<bool?>)db.CRMspSelectDisableReceiveCNVSInfoAllarmStatus(cRMspSelectCompanyConversationLastStatus_Result.cnvsReferUserId))).GetValueOrDefault();
						if (cRMspSelectCompanyConversationLastStatus_Result.cnvsReferUserId != newMessage.cnvsReferUserId && cRMspSelectCompanyConversationLastStatus_Result.cnvsReferUserId != newMessage.cnvsUserId && !valueOrDefault)
						{
							flag5 = true;
							value2 = cRMspSelectCompanyConversationLastStatus_Result.cnvsReferUserId.GetValueOrDefault();
							msgSubject2 = MyResource.GetResourceString("ConversationErjaNotice", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + " : " + CRMIdeal.Classes.Helper.Company.GetUserName(UserLogin.CurrentUser.UserId, defLangID, defLangID);
							text14 = "**" + MyResource.GetResourceString("ConversationErjaAutomatically", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n\r\n" + MyResource.GetResourceString("ConversationErjaAttention", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ConversationErjaInConnection", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + CRMIdeal.Classes.Helper.Company.GetCompanyName(newMessage.CompanyId, defLangID, defLangID) + "\r\n" + MyResource.GetResourceString("ConversationErjaPerson", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + CRMIdeal.Classes.Helper.Company.GetCmpPersonName(defLangID, defLangID, newMessage.cnvsPersonId) + "\r\n" + MyResource.GetResourceString("ConversationErjaProject", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + CRMIdeal.Classes.Helper.Company.GetCmpProjectTitle(defLangID, defLangID, newMessage.ProjectId) + "\r\n\r\n" + MyResource.GetResourceString("ConversationErjaLastNegotiator", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ", " + MyResource.GetResourceString("ConversationErjaTransmitter", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n\r\n" + MyResource.GetResourceString("ConversationErjaConversationDescription", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": \r\n" + newMessage.cnvsDesc;
							if (!string.IsNullOrEmpty(newMessage.cnvsReferDesc))
							{
								text14 = text14 + "\r\n" + MyResource.GetResourceString("ConversationErjaReferDescription", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":\r\n" + newMessage.cnvsReferDesc;
							}
							text12 = text12 + "\r\n\r\n" + MyResource.GetResourceString("ConversationErjaDetails", culture, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						}
					}
					foreach (Languages lang4 in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
					{
						list5.Add(new CommonMultiLanguageViewModel
						{
							LanguageId = lang4.LanguageID,
							Value = MyResource.GetResourceString("ConversationErjaNotice", lang4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + CRMIdeal.Classes.Helper.Company.GetUserName(UserLogin.CurrentUser.UserId, defLangID, lang4.LanguageID)
						});
						string text15 = "";
						text15 = "**" + MyResource.GetResourceString("ConversationErjaAutomatically", lang4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n\r\n" + MyResource.GetResourceString("ConversationErjaAttention", lang4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ConversationErjaInConnection", lang4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + CRMIdeal.Classes.Helper.Company.GetCompanyName(newMessage.CompanyId, defLangID, lang4.LanguageID) + "\r\n" + MyResource.GetResourceString("ConversationErjaPerson", lang4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + CRMIdeal.Classes.Helper.Company.GetCmpPersonName(defLangID, lang4.LanguageID, newMessage.cnvsPersonId) + "\r\n" + MyResource.GetResourceString("ConversationErjaProject", lang4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + CRMIdeal.Classes.Helper.Company.GetCmpProjectTitle(defLangID, lang4.LanguageID, newMessage.ProjectId) + "\r\n\r\n" + MyResource.GetResourceString("ConversationErjaLastNegotiator", lang4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ", " + MyResource.GetResourceString("ConversationErjaTransmitter", lang4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n\r\n" + MyResource.GetResourceString("ConversationErjaConversationDescription", lang4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": \r\n" + ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang4.LanguageID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang4.LanguageID)).Value : null);
						if (!string.IsNullOrEmpty(newMessage.cnvsReferDesc))
						{
							text15 = text15 + "\r\n" + MyResource.GetResourceString("ConversationErjaReferDescription", lang4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":\r\n" + ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang4.LanguageID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang4.LanguageID)).Value : null);
						}
						text15 = text15 + "\r\n\r\n" + MyResource.GetResourceString("ConversationErjaDetails", lang4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						list6.Add(new CommonMultiLanguageViewModel
						{
							LanguageId = lang4.LanguageID,
							Value = text15
						});
					}
					DateTime now2 = DateTime.Now;
					short value3 = short.Parse(now2.ToString("yyyy", new PersianCulture()));
					short value4 = short.Parse(now2.ToString("MM", new PersianCulture()));
					if (flag4)
					{
						DateTime now3 = DateTime.Now;
						ObjectParameter objectParameter2 = new ObjectParameter("InsertedID", 0);
						db.CRMspInternalMessageSendSingle(null, msgSubject, text12, 10, userId, newMessage.cnvsReferUserId, now3.ToString("yyyyMMdd", new PersianCulture()), now3.ToString("HH:mm:ss"), now3, null, "", num5, Messages.ConversationErjaDetails, null, userId, value3, value4, now3, now3.ToString("yyyyMMdd", new PersianCulture()), appType, objectParameter2, defLangID, null, null, centerId);
						int num6 = (int)objectParameter2.Value;
						if (num6 > 0)
						{
							foreach (Languages lang3 in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
							{
								CrmInternalMessage_Lang entity2 = new CrmInternalMessage_Lang
								{
									LanguageID = lang3.LanguageID,
									InternalMessageID = num6,
									msgBody = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang3.LanguageID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang3.LanguageID)).Value : null),
									msgSubject = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang3.LanguageID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang3.LanguageID)).Value : null)
								};
								_dbTbl.CrmInternalMessage_Lang.Add(entity2);
								_dbTbl.SaveChanges();
							}
						}
					}
					bool result18 = false;
					bool.TryParse(newMessage.cnvsIsTicket.ToString(), out result18);
					if (flag5 && !result18)
					{
						DateTime now4 = DateTime.Now;
						ObjectParameter objectParameter3 = new ObjectParameter("InsertedID", 0);
						db.CRMspInternalMessageSendSingle(null, msgSubject2, text14, 10, userId, value2, now4.ToString("yyyyMMdd", new PersianCulture()), now4.ToString("HH:mm:ss"), now4, 1, "", num5, Messages.ConversationErjaDetails, null, userId, value3, value4, now4, now4.ToString("yyyyMMdd", new PersianCulture()), appType, objectParameter3, defLangID, null, null, centerId);
						int num7 = (int)objectParameter3.Value;
						if (num7 > 0)
						{
							foreach (Languages lang2 in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
							{
								CrmInternalMessage_Lang entity3 = new CrmInternalMessage_Lang
								{
									LanguageID = lang2.LanguageID,
									InternalMessageID = num7,
									msgBody = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)).Value : null),
									msgSubject = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)).Value : null)
								};
								_dbTbl.CrmInternalMessage_Lang.Add(entity3);
								_dbTbl.SaveChanges();
							}
						}
					}
					if (!newMessage.cnvsStatusResultId.HasValue)
					{
						base.ViewBag.SuccessfullConversationInsert = Messages.cnvsConversationInsertSuccessFulMessage;
					}
					else
					{
						CRMspSelectConversationStatusResultById_Result cRMspSelectConversationStatusResultById_Result2 = Enumerable.FirstOrDefault<CRMspSelectConversationStatusResultById_Result>((IEnumerable<CRMspSelectConversationStatusResultById_Result>)_dbI.CRMspSelectConversationStatusResultById(newMessage.cnvsStatusResultId, lCID, defLangID));
						if (cRMspSelectConversationStatusResultById_Result2 == null)
						{
							base.ViewBag.SuccessfullConversationInsert = Messages.cnvsConversationInsertSuccessFulMessage;
						}
						else
						{
							int value5 = num5;
							DateTime now5 = DateTime.Now;
							DateTime value6 = now5;
							string registerDatePersian = now5.ToString("yyyyMMdd", new PersianCulture());
							short value7 = short.Parse(now5.ToString("MM", new PersianCulture()));
							string appType2 = Configuration.AppType;
							short value8 = short.Parse(Financial.Get().Id.ToString());
							int userId3 = UserLogin.CurrentUser.UserId;
							string conversationErjaShow = Messages.ConversationErjaShow;
							bool result19 = false;
							bool.TryParse(cRMspSelectConversationStatusResultById_Result2.EventPolicyActive.ToString(), out result19);
							string text16 = "";
							string surveyMainExtrenalLinkLogin = "";
							string surveyMainExtrenalLink = "";
							Uri url = base.HttpContext.Request.Url;
							string text17 = url.Scheme + "://" + url.Authority;
							if (text17.EndsWith("/"))
							{
								text17 = text17.TrimEnd(new char[1] { '/' });
							}
							text17 += "/Survey/Home/SurveyAnswerValues";
							text16 = text17;
							string text18 = "";
							string text19 = "";
							string text20 = "";
							if (cRMspSelectCrmsysSetting_Result != null)
							{
								text19 = cRMspSelectCrmsysSetting_Result.FOUrl ?? "";
								text20 = cRMspSelectCrmsysSetting_Result.CrmIPStatic ?? "";
							}
							if (!string.IsNullOrWhiteSpace(text19))
							{
								text18 = text19.Trim();
								if (!text18.Contains("http"))
								{
									text18 = url.Scheme + "://" + text18;
								}
								if (text18.EndsWith("/"))
								{
									text18 = text18.TrimEnd(new char[1] { '/' });
								}
								text18 += "/Survey/Home";
								surveyMainExtrenalLinkLogin = text18;
							}
							if (!string.IsNullOrWhiteSpace(text20))
							{
								text18 = text20.Trim();
								if (!text18.Contains("http"))
								{
									text18 = url.Scheme + "://" + text18;
								}
								if (text18.EndsWith("/"))
								{
									text18 = text18.TrimEnd(new char[1] { '/' });
								}
								text18 += "/Survey/Register/Index";
								surveyMainExtrenalLink = text18;
							}
							int maxFOCount = Configuration.MaxFOCount;
							ObjectParameter objectParameter4 = new ObjectParameter("ResultJson", "");
							_dbI.CRMspCnvsStatusResultEventExecute(value5, "", null, false, text16, surveyMainExtrenalLink, surveyMainExtrenalLinkLogin, conversationErjaShow, "", userId3, value8, value7, value6, registerDatePersian, appType2, lCID, defLangID, objectParameter4, centerId, maxFOCount);
							string text21 = "";
							if (objectParameter4 != null && objectParameter4.Value != null && !string.IsNullOrWhiteSpace(objectParameter4.Value.ToString()))
							{
								List<CRMspRunCnvsStatusResultEventPolicyViewModel> list7 = new JavaScriptSerializer().Deserialize<List<CRMspRunCnvsStatusResultEventPolicyViewModel>>(objectParameter4.Value.ToString());
								if (list7 != null && Enumerable.Any<CRMspRunCnvsStatusResultEventPolicyViewModel>((IEnumerable<CRMspRunCnvsStatusResultEventPolicyViewModel>)list7) && Enumerable.FirstOrDefault<CRMspRunCnvsStatusResultEventPolicyViewModel>((IEnumerable<CRMspRunCnvsStatusResultEventPolicyViewModel>)list7, (Func<CRMspRunCnvsStatusResultEventPolicyViewModel, bool>)((CRMspRunCnvsStatusResultEventPolicyViewModel m) => m.EventPolicyTypeId.GetValueOrDefault() == 14 && (m.EventPolicyShortText ?? "") == "FOCountModule")) != null)
								{
									string companyNameWithTitle = CRMIdeal.Classes.Helper.Company.GetCompanyNameWithTitle(newMessage.CompanyId);
									text2 = "<br>" + string.Format(Messages.msgLackCapacityCmpFoNotActive, companyNameWithTitle);
									list7 = Enumerable.ToList<CRMspRunCnvsStatusResultEventPolicyViewModel>(Enumerable.Where<CRMspRunCnvsStatusResultEventPolicyViewModel>((IEnumerable<CRMspRunCnvsStatusResultEventPolicyViewModel>)list7, (Func<CRMspRunCnvsStatusResultEventPolicyViewModel, bool>)((CRMspRunCnvsStatusResultEventPolicyViewModel m) => m.EventPolicyTypeId.GetValueOrDefault() != 14 && (m.EventPolicyShortText ?? "") != "FOCountModule")));
								}
								if (list7 != null && Enumerable.Any<CRMspRunCnvsStatusResultEventPolicyViewModel>((IEnumerable<CRMspRunCnvsStatusResultEventPolicyViewModel>)list7))
								{
									CRMspRunCnvsStatusResultEventPolicyViewModel cRMspRunCnvsStatusResultEventPolicyViewModel = Enumerable.FirstOrDefault<CRMspRunCnvsStatusResultEventPolicyViewModel>((IEnumerable<CRMspRunCnvsStatusResultEventPolicyViewModel>)list7, (Func<CRMspRunCnvsStatusResultEventPolicyViewModel, bool>)((CRMspRunCnvsStatusResultEventPolicyViewModel m) => (m.MessageError ?? "") != ""));
									if (cRMspRunCnvsStatusResultEventPolicyViewModel != null)
									{
										text21 = cRMspRunCnvsStatusResultEventPolicyViewModel.MessageError ?? "";
									}
								}
							}
							if (string.IsNullOrWhiteSpace(text21))
							{
								base.ViewBag.SuccessfullConversationInsert = Messages.cnvsConversationInsertSuccessFulMessage + text2;
							}
							else
							{
								text = Messages.msgErrorRunFunction + "<br>" + text21;
								base.ViewBag.Error = text;
							}
						}
					}
					bool result20 = false;
					int result21 = 0;
					bool.TryParse(newMessage.CnvsReferredRemindOk.ToString(), out result20);
					int.TryParse(newMessage.CnvsReferredId.ToString(), out result21);
					if (result20 && result21 > 0)
					{
						dbI.CRMspUpdateConversationRemindOk(result21, true, userId, short.Parse(now.ToString("MM", new PersianCulture())), short.Parse(id.ToString()), now.ToString("yyyyMMdd", new PersianCulture()), now, appType, num2);
					}
					if (newMessage.IsCloseTicket)
					{
						int userId4 = UserLogin.CurrentUser.UserId;
						DateTime now6 = DateTime.Now;
						DateTime value9 = now6;
						string registerDatePersian2 = now6.ToString("yyyyMMdd", new PersianCulture());
						short value10 = short.Parse(now6.ToString("MM", new PersianCulture()));
						short value11 = short.Parse(Financial.Get().Id.ToString());
						string appType3 = Configuration.AppType;
						_dbI.CRMspCloseTicket(newMessage.ProjectId, userId4, value11, value10, value9, registerDatePersian2, appType3, num2);
					}
					bool result22 = false;
					bool.TryParse(newMessage.cnvsIsTicket.ToString(), out result22);
					if (result22 && num5 > 0)
					{
						int userId5 = UserLogin.CurrentUser.UserId;
						DateTime now7 = DateTime.Now;
						DateTime value12 = now7;
						string registerDatePersian3 = now7.ToString("yyyyMMdd", new PersianCulture());
						short value13 = short.Parse(now7.ToString("MM", new PersianCulture()));
						short value14 = short.Parse(Financial.Get().Id.ToString());
						string appType4 = Configuration.AppType;
						_dbI.CRMspCalcAndUpdateTicketDoingDuration(num5, userId5, value14, value13, value12, registerDatePersian3, appType4);
					}
					if (UserLogin.IsUserAccess("frmDefineConversation", "actCanChangePrjTicketStop", UserLogin.CurrentUser) && num5 > 0 && result22)
					{
						int userId6 = UserLogin.CurrentUser.UserId;
						DateTime now8 = DateTime.Now;
						string prjTicketStopRegisterDatePersian = now8.ToString("yyyyMMdd", new PersianCulture());
						string appType5 = Configuration.AppType;
						_dbI.CRMspUpdateProjectTicketStop(newMessage.ProjectId, newMessage.prjTicketStop, userId6, now8, prjTicketStopRegisterDatePersian, appType5);
					}
					bool valueOrDefault2 = newMessage.cnvsIsTicket.GetValueOrDefault();
					bool valueOrDefault3 = newMessage.cnvsFOCmpCanSee.GetValueOrDefault();
					if (valueOrDefault2 && valueOrDefault3)
					{
						CRMspSelectCrmProjectsById_Result cRMspSelectCrmProjectsById_Result = Enumerable.FirstOrDefault<CRMspSelectCrmProjectsById_Result>((IEnumerable<CRMspSelectCrmProjectsById_Result>)db.CRMspSelectCrmProjectsById(newMessage.ProjectId, lCID, defLangID));
						if (cRMspSelectCrmProjectsById_Result != null)
						{
							int result23 = 0;
							int? num8 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbI.CRMspGetUnReadTicketWithCmpId(newMessage.CompanyId));
							if (num8.HasValue)
							{
								int.TryParse(num8.ToString(), out result23);
							}
							string body = cRMspSelectCrmProjectsById_Result.ProjectTitle ?? "";
							Dictionary<string, string> dictionary = new Dictionary<string, string>();
							dictionary.Add("UnReadTicketCnt", result23.ToString());
							dictionary.Add("cnvsId", num5.ToString());
							dictionary.Add("prjId", newMessage.ProjectId.ToString());
							PushNotif.NewTicketNotify(newMessage.CompanyId, Labels.CnvsSendNotifNewTicket, body, dictionary);
						}
					}
					string errorMsg = "";
					if (!CRMIdeal.Classes.Helper.OtherSystems.SendCmpToLinkAccByShpIsActive(newMessage.CompanyId, num2.GetValueOrDefault(), ref errorMsg))
					{
						int result24 = 0;
						string text22 = "";
						CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result2 = SysSeting.Get();
						if (cRMspSelectCrmsysSetting_Result2 != null)
						{
							int.TryParse(cRMspSelectCrmsysSetting_Result2.LinkAccSystemId.ToString(), out result24);
						}
						text22 = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
						base.ViewBag.SuccessfullConversationInsert = Messages.cnvsConversationInsertSuccessFulMessage + "<br>" + string.Format(Messages.msgErrorSendCmpToOtherSystem, text22) + "<br>" + errorMsg;
					}
					PushNotif.NewIntMsgNotify();
					Alarms.Update(newMessage.UserId);
					CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
					Alarms.Update(newMessage.cnvsReferUserId);
					Alarms.Update(currentUser.UserId);
					string text23 = "";
					try
					{
						foreach (CRMspLoadRemindingTask_Result item in Alarms.Get(currentUser.UserId))
						{
							if (text23.Trim() != "")
							{
								text23 += "@";
							}
							text23 = text23 + item.Type + "|" + item.UserTaskId + "|" + item.UserTaskTitle + "|" + item.UserTaskTime + "|" + item.UserTaskDatePersian + "|" + item.UserTaskRemindTime + "|" + item.UserTaskRemindDate + "|" + item.Val1 + "|" + item.Val2 + "|" + item.Val3 + "|" + item.UserTaskDate.ToString() + "|" + item.UserTaskRemindDateTime.ToString() + "|" + ((item.IsRecurringTask != false) ? 1 : 0);
						}
					}
					catch (Exception e2)
					{
						ErrorSignal.FromCurrentContext().Raise(e2);
					}
					base.ViewBag.ResultLocalStorage = text23;
					goto IL_35b3;
				}
				text = text + Messages.msgErrorInCnvsInsert + "<br>";
				num++;
			}
			goto end_IL_02d3;
			IL_0368:
			bool result25 = false;
			int result26 = 0;
			bool.TryParse(newMessage.CnvsReferredRemindOk.ToString(), out result25);
			int.TryParse(newMessage.CnvsReferredId.ToString(), out result26);
			if (!result25 || result26 <= 0)
			{
				goto IL_03de;
			}
			string text24 = CRMIdeal.Classes.Helper.Company.CheckCnvsRemindOkByPrjPrdHNotDone(newMessage.ProjectId);
			if (string.IsNullOrWhiteSpace(text24))
			{
				goto IL_03de;
			}
			text = text + text24 + "<br>";
			num++;
			end_IL_02d3:;
		}
		catch (DbEntityValidationException e3)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e3);
			text = text + Messages.msgErrorInCnvsInsert + "<br>";
			num++;
		}
		catch (Exception e4)
		{
			ErrorSignal.FromCurrentContext().Raise(e4);
			text = text + Messages.msgErrorInCnvsInsert + "<br>";
			num++;
		}
		goto IL_460b;
		IL_35b3:
		try
		{
			if (base.ModelState.IsValid)
			{
				List<CommonMultiLanguageViewModel> list8 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(newMessage.msgBody_Lang))
				{
					list8 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(newMessage.msgBody_Lang);
				}
				list8.Add(new CommonMultiLanguageViewModel
				{
					Value = newMessage.msgBody,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list9 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(newMessage.msgSubject_Lang))
				{
					list9 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(newMessage.msgSubject_Lang);
				}
				list9.Add(new CommonMultiLanguageViewModel
				{
					Value = newMessage.msgSubject,
					LanguageId = lCID
				});
				if (newMessage.msgToUsersTitle == null && newMessage.msgToUsersTitle == "")
				{
					text = text + Messages.CheckEmptyMsgToUsersTitle + "|";
					num++;
				}
				if (newMessage.msgBody == null && newMessage.msgBody == "")
				{
					text = text + Messages.CheckEmptyMsgBody + "|";
					num++;
				}
				else if (!checkMultiLanguage(newMessage.msgBody, list8))
				{
					text = text + Messages.CheckMsgBodyLang + "<br>";
					num++;
				}
				if (newMessage.msgActiveInCycle.GetValueOrDefault() && (!newMessage.msgLastGroupId.HasValue || newMessage.msgLastGroupId == 0))
				{
					text = text + Messages.CheckEmptyMsgActiveInCycle + "|";
					num++;
				}
				newMessage.msgBody = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
				newMessage.msgSubject = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
				newMessage.AttachRecId = ((newMessage.messageAttachRecId > 0) ? newMessage.messageAttachRecId : 0);
				if (newMessage.msgActiveInCycle.GetValueOrDefault())
				{
					newMessage.msgTypeId = 12;
				}
				if (!(newMessage.msgTypeId > 0) || newMessage.msgTypeId.GetValueOrDefault() == 2)
				{
					newMessage.msgTypeId = 1;
				}
				if (newMessage.ReplyPriorityID == 0)
				{
					newMessage.ReplyPriorityID = null;
				}
				if (newMessage.msgLastGroupId == 0)
				{
					newMessage.msgLastGroupId = null;
				}
				if (num == 0)
				{
					newMessage.UserId = userId;
					newMessage.msgFromUserId = UserLogin.CurrentUser.UserId;
					DateTime now9 = DateTime.Now;
					newMessage.ImportDate = now9.ToString("yyyyMMdd", new PersianCulture());
					newMessage.RegisterDate = now9;
					newMessage.RegisterDatePersian = now9.ToString("yyyyMMdd", new PersianCulture());
					newMessage.Year1 = short.Parse(now9.ToString("yyyy", new PersianCulture()));
					newMessage.Month1 = short.Parse(now9.ToString("MM", new PersianCulture()));
					string msgdSendDate = now9.ToString("yyyyMMdd", new PersianCulture());
					string msgdSendTime = now9.ToString("HH:mm:ss");
					DateTime value15 = now9;
					string msgdAttachFile = "";
					string msgdAttachRecDesc = "";
					if (!string.IsNullOrEmpty(newMessage.AttachRecDesc))
					{
						msgdAttachRecDesc = newMessage.AttachRecDesc;
					}
					List<CRMspSelectFilesDirectoryTemplateByTypeAndUser_Result> list10 = Enumerable.ToList<CRMspSelectFilesDirectoryTemplateByTypeAndUser_Result>((IEnumerable<CRMspSelectFilesDirectoryTemplateByTypeAndUser_Result>)_dbI.CRMspSelectFilesDirectoryTemplateByTypeAndUser(1, userId));
					if (list10.Count > 0 && !VersionBuyer.AttachFiles && flag)
					{
						base.ViewBag.Error = "BV|" + Messages.VersionBuy;
						return View(newMessage);
					}
					List<CrmInternalMessage_Lang> list11 = new List<CrmInternalMessage_Lang>();
					foreach (Languages lang in Enumerable.ToList<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get()))
					{
						CrmInternalMessage_Lang crmInternalMessage_Lang = new CrmInternalMessage_Lang();
						crmInternalMessage_Lang.LanguageID = lang.LanguageID;
						crmInternalMessage_Lang.msgSubject = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						string text25 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : "");
						if (newMessage.msgTypeId.GetValueOrDefault() != 12)
						{
							string text26 = "";
							CRMspSelectUsersById_Result cRMspSelectUsersById_Result = CRMIdeal.Classes.Helper.User.SelectUsersById(UserLogin.CurrentUser.UserId, -1, lang.LanguageID, defLangID);
							if (cRMspSelectUsersById_Result != null)
							{
								text26 = cRMspSelectUsersById_Result.FName + " " + cRMspSelectUsersById_Result.LName;
							}
							string languageCollation = lang.LanguageCollation;
							CultureInfo cultureInfo = ((languageCollation.Trim().ToLower() == "fa-ir") ? new PersianCulture() : new CultureInfo(languageCollation));
							string text27 = DateTime.Now.ToString("yyyy/MM/dd", cultureInfo);
							text25 = Environment.NewLine + "-->" + text26 + "  " + text27 + " " + DateTime.Now.ToString("HH:mm:ss") + Environment.NewLine + text25;
						}
						crmInternalMessage_Lang.msgBody = text25;
						list11.Add(crmInternalMessage_Lang);
					}
					string text28 = "";
					string text29 = "";
					string intMsgLang = "";
					if (list11 != null && Enumerable.Any<CrmInternalMessage_Lang>((IEnumerable<CrmInternalMessage_Lang>)list11))
					{
						text29 = (Enumerable.Any<CrmInternalMessage_Lang>((IEnumerable<CrmInternalMessage_Lang>)list11, (Func<CrmInternalMessage_Lang, bool>)((CrmInternalMessage_Lang c) => c.LanguageID == defLangID)) ? Enumerable.FirstOrDefault<CrmInternalMessage_Lang>((IEnumerable<CrmInternalMessage_Lang>)list11, (Func<CrmInternalMessage_Lang, bool>)((CrmInternalMessage_Lang c) => c.LanguageID == defLangID)).msgSubject : "");
						text28 = (Enumerable.Any<CrmInternalMessage_Lang>((IEnumerable<CrmInternalMessage_Lang>)list11, (Func<CrmInternalMessage_Lang, bool>)((CrmInternalMessage_Lang c) => c.LanguageID == defLangID)) ? Enumerable.FirstOrDefault<CrmInternalMessage_Lang>((IEnumerable<CrmInternalMessage_Lang>)list11, (Func<CrmInternalMessage_Lang, bool>)((CrmInternalMessage_Lang c) => c.LanguageID == defLangID)).msgBody : "");
						intMsgLang = JsonConvert.SerializeObject(Enumerable.ToList<CrmInternalMessage_Lang>(Enumerable.Where<CrmInternalMessage_Lang>((IEnumerable<CrmInternalMessage_Lang>)list11, (Func<CrmInternalMessage_Lang, bool>)((CrmInternalMessage_Lang c) => c.LanguageID != defLangID))));
					}
					ObjectParameter objectParameter5 = new ObjectParameter("InternalMessageID", 0);
					_dbII.CRMspInternalMessageSendWeb(newMessage.msgMasterId, text29, text28, newMessage.MsgActiveInCycle1, newMessage.msgTypeId, newMessage.msgFromUserId, 0, msgdSendDate, msgdSendTime, value15, newMessage.ReplyPriorityID, msgdAttachFile, newMessage.AttachRecId, msgdAttachRecDesc, newMessage.msgLastGroupId, newMessage.IntMsgReceivers, intMsgLang, newMessage.UserId, newMessage.Year1, newMessage.Month1, newMessage.RegisterDate, newMessage.RegisterDatePersian, appType, defLangID, newMessage.msgAttachRecIdI, newMessage.msgAttachRecDescI, objectParameter5, (num2 != 0) ? num2 : null);
					int result27 = 0;
					if (objectParameter5 != null && objectParameter5.Value != null)
					{
						int.TryParse(objectParameter5.Value.ToString(), out result27);
					}
					if (result27 > 0)
					{
						int? fileCId = null;
						if (num2.GetValueOrDefault() != 0)
						{
							fileCId = num2;
						}
						bool flag6 = false;
						foreach (CRMspSelectFilesDirectoryTemplateByTypeAndUser_Result item2 in list10)
						{
							DateTime now10 = DateTime.Now;
							CrmFilesDirectory crmFilesDirectory = new CrmFilesDirectory();
							crmFilesDirectory.UserId = UserLogin.CurrentUser.UserId;
							crmFilesDirectory.Year1 = short.Parse(Financial.Get().Id.ToString());
							crmFilesDirectory.Month1 = short.Parse(now10.ToString("MM", new PersianCulture()));
							crmFilesDirectory.GUId = System.Guid.NewGuid();
							crmFilesDirectory.RegisterDate = now10;
							crmFilesDirectory.RegisterDatePersian = now10.ToString("yyyyMMdd", new PersianCulture());
							crmFilesDirectory.DocDateTime = now10;
							crmFilesDirectory.DocTime = now10.ToString("HH:mm:ss");
							crmFilesDirectory.DocDay = PersianDate.GetNumberWeekOfDay(DateTime.Now.ToString("yyyy/MM/dd", new PersianCulture())).ToString();
							crmFilesDirectory.DocDate = now10.ToString("yyyyMMdd", new PersianCulture());
							crmFilesDirectory.Title = item2.Title;
							crmFilesDirectory.TypeOprObjectId = result27;
							crmFilesDirectory.FilePath = "";
							crmFilesDirectory.FileName = "";
							crmFilesDirectory.FolderName = result27.ToString();
							crmFilesDirectory.AppType = appType;
							crmFilesDirectory.LanguageID = defLangID;
							crmFilesDirectory.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
							crmFilesDirectory.FirstRegisterDate = now10;
							crmFilesDirectory.FirstRegisterDatePersian = now10.ToString("yyyyMMdd", new PersianCulture());
							crmFilesDirectory.FileCId = fileCId;
							_dbTbl.CrmFilesDirectory.Add(crmFilesDirectory);
							_dbTbl.SaveChanges();
							if (crmFilesDirectory.FileDirectoryID <= 0)
							{
								continue;
							}
							FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
							string text30 = Configuration.MainDirectoryPath + Configuration.IntmsgDirectoryPath;
							string intmsgDirectoryPath = Configuration.IntmsgDirectoryPath;
							intmsgDirectoryPath = (intmsgDirectoryPath.EndsWith("/") ? intmsgDirectoryPath.TrimEnd(new char[1] { '/' }) : intmsgDirectoryPath);
							bool flag7 = facadeFTP.ExistsDirectoryInFtp(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, Configuration.MainDirectoryPath, intmsgDirectoryPath, Configuration.UsePassiveFtp);
							if (!flag7)
							{
								flag7 = facadeFTP.CreateDirectoryInFtp(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, Configuration.MainDirectoryPath, intmsgDirectoryPath, Configuration.UsePassiveFtp);
							}
							string directoryName = result27.ToString();
							bool flag8 = facadeFTP.ExistsDirectoryInFtp(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, text30, directoryName, Configuration.UsePassiveFtp);
							if (!flag8)
							{
								flag8 = facadeFTP.CreateDirectoryInFtp(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, text30, directoryName, Configuration.UsePassiveFtp);
							}
							if (flag8 && flag7)
							{
								string text31 = "";
								string text32 = "";
								text30 = text30 + result27 + "/";
								if (item2.CopyFromPath.Contains("FileDirectoryID:"))
								{
									_003C_003Ec__DisplayClass189_7 _003C_003Ec__DisplayClass189_ = new _003C_003Ec__DisplayClass189_7();
									_003C_003Ec__DisplayClass189_.fId = 0;
									int.TryParse(item2.CopyFromPath.Replace("FileDirectoryID:", ""), out _003C_003Ec__DisplayClass189_.fId);
									DbSet<CrmFilesDirectory> crmFilesDirectory2 = _dbTbl.CrmFilesDirectory;
									ParameterExpression val = Expression.Parameter(typeof(CrmFilesDirectory), "c");
									if (Queryable.FirstOrDefault<CrmFilesDirectory>((IQueryable<CrmFilesDirectory>)crmFilesDirectory2, Expression.Lambda<Func<CrmFilesDirectory, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass189_, typeof(_003C_003Ec__DisplayClass189_7)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
									{
										string filePath = new CompanyInfoController().GetFilePath(_003C_003Ec__DisplayClass189_.fId, idUrlEncode: false);
										if (filePath != "")
										{
											string[] array4 = filePath.Split(new char[1] { '.' });
											text31 = result27 + "-" + crmFilesDirectory.FileDirectoryID + "." + array4[^1];
											text30 += text31;
											text32 = filePath;
										}
									}
								}
								else
								{
									string[] array5 = item2.CopyFromPath.Split(new char[1] { '.' });
									text31 = result27 + "-" + crmFilesDirectory.FileDirectoryID + "." + array5[^1];
									text30 += text31;
									text32 = item2.CopyFromPath;
								}
								if (text32 != "")
								{
									flag6 = facadeFTP.UploadFtpFormTable(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, text30, text32, Configuration.UsePassiveFtp);
								}
								crmFilesDirectory.FilePath = text30;
								crmFilesDirectory.FileName = text31;
								crmFilesDirectory.AppType = Configuration.AppType;
								_dbTbl.Entry(crmFilesDirectory).State = EntityState.Modified;
								_dbTbl.SaveChanges();
							}
							else
							{
								try
								{
									db.CRMspDeleteCrmFilesDirectory(crmFilesDirectory.FileDirectoryID);
								}
								catch (Exception e5)
								{
									ErrorSignal.FromCurrentContext().Raise(e5);
								}
							}
						}
						List<CRMspIntMsgSelectMessageFiles_Result> list12 = Enumerable.ToList<CRMspIntMsgSelectMessageFiles_Result>((IEnumerable<CRMspIntMsgSelectMessageFiles_Result>)db.CRMspIntMsgSelectMessageFiles(result27));
						if (list12.Count != 0 || list10.Count <= 0 || flag6)
						{
							base.ViewBag.SuccessfullInsert = Messages.IntMsgNew + text2;
						}
						else
						{
							base.ViewBag.SuccessfullInsert = Messages.IntMsgNewWithOutFile + text2;
							CRMspSelectInternalMessageById_Result cRMspSelectInternalMessageById_Result = Enumerable.FirstOrDefault<CRMspSelectInternalMessageById_Result>((IEnumerable<CRMspSelectInternalMessageById_Result>)dbI.CRMspSelectInternalMessageById(result27, defLangID, defLangID));
							if (cRMspSelectInternalMessageById_Result != null)
							{
								cRMspSelectInternalMessageById_Result.msgBody = cRMspSelectInternalMessageById_Result.msgBody + "\r\n\r\n--------------------------------\r\n" + Messages.IntyMsgErrorSendFileAttache;
								dbI.CRMspUpdateInternalMessageBody(cRMspSelectInternalMessageById_Result.InternalMessageID, cRMspSelectInternalMessageById_Result.msgBody);
							}
						}
						int num9 = 0;
						if (list12 != null && Enumerable.Any<CRMspIntMsgSelectMessageFiles_Result>((IEnumerable<CRMspIntMsgSelectMessageFiles_Result>)list12))
						{
							num9 = Enumerable.Count<CRMspIntMsgSelectMessageFiles_Result>((IEnumerable<CRMspIntMsgSelectMessageFiles_Result>)list12);
						}
						if (num9 > 0)
						{
							dbI.CRMspUpdateInternalMessageAttachFileCount(result27, num9);
						}
					}
					string fromUserId = UserLogin.CurrentUser.UserId.ToString();
					string fromUserName = UserLogin.CurrentUser.FullName ?? "";
					string text33 = "";
					string message = newMessage.msgBody ?? "";
					text33 = newMessage.IntMsgReceivers ?? "";
					if (!string.IsNullOrWhiteSpace(text33) && text33.EndsWith(","))
					{
						text33 = text33.TrimEnd(new char[1] { ',' });
					}
					ChatHub.SendWinNotifyToUser(fromUserId, fromUserName, text33, message);
					PushNotif.NewIntMsgNotify();
					if (newMessage.CompanyId > 0)
					{
						Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
						dictionary2.Add("Title", text29);
						dictionary2.Add("Message", text28);
						dictionary2.Add("MessageType", "InternalMsg");
						PushNotif.NewIntMsgNotifyToCompany(newMessage.CompanyId, dictionary2);
					}
				}
			}
		}
		catch (DbEntityValidationException ex)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
			text = Messages.frmErrorMessage + "<br />" + ((Exception)(object)ex).Message;
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			text = Messages.frmErrorMessage + "<br />" + ex2.Message;
		}
		goto IL_460b;
		IL_460b:
		bool prjFoCmpCanSee = false;
		bool prjIsTicket = false;
		bool prjTicketStop = false;
		GetCnvsLastStatus(newMessage.CompanyId, newMessage.ProjectId, ref prjFoCmpCanSee, ref prjIsTicket, ref prjTicketStop, num2);
		base.ViewBag.Error = text;
		return View(newMessage);
	}

	[AjaxOnly]
	public JsonResult GetInternalMessageNewInfo()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		LoadIntMsgInfoDataEntryViewModel loadIntMsgInfoDataEntryViewModel = new LoadIntMsgInfoDataEntryViewModel();
		loadIntMsgInfoDataEntryViewModel.InternalMessageDefaultContext = new CRMspSelectInternalMessageDefaultContext_Result();
		try
		{
			loadIntMsgInfoDataEntryViewModel.InternalMessageDefaultContext = GetInternalMessageDefaultContext();
			if (loadIntMsgInfoDataEntryViewModel.InternalMessageDefaultContext == null)
			{
				loadIntMsgInfoDataEntryViewModel.InternalMessageDefaultContext = new CRMspSelectInternalMessageDefaultContext_Result();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(loadIntMsgInfoDataEntryViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetInternalMessageNewDefaultContext()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		CRMspSelectInternalMessageDefaultContext_Result cRMspSelectInternalMessageDefaultContext_Result = new CRMspSelectInternalMessageDefaultContext_Result();
		try
		{
			cRMspSelectInternalMessageDefaultContext_Result = GetInternalMessageDefaultContext();
			if (cRMspSelectInternalMessageDefaultContext_Result == null)
			{
				cRMspSelectInternalMessageDefaultContext_Result = new CRMspSelectInternalMessageDefaultContext_Result();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(cRMspSelectInternalMessageDefaultContext_Result, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	private void FillDropdownIntMsg()
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
			List<CRMspSelectInternalMessagePriority_Result> list3 = Enumerable.ToList<CRMspSelectInternalMessagePriority_Result>((IEnumerable<CRMspSelectInternalMessagePriority_Result>)db.CRMspSelectInternalMessagePriority(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectInternalMessagePriority_Result, SelectListItem>((IEnumerable<CRMspSelectInternalMessagePriority_Result>)list3, (Func<CRMspSelectInternalMessagePriority_Result, SelectListItem>)((CRMspSelectInternalMessagePriority_Result item) => new SelectListItem
			{
				Text = item.InternalMessagePriority,
				Value = item.InternalMessagePriorityID.ToString(),
				Selected = false
			})));
			list2 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectInternalMessageGroup_Result, SelectListItem>((IEnumerable<CRMspSelectInternalMessageGroup_Result>)Enumerable.ToList<CRMspSelectInternalMessageGroup_Result>((IEnumerable<CRMspSelectInternalMessageGroup_Result>)db.CRMspSelectInternalMessageGroup(lCID, result)), (Func<CRMspSelectInternalMessageGroup_Result, SelectListItem>)((CRMspSelectInternalMessageGroup_Result item) => new SelectListItem
			{
				Text = item.InternalMessageGroup,
				Value = item.InternalMessageGroupID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.IntMsgPriorityList = list;
		base.ViewBag.IntMsgGroupList = list2;
	}

	[AjaxOnly]
	public JsonResult GetIntMsgPriority()
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
			list = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspSelectInternalMessagePriority_Result, CrmDroupDownItem>((IEnumerable<CRMspSelectInternalMessagePriority_Result>)Enumerable.ToList<CRMspSelectInternalMessagePriority_Result>((IEnumerable<CRMspSelectInternalMessagePriority_Result>)db.CRMspSelectInternalMessagePriority(lCID, result)), (Func<CRMspSelectInternalMessagePriority_Result, CrmDroupDownItem>)((CRMspSelectInternalMessagePriority_Result item) => new CrmDroupDownItem
			{
				text = item.InternalMessagePriority,
				value = item.InternalMessagePriorityID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.IntMsgPriorityList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public void GetCnvsLastStatus(int cmpId, int prjId, ref bool prjFoCmpCanSee, ref bool prjIsTicket, ref bool prjTicketStop, int? cId = 0)
	{
		prjFoCmpCanSee = false;
		prjIsTicket = false;
		prjTicketStop = false;
		if (cmpId > 0 && prjId > 0)
		{
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				CRMspSelectInternalMessageConversationLastStatus_Result cRMspSelectInternalMessageConversationLastStatus_Result = Enumerable.FirstOrDefault<CRMspSelectInternalMessageConversationLastStatus_Result>((IEnumerable<CRMspSelectInternalMessageConversationLastStatus_Result>)db.CRMspSelectInternalMessageConversationLastStatus(cmpId, prjId, lCID, result));
				if (cRMspSelectInternalMessageConversationLastStatus_Result != null)
				{
					base.ViewBag.CmpName = cRMspSelectInternalMessageConversationLastStatus_Result.CompanyName;
					base.ViewBag.PrjTitle = cRMspSelectInternalMessageConversationLastStatus_Result.prjTitle;
					base.ViewBag.LastStatus = cRMspSelectInternalMessageConversationLastStatus_Result.Status;
					base.ViewBag.ReferUser = cRMspSelectInternalMessageConversationLastStatus_Result.cnvsReferUser;
					int.TryParse(cRMspSelectInternalMessageConversationLastStatus_Result.prjcnvsStatusGroupId.ToString(), out var result2);
					int.TryParse(cRMspSelectInternalMessageConversationLastStatus_Result.cnvsStatusId.ToString(), out var result3);
					GetCnvsStatusInternalMessage(result2, result3);
					int.TryParse(cRMspSelectInternalMessageConversationLastStatus_Result.cnvsPersonId.ToString(), out var result4);
					GetCnvsPerson(cmpId, result4, cId);
					int.TryParse(cRMspSelectInternalMessageConversationLastStatus_Result.cnvsTopicId.ToString(), out var result5);
					GetCnvsTopic(result5);
					GetCnvsReferUser(cmpId, cId);
					GetCnvsUser(cId);
					bool.TryParse(cRMspSelectInternalMessageConversationLastStatus_Result.prjFOCmpCanSee.ToString(), out prjFoCmpCanSee);
					bool.TryParse(cRMspSelectInternalMessageConversationLastStatus_Result.prjIsTicket.ToString(), out prjIsTicket);
					bool.TryParse(cRMspSelectInternalMessageConversationLastStatus_Result.prjTicketStop.ToString(), out prjTicketStop);
				}
				else
				{
					List<SelectListItem> list = new List<SelectListItem>();
					if (cmpId <= 0 || prjId <= 0)
					{
						base.ViewBag.CnvsReferUserList = list;
						base.ViewBag.CnvsUserList = list;
						base.ViewBag.CnvsTopicList = list;
						base.ViewBag.CnvsPersonList = list;
						base.ViewBag.CnvsStatusList = list;
						base.ViewBag.CnvsStatusProgresslist = list;
						base.ViewBag.CmpName = "";
						base.ViewBag.PrjTitle = "";
					}
					else
					{
						CRMspSelectCrmProjectsById_Result cRMspSelectCrmProjectsById_Result = Enumerable.FirstOrDefault<CRMspSelectCrmProjectsById_Result>((IEnumerable<CRMspSelectCrmProjectsById_Result>)db.CRMspSelectCrmProjectsById(prjId, lCID, result));
						int? num = null;
						if (cRMspSelectCrmProjectsById_Result != null)
						{
							base.ViewBag.CmpName = cRMspSelectCrmProjectsById_Result.prjCompany;
							base.ViewBag.PrjTitle = cRMspSelectCrmProjectsById_Result.prjTitle;
							num = cRMspSelectCrmProjectsById_Result.prjcnvsStatusGroupId;
						}
						else
						{
							base.ViewBag.CmpName = CRMIdeal.Classes.Helper.Company.GetCompanyName(cmpId);
							base.ViewBag.PrjTitle = CRMIdeal.Classes.Helper.Company.GetCmpProjectTitle(prjId);
							num = 0;
						}
						GetCnvsReferUser(cmpId, cId);
						GetCnvsUser(cId);
						GetCnvsTopic(0);
						GetCnvsPerson(cmpId, 0, cId);
						GetCnvsStatusInternalMessage(num.GetValueOrDefault(), 0);
					}
					base.ViewBag.LastStatus = "";
					base.ViewBag.ReferUser = "";
				}
				return;
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				return;
			}
		}
		List<SelectListItem> list2 = new List<SelectListItem>();
		base.ViewBag.CnvsPersonList = list2;
		base.ViewBag.CnvsStatusList = list2;
		base.ViewBag.CnvsStatusProgresslist = list2;
		base.ViewBag.CnvsReferUserList = list2;
		base.ViewBag.CnvsUserList = list2;
		base.ViewBag.CnvsTopicList = list2;
		base.ViewBag.CmpName = "";
		base.ViewBag.PrjTitle = "";
		base.ViewBag.LastStatus = "";
		base.ViewBag.ReferUser = "";
	}

	[AjaxOnly]
	public JsonResult GetCnvsTopic(int cnvsTopicId)
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
			List<CRMspSelectConversationTopics_Result> list2 = Enumerable.ToList<CRMspSelectConversationTopics_Result>((IEnumerable<CRMspSelectConversationTopics_Result>)db.CRMspSelectConversationTopics(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectConversationTopics_Result, SelectListItem>((IEnumerable<CRMspSelectConversationTopics_Result>)list2, (Func<CRMspSelectConversationTopics_Result, SelectListItem>)((CRMspSelectConversationTopics_Result item) => new SelectListItem
			{
				Text = item.Topic,
				Value = item.ConversationTopicsID.ToString(),
				Selected = (item.ConversationTopicsID == cnvsTopicId)
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CnvsTopicList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCnvsPerson(int cmpId, int cnvsPersonId, int? cId = 0)
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
			if (cId.GetValueOrDefault() != 0)
			{
				result2 = cId.GetValueOrDefault();
			}
			foreach (CRMspSelectConversationCompanyPersons_Result item in Enumerable.ToList<CRMspSelectConversationCompanyPersons_Result>((IEnumerable<CRMspSelectConversationCompanyPersons_Result>)db.CRMspSelectConversationCompanyPersons(cmpId, lCID, result, UserLogin.CurrentUser.UserId, result2)))
			{
				list.Add(new SelectListItem
				{
					Text = ((!string.IsNullOrEmpty(item.prsLName)) ? item.prsLName : "") + ((!string.IsNullOrEmpty(item.prsFName)) ? (" |" + Labels.prsFName + ": " + item.prsFName) : "") + ((!string.IsNullOrEmpty(item.Job)) ? (" |" + Labels.PrsJob + ": " + item.Job) : "") + ((!string.IsNullOrEmpty(item.Departman)) ? (" |" + Labels.PrsDepartment + ": " + item.Departman) : ""),
					Value = item.CompanyPersonID.ToString(),
					Selected = (item.CompanyPersonID == cnvsPersonId)
				});
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CnvsPersonList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCnvsStatusInternalMessage(int groupId, int cnvsStatusId)
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
			List<CRMspSelectActiveConversationStatus_Result> list3 = Enumerable.ToList<CRMspSelectActiveConversationStatus_Result>((IEnumerable<CRMspSelectActiveConversationStatus_Result>)_dbI.CRMspSelectActiveConversationStatus(groupId, lCID, result));
			foreach (CRMspSelectActiveConversationStatus_Result item in list3)
			{
				list.Add(new SelectListItem
				{
					Text = ((!string.IsNullOrEmpty(item.Status)) ? item.Status : "") + (item.ProgressPercent.HasValue ? (" |" + Labels.cnvsPercentStatus + ": " + item.ProgressPercent) : "") + ((!string.IsNullOrEmpty(item.StatusDesc)) ? (" |" + Labels.cnvsDescStatus + ": " + item.StatusDesc) : ""),
					Value = item.ConversationStatusID.ToString(),
					Selected = (item.ConversationStatusID == cnvsStatusId)
				});
			}
			if (list3 != null)
			{
				list2 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectActiveConversationStatus_Result, SelectListItem>((IEnumerable<CRMspSelectActiveConversationStatus_Result>)list3, (Func<CRMspSelectActiveConversationStatus_Result, SelectListItem>)((CRMspSelectActiveConversationStatus_Result item) => new SelectListItem
				{
					Text = item.ProgressPercent.GetValueOrDefault() + "|" + item.GroupId.GetValueOrDefault() + "|" + item.ProcessKindId.GetValueOrDefault() + "|" + item.SendInCnvsAllarmDate.GetValueOrDefault(),
					Value = item.ConversationStatusID.ToString(),
					Selected = false
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CnvsStatusList = list;
		base.ViewBag.CnvsStatusProgresslist = list2;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCnvsUser(int? cId = 0)
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
			if (cId.GetValueOrDefault() != 0)
			{
				result2 = cId.GetValueOrDefault();
			}
			List<CRMspSelectUserForLinkedType_Result> list2 = Enumerable.ToList<CRMspSelectUserForLinkedType_Result>((IEnumerable<CRMspSelectUserForLinkedType_Result>)db.CRMspSelectUserForLinkedType(UserLogin.CurrentUser.UserId, 8, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectUserForLinkedType_Result, SelectListItem>((IEnumerable<CRMspSelectUserForLinkedType_Result>)list2, (Func<CRMspSelectUserForLinkedType_Result, SelectListItem>)((CRMspSelectUserForLinkedType_Result item) => new SelectListItem
			{
				Text = item.UserName,
				Value = item.LinkedUserId.ToString(),
				Selected = (item.LinkedUserId == UserLogin.CurrentUser.UserId)
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CnvsUserList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCnvsReferUser(int cmpId, int? cId = 0)
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
			if (cId.GetValueOrDefault() != 0)
			{
				result2 = cId.GetValueOrDefault();
			}
			List<CRMspSelectUserForCnvsReferToUser_Result> list2 = Enumerable.ToList<CRMspSelectUserForCnvsReferToUser_Result>((IEnumerable<CRMspSelectUserForCnvsReferToUser_Result>)db.CRMspSelectUserForCnvsReferToUser(UserLogin.CurrentUser.UserId, 7, cmpId, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectUserForCnvsReferToUser_Result, SelectListItem>((IEnumerable<CRMspSelectUserForCnvsReferToUser_Result>)list2, (Func<CRMspSelectUserForCnvsReferToUser_Result, SelectListItem>)((CRMspSelectUserForCnvsReferToUser_Result item) => new SelectListItem
			{
				Text = item.UserName,
				Value = item.LinkedUserId.ToString(),
				Selected = (item.LinkedUserId == UserLogin.CurrentUser.UserId)
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
	public string GetUsersTitle()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		try
		{
			return Enumerable.FirstOrDefault<string>((IEnumerable<string>)Enumerable.ToList<string>((IEnumerable<string>)db.CRMspInternalMessageMakeAllReceiverTogether(1, UserLogin.CurrentUser.UserId, 0, 0, lCID, result)));
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			return "-1";
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			return "-1";
		}
	}

	public CRMspSelectInternalMessageDefaultContext_Result GetInternalMessageDefaultContext()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CRMspSelectInternalMessageDefaultContext_Result result2 = new CRMspSelectInternalMessageDefaultContext_Result();
		try
		{
			result2 = Enumerable.FirstOrDefault<CRMspSelectInternalMessageDefaultContext_Result>((IEnumerable<CRMspSelectInternalMessageDefaultContext_Result>)db.CRMspSelectInternalMessageDefaultContext(UserLogin.CurrentUser.UserId, lCID, result));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result2;
	}

	[AjaxOnly]
	public ActionResult _PartialCInternalMessageDefaultContext()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		CRMspSelectInternalMessageDefaultContext_Result cRMspSelectInternalMessageDefaultContext_Result = new CRMspSelectInternalMessageDefaultContext_Result();
		try
		{
			cRMspSelectInternalMessageDefaultContext_Result = GetInternalMessageDefaultContext();
			if (cRMspSelectInternalMessageDefaultContext_Result == null)
			{
				cRMspSelectInternalMessageDefaultContext_Result = new CRMspSelectInternalMessageDefaultContext_Result();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView(cRMspSelectInternalMessageDefaultContext_Result);
	}

	public ActionResult _PartialCInternalMessageAttachFile(int msgTypeId, string sendMode)
	{
		base.ViewBag.msgTypeId = msgTypeId;
		return PartialView();
	}

	public ActionResult CInternalMessageAttachFile_Read([DataSourceRequest] DataSourceRequest request, int msgTypeId)
	{
		List<CRMspSelectFilesDirectoryTemplateByTypeAndUser_Result> enumerable = new List<CRMspSelectFilesDirectoryTemplateByTypeAndUser_Result>();
		try
		{
			if (msgTypeId != 0)
			{
				enumerable = Enumerable.ToList<CRMspSelectFilesDirectoryTemplateByTypeAndUser_Result>((IEnumerable<CRMspSelectFilesDirectoryTemplateByTypeAndUser_Result>)_dbI.CRMspSelectFilesDirectoryTemplateByTypeAndUser(1, UserLogin.CurrentUser.UserId));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public JsonResult GetInternalMessageAttachFile(int msgTypeId)
	{
		List<CRMspSelectFilesDirectoryTemplateByTypeAndUser_Result> data = new List<CRMspSelectFilesDirectoryTemplateByTypeAndUser_Result>();
		try
		{
			if (msgTypeId != 0)
			{
				data = Enumerable.ToList<CRMspSelectFilesDirectoryTemplateByTypeAndUser_Result>((IEnumerable<CRMspSelectFilesDirectoryTemplateByTypeAndUser_Result>)_dbI.CRMspSelectFilesDirectoryTemplateByTypeAndUser(msgTypeId, UserLogin.CurrentUser.UserId));
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

	public ActionResult CInternalMessageAttachFile(int msgTypeId, string saveParameter, string msgReceiver)
	{
		return View();
	}

	[ValidateAntiForgeryToken]
	public ActionResult ActAttachFile(HttpPostedFileBase[] attachFileUrlUpload)
	{
		string text = "";
		try
		{
			if (attachFileUrlUpload != null)
			{
				bool flag = false;
				int maxFileCount = Configuration.MaxFileCount;
				if (attachFileUrlUpload.Length > maxFileCount)
				{
					string msgErrorMessageMaxSizeFile = Messages.msgErrorMessageMaxSizeFile;
					base.ModelState.AddModelError("error", string.Format(msgErrorMessageMaxSizeFile, maxFileCount));
					flag = true;
					text = string.Format(msgErrorMessageMaxSizeFile, maxFileCount) + "<br>";
				}
				HttpPostedFileBase[] array = attachFileUrlUpload;
				foreach (HttpPostedFileBase val in array)
				{
					val.ContentType.ToLower();
					object obj = ((val.FileName != null) ? Path.GetExtension(val.FileName).ToLower() : "");
					string arg = val.FileName ?? "";
					if (obj == null)
					{
						obj = "";
					}
					string text2 = ((string)obj).ToLower();
					text2 = text2.Replace(".", "");
					if (Configuration.MaliciousFileExtensions.Contains(text2))
					{
						flag = true;
						text = text + string.Format(Messages.msgErrorNotUploadFileByDue, arg) + Messages.msgErrorFileIsExecuted + "<br>";
					}
					int num = Configuration.MaxFileSizeForUploadMb * 1024 * 1024;
					if (val.ContentLength > num)
					{
						string fileFormatByteSize = CRM.General.IO.File.GetFileFormatByteSize(val.ContentLength);
						string fileFormatByteSize2 = CRM.General.IO.File.GetFileFormatByteSize(num);
						string msgErrorMessageMaxSizeFile2 = Messages.msgErrorMessageMaxSizeFile;
						flag = true;
						text = text + string.Format(Messages.msgErrorNotUploadFileByDue, arg) + string.Format(msgErrorMessageMaxSizeFile2, fileFormatByteSize, fileFormatByteSize2) + "<br>";
					}
				}
				if (flag)
				{
					return Content(text);
				}
				int userId = UserLogin.CurrentUser.UserId;
				string appType = Configuration.AppType;
				array = attachFileUrlUpload;
				foreach (HttpPostedFileBase val2 in array)
				{
					val2.ContentType.ToLower();
					Path.GetExtension(val2.FileName).ToLower();
					string text3 = Configuration.HostTempFilesPath + "/" + Configuration.IntmsgDirectoryPath;
					string text4 = base.Server.MapPath(text3);
					if (!System.IO.Directory.Exists(text4))
					{
						System.IO.Directory.CreateDirectory(text4);
						CRM.General.IO.Directory.SetFullControlForEveryOne(text4);
					}
					string text5 = base.Server.MapPath(text3 + userId + "/");
					if (!System.IO.Directory.Exists(text5))
					{
						System.IO.Directory.CreateDirectory(text5);
						CRM.General.IO.Directory.SetFullControlForEveryOne(text5);
					}
					string text6 = Path.GetFileName(val2.FileName);
					if (text6 != null && text6.Length < Configuration.FileDirectoryTitleLength)
					{
						string text7 = Path.Combine(text5, text6);
						if (System.IO.File.Exists(text7))
						{
							text6 = DateTime.Now.ToString("yyyyMMdd-HHmmss") + "-" + text6;
							text7 = Path.Combine(text5, text6);
						}
						val2.SaveAs(text7);
						CrmFilesDirectoryTemplate crmFilesDirectoryTemplate = new CrmFilesDirectoryTemplate();
						crmFilesDirectoryTemplate.UserId = userId;
						crmFilesDirectoryTemplate.TypeId = 1;
						crmFilesDirectoryTemplate.Title = text6;
						crmFilesDirectoryTemplate.CopyFromPath = text7;
						crmFilesDirectoryTemplate.AppType = appType;
						crmFilesDirectoryTemplate.GUId = System.Guid.NewGuid();
						_dbTbl.CrmFilesDirectoryTemplate.Add(crmFilesDirectoryTemplate);
						_dbTbl.SaveChanges();
					}
					else
					{
						text = text + Messages.IntmsgErrorLengthFileName + "|";
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Content(text);
	}

	public string ActRemoveFile(int fileId)
	{
		string result = "-1";
		CrmFilesDirectoryTemplate crmFilesDirectoryTemplate = _dbTbl.CrmFilesDirectoryTemplate.Find(fileId);
		if (crmFilesDirectoryTemplate != null)
		{
			try
			{
				string text = Configuration.HostTempFilesPath + "/" + Configuration.IntmsgDirectoryPath;
				string text2 = base.Server.MapPath(text + UserLogin.CurrentUser.UserId + "/");
				if (System.IO.Directory.Exists(text2))
				{
					string fileName = Path.GetFileName(crmFilesDirectoryTemplate.Title);
					string path = text2 + fileName;
					if (System.IO.File.Exists(path))
					{
						System.IO.File.Delete(path);
					}
				}
				_dbTbl.CrmFilesDirectoryTemplate.Remove(crmFilesDirectoryTemplate);
				_dbTbl.SaveChanges();
				result = Messages.frmDeleteSuccessMessage;
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
		}
		return result;
	}

	public string ActRemoveFileCnvs(int fileId)
	{
		string result = "-1";
		CrmFilesDirectoryTemplate crmFilesDirectoryTemplate = _dbTbl.CrmFilesDirectoryTemplate.Find(fileId);
		if (crmFilesDirectoryTemplate != null)
		{
			try
			{
				string text = Configuration.HostTempFilesPath + "/" + Configuration.CnvsDirectoryPath;
				string text2 = base.Server.MapPath(text + UserLogin.CurrentUser.UserId + "/");
				if (System.IO.Directory.Exists(text2))
				{
					string fileName = Path.GetFileName(crmFilesDirectoryTemplate.Title);
					string path = text2 + fileName;
					if (System.IO.File.Exists(path))
					{
						System.IO.File.Delete(path);
					}
				}
				_dbTbl.CrmFilesDirectoryTemplate.Remove(crmFilesDirectoryTemplate);
				_dbTbl.SaveChanges();
				result = Messages.frmDeleteSuccessMessage;
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
		}
		return result;
	}

	public FileResult GetFilesDirectoryTemplate(int fdtId)
	{
		CrmFilesDirectoryTemplate crmFilesDirectoryTemplate = _dbTbl.CrmFilesDirectoryTemplate.Find(fdtId);
		string text = "";
		if (crmFilesDirectoryTemplate != null)
		{
			text = crmFilesDirectoryTemplate.CopyFromPath;
			if (!string.IsNullOrWhiteSpace(text) && text.IndexOf("FileDirectoryID:") >= 0)
			{
				string[] array = text.Split(new char[1] { ':' });
				if (array != null && array.Length >= 2)
				{
					int result = 0;
					int.TryParse(array[1], out result);
					if (result != 0)
					{
						text = new CompanyInfoController().GetFilePath(result, idUrlEncode: false);
					}
				}
			}
		}
		string mimeMapping = MimeMapping.GetMimeMapping(text);
		return File(text, mimeMapping);
	}

	[AjaxOnly]
	public int RunCnvsEventPolicyForSms(int cnvsId, int statusId, int prjId, int cmpId, int prsId, bool eventPolicyNeedCheck, int? cId = 0)
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
				short value = short.Parse(now.ToString("yyyy", new PersianCulture()));
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				ObjectParameter objectParameter = new ObjectParameter("Result", 0);
				int? centerId = null;
				if (UserLogin.CurrentUser != null)
				{
					centerId = UserLogin.CurrentUser.UserLastCId;
				}
				if (cId.GetValueOrDefault() != 0)
				{
					centerId = cId;
				}
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
	public int RunCnvsEventPolicyForEmail(int cnvsId, int statusId, int prjId, int cmpId, int prsId, bool eventPolicyNeedCheck, int? cId = 0)
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
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
				short value3 = short.Parse(now.ToString("MM", new PersianCulture()));
				int userId = UserLogin.CurrentUser.UserId;
				string appType = Configuration.AppType;
				int? centerId = null;
				if (UserLogin.CurrentUser != null)
				{
					centerId = UserLogin.CurrentUser.UserLastCId;
				}
				if (cId.GetValueOrDefault() != 0)
				{
					centerId = cId;
				}
				ObjectParameter objectParameter = new ObjectParameter("Result", 0);
				CRMSpIEntities cRMSpIEntities = _dbI;
				int? conversationID = cnvsId;
				int? conversationStatusID = statusId;
				int? cnvsProjectID = prjId;
				int? cnvsCompanyId = cmpId;
				int? cnvsPersonId = prsId;
				int? userID = userId;
				int? year = value2;
				int? month = value3;
				DateTime? registerDate = value;
				cRMSpIEntities.CRMspRunCnvsEventPolicyEmail(conversationID, conversationStatusID, cnvsProjectID, cnvsCompanyId, cnvsPersonId, userID, year, month, registerDatePersian, registerDate, appType, lCID, result2, eventPolicyNeedCheck, objectParameter, centerId);
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

	[DynamicAuthorize(ControllerName = "frmInternalMessageNew", ActionName = "actSelectReceiver")]
	public ActionResult CInternalMessageSelectReceiver(int msgTypeId, string saveParameter, string activeInCycle, int msgCId = 0)
	{
		if (msgTypeId == 12)
		{
			ActUnSelectAllExecute(msgTypeId);
		}
		base.ViewBag.SaveParameter = saveParameter;
		base.ViewBag.msgTypeId = msgTypeId;
		base.ViewBag.activeInCycle = activeInCycle;
		base.ViewBag.MsgCId = msgCId;
		return View();
	}

	public ActionResult _PartialCInternalMessageSelectReceiver(int msgTypeId, string activeInCycle)
	{
		base.ViewBag.msgTypeId = msgTypeId;
		base.ViewBag.activeInCycle = activeInCycle;
		return PartialView();
	}

	public ActionResult CInternalMessageSelectReceiver_Read([DataSourceRequest] DataSourceRequest request, int msgTypeId, string activeInCycle)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspIntMsgSelectReceiverViewModel> list = new List<CRMspIntMsgSelectReceiverViewModel>();
		try
		{
			if (msgTypeId != 0)
			{
				List<CRMspIntMsgSelectReceiver_Result> list2 = new List<CRMspIntMsgSelectReceiver_Result>();
				if (string.CompareOrdinal(activeInCycle, "true") == 0)
				{
					ActUnSelectExecute(UserLogin.CurrentUser.UserId, msgTypeId);
					list2 = Enumerable.ToList<CRMspIntMsgSelectReceiver_Result>(Enumerable.Where<CRMspIntMsgSelectReceiver_Result>((IEnumerable<CRMspIntMsgSelectReceiver_Result>)db.CRMspIntMsgSelectReceiver(UserLogin.CurrentUser.UserId, msgTypeId, lCID, result), (Func<CRMspIntMsgSelectReceiver_Result, bool>)((CRMspIntMsgSelectReceiver_Result c) => c.UserId != c.crmUserId)));
				}
				else
				{
					list2 = Enumerable.ToList<CRMspIntMsgSelectReceiver_Result>((IEnumerable<CRMspIntMsgSelectReceiver_Result>)db.CRMspIntMsgSelectReceiver(UserLogin.CurrentUser.UserId, msgTypeId, lCID, result));
				}
				foreach (CRMspIntMsgSelectReceiver_Result item in list2)
				{
					CRMspIntMsgSelectReceiverViewModel cRMspIntMsgSelectReceiverViewModel = new CRMspIntMsgSelectReceiverViewModel();
					cRMspIntMsgSelectReceiverViewModel.crmUserId = item.crmUserId;
					cRMspIntMsgSelectReceiverViewModel.Selector = item.Selector;
					cRMspIntMsgSelectReceiverViewModel.UserId = item.UserId;
					cRMspIntMsgSelectReceiverViewModel.Val = item.Val;
					list.Add(cRMspIntMsgSelectReceiverViewModel);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)list).ToDataSourceResult(request));
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public void ActUnSelectAllExecute(int msgTypeId)
	{
		try
		{
			db.CRMspIntMsgUpdateSelectReceiver(UserLogin.CurrentUser.UserId.ToString(), "0", false, 3);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	public void ActSelectAllExecute(int msgTypeId)
	{
		try
		{
			if (msgTypeId == 12)
			{
				db.CRMspIntMsgUpdateSelectReceiver(UserLogin.CurrentUser.UserId.ToString(), UserLogin.CurrentUser.UserId.ToString(), true, 2);
			}
			else
			{
				db.CRMspIntMsgUpdateSelectReceiver(UserLogin.CurrentUser.UserId.ToString(), "0", true, 3);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	public void ActSelectExecute(int userId, int msgTypeId)
	{
		_003C_003Ec__DisplayClass218_0 _003C_003Ec__DisplayClass218_ = new _003C_003Ec__DisplayClass218_0();
		_003C_003Ec__DisplayClass218_.userId = userId;
		try
		{
			DbSet<CrmInternalMessageSelectReceiver> crmInternalMessageSelectReceiver = _dbTbl.CrmInternalMessageSelectReceiver;
			ParameterExpression val = Expression.Parameter(typeof(CrmInternalMessageSelectReceiver), "c");
			CrmInternalMessageSelectReceiver crmInternalMessageSelectReceiver2 = Queryable.First<CrmInternalMessageSelectReceiver>((IQueryable<CrmInternalMessageSelectReceiver>)crmInternalMessageSelectReceiver, Expression.Lambda<Func<CrmInternalMessageSelectReceiver, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Property((Expression)null, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass218_, typeof(_003C_003Ec__DisplayClass218_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			crmInternalMessageSelectReceiver2.Selector = true;
			crmInternalMessageSelectReceiver2.AppType = Configuration.AppType;
			_dbTbl.Entry(crmInternalMessageSelectReceiver2).State = EntityState.Modified;
			_dbTbl.SaveChanges();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	public void ActUnSelectExecute(int userId, int msgTypeId)
	{
		_003C_003Ec__DisplayClass219_0 _003C_003Ec__DisplayClass219_ = new _003C_003Ec__DisplayClass219_0();
		_003C_003Ec__DisplayClass219_.userId = userId;
		try
		{
			DbSet<CrmInternalMessageSelectReceiver> crmInternalMessageSelectReceiver = _dbTbl.CrmInternalMessageSelectReceiver;
			ParameterExpression val = Expression.Parameter(typeof(CrmInternalMessageSelectReceiver), "c");
			CrmInternalMessageSelectReceiver crmInternalMessageSelectReceiver2 = Queryable.First<CrmInternalMessageSelectReceiver>((IQueryable<CrmInternalMessageSelectReceiver>)crmInternalMessageSelectReceiver, Expression.Lambda<Func<CrmInternalMessageSelectReceiver, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Property((Expression)null, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass219_, typeof(_003C_003Ec__DisplayClass219_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			crmInternalMessageSelectReceiver2.Selector = false;
			crmInternalMessageSelectReceiver2.AppType = Configuration.AppType;
			_dbTbl.Entry(crmInternalMessageSelectReceiver2).State = EntityState.Modified;
			_dbTbl.SaveChanges();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	[AjaxOnly]
	public JsonResult GetCInternalMessageSelectReceiver(int msgTypeId, string activeInCycle)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiSelectorViewModel> list = new List<CommonMultiSelectorViewModel>();
		try
		{
			int userId = UserLogin.CurrentUser.UserId;
			if (msgTypeId != 0)
			{
				List<CRMspIntMsgSelectReceiver_Result> list2 = new List<CRMspIntMsgSelectReceiver_Result>();
				if (string.CompareOrdinal(activeInCycle, "true") == 0)
				{
					db.CRMspIntMsgUpdateSelectReceiver(userId.ToString(), userId.ToString(), false, 1);
					list2 = Enumerable.ToList<CRMspIntMsgSelectReceiver_Result>(Enumerable.Where<CRMspIntMsgSelectReceiver_Result>((IEnumerable<CRMspIntMsgSelectReceiver_Result>)db.CRMspIntMsgSelectReceiver(userId, msgTypeId, lCID, result), (Func<CRMspIntMsgSelectReceiver_Result, bool>)((CRMspIntMsgSelectReceiver_Result c) => c.UserId != c.crmUserId)));
				}
				else
				{
					list2 = Enumerable.ToList<CRMspIntMsgSelectReceiver_Result>((IEnumerable<CRMspIntMsgSelectReceiver_Result>)db.CRMspIntMsgSelectReceiver(userId, msgTypeId, lCID, result));
				}
				if (list2 != null && Enumerable.Any<CRMspIntMsgSelectReceiver_Result>((IEnumerable<CRMspIntMsgSelectReceiver_Result>)list2))
				{
					foreach (CRMspIntMsgSelectReceiver_Result item2 in list2)
					{
						CommonMultiSelectorViewModel item = new CommonMultiSelectorViewModel
						{
							Id = item2.UserId,
							Name = item2.Val,
							Selected = ((item2.Selector.HasValue && item2.Selector != false) ? true : false)
						};
						list.Add(item);
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

	public string UpdateInternalMessageSelectReceiver(int msgTypeId, string userIds)
	{
		string result = "0";
		try
		{
			int userId = UserLogin.CurrentUser.UserId;
			if (msgTypeId == 12)
			{
				dbI.CRMspIntMsgUpdateSelectReceiverByUserIds(userId, "", true, 2);
				db.CRMspIntMsgUpdateSelectReceiver(UserLogin.CurrentUser.UserId.ToString(), UserLogin.CurrentUser.UserId.ToString(), true, 2);
			}
			else
			{
				dbI.CRMspIntMsgUpdateSelectReceiverByUserIds(userId, userIds, true, 1);
			}
			result = "1";
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[AjaxOnly]
	public JsonResult GetIntMsgSelectReceiver(int msgTypeId, string activeInCycle, int? cId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspIntMsgSelectReceiverWeb_Result> list = new List<CRMspIntMsgSelectReceiverWeb_Result>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (cId.GetValueOrDefault() != 0)
			{
				result2 = cId.GetValueOrDefault();
			}
			int userId = UserLogin.CurrentUser.UserId;
			string noUserDepartmentTxt = Labels.NoUserDepartmentTxt;
			string noUserRollTxt = Labels.NoUserRollTxt;
			if (msgTypeId != 0)
			{
				new List<CRMspIntMsgSelectReceiver_Result>();
				if (string.CompareOrdinal(activeInCycle, "true") == 0)
				{
					db.CRMspIntMsgUpdateSelectReceiver(userId.ToString(), userId.ToString(), false, 1);
					list = Enumerable.ToList<CRMspIntMsgSelectReceiverWeb_Result>(Enumerable.Where<CRMspIntMsgSelectReceiverWeb_Result>((IEnumerable<CRMspIntMsgSelectReceiverWeb_Result>)_dbII.CRMspIntMsgSelectReceiverWeb(userId, msgTypeId, noUserDepartmentTxt, noUserRollTxt, lCID, result, result2), (Func<CRMspIntMsgSelectReceiverWeb_Result, bool>)((CRMspIntMsgSelectReceiverWeb_Result c) => c.UserId != c.crmUserId)));
				}
				else
				{
					list = Enumerable.ToList<CRMspIntMsgSelectReceiverWeb_Result>((IEnumerable<CRMspIntMsgSelectReceiverWeb_Result>)_dbII.CRMspIntMsgSelectReceiverWeb(userId, msgTypeId, noUserDepartmentTxt, noUserRollTxt, lCID, result, result2));
				}
				if (list != null)
				{
					if (Enumerable.Any<CRMspIntMsgSelectReceiverWeb_Result>((IEnumerable<CRMspIntMsgSelectReceiverWeb_Result>)list))
					{
						foreach (CRMspIntMsgSelectReceiverWeb_Result item in list)
						{
							item.Selector = item.Selector.GetValueOrDefault();
						}
					}
				}
				else
				{
					list = new List<CRMspIntMsgSelectReceiverWeb_Result>();
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

	[DynamicAuthorize(ControllerName = "frmInternalMessage", ActionName = "actViewMessage")]
	public ActionResult CInternalMessageView(int messageTypeId, int messageId, string fromPlase, int msgToUserId = 0)
	{
		if (messageTypeId == 1 || messageTypeId == 5 || messageTypeId == 6 || messageTypeId == 7 || messageTypeId == 8 || messageTypeId == 10 || messageTypeId == 12 || messageTypeId == 9 || messageTypeId == 14 || messageTypeId == 16 || messageTypeId == 45 || messageTypeId == 50 || messageTypeId == 55 || messageTypeId == 60 || messageTypeId == 17 || messageTypeId == 18 || messageTypeId == 19 || messageTypeId == 20 || messageTypeId == 21)
		{
			UpdateInternalMessage("Read", messageId, messageTypeId);
		}
		base.ViewBag.fromPlase = fromPlase;
		base.ViewBag.msgTypeId = messageTypeId;
		base.ViewBag.msgId = messageId;
		base.ViewBag.msgToUserId = msgToUserId;
		return View();
	}

	public ActionResult _PartialCInternalMessageView(int msgid, string kind, int msgTypeId, int fromPlase, int msgToUserId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CRMspIntMsgSelectMessageInTypeViewModel cRMspIntMsgSelectMessageInTypeViewModel = new CRMspIntMsgSelectMessageInTypeViewModel();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			msgToUserId = ((msgToUserId != 0) ? msgToUserId : UserLogin.CurrentUser.UserId);
			List<CRMspIntMsgSelectMessageInType_Result> list = Enumerable.ToList<CRMspIntMsgSelectMessageInType_Result>((IEnumerable<CRMspIntMsgSelectMessageInType_Result>)db.CRMspIntMsgSelectMessageInType(msgid, msgToUserId, msgTypeId, lCID, result, result2));
			CRMspIntMsgSelectMessageInType_Result cRMspIntMsgSelectMessageInType_Result = null;
			cRMspIntMsgSelectMessageInType_Result = ((msgid == 0) ? Enumerable.FirstOrDefault<CRMspIntMsgSelectMessageInType_Result>(Enumerable.Take<CRMspIntMsgSelectMessageInType_Result>((IEnumerable<CRMspIntMsgSelectMessageInType_Result>)Enumerable.OrderByDescending<CRMspIntMsgSelectMessageInType_Result, int>((IEnumerable<CRMspIntMsgSelectMessageInType_Result>)list, (Func<CRMspIntMsgSelectMessageInType_Result, int>)((CRMspIntMsgSelectMessageInType_Result c) => c.InternalMessageID)), 1)) : ((kind == "next") ? (Enumerable.FirstOrDefault<CRMspIntMsgSelectMessageInType_Result>(Enumerable.Take<CRMspIntMsgSelectMessageInType_Result>(Enumerable.Where<CRMspIntMsgSelectMessageInType_Result>((IEnumerable<CRMspIntMsgSelectMessageInType_Result>)list, (Func<CRMspIntMsgSelectMessageInType_Result, bool>)((CRMspIntMsgSelectMessageInType_Result c) => c.InternalMessageID > msgid)), 1)) ?? Enumerable.First<CRMspIntMsgSelectMessageInType_Result>(Enumerable.Take<CRMspIntMsgSelectMessageInType_Result>((IEnumerable<CRMspIntMsgSelectMessageInType_Result>)Enumerable.OrderByDescending<CRMspIntMsgSelectMessageInType_Result, int>((IEnumerable<CRMspIntMsgSelectMessageInType_Result>)list, (Func<CRMspIntMsgSelectMessageInType_Result, int>)((CRMspIntMsgSelectMessageInType_Result c) => c.InternalMessageID)), 1))) : ((!(kind == "prev")) ? Enumerable.FirstOrDefault<CRMspIntMsgSelectMessageInType_Result>((IEnumerable<CRMspIntMsgSelectMessageInType_Result>)list, (Func<CRMspIntMsgSelectMessageInType_Result, bool>)((CRMspIntMsgSelectMessageInType_Result c) => c.InternalMessageID == msgid)) : (Enumerable.FirstOrDefault<CRMspIntMsgSelectMessageInType_Result>(Enumerable.Take<CRMspIntMsgSelectMessageInType_Result>((IEnumerable<CRMspIntMsgSelectMessageInType_Result>)Enumerable.OrderByDescending<CRMspIntMsgSelectMessageInType_Result, int>(Enumerable.Where<CRMspIntMsgSelectMessageInType_Result>((IEnumerable<CRMspIntMsgSelectMessageInType_Result>)list, (Func<CRMspIntMsgSelectMessageInType_Result, bool>)((CRMspIntMsgSelectMessageInType_Result c) => c.InternalMessageID < msgid)), (Func<CRMspIntMsgSelectMessageInType_Result, int>)((CRMspIntMsgSelectMessageInType_Result c) => c.InternalMessageID)), 1)) ?? Enumerable.First<CRMspIntMsgSelectMessageInType_Result>(Enumerable.Take<CRMspIntMsgSelectMessageInType_Result>((IEnumerable<CRMspIntMsgSelectMessageInType_Result>)list, 1))))));
			if (cRMspIntMsgSelectMessageInType_Result == null)
			{
				cRMspIntMsgSelectMessageInType_Result = new CRMspIntMsgSelectMessageInType_Result
				{
					RegisterDate = DateTime.Now,
					InternalMessageID = 0,
					msgdReadDateTime = DateTime.Now,
					msgdReceiveDateTime = DateTime.Now,
					msgdSendDateTime = DateTime.Now
				};
			}
			else if (cRMspIntMsgSelectMessageInType_Result.msgdTypeId == 12)
			{
				UpdateInternalMessage("Read", cRMspIntMsgSelectMessageInType_Result.InternalMessageID, cRMspIntMsgSelectMessageInType_Result.msgdTypeId);
			}
			string text = "";
			if (cRMspIntMsgSelectMessageInType_Result.msgdTypeId == 12)
			{
				text = Enumerable.Aggregate<CRMspIntMsgSelectMessageInType_Result, string>((IEnumerable<CRMspIntMsgSelectMessageInType_Result>)list, text, (Func<string, CRMspIntMsgSelectMessageInType_Result, string>)((string current, CRMspIntMsgSelectMessageInType_Result msg) => current + Labels.FromUser + " : " + msg.FROMUser + "     -->  " + Labels.MsgPriority + " : " + msg.InternalMessagePriority + "-->" + Labels.MsgStatus + " :" + msg.InternalMessageGroup + Environment.NewLine + msg.msgBody + Environment.NewLine + Labels.EmailSendingDate + "   : " + msg.msgdSendDateTime.ToString() + Environment.NewLine + Labels.RSmsReceiveDate + "  :" + msg.msgdReceiveDateTime.ToString() + Environment.NewLine + Labels.MsgDateSeen + "     :" + msg.msgdReadDateTime.ToString() + Environment.NewLine + Labels.MsgReciveres + " :" + msg.ToAndOtherUser + Environment.NewLine + "------------------------------------------------------------------------" + Environment.NewLine));
			}
			cRMspIntMsgSelectMessageInTypeViewModel.InternalMessageID = cRMspIntMsgSelectMessageInType_Result.InternalMessageID;
			cRMspIntMsgSelectMessageInTypeViewModel.msgSubject = cRMspIntMsgSelectMessageInType_Result.msgSubject;
			cRMspIntMsgSelectMessageInTypeViewModel.msgBody = ((text != "") ? text : cRMspIntMsgSelectMessageInType_Result.msgBody);
			cRMspIntMsgSelectMessageInTypeViewModel.InternalMessageDetailID = cRMspIntMsgSelectMessageInType_Result.InternalMessageDetailID;
			cRMspIntMsgSelectMessageInTypeViewModel.msgdTypeId = cRMspIntMsgSelectMessageInType_Result.msgdTypeId;
			cRMspIntMsgSelectMessageInTypeViewModel.MessageType = cRMspIntMsgSelectMessageInType_Result.MessageType;
			cRMspIntMsgSelectMessageInTypeViewModel.msgMasterId = cRMspIntMsgSelectMessageInType_Result.msgMasterId;
			cRMspIntMsgSelectMessageInTypeViewModel.msgdFromUserId = cRMspIntMsgSelectMessageInType_Result.msgdFromUserId;
			cRMspIntMsgSelectMessageInTypeViewModel.FROMUser = cRMspIntMsgSelectMessageInType_Result.FROMUser;
			cRMspIntMsgSelectMessageInTypeViewModel.msgdToUserId = cRMspIntMsgSelectMessageInType_Result.msgdToUserId;
			cRMspIntMsgSelectMessageInTypeViewModel.ToUser = cRMspIntMsgSelectMessageInType_Result.ToUser;
			cRMspIntMsgSelectMessageInTypeViewModel.ToOtherUser = cRMspIntMsgSelectMessageInType_Result.ToOtherUser;
			cRMspIntMsgSelectMessageInTypeViewModel.ToAndOtherUser = cRMspIntMsgSelectMessageInType_Result.ToAndOtherUser;
			cRMspIntMsgSelectMessageInTypeViewModel.msgdSendDate = cRMspIntMsgSelectMessageInType_Result.msgdSendDate;
			cRMspIntMsgSelectMessageInTypeViewModel.msgdSendTime = cRMspIntMsgSelectMessageInType_Result.msgdSendTime;
			cRMspIntMsgSelectMessageInTypeViewModel.msgdSendDateTime = cRMspIntMsgSelectMessageInType_Result.msgdSendDateTime;
			cRMspIntMsgSelectMessageInTypeViewModel.SendDateTime = cRMspIntMsgSelectMessageInType_Result.SendDateTime;
			cRMspIntMsgSelectMessageInTypeViewModel.msgdReceiveDate = cRMspIntMsgSelectMessageInType_Result.msgdReceiveDate;
			cRMspIntMsgSelectMessageInTypeViewModel.msgdReceiveTime = cRMspIntMsgSelectMessageInType_Result.msgdReceiveTime;
			cRMspIntMsgSelectMessageInTypeViewModel.msgdReceiveDateTime = cRMspIntMsgSelectMessageInType_Result.msgdReceiveDateTime;
			cRMspIntMsgSelectMessageInTypeViewModel.ReceiveDateTime = cRMspIntMsgSelectMessageInType_Result.ReceiveDateTime;
			cRMspIntMsgSelectMessageInTypeViewModel.msgdIsRead = cRMspIntMsgSelectMessageInType_Result.msgdIsRead;
			cRMspIntMsgSelectMessageInTypeViewModel.msgdReadDate = cRMspIntMsgSelectMessageInType_Result.msgdReadDate;
			cRMspIntMsgSelectMessageInTypeViewModel.msgdReadDateTime = cRMspIntMsgSelectMessageInType_Result.msgdReadDateTime;
			cRMspIntMsgSelectMessageInTypeViewModel.msgdReadTime = cRMspIntMsgSelectMessageInType_Result.msgdReadTime;
			cRMspIntMsgSelectMessageInTypeViewModel.ReadDateTime = cRMspIntMsgSelectMessageInType_Result.ReadDateTime;
			cRMspIntMsgSelectMessageInTypeViewModel.msgdPriorityId = cRMspIntMsgSelectMessageInType_Result.msgdPriorityId;
			cRMspIntMsgSelectMessageInTypeViewModel.InternalMessagePriority = cRMspIntMsgSelectMessageInType_Result.InternalMessagePriority;
			cRMspIntMsgSelectMessageInTypeViewModel.msgdIsDraft = cRMspIntMsgSelectMessageInType_Result.msgdIsDraft;
			cRMspIntMsgSelectMessageInTypeViewModel.msgdIsDeleted = cRMspIntMsgSelectMessageInType_Result.msgdIsDeleted;
			cRMspIntMsgSelectMessageInTypeViewModel.msgdAttachFile = cRMspIntMsgSelectMessageInType_Result.msgdAttachFile;
			cRMspIntMsgSelectMessageInTypeViewModel.msgdAttachRecId = cRMspIntMsgSelectMessageInType_Result.msgdAttachRecId;
			string text2 = cRMspIntMsgSelectMessageInType_Result.msgdAttachRecDesc;
			if (!string.IsNullOrEmpty(text2) && cRMspIntMsgSelectMessageInType_Result.msgdTypeId != 16 && cRMspIntMsgSelectMessageInType_Result.msgdTypeId != 55 && cRMspIntMsgSelectMessageInType_Result.msgdTypeId != 17)
			{
				text2 = Messages.ConversationErjaShow;
			}
			cRMspIntMsgSelectMessageInTypeViewModel.msgdAttachRecTypeId = cRMspIntMsgSelectMessageInType_Result.msgdAttachRecTypeId;
			if (cRMspIntMsgSelectMessageInType_Result.msgdAttachRecTypeId.HasValue && (cRMspIntMsgSelectMessageInType_Result.msgdTypeId == 1 || cRMspIntMsgSelectMessageInType_Result.msgdTypeId == 2) && !string.IsNullOrEmpty(text2) && cRMspIntMsgSelectMessageInType_Result.msgdAttachRecTypeId > 0 && cRMspIntMsgSelectMessageInType_Result.msgdAttachRecTypeId.GetValueOrDefault() != 16 && cRMspIntMsgSelectMessageInType_Result.msgdAttachRecTypeId.GetValueOrDefault() != 55 && cRMspIntMsgSelectMessageInType_Result.msgdAttachRecTypeId.GetValueOrDefault() != 17)
			{
				text2 = Messages.ConversationErjaShow;
			}
			cRMspIntMsgSelectMessageInTypeViewModel.msgdAttachRecDesc = text2;
			cRMspIntMsgSelectMessageInTypeViewModel.DocNumber = cRMspIntMsgSelectMessageInType_Result.DocNumber;
			cRMspIntMsgSelectMessageInTypeViewModel.OprID = cRMspIntMsgSelectMessageInType_Result.OprID;
			cRMspIntMsgSelectMessageInTypeViewModel.CompanyID = cRMspIntMsgSelectMessageInType_Result.CompanyID;
			cRMspIntMsgSelectMessageInTypeViewModel.ProjectID = cRMspIntMsgSelectMessageInType_Result.ProjectID;
			cRMspIntMsgSelectMessageInTypeViewModel.msgdGroupId = cRMspIntMsgSelectMessageInType_Result.msgdGroupId;
			cRMspIntMsgSelectMessageInTypeViewModel.InternalMessageGroup = cRMspIntMsgSelectMessageInType_Result.InternalMessageGroup;
			cRMspIntMsgSelectMessageInTypeViewModel.UserId = cRMspIntMsgSelectMessageInType_Result.UserId;
			cRMspIntMsgSelectMessageInTypeViewModel.Year1 = cRMspIntMsgSelectMessageInType_Result.Year1;
			cRMspIntMsgSelectMessageInTypeViewModel.Month1 = cRMspIntMsgSelectMessageInType_Result.Month1;
			cRMspIntMsgSelectMessageInTypeViewModel.RegisterDate = cRMspIntMsgSelectMessageInType_Result.RegisterDate;
			cRMspIntMsgSelectMessageInTypeViewModel.RegisterDatePersian = cRMspIntMsgSelectMessageInType_Result.RegisterDatePersian;
			cRMspIntMsgSelectMessageInTypeViewModel.msgActiveInCycle = cRMspIntMsgSelectMessageInType_Result.msgActiveInCycle;
			cRMspIntMsgSelectMessageInTypeViewModel.msgLastGroupId = cRMspIntMsgSelectMessageInType_Result.msgLastGroupId;
			cRMspIntMsgSelectMessageInTypeViewModel.msgIsFinalised = cRMspIntMsgSelectMessageInType_Result.msgIsFinalised;
			cRMspIntMsgSelectMessageInTypeViewModel.msgdAttachRecIdI = cRMspIntMsgSelectMessageInType_Result.msgdAttachRecIdI;
			cRMspIntMsgSelectMessageInTypeViewModel.msgdAttachRecDescI = cRMspIntMsgSelectMessageInType_Result.msgdAttachRecDescI;
			base.ViewBag.msgTypeId = cRMspIntMsgSelectMessageInType_Result.msgdTypeId;
			base.ViewBag.fromPlase = fromPlase;
			base.ViewBag.intMsgId = cRMspIntMsgSelectMessageInType_Result.InternalMessageID;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView(cRMspIntMsgSelectMessageInTypeViewModel);
	}

	public ActionResult IntMsgIntMsgSelectMessageFiles_Read([DataSourceRequest] DataSourceRequest request, int intMsgId)
	{
		List<CRMspIntMsgSelectMessageFiles_Result> list = new List<CRMspIntMsgSelectMessageFiles_Result>();
		try
		{
			if (intMsgId == 0)
			{
				return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
			}
			foreach (CRMspIntMsgSelectMessageFiles_Result item in Enumerable.ToList<CRMspIntMsgSelectMessageFiles_Result>((IEnumerable<CRMspIntMsgSelectMessageFiles_Result>)db.CRMspIntMsgSelectMessageFiles(intMsgId)))
			{
				CRMspIntMsgSelectMessageFiles_Result cRMspIntMsgSelectMessageFiles_Result = new CRMspIntMsgSelectMessageFiles_Result();
				cRMspIntMsgSelectMessageFiles_Result.FileDirectoryID = item.FileDirectoryID;
				cRMspIntMsgSelectMessageFiles_Result.FileDirectoryTypeId = item.FileDirectoryTypeId;
				cRMspIntMsgSelectMessageFiles_Result.MasterId = item.MasterId;
				cRMspIntMsgSelectMessageFiles_Result.DetailId = item.DetailId;
				cRMspIntMsgSelectMessageFiles_Result.SubDetailId = item.SubDetailId;
				cRMspIntMsgSelectMessageFiles_Result.Title = item.Title;
				cRMspIntMsgSelectMessageFiles_Result.FolderName = item.FolderName;
				cRMspIntMsgSelectMessageFiles_Result.FileName = item.FileName;
				cRMspIntMsgSelectMessageFiles_Result.FilePath = item.FilePath;
				cRMspIntMsgSelectMessageFiles_Result.CopyFromPath = item.CopyFromPath;
				cRMspIntMsgSelectMessageFiles_Result.UserId = item.UserId;
				cRMspIntMsgSelectMessageFiles_Result.Year1 = item.Year1;
				cRMspIntMsgSelectMessageFiles_Result.Month1 = item.Month1;
				cRMspIntMsgSelectMessageFiles_Result.RegisterDate = item.RegisterDate;
				cRMspIntMsgSelectMessageFiles_Result.RegisterDatePersian = item.RegisterDatePersian;
				cRMspIntMsgSelectMessageFiles_Result.DocDate = item.DocDate;
				cRMspIntMsgSelectMessageFiles_Result.DocDay = item.DocDay;
				cRMspIntMsgSelectMessageFiles_Result.DocTime = item.DocTime;
				cRMspIntMsgSelectMessageFiles_Result.GUId = item.GUId;
				cRMspIntMsgSelectMessageFiles_Result.DocDateTime = item.DocDateTime;
				cRMspIntMsgSelectMessageFiles_Result.TypeOprObjectId = item.TypeOprObjectId;
				list.Add(cRMspIntMsgSelectMessageFiles_Result);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	public ActionResult IntMsgGetToUsersInfo_Read([DataSourceRequest] DataSourceRequest request, int intMsgId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspIntMsgGetToUsersInfoViewModel> list = new List<CRMspIntMsgGetToUsersInfoViewModel>();
		if (intMsgId == 0)
		{
			return Json(((IEnumerable)list).ToDataSourceResult(request));
		}
		foreach (CRMspIntMsgGetToUsersInfo_Result item in Enumerable.ToList<CRMspIntMsgGetToUsersInfo_Result>((IEnumerable<CRMspIntMsgGetToUsersInfo_Result>)db.CRMspIntMsgGetToUsersInfo(intMsgId, lCID, result)))
		{
			string msgdReceiveDate = "";
			string receiveDateTime = "";
			if (item.msgdReceiveDateTime.HasValue)
			{
				msgdReceiveDate = DateTime.Parse(item.msgdReceiveDateTime.ToString()).ToString("yyyy/MM/dd HH:mm:ss");
				receiveDateTime = DateTime.Parse(item.msgdReceiveDateTime.ToString()).ToString("yyyy/MM/dd HH:mm:ss");
			}
			string readDateTime = "";
			if (item.msgdReadDateTime.HasValue)
			{
				readDateTime = DateTime.Parse(item.msgdReadDateTime.ToString()).ToString("yyyy/MM/dd HH:mm:ss");
			}
			CRMspIntMsgGetToUsersInfoViewModel cRMspIntMsgGetToUsersInfoViewModel = new CRMspIntMsgGetToUsersInfoViewModel();
			cRMspIntMsgGetToUsersInfoViewModel.msgdToUserId = item.msgdToUserId;
			cRMspIntMsgGetToUsersInfoViewModel.ToUser = item.ToUser;
			cRMspIntMsgGetToUsersInfoViewModel.msgdReceiveDate = msgdReceiveDate;
			cRMspIntMsgGetToUsersInfoViewModel.msgdReceiveTime = item.msgdReceiveTime;
			cRMspIntMsgGetToUsersInfoViewModel.msgdReceiveDateTime = item.msgdReceiveDateTime;
			cRMspIntMsgGetToUsersInfoViewModel.ReceiveDateTime = receiveDateTime;
			cRMspIntMsgGetToUsersInfoViewModel.msgdReadDateTime = item.msgdReadDateTime;
			cRMspIntMsgGetToUsersInfoViewModel.msgdReadTime = item.msgdReadTime;
			cRMspIntMsgGetToUsersInfoViewModel.ReadDateTime = readDateTime;
			list.Add(cRMspIntMsgGetToUsersInfoViewModel);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request));
	}

	[AjaxOnly]
	public JsonResult GetInternalMessageInfo(int msgid, string kind, int msgTypeId, int fromPlase, int msgToUserId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int num = 0;
		LoadIntMsgInfoViewModel loadIntMsgInfoViewModel = new LoadIntMsgInfoViewModel();
		loadIntMsgInfoViewModel.InternalMessageInfo = new CRMspIntMsgSelectMessageInType_Result();
		loadIntMsgInfoViewModel.InternalMessageFiles = new List<CRMspIntMsgSelectMessageFiles_Result>();
		loadIntMsgInfoViewModel.InternalMessageToUsersInfo = new List<CRMspIntMsgGetToUsersInfo_Result>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			msgToUserId = ((msgToUserId != 0) ? msgToUserId : UserLogin.CurrentUser.UserId);
			List<CRMspIntMsgSelectMessageInType_Result> list = Enumerable.ToList<CRMspIntMsgSelectMessageInType_Result>((IEnumerable<CRMspIntMsgSelectMessageInType_Result>)db.CRMspIntMsgSelectMessageInType(msgid, msgToUserId, msgTypeId, lCID, result, result2));
			CRMspIntMsgSelectMessageInType_Result cRMspIntMsgSelectMessageInType_Result = null;
			cRMspIntMsgSelectMessageInType_Result = ((msgid == 0) ? Enumerable.FirstOrDefault<CRMspIntMsgSelectMessageInType_Result>(Enumerable.Take<CRMspIntMsgSelectMessageInType_Result>((IEnumerable<CRMspIntMsgSelectMessageInType_Result>)Enumerable.OrderByDescending<CRMspIntMsgSelectMessageInType_Result, int>((IEnumerable<CRMspIntMsgSelectMessageInType_Result>)list, (Func<CRMspIntMsgSelectMessageInType_Result, int>)((CRMspIntMsgSelectMessageInType_Result c) => c.InternalMessageID)), 1)) : ((kind == "next") ? (Enumerable.FirstOrDefault<CRMspIntMsgSelectMessageInType_Result>(Enumerable.Take<CRMspIntMsgSelectMessageInType_Result>(Enumerable.Where<CRMspIntMsgSelectMessageInType_Result>((IEnumerable<CRMspIntMsgSelectMessageInType_Result>)list, (Func<CRMspIntMsgSelectMessageInType_Result, bool>)((CRMspIntMsgSelectMessageInType_Result c) => c.InternalMessageID > msgid)), 1)) ?? Enumerable.First<CRMspIntMsgSelectMessageInType_Result>(Enumerable.Take<CRMspIntMsgSelectMessageInType_Result>((IEnumerable<CRMspIntMsgSelectMessageInType_Result>)Enumerable.OrderByDescending<CRMspIntMsgSelectMessageInType_Result, int>((IEnumerable<CRMspIntMsgSelectMessageInType_Result>)list, (Func<CRMspIntMsgSelectMessageInType_Result, int>)((CRMspIntMsgSelectMessageInType_Result c) => c.InternalMessageID)), 1))) : ((!(kind == "prev")) ? Enumerable.FirstOrDefault<CRMspIntMsgSelectMessageInType_Result>((IEnumerable<CRMspIntMsgSelectMessageInType_Result>)list, (Func<CRMspIntMsgSelectMessageInType_Result, bool>)((CRMspIntMsgSelectMessageInType_Result c) => c.InternalMessageID == msgid)) : (Enumerable.FirstOrDefault<CRMspIntMsgSelectMessageInType_Result>(Enumerable.Take<CRMspIntMsgSelectMessageInType_Result>((IEnumerable<CRMspIntMsgSelectMessageInType_Result>)Enumerable.OrderByDescending<CRMspIntMsgSelectMessageInType_Result, int>(Enumerable.Where<CRMspIntMsgSelectMessageInType_Result>((IEnumerable<CRMspIntMsgSelectMessageInType_Result>)list, (Func<CRMspIntMsgSelectMessageInType_Result, bool>)((CRMspIntMsgSelectMessageInType_Result c) => c.InternalMessageID < msgid)), (Func<CRMspIntMsgSelectMessageInType_Result, int>)((CRMspIntMsgSelectMessageInType_Result c) => c.InternalMessageID)), 1)) ?? Enumerable.First<CRMspIntMsgSelectMessageInType_Result>(Enumerable.Take<CRMspIntMsgSelectMessageInType_Result>((IEnumerable<CRMspIntMsgSelectMessageInType_Result>)list, 1))))));
			if (cRMspIntMsgSelectMessageInType_Result == null)
			{
				cRMspIntMsgSelectMessageInType_Result = new CRMspIntMsgSelectMessageInType_Result
				{
					RegisterDate = DateTime.Now,
					InternalMessageID = 0,
					msgdReadDateTime = DateTime.Now,
					msgdReceiveDateTime = DateTime.Now,
					msgdSendDateTime = DateTime.Now
				};
			}
			else if (cRMspIntMsgSelectMessageInType_Result.msgdTypeId == 12)
			{
				UpdateInternalMessage("Read", cRMspIntMsgSelectMessageInType_Result.InternalMessageID, cRMspIntMsgSelectMessageInType_Result.msgdTypeId);
			}
			string text = "";
			if (cRMspIntMsgSelectMessageInType_Result.msgdTypeId == 12)
			{
				text = Enumerable.Aggregate<CRMspIntMsgSelectMessageInType_Result, string>((IEnumerable<CRMspIntMsgSelectMessageInType_Result>)list, text, (Func<string, CRMspIntMsgSelectMessageInType_Result, string>)((string current, CRMspIntMsgSelectMessageInType_Result msg) => current + Labels.FromUser + " : " + msg.FROMUser + "     -->  " + Labels.MsgPriority + " : " + msg.InternalMessagePriority + "-->" + Labels.MsgStatus + " :" + msg.InternalMessageGroup + Environment.NewLine + msg.msgBody + Environment.NewLine + Labels.EmailSendingDate + "   : " + msg.msgdSendDateTime.ToString() + Environment.NewLine + Labels.RSmsReceiveDate + "  :" + msg.msgdReceiveDateTime.ToString() + Environment.NewLine + Labels.MsgDateSeen + "     :" + msg.msgdReadDateTime.ToString() + Environment.NewLine + Labels.MsgReciveres + " :" + msg.ToAndOtherUser + Environment.NewLine + "------------------------------------------------------------------------" + Environment.NewLine));
			}
			loadIntMsgInfoViewModel.InternalMessageInfo = cRMspIntMsgSelectMessageInType_Result;
			if (loadIntMsgInfoViewModel.InternalMessageInfo == null)
			{
				loadIntMsgInfoViewModel.InternalMessageInfo = new CRMspIntMsgSelectMessageInType_Result();
			}
			else
			{
				loadIntMsgInfoViewModel.InternalMessageInfo.msgBody = ((!string.IsNullOrWhiteSpace(text)) ? text : loadIntMsgInfoViewModel.InternalMessageInfo.msgBody);
				string text2 = loadIntMsgInfoViewModel.InternalMessageInfo.msgdAttachRecDesc;
				if (!string.IsNullOrWhiteSpace(text2) && loadIntMsgInfoViewModel.InternalMessageInfo.msgdTypeId != 16 && loadIntMsgInfoViewModel.InternalMessageInfo.msgdTypeId != 55 && loadIntMsgInfoViewModel.InternalMessageInfo.msgdTypeId != 17)
				{
					text2 = Messages.ConversationErjaShow;
				}
				if (loadIntMsgInfoViewModel.InternalMessageInfo.msgdAttachRecTypeId.HasValue && (loadIntMsgInfoViewModel.InternalMessageInfo.msgdTypeId == 1 || loadIntMsgInfoViewModel.InternalMessageInfo.msgdTypeId == 2) && !string.IsNullOrWhiteSpace(text2) && loadIntMsgInfoViewModel.InternalMessageInfo.msgdAttachRecTypeId > 0 && loadIntMsgInfoViewModel.InternalMessageInfo.msgdAttachRecTypeId.GetValueOrDefault() != 16 && loadIntMsgInfoViewModel.InternalMessageInfo.msgdAttachRecTypeId.GetValueOrDefault() != 55 && loadIntMsgInfoViewModel.InternalMessageInfo.msgdAttachRecTypeId.GetValueOrDefault() != 17)
				{
					text2 = Messages.ConversationErjaShow;
				}
				loadIntMsgInfoViewModel.InternalMessageInfo.msgdAttachRecDesc = text2;
				msgTypeId = loadIntMsgInfoViewModel.InternalMessageInfo.msgdTypeId;
				num = loadIntMsgInfoViewModel.InternalMessageInfo.InternalMessageID;
				CRMspIntMsgSelectMessageInType_Result internalMessageInfo = loadIntMsgInfoViewModel.InternalMessageInfo;
				_ = loadIntMsgInfoViewModel.InternalMessageInfo.msgdSendDateTime;
				internalMessageInfo.msgdSendDate = loadIntMsgInfoViewModel.InternalMessageInfo.msgdSendDateTime.ToString("yyyy/MM/dd HH:mm:ss");
				loadIntMsgInfoViewModel.InternalMessageInfo.msgdReceiveDate = (loadIntMsgInfoViewModel.InternalMessageInfo.msgdReceiveDateTime.HasValue ? loadIntMsgInfoViewModel.InternalMessageInfo.msgdReceiveDateTime.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
			}
			loadIntMsgInfoViewModel.InternalMessageFiles = Enumerable.ToList<CRMspIntMsgSelectMessageFiles_Result>((IEnumerable<CRMspIntMsgSelectMessageFiles_Result>)db.CRMspIntMsgSelectMessageFiles(msgid));
			if (loadIntMsgInfoViewModel.InternalMessageFiles == null)
			{
				loadIntMsgInfoViewModel.InternalMessageFiles = new List<CRMspIntMsgSelectMessageFiles_Result>();
			}
			loadIntMsgInfoViewModel.InternalMessageToUsersInfo = Enumerable.ToList<CRMspIntMsgGetToUsersInfo_Result>((IEnumerable<CRMspIntMsgGetToUsersInfo_Result>)db.CRMspIntMsgGetToUsersInfo(msgid, lCID, result));
			if (loadIntMsgInfoViewModel.InternalMessageToUsersInfo == null)
			{
				loadIntMsgInfoViewModel.InternalMessageToUsersInfo = new List<CRMspIntMsgGetToUsersInfo_Result>();
			}
			else
			{
				foreach (CRMspIntMsgGetToUsersInfo_Result item in loadIntMsgInfoViewModel.InternalMessageToUsersInfo)
				{
					item.msgdReceiveDate = (item.msgdReceiveDateTime.HasValue ? item.msgdReceiveDateTime.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
					item.msgdReceiveTime = (item.msgdReceiveDateTime.HasValue ? item.msgdReceiveDateTime.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
					item.ReceiveDateTime = (item.msgdReceiveDateTime.HasValue ? item.msgdReceiveDateTime.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
					item.ReadDateTime = (item.msgdReadDateTime.HasValue ? item.msgdReadDateTime.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.msgTypeId = msgTypeId;
		base.ViewBag.fromPlase = fromPlase;
		base.ViewBag.intMsgId = num;
		JsonResult jsonResult = Json(loadIntMsgInfoViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public string ReturnLetterTypeId(int recId)
	{
		string text = "-1";
		try
		{
			if (recId > 0)
			{
				int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)db.SecspReturnLetterTypeIdFromLetterId(recId));
				return num.HasValue ? num.ToString() : "0";
			}
			return "-1";
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.frmErrorMessage;
		}
	}

	[AjaxOnly]
	public string ReturnDocType(int docId)
	{
		string text = "-1";
		try
		{
			if (docId > 0)
			{
				WSspReturnDocOprTypeFromDocId_Result wSspReturnDocOprTypeFromDocId_Result = Enumerable.FirstOrDefault<WSspReturnDocOprTypeFromDocId_Result>((IEnumerable<WSspReturnDocOprTypeFromDocId_Result>)_dbI.WSspReturnDocOprTypeFromDocId(docId));
				if (wSspReturnDocOprTypeFromDocId_Result != null)
				{
					return wSspReturnDocOprTypeFromDocId_Result.OprType.GetValueOrDefault().ToString();
				}
				return "-1";
			}
			return "-1";
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.frmErrorMessage;
		}
	}

	[AjaxOnly]
	public string ReturnFormIdAndUserAccess(int mValId)
	{
		string result = "-1";
		try
		{
			if (mValId > 0)
			{
				CRMspDyReturnFormIdAndUserAccessFromMasterValueId_Result cRMspDyReturnFormIdAndUserAccessFromMasterValueId_Result = Enumerable.FirstOrDefault<CRMspDyReturnFormIdAndUserAccessFromMasterValueId_Result>((IEnumerable<CRMspDyReturnFormIdAndUserAccessFromMasterValueId_Result>)db.CRMspDyReturnFormIdAndUserAccessFromMasterValueId(mValId, UserLogin.CurrentUser.UserId));
				if (cRMspDyReturnFormIdAndUserAccessFromMasterValueId_Result != null)
				{
					string[] array = new string[17];
					_ = cRMspDyReturnFormIdAndUserAccessFromMasterValueId_Result.FormId;
					array[0] = cRMspDyReturnFormIdAndUserAccessFromMasterValueId_Result.FormId.ToString();
					array[1] = "|";
					array[2] = (cRMspDyReturnFormIdAndUserAccessFromMasterValueId_Result.FormUserAccess.HasValue ? cRMspDyReturnFormIdAndUserAccessFromMasterValueId_Result.FormUserAccess.ToString() : "");
					array[3] = "|";
					array[4] = (cRMspDyReturnFormIdAndUserAccessFromMasterValueId_Result.CompanyId.HasValue ? cRMspDyReturnFormIdAndUserAccessFromMasterValueId_Result.CompanyId.ToString() : "");
					array[5] = "|";
					array[6] = (cRMspDyReturnFormIdAndUserAccessFromMasterValueId_Result.CompanyPersonId.HasValue ? cRMspDyReturnFormIdAndUserAccessFromMasterValueId_Result.CompanyPersonId.ToString() : "");
					array[7] = "|";
					array[8] = (cRMspDyReturnFormIdAndUserAccessFromMasterValueId_Result.ProjectId.HasValue ? cRMspDyReturnFormIdAndUserAccessFromMasterValueId_Result.ProjectId.ToString() : "");
					array[9] = "|";
					array[10] = (cRMspDyReturnFormIdAndUserAccessFromMasterValueId_Result.ConversationId.HasValue ? cRMspDyReturnFormIdAndUserAccessFromMasterValueId_Result.ConversationId.ToString() : "");
					array[11] = "|";
					array[12] = (cRMspDyReturnFormIdAndUserAccessFromMasterValueId_Result.MasterObjectId.HasValue ? cRMspDyReturnFormIdAndUserAccessFromMasterValueId_Result.MasterObjectId.ToString() : "");
					array[13] = "|";
					array[14] = (cRMspDyReturnFormIdAndUserAccessFromMasterValueId_Result.DetailObjectId.HasValue ? cRMspDyReturnFormIdAndUserAccessFromMasterValueId_Result.DetailObjectId.ToString() : "");
					array[15] = "|";
					array[16] = (cRMspDyReturnFormIdAndUserAccessFromMasterValueId_Result.SubDetailObjectId.HasValue ? cRMspDyReturnFormIdAndUserAccessFromMasterValueId_Result.SubDetailObjectId.ToString() : "");
					result = string.Concat(array);
				}
			}
			else
			{
				result = "-1";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.frmErrorMessage;
		}
		return result;
	}

	public void UpdateInternalMessage(string mode, int messageId, int typeId)
	{
		try
		{
			string date = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			string time = DateTime.Now.ToString("HH:mm:ss");
			int result = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
			}
			db.CRMspInternalMessageUpdate(mode, messageId, UserLogin.CurrentUser.UserId, typeId, time, date, Configuration.AppType, result);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	public ActionResult _PartialCInternalMessageFilterMessageGroup(int selectedUserId, int intMsgGroupId, string fDate, string tDate)
	{
		fDate = fDate.Replace("/", "");
		tDate = tDate.Replace("/", "");
		base.ViewBag.lstParameter = selectedUserId + "|" + intMsgGroupId + "|" + fDate + "|" + tDate;
		return PartialView();
	}

	public ActionResult FilterMessageGroup_Read([DataSourceRequest] DataSourceRequest request, string lstParameter)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string[] array = lstParameter.Split(new char[1] { '|' });
		int value = int.Parse(array[0]);
		int num = int.Parse(array[1]);
		string fDate = array[2];
		string tDate = array[3];
		int result2 = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
		}
		List<CRMspIntMsgSelectUserMessageNAFromGroup_Result> list = Enumerable.ToList<CRMspIntMsgSelectUserMessageNAFromGroup_Result>((IEnumerable<CRMspIntMsgSelectUserMessageNAFromGroup_Result>)db.CRMspIntMsgSelectUserMessageNAFromGroup(value, num, fDate, tDate, lCID, result, result2));
		int messageId = 0;
		if (list.Count > 0)
		{
			messageId = Enumerable.FirstOrDefault<CRMspIntMsgSelectUserMessageNAFromGroup_Result>((IEnumerable<CRMspIntMsgSelectUserMessageNAFromGroup_Result>)list).InternalMessageID;
		}
		UpdateInternalMessage("Receive", messageId, num);
		foreach (CRMspIntMsgSelectUserMessageNAFromGroup_Result item in list)
		{
			_ = item.msgdSendDateTime;
			DateTime.TryParse(item.msgdSendDateTime.ToString(), out var result3);
			item.SendDateTime = result3.ToString("yyyy/MM/dd hh:mm:ss tt");
			if (item.msgdReceiveDateTime.HasValue)
			{
				DateTime.TryParse(item.msgdReceiveDateTime.ToString(), out var result4);
				item.ReceiveDateTime = result4.ToString("yyyy/MM/dd hh:mm:ss tt");
			}
		}
		JsonResult jsonResult = Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public ActionResult _PartialCInternalMessageFilterMessage(int selectedUserId, int intMsgTypeId, string fDate, string tDate)
	{
		fDate = fDate.Replace("/", "");
		tDate = tDate.Replace("/", "");
		base.ViewBag.lstParameter = selectedUserId + "|" + intMsgTypeId + "|" + fDate + "|" + tDate;
		return PartialView();
	}

	public ActionResult FilterMessage_Read([DataSourceRequest] DataSourceRequest request, string lstParameter)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string[] array = lstParameter.Split(new char[1] { '|' });
		int value = int.Parse(array[0]);
		int num = int.Parse(array[1]);
		string text = array[2];
		string text2 = array[3];
		DateTime? fDate = null;
		DateTime? tDate = null;
		switch (lCID)
		{
		case 1065:
			if (!string.IsNullOrEmpty(text))
			{
				DateTime value6 = DateTime.ParseExact(PersianDate.GetFormatetdDate(text.Replace("/", "").Replace(".", "").Replace("-", "")) + " 00:00:00", "yyyy/MM/dd HH:mm:ss", new PersianCulture());
				fDate = value6;
			}
			if (!string.IsNullOrEmpty(text2))
			{
				DateTime value7 = DateTime.ParseExact(PersianDate.GetFormatetdDate(text2.Replace("/", "").Replace(".", "").Replace("-", "")) + " 23:59:59", "yyyy/MM/dd HH:mm:ss", new PersianCulture());
				tDate = value7;
			}
			break;
		case 1025:
			if (!string.IsNullOrEmpty(text))
			{
				DateTime value4 = DateTime.ParseExact(PersianDate.GetFormatetdDate(text.Replace("/", "").Replace(".", "").Replace("-", "")) + " 00:00:00", "yyyy/MM/dd HH:mm:ss", new CultureInfo("ar-SA"));
				fDate = value4;
			}
			if (!string.IsNullOrEmpty(text2))
			{
				DateTime value5 = DateTime.ParseExact(PersianDate.GetFormatetdDate(text2.Replace("/", "").Replace(".", "").Replace("-", "")) + " 23:59:59", "yyyy/MM/dd HH:mm:ss", new CultureInfo("ar-SA"));
				tDate = value5;
			}
			break;
		default:
			if (!string.IsNullOrEmpty(text))
			{
				DateTime value2 = DateTime.ParseExact(PersianDate.GetFormatetdDate(text.Replace("/", "").Replace(".", "").Replace("-", "")) + " 00:00:00", "yyyy/MM/dd HH:mm:ss", new CultureInfo("en-US"));
				fDate = value2;
			}
			if (!string.IsNullOrEmpty(text2))
			{
				DateTime value3 = DateTime.ParseExact(PersianDate.GetFormatetdDate(text2.Replace("/", "").Replace(".", "").Replace("-", "")) + " 23:59:59", "yyyy/MM/dd HH:mm:ss", new CultureInfo("en-US"));
				tDate = value3;
			}
			break;
		}
		int result2 = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
		}
		List<CRMspIntMsgSelectUserMessageFromType_Result> list = Enumerable.ToList<CRMspIntMsgSelectUserMessageFromType_Result>((IEnumerable<CRMspIntMsgSelectUserMessageFromType_Result>)db.CRMspIntMsgSelectUserMessageFromType(value, num, fDate, tDate, lCID, result, result2));
		int messageId = 0;
		if (list.Count > 0)
		{
			messageId = Enumerable.FirstOrDefault<CRMspIntMsgSelectUserMessageFromType_Result>((IEnumerable<CRMspIntMsgSelectUserMessageFromType_Result>)list).InternalMessageID;
		}
		UpdateInternalMessage("Receive", messageId, num);
		List<CRMspIntMsgSelectUserMessageFromTypeViewModel> list2 = new List<CRMspIntMsgSelectUserMessageFromTypeViewModel>();
		foreach (CRMspIntMsgSelectUserMessageFromType_Result item in list)
		{
			CRMspIntMsgSelectUserMessageFromTypeViewModel cRMspIntMsgSelectUserMessageFromTypeViewModel = new CRMspIntMsgSelectUserMessageFromTypeViewModel();
			cRMspIntMsgSelectUserMessageFromTypeViewModel.InternalMessageID = item.InternalMessageID;
			cRMspIntMsgSelectUserMessageFromTypeViewModel.msgSubject = item.msgSubject;
			cRMspIntMsgSelectUserMessageFromTypeViewModel.msgdTypeId = item.msgdTypeId;
			cRMspIntMsgSelectUserMessageFromTypeViewModel.MessageType = item.MessageType;
			cRMspIntMsgSelectUserMessageFromTypeViewModel.msgdOldTypeId = item.msgdOldTypeId;
			cRMspIntMsgSelectUserMessageFromTypeViewModel.InternalMessageDetailID = item.InternalMessageDetailID;
			cRMspIntMsgSelectUserMessageFromTypeViewModel.msgdFromUserId = item.msgdFromUserId;
			cRMspIntMsgSelectUserMessageFromTypeViewModel.FromUser = item.FromUser;
			cRMspIntMsgSelectUserMessageFromTypeViewModel.msgdToUserId = item.msgdToUserId;
			cRMspIntMsgSelectUserMessageFromTypeViewModel.ToUser = item.ToUser;
			cRMspIntMsgSelectUserMessageFromTypeViewModel.msgdSendDateTime = item.msgdSendDateTime;
			cRMspIntMsgSelectUserMessageFromTypeViewModel.msgdReceiveDateTime = item.msgdReceiveDateTime;
			cRMspIntMsgSelectUserMessageFromTypeViewModel.msgdIsRead = item.msgdIsRead;
			cRMspIntMsgSelectUserMessageFromTypeViewModel.msgdPriorityId = item.msgdPriorityId;
			cRMspIntMsgSelectUserMessageFromTypeViewModel.InternalMessagePriority = item.InternalMessagePriority;
			cRMspIntMsgSelectUserMessageFromTypeViewModel.msgdGroupId = item.msgdGroupId;
			cRMspIntMsgSelectUserMessageFromTypeViewModel.UserId = item.UserId;
			cRMspIntMsgSelectUserMessageFromTypeViewModel.msgMasterId = item.msgMasterId;
			cRMspIntMsgSelectUserMessageFromTypeViewModel.msgIsFinalised = item.msgIsFinalised;
			cRMspIntMsgSelectUserMessageFromTypeViewModel.msgLastGroupId = item.msgLastGroupId;
			cRMspIntMsgSelectUserMessageFromTypeViewModel.msgActiveInCycle = item.msgActiveInCycle;
			cRMspIntMsgSelectUserMessageFromTypeViewModel.CompanyName = item.CompanyName ?? "";
			if (item.msgdSendDateTime.HasValue)
			{
				DateTime.TryParse(item.msgdSendDateTime.ToString(), out var result3);
				cRMspIntMsgSelectUserMessageFromTypeViewModel.SendDateTime = result3.ToString("yyyy/MM/dd hh:mm:ss tt");
			}
			if (item.msgdReceiveDateTime.HasValue)
			{
				DateTime.TryParse(item.msgdReceiveDateTime.ToString(), out var result4);
				cRMspIntMsgSelectUserMessageFromTypeViewModel.ReceiveDateTime = result4.ToString("yyyy/MM/dd hh:mm:ss tt");
			}
			list2.Add(cRMspIntMsgSelectUserMessageFromTypeViewModel);
		}
		JsonResult jsonResult = Json(((IEnumerable)list2).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public ActionResult _PartialCInternalMessageArchive(int selectedUserId, string fDate, string tDate)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		DateTime? fDate2 = null;
		DateTime? tDate2 = null;
		switch (lCID)
		{
		case 1065:
			if (!string.IsNullOrEmpty(fDate))
			{
				DateTime value5 = DateTime.ParseExact(PersianDate.GetFormatetdDate(fDate.Replace("/", "").Replace(".", "").Replace("-", "")) + " 00:00:00", "yyyy/MM/dd HH:mm:ss", new PersianCulture());
				fDate2 = value5;
			}
			if (!string.IsNullOrEmpty(tDate))
			{
				DateTime value6 = DateTime.ParseExact(PersianDate.GetFormatetdDate(tDate.Replace("/", "").Replace(".", "").Replace("-", "")) + " 23:59:59", "yyyy/MM/dd HH:mm:ss", new PersianCulture());
				tDate2 = value6;
			}
			break;
		case 1025:
			if (!string.IsNullOrEmpty(fDate))
			{
				DateTime value3 = DateTime.ParseExact(PersianDate.GetFormatetdDate(fDate.Replace("/", "").Replace(".", "").Replace("-", "")) + " 00:00:00", "yyyy/MM/dd HH:mm:ss", new CultureInfo("ar-SA"));
				fDate2 = value3;
			}
			if (!string.IsNullOrEmpty(tDate))
			{
				DateTime value4 = DateTime.ParseExact(PersianDate.GetFormatetdDate(tDate.Replace("/", "").Replace(".", "").Replace("-", "")) + " 23:59:59", "yyyy/MM/dd HH:mm:ss", new CultureInfo("ar-SA"));
				tDate2 = value4;
			}
			break;
		default:
			if (!string.IsNullOrEmpty(fDate))
			{
				DateTime value = DateTime.ParseExact(PersianDate.GetFormatetdDate(fDate.Replace("/", "").Replace(".", "").Replace("-", "")) + " 00:00:00", "yyyy/MM/dd HH:mm:ss", new CultureInfo("en-US"));
				fDate2 = value;
			}
			if (!string.IsNullOrEmpty(tDate))
			{
				DateTime value2 = DateTime.ParseExact(PersianDate.GetFormatetdDate(tDate.Replace("/", "").Replace(".", "").Replace("-", "")) + " 23:59:59", "yyyy/MM/dd HH:mm:ss", new CultureInfo("en-US"));
				tDate2 = value2;
			}
			break;
		}
		if (selectedUserId == 0)
		{
			selectedUserId = UserLogin.CurrentUser.UserId;
		}
		fDate = fDate.Replace("/", "");
		tDate = tDate.Replace("/", "");
		int result2 = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
		}
		List<CRMspIntMsgSelectInternalMessageType_Result> list = Enumerable.ToList<CRMspIntMsgSelectInternalMessageType_Result>((IEnumerable<CRMspIntMsgSelectInternalMessageType_Result>)db.CRMspIntMsgSelectInternalMessageType(selectedUserId, fDate2, tDate2, lCID, result, result2));
		List<TreeViewItemModel> list2 = new List<TreeViewItemModel>();
		foreach (CRMspIntMsgSelectInternalMessageType_Result item in list)
		{
			TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
			treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.RootID + "|" + item.InternalMessageTypeID));
			treeViewItemModel.Id = item.RootID + "|" + item.InternalMessageTypeID;
			treeViewItemModel.Text = item.MessageType;
			treeViewItemModel.ImageUrl = "";
			treeViewItemModel.Items = null;
			list2.Add(treeViewItemModel);
		}
		base.ViewBag.treeIntMsgArchive = list2;
		return PartialView();
	}

	[AjaxOnly]
	public JsonResult GetMsgUser()
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
			List<CRMspIntMsgUserAndLinkedUser_Result> list2 = Enumerable.ToList<CRMspIntMsgUserAndLinkedUser_Result>((IEnumerable<CRMspIntMsgUserAndLinkedUser_Result>)db.CRMspIntMsgUserAndLinkedUser(UserLogin.CurrentUser.UserId, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspIntMsgUserAndLinkedUser_Result, SelectListItem>((IEnumerable<CRMspIntMsgUserAndLinkedUser_Result>)list2, (Func<CRMspIntMsgUserAndLinkedUser_Result, SelectListItem>)((CRMspIntMsgUserAndLinkedUser_Result item) => new SelectListItem
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
		base.ViewBag.MsgUserList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetMsgdToUser(int userId = 0)
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
			List<CRMspIntMsgSearchMsgdToUser_Result> list2 = Enumerable.ToList<CRMspIntMsgSearchMsgdToUser_Result>((IEnumerable<CRMspIntMsgSearchMsgdToUser_Result>)db.CRMspIntMsgSearchMsgdToUser(userId, lCID, result, result2));
			list.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = true
			});
			list.AddRange(Enumerable.Select<CRMspIntMsgSearchMsgdToUser_Result, SelectListItem>((IEnumerable<CRMspIntMsgSearchMsgdToUser_Result>)list2, (Func<CRMspIntMsgSearchMsgdToUser_Result, SelectListItem>)((CRMspIntMsgSearchMsgdToUser_Result item) => new SelectListItem
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
		base.ViewBag.MsgdToUserList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetMsgdFromUser(int userId = 0)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int result = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspIntMsgSearchMsgdFromUser_Result> list2 = Enumerable.ToList<CRMspIntMsgSearchMsgdFromUser_Result>((IEnumerable<CRMspIntMsgSearchMsgdFromUser_Result>)db.CRMspIntMsgSearchMsgdFromUser(userId, lCID, result2, result));
			list.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = true
			});
			list.AddRange(Enumerable.Select<CRMspIntMsgSearchMsgdFromUser_Result, SelectListItem>((IEnumerable<CRMspIntMsgSearchMsgdFromUser_Result>)list2, (Func<CRMspIntMsgSearchMsgdFromUser_Result, SelectListItem>)((CRMspIntMsgSearchMsgdFromUser_Result item) => new SelectListItem
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
		base.ViewBag.MsgdFromUserList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetMsgdType()
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
			List<CRMspIntMsgSearchMessageType_Result> list2 = Enumerable.ToList<CRMspIntMsgSearchMessageType_Result>((IEnumerable<CRMspIntMsgSearchMessageType_Result>)db.CRMspIntMsgSearchMessageType(lCID, result));
			list.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = true
			});
			list.AddRange(Enumerable.Select<CRMspIntMsgSearchMessageType_Result, SelectListItem>((IEnumerable<CRMspIntMsgSearchMessageType_Result>)list2, (Func<CRMspIntMsgSearchMessageType_Result, SelectListItem>)((CRMspIntMsgSearchMessageType_Result item) => new SelectListItem
			{
				Text = item.MessageType,
				Value = item.InternalMessageTypeID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.MsgdTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult IntMsgSearch(InternalMessageSearchViewModel itemSearch)
	{
		JsonResult jsonResult = Json(IntMsgSearchItem(itemSearch), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<CRMspIntMsgSelectUserMessageFromTypeViewModel> IntMsgSearchItem(InternalMessageSearchViewModel itemSearch)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		new List<mct_CRMspIntMsgSearch_Result>();
		List<CRMspIntMsgSelectUserMessageFromTypeViewModel> list = new List<CRMspIntMsgSelectUserMessageFromTypeViewModel>();
		try
		{
			if (itemSearch != null)
			{
				itemSearch.FromDate = ((!string.IsNullOrEmpty(itemSearch.FromDate)) ? itemSearch.FromDate.Replace("/", "") : "");
				itemSearch.ToDate = ((!string.IsNullOrEmpty(itemSearch.ToDate)) ? itemSearch.ToDate.Replace("/", "") : "");
				itemSearch.MsgdUserId = ((string.IsNullOrEmpty(itemSearch.MsgdUserId) || itemSearch.MsgdUserId == "0") ? "" : itemSearch.MsgdUserId);
				itemSearch.MsgdToUserId = ((string.IsNullOrEmpty(itemSearch.MsgdToUserId) || itemSearch.MsgdToUserId == "0") ? "" : itemSearch.MsgdToUserId);
				itemSearch.MsgdFromUserId = ((string.IsNullOrEmpty(itemSearch.MsgdFromUserId) || itemSearch.MsgdFromUserId == "0") ? "" : itemSearch.MsgdFromUserId);
				itemSearch.MsgdTypeId = ((string.IsNullOrEmpty(itemSearch.MsgdTypeId) || itemSearch.MsgdTypeId == "0") ? "" : itemSearch.MsgdTypeId);
				itemSearch.MsgdIsRead = ((string.IsNullOrEmpty(itemSearch.MsgdIsRead) || itemSearch.MsgdIsRead == "-1") ? "" : itemSearch.MsgdIsRead);
				itemSearch.MsgSubject = (string.IsNullOrEmpty(itemSearch.MsgSubject) ? "" : itemSearch.MsgSubject);
				itemSearch.MsgBody = (string.IsNullOrEmpty(itemSearch.MsgBody) ? "" : itemSearch.MsgBody);
				int result2 = 0;
				if (UserLogin.CurrentUser != null)
				{
					int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
				}
				DateTime? dateTime = DateTime.Now;
				DateTime? dateTime2 = DateTime.Now;
				switch (lCID)
				{
				case 1065:
					if (!string.IsNullOrEmpty(itemSearch.FromDate))
					{
						DateTime value5 = DateTime.ParseExact(PersianDate.GetFormatetdDate(itemSearch.FromDate.Replace("/", "").Replace(".", "").Replace("-", "")) + " 00:00:00", "yyyy/MM/dd HH:mm:ss", new PersianCulture());
						dateTime = value5;
					}
					if (!string.IsNullOrEmpty(itemSearch.ToDate))
					{
						DateTime value6 = DateTime.ParseExact(PersianDate.GetFormatetdDate(itemSearch.ToDate.Replace("/", "").Replace(".", "").Replace("-", "")) + " 23:59:59", "yyyy/MM/dd HH:mm:ss", new PersianCulture());
						dateTime2 = value6;
					}
					break;
				case 1025:
					if (!string.IsNullOrEmpty(itemSearch.FromDate))
					{
						DateTime value3 = DateTime.ParseExact(PersianDate.GetFormatetdDate(itemSearch.FromDate.Replace("/", "").Replace(".", "").Replace("-", "")) + " 00:00:00", "yyyy/MM/dd HH:mm:ss", new CultureInfo("ar-SA"));
						dateTime = value3;
					}
					if (!string.IsNullOrEmpty(itemSearch.ToDate))
					{
						DateTime value4 = DateTime.ParseExact(PersianDate.GetFormatetdDate(itemSearch.ToDate.Replace("/", "").Replace(".", "").Replace("-", "")) + " 23:59:59", "yyyy/MM/dd HH:mm:ss", new CultureInfo("ar-SA"));
						dateTime2 = value4;
					}
					break;
				default:
					if (!string.IsNullOrEmpty(itemSearch.FromDate))
					{
						DateTime value = DateTime.ParseExact(PersianDate.GetFormatetdDate(itemSearch.FromDate.Replace("/", "").Replace(".", "").Replace("-", "")) + " 00:00:00", "yyyy/MM/dd HH:mm:ss", new CultureInfo("en-US"));
						dateTime = value;
					}
					if (!string.IsNullOrEmpty(itemSearch.ToDate))
					{
						DateTime value2 = DateTime.ParseExact(PersianDate.GetFormatetdDate(itemSearch.ToDate.Replace("/", "").Replace(".", "").Replace("-", "")) + " 23:59:59", "yyyy/MM/dd HH:mm:ss", new CultureInfo("en-US"));
						dateTime2 = value2;
					}
					break;
				}
				if (string.IsNullOrEmpty(itemSearch.FromDate))
				{
					dateTime = null;
				}
				if (string.IsNullOrEmpty(itemSearch.ToDate))
				{
					dateTime2 = null;
				}
				foreach (mct_CRMspIntMsgSearch_Result item in Enumerable.ToList<mct_CRMspIntMsgSearch_Result>((IEnumerable<mct_CRMspIntMsgSearch_Result>)db.mfi_CRMspIntMsgSearch(dateTime, dateTime2, itemSearch.MsgdUserId, itemSearch.MsgdToUserId, itemSearch.MsgdFromUserId, msgdIsRead: itemSearch.MsgdIsRead, msgdTypeId: itemSearch.MsgdTypeId, msgSubject: itemSearch.MsgSubject, msgBody: itemSearch.MsgBody, languageID: lCID, defaultLanguageID: result, centerId: result2)))
				{
					CRMspIntMsgSelectUserMessageFromTypeViewModel cRMspIntMsgSelectUserMessageFromTypeViewModel = new CRMspIntMsgSelectUserMessageFromTypeViewModel();
					cRMspIntMsgSelectUserMessageFromTypeViewModel.InternalMessageID = item.InternalMessageID.GetValueOrDefault();
					cRMspIntMsgSelectUserMessageFromTypeViewModel.msgSubject = item.msgSubject;
					cRMspIntMsgSelectUserMessageFromTypeViewModel.msgdTypeId = item.msgdTypeId;
					cRMspIntMsgSelectUserMessageFromTypeViewModel.MessageType = item.MessageType;
					cRMspIntMsgSelectUserMessageFromTypeViewModel.msgdOldTypeId = item.msgdOldTypeId;
					cRMspIntMsgSelectUserMessageFromTypeViewModel.InternalMessageDetailID = item.InternalMessageDetailID;
					cRMspIntMsgSelectUserMessageFromTypeViewModel.msgdFromUserId = item.msgdFromUserId;
					cRMspIntMsgSelectUserMessageFromTypeViewModel.FromUser = item.FromUser;
					cRMspIntMsgSelectUserMessageFromTypeViewModel.msgdToUserId = item.msgdToUserId;
					cRMspIntMsgSelectUserMessageFromTypeViewModel.ToUser = item.ToUser;
					cRMspIntMsgSelectUserMessageFromTypeViewModel.msgdSendDateTime = item.msgdSendDateTime;
					cRMspIntMsgSelectUserMessageFromTypeViewModel.msgdReceiveDateTime = item.msgdReceiveDateTime;
					cRMspIntMsgSelectUserMessageFromTypeViewModel.msgdIsRead = item.msgdIsRead;
					cRMspIntMsgSelectUserMessageFromTypeViewModel.msgdPriorityId = item.msgdPriorityId;
					cRMspIntMsgSelectUserMessageFromTypeViewModel.InternalMessagePriority = item.InternalMessagePriority;
					cRMspIntMsgSelectUserMessageFromTypeViewModel.msgdGroupId = item.msgdGroupId;
					cRMspIntMsgSelectUserMessageFromTypeViewModel.UserId = item.UserId.GetValueOrDefault();
					cRMspIntMsgSelectUserMessageFromTypeViewModel.msgMasterId = item.msgMasterId;
					cRMspIntMsgSelectUserMessageFromTypeViewModel.msgIsFinalised = item.msgIsFinalised;
					cRMspIntMsgSelectUserMessageFromTypeViewModel.msgLastGroupId = item.msgLastGroupId;
					cRMspIntMsgSelectUserMessageFromTypeViewModel.msgActiveInCycle = item.msgActiveInCycle;
					if (item.msgdSendDateTime.HasValue)
					{
						DateTime.TryParse(item.msgdSendDateTime.ToString(), out var result3);
						cRMspIntMsgSelectUserMessageFromTypeViewModel.SendDateTime = result3.ToString("yyyy/MM/dd hh:mm:ss tt dddd");
					}
					if (item.msgdReceiveDateTime.HasValue)
					{
						DateTime.TryParse(item.msgdReceiveDateTime.ToString(), out var result4);
						cRMspIntMsgSelectUserMessageFromTypeViewModel.ReceiveDateTime = result4.ToString("yyyy/MM/dd hh:mm:ss tt dddd");
					}
					if (item.msgdReadDateTime.HasValue)
					{
						DateTime.TryParse(item.msgdReadDateTime.ToString(), out var result5);
						cRMspIntMsgSelectUserMessageFromTypeViewModel.ReadDateTime = result5.ToString("yyyy/MM/dd hh:mm:ss tt dddd");
					}
					list.Add(cRMspIntMsgSelectUserMessageFromTypeViewModel);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public ActionResult IntMsgSearch_Read([DataSourceRequest] DataSourceRequest request, string itemSearch)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		InternalMessageSearchViewModel itemSearch2 = new JavaScriptSerializer().Deserialize<InternalMessageSearchViewModel>(itemSearch);
		List<CRMspIntMsgSelectUserMessageFromTypeViewModel> enumerable = IntMsgSearchItem(itemSearch2);
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[LoginAuthorize]
	public ActionResult CInternalMessageShowInfo(int messageTypeId, int messageId, int msgToUserId = 0)
	{
		base.ViewBag.msgTypeId = messageTypeId;
		base.ViewBag.msgId = messageId;
		base.ViewBag.msgToUserId = msgToUserId;
		return View();
	}

	[AjaxOnly]
	public JsonResult GetInternalMessageShowInfo(int msgid, int msgTypeId, int msgToUserId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int num = 0;
		LoadIntMsgInfoViewModel loadIntMsgInfoViewModel = new LoadIntMsgInfoViewModel();
		loadIntMsgInfoViewModel.InternalMessageInfo = new CRMspIntMsgSelectMessageInType_Result();
		loadIntMsgInfoViewModel.InternalMessageFiles = new List<CRMspIntMsgSelectMessageFiles_Result>();
		loadIntMsgInfoViewModel.InternalMessageToUsersInfo = new List<CRMspIntMsgGetToUsersInfo_Result>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			msgToUserId = ((msgToUserId != 0) ? msgToUserId : UserLogin.CurrentUser.UserId);
			List<CRMspIntMsgSelectMessageInType_Result> list = Enumerable.ToList<CRMspIntMsgSelectMessageInType_Result>((IEnumerable<CRMspIntMsgSelectMessageInType_Result>)db.CRMspIntMsgSelectMessageInType(msgid, msgToUserId, msgTypeId, lCID, result, result2));
			CRMspIntMsgSelectMessageInType_Result cRMspIntMsgSelectMessageInType_Result = null;
			cRMspIntMsgSelectMessageInType_Result = ((msgid != 0) ? Enumerable.FirstOrDefault<CRMspIntMsgSelectMessageInType_Result>((IEnumerable<CRMspIntMsgSelectMessageInType_Result>)list, (Func<CRMspIntMsgSelectMessageInType_Result, bool>)((CRMspIntMsgSelectMessageInType_Result c) => c.InternalMessageID == msgid)) : Enumerable.FirstOrDefault<CRMspIntMsgSelectMessageInType_Result>(Enumerable.Take<CRMspIntMsgSelectMessageInType_Result>((IEnumerable<CRMspIntMsgSelectMessageInType_Result>)Enumerable.OrderByDescending<CRMspIntMsgSelectMessageInType_Result, int>((IEnumerable<CRMspIntMsgSelectMessageInType_Result>)list, (Func<CRMspIntMsgSelectMessageInType_Result, int>)((CRMspIntMsgSelectMessageInType_Result c) => c.InternalMessageID)), 1)));
			if (cRMspIntMsgSelectMessageInType_Result == null)
			{
				cRMspIntMsgSelectMessageInType_Result = new CRMspIntMsgSelectMessageInType_Result
				{
					RegisterDate = DateTime.Now,
					InternalMessageID = 0,
					msgdReadDateTime = DateTime.Now,
					msgdReceiveDateTime = DateTime.Now,
					msgdSendDateTime = DateTime.Now
				};
			}
			string text = "";
			if (cRMspIntMsgSelectMessageInType_Result.msgdTypeId == 12)
			{
				text = Enumerable.Aggregate<CRMspIntMsgSelectMessageInType_Result, string>((IEnumerable<CRMspIntMsgSelectMessageInType_Result>)list, text, (Func<string, CRMspIntMsgSelectMessageInType_Result, string>)((string current, CRMspIntMsgSelectMessageInType_Result msg) => current + Labels.FromUser + " : " + msg.FROMUser + "     -->  " + Labels.MsgPriority + " : " + msg.InternalMessagePriority + "-->" + Labels.MsgStatus + " :" + msg.InternalMessageGroup + Environment.NewLine + msg.msgBody + Environment.NewLine + Labels.EmailSendingDate + "   : " + msg.msgdSendDateTime.ToString() + Environment.NewLine + Labels.RSmsReceiveDate + "  :" + msg.msgdReceiveDateTime.ToString() + Environment.NewLine + Labels.MsgDateSeen + "     :" + msg.msgdReadDateTime.ToString() + Environment.NewLine + Labels.MsgReciveres + " :" + msg.ToAndOtherUser + Environment.NewLine + "------------------------------------------------------------------------" + Environment.NewLine));
			}
			loadIntMsgInfoViewModel.InternalMessageInfo = cRMspIntMsgSelectMessageInType_Result;
			if (loadIntMsgInfoViewModel.InternalMessageInfo == null)
			{
				loadIntMsgInfoViewModel.InternalMessageInfo = new CRMspIntMsgSelectMessageInType_Result();
			}
			else
			{
				loadIntMsgInfoViewModel.InternalMessageInfo.msgBody = ((!string.IsNullOrWhiteSpace(text)) ? text : loadIntMsgInfoViewModel.InternalMessageInfo.msgBody);
				string text2 = loadIntMsgInfoViewModel.InternalMessageInfo.msgdAttachRecDesc;
				if (!string.IsNullOrWhiteSpace(text2) && loadIntMsgInfoViewModel.InternalMessageInfo.msgdTypeId != 16 && loadIntMsgInfoViewModel.InternalMessageInfo.msgdTypeId != 55 && loadIntMsgInfoViewModel.InternalMessageInfo.msgdTypeId != 17)
				{
					text2 = Messages.ConversationErjaShow;
				}
				if (loadIntMsgInfoViewModel.InternalMessageInfo.msgdAttachRecTypeId.HasValue && (loadIntMsgInfoViewModel.InternalMessageInfo.msgdTypeId == 1 || loadIntMsgInfoViewModel.InternalMessageInfo.msgdTypeId == 2) && !string.IsNullOrWhiteSpace(text2) && loadIntMsgInfoViewModel.InternalMessageInfo.msgdAttachRecTypeId > 0 && loadIntMsgInfoViewModel.InternalMessageInfo.msgdAttachRecTypeId.GetValueOrDefault() != 16 && loadIntMsgInfoViewModel.InternalMessageInfo.msgdAttachRecTypeId.GetValueOrDefault() != 55 && loadIntMsgInfoViewModel.InternalMessageInfo.msgdAttachRecTypeId.GetValueOrDefault() != 17)
				{
					text2 = Messages.ConversationErjaShow;
				}
				loadIntMsgInfoViewModel.InternalMessageInfo.msgdAttachRecDesc = text2;
				msgTypeId = loadIntMsgInfoViewModel.InternalMessageInfo.msgdTypeId;
				num = loadIntMsgInfoViewModel.InternalMessageInfo.InternalMessageID;
				CRMspIntMsgSelectMessageInType_Result internalMessageInfo = loadIntMsgInfoViewModel.InternalMessageInfo;
				_ = loadIntMsgInfoViewModel.InternalMessageInfo.msgdSendDateTime;
				internalMessageInfo.msgdSendDate = loadIntMsgInfoViewModel.InternalMessageInfo.msgdSendDateTime.ToString("yyyy/MM/dd HH:mm:ss");
				loadIntMsgInfoViewModel.InternalMessageInfo.msgdReceiveDate = (loadIntMsgInfoViewModel.InternalMessageInfo.msgdReceiveDateTime.HasValue ? loadIntMsgInfoViewModel.InternalMessageInfo.msgdReceiveDateTime.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.msgTypeId = msgTypeId;
		base.ViewBag.intMsgId = num;
		JsonResult jsonResult = Json(loadIntMsgInfoViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public ActionResult InternalMessageHistory(int msgId = 0, int typeId = 0)
	{
		List<CRMspSelectInternalMessageHistory_Result> value = new List<CRMspSelectInternalMessageHistory_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (msgId != 0)
			{
				List<CRMspSelectInternalMessageHistory_Result> list = Enumerable.ToList<CRMspSelectInternalMessageHistory_Result>((IEnumerable<CRMspSelectInternalMessageHistory_Result>)_dbI.CRMspSelectInternalMessageHistory(msgId, typeId, lCID, result));
				if (list != null)
				{
					foreach (CRMspSelectInternalMessageHistory_Result item in list)
					{
						if (!string.IsNullOrWhiteSpace(item.MessageDetails))
						{
							List<InternalMessageHistoryViewModel> list2 = new List<InternalMessageHistoryViewModel>();
							list2 = JsonConvert.DeserializeObject<List<InternalMessageHistoryViewModel>>(item.MessageDetails);
							foreach (InternalMessageHistoryViewModel item2 in list2)
							{
								_ = item2.msgdSendDateTime;
								item2.msgdSendDate = item2.msgdSendDateTime.ToString("yyyy/MM/dd HH:mm:ss");
								item2.msgdReceiveDate = (item2.msgdReceiveDateTime.HasValue ? item2.msgdReceiveDateTime?.ToString("yyyy/MM/dd HH:mm:ss") : "");
								item2.msgdReadDate = (item2.msgdReadDateTime.HasValue ? item2.msgdReadDateTime?.ToString("yyyy/MM/dd HH:mm:ss") : "");
							}
							item.MessageDetails = JsonConvert.SerializeObject(list2);
						}
						_ = item.RegisterDate;
						item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
						item.FirstRegisterDatePersian = (item.FirstRegisterDate.HasValue ? item.FirstRegisterDate?.ToString("yyyy/MM/dd HH:mm:ss") : "");
					}
					value = list;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.MessagesHistoryListJs = JsonConvert.SerializeObject(value);
		base.ViewBag.InternalMessageId = msgId;
		return View();
	}

	public ActionResult InternalMessageListForAttachRec(int recId = 0, int typeId = 0, string typeIds = "")
	{
		base.ViewBag.RecordId = recId;
		if (typeId > 0)
		{
			typeIds = typeId.ToString();
		}
		base.ViewBag.TypeIds = typeIds;
		return View();
	}

	[HttpGet]
	public JsonResult LoadInternalMessageListForAttachRec(int recId = 0, string typeIds = "", int pageNumber = 1, int pageSize = 30, string fromDate = "", string toDate = "")
	{
		try
		{
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int.TryParse(SysSeting.Get().DefaultLanguageID?.ToString() ?? "1065", out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			DateTime? fromDate2 = null;
			DateTime? toDate2 = null;
			if (!string.IsNullOrEmpty(fromDate))
			{
				fromDate = fromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				fromDate2 = lCID switch
				{
					1065 => DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00"), 
					1025 => DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None), 
					_ => DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None), 
				};
			}
			if (!string.IsNullOrEmpty(toDate))
			{
				toDate = toDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				toDate2 = lCID switch
				{
					1065 => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59"), 
					1025 => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59", new CultureInfo("ar-SA"), DateTimeStyles.None), 
					_ => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None), 
				};
			}
			CRMSpIEntities cRMSpIEntities = _dbI;
			int? msgdAttachRecId = recId;
			int? languageID = lCID;
			int? defaultLanguageID = result;
			int? pageNumber2 = pageNumber;
			int? pageSize2 = pageSize;
			List<CRMspIntMsgGetByTypeAndAttachRecId_Result> list = Enumerable.ToList<CRMspIntMsgGetByTypeAndAttachRecId_Result>((IEnumerable<CRMspIntMsgGetByTypeAndAttachRecId_Result>)cRMSpIEntities.CRMspIntMsgGetByTypeAndAttachRecId(typeIds, msgdAttachRecId, languageID, defaultLanguageID, fromDate2, toDate2, pageNumber2, pageSize2, UserLogin.CurrentUser.UserId));
			if (list != null && Enumerable.Any<CRMspIntMsgGetByTypeAndAttachRecId_Result>((IEnumerable<CRMspIntMsgGetByTypeAndAttachRecId_Result>)list))
			{
				foreach (CRMspIntMsgGetByTypeAndAttachRecId_Result item in list)
				{
					if (!string.IsNullOrWhiteSpace(item.MessageDetails))
					{
						List<InternalMessageHistoryViewModel> list2 = JsonConvert.DeserializeObject<List<InternalMessageHistoryViewModel>>(item.MessageDetails);
						foreach (InternalMessageHistoryViewModel item2 in list2)
						{
							item2.msgdSendDate = item2.msgdSendDateTime.ToString("yyyy/MM/dd HH:mm:ss") ?? "";
							item2.msgdReceiveDate = item2.msgdReceiveDateTime?.ToString("yyyy/MM/dd HH:mm:ss") ?? "";
							item2.msgdReadDate = item2.msgdReadDateTime?.ToString("yyyy/MM/dd HH:mm:ss") ?? "";
						}
						item.MessageDetails = JsonConvert.SerializeObject(list2);
					}
					item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss") ?? "";
					item.FirstRegisterDatePersian = item.FirstRegisterDate?.ToString("yyyy/MM/dd HH:mm:ss") ?? "";
				}
				int valueOrDefault = (Enumerable.FirstOrDefault<CRMspIntMsgGetByTypeAndAttachRecId_Result>((IEnumerable<CRMspIntMsgGetByTypeAndAttachRecId_Result>)list)?.TotalCount).GetValueOrDefault();
				bool hasNextPage = list.Count == pageSize && valueOrDefault > pageNumber * pageSize;
				return Json(new
				{
					Status = 1,
					Message = "",
					Data = list,
					TotalCount = valueOrDefault,
					PageNumber = pageNumber,
					PageSize = pageSize,
					HasNextPage = hasNextPage
				}, JsonRequestBehavior.AllowGet);
			}
			return Json(new
			{
				Status = 1,
				Message = "",
				Data = new List<CRMspIntMsgGetByTypeAndAttachRecId_Result>(),
				TotalCount = 0,
				PageNumber = pageNumber,
				PageSize = pageSize,
				HasNextPage = false
			}, JsonRequestBehavior.AllowGet);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Json(new
			{
				Status = 0,
				Message = Messages.msgErrorOperationFailed,
				Data = new List<CRMspIntMsgGetByTypeAndAttachRecId_Result>(),
				TotalCount = 0,
				PageNumber = pageNumber,
				PageSize = pageSize,
				HasNextPage = false
			}, JsonRequestBehavior.AllowGet);
		}
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actcknowledge")]
	public ActionResult Cknowledge()
	{
		base.ViewBag.lstGroups = SelectKnowledgeTankGroup();
		return View();
	}

	[HttpPost]
	[LoginAuthorize]
	public List<CRMspKnlgSearchWeb_Result> KnlgSearchWeb(string txtSearch = "", string modes = "", int groupId = 0, int lastRowNumber = 0, int pageSize = 300)
	{
		List<CRMspKnlgSearchWeb_Result> result = new List<CRMspKnlgSearchWeb_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspKnlgSearchWeb_Result> list = Enumerable.ToList<CRMspKnlgSearchWeb_Result>((IEnumerable<CRMspKnlgSearchWeb_Result>)dbI.CRMspKnlgSearchWeb(txtSearch, UserLogin.CurrentUser.RollId, modes, groupId, lCID, result2, lastRowNumber, pageSize, false));
			if (list != null)
			{
				foreach (CRMspKnlgSearchWeb_Result item in list)
				{
					_ = item.FirstRegisterDate;
					item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyy/MM/dd");
					_ = item.RegisterDate;
					item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd");
				}
				result = list;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string KnlgSearchWebJs(string txtSearch = "", string modes = "", int groupId = 0, int lastRowNumber = 0, int pageSize = 300)
	{
		return JsonConvert.SerializeObject(KnlgSearchWeb(txtSearch, modes, groupId, lastRowNumber, pageSize));
	}

	[HttpPost]
	[LoginAuthorize]
	public List<CRMspSelectFilesDirectory_Result> SelectFilesDirectory(int knlgId = 0)
	{
		List<CRMspSelectFilesDirectory_Result> result = new List<CRMspSelectFilesDirectory_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (knlgId > 0)
			{
				List<CRMspSelectFilesDirectory_Result> list = Files.SelectFilesDirectory("0", "0", "0", "40", knlgId.ToString(), "0", "0", false);
				if (list != null)
				{
					foreach (CRMspSelectFilesDirectory_Result item in list)
					{
						if (item.DocDateTime.HasValue)
						{
							DateTime.TryParse(item.DocDateTime.ToString(), out var result3);
							item.DocDate = result3.ToString("yyyy/MM/dd");
						}
						else if (!string.IsNullOrEmpty(item.DocDate))
						{
							if (lCID != 1065)
							{
								item.DocDate = DateTime.ParseExact(PersianDate.GetFormatetdDate(item.DocDate.Replace("/", "")), "yyyy/MM/dd", new PersianCulture()).ToString("yyyy/MM/dd");
							}
							else
							{
								item.DocDate = PersianDate.GetFormatetdDate(item.DocDate.Replace("/", ""));
							}
						}
						if (string.IsNullOrEmpty(item.AppType))
						{
							item.AppType = Configuration.AppType;
						}
						item.AppType = Configuration.GetAppType(item.AppType);
						string text = item.FirstRegisterUser ?? "";
						string text2 = (item.FirstRegisterDate.HasValue ? item.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
						item.FirstRegisterUser = Labels.frmFirstRegisterUser + ": " + text + " (" + text2 + ")";
						string text3 = item.EditUser ?? "";
						_ = item.RegisterDate;
						string text4 = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
						item.EditUser = Labels.frmRegisterUser + ": " + text3 + " (" + Labels.AppType + ":" + item.AppType + ")  (" + text4 + ")";
					}
					result = list;
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectFilesDirectoryJs(int knlgId = 0)
	{
		return JsonConvert.SerializeObject(SelectFilesDirectory(knlgId));
	}

	[HttpPost]
	[LoginAuthorize]
	public List<SelectListItem> SelectKnowledgeTankGroup()
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
			List<CRMspknlgSelectKnowledgeTankGroup_Result> list2 = Enumerable.ToList<CRMspknlgSelectKnowledgeTankGroup_Result>((IEnumerable<CRMspknlgSelectKnowledgeTankGroup_Result>)db.CRMspknlgSelectKnowledgeTankGroup(UserLogin.CurrentUser.RollId, lCID, result));
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<CRMspknlgSelectKnowledgeTankGroup_Result, SelectListItem>((IEnumerable<CRMspknlgSelectKnowledgeTankGroup_Result>)list2, (Func<CRMspknlgSelectKnowledgeTankGroup_Result, SelectListItem>)((CRMspknlgSelectKnowledgeTankGroup_Result x) => new SelectListItem
				{
					Text = x.KnowledgeTankGroupTitle,
					Value = x.KnowledgeTankGroupId.ToString()
				})));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return list;
	}

	[AjaxOnly]
	public ActionResult _PartialCknowledge(string txtSearch, int mode)
	{
		base.ViewBag.txtknowledge = txtSearch + "-" + mode;
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult Cknowledge_Read([DataSourceRequest] DataSourceRequest request, string contextknowledge)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspKnlgSearch_Result> list = new List<CRMspKnlgSearch_Result>();
		try
		{
			if (!string.IsNullOrEmpty(contextknowledge))
			{
				string[] array = contextknowledge.Split(new char[1] { '-' });
				int? rollId = UserLogin.CurrentUser.RollId;
				list = Enumerable.ToList<CRMspKnlgSearch_Result>((IEnumerable<CRMspKnlgSearch_Result>)db.CRMspKnlgSearch(array[0], rollId, int.Parse(array[1]), lCID, result));
				foreach (CRMspKnlgSearch_Result item in list)
				{
					_ = item.FirstRegisterDate;
					item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyyMMdd");
					_ = item.RegisterDate;
					item.RegisterDatePersian = item.RegisterDate.ToString("yyyyMMdd");
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult KnlgList_Read([DataSourceRequest] DataSourceRequest request)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspknlgSelectKnowledgeTankByRollId_Result> list = new List<CRMspknlgSelectKnowledgeTankByRollId_Result>();
		try
		{
			list = Enumerable.ToList<CRMspknlgSelectKnowledgeTankByRollId_Result>((IEnumerable<CRMspknlgSelectKnowledgeTankByRollId_Result>)db.CRMspknlgSelectKnowledgeTankByRollId(0, UserLogin.CurrentUser.RollId, lCID, result));
			foreach (CRMspknlgSelectKnowledgeTankByRollId_Result item in list)
			{
				_ = item.FirstRegisterDate;
				DateTime.TryParse(item.FirstRegisterDate.ToString(), out var result2);
				item.FirstRegisterDatePersian = result2.ToString("yyyy/MM/dd");
				_ = item.RegisterDate;
				DateTime.TryParse(item.RegisterDate.ToString(), out var result3);
				item.RegisterDatePersian = result3.ToString("yyyy/MM/dd");
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetKTankGroups()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmDroupDownItem> data = new List<CrmDroupDownItem>();
		try
		{
			data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspknlgSelectKnowledgeTankGroup_Result, CrmDroupDownItem>((IEnumerable<CRMspknlgSelectKnowledgeTankGroup_Result>)Enumerable.ToList<CRMspknlgSelectKnowledgeTankGroup_Result>((IEnumerable<CRMspknlgSelectKnowledgeTankGroup_Result>)db.CRMspknlgSelectKnowledgeTankGroup(UserLogin.CurrentUser.RollId, lCID, result)), (Func<CRMspknlgSelectKnowledgeTankGroup_Result, CrmDroupDownItem>)((CRMspknlgSelectKnowledgeTankGroup_Result item) => new CrmDroupDownItem
			{
				text = item.KnowledgeTankGroupTitle,
				value = item.KnowledgeTankGroupId.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetKTankPriorities()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmDroupDownItem> data = new List<CrmDroupDownItem>();
		try
		{
			data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspknlgSelectKnowledgeTankPriority_Result, CrmDroupDownItem>((IEnumerable<CRMspknlgSelectKnowledgeTankPriority_Result>)Enumerable.ToList<CRMspknlgSelectKnowledgeTankPriority_Result>((IEnumerable<CRMspknlgSelectKnowledgeTankPriority_Result>)db.CRMspknlgSelectKnowledgeTankPriority(lCID, result)), (Func<CRMspknlgSelectKnowledgeTankPriority_Result, CrmDroupDownItem>)((CRMspknlgSelectKnowledgeTankPriority_Result item) => new CrmDroupDownItem
			{
				text = item.KnowledgeTankPriorityTitle,
				value = item.KnowledgeTankPriorityId.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult _PartialKnlgListTankGroupPermission(int rollId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonDroupDownItemViewModel> list = new List<CommonDroupDownItemViewModel>();
		try
		{
			if (rollId > 0)
			{
				foreach (CRMspknlgSelectKnowledgeTankGroup_Result item in Enumerable.ToList<CRMspknlgSelectKnowledgeTankGroup_Result>((IEnumerable<CRMspknlgSelectKnowledgeTankGroup_Result>)db.CRMspknlgSelectKnowledgeTankGroup(0, lCID, result)))
				{
					CommonDroupDownItemViewModel commonDroupDownItemViewModel = new CommonDroupDownItemViewModel
					{
						Text = item.KnowledgeTankGroupTitle,
						Value = item.KnowledgeTankGroupId.ToString(),
						Tag = false
					};
					if (Enumerable.FirstOrDefault<CRMspknlgCheckHaveknlgMultiGroup_Result>((IEnumerable<CRMspknlgCheckHaveknlgMultiGroup_Result>)db.CRMspknlgCheckHaveknlgMultiGroup(rollId, item.KnowledgeTankGroupId)) != null)
					{
						commonDroupDownItemViewModel.Tag = true;
					}
					list.Add(commonDroupDownItemViewModel);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.LstGroups = list;
		return PartialView();
	}

	[AjaxOnly]
	public JsonResult GetKTankRolls()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmDroupDownItem> data = new List<CrmDroupDownItem>();
		try
		{
			data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspSelectsysRolls_Result, CrmDroupDownItem>((IEnumerable<CRMspSelectsysRolls_Result>)Enumerable.ToList<CRMspSelectsysRolls_Result>((IEnumerable<CRMspSelectsysRolls_Result>)db.CRMspSelectsysRolls(lCID, result)), (Func<CRMspSelectsysRolls_Result, CrmDroupDownItem>)((CRMspSelectsysRolls_Result roll) => new CrmDroupDownItem
			{
				text = roll.RollName,
				value = roll.ID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public string CKnowledgeTankGroupPermissionInsert(int rollId, int gId)
	{
		string result = "-1";
		if (rollId > 0 && gId > 0)
		{
			try
			{
				int userId = UserLogin.CurrentUser.UserId;
				string appType = Configuration.AppType;
				DateTime now = DateTime.Now;
				short value = short.Parse(Financial.Get().Id.ToString());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
				if (result2 <= 0)
				{
					result2 = 1065;
				}
				int num = db.CRMspknlgInsertGroupPermission(gId, rollId, userId, value, value2, registerDatePersian, appType, result2);
				result = ((num > 0) ? Messages.frmFormBaseInsertSuccessFulMessage : "-1");
				if (num > 0)
				{
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmKnowledgeTankGroupPermission");
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
		}
		else
		{
			result = "-2";
		}
		return result;
	}

	[AjaxOnly]
	public string CKnowledgeTankGroupPermissionDelete(int rollId, int gId)
	{
		string result = "-1";
		if (rollId > 0 && gId > 0)
		{
			try
			{
				int num = db.CRMspknlgDeleteGroupPermission(gId, rollId);
				result = ((num > 0) ? Messages.frmDeleteSuccessMessage : "-1");
				if (num > 0)
				{
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmKnowledgeTankGroupPermission");
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
		}
		else
		{
			result = "-2";
		}
		return result;
	}

	[AjaxOnly]
	public ActionResult _PartialKnlgList()
	{
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult _PartialKnlgShowFilse(int knlgId)
	{
		base.ViewBag.KnlgId = knlgId;
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult _PartialKnlgShowFilse_Read([DataSourceRequest] DataSourceRequest request, int knlgId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectFilesDirectory_Result> list = new List<CRMspSelectFilesDirectory_Result>();
		try
		{
			if (knlgId != 0)
			{
				list = Files.SelectFilesDirectory("0", "0", "0", "40", knlgId.ToString(), "0", "0", false);
			}
			if (list != null && Enumerable.Any<CRMspSelectFilesDirectory_Result>((IEnumerable<CRMspSelectFilesDirectory_Result>)list))
			{
				foreach (CRMspSelectFilesDirectory_Result item in list)
				{
					if (item.DocDateTime.HasValue)
					{
						DateTime.TryParse(item.DocDateTime.ToString(), out var result2);
						item.DocDate = result2.ToString("yyyy/MM/dd");
					}
					else if (!string.IsNullOrEmpty(item.DocDate))
					{
						if (lCID != 1065)
						{
							item.DocDate = DateTime.ParseExact(PersianDate.GetFormatetdDate(item.DocDate.Replace("/", "")), "yyyy/MM/dd", new PersianCulture()).ToString("yyyy/MM/dd");
						}
						else
						{
							item.DocDate = PersianDate.GetFormatetdDate(item.DocDate.Replace("/", ""));
						}
					}
					if (string.IsNullOrEmpty(item.AppType))
					{
						item.AppType = Configuration.AppType;
					}
					item.AppType = Configuration.GetAppType(item.AppType);
					string text = item.FirstRegisterUser ?? "";
					string text2 = (item.FirstRegisterDate.HasValue ? item.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
					item.FirstRegisterUser = Labels.frmFirstRegisterUser + ": " + text + " (" + text2 + ")";
					string text3 = item.EditUser ?? "";
					_ = item.RegisterDate;
					string text4 = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
					item.EditUser = Labels.frmRegisterUser + ": " + text3 + " (" + Labels.AppType + ":" + item.AppType + ")  (" + text4 + ")";
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult _PartialKnlgInfo(int knlgid, string kind)
	{
		_003C_003Ec__DisplayClass268_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass268_0();
		CS_0024_003C_003E8__locals0.knlgid = knlgid;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CRMspKnlgSearchViewModel cRMspKnlgSearchViewModel = new CRMspKnlgSearchViewModel();
		CS_0024_003C_003E8__locals0.knlg = null;
		try
		{
			List<CRMspknlgSelectKnowledgeTankByRollId_Result> list = Enumerable.ToList<CRMspknlgSelectKnowledgeTankByRollId_Result>((IEnumerable<CRMspknlgSelectKnowledgeTankByRollId_Result>)db.CRMspknlgSelectKnowledgeTankByRollId(0, UserLogin.CurrentUser.RollId, lCID, result));
			if (CS_0024_003C_003E8__locals0.knlgid == 0)
			{
				CS_0024_003C_003E8__locals0.knlg = Enumerable.FirstOrDefault<CRMspknlgSelectKnowledgeTankByRollId_Result>((IEnumerable<CRMspknlgSelectKnowledgeTankByRollId_Result>)list);
			}
			else
			{
				switch (kind)
				{
				case "next":
					if (UserLogin.IsUserAccess("frmKnowledgeTankDataEntry", "actNext", UserLogin.CurrentUser))
					{
						CS_0024_003C_003E8__locals0.knlg = Enumerable.FirstOrDefault<CRMspknlgSelectKnowledgeTankByRollId_Result>((IEnumerable<CRMspknlgSelectKnowledgeTankByRollId_Result>)Enumerable.OrderByDescending<CRMspknlgSelectKnowledgeTankByRollId_Result, int>((IEnumerable<CRMspknlgSelectKnowledgeTankByRollId_Result>)list, (Func<CRMspknlgSelectKnowledgeTankByRollId_Result, int>)((CRMspknlgSelectKnowledgeTankByRollId_Result c) => c.KnowledgeTankId)), (Func<CRMspknlgSelectKnowledgeTankByRollId_Result, bool>)((CRMspknlgSelectKnowledgeTankByRollId_Result c) => c.KnowledgeTankId < CS_0024_003C_003E8__locals0.knlgid)) ?? Enumerable.FirstOrDefault<CRMspknlgSelectKnowledgeTankByRollId_Result>((IEnumerable<CRMspknlgSelectKnowledgeTankByRollId_Result>)list);
					}
					break;
				case "prev":
					if (UserLogin.IsUserAccess("frmKnowledgeTankDataEntry", "actPrior", UserLogin.CurrentUser))
					{
						CS_0024_003C_003E8__locals0.knlg = Enumerable.FirstOrDefault<CRMspknlgSelectKnowledgeTankByRollId_Result>((IEnumerable<CRMspknlgSelectKnowledgeTankByRollId_Result>)list, (Func<CRMspknlgSelectKnowledgeTankByRollId_Result, bool>)((CRMspknlgSelectKnowledgeTankByRollId_Result c) => c.KnowledgeTankId > CS_0024_003C_003E8__locals0.knlgid)) ?? Enumerable.FirstOrDefault<CRMspknlgSelectKnowledgeTankByRollId_Result>((IEnumerable<CRMspknlgSelectKnowledgeTankByRollId_Result>)Enumerable.OrderByDescending<CRMspknlgSelectKnowledgeTankByRollId_Result, int>((IEnumerable<CRMspknlgSelectKnowledgeTankByRollId_Result>)list, (Func<CRMspknlgSelectKnowledgeTankByRollId_Result, int>)((CRMspknlgSelectKnowledgeTankByRollId_Result c) => c.KnowledgeTankId)));
					}
					break;
				case "first":
					if (UserLogin.IsUserAccess("frmKnowledgeTankDataEntry", "actFirst", UserLogin.CurrentUser))
					{
						CS_0024_003C_003E8__locals0.knlg = Enumerable.FirstOrDefault<CRMspknlgSelectKnowledgeTankByRollId_Result>((IEnumerable<CRMspknlgSelectKnowledgeTankByRollId_Result>)Enumerable.OrderByDescending<CRMspknlgSelectKnowledgeTankByRollId_Result, int>((IEnumerable<CRMspknlgSelectKnowledgeTankByRollId_Result>)list, (Func<CRMspknlgSelectKnowledgeTankByRollId_Result, int>)((CRMspknlgSelectKnowledgeTankByRollId_Result c) => c.KnowledgeTankId)));
					}
					break;
				case "last":
					if (UserLogin.IsUserAccess("frmKnowledgeTankDataEntry", "actLast", UserLogin.CurrentUser))
					{
						CS_0024_003C_003E8__locals0.knlg = Enumerable.FirstOrDefault<CRMspknlgSelectKnowledgeTankByRollId_Result>((IEnumerable<CRMspknlgSelectKnowledgeTankByRollId_Result>)list);
					}
					break;
				default:
					CS_0024_003C_003E8__locals0.knlg = Enumerable.FirstOrDefault<CRMspknlgSelectKnowledgeTankByRollId_Result>((IEnumerable<CRMspknlgSelectKnowledgeTankByRollId_Result>)db.CRMspknlgSelectKnowledgeTankByRollId(CS_0024_003C_003E8__locals0.knlgid, UserLogin.CurrentUser.RollId, lCID, result));
					break;
				}
			}
			DateTime now = DateTime.Now;
			if (CS_0024_003C_003E8__locals0.knlg == null)
			{
				CS_0024_003C_003E8__locals0.knlg = new CRMspknlgSelectKnowledgeTankByRollId_Result();
				CS_0024_003C_003E8__locals0.knlg.RegisterDate = now;
				CS_0024_003C_003E8__locals0.knlg.FirstRegisterDate = now;
				CS_0024_003C_003E8__locals0.knlg.KnowledgeTankId = 0;
			}
			cRMspKnlgSearchViewModel.KnowledgeTankId = CS_0024_003C_003E8__locals0.knlg.KnowledgeTankId;
			cRMspKnlgSearchViewModel.knlgTitle = CS_0024_003C_003E8__locals0.knlg.knlgTitle;
			cRMspKnlgSearchViewModel.knlgSigns = CS_0024_003C_003E8__locals0.knlg.knlgSigns;
			cRMspKnlgSearchViewModel.knlgKnowledge = CS_0024_003C_003E8__locals0.knlg.knlgKnowledge;
			cRMspKnlgSearchViewModel.knlgPriorityId = CS_0024_003C_003E8__locals0.knlg.knlgPriorityId;
			cRMspKnlgSearchViewModel.knowledgeTankPriorityTitle = CS_0024_003C_003E8__locals0.knlg.knowledgeTankPriorityTitle ?? "";
			cRMspKnlgSearchViewModel.knlgGroupId = CS_0024_003C_003E8__locals0.knlg.knlgGroupId;
			cRMspKnlgSearchViewModel.knowledgeTankGroupTitle = CS_0024_003C_003E8__locals0.knlg.knowledgeTankGroupTitle ?? "";
			cRMspKnlgSearchViewModel.FirstRegisterDate = CS_0024_003C_003E8__locals0.knlg.FirstRegisterDate;
			cRMspKnlgSearchViewModel.FirstRegisterDatePersian = CS_0024_003C_003E8__locals0.knlg.FirstRegisterDatePersian;
			cRMspKnlgSearchViewModel.FirstRegisterDatePersian = DateTimeClass.ConvertDateWOSlashToSlash(cRMspKnlgSearchViewModel.FirstRegisterDatePersian);
			cRMspKnlgSearchViewModel.UserId = CS_0024_003C_003E8__locals0.knlg.UserId;
			DbSet<Users> users = _dbTbl.Users;
			ParameterExpression val = Expression.Parameter(typeof(Users), "c");
			Queryable.FirstOrDefault<Users>((IQueryable<Users>)users, Expression.Lambda<Func<Users, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass268_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			cRMspKnlgSearchViewModel.EditedUser = CS_0024_003C_003E8__locals0.knlg.EditedUser ?? "";
			cRMspKnlgSearchViewModel.RegisterUser = CS_0024_003C_003E8__locals0.knlg.RegisterUser ?? "";
			cRMspKnlgSearchViewModel.RegisterDate = CS_0024_003C_003E8__locals0.knlg.RegisterDate;
			cRMspKnlgSearchViewModel.RegisterDatePersian = CS_0024_003C_003E8__locals0.knlg.RegisterDatePersian;
			cRMspKnlgSearchViewModel.RegisterDatePersian = DateTimeClass.ConvertDateWOSlashToSlash(cRMspKnlgSearchViewModel.RegisterDatePersian);
			cRMspKnlgSearchViewModel.EditedUser = Labels.frmRegisterUser + ": " + cRMspKnlgSearchViewModel.EditedUser;
			cRMspKnlgSearchViewModel.RegisterUser = Labels.frmFirstRegisterUser + ": " + cRMspKnlgSearchViewModel.RegisterUser;
			_ = CS_0024_003C_003E8__locals0.knlg.FirstRegisterDate;
			cRMspKnlgSearchViewModel.FirstRegisterDatePersian = CS_0024_003C_003E8__locals0.knlg.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
			_ = CS_0024_003C_003E8__locals0.knlg.RegisterDate;
			cRMspKnlgSearchViewModel.RegisterDatePersian = CS_0024_003C_003E8__locals0.knlg.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
			string appType = (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.knlg.AppType) ? Configuration.AppType : CS_0024_003C_003E8__locals0.knlg.AppType);
			cRMspKnlgSearchViewModel.AppType = Labels.AppType + ": " + Configuration.GetAppType(appType);
			cRMspKnlgSearchViewModel.EditedUser = cRMspKnlgSearchViewModel.EditedUser + " (" + cRMspKnlgSearchViewModel.AppType + ")";
			cRMspKnlgSearchViewModel.knlgFOCmpCanSee = CS_0024_003C_003E8__locals0.knlg.knlgFOCmpCanSee.GetValueOrDefault();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView(cRMspKnlgSearchViewModel);
	}

	[DynamicAuthorize(ControllerName = "frmKnowledgeTankDataEntry", ActionName = "actSetPermission")]
	public ActionResult CKnowledgeTankGroupPermission()
	{
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmKnowledgeTankDataEntry", ActionName = "actDelete")]
	public string CKnowledgeTankDelete(int ktId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string result2 = "-1";
		try
		{
			if (ktId > 0)
			{
				if (_dbTbl.CrmKnowledgeTank.Find(ktId) != null)
				{
					List<CRMspSelectFilesDirectory_Result> list = Files.SelectFilesDirectory("0", "0", "0", "40", ktId.ToString(), "0", "0", false);
					if (list != null)
					{
						if (list.Count == 0)
						{
							try
							{
								if (db.CRMspDeleteCrmKnowledgeTank(ktId) > 0)
								{
									result2 = "1";
								}
							}
							catch (DbEntityValidationException e)
							{
								ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
								result2 = Messages.RedundancyMessage;
							}
							catch (Exception ex)
							{
								ErrorSignal.FromCurrentContext().Raise(ex);
								result2 = Messages.msgErrorCommunicateWithServer + "<br><p style=text-align:left;>" + ex.Message + "</p>";
							}
						}
						else
						{
							result2 = Messages.RedundancyMessage;
						}
					}
					else
					{
						result2 = Messages.RedundancyMessage;
					}
				}
				else
				{
					result2 = Messages.ErrorNotFound;
				}
			}
			else
			{
				result2 = Messages.ErrorNotFound;
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			result2 = Messages.frmErrorMessage;
		}
		return result2;
	}

	[DynamicAuthorize(ControllerName = "frmKnowledgeTankDataEntry", ActionName = "actInsert")]
	public ActionResult CKnowledgeTankInsert()
	{
		KnowledgeTankLanguageViewModel knowledgeTankLanguageViewModel = new KnowledgeTankLanguageViewModel();
		knowledgeTankLanguageViewModel.UserId = UserLogin.CurrentUser.UserId;
		knowledgeTankLanguageViewModel.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
		DateTime now = DateTime.Now;
		knowledgeTankLanguageViewModel.Year1 = short.Parse(Financial.Get().Id.ToString());
		knowledgeTankLanguageViewModel.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
		knowledgeTankLanguageViewModel.RegisterDate = now;
		knowledgeTankLanguageViewModel.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
		knowledgeTankLanguageViewModel.FirstRegisterDate = now;
		knowledgeTankLanguageViewModel.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
		return View(knowledgeTankLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmKnowledgeTankDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult CKnowledgeTankInsert(KnowledgeTankLanguageViewModel model)
	{
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int countError = 0;
		try
		{
			if (base.ModelState.IsValid)
			{
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.knlgTitle_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.knlgTitle_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = model.knlgTitle,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.knlgSigns_Lang))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.knlgSigns_Lang);
				}
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = model.knlgSigns,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.knlgKnowledge_Lang))
				{
					list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.knlgKnowledge_Lang);
				}
				list3.Add(new CommonMultiLanguageViewModel
				{
					Value = model.knlgKnowledge,
					LanguageId = lCID
				});
				text = ChkBeforeSubmitKnlgTank_Lang(model, list, list2, list3, ref countError);
				if (countError == 0)
				{
					DateTime now = DateTime.Now;
					CrmKnowledgeTank crmKnowledgeTank = new CrmKnowledgeTank
					{
						UserId = UserLogin.CurrentUser.UserId,
						FirstRegisterUserId = UserLogin.CurrentUser.UserId,
						GUId = System.Guid.NewGuid(),
						AppType = Configuration.AppType,
						Year1 = short.Parse(Financial.Get().Id.ToString()),
						Month1 = short.Parse(now.ToString("MM", new PersianCulture())),
						RegisterDate = now,
						RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
						FirstRegisterDate = now,
						FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
						knlgGroupId = model.knlgGroupId,
						knlgPriorityId = model.knlgPriorityId,
						LanguageID = defLangID,
						knlgTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null),
						knlgSigns = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null),
						knlgKnowledge = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null)
					};
					if (UserLogin.IsUserAccess("frmKnowledgeTankDataEntry", "actCanSetFOCmpCanSeeInInsert", UserLogin.CurrentUser))
					{
						crmKnowledgeTank.knlgFOCmpCanSee = model.knlgFOCmpCanSee;
					}
					_dbTbl.CrmKnowledgeTank.Add(crmKnowledgeTank);
					_dbTbl.SaveChanges();
					model.KnowledgeTankId = crmKnowledgeTank.KnowledgeTankId;
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
					{
						CrmKnowledgeTank_Lang entity = new CrmKnowledgeTank_Lang
						{
							LanguageID = lang.LanguageID,
							KnowledgeTankId = crmKnowledgeTank.KnowledgeTankId,
							knlgTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
							knlgSigns = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
							knlgKnowledge = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null)
						};
						_dbTbl.CrmKnowledgeTank_Lang.Add(entity);
						_dbTbl.SaveChanges();
					}
					base.ViewBag.SuccessfullInsert = Messages.frmFormBaseInsertSuccessFulMessage;
				}
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			text = Messages.frmErrorMessage;
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text = Messages.frmErrorMessage + "<br/>" + ex.Message;
		}
		base.ViewBag.Error = text;
		return View(model);
	}

	public string ChkBeforeSubmitKnlgTank_Lang(KnowledgeTankLanguageViewModel KnlgTank, List<CommonMultiLanguageViewModel> listModelObj_knlgTitle_Lang, List<CommonMultiLanguageViewModel> listModelObj_knlgSigns_Lang, List<CommonMultiLanguageViewModel> listModelObj_knlgKnowledge_Lang, ref int countError)
	{
		string text = "";
		if (string.IsNullOrEmpty(KnlgTank.knlgTitle))
		{
			text = text + Messages.CheckEmptyKnlgTitle + "|";
			countError++;
		}
		else if (!checkMultiLanguage(KnlgTank.knlgTitle, listModelObj_knlgTitle_Lang))
		{
			text = text + Messages.CheckKnlgTitleLang + "<br>";
			countError++;
		}
		if (KnlgTank.knlgGroupId == 0)
		{
			text += Messages.CheckEmptyKnlgGroupId;
			countError++;
		}
		if (string.IsNullOrEmpty(KnlgTank.knlgKnowledge))
		{
			text = text + Messages.CheckEmptyKnlgKnowledge + "|";
			countError++;
		}
		else if (!checkMultiLanguage(KnlgTank.knlgKnowledge, listModelObj_knlgKnowledge_Lang))
		{
			text = text + Messages.CheckKnlgKnowledgeLang + "<br>";
			countError++;
		}
		return text;
	}

	[DynamicAuthorize(ControllerName = "frmKnowledgeTankDataEntry", ActionName = "actEdit")]
	public ActionResult CKnowledgeTankEdit(int ktid)
	{
		_003C_003Ec__DisplayClass274_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass274_0();
		CS_0024_003C_003E8__locals0.ktid = ktid;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		DbSet<CrmKnowledgeTank_Lang> crmKnowledgeTank_Lang = _dbTbl.CrmKnowledgeTank_Lang;
		ParameterExpression val = Expression.Parameter(typeof(CrmKnowledgeTank_Lang), "c");
		List<CrmKnowledgeTank_Lang> list = Enumerable.ToList<CrmKnowledgeTank_Lang>((IEnumerable<CrmKnowledgeTank_Lang>)Queryable.Where<CrmKnowledgeTank_Lang>((IQueryable<CrmKnowledgeTank_Lang>)crmKnowledgeTank_Lang, Expression.Lambda<Func<CrmKnowledgeTank_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass274_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
		KnowledgeTankLanguageViewModel model = new KnowledgeTankLanguageViewModel();
		CrmKnowledgeTank crmKnowledgeTank = new CrmKnowledgeTank();
		try
		{
			crmKnowledgeTank = _dbTbl.CrmKnowledgeTank.Find(CS_0024_003C_003E8__locals0.ktid);
			if (crmKnowledgeTank != null)
			{
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmKnowledgeTank_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmKnowledgeTank_Lang>)list, (Func<CrmKnowledgeTank_Lang, CommonMultiLanguageViewModel>)((CrmKnowledgeTank_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.knlgTitle,
					LanguageId = item.LanguageID
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = crmKnowledgeTank.knlgTitle,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmKnowledgeTank_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmKnowledgeTank_Lang>)list, (Func<CrmKnowledgeTank_Lang, CommonMultiLanguageViewModel>)((CrmKnowledgeTank_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.knlgSigns,
					LanguageId = item.LanguageID
				})));
				list3.Add(new CommonMultiLanguageViewModel
				{
					Value = crmKnowledgeTank.knlgSigns,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmKnowledgeTank_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmKnowledgeTank_Lang>)list, (Func<CrmKnowledgeTank_Lang, CommonMultiLanguageViewModel>)((CrmKnowledgeTank_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.knlgKnowledge,
					LanguageId = item.LanguageID
				})));
				list4.Add(new CommonMultiLanguageViewModel
				{
					Value = crmKnowledgeTank.knlgKnowledge,
					LanguageId = result
				});
				DateTime now = DateTime.Now;
				model = new KnowledgeTankLanguageViewModel
				{
					UserId = UserLogin.CurrentUser.UserId,
					Year1 = short.Parse(Financial.Get().Id.ToString()),
					Month1 = short.Parse(now.ToString("MM", new PersianCulture())),
					RegisterDate = now,
					RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
					KnowledgeTankId = CS_0024_003C_003E8__locals0.ktid,
					LanguageID = crmKnowledgeTank.LanguageID,
					knlgGroupId = crmKnowledgeTank.knlgGroupId,
					knlgPriorityId = crmKnowledgeTank.knlgPriorityId,
					AppType = crmKnowledgeTank.AppType,
					GUId = crmKnowledgeTank.GUId,
					FirstRegisterDate = crmKnowledgeTank.FirstRegisterDate,
					FirstRegisterUserId = crmKnowledgeTank.FirstRegisterUserId,
					FirstRegisterDatePersian = crmKnowledgeTank.FirstRegisterDatePersian,
					knlgTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					knlgSigns = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					knlgKnowledge = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					knlgTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					knlgSigns_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					knlgKnowledge_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					knlgFOCmpCanSee = crmKnowledgeTank.knlgFOCmpCanSee.GetValueOrDefault()
				};
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(model);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmKnowledgeTankDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult CKnowledgeTankEdit(KnowledgeTankLanguageViewModel model)
	{
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int countError = 0;
		try
		{
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.knlgTitle_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.knlgTitle_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = model.knlgTitle,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.knlgSigns_Lang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.knlgSigns_Lang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = model.knlgSigns,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.knlgKnowledge_Lang))
			{
				list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.knlgKnowledge_Lang);
			}
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = model.knlgKnowledge,
				LanguageId = lCID
			});
			if (base.ModelState.IsValid)
			{
				text = ChkBeforeSubmitKnlgTank_Lang(model, list, list2, list3, ref countError);
				if (countError == 0)
				{
					_003C_003Ec__DisplayClass275_1 _003C_003Ec__DisplayClass275_ = new _003C_003Ec__DisplayClass275_1();
					_003C_003Ec__DisplayClass275_.KnlgTank = _dbTbl.CrmKnowledgeTank.Find(model.KnowledgeTankId);
					_003C_003Ec__DisplayClass275_.KnlgTank.UserId = UserLogin.CurrentUser.UserId;
					_003C_003Ec__DisplayClass275_.KnlgTank.AppType = Configuration.AppType;
					DateTime now = DateTime.Now;
					_003C_003Ec__DisplayClass275_.KnlgTank.Year1 = short.Parse(Financial.Get().Id.ToString());
					_003C_003Ec__DisplayClass275_.KnlgTank.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
					_003C_003Ec__DisplayClass275_.KnlgTank.RegisterDate = now;
					_003C_003Ec__DisplayClass275_.KnlgTank.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					_003C_003Ec__DisplayClass275_.KnlgTank.knlgPriorityId = model.knlgPriorityId;
					if (_003C_003Ec__DisplayClass275_.KnlgTank.knlgPriorityId == 0)
					{
						_003C_003Ec__DisplayClass275_.KnlgTank.knlgPriorityId = null;
					}
					_003C_003Ec__DisplayClass275_.KnlgTank.knlgGroupId = model.knlgGroupId;
					_003C_003Ec__DisplayClass275_.KnlgTank.knlgTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					_003C_003Ec__DisplayClass275_.KnlgTank.knlgSigns = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					_003C_003Ec__DisplayClass275_.KnlgTank.knlgKnowledge = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					if (UserLogin.IsUserAccess("frmKnowledgeTankDataEntry", "actCanSetFOCmpCanSeeInEdit", UserLogin.CurrentUser))
					{
						_003C_003Ec__DisplayClass275_.KnlgTank.knlgFOCmpCanSee = model.knlgFOCmpCanSee;
					}
					_dbTbl.Entry(_003C_003Ec__DisplayClass275_.KnlgTank).State = EntityState.Modified;
					_dbTbl.SaveChanges();
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass275_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass275_2();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass275_;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							DbSet<CrmKnowledgeTank_Lang> crmKnowledgeTank_Lang = _dbTbl.CrmKnowledgeTank_Lang;
							ParameterExpression val = Expression.Parameter(typeof(CrmKnowledgeTank_Lang), "c");
							CrmKnowledgeTank_Lang crmKnowledgeTank_Lang2 = Queryable.FirstOrDefault<CrmKnowledgeTank_Lang>((IQueryable<CrmKnowledgeTank_Lang>)crmKnowledgeTank_Lang, Expression.Lambda<Func<CrmKnowledgeTank_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass275_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass275_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (crmKnowledgeTank_Lang2 != null)
							{
								crmKnowledgeTank_Lang2.knlgTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmKnowledgeTank_Lang2.knlgSigns = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmKnowledgeTank_Lang2.knlgKnowledge = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(crmKnowledgeTank_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							CrmKnowledgeTank_Lang entity = new CrmKnowledgeTank_Lang
							{
								LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
								KnowledgeTankId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.KnlgTank.KnowledgeTankId,
								knlgTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
								knlgSigns = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
								knlgKnowledge = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
							};
							_dbTbl.CrmKnowledgeTank_Lang.Add(entity);
							_dbTbl.SaveChanges();
						}
					}
					base.ViewBag.SuccessfullEdit = Messages.UeserTasksEditSuccessFulMessage;
				}
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			text = Messages.frmErrorMessage;
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text = Messages.frmErrorMessage + "<br/>" + ex.Message;
		}
		base.ViewBag.Error = text;
		return View(model);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actcReminder")]
	public ActionResult CReminder()
	{
		base.ViewBag.CurrWeekDates = GetDatesOfWeek();
		base.ViewBag.UserTasksRepeats = GetPrivateRemindesRepeats(0, "", 0, 0, -1);
		base.ViewBag.CurrHour = DateTime.Now.Hour;
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
		List<SelectListItem> list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectUserForLinkedType_Result, SelectListItem>((IEnumerable<CRMspSelectUserForLinkedType_Result>)Enumerable.ToList<CRMspSelectUserForLinkedType_Result>((IEnumerable<CRMspSelectUserForLinkedType_Result>)db.CRMspSelectUserForLinkedType(UserLogin.CurrentUser.UserId, 30, lCID, result, result2)), (Func<CRMspSelectUserForLinkedType_Result, SelectListItem>)((CRMspSelectUserForLinkedType_Result priority) => new SelectListItem
		{
			Text = priority.UserName,
			Value = priority.LinkedUserId.ToString()
		})));
		list.Insert(0, new SelectListItem
		{
			Text = Labels.AllUsers,
			Value = "-1"
		});
		base.ViewBag.Users = list;
		List<CRMspSelectUserTaskPriorities_Result> list2 = Enumerable.ToList<CRMspSelectUserTaskPriorities_Result>(Enumerable.Where<CRMspSelectUserTaskPriorities_Result>((IEnumerable<CRMspSelectUserTaskPriorities_Result>)Enumerable.ToList<CRMspSelectUserTaskPriorities_Result>((IEnumerable<CRMspSelectUserTaskPriorities_Result>)db.CRMspSelectUserTaskPriorities(lCID, result)), (Func<CRMspSelectUserTaskPriorities_Result, bool>)((CRMspSelectUserTaskPriorities_Result ut) => ut.UserId == UserLogin.CurrentUser.UserId)));
		base.ViewBag.Priorities = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectUserTaskPriorities_Result, SelectListItem>((IEnumerable<CRMspSelectUserTaskPriorities_Result>)list2, (Func<CRMspSelectUserTaskPriorities_Result, SelectListItem>)((CRMspSelectUserTaskPriorities_Result priority) => new SelectListItem
		{
			Text = priority.Priority,
			Value = priority.UserTaskPriorityId.ToString()
		})));
		List<CRMspSelectUserTaskGroups_Result> list3 = Enumerable.ToList<CRMspSelectUserTaskGroups_Result>(Enumerable.Where<CRMspSelectUserTaskGroups_Result>((IEnumerable<CRMspSelectUserTaskGroups_Result>)Enumerable.ToList<CRMspSelectUserTaskGroups_Result>((IEnumerable<CRMspSelectUserTaskGroups_Result>)db.CRMspSelectUserTaskGroups(lCID, result)), (Func<CRMspSelectUserTaskGroups_Result, bool>)((CRMspSelectUserTaskGroups_Result ut) => ut.UserId == UserLogin.CurrentUser.UserId)));
		base.ViewBag.Groups = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectUserTaskGroups_Result, SelectListItem>((IEnumerable<CRMspSelectUserTaskGroups_Result>)list3, (Func<CRMspSelectUserTaskGroups_Result, SelectListItem>)((CRMspSelectUserTaskGroups_Result priority) => new SelectListItem
		{
			Text = priority.UserTaskGroup,
			Value = priority.UserTaskGroupId.ToString()
		})));
		base.ViewBag.DidItStatuses = new List<SelectListItem>
		{
			new SelectListItem
			{
				Text = Labels.All,
				Value = "-1"
			},
			new SelectListItem
			{
				Text = Labels.TxtIsNotDone,
				Value = "0"
			},
			new SelectListItem
			{
				Text = Labels.TxtIsDone,
				Value = "1"
			}
		};
		return View();
	}

	[AjaxOnly]
	public ActionResult _PartialCReminder(string cRDate, bool isShowTicket)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		cRDate = cRDate.Replace("/", "");
		int result2 = 0;
		int.TryParse(cRDate, out result2);
		if (result2 <= 0)
		{
			cRDate = DateTime.Now.ToString("yyyyMMdd");
			int.TryParse(cRDate, out result2);
		}
		DateTime value = DateTime.Parse(PersianDate.GetFormatetdDate(cRDate.Replace("/", "")) + " 23:59:59");
		try
		{
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			List<CRMspUserTreeReminderCartable_Result> list = Enumerable.ToList<CRMspUserTreeReminderCartable_Result>((IEnumerable<CRMspUserTreeReminderCartable_Result>)db.CRMspUserTreeReminderCartable(UserLogin.CurrentUser.UserId, 1, result2, value, Labels.AllUsers, lCID, result, isShowTicket, result3));
			List<TreeViewItemModel> list2 = new List<TreeViewItemModel>
			{
				new TreeViewItemModel
				{
					HtmlAttributes = 
					{
						new KeyValuePair<string, string>("accesskey", "-1|-1")
					},
					Id = "-1|-1",
					Text = Labels.Empty,
					ImageUrl = "",
					Items = null
				}
			};
			foreach (CRMspUserTreeReminderCartable_Result item in list)
			{
				TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
				treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.RootId + "|" + item.KeyId));
				treeViewItemModel.Id = item.RootId + "|" + item.KeyId;
				treeViewItemModel.Text = item.KeyName;
				treeViewItemModel.ImageUrl = "";
				treeViewItemModel.Items = null;
				list2.Add(treeViewItemModel);
			}
			base.ViewBag.CReminderTree = list2;
			base.ViewBag.reminderId = UserLogin.CurrentUser.UserId;
			base.ViewBag.cRDate = result2;
			base.ViewBag.RemindIdDate = UserLogin.CurrentUser.UserId + "|" + result2;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult _PartialCReminderGrid(int reminderId, string cRDate, bool isShowTicket)
	{
		if (reminderId == 0)
		{
			reminderId = UserLogin.CurrentUser.UserId;
		}
		string text = ((!(cRDate == "")) ? cRDate.Replace("/", "") : DateTime.Now.ToString("yyyyMMdd"));
		base.ViewBag.RemindIdDate = reminderId + "|" + text + "|" + isShowTicket;
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult CReminder_Read([DataSourceRequest] DataSourceRequest request, string RemindIdDate)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspResultsReminderCartable_Result> list = new List<CRMspResultsReminderCartable_Result>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			string[] array = RemindIdDate.Split(new char[1] { '|' });
			DateTime value = DateTime.Parse(PersianDate.GetFormatetdDate(((array[1] == "") ? DateTime.Now.ToString("yyyyMMdd") : array[1].Replace("/", "")).Replace("/", "")) + " 23:59:59");
			int.TryParse(array[0], out var TreeKeyId);
			bool result3 = false;
			if (Enumerable.Count<string>((IEnumerable<string>)array) >= 3)
			{
				bool.TryParse(array[2], out result3);
			}
			list = ((TreeKeyId != 0 && TreeKeyId != -1) ? Enumerable.ToList<CRMspResultsReminderCartable_Result>(Enumerable.Where<CRMspResultsReminderCartable_Result>((IEnumerable<CRMspResultsReminderCartable_Result>)db.CRMspResultsReminderCartable(UserLogin.CurrentUser.UserId, value, lCID, result, result3, result2), (Func<CRMspResultsReminderCartable_Result, bool>)((CRMspResultsReminderCartable_Result c) => c.cnvsReferUserId == TreeKeyId))) : Enumerable.ToList<CRMspResultsReminderCartable_Result>((IEnumerable<CRMspResultsReminderCartable_Result>)db.CRMspResultsReminderCartable(UserLogin.CurrentUser.UserId, value, lCID, result, result3, result2)));
			foreach (CRMspResultsReminderCartable_Result item in list)
			{
				item.RemindDate = ConverDateTimeToDate(item.RemindDateTime);
				item.cnvsDate = ConverDateTimeToDate(item.cnvsDateTime);
				item.RegisterDatePersian = ConverDateTimeToDate(item.RegisterDate);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	public string ConverDateTimeToDate(DateTime? date, string format = "yyyy/MM/dd")
	{
		DateTime result = default(DateTime);
		string result2 = "";
		if (date.HasValue)
		{
			DateTime.TryParse(date.ToString(), out result);
			result2 = result.ToString(format);
		}
		return result2;
	}

	[HttpPost]
	[LoginAuthorize]
	public List<CRMspUserTreeReminderCartableWeb_Result> UserTreeReminderCartable(string selectedDate = "", bool isShowTicket = false)
	{
		List<CRMspUserTreeReminderCartableWeb_Result> result = new List<CRMspUserTreeReminderCartableWeb_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			short.Parse(Financial.Get().Id.ToString());
			_ = Financial.Get().Id;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			if (!string.IsNullOrWhiteSpace(selectedDate))
			{
				selectedDate = selectedDate.Replace("/", "");
				int result4 = 0;
				int.TryParse(selectedDate, out result4);
				if (result4 <= 0)
				{
					selectedDate = DateTime.Now.ToString("yyyyMMdd");
					int.TryParse(selectedDate, out result4);
				}
				DateTime value = DateTime.Parse(PersianDate.GetFormatetdDate(selectedDate.Replace("/", "")) + " 23:59:59");
				List<CRMspUserTreeReminderCartableWeb_Result> list = Enumerable.ToList<CRMspUserTreeReminderCartableWeb_Result>((IEnumerable<CRMspUserTreeReminderCartableWeb_Result>)_dbI.CRMspUserTreeReminderCartableWeb(userId, 1, result4, value, Labels.AllUsers, isShowTicket, lCID, result2, result3));
				if (list != null)
				{
					result = list;
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string UserTreeReminderCartableJs(string selectedDate = "", bool isShowTicket = false)
	{
		return JsonConvert.SerializeObject(UserTreeReminderCartable(selectedDate, isShowTicket));
	}

	[HttpPost]
	[LoginAuthorize]
	public List<CRMspResultsReminderCartableWeb_Result> LoadUserReminders(int userId = 0, string selectedDate = "", bool? isShowTicket = false, int lastRowNumber = 0, int pageSize = 300)
	{
		List<CRMspResultsReminderCartableWeb_Result> result = new List<CRMspResultsReminderCartableWeb_Result>();
		try
		{
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
			DateTime value = DateTime.Parse(PersianDate.GetFormatetdDate(selectedDate.Replace("/", "")) + " 23:59:59");
			List<CRMspResultsReminderCartableWeb_Result> list = Enumerable.ToList<CRMspResultsReminderCartableWeb_Result>((IEnumerable<CRMspResultsReminderCartableWeb_Result>)dbI.CRMspResultsReminderCartableWeb(UserLogin.CurrentUser.UserId, userId, value, lCID, result2, isShowTicket, lastRowNumber, pageSize, false, result3));
			if (list != null)
			{
				foreach (CRMspResultsReminderCartableWeb_Result item in list)
				{
					List<CRMspResultsReminderCartableWeb_Result> list2 = JsonConvert.DeserializeObject<List<CRMspResultsReminderCartableWeb_Result>>(item.CmpJs);
					if (list2 != null)
					{
						CRMspResultsReminderCartableWeb_Result cRMspResultsReminderCartableWeb_Result = Enumerable.FirstOrDefault<CRMspResultsReminderCartableWeb_Result>((IEnumerable<CRMspResultsReminderCartableWeb_Result>)list2);
						item.CompanyID = cRMspResultsReminderCartableWeb_Result.CompanyID;
						item.CompanyName = cRMspResultsReminderCartableWeb_Result.CompanyName;
						item.cmpPreTel = cRMspResultsReminderCartableWeb_Result.cmpPreTel;
						item.cmpTel = cRMspResultsReminderCartableWeb_Result.cmpTel;
						item.cmpTelUpTo = cRMspResultsReminderCartableWeb_Result.cmpTelUpTo;
						item.cmpTelDesc = cRMspResultsReminderCartableWeb_Result.cmpTelDesc;
						item.cmpPreTelII = cRMspResultsReminderCartableWeb_Result.cmpPreTelII;
						item.cmpTelII = cRMspResultsReminderCartableWeb_Result.cmpTelII;
						item.cmpTelUpToII = cRMspResultsReminderCartableWeb_Result.cmpTelUpToII;
						item.cmpTelIIDesc = cRMspResultsReminderCartableWeb_Result.cmpTelIIDesc;
						item.cmpFax = cRMspResultsReminderCartableWeb_Result.cmpFax;
						item.cmpFaxDesc = cRMspResultsReminderCartableWeb_Result.cmpFaxDesc;
						item.cmpSpecialPoint = cRMspResultsReminderCartableWeb_Result.cmpSpecialPoint;
						item.cmpSpecialWordForCI = cRMspResultsReminderCartableWeb_Result.cmpSpecialWordForCI;
						item.cmpCountryId = cRMspResultsReminderCartableWeb_Result.cmpCountryId;
						item.Country = cRMspResultsReminderCartableWeb_Result.Country;
						item.cmpProvinceId = cRMspResultsReminderCartableWeb_Result.cmpProvinceId;
						item.Province = cRMspResultsReminderCartableWeb_Result.Province;
						item.cmpCityId = cRMspResultsReminderCartableWeb_Result.cmpCityId;
						item.City = cRMspResultsReminderCartableWeb_Result.City;
						item.cmpAddress = cRMspResultsReminderCartableWeb_Result.cmpAddress;
						item.cmpPresentation = cRMspResultsReminderCartableWeb_Result.cmpPresentation;
					}
					List<CRMspResultsReminderCartableWeb_Result> list3 = JsonConvert.DeserializeObject<List<CRMspResultsReminderCartableWeb_Result>>(item.PrsJs);
					if (list3 != null)
					{
						CRMspResultsReminderCartableWeb_Result cRMspResultsReminderCartableWeb_Result2 = Enumerable.FirstOrDefault<CRMspResultsReminderCartableWeb_Result>((IEnumerable<CRMspResultsReminderCartableWeb_Result>)list3);
						item.Person = cRMspResultsReminderCartableWeb_Result2.Person;
						item.prsPreTel = cRMspResultsReminderCartableWeb_Result2.prsPreTel;
						item.prsTel = cRMspResultsReminderCartableWeb_Result2.prsTel;
						item.prsTelUpTo = cRMspResultsReminderCartableWeb_Result2.prsTelUpTo;
						item.prsTelDesc = cRMspResultsReminderCartableWeb_Result2.prsTelDesc;
						item.prsMobile = cRMspResultsReminderCartableWeb_Result2.prsMobile;
						item.prsJobId = cRMspResultsReminderCartableWeb_Result2.prsJobId;
						item.prsJob = cRMspResultsReminderCartableWeb_Result2.prsJob;
					}
					List<CRMspResultsReminderCartableWeb_Result> list4 = JsonConvert.DeserializeObject<List<CRMspResultsReminderCartableWeb_Result>>(item.PrjJs);
					if (list4 != null)
					{
						CRMspResultsReminderCartableWeb_Result cRMspResultsReminderCartableWeb_Result3 = Enumerable.FirstOrDefault<CRMspResultsReminderCartableWeb_Result>((IEnumerable<CRMspResultsReminderCartableWeb_Result>)list4);
						item.prjTitle = cRMspResultsReminderCartableWeb_Result3.prjTitle;
						item.ProjectID = cRMspResultsReminderCartableWeb_Result3.ProjectID;
					}
					item.RemindDate = ConverDateTimeToDate(item.RemindDateTime);
					item.cnvsDate = ConverDateTimeToDate(item.cnvsDateTime, "yyyy/MM/dd HH:mm");
					item.RegisterDatePersian = ConverDateTimeToDate(item.RegisterDate, "yyyy/MM/dd HH:mm");
				}
				result = list;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string LoadUserRemindersJs(int userId = 0, string selectedDate = "", bool? isShowTicket = false, int lastRowNumber = 0, int pageSize = 300)
	{
		return JsonConvert.SerializeObject(LoadUserReminders(userId, selectedDate, isShowTicket, lastRowNumber, pageSize));
	}

	public List<CRMspSelectUserReminderCartable_Result> SelectUserReminderCartable()
	{
		List<CRMspSelectUserReminderCartable_Result> result = new List<CRMspSelectUserReminderCartable_Result>();
		try
		{
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
			result = Enumerable.ToList<CRMspSelectUserReminderCartable_Result>((IEnumerable<CRMspSelectUserReminderCartable_Result>)dbI.CRMspSelectUserReminderCartable(UserLogin.CurrentUser.UserId, 1, null, null, Labels.AllUsers, lCID, result2, null, result3));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public List<SelectListItem> SelectUserReminderCartable_SelectListItem(int selectedId = 0)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<CRMspSelectUserReminderCartable_Result> list2 = SelectUserReminderCartable();
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<CRMspSelectUserReminderCartable_Result, SelectListItem>((IEnumerable<CRMspSelectUserReminderCartable_Result>)list2, (Func<CRMspSelectUserReminderCartable_Result, SelectListItem>)((CRMspSelectUserReminderCartable_Result x) => new SelectListItem
				{
					Text = x.KeyName,
					Value = x.KeyId.ToString(),
					Selected = (x.KeyId == selectedId)
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public List<CRMspSelectUserForLinkedType_Result> SelectUserForLinkedType()
	{
		List<CRMspSelectUserForLinkedType_Result> result = new List<CRMspSelectUserForLinkedType_Result>();
		try
		{
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
			result = Enumerable.ToList<CRMspSelectUserForLinkedType_Result>((IEnumerable<CRMspSelectUserForLinkedType_Result>)db.CRMspSelectUserForLinkedType(UserLogin.CurrentUser.UserId, 30, lCID, result2, result3));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public List<SelectListItem> SelectUserForLinkedType_SelectListItem(int selectedId = 0)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		List<CRMspSelectUserForLinkedType_Result> list2 = SelectUserForLinkedType();
		if (list2 != null && list2.Count > 0)
		{
			list.AddRange(Enumerable.Select<CRMspSelectUserForLinkedType_Result, SelectListItem>((IEnumerable<CRMspSelectUserForLinkedType_Result>)list2, (Func<CRMspSelectUserForLinkedType_Result, SelectListItem>)((CRMspSelectUserForLinkedType_Result x) => new SelectListItem
			{
				Text = (x.UserName ?? ""),
				Value = x.LinkedUserId.ToString(),
				Selected = (x.LinkedUserId == selectedId)
			})));
		}
		return list;
	}

	public string SelectUserForLinkedType_SelectListItemJs(int selectedId = 0)
	{
		return JsonConvert.SerializeObject(SelectUserForLinkedType_SelectListItem(selectedId));
	}

	[LoginAuthorize]
	[HttpPost]
	public JsonResult GetPrivateRemindes(string date = "", int userId = -1, bool selectWithCnvs = false, int? groupId = 0, int? priorityId = 0, int? didItStatus = -1)
	{
		List<CRMspLoadUserTasksWeb_Result> list = new List<CRMspLoadUserTasksWeb_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			_ = DateTime.Now;
			if (!string.IsNullOrWhiteSpace(date))
			{
				DateTime dateTime = default(DateTime);
				string text = "";
				try
				{
					if (!string.IsNullOrEmpty(date))
					{
						text = PersianDate.GetFormatetdDate(date.Replace("/", ""));
						switch (lCID)
						{
						case 1065:
							dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
							break;
						case 1025:
							dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
							break;
						default:
							dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
							break;
						}
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
			}
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CommonSelectListItemViewModel> datesOfWeekSelectListItemFromSp = GetDatesOfWeekSelectListItemFromSp(date);
			if (datesOfWeekSelectListItemFromSp != null)
			{
				foreach (CommonSelectListItemViewModel item in datesOfWeekSelectListItemFromSp)
				{
					DateTime value = default(DateTime);
					string text2 = "";
					try
					{
						if (!string.IsNullOrEmpty(item.Text))
						{
							text2 = PersianDate.GetFormatetdDate(item.Text.Replace("/", ""));
							value = lCID switch
							{
								1065 => DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()), 
								1025 => DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")), 
								_ => DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")), 
							};
						}
					}
					catch (Exception e2)
					{
						ErrorSignal.FromCurrentContext().Raise(e2);
					}
					List<CRMspLoadUserTasksWeb_Result> list2 = Enumerable.ToList<CRMspLoadUserTasksWeb_Result>((IEnumerable<CRMspLoadUserTasksWeb_Result>)_dbI.CRMspLoadUserTasksWeb(value, userId, lCID, result, selectWithCnvs, UserLogin.CurrentUser.UserId, result2, groupId, priorityId, didItStatus));
					if (list2 != null)
					{
						list.AddRange(list2);
					}
				}
			}
			if (list != null)
			{
				foreach (CRMspLoadUserTasksWeb_Result item2 in list)
				{
					if (!string.IsNullOrWhiteSpace(item2.TaskPriorityColor) && item2.TaskPriorityColor.Contains("$"))
					{
						item2.TaskPriorityColor = TColorToHex(item2.TaskPriorityColor);
					}
					item2.UserTaskDatePersian = ((!item2.UserTaskDate.HasValue) ? "" : item2.UserTaskDate?.ToString("yyyy/MM/dd"));
					item2.UserTaskRemindDate = ((!item2.UserTaskRemindDateTime.HasValue) ? "" : item2.UserTaskRemindDateTime?.ToString("yyyy/MM/dd"));
					item2.UserTaskDidItDatePersian = ((!item2.UserTaskDidItDate.HasValue) ? "" : item2.UserTaskDidItDate?.ToString("yyyy/MM/dd"));
					item2.UserTaskDateEndPersian = ((!item2.UserTaskDateEnd.HasValue) ? "" : item2.UserTaskDateEnd?.ToString("yyyy/MM/dd"));
					if (string.IsNullOrEmpty(item2.UserTaskDidItInfoJson))
					{
						continue;
					}
					Dictionary<string, string> dictionary = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(item2.UserTaskDidItInfoJson);
					if (dictionary == null || !Enumerable.Any<KeyValuePair<string, string>>((IEnumerable<KeyValuePair<string, string>>)dictionary))
					{
						continue;
					}
					Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
					foreach (KeyValuePair<string, string> item3 in dictionary)
					{
						if (DateTime.TryParseExact(item3.Key, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var result3))
						{
							string key = result3.ToString("yyyy/MM/dd");
							dictionary2[key] = item3.Value;
						}
						else
						{
							dictionary2[item3.Key] = item3.Value;
						}
					}
					item2.UserTaskDidItInfoJson = System.Text.Json.JsonSerializer.Serialize(dictionary2);
				}
			}
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[LoginAuthorize]
	public string GetPrivateRemindesRepeats(int userId = 0, string date = "", int? groupId = 0, int? priorityId = 0, int? didItStatus = -1)
	{
		List<CRMspSelectUserTasksRepeats_Result> list = new List<CRMspSelectUserTasksRepeats_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (!string.IsNullOrWhiteSpace(date))
			{
				date = Enumerable.LastOrDefault<CommonSelectListItemViewModel>((IEnumerable<CommonSelectListItemViewModel>)GetDatesOfWeekSelectListItemFromSp(date)).Text;
			}
			DateTime value = DateTime.Now;
			if (!string.IsNullOrWhiteSpace(date))
			{
				DateTime dateTime = default(DateTime);
				string text = "";
				try
				{
					if (!string.IsNullOrEmpty(date))
					{
						text = PersianDate.GetFormatetdDate(date.Replace("/", ""));
						value = lCID switch
						{
							1065 => DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()), 
							1025 => DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")), 
							_ => DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")), 
						};
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
			}
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (userId != 0)
			{
				list = Enumerable.ToList<CRMspSelectUserTasksRepeats_Result>((IEnumerable<CRMspSelectUserTasksRepeats_Result>)_dbI.CRMspSelectUserTasksRepeats(userId, value, lCID, result, result2, groupId, priorityId, didItStatus, UserLogin.CurrentUser.UserId));
				if (list != null)
				{
					foreach (CRMspSelectUserTasksRepeats_Result item in list)
					{
						if (!string.IsNullOrWhiteSpace(item.TaskPriorityColor) && item.TaskPriorityColor.Contains("$"))
						{
							item.TaskPriorityColor = TColorToHex(item.TaskPriorityColor);
						}
						_ = item.UserTaskDate;
						item.UserTaskDatePersian = item.UserTaskDate.ToString("yyyy/MM/dd");
						item.UserTaskRemindDate = ((!item.UserTaskRemindDateTime.HasValue) ? "" : item.UserTaskRemindDateTime?.ToString("yyyy/MM/dd"));
						item.UserTaskDidItDatePersian = ((!item.UserTaskDidItDate.HasValue) ? "" : item.UserTaskDidItDate?.ToString("yyyy/MM/dd"));
						item.UserTaskDateEndPersian = ((!item.UserTaskDateEnd.HasValue) ? "" : item.UserTaskDateEnd?.ToString("yyyy/MM/dd"));
						if (string.IsNullOrEmpty(item.UserTaskDidItInfoJson))
						{
							continue;
						}
						Dictionary<string, string> dictionary = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(item.UserTaskDidItInfoJson);
						if (dictionary == null || !Enumerable.Any<KeyValuePair<string, string>>((IEnumerable<KeyValuePair<string, string>>)dictionary))
						{
							continue;
						}
						Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
						foreach (KeyValuePair<string, string> item2 in dictionary)
						{
							if (DateTime.TryParseExact(item2.Key, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var result3))
							{
								string key = result3.ToString("yyyy/MM/dd");
								dictionary2[key] = item2.Value;
							}
							else
							{
								dictionary2[item2.Key] = item2.Value;
							}
						}
						item.UserTaskDidItInfoJson = System.Text.Json.JsonSerializer.Serialize(dictionary2);
					}
				}
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return JsonConvert.SerializeObject(list);
	}

	[LoginAuthorize]
	[HttpPost]
	public List<SelectListItem> GetDatesOfWeek_SelectListItem(string date = "")
	{
		List<SelectListItem> list = new List<SelectListItem>();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		DateTime dateTime = DateTime.Today;
		if (lCID == 1025)
		{
			dateTime = dateTime.AddDays(-1.0);
		}
		DateTime dateTime2 = DateTimeClass.GetDateFromPersian(date) ?? DateTime.Now;
		int num = 0;
		switch (lCID)
		{
		case 1065:
			num = 1;
			break;
		case 1033:
			num = 1;
			break;
		}
		int dayOfWeek = (int)dateTime2.DayOfWeek;
		DateTime dateTime3 = dateTime2.AddDays(-1 * dayOfWeek - num);
		for (int i = 0; i < 7; i++)
		{
			list.Add(new SelectListItem
			{
				Text = dateTime3.AddDays(i).ToString("yyyy/MM/dd"),
				Value = ((int)dateTime3.AddDays(i).DayOfWeek).ToString(),
				Selected = (dateTime3.AddDays(i).ToString("yyyy/MM/dd") == dateTime.ToString("yyyy/MM/dd"))
			});
		}
		return list;
	}

	[LoginAuthorize]
	[HttpPost]
	public static List<CommonSelectListItemViewModel> GetDatesOfWeekSelectListItemFromSp(string date = "")
	{
		CRMSpIIEntities cRMSpIIEntities = null;
		List<CommonSelectListItemViewModel> list = new List<CommonSelectListItemViewModel>();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		DateTime today = DateTime.Today;
		int value = ((lCID != 1065 && lCID != 1025) ? 1 : 7);
		if (string.IsNullOrWhiteSpace(date))
		{
			date = DateTime.Now.ToString("yyyy/MM/dd");
		}
		DateTime value2 = default(DateTime);
		string text = "";
		try
		{
			if (!string.IsNullOrEmpty(date))
			{
				text = PersianDate.GetFormatetdDate(date.Replace("/", ""));
				value2 = lCID switch
				{
					1065 => DateTime.Parse(text, new PersianCulture()), 
					1025 => DateTime.Parse(text, new CultureInfo("ar-SA")), 
					_ => DateTime.Parse(text, new CultureInfo("en-US")), 
				};
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		try
		{
			cRMSpIIEntities = new CRMSpIIEntities();
			List<CRMspSelectCalendarEventWeekDates_Result> list2 = Enumerable.ToList<CRMspSelectCalendarEventWeekDates_Result>((IEnumerable<CRMspSelectCalendarEventWeekDates_Result>)cRMSpIIEntities.CRMspSelectCalendarEventWeekDates(value2, value, 7));
			if (list2.Count > 0)
			{
				foreach (CRMspSelectCalendarEventWeekDates_Result item in list2)
				{
					if (item.MiladiDate.HasValue)
					{
						list.Add(new CommonSelectListItemViewModel
						{
							Text = item.MiladiDate.Value.ToString("yyyy/MM/dd"),
							Value = ((int)item.MiladiDate.Value.DayOfWeek).ToString(),
							Selected = (item.MiladiDate.Value.ToString("yyyy/MM/dd") == today.ToString("yyyy/MM/dd")),
							Id = item.CalendarEventID,
							Extra = JsonConvert.SerializeObject(new
							{
								IsClosed = item.IsClosed,
								Desc = item.Description
							})
						});
					}
				}
			}
			return list;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			return list;
		}
		finally
		{
			cRMSpIIEntities?.Dispose();
		}
	}

	[LoginAuthorize]
	[HttpPost]
	public string GetDatesOfWeek(string date = "")
	{
		return JsonConvert.SerializeObject(GetDatesOfWeekSelectListItemFromSp(date));
	}

	[LoginAuthorize]
	[HttpPost]
	public string GetDatesOfWeek_Old(string date = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		DateTime dateTime = DateTime.Today;
		if (lCID == 1025)
		{
			dateTime = dateTime.AddDays(-1.0);
		}
		DateTime dateTime2 = DateTime.Now;
		if (!string.IsNullOrWhiteSpace(date))
		{
			DateTime dateTime3 = default(DateTime);
			string text = "";
			try
			{
				if (!string.IsNullOrEmpty(date))
				{
					text = PersianDate.GetFormatetdDate(date.Replace("/", ""));
					dateTime2 = lCID switch
					{
						1065 => DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()), 
						1025 => DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")), 
					};
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
		}
		int num = 0;
		switch (lCID)
		{
		case 1065:
			num = 1;
			break;
		case 1033:
			num = 1;
			break;
		case 1025:
			num = 2;
			break;
		}
		int dayOfWeek = (int)dateTime2.DayOfWeek;
		DateTime dateTime4 = dateTime2.AddDays(-1 * dayOfWeek - num);
		if (lCID == 1065 && dayOfWeek == 6)
		{
			dateTime4 = dateTime4.AddDays(7.0);
		}
		List<SelectListItem> list = new List<SelectListItem>();
		for (int i = 0; i < 7; i++)
		{
			list.Add(new SelectListItem
			{
				Text = dateTime4.AddDays(i).ToString("yyyy/MM/dd"),
				Value = ((int)dateTime4.AddDays(i).DayOfWeek).ToString(),
				Selected = (dateTime4.AddDays(i).ToString("yyyy/MM/dd") == dateTime.ToString("yyyy/MM/dd"))
			});
		}
		return JsonConvert.SerializeObject(list);
	}

	[AjaxOnly]
	public JsonResult GetUTaskGroups()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmDroupDownItem> data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspSelectUserTaskGroups_Result, CrmDroupDownItem>((IEnumerable<CRMspSelectUserTaskGroups_Result>)Enumerable.ToList<CRMspSelectUserTaskGroups_Result>(Enumerable.Where<CRMspSelectUserTaskGroups_Result>((IEnumerable<CRMspSelectUserTaskGroups_Result>)Enumerable.ToList<CRMspSelectUserTaskGroups_Result>((IEnumerable<CRMspSelectUserTaskGroups_Result>)db.CRMspSelectUserTaskGroups(lCID, result)), (Func<CRMspSelectUserTaskGroups_Result, bool>)((CRMspSelectUserTaskGroups_Result ut) => ut.UserId == UserLogin.CurrentUser.UserId))), (Func<CRMspSelectUserTaskGroups_Result, CrmDroupDownItem>)((CRMspSelectUserTaskGroups_Result group) => new CrmDroupDownItem
		{
			text = group.UserTaskGroup,
			value = group.UserTaskGroupId.ToString()
		})));
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetUTaskPriorities()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmDroupDownItem> data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspSelectUserTaskPriorities_Result, CrmDroupDownItem>((IEnumerable<CRMspSelectUserTaskPriorities_Result>)Enumerable.ToList<CRMspSelectUserTaskPriorities_Result>(Enumerable.Where<CRMspSelectUserTaskPriorities_Result>((IEnumerable<CRMspSelectUserTaskPriorities_Result>)Enumerable.ToList<CRMspSelectUserTaskPriorities_Result>((IEnumerable<CRMspSelectUserTaskPriorities_Result>)db.CRMspSelectUserTaskPriorities(lCID, result)), (Func<CRMspSelectUserTaskPriorities_Result, bool>)((CRMspSelectUserTaskPriorities_Result ut) => ut.UserId == UserLogin.CurrentUser.UserId))), (Func<CRMspSelectUserTaskPriorities_Result, CrmDroupDownItem>)((CRMspSelectUserTaskPriorities_Result priority) => new CrmDroupDownItem
		{
			text = priority.Priority,
			value = priority.UserTaskPriorityId.ToString()
		})));
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult _PartialCReminderPrivate(string Tdate, string dsat, string dsun, string dmon, string dtue, string dwed, string dthu, string dfri, int userid)
	{
		if (userid == 0)
		{
			userid = UserLogin.CurrentUser.UserId;
		}
		string text = DateTime.Now.ToString("yyyy/MM/dd");
		if (Tdate == "")
		{
			text.Replace("/", "");
		}
		else
		{
			Tdate.Replace("/", "");
		}
		dsat = dsat.Replace("/", "");
		dsun = dsun.Replace("/", "");
		dmon = dmon.Replace("/", "");
		dtue = dtue.Replace("/", "");
		dwed = dwed.Replace("/", "");
		dthu = dthu.Replace("/", "");
		dfri = dfri.Replace("/", "");
		base.ViewBag.DateTimePVSatA = userid + "|" + dsat;
		base.ViewBag.DateTimePVSatB = userid + "|" + dsat;
		base.ViewBag.DateTimePVSunA = userid + "|" + dsun;
		base.ViewBag.DateTimePVSunB = userid + "|" + dsun;
		base.ViewBag.DateTimePVMonA = userid + "|" + dmon;
		base.ViewBag.DateTimePVMonB = userid + "|" + dmon;
		base.ViewBag.DateTimePVTueA = userid + "|" + dtue;
		base.ViewBag.DateTimePVTueB = userid + "|" + dtue;
		base.ViewBag.DateTimePVWedA = userid + "|" + dwed;
		base.ViewBag.DateTimePVWedB = userid + "|" + dwed;
		base.ViewBag.DateTimePVThuA = userid + "|" + dthu;
		base.ViewBag.DateTimePVThuB = userid + "|" + dthu;
		base.ViewBag.DateTimePVFriA = userid + "|" + dfri;
		base.ViewBag.DateTimePVFriB = userid + "|" + dfri;
		base.ViewBag.DateCurrent = Tdate;
		base.ViewBag.DateCurrentNxt = Tdate;
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult SatAGrig_Read([DataSourceRequest] DataSourceRequest request, string DateTimePV)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspLoadUserTasks_Result> enumerable = new List<CRMspLoadUserTasks_Result>();
		try
		{
			string[] array = DateTimePV.Split(new char[1] { '|' });
			int value = int.Parse(array[0]);
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			DateTime value2 = DateTime.Parse(PersianDate.GetFormatetdDate(array[1].Trim().Replace("/", "").Replace("/", "")) + " 00:00:00");
			enumerable = Enumerable.ToList<CRMspLoadUserTasks_Result>((IEnumerable<CRMspLoadUserTasks_Result>)db.CRMspLoadUserTasks(array[1], value, 1, value2, lCID, result, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult SatBGrig_Read([DataSourceRequest] DataSourceRequest request, string DateTimePV)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspLoadUserTasks_Result> enumerable = new List<CRMspLoadUserTasks_Result>();
		try
		{
			string[] array = DateTimePV.Split(new char[1] { '|' });
			int value = int.Parse(array[0]);
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			DateTime value2 = DateTime.Parse(PersianDate.GetFormatetdDate(array[1].Trim().Replace("/", "").Replace("/", "")) + " 00:00:00");
			enumerable = Enumerable.ToList<CRMspLoadUserTasks_Result>((IEnumerable<CRMspLoadUserTasks_Result>)db.CRMspLoadUserTasks(array[1], value, 2, value2, lCID, result, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult SunAGrig_Read([DataSourceRequest] DataSourceRequest request, string DateTimePV)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspLoadUserTasks_Result> enumerable = new List<CRMspLoadUserTasks_Result>();
		try
		{
			string[] array = DateTimePV.Split(new char[1] { '|' });
			int value = int.Parse(array[0]);
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			DateTime value2 = DateTime.Parse(PersianDate.GetFormatetdDate(array[1].Trim().Replace("/", "").Replace("/", "")) + " 00:00:00");
			enumerable = Enumerable.ToList<CRMspLoadUserTasks_Result>((IEnumerable<CRMspLoadUserTasks_Result>)db.CRMspLoadUserTasks(array[1], value, 1, value2, lCID, result, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult SunBGrig_Read([DataSourceRequest] DataSourceRequest request, string DateTimePV)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspLoadUserTasks_Result> enumerable = new List<CRMspLoadUserTasks_Result>();
		try
		{
			string[] array = DateTimePV.Split(new char[1] { '|' });
			int value = int.Parse(array[0]);
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			DateTime value2 = DateTime.Parse(PersianDate.GetFormatetdDate(array[1].Trim().Replace("/", "").Replace("/", "")) + " 00:00:00");
			enumerable = Enumerable.ToList<CRMspLoadUserTasks_Result>((IEnumerable<CRMspLoadUserTasks_Result>)db.CRMspLoadUserTasks(array[1], value, 2, value2, lCID, result, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult MonAGrig_Read([DataSourceRequest] DataSourceRequest request, string DateTimePV)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspLoadUserTasks_Result> enumerable = new List<CRMspLoadUserTasks_Result>();
		try
		{
			string[] array = DateTimePV.Split(new char[1] { '|' });
			int value = int.Parse(array[0]);
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			DateTime value2 = DateTime.Parse(PersianDate.GetFormatetdDate(array[1].Trim().Replace("/", "").Replace("/", "")) + " 00:00:00");
			enumerable = Enumerable.ToList<CRMspLoadUserTasks_Result>((IEnumerable<CRMspLoadUserTasks_Result>)db.CRMspLoadUserTasks(array[1], value, 1, value2, lCID, result, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult MonBGrig_Read([DataSourceRequest] DataSourceRequest request, string DateTimePV)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspLoadUserTasks_Result> enumerable = new List<CRMspLoadUserTasks_Result>();
		try
		{
			string[] array = DateTimePV.Split(new char[1] { '|' });
			int value = int.Parse(array[0]);
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			DateTime value2 = DateTime.Parse(PersianDate.GetFormatetdDate(array[1].Trim().Replace("/", "").Replace("/", "")) + " 00:00:00");
			enumerable = Enumerable.ToList<CRMspLoadUserTasks_Result>((IEnumerable<CRMspLoadUserTasks_Result>)db.CRMspLoadUserTasks(array[1], value, 2, value2, lCID, result, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult TueAGrig_Read([DataSourceRequest] DataSourceRequest request, string DateTimePV)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspLoadUserTasks_Result> enumerable = new List<CRMspLoadUserTasks_Result>();
		try
		{
			string[] array = DateTimePV.Split(new char[1] { '|' });
			int value = int.Parse(array[0]);
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			DateTime value2 = DateTime.Parse(PersianDate.GetFormatetdDate(array[1].Trim().Replace("/", "").Replace("/", "")) + " 00:00:00");
			enumerable = Enumerable.ToList<CRMspLoadUserTasks_Result>((IEnumerable<CRMspLoadUserTasks_Result>)db.CRMspLoadUserTasks(array[1], value, 1, value2, lCID, result, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult TueBGrig_Read([DataSourceRequest] DataSourceRequest request, string DateTimePV)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspLoadUserTasks_Result> enumerable = new List<CRMspLoadUserTasks_Result>();
		try
		{
			string[] array = DateTimePV.Split(new char[1] { '|' });
			int value = int.Parse(array[0]);
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			DateTime value2 = DateTime.Parse(PersianDate.GetFormatetdDate(array[1].Trim().Replace("/", "").Replace("/", "")) + " 00:00:00");
			enumerable = Enumerable.ToList<CRMspLoadUserTasks_Result>((IEnumerable<CRMspLoadUserTasks_Result>)db.CRMspLoadUserTasks(array[1], value, 2, value2, lCID, result, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult WedAGrig_Read([DataSourceRequest] DataSourceRequest request, string DateTimePV)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspLoadUserTasks_Result> enumerable = new List<CRMspLoadUserTasks_Result>();
		try
		{
			string[] array = DateTimePV.Split(new char[1] { '|' });
			int value = int.Parse(array[0]);
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			DateTime value2 = DateTime.Parse(PersianDate.GetFormatetdDate(array[1].Trim().Replace("/", "").Replace("/", "")) + " 00:00:00");
			enumerable = Enumerable.ToList<CRMspLoadUserTasks_Result>((IEnumerable<CRMspLoadUserTasks_Result>)db.CRMspLoadUserTasks(array[1], value, 1, value2, lCID, result, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult WedBGrig_Read([DataSourceRequest] DataSourceRequest request, string DateTimePV)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspLoadUserTasks_Result> enumerable = new List<CRMspLoadUserTasks_Result>();
		try
		{
			string[] array = DateTimePV.Split(new char[1] { '|' });
			int value = int.Parse(array[0]);
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			DateTime value2 = DateTime.Parse(PersianDate.GetFormatetdDate(array[1].Trim().Replace("/", "").Replace("/", "")) + " 00:00:00");
			enumerable = Enumerable.ToList<CRMspLoadUserTasks_Result>((IEnumerable<CRMspLoadUserTasks_Result>)db.CRMspLoadUserTasks(array[1], value, 2, value2, lCID, result, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult ThuAGrig_Read([DataSourceRequest] DataSourceRequest request, string DateTimePV)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspLoadUserTasks_Result> enumerable = new List<CRMspLoadUserTasks_Result>();
		try
		{
			string[] array = DateTimePV.Split(new char[1] { '|' });
			int value = int.Parse(array[0]);
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			DateTime value2 = DateTime.Parse(PersianDate.GetFormatetdDate(array[1].Trim().Replace("/", "").Replace("/", "")) + " 00:00:00");
			enumerable = Enumerable.ToList<CRMspLoadUserTasks_Result>((IEnumerable<CRMspLoadUserTasks_Result>)db.CRMspLoadUserTasks(array[1], value, 1, value2, lCID, result, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult ThuBGrig_Read([DataSourceRequest] DataSourceRequest request, string DateTimePV)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspLoadUserTasks_Result> enumerable = new List<CRMspLoadUserTasks_Result>();
		try
		{
			string[] array = DateTimePV.Split(new char[1] { '|' });
			int value = int.Parse(array[0]);
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			DateTime value2 = DateTime.Parse(PersianDate.GetFormatetdDate(array[1].Trim().Replace("/", "").Replace("/", "")) + " 00:00:00");
			enumerable = Enumerable.ToList<CRMspLoadUserTasks_Result>((IEnumerable<CRMspLoadUserTasks_Result>)db.CRMspLoadUserTasks(array[1], value, 2, value2, lCID, result, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult FriAGrig_Read([DataSourceRequest] DataSourceRequest request, string DateTimePV)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspLoadUserTasks_Result> enumerable = new List<CRMspLoadUserTasks_Result>();
		try
		{
			string[] array = DateTimePV.Split(new char[1] { '|' });
			int value = int.Parse(array[0]);
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			DateTime value2 = DateTime.Parse(PersianDate.GetFormatetdDate(array[1].Trim().Replace("/", "").Replace("/", "")) + " 00:00:00");
			enumerable = Enumerable.ToList<CRMspLoadUserTasks_Result>((IEnumerable<CRMspLoadUserTasks_Result>)db.CRMspLoadUserTasks(array[1], value, 1, value2, lCID, result, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult FriBGrig_Read([DataSourceRequest] DataSourceRequest request, string DateTimePV)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspLoadUserTasks_Result> enumerable = new List<CRMspLoadUserTasks_Result>();
		try
		{
			string[] array = DateTimePV.Split(new char[1] { '|' });
			int value = int.Parse(array[0]);
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			DateTime value2 = DateTime.Parse(PersianDate.GetFormatetdDate(array[1].Trim().Replace("/", "").Replace("/", "")) + " 00:00:00");
			enumerable = Enumerable.ToList<CRMspLoadUserTasks_Result>((IEnumerable<CRMspLoadUserTasks_Result>)db.CRMspLoadUserTasks(array[1], value, 2, value2, lCID, result, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	public ActionResult _PartialUtPriority()
	{
		return PartialView();
	}

	public ActionResult _PartialUtPriority_Read([DataSourceRequest] DataSourceRequest request)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectUserTaskPriorities_Result> list = new List<CRMspSelectUserTaskPriorities_Result>();
		try
		{
			list = Enumerable.ToList<CRMspSelectUserTaskPriorities_Result>(Enumerable.Where<CRMspSelectUserTaskPriorities_Result>((IEnumerable<CRMspSelectUserTaskPriorities_Result>)db.CRMspSelectUserTaskPriorities(lCID, result), (Func<CRMspSelectUserTaskPriorities_Result, bool>)((CRMspSelectUserTaskPriorities_Result m) => m.UserId == UserLogin.CurrentUser.UserId)));
			foreach (CRMspSelectUserTaskPriorities_Result item in list)
			{
				if (string.IsNullOrEmpty(item.AppType))
				{
					item.AppType = Configuration.AppType;
				}
				item.AppType = Configuration.GetAppType(item.AppType);
				string text = item.FirstRegisterUser ?? "";
				string text2 = (item.FirstRegisterDate.HasValue ? item.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
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
		return Json(((IEnumerable)list).ToDataSourceResult(request));
	}

	[DynamicAuthorize(ControllerName = "frmDefineprjPriority", ActionName = "actInsert")]
	public ActionResult UserTaskDefinePriorityInsert()
	{
		UserTaskPrioritiesLanguageViewModel userTaskPrioritiesLanguageViewModel = new UserTaskPrioritiesLanguageViewModel();
		userTaskPrioritiesLanguageViewModel.UserId = UserLogin.CurrentUser.UserId;
		userTaskPrioritiesLanguageViewModel.Year1 = short.Parse(Financial.Get().Id.ToString());
		userTaskPrioritiesLanguageViewModel.Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
		userTaskPrioritiesLanguageViewModel.RegisterDate = DateTime.Now;
		userTaskPrioritiesLanguageViewModel.RegisterDatePersian = DateTime.Now.ToString("yyyyMMdd");
		return View(userTaskPrioritiesLanguageViewModel);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	[DynamicAuthorize(ControllerName = "frmDefineprjPriorityDataEntry", ActionName = "actPost")]
	public ActionResult UserTaskDefinePriorityInsert(UserTaskPrioritiesLanguageViewModel model)
	{
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
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
			if (base.ModelState.IsValid)
			{
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.PriorityDesc_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.PriorityDesc_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = model.PriorityDesc,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.Priority_Lang))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.Priority_Lang);
				}
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = model.Priority,
					LanguageId = lCID
				});
				if (model.Priority == null)
				{
					text = text + Messages.CheckEmptyProjectPriority + "|";
					num++;
				}
				else if (!checkMultiLanguage(model.Priority, list2))
				{
					text = text + Messages.CheckProjectPriorityLang + "<br>";
					num++;
				}
				model.Color = HexToColor(model.Color);
				if (num == 0)
				{
					DateTime now = DateTime.Now;
					CrmUserTaskPriorities crmUserTaskPriorities = new CrmUserTaskPriorities
					{
						UserId = UserLogin.CurrentUser.UserId,
						RegisterDate = now,
						RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
						AppType = Configuration.AppType,
						Year1 = short.Parse(Financial.Get().Id.ToString()),
						Month1 = short.Parse(now.ToString("MM", new PersianCulture())),
						GUId = System.Guid.NewGuid(),
						LanguageID = defLangID,
						FirstRegisterDate = now,
						FirstRegisterUserId = UserLogin.CurrentUser.UserId,
						FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
						Color = model.Color,
						Priority = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null),
						PriorityDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null)
					};
					_dbTbl.CrmUserTaskPriorities.Add(crmUserTaskPriorities);
					_dbTbl.SaveChanges();
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
					{
						CrmUserTaskPriorities_Lang entity = new CrmUserTaskPriorities_Lang
						{
							LanguageID = lang.LanguageID,
							UserTaskPriorityId = crmUserTaskPriorities.UserTaskPriorityId,
							Priority = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
							PriorityDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null)
						};
						_dbTbl.CrmUserTaskPriorities_Lang.Add(entity);
						_dbTbl.SaveChanges();
					}
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmUserTaskPriorities", UserLogin.CurrentUser.UserId);
					base.ViewBag.SuccessfullInsert = Messages.frmFormBaseInsertSuccessFulMessage;
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
		if (text != "")
		{
			base.ViewBag.Error = text;
		}
		return View(model);
	}

	[DynamicAuthorize(ControllerName = "frmDefineprjPriority", ActionName = "actEdit")]
	public ActionResult UserTaskDefinePriorityEdit(int id)
	{
		_003C_003Ec__DisplayClass317_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass317_0();
		CS_0024_003C_003E8__locals0.id = id;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		DbSet<CrmUserTaskPriorities_Lang> crmUserTaskPriorities_Lang = _dbTbl.CrmUserTaskPriorities_Lang;
		ParameterExpression val = Expression.Parameter(typeof(CrmUserTaskPriorities_Lang), "c");
		List<CrmUserTaskPriorities_Lang> list = Enumerable.ToList<CrmUserTaskPriorities_Lang>((IEnumerable<CrmUserTaskPriorities_Lang>)Queryable.Where<CrmUserTaskPriorities_Lang>((IQueryable<CrmUserTaskPriorities_Lang>)crmUserTaskPriorities_Lang, Expression.Lambda<Func<CrmUserTaskPriorities_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass317_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
		CrmUserTaskPriorities crmUserTaskPriorities = _dbTbl.CrmUserTaskPriorities.Find(CS_0024_003C_003E8__locals0.id);
		if (crmUserTaskPriorities == null)
		{
			crmUserTaskPriorities = new CrmUserTaskPriorities();
			crmUserTaskPriorities.UserId = UserLogin.CurrentUser.UserId;
			crmUserTaskPriorities.Year1 = short.Parse(Financial.Get().Id.ToString());
			crmUserTaskPriorities.Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			crmUserTaskPriorities.RegisterDate = DateTime.Now;
			crmUserTaskPriorities.RegisterDatePersian = DateTime.Now.ToString("yyyyMMdd");
			crmUserTaskPriorities.UserTaskPriorityId = CS_0024_003C_003E8__locals0.id;
		}
		List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmUserTaskPriorities_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmUserTaskPriorities_Lang>)list, (Func<CrmUserTaskPriorities_Lang, CommonMultiLanguageViewModel>)((CrmUserTaskPriorities_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.PriorityDesc,
			LanguageId = item.LanguageID
		})));
		list2.Add(new CommonMultiLanguageViewModel
		{
			Value = crmUserTaskPriorities.PriorityDesc,
			LanguageId = result
		});
		List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmUserTaskPriorities_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmUserTaskPriorities_Lang>)list, (Func<CrmUserTaskPriorities_Lang, CommonMultiLanguageViewModel>)((CrmUserTaskPriorities_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.Priority,
			LanguageId = item.LanguageID
		})));
		list3.Add(new CommonMultiLanguageViewModel
		{
			Value = crmUserTaskPriorities.Priority,
			LanguageId = result
		});
		UserTaskPrioritiesLanguageViewModel model = new UserTaskPrioritiesLanguageViewModel
		{
			AppType = crmUserTaskPriorities.AppType,
			LanguageID = crmUserTaskPriorities.LanguageID,
			UserId = crmUserTaskPriorities.UserId,
			GUId = crmUserTaskPriorities.GUId,
			FirstRegisterDate = crmUserTaskPriorities.FirstRegisterDate,
			RegisterDate = crmUserTaskPriorities.RegisterDate,
			RegisterDatePersian = crmUserTaskPriorities.RegisterDatePersian,
			Month1 = crmUserTaskPriorities.Month1,
			Year1 = crmUserTaskPriorities.Year1,
			FirstRegisterDatePersian = crmUserTaskPriorities.FirstRegisterDatePersian,
			FirstRegisterUserId = crmUserTaskPriorities.FirstRegisterUserId,
			UserTaskPriorityId = crmUserTaskPriorities.UserTaskPriorityId,
			Color = crmUserTaskPriorities.Color,
			Priority = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			PriorityDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			PriorityDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
			Priority_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))))
		};
		return View(model);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	[DynamicAuthorize(ControllerName = "frmDefineprjPriorityDataEntry", ActionName = "actPost")]
	public ActionResult UserTaskDefinePriorityEdit(UserTaskPrioritiesLanguageViewModel model)
	{
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass318_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass318_0();
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
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.PriorityDesc_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.PriorityDesc_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.PriorityDesc,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.Priority_Lang))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.Priority_Lang);
				}
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.Priority,
					LanguageId = lCID
				});
				if (CS_0024_003C_003E8__locals0.model.Priority == null)
				{
					text = text + Messages.CheckEmptyProjectPriority + "|";
					num++;
				}
				else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.model.Priority, list2))
				{
					text = text + Messages.CheckProjectPriorityLang + "<br>";
					num++;
				}
				CS_0024_003C_003E8__locals0.model.Color = HexToColor(CS_0024_003C_003E8__locals0.model.Color);
				if (num == 0)
				{
					DateTime now = DateTime.Now;
					CrmUserTaskPriorities crmUserTaskPriorities = _dbTbl.CrmUserTaskPriorities.Find(CS_0024_003C_003E8__locals0.model.UserTaskPriorityId);
					crmUserTaskPriorities.AppType = Configuration.AppType;
					crmUserTaskPriorities.RegisterDate = now;
					crmUserTaskPriorities.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					crmUserTaskPriorities.UserId = UserLogin.CurrentUser.UserId;
					crmUserTaskPriorities.Year1 = short.Parse(Financial.Get().Id.ToString());
					crmUserTaskPriorities.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
					crmUserTaskPriorities.GUId = System.Guid.NewGuid();
					crmUserTaskPriorities.Color = CS_0024_003C_003E8__locals0.model.Color;
					crmUserTaskPriorities.Priority = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					crmUserTaskPriorities.PriorityDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					_dbTbl.Entry(crmUserTaskPriorities).State = EntityState.Modified;
					_dbTbl.SaveChanges();
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass318_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass318_1();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							DbSet<CrmUserTaskPriorities_Lang> crmUserTaskPriorities_Lang = _dbTbl.CrmUserTaskPriorities_Lang;
							ParameterExpression val = Expression.Parameter(typeof(CrmUserTaskPriorities_Lang), "c");
							CrmUserTaskPriorities_Lang crmUserTaskPriorities_Lang2 = Queryable.FirstOrDefault<CrmUserTaskPriorities_Lang>((IQueryable<CrmUserTaskPriorities_Lang>)crmUserTaskPriorities_Lang, Expression.Lambda<Func<CrmUserTaskPriorities_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass318_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass318_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (crmUserTaskPriorities_Lang2 != null)
							{
								crmUserTaskPriorities_Lang2.Priority = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmUserTaskPriorities_Lang2.PriorityDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(crmUserTaskPriorities_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							CrmUserTaskPriorities_Lang entity = new CrmUserTaskPriorities_Lang
							{
								LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
								UserTaskPriorityId = crmUserTaskPriorities.UserTaskPriorityId,
								Priority = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
								PriorityDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
							};
							_dbTbl.CrmUserTaskPriorities_Lang.Add(entity);
							_dbTbl.SaveChanges();
						}
					}
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmUserTaskPriorities", UserLogin.CurrentUser.UserId);
					base.ViewBag.SuccessfullEdit = Messages.frmFormBaseEditSuccessFulMessage;
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
		if (text != "")
		{
			base.ViewBag.Error = text;
		}
		return View(CS_0024_003C_003E8__locals0.model);
	}

	public string UserTaskDefinePriorityDelete(int id)
	{
		_003C_003Ec__DisplayClass319_0 _003C_003Ec__DisplayClass319_ = new _003C_003Ec__DisplayClass319_0();
		_003C_003Ec__DisplayClass319_.id = id;
		string result = "-1";
		if (!UserLogin.IsUserAccess("frmDefineprjPriority", "actDelete", UserLogin.CurrentUser))
		{
			return Messages.NotAccessToPage;
		}
		CrmUserTaskPriorities crmUserTaskPriorities = _dbTbl.CrmUserTaskPriorities.Find(_003C_003Ec__DisplayClass319_.id);
		if (crmUserTaskPriorities != null)
		{
			if (crmUserTaskPriorities.CrmUserTasks.Count > 0)
			{
				result = Messages.RedundancyMessage;
			}
			else
			{
				try
				{
					if (db.CRMspDeleteCrmUserTaskPriorities(_003C_003Ec__DisplayClass319_.id) <= 0)
					{
						goto IL_012a;
					}
					DbSet<CrmUserTaskPriorities> crmUserTaskPriorities2 = _dbTbl.CrmUserTaskPriorities;
					ParameterExpression val = Expression.Parameter(typeof(CrmUserTaskPriorities), "model");
					if (Queryable.FirstOrDefault<CrmUserTaskPriorities>((IQueryable<CrmUserTaskPriorities>)crmUserTaskPriorities2, Expression.Lambda<Func<CrmUserTaskPriorities, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass319_, typeof(_003C_003Ec__DisplayClass319_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
					{
						goto IL_012a;
					}
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmUserTaskPriorities", UserLogin.CurrentUser.UserId);
					result = "1";
					goto end_IL_0074;
					IL_012a:
					result = Messages.RedundancyMessage;
					end_IL_0074:;
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					result = Messages.msgErrorRunFunction;
				}
			}
		}
		return result;
	}

	public void SetRegisterInfoForUserTask(UserTasksLanguageViewModel model)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		CRMspSelectUsersById_Result cRMspSelectUsersById_Result = CRMIdeal.Classes.Helper.User.SelectUsersById(model.FirstRegisterUserId.GetValueOrDefault());
		base.ViewBag.FirstRegisterUser = Labels.frmFirstRegisterUser + ": " + ((cRMspSelectUsersById_Result != null) ? (cRMspSelectUsersById_Result.LName + ((cRMspSelectUsersById_Result.FName != null) ? (" " + cRMspSelectUsersById_Result.FName) : "")) : "");
		string text = (model.FirstRegisterDate.HasValue ? model.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
		base.ViewBag.FirstRegisterDate = text;
		CRMspSelectUsersById_Result cRMspSelectUsersById_Result2 = CRMIdeal.Classes.Helper.User.SelectUsersById(model.UserId);
		string text2 = Labels.prsUserId + ": " + ((cRMspSelectUsersById_Result2 != null) ? (cRMspSelectUsersById_Result2.LName + ((cRMspSelectUsersById_Result2.FName != null) ? (" " + cRMspSelectUsersById_Result2.FName) : "")) : "");
		_ = model.RegisterDate;
		string text3 = model.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
		base.ViewBag.RegisterDate = text3;
		if (string.IsNullOrEmpty(model.AppType))
		{
			model.AppType = Configuration.AppType;
		}
		string text4 = Labels.AppType + ": " + Configuration.GetAppType(model.AppType);
		base.ViewBag.AppType = text4;
		base.ViewBag.RegisterUser = text2 + " (" + text4 + ")";
	}

	public ActionResult CReminderPrivateTaskInsert(string tDate = "", int uid = 0, string remindDate = "", string taskTime = "", string remindTime = "", string taskTitle = "", string taskDesc = "", string taskTimeEnd = "")
	{
		base.ViewBag.ReminderUsers = SelectUserForLinkedType_SelectListItem(UserLogin.CurrentUser.UserId);
		if (uid == 0 && uid == -1)
		{
			uid = UserLogin.CurrentUser.UserId;
		}
		if (tDate == "")
		{
			tDate = DateTime.Now.ToString("yyyy/MM/dd");
		}
		remindDate = ((remindDate == "") ? tDate : remindDate);
		string[] array = ((!string.IsNullOrEmpty(taskDesc)) ? taskDesc.Split(new char[1] { '|' }) : null);
		if (array != null)
		{
			taskDesc = "";
			taskDesc = Enumerable.Aggregate<string, string>((IEnumerable<string>)array, taskDesc, (Func<string, string, string>)((string current, string item) => current + item + Environment.NewLine));
		}
		DateTime now = DateTime.Now;
		UserTasksLanguageViewModel userTasksLanguageViewModel = new UserTasksLanguageViewModel
		{
			UserId = UserLogin.CurrentUser.UserId,
			Year1 = short.Parse(Financial.Get().Id.ToString()),
			Month1 = short.Parse(now.ToString("MM", new PersianCulture())),
			RegisterDate = now,
			RegisterDatePersian = now.ToString("yyyyMMdd"),
			FirstRegisterUserId = UserLogin.CurrentUser.UserId,
			FirstRegisterDate = now,
			FirstRegisterDatePersian = now.ToString("yyyyMMdd"),
			UserTaskDate = DateTime.Parse(tDate),
			UserTaskDatePersian = tDate,
			UserTaskRemindDate = remindDate,
			UserTaskTime = taskTime,
			UserTaskTimeEnd = taskTimeEnd,
			UserTaskRemindTime = remindTime,
			UserTaskTitle = taskTitle,
			UserTaskDescription = taskDesc,
			UserTaskShowAllarm = 1
		};
		SetRegisterInfoForUserTask(userTasksLanguageViewModel);
		return View(userTasksLanguageViewModel);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult CReminderPrivateTaskInsert(UserTasksLanguageViewModel model)
	{
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int countError = 0;
		try
		{
			int? num = null;
			if (UserLogin.CurrentUser != null)
			{
				num = UserLogin.CurrentUser.UserLastCId;
			}
			base.ViewBag.ReminderUsers = SelectUserForLinkedType_SelectListItem(model.UserId);
			if (base.ModelState.IsValid)
			{
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.UserTaskTitle_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.UserTaskTitle_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = model.UserTaskTitle,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.UserTaskDescription_Lang))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.UserTaskDescription_Lang);
				}
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = model.UserTaskDescription,
					LanguageId = lCID
				});
				text = ChkBeforeSubmitUserTask_Lang(model, list, ref countError);
				try
				{
					DateTime dateTime = default(DateTime);
					string text2 = "";
					if (!string.IsNullOrEmpty(model.UserTaskRemindDate))
					{
						text2 = PersianDate.GetFormatetdDate(model.UserTaskRemindDate.Replace("/", ""));
						switch (lCID)
						{
						case 1065:
							dateTime = DateTime.Parse(text2 + " " + model.UserTaskRemindTime, new PersianCulture());
							model.UserTaskRemindDate = dateTime.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime = DateTime.Parse(text2 + " " + model.UserTaskRemindTime, new CultureInfo("ar-SA"));
							model.UserTaskRemindDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime = DateTime.Parse(text2 + " " + model.UserTaskRemindTime, new CultureInfo("en-US"));
							model.UserTaskRemindDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						model.UserTaskRemindDateTime = dateTime;
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					base.ViewBag.Error = Messages.ErrorFormatDatePersian;
					return View(model);
				}
				if (Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbI.CRMspCheckUserTaskTimeOverlap(model.UserTaskId, model.UserTaskDate, model.UserTaskTime, model.UserTaskTimeEnd, UserLogin.CurrentUser.UserId)).Value > 0)
				{
					countError++;
					text += Messages.msgErrorUserTaskTimeOverlap;
				}
				if (countError == 0)
				{
					if (model.UserTaskGroupId == 0)
					{
						model.UserTaskGroupId = null;
					}
					if (model.UserTaskPriorityId == 0)
					{
						model.UserTaskPriorityId = null;
					}
					DateTime dateTime2 = default(DateTime);
					string text3 = "";
					try
					{
						if (!string.IsNullOrEmpty(model.UserTaskDatePersian))
						{
							text3 = PersianDate.GetFormatetdDate(model.UserTaskDatePersian.Replace("/", ""));
							switch (lCID)
							{
							case 1065:
								dateTime2 = DateTime.Parse(text3 + " 00:00:00", new PersianCulture());
								model.UserTaskDatePersian = dateTime2.ToString("yyyyMMdd");
								break;
							case 1025:
								dateTime2 = DateTime.Parse(text3 + " 00:00:00", new CultureInfo("ar-SA"));
								model.UserTaskDatePersian = dateTime2.ToString("yyyyMMdd", new PersianCulture());
								break;
							default:
								dateTime2 = DateTime.Parse(text3 + " 00:00:00", new CultureInfo("en-US"));
								model.UserTaskDatePersian = dateTime2.ToString("yyyyMMdd", new PersianCulture());
								break;
							}
							model.UserTaskDate = dateTime2;
						}
					}
					catch (Exception e2)
					{
						ErrorSignal.FromCurrentContext().Raise(e2);
						base.ViewBag.Error = Messages.ErrorFormatDatePersian;
						return View(model);
					}
					try
					{
						if (!string.IsNullOrEmpty(model.UserTaskDateEndPersian))
						{
							text3 = PersianDate.GetFormatetdDate(model.UserTaskDateEndPersian.Replace("/", ""));
							switch (lCID)
							{
							case 1065:
								dateTime2 = DateTime.Parse(text3 + " 00:00:00", new PersianCulture());
								model.UserTaskDateEndPersian = dateTime2.ToString("yyyyMMdd");
								break;
							case 1025:
								dateTime2 = DateTime.Parse(text3 + " 00:00:00", new CultureInfo("ar-SA"));
								model.UserTaskDateEndPersian = dateTime2.ToString("yyyyMMdd", new PersianCulture());
								break;
							default:
								dateTime2 = DateTime.Parse(text3 + " 00:00:00", new CultureInfo("en-US"));
								model.UserTaskDateEndPersian = dateTime2.ToString("yyyyMMdd", new PersianCulture());
								break;
							}
							model.UserTaskDateEnd = dateTime2;
						}
					}
					catch (Exception e3)
					{
						ErrorSignal.FromCurrentContext().Raise(e3);
						base.ViewBag.Error = Messages.ErrorFormatDatePersian;
						return View(model);
					}
					DateTime now = DateTime.Now;
					CrmUserTasks crmUserTasks = new CrmUserTasks
					{
						UserTaskDate = model.UserTaskDate,
						UserTaskDatePersian = model.UserTaskDatePersian,
						UserTaskRemindDate = model.UserTaskRemindDate,
						UserTaskRemindDateTime = model.UserTaskRemindDateTime,
						UserId = model.UserId,
						Year1 = short.Parse(Financial.Get().Id.ToString()),
						Month1 = short.Parse(now.ToString("MM", new PersianCulture())),
						RegisterDate = now,
						RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
						AppType = Configuration.AppType,
						GUId = System.Guid.NewGuid(),
						UserTaskGroupId = model.UserTaskGroupId,
						UserTaskPriorityId = model.UserTaskPriorityId,
						LanguageID = defLangID,
						FirstRegisterDate = now,
						FirstRegisterUserId = UserLogin.CurrentUser.UserId,
						FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
						UserTaskIsPublic = model.UserTaskIsPublic,
						UserTaskTime = model.UserTaskTime,
						UserTaskTimeEnd = model.UserTaskTimeEnd,
						UserTaskDidIt = model.UserTaskDidIt,
						UserTaskShowAllarm = model.UserTaskShowAllarm,
						UserTaskRemindTime = model.UserTaskRemindTime,
						UserTaskTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null),
						UserTaskDescription = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null),
						ObjectTypeId = model.ObjectTypeId,
						ObjectId = model.ObjectId,
						UserTaskNoTimeOverlap = model.UserTaskNoTimeOverlap,
						UserTaskCompanyIds = model.UserTaskCompanyIds,
						UserTaskRepeatDaily = model.UserTaskRepeatDaily,
						UserTaskRepeatWeekly = model.UserTaskRepeatWeekly,
						UserTaskRepeatMonthly = model.UserTaskRepeatMonthly,
						UserTaskRepeatYearly = model.UserTaskRepeatYearly,
						UserTaskRemindRepeatDaily = model.UserTaskRemindRepeatDaily,
						UserTaskRemindRepeatWeekly = model.UserTaskRemindRepeatWeekly,
						UserTaskRemindRepeatMonthly = model.UserTaskRemindRepeatMonthly,
						UserTaskRemindRepeatYearly = model.UserTaskRemindRepeatYearly,
						UserTaskDateEnd = model.UserTaskDateEnd,
						UserTaskDateEndPersian = model.UserTaskDateEndPersian,
						UserTaskCId = ((num.GetValueOrDefault() != 0) ? num : null)
					};
					if (model.UserTaskDidIt.HasValue && model.UserTaskDidIt.GetValueOrDefault())
					{
						crmUserTasks.UserTaskDidItDate = now;
						crmUserTasks.UserTaskDidItDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					}
					else
					{
						crmUserTasks.UserTaskDidItDate = null;
						crmUserTasks.UserTaskDidItDatePersian = "";
					}
					_dbTbl.CrmUserTasks.Add(crmUserTasks);
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					if (VersionBuyer.Outlook && model.SendToOutlook.GetValueOrDefault())
					{
						model.UserTaskId = crmUserTasks.UserTaskId;
						UserTasks.SendReminderToUserOutlook("InsertReminder", model);
					}
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
					{
						CrmUserTasks_Lang entity = new CrmUserTasks_Lang
						{
							LanguageID = lang.LanguageID,
							UserTaskId = crmUserTasks.UserTaskId,
							UserTaskTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
							UserTaskDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null)
						};
						_dbTbl.CrmUserTasks_Lang.Add(entity);
						_dbTbl.SaveChanges();
					}
					base.ViewBag.SuccessfullUtInsert = Messages.UeserTasksInsertSuccessFulMessage;
					Alarms.Update(crmUserTasks.UserId);
					string text4 = "";
					try
					{
						CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
						foreach (CRMspLoadRemindingTask_Result item in Alarms.Get(currentUser.UserId, currentUser.UserLastCId))
						{
							if (text4.Trim() != "")
							{
								text4 += "@";
							}
							text4 = text4 + item.Type + "|" + item.UserTaskId + "|" + item.UserTaskTitle + "|" + item.UserTaskTime + "|" + item.UserTaskDatePersian + "|" + item.UserTaskRemindTime + "|" + item.UserTaskRemindDate + "|" + item.Val1 + "|" + item.Val2 + "|" + item.Val3 + "|" + item.UserTaskDate.ToString() + "|" + item.UserTaskRemindDateTime.ToString() + "|" + ((item.IsRecurringTask != false) ? 1 : 0);
						}
					}
					catch (Exception e4)
					{
						ErrorSignal.FromCurrentContext().Raise(e4);
					}
					base.ViewBag.ResultLocalStorage = text4;
					model.RegisterDate = now;
					model.FirstRegisterDate = now;
				}
			}
		}
		catch (DbEntityValidationException e5)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e5);
			base.ViewBag.Error = Messages.frmErrorMessage;
		}
		catch (Exception e6)
		{
			ErrorSignal.FromCurrentContext().Raise(e6);
			text = Messages.frmErrorMessage;
		}
		base.ViewBag.Error = text;
		model.UserTaskDatePersian = ((!string.IsNullOrWhiteSpace(model.UserTaskDatePersian)) ? model.UserTaskDate.ToString("yyyy/MM/dd") : "");
		model.UserTaskRemindDate = (string.IsNullOrWhiteSpace(model.UserTaskRemindDate) ? "" : model.UserTaskRemindDateTime?.ToString("yyyy/MM/dd"));
		SetRegisterInfoForUserTask(model);
		return View(model);
	}

	[HttpPost]
	[LoginAuthorize]
	public async Task<string> SendReminderToOutlook(int mode = -1, string js = "")
	{
		string result = "";
		if (mode == -1)
		{
			return result;
		}
		string mode2 = "InsertReminder";
		if (mode == 2)
		{
			mode2 = "UpdateReminder";
		}
		if (VersionBuyer.Outlook && !string.IsNullOrWhiteSpace(js))
		{
			result = await UserTasks.SendReminderToUserOutlook(mode2, null, js);
		}
		return result;
	}

	public ActionResult CReminderPrivateTaskEdit(int utid)
	{
		_003C_003Ec__DisplayClass324_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass324_0();
		CS_0024_003C_003E8__locals0.utid = utid;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		DbSet<CrmUserTasks_Lang> crmUserTasks_Lang = _dbTbl.CrmUserTasks_Lang;
		ParameterExpression val = Expression.Parameter(typeof(CrmUserTasks_Lang), "c");
		List<CrmUserTasks_Lang> list = Enumerable.ToList<CrmUserTasks_Lang>((IEnumerable<CrmUserTasks_Lang>)Queryable.Where<CrmUserTasks_Lang>((IQueryable<CrmUserTasks_Lang>)crmUserTasks_Lang, Expression.Lambda<Func<CrmUserTasks_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass324_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
		CrmUserTasks crmUserTasks = _dbTbl.CrmUserTasks.Find(CS_0024_003C_003E8__locals0.utid);
		if (crmUserTasks == null)
		{
			DateTime now = DateTime.Now;
			crmUserTasks = new CrmUserTasks();
			crmUserTasks.UserId = UserLogin.CurrentUser.UserId;
			crmUserTasks.Year1 = short.Parse(Financial.Get().Id.ToString());
			crmUserTasks.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
			crmUserTasks.RegisterDate = now;
			crmUserTasks.RegisterDatePersian = now.ToString("yyyyMMdd");
			crmUserTasks.UserTaskId = CS_0024_003C_003E8__locals0.utid;
			crmUserTasks.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
			crmUserTasks.FirstRegisterDate = now;
			crmUserTasks.FirstRegisterDatePersian = now.ToString("yyyyMMdd");
		}
		else
		{
			if (!string.IsNullOrWhiteSpace(crmUserTasks.UserTaskRemindDate))
			{
				crmUserTasks.UserTaskRemindDate = crmUserTasks.UserTaskRemindDateTime?.ToString("yyyy/MM/dd");
				if (crmUserTasks.UserTaskRemindDateTime.HasValue)
				{
					crmUserTasks.UserTaskRemindDate = Convert.ToDateTime(crmUserTasks.UserTaskRemindDateTime).ToString("yyyy/MM/dd");
				}
				else
				{
					crmUserTasks.UserTaskRemindDate = PersianDate.GetFormatetdDate(crmUserTasks.UserTaskRemindDate.Replace("/", ""));
					if (CS_0024_003C_003E8__locals0.currLangID != 1065)
					{
						crmUserTasks.UserTaskRemindDate = DateTime.Parse(PersianDate.GetFormatetdDate(crmUserTasks.UserTaskRemindDate.Replace("/", "")), new CultureInfo("en-US")).ToString("yyyy/MM/dd");
					}
				}
			}
			else
			{
				crmUserTasks.UserTaskRemindDate = "";
				crmUserTasks.UserTaskRemindTime = "";
			}
			if (!string.IsNullOrWhiteSpace(crmUserTasks.UserTaskDatePersian))
			{
				crmUserTasks.UserTaskDatePersian = crmUserTasks.UserTaskDate.ToString("yyyy/MM/dd");
				_ = crmUserTasks.UserTaskDate;
				crmUserTasks.UserTaskDatePersian = Convert.ToDateTime(crmUserTasks.UserTaskDate).ToString("yyyy/MM/dd");
			}
			else
			{
				crmUserTasks.UserTaskDatePersian = "";
			}
		}
		List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmUserTasks_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmUserTasks_Lang>)list, (Func<CrmUserTasks_Lang, CommonMultiLanguageViewModel>)((CrmUserTasks_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.UserTaskTitle,
			LanguageId = item.LanguageID
		})));
		list2.Add(new CommonMultiLanguageViewModel
		{
			Value = crmUserTasks.UserTaskTitle,
			LanguageId = result
		});
		List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmUserTasks_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmUserTasks_Lang>)list, (Func<CrmUserTasks_Lang, CommonMultiLanguageViewModel>)((CrmUserTasks_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.UserTaskDescription,
			LanguageId = item.LanguageID
		})));
		list3.Add(new CommonMultiLanguageViewModel
		{
			Value = crmUserTasks.UserTaskDescription,
			LanguageId = result
		});
		UserTasksLanguageViewModel userTasksLanguageViewModel = new UserTasksLanguageViewModel
		{
			AppType = crmUserTasks.AppType,
			LanguageID = crmUserTasks.LanguageID,
			UserId = crmUserTasks.UserId,
			GUId = crmUserTasks.GUId,
			FirstRegisterDate = crmUserTasks.FirstRegisterDate,
			RegisterDate = crmUserTasks.RegisterDate,
			RegisterDatePersian = crmUserTasks.RegisterDatePersian,
			Month1 = crmUserTasks.Month1,
			Year1 = crmUserTasks.Year1,
			FirstRegisterDatePersian = crmUserTasks.FirstRegisterDatePersian,
			FirstRegisterUserId = crmUserTasks.FirstRegisterUserId,
			UserTaskPriorityId = crmUserTasks.UserTaskPriorityId,
			UserTaskId = CS_0024_003C_003E8__locals0.utid,
			UserTaskGroupId = crmUserTasks.UserTaskGroupId,
			UserTaskDate = crmUserTasks.UserTaskDate,
			UserTaskDatePersian = crmUserTasks.UserTaskDatePersian,
			UserTaskRemindDate = crmUserTasks.UserTaskRemindDate,
			UserTaskTime = crmUserTasks.UserTaskTime,
			UserTaskTimeEnd = crmUserTasks.UserTaskTimeEnd,
			UserTaskRemindTime = crmUserTasks.UserTaskRemindTime,
			UserTaskDidIt = crmUserTasks.UserTaskDidIt,
			UserTaskIsPublic = crmUserTasks.UserTaskIsPublic,
			UserTaskShowAllarm = crmUserTasks.UserTaskShowAllarm,
			UserTaskRemindDateTime = crmUserTasks.UserTaskRemindDateTime,
			UserTaskTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			UserTaskDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			UserTaskTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
			UserTaskDescription_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
			ObjectTypeId = crmUserTasks.ObjectTypeId,
			ObjectId = crmUserTasks.ObjectId,
			UserTaskNoTimeOverlap = crmUserTasks.UserTaskNoTimeOverlap,
			UserTaskCompanyIds = crmUserTasks.UserTaskCompanyIds,
			UserTaskCompanys = SelectCompanyByIdsJs(crmUserTasks.UserTaskCompanyIds),
			UserTaskRepeatDaily = crmUserTasks.UserTaskRepeatDaily,
			UserTaskRepeatWeekly = crmUserTasks.UserTaskRepeatWeekly,
			UserTaskRepeatMonthly = crmUserTasks.UserTaskRepeatMonthly,
			UserTaskRepeatYearly = crmUserTasks.UserTaskRepeatYearly,
			UserTaskRemindRepeatDaily = crmUserTasks.UserTaskRemindRepeatDaily,
			UserTaskRemindRepeatWeekly = crmUserTasks.UserTaskRemindRepeatWeekly,
			UserTaskRemindRepeatMonthly = crmUserTasks.UserTaskRemindRepeatMonthly,
			UserTaskRemindRepeatYearly = crmUserTasks.UserTaskRemindRepeatYearly,
			UserTaskDateEnd = crmUserTasks.UserTaskDateEnd,
			UserTaskDateEndPersian = crmUserTasks.UserTaskDateEndPersian,
			UserTaskLinkIdStr = crmUserTasks.UserTaskLinkIdStr
		};
		SetRegisterInfoForUserTask(userTasksLanguageViewModel);
		base.ViewBag.ReminderUsers = SelectUserForLinkedType_SelectListItem(userTasksLanguageViewModel.UserId);
		return View(userTasksLanguageViewModel);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult CReminderPrivateTaskEdit(UserTasksLanguageViewModel model)
	{
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass325_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass325_0();
		CS_0024_003C_003E8__locals0.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int countError = 0;
		try
		{
			if (base.ModelState.IsValid)
			{
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.UserTaskTitle_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.UserTaskTitle_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.UserTaskTitle,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.UserTaskDescription_Lang))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.UserTaskDescription_Lang);
				}
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.UserTaskDescription,
					LanguageId = lCID
				});
				text = ChkBeforeSubmitUserTask_Lang(CS_0024_003C_003E8__locals0.model, list, ref countError);
				if (countError == 0)
				{
					if (CS_0024_003C_003E8__locals0.model.UserTaskGroupId == 0)
					{
						CS_0024_003C_003E8__locals0.model.UserTaskGroupId = null;
					}
					if (CS_0024_003C_003E8__locals0.model.UserTaskPriorityId == 0)
					{
						CS_0024_003C_003E8__locals0.model.UserTaskPriorityId = null;
					}
					if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.model.UserTaskRemindDate))
					{
						CS_0024_003C_003E8__locals0.model.UserTaskRemindDateTime = DateTime.Parse(PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.model.UserTaskRemindDate.Replace("/", "")) + " 00:00:00");
					}
					DateTime dateTime = default(DateTime);
					string text2 = "";
					try
					{
						if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.model.UserTaskDatePersian))
						{
							text2 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.model.UserTaskDatePersian.Replace("/", ""));
							switch (lCID)
							{
							case 1065:
								dateTime = DateTime.Parse(text2 + " 00:00:00", new PersianCulture());
								CS_0024_003C_003E8__locals0.model.UserTaskDatePersian = dateTime.ToString("yyyyMMdd");
								break;
							case 1025:
								dateTime = DateTime.Parse(text2 + " 00:00:00", new CultureInfo("ar-SA"));
								CS_0024_003C_003E8__locals0.model.UserTaskDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							default:
								dateTime = DateTime.Parse(text2 + " 00:00:00", new CultureInfo("en-US"));
								CS_0024_003C_003E8__locals0.model.UserTaskDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							}
							CS_0024_003C_003E8__locals0.model.UserTaskDate = dateTime;
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						base.ViewBag.Error = Messages.ErrorFormatDatePersian;
						return View(CS_0024_003C_003E8__locals0.model);
					}
					try
					{
						if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.model.UserTaskRemindDate))
						{
							text2 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.model.UserTaskRemindDate.Replace("/", ""));
							switch (lCID)
							{
							case 1065:
								dateTime = DateTime.Parse(text2 + " " + CS_0024_003C_003E8__locals0.model.UserTaskRemindTime, new PersianCulture());
								CS_0024_003C_003E8__locals0.model.UserTaskRemindDate = dateTime.ToString("yyyyMMdd");
								break;
							case 1025:
								dateTime = DateTime.Parse(text2 + " " + CS_0024_003C_003E8__locals0.model.UserTaskRemindTime, new CultureInfo("ar-SA"));
								CS_0024_003C_003E8__locals0.model.UserTaskRemindDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							default:
								dateTime = DateTime.Parse(text2 + " " + CS_0024_003C_003E8__locals0.model.UserTaskRemindTime, new CultureInfo("en-US"));
								CS_0024_003C_003E8__locals0.model.UserTaskRemindDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							}
							CS_0024_003C_003E8__locals0.model.UserTaskRemindDateTime = dateTime;
						}
					}
					catch (Exception e2)
					{
						ErrorSignal.FromCurrentContext().Raise(e2);
						base.ViewBag.Error = Messages.ErrorFormatDatePersian;
						return View(CS_0024_003C_003E8__locals0.model);
					}
					try
					{
						if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.UserTaskDateEndPersian))
						{
							text2 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.model.UserTaskDateEndPersian.Replace("/", ""));
							switch (lCID)
							{
							case 1065:
								dateTime = DateTime.Parse(text2 + " 00:00:00", new PersianCulture());
								CS_0024_003C_003E8__locals0.model.UserTaskDateEndPersian = dateTime.ToString("yyyyMMdd");
								break;
							case 1025:
								dateTime = DateTime.Parse(text2 + " 00:00:00", new CultureInfo("ar-SA"));
								CS_0024_003C_003E8__locals0.model.UserTaskDateEndPersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							default:
								dateTime = DateTime.Parse(text2 + " 00:00:00", new CultureInfo("en-US"));
								CS_0024_003C_003E8__locals0.model.UserTaskDateEndPersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							}
							CS_0024_003C_003E8__locals0.model.UserTaskDateEnd = dateTime;
						}
					}
					catch (Exception e3)
					{
						ErrorSignal.FromCurrentContext().Raise(e3);
						base.ViewBag.Error = Messages.ErrorFormatDatePersian;
						return View(CS_0024_003C_003E8__locals0.model);
					}
					CrmUserTasks crmUserTasks = _dbTbl.CrmUserTasks.Find(CS_0024_003C_003E8__locals0.model.UserTaskId);
					DateTime now = DateTime.Now;
					crmUserTasks.UserTaskDate = CS_0024_003C_003E8__locals0.model.UserTaskDate;
					crmUserTasks.UserTaskDatePersian = CS_0024_003C_003E8__locals0.model.UserTaskDatePersian;
					crmUserTasks.UserTaskRemindDate = CS_0024_003C_003E8__locals0.model.UserTaskRemindDate;
					crmUserTasks.UserTaskRemindDateTime = CS_0024_003C_003E8__locals0.model.UserTaskRemindDateTime;
					crmUserTasks.UserId = CS_0024_003C_003E8__locals0.model.UserId;
					crmUserTasks.Year1 = short.Parse(Financial.Get().Id.ToString());
					crmUserTasks.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
					crmUserTasks.RegisterDate = now;
					crmUserTasks.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					crmUserTasks.UserTaskIsPublic = CS_0024_003C_003E8__locals0.model.UserTaskIsPublic;
					crmUserTasks.UserTaskTime = CS_0024_003C_003E8__locals0.model.UserTaskTime;
					crmUserTasks.UserTaskTimeEnd = CS_0024_003C_003E8__locals0.model.UserTaskTimeEnd;
					if ((crmUserTasks.UserTaskDidIt == false || !crmUserTasks.UserTaskDidIt.HasValue) && CS_0024_003C_003E8__locals0.model.UserTaskDidIt.HasValue && CS_0024_003C_003E8__locals0.model.UserTaskDidIt.GetValueOrDefault())
					{
						crmUserTasks.UserTaskDidItDate = now;
						crmUserTasks.UserTaskDidItDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					}
					else if (!CS_0024_003C_003E8__locals0.model.UserTaskDidIt.HasValue || CS_0024_003C_003E8__locals0.model.UserTaskDidIt == false)
					{
						crmUserTasks.UserTaskDidItDate = null;
						crmUserTasks.UserTaskDidItDatePersian = "";
					}
					crmUserTasks.UserTaskDidIt = CS_0024_003C_003E8__locals0.model.UserTaskDidIt;
					crmUserTasks.UserTaskShowAllarm = CS_0024_003C_003E8__locals0.model.UserTaskShowAllarm;
					crmUserTasks.UserTaskRemindTime = CS_0024_003C_003E8__locals0.model.UserTaskRemindTime;
					crmUserTasks.AppType = Configuration.AppType;
					crmUserTasks.UserTaskTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					crmUserTasks.UserTaskDescription = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					crmUserTasks.UserTaskPriorityId = CS_0024_003C_003E8__locals0.model.UserTaskPriorityId;
					crmUserTasks.UserTaskGroupId = CS_0024_003C_003E8__locals0.model.UserTaskGroupId;
					crmUserTasks.ObjectTypeId = CS_0024_003C_003E8__locals0.model.ObjectTypeId;
					crmUserTasks.ObjectId = CS_0024_003C_003E8__locals0.model.ObjectId;
					crmUserTasks.UserTaskNoTimeOverlap = CS_0024_003C_003E8__locals0.model.UserTaskNoTimeOverlap;
					crmUserTasks.UserTaskCompanyIds = CS_0024_003C_003E8__locals0.model.UserTaskCompanyIds;
					crmUserTasks.UserTaskRepeatDaily = CS_0024_003C_003E8__locals0.model.UserTaskRepeatDaily;
					crmUserTasks.UserTaskRepeatWeekly = CS_0024_003C_003E8__locals0.model.UserTaskRepeatWeekly;
					crmUserTasks.UserTaskRepeatMonthly = CS_0024_003C_003E8__locals0.model.UserTaskRepeatMonthly;
					crmUserTasks.UserTaskRepeatYearly = CS_0024_003C_003E8__locals0.model.UserTaskRepeatYearly;
					crmUserTasks.UserTaskRemindRepeatDaily = CS_0024_003C_003E8__locals0.model.UserTaskRemindRepeatDaily;
					crmUserTasks.UserTaskRemindRepeatWeekly = CS_0024_003C_003E8__locals0.model.UserTaskRemindRepeatWeekly;
					crmUserTasks.UserTaskRemindRepeatMonthly = CS_0024_003C_003E8__locals0.model.UserTaskRemindRepeatMonthly;
					crmUserTasks.UserTaskRemindRepeatYearly = CS_0024_003C_003E8__locals0.model.UserTaskRemindRepeatYearly;
					crmUserTasks.UserTaskDateEnd = CS_0024_003C_003E8__locals0.model.UserTaskDateEnd;
					crmUserTasks.UserTaskDateEndPersian = CS_0024_003C_003E8__locals0.model.UserTaskDateEndPersian;
					crmUserTasks.UserTaskLinkIdStr = CS_0024_003C_003E8__locals0.model.UserTaskLinkIdStr;
					_dbTbl.Entry(crmUserTasks).State = EntityState.Modified;
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass325_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass325_1();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							DbSet<CrmUserTasks_Lang> crmUserTasks_Lang = _dbTbl.CrmUserTasks_Lang;
							ParameterExpression val = Expression.Parameter(typeof(CrmUserTasks_Lang), "c");
							CrmUserTasks_Lang crmUserTasks_Lang2 = Queryable.FirstOrDefault<CrmUserTasks_Lang>((IQueryable<CrmUserTasks_Lang>)crmUserTasks_Lang, Expression.Lambda<Func<CrmUserTasks_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass325_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass325_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (crmUserTasks_Lang2 != null)
							{
								crmUserTasks_Lang2.UserTaskTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmUserTasks_Lang2.UserTaskDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(crmUserTasks_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							CrmUserTasks_Lang entity = new CrmUserTasks_Lang
							{
								LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
								UserTaskId = crmUserTasks.UserTaskId,
								UserTaskTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
								UserTaskDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
							};
							_dbTbl.CrmUserTasks_Lang.Add(entity);
							_dbTbl.SaveChanges();
						}
					}
					base.ViewBag.SuccessfullUtEdit = Messages.UeserTasksEditSuccessFulMessage;
					Alarms.Update(crmUserTasks.UserId);
					string text3 = "";
					try
					{
						CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
						foreach (CRMspLoadRemindingTask_Result item in Alarms.Get(currentUser.UserId, currentUser.UserLastCId))
						{
							if (text3.Trim() != "")
							{
								text3 += "@";
							}
							text3 = text3 + item.Type + "|" + item.UserTaskId + "|" + item.UserTaskTitle + "|" + item.UserTaskTime + "|" + item.UserTaskDatePersian + "|" + item.UserTaskRemindTime + "|" + item.UserTaskRemindDate + "|" + item.Val1 + "|" + item.Val2 + "|" + item.Val3 + "|" + item.UserTaskDate.ToString() + "|" + item.UserTaskRemindDateTime.ToString() + "|" + ((item.IsRecurringTask != false) ? 1 : 0);
						}
					}
					catch (Exception e4)
					{
						ErrorSignal.FromCurrentContext().Raise(e4);
					}
					base.ViewBag.ResultLocalStorage = text3;
					CS_0024_003C_003E8__locals0.model.FirstRegisterUserId = ((crmUserTasks != null && crmUserTasks.FirstRegisterUserId.HasValue) ? crmUserTasks.FirstRegisterUserId : new int?(UserLogin.CurrentUser.UserId));
					CS_0024_003C_003E8__locals0.model.RegisterDate = now;
					CS_0024_003C_003E8__locals0.model.FirstRegisterDate = now;
					CS_0024_003C_003E8__locals0.model.AppType = crmUserTasks.AppType;
					if (VersionBuyer.Outlook && CS_0024_003C_003E8__locals0.model.SendToOutlook.GetValueOrDefault())
					{
						UserTasks.SendReminderToUserOutlook("UpdateReminder", CS_0024_003C_003E8__locals0.model);
					}
				}
			}
		}
		catch (DbEntityValidationException e5)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e5);
			base.ViewBag.Error = Messages.frmErrorMessage;
		}
		catch (Exception e6)
		{
			ErrorSignal.FromCurrentContext().Raise(e6);
			text = Messages.frmErrorMessage;
		}
		base.ViewBag.Error = text;
		if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.model.UserTaskDatePersian))
		{
			CS_0024_003C_003E8__locals0.model.UserTaskDatePersian = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.model.UserTaskDatePersian);
			if (string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.model.UserTaskRemindDate))
			{
				CS_0024_003C_003E8__locals0.model.UserTaskRemindDate = "";
			}
			else
			{
				CS_0024_003C_003E8__locals0.model.UserTaskRemindDate = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.model.UserTaskRemindDate);
			}
		}
		SetRegisterInfoForUserTask(CS_0024_003C_003E8__locals0.model);
		base.ViewBag.ReminderUsers = SelectUserForLinkedType_SelectListItem(CS_0024_003C_003E8__locals0.model.UserId);
		return View(CS_0024_003C_003E8__locals0.model);
	}

	public List<CRMspSelectCompanyByIds_Result> SelectCompanyByIds(string ids = "", string seperator = ",")
	{
		List<CRMspSelectCompanyByIds_Result> result = new List<CRMspSelectCompanyByIds_Result>();
		try
		{
			if (!string.IsNullOrWhiteSpace(ids))
			{
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
				result = Enumerable.ToList<CRMspSelectCompanyByIds_Result>((IEnumerable<CRMspSelectCompanyByIds_Result>)_dbI.CRMspSelectCompanyByIds(ids, seperator, lCID, result2, result3));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public string SelectCompanyByIdsJs(string ids = "", string seperator = ",")
	{
		return JsonConvert.SerializeObject(SelectCompanyByIds(ids, seperator));
	}

	[HttpPost]
	public ActionResult UpdateUserTaskDidIt(int userTaskId = 0, bool? state = null)
	{
		string text = "";
		string didItDate = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (userTaskId > 0)
			{
				DateTime now = DateTime.Now;
				short value = short.Parse(Financial.Get().Id.ToString());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				DateTime value3 = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				_dbI.CRMspUpdateUserTaskDidIt(userTaskId, state, UserLogin.CurrentUser.UserId, year1: value, month1: value2, registerDate: value3, registerDatePersian: registerDatePersian, appType: Configuration.AppType);
				text = "";
				didItDate = DateTimeClass.GetLocalDate(DateTime.Now).Value.ToString("yyyy/MM/dd");
			}
			else
			{
				text = Messages.msgErrorSelectedItemIsNotAnItem;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text = "Error: " + ex.Message;
		}
		return Json(new
		{
			Message = text,
			DidItDate = didItDate
		}, JsonRequestBehavior.AllowGet);
	}

	[HttpPost]
	public ActionResult UserTaskDidIt(int userTaskId = 0, bool? isFinish = null, string targetDate = "")
	{
		string text = "";
		string text2 = "";
		bool isSuccess = false;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			DateTime value = DateTime.Now;
			if (!string.IsNullOrEmpty(targetDate))
			{
				targetDate = targetDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				value = lCID switch
				{
					1065 => DateTime.Parse(PersianDate.GetFormatetdDate(targetDate) + " " + now.Hour.ToString("00") + ":" + now.Minute.ToString("00") + ":" + now.Second.ToString("00")), 
					1025 => DateTime.Parse(PersianDate.GetFormatetdDate(targetDate) + " " + now.Hour.ToString("00") + ":" + now.Minute.ToString("00") + ":" + now.Second.ToString("00"), new CultureInfo("ar-SA"), DateTimeStyles.None), 
					_ => DateTime.Parse(PersianDate.GetFormatetdDate(targetDate) + " " + now.Hour.ToString("00") + ":" + now.Minute.ToString("00") + ":" + now.Second.ToString("00"), new CultureInfo("en-US"), DateTimeStyles.None), 
				};
			}
			if (userTaskId > 0)
			{
				short value2 = short.Parse(Financial.Get().Id.ToString());
				short value3 = short.Parse(now.ToString("MM", new PersianCulture()));
				DateTime value4 = now;
				string text3 = now.ToString("yyyyMMdd", new PersianCulture());
				CRMspSelectUserTaskById_Result cRMspSelectUserTaskById_Result = Enumerable.FirstOrDefault<CRMspSelectUserTaskById_Result>((IEnumerable<CRMspSelectUserTaskById_Result>)_dbIII.CRMspSelectUserTaskById(lCID, result, userTaskId));
				if (cRMspSelectUserTaskById_Result == null)
				{
					text = Messages.msgErrorUserTaskNotFound;
					return Json(new
					{
						Message = text,
						ResultLocalStorage = text2,
						IsSuccess = isSuccess
					}, JsonRequestBehavior.AllowGet);
				}
				if (cRMspSelectUserTaskById_Result.UserId != UserLogin.CurrentUser.UserId)
				{
					text = Messages.msgErrorUserTaskNotBelongToUser;
					return Json(new
					{
						Message = text,
						ResultLocalStorage = text2,
						IsSuccess = isSuccess
					}, JsonRequestBehavior.AllowGet);
				}
				_ = cRMspSelectUserTaskById_Result.UserTaskRepeatDaily;
				_ = cRMspSelectUserTaskById_Result.UserTaskRepeatWeekly;
				_ = cRMspSelectUserTaskById_Result.UserTaskRepeatMonthly;
				_ = cRMspSelectUserTaskById_Result.UserTaskRepeatYearly;
				bool flag = cRMspSelectUserTaskById_Result.UserTaskRepeatDaily.GetValueOrDefault() || cRMspSelectUserTaskById_Result.UserTaskRepeatWeekly.GetValueOrDefault() || cRMspSelectUserTaskById_Result.UserTaskRepeatMonthly.GetValueOrDefault() || cRMspSelectUserTaskById_Result.UserTaskRepeatYearly.GetValueOrDefault();
				bool flag2 = false;
				if (flag && !string.IsNullOrEmpty(cRMspSelectUserTaskById_Result.UserTaskDidItInfoJson))
				{
					Dictionary<string, string> dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(cRMspSelectUserTaskById_Result.UserTaskDidItInfoJson);
					if (dictionary != null && dictionary.ContainsKey(targetDate))
					{
						flag2 = true;
					}
				}
				if (flag && flag2 && !isFinish.GetValueOrDefault())
				{
					text = Messages.msgErrorUserTaskAlreadyDoneOnDate;
					return Json(new
					{
						Message = text,
						ResultLocalStorage = text2,
						IsSuccess = false
					});
				}
				if ((cRMspSelectUserTaskById_Result.UserTaskDidIt.GetValueOrDefault() && !flag) || (cRMspSelectUserTaskById_Result.UserTaskDidIt.GetValueOrDefault() && flag && isFinish.GetValueOrDefault()))
				{
					text = Messages.msgErrorUserTaskAlreadyCompleted;
					return Json(new
					{
						Message = text,
						ResultLocalStorage = text2,
						IsSuccess = false
					});
				}
				if (isFinish.GetValueOrDefault() && !flag)
				{
					text = Messages.msgErrorUserTaskNotRecurring;
					return Json(new
					{
						Message = text,
						ResultLocalStorage = text2,
						IsSuccess = false
					});
				}
				CRMSpIIIEntities dbIII = _dbIII;
				int? userTaskId2 = userTaskId;
				int? userId = UserLogin.CurrentUser.UserId;
				short? num = value2;
				dbIII.CRMspUserTaskDidIt(month1: value3, year1: num, registerDate: value4, registerDatePersian: text3, appType: Configuration.AppType, isFinish: isFinish, userTaskId: userTaskId2, userId: userId, targetDate: value);
				Alarms.Update(cRMspSelectUserTaskById_Result.UserId);
				try
				{
					CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
					foreach (CRMspLoadRemindingTask_Result item in Alarms.Get(currentUser.UserId, currentUser.UserLastCId))
					{
						if (text2.Trim() != "")
						{
							text2 += "@";
						}
						text2 = text2 + item.Type + "|" + item.UserTaskId + "|" + item.UserTaskTitle + "|" + item.UserTaskTime + "|" + item.UserTaskDatePersian + "|" + item.UserTaskRemindTime + "|" + item.UserTaskRemindDate + "|" + item.Val1 + "|" + item.Val2 + "|" + item.Val3 + "|" + item.UserTaskDate.ToString() + "|" + item.UserTaskRemindDateTime.ToString() + "|" + ((item.IsRecurringTask != false) ? 1 : 0);
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
				isSuccess = true;
				text = ((isFinish.HasValue && isFinish != false) ? Messages.msgPrivateReminderCompletedSuccessfully : Messages.msgPrivateReminderDoneSuccessfully);
			}
			else
			{
				text = Messages.msgErrorSelectedItemIsNotAnItem;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text = "Error: " + ex.Message;
		}
		return Json(new
		{
			Message = text,
			ResultLocalStorage = text2,
			IsSuccess = isSuccess
		}, JsonRequestBehavior.AllowGet);
	}

	public ActionResult AlarmUserTaskDidIt(int userTaskId = 0)
	{
		string text = "";
		string text2 = "";
		bool isSuccess = false;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			if (userTaskId > 0)
			{
				short value = short.Parse(Financial.Get().Id.ToString());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				DateTime value3 = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				CRMspSelectUserTaskById_Result cRMspSelectUserTaskById_Result = Enumerable.FirstOrDefault<CRMspSelectUserTaskById_Result>((IEnumerable<CRMspSelectUserTaskById_Result>)_dbIII.CRMspSelectUserTaskById(lCID, result, userTaskId));
				if (cRMspSelectUserTaskById_Result == null)
				{
					text = Messages.msgErrorUserTaskNotFound;
					return Json(new
					{
						Message = text,
						ResultLocalStorage = text2,
						IsSuccess = isSuccess
					}, JsonRequestBehavior.AllowGet);
				}
				if (cRMspSelectUserTaskById_Result.UserId != UserLogin.CurrentUser.UserId)
				{
					text = Messages.msgErrorUserTaskNotBelongToUser;
					return Json(new
					{
						Message = text,
						ResultLocalStorage = text2,
						IsSuccess = isSuccess
					}, JsonRequestBehavior.AllowGet);
				}
				System.Globalization.Calendar calendar = (lCID switch
				{
					1065 => new CultureInfo("fa-IR"), 
					1025 => new CultureInfo("ar-SA"), 
					_ => new CultureInfo("en-US"), 
				}).Calendar;
				bool? userTaskRemindRepeatDaily = cRMspSelectUserTaskById_Result.UserTaskRemindRepeatDaily;
				bool? userTaskRemindRepeatWeekly = cRMspSelectUserTaskById_Result.UserTaskRemindRepeatWeekly;
				bool? userTaskRemindRepeatMonthly = cRMspSelectUserTaskById_Result.UserTaskRemindRepeatMonthly;
				bool? userTaskRemindRepeatYearly = cRMspSelectUserTaskById_Result.UserTaskRemindRepeatYearly;
				if (!cRMspSelectUserTaskById_Result.UserTaskRemindRepeatDaily.GetValueOrDefault() && !cRMspSelectUserTaskById_Result.UserTaskRemindRepeatWeekly.GetValueOrDefault() && !cRMspSelectUserTaskById_Result.UserTaskRemindRepeatMonthly.GetValueOrDefault() && !cRMspSelectUserTaskById_Result.UserTaskRemindRepeatYearly.GetValueOrDefault())
				{
					text = Messages.msgErrorUserTaskAlreadyCompleted;
					return Json(new
					{
						Message = text,
						ResultLocalStorage = text2,
						IsSuccess = false
					});
				}
				TimeSpan value4 = TimeSpan.Zero;
				if (!string.IsNullOrEmpty(cRMspSelectUserTaskById_Result.UserTaskTime))
				{
					value4 = ((!TimeSpan.TryParse(cRMspSelectUserTaskById_Result.UserTaskTime, out var result2)) ? DateTime.ParseExact(cRMspSelectUserTaskById_Result.UserTaskTime, "HH:mm", CultureInfo.InvariantCulture).TimeOfDay : result2);
				}
				cRMspSelectUserTaskById_Result.UserTaskDate.Date.Add(value4);
				cRMspSelectUserTaskById_Result.UserTaskDateEnd?.Date.Add(value4);
				DateTime? userTaskRemindDateTime = cRMspSelectUserTaskById_Result.UserTaskRemindDateTime;
				DateTime? userTaskRemindDateTime2 = userTaskRemindDateTime;
				string userTaskRemindDate = null;
				if (userTaskRemindDateTime.HasValue && userTaskRemindDateTime <= now)
				{
					userTaskRemindDateTime2 = GetNextRepeatDate(calendar, userTaskRemindDateTime.Value, now, null, userTaskRemindRepeatDaily.GetValueOrDefault(), userTaskRemindRepeatWeekly.GetValueOrDefault(), userTaskRemindRepeatMonthly.GetValueOrDefault(), userTaskRemindRepeatYearly.GetValueOrDefault());
					if (userTaskRemindDateTime2.HasValue)
					{
						DateTime date = userTaskRemindDateTime2.Value.Date;
						DateTime value5 = userTaskRemindDateTime.Value;
						userTaskRemindDateTime2 = date.AddHours(value5.Hour).AddMinutes(value5.Minute).AddSeconds(value5.Second);
						userTaskRemindDate = userTaskRemindDateTime2.Value.ToString("yyyyMMdd", new PersianCulture());
					}
				}
				_dbIII.CRMspUserTaskAlarmDidIt(userTaskId, UserLogin.CurrentUser.UserId, year1: value, month1: value2, registerDate: value3, registerDatePersian: registerDatePersian, appType: Configuration.AppType, userTaskRemindDateTime: userTaskRemindDateTime2, userTaskRemindDate: userTaskRemindDate);
				Alarms.Update(cRMspSelectUserTaskById_Result.UserId);
				try
				{
					CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
					foreach (CRMspLoadRemindingTask_Result item in Alarms.Get(currentUser.UserId, currentUser.UserLastCId))
					{
						if (text2.Trim() != "")
						{
							text2 += "@";
						}
						text2 = text2 + item.Type + "|" + item.UserTaskId + "|" + item.UserTaskTitle + "|" + item.UserTaskTime + "|" + item.UserTaskDatePersian + "|" + item.UserTaskRemindTime + "|" + item.UserTaskRemindDate + "|" + item.Val1 + "|" + item.Val2 + "|" + item.Val3 + "|" + item.UserTaskDate.ToString() + "|" + item.UserTaskRemindDateTime.ToString() + "|" + ((item.IsRecurringTask != false) ? 1 : 0);
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
				isSuccess = true;
				text = Messages.msgReminderAlarmTimeChangedSuccessfully;
			}
			else
			{
				text = Messages.msgErrorSelectedItemIsNotAnItem;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text = "Error: " + ex.Message;
		}
		return Json(new
		{
			Message = text,
			ResultLocalStorage = text2,
			IsSuccess = isSuccess
		}, JsonRequestBehavior.AllowGet);
	}

	private DateTime? GetNextRepeatDate(System.Globalization.Calendar calendar, DateTime startDate, DateTime currentDate, DateTime? endDate, bool repeatDaily, bool repeatWeekly, bool repeatMonthly, bool repeatYearly)
	{
		if (startDate == DateTime.MinValue || startDate == DateTime.MaxValue)
		{
			return null;
		}
		if (endDate.HasValue && startDate.Date > endDate.Value.Date)
		{
			return null;
		}
		if (startDate.Date > currentDate.Date)
		{
			return startDate;
		}
		DateTime dateTime = startDate;
		if (repeatDaily)
		{
			int num = (int)(currentDate.Date - startDate.Date).TotalDays;
			if (num < 0)
			{
				return startDate;
			}
			dateTime = startDate.AddDays(num + 1);
		}
		else if (repeatWeekly)
		{
			while (dateTime.Date <= currentDate.Date)
			{
				dateTime = dateTime.AddDays(7.0);
			}
		}
		else if (repeatMonthly)
		{
			while (dateTime.Date <= currentDate.Date)
			{
				dateTime = calendar.AddMonths(dateTime, 1);
			}
		}
		else
		{
			if (!repeatYearly)
			{
				return null;
			}
			while (dateTime.Date <= currentDate.Date)
			{
				dateTime = calendar.AddYears(dateTime, 1);
			}
		}
		if (endDate.HasValue && dateTime.Date > endDate.Value.Date)
		{
			return null;
		}
		return dateTime;
	}

	[AjaxOnly]
	public string CReminderPrivateTaskDelete(int utid, string UserTaskLinkIdStr = null)
	{
		string result = "-1";
		try
		{
			if (_dbTbl.CrmUserTasks.Find(utid) != null)
			{
				int? centerId = null;
				if (UserLogin.CurrentUser != null)
				{
					centerId = UserLogin.CurrentUser.UserLastCId;
				}
				if (db.CRMspDeleteCrmUserTasks(utid) > 0)
				{
					Alarms.Update(UserLogin.CurrentUser.UserId, centerId);
					string text = "";
					try
					{
						foreach (CRMspLoadRemindingTask_Result item in Alarms.Get(UserLogin.CurrentUser.UserId, centerId))
						{
							if (text.Trim() != "")
							{
								text += "@";
							}
							text = text + item.Type + "|" + item.UserTaskId + "|" + item.UserTaskTitle + "|" + item.UserTaskTime + "|" + item.UserTaskDatePersian + "|" + item.UserTaskRemindTime + "|" + item.UserTaskRemindDate + "|" + item.Val1 + "|" + item.Val2 + "|" + item.Val3 + "|" + item.UserTaskDate.ToString() + "|" + item.UserTaskRemindDateTime.ToString() + "|" + ((item.IsRecurringTask != false) ? 1 : 0);
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
					}
					result = text;
					if (VersionBuyer.Outlook && !string.IsNullOrWhiteSpace(UserTaskLinkIdStr))
					{
						UserTasks.SendReminderToUserOutlook("DeleteReminder", null, null, UserTaskLinkIdStr);
					}
				}
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return result;
	}

	[LoginAuthorize]
	[HttpPost]
	public string GetNextWeekDate(string date = "")
	{
		string result = "";
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		if (result2 <= 0)
		{
			result2 = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		DateTime dateTime = default(DateTime);
		string text = "";
		try
		{
			if (!string.IsNullOrWhiteSpace(date))
			{
				text = PersianDate.GetFormatetdDate(date.Replace("/", ""));
				switch (lCID)
				{
				case 1065:
					dateTime = DateTime.Parse(text + " 00:00:00", new PersianCulture());
					date = dateTime.ToString("yyyy/MM/dd");
					break;
				case 1025:
					dateTime = DateTime.Parse(text + " 00:00:00", new CultureInfo("ar-SA"));
					date = dateTime.ToString("yyyy/MM/dd", new PersianCulture());
					break;
				default:
					dateTime = DateTime.Parse(text + " 00:00:00", new CultureInfo("en-US"));
					date = dateTime.ToString("yyyy/MM/dd", new PersianCulture());
					break;
				}
				result = dateTime.AddDays(7.0).ToString("yyyy/MM/dd");
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[LoginAuthorize]
	[HttpPost]
	public string GetPreviousWeekDate(string date = "")
	{
		string result = "";
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		if (result2 <= 0)
		{
			result2 = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		DateTime dateTime = default(DateTime);
		string text = "";
		try
		{
			if (!string.IsNullOrWhiteSpace(date))
			{
				text = PersianDate.GetFormatetdDate(date.Replace("/", ""));
				switch (lCID)
				{
				case 1065:
					dateTime = DateTime.Parse(text + " 00:00:00", new PersianCulture());
					date = dateTime.ToString("yyyy/MM/dd");
					break;
				case 1025:
					dateTime = DateTime.Parse(text + " 00:00:00", new CultureInfo("ar-SA"));
					date = dateTime.ToString("yyyy/MM/dd", new PersianCulture());
					break;
				default:
					dateTime = DateTime.Parse(text + " 00:00:00", new CultureInfo("en-US"));
					date = dateTime.ToString("yyyy/MM/dd", new PersianCulture());
					break;
				}
				result = dateTime.AddDays(-7.0).ToString("yyyy/MM/dd");
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public string ChkBeforeSubmitUserTask_Lang(UserTasksLanguageViewModel uTask, List<CommonMultiLanguageViewModel> listModelObj_UserTaskTitle_Lang, ref int countError)
	{
		string text = "";
		if (string.IsNullOrEmpty(uTask.UserTaskTitle))
		{
			text = text + Messages.CheckUserTaskTitle + "<br>";
			countError++;
		}
		else if (!checkMultiLanguage(uTask.UserTaskTitle, listModelObj_UserTaskTitle_Lang))
		{
			text = text + Messages.CheckUserTaskTitleLang + "<br>";
			countError++;
		}
		if (string.IsNullOrEmpty(uTask.UserTaskDatePersian))
		{
			text = text + Messages.CheckUserTaskDatePersian + "<br>";
			countError++;
		}
		if (string.IsNullOrEmpty(uTask.UserTaskTime))
		{
			text = text + Messages.CheckUserTaskTime + "<br>";
			countError++;
		}
		return text;
	}

	[AjaxOnly]
	public JsonResult GetConversationGrorpStatus()
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
			List<CRMspSelectConversationStatusGroups_Result> list2 = Enumerable.ToList<CRMspSelectConversationStatusGroups_Result>((IEnumerable<CRMspSelectConversationStatusGroups_Result>)db.CRMspSelectConversationStatusGroups(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectConversationStatusGroups_Result, SelectListItem>((IEnumerable<CRMspSelectConversationStatusGroups_Result>)list2, (Func<CRMspSelectConversationStatusGroups_Result, SelectListItem>)((CRMspSelectConversationStatusGroups_Result item) => new SelectListItem
			{
				Text = item.ConversationStatusGroup,
				Value = item.ConversationStatusGroupID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ConversationStatusList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult _PartialReminderProject()
	{
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult ReminderProject_Read([DataSourceRequest] DataSourceRequest request, string fDate, string tDate, int prjcnvsStatusGroupId, bool prjIsFinished)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectCompanyProjectFromRemindDate_Result> list = new List<CRMspSelectCompanyProjectFromRemindDate_Result>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (!string.IsNullOrEmpty(fDate) && !string.IsNullOrEmpty(tDate) && prjcnvsStatusGroupId != 0)
			{
				string text = fDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				string text2 = tDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				DateTime value = DateTime.Now;
				DateTime value2 = DateTime.Now;
				if (!string.IsNullOrEmpty(text))
				{
					value = DateTime.Parse(PersianDate.GetFormatetdDate(text.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(text2))
				{
					value2 = DateTime.Parse(PersianDate.GetFormatetdDate(text2.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				int userId = UserLogin.CurrentUser.UserId;
				list = Enumerable.ToList<CRMspSelectCompanyProjectFromRemindDate_Result>((IEnumerable<CRMspSelectCompanyProjectFromRemindDate_Result>)db.CRMspSelectCompanyProjectFromRemindDate(text, text2, value, value2, prjIsFinished, prjcnvsStatusGroupId, lCID, result, userId, result2));
				foreach (CRMspSelectCompanyProjectFromRemindDate_Result item in list)
				{
					item.prjRemindDate = ConverDateTimeToDate(item.prjRemindDateTime);
					item.cmpCode = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccCodeWithComa(1, item.cmpCode);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actcStatus")]
	public ActionResult CStatus()
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
		List<CRMspSelectCompanyProjectTitle_Result> list = Enumerable.ToList<CRMspSelectCompanyProjectTitle_Result>((IEnumerable<CRMspSelectCompanyProjectTitle_Result>)db.CRMspSelectCompanyProjectTitle("", UserLogin.CurrentUser.UserId, lCID, result, result2));
		base.ViewBag.lstProjects = Enumerable.Select<CRMspSelectCompanyProjectTitle_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyProjectTitle_Result>)list, (Func<CRMspSelectCompanyProjectTitle_Result, SelectListItem>)((CRMspSelectCompanyProjectTitle_Result x) => new SelectListItem
		{
			Text = x.prjTitle,
			Value = x.prjTitle
		}));
		List<CRMspSelectProvince_Result> list2 = Enumerable.ToList<CRMspSelectProvince_Result>((IEnumerable<CRMspSelectProvince_Result>)db.CRMspSelectProvince(lCID, result));
		base.ViewBag.Province = Enumerable.Select<CRMspSelectProvince_Result, SelectListItem>((IEnumerable<CRMspSelectProvince_Result>)list2, (Func<CRMspSelectProvince_Result, SelectListItem>)((CRMspSelectProvince_Result x) => new SelectListItem
		{
			Text = x.Province,
			Value = x.ProvinceID.ToString()
		}));
		List<SelectListItem> list3 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyReferUsers_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyReferUsers_Result>)Enumerable.ToList<CRMspSelectCompanyReferUsers_Result>((IEnumerable<CRMspSelectCompanyReferUsers_Result>)db.CRMspSelectCompanyReferUsers(UserLogin.CurrentUser.UserId, lCID, result, result2)), (Func<CRMspSelectCompanyReferUsers_Result, SelectListItem>)((CRMspSelectCompanyReferUsers_Result item) => new SelectListItem
		{
			Text = item.USER,
			Value = item.UserId.ToString(),
			Selected = false
		})));
		base.ViewBag.cmpReferUserList = list3;
		return View();
	}

	[HttpPost]
	[LoginAuthorize]
	public List<CRMspUserTreeStatusCartableWeb_Result> UserTreeStatusCartableWeb()
	{
		List<CRMspUserTreeStatusCartableWeb_Result> result = new List<CRMspUserTreeStatusCartableWeb_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			int userId = UserLogin.CurrentUser.UserId;
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Financial.Get().Id;
			now.ToString("yyyyMMdd", new PersianCulture());
			_ = Configuration.AppType;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			List<CRMspUserTreeStatusCartableWeb_Result> list = Enumerable.ToList<CRMspUserTreeStatusCartableWeb_Result>((IEnumerable<CRMspUserTreeStatusCartableWeb_Result>)dbI.CRMspUserTreeStatusCartableWeb(userId, 3, Labels.AllUsers, "", lCID, result2, result3));
			if (list != null)
			{
				result = list;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string UserTreeStatusCartableWebJs()
	{
		return JsonConvert.SerializeObject(UserTreeStatusCartableWeb());
	}

	[HttpPost]
	[LoginAuthorize]
	public List<CRMspUserTreeStatusCartableWebByStatus_Result> UserTreeStatusCartableWebByStatus(int? userId = -1)
	{
		List<CRMspUserTreeStatusCartableWebByStatus_Result> result = new List<CRMspUserTreeStatusCartableWebByStatus_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			if (!userId.HasValue || userId.GetValueOrDefault() == -1)
			{
				userId = UserLogin.CurrentUser.UserId;
			}
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Financial.Get().Id;
			now.ToString("yyyyMMdd", new PersianCulture());
			_ = Configuration.AppType;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			List<CRMspUserTreeStatusCartableWebByStatus_Result> list = Enumerable.ToList<CRMspUserTreeStatusCartableWebByStatus_Result>((IEnumerable<CRMspUserTreeStatusCartableWebByStatus_Result>)_dbI.CRMspUserTreeStatusCartableWebByStatus(UserLogin.CurrentUser.UserId, userId, 3, Labels.AllStatus, lCID, result2, result3));
			if (list != null)
			{
				result = list;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string UserTreeStatusCartableWebByStatusJs(int? userId = -1)
	{
		return JsonConvert.SerializeObject(UserTreeStatusCartableWebByStatus(userId));
	}

	[HttpPost]
	[LoginAuthorize]
	public List<CRMspResultsStatusCartableWeb_Result> ResultsStatusCartable(int selectedUserId = 0, int statusId = 0, int lastRowNumber = 0, int pageSize = 300)
	{
		List<CRMspResultsStatusCartableWeb_Result> result = new List<CRMspResultsStatusCartableWeb_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			short.Parse(Financial.Get().Id.ToString());
			_ = Financial.Get().Id;
			_ = Configuration.AppType;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			List<CRMspResultsStatusCartableWeb_Result> list = Enumerable.ToList<CRMspResultsStatusCartableWeb_Result>((IEnumerable<CRMspResultsStatusCartableWeb_Result>)dbI.CRMspResultsStatusCartableWeb(userId, selectedUserId, statusId, lCID, result2, lastRowNumber, pageSize, false, result3));
			if (list != null)
			{
				foreach (CRMspResultsStatusCartableWeb_Result item in list)
				{
					if (item.RemindDateTime.HasValue)
					{
						DateTime.TryParse(item.RemindDateTime.ToString(), out var result4);
						item.RemindDate = result4.ToString("yyyy/MM/dd");
					}
					else if (!string.IsNullOrEmpty(item.RemindDate))
					{
						if (lCID != 1065)
						{
							item.RemindDate = DateTime.ParseExact(PersianDate.GetFormatetdDate(item.RemindDate.Replace("/", "")), "yyyy/MM/dd", new PersianCulture()).ToString("yyyy/MM/dd");
						}
						else
						{
							item.RemindDate = PersianDate.GetFormatetdDate(item.RemindDate.Replace("/", ""));
						}
					}
					if (item.cnvsDateTime.HasValue)
					{
						DateTime.TryParse(item.cnvsDateTime.ToString(), out var result5);
						item.cnvsDate = result5.ToString("yyyy/MM/dd");
					}
					else if (!string.IsNullOrEmpty(item.cnvsDate))
					{
						if (lCID != 1065)
						{
							item.cnvsDate = DateTime.ParseExact(PersianDate.GetFormatetdDate(item.cnvsDate.Replace("/", "")), "yyyy/MM/dd", new PersianCulture()).ToString("yyyy/MM/dd");
						}
						else
						{
							item.cnvsDate = PersianDate.GetFormatetdDate(item.cnvsDate.Replace("/", ""));
						}
					}
					_ = item.RegisterDate;
					item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd");
				}
				result = list;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string ResultsStatusCartableJs(int selectedUserId = 0, int statusId = 0, int lastRowNumber = 0, int pageSize = 300)
	{
		return JsonConvert.SerializeObject(ResultsStatusCartable(selectedUserId, statusId, lastRowNumber, pageSize));
	}

	[AjaxOnly]
	public ActionResult _PartialCStatus()
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
			List<CRMspUserTreeStatusCartable_Result> list = Enumerable.ToList<CRMspUserTreeStatusCartable_Result>((IEnumerable<CRMspUserTreeStatusCartable_Result>)db.CRMspUserTreeStatusCartable(UserLogin.CurrentUser.UserId, 3, Labels.AllUsers, Labels.AllStatus, lCID, result, result2));
			List<CRMspUserTreeStatusCartable_Result> list2 = Enumerable.ToList<CRMspUserTreeStatusCartable_Result>(Enumerable.Where<CRMspUserTreeStatusCartable_Result>((IEnumerable<CRMspUserTreeStatusCartable_Result>)list, (Func<CRMspUserTreeStatusCartable_Result, bool>)((CRMspUserTreeStatusCartable_Result c) => c.RootID == 0)));
			List<TreeViewItemModel> list3 = new List<TreeViewItemModel>
			{
				new TreeViewItemModel
				{
					HtmlAttributes = 
					{
						new KeyValuePair<string, string>("accesskey", "-1|-1")
					},
					Id = "-1|-1",
					Text = Labels.Empty,
					ImageUrl = "",
					Items = null
				}
			};
			foreach (CRMspUserTreeStatusCartable_Result item in list2)
			{
				TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
				treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.RootID + "|" + item.KeyId.ToString()));
				treeViewItemModel.Id = item.RootID + "|" + item.KeyId.ToString();
				treeViewItemModel.Text = item.KeyName;
				treeViewItemModel.ImageUrl = "";
				List<CRMspUserTreeStatusCartable_Result> list4 = Enumerable.ToList<CRMspUserTreeStatusCartable_Result>(Enumerable.Where<CRMspUserTreeStatusCartable_Result>((IEnumerable<CRMspUserTreeStatusCartable_Result>)list, (Func<CRMspUserTreeStatusCartable_Result, bool>)((CRMspUserTreeStatusCartable_Result c) => c.RootID == int.Parse(item.KeyId))));
				List<TreeViewItemModel> list5 = new List<TreeViewItemModel>();
				foreach (CRMspUserTreeStatusCartable_Result item2 in list4)
				{
					TreeViewItemModel treeViewItemModel2 = new TreeViewItemModel();
					treeViewItemModel2.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item2.RootID + "|" + item2.KeyId.ToString()));
					treeViewItemModel2.Id = item2.RootID + "|" + item2.KeyId.ToString();
					treeViewItemModel2.Text = item2.KeyName;
					treeViewItemModel2.ImageUrl = "";
					treeViewItemModel2.Items = null;
					list5.Add(treeViewItemModel2);
				}
				treeViewItemModel.Items = new List<TreeViewItemModel>(list5);
				list3.Add(treeViewItemModel);
			}
			base.ViewBag.CStatusTree = list3;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult _PartialCStatusGrid(int rootid, string treeid, int flagMoreInfo)
	{
		base.ViewBag.RootIdStatusId = rootid + "|" + treeid + "|" + flagMoreInfo;
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult CStatus_Read([DataSourceRequest] DataSourceRequest request, string rootIdStatusId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string[] array = rootIdStatusId.Split(new char[1] { '|' });
		List<CRMspResultsStatusCartable_Result> list = new List<CRMspResultsStatusCartable_Result>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (array[1] != null && array[1] != "0")
			{
				int num = int.Parse(array[0]);
				string cnvsStatusId = array[1];
				if (num != 0)
				{
					list = Enumerable.ToList<CRMspResultsStatusCartable_Result>((IEnumerable<CRMspResultsStatusCartable_Result>)db.CRMspResultsStatusCartable(UserLogin.CurrentUser.UserId, num, cnvsStatusId, lCID, result, result2));
				}
			}
			foreach (CRMspResultsStatusCartable_Result item in list)
			{
				if (item.RemindDateTime.HasValue)
				{
					DateTime.TryParse(item.RemindDateTime.ToString(), out var result3);
					item.RemindDate = result3.ToString("yyyy/MM/dd");
				}
				else if (!string.IsNullOrEmpty(item.RemindDate))
				{
					if (lCID != 1065)
					{
						item.RemindDate = DateTime.ParseExact(PersianDate.GetFormatetdDate(item.RemindDate.Replace("/", "")), "yyyy/MM/dd", new PersianCulture()).ToString("yyyy/MM/dd");
					}
					else
					{
						item.RemindDate = PersianDate.GetFormatetdDate(item.RemindDate.Replace("/", ""));
					}
				}
				if (item.cnvsDateTime.HasValue)
				{
					DateTime.TryParse(item.cnvsDateTime.ToString(), out var result4);
					item.cnvsDate = result4.ToString("yyyy/MM/dd");
				}
				else if (!string.IsNullOrEmpty(item.cnvsDate))
				{
					if (lCID != 1065)
					{
						item.cnvsDate = DateTime.ParseExact(PersianDate.GetFormatetdDate(item.cnvsDate.Replace("/", "")), "yyyy/MM/dd", new PersianCulture()).ToString("yyyy/MM/dd");
					}
					else
					{
						item.cnvsDate = PersianDate.GetFormatetdDate(item.cnvsDate.Replace("/", ""));
					}
				}
				_ = item.RegisterDate;
				item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd");
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	[LoginAuthorize]
	public ActionResult _PartialFunnelCampaignTree(int cmpId = 0)
	{
		try
		{
			List<TreeViewItemModel> funnelCampaignTree = GetFunnelCampaignTree(cmpId);
			base.ViewBag.funnelCampaignTree = funnelCampaignTree;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView();
	}

	[HttpPost]
	[LoginAuthorize]
	public List<TreeViewItemModel> GetFunnelCampaignNodeTree(List<CRMspSelectCompanyCampaignTreeByCmpId_Result> lstCamp, int? currCamId)
	{
		List<TreeViewItemModel> list = new List<TreeViewItemModel>();
		try
		{
			List<CRMspSelectCompanyCampaignTreeByCmpId_Result> list2 = Enumerable.ToList<CRMspSelectCompanyCampaignTreeByCmpId_Result>(Enumerable.Where<CRMspSelectCompanyCampaignTreeByCmpId_Result>((IEnumerable<CRMspSelectCompanyCampaignTreeByCmpId_Result>)lstCamp, (Func<CRMspSelectCompanyCampaignTreeByCmpId_Result, bool>)((CRMspSelectCompanyCampaignTreeByCmpId_Result m) => m.ParentId == currCamId)));
			if (Enumerable.Any<CRMspSelectCompanyCampaignTreeByCmpId_Result>((IEnumerable<CRMspSelectCompanyCampaignTreeByCmpId_Result>)list2))
			{
				foreach (CRMspSelectCompanyCampaignTreeByCmpId_Result item in list2)
				{
					TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
					treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.CompanyCampaignId.ToString()));
					treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("campaignFullName", item.CampaignFullName.ToString()));
					treeViewItemModel.Id = item.CompanyCampaignId.ToString();
					treeViewItemModel.Text = item.CampaignName;
					treeViewItemModel.ImageUrl = "";
					treeViewItemModel.Checked = item.IsChekced.HasValue && item.IsChekced != false;
					List<TreeViewItemModel> funnelCampaignNodeTree = GetFunnelCampaignNodeTree(lstCamp, item.CompanyCampaignId);
					treeViewItemModel.Items = new List<TreeViewItemModel>(funnelCampaignNodeTree);
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

	[LoginAuthorize]
	public List<TreeViewItemModel> GetFunnelCampaignTree(int cmpId = 0)
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
			List<CRMspSelectCompanyCampaignTreeByCmpId_Result> list2 = Enumerable.ToList<CRMspSelectCompanyCampaignTreeByCmpId_Result>((IEnumerable<CRMspSelectCompanyCampaignTreeByCmpId_Result>)_dbI.CRMspSelectCompanyCampaignTreeByCmpId(cmpId, lCID, result));
			if (Enumerable.Any<CRMspSelectCompanyCampaignTreeByCmpId_Result>((IEnumerable<CRMspSelectCompanyCampaignTreeByCmpId_Result>)list2))
			{
				List<CRMspSelectCompanyCampaignTreeByCmpId_Result> list3 = Enumerable.ToList<CRMspSelectCompanyCampaignTreeByCmpId_Result>(Enumerable.Where<CRMspSelectCompanyCampaignTreeByCmpId_Result>((IEnumerable<CRMspSelectCompanyCampaignTreeByCmpId_Result>)list2, (Func<CRMspSelectCompanyCampaignTreeByCmpId_Result, bool>)((CRMspSelectCompanyCampaignTreeByCmpId_Result m) => m.ParentId == 0)));
				if (Enumerable.Any<CRMspSelectCompanyCampaignTreeByCmpId_Result>((IEnumerable<CRMspSelectCompanyCampaignTreeByCmpId_Result>)list3))
				{
					foreach (CRMspSelectCompanyCampaignTreeByCmpId_Result item in list3)
					{
						TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
						treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.CompanyCampaignId.ToString()));
						treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("campaignFullName", item.CampaignFullName.ToString()));
						treeViewItemModel.Id = item.CompanyCampaignId.ToString();
						treeViewItemModel.Text = item.CampaignName;
						treeViewItemModel.ImageUrl = "";
						treeViewItemModel.Checked = item.IsChekced.HasValue && item.IsChekced != false;
						List<TreeViewItemModel> funnelCampaignNodeTree = GetFunnelCampaignNodeTree(list2, item.CompanyCampaignId);
						treeViewItemModel.Items = new List<TreeViewItemModel>(funnelCampaignNodeTree);
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

	[HttpPost]
	[LoginAuthorize]
	public string GetFunnelCampaignList(int cmpId = 0)
	{
		string result = "";
		List<CommonTreeViewItemViewModel> list = new List<CommonTreeViewItemViewModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectCompanyCampaignByCmpId_Result> list2 = Enumerable.ToList<CRMspSelectCompanyCampaignByCmpId_Result>((IEnumerable<CRMspSelectCompanyCampaignByCmpId_Result>)_dbI.CRMspSelectCompanyCampaignByCmpId(cmpId, lCID, result2));
			if (list2 != null && Enumerable.Any<CRMspSelectCompanyCampaignByCmpId_Result>((IEnumerable<CRMspSelectCompanyCampaignByCmpId_Result>)list2))
			{
				foreach (CRMspSelectCompanyCampaignByCmpId_Result item2 in list2)
				{
					CommonTreeViewItemViewModel item = new CommonTreeViewItemViewModel
					{
						Id = item2.CompanyCampaignId.ToString(),
						Text = (item2.CampaignName ?? "")
					};
					list.Add(item);
				}
			}
			if (list != null)
			{
				result = JsonConvert.SerializeObject(Enumerable.ToList<CommonTreeViewItemViewModel>((IEnumerable<CommonTreeViewItemViewModel>)list));
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
		return result;
	}

	public JsonResult GetPresentationLists()
	{
		List<CrmDroupDownItem> list = new List<CrmDroupDownItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectCompanyPresentation_Result> list2 = Enumerable.ToList<CRMspSelectCompanyPresentation_Result>((IEnumerable<CRMspSelectCompanyPresentation_Result>)db.CRMspSelectCompanyPresentation(lCID, result));
			CrmDroupDownItem item = new CrmDroupDownItem
			{
				text = Labels.SelectedListDefValue,
				value = ""
			};
			list.Add(item);
			foreach (CRMspSelectCompanyPresentation_Result item2 in list2)
			{
				list.Add(new CrmDroupDownItem
				{
					text = item2.Presentation,
					value = item2.CompanyPresentationID.ToString()
				});
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

	[HttpPost]
	public string GetFunnelChartData(int? userId = -1, string cmpCampaignIds = null, int? cmpCityId = null, int? cmpPresentationId = null, int? cmpProvinceId = null, int? cmpReferUserId = null, string prjTitle = null, DateTime? cnvsFDateTime = null, DateTime? cnvsTDateTime = null)
	{
		List<CRMspChartConversationStatusSalesFunnelSteps_Result> list = null;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (!userId.HasValue || userId.GetValueOrDefault() == -1)
			{
				userId = UserLogin.CurrentUser.UserId;
			}
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			CRMSpIIEntities dbII = _dbII;
			int? userId2 = userId;
			int? cmpCityId2 = cmpCityId;
			List<CRMspChartConversationStatusSalesFunnelSteps_Result> list2 = Enumerable.ToList<CRMspChartConversationStatusSalesFunnelSteps_Result>((IEnumerable<CRMspChartConversationStatusSalesFunnelSteps_Result>)dbII.CRMspChartConversationStatusSalesFunnelSteps(userId2, cmpReferUserId, cmpPresentationId, cmpCampaignIds, null, cmpProvinceId, cmpCityId2, prjTitle, cnvsFDateTime, cnvsTDateTime, lCID, result, result2));
			if (list2 != null)
			{
				list = list2;
			}
			list.ForEach(delegate(CRMspChartConversationStatusSalesFunnelSteps_Result model)
			{
				model.SalesFunnelStepColor = TColorToHex(model.SalesFunnelStepColor);
			});
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	public string GetCity(int? userId = -1, int provinceId = 0)
	{
		List<CRMspSelectCompanyCity_Result> value = null;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (!userId.HasValue || userId.GetValueOrDefault() == -1)
			{
				userId = UserLogin.CurrentUser.UserId;
			}
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectCompanyCity_Result> list = Enumerable.ToList<CRMspSelectCompanyCity_Result>((IEnumerable<CRMspSelectCompanyCity_Result>)db.CRMspSelectCompanyCity(userId, provinceId, lCID, result, result2));
			if (list != null)
			{
				value = list;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return JsonConvert.SerializeObject(value);
	}
}

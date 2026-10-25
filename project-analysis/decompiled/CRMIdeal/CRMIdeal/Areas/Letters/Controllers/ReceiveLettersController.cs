using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
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
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Letters.Controllers;

public class ReceiveLettersController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public int id;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass13_0
	{
		public int letterId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass17_0
	{
		public int id;

		public int currLangID;

		internal bool _003CInsertEdit_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

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
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass18_0
	{
		public CRMspSelectCompanyById_Result cmp;

		public SecLettersLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__27;

		public Func<Languages, bool> _003C_003E9__74;

		internal bool _003CInsertEdit_003Eb__0(CRMspSelectCompanyTitle_Result c)
		{
			return c.CompanyTitleID == cmp.cmpTitleId;
		}

		internal bool _003CInsertEdit_003Eb__1(CRMspSelectCompanyTitle_Result c)
		{
			return c.CompanyTitleID == cmp.cmpTitleId;
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

		internal bool _003CInsertEdit_003Eb__27(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__74(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass18_1
	{
		public SecLetters model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass18_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass18_1 CS_0024_003C_003E8__locals1;

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
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actltrReceiveLetters")]
	public ActionResult Index(int? id = null, bool? isOpenNew = null, bool? fromIndicator = null, string parameters = "", int? companyId = null, string intMsgInfo = "", int letterId = 0, int? selWorkflowStepId = null)
	{
		if (!string.IsNullOrWhiteSpace(intMsgInfo))
		{
			base.ViewBag.IntMsgInfo = intMsgInfo;
		}
		base.ViewBag.SelectedWorkflowStepId = selWorkflowStepId;
		base.ViewBag.Parameters = parameters;
		base.ViewBag.SendedLetterId = 0;
		base.ViewBag.CompanyId = 0;
		base.ViewBag.FromSearchId = false;
		if (id.HasValue)
		{
			base.ViewBag.SendedLetterId = id;
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
		base.ViewBag.LetterId = letterId;
		return View();
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actltrReceiveLetters")]
	public JsonResult GetLetter(int currentId, string fromDate, string toDate, int ltType = 2, int? companyId = null, int? letterId = null, int? userId = null, bool? fromIndicator = false)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		ltType = 2;
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
		CurrentLetterViewModel currentLetterViewModel = new CurrentLetterViewModel();
		currentLetterViewModel.LastVerificationStep = new WSspSelectVerificationWorkFlowStepLast_Result();
		if (!userId.HasValue)
		{
			userId = UserLogin.CurrentUser.UserId;
		}
		if (!letterId.HasValue)
		{
			letterId = 0;
		}
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<SecspSelectLettersByType_Result> list = Enumerable.ToList<SecspSelectLettersByType_Result>((IEnumerable<SecspSelectLettersByType_Result>)_db.SecspSelectLettersByType(ltType, fromDate, toDate, letterId, lCID, result, value, now, UserLogin.CurrentUser.UserId, result2));
			if (Enumerable.Any<SecspSelectLettersByType_Result>((IEnumerable<SecspSelectLettersByType_Result>)list))
			{
				currentLetterViewModel.IsFind = true;
				currentLetterViewModel.Message = "";
				currentLetterViewModel.FromDate = fromDate;
				currentLetterViewModel.ToDate = toDate;
				currentLetterViewModel.NextId = -1;
				currentLetterViewModel.PreviousId = -1;
				currentLetterViewModel.CompanyId = -1;
				currentLetterViewModel.FirstId = -1;
				currentLetterViewModel.LastId = -1;
				if (list.Count == 1)
				{
					currentLetterViewModel.FirstId = -1;
					currentLetterViewModel.LastId = -1;
				}
				else
				{
					currentLetterViewModel.FirstId = Enumerable.FirstOrDefault<SecspSelectLettersByType_Result>((IEnumerable<SecspSelectLettersByType_Result>)list).LetterId;
					currentLetterViewModel.LastId = Enumerable.LastOrDefault<SecspSelectLettersByType_Result>((IEnumerable<SecspSelectLettersByType_Result>)list).LetterId;
				}
				SecspSelectLettersByType_Result secspSelectLettersByType_Result = ((currentId <= 0) ? Enumerable.LastOrDefault<SecspSelectLettersByType_Result>((IEnumerable<SecspSelectLettersByType_Result>)list) : list.Find((SecspSelectLettersByType_Result c) => c.LetterId == currentId));
				if (secspSelectLettersByType_Result != null)
				{
					if (Letter.IsEditAfterFix(secspSelectLettersByType_Result.LetterEditAfterFixInfoJs, secspSelectLettersByType_Result.LetterId, 1))
					{
						secspSelectLettersByType_Result.LetterIsFixed = false;
					}
					if (!string.IsNullOrWhiteSpace((secspSelectLettersByType_Result.LetterEditAfterFixInfoJs ?? "").Replace("[]", "")))
					{
						List<EditAfterFixInfoViewModel> list2 = JsonConvert.DeserializeObject<List<EditAfterFixInfoViewModel>>(secspSelectLettersByType_Result.LetterEditAfterFixInfoJs);
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
							secspSelectLettersByType_Result.LetterEditAfterFixInfoJs = JsonConvert.SerializeObject(list2);
						}
					}
					secspSelectLettersByType_Result.LetterDateTime = secspSelectLettersByType_Result.LetterDateTime;
					_ = secspSelectLettersByType_Result.LetterDateTime;
					secspSelectLettersByType_Result.LetterDate = secspSelectLettersByType_Result.LetterDateTime.ToString("yyyy/MM/dd");
					secspSelectLettersByType_Result.LetterLastPrintDate = (secspSelectLettersByType_Result.LetterLastPrintDateTime.HasValue ? secspSelectLettersByType_Result.LetterLastPrintDateTime.Value.ToString("yyyyMMdd") : null);
					secspSelectLettersByType_Result.LetterVerifiedRegisterDatePersian = (secspSelectLettersByType_Result.LetterVerifiedRegisterDate.HasValue ? secspSelectLettersByType_Result.LetterVerifiedRegisterDate.Value.ToString("yyyyMMdd") : null);
					_ = secspSelectLettersByType_Result.RegisterDate;
					secspSelectLettersByType_Result.RegisterDatePersian = secspSelectLettersByType_Result.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
					_ = secspSelectLettersByType_Result.FirstRegisterDate;
					secspSelectLettersByType_Result.FirstRegisterDatePersian = secspSelectLettersByType_Result.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
					if (string.IsNullOrEmpty(secspSelectLettersByType_Result.AppType))
					{
						secspSelectLettersByType_Result.AppType = Configuration.AppType;
					}
					secspSelectLettersByType_Result.AppType = Configuration.GetAppType(secspSelectLettersByType_Result.AppType);
					currentLetterViewModel.Letter = secspSelectLettersByType_Result;
					currentLetterViewModel.CurrentId = secspSelectLettersByType_Result.LetterId;
					if (list.Count == 1)
					{
						currentLetterViewModel.NextId = -1;
						currentLetterViewModel.PreviousId = -1;
					}
					else
					{
						SecspSelectLettersByType_Result next = Lists.GetNext(list, secspSelectLettersByType_Result);
						if (next != null)
						{
							currentLetterViewModel.NextId = next.LetterId;
						}
						SecspSelectLettersByType_Result previous = Lists.GetPrevious(list, secspSelectLettersByType_Result);
						if (previous != null)
						{
							currentLetterViewModel.PreviousId = previous.LetterId;
						}
					}
					if (secspSelectLettersByType_Result.LetterVerificationWorkFlowId.HasValue)
					{
						currentLetterViewModel.LastVerificationStep = Enumerable.FirstOrDefault<WSspSelectVerificationWorkFlowStepLast_Result>((IEnumerable<WSspSelectVerificationWorkFlowStepLast_Result>)_db.WSspSelectVerificationWorkFlowStepLast(secspSelectLettersByType_Result.LetterId, 110, secspSelectLettersByType_Result.LetterVerificationWorkFlowId, 0, lCID, result));
					}
				}
				else
				{
					currentLetterViewModel.IsFind = false;
					currentLetterViewModel.Message = Messages.ErrorNotFound;
					currentLetterViewModel.FromDate = fromDate;
					currentLetterViewModel.ToDate = toDate;
					currentLetterViewModel.Letter = null;
					currentLetterViewModel.CurrentId = -1;
					currentLetterViewModel.NextId = -1;
					currentLetterViewModel.PreviousId = -1;
					currentLetterViewModel.CompanyId = -1;
					currentLetterViewModel.FirstId = -1;
					currentLetterViewModel.LastId = -1;
				}
			}
			else
			{
				currentLetterViewModel.IsFind = false;
				currentLetterViewModel.Message = Messages.ErrorNotFound;
				currentLetterViewModel.FromDate = fromDate;
				currentLetterViewModel.ToDate = toDate;
				currentLetterViewModel.Letter = null;
				currentLetterViewModel.CurrentId = -1;
				currentLetterViewModel.NextId = -1;
				currentLetterViewModel.PreviousId = -1;
				currentLetterViewModel.CompanyId = -1;
				currentLetterViewModel.FirstId = -1;
				currentLetterViewModel.LastId = -1;
			}
		}
		catch (DbEntityValidationException ex)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
			currentLetterViewModel.Message = Messages.frmErrorMessage + "<br />" + ((Exception)(object)ex).Message;
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			currentLetterViewModel.Message = Messages.frmErrorMessage + "<br />" + ex2.Message;
		}
		if (fromIndicator.GetValueOrDefault())
		{
			base.ViewBag.FromIndicator = true;
		}
		JsonResult jsonResult = Json(currentLetterViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public ActionResult _PartialList(int currentId, string fromDate, string toDate, int ltType, int companyId, int? userId = null, int? letterId = null)
	{
		LetterListViewModel letterListViewModel = new LetterListViewModel
		{
			userId = userId,
			companyId = companyId,
			ltType = ltType,
			toDate = toDate,
			fromDate = fromDate,
			currentId = currentId,
			letterId = letterId
		};
		base.ViewBag.LetterList = letterListViewModel;
		return PartialView();
	}

	public ActionResult _PartialList_Read([DataSourceRequest] DataSourceRequest request, int currentId, string fromDate, string toDate, int ltType, int companyId, int? userId = null, int? letterId = null)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		ltType = 2;
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
		if (!letterId.HasValue)
		{
			letterId = 0;
		}
		int result2 = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
		}
		List<SecspSelectLettersByType_Result> list = Enumerable.ToList<SecspSelectLettersByType_Result>(Enumerable.Reverse<SecspSelectLettersByType_Result>((IEnumerable<SecspSelectLettersByType_Result>)_db.SecspSelectLettersByType(ltType, fromDate, toDate, letterId, lCID, result, value, now, UserLogin.CurrentUser.UserId, result2)));
		foreach (SecspSelectLettersByType_Result item in list)
		{
			item.AppType = ConverDateTimeToTime(item.LetterDateTime);
			_ = item.LetterDateTime;
			item.LetterDate = item.LetterDateTime.ToString("yyyyMMdd");
			_ = item.FirstRegisterDate;
			item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyyMMdd");
			_ = item.RegisterDate;
			item.RegisterDatePersian = item.RegisterDate.ToString("yyyyMMdd");
			if (!string.IsNullOrWhiteSpace(item.LetterPerson))
			{
				item.LetterCompanyTitle = item.LetterCompanyTitle + " - " + item.LetterPerson;
			}
		}
		JsonResult jsonResult = Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
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

	public ActionResult LetterFiles_Read([DataSourceRequest] DataSourceRequest request, int letterId, int companyId, int projectId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectFilesDirectory_Result> list = Files.SelectFilesDirectory("0", "0", "0", "50", letterId.ToString(), "0", "0", false);
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
	[DynamicAuthorize(ControllerName = "frmReceiveLetters", ActionName = "actDelete")]
	public string Delete(int id)
	{
		_003C_003Ec__DisplayClass10_0 _003C_003Ec__DisplayClass10_ = new _003C_003Ec__DisplayClass10_0();
		_003C_003Ec__DisplayClass10_.id = id;
		string result = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmReceiveLetters", "actDelete", currentUser))
			{
				return Messages.ErrorNotAccess;
			}
			DbSet<SecLetters> secLetters = _dbTbl.SecLetters;
			ParameterExpression val = Expression.Parameter(typeof(SecLetters), "m");
			if (Queryable.FirstOrDefault<SecLetters>((IQueryable<SecLetters>)secLetters, Expression.Lambda<Func<SecLetters, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass10_, typeof(_003C_003Ec__DisplayClass10_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
			{
				try
				{
					_db.CRMspDyDeleteFormFieldMasterValuesBySysPart(_003C_003Ec__DisplayClass10_.id, "rsec");
					mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)Enumerable.ToList<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteSecLetters(_003C_003Ec__DisplayClass10_.id)));
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
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	[AjaxOnly]
	public string ExitFromIsFixLetter(int id)
	{
		string text = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmReceiveLetters", "actExitFromIsVerify", currentUser))
		{
			return Messages.ErrorNotAccess;
		}
		try
		{
			if (id > 0)
			{
				string registerDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
				return (_db.SecspLetterVerifyExit(id, currentUser.UserId, registerDatePersian) > 0) ? "1" : Messages.msgErrorRunFunction;
			}
			return Messages.msgErrorNotActiveItem;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.msgErrorRunFunction;
		}
	}

	[AjaxOnly]
	public string VerifyLetter(int id)
	{
		string text = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmReceiveLetters", "actVerifyLetter", currentUser))
		{
			return Messages.ErrorNotAccess;
		}
		try
		{
			if (id > 0)
			{
				string appType = Configuration.AppType;
				string registerDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
				return (_db.SecspLetterVerify(id, currentUser.UserId, registerDatePersian, appType) > 0) ? "1" : Messages.msgErrorRunFunction;
			}
			return Messages.msgErrorNotActiveItem;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.msgErrorRunFunction;
		}
	}

	public bool IsFixed(int letterId)
	{
		_003C_003Ec__DisplayClass13_0 _003C_003Ec__DisplayClass13_ = new _003C_003Ec__DisplayClass13_0();
		_003C_003Ec__DisplayClass13_.letterId = letterId;
		bool result = false;
		try
		{
			DbSet<SecLetters> secLetters = _dbTbl.SecLetters;
			ParameterExpression val = Expression.Parameter(typeof(SecLetters), "m");
			SecLetters secLetters2 = Queryable.FirstOrDefault<SecLetters>((IQueryable<SecLetters>)secLetters, Expression.Lambda<Func<SecLetters, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass13_, typeof(_003C_003Ec__DisplayClass13_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (secLetters2 != null && secLetters2.LetterIsVerified.HasValue && secLetters2.LetterIsVerified.GetValueOrDefault())
			{
				result = true;
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

	[AjaxOnly]
	public string ActIsFixed(int letterId)
	{
		string result = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmReceiveLetters", "actIsFixed", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			_dbII.SecspLetterIsFixed(letterId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	[AjaxOnly]
	public string ExitIsFixed(int letterId)
	{
		string result = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmReceiveLetters", "actExitIsFixed", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			if (Letter.IsVerified(letterId))
			{
				return string.Format(Messages.msgErrorNotExitIsFixedAfterVerify, Labels.lblRLet);
			}
			_dbII.SecspLetterIsFixedExit(letterId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.msgErrorRunFunction;
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

	[DynamicAuthorize(ControllerName = "frmReceiveLetters", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(int id = 0, string parameters = "")
	{
		_003C_003Ec__DisplayClass17_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass17_0();
		CS_0024_003C_003E8__locals0.id = id;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		string[] array = parameters.Split(new char[1] { '|' });
		base.ViewBag.MyParameters = array;
		string text = "";
		string text2 = "";
		string text3 = "";
		SecLettersLanguageViewModel secLettersLanguageViewModel = new SecLettersLanguageViewModel();
		List<CRMspSelectCompanyTitle_Result> list = Enumerable.ToList<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)_db.CRMspSelectCompanyTitle(CS_0024_003C_003E8__locals0.currLangID, result));
		if (CS_0024_003C_003E8__locals0.id > 0)
		{
			if (!UserLogin.IsUserAccess("frmReceiveLetters", "actEdit"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			DbSet<SecLetters_Lang> secLetters_Lang = _dbTbl.SecLetters_Lang;
			ParameterExpression val = Expression.Parameter(typeof(SecLetters_Lang), "c");
			List<SecLetters_Lang> list2 = Enumerable.ToList<SecLetters_Lang>((IEnumerable<SecLetters_Lang>)Queryable.Where<SecLetters_Lang>((IQueryable<SecLetters_Lang>)secLetters_Lang, Expression.Lambda<Func<SecLetters_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass17_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			DbSet<SecLetters> secLetters = _dbTbl.SecLetters;
			val = Expression.Parameter(typeof(SecLetters), "c");
			SecLetters secLetters2 = Queryable.FirstOrDefault<SecLetters>((IQueryable<SecLetters>)secLetters, Expression.Lambda<Func<SecLetters, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass17_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (secLetters2 == null)
			{
				base.ViewBag.Error = Messages.ErrorNotFound;
				return null;
			}
			if (Letter.IsEditAfterFix(secLetters2.LetterEditAfterFixInfoJs, secLetters2.LetterId, 1))
			{
				secLetters2.LetterIsFixed = false;
			}
			if (secLetters2.LetterIsFixed.HasValue && secLetters2.LetterIsFixed.GetValueOrDefault())
			{
				base.ViewBag.Error = Messages.msgErrorNotActiveLtrSend;
				return null;
			}
			CRMspSelectCompanyById_Result cmp2 = CRMIdeal.Classes.Helper.Company.GetCompanyById(secLetters2.LetterCompanyId.GetValueOrDefault());
			if (cmp2 != null)
			{
				text = ((Enumerable.FirstOrDefault<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)list, (Func<CRMspSelectCompanyTitle_Result, bool>)((CRMspSelectCompanyTitle_Result c) => c.CompanyTitleID == cmp2.cmpTitleId)) != null) ? (Enumerable.FirstOrDefault<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)list, (Func<CRMspSelectCompanyTitle_Result, bool>)((CRMspSelectCompanyTitle_Result c) => c.CompanyTitleID == cmp2.cmpTitleId)).CompanyTitle + " ") : "") + cmp2.cmpName;
				text2 = cmp2.cmpAddress;
				text3 = cmp2.cmpTel;
			}
			List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<SecLetters_Lang, CommonMultiLanguageViewModel>((IEnumerable<SecLetters_Lang>)list2, (Func<SecLetters_Lang, CommonMultiLanguageViewModel>)((SecLetters_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.LetterAnnex,
				LanguageId = item.LanguageID
			})));
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = secLetters2.LetterAnnex,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<SecLetters_Lang, CommonMultiLanguageViewModel>((IEnumerable<SecLetters_Lang>)list2, (Func<SecLetters_Lang, CommonMultiLanguageViewModel>)((SecLetters_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.LettercmpNickName,
				LanguageId = item.LanguageID
			})));
			list4.Add(new CommonMultiLanguageViewModel
			{
				Value = secLetters2.LettercmpNickName,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list5 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<SecLetters_Lang, CommonMultiLanguageViewModel>((IEnumerable<SecLetters_Lang>)list2, (Func<SecLetters_Lang, CommonMultiLanguageViewModel>)((SecLetters_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.LettercmpPersonNickName,
				LanguageId = item.LanguageID
			})));
			list5.Add(new CommonMultiLanguageViewModel
			{
				Value = secLetters2.LettercmpPersonNickName,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list6 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<SecLetters_Lang, CommonMultiLanguageViewModel>((IEnumerable<SecLetters_Lang>)list2, (Func<SecLetters_Lang, CommonMultiLanguageViewModel>)((SecLetters_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.LetterSubject,
				LanguageId = item.LanguageID
			})));
			list6.Add(new CommonMultiLanguageViewModel
			{
				Value = secLetters2.LetterSubject,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list7 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<SecLetters_Lang, CommonMultiLanguageViewModel>((IEnumerable<SecLetters_Lang>)list2, (Func<SecLetters_Lang, CommonMultiLanguageViewModel>)((SecLetters_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.LetterHeader,
				LanguageId = item.LanguageID
			})));
			list7.Add(new CommonMultiLanguageViewModel
			{
				Value = secLetters2.LetterHeader,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list8 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<SecLetters_Lang, CommonMultiLanguageViewModel>((IEnumerable<SecLetters_Lang>)list2, (Func<SecLetters_Lang, CommonMultiLanguageViewModel>)((SecLetters_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.LetterContext,
				LanguageId = item.LanguageID
			})));
			list8.Add(new CommonMultiLanguageViewModel
			{
				Value = secLetters2.LetterContext,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list9 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<SecLetters_Lang, CommonMultiLanguageViewModel>((IEnumerable<SecLetters_Lang>)list2, (Func<SecLetters_Lang, CommonMultiLanguageViewModel>)((SecLetters_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.LetterFooter,
				LanguageId = item.LanguageID
			})));
			list9.Add(new CommonMultiLanguageViewModel
			{
				Value = secLetters2.LetterFooter,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list10 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<SecLetters_Lang, CommonMultiLanguageViewModel>((IEnumerable<SecLetters_Lang>)list2, (Func<SecLetters_Lang, CommonMultiLanguageViewModel>)((SecLetters_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.LetterSigningI,
				LanguageId = item.LanguageID
			})));
			list10.Add(new CommonMultiLanguageViewModel
			{
				Value = secLetters2.LetterSigningI,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list11 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<SecLetters_Lang, CommonMultiLanguageViewModel>((IEnumerable<SecLetters_Lang>)list2, (Func<SecLetters_Lang, CommonMultiLanguageViewModel>)((SecLetters_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.LetterSigningII,
				LanguageId = item.LanguageID
			})));
			list11.Add(new CommonMultiLanguageViewModel
			{
				Value = secLetters2.LetterSigningII,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list12 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<SecLetters_Lang, CommonMultiLanguageViewModel>((IEnumerable<SecLetters_Lang>)list2, (Func<SecLetters_Lang, CommonMultiLanguageViewModel>)((SecLetters_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.LetterSigningIII,
				LanguageId = item.LanguageID
			})));
			list12.Add(new CommonMultiLanguageViewModel
			{
				Value = secLetters2.LetterSigningIII,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list13 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<SecLetters_Lang, CommonMultiLanguageViewModel>((IEnumerable<SecLetters_Lang>)list2, (Func<SecLetters_Lang, CommonMultiLanguageViewModel>)((SecLetters_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.LetterSigningIV,
				LanguageId = item.LanguageID
			})));
			list13.Add(new CommonMultiLanguageViewModel
			{
				Value = secLetters2.LetterSigningIV,
				LanguageId = result
			});
			SecLettersLanguageViewModel obj = new SecLettersLanguageViewModel
			{
				LetterId = secLetters2.LetterId,
				LetterTypeId = secLetters2.LetterTypeId
			};
			_ = secLetters2.LetterDateTime;
			obj.LetterDate = secLetters2.LetterDateTime.ToString("yyyy/MM/dd");
			obj.LetterDateTime = secLetters2.LetterDateTime;
			obj.LetterPreNumber = secLetters2.LetterPreNumber;
			obj.LetterNumber = secLetters2.LetterNumber;
			obj.LetterPreNumberII = secLetters2.LetterPreNumberII;
			obj.LetterNumberII = secLetters2.LetterNumberII;
			obj.LetterCompanyId = secLetters2.LetterCompanyId;
			obj.LettercmpPersonId = secLetters2.LettercmpPersonId;
			obj.LettercmpProjectId = secLetters2.LettercmpProjectId;
			obj.LetterPrintFormatId = secLetters2.LetterPrintFormatId;
			obj.LetterLastPrintDate = secLetters2.LetterLastPrintDate;
			obj.LetterLastPrintTime = secLetters2.LetterLastPrintTime;
			obj.LetterLastPrintDateTime = secLetters2.LetterLastPrintDateTime;
			obj.LetterIsVerified = secLetters2.LetterIsVerified;
			obj.LetterVerifierId = secLetters2.LetterVerifierId;
			obj.LetterVerifierRequestId = secLetters2.LetterVerifierRequestId;
			obj.LetterVerifiedRegisterDate = secLetters2.LetterVerifiedRegisterDate;
			obj.LetterVerifiedRegisterDatePersian = secLetters2.LetterVerifiedRegisterDatePersian;
			obj.FirstRegisterDate = secLetters2.FirstRegisterDate;
			obj.FirstRegisterDatePersian = secLetters2.FirstRegisterDatePersian;
			obj.FirstRegisterUserId = secLetters2.FirstRegisterUserId;
			obj.UserId = secLetters2.UserId;
			obj.Year1 = secLetters2.Year1;
			obj.Month1 = secLetters2.Month1;
			obj.RegisterDate = secLetters2.RegisterDate;
			obj.RegisterDatePersian = secLetters2.RegisterDatePersian;
			obj.GUId = secLetters2.GUId;
			obj.AppType = secLetters2.AppType;
			obj.LanguageID = secLetters2.LanguageID;
			obj.LetterAnnex = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
			obj.LetterAnnex_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
			obj.LettercmpNickName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
			obj.LettercmpNickName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
			obj.LettercmpPersonNickName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
			obj.LettercmpPersonNickName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
			obj.LetterSubject = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
			obj.LetterSubject_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
			obj.LetterHeader = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
			obj.LetterHeader_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
			obj.LetterContext = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
			obj.LetterContext_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
			obj.LetterFooter = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
			obj.LetterFooter_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
			obj.LetterSigningI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
			obj.LetterSigningI_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
			obj.LetterSigningII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
			obj.LetterSigningII_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
			obj.LetterSigningIII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
			obj.LetterSigningIII_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
			obj.LetterSigningIV = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
			obj.LetterSigningIV_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
			obj.LetterNumberCounterId = secLetters2.LetterNumberCounterId;
			obj.LetterVerificationWorkFlowId = secLetters2.LetterVerificationWorkFlowId;
			obj.LetterIsFixed = secLetters2.LetterIsFixed;
			obj.LetterDefaultSettingId = secLetters2.LetterDefaultSettingId;
			secLettersLanguageViewModel = obj;
		}
		else
		{
			if (!UserLogin.IsUserAccess("frmReceiveLetters", "actInsert"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			DateTime now = DateTime.Now;
			secLettersLanguageViewModel = new SecLettersLanguageViewModel
			{
				RegisterDate = now,
				RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
				FirstRegisterDate = now,
				FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
				UserId = UserLogin.CurrentUser.UserId,
				FirstRegisterUserId = UserLogin.CurrentUser.UserId,
				LetterDateTime = now,
				LetterDate = now.ToString("yyyyMMdd", new PersianCulture()),
				LetterTypeId = 2
			};
			if (array.Length >= 1 && array[0] != "")
			{
				int.TryParse(array[0], out var result2);
				CRMspSelectCompanyById_Result cmp = CRMIdeal.Classes.Helper.Company.GetCompanyById(result2);
				if (cmp != null)
				{
					text = ((Enumerable.FirstOrDefault<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)list, (Func<CRMspSelectCompanyTitle_Result, bool>)((CRMspSelectCompanyTitle_Result c) => c.CompanyTitleID == cmp.cmpTitleId)) != null) ? (Enumerable.FirstOrDefault<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)list, (Func<CRMspSelectCompanyTitle_Result, bool>)((CRMspSelectCompanyTitle_Result c) => c.CompanyTitleID == cmp.cmpTitleId)).CompanyTitle + " ") : "") + cmp.cmpName;
					text2 = cmp.cmpAddress;
					text3 = cmp.cmpTel;
				}
			}
			base.ViewBag.IsBuying = VersionBuyer.Letters;
		}
		GetdVerifierTitles();
		GetLetterNumberCounter();
		GetVerificationWorkFlow();
		base.ViewBag.CmpFullName = text;
		base.ViewBag.CmpAddrs = text2;
		base.ViewBag.CmpTele = text3;
		return View(secLettersLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmReceiveLetterDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult InsertEdit(SecLettersLanguageViewModel vm)
	{
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0326: Unknown result type (might be due to invalid IL or missing references)
		//IL_037a: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ce: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass18_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass18_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int? num = null;
		if (UserLogin.CurrentUser != null)
		{
			num = UserLogin.CurrentUser.UserLastCId;
		}
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.LetterAnnex_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.LetterAnnex_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.LetterAnnex,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.LettercmpNickName_Lang))
		{
			list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.LettercmpNickName_Lang);
		}
		list2.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.LettercmpNickName,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.LettercmpPersonNickName_Lang))
		{
			list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.LettercmpPersonNickName_Lang);
		}
		list3.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.LettercmpPersonNickName,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.LetterSubject_Lang))
		{
			list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.LetterSubject_Lang);
		}
		list4.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.LetterSubject,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.LetterHeader_Lang))
		{
			list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.LetterHeader_Lang);
		}
		list5.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.LetterHeader,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.LetterContext_Lang))
		{
			list6 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.LetterContext_Lang);
		}
		list6.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.LetterContext,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list7 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.LetterFooter_Lang))
		{
			list7 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.LetterFooter_Lang);
		}
		list7.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.LetterFooter,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list8 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.LetterSigningI_Lang))
		{
			list8 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.LetterSigningI_Lang);
		}
		list8.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.LetterSigningI,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list9 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.LetterSigningII_Lang))
		{
			list9 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.LetterSigningII_Lang);
		}
		list9.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.LetterSigningII,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list10 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.LetterSigningIII_Lang))
		{
			list10 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.LetterSigningIII_Lang);
		}
		list10.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.LetterSigningIII,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list11 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.LetterSigningIV_Lang))
		{
			list11 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.LetterSigningIV_Lang);
		}
		list11.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.LetterSigningIV,
			LanguageId = lCID
		});
		base.ViewBag.MyParameters = "".Split(new char[1] { '|' });
		string text = "";
		string text2 = "";
		string text3 = "";
		CS_0024_003C_003E8__locals0.cmp = CRMIdeal.Classes.Helper.Company.GetCompanyById(CS_0024_003C_003E8__locals0.vm.LetterCompanyId.GetValueOrDefault());
		List<CRMspSelectCompanyTitle_Result> list12 = Enumerable.ToList<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)_db.CRMspSelectCompanyTitle(lCID, CS_0024_003C_003E8__locals0.defLangID));
		if (CS_0024_003C_003E8__locals0.cmp != null)
		{
			text = ((Enumerable.FirstOrDefault<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)list12, (Func<CRMspSelectCompanyTitle_Result, bool>)((CRMspSelectCompanyTitle_Result c) => c.CompanyTitleID == CS_0024_003C_003E8__locals0.cmp.cmpTitleId)) != null) ? (Enumerable.FirstOrDefault<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)list12, (Func<CRMspSelectCompanyTitle_Result, bool>)((CRMspSelectCompanyTitle_Result c) => c.CompanyTitleID == CS_0024_003C_003E8__locals0.cmp.cmpTitleId)).CompanyTitle + " ") : "") + CS_0024_003C_003E8__locals0.cmp.cmpName;
			text2 = CS_0024_003C_003E8__locals0.cmp.cmpAddress;
			text3 = CS_0024_003C_003E8__locals0.cmp.cmpTel;
		}
		base.ViewBag.CmpFullName = text;
		base.ViewBag.CmpAddrs = text2;
		base.ViewBag.CmpTele = text3;
		GetdVerifierTitles();
		GetLetterNumberCounter();
		GetVerificationWorkFlow();
		long num2 = 0L;
		int sysPartId = 51;
		try
		{
			try
			{
				DateTime dateTime = default(DateTime);
				string text4 = "";
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.LetterDate))
				{
					text4 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.vm.LetterDate.Replace("/", ""));
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
						CS_0024_003C_003E8__locals0.vm.LetterDate = dateTime.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime = DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
						CS_0024_003C_003E8__locals0.vm.LetterDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime = DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
						CS_0024_003C_003E8__locals0.vm.LetterDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
					CS_0024_003C_003E8__locals0.vm.LetterDateTime = dateTime;
				}
			}
			catch (Exception e)
			{
				if (CS_0024_003C_003E8__locals0.vm.LetterDate != null)
				{
					SecLettersLanguageViewModel vm2 = CS_0024_003C_003E8__locals0.vm;
					_ = CS_0024_003C_003E8__locals0.vm.LetterDateTime;
					vm2.LetterDate = ((lCID != 1065) ? CS_0024_003C_003E8__locals0.vm.LetterDateTime.ToString("yyyyMMdd") : CS_0024_003C_003E8__locals0.vm.LetterDate.Replace("/", "").Replace("-", "").Replace("_", "")
						.Replace(".", "")
						.Replace(",", "")
						.Replace("\\", ""));
					CS_0024_003C_003E8__locals0.vm.LetterDate = DateTimeClass.ConvertDateWOSlashToSlash(CS_0024_003C_003E8__locals0.vm.LetterDate);
				}
				ErrorSignal.FromCurrentContext().Raise(e);
				base.ViewBag.Error = Messages.WrongLetterDateTime;
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			if (CS_0024_003C_003E8__locals0.vm.LetterDate != null)
			{
				CS_0024_003C_003E8__locals0.vm.LetterDate = CS_0024_003C_003E8__locals0.vm.LetterDate.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
			}
			if (!CS_0024_003C_003E8__locals0.vm.LetterNumberII.HasValue || CS_0024_003C_003E8__locals0.vm.LetterNumberII == 0)
			{
				if (CS_0024_003C_003E8__locals0.vm.LetterDate != null)
				{
					SecLettersLanguageViewModel vm3 = CS_0024_003C_003E8__locals0.vm;
					_ = CS_0024_003C_003E8__locals0.vm.LetterDateTime;
					vm3.LetterDate = ((lCID != 1065) ? CS_0024_003C_003E8__locals0.vm.LetterDateTime.ToString("yyyyMMdd") : CS_0024_003C_003E8__locals0.vm.LetterDate.Replace("/", "").Replace("-", "").Replace("_", "")
						.Replace(".", "")
						.Replace(",", "")
						.Replace("\\", ""));
					CS_0024_003C_003E8__locals0.vm.LetterDate = DateTimeClass.ConvertDateWOSlashToSlash(CS_0024_003C_003E8__locals0.vm.LetterDate);
				}
				base.ViewBag.Error = string.Format(Messages.ErrorEmpty, Labels.ReceiveLetterNumberII);
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			if (!base.ModelState.IsValid)
			{
				base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
			else
			{
				_003C_003Ec__DisplayClass18_1 _003C_003Ec__DisplayClass18_ = new _003C_003Ec__DisplayClass18_1();
				_003C_003Ec__DisplayClass18_.model = new SecLetters();
				if (CS_0024_003C_003E8__locals0.vm.LetterId > 0)
				{
					DbSet<SecLetters> secLetters = _dbTbl.SecLetters;
					ParameterExpression val = Expression.Parameter(typeof(SecLetters), "c");
					_003C_003Ec__DisplayClass18_.model = Queryable.FirstOrDefault<SecLetters>((IQueryable<SecLetters>)secLetters, Expression.Lambda<Func<SecLetters, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass18_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				_003C_003Ec__DisplayClass18_.model.UserId = UserLogin.CurrentUser.UserId;
				DateTime now = DateTime.Now;
				_003C_003Ec__DisplayClass18_.model.RegisterDate = now;
				_003C_003Ec__DisplayClass18_.model.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				_003C_003Ec__DisplayClass18_.model.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
				_003C_003Ec__DisplayClass18_.model.AppType = Configuration.AppType;
				short.TryParse(Financial.Get().Id.ToString(), out var result);
				_003C_003Ec__DisplayClass18_.model.Year1 = result;
				_003C_003Ec__DisplayClass18_.model.LetterTypeId = CS_0024_003C_003E8__locals0.vm.LetterTypeId;
				_003C_003Ec__DisplayClass18_.model.LetterDate = CS_0024_003C_003E8__locals0.vm.LetterDate;
				_003C_003Ec__DisplayClass18_.model.LetterDateTime = CS_0024_003C_003E8__locals0.vm.LetterDateTime;
				_003C_003Ec__DisplayClass18_.model.LetterPreNumber = CS_0024_003C_003E8__locals0.vm.LetterPreNumber;
				_003C_003Ec__DisplayClass18_.model.LetterNumber = CS_0024_003C_003E8__locals0.vm.LetterNumber;
				_003C_003Ec__DisplayClass18_.model.LetterPreNumberII = CS_0024_003C_003E8__locals0.vm.LetterPreNumberII;
				_003C_003Ec__DisplayClass18_.model.LetterNumberII = CS_0024_003C_003E8__locals0.vm.LetterNumberII;
				_003C_003Ec__DisplayClass18_.model.LetterCompanyId = CS_0024_003C_003E8__locals0.vm.LetterCompanyId;
				_003C_003Ec__DisplayClass18_.model.LettercmpPersonId = CS_0024_003C_003E8__locals0.vm.LettercmpPersonId;
				_003C_003Ec__DisplayClass18_.model.LettercmpProjectId = CS_0024_003C_003E8__locals0.vm.LettercmpProjectId;
				_003C_003Ec__DisplayClass18_.model.LetterPrintFormatId = CS_0024_003C_003E8__locals0.vm.LetterPrintFormatId;
				_003C_003Ec__DisplayClass18_.model.LetterLastPrintDate = CS_0024_003C_003E8__locals0.vm.LetterLastPrintDate;
				_003C_003Ec__DisplayClass18_.model.LetterLastPrintTime = CS_0024_003C_003E8__locals0.vm.LetterLastPrintTime;
				_003C_003Ec__DisplayClass18_.model.LetterLastPrintDateTime = CS_0024_003C_003E8__locals0.vm.LetterLastPrintDateTime;
				_003C_003Ec__DisplayClass18_.model.LetterIsVerified = CS_0024_003C_003E8__locals0.vm.LetterIsVerified;
				_003C_003Ec__DisplayClass18_.model.LetterVerifierId = CS_0024_003C_003E8__locals0.vm.LetterVerifierId;
				_003C_003Ec__DisplayClass18_.model.LetterVerifierRequestId = CS_0024_003C_003E8__locals0.vm.LetterVerifierRequestId;
				_003C_003Ec__DisplayClass18_.model.LetterVerifiedRegisterDate = CS_0024_003C_003E8__locals0.vm.LetterVerifiedRegisterDate;
				_003C_003Ec__DisplayClass18_.model.LetterVerifiedRegisterDatePersian = CS_0024_003C_003E8__locals0.vm.LetterVerifiedRegisterDatePersian;
				_003C_003Ec__DisplayClass18_.model.LetterAnnex = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass18_.model.LettercmpNickName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass18_.model.LettercmpPersonNickName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass18_.model.LetterSubject = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass18_.model.LetterHeader = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass18_.model.LetterContext = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass18_.model.LetterFooter = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass18_.model.LetterSigningI = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass18_.model.LetterSigningII = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass18_.model.LetterSigningIII = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass18_.model.LetterSigningIV = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				if (!VersionBuyer.LetterNumberCounter)
				{
					CS_0024_003C_003E8__locals0.vm.LetterNumberCounterId = _003C_003Ec__DisplayClass18_.model.LetterNumberCounterId;
				}
				if (UserLogin.IsUserAccess("frmReceiveLetterDataEntry", "actCanChangeLetterNumberCounter", UserLogin.CurrentUser))
				{
					_003C_003Ec__DisplayClass18_.model.LetterNumberCounterId = CS_0024_003C_003E8__locals0.vm.LetterNumberCounterId;
				}
				else if (_003C_003Ec__DisplayClass18_.model.LetterId == 0)
				{
					_003C_003Ec__DisplayClass18_.model.LetterNumberCounterId = CS_0024_003C_003E8__locals0.vm.LetterNumberCounterId;
				}
				_003C_003Ec__DisplayClass18_.model.LetterDefaultSettingId = CS_0024_003C_003E8__locals0.vm.LetterDefaultSettingId;
				_003C_003Ec__DisplayClass18_.model.LetterIsFixed = CS_0024_003C_003E8__locals0.vm.LetterIsFixed;
				_003C_003Ec__DisplayClass18_.model.LetterVerificationWorkFlowId = CS_0024_003C_003E8__locals0.vm.LetterVerificationWorkFlowId;
				if (_003C_003Ec__DisplayClass18_.model.LetterId > 0)
				{
					long.TryParse(_003C_003Ec__DisplayClass18_.model.LetterNumberII.ToString(), out var result2);
					if (CheckDuplicateNumber(1, result2, _003C_003Ec__DisplayClass18_.model.LetterId, _003C_003Ec__DisplayClass18_.model.LetterNumberCounterId.GetValueOrDefault(), _003C_003Ec__DisplayClass18_.model.LetterCId) > 0)
					{
						if (CS_0024_003C_003E8__locals0.vm.LetterDate != null)
						{
							SecLettersLanguageViewModel vm4 = CS_0024_003C_003E8__locals0.vm;
							_ = CS_0024_003C_003E8__locals0.vm.LetterDateTime;
							vm4.LetterDate = ((lCID != 1065) ? CS_0024_003C_003E8__locals0.vm.LetterDateTime.ToString("yyyyMMdd") : CS_0024_003C_003E8__locals0.vm.LetterDate.Replace("/", "").Replace("-", "").Replace("_", "")
								.Replace(".", "")
								.Replace(",", "")
								.Replace("\\", ""));
							CS_0024_003C_003E8__locals0.vm.LetterDate = DateTimeClass.ConvertDateWOSlashToSlash(CS_0024_003C_003E8__locals0.vm.LetterDate);
						}
						base.ViewBag.Error = Messages.LetterNumberIsRepeated;
						return View(CS_0024_003C_003E8__locals0.vm);
					}
					_dbTbl.Entry(_003C_003Ec__DisplayClass18_.model).State = EntityState.Modified;
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass18_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass18_2();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass18_;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							DbSet<SecLetters_Lang> secLetters_Lang = _dbTbl.SecLetters_Lang;
							ParameterExpression val = Expression.Parameter(typeof(SecLetters_Lang), "c");
							SecLetters_Lang secLetters_Lang2 = Queryable.FirstOrDefault<SecLetters_Lang>((IQueryable<SecLetters_Lang>)secLetters_Lang, Expression.Lambda<Func<SecLetters_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass18_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass18_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (secLetters_Lang2 != null)
							{
								secLetters_Lang2.LetterAnnex = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								secLetters_Lang2.LettercmpNickName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								secLetters_Lang2.LettercmpPersonNickName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								secLetters_Lang2.LetterSubject = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								secLetters_Lang2.LetterHeader = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								secLetters_Lang2.LetterContext = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								secLetters_Lang2.LetterFooter = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								secLetters_Lang2.LetterSigningI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								secLetters_Lang2.LetterSigningII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								secLetters_Lang2.LetterSigningIII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								secLetters_Lang2.LetterSigningIV = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(secLetters_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							secLetters_Lang2 = new SecLetters_Lang();
							secLetters_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
							secLetters_Lang2.LetterId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.LetterId;
							secLetters_Lang2.LetterAnnex = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							secLetters_Lang2.LettercmpNickName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							secLetters_Lang2.LettercmpPersonNickName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							secLetters_Lang2.LetterSubject = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							secLetters_Lang2.LetterHeader = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							secLetters_Lang2.LetterContext = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							secLetters_Lang2.LetterFooter = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							secLetters_Lang2.LetterSigningI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							secLetters_Lang2.LetterSigningII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							secLetters_Lang2.LetterSigningIII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							secLetters_Lang2.LetterSigningIV = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							_dbTbl.SecLetters_Lang.Add(secLetters_Lang2);
							_dbTbl.SaveChanges();
						}
					}
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
				else
				{
					if (!VersionBuyer.Letters)
					{
						DbSet<SecLetters> secLetters2 = _dbTbl.SecLetters;
						ParameterExpression val = Expression.Parameter(typeof(SecLetters), "c");
						if (Queryable.Any<SecLetters>((IQueryable<SecLetters>)secLetters2, Expression.Lambda<Func<SecLetters, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)10, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val })))
						{
							base.ViewBag.Error = "BV|" + Messages.VersionBuy;
							return View(_003C_003Ec__DisplayClass18_.model);
						}
					}
					long num3 = 0L;
					bool flag = false;
					int num4 = 0;
					while (!flag)
					{
						num3 = Enumerable.FirstOrDefault<long>(_db.Database.SqlQuery<long>($"Select dbo.SecfnReturnLetterNumberII({Financial.Get().Id}, {2}, {_003C_003Ec__DisplayClass18_.model.LetterNumberCounterId.GetValueOrDefault()},{num.GetValueOrDefault()})", Array.Empty<object>()));
						_003C_003Ec__DisplayClass18_.model.LetterNumberII = num3;
						num2 = _003C_003Ec__DisplayClass18_.model.LetterNumberII.GetValueOrDefault();
						flag = ReservedNumber.AddNumber(sysPartId, num2);
						num4++;
						if (num4 > 10)
						{
							break;
						}
					}
					if (CheckDuplicateNumber(1, num3, _003C_003Ec__DisplayClass18_.model.LetterId, _003C_003Ec__DisplayClass18_.model.LetterNumberCounterId.GetValueOrDefault(), num) > 0)
					{
						if (CS_0024_003C_003E8__locals0.vm.LetterDate != null)
						{
							SecLettersLanguageViewModel vm5 = CS_0024_003C_003E8__locals0.vm;
							_ = CS_0024_003C_003E8__locals0.vm.LetterDateTime;
							vm5.LetterDate = ((lCID != 1065) ? CS_0024_003C_003E8__locals0.vm.LetterDateTime.ToString("yyyyMMdd") : CS_0024_003C_003E8__locals0.vm.LetterDate.Replace("/", "").Replace("-", "").Replace("_", "")
								.Replace(".", "")
								.Replace(",", "")
								.Replace("\\", ""));
							CS_0024_003C_003E8__locals0.vm.LetterDate = DateTimeClass.ConvertDateWOSlashToSlash(CS_0024_003C_003E8__locals0.vm.LetterDate);
						}
						base.ViewBag.Error = Messages.LetterNumberIsRepeated;
						ReservedNumber.UpdateNumber(sysPartId, num2);
						return View(CS_0024_003C_003E8__locals0.vm);
					}
					_003C_003Ec__DisplayClass18_.model.LetterCId = num;
					_003C_003Ec__DisplayClass18_.model.GUId = System.Guid.NewGuid();
					_003C_003Ec__DisplayClass18_.model.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
					_003C_003Ec__DisplayClass18_.model.FirstRegisterDate = now;
					_003C_003Ec__DisplayClass18_.model.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					_003C_003Ec__DisplayClass18_.model.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
					_dbTbl.SecLetters.Add(_003C_003Ec__DisplayClass18_.model);
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					num2 = (ReservedNumber.RemoveNumber(sysPartId, num2) ? 0 : num2);
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
					{
						SecLetters_Lang secLetters_Lang3 = new SecLetters_Lang();
						secLetters_Lang3.LanguageID = lang.LanguageID;
						secLetters_Lang3.LetterId = _003C_003Ec__DisplayClass18_.model.LetterId;
						secLetters_Lang3.LetterAnnex = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						secLetters_Lang3.LettercmpNickName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						secLetters_Lang3.LettercmpPersonNickName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						secLetters_Lang3.LetterSubject = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						secLetters_Lang3.LetterHeader = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						secLetters_Lang3.LetterContext = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						secLetters_Lang3.LetterFooter = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						secLetters_Lang3.LetterSigningI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						secLetters_Lang3.LetterSigningII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						secLetters_Lang3.LetterSigningIII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						secLetters_Lang3.LetterSigningIV = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						_dbTbl.SecLetters_Lang.Add(secLetters_Lang3);
						_dbTbl.SaveChanges();
					}
					CS_0024_003C_003E8__locals0.vm.LetterId = _003C_003Ec__DisplayClass18_.model.LetterId;
					base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
				}
			}
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
		if (CS_0024_003C_003E8__locals0.vm.LetterDate != null)
		{
			SecLettersLanguageViewModel vm6 = CS_0024_003C_003E8__locals0.vm;
			_ = CS_0024_003C_003E8__locals0.vm.LetterDateTime;
			vm6.LetterDate = ((lCID != 1065) ? CS_0024_003C_003E8__locals0.vm.LetterDateTime.ToString("yyyyMMdd") : CS_0024_003C_003E8__locals0.vm.LetterDate.Replace("/", "").Replace("-", "").Replace("_", "")
				.Replace(".", "")
				.Replace(",", "")
				.Replace("\\", ""));
			CS_0024_003C_003E8__locals0.vm.LetterDate = DateTimeClass.ConvertDateWOSlashToSlash(CS_0024_003C_003E8__locals0.vm.LetterDate);
		}
		if (num2 != 0L)
		{
			ReservedNumber.RemoveNumber(sysPartId, num2);
		}
		return View(CS_0024_003C_003E8__locals0.vm);
	}

	[AjaxOnly]
	public string CheckAccessLetter()
	{
		string result = "";
		try
		{
			if (VersionBuyer.Letters)
			{
				result = "";
			}
			else
			{
				DbSet<SecLetters> secLetters = _dbTbl.SecLetters;
				ParameterExpression val = Expression.Parameter(typeof(SecLetters), "c");
				if (Queryable.Any<SecLetters>((IQueryable<SecLetters>)secLetters, Expression.Lambda<Func<SecLetters, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)15, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val })))
				{
					result = Messages.VersionBuyLetter;
				}
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
	public string GetLettereNumber(int typeId, int letterNumberCounterId = 0, int? cId = null)
	{
		string result = "";
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
			result = Enumerable.FirstOrDefault<long>(_db.Database.SqlQuery<long>($"Select dbo.SecfnReturnLetterNumberII({Financial.Get().Id}, {typeId}, {letterNumberCounterId},{cId})", Array.Empty<object>())).ToString();
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
	public string GetLettereNumberAndPreNumber(int typeId, int letterNumberCounterId = 0, int? cId = null)
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
			int? num = null;
			if (UserLogin.CurrentUser != null)
			{
				num = UserLogin.CurrentUser.UserLastCId;
			}
			if (cId.GetValueOrDefault() == 0)
			{
				cId = num;
			}
			long num2 = Enumerable.FirstOrDefault<long>(_db.Database.SqlQuery<long>($"Select dbo.SecfnReturnLetterNumberII({Financial.Get().Id}, {typeId}, {letterNumberCounterId},{cId.GetValueOrDefault()})", Array.Empty<object>()));
			string text = "";
			SecspSelectLetterNumberCounterById_Result secspSelectLetterNumberCounterById_Result = Enumerable.FirstOrDefault<SecspSelectLetterNumberCounterById_Result>((IEnumerable<SecspSelectLetterNumberCounterById_Result>)_dbI.SecspSelectLetterNumberCounterById(letterNumberCounterId, lCID, result));
			if (secspSelectLetterNumberCounterById_Result != null)
			{
				text = secspSelectLetterNumberCounterById_Result.LtrNumCntPreNumber ?? "";
			}
			result2 = num2 + "|" + text;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result2;
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
			List<CRMspSelectUserForLinkedType_Result> list2 = Enumerable.ToList<CRMspSelectUserForLinkedType_Result>((IEnumerable<CRMspSelectUserForLinkedType_Result>)_db.CRMspSelectUserForLinkedType(UserLogin.CurrentUser.UserId, 28, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectUserForLinkedType_Result, SelectListItem>((IEnumerable<CRMspSelectUserForLinkedType_Result>)list2, (Func<CRMspSelectUserForLinkedType_Result, SelectListItem>)((CRMspSelectUserForLinkedType_Result item) => new SelectListItem
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
	public JsonResult GetCompanyPerson(int cmpId)
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
				PersonName = item.PersonTitleName
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCompanyProject(string cmpIdReferUserId)
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
				prjTitle = item.prjTitle
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetLetterNumberCounter()
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
			List<SecspSelectLetterNumberCounterByTypeId_Result> list2 = Enumerable.ToList<SecspSelectLetterNumberCounterByTypeId_Result>((IEnumerable<SecspSelectLetterNumberCounterByTypeId_Result>)_dbI.SecspSelectLetterNumberCounterByTypeId(2, lCID, result));
			list.AddRange(Enumerable.Select<SecspSelectLetterNumberCounterByTypeId_Result, SelectListItem>((IEnumerable<SecspSelectLetterNumberCounterByTypeId_Result>)list2, (Func<SecspSelectLetterNumberCounterByTypeId_Result, SelectListItem>)((SecspSelectLetterNumberCounterByTypeId_Result item) => new SelectListItem
			{
				Text = item.LtrNumCntTitle,
				Value = item.LetterNumberCounterId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.LetterNumberCounterList = list;
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
			List<WSspSelectVerificationWorkFlowWithObjectType_Result> list2 = Enumerable.ToList<WSspSelectVerificationWorkFlowWithObjectType_Result>((IEnumerable<WSspSelectVerificationWorkFlowWithObjectType_Result>)_db.WSspSelectVerificationWorkFlowWithObjectType(110, lCID, result));
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
	public long CheckDuplicateNumber(int letterTypeId, long letterNumberII, int? currLetterId, int letterNumberCounterId, int? cId = null)
	{
		if (!currLetterId.HasValue)
		{
			currLetterId = 0;
		}
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
			return Enumerable.FirstOrDefault<long>(_db.Database.SqlQuery<long>($"Select * from  dbo.SecfnCheckDuplicateLetterNumberII({letterNumberII}, {currLetterId}, {letterTypeId}, {letterNumberCounterId},{cId.GetValueOrDefault()})", Array.Empty<object>()));
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			return -1L;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			return -1L;
		}
	}
}

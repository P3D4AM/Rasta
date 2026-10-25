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

namespace CRMIdeal.Areas.WareHouse.Controllers;

public class WareHouseMovementController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass17_0
	{
		public int docId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass18_0
	{
		public int docItemId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass19_0
	{
		public int docItemSerialId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass26_0
	{
		public int id;

		public int currLangID;

		internal bool _003CInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
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
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass27_0
	{
		public CRMspSelectCompanyById_Result cmp;

		public WareHouseMovementLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__18;

		public Func<Languages, bool> _003C_003E9__44;

		internal bool _003CInsertEdit_003Eb__0(CRMspSelectCompanyTitle_Result c)
		{
			return c.CompanyTitleID == cmp.cmpTitleId;
		}

		internal bool _003CInsertEdit_003Eb__1(CRMspSelectCompanyTitle_Result c)
		{
			return c.CompanyTitleID == cmp.cmpTitleId;
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

		internal bool _003CInsertEdit_003Eb__18(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__44(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass27_1
	{
		public WSDoc model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass27_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass27_1 CS_0024_003C_003E8__locals1;

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
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass32_0
	{
		public int docId;

		public int currLangID;

		internal bool _003CRegisterSendInfo_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CRegisterSendInfo_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CRegisterSendInfo_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CRegisterSendInfo_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CRegisterSendInfo_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CRegisterSendInfo_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CRegisterSendInfo_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CRegisterSendInfo_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CRegisterSendInfo_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CRegisterSendInfo_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CRegisterSendInfo_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CRegisterSendInfo_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CRegisterSendInfo_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CRegisterSendInfo_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CRegisterSendInfo_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CRegisterSendInfo_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CRegisterSendInfo_003Eb__24(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CRegisterSendInfo_003Eb__25(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass33_0
	{
		public WareHouseMovementLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__15;

		internal bool _003CRegisterSendInfo_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CRegisterSendInfo_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CRegisterSendInfo_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CRegisterSendInfo_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CRegisterSendInfo_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CRegisterSendInfo_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CRegisterSendInfo_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CRegisterSendInfo_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CRegisterSendInfo_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CRegisterSendInfo_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CRegisterSendInfo_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CRegisterSendInfo_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CRegisterSendInfo_003Eb__15(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass33_1
	{
		public WSDoc model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass33_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass33_1 CS_0024_003C_003E8__locals1;

		internal bool _003CRegisterSendInfo_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CRegisterSendInfo_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CRegisterSendInfo_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CRegisterSendInfo_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CRegisterSendInfo_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CRegisterSendInfo_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CRegisterSendInfo_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CRegisterSendInfo_003Eb__24(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CRegisterSendInfo_003Eb__25(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CRegisterSendInfo_003Eb__26(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CRegisterSendInfo_003Eb__27(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CRegisterSendInfo_003Eb__28(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CRegisterSendInfo_003Eb__29(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CRegisterSendInfo_003Eb__30(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CRegisterSendInfo_003Eb__31(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CRegisterSendInfo_003Eb__32(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CRegisterSendInfo_003Eb__33(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CRegisterSendInfo_003Eb__34(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CRegisterSendInfo_003Eb__35(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CRegisterSendInfo_003Eb__36(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CRegisterSendInfo_003Eb__37(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CRegisterSendInfo_003Eb__38(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CRegisterSendInfo_003Eb__39(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CRegisterSendInfo_003Eb__40(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMLinkSpEntities _dbLink = new CRMLinkSpEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actwhWareHouseMovement")]
	public ActionResult Index(int? id = null, string parameters = "", int? companyId = null, int? productId = null, int? serialId = null, bool? fromIndicator = false, int docId = 0, int? selWorkflowStepId = null, string intMsgInfo = "")
	{
		base.ViewBag.Parameters = parameters;
		base.ViewBag.SendedDocId = 0;
		base.ViewBag.CompanyId = 0;
		base.ViewBag.FromSearchId = false;
		base.ViewBag.SelectedWorkflowStepId = selWorkflowStepId;
		if (!string.IsNullOrWhiteSpace(intMsgInfo))
		{
			base.ViewBag.IntMsgInfo = intMsgInfo;
		}
		if (id.HasValue)
		{
			base.ViewBag.SendedDocId = id;
			base.ViewBag.FromSearchId = true;
		}
		if (companyId.HasValue && companyId > 0)
		{
			base.ViewBag.CompanyId = companyId;
		}
		base.ViewBag.ProductID = 0;
		base.ViewBag.SerialId = 0;
		if (productId.HasValue)
		{
			base.ViewBag.ProductID = productId;
		}
		if (serialId.HasValue)
		{
			base.ViewBag.SerialId = serialId;
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
					CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_dbLink.CRMspSelectLinkAccSetting(0, "PreUsedHintSetting", lCID, result, 1, 0, "DocPreUsedHint"));
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
		if (fromIndicator.GetValueOrDefault())
		{
			base.ViewBag.FromIndicator = true;
		}
		base.ViewBag.DocId = docId;
		return View();
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actwhWareHouseMovement")]
	public JsonResult GetWareHouseMovement(int docCurrentId, string fromDate, string toDate, int oprType = 3, int? docNumber = null, int? companyId = null, int? docId = null, int? userId = null, bool? fromIndicator = false)
	{
		//IL_0ac6: Unknown result type (might be due to invalid IL or missing references)
		oprType = 3;
		string manualIssuing = Labels.ManualIssuing;
		string systemIssuing = Labels.SystemIssuing;
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
		DateTime value2 = DateTime.Now;
		try
		{
			if (!string.IsNullOrEmpty(fromDate) && fromDate != "-20")
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
				if (!string.IsNullOrEmpty(toDate))
				{
					toDate = toDate.Replace("/", "").Replace("-", "").Replace("\\", "")
						.Replace(" ", "")
						.Replace("_", "");
					value2 = lCID switch
					{
						1065 => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59"), 
						1025 => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59", new CultureInfo("ar-SA"), DateTimeStyles.None), 
						_ => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None), 
					};
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		CurrentWareHouseMovementViewModel currentWareHouseMovementViewModel = new CurrentWareHouseMovementViewModel();
		currentWareHouseMovementViewModel.ItemsList = new List<WSspSelectDocItems_Result>();
		currentWareHouseMovementViewModel.SerialList = new List<WSspSelectDocItemSerials_Result>();
		currentWareHouseMovementViewModel.DocLinkAccDocNumber = Labels.WareHouseMovementShowLinkAccDocNumber + ":";
		currentWareHouseMovementViewModel.DocLinkAccVoucherNumber = Labels.WareHouseMovementShowLinkAccVoucherNumber + ":";
		currentWareHouseMovementViewModel.DocLinkAccDocIdStr = Labels.WareHouseMovementShowLinkAccDocIdStr + ":";
		currentWareHouseMovementViewModel.DocLinkAccFirstTransferDateStr = Labels.lblLinkAccFirstTransferDate + ":";
		currentWareHouseMovementViewModel.DocLinkAccLastTransferDateStr = Labels.lblLinkAccLastTransferDate + ":";
		if (!userId.HasValue)
		{
			userId = UserLogin.CurrentUser.UserId;
		}
		if (!docId.HasValue)
		{
			docId = 0;
		}
		currentWareHouseMovementViewModel.LastVerificationStep = new WSspSelectVerificationWorkFlowStepLast_Result();
		currentWareHouseMovementViewModel.DocLinkAccData = "";
		currentWareHouseMovementViewModel.IsSentToLinkAcc = false;
		try
		{
			List<WSspSelectDocs_Result> list = Enumerable.ToList<WSspSelectDocs_Result>((IEnumerable<WSspSelectDocs_Result>)_db.WSspSelectDocs(fromDate, toDate, userId, oprType, docId, lCID, result, value, value2, manualIssuing, systemIssuing, result2));
			if (Enumerable.Any<WSspSelectDocs_Result>((IEnumerable<WSspSelectDocs_Result>)list))
			{
				currentWareHouseMovementViewModel.IsFind = true;
				currentWareHouseMovementViewModel.Message = "";
				currentWareHouseMovementViewModel.FromDate = fromDate;
				currentWareHouseMovementViewModel.ToDate = toDate;
				currentWareHouseMovementViewModel.NextId = -1;
				currentWareHouseMovementViewModel.PreviousId = -1;
				currentWareHouseMovementViewModel.CompanyId = -1;
				currentWareHouseMovementViewModel.FirstId = -1;
				currentWareHouseMovementViewModel.LastId = -1;
				if (list.Count == 1)
				{
					currentWareHouseMovementViewModel.FirstId = -1;
					currentWareHouseMovementViewModel.LastId = -1;
				}
				else
				{
					currentWareHouseMovementViewModel.FirstId = Enumerable.FirstOrDefault<WSspSelectDocs_Result>((IEnumerable<WSspSelectDocs_Result>)list).DocID;
					currentWareHouseMovementViewModel.LastId = Enumerable.LastOrDefault<WSspSelectDocs_Result>((IEnumerable<WSspSelectDocs_Result>)list).DocID;
				}
				WSspSelectDocs_Result wSspSelectDocs_Result = ((docCurrentId <= 0) ? Enumerable.LastOrDefault<WSspSelectDocs_Result>((IEnumerable<WSspSelectDocs_Result>)list) : list.Find((WSspSelectDocs_Result c) => c.DocID == docCurrentId));
				if (wSspSelectDocs_Result != null)
				{
					if (Doc.IsEditAfterFix(wSspSelectDocs_Result.EditAfterFixInfoJs, wSspSelectDocs_Result.DocID, 1))
					{
						wSspSelectDocs_Result.IsFix = 0;
					}
					if (!string.IsNullOrWhiteSpace((wSspSelectDocs_Result.EditAfterFixInfoJs ?? "").Replace("[]", "")))
					{
						List<EditAfterFixInfoViewModel> list2 = JsonConvert.DeserializeObject<List<EditAfterFixInfoViewModel>>(wSspSelectDocs_Result.EditAfterFixInfoJs);
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
							wSspSelectDocs_Result.EditAfterFixInfoJs = JsonConvert.SerializeObject(list2);
						}
					}
					wSspSelectDocs_Result.DocDate = (wSspSelectDocs_Result.DocDateTime.HasValue ? wSspSelectDocs_Result.DocDateTime.Value.ToString("yyyy/MM/dd") : null);
					_ = wSspSelectDocs_Result.RegisterDate;
					wSspSelectDocs_Result.RegisterDatePersian = wSspSelectDocs_Result.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
					wSspSelectDocs_Result.FirstRegisterDatePersian = (wSspSelectDocs_Result.FirstRegisterDate.HasValue ? wSspSelectDocs_Result.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : null);
					if (string.IsNullOrEmpty(wSspSelectDocs_Result.AppType))
					{
						wSspSelectDocs_Result.AppType = Configuration.AppType;
					}
					wSspSelectDocs_Result.AppType = Configuration.GetAppType(wSspSelectDocs_Result.AppType);
					wSspSelectDocs_Result.VerifiedRegisterDatePersian = (wSspSelectDocs_Result.VerifiedRegisterDate.HasValue ? wSspSelectDocs_Result.VerifiedRegisterDate.Value.ToString("yyyy/MM/dd") : null);
					if (!string.IsNullOrEmpty(wSspSelectDocs_Result.Verifier) && wSspSelectDocs_Result.VerifiedRegisterDate.HasValue)
					{
						wSspSelectDocs_Result.Verifier += (wSspSelectDocs_Result.VerifiedRegisterDate.HasValue ? (" (" + wSspSelectDocs_Result.VerifiedRegisterDate.Value.ToString("yyyy/MM/dd HH:mm") + ")") : "");
					}
					currentWareHouseMovementViewModel.Doc = wSspSelectDocs_Result;
					currentWareHouseMovementViewModel.DocNumber = wSspSelectDocs_Result.DocNumber;
					currentWareHouseMovementViewModel.CurrentId = wSspSelectDocs_Result.DocID;
					if (list.Count == 1)
					{
						currentWareHouseMovementViewModel.NextId = -1;
						currentWareHouseMovementViewModel.PreviousId = -1;
					}
					else
					{
						WSspSelectDocs_Result next = Lists.GetNext(list, wSspSelectDocs_Result);
						if (next != null)
						{
							currentWareHouseMovementViewModel.NextId = next.DocID;
						}
						WSspSelectDocs_Result previous = Lists.GetPrevious(list, wSspSelectDocs_Result);
						if (previous != null)
						{
							currentWareHouseMovementViewModel.PreviousId = previous.DocID;
						}
					}
					currentWareHouseMovementViewModel.ItemsList = GetItemsProducts(wSspSelectDocs_Result.DocID);
					if (Enumerable.Any<WSspSelectDocItems_Result>((IEnumerable<WSspSelectDocItems_Result>)currentWareHouseMovementViewModel.ItemsList))
					{
						currentWareHouseMovementViewModel.SerialList = GetSerials(currentWareHouseMovementViewModel.ItemsList[0].DocItemID);
						currentWareHouseMovementViewModel.ItemsList[0].Tracing = ConvertCharacter.DecodeTracing(currentWareHouseMovementViewModel.ItemsList[0].Tracing);
						currentWareHouseMovementViewModel.QuantityRemain = 0.0;
						int prdId = currentWareHouseMovementViewModel.ItemsList[0].PrdId;
						int wHId = wSspSelectDocs_Result.WHId;
						double? fCR = currentWareHouseMovementViewModel.ItemsList[0].FCR;
						double? fCRI = currentWareHouseMovementViewModel.ItemsList[0].FCRI;
						string tracing = currentWareHouseMovementViewModel.ItemsList[0].Tracing;
						WSspReturnPrdQuantity_Result returnPrdQuantity = GetReturnPrdQuantity(prdId, wHId, null, fCR, fCRI, tracing);
						if (returnPrdQuantity != null)
						{
							double? quantityRemain = returnPrdQuantity.QuantityRemain;
							if (quantityRemain.HasValue)
							{
								currentWareHouseMovementViewModel.QuantityRemain = double.Parse(quantityRemain.ToString());
							}
							double? tracingRemainCount = returnPrdQuantity.TracingRemainCount;
							if (tracingRemainCount.HasValue)
							{
								currentWareHouseMovementViewModel.TracingRemainCount = double.Parse(tracingRemainCount.ToString());
							}
						}
					}
					else
					{
						currentWareHouseMovementViewModel.SerialList = new List<WSspSelectDocItemSerials_Result>();
						currentWareHouseMovementViewModel.QuantityRemain = 0.0;
						currentWareHouseMovementViewModel.TracingRemainCount = 0.0;
					}
					currentWareHouseMovementViewModel.DocLinkAccDocNumber = Labels.WareHouseMovementShowLinkAccDocNumber + ":" + wSspSelectDocs_Result.DocLinkAccDocNumber;
					currentWareHouseMovementViewModel.DocLinkAccVoucherNumber = Labels.WareHouseMovementShowLinkAccVoucherNumber + ":" + wSspSelectDocs_Result.DocLinkAccVoucherNumber;
					currentWareHouseMovementViewModel.DocLinkAccDocIdStr = Labels.WareHouseMovementShowLinkAccDocIdStr + ":" + ((!string.IsNullOrWhiteSpace(wSspSelectDocs_Result.DocLinkAccDocIdStr)) ? wSspSelectDocs_Result.DocLinkAccDocIdStr : (wSspSelectDocs_Result.DocLinkAccDocId.HasValue ? wSspSelectDocs_Result.DocLinkAccDocId.ToString() : ""));
					currentWareHouseMovementViewModel.DocLinkAccFirstTransferDateStr = Labels.lblLinkAccFirstTransferDate + ":" + (wSspSelectDocs_Result.DocLinkAccFirstTransferDate.HasValue ? ("<span class='span-transfer-date-to-acc'>" + wSspSelectDocs_Result.DocLinkAccFirstTransferDate.Value.ToString("yyyy/MM/dd HH:mm:ss") + "</span>") : "");
					currentWareHouseMovementViewModel.DocLinkAccLastTransferDateStr = Labels.lblLinkAccLastTransferDate + ":" + (wSspSelectDocs_Result.DocLinkAccLastTransferDate.HasValue ? ("<span class='span-transfer-date-to-acc'>" + wSspSelectDocs_Result.DocLinkAccLastTransferDate.Value.ToString("yyyy/MM/dd HH:mm:ss") + "</span>") : "");
					CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
					int num = 0;
					if (cRMspSelectCrmsysSetting_Result != null)
					{
						num = cRMspSelectCrmsysSetting_Result.LinkAccSystemId.GetValueOrDefault();
					}
					currentWareHouseMovementViewModel.DocLinkAccData = wSspSelectDocs_Result.DocLinkAccData ?? "";
					if (num == 1)
					{
						List<CRMspSelectLinkAccSettingDBIsActive_Result> linkAccSettingDBList = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDBList(1);
						List<DocLinkAccDataViewModel> list3 = new List<DocLinkAccDataViewModel>();
						if (!string.IsNullOrWhiteSpace(currentWareHouseMovementViewModel.DocLinkAccData))
						{
							foreach (DocLinkAccDataViewModel item2 in new JavaScriptSerializer().Deserialize<List<DocLinkAccDataViewModel>>(currentWareHouseMovementViewModel.DocLinkAccData))
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
										item2.NumberWithLbl = Labels.WareHouseMovementShowLinkAccDocNumber + ": " + item2.Number;
										item2.IdWithLbl = Labels.WareHouseMovementShowLinkAccDocIdStr + ": " + item2.Id;
										item2.VoucherNumberWithLbl = Labels.WareHouseMovementShowLinkAccVoucherNumber + ": " + item2.VoucherNumber;
										item2.FTDateWithLbl = Labels.lblLinkAccFirstTransferDate + ":" + (item2.FTDate.HasValue ? ("<span class='span-transfer-date-to-acc'>" + item2.FTDate.Value.ToString("yyyy/MM/dd HH:mm:ss") + "</span>") : "");
										item2.LTDateWithLbl = Labels.lblLinkAccLastTransferDate + ":" + (item2.LTDate.HasValue ? ("<span class='span-transfer-date-to-acc'>" + item2.LTDate.Value.ToString("yyyy/MM/dd HH:mm:ss") + "</span>") : "");
										list3.Add(item2);
									}
								}
							}
						}
						currentWareHouseMovementViewModel.DocLinkAccData = "";
						if (list3 != null && Enumerable.Any<DocLinkAccDataViewModel>((IEnumerable<DocLinkAccDataViewModel>)list3))
						{
							currentWareHouseMovementViewModel.DocLinkAccData = JsonConvert.SerializeObject(Enumerable.ToList<DocLinkAccDataViewModel>((IEnumerable<DocLinkAccDataViewModel>)list3));
						}
					}
					if (wSspSelectDocs_Result.DocLinkAccCodeId.GetValueOrDefault() != 0 || !string.IsNullOrWhiteSpace(wSspSelectDocs_Result.DocLinkAccCode) || wSspSelectDocs_Result.DocLinkAccDocId.GetValueOrDefault() != 0 || !string.IsNullOrWhiteSpace(wSspSelectDocs_Result.DocLinkAccDocNumber) || wSspSelectDocs_Result.DocLinkAccVoucherId.GetValueOrDefault() != 0 || !string.IsNullOrWhiteSpace(wSspSelectDocs_Result.DocLinkAccVoucherNumber) || !string.IsNullOrWhiteSpace(wSspSelectDocs_Result.DocLinkAccDocIdStr) || (!string.IsNullOrWhiteSpace(wSspSelectDocs_Result.DocLinkAccData) && wSspSelectDocs_Result.DocLinkAccData != "[]"))
					{
						currentWareHouseMovementViewModel.IsSentToLinkAcc = true;
					}
					if (wSspSelectDocs_Result.VerificationWorkFlowId.HasValue)
					{
						currentWareHouseMovementViewModel.LastVerificationStep = Enumerable.FirstOrDefault<WSspSelectVerificationWorkFlowStepLast_Result>((IEnumerable<WSspSelectVerificationWorkFlowStepLast_Result>)_db.WSspSelectVerificationWorkFlowStepLast(wSspSelectDocs_Result.DocID, 60, wSspSelectDocs_Result.VerificationWorkFlowId, 0, lCID, result));
					}
				}
				else
				{
					currentWareHouseMovementViewModel.IsFind = false;
					currentWareHouseMovementViewModel.Message = Messages.ErrorNotFound;
					currentWareHouseMovementViewModel.FromDate = fromDate;
					currentWareHouseMovementViewModel.ToDate = toDate;
					currentWareHouseMovementViewModel.Doc = null;
					currentWareHouseMovementViewModel.CurrentId = -1;
					currentWareHouseMovementViewModel.NextId = -1;
					currentWareHouseMovementViewModel.DocNumber = -1L;
					currentWareHouseMovementViewModel.PreviousId = -1;
					currentWareHouseMovementViewModel.CompanyId = -1;
					currentWareHouseMovementViewModel.FirstId = -1;
					currentWareHouseMovementViewModel.LastId = -1;
				}
			}
			else
			{
				currentWareHouseMovementViewModel.IsFind = false;
				currentWareHouseMovementViewModel.Message = Messages.ErrorNotFound;
				currentWareHouseMovementViewModel.FromDate = fromDate;
				currentWareHouseMovementViewModel.ToDate = toDate;
				currentWareHouseMovementViewModel.Doc = null;
				currentWareHouseMovementViewModel.CurrentId = -1;
				currentWareHouseMovementViewModel.NextId = -1;
				currentWareHouseMovementViewModel.DocNumber = -1L;
				currentWareHouseMovementViewModel.PreviousId = -1;
				currentWareHouseMovementViewModel.CompanyId = -1;
				currentWareHouseMovementViewModel.FirstId = -1;
				currentWareHouseMovementViewModel.LastId = -1;
			}
		}
		catch (DbEntityValidationException ex)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
			currentWareHouseMovementViewModel.Message = Messages.frmErrorMessage + "<br />" + ((Exception)(object)ex).Message;
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			currentWareHouseMovementViewModel.Message = Messages.frmErrorMessage + "<br />" + ex2.Message;
		}
		JsonResult jsonResult = Json(currentWareHouseMovementViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public WSspReturnPrdQuantity_Result GetReturnPrdQuantity(int prdId, int wHId, int? currId = null, double? fcr = null, double? fcrI = null, string tracing = null)
	{
		if (!currId.HasValue)
		{
			currId = 0;
		}
		WSspReturnPrdQuantity_Result result = null;
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
			tracing = ConvertCharacter.DecodeTracing(tracing);
			result = Enumerable.FirstOrDefault<WSspReturnPrdQuantity_Result>((IEnumerable<WSspReturnPrdQuantity_Result>)_db.WSspReturnPrdQuantity(prdId, Financial.Get().Id, wHId, currId, lCID, result2, fcr, fcrI, tracing, result3));
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

	public List<WSspSelectDocItemSerials_Result> GetSerials(int itemId)
	{
		List<WSspSelectDocItemSerials_Result> list = new List<WSspSelectDocItemSerials_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			list = Enumerable.ToList<WSspSelectDocItemSerials_Result>((IEnumerable<WSspSelectDocItemSerials_Result>)_db.WSspSelectDocItemSerials(itemId, lCID, result));
			foreach (WSspSelectDocItemSerials_Result item in list)
			{
				item.DocDate = ((!string.IsNullOrEmpty(item.DocDate) && lCID != 1065) ? ((lCID == 1025) ? DateTime.Parse(PersianDate.GetShamsi2Miladi(item.DocDate.Replace("/", ""))).ToString("yyyyMMdd", new CultureInfo("ar-SA")) : DateTime.Parse(PersianDate.GetShamsi2Miladi(item.DocDate.Replace("/", ""))).ToString("yyyyMMdd", new CultureInfo("en-US"))) : item.DocDate);
				item.AppType = (item.ExpDateLKP.HasValue ? item.ExpDateLKP.Value.ToString("yyyyMMdd", new CultureInfo("en-US")) : "");
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
	public JsonResult Read_ItemSerials(int itemId)
	{
		List<WSspSelectDocItemSerials_Result> serials = GetSerials(itemId);
		JsonResult jsonResult = Json(serials, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<WSspSelectDocItems_Result> GetItemsProducts(int docId)
	{
		List<WSspSelectDocItems_Result> list = new List<WSspSelectDocItems_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			list = Enumerable.ToList<WSspSelectDocItems_Result>((IEnumerable<WSspSelectDocItems_Result>)_db.WSspSelectDocItems(docId, lCID, result));
			if (list != null && Enumerable.Any<WSspSelectDocItems_Result>((IEnumerable<WSspSelectDocItems_Result>)list))
			{
				foreach (WSspSelectDocItems_Result item in list)
				{
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

	public ActionResult DocItemList_Read([DataSourceRequest] DataSourceRequest request, int docId)
	{
		List<WSspSelectDocItems_Result> enumerable = new List<WSspSelectDocItems_Result>();
		try
		{
			enumerable = GetItemsProducts(docId);
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
	public JsonResult Read_ItemSerialsWithQuantityRemain(int itemId, int prdId, int WHId, double? fcr = null, double? fcrI = null, string tracing = "")
	{
		ItemSerialsWithQuantityRemain itemSerialsWithQuantityRemain = new ItemSerialsWithQuantityRemain();
		itemSerialsWithQuantityRemain.List = GetSerials(itemId);
		itemSerialsWithQuantityRemain.QuantityRemain = 0.0;
		itemSerialsWithQuantityRemain.TracingRemainCount = 0.0;
		tracing = ConvertCharacter.DecodeTracing(tracing);
		string tracing2 = tracing;
		WSspReturnPrdQuantity_Result returnPrdQuantity = GetReturnPrdQuantity(prdId, WHId, null, fcr, fcrI, tracing2);
		if (returnPrdQuantity != null)
		{
			double? quantityRemain = returnPrdQuantity.QuantityRemain;
			if (quantityRemain.HasValue)
			{
				itemSerialsWithQuantityRemain.QuantityRemain = double.Parse(quantityRemain.ToString());
			}
			double? tracingRemainCount = returnPrdQuantity.TracingRemainCount;
			if (tracingRemainCount.HasValue)
			{
				itemSerialsWithQuantityRemain.TracingRemainCount = double.Parse(tracingRemainCount.ToString());
			}
		}
		JsonResult jsonResult = Json(itemSerialsWithQuantityRemain, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public ActionResult _PartialList(int docCurrentId, string fromDate, string toDate, int oprType = 1, int? docNumber = null, int? companyId = null, int? docId = null)
	{
		WareHouseMovementListViewModel wareHouseMovementListViewModel = new WareHouseMovementListViewModel
		{
			companyId = companyId,
			docId = docId,
			toDate = toDate,
			docNumber = docNumber,
			fromDate = fromDate,
			docCurrentId = docCurrentId,
			oprType = oprType
		};
		base.ViewBag.DocList = wareHouseMovementListViewModel;
		return PartialView();
	}

	public ActionResult _PartialList_Read([DataSourceRequest] DataSourceRequest request, int docCurrentId, string fromDate, string toDate, int oprType = 1, int? docNumber = null, int? companyId = null, int? docId = null)
	{
		string manualIssuing = Labels.ManualIssuing;
		string systemIssuing = Labels.SystemIssuing;
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
		DateTime value2 = DateTime.Now;
		try
		{
			if (!string.IsNullOrEmpty(fromDate))
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
			if (!string.IsNullOrEmpty(toDate))
			{
				toDate = toDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				value2 = lCID switch
				{
					1065 => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59"), 
					1025 => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59", new CultureInfo("ar-SA"), DateTimeStyles.None), 
					_ => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None), 
				};
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		int userId = UserLogin.CurrentUser.UserId;
		if (!docId.HasValue)
		{
			docId = 0;
		}
		oprType = 3;
		List<WSspSelectDocs_Result> list = Enumerable.ToList<WSspSelectDocs_Result>(Enumerable.Reverse<WSspSelectDocs_Result>((IEnumerable<WSspSelectDocs_Result>)_db.WSspSelectDocs(fromDate, toDate, userId, oprType, docId, lCID, result, value, value2, manualIssuing, systemIssuing, result2)));
		foreach (WSspSelectDocs_Result item in list)
		{
			item.DocDate = (item.DocDateTime.HasValue ? item.DocDateTime.Value.ToString("yyyy/MM/dd") : item.DocDate);
			_ = item.RegisterDate;
			item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd");
			item.FirstRegisterDatePersian = (item.FirstRegisterDate.HasValue ? item.FirstRegisterDate.Value.ToString("yyyy/MM/dd") : item.FirstRegisterDatePersian);
			item.CompanyName = item.CompanyName ?? "";
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
	public string ExitFromIsFixOrder(int docId)
	{
		string text = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmWareHouseMovement", "actExitFromIsFix", currentUser))
		{
			return Messages.ErrorNotAccess;
		}
		try
		{
			if (docId > 0)
			{
				return (_dbI.WSspDocVerifyExit(docId) > 0) ? "1" : Messages.msgErrorRunFunction;
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
	public string DocVerify(int docId)
	{
		string text = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmWareHouseMovement", "actVerifyDoc", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string verifiedRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			int userId = UserLogin.CurrentUser.UserId;
			if (docId != 0)
			{
				_dbI.WSspDocVerify(docId, userId, value, verifiedRegisterDatePersian);
				return "1|" + userId + "|" + UserLogin.CurrentUser.FullName + " (" + value.ToString("yyyy/MM/dd HH:mm") + ")";
			}
			return Messages.ErrorNotFound;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.frmErrorMessage;
		}
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmWareHouseMovement", ActionName = "actDeleteDoc")]
	public string Delete(int docId)
	{
		_003C_003Ec__DisplayClass17_0 _003C_003Ec__DisplayClass17_ = new _003C_003Ec__DisplayClass17_0();
		_003C_003Ec__DisplayClass17_.docId = docId;
		string result = "";
		try
		{
			DbSet<WSDoc> wSDoc = _dbTbl.WSDoc;
			ParameterExpression val = Expression.Parameter(typeof(WSDoc), "c");
			if (Queryable.FirstOrDefault<WSDoc>((IQueryable<WSDoc>)wSDoc, Expression.Lambda<Func<WSDoc, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass17_, typeof(_003C_003Ec__DisplayClass17_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
			{
				if (WareHouseMovement.IsSentToLinkAccByAction(_003C_003Ec__DisplayClass17_.docId))
				{
					string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
					return string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
				}
				try
				{
					_db.CRMspDyDeleteFormFieldMasterValuesBySysPart(_003C_003Ec__DisplayClass17_.docId, "whmovement");
					mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)Enumerable.ToList<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteWSDoc(_003C_003Ec__DisplayClass17_.docId)));
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
	[DynamicAuthorize(ControllerName = "frmWareHouseMovement", ActionName = "actDeleteDocItem")]
	public string DeleteItem(int docItemId, int docId)
	{
		_003C_003Ec__DisplayClass18_0 _003C_003Ec__DisplayClass18_ = new _003C_003Ec__DisplayClass18_0();
		_003C_003Ec__DisplayClass18_.docItemId = docItemId;
		string result = "";
		try
		{
			if (Doc.IsFixed(docId))
			{
				return Messages.msgErrorNotActiveWareHouseMovement;
			}
			if (WareHouseMovement.IsSentToLinkAccByAction(docId))
			{
				string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
				return string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
			}
			if (_003C_003Ec__DisplayClass18_.docItemId > 0)
			{
				DbSet<WSDocItems> wSDocItems = _dbTbl.WSDocItems;
				ParameterExpression val = Expression.Parameter(typeof(WSDocItems), "c");
				if (Queryable.FirstOrDefault<WSDocItems>((IQueryable<WSDocItems>)wSDocItems, Expression.Lambda<Func<WSDocItems, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass18_, typeof(_003C_003Ec__DisplayClass18_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
				{
					try
					{
						mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)Enumerable.ToList<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteWSDocItems(_003C_003Ec__DisplayClass18_.docItemId)));
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
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmWareHouseMovement", ActionName = "actDeleteItemSerial")]
	public string DeleteItemSerial(int docItemSerialId, int docId)
	{
		_003C_003Ec__DisplayClass19_0 _003C_003Ec__DisplayClass19_ = new _003C_003Ec__DisplayClass19_0();
		_003C_003Ec__DisplayClass19_.docItemSerialId = docItemSerialId;
		string result = "";
		try
		{
			if (Doc.IsFixed(docId))
			{
				return Messages.msgErrorNotActiveWareHouseMovement;
			}
			if (WareHouseMovement.IsSentToLinkAccByAction(docId))
			{
				string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
				return string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
			}
			if (_003C_003Ec__DisplayClass19_.docItemSerialId > 0)
			{
				if (!Enumerable.Any<int?>((IEnumerable<int?>)Enumerable.ToList<int?>((IEnumerable<int?>)_db.WSfnCheckOrderBeforeDeleteResidSerial(_003C_003Ec__DisplayClass19_.docItemSerialId))))
				{
					DbSet<WSDocItemSerials> wSDocItemSerials = _dbTbl.WSDocItemSerials;
					ParameterExpression val = Expression.Parameter(typeof(WSDocItemSerials), "c");
					if (Queryable.FirstOrDefault<WSDocItemSerials>((IQueryable<WSDocItemSerials>)wSDocItemSerials, Expression.Lambda<Func<WSDocItemSerials, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass19_, typeof(_003C_003Ec__DisplayClass19_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
					{
						try
						{
							mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)Enumerable.ToList<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteWSDocItemSerials(_003C_003Ec__DisplayClass19_.docItemSerialId)));
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
				else
				{
					result = Messages.msgErrorUnableToDeleteSerialInDoc;
				}
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
	[DynamicAuthorize(ControllerName = "frmWareHouseMovement", ActionName = "actDeleteAllSerials")]
	public string DeleteAllItemSerials(int docItemId, int docId)
	{
		string result = "1";
		try
		{
			if (Doc.IsFixed(docId))
			{
				return Messages.msgErrorNotActiveWareHouseMovement;
			}
			if (WareHouseMovement.IsSentToLinkAccByAction(docId))
			{
				string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
				return string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
			}
			if (docItemId > 0)
			{
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)Enumerable.ToList<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteDocItemSerialsByDocItemId(docItemId)));
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
	[DynamicAuthorize(ControllerName = "frmWareHouseMovement", ActionName = "actDeleteDocItemWithLinked")]
	public string RemoveProductWithLinked(int docId, int docItemId)
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
			if (!UserLogin.IsUserAccess("frmWareHouseMovement", "actDeleteDocItemWithLinked", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			if (Doc.IsFixed(docId))
			{
				return Messages.msgErrorNotActiveWareHouseMovement;
			}
			if (WareHouseMovement.IsSentToLinkAccByAction(docId))
			{
				string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
				return string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
			}
			if (docItemId > 0)
			{
				try
				{
					mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.WSspDeleteDocItemWithLinkedPrd(docId, docItemId));
					if (mct_I_Result != null && mct_I_Result.Result > 0)
					{
						result = "1";
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
	[DynamicAuthorize(ControllerName = "frmWareHouseMovement", ActionName = "actDeleteDocItemAll")]
	public string RemoveProductAll(int docId)
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
			if (!UserLogin.IsUserAccess("frmWareHouseMovement", "actDeleteDocItemAll", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			if (Doc.IsFixed(docId))
			{
				return Messages.msgErrorNotActiveWareHouseMovement;
			}
			if (WareHouseMovement.IsSentToLinkAccByAction(docId))
			{
				string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
				return string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
			}
			if (docId > 0)
			{
				try
				{
					mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.WSspDeleteDocItemsAll(docId));
					if (mct_I_Result != null && mct_I_Result.Result > 0)
					{
						result = "1";
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
	public string IsFixed(int docId)
	{
		string result = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmWareHouseMovement", "actIsFixed", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			_dbII.WSspDocIsFixed(docId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	[AjaxOnly]
	public string ExitIsFixed(int docId)
	{
		string result = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmWareHouseMovement", "actExitIsFixed", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			if (Doc.IsVerified(docId))
			{
				return string.Format(Messages.msgErrorNotExitIsFixedAfterVerify, Labels.lblMoveMent);
			}
			_dbII.WSspDocIsFixedExit(docId);
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
		_dbLink.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}

	[DynamicAuthorize(ControllerName = "frmWareHouseMovement", ActionName = "actInsertDoc,actEditDoc")]
	public ActionResult InsertEdit(int id = 0, string parameters = "")
	{
		_003C_003Ec__DisplayClass26_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass26_0();
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
		GetdVerifierTitles();
		GetVerificationWorkFlow();
		WareHouseMovementLanguageViewModel wareHouseMovementLanguageViewModel = new WareHouseMovementLanguageViewModel();
		List<CRMspSelectCompanyTitle_Result> list = Enumerable.ToList<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)_db.CRMspSelectCompanyTitle(CS_0024_003C_003E8__locals0.currLangID, result));
		if (CS_0024_003C_003E8__locals0.id > 0)
		{
			if (!UserLogin.IsUserAccess("frmWareHouseMovement", "actEditDoc"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			DbSet<WSDoc_Lang> wSDoc_Lang = _dbTbl.WSDoc_Lang;
			ParameterExpression val = Expression.Parameter(typeof(WSDoc_Lang), "c");
			List<WSDoc_Lang> list2 = Enumerable.ToList<WSDoc_Lang>((IEnumerable<WSDoc_Lang>)Queryable.Where<WSDoc_Lang>((IQueryable<WSDoc_Lang>)wSDoc_Lang, Expression.Lambda<Func<WSDoc_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass26_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			DbSet<WSDoc> wSDoc = _dbTbl.WSDoc;
			val = Expression.Parameter(typeof(WSDoc), "c");
			WSDoc wSDoc2 = Queryable.FirstOrDefault<WSDoc>((IQueryable<WSDoc>)wSDoc, Expression.Lambda<Func<WSDoc, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass26_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (wSDoc2 == null)
			{
				base.ViewBag.Error = Messages.ErrorNotFound;
				return null;
			}
			if (Doc.IsEditAfterFix(wSDoc2.EditAfterFixInfoJs, wSDoc2.DocID, 1))
			{
				wSDoc2.IsFix = 0;
			}
			if (wSDoc2.IsFix.HasValue && ((int?)wSDoc2.IsFix).GetValueOrDefault() == 1)
			{
				base.ViewBag.Error = Messages.msgErrorNotActiveWareHouseMovement;
				return null;
			}
			CRMspSelectCompanyById_Result cmp2 = CRMIdeal.Classes.Helper.Company.GetCompanyById(wSDoc2.CompanyId.GetValueOrDefault());
			if (cmp2 != null)
			{
				text = ((Enumerable.FirstOrDefault<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)list, (Func<CRMspSelectCompanyTitle_Result, bool>)((CRMspSelectCompanyTitle_Result c) => c.CompanyTitleID == cmp2.cmpTitleId)) != null) ? (Enumerable.FirstOrDefault<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)list, (Func<CRMspSelectCompanyTitle_Result, bool>)((CRMspSelectCompanyTitle_Result c) => c.CompanyTitleID == cmp2.cmpTitleId)).CompanyTitle + " ") : "") + cmp2.cmpName;
				text2 = cmp2.cmpAddress;
			}
			List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSDoc_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSDoc_Lang>)list2, (Func<WSDoc_Lang, CommonMultiLanguageViewModel>)((WSDoc_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.SenderName,
				LanguageId = item.LanguageID
			})));
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = wSDoc2.SenderName,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSDoc_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSDoc_Lang>)list2, (Func<WSDoc_Lang, CommonMultiLanguageViewModel>)((WSDoc_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.Description,
				LanguageId = item.LanguageID
			})));
			list4.Add(new CommonMultiLanguageViewModel
			{
				Value = wSDoc2.Description,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list5 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSDoc_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSDoc_Lang>)list2, (Func<WSDoc_Lang, CommonMultiLanguageViewModel>)((WSDoc_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.SendAddress,
				LanguageId = item.LanguageID
			})));
			list5.Add(new CommonMultiLanguageViewModel
			{
				Value = wSDoc2.SendAddress,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list6 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSDoc_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSDoc_Lang>)list2, (Func<WSDoc_Lang, CommonMultiLanguageViewModel>)((WSDoc_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.DriverName,
				LanguageId = item.LanguageID
			})));
			list6.Add(new CommonMultiLanguageViewModel
			{
				Value = wSDoc2.DriverName,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list7 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSDoc_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSDoc_Lang>)list2, (Func<WSDoc_Lang, CommonMultiLanguageViewModel>)((WSDoc_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.FreightName,
				LanguageId = item.LanguageID
			})));
			list7.Add(new CommonMultiLanguageViewModel
			{
				Value = wSDoc2.FreightName,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list8 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSDoc_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSDoc_Lang>)list2, (Func<WSDoc_Lang, CommonMultiLanguageViewModel>)((WSDoc_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.cmpTitle,
				LanguageId = item.LanguageID
			})));
			list8.Add(new CommonMultiLanguageViewModel
			{
				Value = wSDoc2.cmpTitle,
				LanguageId = result
			});
			wareHouseMovementLanguageViewModel = new WareHouseMovementLanguageViewModel
			{
				DocID = wSDoc2.DocID,
				OprId = wSDoc2.OprId,
				DocNumber = wSDoc2.DocNumber,
				DocDate = (wSDoc2.DocDateTime.HasValue ? wSDoc2.DocDateTime.Value.ToString("yyyy/MM/dd") : ""),
				SenderId = wSDoc2.SenderId,
				FactorNumber = wSDoc2.FactorNumber,
				IsFix = wSDoc2.IsFix,
				WHId = wSDoc2.WHId,
				FirstRegisterUserId = wSDoc2.FirstRegisterUserId,
				UserId = wSDoc2.UserId,
				Month1 = wSDoc2.Month1,
				FPId = wSDoc2.FPId,
				RegisterDate = wSDoc2.RegisterDate,
				RegisterDatePersian = wSDoc2.RegisterDatePersian,
				OrderIds = wSDoc2.OrderIds,
				GUId = wSDoc2.GUId,
				BuyOrderId = wSDoc2.BuyOrderId,
				DriverTel = wSDoc2.DriverTel,
				BijakNumber = wSDoc2.BijakNumber,
				CarNumber = wSDoc2.CarNumber,
				DocDateTime = wSDoc2.DocDateTime,
				FirstRegisterDatePersian = wSDoc2.FirstRegisterDatePersian,
				FirstRegisterDate = wSDoc2.FirstRegisterDate,
				WHIdI = wSDoc2.WHIdI,
				CompanyId = wSDoc2.CompanyId,
				CompanyPersonId = wSDoc2.CompanyPersonId,
				ProjectId = wSDoc2.ProjectId,
				AppType = wSDoc2.AppType,
				LanguageID = wSDoc2.LanguageID,
				SenderName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				SenderName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				Description_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				SendAddress = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				SendAddress_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				DriverName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				DriverName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				FreightName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				FreightName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				cmpTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				cmpTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				DocNumRef = wSDoc2.DocNumRef,
				VerifierRequestId = wSDoc2.VerifierRequestId,
				VerificationWorkFlowId = wSDoc2.VerificationWorkFlowId
			};
		}
		else
		{
			if (!UserLogin.IsUserAccess("frmWareHouseMovement", "actInsertDoc"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			DateTime now = DateTime.Now;
			wareHouseMovementLanguageViewModel = new WareHouseMovementLanguageViewModel
			{
				FirstRegisterUserId = UserLogin.CurrentUser.UserId,
				DocDate = now.ToString("yyyyMMdd", new PersianCulture()),
				DocDateTime = now,
				UserId = UserLogin.CurrentUser.UserId,
				RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
				RegisterDate = now,
				FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
				FirstRegisterDate = now
			};
			if (array.Length >= 1 && array[0] != "")
			{
				int result2 = 0;
				int.TryParse(array[0], out result2);
				CRMspSelectCompanyById_Result cmp = CRMIdeal.Classes.Helper.Company.GetCompanyById(result2);
				if (cmp != null)
				{
					text = ((Enumerable.FirstOrDefault<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)list, (Func<CRMspSelectCompanyTitle_Result, bool>)((CRMspSelectCompanyTitle_Result c) => c.CompanyTitleID == cmp.cmpTitleId)) != null) ? (Enumerable.FirstOrDefault<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)list, (Func<CRMspSelectCompanyTitle_Result, bool>)((CRMspSelectCompanyTitle_Result c) => c.CompanyTitleID == cmp.cmpTitleId)).CompanyTitle + " ") : "") + cmp.cmpName;
					text2 = cmp.cmpAddress;
				}
			}
			base.ViewBag.IsBuying = VersionBuyer.WareHouse;
		}
		GetDocOpr();
		GetWareHouse();
		base.ViewBag.CmpFullName = text;
		base.ViewBag.CmpAddrs = text2;
		return View(wareHouseMovementLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmWareHouseMovementDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult InsertEdit(WareHouseMovementLanguageViewModel vm)
	{
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass27_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass27_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		GetdVerifierTitles();
		GetVerificationWorkFlow();
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.SenderName_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.SenderName_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.SenderName,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.Description_Lang))
		{
			list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.Description_Lang);
		}
		list2.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.Description,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.SendAddress_Lang))
		{
			list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.SendAddress_Lang);
		}
		list3.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.SendAddress,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.DriverName_Lang))
		{
			list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.DriverName_Lang);
		}
		list4.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.DriverName,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.FreightName_Lang))
		{
			list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.FreightName_Lang);
		}
		list5.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.FreightName,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.cmpTitle_Lang))
		{
			list6 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.cmpTitle_Lang);
		}
		list6.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.cmpTitle,
			LanguageId = lCID
		});
		base.ViewBag.MyParameters = "".Split(new char[1] { '|' });
		string text = "";
		string text2 = "";
		CS_0024_003C_003E8__locals0.cmp = CRMIdeal.Classes.Helper.Company.GetCompanyById(CS_0024_003C_003E8__locals0.vm.CompanyId.GetValueOrDefault());
		List<CRMspSelectCompanyTitle_Result> list7 = Enumerable.ToList<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)_db.CRMspSelectCompanyTitle(lCID, CS_0024_003C_003E8__locals0.defLangID));
		if (CS_0024_003C_003E8__locals0.cmp != null)
		{
			text = ((Enumerable.FirstOrDefault<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)list7, (Func<CRMspSelectCompanyTitle_Result, bool>)((CRMspSelectCompanyTitle_Result c) => c.CompanyTitleID == CS_0024_003C_003E8__locals0.cmp.cmpTitleId)) != null) ? (Enumerable.FirstOrDefault<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)list7, (Func<CRMspSelectCompanyTitle_Result, bool>)((CRMspSelectCompanyTitle_Result c) => c.CompanyTitleID == CS_0024_003C_003E8__locals0.cmp.cmpTitleId)).CompanyTitle + " ") : "") + CS_0024_003C_003E8__locals0.cmp.cmpName;
			text2 = CS_0024_003C_003E8__locals0.cmp.cmpAddress;
		}
		base.ViewBag.CmpFullName = text;
		base.ViewBag.CmpAddrs = text2;
		GetDocOpr();
		GetWareHouse();
		long num = 0L;
		string text3 = "";
		int sysPartId = 62;
		try
		{
			int? num2 = null;
			if (UserLogin.CurrentUser != null)
			{
				num2 = UserLogin.CurrentUser.UserLastCId;
			}
			if (CS_0024_003C_003E8__locals0.vm.DocID <= 0 && !VersionBuyer.WareHouse)
			{
				DbSet<WSDoc> wSDoc = _dbTbl.WSDoc;
				ParameterExpression val = Expression.Parameter(typeof(WSDoc), "c");
				if (Queryable.Any<WSDoc>((IQueryable<WSDoc>)wSDoc, Expression.Lambda<Func<WSDoc, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)10, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val })))
				{
					base.ViewBag.Error = "BV|" + Messages.VersionBuy;
					return View(CS_0024_003C_003E8__locals0.vm);
				}
			}
			if (CS_0024_003C_003E8__locals0.vm.DocID > 0 && WareHouseMovement.IsSentToLinkAccByAction(CS_0024_003C_003E8__locals0.vm.DocID))
			{
				string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
				base.ViewBag.Error = string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			DateTime dateTime = default(DateTime);
			string text4 = "";
			try
			{
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.DocDate))
				{
					text4 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.vm.DocDate.Replace("/", ""));
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
						CS_0024_003C_003E8__locals0.vm.DocDate = dateTime.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime = DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
						CS_0024_003C_003E8__locals0.vm.DocDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime = DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
						CS_0024_003C_003E8__locals0.vm.DocDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
					CS_0024_003C_003E8__locals0.vm.DocDateTime = dateTime;
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				base.ViewBag.Error = Messages.WrongDocDateTime;
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			if (CS_0024_003C_003E8__locals0.vm.DocDate != null)
			{
				CS_0024_003C_003E8__locals0.vm.DocDate = CS_0024_003C_003E8__locals0.vm.DocDate.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
			}
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.DocNumRef) && UserLogin.IsUserAccess("frmWareHouseMovementDataEntry", "actNotDupNumRef", UserLogin.CurrentUser))
			{
				WSspCheckDuplicateDocNumRef_Result wSspCheckDuplicateDocNumRef_Result = Enumerable.FirstOrDefault<WSspCheckDuplicateDocNumRef_Result>((IEnumerable<WSspCheckDuplicateDocNumRef_Result>)_db.WSspCheckDuplicateDocNumRef(CS_0024_003C_003E8__locals0.vm.DocNumRef, CS_0024_003C_003E8__locals0.vm.DocID, CS_0024_003C_003E8__locals0.vm.OprId, num2));
				if (wSspCheckDuplicateDocNumRef_Result != null)
				{
					base.ViewBag.Error = string.Format(Messages.DocNumRefIsRepeated, wSspCheckDuplicateDocNumRef_Result.DocNumber.ToString());
					return View(CS_0024_003C_003E8__locals0.vm);
				}
			}
			if (!base.ModelState.IsValid)
			{
				base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
			else
			{
				_003C_003Ec__DisplayClass27_1 _003C_003Ec__DisplayClass27_ = new _003C_003Ec__DisplayClass27_1();
				_003C_003Ec__DisplayClass27_.model = new WSDoc();
				if (CS_0024_003C_003E8__locals0.vm.DocID > 0)
				{
					DbSet<WSDoc> wSDoc2 = _dbTbl.WSDoc;
					ParameterExpression val = Expression.Parameter(typeof(WSDoc), "c");
					_003C_003Ec__DisplayClass27_.model = Queryable.FirstOrDefault<WSDoc>((IQueryable<WSDoc>)wSDoc2, Expression.Lambda<Func<WSDoc, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass27_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				_003C_003Ec__DisplayClass27_.model.UserId = UserLogin.CurrentUser.UserId;
				DateTime now = DateTime.Now;
				_003C_003Ec__DisplayClass27_.model.RegisterDate = now;
				_003C_003Ec__DisplayClass27_.model.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				_003C_003Ec__DisplayClass27_.model.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
				_003C_003Ec__DisplayClass27_.model.AppType = Configuration.AppType;
				_003C_003Ec__DisplayClass27_.model.OprId = CS_0024_003C_003E8__locals0.vm.OprId;
				_003C_003Ec__DisplayClass27_.model.DocNumber = CS_0024_003C_003E8__locals0.vm.DocNumber;
				_003C_003Ec__DisplayClass27_.model.DocDate = CS_0024_003C_003E8__locals0.vm.DocDate;
				_003C_003Ec__DisplayClass27_.model.SenderId = CS_0024_003C_003E8__locals0.vm.SenderId;
				_003C_003Ec__DisplayClass27_.model.FactorNumber = CS_0024_003C_003E8__locals0.vm.FactorNumber;
				_003C_003Ec__DisplayClass27_.model.IsFix = CS_0024_003C_003E8__locals0.vm.IsFix;
				if (_003C_003Ec__DisplayClass27_.model.DocID == 0)
				{
					_003C_003Ec__DisplayClass27_.model.WHId = CS_0024_003C_003E8__locals0.vm.WHId;
				}
				_003C_003Ec__DisplayClass27_.model.OrderIds = CS_0024_003C_003E8__locals0.vm.OrderIds;
				_003C_003Ec__DisplayClass27_.model.BuyOrderId = CS_0024_003C_003E8__locals0.vm.BuyOrderId;
				_003C_003Ec__DisplayClass27_.model.DriverTel = CS_0024_003C_003E8__locals0.vm.DriverTel;
				_003C_003Ec__DisplayClass27_.model.BijakNumber = CS_0024_003C_003E8__locals0.vm.BijakNumber;
				_003C_003Ec__DisplayClass27_.model.CarNumber = CS_0024_003C_003E8__locals0.vm.CarNumber;
				_003C_003Ec__DisplayClass27_.model.DocDateTime = CS_0024_003C_003E8__locals0.vm.DocDateTime;
				if (_003C_003Ec__DisplayClass27_.model.DocID == 0)
				{
					_003C_003Ec__DisplayClass27_.model.WHIdI = CS_0024_003C_003E8__locals0.vm.WHIdI;
				}
				_003C_003Ec__DisplayClass27_.model.CompanyId = CS_0024_003C_003E8__locals0.vm.CompanyId;
				_003C_003Ec__DisplayClass27_.model.CompanyPersonId = CS_0024_003C_003E8__locals0.vm.CompanyPersonId;
				_003C_003Ec__DisplayClass27_.model.ProjectId = CS_0024_003C_003E8__locals0.vm.ProjectId;
				_003C_003Ec__DisplayClass27_.model.SenderName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass27_.model.Description = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass27_.model.SendAddress = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass27_.model.DriverName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass27_.model.FreightName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass27_.model.cmpTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass27_.model.VerifierRequestId = CS_0024_003C_003E8__locals0.vm.VerifierRequestId;
				_003C_003Ec__DisplayClass27_.model.VerificationWorkFlowId = CS_0024_003C_003E8__locals0.vm.VerificationWorkFlowId;
				if (_003C_003Ec__DisplayClass27_.model.DocID > 0)
				{
					if (UserLogin.IsUserAccess("frmWareHouseMovementDataEntry", "actCanChangeNumRef", UserLogin.CurrentUser))
					{
						_003C_003Ec__DisplayClass27_.model.DocNumRef = CS_0024_003C_003E8__locals0.vm.DocNumRef;
					}
					int result = 0;
					int.TryParse(_003C_003Ec__DisplayClass27_.model.DocNumber.ToString(), out result);
					if (CheckDuplicateDocNumber(result, _003C_003Ec__DisplayClass27_.model.DocID, _003C_003Ec__DisplayClass27_.model.OprId, _003C_003Ec__DisplayClass27_.model.DocCId) > 0)
					{
						base.ViewBag.Error = Messages.WareHouseMovementNumberIsRepeated;
						return View(CS_0024_003C_003E8__locals0.vm);
					}
					_dbTbl.Entry(_003C_003Ec__DisplayClass27_.model).State = EntityState.Modified;
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass27_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass27_2();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass27_;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							DbSet<WSDoc_Lang> wSDoc_Lang = _dbTbl.WSDoc_Lang;
							ParameterExpression val = Expression.Parameter(typeof(WSDoc_Lang), "c");
							WSDoc_Lang wSDoc_Lang2 = Queryable.FirstOrDefault<WSDoc_Lang>((IQueryable<WSDoc_Lang>)wSDoc_Lang, Expression.Lambda<Func<WSDoc_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass27_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass27_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (wSDoc_Lang2 != null)
							{
								wSDoc_Lang2.SenderName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSDoc_Lang2.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSDoc_Lang2.SendAddress = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSDoc_Lang2.DriverName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSDoc_Lang2.FreightName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSDoc_Lang2.cmpTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(wSDoc_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							wSDoc_Lang2 = new WSDoc_Lang();
							wSDoc_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
							wSDoc_Lang2.DocID = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.DocID;
							wSDoc_Lang2.SenderName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							wSDoc_Lang2.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							wSDoc_Lang2.SendAddress = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							wSDoc_Lang2.DriverName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							wSDoc_Lang2.FreightName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							wSDoc_Lang2.cmpTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							_dbTbl.WSDoc_Lang.Add(wSDoc_Lang2);
							_dbTbl.SaveChanges();
						}
					}
					CS_0024_003C_003E8__locals0.vm.DocDate = (CS_0024_003C_003E8__locals0.vm.DocDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.DocDateTime.Value.ToString("yyyyMMdd") : CS_0024_003C_003E8__locals0.vm.DocDate);
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
				else
				{
					_003C_003Ec__DisplayClass27_.model.FPId = Financial.Get().Id;
					int num3 = 0;
					bool flag = false;
					int num4 = 0;
					while (!flag)
					{
						num3 = Enumerable.FirstOrDefault<int>((IEnumerable<int>)Enumerable.ToList<int>(_db.Database.SqlQuery<int>($"Select dbo.WSfnReturnDocNumber({_003C_003Ec__DisplayClass27_.model.OprId},{num2.GetValueOrDefault()})", Array.Empty<object>())));
						_003C_003Ec__DisplayClass27_.model.DocNumber = num3;
						num = _003C_003Ec__DisplayClass27_.model.DocNumber;
						flag = ReservedNumber.AddNumber(sysPartId, num);
						num4++;
						if (num4 > 10)
						{
							break;
						}
					}
					int result2 = 0;
					int.TryParse(_003C_003Ec__DisplayClass27_.model.DocNumber.ToString(), out result2);
					if (CheckDuplicateDocNumber(result2, 0, _003C_003Ec__DisplayClass27_.model.OprId, num2) > 0)
					{
						base.ViewBag.Error = Messages.WareHouseMovementNumberIsRepeated;
						ReservedNumber.UpdateNumber(sysPartId, num);
						if (!string.IsNullOrWhiteSpace(text3))
						{
							ReservedNumber.UpdateNumber(sysPartId, 0, text3);
						}
						return View(CS_0024_003C_003E8__locals0.vm);
					}
					_003C_003Ec__DisplayClass27_.model.GUId = System.Guid.NewGuid();
					_003C_003Ec__DisplayClass27_.model.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
					_003C_003Ec__DisplayClass27_.model.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					_003C_003Ec__DisplayClass27_.model.FirstRegisterDate = now;
					_003C_003Ec__DisplayClass27_.model.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
					if (UserLogin.IsUserAccess("frmWareHouseMovementDataEntry", "actAutoCalcNumRef", UserLogin.CurrentUser))
					{
						flag = false;
						num4 = 0;
						while (!flag)
						{
							string docNumRef = Enumerable.FirstOrDefault<string>((IEnumerable<string>)_db.WSspReturnDocNumRef(_003C_003Ec__DisplayClass27_.model.CompanyId, _003C_003Ec__DisplayClass27_.model.ProjectId, UserLogin.CurrentUser.UserId, _003C_003Ec__DisplayClass27_.model.DocNumber, lCID, CS_0024_003C_003E8__locals0.defLangID, num2));
							_003C_003Ec__DisplayClass27_.model.DocNumRef = docNumRef;
							text3 = _003C_003Ec__DisplayClass27_.model.DocNumRef;
							flag = string.IsNullOrWhiteSpace(text3) || !UserLogin.IsUserAccess("frmWareHouseMovementDataEntry", "actNotDupNumRef", UserLogin.CurrentUser) || ReservedNumber.AddNumber(sysPartId, 0, text3);
							num4++;
							if (num4 > 10)
							{
								break;
							}
						}
					}
					else
					{
						_003C_003Ec__DisplayClass27_.model.DocNumRef = CS_0024_003C_003E8__locals0.vm.DocNumRef;
					}
					if (!string.IsNullOrEmpty(_003C_003Ec__DisplayClass27_.model.DocNumRef) && UserLogin.IsUserAccess("frmWareHouseMovementDataEntry", "actNotDupNumRef", UserLogin.CurrentUser))
					{
						WSspCheckDuplicateDocNumRef_Result wSspCheckDuplicateDocNumRef_Result2 = Enumerable.FirstOrDefault<WSspCheckDuplicateDocNumRef_Result>((IEnumerable<WSspCheckDuplicateDocNumRef_Result>)_db.WSspCheckDuplicateDocNumRef(_003C_003Ec__DisplayClass27_.model.DocNumRef, _003C_003Ec__DisplayClass27_.model.DocID, _003C_003Ec__DisplayClass27_.model.OprId, num2));
						if (wSspCheckDuplicateDocNumRef_Result2 != null)
						{
							base.ViewBag.Error = string.Format(Messages.DocNumRefIsRepeated, wSspCheckDuplicateDocNumRef_Result2.DocNumber.ToString());
							ReservedNumber.UpdateNumber(sysPartId, num);
							if (!string.IsNullOrWhiteSpace(text3))
							{
								ReservedNumber.UpdateNumber(sysPartId, 0, text3);
							}
							return View(CS_0024_003C_003E8__locals0.vm);
						}
					}
					_003C_003Ec__DisplayClass27_.model.DocCId = num2;
					_dbTbl.WSDoc.Add(_003C_003Ec__DisplayClass27_.model);
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					num = (ReservedNumber.RemoveNumber(sysPartId, num) ? 0 : num);
					if (!string.IsNullOrWhiteSpace(text3))
					{
						text3 = (ReservedNumber.RemoveNumber(sysPartId, 0, text3) ? "" : text3);
					}
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
					{
						WSDoc_Lang wSDoc_Lang3 = new WSDoc_Lang();
						wSDoc_Lang3.LanguageID = lang.LanguageID;
						wSDoc_Lang3.DocID = _003C_003Ec__DisplayClass27_.model.DocID;
						wSDoc_Lang3.SenderName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSDoc_Lang3.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSDoc_Lang3.SendAddress = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSDoc_Lang3.DriverName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSDoc_Lang3.FreightName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSDoc_Lang3.cmpTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						_dbTbl.WSDoc_Lang.Add(wSDoc_Lang3);
						_dbTbl.SaveChanges();
					}
					CS_0024_003C_003E8__locals0.vm.DocID = _003C_003Ec__DisplayClass27_.model.DocID;
					CS_0024_003C_003E8__locals0.vm.DocDate = (CS_0024_003C_003E8__locals0.vm.DocDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.DocDateTime.Value.ToString("yyyyMMdd") : CS_0024_003C_003E8__locals0.vm.DocDate);
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
		if (num != 0L)
		{
			ReservedNumber.RemoveNumber(sysPartId, num);
		}
		if (!string.IsNullOrWhiteSpace(text3))
		{
			ReservedNumber.RemoveNumber(sysPartId, 0, text3);
		}
		return View(CS_0024_003C_003E8__locals0.vm);
	}

	[AjaxOnly]
	public JsonResult GetDocOpr()
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
			List<WSspSelectDocOprByoprType_Result> list2 = Enumerable.ToList<WSspSelectDocOprByoprType_Result>((IEnumerable<WSspSelectDocOprByoprType_Result>)_db.WSspSelectDocOprByoprType(3, lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectDocOprByoprType_Result, SelectListItem>((IEnumerable<WSspSelectDocOprByoprType_Result>)list2, (Func<WSspSelectDocOprByoprType_Result, SelectListItem>)((WSspSelectDocOprByoprType_Result item) => new SelectListItem
			{
				Text = item.Name,
				Value = item.DocOprID.ToString(),
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
		base.ViewBag.DocOprList = list;
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
	public string GetReturnDocNumber(int docOprId, int? cId = null)
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
			result = Enumerable.FirstOrDefault<int>((IEnumerable<int>)Enumerable.ToList<int>(_db.Database.SqlQuery<int>($"Select dbo.WSfnReturnDocNumber({docOprId},{cId.GetValueOrDefault()})", Array.Empty<object>()))).ToString();
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
	public long CheckDuplicateDocNumber(int docNumber, int docId, int? oprId, int? cId = null)
	{
		long result = 0L;
		if (!oprId.HasValue)
		{
			oprId = 0;
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
			int? num2 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)Enumerable.ToList<int?>((IEnumerable<int?>)_db.WSfnCheckDuplicateDocNumber(docNumber, docId, oprId, cId)));
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

	[DynamicAuthorize(ControllerName = "frmWareHouseMovement", ActionName = "actRegisterSendInfo")]
	public ActionResult RegisterSendInfo(int docId)
	{
		_003C_003Ec__DisplayClass32_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass32_0();
		CS_0024_003C_003E8__locals0.docId = docId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		WSDoc wSDoc = new WSDoc();
		WareHouseMovementLanguageViewModel model = new WareHouseMovementLanguageViewModel();
		if (CS_0024_003C_003E8__locals0.docId > 0)
		{
			try
			{
				DbSet<WSDoc_Lang> wSDoc_Lang = _dbTbl.WSDoc_Lang;
				ParameterExpression val = Expression.Parameter(typeof(WSDoc_Lang), "c");
				List<WSDoc_Lang> list = Enumerable.ToList<WSDoc_Lang>((IEnumerable<WSDoc_Lang>)Queryable.Where<WSDoc_Lang>((IQueryable<WSDoc_Lang>)wSDoc_Lang, Expression.Lambda<Func<WSDoc_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass32_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				DbSet<WSDoc> wSDoc2 = _dbTbl.WSDoc;
				val = Expression.Parameter(typeof(WSDoc), "c");
				wSDoc = Queryable.FirstOrDefault<WSDoc>((IQueryable<WSDoc>)wSDoc2, Expression.Lambda<Func<WSDoc, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass32_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (wSDoc == null)
				{
					base.ViewBag.Error = Messages.msgErrorWarehouseMovementNotFound;
				}
				else
				{
					if (!UserLogin.IsUserAccess("frmWareHouseMovement", "actCanRegisterSendInfoAfterIsFix") && wSDoc.IsFix.HasValue && ((int?)wSDoc.IsFix).GetValueOrDefault() == 1)
					{
						base.ViewBag.Error = Messages.msgErrorNotActiveWareHouseMovement;
						return null;
					}
					List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSDoc_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSDoc_Lang>)list, (Func<WSDoc_Lang, CommonMultiLanguageViewModel>)((WSDoc_Lang item) => new CommonMultiLanguageViewModel
					{
						Value = item.SenderName,
						LanguageId = item.LanguageID
					})));
					list2.Add(new CommonMultiLanguageViewModel
					{
						Value = wSDoc.SenderName,
						LanguageId = result
					});
					List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSDoc_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSDoc_Lang>)list, (Func<WSDoc_Lang, CommonMultiLanguageViewModel>)((WSDoc_Lang item) => new CommonMultiLanguageViewModel
					{
						Value = item.Description,
						LanguageId = item.LanguageID
					})));
					list3.Add(new CommonMultiLanguageViewModel
					{
						Value = wSDoc.Description,
						LanguageId = result
					});
					List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSDoc_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSDoc_Lang>)list, (Func<WSDoc_Lang, CommonMultiLanguageViewModel>)((WSDoc_Lang item) => new CommonMultiLanguageViewModel
					{
						Value = item.SendAddress,
						LanguageId = item.LanguageID
					})));
					list4.Add(new CommonMultiLanguageViewModel
					{
						Value = wSDoc.SendAddress,
						LanguageId = result
					});
					List<CommonMultiLanguageViewModel> list5 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSDoc_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSDoc_Lang>)list, (Func<WSDoc_Lang, CommonMultiLanguageViewModel>)((WSDoc_Lang item) => new CommonMultiLanguageViewModel
					{
						Value = item.DriverName,
						LanguageId = item.LanguageID
					})));
					list5.Add(new CommonMultiLanguageViewModel
					{
						Value = wSDoc.DriverName,
						LanguageId = result
					});
					List<CommonMultiLanguageViewModel> list6 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSDoc_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSDoc_Lang>)list, (Func<WSDoc_Lang, CommonMultiLanguageViewModel>)((WSDoc_Lang item) => new CommonMultiLanguageViewModel
					{
						Value = item.FreightName,
						LanguageId = item.LanguageID
					})));
					list6.Add(new CommonMultiLanguageViewModel
					{
						Value = wSDoc.FreightName,
						LanguageId = result
					});
					List<CommonMultiLanguageViewModel> list7 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSDoc_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSDoc_Lang>)list, (Func<WSDoc_Lang, CommonMultiLanguageViewModel>)((WSDoc_Lang item) => new CommonMultiLanguageViewModel
					{
						Value = item.cmpTitle,
						LanguageId = item.LanguageID
					})));
					list7.Add(new CommonMultiLanguageViewModel
					{
						Value = wSDoc.cmpTitle,
						LanguageId = result
					});
					model = new WareHouseMovementLanguageViewModel
					{
						DocID = wSDoc.DocID,
						OprId = wSDoc.OprId,
						DocNumber = wSDoc.DocNumber,
						DocDate = wSDoc.DocDate,
						SenderId = wSDoc.SenderId,
						FactorNumber = wSDoc.FactorNumber,
						IsFix = wSDoc.IsFix,
						WHId = wSDoc.WHId,
						FirstRegisterUserId = wSDoc.FirstRegisterUserId,
						UserId = wSDoc.UserId,
						Month1 = wSDoc.Month1,
						FPId = wSDoc.FPId,
						RegisterDate = wSDoc.RegisterDate,
						RegisterDatePersian = wSDoc.RegisterDatePersian,
						OrderIds = wSDoc.OrderIds,
						GUId = wSDoc.GUId,
						BuyOrderId = wSDoc.BuyOrderId,
						DriverTel = wSDoc.DriverTel,
						BijakNumber = wSDoc.BijakNumber,
						CarNumber = wSDoc.CarNumber,
						DocDateTime = wSDoc.DocDateTime,
						FirstRegisterDatePersian = wSDoc.FirstRegisterDatePersian,
						FirstRegisterDate = wSDoc.FirstRegisterDate,
						WHIdI = wSDoc.WHIdI,
						CompanyId = wSDoc.CompanyId,
						CompanyPersonId = wSDoc.CompanyPersonId,
						ProjectId = wSDoc.ProjectId,
						AppType = wSDoc.AppType,
						LanguageID = wSDoc.LanguageID,
						SenderName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
						SenderName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
						Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
						Description_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
						SendAddress = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
						SendAddress_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
						DriverName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
						DriverName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
						FreightName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
						FreightName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
						cmpTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
						cmpTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))))
					};
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
		}
		return View(model);
	}

	[HttpPost]
	[LoginAuthorize]
	[ValidateAntiForgeryToken]
	[DynamicAuthorize(ControllerName = "frmWareHouseMovement", ActionName = "actRegisterSendInfo")]
	public ActionResult RegisterSendInfo(WareHouseMovementLanguageViewModel vm)
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass33_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass33_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.SenderName_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.SenderName_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.SenderName,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.Description_Lang))
		{
			list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.Description_Lang);
		}
		list2.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.Description,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.SendAddress_Lang))
		{
			list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.SendAddress_Lang);
		}
		list3.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.SendAddress,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.DriverName_Lang))
		{
			list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.DriverName_Lang);
		}
		list4.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.DriverName,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.FreightName_Lang))
		{
			list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.FreightName_Lang);
		}
		list5.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.FreightName,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.cmpTitle_Lang))
		{
			list6 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.cmpTitle_Lang);
		}
		list6.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.cmpTitle,
			LanguageId = lCID
		});
		try
		{
			if (CS_0024_003C_003E8__locals0.vm.DocID > 0 && WareHouseMovement.IsSentToLinkAccByAction(CS_0024_003C_003E8__locals0.vm.DocID))
			{
				string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
				base.ViewBag.Error = string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			if (CS_0024_003C_003E8__locals0.vm.DocDate != null)
			{
				CS_0024_003C_003E8__locals0.vm.DocDate = CS_0024_003C_003E8__locals0.vm.DocDate.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
			}
			if (!base.ModelState.IsValid)
			{
				base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
			else
			{
				_003C_003Ec__DisplayClass33_1 _003C_003Ec__DisplayClass33_ = new _003C_003Ec__DisplayClass33_1();
				_003C_003Ec__DisplayClass33_.model = new WSDoc();
				if (CS_0024_003C_003E8__locals0.vm.DocID > 0)
				{
					DbSet<WSDoc> wSDoc = _dbTbl.WSDoc;
					ParameterExpression val = Expression.Parameter(typeof(WSDoc), "c");
					_003C_003Ec__DisplayClass33_.model = Queryable.FirstOrDefault<WSDoc>((IQueryable<WSDoc>)wSDoc, Expression.Lambda<Func<WSDoc, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass33_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				_003C_003Ec__DisplayClass33_.model.UserId = UserLogin.CurrentUser.UserId;
				DateTime now = DateTime.Now;
				_003C_003Ec__DisplayClass33_.model.RegisterDate = now;
				_003C_003Ec__DisplayClass33_.model.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				_003C_003Ec__DisplayClass33_.model.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
				_003C_003Ec__DisplayClass33_.model.AppType = Configuration.AppType;
				_003C_003Ec__DisplayClass33_.model.FactorNumber = CS_0024_003C_003E8__locals0.vm.FactorNumber;
				_003C_003Ec__DisplayClass33_.model.DriverTel = CS_0024_003C_003E8__locals0.vm.DriverTel;
				_003C_003Ec__DisplayClass33_.model.BijakNumber = CS_0024_003C_003E8__locals0.vm.BijakNumber;
				_003C_003Ec__DisplayClass33_.model.CarNumber = CS_0024_003C_003E8__locals0.vm.CarNumber;
				_003C_003Ec__DisplayClass33_.model.SenderName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass33_.model.Description = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass33_.model.SendAddress = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass33_.model.DriverName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass33_.model.FreightName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass33_.model.cmpTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_dbTbl.Entry(_003C_003Ec__DisplayClass33_.model).State = EntityState.Modified;
				_dbTbl.Configuration.ValidateOnSaveEnabled = false;
				_dbTbl.SaveChanges();
				_dbTbl.Configuration.ValidateOnSaveEnabled = true;
				using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass33_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass33_2();
						CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass33_;
						CS_0024_003C_003E8__locals1.lang = enumerator.Current;
						DbSet<WSDoc_Lang> wSDoc_Lang = _dbTbl.WSDoc_Lang;
						ParameterExpression val = Expression.Parameter(typeof(WSDoc_Lang), "c");
						WSDoc_Lang wSDoc_Lang2 = Queryable.FirstOrDefault<WSDoc_Lang>((IQueryable<WSDoc_Lang>)wSDoc_Lang, Expression.Lambda<Func<WSDoc_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass33_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass33_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						if (wSDoc_Lang2 != null)
						{
							wSDoc_Lang2.SenderName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							wSDoc_Lang2.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							wSDoc_Lang2.SendAddress = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							wSDoc_Lang2.DriverName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							wSDoc_Lang2.FreightName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							wSDoc_Lang2.cmpTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							_dbTbl.Entry(wSDoc_Lang2).State = EntityState.Modified;
							_dbTbl.SaveChanges();
							continue;
						}
						wSDoc_Lang2 = new WSDoc_Lang();
						wSDoc_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
						wSDoc_Lang2.DocID = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.DocID;
						wSDoc_Lang2.SenderName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
						wSDoc_Lang2.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
						wSDoc_Lang2.SendAddress = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
						wSDoc_Lang2.DriverName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
						wSDoc_Lang2.FreightName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
						wSDoc_Lang2.cmpTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
						_dbTbl.WSDoc_Lang.Add(wSDoc_Lang2);
						_dbTbl.SaveChanges();
					}
				}
				base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
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
		return View(CS_0024_003C_003E8__locals0.vm);
	}

	[AjaxOnly]
	public JsonResult GetdVerifierTitles()
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
			List<WSspSelectDocVerifiers_Result> list2 = Enumerable.ToList<WSspSelectDocVerifiers_Result>((IEnumerable<WSspSelectDocVerifiers_Result>)_dbI.WSspSelectDocVerifiers(UserLogin.CurrentUser.UserId, lCID, result, result2));
			list.AddRange(Enumerable.Select<WSspSelectDocVerifiers_Result, SelectListItem>((IEnumerable<WSspSelectDocVerifiers_Result>)list2, (Func<WSspSelectDocVerifiers_Result, SelectListItem>)((WSspSelectDocVerifiers_Result item) => new SelectListItem
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
			List<WSspSelectVerificationWorkFlowWithObjectType_Result> list2 = Enumerable.ToList<WSspSelectVerificationWorkFlowWithObjectType_Result>((IEnumerable<WSspSelectVerificationWorkFlowWithObjectType_Result>)_db.WSspSelectVerificationWorkFlowWithObjectType(60, lCID, result));
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
}

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

namespace CRMIdeal.Areas.BuyOrders.Controllers;

public class HomeController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass19_0
	{
		public int id;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass31_0
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
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass32_0
	{
		public CRMspSelectCompanyById_Result cmp;

		public WSBuyOrderLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__26;

		public Func<Languages, bool> _003C_003E9__64;

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

		internal bool _003CInsertEdit_003Eb__26(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__64(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass32_1
	{
		public WSBuyOrder model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass32_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass32_1 CS_0024_003C_003E8__locals1;

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
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass42_0
	{
		public int bordItemId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass43_0
	{
		public int bordItemId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass46_0
	{
		public int defSettingId;

		public int currLangID;

		internal bool _003CGetBuyOrderDefaultSetting_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetBuyOrderDefaultSetting_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetBuyOrderDefaultSetting_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetBuyOrderDefaultSetting_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetBuyOrderDefaultSetting_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetBuyOrderDefaultSetting_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetBuyOrderDefaultSetting_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetBuyOrderDefaultSetting_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetBuyOrderDefaultSetting_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetBuyOrderDefaultSetting_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetBuyOrderDefaultSetting_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetBuyOrderDefaultSetting_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetBuyOrderDefaultSetting_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetBuyOrderDefaultSetting_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetBuyOrderDefaultSetting_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMLinkSpEntities _dbLink = new CRMLinkSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actbordBuyOrder")]
	public ActionResult Index(int? id = null, bool? isOpenNew = null, bool? fromIndicator = null, string parameters = "", int? companyId = null, int? productId = null, string intMsgInfo = "", int buyOrderId = 0, int? selWorkflowStepId = null)
	{
		if (!string.IsNullOrWhiteSpace(intMsgInfo))
		{
			base.ViewBag.IntMsgInfo = intMsgInfo;
		}
		base.ViewBag.Parameters = parameters;
		base.ViewBag.SendedBuyOrderId = 0;
		base.ViewBag.CompanyId = 0;
		base.ViewBag.FromSearchId = false;
		if (id.HasValue)
		{
			base.ViewBag.SendedBuyOrderId = id;
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
					CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_dbLink.CRMspSelectLinkAccSetting(0, "PreUsedHintSetting", lCID, result, 1, 0, "BordPreUsedHint"));
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
		base.ViewBag.BuyOrderId = buyOrderId;
		base.ViewBag.SelectedWorkflowStepId = selWorkflowStepId;
		return View();
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actbordBuyOrder")]
	public JsonResult GetBuyOrder(int bordCurrentId, string fromDate, string toDate, long bordNumber, int oprType = 0, int? companyId = null, int? userId = null, int? buyOrderId = null)
	{
		//IL_0c81: Unknown result type (might be due to invalid IL or missing references)
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
		oprType = 0;
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
		CurrentBuyOrderViewModel currentBuyOrderViewModel = new CurrentBuyOrderViewModel();
		currentBuyOrderViewModel.IsDecimal = false;
		currentBuyOrderViewModel.FooterData = new WSfnReturnBuyOrderSumFooter_Result();
		if (!userId.HasValue)
		{
			userId = UserLogin.CurrentUser.UserId;
		}
		if (!buyOrderId.HasValue)
		{
			buyOrderId = 0;
		}
		currentBuyOrderViewModel.FooterPay = new WSspReturnSumBuyOrderPay_Result();
		currentBuyOrderViewModel.bordLinkAccBuyOrderNumber = Labels.BordShowLinkAccBuyOrderNumber + ":";
		currentBuyOrderViewModel.bordLinkAccVoucherNumber = Labels.BordShowLinkAccVoucherNumber + ":";
		currentBuyOrderViewModel.bordLinkAccBuyOrderIdStr = Labels.BordShowLinkAccBuyOrderIdStr + ":";
		currentBuyOrderViewModel.bordLinkAccFirstTransferDateStr = Labels.lblLinkAccFirstTransferDate + ":";
		currentBuyOrderViewModel.bordLinkAccLastTransferDateStr = Labels.lblLinkAccLastTransferDate + ":";
		currentBuyOrderViewModel.LastVerificationStep = new WSspSelectVerificationWorkFlowStepLast_Result();
		currentBuyOrderViewModel.OrderList = new List<WSspReturnOrderFromBuyOrder_Result>();
		currentBuyOrderViewModel.bordLinkAccData = "";
		currentBuyOrderViewModel.IsSentToLinkAcc = false;
		try
		{
			List<WSspSelectBuyOrders_Result> list = Enumerable.ToList<WSspSelectBuyOrders_Result>((IEnumerable<WSspSelectBuyOrders_Result>)_db.WSspSelectBuyOrders(fromDate, toDate, userId, oprType, buyOrderId, bordNumber, lCID, result, value, now, result2));
			if (Enumerable.Any<WSspSelectBuyOrders_Result>((IEnumerable<WSspSelectBuyOrders_Result>)list))
			{
				currentBuyOrderViewModel.IsFind = true;
				currentBuyOrderViewModel.Message = "";
				currentBuyOrderViewModel.FromDate = fromDate;
				currentBuyOrderViewModel.ToDate = toDate;
				currentBuyOrderViewModel.BuyOrderNextId = -1;
				currentBuyOrderViewModel.BuyOrderPreviousId = -1;
				currentBuyOrderViewModel.CompanyId = -1;
				currentBuyOrderViewModel.BuyOrderFirstId = -1;
				currentBuyOrderViewModel.BuyOrderLastId = -1;
				currentBuyOrderViewModel.RemainOrdAmount = default(decimal);
				currentBuyOrderViewModel.SumBordPayAmount = default(decimal);
				currentBuyOrderViewModel.RemainOlderordsAmount = default(decimal);
				currentBuyOrderViewModel.WareHouseCount = 0;
				if (list.Count == 1)
				{
					currentBuyOrderViewModel.BuyOrderFirstId = -1;
					currentBuyOrderViewModel.BuyOrderLastId = -1;
				}
				else
				{
					currentBuyOrderViewModel.BuyOrderFirstId = Enumerable.FirstOrDefault<WSspSelectBuyOrders_Result>((IEnumerable<WSspSelectBuyOrders_Result>)list).BuyOrderID;
					currentBuyOrderViewModel.BuyOrderLastId = Enumerable.LastOrDefault<WSspSelectBuyOrders_Result>((IEnumerable<WSspSelectBuyOrders_Result>)list).BuyOrderID;
				}
				WSspSelectBuyOrders_Result wSspSelectBuyOrders_Result = ((bordCurrentId <= 0) ? Enumerable.LastOrDefault<WSspSelectBuyOrders_Result>((IEnumerable<WSspSelectBuyOrders_Result>)list) : list.Find((WSspSelectBuyOrders_Result c) => c.BuyOrderID == bordCurrentId));
				if (wSspSelectBuyOrders_Result != null)
				{
					if (BuyOrder.IsEditAfterFix(wSspSelectBuyOrders_Result.bordEditAfterFixInfoJs, wSspSelectBuyOrders_Result.BuyOrderID, 1))
					{
						wSspSelectBuyOrders_Result.bordIsFixed = false;
					}
					if (!string.IsNullOrWhiteSpace((wSspSelectBuyOrders_Result.bordEditAfterFixInfoJs ?? "").Replace("[]", "")))
					{
						List<EditAfterFixInfoViewModel> list2 = JsonConvert.DeserializeObject<List<EditAfterFixInfoViewModel>>(wSspSelectBuyOrders_Result.bordEditAfterFixInfoJs);
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
							wSspSelectBuyOrders_Result.bordEditAfterFixInfoJs = JsonConvert.SerializeObject(list2);
						}
					}
					wSspSelectBuyOrders_Result.bordDateTime = wSspSelectBuyOrders_Result.bordDateTime;
					wSspSelectBuyOrders_Result.bordDate = (wSspSelectBuyOrders_Result.bordDateTime.HasValue ? wSspSelectBuyOrders_Result.bordDateTime.Value.ToString("yyyy/MM/dd") : null);
					wSspSelectBuyOrders_Result.bordVerifiedRegisterDatePersian = (wSspSelectBuyOrders_Result.bordVerifiedRegisterDate.HasValue ? wSspSelectBuyOrders_Result.bordVerifiedRegisterDate.Value.ToString("yyyyMMdd") : null);
					wSspSelectBuyOrders_Result.bordOrderDate = (wSspSelectBuyOrders_Result.bordOrderDateTime.HasValue ? wSspSelectBuyOrders_Result.bordOrderDateTime.Value.ToString("yyyyMMdd") : null);
					wSspSelectBuyOrders_Result.bordImportDate = (wSspSelectBuyOrders_Result.bordImportDateTime.HasValue ? wSspSelectBuyOrders_Result.bordImportDateTime.Value.ToString("yyyy/MM/dd HH:mm:ss") : null);
					_ = wSspSelectBuyOrders_Result.RegisterDate;
					wSspSelectBuyOrders_Result.RegisterDatePersian = wSspSelectBuyOrders_Result.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
					if (string.IsNullOrEmpty(wSspSelectBuyOrders_Result.AppType))
					{
						wSspSelectBuyOrders_Result.AppType = Configuration.AppType;
					}
					wSspSelectBuyOrders_Result.AppType = Configuration.GetAppType(wSspSelectBuyOrders_Result.AppType);
					wSspSelectBuyOrders_Result.bordTaxClearedDatePersian = (wSspSelectBuyOrders_Result.bordTaxClearedDate.HasValue ? wSspSelectBuyOrders_Result.bordTaxClearedDate.Value.ToString("yyyy/MM/dd") : null);
					wSspSelectBuyOrders_Result.bordDeliveryDatePersian = (wSspSelectBuyOrders_Result.bordDeliveryDate.HasValue ? wSspSelectBuyOrders_Result.bordDeliveryDate.Value.ToString("yyyy/MM/dd HH:mm") : null);
					wSspSelectBuyOrders_Result.bordSupplierDeliveryDatePersian = (wSspSelectBuyOrders_Result.bordSupplierDeliveryDate.HasValue ? wSspSelectBuyOrders_Result.bordSupplierDeliveryDate.Value.ToString("yyyy/MM/dd HH:mm") : null);
					wSspSelectBuyOrders_Result.bordFinalDeliveryDatePersian = (wSspSelectBuyOrders_Result.bordFinalDeliveryDate.HasValue ? wSspSelectBuyOrders_Result.bordFinalDeliveryDate.Value.ToString("yyyy/MM/dd HH:mm") : null);
					if (!string.IsNullOrEmpty(wSspSelectBuyOrders_Result.bordVerifierUser) && wSspSelectBuyOrders_Result.bordVerifiedRegisterDate.HasValue)
					{
						wSspSelectBuyOrders_Result.bordVerifierUser += (wSspSelectBuyOrders_Result.bordVerifiedRegisterDate.HasValue ? (" (" + wSspSelectBuyOrders_Result.bordVerifiedRegisterDate.Value.ToString("yyyy/MM/dd HH:mm") + ")") : "");
					}
					currentBuyOrderViewModel.BuyOrder = wSspSelectBuyOrders_Result;
					currentBuyOrderViewModel.BuyOrderNumber = wSspSelectBuyOrders_Result.bordNumber;
					currentBuyOrderViewModel.BuyOrderCurrentId = wSspSelectBuyOrders_Result.BuyOrderID;
					if (list.Count == 1)
					{
						currentBuyOrderViewModel.BuyOrderNextId = -1;
						currentBuyOrderViewModel.BuyOrderPreviousId = -1;
					}
					else
					{
						WSspSelectBuyOrders_Result next = Lists.GetNext(list, wSspSelectBuyOrders_Result);
						if (next != null)
						{
							currentBuyOrderViewModel.BuyOrderNextId = next.BuyOrderID;
						}
						WSspSelectBuyOrders_Result previous = Lists.GetPrevious(list, wSspSelectBuyOrders_Result);
						if (previous != null)
						{
							currentBuyOrderViewModel.BuyOrderPreviousId = previous.BuyOrderID;
						}
					}
					currentBuyOrderViewModel.BuyOrderItemsList = GetBuyOrderItemsProducts(wSspSelectBuyOrders_Result.BuyOrderID);
					WSfnReturnBuyOrderSumFooter_Result footerData = Enumerable.FirstOrDefault<WSfnReturnBuyOrderSumFooter_Result>((IEnumerable<WSfnReturnBuyOrderSumFooter_Result>)Enumerable.ToList<WSfnReturnBuyOrderSumFooter_Result>((IEnumerable<WSfnReturnBuyOrderSumFooter_Result>)_db.WSfnReturnBuyOrderSumFooter(wSspSelectBuyOrders_Result.BuyOrderID)));
					currentBuyOrderViewModel.FooterData = footerData;
					List<WSspReturnDocForBuyOrder_Result> list3 = Enumerable.ToList<WSspReturnDocForBuyOrder_Result>((IEnumerable<WSspReturnDocForBuyOrder_Result>)_db.WSspReturnDocForBuyOrder(wSspSelectBuyOrders_Result.BuyOrderID, lCID, result));
					currentBuyOrderViewModel.DocList = new List<WSspReturnDocForBuyOrder_Result>();
					currentBuyOrderViewModel.DocList = list3;
					WSspReturnDocForBuyOrder_Result wSspReturnDocForBuyOrder_Result = new WSspReturnDocForBuyOrder_Result();
					if (list3 != null)
					{
						wSspReturnDocForBuyOrder_Result = Enumerable.LastOrDefault<WSspReturnDocForBuyOrder_Result>((IEnumerable<WSspReturnDocForBuyOrder_Result>)list3);
					}
					if (wSspReturnDocForBuyOrder_Result != null)
					{
						currentBuyOrderViewModel.DocInformation = wSspReturnDocForBuyOrder_Result.Info;
						currentBuyOrderViewModel.DocId = wSspReturnDocForBuyOrder_Result.DocID;
						currentBuyOrderViewModel.OprType = wSspReturnDocForBuyOrder_Result.OprType;
					}
					WSspReturnSumBuyOrderPay_Result wSspReturnSumBuyOrderPay_Result = Enumerable.FirstOrDefault<WSspReturnSumBuyOrderPay_Result>((IEnumerable<WSspReturnSumBuyOrderPay_Result>)Enumerable.ToList<WSspReturnSumBuyOrderPay_Result>((IEnumerable<WSspReturnSumBuyOrderPay_Result>)_db.WSspReturnSumBuyOrderPay(wSspSelectBuyOrders_Result.BuyOrderID)));
					if (wSspReturnSumBuyOrderPay_Result != null)
					{
						currentBuyOrderViewModel.RemainOrdAmount = wSspReturnSumBuyOrderPay_Result.RemainordAmount;
						currentBuyOrderViewModel.SumBordPayAmount = wSspReturnSumBuyOrderPay_Result.sumbordpayAmount;
						currentBuyOrderViewModel.RemainOlderordsAmount = wSspReturnSumBuyOrderPay_Result.RemainOlderordsAmount;
						currentBuyOrderViewModel.FooterPay = wSspReturnSumBuyOrderPay_Result;
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
					if (wSspSelectBuyOrders_Result.bordLinkAccCodeId.GetValueOrDefault() != 0 || !string.IsNullOrWhiteSpace(wSspSelectBuyOrders_Result.bordLinkAccCode) || wSspSelectBuyOrders_Result.bordLinkAccBuyOrderId.GetValueOrDefault() != 0 || !string.IsNullOrWhiteSpace(wSspSelectBuyOrders_Result.bordLinkAccBuyOrderNumber) || wSspSelectBuyOrders_Result.bordLinkAccVoucherId.GetValueOrDefault() != 0 || !string.IsNullOrWhiteSpace(wSspSelectBuyOrders_Result.bordLinkAccVoucherNumber) || !string.IsNullOrWhiteSpace(wSspSelectBuyOrders_Result.bordLinkAccBuyOrderIdStr) || (!string.IsNullOrWhiteSpace(wSspSelectBuyOrders_Result.bordLinkAccData) && wSspSelectBuyOrders_Result.bordLinkAccData != "[]"))
					{
						currentBuyOrderViewModel.IsSentToLinkAcc = true;
					}
					currentBuyOrderViewModel.bordLinkAccBuyOrderNumber = Labels.BordShowLinkAccBuyOrderNumber + ":" + wSspSelectBuyOrders_Result.bordLinkAccBuyOrderNumber;
					currentBuyOrderViewModel.bordLinkAccVoucherNumber = Labels.BordShowLinkAccVoucherNumber + ":" + wSspSelectBuyOrders_Result.bordLinkAccVoucherNumber;
					currentBuyOrderViewModel.bordLinkAccBuyOrderIdStr = Labels.BordShowLinkAccBuyOrderIdStr + ": " + ((!string.IsNullOrWhiteSpace(wSspSelectBuyOrders_Result.bordLinkAccBuyOrderIdStr)) ? wSspSelectBuyOrders_Result.bordLinkAccBuyOrderIdStr : (wSspSelectBuyOrders_Result.bordLinkAccBuyOrderId.HasValue ? wSspSelectBuyOrders_Result.bordLinkAccBuyOrderId.ToString() : ""));
					currentBuyOrderViewModel.bordLinkAccFirstTransferDateStr = Labels.lblLinkAccFirstTransferDate + ":" + (wSspSelectBuyOrders_Result.bordLinkAccFirstTransferDate.HasValue ? ("<span class='span-transfer-date-to-acc'>" + wSspSelectBuyOrders_Result.bordLinkAccFirstTransferDate.Value.ToString("yyyy/MM/dd HH:mm:ss") + "</span>") : "");
					currentBuyOrderViewModel.bordLinkAccLastTransferDateStr = Labels.lblLinkAccLastTransferDate + ":" + (wSspSelectBuyOrders_Result.bordLinkAccLastTransferDate.HasValue ? ("<span class='span-transfer-date-to-acc'>" + wSspSelectBuyOrders_Result.bordLinkAccLastTransferDate.Value.ToString("yyyy/MM/dd HH:mm:ss") + "</span>") : "");
					currentBuyOrderViewModel.bordLinkAccData = wSspSelectBuyOrders_Result.bordLinkAccData ?? "";
					if (num == 1)
					{
						List<CRMspSelectLinkAccSettingDBIsActive_Result> linkAccSettingDBList = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDBList(1);
						List<BordLinkAccDataViewModel> list4 = new List<BordLinkAccDataViewModel>();
						if (!string.IsNullOrWhiteSpace(currentBuyOrderViewModel.bordLinkAccData))
						{
							foreach (BordLinkAccDataViewModel item2 in new JavaScriptSerializer().Deserialize<List<BordLinkAccDataViewModel>>(currentBuyOrderViewModel.bordLinkAccData))
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
										item2.NumberWithLbl = Labels.BordShowLinkAccBuyOrderNumber + ": " + item2.Number;
										item2.IdWithLbl = Labels.BordShowLinkAccBuyOrderIdStr + ": " + item2.Id;
										item2.VoucherNumberWithLbl = Labels.BordShowLinkAccVoucherNumber + ": ";
										item2.FTDateWithLbl = Labels.lblLinkAccFirstTransferDate + ":" + (item2.FTDate.HasValue ? ("<span class='span-transfer-date-to-acc'>" + item2.FTDate.Value.ToString("yyyy/MM/dd HH:mm:ss") + "</span>") : "");
										item2.LTDateWithLbl = Labels.lblLinkAccLastTransferDate + ":" + (item2.LTDate.HasValue ? ("<span class='span-transfer-date-to-acc'>" + item2.LTDate.Value.ToString("yyyy/MM/dd HH:mm:ss") + "</span>") : "");
										list4.Add(item2);
									}
								}
							}
						}
						currentBuyOrderViewModel.bordLinkAccData = "";
						if (list4 != null && Enumerable.Any<BordLinkAccDataViewModel>((IEnumerable<BordLinkAccDataViewModel>)list4))
						{
							currentBuyOrderViewModel.bordLinkAccData = JsonConvert.SerializeObject(Enumerable.ToList<BordLinkAccDataViewModel>((IEnumerable<BordLinkAccDataViewModel>)list4));
						}
					}
					List<int?> list5 = Enumerable.ToList<int?>((IEnumerable<int?>)_dbI.WSspReturnBuyOrderItemsWareHouseCnt(wSspSelectBuyOrders_Result.BuyOrderID));
					if (list5 != null)
					{
						int result3 = 0;
						int.TryParse(list5.Count.ToString(), out result3);
						currentBuyOrderViewModel.WareHouseCount = result3;
					}
					bool result4 = false;
					WSspSelectCurrencyUnitsWithId_Result wSspSelectCurrencyUnitsWithId_Result = Enumerable.FirstOrDefault<WSspSelectCurrencyUnitsWithId_Result>((IEnumerable<WSspSelectCurrencyUnitsWithId_Result>)_db.WSspSelectCurrencyUnitsWithId(wSspSelectBuyOrders_Result.bordCurrencyUnitId, lCID, result));
					if (wSspSelectCurrencyUnitsWithId_Result != null)
					{
						bool.TryParse(wSspSelectCurrencyUnitsWithId_Result.IsDecimal.ToString(), out result4);
					}
					currentBuyOrderViewModel.IsDecimal = result4;
					if (wSspSelectBuyOrders_Result.bordVerificationWorkFlowId.GetValueOrDefault() != 0)
					{
						currentBuyOrderViewModel.LastVerificationStep = Enumerable.FirstOrDefault<WSspSelectVerificationWorkFlowStepLast_Result>((IEnumerable<WSspSelectVerificationWorkFlowStepLast_Result>)_db.WSspSelectVerificationWorkFlowStepLast(wSspSelectBuyOrders_Result.BuyOrderID, 40, wSspSelectBuyOrders_Result.bordVerificationWorkFlowId, 0, lCID, result));
					}
					currentBuyOrderViewModel.OrderList = Enumerable.ToList<WSspReturnOrderFromBuyOrder_Result>((IEnumerable<WSspReturnOrderFromBuyOrder_Result>)_dbII.WSspReturnOrderFromBuyOrder(wSspSelectBuyOrders_Result.BuyOrderID, lCID, result));
					if (currentBuyOrderViewModel.OrderList == null)
					{
						currentBuyOrderViewModel.OrderList = new List<WSspReturnOrderFromBuyOrder_Result>();
					}
				}
				else
				{
					currentBuyOrderViewModel.IsFind = false;
					currentBuyOrderViewModel.Message = Messages.ErrorNotFound;
					currentBuyOrderViewModel.FromDate = fromDate;
					currentBuyOrderViewModel.ToDate = toDate;
					currentBuyOrderViewModel.BuyOrder = null;
					currentBuyOrderViewModel.BuyOrderCurrentId = -1;
					currentBuyOrderViewModel.BuyOrderNextId = -1;
					currentBuyOrderViewModel.BuyOrderNumber = -1L;
					currentBuyOrderViewModel.BuyOrderPreviousId = -1;
					currentBuyOrderViewModel.CompanyId = -1;
					currentBuyOrderViewModel.BuyOrderFirstId = -1;
					currentBuyOrderViewModel.BuyOrderLastId = -1;
					currentBuyOrderViewModel.RemainOrdAmount = default(decimal);
					currentBuyOrderViewModel.SumBordPayAmount = default(decimal);
					currentBuyOrderViewModel.RemainOlderordsAmount = default(decimal);
					currentBuyOrderViewModel.WareHouseCount = 0;
				}
			}
			else
			{
				currentBuyOrderViewModel.IsFind = false;
				currentBuyOrderViewModel.Message = Messages.ErrorNotFound;
				currentBuyOrderViewModel.FromDate = fromDate;
				currentBuyOrderViewModel.ToDate = toDate;
				currentBuyOrderViewModel.BuyOrder = null;
				currentBuyOrderViewModel.BuyOrderCurrentId = -1;
				currentBuyOrderViewModel.BuyOrderNextId = -1;
				currentBuyOrderViewModel.BuyOrderNumber = -1L;
				currentBuyOrderViewModel.BuyOrderPreviousId = -1;
				currentBuyOrderViewModel.CompanyId = -1;
				currentBuyOrderViewModel.BuyOrderFirstId = -1;
				currentBuyOrderViewModel.BuyOrderLastId = -1;
				currentBuyOrderViewModel.RemainOrdAmount = default(decimal);
				currentBuyOrderViewModel.SumBordPayAmount = default(decimal);
				currentBuyOrderViewModel.RemainOlderordsAmount = default(decimal);
				currentBuyOrderViewModel.WareHouseCount = 0;
			}
		}
		catch (DbEntityValidationException ex)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
			currentBuyOrderViewModel.Message = Messages.frmErrorMessage + "<br />" + ((Exception)(object)ex).Message;
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			currentBuyOrderViewModel.Message = Messages.frmErrorMessage + "<br />" + ex2.Message;
		}
		JsonResult jsonResult = Json(currentBuyOrderViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<WSspSelectBuyOrderItems_Result> GetBuyOrderItemsProducts(int id)
	{
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		List<WSspSelectBuyOrderItems_Result> list = new List<WSspSelectBuyOrderItems_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			list = Enumerable.ToList<WSspSelectBuyOrderItems_Result>((IEnumerable<WSspSelectBuyOrderItems_Result>)_db.WSspSelectBuyOrderItems(id, lCID, result));
			if (list != null && Enumerable.Any<WSspSelectBuyOrderItems_Result>((IEnumerable<WSspSelectBuyOrderItems_Result>)list))
			{
				foreach (WSspSelectBuyOrderItems_Result item in list)
				{
					if (!string.IsNullOrWhiteSpace(item.bordIStockSupply))
					{
						List<BuyOrderItemsStockSupplyViewModel> list2 = new JavaScriptSerializer().Deserialize<List<BuyOrderItemsStockSupplyViewModel>>(item.bordIStockSupply);
						if (list2 != null && Enumerable.Any<BuyOrderItemsStockSupplyViewModel>((IEnumerable<BuyOrderItemsStockSupplyViewModel>)list2))
						{
							foreach (BuyOrderItemsStockSupplyViewModel item2 in list2)
							{
								item2.stsupDate = (item2.stsupDateTime.HasValue ? item2.stsupDateTime.Value.ToString("yyyy/MM/dd") : "");
								item2.stsupInfo = "(" + item2.stsupNumber.GetValueOrDefault() + " - " + item2.stsupDate + ")";
							}
							item.bordIStockSupply = JsonConvert.SerializeObject(Enumerable.ToList<BuyOrderItemsStockSupplyViewModel>((IEnumerable<BuyOrderItemsStockSupplyViewModel>)list2));
						}
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

	public ActionResult _PartialList(int bordCurrentId, int companyId, int bordNumber, string fromDate, string toDate, int? userId = null, int? borderId = null)
	{
		BuyOrderListViewModel buyOrderListViewModel = new BuyOrderListViewModel
		{
			userId = userId,
			companyId = companyId,
			borderId = borderId,
			toDate = toDate,
			bordNumber = bordNumber,
			fromDate = fromDate,
			bordCurrentId = bordCurrentId
		};
		base.ViewBag.BuyOrderList = buyOrderListViewModel;
		return PartialView();
	}

	public ActionResult _PartialList_Read([DataSourceRequest] DataSourceRequest request, int bordCurrentId, int companyId, int bordNumber, string fromDate, string toDate, int? userId = null, int? borderId = null)
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
		if (!borderId.HasValue)
		{
			borderId = 0;
		}
		int value2 = 0;
		List<WSspSelectBuyOrders_Result> list = Enumerable.ToList<WSspSelectBuyOrders_Result>(Enumerable.Reverse<WSspSelectBuyOrders_Result>((IEnumerable<WSspSelectBuyOrders_Result>)_db.WSspSelectBuyOrders(fromDate, toDate, userId, value2, borderId, bordNumber, lCID, result, value, now, result2)));
		foreach (WSspSelectBuyOrders_Result item in list)
		{
			item.bordDate = (item.bordDateTime.HasValue ? item.bordDateTime.Value.ToString("yyyy/MM/dd") : item.bordDate);
			item.bordOrderDate = (item.bordOrderDateTime.HasValue ? item.bordOrderDateTime.Value.ToString("yyyy/MM/dd") : item.bordOrderDate);
			if (!string.IsNullOrWhiteSpace(item.bordCompany))
			{
				item.bordCompany = item.bordCompany + " - " + item.bordPerson;
			}
		}
		JsonResult jsonResult = Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public ActionResult BuyOrdItemSerials_Read([DataSourceRequest] DataSourceRequest request, int buyOrderItemId)
	{
		List<WSspSelectBuyOrderItemSerials_Result> buyOrderItemSerials = GetBuyOrderItemSerials(buyOrderItemId);
		JsonResult jsonResult = Json(((IEnumerable)buyOrderItemSerials).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<WSspSelectBuyOrderItemSerials_Result> GetBuyOrderItemSerials(int buyOrderItemId)
	{
		List<WSspSelectBuyOrderItemSerials_Result> list = new List<WSspSelectBuyOrderItemSerials_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			list = Enumerable.ToList<WSspSelectBuyOrderItemSerials_Result>((IEnumerable<WSspSelectBuyOrderItemSerials_Result>)_db.WSspSelectBuyOrderItemSerials(buyOrderItemId, lCID, result));
			foreach (WSspSelectBuyOrderItemSerials_Result item in list)
			{
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
	[DynamicAuthorize(ControllerName = "frmBuyOrder", ActionName = "actDeleteItemSerial")]
	public string RemoveItemSerials(int orderItemSerialId, int ordId)
	{
		string result = "";
		try
		{
			if (BuyOrder.IsFixed(ordId))
			{
				return Messages.msgErrorNotActiveBOrd;
			}
			if (orderItemSerialId > 0)
			{
				if (_dbTbl.WSBuyOrderItemSerials.Find(orderItemSerialId) != null)
				{
					try
					{
						mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)Enumerable.ToList<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteWSBuyOrderItemSerials(orderItemSerialId)));
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
	[DynamicAuthorize(ControllerName = "frmBuyOrder", ActionName = "actDeleteAllSerials")]
	public string RemoveAllItemSerials(int ordItemId, int ordId)
	{
		string result = "1";
		try
		{
			if (BuyOrder.IsFixed(ordId))
			{
				return Messages.msgErrorNotActiveBOrd;
			}
			if (ordItemId > 0)
			{
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)Enumerable.ToList<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteBuyOrderItemSerialsByBuyOrderItemId(ordItemId)));
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
	[DynamicAuthorize(ControllerName = "frmBuyOrder", ActionName = "actCopypreoItem")]
	public string CopyBordItem(int bordId)
	{
		string text = "";
		try
		{
			if (!UserLogin.IsUserAccess("frmBuyOrder", "actCopypreoItem", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			if (bordId > 0)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				_ = Thread.CurrentThread.CurrentCulture.LCID;
				string firstRegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
				return (_db.WSspTmpUserItemCopy("BuyOrder", bordId, UserLogin.CurrentUser.UserId, Configuration.AppType, result, firstRegisterDatePersian) > 0) ? "1" : Messages.msgErrorRunFunction;
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
	[DynamicAuthorize(ControllerName = "frmBuyOrder", ActionName = "actPastpreoItem")]
	public string PasteBordItem(int bordId)
	{
		string result = "";
		try
		{
			if (!UserLogin.IsUserAccess("frmBuyOrder", "actPastpreoItem", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			if (bordId > 0)
			{
				if (BuyOrder.IsFixed(bordId))
				{
					return Messages.msgErrorNotActiveBOrd;
				}
				if (BuyOrder.IsSentToLinkAccByAction(bordId))
				{
					string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
					return string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
				}
				DateTime now = DateTime.Now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value = short.Parse(now.ToString("MM", new PersianCulture()));
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
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.WSspTmpUserItemPast("BuyOrder", bordId, UserLogin.CurrentUser.UserId, id, value, registerDatePersian, Configuration.AppType, result2, centerId));
				if (mct_Result != null && mct_Result.Result > 0)
				{
					result = (BuyOrder.CalcAndSetOrderAmounts(bordId) ? "1" : Messages.msgErrorInCalculation);
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
	public string VerifyOrder(int bordId)
	{
		string text = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		int result = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
		}
		if (!UserLogin.IsUserAccess("frmBuyOrder", "actVerifyOrder", currentUser))
		{
			return Messages.ErrorNotAccess;
		}
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (bordId > 0)
			{
				string text2 = BuyOrder.CheckBeforeVerification(bordId);
				if (!string.IsNullOrWhiteSpace(text2))
				{
					return text2;
				}
				string registerDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
				if (_db.WSspBuyOrderVerify(bordId, currentUser.UserId, registerDatePersian) > 0)
				{
					string text3 = "";
					string text4 = "";
					if (UserLogin.IsUserAccess("frmBuyOrder", "actIssueDocAuto", currentUser) && bordId > 0 && VersionBuyer.WareHouse)
					{
						string refResult = "";
						bool flag = BuyOrder.AutoIssueDocFromBord(bordId, currentUser.UserId, ref refResult, 0, result);
						if (!string.IsNullOrWhiteSpace(refResult))
						{
							if (flag)
							{
								text4 = refResult;
							}
							else
							{
								text3 = refResult;
							}
						}
					}
					text = "1|" + UserLogin.CurrentUser.UserId + "|" + UserLogin.CurrentUser.FullName + " (" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + ")";
					if (!string.IsNullOrWhiteSpace(text3))
					{
						text = text + "|doc-1^,^" + text3;
					}
					else if (!string.IsNullOrWhiteSpace(text4))
					{
						text = text + "|doc1^,^" + text4;
					}
				}
				else
				{
					text = Messages.msgErrorRunFunction;
				}
			}
			else
			{
				text = Messages.msgErrorNotActiveItem;
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
	public string ExitFromIsFixOrder(int bordId)
	{
		string text = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmBuyOrder", "actExitFromIsFix", currentUser))
		{
			return Messages.ErrorNotAccess;
		}
		try
		{
			if (bordId > 0)
			{
				string registerDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
				return (_db.WSspBuyOrderVerifyExit(bordId, currentUser.UserId, registerDatePersian) > 0) ? "1" : Messages.msgErrorRunFunction;
			}
			return Messages.msgErrorNotActiveItem;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.frmErrorMessage;
		}
	}

	public ActionResult OrderFiles_Read([DataSourceRequest] DataSourceRequest request, int borderId, int companyId, int projectId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectFilesDirectory_Result> list = Files.SelectFilesDirectory(companyId.ToString(), "", projectId.ToString(), "30", borderId.ToString(), "0", "0", false);
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
	[DynamicAuthorize(ControllerName = "frmBuyOrder", ActionName = "actDelete")]
	public string Delete(int id)
	{
		_003C_003Ec__DisplayClass19_0 _003C_003Ec__DisplayClass19_ = new _003C_003Ec__DisplayClass19_0();
		_003C_003Ec__DisplayClass19_.id = id;
		string result = "";
		try
		{
			DbSet<WSBuyOrder> wSBuyOrder = _dbTbl.WSBuyOrder;
			ParameterExpression val = Expression.Parameter(typeof(WSBuyOrder), "c");
			WSBuyOrder wSBuyOrder2 = Queryable.FirstOrDefault<WSBuyOrder>((IQueryable<WSBuyOrder>)wSBuyOrder, Expression.Lambda<Func<WSBuyOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass19_, typeof(_003C_003Ec__DisplayClass19_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (wSBuyOrder2 != null)
			{
				try
				{
					if (BuyOrder.IsSentToLinkAccByAction(wSBuyOrder2.BuyOrderID))
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
					List<CRMspSelectFilesDirectory_Result> list = Files.SelectFilesDirectory(wSBuyOrder2.bordCompanyId.ToString(), "", wSBuyOrder2.bordProjectId.ToString(), "30", wSBuyOrder2.BuyOrderID.ToString(), "0", "0", false);
					if (list != null && Enumerable.Any<CRMspSelectFilesDirectory_Result>((IEnumerable<CRMspSelectFilesDirectory_Result>)list) && list != null && Enumerable.Any<CRMspSelectFilesDirectory_Result>((IEnumerable<CRMspSelectFilesDirectory_Result>)list))
					{
						return Messages.msgErrorItemHasFiles;
					}
					_db.CRMspDyDeleteFormFieldMasterValuesBySysPart(_003C_003Ec__DisplayClass19_.id, "bord");
					mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)Enumerable.ToList<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteWSBuyOrder(_003C_003Ec__DisplayClass19_.id)));
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
	[DynamicAuthorize(ControllerName = "frmBuyOrder", ActionName = "actRemoveProductWithLinked")]
	public string RemoveProductWithLinked(int bordId, int bordItemId)
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
			if (!UserLogin.IsUserAccess("frmBuyOrder", "actRemoveProductWithLinked", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			if (BuyOrder.IsFixed(bordId))
			{
				return Messages.msgErrorNotActiveBOrd;
			}
			if (BuyOrder.IsSentToLinkAccByAction(bordId))
			{
				string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
				return string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
			}
			if (bordItemId > 0)
			{
				try
				{
					mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.WSspDeleteBuyOrderItemWithLinkedPrd(bordId, bordItemId));
					if (mct_I_Result != null && mct_I_Result.Result > 0)
					{
						result = (BuyOrder.CalcAndSetOrderAmounts(bordId) ? "1" : Messages.msgErrorInCalculation);
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
	public JsonResult GetDocInfo(int ordId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspReturnDocForBuyOrder_Result> list = new List<WSspReturnDocForBuyOrder_Result>();
		try
		{
			list = Enumerable.ToList<WSspReturnDocForBuyOrder_Result>((IEnumerable<WSspReturnDocForBuyOrder_Result>)_db.WSspReturnDocForBuyOrder(ordId, lCID, result));
			if (list == null)
			{
				list = new List<WSspReturnDocForBuyOrder_Result>();
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
	public string IsFixed(int bordId)
	{
		string result = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmBuyOrder", "actIsFixed", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			_dbII.WSspBuyOrderIsFixed(bordId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	[AjaxOnly]
	public string ExitIsFixed(int bordId)
	{
		string result = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmBuyOrder", "actExitIsFixed", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			if (BuyOrder.IsVerified(bordId))
			{
				return string.Format(Messages.msgErrorNotExitIsFixedAfterVerify, Labels.lblBOrd);
			}
			_dbII.WSspBuyOrderIsFixedExit(bordId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
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
			int userId = UserLogin.CurrentUser.UserId;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			List<CRMspSelectUserForLinkedType_Result> list = Enumerable.ToList<CRMspSelectUserForLinkedType_Result>((IEnumerable<CRMspSelectUserForLinkedType_Result>)_db.CRMspSelectUserForLinkedType(userId, 17, lCID, result2, result3));
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
	public List<SelectListItem> SelectUserForLinkedType_SelectListItem(int? selectedId = 0)
	{
		return Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectUserForLinkedType_Result, SelectListItem>((IEnumerable<CRMspSelectUserForLinkedType_Result>)SelectUserForLinkedType(), (Func<CRMspSelectUserForLinkedType_Result, SelectListItem>)((CRMspSelectUserForLinkedType_Result x) => new SelectListItem
		{
			Text = (x.UserName ?? "").Trim(),
			Value = x.LinkedUserId.ToString(),
			Selected = (x.LinkedUserId == selectedId)
		})));
	}

	[HttpPost]
	[LoginAuthorize]
	public List<CRMspSelectActiveUsers_Result> SelectActiveUsers()
	{
		List<CRMspSelectActiveUsers_Result> result = new List<CRMspSelectActiveUsers_Result>();
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
			List<CRMspSelectActiveUsers_Result> list = Enumerable.ToList<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)_db.CRMspSelectActiveUsers(lCID, result2, result3));
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
	public List<SelectListItem> SelectActiveUsers_SelectListItem(int? selectedId = 0)
	{
		return Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)SelectActiveUsers(), (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result x) => new SelectListItem
		{
			Text = (x.Name ?? "").Trim(),
			Value = x.UserId.ToString(),
			Selected = (x.UserId == selectedId)
		})));
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbLink.Dispose();
		_dbI.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}

	public ActionResult PrePaid_Read([DataSourceRequest] DataSourceRequest request, int borderId)
	{
		//IL_03d9: Unknown result type (might be due to invalid IL or missing references)
		List<WSspSelectBuyOrderPayments_Result> list = new List<WSspSelectBuyOrderPayments_Result>();
		try
		{
			list = GetBuyOrderPayment(borderId);
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
			foreach (WSspSelectBuyOrderPayments_Result item in list)
			{
				item.ImportDate = (item.ImportDateTime.HasValue ? item.ImportDateTime.Value.ToString("yyyyMMdd") : item.ImportDate);
				item.bordpayDocDate = (item.bordpayDocDateTime.HasValue ? item.bordpayDocDateTime.Value.ToString("yyyyMMdd") : item.bordpayDocDate);
				if (item.bordpayLinkAccHeaderId.HasValue || item.bordpayLinkAccDetailId.HasValue || !string.IsNullOrWhiteSpace(item.bordpayLinkAccHeaderNumber) || !string.IsNullOrWhiteSpace(item.bordpayLinkAccVoucherNumber))
				{
					string text = "";
					if (!string.IsNullOrWhiteSpace(item.bordpayLinkAccHeaderNumber))
					{
						text += string.Format(Labels.BordPayListAccLinkHeaderNumber, item.bordpayLinkAccHeaderNumber);
					}
					if (!string.IsNullOrWhiteSpace(item.bordpayLinkAccVoucherNumber))
					{
						if (!string.IsNullOrWhiteSpace(text))
						{
							text += ", ";
						}
						text += string.Format(Labels.BordPayListAccLinkVoucherNumber, item.bordpayLinkAccVoucherNumber);
					}
					if (item.bordpayLinkAccDetailId.HasValue)
					{
						if (!string.IsNullOrWhiteSpace(text))
						{
							text += ", ";
						}
						text += string.Format(Labels.BordPayListAccLinkDetailId, item.bordpayLinkAccDetailId.ToString());
					}
					item.bordpayLinkAccHeaderNumber = text;
				}
				item.bordpayDocDateTemp = (item.bordpayDocDateTimeTemp.HasValue ? item.bordpayDocDateTimeTemp.Value.ToString("yyyy/MM/dd") : "");
				bool result = false;
				bool.TryParse(item.bordpayIsVerified.ToString(), out result);
				if (result)
				{
					item.bordpayVerifier += (item.bordpayVerifiedRegisterDate.HasValue ? (" (<span class='dt-verify'>" + item.bordpayVerifiedRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") + "</span>)") : "");
					if (!string.IsNullOrWhiteSpace(item.bordpayVerifier))
					{
						item.bordpayVerifier = Labels.lblPayVerified + "(" + item.bordpayVerifier + ")";
					}
				}
				item.bordpayDeActiveDatePersian = (item.bordpayDeActiveDate.HasValue ? item.bordpayDeActiveDate.Value.ToString("yyyy/MM/dd") : "");
				bool result2 = false;
				bool.TryParse(item.bordpayDeActive.ToString(), out result2);
				if (result2)
				{
					item.bordpayDeActiveUser += (item.bordpayDeActiveDate.HasValue ? (" (<span class='dt-deactive'>" + item.bordpayDeActiveDate.Value.ToString("yyyy/MM/dd HH:mm:ss") + "</span>)") : "");
					if (!string.IsNullOrWhiteSpace(item.bordpayDeActiveUser))
					{
						item.bordpayDeActiveUser = Labels.lblPayDeActive + "(" + item.bordpayDeActiveUser + ")";
					}
				}
				if (num != 1)
				{
					continue;
				}
				List<PayLinkAccDataViewModel> list3 = new List<PayLinkAccDataViewModel>();
				if (!string.IsNullOrWhiteSpace(item.bordpayLinkAccData))
				{
					foreach (PayLinkAccDataViewModel item2 in new JavaScriptSerializer().Deserialize<List<PayLinkAccDataViewModel>>(item.bordpayLinkAccData))
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
							text2 += string.Format(Labels.BordPayListAccLinkHeaderNumber, item2.Number);
						}
						if (!string.IsNullOrWhiteSpace(item2.VoucherNumber) && (item2.VoucherNumber ?? "0") != "0")
						{
							if (!string.IsNullOrWhiteSpace(text2))
							{
								text2 += ", ";
							}
							text2 += string.Format(Labels.BordPayListAccLinkVoucherNumber, item2.VoucherNumber);
						}
						if (!string.IsNullOrWhiteSpace(item2.DetailId) && (item2.DetailId ?? "0") != "0")
						{
							if (!string.IsNullOrWhiteSpace(text2))
							{
								text2 += ", ";
							}
							text2 += string.Format(Labels.BordPayListAccLinkDetailId, item2.DetailId);
						}
						if (!string.IsNullOrWhiteSpace(item2.RefundNum) && (item2.RefundNum ?? "0") != "0")
						{
							if (!string.IsNullOrWhiteSpace(text2))
							{
								text2 += ", ";
							}
							text2 += string.Format(Labels.BordPayListAccLinkRefundNum, item2.RefundNum);
						}
						if (!string.IsNullOrWhiteSpace(item2.RefundVoucherNum) && (item2.RefundVoucherNum ?? "0") != "0")
						{
							if (!string.IsNullOrWhiteSpace(text2))
							{
								text2 += ", ";
							}
							text2 += string.Format(Labels.BordPayListAccLinkRefundVoucherNum, item2.RefundVoucherNum);
						}
						if (!string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(item2.DbTitle))
						{
							text2 = text2 + " (" + item2.DbTitle + ")";
						}
						item2.PayInfoWithLbl = text2;
						list3.Add(item2);
					}
				}
				item.bordpayLinkAccData = "";
				if (list3 != null && Enumerable.Any<PayLinkAccDataViewModel>((IEnumerable<PayLinkAccDataViewModel>)list3))
				{
					item.bordpayLinkAccData = JsonConvert.SerializeObject(Enumerable.ToList<PayLinkAccDataViewModel>((IEnumerable<PayLinkAccDataViewModel>)list3));
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
		JsonResult jsonResult = Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<WSspSelectBuyOrderPayments_Result> GetBuyOrderPayment(int id)
	{
		List<WSspSelectBuyOrderPayments_Result> result = new List<WSspSelectBuyOrderPayments_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			result = Enumerable.ToList<WSspSelectBuyOrderPayments_Result>((IEnumerable<WSspSelectBuyOrderPayments_Result>)_db.WSspSelectBuyOrderPayments(id, lCID, result2));
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

	[DynamicAuthorize(ControllerName = "frmBuyOrder", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(int id = 0, string itemsAmount = "", string parameters = "")
	{
		_003C_003Ec__DisplayClass31_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass31_0();
		CS_0024_003C_003E8__locals0.id = id;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		string[] array = parameters.Split(new char[1] { '|' });
		base.ViewBag.MyParameters = array;
		decimal result2 = default(decimal);
		string text = "";
		string text2 = "";
		string text3 = "";
		WSBuyOrderLanguageViewModel wSBuyOrderLanguageViewModel = new WSBuyOrderLanguageViewModel();
		List<CRMspSelectCompanyTitle_Result> list = Enumerable.ToList<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)_db.CRMspSelectCompanyTitle(CS_0024_003C_003E8__locals0.currLangID, result));
		if (CS_0024_003C_003E8__locals0.id > 0)
		{
			if (!UserLogin.IsUserAccess("frmBuyOrder", "actEdit"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			DbSet<WSBuyOrder_Lang> wSBuyOrder_Lang = _dbTbl.WSBuyOrder_Lang;
			ParameterExpression val = Expression.Parameter(typeof(WSBuyOrder_Lang), "c");
			List<WSBuyOrder_Lang> list2 = Enumerable.ToList<WSBuyOrder_Lang>((IEnumerable<WSBuyOrder_Lang>)Queryable.Where<WSBuyOrder_Lang>((IQueryable<WSBuyOrder_Lang>)wSBuyOrder_Lang, Expression.Lambda<Func<WSBuyOrder_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass31_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			DbSet<WSBuyOrder> wSBuyOrder = _dbTbl.WSBuyOrder;
			val = Expression.Parameter(typeof(WSBuyOrder), "c");
			WSBuyOrder wSBuyOrder2 = Queryable.FirstOrDefault<WSBuyOrder>((IQueryable<WSBuyOrder>)wSBuyOrder, Expression.Lambda<Func<WSBuyOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass31_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (wSBuyOrder2 == null)
			{
				base.ViewBag.Error = Messages.ErrorNotFound;
				return null;
			}
			if (BuyOrder.IsEditAfterFix(wSBuyOrder2.bordEditAfterFixInfoJs, wSBuyOrder2.BuyOrderID, 1))
			{
				wSBuyOrder2.bordIsFixed = false;
			}
			if (wSBuyOrder2.bordIsFixed.HasValue && wSBuyOrder2.bordIsFixed.GetValueOrDefault())
			{
				base.ViewBag.Error = Messages.msgErrorNotActiveBOrd;
				return null;
			}
			if (itemsAmount.Trim() != "")
			{
				itemsAmount = itemsAmount.Replace(",", "").Replace("،", "").Replace("/", ".");
				decimal.TryParse(itemsAmount, out result2);
			}
			CRMspSelectCompanyById_Result cmp2 = CRMIdeal.Classes.Helper.Company.GetCompanyById(wSBuyOrder2.bordCompanyId);
			if (cmp2 != null)
			{
				text = ((Enumerable.FirstOrDefault<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)list, (Func<CRMspSelectCompanyTitle_Result, bool>)((CRMspSelectCompanyTitle_Result c) => c.CompanyTitleID == cmp2.cmpTitleId)) != null) ? (Enumerable.FirstOrDefault<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)list, (Func<CRMspSelectCompanyTitle_Result, bool>)((CRMspSelectCompanyTitle_Result c) => c.CompanyTitleID == cmp2.cmpTitleId)).CompanyTitle + " ") : "") + cmp2.cmpName;
				text2 = cmp2.cmpAddress;
				text3 = cmp2.cmpTel;
			}
			List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSBuyOrder_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSBuyOrder_Lang>)list2, (Func<WSBuyOrder_Lang, CommonMultiLanguageViewModel>)((WSBuyOrder_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.bordTitle,
				LanguageId = item.LanguageID
			})));
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = wSBuyOrder2.bordTitle,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSBuyOrder_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSBuyOrder_Lang>)list2, (Func<WSBuyOrder_Lang, CommonMultiLanguageViewModel>)((WSBuyOrder_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.bordSubject,
				LanguageId = item.LanguageID
			})));
			list4.Add(new CommonMultiLanguageViewModel
			{
				Value = wSBuyOrder2.bordSubject,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list5 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSBuyOrder_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSBuyOrder_Lang>)list2, (Func<WSBuyOrder_Lang, CommonMultiLanguageViewModel>)((WSBuyOrder_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.bordTotalAmountStr,
				LanguageId = item.LanguageID
			})));
			list5.Add(new CommonMultiLanguageViewModel
			{
				Value = wSBuyOrder2.bordTotalAmountStr,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list6 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSBuyOrder_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSBuyOrder_Lang>)list2, (Func<WSBuyOrder_Lang, CommonMultiLanguageViewModel>)((WSBuyOrder_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.bordNote,
				LanguageId = item.LanguageID
			})));
			list6.Add(new CommonMultiLanguageViewModel
			{
				Value = wSBuyOrder2.bordNote,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list7 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSBuyOrder_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSBuyOrder_Lang>)list2, (Func<WSBuyOrder_Lang, CommonMultiLanguageViewModel>)((WSBuyOrder_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.bordDiscountTitle,
				LanguageId = item.LanguageID
			})));
			list7.Add(new CommonMultiLanguageViewModel
			{
				Value = wSBuyOrder2.bordDiscountTitle,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list8 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSBuyOrder_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSBuyOrder_Lang>)list2, (Func<WSBuyOrder_Lang, CommonMultiLanguageViewModel>)((WSBuyOrder_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.bordcmpTitle,
				LanguageId = item.LanguageID
			})));
			list8.Add(new CommonMultiLanguageViewModel
			{
				Value = wSBuyOrder2.bordcmpTitle,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list9 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSBuyOrder_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSBuyOrder_Lang>)list2, (Func<WSBuyOrder_Lang, CommonMultiLanguageViewModel>)((WSBuyOrder_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.bordDeliveryTerm,
				LanguageId = item.LanguageID
			})));
			list9.Add(new CommonMultiLanguageViewModel
			{
				Value = wSBuyOrder2.bordDeliveryTerm,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list10 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSBuyOrder_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSBuyOrder_Lang>)list2, (Func<WSBuyOrder_Lang, CommonMultiLanguageViewModel>)((WSBuyOrder_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.bordForwarderName,
				LanguageId = item.LanguageID
			})));
			list10.Add(new CommonMultiLanguageViewModel
			{
				Value = wSBuyOrder2.bordForwarderName,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list11 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSBuyOrder_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSBuyOrder_Lang>)list2, (Func<WSBuyOrder_Lang, CommonMultiLanguageViewModel>)((WSBuyOrder_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.bordCustomsPart,
				LanguageId = item.LanguageID
			})));
			list11.Add(new CommonMultiLanguageViewModel
			{
				Value = wSBuyOrder2.bordCustomsPart,
				LanguageId = result
			});
			wSBuyOrderLanguageViewModel = new WSBuyOrderLanguageViewModel
			{
				BuyOrderID = wSBuyOrder2.BuyOrderID,
				BuyOrderOprId = wSBuyOrder2.BuyOrderOprId,
				PreBuyOrderId = wSBuyOrder2.PreBuyOrderId,
				PreBuyOrderVerifierId = wSBuyOrder2.PreBuyOrderVerifierId,
				bordNumber = wSBuyOrder2.bordNumber,
				bordOrderNumber = wSBuyOrder2.bordOrderNumber,
				bordDate = (wSBuyOrder2.bordDateTime.HasValue ? wSBuyOrder2.bordDateTime.Value.ToString("yyyy/MM/dd") : ""),
				bordOrderDate = (wSBuyOrder2.bordOrderDateTime.HasValue ? wSBuyOrder2.bordOrderDateTime.Value.ToString("yyyy/MM/dd") : ""),
				bordOrderDateTime = wSBuyOrder2.bordOrderDateTime,
				bordCompanyId = wSBuyOrder2.bordCompanyId,
				bordCompanyPersonId = wSBuyOrder2.bordCompanyPersonId,
				bordProjectId = wSBuyOrder2.bordProjectId,
				bordItemCount = wSBuyOrder2.bordItemCount,
				bordItemsAmount = wSBuyOrder2.bordItemsAmount,
				bordDiscount = wSBuyOrder2.bordDiscount,
				bordSumAmount = wSBuyOrder2.bordSumAmount,
				bordTax = wSBuyOrder2.bordTax,
				bordTaxIndex = wSBuyOrder2.bordTaxIndex,
				bordCalculateTax = wSBuyOrder2.bordCalculateTax,
				bordTotalAmount = wSBuyOrder2.bordTotalAmount,
				bordIsVerified = wSBuyOrder2.bordIsVerified,
				bordStatusId = wSBuyOrder2.bordStatusId,
				bordIsFixed = wSBuyOrder2.bordIsFixed,
				bordPrintFormatId = wSBuyOrder2.bordPrintFormatId,
				bordImportDate = wSBuyOrder2.bordImportDate,
				UserId = wSBuyOrder2.UserId,
				FPId = wSBuyOrder2.FPId,
				Month1 = wSBuyOrder2.Month1,
				RegisterDate = wSBuyOrder2.RegisterDate,
				RegisterDatePersian = wSBuyOrder2.RegisterDatePersian,
				bordVerifierId = wSBuyOrder2.bordVerifierId,
				bordVerifiedRegisterDate = wSBuyOrder2.bordVerifiedRegisterDate,
				bordVerifiedRegisterDatePersian = wSBuyOrder2.bordVerifiedRegisterDatePersian,
				bordFirstRegisterUserId = wSBuyOrder2.bordFirstRegisterUserId,
				bordSettlementTypeId = wSBuyOrder2.bordSettlementTypeId,
				bordDay = wSBuyOrder2.bordDay,
				bordTime = wSBuyOrder2.bordTime,
				bordTransportation = wSBuyOrder2.bordTransportation,
				bordReferUserId = wSBuyOrder2.bordReferUserId,
				bordRound = wSBuyOrder2.bordRound,
				bordDiscountPercent = wSBuyOrder2.bordDiscountPercent,
				bordDateTime = wSBuyOrder2.bordDateTime,
				bordImportDateTime = wSBuyOrder2.bordImportDateTime,
				GUId = wSBuyOrder2.GUId,
				AppType = wSBuyOrder2.AppType,
				LanguageID = wSBuyOrder2.LanguageID,
				FirstRegisterUserId = wSBuyOrder2.FirstRegisterUserId,
				FirstRegisterDatePersian = wSBuyOrder2.FirstRegisterDatePersian,
				FirstRegisterDate = wSBuyOrder2.FirstRegisterDate,
				bordTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				bordTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				bordSubject = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				bordSubject_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				bordTotalAmountStr = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				bordTotalAmountStr_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				bordNote = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				bordNote_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				bordDiscountTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				bordDiscountTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				bordcmpTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				bordcmpTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				bordCurrencyUnitId = wSBuyOrder2.bordCurrencyUnitId,
				bordCurrencyUnitIdI = wSBuyOrder2.bordCurrencyUnitIdI,
				bordCurrencyUnitIRate = wSBuyOrder2.bordCurrencyUnitIRate,
				bordFacilityCmpId = wSBuyOrder2.bordFacilityCmpId,
				bordFacilityPrsId = wSBuyOrder2.bordFacilityPrsId,
				bordFacilityPrjId = wSBuyOrder2.bordFacilityPrjId,
				bordReqCmpId = wSBuyOrder2.bordReqCmpId,
				bordReqPrsId = wSBuyOrder2.bordReqPrsId,
				bordReqPrjId = wSBuyOrder2.bordReqPrjId,
				bordDeliveryTerm = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				bordDeliveryTerm_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				bordDeliveryDate = wSBuyOrder2.bordDeliveryDate,
				bordDeliveryDatePersian = (wSBuyOrder2.bordDeliveryDate.HasValue ? wSBuyOrder2.bordDeliveryDate.Value.ToString("yyyy/MM/dd") : ""),
				bordDeliveryTime = (wSBuyOrder2.bordDeliveryDate.HasValue ? wSBuyOrder2.bordDeliveryDate.Value.ToString("HH:mm") : ""),
				bordTaxCleared = wSBuyOrder2.bordTaxCleared,
				bordTaxClearedDate = wSBuyOrder2.bordTaxClearedDate,
				bordTaxClearedDatePersian = (wSBuyOrder2.bordTaxClearedDate.HasValue ? wSBuyOrder2.bordTaxClearedDate.Value.ToString("yyyy/MM/dd") : ""),
				bordFacilityCost = wSBuyOrder2.bordFacilityCost,
				bordFacilityCostPercent = wSBuyOrder2.bordFacilityCostPercent,
				bordSupplierDeliveryDate = wSBuyOrder2.bordSupplierDeliveryDate,
				bordSupplierDeliveryDatePersian = (wSBuyOrder2.bordSupplierDeliveryDate.HasValue ? wSBuyOrder2.bordSupplierDeliveryDate.Value.ToString("yyyy/MM/dd") : ""),
				bordSupplierDeliveryTime = (wSBuyOrder2.bordSupplierDeliveryDate.HasValue ? wSBuyOrder2.bordSupplierDeliveryDate.Value.ToString("HH:mm") : ""),
				bordForwarderName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				bordForwarderName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				bordFreightCost = wSBuyOrder2.bordFreightCost,
				bordFreightCurrUnId = wSBuyOrder2.bordFreightCurrUnId,
				bordFreightCurrencyRate = wSBuyOrder2.bordFreightCurrencyRate,
				bordFinalFreightCost = wSBuyOrder2.bordFinalFreightCost,
				bordCustomsPart = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				bordCustomsPart_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				bordCustomsFee = wSBuyOrder2.bordCustomsFee,
				bordCustomsCurrUnId = wSBuyOrder2.bordCustomsCurrUnId,
				bordCustomsCurrencyRate = wSBuyOrder2.bordCustomsCurrencyRate,
				bordFinalCustomsFee = wSBuyOrder2.bordFinalCustomsFee,
				bordFinalDeliveryDate = wSBuyOrder2.bordFinalDeliveryDate,
				bordFinalDeliveryDatePersian = (wSBuyOrder2.bordFinalDeliveryDate.HasValue ? wSBuyOrder2.bordFinalDeliveryDate.Value.ToString("yyyy/MM/dd") : ""),
				bordFinalDeliveryTime = (wSBuyOrder2.bordFinalDeliveryDate.HasValue ? wSBuyOrder2.bordFinalDeliveryDate.Value.ToString("HH:mm") : ""),
				bordCommission = wSBuyOrder2.bordCommission,
				bordCommissionCurrUnId = wSBuyOrder2.bordCommissionCurrUnId,
				bordCommissionCurrencyRate = wSBuyOrder2.bordCommissionCurrencyRate,
				bordFinalCommission = wSBuyOrder2.bordFinalCommission,
				bordNumRef = wSBuyOrder2.bordNumRef,
				bordDefaultSettingId = wSBuyOrder2.bordDefaultSettingId,
				bordVerificationWorkFlowId = wSBuyOrder2.bordVerificationWorkFlowId,
				bordSuppUserId = wSBuyOrder2.bordSuppUserId
			};
			if (wSBuyOrder2.bordFacilityCmpId.HasValue)
			{
				int result3 = 0;
				int.TryParse(wSBuyOrder2.bordFacilityCmpId.ToString(), out result3);
				if (result3 > 0)
				{
					CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(result3);
					if (companyById != null)
					{
						wSBuyOrderLanguageViewModel.bordFacilityCmp = companyById.CompanyName ?? "";
					}
				}
			}
			if (wSBuyOrder2.bordReqCmpId.HasValue)
			{
				int result4 = 0;
				int.TryParse(wSBuyOrder2.bordReqCmpId.ToString(), out result4);
				if (result4 > 0)
				{
					CRMspSelectCompanyById_Result companyById2 = CRMIdeal.Classes.Helper.Company.GetCompanyById(result4);
					if (companyById2 != null)
					{
						wSBuyOrderLanguageViewModel.bordReqCmp = companyById2.CompanyName ?? "";
					}
				}
			}
		}
		else
		{
			if (!UserLogin.IsUserAccess("frmBuyOrder", "actInsert"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			DateTime now = DateTime.Now;
			wSBuyOrderLanguageViewModel = new WSBuyOrderLanguageViewModel
			{
				bordFirstRegisterUserId = UserLogin.CurrentUser.UserId,
				bordDate = now.ToString("yyyyMMdd", new PersianCulture()),
				bordDateTime = now,
				bordImportDate = now.ToString("yyyyMMdd", new PersianCulture()),
				bordImportDateTime = now,
				bordCalculateTax = true,
				bordDay = DateTimeClass.DefineDayeOfWeekStartWith7(now.DayOfWeek.ToString()),
				bordTime = now.ToString("HH:mm:ss"),
				bordStatusId = 1,
				UserId = UserLogin.CurrentUser.UserId,
				bordReferUserId = UserLogin.CurrentUser.UserId,
				RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
				RegisterDate = now
			};
			if (array.Length >= 1 && array[0] != "")
			{
				int result5 = 0;
				int.TryParse(array[0], out result5);
				CRMspSelectCompanyById_Result cmp = CRMIdeal.Classes.Helper.Company.GetCompanyById(result5);
				if (cmp != null)
				{
					text = ((Enumerable.FirstOrDefault<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)list, (Func<CRMspSelectCompanyTitle_Result, bool>)((CRMspSelectCompanyTitle_Result c) => c.CompanyTitleID == cmp.cmpTitleId)) != null) ? (Enumerable.FirstOrDefault<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)list, (Func<CRMspSelectCompanyTitle_Result, bool>)((CRMspSelectCompanyTitle_Result c) => c.CompanyTitleID == cmp.cmpTitleId)).CompanyTitle + " ") : "") + cmp.cmpName;
					text2 = cmp.cmpAddress;
					text3 = cmp.cmpTel;
				}
			}
			base.ViewBag.IsBuying = VersionBuyer.BuyOrders;
		}
		GetBuyOrderOpr();
		GetBuyOrdStatus();
		GetBuyOrdPrintFormat();
		GetCurrencyUnit();
		GetBordDefSetting();
		GetVerificationWorkFlow();
		base.ViewBag.ReferUsers = SelectUserForLinkedType_SelectListItem(wSBuyOrderLanguageViewModel.bordReferUserId);
		base.ViewBag.SuppUsers = SelectActiveUsers_SelectListItem(wSBuyOrderLanguageViewModel.bordSuppUserId);
		List<int> list12 = new List<int>();
		List<CRMspSelectUsers_Result> list13 = CRMIdeal.Classes.Helper.User.SelectUsers(0);
		if (list13 != null && Enumerable.Any<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)list13))
		{
			list12 = Enumerable.ToList<int>(Enumerable.Select<CRMspSelectUsers_Result, int>(Enumerable.Where<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)list13, (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result c) => c.IsActive == false || !c.IsActive.HasValue)), (Func<CRMspSelectUsers_Result, int>)((CRMspSelectUsers_Result c) => c.UserId)));
		}
		base.ViewBag.ListUserIsActiveStatus = list12;
		base.ViewBag.ItemsSumAmount = result2;
		base.ViewBag.CmpFullName = text;
		base.ViewBag.CmpAddrs = text2;
		base.ViewBag.CmpTele = text3;
		return View(wSBuyOrderLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmBuyOrderDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult InsertEdit(WSBuyOrderLanguageViewModel vm)
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
		_003C_003Ec__DisplayClass32_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass32_0();
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
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.bordTitle_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.bordTitle_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.bordTitle,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.bordSubject_Lang))
		{
			list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.bordSubject_Lang);
		}
		list2.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.bordSubject,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.bordTotalAmountStr_Lang))
		{
			list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.bordTotalAmountStr_Lang);
		}
		list3.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.bordTotalAmountStr,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.bordNote_Lang))
		{
			list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.bordNote_Lang);
		}
		list4.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.bordNote,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.bordDiscountTitle_Lang))
		{
			list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.bordDiscountTitle_Lang);
		}
		list5.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.bordDiscountTitle,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.bordcmpTitle_Lang))
		{
			list6 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.bordcmpTitle_Lang);
		}
		list6.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.bordcmpTitle,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list7 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.bordDeliveryTerm_Lang))
		{
			list7 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.bordDeliveryTerm_Lang);
		}
		list7.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.bordDeliveryTerm,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list8 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.bordForwarderName_Lang))
		{
			list8 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.bordForwarderName_Lang);
		}
		list8.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.bordForwarderName,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list9 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.bordCustomsPart_Lang))
		{
			list9 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.bordCustomsPart_Lang);
		}
		list9.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.bordCustomsPart,
			LanguageId = lCID
		});
		base.ViewBag.MyParameters = "".Split(new char[1] { '|' });
		string text = "";
		string text2 = "";
		string text3 = "";
		CS_0024_003C_003E8__locals0.cmp = CRMIdeal.Classes.Helper.Company.GetCompanyById(CS_0024_003C_003E8__locals0.vm.bordCompanyId);
		List<CRMspSelectCompanyTitle_Result> list10 = Enumerable.ToList<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)_db.CRMspSelectCompanyTitle(lCID, CS_0024_003C_003E8__locals0.defLangID));
		if (CS_0024_003C_003E8__locals0.cmp != null)
		{
			text = ((Enumerable.FirstOrDefault<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)list10, (Func<CRMspSelectCompanyTitle_Result, bool>)((CRMspSelectCompanyTitle_Result c) => c.CompanyTitleID == CS_0024_003C_003E8__locals0.cmp.cmpTitleId)) != null) ? (Enumerable.FirstOrDefault<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)list10, (Func<CRMspSelectCompanyTitle_Result, bool>)((CRMspSelectCompanyTitle_Result c) => c.CompanyTitleID == CS_0024_003C_003E8__locals0.cmp.cmpTitleId)).CompanyTitle + " ") : "") + CS_0024_003C_003E8__locals0.cmp.cmpName;
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
				decimal.TryParse(array[1].Replace(",", "").Replace("،", "").Replace("/", "."), out result);
			}
		}
		base.ViewBag.ItemsSumAmount = result;
		GetBuyOrderOpr();
		GetBuyOrdStatus();
		GetBuyOrdPrintFormat();
		GetCurrencyUnit();
		GetBordDefSetting();
		GetVerificationWorkFlow();
		base.ViewBag.ReferUsers = SelectUserForLinkedType_SelectListItem(CS_0024_003C_003E8__locals0.vm.bordReferUserId);
		base.ViewBag.SuppUsers = SelectActiveUsers_SelectListItem(CS_0024_003C_003E8__locals0.vm.bordSuppUserId);
		List<int> list11 = new List<int>();
		List<CRMspSelectUsers_Result> list12 = CRMIdeal.Classes.Helper.User.SelectUsers(0);
		if (list12 != null && Enumerable.Any<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)list12))
		{
			list11 = Enumerable.ToList<int>(Enumerable.Select<CRMspSelectUsers_Result, int>(Enumerable.Where<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)list12, (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result c) => c.IsActive == false || !c.IsActive.HasValue)), (Func<CRMspSelectUsers_Result, int>)((CRMspSelectUsers_Result c) => c.UserId)));
		}
		base.ViewBag.ListUserIsActiveStatus = list11;
		long num2 = 0L;
		string text4 = "";
		int sysPartId = 40;
		try
		{
			if (CS_0024_003C_003E8__locals0.vm.BuyOrderID <= 0 && !VersionBuyer.BuyOrders)
			{
				DbSet<WSBuyOrder> wSBuyOrder = _dbTbl.WSBuyOrder;
				ParameterExpression val = Expression.Parameter(typeof(WSBuyOrder), "c");
				if (Queryable.Any<WSBuyOrder>((IQueryable<WSBuyOrder>)wSBuyOrder, Expression.Lambda<Func<WSBuyOrder, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)10, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val })))
				{
					base.ViewBag.Error = "BV|" + Messages.VersionBuy;
					return View(CS_0024_003C_003E8__locals0.vm);
				}
			}
			if (CS_0024_003C_003E8__locals0.vm.BuyOrderID > 0 && BuyOrder.IsSentToLinkAccByAction(CS_0024_003C_003E8__locals0.vm.BuyOrderID))
			{
				string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
				base.ViewBag.Error = string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			if (!CS_0024_003C_003E8__locals0.vm.bordDiscountPercent.HasValue)
			{
				CS_0024_003C_003E8__locals0.vm.bordDiscountPercent = default(decimal);
			}
			DateTime dateTime = default(DateTime);
			string text5 = "";
			try
			{
				if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.bordTime))
				{
					CS_0024_003C_003E8__locals0.vm.bordTime = DateTime.Now.ToString("HH:mm:ss");
				}
				else
				{
					CS_0024_003C_003E8__locals0.vm.bordTime = CS_0024_003C_003E8__locals0.vm.bordTime.Trim();
				}
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.bordDate))
				{
					text5 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.vm.bordDate.Replace("/", ""));
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text5 + " " + CS_0024_003C_003E8__locals0.vm.bordTime, new PersianCulture());
						CS_0024_003C_003E8__locals0.vm.bordDate = dateTime.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime = DateTime.Parse(text5 + " " + CS_0024_003C_003E8__locals0.vm.bordTime, new CultureInfo("ar-SA"));
						CS_0024_003C_003E8__locals0.vm.bordDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime = DateTime.Parse(text5 + " " + CS_0024_003C_003E8__locals0.vm.bordTime, new CultureInfo("en-US"));
						CS_0024_003C_003E8__locals0.vm.bordDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
					CS_0024_003C_003E8__locals0.vm.bordDateTime = dateTime;
					CS_0024_003C_003E8__locals0.vm.bordDay = DateTimeClass.DefineDayeOfWeekStartWith7(dateTime.DayOfWeek.ToString());
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				base.ViewBag.Error = Messages.WrongBordDateTime;
				CS_0024_003C_003E8__locals0.vm.bordDate = (CS_0024_003C_003E8__locals0.vm.bordDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.bordDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.bordOrderDate = (CS_0024_003C_003E8__locals0.vm.bordOrderDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.bordOrderDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.bordTaxClearedDatePersian = (CS_0024_003C_003E8__locals0.vm.bordTaxClearedDate.HasValue ? CS_0024_003C_003E8__locals0.vm.bordTaxClearedDate.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.bordDeliveryDatePersian = (CS_0024_003C_003E8__locals0.vm.bordDeliveryDate.HasValue ? CS_0024_003C_003E8__locals0.vm.bordDeliveryDate.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDatePersian = (CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDate.HasValue ? CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDate.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDatePersian = (CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDate.HasValue ? CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDate.Value.ToString("yyyy/MM/dd") : "");
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			try
			{
				if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.vm.bordOrderDate))
				{
					text5 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.vm.bordOrderDate.Replace("/", ""));
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text5 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
						CS_0024_003C_003E8__locals0.vm.bordOrderDate = dateTime.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime = DateTime.Parse(text5 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
						CS_0024_003C_003E8__locals0.vm.bordOrderDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime = DateTime.Parse(text5 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
						CS_0024_003C_003E8__locals0.vm.bordOrderDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
					CS_0024_003C_003E8__locals0.vm.bordOrderDateTime = dateTime;
				}
				else
				{
					CS_0024_003C_003E8__locals0.vm.bordOrderDate = null;
					CS_0024_003C_003E8__locals0.vm.bordOrderDateTime = null;
				}
			}
			catch (Exception e2)
			{
				ErrorSignal.FromCurrentContext().Raise(e2);
				base.ViewBag.Error = Messages.WrongBordOrderDateTime;
				CS_0024_003C_003E8__locals0.vm.bordDate = (CS_0024_003C_003E8__locals0.vm.bordDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.bordDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.bordOrderDate = (CS_0024_003C_003E8__locals0.vm.bordOrderDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.bordOrderDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.bordTaxClearedDatePersian = (CS_0024_003C_003E8__locals0.vm.bordTaxClearedDate.HasValue ? CS_0024_003C_003E8__locals0.vm.bordTaxClearedDate.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.bordDeliveryDatePersian = (CS_0024_003C_003E8__locals0.vm.bordDeliveryDate.HasValue ? CS_0024_003C_003E8__locals0.vm.bordDeliveryDate.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDatePersian = (CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDate.HasValue ? CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDate.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDatePersian = (CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDate.HasValue ? CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDate.Value.ToString("yyyy/MM/dd") : "");
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			if (CS_0024_003C_003E8__locals0.vm.bordDate != null)
			{
				CS_0024_003C_003E8__locals0.vm.bordDate = CS_0024_003C_003E8__locals0.vm.bordDate.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
			}
			if (CS_0024_003C_003E8__locals0.vm.bordOrderDate != null)
			{
				CS_0024_003C_003E8__locals0.vm.bordOrderDate = CS_0024_003C_003E8__locals0.vm.bordOrderDate.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
			}
			if (CS_0024_003C_003E8__locals0.vm.bordImportDate != null)
			{
				CS_0024_003C_003E8__locals0.vm.bordImportDate = CS_0024_003C_003E8__locals0.vm.bordImportDate.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
			}
			if (CS_0024_003C_003E8__locals0.vm.bordVerifiedRegisterDatePersian != null)
			{
				CS_0024_003C_003E8__locals0.vm.bordVerifiedRegisterDatePersian = CS_0024_003C_003E8__locals0.vm.bordVerifiedRegisterDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
			}
			try
			{
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.bordTaxClearedDatePersian))
				{
					text5 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.vm.bordTaxClearedDatePersian.Replace("/", ""));
					text5 += " 00:00:00";
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text5, new PersianCulture());
						CS_0024_003C_003E8__locals0.vm.bordTaxClearedDatePersian = dateTime.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime = DateTime.Parse(text5, new CultureInfo("ar-SA"));
						CS_0024_003C_003E8__locals0.vm.bordTaxClearedDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime = DateTime.Parse(text5, new CultureInfo("en-US"));
						CS_0024_003C_003E8__locals0.vm.bordTaxClearedDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
					CS_0024_003C_003E8__locals0.vm.bordTaxClearedDate = dateTime;
				}
				else
				{
					CS_0024_003C_003E8__locals0.vm.bordTaxClearedDatePersian = null;
					CS_0024_003C_003E8__locals0.vm.bordTaxClearedDate = null;
				}
			}
			catch (Exception e3)
			{
				ErrorSignal.FromCurrentContext().Raise(e3);
				base.ViewBag.Error = string.Format(Messages.ErrorInFormat, Labels.bordTaxClearedDate);
				CS_0024_003C_003E8__locals0.vm.bordDate = (CS_0024_003C_003E8__locals0.vm.bordDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.bordDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.bordOrderDate = (CS_0024_003C_003E8__locals0.vm.bordOrderDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.bordOrderDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.bordTaxClearedDatePersian = (CS_0024_003C_003E8__locals0.vm.bordTaxClearedDate.HasValue ? CS_0024_003C_003E8__locals0.vm.bordTaxClearedDate.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.bordDeliveryDatePersian = (CS_0024_003C_003E8__locals0.vm.bordDeliveryDate.HasValue ? CS_0024_003C_003E8__locals0.vm.bordDeliveryDate.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDatePersian = (CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDate.HasValue ? CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDate.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDatePersian = (CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDate.HasValue ? CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDate.Value.ToString("yyyy/MM/dd") : "");
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			if (CS_0024_003C_003E8__locals0.vm.bordTaxClearedDatePersian != null)
			{
				CS_0024_003C_003E8__locals0.vm.bordTaxClearedDatePersian = CS_0024_003C_003E8__locals0.vm.bordTaxClearedDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
			}
			try
			{
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.bordDeliveryDatePersian))
				{
					text5 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.vm.bordDeliveryDatePersian.Replace("/", ""));
					text5 = (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.bordDeliveryTime) ? (text5 + " 00:00:00") : (text5 + " " + CS_0024_003C_003E8__locals0.vm.bordDeliveryTime.Trim()));
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text5, new PersianCulture());
						CS_0024_003C_003E8__locals0.vm.bordDeliveryDatePersian = dateTime.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime = DateTime.Parse(text5, new CultureInfo("ar-SA"));
						CS_0024_003C_003E8__locals0.vm.bordDeliveryDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime = DateTime.Parse(text5, new CultureInfo("en-US"));
						CS_0024_003C_003E8__locals0.vm.bordDeliveryDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
					CS_0024_003C_003E8__locals0.vm.bordDeliveryDate = dateTime;
				}
				else
				{
					CS_0024_003C_003E8__locals0.vm.bordDeliveryDatePersian = null;
					CS_0024_003C_003E8__locals0.vm.bordDeliveryDate = null;
				}
			}
			catch (Exception e4)
			{
				ErrorSignal.FromCurrentContext().Raise(e4);
				base.ViewBag.Error = string.Format(Messages.ErrorInFormat, Labels.bordDeliveryDate);
				CS_0024_003C_003E8__locals0.vm.bordDate = (CS_0024_003C_003E8__locals0.vm.bordDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.bordDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.bordOrderDate = (CS_0024_003C_003E8__locals0.vm.bordOrderDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.bordOrderDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.bordTaxClearedDatePersian = (CS_0024_003C_003E8__locals0.vm.bordTaxClearedDate.HasValue ? CS_0024_003C_003E8__locals0.vm.bordTaxClearedDate.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.bordDeliveryDatePersian = (CS_0024_003C_003E8__locals0.vm.bordDeliveryDate.HasValue ? CS_0024_003C_003E8__locals0.vm.bordDeliveryDate.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDatePersian = (CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDate.HasValue ? CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDate.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDatePersian = (CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDate.HasValue ? CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDate.Value.ToString("yyyy/MM/dd") : "");
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			if (CS_0024_003C_003E8__locals0.vm.bordDeliveryDatePersian != null)
			{
				CS_0024_003C_003E8__locals0.vm.bordDeliveryDatePersian = CS_0024_003C_003E8__locals0.vm.bordDeliveryDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
			}
			try
			{
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDatePersian))
				{
					text5 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDatePersian.Replace("/", ""));
					text5 = (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryTime) ? (text5 + " 00:00:00") : (text5 + " " + CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryTime.Trim()));
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text5, new PersianCulture());
						CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDatePersian = dateTime.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime = DateTime.Parse(text5, new CultureInfo("ar-SA"));
						CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime = DateTime.Parse(text5, new CultureInfo("en-US"));
						CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
					CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDate = dateTime;
				}
				else
				{
					CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDatePersian = null;
					CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDate = null;
				}
			}
			catch (Exception e5)
			{
				ErrorSignal.FromCurrentContext().Raise(e5);
				base.ViewBag.Error = string.Format(Messages.ErrorInFormat, Labels.bordSupplierDeliveryDate);
				CS_0024_003C_003E8__locals0.vm.bordDate = (CS_0024_003C_003E8__locals0.vm.bordDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.bordDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.bordOrderDate = (CS_0024_003C_003E8__locals0.vm.bordOrderDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.bordOrderDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.bordTaxClearedDatePersian = (CS_0024_003C_003E8__locals0.vm.bordTaxClearedDate.HasValue ? CS_0024_003C_003E8__locals0.vm.bordTaxClearedDate.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.bordDeliveryDatePersian = (CS_0024_003C_003E8__locals0.vm.bordDeliveryDate.HasValue ? CS_0024_003C_003E8__locals0.vm.bordDeliveryDate.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDatePersian = (CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDate.HasValue ? CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDate.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDatePersian = (CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDate.HasValue ? CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDate.Value.ToString("yyyy/MM/dd") : "");
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			if (CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDatePersian != null)
			{
				CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDatePersian = CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
			}
			try
			{
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDatePersian))
				{
					text5 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDatePersian.Replace("/", ""));
					text5 = (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryTime) ? (text5 + " 00:00:00") : (text5 + " " + CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryTime.Trim()));
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text5, new PersianCulture());
						CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDatePersian = dateTime.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime = DateTime.Parse(text5, new CultureInfo("ar-SA"));
						CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime = DateTime.Parse(text5, new CultureInfo("en-US"));
						CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
					CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDate = dateTime;
				}
				else
				{
					CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDatePersian = null;
					CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDate = null;
				}
			}
			catch (Exception e6)
			{
				ErrorSignal.FromCurrentContext().Raise(e6);
				base.ViewBag.Error = string.Format(Messages.ErrorInFormat, Labels.bordFinalDeliveryDate);
				CS_0024_003C_003E8__locals0.vm.bordDate = (CS_0024_003C_003E8__locals0.vm.bordDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.bordDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.bordOrderDate = (CS_0024_003C_003E8__locals0.vm.bordOrderDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.bordOrderDateTime.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.bordTaxClearedDatePersian = (CS_0024_003C_003E8__locals0.vm.bordTaxClearedDate.HasValue ? CS_0024_003C_003E8__locals0.vm.bordTaxClearedDate.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.bordDeliveryDatePersian = (CS_0024_003C_003E8__locals0.vm.bordDeliveryDate.HasValue ? CS_0024_003C_003E8__locals0.vm.bordDeliveryDate.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDatePersian = (CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDate.HasValue ? CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDate.Value.ToString("yyyy/MM/dd") : "");
				CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDatePersian = (CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDate.HasValue ? CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDate.Value.ToString("yyyy/MM/dd") : "");
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			if (CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDatePersian != null)
			{
				CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDatePersian = CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
			}
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.bordNumRef) && UserLogin.IsUserAccess("frmBuyOrderDataEntry", "actNotDupNumRef", UserLogin.CurrentUser))
			{
				WSspCheckDuplicateBuyOrderNumRef_Result wSspCheckDuplicateBuyOrderNumRef_Result = Enumerable.FirstOrDefault<WSspCheckDuplicateBuyOrderNumRef_Result>((IEnumerable<WSspCheckDuplicateBuyOrderNumRef_Result>)_db.WSspCheckDuplicateBuyOrderNumRef(CS_0024_003C_003E8__locals0.vm.bordNumRef, CS_0024_003C_003E8__locals0.vm.BuyOrderID, CS_0024_003C_003E8__locals0.vm.BuyOrderOprId, num));
				if (wSspCheckDuplicateBuyOrderNumRef_Result != null)
				{
					base.ViewBag.Error = string.Format(Messages.BuyOrderNumRefIsRepeated, wSspCheckDuplicateBuyOrderNumRef_Result.bordNumber.ToString());
					CS_0024_003C_003E8__locals0.vm.bordDate = (CS_0024_003C_003E8__locals0.vm.bordDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.bordDateTime.Value.ToString("yyyy/MM/dd") : "");
					CS_0024_003C_003E8__locals0.vm.bordOrderDate = (CS_0024_003C_003E8__locals0.vm.bordOrderDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.bordOrderDateTime.Value.ToString("yyyy/MM/dd") : "");
					CS_0024_003C_003E8__locals0.vm.bordTaxClearedDatePersian = (CS_0024_003C_003E8__locals0.vm.bordTaxClearedDate.HasValue ? CS_0024_003C_003E8__locals0.vm.bordTaxClearedDate.Value.ToString("yyyy/MM/dd") : "");
					CS_0024_003C_003E8__locals0.vm.bordDeliveryDatePersian = (CS_0024_003C_003E8__locals0.vm.bordDeliveryDate.HasValue ? CS_0024_003C_003E8__locals0.vm.bordDeliveryDate.Value.ToString("yyyy/MM/dd") : "");
					CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDatePersian = (CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDate.HasValue ? CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDate.Value.ToString("yyyy/MM/dd") : "");
					CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDatePersian = (CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDate.HasValue ? CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDate.Value.ToString("yyyy/MM/dd") : "");
					return View(CS_0024_003C_003E8__locals0.vm);
				}
			}
			if (!base.ModelState.IsValid)
			{
				base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
			else
			{
				_003C_003Ec__DisplayClass32_1 _003C_003Ec__DisplayClass32_ = new _003C_003Ec__DisplayClass32_1();
				_003C_003Ec__DisplayClass32_.model = new WSBuyOrder();
				if (CS_0024_003C_003E8__locals0.vm.BuyOrderID > 0)
				{
					DbSet<WSBuyOrder> wSBuyOrder2 = _dbTbl.WSBuyOrder;
					ParameterExpression val = Expression.Parameter(typeof(WSBuyOrder), "c");
					_003C_003Ec__DisplayClass32_.model = Queryable.FirstOrDefault<WSBuyOrder>((IQueryable<WSBuyOrder>)wSBuyOrder2, Expression.Lambda<Func<WSBuyOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass32_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				_003C_003Ec__DisplayClass32_.model.UserId = UserLogin.CurrentUser.UserId;
				DateTime now = DateTime.Now;
				_003C_003Ec__DisplayClass32_.model.RegisterDate = now;
				_003C_003Ec__DisplayClass32_.model.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				_003C_003Ec__DisplayClass32_.model.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
				_003C_003Ec__DisplayClass32_.model.AppType = Configuration.AppType;
				_003C_003Ec__DisplayClass32_.model.BuyOrderOprId = CS_0024_003C_003E8__locals0.vm.BuyOrderOprId;
				_003C_003Ec__DisplayClass32_.model.PreBuyOrderId = CS_0024_003C_003E8__locals0.vm.PreBuyOrderId;
				_003C_003Ec__DisplayClass32_.model.PreBuyOrderVerifierId = CS_0024_003C_003E8__locals0.vm.PreBuyOrderVerifierId;
				_003C_003Ec__DisplayClass32_.model.bordNumber = CS_0024_003C_003E8__locals0.vm.bordNumber;
				_003C_003Ec__DisplayClass32_.model.bordOrderNumber = CS_0024_003C_003E8__locals0.vm.bordOrderNumber;
				_003C_003Ec__DisplayClass32_.model.bordDate = CS_0024_003C_003E8__locals0.vm.bordDate;
				_003C_003Ec__DisplayClass32_.model.bordOrderDate = CS_0024_003C_003E8__locals0.vm.bordOrderDate;
				_003C_003Ec__DisplayClass32_.model.bordOrderDateTime = CS_0024_003C_003E8__locals0.vm.bordOrderDateTime;
				_003C_003Ec__DisplayClass32_.model.bordCompanyId = CS_0024_003C_003E8__locals0.vm.bordCompanyId;
				_003C_003Ec__DisplayClass32_.model.bordCompanyPersonId = CS_0024_003C_003E8__locals0.vm.bordCompanyPersonId;
				_003C_003Ec__DisplayClass32_.model.bordProjectId = CS_0024_003C_003E8__locals0.vm.bordProjectId;
				_003C_003Ec__DisplayClass32_.model.bordItemCount = CS_0024_003C_003E8__locals0.vm.bordItemCount;
				_003C_003Ec__DisplayClass32_.model.bordItemsAmount = CS_0024_003C_003E8__locals0.vm.bordItemsAmount;
				_003C_003Ec__DisplayClass32_.model.bordDiscount = CS_0024_003C_003E8__locals0.vm.bordDiscount;
				_003C_003Ec__DisplayClass32_.model.bordSumAmount = CS_0024_003C_003E8__locals0.vm.bordSumAmount;
				_003C_003Ec__DisplayClass32_.model.bordTax = CS_0024_003C_003E8__locals0.vm.bordTax;
				_003C_003Ec__DisplayClass32_.model.bordTaxIndex = CS_0024_003C_003E8__locals0.vm.bordTaxIndex;
				_003C_003Ec__DisplayClass32_.model.bordCalculateTax = CS_0024_003C_003E8__locals0.vm.bordCalculateTax;
				_003C_003Ec__DisplayClass32_.model.bordTotalAmount = CS_0024_003C_003E8__locals0.vm.bordTotalAmount;
				_003C_003Ec__DisplayClass32_.model.bordIsVerified = CS_0024_003C_003E8__locals0.vm.bordIsVerified;
				_003C_003Ec__DisplayClass32_.model.bordStatusId = CS_0024_003C_003E8__locals0.vm.bordStatusId;
				_003C_003Ec__DisplayClass32_.model.bordIsFixed = CS_0024_003C_003E8__locals0.vm.bordIsFixed;
				_003C_003Ec__DisplayClass32_.model.bordPrintFormatId = CS_0024_003C_003E8__locals0.vm.bordPrintFormatId;
				_003C_003Ec__DisplayClass32_.model.bordImportDate = CS_0024_003C_003E8__locals0.vm.bordImportDate;
				_003C_003Ec__DisplayClass32_.model.bordVerifierId = CS_0024_003C_003E8__locals0.vm.bordVerifierId;
				_003C_003Ec__DisplayClass32_.model.bordVerifiedRegisterDate = CS_0024_003C_003E8__locals0.vm.bordVerifiedRegisterDate;
				_003C_003Ec__DisplayClass32_.model.bordVerifiedRegisterDatePersian = CS_0024_003C_003E8__locals0.vm.bordVerifiedRegisterDatePersian;
				_003C_003Ec__DisplayClass32_.model.bordSettlementTypeId = CS_0024_003C_003E8__locals0.vm.bordSettlementTypeId;
				_003C_003Ec__DisplayClass32_.model.bordDay = CS_0024_003C_003E8__locals0.vm.bordDay;
				_003C_003Ec__DisplayClass32_.model.bordTime = CS_0024_003C_003E8__locals0.vm.bordTime;
				_003C_003Ec__DisplayClass32_.model.bordTransportation = CS_0024_003C_003E8__locals0.vm.bordTransportation;
				_003C_003Ec__DisplayClass32_.model.bordReferUserId = CS_0024_003C_003E8__locals0.vm.bordReferUserId;
				_003C_003Ec__DisplayClass32_.model.bordRound = CS_0024_003C_003E8__locals0.vm.bordRound;
				_003C_003Ec__DisplayClass32_.model.bordDiscountPercent = CS_0024_003C_003E8__locals0.vm.bordDiscountPercent;
				_003C_003Ec__DisplayClass32_.model.bordDateTime = CS_0024_003C_003E8__locals0.vm.bordDateTime;
				_003C_003Ec__DisplayClass32_.model.bordImportDateTime = CS_0024_003C_003E8__locals0.vm.bordImportDateTime;
				_003C_003Ec__DisplayClass32_.model.bordTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass32_.model.bordSubject = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass32_.model.bordTotalAmountStr = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass32_.model.bordNote = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass32_.model.bordDiscountTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass32_.model.bordcmpTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass32_.model.bordItemCount = ((_003C_003Ec__DisplayClass32_.model.bordItemCount == 0) ? null : _003C_003Ec__DisplayClass32_.model.bordItemCount);
				WSBuyOrder model = _003C_003Ec__DisplayClass32_.model;
				decimal? bordItemsAmount = _003C_003Ec__DisplayClass32_.model.bordItemsAmount;
				model.bordItemsAmount = (((bordItemsAmount.GetValueOrDefault() == default(decimal)) & bordItemsAmount.HasValue) ? null : _003C_003Ec__DisplayClass32_.model.bordItemsAmount);
				WSBuyOrder model2 = _003C_003Ec__DisplayClass32_.model;
				bordItemsAmount = _003C_003Ec__DisplayClass32_.model.bordSumAmount;
				model2.bordSumAmount = (((bordItemsAmount.GetValueOrDefault() == default(decimal)) & bordItemsAmount.HasValue) ? null : _003C_003Ec__DisplayClass32_.model.bordSumAmount);
				WSBuyOrder model3 = _003C_003Ec__DisplayClass32_.model;
				bordItemsAmount = _003C_003Ec__DisplayClass32_.model.bordTax;
				model3.bordTax = (((bordItemsAmount.GetValueOrDefault() == default(decimal)) & bordItemsAmount.HasValue) ? null : _003C_003Ec__DisplayClass32_.model.bordTax);
				bordItemsAmount = _003C_003Ec__DisplayClass32_.model.bordTotalAmount;
				if ((bordItemsAmount.GetValueOrDefault() == default(decimal)) & bordItemsAmount.HasValue)
				{
					_003C_003Ec__DisplayClass32_.model.bordTotalAmount = null;
					_003C_003Ec__DisplayClass32_.model.bordTotalAmountStr = null;
				}
				WSBuyOrder model4 = _003C_003Ec__DisplayClass32_.model;
				bordItemsAmount = _003C_003Ec__DisplayClass32_.model.bordDiscountPercent;
				model4.bordDiscountPercent = (((bordItemsAmount.GetValueOrDefault() == default(decimal)) & bordItemsAmount.HasValue) ? null : _003C_003Ec__DisplayClass32_.model.bordDiscountPercent);
				_003C_003Ec__DisplayClass32_.model.bordTransportation = _003C_003Ec__DisplayClass32_.model.bordTransportation.GetValueOrDefault();
				_003C_003Ec__DisplayClass32_.model.bordRound = _003C_003Ec__DisplayClass32_.model.bordRound.GetValueOrDefault();
				_003C_003Ec__DisplayClass32_.model.bordDiscount = _003C_003Ec__DisplayClass32_.model.bordDiscount.GetValueOrDefault();
				_003C_003Ec__DisplayClass32_.model.bordCompanyPersonId = ((_003C_003Ec__DisplayClass32_.model.bordCompanyPersonId <= 0) ? null : _003C_003Ec__DisplayClass32_.model.bordCompanyPersonId);
				int result2 = 0;
				int.TryParse(_003C_003Ec__DisplayClass32_.model.bordCurrencyUnitId.ToString(), out result2);
				_003C_003Ec__DisplayClass32_.model.bordCurrencyUnitId = CS_0024_003C_003E8__locals0.vm.bordCurrencyUnitId;
				_003C_003Ec__DisplayClass32_.model.bordCurrencyUnitIdI = CS_0024_003C_003E8__locals0.vm.bordCurrencyUnitIdI;
				_003C_003Ec__DisplayClass32_.model.bordCurrencyUnitIRate = CS_0024_003C_003E8__locals0.vm.bordCurrencyUnitIRate;
				_003C_003Ec__DisplayClass32_.model.bordFacilityCmpId = CS_0024_003C_003E8__locals0.vm.bordFacilityCmpId;
				_003C_003Ec__DisplayClass32_.model.bordFacilityPrsId = CS_0024_003C_003E8__locals0.vm.bordFacilityPrsId;
				_003C_003Ec__DisplayClass32_.model.bordFacilityPrjId = CS_0024_003C_003E8__locals0.vm.bordFacilityPrjId;
				_003C_003Ec__DisplayClass32_.model.bordReqCmpId = CS_0024_003C_003E8__locals0.vm.bordReqCmpId;
				_003C_003Ec__DisplayClass32_.model.bordReqPrsId = CS_0024_003C_003E8__locals0.vm.bordReqPrsId;
				_003C_003Ec__DisplayClass32_.model.bordReqPrjId = CS_0024_003C_003E8__locals0.vm.bordReqPrjId;
				_003C_003Ec__DisplayClass32_.model.bordDeliveryTerm = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass32_.model.bordDeliveryDate = CS_0024_003C_003E8__locals0.vm.bordDeliveryDate;
				_003C_003Ec__DisplayClass32_.model.bordDeliveryDatePersian = CS_0024_003C_003E8__locals0.vm.bordDeliveryDatePersian;
				_003C_003Ec__DisplayClass32_.model.bordTaxCleared = CS_0024_003C_003E8__locals0.vm.bordTaxCleared;
				_003C_003Ec__DisplayClass32_.model.bordTaxClearedDate = CS_0024_003C_003E8__locals0.vm.bordTaxClearedDate;
				_003C_003Ec__DisplayClass32_.model.bordTaxClearedDatePersian = CS_0024_003C_003E8__locals0.vm.bordTaxClearedDatePersian;
				_003C_003Ec__DisplayClass32_.model.bordFacilityCost = CS_0024_003C_003E8__locals0.vm.bordFacilityCost.GetValueOrDefault();
				WSBuyOrder model5 = _003C_003Ec__DisplayClass32_.model;
				bordItemsAmount = CS_0024_003C_003E8__locals0.vm.bordFacilityCostPercent;
				model5.bordFacilityCostPercent = (((bordItemsAmount.GetValueOrDefault() == default(decimal)) & bordItemsAmount.HasValue) ? null : CS_0024_003C_003E8__locals0.vm.bordFacilityCostPercent);
				_003C_003Ec__DisplayClass32_.model.bordSupplierDeliveryDate = CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDate;
				_003C_003Ec__DisplayClass32_.model.bordSupplierDeliveryDatePersian = CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDatePersian;
				_003C_003Ec__DisplayClass32_.model.bordForwarderName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass32_.model.bordFreightCost = CS_0024_003C_003E8__locals0.vm.bordFreightCost.GetValueOrDefault();
				_003C_003Ec__DisplayClass32_.model.bordFreightCurrUnId = CS_0024_003C_003E8__locals0.vm.bordFreightCurrUnId;
				_003C_003Ec__DisplayClass32_.model.bordFreightCurrencyRate = CS_0024_003C_003E8__locals0.vm.bordFreightCurrencyRate;
				_003C_003Ec__DisplayClass32_.model.bordFinalFreightCost = CS_0024_003C_003E8__locals0.vm.bordFinalFreightCost.GetValueOrDefault();
				_003C_003Ec__DisplayClass32_.model.bordCustomsPart = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass32_.model.bordCustomsFee = CS_0024_003C_003E8__locals0.vm.bordCustomsFee.GetValueOrDefault();
				_003C_003Ec__DisplayClass32_.model.bordCustomsCurrUnId = CS_0024_003C_003E8__locals0.vm.bordCustomsCurrUnId;
				_003C_003Ec__DisplayClass32_.model.bordCustomsCurrencyRate = CS_0024_003C_003E8__locals0.vm.bordCustomsCurrencyRate;
				_003C_003Ec__DisplayClass32_.model.bordFinalCustomsFee = CS_0024_003C_003E8__locals0.vm.bordFinalCustomsFee.GetValueOrDefault();
				_003C_003Ec__DisplayClass32_.model.bordFinalDeliveryDate = CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDate;
				_003C_003Ec__DisplayClass32_.model.bordFinalDeliveryDatePersian = CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDatePersian;
				_003C_003Ec__DisplayClass32_.model.bordCommission = CS_0024_003C_003E8__locals0.vm.bordCommission.GetValueOrDefault();
				_003C_003Ec__DisplayClass32_.model.bordCommissionCurrUnId = CS_0024_003C_003E8__locals0.vm.bordCommissionCurrUnId;
				_003C_003Ec__DisplayClass32_.model.bordCommissionCurrencyRate = CS_0024_003C_003E8__locals0.vm.bordCommissionCurrencyRate;
				_003C_003Ec__DisplayClass32_.model.bordFinalCommission = CS_0024_003C_003E8__locals0.vm.bordFinalCommission.GetValueOrDefault();
				_003C_003Ec__DisplayClass32_.model.bordSuppUserId = ((CS_0024_003C_003E8__locals0.vm.bordSuppUserId == 0) ? null : CS_0024_003C_003E8__locals0.vm.bordSuppUserId);
				decimal valueOrDefault = CS_0024_003C_003E8__locals0.vm.bordFacilityCost.GetValueOrDefault();
				decimal valueOrDefault2 = CS_0024_003C_003E8__locals0.vm.bordFreightCost.GetValueOrDefault();
				double valueOrDefault3 = CS_0024_003C_003E8__locals0.vm.bordFreightCurrencyRate.GetValueOrDefault(1.0);
				decimal num3 = valueOrDefault2 * (decimal)valueOrDefault3;
				decimal valueOrDefault4 = CS_0024_003C_003E8__locals0.vm.bordCustomsFee.GetValueOrDefault();
				double valueOrDefault5 = CS_0024_003C_003E8__locals0.vm.bordCustomsCurrencyRate.GetValueOrDefault(1.0);
				decimal num4 = valueOrDefault4 * (decimal)valueOrDefault5;
				decimal valueOrDefault6 = CS_0024_003C_003E8__locals0.vm.bordCommission.GetValueOrDefault();
				double valueOrDefault7 = CS_0024_003C_003E8__locals0.vm.bordCommissionCurrencyRate.GetValueOrDefault(1.0);
				decimal num5 = valueOrDefault6 * (decimal)valueOrDefault7;
				decimal value = valueOrDefault + num3 + num4 + num5;
				_003C_003Ec__DisplayClass32_.model.bordFacilityCost = valueOrDefault;
				_003C_003Ec__DisplayClass32_.model.bordFreightCost = valueOrDefault2;
				_003C_003Ec__DisplayClass32_.model.bordFreightCurrencyRate = valueOrDefault3;
				_003C_003Ec__DisplayClass32_.model.bordFinalFreightCost = num3;
				_003C_003Ec__DisplayClass32_.model.bordCustomsFee = valueOrDefault4;
				_003C_003Ec__DisplayClass32_.model.bordCustomsCurrencyRate = valueOrDefault5;
				_003C_003Ec__DisplayClass32_.model.bordFinalCustomsFee = num4;
				_003C_003Ec__DisplayClass32_.model.bordCommission = valueOrDefault6;
				_003C_003Ec__DisplayClass32_.model.bordCommissionCurrencyRate = valueOrDefault7;
				_003C_003Ec__DisplayClass32_.model.bordFinalCommission = num5;
				_003C_003Ec__DisplayClass32_.model.bordTotalFinalCost = value;
				_003C_003Ec__DisplayClass32_.model.bordDefaultSettingId = CS_0024_003C_003E8__locals0.vm.bordDefaultSettingId;
				_003C_003Ec__DisplayClass32_.model.bordVerificationWorkFlowId = CS_0024_003C_003E8__locals0.vm.bordVerificationWorkFlowId;
				if (_003C_003Ec__DisplayClass32_.model.BuyOrderID > 0)
				{
					if (UserLogin.IsUserAccess("frmBuyOrderDataEntry", "actCanChangeNumRef", UserLogin.CurrentUser))
					{
						_003C_003Ec__DisplayClass32_.model.bordNumRef = CS_0024_003C_003E8__locals0.vm.bordNumRef;
					}
					long result3 = 0L;
					long.TryParse(_003C_003Ec__DisplayClass32_.model.bordNumber.ToString(), out result3);
					if (CheckDuplicateOrderNumber(result3, _003C_003Ec__DisplayClass32_.model.BuyOrderID, _003C_003Ec__DisplayClass32_.model.BuyOrderOprId, _003C_003Ec__DisplayClass32_.model.bordCId) > 0)
					{
						base.ViewBag.Error = Messages.BuyOrderNumberIsRepeated;
						CS_0024_003C_003E8__locals0.vm.bordDate = (CS_0024_003C_003E8__locals0.vm.bordDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.bordDateTime.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.vm.bordOrderDate = (CS_0024_003C_003E8__locals0.vm.bordOrderDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.bordOrderDateTime.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.vm.bordTaxClearedDatePersian = (CS_0024_003C_003E8__locals0.vm.bordTaxClearedDate.HasValue ? CS_0024_003C_003E8__locals0.vm.bordTaxClearedDate.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.vm.bordDeliveryDatePersian = (CS_0024_003C_003E8__locals0.vm.bordDeliveryDate.HasValue ? CS_0024_003C_003E8__locals0.vm.bordDeliveryDate.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDatePersian = (CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDate.HasValue ? CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDate.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDatePersian = (CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDate.HasValue ? CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDate.Value.ToString("yyyy/MM/dd") : "");
						return View(CS_0024_003C_003E8__locals0.vm);
					}
					_dbTbl.Entry(_003C_003Ec__DisplayClass32_.model).State = EntityState.Modified;
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					if (!BuyOrder.CalcAndSetOrderAmounts(_003C_003Ec__DisplayClass32_.model))
					{
						base.ViewBag.Error = Messages.CalcAndSetBuyOrderErrorMessage;
					}
					else
					{
						using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								_003C_003Ec__DisplayClass32_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass32_2();
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass32_;
								CS_0024_003C_003E8__locals1.lang = enumerator.Current;
								DbSet<WSBuyOrder_Lang> wSBuyOrder_Lang = _dbTbl.WSBuyOrder_Lang;
								ParameterExpression val = Expression.Parameter(typeof(WSBuyOrder_Lang), "c");
								WSBuyOrder_Lang wSBuyOrder_Lang2 = Queryable.FirstOrDefault<WSBuyOrder_Lang>((IQueryable<WSBuyOrder_Lang>)wSBuyOrder_Lang, Expression.Lambda<Func<WSBuyOrder_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass32_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass32_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (wSBuyOrder_Lang2 != null)
								{
									wSBuyOrder_Lang2.bordTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									wSBuyOrder_Lang2.bordSubject = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									wSBuyOrder_Lang2.bordTotalAmountStr = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									wSBuyOrder_Lang2.bordNote = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									wSBuyOrder_Lang2.bordDiscountTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									wSBuyOrder_Lang2.bordcmpTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									wSBuyOrder_Lang2.bordDeliveryTerm = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									wSBuyOrder_Lang2.bordForwarderName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									wSBuyOrder_Lang2.bordCustomsPart = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									_dbTbl.Entry(wSBuyOrder_Lang2).State = EntityState.Modified;
									_dbTbl.SaveChanges();
									continue;
								}
								wSBuyOrder_Lang2 = new WSBuyOrder_Lang();
								wSBuyOrder_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
								wSBuyOrder_Lang2.BuyOrderID = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.BuyOrderID;
								wSBuyOrder_Lang2.bordTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSBuyOrder_Lang2.bordSubject = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSBuyOrder_Lang2.bordTotalAmountStr = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSBuyOrder_Lang2.bordNote = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSBuyOrder_Lang2.bordDiscountTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSBuyOrder_Lang2.bordcmpTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSBuyOrder_Lang2.bordDeliveryTerm = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSBuyOrder_Lang2.bordForwarderName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSBuyOrder_Lang2.bordCustomsPart = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.WSBuyOrder_Lang.Add(wSBuyOrder_Lang2);
								_dbTbl.SaveChanges();
							}
						}
						if (result2 != 0)
						{
							int result4 = 0;
							int.TryParse(_003C_003Ec__DisplayClass32_.model.bordCurrencyUnitId.ToString(), out result4);
							if (result2 != result4 && result4 != 0)
							{
								_dbI.WSspUpdateBuyOrderItemCurrencyUnitId(_003C_003Ec__DisplayClass32_.model.BuyOrderID, result4, UserLogin.CurrentUser.UserId, short.Parse(now.ToString("MM", new PersianCulture())), now, now.ToString("yyyyMMdd", new PersianCulture()), Configuration.AppType);
							}
						}
						if (_003C_003Ec__DisplayClass32_.model.BuyOrderID > 0 && _003C_003Ec__DisplayClass32_.model.bordTax.HasValue)
						{
							WSspGetBuyOrderTax_Result wSspGetBuyOrderTax_Result = Enumerable.FirstOrDefault<WSspGetBuyOrderTax_Result>((IEnumerable<WSspGetBuyOrderTax_Result>)_dbI.WSspGetBuyOrderTax(_003C_003Ec__DisplayClass32_.model.BuyOrderID));
							if (wSspGetBuyOrderTax_Result != null)
							{
								decimal valueOrDefault8 = wSspGetBuyOrderTax_Result.bordTax.GetValueOrDefault();
								bordItemsAmount = _003C_003Ec__DisplayClass32_.model.bordTax;
								decimal num6 = valueOrDefault8;
								if (!((bordItemsAmount.GetValueOrDefault() == num6) & bordItemsAmount.HasValue))
								{
									base.ViewBag.ErrorBordTax = Messages.msgErrorCalcBordTaxNotMatchEnteredBordTax;
									return View(CS_0024_003C_003E8__locals0.vm);
								}
							}
						}
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					}
				}
				else
				{
					_003C_003Ec__DisplayClass32_.model.FPId = Financial.Get().Id;
					long num7 = 0L;
					bool flag = false;
					int num8 = 0;
					while (!flag)
					{
						num7 = Enumerable.FirstOrDefault<long>((IEnumerable<long>)Enumerable.ToList<long>(_db.Database.SqlQuery<long>($"Select dbo.WSfnReturnBuyOrderNumber({_003C_003Ec__DisplayClass32_.model.BuyOrderOprId},{num.GetValueOrDefault()})", Array.Empty<object>())));
						_003C_003Ec__DisplayClass32_.model.bordNumber = num7;
						num2 = _003C_003Ec__DisplayClass32_.model.bordNumber;
						flag = ReservedNumber.AddNumber(sysPartId, num2);
						num8++;
						if (num8 > 10)
						{
							break;
						}
					}
					long result5 = 0L;
					long.TryParse(_003C_003Ec__DisplayClass32_.model.bordNumber.ToString(), out result5);
					if (CheckDuplicateOrderNumber(result5, 0, _003C_003Ec__DisplayClass32_.model.BuyOrderOprId, num) > 0)
					{
						base.ViewBag.Error = Messages.BuyOrderNumberIsRepeated;
						CS_0024_003C_003E8__locals0.vm.bordDate = (CS_0024_003C_003E8__locals0.vm.bordDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.bordDateTime.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.vm.bordOrderDate = (CS_0024_003C_003E8__locals0.vm.bordOrderDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.bordOrderDateTime.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.vm.bordTaxClearedDatePersian = (CS_0024_003C_003E8__locals0.vm.bordTaxClearedDate.HasValue ? CS_0024_003C_003E8__locals0.vm.bordTaxClearedDate.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.vm.bordDeliveryDatePersian = (CS_0024_003C_003E8__locals0.vm.bordDeliveryDate.HasValue ? CS_0024_003C_003E8__locals0.vm.bordDeliveryDate.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDatePersian = (CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDate.HasValue ? CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDate.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDatePersian = (CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDate.HasValue ? CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDate.Value.ToString("yyyy/MM/dd") : "");
						ReservedNumber.UpdateNumber(sysPartId, num2);
						if (!string.IsNullOrWhiteSpace(text4))
						{
							ReservedNumber.UpdateNumber(sysPartId, 0, text4);
						}
						return View(CS_0024_003C_003E8__locals0.vm);
					}
					if (UserLogin.IsUserAccess("frmBuyOrderDataEntry", "actAutoCalcNumRef", UserLogin.CurrentUser))
					{
						flag = false;
						num8 = 0;
						while (!flag)
						{
							string bordNumRef = Enumerable.FirstOrDefault<string>((IEnumerable<string>)_db.WSspReturnBuyOrderNumRef(_003C_003Ec__DisplayClass32_.model.bordCompanyId, _003C_003Ec__DisplayClass32_.model.bordProjectId, _003C_003Ec__DisplayClass32_.model.bordReferUserId, _003C_003Ec__DisplayClass32_.model.bordNumber, lCID, CS_0024_003C_003E8__locals0.defLangID, num));
							_003C_003Ec__DisplayClass32_.model.bordNumRef = bordNumRef;
							text4 = _003C_003Ec__DisplayClass32_.model.bordNumRef;
							flag = string.IsNullOrWhiteSpace(text4) || !UserLogin.IsUserAccess("frmBuyOrderDataEntry", "actNotDupNumRef", UserLogin.CurrentUser) || ReservedNumber.AddNumber(sysPartId, 0, text4);
							num8++;
							if (num8 > 10)
							{
								break;
							}
						}
					}
					else
					{
						_003C_003Ec__DisplayClass32_.model.bordNumRef = CS_0024_003C_003E8__locals0.vm.bordNumRef;
					}
					if (!string.IsNullOrEmpty(_003C_003Ec__DisplayClass32_.model.bordNumRef) && UserLogin.IsUserAccess("frmBuyOrderDataEntry", "actNotDupNumRef", UserLogin.CurrentUser))
					{
						WSspCheckDuplicateBuyOrderNumRef_Result wSspCheckDuplicateBuyOrderNumRef_Result2 = Enumerable.FirstOrDefault<WSspCheckDuplicateBuyOrderNumRef_Result>((IEnumerable<WSspCheckDuplicateBuyOrderNumRef_Result>)_db.WSspCheckDuplicateBuyOrderNumRef(_003C_003Ec__DisplayClass32_.model.bordNumRef, _003C_003Ec__DisplayClass32_.model.BuyOrderID, _003C_003Ec__DisplayClass32_.model.BuyOrderOprId, num));
						if (wSspCheckDuplicateBuyOrderNumRef_Result2 != null)
						{
							base.ViewBag.Error = string.Format(Messages.BuyOrderNumRefIsRepeated, wSspCheckDuplicateBuyOrderNumRef_Result2.bordNumber.ToString());
							CS_0024_003C_003E8__locals0.vm.bordDate = (CS_0024_003C_003E8__locals0.vm.bordDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.bordDateTime.Value.ToString("yyyy/MM/dd") : "");
							CS_0024_003C_003E8__locals0.vm.bordOrderDate = (CS_0024_003C_003E8__locals0.vm.bordOrderDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.bordOrderDateTime.Value.ToString("yyyy/MM/dd") : "");
							CS_0024_003C_003E8__locals0.vm.bordTaxClearedDatePersian = (CS_0024_003C_003E8__locals0.vm.bordTaxClearedDate.HasValue ? CS_0024_003C_003E8__locals0.vm.bordTaxClearedDate.Value.ToString("yyyy/MM/dd") : "");
							CS_0024_003C_003E8__locals0.vm.bordDeliveryDatePersian = (CS_0024_003C_003E8__locals0.vm.bordDeliveryDate.HasValue ? CS_0024_003C_003E8__locals0.vm.bordDeliveryDate.Value.ToString("yyyy/MM/dd") : "");
							CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDatePersian = (CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDate.HasValue ? CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDate.Value.ToString("yyyy/MM/dd") : "");
							CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDatePersian = (CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDate.HasValue ? CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDate.Value.ToString("yyyy/MM/dd") : "");
							ReservedNumber.UpdateNumber(sysPartId, num2);
							if (!string.IsNullOrWhiteSpace(text4))
							{
								ReservedNumber.UpdateNumber(sysPartId, 0, text4);
							}
							return View(CS_0024_003C_003E8__locals0.vm);
						}
					}
					DateTime now2 = DateTime.Now;
					_003C_003Ec__DisplayClass32_.model.bordFirstRegisterUserId = CS_0024_003C_003E8__locals0.vm.bordFirstRegisterUserId;
					_003C_003Ec__DisplayClass32_.model.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
					_003C_003Ec__DisplayClass32_.model.FirstRegisterDate = now2;
					_003C_003Ec__DisplayClass32_.model.FirstRegisterDatePersian = now2.ToString("yyyyMMdd", new PersianCulture());
					_003C_003Ec__DisplayClass32_.model.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
					_003C_003Ec__DisplayClass32_.model.GUId = System.Guid.NewGuid();
					_003C_003Ec__DisplayClass32_.model.bordCId = num;
					_dbTbl.WSBuyOrder.Add(_003C_003Ec__DisplayClass32_.model);
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					num2 = (ReservedNumber.RemoveNumber(sysPartId, num2) ? 0 : num2);
					if (!string.IsNullOrWhiteSpace(text4))
					{
						text4 = (ReservedNumber.RemoveNumber(sysPartId, 0, text4) ? "" : text4);
					}
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
					{
						WSBuyOrder_Lang wSBuyOrder_Lang3 = new WSBuyOrder_Lang();
						wSBuyOrder_Lang3.LanguageID = lang.LanguageID;
						wSBuyOrder_Lang3.BuyOrderID = _003C_003Ec__DisplayClass32_.model.BuyOrderID;
						wSBuyOrder_Lang3.bordTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSBuyOrder_Lang3.bordSubject = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSBuyOrder_Lang3.bordTotalAmountStr = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSBuyOrder_Lang3.bordNote = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSBuyOrder_Lang3.bordDiscountTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSBuyOrder_Lang3.bordcmpTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSBuyOrder_Lang3.bordDeliveryTerm = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSBuyOrder_Lang3.bordForwarderName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSBuyOrder_Lang3.bordCustomsPart = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						_dbTbl.WSBuyOrder_Lang.Add(wSBuyOrder_Lang3);
						_dbTbl.SaveChanges();
					}
					CS_0024_003C_003E8__locals0.vm.BuyOrderID = _003C_003Ec__DisplayClass32_.model.BuyOrderID;
					if (_003C_003Ec__DisplayClass32_.model.BuyOrderID != 0)
					{
						_dbII.WSspCalcAndUpdateBuyOrderAmountsCurrency(_003C_003Ec__DisplayClass32_.model.BuyOrderID, lCID, CS_0024_003C_003E8__locals0.defLangID);
					}
					base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
				}
			}
		}
		catch (DbEntityValidationException e7)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e7);
			base.ViewBag.Error = Messages.frmErrorMessage;
		}
		catch (Exception e8)
		{
			ErrorSignal.FromCurrentContext().Raise(e8);
			base.ViewBag.Error = Messages.frmErrorMessage;
		}
		CS_0024_003C_003E8__locals0.vm.bordDate = (CS_0024_003C_003E8__locals0.vm.bordDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.bordDateTime.Value.ToString("yyyy/MM/dd") : CS_0024_003C_003E8__locals0.vm.bordDate);
		CS_0024_003C_003E8__locals0.vm.bordOrderDate = (CS_0024_003C_003E8__locals0.vm.bordOrderDateTime.HasValue ? CS_0024_003C_003E8__locals0.vm.bordOrderDateTime.Value.ToString("yyyy/MM/dd") : (CS_0024_003C_003E8__locals0.vm.bordOrderDate ?? ""));
		CS_0024_003C_003E8__locals0.vm.bordTaxClearedDatePersian = (CS_0024_003C_003E8__locals0.vm.bordTaxClearedDate.HasValue ? CS_0024_003C_003E8__locals0.vm.bordTaxClearedDate.Value.ToString("yyyy/MM/dd") : (CS_0024_003C_003E8__locals0.vm.bordTaxClearedDatePersian ?? ""));
		CS_0024_003C_003E8__locals0.vm.bordDeliveryDatePersian = (CS_0024_003C_003E8__locals0.vm.bordDeliveryDate.HasValue ? CS_0024_003C_003E8__locals0.vm.bordDeliveryDate.Value.ToString("yyyy/MM/dd") : (CS_0024_003C_003E8__locals0.vm.bordDeliveryDatePersian ?? ""));
		CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDatePersian = (CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDate.HasValue ? CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDate.Value.ToString("yyyy/MM/dd") : (CS_0024_003C_003E8__locals0.vm.bordSupplierDeliveryDatePersian ?? ""));
		CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDatePersian = (CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDate.HasValue ? CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDate.Value.ToString("yyyy/MM/dd") : (CS_0024_003C_003E8__locals0.vm.bordFinalDeliveryDatePersian ?? ""));
		if (num2 != 0L)
		{
			ReservedNumber.RemoveNumber(sysPartId, num2);
		}
		if (!string.IsNullOrWhiteSpace(text4))
		{
			ReservedNumber.RemoveNumber(sysPartId, 0, text4);
		}
		return View(CS_0024_003C_003E8__locals0.vm);
	}

	[AjaxOnly]
	public string GetOrderNumber(int buyOrderOprId, int? cId = null)
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
			result = Enumerable.FirstOrDefault<long>((IEnumerable<long>)Enumerable.ToList<long>(_db.Database.SqlQuery<long>($"Select dbo.WSfnReturnBuyOrderNumber({buyOrderOprId},{num.GetValueOrDefault()})", Array.Empty<object>()))).ToString();
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
	public JsonResult OrderItemTax(int borderId)
	{
		decimal valueOrDefault = Enumerable.FirstOrDefault<decimal?>((IEnumerable<decimal?>)Enumerable.ToList<decimal?>(_db.Database.SqlQuery<decimal?>($"Select * from dbo.WSfnReturnBuyOrderItemTax({borderId})", Array.Empty<object>()))).GetValueOrDefault();
		return Json(valueOrDefault, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public long CheckDuplicateOrderNumber(long borderNumber, int borderId, int? oprId, int? cId = null)
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
			long? num2 = Enumerable.FirstOrDefault<long?>((IEnumerable<long?>)Enumerable.ToList<long?>((IEnumerable<long?>)_db.WSfnCheckDuplicateBuyOrderNumber(borderNumber, borderId, oprId, cId)));
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

	[AjaxOnly]
	public JsonResult GetBuyOrderOpr()
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
			List<WSspSelectBuyOrderOpr_Result> list2 = BuyOrder.SelectBuyOrderOpr();
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<WSspSelectBuyOrderOpr_Result, SelectListItem>((IEnumerable<WSspSelectBuyOrderOpr_Result>)list2, (Func<WSspSelectBuyOrderOpr_Result, SelectListItem>)((WSspSelectBuyOrderOpr_Result item) => new SelectListItem
				{
					Text = item.Name,
					Value = item.BuyOrderOprID.ToString(),
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
		base.ViewBag.BuyOrderOprList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetBuyOrdStatus()
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
			List<WSspSelectBuyOrderStatus_Result> list2 = Enumerable.ToList<WSspSelectBuyOrderStatus_Result>((IEnumerable<WSspSelectBuyOrderStatus_Result>)_db.WSspSelectBuyOrderStatus(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectBuyOrderStatus_Result, SelectListItem>((IEnumerable<WSspSelectBuyOrderStatus_Result>)list2, (Func<WSspSelectBuyOrderStatus_Result, SelectListItem>)((WSspSelectBuyOrderStatus_Result item) => new SelectListItem
			{
				Text = item.BuyOrderStatus,
				Value = item.BuyOrderStatusId.ToString(),
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
		base.ViewBag.BuyOrdStatusList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetBuyOrdPrintFormat()
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
			List<CRMspSelectPrintFormatByTypeId_Result> printFortants = CRMIdeal.Classes.Helper.PrintFormat.GetPrintFortants(result2, 5);
			list.AddRange(Enumerable.Select<CRMspSelectPrintFormatByTypeId_Result, SelectListItem>((IEnumerable<CRMspSelectPrintFormatByTypeId_Result>)printFortants, (Func<CRMspSelectPrintFormatByTypeId_Result, SelectListItem>)((CRMspSelectPrintFormatByTypeId_Result item) => new SelectListItem
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
		base.ViewBag.BuyOrdPrintFormatList = list;
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
		base.ViewBag.FreightCurrUnList = list;
		base.ViewBag.CustomsCurrUnList = list;
		base.ViewBag.CommissionCurrUnList = list;
		base.ViewBag.CurrencyUnitListI = list2;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetBordDefSetting()
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
			int userId = UserLogin.CurrentUser.UserId;
			List<WSspSelectBuyOrderDefaultSettingByReferUserIdAndIsPublic_Result> list2 = Enumerable.ToList<WSspSelectBuyOrderDefaultSettingByReferUserIdAndIsPublic_Result>((IEnumerable<WSspSelectBuyOrderDefaultSettingByReferUserIdAndIsPublic_Result>)_dbII.WSspSelectBuyOrderDefaultSettingByReferUserIdAndIsPublic(userId, lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectBuyOrderDefaultSettingByReferUserIdAndIsPublic_Result, SelectListItem>((IEnumerable<WSspSelectBuyOrderDefaultSettingByReferUserIdAndIsPublic_Result>)list2, (Func<WSspSelectBuyOrderDefaultSettingByReferUserIdAndIsPublic_Result, SelectListItem>)((WSspSelectBuyOrderDefaultSettingByReferUserIdAndIsPublic_Result item) => new SelectListItem
			{
				Text = item.SettingTitle,
				Value = item.BuyOrderDefaultSettingId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.bordDefSettingList = list;
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
			List<WSspSelectVerificationWorkFlowWithObjectType_Result> list2 = Enumerable.ToList<WSspSelectVerificationWorkFlowWithObjectType_Result>((IEnumerable<WSspSelectVerificationWorkFlowWithObjectType_Result>)_db.WSspSelectVerificationWorkFlowWithObjectType(40, lCID, result));
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
	[DynamicAuthorize(ControllerName = "frmBuyOrder", ActionName = "actRemoveProduct")]
	public string RemoveProduct(int bordItemId, int bordId)
	{
		_003C_003Ec__DisplayClass42_0 _003C_003Ec__DisplayClass42_ = new _003C_003Ec__DisplayClass42_0();
		_003C_003Ec__DisplayClass42_.bordItemId = bordItemId;
		string result = "";
		try
		{
			if (BuyOrder.IsFixed(bordId))
			{
				return Messages.msgErrorNotActiveBOrd;
			}
			if (BuyOrder.IsSentToLinkAccByAction(bordId))
			{
				string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
				return string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
			}
			if (_003C_003Ec__DisplayClass42_.bordItemId > 0)
			{
				DbSet<WSBuyOrderItems> wSBuyOrderItems = _dbTbl.WSBuyOrderItems;
				ParameterExpression val = Expression.Parameter(typeof(WSBuyOrderItems), "c");
				if (Queryable.FirstOrDefault<WSBuyOrderItems>((IQueryable<WSBuyOrderItems>)wSBuyOrderItems, Expression.Lambda<Func<WSBuyOrderItems, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass42_, typeof(_003C_003Ec__DisplayClass42_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
				{
					try
					{
						mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)Enumerable.ToList<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteWSBuyOrderItems(_003C_003Ec__DisplayClass42_.bordItemId)));
						if (mct_Result != null && mct_Result.Result > 0)
						{
							result = (BuyOrder.CalcAndSetOrderAmounts(bordId) ? "1" : Messages.msgErrorInCalculation);
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
	[DynamicAuthorize(ControllerName = "frmBuyOrder", ActionName = "actRemoveProductAll")]
	public string RemoveProductAll(int bordItemId)
	{
		_003C_003Ec__DisplayClass43_0 _003C_003Ec__DisplayClass43_ = new _003C_003Ec__DisplayClass43_0();
		_003C_003Ec__DisplayClass43_.bordItemId = bordItemId;
		string result = "";
		try
		{
			if (_003C_003Ec__DisplayClass43_.bordItemId > 0)
			{
				DbSet<WSBuyOrderItems> wSBuyOrderItems = _dbTbl.WSBuyOrderItems;
				ParameterExpression val = Expression.Parameter(typeof(WSBuyOrderItems), "c");
				WSBuyOrderItems wSBuyOrderItems2 = Queryable.FirstOrDefault<WSBuyOrderItems>((IQueryable<WSBuyOrderItems>)wSBuyOrderItems, Expression.Lambda<Func<WSBuyOrderItems, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass43_, typeof(_003C_003Ec__DisplayClass43_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (wSBuyOrderItems2 != null)
				{
					try
					{
						if (BuyOrder.IsFixed(wSBuyOrderItems2.BuyOrderId))
						{
							return Messages.msgErrorNotActiveBOrd;
						}
						if (BuyOrder.IsSentToLinkAccByAction(wSBuyOrderItems2.BuyOrderId))
						{
							string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
							return string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
						}
						mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)Enumerable.ToList<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.WSspDeleteBuyOrderItemsAll(wSBuyOrderItems2.BuyOrderId)));
						if (mct_I_Result != null && mct_I_Result.Result > 0)
						{
							result = (BuyOrder.CalcAndSetOrderAmounts(wSBuyOrderItems2.BuyOrderId) ? "1" : Messages.msgErrorInCalculation);
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
	public JsonResult GetSumBuyOrderPay(int preOrderId)
	{
		WSspReturnSumBuyOrderPay_Result data = new WSspReturnSumBuyOrderPay_Result();
		try
		{
			WSspReturnSumBuyOrderPay_Result wSspReturnSumBuyOrderPay_Result = Enumerable.FirstOrDefault<WSspReturnSumBuyOrderPay_Result>((IEnumerable<WSspReturnSumBuyOrderPay_Result>)Enumerable.ToList<WSspReturnSumBuyOrderPay_Result>((IEnumerable<WSspReturnSumBuyOrderPay_Result>)_db.WSspReturnSumBuyOrderPay(preOrderId)));
			if (wSspReturnSumBuyOrderPay_Result != null)
			{
				data = new WSspReturnSumBuyOrderPay_Result
				{
					bordTotalAmount = wSspReturnSumBuyOrderPay_Result.bordTotalAmount,
					RemainordAmount = wSspReturnSumBuyOrderPay_Result.RemainordAmount,
					sumbordpayAmount = wSspReturnSumBuyOrderPay_Result.sumbordpayAmount,
					RemainOlderordsAmount = wSspReturnSumBuyOrderPay_Result.RemainOlderordsAmount
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
	public int UpdateAndCalcBordTax(int bordId, decimal bordTax)
	{
		int result = -1;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		if (result2 <= 0)
		{
			result2 = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			if (BuyOrder.CalcAndSetOrderAmountsWithTax(bordId, bordTax))
			{
				result = 1;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[AjaxOnly]
	public JsonResult GetBuyOrderDefaultSetting(int defSettingId)
	{
		_003C_003Ec__DisplayClass46_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass46_0();
		CS_0024_003C_003E8__locals0.defSettingId = defSettingId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		WSBuyOrderDefaultSettingLanguageViewModel data = new WSBuyOrderDefaultSettingLanguageViewModel();
		try
		{
			DbSet<WSBuyOrderDefaultSetting> wSBuyOrderDefaultSetting = _dbTbl.WSBuyOrderDefaultSetting;
			ParameterExpression val = Expression.Parameter(typeof(WSBuyOrderDefaultSetting), "c");
			WSBuyOrderDefaultSetting wSBuyOrderDefaultSetting2 = Queryable.FirstOrDefault<WSBuyOrderDefaultSetting>((IQueryable<WSBuyOrderDefaultSetting>)wSBuyOrderDefaultSetting, Expression.Lambda<Func<WSBuyOrderDefaultSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass46_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (wSBuyOrderDefaultSetting2 != null)
			{
				DbSet<WSBuyOrderDefaultSetting_Lang> wSBuyOrderDefaultSetting_Lang = _dbTbl.WSBuyOrderDefaultSetting_Lang;
				val = Expression.Parameter(typeof(WSBuyOrderDefaultSetting_Lang), "c");
				List<WSBuyOrderDefaultSetting_Lang> list = Enumerable.ToList<WSBuyOrderDefaultSetting_Lang>((IEnumerable<WSBuyOrderDefaultSetting_Lang>)Queryable.Where<WSBuyOrderDefaultSetting_Lang>((IQueryable<WSBuyOrderDefaultSetting_Lang>)wSBuyOrderDefaultSetting_Lang, Expression.Lambda<Func<WSBuyOrderDefaultSetting_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass46_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				if (list != null)
				{
					list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSBuyOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSBuyOrderDefaultSetting_Lang>)list, (Func<WSBuyOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSBuyOrderDefaultSetting_Lang itemVm) => new CommonMultiLanguageViewModel
					{
						Value = itemVm.SettingTitle,
						LanguageId = itemVm.LanguageID
					})));
				}
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = wSBuyOrderDefaultSetting2.SettingTitle,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
				if (list != null)
				{
					list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSBuyOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSBuyOrderDefaultSetting_Lang>)list, (Func<WSBuyOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSBuyOrderDefaultSetting_Lang itemVm) => new CommonMultiLanguageViewModel
					{
						Value = itemVm.Title,
						LanguageId = itemVm.LanguageID
					})));
				}
				list3.Add(new CommonMultiLanguageViewModel
				{
					Value = wSBuyOrderDefaultSetting2.Title,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
				if (list != null)
				{
					list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSBuyOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSBuyOrderDefaultSetting_Lang>)list, (Func<WSBuyOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSBuyOrderDefaultSetting_Lang itemVm) => new CommonMultiLanguageViewModel
					{
						Value = itemVm.Subject,
						LanguageId = itemVm.LanguageID
					})));
				}
				list4.Add(new CommonMultiLanguageViewModel
				{
					Value = wSBuyOrderDefaultSetting2.Subject,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
				if (list != null)
				{
					list5 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSBuyOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSBuyOrderDefaultSetting_Lang>)list, (Func<WSBuyOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSBuyOrderDefaultSetting_Lang itemVm) => new CommonMultiLanguageViewModel
					{
						Value = itemVm.Note,
						LanguageId = itemVm.LanguageID
					})));
				}
				list5.Add(new CommonMultiLanguageViewModel
				{
					Value = wSBuyOrderDefaultSetting2.Note,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
				if (list != null)
				{
					list6 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSBuyOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSBuyOrderDefaultSetting_Lang>)list, (Func<WSBuyOrderDefaultSetting_Lang, CommonMultiLanguageViewModel>)((WSBuyOrderDefaultSetting_Lang itemVm) => new CommonMultiLanguageViewModel
					{
						Value = itemVm.DeliveryTerm,
						LanguageId = itemVm.LanguageID
					})));
				}
				list6.Add(new CommonMultiLanguageViewModel
				{
					Value = wSBuyOrderDefaultSetting2.DeliveryTerm,
					LanguageId = result
				});
				data = new WSBuyOrderDefaultSettingLanguageViewModel
				{
					BuyOrderDefaultSettingId = wSBuyOrderDefaultSetting2.BuyOrderDefaultSettingId,
					ReferUserId = wSBuyOrderDefaultSetting2.ReferUserId,
					SettingTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					SettingTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					BuyOrderOprId = wSBuyOrderDefaultSetting2.BuyOrderOprId,
					Title = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					Title_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					Subject = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					Subject_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					TaxIndex = wSBuyOrderDefaultSetting2.TaxIndex,
					CalculateTax = wSBuyOrderDefaultSetting2.CalculateTax,
					TaxIndexItem = wSBuyOrderDefaultSetting2.TaxIndexItem,
					CalculateTaxItem = wSBuyOrderDefaultSetting2.CalculateTaxItem,
					PrintFormatId = wSBuyOrderDefaultSetting2.PrintFormatId,
					Note = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					Note_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					CurrencyUnitId = wSBuyOrderDefaultSetting2.CurrencyUnitId,
					CurrencyUnitIdI = wSBuyOrderDefaultSetting2.CurrencyUnitIdI,
					DeliveryTerm = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					DeliveryTerm_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					VerificationWorkFlowId = wSBuyOrderDefaultSetting2.VerificationWorkFlowId,
					IsPublic = wSBuyOrderDefaultSetting2.IsPublic
				};
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
}

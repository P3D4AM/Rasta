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
using CRMIdeal.Areas.Company.Controllers;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.StockSupply.Controllers;

public class HomeController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass13_0
	{
		public int stsupItemId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass20_0
	{
		public int id;

		public int currLangID;

		internal bool _003CInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass21_0
	{
		public WSStockSupplyLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__7;

		public Func<Languages, bool> _003C_003E9__13;

		internal bool _003CInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__7(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__13(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass21_1
	{
		public WSStockSupply model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass21_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass21_1 CS_0024_003C_003E8__locals1;

		internal bool _003CInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actstsupStockSupply")]
	public ActionResult Index(int? id = null, bool? isOpenNew = null, bool? fromIndicator = null, string parameters = "", int? companyId = null, int? selWorkflowStepId = null, string intMsgInfo = "", int stockSupplyId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		if (!string.IsNullOrWhiteSpace(intMsgInfo))
		{
			base.ViewBag.IntMsgInfo = intMsgInfo;
		}
		base.ViewBag.SelectedWorkflowStepId = selWorkflowStepId;
		base.ViewBag.Parameters = parameters;
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
			base.ViewBag.SendedStockSupplyId = id;
			base.ViewBag.FromSearchId = true;
		}
		if (companyId.HasValue && companyId > 0)
		{
			base.ViewBag.CompanyId = companyId;
		}
		base.ViewBag.StockSupplyId = stockSupplyId;
		return View();
	}

	public List<WSspSelectStockSupplyItems_Result> GetStockSupplyItemsList(int stockSupplyId)
	{
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectStockSupplyItems_Result> list = new List<WSspSelectStockSupplyItems_Result>();
		try
		{
			list = Enumerable.ToList<WSspSelectStockSupplyItems_Result>((IEnumerable<WSspSelectStockSupplyItems_Result>)_dbII.WSspSelectStockSupplyItems(stockSupplyId, lCID, result));
			if (list != null)
			{
				foreach (WSspSelectStockSupplyItems_Result item in list)
				{
					item.AppType = item.stsupIPrdFGName + "/" + item.stsupIPrdSGName;
					if (!string.IsNullOrWhiteSpace(item.stsupIBuyOrders))
					{
						List<StockSupplyItemsBuyOrdersViewModel> list2 = new JavaScriptSerializer().Deserialize<List<StockSupplyItemsBuyOrdersViewModel>>(item.stsupIBuyOrders);
						if (list2 != null)
						{
							if (Enumerable.Any<StockSupplyItemsBuyOrdersViewModel>((IEnumerable<StockSupplyItemsBuyOrdersViewModel>)list2))
							{
								foreach (StockSupplyItemsBuyOrdersViewModel item2 in list2)
								{
									item2.bordDate = (item2.bordDateTime.HasValue ? item2.bordDateTime.Value.ToString("yyyy/MM/dd") : "");
								}
							}
							item.stsupIBuyOrders = JsonConvert.SerializeObject(Enumerable.ToList<StockSupplyItemsBuyOrdersViewModel>((IEnumerable<StockSupplyItemsBuyOrdersViewModel>)list2));
						}
					}
					item.PrdRowColor = Public.TColorToHex(item.PrdRowColor);
				}
			}
			else
			{
				list = new List<WSspSelectStockSupplyItems_Result>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public JsonResult GetStockSupply(int stsupCurrentId, int companyId, long stsupNumber, string fromDate, string toDate, int? userId = null, int? stockSupplyId = null)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CurrentStockSupplyViewModel currentStockSupplyViewModel = new CurrentStockSupplyViewModel();
		currentStockSupplyViewModel.StockSupply = new WSspSelectStockSupply_Result();
		currentStockSupplyViewModel.StockSupplyItemsList = new List<WSspSelectStockSupplyItems_Result>();
		currentStockSupplyViewModel.FooterData = new WSspReturnStockSupplySumFooter_Result();
		currentStockSupplyViewModel.LastVerificationStep = new WSspSelectVerificationWorkFlowStepLast_Result();
		try
		{
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
			if (userId.GetValueOrDefault() == 0)
			{
				userId = UserLogin.CurrentUser.UserId;
			}
			if (!stockSupplyId.HasValue)
			{
				stockSupplyId = 0;
			}
			List<WSspSelectStockSupply_Result> list = Enumerable.ToList<WSspSelectStockSupply_Result>((IEnumerable<WSspSelectStockSupply_Result>)_dbII.WSspSelectStockSupply(fromDate, toDate, value, now, stockSupplyId, stsupNumber, userId, lCID, result));
			if (list != null)
			{
				if (Enumerable.Any<WSspSelectStockSupply_Result>((IEnumerable<WSspSelectStockSupply_Result>)list))
				{
					currentStockSupplyViewModel.IsFind = true;
					currentStockSupplyViewModel.Message = "";
					currentStockSupplyViewModel.FromDate = fromDate;
					currentStockSupplyViewModel.ToDate = toDate;
					currentStockSupplyViewModel.StockSupplyNextId = -1;
					currentStockSupplyViewModel.StockSupplyPreviousId = -1;
					if (list.Count == 1)
					{
						currentStockSupplyViewModel.StockSupplyFirstId = -1;
						currentStockSupplyViewModel.StockSupplyLastId = -1;
					}
					else
					{
						currentStockSupplyViewModel.StockSupplyFirstId = Enumerable.FirstOrDefault<WSspSelectStockSupply_Result>((IEnumerable<WSspSelectStockSupply_Result>)list).StockSupplyId;
						currentStockSupplyViewModel.StockSupplyLastId = Enumerable.LastOrDefault<WSspSelectStockSupply_Result>((IEnumerable<WSspSelectStockSupply_Result>)list).StockSupplyId;
					}
					WSspSelectStockSupply_Result wSspSelectStockSupply_Result = ((stsupCurrentId <= 0) ? Enumerable.LastOrDefault<WSspSelectStockSupply_Result>((IEnumerable<WSspSelectStockSupply_Result>)list) : Enumerable.FirstOrDefault<WSspSelectStockSupply_Result>((IEnumerable<WSspSelectStockSupply_Result>)list, (Func<WSspSelectStockSupply_Result, bool>)((WSspSelectStockSupply_Result c) => c.StockSupplyId == stsupCurrentId)));
					if (wSspSelectStockSupply_Result != null)
					{
						wSspSelectStockSupply_Result.stsupDateTime = wSspSelectStockSupply_Result.stsupDateTime;
						_ = wSspSelectStockSupply_Result.stsupDateTime;
						wSspSelectStockSupply_Result.stsupDate = wSspSelectStockSupply_Result.stsupDateTime.ToString("yyyy/MM/dd");
						_ = wSspSelectStockSupply_Result.FirstRegisterDate;
						wSspSelectStockSupply_Result.FirstRegisterDatePersian = wSspSelectStockSupply_Result.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
						_ = wSspSelectStockSupply_Result.RegisterDate;
						wSspSelectStockSupply_Result.RegisterDatePersian = wSspSelectStockSupply_Result.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
						if (string.IsNullOrEmpty(wSspSelectStockSupply_Result.AppType))
						{
							wSspSelectStockSupply_Result.AppType = Configuration.AppType;
						}
						wSspSelectStockSupply_Result.AppType = Configuration.GetAppType(wSspSelectStockSupply_Result.AppType);
						if (!string.IsNullOrEmpty(wSspSelectStockSupply_Result.stsupVerifier) && wSspSelectStockSupply_Result.stsupVerifiedRegisterDate.HasValue)
						{
							wSspSelectStockSupply_Result.stsupVerifier += (wSspSelectStockSupply_Result.stsupVerifiedRegisterDate.HasValue ? (" (" + wSspSelectStockSupply_Result.stsupVerifiedRegisterDate.Value.ToString("yyyy/MM/dd HH:mm") + ")") : "");
						}
						currentStockSupplyViewModel.StockSupply = wSspSelectStockSupply_Result;
						currentStockSupplyViewModel.StockSupplyNumber = wSspSelectStockSupply_Result.stsupNumber;
						currentStockSupplyViewModel.StockSupplyCurrentId = wSspSelectStockSupply_Result.StockSupplyId;
						if (list.Count == 1)
						{
							currentStockSupplyViewModel.StockSupplyNextId = -1;
							currentStockSupplyViewModel.StockSupplyPreviousId = -1;
						}
						else
						{
							WSspSelectStockSupply_Result next = Lists.GetNext(list, wSspSelectStockSupply_Result);
							if (next != null)
							{
								currentStockSupplyViewModel.StockSupplyNextId = next.StockSupplyId;
							}
							WSspSelectStockSupply_Result previous = Lists.GetPrevious(list, wSspSelectStockSupply_Result);
							if (previous != null)
							{
								currentStockSupplyViewModel.StockSupplyPreviousId = previous.StockSupplyId;
							}
						}
						currentStockSupplyViewModel.StockSupplyItemsList = GetStockSupplyItemsList(wSspSelectStockSupply_Result.StockSupplyId);
						WSspReturnStockSupplySumFooter_Result wSspReturnStockSupplySumFooter_Result = Enumerable.FirstOrDefault<WSspReturnStockSupplySumFooter_Result>((IEnumerable<WSspReturnStockSupplySumFooter_Result>)_dbII.WSspReturnStockSupplySumFooter(wSspSelectStockSupply_Result.StockSupplyId));
						if (wSspReturnStockSupplySumFooter_Result != null)
						{
							currentStockSupplyViewModel.FooterData = wSspReturnStockSupplySumFooter_Result;
						}
						WSspReturnPreOrderFromStockSupply_Result wSspReturnPreOrderFromStockSupply_Result = Enumerable.FirstOrDefault<WSspReturnPreOrderFromStockSupply_Result>((IEnumerable<WSspReturnPreOrderFromStockSupply_Result>)_dbII.WSspReturnPreOrderFromStockSupply(wSspSelectStockSupply_Result.StockSupplyId, lCID, result));
						if (wSspReturnPreOrderFromStockSupply_Result != null)
						{
							currentStockSupplyViewModel.PreOrderId = wSspReturnPreOrderFromStockSupply_Result.PreOrderID;
							currentStockSupplyViewModel.PreOrderInfo = wSspReturnPreOrderFromStockSupply_Result.PreOrderInfo ?? "";
							if (!string.IsNullOrWhiteSpace(currentStockSupplyViewModel.PreOrderInfo))
							{
								currentStockSupplyViewModel.PreOrderInfo = string.Format(currentStockSupplyViewModel.PreOrderInfo, Labels.lblPOrd);
							}
						}
						if (wSspSelectStockSupply_Result.stsupVerificationWorkFlowId.GetValueOrDefault() != 0)
						{
							currentStockSupplyViewModel.LastVerificationStep = Enumerable.FirstOrDefault<WSspSelectVerificationWorkFlowStepLast_Result>((IEnumerable<WSspSelectVerificationWorkFlowStepLast_Result>)_db.WSspSelectVerificationWorkFlowStepLast(wSspSelectStockSupply_Result.StockSupplyId, 45, wSspSelectStockSupply_Result.stsupVerificationWorkFlowId, 0, lCID, result));
						}
						List<int?> list2 = Enumerable.ToList<int?>((IEnumerable<int?>)_dbII.WSspReturnStockSupplyItemsWareHouseCnt(wSspSelectStockSupply_Result.StockSupplyId));
						if (list2 != null)
						{
							int result2 = 0;
							int.TryParse(list2.Count.ToString(), out result2);
							currentStockSupplyViewModel.WareHouseCount = result2;
						}
					}
					else
					{
						currentStockSupplyViewModel.IsFind = false;
						currentStockSupplyViewModel.Message = Messages.ErrorNotFound;
						currentStockSupplyViewModel.FromDate = fromDate;
						currentStockSupplyViewModel.ToDate = toDate;
						currentStockSupplyViewModel.StockSupply = null;
						currentStockSupplyViewModel.StockSupplyCurrentId = -1;
						currentStockSupplyViewModel.StockSupplyNextId = -1;
						currentStockSupplyViewModel.StockSupplyNumber = -1L;
						currentStockSupplyViewModel.StockSupplyPreviousId = -1;
						currentStockSupplyViewModel.CompanyId = -1;
						currentStockSupplyViewModel.StockSupplyFirstId = -1;
						currentStockSupplyViewModel.StockSupplyLastId = -1;
					}
				}
				else
				{
					currentStockSupplyViewModel.IsFind = false;
					currentStockSupplyViewModel.Message = Messages.ErrorNotFound;
					currentStockSupplyViewModel.FromDate = fromDate;
					currentStockSupplyViewModel.ToDate = toDate;
					currentStockSupplyViewModel.StockSupply = null;
					currentStockSupplyViewModel.StockSupplyCurrentId = -1;
					currentStockSupplyViewModel.StockSupplyNextId = -1;
					currentStockSupplyViewModel.StockSupplyNumber = -1L;
					currentStockSupplyViewModel.StockSupplyPreviousId = -1;
					currentStockSupplyViewModel.CompanyId = -1;
					currentStockSupplyViewModel.StockSupplyFirstId = -1;
					currentStockSupplyViewModel.StockSupplyLastId = -1;
				}
			}
			else
			{
				currentStockSupplyViewModel.IsFind = false;
				currentStockSupplyViewModel.Message = Messages.ErrorNotFound;
				currentStockSupplyViewModel.FromDate = fromDate;
				currentStockSupplyViewModel.ToDate = toDate;
				currentStockSupplyViewModel.StockSupply = null;
				currentStockSupplyViewModel.StockSupplyCurrentId = -1;
				currentStockSupplyViewModel.StockSupplyNextId = -1;
				currentStockSupplyViewModel.StockSupplyNumber = -1L;
				currentStockSupplyViewModel.StockSupplyPreviousId = -1;
				currentStockSupplyViewModel.CompanyId = -1;
				currentStockSupplyViewModel.StockSupplyFirstId = -1;
				currentStockSupplyViewModel.StockSupplyLastId = -1;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			currentStockSupplyViewModel.Message = Messages.msgErrorRunProcedure + "<br />" + ex.Message;
		}
		JsonResult jsonResult = Json(currentStockSupplyViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public ActionResult _PartialList(int stsupCurrentId, int companyId, long stsupNumber, string fromDate, string toDate, int? userId = null, int? stockSupplyId = null)
	{
		StockSupplyListViewModel stockSupplyListViewModel = new StockSupplyListViewModel
		{
			stsupCurrentId = stsupCurrentId,
			companyId = companyId,
			stsupNumber = stsupNumber,
			fromDate = fromDate,
			toDate = toDate,
			userId = userId,
			stockSupplyId = stockSupplyId
		};
		base.ViewBag.StocksupplyList = stockSupplyListViewModel;
		return PartialView();
	}

	public ActionResult _PartialList_Read([DataSourceRequest] DataSourceRequest request, int stsupCurrentId, int companyId, long stsupNumber, string fromDate, string toDate, int? userId = null, int? stockSupplyId = null)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectStockSupply_Result> list = new List<WSspSelectStockSupply_Result>();
		try
		{
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
			if (userId.GetValueOrDefault() == 0)
			{
				userId = UserLogin.CurrentUser.UserId;
			}
			if (!stockSupplyId.HasValue)
			{
				stockSupplyId = 0;
			}
			list = Enumerable.ToList<WSspSelectStockSupply_Result>(Enumerable.Reverse<WSspSelectStockSupply_Result>((IEnumerable<WSspSelectStockSupply_Result>)_dbII.WSspSelectStockSupply(fromDate, toDate, value, now, stockSupplyId, stsupNumber, userId, lCID, result)));
			if (list == null)
			{
				list = new List<WSspSelectStockSupply_Result>();
			}
			else
			{
				foreach (WSspSelectStockSupply_Result item in list)
				{
					_ = item.stsupDateTime;
					item.stsupDate = item.stsupDateTime.ToString("yyyy/MM/dd");
					if (!string.IsNullOrWhiteSpace(item.CompanyPerson))
					{
						item.CompanyName = item.CompanyName + " - " + item.CompanyPerson;
					}
				}
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

	[AjaxOnly]
	public string VerifyStockSupply(int stsupId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmStockSupply", "actVerifyStockSupply", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			DateTime now = DateTime.Now;
			_dbII.WSspStockSupplyVerify(stsupId, currentUser.UserId, now, now.ToString("yyyyMMdd", new PersianCulture()));
			return "1|" + UserLogin.CurrentUser.UserId + "|" + UserLogin.CurrentUser.FullName + " (" + now.ToString("yyyy/MM/dd HH:mm") + ")";
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.msgErrorRunFunction;
		}
	}

	[AjaxOnly]
	public string ExitFromVerifyStockSupply(int stsupId)
	{
		string result = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmStockSupply", "actExitFromIsFix", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			_dbII.WSspStockSupplyVerifyExit(stsupId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	[AjaxOnly]
	public string CanceledStockSupply(int stsupId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmStockSupply", "actCanceledStockSupply", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			DateTime now = DateTime.Now;
			short value = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			_dbII.WSspStockSupplyCanceled(stsupId, currentUser.UserId, value, now, now.ToString("yyyyMMdd", new PersianCulture()), appType);
			return "1";
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.msgErrorRunFunction;
		}
	}

	[AjaxOnly]
	public string ExitFromCanceledStockSupply(int stsupId)
	{
		string result = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmStockSupply", "actExitFromIsCanceled", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			DateTime now = DateTime.Now;
			short value = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			_dbII.WSspStockSupplyCanceledExit(stsupId, currentUser.UserId, value, now, now.ToString("yyyyMMdd", new PersianCulture()), appType);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmStockSupply", ActionName = "actRemoveProduct")]
	public string RemoveProduct(int stsupItemId, int stsupId)
	{
		_003C_003Ec__DisplayClass13_0 _003C_003Ec__DisplayClass13_ = new _003C_003Ec__DisplayClass13_0();
		_003C_003Ec__DisplayClass13_.stsupItemId = stsupItemId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string result2 = "";
		try
		{
			if (CRMIdeal.Classes.Helper.StockSupply.IsFixed(stsupId))
			{
				return Messages.msgErrorNotEditStSup;
			}
			if (_003C_003Ec__DisplayClass13_.stsupItemId > 0)
			{
				DbSet<WSStockSupplyItems> wSStockSupplyItems = _dbTbl.WSStockSupplyItems;
				ParameterExpression val = Expression.Parameter(typeof(WSStockSupplyItems), "c");
				WSStockSupplyItems wSStockSupplyItems2 = Queryable.FirstOrDefault<WSStockSupplyItems>((IQueryable<WSStockSupplyItems>)wSStockSupplyItems, Expression.Lambda<Func<WSStockSupplyItems, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass13_, typeof(_003C_003Ec__DisplayClass13_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (wSStockSupplyItems2 != null)
				{
					try
					{
						if (!string.IsNullOrWhiteSpace(wSStockSupplyItems2.stsupIBuyOrderIds))
						{
							WSspSelectProductsWithId_Result wSspSelectProductsWithId_Result = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(wSStockSupplyItems2.stsupIPrdId, lCID, result));
							if (wSspSelectProductsWithId_Result != null)
							{
								return string.Format(Messages.msgErrorNoDeleteStsupItemHaveBord, wSspSelectProductsWithId_Result.PrdName ?? "");
							}
						}
						mct_II_Result mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.WSspDeleteStockSupplyItems(_003C_003Ec__DisplayClass13_.stsupItemId));
						int result3 = 0;
						if (mct_II_Result != null)
						{
							int.TryParse(mct_II_Result.Result.ToString(), out result3);
						}
						result2 = ((result3 <= 0) ? Messages.RedundancyMessage : (CRMIdeal.Classes.Helper.StockSupply.CalcAndSetStockSupplyFields(stsupId) ? "1" : Messages.msgErrorInCalculation));
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
					result2 = Messages.ErrorNotFound;
				}
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			result2 = Messages.msgErrorRunFunction;
		}
		return result2;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmStockSupply", ActionName = "actRemoveProductAll")]
	public string RemoveProductAll(int stsupId)
	{
		string result = "";
		try
		{
			if (stsupId > 0)
			{
				if (CRMIdeal.Classes.Helper.StockSupply.IsFixed(stsupId))
				{
					return Messages.msgErrorNotEditStSup;
				}
				try
				{
					List<WSspSelectStockSupplyItems_Result> stockSupplyItemsList = GetStockSupplyItemsList(stsupId);
					if (stockSupplyItemsList != null && Enumerable.Any<WSspSelectStockSupplyItems_Result>((IEnumerable<WSspSelectStockSupplyItems_Result>)stockSupplyItemsList))
					{
						WSspSelectStockSupplyItems_Result wSspSelectStockSupplyItems_Result = Enumerable.FirstOrDefault<WSspSelectStockSupplyItems_Result>((IEnumerable<WSspSelectStockSupplyItems_Result>)stockSupplyItemsList, (Func<WSspSelectStockSupplyItems_Result, bool>)((WSspSelectStockSupplyItems_Result m) => !string.IsNullOrWhiteSpace(m.stsupIBuyOrderIds)));
						if (wSspSelectStockSupplyItems_Result != null)
						{
							return string.Format(Messages.msgErrorNoDeleteStsupItemHaveBord, wSspSelectStockSupplyItems_Result.stsupIPrdName ?? "");
						}
					}
					mct_II_Result mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.WSspDeleteStockSupplyItemsAll(stsupId));
					int result2 = 0;
					if (mct_II_Result != null)
					{
						int.TryParse(mct_II_Result.Result.ToString(), out result2);
					}
					result = ((result2 <= 0) ? Messages.RedundancyMessage : (CRMIdeal.Classes.Helper.StockSupply.CalcAndSetStockSupplyFields(stsupId) ? "1" : Messages.msgErrorInCalculation));
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
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			result = Messages.frmErrorMessage;
		}
		return result;
	}

	public ActionResult Files_Read([DataSourceRequest] DataSourceRequest request, int stsupId)
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
			list = Files.SelectFilesDirectory("", "", "", "100", stsupId.ToString(), "0", "0", false);
			if (list != null)
			{
				if (Enumerable.Any<CRMspSelectFilesDirectory_Result>((IEnumerable<CRMspSelectFilesDirectory_Result>)list))
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
						if (!string.IsNullOrWhiteSpace(item.DocDay))
						{
							item.DocDay = DateTimeClass.ConvertNumToDayeOfWeek(int.Parse(item.DocDay));
						}
					}
				}
			}
			else
			{
				list = new List<CRMspSelectFilesDirectory_Result>();
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

	[AjaxOnly]
	public string DeleteStsupWithDep(int stsupId)
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
			if (!UserLogin.IsUserAccess("frmStockSupply", "actDeleteAllStsupWithDep", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			if (stsupId > 0)
			{
				try
				{
					List<CRMspSelectFilesDirectory_Result> list = Files.SelectFilesDirectory("", "", "", "100", stsupId.ToString(), "0", "0", false);
					mct_Result_StrII mct_Result_StrII = Enumerable.FirstOrDefault<mct_Result_StrII>((IEnumerable<mct_Result_StrII>)_dbII.WSspDeleteStockSupplyWithDependencies(stsupId, lCID, result2));
					if (mct_Result_StrII != null && !string.IsNullOrWhiteSpace(mct_Result_StrII.Result))
					{
						string[] array = mct_Result_StrII.Result.Split(new char[1] { '|' });
						if (array != null)
						{
							if (array[0] == "1")
							{
								try
								{
									if ((list != null) & Enumerable.Any<CRMspSelectFilesDirectory_Result>((IEnumerable<CRMspSelectFilesDirectory_Result>)list))
									{
										foreach (CRMspSelectFilesDirectory_Result item in list)
										{
											new CompanyInfoController().DeleteFileByPath(item.FilePath, item.FileName, item.FolderName);
										}
									}
								}
								catch (Exception e)
								{
									ErrorSignal.FromCurrentContext().Raise(e);
								}
								result = "";
							}
							else if (array[0] == "0")
							{
								result = Messages.msgErrorRunFunction;
							}
							else
							{
								string text = "";
								if (mct_Result_StrII.Result.IndexOf("-3", StringComparison.Ordinal) >= 0)
								{
									text = text + Messages.msgErrStsupHasBord + "<br>";
								}
								result = text;
							}
						}
					}
				}
				catch (Exception ex)
				{
					ErrorSignal.FromCurrentContext().Raise(ex);
					result = Messages.msgErrorCommunicateWithServer + "<br><p style=text-align:left;>" + ex.Message + "</p>";
				}
			}
			else
			{
				result = Messages.msgErrorNotActiveItem;
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
	public string IsFixed(int stsupId)
	{
		string result = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmStockSupply", "actIsFixed", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			_dbII.WSspStockSupplyIsFixed(stsupId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	[AjaxOnly]
	public string ExitIsFixed(int stsupId)
	{
		string result = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmStockSupply", "actExitIsFixed", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			if (CRMIdeal.Classes.Helper.StockSupply.IsVerified(stsupId))
			{
				return string.Format(Messages.msgErrorNotExitIsFixedAfterVerify, Labels.lblStsup);
			}
			_dbII.WSspStockSupplyIsFixedExit(stsupId);
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

	[DynamicAuthorize(ControllerName = "frmStockSupply", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(int id = 0, string parameters = "")
	{
		_003C_003Ec__DisplayClass20_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass20_0();
		CS_0024_003C_003E8__locals0.id = id;
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
		string[] array = parameters.Split(new char[1] { '|' });
		base.ViewBag.MyParameters = array;
		WSStockSupplyLanguageViewModel model = new WSStockSupplyLanguageViewModel();
		string text = "";
		try
		{
			if (CS_0024_003C_003E8__locals0.id > 0)
			{
				if (!UserLogin.IsUserAccess("frmStockSupply", "actEdit"))
				{
					base.ViewBag.Error = Messages.NotAccessToPage;
					return null;
				}
				DbSet<WSStockSupply_Lang> wSStockSupply_Lang = _dbTbl.WSStockSupply_Lang;
				ParameterExpression val = Expression.Parameter(typeof(WSStockSupply_Lang), "c");
				List<WSStockSupply_Lang> list = Enumerable.ToList<WSStockSupply_Lang>((IEnumerable<WSStockSupply_Lang>)Queryable.Where<WSStockSupply_Lang>((IQueryable<WSStockSupply_Lang>)wSStockSupply_Lang, Expression.Lambda<Func<WSStockSupply_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass20_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				DbSet<WSStockSupply> wSStockSupply = _dbTbl.WSStockSupply;
				val = Expression.Parameter(typeof(WSStockSupply), "c");
				WSStockSupply wSStockSupply2 = Queryable.FirstOrDefault<WSStockSupply>((IQueryable<WSStockSupply>)wSStockSupply, Expression.Lambda<Func<WSStockSupply, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass20_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (wSStockSupply2 == null)
				{
					base.ViewBag.Error = Messages.ErrorNotFound;
					return null;
				}
				if (wSStockSupply2.stsupIsFixed.GetValueOrDefault())
				{
					base.ViewBag.Error = Messages.msgErrorNotEditStSup;
					return null;
				}
				int result3 = 0;
				int.TryParse(wSStockSupply2.stsupCompanyId.ToString(), out result3);
				if (result3 != 0)
				{
					CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(result3);
					if (companyById != null)
					{
						text = companyById.cmpTitle ?? "";
						if (!string.IsNullOrWhiteSpace(text))
						{
							text += " ";
						}
						text += companyById.cmpName;
					}
				}
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSStockSupply_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSStockSupply_Lang>)list, (Func<WSStockSupply_Lang, CommonMultiLanguageViewModel>)((WSStockSupply_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.stsupNote,
					LanguageId = item.LanguageID
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = wSStockSupply2.stsupNote,
					LanguageId = result
				});
				WSStockSupplyLanguageViewModel obj = new WSStockSupplyLanguageViewModel
				{
					StockSupplyId = wSStockSupply2.StockSupplyId,
					StockSupplyOprId = wSStockSupply2.StockSupplyOprId,
					stsupReferUserId = wSStockSupply2.stsupReferUserId,
					stsupNumber = wSStockSupply2.stsupNumber,
					stsupDateTime = wSStockSupply2.stsupDateTime
				};
				_ = wSStockSupply2.stsupDateTime;
				obj.stsupDate = wSStockSupply2.stsupDateTime.ToString("yyyy/MM/dd");
				obj.stsupCompanyId = wSStockSupply2.stsupCompanyId;
				obj.stsupCompanyPersonId = wSStockSupply2.stsupCompanyPersonId;
				obj.stsupProjectId = wSStockSupply2.stsupProjectId;
				obj.stsupVerifierRequestId = wSStockSupply2.stsupVerifierRequestId;
				obj.stsupVerificationWorkFlowId = wSStockSupply2.stsupVerificationWorkFlowId;
				obj.stsupPrintFormatId = wSStockSupply2.stsupPrintFormatId;
				obj.stsupNote = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
				obj.stsupNote_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
				model = obj;
			}
			else
			{
				if (!UserLogin.IsUserAccess("frmStockSupply", "actInsert"))
				{
					base.ViewBag.Error = Messages.NotAccessToPage;
					return null;
				}
				long stsupNumber = Enumerable.FirstOrDefault<long>(_dbII.Database.SqlQuery<long>($"Select dbo.WSfnReturnStockSupplyNumber({1},{result2})", Array.Empty<object>()));
				DateTime now = DateTime.Now;
				model = new WSStockSupplyLanguageViewModel
				{
					StockSupplyOprId = 1,
					stsupReferUserId = UserLogin.CurrentUser.UserId,
					stsupNumber = stsupNumber,
					stsupDateTime = now,
					stsupDate = now.ToString("yyyy/MM/dd")
				};
				if (array != null && array.Length >= 1 && array[0] != "")
				{
					int result4 = 0;
					int.TryParse(array[0], out result4);
					CRMspSelectCompanyById_Result companyById2 = CRMIdeal.Classes.Helper.Company.GetCompanyById(result4);
					if (companyById2 != null)
					{
						text = companyById2.cmpTitle ?? "";
						if (!string.IsNullOrWhiteSpace(text))
						{
							text += " ";
						}
						text += companyById2.cmpName;
					}
				}
				base.ViewBag.IsBuying = VersionBuyer.StockSupply;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CmpFullName = text;
		List<int> list3 = Enumerable.ToList<int>(Enumerable.Select<CRMspSelectDeActiveUsers_Result, int>((IEnumerable<CRMspSelectDeActiveUsers_Result>)_dbII.CRMspSelectDeActiveUsers(CS_0024_003C_003E8__locals0.currLangID, result), (Func<CRMspSelectDeActiveUsers_Result, int>)((CRMspSelectDeActiveUsers_Result c) => c.UserId)));
		base.ViewBag.ListUserIsActiveStatus = list3;
		GetStsupPrintFormat();
		GetVerificationWorkFlow();
		GetStsupVerifierRequest();
		return View(model);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmStockSupplyDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult InsertEdit(WSStockSupplyLanguageViewModel vm)
	{
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass21_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass21_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int result = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
		}
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.vm.stsupNote_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.stsupNote_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.stsupNote,
			LanguageId = lCID
		});
		base.ViewBag.MyParameters = "".Split(new char[1] { '|' });
		string text = "";
		int result2 = 0;
		int.TryParse(CS_0024_003C_003E8__locals0.vm.stsupCompanyId.ToString(), out result2);
		if (result2 != 0)
		{
			CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(result2);
			if (companyById != null)
			{
				text = companyById.cmpTitle ?? "";
				if (!string.IsNullOrWhiteSpace(text))
				{
					text += " ";
				}
				text += companyById.cmpName;
			}
		}
		base.ViewBag.CmpFullName = text;
		List<int> list2 = Enumerable.ToList<int>(Enumerable.Select<CRMspSelectDeActiveUsers_Result, int>((IEnumerable<CRMspSelectDeActiveUsers_Result>)_dbII.CRMspSelectDeActiveUsers(lCID, CS_0024_003C_003E8__locals0.defLangID), (Func<CRMspSelectDeActiveUsers_Result, int>)((CRMspSelectDeActiveUsers_Result c) => c.UserId)));
		base.ViewBag.ListUserIsActiveStatus = list2;
		GetStsupPrintFormat();
		GetVerificationWorkFlow();
		GetStsupVerifierRequest();
		long num = 0L;
		int sysPartId = 45;
		try
		{
			if (CS_0024_003C_003E8__locals0.vm.StockSupplyId <= 0 && !VersionBuyer.StockSupply)
			{
				DbSet<WSStockSupply> wSStockSupply = _dbTbl.WSStockSupply;
				ParameterExpression val = Expression.Parameter(typeof(WSStockSupply), "c");
				if (Queryable.Any<WSStockSupply>((IQueryable<WSStockSupply>)wSStockSupply, Expression.Lambda<Func<WSStockSupply, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)10, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val })))
				{
					base.ViewBag.Error = "BV|" + Messages.VersionBuy;
					return View(CS_0024_003C_003E8__locals0.vm);
				}
			}
			string text2 = "";
			DateTime dateTime = default(DateTime);
			try
			{
				text2 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.vm.stsupDate.Replace("/", ""));
				switch (lCID)
				{
				case 1065:
					dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
					CS_0024_003C_003E8__locals0.vm.stsupDate = dateTime.ToString("yyyyMMdd");
					break;
				case 1025:
					dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
					CS_0024_003C_003E8__locals0.vm.stsupDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
					break;
				default:
					dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
					CS_0024_003C_003E8__locals0.vm.stsupDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
					break;
				}
				CS_0024_003C_003E8__locals0.vm.stsupDateTime = dateTime;
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				WSStockSupplyLanguageViewModel vm2 = CS_0024_003C_003E8__locals0.vm;
				_ = CS_0024_003C_003E8__locals0.vm.stsupDateTime;
				vm2.stsupDate = CS_0024_003C_003E8__locals0.vm.stsupDateTime.ToString("yyyy/MM/dd");
				base.ViewBag.Error = string.Format(Messages.ErrorInFormat, Labels.stsupDate);
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			if (CS_0024_003C_003E8__locals0.vm.stsupDate != null)
			{
				CS_0024_003C_003E8__locals0.vm.stsupDate = CS_0024_003C_003E8__locals0.vm.stsupDate.Replace("/", "").Replace("-", "").Replace("_", "")
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
				_003C_003Ec__DisplayClass21_1 _003C_003Ec__DisplayClass21_ = new _003C_003Ec__DisplayClass21_1();
				_003C_003Ec__DisplayClass21_.model = new WSStockSupply();
				if (CS_0024_003C_003E8__locals0.vm.StockSupplyId > 0)
				{
					DbSet<WSStockSupply> wSStockSupply2 = _dbTbl.WSStockSupply;
					ParameterExpression val = Expression.Parameter(typeof(WSStockSupply), "c");
					_003C_003Ec__DisplayClass21_.model = Queryable.FirstOrDefault<WSStockSupply>((IQueryable<WSStockSupply>)wSStockSupply2, Expression.Lambda<Func<WSStockSupply, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass21_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				DateTime now = DateTime.Now;
				_003C_003Ec__DisplayClass21_.model.UserId = UserLogin.CurrentUser.UserId;
				_003C_003Ec__DisplayClass21_.model.RegisterDate = now;
				_003C_003Ec__DisplayClass21_.model.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				_003C_003Ec__DisplayClass21_.model.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
				_003C_003Ec__DisplayClass21_.model.AppType = Configuration.AppType;
				_003C_003Ec__DisplayClass21_.model.StockSupplyOprId = CS_0024_003C_003E8__locals0.vm.StockSupplyOprId;
				_003C_003Ec__DisplayClass21_.model.stsupReferUserId = CS_0024_003C_003E8__locals0.vm.stsupReferUserId;
				_003C_003Ec__DisplayClass21_.model.stsupDate = CS_0024_003C_003E8__locals0.vm.stsupDate;
				_003C_003Ec__DisplayClass21_.model.stsupDateTime = CS_0024_003C_003E8__locals0.vm.stsupDateTime;
				_003C_003Ec__DisplayClass21_.model.stsupCompanyId = CS_0024_003C_003E8__locals0.vm.stsupCompanyId;
				_003C_003Ec__DisplayClass21_.model.stsupCompanyPersonId = CS_0024_003C_003E8__locals0.vm.stsupCompanyPersonId;
				_003C_003Ec__DisplayClass21_.model.stsupProjectId = CS_0024_003C_003E8__locals0.vm.stsupProjectId;
				_003C_003Ec__DisplayClass21_.model.stsupVerifierRequestId = CS_0024_003C_003E8__locals0.vm.stsupVerifierRequestId;
				_003C_003Ec__DisplayClass21_.model.stsupVerificationWorkFlowId = CS_0024_003C_003E8__locals0.vm.stsupVerificationWorkFlowId;
				if (!UserLogin.IsUserAccess("frmStockSupplyDataEntry", "actCanNotChangePrintFormat", UserLogin.CurrentUser))
				{
					_003C_003Ec__DisplayClass21_.model.stsupPrintFormatId = CS_0024_003C_003E8__locals0.vm.stsupPrintFormatId;
				}
				else if (_003C_003Ec__DisplayClass21_.model.StockSupplyId == 0)
				{
					_003C_003Ec__DisplayClass21_.model.stsupPrintFormatId = CS_0024_003C_003E8__locals0.vm.stsupPrintFormatId;
				}
				_003C_003Ec__DisplayClass21_.model.stsupNote = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				if (_003C_003Ec__DisplayClass21_.model.StockSupplyId > 0)
				{
					string sql = $"Select * from WSfnCheckDuplicateStockSupplyNumber({_003C_003Ec__DisplayClass21_.model.stsupNumber}, {_003C_003Ec__DisplayClass21_.model.StockSupplyId},{_003C_003Ec__DisplayClass21_.model.StockSupplyOprId},{_003C_003Ec__DisplayClass21_.model.stsupCId.GetValueOrDefault()})";
					long? num2 = Enumerable.FirstOrDefault<long?>(_dbII.Database.SqlQuery<long?>(sql, Array.Empty<object>()));
					if (num2.HasValue && num2 > 0)
					{
						WSStockSupplyLanguageViewModel vm3 = CS_0024_003C_003E8__locals0.vm;
						_ = CS_0024_003C_003E8__locals0.vm.stsupDateTime;
						vm3.stsupDate = CS_0024_003C_003E8__locals0.vm.stsupDateTime.ToString("yyyy/MM/dd");
						base.ViewBag.Error = Messages.msgErrorStockSupplyNumberIsDuplicate;
						return View(CS_0024_003C_003E8__locals0.vm);
					}
					_dbTbl.Entry(_003C_003Ec__DisplayClass21_.model).State = EntityState.Modified;
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					if (!CRMIdeal.Classes.Helper.StockSupply.CalcAndSetStockSupplyFields(_003C_003Ec__DisplayClass21_.model))
					{
						base.ViewBag.Error = Messages.msgErrorInCalculation;
					}
					else
					{
						using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								_003C_003Ec__DisplayClass21_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass21_2();
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass21_;
								CS_0024_003C_003E8__locals1.lang = enumerator.Current;
								DbSet<WSStockSupply_Lang> wSStockSupply_Lang = _dbTbl.WSStockSupply_Lang;
								ParameterExpression val = Expression.Parameter(typeof(WSStockSupply_Lang), "c");
								WSStockSupply_Lang wSStockSupply_Lang2 = Queryable.FirstOrDefault<WSStockSupply_Lang>((IQueryable<WSStockSupply_Lang>)wSStockSupply_Lang, Expression.Lambda<Func<WSStockSupply_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass21_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass21_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (wSStockSupply_Lang2 != null)
								{
									wSStockSupply_Lang2.stsupNote = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									_dbTbl.Entry(wSStockSupply_Lang2).State = EntityState.Modified;
									_dbTbl.SaveChanges();
									continue;
								}
								wSStockSupply_Lang2 = new WSStockSupply_Lang();
								wSStockSupply_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
								wSStockSupply_Lang2.StockSupplyId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.StockSupplyId;
								wSStockSupply_Lang2.stsupNote = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.WSStockSupply_Lang.Add(wSStockSupply_Lang2);
								_dbTbl.SaveChanges();
							}
						}
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					}
				}
				else
				{
					_003C_003Ec__DisplayClass21_.model.FPId = Financial.Get().Id;
					_003C_003Ec__DisplayClass21_.model.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
					_003C_003Ec__DisplayClass21_.model.FirstRegisterDate = now;
					_003C_003Ec__DisplayClass21_.model.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					_003C_003Ec__DisplayClass21_.model.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
					_003C_003Ec__DisplayClass21_.model.GUId = System.Guid.NewGuid();
					long num3 = 0L;
					bool flag = false;
					int num4 = 0;
					while (!flag)
					{
						num3 = Enumerable.FirstOrDefault<long>(_dbII.Database.SqlQuery<long>($"Select dbo.WSfnReturnStockSupplyNumber({_003C_003Ec__DisplayClass21_.model.StockSupplyOprId},{result})", Array.Empty<object>()));
						_003C_003Ec__DisplayClass21_.model.stsupNumber = num3;
						num = _003C_003Ec__DisplayClass21_.model.stsupNumber;
						flag = ReservedNumber.AddNumber(sysPartId, num);
						num4++;
						if (num4 > 10)
						{
							break;
						}
					}
					string sql2 = $"Select * from WSfnCheckDuplicateStockSupplyNumber({_003C_003Ec__DisplayClass21_.model.stsupNumber}, 0,{_003C_003Ec__DisplayClass21_.model.StockSupplyOprId},{result})";
					long? num5 = Enumerable.FirstOrDefault<long?>(_dbII.Database.SqlQuery<long?>(sql2, Array.Empty<object>()));
					if (num5.HasValue && num5 > 0)
					{
						WSStockSupplyLanguageViewModel vm4 = CS_0024_003C_003E8__locals0.vm;
						_ = CS_0024_003C_003E8__locals0.vm.stsupDateTime;
						vm4.stsupDate = CS_0024_003C_003E8__locals0.vm.stsupDateTime.ToString("yyyy/MM/dd");
						base.ViewBag.Error = Messages.msgErrorStockSupplyNumberIsDuplicate;
						ReservedNumber.UpdateNumber(sysPartId, num);
						return View(CS_0024_003C_003E8__locals0.vm);
					}
					_003C_003Ec__DisplayClass21_.model.stsupCId = result;
					_dbTbl.WSStockSupply.Add(_003C_003Ec__DisplayClass21_.model);
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					num = (ReservedNumber.RemoveNumber(sysPartId, num) ? 0 : num);
					if (_003C_003Ec__DisplayClass21_.model.StockSupplyId <= 0)
					{
						base.ViewBag.Error = Messages.msgErrorRunFunction;
					}
					else
					{
						foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
						{
							WSStockSupply_Lang wSStockSupply_Lang3 = new WSStockSupply_Lang();
							wSStockSupply_Lang3.LanguageID = lang.LanguageID;
							wSStockSupply_Lang3.StockSupplyId = _003C_003Ec__DisplayClass21_.model.StockSupplyId;
							wSStockSupply_Lang3.stsupNote = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
							_dbTbl.WSStockSupply_Lang.Add(wSStockSupply_Lang3);
							_dbTbl.SaveChanges();
						}
						CS_0024_003C_003E8__locals0.vm.StockSupplyId = _003C_003Ec__DisplayClass21_.model.StockSupplyId;
						base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
					}
				}
			}
		}
		catch (DbEntityValidationException ex)
		{
			Public.InsExceptToElmah((Exception)(object)ex);
			base.ViewBag.Error = Messages.msgErrorRunFunction;
		}
		catch (Exception ex2)
		{
			Public.InsExceptToElmah(ex2);
			base.ViewBag.Error = Messages.msgErrorRunFunction;
		}
		WSStockSupplyLanguageViewModel vm5 = CS_0024_003C_003E8__locals0.vm;
		_ = CS_0024_003C_003E8__locals0.vm.stsupDateTime;
		vm5.stsupDate = CS_0024_003C_003E8__locals0.vm.stsupDateTime.ToString("yyyy/MM/dd");
		if (num != 0L)
		{
			ReservedNumber.RemoveNumber(sysPartId, num);
		}
		return View(CS_0024_003C_003E8__locals0.vm);
	}

	[AjaxOnly]
	public JsonResult GetStsupPrintFormat()
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
			List<spSelectPrintFormat_Result> list2 = CRMIdeal.Classes.Helper.PrintFormat.GetspPrintFortants(result2, 82);
			if (list2 != null)
			{
				list = Enumerable.ToList<SelectListItem>(Enumerable.Select<spSelectPrintFormat_Result, SelectListItem>((IEnumerable<spSelectPrintFormat_Result>)list2, (Func<spSelectPrintFormat_Result, SelectListItem>)((spSelectPrintFormat_Result item) => new SelectListItem
				{
					Text = item.Title,
					Value = item.PrintFormatID.ToString()
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.stsupPrintFormatList = list;
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
			List<WSspSelectVerificationWorkFlowWithObjectType_Result> list2 = Enumerable.ToList<WSspSelectVerificationWorkFlowWithObjectType_Result>((IEnumerable<WSspSelectVerificationWorkFlowWithObjectType_Result>)_db.WSspSelectVerificationWorkFlowWithObjectType(45, lCID, result));
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
	public JsonResult GetStsupVerifierRequest()
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
			List<WSspSelectStockSupplyVerifiers_Result> list2 = Enumerable.ToList<WSspSelectStockSupplyVerifiers_Result>((IEnumerable<WSspSelectStockSupplyVerifiers_Result>)_dbII.WSspSelectStockSupplyVerifiers(UserLogin.CurrentUser.UserId, lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectStockSupplyVerifiers_Result, SelectListItem>((IEnumerable<WSspSelectStockSupplyVerifiers_Result>)list2, (Func<WSspSelectStockSupplyVerifiers_Result, SelectListItem>)((WSspSelectStockSupplyVerifiers_Result item) => new SelectListItem
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
	public JsonResult GetStsupReferUser(int stsupId = 0)
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
			if (stsupId != 0)
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
	public string GetStockSupplyNumber(int stockSupplyOprId, int? cId = null)
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
			result = Enumerable.FirstOrDefault<long>(_dbII.Database.SqlQuery<long>($"Select dbo.WSfnReturnStockSupplyNumber({stockSupplyOprId},{cId.GetValueOrDefault()})", Array.Empty<object>())).ToString();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}
}

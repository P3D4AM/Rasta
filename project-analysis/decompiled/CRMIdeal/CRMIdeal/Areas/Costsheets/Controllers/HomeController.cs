using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using CRM.General.Calendar;
using CRM.General.IO;
using CRM.General.Security;
using CRM.Models;
using CRM.Models.ReportModel.CostSheetProductsPrintRpt;
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
using OfficeOpenXml;
using OfficeOpenXml.Style;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using SautinSoft;
using Stimulsoft.Report;
using Stimulsoft.Report.Components;
using Stimulsoft.Report.Dictionary;
using Stimulsoft.Report.Export;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace CRMIdeal.Areas.Costsheets.Controllers;

public class HomeController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass15_0
	{
		public int ctshId;

		public int currLangID;

		internal bool _003CCtshInsertEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CCtshInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CCtshInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass16_0
	{
		public WSCostSheetsLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__6;

		public Func<Languages, bool> _003C_003E9__12;

		internal bool _003CCtshInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CCtshInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CCtshInsertEdit_003Eb__6(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CCtshInsertEdit_003Eb__12(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass16_1
	{
		public WSCostSheets model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass16_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass16_1 CS_0024_003C_003E8__locals1;

		internal bool _003CCtshInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCtshInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCtshInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCtshInsertEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public int ctshPrdId;

		public int currLangID;

		internal bool _003CCtshPrdInsertEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CCtshPrdInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CCtshPrdInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public int ctshSelectPrdId;

		public WSCostSheetProductsLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__9;

		public Func<Languages, bool> _003C_003E9__15;

		internal bool _003CCtshPrdInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CCtshPrdInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CCtshPrdInsertEdit_003Eb__9(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CCtshPrdInsertEdit_003Eb__15(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_1
	{
		public WSCostSheetProducts model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass9_1 CS_0024_003C_003E8__locals1;

		internal bool _003CCtshPrdInsertEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCtshPrdInsertEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCtshPrdInsertEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCtshPrdInsertEdit_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actGotoCostsheet")]
	public ActionResult Index(bool? isOpenNew = null, string parameters = "", int prjId = 0)
	{
		base.ViewBag.Parameters = parameters;
		if (isOpenNew ?? false)
		{
			base.ViewBag.IsOpenNew = true;
		}
		base.ViewBag.ProjectId = prjId;
		return View();
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
				prjInquiryNum = item.prjInquiryNum,
				prjNumR = item.prjNumR
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCtshPrj(int currentId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CurrentCostSheetProjectViewModel currentCostSheetProjectViewModel = new CurrentCostSheetProjectViewModel();
		currentCostSheetProjectViewModel.Project = new WSspSelectCrmProjectsForCostSheet_Result();
		try
		{
			WSspSelectCrmProjectsForCostSheet_Result wSspSelectCrmProjectsForCostSheet_Result = Enumerable.FirstOrDefault<WSspSelectCrmProjectsForCostSheet_Result>((IEnumerable<WSspSelectCrmProjectsForCostSheet_Result>)_db.WSspSelectCrmProjectsForCostSheet(currentId, UserLogin.CurrentUser.UserId, lCID, result));
			if (wSspSelectCrmProjectsForCostSheet_Result != null)
			{
				currentCostSheetProjectViewModel.IsFind = true;
				currentCostSheetProjectViewModel.Message = "";
				currentCostSheetProjectViewModel.CtshPrjNextId = -1;
				currentCostSheetProjectViewModel.CtshPrjPreviousId = -1;
				currentCostSheetProjectViewModel.CtshPrjFirstId = -1;
				currentCostSheetProjectViewModel.CtshPrjLastId = -1;
				currentCostSheetProjectViewModel.Project = wSspSelectCrmProjectsForCostSheet_Result;
				currentCostSheetProjectViewModel.CtshPrjCurrentId = wSspSelectCrmProjectsForCostSheet_Result.ProjectID;
				currentCostSheetProjectViewModel.Project = wSspSelectCrmProjectsForCostSheet_Result;
				WSspReturnPreOrderFromCostSheet_Result wSspReturnPreOrderFromCostSheet_Result = Enumerable.FirstOrDefault<WSspReturnPreOrderFromCostSheet_Result>((IEnumerable<WSspReturnPreOrderFromCostSheet_Result>)_db.WSspReturnPreOrderFromCostSheet(wSspSelectCrmProjectsForCostSheet_Result.ProjectID, currentId, result));
				if (wSspReturnPreOrderFromCostSheet_Result != null)
				{
					currentCostSheetProjectViewModel.PreOrderId = wSspReturnPreOrderFromCostSheet_Result.PreOrderID;
					string text = "";
					_ = wSspReturnPreOrderFromCostSheet_Result.pordNumber;
					text += wSspReturnPreOrderFromCostSheet_Result.pordNumber;
					if (wSspReturnPreOrderFromCostSheet_Result.pordNumberRevision.HasValue)
					{
						text += 45u + wSspReturnPreOrderFromCostSheet_Result.pordNumberRevision;
					}
					string text2 = (wSspReturnPreOrderFromCostSheet_Result.pordDateTime.HasValue ? (" (" + Labels.ctshPordInfoDate + ": " + wSspReturnPreOrderFromCostSheet_Result.pordDateTime.Value.ToString("yyyy/MM/dd") + ")") : "");
					string text3 = "";
					if (wSspReturnPreOrderFromCostSheet_Result.pordCurrencyUnitId.HasValue)
					{
						bool result2 = false;
						WSspSelectCurrencyUnitsWithId_Result wSspSelectCurrencyUnitsWithId_Result = Enumerable.FirstOrDefault<WSspSelectCurrencyUnitsWithId_Result>((IEnumerable<WSspSelectCurrencyUnitsWithId_Result>)_db.WSspSelectCurrencyUnitsWithId(wSspReturnPreOrderFromCostSheet_Result.pordCurrencyUnitId, lCID, result));
						if (wSspSelectCurrencyUnitsWithId_Result != null)
						{
							bool.TryParse(wSspSelectCurrencyUnitsWithId_Result.IsDecimal.ToString(), out result2);
						}
						text3 = (result2 ? (" (" + Labels.ctshPordInfoTotalAmount + ": " + $"{wSspReturnPreOrderFromCostSheet_Result.pordTotalAmount.GetValueOrDefault():N2}" + " " + wSspSelectCurrencyUnitsWithId_Result.CurrencyUnit + ")") : (" (" + Labels.ctshPordInfoTotalAmount + ": " + $"{wSspReturnPreOrderFromCostSheet_Result.pordTotalAmount.GetValueOrDefault():N0}" + " " + wSspSelectCurrencyUnitsWithId_Result.CurrencyUnit + ")"));
					}
					else
					{
						text3 = " (" + Labels.ctshPordInfoTotalAmount + ": " + $"{wSspReturnPreOrderFromCostSheet_Result.pordTotalAmount.GetValueOrDefault():N2}" + " " + wSspReturnPreOrderFromCostSheet_Result.pordCurrencyUnit + ")";
					}
					if (!string.IsNullOrEmpty(wSspReturnPreOrderFromCostSheet_Result.pordNumRef))
					{
						text = wSspReturnPreOrderFromCostSheet_Result.pordNumRef;
					}
					currentCostSheetProjectViewModel.PreOrderInfo = text + text2 + text3;
				}
			}
			else
			{
				currentCostSheetProjectViewModel.IsFind = false;
				currentCostSheetProjectViewModel.Message = Messages.ErrorNotFound;
				currentCostSheetProjectViewModel.Project = null;
				currentCostSheetProjectViewModel.CtshPrjCurrentId = -1;
				currentCostSheetProjectViewModel.CtshPrjNextId = -1;
				currentCostSheetProjectViewModel.CtshPrjPreviousId = -1;
				currentCostSheetProjectViewModel.CtshPrjFirstId = -1;
				currentCostSheetProjectViewModel.CtshPrjLastId = -1;
			}
		}
		catch (DbEntityValidationException ex)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
			currentCostSheetProjectViewModel.Message = Messages.frmErrorMessage + "<br />" + ((Exception)(object)ex).Message;
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			currentCostSheetProjectViewModel.Message = Messages.frmErrorMessage + "<br />" + ex2.Message;
		}
		JsonResult jsonResult = Json(currentCostSheetProjectViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public ActionResult CostSheetProducts_Read([DataSourceRequest] DataSourceRequest request, int ctshPrjId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectCostSheetProducts_Result> enumerable = new List<WSspSelectCostSheetProducts_Result>();
		try
		{
			if (ctshPrjId > 0)
			{
				enumerable = Enumerable.ToList<WSspSelectCostSheetProducts_Result>((IEnumerable<WSspSelectCostSheetProducts_Result>)_db.WSspSelectCostSheetProducts(ctshPrjId, lCID, result));
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

	[AjaxOnly]
	public ActionResult CostSheet_Read([DataSourceRequest] DataSourceRequest request, int ctshPrjId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectCostSheets_Result> list = new List<WSspSelectCostSheets_Result>();
		try
		{
			if (ctshPrjId > 0)
			{
				list = Enumerable.ToList<WSspSelectCostSheets_Result>((IEnumerable<WSspSelectCostSheets_Result>)_db.WSspSelectCostSheets(ctshPrjId, lCID, result));
				foreach (WSspSelectCostSheets_Result item in list)
				{
					_ = item.ctshDate;
					item.ctshDatePersian = item.ctshDate.ToString("yyyy/MM/dd HH:mm:ss");
					if (!string.IsNullOrEmpty(item.pordNumRef))
					{
						item.PreOrderInfo = item.pordNumRef;
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

	public void SetCtshPrdRegisterInfo(WSCostSheetProductsLanguageViewModel model, ref string firstRegInfo, ref string regInfo)
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
			List<CRMspSelectUsersByIds_Result> list = CRMIdeal.Classes.Helper.User.SelectUsersByIds(model.FirstRegisterUserId + "," + model.UserId);
			if (list == null || !Enumerable.Any<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list))
			{
				return;
			}
			CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.FirstRegisterUserId));
			if (cRMspSelectUsersByIds_Result != null)
			{
				firstRegInfo = ((!string.IsNullOrEmpty(cRMspSelectUsersByIds_Result.LName)) ? cRMspSelectUsersByIds_Result.LName : "") + ((!string.IsNullOrEmpty(cRMspSelectUsersByIds_Result.FName)) ? (" " + cRMspSelectUsersByIds_Result.FName) : "");
				_ = model.FirstRegisterDate;
				string text = model.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				firstRegInfo += ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			}
			CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result2 = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.UserId));
			if (cRMspSelectUsersByIds_Result2 != null)
			{
				regInfo = ((!string.IsNullOrEmpty(cRMspSelectUsersByIds_Result2.LName)) ? cRMspSelectUsersByIds_Result2.LName : "") + ((!string.IsNullOrEmpty(cRMspSelectUsersByIds_Result2.FName)) ? (" " + cRMspSelectUsersByIds_Result2.FName) : "");
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

	[DynamicAuthorize(ControllerName = "frmCostsheet", ActionName = "actprdInsert,actprdEdit")]
	public ActionResult CtshPrdInsertEdit(int ctshPrjId, int ctshPrdId = 0, bool isSelectPrd = false)
	{
		_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass8_0();
		CS_0024_003C_003E8__locals0.ctshPrdId = ctshPrdId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		WSCostSheetProductsLanguageViewModel wSCostSheetProductsLanguageViewModel = new WSCostSheetProductsLanguageViewModel();
		try
		{
			if (CS_0024_003C_003E8__locals0.ctshPrdId > 0)
			{
				if (!UserLogin.IsUserAccess("frmCostsheet", "actprdEdit"))
				{
					base.ViewBag.Error = Messages.NotAccessToPage;
					return null;
				}
				DbSet<WSCostSheetProducts_Lang> wSCostSheetProducts_Lang = _dbTbl.WSCostSheetProducts_Lang;
				ParameterExpression val = Expression.Parameter(typeof(WSCostSheetProducts_Lang), "c");
				List<WSCostSheetProducts_Lang> list = Enumerable.ToList<WSCostSheetProducts_Lang>((IEnumerable<WSCostSheetProducts_Lang>)Queryable.Where<WSCostSheetProducts_Lang>((IQueryable<WSCostSheetProducts_Lang>)wSCostSheetProducts_Lang, Expression.Lambda<Func<WSCostSheetProducts_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				DbSet<WSCostSheetProducts> wSCostSheetProducts = _dbTbl.WSCostSheetProducts;
				val = Expression.Parameter(typeof(WSCostSheetProducts), "c");
				WSCostSheetProducts wSCostSheetProducts2 = Queryable.FirstOrDefault<WSCostSheetProducts>((IQueryable<WSCostSheetProducts>)wSCostSheetProducts, Expression.Lambda<Func<WSCostSheetProducts, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (wSCostSheetProducts2 == null)
				{
					base.ViewBag.Error = Messages.ErrorNotFound;
					return null;
				}
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSCostSheetProducts_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSCostSheetProducts_Lang>)list, (Func<WSCostSheetProducts_Lang, CommonMultiLanguageViewModel>)((WSCostSheetProducts_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.ctshPrdName,
					LanguageId = item.LanguageID
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = wSCostSheetProducts2.ctshPrdName,
					LanguageId = result
				});
				wSCostSheetProductsLanguageViewModel = new WSCostSheetProductsLanguageViewModel
				{
					CostSheetProductId = wSCostSheetProducts2.CostSheetProductId,
					ctshPrdCmpProjectId = wSCostSheetProducts2.ctshPrdCmpProjectId.GetValueOrDefault(),
					ctshPrdName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					ctshPrdName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					ctshQuantity = wSCostSheetProducts2.ctshPrdQuantity,
					OrderView = wSCostSheetProducts2.OrderView,
					FirstRegisterUserId = wSCostSheetProducts2.FirstRegisterUserId,
					FirstRegisterDate = wSCostSheetProducts2.FirstRegisterDate,
					FirstRegisterDatePersian = wSCostSheetProducts2.FirstRegisterDatePersian,
					UserId = wSCostSheetProducts2.UserId,
					FPId = wSCostSheetProducts2.FPId,
					Month1 = wSCostSheetProducts2.Month1,
					RegisterDate = wSCostSheetProducts2.RegisterDate,
					RegisterDatePersian = wSCostSheetProducts2.RegisterDatePersian,
					GUId = wSCostSheetProducts2.GUId,
					AppType = wSCostSheetProducts2.AppType,
					LanguageID = wSCostSheetProducts2.LanguageID,
					ctshPrdGroupId = wSCostSheetProducts2.ctshPrdGroupId,
					ctshPrdProductId = wSCostSheetProducts2.ctshPrdId
				};
				int result2 = 0;
				if (wSCostSheetProductsLanguageViewModel != null)
				{
					int.TryParse(wSCostSheetProductsLanguageViewModel.ctshPrdProductId.ToString(), out result2);
					if (result2 != 0)
					{
						wSCostSheetProductsLanguageViewModel.IsSelectPrd = true;
						WSspSelectProductsWithId_Result wSspSelectProductsWithId_Result = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(result2, CS_0024_003C_003E8__locals0.currLangID, result));
						if (wSspSelectProductsWithId_Result != null)
						{
							string text = wSspSelectProductsWithId_Result.PrdName ?? "";
							string text2 = wSspSelectProductsWithId_Result.PrdCode ?? "";
							if (!string.IsNullOrWhiteSpace(text2))
							{
								text = text + " (" + text2 + ")";
							}
							wSCostSheetProductsLanguageViewModel.ctshPrdName_I = text;
						}
					}
				}
			}
			else
			{
				if (!UserLogin.IsUserAccess("frmCostsheet", "actprdInsert"))
				{
					base.ViewBag.Error = Messages.NotAccessToPage;
					return null;
				}
				DateTime now = DateTime.Now;
				wSCostSheetProductsLanguageViewModel = new WSCostSheetProductsLanguageViewModel
				{
					FirstRegisterUserId = UserLogin.CurrentUser.UserId,
					FirstRegisterDate = now,
					FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
					UserId = UserLogin.CurrentUser.UserId,
					RegisterDate = now,
					RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
					ctshQuantity = 1.0,
					ctshPrdCmpProjectId = ctshPrjId,
					IsSelectPrd = isSelectPrd
				};
				if (!Enumerable.Any<WSspSelectCostSheetProducts_Result>((IEnumerable<WSspSelectCostSheetProducts_Result>)Enumerable.ToList<WSspSelectCostSheetProducts_Result>((IEnumerable<WSspSelectCostSheetProducts_Result>)_db.WSspSelectCostSheetProducts(ctshPrjId, CS_0024_003C_003E8__locals0.currLangID, result))))
				{
					wSCostSheetProductsLanguageViewModel.OrderView = 10;
				}
				base.ViewBag.IsBuying = VersionBuyer.Costsheet;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			base.ViewBag.Error = Messages.msgErrorRunFunction;
		}
		string firstRegInfo = "";
		string regInfo = "";
		SetCtshPrdRegisterInfo(wSCostSheetProductsLanguageViewModel, ref firstRegInfo, ref regInfo);
		wSCostSheetProductsLanguageViewModel.FirstRegisterUser = firstRegInfo;
		wSCostSheetProductsLanguageViewModel.EditUser = ((CS_0024_003C_003E8__locals0.ctshPrdId > 0) ? regInfo : "");
		return View(wSCostSheetProductsLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmCostsheetProductDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult CtshPrdInsertEdit(WSCostSheetProductsLanguageViewModel vm)
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass9_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ctshPrdName_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.ctshPrdName_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.ctshPrdName,
			LanguageId = lCID
		});
		CS_0024_003C_003E8__locals0.ctshSelectPrdId = 0;
		if (CS_0024_003C_003E8__locals0.vm != null)
		{
			int.TryParse(CS_0024_003C_003E8__locals0.vm.ctshPrdProductId.ToString(), out CS_0024_003C_003E8__locals0.ctshSelectPrdId);
			if (CS_0024_003C_003E8__locals0.ctshSelectPrdId != 0)
			{
				DbSet<WSProducts> wSProducts = _dbTbl.WSProducts;
				ParameterExpression val = Expression.Parameter(typeof(WSProducts), "c");
				WSProducts wSProducts2 = Queryable.FirstOrDefault<WSProducts>((IQueryable<WSProducts>)wSProducts, Expression.Lambda<Func<WSProducts, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass9_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (wSProducts2 != null)
				{
					DbSet<WSProducts_Lang> wSProducts_Lang = _dbTbl.WSProducts_Lang;
					val = Expression.Parameter(typeof(WSProducts_Lang), "c");
					List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProducts_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProducts_Lang>)Enumerable.ToList<WSProducts_Lang>((IEnumerable<WSProducts_Lang>)Queryable.Where<WSProducts_Lang>((IQueryable<WSProducts_Lang>)wSProducts_Lang, Expression.Lambda<Func<WSProducts_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass9_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }))), (Func<WSProducts_Lang, CommonMultiLanguageViewModel>)((WSProducts_Lang item) => new CommonMultiLanguageViewModel
					{
						Value = item.PrdName,
						LanguageId = item.LanguageID
					})));
					list2.Add(new CommonMultiLanguageViewModel
					{
						Value = wSProducts2.PrdName,
						LanguageId = CS_0024_003C_003E8__locals0.defLangID
					});
					if (list2 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2))
					{
						list = new List<CommonMultiLanguageViewModel>();
						list.AddRange(list2);
					}
					if (wSProducts2.PrdGroupID != CS_0024_003C_003E8__locals0.vm.ctshPrdGroupId.GetValueOrDefault())
					{
						CS_0024_003C_003E8__locals0.vm.ctshPrdGroupId = wSProducts2.PrdGroupID;
					}
				}
			}
			else
			{
				CS_0024_003C_003E8__locals0.vm.ctshPrdProductId = null;
			}
		}
		string text = "";
		if (CS_0024_003C_003E8__locals0.vm.ctshPrdName == null && CS_0024_003C_003E8__locals0.vm.ctshPrdName == "")
		{
			text = text + string.Format(Messages.ErrorEmpty, Labels.ctshPrdName) + "<br/>";
		}
		else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.ctshPrdName, list))
		{
			text = text + string.Format(Messages.CheckFieldInLang, Labels.ctshPrdName) + "<br>";
		}
		if (text != "")
		{
			base.ViewBag.Error = text;
			return View(CS_0024_003C_003E8__locals0.vm);
		}
		try
		{
			if (CS_0024_003C_003E8__locals0.vm.CostSheetProductId <= 0 && !VersionBuyer.Costsheet)
			{
				DbSet<WSCostSheetProducts> wSCostSheetProducts = _dbTbl.WSCostSheetProducts;
				ParameterExpression val = Expression.Parameter(typeof(WSCostSheetProducts), "c");
				if (Queryable.Any<WSCostSheetProducts>((IQueryable<WSCostSheetProducts>)wSCostSheetProducts, Expression.Lambda<Func<WSCostSheetProducts, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)10, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val })))
				{
					base.ViewBag.Error = "BV|" + Messages.VersionBuy;
					return View(CS_0024_003C_003E8__locals0.vm);
				}
			}
			if (!base.ModelState.IsValid)
			{
				base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
			else
			{
				_003C_003Ec__DisplayClass9_1 _003C_003Ec__DisplayClass9_ = new _003C_003Ec__DisplayClass9_1();
				DateTime now = DateTime.Now;
				DateTime dateTime = now;
				string text2 = now.ToString("yyyyMMdd", new PersianCulture());
				short month = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				int id = Financial.Get().Id;
				int userId = UserLogin.CurrentUser.UserId;
				_003C_003Ec__DisplayClass9_.model = new WSCostSheetProducts();
				if (CS_0024_003C_003E8__locals0.vm.CostSheetProductId > 0)
				{
					DbSet<WSCostSheetProducts> wSCostSheetProducts2 = _dbTbl.WSCostSheetProducts;
					ParameterExpression val = Expression.Parameter(typeof(WSCostSheetProducts), "c");
					_003C_003Ec__DisplayClass9_.model = Queryable.FirstOrDefault<WSCostSheetProducts>((IQueryable<WSCostSheetProducts>)wSCostSheetProducts2, Expression.Lambda<Func<WSCostSheetProducts, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass9_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				_003C_003Ec__DisplayClass9_.model.ctshPrdCmpProjectId = CS_0024_003C_003E8__locals0.vm.ctshPrdCmpProjectId;
				_003C_003Ec__DisplayClass9_.model.ctshPrdName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass9_.model.ctshPrdQuantity = CS_0024_003C_003E8__locals0.vm.ctshQuantity;
				_003C_003Ec__DisplayClass9_.model.OrderView = CS_0024_003C_003E8__locals0.vm.OrderView;
				_003C_003Ec__DisplayClass9_.model.UserId = userId;
				_003C_003Ec__DisplayClass9_.model.Month1 = month;
				_003C_003Ec__DisplayClass9_.model.RegisterDate = dateTime;
				_003C_003Ec__DisplayClass9_.model.RegisterDatePersian = text2;
				_003C_003Ec__DisplayClass9_.model.AppType = appType;
				if (!CS_0024_003C_003E8__locals0.vm.ctshPrdGroupId.HasValue || CS_0024_003C_003E8__locals0.vm.ctshPrdGroupId == 0)
				{
					CS_0024_003C_003E8__locals0.vm.ctshPrdGroupId = null;
				}
				_003C_003Ec__DisplayClass9_.model.ctshPrdGroupId = CS_0024_003C_003E8__locals0.vm.ctshPrdGroupId;
				_003C_003Ec__DisplayClass9_.model.ctshPrdId = CS_0024_003C_003E8__locals0.vm.ctshPrdProductId;
				if (_003C_003Ec__DisplayClass9_.model.CostSheetProductId > 0)
				{
					_dbTbl.Entry(_003C_003Ec__DisplayClass9_.model).State = EntityState.Modified;
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass9_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass9_2();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass9_;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							DbSet<WSCostSheetProducts_Lang> wSCostSheetProducts_Lang = _dbTbl.WSCostSheetProducts_Lang;
							ParameterExpression val = Expression.Parameter(typeof(WSCostSheetProducts_Lang), "c");
							WSCostSheetProducts_Lang wSCostSheetProducts_Lang2 = Queryable.FirstOrDefault<WSCostSheetProducts_Lang>((IQueryable<WSCostSheetProducts_Lang>)wSCostSheetProducts_Lang, Expression.Lambda<Func<WSCostSheetProducts_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass9_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass9_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (wSCostSheetProducts_Lang2 != null)
							{
								wSCostSheetProducts_Lang2.ctshPrdName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(wSCostSheetProducts_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							wSCostSheetProducts_Lang2 = new WSCostSheetProducts_Lang();
							wSCostSheetProducts_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
							wSCostSheetProducts_Lang2.CostSheetProductId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.CostSheetProductId;
							wSCostSheetProducts_Lang2.ctshPrdName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							_dbTbl.WSCostSheetProducts_Lang.Add(wSCostSheetProducts_Lang2);
							_dbTbl.SaveChanges();
						}
					}
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
				else
				{
					_003C_003Ec__DisplayClass9_.model.FPId = id;
					if (!CS_0024_003C_003E8__locals0.vm.OrderView.HasValue)
					{
						List<WSspSelectCostSheetProducts_Result> list3 = Enumerable.ToList<WSspSelectCostSheetProducts_Result>((IEnumerable<WSspSelectCostSheetProducts_Result>)_db.WSspSelectCostSheetProducts(_003C_003Ec__DisplayClass9_.model.ctshPrdCmpProjectId, lCID, CS_0024_003C_003E8__locals0.defLangID));
						int num = (Enumerable.Any<WSspSelectCostSheetProducts_Result>((IEnumerable<WSspSelectCostSheetProducts_Result>)list3) ? Enumerable.Count<WSspSelectCostSheetProducts_Result>((IEnumerable<WSspSelectCostSheetProducts_Result>)list3) : 0);
						_003C_003Ec__DisplayClass9_.model.OrderView = num * 10 + 10;
						if (Enumerable.LastOrDefault<WSspSelectCostSheetProducts_Result>((IEnumerable<WSspSelectCostSheetProducts_Result>)list3) != null)
						{
							int valueOrDefault = Enumerable.LastOrDefault<WSspSelectCostSheetProducts_Result>((IEnumerable<WSspSelectCostSheetProducts_Result>)list3).OrderView.GetValueOrDefault();
							if (valueOrDefault > 0)
							{
								_003C_003Ec__DisplayClass9_.model.OrderView = valueOrDefault + 10;
							}
						}
					}
					else
					{
						_003C_003Ec__DisplayClass9_.model.OrderView = CS_0024_003C_003E8__locals0.vm.OrderView;
					}
					_003C_003Ec__DisplayClass9_.model.FirstRegisterUserId = userId;
					_003C_003Ec__DisplayClass9_.model.FirstRegisterDate = dateTime;
					_003C_003Ec__DisplayClass9_.model.FirstRegisterDatePersian = text2;
					_003C_003Ec__DisplayClass9_.model.GUId = Guid.NewGuid();
					_003C_003Ec__DisplayClass9_.model.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
					_dbTbl.WSCostSheetProducts.Add(_003C_003Ec__DisplayClass9_.model);
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					if (_003C_003Ec__DisplayClass9_.model.CostSheetProductId <= 0)
					{
						base.ViewBag.Error = Messages.msgErrorRunFunction;
					}
					else
					{
						foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
						{
							WSCostSheetProducts_Lang wSCostSheetProducts_Lang3 = new WSCostSheetProducts_Lang();
							wSCostSheetProducts_Lang3.LanguageID = lang.LanguageID;
							wSCostSheetProducts_Lang3.CostSheetProductId = _003C_003Ec__DisplayClass9_.model.CostSheetProductId;
							wSCostSheetProducts_Lang3.ctshPrdName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
							_dbTbl.WSCostSheetProducts_Lang.Add(wSCostSheetProducts_Lang3);
							_dbTbl.SaveChanges();
						}
						CS_0024_003C_003E8__locals0.vm.CostSheetProductId = _003C_003Ec__DisplayClass9_.model.CostSheetProductId;
						base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
					}
				}
				string firstRegInfo = "";
				string regInfo = "";
				CS_0024_003C_003E8__locals0.vm.FirstRegisterUserId = _003C_003Ec__DisplayClass9_.model.FirstRegisterUserId;
				CS_0024_003C_003E8__locals0.vm.UserId = userId;
				CS_0024_003C_003E8__locals0.vm.FirstRegisterDate = _003C_003Ec__DisplayClass9_.model.FirstRegisterDate;
				CS_0024_003C_003E8__locals0.vm.RegisterDate = dateTime;
				CS_0024_003C_003E8__locals0.vm.FirstRegisterDatePersian = _003C_003Ec__DisplayClass9_.model.FirstRegisterDatePersian;
				CS_0024_003C_003E8__locals0.vm.RegisterDatePersian = text2;
				CS_0024_003C_003E8__locals0.vm.AppType = appType;
				SetCtshPrdRegisterInfo(CS_0024_003C_003E8__locals0.vm, ref firstRegInfo, ref regInfo);
				CS_0024_003C_003E8__locals0.vm.FirstRegisterUser = firstRegInfo;
				CS_0024_003C_003E8__locals0.vm.EditUser = regInfo;
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			base.ViewBag.Error = Messages.msgErrorRunFunction;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			base.ViewBag.Error = Messages.msgErrorRunFunction;
		}
		return View(CS_0024_003C_003E8__locals0.vm);
	}

	[AjaxOnly]
	public ActionResult _PartialCtshPrdGroupTree(int groupId = 0)
	{
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<TreeViewItemModel> list = new List<TreeViewItemModel>();
			List<WSspSelectProductGroupTree_Result> list2 = Enumerable.ToList<WSspSelectProductGroupTree_Result>((IEnumerable<WSspSelectProductGroupTree_Result>)_db.WSspSelectProductGroupTree(lCID, result));
			if (list2 != null)
			{
				foreach (WSspSelectProductGroupTree_Result item in Enumerable.ToList<WSspSelectProductGroupTree_Result>(Enumerable.Where<WSspSelectProductGroupTree_Result>((IEnumerable<WSspSelectProductGroupTree_Result>)list2, (Func<WSspSelectProductGroupTree_Result, bool>)((WSspSelectProductGroupTree_Result c) => c.ParentId == 0))))
				{
					TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
					treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", "0"));
					treeViewItemModel.Id = "0";
					treeViewItemModel.Text = item.KEYName;
					treeViewItemModel.ImageUrl = "";
					List<WSspSelectProductGroupTree_Result> list3 = Enumerable.ToList<WSspSelectProductGroupTree_Result>(Enumerable.Where<WSspSelectProductGroupTree_Result>((IEnumerable<WSspSelectProductGroupTree_Result>)list2, (Func<WSspSelectProductGroupTree_Result, bool>)((WSspSelectProductGroupTree_Result c) => c.ParentId == item.FId)));
					List<TreeViewItemModel> list4 = new List<TreeViewItemModel>();
					foreach (WSspSelectProductGroupTree_Result item2 in list3)
					{
						TreeViewItemModel treeViewItemModel2 = new TreeViewItemModel();
						treeViewItemModel2.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item2.SId.ToString()));
						treeViewItemModel2.Id = item2.SId.ToString();
						treeViewItemModel2.Text = item2.KEYName;
						treeViewItemModel2.ImageUrl = "";
						treeViewItemModel2.Items = null;
						list4.Add(treeViewItemModel2);
					}
					treeViewItemModel.Items = new List<TreeViewItemModel>(list4);
					list.Add(treeViewItemModel);
				}
			}
			base.ViewBag.CtshPrdGroupTree = list;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView();
	}

	[AjaxOnly]
	public JsonResult SearchProducts(string text = "", int showMode = 0, int prdKind = 0, int companyId = 0, int projectId = 0)
	{
		List<WSspSearchProducts_Result> list = new List<WSspSearchProducts_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (!string.IsNullOrWhiteSpace(text))
			{
				list = Enumerable.ToList<WSspSearchProducts_Result>(Enumerable.Take<WSspSearchProducts_Result>((IEnumerable<WSspSearchProducts_Result>)_db.WSspSearchProducts(0, 0, text, text, 0, showMode, lCID, result, prdKind, 0, companyId, projectId, "", null), 800));
				foreach (WSspSearchProducts_Result item in list)
				{
					item.PrdLinkAccPrdCode = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccCodeWithComa(2, item.PrdLinkAccPrdCode);
					item.PrdLinkAccPrdIdStr = item.PName + "|" + item.PrdCode + "|" + item.PrdModel + "|" + item.PrdLatinName + "|" + item.PrdBarcode + "|" + item.PrdFirstBarcode + "|" + item.PrdLinkAccPrdCode + "|";
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
	[DynamicAuthorize(ControllerName = "frmCostsheet", ActionName = "actprdDelete")]
	public string ActPrdDelete(int ctshPrdId)
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
			if (!UserLogin.IsUserAccess("frmCostsheet", "actprdDelete", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			if (ctshPrdId > 0)
			{
				try
				{
					mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteCostSheetProducts(ctshPrdId));
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
	[DynamicAuthorize(ControllerName = "frmCostsheet", ActionName = "actTransferProductToCostSheet")]
	public string TransferCostSheetProduct(int ctshPrdId, int fromCtshId, int toCtshId)
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
			if (!UserLogin.IsUserAccess("frmCostsheet", "actTransferProductToCostSheet", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			if (ctshPrdId > 0 && toCtshId > 0)
			{
				if (Costsheet.IsFixed(toCtshId))
				{
					return Messages.msgErrorCtshNotEditable;
				}
				if (fromCtshId > 0 && Costsheet.IsFixed(fromCtshId))
				{
					return Messages.msgErrorCtshNotEditable;
				}
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				int id = Financial.Get().Id;
				int userId = UserLogin.CurrentUser.UserId;
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.WSspTransferCostSheetProduct(ctshPrdId, fromCtshId, toCtshId, userId, id, value2, value, registerDatePersian, appType, result2));
				if (mct_Result != null && mct_Result.Result > 0)
				{
					result = "";
				}
				else if (mct_Result != null && mct_Result.Result == 0)
				{
					result = Messages.msgErrorRunFunction;
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

	public void SetCtshRegisterInfo(WSCostSheetsLanguageViewModel model, ref string firstRegInfo, ref string regInfo)
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
			List<CRMspSelectUsersByIds_Result> list = CRMIdeal.Classes.Helper.User.SelectUsersByIds(model.FirstRegisterUserId + "," + model.UserId);
			if (list == null || !Enumerable.Any<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list))
			{
				return;
			}
			CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.FirstRegisterUserId));
			if (cRMspSelectUsersByIds_Result != null)
			{
				firstRegInfo = ((!string.IsNullOrEmpty(cRMspSelectUsersByIds_Result.LName)) ? cRMspSelectUsersByIds_Result.LName : "") + ((!string.IsNullOrEmpty(cRMspSelectUsersByIds_Result.FName)) ? (" " + cRMspSelectUsersByIds_Result.FName) : "");
				_ = model.FirstRegisterDate;
				string text = model.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				firstRegInfo += ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			}
			CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result2 = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.UserId));
			if (cRMspSelectUsersByIds_Result2 != null)
			{
				regInfo = ((!string.IsNullOrEmpty(cRMspSelectUsersByIds_Result2.LName)) ? cRMspSelectUsersByIds_Result2.LName : "") + ((!string.IsNullOrEmpty(cRMspSelectUsersByIds_Result2.FName)) ? (" " + cRMspSelectUsersByIds_Result2.FName) : "");
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

	[DynamicAuthorize(ControllerName = "frmCostsheet", ActionName = "actctshInsert,actctshEdit")]
	public ActionResult CtshInsertEdit(int ctshPrjId, int ctshId = 0, string ctshPrdIds = "")
	{
		_003C_003Ec__DisplayClass15_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass15_0();
		CS_0024_003C_003E8__locals0.ctshId = ctshId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		WSCostSheetsLanguageViewModel wSCostSheetsLanguageViewModel = new WSCostSheetsLanguageViewModel();
		try
		{
			if (CS_0024_003C_003E8__locals0.ctshId > 0)
			{
				if (!UserLogin.IsUserAccess("frmCostsheet", "actctshEdit"))
				{
					base.ViewBag.Error = Messages.NotAccessToPage;
					return null;
				}
				DbSet<WSCostSheets_Lang> wSCostSheets_Lang = _dbTbl.WSCostSheets_Lang;
				ParameterExpression val = Expression.Parameter(typeof(WSCostSheets_Lang), "c");
				List<WSCostSheets_Lang> list = Enumerable.ToList<WSCostSheets_Lang>((IEnumerable<WSCostSheets_Lang>)Queryable.Where<WSCostSheets_Lang>((IQueryable<WSCostSheets_Lang>)wSCostSheets_Lang, Expression.Lambda<Func<WSCostSheets_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass15_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				DbSet<WSCostSheets> wSCostSheets = _dbTbl.WSCostSheets;
				val = Expression.Parameter(typeof(WSCostSheets), "c");
				WSCostSheets wSCostSheets2 = Queryable.FirstOrDefault<WSCostSheets>((IQueryable<WSCostSheets>)wSCostSheets, Expression.Lambda<Func<WSCostSheets, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass15_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (wSCostSheets2 == null)
				{
					base.ViewBag.Error = Messages.ErrorNotFound;
					return null;
				}
				if (Costsheet.IsFixed(wSCostSheets2.CostSheetId))
				{
					return null;
				}
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSCostSheets_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSCostSheets_Lang>)list, (Func<WSCostSheets_Lang, CommonMultiLanguageViewModel>)((WSCostSheets_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.ctshTitle,
					LanguageId = item.LanguageID
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = wSCostSheets2.ctshTitle,
					LanguageId = result
				});
				WSCostSheetsLanguageViewModel obj = new WSCostSheetsLanguageViewModel
				{
					CostSheetId = wSCostSheets2.CostSheetId,
					ctshCmpProjectId = wSCostSheets2.ctshCmpProjectId.GetValueOrDefault(),
					ctshNumber = wSCostSheets2.ctshNumber,
					ctshDate = wSCostSheets2.ctshDate
				};
				_ = wSCostSheets2.ctshDate;
				obj.ctshDatePersian = wSCostSheets2.ctshDate.ToString("yyyy/MM/dd");
				obj.ctshTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
				obj.ctshTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
				obj.ctshSrcCurrencyUnitId = wSCostSheets2.ctshSrcCurrencyUnitId;
				obj.ctshDestCurrencyUnitId = wSCostSheets2.ctshDestCurrencyUnitId;
				obj.ctshCurrencyRate = wSCostSheets2.ctshCurrencyRate;
				obj.ctshRoundRate = wSCostSheets2.ctshRoundRate;
				obj.ctshTaxIndex = wSCostSheets2.ctshTaxIndex;
				obj.FirstRegisterUserId = wSCostSheets2.FirstRegisterUserId;
				obj.FirstRegisterDate = wSCostSheets2.FirstRegisterDate;
				obj.FirstRegisterDatePersian = wSCostSheets2.FirstRegisterDatePersian;
				obj.UserId = wSCostSheets2.UserId;
				obj.FPId = wSCostSheets2.FPId;
				obj.Month1 = wSCostSheets2.Month1;
				obj.RegisterDate = wSCostSheets2.RegisterDate;
				obj.RegisterDatePersian = wSCostSheets2.RegisterDatePersian;
				obj.GUId = wSCostSheets2.GUId;
				obj.AppType = wSCostSheets2.AppType;
				obj.LanguageID = wSCostSheets2.LanguageID;
				obj.Mode = 2;
				obj.IsAddItems = false;
				obj.ctshNumRef = wSCostSheets2.ctshNumRef;
				wSCostSheetsLanguageViewModel = obj;
			}
			else
			{
				if (!UserLogin.IsUserAccess("frmCostsheet", "actctshInsert"))
				{
					base.ViewBag.Error = Messages.NotAccessToPage;
					return null;
				}
				DateTime now = DateTime.Now;
				long ctshNumber = Enumerable.FirstOrDefault<long>((IEnumerable<long>)Enumerable.ToList<long>(_db.Database.SqlQuery<long>($"Select dbo.WSfnReturnCostSheetNumber({ctshPrjId})", Array.Empty<object>())));
				wSCostSheetsLanguageViewModel = new WSCostSheetsLanguageViewModel
				{
					FirstRegisterUserId = UserLogin.CurrentUser.UserId,
					FirstRegisterDate = now,
					FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
					UserId = UserLogin.CurrentUser.UserId,
					RegisterDate = now,
					RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
					ctshCmpProjectId = ctshPrjId,
					ctshNumber = ctshNumber,
					ctshDate = now,
					ctshDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
					Mode = 1,
					IsAddItems = false,
					costSheetProductIds = ctshPrdIds
				};
				base.ViewBag.IsBuying = VersionBuyer.Costsheet;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			base.ViewBag.Error = Messages.msgErrorRunFunction;
		}
		string firstRegInfo = "";
		string regInfo = "";
		SetCtshRegisterInfo(wSCostSheetsLanguageViewModel, ref firstRegInfo, ref regInfo);
		wSCostSheetsLanguageViewModel.FirstRegisterUser = firstRegInfo;
		wSCostSheetsLanguageViewModel.EditUser = ((CS_0024_003C_003E8__locals0.ctshId > 0) ? regInfo : "");
		GetCurrencyUnits();
		GetDyFieldGroups();
		return View(wSCostSheetsLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmCostsheetDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult CtshInsertEdit(WSCostSheetsLanguageViewModel vm)
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass16_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ctshTitle_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.ctshTitle_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.ctshTitle,
			LanguageId = lCID
		});
		GetCurrencyUnits();
		GetDyFieldGroups();
		string text = "";
		if (CS_0024_003C_003E8__locals0.vm.ctshTitle == null && CS_0024_003C_003E8__locals0.vm.ctshTitle == "")
		{
			text = text + string.Format(Messages.ErrorEmpty, Labels.ctshTitle) + "<br/>";
		}
		else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.ctshTitle, list))
		{
			text = text + string.Format(Messages.CheckFieldInLang, Labels.ctshTitle) + "<br>";
		}
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ctshNumRef) && UserLogin.IsUserAccess("frmCostsheetDataEntry", "actNotDupNumRef", UserLogin.CurrentUser))
		{
			WSspCheckDuplicateCostSheetNumRef_Result wSspCheckDuplicateCostSheetNumRef_Result = Enumerable.FirstOrDefault<WSspCheckDuplicateCostSheetNumRef_Result>((IEnumerable<WSspCheckDuplicateCostSheetNumRef_Result>)_db.WSspCheckDuplicateCostSheetNumRef(CS_0024_003C_003E8__locals0.vm.ctshNumRef, CS_0024_003C_003E8__locals0.vm.CostSheetId));
			if (wSspCheckDuplicateCostSheetNumRef_Result != null)
			{
				base.ViewBag.Error = string.Format(Messages.CostSheetNumRefIsRepeated, wSspCheckDuplicateCostSheetNumRef_Result.ctshNumber.ToString());
				return View(CS_0024_003C_003E8__locals0.vm);
			}
		}
		if (text != "")
		{
			base.ViewBag.Error = text;
			return View(CS_0024_003C_003E8__locals0.vm);
		}
		DateTime dateTime = default(DateTime);
		string text2 = "";
		try
		{
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ctshDatePersian))
			{
				text2 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.vm.ctshDatePersian.Replace("/", ""));
				switch (lCID)
				{
				case 1065:
					dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
					CS_0024_003C_003E8__locals0.vm.ctshDatePersian = dateTime.ToString("yyyyMMdd");
					break;
				case 1025:
					dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
					CS_0024_003C_003E8__locals0.vm.ctshDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
					break;
				default:
					dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
					CS_0024_003C_003E8__locals0.vm.ctshDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
					break;
				}
				CS_0024_003C_003E8__locals0.vm.ctshDate = dateTime;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			base.ViewBag.Error = Messages.WrongDateTime;
			return View(CS_0024_003C_003E8__locals0.vm);
		}
		if (CS_0024_003C_003E8__locals0.vm.ctshDatePersian != null)
		{
			CS_0024_003C_003E8__locals0.vm.ctshDatePersian = CS_0024_003C_003E8__locals0.vm.ctshDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
				.Replace(".", "")
				.Replace(",", "")
				.Replace("\\", "");
		}
		long num = 0L;
		string text3 = "";
		int sysPartId = 300;
		try
		{
			if (CS_0024_003C_003E8__locals0.vm.CostSheetId <= 0 && !VersionBuyer.Costsheet)
			{
				DbSet<WSCostSheets> wSCostSheets = _dbTbl.WSCostSheets;
				ParameterExpression val = Expression.Parameter(typeof(WSCostSheets), "c");
				if (Queryable.Any<WSCostSheets>((IQueryable<WSCostSheets>)wSCostSheets, Expression.Lambda<Func<WSCostSheets, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)10, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val })))
				{
					base.ViewBag.Error = "BV|" + Messages.VersionBuy;
					return View(CS_0024_003C_003E8__locals0.vm);
				}
			}
			if (!base.ModelState.IsValid)
			{
				base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
			else
			{
				_003C_003Ec__DisplayClass16_1 _003C_003Ec__DisplayClass16_ = new _003C_003Ec__DisplayClass16_1();
				DateTime now = DateTime.Now;
				DateTime dateTime2 = now;
				string text4 = now.ToString("yyyyMMdd", new PersianCulture());
				short num2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				int id = Financial.Get().Id;
				int userId = UserLogin.CurrentUser.UserId;
				_003C_003Ec__DisplayClass16_.model = new WSCostSheets();
				if (CS_0024_003C_003E8__locals0.vm.CostSheetId > 0)
				{
					DbSet<WSCostSheets> wSCostSheets2 = _dbTbl.WSCostSheets;
					ParameterExpression val = Expression.Parameter(typeof(WSCostSheets), "c");
					_003C_003Ec__DisplayClass16_.model = Queryable.FirstOrDefault<WSCostSheets>((IQueryable<WSCostSheets>)wSCostSheets2, Expression.Lambda<Func<WSCostSheets, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass16_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				_003C_003Ec__DisplayClass16_.model.ctshCmpProjectId = CS_0024_003C_003E8__locals0.vm.ctshCmpProjectId;
				_003C_003Ec__DisplayClass16_.model.ctshDate = CS_0024_003C_003E8__locals0.vm.ctshDate;
				_003C_003Ec__DisplayClass16_.model.ctshDatePersian = CS_0024_003C_003E8__locals0.vm.ctshDatePersian;
				_003C_003Ec__DisplayClass16_.model.ctshNumber = CS_0024_003C_003E8__locals0.vm.ctshNumber;
				_003C_003Ec__DisplayClass16_.model.ctshTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass16_.model.ctshSrcCurrencyUnitId = CS_0024_003C_003E8__locals0.vm.ctshSrcCurrencyUnitId;
				_003C_003Ec__DisplayClass16_.model.ctshDestCurrencyUnitId = CS_0024_003C_003E8__locals0.vm.ctshDestCurrencyUnitId;
				_003C_003Ec__DisplayClass16_.model.ctshCurrencyRate = CS_0024_003C_003E8__locals0.vm.ctshCurrencyRate.GetValueOrDefault();
				_003C_003Ec__DisplayClass16_.model.ctshRoundRate = CS_0024_003C_003E8__locals0.vm.ctshRoundRate.GetValueOrDefault();
				_003C_003Ec__DisplayClass16_.model.ctshTaxIndex = CS_0024_003C_003E8__locals0.vm.ctshTaxIndex;
				_003C_003Ec__DisplayClass16_.model.UserId = userId;
				_003C_003Ec__DisplayClass16_.model.Month1 = num2;
				_003C_003Ec__DisplayClass16_.model.RegisterDate = dateTime2;
				_003C_003Ec__DisplayClass16_.model.RegisterDatePersian = text4;
				_003C_003Ec__DisplayClass16_.model.AppType = appType;
				if (_003C_003Ec__DisplayClass16_.model.CostSheetId > 0)
				{
					long.TryParse(_003C_003Ec__DisplayClass16_.model.ctshNumber.ToString(), out var result);
					if (CheckDuplicateNumber(result, _003C_003Ec__DisplayClass16_.model.ctshCmpProjectId.GetValueOrDefault(), _003C_003Ec__DisplayClass16_.model.CostSheetId) > 0)
					{
						if (CS_0024_003C_003E8__locals0.vm.ctshDatePersian != null)
						{
							WSCostSheetsLanguageViewModel vm2 = CS_0024_003C_003E8__locals0.vm;
							_ = CS_0024_003C_003E8__locals0.vm.ctshDate;
							vm2.ctshDatePersian = ((lCID != 1065) ? CS_0024_003C_003E8__locals0.vm.ctshDate.ToString("yyyyMMdd") : CS_0024_003C_003E8__locals0.vm.ctshDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
								.Replace(".", "")
								.Replace(",", "")
								.Replace("\\", ""));
							CS_0024_003C_003E8__locals0.vm.ctshDatePersian = DateTimeClass.ConvertDateWOSlashToSlash(CS_0024_003C_003E8__locals0.vm.ctshDatePersian);
						}
						base.ViewBag.Error = Messages.CostsheetNumberIsDuplicate;
						return View(CS_0024_003C_003E8__locals0.vm);
					}
					if (UserLogin.IsUserAccess("frmCostsheetDataEntry", "actCanChangeNumRef", UserLogin.CurrentUser))
					{
						_003C_003Ec__DisplayClass16_.model.ctshNumRef = CS_0024_003C_003E8__locals0.vm.ctshNumRef;
					}
					_dbTbl.Entry(_003C_003Ec__DisplayClass16_.model).State = EntityState.Modified;
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass16_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass16_2();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass16_;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							DbSet<WSCostSheets_Lang> wSCostSheets_Lang = _dbTbl.WSCostSheets_Lang;
							ParameterExpression val = Expression.Parameter(typeof(WSCostSheets_Lang), "c");
							WSCostSheets_Lang wSCostSheets_Lang2 = Queryable.FirstOrDefault<WSCostSheets_Lang>((IQueryable<WSCostSheets_Lang>)wSCostSheets_Lang, Expression.Lambda<Func<WSCostSheets_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass16_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass16_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (wSCostSheets_Lang2 != null)
							{
								wSCostSheets_Lang2.ctshTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(wSCostSheets_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							wSCostSheets_Lang2 = new WSCostSheets_Lang();
							wSCostSheets_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
							wSCostSheets_Lang2.CostSheetId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.CostSheetId;
							wSCostSheets_Lang2.ctshTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							_dbTbl.WSCostSheets_Lang.Add(wSCostSheets_Lang2);
							_dbTbl.SaveChanges();
						}
					}
					_db.WSspCalculateCostSheet(_003C_003Ec__DisplayClass16_.model.CostSheetId, userId, dateTime2, text4, id, num2, appType);
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
				else
				{
					_003C_003Ec__DisplayClass16_.model.FPId = id;
					bool flag = false;
					int num3 = 0;
					while (!flag)
					{
						long ctshNumber = Enumerable.FirstOrDefault<long>((IEnumerable<long>)Enumerable.ToList<long>(_db.Database.SqlQuery<long>($"Select dbo.WSfnReturnCostSheetNumber({_003C_003Ec__DisplayClass16_.model.ctshCmpProjectId})", Array.Empty<object>())));
						_003C_003Ec__DisplayClass16_.model.ctshNumber = ctshNumber;
						num = _003C_003Ec__DisplayClass16_.model.ctshNumber;
						flag = ReservedNumber.AddNumber(sysPartId, num);
						num3++;
						if (num3 > 10)
						{
							break;
						}
					}
					_003C_003Ec__DisplayClass16_.model.FirstRegisterUserId = userId;
					_003C_003Ec__DisplayClass16_.model.FirstRegisterDate = dateTime2;
					_003C_003Ec__DisplayClass16_.model.FirstRegisterDatePersian = text4;
					_003C_003Ec__DisplayClass16_.model.GUId = Guid.NewGuid();
					_003C_003Ec__DisplayClass16_.model.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
					if (UserLogin.IsUserAccess("frmCostsheetDataEntry", "actAutoCalcNumRef", UserLogin.CurrentUser))
					{
						flag = false;
						num3 = 0;
						while (!flag)
						{
							string ctshNumRef = Enumerable.FirstOrDefault<string>((IEnumerable<string>)_db.WSspReturnCostSheetNumRef(_003C_003Ec__DisplayClass16_.model.ctshCmpProjectId, UserLogin.CurrentUser.UserId, _003C_003Ec__DisplayClass16_.model.ctshNumber, lCID, CS_0024_003C_003E8__locals0.defLangID));
							_003C_003Ec__DisplayClass16_.model.ctshNumRef = ctshNumRef;
							text3 = _003C_003Ec__DisplayClass16_.model.ctshNumRef;
							flag = string.IsNullOrWhiteSpace(text3) || !UserLogin.IsUserAccess("frmCostsheetDataEntry", "actNotDupNumRef", UserLogin.CurrentUser) || ReservedNumber.AddNumber(sysPartId, 0, text3);
							num3++;
							if (num3 > 10)
							{
								break;
							}
						}
					}
					else
					{
						_003C_003Ec__DisplayClass16_.model.ctshNumRef = CS_0024_003C_003E8__locals0.vm.ctshNumRef;
					}
					if (!string.IsNullOrEmpty(_003C_003Ec__DisplayClass16_.model.ctshNumRef) && UserLogin.IsUserAccess("frmCostsheetDataEntry", "actNotDupNumRef", UserLogin.CurrentUser))
					{
						WSspCheckDuplicateCostSheetNumRef_Result wSspCheckDuplicateCostSheetNumRef_Result2 = Enumerable.FirstOrDefault<WSspCheckDuplicateCostSheetNumRef_Result>((IEnumerable<WSspCheckDuplicateCostSheetNumRef_Result>)_db.WSspCheckDuplicateCostSheetNumRef(_003C_003Ec__DisplayClass16_.model.ctshNumRef, _003C_003Ec__DisplayClass16_.model.CostSheetId));
						if (wSspCheckDuplicateCostSheetNumRef_Result2 != null)
						{
							base.ViewBag.Error = string.Format(Messages.DocNumRefIsRepeated, wSspCheckDuplicateCostSheetNumRef_Result2.ctshNumber.ToString());
							ReservedNumber.UpdateNumber(sysPartId, num);
							if (!string.IsNullOrWhiteSpace(text3))
							{
								ReservedNumber.UpdateNumber(sysPartId, 0, text3);
							}
							return View(CS_0024_003C_003E8__locals0.vm);
						}
					}
					_dbTbl.WSCostSheets.Add(_003C_003Ec__DisplayClass16_.model);
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					num = (ReservedNumber.RemoveNumber(sysPartId, num) ? 0 : num);
					if (!string.IsNullOrWhiteSpace(text3))
					{
						text3 = (ReservedNumber.RemoveNumber(sysPartId, 0, text3) ? "" : text3);
					}
					if (_003C_003Ec__DisplayClass16_.model.CostSheetId <= 0)
					{
						base.ViewBag.Error = Messages.msgErrorRunFunction;
					}
					else
					{
						foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
						{
							WSCostSheets_Lang wSCostSheets_Lang3 = new WSCostSheets_Lang();
							wSCostSheets_Lang3.LanguageID = lang.LanguageID;
							wSCostSheets_Lang3.CostSheetId = _003C_003Ec__DisplayClass16_.model.CostSheetId;
							wSCostSheets_Lang3.ctshTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
							_dbTbl.WSCostSheets_Lang.Add(wSCostSheets_Lang3);
							_dbTbl.SaveChanges();
						}
						if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.costSheetProductIds) && CS_0024_003C_003E8__locals0.vm.costSheetProductIds != ",")
						{
							_db.WSspInsertCostSheetItems(_003C_003Ec__DisplayClass16_.model.CostSheetId, _003C_003Ec__DisplayClass16_.model.ctshCmpProjectId, CS_0024_003C_003E8__locals0.vm.costSheetProductIds, userId, id, num2, dateTime2, text4, appType, CS_0024_003C_003E8__locals0.defLangID);
						}
						if (CS_0024_003C_003E8__locals0.vm.CostSheetDyFieldGroupId.HasValue)
						{
							decimal? costSheetDyFieldGroupId = CS_0024_003C_003E8__locals0.vm.CostSheetDyFieldGroupId;
							if (!((costSheetDyFieldGroupId.GetValueOrDefault() == default(decimal)) & costSheetDyFieldGroupId.HasValue))
							{
								_db.WSspInsertCostSheetDyFieldValues(_003C_003Ec__DisplayClass16_.model.CostSheetId, (int?)CS_0024_003C_003E8__locals0.vm.CostSheetDyFieldGroupId, userId, id, num2, dateTime2, text4, appType, CS_0024_003C_003E8__locals0.defLangID);
							}
						}
						_db.WSspCalculateCostSheet(_003C_003Ec__DisplayClass16_.model.CostSheetId, userId, dateTime2, text4, id, num2, appType);
						CS_0024_003C_003E8__locals0.vm.CostSheetId = _003C_003Ec__DisplayClass16_.model.CostSheetId;
						base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
					}
				}
				string firstRegInfo = "";
				string regInfo = "";
				CS_0024_003C_003E8__locals0.vm.FirstRegisterUserId = _003C_003Ec__DisplayClass16_.model.FirstRegisterUserId;
				CS_0024_003C_003E8__locals0.vm.UserId = userId;
				CS_0024_003C_003E8__locals0.vm.FirstRegisterDate = _003C_003Ec__DisplayClass16_.model.FirstRegisterDate;
				CS_0024_003C_003E8__locals0.vm.RegisterDate = dateTime2;
				CS_0024_003C_003E8__locals0.vm.FirstRegisterDatePersian = _003C_003Ec__DisplayClass16_.model.FirstRegisterDatePersian;
				CS_0024_003C_003E8__locals0.vm.RegisterDatePersian = text4;
				CS_0024_003C_003E8__locals0.vm.AppType = appType;
				SetCtshRegisterInfo(CS_0024_003C_003E8__locals0.vm, ref firstRegInfo, ref regInfo);
				CS_0024_003C_003E8__locals0.vm.FirstRegisterUser = firstRegInfo;
				CS_0024_003C_003E8__locals0.vm.EditUser = regInfo;
			}
		}
		catch (DbEntityValidationException e2)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e2);
			base.ViewBag.Error = Messages.msgErrorRunFunction;
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
			base.ViewBag.Error = Messages.msgErrorRunFunction;
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
	[DynamicAuthorize(ControllerName = "frmCostsheet", ActionName = "actctshDelete")]
	public string ActCtshDelete(int ctshId)
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
			if (!UserLogin.IsUserAccess("frmCostsheet", "actctshDelete", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			if (ctshId > 0)
			{
				try
				{
					if (Costsheet.IsFixed(ctshId))
					{
						return Messages.msgErrorCtshNotEditable;
					}
					mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteCostSheets(ctshId));
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
	[DynamicAuthorize(ControllerName = "frmCostsheet", ActionName = "actAddCostSheetToPreOrder")]
	public string AddCostSheetToPreOrder(int ctshId)
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
			if (!UserLogin.IsUserAccess("frmCostsheet", "actAddCostSheetToPreOrder", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			if (ctshId > 0)
			{
				if (true)
				{
					return "";
				}
				return Messages.msgErrorRunFunction;
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
	public JsonResult GetCurrencyUnits()
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
			List<WSspSelectCurrencyUnits_Result> list2 = Enumerable.ToList<WSspSelectCurrencyUnits_Result>((IEnumerable<WSspSelectCurrencyUnits_Result>)_db.WSspSelectCurrencyUnits(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectCurrencyUnits_Result, SelectListItem>((IEnumerable<WSspSelectCurrencyUnits_Result>)list2, (Func<WSspSelectCurrencyUnits_Result, SelectListItem>)((WSspSelectCurrencyUnits_Result item) => new SelectListItem
			{
				Text = (item.CurrencyUnit ?? ""),
				Value = item.CurrencyUnitID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.SrcCurrencyUnitList = list;
		base.ViewBag.DestCurrencyUnitList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCostSheetList(int ctshPrjId)
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
			List<WSspSelectCostSheets_Result> list2 = Enumerable.ToList<WSspSelectCostSheets_Result>((IEnumerable<WSspSelectCostSheets_Result>)_db.WSspSelectCostSheets(ctshPrjId, lCID, result));
			SelectListItem item2 = new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "",
				Selected = true
			};
			list.Add(item2);
			list.AddRange(Enumerable.Select<WSspSelectCostSheets_Result, SelectListItem>((IEnumerable<WSspSelectCostSheets_Result>)list2, (Func<WSspSelectCostSheets_Result, SelectListItem>)((WSspSelectCostSheets_Result item) => new SelectListItem
			{
				Text = (item.ctshTitle ?? ""),
				Value = item.CostSheetId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetDyFieldGroups()
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
			List<WSspSelectCostSheetDyFieldGroups_Result> list2 = Enumerable.ToList<WSspSelectCostSheetDyFieldGroups_Result>((IEnumerable<WSspSelectCostSheetDyFieldGroups_Result>)_db.WSspSelectCostSheetDyFieldGroups(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectCostSheetDyFieldGroups_Result, SelectListItem>((IEnumerable<WSspSelectCostSheetDyFieldGroups_Result>)list2, (Func<WSspSelectCostSheetDyFieldGroups_Result, SelectListItem>)((WSspSelectCostSheetDyFieldGroups_Result item) => new SelectListItem
			{
				Text = (item.ctshDyFieldGroupName ?? ""),
				Value = item.CostSheetDyFieldGroupId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.DyFieldGroupList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public long CheckDuplicateNumber(long ctshNumber, int prjId, int? currCtshId)
	{
		if (!currCtshId.HasValue)
		{
			currCtshId = 0;
		}
		try
		{
			return Enumerable.FirstOrDefault<long>(_db.Database.SqlQuery<long>($"Select * from  dbo.WSfnCheckDuplicateCostSheetNumber({ctshNumber}, {currCtshId}, {prjId})", Array.Empty<object>()));
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

	[AjaxOnly]
	public ActionResult PreOrder_Read([DataSourceRequest] DataSourceRequest request, int ctshPrjId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectPreOrderForCostSheetByPrjId_Result> list = new List<WSspSelectPreOrderForCostSheetByPrjId_Result>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (ctshPrjId > 0)
			{
				list = Enumerable.ToList<WSspSelectPreOrderForCostSheetByPrjId_Result>((IEnumerable<WSspSelectPreOrderForCostSheetByPrjId_Result>)_db.WSspSelectPreOrderForCostSheetByPrjId(ctshPrjId, UserLogin.CurrentUser.UserId, lCID, result, result2));
				foreach (WSspSelectPreOrderForCostSheetByPrjId_Result item in list)
				{
					item.pordDate = (item.pordDateTime.HasValue ? item.pordDateTime.Value.ToString("yyyy/MM/dd") : "");
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

	[DynamicAuthorize(ControllerName = "frmCostsheet", ActionName = "actTransferGroupProductToCostSheet")]
	public ActionResult TransferGroupProductToCostSheet(int ctshPrjId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		return View();
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmCostsheet", ActionName = "actTransferProductToCostSheet")]
	public string ActTransferGroupProductToCostSheet(int ctshPrjId, string ctshPrdIds, int toCtshId, string fromCtshIds = "")
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
			if (!UserLogin.IsUserAccess("frmCostsheet", "actTransferProductToCostSheet", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			if (!string.IsNullOrEmpty(ctshPrdIds) && toCtshId > 0)
			{
				if (Costsheet.IsFixed(toCtshId))
				{
					return Messages.msgErrorCtshNotEditable;
				}
				if (!string.IsNullOrEmpty(fromCtshIds))
				{
					string[] array = fromCtshIds.Split(new char[1] { ',' });
					if (array != null)
					{
						string[] array2 = array;
						foreach (string s in array2)
						{
							int result3 = 0;
							int.TryParse(s, out result3);
							if (result3 > 0 && Costsheet.IsFixed(result3))
							{
								return Messages.msgErrorCtshNotEditable;
							}
						}
					}
				}
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				int id = Financial.Get().Id;
				int userId = UserLogin.CurrentUser.UserId;
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.WSspTransferCostSheetProducts(ctshPrdIds, ctshPrjId, 0, toCtshId, userId, id, value2, value, registerDatePersian, appType, result2));
				if (mct_Result != null && mct_Result.Result > 0)
				{
					result = "";
				}
				else if (mct_Result != null && mct_Result.Result == 0)
				{
					result = Messages.msgErrorRunFunction;
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
	[DynamicAuthorize(ControllerName = "frmCostsheet", ActionName = "actGetCtshPrdWordlFile")]
	public string GetCtshPrdWordlFile_PDFEXCELWORD(int ctshPrjId)
	{
		//IL_04bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e4: Expected I4, but got Unknown
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Expected O, but got Unknown
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e8: Invalid comparison between Unknown and I4
		//IL_0848: Unknown result type (might be due to invalid IL or missing references)
		//IL_0863: Unknown result type (might be due to invalid IL or missing references)
		string result = "";
		string text = "";
		Guid.NewGuid().ToString();
		StiReport stiReport = new StiReport();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			if (!UserLogin.IsUserAccess("frmCostsheet", "actGetCtshPrdWordlFile", UserLogin.CurrentUser))
			{
				return "0|" + Messages.ErrorNotAccess;
			}
			if (ctshPrjId > 0)
			{
				string text2 = base.Server.MapPath("~/Areas/Reports/ReportDatasets/");
				string text3 = base.Server.MapPath("~/Areas/Reports/ReportFiles/");
				Parameters parameters = new Parameters();
				CRMIdeal.Classes.Helper.Reports reports = new CRMIdeal.Classes.Helper.Reports();
				parameters.SysSetting = reports.GetSysSetting();
				_ = UserLogin.CurrentUser.UserId;
				DateTime now = DateTime.Now;
				now.ToString("yyyy/MM/dd");
				DateTimeClass.DefineDayeOfWeekFaWithoutNull(now.DayOfWeek.ToString());
				byte[] coLoGo = SysSeting.Get().CoLoGo;
				if (coLoGo != null && coLoGo.Length != 0)
				{
					parameters.CoLogo = Convert.ToBase64String(coLoGo);
				}
				parameters.ReportDateTime = DateTime.Now;
				parameters.ReporterUserName = UserLogin.CurrentUser.FullName;
				List<WSspSelectCostSheetProducts_Result> list = Enumerable.ToList<WSspSelectCostSheetProducts_Result>((IEnumerable<WSspSelectCostSheetProducts_Result>)_db.WSspSelectCostSheetProducts(ctshPrjId, lCID, result2));
				if (list != null && Enumerable.Any<WSspSelectCostSheetProducts_Result>((IEnumerable<WSspSelectCostSheetProducts_Result>)list))
				{
					parameters.ListProducts = list;
					string text4 = "CostSheetProductsPrint.mrt";
					XmlSerializer val = new XmlSerializer(typeof(Parameters));
					StringWriter stringWriter = new StringWriter();
					XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
					val.Serialize(val2, (object)parameters);
					DataSet val3 = new DataSet();
					val3.ReadXmlSchema(text2 + "CostSheetProductsPrint.xsd");
					XElement val4 = XElement.Parse(stringWriter.ToString());
					val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
					stiReport.Load(text3 + text4);
					string text5 = "Integrated Security=False;Data Source={DBServer};Initial Catalog={DBName};Password={DBPass};User ID={DBUser}";
					text5 = text5.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
					text5 = text5.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
					text5 = text5.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
					text5 = text5.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
					((CollectionBase)stiReport.Dictionary.Databases).Clear();
					stiReport.Dictionary.Databases.Add(new StiSqlDatabase("CRMIdealExtra", text5));
					stiReport.Compile();
					stiReport.RegData(val3);
					stiReport.Render();
					string text6 = base.Server.MapPath(Configuration.HostTempFilesPath) + "\\Costsheets\\" + userId;
					string text7 = "CRM-Ideal-" + DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss");
					string text8 = text6 + "\\" + text7 + ".docx";
					string path = text6 + "\\" + text7 + ".xls";
					try
					{
						DirectoryInfo directoryInfo = new DirectoryInfo(text6);
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
						if (System.IO.Directory.Exists(text6))
						{
							System.IO.Directory.Delete(text6);
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
					}
					if (!System.IO.Directory.Exists(text6))
					{
						System.IO.Directory.CreateDirectory(text6);
						CRM.General.IO.Directory.SetFullControlForEveryOne(text6);
					}
					StiJpegExportSettings stiJpegExportSettings = new StiJpegExportSettings
					{
						ImageResolution = 200
					};
					int currentPage = Enumerable.Count<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
					string path2 = text6 + "\\" + text7 + ".pdf";
					string text9 = text6;
					if (!System.IO.Directory.Exists(text9))
					{
						System.IO.Directory.CreateDirectory(text9);
						CRM.General.IO.Directory.SetFullControlForEveryOne(text9);
					}
					string file = text9 + "\\CtshPrd_001.jpg";
					stiJpegExportSettings.PageRange = new StiPagesRange(currentPage);
					stiReport.ExportDocument(StiExportFormat.ImageJpeg, file, stiJpegExportSettings);
					string[] files2 = System.IO.Directory.GetFiles(text9);
					if (Enumerable.Any<string>((IEnumerable<string>)files2))
					{
						PdfDocument pdfDocument = new PdfDocument();
						for (int j = 0; j < files2.Length; j++)
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
										goto end_IL_04ba;
									case 0:
										pdfPage.Size = PageSize.A3;
										goto end_IL_04ba;
									case 1:
										pdfPage.Size = PageSize.A4;
										goto end_IL_04ba;
									case 3:
										pdfPage.Size = PageSize.A5;
										goto end_IL_04ba;
									case 4:
										pdfPage.Size = PageSize.B4;
										goto end_IL_04ba;
									case 5:
										pdfPage.Size = PageSize.B5;
										goto end_IL_04ba;
									case 2:
										break;
									}
									pdfPage.Size = PageSize.A4;
									end_IL_04ba:;
								}
								catch (Exception e2)
								{
									ErrorSignal.FromCurrentContext().Raise(e2);
									pdfPage.Size = PageSize.A4;
								}
							}
							pdfDocument.Pages.Add(pdfPage);
							XGraphics xGraphics = XGraphics.FromPdfPage(pdfDocument.Pages[j]);
							XImage xImage = XImage.FromFile(files2[j]);
							xGraphics.DrawImage(xImage, 0.0, 0.0);
							xImage.Dispose();
							xGraphics.Dispose();
						}
						pdfDocument.Save(path2);
						pdfDocument.Close();
					}
					using (DocX docX = DocX.Create(text8))
					{
						int num = 1;
						foreach (WSspSelectCostSheetProducts_Result item in list)
						{
							docX.InsertParagraph(num + ") " + item.ctshPrdName).Font("Arial").FontSize(11.0)
								.SpacingAfter(10.0)
								.Alignment = Alignment.left;
							docX.InsertParagraph("QTY: " + item.ctshPrdQuantity).Font("Arial").FontSize(11.0)
								.SpacingAfter(10.0)
								.Alignment = Alignment.left;
							num++;
						}
						docX.Save();
						docX.Dispose();
					}
					ExcelPackage excelPackage = new ExcelPackage();
					ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(Labels.CtshExcelPropertiesTitle);
					int num2 = 0;
					int num3 = 1;
					num2++;
					excelWorksheet.Cells[num3, num2].Value = Labels.Row;
					num2++;
					excelWorksheet.Cells[num3, num2].Value = Labels.MainCtshPrdListPrdName;
					num2++;
					excelWorksheet.Cells[num3, num2].Value = Labels.MainCtshPrdListQuantity;
					int num4 = 1;
					foreach (WSspSelectCostSheetProducts_Result item2 in list)
					{
						num3++;
						num2 = 0;
						num2++;
						excelWorksheet.Cells[num3, num2].Value = num4.ToString();
						num2++;
						excelWorksheet.Cells[num3, num2].Value = item2.ctshPrdName ?? "";
						num2++;
						excelWorksheet.Cells[num3, num2].Value = item2.ctshPrdQuantity.ToString();
						num4++;
					}
					using (ExcelRange excelRange = excelWorksheet.Cells[1, 1, 1, num2])
					{
						excelRange.Style.Font.Bold = true;
						excelRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
						excelRange.Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);
						excelRange.Style.Font.Color.SetColor(Color.White);
					}
					excelPackage.Workbook.Properties.Title = Labels.CtshExcelPropertiesTitle;
					excelPackage.Workbook.Properties.Company = Labels.CtshExcelPropertiesCompany;
					Stream stream = System.IO.File.Create(path);
					excelPackage.SaveAs(stream);
					stream.Close();
					string text10 = "";
					if (System.IO.File.Exists(path2))
					{
						text10 = Configuration.HostTempFilesPath + "/Costsheets/" + userId + "/" + text7 + ".pdf";
						text10 = text10.Replace("~/", "/");
						text10 = (text10.StartsWith("/") ? text10 : ("/" + text10));
					}
					string text11 = "";
					if (System.IO.File.Exists(path))
					{
						text11 = Configuration.HostTempFilesPath + "/Costsheets/" + userId + "/" + text7 + ".xls";
						text11 = text11.Replace("~/", "/");
						text11 = (text11.StartsWith("/") ? text11 : ("/" + text11));
					}
					if (System.IO.File.Exists(text8))
					{
						text = Configuration.HostTempFilesPath + "/Costsheets/" + userId + "/" + text7 + ".docx";
						text = text.Replace("~/", "/");
						text = (text.StartsWith("/") ? text : ("/" + text));
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						result = "1|" + text + "|" + text11 + "|" + text10;
					}
				}
				else
				{
					result = "0|" + Messages.ErrorNotFound;
				}
			}
			else
			{
				result = "0|" + Messages.ErrorNotFound;
			}
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
			result = "0|" + Messages.msgErrorRunFunction;
		}
		return result;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmCostsheet", ActionName = "actGetCtshPrdWordlFile")]
	public string GetCtshPrdWordlFile(int ctshPrjId)
	{
		string result = "";
		string text = "";
		Guid.NewGuid().ToString();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			if (!UserLogin.IsUserAccess("frmCostsheet", "actGetCtshPrdWordlFile", UserLogin.CurrentUser))
			{
				return "0|" + Messages.ErrorNotAccess;
			}
			if (ctshPrjId > 0)
			{
				List<WSspSelectCostSheetProducts_Result> list = Enumerable.ToList<WSspSelectCostSheetProducts_Result>((IEnumerable<WSspSelectCostSheetProducts_Result>)_db.WSspSelectCostSheetProducts(ctshPrjId, lCID, result2));
				if (list != null && Enumerable.Any<WSspSelectCostSheetProducts_Result>((IEnumerable<WSspSelectCostSheetProducts_Result>)list))
				{
					string text2 = base.Server.MapPath(Configuration.HostTempFilesPath) + "\\Costsheets\\" + userId;
					string text3 = "CRM-Ideal-" + DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss");
					string path = text2 + "\\" + text3 + ".doc";
					try
					{
						DirectoryInfo directoryInfo = new DirectoryInfo(text2);
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
						if (System.IO.Directory.Exists(text2))
						{
							System.IO.Directory.Delete(text2);
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
					}
					if (!System.IO.Directory.Exists(text2))
					{
						System.IO.Directory.CreateDirectory(text2);
						CRM.General.IO.Directory.SetFullControlForEveryOne(text2);
					}
					int num = 1;
					string text4 = "";
					foreach (WSspSelectCostSheetProducts_Result item in list)
					{
						if (!string.IsNullOrEmpty(item.ctshPrdName))
						{
							item.ctshPrdName = item.ctshPrdName.Replace("\r\n", "<br/>");
						}
						text4 = text4 + "<p>" + num + ") " + item.ctshPrdName + "<br/>QTY: " + item.ctshPrdQuantity + "<\\p>";
						num++;
					}
					string contents = new HtmlToRtf().ConvertString(text4);
					System.IO.File.WriteAllText(path, contents);
					if (System.IO.File.Exists(path))
					{
						text = Configuration.HostTempFilesPath + "/Costsheets/" + userId + "/" + text3 + ".doc";
						text = text.Replace("~/", "/");
						text = (text.StartsWith("/") ? text : ("/" + text));
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						result = "1|" + text;
					}
				}
				else
				{
					result = "0|" + Messages.ErrorNotFound;
				}
			}
			else
			{
				result = "0|" + Messages.ErrorNotFound;
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			result = "0|" + Messages.msgErrorRunFunction;
		}
		return result;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		base.Dispose(disposing);
	}
}

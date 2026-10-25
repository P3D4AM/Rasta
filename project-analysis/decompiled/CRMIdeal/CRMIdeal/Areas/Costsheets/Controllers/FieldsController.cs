using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Costsheets.Controllers;

public class FieldsController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass13_0
	{
		public int fieldId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public int id;

		public int currLangID;

		internal bool _003CInsertEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public WSCostSheetDyFieldTitleLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__3;

		public Func<Languages, bool> _003C_003E9__6;

		internal bool _003CInsertEdit_003Eb__1(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__3(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__6(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_1
	{
		public WSCostSheetDyFieldTitle model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_3
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass8_1 CS_0024_003C_003E8__locals1;

		internal bool _003CInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

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
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public int fieldId;
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[LoginAuthorize]
	public ActionResult Index(int position = 1)
	{
		string text = "";
		string text2 = "";
		switch (position)
		{
		case 1:
			text = "frmCostsheetDetails";
			text2 = "actManageDyField";
			break;
		case 2:
			text = "frmMain";
			text2 = "actctshManageDyField";
			break;
		default:
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		if (!UserLogin.IsUserAccess(text, text2, UserLogin.CurrentUser))
		{
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		GetFieldGroups();
		return View();
	}

	[AjaxOnly]
	public JsonResult GetFieldGroups()
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
		base.ViewBag.FieldGroupsList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetDyFieldType()
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
			string ctshConstantValueText = Labels.ctshConstantValueText;
			string ctshFormulaText = Labels.ctshFormulaText;
			SelectListItem item = new SelectListItem
			{
				Text = ctshConstantValueText,
				Value = "0",
				Selected = false
			};
			list.Add(item);
			item = new SelectListItem
			{
				Text = ctshFormulaText,
				Value = "1",
				Selected = false
			};
			list.Add(item);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.DyFieldTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetFields(int fieldId, int ctshDyFieldGroupId)
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
			string ctshConstantValueText = Labels.ctshConstantValueText;
			string ctshFormulaText = Labels.ctshFormulaText;
			List<WSspSelectCostSheetDyFieldTitleForFormula_Result> list2 = Enumerable.ToList<WSspSelectCostSheetDyFieldTitleForFormula_Result>((IEnumerable<WSspSelectCostSheetDyFieldTitleForFormula_Result>)_db.WSspSelectCostSheetDyFieldTitleForFormula(ctshDyFieldGroupId, fieldId, ctshConstantValueText, ctshFormulaText, lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectCostSheetDyFieldTitleForFormula_Result, SelectListItem>((IEnumerable<WSspSelectCostSheetDyFieldTitleForFormula_Result>)list2, (Func<WSspSelectCostSheetDyFieldTitleForFormula_Result, SelectListItem>)((WSspSelectCostSheetDyFieldTitleForFormula_Result item) => new SelectListItem
			{
				Text = (item.ctshDyFieldTitle ?? ""),
				Value = "[#" + item.ctshDyFieldTitleForFormula + "#]",
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.DyFieldsList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult CtshDyFields_Read([DataSourceRequest] DataSourceRequest request, int ctshDyFieldGroupId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectCostSheetDyFieldTitle_Result> list = new List<WSspSelectCostSheetDyFieldTitle_Result>();
		try
		{
			string ctshConstantValueText = Labels.ctshConstantValueText;
			string ctshFormulaText = Labels.ctshFormulaText;
			list = Enumerable.ToList<WSspSelectCostSheetDyFieldTitle_Result>((IEnumerable<WSspSelectCostSheetDyFieldTitle_Result>)_db.WSspSelectCostSheetDyFieldTitle(ctshDyFieldGroupId, ctshConstantValueText, ctshFormulaText, lCID, result));
			foreach (WSspSelectCostSheetDyFieldTitle_Result item in list)
			{
				_ = item.FirstRegisterDate;
				item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				_ = item.RegisterDate;
				item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				item.FirstRegisterUser = item.FirstRegisterUser ?? "";
				item.EditUser = item.EditUser ?? "";
				if (string.IsNullOrEmpty(item.AppType))
				{
					item.AppType = Configuration.AppType;
				}
				item.AppType = Configuration.GetAppType(item.AppType);
				item.FirstRegisterUser = item.FirstRegisterUser + " (" + item.FirstRegisterDatePersian + ")";
				string text = (string.IsNullOrEmpty(item.AppType) ? "" : (" (" + Labels.AppType + ": " + item.AppType + ") "));
				WSspSelectCostSheetDyFieldTitle_Result wSspSelectCostSheetDyFieldTitle_Result = item;
				wSspSelectCostSheetDyFieldTitle_Result.EditUser = wSspSelectCostSheetDyFieldTitle_Result.EditUser + text + "(" + item.RegisterDatePersian + ")";
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

	[DynamicAuthorize(ControllerName = "frmCostsheetDyFieldTitle", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(int ctshFieldGroupId, int id = 0)
	{
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass7_0();
		CS_0024_003C_003E8__locals0.id = id;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		DateTime now = DateTime.Now;
		int userId = UserLogin.CurrentUser.UserId;
		WSCostSheetDyFieldTitleLanguageViewModel model = new WSCostSheetDyFieldTitleLanguageViewModel();
		GetFieldGroups();
		GetDyFieldType();
		try
		{
			if (CS_0024_003C_003E8__locals0.id > 0)
			{
				if (!UserLogin.IsUserAccess("frmCostsheetDyFieldTitle", "actEdit"))
				{
					base.ViewBag.Error = Messages.NotAccessToPage;
					return null;
				}
				DbSet<WSCostSheetDyFieldTitle_Lang> wSCostSheetDyFieldTitle_Lang = _dbTbl.WSCostSheetDyFieldTitle_Lang;
				ParameterExpression val = Expression.Parameter(typeof(WSCostSheetDyFieldTitle_Lang), "m");
				List<WSCostSheetDyFieldTitle_Lang> list = Enumerable.ToList<WSCostSheetDyFieldTitle_Lang>((IEnumerable<WSCostSheetDyFieldTitle_Lang>)Queryable.Where<WSCostSheetDyFieldTitle_Lang>((IQueryable<WSCostSheetDyFieldTitle_Lang>)wSCostSheetDyFieldTitle_Lang, Expression.Lambda<Func<WSCostSheetDyFieldTitle_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass7_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				DbSet<WSCostSheetDyFieldTitle> wSCostSheetDyFieldTitle = _dbTbl.WSCostSheetDyFieldTitle;
				val = Expression.Parameter(typeof(WSCostSheetDyFieldTitle), "m");
				WSCostSheetDyFieldTitle wSCostSheetDyFieldTitle2 = Queryable.FirstOrDefault<WSCostSheetDyFieldTitle>((IQueryable<WSCostSheetDyFieldTitle>)wSCostSheetDyFieldTitle, Expression.Lambda<Func<WSCostSheetDyFieldTitle, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass7_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (wSCostSheetDyFieldTitle2 == null)
				{
					base.ViewBag.Error = Messages.ErrorNotFound;
					return null;
				}
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSCostSheetDyFieldTitle_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSCostSheetDyFieldTitle_Lang>)list, (Func<WSCostSheetDyFieldTitle_Lang, CommonMultiLanguageViewModel>)((WSCostSheetDyFieldTitle_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.ctshDyFieldTitle,
					LanguageId = item.LanguageID
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = wSCostSheetDyFieldTitle2.ctshDyFieldTitle,
					LanguageId = result
				});
				model = new WSCostSheetDyFieldTitleLanguageViewModel
				{
					CostSheetDyFieldTitleId = wSCostSheetDyFieldTitle2.CostSheetDyFieldTitleId,
					CostSheetDyFieldGroupId = wSCostSheetDyFieldTitle2.CostSheetDyFieldGroupId,
					ctshDyFieldTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					ctshDyFieldTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					ctshDyFieldType = wSCostSheetDyFieldTitle2.ctshDyFieldType,
					ctshDyFieldFormula = wSCostSheetDyFieldTitle2.ctshDyFieldFormula,
					ctshDyFieldDefaultValue = wSCostSheetDyFieldTitle2.ctshDyFieldDefaultValue,
					OrderView = wSCostSheetDyFieldTitle2.OrderView,
					FirstRegisterUserId = wSCostSheetDyFieldTitle2.FirstRegisterUserId,
					FirstRegisterDate = wSCostSheetDyFieldTitle2.FirstRegisterDate,
					FirstRegisterDatePersian = wSCostSheetDyFieldTitle2.FirstRegisterDatePersian,
					UserId = wSCostSheetDyFieldTitle2.UserId,
					RegisterDate = wSCostSheetDyFieldTitle2.RegisterDate,
					RegisterDatePersian = wSCostSheetDyFieldTitle2.RegisterDatePersian,
					FPId = wSCostSheetDyFieldTitle2.FPId,
					Month1 = wSCostSheetDyFieldTitle2.Month1,
					GUId = wSCostSheetDyFieldTitle2.GUId,
					AppType = wSCostSheetDyFieldTitle2.AppType,
					LanguageID = wSCostSheetDyFieldTitle2.LanguageID,
					ctshDyFieldTitleForFormula = wSCostSheetDyFieldTitle2.ctshDyFieldTitleForFormula,
					ctshDyFieldIsMarkup = wSCostSheetDyFieldTitle2.ctshDyFieldIsMarkup
				};
			}
			else
			{
				if (!UserLogin.IsUserAccess("frmCostsheetDyFieldTitle", "actEdit"))
				{
					base.ViewBag.Error = Messages.NotAccessToPage;
					return null;
				}
				model = new WSCostSheetDyFieldTitleLanguageViewModel
				{
					FirstRegisterUserId = userId,
					FirstRegisterDate = now,
					FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
					UserId = userId,
					RegisterDate = now,
					RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
					CostSheetDyFieldGroupId = ctshFieldGroupId
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
	[DynamicAuthorize(ControllerName = "frmCostsheetDyFieldTitleDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult InsertEdit(WSCostSheetDyFieldTitleLanguageViewModel vm)
	{
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass8_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		GetFieldGroups();
		GetDyFieldType();
		string appType = CS_0024_003C_003E8__locals0.vm.AppType;
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ctshDyFieldTitle_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.ctshDyFieldTitle_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.ctshDyFieldTitle,
			LanguageId = lCID
		});
		string text = "";
		if (CS_0024_003C_003E8__locals0.vm.ctshDyFieldTitle == null && CS_0024_003C_003E8__locals0.vm.ctshDyFieldTitle == "")
		{
			text = text + string.Format(Messages.ErrorEmpty, Labels.ctshDyFieldTitle) + "<br/>";
		}
		else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.ctshDyFieldTitle, list))
		{
			text = text + string.Format(Messages.CheckFieldInLang, Labels.ctshDyFieldTitle) + "<br>";
		}
		if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ctshDyFieldTitleForFormula))
		{
			text = text + string.Format(Messages.ErrorEmpty, Labels.ctshDyFieldTitleForFormula) + "<br/>";
		}
		else
		{
			WSspCheckDuplicateCtshDyFieldTitleForFormula_Result wSspCheckDuplicateCtshDyFieldTitleForFormula_Result = Enumerable.FirstOrDefault<WSspCheckDuplicateCtshDyFieldTitleForFormula_Result>((IEnumerable<WSspCheckDuplicateCtshDyFieldTitleForFormula_Result>)_db.WSspCheckDuplicateCtshDyFieldTitleForFormula(CS_0024_003C_003E8__locals0.vm.CostSheetDyFieldGroupId, CS_0024_003C_003E8__locals0.vm.ctshDyFieldTitleForFormula, CS_0024_003C_003E8__locals0.vm.CostSheetDyFieldTitleId, lCID, CS_0024_003C_003E8__locals0.defLangID));
			if (wSspCheckDuplicateCtshDyFieldTitleForFormula_Result != null)
			{
				text += string.Format(Messages.msgErrorDupCtshDyFieldTitleForFormula, wSspCheckDuplicateCtshDyFieldTitleForFormula_Result.ctshDyFieldTitle ?? "", wSspCheckDuplicateCtshDyFieldTitleForFormula_Result.ctshDyFieldGroupName ?? "");
			}
		}
		bool result = false;
		bool.TryParse(CS_0024_003C_003E8__locals0.vm.ctshDyFieldIsMarkup.ToString(), out result);
		if (result)
		{
			WSspSelectCostSheetDyFieldTitleByIsMarkup_Result wSspSelectCostSheetDyFieldTitleByIsMarkup_Result = Enumerable.FirstOrDefault<WSspSelectCostSheetDyFieldTitleByIsMarkup_Result>((IEnumerable<WSspSelectCostSheetDyFieldTitleByIsMarkup_Result>)_db.WSspSelectCostSheetDyFieldTitleByIsMarkup(CS_0024_003C_003E8__locals0.vm.CostSheetDyFieldGroupId, true, lCID, CS_0024_003C_003E8__locals0.defLangID));
			if (wSspSelectCostSheetDyFieldTitleByIsMarkup_Result != null && wSspSelectCostSheetDyFieldTitleByIsMarkup_Result.CostSheetDyFieldTitleId != CS_0024_003C_003E8__locals0.vm.CostSheetDyFieldTitleId)
			{
				text = text + string.Format(Messages.msgErrorDyFieldIsMarkupHasAlreadyBeen, wSspSelectCostSheetDyFieldTitleByIsMarkup_Result.ctshDyFieldTitle) + "<br/>";
			}
		}
		if (text != "")
		{
			base.ViewBag.Error = text;
			return View(CS_0024_003C_003E8__locals0.vm);
		}
		if (!base.ModelState.IsValid)
		{
			base.ViewBag.Error = Messages.msgErrorRunFunction;
		}
		else
		{
			_003C_003Ec__DisplayClass8_1 _003C_003Ec__DisplayClass8_ = new _003C_003Ec__DisplayClass8_1();
			_003C_003Ec__DisplayClass8_.model = new WSCostSheetDyFieldTitle();
			if (CS_0024_003C_003E8__locals0.vm.CostSheetDyFieldTitleId > 0)
			{
				DbSet<WSCostSheetDyFieldTitle> wSCostSheetDyFieldTitle = _dbTbl.WSCostSheetDyFieldTitle;
				ParameterExpression val = Expression.Parameter(typeof(WSCostSheetDyFieldTitle), "m");
				_003C_003Ec__DisplayClass8_.model = Queryable.FirstOrDefault<WSCostSheetDyFieldTitle>((IQueryable<WSCostSheetDyFieldTitle>)wSCostSheetDyFieldTitle, Expression.Lambda<Func<WSCostSheetDyFieldTitle, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			}
			int userId = UserLogin.CurrentUser.UserId;
			DateTime now = DateTime.Now;
			DateTime dateTime = now;
			string text2 = now.ToString("yyyyMMdd", new PersianCulture());
			short month = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType2 = Configuration.AppType;
			int id = Financial.Get().Id;
			_003C_003Ec__DisplayClass8_.model.CostSheetDyFieldGroupId = CS_0024_003C_003E8__locals0.vm.CostSheetDyFieldGroupId;
			_003C_003Ec__DisplayClass8_.model.ctshDyFieldTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
			_003C_003Ec__DisplayClass8_.model.ctshDyFieldType = CS_0024_003C_003E8__locals0.vm.ctshDyFieldType;
			_003C_003Ec__DisplayClass8_.model.ctshDyFieldFormula = CS_0024_003C_003E8__locals0.vm.ctshDyFieldFormula;
			_003C_003Ec__DisplayClass8_.model.ctshDyFieldDefaultValue = CS_0024_003C_003E8__locals0.vm.ctshDyFieldDefaultValue;
			_003C_003Ec__DisplayClass8_.model.OrderView = CS_0024_003C_003E8__locals0.vm.OrderView;
			_003C_003Ec__DisplayClass8_.model.UserId = userId;
			_003C_003Ec__DisplayClass8_.model.Month1 = month;
			_003C_003Ec__DisplayClass8_.model.RegisterDate = dateTime;
			_003C_003Ec__DisplayClass8_.model.RegisterDatePersian = text2;
			_003C_003Ec__DisplayClass8_.model.AppType = appType2;
			_003C_003Ec__DisplayClass8_.model.ctshDyFieldTitleForFormula = CS_0024_003C_003E8__locals0.vm.ctshDyFieldTitleForFormula;
			_003C_003Ec__DisplayClass8_.model.ctshDyFieldIsMarkup = CS_0024_003C_003E8__locals0.vm.ctshDyFieldIsMarkup;
			try
			{
				if (CS_0024_003C_003E8__locals0.vm.CostSheetDyFieldTitleId <= 0)
				{
					_003C_003Ec__DisplayClass8_.model.FPId = id;
					_003C_003Ec__DisplayClass8_.model.FirstRegisterUserId = userId;
					_003C_003Ec__DisplayClass8_.model.FirstRegisterDate = dateTime;
					_003C_003Ec__DisplayClass8_.model.FirstRegisterDatePersian = text2;
					_003C_003Ec__DisplayClass8_.model.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
					_003C_003Ec__DisplayClass8_.model.GUId = Guid.NewGuid();
					_dbTbl.WSCostSheetDyFieldTitle.Add(_003C_003Ec__DisplayClass8_.model);
					_dbTbl.SaveChanges();
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
					{
						WSCostSheetDyFieldTitle_Lang wSCostSheetDyFieldTitle_Lang = new WSCostSheetDyFieldTitle_Lang();
						wSCostSheetDyFieldTitle_Lang.LanguageID = lang.LanguageID;
						wSCostSheetDyFieldTitle_Lang.CostSheetDyFieldTitleId = _003C_003Ec__DisplayClass8_.model.CostSheetDyFieldTitleId;
						wSCostSheetDyFieldTitle_Lang.ctshDyFieldTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						_dbTbl.WSCostSheetDyFieldTitle_Lang.Add(wSCostSheetDyFieldTitle_Lang);
						_dbTbl.SaveChanges();
					}
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSCostSheetDyFieldTitle");
					base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
				}
				else
				{
					_dbTbl.Entry(_003C_003Ec__DisplayClass8_.model).State = EntityState.Modified;
					_dbTbl.SaveChanges();
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass8_3 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass8_3();
							CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass8_;
							CS_0024_003C_003E8__locals2.lang = enumerator.Current;
							DbSet<WSCostSheetDyFieldTitle_Lang> wSCostSheetDyFieldTitle_Lang2 = _dbTbl.WSCostSheetDyFieldTitle_Lang;
							ParameterExpression val = Expression.Parameter(typeof(WSCostSheetDyFieldTitle_Lang), "c");
							WSCostSheetDyFieldTitle_Lang wSCostSheetDyFieldTitle_Lang3 = Queryable.FirstOrDefault<WSCostSheetDyFieldTitle_Lang>((IQueryable<WSCostSheetDyFieldTitle_Lang>)wSCostSheetDyFieldTitle_Lang2, Expression.Lambda<Func<WSCostSheetDyFieldTitle_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals2, typeof(_003C_003Ec__DisplayClass8_3)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals2, typeof(_003C_003Ec__DisplayClass8_3)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (wSCostSheetDyFieldTitle_Lang3 != null)
							{
								wSCostSheetDyFieldTitle_Lang3.ctshDyFieldTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								_dbTbl.Entry(wSCostSheetDyFieldTitle_Lang3).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							wSCostSheetDyFieldTitle_Lang3 = new WSCostSheetDyFieldTitle_Lang();
							wSCostSheetDyFieldTitle_Lang3.LanguageID = CS_0024_003C_003E8__locals2.lang.LanguageID;
							wSCostSheetDyFieldTitle_Lang3.CostSheetDyFieldTitleId = CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.model.CostSheetDyFieldTitleId;
							wSCostSheetDyFieldTitle_Lang3.ctshDyFieldTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
							_dbTbl.WSCostSheetDyFieldTitle_Lang.Add(wSCostSheetDyFieldTitle_Lang3);
							_dbTbl.SaveChanges();
						}
					}
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSCostSheetDyFieldTitle");
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
				CS_0024_003C_003E8__locals0.vm.CostSheetDyFieldTitleId = _003C_003Ec__DisplayClass8_.model.CostSheetDyFieldTitleId;
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
		}
		CS_0024_003C_003E8__locals0.vm.AppType = appType;
		return View(CS_0024_003C_003E8__locals0.vm);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmCostsheetDyFieldTitle", ActionName = "actDelete")]
	public JsonResult ActDelete(int fieldId)
	{
		_003C_003Ec__DisplayClass9_0 _003C_003Ec__DisplayClass9_ = new _003C_003Ec__DisplayClass9_0();
		_003C_003Ec__DisplayClass9_.fieldId = fieldId;
		string data = "";
		try
		{
			DbSet<WSCostSheetDyFieldTitle> wSCostSheetDyFieldTitle = _dbTbl.WSCostSheetDyFieldTitle;
			ParameterExpression val = Expression.Parameter(typeof(WSCostSheetDyFieldTitle), "m");
			if (Queryable.FirstOrDefault<WSCostSheetDyFieldTitle>((IQueryable<WSCostSheetDyFieldTitle>)wSCostSheetDyFieldTitle, Expression.Lambda<Func<WSCostSheetDyFieldTitle, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass9_, typeof(_003C_003Ec__DisplayClass9_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
			{
				try
				{
					mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteCostSheetDyFieldTitle(_003C_003Ec__DisplayClass9_.fieldId));
					if (mct_Result != null && mct_Result.Result > 0)
					{
						data = "ok";
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSCostSheetDyFieldTitle");
					}
					else if (mct_Result != null && mct_Result.Result == 0)
					{
						data = "redun";
					}
				}
				catch (DbEntityValidationException e)
				{
					ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
					data = "redun";
				}
			}
		}
		catch (DbEntityValidationException e2)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e2);
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmCostsheetDyFieldTitle", ActionName = "actDeleteAll")]
	public JsonResult ActDeleteAll(int groupId)
	{
		string data = "";
		try
		{
			try
			{
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteCostSheetDyFieldTitleAll(groupId));
				if (mct_Result != null && mct_Result.Result > 0)
				{
					data = "ok";
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSCostSheetDyFieldTitle");
				}
				else if (mct_Result != null && mct_Result.Result == 0)
				{
					data = "redun";
				}
			}
			catch (DbEntityValidationException e)
			{
				ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
				data = "redun";
			}
		}
		catch (DbEntityValidationException e2)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e2);
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
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

	[DynamicAuthorize(ControllerName = "frmCostsheetDyFieldTitle", ActionName = "actMakeFormula")]
	public ActionResult CreateFormula(int fieldId, int ctshDyFieldGroupId)
	{
		GetFields(fieldId, ctshDyFieldGroupId);
		return View();
	}

	[AjaxOnly]
	public string UpdateItemFormula(int fieldId, string itemFormula)
	{
		_003C_003Ec__DisplayClass13_0 _003C_003Ec__DisplayClass13_ = new _003C_003Ec__DisplayClass13_0();
		_003C_003Ec__DisplayClass13_.fieldId = fieldId;
		string text = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmCostsheetDyFieldTitle", "actMakeFormula", currentUser))
			{
				return Messages.ErrorNotAccess;
			}
			DbSet<WSCostSheetDyFieldTitle> wSCostSheetDyFieldTitle = _dbTbl.WSCostSheetDyFieldTitle;
			ParameterExpression val = Expression.Parameter(typeof(WSCostSheetDyFieldTitle), "m");
			WSCostSheetDyFieldTitle wSCostSheetDyFieldTitle2 = Queryable.FirstOrDefault<WSCostSheetDyFieldTitle>((IQueryable<WSCostSheetDyFieldTitle>)wSCostSheetDyFieldTitle, Expression.Lambda<Func<WSCostSheetDyFieldTitle, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass13_, typeof(_003C_003Ec__DisplayClass13_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (wSCostSheetDyFieldTitle2 != null)
			{
				int userId = UserLogin.CurrentUser.UserId;
				DateTime now = DateTime.Now;
				DateTime registerDate = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short month = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				int id = Financial.Get().Id;
				wSCostSheetDyFieldTitle2.UserId = userId;
				wSCostSheetDyFieldTitle2.RegisterDate = registerDate;
				wSCostSheetDyFieldTitle2.RegisterDatePersian = registerDatePersian;
				wSCostSheetDyFieldTitle2.FPId = id;
				wSCostSheetDyFieldTitle2.Month1 = month;
				wSCostSheetDyFieldTitle2.AppType = appType;
				wSCostSheetDyFieldTitle2.ctshDyFieldFormula = itemFormula;
				_dbTbl.Entry(wSCostSheetDyFieldTitle2).State = EntityState.Modified;
				_dbTbl.SaveChanges();
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSCostSheetDyFieldTitle");
				return "";
			}
			return Messages.msgNotFound;
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			return ex.Message;
		}
	}

	[DynamicAuthorize(ControllerName = "frmCostsheetDyFieldTitle", ActionName = "actCopyDyFieldsToOtherGroup")]
	public ActionResult CopyDyFieldsToOtherGroup()
	{
		GetFieldGroups();
		return View();
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmCostsheetDyFieldTitle", ActionName = "actCopyDyFieldsToOtherGroup")]
	public string ActCopyDyFieldsToOtherGroup(int fromGroupId, int toGroupId)
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
			if (!UserLogin.IsUserAccess("frmCostsheetDyFieldTitle", "actCopyDyFieldsToOtherGroup", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			if (fromGroupId > 0 && toGroupId > 0)
			{
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				int id = Financial.Get().Id;
				int userId = UserLogin.CurrentUser.UserId;
				ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
				Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_db.WSspCopyCostSheetDyFieldTitleBetweenGroups(fromGroupId, toGroupId, userId, value, registerDatePersian, id, value2, appType, lCID, result, objectParameter));
				if (objectParameter.Value != null && !string.IsNullOrEmpty(objectParameter.Value.ToString()))
				{
					string[] array = objectParameter.Value.ToString().Split(new char[1] { '|' });
					if (array != null && Enumerable.Any<string>((IEnumerable<string>)array))
					{
						string[] array2 = array;
						foreach (string text2 in array2)
						{
							if (!string.IsNullOrEmpty(text2))
							{
								string text3 = "";
								string text4 = "";
								string text5 = "";
								string[] array3 = text2.Split(new char[1] { ',' });
								if (array3 != null && Enumerable.Any<string>((IEnumerable<string>)array3) && array3.Length == 3)
								{
									text3 = array3[0];
									text4 = array3[1];
									text5 = array3[2];
									text = text + string.Format(Messages.msgErrorCtshDyFieldTitleFormulaIsDup, text4 ?? "", text5 ?? "", text3 ?? "") + "<br>";
								}
							}
						}
					}
				}
			}
			else
			{
				text = Messages.ErrorNotFound;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text = Messages.msgErrorRunFunction + "<br>" + ex.Message;
		}
		return text;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		base.Dispose(disposing);
	}
}

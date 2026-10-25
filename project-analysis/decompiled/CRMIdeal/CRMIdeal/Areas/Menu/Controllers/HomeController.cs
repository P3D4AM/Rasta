using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
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
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Menu.Controllers;

public class HomeController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass25_0
	{
		public CRMspSelectMenuModelWithId_Result sp;
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _db_spI = new CRMSpIEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[LoginAuthorize]
	public ActionResult Index()
	{
		return RedirectToAction("HomePage", "Cartables", (object)new
		{
			area = "Cartables"
		});
	}

	[LoginAuthorize]
	public List<CRMspSelectSysMenuItems_Result> GetSysMenuItems()
	{
		List<CRMspSelectSysMenuItems_Result> result = new List<CRMspSelectSysMenuItems_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			result = Enumerable.ToList<CRMspSelectSysMenuItems_Result>((IEnumerable<CRMspSelectSysMenuItems_Result>)_db_spI.CRMspSelectSysMenuItems(lCID, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[LoginAuthorize]
	[AjaxOnly]
	public JsonResult GetSysMenuItemsJs()
	{
		return Json(GetSysMenuItems(), JsonRequestBehavior.AllowGet);
	}

	[LoginAuthorize]
	public List<CRMspSelectsysRolls_Result> GetRollsList()
	{
		List<CRMspSelectsysRolls_Result> result = new List<CRMspSelectsysRolls_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			result = Enumerable.ToList<CRMspSelectsysRolls_Result>((IEnumerable<CRMspSelectsysRolls_Result>)_db.CRMspSelectsysRolls(lCID, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[LoginAuthorize]
	public List<SelectListItem> GetRollsSelectListItem(int selectedId = 0)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		List<CRMspSelectsysRolls_Result> rollsList = GetRollsList();
		list.AddRange(Enumerable.Select<CRMspSelectsysRolls_Result, SelectListItem>((IEnumerable<CRMspSelectsysRolls_Result>)rollsList, (Func<CRMspSelectsysRolls_Result, SelectListItem>)((CRMspSelectsysRolls_Result x) => new SelectListItem
		{
			Text = x.RollName,
			Value = x.ID.ToString(),
			Selected = (x.ID == selectedId)
		})));
		return list;
	}

	[LoginAuthorize]
	public string GetRollsSelectListItemJs()
	{
		return JsonConvert.SerializeObject(GetRollsSelectListItem());
	}

	[LoginAuthorize]
	public List<CRMspSelectRollMenuModels_Result> SelectRollMenuModels()
	{
		List<CRMspSelectRollMenuModels_Result> result = new List<CRMspSelectRollMenuModels_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			result = Enumerable.ToList<CRMspSelectRollMenuModels_Result>((IEnumerable<CRMspSelectRollMenuModels_Result>)_db_spI.CRMspSelectRollMenuModels(lCID, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[LoginAuthorize]
	public ActionResult RollMenuModels_Read([DataSourceRequest] DataSourceRequest request)
	{
		JsonResult jsonResult = Json(((IEnumerable)SelectRollMenuModels()).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actAccessMenuModelToRoll")]
	public ActionResult RollMenuModels()
	{
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmAccessMenuModelToRoll", ActionName = "actInsert,actEdit")]
	public ActionResult RollMenuModelInsertEdit(int rollMenuId = 0)
	{
		CRMspSelectRollMenuModelWithId_Result cRMspSelectRollMenuModelWithId_Result = new CRMspSelectRollMenuModelWithId_Result();
		if (rollMenuId > 0)
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			cRMspSelectRollMenuModelWithId_Result = Enumerable.FirstOrDefault<CRMspSelectRollMenuModelWithId_Result>((IEnumerable<CRMspSelectRollMenuModelWithId_Result>)_db_spI.CRMspSelectRollMenuModelWithId(rollMenuId, lCID, result));
		}
		GetSysMenuType_SelectListItem(cRMspSelectRollMenuModelWithId_Result.MenuTypeId.GetValueOrDefault());
		base.ViewBag.MenuModelsList = SelectMenuModels_SelectListItem(cRMspSelectRollMenuModelWithId_Result.MenuModelID);
		base.ViewBag.RollsList = GetRollsSelectListItem(cRMspSelectRollMenuModelWithId_Result.RollId);
		return View(cRMspSelectRollMenuModelWithId_Result);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmAccessMenuModelToRoll", ActionName = "actInsert,actEdit")]
	public ActionResult RollMenuModelInsertEdit(CRMspSelectRollMenuModelWithId_Result vm)
	{
		GetSysMenuType_SelectListItem(vm.MenuTypeId.GetValueOrDefault());
		base.ViewBag.MenuModelsList = SelectMenuModels_SelectListItem(vm.MenuModelID);
		base.ViewBag.RollsList = GetRollsSelectListItem(vm.RollId);
		string text = "";
		string text2 = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string text3 = now.ToString("yyyyMMdd", new PersianCulture());
			int userId = UserLogin.CurrentUser.UserId;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			ObjectParameter objectParameter = new ObjectParameter("ResultId", 0);
			_db_spI.CRMspInsertUpdateSysRollMenu(vm.RollMenuID, vm.MenuModelID, vm.MenuTypeId, vm.RollId, value2, value3, userId, value, text3, userId, value, text3, appType, lCID, vm.OrderView, vm.MenuModelIsDefault, objectParameter);
			if (objectParameter.Value != null)
			{
				if (int.Parse(objectParameter.Value.ToString()) != 1)
				{
					text2 = ((int.Parse(objectParameter.Value.ToString()) == -1) ? Messages.msgNotCompeleteSuccessAction : ((int.Parse(objectParameter.Value.ToString()) != -5) ? Messages.msgNotCompeleteSuccessAction : Messages.frmRecordDuplicate));
				}
				else
				{
					text = Messages.msgSuccessAction;
				}
			}
			else
			{
				text2 = Messages.msgNotCompeleteSuccessAction;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text2 = ex.Message;
		}
		base.ViewBag.Successfull = text;
		base.ViewBag.Error = text2;
		return View(vm);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmAccessMenuModelToRoll", ActionName = "actDelete")]
	public string DeleteRollMenuModel(int rollMenuId = 0)
	{
		string result = "";
		if (rollMenuId > 0)
		{
			try
			{
				mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_db_spI.CRMspDeleteSysRollMenu(rollMenuId));
				if (mct_I_Result != null && mct_I_Result.Result != 1)
				{
					result = "-2";
				}
			}
			catch (Exception ex)
			{
				ErrorSignal.FromCurrentContext().Raise(ex);
				result = ex.Message;
			}
		}
		return result;
	}

	[LoginAuthorize]
	public List<CRMspSelectSysMenuType_Result> GetSysMenuType()
	{
		List<CRMspSelectSysMenuType_Result> result = new List<CRMspSelectSysMenuType_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			result = Enumerable.ToList<CRMspSelectSysMenuType_Result>((IEnumerable<CRMspSelectSysMenuType_Result>)_db_spI.CRMspSelectSysMenuType(lCID, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[LoginAuthorize]
	public List<SelectListItem> GetSysMenuType_SelectListItem(int menuTypeId = 0)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		List<CRMspSelectSysMenuType_Result> sysMenuType = GetSysMenuType();
		list.AddRange(Enumerable.Select<CRMspSelectSysMenuType_Result, SelectListItem>((IEnumerable<CRMspSelectSysMenuType_Result>)sysMenuType, (Func<CRMspSelectSysMenuType_Result, SelectListItem>)((CRMspSelectSysMenuType_Result x) => new SelectListItem
		{
			Text = x.TypeTitle,
			Value = x.MenuTypeID.ToString(),
			Selected = (x.MenuTypeID == menuTypeId)
		})));
		base.ViewBag.MenuTypesList = list;
		return list;
	}

	[LoginAuthorize]
	public List<CRMspSelectMenuModels_Result> SelectMenuModels()
	{
		List<CRMspSelectMenuModels_Result> result = new List<CRMspSelectMenuModels_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			result = Enumerable.ToList<CRMspSelectMenuModels_Result>((IEnumerable<CRMspSelectMenuModels_Result>)_db_spI.CRMspSelectMenuModels(lCID, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[LoginAuthorize]
	public List<SelectListItem> SelectMenuModels_SelectListItem(int selectedId = 0)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<CRMspSelectMenuModels_Result> list2 = SelectMenuModels();
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<CRMspSelectMenuModels_Result, SelectListItem>((IEnumerable<CRMspSelectMenuModels_Result>)list2, (Func<CRMspSelectMenuModels_Result, SelectListItem>)((CRMspSelectMenuModels_Result x) => new SelectListItem
				{
					Text = x.Title,
					Value = x.MenuModelID.ToString(),
					Selected = (x.MenuModelID == selectedId)
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[LoginAuthorize]
	public ActionResult MenuModels_Read([DataSourceRequest] DataSourceRequest request)
	{
		JsonResult jsonResult = Json(((IEnumerable)SelectMenuModels()).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[LoginAuthorize]
	public List<CRMspSelectRollMenuModelsWithRollId_Result> GetRollMenuModelsWithRollId(int rollId = 0)
	{
		List<CRMspSelectRollMenuModelsWithRollId_Result> result = new List<CRMspSelectRollMenuModelsWithRollId_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			result = Enumerable.ToList<CRMspSelectRollMenuModelsWithRollId_Result>((IEnumerable<CRMspSelectRollMenuModelsWithRollId_Result>)_db_spI.CRMspSelectRollMenuModelsWithRollId(rollId, lCID, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[LoginAuthorize]
	public string GetRollMenuModelsWithRollIdJs(int rollId = 0)
	{
		return JsonConvert.SerializeObject(GetRollMenuModelsWithRollId(rollId));
	}

	[LoginAuthorize]
	public List<SelectListItem> GetRollMenuModelsWithRollId_SelectListItem(int rollId = 0, int selectedId = 0)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		List<CRMspSelectRollMenuModelsWithRollId_Result> rollMenuModelsWithRollId = GetRollMenuModelsWithRollId(rollId);
		list.AddRange(Enumerable.Select<CRMspSelectRollMenuModelsWithRollId_Result, SelectListItem>((IEnumerable<CRMspSelectRollMenuModelsWithRollId_Result>)rollMenuModelsWithRollId, (Func<CRMspSelectRollMenuModelsWithRollId_Result, SelectListItem>)((CRMspSelectRollMenuModelsWithRollId_Result x) => new SelectListItem
		{
			Text = x.MenuModel + ((!string.IsNullOrWhiteSpace(x.MenuType)) ? (" ( " + x.MenuType + " )") : ""),
			Value = x.MenuModelID.ToString(),
			Selected = (x.MenuModelID == selectedId)
		})));
		base.ViewBag.MenuTypesList = list;
		return list;
	}

	[LoginAuthorize]
	public string GetRollMenuModelsWithRollId_SelectListItemJs(int rollId = 0, int selectedId = 0)
	{
		return JsonConvert.SerializeObject(GetRollMenuModelsWithRollId_SelectListItem(rollId, selectedId));
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actDefindMenuModels")]
	public ActionResult MenuModels()
	{
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmDefineMenuModel", ActionName = "actInsert,actEdit")]
	public ActionResult MenuModelInsertEdit(int menuModelId = 0, int rollMenuId = 0, int rollId = 0, int menuTypeId = 1)
	{
		MenuModelLanguageViewModel menuModelLanguageViewModel = new MenuModelLanguageViewModel();
		if (menuModelId > 0)
		{
			_003C_003Ec__DisplayClass25_0 _003C_003Ec__DisplayClass25_ = new _003C_003Ec__DisplayClass25_0();
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			_003C_003Ec__DisplayClass25_.sp = Enumerable.FirstOrDefault<CRMspSelectMenuModelWithId_Result>((IEnumerable<CRMspSelectMenuModelWithId_Result>)_db_spI.CRMspSelectMenuModelWithId(menuModelId, lCID, result));
			if (_003C_003Ec__DisplayClass25_.sp != null)
			{
				DbSet<CrmMenuModel_Lang> crmMenuModel_Lang = _dbTbl.CrmMenuModel_Lang;
				ParameterExpression val = Expression.Parameter(typeof(CrmMenuModel_Lang), "c");
				List<CommonMultiLanguageViewModel> list = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmMenuModel_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmMenuModel_Lang>)Enumerable.ToList<CrmMenuModel_Lang>((IEnumerable<CrmMenuModel_Lang>)Queryable.Where<CrmMenuModel_Lang>((IQueryable<CrmMenuModel_Lang>)crmMenuModel_Lang, Expression.Lambda<Func<CrmMenuModel_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass25_, typeof(_003C_003Ec__DisplayClass25_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }))), (Func<CrmMenuModel_Lang, CommonMultiLanguageViewModel>)((CrmMenuModel_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.Title,
					LanguageId = item.LanguageID
				})));
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = _003C_003Ec__DisplayClass25_.sp.Title,
					LanguageId = result
				});
				menuModelLanguageViewModel.MenuModelID = _003C_003Ec__DisplayClass25_.sp.MenuModelID;
				menuModelLanguageViewModel.MenuTypeId = _003C_003Ec__DisplayClass25_.sp.MenuTypeId;
				menuModelLanguageViewModel.Title = _003C_003Ec__DisplayClass25_.sp.Title;
				menuModelLanguageViewModel.Title_Lang = JsonConvert.SerializeObject(list);
				menuModelLanguageViewModel.IsDefault = _003C_003Ec__DisplayClass25_.sp.IsDefault;
				menuModelLanguageViewModel.Year1 = _003C_003Ec__DisplayClass25_.sp.Year1;
				menuModelLanguageViewModel.Month1 = _003C_003Ec__DisplayClass25_.sp.Month1;
				menuModelLanguageViewModel.FirstRegisterUserId = _003C_003Ec__DisplayClass25_.sp.FirstRegisterUserId;
				menuModelLanguageViewModel.FirstRegisterDate = _003C_003Ec__DisplayClass25_.sp.FirstRegisterDate;
				menuModelLanguageViewModel.FirstRegisterDatePersian = _003C_003Ec__DisplayClass25_.sp.FirstRegisterDatePersian;
				menuModelLanguageViewModel.UserId = _003C_003Ec__DisplayClass25_.sp.UserId;
				menuModelLanguageViewModel.RegisterDate = _003C_003Ec__DisplayClass25_.sp.RegisterDate;
				menuModelLanguageViewModel.RegisterDatePersian = _003C_003Ec__DisplayClass25_.sp.RegisterDatePersian;
				menuModelLanguageViewModel.AppType = _003C_003Ec__DisplayClass25_.sp.AppType;
				menuModelLanguageViewModel.LanguageID = _003C_003Ec__DisplayClass25_.sp.LanguageID;
				menuModelLanguageViewModel.OrderView = _003C_003Ec__DisplayClass25_.sp.OrderView;
				menuModelLanguageViewModel.RollMenuID = rollMenuId;
				menuModelLanguageViewModel.RollId = rollId;
			}
			GetSysMenuType_SelectListItem((menuTypeId > 0) ? menuTypeId : menuModelLanguageViewModel.MenuTypeId.GetValueOrDefault());
		}
		else
		{
			GetSysMenuType_SelectListItem((menuTypeId > 0) ? menuTypeId : menuModelLanguageViewModel.MenuTypeId.GetValueOrDefault());
		}
		return View(menuModelLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefineMenuModel", ActionName = "actInsert,actEdit")]
	public ActionResult MenuModelInsertEdit(MenuModelLanguageViewModel vm)
	{
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		string value = "";
		GetSysMenuType_SelectListItem(vm.MenuTypeId.GetValueOrDefault());
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			DateTime value2 = now;
			string text = now.ToString("yyyyMMdd", new PersianCulture());
			int userId = UserLogin.CurrentUser.UserId;
			short value3 = short.Parse(Financial.Get().Id.ToString());
			short value4 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(vm.Title_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(vm.Title_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = vm.Title,
				LanguageId = lCID
			});
			if (vm != null && vm.MenuModelID > 0)
			{
				_db_spI.CRMspUpdateMenuModel(vm.MenuModelID, vm.MenuTypeId, vm.Title, JsonConvert.SerializeObject(list), vm.IsDefault, value3, value4, userId, value2, text, result, vm.OrderView);
			}
			else
			{
				ObjectParameter objectParameter = new ObjectParameter("InsertedId", -1);
				_db_spI.CRMspInsertMenuModel(vm.MenuTypeId, vm.Title, JsonConvert.SerializeObject(list), vm.IsDefault, value3, value4, userId, value2, text, userId, value2, text, appType, result, vm.OrderView, vm.RollId, objectParameter);
				if (objectParameter != null && int.Parse(objectParameter.Value.ToString()) > 0)
				{
					vm.MenuModelID = int.Parse(objectParameter.Value.ToString());
				}
			}
		}
		catch (Exception ex)
		{
			value = ex.Message;
			base.ViewBag.Error = ex.Message;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		if (string.IsNullOrWhiteSpace(value))
		{
			base.ViewBag.Successfull = string.Format(Messages.msgSuccessfulySavedValues, Labels.MenuModel);
		}
		return View(vm);
	}

	[DynamicAuthorize(ControllerName = "frmDefineMenuModel", ActionName = "actDelete")]
	public string DeleteMenuModel(int menuModelId = 0)
	{
		string result = "";
		try
		{
			if (menuModelId > 0)
			{
				mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_db_spI.CRMspDeleteMenuModel(menuModelId));
				if (mct_I_Result != null && mct_I_Result.Result != 1)
				{
					result = "-2";
				}
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
	public string SetDefaultMenuModelForRoll(int rollMenuId = 0, bool isDefault = false)
	{
		string result = "";
		try
		{
			if (rollMenuId > 0)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
				if (result2 <= 0)
				{
					result2 = 1065;
				}
				_ = Thread.CurrentThread.CurrentCulture.LCID;
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				int userId = UserLogin.CurrentUser.UserId;
				short.Parse(Financial.Get().Id.ToString());
				short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				_db_spI.CRMspUpdateSysRollMenuIsDefault(rollMenuId, isDefault, userId, value, registerDatePersian, appType);
			}
			else
			{
				result = Messages.msgErrorNotSelectedItem;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = ex.Message;
		}
		return result;
	}

	[LoginAuthorize]
	public List<CRMspSelectMenuModelItems_Result> GetMenuModelItems(int menuModelId = 0)
	{
		List<CRMspSelectMenuModelItems_Result> result = new List<CRMspSelectMenuModelItems_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (menuModelId > 0)
			{
				result = Enumerable.ToList<CRMspSelectMenuModelItems_Result>((IEnumerable<CRMspSelectMenuModelItems_Result>)_db_spI.CRMspSelectMenuModelItems(menuModelId, lCID, result2));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[LoginAuthorize]
	public string GetMenuModelItemsJs(int menuModelId = 0)
	{
		return JsonConvert.SerializeObject(GetMenuModelItems(menuModelId));
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actManageMenuModelItemsByRoll")]
	public ActionResult MenuModelItems()
	{
		base.ViewBag.RollsSelectListItem = GetRollsSelectListItem();
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmManageMenuModelItemsByRoll", ActionName = "actEditMenuModelItem,actInsertRootMenuItem,actInsertMenuModelItem")]
	public ActionResult MenuModelItemInsertEdit(int menuModelItemId = 0, int rootMenuId = 0, int parentMenuId = 0, int menuModelId = 0, string parentMenuTitle = "")
	{
		CRMspSelectMenuModelItemWithId_Result cRMspSelectMenuModelItemWithId_Result = new CRMspSelectMenuModelItemWithId_Result();
		if (menuModelItemId > 0)
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			cRMspSelectMenuModelItemWithId_Result = Enumerable.FirstOrDefault<CRMspSelectMenuModelItemWithId_Result>((IEnumerable<CRMspSelectMenuModelItemWithId_Result>)_db_spI.CRMspSelectMenuModelItemWithId(menuModelItemId, lCID, result));
		}
		else
		{
			cRMspSelectMenuModelItemWithId_Result.MenuModelId = menuModelItemId;
			cRMspSelectMenuModelItemWithId_Result.RootMenuId = rootMenuId;
			cRMspSelectMenuModelItemWithId_Result.ParentMenuId = parentMenuId;
		}
		base.ViewBag.SysMenuItems = JsonConvert.SerializeObject(GetSysMenuItems());
		base.ViewBag.ParentMenuTitle = parentMenuTitle;
		return View(cRMspSelectMenuModelItemWithId_Result);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmManageMenuModelItemsByRoll", ActionName = "actEditMenuModelItem,actInsertRootMenuItem,actInsertMenuModelItem")]
	public ActionResult MenuModelItemInsertEdit(CRMspSelectMenuModelItemWithId_Result vm, string parentMenuTitle = "")
	{
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string text = now.ToString("yyyyMMdd", new PersianCulture());
			int userId = UserLogin.CurrentUser.UserId;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			string text2 = "";
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_db_spI.CRMspCheckDuplicateMenuModelItem(vm.MenuModelId, vm.MenuModelItemID, vm.MenuItemName));
			if (num.HasValue)
			{
				int? num2 = num;
				if (num2.HasValue && num2.GetValueOrDefault() == 1)
				{
					text2 = string.Format(Messages.msgErrorItemDuplicate, Labels.MenuModelItem);
				}
			}
			else
			{
				text2 = Messages.msgNotCompeleteSuccessAction + " [CheckDupErr]";
			}
			ObjectParameter objectParameter = new ObjectParameter("ResultId", -1);
			if (!string.IsNullOrWhiteSpace(text2))
			{
				base.ViewBag.Error = text2;
			}
			else
			{
				if (vm.MenuModelItemID > 0)
				{
					_db_spI.CRMspUpdateMenuModelItem(vm.MenuModelItemID, vm.MenuModelId, vm.MenuItemId, vm.MenuTypeId, (vm.ParentMenuId > 0) ? vm.ParentMenuId : null, (vm.RootMenuId > 0) ? vm.RootMenuId : null, vm.MenuItemName, vm.MenuItemTitle, vm.MenuItemClassName, vm.MenuItemStyleCode, vm.MenuItemSelectedStyleCode, vm.Link, vm.LinkTarget, vm.MenuIconClassName, vm.MenuIconStyleCode, vm.MenuHaveDividerInBottom, vm.InActive, vm.InVisible, vm.IsDisabled, value2, value3, userId, value, text, appType, vm.OrderView, objectParameter);
				}
				else
				{
					CRMSpIEntities db_spI = _db_spI;
					int? menuModelId = vm.MenuModelId;
					int? menuItemId = ((vm.MenuItemId > 0) ? vm.MenuItemId : null);
					int? menuTypeId = ((vm.MenuTypeId > 0) ? vm.MenuTypeId : null);
					int? parentMenuId = ((vm.ParentMenuId > 0) ? vm.ParentMenuId : null);
					int? rootMenuId = ((vm.RootMenuId > 0) ? vm.RootMenuId : null);
					int? formId = vm.FormId;
					int? formActionId = vm.FormActionId;
					string moduleNames = vm.ModuleNames;
					string menuItemName = vm.MenuItemName;
					string menuItemTitle = vm.MenuItemTitle;
					string menuItemTitle_Lang = vm.MenuItemTitle_Lang;
					string resourceName = vm.ResourceName;
					string menuItemClassName = vm.MenuItemClassName;
					string menuItemStyleCode = vm.MenuItemStyleCode;
					string menuItemSelectedStyleCode = vm.MenuItemSelectedStyleCode;
					string link = vm.Link;
					string linkTarget = vm.LinkTarget;
					string onClick = vm.OnClick;
					string menuIconClassName = vm.MenuIconClassName;
					string menuIconStyleCode = vm.MenuIconStyleCode;
					bool? menuHaveDividerInBottom = vm.MenuHaveDividerInBottom;
					bool? inActive = vm.InActive;
					bool? inVisible = vm.InVisible;
					bool? isDisabled = vm.IsDisabled;
					int? num3 = userId;
					DateTime? dateTime = value;
					string text3 = text;
					db_spI.CRMspInsertMenuModelItem(year1: value2, month1: value3, firstRegisterUserId: num3, firstRegisterDate: dateTime, firstRegisterDatePersian: text3, userId: userId, registerDate: value, registerDatePersian: text, appType: appType, orderView: vm.OrderView, menuModelId: menuModelId, menuItemId: menuItemId, menuTypeId: menuTypeId, parentMenuId: parentMenuId, rootMenuId: rootMenuId, formId: formId, formActionId: formActionId, moduleNames: moduleNames, menuItemName: menuItemName, menuItemTitle: menuItemTitle, jsMenuItemTitle_Lang: menuItemTitle_Lang, resourceName: resourceName, menuItemClassName: menuItemClassName, menuItemStyleCode: menuItemStyleCode, menuItemSelectedStyleCode: menuItemSelectedStyleCode, link: link, linkTarget: linkTarget, onClick: onClick, menuIconClassName: menuIconClassName, menuIconStyleCode: menuIconStyleCode, menuHaveDividerInBottom: menuHaveDividerInBottom, inActive: inActive, inVisible: inVisible, isDisabled: isDisabled, languageID: lCID, defaultLanguageID: result, resultId: objectParameter);
				}
				if (objectParameter == null || string.IsNullOrWhiteSpace(objectParameter.Value.ToString()))
				{
					base.ViewBag.Error = Messages.msgNotCompeleteSuccessAction;
				}
				else if (objectParameter.Value.ToString() == "0")
				{
					base.ViewBag.Error = Messages.UpdateFaild;
				}
				else if (!(objectParameter.Value.ToString() == "-2"))
				{
					base.ViewBag.Successfull = string.Format(Messages.msgSuccessfulySavedValues, Labels.MenuModelItem);
				}
				else
				{
					base.ViewBag.Error = string.Format(Messages.msgErrorItemDuplicate, Labels.MenuModelItem);
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			base.ViewBag.Error = ex.Message;
		}
		base.ViewBag.SysMenuItems = JsonConvert.SerializeObject(GetSysMenuItems());
		base.ViewBag.ParentMenuTitle = parentMenuTitle;
		return View(vm);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmManageMenuModelItemsByRoll", ActionName = "actDeleteMenuModelItem")]
	public string DeleteMenuModelItem(int menuModelItemId = 0)
	{
		string result = "";
		try
		{
			if (menuModelItemId > 0)
			{
				mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_db_spI.CRMspDeleteMenuModelItem(menuModelItemId));
				result = ((mct_I_Result == null || mct_I_Result.Result <= 0) ? "-2" : Messages.frmDeleteSuccessMessage);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[LoginAuthorize]
	public ActionResult MenuModelItemNodeInsertEdit(int menuModelItemId = 0, int rootId = 0, int parentId = 0)
	{
		CRMspSelectMenuModelItemWithId_Result model = new CRMspSelectMenuModelItemWithId_Result();
		if (menuModelItemId > 0)
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			model = Enumerable.FirstOrDefault<CRMspSelectMenuModelItemWithId_Result>((IEnumerable<CRMspSelectMenuModelItemWithId_Result>)_db_spI.CRMspSelectMenuModelItemWithId(menuModelItemId, lCID, result));
		}
		return View(model);
	}

	[HttpPost]
	[LoginAuthorize]
	public ActionResult MenuModelItemNodeInsertEdit(CRMspSelectMenuModelItemWithId_Result vm)
	{
		if (vm.MenuModelItemID > 0)
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
		}
		return View(vm);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmManageMenuModelItemsByRoll", ActionName = "actAddMenuItemFromSysMenu")]
	public string InsertMenuModelItemFromSysMenuItem(string sysMenuItemIds = "", int menuModelId = 0)
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
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int userId = UserLogin.CurrentUser.UserId;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			if (string.IsNullOrWhiteSpace(sysMenuItemIds))
			{
				text += Messages.msgErrorNotSelectedItem;
			}
			if (menuModelId <= 0)
			{
				text = text + "</br>" + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.MenuModel);
			}
			if (text == "")
			{
				List<SelectListItem> list = new List<SelectListItem>();
				list = JsonConvert.DeserializeObject<List<SelectListItem>>(sysMenuItemIds);
				if (list != null && list.Count > 0)
				{
					foreach (SelectListItem item in list)
					{
						int value4 = int.Parse(item.Value);
						_db_spI.CRMspInsertMenuModelItemFromSysMenuItem(value4, menuModelId, value2, value3, userId, value, registerDatePersian, appType);
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

	[HttpPost]
	[LoginAuthorize]
	public string InsertMenuModelItemToSelectedNode(string ids = "", int parentid = 0, int rootId = 0, int menuModelId = 0)
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
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int userId = UserLogin.CurrentUser.UserId;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			if (!string.IsNullOrWhiteSpace(ids) && menuModelId > 0)
			{
				List<SelectListItem> list = new List<SelectListItem>();
				list = JsonConvert.DeserializeObject<List<SelectListItem>>(ids);
				if (list != null && list.Count > 0)
				{
					foreach (SelectListItem item in list)
					{
						int value4 = int.Parse(item.Value);
						_db_spI.CRMspInsertMenuModelItemToSelectedNode(parentid, rootId, value4, menuModelId, value2, value3, userId, value, registerDatePersian, appType);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[LoginAuthorize]
	public ActionResult CrmIcons()
	{
		return View();
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_db_spI.Dispose();
		base.Dispose(disposing);
	}
}

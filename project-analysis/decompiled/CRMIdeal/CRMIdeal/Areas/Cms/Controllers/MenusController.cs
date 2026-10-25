using System;
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
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.UI;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Cms.Controllers;

public class MenusController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public int menuId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public int menuId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public CrmCmsMenusLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__5;

		public Func<Languages, bool> _003C_003E9__11;

		internal bool _003CInsertEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__5(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__11(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_1
	{
		public CrmCmsMenus model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass8_1 CS_0024_003C_003E8__locals1;

		internal bool _003CInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

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
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actcmsDefineMenus")]
	public ActionResult Index()
	{
		return View();
	}

	public List<TreeViewItemModel> GetMenuNodeTree(List<CRMspCmsSelectMenusTree_Result> lstMenus, int? mId)
	{
		List<TreeViewItemModel> list = new List<TreeViewItemModel>();
		try
		{
			List<CRMspCmsSelectMenusTree_Result> list2 = Enumerable.ToList<CRMspCmsSelectMenusTree_Result>(Enumerable.Where<CRMspCmsSelectMenusTree_Result>((IEnumerable<CRMspCmsSelectMenusTree_Result>)lstMenus, (Func<CRMspCmsSelectMenusTree_Result, bool>)((CRMspCmsSelectMenusTree_Result m) => m.ParentId == mId)));
			if (Enumerable.Any<CRMspCmsSelectMenusTree_Result>((IEnumerable<CRMspCmsSelectMenusTree_Result>)list2))
			{
				foreach (CRMspCmsSelectMenusTree_Result item in list2)
				{
					TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
					treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.MenuId.ToString()));
					treeViewItemModel.Id = item.MenuId.ToString();
					treeViewItemModel.Text = item.MenuTitle;
					treeViewItemModel.ImageUrl = "";
					List<TreeViewItemModel> menuNodeTree = GetMenuNodeTree(lstMenus, item.MenuId);
					treeViewItemModel.Items = new List<TreeViewItemModel>(menuNodeTree);
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

	[AjaxOnly]
	public ActionResult _PartialMenusTree()
	{
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspCmsSelectMenusTree_Result> list = Enumerable.ToList<CRMspCmsSelectMenusTree_Result>((IEnumerable<CRMspCmsSelectMenusTree_Result>)_db.CRMspCmsSelectMenusTree(lCID, result));
			List<TreeViewItemModel> list2 = new List<TreeViewItemModel>();
			if (Enumerable.Any<CRMspCmsSelectMenusTree_Result>((IEnumerable<CRMspCmsSelectMenusTree_Result>)list))
			{
				list2 = GetMenuNodeTree(list, 0);
			}
			base.ViewBag.MenusTree = list2;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView();
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actcmsDefineMenus")]
	public JsonResult GetMenu(int menuId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CurrentCmsMenuViewModel currentCmsMenuViewModel = new CurrentCmsMenuViewModel();
		try
		{
			string cmsMenuTypeLinkTxt = Labels.CmsMenuTypeLinkTxt;
			string cmsMenuTypeModuleTxt = Labels.CmsMenuTypeModuleTxt;
			string cmsMenuModuleFormTxt = Labels.CmsMenuModuleFormTxt;
			string cmsMenuModulePageTxt = Labels.CmsMenuModulePageTxt;
			string cmsMenuModuleNewsTxt = Labels.CmsMenuModuleNewsTxt;
			string cmsMenuModuleProductTxt = Labels.CmsMenuModuleProductTxt;
			string cmsMenuTargetModeSelfTxt = Labels.CmsMenuTargetModeSelfTxt;
			string cmsMenuTargetModeBlankTxt = Labels.CmsMenuTargetModeBlankTxt;
			CRMspCmsSelectMenus_Result cRMspCmsSelectMenus_Result = Enumerable.FirstOrDefault<CRMspCmsSelectMenus_Result>((IEnumerable<CRMspCmsSelectMenus_Result>)_db.CRMspCmsSelectMenus(menuId, cmsMenuTypeLinkTxt, cmsMenuTypeModuleTxt, cmsMenuModuleFormTxt, cmsMenuModulePageTxt, cmsMenuModuleNewsTxt, cmsMenuModuleProductTxt, cmsMenuTargetModeSelfTxt, cmsMenuTargetModeBlankTxt, lCID, result));
			if (cRMspCmsSelectMenus_Result != null)
			{
				currentCmsMenuViewModel.IsFind = true;
				currentCmsMenuViewModel.Message = "";
				currentCmsMenuViewModel.Menu = cRMspCmsSelectMenus_Result;
				currentCmsMenuViewModel.MenuCurrentId = cRMspCmsSelectMenus_Result.MenuId;
				_ = cRMspCmsSelectMenus_Result.FirstRegisterDate;
				cRMspCmsSelectMenus_Result.FirstRegisterDatePersian = cRMspCmsSelectMenus_Result.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				_ = cRMspCmsSelectMenus_Result.RegisterDate;
				cRMspCmsSelectMenus_Result.RegisterDatePersian = cRMspCmsSelectMenus_Result.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				if (string.IsNullOrEmpty(cRMspCmsSelectMenus_Result.AppType))
				{
					cRMspCmsSelectMenus_Result.AppType = Configuration.AppType;
				}
				cRMspCmsSelectMenus_Result.AppType = Configuration.GetAppType(cRMspCmsSelectMenus_Result.AppType);
			}
			else
			{
				currentCmsMenuViewModel.IsFind = false;
				currentCmsMenuViewModel.Message = Messages.ErrorNotFound;
				currentCmsMenuViewModel.Menu = null;
				currentCmsMenuViewModel.MenuCurrentId = -1;
			}
		}
		catch (DbEntityValidationException ex)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
			currentCmsMenuViewModel.Message = Messages.frmErrorMessage + "<br />" + ((Exception)(object)ex).Message;
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			currentCmsMenuViewModel.Message = Messages.frmErrorMessage + "<br />" + ex2.Message;
		}
		JsonResult jsonResult = Json(currentCmsMenuViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmCmsDefineMenu", ActionName = "actDelete")]
	public string DeleteMenu(int menuId)
	{
		_003C_003Ec__DisplayClass6_0 _003C_003Ec__DisplayClass6_ = new _003C_003Ec__DisplayClass6_0();
		_003C_003Ec__DisplayClass6_.menuId = menuId;
		string result = "";
		try
		{
			DbSet<CrmCmsMenus> crmCmsMenus = _dbTbl.CrmCmsMenus;
			ParameterExpression val = Expression.Parameter(typeof(CrmCmsMenus), "c");
			if (Queryable.FirstOrDefault<CrmCmsMenus>((IQueryable<CrmCmsMenus>)crmCmsMenus, Expression.Lambda<Func<CrmCmsMenus, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass6_, typeof(_003C_003Ec__DisplayClass6_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
			{
				try
				{
					int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
					if (result2 <= 0)
					{
						result2 = 1065;
					}
					_ = Thread.CurrentThread.CurrentCulture.LCID;
					mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspCmsDeleteMenu(_003C_003Ec__DisplayClass6_.menuId));
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

	[DynamicAuthorize(ControllerName = "frmCmsDefineMenu", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(int menuId = 0, int parentId = 0)
	{
		_003C_003Ec__DisplayClass7_0 _003C_003Ec__DisplayClass7_ = new _003C_003Ec__DisplayClass7_0();
		_003C_003Ec__DisplayClass7_.menuId = menuId;
		CrmCmsMenusLanguageViewModel crmCmsMenusLanguageViewModel = new CrmCmsMenusLanguageViewModel();
		try
		{
			CrmCmsMenus crmCmsMenus = new CrmCmsMenus();
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
			if (_003C_003Ec__DisplayClass7_.menuId > 0)
			{
				if (!UserLogin.IsUserAccess("frmCmsDefineMenu", "actEdit"))
				{
					base.ViewBag.Error = Messages.NotAccessToPage;
					return null;
				}
				DbSet<CrmCmsMenus_Lang> crmCmsMenus_Lang = _dbTbl.CrmCmsMenus_Lang;
				ParameterExpression val = Expression.Parameter(typeof(CrmCmsMenus_Lang), "c");
				List<CrmCmsMenus_Lang> list = Enumerable.ToList<CrmCmsMenus_Lang>((IEnumerable<CrmCmsMenus_Lang>)Queryable.Where<CrmCmsMenus_Lang>((IQueryable<CrmCmsMenus_Lang>)crmCmsMenus_Lang, Expression.Lambda<Func<CrmCmsMenus_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass7_, typeof(_003C_003Ec__DisplayClass7_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				DbSet<CrmCmsMenus> crmCmsMenus2 = _dbTbl.CrmCmsMenus;
				val = Expression.Parameter(typeof(CrmCmsMenus), "c");
				crmCmsMenus = Queryable.FirstOrDefault<CrmCmsMenus>((IQueryable<CrmCmsMenus>)crmCmsMenus2, Expression.Lambda<Func<CrmCmsMenus, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass7_, typeof(_003C_003Ec__DisplayClass7_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (crmCmsMenus == null)
				{
					base.ViewBag.Error = Messages.ErrorNotFound;
					return null;
				}
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsMenus_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsMenus_Lang>)list, (Func<CrmCmsMenus_Lang, CommonMultiLanguageViewModel>)((CrmCmsMenus_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.MenuTitle,
					LanguageId = item.LanguageID
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCmsMenus.MenuTitle,
					LanguageId = result
				});
				crmCmsMenusLanguageViewModel = new CrmCmsMenusLanguageViewModel
				{
					MenuId = crmCmsMenus.MenuId,
					MenuTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
					MenuTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
					Type = crmCmsMenus.Type,
					ModuleName = crmCmsMenus.ModuleName,
					ParentId = crmCmsMenus.ParentId,
					DyFormId = crmCmsMenus.DyFormId,
					PageId = crmCmsMenus.PageId,
					NewsId = crmCmsMenus.NewsId,
					PrdFirstGroupId = crmCmsMenus.PrdFirstGroupId,
					PrdSecondGroupId = crmCmsMenus.PrdSecondGroupId,
					Link = crmCmsMenus.Link,
					TargetMode = crmCmsMenus.TargetMode,
					OnlyForLoginUser = crmCmsMenus.OnlyForLoginUser,
					IsActive = crmCmsMenus.IsActive,
					OrderView = crmCmsMenus.OrderView,
					FirstRegisterUserId = crmCmsMenus.FirstRegisterUserId,
					FirstRegisterDate = crmCmsMenus.FirstRegisterDate,
					FirstRegisterDatePersian = crmCmsMenus.FirstRegisterDatePersian,
					UserId = crmCmsMenus.UserId,
					Year1 = crmCmsMenus.Year1,
					Month1 = crmCmsMenus.Month1,
					RegisterDate = crmCmsMenus.RegisterDate,
					RegisterDatePersian = crmCmsMenus.RegisterDatePersian,
					GUId = crmCmsMenus.GUId,
					AppType = crmCmsMenus.AppType,
					LanguageID = crmCmsMenus.LanguageID
				};
				string cmsMenuTypeLinkTxt = Labels.CmsMenuTypeLinkTxt;
				string cmsMenuTypeModuleTxt = Labels.CmsMenuTypeModuleTxt;
				string cmsMenuModuleFormTxt = Labels.CmsMenuModuleFormTxt;
				string cmsMenuModulePageTxt = Labels.CmsMenuModulePageTxt;
				string cmsMenuModuleNewsTxt = Labels.CmsMenuModuleNewsTxt;
				string cmsMenuModuleProductTxt = Labels.CmsMenuModuleProductTxt;
				string cmsMenuTargetModeSelfTxt = Labels.CmsMenuTargetModeSelfTxt;
				string cmsMenuTargetModeBlankTxt = Labels.CmsMenuTargetModeBlankTxt;
				CRMspCmsSelectMenus_Result cRMspCmsSelectMenus_Result = Enumerable.FirstOrDefault<CRMspCmsSelectMenus_Result>((IEnumerable<CRMspCmsSelectMenus_Result>)_db.CRMspCmsSelectMenus(_003C_003Ec__DisplayClass7_.menuId, cmsMenuTypeLinkTxt, cmsMenuTypeModuleTxt, cmsMenuModuleFormTxt, cmsMenuModulePageTxt, cmsMenuModuleNewsTxt, cmsMenuModuleProductTxt, cmsMenuTargetModeSelfTxt, cmsMenuTargetModeBlankTxt, currLangID, result));
				if (cRMspCmsSelectMenus_Result != null)
				{
					CrmCmsMenusLanguageViewModel crmCmsMenusLanguageViewModel2 = crmCmsMenusLanguageViewModel;
					_ = cRMspCmsSelectMenus_Result.FirstRegisterDate;
					crmCmsMenusLanguageViewModel2.FirstRegisterDatePersian = cRMspCmsSelectMenus_Result.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
					CrmCmsMenusLanguageViewModel crmCmsMenusLanguageViewModel3 = crmCmsMenusLanguageViewModel;
					_ = cRMspCmsSelectMenus_Result.RegisterDate;
					crmCmsMenusLanguageViewModel3.RegisterDatePersian = cRMspCmsSelectMenus_Result.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
					if (string.IsNullOrEmpty(cRMspCmsSelectMenus_Result.AppType))
					{
						cRMspCmsSelectMenus_Result.AppType = Configuration.AppType;
					}
					crmCmsMenusLanguageViewModel.AppType = Configuration.GetAppType(cRMspCmsSelectMenus_Result.AppType);
					crmCmsMenusLanguageViewModel.FirstRegisterUser = cRMspCmsSelectMenus_Result.FirstRegisterUser ?? "";
					crmCmsMenusLanguageViewModel.EditUser = cRMspCmsSelectMenus_Result.EditUser + "(" + Labels.AppType + ":" + crmCmsMenusLanguageViewModel.AppType + ")";
				}
			}
			else
			{
				if (!UserLogin.IsUserAccess("frmCmsDefineMenu", "actInsert"))
				{
					base.ViewBag.Error = Messages.NotAccessToPage;
					return null;
				}
				DateTime now = DateTime.Now;
				crmCmsMenusLanguageViewModel = new CrmCmsMenusLanguageViewModel
				{
					ParentId = parentId,
					FirstRegisterUserId = UserLogin.CurrentUser.UserId,
					FirstRegisterDate = now,
					UserId = UserLogin.CurrentUser.UserId,
					RegisterDate = now,
					Year1 = short.Parse(Financial.Get().Id.ToString()),
					Month1 = short.Parse(now.ToString("MM", new PersianCulture())),
					AppType = Configuration.AppType,
					LanguageID = result,
					IsActive = true
				};
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		GetDyForms();
		GetTargetMode();
		GetCmsPages();
		GetCmsNews();
		GetMenuType();
		GetModuleName();
		GetPrdFGroup();
		GetPrdSGroup(crmCmsMenusLanguageViewModel.PrdFirstGroupId.GetValueOrDefault());
		GetParent();
		return View(crmCmsMenusLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmCmsDefineMenuDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult InsertEdit(CrmCmsMenusLanguageViewModel vm)
	{
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass8_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			_003C_003Ec__DisplayClass8_1 _003C_003Ec__DisplayClass8_ = new _003C_003Ec__DisplayClass8_1();
			_003C_003Ec__DisplayClass8_.model = new CrmCmsMenus();
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.MenuTitle_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.MenuTitle_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.MenuTitle,
				LanguageId = lCID
			});
			GetDyForms();
			GetTargetMode();
			GetCmsPages();
			GetCmsNews();
			GetMenuType();
			GetModuleName();
			GetPrdFGroup();
			GetPrdSGroup(CS_0024_003C_003E8__locals0.vm.PrdFirstGroupId.GetValueOrDefault());
			GetParent();
			_ = CRMIdeal.Cache.Setting.Language.Get().Count;
			string text = "";
			int num = 0;
			if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.MenuTitle))
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.CmsMenuTitle) + "<br/>";
				num++;
			}
			else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.MenuTitle, list))
			{
				text = text + string.Format(Messages.CheckFieldInLang, Labels.CmsMenuTitle) + "<br>";
				num++;
			}
			if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.Type))
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.CmsMenuType) + "<br/>";
				num++;
			}
			if (num > 0)
			{
				base.ViewBag.Error = text;
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			if (base.ModelState.IsValid)
			{
				_003C_003Ec__DisplayClass8_.model = new CrmCmsMenus();
				if (CS_0024_003C_003E8__locals0.vm.MenuId > 0)
				{
					DbSet<CrmCmsMenus> crmCmsMenus = _dbTbl.CrmCmsMenus;
					ParameterExpression val = Expression.Parameter(typeof(CrmCmsMenus), "c");
					_003C_003Ec__DisplayClass8_.model = Queryable.FirstOrDefault<CrmCmsMenus>((IQueryable<CrmCmsMenus>)crmCmsMenus, Expression.Lambda<Func<CrmCmsMenus, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				_003C_003Ec__DisplayClass8_.model.UserId = UserLogin.CurrentUser.UserId;
				DateTime now = DateTime.Now;
				_003C_003Ec__DisplayClass8_.model.RegisterDate = now;
				_003C_003Ec__DisplayClass8_.model.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				_003C_003Ec__DisplayClass8_.model.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
				_003C_003Ec__DisplayClass8_.model.AppType = Configuration.AppType;
				_003C_003Ec__DisplayClass8_.model.Year1 = short.Parse(Financial.Get().Id.ToString());
				_003C_003Ec__DisplayClass8_.model.MenuTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass8_.model.Type = CS_0024_003C_003E8__locals0.vm.Type;
				_003C_003Ec__DisplayClass8_.model.ModuleName = CS_0024_003C_003E8__locals0.vm.ModuleName;
				_003C_003Ec__DisplayClass8_.model.ParentId = CS_0024_003C_003E8__locals0.vm.ParentId;
				_003C_003Ec__DisplayClass8_.model.DyFormId = CS_0024_003C_003E8__locals0.vm.DyFormId;
				_003C_003Ec__DisplayClass8_.model.PageId = CS_0024_003C_003E8__locals0.vm.PageId;
				_003C_003Ec__DisplayClass8_.model.NewsId = CS_0024_003C_003E8__locals0.vm.NewsId;
				_003C_003Ec__DisplayClass8_.model.PrdFirstGroupId = CS_0024_003C_003E8__locals0.vm.PrdFirstGroupId;
				_003C_003Ec__DisplayClass8_.model.PrdSecondGroupId = CS_0024_003C_003E8__locals0.vm.PrdSecondGroupId;
				_003C_003Ec__DisplayClass8_.model.Link = CS_0024_003C_003E8__locals0.vm.Link;
				_003C_003Ec__DisplayClass8_.model.TargetMode = CS_0024_003C_003E8__locals0.vm.TargetMode;
				_003C_003Ec__DisplayClass8_.model.OnlyForLoginUser = CS_0024_003C_003E8__locals0.vm.OnlyForLoginUser;
				_003C_003Ec__DisplayClass8_.model.IsActive = CS_0024_003C_003E8__locals0.vm.IsActive;
				_003C_003Ec__DisplayClass8_.model.OrderView = CS_0024_003C_003E8__locals0.vm.OrderView;
				if (_003C_003Ec__DisplayClass8_.model.MenuId > 0)
				{
					_dbTbl.Entry(_003C_003Ec__DisplayClass8_.model).State = EntityState.Modified;
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass8_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass8_2();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass8_;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							DbSet<CrmCmsMenus_Lang> crmCmsMenus_Lang = _dbTbl.CrmCmsMenus_Lang;
							ParameterExpression val = Expression.Parameter(typeof(CrmCmsMenus_Lang), "c");
							CrmCmsMenus_Lang crmCmsMenus_Lang2 = Queryable.FirstOrDefault<CrmCmsMenus_Lang>((IQueryable<CrmCmsMenus_Lang>)crmCmsMenus_Lang, Expression.Lambda<Func<CrmCmsMenus_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass8_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass8_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (crmCmsMenus_Lang2 != null)
							{
								crmCmsMenus_Lang2.MenuTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(crmCmsMenus_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							crmCmsMenus_Lang2 = new CrmCmsMenus_Lang();
							crmCmsMenus_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
							crmCmsMenus_Lang2.MenuId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.MenuId;
							crmCmsMenus_Lang2.MenuTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							_dbTbl.CrmCmsMenus_Lang.Add(crmCmsMenus_Lang2);
							_dbTbl.SaveChanges();
						}
					}
					text = Messages.frmFormBaseEditSuccessFulMessage;
				}
				else
				{
					_003C_003Ec__DisplayClass8_.model.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
					_003C_003Ec__DisplayClass8_.model.FirstRegisterDate = now;
					_003C_003Ec__DisplayClass8_.model.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					_003C_003Ec__DisplayClass8_.model.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
					_003C_003Ec__DisplayClass8_.model.GUId = Guid.NewGuid();
					_dbTbl.CrmCmsMenus.Add(_003C_003Ec__DisplayClass8_.model);
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
					{
						CrmCmsMenus_Lang crmCmsMenus_Lang3 = new CrmCmsMenus_Lang();
						crmCmsMenus_Lang3.LanguageID = lang.LanguageID;
						crmCmsMenus_Lang3.MenuId = _003C_003Ec__DisplayClass8_.model.MenuId;
						crmCmsMenus_Lang3.MenuTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						_dbTbl.CrmCmsMenus_Lang.Add(crmCmsMenus_Lang3);
						_dbTbl.SaveChanges();
					}
					text = Messages.frmFormBaseInsertSuccessFulMessage;
				}
				CS_0024_003C_003E8__locals0.vm.MenuId = _003C_003Ec__DisplayClass8_.model.MenuId;
				CS_0024_003C_003E8__locals0.vm.RegisterDate = _003C_003Ec__DisplayClass8_.model.RegisterDate;
				CS_0024_003C_003E8__locals0.vm.UserId = _003C_003Ec__DisplayClass8_.model.UserId;
				CS_0024_003C_003E8__locals0.vm.FirstRegisterDate = _003C_003Ec__DisplayClass8_.model.FirstRegisterDate;
				CS_0024_003C_003E8__locals0.vm.FirstRegisterUserId = _003C_003Ec__DisplayClass8_.model.FirstRegisterUserId;
				string cmsMenuTypeLinkTxt = Labels.CmsMenuTypeLinkTxt;
				string cmsMenuTypeModuleTxt = Labels.CmsMenuTypeModuleTxt;
				string cmsMenuModuleFormTxt = Labels.CmsMenuModuleFormTxt;
				string cmsMenuModulePageTxt = Labels.CmsMenuModulePageTxt;
				string cmsMenuModuleNewsTxt = Labels.CmsMenuModuleNewsTxt;
				string cmsMenuModuleProductTxt = Labels.CmsMenuModuleProductTxt;
				string cmsMenuTargetModeSelfTxt = Labels.CmsMenuTargetModeSelfTxt;
				string cmsMenuTargetModeBlankTxt = Labels.CmsMenuTargetModeBlankTxt;
				CRMspCmsSelectMenus_Result cRMspCmsSelectMenus_Result = Enumerable.FirstOrDefault<CRMspCmsSelectMenus_Result>((IEnumerable<CRMspCmsSelectMenus_Result>)_db.CRMspCmsSelectMenus(CS_0024_003C_003E8__locals0.vm.MenuId, cmsMenuTypeLinkTxt, cmsMenuTypeModuleTxt, cmsMenuModuleFormTxt, cmsMenuModulePageTxt, cmsMenuModuleNewsTxt, cmsMenuModuleProductTxt, cmsMenuTargetModeSelfTxt, cmsMenuTargetModeBlankTxt, lCID, CS_0024_003C_003E8__locals0.defLangID));
				if (cRMspCmsSelectMenus_Result != null)
				{
					CrmCmsMenusLanguageViewModel vm2 = CS_0024_003C_003E8__locals0.vm;
					_ = cRMspCmsSelectMenus_Result.FirstRegisterDate;
					vm2.FirstRegisterDatePersian = cRMspCmsSelectMenus_Result.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
					CrmCmsMenusLanguageViewModel vm3 = CS_0024_003C_003E8__locals0.vm;
					_ = cRMspCmsSelectMenus_Result.RegisterDate;
					vm3.RegisterDatePersian = cRMspCmsSelectMenus_Result.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
					if (string.IsNullOrEmpty(cRMspCmsSelectMenus_Result.AppType))
					{
						cRMspCmsSelectMenus_Result.AppType = Configuration.AppType;
					}
					CS_0024_003C_003E8__locals0.vm.AppType = Configuration.GetAppType(cRMspCmsSelectMenus_Result.AppType);
					CS_0024_003C_003E8__locals0.vm.FirstRegisterUser = cRMspCmsSelectMenus_Result.FirstRegisterUser ?? "";
					CS_0024_003C_003E8__locals0.vm.EditUser = cRMspCmsSelectMenus_Result.EditUser + "(" + Labels.AppType + ":" + CS_0024_003C_003E8__locals0.vm.AppType + ")";
				}
				if (cRMspCmsSelectMenus_Result != null)
				{
					CrmCmsMenusLanguageViewModel vm4 = CS_0024_003C_003E8__locals0.vm;
					_ = cRMspCmsSelectMenus_Result.FirstRegisterDate;
					vm4.FirstRegisterDatePersian = cRMspCmsSelectMenus_Result.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
					CrmCmsMenusLanguageViewModel vm5 = CS_0024_003C_003E8__locals0.vm;
					_ = cRMspCmsSelectMenus_Result.RegisterDate;
					vm5.RegisterDatePersian = cRMspCmsSelectMenus_Result.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
					if (string.IsNullOrEmpty(cRMspCmsSelectMenus_Result.AppType))
					{
						cRMspCmsSelectMenus_Result.AppType = Configuration.AppType;
					}
					CS_0024_003C_003E8__locals0.vm.AppType = Configuration.GetAppType(cRMspCmsSelectMenus_Result.AppType);
					CS_0024_003C_003E8__locals0.vm.FirstRegisterUser = cRMspCmsSelectMenus_Result.FirstRegisterUser ?? "";
					CS_0024_003C_003E8__locals0.vm.EditUser = cRMspCmsSelectMenus_Result.EditUser + "(" + Labels.AppType + ":" + CS_0024_003C_003E8__locals0.vm.AppType + ")";
					cRMspCmsSelectMenus_Result.FirstRegisterDatePersian = CS_0024_003C_003E8__locals0.vm.FirstRegisterDatePersian;
					cRMspCmsSelectMenus_Result.RegisterDatePersian = CS_0024_003C_003E8__locals0.vm.RegisterDatePersian;
					cRMspCmsSelectMenus_Result.FirstRegisterUser = CS_0024_003C_003E8__locals0.vm.FirstRegisterUser;
					cRMspCmsSelectMenus_Result.EditUser = CS_0024_003C_003E8__locals0.vm.EditUser;
				}
				base.ViewBag.Successfull = text;
			}
			else
			{
				text = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
				base.ViewBag.Error = text;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			base.ViewBag.Error = ex.Message;
		}
		return View(CS_0024_003C_003E8__locals0.vm);
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
	public JsonResult GetParent()
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
			string cmsMenuIndependent = Labels.CmsMenuIndependent;
			string cmsMenuTypeLinkTxt = Labels.CmsMenuTypeLinkTxt;
			string cmsMenuTypeModuleTxt = Labels.CmsMenuTypeModuleTxt;
			string cmsMenuModuleFormTxt = Labels.CmsMenuModuleFormTxt;
			string cmsMenuModulePageTxt = Labels.CmsMenuModulePageTxt;
			string cmsMenuModuleNewsTxt = Labels.CmsMenuModuleNewsTxt;
			string cmsMenuModuleProductTxt = Labels.CmsMenuModuleProductTxt;
			string cmsMenuTargetModeSelfTxt = Labels.CmsMenuTargetModeSelfTxt;
			string cmsMenuTargetModeBlankTxt = Labels.CmsMenuTargetModeBlankTxt;
			List<CRMspCmsSelectMenusParent_Result> list2 = Enumerable.ToList<CRMspCmsSelectMenusParent_Result>(Enumerable.Where<CRMspCmsSelectMenusParent_Result>((IEnumerable<CRMspCmsSelectMenusParent_Result>)_db.CRMspCmsSelectMenusParent(cmsMenuIndependent, cmsMenuTypeLinkTxt, cmsMenuTypeModuleTxt, cmsMenuModuleFormTxt, cmsMenuModulePageTxt, cmsMenuModuleNewsTxt, cmsMenuModuleProductTxt, cmsMenuTargetModeSelfTxt, cmsMenuTargetModeBlankTxt, lCID, result), (Func<CRMspCmsSelectMenusParent_Result, bool>)((CRMspCmsSelectMenusParent_Result m) => m.ParentId == 0)));
			list.AddRange(Enumerable.Select<CRMspCmsSelectMenusParent_Result, SelectListItem>((IEnumerable<CRMspCmsSelectMenusParent_Result>)Enumerable.ToList<CRMspCmsSelectMenusParent_Result>((IEnumerable<CRMspCmsSelectMenusParent_Result>)list2), (Func<CRMspCmsSelectMenusParent_Result, SelectListItem>)((CRMspCmsSelectMenusParent_Result i) => new SelectListItem
			{
				Text = i.MenuTitle,
				Value = i.MenuId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ParentList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetDyForms()
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
			List<CRMspCmsSelectDyFormsForMenus_Result> list2 = Enumerable.ToList<CRMspCmsSelectDyFormsForMenus_Result>((IEnumerable<CRMspCmsSelectDyFormsForMenus_Result>)_db.CRMspCmsSelectDyFormsForMenus(UserLogin.CurrentUser.UserId, 100, lCID, result));
			list.AddRange(Enumerable.Select<CRMspCmsSelectDyFormsForMenus_Result, SelectListItem>((IEnumerable<CRMspCmsSelectDyFormsForMenus_Result>)Enumerable.ToList<CRMspCmsSelectDyFormsForMenus_Result>((IEnumerable<CRMspCmsSelectDyFormsForMenus_Result>)list2), (Func<CRMspCmsSelectDyFormsForMenus_Result, SelectListItem>)((CRMspCmsSelectDyFormsForMenus_Result i) => new SelectListItem
			{
				Text = i.FormName,
				Value = i.FormId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.DyFormList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetTargetMode()
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
			SelectListItem item = new SelectListItem
			{
				Text = Labels.CmsTargetSelfMode,
				Value = "1",
				Selected = false
			};
			list.Add(item);
			item = new SelectListItem
			{
				Text = Labels.CmsTargetBlankMode,
				Value = "2",
				Selected = false
			};
			list.Add(item);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.TargetModeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCmsPages()
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
			List<CRMspCmsSelectActivePages_Result> list2 = Enumerable.ToList<CRMspCmsSelectActivePages_Result>((IEnumerable<CRMspCmsSelectActivePages_Result>)_db.CRMspCmsSelectActivePages(2, lCID, result));
			list.AddRange(Enumerable.Select<CRMspCmsSelectActivePages_Result, SelectListItem>((IEnumerable<CRMspCmsSelectActivePages_Result>)Enumerable.ToList<CRMspCmsSelectActivePages_Result>((IEnumerable<CRMspCmsSelectActivePages_Result>)list2), (Func<CRMspCmsSelectActivePages_Result, SelectListItem>)((CRMspCmsSelectActivePages_Result i) => new SelectListItem
			{
				Text = i.PageName,
				Value = i.PageId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CmsPageList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCmsNews()
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
			List<CRMspCmsSelectNewsVerified_Result> list2 = Enumerable.ToList<CRMspCmsSelectNewsVerified_Result>((IEnumerable<CRMspCmsSelectNewsVerified_Result>)_db.CRMspCmsSelectNewsVerified(lCID, result));
			list.AddRange(Enumerable.Select<CRMspCmsSelectNewsVerified_Result, SelectListItem>((IEnumerable<CRMspCmsSelectNewsVerified_Result>)Enumerable.ToList<CRMspCmsSelectNewsVerified_Result>((IEnumerable<CRMspCmsSelectNewsVerified_Result>)list2), (Func<CRMspCmsSelectNewsVerified_Result, SelectListItem>)((CRMspCmsSelectNewsVerified_Result i) => new SelectListItem
			{
				Text = i.Title,
				Value = i.NewsId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CmsNewsList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetMenuType()
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
			SelectListItem item = new SelectListItem
			{
				Text = Labels.CmsMenuTypeLinkTxt,
				Value = "Link",
				Selected = false
			};
			list.Add(item);
			item = new SelectListItem
			{
				Text = Labels.CmsMenuTypeModuleTxt,
				Value = "Module",
				Selected = false
			};
			list.Add(item);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.TypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetModuleName()
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
			SelectListItem item = new SelectListItem
			{
				Text = Labels.CmsMenuModuleFormTxt,
				Value = "Form",
				Selected = false
			};
			list.Add(item);
			item = new SelectListItem
			{
				Text = Labels.CmsMenuModulePageTxt,
				Value = "Page",
				Selected = false
			};
			list.Add(item);
			item = new SelectListItem
			{
				Text = Labels.CmsMenuModuleNewsTxt,
				Value = "News",
				Selected = false
			};
			list.Add(item);
			item = new SelectListItem
			{
				Text = Labels.CmsMenuModuleProductTxt,
				Value = "Product",
				Selected = false
			};
			list.Add(item);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ModuleNameList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPrdFGroup()
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
			List<WSspSelectProductFirstGroupActiveInSale_Result> list2 = Enumerable.ToList<WSspSelectProductFirstGroupActiveInSale_Result>((IEnumerable<WSspSelectProductFirstGroupActiveInSale_Result>)_db.WSspSelectProductFirstGroupActiveInSale(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectProductFirstGroupActiveInSale_Result, SelectListItem>((IEnumerable<WSspSelectProductFirstGroupActiveInSale_Result>)Enumerable.ToList<WSspSelectProductFirstGroupActiveInSale_Result>((IEnumerable<WSspSelectProductFirstGroupActiveInSale_Result>)list2), (Func<WSspSelectProductFirstGroupActiveInSale_Result, SelectListItem>)((WSspSelectProductFirstGroupActiveInSale_Result i) => new SelectListItem
			{
				Text = i.FGName,
				Value = i.PrdFirstGroupID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PrdFGroupList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPrdSGroup(int fgId = 0)
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
			if (fgId > 0)
			{
				List<WSspSelectProductSecondGroupActiveInSale_Result> list2 = Enumerable.ToList<WSspSelectProductSecondGroupActiveInSale_Result>((IEnumerable<WSspSelectProductSecondGroupActiveInSale_Result>)_db.WSspSelectProductSecondGroupActiveInSale(fgId, lCID, result));
				SelectListItem item = new SelectListItem
				{
					Text = Labels.SelectedListDefValue,
					Value = "",
					Selected = false
				};
				list.Add(item);
				list.AddRange(Enumerable.Select<WSspSelectProductSecondGroupActiveInSale_Result, SelectListItem>((IEnumerable<WSspSelectProductSecondGroupActiveInSale_Result>)Enumerable.ToList<WSspSelectProductSecondGroupActiveInSale_Result>((IEnumerable<WSspSelectProductSecondGroupActiveInSale_Result>)list2), (Func<WSspSelectProductSecondGroupActiveInSale_Result, SelectListItem>)((WSspSelectProductSecondGroupActiveInSale_Result i) => new SelectListItem
				{
					Text = i.SGName,
					Value = i.PrdSecondGroupID.ToString(),
					Selected = false
				})));
			}
			else
			{
				SelectListItem item2 = new SelectListItem
				{
					Text = Labels.SelectedListDefValue,
					Value = "",
					Selected = false
				};
				list.Add(item2);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PrdSGroupList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		base.Dispose(disposing);
	}
}

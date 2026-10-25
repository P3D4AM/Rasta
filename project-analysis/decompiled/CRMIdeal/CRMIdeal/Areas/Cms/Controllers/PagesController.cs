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
using CRM.General.IO.FTP;
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
using Kendo.Mvc.UI;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Cms.Controllers;

public class PagesController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass15_0
	{
		public int pageId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public int pageId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public CrmCmsPagesLanguageViewModel vm;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_1
	{
		public int defLangID;

		public CrmCmsPages model;

		public Func<Languages, bool> _003C_003E9__13;

		public Func<Languages, bool> _003C_003E9__35;

		internal bool _003CPageInsertEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CPageInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CPageInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CPageInsertEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CPageInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CPageInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CPageInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CPageInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CPageInsertEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CPageInsertEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CPageInsertEdit_003Eb__13(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CPageInsertEdit_003Eb__35(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass6_1 CS_0024_003C_003E8__locals1;

		internal bool _003CPageInsertEdit_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CPageInsertEdit_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CPageInsertEdit_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CPageInsertEdit_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CPageInsertEdit_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CPageInsertEdit_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CPageInsertEdit_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CPageInsertEdit_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CPageInsertEdit_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CPageInsertEdit_003Eb__24(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CPageInsertEdit_003Eb__25(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CPageInsertEdit_003Eb__26(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CPageInsertEdit_003Eb__27(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CPageInsertEdit_003Eb__28(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CPageInsertEdit_003Eb__29(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CPageInsertEdit_003Eb__30(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CPageInsertEdit_003Eb__31(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CPageInsertEdit_003Eb__32(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CPageInsertEdit_003Eb__33(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CPageInsertEdit_003Eb__34(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public int pageId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public CrmCmsPagesLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__26;

		public Func<Languages, bool> _003C_003E9__72;

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

		internal bool _003CInsertEdit_003Eb__26(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__72(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_1
	{
		public CrmCmsPages model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass8_1 CS_0024_003C_003E8__locals1;

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
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actcmsDefinePages")]
	public ActionResult Index(int pageId = 0)
	{
		base.ViewBag.CurrPageId = pageId;
		return View();
	}

	[AjaxOnly]
	public ActionResult _PartialPagesTree()
	{
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspCmsSelectPages_Result> list = Enumerable.ToList<CRMspCmsSelectPages_Result>((IEnumerable<CRMspCmsSelectPages_Result>)_db.CRMspCmsSelectPages(0, lCID, result));
			List<TreeViewItemModel> list2 = new List<TreeViewItemModel>();
			foreach (CRMspCmsSelectPages_Result item in list)
			{
				TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
				treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.PageId.ToString()));
				treeViewItemModel.Id = item.PageId.ToString();
				treeViewItemModel.Text = item.PageName;
				treeViewItemModel.ImageUrl = "";
				treeViewItemModel.Items = null;
				list2.Add(treeViewItemModel);
			}
			base.ViewBag.PagesTree = list2;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView();
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actcmsDefinePages")]
	public JsonResult GetPage(int pageId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CurrentCmsPageViewModel currentCmsPageViewModel = new CurrentCmsPageViewModel();
		try
		{
			CRMspCmsSelectPages_Result cRMspCmsSelectPages_Result = Enumerable.FirstOrDefault<CRMspCmsSelectPages_Result>((IEnumerable<CRMspCmsSelectPages_Result>)_db.CRMspCmsSelectPages(pageId, lCID, result));
			if (cRMspCmsSelectPages_Result != null)
			{
				currentCmsPageViewModel.IsFind = true;
				currentCmsPageViewModel.Message = "";
				currentCmsPageViewModel.Page = cRMspCmsSelectPages_Result;
				currentCmsPageViewModel.PageCurrentId = cRMspCmsSelectPages_Result.PageId;
				_ = cRMspCmsSelectPages_Result.FirstRegisterDate;
				cRMspCmsSelectPages_Result.FirstRegisterDatePersian = cRMspCmsSelectPages_Result.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				_ = cRMspCmsSelectPages_Result.RegisterDate;
				cRMspCmsSelectPages_Result.RegisterDatePersian = cRMspCmsSelectPages_Result.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				if (string.IsNullOrEmpty(cRMspCmsSelectPages_Result.AppType))
				{
					cRMspCmsSelectPages_Result.AppType = Configuration.AppType;
				}
				cRMspCmsSelectPages_Result.AppType = Configuration.GetAppType(cRMspCmsSelectPages_Result.AppType);
			}
			else
			{
				currentCmsPageViewModel.IsFind = false;
				currentCmsPageViewModel.Message = Messages.ErrorNotFound;
				currentCmsPageViewModel.Page = null;
				currentCmsPageViewModel.PageCurrentId = -1;
			}
		}
		catch (DbEntityValidationException ex)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
			currentCmsPageViewModel.Message = Messages.frmErrorMessage + "<br />" + ((Exception)(object)ex).Message;
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			currentCmsPageViewModel.Message = Messages.frmErrorMessage + "<br />" + ex2.Message;
		}
		JsonResult jsonResult = Json(currentCmsPageViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmCmsDefinePage", ActionName = "actInsert,actEdit")]
	public ActionResult _PartialPageInsertEdit(int pageId = 0)
	{
		_003C_003Ec__DisplayClass5_0 _003C_003Ec__DisplayClass5_ = new _003C_003Ec__DisplayClass5_0();
		_003C_003Ec__DisplayClass5_.pageId = pageId;
		CrmCmsPagesLanguageViewModel crmCmsPagesLanguageViewModel = new CrmCmsPagesLanguageViewModel();
		try
		{
			CrmCmsPages crmCmsPages = new CrmCmsPages();
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
			if (_003C_003Ec__DisplayClass5_.pageId > 0)
			{
				if (!UserLogin.IsUserAccess("frmCmsDefinePage", "actEdit"))
				{
					base.ViewBag.Error = Messages.NotAccessToPage;
					return null;
				}
				DbSet<CrmCmsPages_Lang> crmCmsPages_Lang = _dbTbl.CrmCmsPages_Lang;
				ParameterExpression val = Expression.Parameter(typeof(CrmCmsPages_Lang), "c");
				List<CrmCmsPages_Lang> list = Enumerable.ToList<CrmCmsPages_Lang>((IEnumerable<CrmCmsPages_Lang>)Queryable.Where<CrmCmsPages_Lang>((IQueryable<CrmCmsPages_Lang>)crmCmsPages_Lang, Expression.Lambda<Func<CrmCmsPages_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass5_, typeof(_003C_003Ec__DisplayClass5_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				DbSet<CrmCmsPages> crmCmsPages2 = _dbTbl.CrmCmsPages;
				val = Expression.Parameter(typeof(CrmCmsPages), "c");
				crmCmsPages = Queryable.FirstOrDefault<CrmCmsPages>((IQueryable<CrmCmsPages>)crmCmsPages2, Expression.Lambda<Func<CrmCmsPages, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass5_, typeof(_003C_003Ec__DisplayClass5_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (crmCmsPages == null)
				{
					base.ViewBag.Error = Messages.ErrorNotFound;
					return null;
				}
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsPages_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsPages_Lang>)list, (Func<CrmCmsPages_Lang, CommonMultiLanguageViewModel>)((CrmCmsPages_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.PageName,
					LanguageId = item.LanguageID
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCmsPages.PageName,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsPages_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsPages_Lang>)list, (Func<CrmCmsPages_Lang, CommonMultiLanguageViewModel>)((CrmCmsPages_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.PageTitle,
					LanguageId = item.LanguageID
				})));
				list3.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCmsPages.PageTitle,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsPages_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsPages_Lang>)list, (Func<CrmCmsPages_Lang, CommonMultiLanguageViewModel>)((CrmCmsPages_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.PageHeader,
					LanguageId = item.LanguageID
				})));
				list4.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCmsPages.PageHeader,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list5 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsPages_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsPages_Lang>)list, (Func<CrmCmsPages_Lang, CommonMultiLanguageViewModel>)((CrmCmsPages_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.PageBody,
					LanguageId = item.LanguageID
				})));
				list5.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCmsPages.PageBody,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list6 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsPages_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsPages_Lang>)list, (Func<CrmCmsPages_Lang, CommonMultiLanguageViewModel>)((CrmCmsPages_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.PageFooter,
					LanguageId = item.LanguageID
				})));
				list6.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCmsPages.PageFooter,
					LanguageId = result
				});
				crmCmsPagesLanguageViewModel = new CrmCmsPagesLanguageViewModel
				{
					PageId = crmCmsPages.PageId,
					PageName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
					PageName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
					PageTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
					PageTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
					PageHeader = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
					PageHeader_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
					PageBody = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
					PageBody_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
					PageFooter = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
					PageFooter_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
					IsActive = crmCmsPages.IsActive,
					OrderView = crmCmsPages.OrderView,
					PageStyle = crmCmsPages.PageStyle,
					PageHeaderScript = crmCmsPages.PageHeaderScript,
					PageEndScript = crmCmsPages.PageEndScript,
					CrmDyFormId = crmCmsPages.CrmDyFormId,
					TargetMode = crmCmsPages.TargetMode,
					OnlyForLoginUser = crmCmsPages.OnlyForLoginUser,
					PageLocation = crmCmsPages.PageLocation,
					LayoutType = crmCmsPages.LayoutType,
					FirstRegisterUserId = crmCmsPages.FirstRegisterUserId,
					FirstRegisterDate = crmCmsPages.FirstRegisterDate,
					FirstRegisterDatePersian = crmCmsPages.FirstRegisterDatePersian,
					UserId = crmCmsPages.UserId,
					Year1 = crmCmsPages.Year1,
					Month1 = crmCmsPages.Month1,
					RegisterDate = crmCmsPages.RegisterDate,
					RegisterDatePersian = crmCmsPages.RegisterDatePersian,
					GUId = crmCmsPages.GUId,
					AppType = crmCmsPages.AppType,
					LanguageID = crmCmsPages.LanguageID
				};
				CRMspCmsSelectPages_Result cRMspCmsSelectPages_Result = Enumerable.FirstOrDefault<CRMspCmsSelectPages_Result>((IEnumerable<CRMspCmsSelectPages_Result>)_db.CRMspCmsSelectPages(_003C_003Ec__DisplayClass5_.pageId, currLangID, result));
				if (cRMspCmsSelectPages_Result != null)
				{
					CrmCmsPagesLanguageViewModel crmCmsPagesLanguageViewModel2 = crmCmsPagesLanguageViewModel;
					_ = cRMspCmsSelectPages_Result.FirstRegisterDate;
					crmCmsPagesLanguageViewModel2.FirstRegisterDatePersian = cRMspCmsSelectPages_Result.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
					CrmCmsPagesLanguageViewModel crmCmsPagesLanguageViewModel3 = crmCmsPagesLanguageViewModel;
					_ = cRMspCmsSelectPages_Result.RegisterDate;
					crmCmsPagesLanguageViewModel3.RegisterDatePersian = cRMspCmsSelectPages_Result.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
					if (string.IsNullOrEmpty(cRMspCmsSelectPages_Result.AppType))
					{
						cRMspCmsSelectPages_Result.AppType = Configuration.AppType;
					}
					crmCmsPagesLanguageViewModel.AppType = Configuration.GetAppType(cRMspCmsSelectPages_Result.AppType);
					crmCmsPagesLanguageViewModel.FirstRegisterUser = cRMspCmsSelectPages_Result.FirstRegisterUser ?? "";
					crmCmsPagesLanguageViewModel.EditUser = cRMspCmsSelectPages_Result.EditUser + "(" + Labels.AppType + ":" + crmCmsPagesLanguageViewModel.AppType + ")";
				}
			}
			else
			{
				if (!UserLogin.IsUserAccess("frmCmsDefinePage", "actInsert"))
				{
					base.ViewBag.Error = Messages.NotAccessToPage;
					return null;
				}
				DateTime now = DateTime.Now;
				crmCmsPagesLanguageViewModel = new CrmCmsPagesLanguageViewModel
				{
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
		GetPageLocation();
		GetLayoutType();
		return PartialView(crmCmsPagesLanguageViewModel);
	}

	[HttpPost]
	[AllowAnonymous]
	[DynamicAuthorize(ControllerName = "frmCmsDefinePageDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public JsonResult PageInsertEdit(CrmCmsPagesLanguageViewModel vm)
	{
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass6_0 _003C_003Ec__DisplayClass6_ = new _003C_003Ec__DisplayClass6_0();
		_003C_003Ec__DisplayClass6_.vm = vm;
		CurrentCmsPageViewModel currentCmsPageViewModel = new CurrentCmsPageViewModel();
		try
		{
			_003C_003Ec__DisplayClass6_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass6_1();
			CS_0024_003C_003E8__locals0.model = new CrmCmsPages();
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
			if (CS_0024_003C_003E8__locals0.defLangID <= 0)
			{
				CS_0024_003C_003E8__locals0.defLangID = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(_003C_003Ec__DisplayClass6_.vm.PageName_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(_003C_003Ec__DisplayClass6_.vm.PageName_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = _003C_003Ec__DisplayClass6_.vm.PageName,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(_003C_003Ec__DisplayClass6_.vm.PageTitle_Lang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(_003C_003Ec__DisplayClass6_.vm.PageTitle_Lang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = _003C_003Ec__DisplayClass6_.vm.PageTitle,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(_003C_003Ec__DisplayClass6_.vm.PageHeader_Lang))
			{
				list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(_003C_003Ec__DisplayClass6_.vm.PageHeader_Lang);
			}
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = _003C_003Ec__DisplayClass6_.vm.PageHeader,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(_003C_003Ec__DisplayClass6_.vm.PageBody_Lang))
			{
				list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(_003C_003Ec__DisplayClass6_.vm.PageBody_Lang);
			}
			list4.Add(new CommonMultiLanguageViewModel
			{
				Value = _003C_003Ec__DisplayClass6_.vm.PageBody,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(_003C_003Ec__DisplayClass6_.vm.PageFooter_Lang))
			{
				list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(_003C_003Ec__DisplayClass6_.vm.PageFooter_Lang);
			}
			list5.Add(new CommonMultiLanguageViewModel
			{
				Value = _003C_003Ec__DisplayClass6_.vm.PageFooter,
				LanguageId = lCID
			});
			GetDyForms();
			GetTargetMode();
			GetPageLocation();
			GetLayoutType();
			_ = CRMIdeal.Cache.Setting.Language.Get().Count;
			string text = "";
			int num = 0;
			if (string.IsNullOrEmpty(_003C_003Ec__DisplayClass6_.vm.PageName))
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.CmsPageName) + "<br/>";
				num++;
			}
			else if (!checkMultiLanguage(_003C_003Ec__DisplayClass6_.vm.PageName, list))
			{
				text = text + string.Format(Messages.CheckFieldInLang, Labels.CmsPageName) + "<br>";
				num++;
			}
			if (string.IsNullOrEmpty(_003C_003Ec__DisplayClass6_.vm.PageTitle))
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.CmsPageTitle) + "<br/>";
				num++;
			}
			else if (!checkMultiLanguage(_003C_003Ec__DisplayClass6_.vm.PageTitle, list2))
			{
				text = text + string.Format(Messages.CheckFieldInLang, Labels.CmsPageTitle) + "<br>";
				num++;
			}
			if (num > 0)
			{
				currentCmsPageViewModel = new CurrentCmsPageViewModel
				{
					Page = null,
					Message = text,
					IsFind = false
				};
				return Json(currentCmsPageViewModel, JsonRequestBehavior.AllowGet);
			}
			if (base.ModelState.IsValid)
			{
				CS_0024_003C_003E8__locals0.model = new CrmCmsPages();
				if (_003C_003Ec__DisplayClass6_.vm.PageId > 0)
				{
					DbSet<CrmCmsPages> crmCmsPages = _dbTbl.CrmCmsPages;
					ParameterExpression val = Expression.Parameter(typeof(CrmCmsPages), "c");
					CS_0024_003C_003E8__locals0.model = Queryable.FirstOrDefault<CrmCmsPages>((IQueryable<CrmCmsPages>)crmCmsPages, Expression.Lambda<Func<CrmCmsPages, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass6_, typeof(_003C_003Ec__DisplayClass6_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				CS_0024_003C_003E8__locals0.model.UserId = UserLogin.CurrentUser.UserId;
				DateTime now = DateTime.Now;
				CS_0024_003C_003E8__locals0.model.RegisterDate = now;
				CS_0024_003C_003E8__locals0.model.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				CS_0024_003C_003E8__locals0.model.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
				CS_0024_003C_003E8__locals0.model.AppType = Configuration.AppType;
				CS_0024_003C_003E8__locals0.model.Year1 = short.Parse(Financial.Get().Id.ToString());
				CS_0024_003C_003E8__locals0.model.PageName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				CS_0024_003C_003E8__locals0.model.PageTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				CS_0024_003C_003E8__locals0.model.PageHeader = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				CS_0024_003C_003E8__locals0.model.PageBody = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				CS_0024_003C_003E8__locals0.model.PageFooter = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				CS_0024_003C_003E8__locals0.model.IsActive = _003C_003Ec__DisplayClass6_.vm.IsActive;
				CS_0024_003C_003E8__locals0.model.OrderView = _003C_003Ec__DisplayClass6_.vm.OrderView;
				CS_0024_003C_003E8__locals0.model.PageStyle = _003C_003Ec__DisplayClass6_.vm.PageStyle;
				CS_0024_003C_003E8__locals0.model.PageHeaderScript = _003C_003Ec__DisplayClass6_.vm.PageHeaderScript;
				CS_0024_003C_003E8__locals0.model.PageEndScript = _003C_003Ec__DisplayClass6_.vm.PageEndScript;
				CS_0024_003C_003E8__locals0.model.CrmDyFormId = _003C_003Ec__DisplayClass6_.vm.CrmDyFormId;
				CS_0024_003C_003E8__locals0.model.TargetMode = _003C_003Ec__DisplayClass6_.vm.TargetMode;
				CS_0024_003C_003E8__locals0.model.OnlyForLoginUser = _003C_003Ec__DisplayClass6_.vm.OnlyForLoginUser;
				CS_0024_003C_003E8__locals0.model.PageLocation = _003C_003Ec__DisplayClass6_.vm.PageLocation;
				CS_0024_003C_003E8__locals0.model.LayoutType = _003C_003Ec__DisplayClass6_.vm.LayoutType;
				if (CS_0024_003C_003E8__locals0.model.PageId > 0)
				{
					_dbTbl.Entry(CS_0024_003C_003E8__locals0.model).State = EntityState.Modified;
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass6_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass6_2();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							DbSet<CrmCmsPages_Lang> crmCmsPages_Lang = _dbTbl.CrmCmsPages_Lang;
							ParameterExpression val = Expression.Parameter(typeof(CrmCmsPages_Lang), "c");
							CrmCmsPages_Lang crmCmsPages_Lang2 = Queryable.FirstOrDefault<CrmCmsPages_Lang>((IQueryable<CrmCmsPages_Lang>)crmCmsPages_Lang, Expression.Lambda<Func<CrmCmsPages_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass6_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass6_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (crmCmsPages_Lang2 != null)
							{
								crmCmsPages_Lang2.PageName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmCmsPages_Lang2.PageTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmCmsPages_Lang2.PageHeader = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmCmsPages_Lang2.PageBody = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmCmsPages_Lang2.PageFooter = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(crmCmsPages_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							crmCmsPages_Lang2 = new CrmCmsPages_Lang();
							crmCmsPages_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
							crmCmsPages_Lang2.PageId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.PageId;
							crmCmsPages_Lang2.PageName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							crmCmsPages_Lang2.PageTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							crmCmsPages_Lang2.PageHeader = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							crmCmsPages_Lang2.PageBody = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							crmCmsPages_Lang2.PageFooter = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							_dbTbl.CrmCmsPages_Lang.Add(crmCmsPages_Lang2);
							_dbTbl.SaveChanges();
						}
					}
					text = Messages.frmFormBaseEditSuccessFulMessage;
				}
				else
				{
					CS_0024_003C_003E8__locals0.model.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
					CS_0024_003C_003E8__locals0.model.FirstRegisterDate = now;
					CS_0024_003C_003E8__locals0.model.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					CS_0024_003C_003E8__locals0.model.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
					CS_0024_003C_003E8__locals0.model.GUId = Guid.NewGuid();
					_dbTbl.CrmCmsPages.Add(CS_0024_003C_003E8__locals0.model);
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
					{
						CrmCmsPages_Lang crmCmsPages_Lang3 = new CrmCmsPages_Lang();
						crmCmsPages_Lang3.LanguageID = lang.LanguageID;
						crmCmsPages_Lang3.PageId = CS_0024_003C_003E8__locals0.model.PageId;
						crmCmsPages_Lang3.PageName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmCmsPages_Lang3.PageTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmCmsPages_Lang3.PageHeader = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmCmsPages_Lang3.PageBody = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmCmsPages_Lang3.PageFooter = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						_dbTbl.CrmCmsPages_Lang.Add(crmCmsPages_Lang3);
						_dbTbl.SaveChanges();
					}
					text = Messages.frmFormBaseInsertSuccessFulMessage;
				}
				_003C_003Ec__DisplayClass6_.vm.PageId = CS_0024_003C_003E8__locals0.model.PageId;
				_003C_003Ec__DisplayClass6_.vm.RegisterDate = CS_0024_003C_003E8__locals0.model.RegisterDate;
				_003C_003Ec__DisplayClass6_.vm.UserId = CS_0024_003C_003E8__locals0.model.UserId;
				_003C_003Ec__DisplayClass6_.vm.FirstRegisterDate = CS_0024_003C_003E8__locals0.model.FirstRegisterDate;
				_003C_003Ec__DisplayClass6_.vm.FirstRegisterUserId = CS_0024_003C_003E8__locals0.model.FirstRegisterUserId;
				CRMspCmsSelectPages_Result cRMspCmsSelectPages_Result = Enumerable.FirstOrDefault<CRMspCmsSelectPages_Result>((IEnumerable<CRMspCmsSelectPages_Result>)_db.CRMspCmsSelectPages(_003C_003Ec__DisplayClass6_.vm.PageId, lCID, CS_0024_003C_003E8__locals0.defLangID));
				CRMspCmsSelectPages_Result page = new CRMspCmsSelectPages_Result();
				if (cRMspCmsSelectPages_Result != null)
				{
					CrmCmsPagesLanguageViewModel vm2 = _003C_003Ec__DisplayClass6_.vm;
					_ = cRMspCmsSelectPages_Result.FirstRegisterDate;
					vm2.FirstRegisterDatePersian = cRMspCmsSelectPages_Result.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
					CrmCmsPagesLanguageViewModel vm3 = _003C_003Ec__DisplayClass6_.vm;
					_ = cRMspCmsSelectPages_Result.RegisterDate;
					vm3.RegisterDatePersian = cRMspCmsSelectPages_Result.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
					if (string.IsNullOrEmpty(cRMspCmsSelectPages_Result.AppType))
					{
						cRMspCmsSelectPages_Result.AppType = Configuration.AppType;
					}
					_003C_003Ec__DisplayClass6_.vm.AppType = Configuration.GetAppType(cRMspCmsSelectPages_Result.AppType);
					_003C_003Ec__DisplayClass6_.vm.FirstRegisterUser = cRMspCmsSelectPages_Result.FirstRegisterUser ?? "";
					_003C_003Ec__DisplayClass6_.vm.EditUser = cRMspCmsSelectPages_Result.EditUser + "(" + Labels.AppType + ":" + _003C_003Ec__DisplayClass6_.vm.AppType + ")";
					cRMspCmsSelectPages_Result.FirstRegisterDatePersian = _003C_003Ec__DisplayClass6_.vm.FirstRegisterDatePersian;
					cRMspCmsSelectPages_Result.RegisterDatePersian = _003C_003Ec__DisplayClass6_.vm.RegisterDatePersian;
					cRMspCmsSelectPages_Result.FirstRegisterUser = _003C_003Ec__DisplayClass6_.vm.FirstRegisterUser;
					cRMspCmsSelectPages_Result.EditUser = _003C_003Ec__DisplayClass6_.vm.EditUser;
					page = cRMspCmsSelectPages_Result;
				}
				currentCmsPageViewModel = new CurrentCmsPageViewModel
				{
					Page = page,
					Message = text,
					IsFind = true
				};
			}
			else
			{
				text = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
				currentCmsPageViewModel = new CurrentCmsPageViewModel
				{
					Page = null,
					Message = text,
					IsFind = false
				};
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			currentCmsPageViewModel = new CurrentCmsPageViewModel
			{
				Page = null,
				Message = ex.Message,
				IsFind = false
			};
		}
		return Json(currentCmsPageViewModel, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmCmsDefinePage", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(int pageId = 0)
	{
		_003C_003Ec__DisplayClass7_0 _003C_003Ec__DisplayClass7_ = new _003C_003Ec__DisplayClass7_0();
		_003C_003Ec__DisplayClass7_.pageId = pageId;
		CrmCmsPagesLanguageViewModel crmCmsPagesLanguageViewModel = new CrmCmsPagesLanguageViewModel();
		try
		{
			CrmCmsPages crmCmsPages = new CrmCmsPages();
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
			if (_003C_003Ec__DisplayClass7_.pageId > 0)
			{
				if (!UserLogin.IsUserAccess("frmCmsDefinePage", "actEdit"))
				{
					base.ViewBag.Error = Messages.NotAccessToPage;
					return null;
				}
				DbSet<CrmCmsPages_Lang> crmCmsPages_Lang = _dbTbl.CrmCmsPages_Lang;
				ParameterExpression val = Expression.Parameter(typeof(CrmCmsPages_Lang), "c");
				List<CrmCmsPages_Lang> list = Enumerable.ToList<CrmCmsPages_Lang>((IEnumerable<CrmCmsPages_Lang>)Queryable.Where<CrmCmsPages_Lang>((IQueryable<CrmCmsPages_Lang>)crmCmsPages_Lang, Expression.Lambda<Func<CrmCmsPages_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass7_, typeof(_003C_003Ec__DisplayClass7_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				DbSet<CrmCmsPages> crmCmsPages2 = _dbTbl.CrmCmsPages;
				val = Expression.Parameter(typeof(CrmCmsPages), "c");
				crmCmsPages = Queryable.FirstOrDefault<CrmCmsPages>((IQueryable<CrmCmsPages>)crmCmsPages2, Expression.Lambda<Func<CrmCmsPages, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass7_, typeof(_003C_003Ec__DisplayClass7_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (crmCmsPages == null)
				{
					base.ViewBag.Error = Messages.ErrorNotFound;
					return null;
				}
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsPages_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsPages_Lang>)list, (Func<CrmCmsPages_Lang, CommonMultiLanguageViewModel>)((CrmCmsPages_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.PageName,
					LanguageId = item.LanguageID
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCmsPages.PageName,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsPages_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsPages_Lang>)list, (Func<CrmCmsPages_Lang, CommonMultiLanguageViewModel>)((CrmCmsPages_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.PageTitle,
					LanguageId = item.LanguageID
				})));
				list3.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCmsPages.PageTitle,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsPages_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsPages_Lang>)list, (Func<CrmCmsPages_Lang, CommonMultiLanguageViewModel>)((CrmCmsPages_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.PageHeader,
					LanguageId = item.LanguageID
				})));
				list4.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCmsPages.PageHeader,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list5 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsPages_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsPages_Lang>)list, (Func<CrmCmsPages_Lang, CommonMultiLanguageViewModel>)((CrmCmsPages_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.PageBody,
					LanguageId = item.LanguageID
				})));
				list5.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCmsPages.PageBody,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list6 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsPages_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsPages_Lang>)list, (Func<CrmCmsPages_Lang, CommonMultiLanguageViewModel>)((CrmCmsPages_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.PageFooter,
					LanguageId = item.LanguageID
				})));
				list6.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCmsPages.PageFooter,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list7 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsPages_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsPages_Lang>)list, (Func<CrmCmsPages_Lang, CommonMultiLanguageViewModel>)((CrmCmsPages_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.PageSeoTitle,
					LanguageId = item.LanguageID
				})));
				list7.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCmsPages.PageSeoTitle,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list8 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsPages_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsPages_Lang>)list, (Func<CrmCmsPages_Lang, CommonMultiLanguageViewModel>)((CrmCmsPages_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.PageSeoDescription,
					LanguageId = item.LanguageID
				})));
				list8.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCmsPages.PageSeoDescription,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list9 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsPages_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsPages_Lang>)list, (Func<CrmCmsPages_Lang, CommonMultiLanguageViewModel>)((CrmCmsPages_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.PageSeoKeywords,
					LanguageId = item.LanguageID
				})));
				list9.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCmsPages.PageSeoKeywords,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list10 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsPages_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsPages_Lang>)list, (Func<CrmCmsPages_Lang, CommonMultiLanguageViewModel>)((CrmCmsPages_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.PageSeoFaq,
					LanguageId = item.LanguageID
				})));
				list10.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCmsPages.PageSeoFaq,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list11 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsPages_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsPages_Lang>)list, (Func<CrmCmsPages_Lang, CommonMultiLanguageViewModel>)((CrmCmsPages_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.PageSeoAuthor,
					LanguageId = item.LanguageID
				})));
				list11.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCmsPages.PageSeoAuthor,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list12 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsPages_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsPages_Lang>)list, (Func<CrmCmsPages_Lang, CommonMultiLanguageViewModel>)((CrmCmsPages_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.PageSeoCopyright,
					LanguageId = item.LanguageID
				})));
				list12.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCmsPages.PageSeoCopyright,
					LanguageId = result
				});
				crmCmsPagesLanguageViewModel = new CrmCmsPagesLanguageViewModel
				{
					PageId = crmCmsPages.PageId,
					PageName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
					PageName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
					PageTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
					PageTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
					PageHeader = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
					PageHeader_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
					PageBody = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
					PageBody_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
					PageFooter = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
					PageFooter_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
					IsActive = crmCmsPages.IsActive,
					OrderView = crmCmsPages.OrderView,
					PageStyle = crmCmsPages.PageStyle,
					PageHeaderScript = crmCmsPages.PageHeaderScript,
					PageEndScript = crmCmsPages.PageEndScript,
					CrmDyFormId = crmCmsPages.CrmDyFormId,
					TargetMode = crmCmsPages.TargetMode,
					OnlyForLoginUser = crmCmsPages.OnlyForLoginUser,
					PageLocation = crmCmsPages.PageLocation,
					LayoutType = crmCmsPages.LayoutType,
					FirstRegisterUserId = crmCmsPages.FirstRegisterUserId,
					FirstRegisterDate = crmCmsPages.FirstRegisterDate,
					FirstRegisterDatePersian = crmCmsPages.FirstRegisterDatePersian,
					UserId = crmCmsPages.UserId,
					Year1 = crmCmsPages.Year1,
					Month1 = crmCmsPages.Month1,
					RegisterDate = crmCmsPages.RegisterDate,
					RegisterDatePersian = crmCmsPages.RegisterDatePersian,
					GUId = crmCmsPages.GUId,
					AppType = crmCmsPages.AppType,
					LanguageID = crmCmsPages.LanguageID,
					PageSeoTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
					PageSeoTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
					PageSeoDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
					PageSeoDescription_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
					PageSeoKeywords = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
					PageSeoKeywords_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
					PageSeoFaq = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
					PageSeoFaq_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
					PageSeoIsActive = crmCmsPages.PageSeoIsActive,
					PageSeoHttpEquiv = crmCmsPages.PageSeoHttpEquiv,
					PageSeoExpires = crmCmsPages.PageSeoExpires,
					PageSeoGoogleNotranslate = crmCmsPages.PageSeoGoogleNotranslate,
					PageSeoDistribution = crmCmsPages.PageSeoDistribution,
					PageSeoRobots = crmCmsPages.PageSeoRobots,
					PageSeoRating = crmCmsPages.PageSeoRating,
					PageSeoAuthor = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
					PageSeoIsUseSocialNetwork = crmCmsPages.PageSeoIsUseSocialNetwork,
					PageSeoMobileOptimized = crmCmsPages.PageSeoMobileOptimized,
					PageSeoCopyright = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
					PageSeoUseDefault = crmCmsPages.PageSeoUseDefault,
					PageSeoAuthor_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
					PageSeoCopyright_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))))
				};
				CRMspCmsSelectPages_Result cRMspCmsSelectPages_Result = Enumerable.FirstOrDefault<CRMspCmsSelectPages_Result>((IEnumerable<CRMspCmsSelectPages_Result>)_db.CRMspCmsSelectPages(_003C_003Ec__DisplayClass7_.pageId, currLangID, result));
				if (cRMspCmsSelectPages_Result != null)
				{
					CrmCmsPagesLanguageViewModel crmCmsPagesLanguageViewModel2 = crmCmsPagesLanguageViewModel;
					_ = cRMspCmsSelectPages_Result.FirstRegisterDate;
					crmCmsPagesLanguageViewModel2.FirstRegisterDatePersian = cRMspCmsSelectPages_Result.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
					CrmCmsPagesLanguageViewModel crmCmsPagesLanguageViewModel3 = crmCmsPagesLanguageViewModel;
					_ = cRMspCmsSelectPages_Result.RegisterDate;
					crmCmsPagesLanguageViewModel3.RegisterDatePersian = cRMspCmsSelectPages_Result.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
					if (string.IsNullOrEmpty(cRMspCmsSelectPages_Result.AppType))
					{
						cRMspCmsSelectPages_Result.AppType = Configuration.AppType;
					}
					crmCmsPagesLanguageViewModel.AppType = Configuration.GetAppType(cRMspCmsSelectPages_Result.AppType);
					crmCmsPagesLanguageViewModel.FirstRegisterUser = cRMspCmsSelectPages_Result.FirstRegisterUser ?? "";
					crmCmsPagesLanguageViewModel.EditUser = cRMspCmsSelectPages_Result.EditUser + "(" + Labels.AppType + ":" + crmCmsPagesLanguageViewModel.AppType + ")";
				}
			}
			else
			{
				if (!UserLogin.IsUserAccess("frmCmsDefinePage", "actInsert"))
				{
					base.ViewBag.Error = Messages.NotAccessToPage;
					return null;
				}
				DateTime now = DateTime.Now;
				crmCmsPagesLanguageViewModel = new CrmCmsPagesLanguageViewModel
				{
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
				List<CRMspCmsSelectPages_Result> list13 = Enumerable.ToList<CRMspCmsSelectPages_Result>((IEnumerable<CRMspCmsSelectPages_Result>)_db.CRMspCmsSelectPages(0, currLangID, result));
				if (!Enumerable.Any<CRMspCmsSelectPages_Result>((IEnumerable<CRMspCmsSelectPages_Result>)list13))
				{
					crmCmsPagesLanguageViewModel.OrderView = 10;
				}
				else
				{
					int result2 = 10;
					CRMspCmsSelectPages_Result cRMspCmsSelectPages_Result2 = Enumerable.LastOrDefault<CRMspCmsSelectPages_Result>((IEnumerable<CRMspCmsSelectPages_Result>)list13);
					if (cRMspCmsSelectPages_Result2 != null)
					{
						int.TryParse(cRMspCmsSelectPages_Result2.OrderView.ToString(), out result2);
						result2 = ((result2 == 0) ? 10 : (result2 + 10));
					}
					crmCmsPagesLanguageViewModel.OrderView = result2;
				}
				base.ViewBag.IsBuying = VersionBuyer.FoCmsPage;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		GetDyForms();
		GetTargetMode();
		GetPageLocation();
		GetLayoutType();
		GetLanguagesList();
		return View(crmCmsPagesLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmCmsDefinePageDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult InsertEdit(CrmCmsPagesLanguageViewModel vm)
	{
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_031f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0373: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c7: Unknown result type (might be due to invalid IL or missing references)
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
			_003C_003Ec__DisplayClass8_.model = new CrmCmsPages();
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.PageName_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.PageName_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.PageName,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.PageTitle_Lang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.PageTitle_Lang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.PageTitle,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.PageHeader_Lang))
			{
				list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.PageHeader_Lang);
			}
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.PageHeader,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.PageBody_Lang))
			{
				list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.PageBody_Lang);
			}
			list4.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.PageBody,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.PageFooter_Lang))
			{
				list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.PageFooter_Lang);
			}
			list5.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.PageFooter,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.PageSeoTitle_Lang))
			{
				list6 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.PageSeoTitle_Lang);
			}
			list6.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.PageSeoTitle,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list7 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.PageSeoDescription_Lang))
			{
				list7 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.PageSeoDescription_Lang);
			}
			list7.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.PageSeoDescription,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list8 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.PageSeoKeywords_Lang))
			{
				list8 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.PageSeoKeywords_Lang);
			}
			list8.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.PageSeoKeywords,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list9 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.PageSeoFaq_Lang))
			{
				list9 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.PageSeoFaq_Lang);
			}
			list9.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.PageSeoFaq,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list10 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.PageSeoAuthor_Lang))
			{
				list10 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.PageSeoAuthor_Lang);
			}
			list10.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.PageSeoAuthor,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list11 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.PageSeoCopyright_Lang))
			{
				list11 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.PageSeoCopyright_Lang);
			}
			list11.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.PageSeoCopyright,
				LanguageId = lCID
			});
			GetDyForms();
			GetTargetMode();
			GetPageLocation();
			GetLayoutType();
			GetLanguagesList();
			if (CS_0024_003C_003E8__locals0.vm.PageId <= 0 && !VersionBuyer.FoCmsPage)
			{
				DbSet<CrmCmsPages> crmCmsPages = _dbTbl.CrmCmsPages;
				ParameterExpression val = Expression.Parameter(typeof(CrmCmsPages), "c");
				if (Queryable.Any<CrmCmsPages>((IQueryable<CrmCmsPages>)crmCmsPages, Expression.Lambda<Func<CrmCmsPages, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)1, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val })))
				{
					base.ViewBag.Error = "BV|" + string.Format(Messages.VersionBuyWithCount, "1");
					return View(CS_0024_003C_003E8__locals0.vm);
				}
			}
			_ = CRMIdeal.Cache.Setting.Language.Get().Count;
			string text = "";
			int num = 0;
			if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.PageName))
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.CmsPageName) + "<br/>";
				num++;
			}
			else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.PageName, list))
			{
				text = text + string.Format(Messages.CheckFieldInLang, Labels.CmsPageName) + "<br>";
				num++;
			}
			if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.PageTitle))
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.CmsPageTitle) + "<br/>";
				num++;
			}
			else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.PageTitle, list2))
			{
				text = text + string.Format(Messages.CheckFieldInLang, Labels.CmsPageTitle) + "<br>";
				num++;
			}
			if (num > 0)
			{
				base.ViewBag.Error = text;
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			if (base.ModelState.IsValid)
			{
				_003C_003Ec__DisplayClass8_.model = new CrmCmsPages();
				if (CS_0024_003C_003E8__locals0.vm.PageId > 0)
				{
					DbSet<CrmCmsPages> crmCmsPages2 = _dbTbl.CrmCmsPages;
					ParameterExpression val = Expression.Parameter(typeof(CrmCmsPages), "c");
					_003C_003Ec__DisplayClass8_.model = Queryable.FirstOrDefault<CrmCmsPages>((IQueryable<CrmCmsPages>)crmCmsPages2, Expression.Lambda<Func<CrmCmsPages, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				_003C_003Ec__DisplayClass8_.model.UserId = UserLogin.CurrentUser.UserId;
				DateTime now = DateTime.Now;
				_003C_003Ec__DisplayClass8_.model.RegisterDate = now;
				_003C_003Ec__DisplayClass8_.model.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				_003C_003Ec__DisplayClass8_.model.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
				_003C_003Ec__DisplayClass8_.model.AppType = Configuration.AppType;
				_003C_003Ec__DisplayClass8_.model.Year1 = short.Parse(Financial.Get().Id.ToString());
				_003C_003Ec__DisplayClass8_.model.PageName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass8_.model.PageTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass8_.model.PageHeader = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass8_.model.PageBody = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass8_.model.PageFooter = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass8_.model.IsActive = CS_0024_003C_003E8__locals0.vm.IsActive;
				_003C_003Ec__DisplayClass8_.model.OrderView = CS_0024_003C_003E8__locals0.vm.OrderView;
				_003C_003Ec__DisplayClass8_.model.PageStyle = CS_0024_003C_003E8__locals0.vm.PageStyle;
				_003C_003Ec__DisplayClass8_.model.PageHeaderScript = CS_0024_003C_003E8__locals0.vm.PageHeaderScript;
				_003C_003Ec__DisplayClass8_.model.PageEndScript = CS_0024_003C_003E8__locals0.vm.PageEndScript;
				_003C_003Ec__DisplayClass8_.model.CrmDyFormId = CS_0024_003C_003E8__locals0.vm.CrmDyFormId;
				_003C_003Ec__DisplayClass8_.model.TargetMode = CS_0024_003C_003E8__locals0.vm.TargetMode;
				_003C_003Ec__DisplayClass8_.model.OnlyForLoginUser = CS_0024_003C_003E8__locals0.vm.OnlyForLoginUser;
				_003C_003Ec__DisplayClass8_.model.PageLocation = CS_0024_003C_003E8__locals0.vm.PageLocation;
				_003C_003Ec__DisplayClass8_.model.LayoutType = CS_0024_003C_003E8__locals0.vm.LayoutType;
				_003C_003Ec__DisplayClass8_.model.PageSeoTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass8_.model.PageSeoDescription = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass8_.model.PageSeoKeywords = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass8_.model.PageSeoFaq = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass8_.model.PageSeoIsActive = CS_0024_003C_003E8__locals0.vm.PageSeoIsActive;
				_003C_003Ec__DisplayClass8_.model.PageSeoHttpEquiv = CS_0024_003C_003E8__locals0.vm.PageSeoHttpEquiv;
				_003C_003Ec__DisplayClass8_.model.PageSeoExpires = CS_0024_003C_003E8__locals0.vm.PageSeoExpires;
				_003C_003Ec__DisplayClass8_.model.PageSeoGoogleNotranslate = CS_0024_003C_003E8__locals0.vm.PageSeoGoogleNotranslate;
				_003C_003Ec__DisplayClass8_.model.PageSeoDistribution = CS_0024_003C_003E8__locals0.vm.PageSeoDistribution;
				_003C_003Ec__DisplayClass8_.model.PageSeoRobots = CS_0024_003C_003E8__locals0.vm.PageSeoRobots;
				_003C_003Ec__DisplayClass8_.model.PageSeoRating = CS_0024_003C_003E8__locals0.vm.PageSeoRating;
				_003C_003Ec__DisplayClass8_.model.PageSeoAuthor = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass8_.model.PageSeoIsUseSocialNetwork = CS_0024_003C_003E8__locals0.vm.PageSeoIsUseSocialNetwork;
				_003C_003Ec__DisplayClass8_.model.PageSeoMobileOptimized = CS_0024_003C_003E8__locals0.vm.PageSeoMobileOptimized;
				_003C_003Ec__DisplayClass8_.model.PageSeoCopyright = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass8_.model.PageSeoUseDefault = CS_0024_003C_003E8__locals0.vm.PageSeoUseDefault;
				if (_003C_003Ec__DisplayClass8_.model.PageId > 0)
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
							DbSet<CrmCmsPages_Lang> crmCmsPages_Lang = _dbTbl.CrmCmsPages_Lang;
							ParameterExpression val = Expression.Parameter(typeof(CrmCmsPages_Lang), "c");
							CrmCmsPages_Lang crmCmsPages_Lang2 = Queryable.FirstOrDefault<CrmCmsPages_Lang>((IQueryable<CrmCmsPages_Lang>)crmCmsPages_Lang, Expression.Lambda<Func<CrmCmsPages_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass8_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass8_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (crmCmsPages_Lang2 != null)
							{
								crmCmsPages_Lang2.PageName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmCmsPages_Lang2.PageTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmCmsPages_Lang2.PageHeader = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmCmsPages_Lang2.PageBody = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmCmsPages_Lang2.PageFooter = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmCmsPages_Lang2.PageSeoTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmCmsPages_Lang2.PageSeoDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmCmsPages_Lang2.PageSeoKeywords = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmCmsPages_Lang2.PageSeoFaq = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmCmsPages_Lang2.PageSeoAuthor = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmCmsPages_Lang2.PageSeoCopyright = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(crmCmsPages_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							crmCmsPages_Lang2 = new CrmCmsPages_Lang();
							crmCmsPages_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
							crmCmsPages_Lang2.PageId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.PageId;
							crmCmsPages_Lang2.PageName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							crmCmsPages_Lang2.PageTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							crmCmsPages_Lang2.PageHeader = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							crmCmsPages_Lang2.PageBody = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							crmCmsPages_Lang2.PageFooter = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							crmCmsPages_Lang2.PageSeoTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							crmCmsPages_Lang2.PageSeoDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							crmCmsPages_Lang2.PageSeoKeywords = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							crmCmsPages_Lang2.PageSeoFaq = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							crmCmsPages_Lang2.PageSeoAuthor = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							crmCmsPages_Lang2.PageSeoCopyright = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							_dbTbl.CrmCmsPages_Lang.Add(crmCmsPages_Lang2);
							_dbTbl.SaveChanges();
						}
					}
					text = Messages.frmFormBaseEditSuccessFulMessage;
				}
				else
				{
					if (!CS_0024_003C_003E8__locals0.vm.OrderView.HasValue)
					{
						List<CRMspCmsSelectPages_Result> list12 = Enumerable.ToList<CRMspCmsSelectPages_Result>((IEnumerable<CRMspCmsSelectPages_Result>)_db.CRMspCmsSelectPages(0, lCID, CS_0024_003C_003E8__locals0.defLangID));
						int num2 = (Enumerable.Any<CRMspCmsSelectPages_Result>((IEnumerable<CRMspCmsSelectPages_Result>)list12) ? Enumerable.Count<CRMspCmsSelectPages_Result>((IEnumerable<CRMspCmsSelectPages_Result>)list12) : 0);
						_003C_003Ec__DisplayClass8_.model.OrderView = num2 * 10 + 10;
						if (Enumerable.LastOrDefault<CRMspCmsSelectPages_Result>((IEnumerable<CRMspCmsSelectPages_Result>)list12) != null)
						{
							int valueOrDefault = Enumerable.LastOrDefault<CRMspCmsSelectPages_Result>((IEnumerable<CRMspCmsSelectPages_Result>)list12).OrderView.GetValueOrDefault();
							if (valueOrDefault > 0)
							{
								_003C_003Ec__DisplayClass8_.model.OrderView = valueOrDefault + 10;
							}
						}
					}
					else
					{
						_003C_003Ec__DisplayClass8_.model.OrderView = CS_0024_003C_003E8__locals0.vm.OrderView;
					}
					_003C_003Ec__DisplayClass8_.model.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
					_003C_003Ec__DisplayClass8_.model.FirstRegisterDate = now;
					_003C_003Ec__DisplayClass8_.model.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					_003C_003Ec__DisplayClass8_.model.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
					_003C_003Ec__DisplayClass8_.model.GUId = Guid.NewGuid();
					_dbTbl.CrmCmsPages.Add(_003C_003Ec__DisplayClass8_.model);
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
					{
						CrmCmsPages_Lang crmCmsPages_Lang3 = new CrmCmsPages_Lang();
						crmCmsPages_Lang3.LanguageID = lang.LanguageID;
						crmCmsPages_Lang3.PageId = _003C_003Ec__DisplayClass8_.model.PageId;
						crmCmsPages_Lang3.PageName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmCmsPages_Lang3.PageTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmCmsPages_Lang3.PageHeader = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmCmsPages_Lang3.PageBody = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmCmsPages_Lang3.PageFooter = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmCmsPages_Lang3.PageSeoTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmCmsPages_Lang3.PageSeoDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmCmsPages_Lang3.PageSeoKeywords = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmCmsPages_Lang3.PageSeoFaq = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmCmsPages_Lang3.PageSeoAuthor = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmCmsPages_Lang3.PageSeoCopyright = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						_dbTbl.CrmCmsPages_Lang.Add(crmCmsPages_Lang3);
						_dbTbl.SaveChanges();
					}
					text = Messages.frmFormBaseInsertSuccessFulMessage;
				}
				CS_0024_003C_003E8__locals0.vm.PageId = _003C_003Ec__DisplayClass8_.model.PageId;
				CS_0024_003C_003E8__locals0.vm.RegisterDate = _003C_003Ec__DisplayClass8_.model.RegisterDate;
				CS_0024_003C_003E8__locals0.vm.UserId = _003C_003Ec__DisplayClass8_.model.UserId;
				CS_0024_003C_003E8__locals0.vm.FirstRegisterDate = _003C_003Ec__DisplayClass8_.model.FirstRegisterDate;
				CS_0024_003C_003E8__locals0.vm.FirstRegisterUserId = _003C_003Ec__DisplayClass8_.model.FirstRegisterUserId;
				CRMspCmsSelectPages_Result cRMspCmsSelectPages_Result = Enumerable.FirstOrDefault<CRMspCmsSelectPages_Result>((IEnumerable<CRMspCmsSelectPages_Result>)_db.CRMspCmsSelectPages(CS_0024_003C_003E8__locals0.vm.PageId, lCID, CS_0024_003C_003E8__locals0.defLangID));
				new CRMspCmsSelectPages_Result();
				if (cRMspCmsSelectPages_Result != null)
				{
					CrmCmsPagesLanguageViewModel vm2 = CS_0024_003C_003E8__locals0.vm;
					_ = cRMspCmsSelectPages_Result.FirstRegisterDate;
					vm2.FirstRegisterDatePersian = cRMspCmsSelectPages_Result.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
					CrmCmsPagesLanguageViewModel vm3 = CS_0024_003C_003E8__locals0.vm;
					_ = cRMspCmsSelectPages_Result.RegisterDate;
					vm3.RegisterDatePersian = cRMspCmsSelectPages_Result.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
					if (string.IsNullOrEmpty(cRMspCmsSelectPages_Result.AppType))
					{
						cRMspCmsSelectPages_Result.AppType = Configuration.AppType;
					}
					CS_0024_003C_003E8__locals0.vm.AppType = Configuration.GetAppType(cRMspCmsSelectPages_Result.AppType);
					CS_0024_003C_003E8__locals0.vm.FirstRegisterUser = cRMspCmsSelectPages_Result.FirstRegisterUser ?? "";
					CS_0024_003C_003E8__locals0.vm.EditUser = cRMspCmsSelectPages_Result.EditUser + "(" + Labels.AppType + ":" + CS_0024_003C_003E8__locals0.vm.AppType + ")";
					cRMspCmsSelectPages_Result.FirstRegisterDatePersian = CS_0024_003C_003E8__locals0.vm.FirstRegisterDatePersian;
					cRMspCmsSelectPages_Result.RegisterDatePersian = CS_0024_003C_003E8__locals0.vm.RegisterDatePersian;
					cRMspCmsSelectPages_Result.FirstRegisterUser = CS_0024_003C_003E8__locals0.vm.FirstRegisterUser;
					cRMspCmsSelectPages_Result.EditUser = CS_0024_003C_003E8__locals0.vm.EditUser;
				}
				new FilesManager();
				new FacadeFTP(Configuration.FacadeFtpFo);
				string pathFtpFo = Configuration.PathFtpFo;
				string userNameFtpFo = Configuration.UserNameFtpFo;
				string passwordFtpFo = Configuration.PasswordFtpFo;
				bool usePassiveFtpFo = Configuration.UsePassiveFtpFo;
				if (!string.IsNullOrEmpty(pathFtpFo) && !string.IsNullOrEmpty(userNameFtpFo) && !string.IsNullOrEmpty(passwordFtpFo))
				{
					try
					{
						if (list3 != null)
						{
							Files.UploadPicFromEditorToFtp(pathFtpFo, userNameFtpFo, passwordFtpFo, usePassiveFtpFo, list3);
						}
						if (list4 != null)
						{
							Files.UploadPicFromEditorToFtp(pathFtpFo, userNameFtpFo, passwordFtpFo, usePassiveFtpFo, list4);
						}
						if (list5 != null)
						{
							Files.UploadPicFromEditorToFtp(pathFtpFo, userNameFtpFo, passwordFtpFo, usePassiveFtpFo, list5);
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
					}
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

	public List<CommonMultiLanguageViewModel> GetLanguagesList()
	{
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
			foreach (Languages item in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages x) => x.LanguageID != currLangID))))
			{
				list.Add(new CommonMultiLanguageViewModel
				{
					LanguageId = item.LanguageID,
					Value = ""
				});
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.LangsListJs = JsonConvert.SerializeObject(list);
		return list;
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
			List<CRMspCmsSelectDyFormsForPages_Result> list2 = Enumerable.ToList<CRMspCmsSelectDyFormsForPages_Result>((IEnumerable<CRMspCmsSelectDyFormsForPages_Result>)_db.CRMspCmsSelectDyFormsForPages(UserLogin.CurrentUser.UserId, 105, lCID, result));
			list.AddRange(Enumerable.Select<CRMspCmsSelectDyFormsForPages_Result, SelectListItem>((IEnumerable<CRMspCmsSelectDyFormsForPages_Result>)Enumerable.ToList<CRMspCmsSelectDyFormsForPages_Result>((IEnumerable<CRMspCmsSelectDyFormsForPages_Result>)list2), (Func<CRMspCmsSelectDyFormsForPages_Result, SelectListItem>)((CRMspCmsSelectDyFormsForPages_Result i) => new SelectListItem
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
	public JsonResult GetPageLocation()
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
				Text = Labels.CmsPageLocationInBoth,
				Value = "0",
				Selected = false
			};
			list.Add(item);
			item = new SelectListItem
			{
				Text = Labels.CmsPageLocationInFo,
				Value = "1",
				Selected = false
			};
			list.Add(item);
			item = new SelectListItem
			{
				Text = Labels.CmsPageLocationInShop,
				Value = "2",
				Selected = false
			};
			list.Add(item);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PageLocationList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetLayoutType()
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
				Text = Labels.CmsLayoutTypeFo,
				Value = "1",
				Selected = false
			};
			list.Add(item);
			item = new SelectListItem
			{
				Text = Labels.CmsLayoutTypeShop,
				Value = "2",
				Selected = false
			};
			list.Add(item);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.LayoutTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmCmsDefinePage", ActionName = "actDelete")]
	public string DeletePage(int pageId)
	{
		_003C_003Ec__DisplayClass15_0 _003C_003Ec__DisplayClass15_ = new _003C_003Ec__DisplayClass15_0();
		_003C_003Ec__DisplayClass15_.pageId = pageId;
		string result = "";
		try
		{
			DbSet<CrmCmsPages> crmCmsPages = _dbTbl.CrmCmsPages;
			ParameterExpression val = Expression.Parameter(typeof(CrmCmsPages), "c");
			if (Queryable.FirstOrDefault<CrmCmsPages>((IQueryable<CrmCmsPages>)crmCmsPages, Expression.Lambda<Func<CrmCmsPages, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass15_, typeof(_003C_003Ec__DisplayClass15_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
			{
				try
				{
					int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
					if (result2 <= 0)
					{
						result2 = 1065;
					}
					_ = Thread.CurrentThread.CurrentCulture.LCID;
					_db.CRMspDyDeleteFormFieldMasterValuesBySysPart(_003C_003Ec__DisplayClass15_.pageId, "cms");
					mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspCmsDeletePage(_003C_003Ec__DisplayClass15_.pageId));
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

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		base.Dispose(disposing);
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Calendar;
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
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Cms.Controllers;

public class HomePageSectionsController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass12_0
	{
		public int hpSectionId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass13_0
	{
		public int hpSectionItemId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass17_0
	{
		public CrmCmsHomePageSectionItemsLanguageViewModel vm;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public int hpSectionCurrentId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public CrmCmsHomePageSectionsLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__19;

		public Func<Languages, bool> _003C_003E9__53;

		internal bool _003CInsertEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

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

		internal bool _003CInsertEdit_003Eb__19(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__53(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_1
	{
		public CrmCmsHomePageSections model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass9_1 CS_0024_003C_003E8__locals1;

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
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actcmsManageHomePageSection")]
	public ActionResult Index()
	{
		return View();
	}

	[AjaxOnly]
	public ActionResult _PartialHomePageSectionTree()
	{
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
			List<CRMspCmsSelectHomePageSections_Result> list = Enumerable.ToList<CRMspCmsSelectHomePageSections_Result>((IEnumerable<CRMspCmsSelectHomePageSections_Result>)_db.CRMspCmsSelectHomePageSections(0, lCID, result, result2));
			List<TreeViewItemModel> list2 = new List<TreeViewItemModel>();
			if (Enumerable.Any<CRMspCmsSelectHomePageSections_Result>((IEnumerable<CRMspCmsSelectHomePageSections_Result>)list))
			{
				foreach (CRMspCmsSelectHomePageSections_Result item in list)
				{
					TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
					treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.HomePageSectionId.ToString()));
					treeViewItemModel.Id = item.HomePageSectionId.ToString();
					treeViewItemModel.Text = item.SectionTitle;
					treeViewItemModel.ImageUrl = "";
					treeViewItemModel.Items = null;
					list2.Add(treeViewItemModel);
				}
			}
			base.ViewBag.HomePageSectionTree = list2;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView();
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actcmsManageHomePageSection")]
	public JsonResult GetHomePageSection(int hpSectionCurrentId)
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
		CurrentHomePageSectionViewModel currentHomePageSectionViewModel = new CurrentHomePageSectionViewModel();
		try
		{
			CRMspCmsSelectHomePageSections_Result cRMspCmsSelectHomePageSections_Result = Enumerable.FirstOrDefault<CRMspCmsSelectHomePageSections_Result>((IEnumerable<CRMspCmsSelectHomePageSections_Result>)_db.CRMspCmsSelectHomePageSections(hpSectionCurrentId, lCID, result, result2));
			if (cRMspCmsSelectHomePageSections_Result != null)
			{
				currentHomePageSectionViewModel.IsFind = true;
				currentHomePageSectionViewModel.Message = "";
				currentHomePageSectionViewModel.HomePageSection = cRMspCmsSelectHomePageSections_Result;
				currentHomePageSectionViewModel.HomePageSectionCurrentId = cRMspCmsSelectHomePageSections_Result.HomePageSectionId;
				_ = cRMspCmsSelectHomePageSections_Result.FirstRegisterDate;
				cRMspCmsSelectHomePageSections_Result.FirstRegisterDatePersian = cRMspCmsSelectHomePageSections_Result.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				cRMspCmsSelectHomePageSections_Result.FirstRegisterUser += ((!string.IsNullOrEmpty(cRMspCmsSelectHomePageSections_Result.FirstRegisterDatePersian)) ? (" (" + cRMspCmsSelectHomePageSections_Result.FirstRegisterDatePersian + ")") : "");
				_ = cRMspCmsSelectHomePageSections_Result.RegisterDate;
				cRMspCmsSelectHomePageSections_Result.RegisterDatePersian = cRMspCmsSelectHomePageSections_Result.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				if (string.IsNullOrEmpty(cRMspCmsSelectHomePageSections_Result.AppType))
				{
					cRMspCmsSelectHomePageSections_Result.AppType = Configuration.AppType;
				}
				cRMspCmsSelectHomePageSections_Result.AppType = Configuration.GetAppType(cRMspCmsSelectHomePageSections_Result.AppType);
				cRMspCmsSelectHomePageSections_Result.EditUser = cRMspCmsSelectHomePageSections_Result.EditUser + "(" + Labels.AppType + ":" + cRMspCmsSelectHomePageSections_Result.AppType + ")" + ((!string.IsNullOrEmpty(cRMspCmsSelectHomePageSections_Result.RegisterDatePersian)) ? (" (" + cRMspCmsSelectHomePageSections_Result.RegisterDatePersian + ")") : "");
			}
			else
			{
				currentHomePageSectionViewModel.IsFind = false;
				currentHomePageSectionViewModel.Message = Messages.ErrorNotFound;
				currentHomePageSectionViewModel.HomePageSection = null;
				currentHomePageSectionViewModel.HomePageSectionCurrentId = -1;
			}
		}
		catch (DbEntityValidationException ex)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
			currentHomePageSectionViewModel.Message = Messages.frmErrorMessage + "<br />" + ((Exception)(object)ex).Message;
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			currentHomePageSectionViewModel.Message = Messages.frmErrorMessage + "<br />" + ex2.Message;
		}
		JsonResult jsonResult = Json(currentHomePageSectionViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public ActionResult HomePageSectionItem_Read([DataSourceRequest] DataSourceRequest request, int hpSectionCurrentId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspCmsSelectHomePageSectionItemsBySectionId_Result> list = new List<CRMspCmsSelectHomePageSectionItemsBySectionId_Result>();
		try
		{
			list = Enumerable.ToList<CRMspCmsSelectHomePageSectionItemsBySectionId_Result>((IEnumerable<CRMspCmsSelectHomePageSectionItemsBySectionId_Result>)_db.CRMspCmsSelectHomePageSectionItemsBySectionId(hpSectionCurrentId, lCID, result));
			foreach (CRMspCmsSelectHomePageSectionItemsBySectionId_Result item in list)
			{
				item.AppType = (item.SectionItemShowExpDate.HasValue ? item.SectionItemShowExpDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : null);
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

	[DynamicAuthorize(ControllerName = "frmCmsManageHomePageSection", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(int hpSectionCurrentId = 0)
	{
		_003C_003Ec__DisplayClass8_0 _003C_003Ec__DisplayClass8_ = new _003C_003Ec__DisplayClass8_0();
		_003C_003Ec__DisplayClass8_.hpSectionCurrentId = hpSectionCurrentId;
		CrmCmsHomePageSectionsLanguageViewModel crmCmsHomePageSectionsLanguageViewModel = new CrmCmsHomePageSectionsLanguageViewModel();
		try
		{
			BaseInfo baseInfo = new BaseInfo();
			CrmCmsHomePageSections crmCmsHomePageSections = new CrmCmsHomePageSections();
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (_003C_003Ec__DisplayClass8_.hpSectionCurrentId > 0)
			{
				if (!UserLogin.IsUserAccess("frmCmsManageHomePageSection", "actEdit"))
				{
					base.ViewBag.Error = Messages.NotAccessToPage;
					return null;
				}
				DbSet<CrmCmsHomePageSections_Lang> crmCmsHomePageSections_Lang = _dbTbl.CrmCmsHomePageSections_Lang;
				ParameterExpression val = Expression.Parameter(typeof(CrmCmsHomePageSections_Lang), "c");
				List<CrmCmsHomePageSections_Lang> list = Enumerable.ToList<CrmCmsHomePageSections_Lang>((IEnumerable<CrmCmsHomePageSections_Lang>)Queryable.Where<CrmCmsHomePageSections_Lang>((IQueryable<CrmCmsHomePageSections_Lang>)crmCmsHomePageSections_Lang, Expression.Lambda<Func<CrmCmsHomePageSections_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass8_, typeof(_003C_003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				DbSet<CrmCmsHomePageSections> crmCmsHomePageSections2 = _dbTbl.CrmCmsHomePageSections;
				val = Expression.Parameter(typeof(CrmCmsHomePageSections), "c");
				crmCmsHomePageSections = Queryable.FirstOrDefault<CrmCmsHomePageSections>((IQueryable<CrmCmsHomePageSections>)crmCmsHomePageSections2, Expression.Lambda<Func<CrmCmsHomePageSections, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass8_, typeof(_003C_003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (crmCmsHomePageSections == null)
				{
					base.ViewBag.Error = Messages.ErrorNotFound;
					return null;
				}
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsHomePageSections_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsHomePageSections_Lang>)list, (Func<CrmCmsHomePageSections_Lang, CommonMultiLanguageViewModel>)((CrmCmsHomePageSections_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.SectionTitle,
					LanguageId = item.LanguageID
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCmsHomePageSections.SectionTitle,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsHomePageSections_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsHomePageSections_Lang>)list, (Func<CrmCmsHomePageSections_Lang, CommonMultiLanguageViewModel>)((CrmCmsHomePageSections_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.SectionHeader,
					LanguageId = item.LanguageID
				})));
				list3.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCmsHomePageSections.SectionHeader,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsHomePageSections_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsHomePageSections_Lang>)list, (Func<CrmCmsHomePageSections_Lang, CommonMultiLanguageViewModel>)((CrmCmsHomePageSections_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.SectionSeoTitle,
					LanguageId = item.LanguageID
				})));
				list4.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCmsHomePageSections.SectionSeoTitle,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list5 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsHomePageSections_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsHomePageSections_Lang>)list, (Func<CrmCmsHomePageSections_Lang, CommonMultiLanguageViewModel>)((CrmCmsHomePageSections_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.SectionSeoDescription,
					LanguageId = item.LanguageID
				})));
				list5.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCmsHomePageSections.SectionSeoDescription,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list6 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsHomePageSections_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsHomePageSections_Lang>)list, (Func<CrmCmsHomePageSections_Lang, CommonMultiLanguageViewModel>)((CrmCmsHomePageSections_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.SectionSeoAuthor,
					LanguageId = item.LanguageID
				})));
				list6.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCmsHomePageSections.SectionSeoAuthor,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list7 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsHomePageSections_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsHomePageSections_Lang>)list, (Func<CrmCmsHomePageSections_Lang, CommonMultiLanguageViewModel>)((CrmCmsHomePageSections_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.SectionSeoCopyright,
					LanguageId = item.LanguageID
				})));
				list7.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCmsHomePageSections.SectionSeoCopyright,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list8 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsHomePageSections_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsHomePageSections_Lang>)list, (Func<CrmCmsHomePageSections_Lang, CommonMultiLanguageViewModel>)((CrmCmsHomePageSections_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.SectionSeoKeywords,
					LanguageId = item.LanguageID
				})));
				list8.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCmsHomePageSections.SectionSeoKeywords,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list9 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsHomePageSections_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsHomePageSections_Lang>)list, (Func<CrmCmsHomePageSections_Lang, CommonMultiLanguageViewModel>)((CrmCmsHomePageSections_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.SectionSeoFAQ,
					LanguageId = item.LanguageID
				})));
				list9.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCmsHomePageSections.SectionSeoFAQ,
					LanguageId = result
				});
				crmCmsHomePageSectionsLanguageViewModel = new CrmCmsHomePageSectionsLanguageViewModel
				{
					HomePageSectionId = crmCmsHomePageSections.HomePageSectionId,
					SectionTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
					SectionTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
					SectionHeader = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
					SectionHeader_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
					SectionHeaderStyle = crmCmsHomePageSections.SectionHeaderStyle,
					SectionHeaderScript = crmCmsHomePageSections.SectionHeaderScript,
					SectionHeaderPosition = crmCmsHomePageSections.SectionHeaderPosition,
					SectionBgColor = baseInfo.DelphiCToRgbolor(crmCmsHomePageSections.SectionBgColor),
					SectionIsActive = crmCmsHomePageSections.SectionIsActive,
					SectionOrderView = crmCmsHomePageSections.SectionOrderView,
					SectionSeoIsActive = crmCmsHomePageSections.SectionSeoIsActive,
					SectionSeoTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
					SectionSeoDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
					SectionSeoHttpEquiv = crmCmsHomePageSections.SectionSeoHttpEquiv,
					SectionSeoExpires = crmCmsHomePageSections.SectionSeoExpires,
					SectionSeoGoogleNotranslate = crmCmsHomePageSections.SectionSeoGoogleNotranslate,
					SectionSeoDistribution = crmCmsHomePageSections.SectionSeoDistribution,
					SectionSeoRobots = crmCmsHomePageSections.SectionSeoRobots,
					SectionSeoRating = crmCmsHomePageSections.SectionSeoRating,
					SectionSeoAuthor = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
					SectionSeoIsUseSocialNetwork = crmCmsHomePageSections.SectionSeoIsUseSocialNetwork,
					SectionSeoMobileOptimized = crmCmsHomePageSections.SectionSeoMobileOptimized,
					SectionSeoCopyright = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
					SectionSeoUseDefault = crmCmsHomePageSections.SectionSeoUseDefault,
					SectionSeoKeywords = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
					SectionSeoFAQ = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
					SectionSeoTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
					SectionSeoDescription_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
					SectionSeoAuthor_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
					SectionSeoCopyright_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
					SectionSeoKeywords_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
					SectionSeoFAQ_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))))
				};
			}
			else
			{
				if (!UserLogin.IsUserAccess("frmCmsManageHomePageSection", "actInsert"))
				{
					base.ViewBag.Error = Messages.NotAccessToPage;
					return null;
				}
				_ = DateTime.Now;
				crmCmsHomePageSectionsLanguageViewModel = new CrmCmsHomePageSectionsLanguageViewModel
				{
					SectionIsActive = true
				};
				if (crmCmsHomePageSectionsLanguageViewModel.SectionOrderView.GetValueOrDefault() <= 0)
				{
					List<CRMspCmsSelectHomePageSections_Result> list10 = Enumerable.ToList<CRMspCmsSelectHomePageSections_Result>((IEnumerable<CRMspCmsSelectHomePageSections_Result>)_db.CRMspCmsSelectHomePageSections(0, currLangID, result, result2));
					_ = Enumerable.FirstOrDefault<CRMspCmsSelectHomePageSections_Result>((IEnumerable<CRMspCmsSelectHomePageSections_Result>)Enumerable.OrderByDescending<CRMspCmsSelectHomePageSections_Result, int?>((IEnumerable<CRMspCmsSelectHomePageSections_Result>)list10, (Func<CRMspCmsSelectHomePageSections_Result, int?>)((CRMspCmsSelectHomePageSections_Result m) => m.SectionOrderView)))?.SectionOrderView;
					int num = (Enumerable.Any<CRMspCmsSelectHomePageSections_Result>((IEnumerable<CRMspCmsSelectHomePageSections_Result>)list10) ? Enumerable.Count<CRMspCmsSelectHomePageSections_Result>((IEnumerable<CRMspCmsSelectHomePageSections_Result>)list10) : 0);
					crmCmsHomePageSectionsLanguageViewModel.SectionOrderView = num + 10 + num * 9 - 5;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		GetSectionHeaderPosition();
		return View(crmCmsHomePageSectionsLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmCmsManageHomePageSectionDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult InsertEdit(CrmCmsHomePageSectionsLanguageViewModel vm)
	{
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_0296: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_033e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0392: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e6: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass9_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		GetSectionHeaderPosition();
		try
		{
			_003C_003Ec__DisplayClass9_1 _003C_003Ec__DisplayClass9_ = new _003C_003Ec__DisplayClass9_1();
			int? num = null;
			if (UserLogin.CurrentUser != null)
			{
				num = UserLogin.CurrentUser.UserLastCId;
			}
			_003C_003Ec__DisplayClass9_.model = new CrmCmsHomePageSections();
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.SectionTitle_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.SectionTitle_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.SectionTitle,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.SectionHeader_Lang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.SectionHeader_Lang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.SectionHeader,
				LanguageId = lCID
			});
			_ = CRMIdeal.Cache.Setting.Language.Get().Count;
			string text = "";
			int num2 = 0;
			if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.SectionTitle))
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.CmsHomePageSectionTitle) + "<br/>";
				num2++;
			}
			else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.SectionTitle, list))
			{
				text = text + string.Format(Messages.CheckFieldInLang, Labels.CmsHomePageSectionTitle) + "<br>";
				num2++;
			}
			if (num2 > 0)
			{
				base.ViewBag.Error = text;
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.SectionSeoTitle_Lang))
			{
				list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.SectionSeoTitle_Lang);
			}
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.SectionSeoTitle,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.SectionSeoDescription_Lang))
			{
				list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.SectionSeoDescription_Lang);
			}
			list4.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.SectionSeoDescription,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.SectionSeoAuthor_Lang))
			{
				list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.SectionSeoAuthor_Lang);
			}
			list5.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.SectionSeoAuthor,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.SectionSeoCopyright_Lang))
			{
				list6 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.SectionSeoCopyright_Lang);
			}
			list6.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.SectionSeoCopyright,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list7 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.SectionSeoKeywords_Lang))
			{
				list7 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.SectionSeoKeywords_Lang);
			}
			list7.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.SectionSeoKeywords,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list8 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.SectionSeoFAQ_Lang))
			{
				list8 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.SectionSeoFAQ_Lang);
			}
			list8.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.SectionSeoFAQ,
				LanguageId = lCID
			});
			BaseInfo baseInfo = new BaseInfo();
			if (base.ModelState.IsValid)
			{
				_003C_003Ec__DisplayClass9_.model = new CrmCmsHomePageSections();
				if (CS_0024_003C_003E8__locals0.vm.HomePageSectionId > 0)
				{
					DbSet<CrmCmsHomePageSections> crmCmsHomePageSections = _dbTbl.CrmCmsHomePageSections;
					ParameterExpression val = Expression.Parameter(typeof(CrmCmsHomePageSections), "c");
					_003C_003Ec__DisplayClass9_.model = Queryable.FirstOrDefault<CrmCmsHomePageSections>((IQueryable<CrmCmsHomePageSections>)crmCmsHomePageSections, Expression.Lambda<Func<CrmCmsHomePageSections, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass9_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				_003C_003Ec__DisplayClass9_.model.UserId = UserLogin.CurrentUser.UserId;
				DateTime now = DateTime.Now;
				_003C_003Ec__DisplayClass9_.model.RegisterDate = now;
				_003C_003Ec__DisplayClass9_.model.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				_003C_003Ec__DisplayClass9_.model.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
				_003C_003Ec__DisplayClass9_.model.AppType = Configuration.AppType;
				_003C_003Ec__DisplayClass9_.model.Year1 = short.Parse(Financial.Get().Id.ToString());
				_003C_003Ec__DisplayClass9_.model.SectionTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass9_.model.SectionHeader = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass9_.model.SectionHeaderStyle = CS_0024_003C_003E8__locals0.vm.SectionHeaderStyle;
				_003C_003Ec__DisplayClass9_.model.SectionHeaderScript = CS_0024_003C_003E8__locals0.vm.SectionHeaderScript;
				_003C_003Ec__DisplayClass9_.model.SectionHeaderPosition = CS_0024_003C_003E8__locals0.vm.SectionHeaderPosition;
				_003C_003Ec__DisplayClass9_.model.SectionBgColor = baseInfo.RgbToDelphiColor(CS_0024_003C_003E8__locals0.vm.SectionBgColor);
				_003C_003Ec__DisplayClass9_.model.SectionIsActive = CS_0024_003C_003E8__locals0.vm.SectionIsActive;
				_003C_003Ec__DisplayClass9_.model.SectionOrderView = CS_0024_003C_003E8__locals0.vm.SectionOrderView;
				_003C_003Ec__DisplayClass9_.model.SectionSeoIsActive = CS_0024_003C_003E8__locals0.vm.SectionSeoIsActive;
				_003C_003Ec__DisplayClass9_.model.SectionSeoTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass9_.model.SectionSeoDescription = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass9_.model.SectionSeoHttpEquiv = CS_0024_003C_003E8__locals0.vm.SectionSeoHttpEquiv;
				_003C_003Ec__DisplayClass9_.model.SectionSeoExpires = CS_0024_003C_003E8__locals0.vm.SectionSeoExpires;
				_003C_003Ec__DisplayClass9_.model.SectionSeoGoogleNotranslate = CS_0024_003C_003E8__locals0.vm.SectionSeoGoogleNotranslate;
				_003C_003Ec__DisplayClass9_.model.SectionSeoDistribution = CS_0024_003C_003E8__locals0.vm.SectionSeoDistribution;
				_003C_003Ec__DisplayClass9_.model.SectionSeoRobots = CS_0024_003C_003E8__locals0.vm.SectionSeoRobots;
				_003C_003Ec__DisplayClass9_.model.SectionSeoRating = CS_0024_003C_003E8__locals0.vm.SectionSeoRating;
				_003C_003Ec__DisplayClass9_.model.SectionSeoAuthor = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass9_.model.SectionSeoIsUseSocialNetwork = CS_0024_003C_003E8__locals0.vm.SectionSeoIsUseSocialNetwork;
				_003C_003Ec__DisplayClass9_.model.SectionSeoMobileOptimized = CS_0024_003C_003E8__locals0.vm.SectionSeoMobileOptimized;
				_003C_003Ec__DisplayClass9_.model.SectionSeoCopyright = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass9_.model.SectionSeoUseDefault = CS_0024_003C_003E8__locals0.vm.SectionSeoUseDefault;
				_003C_003Ec__DisplayClass9_.model.SectionSeoKeywords = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass9_.model.SectionSeoFAQ = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				if (_003C_003Ec__DisplayClass9_.model.HomePageSectionId > 0)
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
							DbSet<CrmCmsHomePageSections_Lang> crmCmsHomePageSections_Lang = _dbTbl.CrmCmsHomePageSections_Lang;
							ParameterExpression val = Expression.Parameter(typeof(CrmCmsHomePageSections_Lang), "c");
							CrmCmsHomePageSections_Lang crmCmsHomePageSections_Lang2 = Queryable.FirstOrDefault<CrmCmsHomePageSections_Lang>((IQueryable<CrmCmsHomePageSections_Lang>)crmCmsHomePageSections_Lang, Expression.Lambda<Func<CrmCmsHomePageSections_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass9_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass9_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (crmCmsHomePageSections_Lang2 != null)
							{
								crmCmsHomePageSections_Lang2.SectionTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmCmsHomePageSections_Lang2.SectionHeader = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmCmsHomePageSections_Lang2.SectionSeoTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmCmsHomePageSections_Lang2.SectionSeoDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmCmsHomePageSections_Lang2.SectionSeoAuthor = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmCmsHomePageSections_Lang2.SectionSeoCopyright = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmCmsHomePageSections_Lang2.SectionSeoKeywords = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmCmsHomePageSections_Lang2.SectionSeoFAQ = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(crmCmsHomePageSections_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							crmCmsHomePageSections_Lang2 = new CrmCmsHomePageSections_Lang();
							crmCmsHomePageSections_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
							crmCmsHomePageSections_Lang2.HomePageSectionId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.HomePageSectionId;
							crmCmsHomePageSections_Lang2.SectionTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							crmCmsHomePageSections_Lang2.SectionHeader = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							crmCmsHomePageSections_Lang2.SectionSeoTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							crmCmsHomePageSections_Lang2.SectionSeoDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							crmCmsHomePageSections_Lang2.SectionSeoAuthor = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							crmCmsHomePageSections_Lang2.SectionSeoCopyright = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							crmCmsHomePageSections_Lang2.SectionSeoKeywords = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							crmCmsHomePageSections_Lang2.SectionSeoFAQ = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							_dbTbl.CrmCmsHomePageSections_Lang.Add(crmCmsHomePageSections_Lang2);
							_dbTbl.SaveChanges();
						}
					}
					text = Messages.frmFormBaseEditSuccessFulMessage;
				}
				else
				{
					_003C_003Ec__DisplayClass9_.model.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
					_003C_003Ec__DisplayClass9_.model.FirstRegisterDate = now;
					_003C_003Ec__DisplayClass9_.model.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					_003C_003Ec__DisplayClass9_.model.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
					_003C_003Ec__DisplayClass9_.model.GUId = Guid.NewGuid();
					_003C_003Ec__DisplayClass9_.model.SectionCId = ((num != 0) ? num : null);
					_dbTbl.CrmCmsHomePageSections.Add(_003C_003Ec__DisplayClass9_.model);
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
					{
						CrmCmsHomePageSections_Lang crmCmsHomePageSections_Lang3 = new CrmCmsHomePageSections_Lang();
						crmCmsHomePageSections_Lang3.LanguageID = lang.LanguageID;
						crmCmsHomePageSections_Lang3.HomePageSectionId = _003C_003Ec__DisplayClass9_.model.HomePageSectionId;
						crmCmsHomePageSections_Lang3.SectionTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmCmsHomePageSections_Lang3.SectionHeader = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmCmsHomePageSections_Lang3.SectionSeoTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmCmsHomePageSections_Lang3.SectionSeoDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmCmsHomePageSections_Lang3.SectionSeoAuthor = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmCmsHomePageSections_Lang3.SectionSeoCopyright = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmCmsHomePageSections_Lang3.SectionSeoKeywords = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmCmsHomePageSections_Lang3.SectionSeoFAQ = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						_dbTbl.CrmCmsHomePageSections_Lang.Add(crmCmsHomePageSections_Lang3);
						_dbTbl.SaveChanges();
					}
					text = Messages.frmFormBaseInsertSuccessFulMessage;
				}
				CS_0024_003C_003E8__locals0.vm.HomePageSectionId = _003C_003Ec__DisplayClass9_.model.HomePageSectionId;
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
						if (list2 != null)
						{
							Files.UploadPicFromEditorToFtp(pathFtpFo, userNameFtpFo, passwordFtpFo, usePassiveFtpFo, list2);
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

	[AjaxOnly]
	public JsonResult GetSectionHeaderPosition()
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
				Text = Labels.CmsHomePageSectionHeaderPositionTop,
				Value = "Top",
				Selected = false
			};
			list.Add(item);
			item = new SelectListItem
			{
				Text = Labels.CmsHomePageSectionHeaderPositionRight,
				Value = "Right",
				Selected = false
			};
			list.Add(item);
			item = new SelectListItem
			{
				Text = Labels.CmsHomePageSectionHeaderPositionLeft,
				Value = "Left",
				Selected = false
			};
			list.Add(item);
			item = new SelectListItem
			{
				Text = Labels.CmsHomePageSectionHeaderPositionBottom,
				Value = "Bottom",
				Selected = false
			};
			list.Add(item);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.SectionHeaderPositionList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
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
	[DynamicAuthorize(ControllerName = "frmCmsManageHomePageSection", ActionName = "actDelete")]
	public string DeleteHomePageSection(int hpSectionId)
	{
		_003C_003Ec__DisplayClass12_0 _003C_003Ec__DisplayClass12_ = new _003C_003Ec__DisplayClass12_0();
		_003C_003Ec__DisplayClass12_.hpSectionId = hpSectionId;
		string result = "";
		try
		{
			DbSet<CrmCmsHomePageSections> crmCmsHomePageSections = _dbTbl.CrmCmsHomePageSections;
			ParameterExpression val = Expression.Parameter(typeof(CrmCmsHomePageSections), "c");
			if (Queryable.FirstOrDefault<CrmCmsHomePageSections>((IQueryable<CrmCmsHomePageSections>)crmCmsHomePageSections, Expression.Lambda<Func<CrmCmsHomePageSections, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass12_, typeof(_003C_003Ec__DisplayClass12_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
			{
				try
				{
					int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
					if (result2 <= 0)
					{
						result2 = 1065;
					}
					_ = Thread.CurrentThread.CurrentCulture.LCID;
					mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspCmsDeleteHomePageSection(_003C_003Ec__DisplayClass12_.hpSectionId));
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
	[DynamicAuthorize(ControllerName = "frmCmsManageHomePageSection", ActionName = "actDeleteItem")]
	public string DeleteProduct(int hpSectionItemId)
	{
		_003C_003Ec__DisplayClass13_0 _003C_003Ec__DisplayClass13_ = new _003C_003Ec__DisplayClass13_0();
		_003C_003Ec__DisplayClass13_.hpSectionItemId = hpSectionItemId;
		string result = "";
		try
		{
			DbSet<CrmCmsHomePageSectionItems> crmCmsHomePageSectionItems = _dbTbl.CrmCmsHomePageSectionItems;
			ParameterExpression val = Expression.Parameter(typeof(CrmCmsHomePageSectionItems), "c");
			if (Queryable.FirstOrDefault<CrmCmsHomePageSectionItems>((IQueryable<CrmCmsHomePageSectionItems>)crmCmsHomePageSectionItems, Expression.Lambda<Func<CrmCmsHomePageSectionItems, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass13_, typeof(_003C_003Ec__DisplayClass13_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
			{
				try
				{
					int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
					if (result2 <= 0)
					{
						result2 = 1065;
					}
					_ = Thread.CurrentThread.CurrentCulture.LCID;
					mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspCmsDeleteHomePageSectionItem(_003C_003Ec__DisplayClass13_.hpSectionItemId));
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
	[DynamicAuthorize(ControllerName = "frmCmsManageHomePageSection", ActionName = "actDeleteAllItems")]
	public string DeleteAllProducts(int hpSectionId)
	{
		string result = "";
		try
		{
			if (hpSectionId > 0)
			{
				try
				{
					int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
					if (result2 <= 0)
					{
						result2 = 1065;
					}
					_ = Thread.CurrentThread.CurrentCulture.LCID;
					mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspCmsDeleteHomePageSectionItemsBySectionId(hpSectionId));
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

	public void SetHpSecItemRegisterInfo(CrmCmsHomePageSectionItemsLanguageViewModel model, ref string firstRegInfo, ref string regInfo)
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
			CRMspSelectUsersById_Result cRMspSelectUsersById_Result = CRMIdeal.Classes.Helper.User.SelectUsersById(model.FirstRegisterUserId);
			if (cRMspSelectUsersById_Result != null)
			{
				firstRegInfo = ((!string.IsNullOrEmpty(cRMspSelectUsersById_Result.LName)) ? cRMspSelectUsersById_Result.LName : "") + ((!string.IsNullOrEmpty(cRMspSelectUsersById_Result.FName)) ? (" " + cRMspSelectUsersById_Result.FName) : "");
				_ = model.FirstRegisterDate;
				string text = model.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				firstRegInfo += ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			}
			CRMspSelectUsersById_Result cRMspSelectUsersById_Result2 = CRMIdeal.Classes.Helper.User.SelectUsersById(model.UserId);
			if (cRMspSelectUsersById_Result2 != null)
			{
				regInfo = ((!string.IsNullOrEmpty(cRMspSelectUsersById_Result2.LName)) ? cRMspSelectUsersById_Result2.LName : "") + ((!string.IsNullOrEmpty(cRMspSelectUsersById_Result2.FName)) ? (" " + cRMspSelectUsersById_Result2.FName) : "");
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

	[DynamicAuthorize(ControllerName = "frmCmsManageHomePageSection", ActionName = "actAddItem,actEditItem")]
	public ActionResult InsertEditItem(int hpSectionId, int hpSectionItemId = 0)
	{
		CrmCmsHomePageSectionItemsLanguageViewModel crmCmsHomePageSectionItemsLanguageViewModel = new CrmCmsHomePageSectionItemsLanguageViewModel();
		GetSectionItemLinkType();
		try
		{
			new BaseInfo();
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			GetSystemParts();
			base.ViewBag.PrdFirstGroupsJson = GetProductFirstGroups_Json();
			if (hpSectionItemId > 0)
			{
				if (!UserLogin.IsUserAccess("frmCmsManageHomePageSection", "actEditItem"))
				{
					base.ViewBag.Error = Messages.NotAccessToPage;
					return null;
				}
				CRMspCmsSelectHomePageSectionItemsById_Result cRMspCmsSelectHomePageSectionItemsById_Result = Enumerable.FirstOrDefault<CRMspCmsSelectHomePageSectionItemsById_Result>((IEnumerable<CRMspCmsSelectHomePageSectionItemsById_Result>)_db.CRMspCmsSelectHomePageSectionItemsById(hpSectionItemId, lCID, result));
				if (cRMspCmsSelectHomePageSectionItemsById_Result == null)
				{
					base.ViewBag.Error = Messages.ErrorNotFound;
					return null;
				}
				crmCmsHomePageSectionItemsLanguageViewModel = new CrmCmsHomePageSectionItemsLanguageViewModel
				{
					HomePageSectionId = cRMspCmsSelectHomePageSectionItemsById_Result.HomePageSectionId,
					HomePageSectionItemId = cRMspCmsSelectHomePageSectionItemsById_Result.HomePageSectionItemId,
					SectionItemPrdId = cRMspCmsSelectHomePageSectionItemsById_Result.SectionItemPrdId,
					SectionItemPrdName = cRMspCmsSelectHomePageSectionItemsById_Result.SectionItemPrd,
					SectionItemShowExpDateTime = cRMspCmsSelectHomePageSectionItemsById_Result.SectionItemShowExpDate,
					SectionItemShowExpDate = (cRMspCmsSelectHomePageSectionItemsById_Result.SectionItemShowExpDate.HasValue ? cRMspCmsSelectHomePageSectionItemsById_Result.SectionItemShowExpDate.Value.ToString("yyyy/MM/dd") : ""),
					SectionItemShowExpTime = (cRMspCmsSelectHomePageSectionItemsById_Result.SectionItemShowExpDate.HasValue ? cRMspCmsSelectHomePageSectionItemsById_Result.SectionItemShowExpDate.Value.ToString("HH:mm") : ""),
					SectionItemIsActive = cRMspCmsSelectHomePageSectionItemsById_Result.SectionItemIsActive,
					SectionItemOrderView = cRMspCmsSelectHomePageSectionItemsById_Result.SectionItemOrderView,
					FirstRegisterUserId = cRMspCmsSelectHomePageSectionItemsById_Result.FirstRegisterUserId,
					FirstRegisterDate = cRMspCmsSelectHomePageSectionItemsById_Result.FirstRegisterDate,
					UserId = cRMspCmsSelectHomePageSectionItemsById_Result.UserId,
					RegisterDate = cRMspCmsSelectHomePageSectionItemsById_Result.RegisterDate,
					AppType = cRMspCmsSelectHomePageSectionItemsById_Result.AppType,
					SectionItemSysPartId = cRMspCmsSelectHomePageSectionItemsById_Result.SectionItemSysPartId,
					SectionItemSysPartTitle = (cRMspCmsSelectHomePageSectionItemsById_Result.SectionItemSysPartTitle ?? ""),
					SectionItemObjId = cRMspCmsSelectHomePageSectionItemsById_Result.SectionItemObjId,
					SectionItemObjName = cRMspCmsSelectHomePageSectionItemsById_Result.SectionItemObjName,
					SectionItemLinkType = cRMspCmsSelectHomePageSectionItemsById_Result.SectionItemLinkType
				};
			}
			else
			{
				if (!UserLogin.IsUserAccess("frmCmsManageHomePageSection", "actAddItem"))
				{
					base.ViewBag.Error = Messages.NotAccessToPage;
					return null;
				}
				DateTime now = DateTime.Now;
				crmCmsHomePageSectionItemsLanguageViewModel = new CrmCmsHomePageSectionItemsLanguageViewModel
				{
					SectionItemIsActive = true,
					HomePageSectionId = hpSectionId,
					FirstRegisterDate = now,
					RegisterDate = now,
					FirstRegisterUserId = UserLogin.CurrentUser.UserId,
					UserId = UserLogin.CurrentUser.UserId
				};
				if (crmCmsHomePageSectionItemsLanguageViewModel.SectionItemOrderView.GetValueOrDefault() <= 0)
				{
					List<CRMspCmsSelectHomePageSectionItemsBySectionId_Result> list = Enumerable.ToList<CRMspCmsSelectHomePageSectionItemsBySectionId_Result>((IEnumerable<CRMspCmsSelectHomePageSectionItemsBySectionId_Result>)_db.CRMspCmsSelectHomePageSectionItemsBySectionId(crmCmsHomePageSectionItemsLanguageViewModel.HomePageSectionId, lCID, result));
					_ = Enumerable.FirstOrDefault<CRMspCmsSelectHomePageSectionItemsBySectionId_Result>((IEnumerable<CRMspCmsSelectHomePageSectionItemsBySectionId_Result>)Enumerable.OrderByDescending<CRMspCmsSelectHomePageSectionItemsBySectionId_Result, int?>((IEnumerable<CRMspCmsSelectHomePageSectionItemsBySectionId_Result>)list, (Func<CRMspCmsSelectHomePageSectionItemsBySectionId_Result, int?>)((CRMspCmsSelectHomePageSectionItemsBySectionId_Result m) => m.SectionItemOrderView)))?.SectionItemOrderView;
					int num = (Enumerable.Any<CRMspCmsSelectHomePageSectionItemsBySectionId_Result>((IEnumerable<CRMspCmsSelectHomePageSectionItemsBySectionId_Result>)list) ? Enumerable.Count<CRMspCmsSelectHomePageSectionItemsBySectionId_Result>((IEnumerable<CRMspCmsSelectHomePageSectionItemsBySectionId_Result>)list) : 0);
					crmCmsHomePageSectionItemsLanguageViewModel.SectionItemOrderView = num + 10 + num * 9 - 5;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		string firstRegInfo = "";
		string regInfo = "";
		SetHpSecItemRegisterInfo(crmCmsHomePageSectionItemsLanguageViewModel, ref firstRegInfo, ref regInfo);
		crmCmsHomePageSectionItemsLanguageViewModel.FirstRegisterUser = firstRegInfo;
		crmCmsHomePageSectionItemsLanguageViewModel.EditUser = regInfo;
		return View(crmCmsHomePageSectionItemsLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmCmsManageHomePageSectionItemDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult InsertEditItem(CrmCmsHomePageSectionItemsLanguageViewModel vm)
	{
		_003C_003Ec__DisplayClass17_0 _003C_003Ec__DisplayClass17_ = new _003C_003Ec__DisplayClass17_0();
		_003C_003Ec__DisplayClass17_.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		GetSectionHeaderPosition();
		GetSystemParts();
		GetSectionItemLinkType();
		base.ViewBag.PrdFirstGroupsJson = GetProductFirstGroups_Json();
		try
		{
			string text = "";
			CrmCmsHomePageSectionItems crmCmsHomePageSectionItems = new CrmCmsHomePageSectionItems();
			try
			{
				DateTime dateTime = default(DateTime);
				string text2 = "";
				if (!string.IsNullOrEmpty(_003C_003Ec__DisplayClass17_.vm.SectionItemShowExpDate))
				{
					text2 = PersianDate.GetFormatetdDate(_003C_003Ec__DisplayClass17_.vm.SectionItemShowExpDate.Replace("/", ""));
					text2 = (string.IsNullOrEmpty(_003C_003Ec__DisplayClass17_.vm.SectionItemShowExpTime) ? (text2 + " 00:00:00") : (text2 + " " + _003C_003Ec__DisplayClass17_.vm.SectionItemShowExpTime.Trim()));
					dateTime = lCID switch
					{
						1065 => DateTime.Parse(text2, new PersianCulture()), 
						1025 => DateTime.Parse(text2, new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(text2, new CultureInfo("en-US")), 
					};
					_003C_003Ec__DisplayClass17_.vm.SectionItemShowExpDateTime = dateTime;
				}
				else
				{
					_003C_003Ec__DisplayClass17_.vm.SectionItemShowExpDateTime = null;
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				base.ViewBag.Error = string.Format(Messages.ErrorInFormat, Labels.CmsHomePageSectionItemShowExpDateTime);
				return View(_003C_003Ec__DisplayClass17_.vm);
			}
			if (base.ModelState.IsValid)
			{
				crmCmsHomePageSectionItems = new CrmCmsHomePageSectionItems();
				if (_003C_003Ec__DisplayClass17_.vm.HomePageSectionItemId > 0)
				{
					DbSet<CrmCmsHomePageSectionItems> crmCmsHomePageSectionItems2 = _dbTbl.CrmCmsHomePageSectionItems;
					ParameterExpression val = Expression.Parameter(typeof(CrmCmsHomePageSectionItems), "c");
					crmCmsHomePageSectionItems = Queryable.FirstOrDefault<CrmCmsHomePageSectionItems>((IQueryable<CrmCmsHomePageSectionItems>)crmCmsHomePageSectionItems2, Expression.Lambda<Func<CrmCmsHomePageSectionItems, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass17_, typeof(_003C_003Ec__DisplayClass17_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				int userId = UserLogin.CurrentUser.UserId;
				DateTime now = DateTime.Now;
				DateTime dateTime2 = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short value2 = short.Parse(Financial.Get().Id.ToString());
				ObjectParameter objectParameter = new ObjectParameter("InsertedSectionItemId", typeof(int));
				_dbII.CRMspCmsInsertUpdateHomePageSectionItem(_003C_003Ec__DisplayClass17_.vm.HomePageSectionItemId, _003C_003Ec__DisplayClass17_.vm.HomePageSectionId, _003C_003Ec__DisplayClass17_.vm.SectionItemSysPartId, _003C_003Ec__DisplayClass17_.vm.SectionItemObjId, _003C_003Ec__DisplayClass17_.vm.SectionItemShowExpDateTime, _003C_003Ec__DisplayClass17_.vm.SectionItemIsActive, _003C_003Ec__DisplayClass17_.vm.SectionItemOrderView, userId, value2, value, dateTime2, registerDatePersian, appType, result, objectParameter, _003C_003Ec__DisplayClass17_.vm.SectionItemLinkType);
				int result2 = 0;
				if (objectParameter != null && objectParameter.Value != null && !string.IsNullOrWhiteSpace(objectParameter.ToString()))
				{
					int.TryParse(objectParameter.Value.ToString(), out result2);
				}
				if (_003C_003Ec__DisplayClass17_.vm.HomePageSectionItemId > 0)
				{
					text = Messages.frmFormBaseEditSuccessFulMessage;
					crmCmsHomePageSectionItems.UserId = userId;
					crmCmsHomePageSectionItems.FirstRegisterUserId = userId;
					crmCmsHomePageSectionItems.RegisterDate = dateTime2;
					crmCmsHomePageSectionItems.FirstRegisterDate = dateTime2;
					crmCmsHomePageSectionItems.AppType = appType;
				}
				else
				{
					text = Messages.frmFormBaseInsertSuccessFulMessage;
					crmCmsHomePageSectionItems = new CrmCmsHomePageSectionItems
					{
						UserId = userId,
						FirstRegisterUserId = userId,
						RegisterDate = dateTime2,
						FirstRegisterDate = dateTime2,
						AppType = appType
					};
				}
				_003C_003Ec__DisplayClass17_.vm.HomePageSectionItemId = result2;
				base.ViewBag.Successfull = text;
				_003C_003Ec__DisplayClass17_.vm.UserId = crmCmsHomePageSectionItems.UserId;
				_003C_003Ec__DisplayClass17_.vm.FirstRegisterUserId = crmCmsHomePageSectionItems.FirstRegisterUserId;
				_003C_003Ec__DisplayClass17_.vm.RegisterDate = crmCmsHomePageSectionItems.RegisterDate;
				_003C_003Ec__DisplayClass17_.vm.FirstRegisterDate = crmCmsHomePageSectionItems.FirstRegisterDate;
				_003C_003Ec__DisplayClass17_.vm.AppType = crmCmsHomePageSectionItems.AppType;
				string firstRegInfo = "";
				string regInfo = "";
				SetHpSecItemRegisterInfo(_003C_003Ec__DisplayClass17_.vm, ref firstRegInfo, ref regInfo);
				_003C_003Ec__DisplayClass17_.vm.FirstRegisterUser = firstRegInfo;
				_003C_003Ec__DisplayClass17_.vm.EditUser = regInfo;
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
		return View(_003C_003Ec__DisplayClass17_.vm);
	}

	[DynamicAuthorize(ControllerName = "frmCmsManageHomePageSectionItemDataEntry", ActionName = "actAddProductMulti")]
	public ActionResult AddProduct(int hpSectionId)
	{
		base.ViewBag.HomePagesectionId = hpSectionId;
		GetProductFirstGroups();
		GetProductSetcondGroups(0);
		return View();
	}

	[AjaxOnly]
	public ActionResult Products_Read([DataSourceRequest] DataSourceRequest request, int prdSgId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectProductsForHomePageSectionBySgId_Result> enumerable = new List<WSspSelectProductsForHomePageSectionBySgId_Result>();
		try
		{
			enumerable = Enumerable.ToList<WSspSelectProductsForHomePageSectionBySgId_Result>((IEnumerable<WSspSelectProductsForHomePageSectionBySgId_Result>)_db.WSspSelectProductsForHomePageSectionBySgId(prdSgId, lCID, result));
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
	public JsonResult GetProductFirstGroups()
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
			list = GetProductFirstGroupsList();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ProductFirstGroupsList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetProductSetcondGroups(int prdFgId)
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
			if (prdFgId > 0)
			{
				List<WSspSelectProductSecondGroup_Result> list2 = Enumerable.ToList<WSspSelectProductSecondGroup_Result>((IEnumerable<WSspSelectProductSecondGroup_Result>)_db.WSspSelectProductSecondGroup(prdFgId, lCID, result));
				list.AddRange(Enumerable.Select<WSspSelectProductSecondGroup_Result, SelectListItem>((IEnumerable<WSspSelectProductSecondGroup_Result>)list2, (Func<WSspSelectProductSecondGroup_Result, SelectListItem>)((WSspSelectProductSecondGroup_Result item) => new SelectListItem
				{
					Text = item.SGName,
					Value = item.PrdSecondGroupID.ToString(),
					Selected = false
				})));
			}
			else
			{
				SelectListItem item2 = new SelectListItem
				{
					Text = Labels.SelectedListDefValue,
					Value = "0",
					Selected = false
				};
				list.Add(item2);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ProductSecondGroupsList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public List<SelectListItem> GetProductFirstGroupsList()
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
			List<WSspSelectProductFirstGroup_Result> list2 = Enumerable.ToList<WSspSelectProductFirstGroup_Result>((IEnumerable<WSspSelectProductFirstGroup_Result>)_db.WSspSelectProductFirstGroup(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectProductFirstGroup_Result, SelectListItem>((IEnumerable<WSspSelectProductFirstGroup_Result>)list2, (Func<WSspSelectProductFirstGroup_Result, SelectListItem>)((WSspSelectProductFirstGroup_Result item) => new SelectListItem
			{
				Text = item.FGName,
				Value = item.PrdFirstGroupID.ToString(),
				Selected = false
			})));
			if (list == null)
			{
				list = new List<SelectListItem>();
			}
			SelectListItem item2 = new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = true
			};
			list.Add(item2);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public string GetProductFirstGroups_Json()
	{
		return JsonConvert.SerializeObject(GetProductFirstGroupsList());
	}

	public string GetTreeProductSetcondGroups()
	{
		List<nTreeItemViewModel> list = new List<nTreeItemViewModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectProductGroupTree_Result> list2 = Enumerable.ToList<WSspSelectProductGroupTree_Result>((IEnumerable<WSspSelectProductGroupTree_Result>)_db.WSspSelectProductGroupTree(lCID, result));
			if (list2 != null && Enumerable.Any<WSspSelectProductGroupTree_Result>((IEnumerable<WSspSelectProductGroupTree_Result>)list2))
			{
				list.AddRange(Enumerable.Select<WSspSelectProductGroupTree_Result, nTreeItemViewModel>((IEnumerable<WSspSelectProductGroupTree_Result>)list2, (Func<WSspSelectProductGroupTree_Result, nTreeItemViewModel>)((WSspSelectProductGroupTree_Result item) => new nTreeItemViewModel
				{
					ParentId = ((item.ParentId == 0) ? "" : ("0-" + item.ParentId)),
					KeyId = ((item.ParentId == 0) ? ("0-" + item.FId) : ("1-" + item.SId)),
					KeyName = (item.KEYName ?? "")
				})));
			}
			if (list == null)
			{
				list = new List<nTreeItemViewModel>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[AjaxOnly]
	public JsonResult SearchProducts(int fgId = 0, int sgId = 0, string barcode = "", string val = "")
	{
		List<WSspSearchProductsWeb_Result> list = new List<WSspSearchProductsWeb_Result>();
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
			list = Enumerable.ToList<WSspSearchProductsWeb_Result>((IEnumerable<WSspSearchProductsWeb_Result>)_dbI.WSspSearchProductsWeb(fgId, sgId, barcode, val, 0, 0, lCID, result, 0, -1, null, null, result2, UserLogin.CurrentUser.UserId));
			if (list == null)
			{
				list = new List<WSspSearchProductsWeb_Result>();
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmCmsManageHomePageSectionItemAdd", ActionName = "actAddProductByFGId")]
	public string AddProductByFGId(int hpSectionId, int prdFgId, string sectionItemShowExpDate, string sectionItemShowExpTime)
	{
		string result = "";
		try
		{
			if (hpSectionId > 0)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
				if (result2 <= 0)
				{
					result2 = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				int userId = UserLogin.CurrentUser.UserId;
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short value3 = short.Parse(Financial.Get().Id.ToString());
				DateTime value4 = default(DateTime);
				try
				{
					DateTime dateTime = default(DateTime);
					string text = "";
					if (!string.IsNullOrEmpty(sectionItemShowExpDate))
					{
						text = PersianDate.GetFormatetdDate(sectionItemShowExpDate.Replace("/", ""));
						text = (string.IsNullOrEmpty(sectionItemShowExpTime) ? (text + " 00:00:00") : (text + " " + sectionItemShowExpTime.Trim()));
						value4 = lCID switch
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
					return string.Format(Messages.ErrorInFormat, Labels.CmsHomePageSectionItemShowExpDateTime);
				}
				_db.CRMspCmsInsertHomePageSectionItemsByPrdFGId(hpSectionId, prdFgId, (!string.IsNullOrEmpty(sectionItemShowExpDate)) ? new DateTime?(value4) : null, userId, value3, value2, value, registerDatePersian, appType, result2);
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
	[DynamicAuthorize(ControllerName = "frmCmsManageHomePageSectionItemAdd", ActionName = "actAddProductBySGId")]
	public string AddProductBySGId(int hpSectionId, int prdSgId, string sectionItemShowExpDate, string sectionItemShowExpTime)
	{
		string result = "";
		try
		{
			if (hpSectionId > 0)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
				if (result2 <= 0)
				{
					result2 = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				int userId = UserLogin.CurrentUser.UserId;
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short value3 = short.Parse(Financial.Get().Id.ToString());
				DateTime value4 = default(DateTime);
				try
				{
					DateTime dateTime = default(DateTime);
					string text = "";
					if (!string.IsNullOrEmpty(sectionItemShowExpDate))
					{
						text = PersianDate.GetFormatetdDate(sectionItemShowExpDate.Replace("/", ""));
						text = (string.IsNullOrEmpty(sectionItemShowExpTime) ? (text + " 00:00:00") : (text + " " + sectionItemShowExpTime.Trim()));
						value4 = lCID switch
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
					return string.Format(Messages.ErrorInFormat, Labels.CmsHomePageSectionItemShowExpDateTime);
				}
				_db.CRMspCmsInsertHomePageSectionItemsByPrdSGId(hpSectionId, prdSgId, (!string.IsNullOrEmpty(sectionItemShowExpDate)) ? new DateTime?(value4) : null, userId, value3, value2, value, registerDatePersian, appType, result2);
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
	[DynamicAuthorize(ControllerName = "frmCmsManageHomePageSectionItemAdd", ActionName = "actAddSelectedProducts")]
	public string AddSelectedProducts(int hpSectionId, string prdIds, string sectionItemShowExpDate, string sectionItemShowExpTime)
	{
		string result = "";
		try
		{
			if (hpSectionId > 0)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
				if (result2 <= 0)
				{
					result2 = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				int userId = UserLogin.CurrentUser.UserId;
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short value3 = short.Parse(Financial.Get().Id.ToString());
				DateTime value4 = default(DateTime);
				try
				{
					DateTime dateTime = default(DateTime);
					string text = "";
					if (!string.IsNullOrEmpty(sectionItemShowExpDate))
					{
						text = PersianDate.GetFormatetdDate(sectionItemShowExpDate.Replace("/", ""));
						text = (string.IsNullOrEmpty(sectionItemShowExpTime) ? (text + " 00:00:00") : (text + " " + sectionItemShowExpTime.Trim()));
						value4 = lCID switch
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
					return string.Format(Messages.ErrorInFormat, Labels.CmsHomePageSectionItemShowExpDateTime);
				}
				_db.CRMspCmsInsertHomePageSectionItemsByPrdIds(hpSectionId, prdIds, (!string.IsNullOrEmpty(sectionItemShowExpDate)) ? new DateTime?(value4) : null, userId, value3, value2, value, registerDatePersian, appType, result2);
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
	public void GetSystemParts()
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
			List<CRMspSelectActiveSystemParts_Result> list2 = Enumerable.ToList<CRMspSelectActiveSystemParts_Result>((IEnumerable<CRMspSelectActiveSystemParts_Result>)_dbI.CRMspSelectActiveSystemParts(lCID, result, "70,320,330,340"));
			list.AddRange(Enumerable.Select<CRMspSelectActiveSystemParts_Result, SelectListItem>((IEnumerable<CRMspSelectActiveSystemParts_Result>)list2, (Func<CRMspSelectActiveSystemParts_Result, SelectListItem>)((CRMspSelectActiveSystemParts_Result i) => new SelectListItem
			{
				Text = i.PartTitle,
				Value = i.SystemPartId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.SystemPartList = list;
	}

	[AjaxOnly]
	public JsonResult GetSectionItemLinkType()
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
				Text = Labels.CmsHomePageSectionItemLinkTypePrd,
				Value = "1",
				Selected = false
			};
			list.Add(item);
			item = new SelectListItem
			{
				Text = Labels.CmsHomePageSectionItemLinkTypePrdFGroup,
				Value = "2",
				Selected = false
			};
			list.Add(item);
			item = new SelectListItem
			{
				Text = Labels.CmsHomePageSectionItemLinkTypePrdSGroup,
				Value = "3",
				Selected = false
			};
			list.Add(item);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.SectionItemLinkTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		base.Dispose(disposing);
	}
}

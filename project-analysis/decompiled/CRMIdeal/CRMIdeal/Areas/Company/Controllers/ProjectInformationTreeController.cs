using System;
using System.Collections;
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
using CRM.General.Utilities;
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

namespace CRMIdeal.Areas.Company.Controllers;

public class ProjectInformationTreeController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass13_0
	{
		public CRMspSelectDefaultFormObjectProperties_Result model;

		public int currLangId;

		internal bool _003CEditCaptionMultiGroups_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass14_1
	{
		public CrmsysFormObjectProperties editCaption;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass14_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass14_1 CS_0024_003C_003E8__locals1;

		internal bool _003CEditCaption_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditCaption_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditCaption_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditCaption_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass16_0
	{
		public int prjInfoId;

		public int currLangId;

		internal bool _003CInsertEdit_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangId;
		}

		internal bool _003CInsertEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangId;
		}

		internal bool _003CInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass17_0
	{
		public CrmProjectInformationsViewModel model;

		public int defLangId;

		public Func<Languages, bool> _003C_003E9__4;

		internal bool _003CInsertEdit_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangId;
		}

		internal bool _003CInsertEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangId;
		}

		internal bool _003CInsertEdit_003Eb__4(Languages c)
		{
			return c.LanguageID != defLangId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass17_1
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass17_0 CS_0024_003C_003E8__locals1;

		internal bool _003CInsertEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

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
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass26_0
	{
		public int fieldid;

		public int currLangId;

		internal bool _003CDefineProjectFieldTitleInsertEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangId;
		}

		internal bool _003CDefineProjectFieldTitleInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangId;
		}

		internal bool _003CDefineProjectFieldTitleInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangId;
		}

		internal bool _003CDefineProjectFieldTitleInsertEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangId;
		}

		internal bool _003CDefineProjectFieldTitleInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangId;
		}

		internal bool _003CDefineProjectFieldTitleInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass27_0
	{
		public CrmProjectFieldTitleLanguageViewModel model;

		public int defLangId;

		public Func<Languages, bool> _003C_003E9__4;

		public Func<Languages, bool> _003C_003E9__18;

		internal bool _003CDefineProjectFieldTitleInsertEdit_003Eb__0(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangId;
		}

		internal bool _003CDefineProjectFieldTitleInsertEdit_003Eb__1(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangId;
		}

		internal bool _003CDefineProjectFieldTitleInsertEdit_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangId;
		}

		internal bool _003CDefineProjectFieldTitleInsertEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangId;
		}

		internal bool _003CDefineProjectFieldTitleInsertEdit_003Eb__4(Languages c)
		{
			return c.LanguageID != defLangId;
		}

		internal bool _003CDefineProjectFieldTitleInsertEdit_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangId;
		}

		internal bool _003CDefineProjectFieldTitleInsertEdit_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangId;
		}

		internal bool _003CDefineProjectFieldTitleInsertEdit_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangId;
		}

		internal bool _003CDefineProjectFieldTitleInsertEdit_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangId;
		}

		internal bool _003CDefineProjectFieldTitleInsertEdit_003Eb__18(Languages c)
		{
			return c.LanguageID != defLangId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass27_1
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass27_0 CS_0024_003C_003E8__locals1;

		internal bool _003CDefineProjectFieldTitleInsertEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CDefineProjectFieldTitleInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CDefineProjectFieldTitleInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CDefineProjectFieldTitleInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CDefineProjectFieldTitleInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CDefineProjectFieldTitleInsertEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CDefineProjectFieldTitleInsertEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CDefineProjectFieldTitleInsertEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass35_0
	{
		public int fieldid;

		public int currLangId;

		internal bool _003CDefineDefaultValueInsertEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangId;
		}

		internal bool _003CDefineDefaultValueInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangId;
		}

		internal bool _003CDefineDefaultValueInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangId;
		}

		internal bool _003CDefineDefaultValueInsertEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangId;
		}

		internal bool _003CDefineDefaultValueInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangId;
		}

		internal bool _003CDefineDefaultValueInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass36_0
	{
		public CrmProjectDefualtValueLanguageViewModel model;

		public int defLangId;

		public Func<Languages, bool> _003C_003E9__2;

		public Func<Languages, bool> _003C_003E9__10;

		internal bool _003CDefineDefaultValueInsertEdit_003Eb__0(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangId;
		}

		internal bool _003CDefineDefaultValueInsertEdit_003Eb__1(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangId;
		}

		internal bool _003CDefineDefaultValueInsertEdit_003Eb__2(Languages c)
		{
			return c.LanguageID != defLangId;
		}

		internal bool _003CDefineDefaultValueInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangId;
		}

		internal bool _003CDefineDefaultValueInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangId;
		}

		internal bool _003CDefineDefaultValueInsertEdit_003Eb__10(Languages c)
		{
			return c.LanguageID != defLangId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass36_1
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass36_0 CS_0024_003C_003E8__locals1;

		internal bool _003CDefineDefaultValueInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CDefineDefaultValueInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CDefineDefaultValueInsertEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CDefineDefaultValueInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass37_0
	{
		public CrmProjectDefualtValue model;

		public string value;
	}

	private CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actProjectInformationTree")]
	public ActionResult Index(int prjId)
	{
		base.ViewBag.ProjectTitle = "";
		base.ViewBag.ProjectId = prjId;
		return View();
	}

	[AjaxOnly]
	public JsonResult LoadTree(int prjId)
	{
		List<TreeViewItemModel> data = new List<TreeViewItemModel>();
		try
		{
			if (prjId > 0)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				new List<CRMspSelectProjectInformationsTree_Result>();
				List<CRMspSelectProjectInformationsTree_Result> list = Enumerable.ToList<CRMspSelectProjectInformationsTree_Result>((IEnumerable<CRMspSelectProjectInformationsTree_Result>)_db.CRMspSelectProjectInformationsTree(prjId, lCID, result));
				List<TreeViewItemModel> list2 = new List<TreeViewItemModel>();
				foreach (CRMspSelectProjectInformationsTree_Result item in list)
				{
					TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
					treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.ProjectInformationId + "|" + item.RootId));
					treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("title", item.Field));
					treeViewItemModel.Id = item.ProjectInformationId + "|" + item.RootId;
					treeViewItemModel.Text = item.Field;
					treeViewItemModel.ImageUrl = "";
					treeViewItemModel.Items = null;
					list2.Add(treeViewItemModel);
				}
				data = list2;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult CheckHaveMultiGroup(int prjId)
	{
		List<MultiGroupItem> data = new List<MultiGroupItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectPrjMultiG_Result> list = Enumerable.ToList<CRMspSelectPrjMultiG_Result>((IEnumerable<CRMspSelectPrjMultiG_Result>)_db.CRMspSelectPrjMultiG(lCID, result));
			List<MultiGroupItem> list2 = new List<MultiGroupItem>();
			foreach (CRMspSelectPrjMultiG_Result item in list)
			{
				MultiGroupItem multiGroupItem = new MultiGroupItem
				{
					title = item.ProjectGroupsMultiName,
					id = item.ProjectGroupsMultiId,
					ischeck = false
				};
				if (Enumerable.FirstOrDefault<CRMspCheckHaveMultiGroup_Result>((IEnumerable<CRMspCheckHaveMultiGroup_Result>)Enumerable.ToList<CRMspCheckHaveMultiGroup_Result>((IEnumerable<CRMspCheckHaveMultiGroup_Result>)_db.CRMspCheckHaveMultiGroup(prjId, item.ProjectGroupsMultiId))) != null)
				{
					multiGroupItem.ischeck = true;
				}
				list2.Add(multiGroupItem);
			}
			data = list2;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public string InsertProjectMultiGroups(int prjId, int multiGroupId)
	{
		string text = "";
		try
		{
			if (!UserLogin.IsUserAccess("frmProjectInformationTree", "actMultiGroupCanEdit", UserLogin.CurrentUser))
			{
				return "-1|" + Messages.ErrorNotAccess;
			}
			if (prjId > 0 && multiGroupId > 0)
			{
				DateTime now = DateTime.Now;
				int userId = UserLogin.CurrentUser.UserId;
				short value = short.Parse(Financial.Get().Id.ToString());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				string appType = Configuration.AppType;
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				_ = Thread.CurrentThread.CurrentCulture.LCID;
				if (_db.CRMspInsertProjectMultiGroups(prjId, multiGroupId, userId, value, value2, registerDatePersian, appType, result) > 0)
				{
					return "1|" + Messages.msgSuccessAction;
				}
				return "-1|" + Messages.msgErrorRunFunction;
			}
			return "-1|" + Messages.ErrorNotFound;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return "-1|" + Messages.msgErrorRunFunction;
		}
	}

	[AjaxOnly]
	public string DeleteProjectMultiGroups(int prjId, int multiGroupId)
	{
		string text = "";
		try
		{
			if (!UserLogin.IsUserAccess("frmProjectInformationTree", "actMultiGroupCanEdit", UserLogin.CurrentUser))
			{
				return "-1|" + Messages.ErrorNotAccess;
			}
			if (prjId > 0 && multiGroupId > 0)
			{
				if (_db.CRMspDeleteProjectMultiGroups(prjId, multiGroupId) > 0)
				{
					return "1|" + Messages.msgSuccessAction;
				}
				return "-1|" + Messages.msgErrorRunFunction;
			}
			return "-1|" + Messages.ErrorNotFound;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return "-1|" + Messages.msgErrorRunFunction;
		}
	}

	[AjaxOnly]
	public JsonResult CheckHaveMultiGroupI(int prjId)
	{
		List<MultiGroupItem> data = new List<MultiGroupItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectPrjMultiIG_Result> list = Enumerable.ToList<CRMspSelectPrjMultiIG_Result>((IEnumerable<CRMspSelectPrjMultiIG_Result>)_db.CRMspSelectPrjMultiIG(lCID, result));
			List<MultiGroupItem> list2 = new List<MultiGroupItem>();
			foreach (CRMspSelectPrjMultiIG_Result item in list)
			{
				MultiGroupItem multiGroupItem = new MultiGroupItem
				{
					title = item.ProjectGroupsMultiIName,
					id = item.ProjectGroupsMultiIId,
					ischeck = false
				};
				if (Enumerable.FirstOrDefault<CRMspCheckHaveMultiIGroup_Result>((IEnumerable<CRMspCheckHaveMultiIGroup_Result>)Enumerable.ToList<CRMspCheckHaveMultiIGroup_Result>((IEnumerable<CRMspCheckHaveMultiIGroup_Result>)_db.CRMspCheckHaveMultiIGroup(prjId, item.ProjectGroupsMultiIId))) != null)
				{
					multiGroupItem.ischeck = true;
				}
				list2.Add(multiGroupItem);
			}
			data = list2;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public string InsertProjectMultiIGroups(int prjId, int multiGroupId)
	{
		string text = "";
		try
		{
			if (!UserLogin.IsUserAccess("frmProjectInformationTree", "actMultiIGroupCanEdit", UserLogin.CurrentUser))
			{
				return "-1|" + Messages.ErrorNotAccess;
			}
			if (prjId > 0 && multiGroupId > 0)
			{
				DateTime now = DateTime.Now;
				int userId = UserLogin.CurrentUser.UserId;
				short value = short.Parse(Financial.Get().Id.ToString());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				string appType = Configuration.AppType;
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				_ = Thread.CurrentThread.CurrentCulture.LCID;
				if (_db.CRMspInsertProjectMultiIGroups(prjId, multiGroupId, userId, value, value2, registerDatePersian, appType, result) > 0)
				{
					return "1|" + Messages.msgSuccessAction;
				}
				return "-1|" + Messages.msgErrorRunFunction;
			}
			return "-1|" + Messages.ErrorNotFound;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return "-1|" + Messages.msgErrorRunFunction;
		}
	}

	[AjaxOnly]
	public string DeleteProjectMultiIGroups(int prjId, int multiGroupId)
	{
		string text = "";
		try
		{
			if (!UserLogin.IsUserAccess("frmProjectInformationTree", "actMultiIGroupCanEdit", UserLogin.CurrentUser))
			{
				return "-1|" + Messages.ErrorNotAccess;
			}
			if (prjId > 0 && multiGroupId > 0)
			{
				if (_db.CRMspDeleteProjectMultiIGroups(prjId, multiGroupId) > 0)
				{
					return "1|" + Messages.msgSuccessAction;
				}
				return "-1|" + Messages.msgErrorRunFunction;
			}
			return "-1|" + Messages.ErrorNotFound;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return "-1|" + Messages.msgErrorRunFunction;
		}
	}

	[AjaxOnly]
	public string DeleteMultiGroupsAfterPrjDel(int prjId)
	{
		string text = "";
		try
		{
			if (prjId > 0)
			{
				if (_db.CRMspDeleteMultiGroupsAfterPrjDel(prjId) > 0)
				{
					return "1|" + Messages.msgSuccessAction;
				}
				return "-1|" + Messages.msgErrorRunFunction;
			}
			return "-1|" + Messages.ErrorNotFound;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return "-1|" + Messages.msgErrorRunFunction;
		}
	}

	[AjaxOnly]
	public string DeleteMultiIGroupsAfterPrjDel(int prjId)
	{
		string text = "";
		try
		{
			if (prjId > 0)
			{
				if (_db.CRMspDeleteMultiIGroupsAfterPrjDel(prjId) > 0)
				{
					return "1|" + Messages.msgSuccessAction;
				}
				return "-1|" + Messages.msgErrorRunFunction;
			}
			return "-1|" + Messages.ErrorNotFound;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return "-1|" + Messages.msgErrorRunFunction;
		}
	}

	[AjaxOnly]
	public string SetObjectProperties(string formName, int langId)
	{
		string text = "";
		try
		{
			if (!string.IsNullOrEmpty(formName))
			{
				text = "1|";
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				List<CRMspSelectFormObjectProperties_Result> list = Enumerable.ToList<CRMspSelectFormObjectProperties_Result>((IEnumerable<CRMspSelectFormObjectProperties_Result>)_db.CRMspSelectFormObjectProperties(formName, lCID, result));
				if (Enumerable.Any<CRMspSelectFormObjectProperties_Result>((IEnumerable<CRMspSelectFormObjectProperties_Result>)list))
				{
					foreach (CRMspSelectFormObjectProperties_Result item in list)
					{
						if (item.ObjectType == "TRzLabel")
						{
							text = text + item.ObjectName + "," + item.ObjectPersianName + "," + item.ID + "|";
						}
					}
				}
				else
				{
					text = "-1|" + Messages.msgErrorRunFunction;
				}
			}
			else
			{
				text = "-1|" + Messages.ErrorNotFound;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = "-1|" + Messages.msgErrorRunFunction;
		}
		return text;
	}

	public ActionResult EditCaptionMultiGroups(string formName, string lableName)
	{
		base.ViewBag.FormName = formName;
		base.ViewBag.LabelName = lableName;
		string text = "";
		try
		{
			if (!string.IsNullOrEmpty(formName) && !string.IsNullOrEmpty(lableName))
			{
				_003C_003Ec__DisplayClass13_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass13_0();
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				CS_0024_003C_003E8__locals0.currLangId = Thread.CurrentThread.CurrentCulture.LCID;
				CS_0024_003C_003E8__locals0.model = Enumerable.FirstOrDefault<CRMspSelectDefaultFormObjectProperties_Result>((IEnumerable<CRMspSelectDefaultFormObjectProperties_Result>)_db.CRMspSelectDefaultFormObjectProperties(formName, lableName));
				if (CS_0024_003C_003E8__locals0.model != null)
				{
					DbSet<CrmsysFormObjectProperties_Lang> crmsysFormObjectProperties_Lang = _dbTbl.CrmsysFormObjectProperties_Lang;
					ParameterExpression val = Expression.Parameter(typeof(CrmsysFormObjectProperties_Lang), "c");
					List<CommonMultiLanguageViewModel> list = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmsysFormObjectProperties_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmsysFormObjectProperties_Lang>)Enumerable.ToList<CrmsysFormObjectProperties_Lang>((IEnumerable<CrmsysFormObjectProperties_Lang>)Queryable.Where<CrmsysFormObjectProperties_Lang>((IQueryable<CrmsysFormObjectProperties_Lang>)crmsysFormObjectProperties_Lang, Expression.Lambda<Func<CrmsysFormObjectProperties_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass13_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }))), (Func<CrmsysFormObjectProperties_Lang, CommonMultiLanguageViewModel>)((CrmsysFormObjectProperties_Lang liObj) => new CommonMultiLanguageViewModel
					{
						Value = liObj.ObjectPersianName,
						LanguageId = liObj.LanguageID
					})));
					list.Add(new CommonMultiLanguageViewModel
					{
						Value = CS_0024_003C_003E8__locals0.model.ObjectPersianName,
						LanguageId = result
					});
					text = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangId))));
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.Caption_Lang = text;
		return View();
	}

	[AjaxOnly]
	public string EditCaption(string formName, string lableName, string newCaption, string langCaption)
	{
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		int num = 0;
		try
		{
			if (!string.IsNullOrEmpty(formName) && !string.IsNullOrEmpty(lableName))
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangId);
				if (defLangId <= 0)
				{
					defLangId = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				List<CRMspSelectFormObjectProperties_Result> list = Enumerable.ToList<CRMspSelectFormObjectProperties_Result>((IEnumerable<CRMspSelectFormObjectProperties_Result>)_db.CRMspSelectFormObjectProperties(formName, lCID, defLangId));
				if (Enumerable.Any<CRMspSelectFormObjectProperties_Result>((IEnumerable<CRMspSelectFormObjectProperties_Result>)list))
				{
					foreach (CRMspSelectFormObjectProperties_Result item in list)
					{
						if (!(item.ObjectName == lableName))
						{
							continue;
						}
						_003C_003Ec__DisplayClass14_1 _003C_003Ec__DisplayClass14_ = new _003C_003Ec__DisplayClass14_1();
						_003C_003Ec__DisplayClass14_.editCaption = _dbTbl.CrmsysFormObjectProperties.Find(item.ID);
						if (_003C_003Ec__DisplayClass14_.editCaption != null)
						{
							List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
							if (!string.IsNullOrEmpty(langCaption))
							{
								list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(langCaption);
							}
							list2.Add(new CommonMultiLanguageViewModel
							{
								Value = newCaption,
								LanguageId = lCID
							});
							if (string.IsNullOrEmpty(newCaption))
							{
								num++;
								text = text + "-1|" + Messages.msgErrorNotEnteredCaptionMultiGroups + "<br>";
							}
							else if (!checkMultiLanguage(newCaption, list2))
							{
								text = "-1|" + text + Messages.CheckCaptionMultiGroupsLang + "<br>";
								num++;
							}
							if (num != 0)
							{
								continue;
							}
							_003C_003Ec__DisplayClass14_.editCaption.ObjectPersianName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
							_003C_003Ec__DisplayClass14_.editCaption.AppType = Configuration.AppType;
							_003C_003Ec__DisplayClass14_.editCaption.UserId = UserLogin.CurrentUser.UserId;
							_003C_003Ec__DisplayClass14_.editCaption.LanguageID = defLangId;
							DateTime now = DateTime.Now;
							_003C_003Ec__DisplayClass14_.editCaption.RegisterDate = now;
							_003C_003Ec__DisplayClass14_.editCaption.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
							_003C_003Ec__DisplayClass14_.editCaption.Year1 = short.Parse(Financial.Get().Id.ToString());
							_003C_003Ec__DisplayClass14_.editCaption.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
							_dbTbl.Entry(_003C_003Ec__DisplayClass14_.editCaption).State = EntityState.Modified;
							_dbTbl.SaveChanges();
							using (List<Languages>.Enumerator enumerator2 = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangId))).GetEnumerator())
							{
								while (enumerator2.MoveNext())
								{
									_003C_003Ec__DisplayClass14_2 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass14_2();
									CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass14_;
									CS_0024_003C_003E8__locals0.lang = enumerator2.Current;
									DbSet<CrmsysFormObjectProperties_Lang> crmsysFormObjectProperties_Lang = _dbTbl.CrmsysFormObjectProperties_Lang;
									ParameterExpression val = Expression.Parameter(typeof(CrmsysFormObjectProperties_Lang), "c");
									CrmsysFormObjectProperties_Lang crmsysFormObjectProperties_Lang2 = Queryable.FirstOrDefault<CrmsysFormObjectProperties_Lang>((IQueryable<CrmsysFormObjectProperties_Lang>)crmsysFormObjectProperties_Lang, Expression.Lambda<Func<CrmsysFormObjectProperties_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass14_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass14_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
									if (crmsysFormObjectProperties_Lang2 != null)
									{
										crmsysFormObjectProperties_Lang2.ObjectPersianName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.lang.LanguageID)).Value : null);
										_dbTbl.Entry(crmsysFormObjectProperties_Lang2).State = EntityState.Modified;
										_dbTbl.SaveChanges();
										continue;
									}
									CrmsysFormObjectProperties_Lang entity = new CrmsysFormObjectProperties_Lang
									{
										LanguageID = CS_0024_003C_003E8__locals0.lang.LanguageID,
										ID = CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.editCaption.ID,
										ObjectPersianName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.lang.LanguageID)).Value : null)
									};
									_dbTbl.CrmsysFormObjectProperties_Lang.Add(entity);
									_dbTbl.SaveChanges();
								}
							}
							text = "1|" + Messages.msgSuccessAction;
						}
						else
						{
							text = "-1|" + Messages.ErrorNotFound;
						}
					}
				}
				else
				{
					text = "-1|" + Messages.msgErrorRunFunction;
				}
			}
			else
			{
				text = "-1|" + Messages.ErrorNotFound;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = "-1|" + Messages.msgErrorRunFunction;
		}
		return text;
	}

	public void SetUserNameDateForProjectInformation(CrmProjectInformationsViewModel model)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		string text2 = "";
		try
		{
			string text3 = "";
			string text4 = "";
			string text5 = (model.FirstRegisterUserId ?? UserLogin.CurrentUser.UserId).ToString();
			_ = model.UserId;
			List<CRMspSelectUsersByIds_Result> list = CRMIdeal.Classes.Helper.User.SelectUsersByIds(text5 + "," + model.UserId);
			if (Enumerable.Any<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list))
			{
				CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.FirstRegisterUserId));
				text3 = ((cRMspSelectUsersByIds_Result != null) ? (cRMspSelectUsersByIds_Result.LName + ((cRMspSelectUsersByIds_Result.FName != null) ? (" " + cRMspSelectUsersByIds_Result.FName) : "")) : "");
				CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result2 = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.UserId));
				text4 = ((cRMspSelectUsersByIds_Result2 != null) ? (cRMspSelectUsersByIds_Result2.LName + ((cRMspSelectUsersByIds_Result2.FName != null) ? (" " + cRMspSelectUsersByIds_Result2.FName) : "")) : "");
			}
			string text6 = (model.FirstRegisterDate.HasValue ? model.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
			_ = model.RegisterDate;
			string text7 = model.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
			if (string.IsNullOrEmpty(model.AppType))
			{
				model.AppType = Configuration.AppType;
			}
			string text8 = Labels.AppType + ": " + Configuration.GetAppType(model.AppType);
			text = Labels.frmFirstRegisterUser + ": " + text3 + " (" + text6 + ")";
			text2 = Labels.frmRegisterUser + ": " + text4 + " (" + text8 + ") (" + text7 + ")";
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.FirstRegisterInfo = text;
		base.ViewBag.EditInfo = text2;
	}

	[DynamicAuthorize(ControllerName = "frmProjectInformationTree", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(int prjId, string mode, int prjInfoId)
	{
		_003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass16_0();
		CS_0024_003C_003E8__locals0.prjInfoId = prjInfoId;
		CrmProjectInformationsViewModel crmProjectInformationsViewModel = new CrmProjectInformationsViewModel();
		DateTime now = DateTime.Now;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangId = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			if (CS_0024_003C_003E8__locals0.prjInfoId > 0)
			{
				if (!UserLogin.IsUserAccess("frmProjectInformationTree", "actEdit"))
				{
					return RedirectToAction("Login", "Account", (object)new
					{
						area = "",
						d = DateTime.Now
					});
				}
				crmProjectInformationsViewModel = new CrmProjectInformationsViewModel();
				CRMspSelectProjectInformations_Result cRMspSelectProjectInformations_Result = Enumerable.FirstOrDefault<CRMspSelectProjectInformations_Result>((IEnumerable<CRMspSelectProjectInformations_Result>)_db.CRMspSelectProjectInformations(CS_0024_003C_003E8__locals0.prjInfoId, CS_0024_003C_003E8__locals0.currLangId, result));
				if (cRMspSelectProjectInformations_Result == null)
				{
					base.ViewBag.Error = Messages.ErrorNotFound;
					return null;
				}
				crmProjectInformationsViewModel.ProjectInformationId = cRMspSelectProjectInformations_Result.ProjectInformationId;
				crmProjectInformationsViewModel.ProjectId = cRMspSelectProjectInformations_Result.ProjectId;
				crmProjectInformationsViewModel.FieldTitleId = cRMspSelectProjectInformations_Result.FieldTitleId;
				crmProjectInformationsViewModel.FieldValue = cRMspSelectProjectInformations_Result.FieldValue;
				crmProjectInformationsViewModel.Description = cRMspSelectProjectInformations_Result.Description;
				crmProjectInformationsViewModel.UserId = cRMspSelectProjectInformations_Result.UserId;
				crmProjectInformationsViewModel.Year1 = cRMspSelectProjectInformations_Result.Year1;
				crmProjectInformationsViewModel.Month1 = cRMspSelectProjectInformations_Result.Month1;
				crmProjectInformationsViewModel.RegisterDate = cRMspSelectProjectInformations_Result.RegisterDate;
				crmProjectInformationsViewModel.RegisterDatePersian = cRMspSelectProjectInformations_Result.RegisterDatePersian;
				crmProjectInformationsViewModel.GUId = cRMspSelectProjectInformations_Result.GUId;
				crmProjectInformationsViewModel.AppType = cRMspSelectProjectInformations_Result.AppType;
				crmProjectInformationsViewModel.FieldTitle = cRMspSelectProjectInformations_Result.FieldTitle;
				crmProjectInformationsViewModel.ValueType = cRMspSelectProjectInformations_Result.ValueType;
				crmProjectInformationsViewModel.Mode = mode;
				crmProjectInformationsViewModel.LanguageID = cRMspSelectProjectInformations_Result.LanguageID;
				crmProjectInformationsViewModel.FirstRegisterUserId = cRMspSelectProjectInformations_Result.FirstRegisterUserId;
				crmProjectInformationsViewModel.FirstRegisterDatePersian = cRMspSelectProjectInformations_Result.FirstRegisterDatePersian;
				crmProjectInformationsViewModel.FirstRegisterDate = cRMspSelectProjectInformations_Result.FirstRegisterDate;
			}
			else
			{
				DateTime now2 = DateTime.Now;
				if (!UserLogin.IsUserAccess("frmProjectInformationTree", "actInsert"))
				{
					return RedirectToAction("Login", "Account", (object)new
					{
						area = "",
						d = DateTime.Now
					});
				}
				crmProjectInformationsViewModel = new CrmProjectInformationsViewModel
				{
					Mode = mode,
					ProjectId = prjId,
					UserId = UserLogin.CurrentUser.UserId,
					FirstRegisterUserId = UserLogin.CurrentUser.UserId,
					RegisterDate = now2,
					AppType = Configuration.AppType,
					FirstRegisterDate = now2
				};
			}
			DbSet<CrmProjectInformations_Lang> crmProjectInformations_Lang = _dbTbl.CrmProjectInformations_Lang;
			ParameterExpression val = Expression.Parameter(typeof(CrmProjectInformations_Lang), "c");
			List<CommonMultiLanguageViewModel> list = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmProjectInformations_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmProjectInformations_Lang>)Enumerable.ToList<CrmProjectInformations_Lang>((IEnumerable<CrmProjectInformations_Lang>)Queryable.Where<CrmProjectInformations_Lang>((IQueryable<CrmProjectInformations_Lang>)crmProjectInformations_Lang, Expression.Lambda<Func<CrmProjectInformations_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass16_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }))), (Func<CrmProjectInformations_Lang, CommonMultiLanguageViewModel>)((CrmProjectInformations_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.FieldValue,
				LanguageId = item.LanguageID
			})));
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = crmProjectInformationsViewModel.FieldValue,
				LanguageId = result
			});
			crmProjectInformationsViewModel.UserId = UserLogin.CurrentUser.UserId;
			crmProjectInformationsViewModel.Year1 = short.Parse(Financial.Get().Id.ToString());
			crmProjectInformationsViewModel.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
			crmProjectInformationsViewModel.RegisterDate = now;
			crmProjectInformationsViewModel.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			crmProjectInformationsViewModel.AppType = Configuration.AppType;
			crmProjectInformationsViewModel.Mode = mode;
			crmProjectInformationsViewModel.LanguageID = result;
			crmProjectInformationsViewModel.FieldValue = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangId)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangId)).Value : "");
			crmProjectInformationsViewModel.FieldValue_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangId))));
			GetFieldTitle(prjId);
			int.TryParse(crmProjectInformationsViewModel.ValueType.ToString(), out var result2);
			GetFieldValue(result2, "", crmProjectInformationsViewModel.FieldTitleId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		SetUserNameDateForProjectInformation(crmProjectInformationsViewModel);
		return View(crmProjectInformationsViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmProjectInformationTreeDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult InsertEdit(CrmProjectInformationsViewModel model)
	{
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass17_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass17_0();
		CS_0024_003C_003E8__locals0.model = model;
		string text = "";
		int num = 0;
		try
		{
			GetFieldTitle(CS_0024_003C_003E8__locals0.model.ProjectId);
			int.TryParse(CS_0024_003C_003E8__locals0.model.ValueType.ToString(), out var result);
			GetFieldValue(result, "", CS_0024_003C_003E8__locals0.model.FieldTitleId);
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangId);
			if (CS_0024_003C_003E8__locals0.defLangId <= 0)
			{
				CS_0024_003C_003E8__locals0.defLangId = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (!base.ModelState.IsValid)
			{
				base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
			else
			{
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				if (CS_0024_003C_003E8__locals0.model.ValueType == 0 && CS_0024_003C_003E8__locals0.model.Mode == "Value")
				{
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.FieldValue_Lang))
					{
						list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.FieldValue_Lang);
					}
					list.Add(new CommonMultiLanguageViewModel
					{
						Value = CS_0024_003C_003E8__locals0.model.FieldValue,
						LanguageId = lCID
					});
				}
				if (CS_0024_003C_003E8__locals0.model.ValueType == 0 && CS_0024_003C_003E8__locals0.model.Mode == "Value")
				{
					if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.FieldValue))
					{
						text = text + Messages.CheckEmptyProjectInformationTreeFieldValue + "|";
						num++;
					}
					else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.model.FieldValue, list))
					{
						text = text + Messages.CheckProjectInformationTreeFieldValueLang + "<br>";
						num++;
					}
				}
				try
				{
					if (num == 0)
					{
						if (CS_0024_003C_003E8__locals0.model.ProjectInformationId > 0)
						{
							string text2 = "";
							text2 = ((CS_0024_003C_003E8__locals0.model.ValueType != 0 || !(CS_0024_003C_003E8__locals0.model.Mode == "Value")) ? CS_0024_003C_003E8__locals0.model.FieldValue : ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangId)).Value : null));
							CrmProjectInformations crmProjectInformations = _dbTbl.CrmProjectInformations.Find(CS_0024_003C_003E8__locals0.model.ProjectInformationId);
							if (crmProjectInformations != null)
							{
								crmProjectInformations.UserId = UserLogin.CurrentUser.UserId;
								DateTime dateTime = (crmProjectInformations.RegisterDate = DateTime.Now);
								crmProjectInformations.RegisterDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
								crmProjectInformations.AppType = Configuration.AppType;
								crmProjectInformations.Year1 = short.Parse(Financial.Get().Id.ToString());
								crmProjectInformations.Month1 = short.Parse(dateTime.ToString("MM", new PersianCulture()));
								crmProjectInformations.FieldValue = text2;
								_dbTbl.Entry(crmProjectInformations).State = EntityState.Modified;
								_dbTbl.Configuration.ValidateOnSaveEnabled = false;
								_dbTbl.SaveChanges();
								_dbTbl.Configuration.ValidateOnSaveEnabled = true;
								if (CS_0024_003C_003E8__locals0.model.ValueType == 0 && CS_0024_003C_003E8__locals0.model.Mode == "Value")
								{
									using List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangId))).GetEnumerator();
									while (enumerator.MoveNext())
									{
										_003C_003Ec__DisplayClass17_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass17_1();
										CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
										CS_0024_003C_003E8__locals1.lang = enumerator.Current;
										DbSet<CrmProjectInformations_Lang> crmProjectInformations_Lang = _dbTbl.CrmProjectInformations_Lang;
										ParameterExpression val = Expression.Parameter(typeof(CrmProjectInformations_Lang), "c");
										CrmProjectInformations_Lang crmProjectInformations_Lang2 = Queryable.FirstOrDefault<CrmProjectInformations_Lang>((IQueryable<CrmProjectInformations_Lang>)crmProjectInformations_Lang, Expression.Lambda<Func<CrmProjectInformations_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass17_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass17_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
										if (crmProjectInformations_Lang2 != null)
										{
											crmProjectInformations_Lang2.FieldValue = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
											_dbTbl.Entry(crmProjectInformations_Lang2).State = EntityState.Modified;
											_dbTbl.SaveChanges();
											continue;
										}
										CrmProjectInformations_Lang entity = new CrmProjectInformations_Lang
										{
											LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
											ProjectInformationId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.ProjectInformationId,
											FieldValue = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
										};
										_dbTbl.CrmProjectInformations_Lang.Add(entity);
										_dbTbl.SaveChanges();
									}
								}
								base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
								CS_0024_003C_003E8__locals0.model.RegisterDate = crmProjectInformations.RegisterDate;
								CS_0024_003C_003E8__locals0.model.FirstRegisterUserId = crmProjectInformations.FirstRegisterUserId;
								CS_0024_003C_003E8__locals0.model.UserId = crmProjectInformations.UserId;
								CS_0024_003C_003E8__locals0.model.FirstRegisterDate = crmProjectInformations.FirstRegisterDate;
								CS_0024_003C_003E8__locals0.model.AppType = crmProjectInformations.AppType;
							}
						}
						else
						{
							DateTime now2 = DateTime.Now;
							CrmProjectInformations crmProjectInformations2 = new CrmProjectInformations
							{
								UserId = UserLogin.CurrentUser.UserId,
								FirstRegisterUserId = UserLogin.CurrentUser.UserId,
								FirstRegisterDate = now2,
								FirstRegisterDatePersian = now2.ToString("yyyyMMdd", new PersianCulture()),
								RegisterDate = now2,
								RegisterDatePersian = now2.ToString("yyyyMMdd", new PersianCulture()),
								AppType = Configuration.AppType,
								Year1 = short.Parse(Financial.Get().Id.ToString()),
								Month1 = short.Parse(now2.ToString("MM", new PersianCulture())),
								GUId = System.Guid.NewGuid(),
								LanguageID = CS_0024_003C_003E8__locals0.defLangId,
								FieldValue = CS_0024_003C_003E8__locals0.model.FieldValue,
								ProjectId = CS_0024_003C_003E8__locals0.model.ProjectId,
								FieldTitleId = CS_0024_003C_003E8__locals0.model.FieldTitleId,
								Description = CS_0024_003C_003E8__locals0.model.Description
							};
							_dbTbl.CrmProjectInformations.Add(crmProjectInformations2);
							_dbTbl.Configuration.ValidateOnSaveEnabled = false;
							_dbTbl.SaveChanges();
							_dbTbl.Configuration.ValidateOnSaveEnabled = true;
							base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
							CS_0024_003C_003E8__locals0.model.ProjectInformationId = crmProjectInformations2.ProjectInformationId;
							CS_0024_003C_003E8__locals0.model.RegisterDate = crmProjectInformations2.RegisterDate;
							CS_0024_003C_003E8__locals0.model.FirstRegisterUserId = crmProjectInformations2.FirstRegisterUserId;
							CS_0024_003C_003E8__locals0.model.UserId = crmProjectInformations2.UserId;
							CS_0024_003C_003E8__locals0.model.FirstRegisterDate = crmProjectInformations2.FirstRegisterDate;
							CS_0024_003C_003E8__locals0.model.AppType = crmProjectInformations2.AppType;
						}
					}
				}
				catch (DbEntityValidationException e)
				{
					ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
					text = Messages.frmErrorMessage;
				}
			}
		}
		catch (DbEntityValidationException e2)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e2);
			base.ViewBag.Error = Messages.frmErrorMessage;
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
			base.ViewBag.Error = Messages.frmErrorMessage;
		}
		base.ViewBag.Error = text;
		SetUserNameDateForProjectInformation(CS_0024_003C_003E8__locals0.model);
		return View(CS_0024_003C_003E8__locals0.model);
	}

	[AjaxOnly]
	public JsonResult GetFieldTitle(int prjId)
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
			List<CRMspSelectProjectInformationFieldTitle_Result> list2 = Enumerable.ToList<CRMspSelectProjectInformationFieldTitle_Result>((IEnumerable<CRMspSelectProjectInformationFieldTitle_Result>)_db.CRMspSelectProjectInformationFieldTitle(prjId, lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectProjectInformationFieldTitle_Result, SelectListItem>((IEnumerable<CRMspSelectProjectInformationFieldTitle_Result>)list2, (Func<CRMspSelectProjectInformationFieldTitle_Result, SelectListItem>)((CRMspSelectProjectInformationFieldTitle_Result item) => new SelectListItem
			{
				Text = item.FieldTitle,
				Value = item.ProjectFieldTitleId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.FieldTitleList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetFieldValue(int valueType, string val, int fieldTitleId)
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			switch (valueType)
			{
			case 1:
			{
				List<CRMspSelectAndSearchCompany_Result> list3 = Enumerable.ToList<CRMspSelectAndSearchCompany_Result>((IEnumerable<CRMspSelectAndSearchCompany_Result>)_db.CRMspSelectAndSearchCompany(val, UserLogin.CurrentUser.UserId, lCID, result, result2));
				list.AddRange(Enumerable.Select<CRMspSelectAndSearchCompany_Result, SelectListItem>((IEnumerable<CRMspSelectAndSearchCompany_Result>)list3, (Func<CRMspSelectAndSearchCompany_Result, SelectListItem>)((CRMspSelectAndSearchCompany_Result item) => new SelectListItem
				{
					Text = item.TitleCompany + "     |" + Labels.PrjInfoTreeIECmpNumber + ": " + item.cmpNumber + "     |" + Labels.PrjInfoTreeIECmpProvince + ": " + item.Province + "     |" + Labels.PrjInfoTreeIECmpCity + ": " + item.City,
					Value = item.CompanyID.ToString(),
					Selected = false
				})));
				break;
			}
			case 2:
			{
				List<CRMspSelectAndSearchCompanyPersons_Result> list4 = Enumerable.ToList<CRMspSelectAndSearchCompanyPersons_Result>((IEnumerable<CRMspSelectAndSearchCompanyPersons_Result>)_db.CRMspSelectAndSearchCompanyPersons(val, UserLogin.CurrentUser.UserId, lCID, result, result2));
				list.AddRange(Enumerable.Select<CRMspSelectAndSearchCompanyPersons_Result, SelectListItem>((IEnumerable<CRMspSelectAndSearchCompanyPersons_Result>)list4, (Func<CRMspSelectAndSearchCompanyPersons_Result, SelectListItem>)((CRMspSelectAndSearchCompanyPersons_Result item) => new SelectListItem
				{
					Text = item.Person + ((!string.IsNullOrEmpty(item.PersonJob)) ? ("     |" + Labels.PrjInfoTreeIEPersonJob + ": " + item.PersonJob) : "") + " |" + Labels.PrjInfoTreeIETitleCompany + ": " + item.TitleCompany,
					Value = item.CompanyPersonID.ToString(),
					Selected = false
				})));
				break;
			}
			case 3:
			{
				List<CRMspSelectAndSearchProjectDefualtValue_Result> list2 = Enumerable.ToList<CRMspSelectAndSearchProjectDefualtValue_Result>((IEnumerable<CRMspSelectAndSearchProjectDefualtValue_Result>)_db.CRMspSelectAndSearchProjectDefualtValue(fieldTitleId, val, lCID, result));
				list.AddRange(Enumerable.Select<CRMspSelectAndSearchProjectDefualtValue_Result, SelectListItem>((IEnumerable<CRMspSelectAndSearchProjectDefualtValue_Result>)list2, (Func<CRMspSelectAndSearchProjectDefualtValue_Result, SelectListItem>)((CRMspSelectAndSearchProjectDefualtValue_Result item) => new SelectListItem
				{
					Text = item.DefualtValue + ((!string.IsNullOrEmpty(item.Description)) ? ("     |" + Labels.PrjInfoTreeIEValueDescription + ": " + item.Description) : ""),
					Value = item.ProjectDefualtValueId.ToString(),
					Selected = false
				})));
				break;
			}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.FieldValueList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmProjectInformationTree", ActionName = "actDelete")]
	[AjaxOnly]
	public string DeleteFieldWithValue(int prjInfoId)
	{
		string text = "";
		try
		{
			if (!UserLogin.IsUserAccess("frmProjectInformationTree", "actDelete", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			if (prjInfoId > 0)
			{
				if (_db.CRMspDeleteProjectInformationsRecord(prjInfoId) > 0)
				{
					return "1";
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

	public ActionResult DefineProjectFieldTitle(int position)
	{
		string text = "";
		string text2 = "";
		switch (position)
		{
		case 1:
			text = "frmProjectInformationTree";
			text2 = "actDefineProjectFieldTitle";
			break;
		case 2:
			text = "frmProjectInformationTreeDataEntry";
			text2 = "actGotoDefineFieldTitle";
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
		return View();
	}

	[AjaxOnly]
	[HttpPost]
	public JsonResult GetProjectFieldTitleInfo(int currentId)
	{
		_ = UserLogin.CurrentUser.UserId;
		CrmProjectFieldTitleViewModel crmProjectFieldTitleViewModel = new CrmProjectFieldTitleViewModel();
		crmProjectFieldTitleViewModel.Info = new CRMspSelectProjectFieldTitle_Result();
		crmProjectFieldTitleViewModel.GridList = new List<CRMspSelectProjectFieldTitle_Result>();
		crmProjectFieldTitleViewModel.CurrentId = 0;
		crmProjectFieldTitleViewModel.NextId = -1;
		crmProjectFieldTitleViewModel.PreviousId = -1;
		crmProjectFieldTitleViewModel.FirstId = -1;
		crmProjectFieldTitleViewModel.LastId = -1;
		crmProjectFieldTitleViewModel.Message = "";
		crmProjectFieldTitleViewModel.IsFind = false;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectProjectFieldTitle_Result> list = Enumerable.ToList<CRMspSelectProjectFieldTitle_Result>((IEnumerable<CRMspSelectProjectFieldTitle_Result>)_db.CRMspSelectProjectFieldTitle(lCID, result));
			if (Enumerable.Any<CRMspSelectProjectFieldTitle_Result>((IEnumerable<CRMspSelectProjectFieldTitle_Result>)list))
			{
				crmProjectFieldTitleViewModel.IsFind = true;
				crmProjectFieldTitleViewModel.Message = "";
				crmProjectFieldTitleViewModel.CurrentId = 0;
				crmProjectFieldTitleViewModel.NextId = -1;
				crmProjectFieldTitleViewModel.PreviousId = -1;
				crmProjectFieldTitleViewModel.FirstId = -1;
				crmProjectFieldTitleViewModel.LastId = -1;
				if (list.Count == 1)
				{
					crmProjectFieldTitleViewModel.FirstId = -1;
					crmProjectFieldTitleViewModel.LastId = -1;
				}
				else
				{
					crmProjectFieldTitleViewModel.FirstId = Enumerable.FirstOrDefault<CRMspSelectProjectFieldTitle_Result>((IEnumerable<CRMspSelectProjectFieldTitle_Result>)list).ProjectFieldTitleId;
					crmProjectFieldTitleViewModel.LastId = Enumerable.LastOrDefault<CRMspSelectProjectFieldTitle_Result>((IEnumerable<CRMspSelectProjectFieldTitle_Result>)list).ProjectFieldTitleId;
				}
				CRMspSelectProjectFieldTitle_Result cRMspSelectProjectFieldTitle_Result = ((currentId <= 0) ? Enumerable.LastOrDefault<CRMspSelectProjectFieldTitle_Result>((IEnumerable<CRMspSelectProjectFieldTitle_Result>)list) : list.Find((CRMspSelectProjectFieldTitle_Result c) => c.ProjectFieldTitleId == currentId));
				if (cRMspSelectProjectFieldTitle_Result != null)
				{
					crmProjectFieldTitleViewModel.Info = cRMspSelectProjectFieldTitle_Result;
					crmProjectFieldTitleViewModel.GridList = list;
					crmProjectFieldTitleViewModel.CurrentId = cRMspSelectProjectFieldTitle_Result.ProjectFieldTitleId;
					if (crmProjectFieldTitleViewModel.Info != null)
					{
						if (string.IsNullOrEmpty(crmProjectFieldTitleViewModel.Info.AppType))
						{
							crmProjectFieldTitleViewModel.Info.AppType = Configuration.AppType;
						}
						crmProjectFieldTitleViewModel.Info.AppType = Configuration.GetAppType(crmProjectFieldTitleViewModel.Info.AppType);
						string text = crmProjectFieldTitleViewModel.Info.FirstRegisterUser ?? "";
						string text2 = (crmProjectFieldTitleViewModel.Info.FirstRegisterDate.HasValue ? crmProjectFieldTitleViewModel.Info.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
						crmProjectFieldTitleViewModel.Info.FirstRegisterDatePersian = text + " (" + text2 + ")";
						string text3 = crmProjectFieldTitleViewModel.Info.EditUser ?? "";
						_ = crmProjectFieldTitleViewModel.Info.RegisterDate;
						string text4 = crmProjectFieldTitleViewModel.Info.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
						crmProjectFieldTitleViewModel.Info.RegisterDatePersian = text3 + " (" + Labels.AppType + ":" + crmProjectFieldTitleViewModel.Info.AppType + ")  (" + text4 + ")";
					}
					foreach (CRMspSelectProjectFieldTitle_Result grid in crmProjectFieldTitleViewModel.GridList)
					{
						if (string.IsNullOrEmpty(grid.AppType))
						{
							grid.AppType = Configuration.AppType;
						}
						grid.AppType = Configuration.GetAppType(grid.AppType);
						string text5 = grid.FirstRegisterUser ?? "";
						string text6 = (grid.FirstRegisterDate.HasValue ? grid.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
						grid.FirstRegisterDatePersian = text5 + " (" + text6 + ")";
						string text7 = grid.EditUser ?? "";
						_ = grid.RegisterDate;
						string text8 = grid.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
						grid.RegisterDatePersian = text7 + " (" + Labels.AppType + ":" + grid.AppType + ")  (" + text8 + ")";
					}
					if (list.Count == 1)
					{
						crmProjectFieldTitleViewModel.NextId = -1;
						crmProjectFieldTitleViewModel.PreviousId = -1;
					}
					else
					{
						CRMspSelectProjectFieldTitle_Result next = Lists.GetNext(list, cRMspSelectProjectFieldTitle_Result);
						if (next != null)
						{
							crmProjectFieldTitleViewModel.NextId = next.ProjectFieldTitleId;
						}
						CRMspSelectProjectFieldTitle_Result previous = Lists.GetPrevious(list, cRMspSelectProjectFieldTitle_Result);
						if (previous != null)
						{
							crmProjectFieldTitleViewModel.PreviousId = previous.ProjectFieldTitleId;
						}
					}
				}
				else
				{
					crmProjectFieldTitleViewModel.IsFind = false;
					crmProjectFieldTitleViewModel.Message = Messages.ErrorNotFound;
					crmProjectFieldTitleViewModel.CurrentId = -1;
					crmProjectFieldTitleViewModel.NextId = -1;
					crmProjectFieldTitleViewModel.PreviousId = -1;
					crmProjectFieldTitleViewModel.FirstId = -1;
					crmProjectFieldTitleViewModel.LastId = -1;
					crmProjectFieldTitleViewModel.Info = null;
				}
			}
			else
			{
				crmProjectFieldTitleViewModel.IsFind = false;
				crmProjectFieldTitleViewModel.Message = Messages.ErrorNotFound;
				crmProjectFieldTitleViewModel.CurrentId = -1;
				crmProjectFieldTitleViewModel.NextId = -1;
				crmProjectFieldTitleViewModel.PreviousId = -1;
				crmProjectFieldTitleViewModel.FirstId = -1;
				crmProjectFieldTitleViewModel.LastId = -1;
				crmProjectFieldTitleViewModel.Info = null;
			}
		}
		catch (DbEntityValidationException ex)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
			crmProjectFieldTitleViewModel.Message = Messages.frmErrorMessage + "<br />" + ((Exception)(object)ex).Message;
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			crmProjectFieldTitleViewModel.Message = Messages.frmErrorMessage + "<br />" + ex2.Message;
		}
		return Json(crmProjectFieldTitleViewModel, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult ProjectFieldTitle()
	{
		return Json(ProjectFieldTitleItem(), JsonRequestBehavior.AllowGet);
	}

	public List<CRMspSelectProjectFieldTitle_Result> ProjectFieldTitleItem()
	{
		List<CRMspSelectProjectFieldTitle_Result> list = new List<CRMspSelectProjectFieldTitle_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			list = Enumerable.ToList<CRMspSelectProjectFieldTitle_Result>((IEnumerable<CRMspSelectProjectFieldTitle_Result>)_db.CRMspSelectProjectFieldTitle(lCID, result));
			foreach (CRMspSelectProjectFieldTitle_Result item in list)
			{
				if (string.IsNullOrEmpty(item.AppType))
				{
					item.AppType = Configuration.AppType;
				}
				item.AppType = Configuration.GetAppType(item.AppType);
				string text = item.FirstRegisterUser ?? "";
				string text2 = (item.FirstRegisterDate.HasValue ? item.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
				item.FirstRegisterDatePersian = text + " (" + text2 + ")";
				string text3 = item.EditUser ?? "";
				_ = item.RegisterDate;
				string text4 = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				item.RegisterDatePersian = text3 + " (" + Labels.AppType + ":" + item.AppType + ")  (" + text4 + ")";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public ActionResult ProjectFieldTitle_Read([DataSourceRequest] DataSourceRequest request)
	{
		List<CRMspSelectProjectFieldTitle_Result> enumerable = ProjectFieldTitleItem();
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmDefineProjectFieldTitle", ActionName = "actInsert,actEdit")]
	public ActionResult DefineProjectFieldTitleInsertEdit(int fieldid = 0)
	{
		_003C_003Ec__DisplayClass26_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass26_0();
		CS_0024_003C_003E8__locals0.fieldid = fieldid;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangId = Thread.CurrentThread.CurrentCulture.LCID;
		DateTime now = DateTime.Now;
		CrmProjectFieldTitleLanguageViewModel crmProjectFieldTitleLanguageViewModel = new CrmProjectFieldTitleLanguageViewModel();
		string value = "";
		string value2 = "";
		try
		{
			if (CS_0024_003C_003E8__locals0.fieldid > 0)
			{
				if (!UserLogin.IsUserAccess("frmDefineProjectFieldTitle", "actEdit"))
				{
					return RedirectToAction("Login", "Account", (object)new
					{
						area = "",
						d = DateTime.Now
					});
				}
				CrmProjectFieldTitle crmProjectFieldTitle = _dbTbl.CrmProjectFieldTitle.Find(CS_0024_003C_003E8__locals0.fieldid);
				if (crmProjectFieldTitle == null)
				{
					crmProjectFieldTitle = new CrmProjectFieldTitle();
					crmProjectFieldTitle.ProjectFieldTitleId = 0;
				}
				else
				{
					crmProjectFieldTitleLanguageViewModel.LanguageID = crmProjectFieldTitle.LanguageID;
					crmProjectFieldTitleLanguageViewModel.FirstRegisterUserId = crmProjectFieldTitle.FirstRegisterUserId;
					crmProjectFieldTitleLanguageViewModel.FirstRegisterDate = crmProjectFieldTitle.FirstRegisterDate;
					crmProjectFieldTitleLanguageViewModel.FirstRegisterDatePersian = crmProjectFieldTitle.FirstRegisterDatePersian;
					crmProjectFieldTitleLanguageViewModel.ProjectId = crmProjectFieldTitle.ProjectId;
					crmProjectFieldTitleLanguageViewModel.GUId = crmProjectFieldTitle.GUId;
					crmProjectFieldTitleLanguageViewModel.IsDefualtField = crmProjectFieldTitle.IsDefualtField;
					crmProjectFieldTitleLanguageViewModel.ValueType = crmProjectFieldTitle.ValueType;
					crmProjectFieldTitleLanguageViewModel.SortCode = crmProjectFieldTitle.SortCode;
					crmProjectFieldTitleLanguageViewModel.ProjectFieldTitleId = crmProjectFieldTitle.ProjectFieldTitleId;
					value = crmProjectFieldTitle.FieldTitle;
					value2 = crmProjectFieldTitle.Description;
				}
			}
			else
			{
				if (!UserLogin.IsUserAccess("frmDefineProjectFieldTitle", "actInsert"))
				{
					return RedirectToAction("Login", "Account", (object)new
					{
						area = "",
						d = DateTime.Now
					});
				}
				crmProjectFieldTitleLanguageViewModel.ProjectFieldTitleId = 0;
				crmProjectFieldTitleLanguageViewModel.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
				crmProjectFieldTitleLanguageViewModel.FirstRegisterDate = now;
				crmProjectFieldTitleLanguageViewModel.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			}
			DbSet<CrmProjectFieldTitle_Lang> crmProjectFieldTitle_Lang = _dbTbl.CrmProjectFieldTitle_Lang;
			ParameterExpression val = Expression.Parameter(typeof(CrmProjectFieldTitle_Lang), "c");
			List<CrmProjectFieldTitle_Lang> list = Enumerable.ToList<CrmProjectFieldTitle_Lang>((IEnumerable<CrmProjectFieldTitle_Lang>)Queryable.Where<CrmProjectFieldTitle_Lang>((IQueryable<CrmProjectFieldTitle_Lang>)crmProjectFieldTitle_Lang, Expression.Lambda<Func<CrmProjectFieldTitle_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass26_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmProjectFieldTitle_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmProjectFieldTitle_Lang>)list, (Func<CrmProjectFieldTitle_Lang, CommonMultiLanguageViewModel>)((CrmProjectFieldTitle_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.FieldTitle,
				LanguageId = item.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = value,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmProjectFieldTitle_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmProjectFieldTitle_Lang>)list, (Func<CrmProjectFieldTitle_Lang, CommonMultiLanguageViewModel>)((CrmProjectFieldTitle_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.Description,
				LanguageId = item.LanguageID
			})));
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = value2,
				LanguageId = result
			});
			crmProjectFieldTitleLanguageViewModel.LanguageID = result;
			crmProjectFieldTitleLanguageViewModel.AppType = Configuration.AppType;
			crmProjectFieldTitleLanguageViewModel.UserId = UserLogin.CurrentUser.UserId;
			crmProjectFieldTitleLanguageViewModel.RegisterDate = now;
			crmProjectFieldTitleLanguageViewModel.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			crmProjectFieldTitleLanguageViewModel.FieldTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangId)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangId)).Value : "");
			crmProjectFieldTitleLanguageViewModel.FieldTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangId))));
			crmProjectFieldTitleLanguageViewModel.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangId)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangId)).Value : "");
			crmProjectFieldTitleLanguageViewModel.Description_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangId))));
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			base.ViewBag.Error = Messages.frmErrorMessage;
		}
		GetValueType();
		return View(crmProjectFieldTitleLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefineProjectFieldTitleDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult DefineProjectFieldTitleInsertEdit(CrmProjectFieldTitleLanguageViewModel model)
	{
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass27_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass27_0();
		CS_0024_003C_003E8__locals0.model = model;
		GetValueType();
		string text = "";
		int num = 0;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangId);
			if (CS_0024_003C_003E8__locals0.defLangId <= 0)
			{
				CS_0024_003C_003E8__locals0.defLangId = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (base.ModelState.IsValid)
			{
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.FieldTitle_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.FieldTitle_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.FieldTitle,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.Description_Lang))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.Description_Lang);
				}
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.Description,
					LanguageId = lCID
				});
				if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.FieldTitle))
				{
					text = text + Messages.CheckEmptyProjectInformationFieldTitle + "|";
					num++;
				}
				else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.model.FieldTitle, list))
				{
					text = text + Messages.CheckProjectInformationFieldTitleLang + "<br>";
					num++;
				}
				try
				{
					if (num == 0)
					{
						if (CS_0024_003C_003E8__locals0.model.ProjectFieldTitleId > 0)
						{
							CrmProjectFieldTitle crmProjectFieldTitle = _dbTbl.CrmProjectFieldTitle.Find(CS_0024_003C_003E8__locals0.model.ProjectFieldTitleId);
							if (crmProjectFieldTitle != null)
							{
								crmProjectFieldTitle.UserId = UserLogin.CurrentUser.UserId;
								DateTime dateTime = (crmProjectFieldTitle.RegisterDate = DateTime.Now);
								crmProjectFieldTitle.RegisterDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
								crmProjectFieldTitle.AppType = Configuration.AppType;
								crmProjectFieldTitle.Year1 = short.Parse(Financial.Get().Id.ToString());
								crmProjectFieldTitle.Month1 = short.Parse(dateTime.ToString("MM", new PersianCulture()));
								crmProjectFieldTitle.FieldTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangId)).Value : null);
								crmProjectFieldTitle.Description = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangId)).Value : null);
								crmProjectFieldTitle.IsDefualtField = CS_0024_003C_003E8__locals0.model.IsDefualtField;
								crmProjectFieldTitle.ValueType = CS_0024_003C_003E8__locals0.model.ValueType;
								crmProjectFieldTitle.SortCode = CS_0024_003C_003E8__locals0.model.SortCode;
								_dbTbl.Entry(crmProjectFieldTitle).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangId))).GetEnumerator())
								{
									while (enumerator.MoveNext())
									{
										_003C_003Ec__DisplayClass27_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass27_1();
										CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
										CS_0024_003C_003E8__locals1.lang = enumerator.Current;
										DbSet<CrmProjectFieldTitle_Lang> crmProjectFieldTitle_Lang = _dbTbl.CrmProjectFieldTitle_Lang;
										ParameterExpression val = Expression.Parameter(typeof(CrmProjectFieldTitle_Lang), "c");
										CrmProjectFieldTitle_Lang crmProjectFieldTitle_Lang2 = Queryable.FirstOrDefault<CrmProjectFieldTitle_Lang>((IQueryable<CrmProjectFieldTitle_Lang>)crmProjectFieldTitle_Lang, Expression.Lambda<Func<CrmProjectFieldTitle_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass27_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass27_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
										if (crmProjectFieldTitle_Lang2 != null)
										{
											crmProjectFieldTitle_Lang2.FieldTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
											crmProjectFieldTitle_Lang2.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
											_dbTbl.Entry(crmProjectFieldTitle_Lang2).State = EntityState.Modified;
											_dbTbl.SaveChanges();
											continue;
										}
										CrmProjectFieldTitle_Lang entity = new CrmProjectFieldTitle_Lang
										{
											LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
											ProjectFieldTitleId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.ProjectFieldTitleId,
											FieldTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
											Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
										};
										_dbTbl.CrmProjectFieldTitle_Lang.Add(entity);
										_dbTbl.SaveChanges();
									}
								}
								CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmProjectFieldTitle");
								base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
							}
							else
							{
								text = Messages.ErrorNotFound;
							}
						}
						else
						{
							DateTime now2 = DateTime.Now;
							CrmProjectFieldTitle crmProjectFieldTitle2 = new CrmProjectFieldTitle
							{
								UserId = UserLogin.CurrentUser.UserId,
								FirstRegisterUserId = UserLogin.CurrentUser.UserId,
								FirstRegisterDate = now2,
								FirstRegisterDatePersian = now2.ToString("yyyyMMdd", new PersianCulture()),
								RegisterDate = now2,
								RegisterDatePersian = now2.ToString("yyyyMMdd", new PersianCulture()),
								AppType = Configuration.AppType,
								Year1 = short.Parse(Financial.Get().Id.ToString()),
								Month1 = short.Parse(now2.ToString("MM", new PersianCulture())),
								GUId = System.Guid.NewGuid(),
								LanguageID = CS_0024_003C_003E8__locals0.defLangId,
								FieldTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangId)).Value : null),
								Description = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangId)).Value : null),
								IsDefualtField = CS_0024_003C_003E8__locals0.model.IsDefualtField,
								ValueType = CS_0024_003C_003E8__locals0.model.ValueType,
								SortCode = CS_0024_003C_003E8__locals0.model.SortCode
							};
							_dbTbl.CrmProjectFieldTitle.Add(crmProjectFieldTitle2);
							_dbTbl.SaveChanges();
							foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangId))))
							{
								CrmProjectFieldTitle_Lang entity2 = new CrmProjectFieldTitle_Lang
								{
									LanguageID = lang.LanguageID,
									ProjectFieldTitleId = crmProjectFieldTitle2.ProjectFieldTitleId,
									FieldTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
									Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null)
								};
								_dbTbl.CrmProjectFieldTitle_Lang.Add(entity2);
								_dbTbl.SaveChanges();
							}
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmProjectFieldTitle");
							base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
						}
					}
				}
				catch (DbEntityValidationException e)
				{
					ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
					text = Messages.frmErrorMessage;
				}
				catch (Exception ex)
				{
					ErrorSignal.FromCurrentContext().Raise(ex);
					text = Messages.frmErrorMessage + "<br/>" + ex.Message;
				}
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			base.ViewBag.Error = Messages.frmErrorMessage;
		}
		base.ViewBag.Error = text;
		return View(CS_0024_003C_003E8__locals0.model);
	}

	[DynamicAuthorize(ControllerName = "frmDefineProjectFieldTitle", ActionName = "actDelete")]
	[AjaxOnly]
	public string DefineProjectFieldTitleDelete(int fieldId)
	{
		string result = "";
		try
		{
			if (!UserLogin.IsUserAccess("frmDefineProjectFieldTitle", "actDelete", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			if (fieldId > 0)
			{
				CrmProjectFieldTitle crmProjectFieldTitle = _dbTbl.CrmProjectFieldTitle.Find(fieldId);
				if (crmProjectFieldTitle != null)
				{
					try
					{
						if (crmProjectFieldTitle.CrmProjectInformations.Count > 0 || crmProjectFieldTitle.CrmProjectDefualtValue.Count > 0)
						{
							result = Messages.RedundancyMessage;
						}
						else if (_db.CRMspDeleteCrmProjectFieldTitle(fieldId) > 0)
						{
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmProjectFieldTitle");
							result = "1";
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
	public JsonResult GetValueType()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			SelectListItem item = new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "",
				Selected = true
			};
			list.Add(item);
			item = new SelectListItem
			{
				Text = Labels.ProjectFiledValueTypeFree,
				Value = "0",
				Selected = false
			};
			list.Add(item);
			item = new SelectListItem
			{
				Text = Labels.ProjectFiledValueTypeFromCmpInfo,
				Value = "1",
				Selected = false
			};
			list.Add(item);
			item = new SelectListItem
			{
				Text = Labels.ProjectFiledValueTypeFromPrsInfo,
				Value = "2",
				Selected = false
			};
			list.Add(item);
			item = new SelectListItem
			{
				Text = Labels.ProjectFiledValueTypeFromDefault,
				Value = "3",
				Selected = false
			};
			list.Add(item);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ValueTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public ActionResult DefineDefaultValue(int position, int fieldTitleId, string fieldTitle)
	{
		string text = "";
		string text2 = "";
		switch (position)
		{
		case 1:
			text = "frmProjectInformationTreeDataEntry";
			text2 = "actGotoDefineDefualtValue";
			break;
		case 2:
			text = "frmDefineProjectFieldTitle";
			text2 = "actDefineDefualtValue";
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
		base.ViewBag.FieldTitleId = fieldTitleId;
		base.ViewBag.FieldTitle = fieldTitle;
		return View();
	}

	[AjaxOnly]
	[HttpPost]
	public JsonResult GetProjectDefaultInfo(int currentId, int fieldTitleId)
	{
		_ = UserLogin.CurrentUser.UserId;
		CrmDefineDefaultValueViewModel crmDefineDefaultValueViewModel = new CrmDefineDefaultValueViewModel();
		crmDefineDefaultValueViewModel.Info = new CRMspSelectProjectDefualtValue_Result();
		crmDefineDefaultValueViewModel.GridList = new List<CRMspSelectProjectDefualtValue_Result>();
		crmDefineDefaultValueViewModel.CurrentId = 0;
		crmDefineDefaultValueViewModel.NextId = -1;
		crmDefineDefaultValueViewModel.PreviousId = -1;
		crmDefineDefaultValueViewModel.FirstId = -1;
		crmDefineDefaultValueViewModel.LastId = -1;
		crmDefineDefaultValueViewModel.Message = "";
		crmDefineDefaultValueViewModel.IsFind = false;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectProjectDefualtValue_Result> list = Enumerable.ToList<CRMspSelectProjectDefualtValue_Result>((IEnumerable<CRMspSelectProjectDefualtValue_Result>)_db.CRMspSelectProjectDefualtValue(fieldTitleId, lCID, result));
			if (Enumerable.Any<CRMspSelectProjectDefualtValue_Result>((IEnumerable<CRMspSelectProjectDefualtValue_Result>)list))
			{
				crmDefineDefaultValueViewModel.IsFind = true;
				crmDefineDefaultValueViewModel.Message = "";
				crmDefineDefaultValueViewModel.CurrentId = 0;
				crmDefineDefaultValueViewModel.NextId = -1;
				crmDefineDefaultValueViewModel.PreviousId = -1;
				crmDefineDefaultValueViewModel.FirstId = -1;
				crmDefineDefaultValueViewModel.LastId = -1;
				if (list.Count == 1)
				{
					crmDefineDefaultValueViewModel.FirstId = -1;
					crmDefineDefaultValueViewModel.LastId = -1;
				}
				else
				{
					crmDefineDefaultValueViewModel.FirstId = Enumerable.FirstOrDefault<CRMspSelectProjectDefualtValue_Result>((IEnumerable<CRMspSelectProjectDefualtValue_Result>)list).ProjectDefualtValueId;
					crmDefineDefaultValueViewModel.LastId = Enumerable.LastOrDefault<CRMspSelectProjectDefualtValue_Result>((IEnumerable<CRMspSelectProjectDefualtValue_Result>)list).ProjectDefualtValueId;
				}
				CRMspSelectProjectDefualtValue_Result cRMspSelectProjectDefualtValue_Result = ((currentId <= 0) ? Enumerable.LastOrDefault<CRMspSelectProjectDefualtValue_Result>((IEnumerable<CRMspSelectProjectDefualtValue_Result>)list) : list.Find((CRMspSelectProjectDefualtValue_Result c) => c.ProjectDefualtValueId == currentId));
				if (cRMspSelectProjectDefualtValue_Result != null)
				{
					crmDefineDefaultValueViewModel.Info = cRMspSelectProjectDefualtValue_Result;
					crmDefineDefaultValueViewModel.GridList = list;
					crmDefineDefaultValueViewModel.CurrentId = cRMspSelectProjectDefualtValue_Result.ProjectDefualtValueId;
					if (crmDefineDefaultValueViewModel.Info != null)
					{
						if (string.IsNullOrEmpty(crmDefineDefaultValueViewModel.Info.AppType))
						{
							crmDefineDefaultValueViewModel.Info.AppType = Configuration.AppType;
						}
						crmDefineDefaultValueViewModel.Info.AppType = Configuration.GetAppType(crmDefineDefaultValueViewModel.Info.AppType);
						string text = crmDefineDefaultValueViewModel.Info.FirstRegisterUser ?? "";
						string text2 = (crmDefineDefaultValueViewModel.Info.FirstRegisterDate.HasValue ? crmDefineDefaultValueViewModel.Info.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
						crmDefineDefaultValueViewModel.Info.FirstRegisterDatePersian = text + " (" + text2 + ")";
						string text3 = crmDefineDefaultValueViewModel.Info.EditUser ?? "";
						_ = crmDefineDefaultValueViewModel.Info.RegisterDate;
						string text4 = crmDefineDefaultValueViewModel.Info.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
						crmDefineDefaultValueViewModel.Info.RegisterDatePersian = text3 + " (" + Labels.AppType + ":" + crmDefineDefaultValueViewModel.Info.AppType + ")  (" + text4 + ")";
					}
					foreach (CRMspSelectProjectDefualtValue_Result grid in crmDefineDefaultValueViewModel.GridList)
					{
						if (string.IsNullOrEmpty(grid.AppType))
						{
							grid.AppType = Configuration.AppType;
						}
						grid.AppType = Configuration.GetAppType(grid.AppType);
						string text5 = grid.FirstRegisterUser ?? "";
						string text6 = (grid.FirstRegisterDate.HasValue ? grid.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
						grid.FirstRegisterDatePersian = text5 + " (" + text6 + ")";
						string text7 = grid.EditUser ?? "";
						_ = grid.RegisterDate;
						string text8 = grid.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
						grid.RegisterDatePersian = text7 + " (" + Labels.AppType + ":" + grid.AppType + ")  (" + text8 + ")";
					}
					if (list.Count == 1)
					{
						crmDefineDefaultValueViewModel.NextId = -1;
						crmDefineDefaultValueViewModel.PreviousId = -1;
					}
					else
					{
						CRMspSelectProjectDefualtValue_Result next = Lists.GetNext(list, cRMspSelectProjectDefualtValue_Result);
						if (next != null)
						{
							crmDefineDefaultValueViewModel.NextId = next.ProjectDefualtValueId;
						}
						CRMspSelectProjectDefualtValue_Result previous = Lists.GetPrevious(list, cRMspSelectProjectDefualtValue_Result);
						if (previous != null)
						{
							crmDefineDefaultValueViewModel.PreviousId = previous.ProjectDefualtValueId;
						}
					}
				}
				else
				{
					crmDefineDefaultValueViewModel.IsFind = false;
					crmDefineDefaultValueViewModel.Message = Messages.ErrorNotFound;
					crmDefineDefaultValueViewModel.CurrentId = -1;
					crmDefineDefaultValueViewModel.NextId = -1;
					crmDefineDefaultValueViewModel.PreviousId = -1;
					crmDefineDefaultValueViewModel.FirstId = -1;
					crmDefineDefaultValueViewModel.LastId = -1;
					crmDefineDefaultValueViewModel.Info = null;
				}
			}
			else
			{
				crmDefineDefaultValueViewModel.IsFind = false;
				crmDefineDefaultValueViewModel.Message = Messages.ErrorNotFound;
				crmDefineDefaultValueViewModel.CurrentId = -1;
				crmDefineDefaultValueViewModel.NextId = -1;
				crmDefineDefaultValueViewModel.PreviousId = -1;
				crmDefineDefaultValueViewModel.FirstId = -1;
				crmDefineDefaultValueViewModel.LastId = -1;
				crmDefineDefaultValueViewModel.Info = null;
			}
		}
		catch (DbEntityValidationException ex)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
			crmDefineDefaultValueViewModel.Message = Messages.frmErrorMessage + "<br />" + ((Exception)(object)ex).Message;
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			crmDefineDefaultValueViewModel.Message = Messages.frmErrorMessage + "<br />" + ex2.Message;
		}
		return Json(crmDefineDefaultValueViewModel, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult DefaultValue(int fieldTitleId)
	{
		return Json(DefaultValueItem(fieldTitleId), JsonRequestBehavior.AllowGet);
	}

	public List<CRMspSelectProjectDefualtValue_Result> DefaultValueItem(int fieldTitleId)
	{
		List<CRMspSelectProjectDefualtValue_Result> list = new List<CRMspSelectProjectDefualtValue_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			list = Enumerable.ToList<CRMspSelectProjectDefualtValue_Result>((IEnumerable<CRMspSelectProjectDefualtValue_Result>)_db.CRMspSelectProjectDefualtValue(fieldTitleId, lCID, result));
			foreach (CRMspSelectProjectDefualtValue_Result item in list)
			{
				if (string.IsNullOrEmpty(item.AppType))
				{
					item.AppType = Configuration.AppType;
				}
				item.AppType = Configuration.GetAppType(item.AppType);
				string text = item.FirstRegisterUser ?? "";
				string text2 = (item.FirstRegisterDate.HasValue ? item.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
				item.FirstRegisterDatePersian = text + " (" + text2 + ")";
				string text3 = item.EditUser ?? "";
				_ = item.RegisterDate;
				string text4 = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				item.RegisterDatePersian = text3 + " (" + Labels.AppType + ":" + item.AppType + ")  (" + text4 + ")";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public ActionResult DefaultValue_Read([DataSourceRequest] DataSourceRequest request, int fieldTitleId)
	{
		List<CRMspSelectProjectDefualtValue_Result> enumerable = DefaultValueItem(fieldTitleId);
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmDefineBaseInfoI", ActionName = "actInsert,actEdit")]
	public ActionResult DefineDefaultValueInsertEdit(int fieldTitleId, int fieldid = 0)
	{
		_003C_003Ec__DisplayClass35_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass35_0();
		CS_0024_003C_003E8__locals0.fieldid = fieldid;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangId = Thread.CurrentThread.CurrentCulture.LCID;
		DateTime now = DateTime.Now;
		CrmProjectDefualtValueLanguageViewModel crmProjectDefualtValueLanguageViewModel = new CrmProjectDefualtValueLanguageViewModel();
		string value = "";
		string value2 = "";
		try
		{
			if (CS_0024_003C_003E8__locals0.fieldid > 0)
			{
				if (!UserLogin.IsUserAccess("frmDefineBaseInfoI", "actEdit"))
				{
					return RedirectToAction("Login", "Account", (object)new
					{
						area = "",
						d = DateTime.Now
					});
				}
				CrmProjectDefualtValue crmProjectDefualtValue = _dbTbl.CrmProjectDefualtValue.Find(CS_0024_003C_003E8__locals0.fieldid);
				if (crmProjectDefualtValue == null)
				{
					crmProjectDefualtValue = new CrmProjectDefualtValue();
					crmProjectDefualtValue.ProjectDefualtValueId = 0;
					crmProjectDefualtValue.FieldTitleId = fieldTitleId;
				}
				else
				{
					crmProjectDefualtValueLanguageViewModel.LanguageID = crmProjectDefualtValue.LanguageID;
					crmProjectDefualtValueLanguageViewModel.FirstRegisterUserId = crmProjectDefualtValue.FirstRegisterUserId;
					crmProjectDefualtValueLanguageViewModel.FirstRegisterDate = crmProjectDefualtValue.FirstRegisterDate;
					crmProjectDefualtValueLanguageViewModel.FirstRegisterDatePersian = crmProjectDefualtValue.FirstRegisterDatePersian;
					crmProjectDefualtValueLanguageViewModel.GUId = crmProjectDefualtValue.GUId;
					crmProjectDefualtValueLanguageViewModel.FieldTitleId = crmProjectDefualtValue.FieldTitleId;
					crmProjectDefualtValueLanguageViewModel.ProjectDefualtValueId = crmProjectDefualtValue.ProjectDefualtValueId;
					value = crmProjectDefualtValue.DefualtValue;
					value2 = crmProjectDefualtValue.Description;
				}
			}
			else
			{
				if (!UserLogin.IsUserAccess("frmDefineBaseInfoI", "actInsert"))
				{
					return RedirectToAction("Login", "Account", (object)new
					{
						area = "",
						d = DateTime.Now
					});
				}
				crmProjectDefualtValueLanguageViewModel.ProjectDefualtValueId = 0;
				crmProjectDefualtValueLanguageViewModel.FieldTitleId = fieldTitleId;
				crmProjectDefualtValueLanguageViewModel.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
				crmProjectDefualtValueLanguageViewModel.FirstRegisterDate = now;
				crmProjectDefualtValueLanguageViewModel.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			}
			DbSet<CrmProjectDefualtValue_Lang> crmProjectDefualtValue_Lang = _dbTbl.CrmProjectDefualtValue_Lang;
			ParameterExpression val = Expression.Parameter(typeof(CrmProjectDefualtValue_Lang), "c");
			List<CrmProjectDefualtValue_Lang> list = Enumerable.ToList<CrmProjectDefualtValue_Lang>((IEnumerable<CrmProjectDefualtValue_Lang>)Queryable.Where<CrmProjectDefualtValue_Lang>((IQueryable<CrmProjectDefualtValue_Lang>)crmProjectDefualtValue_Lang, Expression.Lambda<Func<CrmProjectDefualtValue_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass35_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmProjectDefualtValue_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmProjectDefualtValue_Lang>)list, (Func<CrmProjectDefualtValue_Lang, CommonMultiLanguageViewModel>)((CrmProjectDefualtValue_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.DefualtValue,
				LanguageId = item.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = value,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmProjectDefualtValue_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmProjectDefualtValue_Lang>)list, (Func<CrmProjectDefualtValue_Lang, CommonMultiLanguageViewModel>)((CrmProjectDefualtValue_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.Description,
				LanguageId = item.LanguageID
			})));
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = value2,
				LanguageId = result
			});
			crmProjectDefualtValueLanguageViewModel.LanguageID = result;
			crmProjectDefualtValueLanguageViewModel.AppType = Configuration.AppType;
			crmProjectDefualtValueLanguageViewModel.UserId = UserLogin.CurrentUser.UserId;
			crmProjectDefualtValueLanguageViewModel.RegisterDate = now;
			crmProjectDefualtValueLanguageViewModel.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			crmProjectDefualtValueLanguageViewModel.DefualtValue = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangId)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangId)).Value : "");
			crmProjectDefualtValueLanguageViewModel.DefualtValue_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangId))));
			crmProjectDefualtValueLanguageViewModel.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangId)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangId)).Value : "");
			crmProjectDefualtValueLanguageViewModel.Description_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangId))));
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			base.ViewBag.Error = Messages.frmErrorMessage;
		}
		return View(crmProjectDefualtValueLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefineBaseInfoIDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult DefineDefaultValueInsertEdit(CrmProjectDefualtValueLanguageViewModel model)
	{
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass36_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass36_0();
		CS_0024_003C_003E8__locals0.model = model;
		string text = "";
		int num = 0;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangId);
			if (CS_0024_003C_003E8__locals0.defLangId <= 0)
			{
				CS_0024_003C_003E8__locals0.defLangId = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (base.ModelState.IsValid)
			{
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.DefualtValue_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.DefualtValue_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.model.DefualtValue,
					LanguageId = lCID
				});
				if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.DefualtValue))
				{
					text = text + Messages.CheckEmptyProjectDefualtValue + "|";
					num++;
				}
				else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.model.DefualtValue, list))
				{
					text = text + Messages.CheckProjectDefualtValueLang + "<br>";
					num++;
				}
				try
				{
					if (num == 0)
					{
						if (CS_0024_003C_003E8__locals0.model.ProjectDefualtValueId > 0)
						{
							CrmProjectDefualtValue crmProjectDefualtValue = _dbTbl.CrmProjectDefualtValue.Find(CS_0024_003C_003E8__locals0.model.ProjectDefualtValueId);
							if (crmProjectDefualtValue != null)
							{
								crmProjectDefualtValue.UserId = UserLogin.CurrentUser.UserId;
								DateTime dateTime = (crmProjectDefualtValue.RegisterDate = DateTime.Now);
								crmProjectDefualtValue.RegisterDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
								crmProjectDefualtValue.AppType = Configuration.AppType;
								crmProjectDefualtValue.Year1 = short.Parse(Financial.Get().Id.ToString());
								crmProjectDefualtValue.Month1 = short.Parse(dateTime.ToString("MM", new PersianCulture()));
								crmProjectDefualtValue.DefualtValue = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangId)).Value : null);
								crmProjectDefualtValue.Description = CS_0024_003C_003E8__locals0.model.Description;
								_dbTbl.Entry(crmProjectDefualtValue).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangId))).GetEnumerator())
								{
									while (enumerator.MoveNext())
									{
										_003C_003Ec__DisplayClass36_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass36_1();
										CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
										CS_0024_003C_003E8__locals1.lang = enumerator.Current;
										DbSet<CrmProjectDefualtValue_Lang> crmProjectDefualtValue_Lang = _dbTbl.CrmProjectDefualtValue_Lang;
										ParameterExpression val = Expression.Parameter(typeof(CrmProjectDefualtValue_Lang), "c");
										CrmProjectDefualtValue_Lang crmProjectDefualtValue_Lang2 = Queryable.FirstOrDefault<CrmProjectDefualtValue_Lang>((IQueryable<CrmProjectDefualtValue_Lang>)crmProjectDefualtValue_Lang, Expression.Lambda<Func<CrmProjectDefualtValue_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass36_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass36_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
										if (crmProjectDefualtValue_Lang2 != null)
										{
											crmProjectDefualtValue_Lang2.DefualtValue = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
											_dbTbl.Entry(crmProjectDefualtValue_Lang2).State = EntityState.Modified;
											_dbTbl.SaveChanges();
											continue;
										}
										CrmProjectDefualtValue_Lang entity = new CrmProjectDefualtValue_Lang
										{
											LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
											ProjectDefualtValueId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.ProjectDefualtValueId,
											DefualtValue = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
										};
										_dbTbl.CrmProjectDefualtValue_Lang.Add(entity);
										_dbTbl.SaveChanges();
									}
								}
								base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
							}
							else
							{
								text = Messages.ErrorNotFound;
							}
						}
						else
						{
							DateTime now2 = DateTime.Now;
							CrmProjectDefualtValue crmProjectDefualtValue2 = new CrmProjectDefualtValue
							{
								UserId = UserLogin.CurrentUser.UserId,
								FirstRegisterUserId = UserLogin.CurrentUser.UserId,
								FirstRegisterDate = now2,
								FirstRegisterDatePersian = now2.ToString("yyyyMMdd", new PersianCulture()),
								RegisterDate = now2,
								RegisterDatePersian = now2.ToString("yyyyMMdd", new PersianCulture()),
								AppType = Configuration.AppType,
								Year1 = short.Parse(Financial.Get().Id.ToString()),
								Month1 = short.Parse(now2.ToString("MM", new PersianCulture())),
								GUId = System.Guid.NewGuid(),
								LanguageID = CS_0024_003C_003E8__locals0.defLangId,
								DefualtValue = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangId)).Value : null),
								Description = CS_0024_003C_003E8__locals0.model.Description,
								FieldTitleId = CS_0024_003C_003E8__locals0.model.FieldTitleId
							};
							_dbTbl.CrmProjectDefualtValue.Add(crmProjectDefualtValue2);
							_dbTbl.SaveChanges();
							foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangId))))
							{
								CrmProjectDefualtValue_Lang entity2 = new CrmProjectDefualtValue_Lang
								{
									LanguageID = lang.LanguageID,
									ProjectDefualtValueId = crmProjectDefualtValue2.ProjectDefualtValueId,
									DefualtValue = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null)
								};
								_dbTbl.CrmProjectDefualtValue_Lang.Add(entity2);
								_dbTbl.SaveChanges();
							}
							base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
						}
					}
				}
				catch (DbEntityValidationException e)
				{
					ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
					text = Messages.frmErrorMessage;
				}
				catch (Exception ex)
				{
					ErrorSignal.FromCurrentContext().Raise(ex);
					text = Messages.frmErrorMessage + "<br/>" + ex.Message;
				}
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			base.ViewBag.Error = Messages.frmErrorMessage;
		}
		base.ViewBag.Error = text;
		return View(CS_0024_003C_003E8__locals0.model);
	}

	[DynamicAuthorize(ControllerName = "frmDefineBaseInfoI", ActionName = "actDelete")]
	[AjaxOnly]
	public string DefineDefaultValueDelete(int fieldId)
	{
		string result = "";
		try
		{
			if (!UserLogin.IsUserAccess("frmDefineBaseInfoI", "actDelete", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			if (fieldId > 0)
			{
				_003C_003Ec__DisplayClass37_0 _003C_003Ec__DisplayClass37_ = new _003C_003Ec__DisplayClass37_0();
				_003C_003Ec__DisplayClass37_.model = _dbTbl.CrmProjectDefualtValue.Find(fieldId);
				if (_003C_003Ec__DisplayClass37_.model != null)
				{
					try
					{
						_003C_003Ec__DisplayClass37_.value = _003C_003Ec__DisplayClass37_.model.ProjectDefualtValueId.ToString();
						DbSet<CrmProjectInformations> crmProjectInformations = _dbTbl.CrmProjectInformations;
						ParameterExpression val = Expression.Parameter(typeof(CrmProjectInformations), "m");
						if (Queryable.FirstOrDefault<CrmProjectInformations>((IQueryable<CrmProjectInformations>)crmProjectInformations, Expression.Lambda<Func<CrmProjectInformations, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass37_, typeof(_003C_003Ec__DisplayClass37_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass37_, typeof(_003C_003Ec__DisplayClass37_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
						{
							result = Messages.RedundancyMessage;
						}
						else if (_db.CRMspDeleteCrmProjectDefualtValue(fieldId) > 0)
						{
							result = "1";
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

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		base.Dispose(disposing);
	}
}

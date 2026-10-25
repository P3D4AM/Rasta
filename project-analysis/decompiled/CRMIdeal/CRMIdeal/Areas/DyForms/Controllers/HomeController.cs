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

namespace CRMIdeal.Areas.DyForms.Controllers;

public class HomeController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public CrmDyFormLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__17;

		public Func<Languages, bool> _003C_003E9__44;

		internal bool _003CInsertEdit_003Eb__3(CRMspDySelectFormWorkflows_Result m)
		{
			return m.FormWorkflowId == vm.WorkflowId;
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

		internal bool _003CInsertEdit_003Eb__17(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__44(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_1
	{
		public CrmDyForms model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass10_1 CS_0024_003C_003E8__locals1;

		internal bool _003CInsertEdit_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

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
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_3
	{
		public CRMspDySelectForms_Result chFrm;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass17_0
	{
		public int formId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public int fromId;

		public int currLangID;

		public CrmDyFormLanguageViewModel vm;

		internal bool _003CInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__24(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__25(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__27(CRMspDySelectFormWorkflows_Result m)
		{
			return m.FormWorkflowId == vm.WorkflowId;
		}
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actdyDefineForms")]
	public ActionResult Index()
	{
		return View();
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actdyDefineForms")]
	public JsonResult GetDyForm(int frmCurrentId)
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
		CurrentDyFormViewModel currentDyFormViewModel = new CurrentDyFormViewModel();
		try
		{
			CRMspDySelectForms_Result cRMspDySelectForms_Result = Enumerable.FirstOrDefault<CRMspDySelectForms_Result>((IEnumerable<CRMspDySelectForms_Result>)_db.CRMspDySelectForms(frmCurrentId, 0, lCID, result, result2));
			if (cRMspDySelectForms_Result != null)
			{
				currentDyFormViewModel.IsFind = true;
				currentDyFormViewModel.Message = "";
				cRMspDySelectForms_Result.FormCenterInfoJs = DyForm.GetFormCenterInfoJsByFormId(cRMspDySelectForms_Result.FormId);
				currentDyFormViewModel.DyForm = cRMspDySelectForms_Result;
				currentDyFormViewModel.DyFormCurrentId = cRMspDySelectForms_Result.FormId;
				_ = cRMspDySelectForms_Result.FirstRegisterDate;
				cRMspDySelectForms_Result.FirstRegisterDatePersian = cRMspDySelectForms_Result.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				_ = cRMspDySelectForms_Result.RegisterDate;
				cRMspDySelectForms_Result.RegisterDatePersian = cRMspDySelectForms_Result.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				if (string.IsNullOrEmpty(cRMspDySelectForms_Result.AppType))
				{
					cRMspDySelectForms_Result.AppType = Configuration.AppType;
				}
				cRMspDySelectForms_Result.AppType = Configuration.GetAppType(cRMspDySelectForms_Result.AppType);
			}
			else
			{
				currentDyFormViewModel.IsFind = false;
				currentDyFormViewModel.Message = Messages.ErrorNotFound;
				currentDyFormViewModel.DyForm = null;
				currentDyFormViewModel.DyFormCurrentId = -1;
			}
		}
		catch (DbEntityValidationException ex)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
			currentDyFormViewModel.Message = Messages.frmErrorMessage + "<br />" + ((Exception)(object)ex).Message;
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			currentDyFormViewModel.Message = Messages.frmErrorMessage + "<br />" + ex2.Message;
		}
		JsonResult jsonResult = Json(currentDyFormViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<TreeViewItemModel> GetFormsList()
	{
		List<TreeViewItemModel> list = new List<TreeViewItemModel>();
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
			List<CRMspDySelectFormsTree_Result> list2 = Enumerable.ToList<CRMspDySelectFormsTree_Result>((IEnumerable<CRMspDySelectFormsTree_Result>)_db.CRMspDySelectFormsTree(UserLogin.CurrentUser.UserId, lCID, result, result2));
			if (list2 != null && Enumerable.Any<CRMspDySelectFormsTree_Result>((IEnumerable<CRMspDySelectFormsTree_Result>)list2))
			{
				foreach (CRMspDySelectFormsTree_Result item4 in list2)
				{
					if (string.IsNullOrWhiteSpace(item4.FOSysPartShow))
					{
						item4.FOSysPartId = null;
					}
				}
			}
			List<CRMspDySelectFormsTree_Result> list3 = Enumerable.ToList<CRMspDySelectFormsTree_Result>(Enumerable.Where<CRMspDySelectFormsTree_Result>((IEnumerable<CRMspDySelectFormsTree_Result>)list2, (Func<CRMspDySelectFormsTree_Result, bool>)((CRMspDySelectFormsTree_Result c) => c.ParentFormId == 0)));
			List<CRMspDySelectFormsTree_Result> list4 = Enumerable.ToList<CRMspDySelectFormsTree_Result>(Enumerable.Where<CRMspDySelectFormsTree_Result>((IEnumerable<CRMspDySelectFormsTree_Result>)list3, (Func<CRMspDySelectFormsTree_Result, bool>)((CRMspDySelectFormsTree_Result m) => m.CrmSysPartId.HasValue && !m.FOSysPartId.HasValue)));
			if (Enumerable.Any<CRMspDySelectFormsTree_Result>((IEnumerable<CRMspDySelectFormsTree_Result>)list4))
			{
				List<TreeViewItemModel> list5 = new List<TreeViewItemModel>();
				TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
				treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", "-2|0|-2|-2"));
				treeViewItemModel.Id = "-2|0|-2|-2";
				treeViewItemModel.Text = Labels.DyFrmCrmSysPart;
				treeViewItemModel.ImageUrl = "";
				foreach (CRMspDySelectFormsTree_Result item3 in list4)
				{
					TreeViewItemModel mainTree3 = new TreeViewItemModel();
					mainTree3.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", (item3.CrmSysPartId.HasValue ? item3.CrmSysPartId.ToString() : "0") + "|0|-1|-1"));
					mainTree3.Id = (item3.CrmSysPartId.HasValue ? item3.CrmSysPartId.ToString() : "0") + "|0|-1|-1";
					mainTree3.Text = item3.CrmSysPartTitle;
					mainTree3.ImageUrl = "";
					if (Enumerable.FirstOrDefault<TreeViewItemModel>((IEnumerable<TreeViewItemModel>)list5, (Func<TreeViewItemModel, bool>)((TreeViewItemModel m) => m.Id == mainTree3.Id)) != null)
					{
						continue;
					}
					List<CRMspDySelectFormsTree_Result> list6 = Enumerable.ToList<CRMspDySelectFormsTree_Result>(Enumerable.Where<CRMspDySelectFormsTree_Result>((IEnumerable<CRMspDySelectFormsTree_Result>)list4, (Func<CRMspDySelectFormsTree_Result, bool>)((CRMspDySelectFormsTree_Result c) => c.CrmSysPartId == item3.CrmSysPartId)));
					List<TreeViewItemModel> list7 = new List<TreeViewItemModel>();
					foreach (CRMspDySelectFormsTree_Result subfrmIn3 in list6)
					{
						TreeViewItemModel treeViewItemModel2 = new TreeViewItemModel();
						treeViewItemModel2.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", (subfrmIn3.CrmSysPartId.HasValue ? subfrmIn3.CrmSysPartId.ToString() : "0") + "|" + (subfrmIn3.FOSysPartId.HasValue ? subfrmIn3.FOSysPartId.ToString() : "0") + "|" + subfrmIn3.ParentFormId + "|" + subfrmIn3.FormId));
						treeViewItemModel2.Id = (subfrmIn3.CrmSysPartId.HasValue ? subfrmIn3.CrmSysPartId.ToString() : "0") + "|" + (subfrmIn3.FOSysPartId.HasValue ? subfrmIn3.FOSysPartId.ToString() : "0") + "|" + subfrmIn3.ParentFormId + "|" + subfrmIn3.FormId;
						treeViewItemModel2.Text = subfrmIn3.FormName;
						treeViewItemModel2.ImageUrl = "";
						List<CRMspDySelectFormsTree_Result> list8 = Enumerable.ToList<CRMspDySelectFormsTree_Result>(Enumerable.Where<CRMspDySelectFormsTree_Result>((IEnumerable<CRMspDySelectFormsTree_Result>)list2, (Func<CRMspDySelectFormsTree_Result, bool>)((CRMspDySelectFormsTree_Result c) => c.ParentFormId == subfrmIn3.FormId)));
						List<TreeViewItemModel> list9 = new List<TreeViewItemModel>();
						foreach (CRMspDySelectFormsTree_Result item5 in list8)
						{
							TreeViewItemModel treeViewItemModel3 = new TreeViewItemModel();
							treeViewItemModel3.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", (item5.CrmSysPartId.HasValue ? item5.CrmSysPartId.ToString() : "0") + "|" + (item5.FOSysPartId.HasValue ? item5.FOSysPartId.ToString() : "0") + "|" + item5.ParentFormId + "|" + item5.FormId));
							treeViewItemModel3.Id = (item5.CrmSysPartId.HasValue ? item5.CrmSysPartId.ToString() : "0") + "|" + (item5.FOSysPartId.HasValue ? item5.FOSysPartId.ToString() : "0") + "|" + item5.ParentFormId + "|" + item5.FormId;
							treeViewItemModel3.Text = item5.FormName;
							treeViewItemModel3.ImageUrl = "";
							treeViewItemModel3.Items = null;
							list9.Add(treeViewItemModel3);
						}
						treeViewItemModel2.Items = new List<TreeViewItemModel>(list9);
						list7.Add(treeViewItemModel2);
					}
					mainTree3.Items = new List<TreeViewItemModel>(list7);
					list5.Add(mainTree3);
				}
				treeViewItemModel.Items = new List<TreeViewItemModel>(list5);
				list.Add(treeViewItemModel);
			}
			List<CRMspDySelectFormsTree_Result> list10 = Enumerable.ToList<CRMspDySelectFormsTree_Result>(Enumerable.Where<CRMspDySelectFormsTree_Result>((IEnumerable<CRMspDySelectFormsTree_Result>)list3, (Func<CRMspDySelectFormsTree_Result, bool>)((CRMspDySelectFormsTree_Result m) => !m.CrmSysPartId.HasValue && m.FOSysPartId.HasValue)));
			if (Enumerable.Any<CRMspDySelectFormsTree_Result>((IEnumerable<CRMspDySelectFormsTree_Result>)list10))
			{
				List<TreeViewItemModel> list11 = new List<TreeViewItemModel>();
				TreeViewItemModel treeViewItemModel4 = new TreeViewItemModel();
				treeViewItemModel4.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", "0|-2|-2|-2"));
				treeViewItemModel4.Id = "0|-2|-2|-2";
				treeViewItemModel4.Text = Labels.DyFrmFOSysPart;
				treeViewItemModel4.ImageUrl = "";
				foreach (CRMspDySelectFormsTree_Result item2 in list10)
				{
					TreeViewItemModel mainTree2 = new TreeViewItemModel();
					mainTree2.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", "0|" + (item2.FOSysPartId.HasValue ? item2.FOSysPartId.ToString() : "0") + "|-1|-1"));
					mainTree2.Id = "0|" + (item2.FOSysPartId.HasValue ? item2.FOSysPartId.ToString() : "0") + "|-1|-1";
					mainTree2.Text = item2.FOSysPartTitle;
					mainTree2.ImageUrl = "";
					if (Enumerable.FirstOrDefault<TreeViewItemModel>((IEnumerable<TreeViewItemModel>)list11, (Func<TreeViewItemModel, bool>)((TreeViewItemModel m) => m.Id == mainTree2.Id)) != null)
					{
						continue;
					}
					List<CRMspDySelectFormsTree_Result> list12 = Enumerable.ToList<CRMspDySelectFormsTree_Result>(Enumerable.Where<CRMspDySelectFormsTree_Result>((IEnumerable<CRMspDySelectFormsTree_Result>)list10, (Func<CRMspDySelectFormsTree_Result, bool>)((CRMspDySelectFormsTree_Result c) => c.FOSysPartId == item2.FOSysPartId)));
					List<TreeViewItemModel> list13 = new List<TreeViewItemModel>();
					foreach (CRMspDySelectFormsTree_Result subfrmIn2 in list12)
					{
						TreeViewItemModel treeViewItemModel5 = new TreeViewItemModel();
						treeViewItemModel5.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", (subfrmIn2.CrmSysPartId.HasValue ? subfrmIn2.CrmSysPartId.ToString() : "0") + "|" + (subfrmIn2.FOSysPartId.HasValue ? subfrmIn2.FOSysPartId.ToString() : "0") + "|" + subfrmIn2.ParentFormId + "|" + subfrmIn2.FormId));
						treeViewItemModel5.Id = (subfrmIn2.CrmSysPartId.HasValue ? subfrmIn2.CrmSysPartId.ToString() : "0") + "|" + (subfrmIn2.FOSysPartId.HasValue ? subfrmIn2.FOSysPartId.ToString() : "0") + "|" + subfrmIn2.ParentFormId + "|" + subfrmIn2.FormId;
						treeViewItemModel5.Text = subfrmIn2.FormName;
						treeViewItemModel5.ImageUrl = "";
						List<CRMspDySelectFormsTree_Result> list14 = Enumerable.ToList<CRMspDySelectFormsTree_Result>(Enumerable.Where<CRMspDySelectFormsTree_Result>((IEnumerable<CRMspDySelectFormsTree_Result>)list2, (Func<CRMspDySelectFormsTree_Result, bool>)((CRMspDySelectFormsTree_Result c) => c.ParentFormId == subfrmIn2.FormId)));
						List<TreeViewItemModel> list15 = new List<TreeViewItemModel>();
						foreach (CRMspDySelectFormsTree_Result item6 in list14)
						{
							TreeViewItemModel treeViewItemModel6 = new TreeViewItemModel();
							treeViewItemModel6.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", (item6.CrmSysPartId.HasValue ? item6.CrmSysPartId.ToString() : "0") + "|" + (item6.FOSysPartId.HasValue ? item6.FOSysPartId.ToString() : "0") + "|" + item6.ParentFormId + "|" + item6.FormId));
							treeViewItemModel6.Id = (item6.CrmSysPartId.HasValue ? item6.CrmSysPartId.ToString() : "0") + "|" + (item6.FOSysPartId.HasValue ? item6.FOSysPartId.ToString() : "0") + "|" + item6.ParentFormId + "|" + item6.FormId;
							treeViewItemModel6.Text = item6.FormName;
							treeViewItemModel6.ImageUrl = "";
							treeViewItemModel6.Items = null;
							list15.Add(treeViewItemModel6);
						}
						treeViewItemModel5.Items = new List<TreeViewItemModel>(list15);
						list13.Add(treeViewItemModel5);
					}
					mainTree2.Items = new List<TreeViewItemModel>(list13);
					list11.Add(mainTree2);
				}
				treeViewItemModel4.Items = new List<TreeViewItemModel>(list11);
				list.Add(treeViewItemModel4);
			}
			List<CRMspDySelectFormsTree_Result> list16 = Enumerable.ToList<CRMspDySelectFormsTree_Result>(Enumerable.Where<CRMspDySelectFormsTree_Result>((IEnumerable<CRMspDySelectFormsTree_Result>)list3, (Func<CRMspDySelectFormsTree_Result, bool>)((CRMspDySelectFormsTree_Result m) => m.CrmSysPartId.HasValue && m.FOSysPartId.HasValue)));
			if (Enumerable.Any<CRMspDySelectFormsTree_Result>((IEnumerable<CRMspDySelectFormsTree_Result>)list16))
			{
				List<TreeViewItemModel> list17 = new List<TreeViewItemModel>();
				TreeViewItemModel treeViewItemModel7 = new TreeViewItemModel();
				treeViewItemModel7.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", "-2|-2|-2|-2"));
				treeViewItemModel7.Id = "-2|-2|-2|-2";
				treeViewItemModel7.Text = Labels.DyFrmBothSysPart;
				treeViewItemModel7.ImageUrl = "";
				foreach (CRMspDySelectFormsTree_Result item in list16)
				{
					TreeViewItemModel mainTree = new TreeViewItemModel();
					mainTree.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", (item.CrmSysPartId.HasValue ? item.CrmSysPartId.ToString() : "0") + "|" + (item.FOSysPartId.HasValue ? item.FOSysPartId.ToString() : "0") + "|-1|-1"));
					mainTree.Id = (item.CrmSysPartId.HasValue ? item.CrmSysPartId.ToString() : "0") + "|" + (item.FOSysPartId.HasValue ? item.FOSysPartId.ToString() : "0") + "|-1|-1";
					mainTree.Text = item.CrmSysPartTitle + "-" + item.FOSysPartTitle;
					mainTree.ImageUrl = "";
					if (Enumerable.FirstOrDefault<TreeViewItemModel>((IEnumerable<TreeViewItemModel>)list17, (Func<TreeViewItemModel, bool>)((TreeViewItemModel m) => m.Id == mainTree.Id)) != null)
					{
						continue;
					}
					List<CRMspDySelectFormsTree_Result> list18 = Enumerable.ToList<CRMspDySelectFormsTree_Result>(Enumerable.Where<CRMspDySelectFormsTree_Result>((IEnumerable<CRMspDySelectFormsTree_Result>)list16, (Func<CRMspDySelectFormsTree_Result, bool>)((CRMspDySelectFormsTree_Result c) => c.FOSysPartId == item.FOSysPartId && c.CrmSysPartId == item.CrmSysPartId)));
					List<TreeViewItemModel> list19 = new List<TreeViewItemModel>();
					foreach (CRMspDySelectFormsTree_Result subfrmIn in list18)
					{
						TreeViewItemModel treeViewItemModel8 = new TreeViewItemModel();
						treeViewItemModel8.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", (subfrmIn.CrmSysPartId.HasValue ? subfrmIn.CrmSysPartId.ToString() : "0") + "|" + (subfrmIn.FOSysPartId.HasValue ? subfrmIn.FOSysPartId.ToString() : "0") + "|" + subfrmIn.ParentFormId + "|" + subfrmIn.FormId));
						treeViewItemModel8.Id = (subfrmIn.CrmSysPartId.HasValue ? subfrmIn.CrmSysPartId.ToString() : "0") + "|" + (subfrmIn.FOSysPartId.HasValue ? subfrmIn.FOSysPartId.ToString() : "0") + "|" + subfrmIn.ParentFormId + "|" + subfrmIn.FormId;
						treeViewItemModel8.Text = subfrmIn.FormName;
						treeViewItemModel8.ImageUrl = "";
						List<CRMspDySelectFormsTree_Result> list20 = Enumerable.ToList<CRMspDySelectFormsTree_Result>(Enumerable.Where<CRMspDySelectFormsTree_Result>((IEnumerable<CRMspDySelectFormsTree_Result>)list2, (Func<CRMspDySelectFormsTree_Result, bool>)((CRMspDySelectFormsTree_Result c) => c.ParentFormId == subfrmIn.FormId)));
						List<TreeViewItemModel> list21 = new List<TreeViewItemModel>();
						foreach (CRMspDySelectFormsTree_Result item7 in list20)
						{
							TreeViewItemModel treeViewItemModel9 = new TreeViewItemModel();
							treeViewItemModel9.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", (item7.CrmSysPartId.HasValue ? item7.CrmSysPartId.ToString() : "0") + "|" + (item7.FOSysPartId.HasValue ? item7.FOSysPartId.ToString() : "0") + "|" + item7.ParentFormId + "|" + item7.FormId));
							treeViewItemModel9.Id = (item7.CrmSysPartId.HasValue ? item7.CrmSysPartId.ToString() : "0") + "|" + (item7.FOSysPartId.HasValue ? item7.FOSysPartId.ToString() : "0") + "|" + item7.ParentFormId + "|" + item7.FormId;
							treeViewItemModel9.Text = item7.FormName;
							treeViewItemModel9.ImageUrl = "";
							treeViewItemModel9.Items = null;
							list21.Add(treeViewItemModel9);
						}
						treeViewItemModel8.Items = new List<TreeViewItemModel>(list21);
						list19.Add(treeViewItemModel8);
					}
					mainTree.Items = new List<TreeViewItemModel>(list19);
					list17.Add(mainTree);
				}
				treeViewItemModel7.Items = new List<TreeViewItemModel>(list17);
				list.Add(treeViewItemModel7);
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
	public ActionResult _PartialFormsTree()
	{
		try
		{
			base.ViewBag.FormsTree = GetFormsList();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView();
	}

	[AjaxOnly]
	public JsonResult GetFields(int formId)
	{
		List<CRMspDySelectFormFields_Result> list = new List<CRMspDySelectFormFields_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			list = Enumerable.ToList<CRMspDySelectFormFields_Result>((IEnumerable<CRMspDySelectFormFields_Result>)_db.CRMspDySelectFormFields(0, formId, null, lCID, result));
			foreach (CRMspDySelectFormFields_Result item in list)
			{
				item.FieldType = ((!item.FieldTypeId.HasValue) ? (Labels.lblMainTitle + " " + Labels.DyFrmGroupOfField) : item.FieldType);
				if (item.LinkDbObjectId.GetValueOrDefault() == 0)
				{
					continue;
				}
				string text = "";
				if (!string.IsNullOrWhiteSpace(item.LinkDbObjectName))
				{
					if (item.LinkDbObjectName.ToLower() == "crmcompany")
					{
						text = Labels.lblCmp;
					}
					else if (item.LinkDbObjectName.ToLower() == "crmcompanypersons")
					{
						text = Labels.lblPrs;
					}
				}
				string text2 = item.LinkDbObjectFieldTitle ?? "";
				if (!string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(text))
				{
					text2 = text2 + " - " + text;
				}
				item.LinkDbObjectFieldTitle = text2;
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

	[DynamicAuthorize(ControllerName = "frmDyDefineForm", ActionName = "actInsertForm,actEditForm")]
	public ActionResult InsertEdit(int fromId = 0, int parentFormId = 0)
	{
		_003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass9_0();
		CS_0024_003C_003E8__locals0.fromId = fromId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		CS_0024_003C_003E8__locals0.vm = new CrmDyFormLanguageViewModel();
		int result2 = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
		}
		if (CS_0024_003C_003E8__locals0.fromId > 0)
		{
			if (!UserLogin.IsUserAccess("frmDyDefineForm", "actEditForm"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			BaseInfo baseInfo = new BaseInfo();
			DbSet<CrmDyForms_Lang> crmDyForms_Lang = _dbTbl.CrmDyForms_Lang;
			ParameterExpression val = Expression.Parameter(typeof(CrmDyForms_Lang), "c");
			List<CrmDyForms_Lang> list = Enumerable.ToList<CrmDyForms_Lang>((IEnumerable<CrmDyForms_Lang>)Queryable.Where<CrmDyForms_Lang>((IQueryable<CrmDyForms_Lang>)crmDyForms_Lang, Expression.Lambda<Func<CrmDyForms_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass9_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			DbSet<CrmDyForms> crmDyForms = _dbTbl.CrmDyForms;
			val = Expression.Parameter(typeof(CrmDyForms), "c");
			CrmDyForms crmDyForms2 = Queryable.FirstOrDefault<CrmDyForms>((IQueryable<CrmDyForms>)crmDyForms, Expression.Lambda<Func<CrmDyForms, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass9_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmDyForms2 == null)
			{
				base.ViewBag.Error = Messages.ErrorNotFound;
				return null;
			}
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmDyForms_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmDyForms_Lang>)list, (Func<CrmDyForms_Lang, CommonMultiLanguageViewModel>)((CrmDyForms_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.FormName,
				LanguageId = item.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = crmDyForms2.FormName,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmDyForms_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmDyForms_Lang>)list, (Func<CrmDyForms_Lang, CommonMultiLanguageViewModel>)((CrmDyForms_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.FormTitle,
				LanguageId = item.LanguageID
			})));
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = crmDyForms2.FormTitle,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmDyForms_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmDyForms_Lang>)list, (Func<CrmDyForms_Lang, CommonMultiLanguageViewModel>)((CrmDyForms_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.FormHeader,
				LanguageId = item.LanguageID
			})));
			list4.Add(new CommonMultiLanguageViewModel
			{
				Value = crmDyForms2.FormHeader,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list5 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmDyForms_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmDyForms_Lang>)list, (Func<CrmDyForms_Lang, CommonMultiLanguageViewModel>)((CrmDyForms_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.FormBody,
				LanguageId = item.LanguageID
			})));
			list5.Add(new CommonMultiLanguageViewModel
			{
				Value = crmDyForms2.FormBody,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list6 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmDyForms_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmDyForms_Lang>)list, (Func<CrmDyForms_Lang, CommonMultiLanguageViewModel>)((CrmDyForms_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.FormFooter,
				LanguageId = item.LanguageID
			})));
			list6.Add(new CommonMultiLanguageViewModel
			{
				Value = crmDyForms2.FormFooter,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list7 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmDyForms_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmDyForms_Lang>)list, (Func<CrmDyForms_Lang, CommonMultiLanguageViewModel>)((CrmDyForms_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.UploadFileDescription,
				LanguageId = item.LanguageID
			})));
			list7.Add(new CommonMultiLanguageViewModel
			{
				Value = crmDyForms2.UploadFileDescription,
				LanguageId = result
			});
			CS_0024_003C_003E8__locals0.vm = new CrmDyFormLanguageViewModel
			{
				FormId = crmDyForms2.FormId,
				IsActive = crmDyForms2.IsActive,
				HaveUploadFile = crmDyForms2.HaveUploadFile,
				UploadFileCount = crmDyForms2.UploadFileCount,
				UploadFileMaxSize = crmDyForms2.UploadFileMaxSize,
				ColumnCount = crmDyForms2.ColumnCount,
				OrderView = crmDyForms2.OrderView,
				ParentFormId = crmDyForms2.ParentFormId,
				CrmSysPartId = crmDyForms2.CrmSysPartId,
				FOSysPartId = crmDyForms2.FOSysPartId,
				FirstRegisterUserId = crmDyForms2.FirstRegisterUserId,
				FirstRegisterDate = crmDyForms2.FirstRegisterDate,
				FirstRegisterDatePersian = crmDyForms2.FirstRegisterDatePersian,
				UserId = crmDyForms2.UserId,
				RegisterDate = crmDyForms2.RegisterDate,
				RegisterDatePersian = crmDyForms2.RegisterDatePersian,
				Year1 = crmDyForms2.Year1,
				Month1 = crmDyForms2.Month1,
				GUId = crmDyForms2.GUId,
				AppType = crmDyForms2.AppType,
				LanguageID = crmDyForms2.LanguageID,
				FormName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				FormName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				FormTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				FormTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				FormHeader = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				FormHeader_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				FormBody = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				FormBody_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				FormFooter = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				FormFooter_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				UploadFileDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				UploadFileDescription_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				FormTitleColor = baseInfo.DelphiCToRgbolor(crmDyForms2.FormTitleColor),
				FormBgColor = baseInfo.DelphiCToRgbolor(crmDyForms2.FormBgColor),
				UploadFileExtension = crmDyForms2.UploadFileExtension,
				PrintFormatId = crmDyForms2.PrintFormatId,
				VerificationWorkFlowId = crmDyForms2.VerificationWorkFlowId,
				FOIsVisible = crmDyForms2.FOIsVisible,
				FOIsEnable = crmDyForms2.FOIsEnable,
				FOCanInsertMulti = crmDyForms2.FOCanInsertMulti,
				EnableForUsersId = crmDyForms2.EnableForUsersId,
				EnableForRollId = crmDyForms2.EnableForRollId,
				CheckerUsersId = crmDyForms2.CheckerUsersId,
				WorkflowId = crmDyForms2.WorkflowId,
				CrmSysPartShow = crmDyForms2.CrmSysPartShow,
				CrmSysPartShowNames = ReturnSysPartNamesFromIds(crmDyForms2.CrmSysPartShow, '|'),
				FOSysPartShow = crmDyForms2.FOSysPartShow,
				FOSysPartShowNames = ReturnSysPartNamesFromIds(crmDyForms2.FOSysPartShow, '|'),
				SetSysPartFieldByUser = crmDyForms2.SetSysPartFieldByUser,
				EnableForResponsibleUserChecker = crmDyForms2.EnableForResponsibleUserChecker,
				CheckerRollId = crmDyForms2.CheckerRollId
			};
			int printFormatId = 0;
			DyForm.GetFormPrintFormatInCenter(crmDyForms2.FormId, ref printFormatId, result2);
			if (printFormatId != 0)
			{
				CS_0024_003C_003E8__locals0.vm.PrintFormatId = printFormatId;
			}
			else
			{
				CS_0024_003C_003E8__locals0.vm.PrintFormatId = null;
			}
		}
		else
		{
			if (!UserLogin.IsUserAccess("frmDyDefineForm", "actInsertForm"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			DateTime now = DateTime.Now;
			CS_0024_003C_003E8__locals0.vm = new CrmDyFormLanguageViewModel
			{
				ParentFormId = parentFormId,
				FirstRegisterUserId = UserLogin.CurrentUser.UserId,
				FirstRegisterDate = now,
				FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
				UserId = UserLogin.CurrentUser.UserId,
				RegisterDate = now,
				RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
				Year1 = short.Parse(Financial.Get().Id.ToString()),
				Month1 = short.Parse(now.ToString("MM", new PersianCulture())),
				AppType = Configuration.AppType,
				LanguageID = result,
				IsActive = true
			};
			if (!CS_0024_003C_003E8__locals0.vm.OrderView.HasValue || CS_0024_003C_003E8__locals0.vm.OrderView <= 0)
			{
				List<CRMspDySelectForms_Result> list8 = Enumerable.ToList<CRMspDySelectForms_Result>((IEnumerable<CRMspDySelectForms_Result>)_db.CRMspDySelectForms(0, null, CS_0024_003C_003E8__locals0.currLangID, result, result2));
				_ = Enumerable.FirstOrDefault<CRMspDySelectForms_Result>((IEnumerable<CRMspDySelectForms_Result>)Enumerable.OrderByDescending<CRMspDySelectForms_Result, int?>((IEnumerable<CRMspDySelectForms_Result>)list8, (Func<CRMspDySelectForms_Result, int?>)((CRMspDySelectForms_Result m) => m.OrderView)))?.OrderView;
				int num = (Enumerable.Any<CRMspDySelectForms_Result>((IEnumerable<CRMspDySelectForms_Result>)list8) ? Enumerable.Count<CRMspDySelectForms_Result>((IEnumerable<CRMspDySelectForms_Result>)list8) : 0);
				CS_0024_003C_003E8__locals0.vm.OrderView = num + 10 + num * 9 - 5;
			}
			base.ViewBag.IsBuying = VersionBuyer.DyForm;
		}
		GetSystemParts();
		GetPrintFormat();
		GetRolls();
		GetVerificationWorkFlow();
		base.ViewBag.EnableForUsers = GetUsers(CS_0024_003C_003E8__locals0.vm.EnableForUsersId);
		base.ViewBag.CheckerUsers = GetUsers(CS_0024_003C_003E8__locals0.vm.CheckerUsersId);
		if (CS_0024_003C_003E8__locals0.vm.WorkflowId > 0)
		{
			CRMspDySelectFormWorkflows_Result cRMspDySelectFormWorkflows_Result = Enumerable.FirstOrDefault<CRMspDySelectFormWorkflows_Result>((IEnumerable<CRMspDySelectFormWorkflows_Result>)_db.CRMspDySelectFormWorkflows(CS_0024_003C_003E8__locals0.currLangID, result, result2), (Func<CRMspDySelectFormWorkflows_Result, bool>)((CRMspDySelectFormWorkflows_Result m) => m.FormWorkflowId == CS_0024_003C_003E8__locals0.vm.WorkflowId));
			if (cRMspDySelectFormWorkflows_Result != null)
			{
				base.ViewBag.Workflow = cRMspDySelectFormWorkflows_Result.WorkflowTitle ?? "";
			}
		}
		return View(CS_0024_003C_003E8__locals0.vm);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDyFormDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult InsertEdit(CrmDyFormLanguageViewModel vm)
	{
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0306: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass10_0();
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
		if (CS_0024_003C_003E8__locals0.vm.WorkflowId > 0)
		{
			CRMspDySelectFormWorkflows_Result cRMspDySelectFormWorkflows_Result = Enumerable.FirstOrDefault<CRMspDySelectFormWorkflows_Result>((IEnumerable<CRMspDySelectFormWorkflows_Result>)_db.CRMspDySelectFormWorkflows(lCID, CS_0024_003C_003E8__locals0.defLangID, result), (Func<CRMspDySelectFormWorkflows_Result, bool>)((CRMspDySelectFormWorkflows_Result m) => m.FormWorkflowId == CS_0024_003C_003E8__locals0.vm.WorkflowId));
			if (cRMspDySelectFormWorkflows_Result != null)
			{
				base.ViewBag.Workflow = cRMspDySelectFormWorkflows_Result.WorkflowTitle ?? "";
			}
		}
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.FormName_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.FormName_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.FormName,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.FormTitle_Lang))
		{
			list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.FormTitle_Lang);
		}
		list2.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.FormTitle,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.FormHeader_Lang))
		{
			list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.FormHeader_Lang);
		}
		list3.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.FormHeader,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.FormBody_Lang))
		{
			list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.FormBody_Lang);
		}
		list4.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.FormBody,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.FormFooter_Lang))
		{
			list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.FormFooter_Lang);
		}
		list5.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.FormFooter,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.UploadFileDescription_Lang))
		{
			list6 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.UploadFileDescription_Lang);
		}
		list6.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.UploadFileDescription,
			LanguageId = lCID
		});
		GetSystemParts();
		GetPrintFormat();
		GetRolls();
		GetVerificationWorkFlow();
		base.ViewBag.EnableForUsers = GetUsers(CS_0024_003C_003E8__locals0.vm.EnableForUsersId);
		base.ViewBag.CheckerUsers = GetUsers(CS_0024_003C_003E8__locals0.vm.CheckerUsersId);
		try
		{
			if (CS_0024_003C_003E8__locals0.vm.FormId <= 0 && !VersionBuyer.DyForm)
			{
				DbSet<CrmDyForms> crmDyForms = _dbTbl.CrmDyForms;
				ParameterExpression val = Expression.Parameter(typeof(CrmDyForms), "c");
				if (Queryable.Any<CrmDyForms>((IQueryable<CrmDyForms>)crmDyForms, Expression.Lambda<Func<CrmDyForms, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)10, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val })))
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
				_003C_003Ec__DisplayClass10_1 _003C_003Ec__DisplayClass10_ = new _003C_003Ec__DisplayClass10_1();
				_ = CRMIdeal.Cache.Setting.Language.Get().Count;
				string text = "";
				int num = 0;
				if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.FormName))
				{
					text = text + string.Format(Messages.ErrorEmpty, Labels.DyFormName) + "<br/>";
					num++;
				}
				else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.FormName, list))
				{
					text = text + string.Format(Messages.CheckFieldInLang, Labels.DyFormName) + "<br>";
					num++;
				}
				if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.FormTitle))
				{
					text = text + string.Format(Messages.ErrorEmpty, Labels.DyFormTitle) + "<br/>";
					num++;
				}
				else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.FormTitle, list2))
				{
					text = text + string.Format(Messages.CheckFieldInLang, Labels.DyFormTitle) + "<br>";
					num++;
				}
				if (num > 0)
				{
					base.ViewBag.Error = text;
					return View(CS_0024_003C_003E8__locals0.vm);
				}
				_003C_003Ec__DisplayClass10_.model = new CrmDyForms();
				if (CS_0024_003C_003E8__locals0.vm.FormId > 0)
				{
					DbSet<CrmDyForms> crmDyForms2 = _dbTbl.CrmDyForms;
					ParameterExpression val = Expression.Parameter(typeof(CrmDyForms), "c");
					_003C_003Ec__DisplayClass10_.model = Queryable.FirstOrDefault<CrmDyForms>((IQueryable<CrmDyForms>)crmDyForms2, Expression.Lambda<Func<CrmDyForms, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass10_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				BaseInfo baseInfo = new BaseInfo();
				_003C_003Ec__DisplayClass10_.model.UserId = UserLogin.CurrentUser.UserId;
				DateTime now = DateTime.Now;
				_003C_003Ec__DisplayClass10_.model.RegisterDate = now;
				_003C_003Ec__DisplayClass10_.model.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				_003C_003Ec__DisplayClass10_.model.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
				_003C_003Ec__DisplayClass10_.model.AppType = Configuration.AppType;
				_003C_003Ec__DisplayClass10_.model.Year1 = short.Parse(Financial.Get().Id.ToString());
				_003C_003Ec__DisplayClass10_.model.HaveUploadFile = CS_0024_003C_003E8__locals0.vm.HaveUploadFile;
				_003C_003Ec__DisplayClass10_.model.UploadFileCount = CS_0024_003C_003E8__locals0.vm.UploadFileCount;
				_003C_003Ec__DisplayClass10_.model.UploadFileMaxSize = CS_0024_003C_003E8__locals0.vm.UploadFileMaxSize;
				_003C_003Ec__DisplayClass10_.model.ColumnCount = CS_0024_003C_003E8__locals0.vm.ColumnCount;
				_003C_003Ec__DisplayClass10_.model.IsActive = CS_0024_003C_003E8__locals0.vm.IsActive;
				_003C_003Ec__DisplayClass10_.model.OrderView = CS_0024_003C_003E8__locals0.vm.OrderView;
				_003C_003Ec__DisplayClass10_.model.ParentFormId = CS_0024_003C_003E8__locals0.vm.ParentFormId;
				if (_003C_003Ec__DisplayClass10_.model.FormId == 0 || UserLogin.IsUserAccess("frmDyFormDataEntry", "actCanChangeSysPart", UserLogin.CurrentUser))
				{
					_003C_003Ec__DisplayClass10_.model.CrmSysPartId = CS_0024_003C_003E8__locals0.vm.CrmSysPartId;
				}
				_003C_003Ec__DisplayClass10_.model.FOSysPartId = CS_0024_003C_003E8__locals0.vm.FOSysPartId;
				_003C_003Ec__DisplayClass10_.model.FormTitleColor = baseInfo.RgbToDelphiColor(CS_0024_003C_003E8__locals0.vm.FormTitleColor);
				_003C_003Ec__DisplayClass10_.model.FormBgColor = baseInfo.RgbToDelphiColor(CS_0024_003C_003E8__locals0.vm.FormBgColor);
				_003C_003Ec__DisplayClass10_.model.FormName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass10_.model.FormTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass10_.model.FormHeader = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass10_.model.FormBody = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass10_.model.FormFooter = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass10_.model.UploadFileDescription = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass10_.model.UploadFileExtension = CS_0024_003C_003E8__locals0.vm.UploadFileExtension;
				_003C_003Ec__DisplayClass10_.model.PrintFormatId = CS_0024_003C_003E8__locals0.vm.PrintFormatId;
				_003C_003Ec__DisplayClass10_.model.VerificationWorkFlowId = CS_0024_003C_003E8__locals0.vm.VerificationWorkFlowId;
				_003C_003Ec__DisplayClass10_.model.FOIsVisible = CS_0024_003C_003E8__locals0.vm.FOIsVisible;
				_003C_003Ec__DisplayClass10_.model.FOIsEnable = CS_0024_003C_003E8__locals0.vm.FOIsEnable;
				_003C_003Ec__DisplayClass10_.model.FOCanInsertMulti = CS_0024_003C_003E8__locals0.vm.FOCanInsertMulti;
				_003C_003Ec__DisplayClass10_.model.EnableForUsersId = CS_0024_003C_003E8__locals0.vm.EnableForUsersId;
				_003C_003Ec__DisplayClass10_.model.EnableForRollId = CS_0024_003C_003E8__locals0.vm.EnableForRollId;
				_003C_003Ec__DisplayClass10_.model.CheckerUsersId = CS_0024_003C_003E8__locals0.vm.CheckerUsersId;
				_003C_003Ec__DisplayClass10_.model.CrmSysPartShow = CS_0024_003C_003E8__locals0.vm.CrmSysPartShow;
				_003C_003Ec__DisplayClass10_.model.FOSysPartShow = CS_0024_003C_003E8__locals0.vm.FOSysPartShow;
				_003C_003Ec__DisplayClass10_.model.SetSysPartFieldByUser = CS_0024_003C_003E8__locals0.vm.SetSysPartFieldByUser;
				_003C_003Ec__DisplayClass10_.model.EnableForResponsibleUserChecker = CS_0024_003C_003E8__locals0.vm.EnableForResponsibleUserChecker;
				_003C_003Ec__DisplayClass10_.model.CheckerRollId = CS_0024_003C_003E8__locals0.vm.CheckerRollId;
				if (_003C_003Ec__DisplayClass10_.model.FormId == 0)
				{
					if (_003C_003Ec__DisplayClass10_.model.ParentFormId.GetValueOrDefault() == 0)
					{
						if (result != 0)
						{
							_003C_003Ec__DisplayClass10_.model.FormCIds = result.ToString();
							_003C_003Ec__DisplayClass10_.model.FormCenterInfoJs = DyForm.GetFormCenterInfoJs(_003C_003Ec__DisplayClass10_.model.FormCenterInfoJs ?? "", _003C_003Ec__DisplayClass10_.model.FormCenterInfoJs ?? "", _003C_003Ec__DisplayClass10_.model.FormCIds, _003C_003Ec__DisplayClass10_.model.PrintFormatId.GetValueOrDefault());
						}
					}
					else
					{
						_003C_003Ec__DisplayClass10_.model.FormCIds = DyForm.GetFromCIds(_003C_003Ec__DisplayClass10_.model.ParentFormId.GetValueOrDefault());
						_003C_003Ec__DisplayClass10_.model.FormCenterInfoJs = null;
					}
				}
				else if (_003C_003Ec__DisplayClass10_.model.ParentFormId.GetValueOrDefault() == 0)
				{
					_003C_003Ec__DisplayClass10_.model.FormCenterInfoJs = DyForm.GetFormCenterInfoJs(_003C_003Ec__DisplayClass10_.model.FormCenterInfoJs ?? "", _003C_003Ec__DisplayClass10_.model.FormCenterInfoJs ?? "", _003C_003Ec__DisplayClass10_.model.FormCIds, _003C_003Ec__DisplayClass10_.model.PrintFormatId.GetValueOrDefault());
				}
				if (_003C_003Ec__DisplayClass10_.model.FormId > 0)
				{
					_dbTbl.Entry(_003C_003Ec__DisplayClass10_.model).State = EntityState.Modified;
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass10_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass10_2();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass10_;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							DbSet<CrmDyForms_Lang> crmDyForms_Lang = _dbTbl.CrmDyForms_Lang;
							ParameterExpression val = Expression.Parameter(typeof(CrmDyForms_Lang), "c");
							CrmDyForms_Lang crmDyForms_Lang2 = Queryable.FirstOrDefault<CrmDyForms_Lang>((IQueryable<CrmDyForms_Lang>)crmDyForms_Lang, Expression.Lambda<Func<CrmDyForms_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass10_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass10_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (crmDyForms_Lang2 != null)
							{
								crmDyForms_Lang2.FormName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmDyForms_Lang2.FormTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmDyForms_Lang2.FormHeader = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmDyForms_Lang2.FormBody = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmDyForms_Lang2.FormFooter = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmDyForms_Lang2.UploadFileDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(crmDyForms_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							crmDyForms_Lang2 = new CrmDyForms_Lang();
							crmDyForms_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
							crmDyForms_Lang2.FormId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.FormId;
							crmDyForms_Lang2.FormName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							crmDyForms_Lang2.FormTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							crmDyForms_Lang2.FormHeader = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							crmDyForms_Lang2.FormBody = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							crmDyForms_Lang2.FormFooter = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							crmDyForms_Lang2.UploadFileDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							_dbTbl.CrmDyForms_Lang.Add(crmDyForms_Lang2);
							_dbTbl.SaveChanges();
						}
					}
					if (_003C_003Ec__DisplayClass10_.model.ParentFormId == 0)
					{
						List<CRMspDySelectForms_Result> list7 = Enumerable.ToList<CRMspDySelectForms_Result>((IEnumerable<CRMspDySelectForms_Result>)_db.CRMspDySelectForms(0, _003C_003Ec__DisplayClass10_.model.FormId, lCID, CS_0024_003C_003E8__locals0.defLangID, result));
						if (Enumerable.Any<CRMspDySelectForms_Result>((IEnumerable<CRMspDySelectForms_Result>)list7))
						{
							using List<CRMspDySelectForms_Result>.Enumerator enumerator2 = list7.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								_003C_003Ec__DisplayClass10_3 _003C_003Ec__DisplayClass10_2 = new _003C_003Ec__DisplayClass10_3();
								_003C_003Ec__DisplayClass10_2.chFrm = enumerator2.Current;
								DbSet<CrmDyForms> crmDyForms3 = _dbTbl.CrmDyForms;
								ParameterExpression val = Expression.Parameter(typeof(CrmDyForms), "m");
								CrmDyForms crmDyForms4 = Queryable.FirstOrDefault<CrmDyForms>((IQueryable<CrmDyForms>)crmDyForms3, Expression.Lambda<Func<CrmDyForms, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass10_2, typeof(_003C_003Ec__DisplayClass10_3)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (crmDyForms4 != null)
								{
									crmDyForms4.CrmSysPartId = _003C_003Ec__DisplayClass10_.model.CrmSysPartId;
									crmDyForms4.FOSysPartId = _003C_003Ec__DisplayClass10_.model.FOSysPartId;
									crmDyForms4.UserId = _003C_003Ec__DisplayClass10_.model.UserId;
									crmDyForms4.Year1 = _003C_003Ec__DisplayClass10_.model.Year1;
									crmDyForms4.Month1 = _003C_003Ec__DisplayClass10_.model.Month1;
									crmDyForms4.RegisterDate = _003C_003Ec__DisplayClass10_.model.RegisterDate;
									crmDyForms4.RegisterDatePersian = _003C_003Ec__DisplayClass10_.model.RegisterDatePersian;
									crmDyForms4.AppType = _003C_003Ec__DisplayClass10_.model.AppType;
									_dbTbl.Entry(crmDyForms4).State = EntityState.Modified;
									_dbTbl.Configuration.ValidateOnSaveEnabled = false;
									_dbTbl.SaveChanges();
									_dbTbl.Configuration.ValidateOnSaveEnabled = true;
								}
							}
						}
					}
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
				else
				{
					_003C_003Ec__DisplayClass10_.model.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
					_003C_003Ec__DisplayClass10_.model.FirstRegisterDate = now;
					_003C_003Ec__DisplayClass10_.model.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					_003C_003Ec__DisplayClass10_.model.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
					_003C_003Ec__DisplayClass10_.model.GUId = Guid.NewGuid();
					_dbTbl.CrmDyForms.Add(_003C_003Ec__DisplayClass10_.model);
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
					{
						CrmDyForms_Lang crmDyForms_Lang3 = new CrmDyForms_Lang();
						crmDyForms_Lang3.LanguageID = lang.LanguageID;
						crmDyForms_Lang3.FormId = _003C_003Ec__DisplayClass10_.model.FormId;
						crmDyForms_Lang3.FormName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmDyForms_Lang3.FormTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmDyForms_Lang3.FormHeader = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmDyForms_Lang3.FormBody = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmDyForms_Lang3.FormFooter = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmDyForms_Lang3.UploadFileDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						_dbTbl.CrmDyForms_Lang.Add(crmDyForms_Lang3);
						_dbTbl.SaveChanges();
					}
					if (_003C_003Ec__DisplayClass10_.model.FormId > 0 && _003C_003Ec__DisplayClass10_.model.ParentFormId == 0)
					{
						_db.CRMspDyInsertFormUserAccess(_003C_003Ec__DisplayClass10_.model.FirstRegisterUserId, _003C_003Ec__DisplayClass10_.model.FormId, _003C_003Ec__DisplayClass10_.model.UserId, short.Parse(now.ToString("yyyy", new PersianCulture())), _003C_003Ec__DisplayClass10_.model.Month1, now, _003C_003Ec__DisplayClass10_.model.FirstRegisterDatePersian, _003C_003Ec__DisplayClass10_.model.AppType, CS_0024_003C_003E8__locals0.defLangID);
					}
					base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
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
				CS_0024_003C_003E8__locals0.vm.FormId = _003C_003Ec__DisplayClass10_.model.FormId;
				CS_0024_003C_003E8__locals0.vm.CrmSysPartId = _003C_003Ec__DisplayClass10_.model.CrmSysPartId;
				CS_0024_003C_003E8__locals0.vm.FOSysPartId = _003C_003Ec__DisplayClass10_.model.FOSysPartId;
				CS_0024_003C_003E8__locals0.vm.ParentFormId = _003C_003Ec__DisplayClass10_.model.ParentFormId;
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
		return View(CS_0024_003C_003E8__locals0.vm);
	}

	[AjaxOnly]
	public void GetSystemParts()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		List<SelectListItem> list2 = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectActiveSystemParts_Result> list3 = Enumerable.ToList<CRMspSelectActiveSystemParts_Result>((IEnumerable<CRMspSelectActiveSystemParts_Result>)_dbI.CRMspSelectActiveSystemParts(lCID, result, "1,10,11,12,13,20,30,40,50,51,60,61,62,70,100,105,110,111,112,120,130,45"));
			list.AddRange(Enumerable.Select<CRMspSelectActiveSystemParts_Result, SelectListItem>((IEnumerable<CRMspSelectActiveSystemParts_Result>)Enumerable.ToList<CRMspSelectActiveSystemParts_Result>(Enumerable.Where<CRMspSelectActiveSystemParts_Result>((IEnumerable<CRMspSelectActiveSystemParts_Result>)list3, (Func<CRMspSelectActiveSystemParts_Result, bool>)((CRMspSelectActiveSystemParts_Result m) => m.Type == "CRM"))), (Func<CRMspSelectActiveSystemParts_Result, SelectListItem>)((CRMspSelectActiveSystemParts_Result i) => new SelectListItem
			{
				Text = i.PartTitle,
				Value = i.SystemPartId.ToString(),
				Selected = false
			})));
			list.AddRange(Enumerable.Select<CRMspSelectActiveSystemParts_Result, SelectListItem>((IEnumerable<CRMspSelectActiveSystemParts_Result>)Enumerable.ToList<CRMspSelectActiveSystemParts_Result>(Enumerable.Where<CRMspSelectActiveSystemParts_Result>((IEnumerable<CRMspSelectActiveSystemParts_Result>)list3, (Func<CRMspSelectActiveSystemParts_Result, bool>)((CRMspSelectActiveSystemParts_Result m) => m.Type == "FO" && m.SystemPartId == 105))), (Func<CRMspSelectActiveSystemParts_Result, SelectListItem>)((CRMspSelectActiveSystemParts_Result i) => new SelectListItem
			{
				Text = i.PartTitle,
				Value = i.SystemPartId.ToString(),
				Selected = false
			})));
			list2.AddRange(Enumerable.Select<CRMspSelectActiveSystemParts_Result, SelectListItem>((IEnumerable<CRMspSelectActiveSystemParts_Result>)Enumerable.ToList<CRMspSelectActiveSystemParts_Result>(Enumerable.Where<CRMspSelectActiveSystemParts_Result>((IEnumerable<CRMspSelectActiveSystemParts_Result>)list3, (Func<CRMspSelectActiveSystemParts_Result, bool>)((CRMspSelectActiveSystemParts_Result m) => m.Type == "FO"))), (Func<CRMspSelectActiveSystemParts_Result, SelectListItem>)((CRMspSelectActiveSystemParts_Result i) => new SelectListItem
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
		base.ViewBag.FOSystemPartList = list2;
	}

	[AjaxOnly]
	public JsonResult GetPrintFormat()
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectPrintFormatByTypeId_Result> printFortants = CRMIdeal.Classes.Helper.PrintFormat.GetPrintFortants(result2, 505);
			list.AddRange(Enumerable.Select<CRMspSelectPrintFormatByTypeId_Result, SelectListItem>((IEnumerable<CRMspSelectPrintFormatByTypeId_Result>)Enumerable.ToList<CRMspSelectPrintFormatByTypeId_Result>((IEnumerable<CRMspSelectPrintFormatByTypeId_Result>)printFortants), (Func<CRMspSelectPrintFormatByTypeId_Result, SelectListItem>)((CRMspSelectPrintFormatByTypeId_Result i) => new SelectListItem
			{
				Text = i.Title,
				Value = i.PrintFormatID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PrintFormatList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public void GetRolls()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		List<SelectListItem> list2 = new List<SelectListItem>();
		try
		{
			list = GetRollsList();
			list2 = GetRollsList();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.RollList = list;
		base.ViewBag.CheckerRollList = list2;
	}

	public List<SelectListItem> GetRollsList()
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
			List<CRMspSelectsysRolls_Result> list2 = Enumerable.ToList<CRMspSelectsysRolls_Result>((IEnumerable<CRMspSelectsysRolls_Result>)_db.CRMspSelectsysRolls(lCID, result));
			if (list2 != null && Enumerable.Any<CRMspSelectsysRolls_Result>((IEnumerable<CRMspSelectsysRolls_Result>)list2))
			{
				list.AddRange(Enumerable.Select<CRMspSelectsysRolls_Result, SelectListItem>((IEnumerable<CRMspSelectsysRolls_Result>)Enumerable.ToList<CRMspSelectsysRolls_Result>((IEnumerable<CRMspSelectsysRolls_Result>)list2), (Func<CRMspSelectsysRolls_Result, SelectListItem>)((CRMspSelectsysRolls_Result i) => new SelectListItem
				{
					Text = i.RollName,
					Value = i.ID.ToString(),
					Selected = false
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public JsonResult GetVerificationWorkFlow()
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
			List<WSspSelectVerificationWorkFlowWithObjectType_Result> list2 = Enumerable.ToList<WSspSelectVerificationWorkFlowWithObjectType_Result>((IEnumerable<WSspSelectVerificationWorkFlowWithObjectType_Result>)_db.WSspSelectVerificationWorkFlowWithObjectType(80, lCID, result));
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

	public string ReturnSysPartNamesFromIds(string ids = "", char seperator = ',')
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
			if (!string.IsNullOrWhiteSpace(ids))
			{
				List<string> list = Enumerable.ToList<string>((IEnumerable<string>)ids.Split(new char[1] { seperator }));
				if (list != null)
				{
					List<CRMspSelectSystemParts_Result> list2 = Enumerable.ToList<CRMspSelectSystemParts_Result>((IEnumerable<CRMspSelectSystemParts_Result>)_db.CRMspSelectSystemParts(lCID, result));
					foreach (string i in list)
					{
						CRMspSelectSystemParts_Result cRMspSelectSystemParts_Result = Enumerable.FirstOrDefault<CRMspSelectSystemParts_Result>((IEnumerable<CRMspSelectSystemParts_Result>)list2, (Func<CRMspSelectSystemParts_Result, bool>)((CRMspSelectSystemParts_Result x) => x.SystemPartId == int.Parse(i)));
						if (cRMspSelectSystemParts_Result != null)
						{
							text = text + ((!string.IsNullOrWhiteSpace(text)) ? "," : "") + cRMspSelectSystemParts_Result.PartTitle;
						}
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

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmDyDefineForm", ActionName = "actDeleteForm")]
	public string DeleteForm(int formId)
	{
		_003C_003Ec__DisplayClass17_0 _003C_003Ec__DisplayClass17_ = new _003C_003Ec__DisplayClass17_0();
		_003C_003Ec__DisplayClass17_.formId = formId;
		string result = "";
		try
		{
			DbSet<CrmDyForms> crmDyForms = _dbTbl.CrmDyForms;
			ParameterExpression val = Expression.Parameter(typeof(CrmDyForms), "c");
			if (Queryable.FirstOrDefault<CrmDyForms>((IQueryable<CrmDyForms>)crmDyForms, Expression.Lambda<Func<CrmDyForms, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass17_, typeof(_003C_003Ec__DisplayClass17_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
			{
				try
				{
					int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
					if (result2 <= 0)
					{
						result2 = 1065;
					}
					_ = Thread.CurrentThread.CurrentCulture.LCID;
					mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)Enumerable.ToList<mct_Result>((IEnumerable<mct_Result>)_db.CRMspDyDeleteForm(_003C_003Ec__DisplayClass17_.formId)));
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

	public ActionResult SetColor(int type, string color = "")
	{
		base.ViewBag.Type = type;
		base.ViewBag.Color = color;
		return View();
	}

	[AjaxOnly]
	public string ActPateFormAndFields(int mode, int newFormId, int oldFormId, int parentFormId, int? crmSysPartId, int? foSysPartId)
	{
		string text = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			string text2 = "";
			if (!UserLogin.IsUserAccess("frmDyDefineForm", mode switch
			{
				1 => "actPasteDyForm", 
				2 => "actPasteDyFormAndFields", 
				3 => "actPasteDyFormFields", 
				_ => "notAccess", 
			}, currentUser))
			{
				return Messages.ErrorNotAccess;
			}
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = currentUser.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short value3 = short.Parse(Financial.Get().Id.ToString());
			crmSysPartId = ((crmSysPartId <= 0) ? null : crmSysPartId);
			foSysPartId = ((foSysPartId <= 0) ? null : foSysPartId);
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_db.CRMspDyCopyPastFormAndFields(mode, newFormId, oldFormId, parentFormId, crmSysPartId, foSysPartId, userId, value2, value3, value, registerDatePersian, appType, result, centerId));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 <= 0)
			{
				return Messages.msgErrorRunFunction;
			}
			return "1|" + result2;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.msgErrorRunFunction;
		}
	}

	public string GetUsers(string usersId)
	{
		string text = "";
		try
		{
			int result = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
			}
			if (!string.IsNullOrEmpty(usersId))
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
				if (result2 <= 0)
				{
					result2 = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				List<CRMspSelectActiveUsers_Result> users = Enumerable.ToList<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)_db.CRMspSelectActiveUsers(lCID, result2, result));
				if (Enumerable.Any<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)users))
				{
					text = Enumerable.Aggregate<CRMspSelectActiveUsers_Result, string>(Enumerable.Where<CRMspSelectActiveUsers_Result>(Enumerable.Select<string, CRMspSelectActiveUsers_Result>(Enumerable.Where<string>((IEnumerable<string>)usersId.Split(new char[1] { '|' }), (Func<string, bool>)((string us) => !string.IsNullOrEmpty(us))), (Func<string, CRMspSelectActiveUsers_Result>)((string us) => Enumerable.FirstOrDefault<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)users, (Func<CRMspSelectActiveUsers_Result, bool>)((CRMspSelectActiveUsers_Result m) => m.UserId == int.Parse(us))))), (Func<CRMspSelectActiveUsers_Result, bool>)((CRMspSelectActiveUsers_Result u) => u != null)), text, (Func<string, CRMspSelectActiveUsers_Result, string>)((string current, CRMspSelectActiveUsers_Result u) => current + ((!string.IsNullOrEmpty(u.Name)) ? u.Name : "") + ","));
					if (!string.IsNullOrEmpty(text))
					{
						text = text.TrimEnd(new char[1] { ',' });
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

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}

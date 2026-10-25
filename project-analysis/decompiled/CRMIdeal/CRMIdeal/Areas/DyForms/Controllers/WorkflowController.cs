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

namespace CRMIdeal.Areas.DyForms.Controllers;

public class WorkflowController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public int workflowId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass20_0
	{
		public int workflowDetailId;

		public int currLangID;

		internal bool _003CInsertEditDetail_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEditDetail_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEditDetail_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass21_0
	{
		public CrmDyFormWorkflowStepsLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__3;

		public Func<Languages, bool> _003C_003E9__9;

		internal bool _003CInsertEditDetail_003Eb__1(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEditDetail_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEditDetail_003Eb__3(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEditDetail_003Eb__9(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass21_1
	{
		public CrmDyFormWorkflowSteps model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass21_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass21_1 CS_0024_003C_003E8__locals1;

		internal bool _003CInsertEditDetail_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEditDetail_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEditDetail_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEditDetail_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass22_0
	{
		public int workflowDetailId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public int workflowId;

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
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public CrmDyFormWorkflowsLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__3;

		public Func<Languages, bool> _003C_003E9__9;

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

		internal bool _003CInsertEdit_003Eb__9(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_1
	{
		public CrmDyFormWorkflows model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass7_1 CS_0024_003C_003E8__locals1;

		internal bool _003CInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

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
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actdyDefineFormWorkflows")]
	public ActionResult Index()
	{
		return View();
	}

	public List<CRMspDySelectFormWorkflows_Result> ListWorkflows()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspDySelectFormWorkflows_Result> list = new List<CRMspDySelectFormWorkflows_Result>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			list = Enumerable.ToList<CRMspDySelectFormWorkflows_Result>((IEnumerable<CRMspDySelectFormWorkflows_Result>)_db.CRMspDySelectFormWorkflows(lCID, result, result2));
			foreach (CRMspDySelectFormWorkflows_Result item in list)
			{
				if (string.IsNullOrEmpty(item.AppType))
				{
					item.AppType = Configuration.AppType;
				}
				item.AppType = Configuration.GetAppType(item.AppType);
				string text = item.FirstRegisterUser ?? "";
				_ = item.FirstRegisterDate;
				string text2 = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
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

	[AjaxOnly]
	public ActionResult Workflow_Read([DataSourceRequest] DataSourceRequest request)
	{
		return Json(((IEnumerable)ListWorkflows()).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult WorkflowsList()
	{
		return Json(ListWorkflows(), JsonRequestBehavior.AllowGet);
	}

	public ActionResult InsertEdit(int workflowId = 0)
	{
		_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass6_0();
		CS_0024_003C_003E8__locals0.workflowId = workflowId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		DbSet<CrmDyFormWorkflows_Lang> crmDyFormWorkflows_Lang = _dbTbl.CrmDyFormWorkflows_Lang;
		ParameterExpression val = Expression.Parameter(typeof(CrmDyFormWorkflows_Lang), "c");
		List<CrmDyFormWorkflows_Lang> list = Enumerable.ToList<CrmDyFormWorkflows_Lang>((IEnumerable<CrmDyFormWorkflows_Lang>)Queryable.Where<CrmDyFormWorkflows_Lang>((IQueryable<CrmDyFormWorkflows_Lang>)crmDyFormWorkflows_Lang, Expression.Lambda<Func<CrmDyFormWorkflows_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass6_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
		DateTime now = DateTime.Now;
		CrmDyFormWorkflows crmDyFormWorkflows = new CrmDyFormWorkflows();
		if (CS_0024_003C_003E8__locals0.workflowId == 0)
		{
			if (!UserLogin.IsUserAccess("frmDyDefineFormWorkflow", "actInsert", UserLogin.CurrentUser))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			crmDyFormWorkflows = new CrmDyFormWorkflows();
			crmDyFormWorkflows.FormWorkflowId = 0;
			crmDyFormWorkflows.RegisterDate = now;
			crmDyFormWorkflows.FirstRegisterDate = now;
			crmDyFormWorkflows.IsActive = true;
		}
		else
		{
			if (!UserLogin.IsUserAccess("frmDyDefineFormWorkflow", "actEdit", UserLogin.CurrentUser))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			DbSet<CrmDyFormWorkflows> crmDyFormWorkflows2 = _dbTbl.CrmDyFormWorkflows;
			val = Expression.Parameter(typeof(CrmDyFormWorkflows), "m");
			crmDyFormWorkflows = Queryable.FirstOrDefault<CrmDyFormWorkflows>((IQueryable<CrmDyFormWorkflows>)crmDyFormWorkflows2, Expression.Lambda<Func<CrmDyFormWorkflows, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass6_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmDyFormWorkflows == null)
			{
				crmDyFormWorkflows = new CrmDyFormWorkflows();
				crmDyFormWorkflows.FormWorkflowId = 0;
				crmDyFormWorkflows.RegisterDate = now;
				crmDyFormWorkflows.FirstRegisterDate = now;
				crmDyFormWorkflows.IsActive = true;
			}
		}
		List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmDyFormWorkflows_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmDyFormWorkflows_Lang>)list, (Func<CrmDyFormWorkflows_Lang, CommonMultiLanguageViewModel>)((CrmDyFormWorkflows_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.WorkflowTitle,
			LanguageId = item.LanguageID
		})));
		list2.Add(new CommonMultiLanguageViewModel
		{
			Value = crmDyFormWorkflows.WorkflowTitle,
			LanguageId = result
		});
		CrmDyFormWorkflowsLanguageViewModel model = new CrmDyFormWorkflowsLanguageViewModel
		{
			FormWorkflowId = crmDyFormWorkflows.FormWorkflowId,
			WorkflowTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			WorkflowTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
			DyFormId = crmDyFormWorkflows.DyFormId,
			FirstRegisterUserId = crmDyFormWorkflows.FirstRegisterUserId,
			FirstRegisterDate = crmDyFormWorkflows.FirstRegisterDate,
			FirstRegisterDatePersian = crmDyFormWorkflows.FirstRegisterDatePersian,
			UserId = crmDyFormWorkflows.UserId,
			Year1 = crmDyFormWorkflows.Year1,
			Month1 = crmDyFormWorkflows.Month1,
			RegisterDate = crmDyFormWorkflows.RegisterDate,
			RegisterDatePersian = crmDyFormWorkflows.RegisterDatePersian,
			GUId = crmDyFormWorkflows.GUId,
			AppType = crmDyFormWorkflows.AppType,
			LanguageID = crmDyFormWorkflows.LanguageID,
			IsActive = crmDyFormWorkflows.IsActive,
			WorkflowPanelShowType = crmDyFormWorkflows.WorkflowPanelShowType,
			WorkflowPanelHide = crmDyFormWorkflows.WorkflowPanelHide
		};
		return View(model);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDyDefineFormWorkflowDataEntry", ActionName = "actPost")]
	public ActionResult InsertEdit(CrmDyFormWorkflowsLanguageViewModel vm)
	{
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass7_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		if (base.ModelState.IsValid)
		{
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.WorkflowTitle_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.WorkflowTitle_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.WorkflowTitle,
				LanguageId = lCID
			});
			if (CS_0024_003C_003E8__locals0.vm.WorkflowTitle == null)
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.DyFrmWorkflowTitle) + "<br/>";
				num++;
			}
			else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.WorkflowTitle, list))
			{
				text = text + string.Format(Messages.CheckFieldInLang, Labels.DyFrmWorkflowTitle) + "<br>";
				num++;
			}
			if (num == 0)
			{
				DateTime now = DateTime.Now;
				try
				{
					_003C_003Ec__DisplayClass7_1 _003C_003Ec__DisplayClass7_ = new _003C_003Ec__DisplayClass7_1();
					_003C_003Ec__DisplayClass7_.model = new CrmDyFormWorkflows();
					if (CS_0024_003C_003E8__locals0.vm.FormWorkflowId > 0)
					{
						DbSet<CrmDyFormWorkflows> crmDyFormWorkflows = _dbTbl.CrmDyFormWorkflows;
						ParameterExpression val = Expression.Parameter(typeof(CrmDyFormWorkflows), "m");
						_003C_003Ec__DisplayClass7_.model = Queryable.FirstOrDefault<CrmDyFormWorkflows>((IQueryable<CrmDyFormWorkflows>)crmDyFormWorkflows, Expression.Lambda<Func<CrmDyFormWorkflows, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass7_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						if (_003C_003Ec__DisplayClass7_.model != null && _003C_003Ec__DisplayClass7_.model.DyFormId != CS_0024_003C_003E8__locals0.vm.DyFormId)
						{
							int? num2 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_db.CRMspDyCheckUsedFormWorkflowId(CS_0024_003C_003E8__locals0.vm.FormWorkflowId));
							if (num2.HasValue)
							{
								int result = 0;
								int.TryParse(num2.ToString(), out result);
								base.ViewBag.Error = string.Format(Messages.msgErrorNotEditFormInWorkflow, result.ToString());
								return View(CS_0024_003C_003E8__locals0.vm);
							}
						}
					}
					_003C_003Ec__DisplayClass7_.model.WorkflowTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					_003C_003Ec__DisplayClass7_.model.DyFormId = CS_0024_003C_003E8__locals0.vm.DyFormId;
					_003C_003Ec__DisplayClass7_.model.UserId = UserLogin.CurrentUser.UserId;
					_003C_003Ec__DisplayClass7_.model.Year1 = short.Parse(Financial.Get().Id.ToString());
					_003C_003Ec__DisplayClass7_.model.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
					_003C_003Ec__DisplayClass7_.model.RegisterDate = now;
					_003C_003Ec__DisplayClass7_.model.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					_003C_003Ec__DisplayClass7_.model.AppType = Configuration.AppType;
					_003C_003Ec__DisplayClass7_.model.IsActive = CS_0024_003C_003E8__locals0.vm.IsActive;
					_003C_003Ec__DisplayClass7_.model.WorkflowPanelShowType = CS_0024_003C_003E8__locals0.vm.WorkflowPanelShowType;
					_003C_003Ec__DisplayClass7_.model.WorkflowPanelHide = CS_0024_003C_003E8__locals0.vm.WorkflowPanelHide;
					if (CS_0024_003C_003E8__locals0.vm.FormWorkflowId > 0)
					{
						_dbTbl.Entry(_003C_003Ec__DisplayClass7_.model).State = EntityState.Modified;
						_dbTbl.Configuration.ValidateOnSaveEnabled = false;
						_dbTbl.SaveChanges();
						_dbTbl.Configuration.ValidateOnSaveEnabled = true;
						using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								_003C_003Ec__DisplayClass7_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass7_2();
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass7_;
								CS_0024_003C_003E8__locals1.lang = enumerator.Current;
								DbSet<CrmDyFormWorkflows_Lang> crmDyFormWorkflows_Lang = _dbTbl.CrmDyFormWorkflows_Lang;
								ParameterExpression val = Expression.Parameter(typeof(CrmDyFormWorkflows_Lang), "c");
								CrmDyFormWorkflows_Lang crmDyFormWorkflows_Lang2 = Queryable.FirstOrDefault<CrmDyFormWorkflows_Lang>((IQueryable<CrmDyFormWorkflows_Lang>)crmDyFormWorkflows_Lang, Expression.Lambda<Func<CrmDyFormWorkflows_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass7_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass7_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (crmDyFormWorkflows_Lang2 != null)
								{
									crmDyFormWorkflows_Lang2.WorkflowTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									_dbTbl.Entry(crmDyFormWorkflows_Lang2).State = EntityState.Modified;
									_dbTbl.SaveChanges();
									continue;
								}
								crmDyFormWorkflows_Lang2 = new CrmDyFormWorkflows_Lang();
								crmDyFormWorkflows_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
								crmDyFormWorkflows_Lang2.FormWorkflowId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.FormWorkflowId;
								crmDyFormWorkflows_Lang2.WorkflowTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.CrmDyFormWorkflows_Lang.Add(crmDyFormWorkflows_Lang2);
								_dbTbl.SaveChanges();
							}
						}
						_db.CRMspDyUpdateFormWorkflowId(_003C_003Ec__DisplayClass7_.model.DyFormId, _003C_003Ec__DisplayClass7_.model.FormWorkflowId);
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					}
					else
					{
						_003C_003Ec__DisplayClass7_.model.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
						_003C_003Ec__DisplayClass7_.model.FirstRegisterDate = now;
						_003C_003Ec__DisplayClass7_.model.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						_003C_003Ec__DisplayClass7_.model.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
						_003C_003Ec__DisplayClass7_.model.GUId = Guid.NewGuid();
						_dbTbl.CrmDyFormWorkflows.Add(_003C_003Ec__DisplayClass7_.model);
						_dbTbl.Configuration.ValidateOnSaveEnabled = false;
						_dbTbl.SaveChanges();
						_dbTbl.Configuration.ValidateOnSaveEnabled = true;
						foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
						{
							CrmDyFormWorkflows_Lang crmDyFormWorkflows_Lang3 = new CrmDyFormWorkflows_Lang();
							crmDyFormWorkflows_Lang3.LanguageID = lang.LanguageID;
							crmDyFormWorkflows_Lang3.FormWorkflowId = _003C_003Ec__DisplayClass7_.model.FormWorkflowId;
							crmDyFormWorkflows_Lang3.WorkflowTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
							_dbTbl.CrmDyFormWorkflows_Lang.Add(crmDyFormWorkflows_Lang3);
							_dbTbl.SaveChanges();
						}
						_db.CRMspDyUpdateFormWorkflowId(_003C_003Ec__DisplayClass7_.model.DyFormId, _003C_003Ec__DisplayClass7_.model.FormWorkflowId);
						base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					text = Messages.msgErrorRunFunction;
				}
			}
		}
		if (text != "")
		{
			base.ViewBag.Error = text;
		}
		return View(CS_0024_003C_003E8__locals0.vm);
	}

	public List<TreeViewItemModel> GetFormsTree(int workflowId, int formId)
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
			List<CRMspDySelectFormsForWorkflow_Result> list2 = Enumerable.ToList<CRMspDySelectFormsForWorkflow_Result>((IEnumerable<CRMspDySelectFormsForWorkflow_Result>)_db.CRMspDySelectFormsForWorkflow(workflowId, formId, UserLogin.CurrentUser.UserId, lCID, result, result2));
			if (list2 != null && Enumerable.Any<CRMspDySelectFormsForWorkflow_Result>((IEnumerable<CRMspDySelectFormsForWorkflow_Result>)list2))
			{
				foreach (CRMspDySelectFormsForWorkflow_Result item4 in list2)
				{
					if (string.IsNullOrWhiteSpace(item4.FOSysPartShow))
					{
						item4.FOSysPartId = null;
					}
				}
			}
			List<CRMspDySelectFormsForWorkflow_Result> list3 = Enumerable.ToList<CRMspDySelectFormsForWorkflow_Result>(Enumerable.Where<CRMspDySelectFormsForWorkflow_Result>((IEnumerable<CRMspDySelectFormsForWorkflow_Result>)list2, (Func<CRMspDySelectFormsForWorkflow_Result, bool>)((CRMspDySelectFormsForWorkflow_Result m) => m.CrmSysPartId.HasValue && !m.FOSysPartId.HasValue)));
			if (Enumerable.Any<CRMspDySelectFormsForWorkflow_Result>((IEnumerable<CRMspDySelectFormsForWorkflow_Result>)list3))
			{
				List<TreeViewItemModel> list4 = new List<TreeViewItemModel>();
				TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
				treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", "-2|0|-2|-2"));
				treeViewItemModel.Id = "-2|0|-2|-2";
				treeViewItemModel.Text = Labels.DyFrmCrmSysPart;
				treeViewItemModel.ImageUrl = "";
				foreach (CRMspDySelectFormsForWorkflow_Result item3 in list3)
				{
					TreeViewItemModel mainTree3 = new TreeViewItemModel();
					mainTree3.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", (item3.CrmSysPartId.HasValue ? item3.CrmSysPartId.ToString() : "0") + "|0|-1|-1"));
					mainTree3.Id = (item3.CrmSysPartId.HasValue ? item3.CrmSysPartId.ToString() : "0") + "|0|-1|-1";
					mainTree3.Text = item3.CrmSysPartTitle;
					mainTree3.ImageUrl = "";
					if (Enumerable.FirstOrDefault<TreeViewItemModel>((IEnumerable<TreeViewItemModel>)list4, (Func<TreeViewItemModel, bool>)((TreeViewItemModel m) => m.Id == mainTree3.Id)) != null)
					{
						continue;
					}
					List<CRMspDySelectFormsForWorkflow_Result> list5 = Enumerable.ToList<CRMspDySelectFormsForWorkflow_Result>(Enumerable.Where<CRMspDySelectFormsForWorkflow_Result>((IEnumerable<CRMspDySelectFormsForWorkflow_Result>)list3, (Func<CRMspDySelectFormsForWorkflow_Result, bool>)((CRMspDySelectFormsForWorkflow_Result c) => c.CrmSysPartId == item3.CrmSysPartId)));
					List<TreeViewItemModel> list6 = new List<TreeViewItemModel>();
					foreach (CRMspDySelectFormsForWorkflow_Result item5 in list5)
					{
						TreeViewItemModel treeViewItemModel2 = new TreeViewItemModel();
						if (!item5.WorkflowId.HasValue || (workflowId > 0 && workflowId == item5.WorkflowId))
						{
							treeViewItemModel2.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item5.FormId.ToString()));
							treeViewItemModel2.Id = item5.FormId.ToString();
							treeViewItemModel2.Text = item5.FormName;
						}
						else
						{
							treeViewItemModel2.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item5.WorkflowId + "|" + item5.FormId));
							treeViewItemModel2.Id = item5.WorkflowId + "|" + item5.FormId;
							treeViewItemModel2.Text = item5.FormName + " " + string.Format(Labels.DyFrmWorkflowNameIE, item5.Workflow ?? "");
						}
						treeViewItemModel2.ImageUrl = "";
						treeViewItemModel2.Items = new List<TreeViewItemModel>();
						list6.Add(treeViewItemModel2);
					}
					mainTree3.Items = new List<TreeViewItemModel>(list6);
					list4.Add(mainTree3);
				}
				treeViewItemModel.Items = new List<TreeViewItemModel>(list4);
				list.Add(treeViewItemModel);
			}
			List<CRMspDySelectFormsForWorkflow_Result> list7 = Enumerable.ToList<CRMspDySelectFormsForWorkflow_Result>(Enumerable.Where<CRMspDySelectFormsForWorkflow_Result>((IEnumerable<CRMspDySelectFormsForWorkflow_Result>)list2, (Func<CRMspDySelectFormsForWorkflow_Result, bool>)((CRMspDySelectFormsForWorkflow_Result m) => !m.CrmSysPartId.HasValue && m.FOSysPartId.HasValue)));
			if (Enumerable.Any<CRMspDySelectFormsForWorkflow_Result>((IEnumerable<CRMspDySelectFormsForWorkflow_Result>)list7))
			{
				List<TreeViewItemModel> list8 = new List<TreeViewItemModel>();
				TreeViewItemModel treeViewItemModel3 = new TreeViewItemModel();
				treeViewItemModel3.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", "0|-2|-2|-2"));
				treeViewItemModel3.Id = "0|-2|-2|-2";
				treeViewItemModel3.Text = Labels.DyFrmFOSysPart;
				treeViewItemModel3.ImageUrl = "";
				foreach (CRMspDySelectFormsForWorkflow_Result item2 in list7)
				{
					TreeViewItemModel mainTree2 = new TreeViewItemModel();
					mainTree2.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", "0|" + (item2.FOSysPartId.HasValue ? item2.FOSysPartId.ToString() : "0") + "|-1|-1"));
					mainTree2.Id = "0|" + (item2.FOSysPartId.HasValue ? item2.FOSysPartId.ToString() : "0") + "|-1|-1";
					mainTree2.Text = item2.FOSysPartTitle;
					mainTree2.ImageUrl = "";
					if (Enumerable.FirstOrDefault<TreeViewItemModel>((IEnumerable<TreeViewItemModel>)list8, (Func<TreeViewItemModel, bool>)((TreeViewItemModel m) => m.Id == mainTree2.Id)) != null)
					{
						continue;
					}
					List<CRMspDySelectFormsForWorkflow_Result> list9 = Enumerable.ToList<CRMspDySelectFormsForWorkflow_Result>(Enumerable.Where<CRMspDySelectFormsForWorkflow_Result>((IEnumerable<CRMspDySelectFormsForWorkflow_Result>)list7, (Func<CRMspDySelectFormsForWorkflow_Result, bool>)((CRMspDySelectFormsForWorkflow_Result c) => c.FOSysPartId == item2.FOSysPartId)));
					List<TreeViewItemModel> list10 = new List<TreeViewItemModel>();
					foreach (CRMspDySelectFormsForWorkflow_Result item6 in list9)
					{
						TreeViewItemModel treeViewItemModel4 = new TreeViewItemModel();
						if (!item6.WorkflowId.HasValue || (workflowId > 0 && workflowId == item6.WorkflowId))
						{
							treeViewItemModel4.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item6.FormId.ToString()));
							treeViewItemModel4.Id = item6.FormId.ToString();
							treeViewItemModel4.Text = item6.FormName;
						}
						else
						{
							treeViewItemModel4.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item6.WorkflowId + "|" + item6.FormId));
							treeViewItemModel4.Id = item6.WorkflowId + "|" + item6.FormId;
							treeViewItemModel4.Text = item6.FormName + " " + string.Format(Labels.DyFrmWorkflowNameIE, item6.Workflow ?? "");
						}
						treeViewItemModel4.ImageUrl = "";
						treeViewItemModel4.Items = new List<TreeViewItemModel>();
						list10.Add(treeViewItemModel4);
					}
					mainTree2.Items = new List<TreeViewItemModel>(list10);
					list8.Add(mainTree2);
				}
				treeViewItemModel3.Items = new List<TreeViewItemModel>(list8);
				list.Add(treeViewItemModel3);
			}
			List<CRMspDySelectFormsForWorkflow_Result> list11 = Enumerable.ToList<CRMspDySelectFormsForWorkflow_Result>(Enumerable.Where<CRMspDySelectFormsForWorkflow_Result>((IEnumerable<CRMspDySelectFormsForWorkflow_Result>)list2, (Func<CRMspDySelectFormsForWorkflow_Result, bool>)((CRMspDySelectFormsForWorkflow_Result m) => m.CrmSysPartId.HasValue && m.FOSysPartId.HasValue)));
			if (Enumerable.Any<CRMspDySelectFormsForWorkflow_Result>((IEnumerable<CRMspDySelectFormsForWorkflow_Result>)list11))
			{
				List<TreeViewItemModel> list12 = new List<TreeViewItemModel>();
				TreeViewItemModel treeViewItemModel5 = new TreeViewItemModel();
				treeViewItemModel5.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", "-2|-2|-2|-2"));
				treeViewItemModel5.Id = "-2|-2|-2|-2";
				treeViewItemModel5.Text = Labels.DyFrmBothSysPart;
				treeViewItemModel5.ImageUrl = "";
				foreach (CRMspDySelectFormsForWorkflow_Result item in list11)
				{
					TreeViewItemModel mainTree = new TreeViewItemModel();
					mainTree.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", (item.CrmSysPartId.HasValue ? item.CrmSysPartId.ToString() : "0") + "|" + (item.FOSysPartId.HasValue ? item.FOSysPartId.ToString() : "0") + "|-1|-1"));
					mainTree.Id = (item.CrmSysPartId.HasValue ? item.CrmSysPartId.ToString() : "0") + "|" + (item.FOSysPartId.HasValue ? item.FOSysPartId.ToString() : "0") + "|-1|-1";
					mainTree.Text = item.CrmSysPartTitle + "-" + item.FOSysPartTitle;
					mainTree.ImageUrl = "";
					if (Enumerable.FirstOrDefault<TreeViewItemModel>((IEnumerable<TreeViewItemModel>)list12, (Func<TreeViewItemModel, bool>)((TreeViewItemModel m) => m.Id == mainTree.Id)) != null)
					{
						continue;
					}
					List<CRMspDySelectFormsForWorkflow_Result> list13 = Enumerable.ToList<CRMspDySelectFormsForWorkflow_Result>(Enumerable.Where<CRMspDySelectFormsForWorkflow_Result>((IEnumerable<CRMspDySelectFormsForWorkflow_Result>)list11, (Func<CRMspDySelectFormsForWorkflow_Result, bool>)((CRMspDySelectFormsForWorkflow_Result c) => c.FOSysPartId == item.FOSysPartId && c.CrmSysPartId == item.CrmSysPartId)));
					List<TreeViewItemModel> list14 = new List<TreeViewItemModel>();
					foreach (CRMspDySelectFormsForWorkflow_Result item7 in list13)
					{
						TreeViewItemModel treeViewItemModel6 = new TreeViewItemModel();
						if (!item7.WorkflowId.HasValue || (workflowId > 0 && workflowId == item7.WorkflowId))
						{
							treeViewItemModel6.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item7.FormId.ToString()));
							treeViewItemModel6.Id = item7.FormId.ToString();
							treeViewItemModel6.Text = item7.FormName;
						}
						else
						{
							treeViewItemModel6.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item7.WorkflowId + "|" + item7.FormId));
							treeViewItemModel6.Id = item7.WorkflowId + "|" + item7.FormId;
							treeViewItemModel6.Text = item7.FormName + " " + string.Format(Labels.DyFrmWorkflowNameIE, item7.Workflow ?? "");
						}
						treeViewItemModel6.ImageUrl = "";
						treeViewItemModel6.Items = new List<TreeViewItemModel>();
						list14.Add(treeViewItemModel6);
					}
					mainTree.Items = new List<TreeViewItemModel>(list14);
					list12.Add(mainTree);
				}
				treeViewItemModel5.Items = new List<TreeViewItemModel>(list12);
				list.Add(treeViewItemModel5);
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
	public ActionResult _PartialFormsTree(int workflowId, int formId)
	{
		try
		{
			base.ViewBag.FormsTree = GetFormsTree(workflowId, formId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView();
	}

	[AjaxOnly]
	public string ActDelete(int workflowId)
	{
		_003C_003Ec__DisplayClass10_0 _003C_003Ec__DisplayClass10_ = new _003C_003Ec__DisplayClass10_0();
		_003C_003Ec__DisplayClass10_.workflowId = workflowId;
		string result = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmDyDefineFormWorkflow", "actDelete", currentUser))
			{
				return Messages.ErrorNotAccess;
			}
			if (_003C_003Ec__DisplayClass10_.workflowId > 0)
			{
				DbSet<CrmDyFormWorkflows> crmDyFormWorkflows = _dbTbl.CrmDyFormWorkflows;
				ParameterExpression val = Expression.Parameter(typeof(CrmDyFormWorkflows), "m");
				if (Queryable.FirstOrDefault<CrmDyFormWorkflows>((IQueryable<CrmDyFormWorkflows>)crmDyFormWorkflows, Expression.Lambda<Func<CrmDyFormWorkflows, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass10_, typeof(_003C_003Ec__DisplayClass10_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
				{
					try
					{
						mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspDyDeleteFormWorkflow(_003C_003Ec__DisplayClass10_.workflowId));
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
						result = Messages.msgErrorRunFunction;
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

	public JsonResult FormWorkflowStepsListJs(int workflowId = 0)
	{
		List<CRMspDySelectFormWorkflowSteps_Result> data = new List<CRMspDySelectFormWorkflowSteps_Result>();
		try
		{
			if (workflowId > 0)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				data = Enumerable.ToList<CRMspDySelectFormWorkflowSteps_Result>((IEnumerable<CRMspDySelectFormWorkflowSteps_Result>)_db.CRMspDySelectFormWorkflowSteps(workflowId, lCID, result));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[LoginAuthorize]
	public ActionResult Details(int workflowId, int position = 0)
	{
		string text = "";
		string text2 = "";
		switch (position)
		{
		case 0:
			text = "frmDyDefineFormWorkflow";
			text2 = "actDefineWorkflowSteps";
			break;
		case 1:
			text = "frmDyDefineForm";
			text2 = "actGotoWorkflowSteps";
			break;
		}
		if (text != "" && text2 != "" && !UserLogin.IsUserAccess(text, text2, UserLogin.CurrentUser))
		{
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		base.ViewBag.WorkflowId = workflowId;
		int num = 0;
		string text3 = "";
		string text4 = "";
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			CRMspDySelectFormWorkflowWithId_Result cRMspDySelectFormWorkflowWithId_Result = Enumerable.FirstOrDefault<CRMspDySelectFormWorkflowWithId_Result>((IEnumerable<CRMspDySelectFormWorkflowWithId_Result>)_db.CRMspDySelectFormWorkflowWithId(workflowId, lCID, result));
			if (cRMspDySelectFormWorkflowWithId_Result != null)
			{
				text4 = cRMspDySelectFormWorkflowWithId_Result.WorkflowTitle ?? "";
				num = cRMspDySelectFormWorkflowWithId_Result.DyFormId;
				text3 = cRMspDySelectFormWorkflowWithId_Result.DyForm ?? "";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.DyFormId = num;
		base.ViewBag.DyForm = text3;
		base.ViewBag.WorkflowTitle = text4;
		return View();
	}

	public List<CRMspDySelectFormWorkflowSteps_Result> ListWorkflowDetails(int workflowId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspDySelectFormWorkflowSteps_Result> list = new List<CRMspDySelectFormWorkflowSteps_Result>();
		try
		{
			list = Enumerable.ToList<CRMspDySelectFormWorkflowSteps_Result>((IEnumerable<CRMspDySelectFormWorkflowSteps_Result>)_db.CRMspDySelectFormWorkflowSteps(workflowId, lCID, result));
			foreach (CRMspDySelectFormWorkflowSteps_Result item in list)
			{
				if (string.IsNullOrEmpty(item.AppType))
				{
					item.AppType = Configuration.AppType;
				}
				item.AppType = Configuration.GetAppType(item.AppType);
				string text = item.FirstRegisterUser ?? "";
				_ = item.FirstRegisterDate;
				string text2 = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
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

	[AjaxOnly]
	public ActionResult WorkflowDetials_Read([DataSourceRequest] DataSourceRequest request, int workflowId)
	{
		return Json(((IEnumerable)ListWorkflowDetails(workflowId)).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult WorkflowDetailsList(int workflowId)
	{
		return Json(ListWorkflowDetails(workflowId), JsonRequestBehavior.AllowGet);
	}

	public string GetUsersName(string usersId)
	{
		string text = "";
		try
		{
			if (!string.IsNullOrEmpty(usersId))
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				_ = Thread.CurrentThread.CurrentCulture.LCID;
				List<CRMspSelectUsers_Result> users = CRMIdeal.Classes.Helper.User.SelectUsers(0);
				if (Enumerable.Any<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)users))
				{
					text = Enumerable.Aggregate<CRMspSelectUsers_Result, string>(Enumerable.Where<CRMspSelectUsers_Result>(Enumerable.Select<string, CRMspSelectUsers_Result>(Enumerable.Where<string>((IEnumerable<string>)usersId.Split(new char[1] { '|' }), (Func<string, bool>)((string us) => !string.IsNullOrEmpty(us))), (Func<string, CRMspSelectUsers_Result>)((string us) => Enumerable.FirstOrDefault<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)users, (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result m) => m.UserId == int.Parse(us))))), (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result u) => u != null)), text, (Func<string, CRMspSelectUsers_Result, string>)((string current, CRMspSelectUsers_Result u) => current + ((!string.IsNullOrEmpty(u.LName)) ? u.LName : "") + ((!string.IsNullOrEmpty(u.FName)) ? (" " + u.FName + " ") : "") + ","));
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

	[AjaxOnly]
	public JsonResult GetSubForm(int parentFormId, int workflowStepId = 0)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		string text = "";
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
			List<CRMspDySelectFormsForWorkflowSteps_Result> list2 = Enumerable.ToList<CRMspDySelectFormsForWorkflowSteps_Result>((IEnumerable<CRMspDySelectFormsForWorkflowSteps_Result>)_db.CRMspDySelectFormsForWorkflowSteps(workflowStepId, parentFormId, UserLogin.CurrentUser.UserId, lCID, result, result2));
			if (list2 != null && Enumerable.Any<CRMspDySelectFormsForWorkflowSteps_Result>((IEnumerable<CRMspDySelectFormsForWorkflowSteps_Result>)list2))
			{
				foreach (CRMspDySelectFormsForWorkflowSteps_Result item in list2)
				{
					if (string.IsNullOrWhiteSpace(item.FOSysPartShow))
					{
						item.FOSysPartId = null;
					}
				}
			}
			foreach (CRMspDySelectFormsForWorkflowSteps_Result item2 in list2)
			{
				SelectListItem selectListItem = new SelectListItem();
				if (!item2.WorkflowStepId.HasValue || (workflowStepId > 0 && workflowStepId == item2.WorkflowStepId))
				{
					selectListItem.Text = item2.FormName;
					selectListItem.Value = item2.FormId.ToString();
					selectListItem.Selected = false;
				}
				else
				{
					selectListItem.Text = item2.FormName + " " + string.Format(Labels.DyFrmWorkflowDetailNameIE, item2.WorkflowStep ?? "");
					selectListItem.Value = "-1";
					selectListItem.Selected = false;
				}
				text = text + item2.FormId + "^-^" + ((!string.IsNullOrEmpty(item2.EnableForUsersId)) ? item2.EnableForUsersId : "0") + "^-^" + ((!string.IsNullOrEmpty(item2.EnableForUsers)) ? item2.EnableForUsers : "0") + "^-^" + ((item2.EnableForRollId.HasValue && item2.EnableForRollId > 0) ? item2.EnableForRollId.ToString() : "0") + "^@^";
				list.Add(selectListItem);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.SubFormsList = list;
		base.ViewBag.ListReferUsres = text;
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

	public ActionResult InsertEditDetail(int workflowId, int parentFormId, int workflowDetailId = 0)
	{
		_003C_003Ec__DisplayClass20_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass20_0();
		CS_0024_003C_003E8__locals0.workflowDetailId = workflowDetailId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		DbSet<CrmDyFormWorkflowSteps_Lang> crmDyFormWorkflowSteps_Lang = _dbTbl.CrmDyFormWorkflowSteps_Lang;
		ParameterExpression val = Expression.Parameter(typeof(CrmDyFormWorkflowSteps_Lang), "c");
		List<CrmDyFormWorkflowSteps_Lang> list = Enumerable.ToList<CrmDyFormWorkflowSteps_Lang>((IEnumerable<CrmDyFormWorkflowSteps_Lang>)Queryable.Where<CrmDyFormWorkflowSteps_Lang>((IQueryable<CrmDyFormWorkflowSteps_Lang>)crmDyFormWorkflowSteps_Lang, Expression.Lambda<Func<CrmDyFormWorkflowSteps_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass20_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
		DateTime now = DateTime.Now;
		CrmDyFormWorkflowSteps crmDyFormWorkflowSteps = new CrmDyFormWorkflowSteps();
		if (CS_0024_003C_003E8__locals0.workflowDetailId == 0)
		{
			if (!UserLogin.IsUserAccess("frmDyDefineFormWorkflowSteps", "actInsert", UserLogin.CurrentUser))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			crmDyFormWorkflowSteps = new CrmDyFormWorkflowSteps();
			crmDyFormWorkflowSteps.FormWorkflowStepId = 0;
			crmDyFormWorkflowSteps.RegisterDate = now;
			crmDyFormWorkflowSteps.FirstRegisterDate = now;
			crmDyFormWorkflowSteps.WorkflowId = workflowId;
			crmDyFormWorkflowSteps.IsActive = true;
			if (!crmDyFormWorkflowSteps.OrderView.HasValue || crmDyFormWorkflowSteps.OrderView <= 0)
			{
				List<CRMspDySelectFormWorkflowSteps_Result> list2 = Enumerable.ToList<CRMspDySelectFormWorkflowSteps_Result>((IEnumerable<CRMspDySelectFormWorkflowSteps_Result>)_db.CRMspDySelectFormWorkflowSteps(workflowId, CS_0024_003C_003E8__locals0.currLangID, result));
				_ = Enumerable.FirstOrDefault<CRMspDySelectFormWorkflowSteps_Result>((IEnumerable<CRMspDySelectFormWorkflowSteps_Result>)Enumerable.OrderByDescending<CRMspDySelectFormWorkflowSteps_Result, int?>((IEnumerable<CRMspDySelectFormWorkflowSteps_Result>)list2, (Func<CRMspDySelectFormWorkflowSteps_Result, int?>)((CRMspDySelectFormWorkflowSteps_Result m) => m.OrderView)))?.OrderView;
				int num = (Enumerable.Any<CRMspDySelectFormWorkflowSteps_Result>((IEnumerable<CRMspDySelectFormWorkflowSteps_Result>)list2) ? Enumerable.Count<CRMspDySelectFormWorkflowSteps_Result>((IEnumerable<CRMspDySelectFormWorkflowSteps_Result>)list2) : 0);
				crmDyFormWorkflowSteps.OrderView = num + 10 + num * 9 - 5;
			}
		}
		else
		{
			if (!UserLogin.IsUserAccess("frmDyDefineFormWorkflowSteps", "actEdit", UserLogin.CurrentUser))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			DbSet<CrmDyFormWorkflowSteps> crmDyFormWorkflowSteps2 = _dbTbl.CrmDyFormWorkflowSteps;
			val = Expression.Parameter(typeof(CrmDyFormWorkflowSteps), "m");
			crmDyFormWorkflowSteps = Queryable.FirstOrDefault<CrmDyFormWorkflowSteps>((IQueryable<CrmDyFormWorkflowSteps>)crmDyFormWorkflowSteps2, Expression.Lambda<Func<CrmDyFormWorkflowSteps, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass20_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmDyFormWorkflowSteps == null)
			{
				crmDyFormWorkflowSteps = new CrmDyFormWorkflowSteps();
				crmDyFormWorkflowSteps.FormWorkflowStepId = 0;
				crmDyFormWorkflowSteps.RegisterDate = now;
				crmDyFormWorkflowSteps.FirstRegisterDate = now;
				crmDyFormWorkflowSteps.WorkflowId = workflowId;
				crmDyFormWorkflowSteps.IsActive = true;
			}
		}
		List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmDyFormWorkflowSteps_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmDyFormWorkflowSteps_Lang>)list, (Func<CrmDyFormWorkflowSteps_Lang, CommonMultiLanguageViewModel>)((CrmDyFormWorkflowSteps_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.WorkflowStepTitle,
			LanguageId = item.LanguageID
		})));
		list3.Add(new CommonMultiLanguageViewModel
		{
			Value = crmDyFormWorkflowSteps.WorkflowStepTitle,
			LanguageId = result
		});
		CrmDyFormWorkflowStepsLanguageViewModel crmDyFormWorkflowStepsLanguageViewModel = new CrmDyFormWorkflowStepsLanguageViewModel
		{
			FormWorkflowStepId = crmDyFormWorkflowSteps.FormWorkflowStepId,
			WorkflowId = crmDyFormWorkflowSteps.WorkflowId,
			WorkflowStepTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			WorkflowStepTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
			SubFormId = crmDyFormWorkflowSteps.SubFormId,
			ReferUserIds = crmDyFormWorkflowSteps.ReferUserIds,
			ReferRollId = crmDyFormWorkflowSteps.ReferRollId,
			MultiReferUserIds = crmDyFormWorkflowSteps.MultiReferUserIds,
			CheckerUserIds = crmDyFormWorkflowSteps.CheckerUserIds,
			NoPrevious = crmDyFormWorkflowSteps.NoPrevious,
			NoNextWithOutCheck = crmDyFormWorkflowSteps.NoNextWithOutCheck,
			OrderView = crmDyFormWorkflowSteps.OrderView,
			ProgressPercent = crmDyFormWorkflowSteps.ProgressPercent,
			FirstRegisterUserId = crmDyFormWorkflowSteps.FirstRegisterUserId,
			FirstRegisterDate = crmDyFormWorkflowSteps.FirstRegisterDate,
			FirstRegisterDatePersian = crmDyFormWorkflowSteps.FirstRegisterDatePersian,
			UserId = crmDyFormWorkflowSteps.UserId,
			Year1 = crmDyFormWorkflowSteps.Year1,
			Month1 = crmDyFormWorkflowSteps.Month1,
			RegisterDate = crmDyFormWorkflowSteps.RegisterDate,
			RegisterDatePersian = crmDyFormWorkflowSteps.RegisterDatePersian,
			GUId = crmDyFormWorkflowSteps.GUId,
			AppType = crmDyFormWorkflowSteps.AppType,
			LanguageID = crmDyFormWorkflowSteps.LanguageID,
			IsActive = crmDyFormWorkflowSteps.IsActive,
			ParentFormId = parentFormId,
			CheckerRollId = crmDyFormWorkflowSteps.CheckerRollId
		};
		GetSubForm(parentFormId, CS_0024_003C_003E8__locals0.workflowDetailId);
		GetRolls();
		base.ViewBag.MultiReferUserIds = GetUsersName(crmDyFormWorkflowStepsLanguageViewModel.MultiReferUserIds);
		base.ViewBag.CheckerUserIds = GetUsersName(crmDyFormWorkflowStepsLanguageViewModel.CheckerUserIds);
		base.ViewBag.ReferUserIds = GetUsersName(crmDyFormWorkflowStepsLanguageViewModel.ReferUserIds);
		return View(crmDyFormWorkflowStepsLanguageViewModel);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDyDefineFormWorkflowStepsDataEntry", ActionName = "actPost")]
	public ActionResult InsertEditDetail(CrmDyFormWorkflowStepsLanguageViewModel vm)
	{
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass21_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass21_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		GetSubForm(CS_0024_003C_003E8__locals0.vm.ParentFormId, CS_0024_003C_003E8__locals0.vm.FormWorkflowStepId);
		GetRolls();
		base.ViewBag.MultiReferUserIds = GetUsersName(CS_0024_003C_003E8__locals0.vm.MultiReferUserIds);
		base.ViewBag.CheckerUserIds = GetUsersName(CS_0024_003C_003E8__locals0.vm.CheckerUserIds);
		base.ViewBag.ReferUserIds = GetUsersName(CS_0024_003C_003E8__locals0.vm.ReferUserIds);
		if (base.ModelState.IsValid)
		{
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.WorkflowStepTitle_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.WorkflowStepTitle_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.WorkflowStepTitle,
				LanguageId = lCID
			});
			if (CS_0024_003C_003E8__locals0.vm.WorkflowStepTitle == null)
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.DyFrmWorkflowDetailTitle) + "<br/>";
				num++;
			}
			else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.WorkflowStepTitle, list))
			{
				text = text + string.Format(Messages.CheckFieldInLang, Labels.DyFrmWorkflowDetailTitle) + "<br>";
				num++;
			}
			if (num == 0)
			{
				DateTime now = DateTime.Now;
				try
				{
					_003C_003Ec__DisplayClass21_1 _003C_003Ec__DisplayClass21_ = new _003C_003Ec__DisplayClass21_1();
					_003C_003Ec__DisplayClass21_.model = new CrmDyFormWorkflowSteps();
					if (CS_0024_003C_003E8__locals0.vm.FormWorkflowStepId > 0)
					{
						DbSet<CrmDyFormWorkflowSteps> crmDyFormWorkflowSteps = _dbTbl.CrmDyFormWorkflowSteps;
						ParameterExpression val = Expression.Parameter(typeof(CrmDyFormWorkflowSteps), "m");
						_003C_003Ec__DisplayClass21_.model = Queryable.FirstOrDefault<CrmDyFormWorkflowSteps>((IQueryable<CrmDyFormWorkflowSteps>)crmDyFormWorkflowSteps, Expression.Lambda<Func<CrmDyFormWorkflowSteps, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass21_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					}
					_003C_003Ec__DisplayClass21_.model.WorkflowStepTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					_003C_003Ec__DisplayClass21_.model.SubFormId = CS_0024_003C_003E8__locals0.vm.SubFormId;
					_003C_003Ec__DisplayClass21_.model.ReferUserIds = CS_0024_003C_003E8__locals0.vm.ReferUserIds;
					_003C_003Ec__DisplayClass21_.model.ReferRollId = CS_0024_003C_003E8__locals0.vm.ReferRollId;
					_003C_003Ec__DisplayClass21_.model.MultiReferUserIds = CS_0024_003C_003E8__locals0.vm.MultiReferUserIds;
					_003C_003Ec__DisplayClass21_.model.CheckerUserIds = CS_0024_003C_003E8__locals0.vm.CheckerUserIds;
					_003C_003Ec__DisplayClass21_.model.NoPrevious = CS_0024_003C_003E8__locals0.vm.NoPrevious;
					_003C_003Ec__DisplayClass21_.model.NoNextWithOutCheck = CS_0024_003C_003E8__locals0.vm.NoNextWithOutCheck;
					_003C_003Ec__DisplayClass21_.model.OrderView = CS_0024_003C_003E8__locals0.vm.OrderView;
					_003C_003Ec__DisplayClass21_.model.ProgressPercent = CS_0024_003C_003E8__locals0.vm.ProgressPercent;
					_003C_003Ec__DisplayClass21_.model.UserId = UserLogin.CurrentUser.UserId;
					_003C_003Ec__DisplayClass21_.model.Year1 = short.Parse(Financial.Get().Id.ToString());
					_003C_003Ec__DisplayClass21_.model.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
					_003C_003Ec__DisplayClass21_.model.RegisterDate = now;
					_003C_003Ec__DisplayClass21_.model.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					_003C_003Ec__DisplayClass21_.model.AppType = Configuration.AppType;
					_003C_003Ec__DisplayClass21_.model.IsActive = CS_0024_003C_003E8__locals0.vm.IsActive;
					_003C_003Ec__DisplayClass21_.model.CheckerRollId = CS_0024_003C_003E8__locals0.vm.CheckerRollId;
					if (CS_0024_003C_003E8__locals0.vm.FormWorkflowStepId > 0)
					{
						_dbTbl.Entry(_003C_003Ec__DisplayClass21_.model).State = EntityState.Modified;
						_dbTbl.Configuration.ValidateOnSaveEnabled = false;
						_dbTbl.SaveChanges();
						_dbTbl.Configuration.ValidateOnSaveEnabled = true;
						using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								_003C_003Ec__DisplayClass21_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass21_2();
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass21_;
								CS_0024_003C_003E8__locals1.lang = enumerator.Current;
								DbSet<CrmDyFormWorkflowSteps_Lang> crmDyFormWorkflowSteps_Lang = _dbTbl.CrmDyFormWorkflowSteps_Lang;
								ParameterExpression val = Expression.Parameter(typeof(CrmDyFormWorkflowSteps_Lang), "c");
								CrmDyFormWorkflowSteps_Lang crmDyFormWorkflowSteps_Lang2 = Queryable.FirstOrDefault<CrmDyFormWorkflowSteps_Lang>((IQueryable<CrmDyFormWorkflowSteps_Lang>)crmDyFormWorkflowSteps_Lang, Expression.Lambda<Func<CrmDyFormWorkflowSteps_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass21_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass21_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (crmDyFormWorkflowSteps_Lang2 != null)
								{
									crmDyFormWorkflowSteps_Lang2.WorkflowStepTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									_dbTbl.Entry(crmDyFormWorkflowSteps_Lang2).State = EntityState.Modified;
									_dbTbl.SaveChanges();
									continue;
								}
								crmDyFormWorkflowSteps_Lang2 = new CrmDyFormWorkflowSteps_Lang();
								crmDyFormWorkflowSteps_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
								crmDyFormWorkflowSteps_Lang2.FormWorkflowStepId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.FormWorkflowStepId;
								crmDyFormWorkflowSteps_Lang2.WorkflowStepTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.CrmDyFormWorkflowSteps_Lang.Add(crmDyFormWorkflowSteps_Lang2);
								_dbTbl.SaveChanges();
							}
						}
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					}
					else
					{
						_003C_003Ec__DisplayClass21_.model.WorkflowId = CS_0024_003C_003E8__locals0.vm.WorkflowId;
						_003C_003Ec__DisplayClass21_.model.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
						_003C_003Ec__DisplayClass21_.model.FirstRegisterDate = now;
						_003C_003Ec__DisplayClass21_.model.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						_003C_003Ec__DisplayClass21_.model.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
						_003C_003Ec__DisplayClass21_.model.GUId = Guid.NewGuid();
						_dbTbl.CrmDyFormWorkflowSteps.Add(_003C_003Ec__DisplayClass21_.model);
						_dbTbl.Configuration.ValidateOnSaveEnabled = false;
						_dbTbl.SaveChanges();
						_dbTbl.Configuration.ValidateOnSaveEnabled = true;
						foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
						{
							CrmDyFormWorkflowSteps_Lang crmDyFormWorkflowSteps_Lang3 = new CrmDyFormWorkflowSteps_Lang();
							crmDyFormWorkflowSteps_Lang3.LanguageID = lang.LanguageID;
							crmDyFormWorkflowSteps_Lang3.FormWorkflowStepId = _003C_003Ec__DisplayClass21_.model.FormWorkflowStepId;
							crmDyFormWorkflowSteps_Lang3.WorkflowStepTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
							_dbTbl.CrmDyFormWorkflowSteps_Lang.Add(crmDyFormWorkflowSteps_Lang3);
							_dbTbl.SaveChanges();
						}
						base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					text = Messages.msgErrorRunFunction;
				}
			}
		}
		if (text != "")
		{
			base.ViewBag.Error = text;
		}
		return View(CS_0024_003C_003E8__locals0.vm);
	}

	[AjaxOnly]
	public string ActDeleteDetail(int workflowDetailId)
	{
		_003C_003Ec__DisplayClass22_0 _003C_003Ec__DisplayClass22_ = new _003C_003Ec__DisplayClass22_0();
		_003C_003Ec__DisplayClass22_.workflowDetailId = workflowDetailId;
		string result = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmDyDefineFormWorkflowSteps", "actDelete", currentUser))
			{
				return Messages.ErrorNotAccess;
			}
			if (_003C_003Ec__DisplayClass22_.workflowDetailId > 0)
			{
				DbSet<CrmDyFormWorkflowSteps> crmDyFormWorkflowSteps = _dbTbl.CrmDyFormWorkflowSteps;
				ParameterExpression val = Expression.Parameter(typeof(CrmDyFormWorkflowSteps), "m");
				if (Queryable.FirstOrDefault<CrmDyFormWorkflowSteps>((IQueryable<CrmDyFormWorkflowSteps>)crmDyFormWorkflowSteps, Expression.Lambda<Func<CrmDyFormWorkflowSteps, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass22_, typeof(_003C_003Ec__DisplayClass22_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
				{
					try
					{
						mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspDyDeleteFormWorkflowStep(_003C_003Ec__DisplayClass22_.workflowDetailId));
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
						result = Messages.msgErrorRunFunction;
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

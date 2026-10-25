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

namespace CRMIdeal.Areas.FormBase.Controllers;

public class VerificationWorkflowController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass33_0
	{
		public int workflowStepId;

		public int currLangID;

		public WSVerificationWorkFlowStepsLanguageViewModel model;

		internal bool _003CInsertEditStep_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEditStep_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEditStep_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEditStep_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEditStep_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEditStep_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEditStep_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEditStep_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEditStep_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEditStep_003Eb__17(WSVerificationWorkFlows_Lang x)
		{
			return x.LanguageID == currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass34_0
	{
		public WSVerificationWorkFlowStepsLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__8;

		public Func<Languages, bool> _003C_003E9__22;

		internal bool _003CInsertEditStep_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEditStep_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEditStep_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEditStep_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEditStep_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEditStep_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEditStep_003Eb__8(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEditStep_003Eb__22(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass34_1
	{
		public WSVerificationWorkFlowSteps model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass34_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass34_1 CS_0024_003C_003E8__locals1;

		internal bool _003CInsertEditStep_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEditStep_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEditStep_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEditStep_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEditStep_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEditStep_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEditStep_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEditStep_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEditStep_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEditStep_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEditStep_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEditStep_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass35_0
	{
		public int workflowStepId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public int workflowId;

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

		internal bool _003CInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public WSVerificationWorkFlowsLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__7;

		public Func<Languages, bool> _003C_003E9__17;

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

		internal bool _003CInsertEdit_003Eb__7(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__17(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_1
	{
		public int objType;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_2
	{
		public WSVerificationWorkFlows model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_3
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass9_2 CS_0024_003C_003E8__locals1;

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

		internal bool _003CInsertEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	private const int ObjType_Pord = 10;

	private const int ObjType_Ord = 20;

	private const int ObjType_Bord = 40;

	private const int ObjType_StSup = 45;

	private const int ObjType_WH = 60;

	private const int ObjType_DyForm = 80;

	private const int ObjType_Leave = 90;

	private const int ObjType_Mission = 100;

	private const int ObjType_Letter = 110;

	private const int ObjType_ShiftWorking = 120;

	private const int ObjType_Fund = 130;

	[LoginAuthorize]
	public ActionResult Index(int objType = 10)
	{
		string text = "";
		string text2 = "";
		switch (objType)
		{
		case 10:
			text = "frmMain";
			text2 = "actpordDefineVerificationWorkflow";
			break;
		case 20:
			text = "frmMain";
			text2 = "actordDefineVerificationWorkflow";
			break;
		case 40:
			text = "frmMain";
			text2 = "actbordDefineVerificationWorkflow";
			break;
		case 45:
			text = "frmMain";
			text2 = "actstsupDefineVerificationWorkflow";
			break;
		case 80:
			text = "frmMain";
			text2 = "actdyDefineVerificationWorkflow";
			break;
		case 60:
			text = "frmMain";
			text2 = "actdocDefineVerificationWorkflow";
			break;
		case 90:
			text = "frmMain";
			text2 = "acthrLeaveDefineVerificationWorkflow";
			break;
		case 100:
			text = "frmMain";
			text2 = "acthrMissionDefineVerificationWorkflow";
			break;
		case 110:
			text = "frmMain";
			text2 = "actltrDefineVerificationWorkflow";
			break;
		case 130:
			text = "frmMain";
			text2 = "actFundDefineVerificationWorkflow";
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

	public List<WSspSelectVerificationWorkFlows_Result> ListWorkflows()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectVerificationWorkFlows_Result> list = new List<WSspSelectVerificationWorkFlows_Result>();
		try
		{
			list = Enumerable.ToList<WSspSelectVerificationWorkFlows_Result>((IEnumerable<WSspSelectVerificationWorkFlows_Result>)_db.WSspSelectVerificationWorkFlows(lCID, result));
			foreach (WSspSelectVerificationWorkFlows_Result item in list)
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
				item.AppType = "";
				if (item.ObjectType.GetValueOrDefault() == 10)
				{
					item.AppType = Labels.lblPOrd;
				}
				else if (item.ObjectType.GetValueOrDefault() == 20)
				{
					item.AppType = Labels.lblOrd;
				}
				else if (item.ObjectType.GetValueOrDefault() == 40)
				{
					item.AppType = Labels.lblBOrd;
				}
				else if (item.ObjectType.GetValueOrDefault() == 45)
				{
					item.AppType = Labels.lblStsup;
				}
				else if (item.ObjectType.GetValueOrDefault() == 60)
				{
					item.AppType = Labels.lblWareHouse;
				}
				else if (item.ObjectType.GetValueOrDefault() == 80)
				{
					item.AppType = Labels.lblDyForm;
				}
				else if (item.ObjectType.GetValueOrDefault() == 90)
				{
					item.AppType = Labels.lblLeave;
				}
				else if (item.ObjectType.GetValueOrDefault() == 100)
				{
					item.AppType = Labels.lblMission;
				}
				else if (item.ObjectType.GetValueOrDefault() == 110)
				{
					item.AppType = Labels.lblLetter;
				}
				else if (item.ObjectType.GetValueOrDefault() == 130)
				{
					item.AppType = Labels.lblFund;
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
		_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass8_0();
		CS_0024_003C_003E8__locals0.workflowId = workflowId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		DbSet<WSVerificationWorkFlows_Lang> wSVerificationWorkFlows_Lang = _dbTbl.WSVerificationWorkFlows_Lang;
		ParameterExpression val = Expression.Parameter(typeof(WSVerificationWorkFlows_Lang), "c");
		List<WSVerificationWorkFlows_Lang> list = Enumerable.ToList<WSVerificationWorkFlows_Lang>((IEnumerable<WSVerificationWorkFlows_Lang>)Queryable.Where<WSVerificationWorkFlows_Lang>((IQueryable<WSVerificationWorkFlows_Lang>)wSVerificationWorkFlows_Lang, Expression.Lambda<Func<WSVerificationWorkFlows_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
		DateTime now = DateTime.Now;
		WSVerificationWorkFlows wSVerificationWorkFlows = new WSVerificationWorkFlows();
		if (CS_0024_003C_003E8__locals0.workflowId == 0)
		{
			if (!UserLogin.IsUserAccess("frmDefineVerificationWorkflow", "actInsert", UserLogin.CurrentUser))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			wSVerificationWorkFlows = new WSVerificationWorkFlows();
			wSVerificationWorkFlows.VerificationWorkFlowId = 0;
			wSVerificationWorkFlows.RegisterDate = now;
			wSVerificationWorkFlows.FirstRegisterDate = now;
			wSVerificationWorkFlows.IsActive = true;
		}
		else
		{
			if (!UserLogin.IsUserAccess("frmDefineVerificationWorkflow", "actEdit", UserLogin.CurrentUser))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			DbSet<WSVerificationWorkFlows> wSVerificationWorkFlows2 = _dbTbl.WSVerificationWorkFlows;
			val = Expression.Parameter(typeof(WSVerificationWorkFlows), "m");
			wSVerificationWorkFlows = Queryable.FirstOrDefault<WSVerificationWorkFlows>((IQueryable<WSVerificationWorkFlows>)wSVerificationWorkFlows2, Expression.Lambda<Func<WSVerificationWorkFlows, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (wSVerificationWorkFlows == null)
			{
				wSVerificationWorkFlows = new WSVerificationWorkFlows();
				wSVerificationWorkFlows.VerificationWorkFlowId = 0;
				wSVerificationWorkFlows.RegisterDate = now;
				wSVerificationWorkFlows.FirstRegisterDate = now;
				wSVerificationWorkFlows.IsActive = true;
			}
		}
		List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSVerificationWorkFlows_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSVerificationWorkFlows_Lang>)list, (Func<WSVerificationWorkFlows_Lang, CommonMultiLanguageViewModel>)((WSVerificationWorkFlows_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.VerificationWorkFlowTitle,
			LanguageId = item.LanguageID
		})));
		list2.Add(new CommonMultiLanguageViewModel
		{
			Value = wSVerificationWorkFlows.VerificationWorkFlowTitle,
			LanguageId = result
		});
		List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSVerificationWorkFlows_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSVerificationWorkFlows_Lang>)list, (Func<WSVerificationWorkFlows_Lang, CommonMultiLanguageViewModel>)((WSVerificationWorkFlows_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.VerifyRequestText,
			LanguageId = item.LanguageID
		})));
		list3.Add(new CommonMultiLanguageViewModel
		{
			Value = wSVerificationWorkFlows.VerifyRequestText,
			LanguageId = result
		});
		WSVerificationWorkFlowsLanguageViewModel model = new WSVerificationWorkFlowsLanguageViewModel
		{
			VerificationWorkFlowId = wSVerificationWorkFlows.VerificationWorkFlowId,
			VerificationWorkFlowTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			VerificationWorkFlowTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
			VerifyRequestText = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			VerifyRequestText_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
			SequenceObservation = wSVerificationWorkFlows.SequenceObservation,
			IsActive = wSVerificationWorkFlows.IsActive,
			FirstRegisterUserId = wSVerificationWorkFlows.FirstRegisterUserId,
			FirstRegisterDate = wSVerificationWorkFlows.FirstRegisterDate,
			FirstRegisterDatePersian = wSVerificationWorkFlows.FirstRegisterDatePersian,
			UserId = wSVerificationWorkFlows.UserId,
			Year1 = wSVerificationWorkFlows.Year1,
			Month1 = wSVerificationWorkFlows.Month1,
			RegisterDate = wSVerificationWorkFlows.RegisterDate,
			RegisterDatePersian = wSVerificationWorkFlows.RegisterDatePersian,
			GUId = wSVerificationWorkFlows.GUId,
			AppType = wSVerificationWorkFlows.AppType,
			LanguageID = wSVerificationWorkFlows.LanguageID,
			ObjectType = wSVerificationWorkFlows.ObjectType
		};
		GetObjectType();
		return View(model);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefineVerificationWorkflowDataEntry", ActionName = "actPost")]
	public ActionResult InsertEdit(WSVerificationWorkFlowsLanguageViewModel vm)
	{
		//IL_0321: Unknown result type (might be due to invalid IL or missing references)
		//IL_0375: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass9_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		GetObjectType();
		if (base.ModelState.IsValid)
		{
			if (CS_0024_003C_003E8__locals0.vm.VerificationWorkFlowId <= 0 && !VersionBuyer.VerificationWorkFlow)
			{
				_003C_003Ec__DisplayClass9_1 _003C_003Ec__DisplayClass9_ = new _003C_003Ec__DisplayClass9_1();
				_003C_003Ec__DisplayClass9_.objType = 0;
				int.TryParse(CS_0024_003C_003E8__locals0.vm.ObjectType.ToString(), out _003C_003Ec__DisplayClass9_.objType);
				if ((_003C_003Ec__DisplayClass9_.objType == 90 || _003C_003Ec__DisplayClass9_.objType == 100) && VersionBuyer.Leave)
				{
					DbSet<WSVerificationWorkFlows> wSVerificationWorkFlows = _dbTbl.WSVerificationWorkFlows;
					ParameterExpression val = Expression.Parameter(typeof(WSVerificationWorkFlows), "m");
					List<WSVerificationWorkFlows> list = Enumerable.ToList<WSVerificationWorkFlows>((IEnumerable<WSVerificationWorkFlows>)Queryable.Where<WSVerificationWorkFlows>((IQueryable<WSVerificationWorkFlows>)wSVerificationWorkFlows, Expression.Lambda<Func<WSVerificationWorkFlows, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Coalesce((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)0, typeof(int))), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass9_, typeof(_003C_003Ec__DisplayClass9_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					if (list != null && Enumerable.Any<WSVerificationWorkFlows>((IEnumerable<WSVerificationWorkFlows>)list) && Enumerable.Count<WSVerificationWorkFlows>((IEnumerable<WSVerificationWorkFlows>)list) >= 3)
					{
						base.ViewBag.Error = "BV|" + string.Format(Messages.VersionBuyWithCount, "3");
						return View(CS_0024_003C_003E8__locals0.vm);
					}
				}
				else
				{
					DbSet<WSVerificationWorkFlows> wSVerificationWorkFlows2 = _dbTbl.WSVerificationWorkFlows;
					ParameterExpression val = Expression.Parameter(typeof(WSVerificationWorkFlows), "c");
					if (Queryable.Any<WSVerificationWorkFlows>((IQueryable<WSVerificationWorkFlows>)wSVerificationWorkFlows2, Expression.Lambda<Func<WSVerificationWorkFlows, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)1, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val })))
					{
						base.ViewBag.Error = "BV|" + string.Format(Messages.VersionBuyWithCount, "1");
						return View(CS_0024_003C_003E8__locals0.vm);
					}
				}
			}
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.VerificationWorkFlowTitle_Lang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.VerificationWorkFlowTitle_Lang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.VerificationWorkFlowTitle,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.VerifyRequestText_Lang))
			{
				list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.VerifyRequestText_Lang);
			}
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.VerifyRequestText,
				LanguageId = lCID
			});
			if (CS_0024_003C_003E8__locals0.vm.VerificationWorkFlowTitle == null)
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.VerificationWorkFlowTitle) + "<br/>";
				num++;
			}
			else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.VerificationWorkFlowTitle, list2))
			{
				text = text + string.Format(Messages.CheckFieldInLang, Labels.VerificationWorkFlowTitle) + "<br>";
				num++;
			}
			if (num == 0)
			{
				DateTime now = DateTime.Now;
				try
				{
					_003C_003Ec__DisplayClass9_2 _003C_003Ec__DisplayClass9_2 = new _003C_003Ec__DisplayClass9_2();
					_003C_003Ec__DisplayClass9_2.model = new WSVerificationWorkFlows();
					if (CS_0024_003C_003E8__locals0.vm.VerificationWorkFlowId > 0)
					{
						DbSet<WSVerificationWorkFlows> wSVerificationWorkFlows3 = _dbTbl.WSVerificationWorkFlows;
						ParameterExpression val = Expression.Parameter(typeof(WSVerificationWorkFlows), "m");
						_003C_003Ec__DisplayClass9_2.model = Queryable.FirstOrDefault<WSVerificationWorkFlows>((IQueryable<WSVerificationWorkFlows>)wSVerificationWorkFlows3, Expression.Lambda<Func<WSVerificationWorkFlows, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass9_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					}
					_003C_003Ec__DisplayClass9_2.model.VerificationWorkFlowTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					_003C_003Ec__DisplayClass9_2.model.VerifyRequestText = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					_003C_003Ec__DisplayClass9_2.model.UserId = UserLogin.CurrentUser.UserId;
					_003C_003Ec__DisplayClass9_2.model.Year1 = short.Parse(Financial.Get().Id.ToString());
					_003C_003Ec__DisplayClass9_2.model.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
					_003C_003Ec__DisplayClass9_2.model.RegisterDate = now;
					_003C_003Ec__DisplayClass9_2.model.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					_003C_003Ec__DisplayClass9_2.model.AppType = Configuration.AppType;
					_003C_003Ec__DisplayClass9_2.model.IsActive = CS_0024_003C_003E8__locals0.vm.IsActive;
					_003C_003Ec__DisplayClass9_2.model.SequenceObservation = CS_0024_003C_003E8__locals0.vm.SequenceObservation;
					_003C_003Ec__DisplayClass9_2.model.ObjectType = CS_0024_003C_003E8__locals0.vm.ObjectType;
					if (CS_0024_003C_003E8__locals0.vm.VerificationWorkFlowId > 0)
					{
						_dbTbl.Entry(_003C_003Ec__DisplayClass9_2.model).State = EntityState.Modified;
						_dbTbl.Configuration.ValidateOnSaveEnabled = false;
						_dbTbl.SaveChanges();
						_dbTbl.Configuration.ValidateOnSaveEnabled = true;
						using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								_003C_003Ec__DisplayClass9_3 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass9_3();
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass9_2;
								CS_0024_003C_003E8__locals1.lang = enumerator.Current;
								DbSet<WSVerificationWorkFlows_Lang> wSVerificationWorkFlows_Lang = _dbTbl.WSVerificationWorkFlows_Lang;
								ParameterExpression val = Expression.Parameter(typeof(WSVerificationWorkFlows_Lang), "c");
								WSVerificationWorkFlows_Lang wSVerificationWorkFlows_Lang2 = Queryable.FirstOrDefault<WSVerificationWorkFlows_Lang>((IQueryable<WSVerificationWorkFlows_Lang>)wSVerificationWorkFlows_Lang, Expression.Lambda<Func<WSVerificationWorkFlows_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass9_3)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass9_3)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (wSVerificationWorkFlows_Lang2 != null)
								{
									wSVerificationWorkFlows_Lang2.VerificationWorkFlowTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									wSVerificationWorkFlows_Lang2.VerifyRequestText = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									_dbTbl.Entry(wSVerificationWorkFlows_Lang2).State = EntityState.Modified;
									_dbTbl.SaveChanges();
									continue;
								}
								wSVerificationWorkFlows_Lang2 = new WSVerificationWorkFlows_Lang();
								wSVerificationWorkFlows_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
								wSVerificationWorkFlows_Lang2.VerificationWorkFlowId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.VerificationWorkFlowId;
								wSVerificationWorkFlows_Lang2.VerificationWorkFlowTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSVerificationWorkFlows_Lang2.VerifyRequestText = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.WSVerificationWorkFlows_Lang.Add(wSVerificationWorkFlows_Lang2);
								_dbTbl.SaveChanges();
							}
						}
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					}
					else
					{
						_003C_003Ec__DisplayClass9_2.model.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
						_003C_003Ec__DisplayClass9_2.model.FirstRegisterDate = now;
						_003C_003Ec__DisplayClass9_2.model.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						_003C_003Ec__DisplayClass9_2.model.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
						_003C_003Ec__DisplayClass9_2.model.GUId = Guid.NewGuid();
						_dbTbl.WSVerificationWorkFlows.Add(_003C_003Ec__DisplayClass9_2.model);
						_dbTbl.Configuration.ValidateOnSaveEnabled = false;
						_dbTbl.SaveChanges();
						_dbTbl.Configuration.ValidateOnSaveEnabled = true;
						foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
						{
							WSVerificationWorkFlows_Lang wSVerificationWorkFlows_Lang3 = new WSVerificationWorkFlows_Lang();
							wSVerificationWorkFlows_Lang3.LanguageID = lang.LanguageID;
							wSVerificationWorkFlows_Lang3.VerificationWorkFlowId = _003C_003Ec__DisplayClass9_2.model.VerificationWorkFlowId;
							wSVerificationWorkFlows_Lang3.VerificationWorkFlowTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
							wSVerificationWorkFlows_Lang3.VerifyRequestText = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
							_dbTbl.WSVerificationWorkFlows_Lang.Add(wSVerificationWorkFlows_Lang3);
							_dbTbl.SaveChanges();
						}
						base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
					}
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSVerificationWorkFlows");
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
	public string ActDelete(int workflowId)
	{
		string result = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmDefineVerificationWorkflow", "actDelete", currentUser))
			{
				return Messages.ErrorNotAccess;
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (workflowId > 0)
			{
				if (Enumerable.FirstOrDefault<WSspSelectVerificationWorkFlowWithId_Result>((IEnumerable<WSspSelectVerificationWorkFlowWithId_Result>)_db.WSspSelectVerificationWorkFlowWithId(workflowId, lCID, result2)) != null)
				{
					try
					{
						mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteVerificationWorkFlows(workflowId));
						if (mct_Result != null && mct_Result.Result > 0)
						{
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSVerificationWorkFlows");
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
		List<WSspSelectVerificationWorkFlowSteps_Result> data = new List<WSspSelectVerificationWorkFlowSteps_Result>();
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
				data = Enumerable.ToList<WSspSelectVerificationWorkFlowSteps_Result>((IEnumerable<WSspSelectVerificationWorkFlowSteps_Result>)_db.WSspSelectVerificationWorkFlowSteps(workflowId, lCID, result));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	public string GetObjectTypeName(int? id = 0)
	{
		string result = "";
		if (id.GetValueOrDefault() == 40)
		{
			result = Labels.lblBOrd;
		}
		else if (id.GetValueOrDefault() == 20)
		{
			result = Labels.lblOrd;
		}
		else if (id.GetValueOrDefault() == 10)
		{
			result = Labels.lblPOrd;
		}
		else if (id.GetValueOrDefault() == 45)
		{
			result = Labels.lblStsup;
		}
		else if (id.GetValueOrDefault() == 60)
		{
			result = Labels.lblWareHouse;
		}
		else if (id.GetValueOrDefault() == 80)
		{
			result = Labels.lblDyForm;
		}
		else if (id.GetValueOrDefault() == 90)
		{
			result = Labels.lblLeave;
		}
		else if (id.GetValueOrDefault() == 100)
		{
			result = Labels.lblMission;
		}
		else if (id.GetValueOrDefault() == 110)
		{
			result = Labels.lblLetter;
		}
		else if (id.GetValueOrDefault() == 120)
		{
			result = Labels.lblShiftWorking;
		}
		return result;
	}

	[AjaxOnly]
	public JsonResult GetObjectType()
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
			list.Add(new SelectListItem
			{
				Text = Labels.lblPOrd,
				Value = "10",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.lblOrd,
				Value = "20",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.lblBOrd,
				Value = "40",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.lblStsup,
				Value = "45",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.lblWareHouse,
				Value = "60",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.lblDyForm,
				Value = "80",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.lblLeave,
				Value = "90",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.lblMission,
				Value = "100",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.lblLetter,
				Value = "110",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.lblFund,
				Value = "130",
				Selected = false
			});
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ObjectTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public void GetVerifyUsers(int? objectTypeId = 0)
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
			List<CRMspSelectActiveUsers_Result> list2 = Enumerable.ToList<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)_db.CRMspSelectActiveUsers(lCID, result, 0));
			string userIds = "";
			if (objectTypeId.GetValueOrDefault() == 20)
			{
				userIds = "-101,-102,-103,-104,-106,-109";
			}
			else if (objectTypeId.GetValueOrDefault() == 10)
			{
				userIds = "-101,-102,-103,-104,-106,-109";
			}
			else if (objectTypeId.GetValueOrDefault() == 45)
			{
				userIds = "-101,-107,-108";
			}
			else if (objectTypeId.GetValueOrDefault() == 90 || objectTypeId.GetValueOrDefault() == 100)
			{
				userIds = "-101,-108";
			}
			else if (objectTypeId.GetValueOrDefault() == 80)
			{
				userIds = "-101,-108";
			}
			else if (objectTypeId.GetValueOrDefault() == 40)
			{
				userIds = "-101,-108";
			}
			else if (objectTypeId.GetValueOrDefault() == 110)
			{
				userIds = "-102,-103,-101,-108";
			}
			else if (objectTypeId.GetValueOrDefault() == 60)
			{
				userIds = "-108";
			}
			List<CRMspSelectUsersByIds_Result> list3 = CRMIdeal.Classes.Helper.User.SelectUsersByIds(userIds);
			if (list3 != null)
			{
				list3 = Enumerable.ToList<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)Enumerable.OrderByDescending<CRMspSelectUsersByIds_Result, int>((IEnumerable<CRMspSelectUsersByIds_Result>)list3, (Func<CRMspSelectUsersByIds_Result, int>)((CRMspSelectUsersByIds_Result m) => m.UserId)));
			}
			if (list3 != null)
			{
				list.AddRange(Enumerable.Select<CRMspSelectUsersByIds_Result, SelectListItem>((IEnumerable<CRMspSelectUsersByIds_Result>)Enumerable.ToList<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list3), (Func<CRMspSelectUsersByIds_Result, SelectListItem>)((CRMspSelectUsersByIds_Result i) => new SelectListItem
				{
					Text = (i.FullName ?? ""),
					Value = i.UserId.ToString(),
					Selected = false
				})));
				foreach (SelectListItem item2 in list)
				{
					int num = int.Parse(item2.Value);
					if (num == -101 && objectTypeId.GetValueOrDefault() != 90 && objectTypeId.GetValueOrDefault() != 100)
					{
						item2.Text = item2.Text + " ( " + string.Format(Labels.frmFirstRegisterUserByParam, GetObjectTypeName(objectTypeId)) + " )";
					}
					else if (num != -102 && num != -103)
					{
						item2.Text = item2.Text + " ( " + GetObjectTypeName(objectTypeId) + " )";
					}
				}
				SelectListItem item = new SelectListItem
				{
					Text = "--------------------",
					Value = "",
					Selected = false
				};
				list.Add(item);
			}
			list.AddRange(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)Enumerable.ToList<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)list2), (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result i) => new SelectListItem
			{
				Text = i.Name,
				Value = i.UserId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.VerifyUsersList = list;
	}

	[AjaxOnly]
	public void GetAlternateVerifyUsers(int? objectTypeId = 0)
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
			List<CRMspSelectActiveUsers_Result> list2 = Enumerable.ToList<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)_db.CRMspSelectActiveUsers(lCID, result, 0));
			string userIds = "";
			if (objectTypeId.GetValueOrDefault() == 20)
			{
				userIds = "-101,-102,-103,-104,-106,-109";
			}
			else if (objectTypeId.GetValueOrDefault() == 10)
			{
				userIds = "-101,-102,-103,-104,-106,-109";
			}
			else if (objectTypeId.GetValueOrDefault() == 45)
			{
				userIds = "-101,-107,-108";
			}
			else if (objectTypeId.GetValueOrDefault() == 90 || objectTypeId.GetValueOrDefault() == 100)
			{
				userIds = "-101,-108";
			}
			else if (objectTypeId.GetValueOrDefault() == 80)
			{
				userIds = "-101,-108";
			}
			else if (objectTypeId.GetValueOrDefault() == 40)
			{
				userIds = "-101,-108";
			}
			else if (objectTypeId.GetValueOrDefault() == 110)
			{
				userIds = "-102,-103,-101,-108";
			}
			else if (objectTypeId.GetValueOrDefault() == 60)
			{
				userIds = "-108";
			}
			List<CRMspSelectUsersByIds_Result> list3 = CRMIdeal.Classes.Helper.User.SelectUsersByIds(userIds);
			if (list3 != null)
			{
				list3 = Enumerable.ToList<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)Enumerable.OrderByDescending<CRMspSelectUsersByIds_Result, int>((IEnumerable<CRMspSelectUsersByIds_Result>)list3, (Func<CRMspSelectUsersByIds_Result, int>)((CRMspSelectUsersByIds_Result m) => m.UserId)));
			}
			if (list3 != null)
			{
				list.AddRange(Enumerable.Select<CRMspSelectUsersByIds_Result, SelectListItem>((IEnumerable<CRMspSelectUsersByIds_Result>)Enumerable.ToList<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list3), (Func<CRMspSelectUsersByIds_Result, SelectListItem>)((CRMspSelectUsersByIds_Result i) => new SelectListItem
				{
					Text = (i.FullName ?? ""),
					Value = i.UserId.ToString(),
					Selected = false
				})));
				foreach (SelectListItem item in list)
				{
					switch (int.Parse(item.Value))
					{
					case -101:
						item.Text = item.Text + " ( " + string.Format(Labels.frmFirstRegisterUserByParam, GetObjectTypeName(objectTypeId)) + " )";
						break;
					default:
						item.Text = item.Text + " ( " + GetObjectTypeName(objectTypeId) + " )";
						break;
					case -103:
					case -102:
						break;
					}
				}
				list.Add(new SelectListItem
				{
					Text = "--------------------",
					Value = "",
					Selected = false
				});
			}
			list.AddRange(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)Enumerable.ToList<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)list2), (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result i) => new SelectListItem
			{
				Text = i.Name,
				Value = i.UserId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.AlternateVerifyUsersList = list;
	}

	[AjaxOnly]
	public void GetAlternateVerifyUsers_Old(int? objectTypeId = 0, string partTitle = "")
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
			List<CRMspSelectActiveUsers_Result> list2 = Enumerable.ToList<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)_db.CRMspSelectActiveUsers(lCID, result, 0));
			list.AddRange(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)Enumerable.ToList<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)list2), (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result i) => new SelectListItem
			{
				Text = i.Name,
				Value = i.UserId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.AlternateVerifyUsersList = list;
	}

	[DynamicAuthorize(ControllerName = "frmDefineVerificationWorkflow", ActionName = "actDefineWorkflowSteps")]
	public ActionResult Steps(int workflowId)
	{
		base.ViewBag.WorkflowId = workflowId;
		base.ViewBag.WorkflowTitle = "";
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			WSspSelectVerificationWorkFlowWithId_Result wSspSelectVerificationWorkFlowWithId_Result = Enumerable.FirstOrDefault<WSspSelectVerificationWorkFlowWithId_Result>((IEnumerable<WSspSelectVerificationWorkFlowWithId_Result>)_db.WSspSelectVerificationWorkFlowWithId(workflowId, lCID, result));
			if (wSspSelectVerificationWorkFlowWithId_Result != null)
			{
				base.ViewBag.WorkflowTitle = wSspSelectVerificationWorkFlowWithId_Result.VerificationWorkFlowTitle ?? "";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View();
	}

	public List<WSspSelectVerificationWorkFlowSteps_Result> ListWorkflowSteps(int workflowId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectVerificationWorkFlowSteps_Result> list = new List<WSspSelectVerificationWorkFlowSteps_Result>();
		try
		{
			list = Enumerable.ToList<WSspSelectVerificationWorkFlowSteps_Result>((IEnumerable<WSspSelectVerificationWorkFlowSteps_Result>)_db.WSspSelectVerificationWorkFlowSteps(workflowId, lCID, result));
			foreach (WSspSelectVerificationWorkFlowSteps_Result item in list)
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
	public ActionResult WorkflowSteps_Read([DataSourceRequest] DataSourceRequest request, int workflowId)
	{
		return Json(((IEnumerable)ListWorkflowSteps(workflowId)).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult WorkflowStepsList(int workflowId)
	{
		return Json(ListWorkflowSteps(workflowId), JsonRequestBehavior.AllowGet);
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
				if (users != null && Enumerable.Any<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)users))
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

	public ActionResult InsertEditStep(int workflowId, int workflowStepId = 0)
	{
		_003C_003Ec__DisplayClass33_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass33_0();
		CS_0024_003C_003E8__locals0.workflowStepId = workflowStepId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		DbSet<WSVerificationWorkFlowSteps_Lang> wSVerificationWorkFlowSteps_Lang = _dbTbl.WSVerificationWorkFlowSteps_Lang;
		ParameterExpression val = Expression.Parameter(typeof(WSVerificationWorkFlowSteps_Lang), "c");
		List<WSVerificationWorkFlowSteps_Lang> list = Enumerable.ToList<WSVerificationWorkFlowSteps_Lang>((IEnumerable<WSVerificationWorkFlowSteps_Lang>)Queryable.Where<WSVerificationWorkFlowSteps_Lang>((IQueryable<WSVerificationWorkFlowSteps_Lang>)wSVerificationWorkFlowSteps_Lang, Expression.Lambda<Func<WSVerificationWorkFlowSteps_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass33_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
		DateTime now = DateTime.Now;
		WSVerificationWorkFlowSteps wSVerificationWorkFlowSteps = new WSVerificationWorkFlowSteps();
		if (CS_0024_003C_003E8__locals0.workflowStepId == 0)
		{
			if (!UserLogin.IsUserAccess("frmDefineVerificationWorkflowSteps", "actInsert", UserLogin.CurrentUser))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			wSVerificationWorkFlowSteps = new WSVerificationWorkFlowSteps();
			wSVerificationWorkFlowSteps.VerificationWorkFlowStepId = 0;
			wSVerificationWorkFlowSteps.RegisterDate = now;
			wSVerificationWorkFlowSteps.FirstRegisterDate = now;
			wSVerificationWorkFlowSteps.VerificationWorkFlowId = workflowId;
			if (!wSVerificationWorkFlowSteps.OrderView.HasValue || wSVerificationWorkFlowSteps.OrderView <= 0)
			{
				List<WSspSelectVerificationWorkFlowSteps_Result> list2 = Enumerable.ToList<WSspSelectVerificationWorkFlowSteps_Result>((IEnumerable<WSspSelectVerificationWorkFlowSteps_Result>)_db.WSspSelectVerificationWorkFlowSteps(workflowId, CS_0024_003C_003E8__locals0.currLangID, result));
				_ = Enumerable.FirstOrDefault<WSspSelectVerificationWorkFlowSteps_Result>((IEnumerable<WSspSelectVerificationWorkFlowSteps_Result>)Enumerable.OrderByDescending<WSspSelectVerificationWorkFlowSteps_Result, int?>((IEnumerable<WSspSelectVerificationWorkFlowSteps_Result>)list2, (Func<WSspSelectVerificationWorkFlowSteps_Result, int?>)((WSspSelectVerificationWorkFlowSteps_Result m) => m.OrderView)))?.OrderView;
				int num = (Enumerable.Any<WSspSelectVerificationWorkFlowSteps_Result>((IEnumerable<WSspSelectVerificationWorkFlowSteps_Result>)list2) ? Enumerable.Count<WSspSelectVerificationWorkFlowSteps_Result>((IEnumerable<WSspSelectVerificationWorkFlowSteps_Result>)list2) : 0);
				wSVerificationWorkFlowSteps.OrderView = num + 10 + num * 9 - 5;
			}
		}
		else
		{
			if (!UserLogin.IsUserAccess("frmDefineVerificationWorkflowSteps", "actEdit", UserLogin.CurrentUser))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			DbSet<WSVerificationWorkFlowSteps> wSVerificationWorkFlowSteps2 = _dbTbl.WSVerificationWorkFlowSteps;
			val = Expression.Parameter(typeof(WSVerificationWorkFlowSteps), "m");
			wSVerificationWorkFlowSteps = Queryable.FirstOrDefault<WSVerificationWorkFlowSteps>((IQueryable<WSVerificationWorkFlowSteps>)wSVerificationWorkFlowSteps2, Expression.Lambda<Func<WSVerificationWorkFlowSteps, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass33_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (wSVerificationWorkFlowSteps == null)
			{
				wSVerificationWorkFlowSteps = new WSVerificationWorkFlowSteps();
				wSVerificationWorkFlowSteps.VerificationWorkFlowStepId = 0;
				wSVerificationWorkFlowSteps.RegisterDate = now;
				wSVerificationWorkFlowSteps.FirstRegisterDate = now;
				wSVerificationWorkFlowSteps.VerificationWorkFlowId = workflowId;
			}
		}
		List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSVerificationWorkFlowSteps_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSVerificationWorkFlowSteps_Lang>)list, (Func<WSVerificationWorkFlowSteps_Lang, CommonMultiLanguageViewModel>)((WSVerificationWorkFlowSteps_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.VerificationWorkFlowStepTitle,
			LanguageId = item.LanguageID
		})));
		list3.Add(new CommonMultiLanguageViewModel
		{
			Value = wSVerificationWorkFlowSteps.VerificationWorkFlowStepTitle,
			LanguageId = result
		});
		List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSVerificationWorkFlowSteps_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSVerificationWorkFlowSteps_Lang>)list, (Func<WSVerificationWorkFlowSteps_Lang, CommonMultiLanguageViewModel>)((WSVerificationWorkFlowSteps_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.VerifyText,
			LanguageId = item.LanguageID
		})));
		list4.Add(new CommonMultiLanguageViewModel
		{
			Value = wSVerificationWorkFlowSteps.VerifyText,
			LanguageId = result
		});
		List<CommonMultiLanguageViewModel> list5 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSVerificationWorkFlowSteps_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSVerificationWorkFlowSteps_Lang>)list, (Func<WSVerificationWorkFlowSteps_Lang, CommonMultiLanguageViewModel>)((WSVerificationWorkFlowSteps_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.AutoReferToAltTxt,
			LanguageId = item.LanguageID
		})));
		list5.Add(new CommonMultiLanguageViewModel
		{
			Value = wSVerificationWorkFlowSteps.AutoReferToAltTxt,
			LanguageId = result
		});
		CS_0024_003C_003E8__locals0.model = new WSVerificationWorkFlowStepsLanguageViewModel
		{
			VerificationWorkFlowStepId = wSVerificationWorkFlowSteps.VerificationWorkFlowStepId,
			VerificationWorkFlowId = wSVerificationWorkFlowSteps.VerificationWorkFlowId,
			VerificationWorkFlowStepTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			VerificationWorkFlowStepTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
			VerifyUserId = wSVerificationWorkFlowSteps.VerifyUserId,
			AlternateVerifyUserId = wSVerificationWorkFlowSteps.AlternateVerifyUserId,
			VerifyText = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			VerifyText_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
			FirstRegisterUserId = wSVerificationWorkFlowSteps.FirstRegisterUserId,
			FirstRegisterDate = wSVerificationWorkFlowSteps.FirstRegisterDate,
			FirstRegisterDatePersian = wSVerificationWorkFlowSteps.FirstRegisterDatePersian,
			UserId = wSVerificationWorkFlowSteps.UserId,
			Year1 = wSVerificationWorkFlowSteps.Year1,
			Month1 = wSVerificationWorkFlowSteps.Month1,
			RegisterDate = wSVerificationWorkFlowSteps.RegisterDate,
			RegisterDatePersian = wSVerificationWorkFlowSteps.RegisterDatePersian,
			GUId = wSVerificationWorkFlowSteps.GUId,
			AppType = wSVerificationWorkFlowSteps.AppType,
			LanguageID = wSVerificationWorkFlowSteps.LanguageID,
			OrderView = wSVerificationWorkFlowSteps.OrderView,
			VerificationWorkFlowStepCanBack = wSVerificationWorkFlowSteps.VerificationWorkFlowStepCanBack,
			VerificationWorkFlowStepObjCanEdit = wSVerificationWorkFlowSteps.VerificationWorkFlowStepObjCanEdit,
			AutoReferToAltMin = wSVerificationWorkFlowSteps.AutoReferToAltMin,
			AutoReferToAltTxt = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			AutoReferToAltTxt_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))))
		};
		if (CS_0024_003C_003E8__locals0.model.VerificationWorkFlowId != 0)
		{
			DbSet<WSVerificationWorkFlows> wSVerificationWorkFlows = _dbTbl.WSVerificationWorkFlows;
			val = Expression.Parameter(typeof(WSVerificationWorkFlows), "x");
			WSVerificationWorkFlows wSVerificationWorkFlows2 = Queryable.FirstOrDefault<WSVerificationWorkFlows>((IQueryable<WSVerificationWorkFlows>)wSVerificationWorkFlows, Expression.Lambda<Func<WSVerificationWorkFlows, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass33_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (wSVerificationWorkFlows2 != null)
			{
				WSVerificationWorkFlowStepsLanguageViewModel model = CS_0024_003C_003E8__locals0.model;
				DbSet<WSVerificationWorkFlows> wSVerificationWorkFlows3 = _dbTbl.WSVerificationWorkFlows;
				val = Expression.Parameter(typeof(WSVerificationWorkFlows), "x");
				model.VerificationWorkFlowObjectTypeId = Queryable.FirstOrDefault<WSVerificationWorkFlows>((IQueryable<WSVerificationWorkFlows>)wSVerificationWorkFlows3, Expression.Lambda<Func<WSVerificationWorkFlows, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass33_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })).ObjectType;
				if (CS_0024_003C_003E8__locals0.currLangID == result)
				{
					CS_0024_003C_003E8__locals0.model.VerificationWorkFlowTitle = wSVerificationWorkFlows2.VerificationWorkFlowTitle;
				}
				else
				{
					WSVerificationWorkFlows_Lang wSVerificationWorkFlows_Lang = Enumerable.FirstOrDefault<WSVerificationWorkFlows_Lang>((IEnumerable<WSVerificationWorkFlows_Lang>)wSVerificationWorkFlows2.WSVerificationWorkFlows_Lang, (Func<WSVerificationWorkFlows_Lang, bool>)((WSVerificationWorkFlows_Lang x) => x.LanguageID == CS_0024_003C_003E8__locals0.currLangID));
					CS_0024_003C_003E8__locals0.model.VerificationWorkFlowTitle = ((wSVerificationWorkFlows_Lang == null) ? "" : wSVerificationWorkFlows_Lang.VerificationWorkFlowTitle);
				}
			}
		}
		GetVerifyUsers(CS_0024_003C_003E8__locals0.model.VerificationWorkFlowObjectTypeId);
		GetAlternateVerifyUsers(CS_0024_003C_003E8__locals0.model.VerificationWorkFlowObjectTypeId);
		base.ViewBag.IsBuying = VersionBuyer.VerificationWorkFlow;
		return View(CS_0024_003C_003E8__locals0.model);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefineVerificationWorkflowStepsDataEntry", ActionName = "actPost")]
	public ActionResult InsertEditStep(WSVerificationWorkFlowStepsLanguageViewModel vm)
	{
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass34_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass34_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		GetVerifyUsers(0);
		GetAlternateVerifyUsers(0);
		if (base.ModelState.IsValid)
		{
			if (CS_0024_003C_003E8__locals0.vm.VerificationWorkFlowStepId <= 0 && !VersionBuyer.VerificationWorkFlow)
			{
				int result = 0;
				WSspSelectVerificationWorkFlowWithId_Result wSspSelectVerificationWorkFlowWithId_Result = Enumerable.FirstOrDefault<WSspSelectVerificationWorkFlowWithId_Result>((IEnumerable<WSspSelectVerificationWorkFlowWithId_Result>)_db.WSspSelectVerificationWorkFlowWithId(CS_0024_003C_003E8__locals0.vm.VerificationWorkFlowId, lCID, CS_0024_003C_003E8__locals0.defLangID));
				if (wSspSelectVerificationWorkFlowWithId_Result != null)
				{
					int.TryParse(wSspSelectVerificationWorkFlowWithId_Result.ObjectType.ToString(), out result);
				}
				if ((result != 90 && result != 100) || !VersionBuyer.Leave)
				{
					DbSet<WSVerificationWorkFlowSteps> wSVerificationWorkFlowSteps = _dbTbl.WSVerificationWorkFlowSteps;
					ParameterExpression val = Expression.Parameter(typeof(WSVerificationWorkFlowSteps), "c");
					if (Queryable.Any<WSVerificationWorkFlowSteps>((IQueryable<WSVerificationWorkFlowSteps>)wSVerificationWorkFlowSteps, Expression.Lambda<Func<WSVerificationWorkFlowSteps, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)1, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val })))
					{
						base.ViewBag.Error = "BV|" + string.Format(Messages.VersionBuyWithCount, "1");
						return View(CS_0024_003C_003E8__locals0.vm);
					}
				}
			}
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.VerificationWorkFlowStepTitle_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.VerificationWorkFlowStepTitle_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.VerificationWorkFlowStepTitle,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.VerifyText_Lang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.VerifyText_Lang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.VerifyText,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.AutoReferToAltTxt_Lang))
			{
				list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.AutoReferToAltTxt_Lang);
			}
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.AutoReferToAltTxt,
				LanguageId = lCID
			});
			if (CS_0024_003C_003E8__locals0.vm.VerificationWorkFlowStepTitle == null)
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.VerificationWorkFlowStepTitle) + "<br/>";
				num++;
			}
			else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.VerificationWorkFlowStepTitle, list))
			{
				text = text + string.Format(Messages.CheckFieldInLang, Labels.VerificationWorkFlowStepTitle) + "<br>";
				num++;
			}
			if (num == 0)
			{
				DateTime now = DateTime.Now;
				try
				{
					_003C_003Ec__DisplayClass34_1 _003C_003Ec__DisplayClass34_ = new _003C_003Ec__DisplayClass34_1();
					_003C_003Ec__DisplayClass34_.model = new WSVerificationWorkFlowSteps();
					if (CS_0024_003C_003E8__locals0.vm.VerificationWorkFlowStepId > 0)
					{
						DbSet<WSVerificationWorkFlowSteps> wSVerificationWorkFlowSteps2 = _dbTbl.WSVerificationWorkFlowSteps;
						ParameterExpression val = Expression.Parameter(typeof(WSVerificationWorkFlowSteps), "m");
						_003C_003Ec__DisplayClass34_.model = Queryable.FirstOrDefault<WSVerificationWorkFlowSteps>((IQueryable<WSVerificationWorkFlowSteps>)wSVerificationWorkFlowSteps2, Expression.Lambda<Func<WSVerificationWorkFlowSteps, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass34_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					}
					_003C_003Ec__DisplayClass34_.model.VerificationWorkFlowStepTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					_003C_003Ec__DisplayClass34_.model.VerifyUserId = CS_0024_003C_003E8__locals0.vm.VerifyUserId;
					_003C_003Ec__DisplayClass34_.model.AlternateVerifyUserId = CS_0024_003C_003E8__locals0.vm.AlternateVerifyUserId;
					_003C_003Ec__DisplayClass34_.model.VerificationWorkFlowStepCanBack = CS_0024_003C_003E8__locals0.vm.VerificationWorkFlowStepCanBack;
					_003C_003Ec__DisplayClass34_.model.VerificationWorkFlowStepObjCanEdit = CS_0024_003C_003E8__locals0.vm.VerificationWorkFlowStepObjCanEdit;
					_003C_003Ec__DisplayClass34_.model.VerifyText = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					_003C_003Ec__DisplayClass34_.model.OrderView = CS_0024_003C_003E8__locals0.vm.OrderView;
					_003C_003Ec__DisplayClass34_.model.UserId = UserLogin.CurrentUser.UserId;
					_003C_003Ec__DisplayClass34_.model.Year1 = short.Parse(Financial.Get().Id.ToString());
					_003C_003Ec__DisplayClass34_.model.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
					_003C_003Ec__DisplayClass34_.model.RegisterDate = now;
					_003C_003Ec__DisplayClass34_.model.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					_003C_003Ec__DisplayClass34_.model.AppType = Configuration.AppType;
					_003C_003Ec__DisplayClass34_.model.AutoReferToAltTxt = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					_003C_003Ec__DisplayClass34_.model.AutoReferToAltMin = CS_0024_003C_003E8__locals0.vm.AutoReferToAltMin;
					string text2 = "";
					if (CS_0024_003C_003E8__locals0.vm.VerificationWorkFlowStepId > 0)
					{
						_dbTbl.Entry(_003C_003Ec__DisplayClass34_.model).State = EntityState.Modified;
						_dbTbl.Configuration.ValidateOnSaveEnabled = false;
						_dbTbl.SaveChanges();
						_dbTbl.Configuration.ValidateOnSaveEnabled = true;
						using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								_003C_003Ec__DisplayClass34_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass34_2();
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass34_;
								CS_0024_003C_003E8__locals1.lang = enumerator.Current;
								DbSet<WSVerificationWorkFlowSteps_Lang> wSVerificationWorkFlowSteps_Lang = _dbTbl.WSVerificationWorkFlowSteps_Lang;
								ParameterExpression val = Expression.Parameter(typeof(WSVerificationWorkFlowSteps_Lang), "c");
								WSVerificationWorkFlowSteps_Lang wSVerificationWorkFlowSteps_Lang2 = Queryable.FirstOrDefault<WSVerificationWorkFlowSteps_Lang>((IQueryable<WSVerificationWorkFlowSteps_Lang>)wSVerificationWorkFlowSteps_Lang, Expression.Lambda<Func<WSVerificationWorkFlowSteps_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass34_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass34_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (wSVerificationWorkFlowSteps_Lang2 != null)
								{
									wSVerificationWorkFlowSteps_Lang2.VerificationWorkFlowStepTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									wSVerificationWorkFlowSteps_Lang2.VerifyText = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									wSVerificationWorkFlowSteps_Lang2.AutoReferToAltTxt = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									_dbTbl.Entry(wSVerificationWorkFlowSteps_Lang2).State = EntityState.Modified;
									_dbTbl.SaveChanges();
									continue;
								}
								wSVerificationWorkFlowSteps_Lang2 = new WSVerificationWorkFlowSteps_Lang();
								wSVerificationWorkFlowSteps_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
								wSVerificationWorkFlowSteps_Lang2.VerificationWorkFlowStepId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.VerificationWorkFlowStepId;
								wSVerificationWorkFlowSteps_Lang2.VerificationWorkFlowStepTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSVerificationWorkFlowSteps_Lang2.VerifyText = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSVerificationWorkFlowSteps_Lang2.AutoReferToAltTxt = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.WSVerificationWorkFlowSteps_Lang.Add(wSVerificationWorkFlowSteps_Lang2);
								_dbTbl.SaveChanges();
							}
						}
						text2 = Messages.frmFormBaseEditSuccessFulMessage;
					}
					else
					{
						_003C_003Ec__DisplayClass34_.model.VerificationWorkFlowId = CS_0024_003C_003E8__locals0.vm.VerificationWorkFlowId;
						_003C_003Ec__DisplayClass34_.model.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
						_003C_003Ec__DisplayClass34_.model.FirstRegisterDate = now;
						_003C_003Ec__DisplayClass34_.model.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						_003C_003Ec__DisplayClass34_.model.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
						_003C_003Ec__DisplayClass34_.model.GUId = Guid.NewGuid();
						_dbTbl.WSVerificationWorkFlowSteps.Add(_003C_003Ec__DisplayClass34_.model);
						_dbTbl.Configuration.ValidateOnSaveEnabled = false;
						_dbTbl.SaveChanges();
						_dbTbl.Configuration.ValidateOnSaveEnabled = true;
						foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
						{
							WSVerificationWorkFlowSteps_Lang wSVerificationWorkFlowSteps_Lang3 = new WSVerificationWorkFlowSteps_Lang();
							wSVerificationWorkFlowSteps_Lang3.LanguageID = lang.LanguageID;
							wSVerificationWorkFlowSteps_Lang3.VerificationWorkFlowStepId = _003C_003Ec__DisplayClass34_.model.VerificationWorkFlowStepId;
							wSVerificationWorkFlowSteps_Lang3.VerificationWorkFlowStepTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
							wSVerificationWorkFlowSteps_Lang3.VerifyText = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
							wSVerificationWorkFlowSteps_Lang3.AutoReferToAltTxt = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
							_dbTbl.WSVerificationWorkFlowSteps_Lang.Add(wSVerificationWorkFlowSteps_Lang3);
							_dbTbl.SaveChanges();
						}
						text2 = Messages.frmFormBaseInsertSuccessFulMessage;
					}
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSVerificationWorkFlowSteps");
					string text3 = "";
					try
					{
						_dbII.CRMspCreateVerificationWorkFlowStepAutoSendToAltSqlJob();
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						text3 = "<br>" + Messages.msgSqlJobError;
					}
					if (!string.IsNullOrWhiteSpace(text3))
					{
						base.ViewBag.SuccessfullByError = text2 + text3;
					}
					else
					{
						base.ViewBag.Successfull = text2;
					}
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
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
	public string ActDeleteStep(int workflowStepId)
	{
		_003C_003Ec__DisplayClass35_0 _003C_003Ec__DisplayClass35_ = new _003C_003Ec__DisplayClass35_0();
		_003C_003Ec__DisplayClass35_.workflowStepId = workflowStepId;
		string result = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmDefineVerificationWorkflowSteps", "actDelete", currentUser))
			{
				return Messages.ErrorNotAccess;
			}
			if (_003C_003Ec__DisplayClass35_.workflowStepId > 0)
			{
				DbSet<WSVerificationWorkFlowSteps> wSVerificationWorkFlowSteps = _dbTbl.WSVerificationWorkFlowSteps;
				ParameterExpression val = Expression.Parameter(typeof(WSVerificationWorkFlowSteps), "m");
				if (Queryable.FirstOrDefault<WSVerificationWorkFlowSteps>((IQueryable<WSVerificationWorkFlowSteps>)wSVerificationWorkFlowSteps, Expression.Lambda<Func<WSVerificationWorkFlowSteps, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass35_, typeof(_003C_003Ec__DisplayClass35_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
				{
					try
					{
						mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteVerificationWorkFlowSteps(_003C_003Ec__DisplayClass35_.workflowStepId));
						if (mct_Result != null && mct_Result.Result > 0)
						{
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSVerificationWorkFlowSteps");
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
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}

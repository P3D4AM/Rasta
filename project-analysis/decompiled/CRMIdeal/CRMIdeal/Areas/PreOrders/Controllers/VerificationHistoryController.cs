using System;
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
using CRM.General.Security;
using CRM.General.Utilities;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Areas.Cartables.Controllers;
using CRMIdeal.Areas.Leave.Controllers;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Cache.User;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.PreOrders.Controllers;

public class VerificationHistoryController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public int defLangID;

		public WSVerificationRequestsLanguageViewModel vm;

		public Func<Languages, bool> _003C_003E9__2;

		public Func<Languages, bool> _003C_003E9__7;

		public Func<Languages, bool> _003C_003E9__12;

		public Func<Languages, bool> _003C_003E9__17;

		public Func<Languages, bool> _003C_003E9__22;

		public Func<Languages, bool> _003C_003E9__27;

		public Func<Languages, bool> _003C_003E9__32;

		internal bool _003CIndex_003Eb__0(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CIndex_003Eb__1(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CIndex_003Eb__2(Languages m)
		{
			return m.LanguageID != defLangID;
		}

		internal bool _003CIndex_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CIndex_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CIndex_003Eb__7(Languages m)
		{
			return m.LanguageID != defLangID;
		}

		internal bool _003CIndex_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CIndex_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CIndex_003Eb__12(Languages m)
		{
			return m.LanguageID != defLangID;
		}

		internal bool _003CIndex_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CIndex_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CIndex_003Eb__17(Languages m)
		{
			return m.LanguageID != defLangID;
		}

		internal bool _003CIndex_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CIndex_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CIndex_003Eb__22(Languages m)
		{
			return m.LanguageID != defLangID;
		}

		internal bool _003CIndex_003Eb__25(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CIndex_003Eb__26(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CIndex_003Eb__27(Languages m)
		{
			return m.LanguageID != defLangID;
		}

		internal bool _003CIndex_003Eb__30(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CIndex_003Eb__31(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CIndex_003Eb__32(Languages m)
		{
			return m.LanguageID != defLangID;
		}

		internal bool _003CIndex_003Eb__41(CommonMultiLanguageViewModel x)
		{
			return x.LanguageId == defLangID;
		}

		internal bool _003CIndex_003Eb__42(CommonMultiLanguageViewModel x)
		{
			return x.LanguageId != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass19_1
	{
		public WSspSelectVerificationRequestDetails_Result item;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public int workflowId;

		public int currLangID;

		internal bool _003CIndex_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CIndex_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CIndex_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	private const int _VerifyReqResultId_Verified = 1;

	private const int _VerifyReqResultId_NotVerified = 2;

	private const int _VerifyReqResultId_Cancel = 6;

	private const int _VerifyReqResultId_Return = 7;

	private const int _VerifyReqResultId_SendToAlt = 8;

	[LoginAuthorize]
	public ActionResult Index(int objectId = 0, int objectType = 0, int workflowId = 0, int position = 0, string formName = "", int? msgId = 0)
	{
		_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass4_0();
		CS_0024_003C_003E8__locals0.workflowId = workflowId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		int result2 = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
		}
		string text = "";
		base.ViewBag.ObjectId = objectId;
		base.ViewBag.ObjectType = objectType;
		base.ViewBag.WorkflowId = CS_0024_003C_003E8__locals0.workflowId;
		base.ViewBag.Position = position;
		base.ViewBag.FormName = formName;
		base.ViewBag.Mode = 0;
		base.ViewBag.SequenceObservation = false;
		base.ViewBag.MsgId = msgId;
		string text2 = "";
		string text3 = "";
		if (!string.IsNullOrEmpty(formName))
		{
			switch (formName)
			{
			case "PORD":
				text2 = "frmPreOrder";
				text3 = "actVerifyWithWorkflow";
				break;
			case "ORD":
				text2 = "frmOrder";
				text3 = "actVerifyWithWorkflow";
				break;
			case "DyFrm":
				text2 = "frmDyForm";
				text3 = "actCheckWithWorkflow";
				break;
			case "DOC":
				text2 = "frmDoc";
				text3 = "actVerifyWithWorkflow";
				break;
			case "DRAFT":
				text2 = "frmDraft";
				text3 = "actVerifyWithWorkflow";
				break;
			case "MOVEMENTWRHS":
				text2 = "frmWareHouseMovement";
				text3 = "actVerifyWithWorkflow";
				break;
			case "LEAVE":
				text2 = "frmLeave";
				text3 = "actVerifyRequest";
				break;
			case "MISSION":
				text2 = "frmMission";
				text3 = "actVerifyRequest";
				break;
			case "BORD":
				text2 = "frmBuyOrder";
				text3 = "actVerifyWithWorkflow";
				break;
			case "STSUP":
				text2 = "frmStockSupply";
				text3 = "actVerifyWithWorkflow";
				break;
			case "SENDLTR":
				text2 = "frmSendLetters";
				text3 = "actVerifyWithWorkflow";
				break;
			case "RECIEVELTR":
				text2 = "frmReceiveLetters";
				text3 = "actVerifyWithWorkflow";
				break;
			case "FUND":
				text2 = "frmFund";
				text3 = "actVerifyFund";
				break;
			default:
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			if (!UserLogin.IsUserAccess(text2, text3, UserLogin.CurrentUser))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			WSspSelectVerificationRequests_Result wSspSelectVerificationRequests_Result = Enumerable.FirstOrDefault<WSspSelectVerificationRequests_Result>((IEnumerable<WSspSelectVerificationRequests_Result>)SelectVerificationRequests(objectId, objectType));
			List<SelectListItem> list = SelectVerificationRequestsSelectListItem(objectId, objectType);
			base.ViewBag.RequestsSelectListItem = list;
			int num = 0;
			if (Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list) != null)
			{
				num = int.Parse(Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list).Value);
			}
			if (wSspSelectVerificationRequests_Result != null)
			{
				int verificationWorkFlowId = wSspSelectVerificationRequests_Result.VerificationWorkFlowId;
				bool result3 = false;
				bool.TryParse(wSspSelectVerificationRequests_Result.VerificationReqExpired.ToString(), out result3);
				if (result3 && verificationWorkFlowId != CS_0024_003C_003E8__locals0.workflowId)
				{
					num = 0;
					base.ViewBag.RequestsSelectListItem = new List<SelectListItem>();
				}
			}
			string text4 = "";
			string text5 = "";
			WSspSelectVerificationWorkFlowWithId_Result wSspSelectVerificationWorkFlowWithId_Result = Enumerable.FirstOrDefault<WSspSelectVerificationWorkFlowWithId_Result>((IEnumerable<WSspSelectVerificationWorkFlowWithId_Result>)_db.WSspSelectVerificationWorkFlowWithId(CS_0024_003C_003E8__locals0.workflowId, CS_0024_003C_003E8__locals0.currLangID, result));
			if (wSspSelectVerificationWorkFlowWithId_Result != null)
			{
				DbSet<WSVerificationWorkFlows_Lang> wSVerificationWorkFlows_Lang = _dbTbl.WSVerificationWorkFlows_Lang;
				ParameterExpression val = Expression.Parameter(typeof(WSVerificationWorkFlows_Lang), "c");
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSVerificationWorkFlows_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSVerificationWorkFlows_Lang>)Enumerable.ToList<WSVerificationWorkFlows_Lang>((IEnumerable<WSVerificationWorkFlows_Lang>)Queryable.Where<WSVerificationWorkFlows_Lang>((IQueryable<WSVerificationWorkFlows_Lang>)wSVerificationWorkFlows_Lang, Expression.Lambda<Func<WSVerificationWorkFlows_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass4_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }))), (Func<WSVerificationWorkFlows_Lang, CommonMultiLanguageViewModel>)((WSVerificationWorkFlows_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.VerifyRequestText,
					LanguageId = item.LanguageID
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = wSspSelectVerificationWorkFlowWithId_Result.VerifyRequestText,
					LanguageId = result
				});
				text4 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
				text5 = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
			}
			CRMspSelectLeave_Result cRMspSelectLeave_Result = null;
			if (objectType == 90 || objectType == 100)
			{
				cRMspSelectLeave_Result = Enumerable.FirstOrDefault<CRMspSelectLeave_Result>((IEnumerable<CRMspSelectLeave_Result>)_dbI.CRMspSelectLeave(null, objectId, null, null, null, null, CS_0024_003C_003E8__locals0.currLangID, result, null, result2));
				if (cRMspSelectLeave_Result != null)
				{
					string text6 = "";
					string text7 = "";
					if (cRMspSelectLeave_Result.LeaveTypeId.GetValueOrDefault() == 1)
					{
						string text8 = ((!cRMspSelectLeave_Result.FromDateTime.HasValue) ? "" : cRMspSelectLeave_Result.FromDateTime.Value.ToString("dddd dd MMMM yyyy"));
						text = string.Format(Messages.HourlyLeaveRequestFullDateTimeForUserStr, cRMspSelectLeave_Result.RequestUser ?? "", text8, cRMspSelectLeave_Result.FromTime ?? "", cRMspSelectLeave_Result.ToTime ?? "", cRMspSelectLeave_Result.HourCount ?? "");
					}
					else if (cRMspSelectLeave_Result.LeaveTypeId.GetValueOrDefault() == 2)
					{
						text6 = ((!cRMspSelectLeave_Result.FromDateTime.HasValue) ? "" : cRMspSelectLeave_Result.FromDateTime.Value.ToString("dddd yyyy/MM/dd"));
						text7 = ((!cRMspSelectLeave_Result.ToDateTime.HasValue) ? "" : cRMspSelectLeave_Result.ToDateTime.Value.ToString("dddd yyyy/MM/dd"));
						text = string.Format(Messages.DailyLeaveRequestFullDateTimeForUserStr, cRMspSelectLeave_Result.RequestUser ?? "", text6, text7, cRMspSelectLeave_Result.DayCount.GetValueOrDefault());
					}
					else if (cRMspSelectLeave_Result.LeaveTypeId.GetValueOrDefault() == 3)
					{
						string text9 = ((!cRMspSelectLeave_Result.FromDateTime.HasValue) ? "" : cRMspSelectLeave_Result.FromDateTime.Value.ToString("dddd yyyy/MM/dd"));
						text = string.Format(Messages.HourlyMissionRequestFullDateTimeForUserStr, cRMspSelectLeave_Result.RequestUser ?? "", text9, cRMspSelectLeave_Result.FromTime ?? "", cRMspSelectLeave_Result.ToTime ?? "", cRMspSelectLeave_Result.HourCount ?? "");
					}
					else if (cRMspSelectLeave_Result.LeaveTypeId.GetValueOrDefault() == 4)
					{
						text6 = ((!cRMspSelectLeave_Result.FromDateTime.HasValue) ? "" : cRMspSelectLeave_Result.FromDateTime.Value.ToString("dddd yyyy/MM/dd"));
						text7 = ((!cRMspSelectLeave_Result.ToDateTime.HasValue) ? "" : cRMspSelectLeave_Result.ToDateTime.Value.ToString("dddd yyyy/MM/dd"));
						text = string.Format(Messages.DailyMissionRequestFullDateTimeForUserStr, cRMspSelectLeave_Result.RequestUser ?? "", text6, text7, cRMspSelectLeave_Result.DayCount.GetValueOrDefault());
					}
					cRMspSelectLeave_Result.ReplaceUserVerifiedDatePersian = cRMspSelectLeave_Result.ReplaceUserVerifiedDate?.ToString("yyyy/MM/dd");
				}
			}
			base.ViewBag.LeaveJs = JsonConvert.SerializeObject(cRMspSelectLeave_Result);
			if (string.IsNullOrWhiteSpace(text))
			{
				base.ViewBag.SendReqDefText = text4;
				base.ViewBag.SendReqDefText_Lang = text5;
			}
			else
			{
				base.ViewBag.SendReqDefText = text;
				base.ViewBag.SendReqDefText_Lang = "";
			}
			string crrVerificationRequestJs = GetCrrVerificationRequestJs(num);
			base.ViewBag.WorkflowJs = crrVerificationRequestJs;
			base.ViewBag.RequestId = num;
			List<WSspSelectVerificationWorkFlowSteps_Result> list3 = Enumerable.ToList<WSspSelectVerificationWorkFlowSteps_Result>((IEnumerable<WSspSelectVerificationWorkFlowSteps_Result>)_db.WSspSelectVerificationWorkFlowSteps(CS_0024_003C_003E8__locals0.workflowId, CS_0024_003C_003E8__locals0.currLangID, result));
			int result4 = 0;
			string verifyUser = "";
			int result5 = 0;
			string verifyUser2 = "";
			try
			{
				WSspSelectVerificationRequestObjectInfo_Result wSspSelectVerificationRequestObjectInfo_Result = Enumerable.FirstOrDefault<WSspSelectVerificationRequestObjectInfo_Result>((IEnumerable<WSspSelectVerificationRequestObjectInfo_Result>)_dbI.WSspSelectVerificationRequestObjectInfo(objectId, objectType, CS_0024_003C_003E8__locals0.currLangID, result, result2));
				if (wSspSelectVerificationRequestObjectInfo_Result != null)
				{
					int.TryParse(wSspSelectVerificationRequestObjectInfo_Result.cmpReferUserId.ToString(), out result4);
					int.TryParse(wSspSelectVerificationRequestObjectInfo_Result.cmpSuppUserId.ToString(), out result5);
					verifyUser = wSspSelectVerificationRequestObjectInfo_Result.cmpReferUser ?? "";
					verifyUser2 = wSspSelectVerificationRequestObjectInfo_Result.cmpSuppUser ?? "";
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			if (list3 != null && Enumerable.Any<WSspSelectVerificationWorkFlowSteps_Result>((IEnumerable<WSspSelectVerificationWorkFlowSteps_Result>)list3))
			{
				CRMspSelectUsersById_Result cRMspSelectUsersById_Result = CRMIdeal.Classes.Helper.User.SelectUsersById(UserLogin.CurrentUser.UserId);
				int result6 = 0;
				string verifyUser3 = "";
				if (cRMspSelectUsersById_Result != null)
				{
					int.TryParse(cRMspSelectUsersById_Result.ResponsibleUserId.ToString(), out result6);
					verifyUser3 = cRMspSelectUsersById_Result.ResponsibleUser ?? "";
				}
				foreach (WSspSelectVerificationWorkFlowSteps_Result item in list3)
				{
					int result7 = 0;
					int.TryParse(item.VerifyUserId.ToString(), out result7);
					if (result7 == -101 && result6 != 0)
					{
						item.VerifyUserId = result6;
						item.VerifyUser = verifyUser3;
					}
					else if (result7 == -102 && result4 != 0)
					{
						item.VerifyUserId = result4;
						item.VerifyUser = verifyUser;
					}
					else if (result7 == -103 && result5 != 0)
					{
						item.VerifyUserId = result5;
						item.VerifyUser = verifyUser2;
					}
				}
			}
			base.ViewBag.DefWorkFlowStepsJs = JsonConvert.SerializeObject(list3);
			string text10 = "";
			if (objectType == 90 || objectType == 100)
			{
				text10 = GetLeaveSummaryInfo(objectId);
			}
			base.ViewBag.SummaryInfo = text10;
			return View();
		}
		return RedirectToAction("Login", "Account", (object)new
		{
			area = "",
			d = DateTime.Now
		});
	}

	[AjaxOnly]
	[HttpPost]
	public string Index(WSVerificationRequestsLanguageViewModel vm)
	{
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0326: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass10_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		GetVerificationWorkFlow(CS_0024_003C_003E8__locals0.vm.ObjectType);
		GetVerificationRequests(CS_0024_003C_003E8__locals0.vm.ObjectId, CS_0024_003C_003E8__locals0.vm.ObjectType);
		if (base.ModelState.IsValid)
		{
			int result = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
			}
			ObjectParameter objectParameter = new ObjectParameter("InternalMessageId", 0);
			int msgTypeId = 0;
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.FormName))
			{
				if (CS_0024_003C_003E8__locals0.vm.FormName == "PORD")
				{
					msgTypeId = 5;
				}
				else if (CS_0024_003C_003E8__locals0.vm.FormName == "ORD")
				{
					msgTypeId = 8;
				}
				else if (CS_0024_003C_003E8__locals0.vm.FormName == "DyFrm")
				{
					msgTypeId = 16;
				}
				else if (CS_0024_003C_003E8__locals0.vm.FormName == "DOC" || CS_0024_003C_003E8__locals0.vm.FormName == "DRAFT" || CS_0024_003C_003E8__locals0.vm.FormName == "MOVEMENTWRHS")
				{
					msgTypeId = 20;
				}
				else if (CS_0024_003C_003E8__locals0.vm.FormName == "LEAVE")
				{
					msgTypeId = 6;
				}
				else if (CS_0024_003C_003E8__locals0.vm.FormName == "MISSION")
				{
					msgTypeId = 7;
				}
				else if (CS_0024_003C_003E8__locals0.vm.FormName == "BORD")
				{
					msgTypeId = 9;
				}
				else if (CS_0024_003C_003E8__locals0.vm.FormName == "STSUP")
				{
					msgTypeId = 21;
				}
				else if (CS_0024_003C_003E8__locals0.vm.FormName == "SENDLTR" || CS_0024_003C_003E8__locals0.vm.FormName == "RECIEVELTR")
				{
					msgTypeId = 14;
				}
				else if (CS_0024_003C_003E8__locals0.vm.FormName == "FUND")
				{
					msgTypeId = 22;
				}
			}
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.VerifyText_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.VerifyText_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.VerifyText,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.VerifyRequestText_Lang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.VerifyRequestText_Lang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.VerifyRequestText,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ReasonCancellation_Lang))
			{
				list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.ReasonCancellation_Lang);
			}
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.ReasonCancellation,
				LanguageId = lCID
			});
			_ = CS_0024_003C_003E8__locals0.vm.VerificationWorkFlowId;
			if (CS_0024_003C_003E8__locals0.vm.VerificationWorkFlowId == 0)
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.PordVerificationReqWorkflowId) + "<br/>";
				num++;
			}
			if (CS_0024_003C_003E8__locals0.vm.Mode == 1 || CS_0024_003C_003E8__locals0.vm.Mode == 3)
			{
				_ = UserLogin.CurrentUser;
				if (CS_0024_003C_003E8__locals0.vm.ObjectType == 10)
				{
					string text2 = PreOrder.CheckBeforeVerification(CS_0024_003C_003E8__locals0.vm.ObjectId);
					if (!string.IsNullOrWhiteSpace(text2))
					{
						text = text + text2 + "<br/>|ImportantError";
						num++;
						return text;
					}
				}
				else if (CS_0024_003C_003E8__locals0.vm.ObjectType == 20)
				{
					string text3 = Order.CheckBeforeVerification(CS_0024_003C_003E8__locals0.vm.ObjectId, "", 1, 0);
					if (!string.IsNullOrWhiteSpace(text3))
					{
						text = text + text3 + "<br/>|ImportantError";
						num++;
						return text;
					}
				}
				else if (CS_0024_003C_003E8__locals0.vm.ObjectType == 40)
				{
					string text4 = BuyOrder.CheckBeforeVerification(CS_0024_003C_003E8__locals0.vm.ObjectId);
					if (!string.IsNullOrWhiteSpace(text4))
					{
						text = text + text4 + "<br/>|ImportantError";
						num++;
						return text;
					}
				}
			}
			if (CS_0024_003C_003E8__locals0.vm.VerifyUserId.HasValue && CS_0024_003C_003E8__locals0.vm.VerifyUserId.GetValueOrDefault() == -101)
			{
				text = text + string.Format(Messages.msgErrorIsNotSpecified, Labels.VerificationWorkFlowStepResponsibleUser) + "<br/>";
				num++;
			}
			else if (CS_0024_003C_003E8__locals0.vm.VerifyUserId.HasValue && CS_0024_003C_003E8__locals0.vm.VerifyUserId.GetValueOrDefault() == -102)
			{
				text = text + string.Format(Messages.msgErrorIsNotSpecified, Labels.VerificationWorkFlowStepCmpReferUser) + "<br/>";
				num++;
			}
			else if (CS_0024_003C_003E8__locals0.vm.VerifyUserId.HasValue && CS_0024_003C_003E8__locals0.vm.VerifyUserId.GetValueOrDefault() == -103)
			{
				text = text + string.Format(Messages.msgErrorIsNotSpecified, Labels.VerificationWorkFlowStepCmpSuppUser) + "<br/>";
				num++;
			}
			if (CS_0024_003C_003E8__locals0.vm.Mode == 1 || CS_0024_003C_003E8__locals0.vm.Mode == 2)
			{
				if (CS_0024_003C_003E8__locals0.vm.VerifyRequestText == null)
				{
					text = text + string.Format(Messages.ErrorEmpty, Labels.PordVerificationReqVerifyText) + "<br/>";
					num++;
				}
				else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.VerifyRequestText, list2))
				{
					text = text + string.Format(Messages.CheckFieldInLang, Labels.PordVerificationReqVerifyText) + "<br>";
					num++;
				}
			}
			else if (CS_0024_003C_003E8__locals0.vm.Mode == 3 || CS_0024_003C_003E8__locals0.vm.Mode == 4 || CS_0024_003C_003E8__locals0.vm.Mode == 5)
			{
				if (CS_0024_003C_003E8__locals0.vm.VerifyText == null)
				{
					text = text + string.Format(Messages.ErrorEmpty, Labels.PordVerificationReqStepVerifyText) + "<br/>";
					num++;
				}
				else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.VerifyText, list))
				{
					text = text + string.Format(Messages.CheckFieldInLang, Labels.PordVerificationReqStepVerifyText) + "<br>";
					num++;
				}
				if (CS_0024_003C_003E8__locals0.vm.Mode == 3 && (!CS_0024_003C_003E8__locals0.vm.VerifyUserId.HasValue || CS_0024_003C_003E8__locals0.vm.VerifyUserId == 0))
				{
					text = text + string.Format(Messages.ErrorEmpty, Labels.PordVerificationReqVerifyUserId) + "<br/>";
					num++;
				}
				if (CS_0024_003C_003E8__locals0.vm.Mode == 5 && (!CS_0024_003C_003E8__locals0.vm.AlternateVerifyUserId.HasValue || CS_0024_003C_003E8__locals0.vm.AlternateVerifyUserId == 0))
				{
					text = text + Messages.msgErrorHaveNotAlternateVerifyUser + "<br/>";
					num++;
				}
			}
			else if (CS_0024_003C_003E8__locals0.vm.Mode == 6)
			{
				if (CS_0024_003C_003E8__locals0.vm.ReasonCancellation == null)
				{
					text = text + string.Format(Messages.ErrorEmpty, Labels.PordVerificationReqReasonCancellation) + "<br/>";
					num++;
				}
				else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.ReasonCancellation, list3))
				{
					text = text + string.Format(Messages.CheckFieldInLang, Labels.PordVerificationReqReasonCancellation) + "<br>";
					num++;
				}
				if (!CS_0024_003C_003E8__locals0.vm.VerificationRequestId.HasValue || CS_0024_003C_003E8__locals0.vm.VerificationRequestId == 0)
				{
					text = text + string.Format(Messages.ErrorEmpty, Labels.PordVerificationReqVerification) + "<br/>";
					num++;
				}
			}
			else if (CS_0024_003C_003E8__locals0.vm.Mode == 7)
			{
				if (CS_0024_003C_003E8__locals0.vm.VerifyText == null)
				{
					text = text + string.Format(Messages.ErrorEmpty, Labels.Description) + "<br/>";
					num++;
				}
				else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.VerifyText, list))
				{
					text = text + string.Format(Messages.CheckFieldInLang, Labels.Description) + "<br>";
					num++;
				}
			}
			string text5 = "";
			if (num == 0)
			{
				DateTime now = DateTime.Now;
				int result2 = 0;
				int.TryParse(CS_0024_003C_003E8__locals0.vm.ObjectId.ToString(), out result2);
				try
				{
					int userId = UserLogin.CurrentUser.UserId;
					string text6 = now.ToString("yyyyMMdd", new PersianCulture());
					int value = int.Parse(Financial.Get().Id.ToString());
					short value2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
					short value3 = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					if (CS_0024_003C_003E8__locals0.vm.Mode == 1)
					{
						text = "";
						string verificationReqText = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						string resourceString = MyResource.GetResourceString("VerifiedRequestSubject", "fa-IR", "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
						string text7 = "";
						foreach (Languages lang7 in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages m) => m.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
						{
							string text8 = "";
							string text9 = "";
							text8 = MyResource.GetResourceString("VerifiedRequestSubject", lang7.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
							text9 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang7.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang7.LanguageID)).Value : "");
							text7 = text7 + "[LangId=" + lang7.LanguageID + "|,|Txt=" + text9 + "|,|Subj=" + text8 + "|,|]@";
						}
						if (CS_0024_003C_003E8__locals0.vm.VerificationReqUserId.GetValueOrDefault() == 0)
						{
							CS_0024_003C_003E8__locals0.vm.VerificationReqUserId = userId;
						}
						ObjectParameter objectParameter2 = new ObjectParameter("result", 0);
						_db.WSspSendVerificationRequest(CS_0024_003C_003E8__locals0.vm.VerificationWorkFlowId, CS_0024_003C_003E8__locals0.vm.ObjectId, verificationReqText, text7, resourceString, now, text6, userId, value, value2, value3, appType, CS_0024_003C_003E8__locals0.defLangID, objectParameter2, CS_0024_003C_003E8__locals0.vm.VerificationReqUserId, objectParameter, (result != 0) ? new int?(result) : null);
						if (objectParameter2.Value != null && !string.IsNullOrEmpty(objectParameter2.Value.ToString()))
						{
							switch (objectParameter2.Value.ToString())
							{
							case "-2":
								text += Messages.msgErrorErrorSendingMessages;
								break;
							case "-1":
								text += Messages.msgErrorRunFunction;
								break;
							case "-101":
								text += string.Format(Messages.msgErrorIsNotSpecified, Labels.VerificationWorkFlowStepResponsibleUser);
								break;
							case "-102":
								text += string.Format(Messages.msgErrorIsNotSpecified, Labels.VerificationWorkFlowStepCmpReferUser);
								break;
							case "-103":
								text += string.Format(Messages.msgErrorIsNotSpecified, Labels.VerificationWorkFlowStepCmpSuppUser);
								break;
							case "-106":
								text += string.Format(Messages.msgErrorIsNotSpecified, Labels.VerificationWorkFlowStepSellerUser);
								break;
							case "-109":
								text += string.Format(Messages.msgErrorIsNotSpecified, Labels.VerificationWorkFlowStepSaleCenterReferUser);
								break;
							}
						}
					}
					else if (CS_0024_003C_003E8__locals0.vm.Mode == 2)
					{
						text = "";
						string verificationReqText2 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						string resourceString2 = MyResource.GetResourceString("VerifiedRequestSubject", "fa-IR", "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
						string text10 = "";
						foreach (Languages lang6 in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages m) => m.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
						{
							string text11 = "";
							string text12 = "";
							text11 = MyResource.GetResourceString("VerifiedRequestSubject", lang6.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
							text12 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang6.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang6.LanguageID)).Value : "");
							text10 = text10 + "[LangId=" + lang6.LanguageID + "|,|Txt=" + text12 + "|,|Subj=" + text11 + "|,|]@";
						}
						if (CS_0024_003C_003E8__locals0.vm.VerificationReqUserId.GetValueOrDefault() == 0)
						{
							CS_0024_003C_003E8__locals0.vm.VerificationReqUserId = userId;
						}
						ObjectParameter objectParameter3 = new ObjectParameter("result", 0);
						_dbI.WSspSendVerificationRequestToAlternateUser(CS_0024_003C_003E8__locals0.vm.VerificationWorkFlowId, CS_0024_003C_003E8__locals0.vm.ObjectId, verificationReqText2, text10, resourceString2, now, text6, userId, value, value2, value3, appType, CS_0024_003C_003E8__locals0.defLangID, objectParameter3, CS_0024_003C_003E8__locals0.vm.VerificationReqUserId, objectParameter, (result != 0) ? new int?(result) : null);
						if (objectParameter3.Value != null && !string.IsNullOrEmpty(objectParameter3.Value.ToString()))
						{
							switch (objectParameter3.Value.ToString())
							{
							case "-3":
								text += Messages.msgErrorHaveNotAlternateVerifyUser;
								break;
							case "-2":
								text += Messages.msgErrorErrorSendingMessages;
								break;
							case "-1":
								text += Messages.msgErrorRunFunction;
								break;
							}
						}
					}
					else if (CS_0024_003C_003E8__locals0.vm.Mode == 3)
					{
						text = "";
						string verifyText = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						string resourceString3 = MyResource.GetResourceString("VerifiedRequestSubject", "fa-IR", "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
						string text13 = "";
						string resourceString4 = MyResource.GetResourceString("VerifiedRequestVerify", "fa-IR", "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
						foreach (Languages lang5 in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages m) => m.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
						{
							string text14 = "";
							string text15 = "";
							string text16 = "";
							text14 = MyResource.GetResourceString("VerifiedRequestSubject", lang5.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
							text16 = MyResource.GetResourceString("VerifiedRequestVerify", lang5.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
							text15 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang5.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang5.LanguageID)).Value : "");
							text13 = text13 + "[LangId=" + lang5.LanguageID + "|,|Txt=" + text15 + "|,|Subj=" + text14 + "|,|VerifiedSubj=" + text16 + "|,|]@";
						}
						ObjectParameter objectParameter4 = new ObjectParameter("result", "");
						ObjectParameter objectParameter5 = new ObjectParameter("maxDiscountPercent", typeof(decimal));
						_db.WSspVerificationRequestVerify(CS_0024_003C_003E8__locals0.vm.VerificationWorkFlowId, CS_0024_003C_003E8__locals0.vm.ObjectId, CS_0024_003C_003E8__locals0.vm.VerificationRequestId, CS_0024_003C_003E8__locals0.vm.VerificationWorkFlowStepId, verifyText, text13, resourceString3, resourceString4, UserLogin.CurrentUser.RollId, now, text6, userId, value, value2, value3, appType, lCID, CS_0024_003C_003E8__locals0.defLangID, objectParameter5, objectParameter4, 1, objectParameter, (result != 0) ? new int?(result) : null);
						string text17 = "";
						if (objectParameter5.Value != null && !string.IsNullOrEmpty(objectParameter5.Value.ToString()))
						{
							text17 = objectParameter5.Value.ToString();
						}
						if (objectParameter4.Value != null && !string.IsNullOrEmpty(objectParameter4.Value.ToString()))
						{
							string text18 = objectParameter4.Value.ToString();
							switch (text18)
							{
							case "-8":
								if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.FormName))
								{
									if (CS_0024_003C_003E8__locals0.vm.FormName == "PORD")
									{
										text += string.Format(Messages.msgErrorNotVerifyBecauseDifferentDisStWithItemDis, Labels.lblPOrd);
									}
									else if (CS_0024_003C_003E8__locals0.vm.FormName == "ORD")
									{
										text += string.Format(Messages.msgErrorNotVerifyBecauseDifferentDisStWithItemDis, "lblOrd".OrderLabels());
									}
								}
								break;
							case "-7":
								if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.FormName))
								{
									if (CS_0024_003C_003E8__locals0.vm.FormName == "PORD")
									{
										text += string.Format(Messages.msgErrorNotVerifyBecauseNotAddDisStToItemDis, Labels.lblPOrd);
									}
									else if (CS_0024_003C_003E8__locals0.vm.FormName == "ORD")
									{
										text += string.Format(Messages.msgErrorNotVerifyBecauseNotAddDisStToItemDis, "lblOrd".OrderLabels());
									}
								}
								break;
							case "-6":
							{
								List<CRMspDySelectFormWorkflowStepsNotCheckedForMasterValue_Result> list4 = Enumerable.ToList<CRMspDySelectFormWorkflowStepsNotCheckedForMasterValue_Result>((IEnumerable<CRMspDySelectFormWorkflowStepsNotCheckedForMasterValue_Result>)_dbI.CRMspDySelectFormWorkflowStepsNotCheckedForMasterValue(CS_0024_003C_003E8__locals0.vm.ObjectId, lCID, CS_0024_003C_003E8__locals0.defLangID));
								if (list4 == null || !Enumerable.Any<CRMspDySelectFormWorkflowStepsNotCheckedForMasterValue_Result>((IEnumerable<CRMspDySelectFormWorkflowStepsNotCheckedForMasterValue_Result>)list4))
								{
									break;
								}
								string text19 = "";
								foreach (CRMspDySelectFormWorkflowStepsNotCheckedForMasterValue_Result item in list4)
								{
									if (!string.IsNullOrWhiteSpace(item.WorkflowStepTitle))
									{
										text19 = text19 + item.WorkflowStepTitle + "<br>";
									}
								}
								text = text + Messages.msgErrorDyFrmNotConfirmSteps + "<br>" + text19;
								break;
							}
							case "-5":
								text += Messages.msgErrorRunFunction;
								break;
							default:
								if (text18.IndexOf("-4|", StringComparison.Ordinal) >= 0)
								{
									text = text + string.Format(Messages.msgErrorCheckVerificationWorkflowStepBFCurr, text18.Replace("-4|", "") ?? "") + "<br>";
									break;
								}
								switch (text18)
								{
								case "-3":
									if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.FormName))
									{
										if (CS_0024_003C_003E8__locals0.vm.FormName == "PORD")
										{
											text = text + Messages.MaxDiscountPercentPreOrderInActivePreOrder + " " + text17;
										}
										else if (CS_0024_003C_003E8__locals0.vm.FormName == "ORD")
										{
											text = text + "MaxDiscountPercentOrderInActiveOrder".OrderMessages() + " " + text17;
										}
									}
									break;
								case "-2":
									if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.FormName))
									{
										if (CS_0024_003C_003E8__locals0.vm.FormName == "PORD")
										{
											text = text + Messages.MaxDiscountPercentInActivePreOrder + " " + text17;
										}
										else if (CS_0024_003C_003E8__locals0.vm.FormName == "ORD")
										{
											text = text + Messages.MaxDiscountPercentInActiveOrder + " " + text17;
										}
									}
									break;
								case "-1":
									text += Messages.msgErrorDivisionByZero;
									break;
								case "-101":
									text += string.Format(Messages.msgErrorIsNotSpecified, Labels.VerificationWorkFlowStepResponsibleUser);
									break;
								case "-102":
									text += string.Format(Messages.msgErrorIsNotSpecified, Labels.VerificationWorkFlowStepCmpReferUser);
									break;
								case "-103":
									text += string.Format(Messages.msgErrorIsNotSpecified, Labels.VerificationWorkFlowStepCmpSuppUser);
									break;
								case "-106":
									text += string.Format(Messages.msgErrorIsNotSpecified, Labels.VerificationWorkFlowStepSellerUser);
									break;
								case "-109":
									text += string.Format(Messages.msgErrorIsNotSpecified, Labels.VerificationWorkFlowStepSaleCenterReferUser);
									break;
								}
								break;
							}
						}
					}
					else if (CS_0024_003C_003E8__locals0.vm.Mode == 4)
					{
						text = "";
						string messageText = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : "");
						string resourceString5 = MyResource.GetResourceString("IsNotVerifiedSubject", "fa-IR", "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						List<CrmInternalMessage_Lang> list5 = new List<CrmInternalMessage_Lang>();
						foreach (Languages lang4 in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages m) => m.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
						{
							string resourceString6 = MyResource.GetResourceString("VerifiedRequestSubject", lang4.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
							MyResource.GetResourceString("IsNotVerifiedSubject", lang4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
							string msgBody = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang4.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang4.LanguageID)).Value : "");
							list5.Add(new CrmInternalMessage_Lang
							{
								LanguageID = lang4.LanguageID,
								msgSubject = resourceString6,
								msgBody = msgBody
							});
						}
						ObjectParameter objectParameter6 = new ObjectParameter("result", "");
						_dbI.WSspVerificationRequestExpired(CS_0024_003C_003E8__locals0.vm.VerificationRequestId, CS_0024_003C_003E8__locals0.vm.VerificationWorkFlowId, CS_0024_003C_003E8__locals0.vm.ObjectId, messageText, JsonConvert.SerializeObject(list5), resourceString5, now, text6, userId, value, value2, value3, appType, lCID, CS_0024_003C_003E8__locals0.defLangID, objectParameter6, CS_0024_003C_003E8__locals0.vm.CancellationStepId, CS_0024_003C_003E8__locals0.vm.ReasonCancellation, UserLogin.CurrentUser.RollId, 2, objectParameter, (result != 0) ? new int?(result) : null);
						if (objectParameter6.Value != null && !string.IsNullOrEmpty(objectParameter6.Value.ToString()) && objectParameter6.Value.ToString() != "1")
						{
							text += Messages.msgErrorRunFunction;
						}
					}
					else if (CS_0024_003C_003E8__locals0.vm.Mode == 5)
					{
						text = "";
						string messageText2 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						string resourceString7 = MyResource.GetResourceString("VerifiedRequestSubject", "fa-IR", "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
						List<CrmInternalMessage_Lang> list6 = new List<CrmInternalMessage_Lang>();
						foreach (Languages lang3 in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages m) => m.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
						{
							string resourceString8 = MyResource.GetResourceString("VerifiedRequestSubject", lang3.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
							string msgBody2 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang3.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang3.LanguageID)).Value : "");
							list6.Add(new CrmInternalMessage_Lang
							{
								LanguageID = lang3.LanguageID,
								msgSubject = resourceString8,
								msgBody = msgBody2
							});
						}
						int result3 = 0;
						int.TryParse(CS_0024_003C_003E8__locals0.vm.VerificationReqUserId.ToString(), out result3);
						int result4 = 0;
						int.TryParse(CS_0024_003C_003E8__locals0.vm.AlternateVerifyUserId.ToString(), out result4);
						if (result4 > 0 && result3 > 0)
						{
							_dbII.WSspVerificationRequestSendToAltUser(CS_0024_003C_003E8__locals0.vm.VerificationRequestId, CS_0024_003C_003E8__locals0.vm.VerificationWorkFlowId, CS_0024_003C_003E8__locals0.vm.VerificationWorkFlowStepId, CS_0024_003C_003E8__locals0.vm.ObjectId, CS_0024_003C_003E8__locals0.vm.ObjectType, messageText2, JsonConvert.SerializeObject(list6), resourceString7, CS_0024_003C_003E8__locals0.vm.VerifyText, CS_0024_003C_003E8__locals0.vm.VerifyText_Lang, 8, CS_0024_003C_003E8__locals0.vm.AlternateVerifyUserId, now, text6, userId, value, value2, value3, appType, lCID, CS_0024_003C_003E8__locals0.defLangID, objectParameter, (result != 0) ? new int?(result) : null);
						}
						else
						{
							text += Messages.msgErrorHaveNotAlternateVerifyUser;
						}
					}
					else if (CS_0024_003C_003E8__locals0.vm.Mode == 6)
					{
						string messageText3 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : "");
						string resourceString9 = MyResource.GetResourceString("IsNotVerifiedSubject", "fa-IR", "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						List<CrmInternalMessage_Lang> list7 = new List<CrmInternalMessage_Lang>();
						foreach (Languages lang2 in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages m) => m.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
						{
							string text20 = "";
							string text21 = "";
							text20 = MyResource.GetResourceString("VerifiedRequestSubject", lang2.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
							MyResource.GetResourceString("IsNotVerifiedSubject", lang2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
							text21 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)).Value : "");
							list7.Add(new CrmInternalMessage_Lang
							{
								LanguageID = lang2.LanguageID,
								msgSubject = text20,
								msgBody = text21
							});
						}
						ObjectParameter objectParameter7 = new ObjectParameter("result", "");
						_dbI.WSspVerificationRequestExpired(CS_0024_003C_003E8__locals0.vm.VerificationRequestId, CS_0024_003C_003E8__locals0.vm.VerificationWorkFlowId, CS_0024_003C_003E8__locals0.vm.ObjectId, messageText3, JsonConvert.SerializeObject(list7), resourceString9, now, text6, userId, value, value2, value3, appType, lCID, CS_0024_003C_003E8__locals0.defLangID, objectParameter7, CS_0024_003C_003E8__locals0.vm.CancellationStepId, CS_0024_003C_003E8__locals0.vm.ReasonCancellation, UserLogin.CurrentUser.RollId, 6, objectParameter, (result != 0) ? new int?(result) : null);
						if (objectParameter7.Value != null && !string.IsNullOrEmpty(objectParameter7.Value.ToString()) && objectParameter7.Value.ToString() != "1")
						{
							text += Messages.msgErrorRunFunction;
						}
					}
					else if (CS_0024_003C_003E8__locals0.vm.Mode == 7)
					{
						text = "";
						string text22 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						string @string = Labels.ResourceManager.GetString("VerifiedRequestSubject", new CultureInfo(CS_0024_003C_003E8__locals0.defLangID));
						Labels.ResourceManager.GetString("VerifiedRequestVerify", new CultureInfo(CS_0024_003C_003E8__locals0.defLangID));
						List<CrmInternalMessage_Lang> list8 = new List<CrmInternalMessage_Lang>();
						foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages m) => m.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
						{
							string string2 = Labels.ResourceManager.GetString("VerifiedRequestSubject", new CultureInfo(lang.LanguageCollation));
							Labels.ResourceManager.GetString("VerifiedRequestVerify", new CultureInfo(lang.LanguageCollation));
							string msgBody3 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : "");
							list8.Add(new CrmInternalMessage_Lang
							{
								msgSubject = string2,
								msgBody = msgBody3,
								LanguageID = lang.LanguageID
							});
						}
						new ObjectParameter("result", "");
						WSspVerificationRequestBack_Result wSspVerificationRequestBack_Result = Enumerable.FirstOrDefault<WSspVerificationRequestBack_Result>((IEnumerable<WSspVerificationRequestBack_Result>)_dbII.WSspVerificationRequestBack(CS_0024_003C_003E8__locals0.vm.VerificationRequestId, CS_0024_003C_003E8__locals0.vm.VerificationWorkFlowId, CS_0024_003C_003E8__locals0.vm.ObjectId, CS_0024_003C_003E8__locals0.vm.ObjectType, text22, JsonConvert.SerializeObject(list8), @string, registerDate: now, registerDatePersian: text6, userId: userId, fPId: value, year1: value2, month1: value3, appType: appType, languageID: lCID, defaultLanguageID: CS_0024_003C_003E8__locals0.defLangID, backToStepId: CS_0024_003C_003E8__locals0.vm.CancellationStepId, verifyText: CS_0024_003C_003E8__locals0.vm.ReasonCancellation, verifyReqResultId: 7, internalMessageId: objectParameter, centerId: (result != 0) ? new int?(result) : null));
						if (wSspVerificationRequestBack_Result != null)
						{
							if (wSspVerificationRequestBack_Result.InsertedRequestDetailId.GetValueOrDefault() == 0)
							{
								text += Messages.msgErrorRunFunction;
							}
							else if (wSspVerificationRequestBack_Result.InternalMessageId.GetValueOrDefault() == 0)
							{
								text += Messages.msgErrorRunFunction;
							}
						}
					}
					if (string.IsNullOrWhiteSpace(text))
					{
						if (CS_0024_003C_003E8__locals0.vm.ObjectType == 20)
						{
							WSspSelectOrderById_Result wSspSelectOrderById_Result = Enumerable.FirstOrDefault<WSspSelectOrderById_Result>((IEnumerable<WSspSelectOrderById_Result>)_db.WSspSelectOrderById(CS_0024_003C_003E8__locals0.vm.ObjectId, lCID, CS_0024_003C_003E8__locals0.defLangID));
							if (wSspSelectOrderById_Result != null)
							{
								bool result5 = false;
								bool.TryParse(wSspSelectOrderById_Result.ordIsVerified.ToString(), out result5);
								if (result5)
								{
									Order.VerifyOrderComplete(CS_0024_003C_003E8__locals0.vm.ObjectId, "frmOrder", UserLogin.IsUserAccess("frmOrder", "actVerifyOrder", UserLogin.CurrentUser), actVerifyOrder_Passed: true, UserLogin.IsUserAccess("frmOrder", "actAutoReferOrderToWrhsUserAfterVerify", UserLogin.CurrentUser), UserLogin.IsUserAccess("frmOrder", "actIssueDraftAuto", UserLogin.CurrentUser), "actIssueDraftAuto", UserLogin.IsUserAccess("frmOrder", "actGetOrdFOLink", UserLogin.CurrentUser));
								}
								else
								{
									mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.ScorespDeleteOrderScores(CS_0024_003C_003E8__locals0.vm.ObjectId, userId, value2, value3, now, text6, appType, CS_0024_003C_003E8__locals0.defLangID, (result == 0) ? null : new int?(result)));
									if (mct_I_Result != null && mct_I_Result.Result == 0)
									{
										text = Messages.msgErrorRunFunction;
									}
								}
								if (!string.IsNullOrWhiteSpace((wSspSelectOrderById_Result.ordEditAfterFixInfoJs ?? "").Replace("[]", "")))
								{
									List<EditAfterFixInfoViewModel> list9 = JsonConvert.DeserializeObject<List<EditAfterFixInfoViewModel>>(wSspSelectOrderById_Result.ordEditAfterFixInfoJs);
									if (list9 != null)
									{
										foreach (EditAfterFixInfoViewModel item2 in list9)
										{
											if (item2.eafUserId == UserLogin.CurrentUser.UserId && item2.eafWorkflowReqId == CS_0024_003C_003E8__locals0.vm.VerificationRequestId && item2.eafWorkflowStepId == CS_0024_003C_003E8__locals0.vm.VerificationWorkFlowStepId)
											{
												item2.eafIsDone = true;
												item2.eafDoneDate = DateTime.Now;
											}
										}
										DbSet<WSOrder> wSOrder = _dbTbl.WSOrder;
										ParameterExpression val = Expression.Parameter(typeof(WSOrder), "x");
										WSOrder wSOrder2 = Queryable.FirstOrDefault<WSOrder>((IQueryable<WSOrder>)wSOrder, Expression.Lambda<Func<WSOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass10_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
										if (wSOrder2 != null)
										{
											wSOrder2.ordEditAfterFixInfoJs = JsonConvert.SerializeObject(list9);
											_dbTbl.Entry(wSOrder2).State = EntityState.Modified;
											_dbTbl.Configuration.ValidateOnSaveEnabled = false;
											_dbTbl.SaveChanges();
											_dbTbl.Configuration.ValidateOnSaveEnabled = true;
										}
									}
								}
							}
						}
						if (CS_0024_003C_003E8__locals0.vm.ObjectType == 40)
						{
							WSspSelectBuyOrderById_Result wSspSelectBuyOrderById_Result = Enumerable.FirstOrDefault<WSspSelectBuyOrderById_Result>((IEnumerable<WSspSelectBuyOrderById_Result>)_dbII.WSspSelectBuyOrderById(CS_0024_003C_003E8__locals0.vm.ObjectId, lCID, CS_0024_003C_003E8__locals0.defLangID));
							if (wSspSelectBuyOrderById_Result != null)
							{
								bool result6 = false;
								bool.TryParse(wSspSelectBuyOrderById_Result.bordIsVerified.ToString(), out result6);
								if (result6 && UserLogin.IsUserAccess("frmBuyOrder", "actIssueDocAuto", UserLogin.CurrentUser) && VersionBuyer.WareHouse)
								{
									string refResult = "";
									BuyOrder.AutoIssueDocFromBord(CS_0024_003C_003E8__locals0.vm.ObjectId, UserLogin.CurrentUser.UserId, ref refResult, 0, result);
								}
								if (!string.IsNullOrWhiteSpace((wSspSelectBuyOrderById_Result.bordEditAfterFixInfoJs ?? "").Replace("[]", "")))
								{
									List<EditAfterFixInfoViewModel> list10 = JsonConvert.DeserializeObject<List<EditAfterFixInfoViewModel>>(wSspSelectBuyOrderById_Result.bordEditAfterFixInfoJs);
									if (list10 != null)
									{
										foreach (EditAfterFixInfoViewModel item3 in list10)
										{
											if (item3.eafUserId == UserLogin.CurrentUser.UserId && item3.eafWorkflowReqId == CS_0024_003C_003E8__locals0.vm.VerificationRequestId && item3.eafWorkflowStepId == CS_0024_003C_003E8__locals0.vm.VerificationWorkFlowStepId)
											{
												item3.eafIsDone = true;
												item3.eafDoneDate = DateTime.Now;
											}
										}
										DbSet<WSBuyOrder> wSBuyOrder = _dbTbl.WSBuyOrder;
										ParameterExpression val = Expression.Parameter(typeof(WSBuyOrder), "x");
										WSBuyOrder wSBuyOrder2 = Queryable.FirstOrDefault<WSBuyOrder>((IQueryable<WSBuyOrder>)wSBuyOrder, Expression.Lambda<Func<WSBuyOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass10_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
										if (wSBuyOrder2 != null)
										{
											wSBuyOrder2.bordEditAfterFixInfoJs = JsonConvert.SerializeObject(list10);
											_dbTbl.Entry(wSBuyOrder2).State = EntityState.Modified;
											_dbTbl.Configuration.ValidateOnSaveEnabled = false;
											_dbTbl.SaveChanges();
											_dbTbl.Configuration.ValidateOnSaveEnabled = true;
										}
									}
								}
							}
						}
						if (CS_0024_003C_003E8__locals0.vm.ObjectType == 60)
						{
							WSspSelectDocById_Result wSspSelectDocById_Result = Enumerable.FirstOrDefault<WSspSelectDocById_Result>((IEnumerable<WSspSelectDocById_Result>)_dbI.WSspSelectDocById(CS_0024_003C_003E8__locals0.vm.ObjectId, lCID, CS_0024_003C_003E8__locals0.defLangID));
							if (wSspSelectDocById_Result != null)
							{
								bool result7 = false;
								bool.TryParse(wSspSelectDocById_Result.IsVerified.ToString(), out result7);
								int result8 = 0;
								int.TryParse(wSspSelectDocById_Result.OprType.ToString(), out result8);
								if (result7)
								{
									bool flag = false;
									switch (result8)
									{
									case 1:
										flag = UserLogin.IsUserAccess("frmDoc", "actAutoReferDocToOrdReferUserAfterVerify", UserLogin.CurrentUser);
										break;
									case 2:
										flag = UserLogin.IsUserAccess("frmDraft", "actAutoReferDocToOrdReferUserAfterVerify", UserLogin.CurrentUser);
										break;
									}
									if (flag)
									{
										Doc.ReferDocToOrdReferUser(CS_0024_003C_003E8__locals0.vm.ObjectId.ToString(), 0);
									}
								}
								if (!string.IsNullOrWhiteSpace((wSspSelectDocById_Result.EditAfterFixInfoJs ?? "").Replace("[]", "")))
								{
									List<EditAfterFixInfoViewModel> list11 = JsonConvert.DeserializeObject<List<EditAfterFixInfoViewModel>>(wSspSelectDocById_Result.EditAfterFixInfoJs);
									if (list11 != null)
									{
										foreach (EditAfterFixInfoViewModel item4 in list11)
										{
											if (item4.eafUserId == UserLogin.CurrentUser.UserId && item4.eafWorkflowReqId == CS_0024_003C_003E8__locals0.vm.VerificationRequestId && item4.eafWorkflowStepId == CS_0024_003C_003E8__locals0.vm.VerificationWorkFlowStepId)
											{
												item4.eafIsDone = true;
												item4.eafDoneDate = DateTime.Now;
											}
										}
										DbSet<WSDoc> wSDoc = _dbTbl.WSDoc;
										ParameterExpression val = Expression.Parameter(typeof(WSDoc), "x");
										WSDoc wSDoc2 = Queryable.FirstOrDefault<WSDoc>((IQueryable<WSDoc>)wSDoc, Expression.Lambda<Func<WSDoc, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass10_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
										if (wSDoc2 != null)
										{
											wSDoc2.EditAfterFixInfoJs = JsonConvert.SerializeObject(list11);
											_dbTbl.Entry(wSDoc2).State = EntityState.Modified;
											_dbTbl.Configuration.ValidateOnSaveEnabled = false;
											_dbTbl.SaveChanges();
											_dbTbl.Configuration.ValidateOnSaveEnabled = true;
										}
									}
								}
							}
						}
						if (CS_0024_003C_003E8__locals0.vm.ObjectType == 10)
						{
							WSspSelectPreOrderWithId_Result wSspSelectPreOrderWithId_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)_db.WSspSelectPreOrderWithId(CS_0024_003C_003E8__locals0.vm.ObjectId, lCID, CS_0024_003C_003E8__locals0.defLangID));
							if (wSspSelectPreOrderWithId_Result != null)
							{
								if (wSspSelectPreOrderWithId_Result.pordIsVerified.GetValueOrDefault())
								{
									bool? sendSMSPordFOLinkAfterVerify = SysSeting.Get().SendSMSPordFOLinkAfterVerify;
									int? sendSMSPordFOLinkAfterVerifyType = SysSeting.Get().SendSMSPordFOLinkAfterVerifyType;
									string text23 = "";
									string text24 = "";
									string text25 = "";
									string text26 = "";
									if (sendSMSPordFOLinkAfterVerify.GetValueOrDefault())
									{
										List<SelectListItem> pordFoShortLinks = PreOrder.GetPordFoShortLinks(wSspSelectPreOrderWithId_Result.PreOrderID);
										text24 = pordFoShortLinks[1].Value;
										text25 = pordFoShortLinks[2].Value;
										text26 = pordFoShortLinks[3].Value;
										if (sendSMSPordFOLinkAfterVerifyType.GetValueOrDefault() == 1)
										{
											text23 = text24;
										}
										else if (sendSMSPordFOLinkAfterVerifyType.GetValueOrDefault() == 2)
										{
											text23 = text25;
										}
										else if (sendSMSPordFOLinkAfterVerifyType.GetValueOrDefault() == 3)
										{
											text23 = text26;
										}
									}
									if (!string.IsNullOrWhiteSpace(text23))
									{
										ObjectParameter objectParameter8 = new ObjectParameter("Result", 0);
										_dbII.CRMspSendSmsPordFOLinkAfterVerify(CS_0024_003C_003E8__locals0.vm.ObjectId, text23, text24, text25, userId, value2, value3, text6, appType, lCID, CS_0024_003C_003E8__locals0.defLangID, objectParameter8, text26, (result != 0) ? new int?(result) : null);
										if (objectParameter8 != null)
										{
											_ = (int)objectParameter8.Value;
											_ = 1;
										}
									}
									PreOrder.SendSmsFoSettingPordAfterVerify(CS_0024_003C_003E8__locals0.vm.ObjectId);
									CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(wSspSelectPreOrderWithId_Result.pordCompanyId.GetValueOrDefault());
									if (companyById != null && companyById.cmpCRMShopIsActive.GetValueOrDefault())
									{
										int retId = 0;
										new InternalMessage().SendIntmsgSingle(0, Labels.ShopVerifyPreOrderTitle, string.Format(Labels.ShopVerifyPreOrderMsg, wSspSelectPreOrderWithId_Result.pordNumber, DateTime.Now.ToString("yyyy/MM/dd")).Replace("<br>", "\n"), 5, userId, -20, DateTime.Now.ToString("yyyyMMdd", new PersianCulture()), DateTime.Now.ToString("HH:mm:ss"), 0, "", wSspSelectPreOrderWithId_Result.PreOrderID, Messages.ConversationErjaShow, 0, out retId, CS_0024_003C_003E8__locals0.defLangID);
										if (wSspSelectPreOrderWithId_Result.pordCompanyId.HasValue && wSspSelectPreOrderWithId_Result.pordCompanyId > 0)
										{
											Dictionary<string, string> dictionary = new Dictionary<string, string>();
											dictionary.Add("Title", Labels.ShopVerifyPreOrderTitle);
											dictionary.Add("Message", string.Format(Labels.ShopVerifyPreOrderMsg, wSspSelectPreOrderWithId_Result.pordNumber, DateTime.Now.ToString("yyyy/MM/dd")).Replace("<br>", "\n"));
											dictionary.Add("MessageType", "VerifyPreOrd");
											dictionary.Add("InternalMessageId", retId.ToString());
											dictionary.Add("preOrderID", wSspSelectPreOrderWithId_Result.PreOrderID.ToString());
											PushNotif.NewIntMsgNotifyToCompany(int.Parse(wSspSelectPreOrderWithId_Result.pordCompanyId.ToString()), dictionary);
										}
									}
								}
								if (!string.IsNullOrWhiteSpace((wSspSelectPreOrderWithId_Result.pordEditAfterFixInfoJs ?? "").Replace("[]", "")))
								{
									List<EditAfterFixInfoViewModel> list12 = JsonConvert.DeserializeObject<List<EditAfterFixInfoViewModel>>(wSspSelectPreOrderWithId_Result.pordEditAfterFixInfoJs);
									if (list12 != null)
									{
										foreach (EditAfterFixInfoViewModel item5 in list12)
										{
											if (item5.eafUserId == UserLogin.CurrentUser.UserId && item5.eafWorkflowReqId == CS_0024_003C_003E8__locals0.vm.VerificationRequestId && item5.eafWorkflowStepId == CS_0024_003C_003E8__locals0.vm.VerificationWorkFlowStepId)
											{
												item5.eafIsDone = true;
												item5.eafDoneDate = DateTime.Now;
											}
										}
										DbSet<WSPreOrder> wSPreOrder = _dbTbl.WSPreOrder;
										ParameterExpression val = Expression.Parameter(typeof(WSPreOrder), "x");
										WSPreOrder wSPreOrder2 = Queryable.FirstOrDefault<WSPreOrder>((IQueryable<WSPreOrder>)wSPreOrder, Expression.Lambda<Func<WSPreOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass10_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
										if (wSPreOrder2 != null)
										{
											wSPreOrder2.pordEditAfterFixInfoJs = JsonConvert.SerializeObject(list12);
											_dbTbl.Entry(wSPreOrder2).State = EntityState.Modified;
											_dbTbl.Configuration.ValidateOnSaveEnabled = false;
											_dbTbl.SaveChanges();
											_dbTbl.Configuration.ValidateOnSaveEnabled = true;
										}
									}
								}
							}
						}
						if (CS_0024_003C_003E8__locals0.vm.ObjectType == 80)
						{
							CRMspDySelectFormFieldMasterValueWithId_Result cRMspDySelectFormFieldMasterValueWithId_Result = Enumerable.FirstOrDefault<CRMspDySelectFormFieldMasterValueWithId_Result>((IEnumerable<CRMspDySelectFormFieldMasterValueWithId_Result>)_db.CRMspDySelectFormFieldMasterValueWithId(CS_0024_003C_003E8__locals0.vm.ObjectId, lCID, CS_0024_003C_003E8__locals0.defLangID));
							if (cRMspDySelectFormFieldMasterValueWithId_Result != null)
							{
								if (cRMspDySelectFormFieldMasterValueWithId_Result.IsChecked.GetValueOrDefault())
								{
									_dbII.ScorespInsertAndCalcDyFormScores(null, CS_0024_003C_003E8__locals0.vm.ObjectId, null, null, userId, value2, value3, now, text6, appType, lCID, CS_0024_003C_003E8__locals0.defLangID, true, null, result, true);
								}
								if (!string.IsNullOrWhiteSpace((cRMspDySelectFormFieldMasterValueWithId_Result.EditAfterFixInfoJs ?? "").Replace("[]", "")))
								{
									List<EditAfterFixInfoViewModel> list13 = JsonConvert.DeserializeObject<List<EditAfterFixInfoViewModel>>(cRMspDySelectFormFieldMasterValueWithId_Result.EditAfterFixInfoJs);
									if (list13 != null)
									{
										foreach (EditAfterFixInfoViewModel item6 in list13)
										{
											if (item6.eafUserId == UserLogin.CurrentUser.UserId && item6.eafWorkflowReqId == CS_0024_003C_003E8__locals0.vm.VerificationRequestId && item6.eafWorkflowStepId == CS_0024_003C_003E8__locals0.vm.VerificationWorkFlowStepId)
											{
												item6.eafIsDone = true;
												item6.eafDoneDate = DateTime.Now;
											}
										}
										DbSet<CrmDyFormFieldMasterValues> crmDyFormFieldMasterValues = _dbTbl.CrmDyFormFieldMasterValues;
										ParameterExpression val = Expression.Parameter(typeof(CrmDyFormFieldMasterValues), "x");
										CrmDyFormFieldMasterValues crmDyFormFieldMasterValues2 = Queryable.FirstOrDefault<CrmDyFormFieldMasterValues>((IQueryable<CrmDyFormFieldMasterValues>)crmDyFormFieldMasterValues, Expression.Lambda<Func<CrmDyFormFieldMasterValues, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass10_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
										if (crmDyFormFieldMasterValues2 != null)
										{
											crmDyFormFieldMasterValues2.EditAfterFixInfoJs = JsonConvert.SerializeObject(list13);
											_dbTbl.Entry(crmDyFormFieldMasterValues2).State = EntityState.Modified;
											_dbTbl.Configuration.ValidateOnSaveEnabled = false;
											_dbTbl.SaveChanges();
											_dbTbl.Configuration.ValidateOnSaveEnabled = true;
										}
									}
								}
							}
						}
						if (CS_0024_003C_003E8__locals0.vm.ObjectType == 110)
						{
							SecspSelectLettersById_Result secspSelectLettersById_Result = Enumerable.FirstOrDefault<SecspSelectLettersById_Result>((IEnumerable<SecspSelectLettersById_Result>)_dbII.SecspSelectLettersById(CS_0024_003C_003E8__locals0.vm.ObjectId, lCID, CS_0024_003C_003E8__locals0.defLangID));
							if (secspSelectLettersById_Result != null && !string.IsNullOrWhiteSpace((secspSelectLettersById_Result.LetterEditAfterFixInfoJs ?? "").Replace("[]", "")))
							{
								List<EditAfterFixInfoViewModel> list14 = JsonConvert.DeserializeObject<List<EditAfterFixInfoViewModel>>(secspSelectLettersById_Result.LetterEditAfterFixInfoJs);
								if (list14 != null)
								{
									foreach (EditAfterFixInfoViewModel item7 in list14)
									{
										if (item7.eafUserId == UserLogin.CurrentUser.UserId && item7.eafWorkflowReqId == CS_0024_003C_003E8__locals0.vm.VerificationRequestId && item7.eafWorkflowStepId == CS_0024_003C_003E8__locals0.vm.VerificationWorkFlowStepId)
										{
											item7.eafIsDone = true;
											item7.eafDoneDate = DateTime.Now;
										}
									}
									DbSet<SecLetters> secLetters = _dbTbl.SecLetters;
									ParameterExpression val = Expression.Parameter(typeof(SecLetters), "x");
									SecLetters secLetters2 = Queryable.FirstOrDefault<SecLetters>((IQueryable<SecLetters>)secLetters, Expression.Lambda<Func<SecLetters, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass10_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
									if (secLetters2 != null)
									{
										secLetters2.LetterEditAfterFixInfoJs = JsonConvert.SerializeObject(list14);
										_dbTbl.Entry(secLetters2).State = EntityState.Modified;
										_dbTbl.Configuration.ValidateOnSaveEnabled = false;
										_dbTbl.SaveChanges();
										_dbTbl.Configuration.ValidateOnSaveEnabled = true;
									}
								}
							}
						}
						if (CS_0024_003C_003E8__locals0.vm.ObjectType == 90 || CS_0024_003C_003E8__locals0.vm.ObjectType == 100)
						{
							CRMspSelectLeave_Result cRMspSelectLeave_Result = Enumerable.FirstOrDefault<CRMspSelectLeave_Result>((IEnumerable<CRMspSelectLeave_Result>)_dbI.CRMspSelectLeave(0, CS_0024_003C_003E8__locals0.vm.ObjectId, 0, 0, null, null, lCID, CS_0024_003C_003E8__locals0.defLangID, null, result));
							if (cRMspSelectLeave_Result != null)
							{
								if (cRMspSelectLeave_Result.ReplaceUserId.GetValueOrDefault() != 0 && cRMspSelectLeave_Result.LeaveStatusId.GetValueOrDefault() == 2)
								{
									List<CommonMultiLanguageViewModel> list15 = new List<CommonMultiLanguageViewModel>();
									foreach (Languages item8 in CRMIdeal.Cache.Setting.Language.Get())
									{
										CultureInfo cultureInfo = new CultureInfo(item8.LanguageID);
										list15.Add(new CommonMultiLanguageViewModel
										{
											Value = string.Format(Messages.ResourceManager.GetString("ReplaceUserMessageAfterVerify", cultureInfo), (cRMspSelectLeave_Result.FromDateTime ?? DateTime.Now).ToString("yyyy/MM/dd", cultureInfo), cRMspSelectLeave_Result.RequestUser),
											LanguageId = item8.LanguageID
										});
									}
									int msgId = 0;
									SendMessage(ref msgId, cRMspSelectLeave_Result.FirstRegisterUserId.GetValueOrDefault(), cRMspSelectLeave_Result.ReplaceUserId.GetValueOrDefault(), msgTypeId, Labels.VerifiedRequestSubject, Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list15, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel x) => x.LanguageId == CS_0024_003C_003E8__locals0.defLangID))).Value, Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list15, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel x) => x.LanguageId != CS_0024_003C_003E8__locals0.defLangID))), result2, CS_0024_003C_003E8__locals0.vm.VerificationWorkFlowStepId);
								}
								if (cRMspSelectLeave_Result.LeaveStatusId.GetValueOrDefault() == 2)
								{
									_dbII.CRMspCalcAndUpdateTimeAttendanceLeave(cRMspSelectLeave_Result.FromDateTime, cRMspSelectLeave_Result.RequestUserId, value3, DateTime.Now, text6, appType, lCID);
									DateTime now2 = DateTime.Now;
									DateTime? fromDateTime = cRMspSelectLeave_Result.FromDateTime;
									DateTime? toDateTime = cRMspSelectLeave_Result.ToDateTime;
									if (fromDateTime.HasValue && toDateTime.HasValue)
									{
										DateTime? dateTime = fromDateTime;
										DateTime dateTime2 = now2;
										if (dateTime.HasValue && dateTime.GetValueOrDefault() <= dateTime2 && toDateTime <= now2)
										{
											int leaveId = cRMspSelectLeave_Result.LeaveId;
											int valueOrDefault = cRMspSelectLeave_Result.LeaveTypeId.GetValueOrDefault();
											string arg = "";
											switch (valueOrDefault)
											{
											case 1:
											case 2:
												arg = Labels.lblLeave;
												break;
											case 3:
											case 4:
												arg = Labels.lblMission;
												break;
											}
											CommonReturnResultViewModel commonReturnResultViewModel = new CRMIdeal.Areas.Leave.Controllers.HomeController().ActExecuteLeave(leaveId, valueOrDefault);
											if (commonReturnResultViewModel != null)
											{
												if (!commonReturnResultViewModel.IsDone)
												{
													text5 = (string.IsNullOrWhiteSpace(commonReturnResultViewModel.Message) ? string.Format(Messages.msgErrorNotEexcuteLeave, arg) : commonReturnResultViewModel.Message);
												}
											}
											else
											{
												text5 = string.Format(Messages.msgErrorNotEexcuteLeave, arg);
											}
										}
									}
								}
							}
						}
						if (CS_0024_003C_003E8__locals0.vm.ObjectType == 130)
						{
							Enumerable.FirstOrDefault<CRMspSelectFund_Result>((IEnumerable<CRMspSelectFund_Result>)_db.CRMspSelectFund(null, CS_0024_003C_003E8__locals0.vm.ObjectId, UserLogin.CurrentUser.UserId, null, null, null, lCID, CS_0024_003C_003E8__locals0.defLangID));
						}
					}
					PushNotif.NewIntMsgNotify();
					if (string.IsNullOrEmpty(text))
					{
						if (CS_0024_003C_003E8__locals0.vm.MsgId.GetValueOrDefault() > 0)
						{
							SetMessageRead(CS_0024_003C_003E8__locals0.vm.MsgId.GetValueOrDefault(), msgTypeId);
						}
						if (string.IsNullOrWhiteSpace(text5))
						{
							base.ViewBag.Successfull = Messages.msgSuccessAction;
						}
						else
						{
							text = Messages.msgSuccessAction + "<br>" + text5 + "|-1000";
						}
					}
					if (string.IsNullOrWhiteSpace(text) && objectParameter != null && !string.IsNullOrWhiteSpace(objectParameter.Value.ToString()))
					{
						text = text + "IntMsg=" + objectParameter.Value.ToString();
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
		return text;
	}

	public bool SendMessage(ref int msgId, int fromUserId, int toUserId, int msgTypeId, string subject, string message, List<CommonMultiLanguageViewModel> msglist, int objectId, int? workflowStepId = null, List<CommonMultiLanguageViewModel> sublist = null)
	{
		bool result = true;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			DateTime now = DateTime.Now;
			int userId = UserLogin.CurrentUser.UserId;
			string text = now.ToString("yyyyMMdd", new PersianCulture());
			short value = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short value2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
			string msgdSendTime = now.ToString("HH:mm:ss");
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			ObjectParameter objectParameter = new ObjectParameter("InsertedID", 0);
			_db.CRMspInternalMessageSendSingle(null, subject, message, msgTypeId, fromUserId, toUserId, text, msgdSendTime, now, null, null, objectId, null, null, userId, value2, value, now, text, appType, objectParameter, defLangID, workflowStepId, null, centerId);
			int num = (msgId = (int)objectParameter.Value);
			foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
			{
				string msgBody = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)msglist, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)msglist, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : "");
				string msgSubject = subject;
				if (sublist != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)sublist))
				{
					msgSubject = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)sublist, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)sublist, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : subject);
				}
				CrmInternalMessage_Lang entity = new CrmInternalMessage_Lang
				{
					LanguageID = lang.LanguageID,
					InternalMessageID = num,
					msgBody = msgBody,
					msgSubject = msgSubject
				};
				_dbTbl.CrmInternalMessage_Lang.Add(entity);
				_dbTbl.SaveChanges();
			}
			if (num <= 0)
			{
				result = false;
			}
			PushNotif.NewIntMsgNotify();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = false;
		}
		return result;
	}

	public bool SendMessage_Old(int fromUserId, int toUserId, int msgTypeId, string subject, string message, List<CommonMultiLanguageViewModel> msglist, int objectId, int? workflowStepId = null, List<CommonMultiLanguageViewModel> sublist = null)
	{
		bool result = true;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			DateTime now = DateTime.Now;
			int userId = UserLogin.CurrentUser.UserId;
			string text = now.ToString("yyyyMMdd", new PersianCulture());
			short value = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short value2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
			string msgdSendTime = now.ToString("HH:mm:ss");
			_db.CRMspInternalMessageLoadReceiver(fromUserId);
			_db.CRMspIntMsgUpdateSelectReceiver(fromUserId.ToString(), toUserId.ToString(), true, 1);
			ObjectParameter objectParameter = new ObjectParameter("InternalMessageID", 0);
			_db.mfi_CRMspInternalMessageSend(null, subject, message, null, msgTypeId, fromUserId, toUserId, text, msgdSendTime, now, null, null, objectId, null, null, userId, value2, value, now, text, appType, objectParameter, defLangID, workflowStepId, null, centerId);
			int num = (int)objectParameter.Value;
			foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
			{
				string msgBody = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)msglist, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)msglist, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : "");
				string msgSubject = subject;
				if (sublist != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)sublist))
				{
					msgSubject = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)sublist, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)sublist, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : subject);
				}
				CrmInternalMessage_Lang entity = new CrmInternalMessage_Lang
				{
					LanguageID = lang.LanguageID,
					InternalMessageID = num,
					msgBody = msgBody,
					msgSubject = msgSubject
				};
				_dbTbl.CrmInternalMessage_Lang.Add(entity);
				_dbTbl.SaveChanges();
			}
			if (num <= 0)
			{
				result = false;
			}
			PushNotif.NewIntMsgNotify();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = false;
		}
		return result;
	}

	[AjaxOnly]
	public JsonResult GetVerificationWorkFlow(int objectType)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<WSspSelectVerificationWorkFlowWithObjectType_Result> list2 = Enumerable.ToList<WSspSelectVerificationWorkFlowWithObjectType_Result>((IEnumerable<WSspSelectVerificationWorkFlowWithObjectType_Result>)_db.WSspSelectVerificationWorkFlowWithObjectType(objectType, lCID, result));
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

	[AjaxOnly]
	public JsonResult GetVerificationRequests(int objectId, int objectType)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<WSspSelectVerificationRequests_Result> list2 = Enumerable.ToList<WSspSelectVerificationRequests_Result>((IEnumerable<WSspSelectVerificationRequests_Result>)_db.WSspSelectVerificationRequests(0, objectId, objectType, lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectVerificationRequests_Result, SelectListItem>((IEnumerable<WSspSelectVerificationRequests_Result>)list2, (Func<WSspSelectVerificationRequests_Result, SelectListItem>)((WSspSelectVerificationRequests_Result item) => new SelectListItem
			{
				Text = item.VerificationWorkFlowTitle,
				Value = item.VerificationRequestId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.VerificationRequestsList = list;
		base.ViewBag.VerificationRequestsListI = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public List<WSspSelectVerificationRequests_Result> SelectVerificationRequests(int objectId = 0, int objectType = 0)
	{
		List<WSspSelectVerificationRequests_Result> result = new List<WSspSelectVerificationRequests_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectVerificationRequests_Result> list = Enumerable.ToList<WSspSelectVerificationRequests_Result>((IEnumerable<WSspSelectVerificationRequests_Result>)_db.WSspSelectVerificationRequests(0, objectId, objectType, lCID, result2));
			if (list != null)
			{
				result = list;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	public List<SelectListItem> SelectVerificationRequestsSelectListItem(int objectId = 0, int objectType = 0)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<WSspSelectVerificationRequests_Result> list2 = SelectVerificationRequests(objectId, objectType);
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<WSspSelectVerificationRequests_Result, SelectListItem>((IEnumerable<WSspSelectVerificationRequests_Result>)list2, (Func<WSspSelectVerificationRequests_Result, SelectListItem>)((WSspSelectVerificationRequests_Result item) => new SelectListItem
				{
					Text = item.VerificationWorkFlowTitle,
					Value = item.VerificationRequestId.ToString(),
					Selected = false
				})));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return list;
	}

	[AjaxOnly]
	public JsonResult GetCrrVerificationRequest(int reqId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CurrentWSVerificationRequestsViewModel currentWSVerificationRequestsViewModel = new CurrentWSVerificationRequestsViewModel();
		currentWSVerificationRequestsViewModel.VerificationRequestDetail = new List<WSspSelectVerificationRequestDetails_Result>();
		try
		{
			WSspSelectVerificationRequests_Result wSspSelectVerificationRequests_Result = Enumerable.FirstOrDefault<WSspSelectVerificationRequests_Result>((IEnumerable<WSspSelectVerificationRequests_Result>)_db.WSspSelectVerificationRequests(reqId, 0, 0, lCID, result));
			if (wSspSelectVerificationRequests_Result != null)
			{
				currentWSVerificationRequestsViewModel.IsFind = true;
				currentWSVerificationRequestsViewModel.Message = "";
				currentWSVerificationRequestsViewModel.VerificationRequest = wSspSelectVerificationRequests_Result;
				currentWSVerificationRequestsViewModel.VerificationRequestCurrentId = wSspSelectVerificationRequests_Result.VerificationRequestId;
				_ = wSspSelectVerificationRequests_Result.VerificationReqDateTime;
				wSspSelectVerificationRequests_Result.FirstRegisterDatePersian = wSspSelectVerificationRequests_Result.VerificationReqDateTime.ToString("yyyy/MM/dd");
				wSspSelectVerificationRequests_Result.RegisterDatePersian = (wSspSelectVerificationRequests_Result.VerificationReqExpiredDateTime.HasValue ? wSspSelectVerificationRequests_Result.VerificationReqExpiredDateTime.Value.ToString("yyyy/MM/dd") : null);
				currentWSVerificationRequestsViewModel.VerificationRequestDetail = ListVerificationRequestDetails(wSspSelectVerificationRequests_Result.VerificationRequestId, wSspSelectVerificationRequests_Result.VerificationWorkFlowId);
			}
			else
			{
				currentWSVerificationRequestsViewModel.IsFind = false;
				currentWSVerificationRequestsViewModel.Message = Messages.ErrorNotFound;
				currentWSVerificationRequestsViewModel.VerificationRequest = null;
				currentWSVerificationRequestsViewModel.VerificationRequestCurrentId = -1;
			}
		}
		catch (DbEntityValidationException ex)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
			currentWSVerificationRequestsViewModel.Message = Messages.msgErrorRunFunction + "<br />" + ((Exception)(object)ex).Message;
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			currentWSVerificationRequestsViewModel.Message = Messages.msgErrorRunFunction + "<br />" + ex2.Message;
		}
		JsonResult jsonResult = Json(currentWSVerificationRequestsViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[LoginAuthorize]
	public string GetCrrVerificationRequestJs(int reqId = 0)
	{
		CurrentWSVerificationRequestsViewModel currentWSVerificationRequestsViewModel = new CurrentWSVerificationRequestsViewModel();
		currentWSVerificationRequestsViewModel.VerificationRequestDetail = new List<WSspSelectVerificationRequestDetails_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			WSspSelectVerificationRequests_Result wSspSelectVerificationRequests_Result = Enumerable.FirstOrDefault<WSspSelectVerificationRequests_Result>((IEnumerable<WSspSelectVerificationRequests_Result>)_db.WSspSelectVerificationRequests(reqId, 0, 0, lCID, result));
			if (wSspSelectVerificationRequests_Result != null)
			{
				currentWSVerificationRequestsViewModel.IsFind = true;
				currentWSVerificationRequestsViewModel.Message = "";
				currentWSVerificationRequestsViewModel.VerificationRequest = wSspSelectVerificationRequests_Result;
				currentWSVerificationRequestsViewModel.VerificationRequestCurrentId = wSspSelectVerificationRequests_Result.VerificationRequestId;
				_ = wSspSelectVerificationRequests_Result.VerificationReqDateTime;
				wSspSelectVerificationRequests_Result.FirstRegisterDatePersian = wSspSelectVerificationRequests_Result.VerificationReqDateTime.ToString("yyyy/MM/dd");
				wSspSelectVerificationRequests_Result.RegisterDatePersian = (wSspSelectVerificationRequests_Result.VerificationReqExpiredDateTime.HasValue ? wSspSelectVerificationRequests_Result.VerificationReqExpiredDateTime.Value.ToString("yyyy/MM/dd") : null);
				currentWSVerificationRequestsViewModel.VerificationRequestDetail = ListVerificationRequestDetails(wSspSelectVerificationRequests_Result.VerificationRequestId, wSspSelectVerificationRequests_Result.VerificationWorkFlowId);
			}
			else
			{
				currentWSVerificationRequestsViewModel.IsFind = false;
				currentWSVerificationRequestsViewModel.Message = Messages.ErrorNotFound;
				currentWSVerificationRequestsViewModel.VerificationRequest = null;
				currentWSVerificationRequestsViewModel.VerificationRequestCurrentId = -1;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return JsonConvert.SerializeObject(currentWSVerificationRequestsViewModel);
	}

	public List<WSspSelectVerificationRequestDetails_Result> ListVerificationRequestDetails(int vReqId, int workflowId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectVerificationRequestDetails_Result> list = new List<WSspSelectVerificationRequestDetails_Result>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			list = Enumerable.ToList<WSspSelectVerificationRequestDetails_Result>((IEnumerable<WSspSelectVerificationRequestDetails_Result>)_db.WSspSelectVerificationRequestDetails(0, vReqId, workflowId, currLangID, result, result2));
			using List<WSspSelectVerificationRequestDetails_Result>.Enumerator enumerator = list.GetEnumerator();
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass19_1 _003C_003Ec__DisplayClass19_ = new _003C_003Ec__DisplayClass19_1();
				_003C_003Ec__DisplayClass19_.item = enumerator.Current;
				_003C_003Ec__DisplayClass19_.item.AppType = (_003C_003Ec__DisplayClass19_.item.VerifyDateTime.HasValue ? _003C_003Ec__DisplayClass19_.item.VerifyDateTime.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
				if (_003C_003Ec__DisplayClass19_.item.VerificationRequestDetailId.HasValue && _003C_003Ec__DisplayClass19_.item.VerificationRequestDetailId > 0)
				{
					DbSet<WSVerificationRequestDetails_Lang> wSVerificationRequestDetails_Lang = _dbTbl.WSVerificationRequestDetails_Lang;
					ParameterExpression val = Expression.Parameter(typeof(WSVerificationRequestDetails_Lang), "c");
					List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSVerificationRequestDetails_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSVerificationRequestDetails_Lang>)Enumerable.ToList<WSVerificationRequestDetails_Lang>((IEnumerable<WSVerificationRequestDetails_Lang>)Queryable.Where<WSVerificationRequestDetails_Lang>((IQueryable<WSVerificationRequestDetails_Lang>)wSVerificationRequestDetails_Lang, Expression.Lambda<Func<WSVerificationRequestDetails_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Convert((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), typeof(int?)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass19_, typeof(_003C_003Ec__DisplayClass19_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }))), (Func<WSVerificationRequestDetails_Lang, CommonMultiLanguageViewModel>)((WSVerificationRequestDetails_Lang item1) => new CommonMultiLanguageViewModel
					{
						Value = item1.VerifyText,
						LanguageId = item1.LanguageID
					})));
					list2.Add(new CommonMultiLanguageViewModel
					{
						Value = _003C_003Ec__DisplayClass19_.item.VerifyText,
						LanguageId = result
					});
					_003C_003Ec__DisplayClass19_.item.VerifyText = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
					_003C_003Ec__DisplayClass19_.item.EditUser = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
				}
				else
				{
					DbSet<WSVerificationWorkFlowSteps_Lang> wSVerificationWorkFlowSteps_Lang = _dbTbl.WSVerificationWorkFlowSteps_Lang;
					ParameterExpression val = Expression.Parameter(typeof(WSVerificationWorkFlowSteps_Lang), "c");
					List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSVerificationWorkFlowSteps_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSVerificationWorkFlowSteps_Lang>)Enumerable.ToList<WSVerificationWorkFlowSteps_Lang>((IEnumerable<WSVerificationWorkFlowSteps_Lang>)Queryable.Where<WSVerificationWorkFlowSteps_Lang>((IQueryable<WSVerificationWorkFlowSteps_Lang>)wSVerificationWorkFlowSteps_Lang, Expression.Lambda<Func<WSVerificationWorkFlowSteps_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Convert((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), typeof(int?)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass19_, typeof(_003C_003Ec__DisplayClass19_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }))), (Func<WSVerificationWorkFlowSteps_Lang, CommonMultiLanguageViewModel>)((WSVerificationWorkFlowSteps_Lang item1) => new CommonMultiLanguageViewModel
					{
						Value = item1.VerifyText,
						LanguageId = item1.LanguageID
					})));
					list3.Add(new CommonMultiLanguageViewModel
					{
						Value = _003C_003Ec__DisplayClass19_.item.VerifyText,
						LanguageId = result
					});
					_003C_003Ec__DisplayClass19_.item.VerifyText = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
					_003C_003Ec__DisplayClass19_.item.EditUser = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
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
	public ActionResult GetVerificationRequestDetails(int vReqId, int workflowId)
	{
		return Json(ListVerificationRequestDetails(vReqId, workflowId), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetWorkflowInfo(int workflowId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		WSspSelectVerificationWorkFlowWithId_Result wSspSelectVerificationWorkFlowWithId_Result = new WSspSelectVerificationWorkFlowWithId_Result();
		try
		{
			wSspSelectVerificationWorkFlowWithId_Result = Enumerable.FirstOrDefault<WSspSelectVerificationWorkFlowWithId_Result>((IEnumerable<WSspSelectVerificationWorkFlowWithId_Result>)_db.WSspSelectVerificationWorkFlowWithId(workflowId, lCID, result));
			if (wSspSelectVerificationWorkFlowWithId_Result != null)
			{
				WSspSelectVerificationWorkFlowWithId_Result wSspSelectVerificationWorkFlowWithId_Result2 = wSspSelectVerificationWorkFlowWithId_Result;
				_ = wSspSelectVerificationWorkFlowWithId_Result.SequenceObservation;
				wSspSelectVerificationWorkFlowWithId_Result2.SequenceObservation = wSspSelectVerificationWorkFlowWithId_Result.SequenceObservation;
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
		JsonResult jsonResult = Json(wSspSelectVerificationWorkFlowWithId_Result, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public JsonResult GetOrdFOLink(int ordId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string data = "";
		string text = "";
		CommonResultStatusViewModel status = CommonResultStatusViewModel.Fail;
		CommonResultViewModel<string> commonResultViewModel = new CommonResultViewModel<string>();
		try
		{
			if (ordId != 0)
			{
				if (!UserLogin.IsUserAccess("frmOrder", "actGetOrdFOLink", UserLogin.CurrentUser))
				{
					text = Messages.ErrorNotAccess;
				}
				else
				{
					CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
					if (cRMspSelectCrmsysSetting_Result != null)
					{
						string text2 = cRMspSelectCrmsysSetting_Result.FOUrl ?? "";
						text2 = text2.Trim();
						if (!string.IsNullOrWhiteSpace(text2))
						{
							if (!text2.StartsWith("http"))
							{
								text2 = "http://" + text2;
							}
							if (text2.EndsWith("/"))
							{
								text2 = text2.Substring(0, text2.Length - 1);
							}
							string text3 = CodeDecode.CoddingUTF8(ordId.ToString());
							text2 = text2 + "?" + "Ord".ToLower() + "=" + text3;
							data = text2;
							text = Messages.msgSuccessAction;
							status = CommonResultStatusViewModel.Success;
						}
						else
						{
							text = Messages.errorInReadingSetting;
						}
					}
					else
					{
						text = Messages.errorInReadingSetting;
					}
				}
			}
			else
			{
				text = string.Format(Messages.msgErrorIsNotSelectedItem, Labels.lblPOrd);
				data = null;
				status = CommonResultStatusViewModel.Fail;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = Messages.msgErrorRunFunction;
			data = "";
			status = CommonResultStatusViewModel.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		commonResultViewModel = new CommonResultViewModel<string>
		{
			Message = text,
			Data = data,
			Status = status
		};
		JsonResult jsonResult = Json(commonResultViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public JsonResult GetPordFOLink(int pordId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string data = "";
		string text = "";
		CommonResultStatusViewModel status = CommonResultStatusViewModel.Fail;
		CommonResultViewModel<string> commonResultViewModel = new CommonResultViewModel<string>();
		try
		{
			if (pordId != 0)
			{
				if (!UserLogin.IsUserAccess("frmPreOrder", "actGetPordFOLink", UserLogin.CurrentUser))
				{
					text = Messages.ErrorNotAccess;
				}
				else
				{
					CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
					if (cRMspSelectCrmsysSetting_Result != null)
					{
						string text2 = cRMspSelectCrmsysSetting_Result.FOUrl ?? "";
						text2 = text2.Trim();
						if (!string.IsNullOrWhiteSpace(text2))
						{
							if (!text2.StartsWith("http"))
							{
								text2 = "http://" + text2;
							}
							if (text2.EndsWith("/"))
							{
								text2 = text2.Substring(0, text2.Length - 1);
							}
							string text3 = CodeDecode.CoddingUTF8(pordId.ToString());
							text2 = text2 + "?" + "Pord".ToLower() + "=" + text3;
							data = text2;
							text = Messages.msgSuccessAction;
							status = CommonResultStatusViewModel.Success;
						}
						else
						{
							text = Messages.errorInReadingSetting;
						}
					}
					else
					{
						text = Messages.errorInReadingSetting;
					}
				}
			}
			else
			{
				text = string.Format(Messages.msgErrorIsNotSelectedItem, Labels.lblPOrd);
				data = null;
				status = CommonResultStatusViewModel.Fail;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = Messages.msgErrorRunFunction;
			data = "";
			status = CommonResultStatusViewModel.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		commonResultViewModel = new CommonResultViewModel<string>
		{
			Message = text,
			Data = data,
			Status = status
		};
		JsonResult jsonResult = Json(commonResultViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetCrrVerificationRequestDetail(int reqDetailId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CurrentWSVerificationRequestDetailsViewModel currentWSVerificationRequestDetailsViewModel = new CurrentWSVerificationRequestDetailsViewModel();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			WSspSelectVerificationRequestDetails_Result wSspSelectVerificationRequestDetails_Result = Enumerable.FirstOrDefault<WSspSelectVerificationRequestDetails_Result>((IEnumerable<WSspSelectVerificationRequestDetails_Result>)_db.WSspSelectVerificationRequestDetails(reqDetailId, 0, 0, lCID, result, result2));
			if (wSspSelectVerificationRequestDetails_Result != null)
			{
				currentWSVerificationRequestDetailsViewModel.IsFind = true;
				currentWSVerificationRequestDetailsViewModel.Message = "";
				currentWSVerificationRequestDetailsViewModel.VerificationRequestDetail = wSspSelectVerificationRequestDetails_Result;
				currentWSVerificationRequestDetailsViewModel.VerificationReqDetailCurrentId = wSspSelectVerificationRequestDetails_Result.VerificationRequestDetailId.GetValueOrDefault();
				wSspSelectVerificationRequestDetails_Result.AppType = (wSspSelectVerificationRequestDetails_Result.VerifyDateTime.HasValue ? wSspSelectVerificationRequestDetails_Result.VerifyDateTime.Value.ToString("yyyy/MM/dd") : null);
			}
			else
			{
				currentWSVerificationRequestDetailsViewModel.IsFind = false;
				currentWSVerificationRequestDetailsViewModel.Message = Messages.ErrorNotFound;
				currentWSVerificationRequestDetailsViewModel.VerificationRequestDetail = null;
				currentWSVerificationRequestDetailsViewModel.VerificationReqDetailCurrentId = -1;
			}
		}
		catch (DbEntityValidationException ex)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
			currentWSVerificationRequestDetailsViewModel.Message = Messages.msgErrorRunFunction + "<br />" + ((Exception)(object)ex).Message;
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			currentWSVerificationRequestDetailsViewModel.Message = Messages.msgErrorRunFunction + "<br />" + ex2.Message;
		}
		JsonResult jsonResult = Json(currentWSVerificationRequestDetailsViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public string LeaveSendRequestToReplaceUser(string parameters)
	{
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel();
		commonReturnResultViewModel.IsDone = false;
		commonReturnResultViewModel.MessageExtra = "";
		int num = 0;
		try
		{
			int result = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
			}
			if (!string.IsNullOrEmpty(parameters))
			{
				LeaveReplaceUserVerificationRequestLanguageViewModel leaveReplaceUserVerificationRequestLanguageViewModel = new JavaScriptSerializer().Deserialize<LeaveReplaceUserVerificationRequestLanguageViewModel>(parameters);
				CRMspSelectLeave_Result cRMspSelectLeave_Result = Enumerable.FirstOrDefault<CRMspSelectLeave_Result>((IEnumerable<CRMspSelectLeave_Result>)_dbI.CRMspSelectLeave(null, leaveReplaceUserVerificationRequestLanguageViewModel.LeaveId, null, null, null, null, defLangID, defLangID, null, result));
				if (cRMspSelectLeave_Result != null)
				{
					int? workflowStepId = null;
					int msgTypeId = 0;
					if (cRMspSelectLeave_Result.LeaveTypeOpr.GetValueOrDefault() == 1)
					{
						msgTypeId = 6;
						workflowStepId = cRMspSelectLeave_Result.VerificationWorkFlowId ?? cRMspSelectLeave_Result.UserDepartmentLeaveVerificationWorkFlowId;
					}
					else if (cRMspSelectLeave_Result.LeaveTypeOpr.GetValueOrDefault() == 2)
					{
						msgTypeId = 7;
						workflowStepId = cRMspSelectLeave_Result.VerificationWorkFlowId ?? cRMspSelectLeave_Result.UserDepartmentMissionVerificationWorkFlowId;
					}
					List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrEmpty(leaveReplaceUserVerificationRequestLanguageViewModel.VerifyText_Lang))
					{
						list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(leaveReplaceUserVerificationRequestLanguageViewModel.VerifyText_Lang);
					}
					list.Add(new CommonMultiLanguageViewModel
					{
						Value = leaveReplaceUserVerificationRequestLanguageViewModel.VerifyText,
						LanguageId = lCID
					});
					string message = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					string resourceString = MyResource.GetResourceString("VerifiedRequestSubject", "fa-IR", "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
					List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
					foreach (Languages item2 in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages m) => m.LanguageID != defLangID))))
					{
						string text = "";
						text = MyResource.GetResourceString("VerifiedRequestSubject", item2.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
						CommonMultiLanguageViewModel item = new CommonMultiLanguageViewModel
						{
							Value = text,
							LanguageId = item2.LanguageID
						};
						list2.Add(item);
					}
					int userId = UserLogin.CurrentUser.UserId;
					int result2 = 0;
					int.TryParse(cRMspSelectLeave_Result.ReplaceUserId.ToString(), out result2);
					if (userId > 0 && result2 > 0)
					{
						int msgId = 0;
						SendMessage(ref msgId, userId, result2, msgTypeId, resourceString, message, list, leaveReplaceUserVerificationRequestLanguageViewModel.LeaveId, workflowStepId, list2);
						_dbII.CRMspUpdateLeaveReplaceUserIntMsgId(leaveReplaceUserVerificationRequestLanguageViewModel.LeaveId, msgId);
						commonReturnResultViewModel.IsDone = true;
						commonReturnResultViewModel.Message = Messages.msgSuccessAction;
					}
					else
					{
						num++;
						commonReturnResultViewModel.IsDone = false;
						commonReturnResultViewModel.Message = Messages.msgErrorHaveNotAlternateVerifyUser;
					}
				}
				else
				{
					num++;
					commonReturnResultViewModel.IsDone = false;
					commonReturnResultViewModel.Message = Messages.ErrorNotFound;
				}
			}
			else
			{
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = Messages.msgSendParameterNotEntered;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			commonReturnResultViewModel.IsDone = false;
			commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
		}
		return JsonConvert.SerializeObject(commonReturnResultViewModel);
	}

	[AjaxOnly]
	public string LeaveReplaceUserVerificationAction(string parameters)
	{
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel();
		commonReturnResultViewModel.IsDone = false;
		commonReturnResultViewModel.MessageExtra = "";
		int num = 0;
		try
		{
			int result = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
			}
			if (!string.IsNullOrEmpty(parameters))
			{
				LeaveReplaceUserVerificationRequestLanguageViewModel leaveReplaceUserVerificationRequestLanguageViewModel = new JavaScriptSerializer().Deserialize<LeaveReplaceUserVerificationRequestLanguageViewModel>(parameters);
				CRMspSelectLeave_Result cRMspSelectLeave_Result = Enumerable.FirstOrDefault<CRMspSelectLeave_Result>((IEnumerable<CRMspSelectLeave_Result>)_dbI.CRMspSelectLeave(null, leaveReplaceUserVerificationRequestLanguageViewModel.LeaveId, null, null, null, null, defLangID, defLangID, null, result));
				if (cRMspSelectLeave_Result != null)
				{
					DateTime now = DateTime.Now;
					string verifiedRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					_ = UserLogin.CurrentUser.UserId;
					int msgTypeId = 0;
					if (cRMspSelectLeave_Result.LeaveTypeOpr.GetValueOrDefault() == 1)
					{
						msgTypeId = 6;
					}
					else if (cRMspSelectLeave_Result.LeaveTypeOpr.GetValueOrDefault() == 2)
					{
						msgTypeId = 7;
					}
					if (leaveReplaceUserVerificationRequestLanguageViewModel.Status == 1)
					{
						_dbI.CRMspLeaveReplaceUserVerify(cRMspSelectLeave_Result.LeaveId, now, verifiedRegisterDatePersian);
						if ((cRMspSelectLeave_Result.VerificationWorkFlowId ?? cRMspSelectLeave_Result.UserDepartmentLeaveVerificationWorkFlowId.GetValueOrDefault()) != 0)
						{
							WSVerificationRequestsLanguageViewModel wSVerificationRequestsLanguageViewModel = new WSVerificationRequestsLanguageViewModel();
							wSVerificationRequestsLanguageViewModel.ObjectId = cRMspSelectLeave_Result.LeaveId;
							if (cRMspSelectLeave_Result.LeaveTypeOpr.GetValueOrDefault() == 1)
							{
								wSVerificationRequestsLanguageViewModel.ObjectType = 90;
								wSVerificationRequestsLanguageViewModel.FormName = "LEAVE";
								wSVerificationRequestsLanguageViewModel.VerificationWorkFlowId = cRMspSelectLeave_Result.VerificationWorkFlowId ?? cRMspSelectLeave_Result.UserDepartmentLeaveVerificationWorkFlowId.GetValueOrDefault();
							}
							else if (cRMspSelectLeave_Result.LeaveTypeOpr.GetValueOrDefault() == 2)
							{
								wSVerificationRequestsLanguageViewModel.ObjectType = 100;
								wSVerificationRequestsLanguageViewModel.FormName = "MISSION";
								wSVerificationRequestsLanguageViewModel.VerificationWorkFlowId = cRMspSelectLeave_Result.VerificationWorkFlowId ?? cRMspSelectLeave_Result.UserDepartmentMissionVerificationWorkFlowId.GetValueOrDefault();
							}
							wSVerificationRequestsLanguageViewModel.Mode = 1;
							wSVerificationRequestsLanguageViewModel.Position = 0;
							wSVerificationRequestsLanguageViewModel.VerificationReqUserId = cRMspSelectLeave_Result.RequestUserId;
							wSVerificationRequestsLanguageViewModel.VerifyUserId = cRMspSelectLeave_Result.RequestUserId;
							List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
							foreach (Languages item3 in Enumerable.ToList<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get()))
							{
								CommonMultiLanguageViewModel commonMultiLanguageViewModel = new CommonMultiLanguageViewModel();
								string value = "";
								if (cRMspSelectLeave_Result.LeaveTypeId.GetValueOrDefault() == 1)
								{
									string text = ((!cRMspSelectLeave_Result.FromDateTime.HasValue) ? "" : cRMspSelectLeave_Result.FromDateTime.Value.ToString("dddd dd MMMM yyyy", new CultureInfo(item3.LanguageCollation)));
									value = MyResource.GetResourceString("HourlyLeaveRequestFullDateTimeForUserStr", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Labels).GetTypeInfo().Assembly);
									string userName = CRMIdeal.Classes.Helper.User.GetUserName(cRMspSelectLeave_Result.RequestUserId.GetValueOrDefault(), item3.LanguageID, defLangID);
									value = string.Format(value, userName ?? "", text, cRMspSelectLeave_Result.FromTime ?? "", cRMspSelectLeave_Result.ToTime ?? "", cRMspSelectLeave_Result.HourCount ?? "");
								}
								else if (cRMspSelectLeave_Result.LeaveTypeId.GetValueOrDefault() == 2)
								{
									string text2 = ((!cRMspSelectLeave_Result.FromDateTime.HasValue) ? "" : cRMspSelectLeave_Result.FromDateTime.Value.ToString("dddd yyyy/MM/dd", new CultureInfo(item3.LanguageCollation)));
									string text3 = ((!cRMspSelectLeave_Result.ToDateTime.HasValue) ? "" : cRMspSelectLeave_Result.ToDateTime.Value.ToString("dddd yyyy/MM/dd"));
									value = MyResource.GetResourceString("DailyLeaveRequestFullDateTimeForUserStr", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Labels).GetTypeInfo().Assembly);
									string userName2 = CRMIdeal.Classes.Helper.User.GetUserName(cRMspSelectLeave_Result.RequestUserId.GetValueOrDefault(), item3.LanguageID, defLangID);
									value = string.Format(value, userName2 ?? "", text2, text3, cRMspSelectLeave_Result.DayCount.GetValueOrDefault());
								}
								else if (cRMspSelectLeave_Result.LeaveTypeId.GetValueOrDefault() == 3)
								{
									string text4 = ((!cRMspSelectLeave_Result.FromDateTime.HasValue) ? "" : cRMspSelectLeave_Result.FromDateTime.Value.ToString("dddd yyyy/MM/dd", new CultureInfo(item3.LanguageCollation)));
									value = MyResource.GetResourceString("HourlyMissionRequestFullDateTimeForUserStr", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Labels).GetTypeInfo().Assembly);
									string userName3 = CRMIdeal.Classes.Helper.User.GetUserName(cRMspSelectLeave_Result.RequestUserId.GetValueOrDefault(), item3.LanguageID, defLangID);
									value = string.Format(value, userName3 ?? "", text4, cRMspSelectLeave_Result.FromTime ?? "", cRMspSelectLeave_Result.ToTime ?? "", cRMspSelectLeave_Result.HourCount ?? "");
								}
								else if (cRMspSelectLeave_Result.LeaveTypeId.GetValueOrDefault() == 4)
								{
									string text5 = ((!cRMspSelectLeave_Result.FromDateTime.HasValue) ? "" : cRMspSelectLeave_Result.FromDateTime.Value.ToString("dddd yyyy/MM/dd", new CultureInfo(item3.LanguageCollation)));
									string text6 = ((!cRMspSelectLeave_Result.ToDateTime.HasValue) ? "" : cRMspSelectLeave_Result.ToDateTime.Value.ToString("dddd yyyy/MM/dd"));
									value = MyResource.GetResourceString("DailyMissionRequestFullDateTimeForUserStr", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Labels).GetTypeInfo().Assembly);
									string userName4 = CRMIdeal.Classes.Helper.User.GetUserName(cRMspSelectLeave_Result.RequestUserId.GetValueOrDefault(), item3.LanguageID, defLangID);
									value = string.Format(value, userName4 ?? "", text5, text6, cRMspSelectLeave_Result.DayCount.GetValueOrDefault());
								}
								commonMultiLanguageViewModel.LanguageId = item3.LanguageID;
								commonMultiLanguageViewModel.Value = value;
								list.Add(commonMultiLanguageViewModel);
							}
							if (list != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list))
							{
								wSVerificationRequestsLanguageViewModel.VerifyRequestText = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : "");
								wSVerificationRequestsLanguageViewModel.VerifyRequestText_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID))));
							}
							string text7 = Index(wSVerificationRequestsLanguageViewModel);
							if (string.IsNullOrWhiteSpace(text7))
							{
								commonReturnResultViewModel.IsDone = true;
							}
							else if (text7.Contains("IntMsg"))
							{
								commonReturnResultViewModel.MessageExtra = text7.Split(new char[1] { '=' })[1];
								commonReturnResultViewModel.IsDone = true;
							}
							else
							{
								commonReturnResultViewModel.Message = text7;
							}
						}
					}
					else if (leaveReplaceUserVerificationRequestLanguageViewModel.Status == 2)
					{
						_dbI.CRMspLeaveReplaceUserVerifyExit(cRMspSelectLeave_Result.LeaveId, DateTime.Now, DateTime.Now.ToString("yyyyMMdd", new PersianCulture()));
						List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
						List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
						foreach (Languages item4 in Enumerable.ToList<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get()))
						{
							string resourceString = MyResource.GetResourceString("IsNotVerifiedSubject", item4.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
							string format = "";
							if (cRMspSelectLeave_Result.LeaveTypeOpr.GetValueOrDefault(1) == 1)
							{
								format = MyResource.GetResourceString("msgLeaveRejectedWithNumber", item4.LanguageCollation, "CRM.Resources.Messages", typeof(Labels).GetTypeInfo().Assembly);
							}
							else if (cRMspSelectLeave_Result.LeaveTypeOpr.GetValueOrDefault(1) == 2)
							{
								format = MyResource.GetResourceString("msgMissionRejectedWithNumber", item4.LanguageCollation, "CRM.Resources.Messages", typeof(Labels).GetTypeInfo().Assembly);
							}
							format = string.Format(format, cRMspSelectLeave_Result.LeaveId);
							CommonMultiLanguageViewModel item = new CommonMultiLanguageViewModel
							{
								Value = resourceString,
								LanguageId = item4.LanguageID
							};
							list2.Add(item);
							CommonMultiLanguageViewModel item2 = new CommonMultiLanguageViewModel
							{
								Value = format,
								LanguageId = item4.LanguageID
							};
							list3.Add(item2);
						}
						string subject = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
						string message = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
						int userId = UserLogin.CurrentUser.UserId;
						int result2 = 0;
						int.TryParse(cRMspSelectLeave_Result.RequestUserId.ToString(), out result2);
						int num2 = 0;
						if (cRMspSelectLeave_Result.LeaveTypeOpr.GetValueOrDefault() == 1)
						{
							num2 = (cRMspSelectLeave_Result.VerificationWorkFlowId ?? cRMspSelectLeave_Result.UserDepartmentLeaveVerificationWorkFlowId).GetValueOrDefault();
						}
						else if (cRMspSelectLeave_Result.LeaveTypeOpr.GetValueOrDefault() == 2)
						{
							num2 = (cRMspSelectLeave_Result.VerificationWorkFlowId ?? cRMspSelectLeave_Result.UserDepartmentMissionVerificationWorkFlowId).GetValueOrDefault();
						}
						if (userId > 0 && result2 > 0 && num2 > 0)
						{
							int msgId = 0;
							SendMessage(ref msgId, userId, result2, msgTypeId, subject, message, list3, leaveReplaceUserVerificationRequestLanguageViewModel.LeaveId, num2, list2);
							commonReturnResultViewModel.IsDone = true;
							commonReturnResultViewModel.Message = Messages.msgSuccessAction;
							commonReturnResultViewModel.MessageExtra = msgId.ToString();
						}
						else
						{
							num++;
							commonReturnResultViewModel.IsDone = false;
							commonReturnResultViewModel.Message = Messages.msgErrorHaveNotAlternateVerifyUser;
						}
					}
					if (leaveReplaceUserVerificationRequestLanguageViewModel.MsgId.GetValueOrDefault() > 0)
					{
						SetMessageRead(leaveReplaceUserVerificationRequestLanguageViewModel.MsgId.GetValueOrDefault(), msgTypeId);
					}
				}
				else
				{
					num++;
					commonReturnResultViewModel.IsDone = false;
					commonReturnResultViewModel.Message = Messages.ErrorNotFound;
				}
			}
			else
			{
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = Messages.msgSendParameterNotEntered;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			commonReturnResultViewModel.IsDone = false;
			commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
		}
		return JsonConvert.SerializeObject(commonReturnResultViewModel);
	}

	public bool SetMessageRead(int msgId, int msgTypeId)
	{
		try
		{
			new CartablesController().ReadInternalMessage(msgId, msgTypeId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return false;
		}
		return true;
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

	public string GetLeaveSummaryInfo(int leaveId)
	{
		string result = "";
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		if (result2 <= 0)
		{
			result2 = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			CRMspSelectLeave_Result cRMspSelectLeave_Result = Enumerable.FirstOrDefault<CRMspSelectLeave_Result>((IEnumerable<CRMspSelectLeave_Result>)_dbI.CRMspSelectLeave(null, leaveId, null, null, null, null, lCID, result2, null, result3));
			if (cRMspSelectLeave_Result != null)
			{
				if (cRMspSelectLeave_Result.LeaveTypeId.GetValueOrDefault() == 1)
				{
					string text = ((!cRMspSelectLeave_Result.FromDateTime.HasValue) ? "" : cRMspSelectLeave_Result.FromDateTime.Value.ToString("dddd yyyy/MM/dd"));
					result = string.Format(Messages.HourlyLeaveRequestFullDateTimeForUserStr, cRMspSelectLeave_Result.RequestUser ?? "", text, cRMspSelectLeave_Result.FromTime ?? "", cRMspSelectLeave_Result.ToTime ?? "", cRMspSelectLeave_Result.HourCount ?? "");
				}
				else if (cRMspSelectLeave_Result.LeaveTypeId.GetValueOrDefault() == 2)
				{
					string text2 = ((!cRMspSelectLeave_Result.FromDateTime.HasValue) ? "" : cRMspSelectLeave_Result.FromDateTime.Value.ToString("dddd yyyy/MM/dd"));
					string text3 = ((!cRMspSelectLeave_Result.ToDateTime.HasValue) ? "" : cRMspSelectLeave_Result.ToDateTime.Value.ToString("dddd yyyy/MM/dd"));
					result = string.Format(Messages.DailyLeaveRequestFullDateTimeForUserStr, cRMspSelectLeave_Result.RequestUser ?? "", text2, text3, cRMspSelectLeave_Result.DayCount.GetValueOrDefault());
				}
				else if (cRMspSelectLeave_Result.LeaveTypeId.GetValueOrDefault() == 3)
				{
					string text4 = ((!cRMspSelectLeave_Result.FromDateTime.HasValue) ? "" : cRMspSelectLeave_Result.FromDateTime.Value.ToString("dddd yyyy/MM/dd"));
					result = string.Format(Messages.HourlyMissionRequestFullDateTimeForUserStr, cRMspSelectLeave_Result.RequestUser ?? "", text4, cRMspSelectLeave_Result.FromTime ?? "", cRMspSelectLeave_Result.ToTime ?? "", cRMspSelectLeave_Result.HourCount ?? "");
				}
				else if (cRMspSelectLeave_Result.LeaveTypeId.GetValueOrDefault() == 4)
				{
					string text5 = ((!cRMspSelectLeave_Result.FromDateTime.HasValue) ? "" : cRMspSelectLeave_Result.FromDateTime.Value.ToString("dddd yyyy/MM/dd"));
					string text6 = ((!cRMspSelectLeave_Result.ToDateTime.HasValue) ? "" : cRMspSelectLeave_Result.ToDateTime.Value.ToString("dddd yyyy/MM/dd"));
					result = string.Format(Messages.DailyMissionRequestFullDateTimeForUserStrHtml, cRMspSelectLeave_Result.RequestUser ?? "", text5, text6, cRMspSelectLeave_Result.DayCount.GetValueOrDefault());
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbI.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}
}

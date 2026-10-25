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
using CRMIdeal.Cache.Setting;
using CRMIdeal.Cache.User;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.VerificationWorkflow.Controllers;

public class HomeController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass22_1
	{
		public WSspSelectVerificationRequestDetails_Result item;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass30_0
	{
		public int? modeId;

		public int? wfReqId;

		public int? wfStepId;

		public int objId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass30_1
	{
		public int UserId;

		public _003C_003Ec__DisplayClass30_0 CS_0024_003C_003E8__locals1;

		internal bool _003CEditObjectOrder_003Eb__1(EditAfterFixInfoViewModel x)
		{
			if (x.eafUserId == UserId && x.eafModeId == CS_0024_003C_003E8__locals1.modeId && x.eafWorkflowReqId == CS_0024_003C_003E8__locals1.wfReqId)
			{
				return x.eafWorkflowStepId == CS_0024_003C_003E8__locals1.wfStepId;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass31_0
	{
		public int? modeId;

		public int? wfReqId;

		public int? wfStepId;

		public int objId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass31_1
	{
		public int UserId;

		public _003C_003Ec__DisplayClass31_0 CS_0024_003C_003E8__locals1;

		internal bool _003CEditObjectPreOrder_003Eb__1(EditAfterFixInfoViewModel x)
		{
			if (x.eafUserId == UserId && x.eafModeId == CS_0024_003C_003E8__locals1.modeId && x.eafWorkflowReqId == CS_0024_003C_003E8__locals1.wfReqId)
			{
				return x.eafWorkflowStepId == CS_0024_003C_003E8__locals1.wfStepId;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass32_0
	{
		public int? modeId;

		public int? wfReqId;

		public int? wfStepId;

		public int objId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass32_1
	{
		public int UserId;

		public _003C_003Ec__DisplayClass32_0 CS_0024_003C_003E8__locals1;

		internal bool _003CEditObjectBuyOrder_003Eb__1(EditAfterFixInfoViewModel x)
		{
			if (x.eafUserId == UserId && x.eafModeId == CS_0024_003C_003E8__locals1.modeId && x.eafWorkflowReqId == CS_0024_003C_003E8__locals1.wfReqId)
			{
				return x.eafWorkflowStepId == CS_0024_003C_003E8__locals1.wfStepId;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass33_0
	{
		public int? modeId;

		public int? wfReqId;

		public int? wfStepId;

		public int objId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass33_1
	{
		public int UserId;

		public _003C_003Ec__DisplayClass33_0 CS_0024_003C_003E8__locals1;

		internal bool _003CEditObjectDoc_003Eb__1(EditAfterFixInfoViewModel x)
		{
			if (x.eafUserId == UserId && x.eafModeId == CS_0024_003C_003E8__locals1.modeId && x.eafWorkflowReqId == CS_0024_003C_003E8__locals1.wfReqId)
			{
				return x.eafWorkflowStepId == CS_0024_003C_003E8__locals1.wfStepId;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass34_0
	{
		public int? modeId;

		public int? wfReqId;

		public int? wfStepId;

		public int objId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass34_1
	{
		public int UserId;

		public _003C_003Ec__DisplayClass34_0 CS_0024_003C_003E8__locals1;

		internal bool _003CEditObjectDraft_003Eb__1(EditAfterFixInfoViewModel x)
		{
			if (x.eafUserId == UserId && x.eafModeId == CS_0024_003C_003E8__locals1.modeId && x.eafWorkflowReqId == CS_0024_003C_003E8__locals1.wfReqId)
			{
				return x.eafWorkflowStepId == CS_0024_003C_003E8__locals1.wfStepId;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass35_0
	{
		public int? modeId;

		public int? wfReqId;

		public int? wfStepId;

		public int objId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass35_1
	{
		public int UserId;

		public _003C_003Ec__DisplayClass35_0 CS_0024_003C_003E8__locals1;

		internal bool _003CEditObjectMovement_003Eb__1(EditAfterFixInfoViewModel x)
		{
			if (x.eafUserId == UserId && x.eafModeId == CS_0024_003C_003E8__locals1.modeId && x.eafWorkflowReqId == CS_0024_003C_003E8__locals1.wfReqId)
			{
				return x.eafWorkflowStepId == CS_0024_003C_003E8__locals1.wfStepId;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass36_0
	{
		public int? modeId;

		public int? wfReqId;

		public int? wfStepId;

		public int objId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass36_1
	{
		public int UserId;

		public _003C_003Ec__DisplayClass36_0 CS_0024_003C_003E8__locals1;

		internal bool _003CEditObjectSendLetter_003Eb__1(EditAfterFixInfoViewModel x)
		{
			if (x.eafUserId == UserId && x.eafModeId == CS_0024_003C_003E8__locals1.modeId && x.eafWorkflowReqId == CS_0024_003C_003E8__locals1.wfReqId)
			{
				return x.eafWorkflowStepId == CS_0024_003C_003E8__locals1.wfStepId;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass37_0
	{
		public int? modeId;

		public int? wfReqId;

		public int? wfStepId;

		public int objId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass37_1
	{
		public int UserId;

		public _003C_003Ec__DisplayClass37_0 CS_0024_003C_003E8__locals1;

		internal bool _003CEditObjectReceiveLetter_003Eb__1(EditAfterFixInfoViewModel x)
		{
			if (x.eafUserId == UserId && x.eafModeId == CS_0024_003C_003E8__locals1.modeId && x.eafWorkflowReqId == CS_0024_003C_003E8__locals1.wfReqId)
			{
				return x.eafWorkflowStepId == CS_0024_003C_003E8__locals1.wfStepId;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass38_0
	{
		public int? modeId;

		public int? wfReqId;

		public int? wfStepId;

		public int objId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass38_1
	{
		public int UserId;

		public _003C_003Ec__DisplayClass38_0 CS_0024_003C_003E8__locals1;

		internal bool _003CEditObjectDyForm_003Eb__1(EditAfterFixInfoViewModel x)
		{
			if (x.eafUserId == UserId && x.eafModeId == CS_0024_003C_003E8__locals1.modeId && x.eafWorkflowReqId == CS_0024_003C_003E8__locals1.wfReqId)
			{
				return x.eafWorkflowStepId == CS_0024_003C_003E8__locals1.wfStepId;
			}
			return false;
		}
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[LoginAuthorize]
	public ActionResult Index(int objectId = 0, int objectType = 0, int workflowId = 0, int position = 0, string formName = "", int? msgId = 0)
	{
		if (CheckFormAction(formName))
		{
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		base.ViewBag.ObjectId = objectId;
		base.ViewBag.ObjectType = objectType;
		base.ViewBag.WorkflowId = workflowId;
		base.ViewBag.Position = position;
		base.ViewBag.FormName = formName;
		base.ViewBag.Mode = 0;
		base.ViewBag.SequenceObservation = false;
		base.ViewBag.MsgId = msgId;
		return View();
	}

	[LoginAuthorize]
	public ActionResult _PartialVerifyWorkflow(int objectId = 0, int objectType = 0, int workflowId = 0, int position = 0, string formName = "", int? msgId = 0, int requestId = 0, bool noLoad = false)
	{
		if (CheckFormAction(formName))
		{
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		base.ViewBag.ObjectId = objectId;
		base.ViewBag.ObjectType = objectType;
		base.ViewBag.WorkflowId = workflowId;
		base.ViewBag.Position = position;
		base.ViewBag.FormName = formName;
		base.ViewBag.Mode = 0;
		base.ViewBag.SequenceObservation = false;
		base.ViewBag.MsgId = msgId;
		base.ViewBag.NoLoad = noLoad;
		return PartialView();
	}

	[LoginAuthorize]
	public ActionResult History(int objectId = 0, int objectType = 0)
	{
		base.ViewBag.RequestsList = JsonConvert.SerializeObject(GetVerificationRequest(0, objectType, objectId));
		base.ViewBag.ObjectId = objectId;
		base.ViewBag.ObjectType = objectType;
		return View();
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetRequestDetails(int objectType = 0, int objectId = 0, int verificationRequestId = 0, int workflowId = 0)
	{
		VerificationWorkflowViewModel verificationWorkflowViewModel = new VerificationWorkflowViewModel();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int result2 = 0;
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (currentUser != null)
		{
			int.TryParse(currentUser.UserLastCId.ToString(), out result2);
		}
		if (verificationRequestId == 0)
		{
			WSspSelectVerificationRequests_Result wSspSelectVerificationRequests_Result = Enumerable.FirstOrDefault<WSspSelectVerificationRequests_Result>((IEnumerable<WSspSelectVerificationRequests_Result>)_db.WSspSelectVerificationRequests(0, objectId, objectType, lCID, result));
			if (wSspSelectVerificationRequests_Result != null)
			{
				if (verificationRequestId == 0)
				{
					verificationRequestId = wSspSelectVerificationRequests_Result.VerificationRequestId;
				}
				if (workflowId == 0)
				{
					workflowId = wSspSelectVerificationRequests_Result.VerificationWorkFlowId;
				}
			}
		}
		verificationWorkflowViewModel.ObjectId = objectId;
		verificationWorkflowViewModel.ObjectTypeId = objectType;
		verificationWorkflowViewModel.Workflow = GetVerificationWorkFlowWithId(workflowId);
		verificationWorkflowViewModel.WorkFlowSteps = GetVerificationWorkFlowSteps(workflowId);
		verificationWorkflowViewModel.VerificationRequest = Enumerable.FirstOrDefault<WSspSelectVerificationRequests_Result>((IEnumerable<WSspSelectVerificationRequests_Result>)GetVerificationRequest(verificationRequestId));
		verificationWorkflowViewModel.VerificationRequestDetails = GetVerificationRequestsByReqId(verificationRequestId);
		int? num = 0;
		int? num2 = 0;
		switch (objectType)
		{
		case 90:
		case 100:
		{
			CRMspSelectLeave_Result cRMspSelectLeave_Result = Enumerable.FirstOrDefault<CRMspSelectLeave_Result>((IEnumerable<CRMspSelectLeave_Result>)_dbI.CRMspSelectLeave(0, objectId, null, null, null, null, lCID, result, null, result2));
			if (cRMspSelectLeave_Result != null)
			{
				cRMspSelectLeave_Result.ReplaceUserVerifiedDatePersian = cRMspSelectLeave_Result.ReplaceUserVerifiedDate?.ToString("yyyy/MM/dd HH:mm");
				cRMspSelectLeave_Result.CanceledDatePersian = cRMspSelectLeave_Result.CanceledDate?.ToString("yyyy/MM/dd HH:mm");
				cRMspSelectLeave_Result.FirstRegisterDatePersian = cRMspSelectLeave_Result.FirstRegisterDate?.ToString("yyyy/MM/dd HH:mm");
				cRMspSelectLeave_Result.FromDate = cRMspSelectLeave_Result.FromDateTime?.ToString("yyyy/MM/dd HH:mm");
				cRMspSelectLeave_Result.ToDate = cRMspSelectLeave_Result.ToDateTime?.ToString("yyyy/MM/dd HH:mm");
				cRMspSelectLeave_Result.VerifiedRegisterDatePersian = cRMspSelectLeave_Result.VerifiedRegisterDate?.ToString("yyyy/MM/dd HH:mm");
				verificationWorkflowViewModel.FirstRegisterUserId = cRMspSelectLeave_Result.FirstRegisterUserId;
				verificationWorkflowViewModel.FirstRegisterUserName = cRMspSelectLeave_Result.FirstRegisterUser;
				verificationWorkflowViewModel.ReplaceUserId = cRMspSelectLeave_Result.ReplaceUserId;
				verificationWorkflowViewModel.ReplaceUser = cRMspSelectLeave_Result.ReplaceUser;
				verificationWorkflowViewModel.ReplaceUserIsVerified = cRMspSelectLeave_Result.ReplaceUserIsVerified;
				verificationWorkflowViewModel.ReplaceUserIsVerifiedDate = cRMspSelectLeave_Result.ReplaceUserVerifiedDatePersian;
				verificationWorkflowViewModel.ReplaceUserIsVerifiedDateI = cRMspSelectLeave_Result.ReplaceUserVerifiedDate?.ToString("dddd dd MMMM yyyy");
				verificationWorkflowViewModel.ReplaceUserIntMsgId = cRMspSelectLeave_Result.ReplaceUserIntMsgId;
				num = cRMspSelectLeave_Result.RequestUserId;
				verificationWorkflowViewModel.FirstRegisterDate = cRMspSelectLeave_Result.FirstRegisterDate ?? DateTime.Now;
				verificationWorkflowViewModel.FirstRegisterDatePersian = cRMspSelectLeave_Result.FirstRegisterDate?.ToString("yyyy/MM/dd HH:mm");
				verificationWorkflowViewModel.IsCanceled = cRMspSelectLeave_Result.IsCanceled;
				verificationWorkflowViewModel.CancelerUserId = cRMspSelectLeave_Result.CancelerUserId;
				verificationWorkflowViewModel.CancelerUser = cRMspSelectLeave_Result.CancelerUser;
				verificationWorkflowViewModel.CanceledDate = cRMspSelectLeave_Result.CanceledDate;
				verificationWorkflowViewModel.CanceledDatePersian = cRMspSelectLeave_Result.CanceledDate?.ToString("yyyy/MM/dd HH:mm");
			}
			break;
		}
		case 10:
		{
			WSspSelectPreOrderWithId_Result wSspSelectPreOrderWithId_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)_db.WSspSelectPreOrderWithId(objectId, lCID, result));
			if (wSspSelectPreOrderWithId_Result != null)
			{
				verificationWorkflowViewModel.SellerUserId = wSspSelectPreOrderWithId_Result.pordSellerId;
				verificationWorkflowViewModel.SellerUserName = wSspSelectPreOrderWithId_Result.pordSeller;
				verificationWorkflowViewModel.ReferUserId = wSspSelectPreOrderWithId_Result.pordReferUserId;
				verificationWorkflowViewModel.ReferUserName = wSspSelectPreOrderWithId_Result.pordReferUser;
				verificationWorkflowViewModel.FirstRegisterUserId = wSspSelectPreOrderWithId_Result.FirstRegisterUserId;
				verificationWorkflowViewModel.FirstRegisterUserName = wSspSelectPreOrderWithId_Result.FirstRegisterUser;
				num = wSspSelectPreOrderWithId_Result.FirstRegisterUserId;
				num2 = wSspSelectPreOrderWithId_Result.pordCompanyId;
				verificationWorkflowViewModel.FirstRegisterDate = wSspSelectPreOrderWithId_Result.FirstRegisterDate ?? DateTime.Now;
				verificationWorkflowViewModel.FirstRegisterDatePersian = wSspSelectPreOrderWithId_Result.FirstRegisterDate?.ToString("yyyy/MM/dd HH:mm");
				verificationWorkflowViewModel.SaleCenterReferUserId = wSspSelectPreOrderWithId_Result.pordSaleCenterReferUserId;
				verificationWorkflowViewModel.SaleCenterReferUserName = wSspSelectPreOrderWithId_Result.pordSaleCenterReferUser;
				if (!UserLogin.IsUserAccess("frmPreOrder", "actVerifyAfterExp", currentUser) && ((wSspSelectPreOrderWithId_Result.pordExpireDateTime.HasValue && wSspSelectPreOrderWithId_Result.pordExpireDateTime?.Date < DateTime.Now.Date) || wSspSelectPreOrderWithId_Result.pordStatusId.GetValueOrDefault() == 4))
				{
					verificationWorkflowViewModel.UnableToStart = true;
					verificationWorkflowViewModel.UnableToStartReason = Messages.msgUnableStartVerificationWorkflowCausePreOrderExpired;
				}
			}
			break;
		}
		case 20:
		{
			WSspSelectOrderById_Result wSspSelectOrderById_Result = Enumerable.FirstOrDefault<WSspSelectOrderById_Result>((IEnumerable<WSspSelectOrderById_Result>)_db.WSspSelectOrderById(objectId, lCID, result));
			if (wSspSelectOrderById_Result != null)
			{
				verificationWorkflowViewModel.SellerUserId = wSspSelectOrderById_Result.ordSellerId;
				verificationWorkflowViewModel.SellerUserName = wSspSelectOrderById_Result.ordSeller;
				verificationWorkflowViewModel.ReferUserId = wSspSelectOrderById_Result.ordReferUserId;
				verificationWorkflowViewModel.ReferUserName = wSspSelectOrderById_Result.ordReferUser;
				verificationWorkflowViewModel.FirstRegisterUserId = wSspSelectOrderById_Result.FirstRegisterUserId;
				verificationWorkflowViewModel.FirstRegisterUserName = wSspSelectOrderById_Result.FirstRegisterUser;
				num = wSspSelectOrderById_Result.FirstRegisterUserId;
				verificationWorkflowViewModel.FirstRegisterDate = wSspSelectOrderById_Result.FirstRegisterDate ?? DateTime.Now;
				verificationWorkflowViewModel.FirstRegisterDatePersian = wSspSelectOrderById_Result.FirstRegisterDate?.ToString("yyyy/MM/dd HH:mm");
				verificationWorkflowViewModel.SaleCenterReferUserId = wSspSelectOrderById_Result.ordSaleCenterReferUserId;
				verificationWorkflowViewModel.SaleCenterReferUserName = wSspSelectOrderById_Result.ordSaleCenterReferUser;
				num2 = wSspSelectOrderById_Result.ordCompanyId;
				if (!UserLogin.IsUserAccess("frmOrder", "actVerifyAfterCancel", currentUser) && wSspSelectOrderById_Result.ordStatusId.GetValueOrDefault() == 4)
				{
					verificationWorkflowViewModel.UnableToStart = true;
					verificationWorkflowViewModel.UnableToStartReason = "msgUnableStartVerificationWorkflowCauseOrderCanceled".OrderMessages();
				}
			}
			break;
		}
		case 40:
		{
			WSspSelectBuyOrderById_Result wSspSelectBuyOrderById_Result = Enumerable.FirstOrDefault<WSspSelectBuyOrderById_Result>((IEnumerable<WSspSelectBuyOrderById_Result>)_dbII.WSspSelectBuyOrderById(objectId, lCID, result));
			if (wSspSelectBuyOrderById_Result != null)
			{
				verificationWorkflowViewModel.ReferUserId = wSspSelectBuyOrderById_Result.bordReferUserId;
				verificationWorkflowViewModel.ReferUserName = wSspSelectBuyOrderById_Result.bordReferUser;
				verificationWorkflowViewModel.FirstRegisterUserId = wSspSelectBuyOrderById_Result.FirstRegisterUserId;
				verificationWorkflowViewModel.FirstRegisterUserName = wSspSelectBuyOrderById_Result.FirstRegisterUser;
				num = wSspSelectBuyOrderById_Result.FirstRegisterUserId;
				verificationWorkflowViewModel.FirstRegisterDate = wSspSelectBuyOrderById_Result.FirstRegisterDate ?? DateTime.Now;
				verificationWorkflowViewModel.FirstRegisterDatePersian = wSspSelectBuyOrderById_Result.FirstRegisterDate?.ToString("yyyy/MM/dd HH:mm");
				num2 = wSspSelectBuyOrderById_Result.bordCompanyId;
				if (!UserLogin.IsUserAccess("frmBuyOrder", "actVerifyAfterCancel", currentUser) && (wSspSelectBuyOrderById_Result.bordStatusId.GetValueOrDefault() == 4 || wSspSelectBuyOrderById_Result.bordStatusId.GetValueOrDefault() == 5))
				{
					verificationWorkflowViewModel.UnableToStart = true;
					verificationWorkflowViewModel.UnableToStartReason = Messages.msgUnableStartVerificationWorkflowCauseBuyOrderCanceled;
				}
			}
			break;
		}
		case 45:
		{
			WSspSelectStockSupplyById_Result wSspSelectStockSupplyById_Result = Enumerable.FirstOrDefault<WSspSelectStockSupplyById_Result>((IEnumerable<WSspSelectStockSupplyById_Result>)_dbII.WSspSelectStockSupplyById(objectId, lCID, result));
			if (wSspSelectStockSupplyById_Result != null)
			{
				verificationWorkflowViewModel.SupReferUserId = wSspSelectStockSupplyById_Result.stsupReferUserId;
				verificationWorkflowViewModel.SupReferUserName = wSspSelectStockSupplyById_Result.stsupReferUser;
				verificationWorkflowViewModel.FirstRegisterUserId = wSspSelectStockSupplyById_Result.FirstRegisterUserId;
				verificationWorkflowViewModel.FirstRegisterUserName = wSspSelectStockSupplyById_Result.FirstRegisterUser;
				num2 = wSspSelectStockSupplyById_Result.stsupCompanyId;
				num = wSspSelectStockSupplyById_Result.FirstRegisterUserId;
				verificationWorkflowViewModel.FirstRegisterDate = wSspSelectStockSupplyById_Result.FirstRegisterDate;
				verificationWorkflowViewModel.FirstRegisterDatePersian = wSspSelectStockSupplyById_Result.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm");
			}
			break;
		}
		case 60:
		{
			WSspSelectDocById_Result wSspSelectDocById_Result = Enumerable.FirstOrDefault<WSspSelectDocById_Result>((IEnumerable<WSspSelectDocById_Result>)_dbI.WSspSelectDocById(objectId, lCID, result));
			if (wSspSelectDocById_Result != null)
			{
				verificationWorkflowViewModel.FirstRegisterUserId = wSspSelectDocById_Result.FirstRegisterUserId;
				verificationWorkflowViewModel.FirstRegisterUserName = wSspSelectDocById_Result.FirstRegisterUser;
				verificationWorkflowViewModel.FirstRegisterDate = wSspSelectDocById_Result.FirstRegisterDate ?? DateTime.Now;
				verificationWorkflowViewModel.FirstRegisterDatePersian = wSspSelectDocById_Result.FirstRegisterDate?.ToString("yyyy/MM/dd HH:mm");
			}
			break;
		}
		case 80:
		{
			CRMspDySelectFormFieldMasterValueWithId_Result cRMspDySelectFormFieldMasterValueWithId_Result = Enumerable.FirstOrDefault<CRMspDySelectFormFieldMasterValueWithId_Result>((IEnumerable<CRMspDySelectFormFieldMasterValueWithId_Result>)_db.CRMspDySelectFormFieldMasterValueWithId(objectId, lCID, result));
			if (cRMspDySelectFormFieldMasterValueWithId_Result != null)
			{
				verificationWorkflowViewModel.FirstRegisterUserId = cRMspDySelectFormFieldMasterValueWithId_Result.FirstRegisterUserId;
				verificationWorkflowViewModel.FirstRegisterUserName = cRMspDySelectFormFieldMasterValueWithId_Result.FirstRegisterUser;
				num = cRMspDySelectFormFieldMasterValueWithId_Result.FirstRegisterUserId;
				verificationWorkflowViewModel.FirstRegisterDate = cRMspDySelectFormFieldMasterValueWithId_Result.FirstRegisterDate;
				verificationWorkflowViewModel.FirstRegisterDatePersian = cRMspDySelectFormFieldMasterValueWithId_Result.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm");
			}
			break;
		}
		case 110:
		{
			SecspSelectLettersById_Result secspSelectLettersById_Result = Enumerable.FirstOrDefault<SecspSelectLettersById_Result>((IEnumerable<SecspSelectLettersById_Result>)_dbII.SecspSelectLettersById(objectId, lCID, result));
			if (secspSelectLettersById_Result != null)
			{
				verificationWorkflowViewModel.FirstRegisterUserId = secspSelectLettersById_Result.FirstRegisterUserId;
				verificationWorkflowViewModel.FirstRegisterUserName = secspSelectLettersById_Result.FirstRegisterUser;
				num = secspSelectLettersById_Result.FirstRegisterUserId;
				verificationWorkflowViewModel.FirstRegisterDate = secspSelectLettersById_Result.FirstRegisterDate;
				verificationWorkflowViewModel.FirstRegisterDatePersian = secspSelectLettersById_Result.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm");
				num2 = secspSelectLettersById_Result.LetterCompanyId;
			}
			break;
		}
		case 130:
		{
			CRMspSelectFund_Result cRMspSelectFund_Result = Enumerable.FirstOrDefault<CRMspSelectFund_Result>((IEnumerable<CRMspSelectFund_Result>)_db.CRMspSelectFund(null, objectId, UserLogin.CurrentUser.UserId, null, null, null, lCID, result));
			if (cRMspSelectFund_Result != null)
			{
				verificationWorkflowViewModel.FirstRegisterUserId = cRMspSelectFund_Result.FirstRegisterUserId;
				verificationWorkflowViewModel.FirstRegisterUserName = cRMspSelectFund_Result.FirstRegisterUser;
				num = cRMspSelectFund_Result.FirstRegisterUserId;
				verificationWorkflowViewModel.FirstRegisterDate = cRMspSelectFund_Result.FirstRegisterDate;
				verificationWorkflowViewModel.FirstRegisterDatePersian = cRMspSelectFund_Result.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm");
			}
			break;
		}
		}
		if (num.GetValueOrDefault() != 0)
		{
			CRMspSelectUsersById_Result cRMspSelectUsersById_Result = CRMIdeal.Classes.Helper.User.SelectUsersById(num.GetValueOrDefault());
			if (cRMspSelectUsersById_Result != null)
			{
				verificationWorkflowViewModel.ResponsibleUserId = cRMspSelectUsersById_Result.ResponsibleUserId;
				verificationWorkflowViewModel.ResponsibleUserName = cRMspSelectUsersById_Result.ResponsibleUser;
			}
		}
		if (num2.GetValueOrDefault() != 0)
		{
			CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(num2.GetValueOrDefault());
			if (companyById != null)
			{
				verificationWorkflowViewModel.CmpReferUserId = companyById.cmpReferUserId;
				verificationWorkflowViewModel.CmpReferUserName = companyById.ReferUser;
				verificationWorkflowViewModel.CmpSuppUserId = companyById.cmpSuppUserId;
				verificationWorkflowViewModel.CmpSuppUserName = companyById.cmpSuppUser;
			}
		}
		return JsonConvert.SerializeObject(verificationWorkflowViewModel);
	}

	public string Verify()
	{
		return "";
	}

	[HttpPost]
	[LoginAuthorize]
	public WSspSelectVerificationWorkFlowWithId_Result GetVerificationWorkFlowWithId(int workflowId = 0)
	{
		WSspSelectVerificationWorkFlowWithId_Result result = new WSspSelectVerificationWorkFlowWithId_Result();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			WSspSelectVerificationWorkFlowWithId_Result wSspSelectVerificationWorkFlowWithId_Result = Enumerable.FirstOrDefault<WSspSelectVerificationWorkFlowWithId_Result>((IEnumerable<WSspSelectVerificationWorkFlowWithId_Result>)_db.WSspSelectVerificationWorkFlowWithId(workflowId, lCID, result2));
			if (wSspSelectVerificationWorkFlowWithId_Result != null)
			{
				wSspSelectVerificationWorkFlowWithId_Result.FirstRegisterDatePersian = wSspSelectVerificationWorkFlowWithId_Result.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm");
				wSspSelectVerificationWorkFlowWithId_Result.RegisterDatePersian = wSspSelectVerificationWorkFlowWithId_Result.RegisterDate.ToString("yyyy/MM/dd HH:mm");
				result = wSspSelectVerificationWorkFlowWithId_Result;
			}
		}
		catch (DbEntityValidationException ex)
		{
			Public.InsExceptToElmah((Exception)(object)ex);
		}
		catch (Exception ex2)
		{
			Public.InsExceptToElmah(ex2);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public List<WSspSelectVerificationWorkFlowSteps_Result> GetVerificationWorkFlowSteps(int workflowId = 0)
	{
		List<WSspSelectVerificationWorkFlowSteps_Result> result = new List<WSspSelectVerificationWorkFlowSteps_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectVerificationWorkFlowSteps_Result> list = Enumerable.ToList<WSspSelectVerificationWorkFlowSteps_Result>((IEnumerable<WSspSelectVerificationWorkFlowSteps_Result>)_db.WSspSelectVerificationWorkFlowSteps(workflowId, lCID, result2));
			if (list != null)
			{
				foreach (WSspSelectVerificationWorkFlowSteps_Result item in list)
				{
					item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm");
					item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd HH:mm");
				}
				result = list;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public List<WSspSelectVerificationRequests_Result> GetVerificationRequest(int verificationRequestId = 0, int objectType = 0, int objectId = 0)
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
			List<WSspSelectVerificationRequests_Result> list = Enumerable.ToList<WSspSelectVerificationRequests_Result>((IEnumerable<WSspSelectVerificationRequests_Result>)_db.WSspSelectVerificationRequests(verificationRequestId, objectId, objectType, lCID, result2));
			if (list != null)
			{
				foreach (WSspSelectVerificationRequests_Result item in list)
				{
					item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm");
					item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd HH:mm");
					item.ReplaceUserVerifiedDatePersian = item.ReplaceUserVerifiedDate?.ToString("yyyy/MM/dd HH:mm");
					item.VerificationReqExpiredDatePersian = item.VerificationReqExpiredDateTime?.ToString("yyyy/MM/dd HH:mm");
				}
				result = list;
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
	public List<WSspSelectVerificationRequestsByReqId_Result> GetVerificationRequestsByReqId(int requestId = 0)
	{
		List<WSspSelectVerificationRequestsByReqId_Result> result = new List<WSspSelectVerificationRequestsByReqId_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectVerificationRequestsByReqId_Result> list = Enumerable.ToList<WSspSelectVerificationRequestsByReqId_Result>((IEnumerable<WSspSelectVerificationRequestsByReqId_Result>)_dbII.WSspSelectVerificationRequestsByReqId(requestId, lCID, result2));
			if (list != null)
			{
				foreach (WSspSelectVerificationRequestsByReqId_Result item in list)
				{
					item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm");
					item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd HH:mm");
					item.VerifyDateTimePersian = item.VerifyDateTime?.ToString("yyyy/MM/dd HH:mm");
				}
				result = list;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public List<WSspSelectVerificationRequestDetails_Result> GetVerificationRequestDetails(int verificationRequestDetailId = 0, int verificationRequestId = 0, int verificationWorkFlowId = 0)
	{
		List<WSspSelectVerificationRequestDetails_Result> result = new List<WSspSelectVerificationRequestDetails_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			List<WSspSelectVerificationRequestDetails_Result> list = Enumerable.ToList<WSspSelectVerificationRequestDetails_Result>((IEnumerable<WSspSelectVerificationRequestDetails_Result>)_db.WSspSelectVerificationRequestDetails(verificationRequestDetailId, verificationRequestId, verificationWorkFlowId, lCID, result2, result3));
			if (list != null)
			{
				foreach (WSspSelectVerificationRequestDetails_Result item in list)
				{
					item.FirstRegisterDatePersian = item.FirstRegisterDate?.ToString("yyyy/MM/dd HH:mm");
					item.RegisterDatePersian = item.RegisterDate?.ToString("yyyy/MM/dd HH:mm");
					item.VerifyDateTimePersian = item.VerifyDateTime?.ToString("yyyy/MM/dd HH:mm");
				}
				result = list;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[AjaxOnly]
	[HttpPost]
	public string Verify(WSVerificationRequestsLanguageViewModel vm)
	{
		return "";
	}

	public bool CheckFormAction(string formName = "")
	{
		bool result = false;
		try
		{
			string text = "";
			string text2 = "";
			if (!string.IsNullOrEmpty(formName))
			{
				switch (formName)
				{
				case "PORD":
					text = "frmPreOrder";
					text2 = "actVerifyWithWorkflow";
					break;
				case "ORD":
					text = "frmOrder";
					text2 = "actVerifyWithWorkflow";
					break;
				case "DyFrm":
					text = "frmDyForm";
					text2 = "actCheckWithWorkflow";
					break;
				case "DOC":
					text = "frmDoc";
					text2 = "actVerifyWithWorkflow";
					break;
				case "DRAFT":
					text = "frmDraft";
					text2 = "actVerifyWithWorkflow";
					break;
				case "MOVEMENTWRHS":
					text = "frmWareHouseMovement";
					text2 = "actVerifyWithWorkflow";
					break;
				case "LEAVE":
					text = "frmLeave";
					text2 = "actVerifyRequest";
					text2 = "actLeaveDetails";
					break;
				case "MISSION":
					text = "frmMission";
					text = "frmLeave";
					text2 = "actVerifyRequest";
					text2 = "actMissionDetails";
					break;
				case "BORD":
					text = "frmBuyOrder";
					text2 = "actVerifyWithWorkflow";
					break;
				case "STSUP":
					text = "frmStockSupply";
					text2 = "actVerifyWithWorkflow";
					break;
				case "SENDLTR":
					text = "frmSendLetters";
					text2 = "actVerifyWithWorkflow";
					break;
				case "RECIEVELTR":
					text = "frmReceiveLetters";
					text2 = "actVerifyWithWorkflow";
					break;
				case "FUND":
					text = "frmFund";
					text2 = "actVerifyFund";
					break;
				}
			}
			if (text != "" && text2 != "")
			{
				result = !UserLogin.IsUserAccess(text, text2, UserLogin.CurrentUser);
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	public bool SendMessage(int fromUserId, int toUserId, int msgTypeId, string subject, string message, List<CommonMultiLanguageViewModel> msglist, int objectId, int? workflowStepId = null, List<CommonMultiLanguageViewModel> sublist = null)
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
		return Enumerable.ToList<SelectListItem>(Enumerable.Select<WSspSelectVerificationRequests_Result, SelectListItem>((IEnumerable<WSspSelectVerificationRequests_Result>)SelectVerificationRequests(objectId, objectType), (Func<WSspSelectVerificationRequests_Result, SelectListItem>)((WSspSelectVerificationRequests_Result x) => new SelectListItem
		{
			Text = x.VerificationWorkFlowTitle,
			Value = x.VerificationRequestId.ToString(),
			Selected = false
		})));
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
				_003C_003Ec__DisplayClass22_1 _003C_003Ec__DisplayClass22_ = new _003C_003Ec__DisplayClass22_1();
				_003C_003Ec__DisplayClass22_.item = enumerator.Current;
				_003C_003Ec__DisplayClass22_.item.AppType = (_003C_003Ec__DisplayClass22_.item.VerifyDateTime.HasValue ? _003C_003Ec__DisplayClass22_.item.VerifyDateTime.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
				if (_003C_003Ec__DisplayClass22_.item.VerificationRequestDetailId.HasValue && _003C_003Ec__DisplayClass22_.item.VerificationRequestDetailId > 0)
				{
					DbSet<WSVerificationRequestDetails_Lang> wSVerificationRequestDetails_Lang = _dbTbl.WSVerificationRequestDetails_Lang;
					ParameterExpression val = Expression.Parameter(typeof(WSVerificationRequestDetails_Lang), "c");
					List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSVerificationRequestDetails_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSVerificationRequestDetails_Lang>)Enumerable.ToList<WSVerificationRequestDetails_Lang>((IEnumerable<WSVerificationRequestDetails_Lang>)Queryable.Where<WSVerificationRequestDetails_Lang>((IQueryable<WSVerificationRequestDetails_Lang>)wSVerificationRequestDetails_Lang, Expression.Lambda<Func<WSVerificationRequestDetails_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Convert((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), typeof(int?)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass22_, typeof(_003C_003Ec__DisplayClass22_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }))), (Func<WSVerificationRequestDetails_Lang, CommonMultiLanguageViewModel>)((WSVerificationRequestDetails_Lang item1) => new CommonMultiLanguageViewModel
					{
						Value = item1.VerifyText,
						LanguageId = item1.LanguageID
					})));
					list2.Add(new CommonMultiLanguageViewModel
					{
						Value = _003C_003Ec__DisplayClass22_.item.VerifyText,
						LanguageId = result
					});
					_003C_003Ec__DisplayClass22_.item.VerifyText = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
					_003C_003Ec__DisplayClass22_.item.EditUser = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
				}
				else
				{
					DbSet<WSVerificationWorkFlowSteps_Lang> wSVerificationWorkFlowSteps_Lang = _dbTbl.WSVerificationWorkFlowSteps_Lang;
					ParameterExpression val = Expression.Parameter(typeof(WSVerificationWorkFlowSteps_Lang), "c");
					List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSVerificationWorkFlowSteps_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSVerificationWorkFlowSteps_Lang>)Enumerable.ToList<WSVerificationWorkFlowSteps_Lang>((IEnumerable<WSVerificationWorkFlowSteps_Lang>)Queryable.Where<WSVerificationWorkFlowSteps_Lang>((IQueryable<WSVerificationWorkFlowSteps_Lang>)wSVerificationWorkFlowSteps_Lang, Expression.Lambda<Func<WSVerificationWorkFlowSteps_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Convert((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), typeof(int?)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass22_, typeof(_003C_003Ec__DisplayClass22_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }))), (Func<WSVerificationWorkFlowSteps_Lang, CommonMultiLanguageViewModel>)((WSVerificationWorkFlowSteps_Lang item1) => new CommonMultiLanguageViewModel
					{
						Value = item1.VerifyText,
						LanguageId = item1.LanguageID
					})));
					list3.Add(new CommonMultiLanguageViewModel
					{
						Value = _003C_003Ec__DisplayClass22_.item.VerifyText,
						LanguageId = result
					});
					_003C_003Ec__DisplayClass22_.item.VerifyText = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
					_003C_003Ec__DisplayClass22_.item.EditUser = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
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
						SendMessage(userId, result2, msgTypeId, resourceString, message, list, leaveReplaceUserVerificationRequestLanguageViewModel.LeaveId, workflowStepId, list2);
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
							Verify(wSVerificationRequestsLanguageViewModel);
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
							SendMessage(userId, result2, msgTypeId, subject, message, list3, leaveReplaceUserVerificationRequestLanguageViewModel.LeaveId, num2, list2);
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

	[HttpPost]
	[LoginAuthorize]
	public string EditObjectOrder(int objId = 0, int? wfReqId = null, int? wfId = null, int? wfStepId = null, int? modeId = null)
	{
		_003C_003Ec__DisplayClass30_0 _003C_003Ec__DisplayClass30_ = new _003C_003Ec__DisplayClass30_0();
		_003C_003Ec__DisplayClass30_.modeId = modeId;
		_003C_003Ec__DisplayClass30_.wfReqId = wfReqId;
		_003C_003Ec__DisplayClass30_.wfStepId = wfStepId;
		_003C_003Ec__DisplayClass30_.objId = objId;
		List<SelectListItem> list = new List<SelectListItem>();
		_003C_003Ec__DisplayClass30_.modeId = _003C_003Ec__DisplayClass30_.modeId.GetValueOrDefault(1);
		try
		{
			_003C_003Ec__DisplayClass30_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass30_1();
			CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass30_;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			CS_0024_003C_003E8__locals0.UserId = UserLogin.CurrentUser.UserId;
			List<EditAfterFixInfoViewModel> list2 = new List<EditAfterFixInfoViewModel>();
			WSspSelectOrderById_Result wSspSelectOrderById_Result = Enumerable.FirstOrDefault<WSspSelectOrderById_Result>((IEnumerable<WSspSelectOrderById_Result>)_db.WSspSelectOrderById(CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.objId, lCID, result));
			if (wSspSelectOrderById_Result != null)
			{
				if (!string.IsNullOrWhiteSpace((wSspSelectOrderById_Result.ordEditAfterFixInfoJs ?? "").Replace("[]", "")))
				{
					list2 = JsonConvert.DeserializeObject<List<EditAfterFixInfoViewModel>>(wSspSelectOrderById_Result.ordEditAfterFixInfoJs);
				}
				int num = Enumerable.ToList<EditAfterFixInfoViewModel>(Enumerable.Where<EditAfterFixInfoViewModel>((IEnumerable<EditAfterFixInfoViewModel>)list2, (Func<EditAfterFixInfoViewModel, bool>)((EditAfterFixInfoViewModel x) => !x.eafEndDate.HasValue || x.eafEndDate <= DateTime.Now))).FindIndex((EditAfterFixInfoViewModel x) => x.eafUserId == CS_0024_003C_003E8__locals0.UserId && x.eafModeId == CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.modeId && x.eafWorkflowReqId == CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.wfReqId && x.eafWorkflowStepId == CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.wfStepId);
				if (num == -1)
				{
					string eafID = System.Guid.NewGuid().ToString();
					EditAfterFixInfoViewModel editAfterFixInfoViewModel = new EditAfterFixInfoViewModel();
					editAfterFixInfoViewModel.eafID = eafID;
					editAfterFixInfoViewModel.eafModeId = CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.modeId.GetValueOrDefault();
					editAfterFixInfoViewModel.eafUserId = CS_0024_003C_003E8__locals0.UserId;
					editAfterFixInfoViewModel.eafWorkflowId = wfId;
					editAfterFixInfoViewModel.eafWorkflowReqId = CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.wfReqId;
					editAfterFixInfoViewModel.eafWorkflowStepId = CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.wfStepId;
					editAfterFixInfoViewModel.eafRequestDate = DateTime.Now;
					list2.Add(editAfterFixInfoViewModel);
					DbSet<WSOrder> wSOrder = _dbTbl.WSOrder;
					ParameterExpression val = Expression.Parameter(typeof(WSOrder), "x");
					WSOrder wSOrder2 = Queryable.FirstOrDefault<WSOrder>((IQueryable<WSOrder>)wSOrder, Expression.Lambda<Func<WSOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass30_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					if (wSOrder2 != null)
					{
						wSOrder2.ordEditAfterFixInfoJs = JsonConvert.SerializeObject(list2);
						_dbTbl.Entry(wSOrder2).State = EntityState.Modified;
						_dbTbl.Configuration.ValidateOnSaveEnabled = false;
						_dbTbl.SaveChanges();
						_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					}
					list.Add(new SelectListItem
					{
						Text = "Data",
						Value = JsonConvert.SerializeObject(editAfterFixInfoViewModel)
					});
				}
				else
				{
					list.Add(new SelectListItem
					{
						Text = "Data",
						Value = JsonConvert.SerializeObject(list2[num])
					});
				}
			}
			else
			{
				list.Add(new SelectListItem
				{
					Text = "Error",
					Value = Messages.msgErrorOrderNotFound
				});
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			list.Add(new SelectListItem
			{
				Text = "Error",
				Value = "Error: " + ex.Message
			});
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string EditObjectPreOrder(int objId = 0, int? wfReqId = null, int? wfId = null, int? wfStepId = null, int? modeId = null)
	{
		_003C_003Ec__DisplayClass31_0 _003C_003Ec__DisplayClass31_ = new _003C_003Ec__DisplayClass31_0();
		_003C_003Ec__DisplayClass31_.modeId = modeId;
		_003C_003Ec__DisplayClass31_.wfReqId = wfReqId;
		_003C_003Ec__DisplayClass31_.wfStepId = wfStepId;
		_003C_003Ec__DisplayClass31_.objId = objId;
		List<SelectListItem> list = new List<SelectListItem>();
		_003C_003Ec__DisplayClass31_.modeId = _003C_003Ec__DisplayClass31_.modeId.GetValueOrDefault(1);
		try
		{
			_003C_003Ec__DisplayClass31_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass31_1();
			CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass31_;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			CS_0024_003C_003E8__locals0.UserId = UserLogin.CurrentUser.UserId;
			List<EditAfterFixInfoViewModel> list2 = new List<EditAfterFixInfoViewModel>();
			WSspSelectPreOrderWithId_Result wSspSelectPreOrderWithId_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)_db.WSspSelectPreOrderWithId(CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.objId, lCID, result));
			if (wSspSelectPreOrderWithId_Result != null)
			{
				if (!string.IsNullOrWhiteSpace((wSspSelectPreOrderWithId_Result.pordEditAfterFixInfoJs ?? "").Replace("[]", "")))
				{
					list2 = JsonConvert.DeserializeObject<List<EditAfterFixInfoViewModel>>(wSspSelectPreOrderWithId_Result.pordEditAfterFixInfoJs);
				}
				int num = Enumerable.ToList<EditAfterFixInfoViewModel>(Enumerable.Where<EditAfterFixInfoViewModel>((IEnumerable<EditAfterFixInfoViewModel>)list2, (Func<EditAfterFixInfoViewModel, bool>)((EditAfterFixInfoViewModel x) => !x.eafEndDate.HasValue || x.eafEndDate <= DateTime.Now))).FindIndex((EditAfterFixInfoViewModel x) => x.eafUserId == CS_0024_003C_003E8__locals0.UserId && x.eafModeId == CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.modeId && x.eafWorkflowReqId == CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.wfReqId && x.eafWorkflowStepId == CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.wfStepId);
				if (num == -1)
				{
					string eafID = System.Guid.NewGuid().ToString();
					EditAfterFixInfoViewModel editAfterFixInfoViewModel = new EditAfterFixInfoViewModel();
					editAfterFixInfoViewModel.eafID = eafID;
					editAfterFixInfoViewModel.eafModeId = CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.modeId.GetValueOrDefault();
					editAfterFixInfoViewModel.eafUserId = CS_0024_003C_003E8__locals0.UserId;
					editAfterFixInfoViewModel.eafWorkflowId = wfId;
					editAfterFixInfoViewModel.eafWorkflowReqId = CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.wfReqId;
					editAfterFixInfoViewModel.eafWorkflowStepId = CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.wfStepId;
					editAfterFixInfoViewModel.eafRequestDate = DateTime.Now;
					list2.Add(editAfterFixInfoViewModel);
					DbSet<WSPreOrder> wSPreOrder = _dbTbl.WSPreOrder;
					ParameterExpression val = Expression.Parameter(typeof(WSPreOrder), "x");
					WSPreOrder wSPreOrder2 = Queryable.FirstOrDefault<WSPreOrder>((IQueryable<WSPreOrder>)wSPreOrder, Expression.Lambda<Func<WSPreOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass31_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					if (wSPreOrder2 != null)
					{
						wSPreOrder2.pordEditAfterFixInfoJs = JsonConvert.SerializeObject(list2);
						_dbTbl.Entry(wSPreOrder2).State = EntityState.Modified;
						_dbTbl.Configuration.ValidateOnSaveEnabled = false;
						_dbTbl.SaveChanges();
						_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					}
					list.Add(new SelectListItem
					{
						Text = "Data",
						Value = JsonConvert.SerializeObject(editAfterFixInfoViewModel)
					});
				}
				else
				{
					list.Add(new SelectListItem
					{
						Text = "Data",
						Value = JsonConvert.SerializeObject(list2[num])
					});
				}
			}
			else
			{
				list.Add(new SelectListItem
				{
					Text = "Error",
					Value = Messages.msgErrorPreOrderNotFound
				});
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			list.Add(new SelectListItem
			{
				Text = "Error",
				Value = "Error: " + ex.Message
			});
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string EditObjectBuyOrder(int objId = 0, int? wfReqId = null, int? wfId = null, int? wfStepId = null, int? modeId = null)
	{
		_003C_003Ec__DisplayClass32_0 _003C_003Ec__DisplayClass32_ = new _003C_003Ec__DisplayClass32_0();
		_003C_003Ec__DisplayClass32_.modeId = modeId;
		_003C_003Ec__DisplayClass32_.wfReqId = wfReqId;
		_003C_003Ec__DisplayClass32_.wfStepId = wfStepId;
		_003C_003Ec__DisplayClass32_.objId = objId;
		List<SelectListItem> list = new List<SelectListItem>();
		_003C_003Ec__DisplayClass32_.modeId = _003C_003Ec__DisplayClass32_.modeId.GetValueOrDefault(1);
		try
		{
			_003C_003Ec__DisplayClass32_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass32_1();
			CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass32_;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			CS_0024_003C_003E8__locals0.UserId = UserLogin.CurrentUser.UserId;
			List<EditAfterFixInfoViewModel> list2 = new List<EditAfterFixInfoViewModel>();
			WSspSelectBuyOrderById_Result wSspSelectBuyOrderById_Result = Enumerable.FirstOrDefault<WSspSelectBuyOrderById_Result>((IEnumerable<WSspSelectBuyOrderById_Result>)_dbII.WSspSelectBuyOrderById(CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.objId, lCID, result));
			if (wSspSelectBuyOrderById_Result != null)
			{
				if (!string.IsNullOrWhiteSpace((wSspSelectBuyOrderById_Result.bordEditAfterFixInfoJs ?? "").Replace("[]", "")))
				{
					list2 = JsonConvert.DeserializeObject<List<EditAfterFixInfoViewModel>>(wSspSelectBuyOrderById_Result.bordEditAfterFixInfoJs);
				}
				int num = Enumerable.ToList<EditAfterFixInfoViewModel>(Enumerable.Where<EditAfterFixInfoViewModel>((IEnumerable<EditAfterFixInfoViewModel>)list2, (Func<EditAfterFixInfoViewModel, bool>)((EditAfterFixInfoViewModel x) => !x.eafEndDate.HasValue || x.eafEndDate <= DateTime.Now))).FindIndex((EditAfterFixInfoViewModel x) => x.eafUserId == CS_0024_003C_003E8__locals0.UserId && x.eafModeId == CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.modeId && x.eafWorkflowReqId == CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.wfReqId && x.eafWorkflowStepId == CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.wfStepId);
				if (num == -1)
				{
					string eafID = System.Guid.NewGuid().ToString();
					EditAfterFixInfoViewModel editAfterFixInfoViewModel = new EditAfterFixInfoViewModel();
					editAfterFixInfoViewModel.eafID = eafID;
					editAfterFixInfoViewModel.eafModeId = CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.modeId.GetValueOrDefault();
					editAfterFixInfoViewModel.eafUserId = CS_0024_003C_003E8__locals0.UserId;
					editAfterFixInfoViewModel.eafWorkflowId = wfId;
					editAfterFixInfoViewModel.eafWorkflowReqId = CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.wfReqId;
					editAfterFixInfoViewModel.eafWorkflowStepId = CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.wfStepId;
					editAfterFixInfoViewModel.eafRequestDate = DateTime.Now;
					list2.Add(editAfterFixInfoViewModel);
					DbSet<WSBuyOrder> wSBuyOrder = _dbTbl.WSBuyOrder;
					ParameterExpression val = Expression.Parameter(typeof(WSBuyOrder), "x");
					WSBuyOrder wSBuyOrder2 = Queryable.FirstOrDefault<WSBuyOrder>((IQueryable<WSBuyOrder>)wSBuyOrder, Expression.Lambda<Func<WSBuyOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass32_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					if (wSBuyOrder2 != null)
					{
						wSBuyOrder2.bordEditAfterFixInfoJs = JsonConvert.SerializeObject(list2);
						_dbTbl.Entry(wSBuyOrder2).State = EntityState.Modified;
						_dbTbl.Configuration.ValidateOnSaveEnabled = false;
						_dbTbl.SaveChanges();
						_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					}
					list.Add(new SelectListItem
					{
						Text = "Data",
						Value = JsonConvert.SerializeObject(editAfterFixInfoViewModel)
					});
				}
				else
				{
					list.Add(new SelectListItem
					{
						Text = "Data",
						Value = JsonConvert.SerializeObject(list2[num])
					});
				}
			}
			else
			{
				list.Add(new SelectListItem
				{
					Text = "Error",
					Value = Messages.msgErrorBuyOrderNotFound
				});
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			list.Add(new SelectListItem
			{
				Text = "Error",
				Value = "Error: " + ex.Message
			});
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string EditObjectDoc(int objId = 0, int? wfReqId = null, int? wfId = null, int? wfStepId = null, int? modeId = null)
	{
		_003C_003Ec__DisplayClass33_0 _003C_003Ec__DisplayClass33_ = new _003C_003Ec__DisplayClass33_0();
		_003C_003Ec__DisplayClass33_.modeId = modeId;
		_003C_003Ec__DisplayClass33_.wfReqId = wfReqId;
		_003C_003Ec__DisplayClass33_.wfStepId = wfStepId;
		_003C_003Ec__DisplayClass33_.objId = objId;
		List<SelectListItem> list = new List<SelectListItem>();
		_003C_003Ec__DisplayClass33_.modeId = _003C_003Ec__DisplayClass33_.modeId.GetValueOrDefault(1);
		try
		{
			_003C_003Ec__DisplayClass33_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass33_1();
			CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass33_;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			CS_0024_003C_003E8__locals0.UserId = UserLogin.CurrentUser.UserId;
			List<EditAfterFixInfoViewModel> list2 = new List<EditAfterFixInfoViewModel>();
			WSspSelectDocById_Result wSspSelectDocById_Result = Enumerable.FirstOrDefault<WSspSelectDocById_Result>((IEnumerable<WSspSelectDocById_Result>)_dbI.WSspSelectDocById(CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.objId, lCID, result));
			if (wSspSelectDocById_Result != null)
			{
				if (!string.IsNullOrWhiteSpace((wSspSelectDocById_Result.EditAfterFixInfoJs ?? "").Replace("[]", "")))
				{
					list2 = JsonConvert.DeserializeObject<List<EditAfterFixInfoViewModel>>(wSspSelectDocById_Result.EditAfterFixInfoJs);
				}
				int num = Enumerable.ToList<EditAfterFixInfoViewModel>(Enumerable.Where<EditAfterFixInfoViewModel>((IEnumerable<EditAfterFixInfoViewModel>)list2, (Func<EditAfterFixInfoViewModel, bool>)((EditAfterFixInfoViewModel x) => !x.eafEndDate.HasValue || x.eafEndDate <= DateTime.Now))).FindIndex((EditAfterFixInfoViewModel x) => x.eafUserId == CS_0024_003C_003E8__locals0.UserId && x.eafModeId == CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.modeId && x.eafWorkflowReqId == CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.wfReqId && x.eafWorkflowStepId == CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.wfStepId);
				if (num == -1)
				{
					string eafID = System.Guid.NewGuid().ToString();
					EditAfterFixInfoViewModel editAfterFixInfoViewModel = new EditAfterFixInfoViewModel();
					editAfterFixInfoViewModel.eafID = eafID;
					editAfterFixInfoViewModel.eafModeId = CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.modeId.GetValueOrDefault();
					editAfterFixInfoViewModel.eafUserId = CS_0024_003C_003E8__locals0.UserId;
					editAfterFixInfoViewModel.eafWorkflowId = wfId;
					editAfterFixInfoViewModel.eafWorkflowReqId = CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.wfReqId;
					editAfterFixInfoViewModel.eafWorkflowStepId = CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.wfStepId;
					editAfterFixInfoViewModel.eafRequestDate = DateTime.Now;
					list2.Add(editAfterFixInfoViewModel);
					DbSet<WSDoc> wSDoc = _dbTbl.WSDoc;
					ParameterExpression val = Expression.Parameter(typeof(WSDoc), "x");
					WSDoc wSDoc2 = Queryable.FirstOrDefault<WSDoc>((IQueryable<WSDoc>)wSDoc, Expression.Lambda<Func<WSDoc, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass33_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					if (wSDoc2 != null)
					{
						wSDoc2.EditAfterFixInfoJs = JsonConvert.SerializeObject(list2);
						_dbTbl.Entry(wSDoc2).State = EntityState.Modified;
						_dbTbl.Configuration.ValidateOnSaveEnabled = false;
						_dbTbl.SaveChanges();
						_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					}
					list.Add(new SelectListItem
					{
						Text = "Data",
						Value = JsonConvert.SerializeObject(editAfterFixInfoViewModel)
					});
				}
				else
				{
					list.Add(new SelectListItem
					{
						Text = "Data",
						Value = JsonConvert.SerializeObject(list2[num])
					});
				}
			}
			else
			{
				list.Add(new SelectListItem
				{
					Text = "Error",
					Value = Messages.msgErrorDocNotFound
				});
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			list.Add(new SelectListItem
			{
				Text = "Error",
				Value = "Error: " + ex.Message
			});
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string EditObjectDraft(int objId = 0, int? wfReqId = null, int? wfId = null, int? wfStepId = null, int? modeId = null)
	{
		_003C_003Ec__DisplayClass34_0 _003C_003Ec__DisplayClass34_ = new _003C_003Ec__DisplayClass34_0();
		_003C_003Ec__DisplayClass34_.modeId = modeId;
		_003C_003Ec__DisplayClass34_.wfReqId = wfReqId;
		_003C_003Ec__DisplayClass34_.wfStepId = wfStepId;
		_003C_003Ec__DisplayClass34_.objId = objId;
		List<SelectListItem> list = new List<SelectListItem>();
		_003C_003Ec__DisplayClass34_.modeId = _003C_003Ec__DisplayClass34_.modeId.GetValueOrDefault(1);
		try
		{
			_003C_003Ec__DisplayClass34_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass34_1();
			CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass34_;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			CS_0024_003C_003E8__locals0.UserId = UserLogin.CurrentUser.UserId;
			List<EditAfterFixInfoViewModel> list2 = new List<EditAfterFixInfoViewModel>();
			WSspSelectDocById_Result wSspSelectDocById_Result = Enumerable.FirstOrDefault<WSspSelectDocById_Result>((IEnumerable<WSspSelectDocById_Result>)_dbI.WSspSelectDocById(CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.objId, lCID, result));
			if (wSspSelectDocById_Result != null)
			{
				if (!string.IsNullOrWhiteSpace((wSspSelectDocById_Result.EditAfterFixInfoJs ?? "").Replace("[]", "")))
				{
					list2 = JsonConvert.DeserializeObject<List<EditAfterFixInfoViewModel>>(wSspSelectDocById_Result.EditAfterFixInfoJs);
				}
				int num = Enumerable.ToList<EditAfterFixInfoViewModel>(Enumerable.Where<EditAfterFixInfoViewModel>((IEnumerable<EditAfterFixInfoViewModel>)list2, (Func<EditAfterFixInfoViewModel, bool>)((EditAfterFixInfoViewModel x) => !x.eafEndDate.HasValue || x.eafEndDate <= DateTime.Now))).FindIndex((EditAfterFixInfoViewModel x) => x.eafUserId == CS_0024_003C_003E8__locals0.UserId && x.eafModeId == CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.modeId && x.eafWorkflowReqId == CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.wfReqId && x.eafWorkflowStepId == CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.wfStepId);
				if (num == -1)
				{
					string eafID = System.Guid.NewGuid().ToString();
					EditAfterFixInfoViewModel editAfterFixInfoViewModel = new EditAfterFixInfoViewModel();
					editAfterFixInfoViewModel.eafID = eafID;
					editAfterFixInfoViewModel.eafModeId = CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.modeId.GetValueOrDefault();
					editAfterFixInfoViewModel.eafUserId = CS_0024_003C_003E8__locals0.UserId;
					editAfterFixInfoViewModel.eafWorkflowId = wfId;
					editAfterFixInfoViewModel.eafWorkflowReqId = CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.wfReqId;
					editAfterFixInfoViewModel.eafWorkflowStepId = CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.wfStepId;
					editAfterFixInfoViewModel.eafRequestDate = DateTime.Now;
					list2.Add(editAfterFixInfoViewModel);
					DbSet<WSDoc> wSDoc = _dbTbl.WSDoc;
					ParameterExpression val = Expression.Parameter(typeof(WSDoc), "x");
					WSDoc wSDoc2 = Queryable.FirstOrDefault<WSDoc>((IQueryable<WSDoc>)wSDoc, Expression.Lambda<Func<WSDoc, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass34_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					if (wSDoc2 != null)
					{
						wSDoc2.EditAfterFixInfoJs = JsonConvert.SerializeObject(list2);
						_dbTbl.Entry(wSDoc2).State = EntityState.Modified;
						_dbTbl.Configuration.ValidateOnSaveEnabled = false;
						_dbTbl.SaveChanges();
						_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					}
					list.Add(new SelectListItem
					{
						Text = "Data",
						Value = JsonConvert.SerializeObject(editAfterFixInfoViewModel)
					});
				}
				else
				{
					list.Add(new SelectListItem
					{
						Text = "Data",
						Value = JsonConvert.SerializeObject(list2[num])
					});
				}
			}
			else
			{
				list.Add(new SelectListItem
				{
					Text = "Error",
					Value = Messages.msgErrorDocNotFound
				});
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			list.Add(new SelectListItem
			{
				Text = "Error",
				Value = "Error: " + ex.Message
			});
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string EditObjectMovement(int objId = 0, int? wfReqId = null, int? wfId = null, int? wfStepId = null, int? modeId = null)
	{
		_003C_003Ec__DisplayClass35_0 _003C_003Ec__DisplayClass35_ = new _003C_003Ec__DisplayClass35_0();
		_003C_003Ec__DisplayClass35_.modeId = modeId;
		_003C_003Ec__DisplayClass35_.wfReqId = wfReqId;
		_003C_003Ec__DisplayClass35_.wfStepId = wfStepId;
		_003C_003Ec__DisplayClass35_.objId = objId;
		List<SelectListItem> list = new List<SelectListItem>();
		_003C_003Ec__DisplayClass35_.modeId = _003C_003Ec__DisplayClass35_.modeId.GetValueOrDefault(1);
		try
		{
			_003C_003Ec__DisplayClass35_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass35_1();
			CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass35_;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			CS_0024_003C_003E8__locals0.UserId = UserLogin.CurrentUser.UserId;
			List<EditAfterFixInfoViewModel> list2 = new List<EditAfterFixInfoViewModel>();
			WSspSelectDocById_Result wSspSelectDocById_Result = Enumerable.FirstOrDefault<WSspSelectDocById_Result>((IEnumerable<WSspSelectDocById_Result>)_dbI.WSspSelectDocById(CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.objId, lCID, result));
			if (wSspSelectDocById_Result != null)
			{
				if (!string.IsNullOrWhiteSpace((wSspSelectDocById_Result.EditAfterFixInfoJs ?? "").Replace("[]", "")))
				{
					list2 = JsonConvert.DeserializeObject<List<EditAfterFixInfoViewModel>>(wSspSelectDocById_Result.EditAfterFixInfoJs);
				}
				int num = Enumerable.ToList<EditAfterFixInfoViewModel>(Enumerable.Where<EditAfterFixInfoViewModel>((IEnumerable<EditAfterFixInfoViewModel>)list2, (Func<EditAfterFixInfoViewModel, bool>)((EditAfterFixInfoViewModel x) => !x.eafEndDate.HasValue || x.eafEndDate <= DateTime.Now))).FindIndex((EditAfterFixInfoViewModel x) => x.eafUserId == CS_0024_003C_003E8__locals0.UserId && x.eafModeId == CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.modeId && x.eafWorkflowReqId == CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.wfReqId && x.eafWorkflowStepId == CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.wfStepId);
				if (num == -1)
				{
					string eafID = System.Guid.NewGuid().ToString();
					EditAfterFixInfoViewModel editAfterFixInfoViewModel = new EditAfterFixInfoViewModel();
					editAfterFixInfoViewModel.eafID = eafID;
					editAfterFixInfoViewModel.eafModeId = CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.modeId.GetValueOrDefault();
					editAfterFixInfoViewModel.eafUserId = CS_0024_003C_003E8__locals0.UserId;
					editAfterFixInfoViewModel.eafWorkflowId = wfId;
					editAfterFixInfoViewModel.eafWorkflowReqId = CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.wfReqId;
					editAfterFixInfoViewModel.eafWorkflowStepId = CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.wfStepId;
					editAfterFixInfoViewModel.eafRequestDate = DateTime.Now;
					list2.Add(editAfterFixInfoViewModel);
					DbSet<WSDoc> wSDoc = _dbTbl.WSDoc;
					ParameterExpression val = Expression.Parameter(typeof(WSDoc), "x");
					WSDoc wSDoc2 = Queryable.FirstOrDefault<WSDoc>((IQueryable<WSDoc>)wSDoc, Expression.Lambda<Func<WSDoc, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass35_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					if (wSDoc2 != null)
					{
						wSDoc2.EditAfterFixInfoJs = JsonConvert.SerializeObject(list2);
						_dbTbl.Entry(wSDoc2).State = EntityState.Modified;
						_dbTbl.Configuration.ValidateOnSaveEnabled = false;
						_dbTbl.SaveChanges();
						_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					}
					list.Add(new SelectListItem
					{
						Text = "Data",
						Value = JsonConvert.SerializeObject(editAfterFixInfoViewModel)
					});
				}
				else
				{
					list.Add(new SelectListItem
					{
						Text = "Data",
						Value = JsonConvert.SerializeObject(list2[num])
					});
				}
			}
			else
			{
				list.Add(new SelectListItem
				{
					Text = "Error",
					Value = Messages.msgErrorDocNotFound
				});
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			list.Add(new SelectListItem
			{
				Text = "Error",
				Value = "Error: " + ex.Message
			});
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string EditObjectSendLetter(int objId = 0, int? wfReqId = null, int? wfId = null, int? wfStepId = null, int? modeId = null)
	{
		_003C_003Ec__DisplayClass36_0 _003C_003Ec__DisplayClass36_ = new _003C_003Ec__DisplayClass36_0();
		_003C_003Ec__DisplayClass36_.modeId = modeId;
		_003C_003Ec__DisplayClass36_.wfReqId = wfReqId;
		_003C_003Ec__DisplayClass36_.wfStepId = wfStepId;
		_003C_003Ec__DisplayClass36_.objId = objId;
		List<SelectListItem> list = new List<SelectListItem>();
		_003C_003Ec__DisplayClass36_.modeId = _003C_003Ec__DisplayClass36_.modeId.GetValueOrDefault(1);
		try
		{
			_003C_003Ec__DisplayClass36_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass36_1();
			CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass36_;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			CS_0024_003C_003E8__locals0.UserId = UserLogin.CurrentUser.UserId;
			List<EditAfterFixInfoViewModel> list2 = new List<EditAfterFixInfoViewModel>();
			SecspSelectLettersById_Result secspSelectLettersById_Result = Enumerable.FirstOrDefault<SecspSelectLettersById_Result>((IEnumerable<SecspSelectLettersById_Result>)_dbII.SecspSelectLettersById(CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.objId, lCID, result));
			if (secspSelectLettersById_Result != null)
			{
				if (!string.IsNullOrWhiteSpace((secspSelectLettersById_Result.LetterEditAfterFixInfoJs ?? "").Replace("[]", "")))
				{
					list2 = JsonConvert.DeserializeObject<List<EditAfterFixInfoViewModel>>(secspSelectLettersById_Result.LetterEditAfterFixInfoJs);
				}
				int num = Enumerable.ToList<EditAfterFixInfoViewModel>(Enumerable.Where<EditAfterFixInfoViewModel>((IEnumerable<EditAfterFixInfoViewModel>)list2, (Func<EditAfterFixInfoViewModel, bool>)((EditAfterFixInfoViewModel x) => !x.eafEndDate.HasValue || x.eafEndDate <= DateTime.Now))).FindIndex((EditAfterFixInfoViewModel x) => x.eafUserId == CS_0024_003C_003E8__locals0.UserId && x.eafModeId == CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.modeId && x.eafWorkflowReqId == CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.wfReqId && x.eafWorkflowStepId == CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.wfStepId);
				if (num == -1)
				{
					string eafID = System.Guid.NewGuid().ToString();
					EditAfterFixInfoViewModel editAfterFixInfoViewModel = new EditAfterFixInfoViewModel();
					editAfterFixInfoViewModel.eafID = eafID;
					editAfterFixInfoViewModel.eafModeId = CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.modeId.GetValueOrDefault();
					editAfterFixInfoViewModel.eafUserId = CS_0024_003C_003E8__locals0.UserId;
					editAfterFixInfoViewModel.eafWorkflowId = wfId;
					editAfterFixInfoViewModel.eafWorkflowReqId = CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.wfReqId;
					editAfterFixInfoViewModel.eafWorkflowStepId = CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.wfStepId;
					editAfterFixInfoViewModel.eafRequestDate = DateTime.Now;
					list2.Add(editAfterFixInfoViewModel);
					DbSet<SecLetters> secLetters = _dbTbl.SecLetters;
					ParameterExpression val = Expression.Parameter(typeof(SecLetters), "x");
					SecLetters secLetters2 = Queryable.FirstOrDefault<SecLetters>((IQueryable<SecLetters>)secLetters, Expression.Lambda<Func<SecLetters, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass36_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					if (secLetters2 != null)
					{
						secLetters2.LetterEditAfterFixInfoJs = JsonConvert.SerializeObject(list2);
						_dbTbl.Entry(secLetters2).State = EntityState.Modified;
						_dbTbl.Configuration.ValidateOnSaveEnabled = false;
						_dbTbl.SaveChanges();
						_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					}
					list.Add(new SelectListItem
					{
						Text = "Data",
						Value = JsonConvert.SerializeObject(editAfterFixInfoViewModel)
					});
				}
				else
				{
					list.Add(new SelectListItem
					{
						Text = "Data",
						Value = JsonConvert.SerializeObject(list2[num])
					});
				}
			}
			else
			{
				list.Add(new SelectListItem
				{
					Text = "Error",
					Value = Messages.msgErrorDocNotFound
				});
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			list.Add(new SelectListItem
			{
				Text = "Error",
				Value = "Error: " + ex.Message
			});
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string EditObjectReceiveLetter(int objId = 0, int? wfReqId = null, int? wfId = null, int? wfStepId = null, int? modeId = null)
	{
		_003C_003Ec__DisplayClass37_0 _003C_003Ec__DisplayClass37_ = new _003C_003Ec__DisplayClass37_0();
		_003C_003Ec__DisplayClass37_.modeId = modeId;
		_003C_003Ec__DisplayClass37_.wfReqId = wfReqId;
		_003C_003Ec__DisplayClass37_.wfStepId = wfStepId;
		_003C_003Ec__DisplayClass37_.objId = objId;
		List<SelectListItem> list = new List<SelectListItem>();
		_003C_003Ec__DisplayClass37_.modeId = _003C_003Ec__DisplayClass37_.modeId.GetValueOrDefault(1);
		try
		{
			_003C_003Ec__DisplayClass37_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass37_1();
			CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass37_;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			CS_0024_003C_003E8__locals0.UserId = UserLogin.CurrentUser.UserId;
			List<EditAfterFixInfoViewModel> list2 = new List<EditAfterFixInfoViewModel>();
			SecspSelectLettersById_Result secspSelectLettersById_Result = Enumerable.FirstOrDefault<SecspSelectLettersById_Result>((IEnumerable<SecspSelectLettersById_Result>)_dbII.SecspSelectLettersById(CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.objId, lCID, result));
			if (secspSelectLettersById_Result != null)
			{
				if (!string.IsNullOrWhiteSpace((secspSelectLettersById_Result.LetterEditAfterFixInfoJs ?? "").Replace("[]", "")))
				{
					list2 = JsonConvert.DeserializeObject<List<EditAfterFixInfoViewModel>>(secspSelectLettersById_Result.LetterEditAfterFixInfoJs);
				}
				int num = Enumerable.ToList<EditAfterFixInfoViewModel>(Enumerable.Where<EditAfterFixInfoViewModel>((IEnumerable<EditAfterFixInfoViewModel>)list2, (Func<EditAfterFixInfoViewModel, bool>)((EditAfterFixInfoViewModel x) => !x.eafEndDate.HasValue || x.eafEndDate <= DateTime.Now))).FindIndex((EditAfterFixInfoViewModel x) => x.eafUserId == CS_0024_003C_003E8__locals0.UserId && x.eafModeId == CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.modeId && x.eafWorkflowReqId == CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.wfReqId && x.eafWorkflowStepId == CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.wfStepId);
				if (num == -1)
				{
					string eafID = System.Guid.NewGuid().ToString();
					EditAfterFixInfoViewModel editAfterFixInfoViewModel = new EditAfterFixInfoViewModel();
					editAfterFixInfoViewModel.eafID = eafID;
					editAfterFixInfoViewModel.eafModeId = CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.modeId.GetValueOrDefault();
					editAfterFixInfoViewModel.eafUserId = CS_0024_003C_003E8__locals0.UserId;
					editAfterFixInfoViewModel.eafWorkflowId = wfId;
					editAfterFixInfoViewModel.eafWorkflowReqId = CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.wfReqId;
					editAfterFixInfoViewModel.eafWorkflowStepId = CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.wfStepId;
					editAfterFixInfoViewModel.eafRequestDate = DateTime.Now;
					list2.Add(editAfterFixInfoViewModel);
					DbSet<SecLetters> secLetters = _dbTbl.SecLetters;
					ParameterExpression val = Expression.Parameter(typeof(SecLetters), "x");
					SecLetters secLetters2 = Queryable.FirstOrDefault<SecLetters>((IQueryable<SecLetters>)secLetters, Expression.Lambda<Func<SecLetters, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass37_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					if (secLetters2 != null)
					{
						secLetters2.LetterEditAfterFixInfoJs = JsonConvert.SerializeObject(list2);
						_dbTbl.Entry(secLetters2).State = EntityState.Modified;
						_dbTbl.Configuration.ValidateOnSaveEnabled = false;
						_dbTbl.SaveChanges();
						_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					}
					list.Add(new SelectListItem
					{
						Text = "Data",
						Value = JsonConvert.SerializeObject(editAfterFixInfoViewModel)
					});
				}
				else
				{
					list.Add(new SelectListItem
					{
						Text = "Data",
						Value = JsonConvert.SerializeObject(list2[num])
					});
				}
			}
			else
			{
				list.Add(new SelectListItem
				{
					Text = "Error",
					Value = Messages.msgErrorDocNotFound
				});
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			list.Add(new SelectListItem
			{
				Text = "Error",
				Value = "Error: " + ex.Message
			});
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string EditObjectDyForm(int objId = 0, int? wfReqId = null, int? wfId = null, int? wfStepId = null, int? modeId = null)
	{
		_003C_003Ec__DisplayClass38_0 _003C_003Ec__DisplayClass38_ = new _003C_003Ec__DisplayClass38_0();
		_003C_003Ec__DisplayClass38_.modeId = modeId;
		_003C_003Ec__DisplayClass38_.wfReqId = wfReqId;
		_003C_003Ec__DisplayClass38_.wfStepId = wfStepId;
		_003C_003Ec__DisplayClass38_.objId = objId;
		List<SelectListItem> list = new List<SelectListItem>();
		_003C_003Ec__DisplayClass38_.modeId = _003C_003Ec__DisplayClass38_.modeId.GetValueOrDefault(1);
		try
		{
			_003C_003Ec__DisplayClass38_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass38_1();
			CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass38_;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			CS_0024_003C_003E8__locals0.UserId = UserLogin.CurrentUser.UserId;
			List<EditAfterFixInfoViewModel> list2 = new List<EditAfterFixInfoViewModel>();
			CRMspDySelectFormFieldMasterValueWithId_Result cRMspDySelectFormFieldMasterValueWithId_Result = Enumerable.FirstOrDefault<CRMspDySelectFormFieldMasterValueWithId_Result>((IEnumerable<CRMspDySelectFormFieldMasterValueWithId_Result>)_db.CRMspDySelectFormFieldMasterValueWithId(CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.objId, lCID, result));
			if (cRMspDySelectFormFieldMasterValueWithId_Result != null)
			{
				if (!string.IsNullOrWhiteSpace((cRMspDySelectFormFieldMasterValueWithId_Result.EditAfterFixInfoJs ?? "").Replace("[]", "")))
				{
					list2 = JsonConvert.DeserializeObject<List<EditAfterFixInfoViewModel>>(cRMspDySelectFormFieldMasterValueWithId_Result.EditAfterFixInfoJs);
				}
				int num = Enumerable.ToList<EditAfterFixInfoViewModel>(Enumerable.Where<EditAfterFixInfoViewModel>((IEnumerable<EditAfterFixInfoViewModel>)list2, (Func<EditAfterFixInfoViewModel, bool>)((EditAfterFixInfoViewModel x) => !x.eafEndDate.HasValue || x.eafEndDate <= DateTime.Now))).FindIndex((EditAfterFixInfoViewModel x) => x.eafUserId == CS_0024_003C_003E8__locals0.UserId && x.eafModeId == CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.modeId && x.eafWorkflowReqId == CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.wfReqId && x.eafWorkflowStepId == CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.wfStepId);
				if (num == -1)
				{
					string eafID = System.Guid.NewGuid().ToString();
					EditAfterFixInfoViewModel editAfterFixInfoViewModel = new EditAfterFixInfoViewModel();
					editAfterFixInfoViewModel.eafID = eafID;
					editAfterFixInfoViewModel.eafModeId = CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.modeId.GetValueOrDefault();
					editAfterFixInfoViewModel.eafUserId = CS_0024_003C_003E8__locals0.UserId;
					editAfterFixInfoViewModel.eafWorkflowId = wfId;
					editAfterFixInfoViewModel.eafWorkflowReqId = CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.wfReqId;
					editAfterFixInfoViewModel.eafWorkflowStepId = CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.wfStepId;
					editAfterFixInfoViewModel.eafRequestDate = DateTime.Now;
					list2.Add(editAfterFixInfoViewModel);
					DbSet<CrmDyFormFieldMasterValues> crmDyFormFieldMasterValues = _dbTbl.CrmDyFormFieldMasterValues;
					ParameterExpression val = Expression.Parameter(typeof(CrmDyFormFieldMasterValues), "x");
					CrmDyFormFieldMasterValues crmDyFormFieldMasterValues2 = Queryable.FirstOrDefault<CrmDyFormFieldMasterValues>((IQueryable<CrmDyFormFieldMasterValues>)crmDyFormFieldMasterValues, Expression.Lambda<Func<CrmDyFormFieldMasterValues, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass38_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					if (crmDyFormFieldMasterValues2 != null)
					{
						crmDyFormFieldMasterValues2.EditAfterFixInfoJs = JsonConvert.SerializeObject(list2);
						_dbTbl.Entry(crmDyFormFieldMasterValues2).State = EntityState.Modified;
						_dbTbl.Configuration.ValidateOnSaveEnabled = false;
						_dbTbl.SaveChanges();
						_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					}
					list.Add(new SelectListItem
					{
						Text = "Data",
						Value = JsonConvert.SerializeObject(editAfterFixInfoViewModel)
					});
				}
				else
				{
					list.Add(new SelectListItem
					{
						Text = "Data",
						Value = JsonConvert.SerializeObject(list2[num])
					});
				}
			}
			else
			{
				list.Add(new SelectListItem
				{
					Text = "Error",
					Value = Messages.msgErrorDocNotFound
				});
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			list.Add(new SelectListItem
			{
				Text = "Error",
				Value = "Error: " + ex.Message
			});
		}
		return JsonConvert.SerializeObject(list);
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
		int result3 = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
		}
		try
		{
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

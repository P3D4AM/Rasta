using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Script.Serialization;
using CRM.General.Utilities;
using CRM.Resources;
using Elmah;
using GSD.Globalization;
using Mobile.Cache.Setting;
using Mobile.Classes;
using Mobile.Classes.Helper;
using Mobile.DataType;
using Mobile.Models;
using Mobile.Models.ViewModel.VerificationWorkFlow;
using Newtonsoft.Json;

namespace Mobile.Controllers;

public class HRMVerificationWorkFlowController : ApiController
{
	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<HRMMobspSelectVerificationRequests_Result>> SelectVerificationRequests(int reqId, int objId, int objType, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<HRMMobspSelectVerificationRequests_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					data = Enumerable.ToList<HRMMobspSelectVerificationRequests_Result>((IEnumerable<HRMMobspSelectVerificationRequests_Result>)cRMEntities.HRMMobspSelectVerificationRequests(reqId, objId, objType, result, result2));
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<HRMMobspSelectVerificationRequests_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<VerificationWorkflowViewModelNew> GetVerificationWorkflow(int objectType, int objectId, int verificationRequestId, int workflowId = 0, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		VerificationWorkflowViewModelNew verificationWorkflowViewModelNew = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					verificationWorkflowViewModelNew = new VerificationWorkflowViewModelNew();
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					if (verificationRequestId == 0)
					{
						HRMMobspSelectVerificationRequests_Result hRMMobspSelectVerificationRequests_Result = Enumerable.FirstOrDefault<HRMMobspSelectVerificationRequests_Result>((IEnumerable<HRMMobspSelectVerificationRequests_Result>)cRMEntities.HRMMobspSelectVerificationRequests(0, objectId, objectType, result, result2));
						if (hRMMobspSelectVerificationRequests_Result != null)
						{
							if (verificationRequestId == 0)
							{
								verificationRequestId = hRMMobspSelectVerificationRequests_Result.VerificationRequestId;
							}
							if (workflowId == 0)
							{
								workflowId = hRMMobspSelectVerificationRequests_Result.VerificationWorkFlowId;
							}
						}
					}
					verificationWorkflowViewModelNew.ObjectId = objectId;
					verificationWorkflowViewModelNew.ObjectTypeId = objectType;
					verificationWorkflowViewModelNew.Workflow = GetVerificationWorkFlowWithId(workflowId);
					verificationWorkflowViewModelNew.WorkFlowSteps = GetVerificationWorkFlowSteps(workflowId);
					verificationWorkflowViewModelNew.VerificationRequest = Enumerable.FirstOrDefault<MobspSelectVerificationRequests_Result>((IEnumerable<MobspSelectVerificationRequests_Result>)GetVerificationRequest(verificationRequestId));
					verificationWorkflowViewModelNew.VerificationRequestDetails = GetVerificationRequestsByReqId(verificationRequestId, 0);
					int? userId = 0;
					int? companyId = 0;
					if (objectType == 90 || objectType == 100)
					{
						CRMEntities cRMEntities2 = cRMEntities;
						int? crmUserId = 0;
						int? leaveId = objectId;
						int? languageID = num;
						int? defaultLanguageID = result2;
						MobspSelectLeave_Result mobspSelectLeave_Result = Enumerable.FirstOrDefault<MobspSelectLeave_Result>((IEnumerable<MobspSelectLeave_Result>)cRMEntities2.MobspSelectLeave(crmUserId, leaveId, null, null, null, null, null, null, languageID, defaultLanguageID, null, cId));
						if (mobspSelectLeave_Result != null)
						{
							mobspSelectLeave_Result.ReplaceUserVerifiedDatePersian = mobspSelectLeave_Result.ReplaceUserVerifiedDate?.ToString("yyyy/MM/dd HH:mm");
							mobspSelectLeave_Result.CanceledDatePersian = mobspSelectLeave_Result.CanceledDate?.ToString("yyyy/MM/dd HH:mm");
							mobspSelectLeave_Result.FirstRegisterDatePersian = mobspSelectLeave_Result.FirstRegisterDate?.ToString("yyyy/MM/dd HH:mm");
							mobspSelectLeave_Result.FromDate = mobspSelectLeave_Result.FromDateTime?.ToString("yyyy/MM/dd HH:mm");
							mobspSelectLeave_Result.ToDate = mobspSelectLeave_Result.ToDateTime?.ToString("yyyy/MM/dd HH:mm");
							mobspSelectLeave_Result.VerifiedRegisterDatePersian = mobspSelectLeave_Result.VerifiedRegisterDate?.ToString("yyyy/MM/dd HH:mm");
							verificationWorkflowViewModelNew.FirstRegisterUserId = mobspSelectLeave_Result.FirstRegisterUserId;
							verificationWorkflowViewModelNew.FirstRegisterUserName = mobspSelectLeave_Result.FirstRegisterUser;
							verificationWorkflowViewModelNew.ReplaceUserId = mobspSelectLeave_Result.ReplaceUserId;
							verificationWorkflowViewModelNew.ReplaceUser = mobspSelectLeave_Result.ReplaceUser;
							verificationWorkflowViewModelNew.ReplaceUserIsVerified = mobspSelectLeave_Result.ReplaceUserIsVerified;
							verificationWorkflowViewModelNew.ReplaceUserIsVerifiedDate = mobspSelectLeave_Result.ReplaceUserVerifiedDatePersian;
							verificationWorkflowViewModelNew.FirstRegisterDate = mobspSelectLeave_Result.FirstRegisterDate ?? DateTime.Now;
							verificationWorkflowViewModelNew.ReplaceUserIntMsgId = mobspSelectLeave_Result.ReplaceUserIntMsgId;
							userId = mobspSelectLeave_Result.RequestUserId;
							verificationWorkflowViewModelNew.IsCanceled = mobspSelectLeave_Result.IsCanceled;
							verificationWorkflowViewModelNew.CancelerUserId = mobspSelectLeave_Result.CancelerUserId;
							verificationWorkflowViewModelNew.CancelerUser = mobspSelectLeave_Result.CancelerUser;
							verificationWorkflowViewModelNew.CanceledDate = mobspSelectLeave_Result.CanceledDate;
							verificationWorkflowViewModelNew.CanceledDatePersian = mobspSelectLeave_Result.CanceledDate?.ToString("yyyy/MM/dd HH:mm");
						}
					}
					if (userId.GetValueOrDefault() != 0)
					{
						MobspSelectUsersById_Result mobspSelectUsersById_Result = Enumerable.FirstOrDefault<MobspSelectUsersById_Result>((IEnumerable<MobspSelectUsersById_Result>)cRMEntities.MobspSelectUsersById(userId, result, result2, cId));
						if (mobspSelectUsersById_Result != null)
						{
							verificationWorkflowViewModelNew.ResponsibleUserId = mobspSelectUsersById_Result.ResponsibleUserId;
							verificationWorkflowViewModelNew.ResponsibleUserName = mobspSelectUsersById_Result.ResponsibleUser;
						}
					}
					if (companyId.GetValueOrDefault() != 0)
					{
						MobspSelectCompanyById_Result mobspSelectCompanyById_Result = Enumerable.FirstOrDefault<MobspSelectCompanyById_Result>((IEnumerable<MobspSelectCompanyById_Result>)cRMSpEntities.MobspSelectCompanyById(companyId, result, result2, cId));
						if (mobspSelectCompanyById_Result != null)
						{
							verificationWorkflowViewModelNew.CmpReferUserId = mobspSelectCompanyById_Result.cmpReferUserId;
							verificationWorkflowViewModelNew.CmpReferUserName = mobspSelectCompanyById_Result.ReferUser;
							verificationWorkflowViewModelNew.CmpSuppUserId = mobspSelectCompanyById_Result.cmpSuppUserId;
							verificationWorkflowViewModelNew.CmpSuppUserName = mobspSelectCompanyById_Result.cmpSuppUser;
						}
					}
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					verificationWorkflowViewModelNew = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				verificationWorkflowViewModelNew = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			verificationWorkflowViewModelNew = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<VerificationWorkflowViewModelNew>
		{
			Message = message,
			Data = verificationWorkflowViewModelNew,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<HRMMobspSelectVerificationRequestDetails_Result>> SelectVerificationRequestDetails(int reqDetailId, int reqId, int workFlowId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<HRMMobspSelectVerificationRequestDetails_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					data = Enumerable.ToList<HRMMobspSelectVerificationRequestDetails_Result>((IEnumerable<HRMMobspSelectVerificationRequestDetails_Result>)cRMEntities.HRMMobspSelectVerificationRequestDetails(reqDetailId, reqId, workFlowId, result, result2, cId));
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<HRMMobspSelectVerificationRequestDetails_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> SendVerificationRequestToVerifyUser(HrmVerificationWorkFlowViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangId);
		CRMEntities cRMEntities = null;
		string data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : defLangId);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					List<HRMMobspSelectLanguages_Result> list = Enumerable.ToList<HRMMobspSelectLanguages_Result>(Enumerable.Where<HRMMobspSelectLanguages_Result>((IEnumerable<HRMMobspSelectLanguages_Result>)cRMEntities.HRMMobspSelectLanguages(), (Func<HRMMobspSelectLanguages_Result, bool>)((HRMMobspSelectLanguages_Result m) => m.LanguageID != defLangId)));
					string verificationReqText = model.MessageText ?? "";
					string resourceString = MyResource.GetResourceString("MobVerifiedRequestSubject", "fa-IR", "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
					string text = "";
					foreach (HRMMobspSelectLanguages_Result item in list)
					{
						string text2 = "";
						string text3 = "";
						text2 = MyResource.GetResourceString("MobVerifiedRequestSubject", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
						text3 = model.MessageText ?? "";
						text = text + "[LangId=" + item.LanguageID + "|,|Txt=" + text3 + "|,|Subj=" + text2 + "|,|]@";
					}
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					int value4 = int.Parse(Financial.Get().Id.ToString());
					ObjectParameter objectParameter = new ObjectParameter("result", 0);
					cRMEntities.HRMMobspSendVerificationRequest(model.VerificationWorkFlowId, model.ObjectId, verificationReqText, text, resourceString, value, registerDatePersian, token2.userId, value4, value2, value3, appType, defLangId, objectParameter, token2.userId, model.CenterId);
					string text4 = "";
					if (objectParameter.Value != null && !string.IsNullOrEmpty(objectParameter.Value.ToString()))
					{
						string text5 = objectParameter.Value.ToString();
						if (text5 == "-2")
						{
							text4 += Messages.msgErrorErrorSendingMessages;
						}
						else if (text5 == "-1")
						{
							text4 += Messages.MobMsgErrorDoneOperation;
						}
					}
					if (string.IsNullOrEmpty(text4))
					{
						PushNotif.NewIntMsgNotify(withthread: true, model.CenterId);
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = text4;
						status = ServiceResultStatus.Error;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> SendVerificationRequestToAlternateUserInStep(HrmVerificationWorkFlowViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		string data = null;
		string text = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					List<HRMMobspSelectLanguages_Result> list = Enumerable.ToList<HRMMobspSelectLanguages_Result>((IEnumerable<HRMMobspSelectLanguages_Result>)cRMEntities.HRMMobspSelectLanguages());
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					now.ToString("HH:mm:ss", new PersianCulture());
					short value2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					int value4 = int.Parse(Financial.Get().Id.ToString());
					if (!(model.FormName == "PORD") && !(model.FormName == "ORD") && !(model.FormName == "DyFrm") && !(model.FormName == "DOC") && !(model.FormName == "DRAFT") && !(model.FormName == "MOVEMENTWRHS") && !(model.FormName == "LEAVE"))
					{
						_ = model.FormName == "MISSION";
					}
					string text2 = "";
					foreach (HRMMobspSelectLanguages_Result item in list)
					{
						string text3 = "";
						string text4 = "";
						text3 = MyResource.GetResourceString("MobVerifiedRequestSubject", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
						text4 = model.MessageText ?? "";
						text2 = text2 + "MsgSubj=" + text3 + "|@#@|MsgBody=" + text4 + "|@#@|LangId=" + item.LanguageID + "|@#@||^#^|";
					}
					List<CrmInternalMessage_Lang> list2 = new List<CrmInternalMessage_Lang>();
					foreach (HRMMobspSelectLanguages_Result item2 in list)
					{
						string resourceString = MyResource.GetResourceString("VerifiedRequestSubject", item2.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
						string msgBody = model.MessageText ?? "";
						list2.Add(new CrmInternalMessage_Lang
						{
							LanguageID = item2.LanguageID,
							msgSubject = resourceString,
							msgBody = msgBody
						});
					}
					int result3 = 0;
					int.TryParse(model.VerificationReqUserId.ToString(), out result3);
					int result4 = 0;
					int.TryParse(model.AlternateVerifyUserId.ToString(), out result4);
					string resourceString2 = MyResource.GetResourceString("VerifiedRequestSubject", "fa-IR", "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
					if (result4 > 0 && result3 > 0)
					{
						ObjectParameter internalMessageId = new ObjectParameter("InternalMessageId", 0);
						cRMSpEntities.MobspVerificationRequestSendToAltUser(model.VerificationRequestId, model.VerificationWorkFlowId, model.VerificationWorkFlowStepId, model.ObjectId, model.ObjectType, model.VerifyText, JsonConvert.SerializeObject(list2), resourceString2, model.VerifyText, null, 8, model.AlternateVerifyUserId, value, registerDatePersian, token2.userId, value4, value2, value3, appType, result, result2, internalMessageId, model.CenterId);
						text = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
						PushNotif.NewIntMsgNotify();
					}
					else
					{
						text += Messages.msgErrorHaveNotAlternateVerifyUser;
					}
					text = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					text = Messages.MobMsgErrorAccessingToken;
					data = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				text = Messages.MobMsgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			text = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
			cRMEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = text,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<HRMMobspSelectVerificationRequestDetails_Result>> SendVerificationRequestToAlternateUser(VerificationWorkFlowViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangId);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		List<HRMMobspSelectVerificationRequestDetails_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : defLangId);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					List<MobspSelectLanguages_Result> list = Enumerable.ToList<MobspSelectLanguages_Result>(Enumerable.Where<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)cRMEntities.MobspSelectLanguages(), (Func<MobspSelectLanguages_Result, bool>)((MobspSelectLanguages_Result m) => m.LanguageID != defLangId)));
					string verificationReqText = model.MessageText ?? "";
					string resourceString = MyResource.GetResourceString("MobVerifiedRequestSubject", "fa-IR", "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
					string text = "";
					foreach (MobspSelectLanguages_Result item in list)
					{
						string text2 = "";
						string text3 = "";
						text2 = MyResource.GetResourceString("MobVerifiedRequestSubject", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
						text3 = model.MessageText ?? "";
						text = text + "[LangId=" + item.LanguageID + "|,|Txt=" + text3 + "|,|Subj=" + text2 + "|,|]@";
					}
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					int value4 = int.Parse(Financial.Get().Id.ToString());
					int userId = token2.userId;
					if (model.VerificationReqUserId == 0)
					{
						model.VerificationReqUserId = userId;
					}
					ObjectParameter objectParameter = new ObjectParameter("result", 0);
					cRMSpEntities.HRMMobspSendVerificationRequestToAlternateUser(model.VerificationWorkFlowId, model.ObjectId, verificationReqText, text, resourceString, value, registerDatePersian, userId, value4, value2, value3, appType, defLangId, objectParameter, model.VerificationReqUserId, model.CenterId);
					string text4 = "";
					if (objectParameter.Value != null && !string.IsNullOrEmpty(objectParameter.Value.ToString()) && objectParameter.Value.ToString() != "1")
					{
						text4 += Messages.MobMsgErrorDoneOperation;
					}
					if (string.IsNullOrEmpty(text4))
					{
						if ((model.ObjectType == 90 || model.ObjectType == 100) && model.MsgId.GetValueOrDefault() > 0)
						{
							SetMessageRead(model.MsgId.Value, model.MsgTypeId, model.CenterId);
						}
						PushNotif.NewIntMsgNotify(withthread: true, model.CenterId);
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = text4;
						status = ServiceResultStatus.Error;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<HRMMobspSelectVerificationRequestDetails_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> LeaveSendRequestToReplaceUser(HrmLeaveReplaceUserVerificationRequestLanguageViewModel model)
	{
		//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		string data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					List<HRMMobspSelectLanguages_Result> list = Enumerable.ToList<HRMMobspSelectLanguages_Result>((IEnumerable<HRMMobspSelectLanguages_Result>)cRMEntities.HRMMobspSelectLanguages());
					HRMMobspSelectLeave_Result hRMMobspSelectLeave_Result = Enumerable.FirstOrDefault<HRMMobspSelectLeave_Result>((IEnumerable<HRMMobspSelectLeave_Result>)cRMEntities.HRMMobspSelectLeave(null, model.LeaveId, null, null, null, null, null, null, result2, result2, model.CenterId));
					if (hRMMobspSelectLeave_Result != null)
					{
						int? workflowStepId = null;
						int msgTypeId = 0;
						if (hRMMobspSelectLeave_Result.LeaveTypeOpr.GetValueOrDefault() == 1)
						{
							msgTypeId = 6;
							workflowStepId = hRMMobspSelectLeave_Result.VerificationWorkFlowId ?? hRMMobspSelectLeave_Result.UserDepartmentLeaveVerificationWorkFlowId;
						}
						else if (hRMMobspSelectLeave_Result.LeaveTypeOpr.GetValueOrDefault() == 2)
						{
							msgTypeId = 7;
							workflowStepId = hRMMobspSelectLeave_Result.VerificationWorkFlowId ?? hRMMobspSelectLeave_Result.UserDepartmentMissionVerificationWorkFlowId;
						}
						string text = "";
						foreach (HRMMobspSelectLanguages_Result item in list)
						{
							string text2 = "";
							string text3 = "";
							text2 = MyResource.GetResourceString("MobVerifiedRequestSubject", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
							text3 = model.VerifyText ?? "";
							text = text + "MsgSubj=" + text2 + "|@#@|MsgBody=" + text3 + "|@#@|LangId=" + item.LanguageID + "|@#@||^#^|";
						}
						List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
						if (!string.IsNullOrEmpty(model.VerifyText_Lang))
						{
							list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.VerifyText_Lang);
						}
						list2.Add(new CommonMultiLanguageViewModel
						{
							Value = model.VerifyText,
							LanguageId = num
						});
						int userId = UserLogin.CurrentUser.UserId;
						int result3 = 0;
						int.TryParse(hRMMobspSelectLeave_Result.ReplaceUserId.ToString(), out result3);
						if (userId > 0 && result3 > 0)
						{
							int msgId = 0;
							SendMessage(ref msgId, userId, result3, msgTypeId, text, token2.userId, model.LeaveId, workflowStepId, result, model.CenterId);
							cRMSpEntities.MobspUpdateLeaveReplaceUserIntMsgId(hRMMobspSelectLeave_Result.LeaveId, msgId);
							message = Messages.MobMsgSuccessAction;
							status = ServiceResultStatus.Success;
						}
						else
						{
							message = Messages.msgErrorHaveNotAlternateVerifyUser;
							status = ServiceResultStatus.Fail;
						}
					}
					else
					{
						message = Messages.MobMsgErrorDoneOperation;
						status = ServiceResultStatus.Fail;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	public bool SendMessage(ref int msgId, int fromUserId, int toUserId, int msgTypeId, string message, int userId, int objectId, int? workflowStepId = null, int? langId = 1065, int? cId = null)
	{
		bool result = true;
		try
		{
			int result2 = 1065;
			if (langId.HasValue)
			{
				int.TryParse(langId.ToString(), out result2);
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result3);
			CRMEntities cRMEntities = new CRMEntities();
			DateTime now = DateTime.Now;
			DateTime value = now;
			string text = now.ToString("yyyyMMdd", new PersianCulture());
			string msgdSendTime = now.ToString("HH:mm:ss", new PersianCulture());
			short value2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Mobile.Classes.Configuration.AppType;
			int.Parse(Financial.Get().Id.ToString());
			ObjectParameter objectParameter = new ObjectParameter("InternalMessageID", 0);
			int? msgdTypeId = msgTypeId;
			int? msgdFromUserId = fromUserId;
			int? msgdToUserId = toUserId;
			DateTime? msgdSendDateTime = value;
			int? msgdAttachRecId = objectId;
			int? userId2 = userId;
			short? year = value2;
			short? month = value3;
			DateTime? registerDate = value;
			int? languageID = result3;
			int? firstRegisterUserId = userId;
			DateTime? firstRegisterDate = value;
			int? msgdAttachRecIdI = workflowStepId;
			Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.HRMMobspInsertInternalMessageSingle(null, null, message, null, msgdTypeId, msgdFromUserId, msgdToUserId, text, msgdSendTime, msgdSendDateTime, null, null, msgdAttachRecId, null, null, userId2, year, month, registerDate, text, appType, languageID, firstRegisterUserId, firstRegisterDate, text, null, objectParameter, msgdAttachRecIdI, null, null, cId));
			int num = (int)objectParameter.Value;
			msgId = num;
			PushNotif.NewIntMsgNotify(withthread: true, cId);
		}
		catch
		{
			result = false;
		}
		return result;
	}

	public bool SetMessageRead(int msgId, int msgTypeId, int? cId = null)
	{
		new InternalTaskCartableController().UpdateInternalMessage("Read", msgId, msgTypeId, cId);
		return true;
	}

	public MobspSelectVerificationWorkFlowWithId_Result GetVerificationWorkFlowWithId(int workflowId = 0, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		MobspSelectVerificationWorkFlowWithId_Result result3 = null;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			cRMSpEntities = new CRMSpEntities();
			MobspSelectVerificationWorkFlowWithId_Result mobspSelectVerificationWorkFlowWithId_Result = Enumerable.FirstOrDefault<MobspSelectVerificationWorkFlowWithId_Result>((IEnumerable<MobspSelectVerificationWorkFlowWithId_Result>)cRMSpEntities.MobspSelectVerificationWorkFlowWithId(workflowId, num, result2));
			if (mobspSelectVerificationWorkFlowWithId_Result != null)
			{
				mobspSelectVerificationWorkFlowWithId_Result.FirstRegisterDatePersian = mobspSelectVerificationWorkFlowWithId_Result.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm");
				mobspSelectVerificationWorkFlowWithId_Result.RegisterDatePersian = mobspSelectVerificationWorkFlowWithId_Result.RegisterDate.ToString("yyyy/MM/dd HH:mm");
				result3 = mobspSelectVerificationWorkFlowWithId_Result;
			}
		}
		catch (Exception)
		{
			result3 = null;
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return result3;
	}

	public List<MobspSelectVerificationWorkFlowSteps_Result> GetVerificationWorkFlowSteps(int workflowId = 0, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectVerificationWorkFlowSteps_Result> result3 = null;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			cRMEntities = new CRMEntities();
			List<MobspSelectVerificationWorkFlowSteps_Result> list = Enumerable.ToList<MobspSelectVerificationWorkFlowSteps_Result>((IEnumerable<MobspSelectVerificationWorkFlowSteps_Result>)cRMEntities.MobspSelectVerificationWorkFlowSteps(workflowId, num, result2));
			if (list != null)
			{
				foreach (MobspSelectVerificationWorkFlowSteps_Result item in list)
				{
					item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm");
					item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd HH:mm");
				}
				result3 = list;
			}
		}
		catch (Exception)
		{
			result3 = null;
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return result3;
	}

	public List<MobspSelectVerificationRequests_Result> GetVerificationRequest(int verificationRequestId = 0, int objectType = 0, int objectId = 0, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectVerificationRequests_Result> result3 = null;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			cRMEntities = new CRMEntities();
			List<MobspSelectVerificationRequests_Result> list = Enumerable.ToList<MobspSelectVerificationRequests_Result>((IEnumerable<MobspSelectVerificationRequests_Result>)cRMEntities.MobspSelectVerificationRequests(verificationRequestId, objectId, objectType, num, result2));
			if (list != null)
			{
				foreach (MobspSelectVerificationRequests_Result item in list)
				{
					item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm");
					item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd HH:mm");
					item.ReplaceUserVerifiedDatePersian = item.ReplaceUserVerifiedDate?.ToString("yyyy/MM/dd HH:mm");
					item.VerificationReqExpiredDatePersian = item.VerificationReqExpiredDateTime?.ToString("yyyy/MM/dd HH:mm");
				}
				result3 = list;
			}
		}
		catch (Exception)
		{
			result3 = null;
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return result3;
	}

	public List<MobspSelectVerificationRequestsByReqId_Result> GetVerificationRequestsByReqId(int requestId = 0, int? ln = 0)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<MobspSelectVerificationRequestsByReqId_Result> result3 = null;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			cRMSpEntities = new CRMSpEntities();
			List<MobspSelectVerificationRequestsByReqId_Result> list = Enumerable.ToList<MobspSelectVerificationRequestsByReqId_Result>((IEnumerable<MobspSelectVerificationRequestsByReqId_Result>)cRMSpEntities.MobspSelectVerificationRequestsByReqId(requestId, num, result2));
			if (list != null)
			{
				foreach (MobspSelectVerificationRequestsByReqId_Result item in list)
				{
					item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm");
					item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd HH:mm");
					item.VerifyDateTimePersian = item.VerifyDateTime?.ToString("yyyy/MM/dd HH:mm");
				}
				result3 = list;
			}
		}
		catch (Exception)
		{
			result3 = null;
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return result3;
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<MobspVerificationRequestBack_Result> BackWorkFloeStep(VerificationRequestsLanguageViewModel vm)
	{
		int result = 1065;
		if (vm.LanguageId.HasValue)
		{
			int.TryParse(vm.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		MobspVerificationRequestBack_Result data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		string text = "";
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					Enumerable.ToList<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)cRMEntities.MobspSelectLanguages());
					DateTime now = DateTime.Now;
					DateTime value = now;
					string text2 = now.ToString("yyyyMMdd", new PersianCulture());
					now.ToString("HH:mm:ss", new PersianCulture());
					short value2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					int value4 = int.Parse(Financial.Get().Id.ToString());
					text = "";
					string @string = Labels.ResourceManager.GetString("VerifiedRequestSubject", new CultureInfo(result2));
					Labels.ResourceManager.GetString("VerifiedRequestVerify", new CultureInfo(result2));
					List<CrmInternalMessage_Lang> value5 = new List<CrmInternalMessage_Lang>();
					ObjectParameter internalMessageId = new ObjectParameter("InternalMessageId", 0);
					new ObjectParameter("result", "");
					MobspVerificationRequestBack_Result mobspVerificationRequestBack_Result = Enumerable.FirstOrDefault<MobspVerificationRequestBack_Result>((IEnumerable<MobspVerificationRequestBack_Result>)cRMSpEntities.MobspVerificationRequestBack(vm.VerificationRequestId, vm.VerificationWorkFlowId, vm.ObjectId, vm.ObjectType, vm.VerifyText, JsonConvert.SerializeObject(value5), @string, registerDate: value, registerDatePersian: text2, userId: token2.userId, fPId: value4, year1: value2, month1: value3, appType: appType, languageID: num, defaultLanguageID: result2, backToStepId: vm.CancellationStepId, verifyText: vm.ReasonCancellation, verifyReqResultId: 7, internalMessageId: internalMessageId, centerId: vm.CenterId));
					if (mobspVerificationRequestBack_Result != null)
					{
						if (mobspVerificationRequestBack_Result.InsertedRequestDetailId.GetValueOrDefault() == 0)
						{
							text += Messages.msgErrorRunFunction;
						}
						else if (mobspVerificationRequestBack_Result.InternalMessageId.GetValueOrDefault() == 0)
						{
							text += Messages.msgErrorRunFunction;
						}
						status = ServiceResultStatus.Success;
						data = mobspVerificationRequestBack_Result;
						message = text;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<MobspVerificationRequestBack_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}

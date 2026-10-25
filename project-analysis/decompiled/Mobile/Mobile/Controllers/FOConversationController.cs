using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using CRM.General.Utilities;
using CRM.Resources;
using Elmah;
using GSD.Globalization;
using Mobile.Cache.Setting;
using Mobile.Classes;
using Mobile.Classes.Helper;
using Mobile.DataType;
using Mobile.Models;

namespace Mobile.Controllers;

public class FOConversationController : ApiController
{
	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<int> InsertConversation(FOInsertConversation model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		int data = 0;
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
				FoToken token2 = new FoCommon().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(Financial.Get().Id.ToString());
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					string mobConversationErjaShow = Messages.MobConversationErjaShow;
					DateTime value4 = now.AddSeconds(-7.0);
					string registerDay = DateTimeClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
					string registerTime = now.ToString("HH:mm:ss");
					List<FOMobspSelectLanguages_Result> list = Enumerable.ToList<FOMobspSelectLanguages_Result>((IEnumerable<FOMobspSelectLanguages_Result>)cRMEntities.FOMobspSelectLanguages());
					short value5 = short.Parse(now.ToString("yyyy", new PersianCulture()));
					int companyId = token2.CompanyId;
					int num2 = -20;
					Mobile.Classes.Helper.User.GetUserName(num2, num, result2);
					Company.GetCmpPersonName(model.CnvsPersonId, num);
					Company.GetCmpProjectTitle(model.CnvsProjectId, num);
					string text = "";
					foreach (FOMobspSelectUserForCnvsReferToMultiUser_Result item in Enumerable.ToList<FOMobspSelectUserForCnvsReferToMultiUser_Result>((IEnumerable<FOMobspSelectUserForCnvsReferToMultiUser_Result>)cRMSpEntities.FOMobspSelectUserForCnvsReferToMultiUser(model.CnvsProjectId, 7, companyId, num, result2, model.CenterId)))
					{
						string text2 = "";
						if (item.cmpAccess == -100)
						{
							text2 = $" ({Messages.FOReferUserCmpNotAccess})";
						}
						text = text + item.FullName + text2 + ",";
					}
					text = ((!string.IsNullOrEmpty(text)) ? text.TrimEnd(new char[1] { ',' }) : "");
					string text3 = "";
					string text4 = "";
					string text5 = "";
					foreach (FOMobspSelectLanguages_Result item2 in list)
					{
						text3 = "";
						text4 = "";
						text3 = MyResource.GetResourceString("FOCnvsErjaFrom", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + " " + Mobile.Classes.Helper.User.GetUserName(num2, result2, item2.LanguageID);
						text4 = MyResource.GetResourceString("FOCnvsErjaInConnection", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + Company.GetCompanyName(companyId, num2, item2.LanguageID, model.CenterId) + "<BR>" + MyResource.GetResourceString("FOCnvsErjaPerson", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + Company.GetCmpPersonName(model.CnvsPersonId, item2.LanguageID) + "<BR>" + MyResource.GetResourceString("FOCnvsErjaProject", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + Company.GetCmpProjectTitle(model.CnvsProjectId, item2.LanguageID);
						if (text != "")
						{
							text4 = text4 + "<BR>" + MyResource.GetResourceString("FOCnvsErjaMultiUser", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + Company.GetMultiReferUserForCnvs(companyId, model.CnvsProjectId, result2, item2.LanguageID, item2.LanguageCollation, model.CenterId);
						}
						text4 = text4 + "<BR><BR>" + MyResource.GetResourceString("FOCnvsErjaConversationDescription", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":<BR>" + model.CnvsDesc.Replace("\r\n", "<BR>");
						text4 = text4 + "<BR><BR>" + MyResource.GetResourceString("FOCnvsErjaDetails", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						text5 = text5 + "MsgSubj=" + text3 + "|@#@|MsgBody=" + text4 + "|@#@|LangId=" + item2.LanguageID + "|@#@||^#^|";
					}
					string text6 = "";
					string text7 = "";
					string text8 = "";
					foreach (FOMobspSelectLanguages_Result item3 in list)
					{
						text6 = "";
						text7 = "";
						text6 = MyResource.GetResourceString("FOCnvsErjaNotice", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + " " + Mobile.Classes.Helper.User.GetUserName(num2, result2, item3.LanguageID);
						text7 = "**" + MyResource.GetResourceString("FOCnvsErjaAutomatically", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<BR><BR>" + MyResource.GetResourceString("FOCnvsErjaAttention", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<BR>" + MyResource.GetResourceString("FOCnvsErjaInConnection", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + Company.GetCompanyName(companyId, num2, item3.LanguageID) + "<BR>" + MyResource.GetResourceString("FOCnvsErjaPerson", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + Company.GetCmpPersonName(model.CnvsPersonId, item3.LanguageID) + "<BR>" + MyResource.GetResourceString("FOCnvsErjaProject", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + Company.GetCmpProjectTitle(model.CnvsProjectId, item3.LanguageID) + "<BR><BR>" + MyResource.GetResourceString("FOCnvsErjaLastNegotiator", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ", " + MyResource.GetResourceString("FOCnvsErjaTransmitter", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<BR>" + MyResource.GetResourceString("FOCnvsErjaMultiUser", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + Company.GetMultiReferUserForCnvs(companyId, model.CnvsProjectId, result2, item3.LanguageID, item3.LanguageCollation, model.CenterId) + "<BR><BR>" + MyResource.GetResourceString("FOCnvsErjaConversationDescription", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": <BR>" + model.CnvsDesc.Replace("\r\n", "<BR>");
						text7 = text7 + "<BR><BR>" + MyResource.GetResourceString("FOCnvsErjaDetails", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						text8 = text8 + "MsgSubj=" + text6 + "|@#@|MsgBody=" + text7 + "|@#@|LangId=" + item3.LanguageID + "|@#@||^#^|";
					}
					string text9 = "";
					string text10 = "";
					string text11 = "";
					if (!string.IsNullOrEmpty(text))
					{
						foreach (FOMobspSelectLanguages_Result item4 in list)
						{
							text9 = "";
							text10 = "";
							text9 = MyResource.GetResourceString("FOCnvsErjaRonevesht", item4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + " " + Mobile.Classes.Helper.User.GetUserName(num2, result2, item4.LanguageID);
							text10 = MyResource.GetResourceString("FOCnvsErjaInConnection", item4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + Company.GetCompanyName(companyId, num2, item4.LanguageID) + "<BR>" + MyResource.GetResourceString("FOCnvsErjaPerson", item4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + Company.GetCmpPersonName(model.CnvsPersonId, item4.LanguageID) + "<BR>" + MyResource.GetResourceString("FOCnvsErjaProject", item4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + Company.GetCmpProjectTitle(model.CnvsProjectId, item4.LanguageID);
							if (text != "")
							{
								text10 = text10 + "<BR>" + MyResource.GetResourceString("FOCnvsErjaMultiUser", item4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + Company.GetMultiReferUserForCnvs(companyId, model.CnvsProjectId, result2, item4.LanguageID, item4.LanguageCollation, model.CenterId);
							}
							text10 = text10 + "<BR><BR>" + MyResource.GetResourceString("FOCnvsErjaConversationDescription", item4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":<BR>" + model.CnvsDesc.Replace("\r\n", "<BR>");
							text10 = text10 + "<BR><BR>" + MyResource.GetResourceString("FOCnvsErjaDetails", item4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
							text11 = text11 + "MsgSubj=" + text9 + "|@#@|MsgBody=" + text10 + "|@#@|LangId=" + item4.LanguageID + "|@#@||^#^|";
						}
					}
					int maxFOCount = Mobile.Classes.Configuration.MaxFOCount;
					FOMobspInsertConversation_Result fOMobspInsertConversation_Result = Enumerable.FirstOrDefault<FOMobspInsertConversation_Result>((IEnumerable<FOMobspInsertConversation_Result>)cRMSpEntities.FOMobspInsertConversation(companyId, model.CnvsProjectId, model.CnvsDesc, model.CnvsPersonId, model.CnvsPriorityId, num2, value, registerDatePersian, registerDay, registerTime, value4, value5, value2, value3, appType, result2, text5, text11, text8, mobConversationErjaShow, 7, model.CenterId, maxFOCount));
					if (fOMobspInsertConversation_Result != null)
					{
						data = fOMobspInsertConversation_Result.ConversationId;
						if (fOMobspInsertConversation_Result.ErrorCount > 0 && !string.IsNullOrEmpty(fOMobspInsertConversation_Result.ErrorMessage))
						{
							string text12 = "";
							if (fOMobspInsertConversation_Result.ErrorMessage.IndexOf("NotReferUser|", StringComparison.Ordinal) >= 0)
							{
								text12 = text12 + Messages.FOMsgErrorNotSelectDefaulCnvsReferUser + ",";
							}
							if (fOMobspInsertConversation_Result.ErrorMessage.IndexOf("NotCnvsStatus|", StringComparison.Ordinal) >= 0)
							{
								text12 = text12 + Messages.FOMsgErrorNotSelectDefaulCnvsStatus + ",";
							}
							if (fOMobspInsertConversation_Result.ErrorMessage.IndexOf("NotCnvsTopic|", StringComparison.Ordinal) >= 0)
							{
								text12 = text12 + Messages.FOMsgErrorNotSelectDefaulCnvsTopic + ",";
							}
							if (fOMobspInsertConversation_Result.ErrorMessage.IndexOf("NotSendedSMS|", StringComparison.Ordinal) >= 0)
							{
								text12 = text12 + Messages.FOMsgErrorNotSendedSMSInCnvs + ",";
							}
							if (fOMobspInsertConversation_Result.ErrorMessage.IndexOf("MoreThanAllowInsCnvs|", StringComparison.Ordinal) >= 0)
							{
								text12 = text12 + string.Format(Messages.FOMsgErrorCnvsBeforeAnswerCount, "3") + ",";
								message = string.Format(Messages.FOMsgErrorCnvsBeforeAnswerCount, "3");
							}
							message = text12;
							status = ServiceResultStatus.Fail;
						}
						else
						{
							PushNotif.NewIntMsgNotify(withthread: true, model.CenterId);
							message = Messages.MobMsgSuccessAction;
							status = ServiceResultStatus.Success;
						}
					}
					else
					{
						message = Messages.FOMsgErrorDoneOperation;
						status = ServiceResultStatus.Fail;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = 0;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = 0;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = 0;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<int>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}

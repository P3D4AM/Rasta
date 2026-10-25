using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using CRM.General.Security;
using CRM.General.Utilities;
using CRMIdealApi.ApiModels;
using CRMIdealApi.Classes;
using CRMIdealApi.Classes.Helper;
using CRMIdealApi.DataType;
using CRMIdealApi.Resources;
using Elmah;
using GSD.Globalization;

namespace CRMIdealApi.Controllers;

public class ApiConversationController : ApiController
{
	[HttpPost]
	public ServiceResult<int> Insert(InsertConversationViewModel model)
	{
		CRMEntities cRMEntities = null;
		if (model.ApiCompanyId <= 0)
		{
			model.ApiCompanyId = null;
		}
		if (model.ApiPersonId <= 0)
		{
			model.ApiPersonId = null;
		}
		if (model.ApiProjectId <= 0)
		{
			model.ApiProjectId = null;
		}
		if (model.ApiCnvsTopicId <= 0)
		{
			model.ApiCnvsTopicId = null;
		}
		if (model.ApiCnvsUserId <= 0)
		{
			model.ApiCnvsUserId = null;
		}
		if (model.ApiCnvsReferUserId <= 0)
		{
			model.ApiCnvsReferUserId = null;
		}
		if (model.ApiCnvsStatusId <= 0)
		{
			model.ApiCnvsStatusId = null;
		}
		if (model.ApiCnvsPriorityId <= 0)
		{
			model.ApiCnvsPriorityId = null;
		}
		int data = 0;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<int>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<int>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int.TryParse(model.LanguageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string culture = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				culture = apispSelectLanguages_Result.LanguageCollation;
			}
			string cnvsDate = null;
			string cnvsDay = null;
			string cnvsTime = null;
			string cnvsRemindDate = null;
			string cnvsRemindDateForAllarm = null;
			string cnvsCoordinateLastDatePersian = null;
			string text = null;
			try
			{
				if (!string.IsNullOrEmpty(model.ApiCnvsRemindTime))
				{
					text = model.ApiCnvsRemindTime;
					string s = DateTime.Now.ToString("yyyy/MM/dd") + " " + text;
					DateTime dateTime = DateTime.Parse(s, new PersianCulture());
					if (text.Length > 5)
					{
						text = text.Substring(0, 5);
					}
				}
			}
			catch (Exception)
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CnvsRemindTime", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			try
			{
				if (model.ApiCnvsDateTime.HasValue)
				{
					cnvsDate = (model.ApiCnvsDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
					cnvsDay = commonClass.ConvertNameToDayNum((model.ApiCnvsDateTime ?? DateTime.Now).DayOfWeek.ToString());
					cnvsTime = (model.ApiCnvsDateTime ?? DateTime.Now).ToString("HH:mm:ss");
				}
			}
			catch (Exception)
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CnvsDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			try
			{
				if (model.ApiCnvsRemindDateTime.HasValue)
				{
					cnvsRemindDate = (model.ApiCnvsRemindDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
				}
			}
			catch (Exception)
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CnvsRemindDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			try
			{
				if (model.ApiCnvsRemindDateTimeForAllarm.HasValue)
				{
					string s2 = (model.ApiCnvsRemindDateTimeForAllarm ?? DateTime.Now).ToString("yyyy/MM/dd") + " " + text;
					model.ApiCnvsRemindDateTimeForAllarm = DateTime.Parse(s2, new CultureInfo("en-US"));
					cnvsRemindDateForAllarm = (model.ApiCnvsRemindDateTimeForAllarm ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
				}
			}
			catch (Exception)
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CnvsRemindDateForAllarm", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			try
			{
				if (model.ApiCnvsCoordinateLastDate.HasValue)
				{
					cnvsCoordinateLastDatePersian = (model.ApiCnvsCoordinateLastDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
				}
			}
			catch (Exception)
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CnvsCoordinateLastDatePersian", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (!string.IsNullOrEmpty(model.Password))
			{
				model.Password = CodeDecode.DeCodding(model.Password);
			}
			if (!string.IsNullOrEmpty(model.UserName))
			{
				model.UserName = CodeDecode.DeCodding(model.UserName);
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(model.UserName, model.Password));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 == 0)
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (string.IsNullOrEmpty(model.ApiCnvsDesc))
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorItemIsNotEntered", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CnvsDesc", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			string text2 = ((!string.IsNullOrEmpty(model.ApiCnvsDesc)) ? model.ApiCnvsDesc.Replace("\r\n", "<BR>") : "");
			string text3 = ((!string.IsNullOrEmpty(model.ApiCnvsReferDesc)) ? model.ApiCnvsReferDesc.Replace("\r\n", "<BR>") : "");
			string userName = CommonClass.GetUserName(model.UserId, result, result);
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string dubClickDisplayCmpInfo = Messages.DubClickDisplayCmpInfo;
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			short num2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
			string registerDay = commonClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
			string registerTime = now.ToString("HH:mm:ss");
			string person = Labels.Person;
			string resourceString = MyResource.GetResourceString("DefualtPrjTitle", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
			string text4 = "";
			string text5 = "";
			string text6 = "";
			foreach (ApispSelectLanguages_Result item in list)
			{
				string text7 = "";
				string text8 = "";
				string text9 = "";
				string text10 = "";
				string text11 = resourceString;
				text9 = Company.GetCompanyName(model.ApiCompanyId.GetValueOrDefault(), model.ApiCmpNumber.GetValueOrDefault(), model.ApiCmpCode, result, item.LanguageID);
				if (model.ApiPersonId.HasValue && model.ApiPersonId > 0)
				{
					text10 = Company.GetPersonName(model.ApiPersonId.GetValueOrDefault(), result, item.LanguageID);
				}
				if (model.ApiProjectId.HasValue && model.ApiProjectId > 0)
				{
					text11 = Company.GetProjectTitle(model.ApiProjectId.GetValueOrDefault(), result, item.LanguageID);
				}
				else if (string.IsNullOrEmpty(model.ApiPrjTitle))
				{
					text11 = model.ApiPrjTitle;
				}
				text7 = ((!string.IsNullOrEmpty(model.ApiCnvsDesc)) ? model.ApiCnvsDesc.Replace("\r\n", "<BR>") : text7);
				text8 = ((!string.IsNullOrEmpty(model.ApiCnvsReferDesc)) ? model.ApiCnvsReferDesc.Replace("\r\n", "<BR>") : text8);
				text4 = "";
				text5 = "";
				text4 = MyResource.GetResourceString("ErjaFrom", item.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + " " + CommonClass.GetUserName(model.UserId, result, item.LanguageID);
				text5 = MyResource.GetResourceString("ErjaInConnection", item.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + text9 + "<BR>" + MyResource.GetResourceString("ErjaPerson", item.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + text10 + "<BR>" + MyResource.GetResourceString("ErjaProject", item.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + text11;
				if (!string.IsNullOrEmpty(model.ApiCnvsReferToMultilUser))
				{
					string[] array = model.ApiCnvsReferToMultilUser.Split(new char[1] { ',' });
					if (Enumerable.Any<string>((IEnumerable<string>)array))
					{
						string text12 = "";
						string[] array2 = array;
						foreach (string text13 in array2)
						{
							int num3 = ((!string.IsNullOrEmpty(text13)) ? int.Parse(text13) : 0);
							if (num3 > 0)
							{
								string text14 = ((num3 > 0) ? CommonClass.GetUserName(num3, result, item.LanguageID) : "");
								text12 = text12 + text14 + ",";
							}
						}
						text12 = ((!string.IsNullOrEmpty(text12)) ? text12.TrimEnd(new char[1] { ',' }) : "");
						if (text12 != "")
						{
							text5 = text5 + "<BR>" + MyResource.GetResourceString("ErjaMultiUser", item.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + text12;
						}
					}
				}
				text5 = text5 + "<BR><BR>" + MyResource.GetResourceString("ErjaConversationDescription", item.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":<BR>" + text7.Replace("\r\n", "<BR>");
				string text15 = text8;
				if (!string.IsNullOrEmpty(text15))
				{
					text5 = text5 + "<BR>" + MyResource.GetResourceString("ErjaReferDescription", item.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":<BR>" + text15.Replace("\r\n", "<BR>");
				}
				text5 = text5 + "<BR><BR>" + MyResource.GetResourceString("ErjaDetails", item.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				text6 = text6 + "MsgSubj=" + text4 + "|@#@|MsgBody=" + text5 + "|@#@|LangId=" + item.LanguageID + "|@#@||^#^|";
			}
			string text16 = "";
			string text17 = "";
			string text18 = "";
			if (!string.IsNullOrEmpty(model.ApiCnvsReferToMultilUser))
			{
				string[] array3 = model.ApiCnvsReferToMultilUser.Split(new char[1] { ',' });
				if (Enumerable.Any<string>((IEnumerable<string>)array3))
				{
					foreach (ApispSelectLanguages_Result item2 in list)
					{
						string text19 = "";
						string[] array4 = array3;
						foreach (string text20 in array4)
						{
							int num4 = ((!string.IsNullOrEmpty(text20)) ? int.Parse(text20) : 0);
							if (num4 > 0)
							{
								string text21 = ((num4 > 0) ? CommonClass.GetUserName(num4, result, item2.LanguageID) : "");
								text19 = text19 + text21 + ",";
							}
						}
						text19 = ((!string.IsNullOrEmpty(text19)) ? text19.TrimEnd(new char[1] { ',' }) : "");
						string text22 = "";
						string text23 = "";
						string text24 = "";
						string text25 = "";
						string text26 = resourceString;
						text24 = Company.GetCompanyName(model.ApiCompanyId.GetValueOrDefault(), model.ApiCmpNumber.GetValueOrDefault(), model.ApiCmpCode, result, item2.LanguageID);
						if (model.ApiPersonId.HasValue && model.ApiPersonId > 0)
						{
							text25 = Company.GetPersonName(model.ApiPersonId.GetValueOrDefault(), result, item2.LanguageID);
						}
						if (model.ApiProjectId.HasValue && model.ApiProjectId > 0)
						{
							text26 = Company.GetProjectTitle(model.ApiProjectId.GetValueOrDefault(), result, item2.LanguageID);
						}
						else if (string.IsNullOrEmpty(model.ApiPrjTitle))
						{
							text26 = model.ApiPrjTitle;
						}
						text22 = ((!string.IsNullOrEmpty(model.ApiCnvsDesc)) ? model.ApiCnvsDesc.Replace("\r\n", "<BR>") : text22);
						text23 = ((!string.IsNullOrEmpty(model.ApiCnvsReferDesc)) ? model.ApiCnvsReferDesc.Replace("\r\n", "<BR>") : text23);
						text16 = "";
						text17 = "";
						text16 = MyResource.GetResourceString("ErjaRonevesht", item2.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + " " + CommonClass.GetUserName(model.UserId, result, item2.LanguageID);
						text17 = MyResource.GetResourceString("ErjaInConnection", item2.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + text24 + "<BR>" + MyResource.GetResourceString("ErjaPerson", item2.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + text25 + "<BR>" + MyResource.GetResourceString("ErjaProject", item2.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + text26;
						if (text19 != "")
						{
							text17 = text17 + "<BR>" + MyResource.GetResourceString("ErjaMultiUser", item2.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + text19;
						}
						text17 = text17 + "<BR><BR>" + MyResource.GetResourceString("ErjaConversationDescription", item2.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":<BR>" + text22.Replace("\r\n", "<BR>");
						text17 = text17 + "<BR><BR>" + MyResource.GetResourceString("ErjaDetails", item2.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						text18 = text18 + "MsgSubj=" + text16 + "|@#@|MsgBody=" + text17 + "|@#@|LangId=" + item2.LanguageID + "|@#@||^#^|";
					}
				}
			}
			string text27 = "";
			string text28 = "";
			string text29 = "";
			foreach (ApispSelectLanguages_Result item3 in list)
			{
				string text30 = "";
				string text31 = "";
				string text32 = "";
				string text33 = "";
				string text34 = resourceString;
				text32 = Company.GetCompanyName(model.ApiCompanyId.GetValueOrDefault(), model.ApiCmpNumber.GetValueOrDefault(), model.ApiCmpCode, result, item3.LanguageID);
				if (model.ApiPersonId.HasValue && model.ApiPersonId > 0)
				{
					text33 = Company.GetPersonName(model.ApiPersonId.GetValueOrDefault(), result, item3.LanguageID);
				}
				if (model.ApiProjectId.HasValue && model.ApiProjectId > 0)
				{
					text34 = Company.GetProjectTitle(model.ApiProjectId.GetValueOrDefault(), result, item3.LanguageID);
				}
				else if (string.IsNullOrEmpty(model.ApiPrjTitle))
				{
					text34 = model.ApiPrjTitle;
				}
				text30 = ((!string.IsNullOrEmpty(model.ApiCnvsDesc)) ? model.ApiCnvsDesc.Replace("\r\n", "<BR>") : text30);
				text31 = ((!string.IsNullOrEmpty(model.ApiCnvsReferDesc)) ? model.ApiCnvsReferDesc.Replace("\r\n", "<BR>") : text31);
				text27 = "";
				text28 = "";
				text27 = MyResource.GetResourceString("ErjaNotice", item3.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + CommonClass.GetUserName(model.UserId, result, item3.LanguageID);
				text28 = "**" + MyResource.GetResourceString("ErjaAutomatically", item3.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<BR><BR>" + MyResource.GetResourceString("ErjaAttention", item3.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<BR>" + MyResource.GetResourceString("ErjaInConnection", item3.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + text32 + "<BR>" + MyResource.GetResourceString("ErjaPerson", item3.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + text33 + "<BR>" + MyResource.GetResourceString("ErjaProject", item3.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + text34 + "<BR><BR>" + MyResource.GetResourceString("ErjaLastNegotiator", item3.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ", " + MyResource.GetResourceString("ErjaTransmitte", item3.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<BR>";
				if (!string.IsNullOrEmpty(model.ApiCnvsReferToMultilUser))
				{
					string[] array5 = model.ApiCnvsReferToMultilUser.Split(new char[1] { ',' });
					if (Enumerable.Any<string>((IEnumerable<string>)array5))
					{
						string text35 = "";
						string[] array6 = array5;
						foreach (string text36 in array6)
						{
							int num5 = ((!string.IsNullOrEmpty(text36)) ? int.Parse(text36) : 0);
							if (num5 > 0)
							{
								string text37 = ((num5 > 0) ? CommonClass.GetUserName(num5, result, item3.LanguageID) : "");
								text35 = text35 + text37 + ",";
							}
						}
						text35 = ((!string.IsNullOrEmpty(text35)) ? text35.TrimEnd(new char[1] { ',' }) : "");
						if (text35 != "")
						{
							text28 = text28 + MyResource.GetResourceString("ErjaMultiUser", item3.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + text35;
						}
					}
				}
				text28 = text28 + "<BR><BR>" + MyResource.GetResourceString("ErjaConversationDescription", item3.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":<BR>" + text30.Replace("\r\n", "<BR>");
				string text38 = text31;
				if (!string.IsNullOrEmpty(text38))
				{
					text28 = text28 + "<BR>" + MyResource.GetResourceString("ErjaReferDescription", item3.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":<BR>" + text38.Replace("\r\n", "<BR>");
				}
				text28 = text28 + "<BR><BR>" + MyResource.GetResourceString("ErjaDetails", item3.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				text29 = text29 + "MsgSubj=" + text27 + "|@#@|MsgBody=" + text28 + "|@#@|LangId=" + item3.LanguageID + "|@#@||^#^|";
			}
			ObjectParameter objectParameter = new ObjectParameter("InsertedConversationId", 0);
			ObjectParameter objectParameter2 = new ObjectParameter("ErrorMessage", "");
			string text39 = "";
			string surveyMainExtrenalLink = "";
			string surveyMainExtrenalLinkLogin = "";
			string leftPart = base.Request.RequestUri.GetLeftPart(UriPartial.Authority);
			string leftPart2 = base.Request.RequestUri.GetLeftPart(UriPartial.Scheme);
			string text40 = leftPart;
			if (text40.EndsWith("/"))
			{
				text40 = text40.TrimEnd(new char[1] { '/' });
			}
			text40 += "/Survey/Home/SurveyAnswerValues";
			text39 = text40;
			int? num6 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispInsertConversation(model.ApiCompanyId, model.ApiCmpNumber, model.ApiCmpCode, model.ApiPersonId, model.ApiProjectId, model.ApiPrjTitle, resourceString, cnvsDate, cnvsDay, cnvsTime, model.ApiCnvsDateTime, model.ApiCnvsTopicId, model.ApiCnvsSubject, model.ApiCnvsDesc, model.ApiCnvsUserId, model.ApiCnvsReferUserId, model.ApiCnvsReferDesc, model.ApiCnvsStatusId, model.ApiCnvsPriorityId, cnvsRemindDate, text, model.ApiCnvsRemindDateTime, model.ApiCnvsRemindOk, model.ApiCnvsIsBookMark, cnvsRemindDateForAllarm, model.ApiCnvsRemindDateTimeForAllarm, model.ApiCnvsApiId, model.ApiCnvsFOCmpCanSee, model.ApiCnvsIsTicket, model.ApiCnvsCoordinateLatitude, model.ApiCnvsCoordinateLongitude, model.ApiCnvsCoordinateLastDate, cnvsCoordinateLastDatePersian, model.ApiCnvsTicketIsRead, model.ApiCnvsDoingTime, model.ApiCnvsIsCopy, model.ApiCnvsReferToMultilUser, model.ApiCnvsEventPolicyNeedCheck, userId, value2, value, registerDatePersian, registerTime, registerDay, appType, result, text6, text29, text18, dubClickDisplayCmpInfo, objectParameter, objectParameter2, model.ApiCnvsStatusResultId, text39, surveyMainExtrenalLink, surveyMainExtrenalLinkLogin, model.CenterId, model.CenterCode));
			string resourceString2 = MyResource.GetResourceString("ErrorDoneOperationTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			string resourceString3 = MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			int result3 = 0;
			int.TryParse(num6.ToString(), out result3);
			if (result3 <= 0)
			{
				return new ServiceResult<int>
				{
					Message = resourceString2.Replace("<br>", "\r\n"),
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			if (objectParameter2.Value != null && objectParameter2.Value.ToString() != "")
			{
				string text41 = "";
				string text42 = "";
				string text43 = objectParameter2.Value.ToString();
				if (text43.IndexOf("IsUser=0", StringComparison.Ordinal) >= 0)
				{
					text41 = text41 + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					resourceString3 = "<br>" + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString3;
					return new ServiceResult<int>
					{
						Message = resourceString3.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text43.IndexOf("No Center|", StringComparison.Ordinal) >= 0)
				{
					text42 = text42 + MyResource.GetResourceString("msgErrorCenterNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text42.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text43.IndexOf("MustFullCnvsRemindDate|", StringComparison.Ordinal) >= 0)
				{
					text42 = text42 + MyResource.GetResourceString("ErrorMustFullCnvsRemindDate", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text42.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text43.IndexOf("No CmpId|", StringComparison.Ordinal) >= 0)
				{
					text42 = text42 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Company", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text42.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text43.IndexOf("No PrsId|", StringComparison.Ordinal) >= 0)
				{
					text42 = text42 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CnvsPerson", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text42.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text43.IndexOf("No PrjId|", StringComparison.Ordinal) >= 0)
				{
					text42 = text42 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Project", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text42.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text43.IndexOf("No CnvsTopicId|", StringComparison.Ordinal) >= 0)
				{
					text42 = text42 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CnvsTopic", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text42.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text43.IndexOf("No CnvsUserId|", StringComparison.Ordinal) >= 0)
				{
					text42 = text42 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CnvsUser", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text42.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text43.IndexOf("No CnvsReferUserId|", StringComparison.Ordinal) >= 0)
				{
					text42 = text42 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CnvsReferUser", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text42.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text43.IndexOf("No CnvsStatusId|", StringComparison.Ordinal) >= 0)
				{
					text42 = text42 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CnvsStatus", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text42.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text43.IndexOf("No CnvsPriorityId|", StringComparison.Ordinal) >= 0)
				{
					text42 = text42 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CnvsPriority", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text42.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text43.IndexOf("No CnvsReferToMultilUser|", StringComparison.Ordinal) >= 0)
				{
					text42 = text42 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CnvsReferToMultilUser", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text42.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text43.IndexOf("ForcedStatus=", StringComparison.Ordinal) >= 0)
				{
					string text44 = "";
					text44 = text43;
					text44 = text44.Replace("ForcedStatus=", "").Replace("|", "");
					text42 = text42 + string.Format(MyResource.GetResourceString("ErrorForcedStatus", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), text44) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text42.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text43.IndexOf("No CnvsStatusResultId|", StringComparison.Ordinal) >= 0)
				{
					text42 = text42 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CnvsStatusResult", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text42.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
			}
			else
			{
				if (objectParameter == null || objectParameter.Value.ToString() == "0")
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = (MyResource.GetResourceString("ErrorDoneOperation", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>" + resourceString2).Replace("<br>", "\r\n");
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Fail;
					return serviceResult;
				}
				PushNotif.NewIntMsgNotify(currLangId, result);
				int result4 = model.ApiCompanyId.GetValueOrDefault();
				if (result4 == 0)
				{
					int.TryParse(Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispReturnCompanyId(model.ApiCmpNumber, model.ApiCmpCode)).ToString(), out result4);
				}
				if (result4 != 0)
				{
					string errorMsg = "";
					bool flag = OtherSystems.SendCmpToLinkAccByShpIsActive(result4, model.CenterId.GetValueOrDefault(), model.CenterCode ?? "", ref errorMsg);
				}
				data = ((objectParameter.Value != null) ? int.Parse(objectParameter.Value.ToString() ?? "0") : 0);
				message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception ex6)
		{
			string text45 = ((!string.IsNullOrEmpty(ex6.Message)) ? ex6.Message : "");
			if (ex6.InnerException != null && !string.IsNullOrEmpty(ex6.InnerException.Message))
			{
				text45 = text45 + " - " + ex6.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text45)) ? (" (" + text45 + ")") : "");
			data = 0;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex6);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<int>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<int> Update(UpdateConversationViewModel model)
	{
		CRMEntities cRMEntities = null;
		int data = 0;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<int>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<int>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int.TryParse(model.LanguageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string culture = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				culture = apispSelectLanguages_Result.LanguageCollation;
			}
			string text = null;
			string text2 = null;
			string text3 = null;
			string text4 = null;
			string cnvsRemindDateForAllarm = null;
			string cnvsCoordinateLastDatePersian = null;
			string text5 = null;
			if (!string.IsNullOrEmpty(model.ApiCnvsRemindTime) && model.ApiCnvsRemindTime.ToLower() == "null")
			{
				text5 = model.ApiCnvsRemindTime;
			}
			else
			{
				if (!model.ApiCnvsRemindDateTimeForAllarm.HasValue && !string.IsNullOrEmpty(model.ApiCnvsRemindTime) && model.ApiCnvsRemindTime.ToLower() != "null")
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = MyResource.GetResourceString("ErrorAlarmcnvsRemindTime", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Fail;
					return serviceResult;
				}
				try
				{
					if (!string.IsNullOrEmpty(model.ApiCnvsRemindTime))
					{
						text5 = model.ApiCnvsRemindTime;
						string s = DateTime.Now.ToString("yyyy/MM/dd") + " " + text5;
						DateTime dateTime = DateTime.Parse(s, new PersianCulture());
						if (text5.Length > 5)
						{
							text5 = text5.Substring(0, 5);
						}
					}
				}
				catch (Exception)
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CnvsRemindTime", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCnvsDate) && model.ApiCnvsDate.ToLower() == "null")
			{
				text = model.ApiCnvsDate;
				model.ApiCnvsDateTime = null;
				text2 = "null";
				text3 = "null";
			}
			else
			{
				try
				{
					if (model.ApiCnvsDateTime.HasValue)
					{
						text = (model.ApiCnvsDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
						text2 = commonClass.ConvertNameToDayNum((model.ApiCnvsDateTime ?? DateTime.Now).DayOfWeek.ToString());
						text3 = (model.ApiCnvsDateTime ?? DateTime.Now).ToString("HH:mm:ss");
					}
				}
				catch (Exception)
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CnvsDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCnvsRemindDate) && model.ApiCnvsRemindDate.ToLower() == "null")
			{
				text4 = model.ApiCnvsRemindDate;
				model.ApiCnvsRemindDateTime = null;
			}
			else
			{
				try
				{
					if (model.ApiCnvsRemindDateTime.HasValue)
					{
						text4 = (model.ApiCnvsRemindDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
					}
				}
				catch (Exception)
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CnvsRemindDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCnvsRemindDateForAllarm) && model.ApiCnvsRemindDateForAllarm.ToLower() == "null")
			{
				cnvsRemindDateForAllarm = model.ApiCnvsRemindDateForAllarm;
				model.ApiCnvsRemindDateTimeForAllarm = null;
			}
			else
			{
				if (model.ApiCnvsRemindDateTimeForAllarm.HasValue && (string.IsNullOrEmpty(model.ApiCnvsRemindTime) || model.ApiCnvsRemindTime.ToLower() == "null"))
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = MyResource.GetResourceString("ErrorAlarmcnvsRemindDateForAllarm", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Fail;
					return serviceResult;
				}
				try
				{
					if (model.ApiCnvsRemindDateTimeForAllarm.HasValue)
					{
						string s2 = (model.ApiCnvsRemindDateTimeForAllarm ?? DateTime.Now).ToString("yyyy/MM/dd") + " " + ((text5 != "null" && !string.IsNullOrEmpty(text5)) ? text5 : DateTime.Now.ToString("HH:mm:ss"));
						model.ApiCnvsRemindDateTimeForAllarm = DateTime.Parse(s2, new CultureInfo("en-US"));
						cnvsRemindDateForAllarm = (model.ApiCnvsRemindDateTimeForAllarm ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
					}
				}
				catch (Exception)
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CnvsRemindDateForAllarm", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCnvsCoordinateLastDatePersian) && model.ApiCnvsCoordinateLastDatePersian.ToLower() == "null")
			{
				cnvsCoordinateLastDatePersian = model.ApiCnvsCoordinateLastDatePersian;
				model.ApiCnvsCoordinateLastDate = null;
			}
			else
			{
				try
				{
					if (model.ApiCnvsCoordinateLastDate.HasValue)
					{
						cnvsCoordinateLastDatePersian = (model.ApiCnvsCoordinateLastDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
					}
				}
				catch (Exception)
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CnvsCoordinateLastDatePersian", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCnvsDoingTimeStr) && model.ApiCnvsDoingTimeStr.ToLower() == "null")
			{
				model.ApiCnvsDoingTime = null;
			}
			else if (model.ApiCnvsDoingTime.HasValue)
			{
				model.ApiCnvsDoingTimeStr = model.ApiCnvsDoingTime.ToString();
			}
			if (!string.IsNullOrEmpty(model.Password))
			{
				model.Password = CodeDecode.DeCodding(model.Password);
			}
			if (!string.IsNullOrEmpty(model.UserName))
			{
				model.UserName = CodeDecode.DeCodding(model.UserName);
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(model.UserName, model.Password));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 == 0)
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiConversationId <= 0)
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("ErrorNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Fail;
				return serviceResult;
			}
			if (model.ApiCnvsUserId.HasValue && model.ApiCnvsReferUserId.HasValue && model.ApiCnvsUserId != model.ApiCnvsReferUserId && !model.ApiCnvsRemindDateTime.HasValue)
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("ErrorNotMatchUserIdReferIDAndSetRemideDate", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Fail;
				return serviceResult;
			}
			string userName = CommonClass.GetUserName(model.UserId, result, result);
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string dubClickDisplayCmpInfo = Messages.DubClickDisplayCmpInfo;
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			short num2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
			string text6 = commonClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
			string text7 = now.ToString("HH:mm:ss");
			string person = Labels.Person;
			string resourceString = MyResource.GetResourceString("DefualtPrjTitle", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
			ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
			int num3 = cRMEntities.ApispUpdateConversation(model.ApiConversationId, model.ApiCompanyId, model.ApiProjectId, model.ApiPersonId, text, text2, text3, cnvsDateTime: model.ApiCnvsDateTime, cnvsTopicId: model.ApiCnvsTopicId, cnvsSubject: model.ApiCnvsSubject, cnvsDesc: model.ApiCnvsDesc, cnvsUserId: model.ApiCnvsUserId, cnvsReferUserId: model.ApiCnvsReferUserId, cnvsReferDesc: model.ApiCnvsReferDesc, cnvsStatusId: model.ApiCnvsStatusId, cnvsPriorityId: model.ApiCnvsPriorityId, cnvsRemindDate: text4, cnvsRemindTime: text5, cnvsRemindDateTime: model.ApiCnvsRemindDateTime, cnvsRemindOk: model.ApiCnvsRemindOk, cnvsIsBookMark: model.ApiCnvsIsBookMark, cnvsRemindDateForAllarm: cnvsRemindDateForAllarm, cnvsRemindDateTimeForAllarm: model.ApiCnvsRemindDateTimeForAllarm, apiId: model.ApiCnvsApiId, cnvsFOCmpCanSee: model.ApiCnvsFOCmpCanSee, cnvsIsTicket: model.ApiCnvsIsTicket, cnvsCoordinateLatitude: model.ApiCnvsCoordinateLatitude, cnvsCoordinateLongitude: model.ApiCnvsCoordinateLongitude, cnvsCoordinateLastDate: model.ApiCnvsCoordinateLastDate, cnvsCoordinateLastDatePersian: cnvsCoordinateLastDatePersian, cnvsTicketIsRead: model.ApiCnvsTicketIsRead, doingTime: model.ApiCnvsDoingTimeStr, cnvsDoingTime: model.ApiCnvsDoingTime, cnvsIsCopy: model.ApiCnvsIsCopy, userId: userId, year1: (short)1, month1: value2, registerDate: value, registerDatePersian: registerDatePersian, appType: appType, languageID: currLangId, defaultLanguageID: result, errorMessage: objectParameter, cnvsStatusResultId: model.ApiCnvsStatusResultId);
			string resourceString2 = MyResource.GetResourceString("ErrorDoneOperationTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			string resourceString3 = MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			int result3 = 0;
			int.TryParse(num3.ToString(), out result3);
			if (result3 < 0 && objectParameter.Value == null)
			{
				return new ServiceResult<int>
				{
					Message = resourceString2.Replace("<br>", "\r\n"),
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			if (objectParameter.Value != null && objectParameter.Value.ToString() != "")
			{
				string text8 = "";
				string text9 = "";
				string text10 = objectParameter.Value.ToString();
				if (text10.IndexOf("IsUser=0", StringComparison.Ordinal) >= 0)
				{
					text8 = text8 + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					resourceString3 = "<br>" + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString3;
					return new ServiceResult<int>
					{
						Message = resourceString3.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text10.IndexOf("No Center|", StringComparison.Ordinal) >= 0)
				{
					text9 = text9 + MyResource.GetResourceString("msgErrorCenterNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text9.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text10.IndexOf("MustFullCnvsRemindDate|", StringComparison.Ordinal) >= 0)
				{
					text9 = text9 + MyResource.GetResourceString("ErrorMustFullCnvsRemindDate", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text9.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text10.IndexOf("No CmpId|", StringComparison.Ordinal) >= 0)
				{
					text9 = text9 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Company", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text9.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text10.IndexOf("No PrsId|", StringComparison.Ordinal) >= 0)
				{
					text9 = text9 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CnvsPerson", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text9.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text10.IndexOf("No PrjId|", StringComparison.Ordinal) >= 0)
				{
					text9 = text9 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Project", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text9.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text10.IndexOf("No CnvsTopicId|", StringComparison.Ordinal) >= 0)
				{
					text9 = text9 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CnvsTopic", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text9.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text10.IndexOf("No CnvsUserId|", StringComparison.Ordinal) >= 0)
				{
					text9 = text9 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CnvsUser", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text9.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text10.IndexOf("No CnvsReferUserId|", StringComparison.Ordinal) >= 0)
				{
					text9 = text9 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CnvsReferUser", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text9.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text10.IndexOf("No CnvsStatusId|", StringComparison.Ordinal) >= 0)
				{
					text9 = text9 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CnvsStatus", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text9.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text10.IndexOf("No CnvsPriorityId|", StringComparison.Ordinal) >= 0)
				{
					text9 = text9 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CnvsPriority", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text9.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text10.IndexOf("No CnvsReferToMultilUser|", StringComparison.Ordinal) >= 0)
				{
					text9 = text9 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CnvsReferToMultilUser", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text9.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text10.IndexOf("ForcedStatus=", StringComparison.Ordinal) >= 0)
				{
					string text11 = "";
					text11 = text10;
					text11 = text11.Replace("ForcedStatus=", "").Replace("|", "");
					text9 = text9 + string.Format(MyResource.GetResourceString("ErrorForcedStatus", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), text11) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text9.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text10.IndexOf("No CnvsStatusResultId|", StringComparison.Ordinal) >= 0)
				{
					text9 = text9 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CnvsStatusResult", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text9.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
			}
			else
			{
				data = 1;
				message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception ex6)
		{
			string text12 = ((!string.IsNullOrEmpty(ex6.Message)) ? ex6.Message : "");
			if (ex6.InnerException != null && !string.IsNullOrEmpty(ex6.InnerException.Message))
			{
				text12 = text12 + " - " + ex6.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text12)) ? (" (" + text12 + ")") : "");
			data = 0;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex6);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<int>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<List<ApispSelectConversation_Result>> Select(SelectConversationViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispSelectConversation_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispSelectConversation_Result>>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<List<ApispSelectConversation_Result>>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int.TryParse(model.LanguageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string culture = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				culture = apispSelectLanguages_Result.LanguageCollation;
			}
			if (!string.IsNullOrEmpty(model.Password))
			{
				model.Password = CodeDecode.DeCodding(model.Password);
			}
			if (!string.IsNullOrEmpty(model.UserName))
			{
				model.UserName = CodeDecode.DeCodding(model.UserName);
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(model.UserName, model.Password));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 == 0)
			{
				ServiceResult<List<ApispSelectConversation_Result>> serviceResult = new ServiceResult<List<ApispSelectConversation_Result>>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			model.PageSize = ((model.PageNumber.HasValue && model.PageNumber > 0 && (!model.PageSize.HasValue || model.PageSize == 0)) ? new int?(20) : model.PageSize);
			List<ApispSelectConversation_Result> list2 = Enumerable.ToList<ApispSelectConversation_Result>((IEnumerable<ApispSelectConversation_Result>)cRMEntities.ApispSelectConversation(model.ApiConversationId, model.ApiProjectId, model.ApiCompanyId, currLangId, result, model.CenterId, model.CenterCode, model.PageNumber, model.PageSize));
			if (list2 != null)
			{
				message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
			else
			{
				message = MyResource.GetResourceString("ErrorNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Fail;
			}
			data = list2;
		}
		catch (Exception ex)
		{
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<ApispSelectConversation_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<bool> Delete(DeleteConversationViewModel model)
	{
		CRMEntities cRMEntities = null;
		bool data = false;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<bool>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = false,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<bool>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = false,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int.TryParse(model.LanguageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string culture = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				culture = apispSelectLanguages_Result.LanguageCollation;
			}
			if (!string.IsNullOrEmpty(model.Password))
			{
				model.Password = CodeDecode.DeCodding(model.Password);
			}
			if (!string.IsNullOrEmpty(model.UserName))
			{
				model.UserName = CodeDecode.DeCodding(model.UserName);
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(model.UserName, model.Password));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 == 0)
			{
				ServiceResult<bool> serviceResult = new ServiceResult<bool>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = false;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiConversationId > 0)
			{
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.ApispDeleteConversation(model.ApiConversationId));
				if (mct_Result != null)
				{
					if (mct_Result.Result > 0)
					{
						data = true;
						message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						status = ServiceResultStatus.Success;
					}
					else
					{
						data = false;
						message = MyResource.GetResourceString("RedundancyMessage", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						status = ServiceResultStatus.Fail;
					}
				}
				else
				{
					data = false;
					message = MyResource.GetResourceString("RedundancyMessage", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
					status = ServiceResultStatus.Fail;
				}
			}
			else
			{
				data = false;
				message = MyResource.GetResourceString("ErrorNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Fail;
			}
		}
		catch (Exception ex)
		{
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			data = false;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<bool>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}

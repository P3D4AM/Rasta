using System;
using System.Collections.Generic;
using System.Data.Objects;
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

public class FOTicketController : ApiController
{
	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<List<FOMobspSelectTickets_Result>> SelectTicketsWithSearch(FoTicketsWithSearch model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<FOMobspSelectTickets_Result> data = null;
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
					data = Enumerable.ToList<FOMobspSelectTickets_Result>((IEnumerable<FOMobspSelectTickets_Result>)cRMEntities.FOMobspSelectTickets(token2.CompanyId, model.ProjectId, model.ConversationId, model.IsFinished, model.IsAnswered, isReadTicket: model.IsReadTicket, isStopTicket: model.IsStopTicket, pageNumber: model.PageNumber, pageSize: model.PageSize, languageID: num, defaultLanguageID: result2, companyPersonId: model.CompanyPersonId, centerId: model.CenterId, foSettingId: model.FoSettingId));
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
		return new ServiceResult<List<FOMobspSelectTickets_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<FoGetTicketDetailsResult> GetTicketDetails(FoGetTicketDetails model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		FoGetTicketDetailsResult foGetTicketDetailsResult = null;
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
					foGetTicketDetailsResult = new FoGetTicketDetailsResult();
					if (model.ProjectId == 0 && token2.CompanyId == 0)
					{
						ServiceResult<FoGetTicketDetailsResult> result3 = new ServiceResult<FoGetTicketDetailsResult>
						{
							Message = Messages.MobMsgErrorParamHaveNotCorrectlyInitialized,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						cRMSpEntities?.Dispose();
						return result3;
					}
					cRMEntities.FOMobspTicketIsRead(token2.CompanyId, model.ProjectId, model.CompanyPersonId, model.CenterId);
					FOMobspSelectTickets_Result fOMobspSelectTickets_Result = Enumerable.FirstOrDefault<FOMobspSelectTickets_Result>((IEnumerable<FOMobspSelectTickets_Result>)cRMEntities.FOMobspSelectTickets(token2.CompanyId, model.ProjectId, 0, null, null, 1, 1, num, result2, null, null, model.CompanyPersonId, model.CenterId, model.FoSettingId));
					if (fOMobspSelectTickets_Result != null)
					{
						foGetTicketDetailsResult.Ticket = fOMobspSelectTickets_Result;
						foGetTicketDetailsResult.TicketHasValidity = true;
						if (model.PrjValidityPrdId > 0 && model.PrjValidityOrdItemId > 0)
						{
							ObjectParameter objectParameter = new ObjectParameter("HasValidiy", 0);
							cRMSpEntities.FOMobspCheckPrjValidityOrdItem(token2.CompanyId, null, fOMobspSelectTickets_Result.prjTitleGroup, model.PrjValidityPrdId, model.PrjValidityOrdItemId, null, objectParameter, model.CenterId, model.FoSettingId);
							int result4 = 0;
							if (objectParameter.Value != null)
							{
								int.TryParse(objectParameter.Value.ToString(), out result4);
							}
							foGetTicketDetailsResult.TicketHasValidity = result4 == 1;
						}
						List<FOMobspSelectTicketsWithTicketNumber_Result> list = Enumerable.ToList<FOMobspSelectTicketsWithTicketNumber_Result>((IEnumerable<FOMobspSelectTicketsWithTicketNumber_Result>)cRMEntities.FOMobspSelectTicketsWithTicketNumber(token2.CompanyId, model.ProjectId, model.PageNumber, model.PageSize, num, result2, model.CompanyPersonId, model.CenterId));
						if (Enumerable.Any<FOMobspSelectTicketsWithTicketNumber_Result>((IEnumerable<FOMobspSelectTicketsWithTicketNumber_Result>)list))
						{
							foGetTicketDetailsResult.SubTickets = new List<FoGetSingleTicketWithFilesViewModel>();
							foreach (FOMobspSelectTicketsWithTicketNumber_Result item in list)
							{
								FoGetSingleTicketWithFilesViewModel foGetSingleTicketWithFilesViewModel = new FoGetSingleTicketWithFilesViewModel();
								foGetSingleTicketWithFilesViewModel.Ticket = item;
								List<FOMobspSelectFilesDirectory_Result> list2 = Enumerable.ToList<FOMobspSelectFilesDirectory_Result>((IEnumerable<FOMobspSelectFilesDirectory_Result>)cRMEntities.FOMobspSelectFilesDirectory(item.cnvsCompanyId.ToString(), item.cnvsPersonId.ToString(), item.cnvsProjectId.ToString(), "2", item.ConversationID.ToString(), num, result2, true, model.CenterId));
								if (list2 != null && Enumerable.Any<FOMobspSelectFilesDirectory_Result>((IEnumerable<FOMobspSelectFilesDirectory_Result>)list2))
								{
									foGetSingleTicketWithFilesViewModel.FileList = list2;
								}
								foGetTicketDetailsResult.SubTickets.Add(foGetSingleTicketWithFilesViewModel);
							}
							message = Messages.MobMsgSuccessAction;
							status = ServiceResultStatus.Success;
						}
						else
						{
							message = Messages.MobMsgErorrNotFound;
							status = ServiceResultStatus.Error;
						}
					}
					else
					{
						message = Messages.MobMsgErorrNotFound;
						status = ServiceResultStatus.Error;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					foGetTicketDetailsResult = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				foGetTicketDetailsResult = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			foGetTicketDetailsResult = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<FoGetTicketDetailsResult>
		{
			Message = message,
			Data = foGetTicketDetailsResult,
			Status = status
		};
	}

	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<Dictionary<string, int>> SendTicket(FoSendTicket model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		CRMEntities cRMEntities = null;
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		string fOTicket = Labels.FOTicket;
		int value = -10;
		int value2 = -10;
		int value3 = 96;
		DateTime now = DateTime.Now;
		DateTime value4 = now;
		string text = now.ToString("yyyyMMdd", new PersianCulture());
		short value5 = short.Parse(Financial.Get().Id.ToString());
		short value6 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
		string appType = Mobile.Classes.Configuration.AppType;
		string mobConversationErjaShow = Messages.MobConversationErjaShow;
		DateTime value7 = now.AddSeconds(-7.0);
		string text2 = DateTimeClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
		string text3 = now.ToString("HH:mm:ss");
		short value8 = short.Parse(now.ToString("yyyy", new PersianCulture()));
		int result3 = 0;
		int result4 = 0;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				FoToken token2 = new FoCommon().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					List<FOMobspSelectLanguages_Result> list = Enumerable.ToList<FOMobspSelectLanguages_Result>((IEnumerable<FOMobspSelectLanguages_Result>)cRMEntities.FOMobspSelectLanguages());
					string text4 = "";
					if (model.ProjectId > 0)
					{
						text4 = Company.GetCmpProjectTitle(model.ProjectId, result2);
					}
					else
					{
						model.ProjectId = -1;
						text4 = fOTicket + " " + model.Subject;
					}
					string text5 = "";
					if (model.ReferUserId <= 0)
					{
						model.ReferUserId = -1;
						foreach (FOMobspSelectUserForTicketReferToMultilUser_Result item in Enumerable.ToList<FOMobspSelectUserForTicketReferToMultilUser_Result>((IEnumerable<FOMobspSelectUserForTicketReferToMultilUser_Result>)cRMEntities.FOMobspSelectUserForTicketReferToMultilUser(model.DepartmentId, 7, -1, token2.CompanyId, num, result2, model.CenterId)))
						{
							string text6 = "";
							if (item.CmpAccess.GetValueOrDefault() == -100)
							{
								text6 = $" ({Messages.MobFOReferUserCmpNotAccess})";
							}
							text5 = text5 + item.FullName + text6 + ",";
						}
					}
					text5 = ((!string.IsNullOrEmpty(text5)) ? text5.TrimEnd(new char[1] { ',' }) : "");
					string text7 = "";
					string text8 = "";
					string text9 = "";
					foreach (FOMobspSelectLanguages_Result item2 in list)
					{
						text7 = "";
						text8 = "";
						text7 = MyResource.GetResourceString("FOTicketErjaFrom", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						text8 = MyResource.GetResourceString("FOTicketErjaInConnection", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + Company.GetCompanyName(token2.CompanyId, result2, item2.LanguageID) + "<BR>" + MyResource.GetResourceString("FOTicketErjaPerson", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + Company.GetCmpPersonName(model.CompanyPersonId, item2.LanguageID) + "<BR>" + MyResource.GetResourceString("FOTicketErjaProject", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + ((model.ProjectId > 0) ? Company.GetCmpProjectTitle(model.ProjectId, item2.LanguageID) : text4);
						if (text5 != "")
						{
							text8 = text8 + "<BR>" + MyResource.GetResourceString("FOTicketErjaMultiUser", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + Company.GetMultiReferUserForTicket(token2.CompanyId, model.DepartmentId, item2.LanguageID, item2.LanguageCollation, model.CenterId);
						}
						text8 = text8 + "<BR><BR>" + MyResource.GetResourceString("FOTicketErjaConversationDescription", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":<BR>" + model.Description.Replace("\r\n", "<BR>");
						text8 = text8 + "<BR><BR>" + MyResource.GetResourceString("FOTicketErjaDetails", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						text9 = text9 + "MsgSubj=" + text7 + "|@#@|MsgBody=" + text8 + "|@#@|LangId=" + item2.LanguageID + "|@#@||^#^|";
					}
					string text10 = "";
					string text11 = "";
					string text12 = "";
					if (!string.IsNullOrEmpty(text5))
					{
						foreach (FOMobspSelectLanguages_Result item3 in list)
						{
							text10 = "";
							text11 = "";
							text10 = MyResource.GetResourceString("FOTicketErjaRonevesht", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
							text11 = MyResource.GetResourceString("FOTicketErjaInConnection", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + Company.GetCompanyName(token2.CompanyId, result2, item3.LanguageID) + "<BR>" + MyResource.GetResourceString("FOTicketErjaPerson", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + Company.GetCmpPersonName(model.CompanyPersonId, item3.LanguageID) + "<BR>" + MyResource.GetResourceString("FOTicketErjaProject", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + ((model.ProjectId > 0) ? Company.GetCmpProjectTitle(model.ProjectId, item3.LanguageID) : text4);
							if (text5 != "")
							{
								text11 = text11 + "<BR>" + MyResource.GetResourceString("FOTicketErjaMultiUser", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + Company.GetMultiReferUserForTicket(token2.CompanyId, model.DepartmentId, item3.LanguageID, item3.LanguageCollation, model.CenterId);
							}
							text11 = text11 + "<BR><BR>" + MyResource.GetResourceString("FOTicketErjaConversationDescription", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":<BR>" + model.Description.Replace("\r\n", "<BR>");
							text11 = text11 + "<BR><BR>" + MyResource.GetResourceString("FOTicketErjaDetails", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
							text12 = text12 + "MsgSubj=" + text10 + "|@#@|MsgBody=" + text11 + "|@#@|LangId=" + item3.LanguageID + "|@#@||^#^|";
						}
					}
					int maxFOCount = Mobile.Classes.Configuration.MaxFOCount;
					string text13 = Enumerable.FirstOrDefault<string>((IEnumerable<string>)cRMEntities.FOMobspInsertTicket(token2.CompanyId, model.ProjectId, model.DepartmentId, fOTicket, model.Subject, value, value2, value3, model.Description, model.CompanyPersonId, model.PriorityId, model.ReferUserId, registerDate: value4, registerDatePersian: text, registerDay: text2, registerTime: text3, firstRegisterDateAddSecond: value7, internalMessageYear: value8, year1: value5, month1: value6, appType: appType, languageID: result2, needErjaRefmsgSubject: text7, needErjaRefmsgBody: text9, needErjaMultiIntmsgSubject: text10, needErjaMultiIntmsgBody: text12, conversationErjaShowText: mobConversationErjaShow, linkedTypeId: 7, defaultUserId: -20, projectTitleGroupId: model.ProjectTitleGroupId, prjValidityPrdId: model.prjValidityPrdId, prjValidityOrdItemId: model.prjValidityOrdItemId, currentDate: now, centerId: model.CenterId, fosettingId: model.FoSettingId, foCountModule: maxFOCount));
					if (!string.IsNullOrEmpty(text13))
					{
						if (text13 == "0")
						{
							dictionary = null;
							message = Messages.FOMsgErrorRunFunction + "<br>";
							status = ServiceResultStatus.Fail;
						}
						else if (text13.IndexOf("-100", StringComparison.Ordinal) >= 0)
						{
							dictionary = null;
							message = Messages.MobFOMsgErrorProjectIsNotForCompany + "<br>";
							status = ServiceResultStatus.Fail;
						}
						else if (text13.IndexOf("-101", StringComparison.Ordinal) >= 0)
						{
							dictionary = null;
							message = Messages.MobFOMsgErrorPersonIsNotForCompany + "<br>";
							status = ServiceResultStatus.Fail;
						}
						else if (text13.IndexOf("-1", StringComparison.Ordinal) >= 0)
						{
							FOMobspReturnTicketAllowInCurrntCount_Result fOMobspReturnTicketAllowInCurrntCount_Result = Enumerable.FirstOrDefault<FOMobspReturnTicketAllowInCurrntCount_Result>((IEnumerable<FOMobspReturnTicketAllowInCurrntCount_Result>)cRMEntities.FOMobspReturnTicketAllowInCurrntCount(token2.CompanyId, model.ProjectTitleGroupId, model.CenterId, model.FoSettingId));
							dictionary = null;
							message = string.Format(Messages.MobFOMsgErrorTicketInCurrntCount, fOMobspReturnTicketAllowInCurrntCount_Result.cmpTicketAllowInCurrntCount.GetValueOrDefault().ToString(), fOMobspReturnTicketAllowInCurrntCount_Result.TicketInCurrntCount.GetValueOrDefault().ToString());
							status = ServiceResultStatus.Fail;
						}
						else if (text13.IndexOf("-2", StringComparison.Ordinal) >= 0)
						{
							FOMobspReturnTicketAllowInCurrntCount_Result fOMobspReturnTicketAllowInCurrntCount_Result2 = Enumerable.FirstOrDefault<FOMobspReturnTicketAllowInCurrntCount_Result>((IEnumerable<FOMobspReturnTicketAllowInCurrntCount_Result>)cRMEntities.FOMobspReturnTicketAllowInCurrntCount(token2.CompanyId, model.ProjectTitleGroupId, model.CenterId, model.FoSettingId));
							dictionary = null;
							message = string.Format(Messages.MobFOMsgErrorTicketInCurrntCount, fOMobspReturnTicketAllowInCurrntCount_Result2.TicketAllowInCurrntCount.GetValueOrDefault().ToString(), fOMobspReturnTicketAllowInCurrntCount_Result2.TicketInCurrntCount.GetValueOrDefault().ToString());
							status = ServiceResultStatus.Fail;
						}
						else if (text13.IndexOf("-3", StringComparison.Ordinal) >= 0)
						{
							FOMobspReturnTicketAllowAddBeforeAnswerCount_Result fOMobspReturnTicketAllowAddBeforeAnswerCount_Result = Enumerable.FirstOrDefault<FOMobspReturnTicketAllowAddBeforeAnswerCount_Result>((IEnumerable<FOMobspReturnTicketAllowAddBeforeAnswerCount_Result>)cRMEntities.FOMobspReturnTicketAllowAddBeforeAnswerCount(token2.CompanyId, model.ProjectId, model.CenterId, model.FoSettingId));
							dictionary = null;
							message = string.Format(Messages.MobFOMsgErrorTicketBeforeAnswerCount, fOMobspReturnTicketAllowAddBeforeAnswerCount_Result.cmpTicketAllowAddBeforeAnswerCount.GetValueOrDefault().ToString()) + "<br>";
							status = ServiceResultStatus.Fail;
						}
						else if (text13.IndexOf("-4", StringComparison.Ordinal) >= 0)
						{
							FOMobspReturnTicketAllowAddBeforeAnswerCount_Result fOMobspReturnTicketAllowAddBeforeAnswerCount_Result2 = Enumerable.FirstOrDefault<FOMobspReturnTicketAllowAddBeforeAnswerCount_Result>((IEnumerable<FOMobspReturnTicketAllowAddBeforeAnswerCount_Result>)cRMEntities.FOMobspReturnTicketAllowAddBeforeAnswerCount(token2.CompanyId, model.ProjectId, model.CenterId, model.FoSettingId));
							dictionary = null;
							message = string.Format(Messages.MobFOMsgErrorTicketBeforeAnswerCount, fOMobspReturnTicketAllowAddBeforeAnswerCount_Result2.TicketAllowAddBeforeAnswerCount.GetValueOrDefault().ToString()) + "<br>";
							status = ServiceResultStatus.Fail;
						}
						else if (text13.IndexOf("-5", StringComparison.Ordinal) >= 0)
						{
							FOMobspReturnTicketAllowInCurrntCount_Result fOMobspReturnTicketAllowInCurrntCount_Result3 = Enumerable.FirstOrDefault<FOMobspReturnTicketAllowInCurrntCount_Result>((IEnumerable<FOMobspReturnTicketAllowInCurrntCount_Result>)cRMEntities.FOMobspReturnTicketAllowInCurrntCount(token2.CompanyId, model.ProjectTitleGroupId, model.CenterId, model.FoSettingId));
							dictionary = null;
							message = string.Format(Messages.MobFOMsgErrorTicketInCurrntCount, fOMobspReturnTicketAllowInCurrntCount_Result3.ProjectTitleGroupTicketAllowInCurrentCount.GetValueOrDefault().ToString(), fOMobspReturnTicketAllowInCurrntCount_Result3.TicketInCurrntCountInPrjTitleGroup.ToString());
							status = ServiceResultStatus.Fail;
						}
						else if (text13.IndexOf("-6", StringComparison.Ordinal) >= 0)
						{
							dictionary = null;
							message = Messages.FOMsgErrorSaveTicketPrdValidityNotValid + "<br>";
							status = ServiceResultStatus.Fail;
						}
						else
						{
							PushNotif.NewIntMsgNotify();
							string[] array = text13.Split(new char[1] { ',' });
							if (array != null)
							{
								int.TryParse(array[0].ToString(), out result3);
								int.TryParse(array[1].ToString(), out result4);
							}
							dictionary.Add("cnvsId", result3);
							dictionary.Add("prjId", result4);
							message = Messages.MobMsgSuccessAction;
							status = ServiceResultStatus.Success;
						}
					}
					else
					{
						dictionary = null;
						message = Messages.MobMsgErrorDoneOperation;
						status = ServiceResultStatus.Fail;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					dictionary = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				dictionary = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			dictionary = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<Dictionary<string, int>>
		{
			Message = message,
			Data = dictionary,
			Status = status
		};
	}

	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<string> ReturnTicketAllowInCurrntCount(int prjTitleGroupId, int? ln = null, int? cId = null, int? foSettingId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		string data = null;
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
				FoToken token2 = new FoCommon().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					FOMobspReturnTicketAllowInCurrntCount_Result fOMobspReturnTicketAllowInCurrntCount_Result = Enumerable.FirstOrDefault<FOMobspReturnTicketAllowInCurrntCount_Result>((IEnumerable<FOMobspReturnTicketAllowInCurrntCount_Result>)cRMEntities.FOMobspReturnTicketAllowInCurrntCount(token2.CompanyId, prjTitleGroupId, cId, foSettingId));
					if (fOMobspReturnTicketAllowInCurrntCount_Result != null)
					{
						if (fOMobspReturnTicketAllowInCurrntCount_Result.cmpTicketAllowInCurrntCount.HasValue)
						{
							if (fOMobspReturnTicketAllowInCurrntCount_Result.TicketInCurrntCount.GetValueOrDefault() >= fOMobspReturnTicketAllowInCurrntCount_Result.cmpTicketAllowInCurrntCount)
							{
								ServiceResult<string> serviceResult = new ServiceResult<string>();
								message = (serviceResult.Message = string.Format(Messages.MobFOMsgErrorTicketInCurrntCount, fOMobspReturnTicketAllowInCurrntCount_Result.cmpTicketAllowInCurrntCount.GetValueOrDefault().ToString(), fOMobspReturnTicketAllowInCurrntCount_Result.TicketInCurrntCount.GetValueOrDefault().ToString()));
								serviceResult.Data = null;
								serviceResult.Status = ServiceResultStatus.Fail;
								cRMEntities?.Dispose();
								return serviceResult;
							}
						}
						else if (fOMobspReturnTicketAllowInCurrntCount_Result.ProjectTitleGroupTicketAllowInCurrentCount.GetValueOrDefault() != 0)
						{
							if (fOMobspReturnTicketAllowInCurrntCount_Result.TicketInCurrntCountInPrjTitleGroup >= fOMobspReturnTicketAllowInCurrntCount_Result.ProjectTitleGroupTicketAllowInCurrentCount.GetValueOrDefault())
							{
								ServiceResult<string> serviceResult2 = new ServiceResult<string>();
								message = (serviceResult2.Message = string.Format(Messages.MobFOMsgErrorTicketInCurrntCount, fOMobspReturnTicketAllowInCurrntCount_Result.ProjectTitleGroupTicketAllowInCurrentCount.GetValueOrDefault().ToString(), fOMobspReturnTicketAllowInCurrntCount_Result.TicketInCurrntCountInPrjTitleGroup.ToString()));
								serviceResult2.Data = null;
								serviceResult2.Status = ServiceResultStatus.Fail;
								cRMEntities?.Dispose();
								return serviceResult2;
							}
						}
						else if (fOMobspReturnTicketAllowInCurrntCount_Result.TicketAllowInCurrntCount.GetValueOrDefault() != 0 && fOMobspReturnTicketAllowInCurrntCount_Result.TicketInCurrntCount.GetValueOrDefault() >= fOMobspReturnTicketAllowInCurrntCount_Result.TicketAllowInCurrntCount)
						{
							ServiceResult<string> serviceResult3 = new ServiceResult<string>();
							message = (serviceResult3.Message = string.Format(Messages.MobFOMsgErrorTicketInCurrntCount, fOMobspReturnTicketAllowInCurrntCount_Result.TicketAllowInCurrntCount.GetValueOrDefault().ToString(), fOMobspReturnTicketAllowInCurrntCount_Result.TicketInCurrntCount.GetValueOrDefault().ToString()));
							serviceResult3.Data = null;
							serviceResult3.Status = ServiceResultStatus.Fail;
							cRMEntities?.Dispose();
							return serviceResult3;
						}
						message = Messages.MobMsgSuccessAction;
						data = null;
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.MobMsgErrorNotFound;
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
	[FoMobileAuthorize]
	public ServiceResult<string> ReturnTicketAllowAddBeforeAnswerCount(int projectId, int? ln = null, int? cId = null, int? foSettingId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		string data = null;
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
				FoToken token2 = new FoCommon().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					FOMobspReturnTicketAllowAddBeforeAnswerCount_Result fOMobspReturnTicketAllowAddBeforeAnswerCount_Result = Enumerable.FirstOrDefault<FOMobspReturnTicketAllowAddBeforeAnswerCount_Result>((IEnumerable<FOMobspReturnTicketAllowAddBeforeAnswerCount_Result>)cRMEntities.FOMobspReturnTicketAllowAddBeforeAnswerCount(token2.CompanyId, projectId, cId, foSettingId));
					if (fOMobspReturnTicketAllowAddBeforeAnswerCount_Result != null)
					{
						if (fOMobspReturnTicketAllowAddBeforeAnswerCount_Result.cmpTicketAllowAddBeforeAnswerCount.HasValue)
						{
							if (fOMobspReturnTicketAllowAddBeforeAnswerCount_Result.TicketBeforeAnswerCount >= fOMobspReturnTicketAllowAddBeforeAnswerCount_Result.cmpTicketAllowAddBeforeAnswerCount)
							{
								ServiceResult<string> result3 = new ServiceResult<string>
								{
									Message = string.Format(Messages.MobFOMsgErrorTicketBeforeAnswerCount, fOMobspReturnTicketAllowAddBeforeAnswerCount_Result.cmpTicketAllowAddBeforeAnswerCount.ToString()) + "<br>",
									Data = null,
									Status = ServiceResultStatus.Fail
								};
								cRMEntities?.Dispose();
								return result3;
							}
						}
						else if (fOMobspReturnTicketAllowAddBeforeAnswerCount_Result.TicketAllowAddBeforeAnswerCount.GetValueOrDefault() != 0 && fOMobspReturnTicketAllowAddBeforeAnswerCount_Result.TicketBeforeAnswerCount >= fOMobspReturnTicketAllowAddBeforeAnswerCount_Result.TicketAllowAddBeforeAnswerCount)
						{
							ServiceResult<string> result4 = new ServiceResult<string>
							{
								Message = string.Format(Messages.MobFOMsgErrorTicketBeforeAnswerCount, fOMobspReturnTicketAllowAddBeforeAnswerCount_Result.TicketAllowAddBeforeAnswerCount.ToString()) + "<br>",
								Data = null,
								Status = ServiceResultStatus.Fail
							};
							cRMEntities?.Dispose();
							return result4;
						}
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
	[FoMobileAuthorize]
	public ServiceResult<int> GetUnReadTicket(int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		int data = 0;
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
				FoToken token2 = new FoCommon().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					data = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.FOMobspGetUnReadTicket(token2.CompanyId, cId)).GetValueOrDefault();
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = 0;
					status = ServiceResultStatus.Error;
				}
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
		}
		return new ServiceResult<int>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<string> UpdateConversationHappyVote(int cnvsId, int cnvsHappyVote, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		string data = null;
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
				if (new FoCommon().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(Financial.Get().Id.ToString());
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					cRMEntities.FOMobspUpdateConversationHappyVote(cnvsId, (cnvsHappyVote == 0) ? null : new int?(cnvsHappyVote), -20, value2, value3, value, registerDatePersian, appType);
					data = null;
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
}

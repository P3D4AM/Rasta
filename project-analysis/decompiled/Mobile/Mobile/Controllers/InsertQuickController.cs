using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using CRM.General.Security;
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

public class InsertQuickController : ApiController
{
	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<InsertQuickCmpPrsPrjCnvsResultViewModel> InsertQuickCmpPrsPrjCnvs(InsertQuickCmpPrsPrjCnvsViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		InsertQuickCmpPrsPrjCnvsResultViewModel data = null;
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
					if (base.Request.Headers.TryGetValues("imeiCode", out var _) && !Common.CheckUserImeiCode(token2.userId, Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("imeiCode")), Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("appName"))))
					{
						return new ServiceResult<InsertQuickCmpPrsPrjCnvsResultViewModel>
						{
							Message = Messages.MobMsgUserImeiNotPreDefined,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					cRMEntities = new CRMEntities();
					int num = 0;
					List<MobspSelectLanguages_Result> list = Enumerable.ToList<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)cRMEntities.MobspSelectLanguages());
					DateTime now = DateTime.Now;
					string mobPersonLabel = Labels.MobPersonLabel;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(Financial.Get().Id.ToString());
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string mobConversationErjaShow = Messages.MobConversationErjaShow;
					string appType = Mobile.Classes.Configuration.AppType;
					string mobLackOfShowText = Labels.MobLackOfShowText;
					string text2 = "\r\n" + Messages.MobConversationErjaMultiUser + "{MultiUser}";
					string text3 = "\r\n" + Messages.MobConversationErjaReferDescription + ":\r\n{CNVSREFERDESC}";
					string conversationErjaShow = Messages.ConversationErjaShow;
					string eventErjaRefmsg = "";
					string mobCnvsReferUserCmpNotAccess = Messages.MobCnvsReferUserCmpNotAccess;
					int value4 = 7;
					string text4 = "";
					string text5 = "";
					string text6 = "";
					foreach (MobspSelectLanguages_Result item in list)
					{
						text2 = "";
						text2 = "\r\n" + MyResource.GetResourceString("MobConversationErjaMultiUser", item.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + " : {MultiUser}";
						text3 = "";
						text3 = "\r\n" + MyResource.GetResourceString("MobConversationErjaReferDescription", item.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":\r\n{CNVSREFERDESC}";
						mobCnvsReferUserCmpNotAccess = "";
						mobCnvsReferUserCmpNotAccess = MyResource.GetResourceString("MobCnvsReferUserCmpNotAccess", item.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						text4 = text4 + "MsgErjaMultiUser=" + text2 + "|@#@|LangId=" + item.LanguageID + "|@#@||^#^|";
						text5 = text5 + "MsgReferDesc=" + text3 + "|@#@|LangId=" + item.LanguageID + "|@#@||^#^|";
						text6 = text6 + "CmpNotAccess=" + mobCnvsReferUserCmpNotAccess + "|@#@|LangId=" + item.LanguageID + "|@#@||^#^|";
					}
					text2 = text4;
					text3 = text5;
					mobCnvsReferUserCmpNotAccess = text6;
					if (num == 0)
					{
						string text7 = "";
						string text8 = "";
						string text9 = "";
						text7 = "";
						foreach (MobspSelectLanguages_Result item2 in list)
						{
							text8 = "";
							text9 = "";
							text8 = MyResource.GetResourceString("MobConversationErjaFrom", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + " " + Common.GetUserName(UserLogin.CurrentUser.UserId, result2, item2.LanguageID, model.CenterId);
							text9 = MyResource.GetResourceString("MobConversationErjaInConnection", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {CMP}\r\n" + MyResource.GetResourceString("MobConversationErjaPerson", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {PRS}\r\n" + MyResource.GetResourceString("MobConversationErjaProject", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {PRJ}{MultiUser}";
							text9 = text9 + "\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaConversationDescription", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":\r\n{CNVSDESC}{CNVSREFERDESC}";
							text9 = text9 + "\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaDetails", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
							text7 = text7 + "MsgSubj=" + text8 + "|@#@|MsgBody=" + text9 + "|@#@|LangId=" + item2.LanguageID + "|@#@||^#^|";
						}
						text8 = "";
						text9 = text7;
						string text10 = "";
						string text11 = "";
						text7 = "";
						foreach (MobspSelectLanguages_Result item3 in list)
						{
							text10 = "";
							text11 = "";
							text10 = MyResource.GetResourceString("MobConversationErjaNotice", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + Common.GetUserName(UserLogin.CurrentUser.UserId, result2, item3.LanguageID, model.CenterId);
							text11 = "**" + MyResource.GetResourceString("MobConversationErjaAutomatically", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaAttention", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("MobConversationErjaInConnection", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {CMP}\r\n" + MyResource.GetResourceString("MobConversationErjaPerson", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {PRS}\r\n" + MyResource.GetResourceString("MobConversationErjaProject", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {PRJ}\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaLastNegotiator", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ", " + MyResource.GetResourceString("MobConversationErjaTransmitter", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("MobConversationErjaMultiUser", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "{MultiUser}\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaConversationDescription", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": \r\n{CNVSDESC}{CNVSREFERDESC}";
							text11 = text11 + "\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaDetails", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
							text7 = text7 + "MsgSubj=" + text10 + "|@#@|MsgBody=" + text11 + "|@#@|LangId=" + item3.LanguageID + "|@#@||^#^|";
						}
						text10 = "";
						text11 = text7;
						string text12 = "";
						string text13 = "";
						text7 = "";
						foreach (MobspSelectLanguages_Result item4 in list)
						{
							text12 = "";
							text13 = "";
							text12 = MyResource.GetResourceString("MobConversationErjaRonevesht", item4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + Common.GetUserName(UserLogin.CurrentUser.UserId, result2, item4.LanguageID, model.CenterId);
							text13 = MyResource.GetResourceString("MobConversationErjaInConnection", item4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {CMP} \r\n" + MyResource.GetResourceString("MobConversationErjaPerson", item4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {PRS} \r\n" + MyResource.GetResourceString("MobConversationErjaProject", item4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {PRJ}\r\n" + MyResource.GetResourceString("MobConversationErjaMultiUser", item4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + " : {MultiUser}\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaConversationDescription", item4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": \r\n{CNVSDESC}{CNVSREFERDESC}";
							text13 = text13 + "\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaDetails", item4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
							text7 = text7 + "MsgSubj=" + text12 + "|@#@|MsgBody=" + text13 + "|@#@|LangId=" + item4.LanguageID + "|@#@||^#^|";
						}
						text12 = "";
						text13 = text7;
						string text14 = "";
						string surveyMainExtrenalLinkLogin = "";
						string surveyMainExtrenalLink = "";
						string text15 = base.Request.RequestUri.GetLeftPart(UriPartial.Authority);
						string leftPart = base.Request.RequestUri.GetLeftPart(UriPartial.Scheme);
						if (text15.EndsWith("/"))
						{
							text15 = text15.TrimEnd(new char[1] { '/' });
						}
						text15 += "/Survey/Home/SurveyAnswerValues";
						text14 = text15;
						string text16 = "";
						MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result = SysSeting.Get();
						string text17 = "";
						string text18 = "";
						if (mobspSelectCrmsysSetting_Result != null)
						{
							text17 = mobspSelectCrmsysSetting_Result.FOUrl ?? "";
							text18 = mobspSelectCrmsysSetting_Result.CrmIPStatic ?? "";
						}
						if (!string.IsNullOrWhiteSpace(text17))
						{
							text16 = text17.Trim();
							if (!text16.Contains("http"))
							{
								text16 = leftPart + text16;
							}
							if (text16.EndsWith("/"))
							{
								text16 = text16.TrimEnd(new char[1] { '/' });
							}
							text16 += "/Survey/Home";
							surveyMainExtrenalLinkLogin = text16;
						}
						if (!string.IsNullOrWhiteSpace(text18))
						{
							text16 = text18.Trim();
							if (!text16.Contains("http"))
							{
								text16 = leftPart + text16;
							}
							if (text16.EndsWith("/"))
							{
								text16 = text16.TrimEnd(new char[1] { '/' });
							}
							text16 += "/Survey/Register/Index";
						}
						if ((model.Company ?? "") != "")
						{
							bool haveEroroFoCnt = false;
							string foInfoJson = Company.GetFoInfoJson("", "", model.CenterId.ToString(), ref haveEroroFoCnt, 0, model.CenterId.GetValueOrDefault(), isCmp: true, model.cmpReferUserId.GetValueOrDefault(), model.cmpSuppUserId.GetValueOrDefault());
							model.Company = model.Company.Replace("{cmpFOInfo}", foInfoJson);
						}
						if ((model.Persons ?? "") != "")
						{
							bool haveEroroFoCnt2 = false;
							string foInfoJson2 = Company.GetFoInfoJson("", "", model.CenterId.ToString(), ref haveEroroFoCnt2, 0, model.CenterId.GetValueOrDefault());
							model.Persons = model.Persons.Replace("{prsFOInfo}", foInfoJson2);
						}
						ObjectParameter objectParameter = new ObjectParameter("insertedCompanyId", 0);
						ObjectParameter objectParameter2 = new ObjectParameter("insertedPersonIds", "");
						ObjectParameter objectParameter3 = new ObjectParameter("insertedProjectIds", "");
						ObjectParameter objectParameter4 = new ObjectParameter("insertedConversationIds", "");
						ObjectParameter insertedCompanyAddressIds = new ObjectParameter("insertedCompanyAddressIds", "");
						ObjectParameter objectParameter5 = new ObjectParameter("errorMessage", "");
						ObjectParameter objectParameter6 = new ObjectParameter("typeTable", "");
						int maxFOCount = Mobile.Classes.Configuration.MaxFOCount;
						string encryptionKey = XorCipher.PreparePublicKeyForSql();
						CRMEntities cRMEntities2 = cRMEntities;
						string company = model.Company;
						string persons = model.Persons;
						string projects = model.Projects;
						string conversations = model.Conversations;
						string companyAddresses = model.CompanyAddresses;
						int? userId = token2.userId;
						short? year = value2;
						short? month = value3;
						DateTime? registerDate = value;
						int? languageID = result;
						int? defaultLanguageID = result2;
						string needErjaRefmsgSubj = text8;
						string needErjaRefmsgBody = text9;
						string needErjaMultiIntmsgSubject = text12;
						string needErjaMultiIntmsgBody = text13;
						string needSendErjaAllarmRefmsgSubj = text10;
						string needSendErjaAllarmRefmsgBody = text11;
						string msgConversationErjaMultiUser = text2;
						string msgConversationErjaReferDescription = text3;
						string cmpNotAccess = mobCnvsReferUserCmpNotAccess;
						int? num2 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities2.MobspInsertQuickCmpPrsPrjCnvs(company, persons, projects, conversations, companyAddresses, userId, year, month, registerDate, registerDatePersian, appType, languageID, defaultLanguageID, mobPersonLabel, needErjaRefmsgSubj, needErjaRefmsgBody, needErjaMultiIntmsgSubject, needErjaMultiIntmsgBody, needSendErjaAllarmRefmsgSubj, needSendErjaAllarmRefmsgBody, mobConversationErjaShow, msgConversationErjaMultiUser, msgConversationErjaReferDescription, objectParameter, objectParameter2, objectParameter3, objectParameter4, insertedCompanyAddressIds, objectParameter5, objectParameter6, value4, cmpNotAccess, text14, surveyMainExtrenalLink, surveyMainExtrenalLinkLogin, conversationErjaShow, eventErjaRefmsg, model.CenterId, encryptionKey, maxFOCount));
						InsertQuickCmpPrsPrjCnvsResultViewModel insertQuickCmpPrsPrjCnvsResultViewModel = new InsertQuickCmpPrsPrjCnvsResultViewModel();
						string text19 = "";
						if (objectParameter5.Value != null)
						{
							if (objectParameter5.Value.ToString() != "")
							{
								string text20 = objectParameter5.Value.ToString();
								text20 = text20.Replace("|Msg=0", "<CMP>" + Messages.MobMsgErrorInsertCompany + "<\\CMP>");
								text20 = text20.Replace("Msg=1", "<CMP>" + Messages.MobMsgErrorInconsistencyInCompanySelection + "<\\CMP>");
								text20 = text20.Replace("Msg=2", "<PRS>" + Messages.MobMsgErrorInsertPersons + "<\\PRS>");
								text20 = text20.Replace("Msg=3", "<PRS>" + Messages.MobMsgErrorInsertPerson + "<\\PRS>");
								text20 = text20.Replace("Msg=4", "<PRJ>" + Messages.MobMsgErrorInsertProjects + "<\\PRJ>");
								text20 = text20.Replace("Msg=5", "<PRJ>" + Messages.MobMsgErrorInsertProject + "<\\PRJ>");
								text20 = text20.Replace("Msg=6", "<CNVS>" + Messages.MobMsgErrorInsertSms + "<\\CNVS>");
								text20 = text20.Replace("Msg=7", "<CNVS>" + Messages.MobMsgErrorInsertConversation + "<\\CNVS>");
								text20 = text20.Replace("Dup=1Msg=0", "<CMP>" + Messages.MobMsgErrorNotInsertDuplicateCompany + "<\\CMP>");
								insertQuickCmpPrsPrjCnvsResultViewModel.ErrorMessage = text20;
								text19 = objectParameter5.Value.ToString();
								if (text19.IndexOf("|Msg=CmpGroupIdAccess|", StringComparison.Ordinal) >= 0 || text19.IndexOf("|Msg=CmpSubGroupIdAccess|", StringComparison.Ordinal) >= 0 || text19.IndexOf("|Msg=CmpGroupIdIVAccess|", StringComparison.Ordinal) >= 0 || text19.IndexOf("|Msg=CmpProvinceIdAccess|", StringComparison.Ordinal) >= 0 || text19.IndexOf("|Msg=CmpCityIdAccess|", StringComparison.Ordinal) >= 0 || text19.IndexOf("|Msg=PrjAccess|", StringComparison.Ordinal) >= 0 || text19.IndexOf("|Msg=CmpIsDraftAccess|", StringComparison.Ordinal) >= 0 || text19.IndexOf("|Msg=CmpIsDraftNotAccess|", StringComparison.Ordinal) >= 0)
								{
									text19 = text19.Replace("|Msg=0", "").Replace("Msg=1", "").Replace("Msg=2", "")
										.Replace("Msg=3", "")
										.Replace("Msg=4", "")
										.Replace("Msg=5", "")
										.Replace("Msg=6", "")
										.Replace("Msg=7", "")
										.Replace("Dup=1Msg=0", "");
									if (text19.IndexOf("|Msg=CmpGroupIdAccess|", StringComparison.Ordinal) >= 0)
									{
										string[] array = text19.Split(new string[1] { "|Msg=CmpGroupIdAccess|" }, StringSplitOptions.None);
										if (array != null && Enumerable.Count<string>((IEnumerable<string>)array) == 3 && !string.IsNullOrEmpty(array[1]))
										{
											string newValue = "<CMP>" + string.Format(Messages.MobMsgErrorrNotAccessToCmpGroup, array[1]) + "<\\CMP>";
											text19 = text19.Replace("|Msg=CmpGroupIdAccess|" + array[1] + "|Msg=CmpGroupIdAccess|", newValue);
										}
									}
									if (text19.IndexOf("|Msg=CmpSubGroupIdAccess|", StringComparison.Ordinal) >= 0)
									{
										string[] array2 = text19.Split(new string[1] { "|Msg=CmpSubGroupIdAccess|" }, StringSplitOptions.None);
										if (array2 != null && Enumerable.Count<string>((IEnumerable<string>)array2) == 3 && !string.IsNullOrEmpty(array2[1]))
										{
											string newValue2 = "<CMP>" + string.Format(Messages.MobMsgErrorrNotAccessToCmpSubGroup, array2[1]) + "<\\CMP>";
											text19 = text19.Replace("|Msg=CmpSubGroupIdAccess|" + array2[1] + "|Msg=CmpSubGroupIdAccess|", newValue2);
										}
									}
									if (text19.IndexOf("|Msg=CmpGroupIdIVAccess|", StringComparison.Ordinal) >= 0)
									{
										string[] array3 = text19.Split(new string[1] { "|Msg=CmpGroupIdIVAccess|" }, StringSplitOptions.None);
										if (array3 != null && Enumerable.Count<string>((IEnumerable<string>)array3) == 3 && !string.IsNullOrEmpty(array3[1]))
										{
											string newValue3 = "<CMP>" + string.Format(Messages.MobMsgErrorrNotAccessToCmpGroupIV, array3[1]) + "<\\CMP>";
											text19 = text19.Replace("|Msg=CmpGroupIdIVAccess|" + array3[1] + "|Msg=CmpGroupIdIVAccess|", newValue3);
										}
									}
									if (text19.IndexOf("|Msg=CmpProvinceIdAccess|", StringComparison.Ordinal) >= 0)
									{
										string[] array4 = text19.Split(new string[1] { "|Msg=CmpProvinceIdAccess|" }, StringSplitOptions.None);
										if (array4 != null && Enumerable.Count<string>((IEnumerable<string>)array4) == 3 && !string.IsNullOrEmpty(array4[1]))
										{
											string newValue4 = "<CMP>" + string.Format(Messages.MobMsgErrorrNotAccessToProvince, array4[1]) + "<\\CMP>";
											text19 = text19.Replace("|Msg=CmpProvinceIdAccess|" + array4[1] + "|Msg=CmpProvinceIdAccess|", newValue4);
										}
									}
									if (text19.IndexOf("|Msg=CmpCityIdAccess|", StringComparison.Ordinal) >= 0)
									{
										string[] array5 = text19.Split(new string[1] { "|Msg=CmpCityIdAccess|" }, StringSplitOptions.None);
										if (array5 != null && Enumerable.Count<string>((IEnumerable<string>)array5) == 3 && !string.IsNullOrEmpty(array5[1]))
										{
											string newValue5 = "<CMP>" + string.Format(Messages.MobMsgErrorrNotAccessToCity, array5[1]) + "<\\CMP>";
											text19 = text19.Replace("|Msg=CmpCityIdAccess|" + array5[1] + "|Msg=CmpCityIdAccess|", newValue5);
										}
									}
									if (text19.IndexOf("|Msg=PrjAccess|", StringComparison.Ordinal) >= 0)
									{
										string[] array6 = text19.Split(new string[1] { "|Msg=PrjAccess|" }, StringSplitOptions.None);
										if (array6 != null && Enumerable.Count<string>((IEnumerable<string>)array6) == 3)
										{
											if (!string.IsNullOrEmpty(array6[1]))
											{
												string[] array7 = array6[1].Split(new string[1] { "|PRJID|" }, StringSplitOptions.None);
												if (array7 != null && Enumerable.Count<string>((IEnumerable<string>)array7) == 2)
												{
													string text21 = string.Format(Messages.MobMsgErrorrNotAccessToProject, array7[1]);
													string newValue6 = "<PRJ><PRJID>" + array7[0] + "<\\PRJID><PRJTITLE>" + text21 + "<\\PRJTITLE><\\PRJ>";
													text19 = text19.Replace("|Msg=PrjAccess|" + array6[1] + "|Msg=PrjAccess|", newValue6);
												}
											}
										}
										else if (array6 != null && Enumerable.Count<string>((IEnumerable<string>)array6) > 3)
										{
											for (int i = 1; i < Enumerable.Count<string>((IEnumerable<string>)array6); i++)
											{
												if (!string.IsNullOrEmpty(array6[i]))
												{
													string[] array8 = array6[i].Split(new string[1] { "|PRJID|" }, StringSplitOptions.None);
													if (array8 != null && Enumerable.Count<string>((IEnumerable<string>)array8) == 2)
													{
														string text22 = string.Format(Messages.MobMsgErrorrNotAccessToProject, array8[1]);
														string newValue7 = "<PRJ><PRJID>" + array8[0] + "<\\PRJID><PRJTITLE>" + text22 + "<\\PRJTITLE><\\PRJ>";
														text19 = text19.Replace("|Msg=PrjAccess|" + array6[i] + "|Msg=PrjAccess|", newValue7);
													}
												}
											}
										}
									}
									if (text19.IndexOf("|Msg=CmpIsDraftAccess|", StringComparison.Ordinal) >= 0)
									{
										string[] array9 = text19.Split(new string[1] { "|Msg=CmpIsDraftAccess|" }, StringSplitOptions.None);
										if (array9 != null && Enumerable.Count<string>((IEnumerable<string>)array9) == 3 && !string.IsNullOrEmpty(array9[1]))
										{
											string newValue8 = "<CMP>عدم امکان ثبت مشتری موقتBRشما بیشتر از " + array9[1] + " مشتری موقت نمی توانید ثبت نمایید. لطفا پس از اصلاح خطاها اقدام به ثبت مشتری نمایید.<\\CMP>";
											text19 = text19.Replace("|Msg=CmpIsDraftAccess|" + array9[1] + "|Msg=CmpIsDraftAccess|", newValue8);
										}
									}
									if (text19.IndexOf("|Msg=CmpIsDraftNotAccess|", StringComparison.Ordinal) >= 0)
									{
										string[] array10 = text19.Split(new string[1] { "|Msg=CmpIsDraftNotAccess|" }, StringSplitOptions.None);
										if (array10 != null && Enumerable.Count<string>((IEnumerable<string>)array10) == 3 && !string.IsNullOrEmpty(array10[1]))
										{
											string newValue9 = "<CMP>دسترسی شما برای ثبت مشتری موقت محدود شده است<\\CMP>";
											text19 = text19.Replace("|Msg=CmpIsDraftNotAccess|" + array10[1] + "|Msg=CmpIsDraftNotAccess|", newValue9);
										}
									}
									insertQuickCmpPrsPrjCnvsResultViewModel.ErrorMessage = text19;
								}
								else if (text19.IndexOf("PreChckErrs", StringComparison.Ordinal) >= 0)
								{
									string text23 = "";
									string[] array11 = text19.Split(new string[1] { "|^|" }, StringSplitOptions.None);
									foreach (string text24 in array11)
									{
										if (!string.IsNullOrEmpty(text24))
										{
											string[] array12 = text24.Split(new char[1] { ',' });
											if (array12[0] == "@StatusResCheckNeedDyFormChecked=PreChckErrs")
											{
												string arg = array12[1].Replace("@FormName=", "") ?? "";
												string arg2 = array12[2].Replace("@DyFormNumber=", "") ?? "";
												text23 = text23 + "<CNVS>" + string.Format(Messages.MobMsgErrorNotSaveCnvsBeforeDyFormChecked, arg, arg2) + "<\\CNVS>";
											}
											else if (array12[0] == "@StatusResCheckNoCnvsDup=PreChckErrs")
											{
												string arg3 = array12[1].Replace("@cnvsDate=", "") ?? "";
												string arg4 = array12[2].Replace("@cnvsStatus=", "") ?? "";
												string arg5 = array12[3].Replace("@cnvsStatusResult=", "") ?? "";
												text23 = text23 + "<CNVS>" + string.Format(Messages.MobMsgErrorNoDupCnvsInStatusResult, arg3, arg4, arg5) + "<\\CNVS>";
											}
											else if (array12[0] == "@StatusResCheckCnvsCountLimit=PreChckErrs")
											{
												string arg6 = array12[1].Replace("@ResultTitle=", "") ?? "";
												string arg7 = array12[2].Replace("@cnvsCountLimit=", "") ?? "";
												text23 = text23 + "<CNVS>" + string.Format(Messages.MobMsgErrorCnvsCountLimitInStatusResult, arg6, arg7) + "<\\CNVS>";
											}
											else if (array12[0] == "@StatusResCheckCnvsDoingTimeLimit=PreChckErrs")
											{
												string arg8 = array12[1].Replace("@ResultTitle=", "") ?? "";
												string arg9 = array12[2].Replace("@cnvsDoingTimeLimit=", "") ?? "";
												text23 = text23 + "<CNVS>" + string.Format(Messages.MobMsgErrorCnvsDoingTimeLimitInStatusResult, arg8, arg9) + "<\\CNVS>";
											}
											else if (array12[0] == "@StatusCheckNoOrderStatus=PreChckErrs")
											{
												string arg10 = array12[1].Replace("@Status=", "") ?? "";
												text23 = text23 + "<CNVS>" + string.Format(Messages.MobMsgErrorNoRegCnvsOlderStatus, arg10) + "<\\CNVS>";
											}
											else if (array12[0] == "@StatusCheckCnvsCountLimit=PreChckErrs")
											{
												string arg11 = array12[1].Replace("@Status=", "") ?? "";
												string arg12 = array12[2].Replace("@cnvsCountLimit=", "") ?? "";
												text23 = text23 + "<CNVS>" + string.Format(Messages.MobMsgErrorCnvsCountLimitInStatus, arg11, arg12) + "<\\CNVS>";
											}
											else if (array12[0] == "@StatusCheckCnvsDoingTimeLimit=PreChckErrs")
											{
												string arg13 = array12[1].Replace("@Status=", "") ?? "";
												string arg14 = array12[2].Replace("@cnvsDoingTimeLimit=", "") ?? "";
												text23 = text23 + "<CNVS>" + string.Format(Messages.MobMsgErrorCnvsDoingTimeLimitInStatus, arg13, arg14) + "<\\CNVS>";
											}
											else if (array12[0] == "@StatusResCheckUsedUserIds=PreChckErrs")
											{
												text23 = text23 + "<CNVS>" + string.Format(Messages.MobMsgErrorCanNotSaveCnvsInResult) + "<\\CNVS>";
											}
											else if (array12[0] == "@StatusCheckUsedUserIds=PreChckErrs")
											{
												text23 = text23 + "<CNVS>" + string.Format(Messages.MobMsgErrorCanNotSaveCnvsInStatus) + "<\\CNVS>";
											}
											else if (array12[0] == "@StatusResCheckNeedDyFormCheckedNotExist=PreChckErrs")
											{
												string text25 = array12[1].Replace("@NeedDyFormCheckedForm=", "") ?? "";
												text23 = text23 + "<CNVS>" + string.Format(Messages.MobMsgErrorNotSaveCnvsBeforeInsertDyFormFromCmp, text25 ?? "") + "<\\CNVS>";
											}
										}
									}
									text19 = text23;
								}
								else
								{
									text19 = "";
								}
							}
							else
							{
								insertQuickCmpPrsPrjCnvsResultViewModel.ErrorMessage = "";
							}
						}
						if (objectParameter.Value != null)
						{
							insertQuickCmpPrsPrjCnvsResultViewModel.Company = objectParameter.Value.ToString() ?? "0";
						}
						else
						{
							insertQuickCmpPrsPrjCnvsResultViewModel.Company = "0";
						}
						if (objectParameter2.Value != null)
						{
							insertQuickCmpPrsPrjCnvsResultViewModel.Persons = objectParameter2.Value.ToString() ?? "0";
						}
						else
						{
							insertQuickCmpPrsPrjCnvsResultViewModel.Persons = "0";
						}
						if (objectParameter3.Value != null)
						{
							insertQuickCmpPrsPrjCnvsResultViewModel.Projects = objectParameter3.Value.ToString() ?? "0";
						}
						else
						{
							insertQuickCmpPrsPrjCnvsResultViewModel.Projects = "0";
						}
						if (objectParameter4.Value != null)
						{
							insertQuickCmpPrsPrjCnvsResultViewModel.Conversations = objectParameter4.Value.ToString() ?? "0";
						}
						else
						{
							insertQuickCmpPrsPrjCnvsResultViewModel.Conversations = "0";
						}
						if (objectParameter6.Value != null)
						{
							insertQuickCmpPrsPrjCnvsResultViewModel.Type = objectParameter6.Value.ToString() ?? "";
						}
						else
						{
							insertQuickCmpPrsPrjCnvsResultViewModel.Type = "";
						}
						if (!num2.HasValue || num2 >= 1)
						{
							bool flag = false;
							if (insertQuickCmpPrsPrjCnvsResultViewModel.Type == "Dup")
							{
								ObjectParameter objectParameter7 = new ObjectParameter("errorMessage", "");
								CRMEntities cRMEntities3 = cRMEntities;
								string company2 = model.Company;
								string persons2 = model.Persons;
								string projects2 = model.Projects;
								cmpNotAccess = mobPersonLabel;
								int? id = 0;
								int? userId2 = token2.userId;
								int? languageID2 = result;
								int? defaultLanguageID2 = result2;
								ObjectParameter errorMessage = objectParameter7;
								int? mode = 0;
								cRMEntities3.MobspCheckDuplicateCompanyWithReason(company2, persons2, projects2, id, userId2, languageID2, defaultLanguageID2, mobLackOfShowText, cmpNotAccess, mode, errorMessage, model.CenterId);
								if (objectParameter7.Value != null && objectParameter7.Value.ToString() != "")
								{
									string text26 = objectParameter7.Value.ToString();
									string text27 = "";
									if (text26 != "")
									{
										bool flag2 = false;
										string companyId = "0";
										string personId = "0";
										string[] array11 = text26.Split(new string[1] { "|^|" }, StringSplitOptions.None);
										foreach (string text28 in array11)
										{
											if (string.IsNullOrEmpty(text28))
											{
												continue;
											}
											string[] array13 = text28.Split(new char[1] { ',' });
											string text29 = "";
											string text30 = "";
											string text31 = "";
											string text32 = "";
											string text33 = "";
											string text34 = "";
											string text35 = "";
											if (array13[0] == "@cmpName=Dup")
											{
												text29 = array13[3].Replace("@DupCmpName=", "") ?? "";
												text30 = array13[2].Replace("@DupCmpTitle=", "") ?? "";
												text31 = array13[4].Replace("@DupCmpCity=", "") ?? "";
												text32 = array13[5].Replace("@DupCmpNumber=", "") ?? "";
												text27 = text27 + "<CMP>" + string.Format(Messages.MobMsgErrorCheckCmpNameDuplicate, text29, text30, text31, text32) + "<\\CMP>";
												if (model.IsQuickFullCompany.GetValueOrDefault() && !flag2)
												{
													flag2 = true;
													companyId = array13[1].Replace("@DupCompanyId=", "") ?? "";
												}
											}
											else if (array13[0] == "@cmpName=IsNull")
											{
												text27 = text27 + "<CMP>" + Messages.MobMsgErrorCmpNameNotEntered + "<\\CMP>";
											}
											else if (array13[0] == "@cmpCode=Dup")
											{
												text29 = array13[1].Replace("@cmpName=", "") ?? "";
												text27 = text27 + "<CMP>" + string.Format(Messages.MobCheckcmpCodeDuplicate, text29) + "<\\CMP>";
											}
											else if (array13[0] == "@cmpTel=Dup")
											{
												text29 = array13[1].Replace("@DupCmpName=", "") ?? "";
												text32 = array13[2].Replace("@DupCmpNumber=", "") ?? "";
												text27 = text27 + "<CMP>" + string.Format(Messages.MobCheckDuplicateTel, text32, text29) + "<\\CMP>";
												if (model.IsQuickFullCompany.GetValueOrDefault() && !flag2 && array13.Length > 2)
												{
													flag2 = true;
													companyId = array13[3].Replace("@DupCompanyId=", "") ?? "";
												}
											}
											else if (array13[0] == "@cmpTelII=Dup")
											{
												text29 = array13[1].Replace("@DupCmpName=", "") ?? "";
												text32 = array13[2].Replace("@DupCmpNumber=", "") ?? "";
												text27 = text27 + "<CMP>" + string.Format(Messages.MobCheckDuplicateTelII, text32, text29) + "<\\CMP>";
											}
											else if (array13[0] == "@cmpFax=Dup")
											{
												text29 = array13[1].Replace("@DupCmpName=", "") ?? "";
												text32 = array13[2].Replace("@DupCmpNumber=", "") ?? "";
												text27 = text27 + "<CMP>" + string.Format(Messages.MobCheckDuplicateFax, text32, text29) + "<\\CMP>";
											}
											else if (array13[0] == "@cmpZipCode=Dup")
											{
												text29 = array13[1].Replace("@DupCmpName=", "") ?? "";
												text32 = array13[2].Replace("@DupCmpNumber=", "") ?? "";
												text27 = text27 + "<CMP>" + string.Format(Messages.MobCheckDuplicateZipCode, text32, text29) + "<\\CMP>";
											}
											else if (array13[0] == "@cmpNationalCode=Dup")
											{
												text29 = array13[1].Replace("@DupCmpName=", "") ?? "";
												text32 = array13[2].Replace("@DupCmpNumber=", "") ?? "";
												text27 = text27 + "<CMP>" + string.Format(Messages.MobCheckDuplicateCmpNationalCode, text32, text29) + "<\\CMP>";
											}
											else if (array13[0] == "@cmpEconomicCode=Dup")
											{
												text29 = array13[1].Replace("@DupCmpName=", "") ?? "";
												text32 = array13[2].Replace("@DupCmpNumber=", "") ?? "";
												text27 = text27 + "<CMP>" + string.Format(Messages.MobCheckDuplicateCmpEconomicCode, text32, text29) + "<\\CMP>";
											}
											else if (array13[0] == "@cmpEmail=Dup")
											{
												text29 = array13[1].Replace("@DupCmpName=", "") ?? "";
												text32 = array13[2].Replace("@DupCmpNumber=", "") ?? "";
												text27 = text27 + "<CMP>" + string.Format(Messages.MobCheckDuplicateCmpEmail, text32, text29) + "<\\CMP>";
											}
											else if (array13[0] == "@cmpMobile=Dup")
											{
												text29 = array13[1].Replace("@DupCmpName=", "") ?? "";
												text32 = array13[2].Replace("@DupCmpNumber=", "") ?? "";
												text27 = text27 + "<CMP>" + string.Format(Messages.MobCheckDuplicateCmpMobile, text32, text29) + "<\\CMP>";
												if (model.IsQuickFullCompany.GetValueOrDefault() && !flag2 && array13.Length > 2)
												{
													flag2 = true;
													companyId = array13[3].Replace("@DupCompanyId=", "") ?? "";
												}
											}
											else if (array13[0] == "@prsLName=Dup")
											{
												text35 = array13[2].Replace("@CompanyPersonID=", "") ?? "";
												text33 = array13[1].Replace("@prsLName=", "") ?? "";
												text34 = array13[4].Replace("@prsFName=", "") ?? "";
												text29 = array13[7].Replace("@DupCmpName=", "") ?? "";
												text30 = array13[6].Replace("@DupCmpTitle=", "") ?? "";
												text31 = array13[8].Replace("@DupCmpCity=", "") ?? "";
												text32 = array13[9].Replace("@DupCmpNumber=", "") ?? "";
												text27 = text27 + "<PRS><PRSID>" + text35 + "<\\PRSID>" + string.Format(Messages.MobMsgErrorCheckPrsLNameDuplicate, text34 + " " + text33, text29, text30, text31, text32) + "<\\PRS>";
											}
											if (array13[0] == "@prsLName=IsNull")
											{
												text27 = text27 + "<PRS>" + Messages.MobMsgErrorPrsLNameNotEntered + "<\\PRS>";
											}
											else if (array13[0] == "@prsMobile=Dup")
											{
												text35 = array13[3].Replace("@CompanyPersonID=", "") ?? "";
												text33 = array13[1].Replace("@prsLName=", "") ?? "";
												text34 = array13[2].Replace("@prsFName=", "") ?? "";
												text32 = array13[5].Replace("@DupCmpNumber=", "") ?? "";
												text27 = text27 + "<PRS><PRSID>" + text35 + "<\\PRSID>" + string.Format(Messages.MobMsgErrorCheckPrsMobileDuplicate, text34 + " " + text33, text32) + "<\\PRS>";
												if (model.IsQuickFullCompany.GetValueOrDefault() && !flag2 && array13.Length > 5)
												{
													flag2 = true;
													companyId = array13[6].Replace("@DupCompanyId=", "") ?? "";
													personId = array13[7].Replace("@DupPersonId=", "") ?? "";
												}
											}
											else if (array13[0] == "@prsEmail=Dup")
											{
												text35 = array13[3].Replace("@CompanyPersonID=", "") ?? "";
												text33 = array13[1].Replace("@prsLName=", "") ?? "";
												text34 = array13[2].Replace("@prsFName=", "") ?? "";
												text32 = array13[5].Replace("@DupCmpNumber=", "") ?? "";
												text27 = text27 + "<PRS><PRSID>" + text35 + "<\\PRSID>" + string.Format(Messages.MobMsgErrorCheckPrsEmailDuplicate, text34 + " " + text33, text32) + "<\\PRS>";
											}
											else if (array13[0] == "@prsEmailII=Dup")
											{
												text35 = array13[3].Replace("@CompanyPersonID=", "") ?? "";
												text33 = array13[1].Replace("@prsLName=", "") ?? "";
												text34 = array13[2].Replace("@prsFName=", "") ?? "";
												text32 = array13[5].Replace("@DupCmpNumber=", "") ?? "";
												text27 = text27 + "<PRS><PRSID>" + text35 + "<\\PRSID>" + string.Format(Messages.MobMsgErrorCheckPrsEmailIIDuplicate, text34 + " " + text33, text32) + "<\\PRS>";
											}
											else if (array13[0] == "@prsTel=Dup")
											{
												text35 = array13[3].Replace("@CompanyPersonID=", "") ?? "";
												text29 = array13[1].Replace("@DupCmpName=", "") ?? "";
												text32 = array13[2].Replace("@DupCmpNumber=", "") ?? "";
												text27 = text27 + "<PRS><PRSID>" + text35 + "<\\PRSID>" + string.Format(Messages.MobCheckDuplicateTel, text32, text29) + "<\\PRS>";
											}
											else if (array13[0] == "@prsTelII=Dup")
											{
												text35 = array13[3].Replace("@CompanyPersonID=", "") ?? "";
												text29 = array13[1].Replace("@DupCmpName=", "") ?? "";
												text32 = array13[2].Replace("@DupCmpNumber=", "") ?? "";
												text27 = text27 + "<PRS><PRSID>" + text35 + "<\\PRSID>" + string.Format(Messages.MobCheckDuplicateTelII, text32, text29) + "<\\PRS>";
											}
											else if (array13[0] == "@prsFax=Dup")
											{
												text35 = array13[3].Replace("@CompanyPersonID=", "") ?? "";
												text29 = array13[1].Replace("@DupCmpName=", "") ?? "";
												text32 = array13[2].Replace("@DupCmpNumber=", "") ?? "";
												text27 = text27 + "<PRS><PRSID>" + text35 + "<\\PRSID>" + string.Format(Messages.MobCheckDuplicateFax, text32, text29) + "<\\PRS>";
											}
											else if (array13[0] == "@prsZipCode=Dup")
											{
												text35 = array13[3].Replace("@CompanyPersonID=", "") ?? "";
												text29 = array13[1].Replace("@DupCmpName=", "") ?? "";
												text32 = array13[2].Replace("@DupCmpNumber=", "") ?? "";
												text27 = text27 + "<PRS><PRSID>" + text35 + "<\\PRSID>" + string.Format(Messages.MobCheckDuplicateZipCode, text32, text29) + "<\\PRS>";
											}
											else if (array13[0] == "@prsNationalCode=Dup")
											{
												text35 = array13[3].Replace("@CompanyPersonID=", "") ?? "";
												text29 = array13[1].Replace("@DupCmpName=", "") ?? "";
												text32 = array13[2].Replace("@DupCmpNumber=", "") ?? "";
												text27 = text27 + "<PRS><PRSID>" + text35 + "<\\PRSID>" + string.Format(Messages.MobCheckDuplicatePrsNationalCode, text32, text29) + "<\\PRS>";
											}
											else if (array13[0] == "@mainPrsNationalCode=Dup")
											{
												text35 = array13[3].Replace("@CompanyPersonID=", "") ?? "";
												text29 = array13[1].Replace("@DupCmpName=", "") ?? "";
												text32 = array13[2].Replace("@DupCmpNumber=", "") ?? "";
												text27 = text27 + "<PRS><PRSID>" + text35 + "<\\PRSID>" + string.Format(Messages.MobCheckDuplicateCmpMainPrsNationalCode, text32, text29) + "<\\PRS>";
											}
											else if (array13[0] == "@prjPostFix=Dup")
											{
												text29 = array13[1].Replace("@DupCmpName=", "") ?? "";
												text32 = array13[2].Replace("@DupCmpNumber=", "") ?? "";
												text27 = text27 + "<PRJ>" + string.Format(Messages.MobCheckDuplicatePrjPostFix, text32, text29) + "<\\PRJ>";
											}
											else if (array13[0] == "@prjDesc=Dup")
											{
												text29 = array13[1].Replace("@DupCmpName=", "") ?? "";
												text32 = array13[2].Replace("@DupCmpNumber=", "") ?? "";
												text27 = text27 + "<PRJ>" + string.Format(Messages.MobCheckDuplicatePrjDesc, text32, text29) + "<\\PRJ>";
											}
											else if (array13[0] == "@prjNumRef=Dup")
											{
												text29 = array13[1].Replace("@DupCmpName=", "") ?? "";
												text32 = array13[2].Replace("@DupCmpNumber=", "") ?? "";
												text27 = text27 + "<PRJ>" + string.Format(Messages.MobCheckDuplicatePrjNumRef, text32, text29) + "<\\PRJ>";
											}
											else if (array13[0] == "@prjInquiryNum=Dup")
											{
												text29 = array13[1].Replace("@DupCmpName=", "") ?? "";
												text32 = array13[2].Replace("@DupCmpNumber=", "") ?? "";
												text27 = text27 + "<PRJ>" + string.Format(Messages.MobCheckDuplicatePrjInquiryNum, text32, text29) + "<\\PRJ>";
											}
											else if (array13[0] == "@prjNumR=Dup")
											{
												text29 = array13[1].Replace("@DupCmpName=", "") ?? "";
												text32 = array13[2].Replace("@DupCmpNumber=", "") ?? "";
												text27 = text27 + "<PRJ>" + string.Format(Messages.MobCheckDuplicatePrjNumR, text32, text29) + "<\\PRJ>";
											}
										}
										if (flag2)
										{
											DublicatePrjCnvsInsetData dublicatePrjCnvsInsetData = InsertQuickPrjCnvsForDuplicate(companyId, personId, model.Company, model.Persons, model.Projects, model.Conversations, token2.userId, result, result2, model.CenterId);
											flag = dublicatePrjCnvsInsetData.OutputRes;
											if (!string.IsNullOrWhiteSpace(dublicatePrjCnvsInsetData.Project))
											{
												insertQuickCmpPrsPrjCnvsResultViewModel.Projects = dublicatePrjCnvsInsetData.Project + "|" + insertQuickCmpPrsPrjCnvsResultViewModel.Projects;
											}
											if (!string.IsNullOrWhiteSpace(dublicatePrjCnvsInsetData.Conversation))
											{
												insertQuickCmpPrsPrjCnvsResultViewModel.Conversations = dublicatePrjCnvsInsetData.Conversation + "|" + insertQuickCmpPrsPrjCnvsResultViewModel.Conversations;
											}
											if (!string.IsNullOrWhiteSpace(dublicatePrjCnvsInsetData.PersonId))
											{
												insertQuickCmpPrsPrjCnvsResultViewModel.Persons = dublicatePrjCnvsInsetData.PersonId + "|" + insertQuickCmpPrsPrjCnvsResultViewModel.Persons;
											}
										}
									}
									insertQuickCmpPrsPrjCnvsResultViewModel.ErrorMessage = text19 + " " + text27;
								}
							}
							if (!string.IsNullOrEmpty(insertQuickCmpPrsPrjCnvsResultViewModel.ErrorMessage))
							{
								data = insertQuickCmpPrsPrjCnvsResultViewModel;
								text = insertQuickCmpPrsPrjCnvsResultViewModel.ErrorMessage;
								if (flag)
								{
									int.TryParse(SysSeting.Get().MobCmpQuickRegDupReaction.ToString(), out var result3);
									text = ((result3 != 3) ? (text + "<InsDup>" + Messages.MobMsgNewPrjCnvsInDuplicateCompany + "<\\InsDup>") : (text + "<InsDup>" + Messages.MobMsgNewCnvsInDuplicateCompany + "<\\InsDup>"));
								}
								status = ServiceResultStatus.Fail;
							}
							else if (insertQuickCmpPrsPrjCnvsResultViewModel.Company == "0")
							{
								data = insertQuickCmpPrsPrjCnvsResultViewModel;
								text = Messages.MobMsgErrorDoneOperation;
								status = ServiceResultStatus.Fail;
							}
							else
							{
								PushNotif.NewIntMsgNotify(withthread: true, model.CenterId);
								data = insertQuickCmpPrsPrjCnvsResultViewModel;
								text = Messages.MobMsgSuccessAction;
								status = ServiceResultStatus.Success;
							}
						}
						else
						{
							data = insertQuickCmpPrsPrjCnvsResultViewModel;
							text = Messages.MobMsgErrorDoneOperation;
							status = ServiceResultStatus.Fail;
						}
					}
					else
					{
						data = null;
						text = Messages.MobMsgErrorDoneOperation;
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
			cRMEntities?.Dispose();
		}
		return new ServiceResult<InsertQuickCmpPrsPrjCnvsResultViewModel>
		{
			Message = text,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<InsertQuickCmpPrsPrjCnvsResultViewModel> InsertQuickCompany(InsertQuickCmpPrsPrjCnvsViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		InsertQuickCmpPrsPrjCnvsResultViewModel data = null;
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
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					DateTime now = DateTime.Now;
					string mobPersonLabel = Labels.MobPersonLabel;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(Financial.Get().Id.ToString());
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					_ = Messages.MobConversationErjaShow;
					string appType = Mobile.Classes.Configuration.AppType;
					string mobLackOfShowText = Labels.MobLackOfShowText;
					if (0 == 0)
					{
						bool haveEroroFoCnt = false;
						string foInfoJson = Company.GetFoInfoJson("", "", model.CenterId.ToString(), ref haveEroroFoCnt, 0, model.CenterId.GetValueOrDefault(), isCmp: true, model.cmpReferUserId.GetValueOrDefault(), model.cmpSuppUserId.GetValueOrDefault());
						model.Company = model.Company.Replace("{cmpFOInfo}", foInfoJson);
						ObjectParameter objectParameter = new ObjectParameter("insertedCompanyId", 0);
						ObjectParameter objectParameter2 = new ObjectParameter("errorMessage", "");
						int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspInsertQuickCompany(model.Company, token2.userId, value2, value3, value, registerDatePersian, appType, result, result2, mobPersonLabel, objectParameter, objectParameter2, model.CenterId));
						InsertQuickCmpPrsPrjCnvsResultViewModel insertQuickCmpPrsPrjCnvsResultViewModel = new InsertQuickCmpPrsPrjCnvsResultViewModel();
						string text = "";
						if (objectParameter2.Value != null)
						{
							if (objectParameter2.Value.ToString() != "")
							{
								string text2 = objectParameter2.Value.ToString();
								text2 = text2.Replace("|Msg=0", "<CMP>" + Messages.MobMsgErrorInsertCompany + "<\\CMP>");
								text2 = text2.Replace("Msg=1", "<CMP>" + Messages.MobMsgErrorInconsistencyInCompanySelection + "<\\CMP>");
								text2 = text2.Replace("Msg=2", "<PRS>" + Messages.MobMsgErrorInsertPersons + "<\\PRS>");
								text2 = text2.Replace("Msg=3", "<PRS>" + Messages.MobMsgErrorInsertPerson + "<\\PRS>");
								text2 = text2.Replace("Msg=4", "<PRJ>" + Messages.MobMsgErrorInsertProjects + "<\\PRJ>");
								text2 = text2.Replace("Msg=5", "<PRJ>" + Messages.MobMsgErrorInsertProject + "<\\PRJ>");
								text2 = text2.Replace("Msg=6", "<CNVS>" + Messages.MobMsgErrorInsertSms + "<\\CNVS>");
								text2 = text2.Replace("Msg=7", "<CNVS>" + Messages.MobMsgErrorInsertConversation + "<\\CNVS>");
								insertQuickCmpPrsPrjCnvsResultViewModel.ErrorMessage = text2;
								text = objectParameter2.Value.ToString();
								if (text.IndexOf("|Msg=CmpGroupIdAccess|", StringComparison.Ordinal) >= 0 || text.IndexOf("|Msg=CmpSubGroupIdAccess|", StringComparison.Ordinal) >= 0 || text.IndexOf("|Msg=CmpGroupIdIVAccess|", StringComparison.Ordinal) >= 0 || text.IndexOf("|Msg=CmpProvinceIdAccess|", StringComparison.Ordinal) >= 0 || text.IndexOf("|Msg=CmpCityIdAccess|", StringComparison.Ordinal) >= 0)
								{
									text = text.Replace("|Msg=0", "").Replace("Msg=1", "").Replace("Msg=2", "")
										.Replace("Msg=3", "")
										.Replace("Msg=4", "")
										.Replace("Msg=5", "")
										.Replace("Msg=6", "")
										.Replace("Msg=7", "")
										.Replace("Dup=1Msg=0", "");
									if (text.IndexOf("|Msg=CmpGroupIdAccess|", StringComparison.Ordinal) >= 0)
									{
										string[] array = text.Split(new string[1] { "|Msg=CmpGroupIdAccess|" }, StringSplitOptions.None);
										if (array != null && Enumerable.Count<string>((IEnumerable<string>)array) == 3 && !string.IsNullOrEmpty(array[1]))
										{
											string newValue = "<CMP>" + string.Format(Messages.MobMsgErrorrNotAccessToCmpGroup, array[1]) + "<\\CMP>";
											text = text.Replace("|Msg=CmpGroupIdAccess|" + array[1] + "|Msg=CmpGroupIdAccess|", newValue);
										}
									}
									if (text.IndexOf("|Msg=CmpSubGroupIdAccess|", StringComparison.Ordinal) >= 0)
									{
										string[] array2 = text.Split(new string[1] { "|Msg=CmpSubGroupIdAccess|" }, StringSplitOptions.None);
										if (array2 != null && Enumerable.Count<string>((IEnumerable<string>)array2) == 3 && !string.IsNullOrEmpty(array2[1]))
										{
											string newValue2 = "<CMP>" + string.Format(Messages.MobMsgErrorrNotAccessToCmpSubGroup, array2[1]) + "<\\CMP>";
											text = text.Replace("|Msg=CmpSubGroupIdAccess|" + array2[1] + "|Msg=CmpSubGroupIdAccess|", newValue2);
										}
									}
									if (text.IndexOf("|Msg=CmpGroupIdIVAccess|", StringComparison.Ordinal) >= 0)
									{
										string[] array3 = text.Split(new string[1] { "|Msg=CmpGroupIdIVAccess|" }, StringSplitOptions.None);
										if (array3 != null && Enumerable.Count<string>((IEnumerable<string>)array3) == 3 && !string.IsNullOrEmpty(array3[1]))
										{
											string newValue3 = "<CMP>" + string.Format(Messages.MobMsgErrorrNotAccessToCmpGroupIV, array3[1]) + "<\\CMP>";
											text = text.Replace("|Msg=CmpGroupIdIVAccess|" + array3[1] + "|Msg=CmpGroupIdIVAccess|", newValue3);
										}
									}
									if (text.IndexOf("|Msg=CmpProvinceIdAccess|", StringComparison.Ordinal) >= 0)
									{
										string[] array4 = text.Split(new string[1] { "|Msg=CmpProvinceIdAccess|" }, StringSplitOptions.None);
										if (array4 != null && Enumerable.Count<string>((IEnumerable<string>)array4) == 3 && !string.IsNullOrEmpty(array4[1]))
										{
											string newValue4 = "<CMP>" + string.Format(Messages.MobMsgErrorrNotAccessToProvince, array4[1]) + "<\\CMP>";
											text = text.Replace("|Msg=CmpProvinceIdAccess|" + array4[1] + "|Msg=CmpProvinceIdAccess|", newValue4);
										}
									}
									if (text.IndexOf("|Msg=CmpCityIdAccess|", StringComparison.Ordinal) >= 0)
									{
										string[] array5 = text.Split(new string[1] { "|Msg=CmpCityIdAccess|" }, StringSplitOptions.None);
										if (array5 != null && Enumerable.Count<string>((IEnumerable<string>)array5) == 3 && !string.IsNullOrEmpty(array5[1]))
										{
											string newValue5 = "<CMP>" + string.Format(Messages.MobMsgErrorrNotAccessToCity, array5[1]) + "<\\CMP>";
											text = text.Replace("|Msg=CmpCityIdAccess|" + array5[1] + "|Msg=CmpCityIdAccess|", newValue5);
										}
									}
									insertQuickCmpPrsPrjCnvsResultViewModel.ErrorMessage = text;
								}
								else
								{
									text = "";
								}
							}
							else
							{
								insertQuickCmpPrsPrjCnvsResultViewModel.ErrorMessage = "";
							}
						}
						if (objectParameter.Value != null)
						{
							insertQuickCmpPrsPrjCnvsResultViewModel.Company = objectParameter.Value.ToString() ?? "0";
						}
						else
						{
							insertQuickCmpPrsPrjCnvsResultViewModel.Company = "0";
						}
						insertQuickCmpPrsPrjCnvsResultViewModel.Persons = "0";
						insertQuickCmpPrsPrjCnvsResultViewModel.Projects = "0";
						insertQuickCmpPrsPrjCnvsResultViewModel.Conversations = "0";
						insertQuickCmpPrsPrjCnvsResultViewModel.Type = "";
						if (!num.HasValue || num >= 1)
						{
							if (insertQuickCmpPrsPrjCnvsResultViewModel.ErrorMessage.IndexOf("Dup=1", StringComparison.Ordinal) >= 0)
							{
								insertQuickCmpPrsPrjCnvsResultViewModel.Type = "Dup";
							}
							if (insertQuickCmpPrsPrjCnvsResultViewModel.Type == "Dup")
							{
								ObjectParameter objectParameter3 = new ObjectParameter("errorMessage", "");
								CRMEntities cRMEntities2 = cRMEntities;
								string company = model.Company;
								string persons = model.Persons;
								string projects = model.Projects;
								string personLabel = mobPersonLabel;
								int? id = 0;
								int? userId = token2.userId;
								int? languageID = result;
								int? defaultLanguageID = result2;
								ObjectParameter errorMessage = objectParameter3;
								int? mode = 0;
								cRMEntities2.MobspCheckDuplicateCompanyWithReason(company, persons, projects, id, userId, languageID, defaultLanguageID, mobLackOfShowText, personLabel, mode, errorMessage, model.CenterId);
								if (objectParameter3.Value != null && objectParameter3.Value.ToString() != "")
								{
									string text3 = objectParameter3.Value.ToString();
									string text4 = "";
									if (text3 != "")
									{
										string[] array6 = text3.Split(new string[1] { "|^|" }, StringSplitOptions.None);
										foreach (string text5 in array6)
										{
											if (!string.IsNullOrEmpty(text5))
											{
												string[] array7 = text5.Split(new char[1] { ',' });
												string text6 = "";
												string text7 = "";
												string text8 = "";
												string text9 = "";
												string text10 = "";
												string text11 = "";
												string text12 = "";
												if (array7[0] == "@cmpName=Dup")
												{
													text6 = array7[3].Replace("@DupCmpName=", "") ?? "";
													text7 = array7[2].Replace("@DupCmpTitle=", "") ?? "";
													text8 = array7[4].Replace("@DupCmpCity=", "") ?? "";
													text9 = array7[5].Replace("@DupCmpNumber=", "") ?? "";
													text4 = text4 + "<CMP>" + string.Format(Messages.MobMsgErrorCheckCmpNameDuplicate, text6, text7, text8, text9) + "<\\CMP>";
												}
												else if (array7[0] == "@cmpName=IsNull")
												{
													text4 = text4 + "<CMP>" + Messages.MobMsgErrorCmpNameNotEntered + "<\\CMP>";
												}
												else if (array7[0] == "@cmpTel=Dup")
												{
													text6 = array7[3].Replace("@DupCmpName=", "") ?? "";
													text7 = array7[2].Replace("@DupCmpTitle=", "") ?? "";
													text8 = array7[4].Replace("@DupCmpCity=", "") ?? "";
													text9 = array7[5].Replace("@DupCmpNumber=", "") ?? "";
													text4 = text4 + "<CMP>" + string.Format(Messages.MobMsgErrorCheckCmpTelDuplicate, text6, text7, text8, text9) + "<\\CMP>";
												}
												else if (array7[0] == "@cmpTelII=Dup")
												{
													text6 = array7[3].Replace("@DupCmpName=", "") ?? "";
													text7 = array7[2].Replace("@DupCmpTitle=", "") ?? "";
													text8 = array7[4].Replace("@DupCmpCity=", "") ?? "";
													text9 = array7[5].Replace("@DupCmpNumber=", "") ?? "";
													text4 = text4 + "<CMP>" + string.Format(Messages.MobMsgErrorCheckCmpTelIIDuplicate, text6, text7, text8, text9) + "<\\CMP>";
												}
												else if (array7[0] == "@cmpFax=Dup")
												{
													text6 = array7[3].Replace("@DupCmpName=", "") ?? "";
													text7 = array7[2].Replace("@DupCmpTitle=", "") ?? "";
													text8 = array7[4].Replace("@DupCmpCity=", "") ?? "";
													text9 = array7[5].Replace("@DupCmpNumber=", "") ?? "";
													text4 = text4 + "<CMP>" + string.Format(Messages.MobMsgErrorCheckCmpFaxDuplicate, text6, text7, text8, text9) + "<\\CMP>";
												}
												else if (array7[0] == "@prsLName=Dup")
												{
													text12 = array7[2].Replace("@CompanyPersonID=", "") ?? "";
													text10 = array7[1].Replace("@prsLName=", "") ?? "";
													text11 = array7[4].Replace("@prsFName=", "") ?? "";
													text6 = array7[7].Replace("@DupCmpName=", "") ?? "";
													text7 = array7[6].Replace("@DupCmpTitle=", "") ?? "";
													text8 = array7[8].Replace("@DupCmpCity=", "") ?? "";
													text9 = array7[9].Replace("@DupCmpNumber=", "") ?? "";
													text4 = text4 + "<PRS><PRSID>" + text12 + "<\\PRSID>" + string.Format(Messages.MobMsgErrorCheckPrsLNameDuplicate, text11 + " " + text10, text6, text7, text8, text9) + "<\\PRS>";
												}
												if (array7[0] == "@prsLName=IsNull")
												{
													text4 = text4 + "<PRS>" + Messages.MobMsgErrorPrsLNameNotEntered + "<\\PRS>";
												}
												else if (array7[0] == "@prsTel=Dup")
												{
													text12 = array7[2].Replace("@CompanyPersonID=", "") ?? "";
													text10 = array7[1].Replace("@prsLName=", "") ?? "";
													text11 = array7[4].Replace("@prsFName=", "") ?? "";
													text6 = array7[7].Replace("@DupCmpName=", "") ?? "";
													text7 = array7[6].Replace("@DupCmpTitle=", "") ?? "";
													text8 = array7[8].Replace("@DupCmpCity=", "") ?? "";
													text9 = array7[9].Replace("@DupCmpNumber=", "") ?? "";
													text4 = text4 + "<PRS><PRSID>" + text12 + "<\\PRSID>" + string.Format(Messages.MobMsgErrorCheckPrsTelDuplicate, text11 + " " + text10, text6, text7, text8, text9) + "<\\PRS>";
												}
												else if (array7[0] == "@prsTelII=Dup")
												{
													text12 = array7[2].Replace("@CompanyPersonID=", "") ?? "";
													text10 = array7[1].Replace("@prsLName=", "") ?? "";
													text11 = array7[4].Replace("@prsFName=", "") ?? "";
													text6 = array7[7].Replace("@DupCmpName=", "") ?? "";
													text7 = array7[6].Replace("@DupCmpTitle=", "") ?? "";
													text8 = array7[8].Replace("@DupCmpCity=", "") ?? "";
													text9 = array7[9].Replace("@DupCmpNumber=", "") ?? "";
													text4 = text4 + "<PRS><PRSID>" + text12 + "<\\PRSID>" + string.Format(Messages.MobMsgErrorCheckPrsTelIIDuplicate, text11 + " " + text10, text6, text7, text8, text9) + "<\\PRS>";
												}
												else if (array7[0] == "@prsFax=Dup")
												{
													text12 = array7[2].Replace("@CompanyPersonID=", "") ?? "";
													text10 = array7[1].Replace("@prsLName=", "") ?? "";
													text11 = array7[4].Replace("@prsFName=", "") ?? "";
													text6 = array7[7].Replace("@DupCmpName=", "") ?? "";
													text7 = array7[6].Replace("@DupCmpTitle=", "") ?? "";
													text8 = array7[8].Replace("@DupCmpCity=", "") ?? "";
													text9 = array7[9].Replace("@DupCmpNumber=", "") ?? "";
													text4 = text4 + "<PRS><PRSID>" + text12 + "<\\PRSID>" + string.Format(Messages.MobMsgErrorCheckPrsFaxDuplicate, text11 + " " + text10, text6, text7, text8, text9) + "<\\PRS>";
												}
												else if (array7[0] == "@prsMobile=Dup")
												{
													text12 = array7[3].Replace("@CompanyPersonID=", "") ?? "";
													text10 = array7[1].Replace("@prsLName=", "") ?? "";
													text11 = array7[2].Replace("@prsFName=", "") ?? "";
													text9 = array7[5].Replace("@DupCmpNumber=", "") ?? "";
													text4 = text4 + "<PRS><PRSID>" + text12 + "<\\PRSID>" + string.Format(Messages.MobMsgErrorCheckPrsMobileDuplicate, text11 + " " + text10, text9) + "<\\PRS>";
												}
												else if (array7[0] == "@prsEmail=Dup")
												{
													text12 = array7[3].Replace("@CompanyPersonID=", "") ?? "";
													text10 = array7[1].Replace("@prsLName=", "") ?? "";
													text11 = array7[2].Replace("@prsFName=", "") ?? "";
													text9 = array7[5].Replace("@DupCmpNumber=", "") ?? "";
													text4 = text4 + "<PRS><PRSID>" + text12 + "<\\PRSID>" + string.Format(Messages.MobMsgErrorCheckPrsEmailDuplicate, text11 + " " + text10, text9) + "<\\PRS>";
												}
												else if (array7[0] == "@prsEmailII=Dup")
												{
													text12 = array7[3].Replace("@CompanyPersonID=", "") ?? "";
													text10 = array7[1].Replace("@prsLName=", "") ?? "";
													text11 = array7[2].Replace("@prsFName=", "") ?? "";
													text9 = array7[5].Replace("@DupCmpNumber=", "") ?? "";
													text4 = text4 + "<PRS><PRSID>" + text12 + "<\\PRSID>" + string.Format(Messages.MobMsgErrorCheckPrsEmailIIDuplicate, text11 + " " + text10, text9) + "<\\PRS>";
												}
											}
										}
									}
									insertQuickCmpPrsPrjCnvsResultViewModel.ErrorMessage = text + " " + text4;
								}
							}
							if (!string.IsNullOrEmpty(insertQuickCmpPrsPrjCnvsResultViewModel.ErrorMessage))
							{
								data = insertQuickCmpPrsPrjCnvsResultViewModel;
								message = insertQuickCmpPrsPrjCnvsResultViewModel.ErrorMessage;
								status = ServiceResultStatus.Fail;
							}
							else
							{
								data = insertQuickCmpPrsPrjCnvsResultViewModel;
								message = Messages.MobMsgSuccessAction;
								status = ServiceResultStatus.Success;
							}
						}
						else
						{
							data = insertQuickCmpPrsPrjCnvsResultViewModel;
							message = Messages.MobMsgErrorDoneOperation;
							status = ServiceResultStatus.Fail;
						}
					}
					else
					{
						data = null;
						message = Messages.MobMsgErrorDoneOperation;
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
		return new ServiceResult<InsertQuickCmpPrsPrjCnvsResultViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<InsertQuickCmpPrsPrjCnvsResultViewModel> InsertQuickPerson(InsertQuickCmpPrsPrjCnvsViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		InsertQuickCmpPrsPrjCnvsResultViewModel data = null;
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
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					DateTime now = DateTime.Now;
					string mobPersonLabel = Labels.MobPersonLabel;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(Financial.Get().Id.ToString());
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					_ = Messages.MobConversationErjaShow;
					string appType = Mobile.Classes.Configuration.AppType;
					string mobLackOfShowText = Labels.MobLackOfShowText;
					if (0 == 0)
					{
						bool haveEroroFoCnt = false;
						string foInfoJson = Company.GetFoInfoJson("", "", model.cmpCIds, ref haveEroroFoCnt, 0, model.CenterId.GetValueOrDefault());
						model.Persons = model.Persons.Replace("{prsFOInfo}", foInfoJson);
						ObjectParameter objectParameter = new ObjectParameter("insertedPersonIds", "");
						ObjectParameter objectParameter2 = new ObjectParameter("errorMessage", "");
						CRMEntities cRMEntities2 = cRMEntities;
						string persons = model.Persons;
						int? userId = token2.userId;
						short? year = value2;
						short? month = value3;
						DateTime? registerDate = value;
						int? languageID = result;
						int? defaultLanguageID = result2;
						ObjectParameter insertedPersonIds = objectParameter;
						ObjectParameter errorMessage = objectParameter2;
						int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities2.MobspInsertQuickPerson(persons, userId, year, month, registerDate, registerDatePersian, appType, languageID, defaultLanguageID, model.Type, insertedPersonIds, errorMessage, model.CenterId));
						InsertQuickCmpPrsPrjCnvsResultViewModel insertQuickCmpPrsPrjCnvsResultViewModel = new InsertQuickCmpPrsPrjCnvsResultViewModel();
						string text = "";
						if (objectParameter2.Value != null)
						{
							if (objectParameter2.Value.ToString() != "")
							{
								string text2 = objectParameter2.Value.ToString();
								text2 = text2.Replace("|Msg=0", "<CMP>" + Messages.MobMsgErrorInsertCompany + "<\\CMP>");
								text2 = text2.Replace("Msg=1", "<CMP>" + Messages.MobMsgErrorInconsistencyInCompanySelection + "<\\CMP>");
								text2 = text2.Replace("Msg=2", "<PRS>" + Messages.MobMsgErrorInsertPersons + "<\\PRS>");
								text2 = text2.Replace("Msg=3", "<PRS>" + Messages.MobMsgErrorInsertPerson + "<\\PRS>");
								text2 = text2.Replace("Msg=4", "<PRJ>" + Messages.MobMsgErrorInsertProjects + "<\\PRJ>");
								text2 = text2.Replace("Msg=5", "<PRJ>" + Messages.MobMsgErrorInsertProject + "<\\PRJ>");
								text2 = text2.Replace("Msg=6", "<CNVS>" + Messages.MobMsgErrorInsertSms + "<\\CNVS>");
								text2 = text2.Replace("Msg=7", "<CNVS>" + Messages.MobMsgErrorInsertConversation + "<\\CNVS>");
								insertQuickCmpPrsPrjCnvsResultViewModel.ErrorMessage = text2;
								text = objectParameter2.Value.ToString();
								if (text.IndexOf("|Msg=CompanyAccess|", StringComparison.Ordinal) >= 0)
								{
									text = text.Replace("|Msg=0", "").Replace("Msg=1", "").Replace("Msg=2", "")
										.Replace("Msg=3", "")
										.Replace("Msg=4", "")
										.Replace("Msg=5", "")
										.Replace("Msg=6", "")
										.Replace("Msg=7", "")
										.Replace("Dup=1Msg=0", "");
									if (text.IndexOf("|Msg=CompanyAccess|", StringComparison.Ordinal) >= 0)
									{
										string[] array = text.Split(new string[1] { "|Msg=CompanyAccess|" }, StringSplitOptions.None);
										if (array != null && Enumerable.Count<string>((IEnumerable<string>)array) == 3)
										{
											if (!string.IsNullOrEmpty(array[1]))
											{
												string[] array2 = array[1].Split(new string[1] { "|PRSID|" }, StringSplitOptions.None);
												if (array2 != null && Enumerable.Count<string>((IEnumerable<string>)array2) == 2)
												{
													string text3 = string.Format(Messages.MobMsgErrorrNotAccessToCompany, array2[1]);
													string newValue = "<PRS><PRSID>" + array2[0] + "<\\PRSID><PRSCOMPANY>" + text3 + "<\\PRSCOMPANY><\\PRS>";
													text = text.Replace("|Msg=CompanyAccess|" + array[1] + "|Msg=CompanyAccess|", newValue);
												}
											}
										}
										else if (array != null && Enumerable.Count<string>((IEnumerable<string>)array) > 3)
										{
											for (int i = 1; i < Enumerable.Count<string>((IEnumerable<string>)array); i++)
											{
												if (!string.IsNullOrEmpty(array[i]))
												{
													string[] array3 = array[i].Split(new string[1] { "|PRSID|" }, StringSplitOptions.None);
													if (array3 != null && Enumerable.Count<string>((IEnumerable<string>)array3) == 2)
													{
														string text4 = string.Format(Messages.MobMsgErrorrNotAccessToCompany, array3[1]);
														string newValue2 = "<PRS><PRSID>" + array3[0] + "<\\PRSID><PRSCOMPANY>" + text4 + "<\\PRSCOMPANY><\\PRS>";
														text = text.Replace("|Msg=CompanyAccess|" + array[i] + "|Msg=CompanyAccess|", newValue2);
													}
												}
											}
										}
									}
									insertQuickCmpPrsPrjCnvsResultViewModel.ErrorMessage = text;
								}
								else
								{
									text = "";
								}
							}
							else
							{
								insertQuickCmpPrsPrjCnvsResultViewModel.ErrorMessage = "";
							}
						}
						insertQuickCmpPrsPrjCnvsResultViewModel.Company = "";
						if (objectParameter.Value != null)
						{
							insertQuickCmpPrsPrjCnvsResultViewModel.Persons = objectParameter.Value.ToString() ?? "0";
						}
						else
						{
							insertQuickCmpPrsPrjCnvsResultViewModel.Persons = "0";
						}
						insertQuickCmpPrsPrjCnvsResultViewModel.Projects = "0";
						insertQuickCmpPrsPrjCnvsResultViewModel.Conversations = "0";
						insertQuickCmpPrsPrjCnvsResultViewModel.Type = "";
						if (!num.HasValue || num >= 1)
						{
							if (insertQuickCmpPrsPrjCnvsResultViewModel.ErrorMessage.IndexOf("Dup=1", StringComparison.Ordinal) >= 0)
							{
								insertQuickCmpPrsPrjCnvsResultViewModel.Type = "Dup";
							}
							if (insertQuickCmpPrsPrjCnvsResultViewModel.Type == "Dup")
							{
								ObjectParameter objectParameter3 = new ObjectParameter("errorMessage", "");
								CRMEntities cRMEntities3 = cRMEntities;
								string company = model.Company;
								string persons2 = model.Persons;
								string projects = model.Projects;
								string personLabel = mobPersonLabel;
								int? id = 0;
								int? userId2 = token2.userId;
								int? languageID2 = result;
								int? defaultLanguageID2 = result2;
								errorMessage = objectParameter3;
								int? mode = 0;
								cRMEntities3.MobspCheckDuplicateCompanyWithReason(company, persons2, projects, id, userId2, languageID2, defaultLanguageID2, mobLackOfShowText, personLabel, mode, errorMessage, model.CenterId);
								if (objectParameter3.Value != null && objectParameter3.Value.ToString() != "")
								{
									string text5 = objectParameter3.Value.ToString();
									string text6 = "";
									if (text5 != "")
									{
										string[] array4 = text5.Split(new string[1] { "|^|" }, StringSplitOptions.None);
										foreach (string text7 in array4)
										{
											if (!string.IsNullOrEmpty(text7))
											{
												string[] array5 = text7.Split(new char[1] { ',' });
												string text8 = "";
												string text9 = "";
												string text10 = "";
												string text11 = "";
												string text12 = "";
												string text13 = "";
												string text14 = "";
												if (array5[0] == "@prsLName=Dup")
												{
													text14 = array5[2].Replace("@CompanyPersonID=", "") ?? "";
													text12 = array5[1].Replace("@prsLName=", "") ?? "";
													text13 = array5[4].Replace("@prsFName=", "") ?? "";
													text8 = array5[7].Replace("@DupCmpName=", "") ?? "";
													text9 = array5[6].Replace("@DupCmpTitle=", "") ?? "";
													text10 = array5[8].Replace("@DupCmpCity=", "") ?? "";
													text11 = array5[9].Replace("@DupCmpNumber=", "") ?? "";
													text6 = text6 + "<PRS><PRSID>" + text14 + "<\\PRSID>" + string.Format(Messages.MobMsgErrorCheckPrsLNameDuplicate, text13 + " " + text12, text8, text9, text10, text11) + "<\\PRS>";
												}
												else if (array5[0] == "@prsLName=IsNull")
												{
													text6 = text6 + "<PRS>" + Messages.MobMsgErrorPrsLNameNotEntered + "<\\PRS>";
												}
												else if (array5[0] == "@prsMobile=Dup")
												{
													text14 = array5[3].Replace("@CompanyPersonID=", "") ?? "";
													text12 = array5[1].Replace("@prsLName=", "") ?? "";
													text13 = array5[2].Replace("@prsFName=", "") ?? "";
													text11 = array5[5].Replace("@DupCmpNumber=", "") ?? "";
													text6 = text6 + "<PRS><PRSID>" + text14 + "<\\PRSID>" + string.Format(Messages.MobMsgErrorCheckPrsMobileDuplicate, text13 + " " + text12, text11) + "<\\PRS>";
												}
												else if (array5[0] == "@prsEmail=Dup")
												{
													text14 = array5[3].Replace("@CompanyPersonID=", "") ?? "";
													text12 = array5[1].Replace("@prsLName=", "") ?? "";
													text13 = array5[2].Replace("@prsFName=", "") ?? "";
													text11 = array5[5].Replace("@DupCmpNumber=", "") ?? "";
													text6 = text6 + "<PRS><PRSID>" + text14 + "<\\PRSID>" + string.Format(Messages.MobMsgErrorCheckPrsEmailDuplicate, text13 + " " + text12, text11) + "<\\PRS>";
												}
												else if (array5[0] == "@prsEmailII=Dup")
												{
													text14 = array5[3].Replace("@CompanyPersonID=", "") ?? "";
													text12 = array5[1].Replace("@prsLName=", "") ?? "";
													text13 = array5[2].Replace("@prsFName=", "") ?? "";
													text11 = array5[5].Replace("@DupCmpNumber=", "") ?? "";
													text6 = text6 + "<PRS><PRSID>" + text14 + "<\\PRSID>" + string.Format(Messages.MobMsgErrorCheckPrsEmailIIDuplicate, text13 + " " + text12, text11) + "<\\PRS>";
												}
												else if (array5[0] == "@prsTel=Dup")
												{
													text14 = array5[3].Replace("@CompanyPersonID=", "") ?? "";
													text8 = array5[1].Replace("@DupCmpName=", "") ?? "";
													text11 = array5[2].Replace("@DupCmpNumber=", "") ?? "";
													text6 = text6 + "<PRS><PRSID>" + text14 + "<\\PRSID>" + string.Format(Messages.MobCheckDuplicateTel, text11, text8) + "<\\PRS>";
												}
												else if (array5[0] == "@prsTelII=Dup")
												{
													text14 = array5[3].Replace("@CompanyPersonID=", "") ?? "";
													text8 = array5[1].Replace("@DupCmpName=", "") ?? "";
													text11 = array5[2].Replace("@DupCmpNumber=", "") ?? "";
													text6 = text6 + "<PRS><PRSID>" + text14 + "<\\PRSID>" + string.Format(Messages.MobCheckDuplicateTelII, text11, text8) + "<\\PRS>";
												}
												else if (array5[0] == "@prsFax=Dup")
												{
													text14 = array5[3].Replace("@CompanyPersonID=", "") ?? "";
													text8 = array5[1].Replace("@DupCmpName=", "") ?? "";
													text11 = array5[2].Replace("@DupCmpNumber=", "") ?? "";
													text6 = text6 + "<PRS><PRSID>" + text14 + "<\\PRSID>" + string.Format(Messages.MobCheckDuplicateFax, text11, text8) + "<\\PRS>";
												}
												else if (array5[0] == "@prsZipCode=Dup")
												{
													text14 = array5[3].Replace("@CompanyPersonID=", "") ?? "";
													text8 = array5[1].Replace("@DupCmpName=", "") ?? "";
													text11 = array5[2].Replace("@DupCmpNumber=", "") ?? "";
													text6 = text6 + "<PRS><PRSID>" + text14 + "<\\PRSID>" + string.Format(Messages.MobCheckDuplicateZipCode, text11, text8) + "<\\PRS>";
												}
												else if (array5[0] == "@prsNationalCode=Dup")
												{
													text14 = array5[3].Replace("@CompanyPersonID=", "") ?? "";
													text8 = array5[1].Replace("@DupCmpName=", "") ?? "";
													text11 = array5[2].Replace("@DupCmpNumber=", "") ?? "";
													text6 = text6 + "<PRS><PRSID>" + text14 + "<\\PRSID>" + string.Format(Messages.MobCheckDuplicatePrsNationalCode, text11, text8) + "<\\PRS>";
												}
												else if (array5[0] == "@mainPrsNationalCode=Dup")
												{
													text14 = array5[3].Replace("@CompanyPersonID=", "") ?? "";
													text8 = array5[1].Replace("@DupCmpName=", "") ?? "";
													text11 = array5[2].Replace("@DupCmpNumber=", "") ?? "";
													text6 = text6 + "<PRS><PRSID>" + text14 + "<\\PRSID>" + string.Format(Messages.MobCheckDuplicateCmpMainPrsNationalCode, text11, text8) + "<\\PRS>";
												}
											}
										}
									}
									insertQuickCmpPrsPrjCnvsResultViewModel.ErrorMessage = text + " " + text6;
								}
							}
							if (!string.IsNullOrEmpty(insertQuickCmpPrsPrjCnvsResultViewModel.ErrorMessage))
							{
								data = insertQuickCmpPrsPrjCnvsResultViewModel;
								message = insertQuickCmpPrsPrjCnvsResultViewModel.ErrorMessage;
								status = ServiceResultStatus.Fail;
							}
							else
							{
								data = insertQuickCmpPrsPrjCnvsResultViewModel;
								message = Messages.MobMsgSuccessAction;
								status = ServiceResultStatus.Success;
							}
						}
						else
						{
							data = insertQuickCmpPrsPrjCnvsResultViewModel;
							message = Messages.MobMsgErrorDoneOperation;
							status = ServiceResultStatus.Fail;
						}
					}
					else
					{
						data = null;
						message = Messages.MobMsgErrorDoneOperation;
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
		return new ServiceResult<InsertQuickCmpPrsPrjCnvsResultViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<InsertQuickCmpPrsPrjCnvsResultViewModel> InsertQuickProject(InsertQuickCmpPrsPrjCnvsViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		InsertQuickCmpPrsPrjCnvsResultViewModel data = null;
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
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					DateTime now = DateTime.Now;
					string mobPersonLabel = Labels.MobPersonLabel;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(Financial.Get().Id.ToString());
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					_ = Messages.MobConversationErjaShow;
					string appType = Mobile.Classes.Configuration.AppType;
					if (0 == 0)
					{
						ObjectParameter objectParameter = new ObjectParameter("insertedProjectIds", "");
						ObjectParameter objectParameter2 = new ObjectParameter("errorMessage", "");
						int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspInsertQuickProject(model.Projects, token2.userId, value2, value3, value, registerDatePersian, appType, result, result2, model.Type, objectParameter, objectParameter2, model.CenterId));
						InsertQuickCmpPrsPrjCnvsResultViewModel insertQuickCmpPrsPrjCnvsResultViewModel = new InsertQuickCmpPrsPrjCnvsResultViewModel();
						string text = "";
						if (objectParameter2.Value != null)
						{
							if (objectParameter2.Value.ToString() != "")
							{
								string text2 = objectParameter2.Value.ToString();
								text2 = text2.Replace("|Msg=0", "<CMP>" + Messages.MobMsgErrorInsertCompany + "<\\CMP>");
								text2 = text2.Replace("Msg=1", "<CMP>" + Messages.MobMsgErrorInconsistencyInCompanySelection + "<\\CMP>");
								text2 = text2.Replace("Msg=2", "<PRS>" + Messages.MobMsgErrorInsertPersons + "<\\PRS>");
								text2 = text2.Replace("Msg=3", "<PRS>" + Messages.MobMsgErrorInsertPerson + "<\\PRS>");
								text2 = text2.Replace("Msg=4", "<PRJ>" + Messages.MobMsgErrorInsertProjects + "<\\PRJ>");
								text2 = text2.Replace("Msg=5", "<PRJ>" + Messages.MobMsgErrorInsertProject + "<\\PRJ>");
								text2 = text2.Replace("Msg=6", "<CNVS>" + Messages.MobMsgErrorInsertSms + "<\\CNVS>");
								text2 = text2.Replace("Msg=7", "<CNVS>" + Messages.MobMsgErrorInsertConversation + "<\\CNVS>");
								text2 = text2.Replace("Msg=8", "<PRJ>" + Messages.MobMsgErrorPrjValidityPrdNotValid + "<\\PRJ>");
								insertQuickCmpPrsPrjCnvsResultViewModel.ErrorMessage = text2;
								text = objectParameter2.Value.ToString();
								if (text.IndexOf("|Msg=CompanyAccess|", StringComparison.Ordinal) >= 0 || text.IndexOf("|Msg=PrjAccess|", StringComparison.Ordinal) >= 0)
								{
									text = text.Replace("|Msg=0", "").Replace("Msg=1", "").Replace("Msg=2", "")
										.Replace("Msg=3", "")
										.Replace("Msg=4", "")
										.Replace("Msg=5", "")
										.Replace("Msg=6", "")
										.Replace("Msg=7", "")
										.Replace("Dup=1Msg=0", "");
									if (text.IndexOf("|Msg=CompanyAccess|", StringComparison.Ordinal) >= 0)
									{
										string[] array = text.Split(new string[1] { "|Msg=CompanyAccess|" }, StringSplitOptions.None);
										if (array != null && Enumerable.Count<string>((IEnumerable<string>)array) == 3)
										{
											if (!string.IsNullOrEmpty(array[1]))
											{
												string[] array2 = array[1].Split(new string[1] { "|PRJID|" }, StringSplitOptions.None);
												if (array2 != null && Enumerable.Count<string>((IEnumerable<string>)array2) == 2)
												{
													string text3 = string.Format(Messages.MobMsgErrorrNotAccessToCompany, array2[1]);
													string newValue = "<PRJ><PRJID>" + array2[0] + "<\\PRJID><PRJCOMPANY>" + text3 + "<\\PRJCOMPANY><\\PRJ>";
													text = text.Replace("|Msg=CompanyAccess|" + array[1] + "|Msg=CompanyAccess|", newValue);
												}
											}
										}
										else if (array != null && Enumerable.Count<string>((IEnumerable<string>)array) > 3)
										{
											for (int i = 1; i < Enumerable.Count<string>((IEnumerable<string>)array); i++)
											{
												if (!string.IsNullOrEmpty(array[i]))
												{
													string[] array3 = array[i].Split(new string[1] { "|PRJID|" }, StringSplitOptions.None);
													if (array3 != null && Enumerable.Count<string>((IEnumerable<string>)array3) == 2)
													{
														string text4 = string.Format(Messages.MobMsgErrorrNotAccessToCompany, array3[1]);
														string newValue2 = "<PRJ><PRJID>" + array3[0] + "<\\PRJID><PRJCOMPANY>" + text4 + "<\\PRJCOMPANY><\\PRJ>";
														text = text.Replace("|Msg=CompanyAccess|" + array[i] + "|Msg=CompanyAccess|", newValue2);
													}
												}
											}
										}
									}
									if (text.IndexOf("|Msg=PrjAccess|", StringComparison.Ordinal) >= 0)
									{
										string[] array4 = text.Split(new string[1] { "|Msg=PrjAccess|" }, StringSplitOptions.None);
										if (array4 != null && Enumerable.Count<string>((IEnumerable<string>)array4) == 3)
										{
											if (!string.IsNullOrEmpty(array4[1]))
											{
												string[] array5 = array4[1].Split(new string[1] { "|PRJID|" }, StringSplitOptions.None);
												if (array5 != null && Enumerable.Count<string>((IEnumerable<string>)array5) == 2)
												{
													string text5 = string.Format(Messages.MobMsgErrorrNotAccessToProject, array5[1]);
													string newValue3 = "<PRJ><PRJID>" + array5[0] + "<\\PRJID><PRJTITLE>" + text5 + "<\\PRJTITLE><\\PRJ>";
													text = text.Replace("|Msg=PrjAccess|" + array4[1] + "|Msg=PrjAccess|", newValue3);
												}
											}
										}
										else if (array4 != null && Enumerable.Count<string>((IEnumerable<string>)array4) > 3)
										{
											for (int j = 1; j < Enumerable.Count<string>((IEnumerable<string>)array4); j++)
											{
												if (!string.IsNullOrEmpty(array4[j]))
												{
													string[] array6 = array4[j].Split(new string[1] { "|PRJID|" }, StringSplitOptions.None);
													if (array6 != null && Enumerable.Count<string>((IEnumerable<string>)array6) == 2)
													{
														string text6 = string.Format(Messages.MobMsgErrorrNotAccessToProject, array6[1]);
														string newValue4 = "<PRJ><PRJID>" + array6[0] + "<\\PRJID><PRJTITLE>" + text6 + "<\\PRJTITLE><\\PRJ>";
														text = text.Replace("|Msg=PrjAccess|" + array4[j] + "|Msg=PrjAccess|", newValue4);
													}
												}
											}
										}
									}
									insertQuickCmpPrsPrjCnvsResultViewModel.ErrorMessage = text;
								}
								else
								{
									text = "";
								}
							}
							else
							{
								insertQuickCmpPrsPrjCnvsResultViewModel.ErrorMessage = "";
							}
						}
						insertQuickCmpPrsPrjCnvsResultViewModel.Company = "0";
						insertQuickCmpPrsPrjCnvsResultViewModel.Persons = "0";
						if (objectParameter.Value != null)
						{
							insertQuickCmpPrsPrjCnvsResultViewModel.Projects = objectParameter.Value.ToString() ?? "0";
						}
						else
						{
							insertQuickCmpPrsPrjCnvsResultViewModel.Projects = "0";
						}
						insertQuickCmpPrsPrjCnvsResultViewModel.Conversations = "0";
						insertQuickCmpPrsPrjCnvsResultViewModel.Type = "";
						if (!num.HasValue || num >= 1)
						{
							if (insertQuickCmpPrsPrjCnvsResultViewModel.ErrorMessage.IndexOf("Dup=1", StringComparison.Ordinal) >= 0)
							{
								insertQuickCmpPrsPrjCnvsResultViewModel.Type = "Dup";
							}
							if (insertQuickCmpPrsPrjCnvsResultViewModel.Type == "Dup")
							{
								ObjectParameter objectParameter3 = new ObjectParameter("errorMessage", "");
								CRMEntities cRMEntities2 = cRMEntities;
								string company = model.Company;
								string persons = model.Persons;
								string projects = model.Projects;
								string personLabel = mobPersonLabel;
								int? id = 0;
								int? userId = token2.userId;
								int? languageID = result;
								int? defaultLanguageID = result2;
								ObjectParameter errorMessage = objectParameter3;
								cRMEntities2.MobspCheckDuplicateCompanyWithReason(company, persons, projects, id, userId, languageID, defaultLanguageID, null, personLabel, 0, errorMessage, model.CenterId);
								if (objectParameter3.Value != null && objectParameter3.Value.ToString() != "")
								{
									string text7 = objectParameter3.Value.ToString();
									string text8 = "";
									if (text7 != "")
									{
										string[] array7 = text7.Split(new string[1] { "|^|" }, StringSplitOptions.None);
										foreach (string text9 in array7)
										{
											if (!string.IsNullOrEmpty(text9))
											{
												string[] array8 = text9.Split(new char[1] { ',' });
												string text10 = "";
												string text11 = "";
												if (array8[0] == "@prjPostFix=Dup")
												{
													text10 = array8[1].Replace("@DupCmpName=", "") ?? "";
													text11 = array8[2].Replace("@DupCmpNumber=", "") ?? "";
													text8 = text8 + "<PRJ>" + string.Format(Messages.MobCheckDuplicatePrjPostFix, text11, text10) + "<\\PRJ>";
												}
												else if (array8[0] == "@prjDesc=Dup")
												{
													text10 = array8[1].Replace("@DupCmpName=", "") ?? "";
													text11 = array8[2].Replace("@DupCmpNumber=", "") ?? "";
													text8 = text8 + "<PRJ>" + string.Format(Messages.MobCheckDuplicatePrjDesc, text11, text10) + "<\\PRJ>";
												}
												else if (array8[0] == "@prjNumRef=Dup")
												{
													text10 = array8[1].Replace("@DupCmpName=", "") ?? "";
													text11 = array8[2].Replace("@DupCmpNumber=", "") ?? "";
													text8 = text8 + "<PRJ>" + string.Format(Messages.MobCheckDuplicatePrjNumRef, text11, text10) + "<\\PRJ>";
												}
												else if (array8[0] == "@prjInquiryNum=Dup")
												{
													text10 = array8[1].Replace("@DupCmpName=", "") ?? "";
													text11 = array8[2].Replace("@DupCmpNumber=", "") ?? "";
													text8 = text8 + "<PRJ>" + string.Format(Messages.MobCheckDuplicatePrjInquiryNum, text11, text10) + "<\\PRJ>";
												}
												else if (array8[0] == "@prjNumR=Dup")
												{
													text10 = array8[1].Replace("@DupCmpName=", "") ?? "";
													text11 = array8[2].Replace("@DupCmpNumber=", "") ?? "";
													text8 = text8 + "<PRJ>" + string.Format(Messages.MobCheckDuplicatePrjNumR, text11, text10) + "<\\PRJ>";
												}
											}
										}
									}
									insertQuickCmpPrsPrjCnvsResultViewModel.ErrorMessage = text + " " + text8;
								}
							}
							if (!string.IsNullOrEmpty(insertQuickCmpPrsPrjCnvsResultViewModel.ErrorMessage))
							{
								data = insertQuickCmpPrsPrjCnvsResultViewModel;
								message = insertQuickCmpPrsPrjCnvsResultViewModel.ErrorMessage;
								status = ServiceResultStatus.Fail;
							}
							else
							{
								data = insertQuickCmpPrsPrjCnvsResultViewModel;
								message = Messages.MobMsgSuccessAction;
								status = ServiceResultStatus.Success;
							}
						}
						else
						{
							data = insertQuickCmpPrsPrjCnvsResultViewModel;
							message = Messages.MobMsgErrorDoneOperation;
							status = ServiceResultStatus.Fail;
						}
					}
					else
					{
						data = null;
						message = Messages.MobMsgErrorDoneOperation;
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
		return new ServiceResult<InsertQuickCmpPrsPrjCnvsResultViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<InsertQuickCmpPrsPrjCnvsResultViewModel> InsertQuickProjectIfNotExists(InsertQuickCmpPrsPrjCnvsViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		InsertQuickCmpPrsPrjCnvsResultViewModel insertQuickCmpPrsPrjCnvsResultViewModel = null;
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
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					DateTime now = DateTime.Now;
					string mobPersonLabel = Labels.MobPersonLabel;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(Financial.Get().Id.ToString());
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					_ = Messages.MobConversationErjaShow;
					string appType = Mobile.Classes.Configuration.AppType;
					insertQuickCmpPrsPrjCnvsResultViewModel = new InsertQuickCmpPrsPrjCnvsResultViewModel();
					string projectTitle = model.Projects.Substring(model.Projects.IndexOf("prjTitle=") + 9, model.Projects.IndexOf("|#|prjStartDate=") - (model.Projects.IndexOf("prjTitle=") + 9));
					string s = model.Projects.Substring(model.Projects.IndexOf("prjCompanyId=") + 13, model.Projects.IndexOf("|#|prjTitle=") - (model.Projects.IndexOf("prjCompanyId=") + 13));
					MobspSelectCrmProjectByProjectTitle_Result mobspSelectCrmProjectByProjectTitle_Result = Enumerable.FirstOrDefault<MobspSelectCrmProjectByProjectTitle_Result>((IEnumerable<MobspSelectCrmProjectByProjectTitle_Result>)cRMEntities.MobspSelectCrmProjectByProjectTitle(projectTitle, int.Parse(s), result, result2));
					if (mobspSelectCrmProjectByProjectTitle_Result == null)
					{
						ObjectParameter objectParameter = new ObjectParameter("insertedProjectIds", "");
						ObjectParameter objectParameter2 = new ObjectParameter("errorMessage", "");
						int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspInsertQuickProject(model.Projects, token2.userId, value2, value3, value, registerDatePersian, appType, result, result2, model.Type, objectParameter, objectParameter2, model.CenterId));
						InsertQuickCmpPrsPrjCnvsResultViewModel insertQuickCmpPrsPrjCnvsResultViewModel2 = new InsertQuickCmpPrsPrjCnvsResultViewModel();
						string text = "";
						if (objectParameter2.Value != null)
						{
							if (objectParameter2.Value.ToString() != "")
							{
								string text2 = objectParameter2.Value.ToString();
								text2 = text2.Replace("|Msg=0", "<CMP>" + Messages.MobMsgErrorInsertCompany + "<\\CMP>");
								text2 = text2.Replace("Msg=1", "<CMP>" + Messages.MobMsgErrorInconsistencyInCompanySelection + "<\\CMP>");
								text2 = text2.Replace("Msg=2", "<PRS>" + Messages.MobMsgErrorInsertPersons + "<\\PRS>");
								text2 = text2.Replace("Msg=3", "<PRS>" + Messages.MobMsgErrorInsertPerson + "<\\PRS>");
								text2 = text2.Replace("Msg=4", "<PRJ>" + Messages.MobMsgErrorInsertProjects + "<\\PRJ>");
								text2 = text2.Replace("Msg=5", "<PRJ>" + Messages.MobMsgErrorInsertProject + "<\\PRJ>");
								text2 = text2.Replace("Msg=6", "<CNVS>" + Messages.MobMsgErrorInsertSms + "<\\CNVS>");
								text2 = text2.Replace("Msg=7", "<CNVS>" + Messages.MobMsgErrorInsertConversation + "<\\CNVS>");
								insertQuickCmpPrsPrjCnvsResultViewModel2.ErrorMessage = text2;
								text = objectParameter2.Value.ToString();
								if (text.IndexOf("|Msg=CompanyAccess|", StringComparison.Ordinal) >= 0 || text.IndexOf("|Msg=PrjAccess|", StringComparison.Ordinal) >= 0)
								{
									text = text.Replace("|Msg=0", "").Replace("Msg=1", "").Replace("Msg=2", "")
										.Replace("Msg=3", "")
										.Replace("Msg=4", "")
										.Replace("Msg=5", "")
										.Replace("Msg=6", "")
										.Replace("Msg=7", "")
										.Replace("Dup=1Msg=0", "");
									if (text.IndexOf("|Msg=CompanyAccess|", StringComparison.Ordinal) >= 0)
									{
										string[] array = text.Split(new string[1] { "|Msg=CompanyAccess|" }, StringSplitOptions.None);
										if (array != null && Enumerable.Count<string>((IEnumerable<string>)array) == 3)
										{
											if (!string.IsNullOrEmpty(array[1]))
											{
												string[] array2 = array[1].Split(new string[1] { "|PRJID|" }, StringSplitOptions.None);
												if (array2 != null && Enumerable.Count<string>((IEnumerable<string>)array2) == 2)
												{
													string text3 = string.Format(Messages.MobMsgErrorrNotAccessToCompany, array2[1]);
													string newValue = "<PRJ><PRJID>" + array2[0] + "<\\PRJID><PRJCOMPANY>" + text3 + "<\\PRJCOMPANY><\\PRJ>";
													text = text.Replace("|Msg=CompanyAccess|" + array[1] + "|Msg=CompanyAccess|", newValue);
												}
											}
										}
										else if (array != null && Enumerable.Count<string>((IEnumerable<string>)array) > 3)
										{
											for (int i = 1; i < Enumerable.Count<string>((IEnumerable<string>)array); i++)
											{
												if (!string.IsNullOrEmpty(array[i]))
												{
													string[] array3 = array[i].Split(new string[1] { "|PRJID|" }, StringSplitOptions.None);
													if (array3 != null && Enumerable.Count<string>((IEnumerable<string>)array3) == 2)
													{
														string text4 = string.Format(Messages.MobMsgErrorrNotAccessToCompany, array3[1]);
														string newValue2 = "<PRJ><PRJID>" + array3[0] + "<\\PRJID><PRJCOMPANY>" + text4 + "<\\PRJCOMPANY><\\PRJ>";
														text = text.Replace("|Msg=CompanyAccess|" + array[i] + "|Msg=CompanyAccess|", newValue2);
													}
												}
											}
										}
									}
									if (text.IndexOf("|Msg=PrjAccess|", StringComparison.Ordinal) >= 0)
									{
										string[] array4 = text.Split(new string[1] { "|Msg=PrjAccess|" }, StringSplitOptions.None);
										if (array4 != null && Enumerable.Count<string>((IEnumerable<string>)array4) == 3)
										{
											if (!string.IsNullOrEmpty(array4[1]))
											{
												string[] array5 = array4[1].Split(new string[1] { "|PRJID|" }, StringSplitOptions.None);
												if (array5 != null && Enumerable.Count<string>((IEnumerable<string>)array5) == 2)
												{
													string text5 = string.Format(Messages.MobMsgErrorrNotAccessToProject, array5[1]);
													string newValue3 = "<PRJ><PRJID>" + array5[0] + "<\\PRJID><PRJTITLE>" + text5 + "<\\PRJTITLE><\\PRJ>";
													text = text.Replace("|Msg=PrjAccess|" + array4[1] + "|Msg=PrjAccess|", newValue3);
												}
											}
										}
										else if (array4 != null && Enumerable.Count<string>((IEnumerable<string>)array4) > 3)
										{
											for (int j = 1; j < Enumerable.Count<string>((IEnumerable<string>)array4); j++)
											{
												if (!string.IsNullOrEmpty(array4[j]))
												{
													string[] array6 = array4[j].Split(new string[1] { "|PRJID|" }, StringSplitOptions.None);
													if (array6 != null && Enumerable.Count<string>((IEnumerable<string>)array6) == 2)
													{
														string text6 = string.Format(Messages.MobMsgErrorrNotAccessToProject, array6[1]);
														string newValue4 = "<PRJ><PRJID>" + array6[0] + "<\\PRJID><PRJTITLE>" + text6 + "<\\PRJTITLE><\\PRJ>";
														text = text.Replace("|Msg=PrjAccess|" + array4[j] + "|Msg=PrjAccess|", newValue4);
													}
												}
											}
										}
									}
									insertQuickCmpPrsPrjCnvsResultViewModel2.ErrorMessage = text;
								}
								else
								{
									text = "";
								}
							}
							else
							{
								insertQuickCmpPrsPrjCnvsResultViewModel2.ErrorMessage = "";
							}
						}
						insertQuickCmpPrsPrjCnvsResultViewModel2.Company = "0";
						insertQuickCmpPrsPrjCnvsResultViewModel2.Persons = "0";
						if (objectParameter.Value != null)
						{
							insertQuickCmpPrsPrjCnvsResultViewModel2.Projects = objectParameter.Value.ToString() ?? "0";
						}
						else
						{
							insertQuickCmpPrsPrjCnvsResultViewModel2.Projects = "0";
						}
						insertQuickCmpPrsPrjCnvsResultViewModel2.Conversations = "0";
						insertQuickCmpPrsPrjCnvsResultViewModel2.Type = "";
						if (!num.HasValue || num >= 1)
						{
							if (insertQuickCmpPrsPrjCnvsResultViewModel2.ErrorMessage.IndexOf("Dup=1", StringComparison.Ordinal) >= 0)
							{
								insertQuickCmpPrsPrjCnvsResultViewModel2.Type = "Dup";
							}
							if (insertQuickCmpPrsPrjCnvsResultViewModel2.Type == "Dup")
							{
								ObjectParameter objectParameter3 = new ObjectParameter("errorMessage", "");
								CRMEntities cRMEntities2 = cRMEntities;
								string company = model.Company;
								string persons = model.Persons;
								string projects = model.Projects;
								string personLabel = mobPersonLabel;
								int? id = 0;
								int? userId = token2.userId;
								int? languageID = result;
								int? defaultLanguageID = result2;
								ObjectParameter errorMessage = objectParameter3;
								cRMEntities2.MobspCheckDuplicateCompanyWithReason(company, persons, projects, id, userId, languageID, defaultLanguageID, null, personLabel, 0, errorMessage, model.CenterId);
								if (objectParameter3.Value != null && objectParameter3.Value.ToString() != "")
								{
									string text7 = objectParameter3.Value.ToString();
									string text8 = "";
									if (text7 != "")
									{
										string[] array7 = text7.Split(new string[1] { "|^|" }, StringSplitOptions.None);
										foreach (string text9 in array7)
										{
											if (!string.IsNullOrEmpty(text9))
											{
												string[] array8 = text9.Split(new char[1] { ',' });
												string text10 = "";
												string text11 = "";
												if (array8[0] == "@prjPostFix=Dup")
												{
													text10 = array8[1].Replace("@DupCmpName=", "") ?? "";
													text11 = array8[2].Replace("@DupCmpNumber=", "") ?? "";
													text8 = text8 + "<PRJ>" + string.Format(Messages.MobCheckDuplicatePrjPostFix, text11, text10) + "<\\PRJ>";
												}
												else if (array8[0] == "@prjDesc=Dup")
												{
													text10 = array8[1].Replace("@DupCmpName=", "") ?? "";
													text11 = array8[2].Replace("@DupCmpNumber=", "") ?? "";
													text8 = text8 + "<PRJ>" + string.Format(Messages.MobCheckDuplicatePrjDesc, text11, text10) + "<\\PRJ>";
												}
												else if (array8[0] == "@prjNumRef=Dup")
												{
													text10 = array8[1].Replace("@DupCmpName=", "") ?? "";
													text11 = array8[2].Replace("@DupCmpNumber=", "") ?? "";
													text8 = text8 + "<PRJ>" + string.Format(Messages.MobCheckDuplicatePrjNumRef, text11, text10) + "<\\PRJ>";
												}
												else if (array8[0] == "@prjInquiryNum=Dup")
												{
													text10 = array8[1].Replace("@DupCmpName=", "") ?? "";
													text11 = array8[2].Replace("@DupCmpNumber=", "") ?? "";
													text8 = text8 + "<PRJ>" + string.Format(Messages.MobCheckDuplicatePrjInquiryNum, text11, text10) + "<\\PRJ>";
												}
												else if (array8[0] == "@prjNumR=Dup")
												{
													text10 = array8[1].Replace("@DupCmpName=", "") ?? "";
													text11 = array8[2].Replace("@DupCmpNumber=", "") ?? "";
													text8 = text8 + "<PRJ>" + string.Format(Messages.MobCheckDuplicatePrjNumR, text11, text10) + "<\\PRJ>";
												}
											}
										}
									}
									insertQuickCmpPrsPrjCnvsResultViewModel2.ErrorMessage = text + " " + text8;
								}
							}
							if (!string.IsNullOrEmpty(insertQuickCmpPrsPrjCnvsResultViewModel2.ErrorMessage))
							{
								insertQuickCmpPrsPrjCnvsResultViewModel = insertQuickCmpPrsPrjCnvsResultViewModel2;
								message = insertQuickCmpPrsPrjCnvsResultViewModel2.ErrorMessage;
								status = ServiceResultStatus.Fail;
							}
							else
							{
								insertQuickCmpPrsPrjCnvsResultViewModel = insertQuickCmpPrsPrjCnvsResultViewModel2;
								message = Messages.MobMsgSuccessAction;
								status = ServiceResultStatus.Success;
							}
						}
						else
						{
							insertQuickCmpPrsPrjCnvsResultViewModel = insertQuickCmpPrsPrjCnvsResultViewModel2;
							message = Messages.MobMsgErrorDoneOperation;
							status = ServiceResultStatus.Fail;
						}
					}
					else
					{
						insertQuickCmpPrsPrjCnvsResultViewModel.Projects = mobspSelectCrmProjectByProjectTitle_Result.ProjectID.ToString();
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					insertQuickCmpPrsPrjCnvsResultViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				insertQuickCmpPrsPrjCnvsResultViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			insertQuickCmpPrsPrjCnvsResultViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<InsertQuickCmpPrsPrjCnvsResultViewModel>
		{
			Message = message,
			Data = insertQuickCmpPrsPrjCnvsResultViewModel,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<InsertQuickCmpPrsPrjCnvsResultViewModel> InsertQuickConversation(InsertQuickCmpPrsPrjCnvsViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		InsertQuickCmpPrsPrjCnvsResultViewModel data = null;
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
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					int num = 0;
					List<MobspSelectLanguages_Result> list = Enumerable.ToList<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)cRMEntities.MobspSelectLanguages());
					DateTime now = DateTime.Now;
					_ = Labels.MobPersonLabel;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(Financial.Get().Id.ToString());
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string mobConversationErjaShow = Messages.MobConversationErjaShow;
					string conversationErjaShow = Messages.ConversationErjaShow;
					string eventErjaRefmsg = "";
					string appType = Mobile.Classes.Configuration.AppType;
					string text = "\r\n" + Messages.MobConversationErjaMultiUser + "{MultiUser}";
					string text2 = "\r\n" + Messages.MobConversationErjaReferDescription + ":\r\n{CNVSREFERDESC}";
					string mobCnvsReferUserCmpNotAccess = Messages.MobCnvsReferUserCmpNotAccess;
					int value4 = 7;
					string text3 = "";
					string text4 = "";
					string text5 = "";
					foreach (MobspSelectLanguages_Result item in list)
					{
						text = "";
						text = "\r\n" + MyResource.GetResourceString("MobConversationErjaMultiUser", item.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + " : {MultiUser}";
						text2 = "";
						text2 = "\r\n" + MyResource.GetResourceString("MobConversationErjaReferDescription", item.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":\r\n{CNVSREFERDESC}";
						mobCnvsReferUserCmpNotAccess = "";
						mobCnvsReferUserCmpNotAccess = MyResource.GetResourceString("MobCnvsReferUserCmpNotAccess", item.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						text3 = text3 + "MsgErjaMultiUser=" + text + "|@#@|LangId=" + item.LanguageID + "|@#@||^#^|";
						text4 = text4 + "MsgReferDesc=" + text2 + "|@#@|LangId=" + item.LanguageID + "|@#@||^#^|";
						text5 = text5 + "CmpNotAccess=" + mobCnvsReferUserCmpNotAccess + "|@#@|LangId=" + item.LanguageID + "|@#@||^#^|";
					}
					text = text3;
					text2 = text4;
					mobCnvsReferUserCmpNotAccess = text5;
					if (num == 0)
					{
						string text6 = "";
						string text7 = "";
						string text8 = "";
						text6 = "";
						foreach (MobspSelectLanguages_Result item2 in list)
						{
							text7 = "";
							text8 = "";
							text7 = MyResource.GetResourceString("MobConversationErjaFrom", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + " " + Common.GetUserName(UserLogin.CurrentUser.UserId, result2, item2.LanguageID, model.CenterId);
							text8 = MyResource.GetResourceString("MobConversationErjaInConnection", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {CMP}\r\n" + MyResource.GetResourceString("MobConversationErjaPerson", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {PRS}\r\n" + MyResource.GetResourceString("MobConversationErjaProject", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {PRJ}{MultiUser}";
							text8 = text8 + "\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaConversationDescription", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":\r\n{CNVSDESC}{CNVSREFERDESC}";
							text8 = text8 + "\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaDetails", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
							text6 = text6 + "MsgSubj=" + text7 + "|@#@|MsgBody=" + text8 + "|@#@|LangId=" + item2.LanguageID + "|@#@||^#^|";
						}
						text7 = "";
						text8 = text6;
						string text9 = "";
						string text10 = "";
						text6 = "";
						foreach (MobspSelectLanguages_Result item3 in list)
						{
							text9 = "";
							text10 = "";
							text9 = MyResource.GetResourceString("MobConversationErjaNotice", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + Common.GetUserName(UserLogin.CurrentUser.UserId, result2, item3.LanguageID, model.CenterId);
							text10 = "**" + MyResource.GetResourceString("MobConversationErjaAutomatically", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaAttention", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("MobConversationErjaInConnection", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {CMP}\r\n" + MyResource.GetResourceString("MobConversationErjaPerson", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {PRS}\r\n" + MyResource.GetResourceString("MobConversationErjaProject", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {PRJ}\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaLastNegotiator", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ", " + MyResource.GetResourceString("MobConversationErjaTransmitter", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("MobConversationErjaMultiUser", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "{MultiUser}\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaConversationDescription", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": \r\n{CNVSDESC}{CNVSREFERDESC}";
							text10 = text10 + "\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaDetails", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
							text6 = text6 + "MsgSubj=" + text9 + "|@#@|MsgBody=" + text10 + "|@#@|LangId=" + item3.LanguageID + "|@#@||^#^|";
						}
						text9 = "";
						text10 = text6;
						string text11 = "";
						string text12 = "";
						text6 = "";
						foreach (MobspSelectLanguages_Result item4 in list)
						{
							text11 = "";
							text12 = "";
							text11 = MyResource.GetResourceString("MobConversationErjaRonevesht", item4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + Common.GetUserName(UserLogin.CurrentUser.UserId, result2, item4.LanguageID, model.CenterId);
							text12 = MyResource.GetResourceString("MobConversationErjaInConnection", item4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {CMP} \r\n" + MyResource.GetResourceString("MobConversationErjaPerson", item4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {PRS} \r\n" + MyResource.GetResourceString("MobConversationErjaProject", item4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {PRJ}\r\n" + MyResource.GetResourceString("MobConversationErjaMultiUser", item4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + " : {MultiUser}\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaConversationDescription", item4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": \r\n{CNVSDESC}{CNVSREFERDESC}";
							text12 = text12 + "\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaDetails", item4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
							text6 = text6 + "MsgSubj=" + text11 + "|@#@|MsgBody=" + text12 + "|@#@|LangId=" + item4.LanguageID + "|@#@||^#^|";
						}
						text11 = "";
						text12 = text6;
						string text13 = "";
						string surveyMainExtrenalLinkLogin = "";
						string surveyMainExtrenalLink = "";
						string text14 = base.Request.RequestUri.GetLeftPart(UriPartial.Authority);
						string leftPart = base.Request.RequestUri.GetLeftPart(UriPartial.Scheme);
						if (text14.EndsWith("/"))
						{
							text14 = text14.TrimEnd(new char[1] { '/' });
						}
						text14 += "/Survey/Home/SurveyAnswerValues";
						text13 = text14;
						string text15 = "";
						MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result = SysSeting.Get();
						string text16 = "";
						string text17 = "";
						if (mobspSelectCrmsysSetting_Result != null)
						{
							text16 = mobspSelectCrmsysSetting_Result.FOUrl ?? "";
							text17 = mobspSelectCrmsysSetting_Result.CrmIPStatic ?? "";
						}
						if (!string.IsNullOrWhiteSpace(text16))
						{
							text15 = text16.Trim();
							if (!text15.Contains("http"))
							{
								text15 = leftPart + text15;
							}
							if (text15.EndsWith("/"))
							{
								text15 = text15.TrimEnd(new char[1] { '/' });
							}
							text15 += "/Survey/Home";
							surveyMainExtrenalLinkLogin = text15;
						}
						if (!string.IsNullOrWhiteSpace(text17))
						{
							text15 = text17.Trim();
							if (!text15.Contains("http"))
							{
								text15 = leftPart + text15;
							}
							if (text15.EndsWith("/"))
							{
								text15 = text15.TrimEnd(new char[1] { '/' });
							}
							text15 += "/Survey/Register/Index";
						}
						int maxFOCount = Mobile.Classes.Configuration.MaxFOCount;
						ObjectParameter objectParameter = new ObjectParameter("insertedConversationIds", "");
						ObjectParameter objectParameter2 = new ObjectParameter("errorMessage", "");
						ObjectParameter objectParameter3 = new ObjectParameter("result", 0);
						CRMEntities cRMEntities2 = cRMEntities;
						string conversations = model.Conversations;
						int? userId = token2.userId;
						short? year = value2;
						short? month = value3;
						DateTime? registerDate = value;
						int? languageID = result;
						int? defaultLanguageID = result2;
						string needErjaRefmsgSubj = text7;
						string needErjaRefmsgBody = text8;
						string needErjaMultiIntmsgSubject = text11;
						string needErjaMultiIntmsgBody = text12;
						string needSendErjaAllarmRefmsgSubj = text9;
						string needSendErjaAllarmRefmsgBody = text10;
						string msgConversationErjaMultiUser = text;
						string msgConversationErjaReferDescription = text2;
						ObjectParameter insertedConversationIds = objectParameter;
						ObjectParameter errorMessage = objectParameter2;
						string type = model.Type;
						string cmpNotAccess = mobCnvsReferUserCmpNotAccess;
						Enumerable.FirstOrDefault<MobspInsertQuickConversation_Result>((IEnumerable<MobspInsertQuickConversation_Result>)cRMEntities2.MobspInsertQuickConversation(conversations, userId, year, month, registerDate, registerDatePersian, appType, languageID, defaultLanguageID, needErjaRefmsgSubj, needErjaRefmsgBody, needErjaMultiIntmsgSubject, needErjaMultiIntmsgBody, needSendErjaAllarmRefmsgSubj, needSendErjaAllarmRefmsgBody, mobConversationErjaShow, msgConversationErjaMultiUser, msgConversationErjaReferDescription, type, insertedConversationIds, errorMessage, objectParameter3, value4, cmpNotAccess, text13, surveyMainExtrenalLink, surveyMainExtrenalLinkLogin, conversationErjaShow, eventErjaRefmsg, model.CenterId, maxFOCount));
						InsertQuickCmpPrsPrjCnvsResultViewModel insertQuickCmpPrsPrjCnvsResultViewModel = new InsertQuickCmpPrsPrjCnvsResultViewModel();
						string text18 = "";
						if (objectParameter2.Value != null)
						{
							if (objectParameter2.Value.ToString() != "")
							{
								string text19 = objectParameter2.Value.ToString();
								text19 = text19.Replace("|Msg=0", "<CMP>" + Messages.MobMsgErrorInsertCompany + "<\\CMP>");
								text19 = text19.Replace("Msg=1", "<CMP>" + Messages.MobMsgErrorInconsistencyInCompanySelection + "<\\CMP>");
								text19 = text19.Replace("Msg=2", "<PRS>" + Messages.MobMsgErrorInsertPersons + "<\\PRS>");
								text19 = text19.Replace("Msg=3", "<PRS>" + Messages.MobMsgErrorInsertPerson + "<\\PRS>");
								text19 = text19.Replace("Msg=4", "<PRJ>" + Messages.MobMsgErrorInsertProjects + "<\\PRJ>");
								text19 = text19.Replace("Msg=5", "<PRJ>" + Messages.MobMsgErrorInsertProject + "<\\PRJ>");
								text19 = text19.Replace("Msg=6", "<CNVS>" + Messages.MobMsgErrorInsertSms + "<\\CNVS>");
								text19 = text19.Replace("Msg=7", "<CNVS>" + Messages.MobMsgErrorInsertConversation + "<\\CNVS>");
								text19 = text19.Replace("Dup=1Msg=0", "<CMP>" + Messages.MobMsgErrorNotInsertDuplicateCompany + "<\\CMP>");
								insertQuickCmpPrsPrjCnvsResultViewModel.ErrorMessage = text19;
								text18 = objectParameter2.Value.ToString();
								if (text18.IndexOf("|Msg=CompanyAccess|", StringComparison.Ordinal) >= 0 || text18.IndexOf("|Msg=PrjAccess|", StringComparison.Ordinal) >= 0)
								{
									text18 = text18.Replace("|Msg=0", "").Replace("Msg=1", "").Replace("Msg=2", "")
										.Replace("Msg=3", "")
										.Replace("Msg=4", "")
										.Replace("Msg=5", "")
										.Replace("Msg=6", "")
										.Replace("Msg=7", "")
										.Replace("Dup=1Msg=0", "");
									if (text18.IndexOf("|Msg=CompanyAccess|", StringComparison.Ordinal) >= 0)
									{
										string[] array = text18.Split(new string[1] { "|Msg=CompanyAccess|" }, StringSplitOptions.None);
										if (array != null && Enumerable.Count<string>((IEnumerable<string>)array) == 3)
										{
											if (!string.IsNullOrEmpty(array[1]))
											{
												string[] array2 = array[1].Split(new string[1] { "|CNVSID|" }, StringSplitOptions.None);
												if (array2 != null && Enumerable.Count<string>((IEnumerable<string>)array2) == 2)
												{
													string text20 = string.Format(Messages.MobMsgErrorrNotAccessToCompany, array2[1]);
													string newValue = "<CNVS><CNVSID>" + array2[0] + "<\\CNVSID><CNVSCOMPANY>" + text20 + "<\\CNVSCOMPANY><\\CNVS>";
													text18 = text18.Replace("|Msg=CompanyAccess|" + array[1] + "|Msg=CompanyAccess|", newValue);
												}
											}
										}
										else if (array != null && Enumerable.Count<string>((IEnumerable<string>)array) > 3)
										{
											for (int i = 1; i < Enumerable.Count<string>((IEnumerable<string>)array); i++)
											{
												if (!string.IsNullOrEmpty(array[i]))
												{
													string[] array3 = array[i].Split(new string[1] { "|CNVSID|" }, StringSplitOptions.None);
													if (array3 != null && Enumerable.Count<string>((IEnumerable<string>)array3) == 2)
													{
														string text21 = string.Format(Messages.MobMsgErrorrNotAccessToCompany, array3[1]);
														string newValue2 = "<CNVS><CNVSID>" + array3[0] + "<\\CNVSID><CNVSCOMPANY>" + text21 + "<\\CNVSCOMPANY><\\CNVS>";
														text18 = text18.Replace("|Msg=CompanyAccess|" + array[i] + "|Msg=CompanyAccess|", newValue2);
													}
												}
											}
										}
									}
									if (text18.IndexOf("|Msg=PrjAccess|", StringComparison.Ordinal) >= 0)
									{
										string[] array4 = text18.Split(new string[1] { "|Msg=PrjAccess|" }, StringSplitOptions.None);
										if (array4 != null && Enumerable.Count<string>((IEnumerable<string>)array4) == 3)
										{
											if (!string.IsNullOrEmpty(array4[1]))
											{
												string[] array5 = array4[1].Split(new string[1] { "|CNVSID|" }, StringSplitOptions.None);
												if (array5 != null && Enumerable.Count<string>((IEnumerable<string>)array5) == 2)
												{
													string text22 = string.Format(Messages.MobMsgErrorrNotAccessToProject, array5[1]);
													string newValue3 = "<CNVS><CNVSID>" + array5[0] + "<\\CNVSID><CNVSPROJECT>" + text22 + "<\\CNVSPROJECT><\\CNVS>";
													text18 = text18.Replace("|Msg=PrjAccess|" + array4[1] + "|Msg=PrjAccess|", newValue3);
												}
											}
										}
										else if (array4 != null && Enumerable.Count<string>((IEnumerable<string>)array4) > 3)
										{
											for (int j = 1; j < Enumerable.Count<string>((IEnumerable<string>)array4); j++)
											{
												if (!string.IsNullOrEmpty(array4[j]))
												{
													string[] array6 = array4[j].Split(new string[1] { "|CNVSID|" }, StringSplitOptions.None);
													if (array6 != null && Enumerable.Count<string>((IEnumerable<string>)array6) == 2)
													{
														string text23 = string.Format(Messages.MobMsgErrorrNotAccessToProject, array6[1]);
														string newValue4 = "<CNVS><CNVSID>" + array6[0] + "<\\CNVSID><CNVSPROJECT>" + text23 + "<\\CNVSPROJECT><\\CNVS>";
														text18 = text18.Replace("|Msg=PrjAccess|" + array4[j] + "|Msg=PrjAccess|", newValue4);
													}
												}
											}
										}
									}
									insertQuickCmpPrsPrjCnvsResultViewModel.ErrorMessage = text18;
								}
								else if (text18.IndexOf("PreChckErrs", StringComparison.Ordinal) >= 0)
								{
									string text24 = "";
									string[] array7 = text18.Split(new string[1] { "|^|" }, StringSplitOptions.None);
									foreach (string text25 in array7)
									{
										if (!string.IsNullOrEmpty(text25))
										{
											string[] array8 = text25.Split(new char[1] { ',' });
											if (array8[0] == "@StatusResCheckNeedDyFormChecked=PreChckErrs")
											{
												string arg = array8[1].Replace("@FormName=", "") ?? "";
												string arg2 = array8[2].Replace("@DyFormNumber=", "") ?? "";
												text24 = text24 + "<CNVS>" + string.Format(Messages.MobMsgErrorNotSaveCnvsBeforeDyFormChecked, arg, arg2) + "<\\CNVS>";
											}
											else if (array8[0] == "@StatusResCheckNoCnvsDup=PreChckErrs")
											{
												string arg3 = array8[1].Replace("@cnvsDate=", "") ?? "";
												string arg4 = array8[2].Replace("@cnvsStatus=", "") ?? "";
												string arg5 = array8[3].Replace("@cnvsStatusResult=", "") ?? "";
												text24 = text24 + "<CNVS>" + string.Format(Messages.MobMsgErrorNoDupCnvsInStatusResult, arg3, arg4, arg5) + "<\\CNVS>";
											}
											else if (array8[0] == "@StatusResCheckCnvsCountLimit=PreChckErrs")
											{
												string arg6 = array8[1].Replace("@ResultTitle=", "") ?? "";
												string arg7 = array8[2].Replace("@cnvsCountLimit=", "") ?? "";
												text24 = text24 + "<CNVS>" + string.Format(Messages.MobMsgErrorCnvsCountLimitInStatusResult, arg6, arg7) + "<\\CNVS>";
											}
											else if (array8[0] == "@StatusResCheckCnvsDoingTimeLimit=PreChckErrs")
											{
												string arg8 = array8[1].Replace("@ResultTitle=", "") ?? "";
												string arg9 = array8[2].Replace("@cnvsDoingTimeLimit=", "") ?? "";
												text24 = text24 + "<CNVS>" + string.Format(Messages.MobMsgErrorCnvsDoingTimeLimitInStatusResult, arg8, arg9) + "<\\CNVS>";
											}
											else if (array8[0] == "@StatusCheckNoOrderStatus=PreChckErrs")
											{
												string arg10 = array8[1].Replace("@Status=", "") ?? "";
												text24 = text24 + "<CNVS>" + string.Format(Messages.MobMsgErrorNoRegCnvsOlderStatus, arg10) + "<\\CNVS>";
											}
											else if (array8[0] == "@StatusCheckCnvsCountLimit=PreChckErrs")
											{
												string arg11 = array8[1].Replace("@Status=", "") ?? "";
												string arg12 = array8[2].Replace("@cnvsCountLimit=", "") ?? "";
												text24 = text24 + "<CNVS>" + string.Format(Messages.MobMsgErrorCnvsCountLimitInStatus, arg11, arg12) + "<\\CNVS>";
											}
											else if (array8[0] == "@StatusCheckCnvsDoingTimeLimit=PreChckErrs")
											{
												string arg13 = array8[1].Replace("@Status=", "") ?? "";
												string arg14 = array8[2].Replace("@cnvsDoingTimeLimit=", "") ?? "";
												text24 = text24 + "<CNVS>" + string.Format(Messages.MobMsgErrorCnvsDoingTimeLimitInStatus, arg13, arg14) + "<\\CNVS>";
											}
											else if (array8[0] == "@StatusResCheckUsedUserIds=PreChckErrs")
											{
												text24 = text24 + "<CNVS>" + string.Format(Messages.MobMsgErrorCanNotSaveCnvsInResult) + "<\\CNVS>";
											}
											else if (array8[0] == "@StatusCheckUsedUserIds=PreChckErrs")
											{
												text24 = text24 + "<CNVS>" + string.Format(Messages.MobMsgErrorCanNotSaveCnvsInStatus) + "<\\CNVS>";
											}
											else if (array8[0] == "@StatusResCheckNeedDyFormCheckedNotExist=PreChckErrs")
											{
												string text26 = array8[1].Replace("@NeedDyFormCheckedForm=", "") ?? "";
												text24 = text24 + "<CNVS>" + string.Format(Messages.MobMsgErrorNotSaveCnvsBeforeInsertDyFormFromCmp, text26 ?? "") + "<\\CNVS>";
											}
										}
									}
									insertQuickCmpPrsPrjCnvsResultViewModel.ErrorMessage = text24;
								}
								else
								{
									text18 = "";
								}
							}
							else
							{
								insertQuickCmpPrsPrjCnvsResultViewModel.ErrorMessage = "";
							}
						}
						insertQuickCmpPrsPrjCnvsResultViewModel.Company = "0";
						insertQuickCmpPrsPrjCnvsResultViewModel.Persons = "0";
						insertQuickCmpPrsPrjCnvsResultViewModel.Projects = "0";
						if (objectParameter.Value != null)
						{
							insertQuickCmpPrsPrjCnvsResultViewModel.Conversations = objectParameter.Value.ToString() ?? "0";
						}
						else
						{
							insertQuickCmpPrsPrjCnvsResultViewModel.Conversations = "0";
						}
						insertQuickCmpPrsPrjCnvsResultViewModel.Type = "";
						if (objectParameter3.Value != null)
						{
							if (objectParameter3.Value.ToString() == "1")
							{
								if (!string.IsNullOrEmpty(insertQuickCmpPrsPrjCnvsResultViewModel.ErrorMessage))
								{
									data = insertQuickCmpPrsPrjCnvsResultViewModel;
									message = insertQuickCmpPrsPrjCnvsResultViewModel.ErrorMessage;
									status = ServiceResultStatus.Fail;
								}
								else
								{
									AfterInsertCnvsOperation(insertQuickCmpPrsPrjCnvsResultViewModel, model, token2.userId, result, result2);
									PushNotif.NewIntMsgNotify(withthread: true, model.CenterId);
									data = insertQuickCmpPrsPrjCnvsResultViewModel;
									message = Messages.MobMsgSuccessAction;
									status = ServiceResultStatus.Success;
								}
							}
							else
							{
								data = insertQuickCmpPrsPrjCnvsResultViewModel;
								message = Messages.MobMsgErrorDoneOperation;
								status = ServiceResultStatus.Fail;
							}
						}
						else
						{
							data = insertQuickCmpPrsPrjCnvsResultViewModel;
							message = Messages.MobMsgErrorDoneOperation;
							status = ServiceResultStatus.Fail;
						}
					}
					else
					{
						data = null;
						message = Messages.MobMsgErrorDoneOperation;
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
		return new ServiceResult<InsertQuickCmpPrsPrjCnvsResultViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	public bool AfterInsertCnvsOperation(InsertQuickCmpPrsPrjCnvsResultViewModel result, InsertQuickCmpPrsPrjCnvsViewModel model, int userId, int langId, int defLangId)
	{
		bool result2 = true;
		CRMEntities cRMEntities = null;
		try
		{
			cRMEntities = new CRMEntities();
			string[] array = result.Conversations.Split(new char[1] { '|' });
			foreach (string text in array)
			{
				int num = int.Parse(text.Substring(text.IndexOf(",") + 1, text.Length - (text.IndexOf(",") + 1)));
				string text2 = text.Substring(0, text.IndexOf(","));
				if (num <= 0)
				{
					continue;
				}
				string[] array2 = model.Conversations.Split(new string[1] { "|^#^|" }, StringSplitOptions.None);
				foreach (string text3 in array2)
				{
					string text4 = text3.Substring(text3.IndexOf("ConversationID=") + 15, text3.Length - (text3.IndexOf("ConversationID") + 15));
					if (!(text4.Substring(0, text4.IndexOf("|#|")) == text2))
					{
						continue;
					}
					string text5 = text3.Substring(text3.IndexOf("cnvsIsTicket=") + 13, text3.Length - (text3.IndexOf("cnvsIsTicket") + 13));
					string value = text5.Substring(0, text5.IndexOf("|#|"));
					bool result3 = false;
					bool.TryParse(value, out result3);
					string text6 = text3.Substring(text3.IndexOf("cnvsFOCmpCanSee=") + 16, text3.Length - (text3.IndexOf("cnvsFOCmpCanSee") + 16));
					string value2 = text6.Substring(0, text6.IndexOf("|#|"));
					bool result4 = false;
					bool.TryParse(value2, out result4);
					if (!(result3 && result4))
					{
						continue;
					}
					string text7 = text3.Substring(text3.IndexOf("cnvsProjectId=") + 14, text3.Length - (text3.IndexOf("cnvsProjectId") + 14));
					string s = text7.Substring(0, text7.IndexOf("|#|"));
					int result5 = 0;
					int.TryParse(s, out result5);
					MobspSelectProjectWithID_Result mobspSelectProjectWithID_Result = Enumerable.FirstOrDefault<MobspSelectProjectWithID_Result>((IEnumerable<MobspSelectProjectWithID_Result>)cRMEntities.MobspSelectProjectWithID(result5, langId, defLangId));
					if (mobspSelectProjectWithID_Result != null)
					{
						string text8 = text3.Substring(text3.IndexOf("cnvsCompanyId=") + 14, text3.Length - (text3.IndexOf("cnvsCompanyId") + 14));
						string s2 = text8.Substring(0, text8.IndexOf("|#|"));
						int result6 = 0;
						int.TryParse(s2, out result6);
						int result7 = 0;
						int? num2 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspGetUnReadTicket(result6, model.CenterId));
						if (num2.HasValue)
						{
							int.TryParse(num2.ToString(), out result7);
						}
						string body = mobspSelectProjectWithID_Result.ProjectTitle ?? "";
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary.Add("UnReadTicketCnt", result7.ToString());
						dictionary.Add("cnvsId", num.ToString());
						dictionary.Add("prjId", result5.ToString());
						PushNotif.NewTicketNotify(result6, Labels.CnvsSendNotifNewTicket, body, dictionary);
					}
				}
			}
		}
		catch
		{
			result2 = false;
		}
		return result2;
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<InsertPreOrderFullViewModel> InsertQuickPreOrderItem(InsertPreOrderFullViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		InsertPreOrderFullViewModel data = null;
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
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					DateTime now = DateTime.Now;
					_ = Labels.MobPersonLabel;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(Financial.Get().Id.ToString());
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					_ = Messages.MobConversationErjaShow;
					string appType = Mobile.Classes.Configuration.AppType;
					bool value4 = UserLogin.IsUserAccess("frmPreOrderItemDataEntry", "actCanNotSelectWithNoStockInPord", UserLogin.CurrentUser, model.CenterId);
					bool value5 = UserLogin.IsUserAccess("frmPreOrderItemDataEntry", "actCanNotSelectWithNoReserveStockInPord", UserLogin.CurrentUser, model.CenterId);
					bool value6 = UserLogin.IsUserAccess("frmPreOrderItemDataEntry", "actCanNotSelectWithNoSoldStockInPord", UserLogin.CurrentUser, model.CenterId);
					if (0 == 0)
					{
						ObjectParameter objectParameter = new ObjectParameter("InsertedPordItemId", "");
						ObjectParameter objectParameter2 = new ObjectParameter("ErrorMessage", "");
						int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspInsertQuickPreOrderItem(model.PordItemList, value, registerDatePersian, token2.userId, value3, value2, appType, result, result2, value4, model.AddLinkedProducts, objectParameter, objectParameter2, model.CenterId, model.haveLinkAccQtyCheck, value5, value6));
						InsertPreOrderFullViewModel insertPreOrderFullViewModel = new InsertPreOrderFullViewModel();
						if (objectParameter2.Value != null)
						{
							if (objectParameter2.Value.ToString() != "")
							{
								string text = objectParameter2.Value.ToString();
								text = text.Replace("|Msg=0", Messages.MobMsgErrorInsertPreOrder);
								text = text.Replace("|pordNumberIsDup", Messages.MobMsgPreOrderNumberIsRepeated);
								text = text.Replace("Msg=1", Messages.MobMsgErrorInconsistencyInPordSelection);
								text = text.Replace("Msg=5", Messages.MobMsgProductLackOfStock);
								text = text.Replace("Msg=6", Messages.MobMsgProductLackOfReserveStock);
								text = text.Replace("Msg=7", Messages.MobMsgProductLackOfSoldStock);
								text = text.Replace("Msg=2", Messages.MobMsgErrorInsertProduct);
								text = text.Replace("Msg=3", Messages.MobMsgErrorInsertProductSpcf);
								insertPreOrderFullViewModel.ErrorMessage = text;
							}
							else
							{
								insertPreOrderFullViewModel.ErrorMessage = "";
							}
						}
						insertPreOrderFullViewModel.PordItemSpecificationList = "0";
						insertPreOrderFullViewModel.PordPaymentList = "0";
						insertPreOrderFullViewModel.PreOrder = "0";
						if (objectParameter.Value != null)
						{
							insertPreOrderFullViewModel.PordItemList = objectParameter.Value.ToString() ?? "0";
						}
						else
						{
							insertPreOrderFullViewModel.PordItemList = "0";
						}
						if (!num.HasValue || num >= 1)
						{
							if (!string.IsNullOrEmpty(insertPreOrderFullViewModel.ErrorMessage))
							{
								data = insertPreOrderFullViewModel;
								message = insertPreOrderFullViewModel.ErrorMessage;
								status = ServiceResultStatus.Fail;
							}
							else
							{
								data = insertPreOrderFullViewModel;
								message = Messages.MobMsgSuccessAction;
								status = ServiceResultStatus.Success;
							}
						}
						else
						{
							data = insertPreOrderFullViewModel;
							message = Messages.MobMsgErrorDoneOperation;
							status = ServiceResultStatus.Fail;
						}
					}
					else
					{
						data = null;
						message = Messages.MobMsgErrorDoneOperation;
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
		return new ServiceResult<InsertPreOrderFullViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<InsertPreOrderFullViewModel> InsertQuickPreOrderPayment(InsertPreOrderFullViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		InsertPreOrderFullViewModel data = null;
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
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					DateTime now = DateTime.Now;
					_ = Labels.MobPersonLabel;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(Financial.Get().Id.ToString());
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					_ = Messages.MobConversationErjaShow;
					string appType = Mobile.Classes.Configuration.AppType;
					if (0 == 0)
					{
						ObjectParameter objectParameter = new ObjectParameter("InsertedPordPaymentId", "");
						ObjectParameter objectParameter2 = new ObjectParameter("ErrorMessage", "");
						int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspInsertQuickPreOrderPayment(model.PordPaymentList, value, registerDatePersian, token2.userId, value3, value2, appType, result, result2, objectParameter, objectParameter2, model.CenterId));
						InsertPreOrderFullViewModel insertPreOrderFullViewModel = new InsertPreOrderFullViewModel();
						if (objectParameter2.Value != null)
						{
							if (objectParameter2.Value.ToString() != "")
							{
								string text = objectParameter2.Value.ToString();
								text = text.Replace("|Msg=0", Messages.MobMsgErrorInsertPreOrder);
								text = text.Replace("|pordNumberIsDup", Messages.MobMsgPreOrderNumberIsRepeated);
								text = text.Replace("Msg=1", Messages.MobMsgErrorInconsistencyInPordSelection);
								text = text.Replace("Msg=5", Messages.MobMsgProductLackOfStock);
								text = text.Replace("Msg=2", Messages.MobMsgErrorInsertProduct);
								text = text.Replace("Msg=3", Messages.MobMsgErrorInsertProductSpcf);
								insertPreOrderFullViewModel.ErrorMessage = text;
							}
							else
							{
								insertPreOrderFullViewModel.ErrorMessage = "";
							}
						}
						insertPreOrderFullViewModel.PordItemSpecificationList = "0";
						insertPreOrderFullViewModel.PordItemList = "0";
						insertPreOrderFullViewModel.PreOrder = "0";
						if (objectParameter.Value != null)
						{
							insertPreOrderFullViewModel.PordPaymentList = objectParameter.Value.ToString() ?? "0";
						}
						else
						{
							insertPreOrderFullViewModel.PordPaymentList = "0";
						}
						if (!num.HasValue || num >= 1)
						{
							if (!string.IsNullOrEmpty(insertPreOrderFullViewModel.ErrorMessage))
							{
								data = insertPreOrderFullViewModel;
								message = insertPreOrderFullViewModel.ErrorMessage;
								status = ServiceResultStatus.Fail;
							}
							else
							{
								string[] array = insertPreOrderFullViewModel.PordPaymentList.Split(new char[1] { '|' });
								foreach (string text2 in array)
								{
									if (string.IsNullOrEmpty(text2))
									{
										continue;
									}
									string[] array2 = text2.Split(new char[1] { ',' });
									if (array2.Length > 1)
									{
										int result3 = 0;
										int.TryParse(array2[1], out result3);
										if (result3 > 0)
										{
											PreOrder.PaymentMoneyBag(result3, 0, result, model.CenterId);
										}
									}
								}
								data = insertPreOrderFullViewModel;
								message = Messages.MobMsgSuccessAction;
								status = ServiceResultStatus.Success;
							}
						}
						else
						{
							data = insertPreOrderFullViewModel;
							message = Messages.MobMsgErrorDoneOperation;
							status = ServiceResultStatus.Fail;
						}
					}
					else
					{
						data = null;
						message = Messages.MobMsgErrorDoneOperation;
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
		return new ServiceResult<InsertPreOrderFullViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<InsertQuickCmpPrsPrjCnvsResultViewModel> InsertQuickCmpPrjCnv(InsertQuickCmpPrjCnvsViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		InsertQuickCmpPrsPrjCnvsResultViewModel insertQuickCmpPrsPrjCnvsResultViewModel = new InsertQuickCmpPrsPrjCnvsResultViewModel();
		string text = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		int num = -10;
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				cRMEntities = new CRMEntities();
				string text2 = "";
				DateTime now = DateTime.Now;
				string mobPersonLabel = Labels.MobPersonLabel;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(Financial.Get().Id.ToString());
				short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
				string mobConversationErjaShow = Messages.MobConversationErjaShow;
				string appType = Mobile.Classes.Configuration.AppType;
				string text3 = "\r\n" + Messages.MobConversationErjaMultiUser + "{MultiUser}";
				string text4 = "\r\n" + Messages.MobConversationErjaReferDescription + ":\r\n{CNVSREFERDESC}";
				string conversationErjaShow = Messages.ConversationErjaShow;
				string eventErjaRefmsg = "";
				string mobLackOfShowText = Labels.MobLackOfShowText;
				ObjectParameter updatedCompanyId;
				ObjectParameter errorMessage;
				string text5;
				if (!string.IsNullOrEmpty(model.Company))
				{
					int num2 = 0;
					ObjectParameter objectParameter = new ObjectParameter("updatedCompanyId", 0);
					ObjectParameter objectParameter2 = new ObjectParameter("errorMessage", "");
					CRMEntities cRMEntities2 = cRMEntities;
					int? companyId = model.CompanyId;
					string company = model.Company;
					text5 = mobPersonLabel;
					int? userId = num;
					short? year = value2;
					int? languageID = result;
					int? defaultLanguageID = result2;
					string personLabel = text5;
					updatedCompanyId = objectParameter;
					errorMessage = objectParameter2;
					int? num3 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities2.MobspUpdateCompanyForPs(companyId, company, userId, year, appType, languageID, defaultLanguageID, personLabel, mobLackOfShowText, updatedCompanyId, errorMessage, model.CenterId));
					if (objectParameter2.Value != null)
					{
						if (objectParameter2.Value.ToString() != "")
						{
							string text6 = objectParameter2.Value.ToString();
							text2 = objectParameter2.Value.ToString();
							if (text2.IndexOf("|Msg=0", StringComparison.Ordinal) >= 0)
							{
								text2 = "<CMP>" + Messages.MobMsgErrorIsNotCompany + "<\\CMP>";
								num2++;
							}
							else
							{
								text6 = text6.Replace("|Msg=0", "");
								if (text6.IndexOf("@cmpName=IsNull", StringComparison.Ordinal) >= 0)
								{
									text2 = "<CMP>" + Messages.MobMsgErrorCmpNameNotEntered + "<\\CMP>";
									num2++;
								}
								if (text6.IndexOf("@cmpName=Dup", StringComparison.Ordinal) >= 0)
								{
									string text7 = "";
									string text8 = text6.Substring(text6.IndexOf("@cmpName=Dup", StringComparison.Ordinal));
									if (text8 != null && text8 != "")
									{
										string[] array = text8.Split(new string[1] { "|^|" }, StringSplitOptions.None);
										foreach (string text9 in array)
										{
											if (!string.IsNullOrEmpty(text9))
											{
												string[] array2 = text9.Split(new char[1] { ',' });
												if (array2[0] == "@cmpName=Dup")
												{
													string text10 = array2[3].Replace("@DupCmpName=", "") ?? "";
													string text11 = array2[2].Replace("@DupCmpTitle=", "") ?? "";
													string text12 = array2[4].Replace("@DupCmpCity=", "") ?? "";
													string text13 = array2[5].Replace("@DupCmpNumber=", "") ?? "";
													text7 = text7 + "<CMP>" + string.Format(Messages.MobMsgErrorCheckCmpNameDuplicate, text10, text11, text12, text13) + "<\\CMP>";
												}
											}
										}
									}
									text2 = text7;
									num2++;
								}
								string text14 = text6;
								if (text14.IndexOf("|Msg=CmpGroupIdAccess|", StringComparison.Ordinal) >= 0 || text14.IndexOf("|Msg=CmpSubGroupIdAccess|", StringComparison.Ordinal) >= 0 || text14.IndexOf("|Msg=CmpGroupIdIVAccess|", StringComparison.Ordinal) >= 0 || text14.IndexOf("|Msg=CmpProvinceIdAccess|", StringComparison.Ordinal) >= 0 || text14.IndexOf("|Msg=CmpCityIdAccess|", StringComparison.Ordinal) >= 0 || text14.IndexOf("|Msg=CompanyAccess|", StringComparison.Ordinal) >= 0)
								{
									if (text14.IndexOf("|Msg=CompanyAccess|", StringComparison.Ordinal) >= 0)
									{
										string[] array3 = text14.Split(new string[1] { "|Msg=CompanyAccess|" }, StringSplitOptions.None);
										if (array3 != null && Enumerable.Count<string>((IEnumerable<string>)array3) == 3 && !string.IsNullOrEmpty(array3[1]))
										{
											string newValue = "<CMP>" + string.Format(Messages.MobMsgErrorrNotAccessToCompany, array3[1]) + "<\\CMP>";
											text14 = text14.Replace("|Msg=CompanyAccess|" + array3[1] + "|Msg=CompanyAccess|", newValue);
										}
									}
									if (text14.IndexOf("|Msg=CmpGroupIdAccess|", StringComparison.Ordinal) >= 0)
									{
										string[] array4 = text14.Split(new string[1] { "|Msg=CmpGroupIdAccess|" }, StringSplitOptions.None);
										if (array4 != null && Enumerable.Count<string>((IEnumerable<string>)array4) == 3 && !string.IsNullOrEmpty(array4[1]))
										{
											string newValue2 = "<CMP>" + string.Format(Messages.MobMsgErrorrNotAccessToCmpGroup, array4[1]) + "<\\CMP>";
											text14 = text14.Replace("|Msg=CmpGroupIdAccess|" + array4[1] + "|Msg=CmpGroupIdAccess|", newValue2);
										}
									}
									if (text14.IndexOf("|Msg=CmpSubGroupIdAccess|", StringComparison.Ordinal) >= 0)
									{
										string[] array5 = text14.Split(new string[1] { "|Msg=CmpSubGroupIdAccess|" }, StringSplitOptions.None);
										if (array5 != null && Enumerable.Count<string>((IEnumerable<string>)array5) == 3 && !string.IsNullOrEmpty(array5[1]))
										{
											string newValue3 = "<CMP>" + string.Format(Messages.MobMsgErrorrNotAccessToCmpSubGroup, array5[1]) + "<\\CMP>";
											text14 = text14.Replace("|Msg=CmpSubGroupIdAccess|" + array5[1] + "|Msg=CmpSubGroupIdAccess|", newValue3);
										}
									}
									if (text14.IndexOf("|Msg=CmpGroupIdIVAccess|", StringComparison.Ordinal) >= 0)
									{
										string[] array6 = text14.Split(new string[1] { "|Msg=CmpGroupIdIVAccess|" }, StringSplitOptions.None);
										if (array6 != null && Enumerable.Count<string>((IEnumerable<string>)array6) == 3 && !string.IsNullOrEmpty(array6[1]))
										{
											string newValue4 = "<CMP>" + string.Format(Messages.MobMsgErrorrNotAccessToCmpGroupIV, array6[1]) + "<\\CMP>";
											text14 = text14.Replace("|Msg=CmpGroupIdIVAccess|" + array6[1] + "|Msg=CmpGroupIdIVAccess|", newValue4);
										}
									}
									if (text14.IndexOf("|Msg=CmpProvinceIdAccess|", StringComparison.Ordinal) >= 0)
									{
										string[] array7 = text14.Split(new string[1] { "|Msg=CmpProvinceIdAccess|" }, StringSplitOptions.None);
										if (array7 != null && Enumerable.Count<string>((IEnumerable<string>)array7) == 3 && !string.IsNullOrEmpty(array7[1]))
										{
											string newValue5 = "<CMP>" + string.Format(Messages.MobMsgErrorrNotAccessToProvince, array7[1]) + "<\\CMP>";
											text14 = text14.Replace("|Msg=CmpProvinceIdAccess|" + array7[1] + "|Msg=CmpProvinceIdAccess|", newValue5);
										}
									}
									if (text14.IndexOf("|Msg=CmpCityIdAccess|", StringComparison.Ordinal) >= 0)
									{
										string[] array8 = text14.Split(new string[1] { "|Msg=CmpCityIdAccess|" }, StringSplitOptions.None);
										if (array8 != null && Enumerable.Count<string>((IEnumerable<string>)array8) == 3 && !string.IsNullOrEmpty(array8[1]))
										{
											string newValue6 = "<CMP>" + string.Format(Messages.MobMsgErrorrNotAccessToCity, array8[1]) + "<\\CMP>";
											text14 = text14.Replace("|Msg=CmpCityIdAccess|" + array8[1] + "|Msg=CmpCityIdAccess|", newValue6);
										}
									}
									text2 = text14;
									num2++;
								}
							}
						}
						else
						{
							text2 = "";
						}
					}
					if (num3.HasValue && !(num3 >= 1))
					{
						text = Messages.MobMsgErrorDoneOperation;
						status = ServiceResultStatus.Fail;
						return new ServiceResult<InsertQuickCmpPrsPrjCnvsResultViewModel>
						{
							Message = text,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					if (num2 > 0)
					{
						text = text2;
						status = ServiceResultStatus.Fail;
						return new ServiceResult<InsertQuickCmpPrsPrjCnvsResultViewModel>
						{
							Message = text,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					insertQuickCmpPrsPrjCnvsResultViewModel.Company = objectParameter.ToString() ?? "0";
					text = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
					ObjectParameter objectParameter3 = new ObjectParameter("updatedPersonId", 0);
					CRMEntities cRMEntities3 = cRMEntities;
					int? num4 = model.CompanyId;
					int? personId = model.PersonId;
					string persons = model.Persons;
					int? companyId2 = num4;
					int? userId2 = num;
					short? year2 = value2;
					int? languageID2 = result;
					int? defaultLanguageID2 = result2;
					errorMessage = objectParameter3;
					updatedCompanyId = objectParameter2;
					int? num5 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities3.MobspUpdateCompanyPersonForPs(personId, persons, companyId2, userId2, year2, appType, languageID2, defaultLanguageID2, mobLackOfShowText, errorMessage, updatedCompanyId, model.CenterId));
					if (objectParameter2.Value != null)
					{
						if (objectParameter2.Value.ToString() != "")
						{
							string text15 = objectParameter2.Value.ToString();
							text2 = objectParameter2.Value.ToString();
							text2 = text2.Replace("|Msg=0", "<PRS>" + Messages.MobMsgErrorIsNotCompany + "<\\PRS>");
							text2 = text2.Replace("|Msg=2", "<PRS>" + Messages.MobMsgErrorIsNotPerson + "<\\PRS>");
							num2++;
							text15 = text15.Replace("|Msg=0", "").Replace("|Msg=2", "");
							if (text15.IndexOf("@prsMobile=Dup", StringComparison.Ordinal) >= 0 || text15.IndexOf("@prsEmail=Dup", StringComparison.Ordinal) >= 0 || text15.IndexOf("@prsEmailII=Dup", StringComparison.Ordinal) >= 0)
							{
								string text16 = "";
								if (text15 != null && text15 != "")
								{
									string[] array = text15.Split(new string[1] { "|^|" }, StringSplitOptions.None);
									foreach (string text17 in array)
									{
										if (!string.IsNullOrEmpty(text17))
										{
											string[] array9 = text17.Split(new char[1] { ',' });
											string text18 = "";
											string text19 = "";
											string text20 = "";
											string text21 = "";
											if (array9[0] == "@prsMobile=Dup")
											{
												text21 = array9[3].Replace("@CompanyPersonID=", "") ?? "";
												text19 = array9[1].Replace("@prsLName=", "") ?? "";
												text20 = array9[2].Replace("@prsFName=", "") ?? "";
												text18 = array9[5].Replace("@DupCmpNumber=", "") ?? "";
												text16 = text16 + "<PRS><PRSID>" + text21 + "<\\PRSID>" + string.Format(Messages.MobMsgErrorCheckPrsMobileDuplicate, text20 + " " + text19, text18) + "<\\PRS>";
											}
											else if (array9[0] == "@prsEmail=Dup")
											{
												text21 = array9[3].Replace("@CompanyPersonID=", "") ?? "";
												text19 = array9[1].Replace("@prsLName=", "") ?? "";
												text20 = array9[2].Replace("@prsFName=", "") ?? "";
												text18 = array9[5].Replace("@DupCmpNumber=", "") ?? "";
												text16 = text16 + "<PRS><PRSID>" + text21 + "<\\PRSID>" + string.Format(Messages.MobMsgErrorCheckPrsEmailDuplicate, text20 + " " + text19, text18) + "<\\PRS>";
											}
											else if (array9[0] == "@prsEmailII=Dup")
											{
												text21 = array9[3].Replace("@CompanyPersonID=", "") ?? "";
												text19 = array9[1].Replace("@prsLName=", "") ?? "";
												text20 = array9[2].Replace("@prsFName=", "") ?? "";
												text18 = array9[5].Replace("@DupCmpNumber=", "") ?? "";
												text16 = text16 + "<PRS><PRSID>" + text21 + "<\\PRSID>" + string.Format(Messages.MobMsgErrorCheckPrsEmailIIDuplicate, text20 + " " + text19, text18) + "<\\PRS>";
											}
										}
									}
								}
								text2 = text16;
								num2++;
							}
							string text22 = text15;
							if (text22.IndexOf("|Msg=CompanyAccess|", StringComparison.Ordinal) >= 0)
							{
								if (text22.IndexOf("|Msg=CompanyAccess|", StringComparison.Ordinal) >= 0)
								{
									string[] array10 = text22.Split(new string[1] { "|Msg=CompanyAccess|" }, StringSplitOptions.None);
									if (array10 != null && Enumerable.Count<string>((IEnumerable<string>)array10) == 3 && !string.IsNullOrEmpty(array10[1]))
									{
										string[] array11 = array10[1].Split(new string[1] { "|PRSID|" }, StringSplitOptions.None);
										if (array11 != null && Enumerable.Count<string>((IEnumerable<string>)array11) == 2)
										{
											string text23 = string.Format(Messages.MobMsgErrorrNotAccessToCompany, array11[1]);
											string newValue7 = "<PRS><PRSID>" + array11[0] + "<\\PRSID><PRSCOMPANY>" + text23 + "<\\PRSCOMPANY><\\PRS>";
											text22 = text22.Replace("|Msg=CompanyAccess|" + array10[1] + "|Msg=CompanyAccess|", newValue7);
										}
									}
								}
								text2 = text22;
								num2++;
							}
						}
						else
						{
							text2 = "";
						}
					}
					if (objectParameter3.Value != null)
					{
						_ = (int)(objectParameter3.Value ?? ((object)0));
					}
					if (num5.HasValue && !(num5 >= 1))
					{
						text = Messages.MobMsgErrorDoneOperation;
						status = ServiceResultStatus.Fail;
						return new ServiceResult<InsertQuickCmpPrsPrjCnvsResultViewModel>
						{
							Message = text,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					if (num2 > 0)
					{
						text = text2;
						status = ServiceResultStatus.Fail;
						return new ServiceResult<InsertQuickCmpPrsPrjCnvsResultViewModel>
						{
							Message = text,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					insertQuickCmpPrsPrjCnvsResultViewModel.Persons = objectParameter3.ToString() ?? "0";
					text = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				string projectTitle = model.Projects.Substring(model.Projects.IndexOf("prjTitle=") + 9, model.Projects.IndexOf("|#|prjStartDate=") - (model.Projects.IndexOf("prjTitle=") + 9));
				MobspSelectCrmProjectByProjectTitle_Result mobspSelectCrmProjectByProjectTitle_Result = Enumerable.FirstOrDefault<MobspSelectCrmProjectByProjectTitle_Result>((IEnumerable<MobspSelectCrmProjectByProjectTitle_Result>)cRMEntities.MobspSelectCrmProjectByProjectTitle(projectTitle, model.CompanyId, result, result2));
				if (mobspSelectCrmProjectByProjectTitle_Result == null)
				{
					ObjectParameter objectParameter4 = new ObjectParameter("insertedProjectIds", "");
					ObjectParameter objectParameter5 = new ObjectParameter("errorMessage", "");
					int? num6 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspInsertQuickProject(model.Projects, num, value2, value3, value, registerDatePersian, appType, result, result2, model.Type, objectParameter4, objectParameter5, model.CenterId));
					string text24 = "";
					if (objectParameter5.Value != null)
					{
						if (objectParameter5.Value.ToString() != "")
						{
							string text25 = objectParameter5.Value.ToString();
							text25 = text25.Replace("|Msg=0", "<CMP>" + Messages.MobMsgErrorInsertCompany + "<\\CMP>");
							text25 = text25.Replace("Msg=1", "<CMP>" + Messages.MobMsgErrorInconsistencyInCompanySelection + "<\\CMP>");
							text25 = text25.Replace("Msg=2", "<PRS>" + Messages.MobMsgErrorInsertPersons + "<\\PRS>");
							text25 = text25.Replace("Msg=3", "<PRS>" + Messages.MobMsgErrorInsertPerson + "<\\PRS>");
							text25 = text25.Replace("Msg=4", "<PRJ>" + Messages.MobMsgErrorInsertProjects + "<\\PRJ>");
							text25 = text25.Replace("Msg=5", "<PRJ>" + Messages.MobMsgErrorInsertProject + "<\\PRJ>");
							text25 = text25.Replace("Msg=6", "<CNVS>" + Messages.MobMsgErrorInsertSms + "<\\CNVS>");
							text25 = text25.Replace("Msg=7", "<CNVS>" + Messages.MobMsgErrorInsertConversation + "<\\CNVS>");
							text25 = text25.Replace("Dup=1Msg=0", "<CMP>" + Messages.MobMsgErrorNotInsertDuplicateCompany + "<\\CMP>");
							insertQuickCmpPrsPrjCnvsResultViewModel.ErrorMessage = text25;
							text24 = objectParameter5.Value.ToString();
							if (text24.IndexOf("|Msg=CompanyAccess|", StringComparison.Ordinal) >= 0 || text24.IndexOf("|Msg=PrjAccess|", StringComparison.Ordinal) >= 0)
							{
								text24 = text24.Replace("|Msg=0", "").Replace("Msg=1", "").Replace("Msg=2", "")
									.Replace("Msg=3", "")
									.Replace("Msg=4", "")
									.Replace("Msg=5", "")
									.Replace("Msg=6", "")
									.Replace("Msg=7", "")
									.Replace("Dup=1Msg=0", "");
								if (text24.IndexOf("|Msg=CompanyAccess|", StringComparison.Ordinal) >= 0)
								{
									string[] array12 = text24.Split(new string[1] { "|Msg=CompanyAccess|" }, StringSplitOptions.None);
									if (array12 != null && Enumerable.Count<string>((IEnumerable<string>)array12) == 3)
									{
										if (!string.IsNullOrEmpty(array12[1]))
										{
											string[] array13 = array12[1].Split(new string[1] { "|PRJID|" }, StringSplitOptions.None);
											if (array13 != null && Enumerable.Count<string>((IEnumerable<string>)array13) == 2)
											{
												string text26 = string.Format(Messages.MobMsgErrorrNotAccessToCompany, array13[1]);
												string newValue8 = "<PRJ><PRJID>" + array13[0] + "<\\PRJID><PRJCOMPANY>" + text26 + "<\\PRJCOMPANY><\\PRJ>";
												text24 = text24.Replace("|Msg=CompanyAccess|" + array12[1] + "|Msg=CompanyAccess|", newValue8);
											}
										}
									}
									else if (array12 != null && Enumerable.Count<string>((IEnumerable<string>)array12) > 3)
									{
										for (int j = 1; j < Enumerable.Count<string>((IEnumerable<string>)array12); j++)
										{
											if (!string.IsNullOrEmpty(array12[j]))
											{
												string[] array14 = array12[j].Split(new string[1] { "|PRJID|" }, StringSplitOptions.None);
												if (array14 != null && Enumerable.Count<string>((IEnumerable<string>)array14) == 2)
												{
													string text27 = string.Format(Messages.MobMsgErrorrNotAccessToCompany, array14[1]);
													string newValue9 = "<PRJ><PRJID>" + array14[0] + "<\\PRJID><PRJCOMPANY>" + text27 + "<\\PRJCOMPANY><\\PRJ>";
													text24 = text24.Replace("|Msg=CompanyAccess|" + array12[j] + "|Msg=CompanyAccess|", newValue9);
												}
											}
										}
									}
								}
								if (text24.IndexOf("|Msg=PrjAccess|", StringComparison.Ordinal) >= 0)
								{
									string[] array15 = text24.Split(new string[1] { "|Msg=PrjAccess|" }, StringSplitOptions.None);
									if (array15 != null && Enumerable.Count<string>((IEnumerable<string>)array15) == 3)
									{
										if (!string.IsNullOrEmpty(array15[1]))
										{
											string[] array16 = array15[1].Split(new string[1] { "|PRJID|" }, StringSplitOptions.None);
											if (array16 != null && Enumerable.Count<string>((IEnumerable<string>)array16) == 2)
											{
												string text28 = string.Format(Messages.MobMsgErrorrNotAccessToProject, array16[1]);
												string newValue10 = "<PRJ><PRJID>" + array16[0] + "<\\PRJID><PRJTITLE>" + text28 + "<\\PRJTITLE><\\PRJ>";
												text24 = text24.Replace("|Msg=PrjAccess|" + array15[1] + "|Msg=PrjAccess|", newValue10);
											}
										}
									}
									else if (array15 != null && Enumerable.Count<string>((IEnumerable<string>)array15) > 3)
									{
										for (int k = 1; k < Enumerable.Count<string>((IEnumerable<string>)array15); k++)
										{
											if (!string.IsNullOrEmpty(array15[k]))
											{
												string[] array17 = array15[k].Split(new string[1] { "|PRJID|" }, StringSplitOptions.None);
												if (array17 != null && Enumerable.Count<string>((IEnumerable<string>)array17) == 2)
												{
													string text29 = string.Format(Messages.MobMsgErrorrNotAccessToProject, array17[1]);
													string newValue11 = "<PRJ><PRJID>" + array17[0] + "<\\PRJID><PRJTITLE>" + text29 + "<\\PRJTITLE><\\PRJ>";
													text24 = text24.Replace("|Msg=PrjAccess|" + array15[k] + "|Msg=PrjAccess|", newValue11);
												}
											}
										}
									}
								}
								insertQuickCmpPrsPrjCnvsResultViewModel.ErrorMessage = text24;
							}
							else
							{
								text24 = "";
							}
						}
						else
						{
							insertQuickCmpPrsPrjCnvsResultViewModel.ErrorMessage = "";
						}
					}
					if (objectParameter4.Value != null)
					{
						string text30 = objectParameter4.Value.ToString();
						insertQuickCmpPrsPrjCnvsResultViewModel.Projects = text30.Substring(text30.IndexOf(",") + 1, text30.IndexOf("|") - 2) ?? "0";
					}
					else
					{
						insertQuickCmpPrsPrjCnvsResultViewModel.Projects = "0";
					}
					if (num6.HasValue && !(num6 >= 1))
					{
						text = Messages.MobMsgErrorDoneOperation;
						status = ServiceResultStatus.Fail;
						return new ServiceResult<InsertQuickCmpPrsPrjCnvsResultViewModel>
						{
							Message = text,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					if (!string.IsNullOrEmpty(insertQuickCmpPrsPrjCnvsResultViewModel.ErrorMessage))
					{
						text = insertQuickCmpPrsPrjCnvsResultViewModel.ErrorMessage;
						status = ServiceResultStatus.Fail;
						return new ServiceResult<InsertQuickCmpPrsPrjCnvsResultViewModel>
						{
							Message = text,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
				}
				else
				{
					insertQuickCmpPrsPrjCnvsResultViewModel.Projects = mobspSelectCrmProjectByProjectTitle_Result.ProjectID.ToString();
				}
				List<MobspSelectLanguages_Result> list = Enumerable.ToList<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)cRMEntities.MobspSelectLanguages());
				string mobCnvsReferUserCmpNotAccess = Messages.MobCnvsReferUserCmpNotAccess;
				string text31 = "";
				string text32 = "";
				string text33 = "";
				foreach (MobspSelectLanguages_Result item in list)
				{
					text3 = "";
					text3 = "\r\n" + MyResource.GetResourceString("MobConversationErjaMultiUser", item.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + " : {MultiUser}";
					text4 = "";
					text4 = "\r\n" + MyResource.GetResourceString("MobConversationErjaReferDescription", item.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":\r\n{CNVSREFERDESC}";
					mobCnvsReferUserCmpNotAccess = "";
					mobCnvsReferUserCmpNotAccess = MyResource.GetResourceString("MobCnvsReferUserCmpNotAccess", item.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
					text31 = text31 + "MsgErjaMultiUser=" + text3 + "|@#@|LangId=" + item.LanguageID + "|@#@||^#^|";
					text32 = text32 + "MsgReferDesc=" + text4 + "|@#@|LangId=" + item.LanguageID + "|@#@||^#^|";
					text33 = text33 + "CmpNotAccess=" + mobCnvsReferUserCmpNotAccess + "|@#@|LangId=" + item.LanguageID + "|@#@||^#^|";
				}
				text3 = text31;
				text4 = text32;
				mobCnvsReferUserCmpNotAccess = text33;
				string text34 = "";
				string text35 = "";
				string text36 = "";
				text34 = "";
				foreach (MobspSelectLanguages_Result item2 in list)
				{
					text35 = "";
					text36 = "";
					text35 = MyResource.GetResourceString("MobConversationErjaFrom", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + " " + Common.GetUserName(num, result2, item2.LanguageID, model.CenterId);
					text36 = MyResource.GetResourceString("MobConversationErjaInConnection", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {CMP}\r\n" + MyResource.GetResourceString("MobConversationErjaPerson", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {PRS}\r\n" + MyResource.GetResourceString("MobConversationErjaProject", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {PRJ}{MultiUser}";
					text36 = text36 + "\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaConversationDescription", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":\r\n{CNVSDESC}{CNVSREFERDESC}";
					text36 = text36 + "\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaDetails", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
					text34 = text34 + "MsgSubj=" + text35 + "|@#@|MsgBody=" + text36 + "|@#@|LangId=" + item2.LanguageID + "|@#@||^#^|";
				}
				text35 = "";
				text36 = text34;
				string text37 = "";
				string text38 = "";
				text34 = "";
				foreach (MobspSelectLanguages_Result item3 in list)
				{
					text37 = "";
					text38 = "";
					text37 = MyResource.GetResourceString("MobConversationErjaNotice", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + Common.GetUserName(num, result2, item3.LanguageID, model.CenterId);
					text38 = "**" + MyResource.GetResourceString("MobConversationErjaAutomatically", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaAttention", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("MobConversationErjaInConnection", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {CMP}\r\n" + MyResource.GetResourceString("MobConversationErjaPerson", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {PRS}\r\n" + MyResource.GetResourceString("MobConversationErjaProject", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {PRJ}\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaLastNegotiator", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ", " + MyResource.GetResourceString("MobConversationErjaTransmitter", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("MobConversationErjaMultiUser", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "{MultiUser}\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaConversationDescription", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": \r\n{CNVSDESC}{CNVSREFERDESC}";
					text38 = text38 + "\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaDetails", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
					text34 = text34 + "MsgSubj=" + text37 + "|@#@|MsgBody=" + text38 + "|@#@|LangId=" + item3.LanguageID + "|@#@||^#^|";
				}
				text37 = "";
				text38 = text34;
				string text39 = "";
				string text40 = "";
				text34 = "";
				foreach (MobspSelectLanguages_Result item4 in list)
				{
					text39 = "";
					text40 = "";
					text39 = MyResource.GetResourceString("MobConversationErjaRonevesht", item4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + Common.GetUserName(num, result2, item4.LanguageID, model.CenterId);
					text40 = MyResource.GetResourceString("MobConversationErjaInConnection", item4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {CMP} \r\n" + MyResource.GetResourceString("MobConversationErjaPerson", item4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {PRS} \r\n" + MyResource.GetResourceString("MobConversationErjaProject", item4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {PRJ}\r\n" + MyResource.GetResourceString("MobConversationErjaMultiUser", item4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + " : {MultiUser}\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaConversationDescription", item4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": \r\n{CNVSDESC}{CNVSREFERDESC}";
					text40 = text40 + "\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaDetails", item4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
					text34 = text34 + "MsgSubj=" + text39 + "|@#@|MsgBody=" + text40 + "|@#@|LangId=" + item4.LanguageID + "|@#@||^#^|";
				}
				text39 = "";
				text40 = text34;
				int value4 = 7;
				model.Conversations = model.Conversations.Replace("cnvsProjectId=", "cnvsProjectId=" + insertQuickCmpPrsPrjCnvsResultViewModel.Projects);
				string text41 = "";
				string surveyMainExtrenalLinkLogin = "";
				string surveyMainExtrenalLink = "";
				string text42 = base.Request.RequestUri.GetLeftPart(UriPartial.Authority);
				string leftPart = base.Request.RequestUri.GetLeftPart(UriPartial.Scheme);
				if (text42.EndsWith("/"))
				{
					text42 = text42.TrimEnd(new char[1] { '/' });
				}
				text42 += "/Survey/Home/SurveyAnswerValues";
				text41 = text42;
				string text43 = "";
				MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result = SysSeting.Get();
				string text44 = "";
				string text45 = "";
				if (mobspSelectCrmsysSetting_Result != null)
				{
					text44 = mobspSelectCrmsysSetting_Result.FOUrl ?? "";
					text45 = mobspSelectCrmsysSetting_Result.CrmIPStatic ?? "";
				}
				if (!string.IsNullOrWhiteSpace(text44))
				{
					text43 = text44.Trim();
					if (!text43.Contains("http"))
					{
						text43 = leftPart + text43;
					}
					if (text43.EndsWith("/"))
					{
						text43 = text43.TrimEnd(new char[1] { '/' });
					}
					text43 += "/Survey/Home";
					surveyMainExtrenalLinkLogin = text43;
				}
				if (!string.IsNullOrWhiteSpace(text45))
				{
					text43 = text45.Trim();
					if (!text43.Contains("http"))
					{
						text43 = leftPart + text43;
					}
					if (text43.EndsWith("/"))
					{
						text43 = text43.TrimEnd(new char[1] { '/' });
					}
					text43 += "/Survey/Register/Index";
				}
				int maxFOCount = Mobile.Classes.Configuration.MaxFOCount;
				ObjectParameter objectParameter6 = new ObjectParameter("insertedConversationIds", "");
				ObjectParameter objectParameter7 = new ObjectParameter("errorMessage", "");
				ObjectParameter objectParameter8 = new ObjectParameter("result", 0);
				CRMEntities cRMEntities4 = cRMEntities;
				string conversations = model.Conversations;
				int? userId3 = num;
				short? year3 = value2;
				short? month = value3;
				DateTime? registerDate = value;
				int? languageID3 = result;
				int? defaultLanguageID3 = result2;
				string needErjaRefmsgSubj = text35;
				string needErjaRefmsgBody = text36;
				string needErjaMultiIntmsgSubject = text39;
				string needErjaMultiIntmsgBody = text40;
				string needSendErjaAllarmRefmsgSubj = text37;
				string needSendErjaAllarmRefmsgBody = text38;
				string msgConversationErjaMultiUser = text3;
				string msgConversationErjaReferDescription = text4;
				updatedCompanyId = objectParameter6;
				errorMessage = objectParameter7;
				string type = model.Type;
				ObjectParameter insertedConversationIds = updatedCompanyId;
				ObjectParameter errorMessage2 = errorMessage;
				text5 = mobCnvsReferUserCmpNotAccess;
				Enumerable.FirstOrDefault<MobspInsertQuickConversation_Result>((IEnumerable<MobspInsertQuickConversation_Result>)cRMEntities4.MobspInsertQuickConversation(conversations, userId3, year3, month, registerDate, registerDatePersian, appType, languageID3, defaultLanguageID3, needErjaRefmsgSubj, needErjaRefmsgBody, needErjaMultiIntmsgSubject, needErjaMultiIntmsgBody, needSendErjaAllarmRefmsgSubj, needSendErjaAllarmRefmsgBody, mobConversationErjaShow, msgConversationErjaMultiUser, msgConversationErjaReferDescription, type, insertedConversationIds, errorMessage2, objectParameter8, value4, text5, text41, surveyMainExtrenalLink, surveyMainExtrenalLinkLogin, conversationErjaShow, eventErjaRefmsg, model.CenterId, maxFOCount));
				string text46 = "";
				if (objectParameter7.Value != null)
				{
					if (objectParameter7.Value.ToString() != "")
					{
						string text47 = objectParameter7.Value.ToString();
						text47 = text47.Replace("|Msg=0", "<CMP>" + Messages.MobMsgErrorInsertCompany + "<\\CMP>");
						text47 = text47.Replace("Msg=1", "<CMP>" + Messages.MobMsgErrorInconsistencyInCompanySelection + "<\\CMP>");
						text47 = text47.Replace("Msg=2", "<PRS>" + Messages.MobMsgErrorInsertPersons + "<\\PRS>");
						text47 = text47.Replace("Msg=3", "<PRS>" + Messages.MobMsgErrorInsertPerson + "<\\PRS>");
						text47 = text47.Replace("Msg=4", "<PRJ>" + Messages.MobMsgErrorInsertProjects + "<\\PRJ>");
						text47 = text47.Replace("Msg=5", "<PRJ>" + Messages.MobMsgErrorInsertProject + "<\\PRJ>");
						text47 = text47.Replace("Msg=6", "<CNVS>" + Messages.MobMsgErrorInsertSms + "<\\CNVS>");
						text47 = text47.Replace("Msg=7", "<CNVS>" + Messages.MobMsgErrorInsertConversation + "<\\CNVS>");
						text47 = text47.Replace("Dup=1Msg=0", "<CMP>" + Messages.MobMsgErrorNotInsertDuplicateCompany + "<\\CMP>");
						insertQuickCmpPrsPrjCnvsResultViewModel.ErrorMessage = text47;
						text46 = objectParameter7.Value.ToString();
						if (text46.IndexOf("|Msg=CompanyAccess|", StringComparison.Ordinal) >= 0 || text46.IndexOf("|Msg=PrjAccess|", StringComparison.Ordinal) >= 0)
						{
							text46 = text46.Replace("|Msg=0", "").Replace("Msg=1", "").Replace("Msg=2", "")
								.Replace("Msg=3", "")
								.Replace("Msg=4", "")
								.Replace("Msg=5", "")
								.Replace("Msg=6", "")
								.Replace("Msg=7", "")
								.Replace("Dup=1Msg=0", "");
							if (text46.IndexOf("|Msg=CompanyAccess|", StringComparison.Ordinal) >= 0)
							{
								string[] array18 = text46.Split(new string[1] { "|Msg=CompanyAccess|" }, StringSplitOptions.None);
								if (array18 != null && Enumerable.Count<string>((IEnumerable<string>)array18) == 3)
								{
									if (!string.IsNullOrEmpty(array18[1]))
									{
										string[] array19 = array18[1].Split(new string[1] { "|CNVSID|" }, StringSplitOptions.None);
										if (array19 != null && Enumerable.Count<string>((IEnumerable<string>)array19) == 2)
										{
											string text48 = string.Format(Messages.MobMsgErrorrNotAccessToCompany, array19[1]);
											string newValue12 = "<CNVS><CNVSID>" + array19[0] + "<\\CNVSID><CNVSCOMPANY>" + text48 + "<\\CNVSCOMPANY><\\CNVS>";
											text46 = text46.Replace("|Msg=CompanyAccess|" + array18[1] + "|Msg=CompanyAccess|", newValue12);
										}
									}
								}
								else if (array18 != null && Enumerable.Count<string>((IEnumerable<string>)array18) > 3)
								{
									for (int l = 1; l < Enumerable.Count<string>((IEnumerable<string>)array18); l++)
									{
										if (!string.IsNullOrEmpty(array18[l]))
										{
											string[] array20 = array18[l].Split(new string[1] { "|CNVSID|" }, StringSplitOptions.None);
											if (array20 != null && Enumerable.Count<string>((IEnumerable<string>)array20) == 2)
											{
												string text49 = string.Format(Messages.MobMsgErrorrNotAccessToCompany, array20[1]);
												string newValue13 = "<CNVS><CNVSID>" + array20[0] + "<\\CNVSID><CNVSCOMPANY>" + text49 + "<\\CNVSCOMPANY><\\CNVS>";
												text46 = text46.Replace("|Msg=CompanyAccess|" + array18[l] + "|Msg=CompanyAccess|", newValue13);
											}
										}
									}
								}
							}
							if (text46.IndexOf("|Msg=PrjAccess|", StringComparison.Ordinal) >= 0)
							{
								string[] array21 = text46.Split(new string[1] { "|Msg=PrjAccess|" }, StringSplitOptions.None);
								if (array21 != null && Enumerable.Count<string>((IEnumerable<string>)array21) == 3)
								{
									if (!string.IsNullOrEmpty(array21[1]))
									{
										string[] array22 = array21[1].Split(new string[1] { "|CNVSID|" }, StringSplitOptions.None);
										if (array22 != null && Enumerable.Count<string>((IEnumerable<string>)array22) == 2)
										{
											string text50 = string.Format(Messages.MobMsgErrorrNotAccessToProject, array22[1]);
											string newValue14 = "<CNVS><CNVSID>" + array22[0] + "<\\CNVSID><CNVSPROJECT>" + text50 + "<\\CNVSPROJECT><\\CNVS>";
											text46 = text46.Replace("|Msg=PrjAccess|" + array21[1] + "|Msg=PrjAccess|", newValue14);
										}
									}
								}
								else if (array21 != null && Enumerable.Count<string>((IEnumerable<string>)array21) > 3)
								{
									for (int m = 1; m < Enumerable.Count<string>((IEnumerable<string>)array21); m++)
									{
										if (!string.IsNullOrEmpty(array21[m]))
										{
											string[] array23 = array21[m].Split(new string[1] { "|CNVSID|" }, StringSplitOptions.None);
											if (array23 != null && Enumerable.Count<string>((IEnumerable<string>)array23) == 2)
											{
												string text51 = string.Format(Messages.MobMsgErrorrNotAccessToProject, array23[1]);
												string newValue15 = "<CNVS><CNVSID>" + array23[0] + "<\\CNVSID><CNVSPROJECT>" + text51 + "<\\CNVSPROJECT><\\CNVS>";
												text46 = text46.Replace("|Msg=PrjAccess|" + array21[m] + "|Msg=PrjAccess|", newValue15);
											}
										}
									}
								}
							}
							insertQuickCmpPrsPrjCnvsResultViewModel.ErrorMessage = text46;
						}
						else
						{
							text46 = "";
						}
					}
					else
					{
						insertQuickCmpPrsPrjCnvsResultViewModel.ErrorMessage = "";
					}
				}
				if (objectParameter6.Value != null)
				{
					string text52 = objectParameter6.Value.ToString();
					insertQuickCmpPrsPrjCnvsResultViewModel.Conversations = text52.Substring(text52.IndexOf(",") + 1, text52.IndexOf("|") - 2) ?? "0";
				}
				else
				{
					insertQuickCmpPrsPrjCnvsResultViewModel.Conversations = "0";
				}
				if (objectParameter8.Value == null)
				{
					text = Messages.MobMsgErrorDoneOperation;
					status = ServiceResultStatus.Fail;
					return new ServiceResult<InsertQuickCmpPrsPrjCnvsResultViewModel>
					{
						Message = text,
						Data = null,
						Status = ServiceResultStatus.Fail
					};
				}
				if (!(objectParameter8.Value.ToString() == "1"))
				{
					text = Messages.MobMsgErrorDoneOperation;
					status = ServiceResultStatus.Fail;
					return new ServiceResult<InsertQuickCmpPrsPrjCnvsResultViewModel>
					{
						Message = text,
						Data = null,
						Status = ServiceResultStatus.Fail
					};
				}
				if (!string.IsNullOrEmpty(insertQuickCmpPrsPrjCnvsResultViewModel.ErrorMessage))
				{
					text = insertQuickCmpPrsPrjCnvsResultViewModel.ErrorMessage;
					status = ServiceResultStatus.Fail;
					return new ServiceResult<InsertQuickCmpPrsPrjCnvsResultViewModel>
					{
						Message = text,
						Data = null,
						Status = ServiceResultStatus.Fail
					};
				}
				Sms sms = new Sms();
				SmsSendViewModel smsSendViewModel = new SmsSendViewModel();
				smsSendViewModel.SendType = 1;
				smsSendViewModel.Sid = -1;
				smsSendViewModel.SmsNumberCount = 1;
				smsSendViewModel.LangId = model.LanguageId;
				smsSendViewModel.CompaniesId = model.CompanyId.ToString();
				smsSendViewModel.CompanyPersonsId = model.PersonId.ToString();
				smsSendViewModel.UserId = num;
				smsSendViewModel.SmsToNumber = model.MobileNumber;
				smsSendViewModel.Cmessage = 1;
				smsSendViewModel.SmsSendBody = "درخواست شما در خصوص " + model.RequestedOn + " با موفقیت ثبت شد.\nکد اشتراک: " + model.CompanyNumber + "\nکد پیگیری: " + insertQuickCmpPrsPrjCnvsResultViewModel.Conversations + "\n*تعمیرکار هوم*\nwww.tamirkar.app";
				smsSendViewModel.CenterId = model.CenterId;
				SmsSendViewModel newSms = smsSendViewModel;
				text = sms.SendSmsSingle(newSms);
				if (string.IsNullOrEmpty(text))
				{
					status = ServiceResultStatus.Success;
				}
				else
				{
					insertQuickCmpPrsPrjCnvsResultViewModel = null;
					status = ServiceResultStatus.Error;
				}
				PushNotif.NewIntMsgNotify(withthread: true, model.CenterId);
			}
			else
			{
				text = Messages.MobMsgErrorAccessingToken;
				insertQuickCmpPrsPrjCnvsResultViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			text = Messages.MobMsgErrorDoneOperation;
			insertQuickCmpPrsPrjCnvsResultViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<InsertQuickCmpPrsPrjCnvsResultViewModel>
		{
			Message = text,
			Data = insertQuickCmpPrsPrjCnvsResultViewModel,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<InsertPrjAndCnvsForLoginViewModel> InsertPrjAndCnvs(InsertPrjAndCnvsForLoginViewModel model)
	{
		InsertPrjAndCnvsForLoginViewModel insertPrjAndCnvsForLoginViewModel = new InsertPrjAndCnvsForLoginViewModel();
		string text = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		CRMEntities cRMEntities = null;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			int num = 1065;
			BaseInfo baseInfo = new BaseInfo();
			num = ((model.LangId > 0) ? model.LangId : 1065);
			int culture = ((num > 0) ? num : result);
			baseInfo.SetCulture(culture);
			DateTime now = DateTime.Now;
			_ = Labels.MobPersonLabel;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string mobConversationErjaShow = Messages.MobConversationErjaShow;
			string appType = Mobile.Classes.Configuration.AppType;
			string text2 = "\r\n" + Messages.MobConversationErjaMultiUser + "{MultiUser}";
			string text3 = "\r\n" + Messages.MobConversationErjaReferDescription + ":\r\n{CNVSREFERDESC}";
			string conversationErjaShow = Messages.ConversationErjaShow;
			string eventErjaRefmsg = "";
			_ = Labels.MobLackOfShowText;
			cRMEntities = new CRMEntities();
			List<MobspSelectLanguages_Result> list = Enumerable.ToList<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)cRMEntities.MobspSelectLanguages());
			if (model.CompanyId > 0 && model.PersonId > 0 && string.IsNullOrEmpty(text))
			{
				string projectTitle = model.Project.Substring(model.Project.IndexOf("prjTitle=") + 9, model.Project.IndexOf("|#|prjStartDate=") - (model.Project.IndexOf("prjTitle=") + 9));
				MobspSelectCrmProjectByProjectTitle_Result mobspSelectCrmProjectByProjectTitle_Result = Enumerable.FirstOrDefault<MobspSelectCrmProjectByProjectTitle_Result>((IEnumerable<MobspSelectCrmProjectByProjectTitle_Result>)cRMEntities.MobspSelectCrmProjectByProjectTitle(projectTitle, model.CompanyId, num, result));
				if (mobspSelectCrmProjectByProjectTitle_Result == null)
				{
					ObjectParameter objectParameter = new ObjectParameter("insertedProjectIds", "");
					ObjectParameter objectParameter2 = new ObjectParameter("errorMessage", "");
					int? num2 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspInsertQuickProject(model.Project, model.UserId, value2, value3, value, registerDatePersian, appType, num, result, model.Type, objectParameter, objectParameter2, model.CenterId));
					string text4 = "";
					if (objectParameter2.Value != null)
					{
						if (objectParameter2.Value.ToString() != "")
						{
							string text5 = objectParameter2.Value.ToString();
							text5 = text5.Replace("|Msg=0", "<CMP>" + Messages.MobMsgErrorInsertCompany + "<\\CMP>");
							text5 = text5.Replace("Msg=1", "<CMP>" + Messages.MobMsgErrorInconsistencyInCompanySelection + "<\\CMP>");
							text5 = text5.Replace("Msg=2", "<PRS>" + Messages.MobMsgErrorInsertPersons + "<\\PRS>");
							text5 = text5.Replace("Msg=3", "<PRS>" + Messages.MobMsgErrorInsertPerson + "<\\PRS>");
							text5 = text5.Replace("Msg=4", "<PRJ>" + Messages.MobMsgErrorInsertProjects + "<\\PRJ>");
							text5 = text5.Replace("Msg=5", "<PRJ>" + Messages.MobMsgErrorInsertProject + "<\\PRJ>");
							text5 = text5.Replace("Msg=6", "<CNVS>" + Messages.MobMsgErrorInsertSms + "<\\CNVS>");
							text5 = text5.Replace("Msg=7", "<CNVS>" + Messages.MobMsgErrorInsertConversation + "<\\CNVS>");
							text5 = text5.Replace("Dup=1Msg=0", "<CMP>" + Messages.MobMsgErrorNotInsertDuplicateCompany + "<\\CMP>");
							insertPrjAndCnvsForLoginViewModel.ErrorMessage = text5;
							text4 = objectParameter2.Value.ToString();
							if (text4.IndexOf("|Msg=CompanyAccess|", StringComparison.Ordinal) >= 0 || text4.IndexOf("|Msg=PrjAccess|", StringComparison.Ordinal) >= 0)
							{
								text4 = text4.Replace("|Msg=0", "").Replace("Msg=1", "").Replace("Msg=2", "")
									.Replace("Msg=3", "")
									.Replace("Msg=4", "")
									.Replace("Msg=5", "")
									.Replace("Msg=6", "")
									.Replace("Msg=7", "")
									.Replace("Dup=1Msg=0", "");
								if (text4.IndexOf("|Msg=CompanyAccess|", StringComparison.Ordinal) >= 0)
								{
									string[] array = text4.Split(new string[1] { "|Msg=CompanyAccess|" }, StringSplitOptions.None);
									if (array != null && Enumerable.Count<string>((IEnumerable<string>)array) == 3)
									{
										if (!string.IsNullOrEmpty(array[1]))
										{
											string[] array2 = array[1].Split(new string[1] { "|PRJID|" }, StringSplitOptions.None);
											if (array2 != null && Enumerable.Count<string>((IEnumerable<string>)array2) == 2)
											{
												string text6 = string.Format(Messages.MobMsgErrorrNotAccessToCompany, array2[1]);
												string newValue = "<PRJ><PRJID>" + array2[0] + "<\\PRJID><PRJCOMPANY>" + text6 + "<\\PRJCOMPANY><\\PRJ>";
												text4 = text4.Replace("|Msg=CompanyAccess|" + array[1] + "|Msg=CompanyAccess|", newValue);
											}
										}
									}
									else if (array != null && Enumerable.Count<string>((IEnumerable<string>)array) > 3)
									{
										for (int i = 1; i < Enumerable.Count<string>((IEnumerable<string>)array); i++)
										{
											if (!string.IsNullOrEmpty(array[i]))
											{
												string[] array3 = array[i].Split(new string[1] { "|PRJID|" }, StringSplitOptions.None);
												if (array3 != null && Enumerable.Count<string>((IEnumerable<string>)array3) == 2)
												{
													string text7 = string.Format(Messages.MobMsgErrorrNotAccessToCompany, array3[1]);
													string newValue2 = "<PRJ><PRJID>" + array3[0] + "<\\PRJID><PRJCOMPANY>" + text7 + "<\\PRJCOMPANY><\\PRJ>";
													text4 = text4.Replace("|Msg=CompanyAccess|" + array[i] + "|Msg=CompanyAccess|", newValue2);
												}
											}
										}
									}
								}
								if (text4.IndexOf("|Msg=PrjAccess|", StringComparison.Ordinal) >= 0)
								{
									string[] array4 = text4.Split(new string[1] { "|Msg=PrjAccess|" }, StringSplitOptions.None);
									if (array4 != null && Enumerable.Count<string>((IEnumerable<string>)array4) == 3)
									{
										if (!string.IsNullOrEmpty(array4[1]))
										{
											string[] array5 = array4[1].Split(new string[1] { "|PRJID|" }, StringSplitOptions.None);
											if (array5 != null && Enumerable.Count<string>((IEnumerable<string>)array5) == 2)
											{
												string text8 = string.Format(Messages.MobMsgErrorrNotAccessToProject, array5[1]);
												string newValue3 = "<PRJ><PRJID>" + array5[0] + "<\\PRJID><PRJTITLE>" + text8 + "<\\PRJTITLE><\\PRJ>";
												text4 = text4.Replace("|Msg=PrjAccess|" + array4[1] + "|Msg=PrjAccess|", newValue3);
											}
										}
									}
									else if (array4 != null && Enumerable.Count<string>((IEnumerable<string>)array4) > 3)
									{
										for (int j = 1; j < Enumerable.Count<string>((IEnumerable<string>)array4); j++)
										{
											if (!string.IsNullOrEmpty(array4[j]))
											{
												string[] array6 = array4[j].Split(new string[1] { "|PRJID|" }, StringSplitOptions.None);
												if (array6 != null && Enumerable.Count<string>((IEnumerable<string>)array6) == 2)
												{
													string text9 = string.Format(Messages.MobMsgErrorrNotAccessToProject, array6[1]);
													string newValue4 = "<PRJ><PRJID>" + array6[0] + "<\\PRJID><PRJTITLE>" + text9 + "<\\PRJTITLE><\\PRJ>";
													text4 = text4.Replace("|Msg=PrjAccess|" + array4[j] + "|Msg=PrjAccess|", newValue4);
												}
											}
										}
									}
								}
								insertPrjAndCnvsForLoginViewModel.ErrorMessage = text4;
							}
							else
							{
								text4 = "";
							}
						}
						else
						{
							insertPrjAndCnvsForLoginViewModel.ErrorMessage = "";
						}
					}
					if (objectParameter.Value != null)
					{
						try
						{
							string text10 = objectParameter.Value.ToString();
							string s = text10.Substring(text10.IndexOf(",") + 1, text10.IndexOf("|") - 2) ?? "0";
							insertPrjAndCnvsForLoginViewModel.ProjectId = int.Parse(s);
						}
						catch (Exception ex)
						{
							insertPrjAndCnvsForLoginViewModel.ProjectId = 0;
							string message = "Error On Split Project Ids => " + ex.Message;
							ErrorSignal.FromCurrentContext().Raise(new Exception(message));
						}
					}
					else
					{
						insertPrjAndCnvsForLoginViewModel.ProjectId = 0;
					}
					if (num2.HasValue && !(num2 >= 1))
					{
						text = Messages.MobMsgErrorDoneOperation;
						status = ServiceResultStatus.Fail;
						return new ServiceResult<InsertPrjAndCnvsForLoginViewModel>
						{
							Message = text,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					if (!string.IsNullOrEmpty(insertPrjAndCnvsForLoginViewModel.ErrorMessage))
					{
						text = insertPrjAndCnvsForLoginViewModel.ErrorMessage;
						status = ServiceResultStatus.Fail;
						return new ServiceResult<InsertPrjAndCnvsForLoginViewModel>
						{
							Message = text,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
				}
				else
				{
					insertPrjAndCnvsForLoginViewModel.ProjectId = mobspSelectCrmProjectByProjectTitle_Result.ProjectID;
				}
				string mobCnvsReferUserCmpNotAccess = Messages.MobCnvsReferUserCmpNotAccess;
				string text11 = "";
				string text12 = "";
				string text13 = "";
				foreach (MobspSelectLanguages_Result item in list)
				{
					text2 = "";
					text2 = "\r\n" + MyResource.GetResourceString("MobConversationErjaMultiUser", item.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + " : {MultiUser}";
					text3 = "";
					text3 = "\r\n" + MyResource.GetResourceString("MobConversationErjaReferDescription", item.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":\r\n{CNVSREFERDESC}";
					mobCnvsReferUserCmpNotAccess = "";
					mobCnvsReferUserCmpNotAccess = MyResource.GetResourceString("MobCnvsReferUserCmpNotAccess", item.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
					text11 = text11 + "MsgErjaMultiUser=" + text2 + "|@#@|LangId=" + item.LanguageID + "|@#@||^#^|";
					text12 = text12 + "MsgReferDesc=" + text3 + "|@#@|LangId=" + item.LanguageID + "|@#@||^#^|";
					text13 = text13 + "CmpNotAccess=" + mobCnvsReferUserCmpNotAccess + "|@#@|LangId=" + item.LanguageID + "|@#@||^#^|";
				}
				text2 = text11;
				text3 = text12;
				mobCnvsReferUserCmpNotAccess = text13;
				string text14 = "";
				string text15 = "";
				string text16 = "";
				text14 = "";
				foreach (MobspSelectLanguages_Result item2 in list)
				{
					text15 = "";
					text16 = "";
					text15 = MyResource.GetResourceString("MobConversationErjaFrom", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + " " + Common.GetUserName(model.UserId, result, item2.LanguageID, model.CenterId);
					text16 = MyResource.GetResourceString("MobConversationErjaInConnection", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {CMP}\r\n" + MyResource.GetResourceString("MobConversationErjaPerson", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {PRS}\r\n" + MyResource.GetResourceString("MobConversationErjaProject", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {PRJ}{MultiUser}";
					text16 = text16 + "\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaConversationDescription", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":\r\n{CNVSDESC}{CNVSREFERDESC}";
					text16 = text16 + "\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaDetails", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
					text14 = text14 + "MsgSubj=" + text15 + "|@#@|MsgBody=" + text16 + "|@#@|LangId=" + item2.LanguageID + "|@#@||^#^|";
				}
				text15 = "";
				text16 = text14;
				string text17 = "";
				string text18 = "";
				text14 = "";
				foreach (MobspSelectLanguages_Result item3 in list)
				{
					text17 = "";
					text18 = "";
					text17 = MyResource.GetResourceString("MobConversationErjaNotice", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + Common.GetUserName(model.UserId, result, item3.LanguageID, model.CenterId);
					text18 = "**" + MyResource.GetResourceString("MobConversationErjaAutomatically", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaAttention", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("MobConversationErjaInConnection", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {CMP}\r\n" + MyResource.GetResourceString("MobConversationErjaPerson", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {PRS}\r\n" + MyResource.GetResourceString("MobConversationErjaProject", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {PRJ}\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaLastNegotiator", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ", " + MyResource.GetResourceString("MobConversationErjaTransmitter", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("MobConversationErjaMultiUser", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "{MultiUser}\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaConversationDescription", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": \r\n{CNVSDESC}{CNVSREFERDESC}";
					text18 = text18 + "\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaDetails", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
					text14 = text14 + "MsgSubj=" + text17 + "|@#@|MsgBody=" + text18 + "|@#@|LangId=" + item3.LanguageID + "|@#@||^#^|";
				}
				text17 = "";
				text18 = text14;
				string text19 = "";
				string text20 = "";
				text14 = "";
				foreach (MobspSelectLanguages_Result item4 in list)
				{
					text19 = "";
					text20 = "";
					text19 = MyResource.GetResourceString("MobConversationErjaRonevesht", item4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + Common.GetUserName(model.UserId, result, item4.LanguageID, model.CenterId);
					text20 = MyResource.GetResourceString("MobConversationErjaInConnection", item4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {CMP} \r\n" + MyResource.GetResourceString("MobConversationErjaPerson", item4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {PRS} \r\n" + MyResource.GetResourceString("MobConversationErjaProject", item4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {PRJ}\r\n" + MyResource.GetResourceString("MobConversationErjaMultiUser", item4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + " : {MultiUser}\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaConversationDescription", item4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": \r\n{CNVSDESC}{CNVSREFERDESC}";
					text20 = text20 + "\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaDetails", item4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
					text14 = text14 + "MsgSubj=" + text19 + "|@#@|MsgBody=" + text20 + "|@#@|LangId=" + item4.LanguageID + "|@#@||^#^|";
				}
				text19 = "";
				text20 = text14;
				int value4 = 7;
				model.Conversation = model.Conversation.Replace("cnvsProjectId=", "cnvsProjectId=" + insertPrjAndCnvsForLoginViewModel.ProjectId);
				string text21 = "";
				string surveyMainExtrenalLinkLogin = "";
				string surveyMainExtrenalLink = "";
				string text22 = base.Request.RequestUri.GetLeftPart(UriPartial.Authority);
				string leftPart = base.Request.RequestUri.GetLeftPart(UriPartial.Scheme);
				if (text22.EndsWith("/"))
				{
					text22 = text22.TrimEnd(new char[1] { '/' });
				}
				text22 += "/Survey/Home/SurveyAnswerValues";
				text21 = text22;
				string text23 = "";
				MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result = SysSeting.Get();
				string text24 = "";
				string text25 = "";
				if (mobspSelectCrmsysSetting_Result != null)
				{
					text24 = mobspSelectCrmsysSetting_Result.FOUrl ?? "";
					text25 = mobspSelectCrmsysSetting_Result.CrmIPStatic ?? "";
				}
				if (!string.IsNullOrWhiteSpace(text24))
				{
					text23 = text24.Trim();
					if (!text23.Contains("http"))
					{
						text23 = leftPart + text23;
					}
					if (text23.EndsWith("/"))
					{
						text23 = text23.TrimEnd(new char[1] { '/' });
					}
					text23 += "/Survey/Home";
					surveyMainExtrenalLinkLogin = text23;
				}
				if (!string.IsNullOrWhiteSpace(text25))
				{
					text23 = text25.Trim();
					if (!text23.Contains("http"))
					{
						text23 = leftPart + text23;
					}
					if (text23.EndsWith("/"))
					{
						text23 = text23.TrimEnd(new char[1] { '/' });
					}
					text23 += "/Survey/Register/Index";
				}
				int maxFOCount = Mobile.Classes.Configuration.MaxFOCount;
				ObjectParameter objectParameter3 = new ObjectParameter("insertedConversationIds", "");
				ObjectParameter objectParameter4 = new ObjectParameter("errorMessage", "");
				ObjectParameter objectParameter5 = new ObjectParameter("result", 0);
				CRMEntities cRMEntities2 = cRMEntities;
				string conversation = model.Conversation;
				int? userId = model.UserId;
				short? year = value2;
				short? month = value3;
				DateTime? registerDate = value;
				int? languageID = num;
				int? defaultLanguageID = result;
				string needErjaRefmsgSubj = text15;
				string needErjaRefmsgBody = text16;
				string needErjaMultiIntmsgSubject = text19;
				string needErjaMultiIntmsgBody = text20;
				string needSendErjaAllarmRefmsgSubj = text17;
				string needSendErjaAllarmRefmsgBody = text18;
				string msgConversationErjaMultiUser = text2;
				string msgConversationErjaReferDescription = text3;
				ObjectParameter insertedConversationIds = objectParameter3;
				ObjectParameter errorMessage = objectParameter4;
				string type = model.Type;
				string cmpNotAccess = mobCnvsReferUserCmpNotAccess;
				Enumerable.FirstOrDefault<MobspInsertQuickConversation_Result>((IEnumerable<MobspInsertQuickConversation_Result>)cRMEntities2.MobspInsertQuickConversation(conversation, userId, year, month, registerDate, registerDatePersian, appType, languageID, defaultLanguageID, needErjaRefmsgSubj, needErjaRefmsgBody, needErjaMultiIntmsgSubject, needErjaMultiIntmsgBody, needSendErjaAllarmRefmsgSubj, needSendErjaAllarmRefmsgBody, mobConversationErjaShow, msgConversationErjaMultiUser, msgConversationErjaReferDescription, type, insertedConversationIds, errorMessage, objectParameter5, value4, cmpNotAccess, text21, surveyMainExtrenalLink, surveyMainExtrenalLinkLogin, conversationErjaShow, eventErjaRefmsg, model.CenterId, maxFOCount));
				string text26 = "";
				if (objectParameter4.Value != null)
				{
					if (objectParameter4.Value.ToString() != "")
					{
						string text27 = objectParameter4.Value.ToString();
						text27 = text27.Replace("|Msg=0", "<CMP>" + Messages.MobMsgErrorInsertCompany + "<\\CMP>");
						text27 = text27.Replace("Msg=1", "<CMP>" + Messages.MobMsgErrorInconsistencyInCompanySelection + "<\\CMP>");
						text27 = text27.Replace("Msg=2", "<PRS>" + Messages.MobMsgErrorInsertPersons + "<\\PRS>");
						text27 = text27.Replace("Msg=3", "<PRS>" + Messages.MobMsgErrorInsertPerson + "<\\PRS>");
						text27 = text27.Replace("Msg=4", "<PRJ>" + Messages.MobMsgErrorInsertProjects + "<\\PRJ>");
						text27 = text27.Replace("Msg=5", "<PRJ>" + Messages.MobMsgErrorInsertProject + "<\\PRJ>");
						text27 = text27.Replace("Msg=6", "<CNVS>" + Messages.MobMsgErrorInsertSms + "<\\CNVS>");
						text27 = text27.Replace("Msg=7", "<CNVS>" + Messages.MobMsgErrorInsertConversation + "<\\CNVS>");
						text27 = text27.Replace("Dup=1Msg=0", "<CMP>" + Messages.MobMsgErrorNotInsertDuplicateCompany + "<\\CMP>");
						insertPrjAndCnvsForLoginViewModel.ErrorMessage = text27;
						text26 = objectParameter4.Value.ToString();
						if (text26.IndexOf("|Msg=CompanyAccess|", StringComparison.Ordinal) >= 0 || text26.IndexOf("|Msg=PrjAccess|", StringComparison.Ordinal) >= 0)
						{
							text26 = text26.Replace("|Msg=0", "").Replace("Msg=1", "").Replace("Msg=2", "")
								.Replace("Msg=3", "")
								.Replace("Msg=4", "")
								.Replace("Msg=5", "")
								.Replace("Msg=6", "")
								.Replace("Msg=7", "")
								.Replace("Dup=1Msg=0", "");
							if (text26.IndexOf("|Msg=CompanyAccess|", StringComparison.Ordinal) >= 0)
							{
								string[] array7 = text26.Split(new string[1] { "|Msg=CompanyAccess|" }, StringSplitOptions.None);
								if (array7 != null && Enumerable.Count<string>((IEnumerable<string>)array7) == 3)
								{
									if (!string.IsNullOrEmpty(array7[1]))
									{
										string[] array8 = array7[1].Split(new string[1] { "|CNVSID|" }, StringSplitOptions.None);
										if (array8 != null && Enumerable.Count<string>((IEnumerable<string>)array8) == 2)
										{
											string text28 = string.Format(Messages.MobMsgErrorrNotAccessToCompany, array8[1]);
											string newValue5 = "<CNVS><CNVSID>" + array8[0] + "<\\CNVSID><CNVSCOMPANY>" + text28 + "<\\CNVSCOMPANY><\\CNVS>";
											text26 = text26.Replace("|Msg=CompanyAccess|" + array7[1] + "|Msg=CompanyAccess|", newValue5);
										}
									}
								}
								else if (array7 != null && Enumerable.Count<string>((IEnumerable<string>)array7) > 3)
								{
									for (int k = 1; k < Enumerable.Count<string>((IEnumerable<string>)array7); k++)
									{
										if (!string.IsNullOrEmpty(array7[k]))
										{
											string[] array9 = array7[k].Split(new string[1] { "|CNVSID|" }, StringSplitOptions.None);
											if (array9 != null && Enumerable.Count<string>((IEnumerable<string>)array9) == 2)
											{
												string text29 = string.Format(Messages.MobMsgErrorrNotAccessToCompany, array9[1]);
												string newValue6 = "<CNVS><CNVSID>" + array9[0] + "<\\CNVSID><CNVSCOMPANY>" + text29 + "<\\CNVSCOMPANY><\\CNVS>";
												text26 = text26.Replace("|Msg=CompanyAccess|" + array7[k] + "|Msg=CompanyAccess|", newValue6);
											}
										}
									}
								}
							}
							if (text26.IndexOf("|Msg=PrjAccess|", StringComparison.Ordinal) >= 0)
							{
								string[] array10 = text26.Split(new string[1] { "|Msg=PrjAccess|" }, StringSplitOptions.None);
								if (array10 != null && Enumerable.Count<string>((IEnumerable<string>)array10) == 3)
								{
									if (!string.IsNullOrEmpty(array10[1]))
									{
										string[] array11 = array10[1].Split(new string[1] { "|CNVSID|" }, StringSplitOptions.None);
										if (array11 != null && Enumerable.Count<string>((IEnumerable<string>)array11) == 2)
										{
											string text30 = string.Format(Messages.MobMsgErrorrNotAccessToProject, array11[1]);
											string newValue7 = "<CNVS><CNVSID>" + array11[0] + "<\\CNVSID><CNVSPROJECT>" + text30 + "<\\CNVSPROJECT><\\CNVS>";
											text26 = text26.Replace("|Msg=PrjAccess|" + array10[1] + "|Msg=PrjAccess|", newValue7);
										}
									}
								}
								else if (array10 != null && Enumerable.Count<string>((IEnumerable<string>)array10) > 3)
								{
									for (int l = 1; l < Enumerable.Count<string>((IEnumerable<string>)array10); l++)
									{
										if (!string.IsNullOrEmpty(array10[l]))
										{
											string[] array12 = array10[l].Split(new string[1] { "|CNVSID|" }, StringSplitOptions.None);
											if (array12 != null && Enumerable.Count<string>((IEnumerable<string>)array12) == 2)
											{
												string text31 = string.Format(Messages.MobMsgErrorrNotAccessToProject, array12[1]);
												string newValue8 = "<CNVS><CNVSID>" + array12[0] + "<\\CNVSID><CNVSPROJECT>" + text31 + "<\\CNVSPROJECT><\\CNVS>";
												text26 = text26.Replace("|Msg=PrjAccess|" + array10[l] + "|Msg=PrjAccess|", newValue8);
											}
										}
									}
								}
							}
							insertPrjAndCnvsForLoginViewModel.ErrorMessage = text26;
						}
						else if (text26.IndexOf("PreChckErrs", StringComparison.Ordinal) >= 0)
						{
							string text32 = "";
							string[] array13 = text26.Split(new string[1] { "|^|" }, StringSplitOptions.None);
							foreach (string text33 in array13)
							{
								if (!string.IsNullOrEmpty(text33))
								{
									string[] array14 = text33.Split(new char[1] { ',' });
									if (array14[0] == "@StatusResCheckNeedDyFormChecked=PreChckErrs")
									{
										string arg = array14[1].Replace("@FormName=", "") ?? "";
										string arg2 = array14[2].Replace("@DyFormNumber=", "") ?? "";
										text32 += string.Format(Messages.MobMsgErrorNotSaveCnvsBeforeDyFormChecked, arg, arg2);
									}
									else if (array14[0] == "@StatusResCheckNoCnvsDup=PreChckErrs")
									{
										string arg3 = array14[1].Replace("@cnvsDate=", "") ?? "";
										string arg4 = array14[2].Replace("@cnvsStatus=", "") ?? "";
										string arg5 = array14[3].Replace("@cnvsStatusResult=", "") ?? "";
										text32 += string.Format(Messages.MobMsgErrorNoDupCnvsInStatusResult, arg3, arg4, arg5);
									}
									else if (array14[0] == "@StatusResCheckCnvsCountLimit=PreChckErrs")
									{
										string arg6 = array14[1].Replace("@ResultTitle=", "") ?? "";
										string arg7 = array14[2].Replace("@cnvsCountLimit=", "") ?? "";
										text32 += string.Format(Messages.MobMsgErrorCnvsCountLimitInStatusResult, arg6, arg7);
									}
									else if (array14[0] == "@StatusResCheckCnvsDoingTimeLimit=PreChckErrs")
									{
										string arg8 = array14[1].Replace("@ResultTitle=", "") ?? "";
										string arg9 = array14[2].Replace("@cnvsDoingTimeLimit=", "") ?? "";
										text32 += string.Format(Messages.MobMsgErrorCnvsDoingTimeLimitInStatusResult, arg8, arg9);
									}
									else if (array14[0] == "@StatusCheckNoOrderStatus=PreChckErrs")
									{
										string arg10 = array14[1].Replace("@Status=", "") ?? "";
										text32 += string.Format(Messages.MobMsgErrorNoRegCnvsOlderStatus, arg10);
									}
									else if (array14[0] == "@StatusCheckCnvsCountLimit=PreChckErrs")
									{
										string arg11 = array14[1].Replace("@Status=", "") ?? "";
										string arg12 = array14[2].Replace("@cnvsCountLimit=", "") ?? "";
										text32 += string.Format(Messages.MobMsgErrorCnvsCountLimitInStatus, arg11, arg12);
									}
									else if (array14[0] == "@StatusCheckCnvsDoingTimeLimit=PreChckErrs")
									{
										string arg13 = array14[1].Replace("@Status=", "") ?? "";
										string arg14 = array14[2].Replace("@cnvsDoingTimeLimit=", "") ?? "";
										text32 += string.Format(Messages.MobMsgErrorCnvsDoingTimeLimitInStatus, arg13, arg14);
									}
									else if (array14[0] == "@StatusResCheckUsedUserIds=PreChckErrs")
									{
										text32 += string.Format(Messages.MobMsgErrorCanNotSaveCnvsInResult);
									}
									else if (array14[0] == "@StatusCheckUsedUserIds=PreChckErrs")
									{
										text32 += string.Format(Messages.MobMsgErrorCanNotSaveCnvsInStatus);
									}
									else if (array14[0] == "@StatusResCheckNeedDyFormCheckedNotExist=PreChckErrs")
									{
										string text34 = array14[1].Replace("@NeedDyFormCheckedForm=", "") ?? "";
										text32 += string.Format(Messages.MobMsgErrorNotSaveCnvsBeforeInsertDyFormFromCmp, text34 ?? "");
									}
								}
							}
							insertPrjAndCnvsForLoginViewModel.ErrorMessage = text32;
						}
						else
						{
							text26 = "";
						}
					}
					else
					{
						insertPrjAndCnvsForLoginViewModel.ErrorMessage = "";
					}
				}
				if (objectParameter3.Value != null)
				{
					PushNotif.NewIntMsgNotify(withthread: true, model.CenterId);
					string text35 = objectParameter3.Value.ToString();
					string s2 = text35.Substring(text35.IndexOf(",") + 1, text35.IndexOf("|") - 2) ?? "0";
					insertPrjAndCnvsForLoginViewModel.ConversationId = int.Parse(s2);
					text = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					insertPrjAndCnvsForLoginViewModel.ConversationId = 0;
				}
				if (objectParameter5.Value == null)
				{
					text = insertPrjAndCnvsForLoginViewModel.ErrorMessage ?? Messages.MobMsgErrorDoneOperation;
					status = ServiceResultStatus.Fail;
					return new ServiceResult<InsertPrjAndCnvsForLoginViewModel>
					{
						Message = text,
						Data = null,
						Status = ServiceResultStatus.Fail
					};
				}
				if (!(objectParameter5.Value.ToString() == "1"))
				{
					text = Messages.MobMsgErrorDoneOperation;
					status = ServiceResultStatus.Fail;
					return new ServiceResult<InsertPrjAndCnvsForLoginViewModel>
					{
						Message = text,
						Data = null,
						Status = ServiceResultStatus.Fail
					};
				}
				if (!string.IsNullOrEmpty(insertPrjAndCnvsForLoginViewModel.ErrorMessage))
				{
					text = insertPrjAndCnvsForLoginViewModel.ErrorMessage;
					status = ServiceResultStatus.Fail;
					return new ServiceResult<InsertPrjAndCnvsForLoginViewModel>
					{
						Message = text,
						Data = null,
						Status = ServiceResultStatus.Fail
					};
				}
			}
		}
		catch (Exception e)
		{
			text = insertPrjAndCnvsForLoginViewModel.ErrorMessage ?? Messages.MobMsgErrorDoneOperation;
			insertPrjAndCnvsForLoginViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<InsertPrjAndCnvsForLoginViewModel>
		{
			Message = text,
			Data = insertPrjAndCnvsForLoginViewModel,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<InsertOrderFullViewModel> InsertQuickOrderItem(InsertOrderFullViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		InsertOrderFullViewModel data = null;
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
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					DateTime now = DateTime.Now;
					_ = Labels.MobPersonLabel;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(Financial.Get().Id.ToString());
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					_ = Messages.MobConversationErjaShow;
					string appType = Mobile.Classes.Configuration.AppType;
					bool value4 = UserLogin.IsUserAccess("frmOrderItemDataEntry", "actCanNotSelectWithNoStockInOrd", UserLogin.CurrentUser, model.CenterId);
					bool value5 = UserLogin.IsUserAccess("frmOrderItemDataEntry", "actCanNotSelectWithNoReserveStockInOrd", UserLogin.CurrentUser, model.CenterId);
					bool value6 = UserLogin.IsUserAccess("frmOrderItemDataEntry", "actCanNotSelectWithNoSoldStockInOrd", UserLogin.CurrentUser, model.CenterId);
					if (0 == 0)
					{
						ObjectParameter objectParameter = new ObjectParameter("InsertedOrdItemId", "");
						ObjectParameter objectParameter2 = new ObjectParameter("ErrorMessage", "");
						int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspInsertQuickOrderItem(model.OrdItemList, value, registerDatePersian, token2.userId, value3, value2, appType, result, result2, value4, model.AddLinkedProducts, objectParameter, objectParameter2, model.CenterId, model.haveLinkAccQtyCheck, value5, value6));
						InsertOrderFullViewModel insertOrderFullViewModel = new InsertOrderFullViewModel();
						if (objectParameter2.Value != null)
						{
							if (objectParameter2.Value.ToString() != "")
							{
								string text = objectParameter2.Value.ToString();
								text = text.Replace("|Msg=0", Messages.MobMsgErrorInsertPreOrder);
								text = text.Replace("Msg=1", Messages.MobMsgErrorInconsistencyInPordSelection);
								text = text.Replace("Msg=5", Messages.MobMsgProductLackOfStock);
								text = text.Replace("Msg=6", Messages.MobMsgProductLackOfReserveStock);
								text = text.Replace("Msg=7", Messages.MobMsgProductLackOfSoldStock);
								text = text.Replace("Msg=2", Messages.MobMsgErrorInsertProduct);
								text = text.Replace("Msg=3", Messages.MobMsgErrorInsertProductSpcf);
								insertOrderFullViewModel.ErrorMessage = text;
							}
							else
							{
								insertOrderFullViewModel.ErrorMessage = "";
							}
						}
						insertOrderFullViewModel.OrdPaymentList = "0";
						insertOrderFullViewModel.Order = "0";
						if (objectParameter.Value != null)
						{
							insertOrderFullViewModel.OrdItemList = objectParameter.Value.ToString() ?? "0";
						}
						else
						{
							insertOrderFullViewModel.OrdItemList = "0";
						}
						if (!num.HasValue || num >= 1)
						{
							if (!string.IsNullOrEmpty(insertOrderFullViewModel.ErrorMessage))
							{
								data = insertOrderFullViewModel;
								message = insertOrderFullViewModel.ErrorMessage;
								status = ServiceResultStatus.Fail;
							}
							else
							{
								data = insertOrderFullViewModel;
								message = Messages.MobMsgSuccessAction;
								status = ServiceResultStatus.Success;
							}
						}
						else
						{
							data = insertOrderFullViewModel;
							message = Messages.MobMsgErrorDoneOperation;
							status = ServiceResultStatus.Fail;
						}
					}
					else
					{
						data = null;
						message = Messages.MobMsgErrorDoneOperation;
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
		return new ServiceResult<InsertOrderFullViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<InsertOrderFullViewModel> InsertQuickOrderPayment(InsertOrderFullViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		InsertOrderFullViewModel data = null;
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
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					DateTime now = DateTime.Now;
					_ = Labels.MobPersonLabel;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(Financial.Get().Id.ToString());
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					_ = Messages.MobConversationErjaShow;
					string appType = Mobile.Classes.Configuration.AppType;
					if (0 == 0)
					{
						ObjectParameter objectParameter = new ObjectParameter("InsertedOrdPaymentId", "");
						ObjectParameter objectParameter2 = new ObjectParameter("ErrorMessage", "");
						int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspInsertQuickOrderPayment(model.OrdPaymentList, value, registerDatePersian, token2.userId, value3, value2, appType, result, result2, objectParameter, objectParameter2, model.CenterId));
						InsertOrderFullViewModel insertOrderFullViewModel = new InsertOrderFullViewModel();
						if (objectParameter2.Value != null)
						{
							if (objectParameter2.Value.ToString() != "")
							{
								string text = objectParameter2.Value.ToString();
								text = text.Replace("|Msg=0", Messages.MobMsgErrorInsertPreOrder);
								text = text.Replace("|pordNumberIsDup", Messages.MobMsgPreOrderNumberIsRepeated);
								text = text.Replace("Msg=1", Messages.MobMsgErrorInconsistencyInPordSelection);
								text = text.Replace("Msg=5", Messages.MobMsgProductLackOfStock);
								text = text.Replace("Msg=2", Messages.MobMsgErrorInsertProduct);
								text = text.Replace("Msg=3", Messages.MobMsgErrorInsertProductSpcf);
								insertOrderFullViewModel.ErrorMessage = text;
							}
							else
							{
								insertOrderFullViewModel.ErrorMessage = "";
							}
						}
						insertOrderFullViewModel.OrdItemList = "0";
						insertOrderFullViewModel.Order = "0";
						if (objectParameter.Value != null)
						{
							insertOrderFullViewModel.OrdPaymentList = objectParameter.Value.ToString() ?? "0";
						}
						else
						{
							insertOrderFullViewModel.OrdPaymentList = "0";
						}
						if (!num.HasValue || num >= 1)
						{
							if (!string.IsNullOrEmpty(insertOrderFullViewModel.ErrorMessage))
							{
								data = insertOrderFullViewModel;
								message = insertOrderFullViewModel.ErrorMessage;
								status = ServiceResultStatus.Fail;
							}
							else
							{
								string[] array = insertOrderFullViewModel.OrdPaymentList.Split(new char[1] { '|' });
								foreach (string text2 in array)
								{
									if (string.IsNullOrEmpty(text2))
									{
										continue;
									}
									string[] array2 = text2.Split(new char[1] { ',' });
									if (array2.Length > 1)
									{
										int result3 = 0;
										int.TryParse(array2[1], out result3);
										if (result3 > 0)
										{
											Order.PaymentMoneyBag(result3, 0, result, model.CenterId);
										}
									}
								}
								data = insertOrderFullViewModel;
								message = Messages.MobMsgSuccessAction;
								status = ServiceResultStatus.Success;
							}
						}
						else
						{
							data = insertOrderFullViewModel;
							message = Messages.MobMsgErrorDoneOperation;
							status = ServiceResultStatus.Fail;
						}
					}
					else
					{
						data = null;
						message = Messages.MobMsgErrorDoneOperation;
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
		return new ServiceResult<InsertOrderFullViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> InsertQuickDocItemSerial(InsertQuickDocItemSerialViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
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
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMSpEntities = new CRMSpEntities();
					DateTime now = DateTime.Now;
					_ = Labels.MobPersonLabel;
					DateTime value = now;
					string text = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					_ = Messages.MobConversationErjaShow;
					string appType = Mobile.Classes.Configuration.AppType;
					int id = Financial.Get().Id;
					if (0 == 0)
					{
						ObjectParameter objectParameter = new ObjectParameter("ResInsertedDocItemSerialIds", "");
						ObjectParameter objectParameter2 = new ObjectParameter("ResErrorMessage", "");
						CRMSpEntities cRMSpEntities2 = cRMSpEntities;
						string docItemSerialParams = model.DocItemSerialParams;
						DateTime? registerDate = value;
						string registerDatePersian = text;
						int? userId = token2.userId;
						short? month = value2;
						int? fPId = id;
						int? languageID = result;
						int? defaultLanguageID = result2;
						ObjectParameter resInsertedDocItemSerialIds = objectParameter;
						Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpEntities2.MobspInsertQuickDocItemSerial(docItemSerialParams, userId, fPId, month, registerDate, registerDatePersian, appType, languageID, defaultLanguageID, objectParameter2, resInsertedDocItemSerialIds));
						if (!string.IsNullOrEmpty(objectParameter2.Value?.ToString()))
						{
							string text2 = "";
							string[] array = objectParameter2.Value.ToString().Split(new string[1] { "#|^|#" }, StringSplitOptions.None);
							string[] array2 = array;
							foreach (string text3 in array2)
							{
								if (string.IsNullOrEmpty(text3))
								{
									continue;
								}
								string[] array3 = text3.Split(new string[1] { "|^|" }, StringSplitOptions.None);
								switch (array3[0])
								{
								case "ParseData=Error":
									text2 = Messages.MobMsgErrorInSentData;
									break;
								case "Serial=Dup":
								{
									string arg = "";
									if (array3.Length > 1)
									{
										arg = array3[1].Replace("DocNumber=", "") ?? "";
									}
									text2 = string.Format(Messages.msgSerialNumberDuplicateInDraft, arg);
									string text4 = "";
									if (array3.Length > 2)
									{
										text4 = array3[2].Replace("Serial=", "") ?? "";
									}
									if (!string.IsNullOrEmpty(text4))
									{
										text2 = text2 + Labels.lblSerialNumber + ": " + text4;
									}
									break;
								}
								case "Error":
									text2 = Messages.MobMsgErrorSubmitDraftItemSerial;
									break;
								}
							}
							if (string.IsNullOrEmpty(text2))
							{
								text2 = array[0];
							}
							message = text2;
							status = ServiceResultStatus.Fail;
						}
						else
						{
							data = null;
							message = Messages.MobMsgSuccessAction;
							status = ServiceResultStatus.Success;
						}
					}
					else
					{
						data = null;
						message = Messages.MobMsgErrorDoneOperation;
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
			cRMSpEntities?.Dispose();
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
	public ServiceResult<InsertQuickDocItemResultViewModel> InsertQuickDocItem(InsertQuickDocItemViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		InsertQuickDocItemResultViewModel insertQuickDocItemResultViewModel = null;
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
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMSpEntities = new CRMSpEntities();
					DateTime now = DateTime.Now;
					_ = Labels.MobPersonLabel;
					DateTime value = now;
					string text = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					_ = Messages.MobConversationErjaShow;
					string appType = Mobile.Classes.Configuration.AppType;
					int id = Financial.Get().Id;
					string prdStockTxt = Labels.PrdStockTxt;
					if (0 == 0)
					{
						ObjectParameter objectParameter = new ObjectParameter("ResInsertedDocItemIds", "");
						ObjectParameter objectParameter2 = new ObjectParameter("ResErrorMessage", "");
						ObjectParameter objectParameter3 = new ObjectParameter("ResLinkedErrorMessage", "");
						CRMSpEntities cRMSpEntities2 = cRMSpEntities;
						string docItemParams = model.DocItemParams;
						DateTime? registerDate = value;
						string registerDatePersian = text;
						int? userId = token2.userId;
						short? month = value2;
						int? fPId = id;
						int? languageID = result;
						int? defaultLanguageID = result2;
						ObjectParameter resInsertedDocItemIds = objectParameter;
						Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpEntities2.MobspInsertQuickDocItem(docItemParams, userId, fPId, month, registerDate, registerDatePersian, appType, languageID, defaultLanguageID, prdStockTxt, objectParameter2, resInsertedDocItemIds, objectParameter3, model.CenterId));
						if (!string.IsNullOrEmpty(objectParameter2.Value?.ToString()))
						{
							string text2 = "";
							string[] array = objectParameter2.Value.ToString().Split(new string[1] { "#|^|#" }, StringSplitOptions.None);
							string[] array2 = array;
							foreach (string text3 in array2)
							{
								if (string.IsNullOrEmpty(text3))
								{
									continue;
								}
								string[] array3 = text3.Split(new string[1] { "|^|" }, StringSplitOptions.None);
								switch (array3[0])
								{
								case "ParseData=Error":
									text2 = Messages.MobMsgErrorInSentData;
									break;
								case "Tracing=Force":
								{
									text2 = Messages.MobMsgErrorTracingIsNotSpecified;
									string text5 = "";
									if (array3.Length > 1)
									{
										string s2 = array3[1].Replace("PrdId=", "") ?? "";
										int result4 = 0;
										int.TryParse(s2, out result4);
										if (result4 > 0)
										{
											MobspSelectProductsWithId_Result mobspSelectProductsWithId_Result2 = Enumerable.FirstOrDefault<MobspSelectProductsWithId_Result>((IEnumerable<MobspSelectProductsWithId_Result>)cRMSpEntities.MobspSelectProductsWithId(result4, result, result2));
											if (mobspSelectProductsWithId_Result2 != null)
											{
												text5 = mobspSelectProductsWithId_Result2.PrdName ?? "";
											}
										}
									}
									if (!string.IsNullOrEmpty(text5))
									{
										text2 = text2 + Labels.lblProduct + ": " + text5;
									}
									break;
								}
								case "Tracing=New":
								{
									string arg = "";
									if (array3.Length > 1)
									{
										arg = array3[1].Replace("NewTracing=", "") ?? "";
									}
									text2 = string.Format(Messages.MobMsgErrorCanNotAddNewTracingCode, arg);
									string text6 = "";
									if (array3.Length > 2)
									{
										string s3 = array3[2].Replace("PrdId=", "") ?? "";
										int result5 = 0;
										int.TryParse(s3, out result5);
										if (result5 > 0)
										{
											MobspSelectProductsWithId_Result mobspSelectProductsWithId_Result3 = Enumerable.FirstOrDefault<MobspSelectProductsWithId_Result>((IEnumerable<MobspSelectProductsWithId_Result>)cRMSpEntities.MobspSelectProductsWithId(result5, result, result2));
											if (mobspSelectProductsWithId_Result3 != null)
											{
												text6 = mobspSelectProductsWithId_Result3.PrdName ?? "";
											}
										}
									}
									if (!string.IsNullOrEmpty(text6))
									{
										text2 = text2 + Labels.lblProduct + ": " + text6;
									}
									break;
								}
								case "QtyRemainLimit":
								{
									string text4 = "";
									if (array3.Length > 1)
									{
										string s = array3[1].Replace("PrdId=", "") ?? "";
										int result3 = 0;
										int.TryParse(s, out result3);
										if (result3 > 0)
										{
											MobspSelectProductsWithId_Result mobspSelectProductsWithId_Result = Enumerable.FirstOrDefault<MobspSelectProductsWithId_Result>((IEnumerable<MobspSelectProductsWithId_Result>)cRMSpEntities.MobspSelectProductsWithId(result3, result, result2));
											if (mobspSelectProductsWithId_Result != null)
											{
												text4 = mobspSelectProductsWithId_Result.PrdName ?? "";
											}
										}
									}
									if (string.IsNullOrEmpty(text4))
									{
										text4 = Labels.lblSelected;
									}
									text2 = string.Format(Messages.MobMsgDraftQuantityRemainLimitExceededI, text4);
									break;
								}
								case "Error":
									text2 = Messages.MobMsgErrorSubmitDraftItem;
									break;
								}
							}
							if (string.IsNullOrEmpty(text2))
							{
								text2 = array[0];
							}
							message = text2;
							status = ServiceResultStatus.Fail;
						}
						else
						{
							insertQuickDocItemResultViewModel = new InsertQuickDocItemResultViewModel();
							insertQuickDocItemResultViewModel.InsertedIds = objectParameter.Value?.ToString();
							if (!string.IsNullOrEmpty(objectParameter3.Value?.ToString()))
							{
								string text7 = "";
								string text8 = "";
								string[] array2 = objectParameter3.Value.ToString().Split(new string[1] { "#|^|#" }, StringSplitOptions.None);
								foreach (string text9 in array2)
								{
									if (string.IsNullOrEmpty(text9))
									{
										continue;
									}
									string[] array4 = text9.Split(new string[1] { "|^|" }, StringSplitOptions.None);
									if (array4.Length != 0)
									{
										string s4 = array4[0].Replace("InsertId=", "") ?? "";
										int result6 = 0;
										int.TryParse(s4, out result6);
										if (result6 > 0)
										{
											text8 = ((!string.IsNullOrEmpty(text8)) ? ("," + result6) : result6.ToString());
										}
										string text10 = array4[1].Replace("MSG=", "") ?? "";
										if (!string.IsNullOrEmpty(text10))
										{
											text7 = ((!string.IsNullOrEmpty(text7)) ? (text7 + "\n" + text10) : text10);
										}
									}
								}
								insertQuickDocItemResultViewModel.InsertLinkedIds = text8;
								insertQuickDocItemResultViewModel.InsertLinkedErrorMessage = Messages.frmFormBaseInsertSuccessFulMessage + "\r\n" + Messages.msgErrorNotAddedLinkedPrdWithoutStockToDocItem + "\r\n" + text7 + "\r\n" + Messages.msgAddPrdWithMinStockInDoc;
							}
							message = Messages.MobMsgSuccessAction;
							status = ServiceResultStatus.Success;
						}
					}
					else
					{
						insertQuickDocItemResultViewModel = null;
						message = Messages.MobMsgErrorDoneOperation;
						status = ServiceResultStatus.Error;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					insertQuickDocItemResultViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				insertQuickDocItemResultViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			insertQuickDocItemResultViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<InsertQuickDocItemResultViewModel>
		{
			Message = message,
			Data = insertQuickDocItemResultViewModel,
			Status = status
		};
	}

	public DublicatePrjCnvsInsetData InsertQuickPrjCnvsForDuplicate(string companyId, string personId, string Company, string Persons, string Projects, string Conversations, int userId, int LangId, int defLangId, int? centerId = null)
	{
		DublicatePrjCnvsInsetData dublicatePrjCnvsInsetData = new DublicatePrjCnvsInsetData();
		dublicatePrjCnvsInsetData.OutputRes = false;
		try
		{
			int value = 0;
			try
			{
				value = int.Parse(companyId);
			}
			catch (Exception)
			{
			}
			int? companyPersonId = null;
			try
			{
				companyPersonId = int.Parse(personId);
			}
			catch (Exception)
			{
			}
			ObjectParameter objectParameter = new ObjectParameter("InsertedPersonIds", "");
			ObjectParameter objectParameter2 = new ObjectParameter("InsertedProjectIds", "");
			ObjectParameter objectParameter3 = new ObjectParameter("InsertedConversationIds", "");
			ObjectParameter errorMessage = new ObjectParameter("errorMessage", "");
			DateTime now = DateTime.Now;
			_ = Labels.MobPersonLabel;
			DateTime value2 = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value3 = short.Parse(Financial.Get().Id.ToString());
			short value4 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Messages.MobConversationErjaShow;
			string appType = Mobile.Classes.Configuration.AppType;
			Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)new CRMEntities().MobspInsertQuickPrjCnvsForDuplicate(value, companyPersonId, Company, Persons, Projects, Conversations, userId, value3, value4, value2, registerDatePersian, appType, LangId, defLangId, errorMessage, objectParameter, objectParameter2, objectParameter3, centerId));
			if (objectParameter3.Value != null && !string.IsNullOrWhiteSpace(objectParameter3.Value.ToString()))
			{
				string[] array = objectParameter3.Value.ToString().Split(new char[1] { '|' });
				if (array.Length != 0 && !string.IsNullOrEmpty(array[0]))
				{
					string[] array2 = array[0].Split(new char[1] { ',' });
					if (array2.Length != 0)
					{
						string text = array2[1];
						if (!string.IsNullOrEmpty(text))
						{
							int result = 0;
							int.TryParse(text, out result);
							if (result > 0)
							{
								dublicatePrjCnvsInsetData.OutputRes = true;
							}
						}
					}
				}
			}
			dublicatePrjCnvsInsetData.Project = objectParameter2.Value.ToString();
			dublicatePrjCnvsInsetData.Conversation = objectParameter3.Value.ToString();
			dublicatePrjCnvsInsetData.PersonId = objectParameter.Value.ToString();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return dublicatePrjCnvsInsetData;
	}
}

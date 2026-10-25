using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Web.Http;
using CRM.General.Calendar;
using CRM.Resources;
using Elmah;
using GSD.Globalization;
using Mobile.Cache.Setting;
using Mobile.Classes;
using Mobile.Classes.Helper;
using Mobile.DataType;
using Mobile.Models;
using Mobile.Models.WareHouse;

namespace Mobile.Controllers;

public class UpdateController : ApiController
{
	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> Company(UpdateCompanyViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
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
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					string text = "";
					int num = 0;
					int num2 = 0;
					if (UserLogin.IsUserAccess("frmCompanyI", "actNotCanEditNoReferUserCmp", UserLogin.CurrentUser, model.CenterId) && model.CmpReferUserId != token2.userId)
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgNotCanEditCmpWithoutBeReferUser,
							Data = model.CompanyId,
							Status = ServiceResultStatus.Fail
						};
					}
					_ = DateTime.Now;
					string mobPersonLabel = Labels.MobPersonLabel;
					string mobLackOfShowText = Labels.MobLackOfShowText;
					short value = short.Parse(Financial.Get().Id.ToString());
					string appType = Mobile.Classes.Configuration.AppType;
					bool haveEroroFoCnt = false;
					int referUId = 0;
					if (UserLogin.IsUserAccess("frmCompanyI", "actCanChangeReferUser", UserLogin.CurrentUser))
					{
						referUId = model.CmpReferUserId;
					}
					string foInfoJson = Mobile.Classes.Helper.Company.GetFoInfoJson(model.OldCmpfoInfo, model.OldCmpfoInfo, model.CIds, ref haveEroroFoCnt, token2.userId, model.CenterId.GetValueOrDefault(), isCmp: true, referUId, model.CmpSuppUserId.GetValueOrDefault(), model.OldCmpReferUserId);
					model.Company = model.Company.Replace("{cmpFOInfo}", foInfoJson);
					ObjectParameter objectParameter = new ObjectParameter("updatedCompanyId", 0);
					ObjectParameter objectParameter2 = new ObjectParameter("errorMessage", "");
					CRMEntities cRMEntities2 = cRMEntities;
					int? companyId = model.CompanyId;
					string company = model.Company;
					string personLabel = mobPersonLabel;
					int? userId = token2.userId;
					short? year = value;
					int? languageID = result;
					int? defaultLanguageID = result2;
					ObjectParameter updatedCompanyId = objectParameter;
					ObjectParameter errorMessage = objectParameter2;
					int? num3 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities2.MobspUpdateCompany(companyId, company, userId, year, appType, languageID, defaultLanguageID, personLabel, mobLackOfShowText, updatedCompanyId, errorMessage, model.CenterId));
					if (objectParameter2.Value != null)
					{
						if (objectParameter2.Value.ToString() != "")
						{
							string text2 = objectParameter2.Value.ToString();
							text = objectParameter2.Value.ToString();
							if (text.IndexOf("|Msg=0", StringComparison.Ordinal) >= 0)
							{
								text = "<CMP>" + Messages.MobMsgErrorIsNotCompany + "<\\CMP>";
								num++;
							}
							else
							{
								text2 = text2.Replace("|Msg=0", "");
								if (text2.IndexOf("@cmpName=IsNull", StringComparison.Ordinal) >= 0)
								{
									text = "<CMP>" + Messages.MobMsgErrorCmpNameNotEntered + "<\\CMP>";
									num++;
								}
								if (text2.IndexOf("@cmpName=Dup", StringComparison.Ordinal) >= 0 || text2.IndexOf("@cmpCode=Dup", StringComparison.Ordinal) >= 0 || text2.IndexOf("@cmpTel=Dup", StringComparison.Ordinal) >= 0 || text2.IndexOf("@cmpTelII=Dup", StringComparison.Ordinal) >= 0 || text2.IndexOf("@cmpFax=Dup", StringComparison.Ordinal) >= 0 || text2.IndexOf("@cmpZipCode=Dup", StringComparison.Ordinal) >= 0 || text2.IndexOf("@cmpNationalCode=Dup", StringComparison.Ordinal) >= 0 || text2.IndexOf("@cmpEconomicCode=Dup", StringComparison.Ordinal) >= 0 || text2.IndexOf("@cmpEmail=Dup", StringComparison.Ordinal) >= 0 || text2.IndexOf("@cmpMobile=Dup", StringComparison.Ordinal) >= 0)
								{
									string text3 = "";
									string text4 = text2.Substring(text2.IndexOf("@cmpName=Dup", StringComparison.Ordinal));
									if (text4 != null && text4 != "")
									{
										string[] array = text4.Split(new string[1] { "|^|" }, StringSplitOptions.None);
										foreach (string text5 in array)
										{
											if (!string.IsNullOrEmpty(text5))
											{
												string[] array2 = text5.Split(new char[1] { ',' });
												string text6 = array2[3].Replace("@DupCmpName=", "") ?? "";
												string text7 = array2[2].Replace("@DupCmpTitle=", "") ?? "";
												string text8 = array2[4].Replace("@DupCmpCity=", "") ?? "";
												string text9 = array2[5].Replace("@DupCmpNumber=", "") ?? "";
												if (array2[0] == "@cmpName=Dup")
												{
													text3 = text3 + "<CMP>" + string.Format(Messages.MobMsgErrorCheckCmpNameDuplicate, text6, text7, text8, text9) + "<\\CMP>";
												}
												else if (array2[0] == "@cmpCode=Dup")
												{
													text6 = array2[1].Replace("@cmpName=", "") ?? "";
													text3 = text3 + "<CMP>کد مخاطب تکراری می باشد. این کد قبلا برای مخاطب " + text6 + " درج گردیده است.عدم امکان درج تکراری<\\CMP>";
												}
												else if (array2[0] == "@cmpTel=Dup")
												{
													text6 = array2[1].Replace("@DupCmpName=", "") ?? "";
													text9 = array2[2].Replace("@DupCmpNumber=", "") ?? "";
													text3 = text3 + "<CMP>شماره تلفن تکراری می باشد. این تلفن در مشتری با شماره " + text9 + " و نام " + text6 + " یافت شده است.<\\CMP>";
												}
												else if (array2[0] == "@cmpTelII=Dup")
												{
													text6 = array2[1].Replace("@DupCmpName=", "") ?? "";
													text9 = array2[2].Replace("@DupCmpNumber=", "") ?? "";
													text3 = text3 + "<CMP>شماره تلفن دوم تکراری می باشد. این تلفن در مشتری با شماره " + text9 + " و نام " + text6 + " یافت شده است.<\\CMP>";
												}
												else if (array2[0] == "@cmpFax=Dup")
												{
													text6 = array2[1].Replace("@DupCmpName=", "") ?? "";
													text9 = array2[2].Replace("@DupCmpNumber=", "") ?? "";
													text3 = text3 + "<CMP>شماره فکس تکراری می باشد. این فکس در مشتری با شماره " + text9 + " و نام " + text6 + " یافت شده است.<\\CMP>";
												}
												else if (array2[0] == "@cmpZipCode=Dup")
												{
													text6 = array2[1].Replace("@DupCmpName=", "") ?? "";
													text9 = array2[2].Replace("@DupCmpNumber=", "") ?? "";
													text3 = text3 + "<CMP>کد پستی تکراری می باشد. این کد پستی در مشتری با شماره " + text9 + " و نام " + text6 + " یافت شده است.<\\CMP>";
												}
												else if (array2[0] == "@cmpNationalCode=Dup")
												{
													text6 = array2[1].Replace("@DupCmpName=", "") ?? "";
													text9 = array2[2].Replace("@DupCmpNumber=", "") ?? "";
													text3 = text3 + "<CMP>شناسه ملی تکراری می باشد. این شناسه ملی در مشتری با شماره " + text9 + " و نام " + text6 + " یافت شده است.<\\CMP>";
												}
												else if (array2[0] == "@cmpEconomicCode=Dup")
												{
													text6 = array2[1].Replace("@DupCmpName=", "") ?? "";
													text9 = array2[2].Replace("@DupCmpNumber=", "") ?? "";
													text3 = text3 + "<CMP>کد اقتصادی تکراری می باشد. این کد اقتصادی در مشتری با شماره " + text9 + " و نام " + text6 + " یافت شده است.<\\CMP>";
												}
												else if (array2[0] == "@cmpEmail=Dup")
												{
													text6 = array2[1].Replace("@DupCmpName=", "") ?? "";
													text9 = array2[2].Replace("@DupCmpNumber=", "") ?? "";
													text3 = text3 + "<CMP>ایمیل تکراری می باشد. این ایمیل در مشتری با شماره " + text9 + " و نام " + text6 + " یافت شده است.<\\CMP>";
												}
												else if (array2[0] == "@cmpMobile=Dup")
												{
													text6 = array2[1].Replace("@DupCmpName=", "") ?? "";
													text9 = array2[2].Replace("@DupCmpNumber=", "") ?? "";
													text3 = text3 + "<CMP>شماره موبایل تکراری می باشد. این شماره موبایل در مشتری با شماره " + text9 + " و نام " + text6 + " یافت شده است.<\\CMP>";
												}
											}
										}
									}
									text = text3;
									num++;
								}
								string text10 = text2;
								if (text10.IndexOf("|Msg=CmpGroupIdAccess|", StringComparison.Ordinal) >= 0 || text10.IndexOf("|Msg=CmpSubGroupIdAccess|", StringComparison.Ordinal) >= 0 || text10.IndexOf("|Msg=CmpGroupIdIVAccess|", StringComparison.Ordinal) >= 0 || text10.IndexOf("|Msg=CmpProvinceIdAccess|", StringComparison.Ordinal) >= 0 || text10.IndexOf("|Msg=CmpCityIdAccess|", StringComparison.Ordinal) >= 0 || text10.IndexOf("|Msg=CompanyAccess|", StringComparison.Ordinal) >= 0)
								{
									if (text10.IndexOf("|Msg=CompanyAccess|", StringComparison.Ordinal) >= 0)
									{
										string[] array3 = text10.Split(new string[1] { "|Msg=CompanyAccess|" }, StringSplitOptions.None);
										if (array3 != null && Enumerable.Count<string>((IEnumerable<string>)array3) == 3 && !string.IsNullOrEmpty(array3[1]))
										{
											string newValue = "<CMP>" + string.Format(Messages.MobMsgErrorrNotAccessToCompany, array3[1]) + "<\\CMP>";
											text10 = text10.Replace("|Msg=CompanyAccess|" + array3[1] + "|Msg=CompanyAccess|", newValue);
										}
									}
									if (text10.IndexOf("|Msg=CmpGroupIdAccess|", StringComparison.Ordinal) >= 0)
									{
										string[] array4 = text10.Split(new string[1] { "|Msg=CmpGroupIdAccess|" }, StringSplitOptions.None);
										if (array4 != null && Enumerable.Count<string>((IEnumerable<string>)array4) == 3 && !string.IsNullOrEmpty(array4[1]))
										{
											string newValue2 = "<CMP>" + string.Format(Messages.MobMsgErrorrNotAccessToCmpGroup, array4[1]) + "<\\CMP>";
											text10 = text10.Replace("|Msg=CmpGroupIdAccess|" + array4[1] + "|Msg=CmpGroupIdAccess|", newValue2);
										}
									}
									if (text10.IndexOf("|Msg=CmpSubGroupIdAccess|", StringComparison.Ordinal) >= 0)
									{
										string[] array5 = text10.Split(new string[1] { "|Msg=CmpSubGroupIdAccess|" }, StringSplitOptions.None);
										if (array5 != null && Enumerable.Count<string>((IEnumerable<string>)array5) == 3 && !string.IsNullOrEmpty(array5[1]))
										{
											string newValue3 = "<CMP>" + string.Format(Messages.MobMsgErrorrNotAccessToCmpSubGroup, array5[1]) + "<\\CMP>";
											text10 = text10.Replace("|Msg=CmpSubGroupIdAccess|" + array5[1] + "|Msg=CmpSubGroupIdAccess|", newValue3);
										}
									}
									if (text10.IndexOf("|Msg=CmpGroupIdIVAccess|", StringComparison.Ordinal) >= 0)
									{
										string[] array6 = text10.Split(new string[1] { "|Msg=CmpGroupIdIVAccess|" }, StringSplitOptions.None);
										if (array6 != null && Enumerable.Count<string>((IEnumerable<string>)array6) == 3 && !string.IsNullOrEmpty(array6[1]))
										{
											string newValue4 = "<CMP>" + string.Format(Messages.MobMsgErrorrNotAccessToCmpGroupIV, array6[1]) + "<\\CMP>";
											text10 = text10.Replace("|Msg=CmpGroupIdIVAccess|" + array6[1] + "|Msg=CmpGroupIdIVAccess|", newValue4);
										}
									}
									if (text10.IndexOf("|Msg=CmpProvinceIdAccess|", StringComparison.Ordinal) >= 0)
									{
										string[] array7 = text10.Split(new string[1] { "|Msg=CmpProvinceIdAccess|" }, StringSplitOptions.None);
										if (array7 != null && Enumerable.Count<string>((IEnumerable<string>)array7) == 3 && !string.IsNullOrEmpty(array7[1]))
										{
											string newValue5 = "<CMP>" + string.Format(Messages.MobMsgErrorrNotAccessToProvince, array7[1]) + "<\\CMP>";
											text10 = text10.Replace("|Msg=CmpProvinceIdAccess|" + array7[1] + "|Msg=CmpProvinceIdAccess|", newValue5);
										}
									}
									if (text10.IndexOf("|Msg=CmpCityIdAccess|", StringComparison.Ordinal) >= 0)
									{
										string[] array8 = text10.Split(new string[1] { "|Msg=CmpCityIdAccess|" }, StringSplitOptions.None);
										if (array8 != null && Enumerable.Count<string>((IEnumerable<string>)array8) == 3 && !string.IsNullOrEmpty(array8[1]))
										{
											string newValue6 = "<CMP>" + string.Format(Messages.MobMsgErrorrNotAccessToCity, array8[1]) + "<\\CMP>";
											text10 = text10.Replace("|Msg=CmpCityIdAccess|" + array8[1] + "|Msg=CmpCityIdAccess|", newValue6);
										}
									}
									text = text10;
									num++;
								}
							}
						}
						else
						{
							text = "";
						}
					}
					num2 = ((objectParameter.Value != null) ? ((int)(objectParameter.Value ?? ((object)0))) : 0);
					if (!num3.HasValue || num3 >= 1)
					{
						if (num > 0)
						{
							data = model.CompanyId;
							message = text;
							status = ServiceResultStatus.Fail;
						}
						else
						{
							if (model.DeleteCmpLogo.GetValueOrDefault())
							{
								Enumerable.ToList<int?>((IEnumerable<int?>)cRMEntities.MobspDeleteCompanyLogoByCmpId(model.CompanyId));
							}
							data = num2;
							message = Messages.MobMsgSuccessAction;
							status = ServiceResultStatus.Success;
						}
					}
					else
					{
						data = model.CompanyId;
						message = Messages.MobMsgErrorDoneOperation;
						status = ServiceResultStatus.Fail;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = model.CompanyId;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = model.CompanyId;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = model.CompanyId;
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
	[MobileAuthorize]
	public ServiceResult<int> Person(UpdatePersonViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
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
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					string text = "";
					int num = 0;
					int num2 = 0;
					_ = DateTime.Now;
					_ = Labels.MobPersonLabel;
					short value = short.Parse(Financial.Get().Id.ToString());
					string appType = Mobile.Classes.Configuration.AppType;
					string mobLackOfShowText = Labels.MobLackOfShowText;
					bool haveEroroFoCnt = false;
					string foInfoJson = Mobile.Classes.Helper.Company.GetFoInfoJson(model.OldPrsfoInfo, model.OldPrsfoInfo, model.CIds, ref haveEroroFoCnt, token2.userId, model.CenterId.GetValueOrDefault());
					model.Person = model.Person.Replace("{prsFOInfo}", foInfoJson);
					ObjectParameter objectParameter = new ObjectParameter("updatedPersonId", 0);
					ObjectParameter objectParameter2 = new ObjectParameter("errorMessage", "");
					CRMEntities cRMEntities2 = cRMEntities;
					int? num3 = model.CompanyId;
					int? personId = model.PersonId;
					string person = model.Person;
					int? companyId = num3;
					int? userId = token2.userId;
					short? year = value;
					int? languageID = result;
					int? defaultLanguageID = result2;
					ObjectParameter updatedPersonId = objectParameter;
					ObjectParameter errorMessage = objectParameter2;
					int? num4 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities2.MobspUpdateCompanyPerson(personId, person, companyId, userId, year, appType, languageID, defaultLanguageID, mobLackOfShowText, updatedPersonId, errorMessage, model.CenterId));
					if (objectParameter2.Value != null)
					{
						if (objectParameter2.Value.ToString() != "")
						{
							string text2 = objectParameter2.Value.ToString();
							text = objectParameter2.Value.ToString();
							text = text.Replace("|Msg=0", "<PRS>" + Messages.MobMsgErrorIsNotCompany + "<\\PRS>");
							text = text.Replace("|Msg=2", "<PRS>" + Messages.MobMsgErrorIsNotPerson + "<\\PRS>");
							num++;
							text2 = text2.Replace("|Msg=0", "").Replace("|Msg=2", "");
							if (text2.IndexOf("@prsMobile=Dup", StringComparison.Ordinal) >= 0 || text2.IndexOf("@prsEmail=Dup", StringComparison.Ordinal) >= 0 || text2.IndexOf("@prsEmailII=Dup", StringComparison.Ordinal) >= 0 || text2.IndexOf("@prsTel=Dup", StringComparison.Ordinal) >= 0 || text2.IndexOf("@prsTelII=Dup", StringComparison.Ordinal) >= 0 || text2.IndexOf("@cmpFax=Dup", StringComparison.Ordinal) >= 0 || text2.IndexOf("@cmpZipCode=Dup", StringComparison.Ordinal) >= 0 || text2.IndexOf("@cmpNationalCode=Dup", StringComparison.Ordinal) >= 0 || text2.IndexOf("@mainPrsNationalCode=Dup", StringComparison.Ordinal) >= 0)
							{
								string text3 = "";
								if (text2 != null && text2 != "")
								{
									string[] array = text2.Split(new string[1] { "|^|" }, StringSplitOptions.None);
									foreach (string text4 in array)
									{
										if (!string.IsNullOrEmpty(text4))
										{
											string[] array2 = text4.Split(new char[1] { ',' });
											string text5 = "";
											string text6 = "";
											string text7 = "";
											string text8 = "";
											string text9 = "";
											if (array2[0] == "@prsMobile=Dup")
											{
												text9 = array2[3].Replace("@CompanyPersonID=", "") ?? "";
												text7 = array2[1].Replace("@prsLName=", "") ?? "";
												text8 = array2[2].Replace("@prsFName=", "") ?? "";
												text6 = array2[5].Replace("@DupCmpNumber=", "") ?? "";
												text3 = text3 + "<PRS><PRSID>" + text9 + "<\\PRSID>" + string.Format(Messages.MobMsgErrorCheckPrsMobileDuplicate, text8 + " " + text7, text6) + "<\\PRS>";
											}
											else if (array2[0] == "@prsEmail=Dup")
											{
												text9 = array2[3].Replace("@CompanyPersonID=", "") ?? "";
												text7 = array2[1].Replace("@prsLName=", "") ?? "";
												text8 = array2[2].Replace("@prsFName=", "") ?? "";
												text6 = array2[5].Replace("@DupCmpNumber=", "") ?? "";
												text3 = text3 + "<PRS><PRSID>" + text9 + "<\\PRSID>" + string.Format(Messages.MobMsgErrorCheckPrsEmailDuplicate, text8 + " " + text7, text6) + "<\\PRS>";
											}
											else if (array2[0] == "@prsEmailII=Dup")
											{
												text9 = array2[3].Replace("@CompanyPersonID=", "") ?? "";
												text7 = array2[1].Replace("@prsLName=", "") ?? "";
												text8 = array2[2].Replace("@prsFName=", "") ?? "";
												text6 = array2[5].Replace("@DupCmpNumber=", "") ?? "";
												text3 = text3 + "<PRS><PRSID>" + text9 + "<\\PRSID>" + string.Format(Messages.MobMsgErrorCheckPrsEmailIIDuplicate, text8 + " " + text7, text6) + "<\\PRS>";
											}
											else if (array2[0] == "@prsTel=Dup")
											{
												text9 = array2[3].Replace("@CompanyPersonID=", "") ?? "";
												text5 = array2[1].Replace("@DupCmpName=", "") ?? "";
												text6 = array2[2].Replace("@DupCmpNumber=", "") ?? "";
												text3 = text3 + "<PRS><PRSID>" + text9 + "<\\PRSID>" + string.Format(Messages.MobCheckDuplicateTel, text6, text5) + "<\\PRS>";
											}
											else if (array2[0] == "@prsTelII=Dup")
											{
												text9 = array2[3].Replace("@CompanyPersonID=", "") ?? "";
												text5 = array2[1].Replace("@DupCmpName=", "") ?? "";
												text6 = array2[2].Replace("@DupCmpNumber=", "") ?? "";
												text3 = text3 + "<PRS><PRSID>" + text9 + "<\\PRSID>" + string.Format(Messages.MobCheckDuplicateTelII, text6, text5) + "<\\PRS>";
											}
											else if (array2[0] == "@prsFax=Dup")
											{
												text9 = array2[3].Replace("@CompanyPersonID=", "") ?? "";
												text5 = array2[1].Replace("@DupCmpName=", "") ?? "";
												text6 = array2[2].Replace("@DupCmpNumber=", "") ?? "";
												text3 = text3 + "<PRS><PRSID>" + text9 + "<\\PRSID>" + string.Format(Messages.MobCheckDuplicateFax, text6, text5) + "<\\PRS>";
											}
											else if (array2[0] == "@prsZipCode=Dup")
											{
												text9 = array2[3].Replace("@CompanyPersonID=", "") ?? "";
												text5 = array2[1].Replace("@DupCmpName=", "") ?? "";
												text6 = array2[2].Replace("@DupCmpNumber=", "") ?? "";
												text3 = text3 + "<PRS><PRSID>" + text9 + "<\\PRSID>" + string.Format(Messages.MobCheckDuplicateZipCode, text6, text5) + "<\\PRS>";
											}
											else if (array2[0] == "@prsNationalCode=Dup")
											{
												text9 = array2[3].Replace("@CompanyPersonID=", "") ?? "";
												text5 = array2[1].Replace("@DupCmpName=", "") ?? "";
												text6 = array2[2].Replace("@DupCmpNumber=", "") ?? "";
												text3 = text3 + "<PRS><PRSID>" + text9 + "<\\PRSID>" + string.Format(Messages.MobCheckDuplicatePrsNationalCode, text6, text5) + "<\\PRS>";
											}
											else if (array2[0] == "@mainPrsNationalCode=Dup")
											{
												text9 = array2[3].Replace("@CompanyPersonID=", "") ?? "";
												text5 = array2[1].Replace("@DupCmpName=", "") ?? "";
												text6 = array2[2].Replace("@DupCmpNumber=", "") ?? "";
												text3 = text3 + "<PRS><PRSID>" + text9 + "<\\PRSID>" + string.Format(Messages.MobCheckDuplicateCmpMainPrsNationalCode, text6, text5) + "<\\PRS>";
											}
										}
									}
								}
								text = text3;
								num++;
							}
							string text10 = text2;
							if (text10.IndexOf("|Msg=CompanyAccess|", StringComparison.Ordinal) >= 0)
							{
								if (text10.IndexOf("|Msg=CompanyAccess|", StringComparison.Ordinal) >= 0)
								{
									string[] array3 = text10.Split(new string[1] { "|Msg=CompanyAccess|" }, StringSplitOptions.None);
									if (array3 != null && Enumerable.Count<string>((IEnumerable<string>)array3) == 3 && !string.IsNullOrEmpty(array3[1]))
									{
										string[] array4 = array3[1].Split(new string[1] { "|PRSID|" }, StringSplitOptions.None);
										if (array4 != null && Enumerable.Count<string>((IEnumerable<string>)array4) == 2)
										{
											string text11 = string.Format(Messages.MobMsgErrorrNotAccessToCompany, array4[1]);
											string newValue = "<PRS><PRSID>" + array4[0] + "<\\PRSID><PRSCOMPANY>" + text11 + "<\\PRSCOMPANY><\\PRS>";
											text10 = text10.Replace("|Msg=CompanyAccess|" + array3[1] + "|Msg=CompanyAccess|", newValue);
										}
									}
								}
								text = text10;
								num++;
							}
						}
						else
						{
							text = "";
						}
					}
					num2 = ((objectParameter.Value != null) ? ((int)(objectParameter.Value ?? ((object)0))) : 0);
					if (!num4.HasValue || num4 >= 1)
					{
						if (num > 0)
						{
							data = model.PersonId;
							message = text;
							status = ServiceResultStatus.Fail;
						}
						else
						{
							if (model.DeletePrsPicture.GetValueOrDefault())
							{
								Enumerable.ToList<int?>((IEnumerable<int?>)cRMEntities.MobspDeletePersonPictureByPrsId(model.PersonId));
							}
							data = num2;
							message = Messages.MobMsgSuccessAction;
							status = ServiceResultStatus.Success;
						}
					}
					else
					{
						data = model.PersonId;
						message = Messages.MobMsgErrorDoneOperation;
						status = ServiceResultStatus.Fail;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = model.PersonId;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = model.PersonId;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = model.PersonId;
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
	[MobileAuthorize]
	public ServiceResult<int> Project(UpdateProjectViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
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
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					string text = "";
					int num = 0;
					int num2 = 0;
					_ = DateTime.Now;
					string mobPersonLabel = Labels.MobPersonLabel;
					short value = short.Parse(Financial.Get().Id.ToString());
					string appType = Mobile.Classes.Configuration.AppType;
					ObjectParameter objectParameter = new ObjectParameter("updatedProjectId", 0);
					ObjectParameter objectParameter2 = new ObjectParameter("errorMessage", "");
					Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspUpdateCompanyProject(model.CompanyId, model.ProjectId, model.Project, token2.userId, value, appType, result, result2, objectParameter, objectParameter2, model.CenterId));
					if (objectParameter2.Value != null)
					{
						if (objectParameter2.Value.ToString() != "")
						{
							text = objectParameter2.Value.ToString();
							text = text.Replace("|Msg=0", "<PRJ>" + Messages.MobMsgErrorIsNotCompany + "<\\PRJ>");
							text = text.Replace("|Msg=3", "<PRJ>" + Messages.MobMsgErrorIsNotProject + "<\\PRJ>");
							text = text.Replace("|Msg=4", "<PRJ>" + Messages.MobMsgNotChangePrjcnvsStatusGroupId + "<\\PRJ>");
							text = text.Replace("Msg=8", "<PRJ>" + Messages.MobMsgErrorPrjValidityPrdNotValid + "<\\PRJ>");
							num++;
							string text2 = objectParameter2.Value.ToString();
							text2.Replace("|Msg=0", "").Replace("|Msg=3", "").Replace("|Msg=4", "");
							if (text2.IndexOf("|Msg=CompanyAccess|", StringComparison.Ordinal) >= 0 || text2.IndexOf("|Msg=PrjAccess|", StringComparison.Ordinal) >= 0)
							{
								if (text2.IndexOf("|Msg=CompanyAccess|", StringComparison.Ordinal) >= 0)
								{
									string[] array = text2.Split(new string[1] { "|Msg=CompanyAccess|" }, StringSplitOptions.None);
									if (array != null && Enumerable.Count<string>((IEnumerable<string>)array) == 3 && !string.IsNullOrEmpty(array[1]))
									{
										string[] array2 = array[1].Split(new string[1] { "|PRJID|" }, StringSplitOptions.None);
										if (array2 != null && Enumerable.Count<string>((IEnumerable<string>)array2) == 2)
										{
											string text3 = string.Format(Messages.MobMsgErrorrNotAccessToCompany, array2[1]);
											string newValue = "<PRJ><PRJID>" + array2[0] + "<\\PRJID><PRJCOMPANY>" + text3 + "<\\PRJCOMPANY><\\PRJ>";
											text2 = text2.Replace("|Msg=CompanyAccess|" + array[1] + "|Msg=CompanyAccess|", newValue);
										}
									}
								}
								if (text2.IndexOf("|Msg=PrjAccess|", StringComparison.Ordinal) >= 0)
								{
									string[] array3 = text2.Split(new string[1] { "|Msg=PrjAccess|" }, StringSplitOptions.None);
									if (array3 != null && Enumerable.Count<string>((IEnumerable<string>)array3) == 3 && !string.IsNullOrEmpty(array3[1]))
									{
										string[] array4 = array3[1].Split(new string[1] { "|PRJID|" }, StringSplitOptions.None);
										if (array4 != null && Enumerable.Count<string>((IEnumerable<string>)array4) == 2)
										{
											string text4 = string.Format(Messages.MobMsgErrorrNotAccessToProject, array4[1]);
											string newValue2 = "<PRJ><PRJID>" + array4[0] + "<\\PRJID><PRJTITLE>" + text4 + "<\\PRJTITLE><\\PRJ>";
											text2 = text2.Replace("|Msg=PrjAccess|" + array3[1] + "|Msg=PrjAccess|", newValue2);
										}
									}
								}
								text = text2;
								num++;
							}
						}
						else
						{
							text = "";
						}
					}
					num2 = ((objectParameter.Value != null) ? ((int)(objectParameter.Value ?? ((object)0))) : 0);
					if (num > 0)
					{
						if (objectParameter2.Value.ToString().IndexOf("Dup=1", StringComparison.Ordinal) >= 0)
						{
							ObjectParameter objectParameter3 = new ObjectParameter("errorMessage", "");
							CRMEntities cRMEntities2 = cRMEntities;
							string personLabel = mobPersonLabel;
							string project = model.Project;
							int? id = 0;
							int? userId = token2.userId;
							int? languageID = result;
							int? defaultLanguageID = result2;
							ObjectParameter errorMessage = objectParameter3;
							cRMEntities2.MobspCheckDuplicateCompanyWithReason(null, null, project, id, userId, languageID, defaultLanguageID, null, personLabel, 1, errorMessage, model.CenterId);
							if (objectParameter3.Value != null && objectParameter3.Value.ToString() != "")
							{
								string text5 = objectParameter3.Value.ToString();
								string text6 = "";
								if (text5 != "")
								{
									string[] array5 = text5.Split(new string[1] { "|^|" }, StringSplitOptions.None);
									foreach (string text7 in array5)
									{
										if (!string.IsNullOrEmpty(text7))
										{
											string[] array6 = text7.Split(new char[1] { ',' });
											string text8 = "";
											string text9 = "";
											if (array6[0] == "@prjPostFix=Dup")
											{
												text8 = array6[1].Replace("@DupCmpName=", "") ?? "";
												text9 = array6[2].Replace("@DupCmpNumber=", "") ?? "";
												text6 = text6 + "<PRJ>" + string.Format(Messages.MobCheckDuplicatePrjPostFix, text9, text8) + "<\\PRJ>";
											}
											else if (array6[0] == "@prjDesc=Dup")
											{
												text8 = array6[1].Replace("@DupCmpName=", "") ?? "";
												text9 = array6[2].Replace("@DupCmpNumber=", "") ?? "";
												text6 = text6 + "<PRJ>" + string.Format(Messages.MobCheckDuplicatePrjDesc, text9, text8) + "<\\PRJ>";
											}
											else if (array6[0] == "@prjNumRef=Dup")
											{
												text8 = array6[1].Replace("@DupCmpName=", "") ?? "";
												text9 = array6[2].Replace("@DupCmpNumber=", "") ?? "";
												text6 = text6 + "<PRJ>" + string.Format(Messages.MobCheckDuplicatePrjNumRef, text9, text8) + "<\\PRJ>";
											}
											else if (array6[0] == "@prjInquiryNum=Dup")
											{
												text8 = array6[1].Replace("@DupCmpName=", "") ?? "";
												text9 = array6[2].Replace("@DupCmpNumber=", "") ?? "";
												text6 = text6 + "<PRJ>" + string.Format(Messages.MobCheckDuplicatePrjInquiryNum, text9, text8) + "<\\PRJ>";
											}
											else if (array6[0] == "@prjNumR=Dup")
											{
												text8 = array6[1].Replace("@DupCmpName=", "") ?? "";
												text9 = array6[2].Replace("@DupCmpNumber=", "") ?? "";
												text6 = text6 + "<PRJ>" + string.Format(Messages.MobCheckDuplicatePrjNumR, text9, text8) + "<\\PRJ>";
											}
										}
									}
								}
								text = text + " " + text6;
							}
						}
						data = model.ProjectId;
						message = text;
						status = ServiceResultStatus.Fail;
					}
					else
					{
						data = num2;
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = model.ProjectId;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = model.ProjectId;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = model.ProjectId;
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
	[MobileAuthorize]
	public ServiceResult<int> Conversation(UpdateConversationViewModel model)
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
					string text = "";
					int num = 0;
					int num2 = 0;
					if (Enumerable.FirstOrDefault<MobspSelectUserForLinkedType_Result>((IEnumerable<MobspSelectUserForLinkedType_Result>)cRMEntities.MobspSelectUserForLinkedType(token2.userId, 9, result, result2, model.CenterId, true), (Func<MobspSelectUserForLinkedType_Result, bool>)((MobspSelectUserForLinkedType_Result m) => m.Id == model.CnvsReferUserId)) == null)
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorUserCanNotCnvsEditaion,
							Data = model.ConversationId,
							Status = ServiceResultStatus.Fail
						};
					}
					_ = DateTime.Now;
					_ = Labels.MobPersonLabel;
					short value = short.Parse(Financial.Get().Id.ToString());
					string appType = Mobile.Classes.Configuration.AppType;
					ObjectParameter objectParameter = new ObjectParameter("updatedConversationId", 0);
					ObjectParameter objectParameter2 = new ObjectParameter("errorMessage", "");
					ObjectParameter result3 = new ObjectParameter("result", 0);
					cRMEntities.MobspUpdateConversation(model.CompanyId, model.ProjectId, model.ConversationId, model.Conversation, token2.userId, value, appType, result, result2, objectParameter, objectParameter2, result3, model.CenterId);
					if (objectParameter2.Value != null)
					{
						if (objectParameter2.Value.ToString() != "")
						{
							text = objectParameter2.Value.ToString();
							text = text.Replace("|Msg=0", "<CNVS>" + Messages.MobMsgErrorIsNotCompany + "<\\CNVS>");
							text = text.Replace("|Msg=2", "<CNVS>" + Messages.MobMsgErrorIsNotPerson + "<\\CNVS>");
							text = text.Replace("|Msg=3", "<CNVS>" + Messages.MobMsgErrorIsNotProject + "<\\CNVS>");
							text = text.Replace("|Msg=5", "<CNVS>" + Messages.MobMsgErrorIsNotConversation + "<\\CNVS>");
							num++;
							string text2 = objectParameter2.Value.ToString();
							text2.Replace("|Msg=0", "").Replace("|Msg=2", "").Replace("|Msg=3", "")
								.Replace("|Msg=5", "");
							if (text2.IndexOf("|Msg=CompanyAccess|", StringComparison.Ordinal) >= 0 || text2.IndexOf("|Msg=PrjAccess|", StringComparison.Ordinal) >= 0)
							{
								if (text2.IndexOf("|Msg=CompanyAccess|", StringComparison.Ordinal) >= 0)
								{
									string[] array = text2.Split(new string[1] { "|Msg=CompanyAccess|" }, StringSplitOptions.None);
									if (array != null && Enumerable.Count<string>((IEnumerable<string>)array) == 3 && !string.IsNullOrEmpty(array[1]))
									{
										string[] array2 = array[1].Split(new string[1] { "|CNVSID|" }, StringSplitOptions.None);
										if (array2 != null && Enumerable.Count<string>((IEnumerable<string>)array2) == 2)
										{
											string text3 = string.Format(Messages.MobMsgErrorrNotAccessToCompany, array2[1]);
											string newValue = "<CNVS><CNVSID>" + array2[0] + "<\\CNVSID><CNVSCOMPANY>" + text3 + "<\\CNVSCOMPANY><\\CNVS>";
											text2 = text2.Replace("|Msg=CompanyAccess|" + array[1] + "|Msg=CompanyAccess|", newValue);
										}
									}
								}
								if (text2.IndexOf("|Msg=PrjAccess|", StringComparison.Ordinal) >= 0)
								{
									string[] array3 = text2.Split(new string[1] { "|Msg=PrjAccess|" }, StringSplitOptions.None);
									if (array3 != null && Enumerable.Count<string>((IEnumerable<string>)array3) == 3 && !string.IsNullOrEmpty(array3[1]))
									{
										string[] array4 = array3[1].Split(new string[1] { "|CNVSID|" }, StringSplitOptions.None);
										if (array4 != null && Enumerable.Count<string>((IEnumerable<string>)array4) == 2)
										{
											string text4 = string.Format(Messages.MobMsgErrorrNotAccessToProject, array4[1]);
											string newValue2 = "<CNVS><CNVSID>" + array4[0] + "<\\CNVSID><CNVSPROJECT>" + text4 + "<\\CNVSPROJECT><\\CNVS>";
											text2 = text2.Replace("|Msg=PrjAccess|" + array3[1] + "|Msg=PrjAccess|", newValue2);
										}
									}
								}
								text = text2;
								num++;
							}
							else if (text2.IndexOf("PreChckErrs", StringComparison.Ordinal) >= 0)
							{
								string text5 = "";
								string[] array5 = text2.Split(new string[1] { "|^|" }, StringSplitOptions.None);
								foreach (string text6 in array5)
								{
									if (!string.IsNullOrEmpty(text6))
									{
										string[] array6 = text6.Split(new char[1] { ',' });
										if (array6[0] == "@StatusResCheckNeedDyFormChecked=PreChckErrs")
										{
											string arg = array6[1].Replace("@FormName=", "") ?? "";
											string arg2 = array6[2].Replace("@DyFormNumber=", "") ?? "";
											text5 = text5 + "<CNVS>" + string.Format(Messages.MobMsgErrorNotSaveCnvsBeforeDyFormChecked, arg, arg2) + "<\\CNVS>";
										}
										else if (array6[0] == "@StatusResCheckNoCnvsDup=PreChckErrs")
										{
											string arg3 = array6[1].Replace("@cnvsDate=", "") ?? "";
											string arg4 = array6[2].Replace("@cnvsStatus=", "") ?? "";
											string arg5 = array6[3].Replace("@cnvsStatusResult=", "") ?? "";
											text5 = text5 + "<CNVS>" + string.Format(Messages.MobMsgErrorNoDupCnvsInStatusResult, arg3, arg4, arg5) + "<\\CNVS>";
										}
										else if (array6[0] == "@StatusResCheckCnvsCountLimit=PreChckErrs")
										{
											string arg6 = array6[1].Replace("@ResultTitle=", "") ?? "";
											string arg7 = array6[2].Replace("@cnvsCountLimit=", "") ?? "";
											text5 = text5 + "<CNVS>" + string.Format(Messages.MobMsgErrorCnvsCountLimitInStatusResult, arg6, arg7) + "<\\CNVS>";
										}
										else if (array6[0] == "@StatusResCheckCnvsDoingTimeLimit=PreChckErrs")
										{
											string arg8 = array6[1].Replace("@ResultTitle=", "") ?? "";
											string arg9 = array6[2].Replace("@cnvsDoingTimeLimit=", "") ?? "";
											text5 = text5 + "<CNVS>" + string.Format(Messages.MobMsgErrorCnvsDoingTimeLimitInStatusResult, arg8, arg9) + "<\\CNVS>";
										}
										else if (array6[0] == "@StatusCheckNoOrderStatus=PreChckErrs")
										{
											string arg10 = array6[1].Replace("@Status=", "") ?? "";
											text5 = text5 + "<CNVS>" + string.Format(Messages.MobMsgErrorNoRegCnvsOlderStatus, arg10) + "<\\CNVS>";
										}
										else if (array6[0] == "@StatusCheckCnvsCountLimit=PreChckErrs")
										{
											string arg11 = array6[1].Replace("@Status=", "") ?? "";
											string arg12 = array6[2].Replace("@cnvsCountLimit=", "") ?? "";
											text5 = text5 + "<CNVS>" + string.Format(Messages.MobMsgErrorCnvsCountLimitInStatus, arg11, arg12) + "<\\CNVS>";
										}
										else if (array6[0] == "@StatusCheckCnvsDoingTimeLimit=PreChckErrs")
										{
											string arg13 = array6[1].Replace("@Status=", "") ?? "";
											string arg14 = array6[2].Replace("@cnvsDoingTimeLimit=", "") ?? "";
											text5 = text5 + "<CNVS>" + string.Format(Messages.MobMsgErrorCnvsDoingTimeLimitInStatus, arg13, arg14) + "<\\CNVS>";
										}
										else if (array6[0] == "@StatusResCheckUsedUserIds=PreChckErrs")
										{
											text5 = text5 + "<CNVS>" + string.Format(Messages.MobMsgErrorCanNotSaveCnvsInResult) + "<\\CNVS>";
										}
										else if (array6[0] == "@StatusCheckUsedUserIds=PreChckErrs")
										{
											text5 = text5 + "<CNVS>" + string.Format(Messages.MobMsgErrorCanNotSaveCnvsInStatus) + "<\\CNVS>";
										}
										else if (array6[0] == "@StatusResCheckNeedDyFormCheckedNotExist=PreChckErrs")
										{
											string text7 = array6[1].Replace("@NeedDyFormCheckedForm=", "") ?? "";
											text5 = text5 + "<CNVS>" + string.Format(Messages.MobMsgErrorNotSaveCnvsBeforeInsertDyFormFromCmp, text7 ?? "") + "<\\CNVS>";
										}
									}
								}
								text = text5;
								num++;
							}
						}
						else
						{
							text = "";
						}
					}
					num2 = ((objectParameter.Value != null) ? ((int)(objectParameter.Value ?? ((object)0))) : 0);
					if (num > 0)
					{
						data = model.ConversationId;
						message = text;
						status = ServiceResultStatus.Fail;
					}
					else
					{
						cRMSpEntities.MobspDeleteSysTempData(0, token2.userId, 13, 0, 170, 0);
						data = num2;
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = model.ConversationId;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = model.ConversationId;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = model.ConversationId;
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

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> File(UpdateFileViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
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
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					string text = "";
					int num = 0;
					int num2 = 0;
					_ = DateTime.Now;
					short value = short.Parse(Financial.Get().Id.ToString());
					short num3 = 0;
					string appType = Mobile.Classes.Configuration.AppType;
					DateTime dateTime = default(DateTime);
					string text2 = "";
					DateTime now = DateTime.Now;
					DateTime now2 = DateTime.Now;
					try
					{
						if (string.IsNullOrEmpty(model.RegisterDatePersian))
						{
							ServiceResult<int> result3 = new ServiceResult<int>
							{
								Message = Messages.MobMsgErrorDateNotEntered,
								Data = model.FileDirectoryId,
								Status = ServiceResultStatus.Fail
							};
							cRMEntities?.Dispose();
							return result3;
						}
						text2 = PersianDate.GetFormatetdDate(model.RegisterDatePersian.Replace("/", ""));
						if (result == 1065)
						{
							dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
							model.RegisterDatePersian = dateTime.ToString("yyyyMMdd");
						}
						else
						{
							dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
							model.RegisterDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
						}
						now = dateTime;
						num3 = short.Parse(dateTime.ToString("MM"));
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						ServiceResult<int> result4 = new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorDateFormatIncorrect,
							Data = model.FileDirectoryId,
							Status = ServiceResultStatus.Error
						};
						cRMEntities?.Dispose();
						return result4;
					}
					try
					{
						if (string.IsNullOrEmpty(model.DocTime))
						{
							ServiceResult<int> result5 = new ServiceResult<int>
							{
								Message = Messages.MobMsgErrorTimeNotEntered,
								Data = model.FileDirectoryId,
								Status = ServiceResultStatus.Fail
							};
							cRMEntities?.Dispose();
							return result5;
						}
						if (string.IsNullOrEmpty(model.DocDate))
						{
							ServiceResult<int> result6 = new ServiceResult<int>
							{
								Message = Messages.MobMsgErrorDateNotEntered,
								Data = model.FileDirectoryId,
								Status = ServiceResultStatus.Fail
							};
							cRMEntities?.Dispose();
							return result6;
						}
						text2 = PersianDate.GetFormatetdDate(model.DocDate.Replace("/", ""));
						if (result == 1065)
						{
							dateTime = DateTime.Parse(text2 + " " + model.DocTime, new PersianCulture());
							model.DocDate = dateTime.ToString("yyyyMMdd");
						}
						else
						{
							dateTime = DateTime.Parse(text2 + " " + model.DocTime, new CultureInfo("en-US"));
							model.DocDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						}
						now2 = dateTime;
						if (string.IsNullOrEmpty(model.DocDay))
						{
							model.DocDay = DateTimeClass.ConvertNameToDayNum(dateTime.DayOfWeek.ToString());
						}
					}
					catch (Exception e2)
					{
						ErrorSignal.FromCurrentContext().Raise(e2);
						ServiceResult<int> result7 = new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorDateFormatIncorrect,
							Data = model.FileDirectoryId,
							Status = ServiceResultStatus.Error
						};
						cRMEntities?.Dispose();
						return result7;
					}
					ObjectParameter objectParameter = new ObjectParameter("UpdatedFileDirectoryId", 0);
					ObjectParameter objectParameter2 = new ObjectParameter("errorMessage", "");
					int? num4 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspUpdateFileDirectory(model.FileDirectoryId, model.FileDirectoryTypeId, model.Title, token2.userId, value, num3, now, model.RegisterDatePersian, model.DocDate, now2, model.DocDay, model.DocTime, appType, result2, objectParameter, objectParameter2, model.FileDesc));
					if (objectParameter2.Value != null)
					{
						if (objectParameter2.Value.ToString() != "")
						{
							text = objectParameter2.Value.ToString();
							text = text.Replace("|Msg=0", Messages.MobMsgErrorFileNotExist);
							num++;
						}
						else
						{
							text = "";
						}
					}
					num2 = ((objectParameter.Value != null) ? ((int)(objectParameter.Value ?? ((object)0))) : 0);
					if (!num4.HasValue || num4 >= 1)
					{
						if (num > 0)
						{
							data = model.FileDirectoryId;
							message = text;
							status = ServiceResultStatus.Fail;
						}
						else
						{
							data = num2;
							message = Messages.MobMsgSuccessAction;
							status = ServiceResultStatus.Success;
						}
					}
					else
					{
						data = model.FileDirectoryId;
						message = Messages.MobMsgErrorDoneOperation;
						status = ServiceResultStatus.Fail;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = model.FileDirectoryId;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = model.FileDirectoryId;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e3)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = model.FileDirectoryId;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e3);
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
	[MobileAuthorize]
	public ServiceResult<UpdatePreOrderViewModel> PreOrder(UpdatePreOrderViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		UpdatePreOrderViewModel data = null;
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
					string text = "";
					_ = DateTime.Now;
					short value = short.Parse(Financial.Get().Id.ToString());
					string appType = Mobile.Classes.Configuration.AppType;
					short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					ObjectParameter objectParameter = new ObjectParameter("updatedPreOrderId", 0);
					ObjectParameter objectParameter2 = new ObjectParameter("errorMessage", "");
					Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspUpdatePreOrder(model.PreOrderId, model.PreOrder, token2.userId, value2, value, appType, result, result2, objectParameter, objectParameter2, model.CenterId));
					UpdatePreOrderViewModel updatePreOrderViewModel = new UpdatePreOrderViewModel();
					if (objectParameter2.Value != null)
					{
						if (objectParameter2.Value.ToString() != "")
						{
							string text2 = objectParameter2.Value.ToString();
							text2 = text2.Replace("|Msg=0", Messages.MobMsgErrorInsertPreOrder);
							text2 = text2.Replace("|pordNumberIsDup", Messages.MobMsgPreOrderNumberIsRepeated);
							text2 = text2.Replace("|Msg=pordReferUserIdAccess", Messages.MobMsgPreOrderEditNotAccess);
							text2 = text2.Replace("Msg=1", Messages.MobMsgErrorInconsistencyInPordSelection);
							text2 = text2.Replace("Msg=5", Messages.MobMsgProductLackOfStock);
							text2 = text2.Replace("Msg=2", Messages.MobMsgErrorInsertProduct);
							text2 = text2.Replace("Msg=3", Messages.MobMsgErrorInsertProductSpcf);
							updatePreOrderViewModel.ErrorMessage = text2;
						}
						else
						{
							text = "";
						}
					}
					if (objectParameter.Value != null)
					{
						updatePreOrderViewModel.PreOrderId = (int)(objectParameter.Value ?? ((object)0));
					}
					else
					{
						updatePreOrderViewModel.PreOrderId = 0;
					}
					if (0 > 0 && !string.IsNullOrWhiteSpace(text))
					{
						updatePreOrderViewModel.PreOrderId = model.PreOrderId;
						data = updatePreOrderViewModel;
						message = text;
						status = ServiceResultStatus.Fail;
					}
					else if (updatePreOrderViewModel.PreOrderId > 0)
					{
						data = updatePreOrderViewModel;
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						updatePreOrderViewModel.PreOrderId = model.PreOrderId;
						data = updatePreOrderViewModel;
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
		}
		return new ServiceResult<UpdatePreOrderViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<UpdatePreOrderItemViewModel> PreOrderItem(UpdatePreOrderItemViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		UpdatePreOrderItemViewModel data = null;
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
					string text = "";
					_ = DateTime.Now;
					short value = short.Parse(Financial.Get().Id.ToString());
					string appType = Mobile.Classes.Configuration.AppType;
					short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					bool value3 = UserLogin.IsUserAccess("frmPreOrderItemDataEntry", "actCanNotSelectWithNoStockInPord", UserLogin.CurrentUser, model.CenterId);
					bool value4 = UserLogin.IsUserAccess("frmPreOrderItemDataEntry", "actCanNotSelectWithNoReserveStockInPord", UserLogin.CurrentUser, model.CenterId);
					bool value5 = UserLogin.IsUserAccess("frmPreOrderItemDataEntry", "actCanNotSelectWithNoSoldStockInPord", UserLogin.CurrentUser, model.CenterId);
					ObjectParameter objectParameter = new ObjectParameter("UpdatedPordItemId", 0);
					ObjectParameter objectParameter2 = new ObjectParameter("errorMessage", "");
					Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspUpdatePreOrderItem(model.PreOrderItemId, model.PreOrderItem, token2.userId, value2, value, appType, result, result2, value3, objectParameter, objectParameter2, model.haveLinkAccQtyCheck, value4, value5));
					UpdatePreOrderItemViewModel updatePreOrderItemViewModel = new UpdatePreOrderItemViewModel();
					if (objectParameter2.Value != null)
					{
						if (objectParameter2.Value.ToString() != "")
						{
							string text2 = objectParameter2.Value.ToString();
							text2 = text2.Replace("|Msg=0", Messages.MobMsgErrorInsertPreOrder);
							text2 = text2.Replace("|pordNumberIsDup", Messages.MobMsgPreOrderNumberIsRepeated);
							text2 = text2.Replace("|Msg=pordReferUserIdAccess", Messages.MobMsgPreOrderEditNotAccess);
							text2 = text2.Replace("Msg=1", Messages.MobMsgErrorInconsistencyInPordSelection);
							text2 = text2.Replace("Msg=5", Messages.MobMsgProductLackOfStock);
							text2 = text2.Replace("Msg=6", Messages.MobMsgProductLackOfReserveStock);
							text2 = text2.Replace("Msg=7", Messages.MobMsgProductLackOfSoldStock);
							text2 = text2.Replace("Msg=2", Messages.MobMsgErrorInsertProduct);
							text2 = text2.Replace("Msg=3", Messages.MobMsgErrorInsertProductSpcf);
							updatePreOrderItemViewModel.ErrorMessage = text2;
						}
						else
						{
							text = "";
						}
					}
					if (objectParameter.Value != null)
					{
						updatePreOrderItemViewModel.PreOrderItemId = (int)(objectParameter.Value ?? ((object)0));
					}
					else
					{
						updatePreOrderItemViewModel.PreOrderItemId = 0;
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						updatePreOrderItemViewModel.PreOrderItemId = model.PreOrderItemId;
						data = updatePreOrderItemViewModel;
						message = text;
						status = ServiceResultStatus.Fail;
					}
					else if (updatePreOrderItemViewModel.PreOrderItemId > 0)
					{
						data = updatePreOrderItemViewModel;
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						updatePreOrderItemViewModel.PreOrderItemId = model.PreOrderItemId;
						data = updatePreOrderItemViewModel;
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
		}
		return new ServiceResult<UpdatePreOrderItemViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> PreOrderPayment(UpdatePreOrderPaymentViewModel model)
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
					string text = "";
					_ = DateTime.Now;
					short value = short.Parse(Financial.Get().Id.ToString());
					string appType = Mobile.Classes.Configuration.AppType;
					short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					int oldPayTypeId = 0;
					if (!model.ModeVerify)
					{
						oldPayTypeId = Enumerable.FirstOrDefault<MobspSelectPreOrderPaymentsWithId_Result>((IEnumerable<MobspSelectPreOrderPaymentsWithId_Result>)cRMSpEntities.MobspSelectPreOrderPaymentsWithId(model.PreOrderPaymentId, result, result2)).pordpayTypeId;
					}
					ObjectParameter objectParameter = new ObjectParameter("UpdatedPordPaymentId", 0);
					ObjectParameter errorMessage = new ObjectParameter("errorMessage", "");
					Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspUpdatePreOrderPayment(model.PreOrderPaymentId, model.PreOrderPayment, token2.userId, value2, value, appType, result, result2, objectParameter, errorMessage));
					if (!string.IsNullOrWhiteSpace(text))
					{
						data = model.PreOrderPaymentId;
						message = text;
						status = ServiceResultStatus.Fail;
					}
					else if (objectParameter.Value != null)
					{
						if (!model.ModeVerify)
						{
							Mobile.Classes.Helper.PreOrder.PaymentMoneyBag(model.PreOrderPaymentId, oldPayTypeId, result, model.CenterId);
						}
						data = (int)(objectParameter.Value ?? ((object)0));
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						data = model.PreOrderPaymentId;
						message = Messages.MobMsgErrorDoneOperation;
						status = ServiceResultStatus.Fail;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = model.PreOrderPaymentId;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = model.PreOrderPaymentId;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = model.PreOrderPaymentId;
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
	[MobileAuthorize]
	public ServiceResult<UpdateOrderViewModel> Order(UpdateOrderViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		UpdateOrderViewModel data = null;
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
					string text = "";
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(Financial.Get().Id.ToString());
					string appType = Mobile.Classes.Configuration.AppType;
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					ObjectParameter objectParameter = new ObjectParameter("updatedOrderId", 0);
					ObjectParameter objectParameter2 = new ObjectParameter("errorMessage", "");
					CRMEntities cRMEntities2 = cRMEntities;
					int? orderId = model.OrderId;
					string order = model.Order;
					int? userId = token2.userId;
					short? month = value3;
					int? fPId = value2;
					string appType2 = appType;
					int? languageID = result;
					int? defaultLanguageID = result2;
					ObjectParameter updatedOrderId = objectParameter;
					ObjectParameter errorMessage = objectParameter2;
					Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities2.MobspUpdateOrder(orderId, order, userId, month, value, registerDatePersian, fPId, appType2, languageID, defaultLanguageID, updatedOrderId, errorMessage, model.CenterId));
					UpdateOrderViewModel updateOrderViewModel = new UpdateOrderViewModel();
					if (objectParameter2.Value != null)
					{
						if (objectParameter2.Value.ToString() != "")
						{
							string text2 = objectParameter2.Value.ToString();
							text2 = text2.Replace("|Msg=0", Messages.MobMsgErrorInsertPreOrder);
							text2 = text2.Replace("|ordNumberIsDup", Messages.MobMsgPreOrderNumberIsRepeated);
							text2 = text2.Replace("|Msg=ordReferUserIdAccess", Messages.MobMsgPreOrderEditNotAccess);
							text2 = text2.Replace("Msg=1", Messages.MobMsgErrorInconsistencyInPordSelection);
							text2 = text2.Replace("Msg=5", Messages.MobMsgProductLackOfStock);
							text2 = text2.Replace("Msg=2", Messages.MobMsgErrorInsertProduct);
							text2 = text2.Replace("Msg=3", Messages.MobMsgErrorInsertProductSpcf);
							updateOrderViewModel.ErrorMessage = text2;
						}
						else
						{
							text = "";
						}
					}
					if (objectParameter.Value != null)
					{
						updateOrderViewModel.OrderId = (int)(objectParameter.Value ?? ((object)0));
					}
					else
					{
						updateOrderViewModel.OrderId = 0;
					}
					if (0 > 0 && !string.IsNullOrWhiteSpace(text))
					{
						updateOrderViewModel.OrderId = model.OrderId;
						data = updateOrderViewModel;
						message = text;
						status = ServiceResultStatus.Fail;
					}
					else if (updateOrderViewModel.OrderId > 0)
					{
						data = updateOrderViewModel;
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						updateOrderViewModel.OrderId = model.OrderId;
						data = updateOrderViewModel;
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
		}
		return new ServiceResult<UpdateOrderViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<UpdateOrderItemViewModel> OrderItem(UpdateOrderItemViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		UpdateOrderItemViewModel data = null;
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
					cRMSpEntities = new CRMSpEntities();
					string text = "";
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(Financial.Get().Id.ToString());
					string appType = Mobile.Classes.Configuration.AppType;
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					bool value4 = UserLogin.IsUserAccess("frmOrderItemDataEntry", "actCanNotSelectWithNoStockInOrd", UserLogin.CurrentUser, model.CenterId);
					bool value5 = UserLogin.IsUserAccess("frmOrderItemDataEntry", "actCanNotSelectWithNoReserveStockInOrd", UserLogin.CurrentUser, model.CenterId);
					bool value6 = UserLogin.IsUserAccess("frmOrderItemDataEntry", "actCanNotSelectWithNoSoldStockInOrd", UserLogin.CurrentUser, model.CenterId);
					ObjectParameter objectParameter = new ObjectParameter("UpdatedOrdItemId", 0);
					ObjectParameter objectParameter2 = new ObjectParameter("errorMessage", "");
					CRMEntities cRMEntities2 = cRMEntities;
					int? orderItemId = model.OrderItemId;
					string orderItem = model.OrderItem;
					int? userId = token2.userId;
					short? month = value3;
					int? fPId = value2;
					int? languageID = result;
					int? defaultLanguageID = result2;
					bool? actCanNotSelectWithNoStock = value4;
					ObjectParameter updatedOrdItemId = objectParameter;
					ObjectParameter errorMessage = objectParameter2;
					Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities2.MobspUpdateOrderItem(orderItemId, orderItem, userId, month, fPId, appType, value, registerDatePersian, languageID, defaultLanguageID, actCanNotSelectWithNoStock, updatedOrdItemId, errorMessage, model.haveLinkAccQtyCheck, value5, value6));
					UpdateOrderItemViewModel updateOrderItemViewModel = new UpdateOrderItemViewModel();
					if (objectParameter2.Value != null)
					{
						if (objectParameter2.Value.ToString() != "")
						{
							string text2 = objectParameter2.Value.ToString();
							text2 = text2.Replace("|Msg=0", Messages.MobMsgErrorInsertPreOrder);
							text2 = text2.Replace("|pordNumberIsDup", Messages.MobMsgPreOrderNumberIsRepeated);
							text2 = text2.Replace("|Msg=pordReferUserIdAccess", Messages.MobMsgPreOrderEditNotAccess);
							text2 = text2.Replace("Msg=1", Messages.MobMsgErrorInconsistencyInPordSelection);
							text2 = text2.Replace("Msg=5", Messages.MobMsgProductLackOfStock);
							text2 = text2.Replace("Msg=6", Messages.MobMsgProductLackOfReserveStock);
							text2 = text2.Replace("Msg=7", Messages.MobMsgProductLackOfSoldStock);
							text2 = text2.Replace("Msg=2", Messages.MobMsgErrorInsertProduct);
							text2 = text2.Replace("Msg=3", Messages.MobMsgErrorInsertProductSpcf);
							updateOrderItemViewModel.ErrorMessage = text2;
						}
						else
						{
							text = "";
						}
					}
					if (objectParameter.Value != null)
					{
						updateOrderItemViewModel.OrderItemId = (int)(objectParameter.Value ?? ((object)0));
					}
					else
					{
						updateOrderItemViewModel.OrderItemId = 0;
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						updateOrderItemViewModel.OrderItemId = model.OrderItemId;
						data = updateOrderItemViewModel;
						message = text;
						status = ServiceResultStatus.Fail;
					}
					else if (updateOrderItemViewModel.OrderItemId > 0)
					{
						data = updateOrderItemViewModel;
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						updateOrderItemViewModel.OrderItemId = model.OrderItemId;
						data = updateOrderItemViewModel;
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
		return new ServiceResult<UpdateOrderItemViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<bool> UpdateOrderItemDeliveryDate(int orderId, int orderItemId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		bool data = false;
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
					cRMSpEntities = new CRMSpEntities();
					List<MobspSelectOrderItems_Result> list = Enumerable.ToList<MobspSelectOrderItems_Result>((IEnumerable<MobspSelectOrderItems_Result>)cRMEntities.MobspSelectOrderItems(orderId, result, result2));
					if (Enumerable.Any<MobspSelectOrderItems_Result>((IEnumerable<MobspSelectOrderItems_Result>)list))
					{
						MobspSelectOrderItems_Result mobspSelectOrderItems_Result = Enumerable.FirstOrDefault<MobspSelectOrderItems_Result>(Enumerable.Where<MobspSelectOrderItems_Result>((IEnumerable<MobspSelectOrderItems_Result>)list, (Func<MobspSelectOrderItems_Result, bool>)((MobspSelectOrderItems_Result ordItem) => ordItem.OrderItemID == orderItemId)));
						if (mobspSelectOrderItems_Result != null)
						{
							cRMSpEntities.MobspUpdateOrderItemsDeliveryDates(orderId, mobspSelectOrderItems_Result.ordIDeliveryDate, mobspSelectOrderItems_Result.ordIDeliveryDatePersian, mobspSelectOrderItems_Result.ordIDeliveryDay, mobspSelectOrderItems_Result.ordIDeliveryEndDate, mobspSelectOrderItems_Result.ordIDeliveryEndDatePersian, mobspSelectOrderItems_Result.ordIDeliveryEndDay, mobspSelectOrderItems_Result.ordIDeliveryEndTime, mobspSelectOrderItems_Result.ordIDeliveryTime, mobspSelectOrderItems_Result.ordISaleCenterId);
						}
					}
					data = true;
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = false;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = false;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = false;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<bool>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<UpdateOrderPaymentViewModel> OrderPayment(UpdateOrderPaymentViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		UpdateOrderPaymentViewModel data;
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
					string text = "";
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(Financial.Get().Id.ToString());
					string appType = Mobile.Classes.Configuration.AppType;
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					int oldPayTypeId = 0;
					if (!model.ModeVerify)
					{
						oldPayTypeId = Enumerable.FirstOrDefault<MobspSelectOrderPaymentsWithId_Result>((IEnumerable<MobspSelectOrderPaymentsWithId_Result>)cRMSpEntities.MobspSelectOrderPaymentsWithId(model.OrderPaymentId, result, result2)).ordpayTypeId;
					}
					ObjectParameter objectParameter = new ObjectParameter("UpdatedOrdPaymentId", 0);
					ObjectParameter objectParameter2 = new ObjectParameter("errorMessage", "");
					CRMEntities cRMEntities2 = cRMEntities;
					int? orderPaymentId = model.OrderPaymentId;
					string orderPayment = model.OrderPayment;
					int? userId = token2.userId;
					short? month = value3;
					int? fPId = value2;
					int? languageID = result;
					int? defaultLanguageID = result2;
					ObjectParameter updatedOrdPaymentId = objectParameter;
					ObjectParameter errorMessage = objectParameter2;
					Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities2.MobspUpdateOrderPayment(orderPaymentId, orderPayment, userId, month, fPId, appType, value, registerDatePersian, languageID, defaultLanguageID, updatedOrdPaymentId, errorMessage));
					UpdateOrderPaymentViewModel updateOrderPaymentViewModel = new UpdateOrderPaymentViewModel();
					if (objectParameter2.Value != null)
					{
						if (objectParameter2.Value.ToString() != "")
						{
							string errorMessage2 = objectParameter2.Value.ToString();
							updateOrderPaymentViewModel.ErrorMessage = errorMessage2;
						}
						else
						{
							text = "";
						}
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						updateOrderPaymentViewModel.OrderPaymentId = model.OrderPaymentId;
						data = updateOrderPaymentViewModel;
						message = text;
						status = ServiceResultStatus.Fail;
					}
					else if (objectParameter.Value != null)
					{
						if (!model.ModeVerify)
						{
							Mobile.Classes.Helper.Order.PaymentMoneyBag(model.OrderPaymentId, oldPayTypeId, result, model.CenterId);
						}
						updateOrderPaymentViewModel.OrderPaymentId = (int)(objectParameter.Value ?? ((object)0));
						data = updateOrderPaymentViewModel;
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						updateOrderPaymentViewModel.OrderPaymentId = model.OrderPaymentId;
						data = updateOrderPaymentViewModel;
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
		return new ServiceResult<UpdateOrderPaymentViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> Doc(UpdateDocViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
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
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMSpEntities = new CRMSpEntities();
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					string appType = Mobile.Classes.Configuration.AppType;
					short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					ObjectParameter objectParameter = new ObjectParameter("ResUpdatedDocId", 0);
					ObjectParameter objectParameter2 = new ObjectParameter("ResErrorMessage", "");
					CRMSpEntities cRMSpEntities2 = cRMSpEntities;
					string docParams = model.DocParams;
					int? userId = token2.userId;
					short? month = value2;
					string appType2 = appType;
					int? languageID = result;
					int? defaultLanguageID = result2;
					ObjectParameter resUpdatedDocId = objectParameter;
					ObjectParameter resErrorMessage = objectParameter2;
					Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpEntities2.MobspUpdateDoc(docParams, userId, month, value, registerDatePersian, appType2, languageID, defaultLanguageID, resErrorMessage, resUpdatedDocId, model.CenterId));
					if (!string.IsNullOrEmpty(objectParameter2.Value?.ToString()))
					{
						string text = "";
						string[] array = objectParameter2.Value.ToString().Split(new string[1] { "#|^|#" }, StringSplitOptions.None);
						string[] array2 = array;
						foreach (string text2 in array2)
						{
							if (string.IsNullOrEmpty(text2))
							{
								continue;
							}
							string[] array3 = text2.Split(new string[1] { "|^|" }, StringSplitOptions.None);
							switch (array3[0])
							{
							case "ParseData=Error":
								text = Messages.MobMsgErrorInSentData;
								break;
							case "DocNumber=Dup":
								text = Messages.MobMsgDraftNumberIsRepeated;
								break;
							case "DocNumRef=Dup":
							{
								string arg = "";
								if (array3.Length > 1)
								{
									arg = array3[1].Replace("DupDocNumber=", "") ?? "";
								}
								text = string.Format(Messages.MobMsgDocNumRefIsRepeated, arg);
								break;
							}
							case "Error":
								text = Messages.MobMsgErrorSubmitDraft;
								break;
							}
						}
						if (string.IsNullOrEmpty(text))
						{
							text = array[0];
						}
						message = text;
						status = ServiceResultStatus.Fail;
					}
					else
					{
						data = model.DocId;
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<int>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> DocItemSerial(UpdateDocItemSerialViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
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
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMSpEntities = new CRMSpEntities();
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					string appType = Mobile.Classes.Configuration.AppType;
					short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					int id = Financial.Get().Id;
					ObjectParameter objectParameter = new ObjectParameter("ResUpdatedDocItemSerialId", 0);
					ObjectParameter objectParameter2 = new ObjectParameter("ResErrorMessage", "");
					CRMSpEntities cRMSpEntities2 = cRMSpEntities;
					string docItemSerialParams = model.DocItemSerialParams;
					int? userId = token2.userId;
					short? month = value2;
					int? fPId = id;
					string appType2 = appType;
					int? languageID = result;
					int? defaultLanguageID = result2;
					ObjectParameter resUpdatedDocItemSerialId = objectParameter;
					ObjectParameter resErrorMessage = objectParameter2;
					Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpEntities2.MobspUpdateDocItemSerial(docItemSerialParams, userId, fPId, month, value, registerDatePersian, appType2, languageID, defaultLanguageID, resErrorMessage, resUpdatedDocItemSerialId));
					if (!string.IsNullOrEmpty(objectParameter2.Value?.ToString()))
					{
						string text = "";
						string[] array = objectParameter2.Value.ToString().Split(new string[1] { "#|^|#" }, StringSplitOptions.None);
						string[] array2 = array;
						foreach (string text2 in array2)
						{
							if (string.IsNullOrEmpty(text2))
							{
								continue;
							}
							string[] array3 = text2.Split(new string[1] { "|^|" }, StringSplitOptions.None);
							switch (array3[0])
							{
							case "ParseData=Error":
								text = Messages.MobMsgErrorInSentData;
								break;
							case "Serial=Dup":
							{
								string arg = "";
								if (array3.Length > 1)
								{
									arg = array3[1].Replace("DocNumber=", "") ?? "";
								}
								text = string.Format(Messages.msgSerialNumberDuplicateInDraft, arg);
								break;
							}
							case "Error":
								text = Messages.MobMsgErrorSubmitDraftItemSerial;
								break;
							}
						}
						if (string.IsNullOrEmpty(text))
						{
							text = array[0];
						}
						message = text;
						status = ServiceResultStatus.Fail;
					}
					else
					{
						data = model.DocItemSerialId;
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<int>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> DocItem(UpdateDocItemViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
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
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMSpEntities = new CRMSpEntities();
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					string appType = Mobile.Classes.Configuration.AppType;
					short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					int id = Financial.Get().Id;
					ObjectParameter objectParameter = new ObjectParameter("ResUpdatedDocItemIds", 0);
					ObjectParameter objectParameter2 = new ObjectParameter("ResErrorMessage", "");
					CRMSpEntities cRMSpEntities2 = cRMSpEntities;
					string docItemParams = model.DocItemParams;
					int? userId = token2.userId;
					short? month = value2;
					string appType2 = appType;
					int? fPId = id;
					int? languageID = result;
					int? defaultLanguageID = result2;
					ObjectParameter resUpdatedDocItemIds = objectParameter;
					ObjectParameter resErrorMessage = objectParameter2;
					Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpEntities2.MobspUpdateDocItem(docItemParams, userId, fPId, month, value, registerDatePersian, appType2, languageID, defaultLanguageID, resErrorMessage, resUpdatedDocItemIds, model.CenterId));
					if (!string.IsNullOrEmpty(objectParameter2.Value?.ToString()))
					{
						string text = "";
						string[] array = objectParameter2.Value.ToString().Split(new string[1] { "#|^|#" }, StringSplitOptions.None);
						string[] array2 = array;
						foreach (string text2 in array2)
						{
							if (string.IsNullOrEmpty(text2))
							{
								continue;
							}
							string[] array3 = text2.Split(new string[1] { "|^|" }, StringSplitOptions.None);
							switch (array3[0])
							{
							case "ParseData=Error":
								text = Messages.MobMsgErrorInSentData;
								break;
							case "Tracing=Force":
								text = Messages.MobMsgErrorTracingIsNotSpecified;
								break;
							case "Tracing=New":
							{
								string arg = "";
								if (array3.Length > 1)
								{
									arg = array3[1].Replace("NewTracing=", "") ?? "";
								}
								text = string.Format(Messages.MobMsgErrorCanNotAddNewTracingCode, arg);
								break;
							}
							case "QtyRemainLimit":
							{
								string text3 = "";
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
											text3 = mobspSelectProductsWithId_Result.PrdName ?? "";
										}
									}
								}
								if (string.IsNullOrEmpty(text3))
								{
									text3 = Labels.lblSelected;
								}
								text = string.Format(Messages.MobMsgDraftQuantityRemainLimitExceededI, text3);
								break;
							}
							case "Error":
								text = Messages.MobMsgErrorSubmitDraftItem;
								break;
							}
						}
						if (string.IsNullOrEmpty(text))
						{
							text = array[0];
						}
						message = text;
						status = ServiceResultStatus.Fail;
					}
					else
					{
						data = model.DocItemId;
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<int>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> Letter(UpdateLetterViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
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
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMSpEntities = new CRMSpEntities();
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					string appType = Mobile.Classes.Configuration.AppType;
					short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					ObjectParameter objectParameter = new ObjectParameter("ResUpdatedLetterId", 0);
					ObjectParameter objectParameter2 = new ObjectParameter("ResErrorMessage", "");
					CRMSpEntities cRMSpEntities2 = cRMSpEntities;
					string letterParams = model.LetterParams;
					int? userId = token2.userId;
					short? month = value2;
					string appType2 = appType;
					int? languageID = result;
					int? defaultLanguageID = result2;
					ObjectParameter resUpdatedLetterId = objectParameter;
					ObjectParameter resErrorMessage = objectParameter2;
					Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpEntities2.MobspUpdateLetter(letterParams, userId, month, value, registerDatePersian, appType2, languageID, defaultLanguageID, resErrorMessage, resUpdatedLetterId));
					if (!string.IsNullOrEmpty(objectParameter2.Value?.ToString()))
					{
						string text = "";
						string[] array = objectParameter2.Value.ToString().Split(new string[1] { "#|^|#" }, StringSplitOptions.None);
						string[] array2 = array;
						foreach (string text2 in array2)
						{
							if (!string.IsNullOrEmpty(text2))
							{
								switch (text2.Split(new string[1] { "|^|" }, StringSplitOptions.None)[0])
								{
								case "ParseData=Error":
									text = Messages.MobMsgErrorInSentData;
									break;
								case "LetterNumber=Dup":
									text = Messages.MobMsgLetterNumberIsRepeated;
									break;
								case "Error":
									text = Messages.MobMsgErrorSubmitLetter;
									break;
								}
							}
						}
						if (string.IsNullOrEmpty(text))
						{
							text = array[0];
						}
						message = text;
						status = ServiceResultStatus.Fail;
					}
					else
					{
						data = model.LetterId;
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<int>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> CompanyAddress(UpdateCompanyAddressViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
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
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMSpEntities = new CRMSpEntities();
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					string appType = Mobile.Classes.Configuration.AppType;
					short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					short value3 = short.Parse(Financial.Get().Id.ToString());
					ObjectParameter objectParameter = new ObjectParameter("ResUpdatedId", 0);
					ObjectParameter objectParameter2 = new ObjectParameter("ResErrorMessage", "");
					CRMSpEntities cRMSpEntities2 = cRMSpEntities;
					string companyAddressParams = model.CompanyAddressParams;
					int? userId = token2.userId;
					short? year = value3;
					short? month = value2;
					string appType2 = appType;
					int? languageID = result;
					int? defaultLanguageID = result2;
					ObjectParameter resUpdatedId = objectParameter;
					ObjectParameter resErrorMessage = objectParameter2;
					Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpEntities2.MobspUpdateCompanyAddresses(companyAddressParams, userId, year, month, value, registerDatePersian, appType2, languageID, defaultLanguageID, resErrorMessage, resUpdatedId));
					if (!string.IsNullOrEmpty(objectParameter2.Value?.ToString()))
					{
						string text = "";
						string[] array = objectParameter2.Value.ToString().Split(new string[1] { "#|^|#" }, StringSplitOptions.None);
						string[] array2 = array;
						foreach (string text2 in array2)
						{
							if (!string.IsNullOrEmpty(text2))
							{
								switch (text2.Split(new string[1] { "|^|" }, StringSplitOptions.None)[0])
								{
								case "ParseData=Error":
									text = Messages.MobMsgErrorInSentData;
									break;
								case "ParseData=Empty":
									text = Messages.MobMsgErrorSentDataIsEmpty;
									break;
								case "LetterNumber=Dup":
									text = Messages.MobMsgLetterNumberIsRepeated;
									break;
								case "Error":
									text = Messages.MobMsgErrorSubmitLetter;
									break;
								}
							}
						}
						if (string.IsNullOrEmpty(text))
						{
							text = array[0];
						}
						message = text;
						status = ServiceResultStatus.Fail;
					}
					else
					{
						data = model.CompanyAddressId;
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<int>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<UpdateSerialInfoVIViewModel> UpdateDocItemSerialInfoVI(string serials, string infoVI, string serialSplite = ",", int? cId = null)
	{
		CRMSpEntities cRMSpEntities = null;
		UpdateSerialInfoVIViewModel updateSerialInfoVIViewModel = new UpdateSerialInfoVIViewModel();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMSpEntities = new CRMSpEntities();
					DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
					_ = Mobile.Classes.Configuration.AppType;
					short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					short.Parse(Financial.Get().Id.ToString());
					new UpdateSerialInfoVIViewModel();
					ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
					cRMSpEntities.MobspUpdateSerialInfoVI(serials, serialSplite, infoVI, cId, objectParameter);
					if (!string.IsNullOrEmpty(objectParameter.Value?.ToString()))
					{
						string text = "";
						string[] array = objectParameter.Value.ToString().Split(new string[1] { "#|^|#" }, StringSplitOptions.None);
						foreach (string text2 in array)
						{
							if (!string.IsNullOrEmpty(text2))
							{
								if (text2.Contains("Msg=Duplicate"))
								{
									text = Messages.MobMsgErrorDuplicateSerial;
								}
								else if (text2.Contains("Msg=NotFind"))
								{
									string[] array2 = text2.Split(new string[1] { "||" }, StringSplitOptions.None);
									updateSerialInfoVIViewModel.ExtraData = array2[1];
									text = Messages.MobMsgErrorSerialNotFound;
								}
							}
						}
						status = ServiceResultStatus.Success;
						updateSerialInfoVIViewModel.Result = false;
						message = text;
					}
					else
					{
						updateSerialInfoVIViewModel.Result = true;
						message = "";
						status = ServiceResultStatus.Success;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					updateSerialInfoVIViewModel.Result = false;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				updateSerialInfoVIViewModel.Result = false;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			updateSerialInfoVIViewModel.Result = false;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<UpdateSerialInfoVIViewModel>
		{
			Message = message,
			Data = updateSerialInfoVIViewModel,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> ExitOrderIsFixed(int ordId, int? cId)
	{
		CRMSpEntities cRMSpEntities = null;
		int data = 0;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMSpEntities = new CRMSpEntities();
					if (!UserLogin.IsUserAccess("frmOrder", "actExitIsFixed", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = ordId,
							Status = ServiceResultStatus.Fail
						};
					}
					data = cRMSpEntities.MobspOrderIsFixedExit(ordId);
					message = "";
					status = ServiceResultStatus.Success;
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<int>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> ExitPreOrderIsFixed(int pordId, int? cId)
	{
		CRMSpEntities cRMSpEntities = null;
		int data = 0;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMSpEntities = new CRMSpEntities();
					if (!UserLogin.IsUserAccess("frmPreOrder", "actExitIsFixed", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = pordId,
							Status = ServiceResultStatus.Fail
						};
					}
					data = cRMSpEntities.MobspPreOrderIsFixedExit(pordId);
					message = "";
					status = ServiceResultStatus.Success;
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<int>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> ExitDocIsFixed(int docId, int? cId)
	{
		CRMSpEntities cRMSpEntities = null;
		int data = 0;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMSpEntities = new CRMSpEntities();
					if (!UserLogin.IsUserAccess("frmDoc", "actExitIsFixed", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = docId,
							Status = ServiceResultStatus.Fail
						};
					}
					data = cRMSpEntities.MobspDocIsFixedExit(docId);
					message = "";
					status = ServiceResultStatus.Success;
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<int>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> ExitDraftIsFixed(int docId, int? cId)
	{
		CRMSpEntities cRMSpEntities = null;
		int data = 0;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMSpEntities = new CRMSpEntities();
					if (!UserLogin.IsUserAccess("frmDraft", "actExitIsFixed", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = docId,
							Status = ServiceResultStatus.Fail
						};
					}
					data = cRMSpEntities.MobspDocIsFixedExit(docId);
					message = "";
					status = ServiceResultStatus.Success;
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<int>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> ExitMovementIsFixed(int docId, int? cId)
	{
		CRMSpEntities cRMSpEntities = null;
		int data = 0;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMSpEntities = new CRMSpEntities();
					if (!UserLogin.IsUserAccess("frmWareHouseMovement", "actExitIsFixed", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = docId,
							Status = ServiceResultStatus.Fail
						};
					}
					data = cRMSpEntities.MobspDocIsFixedExit(docId);
					message = "";
					status = ServiceResultStatus.Success;
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<int>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> ExitLetterIsFixed(int letId, int letTypeId, int? cId)
	{
		CRMSpEntities cRMSpEntities = null;
		int data = 0;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMSpEntities = new CRMSpEntities();
					switch (letTypeId)
					{
					case 1:
						if (!UserLogin.IsUserAccess("frmSendLetters", "actExitIsFixed", UserLogin.CurrentUser, cId))
						{
							return new ServiceResult<int>
							{
								Message = Messages.MobMsgErrorAccessLimited,
								Data = letId,
								Status = ServiceResultStatus.Fail
							};
						}
						break;
					case 2:
						if (!UserLogin.IsUserAccess("frmReceiveLetters", "actExitIsFixed", UserLogin.CurrentUser, cId))
						{
							return new ServiceResult<int>
							{
								Message = Messages.MobMsgErrorAccessLimited,
								Data = letId,
								Status = ServiceResultStatus.Fail
							};
						}
						break;
					default:
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = letId,
							Status = ServiceResultStatus.Fail
						};
					}
					data = cRMSpEntities.MobspLetterIsFixedExit(letId);
					message = "";
					status = ServiceResultStatus.Success;
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

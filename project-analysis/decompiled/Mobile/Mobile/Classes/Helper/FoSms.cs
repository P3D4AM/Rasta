using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using CRM.Resources;
using Elmah;
using GSD.Globalization;
using Mobile.Cache.Setting;
using Mobile.Models;
using Mobile.SmsMehrAfraz;

namespace Mobile.Classes.Helper;

public class FoSms
{
	public bool SendSms(FoSmsSendViewModel item, bool? isSendVerification = false, bool? isManualSmsBody = false, int? cId = null, int? foSettingId = null)
	{
		bool result = false;
		CRMEntities cRMEntities = new CRMEntities();
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			FOMobspSelectCrmFoSetting_Result fOMobspSelectCrmFoSetting_Result = Enumerable.FirstOrDefault<FOMobspSelectCrmFoSetting_Result>((IEnumerable<FOMobspSelectCrmFoSetting_Result>)cRMSpEntities.FOMobspSelectCrmFoSetting(lCID, result2, cId, foSettingId));
			FoEmail foEmail = new FoEmail(cId, foSettingId);
			int result3 = 0;
			int.TryParse(fOMobspSelectCrmFoSetting_Result.EmailUserInfoId.ToString(), out result3);
			int result4 = 0;
			int.TryParse(fOMobspSelectCrmFoSetting_Result.EmailSettingId.ToString(), out result4);
			string text = "";
			int num = 0;
			if (fOMobspSelectCrmFoSetting_Result != null)
			{
				if (fOMobspSelectCrmFoSetting_Result.SmsSendingIsActive.HasValue && fOMobspSelectCrmFoSetting_Result.SmsSendingIsActive.GetValueOrDefault())
				{
					string text2 = "";
					int result5 = 0;
					int.TryParse(item.sendSmsMode.ToString(), out result5);
					switch (result5)
					{
					case 1:
					{
						ObjectParameter objectParameter3 = new ObjectParameter("BodyPatternFormulaResult", "");
						cRMSpEntities.FOMobspGetBodyPatternFormulaResult(item.SmsText ?? "", item.CompanyId, item.CompanyPersonId, (!string.IsNullOrEmpty(item.CmpPassword)) ? item.CmpPassword : "", item.OTPCode ?? "", fOMobspSelectCrmFoSetting_Result.FoSettingId, lCID, result2, objectParameter3);
						if (objectParameter3.Value != null && !string.IsNullOrWhiteSpace(objectParameter3.Value.ToString()))
						{
							text2 = objectParameter3.Value.ToString();
						}
						break;
					}
					case 2:
					{
						ObjectParameter objectParameter2 = new ObjectParameter("BodyPatternFormulaResult", "");
						cRMSpEntities.FOMobspGetBodyPatternFormulaResult(item.SmsText ?? "", item.CompanyId, item.CompanyPersonId, (!string.IsNullOrEmpty(item.CmpPassword)) ? item.CmpPassword : "", item.OTPCode ?? "", fOMobspSelectCrmFoSetting_Result.FoSettingId, lCID, result2, objectParameter2);
						if (objectParameter2.Value != null && !string.IsNullOrWhiteSpace(objectParameter2.Value.ToString()))
						{
							text2 = objectParameter2.Value.ToString();
						}
						break;
					}
					default:
						if (isManualSmsBody == false)
						{
							ObjectParameter objectParameter = new ObjectParameter("SmsBodyPatternFormulaResult", "");
							cRMEntities.FOMobspGetSmsBodyPatternFormulaResult(item.CompanyId, item.CompanyPersonId, (!string.IsNullOrEmpty(item.CmpPassword)) ? item.CmpPassword : "", fOMobspSelectCrmFoSetting_Result.FoSettingId, lCID, result2, objectParameter);
							if (objectParameter.Value != null && objectParameter.Value.ToString() != "")
							{
								text2 = objectParameter.Value.ToString();
								if (text2.Length > 2000)
								{
									text2 = text2.Substring(0, 2000);
								}
							}
						}
						else
						{
							text2 = item.SmsText;
							if (text2.Length > 2000)
							{
								text2 = text2.Substring(0, 2000);
							}
						}
						break;
					}
					bool result6 = false;
					bool result7 = false;
					bool.TryParse(fOMobspSelectCrmFoSetting_Result.SmsSendByWeb.ToString(), out result6);
					bool.TryParse(fOMobspSelectCrmFoSetting_Result.SmsSendByGSM.ToString(), out result7);
					if (result6)
					{
						string value = ((!string.IsNullOrEmpty(fOMobspSelectCrmFoSetting_Result.SmsWebServiceUserName)) ? fOMobspSelectCrmFoSetting_Result.SmsWebServiceUserName : null);
						string value2 = ((!string.IsNullOrEmpty(fOMobspSelectCrmFoSetting_Result.SmsWebServicePassword)) ? fOMobspSelectCrmFoSetting_Result.SmsWebServicePassword : null);
						string text3 = ((!string.IsNullOrEmpty(fOMobspSelectCrmFoSetting_Result.SmsWebServiceNumber)) ? fOMobspSelectCrmFoSetting_Result.SmsWebServiceNumber : null);
						if (!string.IsNullOrWhiteSpace(value) && !string.IsNullOrWhiteSpace(value2) && !string.IsNullOrWhiteSpace(text3))
						{
							FOMobspSelectSmsSetting_Result fOMobspSelectSmsSetting_Result = Enumerable.FirstOrDefault<FOMobspSelectSmsSetting_Result>((IEnumerable<FOMobspSelectSmsSetting_Result>)cRMEntities.FOMobspSelectSmsSetting());
							decimal faCost = default(decimal);
							decimal enCost = default(decimal);
							decimal decSmsLastCreditAmount = default(decimal);
							int result8 = 0;
							if (fOMobspSelectSmsSetting_Result != null)
							{
								int.TryParse(fOMobspSelectSmsSetting_Result.ProviderId.ToString(), out result8);
							}
							string msgError = "";
							if (result8 == 14)
							{
								if (fOMobspSelectSmsSetting_Result != null)
								{
									decimal.TryParse(fOMobspSelectSmsSetting_Result.FaCost.ToString(), out faCost);
									decimal.TryParse(fOMobspSelectSmsSetting_Result.EnCost.ToString(), out enCost);
									decimal.TryParse(fOMobspSelectSmsSetting_Result.LastCreditAmount.ToString(), out decSmsLastCreditAmount);
								}
							}
							else
							{
								MehrAfraz_GetUserInfo(ref faCost, ref enCost, ref decSmsLastCreditAmount, ref msgError, cId, foSettingId);
							}
							if (!string.IsNullOrWhiteSpace(msgError))
							{
								EmailSendViewModel item2 = new EmailSendViewModel
								{
									EmailSubject = "Error log in FrontOffice (Send SMS)",
									EmailBody = msgError,
									PriorityId = 0,
									EmailUsersInfoId = result3,
									EmailSettingId = result4,
									EmailAddress = "",
									EmailCmpId = null,
									EmailCmpPrsId = null,
									EmailCmpPrjId = null,
									EmailCmpPrsName = null,
									EmailCmpName = null,
									EmailPrsJob = null,
									StatusId = 1,
									IsLogEmailAdmin = true,
									CmpPassword = ""
								};
								foEmail.SendEmail(item2);
								num++;
							}
							if (num == 0)
							{
								int sId = -1;
								int sIdTemp = Enumerable.FirstOrDefault<int>(cRMEntities.Database.SqlQuery<int>("Select dbo.SmsfnReturnSID()", Array.Empty<object>()));
								long[] result9 = new long[1];
								string msgError2 = "";
								int num2 = 0;
								string text4 = "";
								int num3 = 0;
								int num4 = ReturnSmsBodyLength(text2);
								if (num4 > 0)
								{
									num2 = ReturnSmsBodyCountLatin(num4);
									decimal num5 = enCost;
									text4 = "EN";
									_ = num5 * (decimal)num2;
								}
								else if (num4 < 0)
								{
									num4 *= -1;
									num2 = ReturnSmsBodyCountFarsi(num4);
									decimal num6 = faCost;
									text4 = "FA";
									_ = num6 * (decimal)num2;
								}
								if (text4 == "EN")
								{
									num3 = 1;
								}
								else if (text4 == "FA")
								{
									num3 = 2;
								}
								string[] array = new string[1];
								string[] array2 = new string[1];
								long[] lstGetId = new long[1];
								int[] array3 = new int[1];
								string[] array4 = new string[1];
								int[] array5 = new int[1];
								string[] array6 = new string[1];
								array[0] = item.PrsMobile;
								array2[0] = text2;
								lstGetId[0] = -1L;
								array3[0] = 1;
								array4[0] = text3;
								array5[0] = num3;
								array6[0] = "";
								if (result8 != 14)
								{
									if (isSendVerification ?? false)
									{
										MehrAfraz_SendSmsByVerification(array[0], item.CmpPassword, ref sIdTemp, ref msgError2, ref lstGetId, ref result9, cId, foSettingId);
									}
									else
									{
										MehrAfraz_SendSms(array, array2, array3, array4, array5, array6, ref sIdTemp, ref msgError2, ref lstGetId, ref result9, cId, foSettingId);
									}
								}
								if (result9[0] == -5000)
								{
									EmailSendViewModel item2 = new EmailSendViewModel
									{
										EmailSubject = "Error log in FrontOffice (Send SMS)",
										EmailBody = msgError2,
										PriorityId = 0,
										EmailUsersInfoId = result3,
										EmailSettingId = result4,
										EmailAddress = "",
										EmailCmpId = null,
										EmailCmpPrsId = null,
										EmailCmpPrjId = null,
										EmailCmpPrsName = null,
										EmailCmpName = null,
										EmailPrsJob = null,
										StatusId = 1,
										IsLogEmailAdmin = true,
										CmpPassword = ""
									};
									foEmail.SendEmail(item2);
								}
								else if (!InsertSms(item.CompanyId, item.CompanyPersonId, text3, enCost, faCost, text2, sId, result9[0], 1, 0, item.OTPCode ?? "", item.PrsMobile ?? "", cId, foSettingId))
								{
									text = Messages.FOMsgErrorInInsertSmsSend;
									EmailSendViewModel item2 = new EmailSendViewModel
									{
										EmailSubject = "Error log in FrontOffice (Send SMS)",
										EmailBody = text,
										PriorityId = 0,
										EmailUsersInfoId = result3,
										EmailSettingId = result4,
										EmailAddress = "",
										EmailCmpId = null,
										EmailCmpPrsId = null,
										EmailCmpPrjId = null,
										EmailCmpPrsName = null,
										EmailCmpName = null,
										EmailPrsJob = null,
										StatusId = 1,
										IsLogEmailAdmin = true,
										CmpPassword = ""
									};
									foEmail.SendEmail(item2);
								}
							}
						}
						else
						{
							text = Messages.FOspMsgErrorInReadingSmsSetting;
							EmailSendViewModel item2 = new EmailSendViewModel
							{
								EmailSubject = "Error log in FrontOffice (Send SMS)",
								EmailBody = text,
								PriorityId = 0,
								EmailUsersInfoId = result3,
								EmailSettingId = result4,
								EmailAddress = "",
								EmailCmpId = null,
								EmailCmpPrsId = null,
								EmailCmpPrjId = null,
								EmailCmpPrsName = null,
								EmailCmpName = null,
								EmailPrsJob = null,
								StatusId = 1,
								IsLogEmailAdmin = true,
								CmpPassword = ""
							};
							foEmail.SendEmail(item2);
						}
					}
					if (result7)
					{
						FOMobspSelectSmsSetting_Result fOMobspSelectSmsSetting_Result2 = Enumerable.FirstOrDefault<FOMobspSelectSmsSetting_Result>((IEnumerable<FOMobspSelectSmsSetting_Result>)cRMEntities.FOMobspSelectSmsSetting());
						decimal num7 = default(decimal);
						decimal num8 = default(decimal);
						decimal result10 = default(decimal);
						decimal result11 = default(decimal);
						if (fOMobspSelectSmsSetting_Result2 != null)
						{
							decimal.TryParse(fOMobspSelectSmsSetting_Result2.FaCost.ToString(), out result10);
							decimal.TryParse(fOMobspSelectSmsSetting_Result2.EnCost.ToString(), out result11);
							num7 = result10;
							num8 = result11;
						}
						int sId2 = ReturnSid();
						string text5 = "+98";
						FOMobspSelectSmsGSMModemSetting_Result fOMobspSelectSmsGSMModemSetting_Result = Enumerable.FirstOrDefault<FOMobspSelectSmsGSMModemSetting_Result>((IEnumerable<FOMobspSelectSmsGSMModemSetting_Result>)cRMEntities.FOMobspSelectSmsGSMModemSetting());
						if (fOMobspSelectSmsGSMModemSetting_Result != null)
						{
							text5 = fOMobspSelectSmsGSMModemSetting_Result.SimNumber ?? "";
						}
						int num9 = 0;
						string text6 = "";
						int num10 = 0;
						int num11 = ReturnSmsBodyLength(text2);
						if (num11 > 0)
						{
							num9 = ReturnSmsBodyCountLatin(num11);
							decimal num12 = num8;
							text6 = "EN";
							_ = num12 * (decimal)num9;
						}
						else if (num11 < 0)
						{
							num11 *= -1;
							num9 = ReturnSmsBodyCountFarsi(num11);
							decimal num13 = num7;
							text6 = "FA";
							_ = num13 * (decimal)num9;
						}
						if (text6 == "EN")
						{
							num10 = 1;
						}
						else if (text6 == "FA")
						{
							num10 = 2;
						}
						string[] array7 = new string[1];
						string[] array8 = new string[1];
						long[] array9 = new long[1];
						int[] array10 = new int[1];
						string[] array11 = new string[1];
						int[] array12 = new int[1];
						string[] array13 = new string[1];
						array7[0] = item.PrsMobile;
						array8[0] = text2;
						array9[0] = -1L;
						array10[0] = 1;
						array11[0] = text5;
						array12[0] = num10;
						array13[0] = "";
						if (!InsertSms(item.CompanyId, item.CompanyPersonId, text5, num8, num7, text2, sId2, 0L, 21, -2000, item.OTPCode ?? "", item.PrsMobile ?? "", cId, foSettingId))
						{
							text = Messages.FOMsgErrorInInsertSmsSend;
							EmailSendViewModel item2 = new EmailSendViewModel
							{
								EmailSubject = "Error log in FrontOffice (Send SMS)",
								EmailBody = text,
								PriorityId = 0,
								EmailUsersInfoId = result3,
								EmailSettingId = result4,
								EmailAddress = "",
								EmailCmpId = null,
								EmailCmpPrsId = null,
								EmailCmpPrjId = null,
								EmailCmpPrsName = null,
								EmailCmpName = null,
								EmailPrsJob = null,
								StatusId = 1,
								IsLogEmailAdmin = true,
								CmpPassword = ""
							};
							foEmail.SendEmail(item2);
						}
					}
				}
			}
			else
			{
				text = Messages.FOMsgErrorInReadingSetting + " (FOSetting)";
			}
		}
		catch (Exception e)
		{
			result = false;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return result;
	}

	public void MehrAfraz_SendSms(string[] lstMobile, string[] lstBody, int[] lstCmessage, string[] lstFromNumber, int[] lstTypeUnicodeMessage, string[] lstSchedulDate, ref int sIdTemp, ref string msgError, ref long[] lstGetId, ref long[] result, int? cId = null, int? foSettingId = null)
	{
		ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
		result = new long[1];
		result[0] = -7L;
		msgError = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			new CRMEntities();
			FOMobspSelectCrmFoSetting_Result fOMobspSelectCrmFoSetting_Result = Enumerable.FirstOrDefault<FOMobspSelectCrmFoSetting_Result>((IEnumerable<FOMobspSelectCrmFoSetting_Result>)new CRMSpEntities().FOMobspSelectCrmFoSetting(lCID, result2, cId, foSettingId));
			if (fOMobspSelectCrmFoSetting_Result == null)
			{
				return;
			}
			string cDomainname = "ideal";
			string text = ((!string.IsNullOrEmpty(fOMobspSelectCrmFoSetting_Result.SmsWebServiceUserName)) ? fOMobspSelectCrmFoSetting_Result.SmsWebServiceUserName : null);
			string text2 = ((!string.IsNullOrEmpty(fOMobspSelectCrmFoSetting_Result.SmsWebServicePassword)) ? fOMobspSelectCrmFoSetting_Result.SmsWebServicePassword : null);
			if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(text2))
			{
				sIdTemp = ReturnSid();
				while (result[0] == -7)
				{
					lstGetId[0] = sIdTemp;
					result = serviceSoapClient.SendSms1To1(cDomainname, text, text2, lstBody, lstMobile, lstGetId, lstCmessage, lstFromNumber, lstTypeUnicodeMessage, lstSchedulDate, 2, 0, 0);
					sIdTemp++;
				}
				if (result[0].ToString().Length < 4)
				{
					msgError = serviceSoapClient.ShowError(result[0].ToString(), "FA");
					result[0] = -5000L;
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result[0] = -5000L;
			msgError = ex.Message;
		}
	}

	public void MehrAfraz_GetUserInfo(ref decimal faCost, ref decimal enCost, ref decimal decSmsLastCreditAmount, ref string msgError, int? cId = null, int? foSettingId = null)
	{
		ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
		string[] array = new string[10];
		msgError = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			new CRMEntities();
			FOMobspSelectCrmFoSetting_Result fOMobspSelectCrmFoSetting_Result = Enumerable.FirstOrDefault<FOMobspSelectCrmFoSetting_Result>((IEnumerable<FOMobspSelectCrmFoSetting_Result>)new CRMSpEntities().FOMobspSelectCrmFoSetting(lCID, result, cId, foSettingId));
			if (fOMobspSelectCrmFoSetting_Result == null)
			{
				return;
			}
			string cDomainName = "ideal";
			string text = ((!string.IsNullOrEmpty(fOMobspSelectCrmFoSetting_Result.SmsWebServiceUserName)) ? fOMobspSelectCrmFoSetting_Result.SmsWebServiceUserName : null);
			string text2 = ((!string.IsNullOrEmpty(fOMobspSelectCrmFoSetting_Result.SmsWebServicePassword)) ? fOMobspSelectCrmFoSetting_Result.SmsWebServicePassword : null);
			if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(text2))
			{
				array = serviceSoapClient.GetuserInfo(text, text2, cDomainName);
				if (array.Length < 3)
				{
					msgError = serviceSoapClient.ShowError(array[0], "FA");
					return;
				}
				decimal.TryParse(array[5], out faCost);
				decimal.TryParse(array[6], out enCost);
				decimal.TryParse(array[1], out var result2);
				decimal.TryParse(result2.ToString(), out decSmsLastCreditAmount);
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
		}
	}

	public void MehrAfraz_SendSmsByVerification(string mobile, string body, ref int sIdTemp, ref string msgError, ref long[] lstGetId, ref long[] result, int? cId = null, int? foSettingId = null)
	{
		ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
		result = new long[1];
		result[0] = -7L;
		msgError = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			new CRMEntities();
			FOMobspSelectCrmFoSetting_Result fOMobspSelectCrmFoSetting_Result = Enumerable.FirstOrDefault<FOMobspSelectCrmFoSetting_Result>((IEnumerable<FOMobspSelectCrmFoSetting_Result>)new CRMSpEntities().FOMobspSelectCrmFoSetting(lCID, result2, cId, foSettingId));
			if (fOMobspSelectCrmFoSetting_Result == null)
			{
				return;
			}
			string cDomainName = "ideal";
			string text = ((!string.IsNullOrEmpty(fOMobspSelectCrmFoSetting_Result.SmsWebServiceUserName)) ? fOMobspSelectCrmFoSetting_Result.SmsWebServiceUserName : null);
			string text2 = ((!string.IsNullOrEmpty(fOMobspSelectCrmFoSetting_Result.SmsWebServicePassword)) ? fOMobspSelectCrmFoSetting_Result.SmsWebServicePassword : null);
			int result3 = 0;
			int.TryParse(fOMobspSelectCrmFoSetting_Result.SmsVerificationId.ToString(), out result3);
			if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(text2) && result3 > 0)
			{
				sIdTemp = ReturnSid();
				while (result[0] == -7)
				{
					lstGetId[0] = sIdTemp;
					int result4 = 0;
					int.TryParse(body, out result4);
					long.TryParse(serviceSoapClient.SENDVERIFICATIONCODE(cDomainName, text, text2, mobile, result3, result4), out result[0]);
					sIdTemp++;
				}
				if (result[0].ToString().Length < 4)
				{
					msgError = serviceSoapClient.ShowError(result[0].ToString(), "FA");
					result[0] = -5000L;
				}
			}
			else
			{
				msgError = Messages.FOMsgErrorInReadingSetting + " (FOSetting (SMS-Verification))";
				result[0] = -5000L;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result[0] = -5000L;
			msgError = ex.Message;
		}
	}

	private bool InsertSms(int companyId, int? companyPersonId, string fromNumber, decimal enCost, decimal faCost, string smsBody, int sId, long refNumbers, int sendType, int statusId, string otp, string mobNumber = "", int? cId = null, int? foSettingId = null)
	{
		bool result = false;
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			cRMEntities = new CRMEntities();
			cRMSpEntities = new CRMSpEntities();
			DateTime now = DateTime.Now;
			string text = now.ToString("yyyyMMdd", new PersianCulture());
			short value = short.Parse(now.ToString("yyyy", new PersianCulture()));
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Messages.FOTicketErjaShow;
			string appType = Configuration.AppType;
			string text2 = DateTimeClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
			string text3 = now.ToString("HH:mm:ss");
			int value3 = -20;
			if (!string.IsNullOrWhiteSpace(otp) && !string.IsNullOrWhiteSpace(smsBody))
			{
				smsBody = smsBody.Replace(otp, "[#کد تایید OTP#]");
			}
			int result3 = 0;
			int result4 = 0;
			int result5 = 0;
			IIdentity identity = Thread.CurrentPrincipal.Identity;
			if (companyPersonId.GetValueOrDefault() != 0)
			{
				int.TryParse(companyPersonId.ToString(), out result3);
			}
			if (companyId != 0)
			{
				int.TryParse(companyId.ToString(), out result5);
			}
			if (result5 == 0 && identity.Name != null && !string.IsNullOrWhiteSpace(identity.Name))
			{
				string[] array = identity.Name.Split(new char[1] { '-' });
				if (array != null && array.Length >= 1)
				{
					int.TryParse(array[0], out result5);
					if (array.Length >= 2)
					{
						int.TryParse(array[1], out result3);
					}
					if (array.Length >= 3)
					{
						int.TryParse(array[2], out result4);
					}
				}
			}
			if (result4 == 0)
			{
				result4 = ((result3 == 0) ? 1 : 2);
			}
			if (string.IsNullOrWhiteSpace(mobNumber))
			{
				FOMobspLoadCompanyLoginInfo_Result fOMobspLoadCompanyLoginInfo_Result = Enumerable.FirstOrDefault<FOMobspLoadCompanyLoginInfo_Result>((IEnumerable<FOMobspLoadCompanyLoginInfo_Result>)cRMSpEntities.FOMobspLoadCompanyLoginInfo(result5, lCID, result2, "", "", "", result4, companyPersonId, cId, foSettingId));
				if (fOMobspLoadCompanyLoginInfo_Result != null)
				{
					mobNumber = fOMobspLoadCompanyLoginInfo_Result.cmpMobile;
					if (fOMobspLoadCompanyLoginInfo_Result.CompanyPersonID.GetValueOrDefault() != 0 && !string.IsNullOrWhiteSpace(fOMobspLoadCompanyLoginInfo_Result.PersonMobile))
					{
						mobNumber = fOMobspLoadCompanyLoginInfo_Result.PersonMobile;
					}
				}
			}
			ObjectParameter objectParameter = new ObjectParameter("Result", 0);
			ObjectParameter objectParameter2 = new ObjectParameter("ErrorMessage", "");
			int num = cRMEntities.FOMobspInsertSendSms(companyId, companyPersonId, fromNumber, enCost, faCost, smsBody, sId, refNumbers, text2, text, text3, value3, value, value2, text, appType, result2, errorMessage: objectParameter2, result: objectParameter, sendType: sendType, statusId: statusId, oTP: otp, mobile: mobNumber, centerId: cId);
			int result7 = 0;
			int.TryParse(num.ToString(), out result7);
			if (result7 > 0)
			{
				if (objectParameter2.Value != null && objectParameter2.Value.ToString() != "")
				{
					objectParameter2.Value.ToString();
					result = false;
					_ = Messages.FOMsgErrorInInsertSmsSend;
				}
				else
				{
					int num2 = ((objectParameter != null && objectParameter.Value.ToString() != "0") ? int.Parse(objectParameter.Value.ToString()) : 0);
					result = ((num2 > 0 && num2 > 0) ? true : false);
				}
			}
			else
			{
				result = false;
			}
		}
		catch (Exception e)
		{
			result = false;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
			if (cRMSpEntities != null)
			{
				cRMEntities.Dispose();
			}
		}
		return result;
	}

	public int ReturnSmsBodyLength(string body)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int result = 0;
		for (int i = 0; i < body.Length; i++)
		{
			int num6 = char.Parse(body[i].ToString().ToLower());
			if (num6 < 97 || num6 > 122)
			{
				switch (num6)
				{
				case 32:
					break;
				case 48:
				case 49:
				case 50:
				case 51:
				case 52:
				case 53:
				case 54:
				case 55:
				case 56:
				case 57:
					num4++;
					continue;
				default:
					if ((num6 >= 33 && num6 <= 47) || (num6 >= 58 && num6 <= 64) || (num6 >= 91 && num6 <= 96) || (num6 >= 123 && num6 <= 126))
					{
						num3++;
						continue;
					}
					switch (num6)
					{
					case 10:
						num5++;
						break;
					default:
						num2++;
						break;
					case 13:
						break;
					}
					continue;
				}
			}
			num++;
		}
		if (num2 > 0)
		{
			result = -(num2 + num + num3 + num4 + num5);
		}
		if (num2 == 0)
		{
			result = num2 + num + num3 + num4 + num5;
		}
		return result;
	}

	public int ReturnSmsBodyCountLatin(int len)
	{
		int num = len;
		int num2 = 0;
		while (num > 0)
		{
			num2++;
			if (num2 == 1)
			{
				num -= 159;
			}
			else if (num2 == 2)
			{
				num = num - 146 - 1;
			}
			else if (num2 > 2)
			{
				num = num - 152 - 1;
			}
		}
		return num2;
	}

	public int ReturnSmsBodyCountFarsi(int len)
	{
		int num = len;
		int num2 = 0;
		while (num > 0)
		{
			num2++;
			if (num2 == 1)
			{
				num -= 70;
			}
			else if (num2 == 2)
			{
				num = num - 63 - 1;
			}
			else if (num2 > 2)
			{
				num = num - 66 - 1;
			}
		}
		return num2;
	}

	public int ReturnSid()
	{
		int result = 0;
		CRMEntities cRMEntities = new CRMEntities();
		try
		{
			result = Enumerable.FirstOrDefault<int>(cRMEntities.Database.SqlQuery<int>("Select dbo.SmsfnReturnSID()", Array.Empty<object>()));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities.Dispose();
		}
		return result;
	}
}

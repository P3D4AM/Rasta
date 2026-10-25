using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.Script.Serialization;
using CRM.General.Security;
using CRM.OtherWebServices.SmsBParsian;
using CRM.OtherWebServices.SmsCandoo;
using CRM.OtherWebServices.SmsNimadd;
using CRM.OtherWebServices.SmsSunWay;
using CRM.Resources;
using Elmah;
using GSD.Globalization;
using Mobile.Cache.Setting;
using Mobile.Models;
using Mobile.SmsAfzar;
using Mobile.SmsFaraPayamak;
using Mobile.SmsFor;
using Mobile.SmsKaveNegar;
using Mobile.SmsMehrAfraz;
using Mobile.SmsPayamResan;
using Mobile.SmsTehranPayamak;
using Mobile.SmsWebOne;
using Mobile.ir.smsline.webservice;
using Newtonsoft.Json;

namespace Mobile.Classes.Helper;

public class Sms
{
	public string SendSmsSingle(SmsSendViewModel newSms, bool isCodeVerification = false, int verificationCode = 0)
	{
		string result = "";
		int sid = newSms.Sid;
		int num = sid;
		long[] result2 = new long[1];
		string[] result3 = new string[1];
		long result4 = 0L;
		string msgError = "";
		try
		{
			if (isCodeVerification)
			{
				newSms.SmsSendBody = verificationCode.ToString();
			}
			int freeSmsCount;
			SmsSettingInfoViewModel smsSetting = GetSmsSetting(out freeSmsCount);
			int num2 = 0;
			string text = "";
			int typeUnicodeMessage = 0;
			int num3 = 1;
			double userCost = 0.0;
			int num4 = ReturnSmsBodyLength(newSms.SmsSendBody);
			if (num4 > 0)
			{
				num2 = ReturnSmsBodyCountLatin(num4);
				num3 = int.Parse(smsSetting.SmsWsEnCost);
				text = "EN";
				userCost = num3 * num2;
			}
			else if (num4 < 0)
			{
				num4 *= -1;
				num2 = ReturnSmsBodyCountFarsi(num4);
				num3 = int.Parse(smsSetting.SmsWsFaCost);
				text = "FA";
				userCost = num3 * num2;
			}
			if (text == "EN")
			{
				typeUnicodeMessage = 1;
			}
			else if (text == "FA")
			{
				typeUnicodeMessage = 2;
			}
			newSms.SmsBodyCount = num2;
			newSms.SmsbodyCost = num3;
			newSms.SmsBodyLangType = text;
			newSms.TypeUnicodeMessage = typeUnicodeMessage;
			newSms.UserCost = userCost;
			string[] array = new string[1];
			string[] array2 = new string[1];
			long[] lstGetId = new long[1];
			int[] array3 = new int[1];
			string[] array4 = new string[1];
			int[] array5 = new int[1];
			string[] array6 = new string[1];
			array[0] = newSms.SmsToNumber;
			array2[0] = newSms.SmsSendBody;
			lstGetId[0] = newSms.Sid;
			array3[0] = newSms.Cmessage;
			array4[0] = smsSetting.SmsWsFromNumber;
			array5[0] = newSms.TypeUnicodeMessage;
			array6[0] = "";
			if (!VersionBuyer.SMS && freeSmsCount <= 0)
			{
				result = Messages.msgNotAccessWebServiceSms;
				return result;
			}
			if (!smsSetting.SmsSendIsActive && freeSmsCount <= 0)
			{
				result = Messages.MobMsgErrorDeactiveServiceSendSms;
				return result;
			}
			if (!string.IsNullOrEmpty(smsSetting.SmsWsUserName) && !string.IsNullOrEmpty(smsSetting.SmsWsPassword) && !string.IsNullOrEmpty(smsSetting.SmsWsDomainNamed) && !string.IsNullOrEmpty(newSms.SmsSendBody) && !string.IsNullOrEmpty(newSms.SmsToNumber) && newSms.SmsNumberCount == 1)
			{
				num = ReturnSid();
				sid = num;
				if (smsSetting.SmsProviderId == 1)
				{
					if (isCodeVerification)
					{
						MehrAfraz_SENDVERIFICATIONCODE(array[0], verificationCode, ref num, ref msgError, ref lstGetId, ref result2);
						if (result2[0] != -5000)
						{
							if (InsertSendedSms(newSms.UserId, newSms.SendType, newSms.SmsSendTopic, sid, smsSetting.SmsWsFromNumber, newSms.SmsSendBody, newSms.SmsBodyCount, newSms.SmsBodyLangType, newSms.SmsbodyCost, newSms.SmsNumberCount, newSms.SmsToNumber, result2[0].ToString(), newSms.SmsNumberCount * newSms.SmsBodyCount, newSms.SmsNumberCount * newSms.SmsBodyCount * newSms.SmsbodyCost, newSms.UserId, newSms.CompaniesId, newSms.CompanyPersonsId, newSms.Cmessage, newSms.sendPriority, 0, null, newSms.CenterId) <= 0)
							{
								result = Messages.msgErrorInsertSmsToDb;
							}
							return result;
						}
						result = msgError;
						return result;
					}
					MehrAfraz_SendSms1To1(array, array2, array3, array4, array5, array6, ref num, ref msgError, ref lstGetId, ref result2);
					if (result2[0] != -5000)
					{
						if (InsertSendedSms(newSms.UserId, newSms.SendType, newSms.SmsSendTopic, sid, smsSetting.SmsWsFromNumber, newSms.SmsSendBody, newSms.SmsBodyCount, newSms.SmsBodyLangType, newSms.SmsbodyCost, newSms.SmsNumberCount, newSms.SmsToNumber, result2[0].ToString(), newSms.SmsNumberCount * newSms.SmsBodyCount, newSms.SmsNumberCount * newSms.SmsBodyCount * newSms.SmsbodyCost, newSms.UserId, newSms.CompaniesId, newSms.CompanyPersonsId, newSms.Cmessage, newSms.sendPriority, 0, null, newSms.CenterId) <= 0)
						{
							result = Messages.msgErrorInsertSmsToDb;
						}
						return result;
					}
					result = msgError;
					return result;
				}
				if (smsSetting.SmsProviderId == 2)
				{
					long result5 = 0L;
					SMSLine_SendSms_Single(array[0], array2[0], smsSetting.SmsWsFromNumber, ref msgError, ref result5);
					if (result5 > 0)
					{
						if (InsertSendedSms(newSms.UserId, newSms.SendType, newSms.SmsSendTopic, sid, smsSetting.SmsWsFromNumber, newSms.SmsSendBody, newSms.SmsBodyCount, newSms.SmsBodyLangType, newSms.SmsbodyCost, newSms.SmsNumberCount, newSms.SmsToNumber, result5.ToString(), newSms.SmsNumberCount * newSms.SmsBodyCount, newSms.SmsNumberCount * newSms.SmsBodyCount * newSms.SmsbodyCost, newSms.UserId, newSms.CompaniesId, newSms.CompanyPersonsId, newSms.Cmessage, newSms.sendPriority, 0, null, newSms.CenterId) <= 0)
						{
							result = Messages.msgErrorInsertSmsToDb;
						}
						return result;
					}
					result = msgError;
					return result;
				}
				if (smsSetting.SmsProviderId == 3)
				{
					FaraPayamak_SendSms1To1(array, array2[0], array3[0], smsSetting.SmsWsFromNumber, ref msgError, ref result2);
					if (result2[0] != -5000)
					{
						if (InsertSendedSms(newSms.UserId, newSms.SendType, newSms.SmsSendTopic, sid, smsSetting.SmsWsFromNumber, newSms.SmsSendBody, newSms.SmsBodyCount, newSms.SmsBodyLangType, newSms.SmsbodyCost, newSms.SmsNumberCount, newSms.SmsToNumber, result2[0].ToString(), newSms.SmsNumberCount * newSms.SmsBodyCount, newSms.SmsNumberCount * newSms.SmsBodyCount * newSms.SmsbodyCost, newSms.UserId, newSms.CompaniesId, newSms.CompanyPersonsId, newSms.Cmessage, newSms.sendPriority, 0, null, newSms.CenterId) <= 0)
						{
							result = Messages.msgErrorInsertSmsToDb;
						}
						return result;
					}
					result = msgError;
					return result;
				}
				if (smsSetting.SmsProviderId == 4)
				{
					Asanak_SendSms1To1(array, array2[0], smsSetting.SmsWsFromNumber, ref msgError, ref result2);
					if (result2[0] != -5000)
					{
						if (InsertSendedSms(newSms.UserId, newSms.SendType, newSms.SmsSendTopic, sid, smsSetting.SmsWsFromNumber, newSms.SmsSendBody, newSms.SmsBodyCount, newSms.SmsBodyLangType, newSms.SmsbodyCost, newSms.SmsNumberCount, newSms.SmsToNumber, result2[0].ToString(), newSms.SmsNumberCount * newSms.SmsBodyCount, newSms.SmsNumberCount * newSms.SmsBodyCount * newSms.SmsbodyCost, newSms.UserId, newSms.CompaniesId, newSms.CompanyPersonsId, newSms.Cmessage, newSms.sendPriority, 0, null, newSms.CenterId) <= 0)
						{
							result = Messages.msgErrorInsertSmsToDb;
						}
						return result;
					}
					result = msgError;
					return result;
				}
				if (smsSetting.SmsProviderId == 5)
				{
					PayamResan_SendSms_Single(array, array2[0], array3[0], smsSetting.SmsWsFromNumber, ref msgError, ref result2);
					if (result2[0] != -5000)
					{
						if (InsertSendedSms(newSms.UserId, newSms.SendType, newSms.SmsSendTopic, sid, smsSetting.SmsWsFromNumber, newSms.SmsSendBody, newSms.SmsBodyCount, newSms.SmsBodyLangType, newSms.SmsbodyCost, newSms.SmsNumberCount, newSms.SmsToNumber, result2[0].ToString(), newSms.SmsNumberCount * newSms.SmsBodyCount, newSms.SmsNumberCount * newSms.SmsBodyCount * newSms.SmsbodyCost, newSms.UserId, newSms.CompaniesId, newSms.CompanyPersonsId, newSms.Cmessage, newSms.sendPriority, 0, null, newSms.CenterId) <= 0)
						{
							result = Messages.msgErrorInsertSmsToDb;
						}
						return result;
					}
					result = msgError;
					return result;
				}
				if (smsSetting.SmsProviderId == 6)
				{
					KaveNegar_SendSms_Single(array, array2[0], array3[0], smsSetting.SmsWsFromNumber, ref msgError, ref result2);
					if (result2[0] != -5000)
					{
						if (InsertSendedSms(newSms.UserId, newSms.SendType, newSms.SmsSendTopic, sid, smsSetting.SmsWsFromNumber, newSms.SmsSendBody, newSms.SmsBodyCount, newSms.SmsBodyLangType, newSms.SmsbodyCost, newSms.SmsNumberCount, newSms.SmsToNumber, result2[0].ToString(), newSms.SmsNumberCount * newSms.SmsBodyCount, newSms.SmsNumberCount * newSms.SmsBodyCount * newSms.SmsbodyCost, newSms.UserId, newSms.CompaniesId, newSms.CompanyPersonsId, newSms.Cmessage, newSms.sendPriority, 0, null, newSms.CenterId) <= 0)
						{
							result = Messages.msgErrorInsertSmsToDb;
						}
						return result;
					}
					result = msgError;
					return result;
				}
				if (smsSetting.SmsProviderId == 7)
				{
					TehranPayamak_SendSms1To1(array, array2[0], array3[0], smsSetting.SmsWsFromNumber, ref msgError, ref result2);
					if (result2[0] != -5000)
					{
						if (InsertSendedSms(newSms.UserId, newSms.SendType, newSms.SmsSendTopic, sid, smsSetting.SmsWsFromNumber, newSms.SmsSendBody, newSms.SmsBodyCount, newSms.SmsBodyLangType, newSms.SmsbodyCost, newSms.SmsNumberCount, newSms.SmsToNumber, result2[0].ToString(), newSms.SmsNumberCount * newSms.SmsBodyCount, newSms.SmsNumberCount * newSms.SmsBodyCount * newSms.SmsbodyCost, newSms.UserId, newSms.CompaniesId, newSms.CompanyPersonsId, newSms.Cmessage, newSms.sendPriority, 0, null, newSms.CenterId) <= 0)
						{
							result = Messages.msgErrorInsertSmsToDb;
						}
						return result;
					}
					result = msgError;
					return result;
				}
				if (smsSetting.SmsProviderId == 8)
				{
					SmsFor_SendSms1To1(array, array2, array3[0], array4[0], ref msgError, ref result2);
					if (result2[0] == -5000)
					{
						result = msgError;
						return result;
					}
					result = ((InsertSendedSms(newSms.UserId, newSms.SendType, newSms.SmsSendTopic, sid, smsSetting.SmsWsFromNumber, newSms.SmsSendBody, newSms.SmsBodyCount, newSms.SmsBodyLangType, newSms.SmsbodyCost, newSms.SmsNumberCount, newSms.SmsToNumber, result2[0].ToString(), newSms.SmsNumberCount * newSms.SmsBodyCount, newSms.SmsNumberCount * newSms.SmsBodyCount * newSms.SmsbodyCost, newSms.UserId, newSms.CompaniesId, newSms.CompanyPersonsId, newSms.Cmessage, newSms.sendPriority, 0, null, newSms.CenterId) <= 0) ? Messages.msgErrorInsertSmsToDb : ("1|" + Messages.msgSuccessSendSms + "|" + result2[0]));
					return result;
				}
				if (smsSetting.SmsProviderId == 9)
				{
					SmsAfzar_SendSms1To1(array, array2, array3[0], array4, ref msgError, ref result2);
					if (result2[0] == -5000)
					{
						result = msgError;
						return result;
					}
					result = ((InsertSendedSms(newSms.UserId, newSms.SendType, newSms.SmsSendTopic, sid, smsSetting.SmsWsFromNumber, newSms.SmsSendBody, newSms.SmsBodyCount, newSms.SmsBodyLangType, newSms.SmsbodyCost, newSms.SmsNumberCount, newSms.SmsToNumber, result2[0].ToString(), newSms.SmsNumberCount * newSms.SmsBodyCount, newSms.SmsNumberCount * newSms.SmsBodyCount * newSms.SmsbodyCost, newSms.UserId, newSms.CompaniesId, newSms.CompanyPersonsId, newSms.Cmessage, newSms.sendPriority, 0, null, newSms.CenterId) <= 0) ? Messages.msgErrorInsertSmsToDb : ("1|" + Messages.msgSuccessSendSms + "|" + result2[0]));
					return result;
				}
				if (smsSetting.SmsProviderId == 10)
				{
					SmsIr_SendSms1To1(array, array2, array3[0], array4[0], ref msgError, ref result2);
					if (result2[0] == -5000)
					{
						result = msgError;
						return result;
					}
					result = ((InsertSendedSms(newSms.UserId, newSms.SendType, newSms.SmsSendTopic, sid, smsSetting.SmsWsFromNumber, newSms.SmsSendBody, newSms.SmsBodyCount, newSms.SmsBodyLangType, newSms.SmsbodyCost, newSms.SmsNumberCount, newSms.SmsToNumber, result2[0].ToString(), newSms.SmsNumberCount * newSms.SmsBodyCount, newSms.SmsNumberCount * newSms.SmsBodyCount * newSms.SmsbodyCost, newSms.UserId, newSms.CompaniesId, newSms.CompanyPersonsId, newSms.Cmessage, newSms.sendPriority, 0, null, newSms.CenterId) <= 0) ? Messages.msgErrorInsertSmsToDb : ("1|" + Messages.msgSuccessSendSms + "|" + result2[0]));
					return result;
				}
				if (smsSetting.SmsProviderId == 11)
				{
					WebOne_SendSms1To1(array, array2[0], array3[0], smsSetting.SmsWsFromNumber, ref msgError, ref result2);
					if (result2[0] != -5000)
					{
						if (InsertSendedSms(newSms.UserId, newSms.SendType, newSms.SmsSendTopic, sid, smsSetting.SmsWsFromNumber, newSms.SmsSendBody, newSms.SmsBodyCount, newSms.SmsBodyLangType, newSms.SmsbodyCost, newSms.SmsNumberCount, newSms.SmsToNumber, result2[0].ToString(), newSms.SmsNumberCount * newSms.SmsBodyCount, newSms.SmsNumberCount * newSms.SmsBodyCount * newSms.SmsbodyCost, newSms.UserId, newSms.CompaniesId, newSms.CompanyPersonsId, newSms.Cmessage, newSms.sendPriority, 0, null, newSms.CenterId) <= 0)
						{
							result = Messages.msgErrorInsertSmsToDb;
						}
						return result;
					}
					result = msgError;
					return result;
				}
				if (smsSetting.SmsProviderId == 12)
				{
					if (isCodeVerification)
					{
						MeliPayamak_SendSmsByBaseNumber(array[0], verificationCode.ToString(), array4[0], ref msgError, ref result4);
						if (result4 != -5000)
						{
							if (InsertSendedSms(newSms.UserId, newSms.SendType, newSms.SmsSendTopic, sid, smsSetting.SmsWsFromNumber, newSms.SmsSendBody, newSms.SmsBodyCount, newSms.SmsBodyLangType, newSms.SmsbodyCost, newSms.SmsNumberCount, newSms.SmsToNumber, result4.ToString(), newSms.SmsNumberCount * newSms.SmsBodyCount, newSms.SmsNumberCount * newSms.SmsBodyCount * newSms.SmsbodyCost, newSms.UserId, newSms.CompaniesId, newSms.CompanyPersonsId, newSms.Cmessage, newSms.sendPriority, 0, null, newSms.CenterId) <= 0)
							{
								result = Messages.msgErrorInsertSmsToDb;
							}
							return result;
						}
						result = msgError;
						return result;
					}
					MeliPayamak_SendSms1To1(array, array2[0], array3[0], array4[0], ref msgError, ref result2);
					if (result4 != -5000)
					{
						if (InsertSendedSms(newSms.UserId, newSms.SendType, newSms.SmsSendTopic, sid, smsSetting.SmsWsFromNumber, newSms.SmsSendBody, newSms.SmsBodyCount, newSms.SmsBodyLangType, newSms.SmsbodyCost, newSms.SmsNumberCount, newSms.SmsToNumber, result4.ToString(), newSms.SmsNumberCount * newSms.SmsBodyCount, newSms.SmsNumberCount * newSms.SmsBodyCount * newSms.SmsbodyCost, newSms.UserId, newSms.CompaniesId, newSms.CompanyPersonsId, newSms.Cmessage, newSms.sendPriority, 0, null, newSms.CenterId) <= 0)
						{
							result = Messages.msgErrorInsertSmsToDb;
						}
						return result;
					}
					result = msgError;
					return result;
				}
				if (smsSetting.SmsProviderId == 13)
				{
					SmsPlus_SendSms1To1(array, array2[0], array3[0], array4[0], ref num, ref msgError, ref result2);
					if (result2[0] != -5000)
					{
						if (InsertSendedSms(newSms.UserId, newSms.SendType, newSms.SmsSendTopic, sid, smsSetting.SmsWsFromNumber, newSms.SmsSendBody, newSms.SmsBodyCount, newSms.SmsBodyLangType, newSms.SmsbodyCost, newSms.SmsNumberCount, newSms.SmsToNumber, result2[0].ToString(), newSms.SmsNumberCount * newSms.SmsBodyCount, newSms.SmsNumberCount * newSms.SmsBodyCount * newSms.SmsbodyCost, newSms.UserId, newSms.CompaniesId, newSms.CompanyPersonsId, newSms.Cmessage, newSms.sendPriority, 0, null, newSms.CenterId) <= 0)
						{
							result = Messages.msgErrorInsertSmsToDb;
						}
						return result;
					}
					result = msgError;
					return result;
				}
				if (smsSetting.SmsProviderId == 14)
				{
					SmsBimehParsian_SendSms1To1(array, array2, newSms.CompaniesId, newSms.CompanyPersonsId, ref msgError, ref result2, smsIsSendByOtherAccount: false, "", "", 0, newSms.CenterId);
					if (result2[0] != -5000)
					{
						if (InsertSendedSms(newSms.UserId, newSms.SendType, newSms.SmsSendTopic, sid, smsSetting.SmsWsFromNumber, newSms.SmsSendBody, newSms.SmsBodyCount, newSms.SmsBodyLangType, newSms.SmsbodyCost, newSms.SmsNumberCount, newSms.SmsToNumber, result2[0].ToString(), newSms.SmsNumberCount * newSms.SmsBodyCount, newSms.SmsNumberCount * newSms.SmsBodyCount * newSms.SmsbodyCost, newSms.UserId, newSms.CompaniesId, newSms.CompanyPersonsId, newSms.Cmessage, newSms.sendPriority, 0, null, newSms.CenterId) <= 0)
						{
							result = Messages.msgErrorInsertSmsToDb;
						}
						return result;
					}
					result = msgError;
					return result;
				}
				if (smsSetting.SmsProviderId == 15)
				{
					ISms_SendSms1To1(array, array2[0], array3[0], array4[0], ref num, ref msgError, ref result2);
					if (result2[0] != -5000)
					{
						if (InsertSendedSms(newSms.UserId, newSms.SendType, newSms.SmsSendTopic, sid, smsSetting.SmsWsFromNumber, newSms.SmsSendBody, newSms.SmsBodyCount, newSms.SmsBodyLangType, newSms.SmsbodyCost, newSms.SmsNumberCount, newSms.SmsToNumber, result2[0].ToString(), newSms.SmsNumberCount * newSms.SmsBodyCount, newSms.SmsNumberCount * newSms.SmsBodyCount * newSms.SmsbodyCost, newSms.UserId, newSms.CompaniesId, newSms.CompanyPersonsId, newSms.Cmessage, newSms.sendPriority, 0, null, newSms.CenterId) <= 0)
						{
							result = Messages.msgErrorInsertSmsToDb;
						}
						return result;
					}
					result = msgError;
					return result;
				}
				if (smsSetting.SmsProviderId == 16)
				{
					Nimaad_SendSms1To1(array, array2, array3[0], array4[0], array5, array6, ref num, ref msgError, ref lstGetId, ref result2);
					if (result2[0] != -5000)
					{
						if (InsertSendedSms(newSms.UserId, newSms.SendType, newSms.SmsSendTopic, sid, smsSetting.SmsWsFromNumber, newSms.SmsSendBody, newSms.SmsBodyCount, newSms.SmsBodyLangType, newSms.SmsbodyCost, newSms.SmsNumberCount, newSms.SmsToNumber, result2[0].ToString(), newSms.SmsNumberCount * newSms.SmsBodyCount, newSms.SmsNumberCount * newSms.SmsBodyCount * newSms.SmsbodyCost, newSms.UserId, newSms.CompaniesId, newSms.CompanyPersonsId, newSms.Cmessage, newSms.sendPriority, 0, null, newSms.CenterId) <= 0)
						{
							result = Messages.msgErrorInsertSmsToDb;
						}
						return result;
					}
					result = msgError;
					return result;
				}
				if (smsSetting.SmsProviderId == 17)
				{
					FarazSms_SendSms1To1(array, array2[0], array3[0], array4[0], ref num, ref msgError, ref result2);
					if (result2[0] != -5000)
					{
						if (InsertSendedSms(newSms.UserId, newSms.SendType, newSms.SmsSendTopic, sid, smsSetting.SmsWsFromNumber, newSms.SmsSendBody, newSms.SmsBodyCount, newSms.SmsBodyLangType, newSms.SmsbodyCost, newSms.SmsNumberCount, newSms.SmsToNumber, result2[0].ToString(), newSms.SmsNumberCount * newSms.SmsBodyCount, newSms.SmsNumberCount * newSms.SmsBodyCount * newSms.SmsbodyCost, newSms.UserId, newSms.CompaniesId, newSms.CompanyPersonsId, newSms.Cmessage, newSms.sendPriority, 0, null, newSms.CenterId) <= 0)
						{
							result = Messages.msgErrorInsertSmsToDb;
						}
						return result;
					}
					result = msgError;
					return result;
				}
				if (smsSetting.SmsProviderId == 18)
				{
					Sharif_SendSms1To1(array, array2[0], array3[0], array4[0], ref msgError, ref result2);
					if (result2[0] != -5000)
					{
						if (InsertSendedSms(newSms.UserId, newSms.SendType, newSms.SmsSendTopic, sid, smsSetting.SmsWsFromNumber, newSms.SmsSendBody, newSms.SmsBodyCount, newSms.SmsBodyLangType, newSms.SmsbodyCost, newSms.SmsNumberCount, newSms.SmsToNumber, result2[0].ToString(), newSms.SmsNumberCount * newSms.SmsBodyCount, newSms.SmsNumberCount * newSms.SmsBodyCount * newSms.SmsbodyCost, newSms.UserId, newSms.CompaniesId, newSms.CompanyPersonsId, newSms.Cmessage, newSms.sendPriority, 0, null, newSms.CenterId) <= 0)
						{
							result = Messages.msgErrorInsertSmsToDb;
						}
						return result;
					}
					result = msgError;
					return result;
				}
				if (smsSetting.SmsProviderId == 19)
				{
					SunWay_SendSms1To1(array, array2, array3[0], array4[0], array5, array6, ref num, ref msgError, ref lstGetId, ref result2);
					if (result2[0] != -5000)
					{
						if (InsertSendedSms(newSms.UserId, newSms.SendType, newSms.SmsSendTopic, sid, smsSetting.SmsWsFromNumber, newSms.SmsSendBody, newSms.SmsBodyCount, newSms.SmsBodyLangType, newSms.SmsbodyCost, newSms.SmsNumberCount, newSms.SmsToNumber, result2[0].ToString(), newSms.SmsNumberCount * newSms.SmsBodyCount, newSms.SmsNumberCount * newSms.SmsBodyCount * newSms.SmsbodyCost, newSms.UserId, newSms.CompaniesId, newSms.CompanyPersonsId, newSms.Cmessage, newSms.sendPriority, 0, null, newSms.CenterId) <= 0)
						{
							result = Messages.msgErrorInsertSmsToDb;
						}
						return result;
					}
					result = msgError;
					return result;
				}
				if (smsSetting.SmsProviderId == 20)
				{
					CandooSms_SendSms1To1(array, array2, array3[0], array4[0], array5, array6, ref num, ref msgError, ref lstGetId, ref result2);
					if (result2[0] != -5000)
					{
						if (InsertSendedSms(newSms.UserId, newSms.SendType, newSms.SmsSendTopic, sid, smsSetting.SmsWsFromNumber, newSms.SmsSendBody, newSms.SmsBodyCount, newSms.SmsBodyLangType, newSms.SmsbodyCost, newSms.SmsNumberCount, newSms.SmsToNumber, result2[0].ToString(), newSms.SmsNumberCount * newSms.SmsBodyCount, newSms.SmsNumberCount * newSms.SmsBodyCount * newSms.SmsbodyCost, newSms.UserId, newSms.CompaniesId, newSms.CompanyPersonsId, newSms.Cmessage, newSms.sendPriority, 0, null, newSms.CenterId) <= 0)
						{
							result = Messages.msgErrorInsertSmsToDb;
						}
						return result;
					}
					result = msgError;
					return result;
				}
				if (smsSetting.SmsProviderId == 21)
				{
					ParmisSms_SendSms1To1(array, array2, array3[0], array4[0], ref msgError, ref result2);
					if (result2[0] != -5000)
					{
						if (InsertSendedSms(newSms.UserId, newSms.SendType, newSms.SmsSendTopic, sid, smsSetting.SmsWsFromNumber, newSms.SmsSendBody, newSms.SmsBodyCount, newSms.SmsBodyLangType, newSms.SmsbodyCost, newSms.SmsNumberCount, newSms.SmsToNumber, result2[0].ToString(), newSms.SmsNumberCount * newSms.SmsBodyCount, newSms.SmsNumberCount * newSms.SmsBodyCount * newSms.SmsbodyCost, newSms.UserId, newSms.CompaniesId, newSms.CompanyPersonsId, newSms.Cmessage, newSms.sendPriority, 0, null, newSms.CenterId) <= 0)
						{
							result = Messages.msgErrorInsertSmsToDb;
						}
						return result;
					}
					result = msgError;
					return result;
				}
				if (smsSetting.SmsProviderId == 22)
				{
					SmsMelli_SendSms1To1(array, array2, array3[0], array4[0], ref msgError, ref result2);
					if (result2[0] != -5000)
					{
						if (InsertSendedSms(newSms.UserId, newSms.SendType, newSms.SmsSendTopic, sid, smsSetting.SmsWsFromNumber, newSms.SmsSendBody, newSms.SmsBodyCount, newSms.SmsBodyLangType, newSms.SmsbodyCost, newSms.SmsNumberCount, newSms.SmsToNumber, result2[0].ToString(), newSms.SmsNumberCount * newSms.SmsBodyCount, newSms.SmsNumberCount * newSms.SmsBodyCount * newSms.SmsbodyCost, newSms.UserId, newSms.CompaniesId, newSms.CompanyPersonsId, newSms.Cmessage, newSms.sendPriority, 0, null, newSms.CenterId) <= 0)
						{
							result = Messages.msgErrorInsertSmsToDb;
						}
						return result;
					}
					result = msgError;
					return result;
				}
				if (smsSetting.SmsProviderId == 23)
				{
					ParsGreen_SendSms1To1(array, array2, array3[0], array4[0], ref msgError, ref result2);
					if (result2[0] != -5000)
					{
						if (InsertSendedSms(newSms.UserId, newSms.SendType, newSms.SmsSendTopic, sid, smsSetting.SmsWsFromNumber, newSms.SmsSendBody, newSms.SmsBodyCount, newSms.SmsBodyLangType, newSms.SmsbodyCost, newSms.SmsNumberCount, newSms.SmsToNumber, result2[0].ToString(), newSms.SmsNumberCount * newSms.SmsBodyCount, newSms.SmsNumberCount * newSms.SmsBodyCount * newSms.SmsbodyCost, newSms.UserId, newSms.CompaniesId, newSms.CompanyPersonsId, newSms.Cmessage, newSms.sendPriority, 0, null, newSms.CenterId) <= 0)
						{
							result = Messages.msgErrorInsertSmsToDb;
						}
						return result;
					}
					result = msgError;
					return result;
				}
				if (smsSetting.SmsProviderId == 24)
				{
					Armaghan_SendSms1To1(array, array2, array3[0], array4[0], ref msgError, ref result2);
					if (result2[0] != -5000)
					{
						if (InsertSendedSms(newSms.UserId, newSms.SendType, newSms.SmsSendTopic, sid, smsSetting.SmsWsFromNumber, newSms.SmsSendBody, newSms.SmsBodyCount, newSms.SmsBodyLangType, newSms.SmsbodyCost, newSms.SmsNumberCount, newSms.SmsToNumber, result2[0].ToString(), newSms.SmsNumberCount * newSms.SmsBodyCount, newSms.SmsNumberCount * newSms.SmsBodyCount * newSms.SmsbodyCost, newSms.UserId, newSms.CompaniesId, newSms.CompanyPersonsId, newSms.Cmessage, newSms.sendPriority, 0, null, newSms.CenterId) <= 0)
						{
							result = Messages.msgErrorInsertSmsToDb;
						}
						return result;
					}
					result = msgError;
					return result;
				}
				if (smsSetting.SmsProviderId == 25)
				{
					Rahyab_SendSms1To1(array, array2, array3[0], array4[0], ref msgError, ref result3);
					if (!(result3[0] != "-5000"))
					{
						result = msgError;
						return result;
					}
					result = ((InsertSendedSms(newSms.UserId, newSms.SendType, newSms.SmsSendTopic, sid, smsSetting.SmsWsFromNumber, newSms.SmsSendBody, newSms.SmsBodyCount, newSms.SmsBodyLangType, newSms.SmsbodyCost, newSms.SmsNumberCount, newSms.SmsToNumber, result3[0].ToString(), newSms.SmsNumberCount * newSms.SmsBodyCount, newSms.SmsNumberCount * newSms.SmsBodyCount * newSms.SmsbodyCost, newSms.UserId, newSms.CompaniesId, newSms.CompanyPersonsId, newSms.Cmessage, newSms.sendPriority, 0, null) <= 0) ? Messages.msgErrorInsertSmsToDb : ("1|" + Messages.msgSuccessSendSms + "|" + result2[0]));
					return result;
				}
				if (smsSetting.SmsProviderId == 26)
				{
					IPPanel_SendSms1To1(array, array2, array3[0], array4[0], ref msgError, ref result3);
					if (!(result3[0] != "-5000"))
					{
						result = msgError;
						return result;
					}
					result = ((InsertSendedSms(newSms.UserId, newSms.SendType, newSms.SmsSendTopic, sid, smsSetting.SmsWsFromNumber, newSms.SmsSendBody, newSms.SmsBodyCount, newSms.SmsBodyLangType, newSms.SmsbodyCost, newSms.SmsNumberCount, newSms.SmsToNumber, result3[0].ToString(), newSms.SmsNumberCount * newSms.SmsBodyCount, newSms.SmsNumberCount * newSms.SmsBodyCount * newSms.SmsbodyCost, newSms.UserId, newSms.CompaniesId, newSms.CompanyPersonsId, newSms.Cmessage, newSms.sendPriority, 0, null) <= 0) ? Messages.msgErrorInsertSmsToDb : ("1|" + Messages.msgSuccessSendSms + "|" + result2[0]));
					return result;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public int InsertSendedSms(int userId, int sendType, string sendTopic, int sId, string fromNumber, string sendBody, int smsBoutCount, string smsBodyLangType, decimal smsBodyCost, int numberCount, string numbers, string refNumbers, int allSmsCount, decimal userCost, int sendUserId, string companiesId, string companyPersonsId, int cMessage, int sendPriority, int? statusId, DateTime? schedulDate, int? centerId = null)
	{
		CRMEntities cRMEntities = new CRMEntities();
		int result = 0;
		try
		{
			if (!string.IsNullOrWhiteSpace(refNumbers))
			{
				string[] array = refNumbers.Split(new char[1] { ',' });
				if (array != null && array.Length > 1 && array[0] == "0")
				{
					refNumbers = refNumbers.Substring(2);
				}
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			string sendDay = DateTimeClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
			string sendDate = now.ToString("yyyyMMdd", new PersianCulture());
			string sendTime = now.ToString("HH:mm:ss");
			int value = short.Parse(now.ToString("yyyy", new PersianCulture()));
			int value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			string singleNumber = ((numberCount == 1) ? numbers : "");
			int value3 = 0;
			int num = 0;
			string singleRefNumber = "-1";
			if (numberCount == 1)
			{
				if (!string.IsNullOrWhiteSpace(companiesId))
				{
					value3 = ((companiesId.Split(new char[1] { ',' }).Length == 1) ? int.Parse(companiesId) : 0);
				}
				if (!string.IsNullOrEmpty(companyPersonsId))
				{
					num = ((companyPersonsId.Split(new char[1] { ',' }).Length == 1) ? int.Parse(companyPersonsId) : 0);
				}
				if (refNumbers != "")
				{
					singleRefNumber = ((refNumbers.Split(new char[1] { ',' }).Length == 1) ? refNumbers : "0");
				}
			}
			result = cRMEntities.MobspInsertSendedSms(sendType, sendTopic, sId, fromNumber, sendBody, smsBoutCount, smsBodyLangType, smsBodyCost, numberCount, numbers, refNumbers, allSmsCount, userCost, sendUserId, sendDay, sendDate, sendTime, now, companiesId, companyPersonsId, userId, value, value2, registerDatePersian, singleNumber, value3, (num > 0) ? new int?(num) : null, singleRefNumber, Configuration.AppType, statusId, cMessage, schedulDate, sendPriority, result2, null, null, null, null, null, null, centerId);
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

	public static int GetFreeSmsCount()
	{
		CRMEntities cRMEntities = new CRMEntities();
		int result = 0;
		try
		{
			MobspGetMaxSmsSendDetailId_Result mobspGetMaxSmsSendDetailId_Result = Enumerable.FirstOrDefault<MobspGetMaxSmsSendDetailId_Result>((IEnumerable<MobspGetMaxSmsSendDetailId_Result>)cRMEntities.MobspGetMaxSmsSendDetailId());
			if (mobspGetMaxSmsSendDetailId_Result != null)
			{
				int num = 55 - mobspGetMaxSmsSendDetailId_Result.MaxId;
				bool sMS = VersionBuyer.SMS;
				result = ((num <= 0 || sMS) ? (-1) : num);
			}
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

	public static SmsSettingInfoViewModel GetSmsSetting(out int freeSmsCount)
	{
		freeSmsCount = GetFreeSmsCount();
		SmsSettingInfoViewModel smsSettingInfoViewModel;
		if (freeSmsCount > 0)
		{
			smsSettingInfoViewModel = new SmsSettingInfoViewModel
			{
				SmsWsUserName = "DemoInternal",
				SmsWsPassword = "DemoAllSoftware1391",
				SmsWsDomainNamed = Configuration.SmsWsDomainNamed,
				SmsWsFromNumber = "30002872500500",
				SmsWsEnCost = "300",
				SmsWsFaCost = "150",
				SmsSendIsActive = true,
				SmsReceiveIsActive = false,
				SmsProviderId = 1
			};
		}
		else
		{
			smsSettingInfoViewModel = SmsSeting.Get();
			if (!smsSettingInfoViewModel.DecryptedPassword.GetValueOrDefault())
			{
				smsSettingInfoViewModel.SmsWsPassword = ((!string.IsNullOrEmpty(smsSettingInfoViewModel.SmsWsPassword)) ? XorCipher.TryDecryptOrReturnOriginal(smsSettingInfoViewModel.SmsWsPassword) : string.Empty);
				smsSettingInfoViewModel.DecryptedPassword = true;
			}
		}
		return smsSettingInfoViewModel;
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

	public string SendSmsToGsmServer(SmsSendViewModel newSms)
	{
		string text = "0";
		int sid = newSms.Sid;
		CRMEntities cRMEntities = new CRMEntities();
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSetting = GetSmsSetting(out freeSmsCount);
			int num = 0;
			string text2 = "";
			int typeUnicodeMessage = 0;
			int num2 = 1;
			double userCost = 0.0;
			if (newSms.HavePassword.HasValue && newSms.HavePassword.Value && !string.IsNullOrWhiteSpace(newSms.Password))
			{
				newSms.SmsSendBody = newSms.SmsSendBody.Replace("[******]", newSms.Password);
			}
			int num3 = ReturnSmsBodyLength(newSms.SmsSendBody);
			if (num3 > 0)
			{
				num = ReturnSmsBodyCountLatin(num3);
				num2 = int.Parse(smsSetting.SmsWsEnCost);
				text2 = "EN";
				userCost = num2 * num;
			}
			else if (num3 < 0)
			{
				num3 *= -1;
				num = ReturnSmsBodyCountFarsi(num3);
				num2 = int.Parse(smsSetting.SmsWsFaCost);
				text2 = "FA";
				userCost = num2 * num;
			}
			if (text2 == "EN")
			{
				typeUnicodeMessage = 1;
			}
			else if (text2 == "FA")
			{
				typeUnicodeMessage = 2;
			}
			newSms.SmsBodyCount = num;
			newSms.SmsbodyCost = num2;
			newSms.SmsBodyLangType = text2;
			newSms.TypeUnicodeMessage = typeUnicodeMessage;
			newSms.UserCost = userCost;
			if (!VersionBuyer.GSM)
			{
				text = Messages.msgNotAccessGSMSms;
				return text;
			}
			if (!string.IsNullOrEmpty(newSms.SmsSendBody) && !string.IsNullOrEmpty(newSms.Numbers))
			{
				sid = ReturnSid();
				string fromNumber = "+98";
				MobspSelectGSMModemSetting_Result mobspSelectGSMModemSetting_Result = Enumerable.FirstOrDefault<MobspSelectGSMModemSetting_Result>((IEnumerable<MobspSelectGSMModemSetting_Result>)cRMEntities.MobspSelectGSMModemSetting());
				if (mobspSelectGSMModemSetting_Result != null)
				{
					fromNumber = mobspSelectGSMModemSetting_Result.SimNumber;
				}
				text = ((InsertSendedSms(newSms.UserId, newSms.SendType, newSms.SmsSendTopic, sid, fromNumber, newSms.SmsSendBody, newSms.SmsBodyCount, newSms.SmsBodyLangType, newSms.SmsbodyCost, newSms.SmsNumberCount, newSms.Numbers, text + ",", newSms.SmsNumberCount * newSms.SmsBodyCount, newSms.SmsNumberCount * newSms.SmsBodyCount * newSms.SmsbodyCost, newSms.UserId, newSms.CompaniesId, newSms.CompanyPersonsId, newSms.Cmessage, newSms.sendPriority, -2000, null, newSms.CenterId) <= 0) ? Messages.msgErrorInsertSmsToDb : null);
				return text;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities.Dispose();
		}
		return text;
	}

	public string SendSmsToGsmServer(int sendType, string sendTopic, int sId, string sendBody, int numberCount, string numbers, string companiesId, string companyPersonsId)
	{
		string result = "-1";
		try
		{
			SmsSendViewModel smsSendViewModel = new SmsSendViewModel();
			smsSendViewModel.SendType = sendType;
			smsSendViewModel.SmsSendTopic = sendTopic;
			smsSendViewModel.Sid = sId;
			smsSendViewModel.SmsSendBody = sendBody;
			smsSendViewModel.SmsNumberCount = numberCount;
			smsSendViewModel.Numbers = numbers;
			smsSendViewModel.CompaniesId = companiesId;
			smsSendViewModel.CompanyPersonsId = companyPersonsId;
			result = SendSmsToGsmServer(smsSendViewModel);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public string SendSMSTankByOtp(string otpCode = "", int? cId = null)
	{
		string result = "";
		CRMEntities cRMEntities = new CRMEntities();
		try
		{
			SysSeting.Get();
			bool sMS = VersionBuyer.SMS;
			if (true)
			{
				List<MobspGetSMSTankRequestByOTP_Result> list = Enumerable.ToList<MobspGetSMSTankRequestByOTP_Result>((IEnumerable<MobspGetSMSTankRequestByOTP_Result>)cRMEntities.MobspGetSMSTankRequestByOTP(otpCode));
				if (list != null && Enumerable.Any<MobspGetSMSTankRequestByOTP_Result>((IEnumerable<MobspGetSMSTankRequestByOTP_Result>)list))
				{
					int count = list.Count;
					int sIdTemp = 0;
					long[] result2 = new long[count];
					string[] result3 = new string[count];
					result3[0] = "-7";
					result2[0] = -7L;
					string msgError = "";
					int freeSmsCount;
					SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
					int result4 = 0;
					if (list[0] != null)
					{
						int.TryParse(list[0].smsProviderId.ToString(), out result4);
						if (result4 != 0)
						{
							smsSettingInfoViewModel = GetSmsProvider(result4, out freeSmsCount);
						}
					}
					string[] array = new string[count];
					string[] array2 = new string[count];
					long[] lstGetId = new long[count];
					int[] array3 = new int[count];
					string[] array4 = new string[count];
					int[] array5 = new int[count];
					string[] array6 = new string[count];
					decimal num = default(decimal);
					decimal num2 = default(decimal);
					for (int i = 0; i < count; i++)
					{
						MobspGetSMSTankRequestByOTP_Result mobspGetSMSTankRequestByOTP_Result = list[i];
						string oTP = mobspGetSMSTankRequestByOTP_Result.OTP;
						oTP = oTP ?? "";
						string text = mobspGetSMSTankRequestByOTP_Result.Body ?? "";
						if (!string.IsNullOrWhiteSpace(text))
						{
							text = text.Replace("[#کد تایید OTP#]", oTP);
							mobspGetSMSTankRequestByOTP_Result.Body = text;
						}
						array[i] = mobspGetSMSTankRequestByOTP_Result.Number;
						array2[i] = mobspGetSMSTankRequestByOTP_Result.Body;
						lstGetId[i] = long.Parse(mobspGetSMSTankRequestByOTP_Result.SID.ToString());
						array3[i] = int.Parse(mobspGetSMSTankRequestByOTP_Result.CMessage.ToString());
						array4[i] = mobspGetSMSTankRequestByOTP_Result.FromNumber;
						array5[i] = ((mobspGetSMSTankRequestByOTP_Result.BodyLangType == "EN") ? 1 : 2);
						array6[i] = "";
						int num3 = 0;
						int num4 = 0;
						int num5 = 1;
						num3 = ReturnSmsBodyLength(mobspGetSMSTankRequestByOTP_Result.Body);
						if (num3 > 0)
						{
							num4 = ReturnSmsBodyCountLatin(num3);
							num5 = int.Parse((smsSettingInfoViewModel.SmsWsEnCost ?? "").Replace(".00", ""));
							num5 *= num4;
						}
						else if (num3 < 0)
						{
							num3 *= -1;
							num4 = ReturnSmsBodyCountFarsi(num3);
							num5 = int.Parse((smsSettingInfoViewModel.SmsWsFaCost ?? "").Replace(".00", ""));
							num5 *= num4;
						}
						num += (decimal)num5;
						num2 += (decimal)num4;
					}
					if (sMS)
					{
						string appType = Configuration.AppType;
						if (!string.IsNullOrEmpty(smsSettingInfoViewModel.SmsWsUserName) && !string.IsNullOrEmpty(smsSettingInfoViewModel.SmsWsPassword) && !string.IsNullOrEmpty(smsSettingInfoViewModel.SmsWsDomainNamed))
						{
							decimal result5 = default(decimal);
							decimal result6 = default(decimal);
							decimal result7 = default(decimal);
							if (smsSettingInfoViewModel.SmsProviderId == 1)
							{
								string msgError2 = "";
								string[] array7 = MehrAfraz_GetUserInfo(ref msgError2, result4);
								if (array7.Length >= 3)
								{
									decimal.TryParse(array7[5], out result5);
									decimal.TryParse(array7[6], out result6);
									decimal.TryParse(array7[1], out var result8);
									decimal.TryParse(result8.ToString(), out result7);
								}
								else
								{
									Exception innerException = new Exception();
									Exception e = new Exception(msgError2, innerException);
									ErrorSignal.FromCurrentContext().Raise(e);
								}
								if (result7 >= num)
								{
									MehrAfraz_SendSms1To1(array, array2, array3, array4, array5, array6, ref sIdTemp, ref msgError, ref lstGetId, ref result2, smsIsSendByOtherAccount: false, "", "", result4);
									if (result2[0] != -5000)
									{
										string text2 = "";
										for (int j = 0; j < result2.Length; j++)
										{
											MobspGetSMSTankRequestByOTP_Result mobspGetSMSTankRequestByOTP_Result2 = list[j];
											text2 = text2 + mobspGetSMSTankRequestByOTP_Result2.ID + "," + result2[j] + "|";
										}
										DateTime now = DateTime.Now;
										DateTime value = now;
										string statusChangeDate = now.ToString("yyyyMMdd", new PersianCulture());
										string statusChangeTime = now.ToString("HH:mm:ss");
										cRMEntities.MobspUpdateSendedDetailStatusAndRefId(text2, 0, statusChangeDate, statusChangeTime, appType, value);
									}
									else
									{
										Exception innerException2 = new Exception();
										Exception e2 = new Exception(msgError, innerException2);
										ErrorSignal.FromCurrentContext().Raise(e2);
									}
								}
								else
								{
									Exception innerException3 = new Exception();
									Exception e3 = new Exception(Messages.msgErrorEndSmsSendAllCredit, innerException3);
									ErrorSignal.FromCurrentContext().Raise(e3);
								}
							}
							else if (smsSettingInfoViewModel.SmsProviderId == 2)
							{
								decimal credit = default(decimal);
								string msgError3 = "";
								SMSLine_GetCredit(ref credit, ref msgError3, result4);
								credit = credit;
								if (credit > 0m)
								{
									decimal.TryParse(credit.ToString(), out var result9);
									decimal.TryParse(result9.ToString(), out result7);
								}
								else
								{
									Exception innerException4 = new Exception();
									Exception e4 = new Exception(Messages.msgErrorPRSendSmsCreditNotSufficient, innerException4);
									ErrorSignal.FromCurrentContext().Raise(e4);
								}
								if (result7 >= num)
								{
									int num6 = 0;
									string text3 = "";
									for (int k = 0; k < count; k++)
									{
										long result10 = 0L;
										string msgError4 = "";
										SMSLine_SendSms_Single(array[k], array2[k], array4[k], ref msgError4, ref result10, smsIsSendByOtherAccount: false, "", "", result4);
										if (result10 > 0)
										{
											MobspGetSMSTankRequestByOTP_Result mobspGetSMSTankRequestByOTP_Result3 = list[k];
											text3 = text3 + mobspGetSMSTankRequestByOTP_Result3.ID + "," + result10 + "|";
											num6++;
										}
										else if (!string.IsNullOrWhiteSpace(msgError4))
										{
											Exception innerException5 = new Exception();
											Exception e5 = new Exception(msgError4, innerException5);
											ErrorSignal.FromCurrentContext().Raise(e5);
										}
									}
									if (num6 > 0 && !string.IsNullOrWhiteSpace(text3))
									{
										DateTime now2 = DateTime.Now;
										DateTime value2 = now2;
										string statusChangeDate2 = now2.ToString("yyyyMMdd", new PersianCulture());
										string statusChangeTime2 = now2.ToString("HH:mm:ss");
										cRMEntities.MobspUpdateSendedDetailStatusAndRefId(text3, 0, statusChangeDate2, statusChangeTime2, appType, value2);
										if (!string.IsNullOrEmpty(msgError))
										{
											Exception innerException6 = new Exception();
											Exception e6 = new Exception(msgError, innerException6);
											ErrorSignal.FromCurrentContext().Raise(e6);
										}
									}
									else
									{
										Exception innerException7 = new Exception();
										Exception e7 = new Exception(msgError, innerException7);
										ErrorSignal.FromCurrentContext().Raise(e7);
									}
								}
								else
								{
									Exception innerException8 = new Exception();
									Exception e8 = new Exception(Messages.msgErrorEndSmsSendAllCredit, innerException8);
									ErrorSignal.FromCurrentContext().Raise(e8);
								}
							}
							else if (smsSettingInfoViewModel.SmsProviderId == 3)
							{
								int num7 = 0;
								string text4 = "";
								for (int l = 0; l < count; l++)
								{
									long[] result11 = new long[1];
									string msgError5 = "";
									FaraPayamak_SendSms1To1(new string[1] { array[l] }, array2[l], array3[l], array4[l], ref msgError5, ref result11, smsIsSendByOtherAccount: false, "", "", result4);
									if (result11[0] != -5000)
									{
										MobspGetSMSTankRequestByOTP_Result mobspGetSMSTankRequestByOTP_Result4 = list[l];
										text4 = text4 + mobspGetSMSTankRequestByOTP_Result4.ID + "," + result11[0] + "|";
										num7++;
									}
									else if (!string.IsNullOrWhiteSpace(msgError5))
									{
										Exception innerException9 = new Exception();
										Exception e9 = new Exception(msgError5, innerException9);
										ErrorSignal.FromCurrentContext().Raise(e9);
									}
								}
								if (num7 > 0 && !string.IsNullOrWhiteSpace(text4))
								{
									DateTime now3 = DateTime.Now;
									DateTime value3 = now3;
									string statusChangeDate3 = now3.ToString("yyyyMMdd", new PersianCulture());
									string statusChangeTime3 = now3.ToString("HH:mm:ss");
									cRMEntities.MobspUpdateSendedDetailStatusAndRefId(text4, 0, statusChangeDate3, statusChangeTime3, appType, value3);
									if (!string.IsNullOrEmpty(msgError))
									{
										Exception innerException10 = new Exception();
										Exception e10 = new Exception(msgError, innerException10);
										ErrorSignal.FromCurrentContext().Raise(e10);
									}
								}
								else
								{
									Exception innerException11 = new Exception();
									Exception e11 = new Exception(msgError, innerException11);
									ErrorSignal.FromCurrentContext().Raise(e11);
								}
							}
							else if (smsSettingInfoViewModel.SmsProviderId == 4)
							{
								decimal credit2 = default(decimal);
								string msgError6 = "";
								Asanak_GetCredit(ref credit2, ref msgError6, result4);
								credit2 = credit2;
								if (credit2 > 0m)
								{
									decimal.TryParse(credit2.ToString(), out var result12);
									decimal.TryParse(result12.ToString(), out result7);
								}
								else
								{
									Exception innerException12 = new Exception();
									Exception e12 = new Exception(Messages.msgErrorPRSendSmsCreditNotSufficient, innerException12);
									ErrorSignal.FromCurrentContext().Raise(e12);
								}
								if (result7 >= num)
								{
									int num8 = 0;
									string text5 = "";
									for (int m = 0; m < count; m++)
									{
										long[] result13 = new long[1];
										string msgError7 = "";
										Asanak_SendSms1To1(new string[1] { array[m] }, array2[m], array4[m], ref msgError7, ref result13, smsIsSendByOtherAccount: false, "", "", result4);
										if (result13[0] != -5000)
										{
											MobspGetSMSTankRequestByOTP_Result mobspGetSMSTankRequestByOTP_Result5 = list[m];
											text5 = text5 + mobspGetSMSTankRequestByOTP_Result5.ID + "," + result13[0] + "|";
											num8++;
										}
										else if (!string.IsNullOrWhiteSpace(msgError7))
										{
											Exception innerException13 = new Exception();
											Exception e13 = new Exception(msgError7, innerException13);
											ErrorSignal.FromCurrentContext().Raise(e13);
										}
									}
									if (num8 > 0 && !string.IsNullOrWhiteSpace(text5))
									{
										DateTime now4 = DateTime.Now;
										DateTime value4 = now4;
										string statusChangeDate4 = now4.ToString("yyyyMMdd", new PersianCulture());
										string statusChangeTime4 = now4.ToString("HH:mm:ss");
										cRMEntities.MobspUpdateSendedDetailStatusAndRefId(text5, 0, statusChangeDate4, statusChangeTime4, appType, value4);
										if (!string.IsNullOrEmpty(msgError))
										{
											Exception innerException14 = new Exception();
											Exception e14 = new Exception(msgError, innerException14);
											ErrorSignal.FromCurrentContext().Raise(e14);
										}
									}
									else
									{
										Exception innerException15 = new Exception();
										Exception e15 = new Exception(msgError, innerException15);
										ErrorSignal.FromCurrentContext().Raise(e15);
									}
								}
								else
								{
									Exception innerException16 = new Exception();
									Exception e16 = new Exception(Messages.msgErrorEndSmsSendAllCredit, innerException16);
									ErrorSignal.FromCurrentContext().Raise(e16);
								}
							}
							else if (smsSettingInfoViewModel.SmsProviderId == 5)
							{
								decimal credit3 = default(decimal);
								string msgError8 = "";
								PayamResan_GetCredit(ref credit3, ref msgError8, result4);
								credit3 = credit3;
								if (credit3 > 0m)
								{
									decimal.TryParse(credit3.ToString(), out var result14);
									decimal.TryParse(result14.ToString(), out result7);
								}
								else
								{
									Exception innerException17 = new Exception();
									Exception e17 = new Exception(Messages.msgErrorPRSendSmsCreditNotSufficient, innerException17);
									ErrorSignal.FromCurrentContext().Raise(e17);
								}
								if (result7 >= num)
								{
									int NumberOfSmsSent = 0;
									PayamResan_SendSms_Multiple(array, array2, array4, ref msgError, ref result2, ref NumberOfSmsSent, result4);
									if (NumberOfSmsSent > 0)
									{
										string text6 = "";
										for (int n = 0; n < result2.Length; n++)
										{
											MobspGetSMSTankRequestByOTP_Result mobspGetSMSTankRequestByOTP_Result6 = list[n];
											text6 = text6 + mobspGetSMSTankRequestByOTP_Result6.ID + "," + result2[n] + "|";
										}
										DateTime now5 = DateTime.Now;
										DateTime value5 = now5;
										string statusChangeDate5 = now5.ToString("yyyyMMdd", new PersianCulture());
										string statusChangeTime5 = now5.ToString("HH:mm:ss");
										cRMEntities.MobspUpdateSendedDetailStatusAndRefId(text6, 0, statusChangeDate5, statusChangeTime5, appType, value5);
										if (!string.IsNullOrEmpty(msgError))
										{
											Exception innerException18 = new Exception();
											Exception e18 = new Exception(msgError, innerException18);
											ErrorSignal.FromCurrentContext().Raise(e18);
										}
									}
									else
									{
										Exception innerException19 = new Exception();
										Exception e19 = new Exception(msgError, innerException19);
										ErrorSignal.FromCurrentContext().Raise(e19);
									}
								}
								else
								{
									Exception innerException20 = new Exception();
									Exception e20 = new Exception(Messages.msgErrorEndSmsSendAllCredit, innerException20);
									ErrorSignal.FromCurrentContext().Raise(e20);
								}
							}
							else if (smsSettingInfoViewModel.SmsProviderId == 6)
							{
								string msgError9 = "";
								decimal credit4 = default(decimal);
								KaveNegar_GetCredit(ref credit4, ref msgError9, result4);
								credit4 = credit4;
								decimal.TryParse(credit4.ToString(), out var result15);
								decimal.TryParse(result15.ToString(), out result7);
								if (result7 >= num)
								{
									int NumberOfSmsSent2 = 0;
									KaveNegar_SendSms_Array(array, array2, 1, array4, ref msgError, ref result2, ref NumberOfSmsSent2, result4);
									if (NumberOfSmsSent2 > 0)
									{
										string text7 = "";
										for (int num9 = 0; num9 < result2.Length; num9++)
										{
											MobspGetSMSTankRequestByOTP_Result mobspGetSMSTankRequestByOTP_Result7 = list[num9];
											text7 = text7 + mobspGetSMSTankRequestByOTP_Result7.ID + "," + result2[num9] + "|";
										}
										DateTime now6 = DateTime.Now;
										DateTime value6 = now6;
										string statusChangeDate6 = now6.ToString("yyyyMMdd", new PersianCulture());
										string statusChangeTime6 = now6.ToString("HH:mm:ss");
										cRMEntities.MobspUpdateSendedDetailStatusAndRefId(text7, 0, statusChangeDate6, statusChangeTime6, appType, value6);
										if (!string.IsNullOrEmpty(msgError))
										{
											Exception innerException21 = new Exception();
											Exception e21 = new Exception(msgError, innerException21);
											ErrorSignal.FromCurrentContext().Raise(e21);
										}
									}
									else
									{
										Exception innerException22 = new Exception();
										Exception e22 = new Exception(msgError, innerException22);
										ErrorSignal.FromCurrentContext().Raise(e22);
									}
								}
								else
								{
									Exception innerException23 = new Exception();
									Exception e23 = new Exception(Messages.msgErrorEndSmsSendAllCredit, innerException23);
									ErrorSignal.FromCurrentContext().Raise(e23);
								}
							}
							else if (smsSettingInfoViewModel.SmsProviderId == 7)
							{
								string msgError10 = "";
								decimal credit5 = default(decimal);
								TehranPayamak_GetUserInfo(ref credit5, ref msgError10, result4);
								credit5 = credit5;
								if (credit5 > 0m)
								{
									decimal.TryParse(credit5.ToString(), out var result16);
									decimal.TryParse(result16.ToString(), out result7);
								}
								else
								{
									Exception innerException24 = new Exception();
									Exception e24 = new Exception(Messages.msgErrorPRSendSmsCreditNotSufficient, innerException24);
									ErrorSignal.FromCurrentContext().Raise(e24);
								}
								if (result7 >= num)
								{
									TehranPayamak_sendMultiSMS(array, array2, array3[0], array4[0], ref msgError, ref result2, result4);
									if (result2[0] != -5000)
									{
										string text8 = "";
										for (int num10 = 0; num10 < result2.Length; num10++)
										{
											MobspGetSMSTankRequestByOTP_Result mobspGetSMSTankRequestByOTP_Result8 = list[num10];
											text8 = text8 + mobspGetSMSTankRequestByOTP_Result8.ID + "," + result2[num10] + "|";
										}
										DateTime now7 = DateTime.Now;
										DateTime value7 = now7;
										string statusChangeDate7 = now7.ToString("yyyyMMdd", new PersianCulture());
										string statusChangeTime7 = now7.ToString("HH:mm:ss");
										cRMEntities.MobspUpdateSendedDetailStatusAndRefId(text8, 0, statusChangeDate7, statusChangeTime7, appType, value7);
									}
									else
									{
										Exception innerException25 = new Exception();
										Exception e25 = new Exception(msgError, innerException25);
										ErrorSignal.FromCurrentContext().Raise(e25);
									}
								}
								else
								{
									Exception innerException26 = new Exception();
									Exception e26 = new Exception(Messages.msgErrorEndSmsSendAllCredit, innerException26);
									ErrorSignal.FromCurrentContext().Raise(e26);
								}
							}
							else if (smsSettingInfoViewModel.SmsProviderId == 8)
							{
								string msgError11 = "";
								decimal credit6 = default(decimal);
								SmsFor_GetCredit(ref credit6, ref msgError11, result4);
								credit6 = credit6;
								if (credit6 > 0m)
								{
									decimal.TryParse(credit6.ToString(), out var result17);
									decimal.TryParse(result17.ToString(), out result7);
								}
								else
								{
									Exception innerException27 = new Exception();
									Exception e27 = new Exception(Messages.msgErrorPRSendSmsCreditNotSufficient, innerException27);
									ErrorSignal.FromCurrentContext().Raise(e27);
								}
								if (result7 >= num)
								{
									SmsFor_SendSms1To1(array, array2, array3[0], array4[0], ref msgError, ref result2, smsIsSendByOtherAccount: false, "", "", result4);
									if (result2[0] != -5000)
									{
										string text9 = "";
										for (int num11 = 0; num11 < result2.Length; num11++)
										{
											MobspGetSMSTankRequestByOTP_Result mobspGetSMSTankRequestByOTP_Result9 = list[num11];
											text9 = text9 + mobspGetSMSTankRequestByOTP_Result9.ID + "," + result2[num11] + "|";
										}
										DateTime now8 = DateTime.Now;
										DateTime value8 = now8;
										string statusChangeDate8 = now8.ToString("yyyyMMdd", new PersianCulture());
										string statusChangeTime8 = now8.ToString("HH:mm:ss");
										cRMEntities.MobspUpdateSendedDetailStatusAndRefId(text9, 0, statusChangeDate8, statusChangeTime8, appType, value8);
									}
									else
									{
										Exception innerException28 = new Exception();
										Exception e28 = new Exception(msgError, innerException28);
										ErrorSignal.FromCurrentContext().Raise(e28);
									}
								}
								else
								{
									Exception innerException29 = new Exception();
									Exception e29 = new Exception(Messages.msgErrorEndSmsSendAllCredit, innerException29);
									ErrorSignal.FromCurrentContext().Raise(e29);
								}
							}
							else if (smsSettingInfoViewModel.SmsProviderId == 9)
							{
								string msgError12 = "";
								decimal credit7 = default(decimal);
								SmsAfzar_GetCredit(ref credit7, ref msgError12, result4);
								credit7 = credit7;
								if (credit7 > 0m)
								{
									decimal.TryParse(credit7.ToString(), out var result18);
									decimal.TryParse(result18.ToString(), out result7);
								}
								else
								{
									Exception innerException30 = new Exception();
									Exception e30 = new Exception(Messages.msgErrorPRSendSmsCreditNotSufficient, innerException30);
									ErrorSignal.FromCurrentContext().Raise(e30);
								}
								if (result7 >= num)
								{
									SmsAfzar_SendSms1To1(array, array2, array3[0], array4, ref msgError, ref result2, smsIsSendByOtherAccount: false, "", "", result4);
									if (result2[0] != -5000)
									{
										string text10 = "";
										for (int num12 = 0; num12 < result2.Length; num12++)
										{
											MobspGetSMSTankRequestByOTP_Result mobspGetSMSTankRequestByOTP_Result10 = list[num12];
											text10 = text10 + mobspGetSMSTankRequestByOTP_Result10.ID + "," + result2[num12] + "|";
										}
										DateTime now9 = DateTime.Now;
										DateTime value9 = now9;
										string statusChangeDate9 = now9.ToString("yyyyMMdd", new PersianCulture());
										string statusChangeTime9 = now9.ToString("HH:mm:ss");
										cRMEntities.MobspUpdateSendedDetailStatusAndRefId(text10, 0, statusChangeDate9, statusChangeTime9, appType, value9);
									}
									else
									{
										Exception innerException31 = new Exception();
										Exception e31 = new Exception(msgError, innerException31);
										ErrorSignal.FromCurrentContext().Raise(e31);
									}
								}
								else
								{
									Exception innerException32 = new Exception();
									Exception e32 = new Exception(Messages.msgErrorEndSmsSendAllCredit, innerException32);
									ErrorSignal.FromCurrentContext().Raise(e32);
								}
							}
							else if (smsSettingInfoViewModel.SmsProviderId == 10)
							{
								string errorMessage = "";
								decimal creditSmsCount = default(decimal);
								GetCreditSmsCount(ref creditSmsCount, ref errorMessage, result4);
								if (creditSmsCount <= 0m)
								{
									Exception innerException33 = new Exception();
									Exception e33 = new Exception(Messages.msgErrorPRSendSmsCreditNotSufficient, innerException33);
									ErrorSignal.FromCurrentContext().Raise(e33);
								}
								if (creditSmsCount >= num2)
								{
									SmsIr_SendSms1To1(array, array2, array3[0], array4[0], ref msgError, ref result2, smsIsSendByOtherAccount: false, "", "", result4);
									if (result2[0] != -5000)
									{
										string text11 = "";
										for (int num13 = 0; num13 < result2.Length; num13++)
										{
											MobspGetSMSTankRequestByOTP_Result mobspGetSMSTankRequestByOTP_Result11 = list[num13];
											text11 = text11 + mobspGetSMSTankRequestByOTP_Result11.ID + "," + result2[num13] + "|";
										}
										DateTime now10 = DateTime.Now;
										DateTime value10 = now10;
										string statusChangeDate10 = now10.ToString("yyyyMMdd", new PersianCulture());
										string statusChangeTime10 = now10.ToString("HH:mm:ss");
										cRMEntities.MobspUpdateSendedDetailStatusAndRefId(text11, 0, statusChangeDate10, statusChangeTime10, appType, value10);
									}
									else
									{
										Exception innerException34 = new Exception();
										Exception e34 = new Exception(msgError, innerException34);
										ErrorSignal.FromCurrentContext().Raise(e34);
									}
								}
								else
								{
									Exception innerException35 = new Exception();
									Exception e35 = new Exception(Messages.msgErrorEndSmsSendAllCredit, innerException35);
									ErrorSignal.FromCurrentContext().Raise(e35);
								}
							}
							else if (smsSettingInfoViewModel.SmsProviderId == 11)
							{
								decimal credit8 = default(decimal);
								string msgError13 = "";
								WebOne_GetCredit(ref credit8, ref msgError13, result4);
								credit8 = credit8;
								if (credit8 > 0m)
								{
									decimal.TryParse(credit8.ToString(), out var result19);
									decimal.TryParse(result19.ToString(), out result7);
								}
								else
								{
									Exception innerException36 = new Exception();
									Exception e36 = new Exception(Messages.msgErrorPRSendSmsCreditNotSufficient, innerException36);
									ErrorSignal.FromCurrentContext().Raise(e36);
								}
								if (result7 >= num)
								{
									int num14 = 0;
									string text12 = "";
									for (int num15 = 0; num15 < count; num15++)
									{
										long[] result20 = new long[1];
										string msgError14 = "";
										WebOne_SendSms1To1(new string[1] { array[num15] }, array2[num15], array3[num15], array4[num15], ref msgError14, ref result20, smsIsSendByOtherAccount: false, "", "", result4);
										if (result20[0] != -5000)
										{
											MobspGetSMSTankRequestByOTP_Result mobspGetSMSTankRequestByOTP_Result12 = list[num15];
											text12 = text12 + mobspGetSMSTankRequestByOTP_Result12.ID + "," + result20[0] + "|";
											num14++;
										}
										else if (!string.IsNullOrWhiteSpace(msgError14))
										{
											Exception innerException37 = new Exception();
											Exception e37 = new Exception(msgError14, innerException37);
											ErrorSignal.FromCurrentContext().Raise(e37);
										}
									}
									if (num14 > 0 && !string.IsNullOrWhiteSpace(text12))
									{
										DateTime now11 = DateTime.Now;
										DateTime value11 = now11;
										string statusChangeDate11 = now11.ToString("yyyyMMdd", new PersianCulture());
										string statusChangeTime11 = now11.ToString("HH:mm:ss");
										cRMEntities.MobspUpdateSendedDetailStatusAndRefId(text12, 0, statusChangeDate11, statusChangeTime11, appType, value11);
										if (!string.IsNullOrEmpty(msgError))
										{
											Exception innerException38 = new Exception();
											Exception e38 = new Exception(msgError, innerException38);
											ErrorSignal.FromCurrentContext().Raise(e38);
										}
									}
									else
									{
										Exception innerException39 = new Exception();
										Exception e39 = new Exception(msgError, innerException39);
										ErrorSignal.FromCurrentContext().Raise(e39);
									}
								}
								else
								{
									Exception innerException40 = new Exception();
									Exception e40 = new Exception(Messages.msgErrorEndSmsSendAllCredit, innerException40);
									ErrorSignal.FromCurrentContext().Raise(e40);
								}
							}
							else if (smsSettingInfoViewModel.SmsProviderId == 12)
							{
								decimal credit9 = default(decimal);
								string msgError15 = "";
								decimal basePrice = default(decimal);
								MeliPayamak_GetCredit(ref credit9, ref msgError15, ref basePrice, result4);
								credit9 = credit9;
								if (credit9 > 0m)
								{
									decimal.TryParse(credit9.ToString(), out var result21);
									decimal.TryParse(result21.ToString(), out result7);
								}
								else
								{
									Exception innerException41 = new Exception();
									Exception e41 = new Exception(Messages.msgErrorPRSendSmsCreditNotSufficient, innerException41);
									ErrorSignal.FromCurrentContext().Raise(e41);
								}
								if (result7 >= num)
								{
									int num16 = 0;
									string text13 = "";
									for (int num17 = 0; num17 < count; num17++)
									{
										long[] result22 = new long[1];
										string msgError16 = "";
										MeliPayamak_SendSms1To1(new string[1] { array[num17] }, array2[num17], array3[num17], array4[num17], ref msgError16, ref result22, smsIsSendByOtherAccount: false, "", "", result4);
										if (result22[0] != -5000)
										{
											MobspGetSMSTankRequestByOTP_Result mobspGetSMSTankRequestByOTP_Result13 = list[num17];
											text13 = text13 + mobspGetSMSTankRequestByOTP_Result13.ID + "," + result22[0] + "|";
											num16++;
										}
										else if (!string.IsNullOrWhiteSpace(msgError16))
										{
											Exception innerException42 = new Exception();
											Exception e42 = new Exception(msgError16, innerException42);
											ErrorSignal.FromCurrentContext().Raise(e42);
										}
									}
									if (num16 > 0 && !string.IsNullOrWhiteSpace(text13))
									{
										DateTime now12 = DateTime.Now;
										DateTime value12 = now12;
										string statusChangeDate12 = now12.ToString("yyyyMMdd", new PersianCulture());
										string statusChangeTime12 = now12.ToString("HH:mm:ss");
										cRMEntities.MobspUpdateSendedDetailStatusAndRefId(text13, 0, statusChangeDate12, statusChangeTime12, appType, value12);
										if (!string.IsNullOrEmpty(msgError))
										{
											Exception innerException43 = new Exception();
											Exception e43 = new Exception(msgError, innerException43);
											ErrorSignal.FromCurrentContext().Raise(e43);
										}
									}
									else
									{
										Exception innerException44 = new Exception();
										Exception e44 = new Exception(msgError, innerException44);
										ErrorSignal.FromCurrentContext().Raise(e44);
									}
								}
								else
								{
									Exception innerException45 = new Exception();
									Exception e45 = new Exception(Messages.msgErrorEndSmsSendAllCredit, innerException45);
									ErrorSignal.FromCurrentContext().Raise(e45);
								}
							}
							else if (smsSettingInfoViewModel.SmsProviderId == 13)
							{
								decimal credit10 = default(decimal);
								string msgError17 = "";
								SmsPlus_GetCredit(ref credit10, ref msgError17, result4);
								credit10 = credit10;
								if (credit10 > 0m)
								{
									decimal.TryParse(credit10.ToString(), out var result23);
									decimal.TryParse(result23.ToString(), out result7);
								}
								else
								{
									Exception innerException46 = new Exception();
									Exception e46 = new Exception(Messages.msgErrorPRSendSmsCreditNotSufficient, innerException46);
									ErrorSignal.FromCurrentContext().Raise(e46);
								}
								if (result7 >= num)
								{
									int num18 = 0;
									string text14 = "";
									for (int num19 = 0; num19 < count; num19++)
									{
										long[] result24 = new long[1];
										string msgError18 = "";
										SmsPlus_SendSms1To1(new string[1] { array[num19] }, array2[num19], array3[num19], array4[num19], ref sIdTemp, ref msgError18, ref result24, smsIsSendByOtherAccount: false, "", "", result4);
										if (result24[0] != -5000)
										{
											MobspGetSMSTankRequestByOTP_Result mobspGetSMSTankRequestByOTP_Result14 = list[num19];
											text14 = text14 + mobspGetSMSTankRequestByOTP_Result14.ID + "," + result24[0] + "|";
											num18++;
										}
										else if (!string.IsNullOrWhiteSpace(msgError18))
										{
											Exception innerException47 = new Exception();
											Exception e47 = new Exception(msgError18, innerException47);
											ErrorSignal.FromCurrentContext().Raise(e47);
										}
									}
									if (num18 > 0 && !string.IsNullOrWhiteSpace(text14))
									{
										DateTime now13 = DateTime.Now;
										DateTime value13 = now13;
										string statusChangeDate13 = now13.ToString("yyyyMMdd", new PersianCulture());
										string statusChangeTime13 = now13.ToString("HH:mm:ss");
										cRMEntities.MobspUpdateSendedDetailStatusAndRefId(text14, 0, statusChangeDate13, statusChangeTime13, appType, value13);
										if (!string.IsNullOrEmpty(msgError))
										{
											Exception innerException48 = new Exception();
											Exception e48 = new Exception(msgError, innerException48);
											ErrorSignal.FromCurrentContext().Raise(e48);
										}
									}
									else
									{
										Exception innerException49 = new Exception();
										Exception e49 = new Exception(msgError, innerException49);
										ErrorSignal.FromCurrentContext().Raise(e49);
									}
								}
								else
								{
									Exception innerException50 = new Exception();
									Exception e50 = new Exception(Messages.msgErrorEndSmsSendAllCredit, innerException50);
									ErrorSignal.FromCurrentContext().Raise(e50);
								}
							}
							else if (smsSettingInfoViewModel.SmsProviderId == 14)
							{
								SmsBimehParsian_SendSms1To1(array, array2, "", "", ref msgError, ref result2, smsIsSendByOtherAccount: false, "", "", result4, cId);
								if (result2[0] != -5000)
								{
									string text15 = "";
									for (int num20 = 0; num20 < result2.Length; num20++)
									{
										MobspGetSMSTankRequestByOTP_Result mobspGetSMSTankRequestByOTP_Result15 = list[num20];
										text15 = text15 + mobspGetSMSTankRequestByOTP_Result15.ID + "," + result2[num20] + "|";
									}
									DateTime now14 = DateTime.Now;
									DateTime value14 = now14;
									string statusChangeDate14 = now14.ToString("yyyyMMdd", new PersianCulture());
									string statusChangeTime14 = now14.ToString("HH:mm:ss");
									cRMEntities.MobspUpdateSendedDetailStatusAndRefId(text15, 0, statusChangeDate14, statusChangeTime14, appType, value14);
								}
								else
								{
									Exception innerException51 = new Exception();
									Exception e51 = new Exception(msgError, innerException51);
									ErrorSignal.FromCurrentContext().Raise(e51);
								}
							}
							else if (smsSettingInfoViewModel.SmsProviderId == 15)
							{
								decimal credit11 = default(decimal);
								string msgError19 = "";
								ISms_GetCredit(ref credit11, ref msgError19, result4);
								credit11 = credit11;
								if (credit11 > 0m)
								{
									decimal.TryParse(credit11.ToString(), out var result25);
									decimal.TryParse(result25.ToString(), out result7);
								}
								else
								{
									Exception innerException52 = new Exception();
									Exception e52 = new Exception(Messages.msgErrorPRSendSmsCreditNotSufficient, innerException52);
									ErrorSignal.FromCurrentContext().Raise(e52);
								}
								if (result7 >= num)
								{
									int num21 = 0;
									string text16 = "";
									for (int num22 = 0; num22 < count; num22++)
									{
										long[] result26 = new long[1];
										string msgError20 = "";
										ISms_SendSms1To1(new string[1] { array[num22] }, array2[num22], array3[num22], array4[num22], ref sIdTemp, ref msgError20, ref result26, smsIsSendByOtherAccount: false, "", "", result4);
										if (result26[0] != -5000)
										{
											MobspGetSMSTankRequestByOTP_Result mobspGetSMSTankRequestByOTP_Result16 = list[num22];
											text16 = text16 + mobspGetSMSTankRequestByOTP_Result16.ID + "," + result26[0] + "|";
											num21++;
										}
										else if (!string.IsNullOrWhiteSpace(msgError20))
										{
											Exception innerException53 = new Exception();
											Exception e53 = new Exception(msgError20, innerException53);
											ErrorSignal.FromCurrentContext().Raise(e53);
										}
									}
									if (num21 > 0 && !string.IsNullOrWhiteSpace(text16))
									{
										DateTime now15 = DateTime.Now;
										DateTime value15 = now15;
										string statusChangeDate15 = now15.ToString("yyyyMMdd", new PersianCulture());
										string statusChangeTime15 = now15.ToString("HH:mm:ss");
										cRMEntities.MobspUpdateSendedDetailStatusAndRefId(text16, 0, statusChangeDate15, statusChangeTime15, appType, value15);
										if (!string.IsNullOrEmpty(msgError))
										{
											Exception innerException54 = new Exception();
											Exception e54 = new Exception(msgError, innerException54);
											ErrorSignal.FromCurrentContext().Raise(e54);
										}
									}
									else
									{
										Exception innerException55 = new Exception();
										Exception e55 = new Exception(msgError, innerException55);
										ErrorSignal.FromCurrentContext().Raise(e55);
									}
								}
								else
								{
									Exception innerException56 = new Exception();
									Exception e56 = new Exception(Messages.msgErrorEndSmsSendAllCredit, innerException56);
									ErrorSignal.FromCurrentContext().Raise(e56);
								}
							}
							else if (smsSettingInfoViewModel.SmsProviderId == 16)
							{
								decimal credit12 = default(decimal);
								string msgError21 = "";
								Nimaad_GetCredit(ref credit12, ref msgError21, result4);
								credit12 = credit12;
								if (credit12 > 0m)
								{
									decimal.TryParse(credit12.ToString(), out var result27);
									decimal.TryParse(result27.ToString(), out result7);
								}
								else
								{
									Exception innerException57 = new Exception();
									Exception e57 = new Exception(Messages.msgErrorPRSendSmsCreditNotSufficient, innerException57);
									ErrorSignal.FromCurrentContext().Raise(e57);
								}
								if (result7 >= num)
								{
									Nimaad_SendSms1To1(array, array2, array3[0], array4[0], array5, array6, ref sIdTemp, ref msgError, ref lstGetId, ref result2, smsIsSendByOtherAccount: false, "", "", result4);
									if (result2[0] != -5000)
									{
										string text17 = "";
										for (int num23 = 0; num23 < result2.Length; num23++)
										{
											MobspGetSMSTankRequestByOTP_Result mobspGetSMSTankRequestByOTP_Result17 = list[num23];
											text17 = text17 + mobspGetSMSTankRequestByOTP_Result17.ID + "," + result2[num23] + "|";
										}
										DateTime now16 = DateTime.Now;
										DateTime value16 = now16;
										string statusChangeDate16 = now16.ToString("yyyyMMdd", new PersianCulture());
										string statusChangeTime16 = now16.ToString("HH:mm:ss");
										cRMEntities.MobspUpdateSendedDetailStatusAndRefId(text17, 0, statusChangeDate16, statusChangeTime16, appType, value16);
									}
									else
									{
										Exception innerException58 = new Exception();
										Exception e58 = new Exception(msgError, innerException58);
										ErrorSignal.FromCurrentContext().Raise(e58);
									}
								}
								else
								{
									Exception innerException59 = new Exception();
									Exception e59 = new Exception(Messages.msgErrorEndSmsSendAllCredit, innerException59);
									ErrorSignal.FromCurrentContext().Raise(e59);
								}
							}
							else if (smsSettingInfoViewModel.SmsProviderId == 17)
							{
								decimal credit13 = default(decimal);
								string msgError22 = "";
								FarazSms_GetCredit(ref credit13, ref msgError22, result4);
								credit13 = credit13;
								if (credit13 > 0m)
								{
									decimal.TryParse(credit13.ToString(), out var result28);
									decimal.TryParse(result28.ToString(), out result7);
								}
								else
								{
									Exception innerException60 = new Exception();
									Exception e60 = new Exception(Messages.msgErrorPRSendSmsCreditNotSufficient, innerException60);
									ErrorSignal.FromCurrentContext().Raise(e60);
								}
								if (result7 >= num)
								{
									int num24 = 0;
									string text18 = "";
									for (int num25 = 0; num25 < count; num25++)
									{
										long[] result29 = new long[1];
										string msgError23 = "";
										FarazSms_SendSms1To1(new string[1] { array[num25] }, array2[num25], array3[num25], array4[num25], ref sIdTemp, ref msgError23, ref result29, smsIsSendByOtherAccount: false, "", "", result4);
										if (result29[0] != -5000)
										{
											MobspGetSMSTankRequestByOTP_Result mobspGetSMSTankRequestByOTP_Result18 = list[num25];
											text18 = text18 + mobspGetSMSTankRequestByOTP_Result18.ID + "," + result29[0] + "|";
											num24++;
										}
										else if (!string.IsNullOrWhiteSpace(msgError23))
										{
											Exception innerException61 = new Exception();
											Exception e61 = new Exception(msgError23, innerException61);
											ErrorSignal.FromCurrentContext().Raise(e61);
										}
									}
									if (num24 > 0 && !string.IsNullOrWhiteSpace(text18))
									{
										DateTime now17 = DateTime.Now;
										DateTime value17 = now17;
										string statusChangeDate17 = now17.ToString("yyyyMMdd", new PersianCulture());
										string statusChangeTime17 = now17.ToString("HH:mm:ss");
										cRMEntities.MobspUpdateSendedDetailStatusAndRefId(text18, 0, statusChangeDate17, statusChangeTime17, appType, value17);
										if (!string.IsNullOrEmpty(msgError))
										{
											Exception innerException62 = new Exception();
											Exception e62 = new Exception(msgError, innerException62);
											ErrorSignal.FromCurrentContext().Raise(e62);
										}
									}
									else
									{
										Exception innerException63 = new Exception();
										Exception e63 = new Exception(msgError, innerException63);
										ErrorSignal.FromCurrentContext().Raise(e63);
									}
								}
								else
								{
									Exception innerException64 = new Exception();
									Exception e64 = new Exception(Messages.msgErrorEndSmsSendAllCredit, innerException64);
									ErrorSignal.FromCurrentContext().Raise(e64);
								}
							}
							else if (smsSettingInfoViewModel.SmsProviderId == 18)
							{
								decimal credit14 = default(decimal);
								string msgError24 = "";
								Sharif_GetCredit(ref credit14, ref msgError24, result4);
								credit14 = credit14;
								if (credit14 > 0m)
								{
									decimal.TryParse(credit14.ToString(), out var result30);
									decimal.TryParse(result30.ToString(), out result7);
								}
								else
								{
									Exception innerException65 = new Exception();
									Exception e65 = new Exception(Messages.msgErrorPRSendSmsCreditNotSufficient, innerException65);
									ErrorSignal.FromCurrentContext().Raise(e65);
								}
								if (result7 >= num)
								{
									int num26 = 0;
									string text19 = "";
									for (int num27 = 0; num27 < count; num27++)
									{
										long[] result31 = new long[1];
										string msgError25 = "";
										Sharif_SendSms1To1(new string[1] { array[num27] }, array2[num27], array3[num27], array4[num27], ref msgError25, ref result31, smsIsSendByOtherAccount: false, "", "", result4);
										if (result31[0] != -5000)
										{
											MobspGetSMSTankRequestByOTP_Result mobspGetSMSTankRequestByOTP_Result19 = list[num27];
											text19 = text19 + mobspGetSMSTankRequestByOTP_Result19.ID + "," + result31[0] + "|";
											num26++;
										}
										else if (!string.IsNullOrWhiteSpace(msgError25))
										{
											Exception innerException66 = new Exception();
											Exception e66 = new Exception(msgError25, innerException66);
											ErrorSignal.FromCurrentContext().Raise(e66);
										}
									}
									if (num26 > 0 && !string.IsNullOrWhiteSpace(text19))
									{
										DateTime now18 = DateTime.Now;
										DateTime value18 = now18;
										string statusChangeDate18 = now18.ToString("yyyyMMdd", new PersianCulture());
										string statusChangeTime18 = now18.ToString("HH:mm:ss");
										cRMEntities.MobspUpdateSendedDetailStatusAndRefId(text19, 0, statusChangeDate18, statusChangeTime18, appType, value18);
										if (!string.IsNullOrEmpty(msgError))
										{
											Exception innerException67 = new Exception();
											Exception e67 = new Exception(msgError, innerException67);
											ErrorSignal.FromCurrentContext().Raise(e67);
										}
									}
									else
									{
										Exception innerException68 = new Exception();
										Exception e68 = new Exception(msgError, innerException68);
										ErrorSignal.FromCurrentContext().Raise(e68);
									}
								}
								else
								{
									Exception innerException69 = new Exception();
									Exception e69 = new Exception(Messages.msgErrorEndSmsSendAllCredit, innerException69);
									ErrorSignal.FromCurrentContext().Raise(e69);
								}
							}
							else if (smsSettingInfoViewModel.SmsProviderId == 19)
							{
								decimal credit15 = default(decimal);
								string msgError26 = "";
								SunWay_GetCredit(ref credit15, ref msgError26, result4);
								credit15 = credit15;
								if (credit15 > 0m)
								{
									decimal.TryParse(credit15.ToString(), out var result32);
									decimal.TryParse(result32.ToString(), out result7);
								}
								else
								{
									Exception innerException70 = new Exception();
									Exception e70 = new Exception(Messages.msgErrorPRSendSmsCreditNotSufficient, innerException70);
									ErrorSignal.FromCurrentContext().Raise(e70);
								}
								if (result7 >= num)
								{
									SunWay_SendSms1To1(array, array2, array3[0], array4[0], array5, array6, ref sIdTemp, ref msgError, ref lstGetId, ref result2, smsIsSendByOtherAccount: false, "", "", result4);
									if (result2[0] != -5000)
									{
										string text20 = "";
										for (int num28 = 0; num28 < result2.Length; num28++)
										{
											MobspGetSMSTankRequestByOTP_Result mobspGetSMSTankRequestByOTP_Result20 = list[num28];
											text20 = text20 + mobspGetSMSTankRequestByOTP_Result20.ID + "," + result2[num28] + "|";
										}
										DateTime now19 = DateTime.Now;
										DateTime value19 = now19;
										string statusChangeDate19 = now19.ToString("yyyyMMdd", new PersianCulture());
										string statusChangeTime19 = now19.ToString("HH:mm:ss");
										cRMEntities.MobspUpdateSendedDetailStatusAndRefId(text20, 0, statusChangeDate19, statusChangeTime19, appType, value19);
									}
									else
									{
										Exception innerException71 = new Exception();
										Exception e71 = new Exception(msgError, innerException71);
										ErrorSignal.FromCurrentContext().Raise(e71);
									}
								}
								else
								{
									Exception innerException72 = new Exception();
									Exception e72 = new Exception(Messages.msgErrorEndSmsSendAllCredit, innerException72);
									ErrorSignal.FromCurrentContext().Raise(e72);
								}
							}
							else if (smsSettingInfoViewModel.SmsProviderId == 20)
							{
								decimal credit16 = default(decimal);
								string msgError27 = "";
								CandooSms_GetCredit(ref credit16, ref msgError27, result4);
								credit16 = credit16;
								if (credit16 > 0m)
								{
									decimal.TryParse(credit16.ToString(), out var result33);
									decimal.TryParse(result33.ToString(), out result7);
								}
								else
								{
									Exception innerException73 = new Exception();
									Exception e73 = new Exception(Messages.msgErrorPRSendSmsCreditNotSufficient, innerException73);
									ErrorSignal.FromCurrentContext().Raise(e73);
								}
								if (result7 >= num)
								{
									CandooSms_SendSms1To1(array, array2, array3[0], array4[0], array5, array6, ref sIdTemp, ref msgError, ref lstGetId, ref result2, smsIsSendByOtherAccount: false, "", "", result4);
									if (result2[0] != -5000)
									{
										string text21 = "";
										for (int num29 = 0; num29 < result2.Length; num29++)
										{
											MobspGetSMSTankRequestByOTP_Result mobspGetSMSTankRequestByOTP_Result21 = list[num29];
											text21 = text21 + mobspGetSMSTankRequestByOTP_Result21.ID + "," + result2[num29] + "|";
										}
										DateTime now20 = DateTime.Now;
										DateTime value20 = now20;
										string statusChangeDate20 = now20.ToString("yyyyMMdd", new PersianCulture());
										string statusChangeTime20 = now20.ToString("HH:mm:ss");
										cRMEntities.MobspUpdateSendedDetailStatusAndRefId(text21, 0, statusChangeDate20, statusChangeTime20, appType, value20);
									}
									else
									{
										Exception innerException74 = new Exception();
										Exception e74 = new Exception(msgError, innerException74);
										ErrorSignal.FromCurrentContext().Raise(e74);
									}
								}
								else
								{
									Exception innerException75 = new Exception();
									Exception e75 = new Exception(Messages.msgErrorEndSmsSendAllCredit, innerException75);
									ErrorSignal.FromCurrentContext().Raise(e75);
								}
							}
							else if (smsSettingInfoViewModel.SmsProviderId == 21)
							{
								string msgError28 = "";
								decimal credit17 = default(decimal);
								ParmisSms_GetCredit(ref credit17, ref msgError28, result4);
								credit17 = credit17;
								if (credit17 > 0m)
								{
									decimal.TryParse(credit17.ToString(), out var result34);
									decimal.TryParse(result34.ToString(), out result7);
								}
								else
								{
									Exception innerException76 = new Exception();
									Exception e76 = new Exception(Messages.msgErrorPRSendSmsCreditNotSufficient, innerException76);
									ErrorSignal.FromCurrentContext().Raise(e76);
								}
								if (result7 >= num)
								{
									ParmisSms_SendSms1To1(array, array2, array3[0], array4[0], ref msgError, ref result2, smsIsSendByOtherAccount: false, "", "", result4);
									if (result2[0] != -5000)
									{
										string text22 = "";
										for (int num30 = 0; num30 < result2.Length; num30++)
										{
											MobspGetSMSTankRequestByOTP_Result mobspGetSMSTankRequestByOTP_Result22 = list[num30];
											text22 = text22 + mobspGetSMSTankRequestByOTP_Result22.ID + "," + result2[num30] + "|";
										}
										DateTime now21 = DateTime.Now;
										DateTime value21 = now21;
										string statusChangeDate21 = now21.ToString("yyyyMMdd", new PersianCulture());
										string statusChangeTime21 = now21.ToString("HH:mm:ss");
										cRMEntities.MobspUpdateSendedDetailStatusAndRefId(text22, 0, statusChangeDate21, statusChangeTime21, appType, value21);
									}
									else
									{
										Exception innerException77 = new Exception();
										Exception e77 = new Exception(msgError, innerException77);
										ErrorSignal.FromCurrentContext().Raise(e77);
									}
								}
								else
								{
									Exception innerException78 = new Exception();
									Exception e78 = new Exception(Messages.msgErrorEndSmsSendAllCredit, innerException78);
									ErrorSignal.FromCurrentContext().Raise(e78);
								}
							}
							else if (smsSettingInfoViewModel.SmsProviderId == 22)
							{
								string msgError29 = "";
								decimal credit18 = default(decimal);
								SmsMelli_GetCredit(ref credit18, ref msgError29, result4);
								credit18 = credit18;
								if (credit18 > 0m)
								{
									decimal.TryParse(credit18.ToString(), out var result35);
									decimal.TryParse(result35.ToString(), out result7);
								}
								else
								{
									Exception innerException79 = new Exception();
									Exception e79 = new Exception(Messages.msgErrorPRSendSmsCreditNotSufficient, innerException79);
									ErrorSignal.FromCurrentContext().Raise(e79);
								}
								if (result7 >= num)
								{
									SmsMelli_SendSms1To1(array, array2, array3[0], array4[0], ref msgError, ref result2, smsIsSendByOtherAccount: false, "", "", result4);
									if (result2[0] != -5000)
									{
										string text23 = "";
										for (int num31 = 0; num31 < result2.Length; num31++)
										{
											MobspGetSMSTankRequestByOTP_Result mobspGetSMSTankRequestByOTP_Result23 = list[num31];
											text23 = text23 + mobspGetSMSTankRequestByOTP_Result23.ID + "," + result2[num31] + "|";
										}
										DateTime now22 = DateTime.Now;
										DateTime value22 = now22;
										string statusChangeDate22 = now22.ToString("yyyyMMdd", new PersianCulture());
										string statusChangeTime22 = now22.ToString("HH:mm:ss");
										cRMEntities.MobspUpdateSendedDetailStatusAndRefId(text23, 0, statusChangeDate22, statusChangeTime22, appType, value22);
									}
									else
									{
										Exception innerException80 = new Exception();
										Exception e80 = new Exception(msgError, innerException80);
										ErrorSignal.FromCurrentContext().Raise(e80);
									}
								}
								else
								{
									Exception innerException81 = new Exception();
									Exception e81 = new Exception(Messages.msgErrorEndSmsSendAllCredit, innerException81);
									ErrorSignal.FromCurrentContext().Raise(e81);
								}
							}
							else if (smsSettingInfoViewModel.SmsProviderId == 23)
							{
								string msgError30 = "";
								decimal credit19 = default(decimal);
								ParsGreen_GetCredit(ref credit19, ref msgError30, result4);
								credit19 = credit19;
								if (credit19 > 0m)
								{
									decimal.TryParse(credit19.ToString(), out var result36);
									decimal.TryParse(result36.ToString(), out result7);
								}
								else
								{
									Exception innerException82 = new Exception();
									Exception e82 = new Exception(Messages.msgErrorPRSendSmsCreditNotSufficient, innerException82);
									ErrorSignal.FromCurrentContext().Raise(e82);
								}
								if (result7 >= num)
								{
									ParsGreen_SendSms1To1(array, array2, array3[0], array4[0], ref msgError, ref result2, smsIsSendByOtherAccount: false, "", "", result4);
									if (result2[0] != -5000)
									{
										string text24 = "";
										for (int num32 = 0; num32 < result2.Length; num32++)
										{
											MobspGetSMSTankRequestByOTP_Result mobspGetSMSTankRequestByOTP_Result24 = list[num32];
											text24 = text24 + mobspGetSMSTankRequestByOTP_Result24.ID + "," + result2[num32] + "|";
										}
										DateTime now23 = DateTime.Now;
										DateTime value23 = now23;
										string statusChangeDate23 = now23.ToString("yyyyMMdd", new PersianCulture());
										string statusChangeTime23 = now23.ToString("HH:mm:ss");
										cRMEntities.MobspUpdateSendedDetailStatusAndRefId(text24, 0, statusChangeDate23, statusChangeTime23, appType, value23);
									}
									else
									{
										Exception innerException83 = new Exception();
										Exception e83 = new Exception(msgError, innerException83);
										ErrorSignal.FromCurrentContext().Raise(e83);
									}
								}
								else
								{
									Exception innerException84 = new Exception();
									Exception e84 = new Exception(Messages.msgErrorEndSmsSendAllCredit, innerException84);
									ErrorSignal.FromCurrentContext().Raise(e84);
								}
							}
							else if (smsSettingInfoViewModel.SmsProviderId == 24)
							{
								string msgError31 = "";
								decimal credit20 = default(decimal);
								Armaghan_GetCredit(ref credit20, ref msgError31, result4);
								credit20 = credit20;
								if (credit20 > 0m)
								{
									decimal.TryParse(credit20.ToString(), out var result37);
									decimal.TryParse(result37.ToString(), out result7);
								}
								else
								{
									Exception innerException85 = new Exception();
									Exception e85 = new Exception(Messages.msgErrorPRSendSmsCreditNotSufficient, innerException85);
									ErrorSignal.FromCurrentContext().Raise(e85);
								}
								if (result7 >= num)
								{
									Armaghan_SendSms1To1(array, array2, array3[0], array4[0], ref msgError, ref result2, smsIsSendByOtherAccount: false, "", "", result4);
									if (result2[0] != -5000)
									{
										string text25 = "";
										for (int num33 = 0; num33 < result2.Length; num33++)
										{
											MobspGetSMSTankRequestByOTP_Result mobspGetSMSTankRequestByOTP_Result25 = list[num33];
											text25 = text25 + mobspGetSMSTankRequestByOTP_Result25.ID + "," + result2[num33] + "|";
										}
										DateTime now24 = DateTime.Now;
										DateTime value24 = now24;
										string statusChangeDate24 = now24.ToString("yyyyMMdd", new PersianCulture());
										string statusChangeTime24 = now24.ToString("HH:mm:ss");
										cRMEntities.MobspUpdateSendedDetailStatusAndRefId(text25, 0, statusChangeDate24, statusChangeTime24, appType, value24);
									}
									else
									{
										Exception innerException86 = new Exception();
										Exception e86 = new Exception(msgError, innerException86);
										ErrorSignal.FromCurrentContext().Raise(e86);
									}
								}
								else
								{
									Exception innerException87 = new Exception();
									Exception e87 = new Exception(Messages.msgErrorEndSmsSendAllCredit, innerException87);
									ErrorSignal.FromCurrentContext().Raise(e87);
								}
							}
							else if (smsSettingInfoViewModel.SmsProviderId == 25)
							{
								string msgError32 = "";
								decimal credit21 = default(decimal);
								Rahyab_GetCredit(ref credit21, ref msgError32, result4);
								credit21 = credit21;
								if (credit21 > 0m)
								{
									decimal.TryParse(credit21.ToString(), out var result38);
									decimal.TryParse(result38.ToString(), out result7);
								}
								else
								{
									Exception innerException88 = new Exception();
									Exception e88 = new Exception(Messages.msgErrorPRSendSmsCreditNotSufficient, innerException88);
									ErrorSignal.FromCurrentContext().Raise(e88);
								}
								if (result7 >= num)
								{
									Rahyab_SendSms1To1(array, array2, array3[0], array4[0], ref msgError, ref result3, smsIsSendByOtherAccount: false, "", "", result4);
									if (result3[0] != "-5000")
									{
										string text26 = "";
										for (int num34 = 0; num34 < result3.Length; num34++)
										{
											MobspGetSMSTankRequestByOTP_Result mobspGetSMSTankRequestByOTP_Result26 = list[num34];
											text26 = text26 + mobspGetSMSTankRequestByOTP_Result26.ID + "," + result3[num34] + "|";
										}
										DateTime now25 = DateTime.Now;
										DateTime value25 = now25;
										string statusChangeDate25 = now25.ToString("yyyyMMdd", new PersianCulture());
										string statusChangeTime25 = now25.ToString("HH:mm:ss");
										cRMEntities.MobspUpdateSendedDetailStatusAndRefId(text26, 0, statusChangeDate25, statusChangeTime25, appType, value25);
									}
									else
									{
										Exception innerException89 = new Exception();
										Exception e89 = new Exception(msgError, innerException89);
										ErrorSignal.FromCurrentContext().Raise(e89);
									}
								}
								else
								{
									Exception innerException90 = new Exception();
									Exception e90 = new Exception(Messages.msgErrorEndSmsSendAllCredit, innerException90);
									ErrorSignal.FromCurrentContext().Raise(e90);
								}
							}
							else if (smsSettingInfoViewModel.SmsProviderId == 26)
							{
								string msgError33 = "";
								decimal credit22 = default(decimal);
								IPPanel_GetCredit(ref credit22, ref msgError33, result4);
								credit22 = credit22;
								if (credit22 > 0m)
								{
									decimal.TryParse(credit22.ToString(), out var result39);
									decimal.TryParse(result39.ToString(), out result7);
								}
								else
								{
									Exception innerException91 = new Exception();
									Exception e91 = new Exception(Messages.msgErrorPRSendSmsCreditNotSufficient, innerException91);
									ErrorSignal.FromCurrentContext().Raise(e91);
								}
								if (result7 >= num)
								{
									IPPanel_SendSms1To1(array, array2, array3[0], array4[0], ref msgError, ref result3, smsIsSendByOtherAccount: false, "", "", result4);
									if (result3[0] != "-5000")
									{
										string text27 = "";
										for (int num35 = 0; num35 < result3.Length; num35++)
										{
											MobspGetSMSTankRequestByOTP_Result mobspGetSMSTankRequestByOTP_Result27 = list[num35];
											text27 = text27 + mobspGetSMSTankRequestByOTP_Result27.ID + "," + result3[num35] + "|";
										}
										DateTime now26 = DateTime.Now;
										DateTime value26 = now26;
										string statusChangeDate26 = now26.ToString("yyyyMMdd", new PersianCulture());
										string statusChangeTime26 = now26.ToString("HH:mm:ss");
										cRMEntities.MobspUpdateSendedDetailStatusAndRefId(text27, 0, statusChangeDate26, statusChangeTime26, appType, value26);
									}
									else
									{
										Exception innerException92 = new Exception();
										Exception e92 = new Exception(msgError, innerException92);
										ErrorSignal.FromCurrentContext().Raise(e92);
									}
								}
								else
								{
									Exception innerException93 = new Exception();
									Exception e93 = new Exception(Messages.msgErrorEndSmsSendAllCredit, innerException93);
									ErrorSignal.FromCurrentContext().Raise(e93);
								}
							}
						}
					}
				}
			}
		}
		catch (Exception e94)
		{
			ErrorSignal.FromCurrentContext().Raise(e94);
		}
		finally
		{
			cRMEntities.Dispose();
		}
		return result;
	}

	public SmsSettingInfoViewModel GetSmsProvider(int? smsProviderId, out int freeSmsCount)
	{
		SmsSettingInfoViewModel smsSettingInfoViewModel = new SmsSettingInfoViewModel();
		freeSmsCount = GetFreeSmsCount();
		if (freeSmsCount > 0)
		{
			smsSettingInfoViewModel = new SmsSettingInfoViewModel
			{
				SmsWsUserName = "DemoInternal",
				SmsWsPassword = "DemoAllSoftware1391",
				SmsWsDomainNamed = Configuration.SmsWsDomainNamed,
				SmsWsFromNumber = "30002872500500",
				SmsWsEnCost = "300",
				SmsWsFaCost = "150",
				SmsSendIsActive = true,
				SmsReceiveIsActive = false,
				SmsProviderId = 1
			};
		}
		else
		{
			CRMEntities cRMEntities = new CRMEntities();
			try
			{
				int result = 0;
				int.TryParse(smsProviderId.ToString(), out result);
				MobspSelectSmsProvidersById_Result mobspSelectSmsProvidersById_Result = Enumerable.FirstOrDefault<MobspSelectSmsProvidersById_Result>((IEnumerable<MobspSelectSmsProvidersById_Result>)cRMEntities.MobspSelectSmsProvidersById(result));
				if (mobspSelectSmsProvidersById_Result != null)
				{
					smsSettingInfoViewModel = new SmsSettingInfoViewModel
					{
						SmsWsUserName = mobspSelectSmsProvidersById_Result.UserName,
						SmsWsPassword = ((!string.IsNullOrEmpty(mobspSelectSmsProvidersById_Result.Password)) ? XorCipher.DecryptByPrivateKey(mobspSelectSmsProvidersById_Result.Password) : string.Empty),
						SmsWsDomainNamed = mobspSelectSmsProvidersById_Result.ProviderDomain,
						SmsWsFromNumber = mobspSelectSmsProvidersById_Result.Number,
						SmsWsEnCost = mobspSelectSmsProvidersById_Result.EnCost.GetValueOrDefault().ToString().Replace(".00", ""),
						SmsWsFaCost = mobspSelectSmsProvidersById_Result.FaCost.GetValueOrDefault().ToString().Replace(".00", ""),
						SmsSendIsActive = (mobspSelectSmsProvidersById_Result.SendIsActive.HasValue && mobspSelectSmsProvidersById_Result.SendIsActive.GetValueOrDefault()),
						SmsReceiveIsActive = (mobspSelectSmsProvidersById_Result.ReceiveIsActive.HasValue && mobspSelectSmsProvidersById_Result.ReceiveIsActive.GetValueOrDefault()),
						SmsProviderId = mobspSelectSmsProvidersById_Result.Id,
						TokenUserName = mobspSelectSmsProvidersById_Result.TokenUserName,
						SmsCustomer = mobspSelectSmsProvidersById_Result.SmsCustomer
					};
				}
				else
				{
					smsSettingInfoViewModel = SmsSeting.Get();
					if (!smsSettingInfoViewModel.DecryptedPassword.GetValueOrDefault())
					{
						smsSettingInfoViewModel.SmsWsPassword = ((!string.IsNullOrEmpty(smsSettingInfoViewModel.SmsWsPassword)) ? XorCipher.TryDecryptOrReturnOriginal(smsSettingInfoViewModel.SmsWsPassword) : string.Empty);
						smsSettingInfoViewModel.DecryptedPassword = true;
					}
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			finally
			{
				cRMEntities.Dispose();
			}
		}
		return smsSettingInfoViewModel;
	}

	public void GetCreditSmsCount(ref decimal creditSmsCount, ref string errorMessage, int smsProviderId)
	{
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSetting = GetSmsSetting(out freeSmsCount);
			if (smsProviderId == 0)
			{
				int.TryParse(smsSetting.SmsProviderId.ToString(), out smsProviderId);
			}
			if (smsProviderId != 0 && smsProviderId == 10)
			{
				SmsIr_GetCredit(ref creditSmsCount, ref errorMessage, smsProviderId);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	public void MehrAfraz_SendSms1To1(string[] lstMobile, string[] lstBody, int[] lstCmessage, string[] lstFromNumber, int[] lstTypeUnicodeMessage, string[] lstSchedulDate, ref int sIdTemp, ref string msgError, ref long[] lstGetId, ref long[] result, bool smsIsSendByOtherAccount = false, string smsWebServiceUserName = "", string smsWebServicePassword = "", int smsProviderId = 0)
	{
		Mobile.SmsMehrAfraz.ServiceSoapClient serviceSoapClient = new Mobile.SmsMehrAfraz.ServiceSoapClient();
		result = new long[1];
		result[0] = -7L;
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			sIdTemp = ReturnSid();
			SysSeting.Get();
			_ = smsSettingInfoViewModel.SmsWsUserName;
			_ = smsSettingInfoViewModel.SmsWsPassword;
			if (!smsIsSendByOtherAccount || string.IsNullOrWhiteSpace(smsWebServiceUserName) || !string.IsNullOrWhiteSpace(smsWebServicePassword))
			{
			}
			while (result[0] == -7)
			{
				lstGetId[0] = sIdTemp;
				result = serviceSoapClient.SendSms1To1(smsSettingInfoViewModel.SmsWsDomainNamed, smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, lstBody, lstMobile, lstGetId, lstCmessage, lstFromNumber, lstTypeUnicodeMessage, lstSchedulDate, 2, 0, 0);
				sIdTemp++;
			}
			if (result[0].ToString().Length < 4)
			{
				msgError = serviceSoapClient.ShowError(result[0].ToString(), "FA");
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

	public void MehrAfraz_SendSms(string numbers, string body, int cmessage, string fromNumber, ref int sIdTemp, ref string msgError, ref string result, int smsProviderId = 0)
	{
		msgError = "";
		result = "-7";
		try
		{
			Mobile.SmsMehrAfraz.ServiceSoapClient serviceSoapClient = new Mobile.SmsMehrAfraz.ServiceSoapClient();
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			sIdTemp = ReturnSid();
			while (result == "-7")
			{
				result = serviceSoapClient.SendSms(smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, body, numbers, sIdTemp.ToString(), cmessage, 1, "", smsSettingInfoViewModel.SmsWsDomainNamed, smsSettingInfoViewModel.SmsWsFromNumber, 0, 0, "", "");
				sIdTemp++;
			}
			if (result.Length < 4)
			{
				msgError = serviceSoapClient.ShowError(result, "FA");
				result = "-50000";
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = "-50000";
			msgError = ex.Message;
		}
	}

	public void MehrAfraz_GetMessageDelivery(long[] refIdArr, ref int[] result, ref string msgError, int smsProviderId = 0)
	{
		try
		{
			Mobile.SmsMehrAfraz.ServiceSoapClient serviceSoapClient = new Mobile.SmsMehrAfraz.ServiceSoapClient();
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			result = new int[Enumerable.Count<long>((IEnumerable<long>)refIdArr)];
			result[0] = -7;
			if (smsSettingInfoViewModel != null)
			{
				while (result[0] == -7)
				{
					result = serviceSoapClient.GetMessageDelivery1to1(smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, smsSettingInfoViewModel.SmsWsDomainNamed, refIdArr);
				}
				if (result[0].ToString().Length < 4)
				{
					msgError = serviceSoapClient.ShowError(result[0].ToString(), "FA");
					Exception innerException = new Exception();
					Exception e = new Exception(msgError, innerException);
					ErrorSignal.FromCurrentContext().Raise(e);
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
		}
	}

	public DataTable MehrAfraz_ReceiveSms(int smsProviderId = 0)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		DataTable result = new DataTable();
		try
		{
			Mobile.SmsMehrAfraz.ServiceSoapClient serviceSoapClient = new Mobile.SmsMehrAfraz.ServiceSoapClient();
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			result = serviceSoapClient.ReceiveSms(smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, lReceiveAllmsg: true, smsSettingInfoViewModel.SmsWsDomainNamed, smsSettingInfoViewModel.SmsWsFromNumber, "", "");
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public string[] MehrAfraz_GetUserInfo(ref string msgError, int smsProviderId = 0)
	{
		Mobile.SmsMehrAfraz.ServiceSoapClient serviceSoapClient = new Mobile.SmsMehrAfraz.ServiceSoapClient();
		string[] array = new string[10];
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			array = serviceSoapClient.GetuserInfo(smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, smsSettingInfoViewModel.SmsWsDomainNamed);
			if (array.Length < 3)
			{
				msgError = serviceSoapClient.ShowError(array[0], "FA");
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
		}
		return array;
	}

	public void MehrAfraz_SENDVERIFICATIONCODE(string lstMobile, int codeVerification, ref int sIdTemp, ref string msgError, ref long[] lstGetId, ref long[] result, int smsProviderId = 0)
	{
		Mobile.SmsMehrAfraz.ServiceSoapClient serviceSoapClient = new Mobile.SmsMehrAfraz.ServiceSoapClient();
		result = new long[1];
		result[0] = -7L;
		msgError = "";
		try
		{
			CRMEntities cRMEntities = new CRMEntities();
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			sIdTemp = ReturnSid();
			SysSeting.Get();
			while (result[0] == -7)
			{
				lstGetId[0] = sIdTemp;
				MobspSelectSmsVerificationFoSetting_Result mobspSelectSmsVerificationFoSetting_Result = Enumerable.FirstOrDefault<MobspSelectSmsVerificationFoSetting_Result>((IEnumerable<MobspSelectSmsVerificationFoSetting_Result>)cRMEntities.MobspSelectSmsVerificationFoSetting());
				result[0] = 0L;
				serviceSoapClient.SENDVERIFICATIONCODE(smsSettingInfoViewModel.SmsWsDomainNamed, smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, lstMobile, mobspSelectSmsVerificationFoSetting_Result.SmsVerificationId.GetValueOrDefault(), codeVerification);
				sIdTemp++;
			}
			if (result[0].ToString().Length < 4)
			{
				msgError = serviceSoapClient.ShowError(result[0].ToString(), "FA");
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

	public void SMSLine_SendSms_Single(string lstMobile, string lstBody, string lstFromNumber, ref string msgError, ref long result, bool smsIsSendByOtherAccount = false, string smsWebServiceUserName = "", string smsWebServicePassword = "", int smsProviderId = 0)
	{
		SMSWebServerService sMSWebServerService = new SMSWebServerService();
		result = 0L;
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			_ = smsSettingInfoViewModel.SmsWsUserName;
			_ = smsSettingInfoViewModel.SmsWsPassword;
			if (smsIsSendByOtherAccount && !string.IsNullOrWhiteSpace(smsWebServiceUserName))
			{
				string.IsNullOrWhiteSpace(smsWebServicePassword);
			}
			long.TryParse(sMSWebServerService.SendSMS(smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, lstMobile, lstBody, lstFromNumber), out result);
			if (result < -1)
			{
				msgError = Messages.msgErrorSendError + "<br>" + result;
				result = 0L;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = 0L;
			msgError = ex.Message;
		}
	}

	public void SMSLine_SendSms_Group(string numbers, string body, int cmessage, string fromNumber, ref string msgError, ref string result, int smsProviderId = 0)
	{
		SMSWebServerService sMSWebServerService = new SMSWebServerService();
		result = "0";
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			result = sMSWebServerService.Send_GROUP_SMS(smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, numbers, body, smsSettingInfoViewModel.SmsWsFromNumber, cmessage.ToString());
			if (result.StartsWith("-"))
			{
				msgError = Messages.msgErrorSendError + "<br>" + result;
				result = "0";
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = "0";
			msgError = ex.Message;
		}
	}

	public void SMSLine_GetMessageDelivery(long[] refIdArr, ref int[] result, ref string msgError, int smsProviderId = 0)
	{
		try
		{
			SMSWebServerService sMSWebServerService = new SMSWebServerService();
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			result = new int[Enumerable.Count<long>((IEnumerable<long>)refIdArr)];
			result[0] = -7;
			string text = "";
			if (smsSettingInfoViewModel == null)
			{
				return;
			}
			for (int i = 0; i < Enumerable.Count<long>((IEnumerable<long>)refIdArr); i++)
			{
				string text2 = sMSWebServerService.StatusSMS(smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, refIdArr[i].ToString());
				text = text + text2 + ",";
			}
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			if (text.StartsWith("-"))
			{
				msgError = Messages.msgErrorSendError + "<br>" + text;
				Exception innerException = new Exception();
				Exception e = new Exception(msgError, innerException);
				ErrorSignal.FromCurrentContext().Raise(e);
				return;
			}
			string[] array = text.Split(new char[1] { ',' });
			if (array == null)
			{
				return;
			}
			for (int j = 0; j < Enumerable.Count<long>((IEnumerable<long>)refIdArr); j++)
			{
				if (!string.IsNullOrEmpty(array[j]))
				{
					result[j] = int.Parse(array[j]);
					if (result[j] == 1)
					{
						result[j] = 2;
					}
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
		}
	}

	public void SMSLine_GetCredit(ref decimal credit, ref string msgError, int smsProviderId = 0)
	{
		credit = default(decimal);
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			string text = new SMSWebServerService().CREDIT_LINESMS(smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, smsSettingInfoViewModel.SmsWsFromNumber);
			if (!string.IsNullOrEmpty(text))
			{
				if (text.StartsWith("-"))
				{
					msgError = Labels.Error + ": " + text;
					credit = default(decimal);
				}
				else
				{
					credit = decimal.Parse(text);
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			credit = default(decimal);
			msgError = ex.Message;
		}
	}

	public void SMSLine_AllSendedSms(ref long countSms, ref string msgError, int smsProviderId = 0)
	{
		countSms = 0L;
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			string text = new SMSWebServerService().COUNT_SENDSMS(smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword);
			if (!string.IsNullOrEmpty(text))
			{
				if (text.StartsWith("-"))
				{
					msgError = Labels.Error + ": " + text;
					countSms = 0L;
				}
				else
				{
					countSms = long.Parse(text);
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			countSms = 0L;
			msgError = ex.Message;
		}
	}

	public void FaraPayamak_SendSms1To1(string[] lstMobile, string body, int cmessage, string fromNumber, ref string msgError, ref long[] result, bool smsIsSendByOtherAccount = false, string smsWebServiceUserName = "", string smsWebServicePassword = "", int smsProviderId = 0)
	{
		SendSoapClient sendSoapClient = new SendSoapClient("SendSoap");
		result = new long[1];
		msgError = "";
		byte[] status = null;
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			bool isflash = cmessage == 3;
			_ = smsSettingInfoViewModel.SmsWsUserName;
			_ = smsSettingInfoViewModel.SmsWsPassword;
			if (smsIsSendByOtherAccount && !string.IsNullOrWhiteSpace(smsWebServiceUserName))
			{
				string.IsNullOrWhiteSpace(smsWebServicePassword);
			}
			switch (sendSoapClient.SendSms(smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, lstMobile, fromNumber, body, isflash, "", ref result, ref status))
			{
			case 0:
				msgError = Messages.msgErrorFPSendSmsIncorrectUsenamePassword;
				break;
			case 2:
				msgError = Messages.msgErrorFPSendSmsCreditNotEnough;
				break;
			case 3:
				msgError = Messages.msgErrorFPSendSmsRestrictionDailySend;
				break;
			case 4:
				msgError = Messages.msgErrorFPSendSmsRestrictionSizeSend;
				break;
			case 5:
				msgError = Messages.msgErrorFPSendSmsSenderNumberNotValid;
				break;
			case 6:
				msgError = Messages.msgErrorFPSendSmsSystemUpdated;
				break;
			case 7:
				msgError = Messages.msgErrorFPSendSmsContainFilterWord;
				break;
			case 1:
				return;
			}
			result[0] = -5000L;
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result[0] = -5000L;
			msgError = ex.Message;
		}
	}

	public void FaraPayamak_SendSms(string numbers, string body, int cmessage, string fromNumber, ref string msgError, ref string result, ref int NumberOfSmsSent, int smsProviderId = 0)
	{
		result = "0";
		try
		{
			SendSoapClient sendSoapClient = new SendSoapClient("SendSoap");
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			bool isflash = cmessage == 3;
			string[] array = numbers.Split(new char[1] { ',' });
			int num = array.Length;
			long[] array2 = new long[num];
			int num2 = 100;
			int num3 = num / num2;
			int num4 = num % num2;
			int num5 = 0;
			int num6 = num2;
			if (num4 != 0)
			{
				num3++;
			}
			for (int i = 0; i < num3; i++)
			{
				if (i == num3 - 1 && num4 != 0)
				{
					num6 = num4;
				}
				string[] array3 = new string[num6];
				for (int j = 0; j < num6; j++)
				{
					num5 = i * num2 + j;
					array3[j] = array[num5];
				}
				long[] recId = null;
				byte[] status = null;
				switch (sendSoapClient.SendSms(smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, array3, fromNumber, body, isflash, "", ref recId, ref status))
				{
				case 1:
				{
					for (int k = 0; k < status.Length; k++)
					{
						num5 = i * num2 + k;
						array2[num5] = recId[k];
						NumberOfSmsSent++;
					}
					continue;
				}
				case 0:
					msgError = Messages.msgErrorFPSendSmsIncorrectUsenamePassword;
					break;
				case 2:
					msgError = Messages.msgErrorFPSendSmsCreditNotEnough;
					break;
				case 3:
					msgError = Messages.msgErrorFPSendSmsRestrictionDailySend;
					break;
				case 4:
					msgError = Messages.msgErrorFPSendSmsRestrictionSizeSend;
					break;
				case 5:
					msgError = Messages.msgErrorFPSendSmsSenderNumberNotValid;
					break;
				case 6:
					msgError = Messages.msgErrorFPSendSmsSystemUpdated;
					break;
				case 7:
					msgError = Messages.msgErrorFPSendSmsContainFilterWord;
					break;
				}
				result = "-5000";
			}
			if (array2 != null)
			{
				for (int l = 0; l < array2.Length; l++)
				{
					result = result + array2[l] + ",";
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = "-5000";
			msgError = ex.Message;
		}
	}

	public void FaraPayamak_GetMessageDelivery(long[] refIdArr, ref int[] result, ref string msgError, int smsProviderId = 0)
	{
		try
		{
			SendSoapClient sendSoapClient = new SendSoapClient("SendSoap");
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			result = new int[Enumerable.Count<long>((IEnumerable<long>)refIdArr)];
			result[0] = -7;
			if (smsSettingInfoViewModel == null)
			{
				return;
			}
			result = sendSoapClient.GetDeliveries(refIdArr, smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword);
			for (int i = 0; i < Enumerable.Count<long>((IEnumerable<long>)refIdArr); i++)
			{
				if (result[i] == 1)
				{
					result[i] = 2;
				}
				else if (result[i] == 35)
				{
					result[i] = 4;
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
		}
	}

	public void FaraPayamak_GetCredit(ref decimal credit, ref string msgError, int smsProviderId = 0)
	{
		credit = default(decimal);
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			credit = decimal.Parse(new SendSoapClient("SendSoap").GetCredit(smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword).ToString());
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
			credit = default(decimal);
		}
	}

	public MessagesBL[] FaraPayamak_GetMessages(int smsProviderId = 0)
	{
		MessagesBL[] result = null;
		try
		{
			SendSoapClient sendSoapClient = new SendSoapClient("SendSoap");
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			result = sendSoapClient.getMessages(smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, 1, "", 0, 100);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public void Asanak_SendSms1To1(string[] lstMobile, string body, string fromNumber, ref string msgError, ref long[] result, bool smsIsSendByOtherAccount = false, string smsWebServiceUserName = "", string smsWebServicePassword = "", int smsProviderId = 0)
	{
		result = new long[1];
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			string text = "";
			for (int i = 0; i < lstMobile.Length; i++)
			{
				text = text + lstMobile[i] + ",";
			}
			if (text.EndsWith(","))
			{
				text = text.TrimEnd(new char[1] { ',' });
			}
			_ = smsSettingInfoViewModel.SmsWsUserName;
			_ = smsSettingInfoViewModel.SmsWsPassword;
			if (smsIsSendByOtherAccount && !string.IsNullOrWhiteSpace(smsWebServiceUserName))
			{
				string.IsNullOrWhiteSpace(smsWebServicePassword);
			}
			HttpClient httpClient = new HttpClient();
			string text2 = $"https://panel.asanak.com/webservice/v1rest/sendsms?username={smsSettingInfoViewModel.SmsWsUserName}&password={smsSettingInfoViewModel.SmsWsPassword}&source={fromNumber}&destination={text}&message={body}";
			httpClient.BaseAddress = new Uri(text2);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			HttpContent content = new StringContent(JsonConvert.SerializeObject(new SmsAsanakSendSmsViewModel
			{
				username = smsSettingInfoViewModel.SmsWsUserName,
				password = smsSettingInfoViewModel.SmsWsPassword,
				source = fromNumber,
				destination = text,
				message = body
			}), Encoding.UTF8, "application/json");
			HttpResponseMessage result2 = httpClient.PostAsync(text2, content).Result;
			if (result2.IsSuccessStatusCode)
			{
				string result3 = result2.Content.ReadAsStringAsync().Result;
				if (!string.IsNullOrEmpty(result3))
				{
					if (result3.IndexOf("[") >= 0)
					{
						result3 = result3.TrimEnd(new char[1] { ']' }).TrimStart(new char[1] { '[' });
						string[] array = result3.Split(new char[1] { ',' });
						if (array != null)
						{
							for (int j = 0; j < Enumerable.Count<string>((IEnumerable<string>)array); j++)
							{
								result[j] = long.Parse(array[j]);
							}
						}
						else
						{
							msgError = Messages.msgErrorRunFunction;
							result[0] = -5000L;
						}
					}
					else
					{
						SmsAsanakSendSmsResultViewModel smsAsanakSendSmsResultViewModel = JsonConvert.DeserializeObject<SmsAsanakSendSmsResultViewModel>(result3);
						if (!string.IsNullOrEmpty(smsAsanakSendSmsResultViewModel.status))
						{
							msgError = smsAsanakSendSmsResultViewModel.status;
							result[0] = -5000L;
						}
						else
						{
							msgError = Messages.msgErrorRunFunction;
							result[0] = -5000L;
						}
					}
				}
				else
				{
					msgError = Messages.msgErrorRunFunction;
					result[0] = -5000L;
				}
			}
			else
			{
				msgError = Messages.msgErrorRunFunction;
				result[0] = -5000L;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
			result[0] = -5000L;
		}
	}

	public void Asanak_SendSms(string numbers, string body, string fromNumber, ref string msgError, ref string result, ref int NumberOfSmsSent, int smsProviderId = 0)
	{
		result = "0";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			string[] array = numbers.Split(new char[1] { ',' });
			int num = array.Length;
			long[] array2 = new long[num];
			int num2 = 100;
			int num3 = num / num2;
			int num4 = num % num2;
			int num5 = 0;
			int num6 = num2;
			if (num4 != 0)
			{
				num3++;
			}
			for (int i = 0; i < num3; i++)
			{
				if (i == num3 - 1 && num4 != 0)
				{
					num6 = num4;
				}
				string[] array3 = new string[num6];
				for (int j = 0; j < num6; j++)
				{
					num5 = i * num2 + j;
					array3[j] = array[num5];
				}
				string text = "";
				for (int k = 0; k < array3.Length; k++)
				{
					text = text + array3[k] + ",";
				}
				if (text.EndsWith(","))
				{
					text = text.TrimEnd(new char[1] { ',' });
				}
				HttpClient httpClient = new HttpClient();
				string text2 = $"https://panel.asanak.com/webservice/v1rest/sendsms?username={smsSettingInfoViewModel.SmsWsUserName}&password={smsSettingInfoViewModel.SmsWsPassword}&source={fromNumber}&destination={text}&message={body}";
				httpClient.BaseAddress = new Uri(text2);
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpContent content = new StringContent(JsonConvert.SerializeObject(new SmsAsanakSendSmsViewModel
				{
					username = smsSettingInfoViewModel.SmsWsUserName,
					password = smsSettingInfoViewModel.SmsWsPassword,
					source = fromNumber,
					destination = text,
					message = body
				}), Encoding.UTF8, "application/json");
				HttpResponseMessage result2 = httpClient.PostAsync(text2, content).Result;
				if (result2.IsSuccessStatusCode)
				{
					string result3 = result2.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrEmpty(result3))
					{
						if (result3.IndexOf("[") >= 0)
						{
							result3 = result3.TrimEnd(new char[1] { ']' }).TrimStart(new char[1] { '[' });
							string[] array4 = result3.Split(new char[1] { ',' });
							if (array4 != null)
							{
								for (int l = 0; l < array4.Length; l++)
								{
									num5 = i * num2 + l;
									array2[num5] = long.Parse(array4[l]);
									NumberOfSmsSent++;
								}
							}
							else
							{
								msgError = Messages.msgErrorRunFunction;
								result = "-5000";
							}
						}
						else
						{
							SmsAsanakSendSmsResultViewModel smsAsanakSendSmsResultViewModel = JsonConvert.DeserializeObject<SmsAsanakSendSmsResultViewModel>(result3);
							if (!string.IsNullOrEmpty(smsAsanakSendSmsResultViewModel.status))
							{
								msgError = smsAsanakSendSmsResultViewModel.status;
								result = "-5000";
							}
							else
							{
								msgError = Messages.msgErrorRunFunction;
								result = "-5000";
							}
						}
					}
					else
					{
						msgError = Messages.msgErrorRunFunction;
						result = "-5000";
					}
				}
				else
				{
					msgError = Messages.msgErrorRunFunction;
					result = "-5000";
				}
			}
			if (array2 != null)
			{
				for (int m = 0; m < array2.Length; m++)
				{
					result = result + array2[m] + ",";
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
			result = "-5000";
		}
	}

	public void Asanak_GetMessageDelivery(long[] refIdArr, ref int[] result, ref string msgError, int smsProviderId = 0)
	{
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			result = new int[Enumerable.Count<long>((IEnumerable<long>)refIdArr)];
			result[0] = -7;
			if (smsSettingInfoViewModel == null)
			{
				return;
			}
			int num = refIdArr.Length;
			int[] array = new int[num];
			int num2 = 100;
			int num3 = num / num2;
			int num4 = num % num2;
			int num5 = 0;
			int num6 = num2;
			if (num4 != 0)
			{
				num3++;
			}
			for (int i = 0; i < num3; i++)
			{
				if (i == num3 - 1 && num4 != 0)
				{
					num6 = num4;
				}
				string text = "";
				for (int j = 0; j < num6; j++)
				{
					num5 = i * num2 + j;
					text += ((refIdArr[num5] != 0L) ? (refIdArr[num5] + ",") : "");
				}
				if (text.EndsWith(","))
				{
					text = text.TrimEnd(new char[1] { ',' });
				}
				HttpClient httpClient = new HttpClient();
				string text2 = $"https://panel.asanak.com/webservice/v1rest/msgstatus?username={smsSettingInfoViewModel.SmsWsUserName}&password={smsSettingInfoViewModel.SmsWsPassword}&msgid={text}";
				httpClient.BaseAddress = new Uri(text2);
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpContent content = new StringContent(JsonConvert.SerializeObject(new SmsAsanakGetDeliveryViewModel
				{
					username = smsSettingInfoViewModel.SmsWsUserName,
					password = smsSettingInfoViewModel.SmsWsPassword,
					msgid = text
				}), Encoding.UTF8, "application/json");
				HttpResponseMessage result2 = httpClient.PostAsync(text2, content).Result;
				if (!result2.IsSuccessStatusCode)
				{
					continue;
				}
				List<SmsAsanakGetDeliveryResultViewModel> list = JsonConvert.DeserializeObject<List<SmsAsanakGetDeliveryResultViewModel>>(result2.Content.ReadAsStringAsync().Result);
				if (list == null)
				{
					continue;
				}
				for (int k = 0; k < Enumerable.Count<SmsAsanakGetDeliveryResultViewModel>((IEnumerable<SmsAsanakGetDeliveryResultViewModel>)list); k++)
				{
					if (list[k].MsgID != null)
					{
						num5 = i * num2 + k;
						int result3 = 0;
						int.TryParse(list[k].Status, out result3);
						array[num5] = result3;
					}
				}
			}
			if (array == null)
			{
				return;
			}
			for (int l = 0; l < array.Length; l++)
			{
				if (array[l] == 6)
				{
					result[l] = 2;
				}
				else
				{
					result[l] = array[l];
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
		}
	}

	public void Asanak_GetCredit(ref decimal credit, ref string msgError, int smsProviderId = 0)
	{
		credit = default(decimal);
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			HttpClient httpClient = new HttpClient();
			string text = $"https://panel.asanak.com/webservice/v1rest/getcredit?username={smsSettingInfoViewModel.SmsWsUserName}&password={smsSettingInfoViewModel.SmsWsPassword}";
			httpClient.BaseAddress = new Uri(text);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			HttpContent content = new StringContent(JsonConvert.SerializeObject(new SmsAsanakSendSmsViewModel
			{
				username = smsSettingInfoViewModel.SmsWsUserName,
				password = smsSettingInfoViewModel.SmsWsPassword
			}), Encoding.UTF8, "application/json");
			HttpResponseMessage result = httpClient.PostAsync(text, content).Result;
			if (result.IsSuccessStatusCode)
			{
				string result2 = result.Content.ReadAsStringAsync().Result;
				if (!string.IsNullOrEmpty(result2))
				{
					if (result2.IndexOf("status") < 0)
					{
						credit = decimal.Parse(result2);
						return;
					}
					SmsAsanakSendSmsResultViewModel smsAsanakSendSmsResultViewModel = JsonConvert.DeserializeObject<SmsAsanakSendSmsResultViewModel>(result2);
					if (!string.IsNullOrEmpty(smsAsanakSendSmsResultViewModel.status))
					{
						msgError = smsAsanakSendSmsResultViewModel.status;
						credit = default(decimal);
					}
					else
					{
						msgError = Messages.msgErrorRunFunction;
						credit = default(decimal);
					}
				}
				else
				{
					msgError = Messages.msgErrorRunFunction;
					credit = default(decimal);
				}
			}
			else
			{
				msgError = Messages.msgErrorRunFunction;
				credit = default(decimal);
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
			credit = default(decimal);
		}
	}

	public void PayamResan_SendSms_Single(string[] lstMobile, string body, int cmessage, string fromNumber, ref string msgError, ref long[] result, bool smsIsSendByOtherAccount = false, string smsWebServiceUserName = "", string smsWebServicePassword = "", int smsProviderId = 0)
	{
		SmsV2 smsV = new SmsV2();
		result = new long[1];
		result[0] = -7L;
		msgError = "";
		cmessage = ((cmessage != 3) ? cmessage : 0);
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			_ = smsSettingInfoViewModel.SmsWsUserName;
			_ = smsSettingInfoViewModel.SmsWsPassword;
			if (smsIsSendByOtherAccount && !string.IsNullOrWhiteSpace(smsWebServiceUserName))
			{
				string.IsNullOrWhiteSpace(smsWebServicePassword);
			}
			result = smsV.SendMessage(smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, body, lstMobile, fromNumber, cmessage, 0);
			if (result[0] <= 0)
			{
				msgError = PayamResan_GetError(result[0]);
				result[0] = -5000L;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
			result[0] = -5000L;
		}
	}

	public void PayamResan_SendSms_Group(string numbers, string body, int cmessage, string fromNumber, ref string msgError, ref string result, ref int NumberOfSmsSent, int smsProviderId = 0)
	{
		SmsV2 smsV = new SmsV2();
		result = "0";
		msgError = "";
		cmessage = ((cmessage != 3) ? cmessage : 0);
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			string[] array = numbers.Split(new char[1] { ',' });
			int num = array.Length;
			long[] array2 = new long[num];
			int num2 = 99;
			int num3 = num / num2;
			int num4 = num % num2;
			int num5 = 0;
			int num6 = num2;
			if (num4 != 0)
			{
				num3++;
			}
			for (int i = 0; i < num3; i++)
			{
				if (i == num3 - 1 && num4 != 0)
				{
					num6 = num4;
				}
				string[] array3 = new string[num6];
				for (int j = 0; j < num6; j++)
				{
					num5 = i * num2 + j;
					array3[j] = array[num5];
				}
				long[] array4 = null;
				array4 = smsV.SendMessage(smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, body, array3, fromNumber, cmessage, 0);
				if (array4[0] <= 0)
				{
					msgError = PayamResan_GetError(array4[0]);
					array4[0] = -5000L;
					result = "-5000";
					continue;
				}
				for (int k = 0; k < array4.Length; k++)
				{
					num5 = i * num2 + k;
					array2[num5] = array4[k];
					NumberOfSmsSent++;
				}
			}
			if (array2 != null)
			{
				for (int l = 0; l < array2.Length; l++)
				{
					result = result + array2[l] + ",";
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
			result = "-5000";
		}
	}

	public void PayamResan_SendSms_Multiple(string[] lstMobile, string[] lstBody, string[] lstFromNumber, ref string msgError, ref long[] result, ref int NumberOfSmsSent, int smsProviderId = 0)
	{
		SmsV2 smsV = new SmsV2();
		result = new long[1];
		result[0] = -7L;
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			int num = lstMobile.Length;
			long[] array = new long[num];
			int num2 = 99;
			int num3 = num / num2;
			int num4 = num % num2;
			int num5 = 0;
			int num6 = num2;
			if (num4 != 0)
			{
				num3++;
			}
			for (int i = 0; i < num3; i++)
			{
				if (i == num3 - 1 && num4 != 0)
				{
					num6 = num4;
				}
				string[] array2 = new string[num6];
				string[] array3 = new string[num6];
				int[] array4 = new int[num6];
				for (int j = 0; j < num6; j++)
				{
					num5 = i * num2 + j;
					array2[j] = lstMobile[num5];
					array3[j] = lstBody[num5];
					array4[j] = 0;
				}
				long[] array5 = null;
				array5 = smsV.SendMessageMultiple(smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, array3, array2, lstFromNumber, array4);
				if (array5[0] <= 0)
				{
					msgError = PayamResan_GetError(array5[0]);
					array5[0] = -5000L;
					continue;
				}
				for (int k = 0; k < array5.Length; k++)
				{
					num5 = i * num2 + k;
					array[num5] = array5[k];
					NumberOfSmsSent++;
				}
			}
			if (array != null)
			{
				result = new long[num];
				for (int l = 0; l < array.Length; l++)
				{
					result[l] = array[l];
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
			result[0] = -5000L;
		}
	}

	public void PayamResan_GetCredit(ref decimal credit, ref string msgError, int smsProviderId = 0)
	{
		credit = default(decimal);
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			double credit2 = new SmsV2().GetCredit(smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword);
			if (credit2 < 0.0)
			{
				msgError = PayamResan_GetError(long.Parse(credit2.ToString()));
				credit = default(decimal);
			}
			else
			{
				credit2 = credit2;
				credit = decimal.Parse(credit2.ToString());
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
			credit = default(decimal);
		}
	}

	public void PayamResan_GetMessageDelivery(long[] refIdArr, ref int[] result, ref string msgError, int smsProviderId = 0)
	{
		SmsV2 smsV = new SmsV2();
		result = new int[Enumerable.Count<long>((IEnumerable<long>)refIdArr)];
		result[0] = -7;
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			int num = refIdArr.Length;
			long[] array = new long[num];
			int num2 = 99;
			int num3 = num / num2;
			int num4 = num % num2;
			int num5 = 0;
			int num6 = num2;
			if (num4 != 0)
			{
				num3++;
			}
			for (int i = 0; i < num3; i++)
			{
				if (i == num3 - 1 && num4 != 0)
				{
					num6 = num4;
				}
				long[] array2 = new long[num6];
				for (int j = 0; j < num6; j++)
				{
					num5 = i * num2 + j;
					array2[j] = refIdArr[num5];
				}
				long[] array3 = null;
				array3 = smsV.GetMessagesStatus(smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, array2);
				if (array3[0] <= 0)
				{
					msgError = PayamResan_GetError(array3[0]);
					Exception innerException = new Exception();
					Exception e = new Exception(msgError, innerException);
					ErrorSignal.FromCurrentContext().Raise(e);
				}
				else
				{
					for (int k = 0; k < array3.Length; k++)
					{
						num5 = i * num2 + k;
						array[num5] = array3[k];
					}
				}
			}
			if (array == null)
			{
				return;
			}
			for (int l = 0; l < array.Length; l++)
			{
				result[l] = int.Parse(array[l].ToString());
				if (result[l] == 4)
				{
					result[l] = 2;
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
		}
	}

	public string PayamResan_GetError(long ErrNum)
	{
		string text = "";
		try
		{
			long num = ErrNum - -21;
			if ((ulong)num <= 20uL)
			{
				switch (num)
				{
				case 20L:
					return Messages.msgErrorPRSendSmsIncorrectUsenamePassword;
				case 19L:
					return Messages.msgErrorPRSendSmsWebServiceDisabledForUser;
				case 18L:
					return Messages.msgErrorPRSendSmsServiceTemporarilyDisabled;
				case 17L:
					return Messages.msgErrorPRSendSmsNumberIsNotOwnedUser;
				case 16L:
					return Messages.msgErrorPRSendSmsRecipientPhoneIncorrect;
				case 15L:
					return Messages.msgErrorPRSendSmsCreditNotSufficient;
				case 14L:
					return Messages.msgErrorPRSendSmsRecipientArrayEmpty;
				case 13L:
					return Messages.msgErrorPRSendSmsNumberRecipientGreater;
				case 12L:
					return Messages.msgErrorPRSendSmsWrongSenderNumber;
				case 11L:
					return Messages.msgErrorPRSednSmsMsgIdArrayEmpty;
				case 10L:
					return Messages.msgErrorPRSendSmsAccountBlocked;
				case 9L:
					return Messages.msgErrorPRSendSmsMobileNotActive;
				case 8L:
					return Messages.msgErrorPRSendSmsEmailNotActive;
				case 7L:
					return Messages.msgErrorPRSendSmsInvalidRecipientNumber;
				case 6L:
					return Messages.msgErrorPrSendSmsNumberMsgOutOfRange;
				case 5L:
					return Messages.msgErrorPRSendSmsDelayAllowed;
				case 3L:
					return Messages.msgErrorPRSendSmsWrongMsgText;
				case 2L:
					return Messages.msgErrorPRSendSmsArrayMsgEqaulArrayRecipient;
				case 1L:
					return Messages.msgErrorPRSendSmsArraySenderEqaulArrayRecipient;
				case 0L:
					return Messages.msgErrorPRSendSmsArrayDelayAllowedEqaulArrayRecipient;
				}
			}
			return Messages.msgErrorPRSendSmsInternalErr;
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			return ex.Message;
		}
	}

	public string[][] PayamResan_GetMessages(ref int errNum, ref string msgError, int smsProviderId = 0)
	{
		string[][] result = new string[100][];
		errNum = 0;
		msgError = "";
		try
		{
			SmsV2 smsV = new SmsV2();
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			result = smsV.GetAllMessages(smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, 99, "", ref errNum);
			if (errNum != 0)
			{
				msgError = PayamResan_GetError(long.Parse(errNum.ToString()));
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
		}
		return result;
	}

	public void KaveNegar_SendSms_Single(string[] lstMobile, string body, int cmessage, string fromNumber, ref string msgError, ref long[] result, bool smsIsSendByOtherAccount = false, string smsWebServiceUserName = "", string smsWebServicePassword = "", int smsProviderId = 0)
	{
		v1 v = new v1();
		result = new long[1];
		result[0] = 0L;
		msgError = "";
		cmessage = ((cmessage != 3) ? cmessage : 0);
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			int status = 0;
			string statusmessage = "";
			_ = smsSettingInfoViewModel.SmsWsUserName;
			_ = smsSettingInfoViewModel.SmsWsPassword;
			if (smsIsSendByOtherAccount && !string.IsNullOrWhiteSpace(smsWebServiceUserName))
			{
				string.IsNullOrWhiteSpace(smsWebServicePassword);
			}
			result = v.SendSimpleByLoginInfo(smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, fromNumber, body, lstMobile, 0L, cmessage, ref status, ref statusmessage);
			if (status != 200)
			{
				msgError = statusmessage;
				result[0] = -5000L;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
			result[0] = -5000L;
		}
	}

	public void KaveNegar_SendSms_Group(string numbers, string body, int cmessage, string fromNumber, ref string msgError, ref string result, ref int NumberOfSmsSent, int smsProviderId = 0)
	{
		v1 v = new v1();
		result = "0";
		msgError = "";
		cmessage = ((cmessage != 3) ? cmessage : 0);
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			string[] array = numbers.Split(new char[1] { ',' });
			int num = array.Length;
			long[] array2 = new long[num];
			int num2 = 200;
			int num3 = num / num2;
			int num4 = num % num2;
			int num5 = 0;
			int num6 = num2;
			if (num4 != 0)
			{
				num3++;
			}
			for (int i = 0; i < num3; i++)
			{
				if (i == num3 - 1 && num4 != 0)
				{
					num6 = num4;
				}
				string[] array3 = new string[num6];
				for (int j = 0; j < num6; j++)
				{
					num5 = i * num2 + j;
					array3[j] = array[num5];
				}
				int status = 0;
				string statusmessage = "";
				long[] array4 = null;
				array4 = v.SendSimpleByLoginInfo(smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, fromNumber, body, array3, 0L, cmessage, ref status, ref statusmessage);
				if (status != 200)
				{
					msgError = statusmessage;
					continue;
				}
				for (int k = 0; k < array4.Length; k++)
				{
					num5 = i * num2 + k;
					array2[num5] = array4[k];
					NumberOfSmsSent++;
				}
			}
			if (array2 != null)
			{
				for (int l = 0; l < array2.Length; l++)
				{
					result = result + array2[l] + ",";
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
			result = "0";
		}
	}

	public void KaveNegar_SendSms_Array(string[] lstMobile, string[] lstBody, int cmessage, string[] lstFromNumber, ref string msgError, ref long[] result, ref int NumberOfSmsSent, int smsProviderId = 0)
	{
		v1 v = new v1();
		result = new long[1];
		result[0] = 0L;
		msgError = "";
		cmessage = ((cmessage != 3) ? cmessage : 0);
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			int num = lstMobile.Length;
			long[] array = new long[num];
			int num2 = 200;
			int num3 = num / num2;
			int num4 = num % num2;
			int num5 = 0;
			int num6 = num2;
			if (num4 != 0)
			{
				num3++;
			}
			for (int i = 0; i < num3; i++)
			{
				if (i == num3 - 1 && num4 != 0)
				{
					num6 = num4;
				}
				string[] array2 = new string[num6];
				string[] array3 = new string[num6];
				int[] array4 = new int[num6];
				for (int j = 0; j < num6; j++)
				{
					num5 = i * num2 + j;
					array2[j] = lstMobile[num5];
					array3[j] = lstBody[num5];
					array4[j] = cmessage;
				}
				long[] array5 = null;
				int status = 0;
				string statusmessage = "";
				array5 = v.SendArrayByLoginInfo(smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, lstFromNumber, array3, array2, 0L, array4, ref status, ref statusmessage);
				if (status != 200)
				{
					msgError = statusmessage;
					continue;
				}
				for (int k = 0; k < array5.Length; k++)
				{
					num5 = i * num2 + k;
					array[num5] = array5[k];
					NumberOfSmsSent++;
				}
			}
			if (array != null)
			{
				result = new long[num];
				for (int l = 0; l < array.Length; l++)
				{
					result[l] = array[l];
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
			result[0] = 0L;
		}
	}

	public void KaveNegar_GetCredit(ref decimal credit, ref string msgError, int smsProviderId = 0)
	{
		credit = default(decimal);
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			v1 v = new v1();
			int status = 0;
			string statusmessage = "";
			long num = v.RemainCreditByLoginInfo(smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, ref status, ref statusmessage);
			num = num;
			if (status != 200)
			{
				msgError = statusmessage;
				Exception innerException = new Exception();
				Exception e = new Exception(msgError, innerException);
				ErrorSignal.FromCurrentContext().Raise(e);
				num = 0L;
			}
			credit = decimal.Parse(num.ToString());
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
		}
	}

	public void KaveNegar_GetMessageDelivery(long[] refIdArr, ref int[] result, ref string msgError, int smsProviderId = 0)
	{
		v1 v = new v1();
		result = new int[Enumerable.Count<long>((IEnumerable<long>)refIdArr)];
		result[0] = -7;
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			int num = refIdArr.Length;
			int[] array = new int[num];
			int num2 = 200;
			int num3 = num / num2;
			int num4 = num % num2;
			int num5 = 0;
			int num6 = num2;
			if (num4 != 0)
			{
				num3++;
			}
			for (int i = 0; i < num3; i++)
			{
				if (i == num3 - 1 && num4 != 0)
				{
					num6 = num4;
				}
				long[] array2 = new long[num6];
				for (int j = 0; j < num6; j++)
				{
					num5 = i * num2 + j;
					array2[j] = refIdArr[num5];
				}
				int[] array3 = null;
				int status = 0;
				string statusmessage = "";
				array3 = v.GetStatusByLoginInfo(smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, array2, ref status, ref statusmessage);
				if (status != 200)
				{
					msgError = statusmessage;
					Exception innerException = new Exception();
					Exception e = new Exception(msgError, innerException);
					ErrorSignal.FromCurrentContext().Raise(e);
				}
				else
				{
					for (int k = 0; k < array3.Length; k++)
					{
						num5 = i * num2 + k;
						array[num5] = array3[k];
					}
				}
			}
			if (array == null)
			{
				return;
			}
			for (int l = 0; l < array.Length; l++)
			{
				result[l] = array[l];
				if (result[l] == 10)
				{
					result[l] = 2;
				}
				else if (result[l] == 14)
				{
					result[l] = 4;
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
		}
	}

	public ApiReceive[] KaveNegar_GetMessages(ref int status_code, ref string status_message, int smsProviderId = 0)
	{
		ApiReceive[] result = null;
		try
		{
			v1 v = new v1();
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			status_code = 0;
			status_message = "";
			result = v.ReceiveByLoginInfo(smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, smsSettingInfoViewModel.SmsWsFromNumber, 0, ref status_code, ref status_message);
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			status_message = ex.Message;
		}
		return result;
	}

	public void TehranPayamak_SendSms1To1(string[] lstMobile, string body, int cmessage, string fromNumber, ref string msgError, ref long[] result, bool smsIsSendByOtherAccount = false, string smsWebServiceUserName = "", string smsWebServicePassword = "", int smsProviderId = 0)
	{
		Mobile.SmsTehranPayamak.SMSwsdlPortTypeClient sMSwsdlPortTypeClient = new Mobile.SmsTehranPayamak.SMSwsdlPortTypeClient();
		result = new long[1];
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			string text = "";
			for (int i = 0; i < Enumerable.Count<string>((IEnumerable<string>)lstMobile); i++)
			{
				text = text + lstMobile[i] + ";";
			}
			cmessage = ((cmessage == 3) ? 2 : cmessage);
			_ = smsSettingInfoViewModel.SmsWsUserName;
			_ = smsSettingInfoViewModel.SmsWsPassword;
			if (smsIsSendByOtherAccount && !string.IsNullOrWhiteSpace(smsWebServiceUserName))
			{
				string.IsNullOrWhiteSpace(smsWebServicePassword);
			}
			string s = sMSwsdlPortTypeClient.sendSMS(smsSettingInfoViewModel.SmsWsDomainNamed, smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, fromNumber, text, body, cmessage);
			long result2 = 0L;
			long.TryParse(s, out result2);
			if (result2 <= 0)
			{
				long num = result2 - -6;
				if ((ulong)num <= 5uL)
				{
					switch (num)
					{
					case 5L:
						msgError = Messages.msgErrorTPSendSmsError;
						break;
					case 4L:
						msgError = Messages.msgErrorTPSendSmsIncorrectUsenamePassword;
						break;
					case 3L:
						msgError = Messages.msgErrorTPSendSmsSenderNumberNotValid;
						break;
					case 2L:
						msgError = Messages.msgErrorTPSendSmsCreditNotEnough;
						break;
					case 1L:
						msgError = Messages.msgErrorTPSendSmsMsgSentAfterConfirm;
						break;
					case 0L:
						msgError = Messages.msgErrorTPSendSmsRecipientNumInCorrect;
						break;
					}
				}
				result[0] = -5000L;
			}
			else
			{
				result[0] = result2;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result[0] = -5000L;
			msgError = ex.Message;
		}
	}

	public void TehranPayamak_SendSms(string numbers, string body, int cmessage, string fromNumber, ref string msgError, ref string result, int smsProviderId = 0)
	{
		result = "0";
		try
		{
			Mobile.SmsTehranPayamak.SMSwsdlPortTypeClient sMSwsdlPortTypeClient = new Mobile.SmsTehranPayamak.SMSwsdlPortTypeClient();
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			string text = numbers.Replace(',', ';');
			if (!text.EndsWith(";"))
			{
				text += ";";
			}
			cmessage = ((cmessage == 3) ? 2 : cmessage);
			string s = sMSwsdlPortTypeClient.sendSMS(smsSettingInfoViewModel.SmsWsDomainNamed, smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, fromNumber, text, body, cmessage);
			long result2 = 0L;
			long.TryParse(s, out result2);
			if (result2 <= 0)
			{
				long num = result2 - -6;
				if ((ulong)num <= 5uL)
				{
					switch (num)
					{
					case 5L:
						msgError = Messages.msgErrorTPSendSmsError;
						break;
					case 4L:
						msgError = Messages.msgErrorTPSendSmsIncorrectUsenamePassword;
						break;
					case 3L:
						msgError = Messages.msgErrorTPSendSmsSenderNumberNotValid;
						break;
					case 2L:
						msgError = Messages.msgErrorTPSendSmsCreditNotEnough;
						break;
					case 1L:
						msgError = Messages.msgErrorTPSendSmsMsgSentAfterConfirm;
						break;
					case 0L:
						msgError = Messages.msgErrorTPSendSmsRecipientNumInCorrect;
						break;
					}
				}
				result = "-5000";
			}
			else
			{
				result = result2.ToString();
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = "-5000";
			msgError = ex.Message;
		}
	}

	public void TehranPayamak_sendMultiSMS(string[] lstMobile, string[] lstBody, int cmessage, string fromNumber, ref string msgError, ref long[] result, int smsProviderId = 0)
	{
		Mobile.SmsTehranPayamak.SMSwsdlPortTypeClient sMSwsdlPortTypeClient = new Mobile.SmsTehranPayamak.SMSwsdlPortTypeClient();
		result = new long[1];
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			string text = "";
			for (int i = 0; i < Enumerable.Count<string>((IEnumerable<string>)lstMobile); i++)
			{
				text = text + lstMobile[i] + ";";
			}
			if (!text.EndsWith(";"))
			{
				text += ";";
			}
			cmessage = ((cmessage == 3) ? 2 : cmessage);
			string text2 = "";
			for (int j = 0; j < Enumerable.Count<string>((IEnumerable<string>)lstBody); j++)
			{
				text2 = text2 + lstBody[j] + ";";
			}
			if (!text2.EndsWith(";"))
			{
				text2 += ";";
			}
			string s = sMSwsdlPortTypeClient.sendMultiSMS(smsSettingInfoViewModel.SmsWsDomainNamed, smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, fromNumber, text, text2, cmessage);
			long result2 = 0L;
			long.TryParse(s, out result2);
			if (result2 <= 0)
			{
				long num = result2 - -5;
				if ((ulong)num <= 4uL)
				{
					switch (num)
					{
					case 4L:
						msgError = Messages.msgErrorTPSendSmsError;
						break;
					case 3L:
						msgError = Messages.msgErrorTPSendSmsIncorrectUsenamePassword;
						break;
					case 2L:
						msgError = Messages.msgErrorTPSendSmsSenderNumberNotValid;
						break;
					case 1L:
						msgError = Messages.msgErrorTPSendSmsCreditNotEnough;
						break;
					case 0L:
						msgError = Messages.msgErrorTPSendSmsMsgSentAfterConfirm;
						break;
					}
				}
				result[0] = -5000L;
			}
			else
			{
				result[0] = result2;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result[0] = -5000L;
			msgError = ex.Message;
		}
	}

	public void TehranPayamak_GetDelivery(int sendType, long[] refIdArr, ref int[] result, ref string msgError, int smsProviderId = 0)
	{
		try
		{
			Mobile.SmsTehranPayamak.SMSwsdlPortTypeClient sMSwsdlPortTypeClient = new Mobile.SmsTehranPayamak.SMSwsdlPortTypeClient();
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			result = new int[Enumerable.Count<long>((IEnumerable<long>)refIdArr)];
			result[0] = -7;
			if (smsSettingInfoViewModel == null)
			{
				return;
			}
			if (sendType == 1 || sendType == 2)
			{
				for (int i = 0; i < Enumerable.Count<long>((IEnumerable<long>)refIdArr); i++)
				{
					Mobile.SmsTehranPayamak.delivery[] delivery = sMSwsdlPortTypeClient.getDelivery(smsSettingInfoViewModel.SmsWsDomainNamed, smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, (int)refIdArr[i]);
					if (delivery == null)
					{
						continue;
					}
					if (Enumerable.Count<Mobile.SmsTehranPayamak.delivery>((IEnumerable<Mobile.SmsTehranPayamak.delivery>)delivery) > 1)
					{
						Mobile.SmsTehranPayamak.delivery[] array = delivery;
						foreach (Mobile.SmsTehranPayamak.delivery delivery2 in array)
						{
							if (delivery2.status == 1)
							{
								result[i] = 2;
							}
							else if (delivery2.status == 2)
							{
								result[i] = 1;
							}
							else if (delivery2.status == 4)
							{
								result[i] = 3;
							}
							else if (delivery2.status == 46)
							{
								result[i] = 4;
							}
							else
							{
								result[i] = delivery2.status;
							}
						}
					}
					else if (Enumerable.Count<Mobile.SmsTehranPayamak.delivery>((IEnumerable<Mobile.SmsTehranPayamak.delivery>)delivery) == 1)
					{
						if (delivery[0].status == 1)
						{
							result[i] = 2;
						}
						else if (delivery[0].status == 2)
						{
							result[i] = 1;
						}
						else if (delivery[0].status == 4)
						{
							result[i] = 3;
						}
						else if (delivery[0].status == 46)
						{
							result[i] = 4;
						}
						else
						{
							result[i] = delivery[0].status;
						}
					}
				}
				return;
			}
			for (int k = 0; k < Enumerable.Count<long>((IEnumerable<long>)refIdArr); k++)
			{
				Mobile.SmsTehranPayamak.delivery[] deliveryMulti = sMSwsdlPortTypeClient.getDeliveryMulti(smsSettingInfoViewModel.SmsWsDomainNamed, smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, (int)refIdArr[k]);
				if (deliveryMulti == null)
				{
					continue;
				}
				if (Enumerable.Count<Mobile.SmsTehranPayamak.delivery>((IEnumerable<Mobile.SmsTehranPayamak.delivery>)deliveryMulti) > 1)
				{
					Mobile.SmsTehranPayamak.delivery[] array = deliveryMulti;
					foreach (Mobile.SmsTehranPayamak.delivery delivery3 in array)
					{
						if (delivery3.status == 1)
						{
							result[k] = 2;
						}
						else if (delivery3.status == 2)
						{
							result[k] = 1;
						}
						else if (delivery3.status == 4)
						{
							result[k] = 3;
						}
						else if (delivery3.status == 46)
						{
							result[k] = 4;
						}
						else
						{
							result[k] = delivery3.status;
						}
					}
				}
				else if (Enumerable.Count<Mobile.SmsTehranPayamak.delivery>((IEnumerable<Mobile.SmsTehranPayamak.delivery>)deliveryMulti) == 1)
				{
					if (deliveryMulti[0].status == 1)
					{
						result[k] = 2;
					}
					else if (deliveryMulti[0].status == 2)
					{
						result[k] = 1;
					}
					else if (deliveryMulti[0].status == 4)
					{
						result[k] = 3;
					}
					else if (deliveryMulti[0].status == 46)
					{
						result[k] = 4;
					}
					else
					{
						result[k] = deliveryMulti[0].status;
					}
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
		}
	}

	public Mobile.SmsTehranPayamak.message[] TehranPayamak_ReceiveSms(int smsProviderId = 0)
	{
		Mobile.SmsTehranPayamak.message[] result = null;
		try
		{
			Mobile.SmsTehranPayamak.SMSwsdlPortTypeClient sMSwsdlPortTypeClient = new Mobile.SmsTehranPayamak.SMSwsdlPortTypeClient();
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			result = sMSwsdlPortTypeClient.getMessages(count: sMSwsdlPortTypeClient.getMessagesCount(smsSettingInfoViewModel.SmsWsDomainNamed, smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, "2", "", ""), domain: smsSettingInfoViewModel.SmsWsDomainNamed, username: smsSettingInfoViewModel.SmsWsUserName, password: smsSettingInfoViewModel.SmsWsPassword, smsType: "2", start: "", from: "");
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public void TehranPayamak_GetUserInfo(ref decimal credit, ref string msgError, int smsProviderId = 0)
	{
		credit = default(decimal);
		msgError = "";
		try
		{
			Mobile.SmsTehranPayamak.SMSwsdlPortTypeClient sMSwsdlPortTypeClient = new Mobile.SmsTehranPayamak.SMSwsdlPortTypeClient();
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			int price = 0;
			string s = sMSwsdlPortTypeClient.getCreditPrice(amount: sMSwsdlPortTypeClient.getCredit(smsSettingInfoViewModel.SmsWsDomainNamed, smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword), domain: smsSettingInfoViewModel.SmsWsDomainNamed, username: smsSettingInfoViewModel.SmsWsUserName, password: smsSettingInfoViewModel.SmsWsPassword, price: out price);
			int result = 0;
			int.TryParse(s, out result);
			if (result < 0)
			{
				msgError = Messages.ErrorInformation;
				credit = default(decimal);
			}
			else
			{
				credit = decimal.Parse(price.ToString());
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
			credit = default(decimal);
		}
	}

	public void SmsFor_SendSms1To1(string[] lstMobile, string[] body, int cmessage, string fromNumber, ref string msgError, ref long[] result, bool smsIsSendByOtherAccount = false, string smsWebServiceUserName = "", string smsWebServicePassword = "", int smsProviderId = 0)
	{
		SmsPanelWebservice smsPanelWebservice = new SmsPanelWebservice();
		result = new long[1];
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			string text = ((cmessage == 3) ? "1" : "0");
			string[] request_uniqueid = new string[lstMobile.Length];
			string username = smsSettingInfoViewModel.SmsWsUserName;
			string password = smsSettingInfoViewModel.SmsWsPassword;
			if (smsIsSendByOtherAccount && !string.IsNullOrWhiteSpace(smsWebServiceUserName) && !string.IsNullOrWhiteSpace(smsWebServicePassword))
			{
				username = smsWebServiceUserName;
				password = smsWebServicePassword;
			}
			string[] array = smsPanelWebservice.send_sms(username, password, new string[1] { fromNumber }, lstMobile, body, new string[1] { DateTime.Now.ToString() }, request_uniqueid, new string[1] { text }, "ok");
			if (array != null)
			{
				if (Enumerable.Any<string>((IEnumerable<string>)array))
				{
					if (array[0].IndexOf("error") >= 0)
					{
						result[0] = -5000L;
						msgError = array[0];
						return;
					}
					string[] array2 = array[0].Split(new char[1] { ',' });
					if (Enumerable.Any<string>((IEnumerable<string>)array2))
					{
						result = new long[array2.Length];
						for (int i = 0; i < Enumerable.Count<string>((IEnumerable<string>)array2); i++)
						{
							long result2 = 0L;
							long.TryParse(array2[i], out result2);
							result[i] = result2;
						}
					}
					else
					{
						result[0] = -5000L;
					}
				}
				else
				{
					result[0] = -5000L;
				}
			}
			else
			{
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

	public void SmsFor_SendSms(string numbers, string body, int cmessage, string fromNumber, ref string msgError, ref string result, int smsProviderId = 0)
	{
		result = "0";
		try
		{
			SmsPanelWebservice smsPanelWebservice = new SmsPanelWebservice();
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			string[] array = numbers.Split(new char[1] { ',' });
			string text = ((cmessage == 3) ? "1" : "0");
			string[] request_uniqueid = new string[array.Length];
			string[] array2 = smsPanelWebservice.send_sms(smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, new string[1] { fromNumber }, array, new string[1] { body }, new string[1] { DateTime.Now.ToString() }, request_uniqueid, new string[1] { text }, "ok");
			if (array2 != null)
			{
				if (Enumerable.Any<string>((IEnumerable<string>)array2))
				{
					if (array2[0].IndexOf("error") >= 0)
					{
						result = "-5000";
						msgError = array2[0];
					}
					else
					{
						result = array2[0];
					}
				}
				else
				{
					result = "-5000";
				}
			}
			else
			{
				result = "-5000";
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = "-5000";
			msgError = ex.Message;
		}
	}

	public void SmsFor_GetDelivery(long[] refIdArr, ref int[] result, ref string msgError, int smsProviderId = 0)
	{
		try
		{
			SmsPanelWebservice smsPanelWebservice = new SmsPanelWebservice();
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			result = new int[Enumerable.Count<long>((IEnumerable<long>)refIdArr)];
			result[0] = -7;
			if (smsSettingInfoViewModel == null)
			{
				return;
			}
			string[] array = new string[Enumerable.Count<long>((IEnumerable<long>)refIdArr)];
			for (int i = 0; i < Enumerable.Count<long>((IEnumerable<long>)refIdArr); i++)
			{
				array[i] = refIdArr[i].ToString();
			}
			string s = "3000";
			if (!string.IsNullOrEmpty(smsSettingInfoViewModel.SmsWsFromNumber))
			{
				s = ((!(smsSettingInfoViewModel.SmsWsFromNumber.Substring(0, 1) != "5")) ? smsSettingInfoViewModel.SmsWsFromNumber.Substring(0, 5) : smsSettingInfoViewModel.SmsWsFromNumber.Substring(0, 4));
			}
			int dargah = int.Parse(s);
			long[] array2 = smsPanelWebservice.sms_deliver(array, dargah);
			if (array2 == null)
			{
				return;
			}
			for (int j = 0; j < Enumerable.Count<long>((IEnumerable<long>)refIdArr); j++)
			{
				if (array2[j] == 1)
				{
					result[j] = 2;
				}
				else if (array2[j] == 2)
				{
					result[j] = 3;
				}
				else if (array2[j] == 4 || array2[j] == 8)
				{
					result[j] = 1;
				}
				else if (array2[j] == 5)
				{
					result[j] = 4;
				}
				else
				{
					result[j] = (int)array2[j];
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
		}
	}

	public array_receive[] SmsFor_ReceiveSms(int smsProviderId = 0)
	{
		array_receive[] result = null;
		try
		{
			SmsPanelWebservice smsPanelWebservice = new SmsPanelWebservice();
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			result = smsPanelWebservice.sms_receive(smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, smsSettingInfoViewModel.SmsWsFromNumber, 0, 1, 10000, -1, null);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public void SmsFor_GetCredit(ref decimal credit, ref string msgError, int smsProviderId = 0)
	{
		credit = default(decimal);
		msgError = "";
		try
		{
			SmsPanelWebservice smsPanelWebservice = new SmsPanelWebservice();
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			int num = smsPanelWebservice.sms_credit(smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword);
			if (num < 0)
			{
				msgError = Messages.ErrorInformation;
				credit = default(decimal);
			}
			else
			{
				credit = decimal.Parse(num.ToString());
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
			credit = default(decimal);
		}
	}

	public void SmsAfzar_SendSms1To1(string[] lstMobile, string[] body, int cmessage, string[] fromNumber, ref string msgError, ref long[] result, bool smsIsSendByOtherAccount = false, string smsWebServiceUserName = "", string smsWebServicePassword = "", int smsProviderId = 0)
	{
		smsWebService smsWebService = new smsWebService();
		result = new long[1];
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			cmessage = ((cmessage != 3) ? cmessage : 0);
			int num = lstMobile.Length;
			long[] array = new long[num];
			int num2 = 90;
			int num3 = num / num2;
			int num4 = num % num2;
			int num5 = 0;
			int num6 = num2;
			if (num4 != 0)
			{
				num3++;
			}
			for (int i = 0; i < num3; i++)
			{
				if (i == num3 - 1 && num4 != 0)
				{
					num6 = num4;
				}
				string[] array2 = new string[num6];
				for (int j = 0; j < num6; j++)
				{
					num5 = i * num2 + j;
					array2[j] = lstMobile[num5];
				}
				int[] array3 = new int[array2.Length];
				for (int k = 0; k < array3.Length; k++)
				{
					array3[k] = cmessage;
				}
				_ = new string[array2.Length];
				int[] array4 = new int[array2.Length];
				for (int l = 0; l < array4.Length; l++)
				{
					array4[l] = 1;
				}
				string[] array5 = new string[array2.Length];
				for (int m = 0; m < array5.Length; m++)
				{
					array5[m] = "";
				}
				int[] array6 = new int[array2.Length];
				for (int n = 0; n < array6.Length; n++)
				{
					array6[n] = -1;
				}
				int num7 = 0;
				long[] array7 = null;
				string username = smsSettingInfoViewModel.SmsWsUserName;
				string password = smsSettingInfoViewModel.SmsWsPassword;
				if (smsIsSendByOtherAccount && !string.IsNullOrWhiteSpace(smsWebServiceUserName) && !string.IsNullOrWhiteSpace(smsWebServicePassword))
				{
					username = smsWebServiceUserName;
					password = smsWebServicePassword;
				}
				array7 = smsWebService.sendSMSEnquee(username, password, smsSettingInfoViewModel.SmsWsDomainNamed, body, array2, fromNumber, array4, array5, array3, array6);
				if (array7 == null)
				{
					array[0] = -5000L;
					continue;
				}
				if (array7[0] <= 0)
				{
					array[0] = -5000L;
					continue;
				}
				for (int num8 = 0; num8 < array7.Length; num8++)
				{
					num5 = i * num2 + num8;
					array[num5] = array7[num8];
					num7++;
				}
			}
			if (array != null)
			{
				result = new long[num];
				result = array;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result[0] = -5000L;
			msgError = ex.Message;
		}
	}

	public void SmsAfzar_SendSms(string numbers, string body, int cmessage, string fromNumber, ref string msgError, ref string result, int smsProviderId = 0)
	{
		result = "0";
		try
		{
			smsWebService smsWebService = new smsWebService();
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			string[] array = numbers.Split(new char[1] { ',' });
			cmessage = ((cmessage != 3) ? cmessage : 0);
			int num = array.Length;
			long[] array2 = new long[num];
			int num2 = 90;
			int num3 = num / num2;
			int num4 = num % num2;
			int num5 = 0;
			int num6 = num2;
			if (num4 != 0)
			{
				num3++;
			}
			for (int i = 0; i < num3; i++)
			{
				if (i == num3 - 1 && num4 != 0)
				{
					num6 = num4;
				}
				string[] array3 = new string[num6];
				for (int j = 0; j < num6; j++)
				{
					num5 = i * num2 + j;
					array3[j] = array[num5];
				}
				int[] array4 = new int[array3.Length];
				for (int k = 0; k < array4.Length; k++)
				{
					array4[k] = cmessage;
				}
				_ = new string[array3.Length];
				int[] array5 = new int[array3.Length];
				for (int l = 0; l < array5.Length; l++)
				{
					array5[l] = 1;
				}
				string[] array6 = new string[array3.Length];
				for (int m = 0; m < array6.Length; m++)
				{
					array6[m] = "";
				}
				int[] array7 = new int[array3.Length];
				for (int n = 0; n < array7.Length; n++)
				{
					array7[n] = -1;
				}
				string[] array8 = new string[array3.Length];
				for (int num7 = 0; num7 < array8.Length; num7++)
				{
					array8[num7] = body;
				}
				string[] array9 = new string[array3.Length];
				for (int num8 = 0; num8 < array9.Length; num8++)
				{
					array9[num8] = fromNumber;
				}
				int num9 = 0;
				long[] array10 = null;
				array10 = smsWebService.sendSMSEnquee(smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, smsSettingInfoViewModel.SmsWsDomainNamed, array8, array3, array9, array5, array6, array4, array7);
				if (array10 == null)
				{
					array2[0] = -5000L;
					continue;
				}
				if (array10[0] <= 0)
				{
					array2[0] = -5000L;
					continue;
				}
				for (int num10 = 0; num10 < array10.Length; num10++)
				{
					num5 = i * num2 + num10;
					array2[num5] = array10[num10];
					num9++;
				}
			}
			if (array2 == null || array2[0] < 0)
			{
				result = "-5000";
				return;
			}
			for (int num11 = 0; num11 < array2.Length; num11++)
			{
				result = result + array2[num11] + ",";
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = "-5000";
			msgError = ex.Message;
		}
	}

	public void SmsAfzar_GetDelivery(long[] refIdArr, ref int[] result, ref string msgError, int smsProviderId = 0)
	{
		try
		{
			smsWebService smsWebService = new smsWebService();
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			result = new int[Enumerable.Count<long>((IEnumerable<long>)refIdArr)];
			result[0] = -7;
			if (smsSettingInfoViewModel == null)
			{
				return;
			}
			int[] messageStatuses = smsWebService.getMessageStatuses(smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, smsSettingInfoViewModel.SmsWsDomainNamed, refIdArr);
			if (messageStatuses == null)
			{
				return;
			}
			for (int i = 0; i < Enumerable.Count<long>((IEnumerable<long>)refIdArr); i++)
			{
				if (messageStatuses[i] == 1)
				{
					result[i] = 2;
				}
				else if (messageStatuses[i] == 2)
				{
					result[i] = 3;
				}
				else if (messageStatuses[i] == 8)
				{
					result[i] = 1;
				}
				else
				{
					result[i] = messageStatuses[i];
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
		}
	}

	public void SmsAfzar_GetCredit(ref decimal credit, ref string msgError, int smsProviderId = 0)
	{
		credit = default(decimal);
		msgError = "";
		try
		{
			smsWebService smsWebService = new smsWebService();
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			decimal credit2 = smsWebService.getCredit(smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, smsSettingInfoViewModel.SmsWsDomainNamed);
			if (credit2 < 0m)
			{
				msgError = Messages.ErrorInformation;
				credit = default(decimal);
			}
			else
			{
				credit = decimal.Parse(credit2.ToString());
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
			credit = default(decimal);
		}
	}

	public reciveInfo[] SmsAfzar_ReceiveSms(int smsProviderId = 0)
	{
		reciveInfo[] result = null;
		try
		{
			smsWebService smsWebService = new smsWebService();
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			result = smsWebService.getAllReciveSMSWithNumber(smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, smsSettingInfoViewModel.SmsWsDomainNamed, smsSettingInfoViewModel.SmsWsFromNumber);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public void SmsIr_SendSms1To1(string[] lstMobile, string[] body, int cmessage, string fromNumber, ref string msgError, ref long[] result, bool smsIsSendByOtherAccount = false, string smsWebServiceUserName = "", string smsWebServicePassword = "", int smsProviderId = 0)
	{
		result = new long[1];
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			_ = smsSettingInfoViewModel.SmsWsUserName;
			string value = smsSettingInfoViewModel.SmsWsPassword;
			if (smsIsSendByOtherAccount && !string.IsNullOrWhiteSpace(smsWebServiceUserName) && !string.IsNullOrWhiteSpace(smsWebServicePassword))
			{
				value = smsWebServicePassword;
			}
			int num = lstMobile.Length;
			long[] array = new long[num];
			int num2 = 100;
			int num3 = num / num2;
			int num4 = num % num2;
			int num5 = 0;
			int num6 = num2;
			if (num4 != 0)
			{
				num3++;
			}
			for (int i = 0; i < num3; i++)
			{
				if (i == num3 - 1 && num4 != 0)
				{
					num6 = num4;
				}
				string[] array2 = new string[num6];
				for (int j = 0; j < num6; j++)
				{
					num5 = i * num2 + j;
					array2[j] = lstMobile[num5];
				}
				string[] array3 = new string[array2.Length];
				for (int k = 0; k < num6; k++)
				{
					num5 = i * num2 + k;
					array3[k] = body[num5];
				}
				int num7 = 0;
				long result2 = 0L;
				long.TryParse(fromNumber, out result2);
				SMSIrlikeToLikeViewModel value2 = new SMSIrlikeToLikeViewModel
				{
					messageTexts = array3,
					mobiles = array2,
					lineNumber = result2,
					senddatetime = null
				};
				HttpClient httpClient = new HttpClient();
				string text = "https://api.sms.ir/v1/send/likeToLike";
				httpClient.BaseAddress = new Uri(text);
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				httpClient.DefaultRequestHeaders.Add("X-API-KEY", value);
				HttpContent content = new StringContent(JsonConvert.SerializeObject(value2), Encoding.UTF8, "application/json");
				HttpResponseMessage result3 = httpClient.PostAsync(text, content).Result;
				if (result3.IsSuccessStatusCode)
				{
					SMSIrlikeToLikeResponseViewModel sMSIrlikeToLikeResponseViewModel = JsonConvert.DeserializeObject<SMSIrlikeToLikeResponseViewModel>(result3.Content.ReadAsStringAsync().Result);
					if (sMSIrlikeToLikeResponseViewModel != null)
					{
						if (sMSIrlikeToLikeResponseViewModel.status == 1)
						{
							SMSIrlikeToLikeDataResponseViewModel data = sMSIrlikeToLikeResponseViewModel.data;
							if (data != null)
							{
								int[] messageIds = data.MessageIds;
								if (Enumerable.Any<int>((IEnumerable<int>)messageIds))
								{
									for (int l = 0; l < messageIds.Length; l++)
									{
										num5 = i * num2 + l;
										array[num5] = messageIds[l];
										num7++;
									}
								}
								else
								{
									array[0] = -5000L;
								}
							}
							else
							{
								array[0] = -5000L;
								msgError = ((!string.IsNullOrEmpty(sMSIrlikeToLikeResponseViewModel.message)) ? sMSIrlikeToLikeResponseViewModel.message : Messages.msgErrorRunFunction);
							}
						}
						else
						{
							array[0] = -5000L;
							msgError = ((!string.IsNullOrEmpty(sMSIrlikeToLikeResponseViewModel.message)) ? sMSIrlikeToLikeResponseViewModel.message : Messages.msgErrorRunFunction);
						}
					}
					else
					{
						array[0] = -5000L;
						msgError = Messages.msgErrorRunFunction;
					}
					continue;
				}
				msgError = Messages.msgErrorRunFunction;
				string result4 = result3.Content.ReadAsStringAsync().Result;
				if (!string.IsNullOrWhiteSpace(result4))
				{
					SMSIrlikeToLikeResponseViewModel sMSIrlikeToLikeResponseViewModel2 = JsonConvert.DeserializeObject<SMSIrlikeToLikeResponseViewModel>(result4);
					if (sMSIrlikeToLikeResponseViewModel2 != null)
					{
						msgError = ((!string.IsNullOrEmpty(sMSIrlikeToLikeResponseViewModel2.message)) ? sMSIrlikeToLikeResponseViewModel2.message : Messages.msgErrorRunFunction);
					}
				}
				array[0] = -5000L;
			}
			if (array != null)
			{
				result = new long[num];
				result = array;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result[0] = -5000L;
			msgError = ex.Message;
		}
	}

	public void SmsIr_SendSms(string numbers, string body, int cmessage, string fromNumber, ref string msgError, ref string result, int smsProviderId = 0)
	{
		result = "0";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			string[] array = numbers.Split(new char[1] { ',' });
			int num = array.Length;
			long[] array2 = new long[num];
			int num2 = 100;
			int num3 = num / num2;
			int num4 = num % num2;
			int num5 = 0;
			int num6 = num2;
			if (num4 != 0)
			{
				num3++;
			}
			for (int i = 0; i < num3; i++)
			{
				if (i == num3 - 1 && num4 != 0)
				{
					num6 = num4;
				}
				string[] array3 = new string[num6];
				for (int j = 0; j < num6; j++)
				{
					num5 = i * num2 + j;
					array3[j] = array[num5];
				}
				int num7 = 0;
				long result2 = 0L;
				long.TryParse(fromNumber, out result2);
				SMSIrBulkViewModel value = new SMSIrBulkViewModel
				{
					messageText = body,
					mobiles = array3,
					lineNumber = result2,
					senddatetime = null
				};
				HttpClient httpClient = new HttpClient();
				string text = "https://api.sms.ir/v1/send/bulk";
				httpClient.BaseAddress = new Uri(text);
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				httpClient.DefaultRequestHeaders.Add("X-API-KEY", smsSettingInfoViewModel.SmsWsPassword);
				HttpContent content = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");
				HttpResponseMessage result3 = httpClient.PostAsync(text, content).Result;
				if (result3.IsSuccessStatusCode)
				{
					SMSIrBulkToSendResponseViewModel sMSIrBulkToSendResponseViewModel = JsonConvert.DeserializeObject<SMSIrBulkToSendResponseViewModel>(result3.Content.ReadAsStringAsync().Result);
					if (sMSIrBulkToSendResponseViewModel != null)
					{
						if (sMSIrBulkToSendResponseViewModel.status == 1)
						{
							SMSIrBulkToSendDataResponseViewModel data = sMSIrBulkToSendResponseViewModel.data;
							if (data != null)
							{
								int[] messageIds = data.MessageIds;
								if (Enumerable.Any<int>((IEnumerable<int>)messageIds))
								{
									for (int k = 0; k < messageIds.Length; k++)
									{
										num5 = i * num2 + k;
										array2[num5] = messageIds[k];
										num7++;
									}
								}
								else
								{
									array2[0] = -5000L;
								}
							}
							else
							{
								array2[0] = -5000L;
							}
						}
						else
						{
							array2[0] = -5000L;
							msgError = ((!string.IsNullOrEmpty(sMSIrBulkToSendResponseViewModel.message)) ? sMSIrBulkToSendResponseViewModel.message : Messages.msgErrorRunFunction);
						}
					}
					else
					{
						array2[0] = -5000L;
						msgError = Messages.msgErrorRunFunction;
					}
					continue;
				}
				msgError = Messages.msgErrorRunFunction;
				string result4 = result3.Content.ReadAsStringAsync().Result;
				if (!string.IsNullOrWhiteSpace(result4))
				{
					SMSIrBulkToSendResponseViewModel sMSIrBulkToSendResponseViewModel2 = JsonConvert.DeserializeObject<SMSIrBulkToSendResponseViewModel>(result4);
					if (sMSIrBulkToSendResponseViewModel2 != null)
					{
						msgError = ((!string.IsNullOrEmpty(sMSIrBulkToSendResponseViewModel2.message)) ? sMSIrBulkToSendResponseViewModel2.message : Messages.msgErrorRunFunction);
					}
				}
				array2[0] = -5000L;
			}
			if (array2 == null || array2[0] < 0)
			{
				result = "-5000";
				return;
			}
			for (int l = 0; l < array2.Length; l++)
			{
				result = result + array2[l] + ",";
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = "-5000";
			msgError = ex.Message;
		}
	}

	public bool SmsIr_GetDelivery(long[] refIdArr, ref int[] result, ref string msgError, int smsProviderId = 0)
	{
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			result = new int[Enumerable.Count<long>((IEnumerable<long>)refIdArr)];
			result[0] = -7;
			if (smsSettingInfoViewModel != null)
			{
				for (int i = 0; i < refIdArr.Length; i++)
				{
					HttpClient httpClient = new HttpClient();
					string text = "https://api.sms.ir/v1/send/" + refIdArr[i];
					httpClient.BaseAddress = new Uri(text);
					httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					httpClient.DefaultRequestHeaders.Add("X-API-KEY", smsSettingInfoViewModel.SmsWsPassword);
					HttpResponseMessage result2 = httpClient.GetAsync(text).Result;
					if (result2.IsSuccessStatusCode)
					{
						SMSIrGetDeliveyResponseViewModel sMSIrGetDeliveyResponseViewModel = JsonConvert.DeserializeObject<SMSIrGetDeliveyResponseViewModel>(result2.Content.ReadAsStringAsync().Result);
						if (sMSIrGetDeliveyResponseViewModel != null)
						{
							if (sMSIrGetDeliveyResponseViewModel.status == 1)
							{
								if (sMSIrGetDeliveyResponseViewModel.data != null)
								{
									int result3 = 0;
									int.TryParse(sMSIrGetDeliveyResponseViewModel.data.deliveryState.ToString(), out result3);
									switch (result3)
									{
									case 1:
										result[i] = 2;
										break;
									case 2:
										result[i] = 3;
										break;
									case 5:
										result[i] = 1;
										break;
									case 3:
									case 4:
										result[i] = 16;
										break;
									case 7:
										result[i] = 4;
										break;
									default:
										result[i] = result3;
										break;
									}
									continue;
								}
								msgError = ((!string.IsNullOrEmpty(sMSIrGetDeliveyResponseViewModel.message)) ? sMSIrGetDeliveyResponseViewModel.message : Messages.msgErrorRunFunction);
								return false;
							}
							msgError = ((!string.IsNullOrEmpty(sMSIrGetDeliveyResponseViewModel.message)) ? sMSIrGetDeliveyResponseViewModel.message : Messages.msgErrorRunFunction);
							return false;
						}
						msgError = ((!string.IsNullOrEmpty(sMSIrGetDeliveyResponseViewModel.message)) ? sMSIrGetDeliveyResponseViewModel.message : Messages.msgErrorRunFunction);
						return false;
					}
					msgError = Messages.msgErrorRunFunction;
					string result4 = result2.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(result4))
					{
						SMSIrGetDeliveyResponseViewModel sMSIrGetDeliveyResponseViewModel2 = JsonConvert.DeserializeObject<SMSIrGetDeliveyResponseViewModel>(result4);
						if (sMSIrGetDeliveyResponseViewModel2 != null)
						{
							msgError = ((!string.IsNullOrEmpty(sMSIrGetDeliveyResponseViewModel2.message)) ? sMSIrGetDeliveyResponseViewModel2.message : Messages.msgErrorRunFunction);
						}
					}
					return false;
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
		}
		return true;
	}

	public void SmsIr_GetCredit(ref decimal credit, ref string msgError, int smsProviderId = 0)
	{
		credit = default(decimal);
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			HttpClient httpClient = new HttpClient();
			string text = "https://api.sms.ir/v1/credit";
			httpClient.BaseAddress = new Uri(text);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			httpClient.DefaultRequestHeaders.Add("X-API-KEY", smsSettingInfoViewModel.SmsWsPassword);
			HttpResponseMessage result = httpClient.GetAsync(text).Result;
			if (result.IsSuccessStatusCode)
			{
				SMSIrCreditResponseViewModel sMSIrCreditResponseViewModel = JsonConvert.DeserializeObject<SMSIrCreditResponseViewModel>(result.Content.ReadAsStringAsync().Result);
				if (sMSIrCreditResponseViewModel != null)
				{
					if (sMSIrCreditResponseViewModel.status == 1)
					{
						decimal result2 = default(decimal);
						decimal.TryParse(sMSIrCreditResponseViewModel.data.ToString(), out result2);
						credit = result2;
					}
					else
					{
						credit = default(decimal);
						msgError = ((!string.IsNullOrEmpty(sMSIrCreditResponseViewModel.message)) ? sMSIrCreditResponseViewModel.message : Messages.ErrorInformation);
					}
				}
				else
				{
					credit = default(decimal);
					msgError = Messages.ErrorInformation;
				}
				return;
			}
			credit = default(decimal);
			string result3 = result.Content.ReadAsStringAsync().Result;
			if (!string.IsNullOrWhiteSpace(result3))
			{
				SMSIrCreditResponseViewModel sMSIrCreditResponseViewModel2 = JsonConvert.DeserializeObject<SMSIrCreditResponseViewModel>(result3);
				if (sMSIrCreditResponseViewModel2 != null)
				{
					msgError = ((!string.IsNullOrEmpty(sMSIrCreditResponseViewModel2.message)) ? sMSIrCreditResponseViewModel2.message : Messages.ErrorInformation);
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
			credit = default(decimal);
		}
	}

	public SMSIrReceiveMessageDataResponseViewModel[] SmsIr_ReceiveSms(int smsProviderId = 0)
	{
		SMSIrReceiveMessageDataResponseViewModel[] result = null;
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			HttpClient httpClient = new HttpClient();
			string text = "https://api.sms.ir/v1/receive/latest?count=100";
			httpClient.BaseAddress = new Uri(text);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			httpClient.DefaultRequestHeaders.Add("X-API-KEY", smsSettingInfoViewModel.SmsWsPassword);
			HttpResponseMessage result2 = httpClient.GetAsync(text).Result;
			if (result2.IsSuccessStatusCode)
			{
				SMSIrReceiveMessageResponseViewModel sMSIrReceiveMessageResponseViewModel = JsonConvert.DeserializeObject<SMSIrReceiveMessageResponseViewModel>(result2.Content.ReadAsStringAsync().Result);
				if (sMSIrReceiveMessageResponseViewModel != null && sMSIrReceiveMessageResponseViewModel.status == 1 && sMSIrReceiveMessageResponseViewModel.data != null)
				{
					result = sMSIrReceiveMessageResponseViewModel.data;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public void WebOne_SendSms1To1(string[] lstMobile, string body, int cmessage, string fromNumber, ref string msgError, ref long[] result, bool smsIsSendByOtherAccount = false, string smsWebServiceUserName = "", string smsWebServicePassword = "", int smsProviderId = 0)
	{
		SendServiceClient sendServiceClient = new SendServiceClient();
		result = new long[1];
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			bool isFlash = cmessage == 3;
			int num = lstMobile.Length;
			long[] array = new long[num];
			int num2 = 100;
			int num3 = num / num2;
			int num4 = num % num2;
			int num5 = 0;
			int num6 = num2;
			if (num4 != 0)
			{
				num3++;
			}
			for (int i = 0; i < num3; i++)
			{
				if (i == num3 - 1 && num4 != 0)
				{
					num6 = num4;
				}
				string[] array2 = new string[num6];
				for (int j = 0; j < num6; j++)
				{
					num5 = i * num2 + j;
					array2[j] = lstMobile[num5];
				}
				long[] recId = new long[array2.Length];
				byte[] status = new byte[array2.Length];
				int num7 = 0;
				string userName = smsSettingInfoViewModel.SmsWsUserName;
				string password = smsSettingInfoViewModel.SmsWsPassword;
				if (smsIsSendByOtherAccount && !string.IsNullOrWhiteSpace(smsWebServiceUserName) && !string.IsNullOrWhiteSpace(smsWebServicePassword))
				{
					userName = smsWebServiceUserName;
					password = smsWebServicePassword;
				}
				switch (sendServiceClient.SendSMS(userName, password, fromNumber, array2, body, isFlash, ref recId, ref status))
				{
				case 1:
					msgError = Messages.msgErrorWOSendSmsIncorrectUsenamePassword;
					goto default;
				case 2:
					msgError = Messages.msgErrorWOSendSmsUserBlocked;
					goto default;
				case 3:
					msgError = Messages.msgErrorWOSendSmsInvalidSenderNumber;
					goto default;
				case 4:
					msgError = Messages.msgErrorWOSendSmsDailyRestriction;
					goto default;
				case 5:
					msgError = Messages.msgErrorWOSendSmsMaxNumRec100;
					goto default;
				case 6:
					msgError = Messages.msgErrorWOSendSmsSenderLineDisabled;
					goto default;
				case 7:
					msgError = Messages.msgErrorWOSendSmsTextContainFilterWord;
					goto default;
				case 8:
					msgError = Messages.msgErrorWOSendSmsCreditNotEnough;
					goto default;
				case 9:
					msgError = Messages.msgErrorWOSendSmsSystemUpdated;
					goto default;
				case 10:
					msgError = Messages.msgErrorWOSendSmsWebServiceDisabled;
					goto default;
				default:
					array[0] = -5000L;
					break;
				case 0:
				{
					if (recId == null)
					{
						array[0] = -5000L;
						break;
					}
					if (recId[0] <= 0)
					{
						array[0] = -5000L;
						break;
					}
					for (int k = 0; k < recId.Length; k++)
					{
						num5 = i * num2 + k;
						array[num5] = recId[k];
						num7++;
					}
					break;
				}
				}
			}
			if (array != null)
			{
				result = new long[num];
				result = array;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result[0] = -5000L;
			msgError = ex.Message;
		}
	}

	public void WebOne_SendSms(string numbers, string body, int cmessage, string fromNumber, ref string msgError, ref string result, int smsProviderId = 0)
	{
		result = "0";
		try
		{
			SendServiceClient sendServiceClient = new SendServiceClient();
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			string[] array = numbers.Split(new char[1] { ',' });
			bool isFlash = cmessage == 3;
			int num = array.Length;
			long[] array2 = new long[num];
			int num2 = 100;
			int num3 = num / num2;
			int num4 = num % num2;
			int num5 = 0;
			int num6 = num2;
			if (num4 != 0)
			{
				num3++;
			}
			for (int i = 0; i < num3; i++)
			{
				if (i == num3 - 1 && num4 != 0)
				{
					num6 = num4;
				}
				string[] array3 = new string[num6];
				for (int j = 0; j < num6; j++)
				{
					num5 = i * num2 + j;
					array3[j] = array[num5];
				}
				long[] recId = new long[array3.Length];
				byte[] status = new byte[array3.Length];
				int num7 = 0;
				switch (sendServiceClient.SendSMS(smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, fromNumber, array3, body, isFlash, ref recId, ref status))
				{
				case 1:
					msgError = Messages.msgErrorWOSendSmsIncorrectUsenamePassword;
					goto default;
				case 2:
					msgError = Messages.msgErrorWOSendSmsUserBlocked;
					goto default;
				case 3:
					msgError = Messages.msgErrorWOSendSmsInvalidSenderNumber;
					goto default;
				case 4:
					msgError = Messages.msgErrorWOSendSmsDailyRestriction;
					goto default;
				case 5:
					msgError = Messages.msgErrorWOSendSmsMaxNumRec100;
					goto default;
				case 6:
					msgError = Messages.msgErrorWOSendSmsSenderLineDisabled;
					goto default;
				case 7:
					msgError = Messages.msgErrorWOSendSmsTextContainFilterWord;
					goto default;
				case 8:
					msgError = Messages.msgErrorWOSendSmsCreditNotEnough;
					goto default;
				case 9:
					msgError = Messages.msgErrorWOSendSmsSystemUpdated;
					goto default;
				case 10:
					msgError = Messages.msgErrorWOSendSmsWebServiceDisabled;
					goto default;
				default:
					array2[0] = -5000L;
					break;
				case 0:
				{
					if (recId == null)
					{
						array2[0] = -5000L;
						break;
					}
					if (recId[0] <= 0)
					{
						array2[0] = -5000L;
						break;
					}
					for (int k = 0; k < recId.Length; k++)
					{
						num5 = i * num2 + k;
						array2[num5] = recId[k];
						num7++;
					}
					break;
				}
				}
			}
			if (array2 == null || array2[0] <= 0)
			{
				result = "-5000";
				return;
			}
			for (int l = 0; l < array2.Length; l++)
			{
				result = result + array2[l] + ",";
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = "-5000";
			msgError = ex.Message;
		}
	}

	public void WebOne_GetDelivery(long[] refIdArr, ref int[] result, ref string msgError, int smsProviderId = 0)
	{
		try
		{
			SendServiceClient sendServiceClient = new SendServiceClient();
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			result = new int[Enumerable.Count<long>((IEnumerable<long>)refIdArr)];
			result[0] = -7;
			if (smsSettingInfoViewModel == null)
			{
				return;
			}
			long[] array = new long[refIdArr.Length];
			for (int i = 0; i < refIdArr.Length; i++)
			{
				array[i] = sendServiceClient.GetDeilvery(smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, refIdArr[i]);
			}
			if (array == null)
			{
				return;
			}
			for (int j = 0; j < refIdArr.Length; j++)
			{
				if (array[j] == 0L)
				{
					result[j] = 1;
				}
				else if (array[j] == 1)
				{
					result[j] = 2;
				}
				else if (array[j] == 2)
				{
					result[j] = 3;
				}
				else if (array[j] == 5)
				{
					result[j] = 8;
				}
				else if (array[j] == 6)
				{
					result[j] = 16;
				}
				else
				{
					result[j] = (int)array[j];
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
		}
	}

	public void WebOne_GetCredit(ref decimal credit, ref string msgError, int smsProviderId = 0)
	{
		credit = default(decimal);
		msgError = "";
		try
		{
			SendServiceClient sendServiceClient = new SendServiceClient();
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			decimal credit2 = sendServiceClient.GetCredit(smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword);
			if (credit2 < 0m)
			{
				msgError = Messages.ErrorInformation;
				if (credit2 == -1m)
				{
					msgError = msgError + "<br/>" + Messages.msgErrorWOSendSmsIncorrectUsenamePassword;
				}
				else if (credit2 == -2m)
				{
					msgError = msgError + "<br/>" + Messages.msgErrorWOSendSmsUserInactive;
				}
				credit = default(decimal);
			}
			else
			{
				credit = credit2;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
			credit = default(decimal);
		}
	}

	public MessageInfo[] WebOne_ReceiveSms(int smsProviderId = 0)
	{
		MessageInfo[] array = null;
		try
		{
			SendServiceClient sendServiceClient = new SendServiceClient();
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			int inboxCount = sendServiceClient.GetInboxCount(smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, isRead: false);
			if (inboxCount == -1)
			{
				Exception e = new Exception(Messages.ErrorInformation + "(" + Messages.msgErrorWOSendSmsIncorrectUsenamePassword + ") in recieve sms");
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			else if (inboxCount > 0)
			{
				int num = 1000;
				int num2 = inboxCount / num;
				int num3 = inboxCount % num;
				int num4 = 0;
				int count = num;
				if (num3 != 0)
				{
					num2++;
				}
				array = new MessageInfo[inboxCount];
				for (int i = 0; i < num2; i++)
				{
					if (i == num2 - 1 && num3 != 0)
					{
						count = num3;
					}
					MessageInfo[] array2 = null;
					array2 = sendServiceClient.GetMessages(smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, 1, new string[1] { smsSettingInfoViewModel.SmsWsFromNumber }, 1, count);
					if (array2 != null)
					{
						for (int j = 0; j < array2.Length; j++)
						{
							num4 = i * num + j;
							array[num4] = array2[j];
						}
					}
				}
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return array;
	}

	public void MeliPayamak_SendSms1To1(string[] lstMobile, string body, int cmessage, string fromNumber, ref string msgError, ref long[] result, bool smsIsSendByOtherAccount = false, string smsWebServiceUserName = "", string smsWebServicePassword = "", int smsProviderId = 0)
	{
		result = new long[1];
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			bool flag = cmessage == 3;
			int num = lstMobile.Length;
			long[] array = new long[num];
			int num2 = 100;
			int num3 = num / num2;
			int num4 = num % num2;
			int num5 = 0;
			int num6 = num2;
			if (num4 != 0)
			{
				num3++;
			}
			for (int i = 0; i < num3; i++)
			{
				if (i == num3 - 1 && num4 != 0)
				{
					num6 = num4;
				}
				string[] array2 = new string[num6];
				for (int j = 0; j < num6; j++)
				{
					num5 = i * num2 + j;
					array2[j] = lstMobile[num5];
				}
				long[] array3 = new long[array2.Length];
				_ = new byte[array2.Length];
				int num7 = 0;
				string text = "";
				for (int k = 0; k < array2.Length; k++)
				{
					text = text + array2[k] + ",";
				}
				if (text.EndsWith(","))
				{
					text = text.TrimEnd(new char[1] { ',' });
				}
				_ = smsSettingInfoViewModel.SmsWsUserName;
				_ = smsSettingInfoViewModel.SmsWsPassword;
				if (smsIsSendByOtherAccount && !string.IsNullOrWhiteSpace(smsWebServiceUserName))
				{
					string.IsNullOrWhiteSpace(smsWebServicePassword);
				}
				HttpClient httpClient = new HttpClient();
				string text2 = $"https://rest.payamak-panel.com/api/SendSMS/SendSMS?username={smsSettingInfoViewModel.SmsWsUserName}&password={smsSettingInfoViewModel.SmsWsPassword}&to={text}&from={fromNumber}&text={body}&isFlash={flag}";
				httpClient.BaseAddress = new Uri(text2);
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpContent content = new StringContent(JsonConvert.SerializeObject(new SmsMeliPayamakSendSmsViewModel
				{
					username = smsSettingInfoViewModel.SmsWsUserName,
					password = smsSettingInfoViewModel.SmsWsPassword,
					to = text,
					from = fromNumber,
					text = body,
					isFlash = flag
				}), Encoding.UTF8, "application/json");
				HttpResponseMessage result2 = httpClient.PostAsync(text2, content).Result;
				if (result2.IsSuccessStatusCode)
				{
					string result3 = result2.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrEmpty(result3))
					{
						SmsMeliPayamakResultViewModel smsMeliPayamakResultViewModel = JsonConvert.DeserializeObject<SmsMeliPayamakResultViewModel>(result3);
						if (smsMeliPayamakResultViewModel != null)
						{
							if (smsMeliPayamakResultViewModel.RetStatus == 1)
							{
								if (!string.IsNullOrEmpty(smsMeliPayamakResultViewModel.Value))
								{
									string[] array4 = smsMeliPayamakResultViewModel.Value.Split(new char[1] { ',' });
									if (array4 != null && Enumerable.Any<string>((IEnumerable<string>)array4))
									{
										if (Enumerable.Count<string>((IEnumerable<string>)array4) == 1)
										{
											long result4 = 0L;
											long.TryParse(array4[0], out result4);
											switch (result4)
											{
											case 0L:
												msgError = Messages.msgErrorMPaySmsIncorrectUsenamePassword;
												array[0] = -5000L;
												continue;
											case 1L:
												msgError = Messages.msgErrorMPaySendSmsReqWasSuccessdul;
												array[0] = -5000L;
												continue;
											case 2L:
												msgError = Messages.msgErrorMPaySendSmsCreditNotEnough;
												array[0] = -5000L;
												continue;
											case 3L:
												msgError = Messages.msgErrorMPaySendSmsDailyRestriction;
												array[0] = -5000L;
												continue;
											case 4L:
												msgError = Messages.msgErrorMPaySendSmsRestrictionSizeSend;
												array[0] = -5000L;
												continue;
											case 5L:
												msgError = Messages.msgErrorMPaySendSmsInvalidSenderNumber;
												array[0] = -5000L;
												continue;
											case 6L:
												msgError = Messages.msgErrorMPaySendSmsSystemUpdated;
												array[0] = -5000L;
												continue;
											case 7L:
												msgError = Messages.msgErrorMPaySendSmsContainFilterWord;
												array[0] = -5000L;
												continue;
											case 9L:
												msgError = Messages.msgErrorMPaySendSmsFromPublicLine;
												array[0] = -5000L;
												continue;
											case 10L:
												msgError = Messages.msgErrorMPaySendSmsUserNotActive;
												array[0] = -5000L;
												continue;
											case 11L:
												msgError = Messages.msgErrorMPaySendSmsNotSent;
												array[0] = -5000L;
												continue;
											case 12L:
												msgError = Messages.msgErrorMPaySendUserDocNotComplete;
												array[0] = -5000L;
												continue;
											}
											for (int l = 0; l < array3.Length; l++)
											{
												num5 = i * num2 + l;
												array[num5] = result4;
												num7++;
											}
											continue;
										}
										for (int m = 0; m < array4.Length; m++)
										{
											long result5 = 0L;
											long.TryParse(array4[m], out result5);
											num5 = i * num2 + m;
											switch (result5)
											{
											case 0L:
												msgError = Messages.msgErrorMPaySmsIncorrectUsenamePassword;
												array[0] = -5000L;
												break;
											case 1L:
												msgError = Messages.msgErrorMPaySendSmsReqWasSuccessdul;
												array[0] = -5000L;
												break;
											case 2L:
												msgError = Messages.msgErrorMPaySendSmsCreditNotEnough;
												array[0] = -5000L;
												break;
											case 3L:
												msgError = Messages.msgErrorMPaySendSmsDailyRestriction;
												array[0] = -5000L;
												break;
											case 4L:
												msgError = Messages.msgErrorMPaySendSmsRestrictionSizeSend;
												array[0] = -5000L;
												break;
											case 5L:
												msgError = Messages.msgErrorMPaySendSmsInvalidSenderNumber;
												array[0] = -5000L;
												break;
											case 6L:
												msgError = Messages.msgErrorMPaySendSmsSystemUpdated;
												array[0] = -5000L;
												break;
											case 7L:
												msgError = Messages.msgErrorMPaySendSmsContainFilterWord;
												array[num5] = -5000L;
												break;
											case 9L:
												msgError = Messages.msgErrorMPaySendSmsFromPublicLine;
												array[0] = -5000L;
												break;
											case 10L:
												msgError = Messages.msgErrorMPaySendSmsUserNotActive;
												array[0] = -5000L;
												break;
											case 11L:
												msgError = Messages.msgErrorMPaySendSmsNotSent;
												array[0] = -5000L;
												break;
											case 12L:
												msgError = Messages.msgErrorMPaySendUserDocNotComplete;
												array[0] = -5000L;
												break;
											default:
												array[num5] = result5;
												break;
											}
											num7++;
										}
									}
									else
									{
										msgError = Messages.msgErrorRunFunction;
										array[0] = -5000L;
									}
								}
								else
								{
									msgError = Messages.msgErrorRunFunction;
									array[0] = -5000L;
								}
							}
							else
							{
								msgError = Messages.msgErrorRunFunction;
								array[0] = -5000L;
							}
						}
						else
						{
							msgError = Messages.msgErrorRunFunction;
							array[0] = -5000L;
						}
					}
					else
					{
						msgError = Messages.msgErrorRunFunction;
						array[0] = -5000L;
					}
				}
				else
				{
					msgError = Messages.msgErrorRunFunction;
					array[0] = -5000L;
				}
			}
			if (array != null)
			{
				result = new long[num];
				result = array;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result[0] = -5000L;
			msgError = ex.Message;
		}
	}

	public void MeliPayamak_SendSms(string numbers, string body, int cmessage, string fromNumber, ref string msgError, ref string result, int smsProviderId = 0)
	{
		result = "0";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			string[] array = numbers.Split(new char[1] { ',' });
			bool flag = cmessage == 3;
			int num = array.Length;
			long[] array2 = new long[num];
			int num2 = 100;
			int num3 = num / num2;
			int num4 = num % num2;
			int num5 = 0;
			int num6 = num2;
			if (num4 != 0)
			{
				num3++;
			}
			for (int i = 0; i < num3; i++)
			{
				if (i == num3 - 1 && num4 != 0)
				{
					num6 = num4;
				}
				string[] array3 = new string[num6];
				for (int j = 0; j < num6; j++)
				{
					num5 = i * num2 + j;
					array3[j] = array[num5];
				}
				long[] array4 = new long[array3.Length];
				_ = new byte[array3.Length];
				int num7 = 0;
				string text = "";
				for (int k = 0; k < array3.Length; k++)
				{
					text = text + array3[k] + ",";
				}
				if (text.EndsWith(","))
				{
					text = text.TrimEnd(new char[1] { ',' });
				}
				HttpClient httpClient = new HttpClient();
				string text2 = $"https://rest.payamak-panel.com/api/SendSMS/SendSMS?username={smsSettingInfoViewModel.SmsWsUserName}&password={smsSettingInfoViewModel.SmsWsPassword}&to={text}&from={fromNumber}&text={body}&isFlash={flag}";
				httpClient.BaseAddress = new Uri(text2);
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpContent content = new StringContent(JsonConvert.SerializeObject(new SmsMeliPayamakSendSmsViewModel
				{
					username = smsSettingInfoViewModel.SmsWsUserName,
					password = smsSettingInfoViewModel.SmsWsPassword,
					to = text,
					from = fromNumber,
					text = body,
					isFlash = flag
				}), Encoding.UTF8, "application/json");
				HttpResponseMessage result2 = httpClient.PostAsync(text2, content).Result;
				if (result2.IsSuccessStatusCode)
				{
					string result3 = result2.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrEmpty(result3))
					{
						SmsMeliPayamakResultViewModel smsMeliPayamakResultViewModel = JsonConvert.DeserializeObject<SmsMeliPayamakResultViewModel>(result3);
						if (smsMeliPayamakResultViewModel != null)
						{
							if (smsMeliPayamakResultViewModel.RetStatus == 1)
							{
								if (!string.IsNullOrEmpty(smsMeliPayamakResultViewModel.Value))
								{
									string[] array5 = smsMeliPayamakResultViewModel.Value.Split(new char[1] { ',' });
									if (array5 != null && Enumerable.Any<string>((IEnumerable<string>)array5))
									{
										if (Enumerable.Count<string>((IEnumerable<string>)array5) == 1)
										{
											long result4 = 0L;
											long.TryParse(array5[0], out result4);
											switch (result4)
											{
											case 0L:
												msgError = Messages.msgErrorMPaySmsIncorrectUsenamePassword;
												array2[0] = -5000L;
												continue;
											case 1L:
												msgError = Messages.msgErrorMPaySendSmsReqWasSuccessdul;
												array2[0] = -5000L;
												continue;
											case 2L:
												msgError = Messages.msgErrorMPaySendSmsCreditNotEnough;
												array2[0] = -5000L;
												continue;
											case 3L:
												msgError = Messages.msgErrorMPaySendSmsDailyRestriction;
												array2[0] = -5000L;
												continue;
											case 4L:
												msgError = Messages.msgErrorMPaySendSmsRestrictionSizeSend;
												array2[0] = -5000L;
												continue;
											case 5L:
												msgError = Messages.msgErrorMPaySendSmsInvalidSenderNumber;
												array2[0] = -5000L;
												continue;
											case 6L:
												msgError = Messages.msgErrorMPaySendSmsSystemUpdated;
												array2[0] = -5000L;
												continue;
											case 7L:
												msgError = Messages.msgErrorMPaySendSmsContainFilterWord;
												array2[0] = -5000L;
												continue;
											case 9L:
												msgError = Messages.msgErrorMPaySendSmsFromPublicLine;
												array2[0] = -5000L;
												continue;
											case 10L:
												msgError = Messages.msgErrorMPaySendSmsUserNotActive;
												array2[0] = -5000L;
												continue;
											case 11L:
												msgError = Messages.msgErrorMPaySendSmsNotSent;
												array2[0] = -5000L;
												continue;
											case 12L:
												msgError = Messages.msgErrorMPaySendUserDocNotComplete;
												array2[0] = -5000L;
												continue;
											}
											for (int l = 0; l < array4.Length; l++)
											{
												num5 = i * num2 + l;
												array2[num5] = result4;
												num7++;
											}
											continue;
										}
										for (int m = 0; m < array5.Length; m++)
										{
											long result5 = 0L;
											long.TryParse(array5[m], out result5);
											num5 = i * num2 + m;
											switch (result5)
											{
											case 0L:
												msgError = Messages.msgErrorMPaySmsIncorrectUsenamePassword;
												array2[0] = -5000L;
												break;
											case 1L:
												msgError = Messages.msgErrorMPaySendSmsReqWasSuccessdul;
												array2[0] = -5000L;
												break;
											case 2L:
												msgError = Messages.msgErrorMPaySendSmsCreditNotEnough;
												array2[0] = -5000L;
												break;
											case 3L:
												msgError = Messages.msgErrorMPaySendSmsDailyRestriction;
												array2[0] = -5000L;
												break;
											case 4L:
												msgError = Messages.msgErrorMPaySendSmsRestrictionSizeSend;
												array2[0] = -5000L;
												break;
											case 5L:
												msgError = Messages.msgErrorMPaySendSmsInvalidSenderNumber;
												array2[0] = -5000L;
												break;
											case 6L:
												msgError = Messages.msgErrorMPaySendSmsSystemUpdated;
												array2[0] = -5000L;
												break;
											case 7L:
												msgError = Messages.msgErrorMPaySendSmsContainFilterWord;
												array2[num5] = -5000L;
												break;
											case 9L:
												msgError = Messages.msgErrorMPaySendSmsFromPublicLine;
												array2[0] = -5000L;
												break;
											case 10L:
												msgError = Messages.msgErrorMPaySendSmsUserNotActive;
												array2[0] = -5000L;
												break;
											case 11L:
												msgError = Messages.msgErrorMPaySendSmsNotSent;
												array2[0] = -5000L;
												break;
											case 12L:
												msgError = Messages.msgErrorMPaySendUserDocNotComplete;
												array2[0] = -5000L;
												break;
											default:
												array2[num5] = result5;
												break;
											}
											num7++;
										}
									}
									else
									{
										msgError = Messages.msgErrorRunFunction;
										array2[0] = -5000L;
									}
								}
								else
								{
									msgError = Messages.msgErrorRunFunction;
									array2[0] = -5000L;
								}
							}
							else
							{
								msgError = Messages.msgErrorRunFunction;
								array2[0] = -5000L;
							}
						}
						else
						{
							msgError = Messages.msgErrorRunFunction;
							array2[0] = -5000L;
						}
					}
					else
					{
						msgError = Messages.msgErrorRunFunction;
						array2[0] = -5000L;
					}
				}
				else
				{
					msgError = Messages.msgErrorRunFunction;
					array2[0] = -5000L;
				}
			}
			if (array2 == null || array2[0] <= 0)
			{
				result = "-5000";
				return;
			}
			for (int n = 0; n < array2.Length; n++)
			{
				result = result + array2[n] + ",";
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = "-5000";
			msgError = ex.Message;
		}
	}

	public void MeliPayamak_GetDelivery(long[] refIdArr, ref int[] result, ref string msgError, int smsProviderId = 0)
	{
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			result = new int[Enumerable.Count<long>((IEnumerable<long>)refIdArr)];
			result[0] = -7;
			if (smsSettingInfoViewModel == null)
			{
				return;
			}
			long[] array = new long[refIdArr.Length];
			for (int i = 0; i < refIdArr.Length; i++)
			{
				HttpClient httpClient = new HttpClient();
				string text = $"https://rest.payamak-panel.com/api/SendSMS/GetDeliveries2?username={smsSettingInfoViewModel.SmsWsUserName}&password={smsSettingInfoViewModel.SmsWsPassword}&recId={refIdArr[i]}";
				httpClient.BaseAddress = new Uri(text);
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpContent content = new StringContent(JsonConvert.SerializeObject(new SmsMeliPayamakGetDeliveriesViewModel
				{
					username = smsSettingInfoViewModel.SmsWsUserName,
					password = smsSettingInfoViewModel.SmsWsPassword,
					recId = refIdArr[i]
				}), Encoding.UTF8, "application/json");
				HttpResponseMessage result2 = httpClient.PostAsync(text, content).Result;
				if (result2.IsSuccessStatusCode)
				{
					string result3 = result2.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrEmpty(result3))
					{
						SmsMeliPayamakResultViewModel smsMeliPayamakResultViewModel = JsonConvert.DeserializeObject<SmsMeliPayamakResultViewModel>(result3);
						if (smsMeliPayamakResultViewModel == null)
						{
							msgError = Messages.ErrorInformation;
							array[i] = -1L;
						}
						else if (smsMeliPayamakResultViewModel.RetStatus == 1)
						{
							array[i] = int.Parse(smsMeliPayamakResultViewModel.Value ?? "0");
						}
						else
						{
							msgError = Messages.ErrorInformation + " (" + smsMeliPayamakResultViewModel.StrRetStatus + ")";
							array[i] = -1L;
						}
					}
					else
					{
						msgError = Messages.ErrorInformation;
						array[i] = -1L;
					}
				}
				else
				{
					msgError = Messages.ErrorInformation;
					array[i] = -1L;
				}
			}
			if (array == null)
			{
				return;
			}
			for (int j = 0; j < refIdArr.Length; j++)
			{
				if (array[j] == 0L)
				{
					result[j] = 1;
				}
				else if (array[j] == 1)
				{
					result[j] = 2;
				}
				else if (array[j] == 2)
				{
					result[j] = 3;
				}
				else if (array[j] == 35)
				{
					result[j] = 4;
				}
				else if (array[j] == 400)
				{
					result[j] = 0;
				}
				else
				{
					result[j] = (int)array[j];
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
		}
	}

	public void MeliPayamak_GetCredit(ref decimal credit, ref string msgError, ref decimal basePrice, int smsProviderId = 0)
	{
		credit = default(decimal);
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			HttpClient httpClient = new HttpClient();
			string text = $"https://rest.payamak-panel.com/api/SendSMS/GetCredit2?UserName={smsSettingInfoViewModel.SmsWsUserName}&PassWord={smsSettingInfoViewModel.SmsWsPassword}";
			httpClient.BaseAddress = new Uri(text);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			HttpContent content = new StringContent(JsonConvert.SerializeObject(new SmsMeliPayamakGetCreditViewModel
			{
				UserName = smsSettingInfoViewModel.SmsWsUserName,
				PassWord = smsSettingInfoViewModel.SmsWsPassword
			}), Encoding.UTF8, "application/json");
			HttpResponseMessage result = httpClient.PostAsync(text, content).Result;
			if (result.IsSuccessStatusCode)
			{
				string result2 = result.Content.ReadAsStringAsync().Result;
				if (!string.IsNullOrEmpty(result2))
				{
					SmsMeliPayamakResultViewModel smsMeliPayamakResultViewModel = JsonConvert.DeserializeObject<SmsMeliPayamakResultViewModel>(result2);
					if (smsMeliPayamakResultViewModel == null)
					{
						msgError = Messages.ErrorInformation;
						credit = default(decimal);
					}
					else if (smsMeliPayamakResultViewModel.RetStatus == 1)
					{
						decimal.TryParse(smsMeliPayamakResultViewModel.Value.ToString(), out credit);
					}
					else
					{
						msgError = Messages.ErrorInformation;
						credit = default(decimal);
					}
				}
				else
				{
					msgError = Messages.ErrorInformation;
					credit = default(decimal);
				}
			}
			else
			{
				msgError = Messages.ErrorInformation;
				credit = default(decimal);
			}
			basePrice = default(decimal);
			HttpClient httpClient2 = new HttpClient();
			text = $"https://rest.payamak-panel.com/api/SendSMS/GetBasePrice?UserName={smsSettingInfoViewModel.SmsWsUserName}&PassWord={smsSettingInfoViewModel.SmsWsPassword}";
			httpClient2.BaseAddress = new Uri(text);
			httpClient2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			content = new StringContent(JsonConvert.SerializeObject(new SmsMeliPayamakGetCreditViewModel
			{
				UserName = smsSettingInfoViewModel.SmsWsUserName,
				PassWord = smsSettingInfoViewModel.SmsWsPassword
			}), Encoding.UTF8, "application/json");
			result = httpClient2.PostAsync(text, content).Result;
			if (result.IsSuccessStatusCode)
			{
				string result3 = result.Content.ReadAsStringAsync().Result;
				if (!string.IsNullOrEmpty(result3))
				{
					SmsMeliPayamakResultViewModel smsMeliPayamakResultViewModel2 = JsonConvert.DeserializeObject<SmsMeliPayamakResultViewModel>(result3);
					if (smsMeliPayamakResultViewModel2 == null)
					{
						msgError = Messages.ErrorInformation;
						basePrice = default(decimal);
					}
					else if (smsMeliPayamakResultViewModel2.RetStatus == 1)
					{
						decimal.TryParse(smsMeliPayamakResultViewModel2.Value.ToString(), out basePrice);
					}
					else
					{
						msgError = Messages.ErrorInformation;
						basePrice = default(decimal);
					}
				}
				else
				{
					msgError = Messages.ErrorInformation;
					basePrice = default(decimal);
				}
			}
			else
			{
				msgError = Messages.ErrorInformation;
				basePrice = default(decimal);
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
			credit = default(decimal);
		}
	}

	public List<SmsMeliPayamakGetMessagesDataResultViewModel> MeliPayamak_ReceiveSms(int smsProviderId = 0)
	{
		List<SmsMeliPayamakGetMessagesDataResultViewModel> list = null;
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			int result = 0;
			HttpClient httpClient = new HttpClient();
			string text = $"https://rest.payamak-panel.com/api/SendSMS/GetInboxCount?username={smsSettingInfoViewModel.SmsWsUserName}&password={smsSettingInfoViewModel.SmsWsPassword}&isRead={false}";
			httpClient.BaseAddress = new Uri(text);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			HttpContent content = new StringContent(JsonConvert.SerializeObject(new SmsMeliPayamakGetInboxCountViewModel
			{
				username = smsSettingInfoViewModel.SmsWsUserName,
				password = smsSettingInfoViewModel.SmsWsPassword,
				isRead = false
			}), Encoding.UTF8, "application/json");
			HttpResponseMessage result2 = httpClient.PostAsync(text, content).Result;
			if (result2.IsSuccessStatusCode)
			{
				string result3 = result2.Content.ReadAsStringAsync().Result;
				if (!string.IsNullOrEmpty(result3))
				{
					SmsMeliPayamakResultViewModel smsMeliPayamakResultViewModel = JsonConvert.DeserializeObject<SmsMeliPayamakResultViewModel>(result3);
					if (smsMeliPayamakResultViewModel == null)
					{
						result = 0;
					}
					else if (smsMeliPayamakResultViewModel.RetStatus == 1)
					{
						int.TryParse(smsMeliPayamakResultViewModel.Value.ToString(), out result);
					}
					else
					{
						result = 0;
					}
				}
				else
				{
					result = 0;
				}
			}
			else
			{
				result = 0;
			}
			int num = 1;
			if (result == -1)
			{
				Exception e = new Exception(Messages.ErrorInformation + "(" + Messages.msgErrorMPaySmsIncorrectUsenamePassword + ") in recieve sms");
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			else if (result > 0)
			{
				int num2 = 100;
				int num3 = result / num2;
				int num4 = result % num2;
				int num5 = num2;
				if (num4 != 0)
				{
					num3++;
				}
				list = new List<SmsMeliPayamakGetMessagesDataResultViewModel>();
				for (int i = 0; i < num3; i++)
				{
					if (i == num3 - 1 && num4 != 0)
					{
						num5 = num4;
					}
					httpClient = new HttpClient();
					text = $"https://rest.payamak-panel.com/api/SendSMS/GetMessages?username={smsSettingInfoViewModel.SmsWsUserName}&password={smsSettingInfoViewModel.SmsWsPassword}&location={num}&index={0}&count={num5}";
					httpClient.BaseAddress = new Uri(text);
					httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					content = new StringContent(JsonConvert.SerializeObject(new SmsMeliPayamakGetMessagesViewModel
					{
						username = smsSettingInfoViewModel.SmsWsUserName,
						password = smsSettingInfoViewModel.SmsWsPassword,
						location = num,
						index = 0,
						count = num5
					}), Encoding.UTF8, "application/json");
					result2 = httpClient.PostAsync(text, content).Result;
					if (!result2.IsSuccessStatusCode)
					{
						continue;
					}
					string result4 = result2.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrEmpty(result4))
					{
						SmsMeliPayamakGetMessagesResultViewModel smsMeliPayamakGetMessagesResultViewModel = JsonConvert.DeserializeObject<SmsMeliPayamakGetMessagesResultViewModel>(result4);
						if (smsMeliPayamakGetMessagesResultViewModel != null && smsMeliPayamakGetMessagesResultViewModel.MyBase != null && smsMeliPayamakGetMessagesResultViewModel.MyBase.RetStatus == 1 && smsMeliPayamakGetMessagesResultViewModel.MyBase.Value.ToLower() == "ok" && smsMeliPayamakGetMessagesResultViewModel.Data != null)
						{
							list.AddRange(smsMeliPayamakGetMessagesResultViewModel.Data);
						}
					}
				}
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return list;
	}

	public void MeliPayamak_SendSmsByBaseNumber(string mobile, string body, string fromNumber, ref string msgError, ref long result, int smsProviderId = 0)
	{
		result = -5000L;
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			int valueOrDefault = Enumerable.FirstOrDefault<MobspSelectSmsVerificationFoSetting_Result>((IEnumerable<MobspSelectSmsVerificationFoSetting_Result>)new CRMEntities().MobspSelectSmsVerificationFoSetting()).SmsVerificationId.GetValueOrDefault();
			HttpClient httpClient = new HttpClient();
			string text = $"https://rest.payamak-panel.com/api/SendSMS/BaseServiceNumber?username={smsSettingInfoViewModel.SmsWsUserName}&password={smsSettingInfoViewModel.SmsWsPassword}&text={body}&to={mobile}&bodyId={valueOrDefault}";
			httpClient.BaseAddress = new Uri(text);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			HttpContent content = new StringContent(JsonConvert.SerializeObject(new SmsMeliPayamakSendSmsByBaseNumber2ViewModel
			{
				username = smsSettingInfoViewModel.SmsWsUserName,
				password = smsSettingInfoViewModel.SmsWsPassword,
				text = body,
				to = mobile,
				bodyId = valueOrDefault
			}), Encoding.UTF8, "application/json");
			HttpResponseMessage result2 = httpClient.PostAsync(text, content).Result;
			if (result2.IsSuccessStatusCode)
			{
				string result3 = result2.Content.ReadAsStringAsync().Result;
				if (!string.IsNullOrEmpty(result3))
				{
					SmsMeliPayamakResultViewModel smsMeliPayamakResultViewModel = JsonConvert.DeserializeObject<SmsMeliPayamakResultViewModel>(result3);
					if (smsMeliPayamakResultViewModel != null)
					{
						if (smsMeliPayamakResultViewModel.RetStatus == 1)
						{
							if (!string.IsNullOrEmpty(smsMeliPayamakResultViewModel.Value))
							{
								long result4 = 0L;
								long.TryParse(smsMeliPayamakResultViewModel.Value, out result4);
								switch (result4)
								{
								case 0L:
									msgError = Messages.msgErrorMPaySmsIncorrectUsenamePassword;
									result = -5000L;
									break;
								case 1L:
									msgError = Messages.msgErrorMPaySendSmsReqWasSuccessdul;
									result = -5000L;
									break;
								case 2L:
									msgError = Messages.msgErrorMPaySendSmsCreditNotEnough;
									result = -5000L;
									break;
								case 3L:
									msgError = Messages.msgErrorMPaySendSmsDailyRestriction;
									result = -5000L;
									break;
								case 4L:
									msgError = Messages.msgErrorMPaySendSmsRestrictionSizeSend;
									result = -5000L;
									break;
								case 5L:
									msgError = Messages.msgErrorMPaySendSmsInvalidSenderNumber;
									result = -5000L;
									break;
								case 6L:
									msgError = Messages.msgErrorMPaySendSmsSystemUpdated;
									result = -5000L;
									break;
								case 7L:
									msgError = Messages.msgErrorMPaySendSmsContainFilterWord;
									result = -5000L;
									break;
								case 9L:
									msgError = Messages.msgErrorMPaySendSmsFromPublicLine;
									result = -5000L;
									break;
								case 10L:
									msgError = Messages.msgErrorMPaySendSmsUserNotActive;
									result = -5000L;
									break;
								case 11L:
									msgError = Messages.msgErrorMPaySendSmsNotSent;
									result = -5000L;
									break;
								case 12L:
									msgError = Messages.msgErrorMPaySendUserDocNotComplete;
									result = -5000L;
									break;
								case -1L:
									msgError = Messages.msgErrorMPaySendWebserviceDisable;
									result = -5000L;
									break;
								case -2L:
									msgError = Messages.msgErrorMPaySendLimitByOneMob;
									result = -5000L;
									break;
								case -3L:
									msgError = Messages.msgErrorMPaySendLineNotDefine;
									result = -5000L;
									break;
								case -4L:
									msgError = Messages.msgErrorMPaySendTextNotVerified;
									result = -5000L;
									break;
								case -5L:
									msgError = Messages.msgErrorMPaySendTextNotMatchVariables;
									result = -5000L;
									break;
								case -6L:
									msgError = Messages.msgErrorMPaySendInternalError;
									result = -5000L;
									break;
								case -7L:
									msgError = Messages.msgErrorMPaySendErrorInSenderNumber;
									result = -5000L;
									break;
								default:
									result = result4;
									break;
								}
							}
							else
							{
								msgError = Messages.msgErrorRunFunction;
								result = -5000L;
							}
						}
						else
						{
							msgError = Messages.msgErrorRunFunction;
							result = -5000L;
						}
					}
					else
					{
						msgError = Messages.msgErrorRunFunction;
						result = -5000L;
					}
				}
				else
				{
					msgError = Messages.msgErrorRunFunction;
					result = -5000L;
				}
			}
			else
			{
				msgError = Messages.msgErrorRunFunction;
				result = -5000L;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = -5000L;
			msgError = ex.Message;
		}
	}

	public void SmsPlus_SendSms1To1(string[] lstMobile, string body, int cmessage, string fromNumber, ref int sIdTemp, ref string msgError, ref long[] result, bool smsIsSendByOtherAccount = false, string smsWebServiceUserName = "", string smsWebServicePassword = "", int smsProviderId = 0)
	{
		result = new long[1];
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			bool flag = cmessage == 3;
			string text = "";
			int num = lstMobile.Length;
			long[] array = new long[num];
			int num2 = 128;
			int num3 = num / num2;
			int num4 = num % num2;
			int num5 = 0;
			int num6 = num2;
			if (num4 != 0)
			{
				num3++;
			}
			for (int i = 0; i < num3; i++)
			{
				Thread.Sleep(3000);
				if (i == num3 - 1 && num4 != 0)
				{
					num6 = num4;
				}
				string[] array2 = new string[num6];
				for (int j = 0; j < num6; j++)
				{
					num5 = i * num2 + j;
					array2[j] = lstMobile[num5];
				}
				string[] array3 = new string[array2.Length];
				for (int k = 0; k < array3.Length; k++)
				{
					array3[k] = sIdTemp.ToString();
					sIdTemp++;
				}
				int num7 = 0;
				string text2 = "";
				for (int l = 0; l < array2.Length; l++)
				{
					text2 = text2 + array2[l] + ",";
				}
				if (text2.EndsWith(","))
				{
					text2 = text2.TrimEnd(new char[1] { ',' });
				}
				string text3 = "";
				for (int m = 0; m < array3.Length; m++)
				{
					text3 = text3 + array3[m] + ",";
				}
				if (text3.EndsWith(","))
				{
					text3 = text3.TrimEnd(new char[1] { ',' });
				}
				_ = smsSettingInfoViewModel.SmsWsUserName;
				string text4 = smsSettingInfoViewModel.SmsWsPassword;
				if (smsIsSendByOtherAccount && !string.IsNullOrWhiteSpace(smsWebServiceUserName) && !string.IsNullOrWhiteSpace(smsWebServicePassword))
				{
					text4 = smsWebServicePassword;
				}
				HttpClient httpClient = new HttpClient();
				string text5 = $"https://smsplus.ir/API/V1.0.0/Send.ashx?privateKey={text4}&number={fromNumber}&text={body}&isFlash={flag.ToString()}&udh={text}&mobiles={text2}&clientIDs={text3}";
				httpClient.BaseAddress = new Uri(text5);
				HttpResponseMessage result2 = httpClient.GetAsync(text5).Result;
				if (result2.IsSuccessStatusCode)
				{
					SmsPlusSendResponseViewModel smsPlusSendResponseViewModel = JsonConvert.DeserializeObject<SmsPlusSendResponseViewModel>(result2.Content.ReadAsStringAsync().Result);
					if (smsPlusSendResponseViewModel != null)
					{
						if (smsPlusSendResponseViewModel.Error == null)
						{
							if (smsPlusSendResponseViewModel.ServerIDs != null && smsPlusSendResponseViewModel.ServerIDs.Length != 0)
							{
								long[] serverIDs = smsPlusSendResponseViewModel.ServerIDs;
								if (Enumerable.Any<long>((IEnumerable<long>)serverIDs))
								{
									for (int n = 0; n < serverIDs.Length; n++)
									{
										num5 = i * num2 + n;
										array[num5] = serverIDs[n];
										num7++;
									}
								}
								else
								{
									array[0] = -5000L;
								}
							}
							else
							{
								array[0] = -5000L;
							}
						}
						else
						{
							array[0] = -5000L;
							msgError = ((!string.IsNullOrEmpty(smsPlusSendResponseViewModel.Error.Message)) ? (smsPlusSendResponseViewModel.Error.Message + " Code = " + smsPlusSendResponseViewModel.Error.Id) : Messages.msgErrorRunFunction);
						}
					}
					else
					{
						array[0] = -5000L;
						msgError = Messages.msgErrorRunFunction;
					}
				}
				else
				{
					array[0] = -5000L;
					msgError = Messages.msgErrorRunFunction;
				}
			}
			if (array != null)
			{
				result = new long[num];
				result = array;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result[0] = -5000L;
			msgError = ex.Message;
		}
	}

	public void SmsPlus_SendSms(string numbers, string body, int cmessage, string fromNumber, ref int sIdTemp, ref string msgError, ref string result, int smsProviderId = 0)
	{
		result = "0";
		try
		{
			sIdTemp = ReturnSid();
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			bool flag = cmessage == 3;
			string text = "";
			string[] array = numbers.Split(new char[1] { ',' });
			int num = array.Length;
			long[] array2 = new long[num];
			int num2 = 128;
			int num3 = num / num2;
			int num4 = num % num2;
			int num5 = 0;
			int num6 = num2;
			if (num4 != 0)
			{
				num3++;
			}
			for (int i = 0; i < num3; i++)
			{
				Thread.Sleep(3000);
				if (i == num3 - 1 && num4 != 0)
				{
					num6 = num4;
				}
				string[] array3 = new string[num6];
				for (int j = 0; j < num6; j++)
				{
					num5 = i * num2 + j;
					array3[j] = array[num5];
				}
				string[] array4 = new string[array3.Length];
				for (int k = 0; k < array4.Length; k++)
				{
					array4[k] = sIdTemp.ToString();
					sIdTemp++;
				}
				int num7 = 0;
				string text2 = "";
				for (int l = 0; l < array3.Length; l++)
				{
					text2 = text2 + array3[l] + ",";
				}
				if (text2.EndsWith(","))
				{
					text2 = text2.TrimEnd(new char[1] { ',' });
				}
				string text3 = "";
				for (int m = 0; m < array4.Length; m++)
				{
					text3 = text3 + array4[m] + ",";
				}
				if (text3.EndsWith(","))
				{
					text3 = text3.TrimEnd(new char[1] { ',' });
				}
				HttpClient httpClient = new HttpClient();
				string text4 = $"https://smsplus.ir/API/V1.0.0/Send.ashx?privateKey={smsSettingInfoViewModel.SmsWsPassword}&number={fromNumber}&text={body}&isFlash={flag.ToString()}&udh={text}&mobiles={text2}&clientIDs={text3}";
				httpClient.BaseAddress = new Uri(text4);
				HttpResponseMessage result2 = httpClient.GetAsync(text4).Result;
				if (result2.IsSuccessStatusCode)
				{
					SmsPlusSendResponseViewModel smsPlusSendResponseViewModel = JsonConvert.DeserializeObject<SmsPlusSendResponseViewModel>(result2.Content.ReadAsStringAsync().Result);
					if (smsPlusSendResponseViewModel != null)
					{
						if (smsPlusSendResponseViewModel.Error == null)
						{
							if (smsPlusSendResponseViewModel.ServerIDs != null && smsPlusSendResponseViewModel.ServerIDs.Length != 0)
							{
								long[] serverIDs = smsPlusSendResponseViewModel.ServerIDs;
								if (Enumerable.Any<long>((IEnumerable<long>)serverIDs))
								{
									for (int n = 0; n < serverIDs.Length; n++)
									{
										num5 = i * num2 + n;
										array2[num5] = serverIDs[n];
										num7++;
									}
								}
								else
								{
									array2[0] = -5000L;
								}
							}
							else
							{
								array2[0] = -5000L;
							}
						}
						else
						{
							array2[0] = -5000L;
							msgError = ((!string.IsNullOrEmpty(smsPlusSendResponseViewModel.Error.Message)) ? (smsPlusSendResponseViewModel.Error.Message + " Code = " + smsPlusSendResponseViewModel.Error.Id) : Messages.msgErrorRunFunction);
						}
					}
					else
					{
						array2[0] = -5000L;
						msgError = Messages.msgErrorRunFunction;
					}
				}
				else
				{
					array2[0] = -5000L;
					msgError = Messages.msgErrorRunFunction;
				}
			}
			if (array2 == null || array2[0] < 0)
			{
				result = "-5000";
				return;
			}
			for (int num8 = 0; num8 < array2.Length; num8++)
			{
				result = result + array2[num8] + ",";
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = "-5000";
			msgError = ex.Message;
		}
	}

	public void SmsPlus_GetDelivery(long[] refIdArr, ref int[] result, ref string msgError, int smsProviderId = 0)
	{
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			result = new int[Enumerable.Count<long>((IEnumerable<long>)refIdArr)];
			result[0] = -7;
			if (smsSettingInfoViewModel == null)
			{
				return;
			}
			int num = refIdArr.Length;
			_ = new int[num];
			int num2 = 128;
			int num3 = num / num2;
			int num4 = num % num2;
			int num5 = 0;
			int num6 = num2;
			if (num4 != 0)
			{
				num3++;
			}
			for (int i = 0; i < num3; i++)
			{
				Thread.Sleep(3000);
				if (i == num3 - 1 && num4 != 0)
				{
					num6 = num4;
				}
				long[] array = new long[num6];
				for (int j = 0; j < num6; j++)
				{
					num5 = i * num2 + j;
					array[j] = refIdArr[num5];
				}
				string text = "";
				for (int k = 0; k < array.Length; k++)
				{
					text = text + array[k] + ",";
				}
				if (text.EndsWith(","))
				{
					text = text.TrimEnd(new char[1] { ',' });
				}
				HttpClient httpClient = new HttpClient();
				string text2 = $"https://smsplus.ir/API/V1.0.0/GetStatus.ashx?privateKey={smsSettingInfoViewModel.SmsWsPassword}&serverIDs={text}";
				httpClient.BaseAddress = new Uri(text2);
				HttpResponseMessage result2 = httpClient.GetAsync(text2).Result;
				if (result2.IsSuccessStatusCode)
				{
					SmsPlusGetStatusResponseViewModel smsPlusGetStatusResponseViewModel = JsonConvert.DeserializeObject<SmsPlusGetStatusResponseViewModel>(result2.Content.ReadAsStringAsync().Result);
					if (smsPlusGetStatusResponseViewModel != null)
					{
						if (smsPlusGetStatusResponseViewModel.Error == null)
						{
							if (smsPlusGetStatusResponseViewModel.StatusList == null || smsPlusGetStatusResponseViewModel.StatusList.Length == 0)
							{
								continue;
							}
							int[] statusList = smsPlusGetStatusResponseViewModel.StatusList;
							if (!Enumerable.Any<int>((IEnumerable<int>)statusList))
							{
								continue;
							}
							for (int l = 0; l < statusList.Length; l++)
							{
								num5 = i * num2 + l;
								if (statusList[l] == -4 || statusList[l] == -3)
								{
									result[num5] = 0;
								}
								else if (statusList[l] == -2 || statusList[l] == 0)
								{
									result[num5] = 8;
								}
								else if (statusList[l] == 2)
								{
									result[num5] = 2;
								}
								else if (statusList[l] == 5)
								{
									result[num5] = 16;
								}
								else if (statusList[l] == 9)
								{
									result[num5] = 4;
								}
								else
								{
									result[num5] = statusList[l];
								}
							}
						}
						else
						{
							msgError = ((!string.IsNullOrEmpty(smsPlusGetStatusResponseViewModel.Error.Message)) ? (smsPlusGetStatusResponseViewModel.Error.Message + " Code = " + smsPlusGetStatusResponseViewModel.Error.Id) : Messages.msgErrorRunFunction);
						}
					}
					else
					{
						msgError = Messages.msgErrorRunFunction;
					}
				}
				else
				{
					msgError = Messages.msgErrorRunFunction;
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
		}
	}

	public void SmsPlus_GetCredit(ref decimal credit, ref string msgError, int smsProviderId = 0)
	{
		credit = default(decimal);
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			if (smsSettingInfoViewModel == null)
			{
				return;
			}
			HttpClient httpClient = new HttpClient();
			string text = $"https://smsplus.ir/API/V1.0.0/GetInfo.ashx?privateKey={smsSettingInfoViewModel.SmsWsPassword}";
			httpClient.BaseAddress = new Uri(text);
			HttpResponseMessage result = httpClient.GetAsync(text).Result;
			if (result.IsSuccessStatusCode)
			{
				SmsPlusGetInfoResponseViewModel smsPlusGetInfoResponseViewModel = JsonConvert.DeserializeObject<SmsPlusGetInfoResponseViewModel>(result.Content.ReadAsStringAsync().Result);
				if (smsPlusGetInfoResponseViewModel != null)
				{
					if (smsPlusGetInfoResponseViewModel.Error == null)
					{
						decimal.TryParse(smsPlusGetInfoResponseViewModel.Credit.ToString(), out credit);
						return;
					}
					credit = default(decimal);
					msgError = ((!string.IsNullOrEmpty(smsPlusGetInfoResponseViewModel.Error.Message)) ? (smsPlusGetInfoResponseViewModel.Error.Message + " Code = " + smsPlusGetInfoResponseViewModel.Error.Id) : Messages.msgErrorRunFunction);
				}
				else
				{
					credit = default(decimal);
					msgError = Messages.ErrorInformation;
				}
			}
			else
			{
				credit = default(decimal);
				msgError = Messages.ErrorInformation;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
			credit = default(decimal);
		}
	}

	public List<SmsPlusReceiveObjSMSInResponseViewModel> SmsPlus_ReceiveSms(int smsProviderId = 0)
	{
		List<SmsPlusReceiveObjSMSInResponseViewModel> list = new List<SmsPlusReceiveObjSMSInResponseViewModel>();
		CRMEntities cRMEntities = new CRMEntities();
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			if (smsSettingInfoViewModel != null)
			{
				bool flag = true;
				while (flag)
				{
					long result = 0L;
					MobspSelectLastSmsReceive_Result mobspSelectLastSmsReceive_Result = Enumerable.FirstOrDefault<MobspSelectLastSmsReceive_Result>((IEnumerable<MobspSelectLastSmsReceive_Result>)cRMEntities.MobspSelectLastSmsReceive());
					if (mobspSelectLastSmsReceive_Result != null)
					{
						long.TryParse(mobspSelectLastSmsReceive_Result.GetId, out result);
					}
					HttpClient httpClient = new HttpClient();
					string text = $"https://smsplus.ir/API/V1.0.0/Receive.ashx?privateKey={smsSettingInfoViewModel.SmsWsPassword}&lastID={result.ToString()}&rowCount=128";
					httpClient.BaseAddress = new Uri(text);
					HttpResponseMessage result2 = httpClient.GetAsync(text).Result;
					if (result2.IsSuccessStatusCode)
					{
						SmsPlusReceiveResponseViewModel smsPlusReceiveResponseViewModel = JsonConvert.DeserializeObject<SmsPlusReceiveResponseViewModel>(result2.Content.ReadAsStringAsync().Result);
						if (smsPlusReceiveResponseViewModel != null)
						{
							if (smsPlusReceiveResponseViewModel.Error == null)
							{
								if (smsPlusReceiveResponseViewModel.SMSReceived != null && Enumerable.Any<SmsPlusReceiveObjSMSInResponseViewModel>((IEnumerable<SmsPlusReceiveObjSMSInResponseViewModel>)smsPlusReceiveResponseViewModel.SMSReceived))
								{
									list.AddRange(smsPlusReceiveResponseViewModel.SMSReceived);
								}
								else
								{
									flag = false;
								}
							}
							else
							{
								flag = false;
								string message = ((!string.IsNullOrEmpty(smsPlusReceiveResponseViewModel.Error.Message)) ? (smsPlusReceiveResponseViewModel.Error.Message + " Code = " + smsPlusReceiveResponseViewModel.Error.Id) : Messages.msgErrorRunFunction);
								Exception innerException = new Exception();
								Exception e = new Exception(message, innerException);
								ErrorSignal.FromCurrentContext().Raise(e);
							}
						}
						else
						{
							flag = false;
							string msgErrorRunFunction = Messages.msgErrorRunFunction;
							Exception innerException2 = new Exception();
							Exception e2 = new Exception(msgErrorRunFunction, innerException2);
							ErrorSignal.FromCurrentContext().Raise(e2);
						}
					}
					else
					{
						flag = false;
						string msgErrorRunFunction2 = Messages.msgErrorRunFunction;
						Exception innerException3 = new Exception();
						Exception e3 = new Exception(msgErrorRunFunction2, innerException3);
						ErrorSignal.FromCurrentContext().Raise(e3);
					}
				}
			}
		}
		catch (Exception e4)
		{
			ErrorSignal.FromCurrentContext().Raise(e4);
		}
		finally
		{
			cRMEntities.Dispose();
		}
		return list;
	}

	public void SmsBimehParsian_SendSms1To1(string[] lstMobile, string[] body, string companiesId, string companyPersonsId, ref string msgError, ref long[] result, bool smsIsSendByOtherAccount = false, string smsWebServiceUserName = "", string smsWebServicePassword = "", int smsProviderId = 0, int? cId = null)
	{
		CRM.OtherWebServices.SmsBParsian.ServiceSoapClient serviceSoapClient = new CRM.OtherWebServices.SmsBParsian.ServiceSoapClient();
		result = new long[1];
		msgError = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			SmsSettingInfoViewModel smsSettingInfoViewModel = SmsSeting.Get();
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out var _);
			}
			string[] array = new string[lstMobile.Length];
			string[] array2 = new string[lstMobile.Length];
			if (!string.IsNullOrWhiteSpace(companiesId))
			{
				array = companiesId.Split(new char[1] { ',' });
			}
			if (!string.IsNullOrWhiteSpace(companyPersonsId))
			{
				array2 = companyPersonsId.Split(new char[1] { ',' });
			}
			if (lstMobile == null || lstMobile.Length == 0)
			{
				return;
			}
			for (int i = 0; i < lstMobile.Length; i++)
			{
				string firstName = "1";
				string lastName = "1";
				CRMEntities cRMEntities = new CRMEntities();
				try
				{
					if (array != null && array.Length != 0 && array2 != null && array2.Length != 0 && array.Length == lstMobile.Length && array2.Length == lstMobile.Length)
					{
						int result3 = 0;
						int.TryParse(array2[i], out result3);
						if (result3 > 0)
						{
							MobspSelectCompanyPersonsByID_Result mobspSelectCompanyPersonsByID_Result = Enumerable.FirstOrDefault<MobspSelectCompanyPersonsByID_Result>((IEnumerable<MobspSelectCompanyPersonsByID_Result>)cRMEntities.MobspSelectCompanyPersonsByID(result3, lCID, result2, cId));
							if (mobspSelectCompanyPersonsByID_Result != null)
							{
								firstName = mobspSelectCompanyPersonsByID_Result.prsFName ?? "";
								lastName = mobspSelectCompanyPersonsByID_Result.prsLName ?? "";
							}
						}
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
				finally
				{
					cRMEntities.Dispose();
				}
				string cellPhone = lstMobile[i];
				string policyID = "1";
				int appName = 31;
				string sMSText = body[i];
				string userName = smsSettingInfoViewModel.SmsWsUserName;
				string passwrd = smsSettingInfoViewModel.SmsWsPassword;
				if (smsIsSendByOtherAccount && !string.IsNullOrWhiteSpace(smsWebServiceUserName) && !string.IsNullOrWhiteSpace(smsWebServicePassword))
				{
					userName = smsWebServiceUserName;
					passwrd = smsWebServicePassword;
				}
				string s = serviceSoapClient.InsertSMS(userName, passwrd, firstName, lastName, cellPhone, sMSText, "", policyID, appName);
				long result4 = 0L;
				long.TryParse(s, out result4);
				if (result4 < 0)
				{
					result[0] = -5000L;
				}
				else
				{
					result[i] = 1L;
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

	public void SmsBimehParsian_SendSms(string numbers, string body, ref string msgError, ref string result, int smsProviderId = 0)
	{
		msgError = "";
		result = "0";
		try
		{
			CRM.OtherWebServices.SmsBParsian.ServiceSoapClient serviceSoapClient = new CRM.OtherWebServices.SmsBParsian.ServiceSoapClient();
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			SmsSettingInfoViewModel smsSettingInfoViewModel = SmsSeting.Get();
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out var _);
			}
			string[] array = numbers.Split(new char[1] { ',' });
			string text = "";
			if (array != null && array.Length != 0)
			{
				for (int i = 0; i < array.Length; i++)
				{
					string firstName = "1";
					string lastName = "1";
					string cellPhone = array[i];
					string policyID = "1";
					int appName = 31;
					string s = serviceSoapClient.InsertSMS(smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, firstName, lastName, cellPhone, body, "", policyID, appName);
					long result3 = 0L;
					long.TryParse(s, out result3);
					if (result3 < 0)
					{
						result = "-5000";
					}
					else
					{
						text += "1,";
					}
				}
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				result = text;
			}
			else
			{
				result = "-5000";
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = "-5000";
			msgError = ex.Message;
		}
	}

	public void ISms_SendSms1To1(string[] lstMobile, string body, int cmessage, string fromNumber, ref int sIdTemp, ref string msgError, ref long[] result, bool smsIsSendByOtherAccount = false, string smsWebServiceUserName = "", string smsWebServicePassword = "", int smsProviderId = 0)
	{
		result = new long[1];
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			_ = 3;
			int num = lstMobile.Length;
			long[] array = new long[num];
			int num2 = 1000;
			int num3 = num / num2;
			int num4 = num % num2;
			int num5 = 0;
			int num6 = num2;
			if (num4 != 0)
			{
				num3++;
			}
			for (int i = 0; i < num3; i++)
			{
				Thread.Sleep(3000);
				if (i == num3 - 1 && num4 != 0)
				{
					num6 = num4;
				}
				string[] array2 = new string[num6];
				for (int j = 0; j < num6; j++)
				{
					num5 = i * num2 + j;
					array2[j] = lstMobile[num5];
				}
				string[] array3 = new string[array2.Length];
				for (int k = 0; k < array3.Length; k++)
				{
					array3[k] = sIdTemp.ToString();
					sIdTemp++;
				}
				int num7 = 0;
				string text = "";
				for (int l = 0; l < array2.Length; l++)
				{
					text = text + array2[l] + ",";
				}
				if (text.EndsWith(","))
				{
					text = text.TrimEnd(new char[1] { ',' });
				}
				string text2 = "";
				for (int m = 0; m < array3.Length; m++)
				{
					text2 = text2 + array3[m] + ",";
				}
				if (text2.EndsWith(","))
				{
					text2 = text2.TrimEnd(new char[1] { ',' });
				}
				string text3 = "";
				for (int n = 0; n < array2.Length; n++)
				{
					text3 = text3 + "&mobiles[]=" + array2[n];
				}
				if (text3.EndsWith("&"))
				{
					text3 = text3.TrimEnd(new char[1] { '&' });
				}
				string text4 = smsSettingInfoViewModel.SmsWsUserName;
				string text5 = smsSettingInfoViewModel.SmsWsPassword;
				if (smsIsSendByOtherAccount && !string.IsNullOrWhiteSpace(smsWebServiceUserName) && !string.IsNullOrWhiteSpace(smsWebServicePassword))
				{
					text4 = smsWebServiceUserName;
					text5 = smsWebServicePassword;
				}
				HttpClient httpClient = new HttpClient();
				string text6 = $"http://ws3584.isms.ir/sendWS?username={text4}&password={text5}{text3}&body={body}&sender={fromNumber}";
				httpClient.BaseAddress = new Uri(text6);
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpContent content = new StringContent("[]", Encoding.UTF8, "application/json");
				HttpResponseMessage result2 = httpClient.PostAsync(text6, content).Result;
				ISmsSendResponseViewModel smsSendResponseViewModel;
				long result3;
				if (result2.IsSuccessStatusCode)
				{
					smsSendResponseViewModel = JsonConvert.DeserializeObject<ISmsSendResponseViewModel>(result2.Content.ReadAsStringAsync().Result);
					if (smsSendResponseViewModel != null)
					{
						if (smsSendResponseViewModel.code.HasValue)
						{
							result3 = 0L;
							long.TryParse(smsSendResponseViewModel.code.ToString(), out result3);
							long num8 = result3;
							if ((ulong)num8 > 14uL)
							{
								goto IL_03b6;
							}
							switch (num8)
							{
							case 0L:
								break;
							case 1L:
								goto IL_0348;
							case 2L:
								goto IL_0352;
							case 3L:
								goto IL_035c;
							case 4L:
								goto IL_0366;
							case 5L:
								goto IL_0370;
							case 6L:
								goto IL_037a;
							case 7L:
								goto IL_0384;
							case 11L:
								goto IL_038e;
							case 12L:
								goto IL_0398;
							case 13L:
								goto IL_03a2;
							case 14L:
								goto IL_03ac;
							default:
								goto IL_03b6;
							}
							msgError = Messages.msgErrorISmsHttpPost;
							goto IL_03c9;
						}
						if (smsSendResponseViewModel.ids != null && smsSendResponseViewModel.ids.Length != 0)
						{
							long[] ids = smsSendResponseViewModel.ids;
							if (Enumerable.Any<long>((IEnumerable<long>)ids))
							{
								for (int num9 = 0; num9 < ids.Length; num9++)
								{
									num5 = i * num2 + num9;
									array[num5] = ids[num9];
									num7++;
								}
							}
							else
							{
								array[0] = -5000L;
							}
						}
						else
						{
							array[0] = -5000L;
						}
						continue;
					}
					array[0] = -5000L;
					msgError = Messages.msgErrorRunFunction;
					continue;
				}
				array[0] = -5000L;
				msgError = Messages.msgErrorRunFunction;
				continue;
				IL_03c9:
				array[0] = -5000L;
				msgError = ((!string.IsNullOrWhiteSpace(msgError)) ? (msgError + " Code = " + result3) : Messages.msgErrorRunFunction);
				continue;
				IL_035c:
				msgError = Messages.msgErrorISmsUsernamePasswordInvalid;
				goto IL_03c9;
				IL_03ac:
				msgError = Messages.msgErrorISmsNumberNotActive;
				goto IL_03c9;
				IL_03b6:
				msgError = smsSendResponseViewModel.message ?? "";
				goto IL_03c9;
				IL_0398:
				msgError = Messages.msgErrorISmsNumberNotValid;
				goto IL_03c9;
				IL_03a2:
				msgError = Messages.msgErrorISmsDefaultNumNotSet;
				goto IL_03c9;
				IL_0384:
				msgError = Messages.msgErrorISmsCalledServiceWithoutEnoughDelay;
				goto IL_03c9;
				IL_037a:
				msgError = Messages.msgErrorISmsTotalAccountNotEnough;
				goto IL_03c9;
				IL_0370:
				msgError = Messages.msgErrorISmsIpForbidden;
				goto IL_03c9;
				IL_038e:
				msgError = Messages.msgErrorISmsSenderNotValid;
				goto IL_03c9;
				IL_0352:
				msgError = Messages.msgErrorISmsMobArrayLength;
				goto IL_03c9;
				IL_0366:
				msgError = Messages.msgErrorISmsWebServiceNotActive;
				goto IL_03c9;
				IL_0348:
				msgError = Messages.msgErrorISmsMobMustArray;
				goto IL_03c9;
			}
			if (array != null)
			{
				result = new long[num];
				result = array;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result[0] = -5000L;
			msgError = ex.Message;
		}
	}

	public void ISms_SendSms(string numbers, string body, int cmessage, string fromNumber, ref int sIdTemp, ref string msgError, ref string result, int smsProviderId = 0)
	{
		result = "0";
		try
		{
			sIdTemp = ReturnSid();
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			_ = 3;
			string[] array = numbers.Split(new char[1] { ',' });
			int num = array.Length;
			long[] array2 = new long[num];
			int num2 = 1000;
			int num3 = num / num2;
			int num4 = num % num2;
			int num5 = 0;
			int num6 = num2;
			if (num4 != 0)
			{
				num3++;
			}
			for (int i = 0; i < num3; i++)
			{
				Thread.Sleep(3000);
				if (i == num3 - 1 && num4 != 0)
				{
					num6 = num4;
				}
				string[] array3 = new string[num6];
				for (int j = 0; j < num6; j++)
				{
					num5 = i * num2 + j;
					array3[j] = array[num5];
				}
				string[] array4 = new string[array3.Length];
				for (int k = 0; k < array4.Length; k++)
				{
					array4[k] = sIdTemp.ToString();
					sIdTemp++;
				}
				int num7 = 0;
				string text = "";
				for (int l = 0; l < array3.Length; l++)
				{
					text = text + array3[l] + ",";
				}
				if (text.EndsWith(","))
				{
					text = text.TrimEnd(new char[1] { ',' });
				}
				string text2 = "";
				for (int m = 0; m < array4.Length; m++)
				{
					text2 = text2 + array4[m] + ",";
				}
				if (text2.EndsWith(","))
				{
					text2 = text2.TrimEnd(new char[1] { ',' });
				}
				string text3 = "";
				for (int n = 0; n < array3.Length; n++)
				{
					text3 = text3 + "&mobiles[]=" + array3[n];
				}
				if (text3.EndsWith("&"))
				{
					text3 = text3.TrimEnd(new char[1] { '&' });
				}
				HttpClient httpClient = new HttpClient();
				string text4 = $"http://ws3584.isms.ir/sendWS?username={smsSettingInfoViewModel.SmsWsUserName}&password={smsSettingInfoViewModel.SmsWsPassword}{text3}&body={body}&sender={fromNumber}";
				httpClient.BaseAddress = new Uri(text4);
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpContent content = new StringContent("[]", Encoding.UTF8, "application/json");
				HttpResponseMessage result2 = httpClient.PostAsync(text4, content).Result;
				ISmsSendResponseViewModel smsSendResponseViewModel;
				long result3;
				if (result2.IsSuccessStatusCode)
				{
					smsSendResponseViewModel = JsonConvert.DeserializeObject<ISmsSendResponseViewModel>(result2.Content.ReadAsStringAsync().Result);
					if (smsSendResponseViewModel != null)
					{
						if (smsSendResponseViewModel.code.HasValue)
						{
							result3 = 0L;
							long.TryParse(smsSendResponseViewModel.code.ToString(), out result3);
							long num8 = result3;
							if ((ulong)num8 > 14uL)
							{
								goto IL_039a;
							}
							switch (num8)
							{
							case 0L:
								break;
							case 1L:
								goto IL_032c;
							case 2L:
								goto IL_0336;
							case 3L:
								goto IL_0340;
							case 4L:
								goto IL_034a;
							case 5L:
								goto IL_0354;
							case 6L:
								goto IL_035e;
							case 7L:
								goto IL_0368;
							case 11L:
								goto IL_0372;
							case 12L:
								goto IL_037c;
							case 13L:
								goto IL_0386;
							case 14L:
								goto IL_0390;
							default:
								goto IL_039a;
							}
							msgError = Messages.msgErrorISmsHttpPost;
							goto IL_03ad;
						}
						if (smsSendResponseViewModel.ids != null && smsSendResponseViewModel.ids.Length != 0)
						{
							long[] ids = smsSendResponseViewModel.ids;
							if (Enumerable.Any<long>((IEnumerable<long>)ids))
							{
								for (int num9 = 0; num9 < ids.Length; num9++)
								{
									num5 = i * num2 + num9;
									array2[num5] = ids[num9];
									num7++;
								}
							}
							else
							{
								array2[0] = -5000L;
							}
						}
						else
						{
							array2[0] = -5000L;
						}
						continue;
					}
					array2[0] = -5000L;
					msgError = Messages.msgErrorRunFunction;
					continue;
				}
				array2[0] = -5000L;
				msgError = Messages.msgErrorRunFunction;
				continue;
				IL_037c:
				msgError = Messages.msgErrorISmsNumberNotValid;
				goto IL_03ad;
				IL_0372:
				msgError = Messages.msgErrorISmsSenderNotValid;
				goto IL_03ad;
				IL_0368:
				msgError = Messages.msgErrorISmsCalledServiceWithoutEnoughDelay;
				goto IL_03ad;
				IL_0386:
				msgError = Messages.msgErrorISmsDefaultNumNotSet;
				goto IL_03ad;
				IL_0354:
				msgError = Messages.msgErrorISmsIpForbidden;
				goto IL_03ad;
				IL_035e:
				msgError = Messages.msgErrorISmsTotalAccountNotEnough;
				goto IL_03ad;
				IL_034a:
				msgError = Messages.msgErrorISmsWebServiceNotActive;
				goto IL_03ad;
				IL_0336:
				msgError = Messages.msgErrorISmsMobArrayLength;
				goto IL_03ad;
				IL_032c:
				msgError = Messages.msgErrorISmsMobMustArray;
				goto IL_03ad;
				IL_03ad:
				array2[0] = -5000L;
				msgError = ((!string.IsNullOrWhiteSpace(msgError)) ? (msgError + " Code = " + result3) : Messages.msgErrorRunFunction);
				continue;
				IL_039a:
				msgError = smsSendResponseViewModel.message ?? "";
				goto IL_03ad;
				IL_0340:
				msgError = Messages.msgErrorISmsUsernamePasswordInvalid;
				goto IL_03ad;
				IL_0390:
				msgError = Messages.msgErrorISmsNumberNotActive;
				goto IL_03ad;
			}
			if (array2 == null || array2[0] < 0)
			{
				result = "-5000";
				return;
			}
			for (int num10 = 0; num10 < array2.Length; num10++)
			{
				result = result + array2[num10] + ",";
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = "-5000";
			msgError = ex.Message;
		}
	}

	public void ISms_GetDelivery(long[] refIdArr, ref int[] result, ref string msgError, int smsProviderId = 0)
	{
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			result = new int[Enumerable.Count<long>((IEnumerable<long>)refIdArr)];
			result[0] = -7;
			if (smsSettingInfoViewModel == null)
			{
				return;
			}
			int num = refIdArr.Length;
			_ = new int[num];
			int num2 = 1000;
			int num3 = num / num2;
			int num4 = num % num2;
			int num5 = 0;
			int num6 = num2;
			if (num4 != 0)
			{
				num3++;
			}
			for (int i = 0; i < num3; i++)
			{
				Thread.Sleep(3000);
				if (i == num3 - 1 && num4 != 0)
				{
					num6 = num4;
				}
				long[] array = new long[num6];
				for (int j = 0; j < num6; j++)
				{
					num5 = i * num2 + j;
					array[j] = refIdArr[num5];
				}
				string text = "";
				for (int k = 0; k < array.Length; k++)
				{
					text = text + array[k] + ",";
				}
				if (text.EndsWith(","))
				{
					text = text.TrimEnd(new char[1] { ',' });
				}
				string text2 = "";
				for (int l = 0; l < array.Length; l++)
				{
					text2 = text2 + "&ids[]=" + array[l];
				}
				if (text2.EndsWith("&"))
				{
					text2 = text2.TrimEnd(new char[1] { '&' });
				}
				HttpClient httpClient = new HttpClient();
				string text3 = $"http://ws3584.isms.ir/reportWS?username={smsSettingInfoViewModel.SmsWsUserName}&password={smsSettingInfoViewModel.SmsWsPassword}{text2}";
				httpClient.BaseAddress = new Uri(text3);
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpContent content = new StringContent("[]", Encoding.UTF8, "application/json");
				HttpResponseMessage result2 = httpClient.PostAsync(text3, content).Result;
				string result3;
				ISmsGetReceiveResponseViewModel smsGetReceiveResponseViewModel;
				long result4;
				if (result2.IsSuccessStatusCode)
				{
					result3 = result2.Content.ReadAsStringAsync().Result;
					if (string.IsNullOrWhiteSpace(result3))
					{
						continue;
					}
					if (result3.IndexOf("{\"code\":", StringComparison.Ordinal) >= 0)
					{
						smsGetReceiveResponseViewModel = JsonConvert.DeserializeObject<ISmsGetReceiveResponseViewModel>(result3);
						if (smsGetReceiveResponseViewModel != null)
						{
							if (smsGetReceiveResponseViewModel.code.HasValue)
							{
								result4 = 0L;
								long.TryParse(smsGetReceiveResponseViewModel.code.ToString(), out result4);
								long num7 = result4;
								if ((ulong)num7 > 14uL)
								{
									goto IL_0307;
								}
								switch (num7)
								{
								case 0L:
									break;
								case 1L:
									goto IL_02a4;
								case 2L:
									goto IL_02ad;
								case 3L:
									goto IL_02b6;
								case 4L:
									goto IL_02bf;
								case 5L:
									goto IL_02c8;
								case 6L:
									goto IL_02d1;
								case 7L:
									goto IL_02da;
								case 11L:
									goto IL_02e3;
								case 12L:
									goto IL_02ec;
								case 13L:
									goto IL_02f5;
								case 14L:
									goto IL_02fe;
								default:
									goto IL_0307;
								}
								msgError = Messages.msgErrorISmsHttpPost;
								goto IL_0319;
							}
						}
						else
						{
							msgError = Messages.msgErrorRunFunction;
						}
					}
					goto IL_0347;
				}
				msgError = Messages.msgErrorRunFunction;
				continue;
				IL_02b6:
				msgError = Messages.msgErrorISmsUsernamePasswordInvalid;
				goto IL_0319;
				IL_02a4:
				msgError = Messages.msgErrorISmsMobMustArray;
				goto IL_0319;
				IL_0319:
				msgError = ((!string.IsNullOrWhiteSpace(msgError)) ? (msgError + " Code = " + result4) : Messages.msgErrorRunFunction);
				goto IL_0347;
				IL_02ad:
				msgError = Messages.msgErrorISmsMobArrayLength;
				goto IL_0319;
				IL_02bf:
				msgError = Messages.msgErrorISmsWebServiceNotActive;
				goto IL_0319;
				IL_0307:
				msgError = smsGetReceiveResponseViewModel.message ?? "";
				goto IL_0319;
				IL_0347:
				if (result3.IndexOf("{\"code\":", StringComparison.Ordinal) < 0)
				{
					if (string.IsNullOrWhiteSpace(result3))
					{
						continue;
					}
					string[] array2 = result3.Split(new string[1] { "}," }, StringSplitOptions.None);
					if (array2 == null || array2.Length == 0)
					{
						continue;
					}
					for (int m = 0; m < array.Length; m++)
					{
						num5 = i * num2 + m;
						string[] array3 = array2;
						foreach (string text4 in array3)
						{
							if (string.IsNullOrWhiteSpace(text4) || text4.IndexOf("\"" + array[m] + "\":", StringComparison.Ordinal) < 0)
							{
								continue;
							}
							string[] array4 = text4.Split(new string[1] { ",\"deliverdate\"" }, StringSplitOptions.None);
							if (!((array4 != null) & (array4.Length == 2)))
							{
								continue;
							}
							string[] array5 = array4[0].Split(new string[1] { "\"status\":" }, StringSplitOptions.None);
							if (array5 != null && array5.Length == 2 && !string.IsNullOrWhiteSpace(array5[1]))
							{
								int result5 = 0;
								int.TryParse(array5[1], out result5);
								switch (result5)
								{
								case -2:
									result[num5] = 1;
									break;
								case -3:
									result[num5] = 0;
									break;
								case 2:
									result[num5] = 2;
									break;
								default:
									result[num5] = result5;
									break;
								}
								break;
							}
						}
					}
				}
				else
				{
					msgError = Messages.msgErrorRunFunction;
				}
				continue;
				IL_02f5:
				msgError = Messages.msgErrorISmsDefaultNumNotSet;
				goto IL_0319;
				IL_02fe:
				msgError = Messages.msgErrorISmsNumberNotActive;
				goto IL_0319;
				IL_02ec:
				msgError = Messages.msgErrorISmsNumberNotValid;
				goto IL_0319;
				IL_02e3:
				msgError = Messages.msgErrorISmsSenderNotValid;
				goto IL_0319;
				IL_02d1:
				msgError = Messages.msgErrorISmsTotalAccountNotEnough;
				goto IL_0319;
				IL_02da:
				msgError = Messages.msgErrorISmsCalledServiceWithoutEnoughDelay;
				goto IL_0319;
				IL_02c8:
				msgError = Messages.msgErrorISmsIpForbidden;
				goto IL_0319;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
		}
	}

	public void ISms_GetCredit(ref decimal credit, ref string msgError, int smsProviderId = 0)
	{
		credit = default(decimal);
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			if (smsSettingInfoViewModel == null)
			{
				return;
			}
			HttpClient httpClient = new HttpClient();
			string text = $"http://ws3584.isms.ir/creditWS?username={smsSettingInfoViewModel.SmsWsUserName}&password={smsSettingInfoViewModel.SmsWsPassword}";
			httpClient.BaseAddress = new Uri(text);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			HttpContent content = new StringContent("[]", Encoding.UTF8, "application/json");
			HttpResponseMessage result = httpClient.PostAsync(text, content).Result;
			ISmsGetCreditResponseViewModel smsGetCreditResponseViewModel;
			long result2;
			if (result.IsSuccessStatusCode)
			{
				smsGetCreditResponseViewModel = JsonConvert.DeserializeObject<ISmsGetCreditResponseViewModel>(result.Content.ReadAsStringAsync().Result);
				if (smsGetCreditResponseViewModel != null)
				{
					if (smsGetCreditResponseViewModel.code.HasValue)
					{
						result2 = 0L;
						long.TryParse(smsGetCreditResponseViewModel.code.ToString(), out result2);
						long num = result2;
						if ((ulong)num > 14uL)
						{
							goto IL_01b9;
						}
						switch (num)
						{
						case 0L:
							break;
						case 1L:
							goto IL_0156;
						case 2L:
							goto IL_015f;
						case 3L:
							goto IL_0168;
						case 4L:
							goto IL_0171;
						case 5L:
							goto IL_017a;
						case 6L:
							goto IL_0183;
						case 7L:
							goto IL_018c;
						case 11L:
							goto IL_0195;
						case 12L:
							goto IL_019e;
						case 13L:
							goto IL_01a7;
						case 14L:
							goto IL_01b0;
						default:
							goto IL_01b9;
						}
						msgError = Messages.msgErrorISmsHttpPost;
						goto IL_01cb;
					}
					if (smsGetCreditResponseViewModel.credit.HasValue)
					{
						decimal.TryParse(smsGetCreditResponseViewModel.credit.ToString(), out credit);
						return;
					}
					credit = default(decimal);
					msgError = Messages.ErrorInformation;
					return;
				}
				credit = default(decimal);
				msgError = Messages.ErrorInformation;
				return;
			}
			credit = default(decimal);
			msgError = Messages.msgErrorRunFunction;
			return;
			IL_015f:
			msgError = Messages.msgErrorISmsMobArrayLength;
			goto IL_01cb;
			IL_0156:
			msgError = Messages.msgErrorISmsMobMustArray;
			goto IL_01cb;
			IL_0168:
			msgError = Messages.msgErrorISmsUsernamePasswordInvalid;
			goto IL_01cb;
			IL_017a:
			msgError = Messages.msgErrorISmsIpForbidden;
			goto IL_01cb;
			IL_0171:
			msgError = Messages.msgErrorISmsWebServiceNotActive;
			goto IL_01cb;
			IL_018c:
			msgError = Messages.msgErrorISmsCalledServiceWithoutEnoughDelay;
			goto IL_01cb;
			IL_0183:
			msgError = Messages.msgErrorISmsTotalAccountNotEnough;
			goto IL_01cb;
			IL_019e:
			msgError = Messages.msgErrorISmsNumberNotValid;
			goto IL_01cb;
			IL_01b9:
			msgError = smsGetCreditResponseViewModel.message ?? "";
			goto IL_01cb;
			IL_01cb:
			credit = default(decimal);
			msgError = ((!string.IsNullOrWhiteSpace(msgError)) ? (msgError + " Code = " + result2) : Messages.msgErrorRunFunction);
			return;
			IL_0195:
			msgError = Messages.msgErrorISmsSenderNotValid;
			goto IL_01cb;
			IL_01a7:
			msgError = Messages.msgErrorISmsDefaultNumNotSet;
			goto IL_01cb;
			IL_01b0:
			msgError = Messages.msgErrorISmsNumberNotActive;
			goto IL_01cb;
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
			credit = default(decimal);
		}
	}

	public List<ISmsGetReceiveResponseViewModel> ISms_ReceiveSms(int smsProviderId = 0)
	{
		List<ISmsGetReceiveResponseViewModel> list = new List<ISmsGetReceiveResponseViewModel>();
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			string text = "";
			ISmsGetReceiveResponseViewModel smsGetReceiveResponseViewModel;
			long result3;
			ISmsGetReceiveResponseViewModel smsGetReceiveResponseViewModel2;
			long result4;
			if (smsSettingInfoViewModel != null)
			{
				HttpClient httpClient = new HttpClient();
				string text2 = $"http://ws3584.isms.ir/receiveWS?username={smsSettingInfoViewModel.SmsWsUserName}&password={smsSettingInfoViewModel.SmsWsPassword}";
				httpClient.BaseAddress = new Uri(text2);
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpContent content = new StringContent("[]", Encoding.UTF8, "application/json");
				HttpResponseMessage result = httpClient.PostAsync(text2, content).Result;
				if (result.IsSuccessStatusCode)
				{
					string result2 = result.Content.ReadAsStringAsync().Result;
					if (result2.IndexOf("{\"code\":", StringComparison.Ordinal) >= 0)
					{
						smsGetReceiveResponseViewModel = JsonConvert.DeserializeObject<ISmsGetReceiveResponseViewModel>(result2);
						if (smsGetReceiveResponseViewModel == null)
						{
							text = Messages.msgErrorRunFunction;
							Exception innerException = new Exception();
							Exception e = new Exception(text, innerException);
							ErrorSignal.FromCurrentContext().Raise(e);
							return list;
						}
						if (smsGetReceiveResponseViewModel.code.HasValue)
						{
							result3 = 0L;
							long.TryParse(smsGetReceiveResponseViewModel.code.ToString(), out result3);
							long num = result3;
							if ((ulong)num > 14uL)
							{
								goto IL_01c1;
							}
							switch (num)
							{
							case 0L:
								break;
							case 1L:
								goto IL_0169;
							case 2L:
								goto IL_0171;
							case 3L:
								goto IL_0179;
							case 4L:
								goto IL_0181;
							case 5L:
								goto IL_0189;
							case 6L:
								goto IL_0191;
							case 7L:
								goto IL_0199;
							case 11L:
								goto IL_01a1;
							case 12L:
								goto IL_01a9;
							case 13L:
								goto IL_01b1;
							case 14L:
								goto IL_01b9;
							default:
								goto IL_01c1;
							}
							text = Messages.msgErrorISmsHttpPost;
							goto IL_01d2;
						}
					}
					List<ISmsGetReceiveResponseViewModel> list2 = JsonConvert.DeserializeObject<List<ISmsGetReceiveResponseViewModel>>(result2);
					if (list2 != null)
					{
						smsGetReceiveResponseViewModel2 = Enumerable.FirstOrDefault<ISmsGetReceiveResponseViewModel>((IEnumerable<ISmsGetReceiveResponseViewModel>)list2);
						if (smsGetReceiveResponseViewModel2 != null && smsGetReceiveResponseViewModel2.code.HasValue)
						{
							result4 = 0L;
							long.TryParse(smsGetReceiveResponseViewModel2.code.ToString(), out result4);
							long num2 = result4;
							if ((ulong)num2 > 14uL)
							{
								goto IL_034d;
							}
							switch (num2)
							{
							case 0L:
								break;
							case 1L:
								goto IL_02f5;
							case 2L:
								goto IL_02fd;
							case 3L:
								goto IL_0305;
							case 4L:
								goto IL_030d;
							case 5L:
								goto IL_0315;
							case 6L:
								goto IL_031d;
							case 7L:
								goto IL_0325;
							case 11L:
								goto IL_032d;
							case 12L:
								goto IL_0335;
							case 13L:
								goto IL_033d;
							case 14L:
								goto IL_0345;
							default:
								goto IL_034d;
							}
							text = Messages.msgErrorISmsHttpPost;
							goto IL_035e;
						}
						if (Enumerable.Any<ISmsGetReceiveResponseViewModel>((IEnumerable<ISmsGetReceiveResponseViewModel>)list2))
						{
							foreach (ISmsGetReceiveResponseViewModel item in list2)
							{
								if (!item.code.HasValue)
								{
									list.Add(item);
								}
							}
						}
					}
					else
					{
						text = Messages.msgErrorRunFunction;
						Exception innerException2 = new Exception();
						Exception e2 = new Exception(text, innerException2);
						ErrorSignal.FromCurrentContext().Raise(e2);
					}
				}
				else
				{
					text = Messages.msgErrorRunFunction;
					Exception innerException3 = new Exception();
					Exception e3 = new Exception(text, innerException3);
					ErrorSignal.FromCurrentContext().Raise(e3);
				}
			}
			goto end_IL_0006;
			IL_0345:
			text = Messages.msgErrorISmsNumberNotActive;
			goto IL_035e;
			IL_033d:
			text = Messages.msgErrorISmsDefaultNumNotSet;
			goto IL_035e;
			IL_034d:
			text = smsGetReceiveResponseViewModel2.message ?? "";
			goto IL_035e;
			IL_0171:
			text = Messages.msgErrorISmsMobArrayLength;
			goto IL_01d2;
			IL_0169:
			text = Messages.msgErrorISmsMobMustArray;
			goto IL_01d2;
			IL_0181:
			text = Messages.msgErrorISmsWebServiceNotActive;
			goto IL_01d2;
			IL_01d2:
			text = ((!string.IsNullOrWhiteSpace(text)) ? (text + " Code = " + result3) : Messages.msgErrorRunFunction);
			Exception innerException4 = new Exception();
			Exception e4 = new Exception(text, innerException4);
			ErrorSignal.FromCurrentContext().Raise(e4);
			return list;
			IL_0189:
			text = Messages.msgErrorISmsIpForbidden;
			goto IL_01d2;
			IL_035e:
			text = ((!string.IsNullOrWhiteSpace(text)) ? (text + " Code = " + result4) : Messages.msgErrorRunFunction);
			Exception innerException5 = new Exception();
			Exception e5 = new Exception(text, innerException5);
			ErrorSignal.FromCurrentContext().Raise(e5);
			return list;
			IL_0199:
			text = Messages.msgErrorISmsCalledServiceWithoutEnoughDelay;
			goto IL_01d2;
			IL_0191:
			text = Messages.msgErrorISmsTotalAccountNotEnough;
			goto IL_01d2;
			IL_01a9:
			text = Messages.msgErrorISmsNumberNotValid;
			goto IL_01d2;
			IL_01a1:
			text = Messages.msgErrorISmsSenderNotValid;
			goto IL_01d2;
			IL_0179:
			text = Messages.msgErrorISmsUsernamePasswordInvalid;
			goto IL_01d2;
			IL_01b1:
			text = Messages.msgErrorISmsDefaultNumNotSet;
			goto IL_01d2;
			IL_01b9:
			text = Messages.msgErrorISmsNumberNotActive;
			goto IL_01d2;
			IL_01c1:
			text = smsGetReceiveResponseViewModel.message ?? "";
			goto IL_01d2;
			IL_02f5:
			text = Messages.msgErrorISmsMobMustArray;
			goto IL_035e;
			IL_02fd:
			text = Messages.msgErrorISmsMobArrayLength;
			goto IL_035e;
			IL_0305:
			text = Messages.msgErrorISmsUsernamePasswordInvalid;
			goto IL_035e;
			IL_030d:
			text = Messages.msgErrorISmsWebServiceNotActive;
			goto IL_035e;
			IL_0315:
			text = Messages.msgErrorISmsIpForbidden;
			goto IL_035e;
			IL_031d:
			text = Messages.msgErrorISmsTotalAccountNotEnough;
			goto IL_035e;
			IL_0325:
			text = Messages.msgErrorISmsCalledServiceWithoutEnoughDelay;
			goto IL_035e;
			IL_032d:
			text = Messages.msgErrorISmsSenderNotValid;
			goto IL_035e;
			IL_0335:
			text = Messages.msgErrorISmsNumberNotValid;
			goto IL_035e;
			end_IL_0006:;
		}
		catch (Exception e6)
		{
			ErrorSignal.FromCurrentContext().Raise(e6);
		}
		return list;
	}

	public void Nimaad_SendSms1To1(string[] lstMobile, string[] lstBody, int cmessage, string fromNumber, int[] lstTypeUnicodeMessage, string[] lstSchedulDate, ref int sIdTemp, ref string msgError, ref long[] lstGetId, ref long[] result, bool smsIsSendByOtherAccount = false, string smsWebServiceUserName = "", string smsWebServicePassword = "", int smsProviderId = 0)
	{
		CRM.OtherWebServices.SmsNimadd.SMSwsdlPortTypeClient sMSwsdlPortTypeClient = new CRM.OtherWebServices.SmsNimadd.SMSwsdlPortTypeClient();
		result = new long[1];
		result[0] = -7L;
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			sIdTemp = ReturnSid();
			SysSeting.Get();
			string username = smsSettingInfoViewModel.SmsWsUserName;
			string password = smsSettingInfoViewModel.SmsWsPassword;
			if (smsIsSendByOtherAccount && !string.IsNullOrWhiteSpace(smsWebServiceUserName) && !string.IsNullOrWhiteSpace(smsWebServicePassword))
			{
				username = smsWebServiceUserName;
				password = smsWebServicePassword;
			}
			int isflash = 1;
			if (cmessage == 3)
			{
				isflash = 2;
			}
			string text = "";
			for (int i = 0; i < lstMobile.Length; i++)
			{
				text = text + lstMobile[i] + ";";
			}
			if (text.EndsWith(";"))
			{
				text = text.TrimEnd(new char[1] { ';' });
			}
			string text2 = "";
			for (int j = 0; j < lstBody.Length; j++)
			{
				string text3 = lstBody[j];
				text3 = text3.Replace(";", " ");
				text2 = text2 + text3 + ";";
			}
			if (text2.EndsWith(";"))
			{
				text2 = text2.TrimEnd(new char[1] { ';' });
			}
			string text4 = sMSwsdlPortTypeClient.sendMultiSMS(smsSettingInfoViewModel.SmsWsDomainNamed, username, password, fromNumber, text, text2, isflash);
			int result2 = 0;
			int.TryParse(text4.ToString(), out result2);
			if (result2 <= 0)
			{
				switch (result2)
				{
				case -1:
				case 0:
					msgError = Messages.msgErrorNimaadSmsErrInSend;
					break;
				case -2:
					msgError = Messages.msgErrorNimaadSmsUserNameIsWrong;
					break;
				case -3:
					msgError = Messages.msgErrorNimaadSmsSenderNumberNotValid;
					break;
				case -4:
					msgError = Messages.msgErrorNimaadSmsCreditNotEnough;
					break;
				case -5:
					msgError = Messages.msgErrorNimaadSmsIsSendAfterConfirm;
					break;
				case -6:
					msgError = Messages.msgErrorNimaadSmsRecipientNumberNotCorrect;
					break;
				default:
					msgError = Messages.msgErrorNimaadSmsErrInSend;
					break;
				}
				result[0] = -5000L;
			}
			else
			{
				int num = lstMobile.Length;
				result = new long[num];
				for (int k = 0; k < num; k++)
				{
					result[k] = result2;
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

	public void Nimaad_SendSms(string numbers, string body, int cmessage, string fromNumber, ref int sIdTemp, ref string msgError, ref string result, int smsProviderId = 0)
	{
		msgError = "";
		result = "-7";
		try
		{
			CRM.OtherWebServices.SmsNimadd.SMSwsdlPortTypeClient sMSwsdlPortTypeClient = new CRM.OtherWebServices.SmsNimadd.SMSwsdlPortTypeClient();
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			sIdTemp = ReturnSid();
			int isflash = 1;
			if (cmessage == 3)
			{
				isflash = 2;
			}
			string[] array = numbers.Split(new char[1] { ',' });
			int num = array.Length;
			long[] array2 = new long[num];
			string text = "";
			for (int i = 0; i < array.Length; i++)
			{
				text = text + array[i] + ";";
			}
			if (text.EndsWith(";"))
			{
				text = text.TrimEnd(new char[1] { ';' });
			}
			string text2 = "";
			for (int j = 0; j < num; j++)
			{
				string text3 = body;
				text3 = text3.Replace(";", " ");
				text2 = text2 + text3 + ";";
			}
			if (text2.EndsWith(";"))
			{
				text2 = text2.TrimEnd(new char[1] { ';' });
			}
			string text4 = sMSwsdlPortTypeClient.sendMultiSMS(smsSettingInfoViewModel.SmsWsDomainNamed, smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, fromNumber, text, text2, isflash);
			int result2 = 0;
			int.TryParse(text4.ToString(), out result2);
			if (result2 <= 0)
			{
				switch (result2)
				{
				case -1:
				case 0:
					msgError = Messages.msgErrorNimaadSmsErrInSend;
					break;
				case -2:
					msgError = Messages.msgErrorNimaadSmsUserNameIsWrong;
					break;
				case -3:
					msgError = Messages.msgErrorNimaadSmsSenderNumberNotValid;
					break;
				case -4:
					msgError = Messages.msgErrorNimaadSmsCreditNotEnough;
					break;
				case -5:
					msgError = Messages.msgErrorNimaadSmsIsSendAfterConfirm;
					break;
				case -6:
					msgError = Messages.msgErrorNimaadSmsRecipientNumberNotCorrect;
					break;
				default:
					msgError = Messages.msgErrorNimaadSmsErrInSend;
					break;
				}
				result = "-50000";
			}
			else
			{
				for (int k = 0; k < array2.Length; k++)
				{
					array2[k] = result2;
				}
				result = "";
				for (int l = 0; l < array2.Length; l++)
				{
					result = result + array2[l] + ",";
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = "-50000";
			msgError = ex.Message;
		}
	}

	public void Nimaad_GetDelivery(long[] refIdArr, string[] mobArr, ref int[] result, ref string msgError, int smsProviderId = 0)
	{
		try
		{
			CRM.OtherWebServices.SmsNimadd.SMSwsdlPortTypeClient sMSwsdlPortTypeClient = new CRM.OtherWebServices.SmsNimadd.SMSwsdlPortTypeClient();
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			result = new int[Enumerable.Count<long>((IEnumerable<long>)refIdArr)];
			result[0] = -7;
			if (smsSettingInfoViewModel == null)
			{
				return;
			}
			List<CommonSelectListItemViewModel> list = new List<CommonSelectListItemViewModel>();
			for (int i = 0; i < refIdArr.Length; i++)
			{
				int id = 0;
				int.TryParse(refIdArr[i].ToString(), out id);
				if (id != 0)
				{
					bool flag = false;
					if (list != null && Enumerable.Any<CommonSelectListItemViewModel>((IEnumerable<CommonSelectListItemViewModel>)list) && Enumerable.FirstOrDefault<CommonSelectListItemViewModel>((IEnumerable<CommonSelectListItemViewModel>)list, (Func<CommonSelectListItemViewModel, bool>)((CommonSelectListItemViewModel m) => m.Id.GetValueOrDefault() == id)) != null)
					{
						flag = true;
					}
					if (!flag)
					{
						CommonSelectListItemViewModel item = new CommonSelectListItemViewModel
						{
							Id = id
						};
						list.Add(item);
					}
				}
			}
			if (list == null || !Enumerable.Any<CommonSelectListItemViewModel>((IEnumerable<CommonSelectListItemViewModel>)list))
			{
				return;
			}
			foreach (CommonSelectListItemViewModel item2 in list)
			{
				int result2 = 0;
				int.TryParse(item2.Id.ToString(), out result2);
				if (result2 == 0)
				{
					continue;
				}
				CRM.OtherWebServices.SmsNimadd.delivery[] deliveryMulti = sMSwsdlPortTypeClient.getDeliveryMulti(smsSettingInfoViewModel.SmsWsDomainNamed, smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, result2);
				if (deliveryMulti == null)
				{
					continue;
				}
				CRM.OtherWebServices.SmsNimadd.delivery[] array = deliveryMulti;
				foreach (CRM.OtherWebServices.SmsNimadd.delivery obj in array)
				{
					string text = obj.mobile ?? "";
					int status = obj.status;
					if (!string.IsNullOrWhiteSpace(text) && text.StartsWith("9"))
					{
						text = "0" + text;
					}
					for (int k = 0; k < refIdArr.Length; k++)
					{
						bool flag2 = false;
						string text2 = mobArr[k] ?? "";
						if (int.Parse(refIdArr[k].ToString()) == result2 && text == text2 && !flag2)
						{
							switch (status)
							{
							case 0:
							case 3:
								result[k] = -1;
								break;
							case 1:
								result[k] = 2;
								break;
							case 2:
								result[k] = 1;
								break;
							case 4:
								result[k] = 3;
								break;
							case 46:
								result[k] = 4;
								break;
							default:
								result[k] = status;
								break;
							}
							flag2 = true;
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
		}
	}

	public CRM.OtherWebServices.SmsNimadd.message[] Nimaad_GetMessage(int smsProviderId = 0)
	{
		CRM.OtherWebServices.SmsNimadd.message[] array = null;
		try
		{
			CRM.OtherWebServices.SmsNimadd.SMSwsdlPortTypeClient sMSwsdlPortTypeClient = new CRM.OtherWebServices.SmsNimadd.SMSwsdlPortTypeClient();
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			string messagesCount = sMSwsdlPortTypeClient.getMessagesCount(smsSettingInfoViewModel.SmsWsDomainNamed, smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, "2", smsSettingInfoViewModel.SmsWsFromNumber, "");
			long result = 0L;
			long.TryParse(messagesCount, out result);
			if (result > 0)
			{
				array = new CRM.OtherWebServices.SmsNimadd.message[result];
				long num = 500L;
				long num2 = result / num;
				long num3 = result % num;
				long num4 = 0L;
				long num5 = num;
				if (num3 != 0L)
				{
					num2++;
				}
				long num6 = 1L;
				for (int i = 0; i < num2; i++)
				{
					if (i == num2 - 1 && num3 != 0L)
					{
						num5 = num3;
					}
					CRM.OtherWebServices.SmsNimadd.message[] array2 = null;
					array2 = sMSwsdlPortTypeClient.getMessages(smsSettingInfoViewModel.SmsWsDomainNamed, smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, "2", num6.ToString(), num5.ToString(), smsSettingInfoViewModel.SmsWsFromNumber);
					if (array2 != null)
					{
						for (int j = 0; j < array2.Length; j++)
						{
							num4 = i * num + j;
							array[num4] = array2[j];
						}
						num6 = i * num + num;
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return array;
	}

	public void Nimaad_GetCredit(ref decimal credit, ref string msgError, int smsProviderId = 0)
	{
		CRM.OtherWebServices.SmsNimadd.SMSwsdlPortTypeClient sMSwsdlPortTypeClient = new CRM.OtherWebServices.SmsNimadd.SMSwsdlPortTypeClient();
		credit = default(decimal);
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			if (smsSettingInfoViewModel != null)
			{
				decimal.TryParse(sMSwsdlPortTypeClient.getCredit(smsSettingInfoViewModel.SmsWsDomainNamed, smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword), out credit);
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
			credit = default(decimal);
		}
	}

	public void FarazSms_SendSms1To1(string[] lstMobile, string body, int cmessage, string fromNumber, ref int sIdTemp, ref string msgError, ref long[] result, bool smsIsSendByOtherAccount = false, string smsWebServiceUserName = "", string smsWebServicePassword = "", int smsProviderId = 0)
	{
		result = new long[1];
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			_ = 3;
			int num = lstMobile.Length;
			long[] array = new long[num];
			int num2 = 1000;
			int num3 = num / num2;
			int num4 = num % num2;
			int num5 = 0;
			int num6 = num2;
			if (num4 != 0)
			{
				num3++;
			}
			for (int i = 0; i < num3; i++)
			{
				Thread.Sleep(3000);
				if (i == num3 - 1 && num4 != 0)
				{
					num6 = num4;
				}
				string[] array2 = new string[num6];
				for (int j = 0; j < num6; j++)
				{
					num5 = i * num2 + j;
					array2[j] = lstMobile[num5];
				}
				string[] array3 = new string[array2.Length];
				for (int k = 0; k < array3.Length; k++)
				{
					array3[k] = sIdTemp.ToString();
					sIdTemp++;
				}
				int num7 = 0;
				string text = "";
				if (array2.Length != 0)
				{
					text = JsonConvert.SerializeObject(array2);
				}
				string text2 = smsSettingInfoViewModel.SmsWsUserName;
				string text3 = smsSettingInfoViewModel.SmsWsPassword;
				if (smsIsSendByOtherAccount && !string.IsNullOrWhiteSpace(smsWebServiceUserName) && !string.IsNullOrWhiteSpace(smsWebServicePassword))
				{
					text2 = smsWebServiceUserName;
					text3 = smsWebServicePassword;
				}
				HttpClient httpClient = new HttpClient();
				HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "http://ippanel.com/services.jspd");
				httpRequestMessage.Headers.Add("Cookie", "DefaultLang=fa; PHPSESSID=v314srvc9qouvidfh3i9skt910");
				StringContent content = new StringContent($"op=send&uname={text2}&pass={text3}&message={body}&to={text}&from={fromNumber}", null, "application/x-www-form-urlencoded");
				httpRequestMessage.Content = content;
				HttpResponseMessage result2 = httpClient.SendAsync(httpRequestMessage).Result;
				if (result2.IsSuccessStatusCode)
				{
					string result3 = result2.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(result3))
					{
						string[] array4 = result3.Split(new char[1] { ',' });
						if (array4.Length > 1)
						{
							int result4 = 0;
							string text4 = array4[0].ToString();
							text4 = text4.Replace("\"", "");
							text4 = text4.Replace("]", "").Replace("[", "");
							if (!string.IsNullOrWhiteSpace(text4))
							{
								int.TryParse(text4, out result4);
							}
							string text5 = array4[1].ToString();
							text5 = text5.Replace("\"", "");
							text5 = text5.Replace("]", "").Replace("[", "");
							if (result4 == 0)
							{
								long result5 = 0L;
								long.TryParse(text5, out result5);
								if (result5 > 0)
								{
									for (int l = 0; l < array2.Length; l++)
									{
										num5 = i * num2 + l;
										array[num5] = result5;
										num7++;
									}
								}
								else
								{
									array[0] = -5000L;
								}
							}
							else
							{
								array[0] = -5000L;
								msgError = ((!string.IsNullOrWhiteSpace(text5)) ? (text5 + " Code = " + text4) : Messages.msgErrorRunFunction);
							}
						}
						else
						{
							array[0] = -5000L;
							msgError = Messages.msgErrorRunFunction;
						}
					}
					else
					{
						array[0] = -5000L;
						msgError = Messages.msgErrorRunFunction;
					}
				}
				else
				{
					array[0] = -5000L;
					msgError = Messages.msgErrorRunFunction;
				}
			}
			if (array != null)
			{
				result = new long[num];
				result = array;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result[0] = -5000L;
			msgError = ex.Message;
		}
	}

	public void FarazSms_SendSms(string numbers, string body, int cmessage, string fromNumber, ref int sIdTemp, ref string msgError, ref string result, int smsProviderId = 0)
	{
		result = "0";
		try
		{
			sIdTemp = ReturnSid();
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			_ = 3;
			string[] array = numbers.Split(new char[1] { ',' });
			int num = array.Length;
			long[] array2 = new long[num];
			int num2 = 1000;
			int num3 = num / num2;
			int num4 = num % num2;
			int num5 = 0;
			int num6 = num2;
			if (num4 != 0)
			{
				num3++;
			}
			for (int i = 0; i < num3; i++)
			{
				Thread.Sleep(3000);
				if (i == num3 - 1 && num4 != 0)
				{
					num6 = num4;
				}
				string[] array3 = new string[num6];
				for (int j = 0; j < num6; j++)
				{
					num5 = i * num2 + j;
					array3[j] = array[num5];
				}
				int num7 = 0;
				string text = "";
				if (array3.Length != 0)
				{
					text = JsonConvert.SerializeObject(array3);
				}
				HttpClient httpClient = new HttpClient();
				HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "http://ippanel.com/services.jspd");
				httpRequestMessage.Headers.Add("Cookie", "DefaultLang=fa; PHPSESSID=v314srvc9qouvidfh3i9skt910");
				StringContent content = new StringContent($"op=send&uname={smsSettingInfoViewModel.SmsWsUserName}&pass={smsSettingInfoViewModel.SmsWsPassword}&message={body}&to={text}&from={fromNumber}", null, "application/x-www-form-urlencoded");
				httpRequestMessage.Content = content;
				HttpResponseMessage result2 = httpClient.SendAsync(httpRequestMessage).Result;
				if (result2.IsSuccessStatusCode)
				{
					string result3 = result2.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(result3))
					{
						string[] array4 = result3.Split(new char[1] { ',' });
						if (array4.Length > 1)
						{
							int result4 = 0;
							string text2 = array4[0].ToString();
							text2 = text2.Replace("\"", "");
							text2 = text2.Replace("]", "").Replace("[", "");
							if (!string.IsNullOrWhiteSpace(text2))
							{
								int.TryParse(text2, out result4);
							}
							string text3 = array4[1].ToString();
							text3 = text3.Replace("\"", "");
							text3 = text3.Replace("]", "").Replace("[", "");
							if (result4 == 0)
							{
								long result5 = 0L;
								long.TryParse(text3, out result5);
								if (result5 > 0)
								{
									for (int k = 0; k < array3.Length; k++)
									{
										num5 = i * num2 + k;
										array2[num5] = result5;
										num7++;
									}
								}
								else
								{
									array2[0] = -5000L;
								}
							}
							else
							{
								array2[0] = -5000L;
								msgError = ((!string.IsNullOrWhiteSpace(text3)) ? (text3 + " Code = " + text2) : Messages.msgErrorRunFunction);
							}
						}
						else
						{
							array2[0] = -5000L;
							msgError = Messages.msgErrorRunFunction;
						}
					}
					else
					{
						array2[0] = -5000L;
						msgError = Messages.msgErrorRunFunction;
					}
				}
				else
				{
					array2[0] = -5000L;
					msgError = Messages.msgErrorRunFunction;
				}
			}
			if (array2 == null || array2[0] < 0)
			{
				result = "-5000";
				return;
			}
			for (int l = 0; l < array2.Length; l++)
			{
				result = result + array2[l] + ",";
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = "-5000";
			msgError = ex.Message;
		}
	}

	public void FarazSms_GetDelivery(long[] refIdArr, string[] mobArr, ref int[] result, ref string msgError, int smsProviderId = 0)
	{
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			result = new int[Enumerable.Count<long>((IEnumerable<long>)refIdArr)];
			result[0] = -7;
			if (smsSettingInfoViewModel == null)
			{
				return;
			}
			List<CommonSelectListItemViewModel> list = new List<CommonSelectListItemViewModel>();
			for (int i = 0; i < refIdArr.Length; i++)
			{
				int id = 0;
				int.TryParse(refIdArr[i].ToString(), out id);
				if (id != 0)
				{
					bool flag = false;
					if (list != null && Enumerable.Any<CommonSelectListItemViewModel>((IEnumerable<CommonSelectListItemViewModel>)list) && Enumerable.FirstOrDefault<CommonSelectListItemViewModel>((IEnumerable<CommonSelectListItemViewModel>)list, (Func<CommonSelectListItemViewModel, bool>)((CommonSelectListItemViewModel m) => m.Id.GetValueOrDefault() == id)) != null)
					{
						flag = true;
					}
					if (!flag)
					{
						CommonSelectListItemViewModel item = new CommonSelectListItemViewModel
						{
							Id = id
						};
						list.Add(item);
					}
				}
			}
			if (list == null || !Enumerable.Any<CommonSelectListItemViewModel>((IEnumerable<CommonSelectListItemViewModel>)list))
			{
				return;
			}
			foreach (CommonSelectListItemViewModel item2 in list)
			{
				long result2 = 0L;
				long.TryParse(item2.Id.ToString(), out result2);
				if (result2 == 0L)
				{
					continue;
				}
				long num = result2;
				HttpClient httpClient = new HttpClient();
				HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "http://ippanel.com/services.jspd")
				{
					Headers = { { "Cookie", "DefaultLang=fa; PHPSESSID=v314srvc9qouvidfh3i9skt910" } }
				};
				StringContent content = new StringContent($"op=delivery&uname={smsSettingInfoViewModel.SmsWsUserName}&pass={smsSettingInfoViewModel.SmsWsPassword}&uinqid={num}", null, "application/x-www-form-urlencoded");
				httpRequestMessage.Content = content;
				HttpResponseMessage result3 = httpClient.SendAsync(httpRequestMessage).Result;
				if (result3.IsSuccessStatusCode)
				{
					string result4 = result3.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(result4))
					{
						string[] array = result4.Split(new char[1] { ',' });
						if (array.Length > 1)
						{
							int result5 = 0;
							string text = array[0].ToString();
							text = text.Replace("\"", "");
							text = text.Replace("]", "").Replace("[", "");
							if (!string.IsNullOrWhiteSpace(text))
							{
								int.TryParse(text, out result5);
							}
							string text2 = array[1].ToString();
							text2 = text2.Replace("\"", "");
							text2 = text2.Replace("]", "").Replace("[", "");
							if (result5 == 0)
							{
								text2 = result4.Replace("\"", "");
								text2 = result4.Replace("[0,", "");
								text2 = text2.Replace("]", "").Replace("[", "");
								string[] array2 = text2.Split(new char[1] { ',' });
								if (array2 == null)
								{
									continue;
								}
								string[] array3 = array2;
								foreach (string text3 in array3)
								{
									if (string.IsNullOrWhiteSpace(text3))
									{
										continue;
									}
									string[] array4 = text3.Split(new char[1] { ':' });
									if (array4 == null || array4.Length <= 1)
									{
										continue;
									}
									string text4 = array4[0] ?? "";
									string text5 = array4[1] ?? "";
									if (!string.IsNullOrWhiteSpace(text4))
									{
										text4 = text4.Replace("\"", "").Replace("\\", "");
										text4 = text4.Replace("+98", "");
										if (text4.StartsWith("9"))
										{
											text4 = "0" + text4;
										}
									}
									text5 = text5.Replace("\"", "").Replace("\\", "");
									for (int k = 0; k < refIdArr.Length; k++)
									{
										bool flag2 = false;
										string text6 = mobArr[k] ?? "";
										if (int.Parse(refIdArr[k].ToString()) != result2 || !(text4 == text6) || flag2)
										{
											continue;
										}
										string text7 = "notsync";
										string text8 = "send";
										string text9 = "pending";
										string text10 = "failed";
										string text11 = "discarded";
										string text12 = "delivered";
										if (!string.IsNullOrWhiteSpace(text5))
										{
											if (text5.ToLower() == text12)
											{
												result[k] = 2;
											}
											else if (text5.ToLower() == text11)
											{
												result[k] = 4;
											}
											else if (text5.ToLower() == text10)
											{
												result[k] = 3;
											}
											else if (text5.ToLower() == text9 || text5.ToLower() == text8)
											{
												result[k] = 1;
											}
											else if (text5.ToLower() == text7)
											{
												result[k] = 0;
											}
											else
											{
												result[k] = 0;
											}
										}
										else
										{
											result[k] = 0;
										}
										flag2 = true;
									}
								}
							}
							else
							{
								msgError = ((!string.IsNullOrWhiteSpace(text2)) ? (text2 + " Code = " + text) : Messages.msgErrorRunFunction);
							}
						}
						else
						{
							msgError = Messages.msgErrorRunFunction;
						}
					}
					else
					{
						msgError = Messages.msgErrorRunFunction;
					}
				}
				else
				{
					msgError = Messages.msgErrorRunFunction;
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
		}
	}

	public void FarazSms_GetCredit(ref decimal credit, ref string msgError, int smsProviderId = 0)
	{
		credit = default(decimal);
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			if (smsSettingInfoViewModel == null)
			{
				return;
			}
			HttpClient httpClient = new HttpClient();
			HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "http://ippanel.com/services.jspd")
			{
				Headers = { { "Cookie", "DefaultLang=fa; PHPSESSID=v314srvc9qouvidfh3i9skt910" } }
			};
			StringContent content = new StringContent($"op=credit&uname={smsSettingInfoViewModel.SmsWsUserName}&pass={smsSettingInfoViewModel.SmsWsPassword}", null, "application/x-www-form-urlencoded");
			httpRequestMessage.Content = content;
			HttpResponseMessage result = httpClient.SendAsync(httpRequestMessage).Result;
			if (result.IsSuccessStatusCode)
			{
				string result2 = result.Content.ReadAsStringAsync().Result;
				if (!string.IsNullOrWhiteSpace(result2))
				{
					string[] array = result2.Split(new char[1] { ',' });
					if (array.Length > 1)
					{
						int result3 = 0;
						string text = array[0].ToString();
						text = text.Replace("\"", "");
						text = text.Replace("]", "").Replace("[", "");
						if (!string.IsNullOrWhiteSpace(text))
						{
							int.TryParse(text, out result3);
						}
						string text2 = array[1].ToString();
						text2 = text2.Replace("\"", "");
						text2 = text2.Replace("]", "").Replace("[", "");
						if (result3 == 0)
						{
							if (!string.IsNullOrWhiteSpace(text2))
							{
								decimal.TryParse(text2, out credit);
								return;
							}
							credit = default(decimal);
							msgError = Messages.ErrorInformation;
						}
						else
						{
							credit = default(decimal);
							msgError = Messages.ErrorInformation + "<br>" + text2 + " Code = " + text;
						}
					}
					else
					{
						credit = default(decimal);
						msgError = Messages.ErrorInformation;
					}
				}
				else
				{
					credit = default(decimal);
					msgError = Messages.ErrorInformation;
				}
			}
			else
			{
				credit = default(decimal);
				msgError = Messages.msgErrorRunFunction;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
			credit = default(decimal);
		}
	}

	public List<FarazSmsGetReceiveResponseViewModel> FarazSms_ReceiveSms(int smsProviderId = 0)
	{
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		List<FarazSmsGetReceiveResponseViewModel> result = new List<FarazSmsGetReceiveResponseViewModel>();
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			if (smsSettingInfoViewModel != null)
			{
				HttpClient httpClient = new HttpClient();
				HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "http://ippanel.com/services.jspd")
				{
					Headers = { { "Cookie", "DefaultLang=fa; PHPSESSID=v314srvc9qouvidfh3i9skt910" } }
				};
				StringContent content = new StringContent($"op=inboxlist&uname={smsSettingInfoViewModel.SmsWsUserName}&pass={smsSettingInfoViewModel.SmsWsPassword}", Encoding.UTF8, "application/x-www-form-urlencoded");
				httpRequestMessage.Content = content;
				HttpResponseMessage result2 = httpClient.SendAsync(httpRequestMessage).Result;
				if (result2.IsSuccessStatusCode)
				{
					string result3 = result2.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(result3))
					{
						string[] array = result3.Split(new char[1] { ',' });
						if (array.Length > 1)
						{
							int result4 = 0;
							string text = array[0].ToString();
							text = text.Replace("\"", "");
							text = text.Replace("]", "").Replace("[", "");
							if (!string.IsNullOrWhiteSpace(text))
							{
								int.TryParse(text, out result4);
							}
							string text2 = array[1].ToString();
							text2 = text2.Replace("\"", "");
							text2 = text2.Replace("]", "").Replace("[", "");
							if (result4 == 0)
							{
								if (text2.ToLower() != "null")
								{
									text2 = result3;
									text2 = Regex.Unescape(result3);
									text2 = Regex.Unescape(text2);
									text2 = text2.Replace("[0,", "");
									text2 = text2.Replace("\\", "");
									text2 = text2.Replace("]", "");
									if (!text2.EndsWith("]"))
									{
										text2 += "]";
									}
									text2 = text2.Replace("\"[", "[").Replace("\"]", "]");
									if (!string.IsNullOrWhiteSpace(text2))
									{
										result = new JavaScriptSerializer().Deserialize<List<FarazSmsGetReceiveResponseViewModel>>(text2);
									}
								}
							}
							else if (string.IsNullOrWhiteSpace(text2))
							{
								_ = Messages.msgErrorRunFunction;
							}
							else
							{
								_ = text2 + " Code = " + text;
							}
						}
						else
						{
							_ = Messages.msgErrorRunFunction;
						}
					}
					else
					{
						_ = Messages.msgErrorRunFunction;
					}
				}
				else
				{
					string msgErrorRunFunction = Messages.msgErrorRunFunction;
					Exception innerException = new Exception();
					Exception e = new Exception(msgErrorRunFunction, innerException);
					ErrorSignal.FromCurrentContext().Raise(e);
				}
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		finally
		{
			cRMSpEntities.Dispose();
		}
		return result;
	}

	public void Sharif_SendSms1To1(string[] lstMobile, string body, int cmessage, string fromNumber, ref string msgError, ref long[] result, bool smsIsSendByOtherAccount = false, string smsWebServiceUserName = "", string smsWebServicePassword = "", int smsProviderId = 0)
	{
		result = new long[1];
		msgError = "";
		try
		{
			GetSmsSetting(out var freeSmsCount);
			if (smsProviderId != 0)
			{
				GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			string value = Sharif_GetToken(smsIsSendByOtherAccount, smsWebServiceUserName, smsWebServicePassword);
			if (!string.IsNullOrWhiteSpace(value))
			{
				List<string> list = new List<string>();
				foreach (string text in lstMobile)
				{
					if (!string.IsNullOrWhiteSpace(text))
					{
						list.Add(text);
					}
				}
				HttpClient httpClient = new HttpClient();
				string text2 = "https://sms.sharif.ir/api/sms/send";
				httpClient.BaseAddress = new Uri(text2);
				httpClient.DefaultRequestHeaders.Add("Authorization", value);
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpContent content = new StringContent(JsonConvert.SerializeObject(new SharifSendRequestViewModel
				{
					Mobile = list,
					Message = body,
					DateTime = null,
					SystemId = 0,
					Password = null
				}), Encoding.UTF8, "application/json");
				HttpResponseMessage result2 = httpClient.PostAsync(text2, content).Result;
				if (result2.IsSuccessStatusCode)
				{
					string result3 = result2.Content.ReadAsStringAsync().Result;
					SharifSendResponseViewModel sharifSendResponseViewModel = JsonConvert.DeserializeObject<SharifSendResponseViewModel>(result3);
					if (sharifSendResponseViewModel != null)
					{
						int result4 = 0;
						int.TryParse(sharifSendResponseViewModel.statusCode.ToString(), out result4);
						if (result4 == 0)
						{
							string[] array = Regex.Split(result3, "\"object\":");
							if (array != null)
							{
								if (array.Length > 1)
								{
									string text3 = array[1];
									if (!string.IsNullOrWhiteSpace(text3))
									{
										if (text3.EndsWith("}"))
										{
											text3 = text3.TrimEnd(new char[1] { '}' });
										}
										List<SharifSendInfoViewModel> list2 = JsonConvert.DeserializeObject<List<SharifSendInfoViewModel>>(text3);
										if (list2 != null)
										{
											int num = Enumerable.Count<SharifSendInfoViewModel>((IEnumerable<SharifSendInfoViewModel>)list2);
											if (num > 0)
											{
												long[] array2 = new long[num];
												for (int j = 0; j < num; j++)
												{
													array2[j] = list2[j].id;
												}
												result = array2;
											}
											else
											{
												result[0] = -5000L;
												msgError = Messages.msgErrorRunFunction;
											}
										}
										else
										{
											result[0] = -5000L;
											msgError = Messages.msgErrorRunFunction;
										}
									}
									else
									{
										result[0] = -5000L;
										msgError = Messages.msgErrorRunFunction;
									}
								}
								else
								{
									result[0] = -5000L;
									msgError = Messages.msgErrorRunFunction;
								}
							}
							else
							{
								result[0] = -5000L;
								msgError = Messages.msgErrorRunFunction;
							}
						}
						else
						{
							result[0] = -5000L;
							msgError = ((!string.IsNullOrEmpty(sharifSendResponseViewModel.message)) ? (sharifSendResponseViewModel.message + " StatusCode: " + result4) : Messages.msgErrorRunFunction);
						}
					}
					else
					{
						result[0] = -5000L;
						msgError = Messages.msgErrorRunFunction;
					}
				}
				else
				{
					result[0] = -5000L;
					msgError = Messages.msgErrorRunFunction;
				}
			}
			else
			{
				result[0] = -5000L;
				msgError = Messages.msgErrorReceivingToken;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result[0] = -5000L;
			msgError = ex.Message;
		}
	}

	public void Sharif_SendSms(string numbers, string body, int cmessage, string fromNumber, ref string msgError, ref string result, int smsProviderId = 0)
	{
		result = "0";
		try
		{
			GetSmsSetting(out var freeSmsCount);
			if (smsProviderId != 0)
			{
				GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			string[] array = numbers.Split(new char[1] { ',' });
			_ = new long[array.Length];
			List<string> list = new List<string>();
			string[] array2 = array;
			foreach (string text in array2)
			{
				if (!string.IsNullOrWhiteSpace(text))
				{
					list.Add(text);
				}
			}
			string value = Sharif_GetToken();
			if (!string.IsNullOrWhiteSpace(value))
			{
				HttpClient httpClient = new HttpClient();
				string text2 = "https://sms.sharif.ir/api/sms/send";
				httpClient.BaseAddress = new Uri(text2);
				httpClient.DefaultRequestHeaders.Add("Authorization", value);
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpContent content = new StringContent(JsonConvert.SerializeObject(new SharifSendRequestViewModel
				{
					Mobile = list,
					Message = body,
					DateTime = null,
					SystemId = 0,
					Password = null
				}), Encoding.UTF8, "application/json");
				HttpResponseMessage result2 = httpClient.PostAsync(text2, content).Result;
				if (result2.IsSuccessStatusCode)
				{
					string result3 = result2.Content.ReadAsStringAsync().Result;
					SharifSendResponseViewModel sharifSendResponseViewModel = JsonConvert.DeserializeObject<SharifSendResponseViewModel>(result3);
					if (sharifSendResponseViewModel != null)
					{
						int result4 = 0;
						int.TryParse(sharifSendResponseViewModel.statusCode.ToString(), out result4);
						if (result4 == 0)
						{
							string[] array3 = Regex.Split(result3, "\"object\":");
							if (array3 != null)
							{
								if (array3.Length > 1)
								{
									string text3 = array3[1];
									if (!string.IsNullOrWhiteSpace(text3))
									{
										if (text3.EndsWith("}"))
										{
											text3 = text3.TrimEnd(new char[1] { '}' });
										}
										List<SharifSendInfoViewModel> list2 = JsonConvert.DeserializeObject<List<SharifSendInfoViewModel>>(text3);
										if (list2 != null)
										{
											int num = Enumerable.Count<SharifSendInfoViewModel>((IEnumerable<SharifSendInfoViewModel>)list2);
											if (num > 0)
											{
												result = "";
												for (int j = 0; j < num; j++)
												{
													if (!string.IsNullOrWhiteSpace(result))
													{
														result += ",";
													}
													result += list2[j].id;
												}
											}
											else
											{
												result = "-5000";
												msgError = Messages.msgErrorRunFunction;
											}
										}
										else
										{
											result = "-5000";
											msgError = Messages.msgErrorRunFunction;
										}
									}
									else
									{
										result = "-5000";
										msgError = Messages.msgErrorRunFunction;
									}
								}
								else
								{
									result = "-5000";
									msgError = Messages.msgErrorRunFunction;
								}
							}
							else
							{
								result = "-5000";
								msgError = Messages.msgErrorRunFunction;
							}
						}
						else
						{
							result = "-5000";
							msgError = ((!string.IsNullOrEmpty(sharifSendResponseViewModel.message)) ? (sharifSendResponseViewModel.message + " StatusCode: " + result4) : Messages.msgErrorRunFunction);
						}
					}
					else
					{
						result = "-5000";
						msgError = Messages.msgErrorRunFunction;
					}
				}
				else
				{
					result = "-5000";
					msgError = Messages.msgErrorRunFunction;
				}
			}
			else
			{
				result = "-5000";
				msgError = Messages.msgErrorReceivingToken;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = "-5000";
			msgError = ex.Message;
		}
	}

	public bool Sharif_GetDelivery(long[] refIdArr, ref int[] result, ref string msgError, int smsProviderId = 0)
	{
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			result = new int[Enumerable.Count<long>((IEnumerable<long>)refIdArr)];
			result[0] = -7;
			if (smsSettingInfoViewModel != null)
			{
				string value = Sharif_GetToken();
				if (string.IsNullOrWhiteSpace(value))
				{
					msgError = Messages.msgErrorReceivingToken;
					return false;
				}
				for (int i = 0; i < refIdArr.Length; i++)
				{
					HttpClient httpClient = new HttpClient();
					string text = "https://sms.sharif.ir/api/sms/status";
					httpClient.BaseAddress = new Uri(text);
					httpClient.DefaultRequestHeaders.Add("Authorization", value);
					httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					HttpContent content = new StringContent(JsonConvert.SerializeObject(new SharifGetStatuRequestViewModel
					{
						Id = refIdArr[i]
					}), Encoding.UTF8, "application/json");
					HttpResponseMessage result2 = httpClient.PostAsync(text, content).Result;
					if (result2.IsSuccessStatusCode)
					{
						SharifGetStatuResponseViewModel sharifGetStatuResponseViewModel = JsonConvert.DeserializeObject<SharifGetStatuResponseViewModel>(result2.Content.ReadAsStringAsync().Result);
						if (sharifGetStatuResponseViewModel != null)
						{
							int result3 = 0;
							int.TryParse(sharifGetStatuResponseViewModel.status.ToString(), out result3);
							switch (result3)
							{
							case 0:
							case 2:
							case 3:
								result[i] = 2;
								break;
							case 1:
								result[i] = 0;
								break;
							case 4:
								result[i] = 1;
								break;
							default:
								result[i] = result3;
								break;
							}
							continue;
						}
						msgError = Messages.ErrorInformation;
						return false;
					}
					msgError = Messages.ErrorInformation;
					return false;
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
		}
		return true;
	}

	public string Sharif_GetToken(bool smsIsSendByOtherAccount = false, string smsWebServiceUserName = "", string smsWebServicePassword = "", int smsProviderId = 0)
	{
		string text = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			string username = smsSettingInfoViewModel.SmsWsUserName;
			string password = smsSettingInfoViewModel.SmsWsPassword;
			if (smsIsSendByOtherAccount && !string.IsNullOrWhiteSpace(smsWebServiceUserName) && !string.IsNullOrWhiteSpace(smsWebServicePassword))
			{
				username = smsWebServiceUserName;
				password = smsWebServicePassword;
			}
			HttpClient httpClient = new HttpClient();
			string text2 = "https://sms.sharif.ir/api/system/authenticate";
			httpClient.BaseAddress = new Uri(text2);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			HttpContent content = new StringContent(JsonConvert.SerializeObject(new SharifRequsetTokenViewModel
			{
				Username = username,
				Password = password
			}), Encoding.UTF8, "application/json");
			HttpResponseMessage result = httpClient.PostAsync(text2, content).Result;
			if (result.IsSuccessStatusCode)
			{
				SharifResponseTokenViewModel sharifResponseTokenViewModel = JsonConvert.DeserializeObject<SharifResponseTokenViewModel>(result.Content.ReadAsStringAsync().Result);
				if (sharifResponseTokenViewModel != null)
				{
					text = sharifResponseTokenViewModel.Token ?? "";
					if (!string.IsNullOrWhiteSpace(text))
					{
						text = "Bearer " + text;
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = "";
		}
		return text;
	}

	public void Sharif_GetCredit(ref decimal credit, ref string msgError, int smsProviderId = 0)
	{
		credit = default(decimal);
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			if (smsSettingInfoViewModel != null)
			{
				string value = Sharif_GetToken();
				if (!string.IsNullOrWhiteSpace(value))
				{
					HttpClient httpClient = new HttpClient();
					string text = "https://sms.sharif.ir/api/system/charge";
					httpClient.BaseAddress = new Uri(text);
					httpClient.DefaultRequestHeaders.Add("Authorization", value);
					httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					HttpContent content = new StringContent(JsonConvert.SerializeObject(new SharifGetCreditRequestViewModel
					{
						SystemId = 0
					}), Encoding.UTF8, "application/json");
					HttpResponseMessage result = httpClient.PostAsync(text, content).Result;
					if (result.IsSuccessStatusCode)
					{
						string result2 = result.Content.ReadAsStringAsync().Result;
						SharifGetCreditResponseViewModel sharifGetCreditResponseViewModel = JsonConvert.DeserializeObject<SharifGetCreditResponseViewModel>(result2);
						if (sharifGetCreditResponseViewModel != null)
						{
							int result3 = 0;
							int.TryParse(sharifGetCreditResponseViewModel.statusCode.ToString(), out result3);
							if (result3 == 0)
							{
								string[] array = Regex.Split(result2, "\"object\":");
								if (array != null && array.Length > 1)
								{
									string text2 = array[1];
									if (!string.IsNullOrWhiteSpace(text2))
									{
										text2 = text2.Replace("}", "");
										decimal.TryParse(text2, out credit);
									}
								}
							}
							else
							{
								credit = default(decimal);
								msgError = Messages.ErrorInformation;
								if (!string.IsNullOrWhiteSpace(sharifGetCreditResponseViewModel.message))
								{
									msgError = msgError + "(" + sharifGetCreditResponseViewModel.message + ")";
								}
							}
						}
						else
						{
							credit = default(decimal);
							msgError = Messages.ErrorInformation;
						}
					}
					else
					{
						credit = default(decimal);
						msgError = Messages.ErrorInformation;
					}
				}
				else
				{
					credit = default(decimal);
					msgError = Messages.msgErrorReceivingToken;
				}
			}
			else
			{
				credit = default(decimal);
				msgError = Messages.msgErrorReceivingToken;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
			credit = default(decimal);
		}
	}

	public void Sharif_ReceiveSms(int smsProviderId = 0)
	{
	}

	public void SunWay_SendSms1To1(string[] lstMobile, string[] lstBody, int cmessage, string fromNumber, int[] lstTypeUnicodeMessage, string[] lstSchedulDate, ref int sIdTemp, ref string msgError, ref long[] lstGetId, ref long[] result, bool smsIsSendByOtherAccount = false, string smsWebServiceUserName = "", string smsWebServicePassword = "", int smsProviderId = 0)
	{
		SMSSoapClient sMSSoapClient = new SMSSoapClient();
		result = new long[1];
		result[0] = -7L;
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			sIdTemp = ReturnSid();
			SysSeting.Get();
			string userName = smsSettingInfoViewModel.SmsWsUserName;
			string password = smsSettingInfoViewModel.SmsWsPassword;
			if (smsIsSendByOtherAccount && !string.IsNullOrWhiteSpace(smsWebServiceUserName) && !string.IsNullOrWhiteSpace(smsWebServicePassword))
			{
				userName = smsWebServiceUserName;
				password = smsWebServicePassword;
			}
			_ = 3;
			int num = lstMobile.Length;
			long[] array = new long[num];
			int num2 = 1000;
			int num3 = num / num2;
			int num4 = num % num2;
			int num5 = 0;
			int num6 = num2;
			if (num4 != 0)
			{
				num3++;
			}
			for (int i = 0; i < num3; i++)
			{
				Thread.Sleep(3000);
				if (i == num3 - 1 && num4 != 0)
				{
					num6 = num4;
				}
				string[] array2 = new string[num6];
				for (int j = 0; j < num6; j++)
				{
					num5 = i * num2 + j;
					array2[j] = lstMobile[num5];
				}
				long[] checkingMessageID = new long[array2.Length];
				string[] array3 = new string[array2.Length];
				for (int k = 0; k < num6; k++)
				{
					num5 = i * num2 + k;
					array3[k] = lstBody[num5];
				}
				int num7 = 0;
				long[] array4 = sMSSoapClient.SendArrayLikeToLike(userName, password, array2, array3, fromNumber, "", checkingMessageID);
				if (array4 != null)
				{
					long num8 = array4[0];
					if (num8 < 1000)
					{
						array[0] = -5000L;
						msgError = SunWay_GetError(num8);
						continue;
					}
					for (int l = 0; l < array2.Length; l++)
					{
						num5 = i * num2 + l;
						array[num5] = array4[l];
						num7++;
					}
				}
				else
				{
					array[0] = -5000L;
					msgError = Messages.msgErrorRunFunction;
				}
			}
			if (array != null)
			{
				result = new long[num];
				result = array;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result[0] = -5000L;
			msgError = ex.Message;
		}
	}

	public void SunWay_SendSms(string numbers, string body, int cmessage, string fromNumber, ref int sIdTemp, ref string msgError, ref string result, int smsProviderId = 0)
	{
		msgError = "";
		result = "-7";
		try
		{
			SMSSoapClient sMSSoapClient = new SMSSoapClient();
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			sIdTemp = ReturnSid();
			_ = 3;
			string[] array = numbers.Split(new char[1] { ',' });
			int num = array.Length;
			long[] array2 = new long[num];
			int num2 = 1000;
			int num3 = num / num2;
			int num4 = num % num2;
			int num5 = 0;
			int num6 = num2;
			if (num4 != 0)
			{
				num3++;
			}
			for (int i = 0; i < num3; i++)
			{
				Thread.Sleep(3000);
				if (i == num3 - 1 && num4 != 0)
				{
					num6 = num4;
				}
				string[] array3 = new string[num6];
				for (int j = 0; j < num6; j++)
				{
					num5 = i * num2 + j;
					array3[j] = array[num5];
				}
				long[] checkingMessageID = new long[array3.Length];
				int num7 = 0;
				long[] array4 = sMSSoapClient.SendArray(smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, array3, body, fromNumber, "", checkingMessageID);
				if (array4 != null)
				{
					long num8 = array4[0];
					if (num8 < 1000)
					{
						array2[0] = -50000L;
						msgError = SunWay_GetError(num8);
						continue;
					}
					for (int k = 0; k < array3.Length; k++)
					{
						num5 = i * num2 + k;
						array2[num5] = array4[k];
						num7++;
					}
				}
				else
				{
					array2[0] = -50000L;
					msgError = Messages.msgErrorRunFunction;
				}
			}
			if (array2 == null || array2[0] < 0)
			{
				result = "-50000";
				return;
			}
			result = "";
			for (int l = 0; l < array2.Length; l++)
			{
				result = result + array2[l] + ",";
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = "-50000";
			msgError = ex.Message;
		}
	}

	public void SunWay_GetDelivery(long[] refIdArr, ref int[] result, ref string msgError, int smsProviderId = 0)
	{
		try
		{
			SMSSoapClient sMSSoapClient = new SMSSoapClient();
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			result = new int[Enumerable.Count<long>((IEnumerable<long>)refIdArr)];
			result[0] = -7;
			if (smsSettingInfoViewModel == null)
			{
				return;
			}
			result = new int[Enumerable.Count<long>((IEnumerable<long>)refIdArr)];
			result[0] = -7;
			if (smsSettingInfoViewModel == null)
			{
				return;
			}
			long[] messageStatus = sMSSoapClient.GetMessageStatus(smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, refIdArr);
			if (messageStatus == null)
			{
				return;
			}
			long num = messageStatus[0];
			if (num < 1000 && num > 50)
			{
				msgError = SunWay_GetError(num);
				return;
			}
			for (int i = 0; i < Enumerable.Count<long>((IEnumerable<long>)refIdArr); i++)
			{
				long num2 = messageStatus[i];
				int result2 = 0;
				int.TryParse(num2.ToString(), out result2);
				switch (result2)
				{
				case 0:
				case 1:
				case 7:
				case 8:
					result[i] = 0;
					break;
				case 2:
					result[i] = 2;
					break;
				case 3:
					result[i] = 3;
					break;
				case 4:
					result[i] = 1;
					break;
				case 5:
					result[i] = 16;
					break;
				default:
					result[i] = result2;
					break;
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
		}
	}

	public InboxItem[] SunWay_GetMessage(int smsProviderId = 0)
	{
		InboxItem[] result = null;
		try
		{
			SMSSoapClient sMSSoapClient = new SMSSoapClient();
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			InboxItem[] inboxMessage = sMSSoapClient.GetInboxMessage(smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, 100000);
			if (inboxMessage != null)
			{
				result = inboxMessage;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public void SunWay_GetCredit(ref decimal credit, ref string msgError, int smsProviderId = 0)
	{
		SMSSoapClient sMSSoapClient = new SMSSoapClient();
		credit = default(decimal);
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			if (smsSettingInfoViewModel != null)
			{
				decimal.TryParse(sMSSoapClient.GetCredit(smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword).ToString(), out credit);
				if (credit < 1000m)
				{
					long result = 0L;
					long.TryParse(credit.ToString(), out result);
					msgError = SunWay_GetError(result);
					credit = default(decimal);
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
			credit = default(decimal);
		}
	}

	public string SunWay_GetError(long errorCode)
	{
		string text = "";
		if (errorCode <= 400)
		{
			if (errorCode <= 80)
			{
				long num = errorCode - 51;
				if ((ulong)num <= 19uL)
				{
					switch (num)
					{
					case 0L:
						return Messages.msgErrorSunWaySmsIsUserNameIsWrong;
					case 1L:
						return Messages.msgErrorSunWaySmsIsUserNameIsEmpty;
					case 2L:
						return Messages.msgErrorSunWaySmsIsLengthReciepientNumberOverlimit;
					case 3L:
						return Messages.msgErrorSunWaySmsReciepientNumberIsEmpty;
					case 4L:
						return Messages.msgErrorSunWaySmsReciepientNumberIsInvalid;
					case 8L:
						return Messages.msgErrorSunWaySmsMessageBodyIsEmpty;
					case 9L:
						return Messages.msgErrorSunWaySmsServerHasTraffic;
					case 10L:
						return Messages.msgErrorSunWaySmsSpecialNumberIsInvalid;
					case 11L:
						return Messages.msgErrorSunWaySmsSpecialNumberIsEmpty;
					case 12L:
						return Messages.msgErrorSunWaySmsIPNotAccess;
					case 19L:
						return Messages.msgErrorSunWaySmsUserDisabled;
					case 5L:
					case 6L:
					case 7L:
					case 13L:
					case 14L:
					case 15L:
					case 16L:
					case 17L:
					case 18L:
						goto IL_01f9;
					}
				}
				long num2 = errorCode - 77;
				if ((ulong)num2 <= 3uL)
				{
					switch (num2)
					{
					case 0L:
						return Messages.msgErrorSunWaySmsNotWebServiceUser;
					case 1L:
						return Messages.msgErrorSunWaySmsUserNotSmsManagement;
					case 3L:
						return Messages.msgErrorSunWaySmsWebServiceDisabledByAdmin;
					}
				}
			}
			else
			{
				long num3 = errorCode - 201;
				if ((ulong)num3 <= 5uL)
				{
					switch (num3)
					{
					case 0L:
						return Messages.msgErrorSunWaySmsSpecialNumberFormatIsWrong;
					case 1L:
						return Messages.msgErrorSunWaySmsOperatorReciepientNumberIsUnknown;
					case 2L:
						return Messages.msgErrorSunWaySmsLackCreditNotAbleToSend;
					case 5L:
						return Messages.msgErrorSunWaySmsOperatorNumberIsInvalid;
					case 3L:
					case 4L:
						goto IL_01f9;
					}
				}
				if (errorCode == 400)
				{
					return Messages.msgErrorSunWaySmsRequsetMoreThanLimit;
				}
			}
		}
		else
		{
			switch (errorCode)
			{
			case 666L:
				return Messages.msgErrorSunWaySmsServiceTemporarilyDisabled;
			case 777L:
				return Messages.msgErrorSunWaySmsIPBlocked;
			case 888L:
				return Messages.msgErrorSunWaySmsNoAuthRegisterdSenderNumber;
			case 999L:
				return Messages.msgErrorSunWaySmsSendSmsNotAllowed;
			}
		}
		goto IL_01f9;
		IL_01f9:
		return Messages.msgErrorRunProcedure;
	}

	public void CandooSms_SendSms1To1(string[] lstMobile, string[] lstBody, int cmessage, string fromNumber, int[] lstTypeUnicodeMessage, string[] lstSchedulDate, ref int sIdTemp, ref string msgError, ref long[] lstGetId, ref long[] result, bool smsIsSendByOtherAccount = false, string smsWebServiceUserName = "", string smsWebServicePassword = "", int smsProviderId = 0)
	{
		result = new long[1];
		result[0] = -7L;
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			sIdTemp = ReturnSid();
			SysSeting.Get();
			_ = smsSettingInfoViewModel.SmsWsUserName;
			string text = smsSettingInfoViewModel.SmsWsPassword;
			if (smsIsSendByOtherAccount && !string.IsNullOrWhiteSpace(smsWebServiceUserName) && !string.IsNullOrWhiteSpace(smsWebServicePassword))
			{
				text = smsWebServicePassword;
			}
			_ = 3;
			int num = lstMobile.Length;
			long[] array = new long[num];
			int num2 = 100;
			int num3 = num / num2;
			int num4 = num % num2;
			int num5 = 0;
			int num6 = num2;
			if (num4 != 0)
			{
				num3++;
			}
			for (int i = 0; i < num3; i++)
			{
				Thread.Sleep(3000);
				if (i == num3 - 1 && num4 != 0)
				{
					num6 = num4;
				}
				int num7 = 0;
				string text2 = smsSettingInfoViewModel.ProviderUrl ?? "";
				string value = text;
				if (string.IsNullOrWhiteSpace(text2))
				{
					text2 = "https://my.candoosms.com/";
				}
				if (!string.IsNullOrWhiteSpace(text2) && !text2.EndsWith("/"))
				{
					text2 += "/";
				}
				List<CandooSendViewModel> list = new List<CandooSendViewModel>();
				num5 = 0;
				for (int j = 0; j < num6; j++)
				{
					num5 = i * num2 + j;
					string text3 = lstMobile[num5];
					if (!string.IsNullOrWhiteSpace(text3))
					{
						if (text3.StartsWith("0"))
						{
							text3 = text3.Substring(1);
						}
						if (!text3.StartsWith("98"))
						{
							text3 = "98" + text3;
						}
					}
					CandooSendViewModel item = new CandooSendViewModel
					{
						srcNum = fromNumber,
						recipient = text3,
						body = lstBody[num5],
						customerId = null,
						type = ((num == 1) ? 1 : 0),
						retryCount = 10,
						validityPeriod = 0
					};
					list.Add(item);
				}
				if (Enumerable.Any<CandooSendViewModel>((IEnumerable<CandooSendViewModel>)list))
				{
					HttpClient httpClient = new HttpClient();
					string text4 = text2 + "api/v3.0.1/send";
					httpClient.BaseAddress = new Uri(text4);
					httpClient.DefaultRequestHeaders.Add("x-api-key", value);
					httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					HttpContent content = new StringContent(JsonConvert.SerializeObject(list), Encoding.UTF8, "application/json");
					HttpResponseMessage result2 = httpClient.PostAsync(text4, content).Result;
					string text5 = result2.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text5))
					{
						text5 = Common.ClearHiddenCharacters(text5);
					}
					if (result2.IsSuccessStatusCode)
					{
						string text6 = Messages.msgErrorRunFunction;
						if (!string.IsNullOrWhiteSpace(text5))
						{
							if (text5.IndexOf("\"messageId\":", StringComparison.Ordinal) < 0)
							{
								CandooErrorResponseViewModel candooErrorResponseViewModel = JsonConvert.DeserializeObject<CandooErrorResponseViewModel>(text5);
								if (candooErrorResponseViewModel != null && !string.IsNullOrWhiteSpace(candooErrorResponseViewModel.message))
								{
									text6 = text6 + " [" + candooErrorResponseViewModel.message + " (ErrorCode = " + candooErrorResponseViewModel.statusCode.GetValueOrDefault() + ")]";
								}
								array[0] = -5000L;
								msgError = text6;
								continue;
							}
							List<CandooSendResponseViewModel> list2 = JsonConvert.DeserializeObject<List<CandooSendResponseViewModel>>(text5);
							if (list2 != null)
							{
								if (Enumerable.Any<CandooSendResponseViewModel>((IEnumerable<CandooSendResponseViewModel>)list2))
								{
									for (int k = 0; k < num6; k++)
									{
										num5 = i * num2 + k;
										string smsVmMob = list[k].recipient ?? "";
										CandooSendResponseViewModel candooSendResponseViewModel = Enumerable.FirstOrDefault<CandooSendResponseViewModel>((IEnumerable<CandooSendResponseViewModel>)list2, (Func<CandooSendResponseViewModel, bool>)((CandooSendResponseViewModel m) => (m.recipient ?? "") == smsVmMob));
										if (candooSendResponseViewModel != null)
										{
											array[num5] = candooSendResponseViewModel.messageId.GetValueOrDefault();
										}
										num7++;
									}
								}
								else
								{
									array[0] = -5000L;
									msgError = text6;
								}
							}
							else
							{
								array[0] = -5000L;
								msgError = text6;
							}
						}
						else
						{
							array[0] = -5000L;
							msgError = text6;
						}
						continue;
					}
					string text7 = Messages.msgErrorRunFunction;
					if (!string.IsNullOrWhiteSpace(text5))
					{
						CandooErrorResponseViewModel candooErrorResponseViewModel2 = JsonConvert.DeserializeObject<CandooErrorResponseViewModel>(text5);
						if (candooErrorResponseViewModel2 != null && !string.IsNullOrWhiteSpace(candooErrorResponseViewModel2.message))
						{
							text7 = text7 + " [" + candooErrorResponseViewModel2.message + " (ErrorCode = " + candooErrorResponseViewModel2.statusCode.GetValueOrDefault() + ")]";
						}
					}
					array[0] = -5000L;
					msgError = text7;
				}
				else
				{
					array[0] = -5000L;
					msgError = Messages.ErrorNotFound;
				}
			}
			if (array != null)
			{
				result = new long[num];
				result = array;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result[0] = -5000L;
			msgError = ex.Message;
		}
	}

	public void CandooSms_SendSms(string numbers, string body, int cmessage, string fromNumber, ref int sIdTemp, ref string msgError, ref string result, int smsProviderId = 0)
	{
		msgError = "";
		result = "-7";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			sIdTemp = ReturnSid();
			_ = 3;
			string[] array = numbers.Split(new char[1] { ',' });
			int num = array.Length;
			long[] array2 = new long[num];
			int num2 = 100;
			int num3 = num / num2;
			int num4 = num % num2;
			int num5 = 0;
			int num6 = num2;
			if (num4 != 0)
			{
				num3++;
			}
			for (int i = 0; i < num3; i++)
			{
				Thread.Sleep(3000);
				if (i == num3 - 1 && num4 != 0)
				{
					num6 = num4;
				}
				int num7 = 0;
				string text = smsSettingInfoViewModel.ProviderUrl ?? "";
				string smsWsPassword = smsSettingInfoViewModel.SmsWsPassword;
				if (string.IsNullOrWhiteSpace(text))
				{
					text = "https://my.candoosms.com/";
				}
				if (!string.IsNullOrWhiteSpace(text) && !text.EndsWith("/"))
				{
					text += "/";
				}
				List<CandooSendViewModel> list = new List<CandooSendViewModel>();
				num5 = 0;
				for (int j = 0; j < num6; j++)
				{
					num5 = i * num2 + j;
					string text2 = array[num5];
					if (!string.IsNullOrWhiteSpace(text2))
					{
						if (text2.StartsWith("0"))
						{
							text2 = text2.Substring(1);
						}
						if (!text2.StartsWith("98"))
						{
							text2 = "98" + text2;
						}
					}
					CandooSendViewModel item = new CandooSendViewModel
					{
						srcNum = fromNumber,
						recipient = text2,
						body = body,
						customerId = null,
						type = ((num == 1) ? 1 : 0),
						retryCount = 10,
						validityPeriod = 0
					};
					list.Add(item);
				}
				if (Enumerable.Any<CandooSendViewModel>((IEnumerable<CandooSendViewModel>)list))
				{
					HttpClient httpClient = new HttpClient();
					string text3 = text + "api/v3.0.1/send";
					httpClient.BaseAddress = new Uri(text3);
					httpClient.DefaultRequestHeaders.Add("x-api-key", smsWsPassword);
					httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					HttpContent content = new StringContent(JsonConvert.SerializeObject(list), Encoding.UTF8, "application/json");
					HttpResponseMessage result2 = httpClient.PostAsync(text3, content).Result;
					string text4 = result2.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text4))
					{
						text4 = Common.ClearHiddenCharacters(text4);
					}
					if (result2.IsSuccessStatusCode)
					{
						string text5 = Messages.msgErrorRunFunction;
						if (!string.IsNullOrWhiteSpace(text4))
						{
							if (text4.IndexOf("\"messageId\":", StringComparison.Ordinal) < 0)
							{
								CandooErrorResponseViewModel candooErrorResponseViewModel = JsonConvert.DeserializeObject<CandooErrorResponseViewModel>(text4);
								if (candooErrorResponseViewModel != null && !string.IsNullOrWhiteSpace(candooErrorResponseViewModel.message))
								{
									text5 = text5 + " [" + candooErrorResponseViewModel.message + " (ErrorCode = " + candooErrorResponseViewModel.statusCode.GetValueOrDefault() + ")]";
								}
								array2[0] = -50000L;
								msgError = text5;
								continue;
							}
							List<CandooSendResponseViewModel> list2 = JsonConvert.DeserializeObject<List<CandooSendResponseViewModel>>(text4);
							if (list2 != null)
							{
								if (Enumerable.Any<CandooSendResponseViewModel>((IEnumerable<CandooSendResponseViewModel>)list2))
								{
									for (int k = 0; k < num6; k++)
									{
										num5 = i * num2 + k;
										string smsVmMob = list[k].recipient ?? "";
										CandooSendResponseViewModel candooSendResponseViewModel = Enumerable.FirstOrDefault<CandooSendResponseViewModel>((IEnumerable<CandooSendResponseViewModel>)list2, (Func<CandooSendResponseViewModel, bool>)((CandooSendResponseViewModel m) => (m.recipient ?? "") == smsVmMob));
										if (candooSendResponseViewModel != null)
										{
											array2[num5] = candooSendResponseViewModel.messageId.GetValueOrDefault();
										}
										num7++;
									}
								}
								else
								{
									array2[0] = -50000L;
									msgError = text5;
								}
							}
							else
							{
								array2[0] = -50000L;
								msgError = text5;
							}
						}
						else
						{
							array2[0] = -50000L;
							msgError = text5;
						}
						continue;
					}
					string text6 = Messages.msgErrorRunFunction;
					if (!string.IsNullOrWhiteSpace(text4))
					{
						CandooErrorResponseViewModel candooErrorResponseViewModel2 = JsonConvert.DeserializeObject<CandooErrorResponseViewModel>(text4);
						if (candooErrorResponseViewModel2 != null && !string.IsNullOrWhiteSpace(candooErrorResponseViewModel2.message))
						{
							text6 = text6 + " [" + candooErrorResponseViewModel2.message + " (ErrorCode = " + candooErrorResponseViewModel2.statusCode.GetValueOrDefault() + ")]";
						}
					}
					array2[0] = -50000L;
					msgError = text6;
				}
				else
				{
					array2[0] = -50000L;
					msgError = Messages.ErrorNotFound;
				}
			}
			if (array2 == null || array2[0] < 0)
			{
				result = "-50000";
				return;
			}
			result = "";
			for (int l = 0; l < array2.Length; l++)
			{
				result = result + array2[l] + ",";
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = "-50000";
			msgError = ex.Message;
		}
	}

	public void CandooSms_GetDelivery(long[] refIdArr, ref int[] result, ref string msgError, DateTime sendDate, int smsProviderId = 0)
	{
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			result = new int[Enumerable.Count<long>((IEnumerable<long>)refIdArr)];
			result[0] = -7;
			if (smsSettingInfoViewModel == null)
			{
				return;
			}
			string text = smsSettingInfoViewModel.ProviderUrl ?? "";
			string smsWsPassword = smsSettingInfoViewModel.SmsWsPassword;
			if (string.IsNullOrWhiteSpace(text))
			{
				text = "https://my.candoosms.com/";
			}
			if (!string.IsNullOrWhiteSpace(text) && !text.EndsWith("/"))
			{
				text += "/";
			}
			string text2 = sendDate.ToString("yyyy-MM-dd", new CultureInfo("en-US"));
			int num = (int)(DateTime.Now - sendDate).TotalHours;
			string text3 = text + "api/v3.0.1/get-status";
			if (num >= 48)
			{
				text3 = text + "api/v3.0.1/get-status-archive/" + text2;
			}
			HttpClient httpClient = new HttpClient();
			httpClient.BaseAddress = new Uri(text3);
			httpClient.DefaultRequestHeaders.Add("x-api-key", smsWsPassword);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			HttpContent content = new StringContent(JsonConvert.SerializeObject(refIdArr), Encoding.UTF8, "application/json");
			HttpResponseMessage result2 = httpClient.PostAsync(text3, content).Result;
			string text4 = result2.Content.ReadAsStringAsync().Result;
			if (!string.IsNullOrWhiteSpace(text4))
			{
				text4 = Common.ClearHiddenCharacters(text4);
			}
			if (result2.IsSuccessStatusCode)
			{
				string text5 = Messages.ErrorInformation;
				if (!string.IsNullOrWhiteSpace(text4))
				{
					if (text4.IndexOf("\"messageId\":", StringComparison.Ordinal) < 0)
					{
						CandooErrorResponseViewModel candooErrorResponseViewModel = JsonConvert.DeserializeObject<CandooErrorResponseViewModel>(text4);
						if (candooErrorResponseViewModel != null && !string.IsNullOrWhiteSpace(candooErrorResponseViewModel.message))
						{
							text5 = text5 + " [" + candooErrorResponseViewModel.message + " (ErrorCode = " + candooErrorResponseViewModel.statusCode.GetValueOrDefault() + ")]";
						}
						msgError = text5;
						return;
					}
					List<CandooGetStateResultesponseViewModel> list = JsonConvert.DeserializeObject<List<CandooGetStateResultesponseViewModel>>(text4);
					if (list != null)
					{
						if (!Enumerable.Any<CandooGetStateResultesponseViewModel>((IEnumerable<CandooGetStateResultesponseViewModel>)list))
						{
							return;
						}
						{
							foreach (CandooGetStateResultesponseViewModel item in list)
							{
								long valueOrDefault = item.messageId.GetValueOrDefault();
								int valueOrDefault2 = item.status.GetValueOrDefault();
								for (int i = 0; i < refIdArr.Length; i++)
								{
									bool flag = false;
									if (refIdArr[i] == valueOrDefault && !flag)
									{
										switch (valueOrDefault2)
										{
										case 1:
										case 2:
											result[i] = 2;
											break;
										case 7:
											result[i] = 16;
											break;
										default:
											result[i] = valueOrDefault2;
											break;
										}
										flag = true;
									}
								}
							}
							return;
						}
					}
					msgError = Messages.ErrorInformation;
				}
				else
				{
					msgError = text5;
				}
				return;
			}
			string text6 = Messages.ErrorInformation;
			if (!string.IsNullOrWhiteSpace(text4))
			{
				CandooErrorResponseViewModel candooErrorResponseViewModel2 = JsonConvert.DeserializeObject<CandooErrorResponseViewModel>(text4);
				if (candooErrorResponseViewModel2 != null && !string.IsNullOrWhiteSpace(candooErrorResponseViewModel2.message))
				{
					text6 = text6 + " [" + candooErrorResponseViewModel2.message + " (ErrorCode = " + candooErrorResponseViewModel2.statusCode.GetValueOrDefault() + ")]";
				}
			}
			msgError = text6;
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
		}
	}

	public ReceiveResult[] CandooSms_GetMessage_old(int smsProviderId = 0)
	{
		ReceiveResult[] result = null;
		try
		{
			SMSAPI sMSAPI = new SMSAPI();
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			ServicePointManager.Expect100Continue = true;
			ServicePointManager.DefaultConnectionLimit = 9999;
			ReceiveResult[] array = sMSAPI.ViewReceive(smsSettingInfoViewModel.SmsWsUserName, smsSettingInfoViewModel.SmsWsPassword, smsSettingInfoViewModel.SmsWsFromNumber, null);
			if (array != null)
			{
				result = array;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public List<CandooGetMessageInfoResponseViewModel> CandooSms_GetMessage(int smsProviderId = 0)
	{
		List<CandooGetMessageInfoResponseViewModel> list = new List<CandooGetMessageInfoResponseViewModel>();
		CRMEntities cRMEntities = new CRMEntities();
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			if (smsSettingInfoViewModel != null)
			{
				long result = 0L;
				MobspSelectLastSmsReceive_Result mobspSelectLastSmsReceive_Result = Enumerable.FirstOrDefault<MobspSelectLastSmsReceive_Result>((IEnumerable<MobspSelectLastSmsReceive_Result>)cRMEntities.MobspSelectLastSmsReceive());
				if (mobspSelectLastSmsReceive_Result != null)
				{
					long.TryParse(mobspSelectLastSmsReceive_Result.GetId, out result);
				}
				string text = smsSettingInfoViewModel.ProviderUrl ?? "";
				string smsWsPassword = smsSettingInfoViewModel.SmsWsPassword;
				if (string.IsNullOrWhiteSpace(text))
				{
					text = "https://my.candoosms.com/";
				}
				if (!string.IsNullOrWhiteSpace(text) && !text.EndsWith("/"))
				{
					text += "/";
				}
				bool flag = true;
				int num = 0;
				while (flag)
				{
					HttpClient httpClient = new HttpClient();
					string text2 = text + "api/v3.0.1/inbound-messages?fromId=" + result + "&page=" + num + "&size=100";
					httpClient.BaseAddress = new Uri(text2);
					httpClient.DefaultRequestHeaders.Add("x-api-key", smsWsPassword);
					httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					HttpResponseMessage result2 = httpClient.GetAsync(text2).Result;
					string text3 = result2.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text3))
					{
						text3 = Common.ClearHiddenCharacters(text3);
					}
					if (result2.IsSuccessStatusCode)
					{
						if (text3.IndexOf("\"messageId\":", StringComparison.Ordinal) < 0)
						{
							flag = false;
						}
						else if (!string.IsNullOrWhiteSpace(text3))
						{
							CandooGetMessageResponseViewModel candooGetMessageResponseViewModel = JsonConvert.DeserializeObject<CandooGetMessageResponseViewModel>(text3);
							if (candooGetMessageResponseViewModel != null)
							{
								if (num > candooGetMessageResponseViewModel.totalPages.GetValueOrDefault())
								{
									flag = false;
								}
								if (candooGetMessageResponseViewModel.inboundMessages != null)
								{
									if (Enumerable.Any<CandooGetMessageInfoResponseViewModel>((IEnumerable<CandooGetMessageInfoResponseViewModel>)candooGetMessageResponseViewModel.inboundMessages))
									{
										list.AddRange(candooGetMessageResponseViewModel.inboundMessages);
									}
									else
									{
										flag = false;
									}
								}
								else
								{
									flag = false;
								}
							}
							else
							{
								flag = false;
							}
						}
						else
						{
							flag = false;
						}
					}
					else
					{
						flag = false;
					}
					num++;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return list;
	}

	public void CandooSms_GetCredit(ref decimal credit, ref string msgError, int smsProviderId = 0)
	{
		credit = default(decimal);
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			if (smsSettingInfoViewModel == null)
			{
				return;
			}
			string text = smsSettingInfoViewModel.ProviderUrl ?? "";
			string smsWsPassword = smsSettingInfoViewModel.SmsWsPassword;
			if (string.IsNullOrWhiteSpace(text))
			{
				text = "https://my.candoosms.com/";
			}
			if (!string.IsNullOrWhiteSpace(text) && !text.EndsWith("/"))
			{
				text += "/";
			}
			HttpClient httpClient = new HttpClient();
			string text2 = text + "api/v3.0.1/balance";
			httpClient.BaseAddress = new Uri(text2);
			httpClient.DefaultRequestHeaders.Add("x-api-key", smsWsPassword);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			HttpContent content = new StringContent("", Encoding.UTF8, "application/json");
			HttpResponseMessage result = httpClient.PostAsync(text2, content).Result;
			if (result.IsSuccessStatusCode)
			{
				string text3 = result.Content.ReadAsStringAsync().Result;
				if (!string.IsNullOrWhiteSpace(text3))
				{
					text3 = Common.ClearHiddenCharacters(text3);
				}
				if (!string.IsNullOrWhiteSpace(text3))
				{
					text3 = text3.Trim();
				}
				decimal.TryParse(text3, out credit);
			}
			else
			{
				credit = default(decimal);
				msgError = Messages.ErrorInformation;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
			credit = default(decimal);
		}
	}

	public string Candoo_GetError(string errorCode)
	{
		string text = "";
		return errorCode switch
		{
			"E1" => Messages.msgErrorCandooSmsSecurityHTTPHeaderNotSet, 
			"E2" => Messages.msgErrorCandooSmsAllParametersIsRequire, 
			"E3" => Messages.msgErrorCandooSmsEnteredParametersMostBeString, 
			"E4" => Messages.msgErrorCandooSmsAccessForbidden, 
			"E5" => Messages.msgErrorCandooSmsAuthenticationFailed, 
			"E107" => Messages.msgErrorCandooSmsRequestSizeOutOfRange, 
			"E223" => Messages.msgErrorCandooSmsSourceNumberNotValid, 
			"E211" => Messages.msgErrorCandooSmsMessageLongOutOfRange, 
			"E6" => Messages.msgErrorCandooSmsNotEnoughCredit, 
			"E7" => Messages.msgErrorCandooSmsNoNewMessage, 
			"E8" => Messages.msgErrorCandooSmsIDNotCorrect, 
			"E305" => Messages.msgErrorCandooSmsMessageIDNotValid, 
			"E65" => Messages.msgErrorCandooSmsMessageIdIsRequire, 
			"E66" => Messages.msgErrorCandooSmsSrcNumberIsRequire, 
			"E43" => Messages.msgErrorCandooSmsRecipientNumberNotValid, 
			"E766" => Messages.msgErrorCandooSmsMessageBodyIsEmpty, 
			_ => errorCode ?? Messages.msgErrorRunFunction, 
		};
	}

	public void ParmisSms_SendSms1To1(string[] lstMobile, string[] body, int cmessage, string fromNumber, ref string msgError, ref long[] result, bool smsIsSendByOtherAccount = false, string smsWebServiceUserName = "", string smsWebServicePassword = "", int smsProviderId = 0)
	{
		result = new long[1];
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			string username = smsSettingInfoViewModel.SmsWsUserName;
			string password = smsSettingInfoViewModel.SmsWsPassword;
			if (smsIsSendByOtherAccount && !string.IsNullOrWhiteSpace(smsWebServiceUserName) && !string.IsNullOrWhiteSpace(smsWebServicePassword))
			{
				username = smsWebServiceUserName;
				password = smsWebServicePassword;
			}
			int num = lstMobile.Length;
			long[] array = new long[num];
			int num2 = 100;
			int num3 = num / num2;
			int num4 = num % num2;
			int num5 = 0;
			int num6 = num2;
			if (num4 != 0)
			{
				num3++;
			}
			for (int i = 0; i < num3; i++)
			{
				if (i == num3 - 1 && num4 != 0)
				{
					num6 = num4;
				}
				string[] array2 = new string[num6];
				for (int j = 0; j < num6; j++)
				{
					num5 = i * num2 + j;
					array2[j] = lstMobile[num5];
				}
				string[] array3 = new string[array2.Length];
				for (int k = 0; k < num6; k++)
				{
					num5 = i * num2 + k;
					array3[k] = body[num5];
				}
				int num7 = 0;
				ParmisSmsSendMultipleViewModel value = new ParmisSmsSendMultipleViewModel
				{
					username = username,
					password = password,
					text = array3,
					to = array2,
					from = fromNumber
				};
				HttpClient httpClient = new HttpClient();
				string text = "https://rest.payamak-panel.com/api/SendSMS/SendMultipleSMS";
				httpClient.BaseAddress = new Uri(text);
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpContent content = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");
				HttpResponseMessage result2 = httpClient.PostAsync(text, content).Result;
				if (result2.IsSuccessStatusCode)
				{
					ParmisSmsSendMultipleResponseViewModel parmisSmsSendMultipleResponseViewModel = JsonConvert.DeserializeObject<ParmisSmsSendMultipleResponseViewModel>(result2.Content.ReadAsStringAsync().Result);
					if (parmisSmsSendMultipleResponseViewModel != null)
					{
						if (parmisSmsSendMultipleResponseViewModel.Result != null)
						{
							if (Enumerable.Any<ParmisSmsSendMultipleResponseResultViewModel>((IEnumerable<ParmisSmsSendMultipleResponseResultViewModel>)parmisSmsSendMultipleResponseViewModel.Result))
							{
								foreach (ParmisSmsSendMultipleResponseResultViewModel item in parmisSmsSendMultipleResponseViewModel.Result)
								{
									long result3 = 0L;
									long.TryParse(item.ReqStatus.ToString(), out result3);
									string text2 = item.Mobile ?? "";
									long valueOrDefault = item.ReqID.GetValueOrDefault();
									if (valueOrDefault != 0L && !string.IsNullOrWhiteSpace(text2))
									{
										for (int l = 0; l < lstMobile.Length; l++)
										{
											if ((lstMobile[l] ?? "") == text2)
											{
												array[l] = valueOrDefault;
											}
										}
									}
									num7++;
								}
							}
							else
							{
								array[0] = -5000L;
								msgError = ((!string.IsNullOrEmpty(parmisSmsSendMultipleResponseViewModel.Message)) ? parmisSmsSendMultipleResponseViewModel.Message : Messages.msgErrorRunFunction);
							}
						}
						else
						{
							long result4 = 0L;
							long.TryParse(parmisSmsSendMultipleResponseViewModel.ReqStatus, out result4);
							array[0] = -5000L;
							msgError = ((!string.IsNullOrEmpty(parmisSmsSendMultipleResponseViewModel.Message)) ? parmisSmsSendMultipleResponseViewModel.Message : Messages.msgErrorRunFunction);
						}
					}
					else
					{
						array[0] = -5000L;
						msgError = Messages.msgErrorRunFunction;
					}
					continue;
				}
				msgError = Messages.msgErrorRunFunction;
				string result5 = result2.Content.ReadAsStringAsync().Result;
				if (!string.IsNullOrWhiteSpace(result5))
				{
					ParmisSmsSendMultipleResponseViewModel parmisSmsSendMultipleResponseViewModel2 = JsonConvert.DeserializeObject<ParmisSmsSendMultipleResponseViewModel>(result5);
					if (parmisSmsSendMultipleResponseViewModel2 != null)
					{
						msgError = ((!string.IsNullOrEmpty(parmisSmsSendMultipleResponseViewModel2.Message)) ? parmisSmsSendMultipleResponseViewModel2.Message : Messages.msgErrorRunFunction);
					}
				}
				array[0] = -5000L;
			}
			if (array != null)
			{
				result = new long[num];
				result = array;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result[0] = -5000L;
			msgError = ex.Message;
		}
	}

	public void ParmisSms_SendSms(string numbers, string body, int cmessage, string fromNumber, ref string msgError, ref string result, int smsProviderId = 0)
	{
		result = "0";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			_ = 3;
			string[] array = numbers.Split(new char[1] { ',' });
			int num = array.Length;
			long[] array2 = new long[num];
			int num2 = 100;
			int num3 = num / num2;
			int num4 = num % num2;
			int num5 = 0;
			int num6 = num2;
			if (num4 != 0)
			{
				num3++;
			}
			for (int i = 0; i < num3; i++)
			{
				if (i == num3 - 1 && num4 != 0)
				{
					num6 = num4;
				}
				string[] array3 = new string[num6];
				for (int j = 0; j < num6; j++)
				{
					num5 = i * num2 + j;
					array3[j] = array[num5];
				}
				string[] array4 = new string[array3.Length];
				for (int k = 0; k < num6; k++)
				{
					num5 = i * num2 + k;
					array4[k] = body;
				}
				int num7 = 0;
				ParmisSmsSendMultipleViewModel value = new ParmisSmsSendMultipleViewModel
				{
					username = smsSettingInfoViewModel.SmsWsUserName,
					password = smsSettingInfoViewModel.SmsWsPassword,
					text = array4,
					to = array3,
					from = fromNumber
				};
				HttpClient httpClient = new HttpClient();
				string text = "https://rest.payamak-panel.com/api/SendSMS/SendMultipleSMS";
				httpClient.BaseAddress = new Uri(text);
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpContent content = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");
				HttpResponseMessage result2 = httpClient.PostAsync(text, content).Result;
				if (result2.IsSuccessStatusCode)
				{
					ParmisSmsSendMultipleResponseViewModel parmisSmsSendMultipleResponseViewModel = JsonConvert.DeserializeObject<ParmisSmsSendMultipleResponseViewModel>(result2.Content.ReadAsStringAsync().Result);
					if (parmisSmsSendMultipleResponseViewModel != null)
					{
						if (parmisSmsSendMultipleResponseViewModel.Result != null)
						{
							if (Enumerable.Any<ParmisSmsSendMultipleResponseResultViewModel>((IEnumerable<ParmisSmsSendMultipleResponseResultViewModel>)parmisSmsSendMultipleResponseViewModel.Result))
							{
								foreach (ParmisSmsSendMultipleResponseResultViewModel item in parmisSmsSendMultipleResponseViewModel.Result)
								{
									long result3 = 0L;
									long.TryParse(item.ReqStatus.ToString(), out result3);
									string text2 = item.Mobile ?? "";
									long valueOrDefault = item.ReqID.GetValueOrDefault();
									if (valueOrDefault != 0L && !string.IsNullOrWhiteSpace(text2))
									{
										for (int l = 0; l < array.Length; l++)
										{
											if ((array[l] ?? "") == text2)
											{
												array2[l] = valueOrDefault;
											}
										}
									}
									num7++;
								}
							}
							else
							{
								array2[0] = -50000L;
								msgError = ((!string.IsNullOrEmpty(parmisSmsSendMultipleResponseViewModel.Message)) ? parmisSmsSendMultipleResponseViewModel.Message : Messages.msgErrorRunFunction);
							}
						}
						else
						{
							long result4 = 0L;
							long.TryParse(parmisSmsSendMultipleResponseViewModel.ReqStatus, out result4);
							array2[0] = -50000L;
							msgError = ((!string.IsNullOrEmpty(parmisSmsSendMultipleResponseViewModel.Message)) ? parmisSmsSendMultipleResponseViewModel.Message : Messages.msgErrorRunFunction);
						}
					}
					else
					{
						array2[0] = -50000L;
						msgError = Messages.msgErrorRunFunction;
					}
					continue;
				}
				msgError = Messages.msgErrorRunFunction;
				string result5 = result2.Content.ReadAsStringAsync().Result;
				if (!string.IsNullOrWhiteSpace(result5))
				{
					ParmisSmsSendMultipleResponseViewModel parmisSmsSendMultipleResponseViewModel2 = JsonConvert.DeserializeObject<ParmisSmsSendMultipleResponseViewModel>(result5);
					if (parmisSmsSendMultipleResponseViewModel2 != null)
					{
						msgError = ((!string.IsNullOrEmpty(parmisSmsSendMultipleResponseViewModel2.Message)) ? parmisSmsSendMultipleResponseViewModel2.Message : Messages.msgErrorRunFunction);
					}
				}
				array2[0] = -50000L;
			}
			if (array2 == null || array2[0] < 0)
			{
				result = "-50000";
				return;
			}
			for (int m = 0; m < array2.Length; m++)
			{
				result = result + array2[m] + ",";
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = "-50000";
			msgError = ex.Message;
		}
	}

	public void ParmisSms_SendSms_Old(string numbers, string body, int cmessage, string fromNumber, ref string msgError, ref string result, int smsProviderId = 0)
	{
		result = "0";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			bool isFlash = cmessage == 3;
			string[] array = numbers.Split(new char[1] { ',' });
			int num = array.Length;
			long[] array2 = new long[num];
			int num2 = 100;
			int num3 = num / num2;
			int num4 = num % num2;
			int num5 = 0;
			int num6 = num2;
			if (num4 != 0)
			{
				num3++;
			}
			for (int i = 0; i < num3; i++)
			{
				if (i == num3 - 1 && num4 != 0)
				{
					num6 = num4;
				}
				string text = "";
				for (int j = 0; j < num6; j++)
				{
					num5 = i * num2 + j;
					if (!string.IsNullOrWhiteSpace(text))
					{
						text += ",";
					}
					text += array[num5];
				}
				int num7 = 0;
				long result2 = 0L;
				long.TryParse(fromNumber, out result2);
				ParmisSmsSendViewModel value = new ParmisSmsSendViewModel
				{
					username = smsSettingInfoViewModel.SmsWsUserName,
					password = smsSettingInfoViewModel.SmsWsPassword,
					to = text,
					from = fromNumber,
					text = body,
					isFlash = isFlash
				};
				HttpClient httpClient = new HttpClient();
				string text2 = "https://rest.payamak-panel.com/api/SendSMS/SendSMS";
				httpClient.BaseAddress = new Uri(text2);
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpContent content = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");
				HttpResponseMessage result3 = httpClient.PostAsync(text2, content).Result;
				if (result3.IsSuccessStatusCode)
				{
					ParmisSmsSendResponseViewModel parmisSmsSendResponseViewModel = JsonConvert.DeserializeObject<ParmisSmsSendResponseViewModel>(result3.Content.ReadAsStringAsync().Result);
					if (parmisSmsSendResponseViewModel != null)
					{
						long result4 = 0L;
						long.TryParse(parmisSmsSendResponseViewModel.RetStatus.ToString(), out result4);
						if (result4 == 1)
						{
							string value2 = parmisSmsSendResponseViewModel.Value;
							if (!string.IsNullOrWhiteSpace(value2))
							{
								string[] array3 = value2.Split(new char[1] { ',' });
								if (array3 != null)
								{
									if (Enumerable.Any<string>((IEnumerable<string>)array3))
									{
										for (int k = 0; k < array3.Length; k++)
										{
											num5 = i * num2 + k;
											long result5 = 0L;
											long.TryParse(array3[k], out result5);
											array2[num5] = result5;
											num7++;
										}
									}
									else
									{
										array2[0] = -50000L;
									}
								}
								else
								{
									array2[0] = -50000L;
								}
							}
							else
							{
								array2[0] = -50000L;
								msgError = ((!string.IsNullOrEmpty(parmisSmsSendResponseViewModel.StrRetStatus)) ? parmisSmsSendResponseViewModel.StrRetStatus : Messages.msgErrorRunFunction);
							}
						}
						else
						{
							array2[0] = -50000L;
							msgError = ((!string.IsNullOrEmpty(parmisSmsSendResponseViewModel.StrRetStatus)) ? parmisSmsSendResponseViewModel.StrRetStatus : Messages.msgErrorRunFunction);
						}
					}
					else
					{
						array2[0] = -50000L;
						msgError = Messages.msgErrorRunFunction;
					}
					continue;
				}
				msgError = Messages.msgErrorRunFunction;
				string result6 = result3.Content.ReadAsStringAsync().Result;
				if (!string.IsNullOrWhiteSpace(result6))
				{
					ParmisSmsSendResponseViewModel parmisSmsSendResponseViewModel2 = JsonConvert.DeserializeObject<ParmisSmsSendResponseViewModel>(result6);
					if (parmisSmsSendResponseViewModel2 != null)
					{
						msgError = ((!string.IsNullOrEmpty(parmisSmsSendResponseViewModel2.StrRetStatus)) ? parmisSmsSendResponseViewModel2.StrRetStatus : Messages.msgErrorRunFunction);
					}
				}
				array2[0] = -50000L;
			}
			if (array2 == null || array2[0] < 0)
			{
				result = "-50000";
				return;
			}
			for (int l = 0; l < array2.Length; l++)
			{
				result = result + array2[l] + ",";
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = "-50000";
			msgError = ex.Message;
		}
	}

	public bool ParmisSms_GetDelivery(long[] refIdArr, ref int[] result, ref string msgError, int smsProviderId = 0)
	{
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			result = new int[Enumerable.Count<long>((IEnumerable<long>)refIdArr)];
			result[0] = -7;
			if (smsSettingInfoViewModel != null)
			{
				for (int i = 0; i < refIdArr.Length; i++)
				{
					ParmisSmsDeliveryViewModel value = new ParmisSmsDeliveryViewModel
					{
						username = smsSettingInfoViewModel.SmsWsUserName,
						password = smsSettingInfoViewModel.SmsWsPassword,
						recID = refIdArr[i]
					};
					HttpClient httpClient = new HttpClient();
					string text = "https://rest.payamak-panel.com/api/SendSMS/GetDeliveries2";
					httpClient.BaseAddress = new Uri(text);
					httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					HttpContent content = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");
					HttpResponseMessage result2 = httpClient.PostAsync(text, content).Result;
					if (result2.IsSuccessStatusCode)
					{
						ParmisSmsDeliveryResponseViewModel parmisSmsDeliveryResponseViewModel = JsonConvert.DeserializeObject<ParmisSmsDeliveryResponseViewModel>(result2.Content.ReadAsStringAsync().Result);
						if (parmisSmsDeliveryResponseViewModel != null)
						{
							long result3 = 0L;
							long.TryParse(parmisSmsDeliveryResponseViewModel.RetStatus.ToString(), out result3);
							string value2 = parmisSmsDeliveryResponseViewModel.Value;
							int result4 = 0;
							if (!string.IsNullOrWhiteSpace(value2))
							{
								int.TryParse(value2, out result4);
							}
							if (result3 == 1 || result4 != 0)
							{
								switch (result4)
								{
								case 1:
								case 200:
									result[i] = 2;
									break;
								case 2:
									result[i] = 3;
									break;
								case 8:
									result[i] = 1;
									break;
								case 16:
									result[i] = 16;
									break;
								case 35:
									result[i] = 4;
									break;
								default:
									result[i] = result4;
									break;
								}
								continue;
							}
							msgError = ((!string.IsNullOrEmpty(parmisSmsDeliveryResponseViewModel.StrRetStatus)) ? parmisSmsDeliveryResponseViewModel.StrRetStatus : Messages.ErrorInformation);
							return false;
						}
						msgError = Messages.msgErrorRunFunction;
						return false;
					}
					msgError = Messages.msgErrorRunFunction;
					string result5 = result2.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(result5))
					{
						ParmisSmsDeliveryResponseViewModel parmisSmsDeliveryResponseViewModel2 = JsonConvert.DeserializeObject<ParmisSmsDeliveryResponseViewModel>(result5);
						if (parmisSmsDeliveryResponseViewModel2 != null)
						{
							msgError = ((!string.IsNullOrEmpty(parmisSmsDeliveryResponseViewModel2.StrRetStatus)) ? parmisSmsDeliveryResponseViewModel2.StrRetStatus : Messages.msgErrorRunFunction);
						}
					}
					return false;
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
		}
		return true;
	}

	public void ParmisSms_GetCredit(ref decimal credit, ref string msgError, int smsProviderId = 0)
	{
		credit = default(decimal);
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			ParmisSmsCreditViewModel value = new ParmisSmsCreditViewModel
			{
				username = smsSettingInfoViewModel.SmsWsUserName,
				password = smsSettingInfoViewModel.SmsWsPassword
			};
			HttpClient httpClient = new HttpClient();
			string text = "https://rest.payamak-panel.com/api/SendSMS/GetCredit2";
			httpClient.BaseAddress = new Uri(text);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			HttpContent content = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");
			HttpResponseMessage result = httpClient.PostAsync(text, content).Result;
			if (result.IsSuccessStatusCode)
			{
				ParmisSmsCreditResponseViewModel parmisSmsCreditResponseViewModel = JsonConvert.DeserializeObject<ParmisSmsCreditResponseViewModel>(result.Content.ReadAsStringAsync().Result);
				if (parmisSmsCreditResponseViewModel != null)
				{
					long result2 = 0L;
					long.TryParse(parmisSmsCreditResponseViewModel.RetStatus.ToString(), out result2);
					if (result2 == 1)
					{
						string value2 = parmisSmsCreditResponseViewModel.Value;
						if (!string.IsNullOrWhiteSpace(value2))
						{
							decimal result3 = default(decimal);
							decimal.TryParse(value2, out result3);
							credit = result3;
						}
						else
						{
							credit = default(decimal);
							msgError = ((!string.IsNullOrEmpty(parmisSmsCreditResponseViewModel.StrRetStatus)) ? parmisSmsCreditResponseViewModel.StrRetStatus : Messages.ErrorInformation);
						}
					}
					else
					{
						credit = default(decimal);
						msgError = ((!string.IsNullOrEmpty(parmisSmsCreditResponseViewModel.StrRetStatus)) ? parmisSmsCreditResponseViewModel.StrRetStatus : Messages.ErrorInformation);
					}
				}
				else
				{
					credit = default(decimal);
					msgError = Messages.msgErrorRunFunction;
				}
				return;
			}
			msgError = Messages.msgErrorRunFunction;
			string result4 = result.Content.ReadAsStringAsync().Result;
			if (!string.IsNullOrWhiteSpace(result4))
			{
				ParmisSmsCreditResponseViewModel parmisSmsCreditResponseViewModel2 = JsonConvert.DeserializeObject<ParmisSmsCreditResponseViewModel>(result4);
				if (parmisSmsCreditResponseViewModel2 != null)
				{
					msgError = ((!string.IsNullOrEmpty(parmisSmsCreditResponseViewModel2.StrRetStatus)) ? parmisSmsCreditResponseViewModel2.StrRetStatus : Messages.msgErrorRunFunction);
				}
			}
			credit = default(decimal);
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
			credit = default(decimal);
		}
	}

	public List<ParmisSmsGetMessageInfoResponseViewModel> ParmisSms_ReceiveSms(int smsProviderId = 0)
	{
		List<ParmisSmsGetMessageInfoResponseViewModel> list = new List<ParmisSmsGetMessageInfoResponseViewModel>();
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			bool flag = true;
			int num = 0;
			while (flag)
			{
				ParmisSmsGetMessageViewModel value = new ParmisSmsGetMessageViewModel
				{
					username = smsSettingInfoViewModel.SmsWsUserName,
					password = smsSettingInfoViewModel.SmsWsPassword,
					location = 1,
					from = smsSettingInfoViewModel.SmsWsFromNumber,
					index = num,
					count = 100
				};
				HttpClient httpClient = new HttpClient();
				string text = "https://rest.payamak-panel.com/api/SendSMS/GetMessages";
				httpClient.BaseAddress = new Uri(text);
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpContent content = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");
				HttpResponseMessage result = httpClient.PostAsync(text, content).Result;
				if (result.IsSuccessStatusCode)
				{
					ParmisSmsGetMessageResponseViewModel parmisSmsGetMessageResponseViewModel = JsonConvert.DeserializeObject<ParmisSmsGetMessageResponseViewModel>(result.Content.ReadAsStringAsync().Result);
					if (parmisSmsGetMessageResponseViewModel != null)
					{
						if (parmisSmsGetMessageResponseViewModel.MyBase != null)
						{
							long result2 = 0L;
							long.TryParse(parmisSmsGetMessageResponseViewModel.MyBase.RetStatus.ToString(), out result2);
							if (result2 == 1)
							{
								List<ParmisSmsGetMessageInfoResponseViewModel> data = parmisSmsGetMessageResponseViewModel.Data;
								if (data != null)
								{
									if (Enumerable.Any<ParmisSmsGetMessageInfoResponseViewModel>((IEnumerable<ParmisSmsGetMessageInfoResponseViewModel>)data))
									{
										list.AddRange(data);
									}
									else
									{
										flag = false;
									}
								}
								else
								{
									flag = false;
								}
							}
							else
							{
								flag = false;
							}
						}
						else
						{
							flag = false;
						}
					}
					else
					{
						flag = false;
					}
				}
				else
				{
					flag = false;
				}
				num += 100;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public void SmsMelli_SendSms1To1(string[] lstMobile, string[] body, int cmessage, string fromNumber, ref string msgError, ref long[] result, bool smsIsSendByOtherAccount = false, string smsWebServiceUserName = "", string smsWebServicePassword = "", int smsProviderId = 0)
	{
		result = new long[1];
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			string uname = smsSettingInfoViewModel.SmsWsUserName;
			string pass = smsSettingInfoViewModel.SmsWsPassword;
			if (smsIsSendByOtherAccount && !string.IsNullOrWhiteSpace(smsWebServiceUserName) && !string.IsNullOrWhiteSpace(smsWebServicePassword))
			{
				uname = smsWebServiceUserName;
				pass = smsWebServicePassword;
			}
			int num = lstMobile.Length;
			long[] array = new long[num];
			int num2 = 100;
			int num3 = num / num2;
			int num4 = num % num2;
			int num5 = 0;
			int num6 = num2;
			if (num4 != 0)
			{
				num3++;
			}
			for (int i = 0; i < num3; i++)
			{
				if (i == num3 - 1 && num4 != 0)
				{
					num6 = num4;
				}
				string[] array2 = new string[num6];
				for (int j = 0; j < num6; j++)
				{
					num5 = i * num2 + j;
					array2[j] = lstMobile[num5];
				}
				string[] array3 = new string[array2.Length];
				for (int k = 0; k < num6; k++)
				{
					num5 = i * num2 + k;
					array3[k] = body[num5];
				}
				int num7 = 0;
				List<SmsMelliContentSendManyToManyViewModel> list = new List<SmsMelliContentSendManyToManyViewModel>();
				string value = "";
				for (int l = 0; l < array2.Length; l++)
				{
					SmsMelliContentSendManyToManyViewModel item = new SmsMelliContentSendManyToManyViewModel
					{
						to = array2[l],
						msg = array3[l]
					};
					list.Add(item);
				}
				if (list != null && Enumerable.Any<SmsMelliContentSendManyToManyViewModel>((IEnumerable<SmsMelliContentSendManyToManyViewModel>)list))
				{
					value = JsonConvert.SerializeObject(Enumerable.ToList<SmsMelliContentSendManyToManyViewModel>((IEnumerable<SmsMelliContentSendManyToManyViewModel>)list));
				}
				if (!string.IsNullOrWhiteSpace(value) && list != null)
				{
					SmsMelliSendManyToManyViewModel value2 = new SmsMelliSendManyToManyViewModel
					{
						uname = uname,
						pass = pass,
						from = fromNumber,
						content = list
					};
					HttpClient httpClient = new HttpClient();
					string text = "http://mysmsapi.ir/class/sms/restful/sendSms_ManyToMany_v2.php";
					httpClient.BaseAddress = new Uri(text);
					httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					HttpContent content = new StringContent(JsonConvert.SerializeObject(value2), Encoding.UTF8, "application/json");
					HttpResponseMessage result2 = httpClient.PostAsync(text, content).Result;
					if (result2.IsSuccessStatusCode)
					{
						string result3 = result2.Content.ReadAsStringAsync().Result;
						if (result3.IndexOf("::", StringComparison.Ordinal) >= 0 || result3.IndexOf("msgId", StringComparison.Ordinal) <= 0)
						{
							SmsMelliErrorResponseViewModel smsMelliErrorResponseViewModel = JsonConvert.DeserializeObject<SmsMelliErrorResponseViewModel>(result3);
							if (smsMelliErrorResponseViewModel != null)
							{
								long result4 = 0L;
								long.TryParse(smsMelliErrorResponseViewModel.errCode.ToString(), out result4);
								array[0] = -5000L;
								msgError = ((!string.IsNullOrEmpty(smsMelliErrorResponseViewModel.result)) ? (smsMelliErrorResponseViewModel.result + " (ErrorCode= " + result4 + ")") : Messages.ErrorInformation);
							}
							else
							{
								array[0] = -5000L;
								msgError = Messages.msgErrorRunFunction;
							}
							continue;
						}
						SmsMelliSendManyToManyResponseViewModel smsMelliSendManyToManyResponseViewModel = JsonConvert.DeserializeObject<SmsMelliSendManyToManyResponseViewModel>(result3);
						if (smsMelliSendManyToManyResponseViewModel != null)
						{
							long result5 = 0L;
							long.TryParse(smsMelliSendManyToManyResponseViewModel.errCode.ToString(), out result5);
							string[] result6 = smsMelliSendManyToManyResponseViewModel.result;
							if (result5 == 0L || result6 != null)
							{
								if (result6.Length != 0)
								{
									for (int m = 0; m < array2.Length; m++)
									{
										num5 = i * num2 + m;
										long result7 = 0L;
										long.TryParse(result6[m].ToString(), out result7);
										array[num5] = result7;
										num7++;
									}
								}
								else
								{
									array[0] = -5000L;
									msgError = Messages.msgErrorRunFunction;
								}
							}
							else
							{
								array[0] = -5000L;
								msgError = Messages.msgErrorRunFunction;
							}
						}
						else
						{
							array[0] = -5000L;
							msgError = Messages.msgErrorRunFunction;
						}
					}
					else
					{
						msgError = Messages.msgErrorRunFunction;
						array[0] = -5000L;
					}
				}
				else
				{
					array[0] = -5000L;
					msgError = Messages.msgErrorRunFunction;
				}
			}
			if (array != null)
			{
				result = new long[num];
				result = array;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result[0] = -5000L;
			msgError = ex.Message;
		}
	}

	public void SmsMelli_SendSms(string numbers, string body, int cmessage, string fromNumber, ref string msgError, ref string result, int smsProviderId = 0)
	{
		result = "0";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			_ = 3;
			string[] array = numbers.Split(new char[1] { ',' });
			int num = array.Length;
			long[] array2 = new long[num];
			int num2 = 100;
			int num3 = num / num2;
			int num4 = num % num2;
			int num5 = 0;
			int num6 = num2;
			if (num4 != 0)
			{
				num3++;
			}
			for (int i = 0; i < num3; i++)
			{
				if (i == num3 - 1 && num4 != 0)
				{
					num6 = num4;
				}
				string[] array3 = new string[num6];
				for (int j = 0; j < num6; j++)
				{
					num5 = i * num2 + j;
					array3[j] = array[num5];
				}
				int num7 = 0;
				SmsMelliSendOneToManyViewModel value = new SmsMelliSendOneToManyViewModel
				{
					uname = smsSettingInfoViewModel.SmsWsUserName,
					pass = smsSettingInfoViewModel.SmsWsPassword,
					from = fromNumber,
					msg = body,
					to = array3
				};
				HttpClient httpClient = new HttpClient();
				string text = "http://mysmsapi.ir/class/sms/restful/sendSms_OneToMany.php";
				httpClient.BaseAddress = new Uri(text);
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpContent content = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");
				HttpResponseMessage result2 = httpClient.PostAsync(text, content).Result;
				if (result2.IsSuccessStatusCode)
				{
					string result3 = result2.Content.ReadAsStringAsync().Result;
					if (result3.IndexOf("::", StringComparison.Ordinal) >= 0 || result3.IndexOf("msgId", StringComparison.Ordinal) <= 0)
					{
						SmsMelliErrorResponseViewModel smsMelliErrorResponseViewModel = JsonConvert.DeserializeObject<SmsMelliErrorResponseViewModel>(result3);
						if (smsMelliErrorResponseViewModel != null)
						{
							long result4 = 0L;
							long.TryParse(smsMelliErrorResponseViewModel.errCode.ToString(), out result4);
							array2[0] = -50000L;
							msgError = ((!string.IsNullOrEmpty(smsMelliErrorResponseViewModel.result)) ? (smsMelliErrorResponseViewModel.result + " (ErrorCode= " + result4 + ")") : Messages.ErrorInformation);
						}
						else
						{
							array2[0] = -50000L;
							msgError = Messages.msgErrorRunFunction;
						}
						continue;
					}
					SmsMelliSendOneToManyResponseViewModel smsMelliSendOneToManyResponseViewModel = JsonConvert.DeserializeObject<SmsMelliSendOneToManyResponseViewModel>(result3);
					if (smsMelliSendOneToManyResponseViewModel != null)
					{
						long result5 = 0L;
						long.TryParse(smsMelliSendOneToManyResponseViewModel.errCode.ToString(), out result5);
						string[] result6 = smsMelliSendOneToManyResponseViewModel.result;
						if (result5 == 0L || result6 != null)
						{
							if (result6.Length != 0)
							{
								for (int k = 0; k < array3.Length; k++)
								{
									num5 = i * num2 + k;
									long result7 = 0L;
									long.TryParse(result6[k].ToString(), out result7);
									array2[num5] = result7;
									num7++;
								}
							}
							else
							{
								array2[0] = -50000L;
								msgError = Messages.msgErrorRunFunction;
							}
						}
						else
						{
							array2[0] = -50000L;
							msgError = Messages.msgErrorRunFunction;
						}
					}
					else
					{
						array2[0] = -50000L;
						msgError = Messages.msgErrorRunFunction;
					}
				}
				else
				{
					msgError = Messages.msgErrorRunFunction;
					array2[0] = -50000L;
				}
			}
			if (array2 == null || array2[0] < 0)
			{
				result = "-50000";
				return;
			}
			for (int l = 0; l < array2.Length; l++)
			{
				result = result + array2[l] + ",";
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = "-50000";
			msgError = ex.Message;
		}
	}

	public bool SmsMelli_GetDelivery(long[] refIdArr, ref int[] result, ref string msgError, int smsProviderId = 0)
	{
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			result = new int[Enumerable.Count<long>((IEnumerable<long>)refIdArr)];
			result[0] = -7;
			if (smsSettingInfoViewModel != null)
			{
				for (int i = 0; i < refIdArr.Length; i++)
				{
					if (refIdArr[i] == 0L)
					{
						continue;
					}
					SmsMelliDeliveryViewModel value = new SmsMelliDeliveryViewModel
					{
						uname = smsSettingInfoViewModel.SmsWsUserName,
						pass = smsSettingInfoViewModel.SmsWsPassword,
						uniqueID = refIdArr[i]
					};
					HttpClient httpClient = new HttpClient();
					string text = "http://mysmsapi.ir/class/sms/restful/getStatus.php";
					httpClient.BaseAddress = new Uri(text);
					httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					HttpContent content = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");
					HttpResponseMessage result2 = httpClient.PostAsync(text, content).Result;
					if (result2.IsSuccessStatusCode)
					{
						string result3 = result2.Content.ReadAsStringAsync().Result;
						if (result3.IndexOf("::", StringComparison.Ordinal) >= 0 || result3.IndexOf("statusId", StringComparison.Ordinal) <= 0)
						{
							SmsMelliErrorResponseViewModel smsMelliErrorResponseViewModel = JsonConvert.DeserializeObject<SmsMelliErrorResponseViewModel>(result3);
							if (smsMelliErrorResponseViewModel != null)
							{
								long result4 = 0L;
								long.TryParse(smsMelliErrorResponseViewModel.errCode.ToString(), out result4);
								msgError = ((!string.IsNullOrEmpty(smsMelliErrorResponseViewModel.result)) ? (smsMelliErrorResponseViewModel.result + " (ErrorCode= " + result4 + ")") : Messages.ErrorInformation);
								return false;
							}
							msgError = Messages.msgErrorRunFunction;
							return false;
						}
						SmsMelliDeliveryResponseViewModel smsMelliDeliveryResponseViewModel = JsonConvert.DeserializeObject<SmsMelliDeliveryResponseViewModel>(result3);
						if (smsMelliDeliveryResponseViewModel != null)
						{
							long result5 = 0L;
							long.TryParse(smsMelliDeliveryResponseViewModel.errCode.ToString(), out result5);
							SmsMelliDeliveryStatusResponseViewModel result6 = smsMelliDeliveryResponseViewModel.result;
							if (result5 == 0L || result6 != null)
							{
								if ((result6.statusId ?? "").ToLower().IndexOf("e", StringComparison.Ordinal) < 0)
								{
									int result7 = 0;
									int.TryParse(result6.statusId ?? "", out result7);
									switch (result7)
									{
									case 4:
										result[i] = 2;
										break;
									case 5:
										result[i] = 3;
										break;
									case 3:
										result[i] = 1;
										break;
									case 2:
										result[i] = 16;
										break;
									case 6:
										result[i] = 4;
										break;
									default:
										result[i] = result7;
										break;
									}
								}
								else
								{
									result[i] = 16;
								}
								continue;
							}
							msgError = Messages.msgErrorRunFunction ?? "";
							return false;
						}
						msgError = Messages.msgErrorRunFunction;
						return false;
					}
					msgError = Messages.msgErrorRunFunction;
					return false;
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
		}
		return true;
	}

	public void SmsMelli_GetCredit(ref decimal credit, ref string msgError, int smsProviderId = 0)
	{
		credit = default(decimal);
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			SmsMelliCreditViewModel value = new SmsMelliCreditViewModel
			{
				uname = smsSettingInfoViewModel.SmsWsUserName,
				pass = smsSettingInfoViewModel.SmsWsPassword
			};
			HttpClient httpClient = new HttpClient();
			string text = "http://mysmsapi.ir/class/sms/restful/getData.php";
			httpClient.BaseAddress = new Uri(text);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			HttpContent content = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");
			HttpResponseMessage result = httpClient.PostAsync(text, content).Result;
			if (result.IsSuccessStatusCode)
			{
				string result2 = result.Content.ReadAsStringAsync().Result;
				if (!string.IsNullOrWhiteSpace(result2))
				{
					if (result2.IndexOf("::", StringComparison.Ordinal) >= 0)
					{
						SmsMelliErrorResponseViewModel smsMelliErrorResponseViewModel = JsonConvert.DeserializeObject<SmsMelliErrorResponseViewModel>(result2);
						if (smsMelliErrorResponseViewModel != null)
						{
							credit = default(decimal);
							long result3 = 0L;
							long.TryParse(smsMelliErrorResponseViewModel.errCode.ToString(), out result3);
							credit = default(decimal);
							msgError = ((!string.IsNullOrEmpty(smsMelliErrorResponseViewModel.result)) ? (smsMelliErrorResponseViewModel.result + " (ErrorCode= " + result3 + ")") : Messages.ErrorInformation);
						}
						else
						{
							credit = default(decimal);
							msgError = Messages.msgErrorRunFunction;
						}
						return;
					}
					SmsMelliCreditResponseViewModel smsMelliCreditResponseViewModel = JsonConvert.DeserializeObject<SmsMelliCreditResponseViewModel>(result2);
					if (smsMelliCreditResponseViewModel != null)
					{
						long result4 = 0L;
						long.TryParse(smsMelliCreditResponseViewModel.errCode.ToString(), out result4);
						if (result4 == 0L || smsMelliCreditResponseViewModel.result != null)
						{
							decimal result5 = default(decimal);
							decimal.TryParse(smsMelliCreditResponseViewModel.result.credit.ToString(), out result5);
							credit = result5;
						}
						else
						{
							credit = default(decimal);
							msgError = Messages.msgErrorRunFunction + " (ErrorCode= " + result4 + ")";
						}
					}
					else
					{
						credit = default(decimal);
						msgError = Messages.msgErrorRunFunction;
					}
				}
				else
				{
					credit = default(decimal);
					msgError = Messages.msgErrorRunFunction;
				}
			}
			else
			{
				msgError = Messages.msgErrorRunFunction;
				credit = default(decimal);
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
			credit = default(decimal);
		}
	}

	public List<SmsMelliGetMessageInfoResponseViewModel> SmsMelli_ReceiveSms(int smsProviderId = 0)
	{
		List<SmsMelliGetMessageInfoResponseViewModel> list = new List<SmsMelliGetMessageInfoResponseViewModel>();
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SmsMelliGetMessageViewModel value = new SmsMelliGetMessageViewModel
			{
				uname = smsSettingInfoViewModel.SmsWsUserName,
				pass = smsSettingInfoViewModel.SmsWsPassword,
				from = smsSettingInfoViewModel.SmsWsFromNumber
			};
			HttpClient httpClient = new HttpClient();
			string text = "http://mysmsapi.ir/class/sms/restful/getMessages.php";
			httpClient.BaseAddress = new Uri(text);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			HttpContent content = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");
			HttpResponseMessage result = httpClient.PostAsync(text, content).Result;
			if (result.IsSuccessStatusCode)
			{
				string result2 = result.Content.ReadAsStringAsync().Result;
				if (result2.IndexOf("::", StringComparison.Ordinal) >= 0)
				{
					SmsMelliErrorResponseViewModel smsMelliErrorResponseViewModel = JsonConvert.DeserializeObject<SmsMelliErrorResponseViewModel>(result2);
					if (smsMelliErrorResponseViewModel != null)
					{
						long result3 = 0L;
						long.TryParse(smsMelliErrorResponseViewModel.errCode.ToString(), out result3);
						if (string.IsNullOrEmpty(smsMelliErrorResponseViewModel.result))
						{
							_ = Messages.ErrorInformation;
						}
						else
						{
							_ = smsMelliErrorResponseViewModel.result + " (ErrorCode= " + result3 + ")";
						}
					}
				}
				else
				{
					SmsMelliGetMessageResponseViewModel smsMelliGetMessageResponseViewModel = JsonConvert.DeserializeObject<SmsMelliGetMessageResponseViewModel>(result2);
					if (smsMelliGetMessageResponseViewModel != null)
					{
						long result4 = 0L;
						long.TryParse(smsMelliGetMessageResponseViewModel.errCode.ToString(), out result4);
						List<SmsMelliGetMessageInfoResponseViewModel> result5 = smsMelliGetMessageResponseViewModel.result;
						if ((result4 == 0L || result5 != null) && Enumerable.Any<SmsMelliGetMessageInfoResponseViewModel>((IEnumerable<SmsMelliGetMessageInfoResponseViewModel>)result5))
						{
							list.AddRange(result5);
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public void ParsGreen_SendSms1To1(string[] lstMobile, string[] body, int cmessage, string fromNumber, ref string msgError, ref long[] result, bool smsIsSendByOtherAccount = false, string smsWebServiceUserName = "", string smsWebServicePassword = "", int smsProviderId = 0)
	{
		result = new long[1];
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			_ = smsSettingInfoViewModel.SmsWsUserName;
			string text = smsSettingInfoViewModel.SmsWsPassword;
			if (smsIsSendByOtherAccount && !string.IsNullOrWhiteSpace(smsWebServiceUserName) && !string.IsNullOrWhiteSpace(smsWebServicePassword))
			{
				text = smsWebServicePassword;
			}
			int num = lstMobile.Length;
			long[] array = new long[num];
			int num2 = 100;
			int num3 = num / num2;
			int num4 = num % num2;
			int num5 = 0;
			int num6 = num2;
			if (num4 != 0)
			{
				num3++;
			}
			for (int i = 0; i < num3; i++)
			{
				if (i == num3 - 1 && num4 != 0)
				{
					num6 = num4;
				}
				string[] array2 = new string[num6];
				for (int j = 0; j < num6; j++)
				{
					num5 = i * num2 + j;
					array2[j] = lstMobile[num5];
				}
				string[] array3 = new string[array2.Length];
				for (int k = 0; k < num6; k++)
				{
					num5 = i * num2 + k;
					array3[k] = body[num5];
				}
				List<ParsGreenItemSendMultipleViewModel> list = new List<ParsGreenItemSendMultipleViewModel>();
				string value = "";
				for (int l = 0; l < array2.Length; l++)
				{
					ParsGreenItemSendMultipleViewModel item = new ParsGreenItemSendMultipleViewModel
					{
						Mobile = array2[l],
						SmsBody = array3[l],
						SmsNumber = fromNumber
					};
					list.Add(item);
				}
				if (list != null && Enumerable.Any<ParsGreenItemSendMultipleViewModel>((IEnumerable<ParsGreenItemSendMultipleViewModel>)list))
				{
					value = JsonConvert.SerializeObject(Enumerable.ToList<ParsGreenItemSendMultipleViewModel>((IEnumerable<ParsGreenItemSendMultipleViewModel>)list));
				}
				if (!string.IsNullOrWhiteSpace(value) && list != null)
				{
					ParsGreenSendMultipleViewModel value2 = new ParsGreenSendMultipleViewModel
					{
						Items = list
					};
					string value3 = "basic apikey:" + text;
					HttpClient httpClient = new HttpClient();
					string text2 = "https://sms.parsgreen.ir/Apiv2/Message/SendMultiple";
					httpClient.DefaultRequestHeaders.Add("Authorization", value3);
					httpClient.BaseAddress = new Uri(text2);
					httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					HttpContent content = new StringContent(JsonConvert.SerializeObject(value2), Encoding.UTF8, "application/json");
					HttpResponseMessage result2 = httpClient.PostAsync(text2, content).Result;
					if (result2.IsSuccessStatusCode)
					{
						string result3 = result2.Content.ReadAsStringAsync().Result;
						if (string.IsNullOrWhiteSpace(result3))
						{
							continue;
						}
						ParsGreenSendMultipleResponseViewModel parsGreenSendMultipleResponseViewModel = JsonConvert.DeserializeObject<ParsGreenSendMultipleResponseViewModel>(result3);
						if (parsGreenSendMultipleResponseViewModel != null)
						{
							long result4 = 0L;
							long.TryParse(parsGreenSendMultipleResponseViewModel.R_Code.ToString(), out result4);
							bool result5 = false;
							bool.TryParse(parsGreenSendMultipleResponseViewModel.R_Success.ToString(), out result5);
							List<ParsGreenSendMultipleDataListResponseViewModel> dataList = parsGreenSendMultipleResponseViewModel.DataList;
							if (result5)
							{
								if (dataList != null)
								{
									if (Enumerable.Any<ParsGreenSendMultipleDataListResponseViewModel>((IEnumerable<ParsGreenSendMultipleDataListResponseViewModel>)dataList))
									{
										foreach (ParsGreenSendMultipleDataListResponseViewModel item2 in dataList)
										{
											string text3 = item2.Mobile ?? "";
											long result6 = 0L;
											long.TryParse(item2.ReqID ?? "", out result6);
											if (string.IsNullOrWhiteSpace(text3))
											{
												continue;
											}
											for (int m = 0; m < lstMobile.Length; m++)
											{
												if ((lstMobile[m] ?? "") == text3)
												{
													array[m] = result6;
												}
											}
										}
									}
									else
									{
										array[0] = -5000L;
										msgError = Messages.msgErrorRunFunction;
									}
								}
								else
								{
									array[0] = -5000L;
									msgError = Messages.msgErrorRunFunction;
								}
							}
							else
							{
								array[0] = -5000L;
								msgError = ((!string.IsNullOrWhiteSpace(parsGreenSendMultipleResponseViewModel.R_Error ?? parsGreenSendMultipleResponseViewModel.R_Message)) ? (parsGreenSendMultipleResponseViewModel.R_Error ?? parsGreenSendMultipleResponseViewModel.R_Message) : Messages.msgErrorRunFunction) + " (ErrorCode= " + result4 + ")";
							}
						}
						else
						{
							array[0] = -5000L;
							msgError = Messages.msgErrorRunFunction;
						}
						continue;
					}
					string result7 = result2.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(result7))
					{
						ParsGreenErrorResponseViewModel parsGreenErrorResponseViewModel = JsonConvert.DeserializeObject<ParsGreenErrorResponseViewModel>(result7);
						if (parsGreenErrorResponseViewModel != null)
						{
							long result8 = 0L;
							long.TryParse(parsGreenErrorResponseViewModel.R_Code.ToString(), out result8);
							bool result9 = false;
							bool.TryParse(parsGreenErrorResponseViewModel.R_Success.ToString(), out result9);
							if (!result9)
							{
								array[0] = -5000L;
								msgError = ((!string.IsNullOrWhiteSpace(parsGreenErrorResponseViewModel.R_Error ?? parsGreenErrorResponseViewModel.R_Message)) ? (parsGreenErrorResponseViewModel.R_Error ?? parsGreenErrorResponseViewModel.R_Message) : Messages.msgErrorRunFunction) + " (ErrorCode = " + result8 + ")";
							}
						}
						else
						{
							array[0] = -5000L;
							msgError = Messages.msgErrorRunFunction;
						}
					}
					else
					{
						array[0] = -5000L;
						msgError = Messages.msgErrorRunFunction;
					}
				}
				else
				{
					array[0] = -5000L;
					msgError = Messages.msgErrorRunFunction;
				}
			}
			if (array != null)
			{
				result = new long[num];
				result = array;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result[0] = -5000L;
			msgError = ex.Message;
		}
	}

	public void ParsGreen_SendSms(string numbers, string body, int cmessage, string fromNumber, ref string msgError, ref string result, int smsProviderId = 0)
	{
		result = "0";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			_ = 3;
			string[] array = numbers.Split(new char[1] { ',' });
			int num = array.Length;
			long[] array2 = new long[num];
			int num2 = 100;
			int num3 = num / num2;
			int num4 = num % num2;
			int num5 = 0;
			int num6 = num2;
			if (num4 != 0)
			{
				num3++;
			}
			for (int i = 0; i < num3; i++)
			{
				if (i == num3 - 1 && num4 != 0)
				{
					num6 = num4;
				}
				string[] array3 = new string[num6];
				for (int j = 0; j < num6; j++)
				{
					num5 = i * num2 + j;
					array3[j] = array[num5];
				}
				ParsGreenSendSmsViewModel value = new ParsGreenSendSmsViewModel
				{
					SmsBody = body,
					Mobiles = array3,
					SmsNumber = fromNumber
				};
				string value2 = "basic apikey:" + smsSettingInfoViewModel.SmsWsPassword;
				HttpClient httpClient = new HttpClient();
				string text = "https://sms.parsgreen.ir/Apiv2/Message/SendSms";
				httpClient.DefaultRequestHeaders.Add("Authorization", value2);
				httpClient.BaseAddress = new Uri(text);
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpContent content = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");
				HttpResponseMessage result2 = httpClient.PostAsync(text, content).Result;
				if (result2.IsSuccessStatusCode)
				{
					string result3 = result2.Content.ReadAsStringAsync().Result;
					if (string.IsNullOrWhiteSpace(result3))
					{
						continue;
					}
					ParsGreenSendSmsResponseViewModel parsGreenSendSmsResponseViewModel = JsonConvert.DeserializeObject<ParsGreenSendSmsResponseViewModel>(result3);
					if (parsGreenSendSmsResponseViewModel != null)
					{
						long result4 = 0L;
						long.TryParse(parsGreenSendSmsResponseViewModel.R_Code.ToString(), out result4);
						bool result5 = false;
						bool.TryParse(parsGreenSendSmsResponseViewModel.R_Success.ToString(), out result5);
						List<ParsGreenSendSmsDataListResponseViewModel> dataList = parsGreenSendSmsResponseViewModel.DataList;
						if (result5)
						{
							if (dataList != null)
							{
								if (Enumerable.Any<ParsGreenSendSmsDataListResponseViewModel>((IEnumerable<ParsGreenSendSmsDataListResponseViewModel>)dataList))
								{
									foreach (ParsGreenSendSmsDataListResponseViewModel item in dataList)
									{
										string text2 = item.Mobile ?? "";
										long result6 = 0L;
										long.TryParse(item.ReqID ?? "", out result6);
										if (string.IsNullOrWhiteSpace(text2))
										{
											continue;
										}
										for (int k = 0; k < array.Length; k++)
										{
											if ((array[k] ?? "") == text2)
											{
												array2[k] = result6;
											}
										}
									}
								}
								else
								{
									array2[0] = -50000L;
									msgError = Messages.msgErrorRunFunction;
								}
							}
							else
							{
								array2[0] = -50000L;
								msgError = Messages.msgErrorRunFunction;
							}
						}
						else
						{
							array2[0] = -50000L;
							msgError = ((!string.IsNullOrWhiteSpace(parsGreenSendSmsResponseViewModel.R_Error ?? parsGreenSendSmsResponseViewModel.R_Message)) ? (parsGreenSendSmsResponseViewModel.R_Error ?? parsGreenSendSmsResponseViewModel.R_Message) : Messages.msgErrorRunFunction) + " (ErrorCode= " + result4 + ")";
						}
					}
					else
					{
						array2[0] = -50000L;
						msgError = Messages.msgErrorRunFunction;
					}
					continue;
				}
				string result7 = result2.Content.ReadAsStringAsync().Result;
				if (!string.IsNullOrWhiteSpace(result7))
				{
					ParsGreenErrorResponseViewModel parsGreenErrorResponseViewModel = JsonConvert.DeserializeObject<ParsGreenErrorResponseViewModel>(result7);
					if (parsGreenErrorResponseViewModel != null)
					{
						long result8 = 0L;
						long.TryParse(parsGreenErrorResponseViewModel.R_Code.ToString(), out result8);
						bool result9 = false;
						bool.TryParse(parsGreenErrorResponseViewModel.R_Success.ToString(), out result9);
						if (!result9)
						{
							array2[0] = -50000L;
							msgError = ((!string.IsNullOrWhiteSpace(parsGreenErrorResponseViewModel.R_Error ?? parsGreenErrorResponseViewModel.R_Message)) ? (parsGreenErrorResponseViewModel.R_Error ?? parsGreenErrorResponseViewModel.R_Message) : Messages.msgErrorRunFunction) + " (ErrorCode = " + result8 + ")";
						}
					}
					else
					{
						array2[0] = -50000L;
						msgError = Messages.msgErrorRunFunction;
					}
				}
				else
				{
					array2[0] = -50000L;
					msgError = Messages.msgErrorRunFunction;
				}
			}
			if (array2 == null || array2[0] < 0)
			{
				result = "-50000";
				return;
			}
			for (int l = 0; l < array2.Length; l++)
			{
				result = result + array2[l] + ",";
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = "-50000";
			msgError = ex.Message;
		}
	}

	public bool ParsGreen_GetDelivery(long[] refIdArr, ref int[] result, ref string msgError, int smsProviderId = 0)
	{
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			result = new int[Enumerable.Count<long>((IEnumerable<long>)refIdArr)];
			result[0] = -7;
			if (smsSettingInfoViewModel != null)
			{
				for (int i = 0; i < refIdArr.Length; i++)
				{
					if (refIdArr[i] == 0L)
					{
						continue;
					}
					ParsGreenDeliveryViewModel value = new ParsGreenDeliveryViewModel
					{
						RecId = refIdArr[i].ToString()
					};
					string value2 = "basic apikey:" + smsSettingInfoViewModel.SmsWsPassword;
					HttpClient httpClient = new HttpClient();
					string text = "https://sms.parsgreen.ir/Apiv2/Message/CheckDelivery";
					httpClient.DefaultRequestHeaders.Add("Authorization", value2);
					httpClient.BaseAddress = new Uri(text);
					httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					HttpContent content = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");
					HttpResponseMessage result2 = httpClient.PostAsync(text, content).Result;
					if (result2.IsSuccessStatusCode)
					{
						string result3 = result2.Content.ReadAsStringAsync().Result;
						if (!string.IsNullOrWhiteSpace(result3))
						{
							ParsGreenDeliveryResponseViewModel parsGreenDeliveryResponseViewModel = JsonConvert.DeserializeObject<ParsGreenDeliveryResponseViewModel>(result3);
							if (parsGreenDeliveryResponseViewModel == null)
							{
								msgError = Messages.msgErrorRunFunction;
								return false;
							}
							long result4 = 0L;
							long.TryParse(parsGreenDeliveryResponseViewModel.R_Code.ToString(), out result4);
							bool result5 = false;
							bool.TryParse(parsGreenDeliveryResponseViewModel.R_Success.ToString(), out result5);
							int result6 = 0;
							int.TryParse(parsGreenDeliveryResponseViewModel.DeliveryStatus.ToString(), out result6);
							switch (result6)
							{
							case 41:
								result[i] = 2;
								break;
							case 42:
							case 44:
								result[i] = 3;
								break;
							default:
								result[i] = result6;
								break;
							}
						}
						continue;
					}
					string result7 = result2.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(result7))
					{
						ParsGreenErrorResponseViewModel parsGreenErrorResponseViewModel = JsonConvert.DeserializeObject<ParsGreenErrorResponseViewModel>(result7);
						if (parsGreenErrorResponseViewModel != null)
						{
							long result8 = 0L;
							long.TryParse(parsGreenErrorResponseViewModel.R_Code.ToString(), out result8);
							bool result9 = false;
							bool.TryParse(parsGreenErrorResponseViewModel.R_Success.ToString(), out result9);
							if (!result9)
							{
								msgError = ((!string.IsNullOrWhiteSpace(parsGreenErrorResponseViewModel.R_Error ?? parsGreenErrorResponseViewModel.R_Message)) ? (parsGreenErrorResponseViewModel.R_Error ?? parsGreenErrorResponseViewModel.R_Message) : Messages.msgErrorRunFunction) + " (ErrorCode = " + result8 + ")";
							}
						}
						else
						{
							msgError = Messages.msgErrorRunFunction;
						}
					}
					else
					{
						msgError = Messages.msgErrorRunFunction;
					}
					return false;
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
		}
		return true;
	}

	public void ParsGreen_GetCredit(ref decimal credit, ref string msgError, int smsProviderId = 0)
	{
		credit = default(decimal);
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			string value = "basic apikey:" + smsSettingInfoViewModel.SmsWsPassword;
			HttpClient httpClient = new HttpClient();
			string text = "https://sms.parsgreen.ir/Apiv2/User/Credit";
			httpClient.BaseAddress = new Uri(text);
			httpClient.DefaultRequestHeaders.Add("Authorization", value);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			HttpContent content = new StringContent("", Encoding.UTF8, "application/json");
			HttpResponseMessage result = httpClient.PostAsync(text, content).Result;
			if (result.IsSuccessStatusCode)
			{
				string result2 = result.Content.ReadAsStringAsync().Result;
				if (!string.IsNullOrWhiteSpace(result2))
				{
					ParsGreenCreditResponseViewModel parsGreenCreditResponseViewModel = JsonConvert.DeserializeObject<ParsGreenCreditResponseViewModel>(result2);
					if (parsGreenCreditResponseViewModel != null)
					{
						long result3 = 0L;
						long.TryParse(parsGreenCreditResponseViewModel.R_Code.ToString(), out result3);
						bool result4 = false;
						bool.TryParse(parsGreenCreditResponseViewModel.R_Success.ToString(), out result4);
						if (result4)
						{
							decimal result5 = default(decimal);
							decimal.TryParse(parsGreenCreditResponseViewModel.Amount.ToString(), out result5);
							credit = result5;
						}
						else
						{
							credit = default(decimal);
							msgError = ((!string.IsNullOrWhiteSpace(parsGreenCreditResponseViewModel.R_Error ?? parsGreenCreditResponseViewModel.R_Message)) ? (parsGreenCreditResponseViewModel.R_Error ?? parsGreenCreditResponseViewModel.R_Message) : Messages.msgErrorRunFunction) + " (ErrorCode= " + result3 + ")";
						}
					}
					else
					{
						credit = default(decimal);
						msgError = Messages.msgErrorRunFunction;
					}
				}
				else
				{
					credit = default(decimal);
					msgError = Messages.msgErrorRunFunction;
				}
				return;
			}
			string result6 = result.Content.ReadAsStringAsync().Result;
			if (!string.IsNullOrWhiteSpace(result6))
			{
				ParsGreenErrorResponseViewModel parsGreenErrorResponseViewModel = JsonConvert.DeserializeObject<ParsGreenErrorResponseViewModel>(result6);
				if (parsGreenErrorResponseViewModel != null)
				{
					long result7 = 0L;
					long.TryParse(parsGreenErrorResponseViewModel.R_Code.ToString(), out result7);
					bool result8 = false;
					bool.TryParse(parsGreenErrorResponseViewModel.R_Success.ToString(), out result8);
					if (!result8)
					{
						credit = default(decimal);
						msgError = ((!string.IsNullOrWhiteSpace(parsGreenErrorResponseViewModel.R_Error ?? parsGreenErrorResponseViewModel.R_Message)) ? (parsGreenErrorResponseViewModel.R_Error ?? parsGreenErrorResponseViewModel.R_Message) : Messages.msgErrorRunFunction) + " (ErrorCode = " + result7 + ")";
					}
				}
				else
				{
					credit = default(decimal);
					msgError = Messages.msgErrorRunFunction;
				}
			}
			else
			{
				credit = default(decimal);
				msgError = Messages.msgErrorRunFunction;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
			credit = default(decimal);
		}
	}

	public void Armaghan_SendSms1To1(string[] lstMobile, string[] body, int cmessage, string fromNumber, ref string msgError, ref long[] result, bool smsIsSendByOtherAccount = false, string smsWebServiceUserName = "", string smsWebServicePassword = "", int smsProviderId = 0)
	{
		result = new long[1];
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			string username = smsSettingInfoViewModel.SmsWsUserName;
			string password = smsSettingInfoViewModel.SmsWsPassword;
			if (smsIsSendByOtherAccount && !string.IsNullOrWhiteSpace(smsWebServiceUserName) && !string.IsNullOrWhiteSpace(smsWebServicePassword))
			{
				username = smsWebServiceUserName;
				password = smsWebServicePassword;
			}
			int num = lstMobile.Length;
			long[] array = new long[num];
			int num2 = 200;
			int num3 = num / num2;
			int num4 = num % num2;
			int num5 = 0;
			int num6 = num2;
			if (num4 != 0)
			{
				num3++;
			}
			for (int i = 0; i < num3; i++)
			{
				if (i == num3 - 1 && num4 != 0)
				{
					num6 = num4;
				}
				string[] array2 = new string[num6];
				for (int j = 0; j < num6; j++)
				{
					num5 = i * num2 + j;
					array2[j] = lstMobile[num5];
				}
				string[] array3 = new string[array2.Length];
				for (int k = 0; k < num6; k++)
				{
					num5 = i * num2 + k;
					array3[k] = body[num5];
				}
				int num7 = 0;
				if (array2.Length == array3.Length)
				{
					ArmaghanSendManyToManyViewModel value = new ArmaghanSendManyToManyViewModel
					{
						username = username,
						password = password,
						originator = fromNumber,
						contents = array3,
						destinations = array2
					};
					HttpClient httpClient = new HttpClient();
					string text = "https://panel.hisms.ir/webservice/rest/sendMessageManyToMany";
					httpClient.BaseAddress = new Uri(text);
					httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					HttpContent content = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");
					HttpResponseMessage result2 = httpClient.PostAsync(text, content).Result;
					if (result2.IsSuccessStatusCode)
					{
						ArmaghanSendManyToManyResponseViewModel armaghanSendManyToManyResponseViewModel = JsonConvert.DeserializeObject<ArmaghanSendManyToManyResponseViewModel>(result2.Content.ReadAsStringAsync().Result);
						if (armaghanSendManyToManyResponseViewModel != null)
						{
							long result3 = 0L;
							string text2 = "";
							if (armaghanSendManyToManyResponseViewModel.errorModel != null)
							{
								long.TryParse(armaghanSendManyToManyResponseViewModel.errorModel.errorCode.ToString(), out result3);
								if (result3 != 0L)
								{
									text2 = Armaghan_GetError(result3);
									if (!string.IsNullOrWhiteSpace(armaghanSendManyToManyResponseViewModel.errorModel.message))
									{
										if (!string.IsNullOrWhiteSpace(text2))
										{
											text2 += "<br>";
										}
										text2 = text2 + armaghanSendManyToManyResponseViewModel.errorModel.message + " (ErrorCode= " + result3 + ")";
									}
								}
							}
							long[] references = armaghanSendManyToManyResponseViewModel.references;
							if (result3 == 0L || references != null)
							{
								if (references.Length != 0)
								{
									for (int l = 0; l < array2.Length; l++)
									{
										num5 = i * num2 + l;
										long result4 = 0L;
										long.TryParse(references[l].ToString(), out result4);
										array[num5] = result4;
										num7++;
									}
								}
								else
								{
									array[0] = -5000L;
									msgError = Messages.msgErrorRunFunction + "<br>" + text2;
								}
							}
							else
							{
								array[0] = -5000L;
								msgError = Messages.msgErrorRunFunction + "<br>" + text2;
							}
						}
						else
						{
							array[0] = -5000L;
							msgError = Messages.msgErrorRunFunction;
						}
					}
					else
					{
						msgError = Messages.msgErrorRunFunction;
						array[0] = -5000L;
					}
				}
				else
				{
					array[0] = -5000L;
					msgError = Messages.msgErrorRunFunction;
				}
			}
			if (array != null)
			{
				result = new long[num];
				result = array;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result[0] = -5000L;
			msgError = ex.Message;
		}
	}

	public void Armaghan_SendSms(string numbers, string body, int cmessage, string fromNumber, ref string msgError, ref string result, int smsProviderId = 0)
	{
		result = "0";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			_ = 3;
			string[] array = numbers.Split(new char[1] { ',' });
			int num = array.Length;
			long[] array2 = new long[num];
			int num2 = 200;
			int num3 = num / num2;
			int num4 = num % num2;
			int num5 = 0;
			int num6 = num2;
			if (num4 != 0)
			{
				num3++;
			}
			for (int i = 0; i < num3; i++)
			{
				if (i == num3 - 1 && num4 != 0)
				{
					num6 = num4;
				}
				string[] array3 = new string[num6];
				for (int j = 0; j < num6; j++)
				{
					num5 = i * num2 + j;
					array3[j] = array[num5];
				}
				int num7 = 0;
				ArmaghanSendOneToManyViewModel value = new ArmaghanSendOneToManyViewModel
				{
					username = smsSettingInfoViewModel.SmsWsUserName,
					password = smsSettingInfoViewModel.SmsWsPassword,
					originator = fromNumber,
					content = body,
					destinations = array3
				};
				HttpClient httpClient = new HttpClient();
				string text = "https://panel.hisms.ir/webservice/rest/sendMessageOneToMany";
				httpClient.BaseAddress = new Uri(text);
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpContent content = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");
				HttpResponseMessage result2 = httpClient.PostAsync(text, content).Result;
				if (result2.IsSuccessStatusCode)
				{
					ArmaghanSendOneToManyResponseViewModel armaghanSendOneToManyResponseViewModel = JsonConvert.DeserializeObject<ArmaghanSendOneToManyResponseViewModel>(result2.Content.ReadAsStringAsync().Result);
					if (armaghanSendOneToManyResponseViewModel != null)
					{
						long result3 = 0L;
						string text2 = "";
						if (armaghanSendOneToManyResponseViewModel.errorModel != null)
						{
							long.TryParse(armaghanSendOneToManyResponseViewModel.errorModel.errorCode.ToString(), out result3);
							if (result3 != 0L)
							{
								text2 = Armaghan_GetError(result3);
								if (!string.IsNullOrWhiteSpace(armaghanSendOneToManyResponseViewModel.errorModel.message))
								{
									if (!string.IsNullOrWhiteSpace(text2))
									{
										text2 += "<br>";
									}
									text2 = text2 + armaghanSendOneToManyResponseViewModel.errorModel.message + " (ErrorCode= " + result3 + ")";
								}
							}
						}
						long[] references = armaghanSendOneToManyResponseViewModel.references;
						if (result3 == 0L || references != null)
						{
							if (references.Length != 0)
							{
								for (int k = 0; k < array3.Length; k++)
								{
									num5 = i * num2 + k;
									long result4 = 0L;
									long.TryParse(references[k].ToString(), out result4);
									array2[num5] = result4;
									num7++;
								}
							}
							else
							{
								array2[0] = -50000L;
								msgError = Messages.msgErrorRunFunction + "<br>" + text2;
							}
						}
						else
						{
							array2[0] = -50000L;
							msgError = Messages.msgErrorRunFunction + "<br>" + text2;
						}
					}
					else
					{
						array2[0] = -50000L;
						msgError = Messages.msgErrorRunFunction;
					}
				}
				else
				{
					msgError = Messages.msgErrorRunFunction;
					array2[0] = -50000L;
				}
			}
			if (array2 == null || array2[0] < 0)
			{
				result = "-50000";
				return;
			}
			for (int l = 0; l < array2.Length; l++)
			{
				result = result + array2[l] + ",";
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = "-50000";
			msgError = ex.Message;
		}
	}

	public bool Armaghan_GetDelivery(long[] refIdArr, ref int[] result, ref string msgError, int smsProviderId = 0)
	{
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			result = new int[Enumerable.Count<long>((IEnumerable<long>)refIdArr)];
			result[0] = -7;
			if (smsSettingInfoViewModel != null && refIdArr.Length != 0)
			{
				ArmaghanMessageStateViewModel value = new ArmaghanMessageStateViewModel
				{
					username = smsSettingInfoViewModel.SmsWsUserName,
					password = smsSettingInfoViewModel.SmsWsPassword,
					ids = refIdArr
				};
				HttpClient httpClient = new HttpClient();
				string text = "https://panel.hisms.ir/webservice/rest/getMessageState";
				httpClient.BaseAddress = new Uri(text);
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpContent content = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");
				HttpResponseMessage result2 = httpClient.PostAsync(text, content).Result;
				if (!result2.IsSuccessStatusCode)
				{
					msgError = Messages.msgErrorRunFunction;
					return false;
				}
				ArmaghanMessageStateResponseViewModel armaghanMessageStateResponseViewModel = JsonConvert.DeserializeObject<ArmaghanMessageStateResponseViewModel>(result2.Content.ReadAsStringAsync().Result);
				if (armaghanMessageStateResponseViewModel == null)
				{
					msgError = Messages.msgErrorRunFunction;
					return false;
				}
				long result3 = 0L;
				string text2 = "";
				if (armaghanMessageStateResponseViewModel.errorModel != null)
				{
					long.TryParse(armaghanMessageStateResponseViewModel.errorModel.errorCode.ToString(), out result3);
					if (result3 != 0L)
					{
						text2 = Armaghan_GetError(result3);
						if (!string.IsNullOrWhiteSpace(armaghanMessageStateResponseViewModel.errorModel.message))
						{
							if (!string.IsNullOrWhiteSpace(text2))
							{
								text2 += "<br>";
							}
							text2 = text2 + armaghanMessageStateResponseViewModel.errorModel.message + " (ErrorCode= " + result3 + ")";
						}
					}
				}
				List<ArmaghanMessageStateResultesponseViewModel> states = armaghanMessageStateResponseViewModel.states;
				if (result3 != 0L && states == null)
				{
					msgError = Messages.msgErrorRunFunction + "<br>" + text2;
					return false;
				}
				if (!Enumerable.Any<ArmaghanMessageStateResultesponseViewModel>((IEnumerable<ArmaghanMessageStateResultesponseViewModel>)states))
				{
					msgError = Messages.msgErrorRunFunction + "<br>" + text2;
					return false;
				}
				for (int i = 0; i < refIdArr.Length; i++)
				{
					long refId = refIdArr[i];
					ArmaghanMessageStateResultesponseViewModel armaghanMessageStateResultesponseViewModel = Enumerable.FirstOrDefault<ArmaghanMessageStateResultesponseViewModel>((IEnumerable<ArmaghanMessageStateResultesponseViewModel>)states, (Func<ArmaghanMessageStateResultesponseViewModel, bool>)((ArmaghanMessageStateResultesponseViewModel m) => m.id == refId));
					if (armaghanMessageStateResultesponseViewModel != null && armaghanMessageStateResultesponseViewModel.id == refId)
					{
						int result4 = 0;
						int.TryParse(armaghanMessageStateResultesponseViewModel.state.ToString(), out result4);
						if (result4 == 5)
						{
							result[i] = 0;
						}
						else
						{
							result[i] = result4;
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
		}
		return true;
	}

	public void Armaghan_GetCredit(ref decimal credit, ref string msgError, int smsProviderId = 0)
	{
		credit = default(decimal);
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			ArmaghanUserInfoViewModel value = new ArmaghanUserInfoViewModel
			{
				username = smsSettingInfoViewModel.SmsWsUserName,
				password = smsSettingInfoViewModel.SmsWsPassword
			};
			HttpClient httpClient = new HttpClient();
			string text = "https://panel.hisms.ir/webservice/rest/getUserInfo";
			httpClient.BaseAddress = new Uri(text);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			HttpContent content = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");
			HttpResponseMessage result = httpClient.PostAsync(text, content).Result;
			if (result.IsSuccessStatusCode)
			{
				string result2 = result.Content.ReadAsStringAsync().Result;
				if (!string.IsNullOrWhiteSpace(result2))
				{
					ArmaghanUserInfoResponseViewModel armaghanUserInfoResponseViewModel = JsonConvert.DeserializeObject<ArmaghanUserInfoResponseViewModel>(result2);
					if (armaghanUserInfoResponseViewModel != null)
					{
						long result3 = 0L;
						string text2 = "";
						if (armaghanUserInfoResponseViewModel.errorModel != null)
						{
							long.TryParse(armaghanUserInfoResponseViewModel.errorModel.errorCode.ToString(), out result3);
							if (result3 != 0L)
							{
								text2 = Armaghan_GetError(result3);
								if (!string.IsNullOrWhiteSpace(armaghanUserInfoResponseViewModel.errorModel.message))
								{
									if (!string.IsNullOrWhiteSpace(text2))
									{
										text2 += "<br>";
									}
									text2 += armaghanUserInfoResponseViewModel.errorModel.message;
								}
							}
						}
						if (result3 == 0L || armaghanUserInfoResponseViewModel.userInfo != null)
						{
							decimal result4 = default(decimal);
							decimal.TryParse(armaghanUserInfoResponseViewModel.userInfo.credit.ToString(), out result4);
							credit = result4;
							return;
						}
						credit = default(decimal);
						msgError = Messages.msgErrorRunFunction + "<br>" + text2 + " (ErrorCode= " + result3 + ")";
					}
					else
					{
						credit = default(decimal);
						msgError = Messages.msgErrorRunFunction;
					}
				}
				else
				{
					credit = default(decimal);
					msgError = Messages.msgErrorRunFunction;
				}
			}
			else
			{
				msgError = Messages.msgErrorRunFunction;
				credit = default(decimal);
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
			credit = default(decimal);
		}
	}

	public List<ArmaghanGetMessageInfoResponseViewModel> Armaghan_ReceiveSms(int smsProviderId = 0)
	{
		List<ArmaghanGetMessageInfoResponseViewModel> list = new List<ArmaghanGetMessageInfoResponseViewModel>();
		CRMEntities cRMEntities = new CRMEntities();
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			if (smsSettingInfoViewModel != null)
			{
				long result = 0L;
				MobspSelectLastSmsReceive_Result mobspSelectLastSmsReceive_Result = Enumerable.FirstOrDefault<MobspSelectLastSmsReceive_Result>((IEnumerable<MobspSelectLastSmsReceive_Result>)cRMEntities.MobspSelectLastSmsReceive());
				if (mobspSelectLastSmsReceive_Result != null)
				{
					long.TryParse(mobspSelectLastSmsReceive_Result.GetId, out result);
				}
				bool flag = true;
				int num = 0;
				while (flag)
				{
					ArmaghanGetMessageViewModel value = new ArmaghanGetMessageViewModel
					{
						username = smsSettingInfoViewModel.SmsWsUserName,
						password = smsSettingInfoViewModel.SmsWsPassword,
						destination = smsSettingInfoViewModel.SmsWsFromNumber,
						page = num,
						size = 100,
						afterId = result
					};
					HttpClient httpClient = new HttpClient();
					string text = "https://panel.hisms.ir/webservice/rest/getReceivedMessages";
					httpClient.BaseAddress = new Uri(text);
					httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					HttpContent content = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");
					HttpResponseMessage result2 = httpClient.PostAsync(text, content).Result;
					if (result2.IsSuccessStatusCode)
					{
						ArmaghanGetMessageResponseViewModel armaghanGetMessageResponseViewModel = JsonConvert.DeserializeObject<ArmaghanGetMessageResponseViewModel>(result2.Content.ReadAsStringAsync().Result);
						if (armaghanGetMessageResponseViewModel != null)
						{
							long result3 = 0L;
							if (armaghanGetMessageResponseViewModel.errorModel != null)
							{
								long.TryParse(armaghanGetMessageResponseViewModel.errorModel.errorCode.ToString(), out result3);
								if (result3 != 0L)
								{
									flag = false;
								}
							}
							if (armaghanGetMessageResponseViewModel.result != null && result3 == 0L)
							{
								List<ArmaghanGetMessageInfoResponseViewModel> data = armaghanGetMessageResponseViewModel.result.data;
								if (data != null)
								{
									if (Enumerable.Any<ArmaghanGetMessageInfoResponseViewModel>((IEnumerable<ArmaghanGetMessageInfoResponseViewModel>)data))
									{
										list.AddRange(data);
									}
									else
									{
										flag = false;
									}
								}
								else
								{
									flag = false;
								}
							}
							else
							{
								flag = false;
							}
						}
						else
						{
							flag = false;
						}
					}
					else
					{
						flag = false;
					}
					num++;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return list;
	}

	public string Armaghan_GetError(long errCode)
	{
		string result = "";
		if (errCode <= -160)
		{
			switch (errCode)
			{
			case -201L:
				result = Messages.msgErrorArmaghanInternalSystemErr;
				break;
			case -160L:
				result = Messages.msgErrorArmaghanProblemFormatSendingBasedTemplate;
				break;
			case -161L:
				result = Messages.msgErrorArmaghanTemplatBasedSubmissionInputParam;
				break;
			}
		}
		else if (errCode != -119)
		{
			long num = errCode - -110;
			if ((ulong)num <= 9uL)
			{
				switch (num)
				{
				case 9L:
					result = Messages.msgErrorArmaghanAuthentication;
					goto IL_00d3;
				case 7L:
					result = Messages.msgErrorArmaghanNumberIncorrect;
					goto IL_00d3;
				case 6L:
					result = Messages.msgErrorArmaghanLackCredit;
					goto IL_00d3;
				case 5L:
					result = Messages.msgErrorArmaghanMalformedRequest;
					goto IL_00d3;
				case 3L:
					result = Messages.msgErrorArmaghanRecipientNumberIncorrect;
					goto IL_00d3;
				case 0L:
					result = Messages.msgErrorArmaghanYourIPNotRegisteredInSystem;
					goto IL_00d3;
				case 1L:
				case 2L:
				case 4L:
				case 8L:
					goto IL_00d3;
				}
			}
			if (errCode == 0L)
			{
				result = "";
			}
		}
		else
		{
			result = Messages.msgErrorArmaghanWebServiceNotEnabled;
		}
		goto IL_00d3;
		IL_00d3:
		return result;
	}

	public string Rahyab_GetToken(bool smsIsSendByOtherAccount = false, string smsWebServiceUserName = "", string smsWebServicePassword = "", int smsProviderId = 0)
	{
		string text = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			_ = smsSettingInfoViewModel.SmsWsUserName;
			string password = smsSettingInfoViewModel.SmsWsPassword;
			string tokenUserName = smsSettingInfoViewModel.TokenUserName;
			if (smsIsSendByOtherAccount && !string.IsNullOrWhiteSpace(smsWebServiceUserName) && !string.IsNullOrWhiteSpace(smsWebServicePassword))
			{
				password = smsWebServicePassword;
			}
			HttpClient httpClient = new HttpClient();
			string text2 = "https://api.rahyab.ir/api/Auth/getToken";
			httpClient.BaseAddress = new Uri(text2);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			HttpContent content = new StringContent(JsonConvert.SerializeObject(new RahyabRequsetTokenViewModel
			{
				username = tokenUserName,
				password = password
			}), Encoding.UTF8, "application/json");
			HttpResponseMessage result = httpClient.PostAsync(text2, content).Result;
			if (result.IsSuccessStatusCode)
			{
				string result2 = result.Content.ReadAsStringAsync().Result;
				if (!string.IsNullOrWhiteSpace(result2))
				{
					text = result2 ?? "";
					text = text.Replace("\"", "");
					if (!string.IsNullOrWhiteSpace(text))
					{
						text = "Bearer " + text;
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = "";
		}
		return text;
	}

	public void Rahyab_SendSms1To1(string[] lstMobile, string[] lstBody, int cmessage, string fromNumber, ref string msgError, ref string[] result, bool smsIsSendByOtherAccount = false, string smsWebServiceUserName = "", string smsWebServicePassword = "", int smsProviderId = 0)
	{
		result = new string[1];
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			string userName = smsSettingInfoViewModel.SmsWsUserName;
			string password = smsSettingInfoViewModel.SmsWsPassword;
			if (smsIsSendByOtherAccount && !string.IsNullOrWhiteSpace(smsWebServiceUserName) && !string.IsNullOrWhiteSpace(smsWebServicePassword))
			{
				userName = smsWebServiceUserName;
				password = smsWebServicePassword;
			}
			string value = Rahyab_GetToken(smsIsSendByOtherAccount, smsWebServiceUserName, smsWebServicePassword);
			if (!string.IsNullOrWhiteSpace(value))
			{
				RahyabSendSmsLikeToLikeViewModel rahyabSendSmsLikeToLikeViewModel = new RahyabSendSmsLikeToLikeViewModel();
				rahyabSendSmsLikeToLikeViewModel.listLikeToLikeMessage = new List<RahyabSendSmsLikeToLikeInfoViewModel>();
				rahyabSendSmsLikeToLikeViewModel.userName = userName;
				rahyabSendSmsLikeToLikeViewModel.password = password;
				rahyabSendSmsLikeToLikeViewModel.company = smsSettingInfoViewModel.SmsCustomer;
				rahyabSendSmsLikeToLikeViewModel.number = fromNumber;
				if (lstMobile.Length == lstBody.Length && lstMobile.Length != 0)
				{
					for (int i = 0; i < lstMobile.Length; i++)
					{
						string text = lstBody[i];
						string text2 = lstMobile[i];
						string messageId = DateTime.Now.ToString("yyyyMMddHHmmssffff", new CultureInfo("en-US"));
						if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(text2))
						{
							RahyabSendSmsLikeToLikeInfoViewModel item = new RahyabSendSmsLikeToLikeInfoViewModel
							{
								destNumber = text2,
								message = text,
								messageId = messageId
							};
							rahyabSendSmsLikeToLikeViewModel.listLikeToLikeMessage.Add(item);
						}
					}
					if (Enumerable.Any<RahyabSendSmsLikeToLikeInfoViewModel>((IEnumerable<RahyabSendSmsLikeToLikeInfoViewModel>)rahyabSendSmsLikeToLikeViewModel.listLikeToLikeMessage))
					{
						HttpClient httpClient = new HttpClient();
						string text3 = "https://api.rahyab.ir/api/v1/SendSMS_LikeToLike";
						httpClient.BaseAddress = new Uri(text3);
						httpClient.DefaultRequestHeaders.Add("Authorization", value);
						httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
						HttpContent content = new StringContent(JsonConvert.SerializeObject(rahyabSendSmsLikeToLikeViewModel), Encoding.UTF8, "application/json");
						HttpResponseMessage result2 = httpClient.PostAsync(text3, content).Result;
						if (result2.IsSuccessStatusCode)
						{
							List<RahyabSendSmsLikeToLikeResponseViewModel> list = JsonConvert.DeserializeObject<List<RahyabSendSmsLikeToLikeResponseViewModel>>(result2.Content.ReadAsStringAsync().Result);
							if (list != null)
							{
								RahyabSendSmsLikeToLikeResponseViewModel rahyabSendSmsLikeToLikeResponseViewModel = Enumerable.FirstOrDefault<RahyabSendSmsLikeToLikeResponseViewModel>((IEnumerable<RahyabSendSmsLikeToLikeResponseViewModel>)list);
								if (rahyabSendSmsLikeToLikeResponseViewModel != null)
								{
									string text4 = rahyabSendSmsLikeToLikeResponseViewModel.code ?? "";
									string text5 = rahyabSendSmsLikeToLikeResponseViewModel.identity ?? "";
									string text6 = rahyabSendSmsLikeToLikeResponseViewModel.errorMsg ?? "";
									if (!string.IsNullOrWhiteSpace(text4))
									{
										if (text4.ToLower() == "CHECK_OK".ToLower() && !string.IsNullOrWhiteSpace(text5))
										{
											int num = Enumerable.Count<RahyabSendSmsLikeToLikeInfoViewModel>((IEnumerable<RahyabSendSmsLikeToLikeInfoViewModel>)rahyabSendSmsLikeToLikeViewModel.listLikeToLikeMessage);
											string[] array = new string[num];
											for (int j = 0; j < num; j++)
											{
												array[j] = text5;
											}
											result = array;
										}
										else
										{
											result[0] = "-5000";
											msgError = ((!string.IsNullOrWhiteSpace(text6)) ? (text6 + ((!string.IsNullOrWhiteSpace(text4)) ? (" StatusCode: " + text4) : "")) : Messages.msgErrorRunFunction);
										}
									}
									else
									{
										result[0] = "-5000";
										msgError = ((!string.IsNullOrWhiteSpace(text6)) ? (text6 + ((!string.IsNullOrWhiteSpace(text4)) ? (" StatusCode: " + text4) : "")) : Messages.msgErrorRunFunction);
									}
								}
								else
								{
									result[0] = "-5000";
									msgError = Messages.msgErrorRunFunction;
								}
							}
							else
							{
								result[0] = "-5000";
								msgError = Messages.msgErrorRunFunction;
							}
						}
						else
						{
							result[0] = "-5000";
							msgError = Messages.msgErrorRunFunction;
						}
					}
					else
					{
						result[0] = "-5000";
						msgError = Messages.ErrorNotFound;
					}
				}
				else
				{
					result[0] = "-5000";
					msgError = Messages.ErrorNotFound;
				}
			}
			else
			{
				result[0] = "-5000";
				msgError = Messages.msgErrorReceivingToken;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result[0] = "-5000";
			msgError = ex.Message;
		}
	}

	public void Rahyab_SendSms(string numbers, string body, int cmessage, string fromNumber, ref string msgError, ref string result, int smsProviderId = 0)
	{
		result = "0";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			string smsWsUserName = smsSettingInfoViewModel.SmsWsUserName;
			string smsWsPassword = smsSettingInfoViewModel.SmsWsPassword;
			string[] array = numbers.Split(new char[1] { ',' });
			int num = array.Length;
			_ = new string[num];
			string value = Rahyab_GetToken();
			if (!string.IsNullOrWhiteSpace(value))
			{
				HttpClient httpClient = new HttpClient();
				string text = "https://api.rahyab.ir/api/v1/SendSMS_Batch";
				httpClient.BaseAddress = new Uri(text);
				httpClient.DefaultRequestHeaders.Add("Authorization", value);
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				httpClient.DefaultRequestHeaders.Add("accept", "*/*");
				HttpContent content = new StringContent(JsonConvert.SerializeObject(new RahyabSendSmsBatchViewModel
				{
					destinationAddress = array,
					message = body,
					number = smsSettingInfoViewModel.SmsWsFromNumber,
					userName = smsWsUserName,
					password = smsWsPassword,
					company = smsSettingInfoViewModel.SmsCustomer
				}), Encoding.UTF8, "application/json");
				HttpResponseMessage result2 = httpClient.PostAsync(text, content).Result;
				if (result2.IsSuccessStatusCode)
				{
					List<RahyabSendSmsBatchResponseViewModel> list = JsonConvert.DeserializeObject<List<RahyabSendSmsBatchResponseViewModel>>(result2.Content.ReadAsStringAsync().Result);
					if (list != null)
					{
						RahyabSendSmsBatchResponseViewModel rahyabSendSmsBatchResponseViewModel = Enumerable.FirstOrDefault<RahyabSendSmsBatchResponseViewModel>((IEnumerable<RahyabSendSmsBatchResponseViewModel>)list);
						if (rahyabSendSmsBatchResponseViewModel != null)
						{
							string text2 = rahyabSendSmsBatchResponseViewModel.batchId ?? "";
							if (!string.IsNullOrWhiteSpace(text2))
							{
								int num2 = num;
								for (int i = 0; i < num2; i++)
								{
									if (!string.IsNullOrWhiteSpace(result))
									{
										result += ",";
									}
									result += text2;
								}
							}
							else
							{
								result = "-50000";
								msgError = Messages.msgErrorRunFunction;
							}
						}
						else
						{
							result = "-50000";
							msgError = Messages.msgErrorRunFunction;
						}
					}
					else
					{
						result = "-50000";
						msgError = Messages.msgErrorRunFunction;
					}
				}
				else
				{
					result = "-50000";
					msgError = Messages.msgErrorRunFunction;
				}
			}
			else
			{
				result = "-50000";
				msgError = Messages.msgErrorReceivingToken;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = "-50000";
			msgError = ex.Message;
		}
	}

	public void Rahyab_GetDelivery(string[] refIdArr, string[] mobArr, ref int[] result, ref string msgError, int smsProviderId = 0)
	{
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			result = new int[Enumerable.Count<string>((IEnumerable<string>)refIdArr)];
			result[0] = -7;
			if (smsSettingInfoViewModel == null)
			{
				return;
			}
			List<CommonSelectListItemViewModel> list = new List<CommonSelectListItemViewModel>();
			foreach (string refId in refIdArr)
			{
				if (!string.IsNullOrWhiteSpace(refId))
				{
					bool flag = false;
					if (list != null && Enumerable.Any<CommonSelectListItemViewModel>((IEnumerable<CommonSelectListItemViewModel>)list) && Enumerable.FirstOrDefault<CommonSelectListItemViewModel>((IEnumerable<CommonSelectListItemViewModel>)list, (Func<CommonSelectListItemViewModel, bool>)((CommonSelectListItemViewModel m) => (m.Value ?? "") == refId)) != null)
					{
						flag = true;
					}
					if (!flag)
					{
						CommonSelectListItemViewModel item = new CommonSelectListItemViewModel
						{
							Value = refId
						};
						list.Add(item);
					}
				}
			}
			if (list != null)
			{
				if (Enumerable.Any<CommonSelectListItemViewModel>((IEnumerable<CommonSelectListItemViewModel>)list))
				{
					string value = Rahyab_GetToken();
					if (!string.IsNullOrWhiteSpace(value))
					{
						foreach (CommonSelectListItemViewModel item2 in list)
						{
							string text = item2.Value ?? "";
							if (!string.IsNullOrWhiteSpace(text))
							{
								HttpClient httpClient = new HttpClient();
								string text2 = "https://api.rahyab.ir/api/v1/StatusSMS";
								httpClient.BaseAddress = new Uri(text2);
								httpClient.DefaultRequestHeaders.Add("Authorization", value);
								httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
								httpClient.DefaultRequestHeaders.Add("accept", "*/*");
								HttpContent content = new StringContent(JsonConvert.SerializeObject(new RahyabGetStatusViewModel
								{
									userName = smsSettingInfoViewModel.SmsWsUserName,
									password = smsSettingInfoViewModel.SmsWsPassword,
									company = smsSettingInfoViewModel.SmsCustomer,
									batchId = text
								}), Encoding.UTF8, "application/json");
								HttpResponseMessage result2 = httpClient.PostAsync(text2, content).Result;
								if (result2.IsSuccessStatusCode)
								{
									List<RahyabGetStatusResponseViewModel> list2 = JsonConvert.DeserializeObject<List<RahyabGetStatusResponseViewModel>>(result2.Content.ReadAsStringAsync().Result);
									if (list2 != null)
									{
										if (Enumerable.Any<RahyabGetStatusResponseViewModel>((IEnumerable<RahyabGetStatusResponseViewModel>)list2))
										{
											foreach (RahyabGetStatusResponseViewModel item3 in list2)
											{
												string text3 = item3.receiveNumber ?? "";
												string text4 = item3.deliveryStatus ?? "";
												if (!string.IsNullOrWhiteSpace(text3))
												{
													text3 = text3.Replace("\"", "").Replace("\\", "");
													text3 = text3.Replace("+98", "");
													if (text3.StartsWith("9"))
													{
														text3 = "0" + text3;
													}
												}
												text4 = text4.Replace("\"", "").Replace("\\", "");
												for (int j = 0; j < refIdArr.Length; j++)
												{
													bool flag2 = false;
													string text5 = mobArr[j] ?? "";
													if ((refIdArr[j] ?? "") == text && text3 == text5 && !flag2)
													{
														"SENT_N".ToLower();
														string text6 = "GATEWAY_TO_SENT".ToLower();
														string text7 = "Delivered".ToLower();
														"Undeliv".ToLower();
														"InvalidDestNetwork".ToLower();
														"InvalidDestAddress".ToLower();
														"InvalidSourceAddress".ToLower();
														string text8 = "BlacklistedDestination".ToLower();
														"Rejected".ToLower();
														"UnreachableDestNetwork".ToLower();
														"SourceAddressNotAllowed".ToLower();
														"InvalidType".ToLower();
														"Expired".ToLower();
														string text9 = "MT_DELIVERED".ToLower();
														if (!string.IsNullOrWhiteSpace(text4))
														{
															if (text4.ToLower() == text7 || text4.ToLower() == text9)
															{
																result[j] = 2;
															}
															else if (text4.ToLower() == text8)
															{
																result[j] = 4;
															}
															else if (text4.ToLower() == text6)
															{
																result[j] = 1;
															}
															else
															{
																result[j] = 3;
															}
														}
														else
														{
															result[j] = 0;
														}
														flag2 = true;
													}
												}
											}
										}
									}
									else
									{
										msgError = Messages.ErrorInformation;
									}
								}
								else
								{
									msgError = Messages.ErrorInformation;
								}
							}
						}
						return;
					}
					msgError = Messages.msgErrorReceivingToken;
				}
				else
				{
					msgError = Messages.ErrorNotFound;
				}
			}
			else
			{
				msgError = Messages.ErrorNotFound;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
		}
	}

	public void Rahyab_GetCredit(ref decimal credit, ref string msgError, int smsProviderId = 0)
	{
		credit = default(decimal);
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			if (smsSettingInfoViewModel != null)
			{
				string value = Rahyab_GetToken();
				if (!string.IsNullOrWhiteSpace(value))
				{
					HttpClient httpClient = new HttpClient();
					string text = "https://api.rahyab.ir/api/v1/GetRemainCredit";
					httpClient.BaseAddress = new Uri(text);
					httpClient.DefaultRequestHeaders.Add("Authorization", value);
					httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					HttpContent content = new StringContent(JsonConvert.SerializeObject(new RahyabGetRemainCreditViewModel
					{
						username = smsSettingInfoViewModel.SmsWsUserName,
						password = smsSettingInfoViewModel.SmsWsPassword,
						company = smsSettingInfoViewModel.SmsCustomer
					}), Encoding.UTF8, "application/json");
					HttpResponseMessage result = httpClient.PostAsync(text, content).Result;
					if (result.IsSuccessStatusCode)
					{
						RahyabGetRemainCreditResponseViewModel rahyabGetRemainCreditResponseViewModel = JsonConvert.DeserializeObject<RahyabGetRemainCreditResponseViewModel>(result.Content.ReadAsStringAsync().Result);
						if (rahyabGetRemainCreditResponseViewModel != null)
						{
							string text2 = rahyabGetRemainCreditResponseViewModel.remainCredit ?? "";
							if (!string.IsNullOrWhiteSpace(text2))
							{
								text2 = text2.Trim();
								text2 = text2.Replace("\n", "");
							}
							decimal.TryParse(text2, out credit);
						}
						else
						{
							credit = default(decimal);
							msgError = Messages.ErrorInformation;
						}
					}
					else
					{
						credit = default(decimal);
						msgError = Messages.ErrorInformation;
					}
				}
				else
				{
					credit = default(decimal);
					msgError = Messages.msgErrorReceivingToken;
				}
			}
			else
			{
				credit = default(decimal);
				msgError = Messages.msgErrorReceivingToken;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
			credit = default(decimal);
		}
	}

	public List<RahyabGetMessageViewModel> Rahyab_ReceiveSms(int smsProviderId = 0)
	{
		List<RahyabGetMessageViewModel> list = new List<RahyabGetMessageViewModel>();
		CRMEntities cRMEntities = new CRMEntities();
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			if (smsSettingInfoViewModel != null)
			{
				string value = Rahyab_GetToken();
				if (!string.IsNullOrWhiteSpace(value))
				{
					long result = 0L;
					MobspSelectLastSmsReceive_Result mobspSelectLastSmsReceive_Result = Enumerable.FirstOrDefault<MobspSelectLastSmsReceive_Result>((IEnumerable<MobspSelectLastSmsReceive_Result>)cRMEntities.MobspSelectLastSmsReceive());
					if (mobspSelectLastSmsReceive_Result != null)
					{
						long.TryParse(mobspSelectLastSmsReceive_Result.GetId, out result);
					}
					bool flag = true;
					int num = 0;
					while (flag)
					{
						HttpClient httpClient = new HttpClient();
						string text = "https://api.rahyab.ir/api/v1/ReadFromId?count=100";
						httpClient.BaseAddress = new Uri(text);
						httpClient.DefaultRequestHeaders.Add("Authorization", value);
						httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
						new StringContent("", Encoding.UTF8, "application/json");
						HttpResponseMessage result2 = httpClient.GetAsync(text).Result;
						if (result2.IsSuccessStatusCode)
						{
							List<RahyabGetMessageViewModel> list2 = JsonConvert.DeserializeObject<List<RahyabGetMessageViewModel>>(result2.Content.ReadAsStringAsync().Result);
							if (list2 != null)
							{
								if (Enumerable.Any<RahyabGetMessageViewModel>((IEnumerable<RahyabGetMessageViewModel>)list2))
								{
									list.AddRange(list2);
								}
								else
								{
									flag = false;
								}
							}
							else
							{
								flag = false;
							}
						}
						else
						{
							flag = false;
						}
						num++;
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return list;
	}

	public void IPPanel_SendSms1To1(string[] lstMobile, string[] lstBody, int cmessage, string fromNumber, ref string msgError, ref string[] result, bool smsIsSendByOtherAccount = false, string smsWebServiceUserName = "", string smsWebServicePassword = "", int smsProviderId = 0)
	{
		result = new string[1];
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			_ = smsSettingInfoViewModel.SmsWsUserName;
			string text = smsSettingInfoViewModel.SmsWsPassword;
			if (smsIsSendByOtherAccount && !string.IsNullOrWhiteSpace(smsWebServiceUserName) && !string.IsNullOrWhiteSpace(smsWebServicePassword))
			{
				text = smsWebServicePassword;
			}
			string text2 = smsSettingInfoViewModel.ProviderUrl ?? "";
			string text3 = text;
			if (string.IsNullOrWhiteSpace(text2))
			{
				text2 = "https://edge.ippanel.com/v1/";
			}
			if (!string.IsNullOrWhiteSpace(text2) && !text2.EndsWith("/"))
			{
				text2 += "/";
			}
			string value = text3.Trim();
			IPPanelSendSmsPeerToPeerViewModel iPPanelSendSmsPeerToPeerViewModel = new IPPanelSendSmsPeerToPeerViewModel();
			iPPanelSendSmsPeerToPeerViewModel.@params = new List<IPPanelSendSmsPeerToPeerInfoViewModel>();
			iPPanelSendSmsPeerToPeerViewModel.sending_type = "peer_to_peer";
			iPPanelSendSmsPeerToPeerViewModel.from_number = fromNumber;
			if (lstMobile.Length == lstBody.Length && lstMobile.Length != 0)
			{
				for (int i = 0; i < lstMobile.Length; i++)
				{
					string text4 = lstBody[i];
					string text5 = lstMobile[i];
					if (!string.IsNullOrWhiteSpace(text4) && !string.IsNullOrWhiteSpace(text5))
					{
						string[] recipients = new string[1] { text5 };
						IPPanelSendSmsPeerToPeerInfoViewModel item = new IPPanelSendSmsPeerToPeerInfoViewModel
						{
							recipients = recipients,
							message = text4
						};
						iPPanelSendSmsPeerToPeerViewModel.@params.Add(item);
					}
				}
				if (Enumerable.Any<IPPanelSendSmsPeerToPeerInfoViewModel>((IEnumerable<IPPanelSendSmsPeerToPeerInfoViewModel>)iPPanelSendSmsPeerToPeerViewModel.@params))
				{
					HttpClient httpClient = new HttpClient();
					string text6 = text2 + "api/send";
					httpClient.BaseAddress = new Uri(text6);
					httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", value);
					httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					HttpContent content = new StringContent(JsonConvert.SerializeObject(iPPanelSendSmsPeerToPeerViewModel), Encoding.UTF8, "application/json");
					HttpResponseMessage result2 = httpClient.PostAsync(text6, content).Result;
					if (result2.IsSuccessStatusCode)
					{
						IPPanelSendSmsPeerToPeerResponseViewModel iPPanelSendSmsPeerToPeerResponseViewModel = JsonConvert.DeserializeObject<IPPanelSendSmsPeerToPeerResponseViewModel>(result2.Content.ReadAsStringAsync().Result);
						if (iPPanelSendSmsPeerToPeerResponseViewModel != null)
						{
							bool result3 = false;
							string text7 = "";
							string text8 = "";
							if (iPPanelSendSmsPeerToPeerResponseViewModel.meta != null)
							{
								bool.TryParse(iPPanelSendSmsPeerToPeerResponseViewModel.meta.status.ToString(), out result3);
								text8 = iPPanelSendSmsPeerToPeerResponseViewModel.meta.message_code ?? "";
								if (iPPanelSendSmsPeerToPeerResponseViewModel.meta.errors != null && iPPanelSendSmsPeerToPeerResponseViewModel.meta.errors.message != null && iPPanelSendSmsPeerToPeerResponseViewModel.meta.errors.message.Length != 0)
								{
									for (int j = 0; j < iPPanelSendSmsPeerToPeerResponseViewModel.meta.errors.message.Length; j++)
									{
										string text9 = iPPanelSendSmsPeerToPeerResponseViewModel.meta.errors.message[j];
										if (!string.IsNullOrWhiteSpace(text9))
										{
											if (!string.IsNullOrWhiteSpace(text7))
											{
												text7 += ", ";
											}
											text7 += text9;
										}
									}
								}
							}
							if (!string.IsNullOrWhiteSpace(text7) && !string.IsNullOrWhiteSpace(text8))
							{
								text7 = text7 + " (Code: " + text8 + ")";
							}
							if (result3 && iPPanelSendSmsPeerToPeerResponseViewModel.data != null)
							{
								if (iPPanelSendSmsPeerToPeerResponseViewModel.data.message_outbox_ids != null)
								{
									if (iPPanelSendSmsPeerToPeerResponseViewModel.data.message_outbox_ids.Length != 0)
									{
										int num = iPPanelSendSmsPeerToPeerResponseViewModel.data.message_outbox_ids.Length;
										string[] array = new string[num];
										for (int k = 0; k < num; k++)
										{
											array[k] = iPPanelSendSmsPeerToPeerResponseViewModel.data.message_outbox_ids[k];
										}
										result = array;
									}
									else
									{
										result[0] = "-5000";
										if (!string.IsNullOrWhiteSpace(text7))
										{
											msgError = text7;
										}
										else
										{
											msgError = Messages.msgErrorRunFunction;
										}
									}
								}
								else
								{
									result[0] = "-5000";
									if (!string.IsNullOrWhiteSpace(text7))
									{
										msgError = text7;
									}
									else
									{
										msgError = Messages.msgErrorRunFunction;
									}
								}
							}
							else
							{
								result[0] = "-5000";
								if (!string.IsNullOrWhiteSpace(text7))
								{
									msgError = text7;
								}
								else
								{
									msgError = Messages.msgErrorRunFunction;
								}
							}
						}
						else
						{
							result[0] = "-5000";
							msgError = Messages.msgErrorRunFunction;
						}
					}
					else
					{
						result[0] = "-5000";
						msgError = Messages.msgErrorRunFunction;
					}
				}
				else
				{
					result[0] = "-5000";
					msgError = Messages.ErrorNotFound;
				}
			}
			else
			{
				result[0] = "-5000";
				msgError = Messages.ErrorNotFound;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result[0] = "-5000";
			msgError = ex.Message;
		}
	}

	public void IPPanel_SendSms(string numbers, string body, int cmessage, string fromNumber, ref string msgError, ref string result, int smsProviderId = 0)
	{
		result = "0";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			_ = smsSettingInfoViewModel.SmsWsUserName;
			string smsWsPassword = smsSettingInfoViewModel.SmsWsPassword;
			string[] array = numbers.Split(new char[1] { ',' });
			_ = new string[array.Length];
			string text = smsSettingInfoViewModel.ProviderUrl ?? "";
			if (string.IsNullOrWhiteSpace(text))
			{
				text = "https://edge.ippanel.com/v1/";
			}
			if (!string.IsNullOrWhiteSpace(text) && !text.EndsWith("/"))
			{
				text += "/";
			}
			string value = smsWsPassword.Trim();
			IPPanelSendSmsWebServiceViewModel iPPanelSendSmsWebServiceViewModel = new IPPanelSendSmsWebServiceViewModel();
			iPPanelSendSmsWebServiceViewModel.@params = new IPPanelSendSmsWebServiceInfoViewModel();
			iPPanelSendSmsWebServiceViewModel.sending_type = "webservice";
			iPPanelSendSmsWebServiceViewModel.from_number = fromNumber;
			iPPanelSendSmsWebServiceViewModel.message = body;
			if (array.Length != 0)
			{
				IPPanelSendSmsWebServiceInfoViewModel @params = new IPPanelSendSmsWebServiceInfoViewModel
				{
					recipients = array
				};
				iPPanelSendSmsWebServiceViewModel.@params = @params;
				if (iPPanelSendSmsWebServiceViewModel.@params.recipients != null)
				{
					HttpClient httpClient = new HttpClient();
					string text2 = text + "api/send";
					httpClient.BaseAddress = new Uri(text2);
					httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", value);
					httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					HttpContent content = new StringContent(JsonConvert.SerializeObject(iPPanelSendSmsWebServiceViewModel), Encoding.UTF8, "application/json");
					HttpResponseMessage result2 = httpClient.PostAsync(text2, content).Result;
					if (result2.IsSuccessStatusCode)
					{
						IPPanelSendSmsWebServiceResponseViewModel iPPanelSendSmsWebServiceResponseViewModel = JsonConvert.DeserializeObject<IPPanelSendSmsWebServiceResponseViewModel>(result2.Content.ReadAsStringAsync().Result);
						if (iPPanelSendSmsWebServiceResponseViewModel != null)
						{
							bool result3 = false;
							string text3 = "";
							string text4 = "";
							if (iPPanelSendSmsWebServiceResponseViewModel.meta != null)
							{
								bool.TryParse(iPPanelSendSmsWebServiceResponseViewModel.meta.status.ToString(), out result3);
								text4 = iPPanelSendSmsWebServiceResponseViewModel.meta.message_code ?? "";
								if (iPPanelSendSmsWebServiceResponseViewModel.meta.errors != null && iPPanelSendSmsWebServiceResponseViewModel.meta.errors.message != null && iPPanelSendSmsWebServiceResponseViewModel.meta.errors.message.Length != 0)
								{
									for (int i = 0; i < iPPanelSendSmsWebServiceResponseViewModel.meta.errors.message.Length; i++)
									{
										string text5 = iPPanelSendSmsWebServiceResponseViewModel.meta.errors.message[i];
										if (!string.IsNullOrWhiteSpace(text5))
										{
											if (!string.IsNullOrWhiteSpace(text3))
											{
												text3 += ", ";
											}
											text3 += text5;
										}
									}
								}
							}
							if (!string.IsNullOrWhiteSpace(text3) && !string.IsNullOrWhiteSpace(text4))
							{
								text3 = text3 + " (Code: " + text4 + ")";
							}
							if (result3 && iPPanelSendSmsWebServiceResponseViewModel.data != null)
							{
								if (iPPanelSendSmsWebServiceResponseViewModel.data.message_outbox_ids != null)
								{
									int num = iPPanelSendSmsWebServiceResponseViewModel.data.message_outbox_ids.Length;
									if (num > 0)
									{
										for (int j = 0; j < num; j++)
										{
											string text6 = iPPanelSendSmsWebServiceResponseViewModel.data.message_outbox_ids[j];
											if (!string.IsNullOrWhiteSpace(text6))
											{
												result += ",";
											}
											result += text6;
										}
									}
									else
									{
										result = "-50000";
										if (!string.IsNullOrWhiteSpace(text3))
										{
											msgError = text3;
										}
										else
										{
											msgError = Messages.msgErrorRunFunction;
										}
									}
								}
								else
								{
									result = "-50000";
									if (!string.IsNullOrWhiteSpace(text3))
									{
										msgError = text3;
									}
									else
									{
										msgError = Messages.msgErrorRunFunction;
									}
								}
							}
							else
							{
								result = "-50000";
								if (!string.IsNullOrWhiteSpace(text3))
								{
									msgError = text3;
								}
								else
								{
									msgError = Messages.msgErrorRunFunction;
								}
							}
						}
						else
						{
							result = "-50000";
							msgError = Messages.msgErrorRunFunction;
						}
					}
					else
					{
						result = "-50000";
						msgError = Messages.msgErrorRunFunction;
					}
				}
				else
				{
					result = "-50000";
					msgError = Messages.ErrorNotFound;
				}
			}
			else
			{
				result = "-50000";
				msgError = Messages.ErrorNotFound;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = "-50000";
			msgError = ex.Message;
		}
	}

	public void IPPanel_GetDelivery(string[] refIdArr, string[] mobArr, ref int[] result, ref string msgError, int smsProviderId = 0)
	{
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			result = new int[Enumerable.Count<string>((IEnumerable<string>)refIdArr)];
			result[0] = -7;
			if (smsSettingInfoViewModel == null)
			{
				return;
			}
			_ = smsSettingInfoViewModel.SmsWsUserName;
			string smsWsPassword = smsSettingInfoViewModel.SmsWsPassword;
			string text = smsSettingInfoViewModel.ProviderUrl ?? "";
			string text2 = smsWsPassword;
			if (string.IsNullOrWhiteSpace(text))
			{
				text = "https://edge.ippanel.com/v1/";
			}
			if (!string.IsNullOrWhiteSpace(text) && !text.EndsWith("/"))
			{
				text += "/";
			}
			List<CommonSelectListItemViewModel> list = new List<CommonSelectListItemViewModel>();
			foreach (string refId in refIdArr)
			{
				if (!string.IsNullOrWhiteSpace(refId))
				{
					bool flag = false;
					if (list != null && Enumerable.Any<CommonSelectListItemViewModel>((IEnumerable<CommonSelectListItemViewModel>)list) && Enumerable.FirstOrDefault<CommonSelectListItemViewModel>((IEnumerable<CommonSelectListItemViewModel>)list, (Func<CommonSelectListItemViewModel, bool>)((CommonSelectListItemViewModel m) => (m.Value ?? "") == refId)) != null)
					{
						flag = true;
					}
					if (!flag)
					{
						CommonSelectListItemViewModel item = new CommonSelectListItemViewModel
						{
							Value = refId
						};
						list.Add(item);
					}
				}
			}
			if (list != null)
			{
				if (Enumerable.Any<CommonSelectListItemViewModel>((IEnumerable<CommonSelectListItemViewModel>)list))
				{
					string value = text2.Trim();
					{
						foreach (CommonSelectListItemViewModel item2 in list)
						{
							string text3 = item2.Value ?? "";
							if (string.IsNullOrWhiteSpace(text3))
							{
								continue;
							}
							HttpClient httpClient = new HttpClient();
							string text4 = text + "api/report/recipients?bulk_id=" + text3;
							httpClient.BaseAddress = new Uri(text4);
							httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", value);
							httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
							HttpResponseMessage result2 = httpClient.GetAsync(text4).Result;
							if (result2.IsSuccessStatusCode)
							{
								IPPanelGetStatusResponseViewModel iPPanelGetStatusResponseViewModel = JsonConvert.DeserializeObject<IPPanelGetStatusResponseViewModel>(result2.Content.ReadAsStringAsync().Result);
								if (iPPanelGetStatusResponseViewModel != null)
								{
									bool result3 = false;
									string text5 = "";
									string text6 = "";
									if (iPPanelGetStatusResponseViewModel.meta != null)
									{
										bool.TryParse(iPPanelGetStatusResponseViewModel.meta.status.ToString(), out result3);
										text6 = iPPanelGetStatusResponseViewModel.meta.message_code ?? "";
										if (iPPanelGetStatusResponseViewModel.meta.errors != null && iPPanelGetStatusResponseViewModel.meta.errors.message != null && iPPanelGetStatusResponseViewModel.meta.errors.message.Length != 0)
										{
											for (int j = 0; j < iPPanelGetStatusResponseViewModel.meta.errors.message.Length; j++)
											{
												string text7 = iPPanelGetStatusResponseViewModel.meta.errors.message[j];
												if (!string.IsNullOrWhiteSpace(text7))
												{
													if (!string.IsNullOrWhiteSpace(text5))
													{
														text5 += ", ";
													}
													text5 += text7;
												}
											}
										}
									}
									if (!string.IsNullOrWhiteSpace(text5) && !string.IsNullOrWhiteSpace(text6))
									{
										text5 = text5 + " (Code: " + text6 + ")";
									}
									if (iPPanelGetStatusResponseViewModel.data != null)
									{
										if (Enumerable.Any<PPanelGetStatusDataResponseViewModel>((IEnumerable<PPanelGetStatusDataResponseViewModel>)iPPanelGetStatusResponseViewModel.data))
										{
											foreach (PPanelGetStatusDataResponseViewModel datum in iPPanelGetStatusResponseViewModel.data)
											{
												string text8 = datum.recipient ?? "";
												string text9 = datum.message_status ?? "";
												if (!string.IsNullOrWhiteSpace(text8))
												{
													text8 = text8.Replace("\"", "").Replace("\\", "");
													text8 = text8.Replace("+98", "");
													if (text8.StartsWith("9"))
													{
														text8 = "0" + text8;
													}
												}
												text9 = text9.Replace("\"", "").Replace("\\", "");
												for (int k = 0; k < refIdArr.Length; k++)
												{
													bool flag2 = false;
													string text10 = mobArr[k] ?? "";
													if (!((refIdArr[k] ?? "") == text3) || !(text8 == text10) || flag2)
													{
														continue;
													}
													if (!string.IsNullOrWhiteSpace(text9))
													{
														switch (text9)
														{
														case "2":
															result[k] = 2;
															break;
														case "3":
															result[k] = 3;
															break;
														case "4":
															result[k] = 4;
															break;
														case "1":
															result[k] = 1;
															break;
														default:
														{
															int result4 = 0;
															int.TryParse(text9, out result4);
															result[k] = result4;
															break;
														}
														}
													}
													else
													{
														result[k] = 0;
													}
													flag2 = true;
												}
											}
										}
										else if (!string.IsNullOrWhiteSpace(text5))
										{
											msgError = text5;
										}
										else
										{
											msgError = Messages.ErrorInformation;
										}
									}
									else if (!string.IsNullOrWhiteSpace(text5))
									{
										msgError = text5;
									}
									else
									{
										msgError = Messages.ErrorInformation;
									}
								}
								else
								{
									msgError = Messages.ErrorInformation;
								}
							}
							else
							{
								msgError = Messages.ErrorInformation;
							}
						}
						return;
					}
				}
				msgError = Messages.ErrorNotFound;
			}
			else
			{
				msgError = Messages.ErrorNotFound;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
		}
	}

	public void IPPanel_GetCredit(ref decimal credit, ref string msgError, int smsProviderId = 0)
	{
		credit = default(decimal);
		msgError = "";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			SysSeting.Get();
			if (smsSettingInfoViewModel != null)
			{
				_ = smsSettingInfoViewModel.SmsWsUserName;
				string smsWsPassword = smsSettingInfoViewModel.SmsWsPassword;
				string text = smsSettingInfoViewModel.ProviderUrl ?? "";
				if (string.IsNullOrWhiteSpace(text))
				{
					text = "https://edge.ippanel.com/v1/";
				}
				if (!string.IsNullOrWhiteSpace(text) && !text.EndsWith("/"))
				{
					text += "/";
				}
				string value = smsWsPassword.Trim();
				HttpClient httpClient = new HttpClient();
				string text2 = text + "api/payment/credit/mine";
				httpClient.BaseAddress = new Uri(text2);
				httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", value);
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpResponseMessage result = httpClient.GetAsync(text2).Result;
				if (result.IsSuccessStatusCode)
				{
					IPPanelGetCreditResponseViewModel iPPanelGetCreditResponseViewModel = JsonConvert.DeserializeObject<IPPanelGetCreditResponseViewModel>(result.Content.ReadAsStringAsync().Result);
					if (iPPanelGetCreditResponseViewModel != null)
					{
						bool result2 = false;
						string text3 = "";
						string text4 = "";
						if (iPPanelGetCreditResponseViewModel.meta != null)
						{
							bool.TryParse(iPPanelGetCreditResponseViewModel.meta.status.ToString(), out result2);
							text4 = iPPanelGetCreditResponseViewModel.meta.message_code ?? "";
							if (iPPanelGetCreditResponseViewModel.meta.errors != null && iPPanelGetCreditResponseViewModel.meta.errors.message != null && iPPanelGetCreditResponseViewModel.meta.errors.message.Length != 0)
							{
								for (int i = 0; i < iPPanelGetCreditResponseViewModel.meta.errors.message.Length; i++)
								{
									string text5 = iPPanelGetCreditResponseViewModel.meta.errors.message[i];
									if (!string.IsNullOrWhiteSpace(text5))
									{
										if (!string.IsNullOrWhiteSpace(text3))
										{
											text3 += ", ";
										}
										text3 += text5;
									}
								}
							}
						}
						if (!string.IsNullOrWhiteSpace(text3) && !string.IsNullOrWhiteSpace(text4))
						{
							text3 = text3 + " (Code: " + text4 + ")";
						}
						if (iPPanelGetCreditResponseViewModel.data != null)
						{
							decimal.TryParse(iPPanelGetCreditResponseViewModel.data.credit.ToString(), out credit);
							return;
						}
						credit = default(decimal);
						if (!string.IsNullOrWhiteSpace(text3))
						{
							msgError = text3;
						}
						else
						{
							msgError = Messages.ErrorInformation;
						}
					}
					else
					{
						credit = default(decimal);
						msgError = Messages.ErrorInformation;
					}
				}
				else
				{
					credit = default(decimal);
					msgError = Messages.ErrorInformation;
				}
			}
			else
			{
				credit = default(decimal);
				msgError = Messages.msgErrorReceivingToken;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			msgError = ex.Message;
			credit = default(decimal);
		}
	}

	public List<IPPanelGetMessageViewModel> IPPanel_ReceiveSms(int smsProviderId = 0)
	{
		List<IPPanelGetMessageViewModel> list = new List<IPPanelGetMessageViewModel>();
		CRMEntities cRMEntities = new CRMEntities();
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSettingInfoViewModel = GetSmsSetting(out freeSmsCount);
			if (smsProviderId != 0)
			{
				smsSettingInfoViewModel = GetSmsProvider(smsProviderId, out freeSmsCount);
			}
			if (smsSettingInfoViewModel != null)
			{
				_ = smsSettingInfoViewModel.SmsWsUserName;
				string smsWsPassword = smsSettingInfoViewModel.SmsWsPassword;
				string text = smsSettingInfoViewModel.ProviderUrl ?? "";
				if (string.IsNullOrWhiteSpace(text))
				{
					text = "https://edge.ippanel.com/v1/";
				}
				if (!string.IsNullOrWhiteSpace(text) && !text.EndsWith("/"))
				{
					text += "/";
				}
				string value = smsWsPassword.Trim();
				if (!string.IsNullOrWhiteSpace(value))
				{
					long result = 0L;
					MobspSelectLastSmsReceive_Result mobspSelectLastSmsReceive_Result = Enumerable.FirstOrDefault<MobspSelectLastSmsReceive_Result>((IEnumerable<MobspSelectLastSmsReceive_Result>)cRMEntities.MobspSelectLastSmsReceive());
					if (mobspSelectLastSmsReceive_Result != null)
					{
						long.TryParse(mobspSelectLastSmsReceive_Result.GetId, out result);
					}
					bool flag = true;
					int num = 0;
					while (flag)
					{
						HttpClient httpClient = new HttpClient();
						string text2 = text + "api/report/messages-inbox";
						httpClient.BaseAddress = new Uri(text2);
						httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", value);
						httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
						IPPanelGetMessageReqViewModel iPPanelGetMessageReqViewModel = new IPPanelGetMessageReqViewModel
						{
							page = num,
							per_page = 1000L,
							filters = new IPPanelGetMessageFromIdReqViewModel()
						};
						if (result != 0L)
						{
							iPPanelGetMessageReqViewModel.filters.from_id = result;
						}
						HttpContent content = new StringContent(JsonConvert.SerializeObject(iPPanelGetMessageReqViewModel), Encoding.UTF8, "application/json");
						HttpResponseMessage result2 = httpClient.PostAsync(text2, content).Result;
						if (result2.IsSuccessStatusCode)
						{
							IPPanelGetMessageResponseViewModel iPPanelGetMessageResponseViewModel = JsonConvert.DeserializeObject<IPPanelGetMessageResponseViewModel>(result2.Content.ReadAsStringAsync().Result);
							if (iPPanelGetMessageResponseViewModel != null)
							{
								if (iPPanelGetMessageResponseViewModel.data != null)
								{
									if (Enumerable.Any<IPPanelGetMessageViewModel>((IEnumerable<IPPanelGetMessageViewModel>)iPPanelGetMessageResponseViewModel.data))
									{
										list.AddRange(iPPanelGetMessageResponseViewModel.data);
									}
									else
									{
										flag = false;
									}
								}
								else
								{
									flag = false;
								}
							}
							else
							{
								flag = false;
							}
						}
						else
						{
							flag = false;
						}
						num++;
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return list;
	}
}

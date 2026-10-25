using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.ServiceModel.Activation;
using System.Threading;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using CRMIdeal.Hubs;
using Elmah;
using Microsoft.AspNet.SignalR;

namespace CRMIdeal.Services;

[AspNetCompatibilityRequirements(/*Could not decode attribute arguments.*/)]
public class CallerIdServiceI : ICallerIdServiceI
{
	public bool SendMessage(string UserName, string Password, string LineNumber, string EventType, int CallType, string[] VoipInfo, string Extention = "", int CmpSearchMode = 0, string CmpSearchVal = "")
	{
		if (!VersionBuyer.APIVoip)
		{
			return false;
		}
		string text = "BP";
		string text2 = "";
		string text3 = "|0|";
		string text4 = "0";
		bool result = false;
		CRMSpEntities cRMSpEntities = null;
		CRMSpIEntities cRMSpIEntities = null;
		CRMSpIIIEntities cRMSpIIIEntities = null;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			string appType = Configuration.AppType;
			string lockSerial = SysSeting.Get().LockSerial;
			if (!string.IsNullOrEmpty(lockSerial))
			{
				string[] array = lockSerial.Split(new char[1] { '-' });
				if (array != null)
				{
					text2 = array[^2];
				}
			}
			MobCallerIdContentViewModel mobCallerIdContentViewModel = new MobCallerIdContentViewModel();
			string text5 = "";
			string text6 = "";
			CRMspCallerIDSelectPopUpSetting_Result cRMspCallerIDSelectPopUpSetting_Result = CIPopUpSetting.Get();
			if (cRMspCallerIDSelectPopUpSetting_Result == null || VoipInfo == null)
			{
				return false;
			}
			if (text == UserName && text2 == Password)
			{
				int value = 0;
				if (cRMspCallerIDSelectPopUpSetting_Result.PopUpJustForcmpReferUser.GetValueOrDefault())
				{
					value = 1;
				}
				if (cRMspCallerIDSelectPopUpSetting_Result.PopUpJustForcmpReferUserAndLinked.GetValueOrDefault())
				{
					value = 2;
				}
				string trunkCallId = null;
				string trunkName = null;
				string text7 = null;
				string text8 = null;
				string text9 = null;
				string recFileName = null;
				string trunkDestinationCycle = null;
				string text10 = "";
				if (VoipInfo != null)
				{
					trunkCallId = ((VoipInfo.Length < 1) ? null : ((!string.IsNullOrEmpty(VoipInfo[0])) ? VoipInfo[0] : null));
					trunkName = ((VoipInfo.Length < 2) ? null : ((!string.IsNullOrEmpty(VoipInfo[1])) ? VoipInfo[1] : null));
					text7 = ((VoipInfo.Length < 3) ? null : ((!string.IsNullOrEmpty(VoipInfo[2])) ? VoipInfo[2] : null));
					text8 = ((VoipInfo.Length < 4) ? null : ((!string.IsNullOrEmpty(VoipInfo[3])) ? VoipInfo[3] : null));
					text9 = ((VoipInfo.Length < 5) ? null : ((!string.IsNullOrEmpty(VoipInfo[4])) ? VoipInfo[4] : null));
					recFileName = ((VoipInfo.Length < 6) ? null : ((!string.IsNullOrEmpty(VoipInfo[5])) ? VoipInfo[5] : null));
					trunkDestinationCycle = ((VoipInfo.Length < 7) ? null : ((!string.IsNullOrEmpty(VoipInfo[6])) ? VoipInfo[6] : null));
				}
				text4 = ((!string.IsNullOrEmpty(text8)) ? text8 : "0");
				text10 = CallType switch
				{
					1 => (!string.IsNullOrEmpty(text8)) ? text8 : "", 
					2 => (!string.IsNullOrEmpty(text7)) ? text7 : "", 
					_ => (!string.IsNullOrEmpty(text8)) ? text8 : "", 
				};
				if (string.IsNullOrEmpty(text10))
				{
					return false;
				}
				cRMSpIIIEntities = new CRMSpIIIEntities();
				CRMspCallerIDCleanPhoneNumberByUserCallPreNumber_Result cRMspCallerIDCleanPhoneNumberByUserCallPreNumber_Result = Enumerable.FirstOrDefault<CRMspCallerIDCleanPhoneNumberByUserCallPreNumber_Result>((IEnumerable<CRMspCallerIDCleanPhoneNumberByUserCallPreNumber_Result>)cRMSpIIIEntities.CRMspCallerIDCleanPhoneNumberByUserCallPreNumber(CallType, text10, text7, text8));
				if (cRMspCallerIDCleanPhoneNumberByUserCallPreNumber_Result != null)
				{
					string text11 = cRMspCallerIDCleanPhoneNumberByUserCallPreNumber_Result.PhoneNumber ?? "";
					string text12 = cRMspCallerIDCleanPhoneNumberByUserCallPreNumber_Result.TrunkSource ?? "";
					string text13 = cRMspCallerIDCleanPhoneNumberByUserCallPreNumber_Result.TrunkDestination ?? "";
					if (!string.IsNullOrWhiteSpace(text11) && !string.IsNullOrWhiteSpace(text10) && text11 != text10)
					{
						text10 = text11;
					}
					if (!string.IsNullOrWhiteSpace(text12) && !string.IsNullOrWhiteSpace(text7) && text12 != text7)
					{
						text7 = text12;
					}
					if (!string.IsNullOrWhiteSpace(text13) && !string.IsNullOrWhiteSpace(text8) && text13 != text8)
					{
						text8 = text13;
					}
				}
				DateTime now = DateTime.Now;
				string text14 = now.ToString("yyyyMMdd", new PersianCulture());
				int value2 = -3;
				string callDay = now.ToString("dddd", new PersianCulture());
				short value3 = short.Parse(now.ToString("yyyy", new PersianCulture()));
				short value4 = short.Parse(now.ToString("MM", new PersianCulture()));
				string callTime = now.ToString("HH:mm:ss");
				string data = "";
				string text15 = (EventType ?? "").ToLower();
				string preRecFileName = "\\" + now.ToString("yyyy", new CultureInfo("en-US")) + "\\" + now.ToString("MM", new CultureInfo("en-US")) + "\\" + now.ToString("dd", new CultureInfo("en-US")) + "\\";
				int result3 = 0;
				int.TryParse(LineNumber, out result3);
				int num = 0;
				int num2 = 0;
				cRMSpEntities = new CRMSpEntities();
				cRMSpIEntities = new CRMSpIEntities();
				CRMspCallerIDSearch_Result cRMspCallerIDSearch_Result = new CRMspCallerIDSearch_Result();
				if (CmpSearchMode != 0 && !string.IsNullOrWhiteSpace(CmpSearchVal))
				{
					CRMspCallerIDSearchInMode_Result cRMspCallerIDSearchInMode_Result = Enumerable.FirstOrDefault<CRMspCallerIDSearchInMode_Result>((IEnumerable<CRMspCallerIDSearchInMode_Result>)cRMSpIEntities.CRMspCallerIDSearchInMode(CmpSearchMode, CmpSearchVal, text10, lCID, result2));
					if (cRMspCallerIDSearchInMode_Result != null)
					{
						cRMspCallerIDSearch_Result = new CRMspCallerIDSearch_Result
						{
							PhoneNumber = cRMspCallerIDSearchInMode_Result.PhoneNumber,
							cmpName = cRMspCallerIDSearchInMode_Result.cmpName,
							cmpPrsName = cRMspCallerIDSearchInMode_Result.cmpPrsName,
							CompanyID = cRMspCallerIDSearchInMode_Result.CompanyID,
							CompanyPersonID = cRMspCallerIDSearchInMode_Result.CompanyPersonID,
							LastcnvscmpPerson = cRMspCallerIDSearchInMode_Result.LastcnvscmpPerson,
							LastProjectId = cRMspCallerIDSearchInMode_Result.LastProjectId,
							LastProject = cRMspCallerIDSearchInMode_Result.LastProject,
							LastcnvsRefUser = cRMspCallerIDSearchInMode_Result.LastcnvsRefUser,
							LastcnvsRefUserId = cRMspCallerIDSearchInMode_Result.LastcnvsRefUserId,
							LastConversationId = cRMspCallerIDSearchInMode_Result.LastConversationId,
							LastcnvsStatus = cRMspCallerIDSearchInMode_Result.LastcnvsStatus,
							cmpReferUser = cRMspCallerIDSearchInMode_Result.cmpReferUser,
							cmpReferUserId = cRMspCallerIDSearchInMode_Result.cmpReferUserId,
							cmpActivityType = cRMspCallerIDSearchInMode_Result.cmpActivityType,
							cmpCountry = cRMspCallerIDSearchInMode_Result.cmpCountry,
							cmpProvince = cRMspCallerIDSearchInMode_Result.cmpProvince,
							cmpCity = cRMspCallerIDSearchInMode_Result.cmpCity,
							cmpPresentation = cRMspCallerIDSearchInMode_Result.cmpPresentation,
							cmpCompanyType = cRMspCallerIDSearchInMode_Result.cmpCompanyType,
							cmpCompanyGroups = cRMspCallerIDSearchInMode_Result.cmpCompanyGroups,
							cmpSubGroupName = cRMspCallerIDSearchInMode_Result.cmpSubGroupName,
							cmpCompanyGroupII = cRMspCallerIDSearchInMode_Result.cmpCompanyGroupII,
							cmpCompanyGroupIII = cRMspCallerIDSearchInMode_Result.cmpCompanyGroupIII,
							cmpCompanyGroupIV = cRMspCallerIDSearchInMode_Result.cmpCompanyGroupIV
						};
						if (cRMspCallerIDSearch_Result.CompanyPersonID.GetValueOrDefault() == 0)
						{
							cRMspCallerIDSearch_Result.CompanyPersonID = cRMspCallerIDSearchInMode_Result.cmpMainPersonId;
							cRMspCallerIDSearch_Result.cmpPrsName = cRMspCallerIDSearchInMode_Result.cmpMainPrsName ?? "";
						}
					}
					else
					{
						cRMspCallerIDSearch_Result = null;
					}
				}
				else
				{
					cRMspCallerIDSearch_Result = Enumerable.FirstOrDefault<CRMspCallerIDSearch_Result>((IEnumerable<CRMspCallerIDSearch_Result>)cRMSpEntities.CRMspCallerIDSearch(text10, lCID, result2));
				}
				switch (text15)
				{
				case "ring":
					if (cRMspCallerIDSearch_Result != null)
					{
						try
						{
							cRMSpEntities.CRMspInsertCallHistory(CallType, result3, text10, cRMspCallerIDSearch_Result.CompanyID, callTime, text14, callDay, value2, value3, value4, text14, "", "", text9, cRMspCallerIDSearch_Result.CompanyPersonID, recFileName, data, appType, result2, trunkCallId, trunkName, text7, text8, null, trunkDestinationCycle, preRecFileName, null);
						}
						catch (Exception e3)
						{
							ErrorSignal.FromCurrentContext().Raise(e3);
						}
					}
					else
					{
						try
						{
							cRMSpEntities.CRMspInsertCallHistory(CallType, result3, text10, null, callTime, text14, callDay, value2, value3, value4, text14, "", "", text9, null, recFileName, data, appType, result2, trunkCallId, trunkName, text7, text8, null, trunkDestinationCycle, preRecFileName, null);
						}
						catch (Exception e4)
						{
							ErrorSignal.FromCurrentContext().Raise(e4);
						}
					}
					result = true;
					return result;
				case "connected":
				{
					if (cRMspCallerIDSearch_Result != null)
					{
						ObjectParameter objectParameter = new ObjectParameter("FormulaPopUpResult", "");
						cRMSpEntities.CRMspCallerIDFormulaPopUpResult(LineNumber, DateTime.Now.ToString("hh:mm:ss"), text10, cRMspCallerIDSearch_Result.cmpName ?? "", cRMspCallerIDSearch_Result.cmpPrsName ?? "", cRMspCallerIDSearch_Result.cmpName + " " + cRMspCallerIDSearch_Result.cmpPrsName, cRMspCallerIDSearch_Result.LastcnvscmpPerson ?? "", cRMspCallerIDSearch_Result.LastProject ?? "", cRMspCallerIDSearch_Result.LastcnvsRefUser ?? "", cRMspCallerIDSearch_Result.LastcnvsStatus ?? "", cRMspCallerIDSearch_Result.cmpReferUser ?? "", cRMspCallerIDSearch_Result.cmpActivityType ?? "", cRMspCallerIDSearch_Result.cmpCountry ?? "", cRMspCallerIDSearch_Result.cmpProvince ?? "", cRMspCallerIDSearch_Result.cmpCity ?? "", cRMspCallerIDSearch_Result.cmpPresentation ?? "", cRMspCallerIDSearch_Result.cmpCompanyType ?? "", cRMspCallerIDSearch_Result.cmpCompanyGroups ?? "", cRMspCallerIDSearch_Result.cmpSubGroupName ?? "", cRMspCallerIDSearch_Result.cmpCompanyGroupII ?? "", cRMspCallerIDSearch_Result.cmpCompanyGroupIII ?? "", cRMspCallerIDSearch_Result.cmpCompanyGroupIV ?? "", "", objectParameter, true);
						text5 = "<div class='CallerIdDiv' id='" + cRMspCallerIDSearch_Result.CompanyID + "-" + cRMspCallerIDSearch_Result.CompanyPersonID + "-" + cRMspCallerIDSearch_Result.LastProjectId + "-" + cRMspCallerIDSearch_Result.LastConversationId + "'>";
						text5 += "<div class='CI-I' onclick='OpenCompanyInfo(this);'>";
						text6 += objectParameter.Value.ToString().Replace("\r\n", "<br/>").Replace(" ", "&nbsp;");
						text5 += text6;
						text5 += "</div>";
						text5 += "<div class='CI-A'></div>";
						text5 += "</div>";
						mobCallerIdContentViewModel.CompanyId = cRMspCallerIDSearch_Result.CompanyID?.ToString();
						mobCallerIdContentViewModel.PersonId = cRMspCallerIDSearch_Result.CompanyPersonID?.ToString();
						mobCallerIdContentViewModel.LastProjectId = cRMspCallerIDSearch_Result.LastProjectId?.ToString();
						mobCallerIdContentViewModel.LastConversationId = cRMspCallerIDSearch_Result.LastConversationId?.ToString();
						mobCallerIdContentViewModel.Message = objectParameter.Value.ToString();
						num = cRMspCallerIDSearch_Result.CompanyID.GetValueOrDefault();
						num2 = cRMspCallerIDSearch_Result.CompanyPersonID.GetValueOrDefault();
					}
					else
					{
						if (cRMspCallerIDSelectPopUpSetting_Result.PopUpDeActiveForUnknownNumber.GetValueOrDefault())
						{
							text3 = "|0|";
							return result;
						}
						text5 = "<div class='CallerIdDiv'>";
						text6 = text6 + Labels.PopUpCallerIdLine + ":&nbsp;" + LineNumber + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + Labels.PopUpCallerIdInTime + ":&nbsp;" + DateTime.Now.ToString("hh:mm:ss");
						text6 += "<br/>";
						text6 = text6 + Labels.PopUpCallerIdTel + ":&nbsp;<span>" + text10 + "</span>";
						text6 += "<br/>";
						text6 = text6 + Labels.PopUpCallerIdCmpName + ":&nbsp;" + Labels.PopUpCallerIdNumberNotRegister;
						text5 = text5 + text6 + "</div>";
						string text16 = "";
						text16 = text16 + Labels.PopUpCallerIdInTime + ":&nbsp;" + DateTime.Now.ToString("hh:mm:ss");
						text16 += "<br/>";
						text16 = text16 + Labels.PopUpCallerIdTel + ":&nbsp;<span>" + text10 + "</span>";
						text16 += "<br/>";
						text16 = text16 + Labels.PopUpCallerIdCmpName + ":&nbsp;" + Labels.PopUpCallerIdNumberNotRegister;
						mobCallerIdContentViewModel.Message = text16.ToString();
					}
					if (cRMspCallerIDSelectPopUpSetting_Result.PopUpDeActive.GetValueOrDefault())
					{
						text3 = "|0|";
						return result;
					}
					int result4 = 3;
					if (cRMspCallerIDSearch_Result != null && cRMspCallerIDSearch_Result.cmpReferUserId.HasValue)
					{
						int.TryParse(cRMspCallerIDSearch_Result.cmpReferUserId.ToString(), out result4);
					}
					text3 = "|";
					List<int?> list = Enumerable.ToList<int?>((IEnumerable<int?>)cRMSpEntities.CRMspCallerIDSelectRejectPopUpUsers(value, result4, result3));
					if (Enumerable.Any<int?>((IEnumerable<int?>)list))
					{
						text3 = Enumerable.Aggregate<int?, string>(Enumerable.Where<int?>((IEnumerable<int?>)list, (Func<int?, bool>)((int? userId) => userId.HasValue)), text3, (Func<string, int?, string>)delegate(string current, int? userId)
						{
							int? num3 = userId;
							return current + num3 + "|";
						});
					}
					if (!string.IsNullOrEmpty(text10) && CallType == 2 && text10.Substring(0, 2) == "09")
					{
						cRMSpEntities.CRMspAutoSendSMSFromCallerID(num, num2, text10, Configuration.AppType, result2, 0);
					}
					try
					{
						cRMSpEntities.CRMspInsertUpdateCallHistoryOnTrunkCdr(CallType, result3, text10, (num == 0) ? null : new int?(num), callTime, text14, callDay, value2, value3, value4, text14, "", "", text9, (num2 == 0) ? null : new int?(num2), recFileName, data, appType, result2, trunkCallId, trunkName, text7, text8, null, trunkDestinationCycle, preRecFileName);
					}
					catch (Exception e5)
					{
						ErrorSignal.FromCurrentContext().Raise(e5);
					}
					IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
					string text17 = text5;
					string text18 = text3;
					if (!string.IsNullOrWhiteSpace(Extention))
					{
						text4 = Extention;
					}
					if (string.IsNullOrEmpty(text4))
					{
						text4 = "";
					}
					if (CallType == 2)
					{
						hubContext.Clients.All.addNewMessageToPage(text18, text17, text4, LineNumber);
						PushNotif.CallerIdNotify(text18, text4, LineNumber, mobCallerIdContentViewModel);
					}
					result = true;
					return result;
				}
				case "cdr":
					if (string.IsNullOrEmpty(text9))
					{
						break;
					}
					try
					{
						if (text9 != "0")
						{
							try
							{
								cRMSpEntities.CRMspInsertUpdateCallHistoryOnTrunkCdr(CallType, result3, text10, (num == 0) ? null : new int?(num), callTime, text14, callDay, value2, value3, value4, text14, "", "", text9, (num2 == 0) ? null : new int?(num2), recFileName, data, appType, result2, trunkCallId, trunkName, text7, text8, null, trunkDestinationCycle, preRecFileName);
							}
							catch (Exception e)
							{
								ErrorSignal.FromCurrentContext().Raise(e);
							}
							result = true;
							return result;
						}
					}
					catch (Exception e2)
					{
						ErrorSignal.FromCurrentContext().Raise(e2);
					}
					finally
					{
						cRMSpEntities?.Dispose();
					}
					break;
				}
			}
			else
			{
				result = false;
			}
		}
		catch (Exception e6)
		{
			ErrorSignal.FromCurrentContext().Raise(e6);
			result = false;
		}
		finally
		{
			cRMSpEntities?.Dispose();
			cRMSpIEntities?.Dispose();
			cRMSpIIIEntities?.Dispose();
		}
		return result;
	}
}

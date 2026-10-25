using System;
using System.Collections.Generic;
using System.Data.Objects;
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
public class CallerIdService : ICallerIdService
{
	public bool SendMessage(string username, string password, string facedMode, string data, string lineNumber, string telNumber, int callTypeId, string[] telInfo = null, string users = "", string fileName = "", string duration = "", string[] voipInfo = null, string exten = "", int devType = 1)
	{
		bool result = false;
		CRMSpEntities cRMSpEntities = null;
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
			MobCallerIdContentViewModel mobCallerIdContentViewModel = new MobCallerIdContentViewModel();
			string text = "";
			string text2 = "";
			CRMspCallerIDSelectPopUpSetting_Result cRMspCallerIDSelectPopUpSetting_Result = CIPopUpSetting.Get();
			if (cRMspCallerIDSelectPopUpSetting_Result == null)
			{
				return false;
			}
			int value;
			string trunkCallId;
			string trunkName;
			string text3;
			string text4;
			string trunkFileLocation;
			string trunkDestinationCycle;
			string preRecFileName;
			DateTime now;
			string callDay;
			CRMspCallerIDSearch_Result cRMspCallerIDSearch_Result;
			int result3;
			int value2;
			int value3;
			bool flag;
			string text6;
			if (username == "Shir" && password == "Palang")
			{
				value = 0;
				if (cRMspCallerIDSelectPopUpSetting_Result.PopUpJustForcmpReferUser.GetValueOrDefault())
				{
					value = 1;
				}
				if (cRMspCallerIDSelectPopUpSetting_Result.PopUpJustForcmpReferUserAndLinked.GetValueOrDefault())
				{
					value = 2;
				}
				if (facedMode == "Local")
				{
					if (telInfo != null)
					{
						text = "<div class='CallerIdDiv' id='" + telInfo[0] + "-" + telInfo[1] + "-" + telInfo[2] + "-" + telInfo[3] + "'>";
						text += "<div class='CI-I' onclick='OpenCompanyInfo(this);'>";
						text2 += telInfo[4].Replace("\r\n", "<br/>").Replace(" ", "&nbsp;");
						text += text2;
						text += "</div>";
						text += "<div class='CI-A'></div>";
						text += "</div>";
						mobCallerIdContentViewModel.CompanyId = telInfo[0];
						mobCallerIdContentViewModel.PersonId = telInfo[1];
						mobCallerIdContentViewModel.LastProjectId = telInfo[2];
						mobCallerIdContentViewModel.LastConversationId = telInfo[3];
						mobCallerIdContentViewModel.Message = telInfo[4].ToString();
					}
					goto IL_0e82;
				}
				if (!string.IsNullOrEmpty(duration) && callTypeId == 2)
				{
					try
					{
						if (duration != "0")
						{
							cRMSpEntities = new CRMSpEntities();
							cRMSpEntities.CRMspUpdateCallHistoryOnHookOff(fileName, duration, "-1", "");
							goto IL_0f49;
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
					}
					finally
					{
						cRMSpEntities?.Dispose();
					}
				}
				trunkCallId = null;
				trunkName = null;
				text3 = null;
				text4 = null;
				trunkFileLocation = null;
				trunkDestinationCycle = null;
				preRecFileName = null;
				string text5 = null;
				text6 = null;
				if (voipInfo != null)
				{
					trunkCallId = ((voipInfo[0] != null && voipInfo[0] != "") ? voipInfo[0] : null);
					trunkName = ((voipInfo[1] != null && voipInfo[1] != "") ? voipInfo[1] : null);
					text3 = ((voipInfo[2] != null && voipInfo[2] != "") ? voipInfo[2] : null);
					text4 = ((voipInfo[3] != null && voipInfo[3] != "") ? voipInfo[3] : null);
					trunkFileLocation = ((voipInfo[4] != null && voipInfo[4] != "") ? voipInfo[4] : null);
					trunkDestinationCycle = ((voipInfo[5] != null && voipInfo[5] != "") ? voipInfo[5] : null);
					preRecFileName = ((voipInfo[6] != null && voipInfo[6] != "") ? voipInfo[6] : null);
					if (Enumerable.Count<string>((IEnumerable<string>)voipInfo) > 7)
					{
						text5 = ((voipInfo[7] != null && voipInfo[7] != "") ? voipInfo[7] : null);
						text6 = ((voipInfo[8] != null && voipInfo[8] != "") ? voipInfo[8] : null);
					}
				}
				cRMSpIIIEntities = new CRMSpIIIEntities();
				CRMspCallerIDCleanPhoneNumberByUserCallPreNumber_Result cRMspCallerIDCleanPhoneNumberByUserCallPreNumber_Result = Enumerable.FirstOrDefault<CRMspCallerIDCleanPhoneNumberByUserCallPreNumber_Result>((IEnumerable<CRMspCallerIDCleanPhoneNumberByUserCallPreNumber_Result>)cRMSpIIIEntities.CRMspCallerIDCleanPhoneNumberByUserCallPreNumber(callTypeId, telNumber, text3, text4));
				if (cRMspCallerIDCleanPhoneNumberByUserCallPreNumber_Result != null)
				{
					string text7 = cRMspCallerIDCleanPhoneNumberByUserCallPreNumber_Result.PhoneNumber ?? "";
					string text8 = cRMspCallerIDCleanPhoneNumberByUserCallPreNumber_Result.TrunkSource ?? "";
					string text9 = cRMspCallerIDCleanPhoneNumberByUserCallPreNumber_Result.TrunkDestination ?? "";
					if (!string.IsNullOrWhiteSpace(text7) && !string.IsNullOrWhiteSpace(telNumber) && text7 != telNumber)
					{
						telNumber = text7;
					}
					if (!string.IsNullOrWhiteSpace(text8) && !string.IsNullOrWhiteSpace(text3) && text8 != text3)
					{
						text3 = text8;
					}
					if (!string.IsNullOrWhiteSpace(text9) && !string.IsNullOrWhiteSpace(text4) && text9 != text4)
					{
						text4 = text9;
					}
				}
				now = DateTime.Now;
				callDay = now.ToString("dddd", new PersianCulture());
				cRMSpEntities = new CRMSpEntities();
				cRMspCallerIDSearch_Result = Enumerable.FirstOrDefault<CRMspCallerIDSearch_Result>((IEnumerable<CRMspCallerIDSearch_Result>)Enumerable.ToList<CRMspCallerIDSearch_Result>((IEnumerable<CRMspCallerIDSearch_Result>)cRMSpEntities.CRMspCallerIDSearch(telNumber, lCID, result2)));
				result3 = 0;
				int.TryParse(lineNumber, out result3);
				value2 = 0;
				value3 = 0;
				flag = false;
				flag = ((cRMspCallerIDSelectPopUpSetting_Result.PopUpActiveWithExt.HasValue && cRMspCallerIDSelectPopUpSetting_Result.PopUpActiveWithExt != false) ? true : false);
				if (!string.IsNullOrWhiteSpace(text5) && !string.IsNullOrWhiteSpace(text6))
				{
					text5 = text5.ToLower();
					text6 = text6.ToLower();
					switch (text5)
					{
					case "incom":
						break;
					case "conn":
						goto IL_0526;
					case "cdr":
						goto IL_0576;
					default:
						goto IL_06b7;
					}
					if (flag || !(text6 == "out_in"))
					{
						goto IL_0f49;
					}
				}
				goto IL_06b7;
			}
			goto end_IL_0006;
			IL_0576:
			switch (text6)
			{
			case "out_in":
			{
				if (!flag)
				{
					break;
				}
				List<CRMspCallerIDCheckExistUserExtension_Result> list = Enumerable.ToList<CRMspCallerIDCheckExistUserExtension_Result>((IEnumerable<CRMspCallerIDCheckExistUserExtension_Result>)cRMSpEntities.CRMspCallerIDCheckExistUserExtension(text4));
				if (list != null && Enumerable.Any<CRMspCallerIDCheckExistUserExtension_Result>((IEnumerable<CRMspCallerIDCheckExistUserExtension_Result>)list))
				{
					break;
				}
				goto IL_0f49;
			}
			case "in_out":
				cRMSpEntities.CRMspInsertUpdateCallHistoryOnTrunkCdr(callTypeId, result3, telNumber, cRMspCallerIDSearch_Result?.CompanyID, now.ToString("HH:mm:ss"), now.ToString("yyyyMMdd", new PersianCulture()), callDay, -3, short.Parse(now.ToString("yyyy", new PersianCulture())), short.Parse(now.ToString("MM", new PersianCulture())), now.ToString("yyyyMMdd", new PersianCulture()), "", "", text4 ?? duration, cRMspCallerIDSearch_Result?.CompanyPersonID, fileName, data, appType, result2, trunkCallId, trunkName, text3, text4, trunkFileLocation, trunkDestinationCycle, preRecFileName);
				goto IL_0f49;
			case "in_in":
				goto IL_0f49;
			}
			goto IL_06b7;
			IL_0e82:
			IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
			string text10 = text;
			string text11 = users;
			if (string.IsNullOrEmpty(exten))
			{
				exten = "";
			}
			if (callTypeId == 2)
			{
				hubContext.Clients.All.addNewMessageToPage(text11, text10, exten, lineNumber);
				PushNotif.CallerIdNotify(text11, exten, lineNumber, mobCallerIdContentViewModel);
			}
			result = true;
			goto IL_0f49;
			IL_0526:
			if (flag && text6 == "out_in")
			{
				List<CRMspCallerIDCheckExistUserExtension_Result> list2 = Enumerable.ToList<CRMspCallerIDCheckExistUserExtension_Result>((IEnumerable<CRMspCallerIDCheckExistUserExtension_Result>)cRMSpEntities.CRMspCallerIDCheckExistUserExtension(text4));
				if (list2 != null && Enumerable.Any<CRMspCallerIDCheckExistUserExtension_Result>((IEnumerable<CRMspCallerIDCheckExistUserExtension_Result>)list2))
				{
					goto IL_06b7;
				}
			}
			goto IL_0f49;
			IL_06b7:
			if (cRMspCallerIDSearch_Result != null)
			{
				try
				{
					cRMSpEntities.CRMspInsertCallHistory(callTypeId, result3, telNumber, cRMspCallerIDSearch_Result.CompanyID, now.ToString("HH:mm:ss"), now.ToString("yyyyMMdd", new PersianCulture()), callDay, -3, short.Parse(now.ToString("yyyy", new PersianCulture())), short.Parse(now.ToString("MM", new PersianCulture())), now.ToString("yyyyMMdd", new PersianCulture()), "", "", duration, cRMspCallerIDSearch_Result.CompanyPersonID, fileName, data, appType, result2, trunkCallId, trunkName, text3, text4, trunkFileLocation, trunkDestinationCycle, preRecFileName, devType);
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
				}
				ObjectParameter objectParameter = new ObjectParameter("FormulaPopUpResult", "");
				cRMSpEntities.CRMspCallerIDFormulaPopUpResult(lineNumber, DateTime.Now.ToString("hh:mm:ss"), telNumber, cRMspCallerIDSearch_Result.cmpName ?? "", cRMspCallerIDSearch_Result.cmpPrsName ?? "", cRMspCallerIDSearch_Result.cmpName + " " + cRMspCallerIDSearch_Result.cmpPrsName, cRMspCallerIDSearch_Result.LastcnvscmpPerson ?? "", cRMspCallerIDSearch_Result.LastProject ?? "", cRMspCallerIDSearch_Result.LastcnvsRefUser ?? "", cRMspCallerIDSearch_Result.LastcnvsStatus ?? "", cRMspCallerIDSearch_Result.cmpReferUser ?? "", cRMspCallerIDSearch_Result.cmpActivityType ?? "", cRMspCallerIDSearch_Result.cmpCountry ?? "", cRMspCallerIDSearch_Result.cmpProvince ?? "", cRMspCallerIDSearch_Result.cmpCity ?? "", cRMspCallerIDSearch_Result.cmpPresentation ?? "", cRMspCallerIDSearch_Result.cmpCompanyType ?? "", cRMspCallerIDSearch_Result.cmpCompanyGroups ?? "", cRMspCallerIDSearch_Result.cmpSubGroupName ?? "", cRMspCallerIDSearch_Result.cmpCompanyGroupII ?? "", cRMspCallerIDSearch_Result.cmpCompanyGroupIII ?? "", cRMspCallerIDSearch_Result.cmpCompanyGroupIV ?? "", "", objectParameter, true);
				text = "<div class='CallerIdDiv' id='" + cRMspCallerIDSearch_Result.CompanyID + "-" + cRMspCallerIDSearch_Result.CompanyPersonID + "-" + cRMspCallerIDSearch_Result.LastProjectId + "-" + cRMspCallerIDSearch_Result.LastConversationId + "'>";
				text += "<div class='CI-I' onclick='OpenCompanyInfo(this);'>";
				text2 += objectParameter.Value.ToString().Replace("\r\n", "<br/>").Replace(" ", "&nbsp;");
				text += text2;
				text += "</div>";
				text += "<div class='CI-A'></div>";
				text += "</div>";
				value2 = cRMspCallerIDSearch_Result.CompanyID.GetValueOrDefault();
				value3 = cRMspCallerIDSearch_Result.CompanyPersonID.GetValueOrDefault();
				mobCallerIdContentViewModel.CompanyId = cRMspCallerIDSearch_Result.CompanyID?.ToString();
				mobCallerIdContentViewModel.PersonId = cRMspCallerIDSearch_Result.CompanyPersonID?.ToString();
				mobCallerIdContentViewModel.LastProjectId = cRMspCallerIDSearch_Result.LastProjectId?.ToString();
				mobCallerIdContentViewModel.LastConversationId = cRMspCallerIDSearch_Result.LastConversationId?.ToString();
				mobCallerIdContentViewModel.Message = objectParameter.Value.ToString();
			}
			else
			{
				try
				{
					cRMSpEntities.CRMspInsertCallHistory(callTypeId, result3, telNumber, null, now.ToString("HH:mm:ss"), now.ToString("yyyyMMdd", new PersianCulture()), callDay, -3, short.Parse(now.ToString("yyyy", new PersianCulture())), short.Parse(now.ToString("MM", new PersianCulture())), now.ToString("yyyyMMdd", new PersianCulture()), "", "", duration, null, fileName, data, appType, result2, trunkCallId, trunkName, text3, text4, trunkFileLocation, trunkDestinationCycle, preRecFileName, devType);
				}
				catch (Exception e3)
				{
					ErrorSignal.FromCurrentContext().Raise(e3);
				}
				if (cRMspCallerIDSelectPopUpSetting_Result.PopUpDeActiveForUnknownNumber.GetValueOrDefault())
				{
					users = "|0|";
					goto IL_0f49;
				}
				text = "<div class='CallerIdDiv'>";
				text2 = text2 + Labels.PopUpCallerIdLine + ":&nbsp;" + lineNumber + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + Labels.PopUpCallerIdInTime + ":&nbsp;" + DateTime.Now.ToString("hh:mm:ss");
				text2 += "<br/>";
				text2 = text2 + Labels.PopUpCallerIdTel + ":&nbsp;<span>" + telNumber + "</span>";
				text2 += "<br/>";
				text2 = text2 + Labels.PopUpCallerIdCmpName + ":&nbsp;" + Labels.PopUpCallerIdNumberNotRegister;
				text = text + text2 + "</div>";
				string text12 = "";
				text12 = text12 + Labels.PopUpCallerIdInTime + ":&nbsp;" + DateTime.Now.ToString("hh:mm:ss");
				text12 += "<br/>";
				text12 = text12 + Labels.PopUpCallerIdTel + ":&nbsp;<span>" + telNumber + "</span>";
				text12 += "<br/>";
				text12 = text12 + Labels.PopUpCallerIdCmpName + ":&nbsp;" + Labels.PopUpCallerIdNumberNotRegister;
				mobCallerIdContentViewModel.Message = text12.ToString();
			}
			if (cRMspCallerIDSelectPopUpSetting_Result.PopUpDeActive.GetValueOrDefault())
			{
				users = "|0|";
				goto IL_0f49;
			}
			int result4 = 3;
			if (cRMspCallerIDSearch_Result != null && cRMspCallerIDSearch_Result.cmpReferUserId.HasValue)
			{
				int.TryParse(cRMspCallerIDSearch_Result.cmpReferUserId.ToString(), out result4);
			}
			users = "|";
			List<int?> list3 = Enumerable.ToList<int?>((IEnumerable<int?>)cRMSpEntities.CRMspCallerIDSelectRejectPopUpUsers(value, result4, result3));
			if (Enumerable.Any<int?>((IEnumerable<int?>)list3))
			{
				users = Enumerable.Aggregate<int?, string>(Enumerable.Where<int?>((IEnumerable<int?>)list3, (Func<int?, bool>)((int? userId) => userId.HasValue)), users, (Func<string, int?, string>)delegate(string current, int? userId)
				{
					int? num = userId;
					return current + num + "|";
				});
			}
			if (!string.IsNullOrEmpty(telNumber) && callTypeId == 2 && telNumber.Substring(0, 2) == "09")
			{
				cRMSpEntities.CRMspAutoSendSMSFromCallerID(value2, value3, telNumber, Configuration.AppType, result2, 0);
			}
			goto IL_0e82;
			IL_0f49:
			result = false;
			end_IL_0006:;
		}
		catch (Exception e4)
		{
			ErrorSignal.FromCurrentContext().Raise(e4);
			result = false;
		}
		finally
		{
			cRMSpEntities?.Dispose();
			cRMSpIIIEntities?.Dispose();
		}
		return result;
	}

	public bool IsReady()
	{
		return true;
	}
}

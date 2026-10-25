using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using CRMIdeal.Hubs;
using Elmah;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CRMIdeal.Controllers;

public class CallerIdAPIController : ApiController
{
	public class CallerIdAPIVoipInfoViewModel
	{
		public string CallId { get; set; }

		public string TrunkName { get; set; }

		public string TrunkSource { get; set; }

		public string TrunkDest { get; set; }

		public string Duration { get; set; }

		public string RecFileName { get; set; }

		public string ExtenCycle { get; set; }
	}

	public enum CallerIdAPIServiceResultStatus
	{
		Success = 1,
		Fail,
		Error
	}

	public class CallerIdAPIServiceResult<T>
	{
		public T Data;

		[JsonConverter(typeof(StringEnumConverter))]
		public CallerIdAPIServiceResultStatus Status;

		public string Message;

		public CallerIdAPIServiceResult()
		{
			Status = CallerIdAPIServiceResultStatus.Success;
		}

		public CallerIdAPIServiceResult(CallerIdAPIServiceResultStatus type)
		{
			Status = type;
		}
	}

	private static CultureInfo _CultureInfo_Fa = new CultureInfo("fa-IR");

	[System.Web.Http.HttpPost]
	public CallerIdAPIServiceResult<bool> SendPopupMessage(string username = "", string password = "", string exten = "", string faced = "", string rejectUsers = "", string voipDetailInfo = "", string companyDetailInfo = "", int? langId = 1065)
	{
		string message = "";
		bool flag = false;
		CRMSpEntities cRMSpEntities = null;
		List<SelectListItem> list = new List<SelectListItem>();
		CRMSpIIIEntities cRMSpIIIEntities = null;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int num = 0;
			num = ((langId.GetValueOrDefault() == 0) ? result : langId.GetValueOrDefault(result));
			_ = CRMIdeal.Classes.Common.Configuration.AppType;
			MobCallerIdContentViewModel mobCallerIdContentViewModel = new MobCallerIdContentViewModel();
			string text = "";
			string text2 = "";
			CallerId.AsteriskCall.Data data = null;
			if (!string.IsNullOrWhiteSpace(voipDetailInfo))
			{
				data = JsonConvert.DeserializeObject<CallerId.AsteriskCall.Data>(HttpUtility.UrlDecode(voipDetailInfo));
			}
			CRMspSelectCrmsysCISetting_Result cRMspSelectCrmsysCISetting_Result = CISetting.Get();
			CRMspCallerIDSelectPopUpSetting_Result cRMspCallerIDSelectPopUpSetting_Result = CIPopUpSetting.Get();
			if (cRMspCallerIDSelectPopUpSetting_Result == null)
			{
				return new CallerIdAPIServiceResult<bool>
				{
					Message = Messages.ErrorNotFoundSetting,
					Status = CallerIdAPIServiceResultStatus.Error,
					Data = false
				};
			}
			if (string.IsNullOrWhiteSpace(faced) && cRMspSelectCrmsysCISetting_Result != null)
			{
				faced = cRMspSelectCrmsysCISetting_Result.VoipApiType;
			}
			list.Add(new SelectListItem
			{
				Text = "UseClientNameForNetworking",
				Value = cRMspCallerIDSelectPopUpSetting_Result.UseClientNameForNetworking.GetValueOrDefault().ToString()
			});
			list.Add(new SelectListItem
			{
				Text = "PopUpDeActive",
				Value = cRMspCallerIDSelectPopUpSetting_Result.PopUpDeActive.GetValueOrDefault().ToString()
			});
			list.Add(new SelectListItem
			{
				Text = "PopUpWinFormIDeActive",
				Value = cRMspCallerIDSelectPopUpSetting_Result.PopUpWinFormIDeActive.GetValueOrDefault().ToString()
			});
			list.Add(new SelectListItem
			{
				Text = "PopUpDeActiveForUnknownNumber",
				Value = cRMspCallerIDSelectPopUpSetting_Result.PopUpDeActiveForUnknownNumber.GetValueOrDefault().ToString()
			});
			list.Add(new SelectListItem
			{
				Text = "PopUpJustForcmpReferUser",
				Value = cRMspCallerIDSelectPopUpSetting_Result.PopUpJustForcmpReferUser.GetValueOrDefault().ToString()
			});
			list.Add(new SelectListItem
			{
				Text = "PopUpJustForcmpReferUserAndLinked",
				Value = cRMspCallerIDSelectPopUpSetting_Result.PopUpJustForcmpReferUserAndLinked.GetValueOrDefault().ToString()
			});
			list.Add(new SelectListItem
			{
				Text = "PopUpActiveWithExt",
				Value = cRMspCallerIDSelectPopUpSetting_Result.PopUpActiveWithExt.GetValueOrDefault().ToString()
			});
			if (string.IsNullOrWhiteSpace(faced))
			{
				faced = "local";
			}
			if (username == "Shir" && password == "Palang")
			{
				if (faced.ToLower().Trim() == "local")
				{
					string[] array = null;
					if (!string.IsNullOrWhiteSpace(companyDetailInfo))
					{
						array = JsonConvert.DeserializeObject<string[]>(HttpUtility.UrlDecode(companyDetailInfo));
					}
					if (array != null)
					{
						text = "<div class='CallerIdDiv' id='" + array[0] + "-" + array[1] + "-" + array[2] + "-" + array[3] + "'>";
						text += "<div class='CI-I' onclick='OpenCompanyInfo(this);'>";
						text2 += array[4].Replace("\r\n", "<br/>").Replace(" ", "&nbsp;");
						text += text2;
						text += "</div>";
						text += "<div class='CI-A'></div>";
						text += "</div>";
						mobCallerIdContentViewModel.CompanyId = array[0];
						mobCallerIdContentViewModel.PersonId = array[1];
						mobCallerIdContentViewModel.LastProjectId = array[2];
						mobCallerIdContentViewModel.LastConversationId = array[3];
						mobCallerIdContentViewModel.Message = array[4].ToString();
					}
				}
				else if (faced.ToLower().Trim() == "host")
				{
					cRMSpEntities = new CRMSpEntities();
					cRMSpIIIEntities = new CRMSpIIIEntities();
					int value = 0;
					if (cRMspCallerIDSelectPopUpSetting_Result.PopUpJustForcmpReferUser.GetValueOrDefault())
					{
						value = 1;
					}
					if (cRMspCallerIDSelectPopUpSetting_Result.PopUpJustForcmpReferUserAndLinked.GetValueOrDefault())
					{
						value = 2;
					}
					CRMspCallerIDSearch_Result cRMspCallerIDSearch_Result = new CRMspCallerIDSearch_Result();
					int result2 = 0;
					string text3 = "";
					string text4 = "";
					string text5 = "";
					string text6 = "";
					string text7 = "";
					string text8 = "";
					if (data != null)
					{
						int.TryParse(data.CrmCallTypeId.ToString(), out result2);
						text3 = data.CalcTelNumClean ?? "";
						text4 = data.Source ?? "";
						text5 = data.Destination ?? "";
						text6 = data.TelNumNoClean ?? "";
						text7 = data.SourceNoClean ?? "";
						text8 = data.DestinationNoClean ?? "";
					}
					CRMspCallerIDCleanPhoneNumberByUserCallPreNumber_Result cRMspCallerIDCleanPhoneNumberByUserCallPreNumber_Result = Enumerable.FirstOrDefault<CRMspCallerIDCleanPhoneNumberByUserCallPreNumber_Result>((IEnumerable<CRMspCallerIDCleanPhoneNumberByUserCallPreNumber_Result>)cRMSpIIIEntities.CRMspCallerIDCleanPhoneNumberByUserCallPreNumber(result2, text3, text4, text5));
					if (cRMspCallerIDCleanPhoneNumberByUserCallPreNumber_Result != null)
					{
						string text9 = cRMspCallerIDCleanPhoneNumberByUserCallPreNumber_Result.PhoneNumber ?? "";
						string text10 = cRMspCallerIDCleanPhoneNumberByUserCallPreNumber_Result.TrunkSource ?? "";
						string text11 = cRMspCallerIDCleanPhoneNumberByUserCallPreNumber_Result.TrunkDestination ?? "";
						if (!string.IsNullOrWhiteSpace(text9) && !string.IsNullOrWhiteSpace(text3) && text9 != text3)
						{
							text3 = text9;
						}
						if (!string.IsNullOrWhiteSpace(text10) && !string.IsNullOrWhiteSpace(text4) && text10 != text4)
						{
							text4 = text10;
						}
						if (!string.IsNullOrWhiteSpace(text11) && !string.IsNullOrWhiteSpace(text5) && text11 != text5)
						{
							text5 = text11;
						}
						if (data != null)
						{
							data.CalcTelNumClean = text3;
							data.Source = text4;
							data.Destination = text5;
						}
					}
					if (result2 == 1)
					{
						if (!string.IsNullOrWhiteSpace(text6) && !string.IsNullOrWhiteSpace(text3) && text6 != text3)
						{
							text3 = CallerId.CleanNumber(text6, result2, text4, text5);
							if (data != null)
							{
								data.CalcTelNumClean = text3;
							}
						}
						if (!string.IsNullOrWhiteSpace(text7) && !string.IsNullOrWhiteSpace(text4) && text7 != text4)
						{
							text4 = CallerId.CleanNumber(text7, result2, text4, text5);
							if (data != null)
							{
								data.Source = text4;
							}
						}
						if (!string.IsNullOrWhiteSpace(text8) && !string.IsNullOrWhiteSpace(text5) && text8 != text5)
						{
							text5 = CallerId.CleanNumber(text8, result2, text4, text5);
							if (data != null)
							{
								data.Destination = text5;
							}
						}
					}
					if (data != null)
					{
						int callHistoryId = CallerId.GetCallHistoryId(data.UId, data.LinkedId);
						cRMspCallerIDSearch_Result = Enumerable.FirstOrDefault<CRMspCallerIDSearch_Result>((IEnumerable<CRMspCallerIDSearch_Result>)cRMSpEntities.CRMspCallerIDSearch(data.CalcTelNumClean, num, result));
						callHistoryId = InsertUpdateAsteriskEvent(data.EventType, data.CrmCallTypeId, data.CalcLineNumber, data.CalcTelNumClean, data.Source, data.Destination, string.IsNullOrWhiteSpace(data.DateReceived) ? null : new DateTime?(DateTime.Parse(data.DateReceived)), string.IsNullOrWhiteSpace(data.DateReceived) ? null : DateTime.Parse(data.DateReceived).ToString("yyyyMMdd", _CultureInfo_Fa), string.IsNullOrWhiteSpace(data.DateReceived) ? null : DateTime.Parse(data.DateReceived).ToString("HH:mm", _CultureInfo_Fa), string.IsNullOrWhiteSpace(data.DateReceived) ? null : DateTime.Parse(data.DateReceived).ToString("dddd", _CultureInfo_Fa), data.StartTime?.ToString("HH:mm", _CultureInfo_Fa), data.EndTime?.ToString("HH:mm", _CultureInfo_Fa), (data.Duration.GetValueOrDefault() == 0L) ? "" : data.Duration.ToString(), data.UId, data.LinkedId, data.Channel, null, data.CalcDevType, null, null, null, null, null, null, callHistoryId, null, null, null, data.CalcIsFinished, data.InsertMode, data.PreFileName, data.FileName, data.FileLocation);
						if (data.EventType == "NewChannel")
						{
							CallerId.SetCallHistoryId(callHistoryId, data.UId, data.LinkedId);
						}
						else if (data.EventType == "CDR")
						{
							CallerId.RemoveAllCalls(data.UId, data.LinkedId);
						}
					}
					int value2 = 0;
					int value3 = 0;
					if (cRMspCallerIDSearch_Result != null)
					{
						ObjectParameter objectParameter = new ObjectParameter("FormulaPopUpResult", "");
						cRMSpEntities.CRMspCallerIDFormulaPopUpResult(data.CalcLineNumber.GetValueOrDefault().ToString(), DateTime.Now.ToString("hh:mm:ss"), data.CalcTelNumClean, cRMspCallerIDSearch_Result.cmpName ?? "", cRMspCallerIDSearch_Result.cmpPrsName ?? "", cRMspCallerIDSearch_Result.cmpName + " " + cRMspCallerIDSearch_Result.cmpPrsName, cRMspCallerIDSearch_Result.LastcnvscmpPerson ?? "", cRMspCallerIDSearch_Result.LastProject ?? "", cRMspCallerIDSearch_Result.LastcnvsRefUser ?? "", cRMspCallerIDSearch_Result.LastcnvsStatus ?? "", cRMspCallerIDSearch_Result.cmpReferUser ?? "", cRMspCallerIDSearch_Result.cmpActivityType ?? "", cRMspCallerIDSearch_Result.cmpCountry ?? "", cRMspCallerIDSearch_Result.cmpProvince ?? "", cRMspCallerIDSearch_Result.cmpCity ?? "", cRMspCallerIDSearch_Result.cmpPresentation ?? "", cRMspCallerIDSearch_Result.cmpCompanyType ?? "", cRMspCallerIDSearch_Result.cmpCompanyGroups ?? "", cRMspCallerIDSearch_Result.cmpSubGroupName ?? "", cRMspCallerIDSearch_Result.cmpCompanyGroupII ?? "", cRMspCallerIDSearch_Result.cmpCompanyGroupIII ?? "", cRMspCallerIDSearch_Result.cmpCompanyGroupIV ?? "", "", objectParameter, true);
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
						if (cRMspCallerIDSelectPopUpSetting_Result.PopUpDeActiveForUnknownNumber.GetValueOrDefault())
						{
							rejectUsers = "|0|";
							goto IL_1194;
						}
						text = "<div class='CallerIdDiv'>";
						text2 = text2 + Labels.ResourceManager.GetString("PopUpCallerIdLine", new CultureInfo(num)) + ":&nbsp;" + data.CalcLineNumber + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + Labels.ResourceManager.GetString("PopUpCallerIdInTime", new CultureInfo(num)) + ":&nbsp;" + DateTime.Now.ToString("hh:mm:ss");
						text2 += "<br/>";
						text2 = text2 + Labels.ResourceManager.GetString("PopUpCallerIdTel", new CultureInfo(num)) + ":&nbsp;<span>" + data.CalcTelNumClean + "</span>";
						text2 += "<br/>";
						text2 = text2 + Labels.ResourceManager.GetString("PopUpCallerIdCmpName", new CultureInfo(num)) + ":&nbsp;" + Labels.ResourceManager.GetString("PopUpCallerIdNumberNotRegister", new CultureInfo(num));
						text = text + text2 + "</div>";
						string text12 = "";
						text12 = text12 + Labels.ResourceManager.GetString("PopUpCallerIdInTime", new CultureInfo(num)) + ":&nbsp;" + DateTime.Now.ToString("hh:mm:ss");
						text12 += "<br/>";
						text12 = text12 + Labels.ResourceManager.GetString("PopUpCallerIdTel", new CultureInfo(num)) + ":&nbsp;<span>" + data.CalcTelNumClean + "</span>";
						text12 += "<br/>";
						text12 = text12 + Labels.ResourceManager.GetString("PopUpCallerIdCmpName", new CultureInfo(num)) + ":&nbsp;" + Labels.ResourceManager.GetString("PopUpCallerIdNumberNotRegister", new CultureInfo(num));
						mobCallerIdContentViewModel.Message = text12.ToString();
					}
					if (cRMspCallerIDSelectPopUpSetting_Result.PopUpDeActive.GetValueOrDefault())
					{
						rejectUsers = "|0|";
						goto IL_1194;
					}
					int result3 = 3;
					if (cRMspCallerIDSearch_Result != null && cRMspCallerIDSearch_Result.cmpReferUserId.HasValue)
					{
						int.TryParse(cRMspCallerIDSearch_Result.cmpReferUserId.ToString(), out result3);
					}
					rejectUsers = "|";
					List<int?> list2 = Enumerable.ToList<int?>((IEnumerable<int?>)cRMSpEntities.CRMspCallerIDSelectRejectPopUpUsers(value, result3, data.CalcLineNumber));
					if (Enumerable.Any<int?>((IEnumerable<int?>)list2))
					{
						rejectUsers = Enumerable.Aggregate<int?, string>(Enumerable.Where<int?>((IEnumerable<int?>)list2, (Func<int?, bool>)((int? userId) => userId.HasValue)), rejectUsers, (Func<string, int?, string>)delegate(string current, int? userId)
						{
							int? num2 = userId;
							return current + num2 + "|";
						});
					}
					if (!string.IsNullOrEmpty(data.CalcTelNumClean) && data.CrmCallTypeId.GetValueOrDefault() == 2 && data.CalcTelNumClean.Substring(0, 2) == "09")
					{
						cRMSpEntities.CRMspAutoSendSMSFromCallerID(value2, value3, data.CalcTelNumClean, CRMIdeal.Classes.Common.Configuration.AppType, result, 0);
					}
				}
				if (data.EventType == "NewChannel")
				{
					if (data.CrmCallTypeId.GetValueOrDefault() == 2 && !cRMspCallerIDSelectPopUpSetting_Result.PopUpActiveWithExt.GetValueOrDefault())
					{
					}
				}
				else if (data.EventType == "NewExten")
				{
					(!cRMspCallerIDSelectPopUpSetting_Result.PopUpActiveWithExt).GetValueOrDefault();
				}
				IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
				string text13 = text;
				string text14 = rejectUsers;
				if (string.IsNullOrEmpty(exten))
				{
					exten = "";
				}
				if (data.CrmCallTypeId.GetValueOrDefault() == 2)
				{
					hubContext.Clients.All.addNewMessageToPage(text14, text13, exten, data.CalcLineNumber, list);
					PushNotif.CallerIdNotify(text14, exten, data.CalcLineNumber.GetValueOrDefault().ToString(), mobCallerIdContentViewModel);
				}
				flag = true;
				goto IL_1194;
			}
			return new CallerIdAPIServiceResult<bool>
			{
				Message = Messages.msgErrorCheckUsernamePassword,
				Status = CallerIdAPIServiceResultStatus.Error,
				Data = false
			};
			IL_1194:
			flag = false;
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			flag = false;
			message = "Error: " + ex.Message;
		}
		finally
		{
			cRMSpEntities?.Dispose();
			cRMSpIIIEntities?.Dispose();
		}
		return new CallerIdAPIServiceResult<bool>
		{
			Message = message,
			Data = flag,
			Status = (flag ? CallerIdAPIServiceResultStatus.Success : CallerIdAPIServiceResultStatus.Fail)
		};
	}

	private int InsertUpdateAsteriskEvent(string data = null, int? callTypeId = null, int? lineNumber = null, string phoneNumber = null, string trunkSource = null, string trunkDestination = null, DateTime? callDateTime = null, string callDate = null, string callTime = null, string callDay = null, string startTime = null, string endTime = null, string duration = null, string trunkCallId = null, string trunkCallIds = null, string trunkName = null, string trunkDestinationCycle = null, int? devType = null, string iVRAuthResult = null, string callerIDDetectData = null, int? numberEditedUserId = null, string note = null, int? noteRegisterUserId = null, int? noteEditedUserId = null, int? callHistoryID = null, int? companyID = null, int? companyPersonId = null, int? conversationID = null, bool? isFinished = null, int? mode = null, string preFileName = "", string fileName = "", string fileLocation = "")
	{
		int result = 0;
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		try
		{
			DateTime now = DateTime.Now;
			ObjectParameter objectParameter = new ObjectParameter("InsertedId", 0);
			ObjectParameter objectParameter2 = new ObjectParameter("UpdatedId", 0);
			Enumerable.FirstOrDefault<CRMspInsertUpdateCallHistoryInAsteriskEvent_Result>((IEnumerable<CRMspInsertUpdateCallHistoryInAsteriskEvent_Result>)cRMSpIIEntities.CRMspInsertUpdateCallHistoryInAsteriskEvent(data, callTypeId, lineNumber, phoneNumber, trunkSource, trunkDestination, callDateTime, callDate, callTime, callDay, startTime, endTime, duration, trunkCallId, trunkCallIds, trunkName, preFileName, fileName, fileLocation, trunkDestinationCycle, devType, iVRAuthResult, callerIDDetectData, numberEditedUserId, note, noteRegisterUserId, noteEditedUserId, callHistoryID, companyID, companyPersonId, conversationID, isFinished, -3, short.Parse(now.ToString("yyyy", _CultureInfo_Fa)), short.Parse(now.ToString("MM", _CultureInfo_Fa)), now, now.ToString("yyyyMMdd", _CultureInfo_Fa), "win", 1065, 1065, mode, objectParameter, objectParameter2));
			if (objectParameter != null && !string.IsNullOrWhiteSpace(objectParameter.Value.ToString()) && objectParameter.Value.ToString() != "0")
			{
				int.TryParse(objectParameter.Value.ToString(), out result);
			}
			if (objectParameter2 != null && !string.IsNullOrWhiteSpace(objectParameter2.Value.ToString()) && objectParameter2.Value.ToString() != "0")
			{
				int.TryParse(objectParameter2.Value.ToString(), out result);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpIIEntities.Dispose();
		}
		return result;
	}

	[System.Web.Http.HttpPost]
	public CallerIdAPIServiceResult<bool> SendMessage(string UserName, string Password, string LineNumber, string EventType, int CallType, string VoipInfo, int langId = 0, string Extention = "", int CmpSearchMode = 0, string CmpSearchVal = "", bool? ShowPopup = false)
	{
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		bool data = false;
		string message = "";
		CallerIdAPIServiceResultStatus status = CallerIdAPIServiceResultStatus.Fail;
		string text = "";
		string text2 = "";
		string text3 = "";
		MobCallerIdContentViewModel mobCallerIdContentViewModel = new MobCallerIdContentViewModel();
		CRMspCallerIDSearch_Result cRMspCallerIDSearch_Result = new CRMspCallerIDSearch_Result();
		string text4 = "|0|";
		int result = 0;
		CRMspCallerIDSelectPopUpSetting_Result cRMspCallerIDSelectPopUpSetting_Result = null;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			int num = ((langId > 0) ? langId : result2);
			new BaseInfo().SetCulture(num);
			if (!VersionBuyer.APIVoip)
			{
				message = Messages.VersionBuyModule;
				data = false;
				status = CallerIdAPIServiceResultStatus.Error;
			}
			else
			{
				string text5 = "CallerIdAPI";
				string text6 = "BP";
				string text7 = "";
				string text8 = "";
				if (base.Request.Headers.Contains("token"))
				{
					text8 = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				}
				if (string.IsNullOrWhiteSpace(text8))
				{
					message = Messages.msgErrorNotEnteredToken;
					data = false;
					status = CallerIdAPIServiceResultStatus.Error;
				}
				else if (text8 != text5)
				{
					message = Messages.msgErrorAccessingToken;
					data = false;
					status = CallerIdAPIServiceResultStatus.Error;
				}
				else
				{
					CRMSpEntities cRMSpEntities = null;
					CRMSpIEntities cRMSpIEntities = null;
					CRMSpIIIEntities cRMSpIIIEntities = null;
					try
					{
						string appType = CRMIdeal.Classes.Common.Configuration.AppType;
						string lockSerial = SysSeting.Get().LockSerial;
						if (!string.IsNullOrEmpty(lockSerial))
						{
							string[] array = lockSerial.Split(new char[1] { '-' });
							if (array != null)
							{
								text7 = array[^2];
							}
						}
						string text9 = "";
						string text10 = "";
						cRMspCallerIDSelectPopUpSetting_Result = CIPopUpSetting.Get();
						string trunkCallId;
						string trunkName;
						string text11;
						string text12;
						string text13;
						string recFileName;
						string trunkDestinationCycle;
						string text14;
						if (cRMspCallerIDSelectPopUpSetting_Result == null || string.IsNullOrWhiteSpace(VoipInfo))
						{
							message = Messages.msgErrorInReadInfo;
							data = false;
							status = CallerIdAPIServiceResultStatus.Error;
						}
						else if (text6 == UserName && text7 == Password)
						{
							trunkCallId = null;
							trunkName = null;
							text11 = null;
							text12 = null;
							text13 = null;
							recFileName = null;
							trunkDestinationCycle = null;
							text14 = "";
							if (string.IsNullOrWhiteSpace(VoipInfo))
							{
								goto IL_02d8;
							}
							CallerIdAPIVoipInfoViewModel callerIdAPIVoipInfoViewModel = new JavaScriptSerializer().Deserialize<CallerIdAPIVoipInfoViewModel>(VoipInfo);
							try
							{
								if (callerIdAPIVoipInfoViewModel != null)
								{
									trunkCallId = (string.IsNullOrWhiteSpace(callerIdAPIVoipInfoViewModel.CallId) ? null : callerIdAPIVoipInfoViewModel.CallId);
									trunkName = (string.IsNullOrWhiteSpace(callerIdAPIVoipInfoViewModel.TrunkName) ? null : callerIdAPIVoipInfoViewModel.TrunkName);
									text11 = (string.IsNullOrWhiteSpace(callerIdAPIVoipInfoViewModel.TrunkSource) ? null : callerIdAPIVoipInfoViewModel.TrunkSource);
									text12 = (string.IsNullOrWhiteSpace(callerIdAPIVoipInfoViewModel.TrunkDest) ? null : callerIdAPIVoipInfoViewModel.TrunkDest);
									text13 = (string.IsNullOrWhiteSpace(callerIdAPIVoipInfoViewModel.Duration) ? null : callerIdAPIVoipInfoViewModel.Duration);
									recFileName = (string.IsNullOrWhiteSpace(callerIdAPIVoipInfoViewModel.RecFileName) ? null : callerIdAPIVoipInfoViewModel.RecFileName);
									trunkDestinationCycle = (string.IsNullOrWhiteSpace(callerIdAPIVoipInfoViewModel.ExtenCycle) ? null : callerIdAPIVoipInfoViewModel.ExtenCycle);
									goto IL_02d8;
								}
								message = Messages.msgErrorInReadInfo;
								data = false;
								status = CallerIdAPIServiceResultStatus.Error;
							}
							catch (Exception e)
							{
								ErrorSignal.FromCurrentContext().Raise(e);
								message = string.Format(Messages.ErrorInFormat, "(VoipInfo)");
								data = false;
								status = CallerIdAPIServiceResultStatus.Error;
							}
						}
						else
						{
							message = Messages.LoginNotSuccess;
							data = false;
							status = CallerIdAPIServiceResultStatus.Error;
						}
						goto end_IL_0113;
						IL_02d8:
						text14 = CallType switch
						{
							1 => (!string.IsNullOrEmpty(text12)) ? text12 : "", 
							2 => (!string.IsNullOrEmpty(text11)) ? text11 : "", 
							_ => (!string.IsNullOrEmpty(text12)) ? text12 : "", 
						};
						cRMSpIIIEntities = new CRMSpIIIEntities();
						CRMspCallerIDCleanPhoneNumberByUserCallPreNumber_Result cRMspCallerIDCleanPhoneNumberByUserCallPreNumber_Result = Enumerable.FirstOrDefault<CRMspCallerIDCleanPhoneNumberByUserCallPreNumber_Result>((IEnumerable<CRMspCallerIDCleanPhoneNumberByUserCallPreNumber_Result>)cRMSpIIIEntities.CRMspCallerIDCleanPhoneNumberByUserCallPreNumber(CallType, text14, text11, text12));
						if (cRMspCallerIDCleanPhoneNumberByUserCallPreNumber_Result != null)
						{
							string text15 = cRMspCallerIDCleanPhoneNumberByUserCallPreNumber_Result.PhoneNumber ?? "";
							string text16 = cRMspCallerIDCleanPhoneNumberByUserCallPreNumber_Result.TrunkSource ?? "";
							string text17 = cRMspCallerIDCleanPhoneNumberByUserCallPreNumber_Result.TrunkDestination ?? "";
							if (!string.IsNullOrWhiteSpace(text15) && !string.IsNullOrWhiteSpace(text14) && text15 != text14)
							{
								text14 = text15;
							}
							if (!string.IsNullOrWhiteSpace(text16) && !string.IsNullOrWhiteSpace(text11) && text16 != text11)
							{
								text11 = text16;
							}
							if (!string.IsNullOrWhiteSpace(text17) && !string.IsNullOrWhiteSpace(text12) && text17 != text12)
							{
								text12 = text17;
							}
						}
						if (string.IsNullOrEmpty(text14))
						{
							message = Messages.msgErrorNotEntererdCallerIdTelNumber;
							data = false;
							status = CallerIdAPIServiceResultStatus.Error;
						}
						else
						{
							DateTime now = DateTime.Now;
							string text18 = now.ToString("yyyyMMdd", new PersianCulture());
							int value = -3;
							string callDay = now.ToString("dddd", new PersianCulture());
							short value2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
							short value3 = short.Parse(now.ToString("MM", new PersianCulture()));
							string callTime = now.ToString("HH:mm:ss");
							string data2 = "";
							string text19 = (EventType ?? "").ToLower();
							string preRecFileName = "\\" + now.ToString("yyyy", new CultureInfo("en-US")) + "\\" + now.ToString("MM", new CultureInfo("en-US")) + "\\" + now.ToString("dd", new CultureInfo("en-US")) + "\\";
							int.TryParse(LineNumber, out result);
							int num2 = 0;
							int num3 = 0;
							cRMSpEntities = new CRMSpEntities();
							cRMSpIEntities = new CRMSpIEntities();
							if (CmpSearchMode != 0 && !string.IsNullOrWhiteSpace(CmpSearchVal))
							{
								CRMspCallerIDSearchInMode_Result cRMspCallerIDSearchInMode_Result = Enumerable.FirstOrDefault<CRMspCallerIDSearchInMode_Result>((IEnumerable<CRMspCallerIDSearchInMode_Result>)cRMSpIEntities.CRMspCallerIDSearchInMode(CmpSearchMode, CmpSearchVal, text14, num, result2));
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
								cRMspCallerIDSearch_Result = Enumerable.FirstOrDefault<CRMspCallerIDSearch_Result>((IEnumerable<CRMspCallerIDSearch_Result>)cRMSpEntities.CRMspCallerIDSearch(text14, num, result2));
							}
							if (ShowPopup.GetValueOrDefault())
							{
								if (cRMspCallerIDSearch_Result != null)
								{
									ObjectParameter objectParameter = new ObjectParameter("FormulaPopUpResult", "");
									cRMSpEntities.CRMspCallerIDFormulaPopUpResult(LineNumber, DateTime.Now.ToString("hh:mm:ss"), text14, cRMspCallerIDSearch_Result.cmpName ?? "", cRMspCallerIDSearch_Result.cmpPrsName ?? "", cRMspCallerIDSearch_Result.cmpName + " " + cRMspCallerIDSearch_Result.cmpPrsName, cRMspCallerIDSearch_Result.LastcnvscmpPerson ?? "", cRMspCallerIDSearch_Result.LastProject ?? "", cRMspCallerIDSearch_Result.LastcnvsRefUser ?? "", cRMspCallerIDSearch_Result.LastcnvsStatus ?? "", cRMspCallerIDSearch_Result.cmpReferUser ?? "", cRMspCallerIDSearch_Result.cmpActivityType ?? "", cRMspCallerIDSearch_Result.cmpCountry ?? "", cRMspCallerIDSearch_Result.cmpProvince ?? "", cRMspCallerIDSearch_Result.cmpCity ?? "", cRMspCallerIDSearch_Result.cmpPresentation ?? "", cRMspCallerIDSearch_Result.cmpCompanyType ?? "", cRMspCallerIDSearch_Result.cmpCompanyGroups ?? "", cRMspCallerIDSearch_Result.cmpSubGroupName ?? "", cRMspCallerIDSearch_Result.cmpCompanyGroupII ?? "", cRMspCallerIDSearch_Result.cmpCompanyGroupIII ?? "", cRMspCallerIDSearch_Result.cmpCompanyGroupIV ?? "", "", objectParameter, true);
									text9 = "<div class='CallerIdDiv' id='" + cRMspCallerIDSearch_Result.CompanyID + "-" + cRMspCallerIDSearch_Result.CompanyPersonID + "-" + cRMspCallerIDSearch_Result.LastProjectId + "-" + cRMspCallerIDSearch_Result.LastConversationId + "'>";
									text9 += "<div class='CI-I' onclick='OpenCompanyInfo(this);'>";
									text10 += objectParameter.Value.ToString().Replace("\r\n", "<br/>").Replace(" ", "&nbsp;");
									text9 += text10;
									text9 += "</div>";
									text9 += "<div class='CI-A'></div>";
									text9 += "</div>";
									mobCallerIdContentViewModel.CompanyId = cRMspCallerIDSearch_Result.CompanyID?.ToString();
									mobCallerIdContentViewModel.PersonId = cRMspCallerIDSearch_Result.CompanyPersonID?.ToString();
									mobCallerIdContentViewModel.LastProjectId = cRMspCallerIDSearch_Result.LastProjectId?.ToString();
									mobCallerIdContentViewModel.LastConversationId = cRMspCallerIDSearch_Result.LastConversationId?.ToString();
									mobCallerIdContentViewModel.Message = objectParameter.Value.ToString();
								}
								else
								{
									text9 = "<div class='CallerIdDiv'>";
									text10 = text10 + Labels.ResourceManager.GetString("PopUpCallerIdLine", new CultureInfo(num)) + ":&nbsp;" + LineNumber + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + Labels.ResourceManager.GetString("PopUpCallerIdInTime", new CultureInfo(num)) + ":&nbsp;" + DateTime.Now.ToString("hh:mm:ss");
									text10 += "<br/>";
									text10 = text10 + Labels.ResourceManager.GetString("PopUpCallerIdTel", new CultureInfo(num)) + ":&nbsp;<span>" + text14 + "</span>";
									text10 += "<br/>";
									text10 = text10 + Labels.ResourceManager.GetString("PopUpCallerIdCmpName", new CultureInfo(num)) + ":&nbsp;" + Labels.ResourceManager.GetString("PopUpCallerIdNumberNotRegister", new CultureInfo(num));
									text9 = text9 + text10 + "</div>";
									string text20 = "";
									text20 = text20 + Labels.ResourceManager.GetString("PopUpCallerIdInTime", new CultureInfo(num)) + ":&nbsp;" + DateTime.Now.ToString("hh:mm:ss");
									text20 += "<br/>";
									text20 = text20 + Labels.ResourceManager.GetString("PopUpCallerIdTel", new CultureInfo(num)) + ":&nbsp;<span>" + text14 + "</span>";
									text20 += "<br/>";
									text20 = text20 + Labels.ResourceManager.GetString("PopUpCallerIdCmpName", new CultureInfo(num)) + ":&nbsp;" + Labels.ResourceManager.GetString("PopUpCallerIdNumberNotRegister", new CultureInfo(num));
									mobCallerIdContentViewModel.Message = text20.ToString();
								}
							}
							switch (text19)
							{
							case "ring":
								if (cRMspCallerIDSearch_Result != null)
								{
									try
									{
										cRMSpEntities.CRMspInsertCallHistory(CallType, result, text14, cRMspCallerIDSearch_Result.CompanyID, callTime, text18, callDay, value, value2, value3, text18, "", "", text13, cRMspCallerIDSearch_Result.CompanyPersonID, recFileName, data2, appType, result2, trunkCallId, trunkName, text11, text12, null, trunkDestinationCycle, preRecFileName, null);
									}
									catch (Exception ex3)
									{
										ErrorSignal.FromCurrentContext().Raise(ex3);
										message = Messages.msgErrorRunFunction + "(" + ex3.Message + ")";
										data = false;
										status = CallerIdAPIServiceResultStatus.Error;
										break;
									}
								}
								else
								{
									try
									{
										cRMSpEntities.CRMspInsertCallHistory(CallType, result, text14, null, callTime, text18, callDay, value, value2, value3, text18, "", "", text13, null, recFileName, data2, appType, result2, trunkCallId, trunkName, text11, text12, null, trunkDestinationCycle, preRecFileName, null);
									}
									catch (Exception ex4)
									{
										ErrorSignal.FromCurrentContext().Raise(ex4);
										message = Messages.msgErrorRunFunction + "(" + ex4.Message + ")";
										data = false;
										status = CallerIdAPIServiceResultStatus.Error;
										break;
									}
								}
								message = Messages.msgSuccessAction;
								data = true;
								status = CallerIdAPIServiceResultStatus.Success;
								break;
							case "connected":
								if (cRMspCallerIDSearch_Result != null)
								{
									num2 = cRMspCallerIDSearch_Result.CompanyID.GetValueOrDefault();
									num3 = cRMspCallerIDSearch_Result.CompanyPersonID.GetValueOrDefault();
								}
								else if (cRMspCallerIDSelectPopUpSetting_Result.PopUpDeActiveForUnknownNumber.GetValueOrDefault())
								{
									ShowPopup = false;
									text4 = "|0|";
									message = Messages.msgErrorCIPopUpDeActiveForUnknownNumber;
									data = false;
									status = CallerIdAPIServiceResultStatus.Fail;
									break;
								}
								if (cRMspCallerIDSelectPopUpSetting_Result.PopUpDeActive.GetValueOrDefault())
								{
									ShowPopup = false;
									text4 = "|0|";
									message = Messages.msgErrorCIPopUpDeActive;
									data = false;
									status = CallerIdAPIServiceResultStatus.Fail;
									break;
								}
								if (!string.IsNullOrEmpty(text14) && CallType == 2 && text14.Substring(0, 2) == "09")
								{
									cRMSpEntities.CRMspAutoSendSMSFromCallerID(num2, num3, text14, CRMIdeal.Classes.Common.Configuration.AppType, result2, 0);
								}
								try
								{
									cRMSpEntities.CRMspInsertUpdateCallHistoryOnTrunkCdr(CallType, result, text14, (num2 == 0) ? null : new int?(num2), callTime, text18, callDay, value, value2, value3, text18, "", "", text13, (num3 == 0) ? null : new int?(num3), recFileName, data2, appType, result2, trunkCallId, trunkName, text11, text12, null, trunkDestinationCycle, preRecFileName);
								}
								catch (Exception ex5)
								{
									ErrorSignal.FromCurrentContext().Raise(ex5);
									message = Messages.msgErrorRunFunction + "(" + ex5.Message + ")";
									data = false;
									status = CallerIdAPIServiceResultStatus.Error;
									break;
								}
								text = text9;
								if (!string.IsNullOrWhiteSpace(Extention))
								{
									text3 = Extention;
								}
								if (string.IsNullOrEmpty(text3))
								{
									text3 = "";
								}
								message = Messages.msgSuccessAction;
								data = true;
								status = CallerIdAPIServiceResultStatus.Success;
								break;
							case "cdr":
								if (string.IsNullOrEmpty(text13))
								{
									break;
								}
								try
								{
									if (text13 != "0")
									{
										try
										{
											cRMSpEntities.CRMspInsertUpdateCallHistoryOnTrunkCdr(CallType, result, text14, (num2 == 0) ? null : new int?(num2), callTime, text18, callDay, value, value2, value3, text18, "", "", text13, (num3 == 0) ? null : new int?(num3), recFileName, data2, appType, result2, trunkCallId, trunkName, text11, text12, null, trunkDestinationCycle, preRecFileName);
										}
										catch (Exception ex)
										{
											ErrorSignal.FromCurrentContext().Raise(ex);
											message = Messages.msgErrorRunFunction + "(" + ex.Message + ")";
											data = false;
											status = CallerIdAPIServiceResultStatus.Error;
											goto end_IL_0fde;
										}
										message = Messages.msgSuccessAction;
										data = true;
										status = CallerIdAPIServiceResultStatus.Success;
									}
									end_IL_0fde:;
								}
								catch (Exception ex2)
								{
									ErrorSignal.FromCurrentContext().Raise(ex2);
									message = Messages.msgErrorRunFunction + "(" + ex2.Message + ")";
									data = false;
									status = CallerIdAPIServiceResultStatus.Error;
								}
								finally
								{
									cRMSpEntities?.Dispose();
								}
								break;
							}
						}
						end_IL_0113:;
					}
					catch (Exception ex6)
					{
						ErrorSignal.FromCurrentContext().Raise(ex6);
						message = Messages.msgErrorRunFunction + "(" + ex6.Message + ")";
						data = false;
						status = CallerIdAPIServiceResultStatus.Error;
					}
					finally
					{
						cRMSpEntities?.Dispose();
						cRMSpIEntities?.Dispose();
						cRMSpIIIEntities?.Dispose();
					}
				}
			}
		}
		catch (Exception ex7)
		{
			ErrorSignal.FromCurrentContext().Raise(ex7);
			message = Messages.msgErrorRunFunction + "(" + ex7.Message + ")";
			data = false;
			status = CallerIdAPIServiceResultStatus.Error;
		}
		CallerIdAPIServiceResult<bool> result3 = new CallerIdAPIServiceResult<bool>
		{
			Message = message,
			Data = data,
			Status = status
		};
		CRMSpEntities cRMSpEntities2 = new CRMSpEntities();
		try
		{
			if (ShowPopup.GetValueOrDefault())
			{
				int value4 = 0;
				if (cRMspCallerIDSelectPopUpSetting_Result.PopUpJustForcmpReferUser.GetValueOrDefault())
				{
					value4 = 1;
				}
				if (cRMspCallerIDSelectPopUpSetting_Result.PopUpJustForcmpReferUserAndLinked.GetValueOrDefault())
				{
					value4 = 2;
				}
				int result4 = 3;
				if (cRMspCallerIDSearch_Result != null && cRMspCallerIDSearch_Result.cmpReferUserId.HasValue)
				{
					int.TryParse(cRMspCallerIDSearch_Result.cmpReferUserId.ToString(), out result4);
				}
				text4 = "|";
				List<int?> list = Enumerable.ToList<int?>((IEnumerable<int?>)cRMSpEntities2.CRMspCallerIDSelectRejectPopUpUsers(value4, result4, result));
				if (Enumerable.Any<int?>((IEnumerable<int?>)list))
				{
					text4 = Enumerable.Aggregate<int?, string>(Enumerable.Where<int?>((IEnumerable<int?>)list, (Func<int?, bool>)((int? userId) => userId.HasValue)), text4, (Func<string, int?, string>)delegate(string current, int? userId)
					{
						int? num4 = userId;
						return current + num4 + "|";
					});
				}
				if (CallType == 2)
				{
					text2 = text4;
					IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
					hubContext.Clients.All.addNewMessageToPage(text2, text, text3, LineNumber);
					PushNotif.CallerIdNotify(text2, text3, LineNumber, mobCallerIdContentViewModel);
				}
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			cRMSpEntities2?.Dispose();
		}
		return result3;
	}

	[System.Web.Http.HttpPost]
	public bool SendMessageFromMobile(string telNumber = "", string duration = "0", int userId = 0, int? ln = null)
	{
		bool result = false;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int result2 = 1065;
			if (ln.HasValue)
			{
				int.TryParse(ln.ToString(), out result2);
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result3);
			if (CRMIdeal.Classes.Helper.User.SelectUsersById(userId, 0, result2, result3) != null)
			{
				string text = "|";
				string text2 = "0";
				string text3 = "";
				string text4 = "";
				MobCallerIdContentViewModel mobCallerIdContentViewModel = new MobCallerIdContentViewModel();
				if (!string.IsNullOrEmpty(telNumber) && userId != 0)
				{
					CRMspCallerIDSearch_Result cRMspCallerIDSearch_Result = Enumerable.FirstOrDefault<CRMspCallerIDSearch_Result>((IEnumerable<CRMspCallerIDSearch_Result>)cRMSpEntities.CRMspCallerIDSearch(telNumber, result2, result3));
					if (cRMspCallerIDSearch_Result != null)
					{
						ObjectParameter objectParameter = new ObjectParameter("FormulaPopUpResult", "");
						cRMSpEntities.CRMspCallerIDFormulaPopUpResult(text2, DateTime.Now.ToString("hh:mm:ss"), telNumber, cRMspCallerIDSearch_Result.cmpName ?? "", cRMspCallerIDSearch_Result.cmpPrsName ?? "", cRMspCallerIDSearch_Result.cmpName + " " + cRMspCallerIDSearch_Result.cmpPrsName, cRMspCallerIDSearch_Result.LastcnvscmpPerson ?? "", cRMspCallerIDSearch_Result.LastProject ?? "", cRMspCallerIDSearch_Result.LastcnvsRefUser ?? "", cRMspCallerIDSearch_Result.LastcnvsStatus ?? "", cRMspCallerIDSearch_Result.cmpReferUser ?? "", cRMspCallerIDSearch_Result.cmpActivityType ?? "", cRMspCallerIDSearch_Result.cmpCountry ?? "", cRMspCallerIDSearch_Result.cmpProvince ?? "", cRMspCallerIDSearch_Result.cmpCity ?? "", cRMspCallerIDSearch_Result.cmpPresentation ?? "", cRMspCallerIDSearch_Result.cmpCompanyType ?? "", cRMspCallerIDSearch_Result.cmpCompanyGroups ?? "", cRMspCallerIDSearch_Result.cmpSubGroupName ?? "", cRMspCallerIDSearch_Result.cmpCompanyGroupII ?? "", cRMspCallerIDSearch_Result.cmpCompanyGroupIII ?? "", cRMspCallerIDSearch_Result.cmpCompanyGroupIV ?? "", "", objectParameter, true);
						text3 = "<div class='CallerIdDiv OnMobile' id='" + cRMspCallerIDSearch_Result.CompanyID + "-" + cRMspCallerIDSearch_Result.CompanyPersonID + "-" + cRMspCallerIDSearch_Result.LastProjectId + "-" + cRMspCallerIDSearch_Result.LastConversationId + "'>";
						text3 += "<div class='CI-I' onclick='OpenCompanyInfo(this);'>";
						text4 += objectParameter.Value.ToString().Replace("\r\n", "<br/>").Replace(" ", "&nbsp;");
						text3 += text4;
						text3 += "</div>";
						text3 += "<div class='CI-A'></div>";
						text3 += "</div>";
						mobCallerIdContentViewModel.CompanyId = cRMspCallerIDSearch_Result.CompanyID?.ToString();
						mobCallerIdContentViewModel.PersonId = cRMspCallerIDSearch_Result.CompanyPersonID?.ToString();
						mobCallerIdContentViewModel.LastProjectId = cRMspCallerIDSearch_Result.LastProjectId?.ToString();
						mobCallerIdContentViewModel.LastConversationId = cRMspCallerIDSearch_Result.LastConversationId?.ToString();
						mobCallerIdContentViewModel.Message = objectParameter.Value.ToString();
					}
					else
					{
						text3 = "<div class='CallerIdDiv OnMobile'>";
						text4 = text4 + Labels.ResourceManager.GetString("PopUpCallerIdLine", new CultureInfo(result2)) + ":&nbsp;" + text2 + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + Labels.ResourceManager.GetString("", new CultureInfo(result2)) + ":&nbsp;" + DateTime.Now.ToString("hh:mm:ss");
						text4 += "<br/>";
						text4 = text4 + Labels.ResourceManager.GetString("PopUpCallerIdTel", new CultureInfo(result2)) + ":&nbsp;<span>" + telNumber + "</span>";
						text4 += "<br/>";
						text4 = text4 + Labels.ResourceManager.GetString("PopUpCallerIdCmpName", new CultureInfo(result2)) + ":&nbsp;" + Labels.ResourceManager.GetString("PopUpCallerIdNumberNotRegister", new CultureInfo(result2));
						text3 = text3 + text4 + "</div>";
						string text5 = "";
						text5 = text5 + Labels.ResourceManager.GetString("PopUpCallerIdInTime", new CultureInfo(result2)) + ":&nbsp;" + DateTime.Now.ToString("hh:mm:ss");
						text5 += "<br/>";
						text5 = text5 + Labels.ResourceManager.GetString("PopUpCallerIdTel", new CultureInfo(result2)) + ":&nbsp;<span>" + telNumber + "</span>";
						text5 += "<br/>";
						text5 = text5 + Labels.ResourceManager.GetString("PopUpCallerIdCmpName", new CultureInfo(result2)) + ":&nbsp;" + Labels.ResourceManager.GetString("PopUpCallerIdNumberNotRegister", new CultureInfo(result2));
						mobCallerIdContentViewModel.Message = text5.ToString();
					}
					int value = 0;
					CRMspCallerIDSelectPopUpSetting_Result cRMspCallerIDSelectPopUpSetting_Result = Enumerable.FirstOrDefault<CRMspCallerIDSelectPopUpSetting_Result>((IEnumerable<CRMspCallerIDSelectPopUpSetting_Result>)cRMSpEntities.CRMspCallerIDSelectPopUpSetting());
					if (cRMspCallerIDSelectPopUpSetting_Result != null)
					{
						if (cRMspCallerIDSelectPopUpSetting_Result.PopUpJustForcmpReferUser.GetValueOrDefault())
						{
							value = 1;
						}
						if (cRMspCallerIDSelectPopUpSetting_Result.PopUpJustForcmpReferUserAndLinked.GetValueOrDefault())
						{
							value = 2;
						}
					}
					int result4 = userId;
					if (cRMspCallerIDSearch_Result != null)
					{
						int.TryParse(cRMspCallerIDSearch_Result.cmpReferUserId.ToString(), out result4);
					}
					List<int?> list = Enumerable.ToList<int?>((IEnumerable<int?>)cRMSpEntities.CRMspCallerIDSelectRejectPopUpUsers(value, result4, 0));
					if (Enumerable.Any<int?>((IEnumerable<int?>)list))
					{
						text = Enumerable.Aggregate<int?, string>(Enumerable.Where<int?>((IEnumerable<int?>)list, (Func<int?, bool>)((int? userId) => userId.HasValue)), text, (Func<string, int?, string>)delegate(string current, int? userId)
						{
							int? num = userId;
							return current + num + "|";
						});
					}
					IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
					string text6 = text3;
					string text7 = text;
					string text8 = "";
					hubContext.Clients.All.addNewMessageToPage(text7, text6, text8, text2);
					PushNotif.CallerIdNotify(text7, text8, text2, mobCallerIdContentViewModel);
					result = true;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}
}

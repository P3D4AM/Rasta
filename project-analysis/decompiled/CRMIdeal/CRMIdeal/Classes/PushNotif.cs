using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CRM.General.PushNotif;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Classes;

public class PushNotif
{
	public static FirebaseCloudMessaging firebaseCloudMessaging = new FirebaseCloudMessaging();

	public static void NewIntMsgNotify_old()
	{
		CRMSpIEntities cRMSpIEntities = null;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			cRMSpIEntities = new CRMSpIEntities();
			foreach (CRMspSelectUserPushNotifTankWithDeviceInfo_Result item in Enumerable.ToList<CRMspSelectUserPushNotifTankWithDeviceInfo_Result>((IEnumerable<CRMspSelectUserPushNotifTankWithDeviceInfo_Result>)cRMSpIEntities.CRMspSelectUserPushNotifTankWithDeviceInfo(1, Configuration.MobAppProjectName)))
			{
				List<string> list = new List<string>();
				List<string> list2 = new List<string>();
				List<MobAppDevSettingViewModel> list3 = new List<MobAppDevSettingViewModel>();
				if (!string.IsNullOrEmpty(item.MobAppDevSetting))
				{
					list3 = JsonConvert.DeserializeObject<List<MobAppDevSettingViewModel>>(item.MobAppDevSetting);
				}
				List<UserAppDeviceInfoViewModel> list4 = new List<UserAppDeviceInfoViewModel>();
				if (!string.IsNullOrEmpty(item.DeviceInfo))
				{
					list4 = JsonConvert.DeserializeObject<List<UserAppDeviceInfoViewModel>>(item.DeviceInfo);
				}
				foreach (UserAppDeviceInfoViewModel info in list4)
				{
					MobAppDevSettingViewModel mobAppDevSettingViewModel = Enumerable.FirstOrDefault<MobAppDevSettingViewModel>(Enumerable.Where<MobAppDevSettingViewModel>((IEnumerable<MobAppDevSettingViewModel>)list3, (Func<MobAppDevSettingViewModel, bool>)((MobAppDevSettingViewModel e) => e.dType == info.DeviceType)));
					if (mobAppDevSettingViewModel == null)
					{
						continue;
					}
					bool flag = false;
					bool flag2 = false;
					if (info.DeviceType == 1 || info.DeviceType == 3)
					{
						if (mobAppDevSettingViewModel.intMsgNotifOnOpenActive.GetValueOrDefault())
						{
							flag = true;
						}
						if (mobAppDevSettingViewModel.intMsgNotifOnBgActive.GetValueOrDefault() && mobAppDevSettingViewModel.intMsgNotifOnCloseActive.GetValueOrDefault())
						{
							flag2 = true;
							flag = false;
						}
					}
					else if (info.DeviceType == 2)
					{
						if (mobAppDevSettingViewModel.intMsgNotifOnOpenActive.GetValueOrDefault())
						{
							flag = true;
						}
						if (mobAppDevSettingViewModel.intMsgNotifOnBgActive.GetValueOrDefault())
						{
							flag = true;
						}
						if (mobAppDevSettingViewModel.intMsgNotifOnCloseActive.GetValueOrDefault())
						{
							flag2 = true;
							flag = false;
						}
					}
					if (!string.IsNullOrEmpty(info.DeviceId))
					{
						if (flag)
						{
							list.Add(info.DeviceId);
						}
						else if (flag2)
						{
							list2.Add(info.DeviceId);
						}
					}
				}
				if (list.Count > 0 || list2.Count > 0)
				{
					FirebaseCloudMessaging firebaseCloudMessaging = new FirebaseCloudMessaging();
					Dictionary<string, string> dictionary = new Dictionary<string, string>();
					if (!string.IsNullOrEmpty(item.upExtraData))
					{
						dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(item.upExtraData);
					}
					string text = "";
					int result2 = 0;
					if (dictionary.ContainsKey("msgdFromUserId"))
					{
						int.TryParse(dictionary["msgdFromUserId"], out result2);
					}
					if (result2 > 0)
					{
						string userName = User.GetUserName(result2, lCID, result);
						text = string.Format(Messages.MsgNewInternalMsgFrom, userName);
					}
					else
					{
						text = Labels.lblNewIntMsg;
					}
					int num = 0;
					num = User.GetUserLastCId(item.upUserId, 1065, 1065);
					int valueOrDefault = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpIEntities.CRMspIntMsgGetUnReadMessgeCnt(item.upUserId, num)).GetValueOrDefault();
					dictionary.Add("MessageType", "NewIntMsgNotif");
					dictionary.Add("UnReadCnt", valueOrDefault.ToString());
					dictionary.Add("Title", text);
					dictionary.Add("Message", item.upTitle ?? "");
					Exception ex = null;
					if (list.Count > 0)
					{
						firebaseCloudMessaging.SendTokenMessage(list, dictionary, ref ex);
					}
					if (list2.Count > 0)
					{
						firebaseCloudMessaging.SendNewIntMsgNotificationMessage(list2, dictionary, ref ex);
					}
					if (ex != null)
					{
						ErrorSignal.FromCurrentContext().Raise(ex);
					}
				}
			}
			cRMSpIEntities.CRMspDeleteUserPushNotifTankByTypeId(1);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
	}

	public static void NewIntMsgNotify(bool withthread = true)
	{
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
			if (defLangID <= 0)
			{
				defLangID = 1065;
			}
			int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
			if (withthread)
			{
				new Thread((ThreadStart)delegate
				{
					NewIntMsgNotifyWithThread(defLangID, currLangID);
				}).Start();
			}
			else
			{
				NewIntMsgNotifyWithThread(defLangID, currLangID);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	public static void NewIntMsgNotifyWithThread(int defLangID, int currLangID)
	{
		CRMSpIEntities cRMSpIEntities = null;
		try
		{
			cRMSpIEntities = new CRMSpIEntities();
			foreach (CRMspSelectUserPushNotifTankWithDeviceInfo_Result item in Enumerable.ToList<CRMspSelectUserPushNotifTankWithDeviceInfo_Result>((IEnumerable<CRMspSelectUserPushNotifTankWithDeviceInfo_Result>)cRMSpIEntities.CRMspSelectUserPushNotifTankWithDeviceInfo(1, null)))
			{
				List<string> list = new List<string>();
				List<string> list2 = new List<string>();
				List<MobAppDevSettingViewModel> list3 = new List<MobAppDevSettingViewModel>();
				if (!string.IsNullOrEmpty(item.MobAppDevSetting))
				{
					list3 = JsonConvert.DeserializeObject<List<MobAppDevSettingViewModel>>(item.MobAppDevSetting);
				}
				List<UserAppDeviceInfoViewModel> list4 = new List<UserAppDeviceInfoViewModel>();
				if (!string.IsNullOrEmpty(item.DeviceInfo))
				{
					list4 = JsonConvert.DeserializeObject<List<UserAppDeviceInfoViewModel>>(item.DeviceInfo);
				}
				foreach (UserAppDeviceInfoViewModel info in list4)
				{
					MobAppDevSettingViewModel mobAppDevSettingViewModel = Enumerable.FirstOrDefault<MobAppDevSettingViewModel>(Enumerable.Where<MobAppDevSettingViewModel>((IEnumerable<MobAppDevSettingViewModel>)list3, (Func<MobAppDevSettingViewModel, bool>)((MobAppDevSettingViewModel e) => e.dType == info.DeviceType)));
					if (mobAppDevSettingViewModel == null)
					{
						continue;
					}
					bool flag = false;
					bool flag2 = false;
					if (info.DeviceType == 1 || info.DeviceType == 3)
					{
						if (mobAppDevSettingViewModel.intMsgNotifOnOpenActive.GetValueOrDefault())
						{
							flag = true;
						}
						if (mobAppDevSettingViewModel.intMsgNotifOnBgActive.GetValueOrDefault() && mobAppDevSettingViewModel.intMsgNotifOnCloseActive.GetValueOrDefault())
						{
							flag2 = true;
							flag = false;
						}
					}
					else if (info.DeviceType == 2)
					{
						if (mobAppDevSettingViewModel.intMsgNotifOnOpenActive.GetValueOrDefault())
						{
							flag = true;
						}
						if (mobAppDevSettingViewModel.intMsgNotifOnBgActive.GetValueOrDefault())
						{
							flag = true;
						}
						if (mobAppDevSettingViewModel.intMsgNotifOnCloseActive.GetValueOrDefault())
						{
							flag2 = true;
							flag = false;
						}
					}
					if (!string.IsNullOrEmpty(info.DeviceId) && (info.AppName == Configuration.MobAppProjectName || (!info.CrmNotifDeactivInHrm && info.AppName == Configuration.MobHRMAppProjectName)))
					{
						if (flag)
						{
							list.Add(info.DeviceId);
						}
						else if (flag2)
						{
							list2.Add(info.DeviceId);
						}
					}
				}
				if (list.Count > 0 || list2.Count > 0)
				{
					Dictionary<string, string> dictionary = new Dictionary<string, string>();
					if (!string.IsNullOrEmpty(item.upExtraData))
					{
						dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(item.upExtraData);
					}
					string text = "";
					int result = 0;
					if (dictionary.ContainsKey("msgdFromUserId"))
					{
						int.TryParse(dictionary["msgdFromUserId"], out result);
					}
					if (result > 0)
					{
						string userName = User.GetUserName(result, currLangID, defLangID);
						text = string.Format(Messages.MsgNewInternalMsgFrom, userName);
					}
					else
					{
						text = Labels.lblNewIntMsg;
					}
					int num = 0;
					num = User.GetUserLastCId(item.upUserId, 1065, 1065);
					int valueOrDefault = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpIEntities.CRMspIntMsgGetUnReadMessgeCnt(item.upUserId, num)).GetValueOrDefault();
					dictionary.Add("MessageType", "NewIntMsgNotif");
					dictionary.Add("UnReadCnt", valueOrDefault.ToString());
					dictionary.Add("Title", text);
					dictionary.Add("Message", item.upTitle ?? "");
					Exception ex = null;
					if (list.Count > 0)
					{
						firebaseCloudMessaging.SendTokenMessage(list, dictionary, ref ex);
					}
					if (list2.Count > 0)
					{
						firebaseCloudMessaging.SendNewIntMsgNotificationMessage(list2, dictionary, ref ex);
					}
					if (ex != null)
					{
						ErrorSignal.FromCurrentContext().Raise(ex);
					}
				}
			}
			cRMSpIEntities.CRMspDeleteUserPushNotifTankByTypeId(1);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
	}

	public static void NewTicketNotify_old(int companyId, string title, string body, Dictionary<string, string> extraData)
	{
		try
		{
			List<CRMspSelectCompanyAppDeviceInfo_Result> list = Enumerable.ToList<CRMspSelectCompanyAppDeviceInfo_Result>((IEnumerable<CRMspSelectCompanyAppDeviceInfo_Result>)new CRMSpIEntities().CRMspSelectCompanyAppDeviceInfo(companyId));
			List<string> list2 = new List<string>();
			foreach (CRMspSelectCompanyAppDeviceInfo_Result item in list)
			{
				if (!string.IsNullOrEmpty(item.DeviceId))
				{
					list2.Add(item.DeviceId);
				}
			}
			Exception ex = null;
			new FirebaseCloudMessaging().SendTokenNotificationMessage(list2, title, body, extraData, ref ex);
			if (ex != null)
			{
				ErrorSignal.FromCurrentContext().Raise(ex);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	public static void NewTicketNotify(int companyId, string title, string body, Dictionary<string, string> extraData, bool withthread = true)
	{
		try
		{
			if (withthread)
			{
				new Thread((ThreadStart)delegate
				{
					NewTicketNotifyWithThread(companyId, title, body, extraData);
				}).Start();
			}
			else
			{
				NewTicketNotifyWithThread(companyId, title, body, extraData);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	public static void NewTicketNotifyWithThread(int companyId, string title, string body, Dictionary<string, string> extraData)
	{
		try
		{
			List<CRMspSelectCompanyAppDeviceInfo_Result> list = Enumerable.ToList<CRMspSelectCompanyAppDeviceInfo_Result>((IEnumerable<CRMspSelectCompanyAppDeviceInfo_Result>)new CRMSpIEntities().CRMspSelectCompanyAppDeviceInfo(companyId));
			List<string> list2 = new List<string>();
			foreach (CRMspSelectCompanyAppDeviceInfo_Result item in list)
			{
				if (!string.IsNullOrEmpty(item.DeviceId))
				{
					list2.Add(item.DeviceId);
				}
			}
			Exception ex = null;
			firebaseCloudMessaging.SendTokenNotificationMessage(list2, title, body, extraData, ref ex);
			if (ex != null)
			{
				ErrorSignal.FromCurrentContext().Raise(ex);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	public static void CallerIdNotify_old(string name, string exten, string lineNumber, MobCallerIdContentViewModel mobContent)
	{
		exten = ((exten == null || exten == "0") ? "" : exten);
		try
		{
			CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
			List<CRMspSelectCallerIdUsersWithDeviceInfo_Result> list = new List<CRMspSelectCallerIdUsersWithDeviceInfo_Result>();
			List<string> list2 = new List<string>();
			List<string> list3 = new List<string>();
			if (name != "|0|")
			{
				foreach (CRMspSelectCallerIdUsersWithDeviceInfo_Result item in Enumerable.ToList<CRMspSelectCallerIdUsersWithDeviceInfo_Result>((IEnumerable<CRMspSelectCallerIdUsersWithDeviceInfo_Result>)cRMSpIEntities.CRMspSelectCallerIdUsersWithDeviceInfo()))
				{
					bool flag = false;
					if (string.IsNullOrEmpty(exten))
					{
						flag = name.ToLower().IndexOf("|" + item.UserId + "|") < 0;
					}
					else
					{
						string text = item.CallreIdDeActiveLines;
						if (!string.IsNullOrEmpty(text))
						{
							if (text.Substring(0, 1) != ",")
							{
								text = "," + text;
							}
							if (text.Substring(text.Length - 1, 1) != ",")
							{
								text += ",";
							}
						}
						if (!string.IsNullOrEmpty(text) && text.ToLower().IndexOf("," + lineNumber + ",") >= 0)
						{
							flag = false;
						}
						else if (!string.IsNullOrEmpty(item.UserExtensions))
						{
							string[] array = item.UserExtensions.Split(new char[1] { ',' });
							if (array != null)
							{
								for (int i = 0; i < array.Length; i++)
								{
									if (array[i] == exten)
									{
										flag = true;
									}
								}
							}
						}
					}
					if (flag)
					{
						list.Add(item);
					}
				}
			}
			if (list.Count > 0)
			{
				foreach (CRMspSelectCallerIdUsersWithDeviceInfo_Result registration in list)
				{
					List<MobAppDevSettingViewModel> list4 = new List<MobAppDevSettingViewModel>();
					if (!string.IsNullOrEmpty(registration.MobAppDevSetting))
					{
						list4 = JsonConvert.DeserializeObject<List<MobAppDevSettingViewModel>>(registration.MobAppDevSetting);
					}
					MobAppDevSettingViewModel mobAppDevSettingViewModel = Enumerable.FirstOrDefault<MobAppDevSettingViewModel>(Enumerable.Where<MobAppDevSettingViewModel>((IEnumerable<MobAppDevSettingViewModel>)list4, (Func<MobAppDevSettingViewModel, bool>)((MobAppDevSettingViewModel e) => e.dType == registration.DeviceType)));
					if (mobAppDevSettingViewModel == null)
					{
						continue;
					}
					bool flag2 = false;
					bool flag3 = false;
					if (registration.DeviceType == 1 || registration.DeviceType == 3)
					{
						if (mobAppDevSettingViewModel.cIdOnOpenActive.GetValueOrDefault())
						{
							flag2 = true;
						}
						if (mobAppDevSettingViewModel.cIdOnBgActive.GetValueOrDefault() && mobAppDevSettingViewModel.cIdOnCloseActive.GetValueOrDefault())
						{
							flag3 = true;
							flag2 = false;
						}
					}
					else if (registration.DeviceType == 2)
					{
						if (mobAppDevSettingViewModel.cIdOnOpenActive.GetValueOrDefault())
						{
							flag2 = true;
						}
						if (mobAppDevSettingViewModel.cIdOnBgActive.GetValueOrDefault())
						{
							flag2 = true;
						}
						if (mobAppDevSettingViewModel.cIdOnCloseActive.GetValueOrDefault())
						{
							flag3 = true;
							flag2 = false;
						}
					}
					if (!string.IsNullOrEmpty(registration.DeviceId))
					{
						if (flag2)
						{
							list2.Add(registration.DeviceId);
						}
						else if (flag3)
						{
							list3.Add(registration.DeviceId);
						}
					}
				}
			}
			if (list2.Count > 0 || list3.Count > 0)
			{
				FirebaseCloudMessaging firebaseCloudMessaging = new FirebaseCloudMessaging();
				Exception ex = null;
				if (!string.IsNullOrEmpty(mobContent.Message))
				{
					mobContent.Message = mobContent.Message.Replace("<br>", "\r\n").Replace("<br/>", "\r\n").Replace("</br>", "\r\n")
						.Replace("</br/>", "\r\n")
						.Replace("&nbsp;", " ")
						.Replace("<span>", "")
						.Replace("</span>", "")
						.Replace("span>", "")
						.Replace("<span", "")
						.Replace("</span", "");
				}
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("MessageType", "CallerIdPopup");
				dictionary.Add("CompanyId", mobContent.CompanyId);
				dictionary.Add("PersonId", mobContent.PersonId);
				dictionary.Add("LastProjectId", mobContent.LastProjectId);
				dictionary.Add("LastConversationId", mobContent.LastConversationId);
				dictionary.Add("Message", mobContent.Message);
				dictionary.Add("Title", Labels.lblIncomingCall);
				if (list2.Count > 0)
				{
					firebaseCloudMessaging.SendTokenMessage(list2, dictionary, ref ex);
				}
				if (list3.Count > 0)
				{
					firebaseCloudMessaging.SendCallerIdNotificationMessage(list3, dictionary, ref ex);
				}
				if (ex != null)
				{
					Public.InsExceptToElmah(ex);
				}
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
	}

	public static void CallerIdNotify(string name, string exten, string lineNumber, MobCallerIdContentViewModel mobContent, bool withthread = true)
	{
		try
		{
			if (withthread)
			{
				new Thread((ThreadStart)delegate
				{
					CallerIdNotifyWithThread(name, exten, lineNumber, mobContent);
				}).Start();
			}
			else
			{
				CallerIdNotifyWithThread(name, exten, lineNumber, mobContent);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	public static void CallerIdNotifyWithThread(string name, string exten, string lineNumber, MobCallerIdContentViewModel mobContent)
	{
		exten = ((exten == null || exten == "0") ? "" : exten);
		try
		{
			CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
			List<CRMspSelectCallerIdUsersWithDeviceInfo_Result> list = new List<CRMspSelectCallerIdUsersWithDeviceInfo_Result>();
			List<string> list2 = new List<string>();
			List<string> list3 = new List<string>();
			if (name != "|0|")
			{
				foreach (CRMspSelectCallerIdUsersWithDeviceInfo_Result item in Enumerable.ToList<CRMspSelectCallerIdUsersWithDeviceInfo_Result>((IEnumerable<CRMspSelectCallerIdUsersWithDeviceInfo_Result>)cRMSpIEntities.CRMspSelectCallerIdUsersWithDeviceInfo()))
				{
					bool flag = false;
					if (string.IsNullOrEmpty(exten))
					{
						flag = name.ToLower().IndexOf("|" + item.UserId + "|") < 0;
					}
					else
					{
						string text = item.CallreIdDeActiveLines;
						if (!string.IsNullOrEmpty(text))
						{
							if (text.Substring(0, 1) != ",")
							{
								text = "," + text;
							}
							if (text.Substring(text.Length - 1, 1) != ",")
							{
								text += ",";
							}
						}
						if (!string.IsNullOrEmpty(text) && text.ToLower().IndexOf("," + lineNumber + ",") >= 0)
						{
							flag = false;
						}
						else if (!string.IsNullOrEmpty(item.UserExtensions))
						{
							string[] array = item.UserExtensions.Split(new char[1] { ',' });
							if (array != null)
							{
								for (int i = 0; i < array.Length; i++)
								{
									if (array[i] == exten)
									{
										flag = true;
									}
								}
							}
						}
					}
					if (flag)
					{
						list.Add(item);
					}
				}
			}
			if (list.Count > 0)
			{
				foreach (CRMspSelectCallerIdUsersWithDeviceInfo_Result registration in list)
				{
					List<MobAppDevSettingViewModel> list4 = new List<MobAppDevSettingViewModel>();
					if (!string.IsNullOrEmpty(registration.MobAppDevSetting))
					{
						list4 = JsonConvert.DeserializeObject<List<MobAppDevSettingViewModel>>(registration.MobAppDevSetting);
					}
					MobAppDevSettingViewModel mobAppDevSettingViewModel = Enumerable.FirstOrDefault<MobAppDevSettingViewModel>(Enumerable.Where<MobAppDevSettingViewModel>((IEnumerable<MobAppDevSettingViewModel>)list4, (Func<MobAppDevSettingViewModel, bool>)((MobAppDevSettingViewModel e) => e.dType == registration.DeviceType)));
					if (mobAppDevSettingViewModel == null)
					{
						continue;
					}
					bool flag2 = false;
					bool flag3 = false;
					if (registration.DeviceType == 1 || registration.DeviceType == 3)
					{
						if (mobAppDevSettingViewModel.cIdOnOpenActive.GetValueOrDefault())
						{
							flag2 = true;
						}
						if (mobAppDevSettingViewModel.cIdOnBgActive.GetValueOrDefault() && mobAppDevSettingViewModel.cIdOnCloseActive.GetValueOrDefault())
						{
							flag3 = true;
							flag2 = false;
						}
					}
					else if (registration.DeviceType == 2)
					{
						if (mobAppDevSettingViewModel.cIdOnOpenActive.GetValueOrDefault())
						{
							flag2 = true;
						}
						if (mobAppDevSettingViewModel.cIdOnBgActive.GetValueOrDefault())
						{
							flag2 = true;
						}
						if (mobAppDevSettingViewModel.cIdOnCloseActive.GetValueOrDefault())
						{
							flag3 = true;
							flag2 = false;
						}
					}
					if (!string.IsNullOrEmpty(registration.DeviceId))
					{
						if (flag2)
						{
							list2.Add(registration.DeviceId);
						}
						else if (flag3)
						{
							list3.Add(registration.DeviceId);
						}
					}
				}
			}
			if (list2.Count > 0 || list3.Count > 0)
			{
				Exception ex = null;
				if (!string.IsNullOrEmpty(mobContent.Message))
				{
					mobContent.Message = mobContent.Message.Replace("<br>", "\r\n").Replace("<br/>", "\r\n").Replace("</br>", "\r\n")
						.Replace("</br/>", "\r\n")
						.Replace("&nbsp;", " ")
						.Replace("<span>", "")
						.Replace("</span>", "")
						.Replace("span>", "")
						.Replace("<span", "")
						.Replace("</span", "");
				}
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("MessageType", "CallerIdPopup");
				dictionary.Add("CompanyId", mobContent.CompanyId);
				dictionary.Add("PersonId", mobContent.PersonId);
				dictionary.Add("LastProjectId", mobContent.LastProjectId);
				dictionary.Add("LastConversationId", mobContent.LastConversationId);
				dictionary.Add("Message", mobContent.Message);
				dictionary.Add("Title", Labels.lblIncomingCall);
				if (list2.Count > 0)
				{
					firebaseCloudMessaging.SendTokenMessage(list2, dictionary, ref ex);
				}
				if (list3.Count > 0)
				{
					firebaseCloudMessaging.SendCallerIdNotificationMessage(list3, dictionary, ref ex);
				}
				if (ex != null)
				{
					Public.InsExceptToElmah(ex);
				}
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
	}

	public static void NewPayRollUserPaymentNotify_old()
	{
		CRMSpIEntities cRMSpIEntities = null;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			cRMSpIEntities = new CRMSpIEntities();
			foreach (CRMspSelectUserPushNotifTankWithDeviceInfo_Result item in Enumerable.ToList<CRMspSelectUserPushNotifTankWithDeviceInfo_Result>((IEnumerable<CRMspSelectUserPushNotifTankWithDeviceInfo_Result>)cRMSpIEntities.CRMspSelectUserPushNotifTankWithDeviceInfo(2, Configuration.MobHRMAppProjectName)))
			{
				List<string> list = new List<string>();
				List<UserAppDeviceInfoViewModel> list2 = new List<UserAppDeviceInfoViewModel>();
				if (!string.IsNullOrEmpty(item.DeviceInfo))
				{
					list2 = JsonConvert.DeserializeObject<List<UserAppDeviceInfoViewModel>>(item.DeviceInfo);
				}
				foreach (UserAppDeviceInfoViewModel item2 in list2)
				{
					if (!string.IsNullOrEmpty(item2.DeviceId))
					{
						list.Add(item2.DeviceId);
					}
				}
				if (list.Count > 0)
				{
					FirebaseCloudMessaging obj = new FirebaseCloudMessaging();
					Dictionary<string, string> dictionary = new Dictionary<string, string>();
					if (!string.IsNullOrEmpty(item.upExtraData))
					{
						dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(item.upExtraData);
					}
					string labelNotification = Labels.labelNotification;
					string msgNewPaymentSubmittedForPayRoll = Messages.msgNewPaymentSubmittedForPayRoll;
					dictionary.Add("MessageType", "NewPayRollUserPaymentNotify");
					dictionary.Add("Title", labelNotification);
					dictionary.Add("Message", msgNewPaymentSubmittedForPayRoll);
					Exception ex = null;
					obj.SendNewPayRollUserPaymentNotificationMessage(list, dictionary, ref ex);
					if (ex != null)
					{
						ErrorSignal.FromCurrentContext().Raise(ex);
					}
				}
			}
			cRMSpIEntities.CRMspDeleteUserPushNotifTankByTypeId(2);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	public static void NewPayRollUserPaymentNotify(bool withthread = true)
	{
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
			if (defLangID <= 0)
			{
				defLangID = 1065;
			}
			int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
			if (withthread)
			{
				new Thread((ThreadStart)delegate
				{
					NewPayRollUserPaymentNotifyWithThread(defLangID, currLangID);
				}).Start();
			}
			else
			{
				NewPayRollUserPaymentNotifyWithThread(defLangID, currLangID);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	public static void NewPayRollUserPaymentNotifyWithThread(int defLangID, int currLangID)
	{
		CRMSpIEntities cRMSpIEntities = null;
		try
		{
			cRMSpIEntities = new CRMSpIEntities();
			foreach (CRMspSelectUserPushNotifTankWithDeviceInfo_Result item in Enumerable.ToList<CRMspSelectUserPushNotifTankWithDeviceInfo_Result>((IEnumerable<CRMspSelectUserPushNotifTankWithDeviceInfo_Result>)cRMSpIEntities.CRMspSelectUserPushNotifTankWithDeviceInfo(2, Configuration.MobHRMAppProjectName)))
			{
				List<string> list = new List<string>();
				List<UserAppDeviceInfoViewModel> list2 = new List<UserAppDeviceInfoViewModel>();
				if (!string.IsNullOrEmpty(item.DeviceInfo))
				{
					list2 = JsonConvert.DeserializeObject<List<UserAppDeviceInfoViewModel>>(item.DeviceInfo);
				}
				foreach (UserAppDeviceInfoViewModel item2 in list2)
				{
					if (!string.IsNullOrEmpty(item2.DeviceId))
					{
						list.Add(item2.DeviceId);
					}
				}
				if (list.Count > 0)
				{
					Dictionary<string, string> dictionary = new Dictionary<string, string>();
					if (!string.IsNullOrEmpty(item.upExtraData))
					{
						dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(item.upExtraData);
					}
					string labelNotification = Labels.labelNotification;
					string msgNewPaymentSubmittedForPayRoll = Messages.msgNewPaymentSubmittedForPayRoll;
					dictionary.Add("MessageType", "NewPayRollUserPaymentNotify");
					dictionary.Add("Title", labelNotification);
					dictionary.Add("Message", msgNewPaymentSubmittedForPayRoll);
					Exception ex = null;
					firebaseCloudMessaging.SendNewPayRollUserPaymentNotificationMessage(list, dictionary, ref ex);
					if (ex != null)
					{
						ErrorSignal.FromCurrentContext().Raise(ex);
					}
				}
			}
			cRMSpIEntities.CRMspDeleteUserPushNotifTankByTypeId(2);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	public static void NewIntMsgNotifyToCompany_old(int companyId, Dictionary<string, string> extraData)
	{
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentUICulture.LCID;
			List<CRMspSelectCompanyAppDeviceInfo_Result> list = Enumerable.ToList<CRMspSelectCompanyAppDeviceInfo_Result>((IEnumerable<CRMspSelectCompanyAppDeviceInfo_Result>)new CRMSpIEntities().CRMspSelectCompanyAppDeviceInfo(companyId));
			List<string> list2 = new List<string>();
			foreach (CRMspSelectCompanyAppDeviceInfo_Result item in list)
			{
				if (!string.IsNullOrEmpty(item.DeviceId))
				{
					list2.Add(item.DeviceId);
				}
			}
			Exception ex = null;
			new FirebaseCloudMessaging().SendNewIntMsgNotificationMessage(list2, extraData, ref ex);
			if (ex != null)
			{
				ErrorSignal.FromCurrentContext().Raise(ex);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	public static void NewIntMsgNotifyToCompany(int companyId, Dictionary<string, string> extraData, bool withthread = true)
	{
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLang);
			if (defLang <= 0)
			{
				defLang = 1065;
			}
			int currLangID = Thread.CurrentThread.CurrentUICulture.LCID;
			if (withthread)
			{
				new Thread((ThreadStart)delegate
				{
					NewIntMsgNotifyToCompanyWithThread(companyId, extraData, defLang, currLangID);
				}).Start();
			}
			else
			{
				NewIntMsgNotifyToCompanyWithThread(companyId, extraData, defLang, currLangID);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	public static void NewIntMsgNotifyToCompanyWithThread(int companyId, Dictionary<string, string> extraData, int defLang, int currLangID)
	{
		try
		{
			List<CRMspSelectCompanyAppDeviceInfo_Result> list = Enumerable.ToList<CRMspSelectCompanyAppDeviceInfo_Result>((IEnumerable<CRMspSelectCompanyAppDeviceInfo_Result>)new CRMSpIEntities().CRMspSelectCompanyAppDeviceInfo(companyId));
			List<string> list2 = new List<string>();
			foreach (CRMspSelectCompanyAppDeviceInfo_Result item in list)
			{
				if (!string.IsNullOrEmpty(item.DeviceId))
				{
					list2.Add(item.DeviceId);
				}
			}
			Exception ex = null;
			firebaseCloudMessaging.SendNewIntMsgNotificationMessage(list2, extraData, ref ex);
			if (ex != null)
			{
				ErrorSignal.FromCurrentContext().Raise(ex);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	public static void NewIntMsgNotifyToCompanyByTank_old()
	{
		CRMSpIIEntities cRMSpIIEntities = null;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			cRMSpIIEntities = new CRMSpIIEntities();
			foreach (CRMspSelectCompanyPushNotifTank_Result item in Enumerable.ToList<CRMspSelectCompanyPushNotifTank_Result>((IEnumerable<CRMspSelectCompanyPushNotifTank_Result>)cRMSpIIEntities.CRMspSelectCompanyPushNotifTank(1)))
			{
				List<string> list = new List<string>();
				List<CRMspSelectCompanyAppDeviceInfo_Result> list2 = new List<CRMspSelectCompanyAppDeviceInfo_Result>();
				if (!string.IsNullOrEmpty(item.cpExtraData))
				{
					list2 = JsonConvert.DeserializeObject<List<CRMspSelectCompanyAppDeviceInfo_Result>>(item.cpExtraData);
				}
				foreach (CRMspSelectCompanyAppDeviceInfo_Result item2 in list2)
				{
					list.Add(item2.DeviceId);
				}
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("MessageType", "InternalMsg");
				dictionary.Add("Title", item.cpTitle);
				dictionary.Add("Message", item.cpBody ?? "");
				if (list.Count > 0)
				{
					Exception ex = null;
					new FirebaseCloudMessaging().SendNewIntMsgNotificationMessage(list, dictionary, ref ex);
					if (ex != null)
					{
						ErrorSignal.FromCurrentContext().Raise(ex);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		cRMSpIIEntities.CRMspDeleteCompnayPushNotifTankByTypeId(1);
	}

	public static void NewIntMsgNotifyToCompanyByTank(bool withthread = true)
	{
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
			if (defLangID <= 0)
			{
				defLangID = 1065;
			}
			int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
			if (withthread)
			{
				new Thread((ThreadStart)delegate
				{
					NewIntMsgNotifyToCompanyByTankWithThread(defLangID, currLangID);
				}).Start();
			}
			else
			{
				NewIntMsgNotifyToCompanyByTankWithThread(defLangID, currLangID);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	public static void NewIntMsgNotifyToCompanyByTankWithThread(int defLangID, int currLangID)
	{
		CRMSpIIEntities cRMSpIIEntities = null;
		string text = "";
		try
		{
			cRMSpIIEntities = new CRMSpIIEntities();
			foreach (CRMspSelectCompanyPushNotifTank_Result item in Enumerable.ToList<CRMspSelectCompanyPushNotifTank_Result>((IEnumerable<CRMspSelectCompanyPushNotifTank_Result>)cRMSpIIEntities.CRMspSelectCompanyPushNotifTank(1)))
			{
				List<string> list = new List<string>();
				List<CRMspSelectCompanyAppDeviceInfo_Result> list2 = new List<CRMspSelectCompanyAppDeviceInfo_Result>();
				if (!string.IsNullOrEmpty(item.cpExtraData))
				{
					list2 = JsonConvert.DeserializeObject<List<CRMspSelectCompanyAppDeviceInfo_Result>>(item.cpExtraData);
				}
				foreach (CRMspSelectCompanyAppDeviceInfo_Result item2 in list2)
				{
					list.Add(item2.DeviceId);
				}
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("MessageType", "InternalMsg");
				dictionary.Add("Title", item.cpTitle);
				dictionary.Add("Message", item.cpBody ?? "");
				if (list.Count > 0)
				{
					Exception ex = null;
					firebaseCloudMessaging.SendNewIntMsgNotificationMessage(list, dictionary, ref ex);
					if (ex != null)
					{
						ErrorSignal.FromCurrentContext().Raise(ex);
					}
					else
					{
						text = ((!string.IsNullOrEmpty(text)) ? (text + "," + item.CompnayPushNotifTankId) : item.CompnayPushNotifTankId.ToString());
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		if (!string.IsNullOrEmpty(text))
		{
			cRMSpIIEntities.CRMspDeleteCompnayPushNotifTankByIds(text);
		}
	}
}

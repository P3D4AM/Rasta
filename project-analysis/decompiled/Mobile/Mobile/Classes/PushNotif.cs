using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CRM.General.PushNotif;
using CRM.Resources;
using Elmah;
using Mobile.Cache.Setting;
using Mobile.Classes.Helper;
using Mobile.Models;
using Newtonsoft.Json;

namespace Mobile.Classes;

public class PushNotif
{
	public static FirebaseCloudMessaging firebaseCloudMessaging = new FirebaseCloudMessaging();

	public static void NewIntMsgNotify_old(int? cId = null)
	{
		CRMEntities cRMEntities = null;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			cRMEntities = new CRMEntities();
			new CRMSpEntities();
			foreach (MobspSelectUserPushNotifTankWithDeviceInfo_Result item in Enumerable.ToList<MobspSelectUserPushNotifTankWithDeviceInfo_Result>((IEnumerable<MobspSelectUserPushNotifTankWithDeviceInfo_Result>)cRMEntities.MobspSelectUserPushNotifTankWithDeviceInfo(1, Configuration.MobAppProjectName)))
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
					int.TryParse(dictionary["msgdFromUserId"], out var result2);
					if (result2 > 0)
					{
						string userName = User.GetUserName(result2, lCID, result);
						text = string.Format(Messages.MsgNewInternalMsgFrom, userName);
					}
					else
					{
						text = Labels.lblNewIntMsg;
					}
					int valueOrDefault = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspIntMsgGetUnReadMessgeCnt(item.upUserId, cId)).GetValueOrDefault();
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
			cRMEntities.MobspDeleteUserPushNotifTankByTypeId(1);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
	}

	public static void NewIntMsgNotify(bool withthread = true, int? cId = null)
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
					NewIntMsgNotifyWithThread(defLangID, currLangID, cId);
				}).Start();
			}
			else
			{
				NewIntMsgNotifyWithThread(defLangID, currLangID, cId);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	public static void NewIntMsgNotifyWithThread(int defLangID, int currLangID, int? cId = null)
	{
		CRMEntities cRMEntities = null;
		try
		{
			cRMEntities = new CRMEntities();
			new CRMSpEntities();
			foreach (MobspSelectUserPushNotifTankWithDeviceInfo_Result item in Enumerable.ToList<MobspSelectUserPushNotifTankWithDeviceInfo_Result>((IEnumerable<MobspSelectUserPushNotifTankWithDeviceInfo_Result>)cRMEntities.MobspSelectUserPushNotifTankWithDeviceInfo(1, Configuration.MobAppProjectName)))
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
					if (!string.IsNullOrEmpty(info.DeviceId) && (info.AppName == Configuration.MobAppProjectName || !info.CrmNotifDeactivInHrm))
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
					int.TryParse(dictionary["msgdFromUserId"], out var result);
					if (result > 0)
					{
						string userName = User.GetUserName(result, currLangID, defLangID);
						text = string.Format(Messages.MsgNewInternalMsgFrom, userName);
					}
					else
					{
						text = Labels.lblNewIntMsg;
					}
					int valueOrDefault = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspIntMsgGetUnReadMessgeCnt(item.upUserId, cId)).GetValueOrDefault();
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
			cRMEntities.MobspDeleteUserPushNotifTankByTypeId(1);
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
			List<MobspSelectCompanyAppDeviceInfo_Result> list = Enumerable.ToList<MobspSelectCompanyAppDeviceInfo_Result>((IEnumerable<MobspSelectCompanyAppDeviceInfo_Result>)new CRMEntities().MobspSelectCompanyAppDeviceInfo(companyId));
			List<string> list2 = new List<string>();
			foreach (MobspSelectCompanyAppDeviceInfo_Result item in list)
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
			List<MobspSelectCompanyAppDeviceInfo_Result> list = Enumerable.ToList<MobspSelectCompanyAppDeviceInfo_Result>((IEnumerable<MobspSelectCompanyAppDeviceInfo_Result>)new CRMEntities().MobspSelectCompanyAppDeviceInfo(companyId));
			List<string> list2 = new List<string>();
			foreach (MobspSelectCompanyAppDeviceInfo_Result item in list)
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

	public static void NewIntMsgNotifyToCompany_old(int companyId, Dictionary<string, string> extraData)
	{
		try
		{
			List<MobspSelectCompanyAppDeviceInfo_Result> list = Enumerable.ToList<MobspSelectCompanyAppDeviceInfo_Result>((IEnumerable<MobspSelectCompanyAppDeviceInfo_Result>)new CRMEntities().MobspSelectCompanyAppDeviceInfo(companyId));
			List<string> list2 = new List<string>();
			foreach (MobspSelectCompanyAppDeviceInfo_Result item in list)
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
			if (withthread)
			{
				new Thread((ThreadStart)delegate
				{
					NewIntMsgNotifyToCompanyWithThread(companyId, extraData);
				}).Start();
			}
			else
			{
				NewIntMsgNotifyToCompanyWithThread(companyId, extraData);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	public static void NewIntMsgNotifyToCompanyWithThread(int companyId, Dictionary<string, string> extraData)
	{
		try
		{
			List<MobspSelectCompanyAppDeviceInfo_Result> list = Enumerable.ToList<MobspSelectCompanyAppDeviceInfo_Result>((IEnumerable<MobspSelectCompanyAppDeviceInfo_Result>)new CRMEntities().MobspSelectCompanyAppDeviceInfo(companyId));
			List<string> list2 = new List<string>();
			foreach (MobspSelectCompanyAppDeviceInfo_Result item in list)
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
}

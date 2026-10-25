using System;
using System.Collections.Generic;
using System.Linq;
using CRM.General.PushNotif;
using CRMIdealApi.ApiModels;
using CRMIdealApi.Classes.Helper;
using CRMIdealApi.Resources;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdealApi.Classes;

public class PushNotif
{
	public static void NewIntMsgNotify(int currLangId, int defLangId)
	{
		CRMEntities cRMEntities = null;
		try
		{
			cRMEntities = new CRMEntities();
			List<ApispSelectUserPushNotifTankWithDeviceInfo_Result> list = Enumerable.ToList<ApispSelectUserPushNotifTankWithDeviceInfo_Result>((IEnumerable<ApispSelectUserPushNotifTankWithDeviceInfo_Result>)cRMEntities.ApispSelectUserPushNotifTankWithDeviceInfo(1, null));
			foreach (ApispSelectUserPushNotifTankWithDeviceInfo_Result item in list)
			{
				List<string> list2 = new List<string>();
				List<string> list3 = new List<string>();
				List<MobAppDevSettingViewModel> list4 = new List<MobAppDevSettingViewModel>();
				if (!string.IsNullOrEmpty(item.MobAppDevSetting))
				{
					list4 = JsonConvert.DeserializeObject<List<MobAppDevSettingViewModel>>(item.MobAppDevSetting);
				}
				List<UserAppDeviceInfoViewModel> list5 = new List<UserAppDeviceInfoViewModel>();
				if (!string.IsNullOrEmpty(item.DeviceInfo))
				{
					list5 = JsonConvert.DeserializeObject<List<UserAppDeviceInfoViewModel>>(item.DeviceInfo);
				}
				foreach (UserAppDeviceInfoViewModel info in list5)
				{
					MobAppDevSettingViewModel mobAppDevSettingViewModel = Enumerable.FirstOrDefault<MobAppDevSettingViewModel>(Enumerable.Where<MobAppDevSettingViewModel>((IEnumerable<MobAppDevSettingViewModel>)list4, (Func<MobAppDevSettingViewModel, bool>)((MobAppDevSettingViewModel e) => e.dType == info.DeviceType)));
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
							list2.Add(info.DeviceId);
						}
						else if (flag2)
						{
							list3.Add(info.DeviceId);
						}
					}
				}
				if (list2.Count > 0 || list3.Count > 0)
				{
					FirebaseCloudMessaging firebaseCloudMessaging = new FirebaseCloudMessaging();
					Dictionary<string, string> dictionary = new Dictionary<string, string>();
					if (!string.IsNullOrEmpty(item.upExtraData))
					{
						dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(item.upExtraData);
					}
					string text = "";
					int.TryParse(dictionary["msgdFromUserId"], out var result);
					if (result > 0)
					{
						string userName = User.GetUserName(result, currLangId, defLangId);
						text = string.Format(Messages.MsgNewInternalMsgFrom, userName);
					}
					else
					{
						text = Labels.NewIntMsg;
					}
					int valueOrDefault = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispIntMsgGetUnReadMessgeCnt(item.upUserId)).GetValueOrDefault();
					dictionary.Add("MessageType", "NewIntMsgNotif");
					dictionary.Add("UnReadCnt", valueOrDefault.ToString());
					dictionary.Add("Title", text);
					dictionary.Add("Message", item.upTitle ?? "");
					Exception ex = null;
					if (list2.Count > 0)
					{
						firebaseCloudMessaging.SendTokenMessage(list2, dictionary, ref ex);
					}
					if (list3.Count > 0)
					{
						firebaseCloudMessaging.SendNewIntMsgNotificationMessage(list3, dictionary, ref ex);
					}
					if (ex != null)
					{
						ErrorSignal.FromCurrentContext().Raise(ex);
					}
				}
			}
			cRMEntities.ApispDeleteUserPushNotifTankByTypeId(1);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
	}
}

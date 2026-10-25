using System;
using System.Collections.Generic;
using System.Linq;
using CRM.General.Cache;
using Elmah;
using Mobile.Classes;
using Mobile.Models;

namespace Mobile.Cache.Setting;

public static class SmsSeting
{
	private static readonly string MainCacheName = Configuration.CacheDefaultName + Configuration.CacheUniqueName + "-Mob-Setting-SmsSeting";

	private static readonly int DefaultTimeInMinutes = Configuration.CacheDefaultTimeInMinutes;

	public static SmsSettingInfoViewModel Get()
	{
		SmsSettingInfoViewModel value = null;
		try
		{
			if (!CacheManager.Get<SmsSettingInfoViewModel>(MainCacheName, out value))
			{
				CRMEntities cRMEntities = new CRMEntities();
				MobspSelectSmsSetting_Result mobspSelectSmsSetting_Result = Enumerable.FirstOrDefault<MobspSelectSmsSetting_Result>((IEnumerable<MobspSelectSmsSetting_Result>)cRMEntities.MobspSelectSmsSetting());
				cRMEntities.Dispose();
				if (mobspSelectSmsSetting_Result != null)
				{
					value = new SmsSettingInfoViewModel
					{
						SmsReceiveIsActive = (mobspSelectSmsSetting_Result.ReceiveIsActive.HasValue && Convert.ToBoolean(mobspSelectSmsSetting_Result.ReceiveIsActive)),
						SmsSendIsActive = (mobspSelectSmsSetting_Result.SendIsActive.HasValue && Convert.ToBoolean(mobspSelectSmsSetting_Result.SendIsActive)),
						SmsWsDomainNamed = mobspSelectSmsSetting_Result.DomainName,
						SmsWsEnCost = (mobspSelectSmsSetting_Result.EnCost.HasValue ? ((int)mobspSelectSmsSetting_Result.EnCost.Value).ToString() : ""),
						SmsWsFaCost = (mobspSelectSmsSetting_Result.FaCost.HasValue ? ((int)mobspSelectSmsSetting_Result.FaCost.Value).ToString() : ""),
						SmsWsFromNumber = mobspSelectSmsSetting_Result.Number,
						SmsWsUserName = mobspSelectSmsSetting_Result.UserName,
						SmsWsPassword = mobspSelectSmsSetting_Result.Password,
						CmpPattern = mobspSelectSmsSetting_Result.CmpPattern,
						CmpTPattern = mobspSelectSmsSetting_Result.CmpTPattern,
						PrsFNPattern = mobspSelectSmsSetting_Result.PrsFNPattern,
						PrsJobPattern = mobspSelectSmsSetting_Result.PrsJobPattern,
						PrsLNPattern = mobspSelectSmsSetting_Result.PrsLNPattern,
						PrsTPattern = mobspSelectSmsSetting_Result.PrsTPattern,
						LastCreditAmount = mobspSelectSmsSetting_Result.LastCreditAmount,
						SmsProviderId = mobspSelectSmsSetting_Result.ProviderId.GetValueOrDefault(),
						ActiveSendBirthCongratulate = mobspSelectSmsSetting_Result.ActiveSendBirthCongratulate,
						SendBirthCongratulateText = mobspSelectSmsSetting_Result.SendBirthCongratulateText,
						SendBirthCongratulateWeb = mobspSelectSmsSetting_Result.SendBirthCongratulateWeb,
						SendBirthCongratulateGSM = mobspSelectSmsSetting_Result.SendBirthCongratulateGSM,
						ActiveSendMarriageCongratulate = mobspSelectSmsSetting_Result.ActiveSendMarriageCongratulate,
						SendMarriageCongratulateText = mobspSelectSmsSetting_Result.SendMarriageCongratulateText,
						SendMarriageCongratulateWeb = mobspSelectSmsSetting_Result.SendMarriageCongratulateWeb,
						SendMarriageCongratulateGSM = mobspSelectSmsSetting_Result.SendMarriageCongratulateGSM,
						ActiveSendSMSAfterReceive = mobspSelectSmsSetting_Result.ActiveSendSMSAfterReceive,
						SendSMSAfterReceiveText = mobspSelectSmsSetting_Result.SendSMSAfterReceiveText,
						SendSMSAfterReceiveWeb = mobspSelectSmsSetting_Result.SendSMSAfterReceiveWeb,
						SendSMSAfterReceiveGSM = mobspSelectSmsSetting_Result.SendSMSAfterReceiveGSM,
						SendStartTime = mobspSelectSmsSetting_Result.SendStartTime,
						SendEndTime = mobspSelectSmsSetting_Result.SendEndTime,
						SendStartDate = mobspSelectSmsSetting_Result.SendStartDate,
						SendEndDate = mobspSelectSmsSetting_Result.SendEndDate,
						SendStartDatePersian = mobspSelectSmsSetting_Result.SendStartDatePersian,
						SendEndDatePersian = mobspSelectSmsSetting_Result.SendEndDatePersian,
						SendBirthCongratulateStartTime = mobspSelectSmsSetting_Result.SendBirthCongratulateStartTime,
						SendBirthCongratulateSMSNumber = mobspSelectSmsSetting_Result.SendBirthCongratulateSMSNumber,
						SendMarriageCongratulateStartTime = mobspSelectSmsSetting_Result.SendMarriageCongratulateStartTime,
						SendMarriageCongratulateSMSNumber = mobspSelectSmsSetting_Result.SendMarriageCongratulateSMSNumber,
						TokenUserName = mobspSelectSmsSetting_Result.TokenUserName,
						SmsCustomer = mobspSelectSmsSetting_Result.SmsCustomer,
						DecryptedPassword = false,
						ProviderUrl = mobspSelectSmsSetting_Result.ProviderUrl
					};
					CacheManager.Add(value, MainCacheName, DefaultTimeInMinutes);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return value;
	}

	public static bool Clear()
	{
		try
		{
			CacheManager.Clear(MainCacheName);
			return true;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return false;
	}

	public static bool Update()
	{
		try
		{
			CRMEntities cRMEntities = new CRMEntities();
			MobspSelectSmsSetting_Result mobspSelectSmsSetting_Result = Enumerable.FirstOrDefault<MobspSelectSmsSetting_Result>((IEnumerable<MobspSelectSmsSetting_Result>)cRMEntities.MobspSelectSmsSetting());
			cRMEntities.Dispose();
			if (mobspSelectSmsSetting_Result != null)
			{
				SmsSettingInfoViewModel o = new SmsSettingInfoViewModel
				{
					SmsReceiveIsActive = (mobspSelectSmsSetting_Result.ReceiveIsActive.HasValue && Convert.ToBoolean(mobspSelectSmsSetting_Result.ReceiveIsActive)),
					SmsSendIsActive = (mobspSelectSmsSetting_Result.SendIsActive.HasValue && Convert.ToBoolean(mobspSelectSmsSetting_Result.SendIsActive)),
					SmsWsDomainNamed = mobspSelectSmsSetting_Result.DomainName,
					SmsWsEnCost = (mobspSelectSmsSetting_Result.EnCost.HasValue ? ((int)mobspSelectSmsSetting_Result.EnCost.Value).ToString() : ""),
					SmsWsFaCost = (mobspSelectSmsSetting_Result.FaCost.HasValue ? ((int)mobspSelectSmsSetting_Result.FaCost.Value).ToString() : ""),
					SmsWsFromNumber = mobspSelectSmsSetting_Result.Number,
					SmsWsUserName = mobspSelectSmsSetting_Result.UserName,
					SmsWsPassword = mobspSelectSmsSetting_Result.Password,
					CmpPattern = mobspSelectSmsSetting_Result.CmpPattern,
					CmpTPattern = mobspSelectSmsSetting_Result.CmpTPattern,
					PrsFNPattern = mobspSelectSmsSetting_Result.PrsFNPattern,
					PrsJobPattern = mobspSelectSmsSetting_Result.PrsJobPattern,
					PrsLNPattern = mobspSelectSmsSetting_Result.PrsLNPattern,
					PrsTPattern = mobspSelectSmsSetting_Result.PrsTPattern,
					LastCreditAmount = mobspSelectSmsSetting_Result.LastCreditAmount,
					SmsProviderId = mobspSelectSmsSetting_Result.ProviderId.GetValueOrDefault(),
					ActiveSendBirthCongratulate = mobspSelectSmsSetting_Result.ActiveSendBirthCongratulate,
					SendBirthCongratulateText = mobspSelectSmsSetting_Result.SendBirthCongratulateText,
					SendBirthCongratulateWeb = mobspSelectSmsSetting_Result.SendBirthCongratulateWeb,
					SendBirthCongratulateGSM = mobspSelectSmsSetting_Result.SendBirthCongratulateGSM,
					ActiveSendMarriageCongratulate = mobspSelectSmsSetting_Result.ActiveSendMarriageCongratulate,
					SendMarriageCongratulateText = mobspSelectSmsSetting_Result.SendMarriageCongratulateText,
					SendMarriageCongratulateWeb = mobspSelectSmsSetting_Result.SendMarriageCongratulateWeb,
					SendMarriageCongratulateGSM = mobspSelectSmsSetting_Result.SendMarriageCongratulateGSM,
					ActiveSendSMSAfterReceive = mobspSelectSmsSetting_Result.ActiveSendSMSAfterReceive,
					SendSMSAfterReceiveText = mobspSelectSmsSetting_Result.SendSMSAfterReceiveText,
					SendSMSAfterReceiveWeb = mobspSelectSmsSetting_Result.SendSMSAfterReceiveWeb,
					SendSMSAfterReceiveGSM = mobspSelectSmsSetting_Result.SendSMSAfterReceiveGSM,
					SendStartTime = mobspSelectSmsSetting_Result.SendStartTime,
					SendEndTime = mobspSelectSmsSetting_Result.SendEndTime,
					SendStartDate = mobspSelectSmsSetting_Result.SendStartDate,
					SendEndDate = mobspSelectSmsSetting_Result.SendEndDate,
					SendStartDatePersian = mobspSelectSmsSetting_Result.SendStartDatePersian,
					SendEndDatePersian = mobspSelectSmsSetting_Result.SendEndDatePersian,
					SendBirthCongratulateStartTime = mobspSelectSmsSetting_Result.SendBirthCongratulateStartTime,
					SendBirthCongratulateSMSNumber = mobspSelectSmsSetting_Result.SendBirthCongratulateSMSNumber,
					SendMarriageCongratulateStartTime = mobspSelectSmsSetting_Result.SendMarriageCongratulateStartTime,
					SendMarriageCongratulateSMSNumber = mobspSelectSmsSetting_Result.SendMarriageCongratulateSMSNumber,
					TokenUserName = mobspSelectSmsSetting_Result.TokenUserName,
					SmsCustomer = mobspSelectSmsSetting_Result.SmsCustomer
				};
				CacheManager.Clear(MainCacheName);
				CacheManager.Add(o, MainCacheName, DefaultTimeInMinutes);
				return true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return false;
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using CRM.General.Cache;
using CRM.Models;
using CRMIdeal.Classes.Common;
using Elmah;

namespace CRMIdeal.Cache.Setting;

public static class SmsSeting
{
	private static readonly string MainCacheName = Configuration.CacheDefaultName + Configuration.CacheUniqueName + "-Setting-SmsSeting";

	private static readonly int DefaultTimeInMinutes = Configuration.CacheDefaultTimeInMinutes;

	public static SmsSettingInfoViewModel Get()
	{
		SmsSettingInfoViewModel value = null;
		try
		{
			if (!CacheManager.Get<SmsSettingInfoViewModel>(MainCacheName, out value))
			{
				CRMSpEntities cRMSpEntities = new CRMSpEntities();
				SmsspSelectSmsSetting_Result smsspSelectSmsSetting_Result = Enumerable.FirstOrDefault<SmsspSelectSmsSetting_Result>((IEnumerable<SmsspSelectSmsSetting_Result>)cRMSpEntities.SmsspSelectSmsSetting());
				cRMSpEntities.Dispose();
				if (smsspSelectSmsSetting_Result != null)
				{
					value = new SmsSettingInfoViewModel
					{
						SmsReceiveIsActive = (smsspSelectSmsSetting_Result.ReceiveIsActive.HasValue && Convert.ToBoolean(smsspSelectSmsSetting_Result.ReceiveIsActive)),
						SmsSendIsActive = (smsspSelectSmsSetting_Result.SendIsActive.HasValue && Convert.ToBoolean(smsspSelectSmsSetting_Result.SendIsActive)),
						SmsWsDomainNamed = smsspSelectSmsSetting_Result.DomainName,
						SmsWsEnCost = (smsspSelectSmsSetting_Result.EnCost.HasValue ? ((int)smsspSelectSmsSetting_Result.EnCost.Value).ToString() : ""),
						SmsWsFaCost = (smsspSelectSmsSetting_Result.FaCost.HasValue ? ((int)smsspSelectSmsSetting_Result.FaCost.Value).ToString() : ""),
						SmsWsFromNumber = smsspSelectSmsSetting_Result.Number,
						SmsWsUserName = smsspSelectSmsSetting_Result.UserName,
						SmsWsPassword = smsspSelectSmsSetting_Result.Password,
						CmpPattern = smsspSelectSmsSetting_Result.CmpPattern,
						CmpTPattern = smsspSelectSmsSetting_Result.CmpTPattern,
						PrsFNPattern = smsspSelectSmsSetting_Result.PrsFNPattern,
						PrsJobPattern = smsspSelectSmsSetting_Result.PrsJobPattern,
						PrsLNPattern = smsspSelectSmsSetting_Result.PrsLNPattern,
						PrsTPattern = smsspSelectSmsSetting_Result.PrsTPattern,
						LastCreditAmount = smsspSelectSmsSetting_Result.LastCreditAmount,
						SmsProviderId = smsspSelectSmsSetting_Result.ProviderId.GetValueOrDefault(),
						ActiveSendBirthCongratulate = smsspSelectSmsSetting_Result.ActiveSendBirthCongratulate,
						SendBirthCongratulateText = smsspSelectSmsSetting_Result.SendBirthCongratulateText,
						SendBirthCongratulateWeb = smsspSelectSmsSetting_Result.SendBirthCongratulateWeb,
						SendBirthCongratulateGSM = smsspSelectSmsSetting_Result.SendBirthCongratulateGSM,
						ActiveSendMarriageCongratulate = smsspSelectSmsSetting_Result.ActiveSendMarriageCongratulate,
						SendMarriageCongratulateText = smsspSelectSmsSetting_Result.SendMarriageCongratulateText,
						SendMarriageCongratulateWeb = smsspSelectSmsSetting_Result.SendMarriageCongratulateWeb,
						SendMarriageCongratulateGSM = smsspSelectSmsSetting_Result.SendMarriageCongratulateGSM,
						ActiveSendSMSAfterReceive = smsspSelectSmsSetting_Result.ActiveSendSMSAfterReceive,
						SendSMSAfterReceiveText = smsspSelectSmsSetting_Result.SendSMSAfterReceiveText,
						SendSMSAfterReceiveWeb = smsspSelectSmsSetting_Result.SendSMSAfterReceiveWeb,
						SendSMSAfterReceiveGSM = smsspSelectSmsSetting_Result.SendSMSAfterReceiveGSM,
						SendStartTime = smsspSelectSmsSetting_Result.SendStartTime,
						SendEndTime = smsspSelectSmsSetting_Result.SendEndTime,
						SendStartDate = smsspSelectSmsSetting_Result.SendStartDate,
						SendEndDate = smsspSelectSmsSetting_Result.SendEndDate,
						SendStartDatePersian = smsspSelectSmsSetting_Result.SendStartDatePersian,
						SendEndDatePersian = smsspSelectSmsSetting_Result.SendEndDatePersian,
						SendBirthCongratulateStartTime = smsspSelectSmsSetting_Result.SendBirthCongratulateStartTime,
						SendBirthCongratulateSMSNumber = smsspSelectSmsSetting_Result.SendBirthCongratulateSMSNumber,
						SendMarriageCongratulateStartTime = smsspSelectSmsSetting_Result.SendMarriageCongratulateStartTime,
						SendMarriageCongratulateSMSNumber = smsspSelectSmsSetting_Result.SendMarriageCongratulateSMSNumber,
						TokenUserName = smsspSelectSmsSetting_Result.TokenUserName,
						SmsCustomer = smsspSelectSmsSetting_Result.SmsCustomer,
						LastCreditCount = smsspSelectSmsSetting_Result.LastCreditCount,
						DecryptedPassword = false,
						ProviderUrl = smsspSelectSmsSetting_Result.ProviderUrl,
						DeActiveJobSmsCredit = smsspSelectSmsSetting_Result.DeActiveJobSmsCredit.GetValueOrDefault()
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
			CRMSpEntities cRMSpEntities = new CRMSpEntities();
			SmsspSelectSmsSetting_Result smsspSelectSmsSetting_Result = Enumerable.FirstOrDefault<SmsspSelectSmsSetting_Result>((IEnumerable<SmsspSelectSmsSetting_Result>)cRMSpEntities.SmsspSelectSmsSetting());
			cRMSpEntities.Dispose();
			if (smsspSelectSmsSetting_Result != null)
			{
				SmsSettingInfoViewModel o = new SmsSettingInfoViewModel
				{
					SmsReceiveIsActive = (smsspSelectSmsSetting_Result.ReceiveIsActive.HasValue && Convert.ToBoolean(smsspSelectSmsSetting_Result.ReceiveIsActive)),
					SmsSendIsActive = (smsspSelectSmsSetting_Result.SendIsActive.HasValue && Convert.ToBoolean(smsspSelectSmsSetting_Result.SendIsActive)),
					SmsWsDomainNamed = smsspSelectSmsSetting_Result.DomainName,
					SmsWsEnCost = (smsspSelectSmsSetting_Result.EnCost.HasValue ? ((int)smsspSelectSmsSetting_Result.EnCost.Value).ToString() : ""),
					SmsWsFaCost = (smsspSelectSmsSetting_Result.FaCost.HasValue ? ((int)smsspSelectSmsSetting_Result.FaCost.Value).ToString() : ""),
					SmsWsFromNumber = smsspSelectSmsSetting_Result.Number,
					SmsWsUserName = smsspSelectSmsSetting_Result.UserName,
					SmsWsPassword = smsspSelectSmsSetting_Result.Password,
					CmpPattern = smsspSelectSmsSetting_Result.CmpPattern,
					CmpTPattern = smsspSelectSmsSetting_Result.CmpTPattern,
					PrsFNPattern = smsspSelectSmsSetting_Result.PrsFNPattern,
					PrsJobPattern = smsspSelectSmsSetting_Result.PrsJobPattern,
					PrsLNPattern = smsspSelectSmsSetting_Result.PrsLNPattern,
					PrsTPattern = smsspSelectSmsSetting_Result.PrsTPattern,
					LastCreditAmount = smsspSelectSmsSetting_Result.LastCreditAmount,
					SmsProviderId = smsspSelectSmsSetting_Result.ProviderId.GetValueOrDefault(),
					ActiveSendBirthCongratulate = smsspSelectSmsSetting_Result.ActiveSendBirthCongratulate,
					SendBirthCongratulateText = smsspSelectSmsSetting_Result.SendBirthCongratulateText,
					SendBirthCongratulateWeb = smsspSelectSmsSetting_Result.SendBirthCongratulateWeb,
					SendBirthCongratulateGSM = smsspSelectSmsSetting_Result.SendBirthCongratulateGSM,
					ActiveSendMarriageCongratulate = smsspSelectSmsSetting_Result.ActiveSendMarriageCongratulate,
					SendMarriageCongratulateText = smsspSelectSmsSetting_Result.SendMarriageCongratulateText,
					SendMarriageCongratulateWeb = smsspSelectSmsSetting_Result.SendMarriageCongratulateWeb,
					SendMarriageCongratulateGSM = smsspSelectSmsSetting_Result.SendMarriageCongratulateGSM,
					ActiveSendSMSAfterReceive = smsspSelectSmsSetting_Result.ActiveSendSMSAfterReceive,
					SendSMSAfterReceiveText = smsspSelectSmsSetting_Result.SendSMSAfterReceiveText,
					SendSMSAfterReceiveWeb = smsspSelectSmsSetting_Result.SendSMSAfterReceiveWeb,
					SendSMSAfterReceiveGSM = smsspSelectSmsSetting_Result.SendSMSAfterReceiveGSM,
					SendStartTime = smsspSelectSmsSetting_Result.SendStartTime,
					SendEndTime = smsspSelectSmsSetting_Result.SendEndTime,
					SendStartDate = smsspSelectSmsSetting_Result.SendStartDate,
					SendEndDate = smsspSelectSmsSetting_Result.SendEndDate,
					SendStartDatePersian = smsspSelectSmsSetting_Result.SendStartDatePersian,
					SendEndDatePersian = smsspSelectSmsSetting_Result.SendEndDatePersian,
					SendBirthCongratulateStartTime = smsspSelectSmsSetting_Result.SendBirthCongratulateStartTime,
					SendBirthCongratulateSMSNumber = smsspSelectSmsSetting_Result.SendBirthCongratulateSMSNumber,
					SendMarriageCongratulateStartTime = smsspSelectSmsSetting_Result.SendMarriageCongratulateStartTime,
					SendMarriageCongratulateSMSNumber = smsspSelectSmsSetting_Result.SendMarriageCongratulateSMSNumber,
					TokenUserName = smsspSelectSmsSetting_Result.TokenUserName,
					SmsCustomer = smsspSelectSmsSetting_Result.SmsCustomer,
					LastCreditCount = smsspSelectSmsSetting_Result.LastCreditCount,
					DecryptedPassword = false,
					ProviderUrl = smsspSelectSmsSetting_Result.ProviderUrl,
					DeActiveJobSmsCredit = smsspSelectSmsSetting_Result.DeActiveJobSmsCredit.GetValueOrDefault()
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

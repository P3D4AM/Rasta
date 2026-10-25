using System;

namespace CRM.Models;

public class SmsSettingInfoViewModel
{
	public string SmsWsUserName { get; set; }

	public string SmsWsPassword { get; set; }

	public string SmsWsDomainNamed { get; set; }

	public string SmsWsFromNumber { get; set; }

	public string SmsWsEnCost { get; set; }

	public string SmsWsFaCost { get; set; }

	public bool SmsSendIsActive { get; set; }

	public bool SmsReceiveIsActive { get; set; }

	public string CmpTPattern { get; set; }

	public string CmpPattern { get; set; }

	public string PrsTPattern { get; set; }

	public string PrsFNPattern { get; set; }

	public string PrsLNPattern { get; set; }

	public string PrsJobPattern { get; set; }

	public decimal? LastCreditAmount { get; set; }

	public int SmsProviderId { get; set; }

	public bool? ActiveSendBirthCongratulate { get; set; }

	public string SendBirthCongratulateText { get; set; }

	public bool? SendBirthCongratulateWeb { get; set; }

	public bool? SendBirthCongratulateGSM { get; set; }

	public bool? ActiveSendMarriageCongratulate { get; set; }

	public string SendMarriageCongratulateText { get; set; }

	public bool? SendMarriageCongratulateWeb { get; set; }

	public bool? SendMarriageCongratulateGSM { get; set; }

	public bool? ActiveSendSMSAfterReceive { get; set; }

	public string SendSMSAfterReceiveText { get; set; }

	public bool? SendSMSAfterReceiveWeb { get; set; }

	public bool? SendSMSAfterReceiveGSM { get; set; }

	public string SendStartTime { get; set; }

	public string SendEndTime { get; set; }

	public DateTime? SendStartDate { get; set; }

	public DateTime? SendEndDate { get; set; }

	public string SendStartDatePersian { get; set; }

	public string SendEndDatePersian { get; set; }

	public string SendBirthCongratulateStartTime { get; set; }

	public string SendBirthCongratulateSMSNumber { get; set; }

	public string SendMarriageCongratulateStartTime { get; set; }

	public string SendMarriageCongratulateSMSNumber { get; set; }

	public string TokenUserName { get; set; }

	public string SmsCustomer { get; set; }

	public decimal? LastCreditCount { get; set; }

	public bool? DecryptedPassword { get; set; }

	public string ProviderUrl { get; set; }

	public bool? DeActiveJobSmsCredit { get; set; }
}

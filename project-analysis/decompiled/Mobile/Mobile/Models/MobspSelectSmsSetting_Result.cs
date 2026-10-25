using System;

namespace Mobile.Models;

public class MobspSelectSmsSetting_Result
{
	public int Id { get; set; }

	public string UserName { get; set; }

	public string Password { get; set; }

	public string Number { get; set; }

	public decimal? EnCost { get; set; }

	public decimal? FaCost { get; set; }

	public bool? SendIsActive { get; set; }

	public bool? ReceiveIsActive { get; set; }

	public string Description { get; set; }

	public string tmp { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string CmpTPattern { get; set; }

	public string CmpPattern { get; set; }

	public string PrsTPattern { get; set; }

	public string PrsFNPattern { get; set; }

	public string PrsLNPattern { get; set; }

	public string PrsJobPattern { get; set; }

	public Guid? GUId { get; set; }

	public bool? GetAutoDeliveryIsActive { get; set; }

	public string AppType { get; set; }

	public decimal? LastCreditAmount { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public bool? ActiveSendAfterRegNewNum { get; set; }

	public string SendAfterRegNewNumText { get; set; }

	public bool? SendAfterRegNewNumWeb { get; set; }

	public bool? SendAfterRegNewNumGSM { get; set; }

	public bool? ActiveSendAfterUnKnownNumCall { get; set; }

	public string SendAfterUnKnownNumCallText { get; set; }

	public bool? SendAfterUnKnownNumCallWeb { get; set; }

	public bool? SendAfterUnKnownNumCallGSM { get; set; }

	public bool? ActiveSendAfterKnownCallNum { get; set; }

	public string SendAfterKnownNumCallText { get; set; }

	public bool? SendAfterKnownNumCallWeb { get; set; }

	public bool? SendAfterKnownNumCallGSM { get; set; }

	public bool? ActiveSendBirthCongratulate { get; set; }

	public string SendBirthCongratulateText { get; set; }

	public bool? SendBirthCongratulateWeb { get; set; }

	public bool? SendBirthCongratulateGSM { get; set; }

	public bool? ActiveSendMarriageCongratulate { get; set; }

	public string SendMarriageCongratulateText { get; set; }

	public bool? SendMarriageCongratulateWeb { get; set; }

	public bool? SendMarriageCongratulateGSM { get; set; }

	public int? ProviderId { get; set; }

	public string DomainName { get; set; }

	public bool? ActiveSendSMSAfterReceive { get; set; }

	public string SendSMSAfterReceiveText { get; set; }

	public bool? SendSMSAfterReceiveWeb { get; set; }

	public bool? SendSMSAfterReceiveGSM { get; set; }

	public string SendStartTime { get; set; }

	public string SendEndTime { get; set; }

	public DateTime? SendStartDate { get; set; }

	public string SendStartDatePersian { get; set; }

	public DateTime? SendEndDate { get; set; }

	public string SendEndDatePersian { get; set; }

	public string SendBirthCongratulateStartTime { get; set; }

	public string SendBirthCongratulateSMSNumber { get; set; }

	public string SendMarriageCongratulateStartTime { get; set; }

	public string SendMarriageCongratulateSMSNumber { get; set; }

	public string CmpUserNamePattern { get; set; }

	public string CmpPasswordPattern { get; set; }

	public string TokenUserName { get; set; }

	public string SmsCustomer { get; set; }

	public string ProviderUrl { get; set; }
}

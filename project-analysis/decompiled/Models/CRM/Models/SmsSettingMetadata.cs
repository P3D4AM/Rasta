using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class SmsSettingMetadata
{
	[Key]
	public int Id { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SmsSetUserName")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string UserName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SmsSetPassword")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Password { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SmsSetNumber")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Number { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SmsSetEnCost")]
	[DisplayFormat(DataFormatString = "{0:#}")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public decimal? EnCost { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SmsSetFaCost")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public decimal? FaCost { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SmsSetSendIsActive")]
	public bool? SendIsActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SmsSetReceiveIsActive")]
	public bool? ReceiveIsActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SmsSetDescription")]
	[MaxLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
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

	[Display(ResourceType = typeof(Labels), Name = "SmsSetGetAutoDeliveryIsActive")]
	public bool? GetAutoDeliveryIsActive { get; set; }

	public string AppType { get; set; }

	public decimal? LastCreditAmount { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public bool? ActiveSendAfterRegNewNum { get; set; }

	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string SendAfterRegNewNumText { get; set; }

	public bool? SendAfterRegNewNumWeb { get; set; }

	public bool? SendAfterRegNewNumGSM { get; set; }

	public bool? ActiveSendAfterUnKnownNumCall { get; set; }

	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string SendAfterUnKnownNumCallText { get; set; }

	public bool? SendAfterUnKnownNumCallWeb { get; set; }

	public bool? SendAfterUnKnownNumCallGSM { get; set; }

	public bool? ActiveSendAfterKnownCallNum { get; set; }

	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string SendAfterKnownNumCallText { get; set; }

	public bool? SendAfterKnownNumCallWeb { get; set; }

	public bool? SendAfterKnownNumCallGSM { get; set; }

	public bool? ActiveSendBirthCongratulate { get; set; }

	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string SendBirthCongratulateText { get; set; }

	public bool? SendBirthCongratulateWeb { get; set; }

	public bool? SendBirthCongratulateGSM { get; set; }

	public bool? ActiveSendMarriageCongratulate { get; set; }

	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string SendMarriageCongratulateText { get; set; }

	public bool? SendMarriageCongratulateWeb { get; set; }

	public bool? SendMarriageCongratulateGSM { get; set; }

	public bool? ActiveSendSMSAfterReceive { get; set; }

	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string SendSMSAfterReceiveText { get; set; }

	public bool? SendSMSAfterReceiveWeb { get; set; }

	public bool? SendSMSAfterReceiveGSM { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SmsSetSendStartDate")]
	public string SendStartDatePersian { get; set; }

	public DateTime? SendStartDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SmsSetSendEndDate")]
	public string SendEndDatePersian { get; set; }

	public DateTime? SendEndDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SmsSetSendStartTime")]
	[RegularExpression("^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string SendStartTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SmsSetSendEndTime")]
	[RegularExpression("^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string SendEndTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SmsSetSendBirthCongratulateStartTime")]
	[RegularExpression("^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string SendBirthCongratulateStartTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SmsSetSendBirthCongratulateSMSNumber")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string SendBirthCongratulateSMSNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SmsSetSendMarriageCongratulateStartTime")]
	[RegularExpression("^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string SendMarriageCongratulateStartTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SmsSetSendMarriageCongratulateSMSNumber")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string SendMarriageCongratulateSMSNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SmsSetDeActiveJobSmsCredit")]
	public bool? DeActiveJobSmsCredit { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SmsSetTokenUserName")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string TokenUserName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SmsSetCustomer")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string SmsCustomer { get; set; }
}

using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class SmsGSMModemSettingMetadata
{
	[Key]
	public int ID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "GSMModemSettingMode")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Mode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "GSMModemSettingProtocol")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Protocol { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "GSMModemSettingParameter")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Parameter { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "GSMModemSettingPinCode")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PinCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "GSMModemSettingConcatenatedSMS")]
	public bool? ConcatenatedSMS { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "GSMModemSettingFlashSMS")]
	public bool? FlashSMS { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "GSMModemSettingRequestSendReport")]
	public bool? RequestSendReport { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "GSMModemSettingAutoDeleteNewSMS")]
	public bool? AutoDeleteNewSMS { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "GSMModemSettingAutoDeleteAllReports")]
	public bool? AutoDeleteAllReports { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "GSMModemSettingRetryTimes")]
	public int? RetryTimes { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "GSMModemSettingSendInterval")]
	public int? SendInterval { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "GSMModemSettingSendTimeout")]
	public int? SendTimeout { get; set; }

	public string Message { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "GSMSettingInfoSendWithDelay")]
	public bool? SendWithDelay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "GSMModemSettingDelayTime")]
	public int? DelayTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "GSMModemSettingDescription")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Description { get; set; }

	public int? UserId { get; set; }

	public short? Year1 { get; set; }

	public short? Month1 { get; set; }

	public DateTime? RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "GSMModemSettingSimNumber")]
	[MaxLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string SimNumber { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "GSMModemSettingSendingIsActive")]
	public bool? SendingIsActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "GSMModemSettingLineIsActive")]
	public bool? LineIsActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "GSMModemSettingDeviceName")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string DeviceName { get; set; }

	public string gsmManufacturer { get; set; }

	public string gsmModel { get; set; }

	public string gsmIMEI { get; set; }

	public string gsmNetworkInfo { get; set; }

	public string gsmBatteryLevel { get; set; }

	public string gsmSignalLevel { get; set; }

	public string gsmFirmware { get; set; }

	public string gsmHardware { get; set; }

	public string gsmTime { get; set; }

	public string gsmSMSCNumber { get; set; }

	public string ConnectStatus { get; set; }

	public string LastSendError { get; set; }

	public int? SendStop { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "GSMModemSettingSendFTime")]
	[MaxLength(5, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(5, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string SendFTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "GSMModemSettingSendTTime")]
	[MaxLength(5, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(5, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string SendTTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "GSMModemSettingDeviceUniqeOrderIdForServiceSelect")]
	public int? DeviceUniqeOrderIdForServiceSelect { get; set; }
}

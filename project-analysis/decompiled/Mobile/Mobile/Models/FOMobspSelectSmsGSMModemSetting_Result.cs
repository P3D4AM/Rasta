using System;

namespace Mobile.Models;

public class FOMobspSelectSmsGSMModemSetting_Result
{
	public int ID { get; set; }

	public string Mode { get; set; }

	public string Protocol { get; set; }

	public string Parameter { get; set; }

	public string PinCode { get; set; }

	public bool? ConcatenatedSMS { get; set; }

	public bool? FlashSMS { get; set; }

	public bool? RequestSendReport { get; set; }

	public bool? AutoDeleteNewSMS { get; set; }

	public bool? AutoDeleteAllReports { get; set; }

	public int? RetryTimes { get; set; }

	public int? SendInterval { get; set; }

	public int? SendTimeout { get; set; }

	public string Message { get; set; }

	public bool? SendWithDelay { get; set; }

	public int? DelayTime { get; set; }

	public string Description { get; set; }

	public int? UserId { get; set; }

	public short? Year1 { get; set; }

	public short? Month1 { get; set; }

	public DateTime? RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string SimNumber { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public bool? SendingIsActive { get; set; }

	public bool? LineIsActive { get; set; }

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

	public string SendFTime { get; set; }

	public string SendTTime { get; set; }

	public int? DeviceUniqeOrderIdForServiceSelect { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }
}

using System;

namespace CRM.Models.ReportModel;

public class CrmsysSettingRpt
{
	public int ID { get; set; }

	public string CoName { get; set; }

	public byte[] CoLoGo { get; set; }

	public string Address { get; set; }

	public string Telephone { get; set; }

	public string Fax { get; set; }

	public string Email { get; set; }

	public string WebSite { get; set; }

	public string ServerIP { get; set; }

	public int? UserId { get; set; }

	public short? Year1 { get; set; }

	public short? Month1 { get; set; }

	public DateTime? RegisterDate { get; set; }

	public string SantralPreNumber { get; set; }

	public string CallerIDServerIP { get; set; }

	public bool? ServiceSIP { get; set; }

	public bool? ServiceSGIP { get; set; }

	public string RegistrationNumber { get; set; }

	public string EconomicCode { get; set; }

	public string NationalCode { get; set; }

	public string QuickAddress { get; set; }

	public string LockSerial { get; set; }

	public string LockCounter { get; set; }

	public string LockNU { get; set; }

	public bool? LockControl { get; set; }

	public string AppFilePath { get; set; }

	public Guid? GUId { get; set; }

	public bool? ServiceCIIP { get; set; }

	public string PublicNotice { get; set; }

	public string ZipCode { get; set; }

	public bool? ServiceFADeAc { get; set; }

	public string RecordingVoiceServerIP { get; set; }

	public bool? ServiceRIP { get; set; }

	public bool? CantSaveDupPrsMob { get; set; }

	public bool? CantSaveDupPrsEmail { get; set; }

	public bool? MustFullcnvsRemindDate { get; set; }

	public string CallerIDVersion { get; set; }

	public string CallerIDOldVersion { get; set; }

	public string SMSServiceVersion { get; set; }

	public string SMSServiceOldVersion { get; set; }

	public bool? ServiceBuyOrdIP { get; set; }

	public bool? ServiceEmailIP { get; set; }

	public bool? ServiceLetterIP { get; set; }

	public string AppType { get; set; }

	public bool? DisablefrmcmpSearchOnType { get; set; }

	public string SMSGSMServiceVersion { get; set; }

	public string SMSGSMServiceOldVersion { get; set; }

	public int? LanguageID { get; set; }

	public int? DefaultLanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? CityId { get; set; }

	public string CityName { get; set; }

	public int? ProvinceId { get; set; }

	public string ProvinceName { get; set; }

	public int? CountryId { get; set; }

	public string CountryName { get; set; }
}

using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmsysSettingMetadata
{
	[Key]
	public int ID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CoName")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string CoName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CoLoGo")]
	public byte[] CoLoGo { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "Address")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Address { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "Telephone")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Telephone { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "Fax")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Fax { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "Email")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Email { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WebSite")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string WebSite { get; set; }

	public string ServerIP { get; set; }

	public int? UserId { get; set; }

	public short? Year1 { get; set; }

	public short? Month1 { get; set; }

	public DateTime? RegisterDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SantralPreNumber")]
	public string SantralPreNumber { get; set; }

	public string CallerIDServerIP { get; set; }

	public bool? ServiceSIP { get; set; }

	public bool? ServiceSGIP { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "RegistrationNumber")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string RegistrationNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "EconomicCode")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string EconomicCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "NationalCode")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string NationalCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "QuickAddress")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string QuickAddress { get; set; }

	public string LockSerial { get; set; }

	public string LockCounter { get; set; }

	public string LockNU { get; set; }

	public bool? LockControl { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "AppFilePath")]
	public string AppFilePath { get; set; }

	public Guid? GUId { get; set; }

	public bool? ServiceCIIP { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PublicNotice")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PublicNotice { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ZipCode")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
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
}

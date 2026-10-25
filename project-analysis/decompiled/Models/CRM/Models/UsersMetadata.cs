using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class UsersMetadata
{
	[Key]
	public int UserId { get; set; }

	public int? Row { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FName")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string FName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LName")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string LName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PersCode")]
	public string PersCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserName")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string UserName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "Password")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Password { get; set; }

	public string IsAdmin { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "IsActive")]
	public bool? IsActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "Description")]
	public string Description { get; set; }

	public int? UserId1 { get; set; }

	public short? Month1 { get; set; }

	public DateTime? RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string IPAddress { get; set; }

	public string Tel { get; set; }

	public string TelDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PositionId")]
	public int? PositionId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SignatureId")]
	public int? SignatureId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ResponsibleUserId")]
	public int? ResponsibleUserId { get; set; }

	public string ComputerName { get; set; }

	public Guid? GUId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CallreIdDeActive")]
	public bool? CallreIdDeActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CallreIdDeActiveLines")]
	public string CallreIdDeActiveLines { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DisableInternalMessageAllarmVoice")]
	public bool? DisableInternalMessageAllarmVoice { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DisableReceiveCNVSInfoAllarm")]
	public bool? DisableReceiveCNVSInfoAllarm { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "EmailAttachFileLocation")]
	public string EmailAttachFileLocation { get; set; }

	public string AppType { get; set; }

	public bool? CanSetFree { get; set; }

	public string UserCIPatternFormulaPopUp { get; set; }

	public bool? UseClientNameForNetworking { get; set; }

	public bool? UserIsActiveInWinApp { get; set; }

	public bool? UserIsActiveInWebApp { get; set; }

	public bool? UserIsActiveInMobApp { get; set; }

	public int? LanguageID { get; set; }

	public bool? AllowCopyOtherLanguage { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }
}

using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

internal class SecLetterDefaultSettingsMetadata
{
	[Key]
	public int LetterDefaultSettingId { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "LtrSendDefTitle")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string LDTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LtrSendDefAnnex")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string LDAnnex { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LtrSendDefCmpNickName")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string LDcmpNickName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LtrSendDefCmpPersonNickName")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string LDcmpPersonNickName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LtrSendDefSubject")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string LDSubject { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LtrSendDefHeader")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string LDHeader { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LtrSendDefContext")]
	public string LDContext { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LtrSendDefFooter")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string LDFooter { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LtrSendDefSigningI")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string LDSigningI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LtrSendDefSigningII")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string LDSigningII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LtrSendDefSigningIII")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string LDSigningIII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LtrSendDefSigningIV")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string LDSigningIV { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LtrSendDefPrintFormatId")]
	public int? LDPrintFormatId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LtrSendDefReferUserId")]
	public int? LDReferUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int FirstRegisterUserId { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LtrSendDefVerifierRequestId")]
	public int? LDVerifierRequestId { get; set; }
}

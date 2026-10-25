using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class SecLetterDefaultSettingsLanguageViewModel
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

	public int? LanguageID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LtrSendDefEmailUsersInfoId")]
	public int? LDEmailUsersInfoId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LtrSendDefEmailUserDefaultSettingId")]
	public int? LDEmailUserDefaultSettingId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LtrSendDefNumberCounterId")]
	public int? LDNumberCounterId { get; set; }

	public string LDTitle_Lang { get; set; }

	public string LDAnnex_Lang { get; set; }

	public string LDcmpNickName_Lang { get; set; }

	public string LDcmpPersonNickName_Lang { get; set; }

	public string LDSubject_Lang { get; set; }

	public string LDHeader_Lang { get; set; }

	public string LDContext_Lang { get; set; }

	public string LDFooter_Lang { get; set; }

	public string LDSigningI_Lang { get; set; }

	public string LDSigningII_Lang { get; set; }

	public string LDSigningIII_Lang { get; set; }

	public string LDSigningIV_Lang { get; set; }

	public string EditUser { get; set; }

	public string FirstRegisterUser { get; set; }

	public string AppTypeHelp { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LtrSendDefVerificationWorkFlowId")]
	public int? LDVerificationWorkFlowId { get; set; }

	public bool? IsPublic { get; set; }

	public bool? CanVerifyInSameContext { get; set; }
}

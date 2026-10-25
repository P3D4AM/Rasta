using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CRM.Resources;

namespace CRM.Models;

public class SecLettersLanguageViewModel
{
	[Key]
	public int LetterId { get; set; }

	public int LetterTypeId { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "LetterDate")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string LetterDate { get; set; }

	public DateTime LetterDateTime { get; set; }

	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string LetterPreNumber { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "LetterNumber")]
	public long LetterNumber { get; set; }

	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string LetterPreNumberII { get; set; }

	public long? LetterNumberII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LetterAnnex")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string LetterAnnex { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "LetterCompanyId")]
	public int? LetterCompanyId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LettercmpNickName")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string LettercmpNickName { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "LettercmpPersonId")]
	public int? LettercmpPersonId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LettercmpPersonNickName")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string LettercmpPersonNickName { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "LettercmpProjectId")]
	public int? LettercmpProjectId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LetterSubject")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string LetterSubject { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LetterHeader")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string LetterHeader { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LetterContext")]
	public string LetterContext { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LetterFooter")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string LetterFooter { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LetterSigningI")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string LetterSigningI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LetterSigningII")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string LetterSigningII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LetterSigningIII")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string LetterSigningIII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LetterSigningIV")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string LetterSigningIV { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LetterPrintFormatId")]
	public int? LetterPrintFormatId { get; set; }

	public string LetterLastPrintDate { get; set; }

	public string LetterLastPrintTime { get; set; }

	public DateTime? LetterLastPrintDateTime { get; set; }

	public bool? LetterIsVerified { get; set; }

	public int? LetterVerifierId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LetterVerifierRequestId")]
	public int? LetterVerifierRequestId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LetterEmailUsersInfoId")]
	public int? LetterEmailUsersInfoId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LetterEmailUserDefaultSettingId")]
	public int? LetterEmailUserDefaultSettingId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LetterNumberCounterId")]
	public int? LetterNumberCounterId { get; set; }

	public DateTime? LetterVerifiedRegisterDate { get; set; }

	public string LetterVerifiedRegisterDatePersian { get; set; }

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

	public int? LanguageID { get; set; }

	public string LetterAnnex_Lang { get; set; }

	public string LettercmpNickName_Lang { get; set; }

	public string LettercmpPersonNickName_Lang { get; set; }

	public string LetterSubject_Lang { get; set; }

	public string LetterHeader_Lang { get; set; }

	public string LetterContext_Lang { get; set; }

	public string LetterFooter_Lang { get; set; }

	public string LetterSigningI_Lang { get; set; }

	public string LetterSigningII_Lang { get; set; }

	public string LetterSigningIII_Lang { get; set; }

	public string LetterSigningIV_Lang { get; set; }

	[DataType(DataType.MultilineText)]
	[AllowHtml]
	public string LetterContextRtf_Lang { get; set; }

	[DataType(DataType.MultilineText)]
	[AllowHtml]
	[Display(ResourceType = typeof(Labels), Name = "LetterContext")]
	public string LetterContextRtf { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LetterVerificationWorkFlowId")]
	public int? LetterVerificationWorkFlowId { get; set; }

	public bool? LetterIsFixed { get; set; }

	public int? LetterDefaultSettingId { get; set; }
}

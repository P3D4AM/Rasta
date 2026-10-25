using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmCmpPrsPrjCnvsLanguageViewModel
{
	public int CompanyId { get; set; }

	[MaxLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string CmpName { get; set; }

	[MaxLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string CmpPreTel { get; set; }

	[MaxLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string CmpTel { get; set; }

	public int? CmpCountryId { get; set; }

	public int? CmpProvinceId { get; set; }

	public int? CmpCityId { get; set; }

	public int? CmpNumber { get; set; }

	public int? CmpPresentationId { get; set; }

	public int? CmpTypeId { get; set; }

	[MaxLength(250, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(250, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string CmpAddress { get; set; }

	public string CmpEffectiveDate { get; set; }

	public int? CmpTitleId { get; set; }

	public int CompanyPersonId { get; set; }

	public int? PrsTitleId { get; set; }

	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PrsLName { get; set; }

	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PrsFName { get; set; }

	[MaxLength(11, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(11, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PrsMobile { get; set; }

	public string PrsBirthDate { get; set; }

	[MaxLength(30, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(30, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PrsNationalCode { get; set; }

	public int ProjectId { get; set; }

	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PrjTitle { get; set; }

	public int? PrjGroupId { get; set; }

	public int? PrjGradeId { get; set; }

	public int? PrjPriorityId { get; set; }

	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PrjPostFix { get; set; }

	public string PrjStartDate { get; set; }

	public string PrjRemindDate { get; set; }

	public int? DefProjectGroupId { get; set; }

	[MaxLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PrjDesc { get; set; }

	public int ConversationId { get; set; }

	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string CnvsDesc { get; set; }

	public int? CnvsReferUserId { get; set; }

	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string CnvsReferDesc { get; set; }

	public int? CnvsStatusId { get; set; }

	public int? CnvsStatusResultId { get; set; }

	public string CnvsRemindDate { get; set; }

	public string CmpReferUser { get; set; }

	public int? CmpReferUserId { get; set; }

	public int? CmpSuppUserId { get; set; }

	public int? PrjFirstCnvsUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public string RegisterUser { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public string RegisterDatePersian { get; set; }

	public string CnvsTime { get; set; }

	public int? IsPrj { get; set; }

	public int? CmpKind { get; set; }

	public string CmpName_Lang { get; set; }

	public string CmpAddress_Lang { get; set; }

	public string PrsLName_Lang { get; set; }

	public string PrsFName_Lang { get; set; }

	public string PrjTitle_Lang { get; set; }

	public string PrjPostFix_Lang { get; set; }

	public string PrjDesc_Lang { get; set; }

	public string CnvsDesc_Lang { get; set; }

	public string CnvsReferDesc_Lang { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CompanyIIQuickRegisterDefSettingId")]
	public int? CompanyQuickRegisterDefSettingId { get; set; }

	public int? CnvsTopicId { get; set; }
}

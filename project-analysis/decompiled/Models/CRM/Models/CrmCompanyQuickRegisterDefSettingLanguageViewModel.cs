using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmCompanyQuickRegisterDefSettingLanguageViewModel
{
	[Key]
	public int CompanyQuickRegisterDefSettingId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingSettingTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string SettingTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingCmpTitle")]
	public int? cmpTitleId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingCmpActivityType")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpActivityType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingCmpGroup")]
	public int? cmpGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingCmpSubGroup")]
	public int? cmpSubGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingCmpGroupII")]
	public int? cmpGroupIdII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingCmpGroupIII")]
	public int? cmpGroupIdIII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingCmpGroupIV")]
	public int? cmpGroupIdIV { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingCmpType")]
	public int? cmpTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingCmpPresentation")]
	public int? cmpPresentationId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingCmpCity")]
	public int? cmpCityId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingCmpSpecialPoint")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpSpecialPoint { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingCmpDescription")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpDescription { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingCmpEffectiveDateIncDay")]
	public int? cmpEffectiveDateIncDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingCmpKind")]
	public int? cmpKind { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingPrsTitle")]
	public int? prsTitleId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingPrsJob")]
	public int? prsJobId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingPrsType")]
	public int? prsTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingPrsGroup")]
	public int? prsGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingPrsSex")]
	public int? prsSexId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingPrsEducation")]
	public int? prsEducationId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingPrsCity")]
	public int? prsCityId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingPrsSpecialPoint")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsSpecialPoint { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingPrsDescription")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsDescription { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingPrsDepartment")]
	public int? prsDepartmentId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingPrjTitle")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prjTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingPrjDesc")]
	[MaxLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prjDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingPrjGrade")]
	public int? prjGradeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingPrjPriority")]
	public int? prjPriorityId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingPrjGroup")]
	public int? prjGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingPrjCnvsStatusGroup")]
	public int? prjcnvsStatusGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingPrjPostFix")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prjPostFix { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingPrjRemindDateIncDay")]
	public int? prjRemindDateIncDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingPrjFOCmpCanSee")]
	public bool? prjFOCmpCanSee { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingPrjSubject")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prjSubject { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingPrjTitleGroup")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prjTitleGroup { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingPrjCategory")]
	public int? prjCategoryId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingPrjDescI")]
	public string prjDescI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingCnvsTopic")]
	public int? cnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingCnvsDesc")]
	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cnvsDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingCnvsStatus")]
	public int? cnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingCnvsPriority")]
	public int? cnvsPriorityId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingCnvsRemindDateIncDay")]
	public int? cnvsRemindDateIncDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingCnvsRemindTime")]
	public string cnvsRemindTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingCnvsRemindDateForAllarmIncDay")]
	public int? cnvsRemindDateForAllarmIncDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingCnvsFOCmpCanSee")]
	public bool? cnvsFOCmpCanSee { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingOrderView")]
	public int? OrderView { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingIsDefault")]
	public bool? IsDefault { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingIsDefaultForCmpInfo")]
	public bool? IsDefaultForCmpInfo { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string AppType { get; set; }

	public string FirstRegisterInfo { get; set; }

	public string RegisterInfo { get; set; }

	public string SettingTitle_Lang { get; set; }

	public string cmpActivityType_Lang { get; set; }

	public string cmpSpecialPoint_Lang { get; set; }

	public string cmpDescription_Lang { get; set; }

	public string prsSpecialPoint_Lang { get; set; }

	public string prsDescription_Lang { get; set; }

	public string prjTitle_Lang { get; set; }

	public string prjDesc_Lang { get; set; }

	public string prjPostFix_Lang { get; set; }

	public string prjSubject_Lang { get; set; }

	public string prjTitleGroup_Lang { get; set; }

	public string prjDescI_Lang { get; set; }

	public string cnvsDesc_Lang { get; set; }

	public string cnvsReferDesc_Lang { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingIsDefIssueQuickOrder")]
	public bool? IsDefIssueQuickOrder { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingPrjpordDefaultSetting")]
	public int? prjpordDefaultSettingId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingprjordDefaultSetting")]
	public int? prjordDefaultSettingId { get; set; }

	public string cmpLocationLat { get; set; }

	public string cmpLocationLong { get; set; }

	public double? cmpLocationZoom { get; set; }

	public string prsLocationLat { get; set; }

	public string prsLocationLong { get; set; }

	public double? prsLocationZoom { get; set; }

	public short? PublicMode { get; set; }

	public string AccessUserJson { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegisterDefSettingActiveInQuickOrder")]
	public bool? ActiveInQuickOrder { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "InActive")]
	public bool? InActive { get; set; }

	public int SaveDefSettings { get; set; }
}

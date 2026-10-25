using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmProjectsInsertViewModel
{
	[Key]
	public int ProjectID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjCompanyId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int prjCompanyId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prjTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjDesc")]
	[MaxLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prjDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjStartDate")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string prjStartDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjStartDay")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prjStartDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjStartTime")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prjStartTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjStartDateTime")]
	public DateTime? prjStartDateTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjStarterUserId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? prjStarterUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjFinishedStatusId")]
	public int? prjFinishedStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjIsFinished")]
	public bool? prjIsFinished { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjFinishedDate")]
	[MaxLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prjFinishedDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjFinishedDay")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prjFinishedDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjFinishedTime")]
	[MaxLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prjFinishedTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjFinishedDateTime")]
	public DateTime? prjFinishedDateTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjFinishedUserId")]
	public int? prjFinishedUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjGradeId")]
	public int? prjGradeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjPriorityId")]
	public int? prjPriorityId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjFirstRegisterDate")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prjFirstRegisterDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjFirstRegisterUserId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int prjFirstRegisterUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjGroupId")]
	public int? prjGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjcnvsStatusGroupId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? prjcnvsStatusGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjOrderView")]
	public int? prjOrderView { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjInsertForbidden")]
	public bool? prjInsertForbidden { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjPostFix")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prjPostFix { get; set; }

	public DateTime? FirstRegisterDateTime { get; set; }

	public DateTime? prjFirstRegisterDateTime { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjRemindDate")]
	[MaxLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prjRemindDate { get; set; }

	public DateTime? prjRemindDateTime { get; set; }

	public string AppType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjFOCmpCanSee")]
	public bool? prjFOCmpCanSee { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjHaveSms")]
	public bool? prjHaveSms { get; set; }

	[MaxLength(3000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(3000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prjSmsPrsIds { get; set; }

	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prjSmsText { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjSmsSendDate")]
	[MaxLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prjSmsSendDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjIsSendSmsAfterSubmit")]
	public bool? prjIsSendSmsAfterSubmit { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjInquiryNum")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prjInquiryNum { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjSubject")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prjSubject { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjTitleGroup")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prjTitleGroup { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjCategoryId")]
	public int? prjCategoryId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjDescI")]
	public string prjDescI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjNumRef")]
	[MaxLength(150, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(150, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prjNumRef { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjNumR")]
	public long? prjNumR { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjQuickRegisterDefSettingId")]
	public int? CompanyQuickRegisterDefSettingId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjToDoTime")]
	public string prjToDoTimeStr { get; set; }

	public DateTime? prjToDoTime { get; set; }

	public string prjToDoTimeStrTime { get; set; }

	public string prjToDoTimeByFormat { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjToDoTimeRegister")]
	public string prjToDoTimeRegisterStr { get; set; }

	public DateTime? prjToDoTimeRegister { get; set; }

	public string prjToDoTimeRegisterTime { get; set; }

	public string prjToDoTimeRegisterByFormat { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjToDoTimeDone")]
	public string prjToDoTimeDoneStr { get; set; }

	public DateTime? prjToDoTimeDone { get; set; }

	public string prjToDoTimeDoneTime { get; set; }

	public string prjToDoTimeDoneByFormat { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjIsTicket")]
	public bool? prjIsTicket { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjFOCmpCanInsCnvs")]
	public bool? prjFOCmpCanInsCnvs { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjFOCmpCanNotInsCnvs")]
	public bool? prjFOCmpCanNotInsCnvs { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjTicketStop")]
	public bool? prjTicketStop { get; set; }

	public long? prjToDoTimeSec { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjUserDepartmentId")]
	public int? prjUserDepartmentId { get; set; }

	public bool? CanSetPrjToDoTimeDone { get; set; }

	public string prjToDoTimeRegisterHistory { get; set; }

	public string prjToDoTimeSecStr { get; set; }

	public int? prjTicketStopUserId { get; set; }

	public string prjTicketStopUser { get; set; }

	public DateTime? prjTicketStopRegisterDate { get; set; }

	public string prjTicketStopRegisterDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjcmpPresentationId")]
	public int? prjcmpPresentationId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjcmpCampaignIds")]
	public string prjcmpCampaignIds { get; set; }

	public string prjcmpCampaignIdsList { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjValidityPrdId")]
	public int? prjValidityPrdId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjValidityOrdItemId")]
	public int? prjValidityOrdItemId { get; set; }

	public int? prjCId { get; set; }

	public string prjTitle_Lang { get; set; }

	public string prjDesc_Lang { get; set; }

	public string prjPostFix_Lang { get; set; }

	public string prjSubject_Lang { get; set; }

	public string prjTitleGroup_Lang { get; set; }

	public string prjDescI_Lang { get; set; }
}

using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmProjectsViewModel
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
	[MaxLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prjStartDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjStartDay")]
	[MaxLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prjStartDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjStartTime")]
	[MaxLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prjStartTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjStartDateTime")]
	public DateTime? prjStartDateTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjStarterUserId")]
	public int? prjStarterUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjStarterUserId")]
	public string prjStarterUserIdTitle { get; set; }

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

	[Display(ResourceType = typeof(Labels), Name = "prjFinishedUserId")]
	public string prjFinishedUserIdTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjGradeId")]
	public int? prjGradeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjGradeId")]
	public string prjGradeIdTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjPriorityId")]
	public int? prjPriorityId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjPriorityId")]
	public string prjPriorityIdTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjFirstRegisterDate")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prjFirstRegisterDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjFirstRegisterUserId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int prjFirstRegisterUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjFirstRegisterUserId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string prjFirstRegisterUserIdTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjGroupId")]
	public int? prjGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjGroupId")]
	public string prjGroupIdTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjcnvsStatusGroupId")]
	public int? prjcnvsStatusGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjcnvsStatusGroupId")]
	public string prjcnvsStatusGroupIdTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjOrderView")]
	public int? prjOrderView { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjUserId")]
	public int UserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjUserId")]
	public string UserIdTitle { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string prjPostFix { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjRemindDate")]
	public string prjRemindDate { get; set; }

	public DateTime? prjRemindDateTime { get; set; }

	public string AppType { get; set; }

	public bool? prjFOCmpCanSee { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsPrjDoingTime")]
	public string cnvsPrjDoingTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjInquiryNum")]
	public string prjInquiryNum { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjInquiryNumR")]
	public long? prjInquiryNumR { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjToDoTime")]
	public string prjToDoTimeStr { get; set; }

	public DateTime? prjToDoTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjToDoTimeRegister")]
	public string prjToDoTimeRegisterStr { get; set; }

	public DateTime? prjToDoTimeRegister { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjToDoTimeDone")]
	public string prjToDoTimeDoneStr { get; set; }

	public DateTime? prjToDoTimeDone { get; set; }
}

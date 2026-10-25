using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmDyFormWorkflowStepsLanguageViewModel
{
	[Key]
	public int FormWorkflowStepId { get; set; }

	public int WorkflowId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFrmWorkflowDetailTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string WorkflowStepTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFrmWorkflowDetailSubForm")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int SubFormId { get; set; }

	public string ReferUserIds { get; set; }

	public int? ReferRollId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFrmWorkflowDetailMultiReferUsers")]
	public string MultiReferUserIds { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFrmWorkflowDetailCheckerUsers")]
	public string CheckerUserIds { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFrmWorkflowDetailNoPrevious")]
	public bool? NoPrevious { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFrmWorkflowDetailNoNextWithOutCheck")]
	public bool? NoNextWithOutCheck { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFrmWorkflowDetailOrderView")]
	public int? OrderView { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFrmWorkflowDetailProgressPercent")]
	public int? ProgressPercent { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFrmWorkflowDetailIsActive")]
	public bool? IsActive { get; set; }

	public int ParentFormId { get; set; }

	public string WorkflowStepTitle_Lang { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFrmWorkflowDetailCheckerRollId")]
	public int? CheckerRollId { get; set; }
}

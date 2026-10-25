using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmDyFormWorkflowsLanguageViewModel
{
	[Key]
	public int FormWorkflowId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFrmWorkflowTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string WorkflowTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFrmWorkflowForm")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int DyFormId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFrmWorkflowIsActive")]
	public bool? IsActive { get; set; }

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

	[Display(ResourceType = typeof(Labels), Name = "DyFrmWorkflowPanelShowType")]
	public int? WorkflowPanelShowType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFrmWorkflowPanelHide")]
	public bool? WorkflowPanelHide { get; set; }

	public string WorkflowTitle_Lang { get; set; }
}

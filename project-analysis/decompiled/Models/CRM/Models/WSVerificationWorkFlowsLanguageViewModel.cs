using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSVerificationWorkFlowsLanguageViewModel
{
	[Key]
	public int VerificationWorkFlowId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "VerificationWorkFlowTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string VerificationWorkFlowTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "VerificationWorkFlowSequenceObservation")]
	public bool SequenceObservation { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "VerificationWorkFlowIsActive")]
	public bool IsActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "VerificationWorkFlowObjectType")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? ObjectType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "VerificationWorkFlowVerifyRequestText")]
	public string VerifyRequestText { get; set; }

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

	public string VerificationWorkFlowTitle_Lang { get; set; }

	public string VerifyRequestText_Lang { get; set; }
}

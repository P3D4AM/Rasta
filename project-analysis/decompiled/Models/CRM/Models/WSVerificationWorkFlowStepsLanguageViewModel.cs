using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSVerificationWorkFlowStepsLanguageViewModel
{
	[Key]
	public int VerificationWorkFlowStepId { get; set; }

	public int VerificationWorkFlowId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "VerificationWorkFlowStepTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string VerificationWorkFlowStepTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "VerificationWorkFlowStepVerifyUserId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? VerifyUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "VerificationWorkFlowStepAlternateVerifyUserId")]
	public int? AlternateVerifyUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "VerificationWorkFlowStepVerifyText")]
	public string VerifyText { get; set; }

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

	[Display(ResourceType = typeof(Labels), Name = "VerificationWorkFlowStepOrderView")]
	public int? OrderView { get; set; }

	public string VerificationWorkFlowStepTitle_Lang { get; set; }

	public string VerifyText_Lang { get; set; }

	public int? VerificationWorkFlowObjectTypeId { get; set; }

	public string VerificationWorkFlowTitle { get; set; }

	public bool? VerificationWorkFlowStepCanBack { get; set; }

	public bool? VerificationWorkFlowStepObjCanEdit { get; set; }

	public int? AutoReferToAltMin { get; set; }

	public string AutoReferToAltTxt { get; set; }

	public string AutoReferToAltTxt_Lang { get; set; }
}

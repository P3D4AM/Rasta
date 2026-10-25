using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class LetterIndicatorViewModel
{
	[Display(ResourceType = typeof(Labels), Name = "LetterIndicatorTypeId")]
	public string LetterTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LetterIndicatorNumberII")]
	public string LetterNumberII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LetterIndicatorNumber")]
	public string LetterNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LetterIndicatorRegUsersId")]
	public string LetterRegUsersId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LetterIndicatorVerifierId")]
	public string LetterVerifierId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LetterIndicatorVerifyStatusId")]
	public string LetterVerifyStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LetterIndicatorPrintStatusId")]
	public string LetterPrintStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LetterIndicatorCompanyNameId")]
	public string LetterCompanyNameId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LetterIndicatorCompanyName")]
	public string LetterCompanyName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LetterIndicatorFDate")]
	public string LetterFDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LetterIndicatorTDate")]
	public string LetterTDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LetterIndicatorPreNumber")]
	public string LetterPreNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LetterIndicatorAnnex")]
	public string LetterAnnex { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LetterIndicatorSubject")]
	public string LetterSubject { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LetterIndicatorHeader")]
	public string LetterHeader { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LetterIndicatorContext")]
	public string LetterContext { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LetterIndicatorFooter")]
	public string LetterFooter { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LetterIndicatorRegFDate")]
	public string LetterRegFDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LetterIndicatorRegTDate")]
	public string LetterRegTDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LetterIndicatorPrintFDate")]
	public string LetterPrintFDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LetterIndicatorPrintTDate")]
	public string LetterPrintTDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LetterIndicatorAnnexLikely")]
	public bool LetterAnnexLikely { get; set; }

	public string LetterAnnexLikelyStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LetterIndicatorSubjectLikely")]
	public bool LetterSubjectLikely { get; set; }

	public string LetterSubjectLikelyStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LetterIndicatorHeaderLikely")]
	public bool LetterHeaderLikely { get; set; }

	public string LetterHeaderLikelyStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LetterIndicatorContextLikely")]
	public bool LetterContextLikely { get; set; }

	public string LetterContextLikelyStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LetterIndicatorFooterLikely")]
	public bool LetterFooterLikely { get; set; }

	public string LetterFooterLikelyStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LetterIndicatorNumberCounterId")]
	public string LetterNumberCounterId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LetterIndicatorVerificationWorkflowId")]
	public string LetterIndicatorVerificationWorkflowId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LetterIndicatorVerificationWorkflowStepId")]
	public string LetterIndicatorVerificationWorkflowStepId { get; set; }
}

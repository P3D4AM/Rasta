using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class DocIndicatorViewModel
{
	[Display(ResourceType = typeof(Labels), Name = "DocIndicatorDate")]
	public string DocIndicatorDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocIndicatorFDate")]
	public string DocIndicatorFDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocIndicatorTDate")]
	public string DocIndicatorTDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocIndicatorNumber")]
	public string DocIndicatorNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocIndicatorCompanyId")]
	public string DocIndicatorCompanyId { get; set; }

	public string DocIndicatorCompanyName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocIndicatorOprId")]
	public string DocIndicatorOprId { get; set; }

	public string DocIndicatorWhId { get; set; }

	public string DocIndicatorWhIdI { get; set; }

	public string DocIndicatorOrderId { get; set; }

	public string DocIndicatorBuyOrderId { get; set; }

	public string DocIndicatorFirstRegisterUserId { get; set; }

	public string DocIndicatorPrdFirstGroupId { get; set; }

	public string DocIndicatorPrdSecondGroupId { get; set; }

	public string DocIndicatorPrdId { get; set; }

	public string DocIndicatorVerificationWorkflowId { get; set; }

	public string DocIndicatorVerificationWorkflowStepId { get; set; }

	public string DocIndicatorOtherFieldName { get; set; }

	public bool DocIndicatorOtherFieldValueLikelyBoolean { get; set; }

	public string DocIndicatorOtherFieldValueLikely { get; set; }

	public string DocIndicatorOtherFieldValue { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocIndicatorTracing")]
	public string Tracing { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocIndicatorWrhsId")]
	public string DocIndicatorWrhsId { get; set; }

	public string DocIndicatorWrhsIds { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocIndicatorWrhsIdI")]
	public string DocIndicatorWrhsIdI { get; set; }

	public string DocIndicatorWrhsIdsI { get; set; }
}

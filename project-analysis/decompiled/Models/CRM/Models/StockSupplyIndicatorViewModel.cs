using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class StockSupplyIndicatorViewModel
{
	[Display(ResourceType = typeof(Labels), Name = "StsupIndicatorDate")]
	public string StsupIndicatorDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "StsupIndicatorFDate")]
	public string StsupIndicatorFDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "StsupIndicatorTDate")]
	public string StsupIndicatorTDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "StsupIndicatorCompanyId")]
	public string StsupIndicatorCompanyId { get; set; }

	public string StsupIndicatorCompanyName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "StsupIndicatorStsupNumber")]
	public string StsupIndicatorStsupNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "StsupIndicatorReferUserId")]
	public string StsupIndicatorReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "StsupIndicatorWhId")]
	public string StsupIndicatorWhId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "StsupIndicatorPrdId")]
	public string StsupIndicatorPrdId { get; set; }

	public string StsupIndicatorPrdIdMulti { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "StsupIndicatorVerified")]
	public string StsupIndicatorVerified { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "StsupIndicatorVerificationWorkflowId")]
	public string StsupIndicatorVerificationWorkflowId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "StsupIndicatorVerificationWorkflowStepId")]
	public string StsupIndicatorVerificationWorkflowStepId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "StsupIndicatorCanceled")]
	public string StsupIndicatorCanceled { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "StsupIndicatorSupplyStatus")]
	public string StsupIndicatorSupplyStatus { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "StsupIndicatorOtherFieldName")]
	public string StsupIndicatorOtherFieldName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "StsupIndicatorOtherFieldValueLikely")]
	public bool StsupIndicatorOtherFieldValueLikelyBoolean { get; set; }

	public string StsupIndicatorOtherFieldValueLikely { get; set; }

	public string StsupIndicatorOtherFieldValue { get; set; }
}

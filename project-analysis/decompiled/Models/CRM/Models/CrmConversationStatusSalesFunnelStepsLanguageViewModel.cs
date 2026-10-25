using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmConversationStatusSalesFunnelStepsLanguageViewModel
{
	[Key]
	public int SalesFunnelStepId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SalesFunnelStepTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string SalesFunnelStepTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SalesFunnelStepStatusGroup")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? SalesFunnelStepStatusGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SalesFunnelStepStatuseNames")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string SalesFunnelStepStatusIDs { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SalesFunnelStepStatuseNames")]
	public string SalesFunnelStepStatusNames { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SalesFunnelStepOrder")]
	public int? SalesFunnelStepOrder { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SalesFunnelStepColor")]
	public string SalesFunnelStepColor { get; set; }

	public string SalesFunnelStepTitle_Lang { get; set; }
}

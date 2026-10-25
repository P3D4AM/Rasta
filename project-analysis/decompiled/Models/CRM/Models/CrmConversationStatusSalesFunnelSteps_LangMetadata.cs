using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmConversationStatusSalesFunnelSteps_LangMetadata
{
	[Key]
	public int CrmConversationStatusSalesFunnelStepsLangID { get; set; }

	public int SalesFunnelStepId { get; set; }

	public int LanguageID { get; set; }

	public string SalesFunnelStepTitle { get; set; }
}

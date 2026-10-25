using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmConversationStatusSalesFunnelSteps_LangMetadata))]
public class CrmConversationStatusSalesFunnelSteps_Lang
{
	public int CrmConversationStatusSalesFunnelStepsLangID { get; set; }

	public int SalesFunnelStepId { get; set; }

	public int LanguageID { get; set; }

	public string SalesFunnelStepTitle { get; set; }

	public virtual CrmConversationStatusSalesFunnelSteps CrmConversationStatusSalesFunnelSteps { get; set; }

	public virtual Languages Languages { get; set; }
}

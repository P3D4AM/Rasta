using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCompanyCampaign_LangMetadata))]
public class CrmCompanyCampaign_Lang
{
	public int CrmCompanyCampaignLangID { get; set; }

	public int CompanyCampaignId { get; set; }

	public int LanguageID { get; set; }

	public string CampaignName { get; set; }

	public virtual CrmCompanyCampaign CrmCompanyCampaign { get; set; }

	public virtual Languages Languages { get; set; }
}

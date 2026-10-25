using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmCompanyCampaign_LangMetadata
{
	[Key]
	public int CrmCompanyCampaignLangID { get; set; }

	public int CompanyCampaignId { get; set; }

	public int LanguageID { get; set; }

	public string CampaignName { get; set; }
}

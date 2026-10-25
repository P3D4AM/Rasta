namespace Mobile.Models;

public class MobspSelectCompanyCampaign_Result
{
	public int CompanyCampaignId { get; set; }

	public int ParentId { get; set; }

	public string ParentName { get; set; }

	public string ParentPath { get; set; }

	public string CampaignName { get; set; }

	public string CampaignFullName { get; set; }

	public int? CampaignDepth { get; set; }

	public bool? CampaignIsLeaf { get; set; }

	public int? OrderView { get; set; }
}

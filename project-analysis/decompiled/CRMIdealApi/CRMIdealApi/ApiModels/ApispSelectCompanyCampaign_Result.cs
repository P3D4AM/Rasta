using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectCompanyCampaign_Result
{
	public int ApiCompanyCampaignId { get; set; }

	public int ApiParentId { get; set; }

	public string ApiParentName { get; set; }

	public string ApiParentPath { get; set; }

	public string ApiCampaignName { get; set; }

	public string ApiCampaignFullName { get; set; }

	public int? ApiCampaignDepth { get; set; }

	public bool? ApiCampaignIsLeaf { get; set; }

	public int? ApiOrderView { get; set; }

	public int ApiFirstRegisterUserId { get; set; }

	public DateTime ApiFirstRegisterDate { get; set; }

	public int ApiUserId { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public string ApiEditUser { get; set; }
}

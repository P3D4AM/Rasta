namespace CRM.Models;

public class CrmCompanyChangeHistoryFieldViewModel
{
	public int? cmpGroupId { get; set; }

	public int? cmpSubGroupId { get; set; }

	public int? cmpGroupIdII { get; set; }

	public int? cmpGroupIdIII { get; set; }

	public int? cmpGroupIdIV { get; set; }

	public int? cmpTypeId { get; set; }

	public int? cmpPresentationId { get; set; }

	public int cmpReferUserId { get; set; }

	public int? cmpSuppUserId { get; set; }

	public string cmpGroupsMultiIds { get; set; }

	public string cmpCampaignIds { get; set; }
}

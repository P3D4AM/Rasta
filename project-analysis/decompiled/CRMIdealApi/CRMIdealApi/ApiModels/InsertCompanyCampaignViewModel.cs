namespace CRMIdealApi.ApiModels;

public class InsertCompanyCampaignViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int UserId { get; set; }

	public int? ApiParentId { get; set; }

	public string ApiCampaignName { get; set; }

	public int? ApiOrderView { get; set; }

	public int? LanguageId { get; set; }
}

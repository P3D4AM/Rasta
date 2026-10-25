namespace Mobile.Models;

public class FundViewModel
{
	public int CrmUserId { get; set; }

	public int FundId { get; set; }

	public int UserId { get; set; }

	public int FundGroupId { get; set; }

	public string fromDate { get; set; }

	public string toDate { get; set; }

	public int? PageNumber { get; set; }

	public int? PageSize { get; set; }

	public int? LanguageId { get; set; }
}

namespace Mobile.Models;

public class FundInsertEditeViewModel
{
	public int CrmUserId { get; set; }

	public int FundId { get; set; }

	public int UserId { get; set; }

	public int FundGroupId { get; set; }

	public string FundDatePersian { get; set; }

	public int FundNumber { get; set; }

	public string FundDesc { get; set; }

	public string FundDesc_Lang { get; set; }

	public decimal? FundCredit { get; set; }

	public decimal? FundDebit { get; set; }

	public decimal? FundRemain { get; set; }

	public int? FundOrderView { get; set; }

	public int? LanguageId { get; set; }
}

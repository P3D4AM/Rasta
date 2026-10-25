namespace CRM.Models;

public class CmpAccountingLinkAccDataViewModel
{
	public int? DBId { get; set; }

	public string DbName { get; set; }

	public string DbTitle { get; set; }

	public string cmpLinkAccAllPayRemain { get; set; }

	public decimal? AllPayRemain { get; set; }

	public string AllPayRemainStr { get; set; }

	public decimal? DebitBalance { get; set; }

	public string DebitBalanceStr { get; set; }

	public decimal? CreditBalance { get; set; }

	public string CreditBalanceStr { get; set; }

	public bool? HaveError { get; set; }
}

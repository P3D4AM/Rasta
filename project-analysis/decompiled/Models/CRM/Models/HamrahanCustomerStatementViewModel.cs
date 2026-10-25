namespace CRM.Models;

public class HamrahanCustomerStatementViewModel
{
	public int? recNo { get; set; }

	public string customerCode { get; set; }

	public string nameFormal { get; set; }

	public decimal? debtor_First { get; set; }

	public decimal? creditor_First { get; set; }

	public decimal? debtor { get; set; }

	public decimal? creditor { get; set; }

	public decimal? sumRemain { get; set; }
}

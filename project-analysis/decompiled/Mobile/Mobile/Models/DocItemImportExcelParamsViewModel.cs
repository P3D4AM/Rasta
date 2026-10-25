namespace Mobile.Models;

public class DocItemImportExcelParamsViewModel
{
	public string DocItemJson { get; set; }

	public int DocId { get; set; }

	public int WHId { get; set; }

	public int WHIdI { get; set; }

	public int Position { get; set; }

	public int? OrderId { get; set; }

	public int? BuyOrderId { get; set; }

	public int? LanguageId { get; set; }

	public int? CenterId { get; set; }
}

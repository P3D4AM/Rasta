namespace CRM.Models;

public class StockSupplyListViewModel
{
	public int? stsupCurrentId { get; set; }

	public int companyId { get; set; }

	public long stsupNumber { get; set; }

	public string fromDate { get; set; }

	public string toDate { get; set; }

	public int? userId { get; set; }

	public int? stockSupplyId { get; set; }
}

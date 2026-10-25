namespace CRM.Models;

public class WareHouseMovementListViewModel
{
	public int docCurrentId { get; set; }

	public int? companyId { get; set; }

	public int? docNumber { get; set; }

	public string fromDate { get; set; }

	public string toDate { get; set; }

	public int? userId { get; set; }

	public int? docId { get; set; }

	public int oprType { get; set; }
}

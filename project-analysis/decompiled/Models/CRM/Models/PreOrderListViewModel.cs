namespace CRM.Models;

public class PreOrderListViewModel
{
	public int poreOrderCurrentId { get; set; }

	public int companyId { get; set; }

	public int preOrderNumber { get; set; }

	public string fromDate { get; set; }

	public string toDate { get; set; }

	public int? userId { get; set; }

	public int? preOrderId { get; set; }

	public string linkAccPreOrderNumber { get; set; }
}

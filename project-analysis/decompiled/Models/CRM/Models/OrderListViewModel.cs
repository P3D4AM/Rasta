namespace CRM.Models;

public class OrderListViewModel
{
	public int orderCurrentId { get; set; }

	public int companyId { get; set; }

	public int orderNumber { get; set; }

	public string fromDate { get; set; }

	public string toDate { get; set; }

	public int? userId { get; set; }

	public int? orderId { get; set; }

	public string linkAccOrderNumber { get; set; }
}

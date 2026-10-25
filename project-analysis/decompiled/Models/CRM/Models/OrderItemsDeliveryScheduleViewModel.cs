namespace CRM.Models;

public class OrderItemsDeliveryScheduleViewModel
{
	public bool IsFind { get; set; }

	public string Message { get; set; }

	public long TotalPage { get; set; }

	public OrdItemsDeliveryScheduleListViewModel Result { get; set; }
}

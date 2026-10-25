namespace CRM.Models;

public class OrderDeliveryScheduleViewModel
{
	public bool IsFind { get; set; }

	public string Message { get; set; }

	public long TotalPage { get; set; }

	public OrdDeliveryScheduleListViewModel Result { get; set; }
}

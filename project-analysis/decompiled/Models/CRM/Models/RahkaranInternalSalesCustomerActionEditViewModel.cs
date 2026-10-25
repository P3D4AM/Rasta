namespace CRM.Models;

public class RahkaranInternalSalesCustomerActionEditViewModel<T>
{
	public int Action { get; set; }

	public T NewValue { get; set; }

	public T OldValue { get; set; }
}

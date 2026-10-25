namespace CRM.Models;

public class ShygunDetailedAPIPuRequestViewModel<T>
{
	public ShygunDetailedAPIConfigViewModel Config { get; set; }

	public T PutObject { get; set; }
}

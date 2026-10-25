namespace CRM.Models;

public class ShygunDetailedAPIRequestViewModel<T>
{
	public ShygunDetailedAPIConfigViewModel Config { get; set; }

	public T Domain { get; set; }
}

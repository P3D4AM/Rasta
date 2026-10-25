namespace CRM.Models;

public class CommonResultViewModel<T>
{
	public T Data;

	public CommonResultStatusViewModel Status;

	public string Message;

	public CommonResultViewModel()
	{
		Status = CommonResultStatusViewModel.Success;
	}

	public CommonResultViewModel(CommonResultStatusViewModel type)
	{
		Status = type;
	}
}

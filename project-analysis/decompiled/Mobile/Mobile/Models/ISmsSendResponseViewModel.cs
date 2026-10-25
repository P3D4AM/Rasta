namespace Mobile.Models;

public class ISmsSendResponseViewModel
{
	public long? code { get; set; }

	public string message { get; set; }

	public long[] ids { get; set; }
}

namespace CRM.Models;

public class HamyarAPIResponseViewModel<T>
{
	public bool? isSuccess { get; set; }

	public string message { get; set; }

	public long? totalPages { get; set; }

	public long? totalItems { get; set; }

	public long? currentPage { get; set; }

	public T data { get; set; }

	public string[] errors { get; set; }
}

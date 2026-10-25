namespace Mobile.Models;

public class UpdateOrderViewModel
{
	public string Order { get; set; }

	public int OrderId { get; set; }

	public int? LanguageId { get; set; }

	public string ErrorMessage { get; set; }

	public int? CenterId { get; set; }
}

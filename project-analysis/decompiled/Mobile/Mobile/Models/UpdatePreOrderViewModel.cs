namespace Mobile.Models;

public class UpdatePreOrderViewModel
{
	public string PreOrder { get; set; }

	public int PreOrderId { get; set; }

	public int? LanguageId { get; set; }

	public string ErrorMessage { get; set; }

	public int? CenterId { get; set; }
}

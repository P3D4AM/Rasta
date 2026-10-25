namespace Mobile.Models;

public class UpdatePreOrderItemViewModel
{
	public string PreOrderItem { get; set; }

	public int PreOrderItemId { get; set; }

	public int? LanguageId { get; set; }

	public string ErrorMessage { get; set; }

	public int? CenterId { get; set; }

	public bool haveLinkAccQtyCheck { get; set; }
}

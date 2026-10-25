namespace Mobile.Models;

public class UpdateOrderItemViewModel
{
	public string OrderItem { get; set; }

	public int OrderItemId { get; set; }

	public int? LanguageId { get; set; }

	public string ErrorMessage { get; set; }

	public int? CenterId { get; set; }

	public bool haveLinkAccQtyCheck { get; set; }
}

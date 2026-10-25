namespace Mobile.Models;

public class InsertOrderFullViewModel
{
	public string Order { get; set; }

	public string OrdItemList { get; set; }

	public string OrdPaymentList { get; set; }

	public int? LanguageId { get; set; }

	public int? UserId { get; set; }

	public string ErrorMessage { get; set; }

	public bool AddLinkedProducts { get; set; }

	public string OrderNumber { get; set; }

	public string ListOrdIssued { get; set; }

	public int? CenterId { get; set; }

	public string OrderItemSerialList { get; set; }

	public bool haveLinkAccQtyCheck { get; set; }
}

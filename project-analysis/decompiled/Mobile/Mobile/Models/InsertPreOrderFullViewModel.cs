namespace Mobile.Models;

public class InsertPreOrderFullViewModel
{
	public string PreOrder { get; set; }

	public string PordItemList { get; set; }

	public string PordItemSpecificationList { get; set; }

	public string PordPaymentList { get; set; }

	public int? LanguageId { get; set; }

	public string ErrorMessage { get; set; }

	public bool AddLinkedProducts { get; set; }

	public int? CenterId { get; set; }

	public bool haveLinkAccQtyCheck { get; set; }
}

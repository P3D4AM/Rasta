namespace Mobile.Models.ViewModel.PreOrder;

public class InsertShopPreOrderFullViewModel
{
	public string PreOrder { get; set; }

	public string PordItemList { get; set; }

	public string PordItemSpecificationList { get; set; }

	public string PordPaymentList { get; set; }

	public int? LanguageId { get; set; }

	public string ErrorMessage { get; set; }

	public bool AddLinkedProducts { get; set; }

	public string PrdDoneTimeJs { get; set; }
}

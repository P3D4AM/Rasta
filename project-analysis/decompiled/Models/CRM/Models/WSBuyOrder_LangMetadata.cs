namespace CRM.Models;

public class WSBuyOrder_LangMetadata
{
	public int WSBuyOrderLangID { get; set; }

	public int BuyOrderID { get; set; }

	public int LanguageID { get; set; }

	public string bordTitle { get; set; }

	public string bordSubject { get; set; }

	public string bordTotalAmountStr { get; set; }

	public string bordDiscountTitle { get; set; }

	public string bordNote { get; set; }

	public string bordcmpTitle { get; set; }
}

namespace CRM.Models;

public class WSOrder_LangMetadata
{
	public int WSOrderLangID { get; set; }

	public int OrderID { get; set; }

	public string ordTitle { get; set; }

	public string ordSubject { get; set; }

	public string ordSpecialWord { get; set; }

	public string ordDescriptionI { get; set; }

	public string ordDescriptionII { get; set; }

	public string ordSigningI { get; set; }

	public string ordSigningII { get; set; }

	public string ordSigningIII { get; set; }

	public string ordDiscountTitle { get; set; }

	public string ordNote { get; set; }

	public string ordcmpTitle { get; set; }

	public int LanguageID { get; set; }

	public string ordTotalAmountStr { get; set; }
}

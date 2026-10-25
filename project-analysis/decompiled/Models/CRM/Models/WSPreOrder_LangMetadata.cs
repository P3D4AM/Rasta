namespace CRM.Models;

public class WSPreOrder_LangMetadata
{
	public int WSPreOrderLangID { get; set; }

	public int PreOrderID { get; set; }

	public int LanguageID { get; set; }

	public string pordTitle { get; set; }

	public string pordSubject { get; set; }

	public string pordTotalAmountStr { get; set; }

	public string pordSpecialWord { get; set; }

	public string pordDescriptionI { get; set; }

	public string pordDescriptionII { get; set; }

	public string pordSigningI { get; set; }

	public string pordSigningII { get; set; }

	public string pordSigningIII { get; set; }

	public string pordAddress { get; set; }

	public string pordDiscountTitle { get; set; }

	public string pordcmpTitle { get; set; }
}

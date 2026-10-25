using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class WSOrderPaymentGroupsII_LangMetadata
{
	[Key]
	public int WSOrderPaymentGroupsIILangID { get; set; }

	public int OrderPaymentGroupIIId { get; set; }

	public int LanguageID { get; set; }

	public string ordpayGroupIIName { get; set; }
}

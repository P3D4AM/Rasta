using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class WSOrderPaymentGroupsI_LangMetadata
{
	[Key]
	public int WSOrderPaymentGroupsILangID { get; set; }

	public int OrderPaymentGroupIId { get; set; }

	public int LanguageID { get; set; }

	public string ordpayGroupIName { get; set; }
}

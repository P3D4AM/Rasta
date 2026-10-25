using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class PayRollUserPayments_LangMetadata
{
	[Key]
	public int PayRollUserPaymentLangID { get; set; }

	public int PayRollUserPaymentId { get; set; }

	public int LanguageID { get; set; }

	public string Description { get; set; }
}

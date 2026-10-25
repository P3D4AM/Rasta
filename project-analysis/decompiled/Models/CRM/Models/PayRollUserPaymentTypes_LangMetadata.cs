using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class PayRollUserPaymentTypes_LangMetadata
{
	[Key]
	public int PayRollUserPaymentTypeLangID { get; set; }

	public string PaymentType { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(PayRollUserPaymentTypes_LangMetadata))]
public class PayRollUserPaymentTypes_Lang
{
	public int PayRollUserPaymentTypeLangID { get; set; }

	public int PayRollUserPaymentTypeId { get; set; }

	public int LanguageID { get; set; }

	public string PaymentType { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual PayRollUserPaymentTypes PayRollUserPaymentTypes { get; set; }
}

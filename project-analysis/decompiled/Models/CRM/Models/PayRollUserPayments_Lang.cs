using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(PayRollUserPayments_LangMetadata))]
public class PayRollUserPayments_Lang
{
	public int PayRollUserPaymentLangID { get; set; }

	public int PayRollUserPaymentId { get; set; }

	public int LanguageID { get; set; }

	public string Description { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual PayRollUserPayments PayRollUserPayments { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSPreOrderPayments_LangMetadata))]
public class WSPreOrderPayments_Lang
{
	public int WSPreOrderPaymentsLangID { get; set; }

	public int PreOrderPaymentId { get; set; }

	public int LanguageID { get; set; }

	public string pordpayDescription { get; set; }

	public string pordpayBankName { get; set; }

	public string pordpayBranchName { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSPreOrderPayments WSPreOrderPayments { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSBuyOrderPayments_LangMetadata))]
public class WSBuyOrderPayments_Lang
{
	public int WSBuyOrderPaymentsLangID { get; set; }

	public int BuyOrderPaymentId { get; set; }

	public int LanguageID { get; set; }

	public string bordpayDescription { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSBuyOrderPayments WSBuyOrderPayments { get; set; }
}

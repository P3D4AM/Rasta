using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSBuyOrderPaymentTypes_LangMetadata))]
public class WSBuyOrderPaymentTypes_Lang
{
	public int WSBuyOrderPaymentTypesLangID { get; set; }

	public int BuyOrderPaymentTypeId { get; set; }

	public int LanguageID { get; set; }

	public string bordpayType { get; set; }

	public string bordpayTypeDescription { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSBuyOrderPaymentTypes WSBuyOrderPaymentTypes { get; set; }
}

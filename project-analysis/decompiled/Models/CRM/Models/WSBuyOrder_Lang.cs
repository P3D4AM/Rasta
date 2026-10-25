using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSBuyOrder_LangMetadata))]
public class WSBuyOrder_Lang
{
	public int WSBuyOrderLangID { get; set; }

	public int BuyOrderID { get; set; }

	public int LanguageID { get; set; }

	public string bordTitle { get; set; }

	public string bordSubject { get; set; }

	public string bordTotalAmountStr { get; set; }

	public string bordDiscountTitle { get; set; }

	public string bordNote { get; set; }

	public string bordcmpTitle { get; set; }

	public string bordDeliveryTerm { get; set; }

	public string bordForwarderName { get; set; }

	public string bordCustomsPart { get; set; }

	public string bordTotalAmountCurrencyIStr { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSBuyOrder WSBuyOrder { get; set; }
}

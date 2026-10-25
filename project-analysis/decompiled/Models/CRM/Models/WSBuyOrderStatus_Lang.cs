using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSBuyOrderStatus_LangMetadata))]
public class WSBuyOrderStatus_Lang
{
	public int WSBuyOrderStatusLangID { get; set; }

	public int BuyOrderStatusId { get; set; }

	public int LanguageID { get; set; }

	public string BuyOrderStatus { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSBuyOrderStatus WSBuyOrderStatus { get; set; }
}

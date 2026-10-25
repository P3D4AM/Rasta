using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSBuyOrderItems_LangMetadata))]
public class WSBuyOrderItems_Lang
{
	public int WSBuyOrderItemsLangID { get; set; }

	public int BuyOrderItemId { get; set; }

	public int LanguageID { get; set; }

	public string bordIDescription { get; set; }

	public string bordIQuantityDesc { get; set; }

	public string bordIForwarderName { get; set; }

	public string bordICustomsPart { get; set; }

	public string bordIPrdNickname { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSBuyOrderItems WSBuyOrderItems { get; set; }
}

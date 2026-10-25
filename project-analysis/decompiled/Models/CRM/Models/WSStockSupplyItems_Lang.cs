using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSStockSupplyItems_LangMetadata))]
public class WSStockSupplyItems_Lang
{
	public int WSStockSupplyItemsLangID { get; set; }

	public int StockSupplyItemId { get; set; }

	public int LanguageID { get; set; }

	public string stsupIDescription { get; set; }

	public string stsupIQuantityDesc { get; set; }

	public string stsupIPrdNickname { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSStockSupplyItems WSStockSupplyItems { get; set; }
}

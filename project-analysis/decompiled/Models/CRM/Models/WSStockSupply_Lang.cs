using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSStockSupply_LangMetadata))]
public class WSStockSupply_Lang
{
	public int WSStockSupplyLangID { get; set; }

	public int StockSupplyId { get; set; }

	public int LanguageID { get; set; }

	public string stsupNote { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSStockSupply WSStockSupply { get; set; }
}

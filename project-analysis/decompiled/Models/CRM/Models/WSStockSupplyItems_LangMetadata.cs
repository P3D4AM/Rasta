using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class WSStockSupplyItems_LangMetadata
{
	[Key]
	public int WSStockSupplyItemsLangID { get; set; }

	public int StockSupplyItemId { get; set; }

	public int LanguageID { get; set; }

	public string stsupIDescription { get; set; }

	public string stsupIQuantityDesc { get; set; }

	public string stsupIPrdNickname { get; set; }
}

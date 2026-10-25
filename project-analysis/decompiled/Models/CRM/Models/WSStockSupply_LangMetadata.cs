using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class WSStockSupply_LangMetadata
{
	[Key]
	public int WSStockSupplyLangID { get; set; }

	public int StockSupplyId { get; set; }

	public int LanguageID { get; set; }

	public string stsupNote { get; set; }
}

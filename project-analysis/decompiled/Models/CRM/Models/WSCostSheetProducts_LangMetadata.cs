using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class WSCostSheetProducts_LangMetadata
{
	[Key]
	public int WSCostSheetProductLangID { get; set; }

	public int CostSheetProductId { get; set; }

	public int LanguageID { get; set; }

	public string ctshPrdName { get; set; }
}

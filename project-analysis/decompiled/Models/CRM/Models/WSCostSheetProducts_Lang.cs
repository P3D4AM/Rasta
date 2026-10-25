using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSCostSheetProducts_LangMetadata))]
public class WSCostSheetProducts_Lang
{
	public int WSCostSheetProductLangID { get; set; }

	public int CostSheetProductId { get; set; }

	public int LanguageID { get; set; }

	public string ctshPrdName { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSCostSheetProducts WSCostSheetProducts { get; set; }
}

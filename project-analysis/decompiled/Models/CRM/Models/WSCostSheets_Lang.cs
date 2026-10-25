using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSCostSheets_LangMetadata))]
public class WSCostSheets_Lang
{
	public int WSCostSheetLangID { get; set; }

	public int CostSheetId { get; set; }

	public int LanguageID { get; set; }

	public string ctshTitle { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSCostSheets WSCostSheets { get; set; }
}

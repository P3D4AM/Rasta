using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class WSCostSheets_LangMetadata
{
	[Key]
	public int WSCostSheetLangID { get; set; }

	public int CostSheetId { get; set; }

	public int LanguageID { get; set; }

	public string ctshTitle { get; set; }
}

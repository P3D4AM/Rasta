using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class WSCostSheetDyFieldTitle_LangMetadata
{
	[Key]
	public int WSCostSheetDyFieldTitleLangID { get; set; }

	public int CostSheetDyFieldTitleId { get; set; }

	public int LanguageID { get; set; }

	public string ctshDyFieldTitle { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class WSCostSheetDyFieldGroups_LangMetadata
{
	[Key]
	public int WSCostSheetDyFieldGroupLangID { get; set; }

	public int CostSheetDyFieldGroupId { get; set; }

	public int LanguageID { get; set; }

	public string ctshDyFieldGroupName { get; set; }
}

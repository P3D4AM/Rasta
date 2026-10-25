using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSCostSheetDyFieldGroups_LangMetadata))]
public class WSCostSheetDyFieldGroups_Lang
{
	public int WSCostSheetDyFieldGroupLangID { get; set; }

	public int CostSheetDyFieldGroupId { get; set; }

	public int LanguageID { get; set; }

	public string ctshDyFieldGroupName { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSCostSheetDyFieldGroups WSCostSheetDyFieldGroups { get; set; }
}

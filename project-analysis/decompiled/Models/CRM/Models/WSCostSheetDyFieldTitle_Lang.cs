using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSCostSheetDyFieldTitle_LangMetadata))]
public class WSCostSheetDyFieldTitle_Lang
{
	public int WSCostSheetDyFieldTitleLangID { get; set; }

	public int CostSheetDyFieldTitleId { get; set; }

	public int LanguageID { get; set; }

	public string ctshDyFieldTitle { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSCostSheetDyFieldTitle WSCostSheetDyFieldTitle { get; set; }
}

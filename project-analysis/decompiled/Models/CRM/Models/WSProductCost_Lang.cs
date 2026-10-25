using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSProductCost_LangMetadata))]
public class WSProductCost_Lang
{
	public int WSProductCostLangID { get; set; }

	public int ProductCostID { get; set; }

	public int LanguageID { get; set; }

	public string Description { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSProductCost WSProductCost { get; set; }
}

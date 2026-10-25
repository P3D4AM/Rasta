using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSProductCostGroup_LangMetadata))]
public class WSProductCostGroup_Lang
{
	public int WSProductCostGroupLangID { get; set; }

	public int ProductCostGroupID { get; set; }

	public int LanguageID { get; set; }

	public string ProductCostGroupName { get; set; }

	public string ProductCostGroupDesc { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSProductCostGroup WSProductCostGroup { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSProductFirstGroup_LangMetadata))]
public class WSProductFirstGroup_Lang
{
	public int WSProductFirstGroupLangID { get; set; }

	public int PrdFirstGroupID { get; set; }

	public int LanguageID { get; set; }

	public string FGName { get; set; }

	public string FGDescription { get; set; }

	public string FGNameEn { get; set; }

	public string FGSHPName { get; set; }

	public string FGSeoTitle { get; set; }

	public string FGSeoDescription { get; set; }

	public string FGSeoAuthor { get; set; }

	public string FGSeoCopyright { get; set; }

	public string FGSeoKeywords { get; set; }

	public string FGSeoFAQ { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSProductFirstGroup WSProductFirstGroup { get; set; }
}

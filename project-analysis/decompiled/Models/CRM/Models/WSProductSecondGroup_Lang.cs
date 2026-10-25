using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSProductSecondGroup_LangMetadata))]
public class WSProductSecondGroup_Lang
{
	public int WSProductSecondGroupLangId { get; set; }

	public int PrdSecondGroupID { get; set; }

	public int LanguageID { get; set; }

	public string SGName { get; set; }

	public string SGDescription { get; set; }

	public string SGNameEn { get; set; }

	public string SGSHPName { get; set; }

	public string SGSeoTitle { get; set; }

	public string SGSeoDescription { get; set; }

	public string SGSeoAuthor { get; set; }

	public string SGSeoCopyright { get; set; }

	public string SGSeoKeywords { get; set; }

	public string SGSeoFAQ { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSProductSecondGroup WSProductSecondGroup { get; set; }
}

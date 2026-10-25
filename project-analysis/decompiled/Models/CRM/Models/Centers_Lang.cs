using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(Centers_LangMetadata))]
public class Centers_Lang
{
	public int CenterLangID { get; set; }

	public int CenterId { get; set; }

	public string CenterName { get; set; }

	public string CenterDesc { get; set; }

	public int LanguageID { get; set; }

	public string CenterSeoTitle { get; set; }

	public string CenterSeoDescription { get; set; }

	public string CenterSeoAuthor { get; set; }

	public string CenterSeoCopyright { get; set; }

	public string CenterSeoKeywords { get; set; }

	public string CenterSeoFAQ { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual Languages Languages { get; set; }
}

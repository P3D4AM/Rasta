using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(SmsDefaultBodyTextGroups_LangMetadata))]
public class SmsDefaultBodyTextGroups_Lang
{
	public int SmsDefaultBodyTextGroupsLangID { get; set; }

	public int Id { get; set; }

	public int LanguageID { get; set; }

	public string Name { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual SmsDefaultBodyTextGroups SmsDefaultBodyTextGroups { get; set; }
}

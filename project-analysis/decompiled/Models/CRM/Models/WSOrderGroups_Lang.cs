using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSOrderGroups_LangMetadata))]
public class WSOrderGroups_Lang
{
	public int WSOrderGroupLangID { get; set; }

	public int OrderGroupId { get; set; }

	public int LanguageID { get; set; }

	public string OrderGroupName { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSOrderGroups WSOrderGroups { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(PayRollListGroups_LangMetadata))]
public class PayRollListGroups_Lang
{
	public int PayRollListGroupLangID { get; set; }

	public int PayRollListGroupId { get; set; }

	public int LanguageID { get; set; }

	public string ListGroupName { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual PayRollListGroups PayRollListGroups { get; set; }
}

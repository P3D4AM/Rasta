using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmLinkAccShygunIISetting_LangMetadata))]
public class CrmLinkAccShygunIISetting_Lang
{
	public int CrmLinkAccShygunIISettingLangID { get; set; }

	public int LinkAccShygunIISettingId { get; set; }

	public int LanguageID { get; set; }

	public string PartDescription { get; set; }

	public string PartLabelTitle { get; set; }

	public string Description { get; set; }

	public virtual CrmLinkAccShygunIISetting CrmLinkAccShygunIISetting { get; set; }

	public virtual Languages Languages { get; set; }
}

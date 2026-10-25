using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmLinkAccArpaSetting_LangMetadata))]
public class CrmLinkAccArpaSetting_Lang
{
	public int CrmLinkAccArpaSettingLangID { get; set; }

	public int LinkAccArpaSettingId { get; set; }

	public int LanguageID { get; set; }

	public string PartDescription { get; set; }

	public string PartLabelTitle { get; set; }

	public string Description { get; set; }

	public virtual CrmLinkAccArpaSetting CrmLinkAccArpaSetting { get; set; }

	public virtual Languages Languages { get; set; }
}

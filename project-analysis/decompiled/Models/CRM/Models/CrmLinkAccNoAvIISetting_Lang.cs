using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmLinkAccNoAvIISetting_LangMetadata))]
public class CrmLinkAccNoAvIISetting_Lang
{
	public int CrmLinkAccNoAvIISettingLangID { get; set; }

	public int LinkAccNoAvIISettingId { get; set; }

	public int LanguageID { get; set; }

	public string PartDescription { get; set; }

	public string PartLabelTitle { get; set; }

	public string Description { get; set; }

	public virtual CrmLinkAccNoAvIISetting CrmLinkAccNoAvIISetting { get; set; }

	public virtual Languages Languages { get; set; }
}

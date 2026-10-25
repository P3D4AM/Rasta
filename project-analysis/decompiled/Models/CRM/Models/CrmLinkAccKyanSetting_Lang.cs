using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmLinkAccKyanSetting_LangMetadata))]
public class CrmLinkAccKyanSetting_Lang
{
	public int CrmLinkAccKyanSettingLangID { get; set; }

	public int LinkAccKyanSettingId { get; set; }

	public int LanguageID { get; set; }

	public string PartDescription { get; set; }

	public string PartLabelTitle { get; set; }

	public string Description { get; set; }

	public virtual CrmLinkAccKyanSetting CrmLinkAccKyanSetting { get; set; }

	public virtual Languages Languages { get; set; }
}

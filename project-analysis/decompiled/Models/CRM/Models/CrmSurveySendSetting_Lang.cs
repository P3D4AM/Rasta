using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmSurveySendSetting_LangMetadata))]
public class CrmSurveySendSetting_Lang
{
	public int CrmSurveySendSettingLangID { get; set; }

	public int SurveySendSettingId { get; set; }

	public int LanguageID { get; set; }

	public string surssTitle { get; set; }

	public virtual CrmSurveySendSetting CrmSurveySendSetting { get; set; }

	public virtual Languages Languages { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmSurveySendSetting_LangMetadata
{
	[Key]
	public int CrmSurveySendSettingLangID { get; set; }

	public int SurveySendSettingId { get; set; }

	public int LanguageID { get; set; }

	public string surssTitle { get; set; }
}

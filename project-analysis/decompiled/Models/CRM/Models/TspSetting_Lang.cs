using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(TspSetting_LangMetadata))]
public class TspSetting_Lang
{
	public int TspSettingLangID { get; set; }

	public int TspSettingId { get; set; }

	public int LanguageID { get; set; }

	public string TspSettingTitle { get; set; }

	public string TspCoName { get; set; }

	public string TspAddress { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual TspSetting TspSetting { get; set; }
}
